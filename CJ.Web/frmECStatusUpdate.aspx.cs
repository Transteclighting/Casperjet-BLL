using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CJ.Class;
using CJ.Report;

public partial class frmECStatusUpdate : System.Web.UI.Page
{
   
    Warehouse oWarehouse;
    Utilities _oUtilitys;
    ECOrder oECOrder;
    int nCurrentStatus = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBController.Instance.OpenNewConnection();

            _oUtilitys = new Utilities();
            cbSatus.Items.Clear();
            _oUtilitys.GetECOrderStatusForTD();          
            cbSatus.DataSource = _oUtilitys;
            cbSatus.DataTextField = "Satus";
            cbSatus.DataBind();

            oECOrder = (ECOrder)Session["ECOrder"];
            lbOrderNo.Text = oECOrder.OrderNo;
            lbOrderDate.Text = oECOrder.OrderDate.ToString("dd-MMM-yyyy");
            lbCustomer.Text = oECOrder.CustomerName;
            lbMail.Text = oECOrder.CustomerMailID;
            lbMobile.Text = oECOrder.CustomerMobileNo;
            oWarehouse = new Warehouse();
            oWarehouse.WarehouseID = oECOrder.DeliveryWHID;
            oWarehouse.Reresh();
            lbWarehouse.Text = oWarehouse.WarehouseName;
            RefreshGrid();
        }
    }
    private bool validateUIInput()
    {
        #region Order Master Information Validation
        if (txtRemarks.Text == "")
        {
            lblMessage.Visible = true;
             lblMessage.Text = "Please enter remarks.";
             txtRemarks.Focus();
            return false;
        }
        #endregion

        return true;
    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("ProductCode", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
        dt.Columns.Add(new DataColumn("Quantity", typeof(string)));

        oECOrder = (ECOrder)Session["ECOrder"];
        oECOrder.RefreshItem();

        foreach (ECOrderDetail oECOrderDetail in oECOrder)
        {
            DateTime _dDate = Convert.ToDateTime(oECOrder.OrderDate);

            dr = dt.NewRow();

            dr["ProductCode"] = oECOrderDetail.ProductCode;
            dr["ProductName"] = oECOrderDetail.ProductName;
            dr["Quantity"] = oECOrderDetail.Qty.ToString();
          
            dt.Rows.Add(dr);
        }  

        ViewState["ProductTable"] = dt;
        dvwProduct.DataSource = dt;
        dvwProduct.DataBind();
      
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        if (validateUIInput())
        {
            oECOrder = (ECOrder)Session["ECOrder"];
            Session.Add("CurrentStatus", oECOrder.OrderStatus);
            if (oECOrder != null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    if (txtRemarks.Text == "Confirm_Stock_HO")
                    {
                       
                    }
                    else
                    {
                        oECOrder.UserID = Utility.UserId;
                        oECOrder.Date = DateTime.Now;
                        oECOrder.Remarks = txtRemarks.Text;
                        oECOrder.OrderStatus = GetStatus();
                        //if (CheckStatus(oECOrder))
                            oECOrder.UpdateStatus();
                        //else
                        //{
                        //    lblMessage.Visible = true;
                        //    lblMessage.Text = "Invalid Status,Please Input Valid Status";
                        //    return;
                        //}
                    }
                    DBController.Instance.CommitTransaction();
                    string[] sSuccedCode =  { "" };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Save", "This Order", sSuccedCode, null, "frmECOrders.aspx", 0);
                    Response.Redirect("frmMessage.aspx");
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error... " + ex;
                }
            }
        }
    }
    public int GetStatus()
    {
        if (cbSatus.Text == "Confirm_Payment")
            return (int)Dictionary.ECOrderStatus.Confirm_Payment;
        else if (cbSatus.Text == "Stock_to_be_Available_Within_2WD")
            return (int)Dictionary.ECOrderStatus.Stock_to_be_Available_Within_2WD;
        else if (cbSatus.Text == "Confirm_Stock_Outlet")
            return (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet;
        else if (cbSatus.Text == "Happy_Call")
            return (int)Dictionary.ECOrderStatus.Happy_Call;
        else if (cbSatus.Text == "Product_Delivered")
            return (int)Dictionary.ECOrderStatus.Product_Delivered;
        else if (cbSatus.Text == "Stock_No_Longer_Available")
            return (int)Dictionary.ECOrderStatus.Stock_No_Longer_Available;
        else if (cbSatus.Text == "UnAvailable_Stock_Outlet")
            return (int)Dictionary.ECOrderStatus.UnAvailable_Stock_Outlet;
        else if (cbSatus.Text == "Stock_to_be_Available_later")
            return (int)Dictionary.ECOrderStatus.Stock_to_be_Available_later;
        else if (cbSatus.Text == "Order_Confirmation_from_Customer")
            return (int)Dictionary.ECOrderStatus.Order_Confirmation_from_Customer;
        else if (cbSatus.Text == "Pick_Up_DD_Extended")
            return (int)Dictionary.ECOrderStatus.Pick_Up_DD_Extended;
        else if (cbSatus.Text == "Cancel")
            return (int)Dictionary.ECOrderStatus.Cancel;
        return 0;
    }
    public bool CheckStatus(ECOrder oECOrder)
    {
        int nCount = 0;
        nCurrentStatus = (int)Session["CurrentStatus"];
        if (nCurrentStatus == (int)Dictionary.ECOrderStatus.Submitted)
        {
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.UnAvailable_Stock_Outlet || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
            {
                nCount++;
            }
        }
        if (nCurrentStatus == (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet)
        {
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Confirm_Payment || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
            {
                nCount++;
            }
        }
        if (nCurrentStatus == (int)Dictionary.ECOrderStatus.Confirm_Payment)
        {
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Product_Delivered || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
            {
                nCount++;
            }
        }
        if (nCurrentStatus == (int)Dictionary.ECOrderStatus.Product_Delivered)
        {
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Happy_Call)
            {
                nCount++;
            }
        }
        if (nCurrentStatus == (int)Dictionary.ECOrderStatus.UnAvailable_Stock_Outlet)
        {
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Stock_to_be_Available_Within_2WD || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Stock_No_Longer_Available || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
            {
                nCount++;
            }
        }
        if (nCurrentStatus == (int)Dictionary.ECOrderStatus.Stock_to_be_Available_Within_2WD)
        {
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
            {
                nCount++;
            }
        }
        if (nCurrentStatus == (int)Dictionary.ECOrderStatus.Stock_No_Longer_Available)
        {
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
            {
                nCount++;
            }
        }
        if (nCount == 0)
            return false;
        else return true;
    }

    protected void lnkShowdata_Click(object sender, EventArgs e)
    {
        oECOrder = (ECOrder)Session["ECOrder"];
        oECOrder.RefreshItem();

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptECOrder));
        doc.SetDataSource(oECOrder);

        doc.SetParameterValue("CustomerName", oECOrder.CustomerName);
        doc.SetParameterValue("CustomerAddress", oECOrder.CustomerAddress);
        doc.SetParameterValue("Mail", oECOrder.CustomerMailID);
        doc.SetParameterValue("Mobile", oECOrder.CustomerMobileNo);
        doc.SetParameterValue("OrderNo", oECOrder.OrderNo);
        doc.SetParameterValue("OrderDate", oECOrder.OrderDate.ToString("dd-MMM-yyyy"));
        doc.SetParameterValue("Amount", oECOrder.Amount);
        if (oECOrder.PaymentMode == (int)Dictionary.ECOPaymentMode.Cash)
            doc.SetParameterValue("PaymentMode", "Cash");
        else doc.SetParameterValue("PaymentMode", "Electronic");
        doc.SetParameterValue("PaymentDate", oECOrder.DesiredPaymentDate.ToString("dd-MMM-yyyy"));
        doc.SetParameterValue("PaymentDes", oECOrder.PaymentDes);
        if (oECOrder.DeliveryMode == (int)Dictionary.ECDeliveryMode.Home_Delivery)
            doc.SetParameterValue("DeliveryMode", "Home Delivery");
        else doc.SetParameterValue("DeliveryMode", "Store Delivery");
        doc.SetParameterValue("DeliveryDate", oECOrder.DesiredDeliveryDate.ToString("dd-MMM-yyyy"));
        oWarehouse = new Warehouse();
        oWarehouse.WarehouseID = oECOrder.DeliveryWHID;
        oWarehouse.Reresh();
        doc.SetParameterValue("Outlet", oWarehouse.WarehouseName);
        doc.SetParameterValue("DeliveryAddress", oECOrder.DeliveryAddress);
        doc.SetParameterValue("User", Utility.Username);
        doc.SetParameterValue("Status", Enum.GetName(typeof(Dictionary.ECOrderStatus), oECOrder.OrderStatus));
              
        Session.Remove("Doc");
        Session.Add("Doc", doc);
        Session["ReportName"] = "Ecommerce Order[ECO]";
        Response.Redirect("~/Report/frmReportViewer.aspx");
    }
}

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

public partial class frmOrderConfirmations : System.Web.UI.Page
{
    SalesOrders _oSalesOrders;
    DateTime _dFromDate;
    DateTime _dToDate;
    Utilities _oUtilitys;
    bool IsUpdate = false;
    Warehouses _oWarehouses;
    Warehouse _oWarehouse;

    int nUserID;


    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("SalesOrder");
        if (!IsPostBack)
        {
            _oUtilitys = new Utilities();
            cbSatus.Items.Clear();
            _oUtilitys.GetOrderStatus();
            cbSatus.DataSource = _oUtilitys;
            cbSatus.DataTextField = "Satus";
            cbSatus.DataBind();

            cboStDay.Text = DateTime.Today.Day.ToString();
            cboStMonth.Text = DateTime.Today.Month.ToString();
            cboStYear.Text = DateTime.Today.Year.ToString();
            cbTDay.Text = DateTime.Today.Day.ToString();
            cbTMonth.Text = DateTime.Today.Month.ToString();
            cbTYear.Text = DateTime.Today.Year.ToString();
            Session.Add("Utilitys", _oUtilitys);
            Combo();
        }
        lnkShowdata_Click(null, null);
    }
    public void Combo()
    {
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();
        _oWarehouses = new Warehouses();
        _oWarehouses.GetFromWarehouseByUser(oUser.UserId);
        DBController.Instance.CloseConnection();
        if (_oWarehouses.Count > 0)
        {
            cmbWarehouse.DataSource = _oWarehouses;
            cmbWarehouse.DataTextField = "WarehouseName";
            cmbWarehouse.DataBind();
            cmbWarehouse.SelectedIndex = 0;
            Session.Add("SalesOrders", _oWarehouse);
        }
        else
        {
            _oWarehouses = new Warehouses();
            _oWarehouse.WarehouseName = "No Permission";
            _oWarehouses.Add(_oWarehouse);

            cmbWarehouse.DataSource = _oWarehouses;
            cmbWarehouse.DataTextField = "WarehouseName";
            cmbWarehouse.DataBind();
            cmbWarehouse.SelectedIndex = 0;
            Session.Add("SalesOrders", _oWarehouse);
        }

    } 
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("OrderNo", typeof(string)));
        dt.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
        dt.Columns.Add(new DataColumn("CustomerCode", typeof(string)));
        dt.Columns.Add(new DataColumn("CustomerName", typeof(string)));
        dt.Columns.Add(new DataColumn("OrderDate", typeof(string)));
        dt.Columns.Add(new DataColumn("OrderCratedBy", typeof(string)));
        dt.Columns.Add(new DataColumn("OrderConfirmedBy", typeof(string)));
        dt.Columns.Add(new DataColumn("OrderSatus", typeof(string)));
        dt.Columns.Add(new DataColumn("OrderType", typeof(string)));

        _oSalesOrders = new SalesOrders();
        _oUtilitys = (Utilities)Session["Utilitys"];
        nUserID = int.Parse(Session["UserID"].ToString());

        DBController.Instance.OpenNewConnection();
        _oWarehouses = new Warehouses();
        _oWarehouses.GetFromWarehouseByUser(nUserID);
        if (_oWarehouses.Count > 0)
        {
            _oSalesOrders.Refresh(_dFromDate, _dToDate, txtOrderNo.Text, _oUtilitys[cbSatus.SelectedIndex].SatusId, _oWarehouses[cmbWarehouse.SelectedIndex].WarehouseID);
        }
        foreach (SalesOrder _oSalesOrder in _oSalesOrders)
        {
            _oSalesOrder.CustomerCode = txtCustomerCode.Text;
            _oSalesOrder.CustomerName = txtCustomerName.Text;
            DateTime _dDate = Convert.ToDateTime(_oSalesOrder.OrderDate);

            dr = dt.NewRow();
            dr["OrderNo"] = _oSalesOrder.OrderNo.ToString();
            dr["InvoiceNo"] = _oSalesOrder.InvoiceNo.ToString();
            dr["CustomerCode"] = _oSalesOrder.Customer.CustomerCode;
            dr["CustomerName"] = _oSalesOrder.Customer.CustomerName;
            dr["OrderDate"] = _dDate.ToString("dd-MMM-yyyy");

            if (_oSalesOrder.CreateUser.Username != null)
                dr["OrderCratedBy"] = _oSalesOrder.CreateUser.Username;
            else dr["OrderCratedBy"] = "NA";

            if (_oSalesOrder.ConfirmUser.Username != null)
                dr["OrderConfirmedBy"] = _oSalesOrder.ConfirmUser.Username;
            else dr["OrderConfirmedBy"] = "NA";

            if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
            {
                dr["OrderSatus"] = "Received";
            }
            if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Confirmed)
            {
                dr["OrderSatus"] = "Confirmed";
            }
            if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Pending)
            {
                dr["OrderSatus"] = "Pending";
            }
            if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Canceled)
            {
                dr["OrderSatus"] = "Canceled";
            }
            if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Invoiced)
            {
                dr["OrderSatus"] = "Invoiced";
            }
            if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Reject_Due_To_Less_Credit)
            {
                dr["OrderSatus"] = "Reject Due To Less Credit"; ;
            }
            if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Cancle_Due_To_Less_Stock)
            {
                dr["OrderSatus"] = "Cancle Due To Less Stock";
            }

            if (_oSalesOrder.OrderTypeID == (short)Dictionary.OrderType.CASH)
            {
                dr["OrderType"] = "Cash";
            }
            else
            {
                dr["OrderType"] = "Credit";
            }
            dt.Rows.Add(dr);

            if (dr["CustomerCode"].ToString() == "")
                dt.Rows.Remove(dr);


        }
        DBController.Instance.CloseConnection();
        //dr = dt.NewRow();
        //Store the DataTable in ViewState

        ViewState["SalesOrderTable"] = dt;
        dvwSalesOrders.DataSource = dt;
        dvwSalesOrders.DataBind();
        Session.Add("SalesOrders", _oSalesOrders);
    }

    protected void lnkShowdata_Click(object sender, EventArgs e)
    {
        try
        {
            _dFromDate = new DateTime(Convert.ToInt32(cboStYear.SelectedValue), Convert.ToInt32(cboStMonth.SelectedValue), Convert.ToInt32(cboStDay.SelectedValue));
        }
        catch
        {
            lblMessage.Text = "Input Date is not correct Formate";
            lblMessage.Visible = true;
            return;
        }
        try
        {
            _dToDate = new DateTime(Convert.ToInt32(cbTYear.SelectedValue), Convert.ToInt32(cbTMonth.SelectedValue), Convert.ToInt32(cbTDay.SelectedValue));
        }
        catch
        {
            lblMessage.Text = "Input Date is not correct Formate";
            lblMessage.Visible = true;
            return;
        }
        lblMessage.Visible = false;
        RefreshGrid();
        Table1.Rows[0].Cells[0].InnerText = "SalesOders" + "[" + dvwSalesOrders.Rows.Count + "]";
    }

    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("SalesOrder");
        _oSalesOrders = (SalesOrders)Session["SalesOrders"];

        LinkButton link = (LinkButton)sender;
        foreach (SalesOrder oSalesOrder in _oSalesOrders)
        {
            if (oSalesOrder.OrderNo.ToString() == link.Text)
            {
                if (oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
                {
                    IsUpdate = true;
                    Session.Add("Update", IsUpdate);
                    Session.Add("SalesOrder", oSalesOrder);
                    break;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error.......only Received order can be update";
                    return;
                }
               
            }
        }
        Response.Redirect("frmOrderConfirmation.aspx");        

    } 

    protected void dvwSalesOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Session.Remove("SalesOrder");
        _oSalesOrders = (SalesOrders)Session["SalesOrders"];

        GridViewRow row = (GridViewRow)dvwSalesOrders.Rows[e.RowIndex];
        LinkButton link = (LinkButton)row.FindControl("OrderNo");
        Label lable = (Label)row.FindControl("OrderSatus");

        foreach (SalesOrder oSalesOrder in _oSalesOrders)
        {
            if (oSalesOrder.OrderNo.ToString() == link.Text)
            {
                if (lable.Text == "Received")
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oSalesOrder.Delete(false);
                        DBController.Instance.CommitTransaction();
                        lnkShowdata_Click(null, null);

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        AppLogger.LogError("Web: Unuccessfull delete sales order =" + ex);
                        lblMessage.Visible = true;
                        lblMessage.Text = "Error....... ";
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Invoice have been Locked.";
                    AppLogger.LogError("Web: Unuccessfull delete sales order" + Utility.Username);
                }
            }

        }
    }
}

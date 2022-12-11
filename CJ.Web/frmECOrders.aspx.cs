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

public partial class frmECOrders : System.Web.UI.Page
{
    ECOrders oECOrders;
    Utilities _oUtilitys; 
    DateTime _dFromDate;
    DateTime _dToDate;
    int nUserID = 0;
    Warehouses _oWarehouses;
    Warehouse oWarehouse;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("ECOrder");
        if (!IsPostBack)
        {
            _oUtilitys = new Utilities();
            cbSatus.Items.Clear();
            _oUtilitys.GetECOrderStatus();
            Utility _oUtility = new Utility();
            _oUtility.SatusId = -1;
            _oUtility.Satus = "ALL";
            _oUtilitys.Add(_oUtility);
            cbSatus.DataSource = _oUtilitys;
            cbSatus.DataTextField = "Satus";
            cbSatus.DataBind();
            cbSatus.SelectedIndex = _oUtilitys.Count - 1;

            cboStDay.Text = DateTime.Today.Day.ToString();
            cboStMonth.Text = DateTime.Today.Month.ToString();
            cboStYear.Text = DateTime.Today.Year.ToString();
            cbTDay.Text = DateTime.Today.Day.ToString();
            cbTMonth.Text = DateTime.Today.Month.ToString();
            cbTYear.Text = DateTime.Today.Year.ToString();
            Session.Add("Utilitys", _oUtilitys);
            Combo();
            lnkShowdata_Click(null, null);
        }
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

            cbWarehouse.DataSource = _oWarehouses;
            cbWarehouse.DataTextField = "WarehouseName";
            cbWarehouse.DataBind();
            cbWarehouse.SelectedIndex = 0;
            Session.Add("Warehouses", oWarehouse);
        }
        else
        {
            oWarehouse = new Warehouse();
            oWarehouse.WarehouseName = "No Permission";
            _oWarehouses.Add(oWarehouse);

            cbWarehouse.DataSource = _oWarehouses;
            cbWarehouse.DataTextField = "WarehouseName";
            cbWarehouse.DataBind();
            cbWarehouse.SelectedIndex = 0;
            Session.Add("Warehouses", oWarehouse);
        }


    } 
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("OrderNo", typeof(string))); 
        dt.Columns.Add(new DataColumn("CustomerName", typeof(string)));
        dt.Columns.Add(new DataColumn("BranchName", typeof(string)));
        dt.Columns.Add(new DataColumn("OrderDate", typeof(string)));    
        dt.Columns.Add(new DataColumn("OrderSatus", typeof(string)));

        oECOrders = new ECOrders();
        _oUtilitys = (Utilities)Session["Utilitys"];
        nUserID = int.Parse(Session["UserID"].ToString());

        DBController.Instance.OpenNewConnection();
        _oWarehouses = new Warehouses();
        _oWarehouses.GetFromWarehouseByUser(nUserID);

        if (_oWarehouses.Count > 0)
        {
            oECOrders.Refresh(_dFromDate, _dToDate, txtOrderNo.Text, _oUtilitys[cbSatus.SelectedIndex].SatusId, _oWarehouses[cbWarehouse.SelectedIndex].WarehouseID);
        }

        foreach (ECOrder oECOrder in oECOrders)
        {

            DateTime _dDate = Convert.ToDateTime(oECOrder.OrderDate);

            dr = dt.NewRow();
            dr["OrderNo"] = oECOrder.OrderNo;
            dr["CustomerName"] = oECOrder.CustomerName;
            dr["BranchName"] = oECOrder.Warehouse.WarehouseName;
            dr["OrderDate"] = _dDate.ToString("dd-MMM-yyyy");

            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Submitted)
            {
                dr["OrderSatus"] = "Submitted";
            }
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
            {
                dr["OrderSatus"]="Cancel";
            }
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Confirm_Payment)
            {
                 dr["OrderSatus"]="Confirm Payment";
            }
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Stock_to_be_Available_Within_2WD)
            {
                dr["OrderSatus"] = "Stock to be Available Within 2 WD";
            }
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet)
            {
                 dr["OrderSatus"]="Confirm Stock By Outlet";
            }
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Happy_Call)
            {
                 dr["OrderSatus"]="Happy Call";
            }
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Product_Delivered)
            {
                 dr["OrderSatus"]="Product Delivered";
            }
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Stock_No_Longer_Available)
            {
                dr["OrderSatus"] = "Stock no longer Available";
            }
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.UnAvailable_Stock_Outlet)
            {
                 dr["OrderSatus"]="Un available Stock Outlet";
            }
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Stock_to_be_Available_later)
            {
                dr["OrderSatus"] = "Stock to be available later";
            }
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Order_Confirmation_from_Customer)
            {
                dr["OrderSatus"] = "Order confirmation from customer";
            }
            if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Pick_Up_DD_Extended)
            {
                dr["OrderSatus"] = "Pick-Up delivery date extended";
            }
            dt.Rows.Add(dr);        

        }
        DBController.Instance.CloseConnection();
      
        ViewState["OrderTable"] = dt;
        dvwSalesOrders.DataSource = dt;
        dvwSalesOrders.DataBind();
        Session.Add("ECOrders", oECOrders);
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
        Table1.Rows[0].Cells[0].InnerText = "Ecommerce Orders" + "[" + dvwSalesOrders.Rows.Count + "]";
    }
    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("ECOrder");
        oECOrders = (ECOrders)Session["ECOrders"];

        LinkButton link = (LinkButton)sender;
        foreach (ECOrder oECOrder in oECOrders)
        {
            if (oECOrder.OrderNo.ToString() == link.Text)
            {
                if (oECOrder.OrderStatus != (int)Dictionary.ECOrderStatus.Happy_Call && oECOrder.OrderStatus != (int)Dictionary.ECOrderStatus.Cancel && oECOrder.OrderStatus != (int)Dictionary.ECOrderStatus.Product_Delivered && oECOrder.OrderStatus != (int)Dictionary.ECOrderStatus.Stock_No_Longer_Available)
                {
                    Session.Add("ECOrder", oECOrder);
                    Response.Redirect("frmECStatusUpdate.aspx");
                }
            }
        }      

    }
}

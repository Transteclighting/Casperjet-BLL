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
using CJ.Class.DCS;

public partial class frmGiftVoucherRedeems : System.Web.UI.Page
{
    DateTime _dFromDate;
    DateTime _dToDate;
    GiftVouchers oGiftVouchers;
    //Customer oCustomer;
    //Customers _oCustomers;
    Warehouse oWarehouse;
    Warehouses oWarehouses;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cboStDay.Text = DateTime.Today.Day.ToString();
            cboStMonth.Text = DateTime.Today.Month.ToString();
            cboStYear.Text = DateTime.Today.Year.ToString();
            cbTDay.Text = DateTime.Today.Day.ToString();
            cbTMonth.Text = DateTime.Today.Month.ToString();
            cbTYear.Text = DateTime.Today.Year.ToString();
            Combo();
        }
        lnkShowdata_Click(null, null);
    }
    public void Combo()
    {

        oGiftVouchers = new GiftVouchers();
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();
        oWarehouses = new Warehouses();
        oWarehouses.GetFromWarehouseByUser(oUser.UserId);
        DBController.Instance.CloseConnection();
        if (oWarehouses.Count > 0)
        {
            cmbOutlet.DataSource = oWarehouses;
            cmbOutlet.DataTextField = "WarehouseName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("GiftVoucherRedeems", oWarehouse);
        }
        else
        {
            oWarehouse = new Warehouse();
            oWarehouse.WarehouseName = "No Permission";
            oWarehouses.Add(oWarehouse);

            cmbOutlet.DataSource = oWarehouses;
            cmbOutlet.DataTextField = "WarehouseName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("GiftVoucherRedeems", oWarehouse);

        }

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
        Table3.Rows[0].Cells[0].InnerText = "Gift Voucher Redeem List" + "[" + dvwGiftVouchers.Rows.Count + "]";
    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("SerialNo", typeof(string)));
        dt.Columns.Add(new DataColumn("RedeemDate", typeof(string)));
        dt.Columns.Add(new DataColumn("UnitPrice", typeof(string)));
        dt.Columns.Add(new DataColumn("SoldOutlet", typeof(string)));
        dt.Columns.Add(new DataColumn("SoldDate", typeof(string)));


        oGiftVouchers = new GiftVouchers();
        User oUser = (User)Session["User"];

        DBController.Instance.OpenNewConnection();

        //oCustomer = new Customer();
        //oCustomer.GetCustomerForGiftVoucher(oUser.UserId);

        oWarehouses = new Warehouses();
        oWarehouses.GetFromWarehouseByUser(oUser.UserId);

        if (oWarehouses.Count > 0)
        {
            oGiftVouchers.RefreshForRedeem(_dFromDate, _dToDate, oWarehouses[cmbOutlet.SelectedIndex].WarehouseID, txtSerialNo.Text);
        }

        foreach (GiftVoucher oGiftVoucher in oGiftVouchers)
        {
            dr = dt.NewRow();

            dr["SerialNo"] = oGiftVoucher.SerialNo;
            dr["RedeemDate"] = oGiftVoucher.RedeemDate.ToString("dd-MMM-yyyy");
            dr["UnitPrice"] = oGiftVoucher.UnitPrice;
            dr["SoldOutlet"] = oGiftVoucher.SoldOutlet;
            dr["SoldDate"] = oGiftVoucher.SaleDate.ToString("dd-MMM-yyyy");

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["GiftVoucherTable"] = dt;
        dvwGiftVouchers.DataSource = dt;
        dvwGiftVouchers.DataBind();
        Session.Add("GiftVoucherRedeems", oGiftVouchers);
    }
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        Session.Add("IsUpdate", false);
        Response.Redirect("frmGiftVoucherRedeem.aspx");
    }
  
}


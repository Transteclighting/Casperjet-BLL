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

public partial class frmGiftVoucherRedeem : System.Web.UI.Page
{

    GiftVouchers oGiftVouchers;
    Customer oCustomer;
    Customers _oCustomers;
    Warehouse oWarehouse;
    Warehouses oWarehouses;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Combo();
        }
        //lnkShowdata_Click(null, null);
    }
    private bool validateUIInput()
    {

        if (cmbOutlet.Text == "No Permission")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have no permission any outlet";
            return false;
        }
        if (txtInvoiceNo.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input a Serial No";
            return false;
        }
        if (txtInvoiceNo.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input a Invoice No";
            return false;
        }
        DBController.Instance.OpenNewConnection();
        GiftVoucher oGiftVoucher = new GiftVoucher();
        oGiftVoucher.SerialNo = Convert.ToInt32(txtSerialNo.Text.ToString());
        oGiftVoucher.ExpireDate = DateTime.Today.Date;

        if (oGiftVoucher.CheckStatus())
        {

        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "This Gift is not eligible to redeem";
            return false;
        }

        return true;
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        if (validateUIInput())
        {
            User oUser = (User)Session["User"];
            Customer oCustomer = (Customer)Session["Customer"];

            DBController.Instance.OpenNewConnection();
            oCustomer = new Customer();
            oCustomer.GetCustomerForFootFall(oUser.UserId);

            oWarehouses = new Warehouses();
            oWarehouses.GetFromWarehouseByUser(oUser.UserId);

            GiftVoucher oGiftVoucher = new GiftVoucher();

            oGiftVoucher.RefreshBySerialNo(Convert.ToInt32(txtSerialNo.Text.ToString()));

            oGiftVoucher.HFromWHID = oGiftVoucher.WarehouseID;
            oGiftVoucher.WarehouseID = oWarehouses[cmbOutlet.SelectedIndex].WarehouseID;
            oGiftVoucher.HSerialNo = oGiftVoucher.SerialNo;
            oGiftVoucher.ToWHID = oGiftVoucher.WarehouseID;
            oGiftVoucher.InvoiceNo = txtInvoiceNo.Text;

            try
            {
                DBController.Instance.BeginNewTransaction();

                oGiftVoucher.Status = (int)Dictionary.GiftVoucherStatus.Redeem;
                oGiftVoucher.HStatus = (int)Dictionary.GiftVoucherStatus.Redeem;
                oGiftVoucher.Redeem();
                oGiftVoucher.AddHistory();

                DBController.Instance.CommitTransaction();
                string[] sSuccedCode =  { " " };
                Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                UIUtility.GetConfirmationMsg("Save", "The Gift Voucher Redeem", sSuccedCode, null, "frmGiftVoucherRedeems.aspx", 0);
                Response.Redirect("frmMessage.aspx");

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                lblMessage.Visible = true;
                lblMessage.Text = "Error..." + ex;
                return;

            }
        }
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
}

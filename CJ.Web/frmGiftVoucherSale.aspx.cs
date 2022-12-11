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

using CJ.Report;
using CJ.Class;
using CJ.Class.Library;


public partial class frmGiftVoucherSale : System.Web.UI.Page
{
    GiftVouchers _oGiftVouchers;
    Customer oCustomer;
    Customers oCustomers;
    Warehouse oWarehouse;
    Warehouses oWarehouses;
    TELLib oTELLib;
    int WHID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Combo();
            RefreshSerial();
        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        Save();
    }
    public void Combo()
    {
        _oGiftVouchers = new GiftVouchers();
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
            Session.Add("GiftVouchers", oWarehouse);
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
            Session.Add("GiftVouchers", oWarehouse);
        }

    }  
    private void RefreshSerial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;


        dt.Columns.Add(new DataColumn("IsCheck", typeof(bool)));
        dt.Columns.Add(new DataColumn("SerialNo", typeof(string)));
        dt.Columns.Add(new DataColumn("UnitPrice", typeof(string)));
        dt.Columns.Add(new DataColumn("DiscountPrice", typeof(string)));


        DBController.Instance.OpenNewConnection();

        User oUser = (User)Session["User"];

        oWarehouse = new Warehouse();
        oWarehouses.GetFromWarehouseByUser(oUser.UserId);

        _oGiftVouchers = new GiftVouchers();

        if (oWarehouses.Count > 0)
        {
            _oGiftVouchers.RefreshSale(oWarehouses[cmbOutlet.SelectedIndex].WarehouseID);
        }

        foreach (GiftVoucher oGiftVoucher in _oGiftVouchers)
        {

            dr = dt.NewRow();

            dr["IsCheck"] = false;
            dr["SerialNo"] = oGiftVoucher.SerialNo;
            dr["UnitPrice"] = Convert.ToDouble(oGiftVoucher.UnitPrice.ToString());
            dr["DiscountPrice"] = Convert.ToDouble(oGiftVoucher.DiscountAmount.ToString());

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["GiftVoucherTable"] = dt;
        dvwGiftVoucherSale.DataSource = dt;
        dvwGiftVoucherSale.DataBind();
        Session.Add("GiftVouchers", _oGiftVouchers);
    }

    private bool validateUIInput()
    {

        if (cmbOutlet.Text == "No Permission")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have no permission any outlet";
            return false;
        }
        if (txtCustomerName.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Customer Name";
            return false;
        }
        if (txtContactNo.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Contact No";
            return false;
        }
        if (txtReceiveAmount.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Receive Amount";
            return false;
        }
        else
        { 
        }

        double UP = 0;
        double DT = 0;

        DataTable dt = (DataTable)ViewState["GiftVoucherTable"];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dvwGiftVoucherSale.Rows[i].Cells[0].FindControl("chkSLNo");
                if (chk.Checked)
                {
                    Label lblUnitPrice = (Label)dvwGiftVoucherSale.Rows[i].Cells[2].FindControl("txtUnitPrice");
                    Label lblDiscount = (Label)dvwGiftVoucherSale.Rows[i].Cells[3].FindControl("txtDiscountPrice");
                    UP = UP + Convert.ToDouble(lblUnitPrice.Text.ToString());
                    DT = DT + Convert.ToDouble(lblDiscount.Text.ToString());
                }
            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "There is no Gift Voucher to Sale";
            return false;
        }

        if ((UP - DT) != Convert.ToDouble(txtReceiveAmount.Text.ToString()))
        {
            lblMessage.Visible = true;
            lblMessage.Text = " Receive Amount and Checked Gift Voucher Price is not Same";
            return false;
        }

        return true;
    }

    private void Save()
    {
        lblMessage.Visible = false;
        if (validateUIInput())
        {
            int SLNo = 0;
            double TtlAmount = 0.00;
            string AllSL = "";
            double TtlUnitPrice = 0.00;
            double TtlDiscount = 0.00;

            User oUser = (User)Session["User"];
            //Customer oCustomer = (Customer)Session["Customer"];


            try
            {
                DBController.Instance.BeginNewTransaction();

                DataTable dt = (DataTable)ViewState["GiftVoucherTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CheckBox chk = (CheckBox)dvwGiftVoucherSale.Rows[i].Cells[0].FindControl("chkSLNo");
                        if (chk.Checked)
                        {
                            //oCustomer = new Customer();
                            //oCustomer.GetCustomerForGiftVoucher(oUser.UserId);
                            GiftVoucher oGiftVoucher = new GiftVoucher();

                            oGiftVoucher.CustomerName = txtCustomerName.Text;
                            oGiftVoucher.CustomerAddress = txtAddress.Text;
                            oGiftVoucher.ContactNo = txtContactNo.Text;
                            oGiftVoucher.Email = txtEmail.Text;
                            oGiftVoucher.Status = (int)Dictionary.GiftVoucherStatus.Sold;

                            Label lblSerialNo = (Label)dvwGiftVoucherSale.Rows[i].Cells[1].FindControl("txtSerialNo");
                            SLNo = Convert.ToInt32(lblSerialNo.Text.ToString());
                            oGiftVoucher.RefreshBySerialNo(SLNo);
                            oGiftVoucher.ExpireDate = DateTime.Today.Date.AddMonths(oGiftVoucher.ValidMonth);
                            oGiftVoucher.HSerialNo = SLNo;
                            oGiftVoucher.HFromWHID = oGiftVoucher.WarehouseID;
                            oGiftVoucher.WarehouseID = oGiftVoucher.WarehouseID;
                            oGiftVoucher.ToWHID = oGiftVoucher.WarehouseID;
                            WHID = oGiftVoucher.WarehouseID;
                            oGiftVoucher.Remarks = txtRemarks.Text;
                            oGiftVoucher.Status = (int)Dictionary.GiftVoucherStatus.Sold;
                            oGiftVoucher.HStatus = (int)Dictionary.GiftVoucherStatus.Sold;

                            Label lblUnitPrice = (Label)dvwGiftVoucherSale.Rows[i].Cells[2].FindControl("txtUnitPrice");
                            Label lblDiscount = (Label)dvwGiftVoucherSale.Rows[i].Cells[3].FindControl("txtDiscountPrice");
                            TtlUnitPrice = TtlUnitPrice + Convert.ToDouble(lblUnitPrice.Text.ToString());
                            TtlDiscount = TtlDiscount + Convert.ToDouble(lblDiscount.Text.ToString());


                            if (AllSL != "")
                            {
                                AllSL = AllSL + ",";
                            }
                            AllSL = AllSL + lblSerialNo.Text;
                            TtlAmount = TtlAmount + (Convert.ToDouble(lblUnitPrice.Text.ToString()) - Convert.ToDouble(lblDiscount.Text.ToString()));

                            oGiftVoucher.AddSale();
                            oGiftVoucher.AddHistory();
                        }


                    }
                }

                DBController.Instance.CommitTransaction();

                oTELLib = new TELLib();
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptGiftVoucher));
                oWarehouse = new Warehouse();
                oWarehouse.WarehouseID = WHID;
                DBController.Instance.BeginNewTransaction();
                oWarehouse.Reresh();


                doc.SetParameterValue("OutletName", oWarehouse.WarehouseName);
                doc.SetParameterValue("CustomerName", txtCustomerName.Text);
                doc.SetParameterValue("GVAmtDetail", "Tk. ( " + TtlUnitPrice + "-" + TtlDiscount + " )");
                doc.SetParameterValue("TotalAmount", TtlAmount);
                doc.SetParameterValue("Remarks", txtRemarks.Text);
                doc.SetParameterValue("SerialNo", AllSL);
                doc.SetParameterValue("User", oUser.Username);
                doc.SetParameterValue("TakaInWord", oTELLib.TakaWords(TtlAmount));

                Session.Remove("Doc");
                Session.Add("Doc", doc);
                Session["ReportName"] = "Money Receipt";
                Response.Redirect("~/Report/frmReportViewer.aspx");


                string[] sSuccedCode =  { " " };
                Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                UIUtility.GetConfirmationMsg("Save", "Gift Voucher Sale", sSuccedCode, null, "frmGiftVoucherSales.aspx", 0);
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
    public void EditItem(Object sender, EventArgs e)
    {
        //Session.Remove("ViweOutletDeposit");
        //oOutletDeposits = (OutletDeposits)Session["OutletDeposits"];

        //LinkButton link = (LinkButton)sender;
        //foreach (OutletDeposit oOutletDeposit in oOutletDeposits)
        //{
        //    if (oOutletDeposit.OutletDepositNo == link.Text)
        //    {
        //        Session.Add("IsUpdate", true);
        //        Session.Add("ViweOutletDeposit", oOutletDeposit);
        //        break;

        //    }
        //}
        //Response.Redirect("frmDCS.aspx");

    }
    protected void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataRow dr = null;


        dt.Columns.Add(new DataColumn("IsCheck", typeof(bool)));
        dt.Columns.Add(new DataColumn("SerialNo", typeof(string)));
        dt.Columns.Add(new DataColumn("UnitPrice", typeof(string)));
        dt.Columns.Add(new DataColumn("DiscountPrice", typeof(string)));


        DBController.Instance.OpenNewConnection();

        User oUser = (User)Session["User"];

        oWarehouses = new Warehouses();
        oWarehouses.GetFromWarehouseByUser(oUser.UserId);
        
        _oGiftVouchers = new GiftVouchers();
        _oGiftVouchers.RefreshSale(oWarehouses[cmbOutlet.SelectedIndex].WarehouseID);

        foreach (GiftVoucher oGiftVoucher in _oGiftVouchers)
        {

            dr = dt.NewRow();

            dr["IsCheck"] = false;
            dr["SerialNo"] = oGiftVoucher.SerialNo;
            dr["UnitPrice"] = Convert.ToDouble(oGiftVoucher.UnitPrice.ToString());
            dr["DiscountPrice"] = Convert.ToDouble(oGiftVoucher.DiscountAmount.ToString());

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["GiftVoucherTable"] = dt;
        dvwGiftVoucherSale.DataSource = dt;
        dvwGiftVoucherSale.DataBind();
        Session.Add("GiftVouchers", _oGiftVouchers);
    }

}

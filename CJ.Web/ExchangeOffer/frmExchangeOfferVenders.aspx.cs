using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CJ.Class;

public partial class ExchangeOffer_frmExchangeOfferVenders : System.Web.UI.Page
{
    bool IsUpdate = false;
    ExchangeOfferVenders _oExchangeOfferVenders;
    ExchangeOfferVender _oExchangeOfferVender;
    DateTime _dFromDate;
    DateTime _dToDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //cboStDay.Text = DateTime.Today.Day.ToString();
            //cboStMonth.Text = DateTime.Today.Month.ToString();
            //cboStYear.Text = DateTime.Today.Year.ToString();
            //cbTDay.Text = DateTime.Today.Day.ToString();
            //cbTMonth.Text = DateTime.Today.Month.ToString();
            //cbTYear.Text = DateTime.Today.Year.ToString();
            lnkShowdata_Click(null, null);
        }
    }
    protected void lnkShowdata_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        RefreshGrid();
        Table3.Rows[0].Cells[0].InnerText = "Total Vender" + "[" + dvwExchangeOfferVender.Rows.Count + "]";
    }
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        Session.Remove("ExchangeOfferVender");
        IsUpdate = false;
        Session.Add("Update", IsUpdate);
        Response.Redirect("frmExchangeOfferVender.aspx");
    }
    
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("CodeNo", typeof(string)));
        dt.Columns.Add(new DataColumn("VenderName", typeof(string)));
        dt.Columns.Add(new DataColumn("Address", typeof(string)));
        dt.Columns.Add(new DataColumn("ContactNo", typeof(string)));

        dt.Columns.Add(new DataColumn("SecurityDeposit", typeof(string)));
        dt.Columns.Add(new DataColumn("PaymentReceive", typeof(string)));
        dt.Columns.Add(new DataColumn("MRAmount", typeof(string)));
        dt.Columns.Add(new DataColumn("Balance", typeof(string)));
        dt.Columns.Add(new DataColumn("ShouldbeDeposited", typeof(string)));

        dt.Columns.Add(new DataColumn("IsActive", typeof(string)));

        _oExchangeOfferVenders = new ExchangeOfferVenders();
        User oUser = (User)Session["User"];

        DBController.Instance.OpenNewConnection();

        _oExchangeOfferVenders.Refresh(txtVenderNo.Text, txtVenderName.Text);

        foreach (ExchangeOfferVender oEOV in _oExchangeOfferVenders)
        {
            double ShouldBeDeposit = 0;

            dr = dt.NewRow();

            dr["CodeNo"] = oEOV.Code.ToString();
            dr["VenderName"] = oEOV.Name.ToString();
            dr["Address"] = oEOV.Address.ToString();
            dr["ContactNo"] = oEOV.ContactNo.ToString();

            dr["SecurityDeposit"] = oEOV.SecurityDeposit.ToString();
            dr["PaymentReceive"] = oEOV.PaymentReceive.ToString();
            dr["MRAmount"] = oEOV.MoneyReceiptAmt.ToString();
            dr["Balance"] = oEOV.Balance.ToString();
            if ((oEOV.SecurityDeposit / 2) > oEOV.Balance)
            {
                ShouldBeDeposit = (oEOV.SecurityDeposit / 2) - oEOV.Balance;
            }
            else
            {
                ShouldBeDeposit = 0;
            }
            dr["ShouldbeDeposited"] = ShouldBeDeposit.ToString();
            dr["IsActive"] = oEOV.ActiveStatus.ToString();

            

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["ExchangeOfferVenderTable"] = dt;
        dvwExchangeOfferVender.DataSource = dt;
        dvwExchangeOfferVender.DataBind();
        Session.Add("ExchangeOfferVenders", _oExchangeOfferVenders);
        setListViewRowFont();
    }
    private void setListViewRowFont()
    {
        DataTable dtCondition = (DataTable)ViewState["ExchangeOfferVenderTable"];
        if (dtCondition.Rows.Count > 0)
        {
            for (int i = 0; i < dtCondition.Rows.Count; i++)
            {
                Label lblAmt = (Label)dvwExchangeOfferVender.Rows[i].Cells[7].FindControl("ShouldbeDeposited");

                if (Convert.ToDouble(lblAmt.Text.ToString()) != 0)
                {
                    GridViewRow oRow = dvwExchangeOfferVender.Rows[i];
                    oRow.ForeColor = Color.Red;
                    oRow.Font.Bold = true;
                }
            }
        }
    }
    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("ExchangeOfferVender");
        _oExchangeOfferVenders = (ExchangeOfferVenders)Session["ExchangeOfferVenders"];

        LinkButton link = (LinkButton)sender;
        foreach (ExchangeOfferVender oExchangeOfferVender in _oExchangeOfferVenders)
        {
            if (oExchangeOfferVender.Code.ToString() == link.Text)
            {
                IsUpdate = true;
                Session.Add("Update", IsUpdate);
                Session.Add("ExchangeOfferVender", oExchangeOfferVender);
                break;
                
            }
        }
        Response.Redirect("frmExchangeOfferVender.aspx");

    }
}

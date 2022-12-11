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

public partial class ExchangeOffer_frmExchangeOfferMoneyReceipts : System.Web.UI.Page
{
    ExchangeOfferVenderMRs _oExchangeOfferVenderMRs;
    Customers _oCustomers;
    Customer _oCustomer;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Combo();
            lnkShowdata_Click(null, null);
        }

    }
    public void Combo()
    {
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();

        _oCustomers = new Customers();
        _oCustomers.GetTDOutlet();

        _oCustomer = new Customer();
        _oCustomer.CustomerName = "All";
        _oCustomers.Add(_oCustomer);

        DBController.Instance.CloseConnection();

        cmbOutlet.DataSource = _oCustomers;
        cmbOutlet.DataTextField = "CustomerName";
        cmbOutlet.DataValueField = "CustomerID";
        cmbOutlet.DataBind();
        cmbOutlet.SelectedIndex = _oCustomers.Count - 1;
        //Status

        cmbStatus.Items.Add("All");
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ExOMRStatus)))
        {
            cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ExOMRStatus), GetEnum));
        }
        cmbStatus.SelectedIndex = 0;

    }
    protected void lnkShowdata_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        RefreshGrid();
        Table3.Rows[0].Cells[0].InnerText = "Exchange Offer Money Receipt List" + "[" + dvwExchangeOfferMoneyReceipt.Rows.Count + "]";
    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("IsCheck", typeof(bool)));
        dt.Columns.Add(new DataColumn("MRNo", typeof(string)));
        dt.Columns.Add(new DataColumn("Amount", typeof(string)));
        dt.Columns.Add(new DataColumn("OutletName", typeof(string)));
        dt.Columns.Add(new DataColumn("StatusName", typeof(string)));

        DBController.Instance.OpenNewConnection();

        _oExchangeOfferVenderMRs = new ExchangeOfferVenderMRs();

        int nCustomerID = 0;
        if (cmbOutlet.Text != "0")
        {
            nCustomerID =Convert.ToInt32(cmbOutlet.Text.ToString());
        }
        else
        {
            nCustomerID = 0;
        }

        _oExchangeOfferVenderMRs.Refresh(txtMRNo.Text, nCustomerID, cmbStatus.SelectedIndex - 1);
        

        foreach (ExchangeOfferVenderMR oExchangeOfferVenderMR in _oExchangeOfferVenderMRs)
        {

            dr = dt.NewRow();

            dr["IsCheck"] = false;
            dr["MRNo"] = oExchangeOfferVenderMR.MoneyReceiptNo.ToString();
            dr["Amount"] = oExchangeOfferVenderMR.Amt.ToString();
            dr["OutletName"] = oExchangeOfferVenderMR.CustomerName.ToString();
            dr["StatusName"] = oExchangeOfferVenderMR.MRStatus.ToString();

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["ExchangeOfferMoneyReceiptTable"] = dt;
        dvwExchangeOfferMoneyReceipt.DataSource = dt;
        dvwExchangeOfferMoneyReceipt.DataBind();
        Session.Add("ExchangeOfferMoneyReceipts", _oExchangeOfferVenderMRs);
    }
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        Session.Remove("ExchangeOfferMoneyReceipt");
        //IsUpdate = false;
        //Session.Add("Update", IsUpdate);
        Response.Redirect("frmExchangeOfferMoneyReceipt.aspx");
    }
    protected void lbCancel_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            lblMessage.Visible = false;
            Session.Remove("ExchangeOfferMoneyReceipt");
            DataTable dt = (DataTable)ViewState["ExchangeOfferMoneyReceiptTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)dvwExchangeOfferMoneyReceipt.Rows[i].Cells[0].FindControl("chkBox");
                    if (chk.Checked)
                    {
                        ExchangeOfferVenderMR oExchangeOfferVenderMR = new ExchangeOfferVenderMR();

                        Label lblCodeNo = (Label)dvwExchangeOfferMoneyReceipt.Rows[i].Cells[1].FindControl("MRNo");
                        Label lblOutlet = (Label)dvwExchangeOfferMoneyReceipt.Rows[i].Cells[3].FindControl("OutletName");

                        oExchangeOfferVenderMR.MoneyReceiptNo = int.Parse(lblCodeNo.Text.ToString());
                        oExchangeOfferVenderMR.CustomerName = lblOutlet.Text;

                        Session.Add("ExchangeOfferMoneyReceipt", oExchangeOfferVenderMR);
                        break;
                    }
                }
            }
            Response.Redirect("frmExchangeOfferMRCancel.aspx");
        }
    }
    private bool validateUIInput()
    {
        int ChkCount = 0;

        DataTable dt = (DataTable)ViewState["ExchangeOfferMoneyReceiptTable"];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dvwExchangeOfferMoneyReceipt.Rows[i].Cells[0].FindControl("chkBox");
                if (chk.Checked)
                {
                    ChkCount = ChkCount + 1;
                }
            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "There is no Data";
            return false;
        }
 
        if (ChkCount == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have to checked a row";
            return false;
        }
        else if (ChkCount > 1)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have to checked Only One row";
            return false;
        }

        return true;
    }
}

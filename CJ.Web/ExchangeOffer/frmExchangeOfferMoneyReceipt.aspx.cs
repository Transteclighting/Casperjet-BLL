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
using System.Text.RegularExpressions;

using CJ.Class;

public partial class ExchangeOffer_frmExchangeOfferMoneyReceipt : System.Web.UI.Page
{
    Customers _oCustomers;
    Customer _oCustomer;
    ExchangeOfferVenderMR _oExchangeOfferVenderMR;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbHeaderText.Text = "Add Exchange Offer Money Receipt";
            Combo();

        }

    }
    public void Combo()
    {
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();

        _oCustomers = new Customers();
        _oCustomers.GetTDOutlet();

        _oCustomer = new Customer();
        _oCustomer.CustomerName = "Select Outlet...";
        _oCustomers.Add(_oCustomer);

        DBController.Instance.CloseConnection();

        cmbOutlet.DataSource = _oCustomers;
        cmbOutlet.DataTextField = "CustomerName";
        cmbOutlet.DataValueField = "CustomerID";
        cmbOutlet.DataBind();
        cmbOutlet.SelectedIndex = _oCustomers.Count - 1;

    }
    private bool validateUIInput()
    {

        #region Input Information Validation

        if (cmbOutlet.Text == "0")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Select a outlet";
            return false;
        }
        if (txtToMRNo.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Enter End Money Receipt Number";
            return false;
        }
        else
        {
            Regex rgCell = new Regex("[0-9]");
            if (rgCell.IsMatch(txtToMRNo.Text))
            {

            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Enter valid End Money Receipt Number";
                return false;
            }

        }
        if (txtFromMRNo.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Enter Start Money Receipt Number";
            return false;
        }
        else
        {
            Regex rgCell = new Regex("[0-9]");
            if (rgCell.IsMatch(txtFromMRNo.Text))
            {

            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Enter valid Start Money Receipt Number";
                return false;
            }
            if (Convert.ToInt32(txtFromMRNo.Text.ToString()) > Convert.ToInt32(txtToMRNo.Text.ToString()))
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Start Money receipt No Munst be Less or Equal the End money receipt No";
                return false;
            }
        }
       

        #endregion

        return true;
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        Save();
    }
    private void Save()
    {
        lblMessage.Visible = false;


        if (validateUIInput())
        {
            int CountMR = 0;
            int StartMR = 0;
            DBController.Instance.OpenNewConnection();

            _oExchangeOfferVenderMR = new ExchangeOfferVenderMR();
            _oCustomers = new Customers();
            _oCustomers.GetTDOutlet();

            _oExchangeOfferVenderMR.CustomerID = _oCustomers[cmbOutlet.SelectedIndex].CustomerID;
            _oExchangeOfferVenderMR.Status = (int)Dictionary.ExOMRStatus.Create;

            CountMR = (Convert.ToInt32(txtToMRNo.Text.ToString()) - Convert.ToInt32(txtFromMRNo.Text.ToString())) + 1;
            StartMR = Convert.ToInt32(txtFromMRNo.Text.ToString());
            try
            {
                DBController.Instance.BeginNewTransaction();

                for (int i = 0; i < CountMR; i++)
                {
                    _oExchangeOfferVenderMR.MoneyReceiptNo = StartMR + i;
                    _oExchangeOfferVenderMR.Add();
                }

                DBController.Instance.CommitTransaction();
                string[] sSuccedCode =  { " " };
                Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                UIUtility.GetConfirmationMsg("Save", "The Exchange Offer Money Receipt", sSuccedCode, null, "ExchangeOffer/frmExchangeOfferMoneyReceipts.aspx", 0);
                Response.Redirect("../frmMessage.aspx");

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
}

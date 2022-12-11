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

public partial class ExchangeOffer_frmExchangeOfferMRCancel : System.Web.UI.Page
{
    ExchangeOfferVenderMR oExchangeOfferVenderMR;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            oExchangeOfferVenderMR = (ExchangeOfferVenderMR)Session["ExchangeOfferMoneyReceipt"];

            lbHeaderText.Text = "Exchange Offer Money Receipt Cancel";
            lblMoneyReceiptNo.Text = oExchangeOfferVenderMR.MoneyReceiptNo.ToString();
            lblOutletName.Text = oExchangeOfferVenderMR.CustomerName;
        }

    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        Save();
    }
    private bool validateUIInput()
    {
        oExchangeOfferVenderMR = (ExchangeOfferVenderMR)Session["ExchangeOfferMoneyReceipt"];

        if (txtCancelReason.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input cancel reason";
            return false;
        }

        oExchangeOfferVenderMR.MoneyReceiptNo = oExchangeOfferVenderMR.MoneyReceiptNo;
        DBController.Instance.OpenNewConnection();

        if (oExchangeOfferVenderMR.CheckMR())
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Only create status can be cancelled";
            return false;
        }

        return true;
    }
    private void Save()
    {
        lblMessage.Visible = false;

        User oUser = (User)Session["User"];

        if (validateUIInput())
        {
            DBController.Instance.OpenNewConnection();


            //oExchangeOfferVenderMR = new ExchangeOfferVenderMR();
            oExchangeOfferVenderMR = (ExchangeOfferVenderMR)Session["ExchangeOfferMoneyReceipt"];
            oExchangeOfferVenderMR.MoneyReceiptNo = oExchangeOfferVenderMR.MoneyReceiptNo;
            oExchangeOfferVenderMR.CancelReason = txtCancelReason.Text;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oExchangeOfferVenderMR.Cancel();

                DBController.Instance.CommitTransaction();
                string[] sSuccedCode =  { " " };
                Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                UIUtility.GetConfirmationMsg("Save", "The Exchange Offer Money Receipt Cancel", sSuccedCode, null, "ExchangeOffer/frmExchangeOfferMoneyReceipts.aspx", 0);
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

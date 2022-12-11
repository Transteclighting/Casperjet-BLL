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

public partial class ExchangeOffer_frmExchangeOfferVender : System.Web.UI.Page
{
    bool IsUpdate = false;
    ExchangeOfferVender oExchangeOfferVender;
    ExchangeOfferVenderAccount oExchangeOfferVenderAccount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbHeaderText.Text = "Add Exchange Offer Vender";
            IsUpdate = (bool)Session["Update"];
            txtCodeNo.Enabled = true;
            
            Table5.Rows[5].Visible = false;
            if (IsUpdate == true)
            {
                lbHeaderText.Text = "Edit Exchange Offer Vender";
                oExchangeOfferVender = (ExchangeOfferVender)Session["ExchangeOfferVender"];
                Session.Add("ExchangeOfferVender", oExchangeOfferVender);
                txtCodeNo.Enabled = false;

                SetUI();
            }
        }

    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        Save();
    }
    private bool validateUIInput()
    {
        if (IsUpdate == false)
        {
            oExchangeOfferVender = new ExchangeOfferVender();
            oExchangeOfferVender.Code = txtCodeNo.Text;
            DBController.Instance.OpenNewConnection();
            if (oExchangeOfferVender.CheckVenderCode())
            {

            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input this Vender Code already exist";
                return false;
            }

        }
        if (txtCodeNo.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Vender Code";
            return false;
        }
        if (txtVenderName.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Vender Name";
            return false;
        }
        if (txtAddress.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Address";
            return false;
        }
        if (txtContactPerson.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Contact Person";
            return false;
        }
        if (txtContactNo.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Contact No";
            return false;
        }
        return true;
    }
    public void SetUI()
    {
        oExchangeOfferVender = (ExchangeOfferVender)Session["ExchangeOfferVender"];

        txtCodeNo.Text = oExchangeOfferVender.Code;
        txtVenderName.Text = oExchangeOfferVender.Name;
        txtAddress.Text = oExchangeOfferVender.Address;
        txtContactNo.Text = oExchangeOfferVender.ContactNo;
        txtContactPerson.Text = oExchangeOfferVender.ContactPerson;
        Table5.Rows[5].Visible = true;
        if (oExchangeOfferVender.IsActive == (int)Dictionary.ExOVenderIsActive.True)
        {
            rdoTrue.Checked = true;
            rdoFalse.Checked = false;
        }
        else
        {
            rdoTrue.Checked = false;
            rdoFalse.Checked = true;
        }

        txtRemarks.Text = oExchangeOfferVender.Remarks;

    }
    private void Save()
    {
        lblMessage.Visible = false;

        User oUser = (User)Session["User"];
        IsUpdate = (bool)Session["Update"];
        if (IsUpdate == false)
        {
            if (validateUIInput())
            {
                DBController.Instance.OpenNewConnection();

                oExchangeOfferVender = new ExchangeOfferVender();


                oExchangeOfferVender.Code = txtCodeNo.Text;
                oExchangeOfferVender.Name = txtVenderName.Text;
                oExchangeOfferVender.Address = txtAddress.Text;
                oExchangeOfferVender.ContactNo = txtContactNo.Text;
                oExchangeOfferVender.ContactPerson = txtContactPerson.Text;
                oExchangeOfferVender.Remarks = txtRemarks.Text;
                oExchangeOfferVender.IsActive = (int)Dictionary.ExOVenderIsActive.True;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oExchangeOfferVender.Add();

                    oExchangeOfferVenderAccount = new ExchangeOfferVenderAccount();
                    oExchangeOfferVenderAccount.VenderID = oExchangeOfferVender.VenderID;
                    oExchangeOfferVenderAccount.SecurityDeposit = 0;
                    oExchangeOfferVenderAccount.PaymentReceive = 0;
                    oExchangeOfferVenderAccount.MoneyReceiptAmt = 0;
                    oExchangeOfferVenderAccount.Balance = 0;

                    oExchangeOfferVenderAccount.Add();


                    DBController.Instance.CommitTransaction();
                    string[] sSuccedCode =  { " " };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Save", "The Exchange Offer Vender", sSuccedCode, null, "ExchangeOffer/frmExchangeOfferVenders.aspx", 0);
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
        else
        {
            if (validateUIInput())
            {
                DBController.Instance.OpenNewConnection();

                oExchangeOfferVender = (ExchangeOfferVender)Session["ExchangeOfferVender"];


                oExchangeOfferVender.Code = txtCodeNo.Text;
                oExchangeOfferVender.Name = txtVenderName.Text;
                oExchangeOfferVender.Address = txtAddress.Text;
                oExchangeOfferVender.ContactNo = txtContactNo.Text;
                oExchangeOfferVender.ContactPerson = txtContactPerson.Text;
                oExchangeOfferVender.Remarks = txtRemarks.Text;
                if (rdoTrue.Checked == true)
                {
                    oExchangeOfferVender.IsActive = (int)Dictionary.ExOVenderIsActive.True;
                }
                else
                {
                    oExchangeOfferVender.IsActive = (int)Dictionary.ExOVenderIsActive.False;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oExchangeOfferVender.Edit();

                    DBController.Instance.CommitTransaction();
                    string[] sSuccedCode =  { " " };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Save", "The Exchange Offer Vender", sSuccedCode, null, "ExchangeOffer/frmExchangeOfferVenders.aspx", 0);
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
    protected void rdoTrue_CheckedChanged(object sender, EventArgs e)
    {
        rdoTrue.Checked = true;
        rdoFalse.Checked = false;
    }
    protected void rdoFalse_CheckedChanged(object sender, EventArgs e)
    {
        rdoTrue.Checked = false;
        rdoFalse.Checked = true;
    }
}

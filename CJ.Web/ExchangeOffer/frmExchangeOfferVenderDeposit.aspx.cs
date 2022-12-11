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
using CJ.Class.Library;
using CJ.Report;

public partial class ExchangeOffer_frmExchangeOfferVenderDeposit : System.Web.UI.Page
{
    ExchangeOfferVenders _oExchangeOfferVenders;
    ExchangeOfferVender oExchangeOfferVender;
    ExchangeOfferVenderDeposit _oExchangeOfferVenderDeposit;
    Banks _oBanks;
    TELLib oTELLib;
    ExchangeOfferVenderAccount _oExchangeOfferVenderAccount;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbHeaderText.Text = "Add Vender Deposit";
            Combo();
            Table5.Rows[4].Visible = false;
            Table5.Rows[5].Visible = false;
            Table5.Rows[6].Visible = false;
        }

    }
    public void Combo()
    {

        DBController.Instance.OpenNewConnection();

        _oExchangeOfferVenders = new ExchangeOfferVenders();
        _oExchangeOfferVenders.RefreshforCombo();

        oExchangeOfferVender = new ExchangeOfferVender();
        oExchangeOfferVender.Name = "Select vender...";
        _oExchangeOfferVenders.Add(oExchangeOfferVender);


        _oBanks = new Banks();
        _oBanks.Refresh();
        DBController.Instance.CloseConnection();

        cmbVender.DataSource = _oExchangeOfferVenders;
        cmbVender.DataTextField = "Name";
        cmbVender.DataBind();
        cmbVender.SelectedIndex = _oExchangeOfferVenders.Count -1;


        cmbBank.DataSource = _oBanks;
        cmbBank.DataTextField = "Name";
        cmbBank.DataBind();
        cmbBank.SelectedIndex = 0;
        //Session.Add("ExchangeOfferVenderDeposit", oExchangeOfferVender);

        cmbInstrumentType.Items.Add("Select Instrument Type");
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InstrumentType)))
        {
            cmbInstrumentType.Items.Add(Enum.GetName(typeof(Dictionary.InstrumentType), GetEnum));
        }
        cmbInstrumentType.SelectedIndex = 0;
    }
    protected void rdoSD_CheckedChanged(object sender, EventArgs e)
    {
        rdoSD.Checked = true;
        rdoPR.Checked = false;
    }
    protected void rdoPR_CheckedChanged(object sender, EventArgs e)
    {
        rdoSD.Checked = false;
        rdoPR.Checked = true;
    }
    private bool validateUIInput()
    {
        if (cmbVender.Text == "Select vender...")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select Vender";
            return false;
        }
        if (cmbInstrumentType.Text == "Select Instrument Type")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select Instrument Type";
            return false;
        }
        if (txtAmount.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Amount";
            return false;
        }
        if (cmbInstrumentType.SelectedIndex - 1 != (int)Dictionary.InstrumentType.CASH)
        {
            if (txtInstrumentNo.Text.Trim() == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Type Instrument Number";
                return false;
            }
            if (txtBranchName.Text.Trim() == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Type Branch Name";
                return false;
            }

        }

        return true;
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;

            if (validateUIInput())
            {
                DBController.Instance.OpenNewConnection();
                User oUser = (User)Session["User"];
                
                _oExchangeOfferVenderDeposit = new ExchangeOfferVenderDeposit();
                

                _oExchangeOfferVenders = new ExchangeOfferVenders();
                _oExchangeOfferVenders.RefreshforCombo();
                _oExchangeOfferVenderDeposit.VenderID = _oExchangeOfferVenders[cmbVender.SelectedIndex].VenderID;
                _oExchangeOfferVenderDeposit.Amount = Convert.ToDouble(txtAmount.Text.ToString());
                _oExchangeOfferVenderDeposit.InstrumentType = cmbInstrumentType.SelectedIndex - 1;
                _oExchangeOfferVenderDeposit.InstrumentNo = txtInstrumentNo.Text;

                _oBanks = new Banks();
                _oBanks.Refresh();
                _oExchangeOfferVenderDeposit.BankID = _oBanks[cmbBank.SelectedIndex].BankID;
                _oExchangeOfferVenderDeposit.BranchName = txtBranchName.Text;
                _oExchangeOfferVenderDeposit.Remarks = txtRemarks.Text;

                _oExchangeOfferVenderAccount = new ExchangeOfferVenderAccount();

                _oExchangeOfferVenderAccount.VenderID = _oExchangeOfferVenders[cmbVender.SelectedIndex].VenderID;

                if (rdoSD.Checked == true)
                {
                    _oExchangeOfferVenderDeposit.DepositType = (int)Dictionary.ExOVenderDepositType.SecurityDeposit;
                    _oExchangeOfferVenderAccount.SecurityDeposit = Convert.ToDouble(txtAmount.Text.ToString());
                    _oExchangeOfferVenderAccount.PaymentReceive = 0;                   
                }
                else
                {
                    _oExchangeOfferVenderDeposit.DepositType = (int)Dictionary.ExOVenderDepositType.PaymentReceive;
                    _oExchangeOfferVenderAccount.SecurityDeposit = 0;
                    _oExchangeOfferVenderAccount.PaymentReceive = Convert.ToDouble(txtAmount.Text.ToString());
                }
                _oExchangeOfferVenderAccount.MoneyReceiptAmt = 0;
                _oExchangeOfferVenderAccount.Balance = Convert.ToDouble(txtAmount.Text.ToString());


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oExchangeOfferVenderDeposit.Add();

                    if (_oExchangeOfferVenderAccount.CheckVenderAccount())
                    {
                        _oExchangeOfferVenderAccount.Add();
                    }
                    else
                    {
                        _oExchangeOfferVenderAccount.Update(true);
                    }
                    
                    DBController.Instance.CommitTransaction();


                    oTELLib = new TELLib();
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptExchangeOfferMoneyReceipt));

                    oExchangeOfferVender = new ExchangeOfferVender();

                    doc.SetParameterValue("VenderName", cmbVender.Text);
                    doc.SetParameterValue("TotalAmount", Convert.ToDouble(txtAmount.Text.ToString()));
                    doc.SetParameterValue("Remarks", txtRemarks.Text);
                    doc.SetParameterValue("User", oUser.Username);
                    doc.SetParameterValue("TakaInWord", oTELLib.TakaWords(Convert.ToDouble(txtAmount.Text.ToString())));

                    Session.Remove("Doc");
                    Session.Add("Doc", doc);
                    Session["ReportName"] = "Money Receipt";
                    Response.Redirect("~/Report/frmReportViewer.aspx");




                    string[] sSuccedCode =  { " " };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Save", "The Vender Deposit", sSuccedCode, null, "frmExchangeOfferVenderDeposit.aspx", 0);
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
    protected void cmbInstrumentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbInstrumentType.SelectedIndex - 1 == (int)Dictionary.InstrumentType.CASH)
        {
            Table5.Rows[4].Visible = false;
            Table5.Rows[5].Visible = false;
            Table5.Rows[6].Visible = false;
        }
        else
        {
            Table5.Rows[4].Visible = true;
            Table5.Rows[5].Visible = true;
            Table5.Rows[6].Visible = true;
        }
    }
}

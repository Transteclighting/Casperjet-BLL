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

public partial class ExchangeOffer_frmExchangeOfferStatus : System.Web.UI.Page
{
    ExchangeOffer oExchangeOffer;
    ExchangeOfferDetail oExchangeOfferDetail;
    ExchangeOfferHist oExchangeOfferHist;
    ExchangeOfferVenderMRs _oExchangeOfferVenderMRs;
    ExchangeOfferVenderMR _oExchangeOfferVenderMR;
    ExchangeOfferVenders _oExchangeOfferVenders;
    ExchangeOfferVender _oExchangeOfferVender;
    int VendID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            //Combo();
            oExchangeOffer = (ExchangeOffer)Session["ExchangeOfferStatus"];
            cmbDate.Text = DateTime.Today.Day.ToString();
            cmbMonth.Text = DateTime.Today.Month.ToString();
            cmbYear.Text = DateTime.Today.Year.ToString();

            cmbDate1.Text = DateTime.Today.Day.ToString();
            cmbMonth1.Text = DateTime.Today.Month.ToString();
            cmbYear1.Text = DateTime.Today.Year.ToString();

            oExchangeOffer.CodeNo = oExchangeOffer.CodeNo;
            DBController.Instance.OpenNewConnection();
            oExchangeOffer.RefreshByCode();
            DBController.Instance.CloseConnection();

            lblCodeNo.Text = oExchangeOffer.CodeNo;
            lblCustomerName.Text = oExchangeOffer.CustomerName;
            lblAddress.Text = oExchangeOffer.Address;
            lblContactNo.Text = oExchangeOffer.ContactNo;
            lblStatus.Text = oExchangeOffer.StatusName;
            LoadCombo();

            Table2.Rows[0].Visible = false;
            Table2.Rows[1].Visible = false;
            Table2.Rows[2].Visible = false;
            Table2.Rows[3].Visible = false;
            Table2.Rows[4].Visible = false;
            Table2.Rows[5].Visible = false;
            Table2.Rows[6].Visible = false;
            Table2.Rows[7].Visible = false;
            Table2.Rows[8].Visible = false;
        }

    }
    private void LoadCombo()
    {
        cmbStatus.Items.Add("Select Status...");
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ExchangeOfferStatusForCombo)))
        {
            cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ExchangeOfferStatusForCombo), GetEnum));
        }
        cmbStatus.SelectedIndex = 0;

        DBController.Instance.OpenNewConnection();
        _oExchangeOfferVenderMRs = new ExchangeOfferVenderMRs();
        _oExchangeOfferVenderMRs.GetMoneyReceiptNo();

        _oExchangeOfferVenderMR = new ExchangeOfferVenderMR();
        _oExchangeOfferVenderMR.MoneyReceiptNo = 0;
        _oExchangeOfferVenderMRs.Add(_oExchangeOfferVenderMR);

        _oExchangeOfferVenders = new ExchangeOfferVenders();
        _oExchangeOfferVenders.RefreshforCombo();


        _oExchangeOfferVender = new ExchangeOfferVender();
        _oExchangeOfferVender.Name = "Select vender...";
        _oExchangeOfferVenders.Add(_oExchangeOfferVender);

        DBController.Instance.CloseConnection();

        cmbMoneyReceipt.DataSource = _oExchangeOfferVenderMRs;
        cmbMoneyReceipt.DataTextField = "MoneyReceiptNo";
        cmbMoneyReceipt.DataBind();
        cmbMoneyReceipt.SelectedIndex = _oExchangeOfferVenderMRs.Count -1;


        //Vender
        cmbVender.DataSource = _oExchangeOfferVenders;
        cmbVender.DataTextField = "Name";
        cmbVender.DataBind();
        cmbVender.SelectedIndex = _oExchangeOfferVenders.Count - 1;

    }
    private bool validateUIInput()
    {

        //oExchangeOffer = (ExchangeOffer)Session["ExchangeOfferStatus"];
        //oExchangeOffer.CodeNo = oExchangeOffer.CodeNo;
        //DBController.Instance.OpenNewConnection();
        //oExchangeOffer.RefreshByCode();
        //DBController.Instance.CloseConnection();

        //if (cmbStatus.Text == "Select Status...")
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "Please select a status";
        //    return false;
        //}
        //if (cmbStatus.SelectedIndex == oExchangeOffer.Status)
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "Existing & Current status is same; please select another status";
        //    return false;
        //}
        //if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatus.Assign)
        //{
        //    if (oExchangeOffer.Status != (int)Dictionary.ExchangeOfferStatus.Create)
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "Only 'create' status can be 'assign'";
        //        return false;
        //    }
        //    if (cmbVender.Text == "0")
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "Please Select a vender";
        //        return false;
        //    }
        //}
        //if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatus.Suspend)
        //{
        //    if (oExchangeOffer.Status != (int)Dictionary.ExchangeOfferStatus.Assign)
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "Only 'Assign' status can be 'Suspended'";
        //        return false;
        //    }
        //    if (txtRemarks.Text == "")
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "Please enter suspend reason";
        //        return false;
        //    }
        //}
        //if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatus.Exchanged)
        //{
        //    if (oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.Create ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.Cancel ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.Exchanged ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.HappyCall ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.SalesExecuted)
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "Only 'Assign','Suspend' & 'Not Exchange' status can be 'Exchanged'";
        //        return false;
        //    }
        //    if (cmbMoneyReceipt.Text == "0")
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "Please select a money receipt number";
        //        return false;
        //    }
        //    if (txtMoneyReceiptAmount.Text.Trim() == "")
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "Please inpute money receipt amount";
        //        return false;
        //    }
        //    else
        //    {
        //        Regex rgCell = new Regex("[0-9]");
        //        if (rgCell.IsMatch(txtMoneyReceiptAmount.Text))
        //        {

        //        }
        //        else
        //        {
        //            lblMessage.Visible = true;
        //            lblMessage.Text = "Please Enter only numerical value";
        //            return false;
        //        }
        //    }

        //}
        //if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatus.NotExchange)
        //{
        //    if (oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.Create ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.Cancel ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.Exchanged ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.HappyCall ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.SalesExecuted ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.NotExchange)
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "Only 'Assign' & 'Suspend' status can be 'Not Exchange'";
        //        return false;
        //    }

        //}
        //if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatus.SalesExecuted)
        //{
        //    if (oExchangeOffer.Status != (int)Dictionary.ExchangeOfferStatus.Exchanged)
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "Only 'Exchanged' status can be 'Sales Executed'";
        //        return false;
        //    }
        //    if (txtInvoiceNo.Text == "")
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "Please enter Invoice Number";
        //        return false;
        //    }
        //}
        //if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatus.Cancel)
        //{
        //    if (oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.Exchanged ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.SalesExecuted ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.HappyCall)
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "'Exchanged','Sales Executed' & 'HappyCall' status can't be 'Cancel'";
        //        return false;
        //    }
        //    if (txtRemarks.Text == "")
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "Please enter cancel reason";
        //        return false;
        //    }
        //}
        //if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatus.HappyCall)
        //{
        //    if (oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.Suspend ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.Cancel ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.Exchanged ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.HappyCall ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.SalesExecuted ||
        //        oExchangeOffer.Status == (int)Dictionary.ExchangeOfferStatus.NotExchange)
        //    {
        //        if (rdoNotHappy.Checked == true)
        //        {
        //            if (chkComit.Checked == false && chkCommu.Checked == false && chkDelay.Checked == false && chkPrice.Checked == false)
        //            {
        //                lblMessage.Visible = true;
        //                lblMessage.Text = "Please select at least a reason";
        //                return false;

        //            }

        //        }
        //    }
        //    else
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "'Create' & 'Assign' status can't be 'Happy Call'";
        //        return false;
        //    }


        //}

        return true;
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            lblMessage.Visible = false;
            User oUser = (User)Session["User"];
            Customer oCustomer = (Customer)Session["Customer"];
            oExchangeOffer = (ExchangeOffer)Session["ExchangeOfferStatus"];

            oExchangeOfferHist = new ExchangeOfferHist();
            oExchangeOfferHist.ExchangeOfferID = oExchangeOffer.ExchangeOfferID;
            oExchangeOfferHist.Remarks = txtRemarks.Text;

            oExchangeOffer.ExchangeOfferID = oExchangeOffer.ExchangeOfferID;
            if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.Assign)
            {
                ExchangeOfferVenders _oExchangeOfferVenders = new ExchangeOfferVenders();
                DBController.Instance.OpenNewConnection();
                _oExchangeOfferVenders.RefreshforCombo();
                DBController.Instance.CloseConnection();
                oExchangeOffer.AssignedVenderID = _oExchangeOfferVenders[cmbVender.SelectedIndex].VenderID;
                oExchangeOffer.AssignDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmbDate.SelectedValue));
                oExchangeOffer.ExpectedVisitDate = new DateTime(Convert.ToInt32(cmbYear1.SelectedValue), Convert.ToInt32(cmbMonth1.SelectedValue), Convert.ToInt32(cmbDate1.SelectedValue));
                oExchangeOfferHist.Status = (int)Dictionary.ExchangeOfferStatus.Assign;
            }
            if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.Exchanged)
            {
                ExchangeOfferVenderMRs _oExchangeOfferVenderMRs = new ExchangeOfferVenderMRs();
                DBController.Instance.OpenNewConnection();
                _oExchangeOfferVenderMRs.GetMoneyReceiptNo();


                oExchangeOffer.GetAssignVenderByEXOID(oExchangeOffer.ExchangeOfferID);
                
                VendID = oExchangeOffer.AssignedVenderID;


                DBController.Instance.CloseConnection();
                oExchangeOffer.MoneyReceiptID = _oExchangeOfferVenderMRs[cmbMoneyReceipt.SelectedIndex].MoneyReceiptID;
                oExchangeOffer.IsExchange = (int)Dictionary.ExOIsExchange.Yes;
                //oExchangeOfferHist.Status = (int)Dictionary.ExchangeOfferStatus.Exchanged;
            }
            if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.SalesExecuted)
            {
                oExchangeOffer.InvoiceNo = txtInvoiceNo.Text;
                oExchangeOfferHist.Status = (int)Dictionary.ExchangeOfferStatus.SalesExecuted;
            }
            if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.Suspend)
            {
                //oExchangeOffer.Status = (int)Dictionary.ExchangeOfferStatus.Suspend;
                //oExchangeOfferHist.Status = (int)Dictionary.ExchangeOfferStatus.Suspend;
            }
            if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.Cancel)
            {
                oExchangeOffer.Status = (int)Dictionary.ExchangeOfferStatus.Cancel;
                oExchangeOfferHist.Status = (int)Dictionary.ExchangeOfferStatus.Cancel;
            }
            if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.NotExchange)
            {
                oExchangeOffer.IsExchange = (int)Dictionary.ExOIsExchange.No;
                if (rdoPrice.Checked == true)
                {
                    oExchangeOffer.NotExchangeReason = (int)Dictionary.ExONotExchangeReason.Price;
                }
                else
                {
                    oExchangeOffer.NotExchangeReason = (int)Dictionary.ExONotExchangeReason.NotAgreed;
                }
                //oExchangeOfferHist.Status = (int)Dictionary.ExchangeOfferStatus.NotExchange;
            }
            if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.HappyCall)
            {
                oExchangeOfferDetail = new ExchangeOfferDetail();
                oExchangeOfferDetail.ExchangeOfferID = oExchangeOffer.ExchangeOfferID;
                oExchangeOfferDetail.Type = (int)Dictionary.ExOType.NotHappyReason;

                if (rdoHappy.Checked == true)
                {
                    oExchangeOffer.HappyStatus = (int)Dictionary.ExOHappyStatus.Happy;
                }
                else if (rdoSatisfy.Checked == true)
                {
                    oExchangeOffer.HappyStatus = (int)Dictionary.ExOHappyStatus.Satisfy;
                }
                else
                {
                    oExchangeOffer.HappyStatus = (int)Dictionary.ExOHappyStatus.NotHappy;

                }
                //oExchangeOfferHist.Status = (int)Dictionary.ExchangeOfferStatus.HappyCall;
            }
            try
            {
                DBController.Instance.BeginNewTransaction();
                if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.Assign)
                {
                    oExchangeOffer.Assign();
                }
                if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.Exchanged)
                {
                    oExchangeOffer.Exchange();
                    ExchangeOfferVenderAccount oEOVA = new ExchangeOfferVenderAccount();
                    oEOVA.VenderID = VendID;
                    oEOVA.SecurityDeposit = 0;
                    oEOVA.PaymentReceive = 0;
                    oEOVA.MoneyReceiptAmt = Convert.ToDouble(txtMoneyReceiptAmount.Text.ToString());
                    oEOVA.Balance = oEOVA.MoneyReceiptAmt;
                    oEOVA.Update(false);

                    ExchangeOfferVenderMR oEXOMR = new ExchangeOfferVenderMR();
                    oEXOMR.MoneyReceiptID = oExchangeOffer.MoneyReceiptID;
                    oEXOMR.Amount = oEOVA.MoneyReceiptAmt;
                    oEXOMR.Status = (int)Dictionary.ExOMRStatus.Exchange;
                    oEXOMR.MRStatusUpdate();
                    oEXOMR.MRAmountUpdate();

                }
                if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.SalesExecuted)
                {
                    oExchangeOffer.SaleExecuted();
                    ExchangeOfferVenderMR oEXOMR = new ExchangeOfferVenderMR();
                    oEXOMR.MoneyReceiptID = oExchangeOffer.MoneyReceiptID;
                    oEXOMR.Status = (int)Dictionary.ExOMRStatus.Redeem;
                    oEXOMR.MRStatusUpdate();

                }
                if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.Suspend ||
                    cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.Cancel)
                {
                    oExchangeOffer.StatusChange();
                }
                if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.NotExchange)
                {
                    oExchangeOffer.NotExchange();
                }
                if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.HappyCall)
                {
                    oExchangeOffer.HappyCall();

                    if (chkComit.Checked == true)
                    {
                        oExchangeOfferDetail.DetailID = (int)Dictionary.ExONotHappyReason.LackOfCommitment;
                        oExchangeOfferDetail.Add();
                    }
                    if (chkCommu.Checked == true)
                    {
                        oExchangeOfferDetail.DetailID = (int)Dictionary.ExONotHappyReason.CommunicationGap;
                        oExchangeOfferDetail.Add();
                    }
                    if (chkDelay.Checked == true)
                    {
                        oExchangeOfferDetail.DetailID = (int)Dictionary.ExONotHappyReason.DelayInResponse;
                        oExchangeOfferDetail.Add();
                    }
                    if (chkPrice.Checked == true)
                    {
                        oExchangeOfferDetail.DetailID = (int)Dictionary.ExONotHappyReason.PriceIsNotAppropriate;
                        oExchangeOfferDetail.Add();
                    }
                }

                oExchangeOfferHist.Add();
                DBController.Instance.CommitTransaction();
                string[] sSuccedCode =  { " " };
                Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                UIUtility.GetConfirmationMsg("Save", "The Satus Update", sSuccedCode, null, "ExchangeOffer/frmExchangeOffers.aspx", 0);
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

    protected void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbStatus.Text == "Select Status...")
        {
            Table2.Rows[0].Visible = false;
            Table2.Rows[1].Visible = false;
            Table2.Rows[2].Visible = false;
            Table2.Rows[3].Visible = false;
            Table2.Rows[4].Visible = false;
            Table2.Rows[5].Visible = false;
            Table2.Rows[6].Visible = false;
            Table2.Rows[7].Visible = false;
            Table2.Rows[8].Visible = false;
            lblRemarks.Text = "Remarks:";

        }
        if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.Assign)
        {
            Table2.Rows[0].Visible = true;
            Table2.Rows[1].Visible = true;
            Table2.Rows[2].Visible = false;
            Table2.Rows[3].Visible = false;
            Table2.Rows[4].Visible = false;
            Table2.Rows[5].Visible = false;
            Table2.Rows[6].Visible = false;
            Table2.Rows[7].Visible = false;
            Table2.Rows[8].Visible = true;
            lblRemarks.Text = "Remarks:";

        }
        else if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.Suspend)
        {
            Table2.Rows[0].Visible = false;
            Table2.Rows[1].Visible = false;
            Table2.Rows[2].Visible = false;
            Table2.Rows[3].Visible = false;
            Table2.Rows[4].Visible = false;
            Table2.Rows[5].Visible = false;
            Table2.Rows[6].Visible = false;
            Table2.Rows[7].Visible = false;
            Table2.Rows[8].Visible = false;
            lblRemarks.Text = "Suspend Reason:";
        }
        else if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.Exchanged)
        {
            Table2.Rows[0].Visible = false;
            Table2.Rows[1].Visible = false;
            Table2.Rows[2].Visible = false;
            Table2.Rows[3].Visible = true;
            Table2.Rows[4].Visible = true;
            Table2.Rows[5].Visible = false;
            Table2.Rows[6].Visible = false;
            Table2.Rows[7].Visible = false;
            Table2.Rows[8].Visible = false;
            lblRemarks.Text = "Remarks:";
        }
        else if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.NotExchange)
        {
            Table2.Rows[0].Visible = false;
            Table2.Rows[1].Visible = false;
            Table2.Rows[2].Visible = false;
            Table2.Rows[3].Visible = false;
            Table2.Rows[4].Visible = false;
            Table2.Rows[5].Visible = false;
            Table2.Rows[6].Visible = true;
            Table2.Rows[7].Visible = false;
            Table2.Rows[8].Visible = false;
            lblRemarks.Text = "Remarks:";
        }
        else if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.SalesExecuted)
        {
            Table2.Rows[0].Visible = false;
            Table2.Rows[1].Visible = false;
            Table2.Rows[2].Visible = true;
            Table2.Rows[3].Visible = false;
            Table2.Rows[4].Visible = false;
            Table2.Rows[5].Visible = false;
            Table2.Rows[6].Visible = false;
            Table2.Rows[7].Visible = false;
            Table2.Rows[8].Visible = false;
            lblRemarks.Text = "Remarks:";
        }
        else if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.HappyCall)
        {
            Table2.Rows[0].Visible = false;
            Table2.Rows[1].Visible = false;
            Table2.Rows[2].Visible = false;
            Table2.Rows[3].Visible = false;
            Table2.Rows[4].Visible = false;
            Table2.Rows[5].Visible = true;
            Table2.Rows[6].Visible = false;
            Table2.Rows[7].Visible = false;
            Table2.Rows[8].Visible = false;
            lblRemarks.Text = "Remarks:";
        }
        else if (cmbStatus.SelectedIndex == (int)Dictionary.ExchangeOfferStatusForCombo.Cancel)
        {
            Table2.Rows[0].Visible = false;
            Table2.Rows[1].Visible = false;
            Table2.Rows[2].Visible = false;
            Table2.Rows[3].Visible = false;
            Table2.Rows[4].Visible = false;
            Table2.Rows[5].Visible = false;
            Table2.Rows[6].Visible = false;
            Table2.Rows[7].Visible = false;
            Table2.Rows[8].Visible = false;
             lblRemarks.Text = "Cancel Reason:";
        }
    }
    protected void rdoHappy_CheckedChanged(object sender, EventArgs e)
    {
        rdoHappy.Checked = true;
        rdoSatisfy.Checked = false;
        rdoNotHappy.Checked = false;
        Table2.Rows[7].Visible = false;
    }
    protected void rdoSatisfy_CheckedChanged(object sender, EventArgs e)
    {
        rdoHappy.Checked = false;
        rdoSatisfy.Checked = true;
        rdoNotHappy.Checked = false;
        Table2.Rows[7].Visible = false;
    }
    protected void rdoNotHappy_CheckedChanged(object sender, EventArgs e)
    {
        rdoHappy.Checked = false;
        rdoSatisfy.Checked = false;
        rdoNotHappy.Checked = true;
        Table2.Rows[7].Visible = true;
    }
    protected void rdoPrice_CheckedChanged(object sender, EventArgs e)
    {
        rdoPrice.Checked = true;
        rdoInfoLater.Checked = false;
    }
    protected void rdoInfoLater_CheckedChanged(object sender, EventArgs e)
    {
        rdoPrice.Checked = false;
        rdoInfoLater.Checked = true;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Class.POS;

namespace CJ.Win.CSD.Reception
{
    public partial class frmInvoiceCallsCustomerWise : Form
    {
        int nInvoiceID = 0;
        CSDCustomerSatisfactions _oCSDCustomerSatisfactions;
        DSInvoiceCalls _oDSInvoiceCalls;
        DSInvoiceCalls _oDSInvoiceCallData;
        public bool _IsLoad = false;
        int nSalesType = 0;
        public frmInvoiceCallsCustomerWise()
        {
            InitializeComponent();
            _oDSInvoiceCallData = new DSInvoiceCalls();
        }
        public void ShowDialog(CSDCustomerSatisfaction oCSDCustomerSatisfaction)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oCSDCustomerSatisfaction;
            nSalesType = oCSDCustomerSatisfaction.SalesType;
            nInvoiceID = oCSDCustomerSatisfaction.InvoiceID;
            lblInvoiceNo.Text = oCSDCustomerSatisfaction.InvoiceNo;
            lblInvoiceDate.Text = oCSDCustomerSatisfaction.InvoiceDate.ToString("dd-MMM-yyyy");
            lblInvAmount.Text = oCSDCustomerSatisfaction.InvoiceAmount.ToString();
            lblDiscount.Text = oCSDCustomerSatisfaction.Discount.ToString();
            lblShowroom.Text = oCSDCustomerSatisfaction.ShowroomCode;
            lblConsumerName.Text = oCSDCustomerSatisfaction.ConsumerName;
            txtMobileNo.Text = oCSDCustomerSatisfaction.Mobile;
            lblAddress.Text = oCSDCustomerSatisfaction.Address;
            lblInstallationRequired.Text = oCSDCustomerSatisfaction.InstallationRequired;
            lblIsExchangeOffer.Text = oCSDCustomerSatisfaction.IsExchangeOffer;

            CSDCustomerSatisfactions oCSDCustomerSatisfactions = new CSDCustomerSatisfactions();
            oCSDCustomerSatisfactions.GetDataByCustomerQueryInvoiceWise(oCSDCustomerSatisfaction.InvoiceID);
            foreach (CSDCustomerSatisfaction oItem in oCSDCustomerSatisfactions)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dsvCustomerQuery);
                oRow.Cells[0].Value = oItem.ProductCode.ToString();
                oRow.Cells[1].Value = oItem.ProductName.ToString();
                oRow.Cells[2].Value = oItem.MAGName.ToString();
                oRow.Cells[3].Value = oItem.BrandDesc.ToString();
                oRow.Cells[4].Value = oItem.ProductSerialNo.ToString();
                oRow.Cells[7].Value = oItem.ProductID.ToString();
                oRow.Cells[8].Value = oItem.MAGID.ToString();
                dsvCustomerQuery.Rows.Add(oRow);
            }
            oCSDCustomerSatisfactions.GetFreeQty(oCSDCustomerSatisfaction.InvoiceID);
            foreach (CSDCustomerSatisfaction oFreeQty in oCSDCustomerSatisfactions)
            {
                ListViewItem oItem = dgvFreeQty.Items.Add('[' + oFreeQty.ProductCode.ToString() + ']' + oFreeQty.ProductName.ToString());
                oItem.SubItems.Add(oFreeQty.FreeQty.ToString());
                oItem.Tag = oFreeQty;
            }

            PaymentModes oPaymentModes = new PaymentModes();
            oPaymentModes.GetPaymentMode(oCSDCustomerSatisfaction.InvoiceID);
            foreach (PaymentMode oPaymentMode in oPaymentModes)
            {
                ListViewItem oItem = lvwPayment.Items.Add(oPaymentMode.PaymentModeName.ToString());
                oItem.SubItems.Add(oPaymentMode.Amount.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oPaymentMode.IsEMI));
                oItem.SubItems.Add(oPaymentMode.NoOfInstallment.ToString());
                oItem.Tag = oPaymentMode;
            }


            oCSDCustomerSatisfactions = new CSDCustomerSatisfactions();
            oCSDCustomerSatisfactions.GetDiscountByInvID(oCSDCustomerSatisfaction.InvoiceID);
            foreach (CSDCustomerSatisfaction oDiscount in oCSDCustomerSatisfactions)
            {
                ListViewItem oItem = lvwDiscount.Items.Add(oDiscount.DiscountTypeName);
                oItem.SubItems.Add(oDiscount.DisorChrAmt.ToString());
                oItem.Tag = oDiscount;
            }

            oCSDCustomerSatisfactions = new CSDCustomerSatisfactions();
            oCSDCustomerSatisfactions.GetChargeByInvID(oCSDCustomerSatisfaction.InvoiceID);
            foreach (CSDCustomerSatisfaction oCharge in oCSDCustomerSatisfactions)
            {
                ListViewItem oItem = lvwCharge.Items.Add(oCharge.DiscountTypeName);
                oItem.SubItems.Add(oCharge.DisorChrAmt.ToString());
                oItem.Tag = oCharge;
            }


            this.ShowDialog();
        }

        private void frmInvoiceCallsCustomerWise_Load(object sender, EventArgs e)
        {
            //chkBanForever.Visible = false;
        }
        private bool validateUIInput()
        {
            #region ValidInput
            if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Please Input Mobile No#", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
                return false;
            }
            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {

                try
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    DBController.Instance.BeginNewTransaction();


                    #region Invoice Call
                    CSDCustomerSatisfaction _oCSDCustomerSatisfaction = new CSDCustomerSatisfaction();
                    _oCSDCustomerSatisfaction.Remarks = txtRemarks.Text;
                    if (rdoSatisfy.Checked == true)
                    {
                        _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.Satisfy;
                    }
                    else if (rdoDissatisfy.Checked == true)
                    {
                        _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.Dissatisfy;
                    }
                    else if (rdoModerate.Checked == true)
                    {
                        _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.Moderate;
                    }
                    else if (rdoCallBack.Checked == true)
                    {
                        _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.CallBack;
                    }
                    else if (rdoNumBusy.Checked == true)
                    {
                        _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.NumBusy;
                    }
                    else if (rdoNoResponse.Checked == true)
                    {
                        _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.NoResponse;
                    }

                    else if (rdoSwitchedOff.Checked == true)
                    {
                        _oCSDCustomerSatisfaction.Status = (int)Dictionary.CSDHappyCallStatus.Switched_Off;
                    }
                    if (chkBanForever.Checked == true)
                    {
                        _oCSDCustomerSatisfaction.IsBanforever = (int)Dictionary.YesOrNoStatus.YES;
                    }
                    else
                    {
                        _oCSDCustomerSatisfaction.IsBanforever = (int)Dictionary.YesOrNoStatus.NO;
                    }
                    _oCSDCustomerSatisfaction.InvoiceID = nInvoiceID;
                    _oCSDCustomerSatisfaction.AddbyInvoice();
                    //CSDJob oCSDJob = new CSDJob();
                    //oCSDJob.JobID = _oCSDCustomerSatisfaction.JobID;
                    //oCSDJob.IsHappyCall = (int)Dictionary.YesOrNoStatus.YES;
                    //oCSDJob.UpdateIsHappyCall();
                    


                    CSDCustomerSatisfactionDetail oItem = new CSDCustomerSatisfactionDetail();
                    oItem.ID = _oCSDCustomerSatisfaction.ID;
                    oItem.DeleteInvoiceWise();

                    foreach (DSInvoiceCalls.InvoiceCallsRow oItemRow in _oDSInvoiceCallData.InvoiceCalls)
                    {
                        CSDCustomerSatisfactionDetail _oCSDCustomerSatisfactionDetail = new CSDCustomerSatisfactionDetail();
                        _oCSDCustomerSatisfactionDetail.ID = _oCSDCustomerSatisfaction.ID;
                        _oCSDCustomerSatisfactionDetail.InvoiceID = nInvoiceID;
                        _oCSDCustomerSatisfactionDetail.ProductID = Convert.ToInt32(oItemRow.ProductID);
                        _oCSDCustomerSatisfactionDetail.QuestionID = Convert.ToInt32(oItemRow.QuestionID);
                        try
                        {
                            _oCSDCustomerSatisfactionDetail.Mark = Convert.ToInt32(oItemRow.Marks);
                        }
                        catch
                        {
                            _oCSDCustomerSatisfactionDetail.Mark = -1;
                        }

                        try
                        {
                            _oCSDCustomerSatisfactionDetail.MarkID = Convert.ToInt32(oItemRow.MarksID);
                        }
                        catch
                        {
                            _oCSDCustomerSatisfactionDetail.MarkID = -1;
                        }
                        _oCSDCustomerSatisfactionDetail.ProductSerial = oItemRow.ProductSerial.ToString();

                        CSDJob oJob = new CSDJob();
                        oJob.GetJobIDByProductSerial(oItemRow.ProductSerial.ToString());
                        if (oJob.JobID != 0)
                        {
                            _oCSDCustomerSatisfactionDetail.JobID = oJob.JobID;
                            //CSDJob _oCSDJob = new CSDJob();
                            //_oCSDJob.JobID = oJob.JobID;
                            //_oCSDJob.IsHappyCall = (int)Dictionary.YesOrNoStatus.YES;
                            //_oCSDJob.UpdateIsHappyCall();

                            //Communication _oCommunication = new Communication();
                            //_oCommunication.CreateDate = DateTime.Now;
                            //_oCommunication.CreateUserID = Utility.UserId;
                            //_oCommunication.JobID = oJob.JobID;
                            //_oCommunication.CallType = (int)Dictionary.CallType.HappyCall;
                            //_oCommunication.Remarks = txtRemarks.Text.Trim();
                            //_oCommunication.CallCategory = (int)Dictionary.CallCategory.OutBoundCall;
                            //_oCommunication.Add();

                        }
                        else
                        {

                            _oCSDCustomerSatisfactionDetail.JobID = -1;
                        }

                        _oCSDCustomerSatisfactionDetail.AddInvoiceWise();
                    }
                    #endregion

                    #region Old Invoice Call
                    CSDCustomerSatisfactions oCSDCustomerSatisfactionsOld = new CSDCustomerSatisfactions();
                    oCSDCustomerSatisfactionsOld.GetDatabyNewID(_oCSDCustomerSatisfaction.ID);
                    foreach (CSDCustomerSatisfaction oCSDCustomerSatisfactionOld in oCSDCustomerSatisfactionsOld)
                    {
                        CSDCustomerSatisfaction oCSDCustomerSatisfactionItem = new CSDCustomerSatisfaction();
                        oCSDCustomerSatisfactionItem.JobID = oCSDCustomerSatisfactionOld.JobID;
                        oCSDCustomerSatisfactionItem.Status = oCSDCustomerSatisfactionOld.Status;
                        oCSDCustomerSatisfactionItem.Remarks = oCSDCustomerSatisfactionOld.Remarks;
                        oCSDCustomerSatisfactionItem.CreateDate = oCSDCustomerSatisfactionOld.CreateDate;
                        oCSDCustomerSatisfactionItem.CreateUserID = oCSDCustomerSatisfactionOld.CreateUserID;
                        oCSDCustomerSatisfactionItem.AddOldData();

                        CSDJob _oCSDJob = new CSDJob();
                        _oCSDJob.JobID = oCSDCustomerSatisfactionItem.JobID;
                        _oCSDJob.IsHappyCall = (int)Dictionary.YesOrNoStatus.YES;
                        _oCSDJob.UpdateIsHappyCall();

                        Communication _oCommunication = new Communication();
                        _oCommunication.CreateDate = DateTime.Now;
                        _oCommunication.CreateUserID = Utility.UserId;
                        _oCommunication.JobID = oCSDCustomerSatisfactionItem.JobID;
                        _oCommunication.CallType = (int)Dictionary.CallType.HappyCall;
                        _oCommunication.Remarks = txtRemarks.Text.Trim();
                        _oCommunication.CallCategory = (int)Dictionary.CallCategory.OutBoundCall;
                        _oCommunication.Add();

                        if (rdoNoResponse.Checked == true)
                        {

                        }
                        else if (chkBanForever.Checked == true)
                        {

                        }
                        else
                        {
                            CSDCustomerSatisfactions oCSDCustomerSatisfactionsItem = new CSDCustomerSatisfactions();
                            oCSDCustomerSatisfactionsItem.GetItembyJobID(oCSDCustomerSatisfactionOld.JobID);
                            foreach (CSDCustomerSatisfactionDetail oCSDCustomerSatisfactionDetailItem in oCSDCustomerSatisfactionsItem)
                            {
                                CSDCustomerSatisfactionDetail oItems = new CSDCustomerSatisfactionDetail();
                                oItems.ID = oCSDCustomerSatisfactionItem.ID;
                                oItems.QuestionID = oCSDCustomerSatisfactionDetailItem.QuestionID;
                                oItems.Mark = oCSDCustomerSatisfactionDetailItem.Mark;
                                oItems.Add();
                            }
                        }

                    }
                    #endregion

                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully Add. InvoiceNo# " + lblInvoiceNo.Text.ToString(), "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _IsLoad = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dsvCustomerQuery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _oDSInvoiceCalls = new DSInvoiceCalls();
            if (e.ColumnIndex == 6)
            {
                frmMAGWiseQuestioner oForm = new frmMAGWiseQuestioner();
                oForm.ShowDialog(_oDSInvoiceCalls, Convert.ToInt32(dsvCustomerQuery.CurrentRow.Cells[8].Value), Convert.ToInt32(dsvCustomerQuery.CurrentRow.Cells[7].Value), dsvCustomerQuery.CurrentRow.Cells[1].Value.ToString(), dsvCustomerQuery.CurrentRow.Cells[2].Value.ToString(), dsvCustomerQuery.CurrentRow.Cells[4].Value.ToString(), nSalesType);
                if (oForm._oDSInvoiceCalls != null)
                {
                    _oDSInvoiceCalls = oForm._oDSInvoiceCalls;
                    _oDSInvoiceCallData.Merge(_oDSInvoiceCalls);
                    _oDSInvoiceCallData.AcceptChanges();
                    dsvCustomerQuery.Rows[e.RowIndex].Cells[5].Value = oForm._sMarks;
                }
            }
        }

        private void rdoNoResponse_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdoNoResponse.Checked == true)
            //{
            //    chkBanForever.Visible = true;
            //}
            //else
            //{
            //    chkBanForever.Visible = false;
            //}
        }

        private void rdoCallBack_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
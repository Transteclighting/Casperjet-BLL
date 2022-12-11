using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;

namespace CJ.POS
{
    public partial class frmDCS : Form
    {
        CustomerCreditApprovalCollection _oCustomerCreditApprovalCollection;
        SalesInvoices _oSalesInvoices;
        SalesInvoice _oSalesInvoice;
        TELLib _oTELLib;
        SystemInfo _oSystemInfo;
        PaymentMode _oPaymentMode;
        DCSInstruments _oDCSInstruments;
        Bnak_Accounts _oBnak_Accounts;
        DCS _oDCS;
        DCSDetail _oDCSDetail;
        ConsumerBalanceTran _oConsumerBalanceTran;
        double _InvoiceAmount;
        public frmDCS()
        {
            InitializeComponent();
        }

        private void frmDCS_Load(object sender, EventArgs e)
        {
            _oSystemInfo = new SystemInfo();
            _oSystemInfo.Refresh();

            _oDCS = new DCS();
            // dtFromDate.Value = Convert.ToDateTime(_oSystemInfo.OperationDate);
            DCS oDCS = new DCS();
            DateTime _DtDCSDate = oDCS.LastDcsDate(Convert.ToDateTime(_oSystemInfo.OperationDate)).AddDays(1);
            dtFromDate.Value = _DtDCSDate.Date;
            dtFromDate.Enabled = false;
            DataLoad();
            LoadCombo();

        }
        private void LoadCombo()
        {

            _oDCSInstruments = new DCSInstruments();
            _oDCSInstruments.GetActiveInstrument();

            _oBnak_Accounts = new Bnak_Accounts();
            _oBnak_Accounts.GetActiveBankAccount();

            DataGridViewComboBoxColumn cmbInstrument = new DataGridViewComboBoxColumn();
            cmbInstrument.DataPropertyName = "cmbDCSInsturment";
            cmbInstrument.HeaderText = "Insturment";
            cmbInstrument.Width = 120;
            cmbInstrument.DataSource = _oDCSInstruments;
            cmbInstrument.ValueMember = "InstrumentID";
            cmbInstrument.DisplayMember = "InstrumentName";
            dgvDeposit.Columns.Add(cmbInstrument);

            DataGridViewTextBoxColumn txtAmount = new DataGridViewTextBoxColumn();
            txtAmount.HeaderText = "Amount";
            txtAmount.Width = 90;
            dgvDeposit.Columns.Add(txtAmount);

            DataGridViewComboBoxColumn colBankAccount = new DataGridViewComboBoxColumn();
            colBankAccount.DataPropertyName = "cmbBankAccount";
            colBankAccount.HeaderText = "Bank Account";
            colBankAccount.Width = 190;
            colBankAccount.DataSource = _oBnak_Accounts;
            colBankAccount.ValueMember = "BankAccountID";
            colBankAccount.DisplayMember = "BankName";
            dgvDeposit.Columns.Add(colBankAccount);


            DataGridViewTextBoxColumn txtInstrumentNo = new DataGridViewTextBoxColumn();
            txtInstrumentNo.HeaderText = "Instrument No";
            txtInstrumentNo.Width = 90;
            dgvDeposit.Columns.Add(txtInstrumentNo);

            DataGridViewTextBoxColumn txtDate = new DataGridViewTextBoxColumn();
            txtDate.HeaderText = "Date";
            txtDate.Width = 90;
            dgvDeposit.Columns.Add(txtDate);

            DataGridViewTextBoxColumn txtDepositBranch = new DataGridViewTextBoxColumn();
            txtDepositBranch.HeaderText = "Deposit Branch";
            txtDepositBranch.Width = 130;
            dgvDeposit.Columns.Add(txtDepositBranch);

            DataGridViewTextBoxColumn txtComment = new DataGridViewTextBoxColumn();
            txtComment.HeaderText = "Comment";
            txtComment.Width = 130;
            dgvDeposit.Columns.Add(txtComment);

        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            DataLoad();
        }
        private void DataLoad()
        {

            if (_oDCS.CheckDCSDate(dtFromDate.Value.Date, _oSystemInfo.CustomerID))
            {
                _oSalesInvoices = new SalesInvoices();
                lblInvoiceAmount.Text = "";
                lblCash.Text = "";
                lblCreditCard.Text = "";
                lblAdvanceReceive.Text = "";
                //lblAdvanceCard.Text = "";
                lblOthers.Text = "";
                lblDepositCreditCard.Text = "";
                lblReverseAmount.Text = "";
                lblB2CCredit.Text = "";
                lblAdjustedB2CCredit.Text = "";
                lblBankGuaranty.Text = "";
                lblDepositBankGuaranty.Text = "";
                _InvoiceAmount = 0;
                _oTELLib = new TELLib();
                lvwDCSInvoice.Items.Clear();
                DBController.Instance.OpenNewConnection();
                _oSalesInvoices.RefreshForDCS(dtFromDate.Value.Date);

                foreach (SalesInvoice oSalesInvoice in _oSalesInvoices)
                {
                    ListViewItem oItem = lvwDCSInvoice.Items.Add(oSalesInvoice.InvoiceNo);
                    oItem.SubItems.Add(_oTELLib.TakaFormat(oSalesInvoice.InvoiceAmount));
                    _InvoiceAmount = _InvoiceAmount + Convert.ToDouble(oSalesInvoice.InvoiceAmount);
                    oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.DCSType), oSalesInvoice.DCSType));
                    oItem.Tag = oSalesInvoice;
                }

                GetTotal();
                btnSave.Enabled = true;
            }
            else
            {
                MessageBox.Show("DCS Already prepared Please Select Another Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtFromDate.Focus();
                Clear();
                btnSave.Enabled = false;
            }
        }
        private void GetTotal()
        {
            lblInvoiceAmount.Text = _oTELLib.TakaFormat(_InvoiceAmount);
            _oPaymentMode = new PaymentMode();
            _oConsumerBalanceTran = new ConsumerBalanceTran();
            _oPaymentMode.GetInvoicePaymentMode(dtFromDate.Value.Date);
            _oCustomerCreditApprovalCollection = new CustomerCreditApprovalCollection();
            double _CreditCollection = _oCustomerCreditApprovalCollection.GetCollectionAmount(dtFromDate.Value.Date);
            lblCash.Text = _oTELLib.TakaFormat(_oPaymentMode.Cash);
            lblCreditCollection.Text = _oTELLib.TakaFormat(_CreditCollection);
            lblCreditCard.Text = _oTELLib.TakaFormat(_oPaymentMode.CreditCard);

            lblAdvanceReceive.Text = _oTELLib.TakaFormat(_oConsumerBalanceTran.GetAdvanceAmountByDate(dtFromDate.Value.Date));
            //lblAdvanceCard.Text = _oTELLib.TakaFormat(_oConsumerBalanceTran.GetAdvanceAmountByDateNew(dtFromDate.Value.Date, (int)Dictionary.ConsumerAdvancePaymentMode.Card));


            lblAdvanceAdjusted.Text = _oTELLib.TakaFormat(_oPaymentMode.AdvancePayment);
            lblBankGuaranty.Text = _oTELLib.TakaFormat(_oPaymentMode.BankGuaranty);
            lblOthers.Text = _oTELLib.TakaFormat(_oPaymentMode.Others);
            lblB2CCredit.Text = _oTELLib.TakaFormat(_oPaymentMode.B2BCredit);
            lblAdjustedB2CCredit.Text = _oTELLib.TakaFormat(_oPaymentMode.B2BCredit);
            lblAdvanceAdjustedIN.Text = _oTELLib.TakaFormat(_oPaymentMode.AdvancePayment);

            double _Amount = _oPaymentMode.GetRevInvCard(dtFromDate.Value.Date);
            lblDepositCreditCard.Text = _oTELLib.TakaFormat(_oPaymentMode.CreditCard - _Amount);


            double _BGAmount = _oPaymentMode.GetRevInvBG(dtFromDate.Value.Date);
            lblDepositBankGuaranty.Text = _oTELLib.TakaFormat(_oPaymentMode.BankGuaranty - _BGAmount);

            _oSalesInvoice = new SalesInvoice();
            lblReverseAmount.Text = _oTELLib.TakaFormat(_oSalesInvoice.GetReverseInvoice(dtFromDate.Value.Date));

            double RcvAmt;
            RcvAmt = Convert.ToDouble(txtDCSAdditional.Text) + _oPaymentMode.BankGuaranty + _oPaymentMode.Cash + _oPaymentMode.CreditCard + _oPaymentMode.B2BCredit + _oPaymentMode.Others + Convert.ToDouble(lblAdvanceReceive.Text) + Convert.ToDouble(lblAdvanceAdjustedIN.Text) + _CreditCollection;
            lblTotalReceive.Text = _oTELLib.TakaFormat(RcvAmt);

            double DepAmt;
            DepAmt = Convert.ToDouble(txtOthers.Text) + Convert.ToDouble(lblDepositBankGuaranty.Text) + Convert.ToDouble(lblDepositCreditCard.Text) + Convert.ToDouble(lblAdjustedB2CCredit.Text) + Convert.ToDouble(lblDeposit.Text) + Convert.ToDouble(lblReverseAmount.Text) + _oPaymentMode.AdvancePayment;
            lblTotalDeposit.Text = _oTELLib.TakaFormat(DepAmt); 



            double diff = (RcvAmt - DepAmt);

            if (diff == 0)
            {
                lbldiff.ForeColor = Color.Green;
                lblDifferent.ForeColor = Color.Green;
            }
            else
            {
                lbldiff.ForeColor = Color.Red;
                lblDifferent.ForeColor = Color.Red;
            }
            lblDifferent.Text = _oTELLib.TakaFormat(diff);

        }
        private void txtDCSAdditional_TextChanged(object sender, EventArgs e)
        {

            if (txtDCSAdditional.Text.Trim() == "")
            {
                txtDCSAdditional.Text = "0.00";
            }
            try
            {
                double tmp = Convert.ToDouble(txtDCSAdditional.Text);
                GetTotal();

            }
            catch
            {
                MessageBox.Show("Please Input valid amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            SystemInfo oSystemDate = new SystemInfo();
            oSystemDate.Refresh();
            DateTime dtSystemDate = Convert.ToDateTime(oSystemDate.OperationDate);
            DateTime dtDCSDate = dtFromDate.Value.Date;

            if (dtDCSDate < dtSystemDate)
            {
                if (UIControl())
                {
                    Save();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("DCS Date must be less then OperationDate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Save()
        {
            if (this.Tag != null)
            {
                try
                {
                    //DBController.Instance.BeginNewTransaction();

                    //ConsumerBalanceTran oConsumerBalanceTran = (ConsumerBalanceTran)this.Tag;

                    //_oConsumerBalanceTran = GetUIData(oConsumerBalanceTran);
                    //_oConsumerBalanceTran.Update();

                    //DBController.Instance.CommitTran();
                    //MessageBox.Show("Success fully Update Stock Requisition # " + _oConsumerBalanceTran.AdvancePaymentNo.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {

                if (Convert.ToDouble(lblTotalReceive.Text) == 0)
                {
                    DialogResult oResult = MessageBox.Show("Are you sure you want to want to create Zero value DCS ? ", "Confirm Ticket For DCS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (oResult == DialogResult.Yes)
                    {
                        try
                        {
                            DBController.Instance.BeginNewTransaction();

                            _oDCS = new DCS();
                            _oDCS = GetUIData(_oDCS);
                            _oDCS.Insert(true);
                            SaveAdditionalData(_oDCS.DCSID);

                            DBController.Instance.CommitTran();
                            MessageBox.Show("Successfully Inserted DCS # " + _oDCS.DCSNo.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();

                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else if (Convert.ToDouble(lblTotalReceive.Text) > 0)
                {

                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oDCS = new DCS();
                        _oDCS = GetUIData(_oDCS);
                        _oDCS.Insert(true);
                        SaveAdditionalData(_oDCS.DCSID);

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Inserted DCS # " + _oDCS.DCSNo.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
        private DCS GetUIData(DCS oDCS)
        {
            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();

            

            oDCS.CustomerID = oSystemInfo.CustomerID;

            int nNextDCSNo = oDCS.GetNextNo();
            oDCS.DCSNo = oSystemInfo.Shortcode + "-DCS-" + Convert.ToDateTime(oSystemInfo.OperationDate).Year.ToString() + "-" + nNextDCSNo.ToString("000");
            oDCS.DCSDate = dtFromDate.Value.Date;
            oDCS.CollectionAmount = Convert.ToDouble(lblTotalReceive.Text);
            oDCS.AdditionalAmount = Convert.ToDouble(txtDCSAdditional.Text);
            oDCS.Other_Amount_Debit = Convert.ToDouble(txtOthers.Text);
            oDCS.Remarks = txtRemarks.Text;
            oDCS.IsUpload = (int)Dictionary.YesOrNoStatus.NO;
            oDCS.CreateUserID = Utility.UserId;
            oDCS.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
            oDCS.UpdateUserID = Utility.UserId;
            oDCS.UpdateDate = Convert.ToDateTime(oSystemInfo.OperationDate);

            
            _oSalesInvoices = new SalesInvoices();
            _oSalesInvoices.RefreshForDCS(dtFromDate.Value.Date);
            foreach(SalesInvoice oSalesInvoice in _oSalesInvoices)
            {
                _oDCSDetail = new DCSDetail();

                if (oSalesInvoice.DCSType == (int)Dictionary.DCSType.Invoice)
                {
                    _oDCSDetail.DCSType = (int)Dictionary.DCSType.Invoice;
                }
                else if (oSalesInvoice.DCSType == (int)Dictionary.DCSType.ExtendedWarrantyCollection)
                {
                    _oDCSDetail.DCSType = (int)Dictionary.DCSType.ExtendedWarrantyCollection;
                }
                else
                {
                    _oDCSDetail.DCSType = (int)Dictionary.DCSType.CreditCollection;
                }

                _oDCSDetail.InvoiceID = Convert.ToInt32(oSalesInvoice.InvoiceID);
                _oDCSDetail.InstrumentID = -1;
                _oDCSDetail.Amount = oSalesInvoice.InvoiceAmount;
                _oDCSDetail.BankAccountID = -1;
                _oDCSDetail.BankBranch = "";
                _oDCSDetail.InstrumentNo = "";
                _oDCSDetail.InstrumentDate = null;
                _oDCSDetail.Status = (int)Dictionary.DCSCheckingStatus.UnCheck;
                _oDCSDetail.Remarks = "";

                oDCS.Add(_oDCSDetail);
            }
            

            return oDCS;
        }

        private void SaveAdditionalData(int nDCSID)
        {
            #region Additional Amount
            if (Convert.ToDouble(txtDCSAdditional.Text) != 0)
            {
                _oDCSDetail = new DCSDetail();
                _oDCSDetail.DCSType = (int)Dictionary.DCSType.Invoice;
                _oDCSDetail.InvoiceID = -1;
                _oDCSDetail.InstrumentID = (int)Dictionary.DCSAdditionalInsturement.Additional_Amount;
                _oDCSDetail.Amount = Convert.ToDouble(txtDCSAdditional.Text);
                _oDCSDetail.BankAccountID = -1;
                _oDCSDetail.BankBranch = "";
                _oDCSDetail.InstrumentNo = "";
                _oDCSDetail.InstrumentDate = null;
                _oDCSDetail.Status = (int)Dictionary.DCSCheckingStatus.UnCheck;
                _oDCSDetail.Remarks = "";

                _oDCSDetail.Insert(nDCSID);
            }
            #endregion

            #region Deposit Amount
            if (dgvDeposit.Rows.Count > 1)
            {
                foreach (DataGridViewRow oItemRow in dgvDeposit.Rows)
                {
                    if (oItemRow.Index < dgvDeposit.Rows.Count - 1)
                    {
                        _oDCSDetail = new DCSDetail();

                        _oDCSDetail.DCSType = (int)Dictionary.DCSType.CashCollectNDeposit;
                        _oDCSDetail.InvoiceID = -1;
                        _oDCSDetail.InstrumentID = int.Parse(oItemRow.Cells[0].Value.ToString());
                        _oDCSDetail.Amount = Convert.ToDouble(oItemRow.Cells[1].Value.ToString());

                        if (oItemRow.Cells[2].Value != null && oItemRow.Cells[2].Value != "")
                        {
                            _oDCSDetail.BankAccountID = int.Parse(oItemRow.Cells[2].Value.ToString());
                        }
                        else
                        {
                            _oDCSDetail.BankAccountID = -1;
                        }
                        if (oItemRow.Cells[3].Value != null && oItemRow.Cells[3].Value != "")
                        {
                            _oDCSDetail.InstrumentNo = oItemRow.Cells[3].Value.ToString();
                        }
                        else
                        {
                            _oDCSDetail.InstrumentNo = "";
                        }
                        if (oItemRow.Cells[4].Value != null && oItemRow.Cells[4].Value != "")
                        {
                            _oDCSDetail.InstrumentDate = Convert.ToDateTime(oItemRow.Cells[4].Value.ToString());
                        }
                        else
                        {
                            _oDCSDetail.InstrumentDate = null;
                        }
                        if (oItemRow.Cells[5].Value != null && oItemRow.Cells[5].Value != "")
                        {
                            _oDCSDetail.BankBranch = oItemRow.Cells[5].Value.ToString();
                        }
                        else
                        {
                            _oDCSDetail.BankBranch = "";
                        }
                        if (oItemRow.Cells[6].Value != null && oItemRow.Cells[6].Value != "")
                        {
                            _oDCSDetail.Remarks = oItemRow.Cells[6].Value.ToString();
                        }
                        else
                        {
                            _oDCSDetail.Remarks = "";
                        }

                        _oDCSDetail.Status = (int)Dictionary.DCSCheckingStatus.UnCheck;

                        _oDCSDetail.Insert(nDCSID);
                    }
                }
            }
            #endregion

            #region Other Debit Amount
            if (Convert.ToDouble(txtOthers.Text) != 0)
            {
                _oDCSDetail = new DCSDetail();

                _oDCSDetail.DCSType = (int)Dictionary.DCSType.CashCollectNDeposit;
                _oDCSDetail.InvoiceID = -1;
                _oDCSDetail.InstrumentID = (int)Dictionary.DCSAdditionalInsturement.Others;
                _oDCSDetail.Amount = Convert.ToDouble(txtOthers.Text);
                _oDCSDetail.BankAccountID = -1;
                _oDCSDetail.BankBranch = "";
                _oDCSDetail.InstrumentNo = "";
                _oDCSDetail.InstrumentDate = null;
                _oDCSDetail.Status = (int)Dictionary.DCSCheckingStatus.UnCheck;
                _oDCSDetail.Remarks = "";

                _oDCSDetail.Insert(nDCSID);
            }
            #endregion

            #region Reverse Amount
            _oSalesInvoices = new SalesInvoices();
            _oSalesInvoices.RefreshReverseInvoice(dtFromDate.Value.Date);
            foreach (SalesInvoice oSalesInvoice in _oSalesInvoices)
            {
                _oDCSDetail = new DCSDetail();

                _oDCSDetail.DCSType = (int)Dictionary.DCSType.CashCollectNDeposit;

                _oDCSDetail.InvoiceID = Convert.ToInt32(oSalesInvoice.InvoiceID);
                _oDCSDetail.InstrumentID = -1;
                _oDCSDetail.Amount = oSalesInvoice.InvoiceAmount;
                _oDCSDetail.BankAccountID = -1;
                _oDCSDetail.BankBranch = "";
                _oDCSDetail.InstrumentNo = "";
                _oDCSDetail.InstrumentDate = null;
                _oDCSDetail.Status = (int)Dictionary.DCSCheckingStatus.UnCheck;
                _oDCSDetail.Remarks = "";

                _oDCSDetail.Insert(nDCSID);
            }

            #endregion
        }

        private bool UIControl()
        {
            //if (Convert.ToDouble(lblTotalReceive.Text) <= 0)
            //{
            //    MessageBox.Show("There is no Amount to make DCS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            
            double diffAmt = 0;
            diffAmt = Convert.ToDouble(lblDifferent.Text);
            if (diffAmt != 0)
            {
                MessageBox.Show("Different amount should Zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            #region Deposit Amount
            if (dgvDeposit.Rows.Count > 1)
            {
                foreach (DataGridViewRow oItemRow in dgvDeposit.Rows)
                {
                    if (oItemRow.Index < dgvDeposit.Rows.Count - 1)
                    {

                        if (oItemRow.Cells[1].Value != null && oItemRow.Cells[1].Value != "")
                        {
                            try
                            {
                                double temp = Convert.ToDouble(oItemRow.Cells[1].Value);
                            }
                            catch
                            {
                                MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please Input Deposit Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (oItemRow.Cells[2].Value != null && oItemRow.Cells[2].Value != "")
                        {
                            try
                            {
                                int temp = Convert.ToInt32(oItemRow.Cells[2].Value);
                            }
                            catch
                            {
                                MessageBox.Show("Please Select Bank Account", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please Select Bank Account", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (oItemRow.Cells[4].Value != null && oItemRow.Cells[4].Value != "")
                        {
                            try
                            {
                                DateTime temp = Convert.ToDateTime(oItemRow.Cells[4].Value);
                            }
                            catch
                            {
                                MessageBox.Show("Please Input Valid Date Format like '16-Dec-1971'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please Input Instrument Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }
                }
            }
            #endregion

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOthers_TextChanged(object sender, EventArgs e)
        {
            if (txtOthers.Text.Trim() == "")
            {
                txtOthers.Text = "0.00";
            }
            try
            {
                double tmp = Convert.ToDouble(txtOthers.Text);
                GetTotal();
            }
            catch
            {
                MessageBox.Show("Please Input valid amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void dgvDeposit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            lblDeposit.Text = "0.00";
            double _balance = 0;
            _oTELLib = new TELLib();
            foreach (DataGridViewRow oItemRow in dgvDeposit.Rows)
            {
                if (oItemRow.Index < dgvDeposit.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value != null)
                    {
                        if (oItemRow.Cells[1].Value != null && oItemRow.Cells[1].Value.ToString().Trim() != "")
                        {
                            _balance = _balance + Convert.ToDouble(oItemRow.Cells[1].Value);

                        }
                    }
                }
            }
            lblDeposit.Text = _oTELLib.TakaFormat(_balance);
            txtOthers_TextChanged(null, null);
        }

        private void dgvDeposit_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgvDeposit_CellValueChanged(null, null);
        }

        private void dgvDeposit_Leave(object sender, EventArgs e)
        {
            dgvDeposit_CellValueChanged(null, null);
        }

        private void txtDCSAdditional_Leave(object sender, EventArgs e)
        {
            try
            {
                double tmp = Convert.ToDouble(txtDCSAdditional.Text);

            }
            catch
            {
                MessageBox.Show("Please Input valid amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDCSAdditional.Focus();
            }
        }

        private void txtOthers_Leave(object sender, EventArgs e)
        {
            try
            {
                double tmp = Convert.ToDouble(txtOthers.Text);

            }
            catch
            {
                MessageBox.Show("Please Input valid amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOthers.Focus();
            }
        }

        private void Clear()
        {
            lvwDCSInvoice.Items.Clear();
            lblCash.Text = "0.00";
            lblCreditCard.Text = "0.00";
            lblAdvanceReceive.Text = "0.00";
           // lblAdvanceCard.Text = "0.00";
            lblAdvanceAdjusted.Text = "0.00";
            lblOthers.Text = "0.00";
            lblDepositCreditCard.Text = "0.00";
            lblReverseAmount.Text = "0.00";
            lblTotalReceive.Text = "0.00";
            lblTotalDeposit.Text = "0.00";
            lblDifferent.Text = "0.00";
            lblInvoiceAmount.Text = "0.00";
            lblBankGuaranty.Text = "0.00";
            lblDepositBankGuaranty.Text = "0.00";
            lbldiff.ForeColor = Color.Green;
            lblDifferent.ForeColor = Color.Green;
        }

        private void dgvDeposit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
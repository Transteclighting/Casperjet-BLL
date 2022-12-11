using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CJ.Class;
using CJ.Class.Accounts;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Control;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Reception
{
    public partial class frmAdvancePayment : Form
    {
        private Product _oProduct;
        ConsumerBalanceTran _oConsumerBalanceTran;
        int _nProductId = 0;
        private RetailConsumer _oRetailConsumer;
        private ShowroomAssets _oShowroomAssets;
        private Banks _oBanks;
        PaymentModes _oPaymentModes;

        CSDJob _oCSDJob;
        CSDJobBill _oCSDJobBill;
        ProductDetail _oProductDetail;
        JobHistory _oJobHistory;
        JobHistorys _oJobHistorys;
        CSDJobBillHistorys _oCSDJobBillHistorys;
        public frmAdvancePayment()
        {
            InitializeComponent();
        }

        public void ShowDialog(CSDJob oCSDJob)
        {
            ctlCSDJob1.Visible = false;
            lblJob.Visible = false;
            //this.Tag = oCSDJob;
            _oProductDetail = new ProductDetail();
            _oProductDetail.ProductID = oCSDJob.ProductID;
            _oProductDetail.Refresh();

            txtName.Text = _oProductDetail.ProductName + " [" + _oProductDetail.ProductCode + "]";
            //txtJobNumber.Text = oCSDJob.JobNo;
            //DBController.Instance.OpenNewConnection();
            //ctlCSDJob1.SelectedJob.JobNo= oCSDJob.JobNo;
            txtJobNumber.Text= oCSDJob.JobNo;
            txtContactNo.Text = oCSDJob.MobileNo;
            txtCustomerName.Text = oCSDJob.CustomerName;

            _oCSDJob = oCSDJob;
            this.ShowDialog();
        }

        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearchProduct oForm = new frmSearchProduct(1);
            oForm.ShowDialog();
        }
        private void frmAdvancePayment_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (this.Tag == null)
            {
                LoadCombos();
            }
            else
            {
                txtAmount.Enabled = false;
            }

        }


        private void LoadCombos()
        {
            LoadPaymentMode();
        }


        private void LoadPaymentMode()
        {

            ////Payment Mode
            //_oPaymentModes = new PaymentModes();
            //_oPaymentModes.GetPaymentModeForAdvance(1);
            //cmbPaymentMode.Items.Clear();
            //foreach (PaymentMode oPaymentMode in _oPaymentModes)
            //{
            //    cmbPaymentMode.Items.Add(oPaymentMode.PaymentModeName);
            //}
            //cmbPaymentMode.SelectedIndex = 0;
            
            _oPaymentModes = new PaymentModes();
            _oPaymentModes.RefreshBySalesType(1);
            cmbPaymentMode.Items.Clear();
            foreach (PaymentMode oPaymentMode in _oPaymentModes)
            {
                cmbPaymentMode.Items.Add(oPaymentMode.PaymentModeName);
            }
            cmbPaymentMode.SelectedIndex = 0;
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUiInput())
            {
                Save();
                this.Close();
            }
        }
        private bool ValidateUiInput()
        {

            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show(@"Please input Advance Amount", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return false;
            }
            if (_oPaymentModes[cmbPaymentMode.SelectedIndex].IsMandatoryInstrumentNo == (int)Dictionary.YesOrNoStatus.YES)
            {
                if (txtInstrumentNo.Text == "")
                {
                    MessageBox.Show(@"Please input instrument number", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInstrumentNo.Focus();
                    return false;
                }
            }
            if (_oPaymentModes[cmbPaymentMode.SelectedIndex].IsFinancialInstitution == (int)Dictionary.YesOrNoStatus.YES)
            {
                if (cmbBank.SelectedIndex == 0)
                {
                    MessageBox.Show(@"Please Select Bank", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
            {
                if (cmbBank.SelectedIndex == 0)
                {
                    MessageBox.Show(@"Please Select Bank", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtApprovalNo.Text == "")
                {
                    MessageBox.Show(@"Please input Approval Number", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                
                if (txtInstrumentNo.Text == "")
                {
                    MessageBox.Show(@"Please input instrument number", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (txtInstrumentNo.Text.Length != 16)
                {
                    MessageBox.Show(@"Instrument number must be 16 digits", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.WalkinJobCreated || ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.HomecallJobCreated || ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.AssignedToTechnician || ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.Untouched || ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.WorkInProgress || ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.Estimated || ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.EstimateApproved || ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.Critical || ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.Pending || ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.ReadyForTest || ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.ReturnFromCustomer || ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.TransportRequired || ctlCSDJob1.SelectedJob.Status == (int)Dictionary.JobStatus.ConvertedFromHomeCall)
            {

            }
            else
            {
                MessageBox.Show(@"You cannot take Advance for this Job", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Save()
        {
            try
            {
                DBController.Instance.BeginNewTransaction();

                _oConsumerBalanceTran = new ConsumerBalanceTran();
                _oConsumerBalanceTran = GetUiData(_oConsumerBalanceTran);
                _oConsumerBalanceTran.AddAdvanceCSD(true);

                _oCSDJobBill = new CSDJobBill();
                int nMaxJobBillID = _oCSDJobBill.GetMaxBillID();
                string sNoOfZero = string.Empty;
                for (int i = nMaxJobBillID.ToString().Length; i < 4; i++)
                {
                    sNoOfZero += "0";
                }
                _oCSDJobBill.BillNo = "B-" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + "-" + sNoOfZero + nMaxJobBillID;

                DateTime _dBillDate = DateTime.Now;
                int CreateUserID = Utility.UserId;
                double fAmount = Convert.ToDouble(txtAmount.Text);
                int nBillID= _oConsumerBalanceTran.AddBillAdvance(_oCSDJobBill.BillNo, _dBillDate, CreateUserID, fAmount);

                _oCSDJobBillHistorys = new CSDJobBillHistorys();
                _oCSDJobBillHistorys.Refresh();
                int nNoOfBillHis = _oCSDJobBillHistorys.Count;
                string sNoOfZeros = "";
                for (int i = _oCSDJobBillHistorys.Count.ToString().Length; i < 4; i++)
                {
                    sNoOfZeros += "0";
                }
                    string sMoneyReceiptNo = "M-" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + sNoOfZeros + (_oCSDJobBillHistorys.Count + 1);
                _oConsumerBalanceTran.AddBillHistoryAdvance(nBillID, _dBillDate, sMoneyReceiptNo, fAmount, _oConsumerBalanceTran.AdvancePaymentMode, _oConsumerBalanceTran.InstrumentNo, _oConsumerBalanceTran.InstrumentDate, _oConsumerBalanceTran.BankID);

                DBController.Instance.CommitTran();
                MessageBox.Show(@"Successfully Inserted Advance Payment # " + _oConsumerBalanceTran.AdvancePaymentNo.ToString(), "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(@"Error..." + ex, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
          
        }
        
        private ConsumerBalanceTran GetUiData(ConsumerBalanceTran oConsumerBalanceTran)
        {
            oConsumerBalanceTran.TranType = Dictionary.ConsumerAdvancePaymentTranType.Advance;
            //oConsumerBalanceTran.TranSide = Dictionary.TransectionSide.CREDIT;
            //int nNextApNo = oConsumerBalanceTran.GetNextAPNo();
            //oConsumerBalanceTran.AdvancePaymentNo = "CSD-ADV-" + nNextApNo.ToString("000000");
            oConsumerBalanceTran.InvoiceNo = "";
            oConsumerBalanceTran.Amount = Convert.ToDouble(txtAmount.Text);
            oConsumerBalanceTran.JobID= _oCSDJob.JobID;
            oConsumerBalanceTran.AdvancePaymentMode = _oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID;
            oConsumerBalanceTran.Remarks = txtRemarks.Text;
            oConsumerBalanceTran.CreateUserID = Utility.UserId;
            oConsumerBalanceTran.CreateDate = DateTime.Now;
            oConsumerBalanceTran.UpdateUserID = Utility.UserId;
            oConsumerBalanceTran.UpdateDate = DateTime.Now;

            try
            {
                oConsumerBalanceTran.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
            }
            catch 
            {
                oConsumerBalanceTran.BankID = -1;

            }
            if (oConsumerBalanceTran.BankID != -1)
            {
                try
                {
                    oConsumerBalanceTran.CardType = cmbCreditCardType.SelectedIndex + 1;
                }
                catch
                {
                    oConsumerBalanceTran.CardType = -1;
                }
            }
            else
            {
                oConsumerBalanceTran.CardType = -1;
            }

            try
            {
                oConsumerBalanceTran.POSMachineID = _oShowroomAssets[cmbPOSMachine.SelectedIndex].AssetID;

            }

            catch
            {
                oConsumerBalanceTran.POSMachineID = -1;

            }
            if (oConsumerBalanceTran.BankID != -1)
            {
                try
                {
                    oConsumerBalanceTran.CardCategory = cmbCategory.SelectedIndex + 1;
                }
                catch
                {

                    oConsumerBalanceTran.CardCategory = -1;

                }
            }
            else
            {
                oConsumerBalanceTran.CardCategory = -1;
            }
            try
            {
                oConsumerBalanceTran.InstrumentNo = txtInstrumentNo.Text;
            }
            catch
            {

                oConsumerBalanceTran.InstrumentNo = "";
            }
            try
            {
                oConsumerBalanceTran.InstrumentDate = dtInstrumentDate.Value.Date;
            }
            catch
            {
                oConsumerBalanceTran.InstrumentDate = DateTime.Now.Date;
            }
            try
            {
                oConsumerBalanceTran.ApprovalNo = txtApprovalNo.Text;
            }
            catch
            {
                oConsumerBalanceTran.ApprovalNo = "";

            }
           
            return oConsumerBalanceTran;
        }

        
        
        private void LoadFinancialInstitutions(int nBankID)
        {
            //Bank
            _oBanks = new Banks();
            _oBanks.GetBankByID(nBankID);
            cmbBank.Items.Clear();
            cmbBank.Items.Add("<Select Bank>");
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.SelectedIndex = 1;
        }
        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_oPaymentModes[cmbPaymentMode.SelectedIndex].IsFinancialInstitution == (int)Dictionary.YesOrNoStatus.YES)
            {
                lblInstrumentNo.Text = "Instrument #";
                grpBankPart.Enabled = true;
                LoadFinancialInstitutions(_oPaymentModes[cmbPaymentMode.SelectedIndex].BankID);
                cmbBank.Enabled = true;
                cmbCreditCardType.Enabled = false;
                cmbPOSMachine.Enabled = false;
                cmbCategory.Enabled = false;
                txtApprovalNo.Enabled = false;
            }
            else
            {

                if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
                {
                    lblInstrumentNo.Text = "Card #";
                    grpBankPart.Enabled = true;
                    cmbCreditCardType.Enabled = true;
                    cmbPOSMachine.Enabled = true;
                    cmbCategory.Enabled = true;
                    txtApprovalNo.Enabled = true;
                    LoadBankPart();
                }
                else
                {
                    lblInstrumentNo.Text = "Instrument #";
                    grpBankPart.Enabled = false;
                    cmbBank.Items.Clear();
                    cmbBank.Items.Add("<N/A>");
                    cmbBank.SelectedIndex = 0;
                    cmbCreditCardType.Items.Clear();
                    cmbCreditCardType.Items.Add("<N/A>");
                    cmbCreditCardType.SelectedIndex = 0;

                    cmbPOSMachine.Items.Clear();
                    cmbPOSMachine.Items.Add("<N/A>");
                    cmbPOSMachine.SelectedIndex = 0;

                    cmbCategory.Items.Clear();
                    cmbCategory.Items.Add("<N/A>");
                    cmbCategory.SelectedIndex = 0;
                    

                }
            }
            
            //else
            //{
            //    txtInstrumentNo.Text = "";
            //}
        }
        //{
        //    if (_oPaymentModes[cmbPaymentMode.SelectedIndex].IsFinancialInstitution == (int)Dictionary.YesOrNoStatus.YES)
        //    {
        //        lblInstrumentNo.Text = @"Instrument #";
        //        grpBankPart.Enabled = true;
        //        LoadFinancialInstitutions(_oPaymentModes[cmbPaymentMode.SelectedIndex].BankID);
        //        cmbBank.Enabled = true;
        //        cmbCreditCardType.Enabled = false;
        //        cmbPOSMachine.Enabled = false;
        //        cmbCategory.Enabled = false;
        //        txtApprovalNo.Enabled = false;


        //        txtInstrumentNo.Enabled = true;
        //        dtInstrumentDate.Enabled = true;
        //        cmbBank.Enabled = true;
        //        cmbCategory.Enabled = true;
        //        cmbPOSMachine.Enabled = true;
        //        cmbCategory.Enabled = true;
        //        txtApprovalNo.Enabled = true;
        //    }
        //    else
        //    {

        //        if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
        //        {
        //            lblInstrumentNo.Text = @"Card #";
        //            grpBankPart.Enabled = true;
        //            cmbCreditCardType.Enabled = true;
        //            cmbPOSMachine.Enabled = true;
        //            cmbCategory.Enabled = true;
        //            txtApprovalNo.Enabled = true;

        //            txtInstrumentNo.Enabled = true;
        //            dtInstrumentDate.Enabled = true;
        //            cmbBank.Enabled = true;
        //            cmbCategory.Enabled = true;
        //            cmbPOSMachine.Enabled = true;
        //            cmbCategory.Enabled = true;
        //            txtApprovalNo.Enabled = true;
        //            LoadBankPart();
        //        }
        //        else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].IsMandatoryInstrumentNo == 1)
        //        {
        //            grpBankPart.Enabled = true;
        //            txtInstrumentNo.Enabled = true;
        //            dtInstrumentDate.Enabled = true;
        //            cmbBank.Enabled = false;
        //            cmbCategory.Enabled = false;
        //            cmbPOSMachine.Enabled = false;
        //            cmbCategory.Enabled = false;
        //            txtApprovalNo.Enabled = false;
        //        }
        //        else
        //        {
        //            lblInstrumentNo.Text = @"Instrument #";
        //            grpBankPart.Enabled = false;
        //            cmbBank.Items.Clear();
        //            cmbBank.Items.Add("<N/A>");
        //            cmbBank.SelectedIndex = 0;
        //            cmbCreditCardType.Items.Clear();
        //            cmbCreditCardType.Items.Add("<N/A>");
        //            cmbCreditCardType.SelectedIndex = 0;

        //            cmbPOSMachine.Items.Clear();
        //            cmbPOSMachine.Items.Add("<N/A>");
        //            cmbPOSMachine.SelectedIndex = 0;

        //            cmbCategory.Items.Clear();
        //            cmbCategory.Items.Add("<N/A>");
        //            cmbCategory.SelectedIndex = 0;

        //            txtApprovalNo.Text = "";

        //        }
        //    }

        //}

        private void LoadBankPart()
        {
            //Bank
            _oBanks = new Banks();
            _oBanks.Refresh();
            cmbBank.Items.Clear();
            cmbBank.Items.Add("<Select Bank>");
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.SelectedIndex = 0;

            //Credit Card Type
            cmbCreditCardType.Items.Clear();
            foreach (int getEnum in Enum.GetValues(typeof(Dictionary.CreditCardType)))
            {
                cmbCreditCardType.Items.Add(Enum.GetName(typeof(Dictionary.CreditCardType), getEnum));
            }
            cmbCreditCardType.SelectedIndex = 0;

            //Credit Card Type
            _oShowroomAssets = new ShowroomAssets();
            _oShowroomAssets.Refresh(Dictionary.ShowroomAssetType.POSMachine);
            cmbPOSMachine.Items.Clear();
            foreach (ShowroomAsset oShowroomAsset in _oShowroomAssets)
            {
                cmbPOSMachine.Items.Add(oShowroomAsset.AssetName);
            }
            cmbPOSMachine.SelectedIndex = 0;

            //Credit Card Category
            cmbCategory.Items.Clear();
            foreach (int getEnum in Enum.GetValues(typeof(Dictionary.CreditCardCategory)))
            {
                cmbCategory.Items.Add(Enum.GetName(typeof(Dictionary.CreditCardCategory), getEnum));
            }
            cmbCategory.SelectedIndex = 0;

        }
        

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtAmount.Text);

                }
                catch
                {
                    MessageBox.Show(@"Please Input Valid Amount ", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmount.Text = "";
                }

            }
        }

        private void ctlCSDJob1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCSDJob1.txtDescription.Text.Trim() != "")
            {
                CSDJob oCSDJob = new CSDJob();
                oCSDJob.JobID = ctlCSDJob1.SelectedJob.JobID;
                oCSDJob.Refresh();
                //this.Tag = oCSDJob;
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oCSDJob.ProductID;
                _oProductDetail.Refresh();

                txtName.Text = _oProductDetail.ProductName + " [" + _oProductDetail.ProductCode + "]";

                txtJobNumber.Text = oCSDJob.JobNo;
                txtContactNo.Text = oCSDJob.MobileNo;
                txtCustomerName.Text = oCSDJob.CustomerName;

                _oCSDJob = oCSDJob;
            }
        }
    }
}
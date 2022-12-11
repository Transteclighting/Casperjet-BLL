using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CJ.Class;
using CJ.Class.Accounts;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Control;

namespace CJ.POS
{
    public partial class frmAdvancePayment : Form
    {
        EMITenures _oEmiTenures;
        private Product _oProduct;
        ConsumerBalanceTran _oConsumerBalanceTran;
        int _nProductId = 0;
        TELLib _oTelLib;
        SystemInfo _oInfo;
        private RetailConsumer _oRetailConsumer;
        private ShowroomAssets _oShowroomAssets;
        private Banks _oBanks;
        PaymentModes _oPaymentModes;
        public frmAdvancePayment()
        {
            InitializeComponent();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            _oProduct = new Product {ProductCode = txtProductCode.Text.Trim()};
            _oProduct.RefreshByCode();
            txtProductName.Text = _oProduct.ProductName;
            _nProductId = _oProduct.ProductID;
        }
        public void ShowDialog(ConsumerBalanceTran oConsumerBalanceTran)
        {
            this.Tag = oConsumerBalanceTran;
            LoadCombos();
            _oTelLib = new TELLib();
            Product oProduct = new Product();
            oProduct.ProductID = oConsumerBalanceTran.ProductID;
            oProduct.RefreshByProductID();
            txtProductCode.Text = oProduct.ProductCode;
            txtPurpose.Text = oConsumerBalanceTran.Purpose;
            txtRemarks.Text = oConsumerBalanceTran.Remarks;
            txtAmount.Text = _oTelLib.TakaFormat(oConsumerBalanceTran.Amount).ToString();
            cmbPaymentMode.SelectedIndex = (int)oConsumerBalanceTran.PaymentMode - 1;
            RetailConsumer oRetailConsumer = new RetailConsumer();
            oRetailConsumer.ConsumerID = oConsumerBalanceTran.ConsumerID;
            oRetailConsumer.CustomerID = oConsumerBalanceTran.CustomerID;

            oRetailConsumer.RefreshForPOS();
            txtConsumerCode.Text = oRetailConsumer.ConsumerCode;
            this.ShowDialog();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearchProduct oForm = new frmSearchProduct(1);
            oForm.ShowDialog();
            txtProductCode.Text = oForm.sProductCode;
        }
        private void frmAdvancePayment_Load(object sender, EventArgs e)
        {
            _oInfo = new SystemInfo();
            _oInfo.Refresh();
            if (this.Tag == null)
            {
                LoadCombos();
                rdoExistingConsumer.Checked = true;
            }
            else
            {
                txtAmount.Enabled = false;
                gbConsumerInfo.Enabled = false;
                rdoExistingConsumer.Checked = true;

            }

        }


        private void LoadCombos()
        {
           
            foreach (int getEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), getEnum) ?? string.Empty);
            }
            cmbSalesType.SelectedIndex = 0;
        }


        private void LoadPaymentMode(int _SalesType)
        {

            //Payment Mode
            _oPaymentModes = new PaymentModes();
            _oPaymentModes.GetPaymentModeForAdvance(_SalesType);
            cmbPaymentMode.Items.Clear();
            foreach (PaymentMode oPaymentMode in _oPaymentModes)
            {
                cmbPaymentMode.Items.Add(oPaymentMode.PaymentModeName);
            }
            cmbPaymentMode.SelectedIndex = 0;
        }
        private void rdoExistingConsumer_CheckedChanged(object sender, EventArgs e)
        {
            lblConsumer.Enabled = true;
            txtConsumerCode.Enabled = true;
            btnPicker.Enabled = true;
            txtConsumerName.Enabled = true;

            lbl1.Enabled = true;

            lblConsumerName.Enabled = false;
            txtCustomerName.Enabled = false;
            lbl2.Enabled = false;
            txtCustomerName.Text = "";

            lblConsumerAddress.Enabled = false;
            txtCustomerAddress.Enabled = false;
            lbl3.Enabled = false;
            txtCustomerAddress.Text = "";

            lblMobile.Enabled = false;
            txtCell.Enabled = false;
            lbl4.Enabled = false;
            txtCell.Text = "";

            lblEmail.Enabled = false;
            txtEmail.Enabled = false;
            lbl5.Enabled = false;
            txtEmail.Text = "";

            lblNationalID.Enabled = false;
            txtNationalID.Enabled = false;
            txtNationalID.Text = "";

            lblTelephone.Enabled = false;
            txtTelePhone.Enabled = false;
            txtTelePhone.Text = "";

        }
        private void rdoNewConsumer_CheckedChanged(object sender, EventArgs e)
        {
            lblConsumer.Enabled = false;
            txtConsumerCode.Enabled = false;
            btnPicker.Enabled = false;
            txtConsumerName.Enabled = false;
            lbl1.Enabled = false;
            txtConsumerCode.Text = "";
            txtConsumerName.Text = "";

            lblConsumerName.Enabled = true;
            txtCustomerName.Enabled = true;
            lbl2.Enabled = true;

            lblConsumerAddress.Enabled = true;
            txtCustomerAddress.Enabled = true;
            lbl3.Enabled = true;

            lblMobile.Enabled = true;
            txtCell.Enabled = true;
            lbl4.Enabled = true;

            lblEmail.Enabled = true;
            txtEmail.Enabled = true;
            lbl5.Enabled = true;

            lblNationalID.Enabled = true;
            txtNationalID.Enabled = true;

            lblTelephone.Enabled = true;
            txtTelePhone.Enabled = true;
            
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

            if (ctlCustomer1.txtDescription.Text == "")
            {
                MessageBox.Show(@"Please Select a Customer ", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctlCustomer1.txtCode.Focus();
                return false;
            }


            if (rdoExistingConsumer.Checked == true)
            {
                if (txtConsumerName.Text == "")
                {
                    MessageBox.Show(@"Please Select a Consumer ", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConsumerCode.Focus();
                    return false;
                }
            }
            else
            {
                if (txtCustomerName.Text.Trim() == "")
                {
                    MessageBox.Show(@"Please input Consumer Name ", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustomerName.Focus();
                    return false;
                }
                if (txtCustomerAddress.Text.Trim() == "")
                {
                    MessageBox.Show(@"Please input Consumer Address ", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustomerAddress.Focus();
                    return false;
                }
                if (txtCell.Text.Trim() == "")
                {
                    MessageBox.Show(@"Please input Contact number ", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCell.Focus();
                    return false;
                }
                else
                {
                    if (txtCell.Text.Trim().Length != 11)
                    {
                        MessageBox.Show(@"Please enter a valid cell no", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCell.Focus();
                        return false;
                    }
                    Regex rgCell = new Regex("[0-9]");
                    if (rgCell.IsMatch(txtCell.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show(@"Please Input Valid Cell no ", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (txtEmail.Text.Trim() == "")
                {
                    MessageBox.Show(@"Please input Consumer Email address", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                    return false;
                }
                else
                {
                    Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
                    Match m = emailregex.Match(txtEmail.Text);
                    if (!m.Success)
                    {
                        MessageBox.Show(@"Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                        return false;
                    }
                }
            }
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show(@"Please input Advance Amount", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return false;
            }

            //if(cmbPaymentMode.Text=="Card")
            //{
            //    if (txtInstrumentNo.Text.Trim() == "")
            //    {
            //        MessageBox.Show(@"Please input Instrument Number", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtInstrumentNo.Focus();
            //        return false;
            //    }

            //    if(cmbBank.SelectedIndex==0)
            //    {
            //        MessageBox.Show(@"Please select Bank", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        cmbBank.Focus();
            //        return false;
            //    }

            //}



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

                if (chkIsEMI.Checked == true)
                {
                    if (cmbNoofInstallment.SelectedIndex == 0)
                    {
                        MessageBox.Show(@"Please select EMI tenure", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
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
                if (chkIsEMI.Checked == true)
                {
                    if (cmbNoofInstallment.SelectedIndex == 0)
                    {
                        MessageBox.Show(@"Please select EMI tenure", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
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

            return true;
        }
        private void Save()
        {
            if (this.Tag != null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    ConsumerBalanceTran oConsumerBalanceTran = (ConsumerBalanceTran)this.Tag;
                    _oConsumerBalanceTran = GetUiData(oConsumerBalanceTran);
                    _oConsumerBalanceTran.Update();

                    DBController.Instance.CommitTran();
                    MessageBox.Show(@"Successfully Update Stock Requisition # " + _oConsumerBalanceTran.AdvancePaymentNo.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(@"Error... " + ex, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();

                    _oConsumerBalanceTran = new ConsumerBalanceTran();
                    _oConsumerBalanceTran = GetUiData(_oConsumerBalanceTran);
                    _oConsumerBalanceTran.AddAdvance(true, true);
                    if (_oConsumerBalanceTran.CheckConsumerBalance())
                    {
                        _oConsumerBalanceTran.UpdateConsumerBalance(true, Convert.ToDouble(txtAmount.Text.Trim()));
                    }
                    else
                    {
                        _oConsumerBalanceTran.AddConsumerBalance();
                    }

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
        }
        private ConsumerBalanceTran GetUIDataxxx(ConsumerBalanceTran oConsumerBalanceTran)
        {
            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();

            if (rdoExistingConsumer.Checked == true)
            {
               // oConsumerBalanceTran.ConsumerID = ctlRetailConsumer1.SelectedCustomer.ConsumerID;
            }
            else
            {
                RetailConsumer oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerName = txtCustomerName.Text.Trim();
                oRetailConsumer.Address = txtCustomerAddress.Text.Trim();
                oRetailConsumer.CellNo = txtCell.Text.Trim();
                oRetailConsumer.PhoneNo = txtTelePhone.Text.Trim();
                oRetailConsumer.Email = txtEmail.Text.Trim();
                oRetailConsumer.NationalID = txtNationalID.Text.Trim();
                oRetailConsumer.CustomerID = oSystemInfo.CustomerID;
                oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                oRetailConsumer.SalesType = (int)Dictionary.SalesType.Retail;

                oRetailConsumer.Add();
                oConsumerBalanceTran.ConsumerID = oRetailConsumer.ConsumerID;
            }

            oConsumerBalanceTran.CustomerID = oSystemInfo.CustomerID;

            oConsumerBalanceTran.TranType = Dictionary.ConsumerAdvancePaymentTranType.Advance;
            oConsumerBalanceTran.TranSide = Dictionary.TransectionSide.CREDIT;
            int nNextAPNo = oConsumerBalanceTran.GetNextAPNo();
            oConsumerBalanceTran.AdvancePaymentNo = oSystemInfo.Shortcode + "-ADV-" + nNextAPNo.ToString("000000");
            oConsumerBalanceTran.InvoiceNo = "";
            oConsumerBalanceTran.Amount = Convert.ToDouble(txtAmount.Text);
            oConsumerBalanceTran.Purpose = txtPurpose.Text;
            if (_nProductId != 0)
            {
                oConsumerBalanceTran.ProductID = _nProductId;
            }
            else
            {
                oConsumerBalanceTran.ProductID = -1;
            }
            oConsumerBalanceTran.PaymentMode = (Dictionary.ConsumerAdvancePaymentMode)cmbPaymentMode.SelectedIndex + 1;
            oConsumerBalanceTran.Remarks = txtRemarks.Text;
            oConsumerBalanceTran.IsUpload = (int)Dictionary.YesOrNoStatus.NO;
            oConsumerBalanceTran.CreateUserID = Utility.UserId;
            oConsumerBalanceTran.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
            oConsumerBalanceTran.UpdateUserID = Utility.UserId;
            oConsumerBalanceTran.UpdateDate = Convert.ToDateTime(oSystemInfo.OperationDate);

            return oConsumerBalanceTran;
        }
        private ConsumerBalanceTran GetUiData(ConsumerBalanceTran oConsumerBalanceTran)
        {
            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();

            if (rdoExistingConsumer.Checked == true)
            {
                // oConsumerBalanceTran.ConsumerID = ctlRetailConsumer1.SelectedCustomer.ConsumerID;

                _oRetailConsumer = new RetailConsumer();
                _oRetailConsumer.GetConsumerByCode(txtConsumerCode.Text.Trim());
                oConsumerBalanceTran.ConsumerID = _oRetailConsumer.ConsumerID;
                // oConsumerBalanceTran.CustomerID = oRetailConsumer.CustomerID;
            }
            else
            {
                RetailConsumer oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerName = txtCustomerName.Text.Trim();
                oRetailConsumer.Address = txtCustomerAddress.Text.Trim();
                oRetailConsumer.CellNo = txtCell.Text.Trim();
                oRetailConsumer.PhoneNo = txtTelePhone.Text.Trim();
                oRetailConsumer.Email = txtEmail.Text.Trim();
                oRetailConsumer.NationalID = txtNationalID.Text.Trim();
                oRetailConsumer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                oRetailConsumer.SalesType = cmbSalesType.SelectedIndex + 1;

                oRetailConsumer.Add();
                oConsumerBalanceTran.ConsumerID = oRetailConsumer.ConsumerID;

            }
            oConsumerBalanceTran.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            // oConsumerBalanceTran.CustomerID = oSystemInfo.CustomerID;

            oConsumerBalanceTran.TranType = Dictionary.ConsumerAdvancePaymentTranType.Advance;
            oConsumerBalanceTran.TranSide = Dictionary.TransectionSide.CREDIT;
            int nNextApNo = oConsumerBalanceTran.GetNextAPNo();
            oConsumerBalanceTran.AdvancePaymentNo = oSystemInfo.Shortcode + "-ADV-" + nNextApNo.ToString("000000");
            oConsumerBalanceTran.InvoiceNo = "";
            oConsumerBalanceTran.Amount = Convert.ToDouble(txtAmount.Text);
            oConsumerBalanceTran.Purpose = txtPurpose.Text;
            if (_nProductId != 0)
            {
                oConsumerBalanceTran.ProductID = _nProductId;
            }
            else
            {
                oConsumerBalanceTran.ProductID = -1;
            }
            oConsumerBalanceTran.AdvancePaymentMode = _oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID;
            oConsumerBalanceTran.Remarks = txtRemarks.Text;
            oConsumerBalanceTran.IsUpload = (int)Dictionary.YesOrNoStatus.NO;
            oConsumerBalanceTran.CreateUserID = Utility.UserId;
            oConsumerBalanceTran.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
            oConsumerBalanceTran.UpdateUserID = Utility.UserId;
            oConsumerBalanceTran.UpdateDate = Convert.ToDateTime(oSystemInfo.OperationDate);

            try
            {
                oConsumerBalanceTran.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
            }
            catch 
            {
                oConsumerBalanceTran.BankID = -1;

            }

            try
            {
                oConsumerBalanceTran.CardType = cmbCreditCardType.SelectedIndex + 1;
            }
            catch
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
            try
            {
                oConsumerBalanceTran.CardCategory = cmbCategory.SelectedIndex + 1;
            }
            catch
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
            if (chkIsEMI.Checked)
            {
                oConsumerBalanceTran.IsEMI = (int) Dictionary.YesOrNoStatus.YES;
                oConsumerBalanceTran.NoOfInstallment = _oEmiTenures[cmbNoofInstallment.SelectedIndex - 1].Tenure;
            }
            else
            {
                oConsumerBalanceTran.IsEMI = (int)Dictionary.YesOrNoStatus.NO;
                oConsumerBalanceTran.NoOfInstallment = -1;

            }
            return oConsumerBalanceTran;
        }

        private void cmbSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadPaymentMode(cmbSalesType.SelectedIndex + 1);

            if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
            {
                ctlCustomer1.Enabled = true;
                //txtConsumerCode.Enabled = false;
                //btnPicker.Enabled = false;
                //txtConsumerName.Enabled = false;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtConsumerName.Enabled = true;
                ctlCustomer1.txtCode.Text = "";
                txtConsumerCode.Text = "";
                lblCustomer.Text = @"Dealer/B2B Cust:";
            }
            else if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2C || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.HPA)
            {
                ctlCustomer1.Enabled = true;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtConsumerName.Enabled = true;
                txtConsumerCode.Text = "";
                ctlCustomer1.txtCode.Text = "";
                lblCustomer.Text = @"HPA/B2C Cust:";
            }
            else
            {
                ctlCustomer1.Enabled = false;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtConsumerName.Enabled = true;
                txtConsumerCode.Text = "";
                ctlCustomer1.txtCode.Text = "";
                ctlCustomer1.txtCode.Text = _oInfo.CustomerCode;
                lblCustomer.Text = @"Retail Customer:";
            }
        }

        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCustomer1.txtDescription.Text != "")
            {
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
                {
                    RetailConsumer oRetailConsumer = new RetailConsumer();
                    if (oRetailConsumer.CheckConsumer(ctlCustomer1.SelectedCustomer.CustomerID, cmbSalesType.SelectedIndex + 1))
                    {
                        rdoExistingConsumer.Checked = true;
                        txtConsumerCode.Text = oRetailConsumer.ConsumerCode;


                    }
                    else
                    {
                        rdoNewConsumer.Checked = true;

                        txtCustomerName.Text = ctlCustomer1.txtDescription.Text;
                        txtCustomerAddress.Text = ctlCustomer1.SelectedCustomer.CustomerAddress;
                        txtCell.Text = ctlCustomer1.SelectedCustomer.CellPhoneNo;
                        txtEmail.Text = ctlCustomer1.SelectedCustomer.EmailAddress;
                        txtTelePhone.Text = ctlCustomer1.SelectedCustomer.CustomerTelephone;
                        txtNationalID.Text = "";

                    }

                }

                if (Utility.CompanyInfo == "TEL")
                {
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Retail)
                    {
                        if (ctlCustomer1.SelectedCustomer.CustTypeID != (int)Dictionary.POSCustomerType.Own_Showroom_TEL)
                        {
                            MessageBox.Show("Please select valid Retail Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                            return;
                        }
                    }
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
                    {
                        if (ctlCustomer1.SelectedCustomer.CustTypeID == (int)Dictionary.POSCustomerType.B2B_TEL)
                        {

                        }
                        else if (ctlCustomer1.SelectedCustomer.CustTypeID == (int)Dictionary.POSCustomerType.B2C_TEL)
                        {
                        }
                        else
                        {
                            MessageBox.Show("Please select valid B2B Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                            return;
                        }
                    }
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2C)
                    {
                        if (ctlCustomer1.SelectedCustomer.CustTypeID != (int)Dictionary.POSCustomerType.B2C_TEL)
                        {
                            MessageBox.Show("Please select valid B2C Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                            return;
                        }
                    }
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer)
                    {
                        if (ctlCustomer1.SelectedCustomer.CustTypeID == (int)Dictionary.POSCustomerType.Electronics_Dealer_TEL)
                        {

                        }
                        else if (ctlCustomer1.SelectedCustomer.CustTypeID == (int)Dictionary.POSCustomerType.Electronics_Exclusive_Dealer_TEL)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Please select valid Dealer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                            return;
                        }
                    }
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.HPA)
                    {
                        if (ctlCustomer1.SelectedCustomer.CustTypeID != (int)Dictionary.POSCustomerType.TD_HPA_TEL)
                        {
                            MessageBox.Show("Please select valid HPA customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                            return;
                        }
                    }
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.eStore)
                    {
                        if (ctlCustomer1.SelectedCustomer.CustTypeID != (int)Dictionary.POSCustomerType.Own_Showroom_TEL)
                        {
                            MessageBox.Show("Please select valid retail customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                            return;
                        }
                    }

                }
                if (Utility.CompanyInfo == "TML")
                {
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Retail)
                    {
                        if (ctlCustomer1.SelectedCustomer.CustTypeID != (int)Dictionary.POSCustomerType.TML_RETAIL)
                        {
                            MessageBox.Show("Please select valid Retail Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                            return;
                        }
                    }
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
                    {
                        if (ctlCustomer1.SelectedCustomer.CustTypeID == (int)Dictionary.POSCustomerType.B2B_TML)
                        {

                        }
                        else if (ctlCustomer1.SelectedCustomer.CustTypeID == (int)Dictionary.POSCustomerType.B2C_TML)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Please select valid B2B Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                            return;
                        }
                    }
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2C)
                    {
                        if (ctlCustomer1.SelectedCustomer.CustTypeID != (int)Dictionary.POSCustomerType.B2C_TML)
                        {
                            MessageBox.Show("Please select valid B2C Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                            return;
                        }
                    }
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer)
                    {

                    }
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.HPA)
                    {

                    }
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.eStore)
                    {
                        if (ctlCustomer1.SelectedCustomer.CustTypeID != (int)Dictionary.POSCustomerType.TML_RETAIL)
                        {
                            MessageBox.Show("Please select valid HPA customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ctlCustomer1.txtCode.Text = "";
                            ctlCustomer1.txtCode.Focus();
                            return;
                        }
                    }

                }
            }
            else
            {
                txtCustomerName.Text = "";
                txtCustomerAddress.Text = "";
                txtCell.Text = "";
                txtEmail.Text = "";
                txtCell.Text = "";
                txtTelePhone.Text = "";
                txtNationalID.Text = "";

            }

        }    
        

        private void txtConsumerCode_TextChanged(object sender, EventArgs e)
        {
            _oRetailConsumer = new RetailConsumer();
            txtConsumerCode.ForeColor = System.Drawing.Color.Red;
            txtConsumerName.Text = "";
            if (txtConsumerCode.Text.Length >= 1 && txtConsumerCode.Text.Length <= 25)
            {
                _oRetailConsumer.ConsumerCode = txtConsumerCode.Text;
                _oRetailConsumer.RefreshConsumerByType(cmbSalesType.SelectedIndex + 1);
                if (_oRetailConsumer.ConsumerName == null)
                {
                    txtCustomerName.Text = "";
                    txtCustomerAddress.Text = "";
                    txtCell.Text = "";
                    txtEmail.Text = "";
                    txtCell.Text = "";
                    txtTelePhone.Text = "";
                    txtNationalID.Text = "";
                    _oRetailConsumer = null;
                    AppLogger.LogFatal("There is no data.");
                    return;
                }
                else
                {
                    txtConsumerName.Text = _oRetailConsumer.ConsumerName;
                    txtCustomerName.Text = _oRetailConsumer.ConsumerName;
                    txtCustomerAddress.Text = _oRetailConsumer.Address;
                    txtCell.Text = _oRetailConsumer.CellNo;
                    txtEmail.Text = _oRetailConsumer.Email;
                    txtTelePhone.Text = _oRetailConsumer.PhoneNo;
                    txtNationalID.Text = _oRetailConsumer.NationalID;
                    txtConsumerCode.ForeColor = System.Drawing.Color.Black;
                }
            }
            else
            {
                txtCustomerName.Text = "";
                txtCustomerAddress.Text = "";
                txtCell.Text = "";
                txtEmail.Text = "";
                txtCell.Text = "";
                txtTelePhone.Text = "";
                txtNationalID.Text = "";
                _oRetailConsumer = null;
                txtConsumerCode.ForeColor = System.Drawing.Color.Black;
                return;
            }
        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            if (rdoNewConsumer.Checked == true)
            {

            }
            else if (rdoExistingConsumer.Checked == true)
            {
                _oRetailConsumer = new RetailConsumer();
                frmReatilConsumerSearch oObj = new frmReatilConsumerSearch(cmbSalesType.SelectedIndex + 1, (int)Dictionary.Terminal.Branch_Office, _oInfo.WarehouseID);
                oObj.ShowDialog(_oRetailConsumer);
                if (_oRetailConsumer.ConsumerCode != null)
                {
                    txtConsumerCode.Text = _oRetailConsumer.ConsumerCode.ToString();
                    ctlCustomer1.txtCode.Text = _oRetailConsumer.CustomerCode.ToString();
                    ctlCustomer1.Enabled = false;

                }
            }
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
                lblInstrumentNo.Text = @"Instrument #";
                grpBankPart.Enabled = true;
                LoadFinancialInstitutions(_oPaymentModes[cmbPaymentMode.SelectedIndex].BankID);
                cmbBank.Enabled = true;
                cmbCreditCardType.Enabled = false;
                cmbPOSMachine.Enabled = false;
                cmbCategory.Enabled = false;
                txtApprovalNo.Enabled = false;
                chkIsEMI.Enabled = true;


                txtInstrumentNo.Enabled = true;
                dtInstrumentDate.Enabled = true;
                cmbBank.Enabled = true;
                cmbCategory.Enabled = true;
                cmbPOSMachine.Enabled = true;
                cmbCategory.Enabled = true;
                txtApprovalNo.Enabled = true;
            }
            else
            {

                if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
                {
                    lblInstrumentNo.Text = @"Card #";
                    grpBankPart.Enabled = true;
                    cmbCreditCardType.Enabled = true;
                    cmbPOSMachine.Enabled = true;
                    cmbCategory.Enabled = true;
                    txtApprovalNo.Enabled = true;

                    txtInstrumentNo.Enabled = true;
                    dtInstrumentDate.Enabled = true;
                    cmbBank.Enabled = true;
                    cmbCategory.Enabled = true;
                    cmbPOSMachine.Enabled = true;
                    cmbCategory.Enabled = true;
                    txtApprovalNo.Enabled = true;
                    LoadBankPart();
                }
                else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].IsMandatoryInstrumentNo == 1)
                {
                    grpBankPart.Enabled = true;
                    txtInstrumentNo.Enabled = true;
                    dtInstrumentDate.Enabled = true;
                    cmbBank.Enabled = false;
                    cmbCategory.Enabled = false;
                    cmbPOSMachine.Enabled = false;
                    cmbCategory.Enabled = false;
                    txtApprovalNo.Enabled = false;
                }
                else
                {
                    lblInstrumentNo.Text = @"Instrument #";
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

                    cmbNoofInstallment.Items.Clear();
                    cmbNoofInstallment.Items.Add("<N/A>");
                    cmbNoofInstallment.SelectedIndex = 0;

                    txtApprovalNo.Text = "";

                }
            }

        }

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
        private void GetEmiTenure(int nBankId)
        {
            //GetEMITenure
            _oEmiTenures = new EMITenures();
            _oEmiTenures.GetEMITenureByBank(nBankId);
            cmbNoofInstallment.Items.Clear();
            cmbNoofInstallment.Items.Add("<Select EMI Tenure>");
            foreach (EMITenure oEmiTenure in _oEmiTenures)
            {
                cmbNoofInstallment.Items.Add(oEmiTenure.Tenure.ToString());
            }
            cmbNoofInstallment.SelectedIndex = 0;
        }
        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBank.SelectedIndex > 0)
            {
                if (_oBanks[cmbBank.SelectedIndex - 1].IsEMI == 1)
                {
                    chkIsEMI.Enabled = true;
                    chkIsEMI.Checked = false;
                    GetEmiTenure(_oBanks[cmbBank.SelectedIndex - 1].BankID);
                }
                else
                {
                    chkIsEMI.Enabled = false;
                    chkIsEMI.Checked = false;
                    cmbNoofInstallment.Enabled = false;
                    cmbNoofInstallment.Items.Clear();
                    cmbNoofInstallment.Items.Add("N/A");
                    cmbNoofInstallment.SelectedIndex = 0;
                }
            }
        }

        private void chkIsEMI_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsEMI.Checked == true)
            {
                cmbNoofInstallment.Enabled = true;
                lblNoOfInstallment.Enabled = true;
            }
            else
            {
                cmbNoofInstallment.Enabled = false;
                lblNoOfInstallment.Enabled = false;
                cmbNoofInstallment.SelectedIndex = 0;
            }
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
    }
}
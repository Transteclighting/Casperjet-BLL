using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CJ.Class;
using CJ.Class.Accounts;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Control;
using CJ.Class.Web.UI.Class;

namespace CJ.POS.RT
{

    public partial class frmAdvancePayment : Form
    {
        RetailConsumer oRetailConsumer;
        int nExistingLocalConsumerID = 0;
        EMITenures _oEmiTenures;
        private Product _oProduct;
        ConsumerBalanceTran _oConsumerBalanceTran;
        int _nProductId = 0;
        TELLib _oTelLib;
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
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oTelLib = new TELLib();
            if (this.Tag == null)
            {
                LoadCombos();
                rdoExistingConsumer.Checked = true;

                dtInstrumentDate.Value = _oTelLib.ServerDateTime().Date;
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
            ctlCustomer1.Enabled = false;
            ctlCustomer1.txtCode.Text = "";
            if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Retail || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.eStore)
            {
                ctlCustomer1.txtCode.Text = Utility.CustomerCode;
            }

        }
        private void rdoNewConsumer_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.HPA || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2C)
            {
                ctlCustomer1.Enabled = true;
            }

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
            ctlCustomer1.txtCode.Text = "";
            if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Retail || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.eStore)
            {
                ctlCustomer1.txtCode.Text = Utility.CustomerCode;
            }
            //else
            //{
            //    ctlCustomer1.txtCode.Text = "";
            //}
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

            int _nUIControl = cmbSalesType.SelectedIndex + 1;
            if (_nUIControl == (int)Dictionary.SalesType.Retail || _nUIControl == (int)Dictionary.SalesType.eStore || _nUIControl == (int)Dictionary.SalesType.B2C || _nUIControl == (int)Dictionary.SalesType.HPA)
            {


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
                        nExistingLocalConsumerID = 0;
                        if (rgCell.IsMatch(txtCell.Text))
                        {
                            RetailConsumer oConsumer = new RetailConsumer();
                            if (oConsumer.GetConsumerByMobileNoSalesTypeRT(txtCell.Text, cmbSalesType.SelectedIndex + 1))
                            {
                                if (rdoNewConsumer.Checked == true)
                                {
                                    nExistingLocalConsumerID = oConsumer.RetailConsumerID;
                                    MessageBox.Show("This mobile number already register.Please select existing consumer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                                else
                                {
                                    nExistingLocalConsumerID = 0;
                                }
                            }
                            else
                            {
                                nExistingLocalConsumerID = 0;
                            }


                        }
                        else
                        {
                            MessageBox.Show("Please Input Valid Cell no ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


            }
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
                    _oConsumerBalanceTran.UpdateRT();

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
                    _oConsumerBalanceTran.AddAdvancePOSRT(true, true);
                    if (_oConsumerBalanceTran.CheckConsumerBalance())
                    {
                        _oConsumerBalanceTran.UpdateConsumerBalanceWEB(true, Convert.ToDouble(txtAmount.Text.Trim()), Utility.WarehouseID);
                    }
                    else
                    {
                        _oConsumerBalanceTran.AddConsumerBalanceWEB(Utility.WarehouseID);
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

        private int AddNewConsumer(string sCode, int nMotherConumerID)
        {
            oRetailConsumer = new RetailConsumer();
            if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer)
            {
                oRetailConsumer = new RetailConsumer();
                if (oRetailConsumer.CheckConsumerRT(ctlCustomer1.SelectedCustomer.CustomerID, cmbSalesType.SelectedIndex + 1))
                {
                    //nConsumerID = oRetailConsumer.ConsumerID;
                    //nCustomerID = oRetailConsumer.CustomerID;
                }
                else
                {
                    CustomerDetail oCustomerDetail = new CustomerDetail();
                    oCustomerDetail.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    oCustomerDetail.RefreshForSalesOrder();
                    oRetailConsumer = new RetailConsumer();
                    oRetailConsumer.ConsumerName = oCustomerDetail.CustomerName;
                    oRetailConsumer.ConsumerType = 0;
                   // nCustomerID = oCustomerDetail.CustomerID;
                    oRetailConsumer.CustomerID = oCustomerDetail.CustomerID;
                    oRetailConsumer.SecondaryConsumer = "";
                    oRetailConsumer.SecondaryMobileNo = "";
                    oRetailConsumer.ParentCustomerID = Utility.CustomerID;
                    oRetailConsumer.Address = oCustomerDetail.CustomerAddress;
                    oRetailConsumer.CellNo = oCustomerDetail.CustomerPhoneNo;
                    oRetailConsumer.PhoneNo = "";
                    oRetailConsumer.Email = "";
                    oRetailConsumer.EmployeeCode = "";
                    oRetailConsumer.NationalID = "";
                    oRetailConsumer.DateofBirth = null;
                    oRetailConsumer.VatRegNo = oCustomerDetail.TaxNumber;
                    oRetailConsumer.DeliveryAddress = oCustomerDetail.CustomerAddress;
                    oRetailConsumer.SalesType = cmbSalesType.SelectedIndex + 1;
                    oRetailConsumer.WarehouseID = Utility.WarehouseID;
                    oRetailConsumer.IsVerifiedEmail = 0;
                    oRetailConsumer.AddRT();
                }
            }
            else
            {

                oRetailConsumer.ConsumerCode = sCode;
                oRetailConsumer.ConsumerName = txtCustomerName.Text;
                oRetailConsumer.ConsumerType = 0;
                oRetailConsumer.SecondaryConsumer = "";
                oRetailConsumer.SecondaryMobileNo = "";
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Retail)
                {
                    oRetailConsumer.CustomerID = Utility.CustomerID;
                }
                else if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.eStore)
                {
                    oRetailConsumer.CustomerID = Utility.CustomerID;
                }
                else
                {
                    oRetailConsumer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                }
                oRetailConsumer.ParentCustomerID = Utility.CustomerID;
                oRetailConsumer.Address = txtCustomerAddress.Text;
                oRetailConsumer.CellNo = txtCell.Text;
                oRetailConsumer.PhoneNo = txtTelePhone.Text;
                oRetailConsumer.Email = txtEmail.Text;
                oRetailConsumer.EmployeeCode = "";
                oRetailConsumer.NationalID = txtNationalID.Text;
                oRetailConsumer.DateofBirth = null;
                oRetailConsumer.VatRegNo = "";
                oRetailConsumer.DeliveryAddress = txtCustomerAddress.Text;
                oRetailConsumer.SalesType = cmbSalesType.SelectedIndex + 1;
                oRetailConsumer.WarehouseID = Utility.WarehouseID;
                oRetailConsumer.IsVerifiedEmail = 0;
                oRetailConsumer.MotherConsumerID = nMotherConumerID;
                oRetailConsumer.AddNewRetailConsumerRTNew();

            }
            return oRetailConsumer.ConsumerID;
        }

        private int AddMotherConsumer(string sCode)
        {
            int nID = 0;
            oRetailConsumer = new RetailConsumer();
            oRetailConsumer.ConsumerCode = sCode;
            oRetailConsumer.ConsumerName = txtCustomerName.Text;
            oRetailConsumer.Address = txtCustomerAddress.Text;
            oRetailConsumer.CellNo = txtCell.Text;
            oRetailConsumer.PhoneNo = txtTelePhone.Text;
            oRetailConsumer.Email = txtEmail.Text;

            nID = oRetailConsumer.AddConsumerDetailRT();
            return nID;

        }

        //private void AddConsumerforAdvance()
        //{
        //    int _nUIControl = cmbSalesType.SelectedIndex + 1;
        //    if (_nUIControl == (int)Dictionary.SalesType.Retail || _nUIControl == (int)Dictionary.SalesType.eStore || _nUIControl == (int)Dictionary.SalesType.B2C || _nUIControl == (int)Dictionary.SalesType.HPA)
        //    {
        //        if (rdoNewConsumer.Checked == true)
        //        {
        //            oRetailConsumer = new RetailConsumer();
        //            string sMaxConsumerCode = oRetailConsumer.GetMaxConsumerCode();
        //            int nMotherConsumerID = AddMotherConsumer(sMaxConsumerCode);
        //            AddNewConsumer(sMaxConsumerCode, nMotherConsumerID);
        //        }
        //        if (rdoExistingConsumer.Checked == true)
        //        {
        //            if (_oRetailConsumer.RetailConsumerID != 0)
        //            {
        //                oRetailConsumer = new RetailConsumer();
        //                oRetailConsumer.ConsumerID = _oRetailConsumer.RetailConsumerID;
        //                oRetailConsumer.ConsumerCode = _oRetailConsumer.RetailConsumerCode;
        //                oRetailConsumer.CustomerID = _oRetailConsumer.CustomerID;

        //                // oRetailConsumer.ConsumerID = _oRetailConsumer.RetailConsumerID;

        //            }
        //            else
        //            {
        //                RetailConsumer oGetMaxConsumerCode = new RetailConsumer();
        //                string sMaxConsumerCode = oGetMaxConsumerCode.GetMaxConsumerCode();
        //                AddNewConsumer(sMaxConsumerCode, _oRetailConsumer.ConsumerID);
        //            }
        //        }

        //    }
        //    else if (_nUIControl == (int)Dictionary.SalesType.B2B || _nUIControl == (int)Dictionary.SalesType.Dealer)
        //    {
        //        oRetailConsumer = new RetailConsumer();
        //        if (oRetailConsumer.CheckConsumerRT(ctlCustomer1.SelectedCustomer.CustomerID, _nUIControl))
        //        {
        //            nConsumerID = oRetailConsumer.ConsumerID;
        //            nCustomerID = oRetailConsumer.CustomerID;
        //        }
        //        else
        //        {
        //            oCustomerDetail = new CustomerDetail();
        //            oCustomerDetail.CustomerID = _oCustomer.CustomerID;
        //            oCustomerDetail.RefreshForSalesOrder();
        //            oRetailConsumer = new RetailConsumer();
        //            oRetailConsumer.ConsumerName = oCustomerDetail.CustomerName;
        //            oRetailConsumer.ConsumerType = cmbConType.SelectedIndex;
        //            nCustomerID = oCustomerDetail.CustomerID;
        //            oRetailConsumer.CustomerID = nCustomerID;
        //            oRetailConsumer.SecondaryConsumer = txtSecConsumer.Text;
        //            oRetailConsumer.SecondaryMobileNo = txtSecMobileNo.Text;
        //            oRetailConsumer.ParentCustomerID = Utility.CustomerID;
        //            oRetailConsumer.Address = oCustomerDetail.CustomerAddress;
        //            oRetailConsumer.CellNo = oCustomerDetail.CustomerPhoneNo;
        //            oRetailConsumer.PhoneNo = "";
        //            oRetailConsumer.Email = "";
        //            oRetailConsumer.EmployeeCode = "";
        //            oRetailConsumer.NationalID = "";
        //            oRetailConsumer.DateofBirth = null;
        //            oRetailConsumer.VatRegNo = oCustomerDetail.TaxNumber;
        //            oRetailConsumer.DeliveryAddress = oCustomerDetail.CustomerAddress;
        //            oRetailConsumer.SalesType = _nUIControl;
        //            oRetailConsumer.WarehouseID = Utility.WarehouseID;
        //            oRetailConsumer.SecondaryConsumer = txtSecConsumer.Text;
        //            oRetailConsumer.SecondaryMobileNo = txtSecMobileNo.Text;

        //            if (chkInvoiceSend.Checked == true)
        //            {
        //                oRetailConsumer.IsVerifiedEmail = 1;
        //            }
        //            else
        //            {
        //                oRetailConsumer.IsVerifiedEmail = 0;
        //            }
        //            oRetailConsumer.AddRT();
        //        }
        //    }
        //}
        private ConsumerBalanceTran GetUiData(ConsumerBalanceTran oConsumerBalanceTran)
        {

            Showroom oShowroom = new Showroom();
            if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer)
            {
                oRetailConsumer = new RetailConsumer();
                string sMaxConsumerCode = oRetailConsumer.GetMaxConsumerCode();
                oConsumerBalanceTran.ConsumerID = AddNewConsumer(sMaxConsumerCode, -1);
            }
            else
            {
                if (rdoNewConsumer.Checked == true)
                {
                    oRetailConsumer = new RetailConsumer();
                    string sMaxConsumerCode = oRetailConsumer.GetMaxConsumerCode();

                    int nMotherConsumerID = AddMotherConsumer(sMaxConsumerCode);
                    oConsumerBalanceTran.ConsumerID = AddNewConsumer(sMaxConsumerCode, nMotherConsumerID);
                }
                if (rdoExistingConsumer.Checked == true)
                {
                    if (_oRetailConsumer.RetailConsumerID != 0)
                    {
                        oRetailConsumer = new RetailConsumer();
                        oRetailConsumer.ConsumerID = _oRetailConsumer.RetailConsumerID;
                        oRetailConsumer.ConsumerCode = _oRetailConsumer.RetailConsumerCode;
                        oRetailConsumer.CustomerID = _oRetailConsumer.CustomerID;
                        oConsumerBalanceTran.ConsumerID = _oRetailConsumer.RetailConsumerID;
                    }
                    else
                    {
                        RetailConsumer oGetMaxConsumerCode = new RetailConsumer();
                        string sMaxConsumerCode = oGetMaxConsumerCode.GetMaxConsumerCode();
                        oConsumerBalanceTran.ConsumerID = AddNewConsumer(sMaxConsumerCode, _oRetailConsumer.ConsumerID);

                    }
                }
            }
            
            oConsumerBalanceTran.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            oConsumerBalanceTran.TranType = Dictionary.ConsumerAdvancePaymentTranType.Advance;
            oConsumerBalanceTran.TranSide = Dictionary.TransectionSide.CREDIT;

            int nNextApNo = oShowroom.GetNextTranNo("NextAdvancePaymentNo");
            oConsumerBalanceTran.AdvancePaymentNo = Utility.Shortcode + "-ADV-" + nNextApNo.ToString("000000");
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
                txtConsumerCode.Enabled = false;
                btnPicker.Enabled = false;
                txtConsumerName.Enabled = false;
                ctlCustomer1.txtCode.Text = "";
                txtConsumerCode.Text = "";
                lblCustomer.Text = @"Dealer/B2B Cust:";
                rdoExistingConsumer.Visible = false;
                rdoNewConsumer.Visible = false;


                rdoExistingConsumer.Checked = false;
                rdoNewConsumer.Checked = false;


                txtCustomerName.Enabled = false;
                txtCustomerAddress.Enabled = false;
                txtCell.Enabled = false;
                txtEmail.Enabled = false;
                txtNationalID.Enabled = false;
                txtTelePhone.Enabled = false;
            }
            else if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2C || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.HPA)
            {


                rdoExistingConsumer.Visible = true;
                rdoNewConsumer.Visible = true;
                rdoNewConsumer.Checked = true;

                txtCustomerName.Enabled = true;
                txtCustomerAddress.Enabled = true;
                txtCell.Enabled = true;
                txtEmail.Enabled = true;
                txtNationalID.Enabled = true;
                txtTelePhone.Enabled = true;

                rdoExistingConsumer.Visible = true;
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

                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Retail || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.eStore)
                {
                    ctlCustomer1.txtCode.Text = Utility.CustomerCode;
                }
                rdoExistingConsumer.Visible = true;
                rdoNewConsumer.Visible = true;
                rdoNewConsumer.Checked = true;

                txtCustomerName.Enabled = true;
                txtCustomerAddress.Enabled = true;
                txtCell.Enabled = true;
                txtEmail.Enabled = true;
                txtNationalID.Enabled = true;
                txtTelePhone.Enabled = true;


                ctlCustomer1.Enabled = false;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtConsumerName.Enabled = true;
                txtConsumerCode.Text = "";
                ctlCustomer1.txtCode.Text = "";
                ctlCustomer1.txtCode.Text = Utility.CustomerCode;
                lblCustomer.Text = @"Retail Customer:";
            }
        }
        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCustomer1.txtDescription.Text != "")
            {
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
                {
                    //RetailConsumer oRetailConsumer = new RetailConsumer();
                    //if (oRetailConsumer.CheckConsumerRT(ctlCustomer1.SelectedCustomer.CustomerID, cmbSalesType.SelectedIndex + 1))
                    //{

                    //    txtConsumerCode.Text = oRetailConsumer.ConsumerCode;
                    //    txtCustomerName.Text = ctlCustomer1.txtDescription.Text;
                    //    txtCustomerAddress.Text = ctlCustomer1.SelectedCustomer.CustomerAddress;
                    //    txtCell.Text = ctlCustomer1.SelectedCustomer.CellPhoneNo;
                    //    txtEmail.Text = ctlCustomer1.SelectedCustomer.EmailAddress;
                    //    txtTelePhone.Text = ctlCustomer1.SelectedCustomer.CustomerTelephone;
                    //    txtNationalID.Text = "";
                    //    //rdoExistingConsumer.Checked = true;
                    //}
                    //else
                    //{
                    txtCustomerName.Text = ctlCustomer1.txtDescription.Text;
                    txtCustomerAddress.Text = ctlCustomer1.SelectedCustomer.CustomerAddress;
                    txtCell.Text = ctlCustomer1.SelectedCustomer.CellPhoneNo;
                    txtEmail.Text = ctlCustomer1.SelectedCustomer.EmailAddress;
                    txtTelePhone.Text = ctlCustomer1.SelectedCustomer.CustomerTelephone;
                    txtNationalID.Text = "";
                    //rdoNewConsumer.Checked = true;
                    //}

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
            if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
            {

            }
            else
            {
                if (txtConsumerCode.Text != "")
                {
                    if (rdoExistingConsumer.Checked == true)
                    {
                        oRetailConsumer = new RetailConsumer();
                        txtConsumerCode.ForeColor = System.Drawing.Color.Red;
                        txtConsumerName.Text = "";
                        _oRetailConsumer = new RetailConsumer();
                        if (txtConsumerCode.Text.Length >= 1 && txtConsumerCode.Text.Length <= 25)
                        {
                            oRetailConsumer.ConsumerCode = txtConsumerCode.Text;
                            oRetailConsumer.RefreshConsumerByTypeRT(cmbSalesType.SelectedIndex + 1, txtConsumerCode.Text);
                            if (oRetailConsumer.ConsumerName == null)
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
                                _oRetailConsumer = oRetailConsumer;
                                txtConsumerName.Text = oRetailConsumer.ConsumerName.ToString();
                                txtCustomerName.Text = oRetailConsumer.ConsumerName;
                                txtCustomerAddress.Text = oRetailConsumer.Address;
                                txtEmail.Text = oRetailConsumer.Email;
                                txtNationalID.Text = oRetailConsumer.NationalID;
                                txtCell.Text = oRetailConsumer.CellNo;
                                txtTelePhone.Text = oRetailConsumer.PhoneNo;
                                txtConsumerCode.SelectionStart = 0;
                                txtConsumerCode.SelectionLength = txtConsumerCode.Text.Length;
                                txtConsumerCode.ForeColor = System.Drawing.Color.Empty;

                                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Retail || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.eStore)
                                {
                                    ctlCustomer1.txtCode.Text = Utility.CustomerCode;
                                }
                                else
                                {
                                    ctlCustomer1.txtCode.Text = oRetailConsumer.CustomerCode;
                                }

                            }
                        }
                        else
                        {
                            txtCustomerName.Text = "";
                            txtCustomerAddress.Text = "";
                            txtEmail.Text = "";
                            txtCell.Text = "";
                            txtTelePhone.Text = "";
                            txtNationalID.Text = "";
                            txtEmail.Enabled = true;
                        }

                    }

                }
                else
                {
                    txtConsumerName.Text = "";
                    txtCustomerName.Text = "";
                    txtCustomerAddress.Text = "";
                    txtEmail.Text = "";
                    txtCell.Text = "";
                    txtTelePhone.Text = "";
                    txtNationalID.Text = "";
                    txtEmail.Enabled = true;

                    oRetailConsumer = null;
                    AppLogger.LogFatal("There is no data.");
                    return;
                }
            }
           
        }
        private void btnPicker_Click(object sender, EventArgs e)
        {
            if (rdoExistingConsumer.Checked == true)
            {
                oRetailConsumer = new RetailConsumer();
                frmReatilConsumerSearchRT oObj = new frmReatilConsumerSearchRT(cmbSalesType.SelectedIndex + 1);
                oObj.ShowDialog(oRetailConsumer);

                if (oRetailConsumer.ConsumerCode != null)
                {
                    txtConsumerCode.Text = oRetailConsumer.ConsumerCode.ToString();
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Retail || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.eStore)
                    {
                        ctlCustomer1.txtCode.Text = Utility.CustomerCode;
                    }
                    else
                    {
                        ctlCustomer1.txtCode.Text = oRetailConsumer.CustomerCode.ToString();
                    }
                    
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
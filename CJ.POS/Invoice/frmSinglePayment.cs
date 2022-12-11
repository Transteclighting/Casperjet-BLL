using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Accounts;
using CJ.Class.Library;

namespace CJ.POS.Invoice
{
    public partial class frmSinglePayment : Form
    {
        bool _IsTrueBlanDiscount = true;
        int _nConsumerID = 0;
        int _nBankDiscountID = 0;
        int _nExtendedEMIChargeID = 0;
        int nFreeEMIID = 0;
        int nWarehousID = 0;
        double _AmtForBG = 0;
        TELLib _oTELLib;
        public DSInvoicePayment _oDSInvoicePayment;
        DSInvoicePayment _oDSInvoicePaymentExptProductSingle;
        int _nDataID = 0;
        PaymentModes _oPaymentModes;
        Banks _oBanks;

        EMITenures _oEMITenures;
        ShowroomAssets _oShowroomAssets;
        double _nDueAmt = 0;
        string _ProductName = "";
        int _ProductID = 0;
        int _CustomerID = 0;
        int _UIControl = 0;
        string _ConsumerCode = "";
        DateTime _dtSystemDate;
        public bool _IsTrue = false;
        public frmSinglePayment(double _DueAmt, string _sProductName, int _nProductID, int _nCustomerID, int _nUIControl, string _sConsumerCode,
            int nPaymentModeID, double _Amount, string sInstrumentNo, DateTime _dtInstrumentDate, int nBankID,
            int nCreditCardType, int nPosMechin, int nCategory, string sApprovalNo, int nIsEMI, int nNoofInstallment, double _BankDiscount, double _ExtendedEMICharge, int nType, DSInvoicePayment oDSInvoicePaymentExptProductSingle,double AmtForBG,int _nFreeEMIID,string sSDApprovalNo)
        {
            InitializeComponent();
            _oDSInvoicePaymentExptProductSingle = oDSInvoicePaymentExptProductSingle;
            nFreeEMIID = _nFreeEMIID;
            _AmtForBG = AmtForBG;
            _oTELLib = new TELLib();
            lblDueAmt.Text = _oTELLib.TakaFormat(_DueAmt);
            _nDueAmt = _DueAmt;
            _UIControl = _nUIControl;
            LoadCombo();
            txtAnount.Text = _oTELLib.TakaFormat(_DueAmt);
            lblProductName.Text = _sProductName;
            _ProductID = _nProductID;
            _CustomerID = _nCustomerID;            
            _ConsumerCode = _sConsumerCode;

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            RetailConsumer oConsumer = new RetailConsumer();
            if (oConsumer.GetConsumerByCode(_ConsumerCode))
            {
                _nConsumerID = oConsumer.ConsumerID;
            }
            if (nType == 2)
            {
                cmbPaymentMode.SelectedIndex = _oPaymentModes.GetIndex(nPaymentModeID);
                txtAnount.Text = _oTELLib.TakaFormat(_Amount);
                txtInstrumentNo.Text = sInstrumentNo.ToString();
                dtInstrumentDate.Value = _dtInstrumentDate.Date;

                if (_oPaymentModes[cmbPaymentMode.SelectedIndex].IsFinancialInstitution == (int)Dictionary.YesOrNoStatus.YES)
                {
                    if (nBankID != -1)
                    {
                        cmbBank.SelectedIndex = _oBanks.GetIndexByID(nBankID) + 1;
                        //cmbCreditCardType.SelectedIndex = nCreditCardType - 1;
                        //cmbPOSMachine.SelectedIndex = _oShowroomAssets.GetIndex(nPosMechin);
                        //cmbCategory.SelectedIndex = nCategory - 1;
                        //txtApprovalNo.Text = sApprovalNo;
                        if (nIsEMI == 1)
                        {
                            chkIsEMI.Checked = true;
                            if (nNoofInstallment != -1)
                            {
                                EMITenure oTenure = new EMITenure();
                                oTenure.Refresh(nNoofInstallment);
                                cmbNoofInstallment.SelectedIndex = _oEMITenures.GetIndex(oTenure.EMITenureID) + 1;
                            }
                        }
                        else
                        {
                            chkIsEMI.Checked = false;
                        }
                        txtBankDiscount.Text = _oTELLib.TakaFormat(_BankDiscount);
                        txtExtendedEMICharge.Text = _oTELLib.TakaFormat(_ExtendedEMICharge);
                        txtSDApprovalNo.Text = sSDApprovalNo.ToString();
                    }
                }
                else
                {

                    if (nBankID != -1)
                    {
                        cmbBank.SelectedIndex = _oBanks.GetIndexByID(nBankID) + 1;
                        cmbCreditCardType.SelectedIndex = nCreditCardType - 1;
                        cmbPOSMachine.SelectedIndex = _oShowroomAssets.GetIndex(nPosMechin);
                        cmbCategory.SelectedIndex = nCategory - 1;
                        txtApprovalNo.Text = sApprovalNo;
                        if (nIsEMI == 1)
                        {
                            chkIsEMI.Checked = true;
                            if (nNoofInstallment != -1)
                            {
                                EMITenure oTenure = new EMITenure();
                                oTenure.Refresh(nNoofInstallment);
                                cmbNoofInstallment.SelectedIndex = _oEMITenures.GetIndex(oTenure.EMITenureID) + 1;
                            }
                        }
                        else
                        {
                            chkIsEMI.Checked = false;
                        }
                        txtBankDiscount.Text = _oTELLib.TakaFormat(_BankDiscount);
                        txtExtendedEMICharge.Text = _oTELLib.TakaFormat(_ExtendedEMICharge);
                        txtSDApprovalNo.Text = sSDApprovalNo.ToString();
                    }
                }

                lblDueAmt.Text = _oTELLib.TakaFormat(Convert.ToDouble(txtAnount.Text) + Convert.ToDouble(txtExtendedEMICharge.Text));
                _nDueAmt = Convert.ToDouble(txtAnount.Text) + Convert.ToDouble(txtExtendedEMICharge.Text);
            }

        }


        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            SystemInfo oInfo = new SystemInfo();
            oInfo.Refresh();
            _dtSystemDate = Convert.ToDateTime(oInfo.OperationDate);
            nWarehousID = oInfo.WarehouseID;

            //Payment Mode
            _oPaymentModes = new PaymentModes();
            _oPaymentModes.RefreshBySalesType(_UIControl);
            cmbPaymentMode.Items.Clear();
            foreach (PaymentMode oPaymentMode in _oPaymentModes)
            {
                cmbPaymentMode.Items.Add(oPaymentMode.PaymentModeName);
            }
            cmbPaymentMode.SelectedIndex = 0;
            
        }
        private void GetEMITenure(int nBankID)
        {
            //GetEMITenure
            _oEMITenures = new EMITenures();
            _oEMITenures.GetEMITenureByBank(nBankID);
            cmbNoofInstallment.Items.Clear();
            cmbNoofInstallment.Items.Add("<Select EMI Tenure>");
            foreach (EMITenure _oEMITenure in _oEMITenures)
            {
                cmbNoofInstallment.Items.Add(_oEMITenure.Tenure.ToString());
            }
            cmbNoofInstallment.SelectedIndex = 0;
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
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CreditCardType)))
            {
                cmbCreditCardType.Items.Add(Enum.GetName(typeof(Dictionary.CreditCardType), GetEnum));
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
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CreditCardCategory)))
            {
                cmbCategory.Items.Add(Enum.GetName(typeof(Dictionary.CreditCardCategory), GetEnum));
            }
            cmbCategory.SelectedIndex = 0;

        }

        private void cmbNoofInstallment_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNetAmount();
        }

        private void GetPaymentModewiseDiscount()
        {
            txtBankDiscount.Text = "0.00";
            _nBankDiscountID = 0;
            _nExtendedEMIChargeID = 0;
            ConsumerPromotionEngine oGetPaymentModewiseDiscount = new ConsumerPromotionEngine();
            txtBankDiscount.Text = _oTELLib.TakaFormat(Math.Round(oGetPaymentModewiseDiscount.GetPaymentModeWiseDiscount(_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID, _ProductID, _dtSystemDate.Date) / (100 - oGetPaymentModewiseDiscount.GetPaymentModeWiseDiscount(_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID, _ProductID, _dtSystemDate.Date)) * Convert.ToDouble(txtAnount.Text), 0, MidpointRounding.AwayFromZero));

            if (Convert.ToDouble(txtBankDiscount.Text) > 0)
            {
                _nBankDiscountID = oGetPaymentModewiseDiscount.BankDiscountID;
                if (oGetPaymentModewiseDiscount.MaxDiscountAmount != 0)
                {
                    if (Convert.ToDouble(txtBankDiscount.Text) > oGetPaymentModewiseDiscount.MaxDiscountAmount)
                    {
                        txtBankDiscount.Text = _oTELLib.TakaFormat(oGetPaymentModewiseDiscount.MaxDiscountAmount);
                    }
                }
            }
            else
            {
                _nBankDiscountID = -1;
            }
            if (Convert.ToDouble(txtBankDiscount.Text) > 0)
            {
                _IsTrueBlanDiscount = false;
            }
            else
            {
                _IsTrueBlanDiscount = true;
            }
        }


        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)

        {
            _oTELLib = new TELLib();
            if (cmbBank.SelectedIndex > 0)
            {
                if (_oBanks[cmbBank.SelectedIndex - 1].IsEMI == 1)
                {
                    chkIsEMI.Enabled = true;
                    chkIsEMI.Checked = false;
                    txtExtendedEMICharge.Text = "0.00";
                    GetEMITenure(_oBanks[cmbBank.SelectedIndex - 1].BankID);
                }
                else
                {
                    chkIsEMI.Enabled = false;
                    chkIsEMI.Checked = false;
                    cmbNoofInstallment.Enabled = false;
                    txtExtendedEMICharge.Enabled = false;
                    cmbNoofInstallment.Items.Clear();
                    cmbNoofInstallment.Items.Add("N/A");
                    cmbNoofInstallment.SelectedIndex = 0;
                    txtExtendedEMICharge.Text = "0.00";

                }
                GetNetAmount();
            }

        }

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _IsTrueBlanDiscount = true;
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
                chkIsEMI.Checked = true;
                chkIsEMI.Enabled = false;
            }
            else
            {
                chkIsEMI.Checked = false;

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

                    cmbNoofInstallment.Items.Clear();
                    cmbNoofInstallment.Items.Add("<N/A>");
                    cmbNoofInstallment.SelectedIndex = 0;

                    txtApprovalNo.Text = "";
                    if (_IsTrueBlanDiscount)
                    {
                        txtBankDiscount.Text = "0.00";
                    }
                    txtExtendedEMICharge.Text = "0.00";

                }
            }
            if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Advance_Payment)
            {
                if (_UIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice || _UIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
                {
                    txtInstrumentNo.Text = _ConsumerCode.ToString();
                }
                else
                {

                }
            }
            else
            {
                txtInstrumentNo.Text = "";
            }
        }

        private void frmSinglePayment_Load(object sender, EventArgs e)
        {

        }

        private void txtInstrumentNo_TextChanged(object sender, EventArgs e)
        {
            //if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
            //{
            //    if (_UIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice || _UIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
            //    {
            //        txtInstrumentNo.Text = _ConsumerCode.ToString();
            //    }
            //    else
            //    {

            //    }
            //}
        }

        private void txtInstrumentNo_Leave(object sender, EventArgs e)
        {
            //if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Advance_Payment)
            //{
            //    if (_UIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
            //    {
            //        if (_ConsumerCode == txtInstrumentNo.Text.Trim())
            //        {
            //            ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();
            //            oConsumerBalanceTran.ConsumerCode = txtInstrumentNo.Text.Trim();
            //            DBController.Instance.OpenNewConnection();
            //            double _balance = oConsumerBalanceTran.GetConsumerBalanceNew();
            //            _nDataID = oConsumerBalanceTran.CustomerID;
            //            _balance = (_balance + _AmtForBG) - GetApprovedAmt(_nDataID);
            //            if (_balance >= Convert.ToDouble(txtAnount.Text))
            //            {

            //            }
            //            else
            //            {
            //                MessageBox.Show("Insufficient consumer balance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                txtAnount.Text = "0.00";
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Please Select Valid Consumer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;

            //        }
            //    }
            //}
            //else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Customer_BG)
            //{
            //    if (_UIControl != (int)Dictionary.SalesType.Dealer)
            //    {
            //        PaymentMode oPaymentMode = new PaymentMode();
            //        double _Balance = oPaymentMode.CheckBGAmount(_CustomerID, _dtSystemDate.Date, Convert.ToDouble(txtAnount.Text));
            //        _nDataID = _CustomerID;
            //        _Balance = (_Balance + Convert.ToDouble(txtAnount.Text) + _AmtForBG) - GetApprovedAmt(_nDataID);
            //        if (_Balance >= Convert.ToDouble(txtAnount.Text))
            //        {

            //        }
            //        else
            //        {
            //            MessageBox.Show("Insufficient customer balance against bank guaranty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            txtAnount.Text = "0.00";
            //            return;
            //        }
            //    }
            //}
            //else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
            //{
            //    CustomerCreditApproval oCCA = new CustomerCreditApproval();
            //    oCCA.RefreshByApprovalNo(txtInstrumentNo.Text);
            //    double _Amount = oCCA.CreditAmount - oCCA.InvoicedAmount;
            //    _nDataID = oCCA.ID;
            //    _Amount = (_Amount + _AmtForBG) - GetApprovedAmt(_nDataID);
            //    if (_Amount >= Convert.ToDouble(txtAnount.Text))
            //    {

            //    }
            //    else
            //    {
            //        MessageBox.Show("Insufficient Credit Balance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtAnount.Text = "0.00";
            //        return;
            //    }

            //}
            //if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Advance_Payment)
            //{
            //    if (_UIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice)
            //    {
            //        if (_ConsumerCode == txtInstrumentNo.Text.Trim())
            //        {
            //            ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();
            //            oConsumerBalanceTran.ConsumerCode = txtInstrumentNo.Text.Trim();
            //            DBController.Instance.OpenNewConnection();
            //            double _balance = oConsumerBalanceTran.GetConsumerBalanceNew();
            //            if (_balance > 0)
            //            {
            //                _oTELLib = new TELLib();
            //                txtAnount.Text = _oTELLib.TakaFormat(_balance);

            //            }
            //            else
            //            {
            //                MessageBox.Show("Insufficient consumer balance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Please Select Valid Consumer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;

            //        }
            //    }
            //}
            //else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
            //{
            //    if (_UIControl == (int)Dictionary.SalesType.B2B || _UIControl == (int)Dictionary.SalesType.Dealer)
            //    {
            //        CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();
            //        double _balance = oCustomerCreditApproval.GetCustomerCreditBalance(txtInstrumentNo.Text.Trim(), _CustomerID);
            //        if (_balance > 0)
            //        {
            //            _oTELLib = new TELLib();
            //            txtAnount.Text = _oTELLib.TakaFormat(_balance);
            //        }
            //        else
            //        {
            //            MessageBox.Show("There is no approved credit amount for this customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //    }
            //}
        }

        private void chkIsEMI_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsEMI.Checked == true)
            {
                cmbNoofInstallment.Enabled = true;
                txtExtendedEMICharge.Enabled = true;
            }
            else
            {
                cmbNoofInstallment.Enabled = false;
                txtExtendedEMICharge.Enabled = false;
                cmbNoofInstallment.SelectedIndex = 0;
                txtExtendedEMICharge.Text = "0.00";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            { 
                DSInvoicePayment oDsInvoicePayment = new DSInvoicePayment();
                DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow =
                    oDsInvoicePayment.InvoicePayment.NewInvoicePaymentRow();
                oInvoicePaymentRow.ProductID = _ProductID;
                oInvoicePaymentRow.ProductName = lblProductName.Text.ToString();
                oInvoicePaymentRow.PaymentModeID = _oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID;
                oInvoicePaymentRow.PaymentModeName = cmbPaymentMode.Text;
                oInvoicePaymentRow.Amount = Convert.ToDouble(txtAnount.Text);


                if (_oPaymentModes[cmbPaymentMode.SelectedIndex].IsFinancialInstitution == (int)Dictionary.YesOrNoStatus.YES)
                {

                    oInvoicePaymentRow.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
                    oInvoicePaymentRow.BankName = cmbBank.Text.ToString();
                    oInvoicePaymentRow.CardType = -1;
                    oInvoicePaymentRow.CardTypeName = "";
                    oInvoicePaymentRow.POSMachineID = -1;
                    oInvoicePaymentRow.POSMachineName = "";
                    oInvoicePaymentRow.CardCategory = -1;
                    oInvoicePaymentRow.CardCategoryName = "";
                    oInvoicePaymentRow.ApprovalNo = "";
                    if (chkIsEMI.Checked == true)
                    {
                        oInvoicePaymentRow.IsEMI = (int)Dictionary.YesOrNoStatus.YES;
                        oInvoicePaymentRow.NoOfInstallment = _oEMITenures[cmbNoofInstallment.SelectedIndex - 1].Tenure;
                        oInvoicePaymentRow.InstrumentNo = txtInstrumentNo.Text;
                        oInvoicePaymentRow.InstrumentDate = dtInstrumentDate.Value.Date;
                        oInvoicePaymentRow.SDApprovalNo = txtSDApprovalNo.Text;
                    }
                    else
                    {
                        oInvoicePaymentRow.IsEMI = (int)Dictionary.YesOrNoStatus.NO;
                        oInvoicePaymentRow.NoOfInstallment = -1;
                        oInvoicePaymentRow.InstrumentNo = txtInstrumentNo.Text;
                        oInvoicePaymentRow.InstrumentDate = dtInstrumentDate.Value.Date;
                        oInvoicePaymentRow.SDApprovalNo = "";
                    }
                    oInvoicePaymentRow.ExtendedEMICharge = Convert.ToDouble(txtExtendedEMICharge.Text);
                    oInvoicePaymentRow.BankDiscount = Convert.ToDouble(txtBankDiscount.Text);
                    oInvoicePaymentRow.BankDiscountID = _nBankDiscountID;
                    oInvoicePaymentRow.ExtendedEMIChargeID = _nExtendedEMIChargeID;

                }
                else
                {

                    if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
                    {
                        oInvoicePaymentRow.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
                        oInvoicePaymentRow.BankName = cmbBank.Text.ToString();
                        oInvoicePaymentRow.CardType = cmbCreditCardType.SelectedIndex + 1;
                        oInvoicePaymentRow.CardTypeName = cmbCreditCardType.Text;
                        oInvoicePaymentRow.POSMachineID = _oShowroomAssets[cmbPOSMachine.SelectedIndex].AssetID;
                        oInvoicePaymentRow.POSMachineName = cmbPOSMachine.Text;
                        oInvoicePaymentRow.CardCategory = cmbCategory.SelectedIndex + 1;
                        oInvoicePaymentRow.CardCategoryName = cmbCategory.Text;
                        oInvoicePaymentRow.ApprovalNo = txtApprovalNo.Text;
                        if (chkIsEMI.Checked == true)
                        {
                            oInvoicePaymentRow.IsEMI = (int)Dictionary.YesOrNoStatus.YES;
                            oInvoicePaymentRow.NoOfInstallment = _oEMITenures[cmbNoofInstallment.SelectedIndex - 1].Tenure;
                            oInvoicePaymentRow.InstrumentNo = txtInstrumentNo.Text;
                            oInvoicePaymentRow.InstrumentDate = dtInstrumentDate.Value.Date;
                            oInvoicePaymentRow.SDApprovalNo = txtSDApprovalNo.Text;
                        }
                        else
                        {
                            oInvoicePaymentRow.IsEMI = (int)Dictionary.YesOrNoStatus.NO;
                            oInvoicePaymentRow.NoOfInstallment = -1;
                            oInvoicePaymentRow.InstrumentNo = txtInstrumentNo.Text;
                            oInvoicePaymentRow.InstrumentDate = dtInstrumentDate.Value.Date;
                            oInvoicePaymentRow.SDApprovalNo = "";
                        }
                        oInvoicePaymentRow.ExtendedEMICharge = Convert.ToDouble(txtExtendedEMICharge.Text);
                        oInvoicePaymentRow.BankDiscount = Convert.ToDouble(txtBankDiscount.Text);

                        oInvoicePaymentRow.BankDiscountID = _nBankDiscountID;
                        oInvoicePaymentRow.ExtendedEMIChargeID = _nExtendedEMIChargeID;


                    }
                    else
                    {
                        oInvoicePaymentRow.BankID = -1;
                        oInvoicePaymentRow.BankName = "";
                        oInvoicePaymentRow.CardType = -1;
                        oInvoicePaymentRow.CardTypeName = "";
                        oInvoicePaymentRow.POSMachineID = -1;
                        oInvoicePaymentRow.POSMachineName = "";
                        oInvoicePaymentRow.CardCategory = -1;
                        oInvoicePaymentRow.CardCategoryName = "";
                        oInvoicePaymentRow.ApprovalNo = "";
                        oInvoicePaymentRow.IsEMI = (int)Dictionary.YesOrNoStatus.NO;
                        oInvoicePaymentRow.NoOfInstallment = -1;
                        oInvoicePaymentRow.InstrumentNo = txtInstrumentNo.Text;
                        oInvoicePaymentRow.InstrumentDate = dtInstrumentDate.Value.Date;
                        oInvoicePaymentRow.ExtendedEMICharge = 0;
                        oInvoicePaymentRow.BankDiscount = Convert.ToDouble(txtBankDiscount.Text); //newly added instead of 0
                        oInvoicePaymentRow.BankDiscountID = _nBankDiscountID; //New Change
                        
                        
                        oInvoicePaymentRow.ExtendedEMIChargeID = -1;
                        oInvoicePaymentRow.SDApprovalNo = "";
                    }

                }

                if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Customer_BG)
                {
                    oInvoicePaymentRow.BGID = _nDataID;
                    oInvoicePaymentRow.CreditApprovalID = -1;
                    oInvoicePaymentRow.AdvancePaymentID = -1;
                }
                else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
                {
                    oInvoicePaymentRow.BGID = -1;
                    oInvoicePaymentRow.CreditApprovalID = _nDataID;
                    oInvoicePaymentRow.AdvancePaymentID = -1;
                }
                else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Advance_Payment)
                {
                    oInvoicePaymentRow.BGID = -1;
                    oInvoicePaymentRow.CreditApprovalID = -1;
                    oInvoicePaymentRow.AdvancePaymentID = _nDataID;
                }
                else
                {
                    oInvoicePaymentRow.BGID = -1;
                    oInvoicePaymentRow.CreditApprovalID = -1;
                    oInvoicePaymentRow.AdvancePaymentID = -1;
                }

                oDsInvoicePayment.InvoicePayment.AddInvoicePaymentRow(oInvoicePaymentRow);
                oDsInvoicePayment.AcceptChanges();
                _IsTrue = true;
                _oDSInvoicePayment = new DSInvoicePayment();
                _oDSInvoicePayment.Merge(oDsInvoicePayment);
                _oDSInvoicePayment.AcceptChanges();
                this.Close();
            }
        }

        public bool ValidateUIInput()
        {

            #region Payment Collection Validation
            DBController.Instance.OpenNewConnection();
            if (Convert.ToDouble(txtAnount.Text) <= 0)
            {
                MessageBox.Show("Amount must be greater than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnount.Focus();
                return false;
            }
            if (_oPaymentModes[cmbPaymentMode.SelectedIndex].IsMandatoryInstrumentNo == (int)Dictionary.YesOrNoStatus.YES)
            {
                if (txtInstrumentNo.Text == "")
                {
                    MessageBox.Show("Please input instrument number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInstrumentNo.Focus();
                    return false;
                }
            }
            if (_oPaymentModes[cmbPaymentMode.SelectedIndex].IsFinancialInstitution == (int)Dictionary.YesOrNoStatus.YES)
            {
                if (cmbBank.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (chkIsEMI.Checked == true)
                {
                    if (cmbNoofInstallment.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please select EMI tenure", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
            {
                if (cmbBank.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (txtApprovalNo.Text == "")
                {
                    MessageBox.Show("Please input Approval Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (chkIsEMI.Checked == true)
                {
                    if (cmbNoofInstallment.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please select EMI tenure", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (txtInstrumentNo.Text == "")
                {
                    MessageBox.Show("Please input instrument number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (txtInstrumentNo.Text.Length != 16)
                {
                    MessageBox.Show("Instrument number must be 16 digits", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Advance_Payment)
            {
                if (_UIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice || _UIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
                {
                    if (_ConsumerCode == txtInstrumentNo.Text.Trim())
                    {
                        ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();
                        oConsumerBalanceTran.ConsumerCode = txtInstrumentNo.Text.Trim();

                        if (!DBController.Instance.CheckConnection())
                        {
                            DBController.Instance.OpenNewConnection();
                        }

                        double _balance = oConsumerBalanceTran.GetConsumerBalanceNew();
                        _nDataID = oConsumerBalanceTran.ConsumerID;
                        _balance = (_balance + _AmtForBG) - GetApprovedAmt(_nDataID);
                        if (_balance >= Convert.ToDouble(txtAnount.Text))
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Insufficient consumer balance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtAnount.Text = "0.00";
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Valid Consumer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;

                    }
                }
                else
                {
                    ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();
                    oConsumerBalanceTran.ConsumerCode = txtInstrumentNo.Text.Trim();

                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }


                    double _balance = oConsumerBalanceTran.GetConsumerBalanceNewOther(_CustomerID);
                    _nDataID = oConsumerBalanceTran.ConsumerID;
                    _balance = (_balance + _AmtForBG) - GetApprovedAmt(_nDataID);
                    if (_balance >= Convert.ToDouble(txtAnount.Text))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Insufficient consumer balance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAnount.Text = "0.00";
                        return false;
                    }
                }
                //else
                //{
                //    MessageBox.Show("Advance payment only eligible for retail invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
            }
            else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Customer_BG)
            {
                if (_UIControl != (int)Dictionary.SalesType.Dealer)
                {
                    MessageBox.Show("Credit facility is not eligible for this invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    PaymentMode oPaymentMode = new PaymentMode();
                    double _Balance = oPaymentMode.CheckBGAmount(_CustomerID, _dtSystemDate.Date, Convert.ToDouble(txtAnount.Text));
                    _nDataID = _CustomerID;
                    _Balance = (_Balance + Convert.ToDouble(txtAnount.Text) + _AmtForBG) - GetApprovedAmt(_nDataID);
                    if (_Balance >= Convert.ToDouble(txtAnount.Text))
                    {
                        return true;
                    }
                    else
                    {
                        // MessageBox.Show("Insufficient customer balance against bank guaranty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageBox.Show("Insufficient credit balance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAnount.Text = "0.00";
                        return false;
                    }
                }
            }

            else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
            {
                if (_UIControl == (int)Dictionary.SalesType.Dealer || _UIControl == (int)Dictionary.SalesType.B2B || _UIControl == (int)Dictionary.SalesType.B2C)
                {
                    CustomerCreditApproval oCCA = new CustomerCreditApproval();
                    //oCCA.RefreshByApprovalNo(txtInstrumentNo.Text);
                    oCCA.RefreshByApprovalNoByCustID(txtInstrumentNo.Text, _CustomerID);

                    double _Amount = oCCA.CreditAmount - oCCA.InvoicedAmount;
                    _nDataID = oCCA.ID;
                    _Amount = (_Amount + _AmtForBG) - GetApprovedAmt(_nDataID);
                    if (_Amount >= Convert.ToDouble(txtAnount.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Insufficient Credit Balance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAnount.Text = "0.00";
                        return false;
                    }
                }
                else
                {
                    CustomerCreditApproval oCCA = new CustomerCreditApproval();
                    oCCA.RefreshByApprovalNoByConsumerID(txtInstrumentNo.Text, _CustomerID, _nConsumerID, _UIControl);
                    double _Amount = oCCA.CreditAmount - oCCA.InvoicedAmount;
                    _nDataID = oCCA.ID;
                    _Amount = (_Amount + _AmtForBG) - GetApprovedAmt(_nDataID);
                    if (_Amount >= Convert.ToDouble(txtAnount.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Insufficient Credit Balance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAnount.Text = "0.00";
                        return false;
                    }
                }
            }
            

            #endregion
            
            return true;
        }
        

        private void txtAnount_TextChanged(object sender, EventArgs e)
        {
            if (txtAnount.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtAnount.Text);
                    GetNetAmount();

                }
                catch
                {
                    MessageBox.Show("Please Input Valid Amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAnount.Text = "";
                }

            }
        }

        private void txtBankDiscount_TextChanged(object sender, EventArgs e)
        {
            _oTELLib = new TELLib();
            lblDueAmt.Text = _oTELLib.TakaFormat(_nDueAmt - Convert.ToDouble(txtBankDiscount.Text) + Convert.ToDouble(txtExtendedEMICharge.Text));
        }

        private void txtExtendedEMICharge_TextChanged(object sender, EventArgs e)
        {

        }
        private void GetNetAmount()

        {
            _oTELLib = new TELLib();
            if (cmbBank.SelectedIndex > 0)
            {
                txtBankDiscount.Text = @"0.00";
                _nBankDiscountID = 0;
                _nExtendedEMIChargeID = 0;
                ConsumerPromotionEngine oGetBenkDiscount = new ConsumerPromotionEngine();
                txtBankDiscount.Text =
                    _oTELLib.TakaFormat(
                        Math.Round(
                            oGetBenkDiscount.GetBankDiscount(_oBanks[cmbBank.SelectedIndex - 1].BankID, _ProductID,
                                _dtSystemDate.Date, cmbCreditCardType.SelectedIndex + 1)/
                            (100 -
                             oGetBenkDiscount.GetBankDiscount(_oBanks[cmbBank.SelectedIndex - 1].BankID, _ProductID,
                                 _dtSystemDate.Date, cmbCreditCardType.SelectedIndex + 1))*
                            Convert.ToDouble(txtAnount.Text), 0, MidpointRounding.AwayFromZero));
                // txtBankDiscount.Text = _oTELLib.TakaFormat(Math.Round(oGetBenkDiscount.GetBankDiscount(_oBanks[cmbBank.SelectedIndex - 1].BankID, _ProductID, _dtSystemDate.Date) / 100 * Convert.ToDouble(txtAnount.Text), 0, MidpointRounding.AwayFromZero));
                if (Convert.ToDouble(txtBankDiscount.Text) > 0)
                {
                    _nBankDiscountID = oGetBenkDiscount.BankDiscountID;

                    //New
                    if (oGetBenkDiscount.MaxDiscountAmount != 0)
                    {
                        if (Convert.ToDouble(txtBankDiscount.Text) > oGetBenkDiscount.MaxDiscountAmount)
                        {
                            txtBankDiscount.Text = _oTELLib.TakaFormat(oGetBenkDiscount.MaxDiscountAmount);
                        }
                    }

                    //if (oGetBenkDiscount.CardType > 0)
                    //{
                    //    if (cmbCreditCardType.SelectedIndex + 1 != oGetBenkDiscount.CardType)
                    //    {
                    //        txtBankDiscount.Text = @"0.00";
                    //    }
                    //}
                    //End New
                }
                else
                {
                    _nBankDiscountID = -1;
                }
                if (cmbNoofInstallment.SelectedIndex > 0)
                {
                    if (_oBanks[cmbBank.SelectedIndex - 1].IsEMI == (int)Dictionary.YesOrNoStatus.YES)
                    {

                        ConsumerPromotionEngine oGetExtendedCharge = new ConsumerPromotionEngine();
                        //double _ExtendedEMIPercent = oGetExtendedCharge.GetExtendedEMIChargeForInvoice(_oEMITenures[cmbNoofInstallment.SelectedIndex - 1].EMITenureID, _dtSystemDate.Date.ToString("dd-MMM-yyyy"), _ProductID, nFreeEMIID);
                        double _ExtendedEMIPercent = 0;
                        if (_oPaymentModes[cmbPaymentMode.SelectedIndex].IsFinancialInstitution == (int)Dictionary.YesOrNoStatus.YES)
                        {
                            _ExtendedEMIPercent = oGetExtendedCharge.GetExtendedEMIChargeForInvoiceFI(_oEMITenures[cmbNoofInstallment.SelectedIndex - 1].EMITenureID, _dtSystemDate.Date.ToString("dd-MMM-yyyy"), _ProductID, nFreeEMIID, nWarehousID, _UIControl, txtSDApprovalNo.Text.Trim(), _CustomerID, _nConsumerID, _oBanks[cmbBank.SelectedIndex - 1].BankID);
                        }
                        else
                        {
                            _ExtendedEMIPercent = oGetExtendedCharge.GetExtendedEMIChargeForInvoiceNew(_oEMITenures[cmbNoofInstallment.SelectedIndex - 1].EMITenureID, _dtSystemDate.Date.ToString("dd-MMM-yyyy"), _ProductID, nFreeEMIID, nWarehousID, _UIControl, txtSDApprovalNo.Text.Trim(), _CustomerID, _nConsumerID);
                        }
                        txtExtendedEMICharge.Text = _oTELLib.TakaFormat(Math.Round(Convert.ToDouble(txtAnount.Text) * _ExtendedEMIPercent / 100, 0, MidpointRounding.AwayFromZero));

                        if (Convert.ToDouble(txtExtendedEMICharge.Text) > 0)
                        {
                            if (_oPaymentModes[cmbPaymentMode.SelectedIndex].IsFinancialInstitution == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                _nExtendedEMIChargeID = oGetExtendedCharge.GetExtendedEMIChargeIDFI(_oEMITenures[cmbNoofInstallment.SelectedIndex - 1].EMITenureID, _oBanks[cmbBank.SelectedIndex - 1].BankID);
                            }
                            else
                            {
                                _nExtendedEMIChargeID = oGetExtendedCharge.GetExtendedEMIChargeID(_oEMITenures[cmbNoofInstallment.SelectedIndex - 1].EMITenureID);
                            }
                        }
                        else
                        {
                            _nExtendedEMIChargeID = -1;
                        }
                        lblDueAmt.Text = _oTELLib.TakaFormat(_nDueAmt + Convert.ToDouble(txtExtendedEMICharge.Text));
                    }
                }
                else
                {
                    txtExtendedEMICharge.Text = "0.00";
                    lblDueAmt.Text = _oTELLib.TakaFormat(_nDueAmt);
                    _nExtendedEMIChargeID = -1;
                }
            }
            if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID != (int)Dictionary.PaymentMode.Credit_Card)
            {
                GetPaymentModewiseDiscount();
            }
            lblDueAmt.Text = _oTELLib.TakaFormat(_nDueAmt - Convert.ToDouble(txtBankDiscount.Text) + Convert.ToDouble(txtExtendedEMICharge.Text));

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public double GetApprovedAmt(int dataId)
        {
            double amount = 0;

            foreach (DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow in _oDSInvoicePaymentExptProductSingle.InvoicePayment)
            {
                if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Advance_Payment)
                {
                    if (oInvoicePaymentRow.AdvancePaymentID == dataId)
                        amount = amount + oInvoicePaymentRow.Amount;
                }
                else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Customer_BG)
                {
                    if (oInvoicePaymentRow.BGID == dataId)
                        amount = amount + oInvoicePaymentRow.Amount;
                }
                else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
                {
                    if (oInvoicePaymentRow.CreditApprovalID == dataId)
                        amount = amount + oInvoicePaymentRow.Amount;
                }
            }

            return amount;
        }

        public double GetBankDiscountValidation(int nProductId)
        {
            double bankDiscountAmount = 0;

            foreach (DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow in _oDSInvoicePaymentExptProductSingle.InvoicePayment)
            {
                if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Advance_Payment)
                {
                    if (oInvoicePaymentRow.AdvancePaymentID == nProductId)
                        bankDiscountAmount = bankDiscountAmount + oInvoicePaymentRow.Amount;
                }
                else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Customer_BG)
                {
                    if (oInvoicePaymentRow.BGID == nProductId)
                        bankDiscountAmount = bankDiscountAmount + oInvoicePaymentRow.Amount;
                }
                else if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
                {
                    if (oInvoicePaymentRow.CreditApprovalID == nProductId)
                        bankDiscountAmount = bankDiscountAmount + oInvoicePaymentRow.Amount;
                }
            }

            return bankDiscountAmount;
        }
        private void lblCpopy_Click(object sender, EventArgs e)
        {

            int _nIsEMI = 0;
            int _nNoofInstallment = 0;
            int _BankID = 0;
            int _CardType = 0;
            int _POSMachinID = 0;
            int _Category = 0;

            if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
            {

                try
                {
                    _BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
                }
                catch
                {
                    _BankID = 0;

                }

                try
                {
                    _CardType = (cmbCreditCardType.SelectedIndex + 1);
                }
                catch
                {
                    _CardType = 0;
                }
                try
                {
                    _POSMachinID = _oShowroomAssets[cmbPOSMachine.SelectedIndex].AssetID;
                }
                catch
                {
                    _POSMachinID = 0;
                }
                try
                {
                    _Category = cmbCategory.SelectedIndex + 1;
                }
                catch
                {
                    _Category = 0;
                }

                if (chkIsEMI.Checked == true)
                {
                    _nIsEMI = 1;
                    _nNoofInstallment = _oEMITenures[cmbNoofInstallment.SelectedIndex - 1].Tenure;

                }
                else
                {
                    _nIsEMI = 0;
                    _nNoofInstallment = 0;
                }
            }

            Payment oPayment = new Payment()
            {
                InstrumentNo = txtInstrumentNo.Text,
                PaymentModeId = _oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID.ToString(),
                InstrumentDate = dtInstrumentDate.Value.Date.ToString("dd-MMM-yyyy"),
                BankId = _BankID.ToString(),
                CardType = _CardType.ToString(),
                PosMachinId = _POSMachinID.ToString(),
                Category = _Category.ToString(),
                ApprovalNo = txtApprovalNo.Text,
                IsEmi = _nIsEMI.ToString(),
                NoofInstallment = _nNoofInstallment.ToString(),
            };
            Clipboard.SetDataObject(oPayment);
        }    
        

        [Serializable()]
        class Payment
        {
            
            public string InstrumentNo;
            public string PaymentModeId;
            public string InstrumentDate;
            public string BankId;
            public string CardType;
            public string PosMachinId;
            public string Category;
            public string ApprovalNo;
            public string IsEmi;
            public string NoofInstallment;

        }

        private void lblPaste_Click(object sender, EventArgs e)
        {
            IDataObject data_object = Clipboard.GetDataObject();
            //Payment oPayment = (Payment)data_object.GetData(typeof(Payment).FullName);
            //txtInstrumentNo.Text = oPayment.InstrumentNo;
            //txtApprovalNo.Text = oPayment.ApprovalNo;

            if (data_object.GetDataPresent(typeof(Payment).FullName))
            {
                Payment oPayment = (Payment)data_object.GetData(typeof(Payment).FullName);


                cmbPaymentMode.SelectedIndex = _oPaymentModes.GetIndex(Convert.ToInt32(oPayment.PaymentModeId));
                txtInstrumentNo.Text = oPayment.InstrumentNo;
                dtInstrumentDate.Value = Convert.ToDateTime(oPayment.InstrumentDate);
                if (Convert.ToInt32(oPayment.BankId) != 0)
                {
                    
                    cmbBank.SelectedIndex = _oBanks.GetIndexByID(Convert.ToInt32(oPayment.BankId)) + 1;
                    try
                    {
                        cmbCreditCardType.SelectedIndex = Convert.ToInt32(oPayment.CardType) - 1;
                    }
                    catch
                    {
                        cmbCreditCardType.SelectedIndex = 0;
                    }
                    try
                    {
                        cmbPOSMachine.SelectedIndex = _oShowroomAssets.GetIndex(Convert.ToInt32(oPayment.PosMachinId));
                    }
                    catch
                    {
                        cmbPOSMachine.SelectedIndex = 0;
                    }
                    try
                    {
                        cmbCategory.SelectedIndex = Convert.ToInt32(oPayment.Category) - 1;
                    }
                    catch
                    {
                        cmbCategory.SelectedIndex = 0;
                    }
                    txtApprovalNo.Text = oPayment.ApprovalNo;

                    if (Convert.ToInt32(oPayment.IsEmi) == 1)
                    {
                        chkIsEMI.Checked = true;
                        if (Convert.ToInt32(oPayment.NoofInstallment) != 0)
                        {
                            EMITenure oTenure = new EMITenure();
                            oTenure.Refresh(Convert.ToInt32(oPayment.NoofInstallment));
                            cmbNoofInstallment.SelectedIndex = _oEMITenures.GetIndex(oTenure.EMITenureID) + 1;
                        }
                    }
                    else
                    {
                        chkIsEMI.Checked = false;
                    }
                }

            }
            else
            {
                txtApprovalNo.Clear();
                txtInstrumentNo.Clear();
            }
        }

        private void txtSDApprovalNo_TextChanged(object sender, EventArgs e)
        {
            GetNetAmount();
        }

        private void cmbCreditCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNetAmount();
        }
    }
}

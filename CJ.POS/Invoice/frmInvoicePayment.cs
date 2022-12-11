using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Win.Control;
//using RSMS.BaseItems;

namespace CJ.POS.Invoice
{
    public partial class frmInvoicePayment : Form
    {
        int _OfferType = 0;
        bool _IsActiveSCDiscount = false;
        int nFreeEMIID =0;
        int nIndexRaw = 0;
        int _PaymentModeID = 0;
        double _Amount = 0;
        int _BankID = 0;
        int _CardType = 0;
        int _POSMachineID = 0;
        int _CardCategory = 0;
        string _sApprovalNo = "";
        int _IsEMI = 0;
        int _NoOfInstallment = 0;
        string _sInstrumentNo = "";
        DateTime _dtInstrumentDate = DateTime.Now.Date;
        double _ExtendedEMICharge = 0;
        double _BankDiscount = 0;
        double _B2BDiscount = 0;
        double _B2CDiscount = 0;
        double _DealerDiscount = 0;
        string _sSDApprovalNo = "";
        double _DealerMargin = 0;

        public DSSalesInvoiceDiscount oDsSalesInvoiceDiscount;
        
        public bool _IsTrueInvoiceDiscount = false;
        public bool _IsTrue = false;
        PaymentModes _oPaymentModes;
        double _dPaymentTotal = 0;
        double _dDueAmount = 0;
        double _TotalDiscount = 0;
        SystemInfo oSystemInfo;
        TELLib oTELLib;
        DiscountReasons _oDiscountReasons;
        string sApprove_Credit_No = "";

        public DSInvoicePayment oDSInvoicePayment;
        DSInvoicePayment oDSInvoicePaymentExptProduct;
        
        //public double _nInstallationCharge = 0;
        //public double _nOtherCharge = 0;
        //public double _nFrightCharge = 0;

        public double _AdditionalDiscount = 0;
        public double _AdditionalCharge = 0;

        public double _nCollection = 0;
        public double _nSMS = 0;
        public string _sSMSCode = "";
        public string _sSMSDescription = "";

        public int _nDiscountReasonID = 0;
        public string _sDiscountReason = "";
        public double _SPPercentage = 0;
        public double _FlatAmount = 0;
        public double _SPPercentageAmount = 0;
        public double _TotalDiscountAfter = 0;
        public double _TotalCollectionAfter = 0;
        public double _TotalPayableAfter = 0;
        public double _TotalDueAfter = 0;

        int _nProductID = 0;
        int _nCustomerID = 0;
        int _nUIControl = 0;
        private string _sProductName = "";
        private string _sConsumerCode = "";
        private double _CPDiscount = 0;
        private double _TPDiscount = 0;
        private double _TotalRsAmount = 0;
        public bool _IsApplicableB2BDiscountPayment;
        bool _bIsApplicableB2BDiscount = false;
        int _nInvoiceQty = 0;
        bool _bPromoExchangeOffer = false;
        public frmInvoicePayment(int nProductiD, string sProductName, int nCustomeriD, string sConsumercode,
            double CPDiscount, int nUicontrol, double totalRSamount, DSSalesInvoiceDiscount oSingleDiscount, double _AdditionalDis, double _TotalCharge, double _CollectionAmt, DSInvoicePayment _oDSInvoicePayment, bool _IsApplicableB2BDiscountInv, double TPDiscount, DSInvoicePayment _oDSExptProductID,int _FreeEMIID, bool bIsApplicableB2BDiscount,int nInvoiceQty)
        {
            InitializeComponent();
            _nInvoiceQty = nInvoiceQty;
            nFreeEMIID = _FreeEMIID;
            _nProductID = nProductiD;
            _sProductName = sProductName;
            _nCustomerID = nCustomeriD;
            _sConsumerCode = sConsumercode;
            _CPDiscount = CPDiscount;
            _TPDiscount = TPDiscount;
            _nUIControl = nUicontrol;
            _TotalRsAmount = totalRSamount;
            oDSInvoicePaymentExptProduct = _oDSExptProductID;
            oDSInvoicePayment = _oDSInvoicePayment;
            oDsSalesInvoiceDiscount = oSingleDiscount;
            txtAdditionalDiscount.Text = _AdditionalDis.ToString();
            txtCollectionAmount.Text = _CollectionAmt.ToString();
            txtTotalCharge.Text = _TotalCharge.ToString();

            _bIsApplicableB2BDiscount = bIsApplicableB2BDiscount;

            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();


            ConsumerPromotionEngine oExchangeOffer = new ConsumerPromotionEngine();
            _bPromoExchangeOffer = oExchangeOffer.GetExchangeOfferPromo(Convert.ToDateTime(oSystemInfo.OperationDate),
                oSystemInfo.WarehouseID,
                _nProductID);

            if (_nUIControl == (int)Dictionary.SalesType.B2B)
            {
                _IsApplicableB2BDiscountPayment = _IsApplicableB2BDiscountInv;
                //if (_IsApplicableB2BDiscountPayment == true)
                //{
                //    if (!_bIsApplicableB2BDiscount)
                //    { 
                //        GetB2BDiscount();
                //    }
                //}
                if (!_bIsApplicableB2BDiscount)
                {
                   GetB2BDiscount();
                }
                   
            }
            if (_nUIControl == (int)Dictionary.SalesType.B2C)
            {
                GetB2CDealerDiscount();
            }
            if (_nUIControl == (int)Dictionary.SalesType.Dealer)
            {
                GetB2CDealerDiscount();
            }


            ConsumerPromotionEngine oScretchCardOffer = new ConsumerPromotionEngine();
            if (oScretchCardOffer.GetScretchCardOfferCustomerType(Convert.ToDateTime(oSystemInfo.OperationDate), oSystemInfo.WarehouseID, nProductiD, nUicontrol, nCustomeriD))
            {
                //OfferTypeSC
                _OfferType = oScretchCardOffer.OfferType;
                _IsActiveSCDiscount = true;
            }
            else
            {
                _IsActiveSCDiscount = false;
            }
        }



        //public void ShowDialog(DSInvoicePayment oSinglePayment)
        //{
        //    this.Tag = oSinglePayment;

        //    if (oSinglePayment.InvoicePayment.Count != 0)
        //    {

        //    }
        //    this.ShowDialog();
        //}

        private void frmInvoicePayment_Load(object sender, EventArgs e)
        {

            oTELLib = new TELLib();
            lblProductName.Text = _sProductName;
            txtPromoDisount.Text = oTELLib.TakaFormat(_CPDiscount + _TPDiscount);
            txtTotal.Text = oTELLib.TakaFormat(_TotalRsAmount);
            LoadData();
            GetTotalAmount();
        }

        public void LoadData() 
        {

            foreach (
            DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow in
                oDSInvoicePayment.InvoicePayment)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvInvoicePayment);
                oRow.Cells[0].Value = oInvoicePaymentRow.PaymentModeName.ToString();
                oRow.Cells[1].Value = oInvoicePaymentRow.Amount.ToString();
                oRow.Cells[9].Value = oInvoicePaymentRow.InstrumentNo.ToString();
                oRow.Cells[10].Value = oInvoicePaymentRow.InstrumentDate.ToString();
                oRow.Cells[11].Value = oInvoicePaymentRow.PaymentModeID.ToString();

                if (oInvoicePaymentRow.PaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
                {

                    oRow.Cells[2].Value = oInvoicePaymentRow.BankName.ToString();
                    oRow.Cells[3].Value = oInvoicePaymentRow.CardTypeName.ToString();
                    oRow.Cells[4].Value = oInvoicePaymentRow.POSMachineName.ToString();
                    oRow.Cells[5].Value = oInvoicePaymentRow.CardCategoryName.ToString();
                    oRow.Cells[6].Value = oInvoicePaymentRow.ApprovalNo.ToString();
                    oRow.Cells[7].Value = Enum.GetName(typeof(Dictionary.YesOrNoStatus), oInvoicePaymentRow.IsEMI);
                    oRow.Cells[8].Value = oInvoicePaymentRow.NoOfInstallment.ToString();
                    oRow.Cells[12].Value = oInvoicePaymentRow.BankID.ToString();
                    oRow.Cells[13].Value = oInvoicePaymentRow.CardType.ToString();
                    oRow.Cells[14].Value = oInvoicePaymentRow.POSMachineID.ToString();
                    oRow.Cells[15].Value = oInvoicePaymentRow.CardCategory.ToString();
                    oRow.Cells[16].Value = oInvoicePaymentRow.ExtendedEMICharge.ToString();
                    oRow.Cells[17].Value = oInvoicePaymentRow.BankDiscount.ToString();
                }
                else
                {
                    try
                    {
                        oRow.Cells[2].Value = oInvoicePaymentRow.BankName.ToString();
                    }
                    catch 
                    {
                        oRow.Cells[2].Value = "";
                    }

                    try
                    {
                        oRow.Cells[3].Value = oInvoicePaymentRow.CardTypeName.ToString();
                    }
                    catch 
                    {
                        oRow.Cells[3].Value = "";
                    }

                    try
                    {
                        oRow.Cells[4].Value = oInvoicePaymentRow.POSMachineName.ToString();
                    }
                    catch 
                    {
                        oRow.Cells[4].Value = "";
                    }

                    try
                    {
                        oRow.Cells[5].Value = oInvoicePaymentRow.CardCategoryName.ToString();
                    }
                    catch
                    {
                        oRow.Cells[5].Value = "";
                    }

                    try
                    {
                        oRow.Cells[6].Value = oInvoicePaymentRow.ApprovalNo.ToString();
                    }
                    catch 
                    {
                        oRow.Cells[6].Value = "";
                    }
                    try
                    {
                        oRow.Cells[7].Value = Enum.GetName(typeof(Dictionary.YesOrNoStatus), oInvoicePaymentRow.IsEMI);
                    }
                    catch
                    {

                        oRow.Cells[7].Value = "";
                    }
                    try
                    {
                        oRow.Cells[8].Value = oInvoicePaymentRow.NoOfInstallment.ToString();
                    }
                    catch
                    {
                        oRow.Cells[8].Value = "";
                    }
                    try
                    {
                        oRow.Cells[12].Value = oInvoicePaymentRow.BankID.ToString();
                    }
                    catch
                    {
                        oRow.Cells[12].Value = "";
                    }
                    try
                    {
                        oRow.Cells[13].Value = oInvoicePaymentRow.CardType.ToString();
                    }
                    catch
                    {
                        oRow.Cells[13].Value = "";
                    }
                    try
                    {
                        oRow.Cells[14].Value = oInvoicePaymentRow.POSMachineID.ToString();
                    }
                    catch
                    {
                        oRow.Cells[14].Value = "";
                    }
                    try
                    {
                        oRow.Cells[15].Value = oInvoicePaymentRow.CardCategory.ToString();
                    }
                    catch
                    {
                        oRow.Cells[15].Value = "";
                    }
                    try
                    {
                        oRow.Cells[16].Value = oInvoicePaymentRow.ExtendedEMICharge.ToString();
                    }
                    catch
                    {
                        oRow.Cells[16].Value = 0;
                    }
                    
                    try
                    {
                        oRow.Cells[17].Value = oInvoicePaymentRow.BankDiscount.ToString(); //NEWLY  added instead of 0
                    }
                    catch
                    {
                        oRow.Cells[17].Value = 0;
                    }

                }

                oRow.Cells[19].Value = oInvoicePaymentRow.BGID.ToString();
                oRow.Cells[20].Value = oInvoicePaymentRow.CreditApprovalID.ToString();
                oRow.Cells[21].Value = oInvoicePaymentRow.AdvancePaymentID.ToString();

                oRow.Cells[22].Value = oInvoicePaymentRow.BankDiscountID.ToString();
                oRow.Cells[23].Value = oInvoicePaymentRow.ExtendedEMIChargeID.ToString();
                oRow.Cells[24].Value = oInvoicePaymentRow.SDApprovalNo.ToString();

                dgvInvoicePayment.Rows.Add(oRow);
            }

        }


        public bool ValidateUIInput()
        {
            #region Payment Collection Validation
            if (dgvInvoicePayment.Rows.Count == 0)
            {
                MessageBox.Show("Please Input Payment Collection ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (DataGridViewRow oItemRow in dgvInvoicePayment.Rows)
            {
                if (oItemRow.Index < dgvInvoicePayment.Rows.Count)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Payment Mode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        if (oItemRow.Cells[1].Value != null)
                        {
                            try
                            {
                                double tmp = Convert.ToDouble(oItemRow.Cells[1].Value);
                            }
                            catch
                            {
                                MessageBox.Show("Please Input valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please Input Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }

                }
            }

            double _Total = 0;
            int nPMCashCount = 0;
            int nPMAdvancePaymentCount = 0;
            int nPMEPSCount = 0;
            int nPMCustomerBG = 0;
            foreach (DataGridViewRow oItemRow in dgvInvoicePayment.Rows)
            {
                if (oItemRow.Index < dgvInvoicePayment.Rows.Count)
                {
                    if (Convert.ToUInt32(oItemRow.Cells[11].Value) == (int)Dictionary.PaymentMode.Cash)
                    {
                        nPMCashCount++;
                    }
                    if (Convert.ToUInt32(oItemRow.Cells[11].Value) == (int)Dictionary.PaymentMode.Advance_Payment)
                    {
                        nPMAdvancePaymentCount++;
                    }
                    if (Convert.ToUInt32(oItemRow.Cells[11].Value) == (int)Dictionary.PaymentMode.EPS)
                    {
                        nPMEPSCount++;
                    }

                    if (Convert.ToUInt32(oItemRow.Cells[11].Value) == (int)Dictionary.PaymentMode.Customer_BG)
                    {
                        nPMCustomerBG++;
                    }

                    try
                    {
                        _Total = _Total + Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            if (nPMCashCount > 1)
            {
                MessageBox.Show("Payment Mode 'Cash Duplicate'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (nPMAdvancePaymentCount > 1)
            {
                MessageBox.Show("Payment Mode 'Advance Payment' Duplicate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (nPMEPSCount > 1)
            {
                MessageBox.Show("Payment Amount 'EPS' Duplicate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (nPMCustomerBG > 1)
            {
                MessageBox.Show("Payment Amount 'Customer Bank Guaranty' Duplicate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_Total <= 0)
            {
                MessageBox.Show("Payment Amount should be positive or grether than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_Total != Convert.ToDouble(txtNetPay.Text))
            {
                MessageBox.Show("Payment Amount and Net Amount Must Be Same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            #endregion
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            _IsTrue = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                oDSInvoicePayment = new DSInvoicePayment();

                foreach (DataGridViewRow oItemRow in dgvInvoicePayment.Rows)
                {

                    if (oItemRow.Index < dgvInvoicePayment.Rows.Count)
                    {
                        DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow =
                            oDSInvoicePayment.InvoicePayment.NewInvoicePaymentRow();
                        oInvoicePaymentRow.ProductID = _nProductID;
                        oInvoicePaymentRow.ProductName = lblProductName.Text.ToString();
                        oInvoicePaymentRow.PaymentModeID = int.Parse(oItemRow.Cells[11].Value.ToString());
                        oInvoicePaymentRow.PaymentModeName = oItemRow.Cells[0].Value.ToString();
                        oInvoicePaymentRow.Amount = Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
                        try
                        {
                            oInvoicePaymentRow.BankID = int.Parse(oItemRow.Cells[12].Value.ToString());
                            oInvoicePaymentRow.BankName = oItemRow.Cells[2].Value.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.BankID = -1;
                            oInvoicePaymentRow.BankName = "";
                        }
                        try
                        {
                            oInvoicePaymentRow.CardType = int.Parse(oItemRow.Cells[13].Value.ToString());
                            oInvoicePaymentRow.CardTypeName = oItemRow.Cells[3].Value.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.CardType = -1;
                            oInvoicePaymentRow.CardTypeName = "";
                        }
                        try
                        {
                            oInvoicePaymentRow.POSMachineID = int.Parse(oItemRow.Cells[14].Value.ToString());
                            oInvoicePaymentRow.POSMachineName = oItemRow.Cells[4].Value.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.POSMachineID = -1;
                            oInvoicePaymentRow.POSMachineName = "";
                        }

                        try
                        {
                            oInvoicePaymentRow.CardCategory = int.Parse(oItemRow.Cells[15].Value.ToString());
                            oInvoicePaymentRow.CardCategoryName = oItemRow.Cells[5].Value.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.CardCategory = -1;
                            oInvoicePaymentRow.CardCategoryName = "";
                        }
                        try
                        {
                            oInvoicePaymentRow.ApprovalNo = oItemRow.Cells[6].Value.ToString().Trim();
                        }
                        catch
                        {
                            oInvoicePaymentRow.ApprovalNo = "";

                        }
                        try
                        {
                            if (oItemRow.Cells[7].Value.ToString() == "YES")
                            {
                                oInvoicePaymentRow.IsEMI = 1;

                            }
                            else
                            {
                                oInvoicePaymentRow.IsEMI = 0;
                            }

                        }
                        catch
                        {
                            oInvoicePaymentRow.IsEMI = 0;
                        }
                        try
                        {
                            oInvoicePaymentRow.NoOfInstallment = int.Parse(oItemRow.Cells[8].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.NoOfInstallment = -1;
                        }
                        try
                        {
                            oInvoicePaymentRow.InstrumentNo = oItemRow.Cells[9].Value.ToString().Trim();
                        }
                        catch
                        {
                            oInvoicePaymentRow.InstrumentNo = "";
                        }

                        try
                        {
                            oInvoicePaymentRow.InstrumentDate =
                                Convert.ToDateTime(oItemRow.Cells[10].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.InstrumentDate = DateTime.Now.Date;
                        }
                        try
                        {
                            oInvoicePaymentRow.ExtendedEMICharge = Convert.ToDouble(oItemRow.Cells[16].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.ExtendedEMICharge = 0;
                        }
                        try
                        {
                            oInvoicePaymentRow.BankDiscount = Convert.ToDouble(oItemRow.Cells[17].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.BankDiscount = 0;
                        }
                        try
                        {
                            oInvoicePaymentRow.BGID = Convert.ToInt32(oItemRow.Cells[19].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.BGID = -1;
                        }
                        try
                        {
                            oInvoicePaymentRow.CreditApprovalID = Convert.ToInt32(oItemRow.Cells[20].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.CreditApprovalID = -1;
                        }
                        try
                        {
                            oInvoicePaymentRow.AdvancePaymentID = Convert.ToInt32(oItemRow.Cells[21].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.AdvancePaymentID = -1;
                        }

                        try
                        {
                            oInvoicePaymentRow.BankDiscountID = Convert.ToInt32(oItemRow.Cells[22].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.BankDiscountID = -1;
                        }

                        try
                        {
                            oInvoicePaymentRow.ExtendedEMIChargeID = Convert.ToInt32(oItemRow.Cells[23].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.ExtendedEMIChargeID = -1;
                        }

                        try
                        {
                            oInvoicePaymentRow.SDApprovalNo = (oItemRow.Cells[24].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.SDApprovalNo = "";
                        }

                        oDSInvoicePayment.InvoicePayment.AddInvoicePaymentRow(oInvoicePaymentRow);
                        oDSInvoicePayment.AcceptChanges();
                    }
                }

                _AdditionalCharge = Convert.ToDouble(txtTotalCharge.Text);
                _nCollection = Convert.ToDouble(txtCollectionAmount.Text);
                _AdditionalDiscount = Convert.ToDouble(txtAdditionalDiscount.Text);

                try
                {
                    _TotalDiscountAfter = Convert.ToDouble(txtTotalDisount.Text);
                }
                catch
                {
                    _TotalDiscountAfter = 0;
                }
                try
                {
                    _TotalPayableAfter = Convert.ToDouble(txtNetPay.Text);
                }
                catch
                {
                    _TotalPayableAfter = 0;
                }
                try
                {
                    _TotalDueAfter = Convert.ToDouble(txtDueAmount.Text);
                }
                catch
                {
                    _TotalDueAfter = 0;
                }
                try
                {
                    _TotalCollectionAfter = Convert.ToDouble(txtCollectionAmount.Text);
                }
                catch
                {
                    _TotalCollectionAfter = 0;
                }

                this.Close();
                _IsTrue = true;
            }
        }

        private void Collection(double _Amount)
        {
            TELLib oTELLib = new TELLib();

            txtCollectionAmount.Text = oTELLib.TakaFormat(_Amount);
            txtDueAmount.Text = oTELLib.TakaFormat((Convert.ToDouble(txtNetPay.Text) - Convert.ToDouble(txtCollectionAmount.Text)));

            if (Convert.ToDouble(txtDueAmount.Text) != 0)
                txtDueAmount.ForeColor = Color.Red;
            else txtDueAmount.ForeColor = Color.Green;
        }

        //private void GetNetAmount()
        //{
        //    double _InstallationCharge = 0;
        //    double _FreightCharge = 0;
        //    double _OtherCharge = 0;
        //    _TotalDiscount = 0;

        //    //if (rdoPercentage.Checked == true)
        //    //{
        //    //    if (txtParcentage.Text != "")
        //    //    {
        //    //        _Percentage = ((Convert.ToDouble(txtTotal.Text)) * (Convert.ToDouble(txtParcentage.Text) / 100));
        //    //    }
        //    //}
        //    //else
        //    //{

        //    //    if (txtFlatAmount.Text != "")
        //    //    {
        //    //        _FlatAmount = Math.Round(Convert.ToDouble(txtFlatAmount.Text), 0, MidpointRounding.AwayFromZero);
        //    //    }
        //    //}

        //    if (txtInstallationCharge.Text != "")
        //        _InstallationCharge = Math.Round(Convert.ToDouble(txtInstallationCharge.Text), 0, MidpointRounding.AwayFromZero);

        //    if (txtFreightCharge.Text != "")
        //        _FreightCharge = Math.Round(Convert.ToDouble(txtFreightCharge.Text), 0, MidpointRounding.AwayFromZero);

        //    if (txtOtherCharge.Text != "")
        //        _OtherCharge = Math.Round(Convert.ToDouble(txtOtherCharge.Text), 0, MidpointRounding.AwayFromZero);

        //    //if (txtSMSDiscount.Text != "")
        //    //    _ScratchCardAmt = Math.Round(Convert.ToDouble(txtSMSDiscount.Text), 0, MidpointRounding.AwayFromZero);

        //    _TotalDiscount = _TotalDiscount +
        //                     Math.Round(Convert.ToDouble(txtPromoDisount.Text), 0, MidpointRounding.AwayFromZero)
        //                     +
        //                     Math.Round(Convert.ToDouble(txtAdditionalDiscount.Text), 0, MidpointRounding.AwayFromZero);


        //    oTELLib = new TELLib();
        //    txtNetPay.Text = oTELLib.TakaFormat(Math.Round(Convert.ToDouble(txtTotal.Text), 0, MidpointRounding.AwayFromZero) + _InstallationCharge + _FreightCharge + _OtherCharge - _TotalDiscount);

        //    if (Math.Round(Convert.ToDouble(txtNetPay.Text), 0, MidpointRounding.AwayFromZero) >= 0)
        //        txtNetPay.ForeColor = Color.Green;
        //    else txtNetPay.ForeColor = Color.Red;
        //    lblpayableAmount.Text = "Net Payable (In Word): " + oTELLib.TakaWords(Math.Round(Convert.ToDouble(txtNetPay.Text), 0, MidpointRounding.AwayFromZero));
        //    txtDueAmount.Text = oTELLib.TakaFormat(Math.Round(Convert.ToDouble(txtNetPay.Text), 0, MidpointRounding.AwayFromZero) - Math.Round(Convert.ToDouble(txtCollectionAmount.Text), 0, MidpointRounding.AwayFromZero));

        //    if (Math.Round(Convert.ToDouble(txtDueAmount.Text), 0, MidpointRounding.AwayFromZero) != 0)
        //        txtDueAmount.ForeColor = Color.Red;
        //    else txtDueAmount.ForeColor = Color.Green;
        //    txtTotalDisount.Text = oTELLib.TakaFormat(_TotalDiscount).ToString();

        //}

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            //GetNetAmount();
            GetTotalAmount();
        }
        private void txtPromoDisount_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvInvoicePayment_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            _dPaymentTotal = 0;
            foreach (DataGridViewRow oItemRow in dgvInvoicePayment.Rows)
            {
                if (oItemRow.Index < dgvInvoicePayment.Rows.Count)
                {
                    if (oItemRow.Cells[0].Value != null)
                    {
                        if (oItemRow.Cells[1].Value != null)
                        {
                            try
                            {
                                txtCollectionAmount.Text = "0.00";
                                txtDueAmount.Text = "0.00";
                                double tmp = Convert.ToDouble(oItemRow.Cells[1].Value.ToString().Trim());
                                _dPaymentTotal = _dPaymentTotal + tmp;
                            }
                            catch
                            {
                                MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                    }
                }
            }
            CollectionNew(_dPaymentTotal);
            GetTotalAmount();
        }

        private void CollectionNew(double _Amount)
        {
            TELLib oTELLib = new TELLib();

            txtCollectionAmount.Text = oTELLib.TakaFormat(_Amount);
            txtDueAmount.Text = oTELLib.TakaFormat((Convert.ToDouble(txtNetPay.Text) - Convert.ToDouble(txtCollectionAmount.Text)));

            if (Convert.ToDouble(txtDueAmount.Text) != 0)
                txtDueAmount.ForeColor = Color.Red;
            else txtDueAmount.ForeColor = Color.Green;
        }
        private void GetTotalAmount()
        {
            txtCollectionAmount.Text = "0.00";
            txtNetPay.Text = "0.00";
            txtAdditionalDiscount.Text = "0.00";
            txtTotalCharge.Text = "0.00";

            double _ExtendEMICharge = 0;
            double _BankDiscount = 0;
            double _nTotalDiscount = 0;

            oTELLib = new TELLib();
            foreach (DataGridViewRow oRow in dgvInvoicePayment.Rows)
            {
                if (oRow.Cells[1].Value != null)
                {
                    txtCollectionAmount.Text = Convert.ToDouble(Convert.ToDouble(txtCollectionAmount.Text) + Convert.ToDouble(oRow.Cells[1].Value.ToString())).ToString();
                    _ExtendEMICharge = _ExtendEMICharge + Convert.ToDouble(oRow.Cells[16].Value.ToString());
                    _BankDiscount = _BankDiscount + Convert.ToDouble(oRow.Cells[17].Value.ToString());
                }
            }
            if (_IsApplicableB2BDiscountPayment == false)
            {
                _B2BDiscount = 0;

            }
            else
            {
                if (_nUIControl == (int)Dictionary.SalesType.B2B)
                {

                    //GetB2BDiscount();
                    if (!_bIsApplicableB2BDiscount)
                    {
                        GetB2BDiscount();
                    }
                }
            }
            GetDiscountsChargesFromSinglePayment(oDsSalesInvoiceDiscount, _BankDiscount, _ExtendEMICharge, _B2BDiscount, _B2CDiscount, _DealerDiscount, _TPDiscount, _CPDiscount, _DealerMargin);

            txtAdditionalDiscount.Text = oTELLib.TakaFormat(Math.Round(_AdditionalDiscount, 0, MidpointRounding.AwayFromZero));
            txtTotalCharge.Text = oTELLib.TakaFormat(Math.Round(_AdditionalCharge, 0, MidpointRounding.AwayFromZero));

            _nTotalDiscount = _nTotalDiscount +
                 Math.Round(Convert.ToDouble(txtPromoDisount.Text), 0, MidpointRounding.AwayFromZero)
                 +
                 Math.Round(Convert.ToDouble(txtAdditionalDiscount.Text), 0, MidpointRounding.AwayFromZero);

            oTELLib = new TELLib();
            txtNetPay.Text = oTELLib.TakaFormat(Math.Round(Convert.ToDouble(txtTotal.Text), 0, MidpointRounding.AwayFromZero) + Math.Round(Convert.ToDouble(txtTotalCharge.Text), 0, MidpointRounding.AwayFromZero) - _nTotalDiscount);
            lblpayableAmount.Text = "Net Payable (In Word): " + oTELLib.TakaWords(Math.Round(Convert.ToDouble(txtNetPay.Text), 0, MidpointRounding.AwayFromZero));
            if (Math.Round(Convert.ToDouble(txtNetPay.Text), 0, MidpointRounding.AwayFromZero) >= 0)
                txtNetPay.ForeColor = Color.Green;
            else txtNetPay.ForeColor = Color.Red;
            txtDueAmount.Text = oTELLib.TakaFormat(Math.Round(Convert.ToDouble(txtNetPay.Text), 0, MidpointRounding.AwayFromZero) - Math.Round(Convert.ToDouble(txtCollectionAmount.Text), 0, MidpointRounding.AwayFromZero));
            if (Math.Round(Convert.ToDouble(txtDueAmount.Text), 0, MidpointRounding.AwayFromZero) != 0)
                txtDueAmount.ForeColor = Color.Red;
            else txtDueAmount.ForeColor = Color.Green;
            txtTotalDisount.Text = oTELLib.TakaFormat(_nTotalDiscount).ToString();
        }
        private void lblAddPayment_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtDueAmount.Text) > 0)
            {

                DSInvoicePayment _oDSInvoicePaymentExptProductSingle = new DSInvoicePayment();
                DSInvoicePayment oDSInvoicePaymentExptProductSingle = new DSInvoicePayment();
                _oDSInvoicePaymentExptProductSingle = MargePaymentExptProduct(_oDSInvoicePaymentExptProductSingle, _nProductID);
                oDSInvoicePaymentExptProductSingle.Merge(_oDSInvoicePaymentExptProductSingle);
                oDSInvoicePaymentExptProductSingle.Merge(oDSInvoicePaymentExptProduct);
                oDSInvoicePaymentExptProductSingle.AcceptChanges();

                frmSinglePayment oForm = new frmSinglePayment(Convert.ToDouble(txtDueAmount.Text), lblProductName.Text, _nProductID, _nCustomerID, _nUIControl, _sConsumerCode,
                    -1, 0, "", DateTime.Now.Date, -1, -1, -1, -1, "", 0, -1, 0, 0, 1, oDSInvoicePaymentExptProductSingle, 0, nFreeEMIID, "");
                oForm.ShowDialog();
                if (oForm._IsTrue == true)
                {
                    if (oForm._oDSInvoicePayment.InvoicePayment.Count > 0)
                    {
                        foreach (
                        DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow in
                            oForm._oDSInvoicePayment.InvoicePayment)
                        {
                            DataGridViewRow oRow = new DataGridViewRow();
                            oRow.CreateCells(dgvInvoicePayment);
                            oRow.Cells[0].Value = oInvoicePaymentRow.PaymentModeName.ToString();
                            oRow.Cells[1].Value = oInvoicePaymentRow.Amount.ToString();
                            oRow.Cells[9].Value = oInvoicePaymentRow.InstrumentNo.ToString();
                            oRow.Cells[10].Value = oInvoicePaymentRow.InstrumentDate.ToString("dd-MMM-yyyy");
                            oRow.Cells[10].Style.ForeColor = Color.Transparent;
                            oRow.Cells[11].Value = oInvoicePaymentRow.PaymentModeID.ToString();

                            PaymentMode oPMode = new PaymentMode();
                            oPMode.PaymentModeID = oInvoicePaymentRow.PaymentModeID;
                            oPMode.Refresh();
                            if (oPMode.IsFinancialInstitution == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                oRow.Cells[10].Style.ForeColor = Color.Black;
                                oRow.Cells[2].Value = oInvoicePaymentRow.BankName.ToString();
                                oRow.Cells[3].Value = "";
                                oRow.Cells[4].Value = "";
                                oRow.Cells[5].Value = "";
                                oRow.Cells[6].Value = "";
                                oRow.Cells[7].Value = Enum.GetName(typeof(Dictionary.YesOrNoStatus), oInvoicePaymentRow.IsEMI);
                                oRow.Cells[8].Value = oInvoicePaymentRow.NoOfInstallment.ToString();
                                if (oInvoicePaymentRow.NoOfInstallment == -1)
                                {
                                    oRow.Cells[8].Style.ForeColor = Color.Transparent;
                                }
                                else
                                {
                                    oRow.Cells[8].Style.ForeColor = Color.Black;
                                }
                                oRow.Cells[12].Value = oInvoicePaymentRow.BankID.ToString();
                                oRow.Cells[13].Value = "";
                                oRow.Cells[14].Value = "";
                                oRow.Cells[15].Value = "";
                                oRow.Cells[16].Value = oInvoicePaymentRow.ExtendedEMICharge.ToString();
                                oRow.Cells[17].Value = oInvoicePaymentRow.BankDiscount.ToString();

                            }
                            else
                            {
                                if (oInvoicePaymentRow.PaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
                                {
                                    oRow.Cells[10].Style.ForeColor = Color.Black;
                                    oRow.Cells[2].Value = oInvoicePaymentRow.BankName.ToString();
                                    oRow.Cells[3].Value = oInvoicePaymentRow.CardTypeName.ToString();
                                    oRow.Cells[4].Value = oInvoicePaymentRow.POSMachineName.ToString();
                                    oRow.Cells[5].Value = oInvoicePaymentRow.CardCategoryName.ToString();
                                    oRow.Cells[6].Value = oInvoicePaymentRow.ApprovalNo.ToString();
                                    oRow.Cells[7].Value = Enum.GetName(typeof(Dictionary.YesOrNoStatus), oInvoicePaymentRow.IsEMI);
                                    oRow.Cells[8].Value = oInvoicePaymentRow.NoOfInstallment.ToString();
                                    if (oInvoicePaymentRow.NoOfInstallment == -1)
                                    {
                                        oRow.Cells[8].Style.ForeColor = Color.Transparent;
                                    }
                                    else
                                    {
                                        oRow.Cells[8].Style.ForeColor = Color.Black;
                                    }
                                    oRow.Cells[12].Value = oInvoicePaymentRow.BankID.ToString();
                                    oRow.Cells[13].Value = oInvoicePaymentRow.CardType.ToString();
                                    oRow.Cells[14].Value = oInvoicePaymentRow.POSMachineID.ToString();
                                    oRow.Cells[15].Value = oInvoicePaymentRow.CardCategory.ToString();
                                    oRow.Cells[16].Value = oInvoicePaymentRow.ExtendedEMICharge.ToString();
                                    oRow.Cells[17].Value = oInvoicePaymentRow.BankDiscount.ToString();
                                }
                                else
                                {

                                    oRow.Cells[2].Value = "";
                                    oRow.Cells[3].Value = "";
                                    oRow.Cells[4].Value = "";
                                    oRow.Cells[5].Value = "";
                                    oRow.Cells[6].Value = "";
                                    oRow.Cells[7].Value = "";
                                    oRow.Cells[8].Value = "";
                                    oRow.Cells[12].Value = "";
                                    oRow.Cells[13].Value = "";
                                    oRow.Cells[14].Value = "";
                                    oRow.Cells[15].Value = "";
                                    oRow.Cells[16].Value = 0;
                                    try
                                    {
                                        oRow.Cells[17].Value = oInvoicePaymentRow.BankDiscount.ToString(); //NEWLY  added instead of 0
                                    }
                                    catch
                                    {
                                        oRow.Cells[17].Value = 0;
                                    }

                                }
                            }
                            oRow.Cells[19].Value = oInvoicePaymentRow.BGID.ToString();
                            oRow.Cells[20].Value = oInvoicePaymentRow.CreditApprovalID.ToString();
                            oRow.Cells[21].Value = oInvoicePaymentRow.AdvancePaymentID.ToString();
                            oRow.Cells[22].Value = oInvoicePaymentRow.BankDiscountID.ToString();
                            oRow.Cells[23].Value = oInvoicePaymentRow.ExtendedEMIChargeID.ToString();
                            try
                            {
                                oRow.Cells[24].Value = oInvoicePaymentRow.SDApprovalNo.ToString();
                            }
                            catch
                            {
                                oRow.Cells[24].Value = "";
                            }

                            dgvInvoicePayment.Rows.Add(oRow);
                        }
                    }
                    GetTotalAmount();
                }
            }
            else
            {
                MessageBox.Show("There is no due amount", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void lblDiscountsCharges_Click(object sender, EventArgs e)
        {
            frmSalesInvoiceDiscount oFrmSalesInvoiceDiscount = new frmSalesInvoiceDiscount(_nProductID,
                lblProductName.Text.ToString(), _nUIControl, _nCustomerID, _sConsumerCode,
                _IsApplicableB2BDiscountPayment, _TotalRsAmount, _bIsApplicableB2BDiscount, _IsActiveSCDiscount,
                _OfferType, _bPromoExchangeOffer);
            oFrmSalesInvoiceDiscount.ShowDialog(oDsSalesInvoiceDiscount);
            if (oFrmSalesInvoiceDiscount._IsTrue == true)
            {
                _IsApplicableB2BDiscountPayment = oFrmSalesInvoiceDiscount._IsApplicableB2BDiscountDiscount;
                oDsSalesInvoiceDiscount = new DSSalesInvoiceDiscount();
                oDsSalesInvoiceDiscount = oFrmSalesInvoiceDiscount._oDSSalesInvoiceDiscount;
                oTELLib = new TELLib();
                txtAdditionalDiscount.Text = oTELLib.TakaFormat(oFrmSalesInvoiceDiscount._TotalDiscount);
                _IsTrueInvoiceDiscount = oFrmSalesInvoiceDiscount._IsTrue;
                GetTotalAmount();
            }
        }

        public void GetDiscountsChargesFromSinglePayment(DSSalesInvoiceDiscount oDSSalesInvoiceDiscount, double _BankDiscount, double _ExtEMICharge, double _nB2BDiscount,double _nB2CDiscount,double _nDealerDiscount,double TPDiscount,double CPDiscount,double _nDealerMargin)
        {
            DSSalesInvoiceDiscount _oDSSalesInvoiceDiscount = new DSSalesInvoiceDiscount();
            _AdditionalDiscount = 0;
            _AdditionalCharge = 0;


            if (oDSSalesInvoiceDiscount.SalesInvoiceDiscount.Count != 0)
            {
                foreach (
                    DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oSalesInvoiceDiscountRow in oDSSalesInvoiceDiscount.SalesInvoiceDiscount)
                {

                    DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oRow = _oDSSalesInvoiceDiscount.SalesInvoiceDiscount.NewSalesInvoiceDiscountRow();
                    oRow.DiscountTypeID = oSalesInvoiceDiscountRow.DiscountTypeID;
                    oRow.DiscountTypeName = oSalesInvoiceDiscountRow.DiscountTypeName;
                    oRow.InstrumentNo = oSalesInvoiceDiscountRow.InstrumentNo;
                    oRow.Description = oSalesInvoiceDiscountRow.Description;
                    oRow.Type = oSalesInvoiceDiscountRow.Type;
                    if (oSalesInvoiceDiscountRow.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Bank_Discount)
                    {
                        oRow.Amount = _BankDiscount;
                    }
                    else if (oSalesInvoiceDiscountRow.DiscountTypeID == (int)Dictionary.DiscountChargeItem.B2B_Discount)
                    {
                        if (_nUIControl == (int)Dictionary.SalesType.B2B)
                        {
                            oRow.Amount = _nB2BDiscount;
                        }
                        else
                        {
                            oRow.Amount = 0;
                        }

                    }
                    else if (oSalesInvoiceDiscountRow.DiscountTypeID == (int)Dictionary.DiscountChargeItem.B2C_Discount)
                    {
                        oRow.Amount = _nB2CDiscount;

                    }
                    else if (oSalesInvoiceDiscountRow.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Dealer_Discount)
                    {
                        oRow.Amount = _nDealerDiscount;

                    }
                    else if (oSalesInvoiceDiscountRow.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Dealer_Margin)
                    {
                        oRow.Amount = _nDealerMargin;
                    }

                    else if (oSalesInvoiceDiscountRow.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Trade_Promotion)
                    {
                        oRow.Amount = TPDiscount;

                    }

                    else if (oSalesInvoiceDiscountRow.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Consumer_Promotion)
                    {
                        oRow.Amount = CPDiscount;

                    }
                    else
                    {
                        oRow.Amount = oSalesInvoiceDiscountRow.Amount;

                    }
                    _AdditionalDiscount = _AdditionalDiscount + oRow.Amount;
                    oRow.ProductID = oSalesInvoiceDiscountRow.ProductID;
                    try
                    {
                        oRow.FreeProductID = oSalesInvoiceDiscountRow.FreeProductID;
                    }
                    catch
                    {
                        oRow.FreeProductID = -1;
                    }
                    try
                    {
                        oRow.FreeQty = oSalesInvoiceDiscountRow.FreeQty;
                    }
                    catch
                    {
                        oRow.FreeQty = -1;
                    }
                    try
                    {
                        oRow.ProductSerialNo = oSalesInvoiceDiscountRow.ProductSerialNo;

                    }
                    catch
                    {
                        oRow.ProductSerialNo = "";
                    }
                    try
                    {
                        oRow.IsBarcodeItemFreeProduct = oSalesInvoiceDiscountRow.IsBarcodeItemFreeProduct;
                    }
                    catch
                    {
                        oRow.IsBarcodeItemFreeProduct = -1;
                    }

                    _oDSSalesInvoiceDiscount.SalesInvoiceDiscount.AddSalesInvoiceDiscountRow(oRow);
                    _oDSSalesInvoiceDiscount.AcceptChanges();
                }
                _AdditionalDiscount = _AdditionalDiscount - (TPDiscount + CPDiscount);
            }
            else
            {
                DiscountReasons oReasons = new DiscountReasons();
                //oReasons.GetSalesInvoiceDiscountType((int)Dictionary.DiscountChargeType.Discount, _nUIControl);
                oReasons.GetSalesInvoiceDiscountTypeWithSCImact((int) Dictionary.DiscountChargeType.Discount,
                    _nUIControl, _IsActiveSCDiscount, _OfferType, _bPromoExchangeOffer);
                foreach (DiscountReason oDiscountReason in oReasons)
                {
                    DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oRow = _oDSSalesInvoiceDiscount.SalesInvoiceDiscount.NewSalesInvoiceDiscountRow();

                    oRow.DiscountTypeID = oDiscountReason.DiscountTypeID;
                    oRow.DiscountTypeName = oDiscountReason.DiscountTypeName;
                    oRow.InstrumentNo = "";
                    oRow.Description = "";
                    oRow.Type = oDiscountReason.Type;
                    //if (oDiscountReason.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Bank_Discount)
                    //{
                    //    oRow.Amount = _BankDiscount;
                    //}
                    //else if (oDiscountReason.DiscountTypeID == (int)Dictionary.DiscountChargeItem.B2B_Discount)
                    //{
                    //    if (_nUIControl == (int)Dictionary.SalesType.B2B)
                    //    {
                    //        oRow.Amount = _nB2BDiscount;
                    //    }
                    //    else
                    //    {
                    //        oRow.Amount = 0;
                    //    }

                    //}
                    if (oDiscountReason.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Bank_Discount)
                    {
                        oRow.Amount = _BankDiscount;
                    }
                    else if (oDiscountReason.DiscountTypeID == (int)Dictionary.DiscountChargeItem.B2B_Discount)
                    {
                        if (_nUIControl == (int)Dictionary.SalesType.B2B)
                        {
                            oRow.Amount = _nB2BDiscount;
                        }
                        else
                        {
                            oRow.Amount = 0;
                        }
                    }
                    else if (oDiscountReason.DiscountTypeID == (int)Dictionary.DiscountChargeItem.B2C_Discount)
                    {
                        oRow.Amount = _nB2CDiscount;

                    }
                    else if (oDiscountReason.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Dealer_Discount)
                    {
                        oRow.Amount = _nDealerDiscount;

                    }
                    else if (oDiscountReason.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Dealer_Margin)
                    {
                        oRow.Amount = _nDealerMargin;
                    }
                    else if (oDiscountReason.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Trade_Promotion)
                    {
                        oRow.Amount = TPDiscount;

                    }
                    else if (oDiscountReason.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Consumer_Promotion)
                    {
                        oRow.Amount = CPDiscount;
                    }
                    else
                    {
                        oRow.Amount = 0;
                    }
                    _AdditionalDiscount = _AdditionalDiscount + oRow.Amount;
                    oRow.ProductID = _nProductID;


                    oRow.FreeProductID = -1;
                    oRow.FreeQty = -1;
                    oRow.ProductSerialNo = "";
                    oRow.IsBarcodeItemFreeProduct = -1;

                    _oDSSalesInvoiceDiscount.SalesInvoiceDiscount.AddSalesInvoiceDiscountRow(oRow);
                    _oDSSalesInvoiceDiscount.AcceptChanges();

                }
            }

            if (oDSSalesInvoiceDiscount.SalesInvoiceCharge.Count != 0)
            {
                foreach (
                    DSSalesInvoiceDiscount.SalesInvoiceChargeRow oSalesInvoiceChargeRow in
                        oDSSalesInvoiceDiscount.SalesInvoiceCharge)
                {
                    DSSalesInvoiceDiscount.SalesInvoiceChargeRow oRow = _oDSSalesInvoiceDiscount.SalesInvoiceCharge.NewSalesInvoiceChargeRow();
                    oRow.DiscountTypeID = oSalesInvoiceChargeRow.DiscountTypeID;
                    oRow.DiscountTypeName = oSalesInvoiceChargeRow.DiscountTypeName;
                    oRow.InstrumentNo = oSalesInvoiceChargeRow.InstrumentNo;
                    oRow.Description = oSalesInvoiceChargeRow.Description;
                    oRow.Type = oSalesInvoiceChargeRow.Type;
                    if (oSalesInvoiceChargeRow.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Extended_EMI_Charge)
                    {
                        oRow.Amount = _ExtEMICharge;
                    }
                    else
                    {
                        oRow.Amount = oSalesInvoiceChargeRow.Amount;

                    }
                    _AdditionalCharge = _AdditionalCharge + oRow.Amount;
                    oRow.ProductID = oSalesInvoiceChargeRow.ProductID;

                    _oDSSalesInvoiceDiscount.SalesInvoiceCharge.AddSalesInvoiceChargeRow(oRow);
                    _oDSSalesInvoiceDiscount.AcceptChanges();
                }
            }
            else
            {
                DiscountReasons oReasons = new DiscountReasons();
                oReasons.GetSalesInvoiceDiscountType((int)Dictionary.DiscountChargeType.Charge, _nUIControl);
                foreach (DiscountReason oDiscountReason in oReasons)
                {
                    DSSalesInvoiceDiscount.SalesInvoiceChargeRow oRow = _oDSSalesInvoiceDiscount.SalesInvoiceCharge.NewSalesInvoiceChargeRow();
                    oRow.DiscountTypeID = oDiscountReason.DiscountTypeID;
                    oRow.DiscountTypeName = oDiscountReason.DiscountTypeName;
                    oRow.InstrumentNo = "";
                    oRow.Description = "";
                    oRow.Type = oDiscountReason.Type;
                    if (oDiscountReason.DiscountTypeID == (int)Dictionary.DiscountChargeItem.Extended_EMI_Charge)
                    {
                        oRow.Amount = _ExtEMICharge;
                    }
                    else
                    {
                        oRow.Amount = 0;

                    }
                    _AdditionalCharge = _AdditionalCharge + oRow.Amount;
                    oRow.ProductID = _nProductID;

                    _oDSSalesInvoiceDiscount.SalesInvoiceCharge.AddSalesInvoiceChargeRow(oRow);
                    _oDSSalesInvoiceDiscount.AcceptChanges();
                }
            }

            oDsSalesInvoiceDiscount = new DSSalesInvoiceDiscount();
            oDsSalesInvoiceDiscount.Merge(_oDSSalesInvoiceDiscount);
            oDsSalesInvoiceDiscount.AcceptChanges();
        }

        private void dgvInvoicePayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 18)
            {
                DSInvoicePayment _oDSInvoicePaymentExptProductSingle = new DSInvoicePayment();
                DSInvoicePayment oDSInvoicePaymentExptProductSingle = new DSInvoicePayment();
                _oDSInvoicePaymentExptProductSingle = MargePaymentExptProduct(_oDSInvoicePaymentExptProductSingle, _nProductID);
                oDSInvoicePaymentExptProductSingle.Merge(_oDSInvoicePaymentExptProductSingle);
                oDSInvoicePaymentExptProductSingle.Merge(oDSInvoicePaymentExptProduct);
                oDSInvoicePaymentExptProductSingle.AcceptChanges();

                _PaymentModeID = int.Parse(dgvInvoicePayment.Rows[e.RowIndex].Cells[11].Value.ToString());
                _Amount = Convert.ToDouble(dgvInvoicePayment.Rows[e.RowIndex].Cells[1].Value.ToString());
                try
                {
                    _BankID = int.Parse(dgvInvoicePayment.Rows[e.RowIndex].Cells[12].Value.ToString());
                }
                catch
                {
                    _BankID = -1;
                }
                try
                {
                    _CardType = int.Parse(dgvInvoicePayment.Rows[e.RowIndex].Cells[13].Value.ToString());
                }
                catch
                {
                    _CardType = -1;
                }
                try
                {
                    _POSMachineID = int.Parse(dgvInvoicePayment.Rows[e.RowIndex].Cells[14].Value.ToString());
                }
                catch
                {
                    _POSMachineID = -1;
                }
                try
                {
                    _CardCategory = int.Parse(dgvInvoicePayment.Rows[e.RowIndex].Cells[15].Value.ToString());
                }
                catch
                {
                    _CardCategory = -1;
                }
                try
                {
                    _sApprovalNo = (dgvInvoicePayment.Rows[e.RowIndex].Cells[6].Value.ToString());
                }
                catch
                {
                    _sApprovalNo = "";
                }
                try
                {
                    if (dgvInvoicePayment.Rows[e.RowIndex].Cells[7].Value.ToString() == "YES")
                    {
                        _IsEMI = 1;
                    }
                    else
                    {
                        _IsEMI = 0;
                    }
                }
                catch
                {
                    _IsEMI = 0;
                }
                try
                {
                    _NoOfInstallment = int.Parse(dgvInvoicePayment.Rows[e.RowIndex].Cells[8].Value.ToString());
                }
                catch
                {
                    _NoOfInstallment = -1;
                }
                try
                {
                    _sInstrumentNo = (dgvInvoicePayment.Rows[e.RowIndex].Cells[9].Value.ToString());
                }
                catch
                {
                    _sInstrumentNo = "";
                }
                try
                {
                    _dtInstrumentDate = Convert.ToDateTime(dgvInvoicePayment.Rows[e.RowIndex].Cells[10].Value.ToString());
                }
                catch
                {
                    _dtInstrumentDate = DateTime.Now.Date;
                }
                try
                {
                    _ExtendedEMICharge = Convert.ToDouble(dgvInvoicePayment.Rows[e.RowIndex].Cells[16].Value.ToString());
                }
                catch
                {
                    _ExtendedEMICharge = 0;
                }
                try
                {
                    _BankDiscount = Convert.ToDouble(dgvInvoicePayment.Rows[e.RowIndex].Cells[17].Value.ToString());
                }
                catch
                {
                    _BankDiscount = 0;
                }

                try
                {
                    _sSDApprovalNo = (dgvInvoicePayment.Rows[e.RowIndex].Cells[24].Value.ToString());
                }
                catch
                {
                    _sSDApprovalNo = "";
                }

                double _nAmount = 0;
                if(_PaymentModeID==(int)Dictionary.PaymentMode.Approve_Credit|| _PaymentModeID == (int)Dictionary.PaymentMode.Advance_Payment || _PaymentModeID == (int)Dictionary.PaymentMode.Customer_BG)
                {
                    _nAmount = _Amount;
                }
                frmSinglePayment oForm = new frmSinglePayment(Convert.ToDouble(txtDueAmount.Text), lblProductName.Text, _nProductID, _nCustomerID, _nUIControl, _sConsumerCode, _PaymentModeID, _Amount, _sInstrumentNo, _dtInstrumentDate, _BankID, _CardType, _POSMachineID, _CardCategory, _sApprovalNo, _IsEMI, _NoOfInstallment, _BankDiscount, _ExtendedEMICharge, 2, oDSInvoicePaymentExptProductSingle, _nAmount, nFreeEMIID, _sSDApprovalNo);
                oForm.ShowDialog();
                if (oForm._IsTrue == true)
                {
                    if (oForm._oDSInvoicePayment.InvoicePayment.Count > 0)
                    {
                        foreach (
                        DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow in
                            oForm._oDSInvoicePayment.InvoicePayment)
                        {

                            dgvInvoicePayment.Rows[e.RowIndex].Cells[0].Value = oInvoicePaymentRow.PaymentModeName.ToString();
                            dgvInvoicePayment.Rows[e.RowIndex].Cells[1].Value = oInvoicePaymentRow.Amount.ToString();
                            dgvInvoicePayment.Rows[e.RowIndex].Cells[9].Value = oInvoicePaymentRow.InstrumentNo.ToString();
                            dgvInvoicePayment.Rows[e.RowIndex].Cells[10].Value = oInvoicePaymentRow.InstrumentDate.ToString("dd-MMM-yyyy");
                            dgvInvoicePayment.Rows[e.RowIndex].Cells[10].Style.ForeColor = Color.Transparent;
                            dgvInvoicePayment.Rows[e.RowIndex].Cells[11].Value = oInvoicePaymentRow.PaymentModeID.ToString();
                            /////New Code
                            PaymentMode oPModes = new PaymentMode();
                            oPModes.PaymentModeID = oInvoicePaymentRow.PaymentModeID;
                            oPModes.Refresh();
                            if (oPModes.IsFinancialInstitution == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[10].Style.ForeColor = Color.Black;

                                dgvInvoicePayment.Rows[e.RowIndex].Cells[2].Value = oInvoicePaymentRow.BankName.ToString();
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[3].Value = "";
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[4].Value = "";
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[5].Value = "";
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[6].Value = "";
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[7].Value = Enum.GetName(typeof(Dictionary.YesOrNoStatus), oInvoicePaymentRow.IsEMI);
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[8].Value = oInvoicePaymentRow.NoOfInstallment.ToString();
                                if (oInvoicePaymentRow.NoOfInstallment == -1)
                                {
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[8].Style.ForeColor = Color.Transparent;
                                }
                                else
                                {
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[8].Style.ForeColor = Color.Black;
                                }
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[12].Value = oInvoicePaymentRow.BankID.ToString();
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[13].Value = "";
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[14].Value = "";
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[15].Value = "";
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[16].Value = oInvoicePaymentRow.ExtendedEMICharge.ToString();
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[17].Value = oInvoicePaymentRow.BankDiscount.ToString();
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[22].Value = oInvoicePaymentRow.BankDiscountID.ToString();
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[23].Value = oInvoicePaymentRow.ExtendedEMIChargeID.ToString();

                            }
                            else
                            {
                                if (oInvoicePaymentRow.PaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
                                {
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[10].Style.ForeColor = Color.Black;

                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[2].Value = oInvoicePaymentRow.BankName.ToString();
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[3].Value = oInvoicePaymentRow.CardTypeName.ToString();
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[4].Value = oInvoicePaymentRow.POSMachineName.ToString();
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[5].Value = oInvoicePaymentRow.CardCategoryName.ToString();
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[6].Value = oInvoicePaymentRow.ApprovalNo.ToString();
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[7].Value = Enum.GetName(typeof(Dictionary.YesOrNoStatus), oInvoicePaymentRow.IsEMI);
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[8].Value = oInvoicePaymentRow.NoOfInstallment.ToString();
                                    if (oInvoicePaymentRow.NoOfInstallment == -1)
                                    {
                                        dgvInvoicePayment.Rows[e.RowIndex].Cells[8].Style.ForeColor = Color.Transparent;
                                    }
                                    else
                                    {
                                        dgvInvoicePayment.Rows[e.RowIndex].Cells[8].Style.ForeColor = Color.Black;
                                    }
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[12].Value = oInvoicePaymentRow.BankID.ToString();
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[13].Value = oInvoicePaymentRow.CardType.ToString();
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[14].Value = oInvoicePaymentRow.POSMachineID.ToString();
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[15].Value = oInvoicePaymentRow.CardCategory.ToString();
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[16].Value = oInvoicePaymentRow.ExtendedEMICharge.ToString();
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[17].Value = oInvoicePaymentRow.BankDiscount.ToString();

                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[22].Value = oInvoicePaymentRow.BankDiscountID.ToString();
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[23].Value = oInvoicePaymentRow.ExtendedEMIChargeID.ToString();
                                }
                                else
                                {

                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[2].Value = "";
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[3].Value = "";
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[4].Value = "";
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[5].Value = "";
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[6].Value = "";
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[7].Value = "";
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[8].Value = "";
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[12].Value = "";
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[13].Value = "";
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[14].Value = "";
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[15].Value = "";
                                    dgvInvoicePayment.Rows[e.RowIndex].Cells[16].Value = 0;
                                    try
                                    {
                                        dgvInvoicePayment.Rows[e.RowIndex].Cells[17].Value = oInvoicePaymentRow.BankDiscount.ToString(); //newly added instead of 0
                                    }
                                    catch
                                    {
                                        dgvInvoicePayment.Rows[e.RowIndex].Cells[17].Value = 0;
                                    }

                                }

                            }
                            
                            try
                            {
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[24].Value = oInvoicePaymentRow.SDApprovalNo.ToString();
                            }
                            catch
                            {
                                dgvInvoicePayment.Rows[e.RowIndex].Cells[24].Value = "";
                            }
                            // dgvInvoicePayment.Rows.Add(oRow);
                        }
                    }
                    GetTotalAmount();
                }

            }
        }

        private void GetB2BDiscount()
        {
            ConsumerPromotionEngine oB2BDiscount = new ConsumerPromotionEngine();
            _B2BDiscount = 0;
            _B2BDiscount = oB2BDiscount.GetB2BDiscount(_nCustomerID, _TotalRsAmount, Convert.ToDateTime(oSystemInfo.OperationDate).Date);
        }
        private void GetB2CDealerDiscount()
        {
            ConsumerPromotionEngine oB2BDiscount = new ConsumerPromotionEngine();
            _B2CDiscount = 0;
            _DealerDiscount = 0;
            double _Discount = 0;
            double _DMargin = 0;
            _Discount = oB2BDiscount.GetB2CDealerDiscount(_nUIControl, _nProductID, Convert.ToDateTime(oSystemInfo.OperationDate).Date, _TotalRsAmount);

            _DMargin = oB2BDiscount.GetCustTypeMarginDiscountRSP(_nCustomerID, _nProductID, Convert.ToDateTime(oSystemInfo.OperationDate).Date, _nInvoiceQty);


            if (_nUIControl == (int)Dictionary.SalesType.B2C)
            {
                _B2CDiscount = _Discount;
            }
            else if (_nUIControl == (int)Dictionary.SalesType.Dealer)
            {
                _DealerDiscount = _Discount;
                _DealerMargin = _DMargin;
            }
        }


        
        public DSInvoicePayment MargePaymentExptProduct(DSInvoicePayment _singlePayment, int nProductID)
        {
            _singlePayment = new DSInvoicePayment();
            foreach (DataGridViewRow oItemRow in dgvInvoicePayment.Rows)
            {

                if (oItemRow.Index < dgvInvoicePayment.Rows.Count)
                {
                    DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow =
                        _singlePayment.InvoicePayment.NewInvoicePaymentRow();
                    oInvoicePaymentRow.ProductID = _nProductID;
                    oInvoicePaymentRow.ProductName = lblProductName.Text.ToString();
                    oInvoicePaymentRow.PaymentModeID = int.Parse(oItemRow.Cells[11].Value.ToString());
                    oInvoicePaymentRow.PaymentModeName = oItemRow.Cells[0].Value.ToString();
                    oInvoicePaymentRow.Amount = Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
                    try
                    {
                        oInvoicePaymentRow.BankID = int.Parse(oItemRow.Cells[12].Value.ToString());
                        oInvoicePaymentRow.BankName = oItemRow.Cells[2].Value.ToString();
                    }
                    catch
                    {
                        oInvoicePaymentRow.BankID = -1;
                        oInvoicePaymentRow.BankName = "";
                    }
                    try
                    {
                        oInvoicePaymentRow.CardType = int.Parse(oItemRow.Cells[13].Value.ToString());
                        oInvoicePaymentRow.CardTypeName = oItemRow.Cells[3].Value.ToString();
                    }
                    catch
                    {
                        oInvoicePaymentRow.CardType = -1;
                        oInvoicePaymentRow.CardTypeName = "";
                    }
                    try
                    {
                        oInvoicePaymentRow.POSMachineID = int.Parse(oItemRow.Cells[14].Value.ToString());
                        oInvoicePaymentRow.POSMachineName = oItemRow.Cells[4].Value.ToString();
                    }
                    catch
                    {
                        oInvoicePaymentRow.POSMachineID = -1;
                        oInvoicePaymentRow.POSMachineName = "";
                    }

                    try
                    {
                        oInvoicePaymentRow.CardCategory = int.Parse(oItemRow.Cells[15].Value.ToString());
                        oInvoicePaymentRow.CardCategoryName = oItemRow.Cells[5].Value.ToString();
                    }
                    catch
                    {
                        oInvoicePaymentRow.CardCategory = -1;
                        oInvoicePaymentRow.CardCategoryName = "";
                    }
                    try
                    {
                        oInvoicePaymentRow.ApprovalNo = oItemRow.Cells[6].Value.ToString().Trim();
                    }
                    catch
                    {
                        oInvoicePaymentRow.ApprovalNo = "";

                    }
                    try
                    {
                        if (oItemRow.Cells[7].Value.ToString() == "YES")
                        {
                            oInvoicePaymentRow.IsEMI = 1;
                        }
                        else
                        {
                            oInvoicePaymentRow.IsEMI = 0;
                        }

                    }
                    catch
                    {
                        oInvoicePaymentRow.IsEMI = 0;
                    }
                    try
                    {
                        oInvoicePaymentRow.NoOfInstallment = int.Parse(oItemRow.Cells[8].Value.ToString().Trim());
                    }
                    catch
                    {
                        oInvoicePaymentRow.NoOfInstallment = -1;
                    }
                    try
                    {
                        oInvoicePaymentRow.InstrumentNo = oItemRow.Cells[9].Value.ToString().Trim();
                    }
                    catch
                    {
                        oInvoicePaymentRow.InstrumentNo = "";
                    }

                    try
                    {
                        oInvoicePaymentRow.InstrumentDate =
                            Convert.ToDateTime(oItemRow.Cells[10].Value.ToString().Trim());
                    }
                    catch
                    {
                        oInvoicePaymentRow.InstrumentDate = DateTime.Now.Date;
                    }
                    try
                    {
                        oInvoicePaymentRow.ExtendedEMICharge = Convert.ToDouble(oItemRow.Cells[16].Value.ToString().Trim());
                    }
                    catch
                    {
                        oInvoicePaymentRow.ExtendedEMICharge = 0;
                    }
                    try
                    {
                        oInvoicePaymentRow.BankDiscount = Convert.ToDouble(oItemRow.Cells[17].Value.ToString().Trim());
                    }
                    catch
                    {
                        oInvoicePaymentRow.BankDiscount = 0;
                    }
                    try
                    {
                        oInvoicePaymentRow.BGID = Convert.ToInt32(oItemRow.Cells[19].Value.ToString().Trim());
                    }
                    catch
                    {
                        oInvoicePaymentRow.BankDiscount = -1;
                    }
                    try
                    {
                        oInvoicePaymentRow.CreditApprovalID = Convert.ToInt32(oItemRow.Cells[20].Value.ToString().Trim());
                    }
                    catch
                    {
                        oInvoicePaymentRow.CreditApprovalID = -1;
                    }
                    try
                    {
                        oInvoicePaymentRow.AdvancePaymentID = Convert.ToInt32(oItemRow.Cells[21].Value.ToString().Trim());
                    }
                    catch
                    {
                        oInvoicePaymentRow.AdvancePaymentID = -1;
                    }

                    try
                    {
                        oInvoicePaymentRow.BankDiscountID = Convert.ToInt32(oItemRow.Cells[22].Value.ToString().Trim());
                    }
                    catch
                    {
                        oInvoicePaymentRow.BankDiscountID = -1;
                    }
                    try
                    {
                        oInvoicePaymentRow.ExtendedEMIChargeID = Convert.ToInt32(oItemRow.Cells[23].Value.ToString().Trim());
                    }
                    catch
                    {
                        oInvoicePaymentRow.ExtendedEMIChargeID = -1;
                    }

                    try
                    {
                        oInvoicePaymentRow.SDApprovalNo = (oItemRow.Cells[24].Value.ToString().Trim());
                    }
                    catch
                    {
                        oInvoicePaymentRow.SDApprovalNo = "";
                    }

                    _singlePayment.InvoicePayment.AddInvoicePaymentRow(oInvoicePaymentRow);
                    _singlePayment.AcceptChanges();
                }
            }
            return _singlePayment;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
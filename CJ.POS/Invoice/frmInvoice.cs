using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Class.Promotion;
using CJ.Class.POS;
using System.Text.RegularExpressions;
using CJ.Class.Report;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Library;
using CJ.Class.Warranty;
using CJ.Class.CLP;
using CJ.Class.Duty;
using CJ.Control;
using CJ.Class.Accounts;
using System.Net;
using System.Xml;
using System.IO;
using System.Net.Mail;
using CJ.Win.Control;
using CJ.Class.CSD;
using CJ.Class.Process;
using System.Data.OleDb;
using CJ.POS.TELWEBSERVER;

namespace CJ.POS.Invoice
{
    public partial class frmInvoice : Form
    {
        Service oService;

        int _IsVatApplicableonNetPrice = 0;
        int _VATType = 0;
        double _nCostPrice = 0;


        CJ.Class.POS.DSCustomer _oDSCustomerAll = new CJ.Class.POS.DSCustomer();

        public string _sBarcodeForDefective = "";
        SMSMaker _oSMSMaker;
        int _nInvoiceCustomerTypeID = 0;
        DutyTran oDutyTranVAT63_15 ;
        DutyTran oDutyTranVAT63_5;
        DutyTran oDutyTranVATExampled;
        string sFromLeadConsumerCode = "";
        int nFromLeadConsumeID = 0;
        private Customer _oCustomer;
        public event System.EventHandler ChangeSelection;
        public event KeyPressEventHandler ChangeFocus;
        string sCustumerTypeID = "";
        bool _IsApplyPromotion = false;

        CJ.Class.POS.DSSalesInvoice oInvoiceDiscountChargeMap;
        CJ.Class.POS.DSSalesInvoice oDSProductBarcodeAll;
        private SalesLead oSalesLead;
        string _sLeadNo = "";
        bool _IsPicFromWeb = false;
        string _sWebConsumerCode = "";
        int _btnEditLineItemClickCount = 0; 
        public SalesLead SelectedLeadCustomer
        {
            get { return oSalesLead; }
        }
        GeoLocations oThana;
        GeoLocations oDistrict;
        private bool _IsApplicableB2BDiscountInv = true;


        private int IsChkVatEntry = 0;
        private string _sCHKSerialNo = "";
        private int nTotalQty = 0;
        private int nLeadConsumer = 0;
        private int nIsExistingConsumer = 0;
        private int nLeadID = 0;
        private Employees oEmployees;
        private ProductDetail _oProductDetail;
        private SPProduct oSPProduct;
        private SPProducts oSPProducts;
        private WUIUtility oWUIUtility;
        private SPromotions oSPromotions;
        private SPromotions oResultSPromotions;
        private SPromotions oSelectedSPromotions;
        private SPromotion oResultSPromotion;
        private RetailConsumer oRetailConsumer;
        private SalesInvoice _oSalesInvoice;
        private CustomerTransaction _oCustomerTransaction;
        private User oUser = new User();
        private SystemInfo oSystemInfo;
        private Branchs _oBranchs;
        private Utilities oPaymentMode;
        private StockTran _oStockTran;
        private ProductStock _oProductStock;
        private ProductTransaction _oProductTransaction;
        private RetailSalesInvoice oRetailSalesInvoice;
        private rptSalesInvoice orptSalesInvoice;
        private WarrantyProducts oWarrantyProducts;
        private WarrantyParameter oWarrantyParameter;
        private TELLib oTELLib;
        private DSSalesInvoiceDetail oDSSalesInvoiceProduct;
        private DSSalesInvoiceDetail oDSFreeGiftProduct;
        private DSSalesInvoiceDetail oDSSalesInvoiceDetail;
        private CLPEligibility oCLPEligibility;
        private CLPPoint oCLPPoint;
        private CLPPointSlab oCLPPointSlab;
        private CLPTran oCLPTran;
        private SPSlabAllRatio _oSPSlabAllRatio;
        private SPSlabRatio _oSPSlabRatio;
        private SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        private SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
        private SalesInvoiceProductSerials _oSIPSs;
        private SalesInvoicePromotionFor _oSalesInvoicePromotionFor;
        private SalesInvoicePromotionOffer _oSalesInvoicePromotionOffer;
        private SalesInvoiceScratchCardInfo _oSalesInvoiceScratchCardInfo;
        private SalesInvoicePromotionMapping _oSalesInvoicePromotionMapping;
        private SalesInvoicePromotionMappings _oSalesInvoicePromotionMappings;
        private SPProductGroup _oSPProductGroup;
        private SPProductGroups _oSPProductGroups;
        private DataTran _oDataTran;
        private PaymentModes _oPaymentModes;
        private DiscountReasons _oDiscountReasons;
        private Product _oProduct;
        private SalesPromotionTypes _oSalesPromotionTypes;
        private SalesPromotionType _oSalesPromotionType;
        private DutyTran oDutyTranVAT11;
        private DutyTran oDutyTranVAT11KA;
        private DutyTran oDutyTranVAT63;
        private DutyAccount oDutyAccount;
        private string SL = "";
        private Image iImage;
        private string sApprove_Credit_No = "";
        private double _MarkUpAMount = 0;
        private double _TotalDiscount = 0;
        private double _DutyLocalBalance = 0;
        private double _DutyImportBalance = 0;
        private double _NewDutyBalance = 0;
        private int nArrayLen = 0;
        private int nDisplayPrmoCount = 0;
        private string[] sProductBarcodeArr = null;
        private int _nUIControl = 0;
        private string _sNumbers = "";
        private int nConsumerID = 0;
        private int nCustomerID = 0;
        private int nConsumerSalesType = 0;
        private int nTabClickCount = 0;
        bool _InvoiceLineItemButtonLock = false;
        private CustomerDetail oCustomerDetail;
        private int[] ProductIDList = { 9, 1823, 2810, 2935, 2936, 2937 };

        private DSConsumerPromo _oDSInvoiceLineItem;
        private DSConsumerPromo _oDSInvoiceLineItemForPromo;
        private DSConsumerPromo _oDSEligiblePromo;
        private DSConsumerPromo _oDSPromoForProduct;
        private DSConsumerPromo _oDSPromoSlab;
        private DSConsumerPromo _oDSPromoSlabRatio;
        private DSConsumerPromo _oDSApplicablePromo;
        private DSConsumerPromo _oDSApplicablePromo_TP;
        private ConsumerPromotionEngines oEligiblePromos;
        ConsumerPromotionEngines _oConsumerPromotionEngines;

        private DSConsumerPromo _oDSEligiblePromoTP;
        private DSConsumerPromo _oDSPromoTPForProduct;
        private DSConsumerPromo _oDSPromoTPSlab;
        private DSConsumerPromo _oDSPromoTPSlabRatio;
        string _sDMSOrderNo = "";
        string _sDMSCustomerCode = "";
        int _nDMSOrderID = -1;

        public frmInvoice(int nUIControl, string sLeadNo, string sOrderNo,string sDMSCustomerCode,int nDMSOrderID)
        {
            InitializeComponent();
            _nUIControl = nUIControl - 1;
            _sLeadNo = sLeadNo;
            _sDMSOrderNo = sOrderNo;
            _sDMSCustomerCode = sDMSCustomerCode;
            _nDMSOrderID = nDMSOrderID;

            //if (sLeadNo != "")
            //{
            //    LoadEOrderData(Convert.ToInt32(_sLeadNo));
            //}

        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool ValidateUIInput()
        {
            if(!DefectiveValidation())
            {
                MessageBox.Show("You cannot select Defective and Sound Product in same Invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return false;
            }
            
            #region Invoice Basic Validation
            if (cmbEmpoyee.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Sales Person", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmpoyee.Focus();
                return false;
            }
            if (cmbDeliveryMode.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Delivery Mode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDeliveryMode.Focus();
                return false;
            }
            if (Convert.ToDouble(txtDueAmount.Text) != 0)
            {
                MessageBox.Show("Due amount must be zero", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDueAmount.Focus();
                return false;
            }
            if (cmbDistrict.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a district", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDistrict.Focus();
                return false;
            }
            if (cmbThana.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a thana", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbThana.Focus();
                return false;
            }
            #endregion

            #region Consumer validation
            if (_nUIControl == (int)Dictionary.SalesType.Retail || _nUIControl == (int)Dictionary.SalesType.eStore || _nUIControl == (int)Dictionary.SalesType.B2C || _nUIControl == (int)Dictionary.SalesType.HPA)
            {


                if (txtCustomerName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a consumer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerName.Focus();
                    return false;
                }
                if (txtCustomerAddress.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a consumer address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerAddress.Focus();
                    return false;
                }
                if (txtDeliveryAddress.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a delivery address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDeliveryAddress.Focus();
                    return false;
                }
                if (cmbDistrict.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select a district", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDistrict.Focus();
                    return false;
                }
                if (cmbThana.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select a thana", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbThana.Focus();
                    return false;
                }

                //if (txtEmail.Text.Trim() == "")
                //{
                //    MessageBox.Show("Please enter a consumer email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtCustomerAddress.Focus();
                //    return false;
                //}
                //if (txtEmail.Text.Trim() != "")
                //{
                //    Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
                //    Match m = emailregex.Match(txtEmail.Text);
                //    if (!m.Success)
                //    {
                //        MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        txtEmail.Focus();
                //        return false;
                //    }
                //}

                if (txtEmail.Text.Trim() != "")
                {
                    bool IsValid = IsValidEmail(txtEmail.Text.Trim());
                    if (txtEmail.Text.Trim() == "na@na.com" && chkInvoiceSend.Checked)
                    {
                        IsValid = false;
                    }
                    if (!IsValid)
                    {
                        MessageBox.Show("Please enter a Valid Email Address Or Uncheck 'Send Invoice and Warranty Card through email'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a consumer email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }

                if (txtCell.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a consumer cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCell.Focus();
                    return false;
                }
                else
                {
                    if (txtCell.Text.Trim().Length != 11)
                    {
                        MessageBox.Show("Please enter a valid cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCell.Focus();
                        return false;
                    }
                    Regex rgCell = new Regex("[0-9]");
                    if (rgCell.IsMatch(txtCell.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please Input Valid Cell no ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (rdoNewConsumer.Checked == true)
                {
                    if (txtCell.Text != "")
                    {
                        RetailConsumer GetConsumerByMobileNo = new RetailConsumer();
                        if (GetConsumerByMobileNo.GetConsumerByMobileNo(txtCell.Text.Trim()))
                        {
                            MessageBox.Show("Mobile number already existed. Please select existing consumer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCell.Focus();
                            return false;
                        }
                    }
                }
            }
            if (_nUIControl == (int)Dictionary.SalesType.B2C)
            {
                if (txtEmployeeNo.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter employee#", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmployeeNo.Focus();
                    return false;
                }
                if (txtCtlCustName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter valid B2C customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCtlCustCode.Focus();
                    return false;
                }
            }
            if (_nUIControl == (int)Dictionary.SalesType.Dealer)
            {
                if (txtCtlCustName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter valid dealer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCtlCustCode.Focus();
                    return false;
                }
                if (txtDeliveryAddress.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a delivery address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDeliveryAddress.Focus();
                    return false;
                }



            }
            if (_nUIControl == (int)Dictionary.SalesType.B2B)
            {
                if (txtCtlCustName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter valid B2C customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCtlCustCode.Focus();
                    return false;
                }
                if (txtDeliveryAddress.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a delivery address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDeliveryAddress.Focus();
                    return false;
                }
            }
            if (_nUIControl == (int)Dictionary.SalesType.HPA)
            {
                if (txtCtlCustName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter valid HPA customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCtlCustCode.Focus();
                    return false;
                }
            }

            #endregion

            #region Invoice Item validation
            if (dgvLineItem.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Product Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            nTotalQty = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[9].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[9].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            long temp = Convert.ToInt64(oItemRow.Cells[9].Value.ToString().Trim());
                        }
                        catch
                        {
                            MessageBox.Show("Please Input Valid Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    if (oItemRow.Cells[5].Value != null)
                    {
                        try
                        {
                            long temp = Convert.ToInt64(oItemRow.Cells[5].Value.ToString().Trim());
                        }
                        catch
                        {
                            MessageBox.Show("Please Input Valid Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (int.Parse(oItemRow.Cells[10].Value.ToString()) != (int)Dictionary.YesOrNoStatus.NO)
                    {
                        if (oItemRow.Cells[7].Value == null)
                        {
                            MessageBox.Show("Please Input Valid Product Barcode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    if (int.Parse(oItemRow.Cells[5].Value.ToString()) > int.Parse(oItemRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("Insufficient current stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (Convert.ToDouble(oItemRow.Cells[16].Value.ToString()) > int.Parse(oItemRow.Cells[18].Value.ToString()))
                    {
                        MessageBox.Show("Collection amount must be same as payable amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (Convert.ToDouble(oItemRow.Cells[3].Value.ToString()) < 0)
                    {
                        MessageBox.Show("Unit price must be grater then 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }

            #endregion

            #region Promo Product Validation
            foreach (DataGridViewRow oItemRowSCard in dvgFreeProduct.Rows)
            {
                if (oItemRowSCard.Index < dvgFreeProduct.Rows.Count)
                {
                    if (int.Parse(oItemRowSCard.Cells[7].Value.ToString()) != (int)Dictionary.YesOrNoStatus.NO)
                    {
                        if (oItemRowSCard.Cells[3].Value == null)
                        {
                            MessageBox.Show("Please select product barcode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (oItemRowSCard.Cells[3].Value.ToString() == "")
                        {
                            MessageBox.Show("Please select product barcode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        char[] splitchar = { ',' };
                        string sProductBarcode = oItemRowSCard.Cells[3].Value.ToString();
                        sProductBarcodeArr = sProductBarcode.Split(splitchar);
                        nArrayLen = sProductBarcodeArr.Length;
                    }
                    if (oItemRowSCard.Cells[2].Value != null)
                    {
                        try
                        {
                            int tem = Convert.ToInt32(oItemRowSCard.Cells[2].Value.ToString().Trim());
                        }
                        catch
                        {
                            MessageBox.Show("Please input valid promo Product qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please input promo Product qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            #endregion

            #region Scratch Card Product Validation
            //foreach (DataGridViewRow oItemRowSCard in dgvScratchCardQty.Rows)
            //{
            //    if (oItemRowSCard.Index < dgvScratchCardQty.Rows.Count - 1)
            //    {
            //        if (oItemRowSCard.Cells[0].Value != null)
            //        {
            //            if (oItemRowSCard.Cells[8].Value == null)
            //            {
            //                MessageBox.Show("Please Select a Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Please Select a Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        if (oItemRowSCard.Cells[6].Value != null)
            //        {
            //            if (oItemRowSCard.Cells[6].Value.ToString().Trim() == "")
            //            {
            //                MessageBox.Show("Please Input valid Scratch Card Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Please Input Scratch Card Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        if (oItemRowSCard.Cells[7].Value != null)
            //        {
            //            if (oItemRowSCard.Cells[7].Value.ToString().Trim() == "")
            //            {
            //                MessageBox.Show("Please Input valid Scratch Card Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Please Input Scratch Card Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }

            //        if (int.Parse(oItemRowSCard.Cells[9].Value.ToString()) != (int)Dictionary.YesOrNoStatus.NO)
            //        {
            //            if (oItemRowSCard.Cells[4].Value == null)
            //            {
            //                MessageBox.Show("Please Input Valid Product Barcode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //            char[] splitchar = { ',' };
            //            string sProductBarcode = oItemRowSCard.Cells[4].Value.ToString();
            //            sProductBarcodeArr = sProductBarcode.Split(splitchar);
            //            nArrayLen = sProductBarcodeArr.Length;
            //        }
            //        else
            //        {
            //            if (oItemRowSCard.Cells[3].Value != null)
            //            {
            //                try
            //                {
            //                    int tem = Convert.ToInt32(oItemRowSCard.Cells[3].Value.ToString().Trim());
            //                }
            //                catch
            //                {
            //                    MessageBox.Show("Please Input Valid Scratch Card Product Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    return false;
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Please Input Scratch Card Product Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //        }

            //    }
            //}
            #endregion

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
                    if (oItemRow.Cells[14].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Payment Mode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value != null)
                    {
                        try
                        {
                            double tmp = Convert.ToDouble(oItemRow.Cells[3].Value);
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

                    if (int.Parse(oItemRow.Cells[14].Value.ToString()) == (int)Dictionary.PaymentMode.Credit_Card)
                    {
                        if (oItemRow.Cells[15].Value == null)
                        {
                            MessageBox.Show("Please Select Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (int.Parse(oItemRow.Cells[15].Value.ToString()) == -1)
                        {
                            MessageBox.Show("Please Select Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (oItemRow.Cells[16].Value == null)
                        {
                            MessageBox.Show("Please Select Card Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (int.Parse(oItemRow.Cells[16].Value.ToString()) == -1)
                        {
                            MessageBox.Show("Please Select Card Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (oItemRow.Cells[17].Value == null)
                        {
                            MessageBox.Show("Please Select POS Machine", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (int.Parse(oItemRow.Cells[17].Value.ToString()) == -1)
                        {
                            MessageBox.Show("Please Select POS Machine", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (oItemRow.Cells[18].Value == null)
                        {
                            MessageBox.Show("Please Select Card Category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (int.Parse(oItemRow.Cells[18].Value.ToString()) == -1)
                        {
                            MessageBox.Show("Please Select Card Category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (oItemRow.Cells[12].Value.ToString() == "")
                        {
                            MessageBox.Show("Please input Approval Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }

                }
            }
            #endregion

            #region Charges & Discount Validation
            if (dgvSalesInvoiceDiscount.Rows.Count == 0)
            {
                //MessageBox.Show("Please Input Payment Collection ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return false;
            }
            #endregion 

            return true;
        }

        bool IsValidEmail(string email)
        {
            if (chkInvoiceSend.Checked)
            {
                try
                {
                    var IsValid = Regex.IsMatch(email,
                      @"^(?("")("".+?(?<!\\)""@)|(([a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                    //var addr = new System.Net.Mail.MailAddress(email);
                    //return addr.Address == email;

                    return IsValid;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public SalesInvoice GetDataForSalesInvoice(SalesInvoice _oSalesInvoice)
        {
            _oSalesInvoice.InvoiceDate = oSystemInfo.OperationDate;
            _oSalesInvoice.InvoiceStatus = (int)Dictionary.InvoiceStatus.DELIVERED;
            _oSalesInvoice.CustomerID = nCustomerID;
            _oSalesInvoice.WarehouseID = oSystemInfo.WarehouseID;
            try
            {
                _oSalesInvoice.InvoiceAmount = Convert.ToDouble(txtNetPay.Text);
            }
            catch
            {
                _oSalesInvoice.InvoiceAmount = 0;
            }
            try
            {
                _oSalesInvoice.Discount = Convert.ToDouble(txtTotalDiscount.Text);
            }
            catch
            {
                _oSalesInvoice.Discount = 0;
            }
            _oSalesInvoice.Remarks = txtRemarks.Text;
            _oSalesInvoice.OrderID = -1;
            _oSalesInvoice.SalesPersonID = oEmployees[cmbEmpoyee.SelectedIndex - 1].EmployeeID;
            _oSalesInvoice.CreateDate = DateTime.Now;
            _oSalesInvoice.InvoiceTypeID = (int)Dictionary.InvoiceType.CASH;
            _oSalesInvoice.UserID = Utility.UserId;
            _oSalesInvoice.DeliveryAddress = txtDeliveryAddress.Text;
            _oSalesInvoice.PriceOptionID = (int)Dictionary.PriceOption.RSP;
            _oSalesInvoice.DeliveredBy = Utility.UserId;
            _oSalesInvoice.DeliveryDate = DateTime.Now.Date;
            _oSalesInvoice.DueAmount = 0;
            try
            {
                _oSalesInvoice.OtherCharge = Convert.ToDouble(txtTotalCharge.Text);
            }
            catch
            {
                _oSalesInvoice.OtherCharge = 0;
            }
            _oSalesInvoice.Terminal = (int)Dictionary.Terminal.Branch_Office;
            _oSalesInvoice.SundryCustomerID = oRetailConsumer.ConsumerID;
            //if (_nUIControl == (int)Dictionary.SalesType.B2B || _nUIControl == (int)Dictionary.SalesType.Dealer)
            //    // _oSalesInvoice.ThanaID = ctlCustomer1.SelectedCustomer.ThanaID;
            //    _oSalesInvoice.ThanaID = _oCustomer.ThanaID;
            //else _oSalesInvoice.ThanaID = oThana[cmbThana.SelectedIndex - 1].GeoLocationID;

            _oSalesInvoice.ThanaID = oThana[cmbThana.SelectedIndex - 1].GeoLocationID;
            #region Get Line Item

            if (dgvLineItem.Rows.Count > 1)
            {
                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                    {
                        SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();
                        _oSalesInvoiceItem.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                        try
                        {
                            _oSalesInvoiceItem.Quantity = int.Parse(oItemRow.Cells[5].Value.ToString());

                        }
                        catch
                        {
                            _oSalesInvoiceItem.Quantity = 0;

                        }

                        _oSalesInvoiceItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                        _oProductDetail = new ProductDetail();
                        _oProductDetail.GetPriceConsideringEffectiveDate(Convert.ToDateTime(oSystemInfo.OperationDate),
                            _oSalesInvoiceItem.ProductID);
                        _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                        _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                        if (Convert.ToInt32(oItemRow.Cells[25].Value.ToString()) == (int)Dictionary.VATType.IMPORTED_15 || Convert.ToInt32(oItemRow.Cells[25].Value.ToString()) == (int)Dictionary.VATType.LOCAL_15)
                        {
                            try
                            {
                                //double CalculativeTP = 0;
                                //TPVATProduct _oTPVATProduct = new TPVATProduct();
                                //if (_oTPVATProduct.IsProductExists(_oSalesInvoiceItem.ProductID))
                                //{
                                //    // CalculativeTP = (Convert.ToDouble(oItemRow.Cells[16].Value.ToString()) - (Convert.ToDouble(oItemRow.Cells[26].Value.ToString()) * _oSalesInvoiceItem.Quantity));
                                //    CalculativeTP = Math.Round(((Convert.ToDouble(oItemRow.Cells[16].Value.ToString()) - (Convert.ToDouble(oItemRow.Cells[26].Value.ToString()) * _oSalesInvoiceItem.Quantity)) / _oSalesInvoiceItem.Quantity) / (1 + _oSalesInvoiceItem.VATAmount), 2, MidpointRounding.AwayFromZero);
                                //}
                                //else
                                //{
                                //    CalculativeTP =
                                //        Math.Round((Convert.ToDouble(oItemRow.Cells[16].Value.ToString()) / _oSalesInvoiceItem.Quantity) / (1 + _oSalesInvoiceItem.VATAmount), 2,
                                //            MidpointRounding.AwayFromZero);
                                //}

                                //if (CalculativeTP < _oProductDetail.TradePrice)
                                //{
                                //    _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                                //}
                                //else
                                //{
                                //    _oSalesInvoiceItem.TradePrice = CalculativeTP;
                                //}

                                TPVATProduct oTPVATProduct = new TPVATProduct();
                                if (oTPVATProduct.IsProductExists(_oSalesInvoiceItem.ProductID))
                                {
                                    _oSalesInvoiceItem.TradePrice = oTPVATProduct.TradePrice;
                                }
                                else
                                {
                                    double _CalculativeTP = 0;
                                    _CalculativeTP =
                                        Math.Round((Convert.ToDouble(oItemRow.Cells[16].Value.ToString()) / _oSalesInvoiceItem.Quantity) / (1 + _oSalesInvoiceItem.VATAmount), 2,
                                            MidpointRounding.AwayFromZero);

                                    if (_CalculativeTP < _oProductDetail.TradePrice)
                                    {
                                        _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                                    }
                                    else
                                    {
                                        _oSalesInvoiceItem.TradePrice = _CalculativeTP;
                                    }

                                }

                            }
                            catch
                            {
                                _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                            }

                        }
                        else
                        {

                            if (Convert.ToInt32(oItemRow.Cells[24].Value.ToString()) == (int)Dictionary.IsVatApplicableonNetPrice.YES)
                            {

                                try
                                {
                                    _oSalesInvoiceItem.TradePrice =
                                            Math.Round((Convert.ToDouble(oItemRow.Cells[16].Value.ToString()) / _oSalesInvoiceItem.Quantity) / (1 + _oSalesInvoiceItem.VATAmount), 2,
                                                MidpointRounding.AwayFromZero);

                                }
                                catch
                                {
                                    _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                                }
                            }
                            else
                            {
                                if (_oSalesInvoiceItem.UnitPrice == 0)
                                {
                                    _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                                }
                                else
                                {
                                    TPVATProduct _oTPVATProduct = new TPVATProduct();
                                    if (_oTPVATProduct.IsProductExists(_oSalesInvoiceItem.ProductID))
                                    {

                                        _oSalesInvoiceItem.TradePrice = _oTPVATProduct.TradePrice;
                                    }
                                    else
                                    {
                                        _oSalesInvoiceItem.TradePrice =
                                            Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 2,
                                                MidpointRounding.AwayFromZero);
                                    }
                                }
                            }
                        }
                        _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;
                        int nIsFreeProduct = 0;
                        int nFreeQty = 0;
                        string sFreeQtyScratchCardNo = "";
                        string sFreeQtyScratchCardDescription = "";

                        foreach (DataGridViewRow oItemProdRow in dvgFreeProduct.Rows)
                        {
                            if (oItemProdRow.Index < dvgFreeProduct.Rows.Count)
                            {
                                if (_oSalesInvoiceItem.ProductID == int.Parse(oItemProdRow.Cells[5].Value.ToString()))
                                {
                                    nIsFreeProduct = (int)Dictionary.YesOrNoStatus.YES;
                                    nFreeQty = nFreeQty + int.Parse(oItemProdRow.Cells[2].Value.ToString());
                                }

                            }
                        }

                        foreach (DataGridViewRow oItemSCQRow in dgvSalesInvoiceDiscount.Rows)
                        {
                            if (int.Parse(oItemSCQRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Free_Product)
                            {
                                if (oItemSCQRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                                {
                                    if (_oSalesInvoiceItem.ProductID == int.Parse(oItemSCQRow.Cells[7].Value.ToString()))
                                    {
                                        nIsFreeProduct = (int)Dictionary.YesOrNoStatus.YES;
                                        nFreeQty = nFreeQty + int.Parse(oItemSCQRow.Cells[8].Value.ToString());
                                        sFreeQtyScratchCardNo = oItemSCQRow.Cells[4].Value.ToString();
                                        sFreeQtyScratchCardDescription = oItemSCQRow.Cells[5].Value.ToString();
                                    }
                                }
                            }

                        }


                        try
                        {
                            _oSalesInvoiceItem.IsFreeProduct = nIsFreeProduct;

                        }
                        catch
                        {
                            _oSalesInvoiceItem.IsFreeProduct = 0;

                        }

                        try
                        {
                            _oSalesInvoiceItem.FreeQty = nFreeQty;
                        }
                        catch
                        {
                            _oSalesInvoiceItem.FreeQty = 0;

                        }

                        try
                        {
                            _oSalesInvoiceItem.TotalCharge = Convert.ToDouble(oItemRow.Cells[12].Value.ToString());
                        }
                        catch
                        {
                            _oSalesInvoiceItem.TotalCharge = 0;
                        }
                        try
                        {
                            _oSalesInvoiceItem.TotalDiscount =
                                Convert.ToDouble(oItemRow.Cells[15].Value.ToString());
                        }
                        catch
                        {
                            _oSalesInvoiceItem.TotalDiscount = 0;
                        }
                        _oSalesInvoice.Add(_oSalesInvoiceItem);
                    }
                }
            }

            #endregion

            #region Get Free/Promotional Product

            if (dvgFreeProduct.Rows.Count > 0)
            {
                int nCount = 0;
                foreach (DataGridViewRow oItemRow in dvgFreeProduct.Rows)
                {
                    if (oItemRow.Index < dvgFreeProduct.Rows.Count)
                    {
                        foreach (DataGridViewRow oItemLineRow in dgvLineItem.Rows)
                        {
                            if (oItemLineRow.Index < dgvLineItem.Rows.Count - 1)
                            {
                                if (int.Parse(oItemRow.Cells[5].Value.ToString()) ==
                                    int.Parse(oItemLineRow.Cells[9].Value.ToString()))
                                {
                                    nCount++;
                                }

                            }
                        }
                        if (nCount == 0)
                        {
                            SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();
                            _oSalesInvoiceItem.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                            _oSalesInvoiceItem.Quantity = 0;
                            _oProductDetail = new ProductDetail();
                            _oProductDetail.GetPriceConsideringEffectiveDate(
                                Convert.ToDateTime(oSystemInfo.OperationDate), _oSalesInvoiceItem.ProductID);
                            _oSalesInvoiceItem.UnitPrice = _oProductDetail.RSP;
                            _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;

                            if (_oSalesInvoiceItem.UnitPrice == 0)
                                _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                            else _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / 1.02, 4);

                            _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;
                            _oSalesInvoiceItem.IsFreeProduct = (int)Dictionary.YesOrNoStatus.YES;
                            _oSalesInvoiceItem.FreeQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                            _oSalesInvoiceItem.TotalCharge = 0;
                            _oSalesInvoiceItem.TotalDiscount = 0;
                            _oSalesInvoice.Add(_oSalesInvoiceItem);
                        }
                    }

                }
            }

            #endregion

            #region Get Scratch Card Product

            if (dgvSalesInvoiceDiscount.Rows.Count > 0)
            {
                int nCount = 0;

                foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                {
                    if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                    {
                        if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Free_Product)
                        {
                            foreach (DataGridViewRow oItemLineRow in dgvLineItem.Rows)
                            {
                                if (oItemLineRow.Index < dgvLineItem.Rows.Count - 1)
                                {
                                    if (int.Parse(oItemRow.Cells[7].Value.ToString()) ==
                                        int.Parse(oItemLineRow.Cells[9].Value.ToString()))
                                    {
                                        nCount++;
                                    }
                                }
                            }

                            if (nCount == 0)
                            {

                                SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                                _oSalesInvoiceItem.ProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                                _oSalesInvoiceItem.Quantity = 0;
                                _oProductDetail = new ProductDetail();
                                _oProductDetail.GetPriceConsideringEffectiveDate(
                                    Convert.ToDateTime(oSystemInfo.OperationDate), _oSalesInvoiceItem.ProductID);
                                _oSalesInvoiceItem.UnitPrice = _oProductDetail.RSP;
                                _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                                if (_oSalesInvoiceItem.UnitPrice == 0)
                                    _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                                else _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / 1.02, 4);
                                _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;
                                _oSalesInvoiceItem.IsFreeProduct = (int)Dictionary.YesOrNoStatus.YES;
                                _oSalesInvoiceItem.FreeQty = int.Parse(oItemRow.Cells[8].Value.ToString());
                                _oSalesInvoiceItem.TotalCharge = 0;
                                _oSalesInvoiceItem.TotalDiscount = 0;
                                _oSalesInvoice.Add(_oSalesInvoiceItem);
                            }
                        }
                    }

                }
            }
            #endregion

            return _oSalesInvoice;
        }

        public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction)
        {
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
            _oCustomerTransaction.TranDate = DateTime.Now;
            _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
            _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
            _oCustomerTransaction.Terminal = 1;
            _oCustomerTransaction.Remarks = txtRemarks.Text;
            _oCustomerTransaction.UserID = Utility.UserId;
            _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE;

            return _oCustomerTransaction;
        }

        public StockTran SetData(StockTran oStockTran, SalesInvoice _oSalesInvoice)
        {
            oStockTran.TranNo = _oSalesInvoice.RefDetails != null ? _oSalesInvoice.RefDetails : _oSalesInvoice.InvoiceNo;
            oStockTran.FromChannelID = oSystemInfo.ChannelID;
            oStockTran.FromWHID = _oSalesInvoice.WarehouseID;
            oStockTran.ToChannelID = (int)Dictionary.SystemChannel.SYS_CHANNEL;
            oStockTran.ToWHID = (int)Dictionary.SystemWarehouse.SYS_WAREHOUSE;
            oStockTran.Remarks = _oSalesInvoice.Remarks;
            oStockTran.TranDate = Convert.ToDateTime(oSystemInfo.OperationDate);
            foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
            {
                StockTranItem oItem = new StockTranItem();
                oItem.ProductID = oSalesInvoiceItem.ProductID;
                oItem.Qty = oSalesInvoiceItem.FreeQty + oSalesInvoiceItem.Quantity;
                oItem.StockPrice = oSalesInvoiceItem.CostPrice;
                oItem.IsFreeProduct = oSalesInvoiceItem.IsFreeProduct;
                // oItem.InvoiceID = oSalesInvoiceItem.InvoiceID;
                oStockTran.Add(oItem);

                //StockTranItem oItem = new StockTranItem();
                //oItem.ProductID = oSalesInvoiceItem.ProductID;
                //if (oSalesInvoiceItem.IsFreeProduct == 0)
                //    oItem.Qty = oSalesInvoiceItem.Quantity;
                //else oItem.Qty = oSalesInvoiceItem.FreeQty;
                //oItem.StockPrice = oSalesInvoiceItem.CostPrice;
                //oStockTran.Add(oItem);
            }
            return oStockTran;
        }

        public bool CheckProductID(int nProductID)
        {
            int nCount = 0;
            foreach (int PID in ProductIDList)
            {
                if (PID == nProductID)
                    nCount++;
            }
            if (nCount == 0)
                return true;
            else return false;

        }

        public DutyTran GetDataForVAT11(DutyTran oDutyTranVAT11)
        {
            oDutyTranVAT11 = new DutyTran();

            DateTime day = Convert.ToDateTime(oSystemInfo.OperationDate);
            DateTime time = DateTime.Now;
            DateTime combine = day.Add(time.TimeOfDay);

            oDutyTranVAT11.DutyTranDate = Convert.ToDateTime(combine);
            oDutyTranVAT11.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT11.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11;
            oDutyTranVAT11.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT11.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT11.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT11.DutyAccountID = (int)Dictionary.SupplyType.IMPORTED;

            foreach (SalesInvoiceItem oItem in _oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                // _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh(oItem.ProductID);
                if (_oProductDetail.VATApplicable == (int)Dictionary.YesOrNoStatus.YES)
                {
                    if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.IMPORTED)
                    {
                        DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                        oDutyTranDetail.ProductID = oItem.ProductID;
                        oDutyTranDetail.Qty = ((int)oItem.Quantity + (int)oItem.FreeQty);
                        if (CheckProductID(oDutyTranDetail.ProductID))
                        {
                            if (oItem.UnitPrice == 0)
                            {
                                CustomerDetail oCustomerDetail = new CustomerDetail();
                                oCustomerDetail.CustomerID = _oSalesInvoice.CustomerID;
                                oCustomerDetail.refresh();

                                if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + oItem.VATAmount), 2,
                                        MidpointRounding.AwayFromZero);
                                    oDutyTranDetail.DutyRate = oItem.VATAmount;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + oItem.VATAmount), 2,
                                        MidpointRounding.AwayFromZero);
                                    oDutyTranDetail.DutyRate = oItem.VATAmount;
                                }
                            }
                            else
                            {
                                TPVATProduct _oTPVATProduct = new TPVATProduct();
                                if (_oTPVATProduct.IsProductExists(oItem.ProductID))
                                {
                                    oDutyTranDetail.DutyPrice = _oTPVATProduct.TradePrice;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(oItem.UnitPrice / (1 + oItem.VATAmount), 2,
                                        MidpointRounding.AwayFromZero);
                                }


                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                        }
                        else
                        {
                            oDutyTranDetail.DutyPrice = 0;
                            oDutyTranDetail.DutyRate = 0;
                        }

                        _DutyImportBalance = _DutyImportBalance +
                                             oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                        oDutyTranVAT11.Add(oDutyTranDetail);
                    }
                }
            }
            oDutyTranVAT11.Amount = _DutyImportBalance;

            return oDutyTranVAT11;
        }

        public DutyTran GetDataForVAT11KA(DutyTran oDutyTranVAT11KA)
        {
            oDutyTranVAT11KA = new DutyTran();

            DateTime day = Convert.ToDateTime(oSystemInfo.OperationDate);
            DateTime time = DateTime.Now;
            DateTime combine = day.Add(time.TimeOfDay);


            oDutyTranVAT11KA.DutyTranDate = Convert.ToDateTime(combine);
            oDutyTranVAT11KA.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT11KA.ChallanTypeID = (int)Dictionary.ChallanType.VAT_11_KA;
            oDutyTranVAT11KA.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT11KA.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT11KA.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT11KA.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT11KA.DutyAccountID = (int)Dictionary.SupplyType.LOCAL;

            foreach (SalesInvoiceItem oItem in _oSalesInvoice)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.Refresh(oItem.ProductID);
                if (_oProductDetail.VATApplicable == (int)Dictionary.YesOrNoStatus.YES)
                {
                    if (_oProductDetail.SupplyType == (int)Dictionary.SupplyType.LOCAL)
                    {
                        DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                        oDutyTranDetail.ProductID = oItem.ProductID;
                        oDutyTranDetail.Qty = ((int)oItem.Quantity + (int)oItem.FreeQty);
                        if (CheckProductID(oDutyTranDetail.ProductID))
                        {
                            if (oItem.UnitPrice == 0)
                            {
                                CustomerDetail oCustomerDetail = new CustomerDetail();
                                oCustomerDetail.CustomerID = _oSalesInvoice.CustomerID;
                                oCustomerDetail.refresh();

                                if (oCustomerDetail.ChannelType == (int)Dictionary.ChannelType.DISTRIBUTION)
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + oItem.VATAmount), 2,
                                        MidpointRounding.AwayFromZero);
                                    oDutyTranDetail.DutyRate = oItem.VATAmount;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + oItem.VATAmount), 2,
                                        MidpointRounding.AwayFromZero);
                                    oDutyTranDetail.DutyRate = oItem.VATAmount;
                                }
                            }
                            else
                            {
                                TPVATProduct _oTPVATProduct = new TPVATProduct();
                                if (_oTPVATProduct.IsProductExists(oItem.ProductID))
                                {
                                    oDutyTranDetail.DutyPrice = _oTPVATProduct.TradePrice;
                                }
                                else
                                {
                                    oDutyTranDetail.DutyPrice = Math.Round(oItem.UnitPrice / (1 + oItem.VATAmount), 2,
                                        MidpointRounding.AwayFromZero);
                                }

                                oDutyTranDetail.DutyRate = oItem.VATAmount;
                            }
                        }
                        else
                        {
                            oDutyTranDetail.DutyPrice = 0;
                            oDutyTranDetail.DutyRate = 0;
                        }

                        _DutyLocalBalance = _DutyLocalBalance +
                                            oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                        oDutyTranVAT11KA.Add(oDutyTranDetail);
                    }
                }
            }
            oDutyTranVAT11KA.Amount = _DutyLocalBalance;

            return oDutyTranVAT11KA;
        }

        public DutyTran GetDataForVAT63(DutyTran oDutyTranVAT63)
        {
            oDutyTranVAT63 = new DutyTran();

            DateTime day = Convert.ToDateTime(oSystemInfo.OperationDate);
            DateTime time = DateTime.Now;
            DateTime combine = day.Add(time.TimeOfDay);

            oDutyTranVAT63.DutyTranDate = Convert.ToDateTime(combine);
            oDutyTranVAT63.WHID = _oSalesInvoice.WarehouseID;
            oDutyTranVAT63.ChallanTypeID = (int)Dictionary.ChallanType.VAT_63;
            oDutyTranVAT63.DutyTypeID = (int)Dictionary.DutyType.VAT;
            oDutyTranVAT63.DocumentNo = _oSalesInvoice.InvoiceNo;
            oDutyTranVAT63.RefID = int.Parse(_oSalesInvoice.InvoiceID.ToString());
            oDutyTranVAT63.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
            oDutyTranVAT63.DutyAccountID = 3;

            DutyAccounts oDetail = new DutyAccounts();
            oDetail.GetDutyDetailNew("Invoice", Convert.ToInt32(_oSalesInvoice.InvoiceID));

            foreach (DutyAccount oItem in oDetail)
            {

                DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                oDutyTranDetail.ProductID = oItem.ProductID;
                oDutyTranDetail.Qty = oItem.Qty;
                oDutyTranDetail.DutyPrice = oItem.DutyPriceForRetail;
                oDutyTranDetail.DutyRate = oItem.DutyRate;
                oDutyTranDetail.WHID = oSystemInfo.WarehouseID;
                oDutyTranDetail.UnitPrice = oItem.UnitPrice;
                oDutyTranDetail.VAT = (oItem.DutyPriceForRetail * oItem.DutyRate) * oItem.Qty;
                oDutyTranDetail.VATType = oItem.VATType;
                DutyTran oVatPaidData = new DutyTran();
                oDutyTranDetail.VATPaidQty = oVatPaidData.GetVATPaidQty(oItem.ProductID, _oSalesInvoice.InvoiceNo);

                _NewDutyBalance = _NewDutyBalance + oDutyTranDetail.VAT;
                oDutyTranVAT63.Add(oDutyTranDetail);


            }
            oDutyTranVAT63.Amount = _NewDutyBalance;

            return oDutyTranVAT63;
        }

        public void InvoiceWiseBarcode()
        {
            SL = "";

            _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
            _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
            _oSalesInvoiceProductSerials.GetProductByInvoice(_oSalesInvoice.InvoiceID);
            foreach (SalesInvoiceProductSerial SIPS in _oSalesInvoiceProductSerials)
            {

                string PCode = "";

                _oSIPSs = new SalesInvoiceProductSerials();
                _oSIPSs.GetBarcodeByInvoiceNProduct(SIPS.InvoiceID, SIPS.ProductID);

                foreach (SalesInvoiceProductSerial SIPSs in _oSIPSs)
                {
                    if (PCode == "")
                    {
                        PCode = "<" + SIPSs.ProductCode + ">";
                    }
                    else
                    {
                        PCode = " ";
                    }
                    if (SL != "")
                    {
                        SL = SL + ",";
                    }
                    SL = SL + PCode + SIPSs.ProductSerialNo;
                }
            }
        }
        public void PrintRetailInvoice(long nInvoiceID, bool _bInvoiceSend)
        {
            string sBarcode = "";
            oDSSalesInvoiceProduct = new DSSalesInvoiceDetail();
            oDSFreeGiftProduct = new DSSalesInvoiceDetail();
            oDSSalesInvoiceDetail = new DSSalesInvoiceDetail();
            oTELLib = new TELLib();
            orptSalesInvoice = new rptSalesInvoice();
            orptSalesInvoice.InvoiceID = nInvoiceID;
            orptSalesInvoice.RetailRefresh();
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = Convert.ToInt32(orptSalesInvoice.SalesPersonID);
            oEmployee.RefreshForPOS();

            foreach (rptSalesInvoiceDetail orptSalesInvoiceDetail in orptSalesInvoice)
            {
                if (orptSalesInvoiceDetail.Quantity != 0)
                {
                    DSSalesInvoiceDetail.SalesProductRow oSalesProductRow = oDSSalesInvoiceProduct.SalesProduct.NewSalesProductRow();

                    oSalesProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oSalesProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oSalesProductRow.UnitPrice = orptSalesInvoiceDetail.UnitPrice;
                    oSalesProductRow.Qty = orptSalesInvoiceDetail.Quantity;
                    oSalesProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oSalesProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    oDSSalesInvoiceProduct.SalesProduct.AddSalesProductRow(oSalesProductRow);
                    oDSSalesInvoiceProduct.AcceptChanges();

                    if (sBarcode == "")
                    {
                        sBarcode = orptSalesInvoiceDetail.Barcode;
                    }
                    else sBarcode = sBarcode + "," + orptSalesInvoiceDetail.Barcode;

                }
                if (orptSalesInvoiceDetail.IsFreeProduct == (int)Dictionary.YesOrNoStatus.YES)
                {
                    DSSalesInvoiceDetail.FreeGiftProductRow oFreeGiftProductRow = oDSFreeGiftProduct.FreeGiftProduct.NewFreeGiftProductRow();

                    oFreeGiftProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oFreeGiftProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oFreeGiftProductRow.Qty = orptSalesInvoiceDetail.FreeQty;
                    oFreeGiftProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oFreeGiftProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    oDSFreeGiftProduct.FreeGiftProduct.AddFreeGiftProductRow(oFreeGiftProductRow);
                    oDSFreeGiftProduct.AcceptChanges();
                }
            }
            oDSSalesInvoiceDetail.Merge(oDSSalesInvoiceProduct);
            oDSSalesInvoiceDetail.Merge(oDSFreeGiftProduct);
            oDSSalesInvoiceDetail.AcceptChanges();
            if (rdoExistingConsumer.Checked == false)
            {
                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerID = int.Parse(orptSalesInvoice.SundryCustomerID.ToString());
                oRetailConsumer.CustomerID = int.Parse(orptSalesInvoice.CustomerID.ToString());
            }
            oRetailConsumer.RefreshForPOS();

            rptRetailInvoiceNew doc;
            doc = new rptRetailInvoiceNew();
            doc.SetDataSource(oDSSalesInvoiceDetail);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("Address", oSystemInfo.WarehouseAddress + ", Outlet Phone No:" + oSystemInfo.WarehousePhoneNo);
            doc.SetParameterValue("Mobile", oSystemInfo.WarehouseCellNo + ", e-mail:" + oSystemInfo.WarehouseEmail);
            doc.SetParameterValue("HC", oSystemInfo.HCMobileNo + ", e-mail:" + oSystemInfo.HCEmail);
            if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Retail)
            {
                doc.SetParameterValue("IsCustomer", true);
            }
            else
            {
                doc.SetParameterValue("IsCustomer", false);
            }
            doc.SetParameterValue("Customer", orptSalesInvoice.CustomerName + " [" + orptSalesInvoice.CustomerCode + "]");
            doc.SetParameterValue("ShippingAddress", orptSalesInvoice.DeliveryAddress);
            doc.SetParameterValue("CustomerName", oRetailConsumer.ConsumerName);
            if (oRetailConsumer.SecondaryConsumer == "")
            {
                doc.SetParameterValue("IsContact", true);
            }
            else
            {
                doc.SetParameterValue("IsContact", false);
            }
            doc.SetParameterValue("SecondaryConsumer", oRetailConsumer.SecondaryConsumer);
            doc.SetParameterValue("SecondaryMobileNo", oRetailConsumer.SecondaryMobileNo);
            doc.SetParameterValue("CustomerCode", oRetailConsumer.ConsumerCode);
            doc.SetParameterValue("CustomerAddress", oRetailConsumer.Address + ' ' + orptSalesInvoice.ThanaName);
            doc.SetParameterValue("CustomerPhoneNo", oRetailConsumer.PhoneNo);
            doc.SetParameterValue("CustomerCellNo", oRetailConsumer.CellNo);
            doc.SetParameterValue("Email", oRetailConsumer.Email);
            doc.SetParameterValue("EmployeeName", oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");
            doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");
            doc.SetParameterValue("RefInvoice", "");
            doc.SetParameterValue("InvoiceNo", orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("W/H", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
            doc.SetParameterValue("DeliveryW/H", "[" + orptSalesInvoice.WarehouseShortcode + "]" + "-" + orptSalesInvoice.WarehouseName);

            RetailSalesInvoices oRetailDiscounCharges = new RetailSalesInvoices();
            oRetailDiscounCharges.GetRetailInvoiceDiscountCharge(nInvoiceID);
            string sCharge = "";
            string sDiscount = "";
            double _TotalDiscount = 0;
            double _TotalCharge = 0;
            foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailDiscounCharges)
            {
                if (oRetailSalesInvoice.Type == (int)Dictionary.DiscountChargeType.Charge)
                {
                    if (sCharge == "")
                    {
                        sCharge = oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    else
                    {
                        sCharge = sCharge + '|' + oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    _TotalCharge = _TotalCharge + oRetailSalesInvoice.Amount;

                }
                else if (oRetailSalesInvoice.Type == (int)Dictionary.DiscountChargeType.Discount)
                {
                    if (sDiscount == "")
                    {
                        sDiscount = oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    else
                    {
                        sDiscount = sDiscount + '|' + oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    _TotalDiscount = _TotalDiscount + oRetailSalesInvoice.Amount;
                }

            }
            doc.SetParameterValue("ChargeDetail", sCharge.ToString());
            doc.SetParameterValue("DiscountDetail", sDiscount.ToString());
            doc.SetParameterValue("TotalCharge", oTELLib.TakaFormat(_TotalCharge));
            doc.SetParameterValue("TotalDiscount", oTELLib.TakaFormat(_TotalDiscount));
            doc.SetParameterValue("InvoiceAmount", orptSalesInvoice.InvoiceAmount);
            doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(orptSalesInvoice.InvoiceAmount));

            PaymentModes oPaymentModes = new PaymentModes();
            oPaymentModes.GetPaymentByInvoice(nInvoiceID);
            string sPaymentDetail = "";
            double _TotalPayment = 0;
            foreach (PaymentMode oPaymentMode in oPaymentModes)
            {
                if (sPaymentDetail == "")
                {
                    sPaymentDetail = oPaymentMode.PaymentModeName + ':' + oTELLib.TakaFormat(oPaymentMode.Amount);
                }
                else
                {
                    sPaymentDetail = sPaymentDetail + '|' + oPaymentMode.PaymentModeName + ':' + oTELLib.TakaFormat(oPaymentMode.Amount);
                }
                _TotalPayment = _TotalPayment + oPaymentMode.Amount;

            }

            doc.SetParameterValue("PaymentModeDetail", sPaymentDetail.ToString());
            doc.SetParameterValue("TotalPayment", oTELLib.TakaFormat(_TotalPayment));

            if (Utility.CompanyInfo == "TML")
            {
                doc.SetParameterValue("IsTML", true);
            }
            else
            {
                doc.SetParameterValue("IsTML", false);
            }

            doc.SetParameterValue("Barcode", SL);

            doc.SetParameterValue("Remarks", orptSalesInvoice.Remarks);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            if (orptSalesInvoice.Flag == true)
                doc.SetParameterValue("IsVisible", true);
            else doc.SetParameterValue("IsVisible", false);

            SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan = new SalesInvoiceEcommerceLeadChallan();
            oSalesInvoiceEcommerceLeadChallan.GetOrderNobyInvNo(orptSalesInvoice.InvoiceNo.ToString());
            if (oSalesInvoiceEcommerceLeadChallan.ChallanNo != null)
            {
                doc.SetParameterValue("EcommOrderNo", oSalesInvoiceEcommerceLeadChallan.ChallanNo.ToString());
            }
            else
            {
                doc.SetParameterValue("EcommOrderNo", "");
            }


            PaymentModes oEMI = new PaymentModes();
            oEMI.GetEMiDetail(nInvoiceID);
            string sEMIDetail = "";
            foreach (PaymentMode oPaymentMode in oEMI)
            {
                if (sEMIDetail == "")
                {
                    sEMIDetail = oPaymentMode.EMIDetail;
                }
                else
                {
                    sEMIDetail = sEMIDetail + '\n' + oPaymentMode.EMIDetail;
                }
            }

            doc.SetParameterValue("EMIDetail", sEMIDetail.ToString());

            if (_bInvoiceSend == true)
            {
                Outgoing _oOutgoing = new Outgoing();
                _oOutgoing.CreateInvoicePath();
                doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ExportedInvoice\" + orptSalesInvoice.InvoiceNo.ToString() + ".pdf");
            }
            
            frmPrintPreviewWithoutExport frmView;
            frmView = new frmPrintPreviewWithoutExport();
            frmView.ShowDialog(doc);
        }

        public void PrintRetailInvoiceThermal(long nInvoiceID, bool _bInvoiceSend)
        {
            string sBarcode = "";
            oDSSalesInvoiceProduct = new DSSalesInvoiceDetail();
            oDSFreeGiftProduct = new DSSalesInvoiceDetail();
            oDSSalesInvoiceDetail = new DSSalesInvoiceDetail();
            oTELLib = new TELLib();
            orptSalesInvoice = new rptSalesInvoice();
            orptSalesInvoice.InvoiceID = nInvoiceID;
            orptSalesInvoice.RetailRefresh();
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = Convert.ToInt32(orptSalesInvoice.SalesPersonID);
            oEmployee.RefreshForPOS();

            foreach (rptSalesInvoiceDetail orptSalesInvoiceDetail in orptSalesInvoice)
            {
                if (orptSalesInvoiceDetail.Quantity != 0)
                {
                    DSSalesInvoiceDetail.SalesProductRow oSalesProductRow = oDSSalesInvoiceProduct.SalesProduct.NewSalesProductRow();

                    oSalesProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oSalesProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oSalesProductRow.UnitPrice = orptSalesInvoiceDetail.UnitPrice;
                    oSalesProductRow.Qty = orptSalesInvoiceDetail.Quantity;
                    oSalesProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oSalesProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    oDSSalesInvoiceProduct.SalesProduct.AddSalesProductRow(oSalesProductRow);
                    oDSSalesInvoiceProduct.AcceptChanges();

                    if (sBarcode == "")
                    {
                        sBarcode = orptSalesInvoiceDetail.Barcode;
                    }
                    else sBarcode = sBarcode + "," + orptSalesInvoiceDetail.Barcode;

                }
                if (orptSalesInvoiceDetail.IsFreeProduct == (int)Dictionary.YesOrNoStatus.YES)
                {
                    DSSalesInvoiceDetail.FreeGiftProductRow oFreeGiftProductRow = oDSFreeGiftProduct.FreeGiftProduct.NewFreeGiftProductRow();

                    oFreeGiftProductRow.ProductCode = orptSalesInvoiceDetail.ProductCode;
                    oFreeGiftProductRow.ProductName = orptSalesInvoiceDetail.ProductName;
                    oFreeGiftProductRow.Qty = orptSalesInvoiceDetail.FreeQty;
                    oFreeGiftProductRow.ProductModel = orptSalesInvoiceDetail.ProductModel;
                    oFreeGiftProductRow.ProductDesc = orptSalesInvoiceDetail.ProductDesc;

                    oDSFreeGiftProduct.FreeGiftProduct.AddFreeGiftProductRow(oFreeGiftProductRow);
                    oDSFreeGiftProduct.AcceptChanges();
                }
            }
            oDSSalesInvoiceDetail.Merge(oDSSalesInvoiceProduct);
            oDSSalesInvoiceDetail.Merge(oDSFreeGiftProduct);
            oDSSalesInvoiceDetail.AcceptChanges();
            if (rdoExistingConsumer.Checked == false)
            {
                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerID = int.Parse(orptSalesInvoice.SundryCustomerID.ToString());
                oRetailConsumer.CustomerID = int.Parse(orptSalesInvoice.CustomerID.ToString());
            }
            oRetailConsumer.RefreshForPOS();

            rptRetailInvoiceThermal doc;
            doc = new rptRetailInvoiceThermal();
            doc.SetDataSource(oDSSalesInvoiceDetail);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("Address", oSystemInfo.WarehouseAddress + ", Outlet Phone No:" + oSystemInfo.WarehousePhoneNo);
            doc.SetParameterValue("Mobile", oSystemInfo.WarehouseCellNo + ", e-mail:" + oSystemInfo.WarehouseEmail);
            doc.SetParameterValue("HC", oSystemInfo.HCMobileNo + ", e-mail:" + oSystemInfo.HCEmail);
            if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Retail)
            {
                doc.SetParameterValue("IsCustomer", true);
            }
            else
            {
                doc.SetParameterValue("IsCustomer", false);
            }
            doc.SetParameterValue("Customer", orptSalesInvoice.CustomerName + " [" + orptSalesInvoice.CustomerCode + "]");
            doc.SetParameterValue("ShippingAddress", orptSalesInvoice.DeliveryAddress);
            doc.SetParameterValue("CustomerName", oRetailConsumer.ConsumerName);
            if (oRetailConsumer.SecondaryConsumer == "")
            {
                doc.SetParameterValue("IsContact", true);
            }
            else
            {
                doc.SetParameterValue("IsContact", false);
            }
            doc.SetParameterValue("SecondaryConsumer", oRetailConsumer.SecondaryConsumer);
            doc.SetParameterValue("SecondaryMobileNo", oRetailConsumer.SecondaryMobileNo);
            doc.SetParameterValue("CustomerCode", oRetailConsumer.ConsumerCode);
            doc.SetParameterValue("CustomerAddress", oRetailConsumer.Address + ' ' + orptSalesInvoice.ThanaName);
            doc.SetParameterValue("CustomerPhoneNo", oRetailConsumer.PhoneNo);
            doc.SetParameterValue("CustomerCellNo", oRetailConsumer.CellNo);
            doc.SetParameterValue("Email", oRetailConsumer.Email);
            doc.SetParameterValue("EmployeeName", oEmployee.EmployeeName + " [" + oEmployee.EmployeeCode + "]");
            doc.SetParameterValue("InvoiceTitle", "Invoice (" + oRetailConsumer.SalesTypeName + ")");
            doc.SetParameterValue("RefInvoice", "");
            doc.SetParameterValue("InvoiceNo", orptSalesInvoice.InvoiceNo.ToString());
            doc.SetParameterValue("InvoiceDate", orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("W/H", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
            doc.SetParameterValue("DeliveryW/H", "[" + orptSalesInvoice.WarehouseShortcode + "]" + "-" + orptSalesInvoice.WarehouseName);

            doc.SetParameterValue("VATRegistrationNo", "000002186-0101");
            RetailSalesInvoices oRetailDiscounCharges = new RetailSalesInvoices();
            oRetailDiscounCharges.GetRetailInvoiceDiscountCharge(nInvoiceID);
            string sCharge = "";
            string sDiscount = "";
            double _TotalDiscount = 0;
            double _TotalCharge = 0;
            foreach (RetailSalesInvoice oRetailSalesInvoice in oRetailDiscounCharges)
            {
                if (oRetailSalesInvoice.Type == (int)Dictionary.DiscountChargeType.Charge)
                {
                    if (sCharge == "")
                    {
                        sCharge = oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    else
                    {
                        sCharge = sCharge + '|' + oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    _TotalCharge = _TotalCharge + oRetailSalesInvoice.Amount;

                }
                else if (oRetailSalesInvoice.Type == (int)Dictionary.DiscountChargeType.Discount)
                {
                    if (sDiscount == "")
                    {
                        sDiscount = oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    else
                    {
                        sDiscount = sDiscount + '|' + oRetailSalesInvoice.DiscountTypeName + ':' + oTELLib.TakaFormat(oRetailSalesInvoice.Amount);
                    }
                    _TotalDiscount = _TotalDiscount + oRetailSalesInvoice.Amount;
                }

            }
            doc.SetParameterValue("ChargeDetail", sCharge.ToString());
            doc.SetParameterValue("DiscountDetail", sDiscount.ToString());
            doc.SetParameterValue("TotalCharge", oTELLib.TakaFormat(_TotalCharge));
            doc.SetParameterValue("TotalDiscount", oTELLib.TakaFormat(_TotalDiscount));
            doc.SetParameterValue("InvoiceAmount", orptSalesInvoice.InvoiceAmount);
            doc.SetParameterValue("AmountInWord", oTELLib.TakaWords(orptSalesInvoice.InvoiceAmount));

            PaymentModes oPaymentModes = new PaymentModes();
            oPaymentModes.GetPaymentByInvoice(nInvoiceID);
            string sPaymentDetail = "";
            double _TotalPayment = 0;
            foreach (PaymentMode oPaymentMode in oPaymentModes)
            {
                if (sPaymentDetail == "")
                {
                    sPaymentDetail = oPaymentMode.PaymentModeName + ':' + oTELLib.TakaFormat(oPaymentMode.Amount);
                }
                else
                {
                    sPaymentDetail = sPaymentDetail + '|' + oPaymentMode.PaymentModeName + ':' + oTELLib.TakaFormat(oPaymentMode.Amount);
                }
                _TotalPayment = _TotalPayment + oPaymentMode.Amount;

            }

            doc.SetParameterValue("PaymentModeDetail", sPaymentDetail.ToString());
            doc.SetParameterValue("TotalPayment", oTELLib.TakaFormat(_TotalPayment));

            if (Utility.CompanyInfo == "TML")
            {
                doc.SetParameterValue("IsTML", true);
            }
            else
            {
                doc.SetParameterValue("IsTML", false);
            }

            doc.SetParameterValue("Barcode", SL);

            doc.SetParameterValue("Remarks", orptSalesInvoice.Remarks);
            doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            if (orptSalesInvoice.Flag == true)
                doc.SetParameterValue("IsVisible", true);
            else doc.SetParameterValue("IsVisible", false);

            SalesInvoiceEcommerceLeadChallan oSalesInvoiceEcommerceLeadChallan = new SalesInvoiceEcommerceLeadChallan();
            oSalesInvoiceEcommerceLeadChallan.GetOrderNobyInvNo(orptSalesInvoice.InvoiceNo.ToString());
            if (oSalesInvoiceEcommerceLeadChallan.ChallanNo != null)
            {
                doc.SetParameterValue("EcommOrderNo", oSalesInvoiceEcommerceLeadChallan.ChallanNo.ToString());
            }
            else
            {
                doc.SetParameterValue("EcommOrderNo", "");
            }


            PaymentModes oEMI = new PaymentModes();
            oEMI.GetEMiDetail(nInvoiceID);
            string sEMIDetail = "";
            foreach (PaymentMode oPaymentMode in oEMI)
            {
                if (sEMIDetail == "")
                {
                    sEMIDetail = oPaymentMode.EMIDetail;
                }
                else
                {
                    sEMIDetail = sEMIDetail + '\n' + oPaymentMode.EMIDetail;
                }
            }

            doc.SetParameterValue("EMIDetail", sEMIDetail.ToString());

            if (_bInvoiceSend == true)
            {
                Outgoing _oOutgoing = new Outgoing();
                _oOutgoing.CreateInvoicePath();
                doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ExportedInvoice\" + orptSalesInvoice.InvoiceNo.ToString() + ".pdf");
            }


            //frmPrintPreviewWithoutExport frmView;
            //frmView = new frmPrintPreviewWithoutExport();
            //frmView.ShowDialog(doc);
            doc.PrintToPrinter(1, true, 1, 1);

        }
        private void PrintWarrantyCard(SalesInvoice _oSalesInvoice)
        {
            try
            {
                foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
                {

                    Product oProduct = new Product();
                    oProduct.ProductID = oSalesInvoiceItem.ProductID;
                    oProduct.RefreshByID();
                    {
                        //if (_oSalesInvoice.InvoiceTypeID == 1)
                        //{
                        _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                        _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                        _oSalesInvoiceProductSerial.ProductID = oProduct.ProductID;
                        _oSalesInvoiceProductSerial.GetBarcode();

                        char[] splitchar = { ',' };
                        if (_oSalesInvoiceProductSerial.ProductSerialNo != null)
                        {
                            string sProductBarcode = _oSalesInvoiceProductSerial.ProductSerialNo;
                            sProductBarcodeArr = sProductBarcode.Split(splitchar);
                            nArrayLen = sProductBarcodeArr.Length;
                            for (int i = 0; i < nArrayLen; i++)
                            {
                                PrintWarrantyCard(oSalesInvoiceItem.ProductID, _oSalesInvoice, sProductBarcodeArr[i], chkInvoiceSend.Checked);
                            }
                        }
                        //}
                        //else
                        //{
                        //    PrintWarrantyCardForBulk(oSalesInvoiceItem.ProductID, _oSalesInvoice);
                        //}
                    }

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        private void PrintWarrantyCardThermal(SalesInvoice _oSalesInvoice)
        {
            try
            {
                foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
                {

                    Product oProduct = new Product();
                    oProduct.ProductID = oSalesInvoiceItem.ProductID;
                    oProduct.RefreshByID();
                    {

                        _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                        _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                        _oSalesInvoiceProductSerial.ProductID = oProduct.ProductID;
                        _oSalesInvoiceProductSerial.GetBarcode();

                        char[] splitchar = { ',' };
                        if (_oSalesInvoiceProductSerial.ProductSerialNo != null)
                        {
                            string sProductBarcode = _oSalesInvoiceProductSerial.ProductSerialNo;
                            sProductBarcodeArr = sProductBarcode.Split(splitchar);
                            nArrayLen = sProductBarcodeArr.Length;
                            for (int i = 0; i < nArrayLen; i++)
                            {
                                PrintWarrantyCardThermal(oSalesInvoiceItem.ProductID, _oSalesInvoice, sProductBarcodeArr[i], chkInvoiceSend.Checked);
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();

        }

        private void QRCodeGen(WarrantyParam oWarrantyParam, RetailConsumer oRetailConsumer, SalesInvoice _oSalesInvoice, string sBarcode, string sProductCode, string sProductName)
        {
            ZAM.QRCode.Codec.QRCodeEncoder qrCodeEncoder = new ZAM.QRCode.Codec.QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = ZAM.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE;
            try
            {
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 15;
                qrCodeEncoder.QRCodeErrorCorrect = ZAM.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.M;

                String data = oRetailConsumer.ConsumerCode +
                                "\n" + _oSalesInvoice.InvoiceNo +
                                "\n" + _oSalesInvoice.InvoiceDate.ToString();
                if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Dealer)
                {
                    data = data + "\n" + "" +
                     "\n" + "" +
                     "\n" + "" +
                     "\n" + "";
                }
                else
                {
                    data = data + "\n" + oRetailConsumer.ConsumerName +
                    "\n" + oRetailConsumer.Address +
                    "\n" + oRetailConsumer.CellNo +
                    "\n" + oRetailConsumer.Email;
                }
                data = data + "\n" + sProductCode +
                "\n" + sProductName +
                "\n" + sBarcode +
                "\n" + oWarrantyParam.ServiceWarranty +
                "\n" + oWarrantyParam.PartsWarranty +
                "\n" + oWarrantyParam.SpecialComponentWarranty +
                "\n" + oRetailConsumer.ParentCustomerID;
                if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.Dealer)
                {
                    data = data + "\n" + Convert.ToString(Utility.DealerChannelID);
                }
                else if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.B2B || oRetailConsumer.SalesType == (int)Dictionary.SalesType.B2C)
                {
                    data = data + "\n" + Convert.ToString(Utility.TDCorporateChannelID);
                }
                else if (oRetailConsumer.SalesType == (int)Dictionary.SalesType.HPA)
                {
                    data = data + "\n" + Convert.ToString(Utility.TDHPAChannelID);
                }
                else
                {
                    data = data + "\n" + Convert.ToString(Utility.RetailChannelID);
                }
                iImage = qrCodeEncoder.Encode(data);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void PrintWarrantyCard(int nProductID, SalesInvoice _oSalesInvoice, string sBarcode, bool _bMakePDF)
        {

            //oWarrantyProducts = new WarrantyProducts();

            ConsumerPromotionEngine oWarrantyPromo = new ConsumerPromotionEngine();
            string sExtendedWarranty = oWarrantyPromo.GetWarrantyPromo(Convert.ToDateTime(oSystemInfo.OperationDate), nProductID);


            WarrantyParam oWarrantyParam = new WarrantyParam();

            if (oWarrantyParam.GetWarranty(nProductID, Convert.ToDateTime(oSystemInfo.OperationDate)))
            {

                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerID = int.Parse(_oSalesInvoice.SundryCustomerID.ToString());
                oRetailConsumer.CustomerID = _oSalesInvoice.CustomerID;
                oRetailConsumer.RefreshForPOS();

                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(nProductID);

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = _oSalesInvoice.SalesPersonID;
                oEmployee.RefreshForPOS();

                try
                {
                    oWarrantyParameter = new WarrantyParameter();

                    //oWarrantyParameter.GetNextWarrantyCardNo(int.Parse(_oSalesInvoice.InvoiceID.ToString()), _oSalesInvoice.WarehouseID, nProductID, oWarrantyParam.WarrantyParamID, sBarcode);
                    oWarrantyParameter.InsertSalesInvoiceWarrantyCard(int.Parse(_oSalesInvoice.InvoiceID.ToString()), _oSalesInvoice.WarehouseID, nProductID, oWarrantyParam.WarrantyParamID, sBarcode, sExtendedWarranty, oWarrantyPromo.WarrantyID);

                }
                catch (Exception ex)
                {
                    int Tem = int.Parse("");
                }

                QRCodeGen(oWarrantyParam, oRetailConsumer, _oSalesInvoice, sBarcode, oProductDetail.ProductCode, oProductDetail.ProductName);

                DSQRCode oDSQRCode = new DSQRCode();
                byte[] pImage = imageToByteArray(iImage);
                oDSQRCode.QRCode.AddQRCodeRow(pImage);
                oDSQRCode.AcceptChanges();

                rptWarrantyCard doc;
                doc = new rptWarrantyCard();

                doc.SetDataSource(oDSQRCode);

                doc.SetParameterValue("WarrantyCardNo", oWarrantyParameter.WarrantyCardNo);


                if (sExtendedWarranty != "")
                {
                    doc.SetParameterValue("ExtendedWarranty", "Extended Warranty: " + sExtendedWarranty);
                }
                else
                {
                    doc.SetParameterValue("ExtendedWarranty", "Extended warranty not applicable");
                }

                //doc.SetParameterValue("ExtendedWarranty", sExtendedWarranty);

                doc.SetParameterValue("Service", oWarrantyParam.ServiceWarranty);
                doc.SetParameterValue("Spare", oWarrantyParam.PartsWarranty);
                doc.SetParameterValue("Special", oWarrantyParam.SpecialComponentWarranty);
                if (oRetailConsumer.SalesType != (int)Dictionary.SalesType.Dealer)
                {
                    doc.SetParameterValue("Name", oRetailConsumer.ConsumerName);
                    doc.SetParameterValue("Address", oRetailConsumer.Address);
                    doc.SetParameterValue("Telephone", oRetailConsumer.PhoneNo);
                    doc.SetParameterValue("Mobile", oRetailConsumer.CellNo);
                    doc.SetParameterValue("Email", oRetailConsumer.Email);
                    doc.SetParameterValue("DealerName", "");
                    doc.SetParameterValue("IsDealer", false);
                    doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    doc.SetParameterValue("Name", "");
                    doc.SetParameterValue("Address", "");
                    doc.SetParameterValue("Telephone", "");
                    doc.SetParameterValue("Mobile", "");
                    doc.SetParameterValue("Email", "");
                    doc.SetParameterValue("DealerName", oRetailConsumer.ConsumerName + "/" + Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("yyyyMMdd"));
                    doc.SetParameterValue("IsDealer", true);
                    doc.SetParameterValue("InvoiceDate", "");
                }
                doc.SetParameterValue("ProductName", oProductDetail.ProductName);
                doc.SetParameterValue("BrandName", oProductDetail.BrandDesc);
                doc.SetParameterValue("ProductCode", oProductDetail.ProductCode);

                doc.SetParameterValue("InvoiceNo", _oSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("OutletName", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
                doc.SetParameterValue("Employee", oEmployee.EmployeeName);

                doc.SetParameterValue("Barcode", sBarcode);
                if (oProductDetail.MAGID == 791) //FPTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 792) //HTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 22) //REF
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 811) //FRZ
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 0) //LCAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 25) //RAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 804) //CAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 23) //WM
                {
                    doc.SetParameterValue("SpecialComponent", "Motor");
                }
                else
                {
                    doc.SetParameterValue("SpecialComponent", "SpecialComponent");
                }

                if (_bMakePDF == true)
                {
                    Outgoing _oOutgoing = new Outgoing();
                    _oOutgoing.CreateInvoicePath();
                    doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ExportedInvoice\" + oWarrantyParameter.WarrantyCardNo + ".pdf");
                }

                frmPrintPreviewWithoutExport frmView;
                frmView = new frmPrintPreviewWithoutExport();
                frmView.ShowDialog(doc);
                
            }
        }

        public void PrintWarrantyCardThermal(int nProductID, SalesInvoice _oSalesInvoice, string sBarcode, bool _bMakePDF)
        {

            //oWarrantyProducts = new WarrantyProducts();

            ConsumerPromotionEngine oWarrantyPromo = new ConsumerPromotionEngine();
            string sExtendedWarranty = oWarrantyPromo.GetWarrantyPromo(Convert.ToDateTime(oSystemInfo.OperationDate), nProductID);


            WarrantyParam oWarrantyParam = new WarrantyParam();

            if (oWarrantyParam.GetWarranty(nProductID, Convert.ToDateTime(oSystemInfo.OperationDate)))
            {

                oRetailConsumer = new RetailConsumer();
                oRetailConsumer.ConsumerID = int.Parse(_oSalesInvoice.SundryCustomerID.ToString());
                oRetailConsumer.CustomerID = _oSalesInvoice.CustomerID;
                oRetailConsumer.RefreshForPOS();

                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(nProductID);

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = _oSalesInvoice.SalesPersonID;
                oEmployee.RefreshForPOS();

                try
                {
                    oWarrantyParameter = new WarrantyParameter();

                    //oWarrantyParameter.GetNextWarrantyCardNo(int.Parse(_oSalesInvoice.InvoiceID.ToString()), _oSalesInvoice.WarehouseID, nProductID, oWarrantyParam.WarrantyParamID, sBarcode);
                    oWarrantyParameter.InsertSalesInvoiceWarrantyCard(int.Parse(_oSalesInvoice.InvoiceID.ToString()), _oSalesInvoice.WarehouseID, nProductID, oWarrantyParam.WarrantyParamID, sBarcode, sExtendedWarranty, oWarrantyPromo.WarrantyID);

                }
                catch (Exception ex)
                {
                    int Tem = int.Parse("");
                }

                QRCodeGen(oWarrantyParam, oRetailConsumer, _oSalesInvoice, sBarcode, oProductDetail.ProductCode, oProductDetail.ProductName);

                DSQRCode oDSQRCode = new DSQRCode();
                byte[] pImage = imageToByteArray(iImage);
                oDSQRCode.QRCode.AddQRCodeRow(pImage);
                oDSQRCode.AcceptChanges();

                rptWarrantyCardThermal doc;
                doc = new rptWarrantyCardThermal();

                doc.SetDataSource(oDSQRCode);

                doc.SetParameterValue("WarrantyCardNo", oWarrantyParameter.WarrantyCardNo);


                if (sExtendedWarranty != "")
                {
                    doc.SetParameterValue("ExtendedWarranty", "Extended Warranty: " + sExtendedWarranty);
                }
                else
                {
                    doc.SetParameterValue("ExtendedWarranty", "Extended warranty not applicable");
                }

                //doc.SetParameterValue("ExtendedWarranty", sExtendedWarranty);

                doc.SetParameterValue("Service", oWarrantyParam.ServiceWarranty);
                doc.SetParameterValue("Spare", oWarrantyParam.PartsWarranty);
                doc.SetParameterValue("Special", oWarrantyParam.SpecialComponentWarranty);
                if (oRetailConsumer.SalesType != (int)Dictionary.SalesType.Dealer)
                {
                    doc.SetParameterValue("Name", oRetailConsumer.ConsumerName);
                    doc.SetParameterValue("Address", oRetailConsumer.Address);
                    doc.SetParameterValue("Telephone", oRetailConsumer.PhoneNo);
                    doc.SetParameterValue("Mobile", oRetailConsumer.CellNo);
                    doc.SetParameterValue("Email", oRetailConsumer.Email);
                    doc.SetParameterValue("DealerName", "");
                    doc.SetParameterValue("IsDealer", false);
                    doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    doc.SetParameterValue("Name", "");
                    doc.SetParameterValue("Address", "");
                    doc.SetParameterValue("Telephone", "");
                    doc.SetParameterValue("Mobile", "");
                    doc.SetParameterValue("Email", "");
                    doc.SetParameterValue("DealerName", oRetailConsumer.ConsumerName + "/" + Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("yyyyMMdd"));
                    doc.SetParameterValue("IsDealer", true);
                    doc.SetParameterValue("InvoiceDate", "");
                }
                doc.SetParameterValue("ProductName", oProductDetail.ProductName);
                doc.SetParameterValue("BrandName", oProductDetail.BrandDesc);
                doc.SetParameterValue("ProductCode", oProductDetail.ProductCode);

                doc.SetParameterValue("InvoiceNo", _oSalesInvoice.InvoiceNo.ToString());
                doc.SetParameterValue("OutletName", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
                doc.SetParameterValue("Employee", oEmployee.EmployeeName);

                doc.SetParameterValue("Barcode", sBarcode);
                if (oProductDetail.MAGID == 791) //FPTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 792) //HTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (oProductDetail.MAGID == 22) //REF
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 811) //FRZ
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 0) //LCAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 25) //RAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 804) //CAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (oProductDetail.MAGID == 23) //WM
                {
                    doc.SetParameterValue("SpecialComponent", "Motor");
                }
                else
                {
                    doc.SetParameterValue("SpecialComponent", "SpecialComponent");
                }

                if (_bMakePDF == true)
                {
                    Outgoing _oOutgoing = new Outgoing();
                    _oOutgoing.CreateInvoicePath();
                    doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ExportedInvoice\" + oWarrantyParameter.WarrantyCardNo + ".pdf");
                }

                frmPrintPreviewWithoutExport frmView;
                frmView = new frmPrintPreviewWithoutExport();
                frmView.ShowDialog(doc);

            }
        }

        private void SetProductSerialAll(string sProductSerialNo)
        {
            CJ.Class.POS.DSSalesInvoice.ProductBarcodeRow oProductBarcodeRow = oDSProductBarcodeAll.ProductBarcode.NewProductBarcodeRow();

            oProductBarcodeRow.Bacode = sProductSerialNo;
            oDSProductBarcodeAll.ProductBarcode.AddProductBarcodeRow(oProductBarcodeRow);
            oDSProductBarcodeAll.AcceptChanges();

        }

        public TDDeliveryShipment GetDataDeliveryShipmentData(SalesInvoice _oSalesInvoice)
        {
            TDDeliveryShipment _oTDDeliveryShipment = new TDDeliveryShipment();
            _oTDDeliveryShipment.WHID = _oSalesInvoice.WarehouseID;
            _oTDDeliveryShipment.InvoiceNo = _oSalesInvoice.InvoiceNo;
            _oTDDeliveryShipment.Remarks = _oSalesInvoice.Remarks;
            if (cmbDeliveryMode.Text == "Self Delivery")
            {
                _oTDDeliveryShipment.Status = (int)Dictionary.TDDeliveryShipmentStatus.Delivered;
            }
            else
            {
                if (cmbDeliveryMode.Text == "Company Vehicle")
                {
                    _oTDDeliveryShipment.Status = (int)Dictionary.TDDeliveryShipmentStatus.Undelivered;
                }
                else
                {
                    _oTDDeliveryShipment.Status = (int)Dictionary.TDDeliveryShipmentStatus.Processing_Delivery;
                }
            }
            _oTDDeliveryShipment.CreateDate = DateTime.Now;
            _oTDDeliveryShipment.CreateUserID = Utility.UserId;

            TDDeliveryShipments oTDDeliveryShipments = new TDDeliveryShipments();
            oTDDeliveryShipments.Refresh(_oSalesInvoice.InvoiceNo, 1);

            // Item Details
            foreach (TDDeliveryShipmentItem oItem in oTDDeliveryShipments)
            {
                TDDeliveryShipmentItem _oTDDeliveryShipmentItem = new TDDeliveryShipmentItem();
                _oTDDeliveryShipmentItem.ProductID = oItem.ProductID;
                _oTDDeliveryShipmentItem.UnitPrice = oItem.UnitPrice;
                _oTDDeliveryShipmentItem.Qty = oItem.Qty;
                _oTDDeliveryShipmentItem.ShipmentDate = dtShipmentDate.Value.Date;
                _oTDDeliveryShipmentItem.ShipmentTime = dtShipmentDate.Value;
                _oTDDeliveryShipmentItem.ShipingAddress = txtDeliveryAddress.Text;
                _oTDDeliveryShipmentItem.ContactNo = txtCell.Text;
                if (dtInstallationDate.Checked == true)
                {
                    _oTDDeliveryShipmentItem.InstallationRequired = "Yes";
                    _oTDDeliveryShipmentItem.ExpInstallationDate = dtInstallationDate.Value.Date;
                    _oTDDeliveryShipmentItem.ExpInstallationTime = dtInstallationDate.Value;
                }
                else
                {
                    _oTDDeliveryShipmentItem.InstallationRequired = "No";
                }
                _oTDDeliveryShipmentItem.DeliveryMode = cmbDeliveryMode.Text;
                _oTDDeliveryShipmentItem.VehicleNo = "";
                _oTDDeliveryShipmentItem.FreightCost = 0;
                _oTDDeliveryShipmentItem.LiftingCost = 0;
                _oTDDeliveryShipmentItem.FloorNo = Convert.ToInt32(txtFloor.Text);
                _oTDDeliveryShipmentItem.DistanceKM = Convert.ToDouble(txtKM.Text);
                _oTDDeliveryShipment.Add(_oTDDeliveryShipmentItem);

            }

            return _oTDDeliveryShipment;
        }
        int _nIsDefective = 0;
        private bool DefectiveValidation()
        {
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (int.Parse(oItemRow.Cells[10].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        char[] splitchar = { ',' };

                        int nProductID = Convert.ToInt32(oItemRow.Cells[9].Value);
                        string sProductBarcode = oItemRow.Cells[7].Value.ToString();
                        sProductBarcodeArr = sProductBarcode.Split(splitchar);
                        nArrayLen = sProductBarcodeArr.Length;

                        if (oItemRow.Index == 0)
                        {
                            ProductBarcode oProductBarcode = new ProductBarcode();
                            oProductBarcode.ProductSerialNo = sProductBarcodeArr[0];
                            oProductBarcode.ProductId = nProductID;
                            oProductBarcode.RefreshForDefective();
                            _nIsDefective = oProductBarcode.IsDefective;

                            for (int i = 1; i < nArrayLen; i++)
                            {

                                ProductBarcode oProductBarcode1 = new ProductBarcode();
                                oProductBarcode1.ProductSerialNo = sProductBarcodeArr[i];
                                oProductBarcode1.ProductId = nProductID;

                                oProductBarcode1.RefreshForDefective();

                                if (oProductBarcode1.IsDefective != _nIsDefective)
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < nArrayLen; i++)
                            {
                                ProductBarcode oProductBarcode1 = new ProductBarcode();
                                oProductBarcode1.ProductSerialNo = sProductBarcodeArr[i];
                                oProductBarcode1.ProductId = nProductID;

                                oProductBarcode1.RefreshForDefective();

                                if (oProductBarcode1.IsDefective != _nIsDefective)
                                {
                                    return false;
                                }
                            }
                        }

                    }
                }
            }

            return true;
        }
        private void btSave_Click(object sender, EventArgs e)
        {

            if (ValidateUIInput())
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();

                    oDSProductBarcodeAll = new CJ.Class.POS.DSSalesInvoice();

                    #region Consumer Entry Old

                    //if (_nUIControl == (int)Dictionary.SalesType.Retail ||
                    //    _nUIControl == (int)Dictionary.SalesType.B2C ||
                    //    _nUIControl == (int)Dictionary.SalesType.HPA ||
                    //    _nUIControl == (int)Dictionary.SalesType.eStore)
                    //{
                    //    if (rdoExistingConsumer.Checked == true)
                    //    {
                    //        oRetailConsumer = new RetailConsumer();
                    //        oRetailConsumer.GetConsumerByCode(txtConsumerCode.Text.Trim());
                    //        nCustomerID = oRetailConsumer.CustomerID;
                    //        oRetailConsumer.Email = txtEmail.Text;
                    //        if (btnEmailVerification.Text == "Verified")
                    //        {
                    //            oRetailConsumer.IsVerifiedEmail = 1;
                    //        }
                    //        else
                    //        {
                    //            oRetailConsumer.IsVerifiedEmail = 0;

                    //        }
                    //        oRetailConsumer.UpdateEmail(oSystemInfo.WarehouseID);
                    //    }
                    //    if (rdoLeadCust.Checked == true)
                    //    {
                    //        if (nFromLeadConsumeID != 0)
                    //        {
                    //            oRetailConsumer = new RetailConsumer();
                    //            oRetailConsumer.GetConsumerByCode(sFromLeadConsumerCode);
                    //            nCustomerID = oRetailConsumer.CustomerID;
                    //            oRetailConsumer.Email = txtEmail.Text;
                    //            if (btnEmailVerification.Text == "Verified")
                    //            {
                    //                oRetailConsumer.IsVerifiedEmail = 1;
                    //            }
                    //            else
                    //            {
                    //                oRetailConsumer.IsVerifiedEmail = 0;

                    //            }
                    //            oRetailConsumer.UpdateEmail(oSystemInfo.WarehouseID);
                    //        }
                    //        else
                    //        {

                    //            oRetailConsumer = new RetailConsumer();
                    //            if (_IsPicFromWeb == true)
                    //            {
                    //                oRetailConsumer.ConsumerCode = _sWebConsumerCode;
                    //            }
                    //            else
                    //            {
                    //                oRetailConsumer.ConsumerCode = "";
                    //            }
                    //            oRetailConsumer.ConsumerName = txtCustomerName.Text;
                    //            oRetailConsumer.ConsumerType = (int)Dictionary.RetailCustomerType.General;
                    //            if (_nUIControl == (int)Dictionary.SalesType.Retail)
                    //            {
                    //                nCustomerID = oSystemInfo.CustomerID;
                    //            }
                    //            else if (_nUIControl == (int)Dictionary.SalesType.eStore)
                    //            {
                    //                nCustomerID = oSystemInfo.CustomerID;
                    //            }
                    //            else
                    //            {
                    //                //nCustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    //                nCustomerID = _oCustomer.CustomerID;
                    //            }

                    //            oRetailConsumer.CustomerID = nCustomerID;
                    //            oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                    //            oRetailConsumer.Address = txtCustomerAddress.Text;
                    //            oRetailConsumer.CellNo = txtCell.Text;
                    //            oRetailConsumer.PhoneNo = txtTelePhone.Text;
                    //            oRetailConsumer.Email = txtEmail.Text;
                    //            oRetailConsumer.EmployeeCode = txtEmployeeNo.Text;
                    //            oRetailConsumer.NationalID = txtNationalID.Text;
                    //            if (dtDateofBirth.Checked == true)
                    //                oRetailConsumer.DateofBirth = dtDateofBirth.Value.Date;
                    //            else oRetailConsumer.DateofBirth = null;
                    //            oRetailConsumer.VatRegNo = txtVatRegNo.Text;
                    //            oRetailConsumer.DeliveryAddress = txtDeliveryAddress.Text;
                    //            oRetailConsumer.SalesType = _nUIControl;
                    //            oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;
                    //            if (btnEmailVerification.Text == "Verified")
                    //            {
                    //                oRetailConsumer.IsVerifiedEmail = 1;
                    //            }
                    //            else
                    //            {
                    //                oRetailConsumer.IsVerifiedEmail = 0;

                    //            }
                    //            oRetailConsumer.Add();
                    //        }
                    //    }
                    //    else
                    //    {
                    //        oRetailConsumer = new RetailConsumer();
                    //        if (_IsPicFromWeb == true)
                    //        {
                    //            oRetailConsumer.ConsumerCode = _sWebConsumerCode;
                    //        }
                    //        else
                    //        {
                    //            oRetailConsumer.ConsumerCode = "";
                    //        }
                    //        oRetailConsumer.ConsumerName = txtCustomerName.Text;
                    //        oRetailConsumer.ConsumerType = (int)Dictionary.RetailCustomerType.General;
                    //        if (_nUIControl == (int)Dictionary.SalesType.Retail)
                    //        {
                    //            nCustomerID = oSystemInfo.CustomerID;
                    //        }
                    //        else if (_nUIControl == (int)Dictionary.SalesType.eStore)
                    //        {
                    //            nCustomerID = oSystemInfo.CustomerID;
                    //        }
                    //        else
                    //        {
                    //            //nCustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    //            nCustomerID = _oCustomer.CustomerID;
                    //        }

                    //        oRetailConsumer.CustomerID = nCustomerID;
                    //        oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                    //        oRetailConsumer.Address = txtCustomerAddress.Text;
                    //        oRetailConsumer.CellNo = txtCell.Text;
                    //        oRetailConsumer.PhoneNo = txtTelePhone.Text;
                    //        oRetailConsumer.Email = txtEmail.Text;
                    //        oRetailConsumer.EmployeeCode = txtEmployeeNo.Text;
                    //        oRetailConsumer.NationalID = txtNationalID.Text;
                    //        if (dtDateofBirth.Checked == true)
                    //            oRetailConsumer.DateofBirth = dtDateofBirth.Value.Date;
                    //        else oRetailConsumer.DateofBirth = null;
                    //        oRetailConsumer.VatRegNo = txtVatRegNo.Text;
                    //        oRetailConsumer.DeliveryAddress = txtDeliveryAddress.Text;
                    //        oRetailConsumer.SalesType = _nUIControl;
                    //        oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;
                    //        if (btnEmailVerification.Text == "Verified")
                    //        {
                    //            oRetailConsumer.IsVerifiedEmail = 1;
                    //        }
                    //        else
                    //        {
                    //            oRetailConsumer.IsVerifiedEmail = 0;

                    //        }
                    //        oRetailConsumer.Add();
                    //    }
                    //}
                    //else if (_nUIControl == (int)Dictionary.SalesType.B2B ||
                    //         _nUIControl == (int)Dictionary.SalesType.Dealer)
                    //{
                    //    oCustomerDetail = new CustomerDetail();
                    //    //oCustomerDetail.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                    //    oCustomerDetail.CustomerID = _oCustomer.CustomerID;
                    //    oCustomerDetail.RefreshForSalesOrder();
                    //    oRetailConsumer = new RetailConsumer();
                    //    oRetailConsumer.ConsumerName = oCustomerDetail.CustomerName;
                    //    oRetailConsumer.ConsumerType = (int)Dictionary.RetailCustomerType.General;
                    //    nCustomerID = oCustomerDetail.CustomerID;
                    //    oRetailConsumer.CustomerID = nCustomerID;
                    //    oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                    //    oRetailConsumer.Address = oCustomerDetail.CustomerAddress;
                    //    oRetailConsumer.CellNo = oCustomerDetail.CustomerPhoneNo;
                    //    oRetailConsumer.PhoneNo = "";
                    //    oRetailConsumer.Email = "";
                    //    oRetailConsumer.EmployeeCode = "";
                    //    oRetailConsumer.NationalID = "";
                    //    oRetailConsumer.DateofBirth = null;
                    //    oRetailConsumer.VatRegNo = oCustomerDetail.TaxNumber;
                    //    oRetailConsumer.DeliveryAddress = oCustomerDetail.CustomerAddress;
                    //    oRetailConsumer.SalesType = _nUIControl;
                    //    oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;
                    //    if (btnEmailVerification.Text == "Verified")
                    //    {
                    //        oRetailConsumer.IsVerifiedEmail = 1;
                    //    }
                    //    else
                    //    {
                    //        oRetailConsumer.IsVerifiedEmail = 0;

                    //    }
                    //    oRetailConsumer.Add();
                    //}
                    //string sConsumerCode = oRetailConsumer.ConsumerCode.ToString();
                    #endregion

                    #region Consumer Entry New
                    if (_nUIControl == (int)Dictionary.SalesType.Retail || _nUIControl == (int)Dictionary.SalesType.eStore || _nUIControl == (int)Dictionary.SalesType.B2C || _nUIControl == (int)Dictionary.SalesType.HPA)
                    {
                        if (rdoNewConsumer.Checked == true)
                        {
                            oRetailConsumer = new RetailConsumer();
                            if (_IsPicFromWeb == true)
                            {
                                oRetailConsumer.ConsumerCode = _sWebConsumerCode;
                            }
                            else
                            {
                                oRetailConsumer.ConsumerCode = "";
                            }
                            oRetailConsumer.ConsumerName = txtCustomerName.Text;
                            oRetailConsumer.ConsumerType = cmbConType.SelectedIndex;
                            oRetailConsumer.SecondaryConsumer = txtSecConsumer.Text;
                            oRetailConsumer.SecondaryMobileNo = txtSecMobileNo.Text;
                            if (_nUIControl == (int)Dictionary.SalesType.Retail)
                            {
                                nCustomerID = oSystemInfo.CustomerID;
                            }
                            else if (_nUIControl == (int)Dictionary.SalesType.eStore)
                            {
                                nCustomerID = oSystemInfo.CustomerID;
                            }
                            else
                            {
                                nCustomerID = _oCustomer.CustomerID;
                            }
                            oRetailConsumer.CustomerID = nCustomerID;
                            oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                            oRetailConsumer.Address = txtCustomerAddress.Text;
                            oRetailConsumer.CellNo = txtCell.Text;
                            oRetailConsumer.PhoneNo = txtTelePhone.Text;
                            oRetailConsumer.Email = txtEmail.Text;
                            oRetailConsumer.EmployeeCode = txtEmployeeNo.Text;
                            oRetailConsumer.NationalID = txtNationalID.Text;
                            if (dtDateofBirth.Checked == true)
                                oRetailConsumer.DateofBirth = dtDateofBirth.Value.Date;
                            else oRetailConsumer.DateofBirth = null;
                            oRetailConsumer.VatRegNo = txtVatRegNo.Text;
                            oRetailConsumer.DeliveryAddress = txtDeliveryAddress.Text;
                            oRetailConsumer.SalesType = _nUIControl;
                            oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;
                            //if (btnEmailVerification.Text == @"Verified")
                            //{
                            //    oRetailConsumer.IsVerifiedEmail = 1;
                            //}
                            //else
                            //{
                            //    oRetailConsumer.IsVerifiedEmail = 0;

                            //}
                            if (chkInvoiceSend.Checked == true)
                            {
                                oRetailConsumer.IsVerifiedEmail = 1;
                            }
                            else
                            {
                                oRetailConsumer.IsVerifiedEmail = 0;
                            }
                            oRetailConsumer.Add();
                        }
                        if (rdoExistingConsumer.Checked == true)
                        {
                            oRetailConsumer = new RetailConsumer();
                            oRetailConsumer.GetConsumerByCode(txtConsumerCode.Text.Trim());
                            nCustomerID = oRetailConsumer.CustomerID;
                            oRetailConsumer.Email = txtEmail.Text;
                            //if (btnEmailVerification.Text == @"Verified")
                            //{
                            //    oRetailConsumer.IsVerifiedEmail = 1;
                            //}
                            //else
                            //{
                            //    oRetailConsumer.IsVerifiedEmail = 0;

                            //}
                            if (chkInvoiceSend.Checked == true)
                            {
                                oRetailConsumer.IsVerifiedEmail = 1;
                            }
                            else
                            {
                                oRetailConsumer.IsVerifiedEmail = 0;
                            }
                            oRetailConsumer.SecondaryConsumer = txtSecConsumer.Text;
                            oRetailConsumer.SecondaryMobileNo = txtSecMobileNo.Text;

                            oRetailConsumer.UpdateEmail(oSystemInfo.WarehouseID);
                        }
                        else if (rdoLeadCust.Checked == true)
                        {
                            if (nFromLeadConsumeID != 0)
                            {
                                oRetailConsumer = new RetailConsumer();
                                oRetailConsumer.GetConsumerByCode(sFromLeadConsumerCode);
                                nCustomerID = oRetailConsumer.CustomerID;
                                oRetailConsumer.Email = txtEmail.Text;
                                //if (btnEmailVerification.Text == "Verified")
                                //{
                                //    oRetailConsumer.IsVerifiedEmail = 1;
                                //}
                                //else
                                //{
                                //    oRetailConsumer.IsVerifiedEmail = 0;

                                //}
                                if (chkInvoiceSend.Checked == true)
                                {
                                    oRetailConsumer.IsVerifiedEmail = 1;
                                }
                                else
                                {
                                    oRetailConsumer.IsVerifiedEmail = 0;
                                }
                                oRetailConsumer.SecondaryConsumer = txtSecConsumer.Text;
                                oRetailConsumer.SecondaryMobileNo = txtSecMobileNo.Text;
                                oRetailConsumer.UpdateEmail(oSystemInfo.WarehouseID);
                            }
                            else
                            {
                                oRetailConsumer = new RetailConsumer();
                                oRetailConsumer.ConsumerName = txtCustomerName.Text;
                                oRetailConsumer.ConsumerType = cmbConType.SelectedIndex;
                                if (_nUIControl == (int)Dictionary.SalesType.Retail)
                                {
                                    nCustomerID = oSystemInfo.CustomerID;
                                }
                                else if (_nUIControl == (int)Dictionary.SalesType.eStore)
                                {
                                    nCustomerID = oSystemInfo.CustomerID;
                                }
                                else
                                {
                                    nCustomerID = _oCustomer.CustomerID;
                                }
                                oRetailConsumer.SecondaryConsumer = txtSecConsumer.Text;
                                oRetailConsumer.SecondaryMobileNo = txtSecMobileNo.Text;
                                oRetailConsumer.CustomerID = nCustomerID;
                                oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                                oRetailConsumer.Address = txtCustomerAddress.Text;
                                oRetailConsumer.CellNo = txtCell.Text;
                                oRetailConsumer.PhoneNo = txtTelePhone.Text;
                                oRetailConsumer.Email = txtEmail.Text;
                                oRetailConsumer.EmployeeCode = txtEmployeeNo.Text;
                                oRetailConsumer.NationalID = txtNationalID.Text;
                                if (dtDateofBirth.Checked == true)
                                    oRetailConsumer.DateofBirth = dtDateofBirth.Value.Date;
                                else oRetailConsumer.DateofBirth = null;
                                oRetailConsumer.VatRegNo = txtVatRegNo.Text;
                                oRetailConsumer.DeliveryAddress = txtDeliveryAddress.Text;
                                oRetailConsumer.SalesType = _nUIControl;
                                oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;
                                //if (btnEmailVerification.Text == @"Verified")
                                //{
                                //    oRetailConsumer.IsVerifiedEmail = 1;
                                //}
                                //else
                                //{
                                //    oRetailConsumer.IsVerifiedEmail = 0;

                                //}
                                if (chkInvoiceSend.Checked == true)
                                {
                                    oRetailConsumer.IsVerifiedEmail = 1;
                                }
                                else
                                {
                                    oRetailConsumer.IsVerifiedEmail = 0;
                                }
                                oRetailConsumer.Add();
                            }

                        }
                    }
                    else if (_nUIControl == (int)Dictionary.SalesType.B2B || _nUIControl == (int)Dictionary.SalesType.Dealer)
                    {
                        oRetailConsumer = new RetailConsumer();
                        if (oRetailConsumer.CheckConsumer(_oCustomer.CustomerID, _nUIControl))
                        {
                            nConsumerID = oRetailConsumer.ConsumerID;
                            nCustomerID = oRetailConsumer.CustomerID;
                        }
                        else
                        {
                            oCustomerDetail = new CustomerDetail();
                            oCustomerDetail.CustomerID = _oCustomer.CustomerID;
                            oCustomerDetail.RefreshForSalesOrder();
                            oRetailConsumer = new RetailConsumer();
                            oRetailConsumer.ConsumerName = oCustomerDetail.CustomerName;
                            oRetailConsumer.ConsumerType = cmbConType.SelectedIndex;
                            nCustomerID = oCustomerDetail.CustomerID;
                            oRetailConsumer.CustomerID = nCustomerID;
                            oRetailConsumer.SecondaryConsumer = txtSecConsumer.Text;
                            oRetailConsumer.SecondaryMobileNo = txtSecMobileNo.Text;
                            oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                            oRetailConsumer.Address = oCustomerDetail.CustomerAddress;
                            oRetailConsumer.CellNo = oCustomerDetail.CustomerPhoneNo;
                            oRetailConsumer.PhoneNo = "";
                            oRetailConsumer.Email = "";
                            oRetailConsumer.EmployeeCode = "";
                            oRetailConsumer.NationalID = "";
                            oRetailConsumer.DateofBirth = null;
                            oRetailConsumer.VatRegNo = oCustomerDetail.TaxNumber;
                            oRetailConsumer.DeliveryAddress = oCustomerDetail.CustomerAddress;
                            oRetailConsumer.SalesType = _nUIControl;
                            oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;
                            oRetailConsumer.SecondaryConsumer = txtSecConsumer.Text;
                            oRetailConsumer.SecondaryMobileNo = txtSecMobileNo.Text;
                            //if (btnEmailVerification.Text == @"Verified")
                            //{
                            //    oRetailConsumer.IsVerifiedEmail = 1;
                            //}
                            //else
                            //{
                            //    oRetailConsumer.IsVerifiedEmail = 0;

                            //}
                            if (chkInvoiceSend.Checked == true)
                            {
                                oRetailConsumer.IsVerifiedEmail = 1;
                            }
                            else
                            {
                                oRetailConsumer.IsVerifiedEmail = 0;
                            }
                            oRetailConsumer.Add();
                        }
                    }
                    string sConsumerCode = oRetailConsumer.ConsumerCode.ToString();
                    #endregion

                    #region Insert in SalesInvoice and SalesInvoiceDetail

                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice);
                    _oSalesInvoice.InsertPOSInvoiceNew();

                    #endregion

                    #region Insert Promotional Effect in Invoice
                    //if (oResultSPromotions != null)
                    //{
                    //    foreach (SPromotion oSelectSPromotion in oResultSPromotions)
                    //    {
                    //        _oSalesInvoice.SalesPromotionID = oSelectSPromotion.SalesPromotionID;

                    //        _oSalesInvoice.InsertSalesInvoicePromo();
                    //    }
                    //}
                    #endregion

                    #region barcode from Invoice Item

                    int _nCount = 1;
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                        {
                            if (int.Parse(oItemRow.Cells[10].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                char[] splitchar = { ',' };
                                string sProductBarcode = oItemRow.Cells[7].Value.ToString();
                                sProductBarcodeArr = sProductBarcode.Split(splitchar);
                                nArrayLen = sProductBarcodeArr.Length;

                                for (int i = 0; i < nArrayLen; i++)
                                {

                                    ProductBarcode oProductBarcode = new ProductBarcode();
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.ProductSerialNo = sProductBarcodeArr[i];
                                    oProductBarcode.UpdateProductSerial();
                                    
                                    //Update VAT Paid Data
                                    Product oProduct = new Product();
                                    oProduct.ProductID= int.Parse(oItemRow.Cells[9].Value.ToString());
                                    oProduct.RefreshByID();
                                    oProductBarcode.UpdateVatPaidProductSerial(oSystemInfo.WarehouseID, oProduct.TradePrice, oProduct.VAT, (int)Dictionary.ProductStockTranType.INVOICE, _oSalesInvoice.InvoiceNo, Convert.ToDateTime(_oSalesInvoice.InvoiceDate));

                                    //SalesInvoiceProductSerial oChkVatPaidProductSerial = new SalesInvoiceProductSerial();
                                    //oChkVatPaidProductSerial.ProductSerialNo = oProductBarcode.ProductSerialNo;
                                    //if (oChkVatPaidProductSerial.CheckVatPaidProductSerial())
                                    //{
                                    //    oProductBarcode.UpdateVatPaidProductSerial(oSystemInfo.WarehouseID);
                                    //}

                                    oProductBarcode.GetProductSerialID(oProductBarcode.ProductSerialNo);
                                    oProductBarcode.FromWHID = oSystemInfo.WarehouseID;
                                    oProductBarcode.ToWHID = (int)Dictionary.WarehouseType.SYSTEM;
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                                    oProductBarcode.InsertProductSerialHistory();


                                    _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                                    _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                                    _oSalesInvoiceProductSerial.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                                    _oSalesInvoiceProductSerial.SerialNo = _nCount;
                                    _oSalesInvoiceProductSerial.ProductSerialNo = sProductBarcodeArr[i];
                                    _oSalesInvoiceProductSerial.Insert();

                                    SetProductSerialAll(_oSalesInvoiceProductSerial.ProductSerialNo);

                                    _nCount++;

                                }

                            }
                        }
                    }

                    #endregion

                    #region barcode from Promotion/Gift Item

                    foreach (DataGridViewRow oItemRow in dvgFreeProduct.Rows)
                    {
                        if (oItemRow.Index < dvgFreeProduct.Rows.Count)
                        {
                            if (int.Parse(oItemRow.Cells[7].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                char[] splitchar = { ',' };
                                string sProductBarcode = oItemRow.Cells[3].Value.ToString();
                                sProductBarcodeArr = sProductBarcode.Split(splitchar);
                                nArrayLen = sProductBarcodeArr.Length;

                                for (int i = 0; i < nArrayLen; i++)
                                {

                                    ProductBarcode oProductBarcode = new ProductBarcode();
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.ProductSerialNo = sProductBarcodeArr[i];
                                    oProductBarcode.UpdateProductSerial();

                                    //Update VAT Paid Data
                                    Product oProduct = new Product();
                                    oProduct.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                                    oProduct.RefreshByID();
                                    oProductBarcode.UpdateVatPaidProductSerial(oSystemInfo.WarehouseID, oProduct.TradePrice, oProduct.VAT, (int)Dictionary.ProductStockTranType.INVOICE, _oSalesInvoice.InvoiceNo, Convert.ToDateTime(_oSalesInvoice.InvoiceDate));


                                    oProductBarcode.GetProductSerialID(oProductBarcode.ProductSerialNo);

                                    oProductBarcode.FromWHID = oSystemInfo.WarehouseID;
                                    oProductBarcode.ToWHID = (int)Dictionary.WarehouseType.SYSTEM;
                                    oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                    oProductBarcode.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                                    oProductBarcode.InsertProductSerialHistory();


                                    _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                                    _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                                    _oSalesInvoiceProductSerial.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                                    _oSalesInvoiceProductSerial.SerialNo = _nCount;
                                    _oSalesInvoiceProductSerial.ProductSerialNo = sProductBarcodeArr[i];

                                    _oSalesInvoiceProductSerial.Insert();
                                    SetProductSerialAll(_oSalesInvoiceProductSerial.ProductSerialNo);
                                    _nCount++;

                                }
                            }
                        }
                    }

                    #endregion

                    #region barcode from Scratch Card Item
                    foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                    {
                        if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Free_Product)
                        {
                            if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                            {
                                if (int.Parse(oItemRow.Cells[10].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                                {
                                    char[] splitchar = { ',' };
                                    string sProductBarcode = oItemRow.Cells[9].Value.ToString();
                                    sProductBarcodeArr = sProductBarcode.Split(splitchar);
                                    nArrayLen = sProductBarcodeArr.Length;

                                    for (int i = 0; i < nArrayLen; i++)
                                    {

                                        ProductBarcode oProductBarcode = new ProductBarcode();
                                        oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                        oProductBarcode.ProductSerialNo = sProductBarcodeArr[i];

                                        oProductBarcode.UpdateProductSerial();
                                        //Update VAT Paid Data
                                        Product oProduct = new Product();
                                        oProduct.ProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                                        oProduct.RefreshByID();
                                        oProductBarcode.UpdateVatPaidProductSerial(oSystemInfo.WarehouseID, oProduct.TradePrice, oProduct.VAT, (int)Dictionary.ProductStockTranType.INVOICE, _oSalesInvoice.InvoiceNo, Convert.ToDateTime(_oSalesInvoice.InvoiceDate));


                                        oProductBarcode.GetProductSerialID(oProductBarcode.ProductSerialNo);

                                        oProductBarcode.FromWHID = oSystemInfo.WarehouseID;
                                        oProductBarcode.ToWHID = (int)Dictionary.WarehouseType.SYSTEM;
                                        oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Sold;
                                        oProductBarcode.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                                        oProductBarcode.InsertProductSerialHistory();

                                        _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                                        _oSalesInvoiceProductSerial.InvoiceID = _oSalesInvoice.InvoiceID;
                                        _oSalesInvoiceProductSerial.ProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                                        _oSalesInvoiceProductSerial.SerialNo = _nCount;
                                        _oSalesInvoiceProductSerial.ProductSerialNo = sProductBarcodeArr[i];

                                        _oSalesInvoiceProductSerial.Insert();
                                        SetProductSerialAll(_oSalesInvoiceProductSerial.ProductSerialNo);
                                        _nCount++;

                                    }

                                }
                            }
                        }
                    }

                    #endregion

                    #region Insert Payment Mode New
                    int _IsCreditInvoice = 0;
                    foreach (DataGridViewRow oItemRow in dgvInvoicePayment.Rows)
                    {
                        if (oItemRow.Index < dgvInvoicePayment.Rows.Count)
                        {
                            RetailSalesInvoice oPaymentMode = new RetailSalesInvoice();
                            oPaymentMode.InvoiceID = _oSalesInvoice.InvoiceID;
                            oPaymentMode.ProductID = Convert.ToInt32(oItemRow.Cells[13].Value.ToString());
                            oPaymentMode.PaymentModeID = Convert.ToInt32(oItemRow.Cells[14].Value.ToString());
                            if (_IsCreditInvoice == 0)
                            {
                                if (oPaymentMode.PaymentModeID != (int)Dictionary.PaymentMode.Cash)
                                {
                                    _IsCreditInvoice = (int)Dictionary.TransectionType.CREDIT_INVOICE;
                                }
                            }
                            oPaymentMode.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                            try
                            {
                                oPaymentMode.BankID = Convert.ToInt32(oItemRow.Cells[15].Value.ToString());
                            }
                            catch
                            {
                                oPaymentMode.BankID = -1;
                            }
                            try
                            {
                                oPaymentMode.CardType = Convert.ToInt32(oItemRow.Cells[16].Value.ToString());
                            }
                            catch
                            {
                                oPaymentMode.CardType = -1;
                            }
                            try
                            {
                                oPaymentMode.POSMachineID = Convert.ToInt32(oItemRow.Cells[17].Value.ToString());
                            }
                            catch
                            {
                                oPaymentMode.POSMachineID = -1;
                            }
                            try
                            {
                                if (oItemRow.Cells[7].Value.ToString() == "YES")
                                {
                                    oPaymentMode.IsEMI = 1;
                                }
                                else
                                {
                                    oPaymentMode.IsEMI = 0;
                                }

                            }
                            catch
                            {
                                oPaymentMode.IsEMI = 0;
                            }
                            try
                            {
                                oPaymentMode.NoOfInstallment = Convert.ToInt32(oItemRow.Cells[8].Value.ToString());
                            }
                            catch
                            {
                                oPaymentMode.NoOfInstallment = 0;
                            }
                            try
                            {
                                oPaymentMode.InstrumentNo = oItemRow.Cells[9].Value.ToString();
                            }
                            catch
                            {
                                oPaymentMode.InstrumentNo = "";
                            }
                            try
                            {
                                oPaymentMode.InstrumentDate = Convert.ToDateTime(oItemRow.Cells[10].Value.ToString());
                            }
                            catch
                            {
                                oPaymentMode.InstrumentDate = DateTime.Now.Date;
                            }
                            try
                            {
                                oPaymentMode.CardCategory = Convert.ToInt32(oItemRow.Cells[18].Value.ToString());
                            }
                            catch
                            {
                                oPaymentMode.CardCategory = -1;
                            }
                            try
                            {
                                oPaymentMode.ApprovalNo = oItemRow.Cells[12].Value.ToString();
                            }
                            catch
                            {
                                oPaymentMode.ApprovalNo = "";
                            }

                            try
                            {
                                oPaymentMode.ExtendedEMICharge = Convert.ToDouble(oItemRow.Cells[19].Value.ToString());
                            }
                            catch
                            {
                                oPaymentMode.ExtendedEMICharge = 0;
                            }
                            try
                            {
                                oPaymentMode.BankDiscount = Convert.ToDouble(oItemRow.Cells[20].Value.ToString());
                            }
                            catch
                            {
                                oPaymentMode.BankDiscount = 0;
                            }

                            try
                            {
                                oPaymentMode.SDApprovalNo = (oItemRow.Cells[26].Value.ToString());
                            }
                            catch
                            {
                                oPaymentMode.SDApprovalNo = "";
                            }
                            oPaymentMode.InsertPayModeNew();

                            #region Approved Credit Data Update
                            if (oPaymentMode.PaymentModeID == (int)Dictionary.PaymentMode.Approve_Credit)
                            {
                                CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();
                                oCustomerCreditApproval.ApprovalNo = oPaymentMode.InstrumentNo;
                                oCustomerCreditApproval.InvoicedAmount = oPaymentMode.Amount;
                                oCustomerCreditApproval.UpdateInvoicedAmount(true);

                            }
                            #endregion

                            #region Advance Payment Data Update
                            if (oPaymentMode.PaymentModeID == (int)Dictionary.PaymentMode.Advance_Payment)
                            {
                                ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();
                                //if (_nUIControl == (int)Dictionary.SalesType.Retail || _nUIControl == (int)Dictionary.SalesType.eStore)
                                //{
                                //    oConsumerBalanceTran.CustomerID = oSystemInfo.CustomerID;
                                //}
                                //else
                                //{
                                //    oConsumerBalanceTran.CustomerID = _oSalesInvoice.CustomerID;
                                //}
                                oConsumerBalanceTran.CustomerID = _oSalesInvoice.CustomerID;
                                oConsumerBalanceTran.TranType = Dictionary.ConsumerAdvancePaymentTranType.Adjust;
                                oConsumerBalanceTran.TranSide = Dictionary.TransectionSide.DEBIT;
                                oConsumerBalanceTran.AdvancePaymentNo = "";
                                oConsumerBalanceTran.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                oConsumerBalanceTran.Amount = oPaymentMode.Amount;
                                oConsumerBalanceTran.Purpose = "";
                                oConsumerBalanceTran.ProductID = -1;
                                oConsumerBalanceTran.PaymentMode = (Dictionary.ConsumerAdvancePaymentMode.Cash);
                                oConsumerBalanceTran.Remarks = "";
                                oConsumerBalanceTran.IsUpload = (int)Dictionary.YesOrNoStatus.NO;
                                oConsumerBalanceTran.CreateUserID = Utility.UserId;
                                oConsumerBalanceTran.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);
                                oConsumerBalanceTran.ConsumerID = Convert.ToInt32(_oSalesInvoice.SundryCustomerID);

                                oConsumerBalanceTran.InstrumentNo = "";
                                oConsumerBalanceTran.InstrumentDate = _oSalesInvoice.InvoiceDate;
                                oConsumerBalanceTran.BankID = -1;
                                oConsumerBalanceTran.CardType = -1;
                                oConsumerBalanceTran.POSMachineID = -1;
                                oConsumerBalanceTran.CardCategory = -1;

                                oConsumerBalanceTran.ApprovalNo = "";
                                oConsumerBalanceTran.IsEMI = 0;
                                oConsumerBalanceTran.NoOfInstallment = 0;

                                oConsumerBalanceTran.Add(true, false);

                                oConsumerBalanceTran.CheckConsumerBalance();
                                if (oConsumerBalanceTran.Amount >= oPaymentMode.Amount)
                                {
                                    oConsumerBalanceTran.UpdateConsumerBalance(false, oPaymentMode.Amount);
                                }
                                else
                                {
                                    try
                                    {
                                        int tmp = Convert.ToInt32("Shuvo");
                                    }
                                    catch (Exception ex)
                                    {

                                        MessageBox.Show("Insufficient Consumer Balance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        throw (ex);
                                    }
                                }

                            }
                            #endregion

                            #region Update Special Discount Status
                            if (oPaymentMode.IsEMI == 1)
                            {
                                if (oPaymentMode.SDApprovalNo != "")
                                {
                                    ConsumerPromotionEngine oSpecialDiscount = new ConsumerPromotionEngine();
                                    try
                                    {
                                        oSpecialDiscount.ApprovalNumber = oPaymentMode.SDApprovalNo;
                                    }
                                    catch
                                    {
                                        oSpecialDiscount.ApprovalNumber = "";
                                    }
                                    oSpecialDiscount.Status = (int)Dictionary.SpacialDiscountStatus.Invoiced;
                                    if (oSpecialDiscount.ApprovalNumber != "")
                                    {
                                        oSpecialDiscount.UpdateSpacialDiscount();
                                        ConsumerPromotionEngine oGetDiscountSpecial = new ConsumerPromotionEngine();
                                        DataTran oDataTran = new DataTran();
                                        oDataTran.TableName = "t_PromoDiscountSpecial";
                                        oDataTran.DataID = oGetDiscountSpecial.GetSpecialDiscountID(oPaymentMode.SDApprovalNo);
                                        oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                                        oDataTran.BatchNo = 0;
                                        if (oDataTran.DataID != 0)
                                        {
                                            if (oDataTran.CheckData() == false)
                                            {
                                                oDataTran.AddForTDPOS();
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion

                        }
                    }
                    ///OLD
                    RetailSalesInvoices oGetPaymentMode = new RetailSalesInvoices();
                    oGetPaymentMode.GetPaymentModeForOldData(_oSalesInvoice.InvoiceID);
                    foreach (RetailSalesInvoice oPayment in oGetPaymentMode)
                    {
                        RetailSalesInvoice oPaymentMode = new RetailSalesInvoice();
                        oPaymentMode.InvoiceID = _oSalesInvoice.InvoiceID;
                        oPaymentMode.PaymentModeID = oPayment.PaymentModeID;
                        oPaymentMode.Amount = oPayment.Amount;
                        oPaymentMode.BankID = oPayment.BankID;
                        oPaymentMode.CardType = oPayment.CardType;
                        oPaymentMode.POSMachineID = oPayment.POSMachineID;
                        oPaymentMode.IsEMI = oPayment.IsEMI;
                        oPaymentMode.NoOfInstallment = oPayment.NoOfInstallment;
                        oPaymentMode.InstrumentNo = oPayment.InstrumentNo;
                        oPaymentMode.InstrumentDate = oPayment.InstrumentDate;
                        oPaymentMode.CardCategory = oPayment.CardCategory;
                        oPaymentMode.ApprovalNo = oPayment.ApprovalNo;
                        oPaymentMode.ExtendedEMICharge = oPayment.ExtendedEMICharge;
                        oPaymentMode.BankDiscount = oPayment.BankDiscount;

                        oPaymentMode.InsertPayMode();

                    }
                    #endregion

                    #region Insert in Customer Transaction and Update Customer Account.

                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
                    _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
                    _oCustomerTransaction.TranDate = DateTime.Now.Date;
                    _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
                    _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
                    _oCustomerTransaction.Terminal = (int)Dictionary.Terminal.Branch_Office;
                    _oCustomerTransaction.Remarks = txtRemarks.Text;
                    _oCustomerTransaction.UserID = Utility.UserId;
                    if (_IsCreditInvoice == 0)
                    {
                        _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE;
                    }
                    else
                    {
                        _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CREDIT_INVOICE;
                    }

                    if (_oCustomerTransaction.CheckTranNo())
                        _oCustomerTransaction.AddTranNew();
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Duplicate Customer Transaction", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
                    #endregion

                    #region Discount and Charge

                    foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                    {
                        if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                        {
                            if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Discount || int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Charge)
                            {
                                SalesInvoiceItem oDiscountCharge = new SalesInvoiceItem();
                                oDiscountCharge.InvoiceID = _oSalesInvoice.InvoiceID;
                                oDiscountCharge.ProductID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                                oDiscountCharge.WarehouseID = oSystemInfo.WarehouseID;
                                oDiscountCharge.DiscountTypeID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                                oDiscountCharge.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                try
                                {
                                    oDiscountCharge.InstrumentNo = oItemRow.Cells[4].Value.ToString();
                                }
                                catch
                                {
                                    oDiscountCharge.InstrumentNo = "";
                                }
                                try
                                {
                                    oDiscountCharge.Description = oItemRow.Cells[5].Value.ToString();
                                }
                                catch
                                {
                                    oDiscountCharge.Description = "";
                                }
                                if (oDiscountCharge.Amount > 0)
                                    oDiscountCharge.AddDiscountCharge();

                            }
                        }
                    }

                    #region Update Special Discount Status
                    foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                    {
                        if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                        {
                            if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Discount)
                            {
                                if (Convert.ToInt32(oItemRow.Cells[1].Value.ToString()) == (int)Dictionary.DiscountChargeItem.Special_Discount)
                                {

                                    ConsumerPromotionEngine oSpecialDiscount = new ConsumerPromotionEngine();
                                    try
                                    {
                                        oSpecialDiscount.ApprovalNumber = oItemRow.Cells[4].Value.ToString();
                                    }
                                    catch
                                    {
                                        oSpecialDiscount.ApprovalNumber = "";
                                    }
                                    oSpecialDiscount.Status = (int)Dictionary.SpacialDiscountStatus.Invoiced;
                                    if (Convert.ToDouble(oItemRow.Cells[3].Value.ToString()) > 0)
                                    {
                                        oSpecialDiscount.UpdateSpacialDiscount();
                                        ConsumerPromotionEngine oGetDiscountSpecial = new ConsumerPromotionEngine();
                                        DataTran oDataTran = new DataTran();
                                        oDataTran.TableName = "t_PromoDiscountSpecial";
                                        oDataTran.DataID = oGetDiscountSpecial.GetSpecialDiscountID(oItemRow.Cells[4].Value.ToString());
                                        oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                                        oDataTran.BatchNo = 0;

                                        if (oDataTran.CheckData() == false)
                                        {
                                            oDataTran.AddForTDPOS();
                                        }
                                    }
                                }

                            }
                        }
                    }
                    #endregion

                    #endregion

                    #region Scratch Card Info Insert
                    //When Product 
                    if (dgvSalesInvoiceDiscount.Rows.Count > 1)
                    {
                        foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                        {
                            if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Free_Product)
                            {
                                if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                                {
                                    _oSalesInvoiceScratchCardInfo = new SalesInvoiceScratchCardInfo();
                                    _oSalesInvoiceScratchCardInfo.OutletID = oSystemInfo.WarehouseID;
                                    _oSalesInvoiceScratchCardInfo.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                    _oSalesInvoiceScratchCardInfo.Type = (int)Dictionary.ProductOrAmountStatus.Product;
                                    _oSalesInvoiceScratchCardInfo.ProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                                    _oSalesInvoiceScratchCardInfo.MainProductID = int.Parse(oItemRow.Cells[0].Value.ToString());
                                    _oSalesInvoiceScratchCardInfo.Qty = int.Parse(oItemRow.Cells[8].Value.ToString());
                                    try
                                    {
                                        _oSalesInvoiceScratchCardInfo.ScratchCardNo =
                                            oItemRow.Cells[4].Value.ToString().Trim();
                                    }

                                    catch
                                    {
                                        _oSalesInvoiceScratchCardInfo.ScratchCardNo = "";
                                    }
                                    try
                                    {
                                        _oSalesInvoiceScratchCardInfo.Description =
                                            oItemRow.Cells[5].Value.ToString().Trim();
                                    }
                                    catch
                                    {
                                        _oSalesInvoiceScratchCardInfo.Description = "";
                                    }
                                    _oSalesInvoiceScratchCardInfo.Add();
                                    _oSalesInvoiceScratchCardInfo.AddScratchCardInfoNew();

                                }
                            }
                        }
                    }
                    //When Amount 
                    foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                    {
                        if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                        {
                            if (Convert.ToInt32(oItemRow.Cells[1].Value.ToString()) == 1 && Convert.ToDouble(oItemRow.Cells[3].Value.ToString()) > 0)//Scratch_Card_Discount
                            {
                                _oSalesInvoiceScratchCardInfo = new SalesInvoiceScratchCardInfo();
                                _oSalesInvoiceScratchCardInfo.OutletID = oSystemInfo.WarehouseID;
                                _oSalesInvoiceScratchCardInfo.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                _oSalesInvoiceScratchCardInfo.Type = (int)Dictionary.ProductOrAmountStatus.Amount;
                                _oSalesInvoiceScratchCardInfo.MainProductID = int.Parse(oItemRow.Cells[0].Value.ToString());
                                try
                                {
                                    _oSalesInvoiceScratchCardInfo.Amount =
                                        Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                }
                                catch
                                {
                                    _oSalesInvoiceScratchCardInfo.Amount = 0;
                                }
                                try
                                {
                                    _oSalesInvoiceScratchCardInfo.ScratchCardNo = oItemRow.Cells[4].Value.ToString();
                                }
                                catch
                                {
                                    _oSalesInvoiceScratchCardInfo.ScratchCardNo = "";
                                }
                                try
                                {
                                    _oSalesInvoiceScratchCardInfo.Description = oItemRow.Cells[5].Value.ToString();
                                }
                                catch
                                {
                                    _oSalesInvoiceScratchCardInfo.Description = "";
                                }
                                _oSalesInvoiceScratchCardInfo.Add();
                                _oSalesInvoiceScratchCardInfo.AddScratchCardInfoNew();

                            }
                        }
                    }
                    #endregion

                    #region Update Product Stock

                    foreach (SalesInvoiceItem _oSalesInvoiceItem in _oSalesInvoice)
                    {
                        ProductStock oProductStock = new ProductStock();

                        oProductStock.ProductID = _oSalesInvoiceItem.ProductID;
                        oProductStock.Quantity = _oSalesInvoiceItem.Quantity + _oSalesInvoiceItem.FreeQty;
                        oProductStock.WarehouseID = _oSalesInvoice.WarehouseID;
                        oProductStock.ChannelID = oSystemInfo.ChannelID;

                        oProductStock.Edit();
                    }

                    #endregion

                    #region Customer Tran(Collection){CustomerTran/Invoice wise payment/CustomerAccount (+)}
                    double _CustomerBGAmt = 0;
                    foreach (DataGridViewRow oItemRow in dgvInvoicePayment.Rows)
                    {
                        if (oItemRow.Index < dgvInvoicePayment.Rows.Count)
                        {
                            if (Convert.ToInt32(oItemRow.Cells[14].Value) == (int)Dictionary.PaymentMode.Customer_BG)
                            {
                                _CustomerBGAmt = _CustomerBGAmt + Convert.ToDouble(oItemRow.Cells[3].Value);

                            }

                        }
                    }
                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction.InvoiceID = _oSalesInvoice.InvoiceID;
                    _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
                    _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
                    _oCustomerTransaction.TranDate = DateTime.Today.Date;
                    _oCustomerTransaction.Amount = Convert.ToDouble(txtNetPay.Text) - _CustomerBGAmt;
                    _oCustomerTransaction.InstrumentType = (int)Dictionary.InstrumentType.CASH;
                    _oCustomerTransaction.UserID = Utility.UserId;
                    _oCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.APPROVED;
                    _oCustomerTransaction.InsertForPOSNew(oSystemInfo.WarehouseID, Convert.ToDateTime(oSystemInfo.OperationDate), _CustomerBGAmt);

                    #endregion

                    #region Sales Prootmion Mapping

                    #region For Prom Free Product 
                    foreach (DataGridViewRow oItemRow in dvgFreeProduct.Rows)
                    {
                        if (oItemRow.Index < dvgFreeProduct.Rows.Count)
                        {
                            SalesInvoiceItem oDiscountMap = new SalesInvoiceItem();
                            oDiscountMap.InvoiceNo = _oSalesInvoice.InvoiceNo;
                            //oDiscountMap.ProductID = oInvoiceDiscountChargeMapRow.ProductID;
                            oDiscountMap.DiscountTypeID = -1;
                            oDiscountMap.DataID = Convert.ToInt32(oItemRow.Cells[9].Value.ToString());
                            oDiscountMap.SlabID = Convert.ToInt32(oItemRow.Cells[10].Value.ToString());
                            oDiscountMap.OfferID = Convert.ToInt32(oItemRow.Cells[11].Value.ToString());
                            if (oItemRow.Cells[8].Value.ToString() == "CP")
                            {
                                oDiscountMap.TableName = "t_PromoCP";
                            }
                            else
                            {
                                oDiscountMap.TableName = "t_PromoTP";
                            }
                            oDiscountMap.IsTableData = (int)Dictionary.YesOrNoStatus.YES;
                            oDiscountMap.Amount = 0;
                            oDiscountMap.FreeProductID = Convert.ToInt32(oItemRow.Cells[5].Value.ToString());
                            oDiscountMap.FreeQty = Convert.ToInt32(oItemRow.Cells[2].Value.ToString());
                            oDiscountMap.IsScratchCardFreeProduct = (int)Dictionary.YesOrNoStatus.NO;
                            oDiscountMap.PromoEMITenureID = -1;
                            oDiscountMap.AddDiscountChargeMap();

                            if (oItemRow.Cells[8].Value.ToString() == "CP")
                            {
                                ConsumerPromotionEngines oEngin = new ConsumerPromotionEngines();
                                DSConsumerPromo oDSPromoForProductforMAP = new DSConsumerPromo();
                                oDSPromoForProductforMAP = oEngin.GetPromoForProduct(oDiscountMap.DataID.ToString());
                                foreach (DSConsumerPromo.ConsumerPromoRow _oForProduct in oDSPromoForProductforMAP.ConsumerPromo)
                                {
                                    oDiscountMap.ProductID = _oForProduct.ProductID;
                                    oDiscountMap.AddDiscountChargeMapProduct();
                                }
                            }
                            else
                            {
                                ConsumerPromotionEngines oEngin = new ConsumerPromotionEngines();
                                DSConsumerPromo oDSPromoForProductforMAP = new DSConsumerPromo();
                                oDSPromoForProductforMAP = oEngin.GetPromoTPForProduct(oDiscountMap.DataID.ToString());
                                foreach (DSConsumerPromo.ConsumerPromoRow _oForProduct in oDSPromoForProductforMAP.ConsumerPromo)
                                {

                                    foreach (DataGridViewRow oInvItemRow in dgvLineItem.Rows)
                                    {
                                        if (oInvItemRow.Index < dgvLineItem.Rows.Count - 1)
                                        {
                                            if (_oForProduct.BrandID == int.Parse(oInvItemRow.Cells[22].Value.ToString()))
                                            {
                                                if (_oForProduct.ProductGroupID == int.Parse(oInvItemRow.Cells[21].Value.ToString()))
                                                {
                                                    if (_oForProduct.IsApplicableOnAllSKU == (int)Dictionary.YesNAStatus.Yes)
                                                    {
                                                        oDiscountMap.ProductID = int.Parse(oInvItemRow.Cells[9].Value.ToString());
                                                        oDiscountMap.AddDiscountChargeMapProduct();
                                                    }
                                                    else
                                                    {
                                                        if (_oForProduct.ApplicableProductID.Contains(oInvItemRow.Cells[9].Value.ToString()))
                                                        {
                                                            oDiscountMap.ProductID = int.Parse(oInvItemRow.Cells[9].Value.ToString());
                                                            oDiscountMap.AddDiscountChargeMapProduct();
                                                        }

                                                    }
                                                }
                                            }
                                        }
                                    }



                                }
                            }

                        }
                    }
                    #endregion Prom Free Product 

                    foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                    {
                        if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                        {
                            if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Discount || int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Charge)
                            {
                                if (Convert.ToDouble(oItemRow.Cells[3].Value.ToString()) > 0)
                                {
                                    if (GetIsSystemDiscountType(Convert.ToInt32(oItemRow.Cells[1].Value.ToString())))
                                    {
                                        string sTableName = "";
                                        int nPID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                                        sTableName = Enum.GetName(typeof(Dictionary.POSDiscountChargeTableMAP), Convert.ToInt32(oItemRow.Cells[1].Value.ToString()));
                                        if (sTableName == "t_PromoTP" || sTableName == "t_PromoCP")
                                        {
                                            DataRow[] oDR = oInvoiceDiscountChargeMap.InvoiceDiscountChargeMap.Select(" TableName= '" + sTableName + "' and ProductID='" + nPID + "'");
                                            CJ.Class.POS.DSSalesInvoice oDSSalesInvoicePromoMAP = new CJ.Class.POS.DSSalesInvoice();
                                            oDSSalesInvoicePromoMAP.Merge(oDR);
                                            oDSSalesInvoicePromoMAP.InvoiceDiscountChargeMap.AcceptChanges();

                                            foreach (CJ.Class.POS.DSSalesInvoice.InvoiceDiscountChargeMapRow oInvoiceDiscountChargeMapRow in oDSSalesInvoicePromoMAP.InvoiceDiscountChargeMap)
                                            {
                                                SalesInvoiceItem oDiscountMap = new SalesInvoiceItem();
                                                oDiscountMap.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                                oDiscountMap.ProductID = oInvoiceDiscountChargeMapRow.ProductID;
                                                oDiscountMap.DiscountTypeID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                                                oDiscountMap.DataID = oInvoiceDiscountChargeMapRow.DataID;
                                                oDiscountMap.SlabID = oInvoiceDiscountChargeMapRow.SlabID;
                                                oDiscountMap.OfferID = oInvoiceDiscountChargeMapRow.OfferID;
                                                oDiscountMap.TableName = oInvoiceDiscountChargeMapRow.TableName;
                                                oDiscountMap.IsTableData = (int)Dictionary.YesOrNoStatus.YES;
                                                oDiscountMap.Amount = oInvoiceDiscountChargeMapRow.Amount;
                                                oDiscountMap.FreeProductID = oInvoiceDiscountChargeMapRow.FreeProductID;
                                                oDiscountMap.FreeQty = oInvoiceDiscountChargeMapRow.FreeQty;
                                                oDiscountMap.IsScratchCardFreeProduct = oInvoiceDiscountChargeMapRow.IsScratchCardFreeProduct;
                                                oDiscountMap.PromoEMITenureID = oInvoiceDiscountChargeMapRow.EMITenureID;
                                                oDiscountMap.AddDiscountChargeMap();
                                                if (oInvoiceDiscountChargeMapRow.ProductID != -1)
                                                {
                                                    oDiscountMap.AddDiscountChargeMapProduct();
                                                }
                                                else
                                                {
                                                    ConsumerPromotionEngines oEngin = new ConsumerPromotionEngines();
                                                    DSConsumerPromo oDSPromoForProductforMAP = new DSConsumerPromo();
                                                    oDSPromoForProductforMAP = oEngin.GetPromoForProduct(oDiscountMap.DataID.ToString());
                                                    foreach (DSConsumerPromo.ConsumerPromoRow _oForProduct in oDSPromoForProductforMAP.ConsumerPromo)
                                                    {
                                                        oDiscountMap.ProductID = _oForProduct.ProductID;
                                                        oDiscountMap.AddDiscountChargeMapProduct();
                                                    }
                                                }

                                            }

                                        }
                                        else if (sTableName == "t_PromoDiscountB2B")
                                        {
                                            SalesInvoiceItem oDiscountMap = new SalesInvoiceItem();
                                            oDiscountMap.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                            oDiscountMap.ProductID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                                            oDiscountMap.DiscountTypeID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                                            ConsumerPromotionEngine oGetPromoDisB2B = new ConsumerPromotionEngine();
                                            oDiscountMap.DataID = oGetPromoDisB2B.GetB2BDiscountID(_oSalesInvoice.CustomerID, Convert.ToDateTime(oSystemInfo.OperationDate));
                                            oDiscountMap.SlabID = -1;
                                            oDiscountMap.OfferID = -1;
                                            oDiscountMap.TableName = "t_PromoDiscountB2B";
                                            oDiscountMap.IsTableData = (int)Dictionary.YesOrNoStatus.YES;
                                            oDiscountMap.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                            oDiscountMap.FreeProductID = -1;
                                            oDiscountMap.FreeQty = -1;
                                            oDiscountMap.IsScratchCardFreeProduct = -1;
                                            oDiscountMap.PromoEMITenureID = -1;
                                            oDiscountMap.AddDiscountChargeMap();
                                            oDiscountMap.AddDiscountChargeMapProduct();
                                        }
                                        else if (sTableName == "t_PromoDiscountMAGBrandB2C" || sTableName == "t_PromoDiscountMAGBrandDealer")
                                        {
                                            SalesInvoiceItem oDiscountMap = new SalesInvoiceItem();
                                            oDiscountMap.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                            oDiscountMap.ProductID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                                            oDiscountMap.DiscountTypeID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                                            ConsumerPromotionEngine oGetPromoDisB2B = new ConsumerPromotionEngine();
                                            oGetPromoDisB2B.GetB2CDealerDiscount(_nUIControl, Convert.ToInt32(oItemRow.Cells[0].Value.ToString()), Convert.ToDateTime(oSystemInfo.OperationDate));
                                            oDiscountMap.DataID = oGetPromoDisB2B.DiscountID;
                                            oDiscountMap.SlabID = -1;
                                            oDiscountMap.OfferID = -1;
                                            oDiscountMap.TableName = "t_PromoDiscountMAGBrand";
                                            oDiscountMap.IsTableData = (int)Dictionary.YesOrNoStatus.YES;
                                            oDiscountMap.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                            oDiscountMap.FreeProductID = -1;
                                            oDiscountMap.FreeQty = -1;
                                            oDiscountMap.IsScratchCardFreeProduct = -1;
                                            oDiscountMap.PromoEMITenureID = -1;
                                            oDiscountMap.AddDiscountChargeMap();
                                            oDiscountMap.AddDiscountChargeMapProduct();

                                        }

                                        else if (sTableName == "t_PromoDiscountMAGBrandDealerMargin")
                                        {
                                            SalesInvoiceItem oDiscountMap = new SalesInvoiceItem();
                                            oDiscountMap.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                            oDiscountMap.ProductID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                                            oDiscountMap.DiscountTypeID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                                            ConsumerPromotionEngine oGetMarginDiscount = new ConsumerPromotionEngine();
                                            oGetMarginDiscount.GetCustTypeMarginDiscount(nCustomerID, Convert.ToInt32(oItemRow.Cells[0].Value.ToString()), Convert.ToDateTime(oSystemInfo.OperationDate));
                                            oDiscountMap.DataID = oGetMarginDiscount.DiscountID;
                                            oDiscountMap.SlabID = -1;
                                            oDiscountMap.OfferID = -1;
                                            oDiscountMap.TableName = "t_PromoDiscountMAGBrandDealerMargin";
                                            oDiscountMap.IsTableData = (int)Dictionary.YesOrNoStatus.YES;
                                            oDiscountMap.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                            oDiscountMap.FreeProductID = -1;
                                            oDiscountMap.FreeQty = -1;
                                            oDiscountMap.IsScratchCardFreeProduct = -1;
                                            oDiscountMap.PromoEMITenureID = -1;
                                            oDiscountMap.AddDiscountChargeMap();
                                            oDiscountMap.AddDiscountChargeMapProduct();

                                        }

                                        else if (sTableName == "t_PromoDiscountBank")
                                        {
                                            foreach (DataGridViewRow oPayItemRow in dgvInvoicePayment.Rows)
                                            {
                                                if (oPayItemRow.Index < dgvInvoicePayment.Rows.Count)
                                                {
                                                    if (Convert.ToInt32(oPayItemRow.Cells[13].Value.ToString()) == Convert.ToInt32(oItemRow.Cells[0].Value.ToString()))
                                                    {
                                                        if (Convert.ToDouble(oPayItemRow.Cells[20].Value.ToString()) > 0)
                                                        {
                                                            SalesInvoiceItem oDiscountMap = new SalesInvoiceItem();
                                                            oDiscountMap.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                                            oDiscountMap.ProductID = Convert.ToInt32(oPayItemRow.Cells[13].Value.ToString());
                                                            oDiscountMap.DiscountTypeID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                                                            oDiscountMap.DataID = Convert.ToInt32(oPayItemRow.Cells[24].Value.ToString());
                                                            oDiscountMap.SlabID = -1;
                                                            oDiscountMap.OfferID = -1;
                                                            oDiscountMap.TableName = "t_PromoDiscountBank";
                                                            oDiscountMap.IsTableData = (int)Dictionary.YesOrNoStatus.YES;
                                                            oDiscountMap.Amount = Convert.ToDouble(oPayItemRow.Cells[20].Value.ToString());
                                                            oDiscountMap.FreeProductID = -1;
                                                            oDiscountMap.FreeQty = -1;
                                                            oDiscountMap.IsScratchCardFreeProduct = -1;
                                                            oDiscountMap.PromoEMITenureID = -1;
                                                            oDiscountMap.AddDiscountChargeMap();
                                                            oDiscountMap.AddDiscountChargeMapProduct();

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (sTableName == "t_EMIExtendedCharge")
                                        {
                                            foreach (DataGridViewRow oPayItemRow in dgvInvoicePayment.Rows)
                                            {
                                                if (oPayItemRow.Index < dgvInvoicePayment.Rows.Count)
                                                {
                                                    if (Convert.ToInt32(oPayItemRow.Cells[13].Value.ToString()) == Convert.ToInt32(oItemRow.Cells[0].Value.ToString()))
                                                    {
                                                        if (Convert.ToDouble(oPayItemRow.Cells[19].Value.ToString()) > 0)
                                                        {
                                                            SalesInvoiceItem oDiscountMap = new SalesInvoiceItem();
                                                            oDiscountMap.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                                            oDiscountMap.ProductID = Convert.ToInt32(oPayItemRow.Cells[13].Value.ToString());
                                                            oDiscountMap.DiscountTypeID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                                                            oDiscountMap.DataID = Convert.ToInt32(oPayItemRow.Cells[25].Value.ToString());
                                                            oDiscountMap.SlabID = -1;
                                                            oDiscountMap.OfferID = -1;
                                                            oDiscountMap.TableName = "t_EMIExtendedCharge";
                                                            oDiscountMap.IsTableData = (int)Dictionary.YesOrNoStatus.YES;
                                                            oDiscountMap.Amount = Convert.ToDouble(oPayItemRow.Cells[19].Value.ToString());
                                                            oDiscountMap.FreeProductID = -1;
                                                            oDiscountMap.FreeQty = -1;
                                                            oDiscountMap.IsScratchCardFreeProduct = -1;
                                                            oDiscountMap.PromoEMITenureID = -1;
                                                            oDiscountMap.AddDiscountChargeMap();
                                                            oDiscountMap.AddDiscountChargeMapProduct();

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (sTableName == "t_PromoDiscountSpecial")
                                        {
                                            SalesInvoiceItem oDiscountMap = new SalesInvoiceItem();
                                            oDiscountMap.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                            oDiscountMap.ProductID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                                            oDiscountMap.DiscountTypeID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                                            ConsumerPromotionEngine oGetDiscountSpecial = new ConsumerPromotionEngine();
                                            //oGetDiscountSpecial.GetSpecialDiscountID(oItemRow.Cells[4].Value.ToString());
                                            oDiscountMap.DataID = oGetDiscountSpecial.GetSpecialDiscountID(oItemRow.Cells[4].Value.ToString());
                                            oDiscountMap.SlabID = -1;
                                            oDiscountMap.OfferID = -1;
                                            oDiscountMap.TableName = "t_PromoDiscountSpecial";
                                            oDiscountMap.IsTableData = (int)Dictionary.YesOrNoStatus.YES;
                                            oDiscountMap.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                            oDiscountMap.FreeProductID = -1;
                                            oDiscountMap.FreeQty = -1;
                                            oDiscountMap.IsScratchCardFreeProduct = -1;
                                            oDiscountMap.PromoEMITenureID = -1;
                                            oDiscountMap.AddDiscountChargeMap();
                                            oDiscountMap.AddDiscountChargeMapProduct();

                                        }
                                        else if (sTableName == "t_SalesInvoiceScratchCardInfoNew")
                                        {
                                            //SalesInvoiceScratchCardInfo 
                                            SalesInvoiceItem oDiscountMap = new SalesInvoiceItem();
                                            oDiscountMap.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                            oDiscountMap.ProductID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                                            oDiscountMap.DiscountTypeID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                                            SalesInvoiceScratchCardInfo oGetID = new SalesInvoiceScratchCardInfo();
                                            oDiscountMap.DataID = oGetID.GetSalesInvoiceScratchCardIDAmount(_oSalesInvoice.InvoiceNo, Convert.ToInt32(oItemRow.Cells[0].Value.ToString()));
                                            oDiscountMap.SlabID = -1;
                                            oDiscountMap.OfferID = -1;
                                            oDiscountMap.TableName = "t_SalesInvoiceScratchCardInfoNew";
                                            oDiscountMap.IsTableData = (int)Dictionary.YesOrNoStatus.YES;
                                            oDiscountMap.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                            oDiscountMap.FreeProductID = -1;
                                            oDiscountMap.FreeQty = -1;
                                            oDiscountMap.IsScratchCardFreeProduct = -1;
                                            oDiscountMap.PromoEMITenureID = -1;
                                            oDiscountMap.AddDiscountChargeMap();
                                            oDiscountMap.AddDiscountChargeMapProduct();

                                        }

                                    }
                                    else
                                    {
                                        SalesInvoiceItem oDiscountMap = new SalesInvoiceItem();
                                        oDiscountMap.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                        oDiscountMap.ProductID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                                        oDiscountMap.DiscountTypeID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                                        oDiscountMap.DataID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                                        oDiscountMap.SlabID = -1;
                                        oDiscountMap.OfferID = -1;
                                        oDiscountMap.TableName = "t_SalesInvoiceDiscount";
                                        oDiscountMap.IsTableData = (int)Dictionary.YesOrNoStatus.YES;
                                        oDiscountMap.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                        oDiscountMap.FreeProductID = -1;
                                        oDiscountMap.FreeQty = -1;
                                        oDiscountMap.IsScratchCardFreeProduct = -1;
                                        oDiscountMap.PromoEMITenureID = -1;
                                        oDiscountMap.AddDiscountChargeMap();
                                        oDiscountMap.AddDiscountChargeMapProduct();
                                    }
                                }


                            }
                            else
                            {
                                SalesInvoiceItem oScretchCardFreeProdoct = new SalesInvoiceItem();
                                oScretchCardFreeProdoct.InvoiceNo = _oSalesInvoice.InvoiceNo;
                                oScretchCardFreeProdoct.ProductID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                                oScretchCardFreeProdoct.DiscountTypeID = -1;
                                SalesInvoiceScratchCardInfo oInfo = new SalesInvoiceScratchCardInfo();
                                oScretchCardFreeProdoct.DataID = oInfo.GetSalesInvoiceScratchCardID(_oSalesInvoice.InvoiceNo, Convert.ToInt32(oItemRow.Cells[0].Value.ToString()), Convert.ToInt32(oItemRow.Cells[7].Value.ToString()));
                                oScretchCardFreeProdoct.SlabID = -1;
                                oScretchCardFreeProdoct.OfferID = -1;
                                oScretchCardFreeProdoct.TableName = "t_SalesInvoiceScratchCardInfoNew";
                                oScretchCardFreeProdoct.IsTableData = (int)Dictionary.YesOrNoStatus.YES;
                                oScretchCardFreeProdoct.Amount = 0;
                                oScretchCardFreeProdoct.FreeProductID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString());
                                oScretchCardFreeProdoct.FreeQty = Convert.ToInt32(oItemRow.Cells[8].Value.ToString());
                                oScretchCardFreeProdoct.IsScratchCardFreeProduct = (int)Dictionary.YesOrNoStatus.YES;
                                oScretchCardFreeProdoct.PromoEMITenureID = -1;
                                oScretchCardFreeProdoct.AddDiscountChargeMap();
                                oScretchCardFreeProdoct.AddDiscountChargeMapProduct();
                            }
                        }
                    }

                    #endregion

                    #region PROCESSING Delivery & CountItemData
                    _oSalesInvoice.NoOfPromo = dsvPromotion.Rows.Count;
                    _oSalesInvoice.GetCountItemData(_oSalesInvoice.InvoiceID);
                    _oSalesInvoice.UpdateDate = oSystemInfo.OperationDate;
                    _oSalesInvoice.UpadteInvoiceStatusnCountData(_oSalesInvoice.InvoiceID, (short)Dictionary.InvoiceStatus.PROCESSING_DELIVERY);
                    #endregion

                    #region Delivery Invoice & ProductStock Tran

                    _oStockTran = new StockTran();
                    _oStockTran = SetData(_oStockTran, _oSalesInvoice);
                    _oSalesInvoice.UserID = Utility.UserId;
                    _oSalesInvoice.DeliveryDate = oSystemInfo.OperationDate;
                    _oSalesInvoice.RetailDeliveryInvoice(_oSalesInvoice.InvoiceID,
                        (short)Dictionary.InvoiceStatus.DELIVERED, _oSalesInvoice.WarehouseID);
                    _oStockTran.UserID = Utility.UserId;
                    _oStockTran.InsertStockTranNew();

                    foreach (StockTranItem oItem in _oStockTran)
                    {
                        _oProductStock = new ProductStock();
                        _oProductStock.Refresh(oItem.ProductID, _oStockTran.FromChannelID, _oStockTran.FromWHID);

                        if ((_oProductStock.CurrentStock - oItem.Qty) < 0)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Stock can't be negative ", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        if ((_oProductStock.BookingStock - oItem.Qty) < 0)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Stock can't be negative ", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.Update(oItem.StockPrice);

                        if (_oProductStock.Flag == false)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Stock can't be negative ", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        _oProductStock = new ProductStock();
                        _oProductStock.ProductID = oItem.ProductID;
                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.WarehouseID = _oStockTran.ToWHID;
                        _oProductStock.Quantity = _oStockTran.ToChannelID;
                        _oProductStock.UpdateCurrentStock(true);

                    }

                    #endregion

                    #region Duty

                    //if (Utility.CompanyInfo == "TEL")
                    //{
                    //    _DutyLocalBalance = 0;
                    //    _DutyImportBalance = 0;

                    //    SystemInfo oIsVatActive = new SystemInfo();
                    //    int nIsActive = oIsVatActive.IsNewVatActive();
                    //    if (nIsActive == 1)
                    //    {
                    //        string dtDate = "30-Jun-2017";
                    //        DateTime dtVatDate = Convert.ToDateTime(dtDate).Date;
                    //        if (Convert.ToDateTime(oSystemInfo.OperationDate).Date > dtVatDate.Date)
                    //        {
                    //            if (IsChkVatEntry == (int)Dictionary.YesOrNoStatus.YES)
                    //            {
                    //                oDutyTranVAT63 = GetDataForVAT63(oDutyTranVAT63);
                    //                if (oDutyTranVAT63.Count > 0)
                    //                {
                    //                    if (oDutyTranVAT63.Amount > 0)
                    //                    {
                    //                        oDutyTranVAT63.Remarks = _oSalesInvoice.Remarks;
                    //                        oDutyTranVAT63.InsertForPOSNew(oSystemInfo.WarehouseCode);
                    //                    }
                    //                }
                    //                oDutyAccount = new DutyAccount();
                    //                oDutyAccount.DutyAccountTypeID = 3;
                    //                oDutyAccount.Balance = _NewDutyBalance;
                    //                oDutyAccount.UpdateBalanceForPOS(true);
                    //            }

                    //        }

                    //    }
                    //    else
                    //    {
                    //        oDutyTranVAT11 = GetDataForVAT11(oDutyTranVAT11);
                    //        oDutyTranVAT11KA = GetDataForVAT11KA(oDutyTranVAT11KA);

                    //        if (oDutyTranVAT11.Count > 0)
                    //        {
                    //            if (oDutyTranVAT11.Amount > 0)
                    //            {
                    //                oDutyTranVAT11.Remarks = _oSalesInvoice.Remarks;
                    //                oDutyTranVAT11.InsertForPOS(oSystemInfo.WarehouseCode);
                    //            }
                    //        }
                    //        if (oDutyTranVAT11KA.Count > 0)
                    //        {
                    //            if (oDutyTranVAT11KA.Amount > 0)
                    //            {
                    //                oDutyTranVAT11KA.Remarks = _oSalesInvoice.Remarks;
                    //                oDutyTranVAT11KA.InsertForPOS(oSystemInfo.WarehouseCode);
                    //            }
                    //        }


                    //        oDutyAccount = new DutyAccount();
                    //        oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.LOCAL;
                    //        oDutyAccount.Balance = _DutyLocalBalance;
                    //        oDutyAccount.UpdateBalanceForPOS(true);

                    //        oDutyAccount = new DutyAccount();
                    //        oDutyAccount.DutyAccountTypeID = (int)Dictionary.SupplyType.IMPORTED;
                    //        oDutyAccount.Balance = _DutyImportBalance;
                    //        oDutyAccount.UpdateBalanceForPOS(true);
                    //    }
                    //}

                    #endregion

                    #region New Duty
                    if (Utility.CompanyInfo == "TEL")
                    {
                        InsertVAT63(Convert.ToInt32(_oSalesInvoice.InvoiceID), _oSalesInvoice.InvoiceNo);
                    }
                    
                    #endregion

                    #region Outlet Display Position

                    OutletDisplayPositions _oOutletDisplayPositions = new OutletDisplayPositions();
                    _oOutletDisplayPositions.RefreshInvoiceData(_oSalesInvoice.InvoiceID);

                    foreach (OutletDisplayPosition oOutletDisplayPosition in _oOutletDisplayPositions)
                    {
                        OutletDisplayPosition oOutletDP = new OutletDisplayPosition();
                        oOutletDP.DisplayPositionID = oOutletDisplayPosition.DisplayPositionID;
                        oOutletDP.ProductSerialNo = oOutletDisplayPosition.ProductSerialNo;
                        oOutletDP.Status = (int)Dictionary.DisplayPositionStatus.Blank;
                        oOutletDP.Type = (int)Dictionary.DisplayPositionStatus.Blank;
                        oOutletDP.CreateDate = DateTime.Now.Date;
                        oOutletDP.CreateUserID = Utility.UserId;
                        oOutletDP.EditForPOSInvoice();
                        oOutletDP.AddHistory();

                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_OutletDisplayPosition";
                        oDataTran.DataID = Convert.ToInt32(oOutletDP.DisplayPositionID);
                        oDataTran.WarehouseID = Convert.ToInt32(_oSalesInvoice.WarehouseID);
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckData() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }

                        DataTran oHistoryDataTran = new DataTran();
                        oHistoryDataTran.TableName = "t_OutletDisplayPositionHistory";
                        oHistoryDataTran.DataID = Convert.ToInt32(oOutletDP.HistoryID);
                        oHistoryDataTran.WarehouseID = Convert.ToInt32(_oSalesInvoice.WarehouseID);
                        oHistoryDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oHistoryDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oHistoryDataTran.BatchNo = 0;
                        if (oHistoryDataTran.CheckData() == false)
                        {
                            oHistoryDataTran.AddForTDPOS();
                        }

                    }

                    #endregion

                    #region SalesLead

                    if (rdoExistingConsumer.Checked == true && txtCustomerName.Text != "")
                    {
                        SalesLead _oSalesLead = new SalesLead();
                        int nLeadID = _oSalesLead.GetLeadIDByContactNo(txtCell.Text, _nUIControl);
                        _oSalesLead.LeadID = nLeadID;
                        _oSalesLead.InvoiceNo = _oSalesInvoice.InvoiceNo;
                        _oSalesLead.InvoiceDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate);
                        if (nLeadID != 0)
                            _oSalesLead.UpdateInvoiceStatus();

                    }
                    if (rdoLeadCust.Checked == true && txtCustomerName.Text != "")
                    {
                        SalesLead _oSalesLead = new SalesLead();
                        _oSalesLead.LeadNo = txtConsumerCode.Text;
                        _oSalesLead.RefreshByLeadNo(_nUIControl);
                        _oSalesLead.InvoiceNo = _oSalesInvoice.InvoiceNo;
                        _oSalesLead.InvoiceDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate);
                        if (_oSalesLead.Type == 1)
                        {
                            _oSalesLead.UpdateInvoiceStatus();
                        }
                        else if (_oSalesLead.Type == 2)
                        {

                            #region E-Commerce Data Update

                            EcommerceOrder _oEcommerceOrder = new EcommerceOrder();
                            _oEcommerceOrder.EComOrderID = _oSalesLead.LeadID;
                            _oEcommerceOrder.RefInvoiceNo = _oSalesInvoice.InvoiceNo;
                            _oEcommerceOrder.Status = (int)Dictionary.ECommerceOrderStatus.Invoiced;
                            _oEcommerceOrder.UpdateLeadInvoiceStatus();

                            DataTran _oDataTran = new DataTran();
                            _oDataTran.TableName = "t_SalesInvoiceEcommerce";
                            _oDataTran.DataID = _oEcommerceOrder.EComOrderID;
                            _oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                            _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                            _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                            _oDataTran.BatchNo = 0;
                            _oDataTran.CreateDate = DateTime.Now.Date;
                            if (_oDataTran.CheckData())
                            {

                            }
                            else
                            {
                                _oDataTran.AddForTDPOS();
                            }

                            #endregion
                        }

                    }

                    #endregion

                    #region Unsold Defective Product
                    foreach (CJ.Class.POS.DSSalesInvoice.ProductBarcodeRow oProductBarcodeRow in oDSProductBarcodeAll.ProductBarcode)
                    {
                        UnsoldDefectiveProduct oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                        oUnsoldDefectiveProduct.BarcodeSL = oProductBarcodeRow.Bacode;
                        if (oUnsoldDefectiveProduct.GetDefectiveIDByBarcode())
                        {
                            oUnsoldDefectiveProduct.Status = (int)Dictionary.POSUnsouldDefectiveProductStatus.Invoiced;
                            oUnsoldDefectiveProduct.RefInvoiceNo = _oSalesInvoice.InvoiceNo;
                            oUnsoldDefectiveProduct.RefInvoiceDate = Convert.ToDateTime(_oSalesInvoice.InvoiceDate);
                            oUnsoldDefectiveProduct.WarehouseID = _oSalesInvoice.WarehouseID;
                            try
                            {
                                oUnsoldDefectiveProduct.Remarks = _oSalesInvoice.Remarks;
                            }
                            catch
                            {
                                oUnsoldDefectiveProduct.Remarks = "";
                            }
                            oUnsoldDefectiveProduct.UpdateInvoiceData();
                        }

                    }
                    #endregion

                    #region TD Delivery Shipment
                    TDDeliveryShipment oTDDeliveryShipment = new TDDeliveryShipment();
                    oTDDeliveryShipment = GetDataDeliveryShipmentData(_oSalesInvoice);
                    oTDDeliveryShipment.Add(0, 1);


                    DataTran _oDataTrans = new DataTran();
                    _oDataTrans.TableName = "t_TDDeliveryShipment";
                    _oDataTrans.DataID = Convert.ToInt32(oTDDeliveryShipment.ShipmentID);
                    _oDataTrans.WarehouseID = _oSalesInvoice.WarehouseID;
                    _oDataTrans.TransferType = (int)Dictionary.DataTransferType.Add;
                    _oDataTrans.IsDownload = (int)Dictionary.IsDownload.No;
                    _oDataTrans.BatchNo = 0;
                    if (_oDataTrans.CheckData() == false)
                    {
                        _oDataTrans.AddForTDPOS();
                    }
                    #endregion

                    #region Sales Order Data update
                    if (_nDMSOrderID != -1)
                    {
                        DMSSecondarySalesOrder oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                        oDMSSecondarySalesOrder.RefInvoiceNo = _oSalesInvoice.InvoiceNo;
                        oDMSSecondarySalesOrder.RefInvoiceDate = _oSalesInvoice.InvoiceDate;
                        oDMSSecondarySalesOrder.Status = (int)Dictionary.DMSSecondarySalesOrderStatus.Invoiced;
                        oDMSSecondarySalesOrder.OrderNo = _sDMSOrderNo;
                        oDMSSecondarySalesOrder.WarehouseID = _oSalesInvoice.WarehouseID;
                        oDMSSecondarySalesOrder.UpdateInvoiceData();


                        DataTran _oDataTranDMS = new DataTran();
                        _oDataTranDMS.TableName = "t_DMSSecondarySalesOrder";
                        _oDataTranDMS.DataID = Convert.ToInt32(_nDMSOrderID);
                        _oDataTranDMS.WarehouseID = _oSalesInvoice.WarehouseID;
                        _oDataTranDMS.TransferType = (int)Dictionary.DataTransferType.Add;
                        _oDataTranDMS.IsDownload = (int)Dictionary.IsDownload.No;
                        _oDataTranDMS.BatchNo = 0;
                        if (_oDataTranDMS.CheckData() == false)
                        {
                            _oDataTranDMS.AddForTDPOS();
                        }
                    }
                    #endregion



                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                    DBController.Instance.OpenNewConnection();
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        InvoiceWiseBarcode();

                        if (Utility.IsThermalPrintEnable == (int)Dictionary.YesOrNoStatus.YES)
                        {
                            PrintRetailInvoiceThermal(_oSalesInvoice.InvoiceID, chkInvoiceSend.Checked);
                        }
                        else
                        {
                            PrintRetailInvoice(_oSalesInvoice.InvoiceID, chkInvoiceSend.Checked);
                        }

                        if (Utility.CompanyInfo == "TEL")
                        {
                            if (Utility.IsThermalPrintEnable == (int)Dictionary.YesOrNoStatus.YES)
                            {
                                PrintWarrantyCardThermal(_oSalesInvoice);
                            }
                            else
                            {
                                PrintWarrantyCard(_oSalesInvoice);
                            }
                        }
                        DBController.Instance.CommitTransaction();
                        Outgoing oOutgoing = new Outgoing();

                        #region Email & SMS Send
                        //if (chkInvoiceSend.Checked)
                        //{
                        //    try
                        //    {

                        //        oOutgoing.SendTDSalesEmail(txtConsumerName.Text, Convert.ToInt32(_oSalesInvoice.InvoiceID), _oSalesInvoice.InvoiceNo, Convert.ToDateTime(_oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"), txtEmail.Text.Trim(), 1);
                        //        MessageBox.Show("Email Send Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    }
                        //    catch
                        //    {
                        //        MessageBox.Show("Email Not send! Please resend again", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }
                        //}
                        try
                        {
                            int _nIsEmailVarified = 0;
                            if (chkInvoiceSend.Checked == true)
                            {
                                _nIsEmailVarified = 1;
                            }
                            oOutgoing.SendTDSalesSMS(txtCell.Text.Trim(), _oSalesInvoice.InvoiceNo, txtEmail.Text, _nIsEmailVarified);
                            MessageBox.Show("SMS Send Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("SMS Not send! Please resend again", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion

                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void InsertVAT63(int nTranID, string sTranNo)
        {
            DutyAccounts oDetail = new DutyAccounts();
            oDetail.GetDutyDetailNew("Invoice", Convert.ToInt32(nTranID));

            double _TotalAmount_63_15 = 0;
            double _TotalAmount_63_5 = 0;

            int countMUSHAK_63_15 = 0;
            int countMUSHAK_63_5 = 0;
            int countMUSHAK_Exampled = 0;

            oDutyTranVAT63_15 = new DutyTran();
            oDutyTranVAT63_5 = new DutyTran();
            oDutyTranVATExampled = new DutyTran();

            foreach (DutyAccount oDutyTranDetail in oDetail)
            {
                if (oDutyTranDetail.VATType == (int)Dictionary.VATType.IMPORTED_15 || oDutyTranDetail.VATType == (int)Dictionary.VATType.LOCAL_15)
                {
                    if (countMUSHAK_63_15 == 0)
                    {

                        DateTime day = Convert.ToDateTime(oSystemInfo.OperationDate);
                        DateTime time = DateTime.Now;
                        DateTime combine = day.Add(time.TimeOfDay);
                        oDutyTranVAT63_15.DutyTranDate = Convert.ToDateTime(combine);
                        oDutyTranVAT63_15.WHID = oSystemInfo.WarehouseID;
                        oDutyTranVAT63_15.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_3;
                        oDutyTranVAT63_15.DocumentNo = sTranNo;
                        oDutyTranVAT63_15.RefID = nTranID;
                        oDutyTranVAT63_15.DutyTypeID = (int)Dictionary.DutyType.VAT;
                        oDutyTranVAT63_15.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
                        oDutyTranVAT63_15.Remarks = txtRemarks.Text;
                        oDutyTranVAT63_15.DutyAccountID = (int)Dictionary.DutyAccountNew.MUSHAK_6_3;
                        oDutyTranVAT63_15.Amount = 0;
                        oDutyTranVAT63_15.InsertForPOSNewVat(oSystemInfo.WarehouseCode, txtVehicleNo.Text);
                        countMUSHAK_63_15++;
                    }

                    DutyTranDetail oItem = new DutyTranDetail();
                    oItem.DutyTranID = oDutyTranVAT63_15.DutyTranID;
                    oItem.ProductID = oDutyTranDetail.ProductID;
                    oItem.Qty = oDutyTranDetail.Qty;
                    //oItem.DutyPrice = oDutyTranDetail.DutyPriceForRetail;
                    oItem.DutyPrice = oDutyTranDetail.TradePrice;

                    oItem.DutyRate = oDutyTranDetail.DutyRate;
                    oItem.WHID = oSystemInfo.WarehouseID;
                    oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                    //oItem.VAT = (oDutyTranDetail.DutyPriceForRetail * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oItem.VAT = (oDutyTranDetail.TradePrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oItem.VATType = oDutyTranDetail.VATType;

                    DutyTran oVatPaidData = new DutyTran();
                    oItem.VATPaidQty = oVatPaidData.GetVATPaidQty(oItem.ProductID, sTranNo);

                    _TotalAmount_63_15 = _TotalAmount_63_15 + oItem.VAT;
                    oItem.InsertForPOSNew();

                }
                else if (oDutyTranDetail.VATType == (int)Dictionary.VATType.LOCAL_5 || oDutyTranDetail.VATType == (int)Dictionary.VATType.IMPORTED_5)
                {
                    if (countMUSHAK_63_5 == 0)
                    {

                        DateTime day = Convert.ToDateTime(oSystemInfo.OperationDate);
                        DateTime time = DateTime.Now;
                        DateTime combine = day.Add(time.TimeOfDay);
                        oDutyTranVAT63_5.DutyTranDate = Convert.ToDateTime(combine);
                        oDutyTranVAT63_5.WHID = oSystemInfo.WarehouseID;
                        oDutyTranVAT63_5.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_3;
                        oDutyTranVAT63_5.DocumentNo = sTranNo;
                        oDutyTranVAT63_5.RefID = nTranID;
                        oDutyTranVAT63_5.DutyTypeID = (int)Dictionary.DutyType.VAT;
                        oDutyTranVAT63_5.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
                        oDutyTranVAT63_5.Remarks = txtRemarks.Text;
                        oDutyTranVAT63_5.DutyAccountID = (int)Dictionary.DutyAccountNew.MUSHAK_6_3;
                        oDutyTranVAT63_5.Amount = 0;
                        oDutyTranVAT63_5.InsertForPOSNewVat(oSystemInfo.WarehouseCode, txtVehicleNo.Text);
                        countMUSHAK_63_5++;
                    }

                    DutyTranDetail oItem = new DutyTranDetail();
                    oItem.DutyTranID = oDutyTranVAT63_5.DutyTranID;
                    oItem.ProductID = oDutyTranDetail.ProductID;
                    oItem.Qty = oDutyTranDetail.Qty;
                    //oItem.DutyPrice = oDutyTranDetail.DutyPriceForRetail;
                    oItem.DutyPrice = oDutyTranDetail.TradePrice;
                    oItem.DutyRate = oDutyTranDetail.DutyRate;
                    oItem.WHID = oSystemInfo.WarehouseID;
                    oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                    //oItem.VAT = (oDutyTranDetail.DutyPriceForRetail * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oItem.VAT = (oDutyTranDetail.TradePrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oItem.VATType = oDutyTranDetail.VATType;
                    DutyTran oVatPaidData = new DutyTran();
                    oItem.VATPaidQty = oVatPaidData.GetVATPaidQty(oItem.ProductID, sTranNo);

                    _TotalAmount_63_5 = _TotalAmount_63_5 + oItem.VAT;
                    oItem.InsertForPOSNew();

                }
                else
                {
                    if (countMUSHAK_Exampled == 0)
                    {

                        DateTime day = Convert.ToDateTime(oSystemInfo.OperationDate);
                        DateTime time = DateTime.Now;
                        DateTime combine = day.Add(time.TimeOfDay);
                        oDutyTranVATExampled.DutyTranDate = Convert.ToDateTime(combine);
                        oDutyTranVATExampled.WHID = oSystemInfo.WarehouseID;
                        oDutyTranVATExampled.ChallanTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_3;
                        oDutyTranVATExampled.DocumentNo = sTranNo;
                        oDutyTranVATExampled.RefID = nTranID;
                        oDutyTranVATExampled.DutyTypeID = (int)Dictionary.DutyType.VAT;
                        oDutyTranVATExampled.DutyTranTypeID = (int)Dictionary.DutyTranType.INVOICE;
                        oDutyTranVATExampled.Remarks = txtRemarks.Text;
                        oDutyTranVATExampled.DutyAccountID = (int)Dictionary.DutyAccountNew.MUSHAK_6_3;
                        oDutyTranVATExampled.Amount = 0;
                        oDutyTranVATExampled.InsertForPOSNewVat(oSystemInfo.WarehouseCode, txtVehicleNo.Text);
                        countMUSHAK_Exampled++;
                    }

                    DutyTranDetail oItem = new DutyTranDetail();
                    oItem.DutyTranID = oDutyTranVATExampled.DutyTranID;
                    oItem.ProductID = oDutyTranDetail.ProductID;
                    oItem.Qty = oDutyTranDetail.Qty;
                    //oItem.DutyPrice = oDutyTranDetail.DutyPriceForRetail;
                    oItem.DutyPrice = oDutyTranDetail.TradePrice;
                    oItem.DutyRate = oDutyTranDetail.DutyRate;
                    oItem.WHID = oSystemInfo.WarehouseID;
                    oItem.UnitPrice = oDutyTranDetail.UnitPrice;
                    //oItem.VAT = (oDutyTranDetail.DutyPriceForRetail * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oItem.VAT = (oDutyTranDetail.TradePrice * oDutyTranDetail.DutyRate) * oDutyTranDetail.Qty;
                    oItem.VATType = oDutyTranDetail.VATType;
                    DutyTran oVatPaidData = new DutyTran();
                    oItem.VATPaidQty = oVatPaidData.GetVATPaidQty(oItem.ProductID, sTranNo);

                    //_TotalAmount_63_5 = _TotalAmount_63_5 + oItem.VAT;
                    oItem.InsertForPOSNew();

                }

            }

            oDutyTranVAT63_15.Amount = _TotalAmount_63_15;
            oDutyTranVAT63_15.UpdateToatlVATAmount();

            oDutyTranVAT63_5.Amount = _TotalAmount_63_5;
            oDutyTranVAT63_5.UpdateToatlVATAmount();



            oDutyAccount = new DutyAccount();
            oDutyAccount.DutyAccountTypeID = (int)Dictionary.DutyAccountNew.MUSHAK_6_3;
            oDutyAccount.Balance = _TotalAmount_63_15 + _TotalAmount_63_5;
            oDutyAccount.UpdateBalanceForPOS(true);



        }
        private bool GetIsSystemDiscountType(int nDiscountTypeID)
        {
            int nCount = 0;
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsSystemDiscountChargeItem)))
            {
                if (nDiscountTypeID == GetEnum)
                {
                    nCount++;

                }
            }
            if (nCount == 0)
                return false;
            else return true;
        }
        private void frmInvoice_Load(object sender, EventArgs e)
        {
            chkB2BDiscount.Visible = false;
            lblConsumer.Enabled = false;
            txtConsumerCode.Enabled = false;
            btnPicker.Enabled = false;
            LoadCombo();
            DataGridViewAlignment();
            btnEditLineItem.Visible = false;
            btnSave.Enabled = false;
            cmbSalesType.SelectedIndex = _nUIControl - 1;
        }

        public void RefreshByProductID(int nProductID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            _IsVatApplicableonNetPrice = 0;
            _VATType = 0;
            _nCostPrice = 0;

            try
            {
                cmd.CommandText = @"SELECT IsVatApplicableonNetPrice,VATType,CostPrice FROM t_Product a
                                join t_FinishedGoodsPrice b on a.ProductID = b.ProductID
                                where b.IsCurrent = 1 and a.ProductID = " + nProductID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    if (reader["IsVatApplicableonNetPrice"] != DBNull.Value)
                        _IsVatApplicableonNetPrice = Convert.ToInt32(reader["IsVatApplicableonNetPrice"].ToString());
                    else _IsVatApplicableonNetPrice = 0;

                    if (reader["VATType"] != DBNull.Value)
                        _VATType = Convert.ToInt32(reader["VATType"].ToString());
                    else _VATType = 0;


                    if (reader["CostPrice"] != DBNull.Value)
                        _nCostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    else _nCostPrice = 0;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        //public void LoadEOrderData(int nEOrderID)
        //{
        //    //DMSSecondarySalesOrder oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
        //    //oDMSSecondarySalesOrder.GetConfirmedQty(sOrderNo);
        //    //dgvLineItem.Rows.Clear();
        //    EcommerceOrder oEcommerceOrder = new EcommerceOrder();
        //    oSystemInfo = new SystemInfo();
        //    oSystemInfo.Refresh();
        //    oEcommerceOrder.GetItem(oSystemInfo.WarehouseID, nEOrderID);
        //    //this.Text = "E-Commerce Order";

        //    foreach (EcommerceOrderDetail oEcommerceOrderDetail in oEcommerceOrder)
        //    {
        //        DataGridViewRow oRow = new DataGridViewRow();
        //        oRow.CreateCells(dgvLineItem);
        //        oRow.Cells[0].Value = oEcommerceOrderDetail.ProductCode.ToString();
        //        oRow.Cells[2].Value = oEcommerceOrderDetail.ProductName.ToString();
        //        oRow.Cells[3].Value = oEcommerceOrderDetail.UnitPrice.ToString();
        //        oRow.Cells[4].Value = oEcommerceOrderDetail.CurrentStock.ToString();
        //        if (oEcommerceOrderDetail.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.NO)
        //        {
        //            oRow.Cells[5].Style.BackColor = Color.White;
        //            oRow.Cells[5].ReadOnly = false;
        //        }
        //        else
        //        {
        //            oRow.Cells[5].ReadOnly = true;
        //        }
        //        oRow.Cells[9].Value = oEcommerceOrderDetail.ProductID;
        //        oRow.Cells[10].Value = oEcommerceOrderDetail.IsBarcodeItem;
        //        oRow.Cells[11].Value = 0;
        //        //oRow.Cells[21].Value = oEcommerceOrderDetail.MAGID.ToString();
        //        //oRow.Cells[22].Value = oEcommerceOrderDetail.BrandID.ToString();
        //        //oRow.Cells[23].Value = oEcommerceOrderDetail.ConfirmedQty.ToString();
        //        oRow.Cells[24].Value = RefreshByProductID(oEcommerceOrderDetail.ProductID);

        //        dgvLineItem.Rows.Add(oRow);
        //    }

        //    //foreach (DMSSecondarySalesOrderDetail oItem in oDMSSecondarySalesOrder)
        //    //{
        //    //    DataGridViewRow oRow = new DataGridViewRow();
        //    //    oRow.CreateCells(dgvLineItem);
        //    //    oRow.Cells[0].Value = oItem.ProductCode;
        //    //    oRow.Cells[2].Value = oItem.ProductName;
        //    //    oRow.Cells[3].Value = oItem.RSP.ToString();
        //    //    oRow.Cells[4].Value = oItem.CurrentStock;
        //    //    if (oItem.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.NO)
        //    //    {
        //    //        oRow.Cells[5].Style.BackColor = Color.White;
        //    //        oRow.Cells[5].ReadOnly = false;
        //    //    }
        //    //    else
        //    //    {
        //    //        oRow.Cells[5].ReadOnly = true;
        //    //    }
        //    //    oRow.Cells[9].Value = oItem.ProductID;
        //    //    oRow.Cells[10].Value = oItem.IsBarcodeItem;
        //    //    oRow.Cells[11].Value = 0;
        //    //    oRow.Cells[21].Value = oItem.MAGID.ToString();
        //    //    oRow.Cells[22].Value = oItem.BrandID.ToString();
        //    //    oRow.Cells[23].Value = oItem.ConfirmedQty.ToString();
        //    //    oRow.Cells[24].Value = RefreshByProductID(oItem.ProductID);

        //    //    dgvLineItem.Rows.Add(oRow);
        //    //}

        //    dgvLineItem.ReadOnly = true;
        //    btnEditLineItem.Visible = false;

        //}

        public void LoadOrderData(string sOrderNo)
        {
            DMSSecondarySalesOrder oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
            oDMSSecondarySalesOrder.GetConfirmedQty(sOrderNo);
            dgvLineItem.Rows.Clear();
            foreach (DMSSecondarySalesOrderDetail oItem in oDMSSecondarySalesOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oItem.ProductCode;
                oRow.Cells[2].Value = oItem.ProductName;
                oRow.Cells[3].Value = oItem.RSP.ToString();
                oRow.Cells[4].Value = oItem.CurrentStock;
                if (oItem.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.NO)
                {
                    oRow.Cells[5].Style.BackColor = Color.White;
                    oRow.Cells[5].ReadOnly = false;
                }
                else
                {
                    oRow.Cells[5].ReadOnly = true;
                }
                oRow.Cells[9].Value = oItem.ProductID;
                oRow.Cells[10].Value = oItem.IsBarcodeItem;
                oRow.Cells[11].Value = 0;
                oRow.Cells[21].Value = oItem.MAGID.ToString();
                oRow.Cells[22].Value = oItem.BrandID.ToString();
                oRow.Cells[23].Value = oItem.ConfirmedQty.ToString();
                RefreshByProductID(oItem.ProductID);

                oRow.Cells[24].Value = _IsVatApplicableonNetPrice;

                oRow.Cells[25].Value = _VATType;
                oRow.Cells[26].Value = _nCostPrice;

                dgvLineItem.Rows.Add(oRow);
            }

            dgvLineItem.ReadOnly = true;
            btnEditLineItem.Visible = false;

        }

        private void DataGridViewAlignment()
        {
            this.dgvLineItem.Columns["txtUnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvLineItem.Columns["txtStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvLineItem.Columns["ColQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvLineItem.Columns["txtTotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvLineItem.Columns["colTotalCharge"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvLineItem.Columns["txtTotalDiscountAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvLineItem.Columns["txtNetPayable"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvLineItem.Columns["txtCollection"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        public void LoadCombo()
        {
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cmbSalesType.SelectedIndex = _nUIControl;

            oEmployees = new Employees();
            cmbEmpoyee.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oEmployees.GetShowroomSalesPerson();
            cmbEmpoyee.Items.Add("<Select Sales Person>");
            foreach (Employee oEmployee in oEmployees)
            {
                cmbEmpoyee.Items.Add("[" + oEmployee.EmployeeCode + "] " + oEmployee.EmployeeName);
            }
            if (oEmployees.Count > 0)
                cmbEmpoyee.SelectedIndex = 0;


            _oSalesPromotionTypes = new SalesPromotionTypes();
            _oSalesPromotionTypes.Refresh((int)Dictionary.YesOrNoStatus.YES);
            cmbPromotionType.Items.Add("<Select Promotion Type>");
            foreach (SalesPromotionType oSalesPromotionType in _oSalesPromotionTypes)
            {
                cmbPromotionType.Items.Add(oSalesPromotionType.SalesPromotionTypeName);
            }
            if (_oSalesPromotionTypes.Count > 0)
                cmbPromotionType.SelectedIndex = 0;

            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            if (oSystemInfo.OperationDate != null)
            {
                dtDeliveryDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate.ToString()).Date;
            }
            else
            {
                MessageBox.Show("Please Start Operation Date ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            cmbDeliveryPoint.Items.Add(oSystemInfo.WarehouseName);
            cmbDeliveryPoint.SelectedIndex = 0;

            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.RetailCustomerType)))
            {
                cmbConType.Items.Add(Enum.GetName(typeof(Dictionary.RetailCustomerType), GetEnum));
            }
            cmbConType.SelectedIndex = 0;

            oDistrict = new GeoLocations();
            oDistrict.RefreshDistrict();
            cmbDistrict.Items.Clear();
            cmbDistrict.Items.Add("<Select a District>");
            foreach (GeoLocation oDistricts in oDistrict)
            {
                cmbDistrict.Items.Add(oDistricts.GeoLocationName);
            }
            cmbDistrict.SelectedIndex = 0;

            cmbDeliveryMode.SelectedIndex = 0;

        }

        public void MenueDisable()
        {
            rdoNewConsumer.Enabled = false;
            rdoExistingConsumer.Enabled = false;
            rdoLeadCust.Enabled = false;
            lblConsumerHistory.Enabled = false;
            txtConsumerCode.Enabled = false;
            btnPicker.Enabled = false;
            txtCustomerName.Enabled = false;
            txtCustomerAddress.Enabled = false;
            txtDeliveryAddress.Enabled = false;
            txtEmail.Enabled = false;
            txtCell.Enabled = false;
            txtEmployeeNo.Enabled = false;
            txtTelePhone.Enabled = false;
            txtVatRegNo.Enabled = false;
            txtNationalID.Enabled = false;
            dtDateofBirth.Enabled = false;
            cmbConType.Enabled = false;
            lblCustomer.Visible = false;
            txtCtlCustCode.Visible = false;
            btnCtlCustPicker.Visible = false;
            txtCtlCustName.Visible = false;
            lblBGAmount.Visible = false;
            lblBGAmt.Visible = false;

            lblCreditLimit.Visible = false;
            lblCreditLimitLbl.Visible = false;

            lblCustomerBalance.Visible = false;
            lblCustomerBalanceAmt.Visible = false;
            txtConsumerCode.Text = "";
            txtConsumerName.Text = "";
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            txtDeliveryAddress.Text = "";
            txtEmail.Text = "";
            txtCell.Text = "";
            txtTelePhone.Text = "";
            txtEmployeeNo.Text = "";
            txtNationalID.Text = "";
            txtVatRegNo.Text = "";
            txtCtlCustCode.Text = "";

        }
        private void UILoad(int nUIControl)
        {
            MenueDisable();
            if (nUIControl == (int)Dictionary.SalesType.Retail)
            {
                //DMS
                _sDMSOrderNo = "";
                _sDMSCustomerCode = "";
                _nDMSOrderID = -1;
                dgvLineItem.Rows.Clear();
                txtCtlCustCode.Text = "";
                //END DMS


                this.Text = "Retail Invoice";
                sCustumerTypeID = "-1";

                txtSecConsumer.Enabled = true;
                txtSecMobileNo.Enabled = true;
                rdoNewConsumer.Enabled = true;
                rdoExistingConsumer.Enabled = true;
                rdoLeadCust.Enabled = true;
                lblConsumerHistory.Enabled = true;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtCustomerName.Enabled = true;
                txtCustomerAddress.Enabled = true;
                txtDeliveryAddress.Enabled = true;
                txtEmail.Enabled = true;
                txtCell.Enabled = true;
                txtEmployeeNo.Enabled = false;
                txtTelePhone.Enabled = true;
                txtVatRegNo.Enabled = true;
                txtNationalID.Enabled = true;
                dtDateofBirth.Enabled = true;
                cmbConType.Enabled = true;
                lblCustomer.Visible = false;
                txtCtlCustCode.Visible = false;
                btnCtlCustPicker.Visible = false;
                txtCtlCustName.Visible = false;
                lblBGAmount.Visible = false;
                lblBGAmt.Visible = false;
                lblCreditLimit.Visible = false;
                lblCreditLimitLbl.Visible = false;

                lblCustomerBalance.Visible = false;
                lblCustomerBalanceAmt.Visible = false;
                lblCustomer.Text = "Retail Customer:";
                txtConsumerCode.Text = "";
                txtConsumerName.Text = "";
                txtCustomerName.Text = "";
                txtCustomerAddress.Text = "";
                txtDeliveryAddress.Text = "";
                txtEmail.Text = "";
                txtCell.Text = "";
                txtTelePhone.Text = "";
                txtEmployeeNo.Text = "";
                txtNationalID.Text = "";
                txtVatRegNo.Text = "";
                txtCtlCustCode.Text = "";
                rdoNewConsumer.Checked = true;
                //cmbThana.Enabled = true;
                //cmbDistrict.Enabled = true;

            }
            else if (nUIControl == (int)Dictionary.SalesType.B2C)
            {
                //DMS
                _sDMSOrderNo = "";
                _sDMSCustomerCode = "";
                _nDMSOrderID = -1;
                dgvLineItem.Rows.Clear();
                txtCtlCustCode.Text = "";
                //END DMS

                this.Text = "Corporate Invoice (B2C)";
                if (Utility.CompanyInfo == "TEL")
                {
                    sCustumerTypeID = "245";
                }
                else
                {
                    sCustumerTypeID = "217";
                }
                txtSecConsumer.Enabled = true;
                txtSecMobileNo.Enabled = true;

                rdoNewConsumer.Enabled = true;
                rdoExistingConsumer.Enabled = true;
                rdoLeadCust.Enabled = true;
                lblConsumerHistory.Enabled = true;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtCustomerName.Enabled = true;
                txtCustomerAddress.Enabled = true;
                txtDeliveryAddress.Enabled = true;
                txtEmail.Enabled = true;
                txtCell.Enabled = true;
                txtEmployeeNo.Enabled = true;
                txtTelePhone.Enabled = true;
                txtVatRegNo.Enabled = true;
                txtNationalID.Enabled = true;
                dtDateofBirth.Enabled = true;
                cmbConType.Enabled = true;
                lblCustomer.Visible = true;
                txtCtlCustCode.Visible = true;
                btnCtlCustPicker.Visible = true;
                txtCtlCustName.Visible = true;
                lblBGAmount.Visible = false;
                lblBGAmt.Visible = false;
                lblCreditLimit.Visible = false;
                lblCreditLimitLbl.Visible = false;

                lblCustomerBalance.Visible = false;
                lblCustomerBalanceAmt.Visible = false;
                lblCustomer.Text = "B2C Customer:";
                txtConsumerCode.Text = "";
                txtConsumerName.Text = "";
                txtCustomerName.Text = "";
                txtCustomerAddress.Text = "";
                txtDeliveryAddress.Text = "";
                txtEmail.Text = "";
                txtCell.Text = "";
                txtTelePhone.Text = "";
                txtEmployeeNo.Text = "";
                txtNationalID.Text = "";
                txtVatRegNo.Text = "";
                txtCtlCustCode.Text = "";
                rdoNewConsumer.Checked = true;

            }
            else if (nUIControl == (int)Dictionary.SalesType.B2B)
            {
                this.Text = "Corporate Invoice (B2B)";
                if (Utility.CompanyInfo == "TEL")
                {
                    sCustumerTypeID = "245,249";
                }
                else
                {
                    sCustumerTypeID = "217,202";
                }
                txtSecConsumer.Enabled = false;
                txtSecMobileNo.Enabled = false;
                rdoNewConsumer.Enabled = false;
                rdoExistingConsumer.Enabled = false;
                rdoLeadCust.Enabled = false;
                lblConsumerHistory.Enabled = true;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtCustomerName.Enabled = true;
                txtCustomerAddress.Enabled = false;
                txtDeliveryAddress.Enabled = true;
                txtEmail.Enabled = false;
                txtCell.Enabled = false;
                txtEmployeeNo.Enabled = false;
                txtTelePhone.Enabled = false;
                txtVatRegNo.Enabled = true;
                txtNationalID.Enabled = false;
                dtDateofBirth.Enabled = false;
                cmbConType.Enabled = true;
                lblCustomer.Visible = true;
                txtCtlCustCode.Visible = true;
                btnCtlCustPicker.Visible = true;
                txtCtlCustName.Visible = true;
                lblBGAmount.Visible = false;
                lblBGAmt.Visible = false;
                lblCreditLimit.Visible = false;
                lblCreditLimitLbl.Visible = false;

                lblCustomerBalance.Visible = false;
                lblCustomerBalanceAmt.Visible = false;
                lblCustomer.Text = "B2B Customer:";
                txtConsumerCode.Text = "";
                txtConsumerName.Text = "";
                txtCustomerName.Text = "";
                txtCustomerAddress.Text = "";
                txtDeliveryAddress.Text = "";
                txtEmail.Text = "";
                txtCell.Text = "";
                txtTelePhone.Text = "";
                txtEmployeeNo.Text = "";
                txtNationalID.Text = "";
                txtVatRegNo.Text = "";
                txtCtlCustCode.Text = "";
                rdoLeadCust.Checked = true;
                if (oSystemInfo.IsActiveSalesOrder == (int)Dictionary.IsActive.Active)
                {
                    frmDMSSalesOrderSearch ofrmDMSSalesOrderSearch = new frmDMSSalesOrderSearch(nUIControl);
                    ofrmDMSSalesOrderSearch.ShowDialog();
                    if (ofrmDMSSalesOrderSearch.nDMSOrederID != -1)
                    {
                        _sDMSOrderNo = ofrmDMSSalesOrderSearch.sDMSOrderNo;
                        _sDMSCustomerCode = ofrmDMSSalesOrderSearch.sCustomerCode;
                        _nDMSOrderID = ofrmDMSSalesOrderSearch.nDMSOrederID;
                        this.Text = "Corporate Invoice (B2B)" + "[Order#" + ofrmDMSSalesOrderSearch.sDMSOrderNo + "]";
                        LoadOrderData(ofrmDMSSalesOrderSearch.sDMSOrderNo);
                        txtCtlCustCode.Text = ofrmDMSSalesOrderSearch.sCustomerCode;
                        txtCtlCustCode.Enabled = false;
                        txtCtlCustName.Enabled = false;
                        btnCtlCustPicker.Enabled = false;
                        cmbSalesType.Enabled = false;
                    }
                    else
                    {
                        _sDMSOrderNo = "";
                        _sDMSCustomerCode = "";
                        _nDMSOrderID = -1;
                        dgvLineItem.Rows.Clear();
                        txtCtlCustCode.Text = "";
                        txtCtlCustCode.Enabled = true;
                        txtCtlCustName.Enabled = true;
                        btnCtlCustPicker.Enabled = true;
                        cmbSalesType.Enabled = true;
                        //cmbSalesType.SelectedIndex = 0;
                    }
                }
                else
                {
                    _sDMSOrderNo = "";
                    _sDMSCustomerCode = "";
                    _nDMSOrderID = -1;
                    dgvLineItem.Rows.Clear();
                    txtCtlCustCode.Text = "";
                    txtCtlCustCode.Enabled = true;
                    txtCtlCustName.Enabled = true;
                    btnCtlCustPicker.Enabled = true;
                    cmbSalesType.Enabled = true;
                   // cmbSalesType.SelectedIndex = 0;
                }

            }
            else if (nUIControl == (int)Dictionary.POSInvoiceUIControl.RetailInvoice_HPA)
            {
                //DMS
                _sDMSOrderNo = "";
                _sDMSCustomerCode = "";
                _nDMSOrderID = -1;
                dgvLineItem.Rows.Clear();
                txtCtlCustCode.Text = "";
                //END DMS

                this.Text = "Retail Invoice (HPA)";
                if (Utility.CompanyInfo == "TEL")
                {
                    sCustumerTypeID = "241,244,252,253";
                }
                else
                {
                    sCustumerTypeID = "-1";
                }
                txtSecConsumer.Enabled = true;
                txtSecMobileNo.Enabled = true;
                rdoNewConsumer.Enabled = true;
                rdoExistingConsumer.Enabled = true;
                rdoLeadCust.Enabled = true;
                lblConsumerHistory.Enabled = true;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtCustomerName.Enabled = true;
                txtCustomerAddress.Enabled = true;
                txtDeliveryAddress.Enabled = true;
                txtEmail.Enabled = true;
                txtCell.Enabled = true;
                txtEmployeeNo.Enabled = false;
                txtTelePhone.Enabled = true;
                txtVatRegNo.Enabled = true;
                txtNationalID.Enabled = true;
                dtDateofBirth.Enabled = true;
                cmbConType.Enabled = true;
                lblCustomer.Visible = true;
                txtCtlCustCode.Visible = true;
                btnCtlCustPicker.Visible = true;
                txtCtlCustName.Visible = true;
                lblBGAmount.Visible = false;
                lblBGAmt.Visible = false;
                lblCreditLimit.Visible = false;
                lblCreditLimitLbl.Visible = false;

                lblCustomerBalance.Visible = false;
                lblCustomerBalanceAmt.Visible = false;
                lblCustomer.Text = "HPA Customer:";
                txtConsumerCode.Text = "";
                txtConsumerName.Text = "";
                txtCustomerName.Text = "";
                txtCustomerAddress.Text = "";
                txtDeliveryAddress.Text = "";
                txtEmail.Text = "";
                txtCell.Text = "";
                txtTelePhone.Text = "";
                txtEmployeeNo.Text = "";
                txtNationalID.Text = "";
                txtVatRegNo.Text = "";
                txtCtlCustCode.Text = "";
                rdoNewConsumer.Checked = true;
            }
            else if (nUIControl == (int)Dictionary.POSInvoiceUIControl.DealerInvoice)
            {
                this.Text = "Dealer Invoice";
                if (Utility.CompanyInfo == "TEL")
                {
                    sCustumerTypeID = "217,2,219";
                }
                else
                {
                    sCustumerTypeID = "-1";
                }
                txtSecConsumer.Enabled = false;
                txtSecMobileNo.Enabled = false;
                rdoNewConsumer.Enabled = false;
                rdoExistingConsumer.Enabled = false;
                rdoLeadCust.Enabled = true;
                lblConsumerHistory.Enabled = true;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtCustomerName.Enabled = false;
                txtCustomerAddress.Enabled = false;
                txtDeliveryAddress.Enabled = true;
                txtEmail.Enabled = false;
                txtCell.Enabled = false;
                txtEmployeeNo.Enabled = false;
                txtTelePhone.Enabled = false;
                txtVatRegNo.Enabled = true;
                txtNationalID.Enabled = false;
                dtDateofBirth.Enabled = false;
                cmbConType.Enabled = true;
                lblCustomer.Visible = true;
                txtCtlCustCode.Visible = true;
                btnCtlCustPicker.Visible = true;
                txtCtlCustName.Visible = true;
                lblBGAmount.Visible = true;
                lblBGAmt.Visible = true;
                lblCreditLimit.Visible = true;
                lblCreditLimitLbl.Visible = true;
                lblCustomerBalance.Visible = true;
                lblCustomerBalanceAmt.Visible = true;
                lblCustomer.Text = "Dealer Customer:";
                txtConsumerCode.Text = "";
                txtConsumerName.Text = "";
                txtCustomerName.Text = "";
                txtCustomerAddress.Text = "";
                txtDeliveryAddress.Text = "";
                txtEmail.Text = "";
                txtCell.Text = "";
                txtTelePhone.Text = "";
                txtEmployeeNo.Text = "";
                txtNationalID.Text = "";
                txtVatRegNo.Text = "";
                txtCtlCustCode.Text = "";
                rdoLeadCust.Checked = true;
                if (oSystemInfo.IsActiveSalesOrder == (int)Dictionary.IsActive.Active)
                {
                    frmDMSSalesOrderSearch ofrmDMSSalesOrderSearch = new frmDMSSalesOrderSearch(nUIControl);
                    ofrmDMSSalesOrderSearch.ShowDialog();
                    if (ofrmDMSSalesOrderSearch.nDMSOrederID != -1)
                    {
                        _sDMSOrderNo = ofrmDMSSalesOrderSearch.sDMSOrderNo;
                        _sDMSCustomerCode = ofrmDMSSalesOrderSearch.sCustomerCode;
                        _nDMSOrderID = ofrmDMSSalesOrderSearch.nDMSOrederID;
                        this.Text = "Corporate Invoice (B2B)" + "[Order#" + ofrmDMSSalesOrderSearch.sDMSOrderNo + "]";
                        LoadOrderData(ofrmDMSSalesOrderSearch.sDMSOrderNo);
                        txtCtlCustCode.Text = ofrmDMSSalesOrderSearch.sCustomerCode;
                        txtCtlCustCode.Enabled = false;
                        txtCtlCustName.Enabled = false;
                        btnCtlCustPicker.Enabled = false;
                        cmbSalesType.Enabled = false;
                    }
                    else
                    {
                        _sDMSOrderNo = "";
                        _sDMSCustomerCode = "";
                        _nDMSOrderID = -1;
                        dgvLineItem.Rows.Clear();
                        txtCtlCustCode.Text = "";
                        txtCtlCustCode.Enabled = true;
                        txtCtlCustName.Enabled = true;
                        btnCtlCustPicker.Enabled = true;
                        cmbSalesType.Enabled = true;
                        //cmbSalesType.SelectedIndex = 0;
                    }
                }
                else
                {
                    _sDMSOrderNo = "";
                    _sDMSCustomerCode = "";
                    _nDMSOrderID = -1;
                    dgvLineItem.Rows.Clear();
                    txtCtlCustCode.Text = "";
                    txtCtlCustCode.Enabled = true;
                    txtCtlCustName.Enabled = true;
                    btnCtlCustPicker.Enabled = true;
                    cmbSalesType.Enabled = true;
                    //cmbSalesType.SelectedIndex = 0;
                }
            }
            else if (nUIControl == (int)Dictionary.POSInvoiceUIControl.eStore)
            {
                //DMS
                _sDMSOrderNo = "";
                _sDMSCustomerCode = "";
                _nDMSOrderID = -1;
                dgvLineItem.Rows.Clear();
                txtCtlCustCode.Text = "";
                //END DMS

                cmbDeliveryMode.Enabled = true;
                this.Text = "e-Store Invoice";
                sCustumerTypeID = "-1";
                txtSecConsumer.Enabled = true;
                txtSecMobileNo.Enabled = true;
                rdoNewConsumer.Enabled = true;
                rdoExistingConsumer.Enabled = true;
                rdoLeadCust.Enabled = true;
                lblConsumerHistory.Enabled = true;
                txtConsumerCode.Enabled = true;
                btnPicker.Enabled = true;
                txtCustomerName.Enabled = true;
                txtCustomerAddress.Enabled = true;
                txtDeliveryAddress.Enabled = true;
                txtEmail.Enabled = true;
                txtCell.Enabled = true;
                txtEmployeeNo.Enabled = false;
                txtTelePhone.Enabled = true;
                txtVatRegNo.Enabled = true;
                txtNationalID.Enabled = true;
                dtDateofBirth.Enabled = true;
                cmbConType.Enabled = true;
                lblCustomer.Visible = false;
                txtCtlCustCode.Visible = false;
                btnCtlCustPicker.Visible = false;
                txtCtlCustName.Visible = false;
                lblBGAmount.Visible = false;
                lblBGAmt.Visible = false;
                lblCreditLimit.Visible = false;
                lblCreditLimitLbl.Visible = false;
                lblCustomerBalance.Visible = false;
                lblCustomerBalanceAmt.Visible = false;
                lblCustomer.Text = "Retail Customer:";
                txtConsumerCode.Text = "";
                txtConsumerName.Text = "";
                txtCustomerName.Text = "";
                txtCustomerAddress.Text = "";
                txtDeliveryAddress.Text = "";
                txtEmail.Text = "";
                txtCell.Text = "";
                txtTelePhone.Text = "";
                txtEmployeeNo.Text = "";
                txtNationalID.Text = "";
                txtVatRegNo.Text = "";
                txtCtlCustCode.Text = "";
                rdoNewConsumer.Checked = true;
                if (_sLeadNo != "")
                {
                    rdoLeadCust.Checked = true;
                    txtConsumerCode.Text = _sLeadNo;
                    rdoNewConsumer.Enabled = false;
                    rdoExistingConsumer.Enabled = false;
                    txtConsumerCode.Enabled = false;
                    txtConsumerName.Enabled = false;
                    btnPicker.Enabled = false;
                    cmbSalesType.Enabled = false;
                }

            }
        }

        private void rdoNewConsumer_CheckedChanged(object sender, EventArgs e)
        {
            lblConsumer.Enabled = false;
            txtConsumerCode.Enabled = false;
            btnPicker.Enabled = false;
            //ctlCustomer1.Enabled = true;
            txtCtlCustCode.Enabled = true;
            btnCtlCustPicker.Enabled = true;
            txtCtlCustName.Enabled = true;

            txtCustomerName.Enabled = true;
            txtCustomerAddress.Enabled = true;
            txtDeliveryAddress.Enabled = true;
            txtEmail.Enabled = true;
            txtCell.Enabled = true;
            txtTelePhone.Enabled = true;
            txtEmployeeNo.Enabled = true;
            txtNationalID.Enabled = true;
            txtVatRegNo.Enabled = true;
            cmbConType.Enabled = true;
            dtDateofBirth.Enabled = true;


            txtConsumerCode.Text = "";
            txtConsumerName.Text = "";
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            txtDeliveryAddress.Text = "";
            txtEmail.Text = "";
            txtCell.Text = "";
            txtTelePhone.Text = "";
            txtEmployeeNo.Text = "";
            txtNationalID.Text = "";
            txtVatRegNo.Text = "";
            txtCtlCustCode.Text = "";

        }

        private void rdoExistingConsumer_CheckedChanged(object sender, EventArgs e)
        {
            lblConsumer.Enabled = true;
            txtConsumerCode.Enabled = true;
            btnPicker.Enabled = true;
            if (_nUIControl == (int)Dictionary.SalesType.Retail || _nUIControl == (int)Dictionary.SalesType.B2C || _nUIControl == (int)Dictionary.SalesType.eStore || _nUIControl == (int)Dictionary.SalesType.HPA)
            {
                //ctlCustomer1.Enabled = false;
                txtCtlCustCode.Enabled = false;
                btnCtlCustPicker.Enabled = false;
                txtCtlCustName.Enabled = false;


                txtCustomerName.Enabled = false;
                txtCustomerAddress.Enabled = false;
                txtDeliveryAddress.Enabled = true;
                txtEmail.Enabled = false;
                txtCell.Enabled = false;
                txtTelePhone.Enabled = false;
                txtEmployeeNo.Enabled = false;
                txtNationalID.Enabled = false;
                txtVatRegNo.Enabled = false;
                cmbConType.Enabled = false;
                dtDateofBirth.Enabled = false;


                txtConsumerCode.Text = "";
                txtConsumerName.Text = "";
                txtCustomerName.Text = "";
                txtCustomerAddress.Text = "";
                txtDeliveryAddress.Text = "";
                txtEmail.Text = "";
                txtCell.Text = "";
                txtTelePhone.Text = "";
                txtEmployeeNo.Text = "";
                txtNationalID.Text = "";
                txtVatRegNo.Text = "";
                //ctlCustomer1.txtCode.Text = "";
                txtCtlCustCode.Text = "";
            }
            if (_nUIControl == (int)Dictionary.SalesType.B2C)
            {
                txtEmployeeNo.Enabled = true;
            }
        }

        private void rdoLeadCust_CheckedChanged(object sender, EventArgs e)
        {
            lblConsumer.Enabled = true;
            txtConsumerCode.Enabled = true;
            btnPicker.Enabled = true;
            //ctlCustomer1.Enabled = true;
            txtCtlCustCode.Enabled = true;
            btnCtlCustPicker.Enabled = true;
            txtCtlCustName.Enabled = true;

            txtCustomerName.Enabled = true;
            txtCustomerAddress.Enabled = true;
            txtDeliveryAddress.Enabled = true;
            txtEmail.Enabled = true;
            txtCell.Enabled = true;
            txtTelePhone.Enabled = true;
            txtEmployeeNo.Enabled = true;
            txtNationalID.Enabled = true;
            txtVatRegNo.Enabled = true;
            cmbConType.Enabled = true;
            dtDateofBirth.Enabled = true;

            txtConsumerCode.Text = "";
            txtConsumerName.Text = "";
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            txtDeliveryAddress.Text = "";
            txtEmail.Text = "";
            txtCell.Text = "";
            txtTelePhone.Text = "";
            txtEmployeeNo.Text = "";
            txtNationalID.Text = "";
            txtVatRegNo.Text = "";
            //ctlCustomer1.txtCode.Text = "";
            txtCtlCustCode.Text = "";
        }

        private void txtConsumerCode_TextChanged(object sender, EventArgs e)
        {
            if (rdoLeadCust.Checked == true)
            {
                SalesLead _oSalesLead = new SalesLead();
                _oSalesLead.LeadNo = txtConsumerCode.Text;
                txtConsumerName.ForeColor = System.Drawing.Color.Red;
                txtConsumerName.Text = "";
                DBController.Instance.OpenNewConnection();
                _oSalesLead.RefreshByLeadNo(_nUIControl);
                nLeadID = 0;
                nLeadID = _oSalesLead.LeadID;
                if (_oSalesLead.Name == null)
                {
                    _oSalesLead = null;
                    AppLogger.LogFatal("There is no data.");
                    txtCustomerName.Text = "";
                    txtCustomerAddress.Text = "";
                    txtEmail.Text = "";
                    txtCell.Text = "";
                    txtConsumerName.Text = "";
                    return;
                }
                else
                {
                    nFromLeadConsumeID = _oSalesLead.ConsumerID;
                    sFromLeadConsumerCode = _oSalesLead.ConsumerCode;

                    txtCustomerName.Text = _oSalesLead.Name.ToString();
                    txtCustomerAddress.Text = _oSalesLead.Address.ToString();
                    txtDeliveryAddress.Text = _oSalesLead.Address.ToString();
                    txtEmail.Text = _oSalesLead.Email.ToString();
                    txtCell.Text = _oSalesLead.ContactNo.ToString();
                    txtConsumerName.Text = _oSalesLead.Name.ToString();
                    txtConsumerCode.SelectionStart = 0;
                    txtConsumerCode.SelectionLength = txtConsumerCode.Text.Length;
                    txtConsumerCode.ForeColor = System.Drawing.Color.Empty;
                }
            }
            else if (rdoExistingConsumer.Checked == true)
            {
                oRetailConsumer = new RetailConsumer();
                txtConsumerCode.ForeColor = System.Drawing.Color.Red;
                txtConsumerName.Text = "";
                if (txtConsumerCode.Text.Length >= 1 && txtConsumerCode.Text.Length <= 25)
                {
                    oRetailConsumer.ConsumerCode = txtConsumerCode.Text;
                    oRetailConsumer.RefreshConsumerByType(_nUIControl);

                    if (oRetailConsumer.ConsumerName == null)
                    {
                        txtCustomerName.Text = "";
                        txtCustomerAddress.Text = "";
                        txtDeliveryAddress.Text = "";
                        txtEmail.Text = "";
                        txtCell.Text = "";
                        txtTelePhone.Text = "";
                        txtEmployeeNo.Text = "";
                        txtNationalID.Text = "";
                        txtVatRegNo.Text = "";
                        //ctlCustomer1.txtCode.Text = "";
                        txtCtlCustCode.Text = "";
                        txtSecConsumer.Text = "";
                        txtSecMobileNo.Text = "";

                        btnEmailVerification.Text = @"Invalid Email";
                        btnEmailVerification.ForeColor = Color.Red;
                        btnEmailVerification.Enabled = true;
                        txtEmail.Enabled = true;


                        oRetailConsumer = null;
                        AppLogger.LogFatal("There is no data.");
                        return;
                    }
                    else
                    {
                        txtConsumerName.Text = oRetailConsumer.ConsumerName.ToString();
                        cmbConType.SelectedIndex = oRetailConsumer.ConsumerType;
                        txtCustomerName.Text = oRetailConsumer.ConsumerName;
                        txtDeliveryAddress.Text = oRetailConsumer.DeliveryAddress;
                        txtCustomerAddress.Text = oRetailConsumer.Address;
                        txtEmail.Text = oRetailConsumer.Email;
                        txtNationalID.Text = oRetailConsumer.NationalID;
                        txtCell.Text = oRetailConsumer.CellNo;
                        txtTelePhone.Text = oRetailConsumer.PhoneNo;
                        txtVatRegNo.Text = oRetailConsumer.VatRegNo;
                        txtSecConsumer.Text = oRetailConsumer.SecondaryConsumer;
                        txtSecMobileNo.Text = oRetailConsumer.SecondaryMobileNo;

                        if (oRetailConsumer.IsVerifiedEmail == 1)
                        {
                            chkInvoiceSend.Checked = true;
                        }
                        else
                        {
                            chkInvoiceSend.Checked = false;
                        }

                        if (oRetailConsumer.DateofBirth != null)
                        {
                            dtDateofBirth.Checked = true;
                            dtDateofBirth.Value = Convert.ToDateTime(oRetailConsumer.DateofBirth);
                        }
                        txtConsumerCode.SelectionStart = 0;
                        txtConsumerCode.SelectionLength = txtConsumerCode.Text.Length;
                        txtConsumerCode.ForeColor = System.Drawing.Color.Empty;
                        //ctlCustomer1.Enabled = false;
                        txtCtlCustCode.Enabled = false;
                        btnCtlCustPicker.Enabled = false;
                        txtCtlCustName.Enabled = false;

                        //ctlCustomer1.txtCode.Text = oRetailConsumer.CustomerCode.ToString();
                        txtCtlCustCode.Text = oRetailConsumer.CustomerCode.ToString();
                        txtEmployeeNo.Text = oRetailConsumer.EmployeeCode;
                        if (oRetailConsumer.IsVerifiedEmail == (int)Dictionary.YesOrNoStatus.YES)
                        {
                            btnEmailVerification.Text = @"Verified";
                            btnEmailVerification.ForeColor = Color.Green;
                            btnEmailVerification.Enabled = false;
                            txtEmail.Enabled = true;
                        }
                        else
                        {
                            btnEmailVerification.Text = @"Invalid Email";
                            btnEmailVerification.ForeColor = Color.Red;
                            btnEmailVerification.Enabled = true;
                            txtEmail.Enabled = true;
                        }
                    }
                }
                else
                {
                    txtCustomerName.Text = "";
                    txtCustomerAddress.Text = "";
                    txtDeliveryAddress.Text = "";
                    txtEmail.Text = "";
                    txtCell.Text = "";
                    txtTelePhone.Text = "";
                    txtEmployeeNo.Text = "";
                    txtNationalID.Text = "";
                    txtVatRegNo.Text = "";
                    txtSecConsumer.Text = "";
                    txtSecMobileNo.Text = "";
                    //ctlCustomer1.txtCode.Text = "";
                    txtCtlCustCode.Text = oRetailConsumer.CustomerCode.ToString();

                    btnEmailVerification.Text = @"Invalid Email";
                    btnEmailVerification.ForeColor = Color.Red;
                    btnEmailVerification.Enabled = true;
                    txtEmail.Enabled = true;
                }

            }
            else if (rdoNewConsumer.Checked == true)
            {

            }

        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            if (rdoLeadCust.Checked == true)
            {
                oSalesLead = new SalesLead();
                frmSalesLeadConsumerSarch oObj = new frmSalesLeadConsumerSarch(_nUIControl);
                oObj.ShowDialog(oSalesLead);
                if (oSalesLead.LeadNo != null)
                {
                    nFromLeadConsumeID = oSalesLead.ConsumerID;
                    sFromLeadConsumerCode = oSalesLead.ConsumerCode;
                    txtConsumerCode.Text = oSalesLead.LeadNo.ToString();
                    txtConsumerName.Text = oSalesLead.Name.ToString();
                }
            }
            else if (rdoExistingConsumer.Checked == true)
            {
                oRetailConsumer = new RetailConsumer();
                frmReatilConsumerSearch oObj = new frmReatilConsumerSearch(_nUIControl, (int)Dictionary.Terminal.Branch_Office, oSystemInfo.WarehouseID);
                oObj.ShowDialog(oRetailConsumer);
                if (oRetailConsumer.ConsumerCode != null)
                {
                    txtConsumerCode.Text = oRetailConsumer.ConsumerCode.ToString();
                    //ctlCustomer1.txtCode.Text = oRetailConsumer.CustomerCode.ToString();
                    txtCtlCustCode.Text = oRetailConsumer.CustomerCode.ToString();
                    //ctlCustomer1.Enabled = false;
                    txtCtlCustCode.Enabled = false;
                    btnCtlCustPicker.Enabled = false;
                    txtCtlCustName.Enabled = false;
                }
            }
        }

        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == ItemCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";
            if (nColumnIndex == 0 && dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show(@"Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvLineItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    Product oProduct = new Product();
                    DBController.Instance.OpenNewConnection();
                    oProduct.ProductCode = sProductCode;
                    oProduct.Refresh();
                    if (oProduct.Flag != true)
                    {
                        if (oProduct.IsActiveProduct == (int)Dictionary.IsActive.InActive)
                        {
                            MessageBox.Show("Please select active product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value = "";
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                    }

                    if (oProduct.Flag != true)
                    {
                        _oProductDetail = new ProductDetail();
                        _oProductDetail.GetPriceConsideringEffectiveDate(Convert.ToDateTime(oSystemInfo.OperationDate),
                            oProduct.ProductID);

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 24].Value = oProduct.IsVatApplicableonNetPrice;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 25].Value = oProduct.VATType;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 26].Value = _oProductDetail.CostPrice;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oProduct.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.RSP;

                        oWUIUtility = new WUIUtility();
                        oWUIUtility.GetRetailStock(oSystemInfo.WarehouseID, oProduct.ProductID);
                        if (oWUIUtility.CurrentStock < 0)
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = 0;
                        else dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = oWUIUtility.CurrentStock;

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 9].Value = (oProduct.ProductID).ToString();
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 21].Value = oProduct.MAGID.ToString();
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 22].Value = oProduct.BrandID.ToString();
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 23].Value = 0;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                        _oProduct = new Product();
                        _oProduct.ProductID = Convert.ToInt32(oProduct.ProductID);
                        _oProduct.RefreshByProductID();
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 10].Value = _oProduct.IsBarcodeItem;
                        if (_oProduct.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.NO)
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].ReadOnly = false;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Style.BackColor = Color.White;
                        }
                        else
                        {
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].ReadOnly = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show(@"Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Invalid Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else if (nColumnIndex == 5)
            {

                if (dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
                {
                    SumNetPayableForNoBarcodeItem();
                    GetTotalRSAmount();
                }
            }


        }

        //private void GetNetAmount()
        //{
        //    double _Percentage = 0;
        //    double _FlatAmount = 0;

        //    double _InstallationCharge = 0;
        //    double _FreightCharge = 0;
        //    double _OtherCharge = 0;

        //    if (rdoPercentage.Checked == true)
        //    {
        //        if (txtParcentage.Text != "")
        //        {
        //            _Percentage = ((Convert.ToDouble(txtTotal.Text)) * (Convert.ToDouble(txtParcentage.Text) / 100));
        //        }
        //    }
        //    else
        //    {

        //        if (txtFlatAmount.Text != "")
        //        {
        //            _FlatAmount = Math.Round(Convert.ToDouble(txtFlatAmount.Text), 0, MidpointRounding.AwayFromZero);
        //        }
        //    }

        //    if (txtInstallationCharge.Text != "")
        //        _InstallationCharge = Math.Round(Convert.ToDouble(txtInstallationCharge.Text), 0, MidpointRounding.AwayFromZero);

        //    if (txtFreightCharge.Text != "")
        //        _FreightCharge = Math.Round(Convert.ToDouble(txtFreightCharge.Text), 0, MidpointRounding.AwayFromZero);

        //    if (txtOtherCharge.Text != "")
        //        _OtherCharge = Math.Round(Convert.ToDouble(txtOtherCharge.Text), 0, MidpointRounding.AwayFromZero);

        //    _TotalDiscount = Math.Round(Convert.ToDouble(txtTotalDisount.Text), 0, MidpointRounding.AwayFromZero) + _FlatAmount + Math.Round(_Percentage, 0, MidpointRounding.AwayFromZero) + Math.Round(Convert.ToDouble(txtSMSDiscount.Text), 0, MidpointRounding.AwayFromZero);

        //    oTELLib = new TELLib();
        //    txtNetPay.Text = oTELLib.TakaFormat(Math.Round(Convert.ToDouble(txtTotal.Text), 0, MidpointRounding.AwayFromZero) + _InstallationCharge + _FreightCharge + _OtherCharge + Math.Round(Convert.ToDouble(txtMarkUp.Text), 0, MidpointRounding.AwayFromZero) - _TotalDiscount);

        //    if (Math.Round(Convert.ToDouble(txtNetPay.Text), 0, MidpointRounding.AwayFromZero) >= 0)
        //        txtNetPay.ForeColor = Color.Green;
        //    else txtNetPay.ForeColor = Color.Red;
        //    lblpayableAmount.Text = "Net Payable (In Word): " + oTELLib.TakaWords(Math.Round(Convert.ToDouble(txtNetPay.Text), 0, MidpointRounding.AwayFromZero));
        //    txtDueAmount.Text = oTELLib.TakaFormat(Math.Round(Convert.ToDouble(txtNetPay.Text), 0, MidpointRounding.AwayFromZero) - Math.Round(Convert.ToDouble(txtCollectionAmount.Text), 0, MidpointRounding.AwayFromZero));

        //    if (Math.Round(Convert.ToDouble(txtDueAmount.Text), 0, MidpointRounding.AwayFromZero) != 0)
        //        txtDueAmount.ForeColor = Color.Red;
        //    else txtDueAmount.ForeColor = Color.Green;
        //}

        private void SumNetPayable()
        {
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    oItemRow.Cells[15].Value = Convert.ToDouble(oItemRow.Cells[13].Value) + Convert.ToDouble(oItemRow.Cells[14].Value) + Convert.ToDouble(oItemRow.Cells[20].Value);
                    oItemRow.Cells[16].Value = (Convert.ToDouble(oItemRow.Cells[3].Value) * Convert.ToDouble(oItemRow.Cells[5].Value)) + Convert.ToDouble(oItemRow.Cells[12].Value) - Convert.ToDouble(oItemRow.Cells[15].Value);

                }
            }
        }

        private void SumNetPayableForNoBarcodeItem()
        {
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    double _UnitPrice = 0;
                    try
                    {
                        _UnitPrice = Convert.ToDouble(oItemRow.Cells[3].Value);
                    }
                    catch
                    {
                        _UnitPrice = 0;
                    }
                    int nQty = 0;
                    try
                    {
                        nQty = Convert.ToInt32(oItemRow.Cells[5].Value);
                    }
                    catch
                    {
                        nQty = 0;
                    }
                    oItemRow.Cells[6].Value = nQty * _UnitPrice;
                    oItemRow.Cells[11].Value = "";
                    oItemRow.Cells[12].Value = 0;
                    oItemRow.Cells[15].Value = Convert.ToDouble(oItemRow.Cells[13].Value) + Convert.ToDouble(oItemRow.Cells[14].Value) + Convert.ToDouble(oItemRow.Cells[20].Value);
                    oItemRow.Cells[16].Value = (Convert.ToDouble(oItemRow.Cells[3].Value) * Convert.ToDouble(oItemRow.Cells[5].Value)) + Convert.ToDouble(oItemRow.Cells[12].Value) - Convert.ToDouble(oItemRow.Cells[15].Value);
                    oItemRow.Cells[18].Value = 0;
                    oItemRow.Cells[20].Value = 0;

                }
            }
        }

        public void GetTotalRSAmount()
        {
            txtGrossAmount.Text = "0.00";
            txtTotalCharge.Text = "0.00";
            txtPromoDiscount.Text = "0.00";
            txtTotalDiscount.Text = "0.00";
            txtNetPay.Text = "0.00";
            txtCollectionAmount.Text = "0.00";
            txtDueAmount.Text = "0.00";

            double _GrossAmount = 0;
            double _TotalCharge = 0;
            double _PromoDiscount = 0;
            double _TotalDiscount = 0;
            double _NetPayable = 0;
            double _CollectedAmount = 0;

            oTELLib = new TELLib();
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[3].Value.ToString().Trim() != "")
                    {
                        try
                        {
                            _GrossAmount += Convert.ToDouble(oItemRow.Cells[3].Value.ToString()) * Convert.ToDouble(oItemRow.Cells[5].Value.ToString());

                        }
                        catch
                        {

                        }
                        try
                        {
                            _TotalCharge += Convert.ToDouble(oItemRow.Cells[12].Value.ToString());
                        }
                        catch
                        {

                        }
                        try
                        {
                            _PromoDiscount += Convert.ToDouble(oItemRow.Cells[14].Value.ToString()) + Convert.ToDouble(oItemRow.Cells[20].Value.ToString());
                        }
                        catch
                        {

                        }
                        try
                        {
                            _TotalDiscount += Convert.ToDouble(oItemRow.Cells[15].Value.ToString());
                        }
                        catch
                        {

                        }

                        try
                        {
                            _NetPayable += Convert.ToDouble(oItemRow.Cells[16].Value.ToString());
                        }
                        catch
                        {

                        }
                        try
                        {
                            _CollectedAmount += Convert.ToDouble(oItemRow.Cells[18].Value.ToString());
                        }
                        catch
                        {

                        }

                    }

                }
            }
            txtGrossAmount.Text = oTELLib.TakaFormat(_GrossAmount);
            txtTotalCharge.Text = oTELLib.TakaFormat(_TotalCharge);
            txtPromoDiscount.Text = oTELLib.TakaFormat(_PromoDiscount);
            txtTotalDiscount.Text = oTELLib.TakaFormat(_TotalDiscount);
            txtNetPay.Text = oTELLib.TakaFormat(_NetPayable);
            txtCollectionAmount.Text = oTELLib.TakaFormat(_CollectedAmount);
            txtDueAmount.Text = oTELLib.TakaFormat(_NetPayable - _CollectedAmount);
        }

        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DBController.Instance.OpenNewConnection();

            #region Get Product

            if (e.ColumnIndex == 1)
            {
                if (_InvoiceLineItemButtonLock)
                {
                    return;
                }

                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm.sProductName != null)
                {
                    if (oForm._IsActive == (int)Dictionary.IsActive.InActive)
                    {
                        MessageBox.Show("Please select active product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oForm.sProductCode;
                oRow.Cells[2].Value = oForm.sProductName;
                oRow.Cells[9].Value = oForm.sProductId;
                oRow.Cells[11].Value = 0;
                oRow.Cells[24].Value = oForm._nIsVatApplicableonNetPrice;
                oRow.Cells[25].Value = oForm._nVATType;
                oRow.Cells[26].Value = oForm._CostPrice;

                if (oForm.sProductId != 0)
                {
                    oWUIUtility = new WUIUtility();
                    oWUIUtility.GetRetailStock(oSystemInfo.WarehouseID, oForm.sProductId);

                    if (oWUIUtility.CurrentStock < 0)
                        oRow.Cells[4].Value = 0;
                    else oRow.Cells[4].Value = oWUIUtility.CurrentStock;
                }
                if (oForm.sProductCode != null)
                {
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.GetPriceConsideringEffectiveDate(Convert.ToDateTime(oSystemInfo.OperationDate),
                        oForm.sProductId);


                    oRow.Cells[3].Value = _oProductDetail.RSP.ToString();

                    int nRowIndex = dgvLineItem.Rows.Add(oRow);

                    _oProduct = new Product();
                    _oProduct.ProductID = Convert.ToInt32(oForm.sProductId);
                    _oProduct.RefreshByProductID();
                    oRow.Cells[10].Value = _oProduct.IsBarcodeItem;
                    oRow.Cells[21].Value = _oProduct.MAGID.ToString();
                    oRow.Cells[22].Value = _oProduct.BrandID.ToString();
                    oRow.Cells[23].Value = 0;
                    if (_oProduct.IsBarcodeItem == (int)Dictionary.YesOrNoStatus.NO)
                    {
                        //dgvLineItem.Rows[e.RowIndex].Cells[6].ReadOnly = false;
                        oRow.Cells[5].Style.BackColor = Color.White;
                        oRow.Cells[5].ReadOnly = false;
                    }
                    else
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[5].ReadOnly = true;
                    }

                    if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                        GetTotalRSAmount();
                    }
                }

            }
            #endregion

            #region Get Barcode

            else if (e.ColumnIndex == 8)
            {
                if (_InvoiceLineItemButtonLock)
                {
                    return;
                }
                if (cmbDeliveryPoint.Text == "")
                {
                    MessageBox.Show("Please Select a Delivery Point.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    int temp = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[9].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Please Select a Product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmAvailableBarcode ofrmAvailableBarcode =
                    new frmAvailableBarcode(int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[9].Value.ToString()),
                        oSystemInfo.WarehouseID,_sBarcodeForDefective,1);
                ofrmAvailableBarcode.ShowDialog();
                ///New Code For Defective Item
                _sBarcodeForDefective = ofrmAvailableBarcode._sIsBarcodeForDefective;

                if (_sDMSOrderNo != "")
                {
                    if (ofrmAvailableBarcode._nCount > int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[23].Value.ToString()))
                    {
                        MessageBox.Show("Invoice qty must be less then or equal of order qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                if (int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[10].Value.ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                {
                    if (ofrmAvailableBarcode._nCount > 0)
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[7].Value = ofrmAvailableBarcode._sBarcode;
                        dgvLineItem.Rows[e.RowIndex].Cells[5].Value = ofrmAvailableBarcode._nCount;
                        double _UnitPrice = Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[3].Value);
                        dgvLineItem.Rows[e.RowIndex].Cells[6].Value = ofrmAvailableBarcode._nCount * _UnitPrice;
                        dgvLineItem.Rows[e.RowIndex].Cells[11].Value = ofrmAvailableBarcode._sChkBarcode;


                        dgvLineItem.Rows[e.RowIndex].Cells[18].Value = 0;
                        dgvLineItem.Rows[e.RowIndex].Cells[12].Value = 0;
                        dgvLineItem.Rows[e.RowIndex].Cells[20].Value = 0;
                        dgvLineItem.Rows[e.RowIndex].Cells[15].Value = 0;
                        dgvLineItem.Rows[e.RowIndex].Cells[16].Value = (ofrmAvailableBarcode._nCount * _UnitPrice) + Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[12].Value) - Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[15].Value);

                        GetTotalRSAmount();
                        SumNetPayable();
                    }
                }
                else
                {
                    GetTotalRSAmount();
                }
            }
            #endregion

            #region Get Payment 

            else if (e.ColumnIndex == 17)
            {
                if (_nUIControl != (int)Dictionary.SalesType.B2B)
                {
                    if (!_IsApplyPromotion)
                    {
                        MessageBox.Show("Please Click Apply Promotion first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }


                int nProductID = 0;
                int nPMCustomerID = 0;
                string sProductName = "";
                string sConsumerCode = "";
                double _CPDiscount = 0;
                double _TPDiscount = 0;

                if (rdoExistingConsumer.Checked == true)
                {
                    if (txtConsumerName.Text == "")
                    {
                        MessageBox.Show("Please select a consumer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                try
                {
                    int temp = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[9].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Please Select a Product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    int temp = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Please select product barcode first", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[5].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Please enter valid sales qty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_nUIControl == (int)Dictionary.SalesType.B2B ||
                    _nUIControl == (int)Dictionary.SalesType.Dealer || _nUIControl == (int)Dictionary.SalesType.B2C || _nUIControl == (int)Dictionary.SalesType.HPA)
                {
                    //if (ctlCustomer1.txtDescription.Text != "")
                    if (txtCtlCustName.Text != "")
                    {
                        //nPMCustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                        nPMCustomerID = _oCustomer.CustomerID;
                    }
                    else
                    {
                        MessageBox.Show("Please select valid customer first.", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    SystemInfo oSystem = new SystemInfo();

                    oSystem.Refresh();
                    nPMCustomerID = oSystem.CustomerID;
                }

                nProductID = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[9].Value.ToString());
                sProductName = dgvLineItem.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (rdoExistingConsumer.Checked == true)
                {
                    sConsumerCode = txtConsumerCode.Text.Trim();
                }
                else if (rdoLeadCust.Checked == true)
                {
                    sConsumerCode = sFromLeadConsumerCode.ToString();
                }
                try
                {
                    _CPDiscount = Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[14].Value.ToString());
                }
                catch
                {
                    _CPDiscount = 0;
                }
                try
                {
                    _TPDiscount = Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[20].Value.ToString());
                }
                catch
                {
                    _TPDiscount = 0;
                }
                DSInvoicePayment _oSinglePayment = new DSInvoicePayment();
                DSInvoicePayment oSinglePayment = new DSInvoicePayment();
                _oSinglePayment = GetSinglePayment(_oSinglePayment, nProductID);
                oSinglePayment.Merge(_oSinglePayment);
                oSinglePayment.AcceptChanges();


                DSInvoicePayment _oExptProductID = new DSInvoicePayment();
                DSInvoicePayment oExptProductID = new DSInvoicePayment();
                _oExptProductID = GetPaymentExptProductID(_oExptProductID, nProductID);
                oExptProductID.Merge(_oExptProductID);
                oExptProductID.AcceptChanges();


                DSSalesInvoiceDiscount _oSingleDiscount = new DSSalesInvoiceDiscount();
                DSSalesInvoiceDiscount oSingleDiscount = new DSSalesInvoiceDiscount();
                _oSingleDiscount = GetSingleProductDiscountCharge(_oSingleDiscount, nProductID);
                oSingleDiscount.Merge(_oSingleDiscount);
                oSingleDiscount.AcceptChanges();

                double _TotalCharge = 0;
                //double _PromotionalDiscount = 999;
                double _FrightAmt = 0;
                double _AdditionalDis = 0;
                double _CollectionAmt = 0;

                //try
                //{
                //    _InstallationAmt = Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[13].Value.ToString());
                //}
                //catch
                //{
                //    _InstallationAmt = 0;
                //}
                //try
                //{
                //    _OtherAmt = Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[14].Value.ToString());
                //}
                //catch
                //{
                //    _OtherAmt = 0;
                //}
                //try
                //{
                //    _FrightAmt = Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[12].Value.ToString());
                //}
                //catch
                //{
                //    _FrightAmt = 0;
                //}

                try
                {
                    _TotalCharge = Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[12].Value.ToString());
                }
                catch
                {
                    _TotalCharge = 0;
                }

                try
                {
                    _AdditionalDis = Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[13].Value.ToString());
                }
                catch
                {
                    _AdditionalDis = 0;
                }

                try
                {
                    _CollectionAmt = Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[18].Value.ToString());
                }
                catch
                {
                    _CollectionAmt = 0;
                }
                int nFreeEMITenureID = 0;
                try
                {
                    nFreeEMITenureID = Convert.ToInt32(dgvLineItem.Rows[e.RowIndex].Cells[19].Value.ToString());
                }
                catch
                {
                    nFreeEMITenureID = 0;
                }
                frmInvoicePayment ofrmInvoicePayment = new frmInvoicePayment(nProductID, sProductName, nPMCustomerID,
                    sConsumerCode, _CPDiscount, _nUIControl,
                    Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[6].Value.ToString()), oSingleDiscount, _AdditionalDis, _TotalCharge, _CollectionAmt, oSinglePayment, _IsApplicableB2BDiscountInv, _TPDiscount, oExptProductID, nFreeEMITenureID, chkB2BDiscount.Checked, Convert.ToInt32(dgvLineItem.Rows[e.RowIndex].Cells[5].Value.ToString()));
                ofrmInvoicePayment.ShowDialog();

                if (ofrmInvoicePayment._IsTrue == true)
                {
                    //ctlCustomer1.Enabled = false;
                    txtCtlCustCode.Enabled = false;
                    btnCtlCustPicker.Enabled = false;
                    txtCtlCustName.Enabled = false;

                    _IsApplicableB2BDiscountInv = ofrmInvoicePayment._IsApplicableB2BDiscountPayment;
                }

                #region Sales Invoice Additional Discount
                //Discount 
                if (ofrmInvoicePayment._IsTrue == true)
                {
                    DSSalesInvoiceDiscount oDSSalesInvoiceDiscount = new DSSalesInvoiceDiscount();
                    if (ofrmInvoicePayment.oDsSalesInvoiceDiscount.SalesInvoiceDiscount.Count > 0)
                    {
                        foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                        {
                            if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                            {
                                //if (nProductID != int.Parse(oItemRow.Cells[0].Value.ToString()) && int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Discount)
                                if (nProductID != int.Parse(oItemRow.Cells[0].Value.ToString()))
                                {
                                    if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Discount || int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Free_Product)
                                    {

                                        DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oSalesInvoiceDiscountRow =
                                            oDSSalesInvoiceDiscount.SalesInvoiceDiscount.NewSalesInvoiceDiscountRow();
                                        oSalesInvoiceDiscountRow.ProductID =
                                            Convert.ToInt32(oItemRow.Cells[0].Value.ToString().Trim());
                                        try
                                        {
                                            oSalesInvoiceDiscountRow.DiscountTypeID =
                                                Convert.ToInt32(oItemRow.Cells[1].Value.ToString().Trim());
                                        }
                                        catch
                                        {
                                            oSalesInvoiceDiscountRow.DiscountTypeID = -1;
                                        }
                                        try
                                        {
                                            oSalesInvoiceDiscountRow.DiscountTypeName =
                                                oItemRow.Cells[2].Value.ToString().Trim();
                                        }
                                        catch
                                        {
                                            oSalesInvoiceDiscountRow.DiscountTypeName = "";
                                        }
                                        try
                                        {
                                            oSalesInvoiceDiscountRow.Amount =
                                                Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                                        }
                                        catch
                                        {
                                            oSalesInvoiceDiscountRow.DiscountTypeID = 0;
                                        }
                                        try
                                        {
                                            oSalesInvoiceDiscountRow.InstrumentNo =
                                                oItemRow.Cells[4].Value.ToString().Trim();
                                        }
                                        catch
                                        {
                                            oSalesInvoiceDiscountRow.InstrumentNo = "";
                                        }
                                        try
                                        {
                                            oSalesInvoiceDiscountRow.Description =
                                                oItemRow.Cells[5].Value.ToString().Trim();
                                        }
                                        catch
                                        {
                                            oSalesInvoiceDiscountRow.Description = "";
                                        }
                                        oSalesInvoiceDiscountRow.Type = Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim());
                                        oSalesInvoiceDiscountRow.FreeProductID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                                        oSalesInvoiceDiscountRow.FreeQty = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
                                        oSalesInvoiceDiscountRow.IsBarcodeItemFreeProduct = Convert.ToInt32(oItemRow.Cells[10].Value.ToString().Trim());
                                        try
                                        {
                                            oSalesInvoiceDiscountRow.ProductSerialNo = oItemRow.Cells[9].Value.ToString().Trim();
                                        }
                                        catch
                                        {
                                            oSalesInvoiceDiscountRow.ProductSerialNo = "";
                                        }

                                        oDSSalesInvoiceDiscount.SalesInvoiceDiscount.AddSalesInvoiceDiscountRow(oSalesInvoiceDiscountRow);
                                        oDSSalesInvoiceDiscount.AcceptChanges();
                                    }
                                }
                            }
                        }

                    }
                    ///end Discount
                    ////Charge
                    if (ofrmInvoicePayment.oDsSalesInvoiceDiscount.SalesInvoiceCharge.Count > 0)
                    {
                        foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                        {
                            if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                            {
                                //if (nProductID != int.Parse(oItemRow.Cells[0].Value.ToString()) && int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Charge)
                                if (nProductID != int.Parse(oItemRow.Cells[0].Value.ToString()))
                                {
                                    if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Charge)
                                    {
                                        DSSalesInvoiceDiscount.SalesInvoiceChargeRow oSalesInvoiceChargeRow =
                                            oDSSalesInvoiceDiscount.SalesInvoiceCharge.NewSalesInvoiceChargeRow();
                                        oSalesInvoiceChargeRow.ProductID =
                                            Convert.ToInt32(oItemRow.Cells[0].Value.ToString().Trim());
                                        try
                                        {
                                            oSalesInvoiceChargeRow.DiscountTypeID =
                                                    Convert.ToInt32(oItemRow.Cells[1].Value.ToString().Trim());
                                        }
                                        catch
                                        {
                                            oSalesInvoiceChargeRow.DiscountTypeID = -1;
                                        }
                                        try
                                        {
                                            oSalesInvoiceChargeRow.DiscountTypeName =
                                                    oItemRow.Cells[2].Value.ToString().Trim();
                                        }
                                        catch
                                        {
                                            oSalesInvoiceChargeRow.DiscountTypeName = "";
                                        }
                                        try
                                        {
                                            oSalesInvoiceChargeRow.Amount =
                                                    Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                                        }
                                        catch
                                        {
                                            oSalesInvoiceChargeRow.DiscountTypeID = 0;
                                        }
                                        try
                                        {
                                            oSalesInvoiceChargeRow.InstrumentNo =
                                                    oItemRow.Cells[4].Value.ToString().Trim();
                                        }
                                        catch
                                        {
                                            oSalesInvoiceChargeRow.InstrumentNo = "";
                                        }
                                        try
                                        {
                                            oSalesInvoiceChargeRow.Description =
                                                    oItemRow.Cells[5].Value.ToString().Trim();
                                        }
                                        catch
                                        {
                                            oSalesInvoiceChargeRow.Description = "";
                                        }

                                        oSalesInvoiceChargeRow.Type = Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim());

                                        oDSSalesInvoiceDiscount.SalesInvoiceCharge.AddSalesInvoiceChargeRow(
                                            oSalesInvoiceChargeRow);
                                        oDSSalesInvoiceDiscount.AcceptChanges();
                                    }
                                }
                            }
                        }
                    }

                    ////end Charge
                    ofrmInvoicePayment.oDsSalesInvoiceDiscount.Merge(oDSSalesInvoiceDiscount);
                    ofrmInvoicePayment.oDsSalesInvoiceDiscount.AcceptChanges();
                    dgvSalesInvoiceDiscount.Rows.Clear();

                    if (ofrmInvoicePayment.oDsSalesInvoiceDiscount.SalesInvoiceDiscount.Count > 0)
                    {
                        foreach (
                        DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oSalesInvoiceDiscountRow in
                            ofrmInvoicePayment.oDsSalesInvoiceDiscount.SalesInvoiceDiscount)
                        {
                            DataGridViewRow oRow = new DataGridViewRow();
                            oRow.CreateCells(dgvSalesInvoiceDiscount);
                            oRow.Cells[0].Value = oSalesInvoiceDiscountRow.ProductID.ToString();
                            oRow.Cells[1].Value = oSalesInvoiceDiscountRow.DiscountTypeID.ToString();
                            oRow.Cells[2].Value = oSalesInvoiceDiscountRow.DiscountTypeName.ToString();
                            oRow.Cells[3].Value = oSalesInvoiceDiscountRow.Amount.ToString();
                            oRow.Cells[4].Value = oSalesInvoiceDiscountRow.InstrumentNo.ToString();
                            oRow.Cells[5].Value = oSalesInvoiceDiscountRow.Description.ToString();
                            oRow.Cells[6].Value = oSalesInvoiceDiscountRow.Type.ToString();

                            oRow.Cells[7].Value = oSalesInvoiceDiscountRow.FreeProductID.ToString();
                            oRow.Cells[8].Value = oSalesInvoiceDiscountRow.FreeQty.ToString();
                            oRow.Cells[9].Value = oSalesInvoiceDiscountRow.ProductSerialNo.ToString();
                            oRow.Cells[10].Value = oSalesInvoiceDiscountRow.IsBarcodeItemFreeProduct.ToString();

                            dgvSalesInvoiceDiscount.Rows.Add(oRow);
                        }
                    }
                    if (ofrmInvoicePayment.oDsSalesInvoiceDiscount.SalesInvoiceCharge.Count > 0)
                    {
                        foreach (
                        DSSalesInvoiceDiscount.SalesInvoiceChargeRow oSalesInvoiceChargeRow in
                            ofrmInvoicePayment.oDsSalesInvoiceDiscount.SalesInvoiceCharge)
                        {
                            DataGridViewRow oRow = new DataGridViewRow();
                            oRow.CreateCells(dgvSalesInvoiceDiscount);
                            oRow.Cells[0].Value = oSalesInvoiceChargeRow.ProductID.ToString();
                            oRow.Cells[1].Value = oSalesInvoiceChargeRow.DiscountTypeID.ToString();
                            oRow.Cells[2].Value = oSalesInvoiceChargeRow.DiscountTypeName.ToString();
                            oRow.Cells[3].Value = oSalesInvoiceChargeRow.Amount.ToString();
                            oRow.Cells[4].Value = oSalesInvoiceChargeRow.InstrumentNo.ToString();
                            oRow.Cells[5].Value = oSalesInvoiceChargeRow.Description.ToString();
                            oRow.Cells[6].Value = (int)Dictionary.DiscountChargeType.Charge;

                            oRow.Cells[7].Value = -1;
                            oRow.Cells[8].Value = -1;
                            oRow.Cells[9].Value = "";
                            oRow.Cells[10].Value = -1;

                            dgvSalesInvoiceDiscount.Rows.Add(oRow);
                        }
                    }

                }
                #endregion

                #region Sales Invoice Payment

                if (ofrmInvoicePayment._IsTrue == true)
                {
                    //ctlCustomer1.Enabled = false;
                    txtCtlCustCode.Enabled = false;
                    btnCtlCustPicker.Enabled = false;
                    txtCtlCustName.Enabled = false;

                    if (rdoExistingConsumer.Checked == true)
                    {
                        if (txtConsumerName.Text != "")
                        {
                            rdoExistingConsumer.Enabled = false;
                            rdoNewConsumer.Enabled = false;
                            rdoLeadCust.Enabled = false;
                        }
                    }

                    dgvLineItem.Rows[e.RowIndex].Cells[12].Value = ofrmInvoicePayment._AdditionalCharge;
                    dgvLineItem.Rows[e.RowIndex].Cells[13].Value = ofrmInvoicePayment._AdditionalDiscount;
                    dgvLineItem.Rows[e.RowIndex].Cells[15].Value = ofrmInvoicePayment._TotalDiscountAfter;
                    dgvLineItem.Rows[e.RowIndex].Cells[16].Value = ofrmInvoicePayment._TotalPayableAfter;
                    dgvLineItem.Rows[e.RowIndex].Cells[18].Value = ofrmInvoicePayment._TotalCollectionAfter;


                    DSInvoicePayment oDSInvoicePayment = new DSInvoicePayment();
                    foreach (DataGridViewRow oItemRow in dgvInvoicePayment.Rows)
                    {
                        if (oItemRow.Index < dgvInvoicePayment.Rows.Count)
                        {
                            if (nProductID != int.Parse(oItemRow.Cells[13].Value.ToString()))
                            {

                                DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow =
                                    oDSInvoicePayment.InvoicePayment.NewInvoicePaymentRow();
                                oInvoicePaymentRow.ProductID = int.Parse(oItemRow.Cells[13].Value.ToString());
                                oInvoicePaymentRow.ProductName = oItemRow.Cells[0].FormattedValue.ToString();
                                oInvoicePaymentRow.PaymentModeID = int.Parse(oItemRow.Cells[14].Value.ToString());
                                oInvoicePaymentRow.PaymentModeName = oItemRow.Cells[2].FormattedValue.ToString();
                                oInvoicePaymentRow.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                try
                                {
                                    oInvoicePaymentRow.BankID = int.Parse(oItemRow.Cells[15].Value.ToString());
                                    oInvoicePaymentRow.BankName = oItemRow.Cells[4].FormattedValue.ToString();
                                }
                                catch
                                {
                                    oInvoicePaymentRow.BankID = -1;
                                    oInvoicePaymentRow.BankName = "";
                                }
                                try
                                {
                                    oInvoicePaymentRow.CardType = int.Parse(oItemRow.Cells[16].Value.ToString());
                                    oInvoicePaymentRow.CardTypeName = oItemRow.Cells[5].FormattedValue.ToString();
                                }
                                catch
                                {
                                    oInvoicePaymentRow.CardType = -1;
                                    oInvoicePaymentRow.CardTypeName = "";
                                }
                                try
                                {
                                    oInvoicePaymentRow.POSMachineID = int.Parse(oItemRow.Cells[17].Value.ToString());
                                    oInvoicePaymentRow.POSMachineName = oItemRow.Cells[6].FormattedValue.ToString();
                                }
                                catch
                                {
                                    oInvoicePaymentRow.POSMachineID = -1;
                                    oInvoicePaymentRow.POSMachineName = "";
                                }

                                try
                                {
                                    oInvoicePaymentRow.CardCategory = int.Parse(oItemRow.Cells[18].Value.ToString());
                                    oInvoicePaymentRow.CardCategoryName =
                                        oItemRow.Cells[11].FormattedValue.ToString();
                                }
                                catch
                                {
                                    oInvoicePaymentRow.CardCategory = -1;
                                    oInvoicePaymentRow.CardCategoryName = "";
                                }
                                try
                                {
                                    oInvoicePaymentRow.ApprovalNo = oItemRow.Cells[12].Value.ToString().Trim();
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
                                    oInvoicePaymentRow.NoOfInstallment =
                                        int.Parse(oItemRow.Cells[8].Value.ToString().Trim());
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
                                    oInvoicePaymentRow.ExtendedEMICharge = Convert.ToDouble(oItemRow.Cells[19].Value.ToString().Trim());
                                }
                                catch
                                {
                                    oInvoicePaymentRow.ExtendedEMICharge = 0;
                                }
                                try
                                {
                                    oInvoicePaymentRow.BankDiscount = Convert.ToDouble(oItemRow.Cells[20].Value.ToString().Trim());
                                }
                                catch
                                {
                                    oInvoicePaymentRow.BankDiscount = 0;
                                }

                                try
                                {
                                    oInvoicePaymentRow.BGID = Convert.ToInt32(oItemRow.Cells[21].Value.ToString().Trim());
                                }
                                catch
                                {
                                    oInvoicePaymentRow.BGID = -1;
                                }
                                try
                                {
                                    oInvoicePaymentRow.CreditApprovalID = Convert.ToInt32(oItemRow.Cells[22].Value.ToString().Trim());
                                }
                                catch
                                {
                                    oInvoicePaymentRow.CreditApprovalID = -1;
                                }
                                try
                                {
                                    oInvoicePaymentRow.AdvancePaymentID = Convert.ToInt32(oItemRow.Cells[23].Value.ToString().Trim());
                                }
                                catch
                                {
                                    oInvoicePaymentRow.AdvancePaymentID = -1;
                                }

                                try
                                {
                                    oInvoicePaymentRow.BankDiscountID = Convert.ToInt32(oItemRow.Cells[24].Value.ToString().Trim());
                                }
                                catch
                                {
                                    oInvoicePaymentRow.BankDiscountID = -1;
                                }
                                try
                                {
                                    oInvoicePaymentRow.ExtendedEMIChargeID = Convert.ToInt32(oItemRow.Cells[25].Value.ToString().Trim());
                                }
                                catch
                                {
                                    oInvoicePaymentRow.ExtendedEMIChargeID = -1;
                                }


                                try
                                {
                                    oInvoicePaymentRow.SDApprovalNo = (oItemRow.Cells[26].Value.ToString().Trim());
                                }
                                catch
                                {
                                    oInvoicePaymentRow.SDApprovalNo = "";
                                }
                                oDSInvoicePayment.InvoicePayment.AddInvoicePaymentRow(oInvoicePaymentRow);
                                oDSInvoicePayment.AcceptChanges();
                            }
                        }
                    }
                    ofrmInvoicePayment.oDSInvoicePayment.Merge(oDSInvoicePayment);
                    ofrmInvoicePayment.oDSInvoicePayment.AcceptChanges();

                    dgvInvoicePayment.Rows.Clear();
                    foreach (
                        DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow in
                            ofrmInvoicePayment.oDSInvoicePayment.InvoicePayment)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvInvoicePayment);
                        oRow.Cells[0].Value = oInvoicePaymentRow.ProductName.ToString();
                        oRow.Cells[1].Value = dgvLineItem.Rows[e.RowIndex].Cells[5].Value.ToString();
                        oRow.Cells[2].Value = oInvoicePaymentRow.PaymentModeName.ToString();
                        oRow.Cells[3].Value = oInvoicePaymentRow.Amount.ToString();
                        try
                        {
                            oRow.Cells[4].Value = oInvoicePaymentRow.BankName.ToString();
                        }
                        catch
                        {
                            oRow.Cells[4].Value = "";
                        }

                        try
                        {
                            oRow.Cells[5].Value = oInvoicePaymentRow.CardTypeName.ToString();
                        }
                        catch
                        {
                            oRow.Cells[5].Value = "";
                        }

                        try
                        {
                            oRow.Cells[6].Value = oInvoicePaymentRow.POSMachineName.ToString();
                        }
                        catch
                        {
                            oRow.Cells[6].Value = "";
                        }


                        try
                        {
                            oRow.Cells[7].Value = Enum.GetName(typeof(Dictionary.YesOrNoStatus),
                                oInvoicePaymentRow.IsEMI);
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
                            oRow.Cells[9].Value = oInvoicePaymentRow.InstrumentNo.ToString();
                        }
                        catch
                        {
                            oRow.Cells[9].Value = "";
                        }
                        try
                        {
                            oRow.Cells[10].Value = oInvoicePaymentRow.InstrumentDate.ToString("dd-MMM-yyyy");
                        }
                        catch
                        {
                            oRow.Cells[10].Value = "";
                        }
                        try
                        {
                            oRow.Cells[11].Value = oInvoicePaymentRow.CardCategoryName.ToString();
                        }
                        catch
                        {
                            oRow.Cells[11].Value = "";
                        }
                        try
                        {
                            oRow.Cells[12].Value = oInvoicePaymentRow.ApprovalNo.ToString();
                        }
                        catch
                        {
                            oRow.Cells[12].Value = "";
                        }
                        oRow.Cells[13].Value = oInvoicePaymentRow.ProductID.ToString();

                        try
                        {
                            oRow.Cells[14].Value = oInvoicePaymentRow.PaymentModeID.ToString();
                        }
                        catch
                        {
                            oRow.Cells[14].Value = -1;
                        }
                        try
                        {

                            oRow.Cells[15].Value = oInvoicePaymentRow.BankID.ToString();
                        }
                        catch
                        {

                            oRow.Cells[15].Value = -1;
                        }
                        try
                        {
                            oRow.Cells[16].Value = oInvoicePaymentRow.CardType.ToString();
                        }
                        catch
                        {
                            oRow.Cells[16].Value = -1;
                        }
                        try
                        {
                            oRow.Cells[17].Value = oInvoicePaymentRow.POSMachineID.ToString();
                        }
                        catch
                        {
                            oRow.Cells[17].Value = -1;
                        }
                        try
                        {

                            oRow.Cells[18].Value = oInvoicePaymentRow.CardCategory.ToString();
                        }
                        catch
                        {

                            oRow.Cells[18].Value = -1;
                        }
                        try
                        {

                            oRow.Cells[19].Value = oInvoicePaymentRow.ExtendedEMICharge.ToString();
                        }
                        catch
                        {

                            oRow.Cells[19].Value = 0;
                        }
                        try
                        {

                            oRow.Cells[20].Value = oInvoicePaymentRow.BankDiscount.ToString();
                        }
                        catch
                        {

                            oRow.Cells[20].Value = 0;
                        }
                        try
                        {

                            oRow.Cells[21].Value = oInvoicePaymentRow.BGID.ToString();
                        }
                        catch
                        {

                            oRow.Cells[21].Value = -1;
                        }
                        try
                        {

                            oRow.Cells[22].Value = oInvoicePaymentRow.CreditApprovalID.ToString();
                        }
                        catch
                        {

                            oRow.Cells[22].Value = -1;
                        }
                        try
                        {

                            oRow.Cells[23].Value = oInvoicePaymentRow.AdvancePaymentID.ToString();
                        }
                        catch
                        {

                            oRow.Cells[23].Value = -1;
                        }




                        try
                        {

                            oRow.Cells[24].Value = oInvoicePaymentRow.BankDiscountID.ToString();
                        }
                        catch
                        {

                            oRow.Cells[24].Value = -1;
                        }
                        try
                        {

                            oRow.Cells[25].Value = oInvoicePaymentRow.ExtendedEMIChargeID.ToString();
                        }
                        catch
                        {

                            oRow.Cells[25].Value = -1;
                        }

                        try
                        {

                            oRow.Cells[26].Value = oInvoicePaymentRow.SDApprovalNo.ToString();
                        }
                        catch
                        {

                            oRow.Cells[26].Value = "";
                        }

                        dgvInvoicePayment.Rows.Add(oRow);
                    }

                }

                #endregion

                GetTotalRSAmount();
            }

            #endregion
        }

        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void dgvLineItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            AddPaymentRaw();
            AddDiscountRaw();
            GetTotalRSAmount();

        }

        private void dgvLineItem_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void SetPromoMap(int nDiscountTypeID, int nDataID, int nSlabID, int nOfferID, string sTableName, int nIsTableData, double Amount, int nFreeProductID, int nFreeQty, int nProductID, int nEMITenureID, int nIsScratchCardFreeProduct)
        {
            CJ.Class.POS.DSSalesInvoice.InvoiceDiscountChargeMapRow oInvoiceDiscountChargeMapRow = oInvoiceDiscountChargeMap.InvoiceDiscountChargeMap.NewInvoiceDiscountChargeMapRow();

            oInvoiceDiscountChargeMapRow.DiscountTypeID = nDiscountTypeID;
            oInvoiceDiscountChargeMapRow.DataID = nDataID;
            oInvoiceDiscountChargeMapRow.SlabID = nSlabID;
            oInvoiceDiscountChargeMapRow.OfferID = nOfferID;
            oInvoiceDiscountChargeMapRow.TableName = sTableName;
            oInvoiceDiscountChargeMapRow.IsTableData = nIsTableData;
            oInvoiceDiscountChargeMapRow.Amount = Amount;
            oInvoiceDiscountChargeMapRow.FreeProductID = nFreeProductID;
            oInvoiceDiscountChargeMapRow.FreeQty = nFreeQty;
            oInvoiceDiscountChargeMapRow.ProductID = nProductID;
            oInvoiceDiscountChargeMapRow.EMITenureID = nEMITenureID;
            oInvoiceDiscountChargeMapRow.IsScratchCardFreeProduct = nIsScratchCardFreeProduct;

            oInvoiceDiscountChargeMap.InvoiceDiscountChargeMap.AddInvoiceDiscountChargeMapRow(oInvoiceDiscountChargeMapRow);
            oInvoiceDiscountChargeMap.AcceptChanges();

        }
        //private void btApplyPromotion_Click(object sender, EventArgs e)
        //{
        //    if (ApplyPromotionValidation())
        //    {
        //        oInvoiceDiscountChargeMap = new DSSalesInvoice();

        //        dvgFreeProduct.Rows.Clear();
        //        //Clear Promo Discount & PromoEMI from Line Itme
        //        foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
        //        {
        //            if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
        //            {
        //                dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value = 0;
        //                dgvLineItem.Rows[_oItemRow.Index].Cells[19].Value = 0;
        //                dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value = 0;
        //            }
        //        }


        //        foreach (DataGridViewRow oItemRow in dsvPromotion.Rows)
        //        {
        //            if (oItemRow.Index < dsvPromotion.Rows.Count)
        //            {
        //                string sPromoType = oItemRow.Cells[2].Value.ToString().Trim();
        //                int nOfferID = Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim());
        //                int nSlabID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
        //                int nPromoID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
        //                int nMultiplyTimes = Convert.ToInt32(oItemRow.Cells[9].Value.ToString().Trim());

        //                _oConsumerPromotionEngines = new ConsumerPromotionEngines();
        //                double _DisAmt = 0;
        //                if (sPromoType == "CP")
        //                {
        //                    _oConsumerPromotionEngines.GetPromoOfferDetail(nPromoID, nSlabID, nOfferID);

        //                    foreach (ConsumerPromotionEngine oCPE in _oConsumerPromotionEngines)
        //                    {
        //                        if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Product)
        //                        {
        //                            Product oProduct = new Product();
        //                            oProduct.ProductID = oCPE.OfferProductID;
        //                            oProduct.RefreshByID();

        //                            DataGridViewRow oRow = new DataGridViewRow();
        //                            oRow.CreateCells(dvgFreeProduct);
        //                            oRow.Cells[0].Value = oProduct.ProductCode;
        //                            oRow.Cells[1].Value = oProduct.ProductName;
        //                            oRow.Cells[2].Value = oCPE.OfferQty * nMultiplyTimes;
        //                            oRow.Cells[5].Value = oProduct.ProductID;
        //                            oRow.Cells[6].Value = oProduct.CostPrice;
        //                            oRow.Cells[7].Value = oProduct.IsBarcodeItem;
        //                            dvgFreeProduct.Rows.Add(oRow);

        //                            #region Promo MAP
        //                            SetPromoMap(-1, nPromoID, nSlabID, nOfferID, "t_PromoCP", 1, 0, oProduct.ProductID, Convert.ToInt32(oRow.Cells[2].Value), -1, -1, 0);
        //                            #endregion 
        //                        }
        //                        else if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.FlatAmount || oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Parcent)
        //                        {
        //                            //Get Discount amount by percent
        //                            double _DisAmount = 0;
        //                            if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Parcent)
        //                            {
        //                                foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
        //                                {
        //                                    if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
        //                                    {
        //                                        int nProductID = Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim());
        //                                        DataRow[] oDR = _oDSPromoForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and ProductID='" + nProductID + "' ");

        //                                        if (oDR.Length != 0)
        //                                        {
        //                                            double _UnitPrice = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[3].Value);
        //                                            int _Qty = Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[5].Value);
        //                                            _DisAmount = _DisAmount + (_UnitPrice * _Qty);
        //                                        }
        //                                    }
        //                                }
        //                                _DisAmount = _DisAmount * oCPE.Discount / 100;
        //                            }

        //                            foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
        //                            {
        //                                if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
        //                                {
        //                                    int nProductID = Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim());
        //                                    DataRow[] oDR = _oDSPromoForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and ProductID='" + nProductID + "' ");

        //                                    if (oDR.Length != 0)
        //                                    {
        //                                        double _DiscountRatio = Convert.ToDouble(oDR[0]["DiscountRatio"]);
        //                                        _DisAmt = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value);
        //                                        if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.FlatAmount)
        //                                        {
        //                                            dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value = _DisAmt + (_DiscountRatio * oCPE.Discount / 100) * nMultiplyTimes;
        //                                        }
        //                                        else
        //                                        {
        //                                            dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value = Math.Round(_DisAmt + (_DiscountRatio * _DisAmount / 100) * nMultiplyTimes, 0);
        //                                        }

        //                                        #region Promo MAP
        //                                        SetPromoMap(3, nPromoID, nSlabID, nOfferID, "t_PromoCP", 1, Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value), -1, 0, nProductID, -1, -1);
        //                                        #endregion 

        //                                        dgvLineItem.Rows[_oItemRow.Index].Cells[15].Value = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[13].Value) + Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value) + Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value);
        //                                    }
        //                                }
        //                            }

        //                        }
        //                        else if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.EMI)
        //                        {
        //                            foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
        //                            {
        //                                if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
        //                                {
        //                                    int nProductID = Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim());
        //                                    DataRow[] oDR = _oDSPromoForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and ProductID='" + nProductID + "' ");

        //                                    if (oDR.Length != 0)
        //                                    {
        //                                        dgvLineItem.Rows[_oItemRow.Index].Cells[19].Value = oCPE.EMITenureID;

        //                                        #region Promo MAP
        //                                        SetPromoMap(-1, nPromoID, nSlabID, nOfferID, "t_PromoCP", 1, 0, -1, 0, Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim()), Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[19].Value), -1);
        //                                        #endregion 

        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    _oConsumerPromotionEngines.GetPromoTPOfferDetail(nPromoID, nSlabID, nOfferID);
        //                    foreach (ConsumerPromotionEngine oCPE in _oConsumerPromotionEngines)
        //                    {
        //                        double _DisAmount = 0;
        //                        if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Parcent)
        //                        {
        //                            foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
        //                            {
        //                                if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
        //                                {
        //                                    //int nProductID = Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim());
        //                                    int nMAGID = Convert.ToInt32(_oItemRow.Cells[21].Value.ToString().Trim());
        //                                    int nBrandID = Convert.ToInt32(_oItemRow.Cells[22].Value.ToString().Trim());
        //                                    double _Discount = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value);
        //                                    DataRow[] oDR = _oDSPromoTPForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and ProductGroupID='" + nMAGID + "' and BrandID='" + nBrandID + "' ");

        //                                    if (oDR.Length != 0)
        //                                    {
        //                                        double _UnitPrice = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[3].Value);
        //                                        int _Qty = Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[5].Value);

        //                                        dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value = _Discount + ((_UnitPrice * _Qty) * oCPE.Discount / 100) * nMultiplyTimes;
        //                                        //_DisAmount = _DisAmount + (_UnitPrice * _Qty);

        //                                        #region Promo MAP
        //                                        SetPromoMap(3, nPromoID, nSlabID, nOfferID, "t_PromoTP", 1, Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value), -1, 0, Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim()), -1, -1);
        //                                        #endregion 
        //                                    }
        //                                }
        //                            }
        //                            //_DisAmount = _DisAmount * oCPE.Discount / 100;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        SumNetPayable();
        //        GetTotalRSAmount();
        //        btnSave.Enabled = true;
        //    }
        //}

        private bool ApplyPromotionValidation()
        {
            if (dsvPromotion.Rows.Count == 0)
            {
                MessageBox.Show("There is no applicable promotion ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                foreach (DataGridViewRow oItemRow in dsvPromotion.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count)
                    {
                        if (Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim()) == 0)
                        {
                            MessageBox.Show("Please Select an Offer before applying promotion", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }

            }

            return true;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void GetPromotion()
        {


        }

        private void AddPaymentRaw()
        {
            DSInvoicePayment oDSInvoicePayment = new DSInvoicePayment();
            if (dgvLineItem.Rows.Count > 1)
            {
                foreach (DataGridViewRow oViewRow in dgvLineItem.Rows)
                {
                    if (oViewRow.Index < dgvLineItem.Rows.Count - 1)
                    {
                        int nProductID = int.Parse(oViewRow.Cells[9].Value.ToString());
                        foreach (DataGridViewRow oItemRow in dgvInvoicePayment.Rows)
                        {
                            if (oItemRow.Index < dgvInvoicePayment.Rows.Count)
                            {
                                //int nID = oItemRow.Index;
                                if (nProductID == int.Parse(oItemRow.Cells[13].Value.ToString()))
                                {

                                    DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow =
                                        oDSInvoicePayment.InvoicePayment.NewInvoicePaymentRow();
                                    oInvoicePaymentRow.ProductID = int.Parse(oItemRow.Cells[13].Value.ToString());
                                    oInvoicePaymentRow.SalesQty = int.Parse(oItemRow.Cells[1].Value.ToString());
                                    oInvoicePaymentRow.ProductName = oItemRow.Cells[0].FormattedValue.ToString();
                                    oInvoicePaymentRow.PaymentModeID = int.Parse(oItemRow.Cells[14].Value.ToString());
                                    oInvoicePaymentRow.PaymentModeName = oItemRow.Cells[2].FormattedValue.ToString();
                                    oInvoicePaymentRow.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                    try
                                    {
                                        oInvoicePaymentRow.BankID = int.Parse(oItemRow.Cells[15].Value.ToString());
                                        oInvoicePaymentRow.BankName = oItemRow.Cells[4].FormattedValue.ToString();
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.BankID = -1;
                                        oInvoicePaymentRow.BankName = "";
                                    }
                                    try
                                    {
                                        oInvoicePaymentRow.CardType = int.Parse(oItemRow.Cells[16].Value.ToString());
                                        oInvoicePaymentRow.CardTypeName = oItemRow.Cells[5].FormattedValue.ToString();
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.CardType = -1;
                                        oInvoicePaymentRow.CardTypeName = "";
                                    }
                                    try
                                    {
                                        oInvoicePaymentRow.POSMachineID = int.Parse(oItemRow.Cells[17].Value.ToString());
                                        oInvoicePaymentRow.POSMachineName = oItemRow.Cells[6].FormattedValue.ToString();
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.POSMachineID = -1;
                                        oInvoicePaymentRow.POSMachineName = "";
                                    }

                                    try
                                    {
                                        oInvoicePaymentRow.CardCategory = int.Parse(oItemRow.Cells[18].Value.ToString());
                                        oInvoicePaymentRow.CardCategoryName =
                                            oItemRow.Cells[11].FormattedValue.ToString();
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.CardCategory = -1;
                                        oInvoicePaymentRow.CardCategoryName = "";
                                    }
                                    try
                                    {
                                        oInvoicePaymentRow.ApprovalNo = oItemRow.Cells[12].Value.ToString().Trim();
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

                                        //oInvoicePaymentRow.IsEMI = oItemRow.Cells[7].FormattedValue.ToString();
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.IsEMI = -1;
                                        //oInvoicePaymentRow.IsEMI = "";
                                    }
                                    try
                                    {
                                        oInvoicePaymentRow.NoOfInstallment =
                                            int.Parse(oItemRow.Cells[8].Value.ToString().Trim());
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
                                        oInvoicePaymentRow.ExtendedEMICharge = Convert.ToDouble(oItemRow.Cells[19].Value.ToString().Trim());
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.ExtendedEMICharge = 0;
                                    }
                                    try
                                    {
                                        oInvoicePaymentRow.BankDiscount = Convert.ToDouble(oItemRow.Cells[20].Value.ToString().Trim());
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.BankDiscount = 0;
                                    }

                                    try
                                    {
                                        oInvoicePaymentRow.BGID = Convert.ToInt32(oItemRow.Cells[21].Value.ToString().Trim());
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.BGID = -1;
                                    }

                                    try
                                    {
                                        oInvoicePaymentRow.CreditApprovalID = Convert.ToInt32(oItemRow.Cells[22].Value.ToString().Trim());
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.CreditApprovalID = -1;
                                    }
                                    try
                                    {
                                        oInvoicePaymentRow.AdvancePaymentID = Convert.ToInt32(oItemRow.Cells[23].Value.ToString().Trim());
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.AdvancePaymentID = -1;
                                    }
                                    try
                                    {
                                        oInvoicePaymentRow.BankDiscountID = Convert.ToInt32(oItemRow.Cells[24].Value.ToString().Trim());
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.BankDiscountID = -1;
                                    }
                                    try
                                    {
                                        oInvoicePaymentRow.ExtendedEMIChargeID = Convert.ToInt32(oItemRow.Cells[25].Value.ToString().Trim());
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.ExtendedEMIChargeID = -1;
                                    }

                                    try
                                    {
                                        oInvoicePaymentRow.SDApprovalNo = (oItemRow.Cells[26].Value.ToString().Trim());
                                    }
                                    catch
                                    {
                                        oInvoicePaymentRow.SDApprovalNo = "";
                                    }
                                    oDSInvoicePayment.InvoicePayment.AddInvoicePaymentRow(oInvoicePaymentRow);
                                    oDSInvoicePayment.AcceptChanges();
                                }
                            }
                        }



                    }
                }
            }

            dgvInvoicePayment.Rows.Clear();
            foreach (DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow in oDSInvoicePayment.InvoicePayment)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvInvoicePayment);
                oRow.Cells[0].Value = oInvoicePaymentRow.ProductName.ToString();
                oRow.Cells[1].Value = oInvoicePaymentRow.SalesQty.ToString();
                oRow.Cells[2].Value = oInvoicePaymentRow.PaymentModeName.ToString();
                oRow.Cells[3].Value = oInvoicePaymentRow.Amount.ToString();
                try
                {
                    oRow.Cells[4].Value = oInvoicePaymentRow.BankName.ToString();
                }
                catch
                {
                    oRow.Cells[4].Value = "";
                }

                try
                {
                    oRow.Cells[5].Value = oInvoicePaymentRow.CardTypeName.ToString();
                }
                catch
                {
                    oRow.Cells[5].Value = "";
                }

                try
                {
                    oRow.Cells[6].Value = oInvoicePaymentRow.POSMachineName.ToString();
                }
                catch
                {
                    oRow.Cells[6].Value = "";
                }


                try
                {
                    oRow.Cells[7].Value = Enum.GetName(typeof(Dictionary.YesOrNoStatus),
                        oInvoicePaymentRow.IsEMI);
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
                    oRow.Cells[9].Value = oInvoicePaymentRow.InstrumentNo.ToString();
                }
                catch
                {
                    oRow.Cells[9].Value = "";
                }
                try
                {
                    oRow.Cells[10].Value = oInvoicePaymentRow.InstrumentDate.ToString("dd-MMM-yyyy");
                }
                catch
                {
                    oRow.Cells[10].Value = "";
                }
                try
                {
                    oRow.Cells[11].Value = oInvoicePaymentRow.CardCategoryName.ToString();
                }
                catch
                {
                    oRow.Cells[11].Value = "";
                }
                try
                {
                    oRow.Cells[12].Value = oInvoicePaymentRow.ApprovalNo.ToString();
                }
                catch
                {
                    oRow.Cells[12].Value = "";
                }
                oRow.Cells[13].Value = oInvoicePaymentRow.ProductID.ToString();

                try
                {
                    oRow.Cells[14].Value = oInvoicePaymentRow.PaymentModeID.ToString();
                }
                catch
                {
                    oRow.Cells[14].Value = -1;
                }
                try
                {

                    oRow.Cells[15].Value = oInvoicePaymentRow.BankID.ToString();
                }
                catch
                {

                    oRow.Cells[15].Value = -1;
                }
                try
                {
                    oRow.Cells[16].Value = oInvoicePaymentRow.CardType.ToString();
                }
                catch
                {
                    oRow.Cells[16].Value = -1;
                }
                try
                {
                    oRow.Cells[17].Value = oInvoicePaymentRow.POSMachineID.ToString();
                }
                catch
                {
                    oRow.Cells[17].Value = -1;
                }
                try
                {

                    oRow.Cells[18].Value = oInvoicePaymentRow.CardCategory.ToString();
                }
                catch
                {

                    oRow.Cells[18].Value = -1;
                }

                try
                {

                    oRow.Cells[19].Value = oInvoicePaymentRow.ExtendedEMICharge.ToString();
                }
                catch
                {

                    oRow.Cells[19].Value = 0;
                }
                try
                {

                    oRow.Cells[20].Value = oInvoicePaymentRow.BankDiscount.ToString();
                }
                catch
                {

                    oRow.Cells[20].Value = 0;
                }





                ////New ///

                try
                {

                    oRow.Cells[21].Value = oInvoicePaymentRow.BGID.ToString();
                }
                catch
                {

                    oRow.Cells[21].Value = -1;
                }
                try
                {

                    oRow.Cells[22].Value = oInvoicePaymentRow.CreditApprovalID.ToString();
                }
                catch
                {

                    oRow.Cells[22].Value = -1;
                }
                try
                {

                    oRow.Cells[23].Value = oInvoicePaymentRow.AdvancePaymentID.ToString();
                }
                catch
                {

                    oRow.Cells[23].Value = -1;
                }
                try
                {

                    oRow.Cells[24].Value = oInvoicePaymentRow.BankDiscountID.ToString();
                }
                catch
                {

                    oRow.Cells[24].Value = -1;
                }
                try
                {

                    oRow.Cells[25].Value = oInvoicePaymentRow.ExtendedEMIChargeID.ToString();
                }
                catch
                {

                    oRow.Cells[25].Value = -1;
                }
                try
                {

                    oRow.Cells[26].Value = oInvoicePaymentRow.SDApprovalNo.ToString();
                }
                catch
                {

                    oRow.Cells[26].Value = "";
                }


                dgvInvoicePayment.Rows.Add(oRow);
            }
        }

        private void AddDiscountRaw()
        {
            DSSalesInvoiceDiscount oDSSalesInvoiceDiscount = new DSSalesInvoiceDiscount();

            if (dgvLineItem.Rows.Count > 1)
            {
                foreach (DataGridViewRow oViewRow in dgvLineItem.Rows)
                {
                    if (oViewRow.Index < dgvLineItem.Rows.Count - 1)
                    {
                        int nProductID = int.Parse(oViewRow.Cells[9].Value.ToString());
                        foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                        {
                            if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                            {
                                //int nID = oItemRow.Index;
                                if (nProductID == int.Parse(oItemRow.Cells[0].Value.ToString()) && int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Discount)
                                {

                                    DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oSalesInvoiceDiscountRow =
                                    oDSSalesInvoiceDiscount.SalesInvoiceDiscount.NewSalesInvoiceDiscountRow();
                                    oSalesInvoiceDiscountRow.ProductID = int.Parse(oItemRow.Cells[0].Value.ToString());
                                    oSalesInvoiceDiscountRow.DiscountTypeID = int.Parse(oItemRow.Cells[1].Value.ToString());
                                    oSalesInvoiceDiscountRow.DiscountTypeName = oItemRow.Cells[2].Value.ToString();
                                    oSalesInvoiceDiscountRow.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                    oSalesInvoiceDiscountRow.InstrumentNo = oItemRow.Cells[4].Value.ToString();
                                    oSalesInvoiceDiscountRow.Description = oItemRow.Cells[5].Value.ToString();
                                    oSalesInvoiceDiscountRow.Type = int.Parse(oItemRow.Cells[6].Value.ToString());
                                    try
                                    {
                                        oSalesInvoiceDiscountRow.FreeProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                                    }
                                    catch
                                    {
                                        oSalesInvoiceDiscountRow.FreeProductID = -1;
                                    }
                                    try
                                    {
                                        oSalesInvoiceDiscountRow.FreeQty = int.Parse(oItemRow.Cells[8].Value.ToString());
                                    }
                                    catch
                                    {
                                        oSalesInvoiceDiscountRow.FreeQty = -1;
                                    }
                                    try
                                    {
                                        oSalesInvoiceDiscountRow.ProductSerialNo = oItemRow.Cells[9].Value.ToString();
                                    }
                                    catch
                                    {
                                        oSalesInvoiceDiscountRow.ProductSerialNo = "";
                                    }
                                    try
                                    {
                                        oSalesInvoiceDiscountRow.IsBarcodeItemFreeProduct = int.Parse(oItemRow.Cells[10].Value.ToString());
                                    }
                                    catch
                                    {
                                        oSalesInvoiceDiscountRow.IsBarcodeItemFreeProduct = -1;
                                    }

                                    oDSSalesInvoiceDiscount.SalesInvoiceDiscount.AddSalesInvoiceDiscountRow(oSalesInvoiceDiscountRow);
                                    oDSSalesInvoiceDiscount.AcceptChanges();
                                }
                            }
                        }
                        foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                        {
                            if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                            {
                                if (nProductID == int.Parse(oItemRow.Cells[0].Value.ToString()) && int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Charge)
                                {
                                    DSSalesInvoiceDiscount.SalesInvoiceChargeRow oSalesInvoiceChargeRow =
                                        oDSSalesInvoiceDiscount.SalesInvoiceCharge.NewSalesInvoiceChargeRow();
                                    oSalesInvoiceChargeRow.ProductID = int.Parse(oItemRow.Cells[0].Value.ToString());
                                    oSalesInvoiceChargeRow.DiscountTypeID = int.Parse(oItemRow.Cells[1].Value.ToString());
                                    oSalesInvoiceChargeRow.DiscountTypeName = oItemRow.Cells[2].Value.ToString();
                                    oSalesInvoiceChargeRow.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                    oSalesInvoiceChargeRow.InstrumentNo = oItemRow.Cells[4].Value.ToString();
                                    oSalesInvoiceChargeRow.Description = oItemRow.Cells[5].Value.ToString();
                                    oSalesInvoiceChargeRow.Type = int.Parse(oItemRow.Cells[6].Value.ToString());
                                    oDSSalesInvoiceDiscount.SalesInvoiceCharge.AddSalesInvoiceChargeRow(oSalesInvoiceChargeRow);
                                    oDSSalesInvoiceDiscount.AcceptChanges();
                                }
                            }
                        }
                    }
                }
            }

            dgvSalesInvoiceDiscount.Rows.Clear();
            foreach (DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oSalesInvoiceDiscountRow in oDSSalesInvoiceDiscount.SalesInvoiceDiscount)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvSalesInvoiceDiscount);
                oRow.Cells[0].Value = oSalesInvoiceDiscountRow.ProductID.ToString();
                oRow.Cells[1].Value = oSalesInvoiceDiscountRow.DiscountTypeID.ToString();
                oRow.Cells[2].Value = oSalesInvoiceDiscountRow.DiscountTypeName.ToString();
                oRow.Cells[3].Value = oSalesInvoiceDiscountRow.Amount.ToString();
                oRow.Cells[4].Value = oSalesInvoiceDiscountRow.InstrumentNo.ToString();
                oRow.Cells[5].Value = oSalesInvoiceDiscountRow.Description.ToString();
                oRow.Cells[6].Value = oSalesInvoiceDiscountRow.Type.ToString();
                oRow.Cells[7].Value = oSalesInvoiceDiscountRow.FreeProductID.ToString();
                oRow.Cells[8].Value = oSalesInvoiceDiscountRow.FreeQty.ToString();
                oRow.Cells[9].Value = oSalesInvoiceDiscountRow.ProductSerialNo.ToString();
                oRow.Cells[10].Value = oSalesInvoiceDiscountRow.IsBarcodeItemFreeProduct.ToString();
                dgvSalesInvoiceDiscount.Rows.Add(oRow);
            }
            foreach (DSSalesInvoiceDiscount.SalesInvoiceChargeRow oSalesInvoiceChargeRow in oDSSalesInvoiceDiscount.SalesInvoiceCharge)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvSalesInvoiceDiscount);
                oRow.Cells[0].Value = oSalesInvoiceChargeRow.ProductID.ToString();
                oRow.Cells[1].Value = oSalesInvoiceChargeRow.DiscountTypeID.ToString();
                oRow.Cells[2].Value = oSalesInvoiceChargeRow.DiscountTypeName.ToString();
                oRow.Cells[3].Value = oSalesInvoiceChargeRow.Amount.ToString();
                oRow.Cells[4].Value = oSalesInvoiceChargeRow.InstrumentNo.ToString();
                oRow.Cells[5].Value = oSalesInvoiceChargeRow.Description.ToString();
                oRow.Cells[6].Value = (int)Dictionary.DiscountChargeType.Charge;
                dgvSalesInvoiceDiscount.Rows.Add(oRow);
            }
        }

        public DSInvoicePayment GetSinglePayment(DSInvoicePayment _singlePayment, int nProductID)
        {
            _singlePayment = new DSInvoicePayment();
            foreach (DataGridViewRow oItemRow in dgvInvoicePayment.Rows)
            {
                if (oItemRow.Index < dgvInvoicePayment.Rows.Count)
                {
                    if (nProductID == int.Parse(oItemRow.Cells[13].Value.ToString()))
                    {
                        DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow =
                            _singlePayment.InvoicePayment.NewInvoicePaymentRow();
                        oInvoicePaymentRow.ProductID = int.Parse(oItemRow.Cells[13].Value.ToString());
                        oInvoicePaymentRow.SalesQty = int.Parse(oItemRow.Cells[1].Value.ToString());
                        oInvoicePaymentRow.ProductName = oItemRow.Cells[0].FormattedValue.ToString();
                        oInvoicePaymentRow.PaymentModeID = int.Parse(oItemRow.Cells[14].Value.ToString());
                        oInvoicePaymentRow.PaymentModeName = oItemRow.Cells[2].FormattedValue.ToString();
                        oInvoicePaymentRow.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                        try
                        {
                            oInvoicePaymentRow.BankID = int.Parse(oItemRow.Cells[15].Value.ToString());
                            oInvoicePaymentRow.BankName = oItemRow.Cells[4].FormattedValue.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.BankID = -1;
                            oInvoicePaymentRow.BankName = "";
                        }
                        try
                        {
                            oInvoicePaymentRow.CardType = int.Parse(oItemRow.Cells[16].Value.ToString());
                            oInvoicePaymentRow.CardTypeName = oItemRow.Cells[5].FormattedValue.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.CardType = -1;
                            oInvoicePaymentRow.CardTypeName = "";
                        }
                        try
                        {
                            oInvoicePaymentRow.POSMachineID = int.Parse(oItemRow.Cells[17].Value.ToString());
                            oInvoicePaymentRow.POSMachineName = oItemRow.Cells[6].FormattedValue.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.POSMachineID = -1;
                            oInvoicePaymentRow.POSMachineName = "";
                        }

                        try
                        {
                            oInvoicePaymentRow.CardCategory = int.Parse(oItemRow.Cells[18].Value.ToString());
                            oInvoicePaymentRow.CardCategoryName =
                                oItemRow.Cells[11].FormattedValue.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.CardCategory = -1;
                            oInvoicePaymentRow.CardCategoryName = "";
                        }
                        try
                        {
                            oInvoicePaymentRow.ApprovalNo = oItemRow.Cells[12].Value.ToString().Trim();
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

                            //oInvoicePaymentRow.IsEMI = oItemRow.Cells[7].FormattedValue.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.IsEMI = 0;
                            //oInvoicePaymentRow.IsEMI = "";
                        }
                        try
                        {
                            oInvoicePaymentRow.NoOfInstallment =
                                int.Parse(oItemRow.Cells[8].Value.ToString().Trim());
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
                            oInvoicePaymentRow.ExtendedEMICharge = Convert.ToDouble(oItemRow.Cells[19].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.ExtendedEMICharge = 0;
                        }
                        try
                        {
                            oInvoicePaymentRow.BankDiscount = Convert.ToDouble(oItemRow.Cells[20].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.BankDiscount = 0;
                        }

                        try
                        {
                            oInvoicePaymentRow.BGID = Convert.ToInt32(oItemRow.Cells[21].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.BGID = -1;
                        }
                        try
                        {
                            oInvoicePaymentRow.CreditApprovalID = Convert.ToInt32(oItemRow.Cells[22].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.CreditApprovalID = -1;
                        }
                        try
                        {
                            oInvoicePaymentRow.AdvancePaymentID = Convert.ToInt32(oItemRow.Cells[23].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.AdvancePaymentID = -1;
                        }

                        try
                        {
                            oInvoicePaymentRow.BankDiscountID = Convert.ToInt32(oItemRow.Cells[24].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.BankDiscountID = -1;
                        }
                        try
                        {
                            oInvoicePaymentRow.ExtendedEMIChargeID = Convert.ToInt32(oItemRow.Cells[25].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.ExtendedEMIChargeID = -1;
                        }

                        try
                        {
                            oInvoicePaymentRow.SDApprovalNo = (oItemRow.Cells[26].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.SDApprovalNo = "";
                        }

                        _singlePayment.InvoicePayment.AddInvoicePaymentRow(oInvoicePaymentRow);
                        _singlePayment.AcceptChanges();
                    }
                }
            }
            return _singlePayment;
        }

        public DSInvoicePayment GetPaymentExptProductID(DSInvoicePayment _singlePayment, int nProductID)
        {
            _singlePayment = new DSInvoicePayment();
            foreach (DataGridViewRow oItemRow in dgvInvoicePayment.Rows)
            {
                if (oItemRow.Index < dgvInvoicePayment.Rows.Count)
                {
                    if (nProductID != int.Parse(oItemRow.Cells[13].Value.ToString()))
                    {
                        DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow =
                            _singlePayment.InvoicePayment.NewInvoicePaymentRow();
                        oInvoicePaymentRow.ProductID = int.Parse(oItemRow.Cells[13].Value.ToString());
                        oInvoicePaymentRow.SalesQty = int.Parse(oItemRow.Cells[1].Value.ToString());
                        oInvoicePaymentRow.ProductName = oItemRow.Cells[0].FormattedValue.ToString();
                        oInvoicePaymentRow.PaymentModeID = int.Parse(oItemRow.Cells[14].Value.ToString());
                        oInvoicePaymentRow.PaymentModeName = oItemRow.Cells[2].FormattedValue.ToString();
                        oInvoicePaymentRow.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                        try
                        {
                            oInvoicePaymentRow.BankID = int.Parse(oItemRow.Cells[15].Value.ToString());
                            oInvoicePaymentRow.BankName = oItemRow.Cells[4].FormattedValue.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.BankID = -1;
                            oInvoicePaymentRow.BankName = "";
                        }
                        try
                        {
                            oInvoicePaymentRow.CardType = int.Parse(oItemRow.Cells[16].Value.ToString());
                            oInvoicePaymentRow.CardTypeName = oItemRow.Cells[5].FormattedValue.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.CardType = -1;
                            oInvoicePaymentRow.CardTypeName = "";
                        }
                        try
                        {
                            oInvoicePaymentRow.POSMachineID = int.Parse(oItemRow.Cells[17].Value.ToString());
                            oInvoicePaymentRow.POSMachineName = oItemRow.Cells[6].FormattedValue.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.POSMachineID = -1;
                            oInvoicePaymentRow.POSMachineName = "";
                        }

                        try
                        {
                            oInvoicePaymentRow.CardCategory = int.Parse(oItemRow.Cells[18].Value.ToString());
                            oInvoicePaymentRow.CardCategoryName =
                                oItemRow.Cells[11].FormattedValue.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.CardCategory = -1;
                            oInvoicePaymentRow.CardCategoryName = "";
                        }
                        try
                        {
                            oInvoicePaymentRow.ApprovalNo = oItemRow.Cells[12].Value.ToString().Trim();
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

                            //oInvoicePaymentRow.IsEMI = oItemRow.Cells[7].FormattedValue.ToString();
                        }
                        catch
                        {
                            oInvoicePaymentRow.IsEMI = 0;
                            //oInvoicePaymentRow.IsEMI = "";
                        }
                        try
                        {
                            oInvoicePaymentRow.NoOfInstallment =
                                int.Parse(oItemRow.Cells[8].Value.ToString().Trim());
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
                            oInvoicePaymentRow.ExtendedEMICharge = Convert.ToDouble(oItemRow.Cells[19].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.ExtendedEMICharge = 0;
                        }
                        try
                        {
                            oInvoicePaymentRow.BankDiscount = Convert.ToDouble(oItemRow.Cells[20].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.BankDiscount = 0;
                        }

                        try
                        {
                            oInvoicePaymentRow.BGID = Convert.ToInt32(oItemRow.Cells[21].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.BGID = -1;
                        }
                        try
                        {
                            oInvoicePaymentRow.CreditApprovalID = Convert.ToInt32(oItemRow.Cells[22].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.CreditApprovalID = -1;
                        }
                        try
                        {
                            oInvoicePaymentRow.AdvancePaymentID = Convert.ToInt32(oItemRow.Cells[23].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.AdvancePaymentID = -1;
                        }

                        try
                        {
                            oInvoicePaymentRow.BankDiscountID = Convert.ToInt32(oItemRow.Cells[24].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.BankDiscountID = -1;
                        }
                        try
                        {
                            oInvoicePaymentRow.ExtendedEMIChargeID = Convert.ToInt32(oItemRow.Cells[25].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.ExtendedEMIChargeID = -1;
                        }

                        try
                        {
                            oInvoicePaymentRow.SDApprovalNo = (oItemRow.Cells[26].Value.ToString().Trim());
                        }
                        catch
                        {
                            oInvoicePaymentRow.SDApprovalNo = "";
                        }

                        _singlePayment.InvoicePayment.AddInvoicePaymentRow(oInvoicePaymentRow);
                        _singlePayment.AcceptChanges();
                    }
                }
            }
            return _singlePayment;
        }

        public DSSalesInvoiceDiscount GetSingleProductDiscountCharge(DSSalesInvoiceDiscount _singleDiscount, int nProductID)
        {
            _singleDiscount = new DSSalesInvoiceDiscount();
            foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
            {
                if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                {
                    //if (nProductID == int.Parse(oItemRow.Cells[0].Value.ToString()) && int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Discount || int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Free_Product)
                    if (nProductID == int.Parse(oItemRow.Cells[0].Value.ToString()))
                    {
                        if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Discount || int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Free_Product)
                        {
                            DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oSalesInvoiceDiscountRow = _singleDiscount.SalesInvoiceDiscount.NewSalesInvoiceDiscountRow();
                            oSalesInvoiceDiscountRow.ProductID = int.Parse(oItemRow.Cells[0].Value.ToString());
                            oSalesInvoiceDiscountRow.DiscountTypeID = int.Parse(oItemRow.Cells[1].Value.ToString());
                            oSalesInvoiceDiscountRow.DiscountTypeName = oItemRow.Cells[2].Value.ToString();
                            oSalesInvoiceDiscountRow.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                            oSalesInvoiceDiscountRow.InstrumentNo = oItemRow.Cells[4].Value.ToString();
                            oSalesInvoiceDiscountRow.Description = oItemRow.Cells[5].Value.ToString();
                            oSalesInvoiceDiscountRow.Type = int.Parse(oItemRow.Cells[6].Value.ToString());
                            try
                            {
                                oSalesInvoiceDiscountRow.FreeProductID = int.Parse(oItemRow.Cells[7].Value.ToString());
                            }
                            catch
                            {
                                oSalesInvoiceDiscountRow.FreeProductID = -1;
                            }
                            try
                            {
                                oSalesInvoiceDiscountRow.FreeQty = int.Parse(oItemRow.Cells[8].Value.ToString());
                            }
                            catch
                            {
                                oSalesInvoiceDiscountRow.FreeQty = -1;
                            }
                            try
                            {
                                oSalesInvoiceDiscountRow.ProductSerialNo = oItemRow.Cells[9].Value.ToString();
                            }
                            catch
                            {
                                oSalesInvoiceDiscountRow.ProductSerialNo = "";
                            }
                            try
                            {
                                oSalesInvoiceDiscountRow.IsBarcodeItemFreeProduct = int.Parse(oItemRow.Cells[10].Value.ToString());
                            }
                            catch
                            {
                                oSalesInvoiceDiscountRow.IsBarcodeItemFreeProduct = -1;
                            }

                            _singleDiscount.SalesInvoiceDiscount.AddSalesInvoiceDiscountRow(oSalesInvoiceDiscountRow);
                            _singleDiscount.AcceptChanges();
                        }
                    }
                }
            }
            DSSalesInvoiceDiscount _oDSsalesInvoCharge = new DSSalesInvoiceDiscount();
            foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
            {
                if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                {
                    //if (nProductID == int.Parse(oItemRow.Cells[0].Value.ToString()) && int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Charge)
                    if (nProductID == int.Parse(oItemRow.Cells[0].Value.ToString()))
                    {
                        if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Charge)
                        {
                            DSSalesInvoiceDiscount.SalesInvoiceChargeRow oSalesInvoiceChargeRow = _oDSsalesInvoCharge.SalesInvoiceCharge.NewSalesInvoiceChargeRow();
                            oSalesInvoiceChargeRow.ProductID = int.Parse(oItemRow.Cells[0].Value.ToString());
                            oSalesInvoiceChargeRow.DiscountTypeID = int.Parse(oItemRow.Cells[1].Value.ToString());
                            oSalesInvoiceChargeRow.DiscountTypeName = oItemRow.Cells[2].Value.ToString();
                            oSalesInvoiceChargeRow.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                            oSalesInvoiceChargeRow.InstrumentNo = oItemRow.Cells[4].Value.ToString();
                            oSalesInvoiceChargeRow.Description = oItemRow.Cells[5].Value.ToString();
                            oSalesInvoiceChargeRow.Type = int.Parse(oItemRow.Cells[6].Value.ToString());
                            _oDSsalesInvoCharge.SalesInvoiceCharge.AddSalesInvoiceChargeRow(oSalesInvoiceChargeRow);
                            _oDSsalesInvoCharge.AcceptChanges();
                        }
                    }
                }
            }
            _singleDiscount.Merge(_oDSsalesInvoCharge);
            _singleDiscount.AcceptChanges();
            return _singleDiscount;
        }

        private void cmbSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _nUIControl = cmbSalesType.SelectedIndex + 1;
            UILoad(_nUIControl);
        }

        //private void btnCustHistory_Click_1(object sender, EventArgs e)
        //{
        //    this.Cursor = Cursors.WaitCursor;
        //    _sWebConsumerCode = "";
        //    _IsPicFromWeb = false;

        //    frmPOSCustomerHistory oFrmPosCustomerHistory = new frmPOSCustomerHistory(txtCell.Text);
        //    oFrmPosCustomerHistory.ShowDialog();
        //    if (oFrmPosCustomerHistory._IsSet == true)
        //    {
        //        rdoNewConsumer.Enabled = false;
        //        rdoExistingConsumer.Enabled = false;
        //        rdoLeadCust.Enabled = false;
        //        cmbSalesType.Enabled = false;

        //        RetailConsumer oChkConsumerCode = new RetailConsumer();
        //        oChkConsumerCode.ConsumerCode = oFrmPosCustomerHistory._sConsumerCode;
        //        oChkConsumerCode.RefreshConsumerByType(cmbSalesType.SelectedIndex + 1);
        //        if (oChkConsumerCode.ConsumerCode != null)
        //        {
        //            rdoExistingConsumer.Checked = true;
        //            txtConsumerCode.Text = oChkConsumerCode.ConsumerCode;
        //            _IsPicFromWeb = false;
        //        }
        //        else
        //        {
        //            _IsPicFromWeb = true;
        //            _sWebConsumerCode = oFrmPosCustomerHistory._sConsumerCode;
        //            rdoNewConsumer.Checked = true;
        //            txtCustomerName.Text = oFrmPosCustomerHistory._sConsumerName;
        //            txtCustomerAddress.Text = oFrmPosCustomerHistory._sAddress;
        //            txtDeliveryAddress.Text = oFrmPosCustomerHistory._sAddress;
        //            txtEmail.Text = oFrmPosCustomerHistory._sEmail;
        //            txtCell.Text = oFrmPosCustomerHistory._sMobileNo;
        //            txtTelePhone.Text = oFrmPosCustomerHistory._sTelephoneNo;
        //            if (oFrmPosCustomerHistory._IsValidEmail == 0)
        //            {
        //                btnEmailVerification.Text = "Invalid Email";
        //                btnEmailVerification.ForeColor = Color.Red;
        //                btnEmailVerification.Enabled = true;
        //                txtEmail.Enabled = true;
        //            }
        //            else
        //            {
        //                btnEmailVerification.Text = "Verified";
        //                btnEmailVerification.ForeColor = Color.Green;
        //                btnEmailVerification.Enabled = false;
        //                txtEmail.Enabled = true;
        //            }
        //        }
        //    }
        //    this.Cursor = Cursors.Default;
        //}
        private bool GetPromoUIValidation()
        {

            int nCount = dgvLineItem.Rows.Count;
            if (nCount == 1)
            {
                MessageBox.Show("Please Input Product", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cmbPromotionType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Promotion Type", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //if (cmbSalesType.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select Sales Type", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}

            return true;
        }
        //private void btnGetPromotion_Click(object sender, EventArgs e)
        //{
        //    if (!GetPromoUIValidation())
        //    {
        //        return;
        //    }
        //    if (!DBController.Instance.CheckConnection())
        //    {
        //        DBController.Instance.OpenNewConnection();
        //    }

        //    _oDSInvoiceLineItem = new DSConsumerPromo();
        //    _oDSInvoiceLineItemForPromo = new DSConsumerPromo();
        //    _oDSEligiblePromo = new DSConsumerPromo();
        //    _oDSPromoForProduct = new DSConsumerPromo();
        //    _oDSPromoSlab = new DSConsumerPromo();
        //    _oDSPromoSlabRatio = new DSConsumerPromo();
        //    _oDSApplicablePromo = new DSConsumerPromo();
        //    _oDSApplicablePromo_TP = new DSConsumerPromo();

        //    _oDSEligiblePromoTP = new DSConsumerPromo();
        //    _oDSPromoTPForProduct = new DSConsumerPromo();
        //    _oDSPromoTPSlab = new DSConsumerPromo();
        //    _oDSPromoTPSlabRatio = new DSConsumerPromo();



        //    string sProductID = "";
        //    string sPromoID = "";
        //    string sPromoNo = "";
        //    string sPromoName = "";
        //    string sSlabName = "";
        //    int nMinInvoiceQty = 0;
        //    int nPromoID = 0;
        //    int nSlabID = 0;
        //    int nOfferMultiplyTimes = 0;

        //    string sMAGID = "";
        //    string sBrandID = "";

        //    //Get Invoice Line Item
        //    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
        //    {
        //        if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
        //        {
        //            DSConsumerPromo.ConsumerPromoRow _oLineItemRow = _oDSInvoiceLineItem.ConsumerPromo.NewConsumerPromoRow();
        //            _oLineItemRow.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
        //            try
        //            {
        //                _oLineItemRow.Qty = int.Parse(oItemRow.Cells[5].Value.ToString());
        //            }
        //            catch
        //            {
        //                MessageBox.Show("Please Input Sales Qty/Select Barcode", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return;
        //            }

        //            _oLineItemRow.ProductGroupID = int.Parse(oItemRow.Cells[21].Value.ToString());
        //            _oLineItemRow.BrandID = int.Parse(oItemRow.Cells[22].Value.ToString());

        //            if (sProductID != "")
        //            {
        //                sProductID += "," + _oLineItemRow.ProductID.ToString();
        //            }
        //            else
        //            {
        //                sProductID += _oLineItemRow.ProductID.ToString();
        //            }

        //            if (sMAGID != "")
        //            {
        //                sMAGID += "," + _oLineItemRow.ProductGroupID;
        //            }
        //            else
        //            {
        //                sMAGID += _oLineItemRow.ProductGroupID;
        //            }

        //            if (sBrandID != "")
        //            {
        //                sBrandID += "," + _oLineItemRow.BrandID;
        //            }
        //            else
        //            {
        //                sBrandID += _oLineItemRow.BrandID;
        //            }

        //            _oDSInvoiceLineItem.ConsumerPromo.AddConsumerPromoRow(_oLineItemRow);
        //            _oDSInvoiceLineItem.AcceptChanges();
        //        }
        //    }

        //    oSystemInfo = new CJ.Class.POS.SystemInfo();
        //    oSystemInfo.Refresh();
        //   String _sSystemDate = Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy");

        //    #region CP
        //    oEligiblePromos = new ConsumerPromotionEngines();
        //    //Get Eligible Promo
        //    _oDSEligiblePromo = oEligiblePromos.GetEligiblePromo(Convert.ToDateTime(_sSystemDate), sProductID, oSystemInfo.WarehouseID, cmbSalesType.SelectedIndex + 1, _oSalesPromotionTypes[cmbPromotionType.SelectedIndex - 1].SalesPromotionTypeID);

        //    if (_oDSEligiblePromo.ConsumerPromo.Rows.Count > 0)
        //    {
        //        foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSEligiblePromo.ConsumerPromo)
        //        {
        //            if (sPromoID != "")
        //            {
        //                sPromoID += "," + _oDSRow.ConsumerPromoID.ToString();
        //            }
        //            else
        //            {
        //                sPromoID += _oDSRow.ConsumerPromoID.ToString();
        //            }
        //        }

        //        _oDSPromoForProduct = oEligiblePromos.GetPromoForProduct(sPromoID);
        //        _oDSPromoSlab = oEligiblePromos.GetPromoSlab(sPromoID);
        //        _oDSPromoSlabRatio = oEligiblePromos.GetPromoSlabRatio(sPromoID);
        //        _oDSInvoiceLineItemForPromo.Merge(_oDSInvoiceLineItem);
        //        _oDSInvoiceLineItemForPromo.AcceptChanges();
        //        foreach (DSConsumerPromo.ConsumerPromoRow _oEligibleRow in _oDSEligiblePromo.ConsumerPromo)
        //        {
        //            DSConsumerPromo oDSForProductByPromo = new DSConsumerPromo();
        //            DataRow[] oDR = _oDSPromoForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRow.ConsumerPromoID + "'");
        //            oDSForProductByPromo.Merge(oDR);
        //            oDSForProductByPromo.AcceptChanges();
        //            sPromoNo = _oEligibleRow.ConsumerPromoNo;
        //            sPromoName = _oEligibleRow.ConsumerPromoName;
        //            int nCount = 0;
        //            foreach (DSConsumerPromo.ConsumerPromoRow _oDSForProductRow in oDSForProductByPromo.ConsumerPromo)
        //            {
        //                DataRow[] oDRLineItem = _oDSInvoiceLineItem.ConsumerPromo.Select(" ProductID= '" + _oDSForProductRow.ProductID + "'");

        //                if (oDRLineItem.Length != 0)
        //                {
        //                    nCount++;
        //                }
        //                else
        //                {
        //                    break;
        //                }

        //            }
        //            if (nCount > 0)
        //            {
        //                if (oDSForProductByPromo.ConsumerPromo.Rows.Count == nCount)
        //                {
        //                    DSConsumerPromo _DSPromoSlab = new DSConsumerPromo();
        //                    DataRow[] oDRSlab = _oDSPromoSlab.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRow.ConsumerPromoID + "'");

        //                    //string x = oDRSlab[0]["SlabID"].ToString();

        //                    _DSPromoSlab.Merge(oDRSlab);
        //                    _DSPromoSlab.AcceptChanges();

        //                    //DataRow[] y = _DSPromoSlab.ConsumerPromo.Select("SlabID = Min(Slab)");
        //                    //string z = y[0]["SlabID"].ToString();

        //                    foreach (DSConsumerPromo.ConsumerPromoRow _oSlabRow in _DSPromoSlab.ConsumerPromo)
        //                    {
        //                        DSConsumerPromo _DSPromoSlabRatio = new DSConsumerPromo();
        //                        DataRow[] oDRSlabRatio = _oDSPromoSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRow.ConsumerPromoID + "' and SlabID= '" + _oSlabRow.SlabID + "' ");
        //                        _DSPromoSlabRatio.Merge(oDRSlabRatio);
        //                        _DSPromoSlabRatio.AcceptChanges();
        //                        sSlabName = _oSlabRow.SlabName;

        //                        int nCountSlabRatio = 0;

        //                        foreach (DSConsumerPromo.ConsumerPromoRow _oSlabRatioRow in _DSPromoSlabRatio.ConsumerPromo)
        //                        {
        //                            DataRow[] oDRLineItemCheck = _oDSInvoiceLineItemForPromo.ConsumerPromo.Select(" ProductID = '" + _oSlabRatioRow.ProductID + "' and Qty >= '" + _oSlabRatioRow.Qty + "' ");
        //                            //int x = Convert.ToInt32(oDRLineItemCheck[0]["Qty"]);
        //                            nPromoID = _oSlabRatioRow.ConsumerPromoID;
        //                            nSlabID = _oSlabRatioRow.SlabID;

        //                            if (oDRLineItemCheck.Length != 0)
        //                            {
        //                                nCountSlabRatio++;
        //                                //break;
        //                            }
        //                        }

        //                        if (_DSPromoSlabRatio.ConsumerPromo.Rows.Count == nCountSlabRatio)
        //                        {
        //                            nOfferMultiplyTimes = 0;
        //                            DSConsumerPromo _oDSConsumerPromoTemp = new DSConsumerPromo();
        //                            foreach (DSConsumerPromo.ConsumerPromoRow _dsRow in _oDSInvoiceLineItemForPromo.ConsumerPromo)
        //                            {
        //                                int nRevisedQty = 0;

        //                                DataRow[] oDRLineItemCheckForPromo = _oDSPromoSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and SlabID= '" + nSlabID + "' and ProductID='" + _dsRow.ProductID + "' ");
        //                                if (oDRLineItemCheckForPromo.Length != 0)
        //                                {
        //                                    int nRatioQty = Convert.ToInt32(oDRLineItemCheckForPromo[0]["Qty"]);
        //                                    //nOfferMultiplyTimes = Convert.ToInt32(_dsRow.Qty / nRatioQty);
        //                                    if (nOfferMultiplyTimes == 0)
        //                                    {
        //                                        nOfferMultiplyTimes = Convert.ToInt32(_dsRow.Qty / nRatioQty);
        //                                    }
        //                                    else
        //                                    {
        //                                        if (nOfferMultiplyTimes > Convert.ToInt32(_dsRow.Qty / nRatioQty))
        //                                        {
        //                                            nOfferMultiplyTimes = Convert.ToInt32(_dsRow.Qty / nRatioQty);
        //                                        }
        //                                    }

        //                                    nRevisedQty = _dsRow.Qty - (nRatioQty * nOfferMultiplyTimes);
        //                                }
        //                                else
        //                                {
        //                                    nRevisedQty = _dsRow.Qty;
        //                                }
        //                                DSConsumerPromo.ConsumerPromoRow _oTempRow = _oDSConsumerPromoTemp.ConsumerPromo.NewConsumerPromoRow();
        //                                _oTempRow.ProductID = _dsRow.ProductID;
        //                                _oTempRow.Qty = nRevisedQty;
        //                                _oDSConsumerPromoTemp.ConsumerPromo.AddConsumerPromoRow(_oTempRow);
        //                                _oDSConsumerPromoTemp.AcceptChanges();
        //                            }

        //                            _oDSInvoiceLineItemForPromo = new DSConsumerPromo();
        //                            _oDSInvoiceLineItemForPromo.Merge(_oDSConsumerPromoTemp);
        //                            _oDSInvoiceLineItemForPromo.AcceptChanges();



        //                            DSConsumerPromo.ConsumerPromoRow _oDSApplicablePromoRow = _oDSApplicablePromo.ConsumerPromo.NewConsumerPromoRow();
        //                            _oDSApplicablePromoRow.ConsumerPromoID = nPromoID;
        //                            _oDSApplicablePromoRow.ConsumerPromoNo = sPromoNo;
        //                            _oDSApplicablePromoRow.ConsumerPromoName = sPromoName;
        //                            _oDSApplicablePromoRow.SlabID = nSlabID;
        //                            _oDSApplicablePromoRow.SlabName = sSlabName;
        //                            _oDSApplicablePromoRow.PromoType = "CP";
        //                            _oDSApplicablePromoRow.MultiplyTimes = nOfferMultiplyTimes;
        //                            oEligiblePromos.GetPromoOffer(nPromoID, nSlabID);
        //                            if (oEligiblePromos.Count == 1)//Single offer will be auto effected
        //                            {
        //                                foreach (ConsumerPromotionEngine oPromoData in oEligiblePromos)
        //                                {
        //                                    _oDSApplicablePromoRow.OfferID = oPromoData.OfferID;
        //                                    _oDSApplicablePromoRow.OfferDescription = oPromoData.OfferDesctiption;
        //                                    _oDSApplicablePromoRow.Flag = false;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                _oDSApplicablePromoRow.OfferID = 0;
        //                                _oDSApplicablePromoRow.OfferDescription = "< Please Select an Offer >";
        //                                _oDSApplicablePromoRow.Flag = true;
        //                            }
        //                            _oDSApplicablePromo.ConsumerPromo.AddConsumerPromoRow(_oDSApplicablePromoRow);
        //                            _oDSApplicablePromo.AcceptChanges();
        //                            //break;
        //                        }
        //                        _oDSInvoiceLineItemForPromo = new DSConsumerPromo();
        //                        _oDSInvoiceLineItemForPromo.Merge(_oDSInvoiceLineItem);
        //                        _oDSInvoiceLineItemForPromo.AcceptChanges();
        //                    }
        //                }
        //            }

        //        }
        //    }
        //    #endregion

        //    #region TP
        //    oEligiblePromos = new ConsumerPromotionEngines();
        //    //Get Eligible Promo
        //    ConsumerPromotionEngine oConsumerPromotionEngine = new Class.ConsumerPromotionEngine();
        //    _oDSEligiblePromoTP = oEligiblePromos.GetEligiblePromoTP(Convert.ToDateTime(_sSystemDate), sMAGID, sBrandID, oSystemInfo.WarehouseID, cmbSalesType.SelectedIndex + 1, _oSalesPromotionTypes[cmbPromotionType.SelectedIndex - 1].SalesPromotionTypeID);

        //    if (_oDSEligiblePromoTP.ConsumerPromo.Rows.Count > 0)
        //    {
        //        //Group by MAG & Brand
        //        DSConsumerPromo _oDSMAGBrandGroupby = new DSConsumerPromo();
        //        foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSInvoiceLineItem.ConsumerPromo)
        //        {

        //            DataRow[] oDSRow = _oDSMAGBrandGroupby.ConsumerPromo.Select(" ProductGroupID= '" + _oDSRow.ProductGroupID + "' and BrandID = '" + _oDSRow.BrandID + "' ");

        //            if (oDSRow.Length == 0)
        //            {
        //                DSConsumerPromo.ConsumerPromoRow _oDSMAGBrandGroupbyRow = _oDSMAGBrandGroupby.ConsumerPromo.NewConsumerPromoRow();
        //                _oDSMAGBrandGroupbyRow.ProductGroupID = _oDSRow.ProductGroupID;
        //                _oDSMAGBrandGroupbyRow.BrandID = _oDSRow.BrandID;
        //                _oDSMAGBrandGroupbyRow.Qty = 0;
        //                _oDSMAGBrandGroupby.ConsumerPromo.AddConsumerPromoRow(_oDSMAGBrandGroupbyRow);
        //                _oDSMAGBrandGroupby.AcceptChanges();

        //            }
        //        }

        //        //Sum Qty by MAG & Brand
        //        DSConsumerPromo _oDSMAGBrandGroupbyWithQty = new DSConsumerPromo();
        //        DSConsumerPromo _oDSMAGBrandGroupbyWithQtyTemp = new DSConsumerPromo();
        //        foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSMAGBrandGroupby.ConsumerPromo)
        //        {
        //            DSConsumerPromo _oDSInvoiceLineItemTemp = new DSConsumerPromo();
        //            DataRow[] oDSRow = _oDSInvoiceLineItem.ConsumerPromo.Select(" ProductGroupID= '" + _oDSRow.ProductGroupID + "' and BrandID = '" + _oDSRow.BrandID + "' ");
        //            _oDSInvoiceLineItemTemp.Merge(oDSRow);
        //            _oDSInvoiceLineItemTemp.AcceptChanges();
        //            int nSumQty = 0;
        //            if (oDSRow.Length != 0)
        //            {
        //                foreach (DSConsumerPromo.ConsumerPromoRow _oDSRowTemp in _oDSInvoiceLineItemTemp.ConsumerPromo)
        //                {
        //                    nSumQty += _oDSRowTemp.Qty;
        //                }

        //            }

        //            DSConsumerPromo.ConsumerPromoRow _oGroupbyQtyRow = _oDSMAGBrandGroupbyWithQty.ConsumerPromo.NewConsumerPromoRow();
        //            _oGroupbyQtyRow.ProductGroupID = _oDSRow.ProductGroupID;
        //            _oGroupbyQtyRow.BrandID = _oDSRow.BrandID;
        //            _oGroupbyQtyRow.Qty = nSumQty;
        //            _oDSMAGBrandGroupbyWithQty.ConsumerPromo.AddConsumerPromoRow(_oGroupbyQtyRow);
        //            _oDSMAGBrandGroupbyWithQty.AcceptChanges();
        //        }

        //        _oDSMAGBrandGroupbyWithQtyTemp.Merge(_oDSMAGBrandGroupbyWithQty);
        //        _oDSMAGBrandGroupbyWithQtyTemp.AcceptChanges();

        //        //Get Eligible Promo
        //        sPromoID = "";
        //        foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSEligiblePromoTP.ConsumerPromo)
        //        {
        //            if (sPromoID != "")
        //            {
        //                sPromoID += "," + _oDSRow.ConsumerPromoID.ToString();
        //            }
        //            else
        //            {
        //                sPromoID += _oDSRow.ConsumerPromoID.ToString();
        //            }
        //        }

        //        _oDSPromoTPForProduct = oEligiblePromos.GetPromoTPForProduct(sPromoID);
        //        _oDSPromoTPSlab = oEligiblePromos.GetPromoSlabTP(sPromoID);
        //        _oDSPromoTPSlabRatio = oEligiblePromos.GetPromoSlabRatioTP(sPromoID);
        //        //_oDSInvoiceLineItemForPromo.Merge(_oDSEligiblePromoTP);
        //        //_oDSInvoiceLineItemForPromo.AcceptChanges();
        //        foreach (DSConsumerPromo.ConsumerPromoRow _oEligibleRowTP in _oDSEligiblePromoTP.ConsumerPromo)
        //        {
        //            DSConsumerPromo oDSForProductByPromoTP = new DSConsumerPromo();
        //            DataRow[] oDR = _oDSPromoTPForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "'");
        //            oDSForProductByPromoTP.Merge(oDR);
        //            oDSForProductByPromoTP.AcceptChanges();
        //            sPromoNo = _oEligibleRowTP.ConsumerPromoNo;
        //            sPromoName = _oEligibleRowTP.ConsumerPromoName;
        //            int nCount = 0;
        //            foreach (DSConsumerPromo.ConsumerPromoRow _oDSForProductRowTP in oDSForProductByPromoTP.ConsumerPromo)
        //            {
        //                DataRow[] oDRLineItem = _oDSMAGBrandGroupbyWithQty.ConsumerPromo.Select(" ProductGroupID= '" + _oDSForProductRowTP.ProductGroupID + "' and BrandID= '" + _oDSForProductRowTP.BrandID + "'");

        //                if (oDRLineItem.Length != 0)
        //                {
        //                    nCount++;
        //                }
        //                else
        //                {
        //                    break;
        //                }

        //            }
        //            if (nCount > 0)
        //            {
        //                if (oDSForProductByPromoTP.ConsumerPromo.Rows.Count == nCount)
        //                {
        //                    DSConsumerPromo _DSPromoSlabTP = new DSConsumerPromo();
        //                    DataRow[] oDRSlab = _oDSPromoTPSlab.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "'");

        //                    //string x = oDRSlab[0]["SlabID"].ToString();

        //                    _DSPromoSlabTP.Merge(oDRSlab);
        //                    _DSPromoSlabTP.AcceptChanges();

        //                    //DataRow[] y = _DSPromoSlab.ConsumerPromo.Select("SlabID = Min(Slab)");
        //                    //string z = y[0]["SlabID"].ToString();

        //                    foreach (DSConsumerPromo.ConsumerPromoRow _oSlabRowTP in _DSPromoSlabTP.ConsumerPromo)
        //                    {
        //                        DSConsumerPromo _DSPromoSlabRatioTP = new DSConsumerPromo();
        //                        DataRow[] oDRSlabRatioTP = _oDSPromoTPSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "' and SlabID= '" + _oSlabRowTP.SlabID + "' ");
        //                        _DSPromoSlabRatioTP.Merge(oDRSlabRatioTP);
        //                        _DSPromoSlabRatioTP.AcceptChanges();
        //                        sSlabName = _oSlabRowTP.SlabName;
        //                        nMinInvoiceQty = _oSlabRowTP.MinInvoiceQty;
        //                        int nCountSlabRatio = 0;
        //                        int nInvoiceQty = 0;
        //                        int nProductGroupID = 0;
        //                        int nBrandID = 0;
        //                        foreach (DSConsumerPromo.ConsumerPromoRow _oSlabRatioRow in _DSPromoSlabRatioTP.ConsumerPromo)
        //                        {
        //                            DataRow[] oDRLineItemCheck = _oDSMAGBrandGroupbyWithQty.ConsumerPromo.Select(" ProductGroupID = '" + _oSlabRatioRow.ProductGroupID + "' and BrandID = '" + _oSlabRatioRow.BrandID + "' and Qty >= '" + _oSlabRatioRow.MinQty + "' and Qty >= '" + nMinInvoiceQty + "' ");
        //                            nProductGroupID = _oSlabRatioRow.ProductGroupID;
        //                            nBrandID = _oSlabRatioRow.BrandID;

        //                            if (oDRLineItemCheck.Length != 0)
        //                            {
        //                                nInvoiceQty += Convert.ToInt32(oDRLineItemCheck[0]["Qty"]);
        //                                nPromoID = _oSlabRatioRow.ConsumerPromoID;
        //                                nSlabID = _oSlabRatioRow.SlabID;

        //                                nCountSlabRatio++;
        //                                //break;
        //                            }
        //                        }

        //                        if (_DSPromoSlabRatioTP.ConsumerPromo.Rows.Count == nCountSlabRatio)
        //                        {
        //                            nOfferMultiplyTimes = 0;

        //                            for (int i = 0; nMinInvoiceQty <= nInvoiceQty; i++)
        //                            {
        //                                nOfferMultiplyTimes++;
        //                                nInvoiceQty = nInvoiceQty - nMinInvoiceQty;
        //                            }

        //                            //Update Data set
        //                            DataRow[] dr = _oDSMAGBrandGroupbyWithQty.Tables[0].Select(" ProductGroupID = '" + nProductGroupID + "' and BrandID = '" + nBrandID + "'");
        //                            if (dr.Length > 0)
        //                            {
        //                                dr[0]["Qty"] = nInvoiceQty;
        //                            }
        //                            _oDSMAGBrandGroupbyWithQty.Tables[0].AcceptChanges();


        //                            DSConsumerPromo.ConsumerPromoRow _oDSApplicablePromoRow = _oDSApplicablePromo_TP.ConsumerPromo.NewConsumerPromoRow();
        //                            _oDSApplicablePromoRow.ConsumerPromoID = nPromoID;
        //                            _oDSApplicablePromoRow.ConsumerPromoNo = sPromoNo;
        //                            _oDSApplicablePromoRow.ConsumerPromoName = sPromoName;
        //                            _oDSApplicablePromoRow.SlabID = nSlabID;
        //                            _oDSApplicablePromoRow.SlabName = sSlabName;
        //                            _oDSApplicablePromoRow.PromoType = "TP";
        //                            _oDSApplicablePromoRow.MultiplyTimes = nOfferMultiplyTimes;
        //                            oEligiblePromos.GetPromoOfferTP(nPromoID, nSlabID);
        //                            if (oEligiblePromos.Count == 1)//Single offer will be auto effected
        //                            {
        //                                foreach (ConsumerPromotionEngine oPromoData in oEligiblePromos)
        //                                {
        //                                    _oDSApplicablePromoRow.OfferID = oPromoData.OfferID;
        //                                    _oDSApplicablePromoRow.OfferDescription = oPromoData.OfferDesctiption;
        //                                    _oDSApplicablePromoRow.Flag = false;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                _oDSApplicablePromoRow.OfferID = 0;
        //                                _oDSApplicablePromoRow.OfferDescription = "< Please Select an Offer >";
        //                                _oDSApplicablePromoRow.Flag = true;
        //                            }
        //                            _oDSApplicablePromo_TP.ConsumerPromo.AddConsumerPromoRow(_oDSApplicablePromoRow);
        //                            _oDSApplicablePromo_TP.AcceptChanges();
        //                            //break;
        //                        }

        //                    }
        //                }
        //            }

        //            //Merge
        //            _oDSMAGBrandGroupbyWithQty.Merge(_oDSMAGBrandGroupbyWithQtyTemp);
        //            _oDSMAGBrandGroupbyWithQty.AcceptChanges();

        //        }
        //    }
        //    #endregion
        //    //Set Promotions

        //    _oDSApplicablePromo.Merge(_oDSApplicablePromo_TP);
        //    _oDSApplicablePromo.AcceptChanges();

        //    dsvPromotion.Rows.Clear();
        //    foreach (DSConsumerPromo.ConsumerPromoRow oDSApplicablePromoRow in _oDSApplicablePromo.ConsumerPromo)
        //    {
        //        DataGridViewRow oRow = new DataGridViewRow();
        //        oRow.CreateCells(dsvPromotion);
        //        oRow.Cells[0].Value = oDSApplicablePromoRow.ConsumerPromoNo;
        //        oRow.Cells[1].Value = oDSApplicablePromoRow.ConsumerPromoName;
        //        oRow.Cells[2].Value = oDSApplicablePromoRow.PromoType;
        //        oRow.Cells[3].Value = oDSApplicablePromoRow.SlabName;
        //        oRow.Cells[4].Value = oDSApplicablePromoRow.OfferDescription;
        //        if (oDSApplicablePromoRow.Flag == false)
        //        {
        //            oRow.Cells[5].ReadOnly = true;
        //        }
        //        oRow.Cells[6].Value = oDSApplicablePromoRow.OfferID;
        //        oRow.Cells[7].Value = oDSApplicablePromoRow.SlabID;
        //        oRow.Cells[8].Value = oDSApplicablePromoRow.ConsumerPromoID;
        //        oRow.Cells[9].Value = oDSApplicablePromoRow.MultiplyTimes;
        //        dsvPromotion.Rows.Add(oRow);
        //    }

        //    cmbSalesType.Enabled = false;
        //    if (dsvPromotion.Rows.Count != 0)
        //    {
        //        dgvLineItem.ReadOnly = true;
        //        dgvLineItem.AllowUserToDeleteRows = false;
        //        btnEditLineItem.Visible = true;
        //        _InvoiceLineItemButtonLock = true;
        //        btnSave.Enabled = false;
        //    }
        //    else
        //    {
        //        btnSave.Enabled = true;
        //    }
        //}

        //private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        //{
        //    if (ctlCustomer1.txtDescription.Text != "")
        //    {
        //        Customer oCustomer = new Customer();
        //        oCustomer.RefreshByID(ctlCustomer1.SelectedCustomer.CustomerID);

        //        if (_nUIControl == (int)Dictionary.SalesType.Dealer)
        //        {
        //            TELLib oTELLib = new TELLib();
        //            PaymentMode oGetBalance = new PaymentMode();
        //            oGetBalance.GetCustomerBalance(DateTime.Now.Date, ctlCustomer1.SelectedCustomer.CustomerID);
        //            lblCustomerBalanceAmt.Text = oTELLib.TakaFormat(oGetBalance.CurrentBalance);
        //            lblBGAmt.Text = oTELLib.TakaFormat(oGetBalance.BankGuaranty);
        //        }
        //        if (_nUIControl == (int)Dictionary.SalesType.B2B)
        //        {
        //            if (Utility.CompanyInfo == "TEL")
        //            {
        //                if (oCustomer.CustTypeID == 249 || oCustomer.CustTypeID == 245)
        //                {

        //                }
        //                else
        //                {
        //                    MessageBox.Show("Please select valid B2B customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    ctlCustomer1.txtCode.Text = "";
        //                    ctlCustomer1.txtCode.Focus();
        //                }
        //            }
        //            else if (Utility.CompanyInfo == "TML")
        //            {
        //                if (oCustomer.CustTypeID == 202 || oCustomer.CustTypeID == 217)
        //                {

        //                }
        //                else
        //                {
        //                    MessageBox.Show("Please select valid B2B customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    //return false;
        //                    ctlCustomer1.txtCode.Text = "";
        //                    ctlCustomer1.txtCode.Focus();
        //                }
        //            }
        //        }
        //        if (_nUIControl == (int)Dictionary.SalesType.B2C)
        //        {
        //            if (Utility.CompanyInfo == "TEL")
        //            {
        //                if (oCustomer.CustTypeID != 245)
        //                {
        //                    MessageBox.Show("Please select valid B2C customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    ctlCustomer1.txtCode.Text = "";
        //                    ctlCustomer1.txtCode.Focus();
        //                }
        //            }
        //            else if (Utility.CompanyInfo == "TML")
        //            {
        //                if (oCustomer.CustTypeID != 217)
        //                {
        //                    MessageBox.Show("Please select valid B2C customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    //return false;
        //                    ctlCustomer1.txtCode.Text = "";
        //                    ctlCustomer1.txtCode.Focus();
        //                }
        //            }
        //        }
        //    }
        //}

        private void dsvPromotion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string sPromoNo = dsvPromotion.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sPromoName = dsvPromotion.Rows[e.RowIndex].Cells[1].Value.ToString();
                string sPromoType = dsvPromotion.Rows[e.RowIndex].Cells[2].Value.ToString();
                string sPromoSlab = dsvPromotion.Rows[e.RowIndex].Cells[3].Value.ToString();


                int nOfferID = int.Parse(dsvPromotion.Rows[e.RowIndex].Cells[6].Value.ToString());
                int nSlabID = int.Parse(dsvPromotion.Rows[e.RowIndex].Cells[7].Value.ToString());
                int nPromoID = int.Parse(dsvPromotion.Rows[e.RowIndex].Cells[8].Value.ToString());

                frmPromotionalOffer oForm = new frmPromotionalOffer(sPromoNo, sPromoName, sPromoType, sPromoSlab, nOfferID, nSlabID, nPromoID);
                oForm.ShowDialog();
                if (oForm._Flag)
                {
                    dsvPromotion.Rows[e.RowIndex].Cells[4].Value = oForm.sOfferDescription;
                    dsvPromotion.Rows[e.RowIndex].Cells[6].Value = oForm.nOfferID;
                    btnSave.Enabled = false;
                }

            }
        }

        private void btnEditLineItem_Click(object sender, EventArgs e)
        {
            _IsApplyPromotion = false;
            cmbPromotionType.Enabled = true;
            _btnEditLineItemClickCount = 1;
            dgvLineItem.ReadOnly = false;
            btnSave.Enabled = false;
            dgvLineItem.AllowUserToDeleteRows = true;
            //dgvLineItem.Columns["btnFindProduct"].Visible = true;
            _InvoiceLineItemButtonLock = false;
            btnEditLineItem.Visible = false;
            cmbSalesType.Enabled = true;
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDistrict.SelectedIndex != 0)
            {
                oThana = new GeoLocations();
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                oThana.GetByParentID(oDistrict[cmbDistrict.SelectedIndex - 1].GeoLocationID);
                cmbThana.Items.Clear();
                cmbThana.Items.Add("<Select a Thana>");
                foreach (GeoLocation oThanas in oThana)
                {
                    cmbThana.Items.Add(oThanas.GeoLocationName);
                }
                cmbThana.SelectedIndex = 0;
            }
            else
            {
                cmbThana.Items.Clear();
                cmbThana.Items.Add("<Select a Thana>");
                cmbThana.SelectedIndex = 0;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

        }

        private void dvgFreeProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                try
                {
                    int temp = int.Parse(dvgFreeProduct.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Please Select a Product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                frmAvailableBarcode ofrmAvailableBarcode = new frmAvailableBarcode(int.Parse(dvgFreeProduct.Rows[e.RowIndex].Cells[5].Value.ToString()), oSystemInfo.WarehouseID, "", 0);
                ofrmAvailableBarcode.ShowDialog();
                if (ofrmAvailableBarcode._nCount == int.Parse(dvgFreeProduct.Rows[e.RowIndex].Cells[2].Value.ToString()))
                {
                    dvgFreeProduct.Rows[e.RowIndex].Cells[3].Value = ofrmAvailableBarcode._sBarcode;
                }
                else
                {
                    dvgFreeProduct.Rows[e.RowIndex].Cells[3].Value = "";
                    MessageBox.Show("Please Select Valid Barcode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        //private void btnEmailVerificationxx_Click(object sender, EventArgs e)
        //{

        //    this.Cursor = Cursors.WaitCursor;
        //    string HtmlResult = "";
        //    string sEmail = txtEmail.Text;
        //    //String sid = "STAKEHOLDER"; String user = "USER NAME"; String pass = "PASSWORD";
        //    String URI = "http://202.53.171.126/e.api/api/EmailVerification/VerifyEmailAddress?emailAddress='"+ sEmail + "'";
        //    String myParameters = "";
        //    //System.Web.HttpUtility.UrlEncode("Test SMS1\nTest SMS2\nTest SMS API3") + "&sms[0][2]=" + "1234567890" + "&sms[1][0]=88***********&sms[1][1]=" +
        //    //System.Web.HttpUtility.UrlEncode("TESTSMS2\nTESTSMS3") + "&sms[1][2]=" + "1234567890" + "&sid=" + sid;
        //    using (WebClient wc = new WebClient())
        //    {
        //        //wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        //        wc.Headers[HttpRequestHeader.Authorization] = "Basic VERXZWJTTVNVc2VyOkRjWC13ZSE2JDQ2";
        //         HtmlResult = wc.UploadString(URI, myParameters); //Console.Write(HtmlResult);
        //    }
        //    if (HtmlResult == "true")
        //    {
        //        btnEmailVerification.Text = "Verified";
        //        btnEmailVerification.ForeColor = Color.Green;
        //        //btnEmailVerification.Font = Font.Bold;
        //    }
        //    else
        //    {
        //        btnEmailVerification.Text = "Invalid Email";
        //        btnEmailVerification.ForeColor = Color.Red;
        //    }
        //    this.Cursor = Cursors.Default;
        //}





        private void lblConsumerHistory_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _sWebConsumerCode = "";
            _IsPicFromWeb = false;

            frmPOSCustomerHistory oFrmPosCustomerHistory = new frmPOSCustomerHistory(txtCell.Text);
            oFrmPosCustomerHistory.ShowDialog();
            if (oFrmPosCustomerHistory._IsSet == true)
            {
                rdoNewConsumer.Enabled = false;
                rdoExistingConsumer.Enabled = false;
                rdoLeadCust.Enabled = false;
                cmbSalesType.Enabled = false;

                RetailConsumer oChkConsumerCode = new RetailConsumer();
                //oChkConsumerCode.ConsumerCode = oFrmPosCustomerHistory._sConsumerCode;
                //oChkConsumerCode.RefreshConsumerByType(cmbSalesType.SelectedIndex + 1);
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                if (oChkConsumerCode.GetConsumerByMobileNoType(oFrmPosCustomerHistory._sMobileNo, cmbSalesType.SelectedIndex + 1))
                {
                    rdoExistingConsumer.Checked = true;
                    txtConsumerCode.Text = oChkConsumerCode.ConsumerCode;
                    _IsPicFromWeb = false;
                }
                else
                {
                    _IsPicFromWeb = true;
                    _sWebConsumerCode = oFrmPosCustomerHistory._sConsumerCode;
                    rdoNewConsumer.Checked = true;
                    txtCustomerName.Text = oFrmPosCustomerHistory._sConsumerName;
                    txtCustomerAddress.Text = oFrmPosCustomerHistory._sAddress;
                    txtDeliveryAddress.Text = oFrmPosCustomerHistory._sAddress;
                    txtEmail.Text = oFrmPosCustomerHistory._sEmail;
                    txtCell.Text = oFrmPosCustomerHistory._sMobileNo;
                    txtTelePhone.Text = oFrmPosCustomerHistory._sTelephoneNo;
                    if (oFrmPosCustomerHistory._IsValidEmail == 0)
                    {
                        btnEmailVerification.Text = @"Invalid Email";
                        btnEmailVerification.ForeColor = Color.Red;
                        btnEmailVerification.Enabled = true;
                        txtEmail.Enabled = true;
                    }
                    else
                    {
                        btnEmailVerification.Text = "Verified";
                        btnEmailVerification.ForeColor = Color.Green;
                        btnEmailVerification.Enabled = false;
                        txtEmail.Enabled = true;
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }
        private void btnApplyPromotion_Click(object sender, EventArgs e)
        {
            _IsApplyPromotion = true;
            if (_nUIControl == (int)Dictionary.SalesType.B2B)
            {
                if (chkB2BDiscount.Checked != true)
                {
                    MessageBox.Show(@"You have to Check 'Apply promotion instead of B2B discount' for apply CP/TP ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    chkB2BDiscount.Enabled = false;
                }
            }
            if (_btnEditLineItemClickCount == 1)
            {
                //btnGetPromotion_Click(null, null);
                MessageBox.Show(@"Please click GetPromotion button first ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGetPromotion.Focus();
                return;
            }
            cmbPromotionType.Enabled = false;
            if (ApplyPromotionValidation())
            {
                oInvoiceDiscountChargeMap = new CJ.Class.POS.DSSalesInvoice();

                dvgFreeProduct.Rows.Clear();
                //Clear Promo Discount & PromoEMI from Line Itme
                foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
                {
                    if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                    {
                        double _CP = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value);
                        double _TP = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value);
                        dgvLineItem.Rows[_oItemRow.Index].Cells[16].Value = (Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[16].Value) + _CP + _TP);
                        dgvLineItem.Rows[_oItemRow.Index].Cells[15].Value = (Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[15].Value) - (_CP + _TP));
                        dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value = 0; //CP
                        dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value = 0; //TP
                        dgvLineItem.Rows[_oItemRow.Index].Cells[19].Value = 0;//EMI

                    }
                }


                foreach (DataGridViewRow oItemRow in dsvPromotion.Rows)
                {
                    if (oItemRow.Index < dsvPromotion.Rows.Count)
                    {
                        string sPromoType = oItemRow.Cells[2].Value.ToString().Trim();
                        int nOfferID = Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim());
                        int nSlabID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                        int nPromoID = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
                        int nMultiplyTimes = Convert.ToInt32(oItemRow.Cells[9].Value.ToString().Trim());
                        int nIsApplicableOnOfferPrice = Convert.ToInt32(oItemRow.Cells[10].Value.ToString().Trim());

                        _oConsumerPromotionEngines = new ConsumerPromotionEngines();
                        double _DisAmt = 0;
                        if (sPromoType == "CP")
                        {
                            if (!DBController.Instance.CheckConnection())
                            {
                                DBController.Instance.OpenNewConnection();
                            }
                            _oConsumerPromotionEngines.GetPromoOfferDetail(nPromoID, nSlabID, nOfferID);

                            foreach (ConsumerPromotionEngine oCPE in _oConsumerPromotionEngines)
                            {
                                if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Product)
                                {
                                    Product oProduct = new Product();
                                    oProduct.ProductID = oCPE.OfferProductID;
                                    oProduct.RefreshByID();

                                    DataGridViewRow oRow = new DataGridViewRow();
                                    oRow.CreateCells(dvgFreeProduct);
                                    oRow.Cells[0].Value = oProduct.ProductCode;
                                    oRow.Cells[1].Value = oProduct.ProductName;
                                    oRow.Cells[2].Value = oCPE.OfferQty * nMultiplyTimes;
                                    oRow.Cells[5].Value = oProduct.ProductID;
                                    oRow.Cells[6].Value = oProduct.CostPrice;
                                    oRow.Cells[7].Value = oProduct.IsBarcodeItem;

                                    oRow.Cells[8].Value = "CP";
                                    oRow.Cells[9].Value = oCPE.ConsumerPromoID;
                                    oRow.Cells[10].Value = oCPE.SlabID;
                                    oRow.Cells[11].Value = oCPE.OfferID;

                                    dvgFreeProduct.Rows.Add(oRow);

                                    #region Promo MAP
                                    SetPromoMap(-1, nPromoID, nSlabID, nOfferID, "t_PromoCP", 1, 0, oProduct.ProductID, Convert.ToInt32(oRow.Cells[2].Value), -1, -1, 0);
                                    #endregion 
                                }
                                else if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.FlatAmount || oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Parcent)
                                {
                                    //Get Discount amount by percent
                                    double _DisAmount = 0;
                                    double _DiscountEligiblePrice = 0;
                                    if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Parcent)
                                    {
                                        foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
                                        {
                                            if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                                            {
                                                int nProductID = Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim());
                                                DataRow[] oDR = _oDSPromoForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and ProductID='" + nProductID + "' ");

                                                if (oDR.Length != 0)
                                                {
                                                    double _UnitPrice = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[3].Value);
                                                    int _Qty = Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[5].Value);
                                                    double _TotalDiscount = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[15].Value);
                                                    //_DisAmount = _DisAmount + (_UnitPrice * _Qty);
                                                    if (nIsApplicableOnOfferPrice == (int)Dictionary.YesOrNoStatus.YES)
                                                    {
                                                        _DiscountEligiblePrice = _DiscountEligiblePrice + (_UnitPrice - _TotalDiscount);
                                                    }
                                                    else
                                                    {
                                                        _DiscountEligiblePrice = _DiscountEligiblePrice + _UnitPrice;
                                                    }
                                                }
                                            }
                                        }
                                        _DisAmount = _DiscountEligiblePrice * oCPE.Discount / 100;

                                    }

                                    foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
                                    {
                                        if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                                        {
                                            int nProductID = Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim());
                                            DataRow[] oDR = _oDSPromoForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and ProductID='" + nProductID + "' ");

                                            if (oDR.Length != 0)
                                            {
                                                double _DiscountRatio = Convert.ToDouble(oDR[0]["DiscountRatio"]);
                                                _DisAmt = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value);

                                                double _SingleDiscount = 0;

                                                if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.FlatAmount)
                                                {
                                                    dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value = _DisAmt + (_DiscountRatio * oCPE.Discount / 100) * nMultiplyTimes;
                                                    _SingleDiscount = (_DiscountRatio * oCPE.Discount / 100) * nMultiplyTimes;
                                                }
                                                else
                                                {
                                                    dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value = Math.Round(_DisAmt + (_DiscountRatio * _DisAmount / 100) * nMultiplyTimes, 0);
                                                    _SingleDiscount = Math.Round((_DiscountRatio * _DisAmount / 100) * nMultiplyTimes, 0);
                                                }

                                                #region Promo MAP
                                                //SetPromoMap(3, nPromoID, nSlabID, nOfferID, "t_PromoCP", 1, Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value), -1, 0, nProductID, -1, -1);
                                                SetPromoMap(3, nPromoID, nSlabID, nOfferID, "t_PromoCP", 1, _SingleDiscount, -1, 0, nProductID, -1, -1);
                                                #endregion 

                                                dgvLineItem.Rows[_oItemRow.Index].Cells[15].Value = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[13].Value) + Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value) + Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value);
                                            }
                                        }
                                    }

                                }
                                else if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.EMI)
                                {
                                    foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
                                    {
                                        if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                                        {
                                            int nProductID = Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim());
                                            DataRow[] oDR = _oDSPromoForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and ProductID='" + nProductID + "' ");

                                            if (oDR.Length != 0)
                                            {
                                                dgvLineItem.Rows[_oItemRow.Index].Cells[19].Value = oCPE.EMITenureID;

                                                #region Promo MAP
                                                SetPromoMap(-1, nPromoID, nSlabID, nOfferID, "t_PromoCP", 1, 0, -1, 0, Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim()), Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[19].Value), -1);
                                                #endregion 

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //TP
                            _oConsumerPromotionEngines.GetPromoTPOfferDetail(nPromoID, nSlabID, nOfferID);
                            foreach (ConsumerPromotionEngine oCPE in _oConsumerPromotionEngines)
                            {
                                double _DisAmount = 0;
                                //if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Parcent)
                                //{
                                foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
                                {
                                    if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                                    {
                                        //int nProductID = Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim());
                                        int nMAGID = Convert.ToInt32(_oItemRow.Cells[21].Value.ToString().Trim());
                                        int nBrandID = Convert.ToInt32(_oItemRow.Cells[22].Value.ToString().Trim());
                                        double _Discount = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value);
                                        double _TotalDiscount = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[15].Value);
                                        DataRow[] oDR = _oDSPromoTPForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and ProductGroupID='" + nMAGID + "' and BrandID='" + nBrandID + "' ");

                                        if (oDR.Length != 0)
                                        {
                                            double _UnitPrice = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[3].Value);
                                            int _Qty = Convert.ToInt32(dgvLineItem.Rows[_oItemRow.Index].Cells[5].Value);
                                            if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Parcent)
                                            {
                                                double _SingleTPDiscountParcent = 0;
                                                if (nIsApplicableOnOfferPrice == (int)Dictionary.YesOrNoStatus.YES)
                                                {
                                                    dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value = _Discount + (((_UnitPrice * _Qty) - _TotalDiscount) * oCPE.Discount / 100);
                                                    _SingleTPDiscountParcent = (((_UnitPrice * _Qty) - _TotalDiscount) * oCPE.Discount / 100);
                                                }
                                                else
                                                {
                                                    dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value = _Discount + ((_UnitPrice * _Qty) * oCPE.Discount / 100);
                                                    _SingleTPDiscountParcent = ((_UnitPrice * _Qty) * oCPE.Discount / 100);


                                                }
                                                #region Promo MAP
                                                //SetPromoMap(3, nPromoID, nSlabID, nOfferID, "t_PromoTP", 1, Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value), -1, 0, Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim()), -1, -1);
                                                SetPromoMap(3, nPromoID, nSlabID, nOfferID, "t_PromoTP", 1, _SingleTPDiscountParcent, -1, 0, Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim()), -1, -1);
                                                #endregion
                                            }
                                            else if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.FlatAmount)
                                            {
                                                double _SingleTPDiscount = 0;

                                                dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value = _Discount + (_Qty * oCPE.Discount);
                                                _SingleTPDiscount = (_Qty * oCPE.Discount);

                                                #region Promo MAP
                                                //SetPromoMap(3, nPromoID, nSlabID, nOfferID, "t_PromoTP", 1, Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value), -1, 0, Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim()), -1, -1);
                                                SetPromoMap(3, nPromoID, nSlabID, nOfferID, "t_PromoTP", 1, _SingleTPDiscount, -1, 0, Convert.ToInt32(_oItemRow.Cells[9].Value.ToString().Trim()), -1, -1);
                                                #endregion
                                            }
                                            else if (oCPE.OfferType == (int)Dictionary.SalesPromOfferType.Product)
                                            {
                                                //New added
                                                Product oProduct = new Product();
                                                oProduct.ProductID = oCPE.OfferProductID;
                                                oProduct.RefreshByID();

                                                DataGridViewRow oRow = new DataGridViewRow();
                                                oRow.CreateCells(dvgFreeProduct);
                                                oRow.Cells[0].Value = oProduct.ProductCode;
                                                oRow.Cells[1].Value = oProduct.ProductName;
                                                oRow.Cells[2].Value = oCPE.OfferQty * nMultiplyTimes;
                                                oRow.Cells[5].Value = oProduct.ProductID;
                                                oRow.Cells[6].Value = oProduct.CostPrice;
                                                oRow.Cells[7].Value = oProduct.IsBarcodeItem;

                                                oRow.Cells[8].Value = "TP";
                                                oRow.Cells[9].Value = oCPE.ConsumerPromoID;
                                                oRow.Cells[10].Value = oCPE.SlabID;
                                                oRow.Cells[11].Value = oCPE.OfferID;


                                                dvgFreeProduct.Rows.Add(oRow);

                                                #region Promo MAP
                                                SetPromoMap(-1, nPromoID, nSlabID, nOfferID, "t_PromoTP", 1, 0, oProduct.ProductID, Convert.ToInt32(oRow.Cells[2].Value), -1, -1, 0);
                                                #endregion
                                                break;
                                            }


                                        }
                                    }
                                }
                                //_DisAmount = _DisAmount * oCPE.Discount / 100;
                                // }


                            }
                        }
                    }
                }
                SumNetPayable();
                GetTotalRSAmount();

                if (_nUIControl == (int)Dictionary.SalesType.B2B)
                {
                    if (_nDMSOrderID != -1)
                    {
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                    }
                }
                else if (_nUIControl == (int)Dictionary.SalesType.Dealer)
                {
                    if (_nDMSOrderID != -1)
                    {
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                    }
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnGetPromotion_Click(object sender, EventArgs e)
        {
            if (_nUIControl == (int)Dictionary.SalesType.B2B || _nUIControl == (int)Dictionary.SalesType.B2C || _nUIControl == (int)Dictionary.SalesType.HPA || _nUIControl == (int)Dictionary.SalesType.Dealer)
            {
                if (txtCtlCustName.Text == "")
                {
                    MessageBox.Show("Please select customer first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    Customer oGetCustTyp = new Customer();
                    oGetCustTyp.CustomerCode = txtCtlCustCode.Text;
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }
                    oGetCustTyp.RefreshByCode();
                    _nInvoiceCustomerTypeID = oGetCustTyp.CustTypeID;
                }
            }
            else if (_nUIControl == (int)Dictionary.SalesType.Retail)
            {
                oSystemInfo = new SystemInfo();
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                oSystemInfo.Refresh();
                _nInvoiceCustomerTypeID = oSystemInfo.CustTypeID;
            }
            else
            {
                _nInvoiceCustomerTypeID = -1;
            }






            dsvPromotion.Rows.Clear();
            dvgFreeProduct.Rows.Clear();
            //Clear Promo Discount & PromoEMI from Line Itme
            foreach (DataGridViewRow _oItemRow in dgvLineItem.Rows)
            {
                if (_oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    double _CP = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value);
                    double _TP = Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value);
                    dgvLineItem.Rows[_oItemRow.Index].Cells[16].Value = (Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[16].Value) + _CP + _TP);
                    dgvLineItem.Rows[_oItemRow.Index].Cells[15].Value = (Convert.ToDouble(dgvLineItem.Rows[_oItemRow.Index].Cells[15].Value) - (_CP + _TP));
                    dgvLineItem.Rows[_oItemRow.Index].Cells[14].Value = 0; //CP
                    dgvLineItem.Rows[_oItemRow.Index].Cells[20].Value = 0; //TP
                    dgvLineItem.Rows[_oItemRow.Index].Cells[19].Value = 0;//EMI

                }
            }
            GetTotalRSAmount();
            // btnSave.Enabled = true;

            if (_nUIControl == (int)Dictionary.SalesType.B2B)
            {
                if (_nDMSOrderID != -1)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
            else if (_nUIControl == (int)Dictionary.SalesType.Dealer)
            {
                if (_nDMSOrderID != -1)
                {
                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
            else
            {
                btnSave.Enabled = true;
            }

            _btnEditLineItemClickCount = 0;
            if (!GetPromoUIValidation())
            {
                return;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oDSInvoiceLineItem = new DSConsumerPromo();
            _oDSInvoiceLineItemForPromo = new DSConsumerPromo();
            _oDSEligiblePromo = new DSConsumerPromo();
            _oDSPromoForProduct = new DSConsumerPromo();
            _oDSPromoSlab = new DSConsumerPromo();
            _oDSPromoSlabRatio = new DSConsumerPromo();
            _oDSApplicablePromo = new DSConsumerPromo();
            _oDSApplicablePromo_TP = new DSConsumerPromo();

            _oDSEligiblePromoTP = new DSConsumerPromo();
            _oDSPromoTPForProduct = new DSConsumerPromo();
            _oDSPromoTPSlab = new DSConsumerPromo();
            _oDSPromoTPSlabRatio = new DSConsumerPromo();



            string sProductID = "";
            string sPromoID = "";
            string sPromoNo = "";
            string sPromoName = "";
            string sSlabName = "";
            int nMinInvoiceQty = 0;
            int nPromoID = 0;
            int nSlabID = 0;
            int nOfferMultiplyTimes = 0;
            int nIsApplicableOnOfferPrice = 0;
            string sMAGID = "";
            string sBrandID = "";

            //Get Invoice Line Item
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    DSConsumerPromo.ConsumerPromoRow _oLineItemRow = _oDSInvoiceLineItem.ConsumerPromo.NewConsumerPromoRow();
                    _oLineItemRow.ProductID = int.Parse(oItemRow.Cells[9].Value.ToString());
                    try
                    {
                        _oLineItemRow.Qty = int.Parse(oItemRow.Cells[5].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please Input Sales Qty/Select Barcode", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    _oLineItemRow.ProductGroupID = int.Parse(oItemRow.Cells[21].Value.ToString());
                    _oLineItemRow.BrandID = int.Parse(oItemRow.Cells[22].Value.ToString());

                    if (sProductID != "")
                    {
                        sProductID += "," + _oLineItemRow.ProductID.ToString();
                    }
                    else
                    {
                        sProductID += _oLineItemRow.ProductID.ToString();
                    }

                    if (sMAGID != "")
                    {
                        sMAGID += "," + _oLineItemRow.ProductGroupID;
                    }
                    else
                    {
                        sMAGID += _oLineItemRow.ProductGroupID;
                    }

                    if (sBrandID != "")
                    {
                        sBrandID += "," + _oLineItemRow.BrandID;
                    }
                    else
                    {
                        sBrandID += _oLineItemRow.BrandID;
                    }

                    _oDSInvoiceLineItem.ConsumerPromo.AddConsumerPromoRow(_oLineItemRow);
                    _oDSInvoiceLineItem.AcceptChanges();
                }
            }

            oSystemInfo = new CJ.Class.POS.SystemInfo();
            oSystemInfo.Refresh();
            String _sSystemDate = Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy");

            #region CP
            oEligiblePromos = new ConsumerPromotionEngines();
            //Get Eligible Promo
            _oDSEligiblePromo = oEligiblePromos.GetEligiblePromo(Convert.ToDateTime(_sSystemDate), sProductID, oSystemInfo.WarehouseID, cmbSalesType.SelectedIndex + 1, _oSalesPromotionTypes[cmbPromotionType.SelectedIndex - 1].SalesPromotionTypeID, _nInvoiceCustomerTypeID);

            if (_oDSEligiblePromo.ConsumerPromo.Rows.Count > 0)
            {
                foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSEligiblePromo.ConsumerPromo)
                {
                    if (sPromoID != "")
                    {
                        sPromoID += "," + _oDSRow.ConsumerPromoID.ToString();
                    }
                    else
                    {
                        sPromoID += _oDSRow.ConsumerPromoID.ToString();
                    }
                }

                _oDSPromoForProduct = oEligiblePromos.GetPromoForProduct(sPromoID);
                _oDSPromoSlab = oEligiblePromos.GetPromoSlab(sPromoID);
                _oDSPromoSlabRatio = oEligiblePromos.GetPromoSlabRatio(sPromoID);
                _oDSInvoiceLineItemForPromo.Merge(_oDSInvoiceLineItem);
                _oDSInvoiceLineItemForPromo.AcceptChanges();
                foreach (DSConsumerPromo.ConsumerPromoRow _oEligibleRow in _oDSEligiblePromo.ConsumerPromo)
                {
                    DSConsumerPromo oDSForProductByPromo = new DSConsumerPromo();
                    DataRow[] oDR = _oDSPromoForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRow.ConsumerPromoID + "'");
                    oDSForProductByPromo.Merge(oDR);
                    oDSForProductByPromo.AcceptChanges();
                    sPromoNo = _oEligibleRow.ConsumerPromoNo;
                    sPromoName = _oEligibleRow.ConsumerPromoName;
                    nIsApplicableOnOfferPrice = _oEligibleRow.IsApplicableOnOfferPrice;
                    int nCount = 0;
                    foreach (DSConsumerPromo.ConsumerPromoRow _oDSForProductRow in oDSForProductByPromo.ConsumerPromo)
                    {
                        DataRow[] oDRLineItem = _oDSInvoiceLineItem.ConsumerPromo.Select(" ProductID= '" + _oDSForProductRow.ProductID + "'");

                        if (oDRLineItem.Length != 0)
                        {
                            nCount++;
                        }
                        else
                        {
                            break;
                        }

                    }
                    if (nCount > 0)
                    {
                        if (oDSForProductByPromo.ConsumerPromo.Rows.Count == nCount)
                        {
                            DSConsumerPromo _DSPromoSlab = new DSConsumerPromo();
                            DataRow[] oDRSlab = _oDSPromoSlab.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRow.ConsumerPromoID + "'");

                            //string x = oDRSlab[0]["SlabID"].ToString();

                            _DSPromoSlab.Merge(oDRSlab);
                            _DSPromoSlab.AcceptChanges();

                            //DataRow[] y = _DSPromoSlab.ConsumerPromo.Select("SlabID = Min(Slab)");
                            //string z = y[0]["SlabID"].ToString();

                            foreach (DSConsumerPromo.ConsumerPromoRow _oSlabRow in _DSPromoSlab.ConsumerPromo)
                            {
                                DSConsumerPromo _DSPromoSlabRatio = new DSConsumerPromo();
                                DataRow[] oDRSlabRatio = _oDSPromoSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRow.ConsumerPromoID + "' and SlabID= '" + _oSlabRow.SlabID + "' ");
                                _DSPromoSlabRatio.Merge(oDRSlabRatio);
                                _DSPromoSlabRatio.AcceptChanges();
                                sSlabName = _oSlabRow.SlabName;

                                int nCountSlabRatio = 0;

                                foreach (DSConsumerPromo.ConsumerPromoRow _oSlabRatioRow in _DSPromoSlabRatio.ConsumerPromo)
                                {
                                    DataRow[] oDRLineItemCheck = _oDSInvoiceLineItemForPromo.ConsumerPromo.Select(" ProductID = '" + _oSlabRatioRow.ProductID + "' and Qty >= '" + _oSlabRatioRow.Qty + "' ");
                                    //int x = Convert.ToInt32(oDRLineItemCheck[0]["Qty"]);
                                    nPromoID = _oSlabRatioRow.ConsumerPromoID;
                                    nSlabID = _oSlabRatioRow.SlabID;

                                    if (oDRLineItemCheck.Length != 0)
                                    {
                                        nCountSlabRatio++;
                                        //break;
                                    }
                                }

                                if (_DSPromoSlabRatio.ConsumerPromo.Rows.Count == nCountSlabRatio)
                                {
                                    nOfferMultiplyTimes = 0;
                                    DSConsumerPromo _oDSConsumerPromoTemp = new DSConsumerPromo();
                                    foreach (DSConsumerPromo.ConsumerPromoRow _dsRow in _oDSInvoiceLineItemForPromo.ConsumerPromo)
                                    {
                                        int nRevisedQty = 0;

                                        DataRow[] oDRLineItemCheckForPromo = _oDSPromoSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + nPromoID + "' and SlabID= '" + nSlabID + "' and ProductID='" + _dsRow.ProductID + "' ");
                                        if (oDRLineItemCheckForPromo.Length != 0)
                                        {
                                            int nRatioQty = Convert.ToInt32(oDRLineItemCheckForPromo[0]["Qty"]);
                                            //nOfferMultiplyTimes = Convert.ToInt32(_dsRow.Qty / nRatioQty);
                                            if (nOfferMultiplyTimes == 0)
                                            {
                                                nOfferMultiplyTimes = Convert.ToInt32(_dsRow.Qty / nRatioQty);
                                            }
                                            else
                                            {
                                                if (nOfferMultiplyTimes > Convert.ToInt32(_dsRow.Qty / nRatioQty))
                                                {
                                                    nOfferMultiplyTimes = Convert.ToInt32(_dsRow.Qty / nRatioQty);
                                                }
                                            }

                                            nRevisedQty = _dsRow.Qty - (nRatioQty * nOfferMultiplyTimes);
                                        }
                                        else
                                        {
                                            nRevisedQty = _dsRow.Qty;
                                        }
                                        DSConsumerPromo.ConsumerPromoRow _oTempRow = _oDSConsumerPromoTemp.ConsumerPromo.NewConsumerPromoRow();
                                        _oTempRow.ProductID = _dsRow.ProductID;
                                        _oTempRow.Qty = nRevisedQty;
                                        _oDSConsumerPromoTemp.ConsumerPromo.AddConsumerPromoRow(_oTempRow);
                                        _oDSConsumerPromoTemp.AcceptChanges();
                                    }

                                    _oDSInvoiceLineItemForPromo = new DSConsumerPromo();
                                    _oDSInvoiceLineItemForPromo.Merge(_oDSConsumerPromoTemp);
                                    _oDSInvoiceLineItemForPromo.AcceptChanges();



                                    DSConsumerPromo.ConsumerPromoRow _oDSApplicablePromoRow = _oDSApplicablePromo.ConsumerPromo.NewConsumerPromoRow();
                                    _oDSApplicablePromoRow.ConsumerPromoID = nPromoID;
                                    _oDSApplicablePromoRow.ConsumerPromoNo = sPromoNo;
                                    _oDSApplicablePromoRow.ConsumerPromoName = sPromoName;
                                    _oDSApplicablePromoRow.SlabID = nSlabID;
                                    _oDSApplicablePromoRow.SlabName = sSlabName;
                                    _oDSApplicablePromoRow.PromoType = "CP";
                                    _oDSApplicablePromoRow.MultiplyTimes = nOfferMultiplyTimes;
                                    _oDSApplicablePromoRow.IsApplicableOnOfferPrice = nIsApplicableOnOfferPrice;
                                    oEligiblePromos.GetPromoOffer(nPromoID, nSlabID);
                                    if (oEligiblePromos.Count == 1)//Single offer will be auto effected
                                    {
                                        foreach (ConsumerPromotionEngine oPromoData in oEligiblePromos)
                                        {
                                            _oDSApplicablePromoRow.OfferID = oPromoData.OfferID;
                                            _oDSApplicablePromoRow.OfferDescription = oPromoData.OfferDesctiption;
                                            _oDSApplicablePromoRow.Flag = false;
                                        }
                                    }
                                    else
                                    {
                                        _oDSApplicablePromoRow.OfferID = 0;
                                        _oDSApplicablePromoRow.OfferDescription = "< Please Select an Offer >";
                                        _oDSApplicablePromoRow.Flag = true;
                                    }
                                    _oDSApplicablePromo.ConsumerPromo.AddConsumerPromoRow(_oDSApplicablePromoRow);
                                    _oDSApplicablePromo.AcceptChanges();
                                   
                                }

                            }
                            _oDSInvoiceLineItemForPromo = new DSConsumerPromo();
                            _oDSInvoiceLineItemForPromo.Merge(_oDSInvoiceLineItem);
                            _oDSInvoiceLineItemForPromo.AcceptChanges();
                        }
                    }

                }
            }
            #endregion

            #region TP
            oEligiblePromos = new ConsumerPromotionEngines();
            //Get Eligible Promo
            ConsumerPromotionEngine oConsumerPromotionEngine = new Class.ConsumerPromotionEngine();
            _oDSEligiblePromoTP = oEligiblePromos.GetEligiblePromoTP(Convert.ToDateTime(_sSystemDate), sMAGID, sBrandID, oSystemInfo.WarehouseID, cmbSalesType.SelectedIndex + 1, _oSalesPromotionTypes[cmbPromotionType.SelectedIndex - 1].SalesPromotionTypeID, _nInvoiceCustomerTypeID);


            if (_oDSEligiblePromoTP.ConsumerPromo.Rows.Count > 0)
            {
                string _sPromoID = "";
                //Get eligible promo id
                foreach (DSConsumerPromo.ConsumerPromoRow _oRowX in _oDSEligiblePromoTP.ConsumerPromo)
                {
                    if (_sPromoID != "")
                    {
                        _sPromoID += "," + _oRowX.ConsumerPromoID;
                    }
                    else
                    {
                        _sPromoID += _oRowX.ConsumerPromoID;
                    }
                }
                DSConsumerPromo _XdsTPForProd = new DSConsumerPromo();
                _XdsTPForProd = oEligiblePromos.GetPromoTPForProduct(_sPromoID);
                _sPromoID = "";

                //Get for applicable all sku under promos
                foreach (DSConsumerPromo.ConsumerPromoRow _oRowY in _XdsTPForProd.ConsumerPromo)
                {
                    //Check specific product for combo
                    DataRow[] oDSRow = _XdsTPForProd.ConsumerPromo.Select(" ConsumerPromoID= '" + _oRowY.ConsumerPromoID + "' and IsApplicableOnAllSKU = 0 ");

                    if (oDSRow.Length > 0)
                    {
                        //return;
                    }
                    else
                    {

                        if (_oRowY.IsApplicableOnAllSKU == 1)
                        {
                            if (_sPromoID != "")
                            {
                                _sPromoID += "," + _oRowY.ConsumerPromoID;
                            }
                            else
                            {
                                _sPromoID += _oRowY.ConsumerPromoID;
                            }
                        }
                    }
                }
                // OLD Code: Get for applicable all sku under promos
                //foreach (DSConsumerPromo.ConsumerPromoRow _oRowY in _XdsTPForProd.ConsumerPromo)
                //{
                //    if (_oRowY.IsApplicableOnAllSKU == 1)
                //    {
                //        if (_sPromoID != "")
                //        {
                //            _sPromoID += "," + _oRowY.ConsumerPromoID;
                //        }
                //        else
                //        {
                //            _sPromoID += _oRowY.ConsumerPromoID;
                //        }
                //    }
                //}

                DSConsumerPromo _oDSForProdSplitProdID = new DSConsumerPromo();
                foreach (DSConsumerPromo.ConsumerPromoRow _oRowY in _XdsTPForProd.ConsumerPromo)
                {
                    if (_oRowY.IsApplicableOnAllSKU == 0)
                    {
                        string s = _oRowY.ApplicableProductID;
                        string[] values = s.Split(',');
                        for (int i = 0; i < values.Length; i++)
                        {
                            DSConsumerPromo.ConsumerPromoRow _oDSRowX = _oDSForProdSplitProdID.ConsumerPromo.NewConsumerPromoRow();
                            _oDSRowX.ConsumerPromoID = _oRowY.ConsumerPromoID;
                            _oDSRowX.ApplicableProductID = values[i].Trim();
                            _oDSForProdSplitProdID.ConsumerPromo.AddConsumerPromoRow(_oDSRowX);
                            _oDSForProdSplitProdID.AcceptChanges();
                        }
                    }
                }

                foreach (DSConsumerPromo.ConsumerPromoRow _oDSRowX in _oDSInvoiceLineItem.ConsumerPromo)
                {
                    DataRow[] oDSRow = _oDSForProdSplitProdID.ConsumerPromo.Select(" ApplicableProductID= '" + _oDSRowX.ProductID + "'");

                    if (oDSRow.Length > 0)
                    {
                        if (_sPromoID != "")
                        {
                            _sPromoID += "," + oDSRow[0]["ConsumerPromoID"];
                        }
                        else
                        {
                            _sPromoID += oDSRow[0]["ConsumerPromoID"];
                        }
                    }
                }

                //// To get Multiple TP 
                    //foreach (DSConsumerPromo.ConsumerPromoRow _oDSRowX in _oDSInvoiceLineItem.ConsumerPromo)
                    //{
                    //    DataRow[] oDSRow = _oDSForProdSplitProdID.ConsumerPromo.Select(" ApplicableProductID= '" + _oDSRowX.ProductID + "'");

                    //    for (int i = 0; i < oDSRow.Length; i++)//(oDSRow.Length > 0)
                    //    {
                    //        if (_sPromoID != "")
                    //        {
                    //            _sPromoID += "," + oDSRow[i]["ConsumerPromoID"];
                    //        }
                    //        else
                    //        {
                    //            _sPromoID += oDSRow[i]["ConsumerPromoID"];
                    //        }
                    //    }
                    //}

                    _oDSEligiblePromoTP = new DSConsumerPromo();
                oEligiblePromos = new ConsumerPromotionEngines();
                if (_sPromoID != "")
                    _oDSEligiblePromoTP = oEligiblePromos.GetPromoTPByPromoID(_sPromoID);

                nIsApplicableOnOfferPrice = 0;
                if (_oDSEligiblePromoTP.ConsumerPromo.Rows.Count > 0)
                {
                    //Group by MAG & Brand
                    DSConsumerPromo _oDSMAGBrandGroupby = new DSConsumerPromo();
                    foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSInvoiceLineItem.ConsumerPromo)
                    {

                        DataRow[] oDSRow = _oDSMAGBrandGroupby.ConsumerPromo.Select(" ProductGroupID= '" + _oDSRow.ProductGroupID + "' and BrandID = '" + _oDSRow.BrandID + "' ");

                        if (oDSRow.Length == 0)
                        {
                            DSConsumerPromo.ConsumerPromoRow _oDSMAGBrandGroupbyRow = _oDSMAGBrandGroupby.ConsumerPromo.NewConsumerPromoRow();
                            _oDSMAGBrandGroupbyRow.ProductGroupID = _oDSRow.ProductGroupID;
                            _oDSMAGBrandGroupbyRow.BrandID = _oDSRow.BrandID;
                            _oDSMAGBrandGroupbyRow.Qty = 0;
                            _oDSMAGBrandGroupby.ConsumerPromo.AddConsumerPromoRow(_oDSMAGBrandGroupbyRow);
                            _oDSMAGBrandGroupby.AcceptChanges();

                        }
                    }

                    //Sum Qty by MAG & Brand
                    DSConsumerPromo _oDSMAGBrandGroupbyWithQty = new DSConsumerPromo();
                    DSConsumerPromo _oDSMAGBrandGroupbyWithQtyTemp = new DSConsumerPromo();
                    foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSMAGBrandGroupby.ConsumerPromo)
                    {
                        DSConsumerPromo _oDSInvoiceLineItemTemp = new DSConsumerPromo();
                        DataRow[] oDSRow = _oDSInvoiceLineItem.ConsumerPromo.Select(" ProductGroupID= '" + _oDSRow.ProductGroupID + "' and BrandID = '" + _oDSRow.BrandID + "' ");
                        _oDSInvoiceLineItemTemp.Merge(oDSRow);
                        _oDSInvoiceLineItemTemp.AcceptChanges();
                        int nSumQty = 0;
                        if (oDSRow.Length != 0)
                        {
                            foreach (DSConsumerPromo.ConsumerPromoRow _oDSRowTemp in _oDSInvoiceLineItemTemp.ConsumerPromo)
                            {
                                nSumQty += _oDSRowTemp.Qty;
                            }

                        }

                        DSConsumerPromo.ConsumerPromoRow _oGroupbyQtyRow = _oDSMAGBrandGroupbyWithQty.ConsumerPromo.NewConsumerPromoRow();
                        _oGroupbyQtyRow.ProductGroupID = _oDSRow.ProductGroupID;
                        _oGroupbyQtyRow.BrandID = _oDSRow.BrandID;
                        _oGroupbyQtyRow.Qty = nSumQty;
                        _oDSMAGBrandGroupbyWithQty.ConsumerPromo.AddConsumerPromoRow(_oGroupbyQtyRow);
                        _oDSMAGBrandGroupbyWithQty.AcceptChanges();
                    }

                    _oDSMAGBrandGroupbyWithQtyTemp.Merge(_oDSMAGBrandGroupbyWithQty);
                    _oDSMAGBrandGroupbyWithQtyTemp.AcceptChanges();

                    //Get Eligible Promo
                    sPromoID = "";
                    foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSEligiblePromoTP.ConsumerPromo)
                    {
                        if (sPromoID != "")
                        {
                            sPromoID += "," + _oDSRow.ConsumerPromoID.ToString();
                        }
                        else
                        {
                            sPromoID += _oDSRow.ConsumerPromoID.ToString();
                        }
                    }

                    _oDSPromoTPForProduct = oEligiblePromos.GetPromoTPForProduct(sPromoID);
                    _oDSPromoTPSlab = oEligiblePromos.GetPromoSlabTP(sPromoID);
                    _oDSPromoTPSlabRatio = oEligiblePromos.GetPromoSlabRatioTP(sPromoID);
                    //_oDSInvoiceLineItemForPromo.Merge(_oDSEligiblePromoTP);
                    //_oDSInvoiceLineItemForPromo.AcceptChanges();
                    foreach (DSConsumerPromo.ConsumerPromoRow _oEligibleRowTP in _oDSEligiblePromoTP.ConsumerPromo)
                    {
                        DSConsumerPromo oDSForProductByPromoTP = new DSConsumerPromo();
                        DataRow[] oDR = _oDSPromoTPForProduct.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "'");
                        oDSForProductByPromoTP.Merge(oDR);
                        oDSForProductByPromoTP.AcceptChanges();
                        sPromoNo = _oEligibleRowTP.ConsumerPromoNo;
                        sPromoName = _oEligibleRowTP.ConsumerPromoName;
                        nIsApplicableOnOfferPrice = _oEligibleRowTP.IsApplicableOnOfferPrice;
                        int nCount = 0;

                        foreach (DSConsumerPromo.ConsumerPromoRow _oDSForProductRowTP in oDSForProductByPromoTP.ConsumerPromo)
                        {
                            DataRow[] oDRLineItem = _oDSMAGBrandGroupbyWithQty.ConsumerPromo.Select(" ProductGroupID= '" + _oDSForProductRowTP.ProductGroupID + "' and BrandID= '" + _oDSForProductRowTP.BrandID + "'");

                            if (oDRLineItem.Length != 0)
                            {
                                nCount++;
                            }
                            else
                            {
                                DataRow[] oDRCheckMinQtyZero = _oDSPromoTPSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "' and SlabID=1  and ProductGroupID = '" + _oDSForProductRowTP.ProductGroupID + "' and BrandID= '" + _oDSForProductRowTP.BrandID + "' and MinQty = 0 ");
                                if (oDRCheckMinQtyZero.Length > 0)
                                {
                                    nCount++;
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        if (nCount > 0)
                        {
                            if (oDSForProductByPromoTP.ConsumerPromo.Rows.Count == nCount)
                            {
                                DSConsumerPromo _DSPromoSlabTP = new DSConsumerPromo();
                                DataRow[] oDRSlab = _oDSPromoTPSlab.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "'");

                                //string x = oDRSlab[0]["SlabID"].ToString();

                                _DSPromoSlabTP.Merge(oDRSlab);
                                _DSPromoSlabTP.AcceptChanges();

                                //DataRow[] y = _DSPromoSlab.ConsumerPromo.Select("SlabID = Min(Slab)");
                                //string z = y[0]["SlabID"].ToString();

                                foreach (DSConsumerPromo.ConsumerPromoRow _oSlabRowTP in _DSPromoSlabTP.ConsumerPromo)
                                {
                                    DSConsumerPromo _DSPromoSlabRatioTP = new DSConsumerPromo();
                                    DataRow[] oDRSlabRatioTP = _oDSPromoTPSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "' and SlabID= '" + _oSlabRowTP.SlabID + "' ");
                                    _DSPromoSlabRatioTP.Merge(oDRSlabRatioTP);
                                    _DSPromoSlabRatioTP.AcceptChanges();
                                    sSlabName = _oSlabRowTP.SlabName;
                                    nMinInvoiceQty = _oSlabRowTP.MinInvoiceQty;
                                    int nCountSlabRatio = 0;
                                    int nInvoiceQty = 0;
                                    int nProductGroupID = 0;
                                    int nBrandID = 0;
                                    foreach (DSConsumerPromo.ConsumerPromoRow _oSlabRatioRow in _DSPromoSlabRatioTP.ConsumerPromo)
                                    {
                                        DataRow[] oDRLineItemCheck = _oDSMAGBrandGroupbyWithQty.ConsumerPromo.Select(" ProductGroupID = '" + _oSlabRatioRow.ProductGroupID + "' and BrandID = '" + _oSlabRatioRow.BrandID + "' and Qty >= '" + _oSlabRatioRow.MinQty + "'");
                                        nProductGroupID = _oSlabRatioRow.ProductGroupID;
                                        nBrandID = _oSlabRatioRow.BrandID;

                                        if (oDRLineItemCheck.Length != 0)
                                        {
                                            nInvoiceQty += Convert.ToInt32(oDRLineItemCheck[0]["Qty"]);
                                            nPromoID = _oSlabRatioRow.ConsumerPromoID;
                                            nSlabID = _oSlabRatioRow.SlabID;

                                            nCountSlabRatio++;
                                            //break;
                                        }
                                        else
                                        {
                                            DataRow[] oDRCheckMinQtyZero = _oDSPromoTPSlabRatio.ConsumerPromo.Select(" ConsumerPromoID= '" + _oEligibleRowTP.ConsumerPromoID + "' and SlabID=1  and ProductGroupID = '" + _oSlabRatioRow.ProductGroupID + "' and BrandID= '" + _oSlabRatioRow.BrandID + "' and MinQty = 0 ");
                                            if (oDRCheckMinQtyZero.Length > 0)
                                            {
                                                nCountSlabRatio++;
                                            }
                                        }
                                    }

                                    if (_DSPromoSlabRatioTP.ConsumerPromo.Rows.Count == nCountSlabRatio)
                                    {
                                        nOfferMultiplyTimes = 0;
                                        if (nInvoiceQty >= nMinInvoiceQty)
                                        {
                                            for (int i = 0; nMinInvoiceQty <= nInvoiceQty; i++)
                                            {
                                                nOfferMultiplyTimes++;
                                                nInvoiceQty = nInvoiceQty - nMinInvoiceQty;
                                            }

                                            //Update Data set
                                            DSConsumerPromo _oDSTemp = new DSConsumerPromo();
                                            int nTotalGroup = _oDSMAGBrandGroupbyWithQty.ConsumerPromo.Count;

                                            if (nInvoiceQty != 0)
                                            {
                                                double x = (nInvoiceQty / nTotalGroup);
                                                x = Math.Round(x, 0);
                                                int nX = 0;
                                                int nQty = 0;
                                                foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSMAGBrandGroupbyWithQty.ConsumerPromo)
                                                {
                                                    nX++;
                                                    if (nTotalGroup == nX)
                                                    {
                                                        x = (nInvoiceQty - nQty);
                                                    }
                                                    else
                                                    {
                                                        nQty += Convert.ToInt32(x);
                                                    }
                                                    DSConsumerPromo.ConsumerPromoRow _oRow = _oDSTemp.ConsumerPromo.NewConsumerPromoRow();
                                                    _oRow.ProductGroupID = _oDSRow.ProductGroupID;
                                                    _oRow.BrandID = _oDSRow.BrandID;
                                                    _oRow.Qty = Convert.ToInt32(x);
                                                    _oDSTemp.ConsumerPromo.AddConsumerPromoRow(_oRow);
                                                    _oDSTemp.AcceptChanges();
                                                }

                                            }
                                            else
                                            {

                                                foreach (DSConsumerPromo.ConsumerPromoRow _oDSRow in _oDSMAGBrandGroupbyWithQty.ConsumerPromo)
                                                {
                                                    DSConsumerPromo.ConsumerPromoRow _oRow = _oDSTemp.ConsumerPromo.NewConsumerPromoRow();
                                                    _oRow.ProductGroupID = _oDSRow.ProductGroupID;
                                                    _oRow.BrandID = _oDSRow.BrandID;
                                                    _oRow.Qty = 0;
                                                    _oDSTemp.ConsumerPromo.AddConsumerPromoRow(_oRow);
                                                    _oDSTemp.AcceptChanges();
                                                }
                                            }

                                            _oDSMAGBrandGroupbyWithQty.Merge(_oDSTemp);
                                            _oDSMAGBrandGroupbyWithQty.AcceptChanges();


                                            DSConsumerPromo.ConsumerPromoRow _oDSApplicablePromoRow = _oDSApplicablePromo_TP.ConsumerPromo.NewConsumerPromoRow();
                                            _oDSApplicablePromoRow.ConsumerPromoID = nPromoID;
                                            _oDSApplicablePromoRow.ConsumerPromoNo = sPromoNo;
                                            _oDSApplicablePromoRow.ConsumerPromoName = sPromoName;
                                            _oDSApplicablePromoRow.SlabID = nSlabID;
                                            _oDSApplicablePromoRow.SlabName = sSlabName;
                                            _oDSApplicablePromoRow.PromoType = "TP";
                                            _oDSApplicablePromoRow.MultiplyTimes = nOfferMultiplyTimes;
                                            _oDSApplicablePromoRow.IsApplicableOnOfferPrice = nIsApplicableOnOfferPrice;
                                            oEligiblePromos.GetPromoOfferTP(nPromoID, nSlabID);
                                            if (oEligiblePromos.Count == 1)//Single offer will be auto effected
                                            {
                                                foreach (ConsumerPromotionEngine oPromoData in oEligiblePromos)
                                                {
                                                    _oDSApplicablePromoRow.OfferID = oPromoData.OfferID;
                                                    _oDSApplicablePromoRow.OfferDescription = oPromoData.OfferDesctiption;
                                                    _oDSApplicablePromoRow.Flag = false;
                                                }
                                            }
                                            else
                                            {
                                                _oDSApplicablePromoRow.OfferID = 0;
                                                _oDSApplicablePromoRow.OfferDescription = "< Please Select an Offer >";
                                                _oDSApplicablePromoRow.Flag = true;
                                            }
                                            _oDSApplicablePromo_TP.ConsumerPromo.AddConsumerPromoRow(_oDSApplicablePromoRow);
                                            _oDSApplicablePromo_TP.AcceptChanges();
                                            break;////Should be deleted (Gozamil Code)
                                        }
                                    }

                                }
                            }
                        }

                        //Merge
                        _oDSMAGBrandGroupbyWithQty.Merge(_oDSMAGBrandGroupbyWithQtyTemp);
                        _oDSMAGBrandGroupbyWithQty.AcceptChanges();

                    }
                }
            }
            #endregion
            //Set Promotions

            _oDSApplicablePromo.Merge(_oDSApplicablePromo_TP);
            _oDSApplicablePromo.AcceptChanges();

            dsvPromotion.Rows.Clear();
            int nCountPromo = 0;
            foreach (DSConsumerPromo.ConsumerPromoRow oDSApplicablePromoRow in _oDSApplicablePromo.ConsumerPromo)
            {
                nCountPromo++;
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dsvPromotion);
                oRow.Cells[0].Value = oDSApplicablePromoRow.ConsumerPromoNo;
                oRow.Cells[1].Value = oDSApplicablePromoRow.ConsumerPromoName;
                oRow.Cells[2].Value = oDSApplicablePromoRow.PromoType;
                oRow.Cells[3].Value = oDSApplicablePromoRow.SlabName;
                oRow.Cells[4].Value = oDSApplicablePromoRow.OfferDescription;
                if (oDSApplicablePromoRow.Flag == false)
                {
                    oRow.Cells[5].ReadOnly = true;
                }
                oRow.Cells[6].Value = oDSApplicablePromoRow.OfferID;
                oRow.Cells[7].Value = oDSApplicablePromoRow.SlabID;
                oRow.Cells[8].Value = oDSApplicablePromoRow.ConsumerPromoID;
                oRow.Cells[9].Value = oDSApplicablePromoRow.MultiplyTimes;
                oRow.Cells[10].Value = oDSApplicablePromoRow.IsApplicableOnOfferPrice;
                dsvPromotion.Rows.Add(oRow);
            }
            if (nCountPromo == 0)
            {
                _IsApplyPromotion = true;
            }
            else
            {
                _IsApplyPromotion = false;
                if (_nUIControl == (int)Dictionary.SalesType.B2B)
                {
                    chkB2BDiscount.Visible = true;
                }
            }

            cmbSalesType.Enabled = false;
            if (dsvPromotion.Rows.Count != 0)
            {
                dgvLineItem.ReadOnly = true;
                dgvLineItem.AllowUserToDeleteRows = false;

                ////Need Code Here
                if (_sDMSCustomerCode == "")
                    btnEditLineItem.Visible = true;
                _InvoiceLineItemButtonLock = true;

                if (_nUIControl == (int)Dictionary.SalesType.B2B)
                {
                    // btnSave.Enabled = true;
                    if (_nDMSOrderID != -1)
                    {
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                    }


                }
                else
                {
                    btnSave.Enabled = false;
                }


            }
            else
            {
                //btnSave.Enabled = true;

                if (_nUIControl == (int)Dictionary.SalesType.B2B)
                {
                    if (_nDMSOrderID != -1)
                    {
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                    }
                }
                else if (_nUIControl == (int)Dictionary.SalesType.Dealer)
                {
                    if (_nDMSOrderID != -1)
                    {
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                    }
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
        }


        private void btnEmailVerification_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string HtmlResult = "";
            string sEmail = txtEmail.Text;
            //String sid = "STAKEHOLDER"; String user = "USER NAME"; String pass = "PASSWORD";
            String URI = "http://202.53.171.126/e.api/api/EmailVerification/VerifyEmailAddress?emailAddress='" + sEmail + "'";
            String myParameters = "";
            //System.Web.HttpUtility.UrlEncode("Test SMS1\nTest SMS2\nTest SMS API3") + "&sms[0][2]=" + "1234567890" + "&sms[1][0]=88***********&sms[1][1]=" +
            //System.Web.HttpUtility.UrlEncode("TESTSMS2\nTESTSMS3") + "&sms[1][2]=" + "1234567890" + "&sid=" + sid;
            using (WebClient wc = new WebClient())
            {
                //wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                wc.Headers[HttpRequestHeader.Authorization] = "Basic VERXZWJTTVNVc2VyOkRjWC13ZSE2JDQ2";
                HtmlResult = wc.UploadString(URI, myParameters); //Console.Write(HtmlResult);
            }
            if (HtmlResult == "true")
            {
                btnEmailVerification.Text = "Verified";
                btnEmailVerification.ForeColor = Color.Green;
                //btnEmailVerification.Font = Font.Bold;
            }
            else
            {
                btnEmailVerification.Text = "Invalid Email";
                btnEmailVerification.ForeColor = Color.Red;
            }
            this.Cursor = Cursors.Default;
        }

        private void txtCtlCustCode_TextChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oCustomer = new Customer();

            txtCtlCustCode.ForeColor = System.Drawing.Color.Red;
            txtCtlCustName.Text = "";

            if (txtCtlCustCode.Text.Length >= 1 && txtCtlCustCode.Text.Length <= 25)
            {
                _oCustomer.CustomerCode = txtCtlCustCode.Text;
                _oCustomer.RefreshByCode();

                if (_oCustomer.CustomerName == null)
                {
                    _oCustomer = null;
                    AppLogger.LogFatal("There is no data in the customer.");
                    return;
                }
                else if (_oCustomer.IsActive == (int)Dictionary.IsActive.InActive)
                {
                    MessageBox.Show("Please select active customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCtlCustCode.Text = "";
                    txtCtlCustCode.Focus();
                    return;
                }
                else
                {
                    txtCtlCustName.Text = _oCustomer.CustomerName.ToString();
                    txtCtlCustCode.SelectionStart = 0;
                    txtCtlCustCode.SelectionLength = txtCtlCustCode.Text.Length;
                    txtCtlCustCode.ForeColor = System.Drawing.Color.Empty;
                    if (_nUIControl == (int)Dictionary.SalesType.Dealer || _nUIControl == (int)Dictionary.SalesType.B2B)
                    {
                        txtCustomerAddress.Text = _oCustomer.CustomerAddress;
                        txtDeliveryAddress.Text = _oCustomer.CustomerAddress;
                    }
                }

                if (txtCtlCustName.Text != "")
                {
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer)
                    {
                        if (_oCustomer.IsCustomerAccount == (int)Dictionary.YesOrNoStatus.NO)
                        {
                            MessageBox.Show("There is no customer account. Please contact MIS department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCtlCustCode.Text = "";
                            txtCtlCustCode.Focus();
                            return;
                        }
                    }
                }
            }
            if (ChangeSelection != null)
                ChangeSelection(this, e);
        }

        private void btnCtlCustPicker_Click(object sender, EventArgs e)
        {
            CustomerTypies oCustomerTypes = new CustomerTypies();
            _oCustomer = new Customer();
            frmCustomerSearch oObj = new frmCustomerSearch(oCustomerTypes.GetCustTypeSalesTypeWise(_nUIControl));
            oObj.ShowDialog(_oCustomer);
            if (_oCustomer.CustomerCode != null)
            {
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer)
                {
                    if (_oCustomer.IsCustomerAccount == (int)Dictionary.YesOrNoStatus.NO)
                    {
                        MessageBox.Show("There is no customer account. Please contact MIS department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCtlCustCode.Text = "";
                        txtCtlCustCode.Focus();
                        return;
                    }
                }
                if (_oCustomer.IsActive == (int)Dictionary.IsActive.Active)
                {
                    txtCtlCustCode.Text = _oCustomer.CustomerCode.ToString();
                }
                else
                {
                    MessageBox.Show("Please select active customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCtlCustCode.Text = "";
                    txtCtlCustCode.Focus();
                    return;
                }
            }
        }

        private void txtCtlCustCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ChangeFocus != null)
            {
                ChangeFocus(sender, e);
            }
        }


        public bool UpdateCustomerBalance(CJ.Class.POS.DSCustomer oDSCustomer, double _TotalAmtLocal)
        {
            double nTotalAmount = 0;
            foreach (CJ.Class.POS.DSCustomer.CustomerRow oCustomerRow in oDSCustomer.Customer)
            {
                nTotalAmount = oCustomerRow.CurrentBalance + oCustomerRow.BGAmount + oCustomerRow.CreditLimit;
            }
            if (Math.Round(_TotalAmtLocal) == Math.Round(nTotalAmount))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void GetCustomerBalance(int nCustomerID,double _TotalAmtLocal, double _CurrentBalance, double _BankGuaranty, double _CreditLimit)
        {
            this.Cursor = Cursors.WaitCursor;
            int Desc;
            if (Utility.InternetGetConnectedState(out Desc, 0))
            {

                CJ.POS.TELWEBSERVER.DSCustomer oDSCustomer = new CJ.POS.TELWEBSERVER.DSCustomer();
                CJ.Class.POS.DSCustomer _oDSCustomer = new CJ.Class.POS.DSCustomer();
                oService = new Service();
                try
                {
                    oDSCustomer = oService.DownloadCustomerBalanceDataWithLocalBalance(oDSCustomer, nCustomerID, oSystemInfo.WarehouseID, Convert.ToDateTime(oSystemInfo.OperationDate), _CurrentBalance, _BankGuaranty, _CreditLimit);
                    _oDSCustomer.Merge(oDSCustomer);
                    _oDSCustomer.AcceptChanges();
                }
                catch
                {
                    //DMS
                    _sDMSOrderNo = "";
                    _sDMSCustomerCode = "";
                    _nDMSOrderID = -1;
                    dgvLineItem.Rows.Clear();
                    //END DMS
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Please check internet connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCtlCustCode.Text = "";
                    txtCtlCustCode.Focus();
                    return;
                }


                _oDSCustomerAll = new Class.POS.DSCustomer();
                _oDSCustomerAll.Merge(_oDSCustomer);
                _oDSCustomerAll.AcceptChanges();
                if (UpdateCustomerBalance(_oDSCustomerAll, _TotalAmtLocal))
                {
                    lblCustomerBalanceAmt.Text = oTELLib.TakaFormat(_CurrentBalance);
                    lblBGAmt.Text = oTELLib.TakaFormat(_BankGuaranty);
                    lblCreditLimit.Text = oTELLib.TakaFormat(_CreditLimit);
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    //DMS
                    _sDMSOrderNo = "";
                    _sDMSCustomerCode = "";
                    _nDMSOrderID = -1;
                    dgvLineItem.Rows.Clear();
                    //END DMS
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Please upload/download first for proper customer balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCtlCustCode.Text = "";
                    txtCtlCustCode.Focus();
                    return;

                }
            }
            else
            {
                MessageBox.Show("Please Check Internet Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                //DMS
                _sDMSOrderNo = "";
                _sDMSCustomerCode = "";
                _nDMSOrderID = -1;
                dgvLineItem.Rows.Clear();
                txtCtlCustCode.Text = "";
                //END DMS
                return;
            }
        }
        private void txtCtlCustName_TextChanged(object sender, EventArgs e)
        {
            string _sCustType = "";
            if (txtCtlCustName.Text != "")
            {
                Customer oCustomer = new Customer();
                oCustomer.RefreshByID(_oCustomer.CustomerID);

                if (_nUIControl == (int)Dictionary.SalesType.Dealer)
                {
                    CustomerTypies oCustomerTypes = new CustomerTypies();
                    _sCustType = oCustomerTypes.GetCustTypeSalesTypeWise((int)Dictionary.SalesType.Dealer);
                    if (_sCustType.Contains(oCustomer.CustTypeID.ToString()))
                    {
                        TELLib oTELLib = new TELLib();
                        PaymentMode oGetBalance = new PaymentMode();
                        oGetBalance.GetCustomerBalance(DateTime.Now.Date, _oCustomer.CustomerID);
                        double _TotalAmtLocal = oGetBalance.CurrentBalance + oGetBalance.BankGuaranty + oGetBalance.CreditLimit;
                        GetCustomerBalance(_oCustomer.CustomerID, _TotalAmtLocal, oGetBalance.CurrentBalance, oGetBalance.BankGuaranty, oGetBalance.CreditLimit);

                        

                        //lblCustomerBalanceAmt.Text = oTELLib.TakaFormat(oGetBalance.CurrentBalance);
                        //lblBGAmt.Text = oTELLib.TakaFormat(oGetBalance.BankGuaranty);
                        //lblCreditLimit.Text = oTELLib.TakaFormat(oGetBalance.CreditLimit);
                    }
                    else
                    {
                        MessageBox.Show("Please select valid dealer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCtlCustCode.Text = "";
                        txtCtlCustCode.Focus();
                    }
                    //if (Utility.CompanyInfo == "TEL")
                    //{
                    //    if (oCustomer.CustTypeID == 217 || oCustomer.CustTypeID == 2 || oCustomer.CustTypeID == 219)
                    //    {
                    //        TELLib oTELLib = new TELLib();
                    //        PaymentMode oGetBalance = new PaymentMode();
                    //        oGetBalance.GetCustomerBalance(DateTime.Now.Date, _oCustomer.CustomerID);
                    //        lblCustomerBalanceAmt.Text = oTELLib.TakaFormat(oGetBalance.CurrentBalance);
                    //        lblBGAmt.Text = oTELLib.TakaFormat(oGetBalance.BankGuaranty);
                    //        lblCreditLimit.Text = oTELLib.TakaFormat(oGetBalance.CreditLimit);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Please select valid dealer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        txtCtlCustCode.Text = "";
                    //        txtCtlCustCode.Focus();
                    //    }
                    //}

                }
                if (_nUIControl == (int)Dictionary.SalesType.B2B)
                {

                    CustomerTypies oCustomerTypes = new CustomerTypies();
                    _sCustType = oCustomerTypes.GetCustTypeSalesTypeWise((int)Dictionary.SalesType.B2B);
                    if (_sCustType.Contains(oCustomer.CustTypeID.ToString()))
                    {
                        TELLib oTELLib = new TELLib();
                        PaymentMode oGetBalance = new PaymentMode();
                        oGetBalance.GetCustomerBalance(DateTime.Now.Date, _oCustomer.CustomerID);
                        lblCustomerBalanceAmt.Text = oTELLib.TakaFormat(oGetBalance.CurrentBalance);
                        lblBGAmt.Text = oTELLib.TakaFormat(oGetBalance.BankGuaranty);
                        lblCreditLimit.Text = oTELLib.TakaFormat(oGetBalance.CreditLimit);
                    }
                    else
                    {
                        MessageBox.Show("Please select valid B2B customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCtlCustCode.Text = "";
                        txtCtlCustCode.Focus();
                    }
                    //if (Utility.CompanyInfo == "TEL")
                    //{
                    //    if (oCustomer.CustTypeID == 249 || oCustomer.CustTypeID == 245)
                    //    {

                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Please select valid B2B customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        txtCtlCustCode.Text = "";
                    //        txtCtlCustCode.Focus();
                    //    }
                    //}
                    //else if (Utility.CompanyInfo == "TML")
                    //{
                    //    if (oCustomer.CustTypeID == 202 || oCustomer.CustTypeID == 217)
                    //    {

                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Please select valid B2B customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        //return false;
                    //        txtCtlCustCode.Text = "";
                    //        txtCtlCustCode.Focus();
                    //    }
                    //}
                }
                if (_nUIControl == (int)Dictionary.SalesType.B2C)
                {
                    CustomerTypies oCustomerTypes = new CustomerTypies();
                    _sCustType = oCustomerTypes.GetCustTypeSalesTypeWise((int)Dictionary.SalesType.B2C);
                    if (_sCustType.Contains(oCustomer.CustTypeID.ToString()))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please select valid B2C customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCtlCustCode.Text = "";
                        txtCtlCustCode.Focus();
                    }
                    //if (Utility.CompanyInfo == "TEL")
                    //{
                    //    if (oCustomer.CustTypeID != 245)
                    //    {
                    //        MessageBox.Show("Please select valid B2C customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        txtCtlCustCode.Text = "";
                    //        txtCtlCustCode.Focus();
                    //    }
                    //}
                    //else if (Utility.CompanyInfo == "TML")
                    //{
                    //    if (oCustomer.CustTypeID != 217)
                    //    {
                    //        MessageBox.Show("Please select valid B2C customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        //return false;
                    //        txtCtlCustCode.Text = "";
                    //        txtCtlCustCode.Focus();
                    //    }
                    //}
                }

                if (_nUIControl == (int)Dictionary.SalesType.HPA)
                {
                    //if (Utility.CompanyInfo == "TEL")
                    //{
                    //    if (oCustomer.CustTypeID == 241 || oCustomer.CustTypeID == 244 || oCustomer.CustTypeID == 252 || oCustomer.CustTypeID == 253)
                    //    {

                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Please select valid HPA customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        txtCtlCustCode.Text = "";
                    //        txtCtlCustCode.Focus();
                    //    }

                    //}
                    CustomerTypies oCustomerTypes = new CustomerTypies();
                    _sCustType = oCustomerTypes.GetCustTypeSalesTypeWise((int)Dictionary.SalesType.HPA);
                    if (_sCustType.Contains(oCustomer.CustTypeID.ToString()))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please select valid HPA customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCtlCustCode.Text = "";
                        txtCtlCustCode.Focus();
                    }
                }
            }
            else
            {
                lblCustomerBalanceAmt.Text = "00.0";
                lblBGAmt.Text = "00.0";
                lblCreditLimit.Text = "00.0";
            }
        }


        private void chkB2BDiscount_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtKM_TextChanged(object sender, EventArgs e)
        {
            if (txtKM.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtKM.Text);


                }
                catch
                {
                    MessageBox.Show("Please Input valid Distance (KM) ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKM.Text = "0";
                }

            }
        }

        private void txtFloor_TextChanged(object sender, EventArgs e)
        {
            if (txtFloor.Text.Trim() != "")
            {
                try
                {
                    int temp = Convert.ToInt32(txtFloor.Text);

                }
                catch
                {
                    MessageBox.Show("Please Input valid Floor# ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFloor.Text = "0";
                }

            }
        }

        private void cmbPromotionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbThana_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkShiptothisaddress_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShiptothisaddress.Checked == true)
            {
                txtDeliveryAddress.Enabled = false;
                txtDeliveryAddress.Text = txtCustomerAddress.Text;
            }
            else
            {
                txtDeliveryAddress.Enabled = true;
                txtDeliveryAddress.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



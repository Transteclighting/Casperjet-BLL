using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace CJ.Win.Promotion
{
    public partial class frmPromotionCalculator : Form
    {
        //private ProductDetail _oProductDetail;
        //private TELLib oTELLib;
        //bool _InvoiceLineItemButtonLock = false;
        //private SystemInfo oSystemInfo;
        //private WUIUtility oWUIUtility;
        //private Product _oProduct;
        //private int _nUIControl = 0;
        //bool _IsApplyPromotion = false;
        //private Customer _oCustomer;
        //private bool _IsApplicableB2BDiscountInv = true;

        public string _sBarcodeForDefective = "";
        SMSMaker _oSMSMaker;
        int _nInvoiceCustomerTypeID = 0;
        DutyTran oDutyTranVAT63_15;
        DutyTran oDutyTranVAT63_5;
        DutyTran oDutyTranVATExampled;
        string sFromLeadConsumerCode = "";
        int nFromLeadConsumeID = 0;
        private Customer _oCustomer;
        public event System.EventHandler ChangeSelection;
        public event KeyPressEventHandler ChangeFocus;
        string sCustumerTypeID = "";
        bool _IsApplyPromotion = false;

        DSSalesInvoice oInvoiceDiscountChargeMap;
        DSSalesInvoice oDSProductBarcodeAll;
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
        private Showrooms _oShowrooms;
        int nWarehouseID=0;

        public frmPromotionCalculator()
        {
            InitializeComponent();
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
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oForm.sProductCode;
                oRow.Cells[2].Value = oForm.sProductName;
                oRow.Cells[9].Value = oForm.sProductId;
                oRow.Cells[11].Value = 0;
                //oRow.Cells[24].Value = oForm._nIsVatApplicableonNetPrice;

                if (oForm.sProductId != 0)
                {
                    oWUIUtility = new WUIUtility();
                    oWUIUtility.GetRetailStock(nWarehouseID, oForm.sProductId);//(oSystemInfo.WarehouseID, oForm.sProductId);

                    if (oWUIUtility.CurrentStock < 0)
                        oRow.Cells[4].Value = 0;
                    else oRow.Cells[4].Value = oWUIUtility.CurrentStock;
                }
                if (oForm.sProductCode != null)
                {
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.GetPriceConsideringEffectiveDate(Convert.ToDateTime(DateTime.Today.Date),//Convert.ToDateTime(oSystemInfo.OperationDate),
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
                        //dgvLineItem.Rows[e.RowIndex].Cells[5].ReadOnly = true;
                        oRow.Cells[5].Style.BackColor = Color.White;
                        oRow.Cells[5].ReadOnly = false;
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
                //frmInvoicePayment ofrmInvoicePayment = new frmInvoicePayment(nProductID, sProductName, nPMCustomerID,
                //    sConsumerCode, _CPDiscount, _nUIControl,
                //    Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[6].Value.ToString()), oSingleDiscount, _AdditionalDis, _TotalCharge, _CollectionAmt, oSinglePayment, _IsApplicableB2BDiscountInv, _TPDiscount, oExptProductID, nFreeEMITenureID, chkB2BDiscount.Checked);
                //    ofrmInvoicePayment.ShowDialog();

                //    if (ofrmInvoicePayment._IsTrue == true)
                //    {
                //        //ctlCustomer1.Enabled = false;
                //        txtCtlCustCode.Enabled = false;
                //        btnCtlCustPicker.Enabled = false;
                //        txtCtlCustName.Enabled = false;

                //        _IsApplicableB2BDiscountInv = ofrmInvoicePayment._IsApplicableB2BDiscountPayment;
                //    }

                //    #region Sales Invoice Additional Discount
                //    //Discount 
                //    if (ofrmInvoicePayment._IsTrue == true)
                //    {
                //        DSSalesInvoiceDiscount oDSSalesInvoiceDiscount = new DSSalesInvoiceDiscount();
                //        if (ofrmInvoicePayment.oDsSalesInvoiceDiscount.SalesInvoiceDiscount.Count > 0)
                //        {
                //            foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                //            {
                //                if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                //                {
                //                    //if (nProductID != int.Parse(oItemRow.Cells[0].Value.ToString()) && int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Discount)
                //                    if (nProductID != int.Parse(oItemRow.Cells[0].Value.ToString()))
                //                    {
                //                        if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Discount || int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Free_Product)
                //                        {

                //                            DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oSalesInvoiceDiscountRow =
                //                                oDSSalesInvoiceDiscount.SalesInvoiceDiscount.NewSalesInvoiceDiscountRow();
                //                            oSalesInvoiceDiscountRow.ProductID =
                //                                Convert.ToInt32(oItemRow.Cells[0].Value.ToString().Trim());
                //                            try
                //                            {
                //                                oSalesInvoiceDiscountRow.DiscountTypeID =
                //                                    Convert.ToInt32(oItemRow.Cells[1].Value.ToString().Trim());
                //                            }
                //                            catch
                //                            {
                //                                oSalesInvoiceDiscountRow.DiscountTypeID = -1;
                //                            }
                //                            try
                //                            {
                //                                oSalesInvoiceDiscountRow.DiscountTypeName =
                //                                    oItemRow.Cells[2].Value.ToString().Trim();
                //                            }
                //                            catch
                //                            {
                //                                oSalesInvoiceDiscountRow.DiscountTypeName = "";
                //                            }
                //                            try
                //                            {
                //                                oSalesInvoiceDiscountRow.Amount =
                //                                    Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                //                            }
                //                            catch
                //                            {
                //                                oSalesInvoiceDiscountRow.DiscountTypeID = 0;
                //                            }
                //                            try
                //                            {
                //                                oSalesInvoiceDiscountRow.InstrumentNo =
                //                                    oItemRow.Cells[4].Value.ToString().Trim();
                //                            }
                //                            catch
                //                            {
                //                                oSalesInvoiceDiscountRow.InstrumentNo = "";
                //                            }
                //                            try
                //                            {
                //                                oSalesInvoiceDiscountRow.Description =
                //                                    oItemRow.Cells[5].Value.ToString().Trim();
                //                            }
                //                            catch
                //                            {
                //                                oSalesInvoiceDiscountRow.Description = "";
                //                            }
                //                            oSalesInvoiceDiscountRow.Type = Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim());
                //                            oSalesInvoiceDiscountRow.FreeProductID = Convert.ToInt32(oItemRow.Cells[7].Value.ToString().Trim());
                //                            oSalesInvoiceDiscountRow.FreeQty = Convert.ToInt32(oItemRow.Cells[8].Value.ToString().Trim());
                //                            oSalesInvoiceDiscountRow.IsBarcodeItemFreeProduct = Convert.ToInt32(oItemRow.Cells[10].Value.ToString().Trim());
                //                            try
                //                            {
                //                                oSalesInvoiceDiscountRow.ProductSerialNo = oItemRow.Cells[9].Value.ToString().Trim();
                //                            }
                //                            catch
                //                            {
                //                                oSalesInvoiceDiscountRow.ProductSerialNo = "";
                //                            }

                //                            oDSSalesInvoiceDiscount.SalesInvoiceDiscount.AddSalesInvoiceDiscountRow(oSalesInvoiceDiscountRow);
                //                            oDSSalesInvoiceDiscount.AcceptChanges();
                //                        }
                //                    }
                //                }
                //            }

                //        }
                //        ///end Discount
                //        ////Charge
                //        if (ofrmInvoicePayment.oDsSalesInvoiceDiscount.SalesInvoiceCharge.Count > 0)
                //        {
                //            foreach (DataGridViewRow oItemRow in dgvSalesInvoiceDiscount.Rows)
                //            {
                //                if (oItemRow.Index < dgvSalesInvoiceDiscount.Rows.Count)
                //                {
                //                    //if (nProductID != int.Parse(oItemRow.Cells[0].Value.ToString()) && int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Charge)
                //                    if (nProductID != int.Parse(oItemRow.Cells[0].Value.ToString()))
                //                    {
                //                        if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.DiscountChargeType.Charge)
                //                        {
                //                            DSSalesInvoiceDiscount.SalesInvoiceChargeRow oSalesInvoiceChargeRow =
                //                                oDSSalesInvoiceDiscount.SalesInvoiceCharge.NewSalesInvoiceChargeRow();
                //                            oSalesInvoiceChargeRow.ProductID =
                //                                Convert.ToInt32(oItemRow.Cells[0].Value.ToString().Trim());
                //                            try
                //                            {
                //                                oSalesInvoiceChargeRow.DiscountTypeID =
                //                                        Convert.ToInt32(oItemRow.Cells[1].Value.ToString().Trim());
                //                            }
                //                            catch
                //                            {
                //                                oSalesInvoiceChargeRow.DiscountTypeID = -1;
                //                            }
                //                            try
                //                            {
                //                                oSalesInvoiceChargeRow.DiscountTypeName =
                //                                        oItemRow.Cells[2].Value.ToString().Trim();
                //                            }
                //                            catch
                //                            {
                //                                oSalesInvoiceChargeRow.DiscountTypeName = "";
                //                            }
                //                            try
                //                            {
                //                                oSalesInvoiceChargeRow.Amount =
                //                                        Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                //                            }
                //                            catch
                //                            {
                //                                oSalesInvoiceChargeRow.DiscountTypeID = 0;
                //                            }
                //                            try
                //                            {
                //                                oSalesInvoiceChargeRow.InstrumentNo =
                //                                        oItemRow.Cells[4].Value.ToString().Trim();
                //                            }
                //                            catch
                //                            {
                //                                oSalesInvoiceChargeRow.InstrumentNo = "";
                //                            }
                //                            try
                //                            {
                //                                oSalesInvoiceChargeRow.Description =
                //                                        oItemRow.Cells[5].Value.ToString().Trim();
                //                            }
                //                            catch
                //                            {
                //                                oSalesInvoiceChargeRow.Description = "";
                //                            }

                //                            oSalesInvoiceChargeRow.Type = Convert.ToInt32(oItemRow.Cells[6].Value.ToString().Trim());

                //                            oDSSalesInvoiceDiscount.SalesInvoiceCharge.AddSalesInvoiceChargeRow(
                //                                oSalesInvoiceChargeRow);
                //                            oDSSalesInvoiceDiscount.AcceptChanges();
                //                        }
                //                    }
                //                }
                //            }
                //        }

                //        ////end Charge
                //        ofrmInvoicePayment.oDsSalesInvoiceDiscount.Merge(oDSSalesInvoiceDiscount);
                //        ofrmInvoicePayment.oDsSalesInvoiceDiscount.AcceptChanges();
                //        dgvSalesInvoiceDiscount.Rows.Clear();

                //        if (ofrmInvoicePayment.oDsSalesInvoiceDiscount.SalesInvoiceDiscount.Count > 0)
                //        {
                //            foreach (
                //            DSSalesInvoiceDiscount.SalesInvoiceDiscountRow oSalesInvoiceDiscountRow in
                //                ofrmInvoicePayment.oDsSalesInvoiceDiscount.SalesInvoiceDiscount)
                //            {
                //                DataGridViewRow oRow = new DataGridViewRow();
                //                oRow.CreateCells(dgvSalesInvoiceDiscount);
                //                oRow.Cells[0].Value = oSalesInvoiceDiscountRow.ProductID.ToString();
                //                oRow.Cells[1].Value = oSalesInvoiceDiscountRow.DiscountTypeID.ToString();
                //                oRow.Cells[2].Value = oSalesInvoiceDiscountRow.DiscountTypeName.ToString();
                //                oRow.Cells[3].Value = oSalesInvoiceDiscountRow.Amount.ToString();
                //                oRow.Cells[4].Value = oSalesInvoiceDiscountRow.InstrumentNo.ToString();
                //                oRow.Cells[5].Value = oSalesInvoiceDiscountRow.Description.ToString();
                //                oRow.Cells[6].Value = oSalesInvoiceDiscountRow.Type.ToString();

                //                oRow.Cells[7].Value = oSalesInvoiceDiscountRow.FreeProductID.ToString();
                //                oRow.Cells[8].Value = oSalesInvoiceDiscountRow.FreeQty.ToString();
                //                oRow.Cells[9].Value = oSalesInvoiceDiscountRow.ProductSerialNo.ToString();
                //                oRow.Cells[10].Value = oSalesInvoiceDiscountRow.IsBarcodeItemFreeProduct.ToString();

                //                dgvSalesInvoiceDiscount.Rows.Add(oRow);
                //            }
                //        }
                //        if (ofrmInvoicePayment.oDsSalesInvoiceDiscount.SalesInvoiceCharge.Count > 0)
                //        {
                //            foreach (
                //            DSSalesInvoiceDiscount.SalesInvoiceChargeRow oSalesInvoiceChargeRow in
                //                ofrmInvoicePayment.oDsSalesInvoiceDiscount.SalesInvoiceCharge)
                //            {
                //                DataGridViewRow oRow = new DataGridViewRow();
                //                oRow.CreateCells(dgvSalesInvoiceDiscount);
                //                oRow.Cells[0].Value = oSalesInvoiceChargeRow.ProductID.ToString();
                //                oRow.Cells[1].Value = oSalesInvoiceChargeRow.DiscountTypeID.ToString();
                //                oRow.Cells[2].Value = oSalesInvoiceChargeRow.DiscountTypeName.ToString();
                //                oRow.Cells[3].Value = oSalesInvoiceChargeRow.Amount.ToString();
                //                oRow.Cells[4].Value = oSalesInvoiceChargeRow.InstrumentNo.ToString();
                //                oRow.Cells[5].Value = oSalesInvoiceChargeRow.Description.ToString();
                //                oRow.Cells[6].Value = (int)Dictionary.DiscountChargeType.Charge;

                //                oRow.Cells[7].Value = -1;
                //                oRow.Cells[8].Value = -1;
                //                oRow.Cells[9].Value = "";
                //                oRow.Cells[10].Value = -1;

                //                dgvSalesInvoiceDiscount.Rows.Add(oRow);
                //            }
                //        }

                //    }
                //    #endregion

                //    #region Sales Invoice Payment

                //    if (ofrmInvoicePayment._IsTrue == true)
                //    {
                //        //ctlCustomer1.Enabled = false;
                //        txtCtlCustCode.Enabled = false;
                //        btnCtlCustPicker.Enabled = false;
                //        txtCtlCustName.Enabled = false;


                //        dgvLineItem.Rows[e.RowIndex].Cells[12].Value = ofrmInvoicePayment._AdditionalCharge;
                //        dgvLineItem.Rows[e.RowIndex].Cells[13].Value = ofrmInvoicePayment._AdditionalDiscount;
                //        dgvLineItem.Rows[e.RowIndex].Cells[15].Value = ofrmInvoicePayment._TotalDiscountAfter;
                //        dgvLineItem.Rows[e.RowIndex].Cells[16].Value = ofrmInvoicePayment._TotalPayableAfter;
                //        dgvLineItem.Rows[e.RowIndex].Cells[18].Value = ofrmInvoicePayment._TotalCollectionAfter;


                //        DSInvoicePayment oDSInvoicePayment = new DSInvoicePayment();
                //        foreach (DataGridViewRow oItemRow in dgvInvoicePayment.Rows)
                //        {
                //            if (oItemRow.Index < dgvInvoicePayment.Rows.Count)
                //            {
                //                if (nProductID != int.Parse(oItemRow.Cells[13].Value.ToString()))
                //                {

                //                    DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow =
                //                        oDSInvoicePayment.InvoicePayment.NewInvoicePaymentRow();
                //                    oInvoicePaymentRow.ProductID = int.Parse(oItemRow.Cells[13].Value.ToString());
                //                    oInvoicePaymentRow.ProductName = oItemRow.Cells[0].FormattedValue.ToString();
                //                    oInvoicePaymentRow.PaymentModeID = int.Parse(oItemRow.Cells[14].Value.ToString());
                //                    oInvoicePaymentRow.PaymentModeName = oItemRow.Cells[2].FormattedValue.ToString();
                //                    oInvoicePaymentRow.Amount = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                //                    try
                //                    {
                //                        oInvoicePaymentRow.BankID = int.Parse(oItemRow.Cells[15].Value.ToString());
                //                        oInvoicePaymentRow.BankName = oItemRow.Cells[4].FormattedValue.ToString();
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.BankID = -1;
                //                        oInvoicePaymentRow.BankName = "";
                //                    }
                //                    try
                //                    {
                //                        oInvoicePaymentRow.CardType = int.Parse(oItemRow.Cells[16].Value.ToString());
                //                        oInvoicePaymentRow.CardTypeName = oItemRow.Cells[5].FormattedValue.ToString();
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.CardType = -1;
                //                        oInvoicePaymentRow.CardTypeName = "";
                //                    }
                //                    try
                //                    {
                //                        oInvoicePaymentRow.POSMachineID = int.Parse(oItemRow.Cells[17].Value.ToString());
                //                        oInvoicePaymentRow.POSMachineName = oItemRow.Cells[6].FormattedValue.ToString();
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.POSMachineID = -1;
                //                        oInvoicePaymentRow.POSMachineName = "";
                //                    }

                //                    try
                //                    {
                //                        oInvoicePaymentRow.CardCategory = int.Parse(oItemRow.Cells[18].Value.ToString());
                //                        oInvoicePaymentRow.CardCategoryName =
                //                            oItemRow.Cells[11].FormattedValue.ToString();
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.CardCategory = -1;
                //                        oInvoicePaymentRow.CardCategoryName = "";
                //                    }
                //                    try
                //                    {
                //                        oInvoicePaymentRow.ApprovalNo = oItemRow.Cells[12].Value.ToString().Trim();
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.ApprovalNo = "";

                //                    }
                //                    try
                //                    {

                //                        if (oItemRow.Cells[7].Value.ToString() == "YES")
                //                        {
                //                            oInvoicePaymentRow.IsEMI = 1;
                //                        }
                //                        else
                //                        {
                //                            oInvoicePaymentRow.IsEMI = 0;
                //                        }

                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.IsEMI = 0;
                //                    }
                //                    try
                //                    {
                //                        oInvoicePaymentRow.NoOfInstallment =
                //                            int.Parse(oItemRow.Cells[8].Value.ToString().Trim());
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.NoOfInstallment = -1;
                //                    }
                //                    try
                //                    {
                //                        oInvoicePaymentRow.InstrumentNo = oItemRow.Cells[9].Value.ToString().Trim();
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.InstrumentNo = "";
                //                    }

                //                    try
                //                    {
                //                        oInvoicePaymentRow.InstrumentDate =
                //                            Convert.ToDateTime(oItemRow.Cells[10].Value.ToString().Trim());
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.InstrumentDate = DateTime.Now.Date;
                //                    }

                //                    try
                //                    {
                //                        oInvoicePaymentRow.ExtendedEMICharge = Convert.ToDouble(oItemRow.Cells[19].Value.ToString().Trim());
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.ExtendedEMICharge = 0;
                //                    }
                //                    try
                //                    {
                //                        oInvoicePaymentRow.BankDiscount = Convert.ToDouble(oItemRow.Cells[20].Value.ToString().Trim());
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.BankDiscount = 0;
                //                    }

                //                    try
                //                    {
                //                        oInvoicePaymentRow.BGID = Convert.ToInt32(oItemRow.Cells[21].Value.ToString().Trim());
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.BGID = -1;
                //                    }
                //                    try
                //                    {
                //                        oInvoicePaymentRow.CreditApprovalID = Convert.ToInt32(oItemRow.Cells[22].Value.ToString().Trim());
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.CreditApprovalID = -1;
                //                    }
                //                    try
                //                    {
                //                        oInvoicePaymentRow.AdvancePaymentID = Convert.ToInt32(oItemRow.Cells[23].Value.ToString().Trim());
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.AdvancePaymentID = -1;
                //                    }

                //                    try
                //                    {
                //                        oInvoicePaymentRow.BankDiscountID = Convert.ToInt32(oItemRow.Cells[24].Value.ToString().Trim());
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.BankDiscountID = -1;
                //                    }
                //                    try
                //                    {
                //                        oInvoicePaymentRow.ExtendedEMIChargeID = Convert.ToInt32(oItemRow.Cells[25].Value.ToString().Trim());
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.ExtendedEMIChargeID = -1;
                //                    }


                //                    try
                //                    {
                //                        oInvoicePaymentRow.SDApprovalNo = (oItemRow.Cells[26].Value.ToString().Trim());
                //                    }
                //                    catch
                //                    {
                //                        oInvoicePaymentRow.SDApprovalNo = "";
                //                    }
                //                    oDSInvoicePayment.InvoicePayment.AddInvoicePaymentRow(oInvoicePaymentRow);
                //                    oDSInvoicePayment.AcceptChanges();
                //                }
                //            }
                //        }
                //        ofrmInvoicePayment.oDSInvoicePayment.Merge(oDSInvoicePayment);
                //        ofrmInvoicePayment.oDSInvoicePayment.AcceptChanges();

                //        dgvInvoicePayment.Rows.Clear();
                //        foreach (
                //            DSInvoicePayment.InvoicePaymentRow oInvoicePaymentRow in
                //                ofrmInvoicePayment.oDSInvoicePayment.InvoicePayment)
                //        {
                //            DataGridViewRow oRow = new DataGridViewRow();
                //            oRow.CreateCells(dgvInvoicePayment);
                //            oRow.Cells[0].Value = oInvoicePaymentRow.ProductName.ToString();
                //            oRow.Cells[1].Value = dgvLineItem.Rows[e.RowIndex].Cells[5].Value.ToString();
                //            oRow.Cells[2].Value = oInvoicePaymentRow.PaymentModeName.ToString();
                //            oRow.Cells[3].Value = oInvoicePaymentRow.Amount.ToString();
                //            try
                //            {
                //                oRow.Cells[4].Value = oInvoicePaymentRow.BankName.ToString();
                //            }
                //            catch
                //            {
                //                oRow.Cells[4].Value = "";
                //            }

                //            try
                //            {
                //                oRow.Cells[5].Value = oInvoicePaymentRow.CardTypeName.ToString();
                //            }
                //            catch
                //            {
                //                oRow.Cells[5].Value = "";
                //            }

                //            try
                //            {
                //                oRow.Cells[6].Value = oInvoicePaymentRow.POSMachineName.ToString();
                //            }
                //            catch
                //            {
                //                oRow.Cells[6].Value = "";
                //            }


                //            try
                //            {
                //                oRow.Cells[7].Value = Enum.GetName(typeof(Dictionary.YesOrNoStatus),
                //                    oInvoicePaymentRow.IsEMI);
                //            }
                //            catch
                //            {
                //                oRow.Cells[7].Value = "";
                //            }


                //            try
                //            {
                //                oRow.Cells[8].Value = oInvoicePaymentRow.NoOfInstallment.ToString();
                //            }
                //            catch
                //            {
                //                oRow.Cells[8].Value = "";
                //            }
                //            try
                //            {
                //                oRow.Cells[9].Value = oInvoicePaymentRow.InstrumentNo.ToString();
                //            }
                //            catch
                //            {
                //                oRow.Cells[9].Value = "";
                //            }
                //            try
                //            {
                //                oRow.Cells[10].Value = oInvoicePaymentRow.InstrumentDate.ToString("dd-MMM-yyyy");
                //            }
                //            catch
                //            {
                //                oRow.Cells[10].Value = "";
                //            }
                //            try
                //            {
                //                oRow.Cells[11].Value = oInvoicePaymentRow.CardCategoryName.ToString();
                //            }
                //            catch
                //            {
                //                oRow.Cells[11].Value = "";
                //            }
                //            try
                //            {
                //                oRow.Cells[12].Value = oInvoicePaymentRow.ApprovalNo.ToString();
                //            }
                //            catch
                //            {
                //                oRow.Cells[12].Value = "";
                //            }
                //            oRow.Cells[13].Value = oInvoicePaymentRow.ProductID.ToString();

                //            try
                //            {
                //                oRow.Cells[14].Value = oInvoicePaymentRow.PaymentModeID.ToString();
                //            }
                //            catch
                //            {
                //                oRow.Cells[14].Value = -1;
                //            }
                //            try
                //            {

                //                oRow.Cells[15].Value = oInvoicePaymentRow.BankID.ToString();
                //            }
                //            catch
                //            {

                //                oRow.Cells[15].Value = -1;
                //            }
                //            try
                //            {
                //                oRow.Cells[16].Value = oInvoicePaymentRow.CardType.ToString();
                //            }
                //            catch
                //            {
                //                oRow.Cells[16].Value = -1;
                //            }
                //            try
                //            {
                //                oRow.Cells[17].Value = oInvoicePaymentRow.POSMachineID.ToString();
                //            }
                //            catch
                //            {
                //                oRow.Cells[17].Value = -1;
                //            }
                //            try
                //            {

                //                oRow.Cells[18].Value = oInvoicePaymentRow.CardCategory.ToString();
                //            }
                //            catch
                //            {

                //                oRow.Cells[18].Value = -1;
                //            }
                //            try
                //            {

                //                oRow.Cells[19].Value = oInvoicePaymentRow.ExtendedEMICharge.ToString();
                //            }
                //            catch
                //            {

                //                oRow.Cells[19].Value = 0;
                //            }
                //            try
                //            {

                //                oRow.Cells[20].Value = oInvoicePaymentRow.BankDiscount.ToString();
                //            }
                //            catch
                //            {

                //                oRow.Cells[20].Value = 0;
                //            }
                //            try
                //            {

                //                oRow.Cells[21].Value = oInvoicePaymentRow.BGID.ToString();
                //            }
                //            catch
                //            {

                //                oRow.Cells[21].Value = -1;
                //            }
                //            try
                //            {

                //                oRow.Cells[22].Value = oInvoicePaymentRow.CreditApprovalID.ToString();
                //            }
                //            catch
                //            {

                //                oRow.Cells[22].Value = -1;
                //            }
                //            try
                //            {

                //                oRow.Cells[23].Value = oInvoicePaymentRow.AdvancePaymentID.ToString();
                //            }
                //            catch
                //            {

                //                oRow.Cells[23].Value = -1;
                //            }




                //            try
                //            {

                //                oRow.Cells[24].Value = oInvoicePaymentRow.BankDiscountID.ToString();
                //            }
                //            catch
                //            {

                //                oRow.Cells[24].Value = -1;
                //            }
                //            try
                //            {

                //                oRow.Cells[25].Value = oInvoicePaymentRow.ExtendedEMIChargeID.ToString();
                //            }
                //            catch
                //            {

                //                oRow.Cells[25].Value = -1;
                //            }

                //            try
                //            {

                //                oRow.Cells[26].Value = oInvoicePaymentRow.SDApprovalNo.ToString();
                //            }
                //            catch
                //            {

                //                oRow.Cells[26].Value = "";
                //            }

                //            dgvInvoicePayment.Rows.Add(oRow);
                //        }

                //    }

                //    #endregion

                //    GetTotalRSAmount();
                //}

                #endregion
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
                        _oProductDetail = new ProductDetail();
                        _oProductDetail.GetPriceConsideringEffectiveDate(Convert.ToDateTime(DateTime.Today.Date),
                            oProduct.ProductID);

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 24].Value = oProduct.IsVatApplicableonNetPrice;

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = oProduct.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oProductDetail.RSP;

                        oWUIUtility = new WUIUtility();
                        oWUIUtility.GetRetailStock(nWarehouseID, oProduct.ProductID);
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
                            //dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].ReadOnly = true;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].ReadOnly = false;
                            dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 5].Style.BackColor = Color.White;
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
                //oSystemInfo.Refresh();
                //_nInvoiceCustomerTypeID = oSystemInfo.CustTypeID;
                _nInvoiceCustomerTypeID = -1;
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

            //oSystemInfo = new CJ.Class.POS.SystemInfo();
            //oSystemInfo.Refresh();
            //String _sSystemDate = Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy");
           
            #region CP
            oEligiblePromos = new ConsumerPromotionEngines();
            //Get Eligible Promo
            _oDSEligiblePromo = oEligiblePromos.GetEligiblePromo(Convert.ToDateTime(DateTime.Today.Date), sProductID, nWarehouseID, cmbSalesType.SelectedIndex + 1, _oSalesPromotionTypes[cmbPromotionType.SelectedIndex - 1].SalesPromotionTypeID, _nInvoiceCustomerTypeID);

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
            _oDSEligiblePromoTP = oEligiblePromos.GetEligiblePromoTP(Convert.ToDateTime(DateTime.Today.Date), sMAGID, sBrandID, nWarehouseID, cmbSalesType.SelectedIndex + 1, _oSalesPromotionTypes[cmbPromotionType.SelectedIndex - 1].SalesPromotionTypeID, _nInvoiceCustomerTypeID);


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

                
               


            }
           
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
                oInvoiceDiscountChargeMap = new DSSalesInvoice();

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

              
                
            }
        }

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

        private void SetPromoMap(int nDiscountTypeID, int nDataID, int nSlabID, int nOfferID, string sTableName, int nIsTableData, double Amount, int nFreeProductID, int nFreeQty, int nProductID, int nEMITenureID, int nIsScratchCardFreeProduct)
        {
            DSSalesInvoice.InvoiceDiscountChargeMapRow oInvoiceDiscountChargeMapRow = oInvoiceDiscountChargeMap.InvoiceDiscountChargeMap.NewInvoiceDiscountChargeMapRow();

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

        private void frmPromotionCalculator_Load(object sender, EventArgs e)
        {
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cmbSalesType.SelectedIndex = _nUIControl;


            _oSalesPromotionTypes = new SalesPromotionTypes();
            _oSalesPromotionTypes.Refresh((int)Dictionary.YesOrNoStatus.YES);
            cmbPromotionType.Items.Add("<Select Promotion Type>");
            foreach (SalesPromotionType oSalesPromotionType in _oSalesPromotionTypes)
            {
                cmbPromotionType.Items.Add(oSalesPromotionType.SalesPromotionTypeName);
            }
            if (_oSalesPromotionTypes.Count > 0)
                cmbPromotionType.SelectedIndex = 0;

            //Showroom 
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbShowroom.Items.Clear();
            cmbShowroom.Items.Add("<All>");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbShowroom.Items.Add(oShowroom.ShowroomCode);
            }
            cmbShowroom.SelectedIndex = 0;
        }

        private void btnCtlCustPicker_Click(object sender, EventArgs e)
        {
            CustomerTypies oCustomerTypes = new CustomerTypies();
            _oCustomer = new Customer();
            frmCustomerSearch oObj = new frmCustomerSearch();//(oCustomerTypes.GetCustTypeSalesTypeWise(_nUIControl));
            oObj.ShowDialog(_oCustomer);

            _oCustomer.RefreshByCode();
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

                txtCtlCustCode.Text = _oCustomer.CustomerCode.ToString();
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

        private void cmbShowroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nWarehouseID = _oShowrooms[cmbShowroom.SelectedIndex - 1].WarehouseID;
            }
            catch
            {
                nWarehouseID = 0;
            }
        }

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

                }

            }
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
                }
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
            if (ChangeSelection != null)
                ChangeSelection(this, e);
        }

        private void cmbSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _nUIControl = cmbSalesType.SelectedIndex + 1;            
        }
    }
}

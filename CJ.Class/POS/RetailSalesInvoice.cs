// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: March 27,2012
// Time :  10:30 AM
// Description: Class for Other info for retail invoice
// Modify Person And Date: Md. Abdul Hakim
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.POS
{
    public class RetailSalesInvoice
    {
        private int _nDataType;
        public int DataType
        {
            get { return _nDataType; }
            set { _nDataType = value; }
        }

        private int _nProjectionID;
        public int ProjectionID
        {
            get { return _nProjectionID; }
            set { _nProjectionID = value; }
        }

        private DateTime _dProjectionDate;
        public DateTime ProjectionDate
        {
            get { return _dProjectionDate; }
            set { _dProjectionDate = value; }
        }
        private int _nDataID;
        public int DataID
        {
            get { return _nDataID; }
            set { _nDataID = value; }
        }
        private string _sDataName;
        public string DataName
        {
            get { return _sDataName; }
            set { _sDataName = value.Trim(); }
        }
        private double _Projection;
        public double Projection
        {
            get { return _Projection; }
            set { _Projection = value; }
        }
        private double _Actual;
        public double Actual
        {
            get { return _Actual; }
            set { _Actual = value; }
        }

        private long _InvoiceID;
        private double _SPParcentage;
        private double _FaltAmount;
        private double _SPDiscount;
        private double _InstallationCharge;
        private double _FreightCharge;
        private double _OtherCharge;
        private double _MarkUpAmount;
        private double _PaymentMode;
        private int _nDiscountReasonID;
        private double _Amount;
        private int _BranchID;
        private string _InstrumentNo;
        private object _InstrumentDate;

        private int _nCardCategory;
        private string _sApprovalNo;


        private double _TotalDiscount;
        private double _TotalCharge;
        private double _TotalPayment;
        private double _smsDiscount;

        private double _Cash;
        private double _Credit;
        private double _AdvanceAdjust;
        private double _Others;
        private double _TotalAmount;

        private int _ProductID;
        private string _WarrantyCardNo;
        private string _sProductSerialNo;
        private int _nSalesPromotionType;
        private int _nWarehouseID;
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        private DateTime _dInvoiceDate;
        // <summary>
        // Get set property for InvoiceDate
        // </summary>
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }

        private int _nID;
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        private int _nStatus;
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        private int _nCreateUserID;
        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        private DateTime _dCreateDate;
        // <summary>
        // Get set property for InvoiceDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        private int _nUpdateUserID;
        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        private DateTime _dUpdateDate;

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        private string _sPaymentModeName;
        public string PaymentModeName
        {
            get { return _sPaymentModeName; }
            set { _sPaymentModeName = value.Trim(); }
        }
        /// <summary>
        /// Shuvo
        /// </summary>
        /// 

        private int _nEmployeeID;
        private string _sEmployeeName;
        private string _sSalesCategory;
        private int _nCMSalesQty;
        private double _CMSalesValue;
        private int _nLYSalesQty;
        private double _LYSalesValue;
        private int _nLMTDSalesQty;
        private double _LMTDSalesValue;
        private double _Target;

        private string _sShowroomCode;
        private int _nTYear;
        private int _nTMonth;
        private int _nOLDNOITGT;
        private int _nNEWNOITGT;
        private int _nOLDNOI;
        private int _nNEWNOI;
        private double _Achievement;
        private double _GrowthLM;
        private double _GrowthLYTM;
        private int _nSL;
        private string _sMonth;
        private double _ThisYearTarget;
        private double _ThisYearActual;
        private double _PerviousYearActual;
        private double _GrowthPercentage;
        private int _nTWeek;
        private string _sDesignationName;
        private string _sMAGName;
        private string _sBrand;
        private string _sChannel;
        private int _nTargetQty;
        private double _NetSales;
        private int _nSalesQty;
        private string _sPGName;

        private double _WeekLeadTargetQty;
        public double WeekLeadTargetQty
        {
            get { return _WeekLeadTargetQty; }
            set { _WeekLeadTargetQty = value; }
        }
        private double _WeekLeadTargetAmount;
        public double WeekLeadTargetAmount
        {
            get { return _WeekLeadTargetAmount; }
            set { _WeekLeadTargetAmount = value; }
        }
        private double _WeekTargetQty;
        public double WeekTargetQty
        {
            get { return _WeekTargetQty; }
            set { _WeekTargetQty = value; }
        }
        private double _WeekTargetAmount;
        public double WeekTargetAmount
        {
            get { return _WeekTargetAmount; }
            set { _WeekTargetAmount = value; }
        }
        private double _DayLeadTargetQty;
        public double DayLeadTargetQty
        {
            get { return _DayLeadTargetQty; }
            set { _DayLeadTargetQty = value; }
        }
        private double _DayLeadTargetAmount;
        public double DayLeadTargetAmount
        {
            get { return _DayLeadTargetAmount; }
            set { _DayLeadTargetAmount = value; }
        }
        private double _DayTargetQty;
        public double DayTargetQty
        {
            get { return _DayTargetQty; }
            set { _DayTargetQty = value; }
        }
        private double _DayTargetAmount;
        public double DayTargetAmount
        {
            get { return _DayTargetAmount; }
            set { _DayTargetAmount = value; }
        }
        private double _DayLeadQty;
        public double DayLeadQty
        {
            get { return _DayLeadQty; }
            set { _DayLeadQty = value; }
        }
        private double _DayLeadAmount;
        public double DayLeadAmount
        {
            get { return _DayLeadAmount; }
            set { _DayLeadAmount = value; }
        }

        private double _TotalSalesQty;
        public double TotalSalesQty
        {
            get { return _TotalSalesQty; }
            set { _TotalSalesQty = value; }
        }
        private double _TotalTGTQty;
        public double TotalTGTQty
        {
            get { return _TotalTGTQty; }
            set { _TotalTGTQty = value; }
        }
        private double _TotalQtyPercentage;
        public double TotalQtyPercentage
        {
            get { return _TotalQtyPercentage; }
            set { _TotalQtyPercentage = value; }
        }
        private double _TotalSalesVal;
        public double TotalSalesVal
        {
            get { return _TotalSalesVal; }
            set { _TotalSalesVal = value; }
        }
        private double _TotalTGTVal;
        public double TotalTGTVal
        {
            get { return _TotalTGTVal; }
            set { _TotalTGTVal = value; }
        }
        private double _TotalValPercentage;
        public double TotalValPercentage
        {
            get { return _TotalValPercentage; }
            set { _TotalValPercentage = value; }
        }

        private int _nRTLTGRQty;
        public int RTLTGRQty
        {
            get { return _nRTLTGRQty; }
            set { _nRTLTGRQty = value; }
        }
        private int _nRTLSalesQty;
        public int RTLSalesQty
        {
            get { return _nRTLSalesQty; }
            set { _nRTLSalesQty = value; }
        }
        private int _nB2BTGTQty;
        public int B2BTGTQty
        {
            get { return _nB2BTGTQty; }
            set { _nB2BTGTQty = value; }
        }
        private int _nB2BSalesQty;
        public int B2BSalesQty
        {
            get { return _nB2BSalesQty; }
            set { _nB2BSalesQty = value; }
        }
        private int _nDealerTGTQty;
        public int DealerTGTQty
        {
            get { return _nDealerTGTQty; }
            set { _nDealerTGTQty = value; }
        }
        private int _nDealerSalesQty;
        public int DealerSalesQty
        {
            get { return _nDealerSalesQty; }
            set { _nDealerSalesQty = value; }
        }
        private int _neStoreTGTQty;
        public int eStoreTGTQty
        {
            get { return _neStoreTGTQty; }
            set { _neStoreTGTQty = value; }
        }
        private int _neStoreSalesQty;
        public int eStoreSalesQty
        {
            get { return _neStoreSalesQty; }
            set { _neStoreSalesQty = value; }
        }

        private double _nRetailTGTVal;
        public double RetailTGTVal
        {
            get { return _nRetailTGTVal; }
            set { _nRetailTGTVal = value; }
        }
        private double _nRTLSalesVal;
        public double RTLSalesVal
        {
            get { return _nRTLSalesVal; }
            set { _nRTLSalesVal = value; }
        }
        private double _nB2BTGTVal;
        public double B2BTGTVal
        {
            get { return _nB2BTGTVal; }
            set { _nB2BTGTVal = value; }
        }
        private double _nB2BSalesVal;
        public double B2BSalesVal
        {
            get { return _nB2BSalesVal; }
            set { _nB2BSalesVal = value; }
        }
        private double _nDealerTGTVal;
        public double DealerTGTVal
        {
            get { return _nDealerTGTVal; }
            set { _nDealerTGTVal = value; }
        }
        private double _nDealerSalesVal;
        public double DealerSalesVal
        {
            get { return _nDealerSalesVal; }
            set { _nDealerSalesVal = value; }
        }
        private double _neStoreTGTVal;
        public double eStoreTGTVal
        {
            get { return _neStoreTGTVal; }
            set { _neStoreTGTVal = value; }
        }
        private double _neStoreSalesVal;
        public double eStoreSalesVal
        {
            get { return _neStoreSalesVal; }
            set { _neStoreSalesVal = value; }
        }


        private double _RTLQtyPercentage;
        public double RTLQtyPercentage
        {
            get { return _RTLQtyPercentage; }
            set { _RTLQtyPercentage = value; }
        }
        private double _DealerQtyPercentage;
        public double DealerQtyPercentage
        {
            get { return _DealerQtyPercentage; }
            set { _DealerQtyPercentage = value; }
        }
        private double _B2BQtyPercentage;
        public double B2BQtyPercentage
        {
            get { return _B2BQtyPercentage; }
            set { _B2BQtyPercentage = value; }
        }
        private double _eStoreQtyPercentage;
        public double eStoreQtyPercentage
        {
            get { return _eStoreQtyPercentage; }
            set { _eStoreQtyPercentage = value; }
        }
        private double _RTLValPercentage;
        public double RTLValPercentage
        {
            get { return _RTLValPercentage; }
            set { _RTLValPercentage = value; }
        }
        private double _DealerValPercentage;
        public double DealerValPercentage
        {
            get { return _DealerValPercentage; }
            set { _DealerValPercentage = value; }
        }
        private double _B2BValPercentage;
        public double B2BValPercentage
        {
            get { return _B2BValPercentage; }
            set { _B2BValPercentage = value; }
        }
        private double _eStoreValPercentage;
        public double eStoreValPercentage
        {
            get { return _eStoreValPercentage; }
            set { _eStoreValPercentage = value; }
        }



        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value.Trim(); }
        }

        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value.Trim(); }
        }
        public string Channel
        {
            get { return _sChannel; }
            set { _sChannel = value.Trim(); }
        }
        public int TargetQty
        {
            get { return _nTargetQty; }
            set { _nTargetQty = value; }
        }
        public int SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }
        public double NetSales
        {
            get { return _NetSales; }
            set { _NetSales = value; }
        }

        private double _QtyPercentage;
        private double _ValuePercentage;

        public double QtyPercentage
        {
            get { return _QtyPercentage; }
            set { _QtyPercentage = value; }
        }
        public double ValuePercentage
        {
            get { return _ValuePercentage; }
            set { _ValuePercentage = value; }
        }


        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }
        private string _EmployeeCode;
        public string EmployeeCode
        {
            get { return _EmployeeCode; }
            set { _EmployeeCode = value.Trim(); }
        }
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
        public string DesignationName
        {
            get { return _sDesignationName; }
            set { _sDesignationName = value.Trim(); }
        }
        public string SalesCategory
        {
            get { return _sSalesCategory; }
            set { _sSalesCategory = value.Trim(); }
        }
        public int CMSalesQty
        {
            get { return _nCMSalesQty; }
            set { _nCMSalesQty = value; }
        }
        public double CMSalesValue
        {
            get { return _CMSalesValue; }
            set { _CMSalesValue = value; }
        }
        public int LYSalesQty
        {
            get { return _nLYSalesQty; }
            set { _nLYSalesQty = value; }
        }
        public double LYSalesValue
        {
            get { return _LYSalesValue; }
            set { _LYSalesValue = value; }
        }
        public int LMTDSalesQty
        {
            get { return _nLMTDSalesQty; }
            set { _nLMTDSalesQty = value; }
        }
        public double LMTDSalesValue
        {
            get { return _LMTDSalesValue; }
            set { _LMTDSalesValue = value; }
        }
        public double Target
        {
            get { return _Target; }
            set { _Target = value; }
        }

        public double Achievement
        {
            get { return _Achievement; }
            set { _Achievement = value; }
        }
        public double GrowthLM
        {
            get { return _GrowthLM; }
            set { _GrowthLM = value; }
        }
        public double GrowthLYTM
        {
            get { return _GrowthLYTM; }
            set { _GrowthLYTM = value; }
        }

        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }

        public int TYear
        {
            get { return _nTYear; }
            set { _nTYear = value; }
        }
        public int TMonth
        {
            get { return _nTMonth; }
            set { _nTMonth = value; }
        }
        public int TWeek
        {
            get { return _nTWeek; }
            set { _nTWeek = value; }
        }
        public int OLDNOITGT
        {
            get { return _nOLDNOITGT; }
            set { _nOLDNOITGT = value; }
        }
        public int NEWNOITGT
        {
            get { return _nNEWNOITGT; }
            set { _nNEWNOITGT = value; }
        }
        public int OLDNOI
        {
            get { return _nOLDNOI; }
            set { _nOLDNOI = value; }
        }
        public int NEWNOI
        {
            get { return _nNEWNOI; }
            set { _nNEWNOI = value; }
        }



        public int SL
        {
            get { return _nSL; }
            set { _nSL = value; }
        }
        public string Month
        {
            get { return _sMonth; }
            set { _sMonth = value.Trim(); }
        }
        public double ThisYearTarget
        {
            get { return _ThisYearTarget; }
            set { _ThisYearTarget = value; }
        }
        public double ThisYearActual
        {
            get { return _ThisYearActual; }
            set { _ThisYearActual = value; }
        }
        public double PerviousYearActual
        {
            get { return _PerviousYearActual; }
            set { _PerviousYearActual = value; }
        }
        public double GrowthPercentage
        {
            get { return _GrowthPercentage; }
            set { _GrowthPercentage = value; }
        }

        /// <summary>
        /// /End Shuvo
        /// </summary>

        private double _ExtendedEMICharge;
        public double ExtendedEMICharge
        {
            get { return _ExtendedEMICharge; }
            set { _ExtendedEMICharge = value; }
        }
        private string _sSDApprovalNo;
        public string SDApprovalNo
        {
            get { return _sSDApprovalNo; }
            set { _sSDApprovalNo = value; }
        }
        private double _BankDiscount;
        public double BankDiscount
        {
            get { return _BankDiscount; }
            set { _BankDiscount = value; }
        }
        public int CardCategory
        {
            get { return _nCardCategory; }
            set { _nCardCategory = value; }
        }
        public string ApprovalNo
        {
            get { return _sApprovalNo; }
            set { _sApprovalNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for InvoiceID
        /// </summary>
        public long InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }

        /// <summary>
        /// Get set property for SPParcentage
        /// </summary>
        public double SPParcentage
        {
            get { return _SPParcentage; }
            set { _SPParcentage = value; }
        }

        /// <summary>
        /// Get set property for FaltAmount
        /// </summary>
        public double FaltAmount
        {
            get { return _FaltAmount; }
            set { _FaltAmount = value; }
        }
        public double SPDiscount
        {
            get { return _SPDiscount; }
            set { _SPDiscount = value; }
        }

        /// <summary>
        /// Get set property for InstallationCharge
        /// </summary>
        public double InstallationCharge
        {
            get { return _InstallationCharge; }
            set { _InstallationCharge = value; }
        }

        /// <summary>
        /// Get set property for FreightCharge
        /// </summary>
        public double FreightCharge
        {
            get { return _FreightCharge; }
            set { _FreightCharge = value; }
        }

        /// <summary>
        /// Get set property for OtherCharge
        /// </summary>
        public double OtherCharge
        {
            get { return _OtherCharge; }
            set { _OtherCharge = value; }
        }

        /// <summary>
        /// Get set property for MarkUpAmount
        /// </summary>
        public double MarkUpAmount
        {
            get { return _MarkUpAmount; }
            set { _MarkUpAmount = value; }
        }
        /// <summary>
        /// Get set property for PaymentMode
        /// </summary>
        public double PaymentMode
        {
            get { return _PaymentMode; }
            set { _PaymentMode = value; }
        }

        /// <summary>
        /// Get set property for DiscountReasonID
        /// </summary>
        public int DiscountReasonID
        {
            get { return _nDiscountReasonID; }
            set { _nDiscountReasonID = value; }
        }

        /// <summary>
        /// Get set property for Amount
        /// </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        private int _nDiscountTypeID;
        public int DiscountTypeID
        {
            get { return _nDiscountTypeID; }
            set { _nDiscountTypeID = value; }
        }
        private string _sDiscountTypeName;
        public string DiscountTypeName
        {
            get { return _sDiscountTypeName; }
            set { _sDiscountTypeName = value.Trim(); }
        }
        private int _nType;
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }


        /// <summary>
        /// Get set property for BranchID
        /// </summary>
        public int BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }

        /// <summary>
        /// Get set property for InstrumentNo
        /// </summary>
        public string InstrumentNo
        {
            get { return _InstrumentNo; }
            set { _InstrumentNo = value.Trim(); }
        }

        private string _sDescription;
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        /// <summary>
        /// Get set property for InstrumentDate
        /// </summary>
        public object InstrumentDate
        {
            get { return _InstrumentDate; }
            set { _InstrumentDate = value; }
        }
        public double TotalDiscount
        {
            get { return _TotalDiscount; }
            set { _TotalDiscount = value; }
        }
        public double smsDiscount
        {
            get { return _smsDiscount; }
            set { _smsDiscount = value; }
        }
        public double TotalCharge
        {
            get { return _TotalCharge; }
            set { _TotalCharge = value; }
        }
        public double TotalPayment
        {
            get { return _TotalPayment; }
            set { _TotalPayment = value; }
        }
        public double Cash
        {
            get { return _Cash; }
            set { _Cash = value; }
        }
        public double Credit
        {
            get { return _Credit; }
            set { _Credit = value; }
        }
        public double AdvanceAdjust
        {
            get { return _AdvanceAdjust; }
            set { _AdvanceAdjust = value; }
        }
        public double Others
        {
            get { return _Others; }
            set { _Others = value; }
        }

        public double TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }

        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        public string WarrantyCardNo
        {
            get { return _WarrantyCardNo; }
            set { _WarrantyCardNo = value.Trim(); }
        }
        private int _nBankID;
        private int _nPaymentModeID;
        private int _nPOSMachineID;
        private int _nIsEMI;
        private int _nNoOfInstallment;
        private int _nCardType;

        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }
        public int PaymentModeID
        {
            get { return _nPaymentModeID; }
            set { _nPaymentModeID = value; }
        }
        public int POSMachineID
        {
            get { return _nPOSMachineID; }
            set { _nPOSMachineID = value; }
        }
        public int IsEMI
        {
            get { return _nIsEMI; }
            set { _nIsEMI = value; }
        }
        public int NoOfInstallment
        {
            get { return _nNoOfInstallment; }
            set { _nNoOfInstallment = value; }
        }
        public int CardType
        {
            get { return _nCardType; }
            set { _nCardType = value; }
        }

        private int _nOutletID;
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }

        private int _nExtendedWarrantyID;
        public int ExtendedWarrantyID
        {
            get { return _nExtendedWarrantyID; }
            set { _nExtendedWarrantyID = value; }
        }
        private string _sExtendedWarrantyDescription;
        public string ExtendedWarrantyDescription
        {
            get { return _sExtendedWarrantyDescription; }
            set { _sExtendedWarrantyDescription = value; }
        }
        private int _nWarrantyParameterID;
        public int WarrantyParameterID
        {
            get { return _nWarrantyParameterID; }
            set { _nWarrantyParameterID = value; }
        }
        private string _sConsumerName;
        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value; }
        }
        private string _sEmail;
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }
        private string _sInvoiceNo;
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }

        private string _sBankName;
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value; }
        }
        private string _sCardTypeName;
        public string CardTypeName
        {
            get { return _sCardTypeName; }
            set { _sCardTypeName = value; }
        }
        private string _sPOSMachineName;
        public string POSMachineName
        {
            get { return _sPOSMachineName; }
            set { _sPOSMachineName = value; }
        }
        private string _sIsEMIName;
        public string IsEMIName
        {
            get { return _sIsEMIName; }
            set { _sIsEMIName = value; }
        }

        private string _sCardCategoryName;
        public string CardCategoryName
        {
            get { return _sCardCategoryName; }
            set { _sCardCategoryName = value; }
        }


        public string ProductSerialNo
        {
            get { return _sProductSerialNo; }
            set { _sProductSerialNo = value; }
        }
        public int SalesPromotionType
        {
            get { return _nSalesPromotionType; }
            set { _nSalesPromotionType = value; }
        }

        public void InsertCharge()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                cmd.CommandText = "INSERT INTO t_SalesInvoiceOtherInfo (InvoiceID,SPParcentage,FaltAmount,SPDiscount, InstallationCharge, " +
                    " FreightCharge, OtherCharge, MarkUpAmount, DiscountReasonID, PromotionType) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("SPParcentage", _SPParcentage);
                cmd.Parameters.AddWithValue("FaltAmount", _FaltAmount);
                cmd.Parameters.AddWithValue("SPDiscount", _SPDiscount);
                cmd.Parameters.AddWithValue("InstallationCharge", _InstallationCharge);
                cmd.Parameters.AddWithValue("FreightCharge", _FreightCharge);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);
                cmd.Parameters.AddWithValue("MarkUpAmount", _MarkUpAmount);
                if (_nDiscountReasonID != 0)
                {
                    cmd.Parameters.AddWithValue("DiscountReasonID", _nDiscountReasonID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("DiscountReasonID", null);
                }
                cmd.Parameters.AddWithValue("PromotionType", _nSalesPromotionType);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertPayMode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                cmd.CommandText = "INSERT INTO t_SalesInvoicePaymentMode (InvoiceID,PaymentModeID,Amount, " +
                " BankID,CardType, POSMachineID,IsEMI,NoOfInstallment,InstrumentNo,InstrumentDate,CardCategory,ApprovalNo) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("PaymentModeID", _nPaymentModeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_nBankID != -1)
                    cmd.Parameters.AddWithValue("BankID", _nBankID);
                else cmd.Parameters.AddWithValue("BankID", null);
                if (_nCardType != -1)
                    cmd.Parameters.AddWithValue("CardType", _nCardType);
                else cmd.Parameters.AddWithValue("CardType", null);
                if (_nPOSMachineID != -1)
                    cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                else cmd.Parameters.AddWithValue("POSMachineID", null);
                if (_nIsEMI != -1)
                    cmd.Parameters.AddWithValue("IsEMI", _nIsEMI);
                else cmd.Parameters.AddWithValue("IsEMI", null);
                if (_nNoOfInstallment != -1)
                    cmd.Parameters.AddWithValue("NoOfInstallment", _nNoOfInstallment);
                else cmd.Parameters.AddWithValue("NoOfInstallment", null);
                if (_InstrumentNo != "")
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                else cmd.Parameters.AddWithValue("InstrumentNo", null);

                if (_InstrumentDate != null)
                    cmd.Parameters.AddWithValue("InstrumentDate", Convert.ToDateTime(_InstrumentDate));
                else cmd.Parameters.AddWithValue("InstrumentDate", null);

                if (_nCardCategory != -1)
                    cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);
                else cmd.Parameters.AddWithValue("CardCategory", null);

                if (_sApprovalNo != "")
                    cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                else cmd.Parameters.AddWithValue("ApprovalNo", null);



                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertPayModeNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                cmd.CommandText = "INSERT INTO t_SalesInvoicePaymentModeNew (InvoiceID,ProductID,PaymentModeID,Amount, " +
                " BankID,CardType, POSMachineID,IsEMI,NoOfInstallment,InstrumentNo,InstrumentDate,CardCategory,ApprovalNo,ExtendedEMICharge,BankDiscount,SDApprovalNo) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("PaymentModeID", _nPaymentModeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("CardType", _nCardType);
                cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                cmd.Parameters.AddWithValue("IsEMI", _nIsEMI);
                cmd.Parameters.AddWithValue("NoOfInstallment", _nNoOfInstallment);
                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                cmd.Parameters.AddWithValue("InstrumentDate", Convert.ToDateTime(_InstrumentDate));
                cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("ExtendedEMICharge", _ExtendedEMICharge);
                cmd.Parameters.AddWithValue("BankDiscount", _BankDiscount);
                cmd.Parameters.AddWithValue("SDApprovalNo", _sSDApprovalNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshInvoiceCharge()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_SalesInvoiceOtherInfo  Where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _SPDiscount = Convert.ToDouble(reader["SPDiscount"].ToString());
                    _FaltAmount = Convert.ToDouble(reader["FaltAmount"].ToString());
                    _SPParcentage = Convert.ToDouble(reader["SPParcentage"].ToString());

                    _TotalDiscount = _FaltAmount + _SPParcentage;

                    _InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    _FreightCharge = Convert.ToDouble(reader["FreightCharge"].ToString());
                    _OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());
                    _MarkUpAmount = Convert.ToDouble(reader["MarkUpAmount"].ToString());

                    _TotalCharge = _InstallationCharge + _FreightCharge + _OtherCharge + _MarkUpAmount;


                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshSMSDiscoutn(string sInvoiceNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT sum(Amount) Amount FROM t_SalesInvoiceScratchCardInfo  Where InvoiceNo=? group by InvoiceNo";
            cmd.Parameters.AddWithValue("InvoiceNo", sInvoiceNo);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        _smsDiscount = Convert.ToDouble(reader["Amount"].ToString());
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshPaymentMode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_SalesInvoicePaymentMode  Where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (int.Parse(reader["PaymentModeID"].ToString()) == (int)Dictionary.PaymentMode.Cash)
                    {
                        _Cash = _Cash + Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else if (int.Parse(reader["PaymentModeID"].ToString()) == (int)Dictionary.PaymentMode.Credit_Card)
                    {
                        _Credit = _Credit + Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else if (int.Parse(reader["PaymentModeID"].ToString()) == (int)Dictionary.PaymentMode.Advance_Payment)
                    {
                        _AdvanceAdjust = _AdvanceAdjust + Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else
                    {
                        _Others = _Others + Convert.ToDouble(reader["Amount"].ToString());
                    }
                }
                _TotalAmount = _Cash + _Credit + _AdvanceAdjust + _Others;
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //public void RefreshCreditInfo()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = " Select * From (Select InvoiceID,PaymentModeID,Amount,a.BankID,Name,isnull (CardType,0) CardType, "+
        //                  "  CardTypeName=Case when CardType=1 then 'VISA' when CardType=2 then 'MASTER' "+
        //                  "  when CardType=3 then 'Brac POS Mechine' when CardType=4 then 'MTB POS Mechine' else 'Other' end, "+
        //                  "  isnull (PosMachineID,0) PosMachineID,AssetName, "+
        //                  "  isnull (a.IsEMI,0) as IsEMI,IsEMIName= Case when a.IsEMI=1 then 'Yes' else 'No' end , "+
        //                  "  isnull (NoofInstallment,0) as NoofInstallment,isnull(InstrumentNo,'') InstrumentNo, "+
        //                  "  isnull(CardCategory,0) CardCategory,CardCategoryName = Case when CardCategory=1 then 'DebitCard' "+
        //                  "  else 'CreditCard' end,isnull(ApprovalNo,'') ApprovalNo From t_SalesinvoicePaymentMode a,t_Bank b,t_ShowroomAsset c " +
        //                  "  where a.BankID=b.BankID and c.AssetID=PosMachineID and PaymentModeID=2 ) x where InvoiceID = ?";


        //    cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

        //    try
        //    {
        //        cmd.CommandText = sSql;

        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            _nPaymentModeID = (int)(reader["PaymentModeID"]);
        //            _Amount = Convert.ToDouble(reader["Amount"].ToString());
        //            _nBankID = (int)(reader["BankID"]);
        //            _sBankName = (string)reader["Name"];
        //            _nCardType = (int)(reader["CardType"]);
        //            _sCardTypeName = (string)reader["CardTypeName"];
        //            _nPOSMachineID = (int)(reader["POSMachineID"]);
        //            _sPOSMachineName = (string)reader["AssetName"];
        //            _nIsEMI = (int)(reader["IsEMI"]);
        //            _sIsEMIName = (string)reader["IsEMIName"];
        //            _nNoOfInstallment = (int)(reader["NoOfInstallment"]);
        //            _InstrumentNo = (string)reader["InstrumentNo"];
        //            _nCardCategory = (int)(reader["CardCategory"]);
        //            _sCardCategoryName = (string)reader["CardCategoryName"];
        //            _sApprovalNo = (string)reader["ApprovalNo"];

        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}


        public void GetSalesInvoiceCharge()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_SalesInvoiceOtherInfo  Where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _SPDiscount = Convert.ToDouble(reader["SPDiscount"].ToString());
                    _FaltAmount = Convert.ToDouble(reader["FaltAmount"].ToString());
                    _SPParcentage = Convert.ToDouble(reader["SPParcentage"].ToString());
                    _InstallationCharge = Convert.ToDouble(reader["InstallationCharge"].ToString());
                    _FreightCharge = Convert.ToDouble(reader["FreightCharge"].ToString());
                    _OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());
                    _MarkUpAmount = Convert.ToDouble(reader["MarkUpAmount"].ToString());
                    if (reader["DiscountReasonID"] != DBNull.Value)
                    {
                        _nDiscountReasonID = (int)reader["DiscountReasonID"];
                    }
                    else
                    {
                        _nDiscountReasonID = 0;
                    }
                    if (reader["PromotionType"] != DBNull.Value)
                    {
                        _nSalesPromotionType = (int)reader["PromotionType"];
                    }
                    else
                    {
                        _nSalesPromotionType = 0;
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertWarrantyCardNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_SalesInvoiceWarrantyCardNo (OutletID,InvoiceID,ProductID,WarrantyCardNo,ProductSerialNo,WarrantyParameterID,ExtendedWarrantyDescription,ExtendedWarrantyID) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("WarrantyCardNo", _WarrantyCardNo);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                cmd.Parameters.AddWithValue("WarrantyParameterID", _nWarrantyParameterID);
                try
                {
                    if (_sExtendedWarrantyDescription != null)
                    {
                        cmd.Parameters.AddWithValue("ExtendedWarrantyDescription", _sExtendedWarrantyDescription);
                    }
                    else
                    {
                        _sExtendedWarrantyDescription = "";
                    }
                }
                catch
                {
                    _sExtendedWarrantyDescription = "";
                }



                try
                {
                    if (_nExtendedWarrantyID != null)
                    {
                        cmd.Parameters.AddWithValue("ExtendedWarrantyID", _nExtendedWarrantyID);
                    }
                    else
                    {
                        _nExtendedWarrantyID = -1;
                    }
                }
                catch
                {
                    _nExtendedWarrantyID = -1;
                }


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckSalesInvoice(string sRefInvoiceID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_SalesInvoice  Where RefInvoiceID=?";
            cmd.Parameters.AddWithValue("RefInvoiceID", sRefInvoiceID);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }
        public void GetInvoicNo(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_SalesInvoice  Where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckWarrantyCard(string sWarrantyCardNo)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesInvoiceWarrantyCardNo Where WarrantyCardNo=?";
            cmd.Parameters.AddWithValue("WarrantyCardNo", sWarrantyCardNo);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }
        public string GetSalesInvoiceNo(int nInvoiceID)
        {
            string sInvoiceNo = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT InvoiceNo FROM t_SalesInvoice  Where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sInvoiceNo = (string)reader["InvoiceNo"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sInvoiceNo;
        }
        public bool CheckInvoiceByDiscountReason(long nInvoiceID, int nDiscountReasonID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesInvoiceOtherInfo Where InvoiceID=" + nInvoiceID + " and DiscountReasonID=" + nDiscountReasonID + "";

            int nCount = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddEMIData()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_EMIManagement";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_EMIManagement (ID, BankID, InvoiceID, Amount, Status, CreateUserID, CreateDate, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteEMIData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_EMIManagement WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeletePayment(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_SalesInvoicePaymentMode WHERE [InvoiceID] = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void MaxProjectionID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT isnull(MAX([ProjectionID]),0)+1 as ProjectionID FROM t_OutletDailyProjection";
            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProjectionID = Convert.ToInt32(reader["ProjectionID"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void MaxProjectionIDRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT isnull(MAX([ProjectionID]),0)+1 as ProjectionID FROM t_OutletDailyProjection where WarehouseID=" + Utility.WarehouseID + "";
            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProjectionID = Convert.ToInt32(reader["ProjectionID"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertProjection()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_OutletDailyProjection (ProjectionID,WarehouseID,ProjectionDate, " +
                                  "DataType,DataID,Projection,Actual,CreateDate,CreateUserID,UpdateDate,UpdateUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProjectionID", _nProjectionID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProjectionDate", _dProjectionDate);
                cmd.Parameters.AddWithValue("DataType", _nDataType);
                cmd.Parameters.AddWithValue("DataID", _nDataID);
                cmd.Parameters.AddWithValue("Projection", _Projection);
                cmd.Parameters.AddWithValue("Actual", _Actual);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteProjectionData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_OutletDailyProjection WHERE [ProjectionDate]=? and [WarehouseID] = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProjectionDate", _dProjectionDate);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int GetProjectionID(DateTime dtDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int nProjectionID = 0;
            string sSql = "Select ProjectionID From t_OutletDailyProjection where  " +
                          "ProjectionDate='" + dtDate + "' group by ProjectionID";
            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nProjectionID = Convert.ToInt32(reader["ProjectionID"].ToString());
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nProjectionID;
        }

        public int GetProjectionIDRT(DateTime dtDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int nProjectionID = 0;
            string sSql = "Select ProjectionID From t_OutletDailyProjection where  " +
                          "ProjectionDate='" + dtDate + "' and WarehouseID=" + Utility.WarehouseID + " group by ProjectionID";
            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nProjectionID = Convert.ToInt32(reader["ProjectionID"].ToString());
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nProjectionID;
        }
    }
    public class RetailSalesInvoices : CollectionBase
    {
        public RetailSalesInvoice this[int i]
        {
            get { return (RetailSalesInvoice)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(RetailSalesInvoice oRetailSalesInvoice)
        {
            InnerList.Add(oRetailSalesInvoice);
        }
        public void GetSaleInvoicePaymentMode(int nInvoiceID)//Hakim
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_SalesInvoicePaymentMode  Where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice oRetailSalesInvoice = new RetailSalesInvoice();

                    oRetailSalesInvoice.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());

                    oRetailSalesInvoice.PaymentModeID = int.Parse(reader["PaymentModeID"].ToString());
                    oRetailSalesInvoice.Amount = Convert.ToDouble(reader["Amount"].ToString());

                    if (reader["BankID"] != DBNull.Value)
                        oRetailSalesInvoice.BankID = int.Parse(reader["BankID"].ToString());
                    else oRetailSalesInvoice.BankID = -1;

                    if (reader["CardType"] != DBNull.Value)
                        oRetailSalesInvoice.CardType = int.Parse(reader["CardType"].ToString());
                    else oRetailSalesInvoice.CardType = -1;

                    if (reader["POSMachineID"] != DBNull.Value)
                        oRetailSalesInvoice.POSMachineID = int.Parse(reader["POSMachineID"].ToString());
                    else oRetailSalesInvoice.POSMachineID = -1;

                    if (reader["IsEMI"] != DBNull.Value)
                        oRetailSalesInvoice.IsEMI = int.Parse(reader["IsEMI"].ToString());
                    else oRetailSalesInvoice.IsEMI = -1;

                    if (reader["NoOfInstallment"] != DBNull.Value)
                        oRetailSalesInvoice.NoOfInstallment = int.Parse(reader["NoOfInstallment"].ToString());
                    else oRetailSalesInvoice.NoOfInstallment = -1;

                    if (reader["InstrumentNo"] != DBNull.Value)
                        oRetailSalesInvoice.InstrumentNo = reader["InstrumentNo"].ToString();
                    else oRetailSalesInvoice.InstrumentNo = "";

                    if (reader["InstrumentDate"] != DBNull.Value)
                        oRetailSalesInvoice.InstrumentDate = (object)reader["InstrumentDate"];
                    else oRetailSalesInvoice.InstrumentDate = null;

                    if (reader["CardCategory"] != DBNull.Value)
                        oRetailSalesInvoice.CardCategory = int.Parse(reader["CardCategory"].ToString());
                    else oRetailSalesInvoice.CardCategory = -1;

                    if (reader["ApprovalNo"] != DBNull.Value)
                        oRetailSalesInvoice.ApprovalNo = reader["ApprovalNo"].ToString();
                    else oRetailSalesInvoice.ApprovalNo = "";



                    InnerList.Add(oRetailSalesInvoice);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSaleInvoicePaymentModeNew(int nInvoiceID)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT * FROM t_SalesInvoicePaymentModeNew Where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice oRetailSalesInvoice = new RetailSalesInvoice();

                    oRetailSalesInvoice.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    oRetailSalesInvoice.PaymentModeID = int.Parse(reader["PaymentModeID"].ToString());
                    oRetailSalesInvoice.ProductID = int.Parse(reader["ProductID"].ToString());
                    oRetailSalesInvoice.Amount = Convert.ToDouble(reader["Amount"].ToString());

                    if (reader["BankID"] != DBNull.Value)
                        oRetailSalesInvoice.BankID = int.Parse(reader["BankID"].ToString());
                    else oRetailSalesInvoice.BankID = -1;

                    if (reader["CardType"] != DBNull.Value)
                        oRetailSalesInvoice.CardType = int.Parse(reader["CardType"].ToString());
                    else oRetailSalesInvoice.CardType = -1;

                    if (reader["POSMachineID"] != DBNull.Value)
                        oRetailSalesInvoice.POSMachineID = int.Parse(reader["POSMachineID"].ToString());
                    else oRetailSalesInvoice.POSMachineID = -1;

                    if (reader["IsEMI"] != DBNull.Value)
                        oRetailSalesInvoice.IsEMI = int.Parse(reader["IsEMI"].ToString());
                    else oRetailSalesInvoice.IsEMI = -1;

                    if (reader["NoOfInstallment"] != DBNull.Value)
                        oRetailSalesInvoice.NoOfInstallment = int.Parse(reader["NoOfInstallment"].ToString());
                    else oRetailSalesInvoice.NoOfInstallment = -1;

                    if (reader["InstrumentNo"] != DBNull.Value)
                        oRetailSalesInvoice.InstrumentNo = reader["InstrumentNo"].ToString();
                    else oRetailSalesInvoice.InstrumentNo = "";

                    if (reader["InstrumentDate"] != DBNull.Value)
                        oRetailSalesInvoice.InstrumentDate = (object)reader["InstrumentDate"];
                    else oRetailSalesInvoice.InstrumentDate = null;

                    if (reader["CardCategory"] != DBNull.Value)
                        oRetailSalesInvoice.CardCategory = int.Parse(reader["CardCategory"].ToString());
                    else oRetailSalesInvoice.CardCategory = -1;

                    if (reader["ApprovalNo"] != DBNull.Value)
                        oRetailSalesInvoice.ApprovalNo = reader["ApprovalNo"].ToString();
                    else oRetailSalesInvoice.ApprovalNo = "";

                    if (reader["ExtendedEMICharge"] != DBNull.Value)
                        oRetailSalesInvoice.ExtendedEMICharge = Convert.ToDouble(reader["ExtendedEMICharge"].ToString());
                    else oRetailSalesInvoice.ExtendedEMICharge = 0;

                    if (reader["BankDiscount"] != DBNull.Value)
                        oRetailSalesInvoice.BankDiscount = Convert.ToDouble(reader["BankDiscount"].ToString());
                    else oRetailSalesInvoice.BankDiscount = -1;

                    if (reader["SDApprovalNo"] != DBNull.Value)
                        oRetailSalesInvoice.SDApprovalNo = (reader["SDApprovalNo"].ToString());
                    else oRetailSalesInvoice.SDApprovalNo = "";

                    InnerList.Add(oRetailSalesInvoice);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetRetailInvoiceDiscountCharge(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.DiscountTypeID,DiscountTypeName,Type,sum(Amount) Amount " +
                                    "From t_SalesInvoiceDiscount a,t_SalesInvoiceDiscountType b " +
                                    "where a.DiscountTypeID = b.DiscountTypeID and InvoiceID = " + nInvoiceID + " " +
                                    "and Type in (0,1)  " + //and Amount<> 0 
                                    "group by a.DiscountTypeID,DiscountTypeName,Type";


            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice oRetailSalesInvoice = new RetailSalesInvoice();
                    oRetailSalesInvoice.DiscountTypeID = int.Parse(reader["DiscountTypeID"].ToString());
                    oRetailSalesInvoice.DiscountTypeName = reader["DiscountTypeName"].ToString();
                    oRetailSalesInvoice.Type = int.Parse(reader["Type"].ToString());
                    oRetailSalesInvoice.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    InnerList.Add(oRetailSalesInvoice);
                }
                
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetSalesInvoiceWarranty(int nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesInvoiceWarrantyCardNo Where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RetailSalesInvoice oRetailSalesInvoice = new RetailSalesInvoice();


                    oRetailSalesInvoice.OutletID = int.Parse(reader["OutletID"].ToString());
                    oRetailSalesInvoice.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    oRetailSalesInvoice.ProductID = int.Parse(reader["ProductID"].ToString());
                    oRetailSalesInvoice.WarrantyCardNo = reader["WarrantyCardNo"].ToString();
                    oRetailSalesInvoice.ProductSerialNo = reader["ProductSerialNo"].ToString();
                    oRetailSalesInvoice.WarrantyParameterID = int.Parse(reader["WarrantyParameterID"].ToString());

                    if (reader["ExtendedWarrantyDescription"] != DBNull.Value)
                        oRetailSalesInvoice.ExtendedWarrantyDescription = (reader["ExtendedWarrantyDescription"].ToString());
                    else oRetailSalesInvoice.ExtendedWarrantyDescription = "";



                    if (reader["ExtendedWarrantyID"] != DBNull.Value)
                        oRetailSalesInvoice.ExtendedWarrantyID = Convert.ToInt32(reader["ExtendedWarrantyID"].ToString());
                    else oRetailSalesInvoice.ExtendedWarrantyID = -1;



                    InnerList.Add(oRetailSalesInvoice);
                }
                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPaymentModeForOldData(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select InvoiceID,PaymentModeID,sum(Amount) Amount,isnull(BankID,-1) BankID, " +
                        "isnull(CardType, -1) CardType,isnull(POSMachineID, -1) POSMachineID, " +
                        "isnull(IsEMI, -1) IsEMI,isnull(NoOfInstallment, -1) NoOfInstallment, " +
                        "isnull(InstrumentNo, '') InstrumentNo, " +
                        "InstrumentDate,isnull(CardCategory, -1) CardCategory, " +
                        "isnull(ApprovalNo, '') ApprovalNo,isnull(sum(ExtendedEMICharge), 0) ExtendedEMICharge, " +
                        "isnull(sum(BankDiscount), 0) BankDiscount " +
                        "From t_SalesInvoicePaymentModeNew where InvoiceID = " + nInvoiceID + " " +
                        "group by InvoiceID,PaymentModeID,BankID, " +
                        "CardType,POSMachineID,IsEMI,NoOfInstallment,InstrumentNo, " +
                        "InstrumentDate,CardCategory,ApprovalNo";

            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RetailSalesInvoice oRetailSalesInvoice = new RetailSalesInvoice();
                    oRetailSalesInvoice.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());

                    oRetailSalesInvoice.PaymentModeID = int.Parse(reader["PaymentModeID"].ToString());
                    oRetailSalesInvoice.Amount = Convert.ToDouble(reader["Amount"].ToString());

                    if (reader["BankID"] != DBNull.Value)
                        oRetailSalesInvoice.BankID = int.Parse(reader["BankID"].ToString());
                    else oRetailSalesInvoice.BankID = -1;

                    if (reader["CardType"] != DBNull.Value)
                        oRetailSalesInvoice.CardType = int.Parse(reader["CardType"].ToString());
                    else oRetailSalesInvoice.CardType = -1;

                    if (reader["POSMachineID"] != DBNull.Value)
                        oRetailSalesInvoice.POSMachineID = int.Parse(reader["POSMachineID"].ToString());
                    else oRetailSalesInvoice.POSMachineID = -1;

                    if (reader["IsEMI"] != DBNull.Value)
                        oRetailSalesInvoice.IsEMI = int.Parse(reader["IsEMI"].ToString());
                    else oRetailSalesInvoice.IsEMI = -1;

                    if (reader["NoOfInstallment"] != DBNull.Value)
                        oRetailSalesInvoice.NoOfInstallment = int.Parse(reader["NoOfInstallment"].ToString());
                    else oRetailSalesInvoice.NoOfInstallment = -1;

                    if (reader["InstrumentNo"] != DBNull.Value)
                        oRetailSalesInvoice.InstrumentNo = reader["InstrumentNo"].ToString();
                    else oRetailSalesInvoice.InstrumentNo = "";

                    if (reader["InstrumentDate"] != DBNull.Value)
                        oRetailSalesInvoice.InstrumentDate = (object)reader["InstrumentDate"];
                    else oRetailSalesInvoice.InstrumentDate = null;

                    if (reader["CardCategory"] != DBNull.Value)
                        oRetailSalesInvoice.CardCategory = int.Parse(reader["CardCategory"].ToString());
                    else oRetailSalesInvoice.CardCategory = -1;

                    if (reader["ApprovalNo"] != DBNull.Value)
                        oRetailSalesInvoice.ApprovalNo = reader["ApprovalNo"].ToString();
                    else oRetailSalesInvoice.ApprovalNo = "";
                    oRetailSalesInvoice.ExtendedEMICharge = Convert.ToDouble(reader["ExtendedEMICharge"].ToString());
                    oRetailSalesInvoice.BankDiscount = Convert.ToDouble(reader["BankDiscount"].ToString());


                    InnerList.Add(oRetailSalesInvoice);
                }
                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshCreditInfo(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select * From (Select InvoiceID,PaymentModeID,Amount,a.BankID,Name,isnull (CardType,0) CardType, " +
                          "  CardTypeName=Case when CardType=1 then 'VISA' when CardType=2 then 'MASTER' " +
                          "  when CardType=3 then 'Brac POS Mechine' when CardType=4 then 'MTB POS Mechine' else 'Other' end, " +
                          "  isnull (PosMachineID,0) PosMachineID,AssetName, " +
                          "  isnull (a.IsEMI,0) as IsEMI,IsEMIName= Case when a.IsEMI=1 then 'Yes' else 'No' end , " +
                          "  isnull (NoofInstallment,0) as NoofInstallment,isnull(InstrumentNo,'') InstrumentNo, " +
                          "  isnull(CardCategory,0) CardCategory,CardCategoryName = Case when CardCategory=1 then 'DebitCard' " +
                          "  else 'CreditCard' end,isnull(ApprovalNo,'') ApprovalNo From t_SalesinvoicePaymentMode a,t_Bank b,t_ShowroomAsset c " +
                          "  where a.BankID=b.BankID and c.AssetID=PosMachineID and PaymentModeID=2 ) x where InvoiceID = ?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RetailSalesInvoice oRetailSalesInvoice = new RetailSalesInvoice();



                    oRetailSalesInvoice.InvoiceID = Convert.ToInt64(reader["InvoiceID"].ToString());
                    oRetailSalesInvoice.PaymentModeID = int.Parse(reader["PaymentModeID"].ToString());
                    oRetailSalesInvoice.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oRetailSalesInvoice.BankID = int.Parse(reader["BankID"].ToString());
                    oRetailSalesInvoice.BankName = reader["Name"].ToString();
                    oRetailSalesInvoice.CardType = int.Parse(reader["CardType"].ToString());
                    oRetailSalesInvoice.CardTypeName = reader["CardTypeName"].ToString();
                    oRetailSalesInvoice.POSMachineID = int.Parse(reader["PosMachineID"].ToString());
                    oRetailSalesInvoice.POSMachineName = reader["AssetName"].ToString();
                    oRetailSalesInvoice.IsEMI = int.Parse(reader["IsEMI"].ToString());
                    oRetailSalesInvoice.IsEMIName = reader["IsEMIName"].ToString();
                    oRetailSalesInvoice.NoOfInstallment = int.Parse(reader["NoofInstallment"].ToString());
                    oRetailSalesInvoice.CardCategory = int.Parse(reader["CardCategory"].ToString());
                    oRetailSalesInvoice.CardCategoryName = reader["CardCategoryName"].ToString();
                    oRetailSalesInvoice.ApprovalNo = reader["ApprovalNo"].ToString();



                    InnerList.Add(oRetailSalesInvoice);
                }
                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void TgtVsAchExecutiveWise(DateTime FirstDateOfThisMonth, DateTime dtGetDate, DateTime FirstDayOfLastMonth, DateTime TodayOfLastMonth, DateTime FirstDateOfLYThisMonth, DateTime TodayOfLYThisMonth, int nTGTYear, int nTGTMonth)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select EmployeeID,EmployeeName,SalesCategory,CMTargetVal,CMSalesQty,CMSalesVal,isnull((CMSalesVal/nullif(CMTargetVal,0)*100),0) as Achievement, " +
                    "LMTDSalesQty,LMTDSalesVal,isnull(((CMSalesVal-LMTDSalesVal)/nullif(LMTDSalesVal,0)*100),0) as GrowthLM,LYSalesQty,LYSalesVal,isnull(((CMSalesVal-LYSalesVal)/nullif(LYSalesVal,0)*100),0) as GrowthLYTM from  " +
                    "(Select EmployeeID,EmployeeName,SalesCategory,Sum(CMTargetVal) CMTargetVal, " +
                    "Sum(CMSalesQty) CMSalesQty,Sum(CMSalesVal) CMSalesVal,Sum(LMTDSalesQty) LMTDSalesQty,Sum(LMTDSalesVal) LMTDSalesVal, " +
                    "Sum(LYSalesQty) LYSalesQty,Sum(LYSalesVal) LYSalesVal From  " +
                    "(Select TYear,TMonth,EmployeeID,EmployeeName, " +
                    "case PGName when 'Electronics' then 'Electronics' else 'Appliances' end as SalesCategory, " +
                    "CMSalesQty,CMSalesVal,LYSalesQty,LYSalesVal,LMTDSalesQty,LMTDSalesVal,CMTargetVal " +
                    "from " +
                    "(select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,SalesQty CMSalesQty,GrossSales+OC-Discount-VAT CMSalesVal,0 LYSalesQty,0 LYSalesVal,0 LMTDSalesQty,0 LMTDSalesVal,0 CMTargetVal from " +
                    "(Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales, " +
                    "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT " +
                    "From " +
                    "(Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                    "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT " +
                    "from " +
                    "(Select WarehouseID,SalesPersonID,a.InvoiceID,TYear,TMonth,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (Discount/GrossPrice * ( unitprice * Quantity)) as Discount, " +
                    "(OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                    "from " +
                    "(select WarehouseID,SalesPersonID,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate  " +
                    "between '" + FirstDateOfThisMonth + "' and '" + dtGetDate + "' and invoicedate <='" + dtGetDate + "'  " +
                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and warehouseid=(Select WarehouseID From t_Thissystem) " +
                    ")as a " +
                    "left outer join " +
                    "(select sa.InvoiceID, Sum(quantity*UnitPrice) as GrossPrice " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate   " +
                    "between '" + FirstDateOfThisMonth + "' and '" + dtGetDate + "' and invoicedate <='" + dtGetDate + "'  " +
                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and warehouseid=(Select WarehouseID From t_Thissystem) " +
                    "group by sa.InvoiceID,Discount,OtherCharge " +
                    ") as b on a.invoiceid = b.invoiceid " +
                    ") as final " +
                    "Group By WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID " +
                    "Union all " +
                    "Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales, " +
                    "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT " +
                    "from " +
                    "(Select WarehouseID,SalesPersonID,a.InvoiceID,TYear,TMonth,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(Discount/GrossPrice * ( unitprice * Quantity)) as Discount, " +
                    "(OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC, " +
                    "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                    "from " +
                    "(select WarehouseID,SalesPersonID,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate  " +
                    "between '" + FirstDateOfThisMonth + "' and '" + dtGetDate + "'  and invoicedate <='" + dtGetDate + "'  " +
                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and warehouseid=(Select WarehouseID From t_Thissystem) " +
                    ")as a " +
                    "left outer join " +
                    "(select sa.InvoiceID,Sum(quantity*UnitPrice) as GrossPrice " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate  " +
                    "between '" + FirstDateOfThisMonth + "' and '" + dtGetDate + "'  and invoicedate <='" + dtGetDate + "'  " +
                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and warehouseid=(Select WarehouseID From t_Thissystem) " +
                    "group by sa.InvoiceID,Discount,OtherCharge " +
                    ") as b on a.invoiceid = b.invoiceid " +
                    ") as final " +
                    "Group By WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID " +
                    ")as FinalQuery " +
                    "Group by WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID) CMSales " +
                    "union all " +
                    "select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,0 CMSalesQty,0 CMSalesVal,0 LYSalesQty,0 LYSalesVal,SalesQty LMTDSalesQty,GrossSales+OC-Discount-VAT LMTDSalesVal,0 CMTargetVal from " +
                    "(Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales, " +
                    "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT " +
                    "From " +
                    "(Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                    "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT " +
                    "from " +
                    "(Select WarehouseID,SalesPersonID,a.InvoiceID,TYear,TMonth,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (Discount/GrossPrice * ( unitprice * Quantity)) as Discount, " +
                    "(OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                    "from " +
                    "(select WarehouseID,SalesPersonID,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate  " +
                    "between '" + FirstDayOfLastMonth + "' and '" + TodayOfLastMonth + "' and invoicedate <='" + TodayOfLastMonth + "' " +
                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and warehouseid=(Select WarehouseID From t_Thissystem) " +
                    ")as a " +
                    "left outer join " +
                    "(select sa.InvoiceID, Sum(quantity*UnitPrice) as GrossPrice " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and  " +
                    "invoicedate between '" + FirstDayOfLastMonth + "' and '" + TodayOfLastMonth + "' and invoicedate <='" + TodayOfLastMonth + "' " +
                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and warehouseid=(Select WarehouseID From t_Thissystem) " +
                    "group by sa.InvoiceID,Discount,OtherCharge " +
                    ") as b on a.invoiceid = b.invoiceid " +
                    ") as final " +
                    "Group By WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID " +
                    "Union all " +
                    "Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales, " +
                    "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT " +
                    "from " +
                    "(Select WarehouseID,SalesPersonID,a.InvoiceID,TYear,TMonth,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(Discount/GrossPrice * ( unitprice * Quantity)) as Discount, " +
                    "(OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC, " +
                    "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                    "from " +
                    "(select WarehouseID,SalesPersonID,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate  " +
                    "between '" + FirstDayOfLastMonth + "' and '" + TodayOfLastMonth + "' and invoicedate <='" + TodayOfLastMonth + "' " +
                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and warehouseid=(Select WarehouseID From t_Thissystem) " +
                    ")as a " +
                    "left outer join " +
                    "(select sa.InvoiceID,Sum(quantity*UnitPrice) as GrossPrice " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate  " +
                    "between '" + FirstDayOfLastMonth + "' and '" + TodayOfLastMonth + "' and invoicedate <='" + TodayOfLastMonth + "' " +
                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and warehouseid=(Select WarehouseID From t_Thissystem) " +
                    "group by sa.InvoiceID,Discount,OtherCharge " +
                    ") as b on a.invoiceid = b.invoiceid " +
                    ") as final " +
                    "Group By WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID " +
                    ")as FinalQuery " +
                    "Group by WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID) LMTDSales " +
                    "union all " +
                    "select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,0 CMSalesQty,0 CMSalesVal,SalesQty LYSalesQty,GrossSales+OC-Discount-VAT LYSalesVal,0 LMTDSalesQty,0 LMTDSalesVal,0 CMTargetVal from " +
                    "(Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales, " +
                    "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT " +
                    "From " +
                    "(Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                    "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT " +
                    "from " +
                    "(Select WarehouseID,SalesPersonID,a.InvoiceID,TYear,TMonth,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (Discount/GrossPrice * ( unitprice * Quantity)) as Discount, " +
                    "(OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                    "from " +
                    "(select WarehouseID,SalesPersonID,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfLYThisMonth + "' and '" + TodayOfLYThisMonth + "' and invoicedate < '" + TodayOfLYThisMonth + "' " +
                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and warehouseid=(Select WarehouseID From t_Thissystem) " +
                    ")as a " +
                    "left outer join " +
                    "(select sa.InvoiceID, Sum(quantity*UnitPrice) as GrossPrice " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfLYThisMonth + "' and '" + TodayOfLYThisMonth + "' and invoicedate < '" + TodayOfLYThisMonth + "' " +
                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and warehouseid=(Select WarehouseID From t_Thissystem) " +
                    "group by sa.InvoiceID,Discount,OtherCharge " +
                    ") as b on a.invoiceid = b.invoiceid " +
                    ") as final " +
                    "Group By WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID " +
                    "Union all " +
                    "Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales, " +
                    "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT " +
                    "from " +
                    "(Select WarehouseID,SalesPersonID,a.InvoiceID,TYear,TMonth,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(Discount/GrossPrice * ( unitprice * Quantity)) as Discount, " +
                    "(OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC, " +
                    "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                    "from " +
                    "(select WarehouseID,SalesPersonID,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfLYThisMonth + "' and '" + TodayOfLYThisMonth + "' and invoicedate < '" + TodayOfLYThisMonth + "' " +
                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and warehouseid=(Select WarehouseID From t_Thissystem) " +
                    ")as a " +
                    "left outer join " +
                    "(select sa.InvoiceID,Sum(quantity*UnitPrice) as GrossPrice " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfLYThisMonth + "' and '" + TodayOfLYThisMonth + "' and invoicedate < '" + TodayOfLYThisMonth + "' " +
                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and warehouseid=(Select WarehouseID From t_Thissystem) " +
                    "group by sa.InvoiceID,Discount,OtherCharge " +
                    ") as b on a.invoiceid = b.invoiceid " +
                    ") as final " +
                    "Group By WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID " +
                    ")as FinalQuery " +
                    "Group by WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID) LYCMSales " +
                    ") as sales " +
                    "inner join " +
                    "(select * from v_customerdetails  " +
                    ") as cd on sales.customerid = cd.customerid " +
                    "inner join " +
                    "(Select * from v_productdetails  " +
                    ") as p on sales.productid = p.productid " +
                    "inner join t_employee e on(Sales.salespersonid=e.employeeid) " +
                    "Union All " +
                    "Select TYear,TMonth,SalesPersonID,EmployeeName,Category,0 CMSalesQty,0 CMSalesVal, " +
                    "0 LYSalesQty,0 LYSalesVal,0 LMTDSalesQty,0 LMTDSalesVal,sum(TargetAmount) as  Target  " +
                    "from dbo.t_PlanExecutiveWeekTarget a,t_Employee b where a.Salespersonid=b.EmployeeID " +
                    "and TYear=" + nTGTYear + " and TMonth=" + nTGTMonth + " group by TYear,TMonth,SalesPersonid,EmployeeName,Category) Total " +
                    "group by EmployeeID,EmployeeName,SalesCategory) xx";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();
                    _oDailySalesReport.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    _oDailySalesReport.EmployeeName = reader["EmployeeName"].ToString();
                    _oDailySalesReport.SalesCategory = reader["SalesCategory"].ToString();
                    _oDailySalesReport.CMSalesQty = Convert.ToInt32(reader["CMSalesQty"].ToString());
                    _oDailySalesReport.CMSalesValue = Convert.ToDouble(reader["CMSalesVal"].ToString());
                    _oDailySalesReport.Achievement = Convert.ToDouble(reader["Achievement"].ToString());
                    _oDailySalesReport.LYSalesQty = Convert.ToInt32(reader["LYSalesQty"].ToString());
                    _oDailySalesReport.LYSalesValue = Convert.ToDouble(reader["LYSalesVal"].ToString());
                    _oDailySalesReport.GrowthLM = Convert.ToDouble(reader["GrowthLM"].ToString());
                    _oDailySalesReport.LMTDSalesQty = Convert.ToInt32(reader["LMTDSalesQty"].ToString());
                    _oDailySalesReport.LMTDSalesValue = Convert.ToDouble(reader["LMTDSalesVal"].ToString());
                    _oDailySalesReport.GrowthLYTM = Convert.ToDouble(reader["GrowthLYTM"].ToString());
                    _oDailySalesReport.Target = Convert.ToDouble(reader["CMTargetVal"].ToString());
                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void TgtVsAchExecutiveWiseRT(DateTime FirstDateOfThisMonth, DateTime dtGetDate, DateTime FirstDayOfLastMonth, DateTime TodayOfLastMonth, DateTime FirstDateOfLYThisMonth, DateTime TodayOfLYThisMonth, int nTGTYear, int nTGTMonth)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql =String.Format(@"Select EmployeeID,EmployeeName,SalesCategory,CMTargetVal,CMSalesQty,CMSalesVal,isnull((CMSalesVal/nullif(CMTargetVal,0)*100),0) as Achievement, LMTDSalesQty,LMTDSalesVal,isnull(((CMSalesVal-LMTDSalesVal)/nullif(LMTDSalesVal,0)*100),0) as GrowthLM,LYSalesQty,LYSalesVal,isnull(((CMSalesVal-LYSalesVal)/nullif(LYSalesVal,0)*100),0) as GrowthLYTM from  (Select EmployeeID,EmployeeName,SalesCategory,Sum(CMTargetVal) CMTargetVal, Sum(CMSalesQty) CMSalesQty,Sum(CMSalesVal) CMSalesVal,Sum(LMTDSalesQty) LMTDSalesQty,Sum(LMTDSalesVal) LMTDSalesVal, Sum(LYSalesQty) LYSalesQty,Sum(LYSalesVal) LYSalesVal From  (Select TYear,TMonth,EmployeeID,EmployeeName, case PGName when 'Electronics' then 'Electronics' else 'Appliances' end as SalesCategory, CMSalesQty,CMSalesVal,LYSalesQty,LYSalesVal,LMTDSalesQty,LMTDSalesVal,CMTargetVal from (select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,SalesQty CMSalesQty,GrossSales+OC-Discount-VAT CMSalesVal,0 LYSalesQty,0 LYSalesVal,0 LMTDSalesQty,0 LMTDSalesVal,0 CMTargetVal from (Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales, isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT From (Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT from (Select WarehouseID,SalesPersonID,a.InvoiceID,TYear,TMonth,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (Discount/GrossPrice * ( unitprice * Quantity)) as Discount, (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT from (select WarehouseID,SalesPersonID,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={8} and invoicedate  between '{0}' and '{1}' and invoicedate <='{1}'  and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and warehouseid={8} )as a left outer join (select sa.InvoiceID, Sum(quantity*UnitPrice) as GrossPrice from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={8} and invoicedate   between '{0}' and '{1}' and invoicedate <='{1}'  and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and warehouseid={8} group by sa.InvoiceID,Discount,OtherCharge ) as b on a.invoiceid = b.invoiceid ) as final Group By WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID Union all Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales, 0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT from (Select WarehouseID,SalesPersonID,a.InvoiceID,TYear,TMonth,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(Discount/GrossPrice * ( unitprice * Quantity)) as Discount, (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC, (Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT from (select WarehouseID,SalesPersonID,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={8} and invoicedate  between '{0}' and '{1}'  and invoicedate <='{1}'  and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and warehouseid={8} )as a left outer join (select sa.InvoiceID,Sum(quantity*UnitPrice) as GrossPrice from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={8} and invoicedate  between '{0}' and '{1}'  and invoicedate <='{1}'  and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and warehouseid={8} group by sa.InvoiceID,Discount,OtherCharge ) as b on a.invoiceid = b.invoiceid ) as final Group By WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID )as FinalQuery Group by WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID) CMSales union all select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,0 CMSalesQty,0 CMSalesVal,0 LYSalesQty,0 LYSalesVal,SalesQty LMTDSalesQty,GrossSales+OC-Discount-VAT LMTDSalesVal,0 CMTargetVal from (Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales, isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT From (Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT from (Select WarehouseID,SalesPersonID,a.InvoiceID,TYear,TMonth,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (Discount/GrossPrice * ( unitprice * Quantity)) as Discount, (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT from (select WarehouseID,SalesPersonID,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={8} and invoicedate  between '{2}' and '{3}' and invoicedate <='{3}' and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and warehouseid={8} )as a left outer join (select sa.InvoiceID, Sum(quantity*UnitPrice) as GrossPrice from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={8} and  invoicedate between '{2}' and '{3}' and invoicedate <='{3}' and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and warehouseid={8} group by sa.InvoiceID,Discount,OtherCharge ) as b on a.invoiceid = b.invoiceid ) as final Group By WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID Union all Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales, 0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT from (Select WarehouseID,SalesPersonID,a.InvoiceID,TYear,TMonth,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(Discount/GrossPrice * ( unitprice * Quantity)) as Discount, (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC, (Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT from (select WarehouseID,SalesPersonID,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={8} and invoicedate  between '{2}' and '{3}' and invoicedate <='{3}' and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and warehouseid={8} )as a left outer join (select sa.InvoiceID,Sum(quantity*UnitPrice) as GrossPrice from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={8} and invoicedate  between '{2}' and '{3}' and invoicedate <='{3}' and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and warehouseid={8} group by sa.InvoiceID,Discount,OtherCharge ) as b on a.invoiceid = b.invoiceid ) as final Group By WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID )as FinalQuery Group by WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID) LMTDSales union all select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,0 CMSalesQty,0 CMSalesVal,SalesQty LYSalesQty,GrossSales+OC-Discount-VAT LYSalesVal,0 LMTDSalesQty,0 LMTDSalesVal,0 CMTargetVal from (Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales, isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT From (Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT from (Select WarehouseID,SalesPersonID,a.InvoiceID,TYear,TMonth,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (Discount/GrossPrice * ( unitprice * Quantity)) as Discount, (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT from (select WarehouseID,SalesPersonID,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={8} and invoicedate between '{4}' and '{5}' and invoicedate < '{5}' and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and warehouseid={8} )as a left outer join (select sa.InvoiceID, Sum(quantity*UnitPrice) as GrossPrice from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={8} and invoicedate between '{4}' and '{5}' and invoicedate < '{5}' and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and warehouseid={8} group by sa.InvoiceID,Discount,OtherCharge ) as b on a.invoiceid = b.invoiceid ) as final Group By WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID Union all Select WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales, 0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT from (Select WarehouseID,SalesPersonID,a.InvoiceID,TYear,TMonth,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(Discount/GrossPrice * ( unitprice * Quantity)) as Discount, (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC, (Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT from (select WarehouseID,SalesPersonID,sa.InvoiceID,year(invoicedate) as TYear,month(invoicedate) as TMonth,CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={8} and invoicedate between '{4}' and '{5}' and invoicedate < '{5}' and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and warehouseid={8} )as a left outer join (select sa.InvoiceID,Sum(quantity*UnitPrice) as GrossPrice from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={8} and invoicedate between '{4}' and '{5}' and invoicedate < '{5}' and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and warehouseid={8} group by sa.InvoiceID,Discount,OtherCharge ) as b on a.invoiceid = b.invoiceid ) as final Group By WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID )as FinalQuery Group by WarehouseID,SalesPersonID,Customerid,TYear,TMonth,ProductID) LYCMSales ) as sales inner join (select * from v_customerdetails  ) as cd on sales.customerid = cd.customerid inner join (Select * from v_productdetails  ) as p on sales.productid = p.productid inner join t_employee e on(Sales.salespersonid=e.employeeid) Union All Select TYear,TMonth,SalesPersonID,EmployeeName,Category,0 CMSalesQty,0 CMSalesVal, 0 LYSalesQty,0 LYSalesVal,0 LMTDSalesQty,0 LMTDSalesVal,sum(TargetAmount) as  Target  from dbo.t_PlanExecutiveWeekTarget a,t_Employee b where a.Salespersonid=b.EmployeeID and TYear={6} and TMonth={7} group by TYear,TMonth,SalesPersonid,EmployeeName,Category) Total group by EmployeeID,EmployeeName,SalesCategory) xx", FirstDateOfThisMonth, dtGetDate, FirstDayOfLastMonth, TodayOfLastMonth, FirstDateOfLYThisMonth, TodayOfLYThisMonth, nTGTYear, nTGTMonth,Utility.WarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();
                    _oDailySalesReport.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    _oDailySalesReport.EmployeeName = reader["EmployeeName"].ToString();
                    _oDailySalesReport.SalesCategory = reader["SalesCategory"].ToString();
                    _oDailySalesReport.CMSalesQty = Convert.ToInt32(reader["CMSalesQty"].ToString());
                    _oDailySalesReport.CMSalesValue = Convert.ToDouble(reader["CMSalesVal"].ToString());
                    _oDailySalesReport.Achievement = Convert.ToDouble(reader["Achievement"].ToString());
                    _oDailySalesReport.LYSalesQty = Convert.ToInt32(reader["LYSalesQty"].ToString());
                    _oDailySalesReport.LYSalesValue = Convert.ToDouble(reader["LYSalesVal"].ToString());
                    _oDailySalesReport.GrowthLM = Convert.ToDouble(reader["GrowthLM"].ToString());
                    _oDailySalesReport.LMTDSalesQty = Convert.ToInt32(reader["LMTDSalesQty"].ToString());
                    _oDailySalesReport.LMTDSalesValue = Convert.ToDouble(reader["LMTDSalesVal"].ToString());
                    _oDailySalesReport.GrowthLYTM = Convert.ToDouble(reader["GrowthLYTM"].ToString());
                    _oDailySalesReport.Target = Convert.ToDouble(reader["CMTargetVal"].ToString());
                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void TgtVsAchExecutiveWiseWeek(DateTime FirstDateOfThisMonth, DateTime LastDateOfThisMonth, int nTGTYear, int nTGTMonth)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "SELECT Final.*,DateName(mm,DATEADD(mm,TMonth,-1)) as MonthName from " +
                "(select Showroomcode,TYear,TMonth,WeekNo,CAST(SalesPersonID AS char(15)) SalesPersonID,EmployeeName,DesignationName, " +
                " SLSProductGroup,TotalNetSales,TargetValue, " +
                " isnull(((TotalNetSales/nullif(TargetValue,0))*100),0) as ACHPercent from " +
                " ( " +
                " select Customerid, SalesPersonID,employeename,designationname, " +
                " TYear,TMonth,WeekNo,TS.ProductGroup SLSProductGroup, " +
                " isnull(sum(Netsales),0) TotalNetSales, " +
                " round(isnull(sum(TargetValue),0),-3) TargetValue  " +
                " from  " +
                " ( " +
                " select sr.customerid,sls.SalesPersonID,TYear,weekno,TMonth, " +
                " case VP.PGName when 'Electronics' then 'Electronics' else 'Appliances' end ProductGroup, " +
                " SalesQty,GrossSales+OC-Discount-sls.VAT as Netsales,0 TargetValue from  " +
                " (Select SalesPersonID,WarehouseID,weekno,TYear,TMonth,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales, " +
                " isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT " +
                " From " +
                " ( " +
                " Select SalesPersonID,WarehouseID,Customerid,InvoiceDate,weekno,TMonth,TYear,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                " sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT " +
                " from " +
                " ( " +
                " Select SalesPersonID,WarehouseID,a.InvoiceID,InvoiceDate,weekno,TMonth,TYear,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (Discount/GrossPrice * ( unitprice * Quantity)) as Discount, " +
                " (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                " from " +
                " ( " +
                " select SalesPersonID,WarehouseID,sa.InvoiceID,InvoiceDate,weekno, month(InvoiceDate) as TMonth,year(InvoiceDate) as TYear, CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge " +
                " from t_salesinvoice sa, t_salesinvoicedetail sd,t_CalendarWeek " +
                " where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate <= '" + LastDateOfThisMonth + "' " +
                " and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate " +
                " and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) " +
                " )as a " +
                " left outer join " +
                " ( " +
                " select sa.InvoiceID, Sum(quantity*UnitPrice) as GrossPrice " +
                " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                " where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate <= '" + LastDateOfThisMonth + "' " +
                " and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) " +
                " group by sa.InvoiceID,Discount,OtherCharge " +
                " ) as b on a.invoiceid = b.invoiceid " +
                " ) as final " +
                " Group By SalesPersonID,WarehouseID,Customerid,InvoiceDate,weekno,TMonth,TYear,ProductID " +
                " Union all " +
                " Select SalesPersonID,WarehouseID,Customerid,InvoiceDate,weekno,TMonth,TYear,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales, " +
                " 0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT " +
                " from " +
                " ( " +
                " Select SalesPersonID,WarehouseID,a.InvoiceID,InvoiceDate,weekno,TMonth,TYear,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(Discount/GrossPrice * ( unitprice * Quantity)) as Discount, " +
                " (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC, " +
                " (Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                " from " +
                " ( " +
                " select SalesPersonID,WarehouseID,sa.InvoiceID,InvoiceDate,weekno, month(InvoiceDate) as TMonth,year(InvoiceDate) as TYear, CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge " +
                " from t_salesinvoice sa, t_salesinvoicedetail sd,t_CalendarWeek " +
                " where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate <= '" + LastDateOfThisMonth + "' " +
                " and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate " +
                " and invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3) " +
                " )as a " +
                " left outer join " +
                " ( " +
                " select sa.InvoiceID,Sum(quantity*UnitPrice) as GrossPrice " +
                " from t_salesinvoice sa, t_salesinvoicedetail sd " +
                " where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate <= '" + LastDateOfThisMonth + "' " +
                " and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)  " +
                " group by sa.InvoiceID,Discount,OtherCharge " +
                " ) as b on a.invoiceid = b.invoiceid " +
                " ) as final " +
                " Group By SalesPersonID,WarehouseID,Customerid,InvoiceDate,weekno,TMonth,TYear,ProductID " +
                " )as FinalQuery " +
                " Group by SalesPersonID,WarehouseID,TYear,weekno,TMonth,ProductID) sls " +
                " join  " +
                " (select * from t_warehouse where warehouseparentid=7) wh " +
                " on(sls.WarehouseID=wh.WarehouseID) " +
                " join " +
                " t_showroom sr " +
                " on(wh.shortcode=sr.showroomcode) " +
                " join v_productdetails vp " +
                " on(sls.productid=vp.productid) " +
                " union all " +
                " select Customerid,Salespersonid Employeeid,TYear,WeekNo,TMonth,Category as ProductGroup,0 SalesQty,0 Netsales, " +
                " sum(TargetAmount) TargetValue  " +
                " from t_PlanExecutiveWeekTarget where TYear=" + nTGTYear + " and TMonth=" + nTGTMonth + " and Category<>'Mobile' " +
                " group by Customerid,Salespersonid,TMonth,TYear,WeekNo,Category) TS " +
                " join t_employee VE " +
                " on (TS.SalesPersonID=VE.EmployeeID) " +
                " group by Customerid, SalesPersonID,employeename,designationname, " +
                " TYear,TMonth,WeekNo,TS.ProductGroup) FinalQry " +
                " join  " +
                " (select a.customerID,ShowroomCode,AreaName,TerritoryName from v_customerdetails a, t_showroom b " +
                " where a.customerid=b.customerid) vc " +
                " on(FinalQry.Customerid=vc.customerid)) Final where 1=1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();
                    _oDailySalesReport.ShowroomCode = reader["EmployeeName"].ToString();
                    _oDailySalesReport.TYear = Convert.ToInt32(reader["TYear"].ToString());
                    _oDailySalesReport.TMonth = Convert.ToInt32(reader["TMonth"].ToString());
                    _oDailySalesReport.Month = reader["MonthName"].ToString();
                    _oDailySalesReport.TWeek = Convert.ToInt32(reader["WeekNo"].ToString());
                    _oDailySalesReport.EmployeeID = Convert.ToInt32(reader["SalesPersonID"].ToString());
                    _oDailySalesReport.EmployeeName = reader["EmployeeName"].ToString();
                    _oDailySalesReport.DesignationName = reader["DesignationName"].ToString();
                    _oDailySalesReport.SalesCategory = reader["SLSProductGroup"].ToString();
                    _oDailySalesReport.CMSalesValue = Convert.ToDouble(reader["TotalNetSales"].ToString());
                    _oDailySalesReport.Target = Convert.ToDouble(reader["TargetValue"].ToString());
                    _oDailySalesReport.Achievement = Convert.ToDouble(reader["ACHPercent"].ToString());
                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void TgtVsAchExecutiveWiseWeekRT(DateTime FirstDateOfThisMonth, DateTime LastDateOfThisMonth, int nTGTYear, int nTGTMonth)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = String.Format(@"SELECT Final.*,DateName(mm,DATEADD(mm,TMonth,-1)) as MonthName from (select Showroomcode,TYear,TMonth,WeekNo,CAST(SalesPersonID AS char(15)) SalesPersonID,EmployeeName,DesignationName,  SLSProductGroup,TotalNetSales,TargetValue,  isnull(((TotalNetSales/nullif(TargetValue,0))*100),0) as ACHPercent from  (  select Customerid, SalesPersonID,employeename,designationname,  TYear,TMonth,WeekNo,TS.ProductGroup SLSProductGroup,  isnull(sum(Netsales),0) TotalNetSales,  round(isnull(sum(TargetValue),0),-3) TargetValue   from   (  select sr.customerid,sls.SalesPersonID,TYear,weekno,TMonth,  case VP.PGName when 'Electronics' then 'Electronics' else 'Appliances' end ProductGroup,  SalesQty,GrossSales+OC-Discount-sls.VAT as Netsales,0 TargetValue from   (Select SalesPersonID,WarehouseID,weekno,TYear,TMonth,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,  isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT  From  (  Select SalesPersonID,WarehouseID,Customerid,InvoiceDate,weekno,TMonth,TYear,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales,  sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT  from  (  Select SalesPersonID,WarehouseID,a.InvoiceID,InvoiceDate,weekno,TMonth,TYear,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (Discount/GrossPrice * ( unitprice * Quantity)) as Discount,  (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT  from  (  select SalesPersonID,WarehouseID,sa.InvoiceID,InvoiceDate,weekno, month(InvoiceDate) as TMonth,year(InvoiceDate) as TYear, CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge  from t_salesinvoice sa, t_salesinvoicedetail sd,t_CalendarWeek  where sa.invoiceid = sd.invoiceid and sa.WarehouseID={4}  and invoicedate between '{0}' and '{1}' and invoicedate <= '{1}'  and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate  and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  )as a  left outer join  (  select sa.InvoiceID, Sum(quantity*UnitPrice) as GrossPrice  from t_salesinvoice sa, t_salesinvoicedetail sd  where sa.invoiceid = sd.invoiceid and sa.WarehouseID={4} and invoicedate between '{0}' and '{1}' and invoicedate <= '{1}'  and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  group by sa.InvoiceID,Discount,OtherCharge  ) as b on a.invoiceid = b.invoiceid  ) as final  Group By SalesPersonID,WarehouseID,Customerid,InvoiceDate,weekno,TMonth,TYear,ProductID  Union all  Select SalesPersonID,WarehouseID,Customerid,InvoiceDate,weekno,TMonth,TYear,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,  0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT  from  (  Select SalesPersonID,WarehouseID,a.InvoiceID,InvoiceDate,weekno,TMonth,TYear,CustomerID,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(Discount/GrossPrice * ( unitprice * Quantity)) as Discount,  (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,  (Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT  from  (  select SalesPersonID,WarehouseID,sa.InvoiceID,InvoiceDate,weekno, month(InvoiceDate) as TMonth,year(InvoiceDate) as TYear, CustomerID,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge  from t_salesinvoice sa, t_salesinvoicedetail sd,t_CalendarWeek  where sa.invoiceid = sd.invoiceid and sa.WarehouseID={4} and invoicedate between '{0}' and '{1}' and invoicedate <= '{1}'  and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate  and invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)  )as a  left outer join  (  select sa.InvoiceID,Sum(quantity*UnitPrice) as GrossPrice  from t_salesinvoice sa, t_salesinvoicedetail sd  where sa.invoiceid = sd.invoiceid and sa.WarehouseID={4} and invoicedate between '{0}' and '{1}' and invoicedate <= '{1}'  and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge  ) as b on a.invoiceid = b.invoiceid  ) as final  Group By SalesPersonID,WarehouseID,Customerid,InvoiceDate,weekno,TMonth,TYear,ProductID  )as FinalQuery  Group by SalesPersonID,WarehouseID,TYear,weekno,TMonth,ProductID) sls  join   (select * from t_warehouse where warehouseparentid=7) wh  on(sls.WarehouseID=wh.WarehouseID)  join  t_showroom sr  on(wh.shortcode=sr.showroomcode and sr.WarehouseID={4})  join v_productdetails vp  on(sls.productid=vp.productid)  union all  select Customerid,Salespersonid Employeeid,TYear,WeekNo,TMonth,Category as ProductGroup,0 SalesQty,0 Netsales,  sum(TargetAmount) TargetValue   from t_PlanExecutiveWeekTarget where TYear={2} and TMonth={3} and Category<>'Mobile'  group by Customerid,Salespersonid,TMonth,TYear,WeekNo,Category) TS  join v_EmployeeDetails VE  on (TS.SalesPersonID=VE.EmployeeID)  group by Customerid, SalesPersonID,employeename,designationname,  TYear,TMonth,WeekNo,TS.ProductGroup) FinalQry  join   (select a.customerID,ShowroomCode,AreaName,TerritoryName from v_customerdetails a, t_showroom b  where a.customerid=b.customerid and b.WarehouseID={4}) vc  on(FinalQry.Customerid=vc.customerid)) Final where 1=1"
, FirstDateOfThisMonth, LastDateOfThisMonth, nTGTYear, nTGTMonth,Utility.WarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();
                    _oDailySalesReport.ShowroomCode = reader["EmployeeName"].ToString();
                    _oDailySalesReport.TYear = Convert.ToInt32(reader["TYear"].ToString());
                    _oDailySalesReport.TMonth = Convert.ToInt32(reader["TMonth"].ToString());
                    _oDailySalesReport.Month = reader["MonthName"].ToString();
                    _oDailySalesReport.TWeek = Convert.ToInt32(reader["WeekNo"].ToString());
                    _oDailySalesReport.EmployeeID = Convert.ToInt32(reader["SalesPersonID"].ToString());
                    _oDailySalesReport.EmployeeName = reader["EmployeeName"].ToString();
                    _oDailySalesReport.DesignationName = reader["DesignationName"].ToString();
                    _oDailySalesReport.SalesCategory = reader["SLSProductGroup"].ToString();
                    _oDailySalesReport.CMSalesValue = Convert.ToDouble(reader["TotalNetSales"].ToString());
                    _oDailySalesReport.Target = Convert.ToDouble(reader["TargetValue"].ToString());
                    _oDailySalesReport.Achievement = Convert.ToDouble(reader["ACHPercent"].ToString());
                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void CustomerTgtVsAchByMonth(DateTime FirstDateOfThisMonth, int TYear, int TMonth)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "select ShowroomCode,TYear, TMonth,sum(OLDCUSTTGT) OLDNOITGT,sum(NEWCUSTTGT) NEWNOITGT,sum(OLDNOI) OLDNOI,sum(NEWNOI) NEWNOI " +
                   " from " +
                   " (select ShowroomCode,TYear, TMonth,sum(OLDCustomer) OLDCUSTTGT,sum(NEWCustomer) NEWCUSTTGT ,0 OLDNOI,0 NEWNOI " +
                   " from dbo.t_PlanCustomerTarget a, t_showroom b " +
                   " where a.customerid=b.customerid and Tyear=" + TYear + " and TMonth=" + TMonth + " group by ShowroomCode,TYear, TMonth " +
                   " union all " +
                   " select  WHCode ShowroomCode,TYear,TMonth, 0 OLDCUSTTGT,0 NEWCUSTTGT ,sum(case when IsNEW='OLD' then NOI else 0 end) as OLDNOI, " +
                   " sum(case when IsNEW='NEW' then NOI else 0 end) as NEWNOI " +
                   " from " +
                   " (select WHCode,TYear,TMonth, IsNEW,count(InvoiceNo) as NOI from " +
                   " (Select ShowroomCode as WHCode,year(InvoiceDate) TYear, month(InvoiceDate) TMonth,'OLD' IsNEW,InvoiceNo " +
                   " from t_RetailConsumer a,t_SalesInvoice b,t_SalesInvoiceDetail c, " +
                   " v_productdetails d,t_Showroom e where a.ConsumerID=b.SundrycustomerID  " +
                   " and b.InvoiceID=c.InvoiceID and c.ProductID=d.ProductID and e.WarehouseID=b.WarehouseID and  " +
                   " year(InvoiceDate)=" + TYear + " and month(InvoiceDate)=" + TMonth + "  " +
                   " and InvoiceTypeID not in (6,7,8,9,10,11,12) " +
                   " and a.CellNo is not null and CellNo<>''  and CellNo in " +
                   " (Select distinct CellNo From t_RetailConsumer a,t_SalesInvoice b " +
                   " where a.ConsumerID=b.SundryCustomerID and InvoiceDate<'" + FirstDateOfThisMonth + "' and  " +
                   " CellNo is not null and CellNo<>'') " +
                   " ) m " +
                   " group by WHCode,TYear,TMonth, IsNEW " +
                   " union all " +
                   " select  WHCode,TYear,TMonth, IsNEW,count(InvoiceNo) as NOI from " +
                   " (Select ShowroomCode as WHCode,year(InvoiceDate) TYear, month(InvoiceDate) TMonth,'NEW' IsNEW,InvoiceNo " +
                   " from t_RetailConsumer a,t_SalesInvoice b,t_SalesInvoiceDetail c, " +
                   " v_productdetails d,t_Showroom e where a.ConsumerID=b.SundrycustomerID  " +
                   " and b.InvoiceID=c.InvoiceID and c.ProductID=d.ProductID and e.WarehouseID=b.WarehouseID and  " +
                   " year(InvoiceDate)=" + TYear + " and month(InvoiceDate)=" + TMonth + "  " +
                   " and InvoiceTypeID not in (6,7,8,9,10,11,12) " +
                   " and a.CellNo is not null and CellNo<>''  and CellNo not in " +
                   " (Select distinct CellNo From t_RetailConsumer a,t_SalesInvoice b " +
                   " where a.ConsumerID=b.SundryCustomerID and InvoiceDate<'" + FirstDateOfThisMonth + "' and  " +
                   " CellNo is not null and CellNo<>'')) m " +
                   " group by WHCode,TYear,TMonth, IsNEW) x  " +
                   " group by WHCode,TYear,TMonth) Final group by ShowroomCode,TYear, TMonth";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oCustTGTvsAchReport = new RetailSalesInvoice();
                    _oCustTGTvsAchReport.ShowroomCode = reader["ShowroomCode"].ToString();
                    _oCustTGTvsAchReport.TYear = Convert.ToInt32(reader["TYear"].ToString());
                    _oCustTGTvsAchReport.TMonth = Convert.ToInt32(reader["TMonth"].ToString());
                    _oCustTGTvsAchReport.OLDNOITGT = Convert.ToInt32(reader["OLDNOITGT"].ToString());
                    _oCustTGTvsAchReport.NEWNOITGT = Convert.ToInt32(reader["NEWNOITGT"].ToString());
                    _oCustTGTvsAchReport.OLDNOI = Convert.ToInt32(reader["OLDNOI"].ToString());
                    _oCustTGTvsAchReport.NEWNOI = Convert.ToInt32(reader["NEWNOI"].ToString());
                    InnerList.Add(_oCustTGTvsAchReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void CustomerTgtVsAchByMonthRT(DateTime FirstDateOfThisMonth, int TYear, int TMonth)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = String.Format(@"select ShowroomCode,TYear, TMonth,sum(OLDCUSTTGT) OLDNOITGT,sum(NEWCUSTTGT) NEWNOITGT,sum(OLDNOI) OLDNOI,sum(NEWNOI) NEWNOI  from  (select ShowroomCode,TYear, TMonth,sum (OLDCustomer) OLDCUSTTGT,sum(NEWCustomer) NEWCUSTTGT ,0 OLDNOI,0 NEWNOI  from dbo.t_PlanCustomerTarget a, t_showroom b  where a.customerid=b.customerid and Tyear=2021 and TMonth=1 and b.WarehouseID={3} group by ShowroomCode,TYear, TMonth  union all  select  WHCode ShowroomCode,TYear,TMonth, 0 OLDCUSTTGT,0 NEWCUSTTGT ,sum(case when IsNEW='OLD' then NOI else 0 end) as OLDNOI,  sum(case when IsNEW='NEW' then NOI else 0 end) as NEWNOI  from  (select WHCode,TYear,TMonth, IsNEW,count(InvoiceNo) as NOI from  (Select ShowroomCode as WHCode,year(InvoiceDate) TYear, month(InvoiceDate) TMonth,'OLD' IsNEW,InvoiceNo  from t_RetailConsumer a,t_SalesInvoice b,t_SalesInvoiceDetail c,  v_productdetails d,t_Showroom e where a.ConsumerID=b.SundrycustomerID and a.WarehouseID=b.WarehouseID and b.WarehouseID={3}   and b.InvoiceID=c.InvoiceID and c.ProductID=d.ProductID and e.WarehouseID=b.WarehouseID and   year(InvoiceDate)=2021 and month(InvoiceDate)=1   and InvoiceTypeID not in (6,7,8,9,10,11,12)  and a.CellNo is not null and CellNo<>''  and CellNo in  (Select distinct CellNo From t_RetailConsumer a,t_SalesInvoice b  where a.ConsumerID=b.SundryCustomerID  and a.WarehouseID=b.WarehouseID and b.WarehouseID={3} and InvoiceDate<'{0}' and   CellNo is not null and CellNo<>'')  ) m  group by WHCode,TYear,TMonth, IsNEW  union all  select  WHCode,TYear,TMonth, IsNEW,count(InvoiceNo) as NOI from  (Select ShowroomCode as WHCode,year(InvoiceDate) TYear, month(InvoiceDate) TMonth,'NEW' IsNEW,InvoiceNo  from t_RetailConsumer a,t_SalesInvoice b,t_SalesInvoiceDetail c,  v_productdetails d,t_Showroom e where a.ConsumerID=b.SundrycustomerID  and a.WarehouseID=b.WarehouseID and b.WarehouseID={3}  and b.InvoiceID=c.InvoiceID and c.ProductID=d.ProductID and e.WarehouseID=b.WarehouseID and   year(InvoiceDate)={1} and month(InvoiceDate)={2}   and InvoiceTypeID not in (6,7,8,9,10,11,12)  and a.CellNo is not null and CellNo<>''  and CellNo not in  (Select distinct CellNo From t_RetailConsumer a,t_SalesInvoice b  where a.ConsumerID=b.SundryCustomerID  and a.WarehouseID=b.WarehouseID and b.WarehouseID={3} and InvoiceDate<'{0}' and   CellNo is not null and CellNo<>'')) m  group by WHCode,TYear,TMonth, IsNEW) x   group by WHCode,TYear,TMonth) Final group by ShowroomCode,TYear, TMonth"
                   , FirstDateOfThisMonth, TYear, TMonth,Utility.WarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oCustTGTvsAchReport = new RetailSalesInvoice();
                    _oCustTGTvsAchReport.ShowroomCode = reader["ShowroomCode"].ToString();
                    _oCustTGTvsAchReport.TYear = Convert.ToInt32(reader["TYear"].ToString());
                    _oCustTGTvsAchReport.TMonth = Convert.ToInt32(reader["TMonth"].ToString());
                    _oCustTGTvsAchReport.OLDNOITGT = Convert.ToInt32(reader["OLDNOITGT"].ToString());
                    _oCustTGTvsAchReport.NEWNOITGT = Convert.ToInt32(reader["NEWNOITGT"].ToString());
                    _oCustTGTvsAchReport.OLDNOI = Convert.ToInt32(reader["OLDNOI"].ToString());
                    _oCustTGTvsAchReport.NEWNOI = Convert.ToInt32(reader["NEWNOI"].ToString());
                    InnerList.Add(_oCustTGTvsAchReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void SalesTrandReport(int nThisYear, int nLastYear)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select SL,Month,ThisYearTarget,ThisYearActual, " +
                    "isnull((ThisYearActual/nullif(ThisYearTarget,0)*100),0) as AchPercentage,PerviousYearActual, " +
                    "isnull(((ThisYearActual-PerviousYearActual)/nullif(PerviousYearActual,0)*100),0) as GrowthPercentage from  " +
                    "( " +
                    "Select SL,Month,Sum(ThisYearTarget) ThisYearTarget,Sum(ThisYearActual) ThisYearActual,Sum(PerviousYearActual) PerviousYearActual From  " +
                    "( " +
                    "Select * From  " +
                    "(SELECT 1 as SL,'January' as Month,0 ThisYearTarget,0 ThisYearActual,0 PerviousYearActual,0 Groth " +
                    "Union All " +
                    "SELECT  2 as SL,'February' as Month,0 Target,0 Actual,0 Actual,0 Groth " +
                    "Union All " +
                    "SELECT  3 as SL,'March' as Month,0 Target,0 Actual,0 Actual,0 Groth " +
                    "Union All " +
                    "SELECT  4 as SL,'April' as Month,0 Target,0 Actual,0 Actual,0 Groth " +
                    "Union All " +
                    "SELECT  5 as SL,'May' as Month,0 Target,0 Actual,0 Actual,0 Groth " +
                    "union all " +
                    "SELECT  6 as SL,'June' as Month,0 Target,0 Actual,0 Actual,0 Groth " +
                    "Union All " +
                    "SELECT  7 as SL,'July' as Month,0 Target,0 Actual,0 Actual,0 Groth " +
                    "Union All " +
                    "SELECT  8 as SL,'August' as Month,0 Target,0 Actual,0 Actual,0 Groth " +
                    "Union All " +
                    "SELECT  9 as SL,'September' as Month,0 Target,0 Actual,0 Actual,0 Groth " +
                    "Union All " +
                    "SELECT  10 as SL,'October' as Month,0 Target,0 Actual,0 Actual,0 Groth " +
                    "Union All " +
                    "SELECT  11 as SL,'November' as Month,0 Target,0 Actual,0 Actual,0 Groth " +
                    "Union All " +
                    "SELECT  12 as SL,'December' as Month,0 Target,0 Actual,0 Actual,0 Groth) as Dammy " +
                    "Union All  " +
                    "Select * From  " +
                    "(Select SL,TMonth,0 as Target,sum (GrossSales+OC-Discount-VAT) as TActual,0 PActual,0 Groth from " +
                    "(Select SL,WarehouseID,TYear,TMonth,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales, " +
                    "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT " +
                    "From " +
                    "( " +
                    "Select SL,WarehouseID,TYear,TMonth,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                    "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT " +
                    "from " +
                    "( " +
                    "Select SL,WarehouseID,a.InvoiceID,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (Discount/GrossPrice * ( unitprice * Quantity)) as Discount, " +
                    "(OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                    "from " +
                    "( " +
                    "select month(invoicedate) as SL,WarehouseID,sa.InvoiceID,year(invoicedate) as TYear,DATENAME(month, invoicedate) as TMonth,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and year(invoicedate)=" + nThisYear + " " +
                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  " +
                    ")as a " +
                    "left outer join " +
                    "( " +
                    "select sa.InvoiceID, Sum(quantity*UnitPrice) as GrossPrice " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and year(invoicedate)=" + nThisYear + " " +
                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  " +
                    "group by sa.InvoiceID,Discount,OtherCharge " +
                    ") as b on a.invoiceid = b.invoiceid " +
                    ") as final " +
                    "Group By SL,WarehouseID,TYear,TMonth,ProductID " +
                    "Union all " +
                    "Select SL,WarehouseID,TYear,TMonth,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales, " +
                    "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT " +
                    "from " +
                    "( " +
                    "Select SL,WarehouseID,a.InvoiceID,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(Discount/GrossPrice * ( unitprice * Quantity)) as Discount, " +
                    "(OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC, " +
                    "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                    "from " +
                    "( " +
                    "select month(invoicedate) as SL,WarehouseID,sa.InvoiceID,year(invoicedate) as TYear,DATENAME(month, invoicedate) as TMonth,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and year(invoicedate)=" + nThisYear + " " +
                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)  " +
                    ")as a " +
                    "left outer join " +
                    "( " +
                    "select sa.InvoiceID,Sum(quantity*UnitPrice) as GrossPrice " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and year(invoicedate)=" + nThisYear + " " +
                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)  " +
                    "group by sa.InvoiceID,Discount,OtherCharge " +
                    ") as b on a.invoiceid = b.invoiceid " +
                    ") as final " +
                    "Group By SL,WarehouseID,TYear,TMonth,ProductID " +
                    ")as FinalQuery " +
                    "Group by SL,WarehouseID,TYear,TMonth,ProductID) CMSales " +
                    "group by SL,TYear,TMonth) CYear " +
                    "Union All " +
                    "Select * From  " +
                    "(Select SL,TMonth,0 as Target,0 TActual,sum (GrossSales+OC-Discount-VAT) as PActual,0 Groth from " +
                    "(Select SL,WarehouseID,TYear,TMonth,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales, " +
                    "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT " +
                    "From " +
                    "( " +
                    "Select SL,WarehouseID,TYear,TMonth,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, " +
                    "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT " +
                    "from " +
                    "( " +
                    "Select SL,WarehouseID,a.InvoiceID,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (Discount/GrossPrice * ( unitprice * Quantity)) as Discount, " +
                    "(OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                    "from " +
                    "( " +
                    "select month(invoicedate) as SL,WarehouseID,sa.InvoiceID,year(invoicedate) as TYear,DATENAME(month, invoicedate) as TMonth,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and year(invoicedate)=" + nLastYear + " " +
                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  " +
                    ")as a " +
                    "left outer join " +
                    "( " +
                    "select sa.InvoiceID, Sum(quantity*UnitPrice) as GrossPrice " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and year(invoicedate)=" + nLastYear + " " +
                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  " +
                    "group by sa.InvoiceID,Discount,OtherCharge " +
                    ") as b on a.invoiceid = b.invoiceid " +
                    ") as final " +
                    "Group By SL,WarehouseID,TYear,TMonth,ProductID " +
                    "Union all " +
                    "Select SL,WarehouseID,TYear,TMonth,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales, " +
                    "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT " +
                    "from " +
                    "( " +
                    "Select SL,WarehouseID,a.InvoiceID,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(Discount/GrossPrice * ( unitprice * Quantity)) as Discount, " +
                    "(OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC, " +
                    "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT " +
                    "from " +
                    "( " +
                    "select month(invoicedate) as SL,WarehouseID,sa.InvoiceID,year(invoicedate) as TYear,DATENAME(month, invoicedate) as TMonth,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and year(invoicedate)=" + nLastYear + " " +
                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)  " +
                    ")as a " +
                    "left outer join " +
                    "( " +
                    "select sa.InvoiceID,Sum(quantity*UnitPrice) as GrossPrice " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd " +
                    "where sa.invoiceid = sd.invoiceid and year(invoicedate)=" + nLastYear + " " +
                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)  " +
                    "group by sa.InvoiceID,Discount,OtherCharge " +
                    ") as b on a.invoiceid = b.invoiceid " +
                    ") as final " +
                    "Group By SL,WarehouseID,TYear,TMonth,ProductID " +
                    ")as FinalQuery " +
                    "Group by SL,WarehouseID,TYear,TMonth,ProductID) CMSales " +
                    "group by SL,TYear,TMonth) PYear " +
                    "Union All " +
                    "Select * From  " +
                    "(Select TMonth,DateName( month , DateAdd( month , TMonth , -1 )) as Month, " +
                    "sum(TargetValue) as Target,0 TActual,0 PActual, 0 Groth " +
                    "From dbo.t_PlanMAGWeekTargetQty where  TYear=" + nThisYear + " and CustomerID=(Select CustomerID From t_Thissystem) group by TMonth) Target " +
                    ") Final group by SL,Month " +
                    ") TotalFinal Order by SL";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oSalesTrandReport = new RetailSalesInvoice();
                    _oSalesTrandReport.SL = Convert.ToInt32(reader["SL"].ToString());
                    _oSalesTrandReport.Month = reader["Month"].ToString();
                    _oSalesTrandReport.ThisYearTarget = Convert.ToDouble(reader["ThisYearTarget"].ToString());
                    _oSalesTrandReport.ThisYearActual = Convert.ToDouble(reader["ThisYearActual"].ToString());
                    _oSalesTrandReport.Achievement = Convert.ToDouble(reader["AchPercentage"].ToString());
                    _oSalesTrandReport.PerviousYearActual = Convert.ToDouble(reader["PerviousYearActual"].ToString());
                    _oSalesTrandReport.GrowthPercentage = Convert.ToDouble(reader["GrowthPercentage"].ToString());
                    InnerList.Add(_oSalesTrandReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void SalesTrandReportRT(int nThisYear, int nLastYear)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = String.Format(@"Select SL,Month,ThisYearTarget,ThisYearActual, isnull((ThisYearActual/nullif (ThisYearTarget,0)*100),0) as AchPercentage,PerviousYearActual, isnull(((ThisYearActual-PerviousYearActual)/nullif(PerviousYearActual,0)*100),0) as GrowthPercentage from  ( Select SL,Month,Sum(ThisYearTarget) ThisYearTarget,Sum(ThisYearActual) ThisYearActual,Sum(PerviousYearActual) PerviousYearActual From  ( Select * From  (SELECT 1 as SL,'January' as Month,0 ThisYearTarget,0 ThisYearActual,0 PerviousYearActual,0 Groth Union All SELECT  2 as SL,'February' as Month,0 Target,0 Actual,0 Actual,0 Groth Union All SELECT  3 as SL,'March' as Month,0 Target,0 Actual,0 Actual,0 Groth Union All SELECT  4 as SL,'April' as Month,0 Target,0 Actual,0 Actual,0 Groth Union All SELECT  5 as SL,'May' as Month,0 Target,0 Actual,0 Actual,0 Groth union all SELECT  6 as SL,'June' as Month,0 Target,0 Actual,0 Actual,0 Groth Union All SELECT  7 as SL,'July' as Month,0 Target,0 Actual,0 Actual,0 Groth Union All SELECT  8 as SL,'August' as Month,0 Target,0 Actual,0 Actual,0 Groth Union All SELECT  9 as SL,'September' as Month,0 Target,0 Actual,0 Actual,0 Groth Union All SELECT  10 as SL,'October' as Month,0 Target,0 Actual,0 Actual,0 Groth Union All SELECT  11 as SL,'November' as Month,0 Target,0 Actual,0 Actual,0 Groth Union All SELECT  12 as SL,'December' as Month,0 Target,0 Actual,0 Actual,0 Groth) as Dammy Union All  Select * From  (Select SL,TMonth,0 as Target,sum (GrossSales+OC-Discount-VAT) as TActual,0 PActual,0 Groth from (Select SL,WarehouseID,TYear,TMonth,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales, isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT From ( Select SL,WarehouseID,TYear,TMonth,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT from ( Select SL,WarehouseID,a.InvoiceID,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (Discount/GrossPrice * ( unitprice * Quantity)) as Discount, (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT from ( select month(invoicedate) as SL,WarehouseID,sa.InvoiceID,year(invoicedate) as TYear,DATENAME(month, invoicedate) as TMonth,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={2} and year(invoicedate)={0} and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  )as a left outer join ( select sa.InvoiceID, Sum(quantity*UnitPrice) as GrossPrice from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={2} and year(invoicedate)={0} and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  group by sa.InvoiceID,Discount,OtherCharge ) as b on a.invoiceid = b.invoiceid ) as final Group By SL,WarehouseID,TYear,TMonth,ProductID Union all Select SL,WarehouseID,TYear,TMonth,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales, 0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT from ( Select SL,WarehouseID,a.InvoiceID,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(Discount/GrossPrice * ( unitprice * Quantity)) as Discount, (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC, (Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT from ( select month(invoicedate) as SL,WarehouseID,sa.InvoiceID,year(invoicedate) as TYear,DATENAME(month, invoicedate) as TMonth,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={2} and year(invoicedate)={0} and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)  )as a left outer join ( select sa.InvoiceID,Sum(quantity*UnitPrice) as GrossPrice from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={2} and year(invoicedate)={0} and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)  group by sa.InvoiceID,Discount,OtherCharge ) as b on a.invoiceid = b.invoiceid ) as final Group By SL,WarehouseID,TYear,TMonth,ProductID )as FinalQuery Group by SL,WarehouseID,TYear,TMonth,ProductID) CMSales group by SL,TYear,TMonth) CYear Union All Select * From  (Select SL,TMonth,0 as Target,0 TActual,sum (GrossSales+OC-Discount-VAT) as PActual,0 Groth from (Select SL,WarehouseID,TYear,TMonth,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales, isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT From ( Select SL,WarehouseID,TYear,TMonth,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT from ( Select SL,WarehouseID,a.InvoiceID,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (Discount/GrossPrice * ( unitprice * Quantity)) as Discount, (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC,(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT from ( select month(invoicedate) as SL,WarehouseID,sa.InvoiceID,year(invoicedate) as TYear,DATENAME(month, invoicedate) as TMonth,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={2} and year(invoicedate)={1} and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  )as a left outer join ( select sa.InvoiceID, Sum(quantity*UnitPrice) as GrossPrice from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={2} and year(invoicedate)={1} and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)  group by sa.InvoiceID,Discount,OtherCharge ) as b on a.invoiceid = b.invoiceid ) as final Group By SL,WarehouseID,TYear,TMonth,ProductID Union all Select SL,WarehouseID,TYear,TMonth,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales, 0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT from ( Select SL,WarehouseID,a.InvoiceID,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(Discount/GrossPrice * ( unitprice * Quantity)) as Discount, (OtherCharge/GrossPrice * ( unitprice * Quantity)) as OC, (Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT from ( select month(invoicedate) as SL,WarehouseID,sa.InvoiceID,year(invoicedate) as TYear,DATENAME(month, invoicedate) as TMonth,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity,OtherCharge from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={2} and year(invoicedate)={1} and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)  )as a left outer join ( select sa.InvoiceID,Sum(quantity*UnitPrice) as GrossPrice from t_salesinvoice sa, t_salesinvoicedetail sd where sa.invoiceid = sd.invoiceid and sa.WarehouseID={2} and year(invoicedate)={1} and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)  group by sa.InvoiceID,Discount,OtherCharge ) as b on a.invoiceid = b.invoiceid ) as final Group By SL,WarehouseID,TYear,TMonth,ProductID )as FinalQuery Group by SL,WarehouseID,TYear,TMonth,ProductID) CMSales group by SL,TYear,TMonth) PYear Union All Select * From  (Select TMonth,DateName( month , DateAdd( month , TMonth , -1 )) as Month, sum(TargetValue) as Target,0 TActual,0 PActual, 0 Groth From dbo.t_PlanMAGWeekTargetQty where  TYear={0} and CustomerID=(Select CustomerID From t_Showroom where WarehouseID={2}) group by TMonth) Target ) Final group by SL,Month ) TotalFinal Order by SL"
                        , nThisYear, nLastYear,Utility.WarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oSalesTrandReport = new RetailSalesInvoice();
                    _oSalesTrandReport.SL = Convert.ToInt32(reader["SL"].ToString());
                    _oSalesTrandReport.Month = reader["Month"].ToString();
                    _oSalesTrandReport.ThisYearTarget = Convert.ToDouble(reader["ThisYearTarget"].ToString());
                    _oSalesTrandReport.ThisYearActual = Convert.ToDouble(reader["ThisYearActual"].ToString());
                    _oSalesTrandReport.Achievement = Convert.ToDouble(reader["AchPercentage"].ToString());
                    _oSalesTrandReport.PerviousYearActual = Convert.ToDouble(reader["PerviousYearActual"].ToString());
                    _oSalesTrandReport.GrowthPercentage = Convert.ToDouble(reader["GrowthPercentage"].ToString());
                    InnerList.Add(_oSalesTrandReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void SalesTrandReportNew(int nThisYear, int nLastYear,int ReportKey)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            string sSalesTypeString = "";
            string sChannelString = "";
            if (ReportKey == (int)Dictionary.ReportKeyfrmSalesTrandReport.Sales_Trand_All)
            {
                sSalesTypeString = "";
                sChannelString = "";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmSalesTrandReport.Sales_Trand_Dealer)
            {
                sSalesTypeString = " where SalesType=" + (int)Dictionary.SalesType.Dealer + "";
                sChannelString = " and Channel in (3,20)";
            }

            if (ReportKey == (int)Dictionary.ReportKeyfrmSalesTrandReport.Sales_Trand_Retail_Other)
            {
                sSalesTypeString = " where SalesType<>" + (int)Dictionary.SalesType.Dealer + "";
                sChannelString = " and Channel not in (3,20)";
            }

            sSql = String.Format(@"Select TMonth as SL,DateName( month , DateAdd( month , TMonth , -1 )) as Month,
                sum(ThisYearTarget) ThisYearTarget,sum(ThisYearActual) ThisYearActual, 
                isnull((sum(ThisYearActual)/nullif(sum(ThisYearTarget),0)*100),0) as AchPercentage,sum(PerviousYearActual) PerviousYearActual, 
                isnull(((sum(ThisYearActual)-sum(PerviousYearActual))/nullif(sum(PerviousYearActual),0)*100),0) as GrowthPercentage  From 
                (
                ---ThisYearActual---
                Select  year(InvoiceDate) TYear,month(InvoiceDate) TMonth,sum((GrossSales + OC - sales.VAT - Discount)) as ThisYearActual,
                0 as PerviousYearActual,0 as ThisYearTarget
                from 
                ( 
                Select WarehouseID, CustomerID, ProductID, CustomerTypeID, Convert(datetime, replace(convert(varchar, InvoiceDate, 6), '', '-'), 1) as InvoiceDate, isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crFreeQty) - sum(drFreeQty)), 0) as FreeQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, 
                isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crInvoiceAmount) - sum(drInvoiceAmount)), 0) as InvoiceAmount, isnull((sum(crOC) - sum(drOC)), 0) as OC, isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT 
                From 
                ( 
                Select InvoiceID, WarehouseID, Customerid, ProductID, InvoiceDate, CustomerTypeID, sum(quantity) as crqty, 0 as drqty, sum(FreeQty) as crFreeQty, 0 as drFreeQty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, 
                sum(Discount) as crDiscount, 0 as drDiscount, Sum(InvoiceAmount) as crInvoiceAmount, 0 as drInvoiceAmount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT 
                from 
                ( 
                Select a.*, CASE When SalesType = 2 then 245 When SalesType = 3 then 249 else 999 end as CustomerTypeID from 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, 
                a.ProductID, Quantity, GrossSales, 
                case when IsNewInv = 1 then NewDiscount else a.Discount end as Discount, 
                case when IsNewInv = 1 then NewCharge else a.OC end as OC, 
                COGS, VAT, FreeQty, SundryCustomerID 
                From 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, Quantity, (Quantity * unitprice) as GrossSales, 
                CASE When GrossPrice > 0 then(Discount / GrossPrice * (unitprice * Quantity)) else 0 end as Discount, 
                CASE When GrossPrice > 0 then(OtherCharge / GrossPrice * (unitprice * Quantity)) else 0 end as OC, 
                (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT, FreeQty, SundryCustomerID 
                from 
                ( 
                select WarehouseID, sa.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity, FreeQty, OtherCharge, SundryCustomerID 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid 
                and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) 
                ) as a 
                left outer join 
                ( 
                select sa.InvoiceID, Sum(quantity * UnitPrice) as GrossPrice 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid 
                and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) 
                group by sa.InvoiceID, Discount, OtherCharge 
                ) as b on a.invoiceid = b.invoiceid 
                ) A 
                Left Outer Join 
                ( 
                Select a.InvoiceID, 1 as IsNewInv, ProductID, sum(Discounts) NewDiscount, sum(Charges) NewCharge 
                From dbo.t_SalesInvoiceDetailNew a, dbo.t_SalesInvoice b where a.InvoiceID = b.InvoiceID and 
                invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) group by a.InvoiceID, ProductID 
                ) B 
                on a.InvoiceID = b.InvoiceID and a.ProductID = b.ProductID 
                ) a 
                Inner Join 
                dbo.t_RetailConsumer b 
                ON a.SundryCustomerID = b.ConsumerID 
                {2}
                ) as final 
                Group By InvoiceID,WarehouseID,Customerid,InvoiceDate,ProductID,CustomerTypeID 
                Union all 
                Select InvoiceID,WarehouseID,Customerid,ProductID,InvoiceDate,CustomerTypeID,0 as crqty, sum(quantity) as drqty, 0 as crFreeQty, sum(FreeQty) as drFreeQty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,    
                0 as crDiscount,sum(Discount) as drDiscount,0 as crInvoiceAmount,Sum(InvoiceAmount) as drInvoiceAmount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT 
                from 
                ( 
                Select a.*, CASE When SalesType = 2 then 245 When SalesType = 3 then 249 else 999 end as CustomerTypeID from 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, 
                a.ProductID, Quantity, GrossSales, 
                case when isnull(IsNewInv, 0) = 1 then NewDiscount else a.Discount end as Discount, 
                case when isnull(IsNewInv, 0) = 1 then NewCharge else a.OC end as OC, 
                COGS, VAT, FreeQty, SundryCustomerID 
                From 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, Quantity, (Quantity * unitprice) as GrossSales, CASE When GrossPrice > 0 then(Discount / GrossPrice * (unitprice * Quantity)) else 0 end as Discount, 
                CASE When GrossPrice > 0 then(OtherCharge / GrossPrice * (unitprice * Quantity)) else 0 end as OC, 
                (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT, FreeQty, SundryCustomerID 
                from 
                ( 
                select WarehouseID, sa.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity, FreeQty, OtherCharge, SundryCustomerID 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid 
                and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3) 
                ) as a 
                left outer join 
                ( 
                select sa.InvoiceID, Sum(quantity * UnitPrice) as GrossPrice 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3) 
                group by sa.InvoiceID, Discount, OtherCharge 
                ) as b 
                on a.invoiceid = b.invoiceid 
                ) A 
                Left Outer Join 
                ( 
                Select a.InvoiceID, 1 as IsNewInv, ProductID, sum(a.Discounts) NewDiscount, sum(a.Charges) NewCharge 
                From dbo.t_SalesInvoiceDetailNew a, dbo.t_SalesInvoice b where a.InvoiceID = b.InvoiceID and 
                invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3) group by a.InvoiceID,ProductID 
                ) B 
                on a.InvoiceID = b.InvoiceID and a.ProductID = b.ProductID 
                )a 
                Inner Join  
                dbo.t_RetailConsumer b 
                ON a.SundryCustomerID = b.ConsumerID 
                {2}
                ) as final 
                Group By InvoiceID,WarehouseID,Customerid,InvoiceDate,ProductID,CustomerTypeID 
                )as FinalQuery 
                Group by WarehouseID,Customerid,InvoiceDate,ProductID,CustomerTypeID 
                ) as sales, (select CustomerID, CustTypeID from dbo.t_Customer)b 
                Where sales.CustomerID = b.CustomerID 
                and year(InvoiceDate)={0} group by year(InvoiceDate),month(InvoiceDate)
                ---End ThisYearActual---
                Union All
                ---PerviousYearActual---
                Select  year(InvoiceDate) TYear,month(InvoiceDate) TMonth,0 as ThisYearActual,
                sum((GrossSales + OC - sales.VAT - Discount)) as PerviousYearActual,0 as ThisYearTarget
                from 
                ( 
                Select WarehouseID, CustomerID, ProductID, CustomerTypeID, Convert(datetime, replace(convert(varchar, InvoiceDate, 6), '', '-'), 1) as InvoiceDate, isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crFreeQty) - sum(drFreeQty)), 0) as FreeQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, 
                isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crInvoiceAmount) - sum(drInvoiceAmount)), 0) as InvoiceAmount, isnull((sum(crOC) - sum(drOC)), 0) as OC, isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT 
                From 
                ( 
                Select InvoiceID, WarehouseID, Customerid, ProductID, InvoiceDate, CustomerTypeID, sum(quantity) as crqty, 0 as drqty, sum(FreeQty) as crFreeQty, 0 as drFreeQty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, 
                sum(Discount) as crDiscount, 0 as drDiscount, Sum(InvoiceAmount) as crInvoiceAmount, 0 as drInvoiceAmount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT 
                from 
                ( 
                Select a.*, CASE When SalesType = 2 then 245 When SalesType = 3 then 249 else 999 end as CustomerTypeID from 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, 
                a.ProductID, Quantity, GrossSales, 
                case when IsNewInv = 1 then NewDiscount else a.Discount end as Discount, 
                case when IsNewInv = 1 then NewCharge else a.OC end as OC, 
                COGS, VAT, FreeQty, SundryCustomerID 
                From 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, Quantity, (Quantity * unitprice) as GrossSales, 
                CASE When GrossPrice > 0 then(Discount / GrossPrice * (unitprice * Quantity)) else 0 end as Discount, 
                CASE When GrossPrice > 0 then(OtherCharge / GrossPrice * (unitprice * Quantity)) else 0 end as OC, 
                (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT, FreeQty, SundryCustomerID 
                from 
                ( 
                select WarehouseID, sa.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity, FreeQty, OtherCharge, SundryCustomerID 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid 
                and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) 
                ) as a 
                left outer join 
                ( 
                select sa.InvoiceID, Sum(quantity * UnitPrice) as GrossPrice 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid 
                and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) 
                group by sa.InvoiceID, Discount, OtherCharge 
                ) as b on a.invoiceid = b.invoiceid 
                ) A 
                Left Outer Join 
                ( 
                Select a.InvoiceID, 1 as IsNewInv, ProductID, sum(Discounts) NewDiscount, sum(Charges) NewCharge 
                From dbo.t_SalesInvoiceDetailNew a, dbo.t_SalesInvoice b where a.InvoiceID = b.InvoiceID and 
                invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) group by a.InvoiceID, ProductID 
                ) B 
                on a.InvoiceID = b.InvoiceID and a.ProductID = b.ProductID 
                ) a 
                Inner Join  
                dbo.t_RetailConsumer b 
                ON a.SundryCustomerID = b.ConsumerID 
                {2}
                ) as final 
                Group By InvoiceID,WarehouseID,Customerid,InvoiceDate,ProductID,CustomerTypeID 
                Union all 
                Select InvoiceID,WarehouseID,Customerid,ProductID,InvoiceDate,CustomerTypeID,0 as crqty, sum(quantity) as drqty, 0 as crFreeQty, sum(FreeQty) as drFreeQty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,    
                0 as crDiscount,sum(Discount) as drDiscount,0 as crInvoiceAmount,Sum(InvoiceAmount) as drInvoiceAmount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT 
                from 
                ( 
                Select a.*, CASE When SalesType = 2 then 245 When SalesType = 3 then 249 else 999 end as CustomerTypeID from 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, 
                a.ProductID, Quantity, GrossSales, 
                case when isnull(IsNewInv, 0) = 1 then NewDiscount else a.Discount end as Discount, 
                case when isnull(IsNewInv, 0) = 1 then NewCharge else a.OC end as OC, 
                COGS, VAT, FreeQty, SundryCustomerID 
                From 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, Quantity, (Quantity * unitprice) as GrossSales, CASE When GrossPrice > 0 then(Discount / GrossPrice * (unitprice * Quantity)) else 0 end as Discount, 
                CASE When GrossPrice > 0 then(OtherCharge / GrossPrice * (unitprice * Quantity)) else 0 end as OC, 
                (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT, FreeQty, SundryCustomerID 
                from 
                ( 
                select WarehouseID, sa.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity, FreeQty, OtherCharge, SundryCustomerID 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid 
                and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3) 
                ) as a 
                left outer join 
                ( 
                select sa.InvoiceID, Sum(quantity * UnitPrice) as GrossPrice 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3) 
                group by sa.InvoiceID, Discount, OtherCharge 
                ) as b 
                on a.invoiceid = b.invoiceid 
                ) A 
                Left Outer Join 
                ( 
                Select a.InvoiceID, 1 as IsNewInv, ProductID, sum(a.Discounts) NewDiscount, sum(a.Charges) NewCharge 
                From dbo.t_SalesInvoiceDetailNew a, dbo.t_SalesInvoice b where a.InvoiceID = b.InvoiceID and 
                invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3) group by a.InvoiceID,ProductID 
                ) B 
                on a.InvoiceID = b.InvoiceID and a.ProductID = b.ProductID 
                )a 
                Inner Join  
                dbo.t_RetailConsumer b 
                ON a.SundryCustomerID = b.ConsumerID 
                {2}
                ) as final 
                Group By InvoiceID,WarehouseID,Customerid,InvoiceDate,ProductID,CustomerTypeID 
                )as FinalQuery 
                Group by WarehouseID,Customerid,InvoiceDate,ProductID,CustomerTypeID 
                ) as sales, (select CustomerID, CustTypeID from dbo.t_Customer)b 
                Where sales.CustomerID = b.CustomerID 
                and year(InvoiceDate)={1} group by year(InvoiceDate),month(InvoiceDate)
                ---End PerviousYearActual---
                Union All
                ---Target---
                Select TYear,TMonth,0 as ThisYearActual,0 as PerviousYearActual,sum(TargetValue) as ThisYearTarget
                From t_PlanMAGWeekTargetQty where TYear={0} {3} group by TYear,TMonth
                ---End Target---
                ) Main group by TMonth order By TMonth", nThisYear, nLastYear, sSalesTypeString, sChannelString);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oSalesTrandReport = new RetailSalesInvoice();
                    _oSalesTrandReport.SL = Convert.ToInt32(reader["SL"].ToString());
                    _oSalesTrandReport.Month = reader["Month"].ToString();
                    _oSalesTrandReport.ThisYearTarget = Convert.ToDouble(reader["ThisYearTarget"].ToString());
                    _oSalesTrandReport.ThisYearActual = Convert.ToDouble(reader["ThisYearActual"].ToString());
                    _oSalesTrandReport.Achievement = Convert.ToDouble(reader["AchPercentage"].ToString());
                    _oSalesTrandReport.PerviousYearActual = Convert.ToDouble(reader["PerviousYearActual"].ToString());
                    _oSalesTrandReport.GrowthPercentage = Convert.ToDouble(reader["GrowthPercentage"].ToString());
                    InnerList.Add(_oSalesTrandReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void SalesTrandReportNewRT(int nThisYear, int nLastYear, int ReportKey)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            string sSalesTypeString = "";
            string sChannelString = "";
            if (ReportKey == (int)Dictionary.ReportKeyfrmSalesTrandReport.Sales_Trand_All)
            {
                sSalesTypeString = "";
                sChannelString = "";
            }
            if (ReportKey == (int)Dictionary.ReportKeyfrmSalesTrandReport.Sales_Trand_Dealer)
            {
                sSalesTypeString = " where SalesType=" + (int)Dictionary.SalesType.Dealer + "";
                sChannelString = " and Channel in (3,20)";
            }

            if (ReportKey == (int)Dictionary.ReportKeyfrmSalesTrandReport.Sales_Trand_Retail_Other)
            {
                sSalesTypeString = " where SalesType<>" + (int)Dictionary.SalesType.Dealer + "";
                sChannelString = " and Channel not in (3,20)";
            }

            sSql = String.Format(@"Select TMonth as SL,DateName( month , DateAdd( month , TMonth , -1 )) as Month,
                sum(ThisYearTarget) ThisYearTarget,sum(ThisYearActual) ThisYearActual, 
                isnull((sum(ThisYearActual)/nullif(sum(ThisYearTarget),0)*100),0) as AchPercentage,sum(PerviousYearActual) PerviousYearActual, 
                isnull(((sum(ThisYearActual)-sum(PerviousYearActual))/nullif(sum(PerviousYearActual),0)*100),0) as GrowthPercentage  From 
                (
                ---ThisYearActual---
                Select  year(InvoiceDate) TYear,month(InvoiceDate) TMonth,sum((GrossSales + OC - sales.VAT - Discount)) as ThisYearActual,
                0 as PerviousYearActual,0 as ThisYearTarget
                from 
                ( 
                Select WarehouseID, CustomerID, ProductID, CustomerTypeID, Convert(datetime, replace(convert(varchar, InvoiceDate, 6), '', '-'), 1) as InvoiceDate, isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crFreeQty) - sum(drFreeQty)), 0) as FreeQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, 
                isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crInvoiceAmount) - sum(drInvoiceAmount)), 0) as InvoiceAmount, isnull((sum(crOC) - sum(drOC)), 0) as OC, isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT 
                From 
                ( 
                Select InvoiceID, WarehouseID, Customerid, ProductID, InvoiceDate, CustomerTypeID, sum(quantity) as crqty, 0 as drqty, sum(FreeQty) as crFreeQty, 0 as drFreeQty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, 
                sum(Discount) as crDiscount, 0 as drDiscount, Sum(InvoiceAmount) as crInvoiceAmount, 0 as drInvoiceAmount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT 
                from 
                ( 
                Select a.*, CASE When SalesType = 2 then 245 When SalesType = 3 then 249 else 999 end as CustomerTypeID from 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, 
                a.ProductID, Quantity, GrossSales, 
                case when IsNewInv = 1 then NewDiscount else a.Discount end as Discount, 
                case when IsNewInv = 1 then NewCharge else a.OC end as OC, 
                COGS, VAT, FreeQty, SundryCustomerID 
                From 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, Quantity, (Quantity * unitprice) as GrossSales, 
                CASE When GrossPrice > 0 then(Discount / GrossPrice * (unitprice * Quantity)) else 0 end as Discount, 
                CASE When GrossPrice > 0 then(OtherCharge / GrossPrice * (unitprice * Quantity)) else 0 end as OC, 
                (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT, FreeQty, SundryCustomerID 
                from 
                ( 
                select WarehouseID, sa.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity, FreeQty, OtherCharge, SundryCustomerID 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid 
                and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) 
                ) as a 
                left outer join 
                ( 
                select sa.InvoiceID, Sum(quantity * UnitPrice) as GrossPrice 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid 
                and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) 
                group by sa.InvoiceID, Discount, OtherCharge 
                ) as b on a.invoiceid = b.invoiceid 
                ) A 
                Left Outer Join 
                ( 
                Select a.InvoiceID, 1 as IsNewInv, ProductID, sum(Discounts) NewDiscount, sum(Charges) NewCharge 
                From dbo.t_SalesInvoiceDetailNew a, dbo.t_SalesInvoice b where a.InvoiceID = b.InvoiceID and 
                invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) group by a.InvoiceID, ProductID 
                ) B 
                on a.InvoiceID = b.InvoiceID and a.ProductID = b.ProductID 
                ) a 
                Inner Join 
                dbo.t_RetailConsumer b 
                ON a.SundryCustomerID = b.ConsumerID 
                {2}
                ) as final 
                Group By InvoiceID,WarehouseID,Customerid,InvoiceDate,ProductID,CustomerTypeID 
                Union all 
                Select InvoiceID,WarehouseID,Customerid,ProductID,InvoiceDate,CustomerTypeID,0 as crqty, sum(quantity) as drqty, 0 as crFreeQty, sum(FreeQty) as drFreeQty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,    
                0 as crDiscount,sum(Discount) as drDiscount,0 as crInvoiceAmount,Sum(InvoiceAmount) as drInvoiceAmount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT 
                from 
                ( 
                Select a.*, CASE When SalesType = 2 then 245 When SalesType = 3 then 249 else 999 end as CustomerTypeID from 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, 
                a.ProductID, Quantity, GrossSales, 
                case when isnull(IsNewInv, 0) = 1 then NewDiscount else a.Discount end as Discount, 
                case when isnull(IsNewInv, 0) = 1 then NewCharge else a.OC end as OC, 
                COGS, VAT, FreeQty, SundryCustomerID 
                From 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, Quantity, (Quantity * unitprice) as GrossSales, CASE When GrossPrice > 0 then(Discount / GrossPrice * (unitprice * Quantity)) else 0 end as Discount, 
                CASE When GrossPrice > 0 then(OtherCharge / GrossPrice * (unitprice * Quantity)) else 0 end as OC, 
                (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT, FreeQty, SundryCustomerID 
                from 
                ( 
                select WarehouseID, sa.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity, FreeQty, OtherCharge, SundryCustomerID 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid 
                and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3) 
                ) as a 
                left outer join 
                ( 
                select sa.InvoiceID, Sum(quantity * UnitPrice) as GrossPrice 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3) 
                group by sa.InvoiceID, Discount, OtherCharge 
                ) as b 
                on a.invoiceid = b.invoiceid 
                ) A 
                Left Outer Join 
                ( 
                Select a.InvoiceID, 1 as IsNewInv, ProductID, sum(a.Discounts) NewDiscount, sum(a.Charges) NewCharge 
                From dbo.t_SalesInvoiceDetailNew a, dbo.t_SalesInvoice b where a.InvoiceID = b.InvoiceID and 
                invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3) group by a.InvoiceID,ProductID 
                ) B 
                on a.InvoiceID = b.InvoiceID and a.ProductID = b.ProductID 
                )a 
                Inner Join  
                dbo.t_RetailConsumer b 
                ON a.SundryCustomerID = b.ConsumerID 
                {2}
                ) as final 
                Group By InvoiceID,WarehouseID,Customerid,InvoiceDate,ProductID,CustomerTypeID 
                )as FinalQuery 
                Group by WarehouseID,Customerid,InvoiceDate,ProductID,CustomerTypeID 
                ) as sales, (select CustomerID, CustTypeID from dbo.t_Customer)b 
                Where sales.CustomerID = b.CustomerID 
                and year(InvoiceDate)={0} group by year(InvoiceDate),month(InvoiceDate)
                ---End ThisYearActual---
                Union All
                ---PerviousYearActual---
                Select  year(InvoiceDate) TYear,month(InvoiceDate) TMonth,0 as ThisYearActual,
                sum((GrossSales + OC - sales.VAT - Discount)) as PerviousYearActual,0 as ThisYearTarget
                from 
                ( 
                Select WarehouseID, CustomerID, ProductID, CustomerTypeID, Convert(datetime, replace(convert(varchar, InvoiceDate, 6), '', '-'), 1) as InvoiceDate, isnull((sum(crqty) - sum(drqty)), 0) as SalesQty, isnull((sum(crFreeQty) - sum(drFreeQty)), 0) as FreeQty, isnull((sum(crGrossSales) - sum(drGrossSales)), 0) as GrossSales, 
                isnull((sum(crDiscount) - sum(drDiscount)), 0) as Discount, isnull((sum(crInvoiceAmount) - sum(drInvoiceAmount)), 0) as InvoiceAmount, isnull((sum(crOC) - sum(drOC)), 0) as OC, isnull((sum(crCOGS) - sum(drCOGS)), 0) as COGS, isnull((sum(crVAT) - sum(drVAT)), 0) as VAT 
                From 
                ( 
                Select InvoiceID, WarehouseID, Customerid, ProductID, InvoiceDate, CustomerTypeID, sum(quantity) as crqty, 0 as drqty, sum(FreeQty) as crFreeQty, 0 as drFreeQty, sum(GrossSales) as crGrossSales, 0 as drGrossSales, 
                sum(Discount) as crDiscount, 0 as drDiscount, Sum(InvoiceAmount) as crInvoiceAmount, 0 as drInvoiceAmount, sum(OC) as crOC, 0 as drOC, sum(COGS) as crCOGS, 0 as drCOGS, sum(VAT) as crVAT, 0 as drVAT 
                from 
                ( 
                Select a.*, CASE When SalesType = 2 then 245 When SalesType = 3 then 249 else 999 end as CustomerTypeID from 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, 
                a.ProductID, Quantity, GrossSales, 
                case when IsNewInv = 1 then NewDiscount else a.Discount end as Discount, 
                case when IsNewInv = 1 then NewCharge else a.OC end as OC, 
                COGS, VAT, FreeQty, SundryCustomerID 
                From 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, Quantity, (Quantity * unitprice) as GrossSales, 
                CASE When GrossPrice > 0 then(Discount / GrossPrice * (unitprice * Quantity)) else 0 end as Discount, 
                CASE When GrossPrice > 0 then(OtherCharge / GrossPrice * (unitprice * Quantity)) else 0 end as OC, 
                (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT, FreeQty, SundryCustomerID 
                from 
                ( 
                select WarehouseID, sa.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity, FreeQty, OtherCharge, SundryCustomerID 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid 
                and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) 
                ) as a 
                left outer join 
                ( 
                select sa.InvoiceID, Sum(quantity * UnitPrice) as GrossPrice 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid 
                and invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) 
                group by sa.InvoiceID, Discount, OtherCharge 
                ) as b on a.invoiceid = b.invoiceid 
                ) A 
                Left Outer Join 
                ( 
                Select a.InvoiceID, 1 as IsNewInv, ProductID, sum(Discounts) NewDiscount, sum(Charges) NewCharge 
                From dbo.t_SalesInvoiceDetailNew a, dbo.t_SalesInvoice b where a.InvoiceID = b.InvoiceID and 
                invoicetypeid in (1, 2, 4, 5)and invoicestatus not in (3) group by a.InvoiceID, ProductID 
                ) B 
                on a.InvoiceID = b.InvoiceID and a.ProductID = b.ProductID 
                ) a 
                Inner Join  
                dbo.t_RetailConsumer b 
                ON a.SundryCustomerID = b.ConsumerID 
                {2}
                ) as final 
                Group By InvoiceID,WarehouseID,Customerid,InvoiceDate,ProductID,CustomerTypeID 
                Union all 
                Select InvoiceID,WarehouseID,Customerid,ProductID,InvoiceDate,CustomerTypeID,0 as crqty, sum(quantity) as drqty, 0 as crFreeQty, sum(FreeQty) as drFreeQty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,    
                0 as crDiscount,sum(Discount) as drDiscount,0 as crInvoiceAmount,Sum(InvoiceAmount) as drInvoiceAmount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT 
                from 
                ( 
                Select a.*, CASE When SalesType = 2 then 245 When SalesType = 3 then 249 else 999 end as CustomerTypeID from 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, 
                a.ProductID, Quantity, GrossSales, 
                case when isnull(IsNewInv, 0) = 1 then NewDiscount else a.Discount end as Discount, 
                case when isnull(IsNewInv, 0) = 1 then NewCharge else a.OC end as OC, 
                COGS, VAT, FreeQty, SundryCustomerID 
                From 
                ( 
                Select WarehouseID, a.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, Quantity, (Quantity * unitprice) as GrossSales, CASE When GrossPrice > 0 then(Discount / GrossPrice * (unitprice * Quantity)) else 0 end as Discount, 
                CASE When GrossPrice > 0 then(OtherCharge / GrossPrice * (unitprice * Quantity)) else 0 end as OC, 
                (Quantity * Costprice) as COGS, (Quantity * Tradeprice * vatamount) as VAT, FreeQty, SundryCustomerID 
                from 
                ( 
                select WarehouseID, sa.InvoiceID, InvoiceDate, InvoiceAmount, CustomerID, ProductID, UnitPrice, Costprice, TradePrice, VatAmount, Discount, quantity, FreeQty, OtherCharge, SundryCustomerID 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid 
                and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3) 
                ) as a 
                left outer join 
                ( 
                select sa.InvoiceID, Sum(quantity * UnitPrice) as GrossPrice 
                from dbo.t_salesinvoice sa, dbo.t_salesinvoicedetail sd 
                where sa.invoiceid = sd.invoiceid and invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3) 
                group by sa.InvoiceID, Discount, OtherCharge 
                ) as b 
                on a.invoiceid = b.invoiceid 
                ) A 
                Left Outer Join 
                ( 
                Select a.InvoiceID, 1 as IsNewInv, ProductID, sum(a.Discounts) NewDiscount, sum(a.Charges) NewCharge 
                From dbo.t_SalesInvoiceDetailNew a, dbo.t_SalesInvoice b where a.InvoiceID = b.InvoiceID and 
                invoicetypeid in (6, 7, 9, 10, 12)and invoicestatus not in (3) group by a.InvoiceID,ProductID 
                ) B 
                on a.InvoiceID = b.InvoiceID and a.ProductID = b.ProductID 
                )a 
                Inner Join  
                dbo.t_RetailConsumer b 
                ON a.SundryCustomerID = b.ConsumerID 
                {2}
                ) as final 
                Group By InvoiceID,WarehouseID,Customerid,InvoiceDate,ProductID,CustomerTypeID 
                )as FinalQuery 
                Group by WarehouseID,Customerid,InvoiceDate,ProductID,CustomerTypeID 
                ) as sales, (select CustomerID, CustTypeID from dbo.t_Customer)b 
                Where sales.CustomerID = b.CustomerID 
                and year(InvoiceDate)={1} group by year(InvoiceDate),month(InvoiceDate)
                ---End PerviousYearActual---
                Union All
                ---Target---
                Select TYear,TMonth,0 as ThisYearActual,0 as PerviousYearActual,sum(TargetValue) as ThisYearTarget
                From t_PlanMAGWeekTargetQty where TYear={0} {3} group by TYear,TMonth
                ---End Target---
                ) Main group by TMonth order By TMonth", nThisYear, nLastYear, sSalesTypeString, sChannelString);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oSalesTrandReport = new RetailSalesInvoice();
                    _oSalesTrandReport.SL = Convert.ToInt32(reader["SL"].ToString());
                    _oSalesTrandReport.Month = reader["Month"].ToString();
                    _oSalesTrandReport.ThisYearTarget = Convert.ToDouble(reader["ThisYearTarget"].ToString());
                    _oSalesTrandReport.ThisYearActual = Convert.ToDouble(reader["ThisYearActual"].ToString());
                    _oSalesTrandReport.Achievement = Convert.ToDouble(reader["AchPercentage"].ToString());
                    _oSalesTrandReport.PerviousYearActual = Convert.ToDouble(reader["PerviousYearActual"].ToString());
                    _oSalesTrandReport.GrowthPercentage = Convert.ToDouble(reader["GrowthPercentage"].ToString());
                    InnerList.Add(_oSalesTrandReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetEMIData(DateTime dFromDate, DateTime dToDate, int nWarehouseID, int nBankID, int nStatus, string sInvoiceNo, bool IsCheck)//Shuvo:Date:28-Apr-2016
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From (Select a.*,isnull(ID,0) as ID,isnull(Status,0) Status,CreateDate From  " +
                       " (Select * From (Select b.WarehouseID,ShowroomCode,a.InvoiceID,InvoiceNo,InvoiceDate,  " +
                       " a.PaymentModeID,PaymentModeName,Amount,a.BankID,Name as BankName,   " +
                       " CardType=Case when CardType= 1 then 'VISA'  " +
                       " when CardType= 2 then 'MASTER'  " +
                       " when CardType= 3 then 'AMEX'  " +
                       " when CardType= 4 then 'NEXUS'  " +
                       " when CardType= 5 then 'JCB'  " +
                       " else 'Other' end,PosMachineID,AssetName,isnull(NoOfInstallment,'') NoOfInstallment,  " +
                       " isnull(InstrumentNo,'')InstrumentNo,isnull(InstrumentDate,InvoiceDate) InstrumentDate,  " +
                       " CardCategory=Case When CardCategory=1 then 'DebitCard'  " +
                       " When CardCategory=2 then 'CreditCard' else 'Other' end,isnull(ApprovalNo,'') ApprovalNo  " +
                       " From t_SalesInvoicePaymentMode a,t_SalesInvoice b,t_PaymentMode c,  " +
                       " t_bank d,t_ShowroomAsset e,t_Showroom f  " +
                       " where a.InvoiceID=b.InvoiceID and a.PaymentModeID=c.PaymentModeID and   " +
                       " a.BankID=d.BankID and a.PosMachineID=e.AssetID and b.WarehouseID=f.WarehouseID and a.IsEMI=1 and   " +
                       " InvoiceTypeID not in (6,7,8,9,10,11,12) ) x) a  " +
                       " Left Outer Join  " +
                       " (Select * From t_EMIManagement) b  " +
                       " on a.InvoiceID=b.InvoiceID and a.BankID=b.BankID and a.Amount=b.Amount) Main where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "' ";
            }
            if (nWarehouseID != -1)
            {
                sSql = sSql + " AND WarehouseID=" + nWarehouseID + "";
            }
            if (nBankID != -1)
            {
                sSql = sSql + " AND BankID=" + nBankID + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo like '%" + sInvoiceNo + "%'";
            }
            sSql = sSql + " Order by InvoiceDate DESC";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oEMIData = new RetailSalesInvoice();
                    _oEMIData.WarehouseID = Convert.ToInt32(reader["WarehouseID"].ToString());
                    _oEMIData.ShowroomCode = reader["ShowroomCode"].ToString();
                    _oEMIData.InvoiceID = Convert.ToInt32(reader["InvoiceID"].ToString());
                    _oEMIData.InvoiceNo = reader["InvoiceNo"].ToString();
                    _oEMIData.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _oEMIData.PaymentModeID = Convert.ToInt32(reader["PaymentModeID"].ToString());
                    _oEMIData.PaymentModeName = reader["PaymentModeName"].ToString();
                    _oEMIData.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _oEMIData.BankID = Convert.ToInt32(reader["BankID"].ToString());
                    _oEMIData.BankName = reader["BankName"].ToString();
                    _oEMIData.CardTypeName = reader["CardType"].ToString();
                    _oEMIData.POSMachineID = Convert.ToInt32(reader["POSMachineID"].ToString());
                    _oEMIData.POSMachineName = reader["AssetName"].ToString();
                    _oEMIData.NoOfInstallment = Convert.ToInt32(reader["NoOfInstallment"].ToString());
                    _oEMIData.InstrumentNo = reader["InstrumentNo"].ToString();
                    _oEMIData.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    _oEMIData.CardCategoryName = reader["CardCategory"].ToString();
                    _oEMIData.ApprovalNo = reader["ApprovalNo"].ToString();
                    _oEMIData.ID = Convert.ToInt32(reader["ID"].ToString());

                    //if (_oEMIData.CreateDate != DBNull.Value)
                    //{
                    //    _oEMIData.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    //}
                    //else
                    //{
                    //    _oEMIData.CreateDate = "";
                    //}
                    _oEMIData.Status = Convert.ToInt32(reader["Status"].ToString());
                    InnerList.Add(_oEMIData);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void TgtVsAchMAGWiseWeek(DateTime FirstDateOfThisMonth, DateTime LastDateOfThisMonth, int nTGTYear, int nTGTMonth)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select a.*,isnull(nullif(SalesQty,0)/nullif(CAST(TargetQty as float),0)*100,0) as QtyPercentage,isnull(nullif(NetSales,0)/nullif(CAST(TargetValue as float),0)*100,0) as ValuePercentage From  " +
                "(Select a.*,isnull(SalesQty,0) SalesQty,isnull(NetSales,0) NetSales From  " +
                "(Select a.*,PDTGroupName as MAGName,BrandDesc as Brand From t_PlanMAGWeekTargetQty a,t_Brand b,t_ProductGroup c  " +
                "where a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID and TYear=" + nTGTYear + " and TMonth=" + nTGTMonth + ") a  " +
                "Left Outer Join   " +
                "(Select * From   " +
                "(Select Channel=Case when SalesType=1 then 'Retail'  " +
                "when SalesType=2 then 'B2C'  " +
                "when SalesType=3 then 'B2B'  " +
                "when SalesType=4 then 'HPA'  " +
                "when SalesType=5 then 'Dealer'  " +
                "when SalesType=6 then 'ECommerceLead'  " +
                "else 'Other' end,TYear,TMonth,WeekNo,BrandID,BrandDesc,MAGID,MAGName,sum(SalesQty) as SalesQty,sum(NetSales) as NetSales From   " +
                "(  " +
                "Select SalesType,TYear,TMonth,WeekNo,BrandID,BrandDesc,MAGID,MAGName,SalesQty,(GrossSales+OC-Main.VAT-Discount) as NetSales From   " +
                "(Select SalesType,TYear,TMonth,WeekNo,ProductID, isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,  " +
                "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT  " +
                "From  " +
                "(  " +
                "Select SalesType,TYear,WeekNo,TMonth,ProductID,sum(quantity)as crqty, 0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales,  " +
                "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS, 0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT  " +
                "from  " +
                "(  " +
                "Select SalesType,a.InvoiceID,WeekNo,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,  " +
                "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT  " +
                "from  " +
                "(  " +
                "select SalesType,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,month(invoicedate) as TMonth,  " +
                "ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity  " +
                "from t_salesinvoice sa, t_salesinvoicedetail sd,t_RetailConsumer sc,t_CalendarWeek  " +
                "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and   " +
                "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate < '" + LastDateOfThisMonth + "'  " +
                "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate   " +
                "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)   " +
                ")as a  " +
                "left outer join  " +
                "(  " +
                "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC  " +
                "from t_salesinvoice sa, t_salesinvoicedetail sd  " +
                "where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate < '" + LastDateOfThisMonth + "'  " +
                "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)   " +
                "group by sa.InvoiceID,Discount,OtherCharge  " +
                ") as b on a.invoiceid = b.invoiceid  " +
                ") as final  " +
                "Group By SalesType,TYear,TMonth,WeekNo,ProductID  " +
                "Union all  " +
                "Select SalesType,TYear,WeekNo,TMonth,ProductID,0 as crqty, sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,  " +
                "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT  " +
                "from  " +
                "(  " +
                "Select a.InvoiceID,WeekNo,TYear,TMonth,SalesType,ProductID,Quantity,(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,  " +
                "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT  " +
                "from  " +
                "(  " +
                "select sa.InvoiceID,WeekNo,year(invoicedate) as TYear,month(invoicedate) as TMonth,  " +
                "SalesType,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity  " +
                "from t_salesinvoice sa, t_salesinvoicedetail sd,t_Retailconsumer sc,t_CalendarWeek  " +
                "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and   " +
                "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate < '" + LastDateOfThisMonth + "'  " +
                "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate   " +
                "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   " +
                ")as a  " +
                "left outer join  " +
                "(  " +
                "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC  " +
                "from t_salesinvoice sa, t_salesinvoicedetail sd  " +
                "where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate < '" + LastDateOfThisMonth + "'  " +
                "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   " +
                "group by sa.InvoiceID,Discount,OtherCharge  " +
                ") as b on a.invoiceid = b.invoiceid  " +
                ") as final  " +
                "Group By SalesType,WeekNo,TYear,TMonth,ProductID  " +
                ")as FinalQuery  " +
                "Group by  " +
                "SalesType,WeekNo,TYear,TMonth,ProductID  " +
                ") Main   " +
                "inner join  " +
                "(  " +
                "Select * from v_productdetails  " +
                ") as p on Main.productid = p.productid  " +
                ") Sales group by SalesType,TYear,TMonth,WeekNo,MAGID,MAGName,BrandID,BrandDesc) as x) b  " +
                "on a.Channel=b.Channel and a.TYear=b.TYear and a.TMonth=b.TMonth  " +
                "and a.WeekNo=b.WeekNo and a.MAGID=b.MAGID and a.BrandID=b.BrandID) a where 1=1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();
                    _oDailySalesReport.TYear = Convert.ToInt32(reader["TYear"].ToString());
                    _oDailySalesReport.TMonth = Convert.ToInt32(reader["TMonth"].ToString());
                    _oDailySalesReport.TWeek = Convert.ToInt32(reader["WeekNo"].ToString());
                    _oDailySalesReport.MAGName = reader["MAGName"].ToString();
                    _oDailySalesReport.Brand = reader["Brand"].ToString();
                    _oDailySalesReport.Channel = reader["Channel"].ToString();
                    _oDailySalesReport.Target = Convert.ToDouble(reader["TargetValue"].ToString());
                    _oDailySalesReport.TargetQty = Convert.ToInt32(reader["TargetQty"].ToString());
                    _oDailySalesReport.NetSales = Convert.ToDouble(reader["NetSales"].ToString());
                    _oDailySalesReport.SalesQty = Convert.ToInt32(reader["SalesQty"].ToString());
                    _oDailySalesReport.QtyPercentage = Convert.ToDouble(reader["QtyPercentage"].ToString());
                    _oDailySalesReport.ValuePercentage = Convert.ToDouble(reader["ValuePercentage"].ToString());
                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void MAGWeekTgtVsAch(DateTime FirstDateOfThisMonth, DateTime LastDateOfThisMonth, int nTGTYear, int nTGTMonth, int nTGTWeek)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = "Select Main.*, " +
                        "isnull(nullif(RetailSalesQty,0)/nullif(CAST(RetailTGTQty as float),0)*100,0) as RTLQtyPercentage, " +
                        "isnull(nullif(DealerSalesQty,0)/nullif(CAST(DealerTGTQty as float),0)*100,0) as DealerQtyPercentage, " +
                        "isnull(nullif(B2BSalesQty,0)/nullif(CAST(B2BTGTQty as float),0)*100,0) as B2BQtyPercentage, " +
                        "isnull(nullif(eStoreSalesQty,0)/nullif(CAST(eStoreTGTQty as float),0)*100,0) as eStoreQtyPercentage, " +
                        "isnull(nullif(RetailSalesVal,0)/nullif(CAST(RetailTGTVal as float),0)*100,0) as RTLValPercentage, " +
                        "isnull(nullif(DealerSalesVal,0)/nullif(CAST(DealerTGTVal as float),0)*100,0) as DealerValPercentage, " +
                        "isnull(nullif(B2BSalesVal,0)/nullif(CAST(B2BTGTVal as float),0)*100,0) as B2BValPercentage, " +
                        "isnull(nullif(eStoreSalesVal,0)/nullif(CAST(eStoreTGTVal as float),0)*100,0) as eStoreValPercentage, " +
                        "isnull(RetailSalesQty+DealerSalesQty+B2BSalesQty+eStoreSalesQty,0) as TotalSalesQty, " +
                        "isnull(RetailTGTQty+DealerTGTQty+B2BTGTQty+eStoreTGTQty,0) as TotalTGTQty, " +
                        "isnull(nullif(RetailSalesQty+DealerSalesQty+B2BSalesQty+eStoreSalesQty,0)/nullif(CAST((RetailTGTQty+DealerTGTQty+B2BTGTQty+eStoreTGTQty) as float),0)*100,0) as TotalQtyPercentage, " +
                        "isnull(RetailSalesVal+DealerSalesVal+B2BSalesVal+eStoreSalesVal,0) as TotalSalesVal, " +
                        "isnull(RetailTGTVal+DealerTGTVal+B2BTGTVal+eStoreTGTVal,0) as TotalTGTVal, " +
                        "isnull(nullif(RetailSalesVal+DealerSalesVal+B2BSalesVal+eStoreSalesVal,0)/nullif(CAST((RetailTGTVal+DealerTGTVal+B2BTGTVal+eStoreTGTVal) as float),0)*100,0) as TotalValPercentage " +
                        "From  " +
                        "( " +
                        "Select TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName, " +
                        "sum(RetailTGTQty) RetailTGTQty,sum(DealerTGTQty) DealerTGTQty,sum(B2BTGTQty) B2BTGTQty,sum(eStoreTGTQty) eStoreTGTQty, " +
                        "sum(RetailSalesQty) RetailSalesQty,sum(DealerSalesQty) DealerSalesQty,sum(B2BSalesQty) B2BSalesQty,sum(eStoreSalesQty) eStoreSalesQty, " +
                        "sum(RetailTGTVal) RetailTGTVal,sum(DealerTGTVal) DealerTGTVal,sum(B2BTGTVal) B2BTGTVal,sum(eStoreTGTVal) eStoreTGTVal, " +
                        "sum(RetailSalesVal) RetailSalesVal,sum(DealerSalesVal) DealerSalesVal,sum(B2BSalesVal) B2BSalesVal,sum(eStoreSalesVal) eStoreSalesVal " +
                        "From  " +
                        "( " +
                        "Select TYear,TMonth,WeekNo,a.BrandID,BrandDesc as Brand,a.MAGID,c.PDTGroupName as MAGName, " +
                        "d.PdtGroupID as PGID,d.PDTGroupName as PGName, " +
                        "sum(case Channel when 4 then TargetQty else 0 end) as RetailTGTQty, " +
                        "sum(case Channel when 3 then TargetQty else 0 end) as DealerTGTQty, " +
                        "sum(case Channel when 13 then TargetQty else 0 end) as B2BTGTQty, " +
                        "sum(case Channel when 16 then TargetQty else 0 end) as eStoreTGTQty, " +
                        "sum(case Channel when 4 then TargetValue else 0 end) as RetailTGTVal, " +
                        "sum(case Channel when 3 then TargetValue else 0 end) as DealerTGTVal, " +
                        "sum(case Channel when 13 then TargetValue else 0 end) as B2BTGTVal, " +
                        "sum(case Channel when 16 then TargetValue else 0 end) as eStoreTGTVal, " +
                        "0 RetailSalesQty,0 DealerSalesQty,0 B2BSalesQty,0 eStoreSalesQty, " +
                        "0 RetailSalesVal,0 DealerSalesVal,0 B2BSalesVal,0 eStoreSalesVal " +
                        "From t_PlanMAGWeekTargetQty a,t_Brand b,t_ProductGroup c,t_ProductGroup d   " +
                        "where a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID " +
                        "and TYear=" + nTGTYear + " and TMonth=" + nTGTMonth + " and TargetValue>0  " +
                        "group by TYear,TMonth,WeekNo,a.BrandID,BrandDesc, " +
                        "a.MAGID,c.PDTGroupName,d.PdtGroupID,d.PDTGroupName,TargetQty,TargetValue " +
                        "Union All " +
                        "Select TYear,TMonth,WeekNo,BrandID,BrandDesc,MAGID,MAGName,PGID,PGName, " +
                        "0 RetailTGTQty,0 DealerTGTQty,0 B2BTGTQty,0 eStoreTGTQty, " +
                        "0 RetailTGTValue,0 DealerTGTValue,0 B2BTGTValue,0 eStoreTGTValue, " +
                        "(RetailSalesQty+B2CSalesQty+HPASalesQty) RetailSalesQty,DealerSalesQty,B2BSalesQty,eStoreSalesQty, " +
                        "(RetailSalesVal+B2CSalesVal+HPASalesVal) RetailSalesVal,DealerSalesVal,B2BSalesVal,eStoreSalesVal From    " +
                        "( " +
                        "Select TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID,MAGName, " +
                        "sum(case SalesType when 1 then SalesQty else 0 end) as RetailSalesQty, " +
                        "sum(case SalesType when 2 then SalesQty else 0 end) as B2CSalesQty, " +
                        "sum(case SalesType when 4 then SalesQty else 0 end) as HPASalesQty, " +
                        "sum(case SalesType when 5 then SalesQty else 0 end) as DealerSalesQty, " +
                        "sum(case SalesType when 3 then SalesQty else 0 end) as B2BSalesQty, " +
                        "sum(case SalesType when 6 then SalesQty else 0 end) as eStoreSalesQty, " +
                        "sum(case SalesType when 1 then NetSales else 0 end) as RetailSalesVal, " +
                        "sum(case SalesType when 2 then NetSales else 0 end) as B2CSalesVal, " +
                        "sum(case SalesType when 4 then NetSales else 0 end) as HPASalesVal, " +
                        "sum(case SalesType when 5 then NetSales else 0 end) as DealerSalesVal, " +
                        "sum(case SalesType when 3 then NetSales else 0 end) as B2BSalesVal, " +
                        "sum(case SalesType when 6 then NetSales else 0 end) as eStoreSalesVal " +
                        "From    " +
                        "(   " +
                        "Select SalesType,TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID, " +
                        "MAGName,SalesQty,(GrossSales+OC-Main.VAT-Discount) as NetSales  " +
                        "From ( " +
                        "Select SalesType,TYear,TMonth,WeekNo,ProductID,  " +
                        "isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,   " +
                        "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC, " +
                        "isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT   " +
                        "From   " +
                        "( " +
                        "Select SalesType,TYear,WeekNo,TMonth,ProductID,sum(quantity)as crqty,  " +
                        "0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales,   " +
                        "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS,  " +
                        "0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT  from  (  Select SalesType,a.InvoiceID, " +
                        "WeekNo,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales, " +
                        "(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,   " +
                        "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT   " +
                        "from  (   " +
                        "select SalesType,sa.InvoiceID,WeekNo,year(invoicedate) as TYear, " +
                        "month(invoicedate) as TMonth,  ProductID,UnitPrice,Costprice, " +
                        "TradePrice,VatAmount,Discount,quantity   " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,t_RetailConsumer sc,t_CalendarWeek   " +
                        "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and    " +
                        "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'  " +
                        "and invoicedate < '" + LastDateOfThisMonth + "'   " +
                        "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate    " +
                        "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)    " +
                        ")as a   " +
                        "left outer join   " +
                        "(   " +
                        "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc, " +
                        "isnull((OtherCharge/sum(quantity)),0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd   " +
                        "where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'  " +
                        "and invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (1,2,4,5)and  " +
                        "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge   " +
                        ") as b  " +
                        "on a.invoiceid = b.invoiceid  ) as final  Group By SalesType,TYear,TMonth,WeekNo,ProductID   " +
                        "Union all   " +
                        "Select SalesType,TYear,WeekNo,TMonth,ProductID,0 as crqty,  " +
                        "sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,   " +
                        "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC, " +
                        "0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT   " +
                        "from  (   " +
                        "Select a.InvoiceID,WeekNo,TYear,TMonth,SalesType,ProductID,Quantity, " +
                        "(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,   " +
                        "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT   " +
                        "from  (   " +
                        "select sa.InvoiceID,WeekNo,year(invoicedate) as TYear,month(invoicedate) as TMonth,   " +
                        "SalesType,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity   " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,t_Retailconsumer sc,t_CalendarWeek   " +
                        "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and    " +
                        "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate < '" + LastDateOfThisMonth + "'   " +
                        "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate    " +
                        "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   )as a   " +
                        "left outer join   " +
                        "(   " +
                        "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC   " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd   " +
                        "where sa.invoiceid = sd.invoiceid and invoicedate  " +
                        "between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and  " +
                        "invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (6,7,9,10,12)and  " +
                        "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge   " +
                        ") as b  " +
                        "on a.invoiceid = b.invoiceid   " +
                        ") as final   " +
                        "Group By SalesType,WeekNo,TYear,TMonth,ProductID   " +
                        ")as FinalQuery   " +
                        "Group by  SalesType,WeekNo,TYear,TMonth,ProductID   " +
                        ") Main    " +
                        "inner join   " +
                        "(   " +
                        "Select * from v_productdetails  ) as p on Main.productid = p.productid   " +
                        ") Sales  " +
                        "group by SalesType,TYear,TMonth,WeekNo,MAGID,MAGName,PGID,PGName,BrandID,BrandDesc) as Sales " +
                        ") a " +
                        "group by TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName " +
                        ") Main where 1=1";
            }
            if (nTGTWeek != -1)
            {
                sSql = sSql + " AND WeekNo=" + nTGTWeek + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();
                    _oDailySalesReport.TYear = Convert.ToInt32(reader["TYear"].ToString());
                    _oDailySalesReport.TMonth = Convert.ToInt32(reader["TMonth"].ToString());
                    _oDailySalesReport.TWeek = Convert.ToInt32(reader["WeekNo"].ToString());
                    _oDailySalesReport.MAGName = reader["MAGName"].ToString();
                    _oDailySalesReport.Brand = reader["Brand"].ToString();
                    _oDailySalesReport.PGName = reader["PGName"].ToString();

                    _oDailySalesReport.RTLTGRQty = Convert.ToInt32(reader["RetailTGTQty"].ToString());
                    _oDailySalesReport.RTLSalesQty = Convert.ToInt32(reader["RetailSalesQty"].ToString());
                    _oDailySalesReport.DealerTGTQty = Convert.ToInt32(reader["DealerTGTQty"].ToString());
                    _oDailySalesReport.DealerSalesQty = Convert.ToInt32(reader["DealerSalesQty"].ToString());
                    _oDailySalesReport.B2BTGTQty = Convert.ToInt32(reader["B2BTGTQty"].ToString());
                    _oDailySalesReport.B2BSalesQty = Convert.ToInt32(reader["B2BSalesQty"].ToString());
                    _oDailySalesReport.eStoreTGTQty = Convert.ToInt32(reader["eStoreTGTQty"].ToString());
                    _oDailySalesReport.eStoreSalesQty = Convert.ToInt32(reader["eStoreSalesQty"].ToString());

                    _oDailySalesReport.RetailTGTVal = Convert.ToDouble(reader["RetailTGTVal"].ToString());
                    _oDailySalesReport.RTLSalesVal = Convert.ToDouble(reader["RetailSalesVal"].ToString());
                    _oDailySalesReport.DealerTGTVal = Convert.ToDouble(reader["DealerTGTVal"].ToString());
                    _oDailySalesReport.DealerSalesVal = Convert.ToDouble(reader["DealerSalesVal"].ToString());
                    _oDailySalesReport.B2BTGTVal = Convert.ToDouble(reader["B2BTGTVal"].ToString());
                    _oDailySalesReport.B2BSalesVal = Convert.ToDouble(reader["B2BSalesVal"].ToString());
                    _oDailySalesReport.eStoreTGTVal = Convert.ToDouble(reader["eStoreTGTVal"].ToString());
                    _oDailySalesReport.eStoreSalesVal = Convert.ToDouble(reader["eStoreSalesVal"].ToString());

                    _oDailySalesReport.RTLQtyPercentage = Convert.ToDouble(reader["RTLQtyPercentage"].ToString());
                    _oDailySalesReport.DealerQtyPercentage = Convert.ToDouble(reader["DealerQtyPercentage"].ToString());
                    _oDailySalesReport.B2BQtyPercentage = Convert.ToDouble(reader["B2BQtyPercentage"].ToString());
                    _oDailySalesReport.eStoreQtyPercentage = Convert.ToDouble(reader["eStoreQtyPercentage"].ToString());
                    _oDailySalesReport.RTLValPercentage = Convert.ToDouble(reader["RTLValPercentage"].ToString());
                    _oDailySalesReport.DealerValPercentage = Convert.ToDouble(reader["DealerValPercentage"].ToString());
                    _oDailySalesReport.B2BValPercentage = Convert.ToDouble(reader["B2BValPercentage"].ToString());
                    _oDailySalesReport.eStoreValPercentage = Convert.ToDouble(reader["eStoreValPercentage"].ToString());

                    _oDailySalesReport.TotalSalesQty = Convert.ToDouble(reader["TotalSalesQty"].ToString());
                    _oDailySalesReport.TotalTGTQty = Convert.ToDouble(reader["TotalTGTQty"].ToString());
                    _oDailySalesReport.TotalQtyPercentage = Convert.ToDouble(reader["TotalQtyPercentage"].ToString());
                    _oDailySalesReport.TotalSalesVal = Convert.ToDouble(reader["TotalSalesVal"].ToString());
                    _oDailySalesReport.TotalTGTVal = Convert.ToDouble(reader["TotalTGTVal"].ToString());
                    _oDailySalesReport.TotalValPercentage = Convert.ToDouble(reader["TotalValPercentage"].ToString());

                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void MAGWeekTgtVsAchRetail(DateTime FirstDateOfThisMonth, DateTime LastDateOfThisMonth, int nTGTYear, int nTGTMonth, int nTGTWeek)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = "Select Main.*, " +
                        "isnull(nullif(RetailSalesQty,0)/nullif(CAST(RetailTGTQty as float),0)*100,0) as RTLQtyPercentage, " +
                        "isnull(nullif(DealerSalesQty,0)/nullif(CAST(DealerTGTQty as float),0)*100,0) as DealerQtyPercentage, " +
                        "isnull(nullif(B2BSalesQty,0)/nullif(CAST(B2BTGTQty as float),0)*100,0) as B2BQtyPercentage, " +
                        "isnull(nullif(eStoreSalesQty,0)/nullif(CAST(eStoreTGTQty as float),0)*100,0) as eStoreQtyPercentage, " +
                        "isnull(nullif(RetailSalesVal,0)/nullif(CAST(RetailTGTVal as float),0)*100,0) as RTLValPercentage, " +
                        "isnull(nullif(DealerSalesVal,0)/nullif(CAST(DealerTGTVal as float),0)*100,0) as DealerValPercentage, " +
                        "isnull(nullif(B2BSalesVal,0)/nullif(CAST(B2BTGTVal as float),0)*100,0) as B2BValPercentage, " +
                        "isnull(nullif(eStoreSalesVal,0)/nullif(CAST(eStoreTGTVal as float),0)*100,0) as eStoreValPercentage, " +
                        "isnull(RetailSalesQty+B2BSalesQty+eStoreSalesQty,0) as TotalSalesQty, " +
                        "isnull(RetailTGTQty+B2BTGTQty+eStoreTGTQty,0) as TotalTGTQty, " +
                        "isnull(nullif(RetailSalesQty+B2BSalesQty+eStoreSalesQty,0)/nullif(CAST((RetailTGTQty+B2BTGTQty+eStoreTGTQty) as float),0)*100,0) as TotalQtyPercentage, " +
                        "isnull(RetailSalesVal+B2BSalesVal+eStoreSalesVal,0) as TotalSalesVal, " +
                        "isnull(RetailTGTVal+B2BTGTVal+eStoreTGTVal,0) as TotalTGTVal, " +
                        "isnull(nullif(RetailSalesVal+B2BSalesVal+eStoreSalesVal,0)/nullif(CAST((RetailTGTVal+B2BTGTVal+eStoreTGTVal) as float),0)*100,0) as TotalValPercentage " +
                        "From  " +
                        "( " +
                        "Select TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName, " +
                        "sum(RetailTGTQty) RetailTGTQty,sum(DealerTGTQty) DealerTGTQty,sum(B2BTGTQty) B2BTGTQty,sum(eStoreTGTQty) eStoreTGTQty, " +
                        "sum(RetailSalesQty) RetailSalesQty,sum(DealerSalesQty) DealerSalesQty,sum(B2BSalesQty) B2BSalesQty,sum(eStoreSalesQty) eStoreSalesQty, " +
                        "sum(RetailTGTVal) RetailTGTVal,sum(DealerTGTVal) DealerTGTVal,sum(B2BTGTVal) B2BTGTVal,sum(eStoreTGTVal) eStoreTGTVal, " +
                        "sum(RetailSalesVal) RetailSalesVal,sum(DealerSalesVal) DealerSalesVal,sum(B2BSalesVal) B2BSalesVal,sum(eStoreSalesVal) eStoreSalesVal " +
                        "From  " +
                        "( " +
                        "Select TYear,TMonth,WeekNo,a.BrandID,BrandDesc as Brand,a.MAGID,c.PDTGroupName as MAGName, " +
                        "d.PdtGroupID as PGID,d.PDTGroupName as PGName, " +
                        "sum(case Channel when 4 then TargetQty else 0 end) as RetailTGTQty, " +
                        "sum(case Channel when 3 then TargetQty else 0 end) as DealerTGTQty, " +
                        "sum(case Channel when 13 then TargetQty else 0 end) as B2BTGTQty, " +
                        "sum(case Channel when 16 then TargetQty else 0 end) as eStoreTGTQty, " +
                        "sum(case Channel when 4 then TargetValue else 0 end) as RetailTGTVal, " +
                        "sum(case Channel when 3 then TargetValue else 0 end) as DealerTGTVal, " +
                        "sum(case Channel when 13 then TargetValue else 0 end) as B2BTGTVal, " +
                        "sum(case Channel when 16 then TargetValue else 0 end) as eStoreTGTVal, " +
                        "0 RetailSalesQty,0 DealerSalesQty,0 B2BSalesQty,0 eStoreSalesQty, " +
                        "0 RetailSalesVal,0 DealerSalesVal,0 B2BSalesVal,0 eStoreSalesVal " +
                        "From t_PlanMAGWeekTargetQty a,t_Brand b,t_ProductGroup c,t_ProductGroup d   " +
                        "where a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID " +
                        "and TYear=" + nTGTYear + " and TMonth=" + nTGTMonth + " and TargetValue>0  " +
                        "group by TYear,TMonth,WeekNo,a.BrandID,BrandDesc, " +
                        "a.MAGID,c.PDTGroupName,d.PdtGroupID,d.PDTGroupName,TargetQty,TargetValue " +
                        "Union All " +
                        "Select TYear,TMonth,WeekNo,BrandID,BrandDesc,MAGID,MAGName,PGID,PGName, " +
                        "0 RetailTGTQty,0 DealerTGTQty,0 B2BTGTQty,0 eStoreTGTQty, " +
                        "0 RetailTGTValue,0 DealerTGTValue,0 B2BTGTValue,0 eStoreTGTValue, " +
                        "(RetailSalesQty+B2CSalesQty+HPASalesQty) RetailSalesQty,DealerSalesQty,B2BSalesQty,eStoreSalesQty, " +
                        "(RetailSalesVal+B2CSalesVal+HPASalesVal) RetailSalesVal,DealerSalesVal,B2BSalesVal,eStoreSalesVal From    " +
                        "( " +
                        "Select TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID,MAGName, " +
                        "sum(case SalesType when 1 then SalesQty else 0 end) as RetailSalesQty, " +
                        "sum(case SalesType when 2 then SalesQty else 0 end) as B2CSalesQty, " +
                        "sum(case SalesType when 4 then SalesQty else 0 end) as HPASalesQty, " +
                        "sum(case SalesType when 5 then SalesQty else 0 end) as DealerSalesQty, " +
                        "sum(case SalesType when 3 then SalesQty else 0 end) as B2BSalesQty, " +
                        "sum(case SalesType when 6 then SalesQty else 0 end) as eStoreSalesQty, " +
                        "sum(case SalesType when 1 then NetSales else 0 end) as RetailSalesVal, " +
                        "sum(case SalesType when 2 then NetSales else 0 end) as B2CSalesVal, " +
                        "sum(case SalesType when 4 then NetSales else 0 end) as HPASalesVal, " +
                        "sum(case SalesType when 5 then NetSales else 0 end) as DealerSalesVal, " +
                        "sum(case SalesType when 3 then NetSales else 0 end) as B2BSalesVal, " +
                        "sum(case SalesType when 6 then NetSales else 0 end) as eStoreSalesVal " +
                        "From    " +
                        "(   " +
                        "Select SalesType,TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID, " +
                        "MAGName,SalesQty,(GrossSales+OC-Main.VAT-Discount) as NetSales  " +
                        "From ( " +
                        "Select SalesType,TYear,TMonth,WeekNo,ProductID,  " +
                        "isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,   " +
                        "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC, " +
                        "isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT   " +
                        "From   " +
                        "( " +
                        "Select SalesType,TYear,WeekNo,TMonth,ProductID,sum(quantity)as crqty,  " +
                        "0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales,   " +
                        "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS,  " +
                        "0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT  from  (  Select SalesType,a.InvoiceID, " +
                        "WeekNo,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales, " +
                        "(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,   " +
                        "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT   " +
                        "from  (   " +
                        "select SalesType,sa.InvoiceID,WeekNo,year(invoicedate) as TYear, " +
                        "month(invoicedate) as TMonth,  ProductID,UnitPrice,Costprice, " +
                        "TradePrice,VatAmount,Discount,quantity   " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,t_RetailConsumer sc,t_CalendarWeek   " +
                        "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and    " +
                        "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'  " +
                        "and invoicedate < '" + LastDateOfThisMonth + "'   " +
                        "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate    " +
                        "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)    " +
                        ")as a   " +
                        "left outer join   " +
                        "(   " +
                        "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc, " +
                        "isnull((OtherCharge/sum(quantity)),0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd   " +
                        "where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'  " +
                        "and invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (1,2,4,5)and  " +
                        "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge   " +
                        ") as b  " +
                        "on a.invoiceid = b.invoiceid  ) as final  Group By SalesType,TYear,TMonth,WeekNo,ProductID   " +
                        "Union all   " +
                        "Select SalesType,TYear,WeekNo,TMonth,ProductID,0 as crqty,  " +
                        "sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,   " +
                        "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC, " +
                        "0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT   " +
                        "from  (   " +
                        "Select a.InvoiceID,WeekNo,TYear,TMonth,SalesType,ProductID,Quantity, " +
                        "(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,   " +
                        "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT   " +
                        "from  (   " +
                        "select sa.InvoiceID,WeekNo,year(invoicedate) as TYear,month(invoicedate) as TMonth,   " +
                        "SalesType,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity   " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,t_Retailconsumer sc,t_CalendarWeek   " +
                        "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and    " +
                        "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate < '" + LastDateOfThisMonth + "'   " +
                        "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate    " +
                        "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   )as a   " +
                        "left outer join   " +
                        "(   " +
                        "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC   " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd   " +
                        "where sa.invoiceid = sd.invoiceid and invoicedate  " +
                        "between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and  " +
                        "invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (6,7,9,10,12)and  " +
                        "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge   " +
                        ") as b  " +
                        "on a.invoiceid = b.invoiceid   " +
                        ") as final   " +
                        "Group By SalesType,WeekNo,TYear,TMonth,ProductID   " +
                        ")as FinalQuery   " +
                        "Group by  SalesType,WeekNo,TYear,TMonth,ProductID   " +
                        ") Main    " +
                        "inner join   " +
                        "(   " +
                        "Select * from v_productdetails  ) as p on Main.productid = p.productid   " +
                        ") Sales  " +
                        "group by SalesType,TYear,TMonth,WeekNo,MAGID,MAGName,PGID,PGName,BrandID,BrandDesc) as Sales " +
                        ") a " +
                        "group by TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName " +
                        ") Main where 1=1";
            }
            if (nTGTWeek != -1)
            {
                sSql = sSql + " AND WeekNo=" + nTGTWeek + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();
                    _oDailySalesReport.TYear = Convert.ToInt32(reader["TYear"].ToString());
                    _oDailySalesReport.TMonth = Convert.ToInt32(reader["TMonth"].ToString());
                    _oDailySalesReport.TWeek = Convert.ToInt32(reader["WeekNo"].ToString());
                    _oDailySalesReport.MAGName = reader["MAGName"].ToString();
                    _oDailySalesReport.Brand = reader["Brand"].ToString();
                    _oDailySalesReport.PGName = reader["PGName"].ToString();

                    _oDailySalesReport.RTLTGRQty = Convert.ToInt32(reader["RetailTGTQty"].ToString());
                    _oDailySalesReport.RTLSalesQty = Convert.ToInt32(reader["RetailSalesQty"].ToString());
                    _oDailySalesReport.DealerTGTQty = Convert.ToInt32(reader["DealerTGTQty"].ToString());
                    _oDailySalesReport.DealerSalesQty = Convert.ToInt32(reader["DealerSalesQty"].ToString());
                    _oDailySalesReport.B2BTGTQty = Convert.ToInt32(reader["B2BTGTQty"].ToString());
                    _oDailySalesReport.B2BSalesQty = Convert.ToInt32(reader["B2BSalesQty"].ToString());
                    _oDailySalesReport.eStoreTGTQty = Convert.ToInt32(reader["eStoreTGTQty"].ToString());
                    _oDailySalesReport.eStoreSalesQty = Convert.ToInt32(reader["eStoreSalesQty"].ToString());

                    _oDailySalesReport.RetailTGTVal = Convert.ToDouble(reader["RetailTGTVal"].ToString());
                    _oDailySalesReport.RTLSalesVal = Convert.ToDouble(reader["RetailSalesVal"].ToString());
                    _oDailySalesReport.DealerTGTVal = Convert.ToDouble(reader["DealerTGTVal"].ToString());
                    _oDailySalesReport.DealerSalesVal = Convert.ToDouble(reader["DealerSalesVal"].ToString());
                    _oDailySalesReport.B2BTGTVal = Convert.ToDouble(reader["B2BTGTVal"].ToString());
                    _oDailySalesReport.B2BSalesVal = Convert.ToDouble(reader["B2BSalesVal"].ToString());
                    _oDailySalesReport.eStoreTGTVal = Convert.ToDouble(reader["eStoreTGTVal"].ToString());
                    _oDailySalesReport.eStoreSalesVal = Convert.ToDouble(reader["eStoreSalesVal"].ToString());

                    _oDailySalesReport.RTLQtyPercentage = Convert.ToDouble(reader["RTLQtyPercentage"].ToString());
                    _oDailySalesReport.DealerQtyPercentage = Convert.ToDouble(reader["DealerQtyPercentage"].ToString());
                    _oDailySalesReport.B2BQtyPercentage = Convert.ToDouble(reader["B2BQtyPercentage"].ToString());
                    _oDailySalesReport.eStoreQtyPercentage = Convert.ToDouble(reader["eStoreQtyPercentage"].ToString());
                    _oDailySalesReport.RTLValPercentage = Convert.ToDouble(reader["RTLValPercentage"].ToString());
                    _oDailySalesReport.DealerValPercentage = Convert.ToDouble(reader["DealerValPercentage"].ToString());
                    _oDailySalesReport.B2BValPercentage = Convert.ToDouble(reader["B2BValPercentage"].ToString());
                    _oDailySalesReport.eStoreValPercentage = Convert.ToDouble(reader["eStoreValPercentage"].ToString());

                    _oDailySalesReport.TotalSalesQty = Convert.ToDouble(reader["TotalSalesQty"].ToString());
                    _oDailySalesReport.TotalTGTQty = Convert.ToDouble(reader["TotalTGTQty"].ToString());
                    _oDailySalesReport.TotalQtyPercentage = Convert.ToDouble(reader["TotalQtyPercentage"].ToString());
                    _oDailySalesReport.TotalSalesVal = Convert.ToDouble(reader["TotalSalesVal"].ToString());
                    _oDailySalesReport.TotalTGTVal = Convert.ToDouble(reader["TotalTGTVal"].ToString());
                    _oDailySalesReport.TotalValPercentage = Convert.ToDouble(reader["TotalValPercentage"].ToString());

                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void MAGWeekTgtVsAchRT(DateTime FirstDateOfThisMonth, DateTime LastDateOfThisMonth, int nTGTYear, int nTGTMonth, int nTGTWeek)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = String.Format(@"Select Main.*, isnull(nullif(RetailSalesQty,0)/nullif(CAST(RetailTGTQty as float),0)*100,0) as RTLQtyPercentage, isnull(nullif(DealerSalesQty,0)/nullif(CAST(DealerTGTQty as float),0)*100,0) as DealerQtyPercentage, isnull(nullif(B2BSalesQty,0)/nullif(CAST(B2BTGTQty as float),0)*100,0) as B2BQtyPercentage, isnull(nullif(eStoreSalesQty,0)/nullif(CAST(eStoreTGTQty as float),0)*100,0) as eStoreQtyPercentage, isnull(nullif(RetailSalesVal,0)/nullif(CAST(RetailTGTVal as float),0)*100,0) as RTLValPercentage, isnull(nullif(DealerSalesVal,0)/nullif(CAST(DealerTGTVal as float),0)*100,0) as DealerValPercentage, isnull(nullif(B2BSalesVal,0)/nullif(CAST(B2BTGTVal as float),0)*100,0) as B2BValPercentage, isnull(nullif(eStoreSalesVal,0)/nullif(CAST(eStoreTGTVal as float),0)*100,0) as eStoreValPercentage, isnull(RetailSalesQty+DealerSalesQty+B2BSalesQty+eStoreSalesQty,0) as TotalSalesQty, isnull(RetailTGTQty+DealerTGTQty+B2BTGTQty+eStoreTGTQty,0) as TotalTGTQty, isnull(nullif(RetailSalesQty+DealerSalesQty+B2BSalesQty+eStoreSalesQty,0)/nullif(CAST((RetailTGTQty+DealerTGTQty+B2BTGTQty+eStoreTGTQty) as float),0)*100,0) as TotalQtyPercentage, isnull(RetailSalesVal+DealerSalesVal+B2BSalesVal+eStoreSalesVal,0) as TotalSalesVal, isnull(RetailTGTVal+DealerTGTVal+B2BTGTVal+eStoreTGTVal,0) as TotalTGTVal, isnull(nullif(RetailSalesVal+DealerSalesVal+B2BSalesVal+eStoreSalesVal,0)/nullif(CAST((RetailTGTVal+DealerTGTVal+B2BTGTVal+eStoreTGTVal) as float),0)*100,0) as TotalValPercentage From  ( Select TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName, sum(RetailTGTQty) RetailTGTQty,sum(DealerTGTQty) DealerTGTQty,sum(B2BTGTQty) B2BTGTQty,sum(eStoreTGTQty) eStoreTGTQty, sum(RetailSalesQty) RetailSalesQty,sum(DealerSalesQty) DealerSalesQty,sum(B2BSalesQty) B2BSalesQty,sum(eStoreSalesQty) eStoreSalesQty, sum(RetailTGTVal) RetailTGTVal,sum(DealerTGTVal) DealerTGTVal,sum(B2BTGTVal) B2BTGTVal,sum(eStoreTGTVal) eStoreTGTVal, sum(RetailSalesVal) RetailSalesVal,sum(DealerSalesVal) DealerSalesVal,sum(B2BSalesVal) B2BSalesVal,sum(eStoreSalesVal) eStoreSalesVal From  ( Select TYear,TMonth,WeekNo,a.BrandID,BrandDesc as Brand,a.MAGID,c.PDTGroupName as MAGName, d.PdtGroupID as PGID,d.PDTGroupName as PGName, sum(case Channel when 4 then TargetQty else 0 end) as RetailTGTQty, sum(case Channel when 3 then TargetQty else 0 end) as DealerTGTQty, sum(case Channel when 13 then TargetQty else 0 end) as B2BTGTQty, sum(case Channel when 16 then TargetQty else 0 end) as eStoreTGTQty, sum(case Channel when 4 then TargetValue else 0 end) as RetailTGTVal, sum(case Channel when 3 then TargetValue else 0 end) as DealerTGTVal, sum(case Channel when 13 then TargetValue else 0 end) as B2BTGTVal, sum(case Channel when 16 then TargetValue else 0 end) as eStoreTGTVal, 0 RetailSalesQty,0 DealerSalesQty,0 B2BSalesQty,0 eStoreSalesQty, 0 RetailSalesVal,0 DealerSalesVal,0 B2BSalesVal,0 eStoreSalesVal From t_PlanMAGWeekTargetQty a,t_Brand b,t_ProductGroup c,t_ProductGroup d   where a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID 
                    and a.CustomerID=(select CustomerID from t_Showroom where WarehouseID={4}) and c.ParentID=d.PdtGroupID and TYear={2} and TMonth={3} and TargetValue>0  group by TYear,TMonth,WeekNo,a.BrandID,BrandDesc, a.MAGID,c.PDTGroupName,d.PdtGroupID,d.PDTGroupName,TargetQty,TargetValue Union All Select TYear,TMonth,WeekNo,BrandID,BrandDesc,MAGID,MAGName,PGID,PGName, 0 RetailTGTQty,0 DealerTGTQty,0 B2BTGTQty,0 eStoreTGTQty, 0 RetailTGTValue,0 DealerTGTValue,0 B2BTGTValue,0 eStoreTGTValue, (RetailSalesQty+B2CSalesQty+HPASalesQty) RetailSalesQty,DealerSalesQty,B2BSalesQty,eStoreSalesQty, (RetailSalesVal+B2CSalesVal+HPASalesVal) RetailSalesVal,DealerSalesVal,B2BSalesVal,eStoreSalesVal From    ( Select TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID,MAGName, sum(case SalesType when 1 then SalesQty else 0 end) as RetailSalesQty, sum(case SalesType when 2 then SalesQty else 0 end) as B2CSalesQty, sum(case SalesType when 4 then SalesQty else 0 end) as HPASalesQty, sum(case SalesType when 5 then SalesQty else 0 end) as DealerSalesQty, sum(case SalesType when 3 then SalesQty else 0 end) as B2BSalesQty, sum(case SalesType when 6 then SalesQty else 0 end) as eStoreSalesQty, sum(case SalesType when 1 then NetSales else 0 end) as RetailSalesVal, sum(case SalesType when 2 then NetSales else 0 end) as B2CSalesVal, sum(case SalesType when 4 then NetSales else 0 end) as HPASalesVal, sum(case SalesType when 5 then NetSales else 0 end) as DealerSalesVal, sum(case SalesType when 3 then NetSales else 0 end) as B2BSalesVal, sum(case SalesType when 6 then NetSales else 0 end) as eStoreSalesVal From    (   Select SalesType,TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID, MAGName,SalesQty,(GrossSales+OC-Main.VAT-Discount) as NetSales  From ( Select SalesType,TYear,TMonth,WeekNo,ProductID,  isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,   isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC, isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT   From   ( Select SalesType,TYear,WeekNo,TMonth,ProductID,sum(quantity)as crqty,  0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales,   sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS,  0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT  from  (  Select SalesType,a.InvoiceID, WeekNo,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales, (AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,   (Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT   from  (   select SalesType,sa.InvoiceID,WeekNo,year(invoicedate) as TYear, month(invoicedate) as TMonth,  ProductID,UnitPrice,Costprice, TradePrice,VatAmount,Discount,quantity   from t_salesinvoice sa, t_salesinvoicedetail sd,t_RetailConsumer sc,t_CalendarWeek   where sa.invoiceid = sd.invoiceid and sa.WarehouseID=sc.WarehouseID and sa.WarehouseID={4} and sa.SundryCustomerID=sc.ConsumerID and    invoicedate between '{0}' and '{1}'  and invoicedate < '{1}'   and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate    and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)    )as a   left outer join   (   select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc, isnull((OtherCharge/sum(quantity)),0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd   where sa.invoiceid = sd.invoiceid and sa.WarehouseID={4} and invoicedate between '{0}' and '{1}'  and invoicedate < '{1}'  and invoicetypeid in (1,2,4,5)and  invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge   ) as b  on a.invoiceid = b.invoiceid  ) as final  Group By SalesType,TYear,TMonth,WeekNo,ProductID   Union all   Select SalesType,TYear,WeekNo,TMonth,ProductID,0 as crqty,  sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,   0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC, 0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT   from  (   Select a.InvoiceID,WeekNo,TYear,TMonth,SalesType,ProductID,Quantity, (Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,   (Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT   from  (   select sa.InvoiceID,WeekNo,year(invoicedate) as TYear,month(invoicedate) as TMonth,   SalesType,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity   from t_salesinvoice sa, t_salesinvoicedetail sd,t_Retailconsumer sc,t_CalendarWeek   where sa.invoiceid = sd.invoiceid and sa.WarehouseID=sc.WarehouseID and sa.WarehouseID={4} and sa.SundryCustomerID=sc.ConsumerID and    invoicedate between '{0}' and '{1}' and invoicedate < '{1}'   and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate    and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   )as a   left outer join   (   select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC   from t_salesinvoice sa, t_salesinvoicedetail sd   where sa.invoiceid = sd.invoiceid and sa.WarehouseID={4} and invoicedate  between '{0}' and '{1}' and  invoicedate < '{1}'  and invoicetypeid in (6,7,9,10,12)and  invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge   ) as b  on a.invoiceid = b.invoiceid   ) as final   Group By SalesType,WeekNo,TYear,TMonth,ProductID   )as FinalQuery   Group by  SalesType,WeekNo,TYear,TMonth,ProductID   ) Main    inner join   (   Select * from v_productdetails  ) as p on Main.productid = p.productid   ) Sales  group by SalesType,TYear,TMonth,WeekNo,MAGID,MAGName,PGID,PGName,BrandID,BrandDesc) as Sales ) a group by TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName ) Main where 1=1"
                    , FirstDateOfThisMonth, LastDateOfThisMonth, nTGTYear, nTGTMonth,Utility.WarehouseID);
            }
            if (nTGTWeek != -1)
            {
                sSql = sSql + " AND WeekNo=" + nTGTWeek + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();
                    _oDailySalesReport.TYear = Convert.ToInt32(reader["TYear"].ToString());
                    _oDailySalesReport.TMonth = Convert.ToInt32(reader["TMonth"].ToString());
                    _oDailySalesReport.TWeek = Convert.ToInt32(reader["WeekNo"].ToString());
                    _oDailySalesReport.MAGName = reader["MAGName"].ToString();
                    _oDailySalesReport.Brand = reader["Brand"].ToString();
                    _oDailySalesReport.PGName = reader["PGName"].ToString();

                    _oDailySalesReport.RTLTGRQty = Convert.ToInt32(reader["RetailTGTQty"].ToString());
                    _oDailySalesReport.RTLSalesQty = Convert.ToInt32(reader["RetailSalesQty"].ToString());
                    _oDailySalesReport.DealerTGTQty = Convert.ToInt32(reader["DealerTGTQty"].ToString());
                    _oDailySalesReport.DealerSalesQty = Convert.ToInt32(reader["DealerSalesQty"].ToString());
                    _oDailySalesReport.B2BTGTQty = Convert.ToInt32(reader["B2BTGTQty"].ToString());
                    _oDailySalesReport.B2BSalesQty = Convert.ToInt32(reader["B2BSalesQty"].ToString());
                    _oDailySalesReport.eStoreTGTQty = Convert.ToInt32(reader["eStoreTGTQty"].ToString());
                    _oDailySalesReport.eStoreSalesQty = Convert.ToInt32(reader["eStoreSalesQty"].ToString());

                    _oDailySalesReport.RetailTGTVal = Convert.ToDouble(reader["RetailTGTVal"].ToString());
                    _oDailySalesReport.RTLSalesVal = Convert.ToDouble(reader["RetailSalesVal"].ToString());
                    _oDailySalesReport.DealerTGTVal = Convert.ToDouble(reader["DealerTGTVal"].ToString());
                    _oDailySalesReport.DealerSalesVal = Convert.ToDouble(reader["DealerSalesVal"].ToString());
                    _oDailySalesReport.B2BTGTVal = Convert.ToDouble(reader["B2BTGTVal"].ToString());
                    _oDailySalesReport.B2BSalesVal = Convert.ToDouble(reader["B2BSalesVal"].ToString());
                    _oDailySalesReport.eStoreTGTVal = Convert.ToDouble(reader["eStoreTGTVal"].ToString());
                    _oDailySalesReport.eStoreSalesVal = Convert.ToDouble(reader["eStoreSalesVal"].ToString());

                    _oDailySalesReport.RTLQtyPercentage = Convert.ToDouble(reader["RTLQtyPercentage"].ToString());
                    _oDailySalesReport.DealerQtyPercentage = Convert.ToDouble(reader["DealerQtyPercentage"].ToString());
                    _oDailySalesReport.B2BQtyPercentage = Convert.ToDouble(reader["B2BQtyPercentage"].ToString());
                    _oDailySalesReport.eStoreQtyPercentage = Convert.ToDouble(reader["eStoreQtyPercentage"].ToString());
                    _oDailySalesReport.RTLValPercentage = Convert.ToDouble(reader["RTLValPercentage"].ToString());
                    _oDailySalesReport.DealerValPercentage = Convert.ToDouble(reader["DealerValPercentage"].ToString());
                    _oDailySalesReport.B2BValPercentage = Convert.ToDouble(reader["B2BValPercentage"].ToString());
                    _oDailySalesReport.eStoreValPercentage = Convert.ToDouble(reader["eStoreValPercentage"].ToString());

                    _oDailySalesReport.TotalSalesQty = Convert.ToDouble(reader["TotalSalesQty"].ToString());
                    _oDailySalesReport.TotalTGTQty = Convert.ToDouble(reader["TotalTGTQty"].ToString());
                    _oDailySalesReport.TotalQtyPercentage = Convert.ToDouble(reader["TotalQtyPercentage"].ToString());
                    _oDailySalesReport.TotalSalesVal = Convert.ToDouble(reader["TotalSalesVal"].ToString());
                    _oDailySalesReport.TotalTGTVal = Convert.ToDouble(reader["TotalTGTVal"].ToString());
                    _oDailySalesReport.TotalValPercentage = Convert.ToDouble(reader["TotalValPercentage"].ToString());

                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void EmployeeMAGWeekTgtVsAch(DateTime FirstDateOfThisMonth, DateTime LastDateOfThisMonth, int nTGTYear, int nTGTMonth, int nTGTWeek, int nType, int nSalesPersonID)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (nType == (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty)
            {
                sSql = "Select * From  " +
                        "(  " +
                        "Select a.*,'['+EmployeeCode+']'+' '+ EmployeeName as EmployeeName,  " +
                        "isnull(nullif(RetailSalesQty,0)/nullif(CAST(RetailTGTQty as float),0)*100,0) as RTLQtyPercentage,   " +
                        "isnull(nullif(DealerSalesQty,0)/nullif(CAST(DealerTGTQty as float),0)*100,0) as DealerQtyPercentage,   " +
                        "isnull(nullif(B2BSalesQty,0)/nullif(CAST(B2BTGTQty as float),0)*100,0) as B2BQtyPercentage,   " +
                        "isnull(nullif(eStoreSalesQty,0)/nullif(CAST(eStoreTGTQty as float),0)*100,0) as eStoreQtyPercentage,   " +
                        "isnull(nullif(RetailSalesVal,0)/nullif(CAST(RetailTGTVal as float),0)*100,0) as RTLValPercentage,   " +
                        "isnull(nullif(DealerSalesVal,0)/nullif(CAST(DealerTGTVal as float),0)*100,0) as DealerValPercentage,   " +
                        "isnull(nullif(B2BSalesVal,0)/nullif(CAST(B2BTGTVal as float),0)*100,0) as B2BValPercentage,   " +
                        "isnull(nullif(eStoreSalesVal,0)/nullif(CAST(eStoreTGTVal as float),0)*100,0) as eStoreValPercentage,   " +
                        "isnull(RetailSalesQty+DealerSalesQty+B2BSalesQty+eStoreSalesQty,0) as TotalSalesQty,   " +
                        "isnull(RetailTGTQty+DealerTGTQty+B2BTGTQty+eStoreTGTQty,0) as TotalTGTQty,   " +
                        "isnull(nullif(RetailSalesQty+DealerSalesQty+B2BSalesQty+eStoreSalesQty,0)/nullif(CAST((RetailTGTQty+DealerTGTQty+B2BTGTQty+eStoreTGTQty) as float),0)*100,0) as TotalQtyPercentage,   " +
                        "isnull(RetailSalesVal+DealerSalesVal+B2BSalesVal+eStoreSalesVal,0) as TotalSalesVal,   " +
                        "isnull(RetailTGTVal+DealerTGTVal+B2BTGTVal+eStoreTGTVal,0) as TotalTGTVal,   " +
                        "isnull(nullif(RetailSalesVal+DealerSalesVal+B2BSalesVal+eStoreSalesVal,0)/nullif(CAST((RetailTGTVal+DealerTGTVal+B2BTGTVal+eStoreTGTVal) as float),0)*100,0) as TotalValPercentage  " +
                        "From   " +
                        "(  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName,   " +
                        "sum(RetailTGTQty) RetailTGTQty,sum(DealerTGTQty) DealerTGTQty,sum(B2BTGTQty) B2BTGTQty,sum(eStoreTGTQty) eStoreTGTQty,   " +
                        "sum(RetailSalesQty) RetailSalesQty,sum(DealerSalesQty) DealerSalesQty,sum(B2BSalesQty) B2BSalesQty,sum(eStoreSalesQty) eStoreSalesQty,   " +
                        "sum(RetailTGTVal) RetailTGTVal,sum(DealerTGTVal) DealerTGTVal,sum(B2BTGTVal) B2BTGTVal,sum(eStoreTGTVal) eStoreTGTVal,   " +
                        "sum(RetailSalesVal) RetailSalesVal,sum(DealerSalesVal) DealerSalesVal,sum(B2BSalesVal) B2BSalesVal,sum(eStoreSalesVal) eStoreSalesVal  " +
                        "From  " +
                        "(  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,a.BrandID,BrandDesc as Brand,a.MAGID,c.PDTGroupName as MAGName,  " +
                        "d.PdtGroupID as PGID,d.PDTGroupName as PGName,  " +
                        "sum(case Channel when 4 then TargetQty else 0 end) as RetailTGTQty,  " +
                        "sum(case Channel when 3 then TargetQty else 0 end) as DealerTGTQty,  " +
                        "sum(case Channel when 13 then TargetQty else 0 end) as B2BTGTQty,  " +
                        "sum(case Channel when 16 then TargetQty else 0 end) as eStoreTGTQty,  " +
                        "sum(case Channel when 4 then TargetAmount else 0 end) as RetailTGTVal,  " +
                        "sum(case Channel when 3 then TargetAmount else 0 end) as DealerTGTVal,  " +
                        "sum(case Channel when 13 then TargetAmount else 0 end) as B2BTGTVal,  " +
                        "sum(case Channel when 16 then TargetAmount else 0 end) as eStoreTGTVal,  " +
                        "0 RetailSalesQty,0 DealerSalesQty,0 B2BSalesQty,0 eStoreSalesQty,  " +
                        "0 RetailSalesVal,0 DealerSalesVal,0 B2BSalesVal,0 eStoreSalesVal  " +
                        "From t_PlanExecutiveLeadTarget a,t_Brand b,t_ProductGroup c,t_ProductGroup d    " +
                        "where a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID  " +
                        "and TYear=" + nTGTYear + " and TMonth=" + nTGTMonth + " and TargetAmount>0 and TargetType=" + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + "  " +
                        "group by SalesPersonID,TYear,TMonth,WeekNo,a.BrandID,BrandDesc,  " +
                        "a.MAGID,c.PDTGroupName,d.PdtGroupID,d.PDTGroupName  " +
                        "Union All  " +
                        "Select SalespersonID,TYear,TMonth,WeekNo,BrandID,BrandDesc,MAGID,MAGName,PGID,PGName,  " +
                        "0 RetailTGTQty,0 DealerTGTQty,0 B2BTGTQty,0 eStoreTGTQty,  " +
                        "0 RetailTGTValue,0 DealerTGTValue,0 B2BTGTValue,0 eStoreTGTValue,  " +
                        "(RetailSalesQty+B2CSalesQty+HPASalesQty) RetailSalesQty,DealerSalesQty,B2BSalesQty,eStoreSalesQty,  " +
                        "(RetailSalesVal+B2CSalesVal+HPASalesVal) RetailSalesVal,DealerSalesVal,B2BSalesVal,eStoreSalesVal From     " +
                        "(  " +
                        "Select SalespersonID,TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID,MAGName,  " +
                        "sum(case SalesType when 1 then SalesQty else 0 end) as RetailSalesQty,  " +
                        "sum(case SalesType when 2 then SalesQty else 0 end) as B2CSalesQty,  " +
                        "sum(case SalesType when 4 then SalesQty else 0 end) as HPASalesQty,  " +
                        "sum(case SalesType when 5 then SalesQty else 0 end) as DealerSalesQty,  " +
                        "sum(case SalesType when 3 then SalesQty else 0 end) as B2BSalesQty,  " +
                        "sum(case SalesType when 6 then SalesQty else 0 end) as eStoreSalesQty,  " +
                        "sum(case SalesType when 1 then NetSales else 0 end) as RetailSalesVal,  " +
                        "sum(case SalesType when 2 then NetSales else 0 end) as B2CSalesVal,  " +
                        "sum(case SalesType when 4 then NetSales else 0 end) as HPASalesVal,  " +
                        "sum(case SalesType when 5 then NetSales else 0 end) as DealerSalesVal,  " +
                        "sum(case SalesType when 3 then NetSales else 0 end) as B2BSalesVal,  " +
                        "sum(case SalesType when 6 then NetSales else 0 end) as eStoreSalesVal  " +
                        "From     " +
                        "(    " +
                        "Select SalespersonID,SalesType,TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID,  " +
                        "MAGName,SalesQty,(GrossSales+OC-Main.VAT-Discount) as NetSales   " +
                        "From (  " +
                        "Select SalespersonID,SalesType,TYear,TMonth,WeekNo,ProductID,   " +
                        "isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,    " +
                        "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,  " +
                        "isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT    " +
                        "From    " +
                        "(  " +
                        "Select SalespersonID,SalesType,TYear,WeekNo,TMonth,ProductID,sum(quantity)as crqty,   " +
                        "0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales,    " +
                        "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS,   " +
                        "0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT    " +
                        "from    " +
                        "(    " +
                        "Select SalespersonID,SalesType,a.InvoiceID,  " +
                        "WeekNo,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales,  " +
                        "(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,    " +
                        "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT    " +
                        "from  (    " +
                        "select SalespersonID,SalesType,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,  " +
                        "month(invoicedate) as TMonth,  ProductID,UnitPrice,Costprice,  " +
                        "TradePrice,VatAmount,Discount,quantity    " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,t_RetailConsumer sc,t_CalendarWeek    " +
                        "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and     " +
                        "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'   " +
                        "and invoicedate < '" + LastDateOfThisMonth + "'    " +
                        "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate     " +
                        "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)     " +
                        ")as a    " +
                        "left outer join    " +
                        "(    " +
                        "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,  " +
                        "isnull((OtherCharge/sum(quantity)),0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd    " +
                        "where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'   " +
                        "and invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (1,2,4,5)and   " +
                        "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge    " +
                        ") as b   " +
                        "on a.invoiceid = b.invoiceid) as final  Group By SalespersonID,SalesType,TYear,TMonth,WeekNo,ProductID    " +
                        "Union all    " +
                        "Select SalespersonID,SalesType,TYear,WeekNo,TMonth,ProductID,0 as crqty,   " +
                        "sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,    " +
                        "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,  " +
                        "0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT    " +
                        "from  (    " +
                        "Select SalespersonID,a.InvoiceID,WeekNo,TYear,TMonth,SalesType,ProductID,Quantity,  " +
                        "(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,    " +
                        "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT    " +
                        "from  (    " +
                        "select SalespersonID,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,month(invoicedate) as TMonth,    " +
                        "SalesType,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity    " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,t_Retailconsumer sc,t_CalendarWeek    " +
                        "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and     " +
                        "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate < '" + LastDateOfThisMonth + "'    " +
                        "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate     " +
                        "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   )as a    " +
                        "left outer join    " +
                        "(    " +
                        "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC    " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd    " +
                        "where sa.invoiceid = sd.invoiceid and invoicedate   " +
                        "between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and   " +
                        "invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (6,7,9,10,12)and   " +
                        "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge    " +
                        ") as b   " +
                        "on a.invoiceid = b.invoiceid    " +
                        ") as final    " +
                        "Group By SalespersonID,SalesType,WeekNo,TYear,TMonth,ProductID    " +
                        ")as FinalQuery    " +
                        "Group by  SalespersonID,SalesType,WeekNo,TYear,TMonth,ProductID    " +
                        ") Main     " +
                        "inner join    " +
                        "(    " +
                        "Select * from v_productdetails  ) as p on Main.productid = p.productid    " +
                        ") Sales   " +
                        "group by SalespersonID,SalesType,TYear,TMonth,WeekNo,MAGID,MAGName,PGID,PGName,BrandID,BrandDesc) as Sales  " +
                        ") a group by SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName) A  " +
                        "Inner Join   " +
                        "(Select * from t_Employee) as b   " +
                        "on A.SalesPersonID = b.EmployeeID  " +
                        ") Main where 1=1";
            }
            else if (nType == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
            {
                sSql = "Select * From  " +
                        "(  " +
                        "Select a.*,'['+EmployeeCode+']'+' '+ EmployeeName as EmployeeName,  " +
                        "isnull(nullif(RetailSalesQty,0)/nullif(CAST(RetailTGTQty as float),0)*100,0) as RTLQtyPercentage,   " +
                        "isnull(nullif(DealerSalesQty,0)/nullif(CAST(DealerTGTQty as float),0)*100,0) as DealerQtyPercentage,   " +
                        "isnull(nullif(B2BSalesQty,0)/nullif(CAST(B2BTGTQty as float),0)*100,0) as B2BQtyPercentage,   " +
                        "isnull(nullif(eStoreSalesQty,0)/nullif(CAST(eStoreTGTQty as float),0)*100,0) as eStoreQtyPercentage,   " +
                        "isnull(nullif(RetailSalesVal,0)/nullif(CAST(RetailTGTVal as float),0)*100,0) as RTLValPercentage,   " +
                        "isnull(nullif(DealerSalesVal,0)/nullif(CAST(DealerTGTVal as float),0)*100,0) as DealerValPercentage,   " +
                        "isnull(nullif(B2BSalesVal,0)/nullif(CAST(B2BTGTVal as float),0)*100,0) as B2BValPercentage,   " +
                        "isnull(nullif(eStoreSalesVal,0)/nullif(CAST(eStoreTGTVal as float),0)*100,0) as eStoreValPercentage,   " +
                        "isnull(RetailSalesQty+DealerSalesQty+B2BSalesQty+eStoreSalesQty,0) as TotalSalesQty,   " +
                        "isnull(RetailTGTQty+DealerTGTQty+B2BTGTQty+eStoreTGTQty,0) as TotalTGTQty,   " +
                        "isnull(nullif(RetailSalesQty+DealerSalesQty+B2BSalesQty+eStoreSalesQty,0)/nullif(CAST((RetailTGTQty+DealerTGTQty+B2BTGTQty+eStoreTGTQty) as float),0)*100,0) as TotalQtyPercentage,   " +
                        "isnull(RetailSalesVal+DealerSalesVal+B2BSalesVal+eStoreSalesVal,0) as TotalSalesVal,   " +
                        "isnull(RetailTGTVal+DealerTGTVal+B2BTGTVal+eStoreTGTVal,0) as TotalTGTVal,   " +
                        "isnull(nullif(RetailSalesVal+DealerSalesVal+B2BSalesVal+eStoreSalesVal,0)/nullif(CAST((RetailTGTVal+DealerTGTVal+B2BTGTVal+eStoreTGTVal) as float),0)*100,0) as TotalValPercentage  " +
                        "from   " +
                        "(Select SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName,   " +
                        "sum(RetailTGTQty) RetailTGTQty,sum(DealerTGTQty) DealerTGTQty,sum(B2BTGTQty) B2BTGTQty,sum(eStoreTGTQty) eStoreTGTQty,   " +
                        "sum(RetailSalesQty) RetailSalesQty,sum(DealerSalesQty) DealerSalesQty,sum(B2BSalesQty) B2BSalesQty,sum(eStoreSalesQty) eStoreSalesQty,   " +
                        "sum(RetailTGTVal) RetailTGTVal,sum(DealerTGTVal) DealerTGTVal,sum(B2BTGTVal) B2BTGTVal,sum(eStoreTGTVal) eStoreTGTVal,   " +
                        "sum(RetailSalesVal) RetailSalesVal,sum(DealerSalesVal) DealerSalesVal,sum(B2BSalesVal) B2BSalesVal,sum(eStoreSalesVal) eStoreSalesVal From   " +
                        "(  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,a.BrandID,BrandDesc as Brand,a.MAGID,c.PDTGroupName as MAGName,  " +
                        "d.PdtGroupID as PGID,d.PDTGroupName as PGName,  " +
                        "sum(case Channel when 4 then TargetQty else 0 end) as RetailTGTQty,  " +
                        "sum(case Channel when 3 then TargetQty else 0 end) as DealerTGTQty,  " +
                        "sum(case Channel when 13 then TargetQty else 0 end) as B2BTGTQty,  " +
                        "sum(case Channel when 16 then TargetQty else 0 end) as eStoreTGTQty,  " +
                        "sum(case Channel when 4 then TargetAmount else 0 end) as RetailTGTVal,  " +
                        "sum(case Channel when 3 then TargetAmount else 0 end) as DealerTGTVal,  " +
                        "sum(case Channel when 13 then TargetAmount else 0 end) as B2BTGTVal,  " +
                        "sum(case Channel when 16 then TargetAmount else 0 end) as eStoreTGTVal,  " +
                        "0 RetailSalesQty,0 DealerSalesQty,0 B2BSalesQty,0 eStoreSalesQty,  " +
                        "0 RetailSalesVal,0 DealerSalesVal,0 B2BSalesVal,0 eStoreSalesVal  " +
                        "From t_PlanExecutiveLeadTarget a,t_Brand b,t_ProductGroup c,t_ProductGroup d    " +
                        "where a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID  " +
                        "and TYear=" + nTGTYear + "  and TMonth=" + nTGTMonth + " and TargetAmount>0 and TargetType=" + (int)Dictionary.PlanVersionType.ExecutiveLeadTarget + "  " +
                        "group by SalesPersonID,TYear,TMonth,WeekNo,a.BrandID,BrandDesc,  " +
                        "a.MAGID,c.PDTGroupName,d.PdtGroupID,d.PDTGroupName  " +
                        "Union All  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,  " +
                        "PGID,PGName,0 RetailTGTQty,0 DealerTGTQty,0 B2BTGTQty,0 eStoreTGTQty,  " +
                        "0 RetailTGTValue,0 DealerTGTValue,0 B2BTGTValue,0 eStoreTGTValue,  " +
                        "(RetailSalesQty+B2CSalesQty+HPASalesQty) as RetailSalesQty,DealerSalesQty,B2BSalesQty,EStoreSalesQty,  " +
                        "(RetailSalesVal+B2CSalesVal+HPASalesVal) as RetailSalesVal,DealerSalesVal,B2BSalesVal,EStoreSalesVal  " +
                        "From   " +
                        "(  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,  " +
                        "PGID,PGName,  " +
                        "sum(case CustomerType when 1 then Qty else 0 end) as RetailSalesQty,  " +
                        "sum(case CustomerType when 2 then Qty else 0 end) as B2CSalesQty,  " +
                        "sum(case CustomerType when 3 then Qty else 0 end) as B2BSalesQty,  " +
                        "sum(case CustomerType when 4 then Qty else 0 end) as HPASalesQty,  " +
                        "sum(case CustomerType when 5 then Qty else 0 end) as DealerSalesQty,  " +
                        "sum(case CustomerType when 6 then Qty else 0 end) as EStoreSalesQty,  " +
                        "sum(case CustomerType when 1 then LeadAmount else 0 end) as RetailSalesVal,  " +
                        "sum(case CustomerType when 2 then LeadAmount else 0 end) as B2CSalesVal,  " +
                        "sum(case CustomerType when 3 then LeadAmount else 0 end) as B2BSalesVal,  " +
                        "sum(case CustomerType when 4 then LeadAmount else 0 end) as HPASalesVal,  " +
                        "sum(case CustomerType when 5 then LeadAmount else 0 end) as DealerSalesVal,  " +
                        "sum(case CustomerType when 6 then LeadAmount else 0 end) as EStoreSalesVal  " +
                        "From   " +
                        "(  " +
                        "Select SalespersonID,CustomerType,Year(ExpExecuteDate) as TYear,Month(ExpExecuteDate) as TMonth,WeekNo,a.BrandID,BrandDesc as Brand,  " +
                        "a.MAGID,c.PDTGroupName as MAGName,d.PdtGroupID as PGID,d.PDTGroupName as PGName,isnull(Qty,1) as Qty,LeadAmount  " +
                        "From t_SalesLeadManagement a,t_CalendarWeek,t_Brand b,t_ProductGroup c,t_ProductGroup d    " +
                        "where a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID  " +
                        "and ExpExecuteDate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'   " +
                        "and ExpExecuteDate < '" + LastDateOfThisMonth + "' and convert(datetime,(convert(varchar(12),ExpExecuteDate,106))) between fromdate and todate   " +
                        ") a group by SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName  " +
                        ") x  " +
                        ") Main group by SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName) A  " +
                        "Inner Join   " +
                        "(Select * From t_Employee) b  " +
                        "on a.SalesPersonID=b.EmployeeID  " +
                        ") Main where 1=1";
            }
            if (nTGTWeek != -1)
            {
                sSql = sSql + " AND WeekNo=" + nTGTWeek + "";
            }
            if (nSalesPersonID != -1)
            {
                sSql = sSql + " AND SalesPersonID=" + nSalesPersonID + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();

                    _oDailySalesReport.EmployeeID = Convert.ToInt32(reader["SalesPersonID"].ToString());
                    _oDailySalesReport.EmployeeName = reader["EmployeeName"].ToString();
                    _oDailySalesReport.TYear = Convert.ToInt32(reader["TYear"].ToString());
                    _oDailySalesReport.TMonth = Convert.ToInt32(reader["TMonth"].ToString());
                    _oDailySalesReport.TWeek = Convert.ToInt32(reader["WeekNo"].ToString());
                    _oDailySalesReport.MAGName = reader["MAGName"].ToString();
                    _oDailySalesReport.Brand = reader["Brand"].ToString();
                    _oDailySalesReport.PGName = reader["PGName"].ToString();
                    _oDailySalesReport.RTLTGRQty = Convert.ToInt32(reader["RetailTGTQty"].ToString());
                    _oDailySalesReport.RTLSalesQty = Convert.ToInt32(reader["RetailSalesQty"].ToString());
                    _oDailySalesReport.DealerTGTQty = Convert.ToInt32(reader["DealerTGTQty"].ToString());
                    _oDailySalesReport.DealerSalesQty = Convert.ToInt32(reader["DealerSalesQty"].ToString());
                    _oDailySalesReport.B2BTGTQty = Convert.ToInt32(reader["B2BTGTQty"].ToString());
                    _oDailySalesReport.B2BSalesQty = Convert.ToInt32(reader["B2BSalesQty"].ToString());
                    _oDailySalesReport.eStoreTGTQty = Convert.ToInt32(reader["eStoreTGTQty"].ToString());
                    _oDailySalesReport.eStoreSalesQty = Convert.ToInt32(reader["eStoreSalesQty"].ToString());
                    _oDailySalesReport.RetailTGTVal = Convert.ToDouble(reader["RetailTGTVal"].ToString());
                    _oDailySalesReport.RTLSalesVal = Convert.ToDouble(reader["RetailSalesVal"].ToString());
                    _oDailySalesReport.DealerTGTVal = Convert.ToDouble(reader["DealerTGTVal"].ToString());
                    _oDailySalesReport.DealerSalesVal = Convert.ToDouble(reader["DealerSalesVal"].ToString());
                    _oDailySalesReport.B2BTGTVal = Convert.ToDouble(reader["B2BTGTVal"].ToString());
                    _oDailySalesReport.B2BSalesVal = Convert.ToDouble(reader["B2BSalesVal"].ToString());
                    _oDailySalesReport.eStoreTGTVal = Convert.ToDouble(reader["eStoreTGTVal"].ToString());
                    _oDailySalesReport.eStoreSalesVal = Convert.ToDouble(reader["eStoreSalesVal"].ToString());
                    _oDailySalesReport.RTLQtyPercentage = Convert.ToDouble(reader["RTLQtyPercentage"].ToString());
                    _oDailySalesReport.DealerQtyPercentage = Convert.ToDouble(reader["DealerQtyPercentage"].ToString());
                    _oDailySalesReport.B2BQtyPercentage = Convert.ToDouble(reader["B2BQtyPercentage"].ToString());
                    _oDailySalesReport.eStoreQtyPercentage = Convert.ToDouble(reader["eStoreQtyPercentage"].ToString());
                    _oDailySalesReport.RTLValPercentage = Convert.ToDouble(reader["RTLValPercentage"].ToString());
                    _oDailySalesReport.DealerValPercentage = Convert.ToDouble(reader["DealerValPercentage"].ToString());
                    _oDailySalesReport.B2BValPercentage = Convert.ToDouble(reader["B2BValPercentage"].ToString());
                    _oDailySalesReport.eStoreValPercentage = Convert.ToDouble(reader["eStoreValPercentage"].ToString());
                    _oDailySalesReport.TotalSalesQty = Convert.ToDouble(reader["TotalSalesQty"].ToString());
                    _oDailySalesReport.TotalTGTQty = Convert.ToDouble(reader["TotalTGTQty"].ToString());
                    _oDailySalesReport.TotalQtyPercentage = Convert.ToDouble(reader["TotalQtyPercentage"].ToString());
                    _oDailySalesReport.TotalSalesVal = Convert.ToDouble(reader["TotalSalesVal"].ToString());
                    _oDailySalesReport.TotalTGTVal = Convert.ToDouble(reader["TotalTGTVal"].ToString());
                    _oDailySalesReport.TotalValPercentage = Convert.ToDouble(reader["TotalValPercentage"].ToString());

                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void EmployeeMAGWeekTgtVsAchRetail(DateTime FirstDateOfThisMonth, DateTime LastDateOfThisMonth, int nTGTYear, int nTGTMonth, int nTGTWeek, int nType, int nSalesPersonID)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (nType == (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty)
            {
                sSql = "Select * From  " +
                        "(  " +
                        "Select a.*,'['+EmployeeCode+']'+' '+ EmployeeName as EmployeeName,  " +
                        "isnull(nullif(RetailSalesQty,0)/nullif(CAST(RetailTGTQty as float),0)*100,0) as RTLQtyPercentage,   " +
                        "isnull(nullif(DealerSalesQty,0)/nullif(CAST(DealerTGTQty as float),0)*100,0) as DealerQtyPercentage,   " +
                        "isnull(nullif(B2BSalesQty,0)/nullif(CAST(B2BTGTQty as float),0)*100,0) as B2BQtyPercentage,   " +
                        "isnull(nullif(eStoreSalesQty,0)/nullif(CAST(eStoreTGTQty as float),0)*100,0) as eStoreQtyPercentage,   " +
                        "isnull(nullif(RetailSalesVal,0)/nullif(CAST(RetailTGTVal as float),0)*100,0) as RTLValPercentage,   " +
                        "isnull(nullif(DealerSalesVal,0)/nullif(CAST(DealerTGTVal as float),0)*100,0) as DealerValPercentage,   " +
                        "isnull(nullif(B2BSalesVal,0)/nullif(CAST(B2BTGTVal as float),0)*100,0) as B2BValPercentage,   " +
                        "isnull(nullif(eStoreSalesVal,0)/nullif(CAST(eStoreTGTVal as float),0)*100,0) as eStoreValPercentage,   " +
                        "isnull(RetailSalesQty+B2BSalesQty+eStoreSalesQty,0) as TotalSalesQty,   " +
                        "isnull(RetailTGTQty+B2BTGTQty+eStoreTGTQty,0) as TotalTGTQty,   " +
                        "isnull(nullif(RetailSalesQty+B2BSalesQty+eStoreSalesQty,0)/nullif(CAST((RetailTGTQty+B2BTGTQty+eStoreTGTQty) as float),0)*100,0) as TotalQtyPercentage,   " +
                        "isnull(RetailSalesVal+B2BSalesVal+eStoreSalesVal,0) as TotalSalesVal,   " +
                        "isnull(RetailTGTVal+B2BTGTVal+eStoreTGTVal,0) as TotalTGTVal,   " +
                        "isnull(nullif(RetailSalesVal+B2BSalesVal+eStoreSalesVal,0)/nullif(CAST((RetailTGTVal+B2BTGTVal+eStoreTGTVal) as float),0)*100,0) as TotalValPercentage  " +
                        "From   " +
                        "(  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName,   " +
                        "sum(RetailTGTQty) RetailTGTQty,sum(DealerTGTQty) DealerTGTQty,sum(B2BTGTQty) B2BTGTQty,sum(eStoreTGTQty) eStoreTGTQty,   " +
                        "sum(RetailSalesQty) RetailSalesQty,sum(DealerSalesQty) DealerSalesQty,sum(B2BSalesQty) B2BSalesQty,sum(eStoreSalesQty) eStoreSalesQty,   " +
                        "sum(RetailTGTVal) RetailTGTVal,sum(DealerTGTVal) DealerTGTVal,sum(B2BTGTVal) B2BTGTVal,sum(eStoreTGTVal) eStoreTGTVal,   " +
                        "sum(RetailSalesVal) RetailSalesVal,sum(DealerSalesVal) DealerSalesVal,sum(B2BSalesVal) B2BSalesVal,sum(eStoreSalesVal) eStoreSalesVal  " +
                        "From  " +
                        "(  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,a.BrandID,BrandDesc as Brand,a.MAGID,c.PDTGroupName as MAGName,  " +
                        "d.PdtGroupID as PGID,d.PDTGroupName as PGName,  " +
                        "sum(case Channel when 4 then TargetQty else 0 end) as RetailTGTQty,  " +
                        "sum(case Channel when 3 then TargetQty else 0 end) as DealerTGTQty,  " +
                        "sum(case Channel when 13 then TargetQty else 0 end) as B2BTGTQty,  " +
                        "sum(case Channel when 16 then TargetQty else 0 end) as eStoreTGTQty,  " +
                        "sum(case Channel when 4 then TargetAmount else 0 end) as RetailTGTVal,  " +
                        "sum(case Channel when 3 then TargetAmount else 0 end) as DealerTGTVal,  " +
                        "sum(case Channel when 13 then TargetAmount else 0 end) as B2BTGTVal,  " +
                        "sum(case Channel when 16 then TargetAmount else 0 end) as eStoreTGTVal,  " +
                        "0 RetailSalesQty,0 DealerSalesQty,0 B2BSalesQty,0 eStoreSalesQty,  " +
                        "0 RetailSalesVal,0 DealerSalesVal,0 B2BSalesVal,0 eStoreSalesVal  " +
                        "From t_PlanExecutiveLeadTarget a,t_Brand b,t_ProductGroup c,t_ProductGroup d    " +
                        "where a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID  " +
                        "and TYear=" + nTGTYear + " and TMonth=" + nTGTMonth + " and TargetAmount>0 and TargetType=" + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + "  " +
                        "group by SalesPersonID,TYear,TMonth,WeekNo,a.BrandID,BrandDesc,  " +
                        "a.MAGID,c.PDTGroupName,d.PdtGroupID,d.PDTGroupName  " +
                        "Union All  " +
                        "Select SalespersonID,TYear,TMonth,WeekNo,BrandID,BrandDesc,MAGID,MAGName,PGID,PGName,  " +
                        "0 RetailTGTQty,0 DealerTGTQty,0 B2BTGTQty,0 eStoreTGTQty,  " +
                        "0 RetailTGTValue,0 DealerTGTValue,0 B2BTGTValue,0 eStoreTGTValue,  " +
                        "(RetailSalesQty+B2CSalesQty+HPASalesQty) RetailSalesQty,DealerSalesQty,B2BSalesQty,eStoreSalesQty,  " +
                        "(RetailSalesVal+B2CSalesVal+HPASalesVal) RetailSalesVal,DealerSalesVal,B2BSalesVal,eStoreSalesVal From     " +
                        "(  " +
                        "Select SalespersonID,TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID,MAGName,  " +
                        "sum(case SalesType when 1 then SalesQty else 0 end) as RetailSalesQty,  " +
                        "sum(case SalesType when 2 then SalesQty else 0 end) as B2CSalesQty,  " +
                        "sum(case SalesType when 4 then SalesQty else 0 end) as HPASalesQty,  " +
                        "sum(case SalesType when 5 then SalesQty else 0 end) as DealerSalesQty,  " +
                        "sum(case SalesType when 3 then SalesQty else 0 end) as B2BSalesQty,  " +
                        "sum(case SalesType when 6 then SalesQty else 0 end) as eStoreSalesQty,  " +
                        "sum(case SalesType when 1 then NetSales else 0 end) as RetailSalesVal,  " +
                        "sum(case SalesType when 2 then NetSales else 0 end) as B2CSalesVal,  " +
                        "sum(case SalesType when 4 then NetSales else 0 end) as HPASalesVal,  " +
                        "sum(case SalesType when 5 then NetSales else 0 end) as DealerSalesVal,  " +
                        "sum(case SalesType when 3 then NetSales else 0 end) as B2BSalesVal,  " +
                        "sum(case SalesType when 6 then NetSales else 0 end) as eStoreSalesVal  " +
                        "From     " +
                        "(    " +
                        "Select SalespersonID,SalesType,TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID,  " +
                        "MAGName,SalesQty,(GrossSales+OC-Main.VAT-Discount) as NetSales   " +
                        "From (  " +
                        "Select SalespersonID,SalesType,TYear,TMonth,WeekNo,ProductID,   " +
                        "isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,    " +
                        "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,  " +
                        "isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT    " +
                        "From    " +
                        "(  " +
                        "Select SalespersonID,SalesType,TYear,WeekNo,TMonth,ProductID,sum(quantity)as crqty,   " +
                        "0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales,    " +
                        "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS,   " +
                        "0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT    " +
                        "from    " +
                        "(    " +
                        "Select SalespersonID,SalesType,a.InvoiceID,  " +
                        "WeekNo,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales,  " +
                        "(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,    " +
                        "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT    " +
                        "from  (    " +
                        "select SalespersonID,SalesType,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,  " +
                        "month(invoicedate) as TMonth,  ProductID,UnitPrice,Costprice,  " +
                        "TradePrice,VatAmount,Discount,quantity    " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,t_RetailConsumer sc,t_CalendarWeek    " +
                        "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and     " +
                        "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'   " +
                        "and invoicedate < '" + LastDateOfThisMonth + "'    " +
                        "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate     " +
                        "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)     " +
                        ")as a    " +
                        "left outer join    " +
                        "(    " +
                        "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,  " +
                        "isnull((OtherCharge/sum(quantity)),0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd    " +
                        "where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'   " +
                        "and invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (1,2,4,5)and   " +
                        "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge    " +
                        ") as b   " +
                        "on a.invoiceid = b.invoiceid) as final  Group By SalespersonID,SalesType,TYear,TMonth,WeekNo,ProductID    " +
                        "Union all    " +
                        "Select SalespersonID,SalesType,TYear,WeekNo,TMonth,ProductID,0 as crqty,   " +
                        "sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,    " +
                        "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,  " +
                        "0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT    " +
                        "from  (    " +
                        "Select SalespersonID,a.InvoiceID,WeekNo,TYear,TMonth,SalesType,ProductID,Quantity,  " +
                        "(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,    " +
                        "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT    " +
                        "from  (    " +
                        "select SalespersonID,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,month(invoicedate) as TMonth,    " +
                        "SalesType,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity    " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,t_Retailconsumer sc,t_CalendarWeek    " +
                        "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and     " +
                        "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate < '" + LastDateOfThisMonth + "'    " +
                        "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate     " +
                        "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   )as a    " +
                        "left outer join    " +
                        "(    " +
                        "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC    " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd    " +
                        "where sa.invoiceid = sd.invoiceid and invoicedate   " +
                        "between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and   " +
                        "invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (6,7,9,10,12)and   " +
                        "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge    " +
                        ") as b   " +
                        "on a.invoiceid = b.invoiceid    " +
                        ") as final    " +
                        "Group By SalespersonID,SalesType,WeekNo,TYear,TMonth,ProductID    " +
                        ")as FinalQuery    " +
                        "Group by  SalespersonID,SalesType,WeekNo,TYear,TMonth,ProductID    " +
                        ") Main     " +
                        "inner join    " +
                        "(    " +
                        "Select * from v_productdetails  ) as p on Main.productid = p.productid    " +
                        ") Sales   " +
                        "group by SalespersonID,SalesType,TYear,TMonth,WeekNo,MAGID,MAGName,PGID,PGName,BrandID,BrandDesc) as Sales  " +
                        ") a group by SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName) A  " +
                        "Inner Join   " +
                        "(Select * from t_Employee) as b   " +
                        "on A.SalesPersonID = b.EmployeeID  " +
                        ") Main where 1=1";
            }
            else if (nType == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
            {
                sSql = "Select * From  " +
                        "(  " +
                        "Select a.*,'['+EmployeeCode+']'+' '+ EmployeeName as EmployeeName,  " +
                        "isnull(nullif(RetailSalesQty,0)/nullif(CAST(RetailTGTQty as float),0)*100,0) as RTLQtyPercentage,   " +
                        "isnull(nullif(DealerSalesQty,0)/nullif(CAST(DealerTGTQty as float),0)*100,0) as DealerQtyPercentage,   " +
                        "isnull(nullif(B2BSalesQty,0)/nullif(CAST(B2BTGTQty as float),0)*100,0) as B2BQtyPercentage,   " +
                        "isnull(nullif(eStoreSalesQty,0)/nullif(CAST(eStoreTGTQty as float),0)*100,0) as eStoreQtyPercentage,   " +
                        "isnull(nullif(RetailSalesVal,0)/nullif(CAST(RetailTGTVal as float),0)*100,0) as RTLValPercentage,   " +
                        "isnull(nullif(DealerSalesVal,0)/nullif(CAST(DealerTGTVal as float),0)*100,0) as DealerValPercentage,   " +
                        "isnull(nullif(B2BSalesVal,0)/nullif(CAST(B2BTGTVal as float),0)*100,0) as B2BValPercentage,   " +
                        "isnull(nullif(eStoreSalesVal,0)/nullif(CAST(eStoreTGTVal as float),0)*100,0) as eStoreValPercentage,   " +
                        "isnull(RetailSalesQty+B2BSalesQty+eStoreSalesQty,0) as TotalSalesQty,   " +
                        "isnull(RetailTGTQty+B2BTGTQty+eStoreTGTQty,0) as TotalTGTQty,   " +
                        "isnull(nullif(RetailSalesQty+B2BSalesQty+eStoreSalesQty,0)/nullif(CAST((RetailTGTQty+B2BTGTQty+eStoreTGTQty) as float),0)*100,0) as TotalQtyPercentage,   " +
                        "isnull(RetailSalesVal+B2BSalesVal+eStoreSalesVal,0) as TotalSalesVal,   " +
                        "isnull(RetailTGTVal+B2BTGTVal+eStoreTGTVal,0) as TotalTGTVal,   " +
                        "isnull(nullif(RetailSalesVal+B2BSalesVal+eStoreSalesVal,0)/nullif(CAST((RetailTGTVal+B2BTGTVal+eStoreTGTVal) as float),0)*100,0) as TotalValPercentage  " +
                        "from   " +
                        "(Select SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName,   " +
                        "sum(RetailTGTQty) RetailTGTQty,sum(DealerTGTQty) DealerTGTQty,sum(B2BTGTQty) B2BTGTQty,sum(eStoreTGTQty) eStoreTGTQty,   " +
                        "sum(RetailSalesQty) RetailSalesQty,sum(DealerSalesQty) DealerSalesQty,sum(B2BSalesQty) B2BSalesQty,sum(eStoreSalesQty) eStoreSalesQty,   " +
                        "sum(RetailTGTVal) RetailTGTVal,sum(DealerTGTVal) DealerTGTVal,sum(B2BTGTVal) B2BTGTVal,sum(eStoreTGTVal) eStoreTGTVal,   " +
                        "sum(RetailSalesVal) RetailSalesVal,sum(DealerSalesVal) DealerSalesVal,sum(B2BSalesVal) B2BSalesVal,sum(eStoreSalesVal) eStoreSalesVal From   " +
                        "(  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,a.BrandID,BrandDesc as Brand,a.MAGID,c.PDTGroupName as MAGName,  " +
                        "d.PdtGroupID as PGID,d.PDTGroupName as PGName,  " +
                        "sum(case Channel when 4 then TargetQty else 0 end) as RetailTGTQty,  " +
                        "sum(case Channel when 3 then TargetQty else 0 end) as DealerTGTQty,  " +
                        "sum(case Channel when 13 then TargetQty else 0 end) as B2BTGTQty,  " +
                        "sum(case Channel when 16 then TargetQty else 0 end) as eStoreTGTQty,  " +
                        "sum(case Channel when 4 then TargetAmount else 0 end) as RetailTGTVal,  " +
                        "sum(case Channel when 3 then TargetAmount else 0 end) as DealerTGTVal,  " +
                        "sum(case Channel when 13 then TargetAmount else 0 end) as B2BTGTVal,  " +
                        "sum(case Channel when 16 then TargetAmount else 0 end) as eStoreTGTVal,  " +
                        "0 RetailSalesQty,0 DealerSalesQty,0 B2BSalesQty,0 eStoreSalesQty,  " +
                        "0 RetailSalesVal,0 DealerSalesVal,0 B2BSalesVal,0 eStoreSalesVal  " +
                        "From t_PlanExecutiveLeadTarget a,t_Brand b,t_ProductGroup c,t_ProductGroup d    " +
                        "where a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID  " +
                        "and TYear=" + nTGTYear + "  and TMonth=" + nTGTMonth + " and TargetAmount>0 and TargetType=" + (int)Dictionary.PlanVersionType.ExecutiveLeadTarget + "  " +
                        "group by SalesPersonID,TYear,TMonth,WeekNo,a.BrandID,BrandDesc,  " +
                        "a.MAGID,c.PDTGroupName,d.PdtGroupID,d.PDTGroupName  " +
                        "Union All  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,  " +
                        "PGID,PGName,0 RetailTGTQty,0 DealerTGTQty,0 B2BTGTQty,0 eStoreTGTQty,  " +
                        "0 RetailTGTValue,0 DealerTGTValue,0 B2BTGTValue,0 eStoreTGTValue,  " +
                        "(RetailSalesQty+B2CSalesQty+HPASalesQty) as RetailSalesQty,DealerSalesQty,B2BSalesQty,EStoreSalesQty,  " +
                        "(RetailSalesVal+B2CSalesVal+HPASalesVal) as RetailSalesVal,DealerSalesVal,B2BSalesVal,EStoreSalesVal  " +
                        "From   " +
                        "(  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,  " +
                        "PGID,PGName,  " +
                        "sum(case CustomerType when 1 then Qty else 0 end) as RetailSalesQty,  " +
                        "sum(case CustomerType when 2 then Qty else 0 end) as B2CSalesQty,  " +
                        "sum(case CustomerType when 3 then Qty else 0 end) as B2BSalesQty,  " +
                        "sum(case CustomerType when 4 then Qty else 0 end) as HPASalesQty,  " +
                        "sum(case CustomerType when 5 then Qty else 0 end) as DealerSalesQty,  " +
                        "sum(case CustomerType when 6 then Qty else 0 end) as EStoreSalesQty,  " +
                        "sum(case CustomerType when 1 then LeadAmount else 0 end) as RetailSalesVal,  " +
                        "sum(case CustomerType when 2 then LeadAmount else 0 end) as B2CSalesVal,  " +
                        "sum(case CustomerType when 3 then LeadAmount else 0 end) as B2BSalesVal,  " +
                        "sum(case CustomerType when 4 then LeadAmount else 0 end) as HPASalesVal,  " +
                        "sum(case CustomerType when 5 then LeadAmount else 0 end) as DealerSalesVal,  " +
                        "sum(case CustomerType when 6 then LeadAmount else 0 end) as EStoreSalesVal  " +
                        "From   " +
                        "(  " +
                        "Select SalespersonID,CustomerType,Year(ExpExecuteDate) as TYear,Month(ExpExecuteDate) as TMonth,WeekNo,a.BrandID,BrandDesc as Brand,  " +
                        "a.MAGID,c.PDTGroupName as MAGName,d.PdtGroupID as PGID,d.PDTGroupName as PGName,isnull(Qty,1) as Qty,LeadAmount  " +
                        "From t_SalesLeadManagement a,t_CalendarWeek,t_Brand b,t_ProductGroup c,t_ProductGroup d    " +
                        "where a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID  " +
                        "and ExpExecuteDate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'   " +
                        "and ExpExecuteDate < '" + LastDateOfThisMonth + "' and convert(datetime,(convert(varchar(12),ExpExecuteDate,106))) between fromdate and todate   " +
                        ") a group by SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName  " +
                        ") x  " +
                        ") Main group by SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName) A  " +
                        "Inner Join   " +
                        "(Select * From t_Employee) b  " +
                        "on a.SalesPersonID=b.EmployeeID  " +
                        ") Main where 1=1";
            }
            if (nTGTWeek != -1)
            {
                sSql = sSql + " AND WeekNo=" + nTGTWeek + "";
            }
            if (nSalesPersonID != -1)
            {
                sSql = sSql + " AND SalesPersonID=" + nSalesPersonID + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();

                    _oDailySalesReport.EmployeeID = Convert.ToInt32(reader["SalesPersonID"].ToString());
                    _oDailySalesReport.EmployeeName = reader["EmployeeName"].ToString();
                    _oDailySalesReport.TYear = Convert.ToInt32(reader["TYear"].ToString());
                    _oDailySalesReport.TMonth = Convert.ToInt32(reader["TMonth"].ToString());
                    _oDailySalesReport.TWeek = Convert.ToInt32(reader["WeekNo"].ToString());
                    _oDailySalesReport.MAGName = reader["MAGName"].ToString();
                    _oDailySalesReport.Brand = reader["Brand"].ToString();
                    _oDailySalesReport.PGName = reader["PGName"].ToString();
                    _oDailySalesReport.RTLTGRQty = Convert.ToInt32(reader["RetailTGTQty"].ToString());
                    _oDailySalesReport.RTLSalesQty = Convert.ToInt32(reader["RetailSalesQty"].ToString());
                    _oDailySalesReport.DealerTGTQty = Convert.ToInt32(reader["DealerTGTQty"].ToString());
                    _oDailySalesReport.DealerSalesQty = Convert.ToInt32(reader["DealerSalesQty"].ToString());
                    _oDailySalesReport.B2BTGTQty = Convert.ToInt32(reader["B2BTGTQty"].ToString());
                    _oDailySalesReport.B2BSalesQty = Convert.ToInt32(reader["B2BSalesQty"].ToString());
                    _oDailySalesReport.eStoreTGTQty = Convert.ToInt32(reader["eStoreTGTQty"].ToString());
                    _oDailySalesReport.eStoreSalesQty = Convert.ToInt32(reader["eStoreSalesQty"].ToString());
                    _oDailySalesReport.RetailTGTVal = Convert.ToDouble(reader["RetailTGTVal"].ToString());
                    _oDailySalesReport.RTLSalesVal = Convert.ToDouble(reader["RetailSalesVal"].ToString());
                    _oDailySalesReport.DealerTGTVal = Convert.ToDouble(reader["DealerTGTVal"].ToString());
                    _oDailySalesReport.DealerSalesVal = Convert.ToDouble(reader["DealerSalesVal"].ToString());
                    _oDailySalesReport.B2BTGTVal = Convert.ToDouble(reader["B2BTGTVal"].ToString());
                    _oDailySalesReport.B2BSalesVal = Convert.ToDouble(reader["B2BSalesVal"].ToString());
                    _oDailySalesReport.eStoreTGTVal = Convert.ToDouble(reader["eStoreTGTVal"].ToString());
                    _oDailySalesReport.eStoreSalesVal = Convert.ToDouble(reader["eStoreSalesVal"].ToString());
                    _oDailySalesReport.RTLQtyPercentage = Convert.ToDouble(reader["RTLQtyPercentage"].ToString());
                    _oDailySalesReport.DealerQtyPercentage = Convert.ToDouble(reader["DealerQtyPercentage"].ToString());
                    _oDailySalesReport.B2BQtyPercentage = Convert.ToDouble(reader["B2BQtyPercentage"].ToString());
                    _oDailySalesReport.eStoreQtyPercentage = Convert.ToDouble(reader["eStoreQtyPercentage"].ToString());
                    _oDailySalesReport.RTLValPercentage = Convert.ToDouble(reader["RTLValPercentage"].ToString());
                    _oDailySalesReport.DealerValPercentage = Convert.ToDouble(reader["DealerValPercentage"].ToString());
                    _oDailySalesReport.B2BValPercentage = Convert.ToDouble(reader["B2BValPercentage"].ToString());
                    _oDailySalesReport.eStoreValPercentage = Convert.ToDouble(reader["eStoreValPercentage"].ToString());
                    _oDailySalesReport.TotalSalesQty = Convert.ToDouble(reader["TotalSalesQty"].ToString());
                    _oDailySalesReport.TotalTGTQty = Convert.ToDouble(reader["TotalTGTQty"].ToString());
                    _oDailySalesReport.TotalQtyPercentage = Convert.ToDouble(reader["TotalQtyPercentage"].ToString());
                    _oDailySalesReport.TotalSalesVal = Convert.ToDouble(reader["TotalSalesVal"].ToString());
                    _oDailySalesReport.TotalTGTVal = Convert.ToDouble(reader["TotalTGTVal"].ToString());
                    _oDailySalesReport.TotalValPercentage = Convert.ToDouble(reader["TotalValPercentage"].ToString());

                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void EmployeeMAGWeekTgtVsAchRT(DateTime FirstDateOfThisMonth, DateTime LastDateOfThisMonth, int nTGTYear, int nTGTMonth, int nTGTWeek, int nType, int nSalesPersonID)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (nType == (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty)
            {
                sSql = "Select * From  " +
                        "(  " +
                        "Select a.*,'['+EmployeeCode+']'+' '+ EmployeeName as EmployeeName,  " +
                        "isnull(nullif(RetailSalesQty,0)/nullif(CAST(RetailTGTQty as float),0)*100,0) as RTLQtyPercentage,   " +
                        "isnull(nullif(DealerSalesQty,0)/nullif(CAST(DealerTGTQty as float),0)*100,0) as DealerQtyPercentage,   " +
                        "isnull(nullif(B2BSalesQty,0)/nullif(CAST(B2BTGTQty as float),0)*100,0) as B2BQtyPercentage,   " +
                        "isnull(nullif(eStoreSalesQty,0)/nullif(CAST(eStoreTGTQty as float),0)*100,0) as eStoreQtyPercentage,   " +
                        "isnull(nullif(RetailSalesVal,0)/nullif(CAST(RetailTGTVal as float),0)*100,0) as RTLValPercentage,   " +
                        "isnull(nullif(DealerSalesVal,0)/nullif(CAST(DealerTGTVal as float),0)*100,0) as DealerValPercentage,   " +
                        "isnull(nullif(B2BSalesVal,0)/nullif(CAST(B2BTGTVal as float),0)*100,0) as B2BValPercentage,   " +
                        "isnull(nullif(eStoreSalesVal,0)/nullif(CAST(eStoreTGTVal as float),0)*100,0) as eStoreValPercentage,   " +
                        "isnull(RetailSalesQty+DealerSalesQty+B2BSalesQty+eStoreSalesQty,0) as TotalSalesQty,   " +
                        "isnull(RetailTGTQty+DealerTGTQty+B2BTGTQty+eStoreTGTQty,0) as TotalTGTQty,   " +
                        "isnull(nullif(RetailSalesQty+DealerSalesQty+B2BSalesQty+eStoreSalesQty,0)/nullif(CAST((RetailTGTQty+DealerTGTQty+B2BTGTQty+eStoreTGTQty) as float),0)*100,0) as TotalQtyPercentage,   " +
                        "isnull(RetailSalesVal+DealerSalesVal+B2BSalesVal+eStoreSalesVal,0) as TotalSalesVal,   " +
                        "isnull(RetailTGTVal+DealerTGTVal+B2BTGTVal+eStoreTGTVal,0) as TotalTGTVal,   " +
                        "isnull(nullif(RetailSalesVal+DealerSalesVal+B2BSalesVal+eStoreSalesVal,0)/nullif(CAST((RetailTGTVal+DealerTGTVal+B2BTGTVal+eStoreTGTVal) as float),0)*100,0) as TotalValPercentage  " +
                        "From   " +
                        "(  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName,   " +
                        "sum(RetailTGTQty) RetailTGTQty,sum(DealerTGTQty) DealerTGTQty,sum(B2BTGTQty) B2BTGTQty,sum(eStoreTGTQty) eStoreTGTQty,   " +
                        "sum(RetailSalesQty) RetailSalesQty,sum(DealerSalesQty) DealerSalesQty,sum(B2BSalesQty) B2BSalesQty,sum(eStoreSalesQty) eStoreSalesQty,   " +
                        "sum(RetailTGTVal) RetailTGTVal,sum(DealerTGTVal) DealerTGTVal,sum(B2BTGTVal) B2BTGTVal,sum(eStoreTGTVal) eStoreTGTVal,   " +
                        "sum(RetailSalesVal) RetailSalesVal,sum(DealerSalesVal) DealerSalesVal,sum(B2BSalesVal) B2BSalesVal,sum(eStoreSalesVal) eStoreSalesVal  " +
                        "From  " +
                        "(  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,a.BrandID,BrandDesc as Brand,a.MAGID,c.PDTGroupName as MAGName,  " +
                        "d.PdtGroupID as PGID,d.PDTGroupName as PGName,  " +
                        "sum(case Channel when 4 then TargetQty else 0 end) as RetailTGTQty,  " +
                        "sum(case Channel when 3 then TargetQty else 0 end) as DealerTGTQty,  " +
                        "sum(case Channel when 13 then TargetQty else 0 end) as B2BTGTQty,  " +
                        "sum(case Channel when 16 then TargetQty else 0 end) as eStoreTGTQty,  " +
                        "sum(case Channel when 4 then TargetAmount else 0 end) as RetailTGTVal,  " +
                        "sum(case Channel when 3 then TargetAmount else 0 end) as DealerTGTVal,  " +
                        "sum(case Channel when 13 then TargetAmount else 0 end) as B2BTGTVal,  " +
                        "sum(case Channel when 16 then TargetAmount else 0 end) as eStoreTGTVal,  " +
                        "0 RetailSalesQty,0 DealerSalesQty,0 B2BSalesQty,0 eStoreSalesQty,  " +
                        "0 RetailSalesVal,0 DealerSalesVal,0 B2BSalesVal,0 eStoreSalesVal  " +
                        "From t_PlanExecutiveLeadTarget a,t_Brand b,t_ProductGroup c,t_ProductGroup d    " +
                        "where a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID  " +
                        "and a.CustomerID="+Utility.CustomerID+" and TYear=" + nTGTYear + " and TMonth=" + nTGTMonth + " and TargetAmount>0 and TargetType=" + (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty + "  " +
                        "group by SalesPersonID,TYear,TMonth,WeekNo,a.BrandID,BrandDesc,  " +
                        "a.MAGID,c.PDTGroupName,d.PdtGroupID,d.PDTGroupName  " +
                        "Union All  " +
                        "Select SalespersonID,TYear,TMonth,WeekNo,BrandID,BrandDesc,MAGID,MAGName,PGID,PGName,  " +
                        "0 RetailTGTQty,0 DealerTGTQty,0 B2BTGTQty,0 eStoreTGTQty,  " +
                        "0 RetailTGTValue,0 DealerTGTValue,0 B2BTGTValue,0 eStoreTGTValue,  " +
                        "(RetailSalesQty+B2CSalesQty+HPASalesQty) RetailSalesQty,DealerSalesQty,B2BSalesQty,eStoreSalesQty,  " +
                        "(RetailSalesVal+B2CSalesVal+HPASalesVal) RetailSalesVal,DealerSalesVal,B2BSalesVal,eStoreSalesVal From     " +
                        "(  " +
                        "Select SalespersonID,TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID,MAGName,  " +
                        "sum(case SalesType when 1 then SalesQty else 0 end) as RetailSalesQty,  " +
                        "sum(case SalesType when 2 then SalesQty else 0 end) as B2CSalesQty,  " +
                        "sum(case SalesType when 4 then SalesQty else 0 end) as HPASalesQty,  " +
                        "sum(case SalesType when 5 then SalesQty else 0 end) as DealerSalesQty,  " +
                        "sum(case SalesType when 3 then SalesQty else 0 end) as B2BSalesQty,  " +
                        "sum(case SalesType when 6 then SalesQty else 0 end) as eStoreSalesQty,  " +
                        "sum(case SalesType when 1 then NetSales else 0 end) as RetailSalesVal,  " +
                        "sum(case SalesType when 2 then NetSales else 0 end) as B2CSalesVal,  " +
                        "sum(case SalesType when 4 then NetSales else 0 end) as HPASalesVal,  " +
                        "sum(case SalesType when 5 then NetSales else 0 end) as DealerSalesVal,  " +
                        "sum(case SalesType when 3 then NetSales else 0 end) as B2BSalesVal,  " +
                        "sum(case SalesType when 6 then NetSales else 0 end) as eStoreSalesVal  " +
                        "From     " +
                        "(    " +
                        "Select SalespersonID,SalesType,TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID,  " +
                        "MAGName,SalesQty,(GrossSales+OC-Main.VAT-Discount) as NetSales   " +
                        "From (  " +
                        "Select SalespersonID,SalesType,TYear,TMonth,WeekNo,ProductID,   " +
                        "isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,    " +
                        "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,  " +
                        "isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT    " +
                        "From    " +
                        "(  " +
                        "Select SalespersonID,SalesType,TYear,WeekNo,TMonth,ProductID,sum(quantity)as crqty,   " +
                        "0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales,    " +
                        "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS,   " +
                        "0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT    " +
                        "from    " +
                        "(    " +
                        "Select SalespersonID,SalesType,a.InvoiceID,  " +
                        "WeekNo,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales,  " +
                        "(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,    " +
                        "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT    " +
                        "from  (    " +
                        "select SalespersonID,SalesType,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,  " +
                        "month(invoicedate) as TMonth,  ProductID,UnitPrice,Costprice,  " +
                        "TradePrice,VatAmount,Discount,quantity    " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,t_RetailConsumer sc,t_CalendarWeek    " +
                        "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and sa.WarehouseID=sc.WarehouseID and sa.WarehouseID=" + Utility.WarehouseID+" and     " +
                        "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'   " +
                        "and invoicedate < '" + LastDateOfThisMonth + "'    " +
                        "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate     " +
                        "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)     " +
                        ")as a    " +
                        "left outer join    " +
                        "(    " +
                        "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,  " +
                        "isnull((OtherCharge/sum(quantity)),0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd    " +
                        "where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'   " +
                        "and invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (1,2,4,5)and   " +
                        "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge    " +
                        ") as b   " +
                        "on a.invoiceid = b.invoiceid) as final  Group By SalespersonID,SalesType,TYear,TMonth,WeekNo,ProductID    " +
                        "Union all    " +
                        "Select SalespersonID,SalesType,TYear,WeekNo,TMonth,ProductID,0 as crqty,   " +
                        "sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,    " +
                        "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,  " +
                        "0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT    " +
                        "from  (    " +
                        "Select SalespersonID,a.InvoiceID,WeekNo,TYear,TMonth,SalesType,ProductID,Quantity,  " +
                        "(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,    " +
                        "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT    " +
                        "from  (    " +
                        "select SalespersonID,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,month(invoicedate) as TMonth,    " +
                        "SalesType,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity    " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd,t_Retailconsumer sc,t_CalendarWeek    " +
                        "where sa.WarehouseID=sc.WarehouseID and sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and     " +
                        "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate < '" + LastDateOfThisMonth + "'    " +
                        "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate     " +
                        "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   )as a    " +
                        "left outer join    " +
                        "(    " +
                        "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC    " +
                        "from t_salesinvoice sa, t_salesinvoicedetail sd    " +
                        "where sa.WarehouseID=" + Utility.WarehouseID + " and sa.invoiceid = sd.invoiceid and invoicedate   " +
                        "between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and   " +
                        "invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (6,7,9,10,12)and   " +
                        "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge    " +
                        ") as b   " +
                        "on a.invoiceid = b.invoiceid    " +
                        ") as final    " +
                        "Group By SalespersonID,SalesType,WeekNo,TYear,TMonth,ProductID    " +
                        ")as FinalQuery    " +
                        "Group by  SalespersonID,SalesType,WeekNo,TYear,TMonth,ProductID    " +
                        ") Main     " +
                        "inner join    " +
                        "(    " +
                        "Select * from v_productdetails  ) as p on Main.productid = p.productid    " +
                        ") Sales   " +
                        "group by SalespersonID,SalesType,TYear,TMonth,WeekNo,MAGID,MAGName,PGID,PGName,BrandID,BrandDesc) as Sales  " +
                        ") a group by SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName) A  " +
                        "Inner Join   " +
                        "(Select * from t_Employee) as b   " +
                        "on A.SalesPersonID = b.EmployeeID  " +
                        ") Main where 1=1";
            }
            else if (nType == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
            {
                sSql = "Select * From  " +
                        "(  " +
                        "Select a.*,'['+EmployeeCode+']'+' '+ EmployeeName as EmployeeName,  " +
                        "isnull(nullif(RetailSalesQty,0)/nullif(CAST(RetailTGTQty as float),0)*100,0) as RTLQtyPercentage,   " +
                        "isnull(nullif(DealerSalesQty,0)/nullif(CAST(DealerTGTQty as float),0)*100,0) as DealerQtyPercentage,   " +
                        "isnull(nullif(B2BSalesQty,0)/nullif(CAST(B2BTGTQty as float),0)*100,0) as B2BQtyPercentage,   " +
                        "isnull(nullif(eStoreSalesQty,0)/nullif(CAST(eStoreTGTQty as float),0)*100,0) as eStoreQtyPercentage,   " +
                        "isnull(nullif(RetailSalesVal,0)/nullif(CAST(RetailTGTVal as float),0)*100,0) as RTLValPercentage,   " +
                        "isnull(nullif(DealerSalesVal,0)/nullif(CAST(DealerTGTVal as float),0)*100,0) as DealerValPercentage,   " +
                        "isnull(nullif(B2BSalesVal,0)/nullif(CAST(B2BTGTVal as float),0)*100,0) as B2BValPercentage,   " +
                        "isnull(nullif(eStoreSalesVal,0)/nullif(CAST(eStoreTGTVal as float),0)*100,0) as eStoreValPercentage,   " +
                        "isnull(RetailSalesQty+DealerSalesQty+B2BSalesQty+eStoreSalesQty,0) as TotalSalesQty,   " +
                        "isnull(RetailTGTQty+DealerTGTQty+B2BTGTQty+eStoreTGTQty,0) as TotalTGTQty,   " +
                        "isnull(nullif(RetailSalesQty+DealerSalesQty+B2BSalesQty+eStoreSalesQty,0)/nullif(CAST((RetailTGTQty+DealerTGTQty+B2BTGTQty+eStoreTGTQty) as float),0)*100,0) as TotalQtyPercentage,   " +
                        "isnull(RetailSalesVal+DealerSalesVal+B2BSalesVal+eStoreSalesVal,0) as TotalSalesVal,   " +
                        "isnull(RetailTGTVal+DealerTGTVal+B2BTGTVal+eStoreTGTVal,0) as TotalTGTVal,   " +
                        "isnull(nullif(RetailSalesVal+DealerSalesVal+B2BSalesVal+eStoreSalesVal,0)/nullif(CAST((RetailTGTVal+DealerTGTVal+B2BTGTVal+eStoreTGTVal) as float),0)*100,0) as TotalValPercentage  " +
                        "from   " +
                        "(Select SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName,   " +
                        "sum(RetailTGTQty) RetailTGTQty,sum(DealerTGTQty) DealerTGTQty,sum(B2BTGTQty) B2BTGTQty,sum(eStoreTGTQty) eStoreTGTQty,   " +
                        "sum(RetailSalesQty) RetailSalesQty,sum(DealerSalesQty) DealerSalesQty,sum(B2BSalesQty) B2BSalesQty,sum(eStoreSalesQty) eStoreSalesQty,   " +
                        "sum(RetailTGTVal) RetailTGTVal,sum(DealerTGTVal) DealerTGTVal,sum(B2BTGTVal) B2BTGTVal,sum(eStoreTGTVal) eStoreTGTVal,   " +
                        "sum(RetailSalesVal) RetailSalesVal,sum(DealerSalesVal) DealerSalesVal,sum(B2BSalesVal) B2BSalesVal,sum(eStoreSalesVal) eStoreSalesVal From   " +
                        "(  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,a.BrandID,BrandDesc as Brand,a.MAGID,c.PDTGroupName as MAGName,  " +
                        "d.PdtGroupID as PGID,d.PDTGroupName as PGName,  " +
                        "sum(case Channel when 4 then TargetQty else 0 end) as RetailTGTQty,  " +
                        "sum(case Channel when 3 then TargetQty else 0 end) as DealerTGTQty,  " +
                        "sum(case Channel when 13 then TargetQty else 0 end) as B2BTGTQty,  " +
                        "sum(case Channel when 16 then TargetQty else 0 end) as eStoreTGTQty,  " +
                        "sum(case Channel when 4 then TargetAmount else 0 end) as RetailTGTVal,  " +
                        "sum(case Channel when 3 then TargetAmount else 0 end) as DealerTGTVal,  " +
                        "sum(case Channel when 13 then TargetAmount else 0 end) as B2BTGTVal,  " +
                        "sum(case Channel when 16 then TargetAmount else 0 end) as eStoreTGTVal,  " +
                        "0 RetailSalesQty,0 DealerSalesQty,0 B2BSalesQty,0 eStoreSalesQty,  " +
                        "0 RetailSalesVal,0 DealerSalesVal,0 B2BSalesVal,0 eStoreSalesVal  " +
                        "From t_PlanExecutiveLeadTarget a,t_Brand b,t_ProductGroup c,t_ProductGroup d    " +
                        "where a.CustomerID="+Utility.CustomerID+" and a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID  " +
                        "and TYear=" + nTGTYear + "  and TMonth=" + nTGTMonth + " and TargetAmount>0 and TargetType=" + (int)Dictionary.PlanVersionType.ExecutiveLeadTarget + "  " +
                        "group by SalesPersonID,TYear,TMonth,WeekNo,a.BrandID,BrandDesc,  " +
                        "a.MAGID,c.PDTGroupName,d.PdtGroupID,d.PDTGroupName  " +
                        "Union All  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,  " +
                        "PGID,PGName,0 RetailTGTQty,0 DealerTGTQty,0 B2BTGTQty,0 eStoreTGTQty,  " +
                        "0 RetailTGTValue,0 DealerTGTValue,0 B2BTGTValue,0 eStoreTGTValue,  " +
                        "(RetailSalesQty+B2CSalesQty+HPASalesQty) as RetailSalesQty,DealerSalesQty,B2BSalesQty,EStoreSalesQty,  " +
                        "(RetailSalesVal+B2CSalesVal+HPASalesVal) as RetailSalesVal,DealerSalesVal,B2BSalesVal,EStoreSalesVal  " +
                        "From   " +
                        "(  " +
                        "Select SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,  " +
                        "PGID,PGName,  " +
                        "sum(case CustomerType when 1 then Qty else 0 end) as RetailSalesQty,  " +
                        "sum(case CustomerType when 2 then Qty else 0 end) as B2CSalesQty,  " +
                        "sum(case CustomerType when 3 then Qty else 0 end) as B2BSalesQty,  " +
                        "sum(case CustomerType when 4 then Qty else 0 end) as HPASalesQty,  " +
                        "sum(case CustomerType when 5 then Qty else 0 end) as DealerSalesQty,  " +
                        "sum(case CustomerType when 6 then Qty else 0 end) as EStoreSalesQty,  " +
                        "sum(case CustomerType when 1 then LeadAmount else 0 end) as RetailSalesVal,  " +
                        "sum(case CustomerType when 2 then LeadAmount else 0 end) as B2CSalesVal,  " +
                        "sum(case CustomerType when 3 then LeadAmount else 0 end) as B2BSalesVal,  " +
                        "sum(case CustomerType when 4 then LeadAmount else 0 end) as HPASalesVal,  " +
                        "sum(case CustomerType when 5 then LeadAmount else 0 end) as DealerSalesVal,  " +
                        "sum(case CustomerType when 6 then LeadAmount else 0 end) as EStoreSalesVal  " +
                        "From   " +
                        "(  " +
                        "Select SalespersonID,CustomerType,Year(ExpExecuteDate) as TYear,Month(ExpExecuteDate) as TMonth,WeekNo,a.BrandID,BrandDesc as Brand,  " +
                        "a.MAGID,c.PDTGroupName as MAGName,d.PdtGroupID as PGID,d.PDTGroupName as PGName,isnull(Qty,1) as Qty,LeadAmount  " +
                        "From t_SalesLeadManagement a,t_CalendarWeek,t_Brand b,t_ProductGroup c,t_ProductGroup d    " +
                        "where a.WarehouseID="+Utility.WarehouseID+" and a.BrandID=b.BrandID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID  " +
                        "and ExpExecuteDate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'   " +
                        "and ExpExecuteDate < '" + LastDateOfThisMonth + "' and convert(datetime,(convert(varchar(12),ExpExecuteDate,106))) between fromdate and todate   " +
                        ") a group by SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName  " +
                        ") x  " +
                        ") Main group by SalesPersonID,TYear,TMonth,WeekNo,BrandID,Brand,MAGID,MAGName,PGID,PGName) A  " +
                        "Inner Join   " +
                        "(Select * From t_Employee) b  " +
                        "on a.SalesPersonID=b.EmployeeID  " +
                        ") Main where 1=1";
            }
            if (nTGTWeek != -1)
            {
                sSql = sSql + " AND WeekNo=" + nTGTWeek + "";
            }
            if (nSalesPersonID != -1)
            {
                sSql = sSql + " AND SalesPersonID=" + nSalesPersonID + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();

                    _oDailySalesReport.EmployeeID = Convert.ToInt32(reader["SalesPersonID"].ToString());
                    _oDailySalesReport.EmployeeName = reader["EmployeeName"].ToString();
                    _oDailySalesReport.TYear = Convert.ToInt32(reader["TYear"].ToString());
                    _oDailySalesReport.TMonth = Convert.ToInt32(reader["TMonth"].ToString());
                    _oDailySalesReport.TWeek = Convert.ToInt32(reader["WeekNo"].ToString());
                    _oDailySalesReport.MAGName = reader["MAGName"].ToString();
                    _oDailySalesReport.Brand = reader["Brand"].ToString();
                    _oDailySalesReport.PGName = reader["PGName"].ToString();
                    _oDailySalesReport.RTLTGRQty = Convert.ToInt32(reader["RetailTGTQty"].ToString());
                    _oDailySalesReport.RTLSalesQty = Convert.ToInt32(reader["RetailSalesQty"].ToString());
                    _oDailySalesReport.DealerTGTQty = Convert.ToInt32(reader["DealerTGTQty"].ToString());
                    _oDailySalesReport.DealerSalesQty = Convert.ToInt32(reader["DealerSalesQty"].ToString());
                    _oDailySalesReport.B2BTGTQty = Convert.ToInt32(reader["B2BTGTQty"].ToString());
                    _oDailySalesReport.B2BSalesQty = Convert.ToInt32(reader["B2BSalesQty"].ToString());
                    _oDailySalesReport.eStoreTGTQty = Convert.ToInt32(reader["eStoreTGTQty"].ToString());
                    _oDailySalesReport.eStoreSalesQty = Convert.ToInt32(reader["eStoreSalesQty"].ToString());
                    _oDailySalesReport.RetailTGTVal = Convert.ToDouble(reader["RetailTGTVal"].ToString());
                    _oDailySalesReport.RTLSalesVal = Convert.ToDouble(reader["RetailSalesVal"].ToString());
                    _oDailySalesReport.DealerTGTVal = Convert.ToDouble(reader["DealerTGTVal"].ToString());
                    _oDailySalesReport.DealerSalesVal = Convert.ToDouble(reader["DealerSalesVal"].ToString());
                    _oDailySalesReport.B2BTGTVal = Convert.ToDouble(reader["B2BTGTVal"].ToString());
                    _oDailySalesReport.B2BSalesVal = Convert.ToDouble(reader["B2BSalesVal"].ToString());
                    _oDailySalesReport.eStoreTGTVal = Convert.ToDouble(reader["eStoreTGTVal"].ToString());
                    _oDailySalesReport.eStoreSalesVal = Convert.ToDouble(reader["eStoreSalesVal"].ToString());
                    _oDailySalesReport.RTLQtyPercentage = Convert.ToDouble(reader["RTLQtyPercentage"].ToString());
                    _oDailySalesReport.DealerQtyPercentage = Convert.ToDouble(reader["DealerQtyPercentage"].ToString());
                    _oDailySalesReport.B2BQtyPercentage = Convert.ToDouble(reader["B2BQtyPercentage"].ToString());
                    _oDailySalesReport.eStoreQtyPercentage = Convert.ToDouble(reader["eStoreQtyPercentage"].ToString());
                    _oDailySalesReport.RTLValPercentage = Convert.ToDouble(reader["RTLValPercentage"].ToString());
                    _oDailySalesReport.DealerValPercentage = Convert.ToDouble(reader["DealerValPercentage"].ToString());
                    _oDailySalesReport.B2BValPercentage = Convert.ToDouble(reader["B2BValPercentage"].ToString());
                    _oDailySalesReport.eStoreValPercentage = Convert.ToDouble(reader["eStoreValPercentage"].ToString());
                    _oDailySalesReport.TotalSalesQty = Convert.ToDouble(reader["TotalSalesQty"].ToString());
                    _oDailySalesReport.TotalTGTQty = Convert.ToDouble(reader["TotalTGTQty"].ToString());
                    _oDailySalesReport.TotalQtyPercentage = Convert.ToDouble(reader["TotalQtyPercentage"].ToString());
                    _oDailySalesReport.TotalSalesVal = Convert.ToDouble(reader["TotalSalesVal"].ToString());
                    _oDailySalesReport.TotalTGTVal = Convert.ToDouble(reader["TotalTGTVal"].ToString());
                    _oDailySalesReport.TotalValPercentage = Convert.ToDouble(reader["TotalValPercentage"].ToString());

                    InnerList.Add(_oDailySalesReport);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetDashboardItem(DateTime dtFromDate, int nSalesperson, int nPGID, int nMAGID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DateTime dToDate = dtFromDate.AddDays(1);
            string sSql = "";
            {

                sSql = "Select x.*,EmployeeCode,'['+EmployeeCode+']'+' '+ EmployeeName as EmployeeName " +
                                    "From  " +
                                    "( " +
                                    "Select SalesPersonID,MAGID,MAGName,PGID,PGName, " +
                                    "sum(WeekLeadTargetQty) WeekLeadTargetQty," +
                                    "ROUND(sum(WeekLeadTargetAmt),0) WeekLeadTargetAmount, " +
                                    "sum(WeekTargetQty) WeekTargetQty, " +
                                    "ROUND(sum(WeekTargetAmt),0) WeekTargetAmount, " +
                                    "ROUND(sum(DayLeadTargetQty),0) DayLeadTargetQty, " +
                                    "ROUND(sum(DayLeadTargetAmt),0) DayLeadTargetAmount, " +
                                    "ROUND(sum(DayTgtQty),0) DayTargetQty, " +
                                    "ROUND(sum(DayTgtAmt),0) DayTargetAmount, " +
                                    "ROUND(sum(LeadQty),0) DayLeadQty, " +
                                    "ROUND(sum(LeadAmt),0) DayLeadAmount, " +
                                    "sum(SalesQty) SalesQty, " +
                                    "ROUND(sum(SalesVal),0) SalesVal  " +
                                    "From  " +
                                    "( " +
                                    "Select * From  " +
                                    "( " +
                                    "Select Main.*, " +
                                    "cast(WeekLeadTargetQty as float)/(SELECT  DATEDIFF(day, fromdate, todate+1) " +
                                    "FROM dbo.t_CalendarWeek " +
                                    "WHERE '" + dtFromDate + "' between fromdate and todate) as DayLeadTargetQty, " +

                                    "cast(WeekLeadTargetAmt as float) /(SELECT  DATEDIFF(day, fromdate, todate+1) " +
                                    "FROM dbo.t_CalendarWeek " +
                                    "WHERE '" + dtFromDate + "' between fromdate and todate) as DayLeadTargetAmt, " +

                                    "cast(WeekTargetQty as float)/(SELECT  DATEDIFF(day, fromdate, todate+1) " +
                                    "FROM dbo.t_CalendarWeek " +
                                    "WHERE '" + dtFromDate + "' between fromdate and todate) as DayTGTQTY, " +

                                    "cast(WeekTargetAmt as float) /(SELECT  DATEDIFF(day, fromdate, todate+1) " +
                                    "FROM dbo.t_CalendarWeek " +
                                    "WHERE '" + dtFromDate + "' between fromdate and todate) as DayTGTAmt, " +

                                    "0 as LeadQty,0 As LeadAmt,0 SalesQty,0 SalesVal " +
                                    "From  " +
                                    "( " +
                                    "Select SalesPersonID,MAGID,b.PdtgroupName as MAGName,PG.PdtGroupID as PGID, " +
                                    "PG.PdtgroupName PGName, " +
                                    "sum(case TargetType when 5 then TargetQty else 0 end) as WeekLeadTargetQty, " +
                                    "sum(case TargetType when 5 then TargetAmount else 0 end) as WeekLeadTargetAmt, " +
                                    "sum(case TargetType when 6 then TargetQty else 0 end) as WeekTargetQty, " +
                                    "sum(case TargetType when 6 then TargetAmount else 0 end) as WeekTargetAmt " +
                                    "From dbo.t_PlanExecutiveLeadTarget a,t_ProductGroup b,t_ProductGroup PG " +
                                    "where a.MAGID=b.PdtGroupID and b.ParentID=PG.PdtGroupID and  " +
                                    "WeekNo=( " +
                                    "SELECT  WeekNo FROM dbo.t_CalendarWeek " +
                                    "WHERE '" + dtFromDate + "' between fromdate and todate) and  " +
                                    "Tyear=" + dtFromDate.Year + " and TMonth=" + dtFromDate.Month + " " +
                                    "group by SalesPersonID,MAGID,b.PdtgroupName,PG.PdtGroupID,PG.PdtgroupName " +
                                    ") Main " +
                                    ") TGT " +
                                    "Union All " +
                    //----Lead----
                                    "Select a.SalesPersonID,d.MAGID,MAGName,PGID,PGName,0,0,0,0,0,0,0,0, " +
                                    "sum(Quantity) as DayLeadQty,sum(InvoiceAmount) as DayLeadAmount, " +
                                    "0,0  " +
                                    "From t_SalesLeadManagement a,t_SalesInvoice b,t_SalesInvoiceDetail c,v_ProductDetails d " +
                                    "where a.invoiceNo=b.invoiceNo and b.InvoiceID=c.invoiceID and  " +
                                    "c.ProductID=d.ProductID and Status=3 and b.InvoiceDate='" + dtFromDate + "' " +
                                    "group by a.SalesPersonID,d.MAGID,MAGName,PGID,PGName " +
                    //----END Lead----
                                    "Union All " +
                    //---Sales----
                                    "Select SalesPersonID,MAGID,MAGName,PGID,PGName, " +
                                    "0 as WeekLeadTargetQty,0 as WeekLeadTargetAMT, " +
                                    "0 as WeekTargetQty,0 as WeekTargetAMT, " +
                                    "0 DayLeadTGTQt,0 DayLeadTGTVal,0 DayTGTQt,0 DayTGTVal, " +
                                    "0 as LeadQty,0 As LeadAmt,SalesQty,NetSales  " +
                                    "From  " +
                                    "( " +
                                    "Select SalesPersonID,SalesType,TYear,TMonth,WeekNo,BrandID,BrandDesc,PGID,PGName,MAGID,  " +
                                    "MAGName,SalesQty,(GrossSales+OC-Main.VAT-Discount) as NetSales   " +
                                    "From  " +
                                    "(  " +
                                    "Select SalesPersonID,SalesType,TYear,TMonth,WeekNo,ProductID,   " +
                                    "isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,    " +
                                    "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,  " +
                                    "isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT    " +
                                    "From    " +
                                    "(  " +
                                    "Select SalesPersonID,SalesType,TYear,WeekNo,TMonth,ProductID,sum(quantity)as crqty,   " +
                                    "0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales,    " +
                                    "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS,   " +
                                    "0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT  from   " +
                                    "(   " +
                                    "Select SalesPersonID,SalesType,a.InvoiceID,  " +
                                    "WeekNo,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales,  " +
                                    "(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,    " +
                                    "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT    " +
                                    "from   " +
                                    "(    " +
                                    "select SalesPersonID,SalesType,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,  " +
                                    "month(invoicedate) as TMonth,  ProductID,UnitPrice,Costprice,  " +
                                    "TradePrice,VatAmount,Discount,quantity    " +
                                    "from t_salesinvoice sa, t_salesinvoicedetail sd,t_RetailConsumer sc,t_CalendarWeek    " +
                                    "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and     " +
                                    "invoicedate between '" + dtFromDate + "' and '" + dToDate + "'   " +
                                    "and invoicedate < '" + dToDate + "'    " +
                                    "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate     " +
                                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)     " +
                                    ")as a    " +
                                    "left outer join    " +
                                    "(    " +
                                    "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,  " +
                                    "isnull((OtherCharge/sum(quantity)),0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd    " +
                                    "where sa.invoiceid = sd.invoiceid and invoicedate between '" + dtFromDate + "' and '" + dToDate + "'   " +
                                    "and invoicedate < '" + dToDate + "'  and invoicetypeid in (1,2,4,5)and   " +
                                    "invoicestatus not in (3)   group by SalesPersonID,sa.InvoiceID,Discount,OtherCharge    " +
                                    ") as b   " +
                                    "on a.invoiceid = b.invoiceid   " +
                                    ") as final  Group By SalesPersonID,SalesType,TYear,TMonth,WeekNo,ProductID  " +
                                    "Union all    " +
                                    "Select SalesPersonID,SalesType,TYear,WeekNo,TMonth,ProductID,0 as crqty,   " +
                                    "sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,    " +
                                    "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,  " +
                                    "0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT    " +
                                    "from  (    " +
                                    "Select SalesPersonID,a.InvoiceID,WeekNo,TYear,TMonth,SalesType,ProductID,Quantity,  " +
                                    "(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,    " +
                                    "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT    " +
                                    "from  (    " +
                                    "select SalesPersonID,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,month(invoicedate) as TMonth,    " +
                                    "SalesType,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity    " +
                                    "from t_salesinvoice sa, t_salesinvoicedetail sd,t_Retailconsumer sc,t_CalendarWeek    " +
                                    "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and     " +
                                    "invoicedate between '" + dtFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "'    " +
                                    "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate     " +
                                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   )as a    " +
                                    "left outer join    " +
                                    "(    " +
                                    "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC    " +
                                    "from t_salesinvoice sa, t_salesinvoicedetail sd    " +
                                    "where sa.invoiceid = sd.invoiceid and invoicedate   " +
                                    "between '" + dtFromDate + "' and '" + dToDate + "' and   " +
                                    "invoicedate < '" + dToDate + "'  and invoicetypeid in (6,7,9,10,12) and   " +
                                    "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge    " +
                                    ") as b   " +
                                    "on a.invoiceid = b.invoiceid    " +
                                    ") as final    " +
                                    "Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID    " +
                                    ")as FinalQuery    " +
                                    "Group by  SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID    " +
                                    ") Main     " +
                                    "inner join    " +
                                    "(    " +
                                    "Select * from v_productdetails  ) as p on Main.productid = p.productid  " +
                                    ") as Sales " +
                    //----End Sales----

                                    ") Main group by SalesPersonID,MAGID,MAGName,PGID,PGName " +
                                    ") x,t_employee y where x.SalesPersonID=y.EmployeeID";


            }
            if (nSalesperson != -1)
            {
                sSql = sSql + " AND SalespersonID=" + nSalesperson + "";
            }
            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();
                    _oDailySalesReport.EmployeeID = Convert.ToInt32(reader["SalesPersonID"].ToString());
                    _oDailySalesReport.EmployeeName = reader["EmployeeName"].ToString();
                    _oDailySalesReport.MAGName = reader["MAGName"].ToString();
                    _oDailySalesReport.PGName = reader["PGName"].ToString();
                    _oDailySalesReport.WeekLeadTargetQty = Convert.ToDouble(reader["WeekLeadTargetQty"].ToString());
                    _oDailySalesReport.WeekLeadTargetAmount = Convert.ToDouble(reader["WeekLeadTargetAmount"].ToString());
                    _oDailySalesReport.WeekTargetQty = Convert.ToDouble(reader["WeekTargetQty"].ToString());
                    _oDailySalesReport.WeekTargetAmount = Convert.ToDouble(reader["WeekTargetAmount"].ToString());
                    _oDailySalesReport.DayLeadTargetQty = Convert.ToDouble(reader["DayLeadTargetQty"].ToString());
                    _oDailySalesReport.DayLeadTargetAmount = Convert.ToDouble(reader["DayLeadTargetAmount"].ToString());
                    _oDailySalesReport.DayTargetQty = Convert.ToDouble(reader["DayTargetQty"].ToString());
                    _oDailySalesReport.DayTargetAmount = Convert.ToDouble(reader["DayTargetAmount"].ToString());
                    _oDailySalesReport.DayLeadQty = Convert.ToDouble(reader["DayLeadQty"].ToString());
                    _oDailySalesReport.DayLeadAmount = Convert.ToDouble(reader["DayLeadAmount"].ToString());
                    _oDailySalesReport.TotalSalesQty = Convert.ToDouble(reader["SalesQty"].ToString());
                    _oDailySalesReport.TotalSalesVal = Convert.ToDouble(reader["SalesVal"].ToString());

                    InnerList.Add(_oDailySalesReport);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void Report(DateTime FirstDateOfThisMonth, DateTime LastDateOfThisMonth, int nTGTYear, int nTGTMonth, int nTGTWeek, int nTGTType, int nSalesPersonID,int nMAGID, int nPGID, int nBrandID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //DateTime dToDate = dtFromDate.AddDays(1);
            string sSql = "";
            {

                sSql = "Select MAGName, " +
                    "sum(RetailTGTQty) RetailTGTQty,sum(DealerTGTQty) DealerTGTQty,sum(B2BTGTQty) B2BTGTQty,sum(EStoreTGTQty) EStoreTGTQty, " +
                    "sum(RetailTGTQty)+sum(DealerTGTQty)+sum(B2BTGTQty)+sum(EStoreTGTQty) as TotalTGTQty, " +
                    "sum(RetailTGTAmt) RetailTGTAmt,sum(DealerTGTAmt) DealerTGTAmt,sum(B2BTGTAmt) B2BTGTAmt,sum(EStoreTGTAmt) EStoreTGTAmt, " +
                    "sum(RetailTGTAmt)+sum(DealerTGTAmt)+sum(B2BTGTAmt)+sum(EStoreTGTAmt) as TotalTGTAmt, " +
                    "sum(RetailSalesQty) RetailSalesQty,sum(DealerSalesQty) DealerSalesQty,sum(B2BSalesQty) B2BSalesQty,sum(EStoreSalesQty) EStoreSalesQty, " +
                    "sum(RetailSalesQty)+sum(DealerSalesQty)+sum(B2BSalesQty)+sum(EStoreSalesQty) as TotalSalesQty, " +
                    "sum(RetailSalesAmt) RetailSalesAmt,sum(DealerSalesAmt) DealerSalesAmt,sum(B2BSalesAmt) B2BSalesAmt,sum(EStoreSalesAmt) EStoreSalesAmt, " +
                    "sum(RetailSalesAmt)+sum(DealerSalesAmt)+sum(B2BSalesAmt)+sum(EStoreSalesAmt) as TotalSalesAmt, " +
                    "ROUND(isnull(nullif(sum(RetailSalesQty),0)/CAST(nullif(sum(RetailTGTQty),0) as float)*100,0),2) as RTLQtyPercentage, " +
                    "ROUND(isnull(nullif(sum(DealerSalesQty),0)/CAST(nullif(sum(DealerTGTQty),0) as float)*100,0),2) as DealerQtyPercentage, " +
                    "ROUND(isnull(nullif(sum(B2BSalesQty),0)/CAST(nullif(sum(B2BTGTQty),0) as float)*100,0),2) as B2BQtyPercentage, " +
                    "ROUND(isnull(nullif(sum(EStoreSalesQty),0)/CAST(nullif(sum(EStoreTGTQty),0) as float)*100,0),2) as eStoreQtyPercentage, " +
                    "ROUND(isnull(nullif(sum(RetailSalesAmt),0)/CAST(nullif(sum(RetailTGTAmt),0) as float)*100,0),2) as RTLValPercentage, " +
                    "ROUND(isnull(nullif(sum(DealerSalesAmt),0)/CAST(nullif(sum(DealerTGTAmt),0) as float)*100,0),2) as DealerValPercentage, " +
                    "ROUND(isnull(nullif(sum(B2BSalesAmt),0)/CAST(nullif(sum(B2BTGTAmt),0) as float)*100,0),2) as B2BValPercentage, " +
                    "ROUND(isnull(nullif(sum(EStoreSalesAmt),0)/CAST(nullif(sum(EStoreTGTAmt),0) as float)*100,0),2) as eStoreValPercentage " +
                    "From  " +
                    "( " +
                    "Select WeekNo,TMonth,TYear,SalesPersonID,EmployeeCode,EmployeeName,a.MAGID,c.PdtGroupName as MAGName, " +
                    "d.PdtGroupID as PGID,d.PdtGroupName as PGName,a.BrandID,BrandDesc as BrandName, " +
                    "sum(case Channel when 4 then TargetQty else 0 end) as RetailTGTQty,   " +
                    "sum(case Channel when 3 then TargetQty else 0 end) as DealerTGTQty,  " +
                    "sum(case Channel when 13 then TargetQty else 0 end) as B2BTGTQty,  " +
                    "sum(case Channel when 16 then TargetQty else 0 end) as EStoreTGTQty, " +
                    "sum(case Channel when 4 then TargetAmount else 0 end) as RetailTGTAmt,   " +
                    "sum(case Channel when 3 then TargetAmount else 0 end) as DealerTGTAmt,  " +
                    "sum(case Channel when 13 then TargetAmount else 0 end) as B2BTGTAmt,  " +
                    "sum(case Channel when 16 then TargetAmount else 0 end) as EStoreTGTAmt, " +
                    "0 RetailSalesQty,0 DealerSalesQty,0 B2BSalesQty,0 EStoreSalesQty, " +
                    "0 RetailSalesAmt,0 DealerSalesAmt,0 B2BSalesAmt,0 EStoreSalesAmt " +
                    "from t_PlanexecutiveLeadtarget a,t_Employee b,t_ProductGroup c,t_ProductGroup d,t_Brand e " +
                    "where a.SalesPersonID=b.EmployeeID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID " +
                    "and e.BrandID=a.BrandID and TargetType=" + nTGTType + " and TMonth=" + nTGTMonth + " and TYear=" + nTGTYear + " " +
                    "group by WeekNo,TMonth,TYear,SalesPersonID,EmployeeCode,EmployeeName,a.MAGID,c.PdtGroupName, " +
                    "d.PdtGroupID,d.PdtGroupName,a.BrandID,BrandDesc " +
                    "Union All " +
                    "Select WeekNo,TMonth,TYear,SalesPersonID,EmployeeCode,EmployeeName, " +
                    "MAGID,MAGName,PGID,PGName,BrandID,BrandName, " +
                    "0 RetailTGTQty,0 DealerTGTQty,0 B2BTGTQty,0 EStoreTGTQty, " +
                    "0 RetailTGTAmt,0 DealerTGTAmt,0 B2BTGTAmt,0 EStoreTGTAmt, " +
                    "(RetailSalesQty+B2CSalesQty+HPASalesQty) as RetailSalesQty,DealerSalesQty,B2BSalesQty,EStoreSalesQty, " +
                    "(RetailSalesAmt+B2CSalesAmt+HPASalesAmt) as RetailSalesAmt,DealerSalesAmt,B2BSalesAmt,EStoreSalesAmt " +
                    "From  " +
                    "( " +
                    "Select WeekNo,TMonth,TYear,SalesPersonID,EmployeeCode,EmployeeName, " +
                    "MAGID,MAGName,PGID,PGName,BrandID,BrandName, " +
                    "sum(case SalesType when 1 then SalesQty else 0 end) as RetailSalesQty,   " +
                    "sum(case SalesType when 2 then SalesQty else 0 end) as B2CSalesQty,  " +
                    "sum(case SalesType when 4 then SalesQty else 0 end) as HPASalesQty,  " +
                    "sum(case SalesType when 5 then SalesQty else 0 end) as DealerSalesQty,  " +
                    "sum(case SalesType when 3 then SalesQty else 0 end) as B2BSalesQty,  " +
                    "sum(case SalesType when 6 then SalesQty else 0 end) as EStoreSalesQty, " +
                    "sum(case SalesType when 1 then NetSales else 0 end) as RetailSalesAmt,  " +
                    "sum(case SalesType when 2 then NetSales else 0 end) as B2CSalesAmt,  " +
                    "sum(case SalesType when 4 then NetSales else 0 end) as HPASalesAmt,  " +
                    "sum(case SalesType when 5 then NetSales else 0 end) as DealerSalesAmt,  " +
                    "sum(case SalesType when 3 then NetSales else 0 end) as B2BSalesAmt,  " +
                    "sum(case SalesType when 6 then NetSales else 0 end) as EStoreSalesAmt  " +
                    "From   " +
                    "(  " +
                    "Select SalesPersonID,EmployeeCode,EmployeeName,SalesType, " +
                    "TYear,TMonth,WeekNo,BrandID,BrandDesc as BrandName,PGID,PGName,MAGID,   " +
                    "MAGName,SalesQty,(GrossSales+OC-Main.VAT-Discount) as NetSales    " +
                    "From   " +
                    "(   " +
                    "Select SalesPersonID,SalesType,TYear,TMonth,WeekNo,ProductID,    " +
                    "isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,     " +
                    "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,   " +
                    "isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT     " +
                    "From     " +
                    "(   " +
                    "Select SalesPersonID,SalesType,TYear,WeekNo,TMonth,ProductID,sum(quantity)as crqty,    " +
                    "0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales,     " +
                    "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS,    " +
                    "0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT  from    " +
                    "(    " +
                    "Select SalesPersonID,SalesType,a.InvoiceID,   " +
                    "WeekNo,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales,   " +
                    "(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,     " +
                    "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT     " +
                    "from    " +
                    "(     " +
                    "select SalesPersonID,SalesType,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,   " +
                    "month(invoicedate) as TMonth,  ProductID,UnitPrice,Costprice,   " +
                    "TradePrice,VatAmount,Discount,quantity     " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd,t_RetailConsumer sc,t_CalendarWeek     " +
                    "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and      " +
                    "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'    " +
                    "and invoicedate < '" + LastDateOfThisMonth + "'     " +
                    "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate      " +
                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)      " +
                    ")as a     " +
                    "left outer join     " +
                    "(     " +
                    "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,   " +
                    "isnull((OtherCharge/sum(quantity)),0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd     " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'    " +
                    "and invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (1,2,4,5)and    " +
                    "invoicestatus not in (3)   group by SalesPersonID,sa.InvoiceID,Discount,OtherCharge     " +
                    ") as b    " +
                    "on a.invoiceid = b.invoiceid    " +
                    ") as final  Group By SalesPersonID,SalesType,TYear,TMonth,WeekNo,ProductID   " +
                    "Union all     " +
                    "Select SalesPersonID,SalesType,TYear,WeekNo,TMonth,ProductID,0 as crqty,    " +
                    "sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,     " +
                    "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,   " +
                    "0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT     " +
                    "from  (     " +
                    "Select SalesPersonID,a.InvoiceID,WeekNo,TYear,TMonth,SalesType,ProductID,Quantity,   " +
                    "(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,     " +
                    "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT     " +
                    "from  (     " +
                    "select SalesPersonID,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,month(invoicedate) as TMonth,     " +
                    "SalesType,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity     " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd,t_Retailconsumer sc,t_CalendarWeek     " +
                    "where sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and      " +
                    "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate < '" + LastDateOfThisMonth + "'     " +
                    "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate      " +
                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   )as a     " +
                    "left outer join     " +
                    "(     " +
                    "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC     " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd     " +
                    "where sa.invoiceid = sd.invoiceid and invoicedate    " +
                    "between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and    " +
                    "invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (6,7,9,10,12) and    " +
                    "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge     " +
                    ") as b    " +
                    "on a.invoiceid = b.invoiceid     " +
                    ") as final     " +
                    "Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID     " +
                    ")as FinalQuery     " +
                    "Group by  SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID     " +
                    ") Main      " +
                    "inner join     " +
                    "(     " +
                    "Select * from v_productdetails   " +
                    ") as p " +
                    "on Main.productid = p.productid   " +
                    "inner join     " +
                    "(     " +
                    "Select * from t_Employee   " +
                    ") as e " +
                    "on Main.SalesPersonID = e.EmployeeID  " +
                    ") as X  " +
                    "group by WeekNo,TMonth,TYear,SalesPersonID,EmployeeCode,EmployeeName, " +
                    "MAGID,MAGName,PGID,PGName,BrandID,BrandName) Sales " +
                    ") Main where 1=1";


            }
            if (nSalesPersonID != -1)
            {
                sSql = sSql + " AND SalesPersonID=" + nSalesPersonID + "";
            }
            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID=" + nBrandID + "";
            }
            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            if (nTGTYear != -1)
            {
                sSql = sSql + " AND TYear=" + nTGTYear + "";
            }
            if (nTGTMonth != -1)
            {
                sSql = sSql + " AND TMonth=" + nTGTMonth + "";
            }
            if (nTGTWeek != -1)
            {
                sSql = sSql + " AND WeekNo=" + nTGTWeek + "";
            }

            sSql = sSql + "group by MAGName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();
                    _oDailySalesReport.MAGName = reader["MAGName"].ToString();


                    _oDailySalesReport.RTLTGRQty = Convert.ToInt32(reader["RetailTGTQty"].ToString());
                    _oDailySalesReport.DealerTGTQty = Convert.ToInt32(reader["DealerTGTQty"].ToString());
                    _oDailySalesReport.B2BTGTQty = Convert.ToInt32(reader["B2BTGTQty"].ToString());
                    _oDailySalesReport.eStoreTGTQty = Convert.ToInt32(reader["EStoreTGTQty"].ToString());
                    _oDailySalesReport.TotalTGTQty = Convert.ToInt32(reader["TotalTGTQty"].ToString());

                    _oDailySalesReport.RetailTGTVal = Convert.ToDouble(reader["RetailTGTAmt"].ToString());
                    _oDailySalesReport.DealerTGTVal = Convert.ToDouble(reader["DealerTGTAmt"].ToString());
                    _oDailySalesReport.B2BTGTVal = Convert.ToDouble(reader["B2BTGTAmt"].ToString());
                    _oDailySalesReport.eStoreTGTVal = Convert.ToDouble(reader["EStoreTGTAmt"].ToString());
                    _oDailySalesReport.TotalTGTVal = Convert.ToDouble(reader["TotalTGTAmt"].ToString());


                    _oDailySalesReport.RTLSalesQty = Convert.ToInt32(reader["RetailSalesQty"].ToString());
                    _oDailySalesReport.DealerSalesQty = Convert.ToInt32(reader["DealerSalesQty"].ToString());
                    _oDailySalesReport.B2BSalesQty = Convert.ToInt32(reader["B2BSalesQty"].ToString());
                    _oDailySalesReport.eStoreSalesQty = Convert.ToInt32(reader["EStoreSalesQty"].ToString());
                    _oDailySalesReport.TotalSalesQty = Convert.ToInt32(reader["TotalSalesQty"].ToString());


                    _oDailySalesReport.RTLSalesVal = Convert.ToDouble(reader["RetailSalesAmt"].ToString());
                    _oDailySalesReport.DealerSalesVal = Convert.ToDouble(reader["DealerSalesAmt"].ToString());
                    _oDailySalesReport.B2BSalesVal = Convert.ToDouble(reader["B2BSalesAmt"].ToString());
                    _oDailySalesReport.eStoreSalesVal = Convert.ToDouble(reader["EStoreSalesAmt"].ToString());
                    _oDailySalesReport.TotalSalesVal = Convert.ToDouble(reader["TotalSalesAmt"].ToString());



                    _oDailySalesReport.RTLQtyPercentage = Convert.ToDouble(reader["RTLQtyPercentage"].ToString());
                    _oDailySalesReport.DealerQtyPercentage = Convert.ToDouble(reader["DealerQtyPercentage"].ToString());
                    _oDailySalesReport.B2BQtyPercentage = Convert.ToDouble(reader["B2BQtyPercentage"].ToString());
                    _oDailySalesReport.eStoreQtyPercentage = Convert.ToDouble(reader["eStoreQtyPercentage"].ToString());

                    _oDailySalesReport.RTLValPercentage = Convert.ToDouble(reader["RTLValPercentage"].ToString());
                    _oDailySalesReport.DealerValPercentage = Convert.ToDouble(reader["DealerValPercentage"].ToString());
                    _oDailySalesReport.B2BValPercentage = Convert.ToDouble(reader["B2BValPercentage"].ToString());
                    _oDailySalesReport.eStoreValPercentage = Convert.ToDouble(reader["eStoreValPercentage"].ToString());

                    InnerList.Add(_oDailySalesReport);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ReportRT(DateTime FirstDateOfThisMonth, DateTime LastDateOfThisMonth, int nTGTYear, int nTGTMonth, int nTGTWeek, int nTGTType, int nSalesPersonID, int nMAGID, int nPGID, int nBrandID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //DateTime dToDate = dtFromDate.AddDays(1);
            string sSql = "";
            {

                sSql = "Select MAGName, " +
                    "sum(RetailTGTQty) RetailTGTQty,sum(DealerTGTQty) DealerTGTQty,sum(B2BTGTQty) B2BTGTQty,sum(EStoreTGTQty) EStoreTGTQty, " +
                    "sum(RetailTGTQty)+sum(DealerTGTQty)+sum(B2BTGTQty)+sum(EStoreTGTQty) as TotalTGTQty, " +
                    "sum(RetailTGTAmt) RetailTGTAmt,sum(DealerTGTAmt) DealerTGTAmt,sum(B2BTGTAmt) B2BTGTAmt,sum(EStoreTGTAmt) EStoreTGTAmt, " +
                    "sum(RetailTGTAmt)+sum(DealerTGTAmt)+sum(B2BTGTAmt)+sum(EStoreTGTAmt) as TotalTGTAmt, " +
                    "sum(RetailSalesQty) RetailSalesQty,sum(DealerSalesQty) DealerSalesQty,sum(B2BSalesQty) B2BSalesQty,sum(EStoreSalesQty) EStoreSalesQty, " +
                    "sum(RetailSalesQty)+sum(DealerSalesQty)+sum(B2BSalesQty)+sum(EStoreSalesQty) as TotalSalesQty, " +
                    "sum(RetailSalesAmt) RetailSalesAmt,sum(DealerSalesAmt) DealerSalesAmt,sum(B2BSalesAmt) B2BSalesAmt,sum(EStoreSalesAmt) EStoreSalesAmt, " +
                    "sum(RetailSalesAmt)+sum(DealerSalesAmt)+sum(B2BSalesAmt)+sum(EStoreSalesAmt) as TotalSalesAmt, " +
                    "ROUND(isnull(nullif(sum(RetailSalesQty),0)/CAST(nullif(sum(RetailTGTQty),0) as float)*100,0),2) as RTLQtyPercentage, " +
                    "ROUND(isnull(nullif(sum(DealerSalesQty),0)/CAST(nullif(sum(DealerTGTQty),0) as float)*100,0),2) as DealerQtyPercentage, " +
                    "ROUND(isnull(nullif(sum(B2BSalesQty),0)/CAST(nullif(sum(B2BTGTQty),0) as float)*100,0),2) as B2BQtyPercentage, " +
                    "ROUND(isnull(nullif(sum(EStoreSalesQty),0)/CAST(nullif(sum(EStoreTGTQty),0) as float)*100,0),2) as eStoreQtyPercentage, " +
                    "ROUND(isnull(nullif(sum(RetailSalesAmt),0)/CAST(nullif(sum(RetailTGTAmt),0) as float)*100,0),2) as RTLValPercentage, " +
                    "ROUND(isnull(nullif(sum(DealerSalesAmt),0)/CAST(nullif(sum(DealerTGTAmt),0) as float)*100,0),2) as DealerValPercentage, " +
                    "ROUND(isnull(nullif(sum(B2BSalesAmt),0)/CAST(nullif(sum(B2BTGTAmt),0) as float)*100,0),2) as B2BValPercentage, " +
                    "ROUND(isnull(nullif(sum(EStoreSalesAmt),0)/CAST(nullif(sum(EStoreTGTAmt),0) as float)*100,0),2) as eStoreValPercentage " +
                    "From  " +
                    "( " +
                    "Select WeekNo,TMonth,TYear,SalesPersonID,EmployeeCode,EmployeeName,a.MAGID,c.PdtGroupName as MAGName, " +
                    "d.PdtGroupID as PGID,d.PdtGroupName as PGName,a.BrandID,BrandDesc as BrandName, " +
                    "sum(case Channel when 4 then TargetQty else 0 end) as RetailTGTQty,   " +
                    "sum(case Channel when 3 then TargetQty else 0 end) as DealerTGTQty,  " +
                    "sum(case Channel when 13 then TargetQty else 0 end) as B2BTGTQty,  " +
                    "sum(case Channel when 16 then TargetQty else 0 end) as EStoreTGTQty, " +
                    "sum(case Channel when 4 then TargetAmount else 0 end) as RetailTGTAmt,   " +
                    "sum(case Channel when 3 then TargetAmount else 0 end) as DealerTGTAmt,  " +
                    "sum(case Channel when 13 then TargetAmount else 0 end) as B2BTGTAmt,  " +
                    "sum(case Channel when 16 then TargetAmount else 0 end) as EStoreTGTAmt, " +
                    "0 RetailSalesQty,0 DealerSalesQty,0 B2BSalesQty,0 EStoreSalesQty, " +
                    "0 RetailSalesAmt,0 DealerSalesAmt,0 B2BSalesAmt,0 EStoreSalesAmt " +
                    "from t_PlanexecutiveLeadtarget a,t_Employee b,t_ProductGroup c,t_ProductGroup d,t_Brand e " +
                    "where a.CustomerID="+Utility.CustomerID+" and a.SalesPersonID=b.EmployeeID and a.MAGID=c.PdtGroupID and c.ParentID=d.PdtGroupID " +
                    "and e.BrandID=a.BrandID and TargetType=" + nTGTType + " and TMonth=" + nTGTMonth + " and TYear=" + nTGTYear + " " +
                    "group by WeekNo,TMonth,TYear,SalesPersonID,EmployeeCode,EmployeeName,a.MAGID,c.PdtGroupName, " +
                    "d.PdtGroupID,d.PdtGroupName,a.BrandID,BrandDesc " +
                    "Union All " +
                    "Select WeekNo,TMonth,TYear,SalesPersonID,EmployeeCode,EmployeeName, " +
                    "MAGID,MAGName,PGID,PGName,BrandID,BrandName, " +
                    "0 RetailTGTQty,0 DealerTGTQty,0 B2BTGTQty,0 EStoreTGTQty, " +
                    "0 RetailTGTAmt,0 DealerTGTAmt,0 B2BTGTAmt,0 EStoreTGTAmt, " +
                    "(RetailSalesQty+B2CSalesQty+HPASalesQty) as RetailSalesQty,DealerSalesQty,B2BSalesQty,EStoreSalesQty, " +
                    "(RetailSalesAmt+B2CSalesAmt+HPASalesAmt) as RetailSalesAmt,DealerSalesAmt,B2BSalesAmt,EStoreSalesAmt " +
                    "From  " +
                    "( " +
                    "Select WeekNo,TMonth,TYear,SalesPersonID,EmployeeCode,EmployeeName, " +
                    "MAGID,MAGName,PGID,PGName,BrandID,BrandName, " +
                    "sum(case SalesType when 1 then SalesQty else 0 end) as RetailSalesQty,   " +
                    "sum(case SalesType when 2 then SalesQty else 0 end) as B2CSalesQty,  " +
                    "sum(case SalesType when 4 then SalesQty else 0 end) as HPASalesQty,  " +
                    "sum(case SalesType when 5 then SalesQty else 0 end) as DealerSalesQty,  " +
                    "sum(case SalesType when 3 then SalesQty else 0 end) as B2BSalesQty,  " +
                    "sum(case SalesType when 6 then SalesQty else 0 end) as EStoreSalesQty, " +
                    "sum(case SalesType when 1 then NetSales else 0 end) as RetailSalesAmt,  " +
                    "sum(case SalesType when 2 then NetSales else 0 end) as B2CSalesAmt,  " +
                    "sum(case SalesType when 4 then NetSales else 0 end) as HPASalesAmt,  " +
                    "sum(case SalesType when 5 then NetSales else 0 end) as DealerSalesAmt,  " +
                    "sum(case SalesType when 3 then NetSales else 0 end) as B2BSalesAmt,  " +
                    "sum(case SalesType when 6 then NetSales else 0 end) as EStoreSalesAmt  " +
                    "From   " +
                    "(  " +
                    "Select SalesPersonID,EmployeeCode,EmployeeName,SalesType, " +
                    "TYear,TMonth,WeekNo,BrandID,BrandDesc as BrandName,PGID,PGName,MAGID,   " +
                    "MAGName,SalesQty,(GrossSales+OC-Main.VAT-Discount) as NetSales    " +
                    "From   " +
                    "(   " +
                    "Select SalesPersonID,SalesType,TYear,TMonth,WeekNo,ProductID,    " +
                    "isnull((sum(crqty)- sum(drqty)),0) as SalesQty,isnull((sum(crGrossSales)- sum(drGrossSales)),0) as GrossSales,     " +
                    "isnull((sum(crDiscount)- sum(drDiscount)),0) as Discount,isnull((sum(crOC)- sum(drOC)),0) as OC,   " +
                    "isnull((sum(crCOGS)- sum(drCOGS)),0) as COGS,isnull((sum(crVAT)- sum(drVAT)),0) as VAT     " +
                    "From     " +
                    "(   " +
                    "Select SalesPersonID,SalesType,TYear,WeekNo,TMonth,ProductID,sum(quantity)as crqty,    " +
                    "0 as drqty, sum(GrossSales) as crGrossSales, 0 as drGrossSales,     " +
                    "sum(Discount) as crDiscount, 0 as drDiscount,sum(OC) as crOC, 0 as drOC,sum(COGS) as crCOGS,    " +
                    "0 as drCOGS,sum(VAT) as crVAT, 0 as drVAT  from    " +
                    "(    " +
                    "Select SalesPersonID,SalesType,a.InvoiceID,   " +
                    "WeekNo,TYear,TMonth,ProductID,Quantity,(Quantity*unitprice)as GrossSales,   " +
                    "(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,     " +
                    "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT     " +
                    "from    " +
                    "(     " +
                    "select SalesPersonID,SalesType,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,   " +
                    "month(invoicedate) as TMonth,  ProductID,UnitPrice,Costprice,   " +
                    "TradePrice,VatAmount,Discount,quantity     " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd,t_RetailConsumer sc,t_CalendarWeek     " +
                    "where sa.WarehouseID=sc.WarehouseID and sa.WarehouseID="+Utility.WarehouseID+" and sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and      " +
                    "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'    " +
                    "and invoicedate < '" + LastDateOfThisMonth + "'     " +
                    "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate      " +
                    "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3)      " +
                    ")as a     " +
                    "left outer join     " +
                    "(     " +
                    "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,   " +
                    "isnull((OtherCharge/sum(quantity)),0) as AvgOC  from t_salesinvoice sa, t_salesinvoicedetail sd     " +
                    "where sa.invoiceid = sd.invoiceid and sa.WarehouseID=" + Utility.WarehouseID + " and invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "'    " +
                    "and invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (1,2,4,5)and    " +
                    "invoicestatus not in (3)   group by SalesPersonID,sa.InvoiceID,Discount,OtherCharge     " +
                    ") as b    " +
                    "on a.invoiceid = b.invoiceid    " +
                    ") as final  Group By SalesPersonID,SalesType,TYear,TMonth,WeekNo,ProductID   " +
                    "Union all     " +
                    "Select SalesPersonID,SalesType,TYear,WeekNo,TMonth,ProductID,0 as crqty,    " +
                    "sum(quantity)as drqty, 0 as crGrossSales,sum(GrossSales) as drGrossSales,     " +
                    "0 as crDiscount,sum(Discount) as drDiscount,0 as crOC,sum(OC) as drOC,   " +
                    "0 as crCOGS,sum(COGS) as drCOGS,0 as crVAT,sum(VAT) as drVAT     " +
                    "from  (     " +
                    "Select SalesPersonID,a.InvoiceID,WeekNo,TYear,TMonth,SalesType,ProductID,Quantity,   " +
                    "(Quantity*unitprice)as GrossSales,(AvgDisc*Quantity) as Discount,(AvgOC*Quantity) as OC,     " +
                    "(Quantity*Costprice)as COGS,(Quantity*Tradeprice*vatamount)as VAT     " +
                    "from  (     " +
                    "select SalesPersonID,sa.InvoiceID,WeekNo,year(invoicedate) as TYear,month(invoicedate) as TMonth,     " +
                    "SalesType,ProductID,UnitPrice,Costprice,TradePrice,VatAmount,Discount,quantity     " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd,t_Retailconsumer sc,t_CalendarWeek     " +
                    "where sa.WarehouseID=sc.WarehouseID and sa.WarehouseID=" + Utility.WarehouseID + " and  sa.invoiceid = sd.invoiceid and sa.SundryCustomerID=sc.ConsumerID and      " +
                    "invoicedate between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and invoicedate < '" + LastDateOfThisMonth + "'     " +
                    "and convert(datetime,(convert(varchar(12),InvoiceDate,106))) between fromdate and todate      " +
                    "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3)   )as a     " +
                    "left outer join     " +
                    "(     " +
                    "select sa.InvoiceID,isnull((Discount/sum(quantity)),0) as AvgDisc,isnull((OtherCharge/sum(quantity)),0) as AvgOC     " +
                    "from t_salesinvoice sa, t_salesinvoicedetail sd     " +
                    "where sa.WarehouseID=" + Utility.WarehouseID + " and  sa.invoiceid = sd.invoiceid and invoicedate    " +
                    "between '" + FirstDateOfThisMonth + "' and '" + LastDateOfThisMonth + "' and    " +
                    "invoicedate < '" + LastDateOfThisMonth + "'  and invoicetypeid in (6,7,9,10,12) and    " +
                    "invoicestatus not in (3)   group by sa.InvoiceID,Discount,OtherCharge     " +
                    ") as b    " +
                    "on a.invoiceid = b.invoiceid     " +
                    ") as final     " +
                    "Group By SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID     " +
                    ")as FinalQuery     " +
                    "Group by  SalesPersonID,SalesType,WeekNo,TYear,TMonth,ProductID     " +
                    ") Main      " +
                    "inner join     " +
                    "(     " +
                    "Select * from v_productdetails   " +
                    ") as p " +
                    "on Main.productid = p.productid   " +
                    "inner join     " +
                    "(     " +
                    "Select * from t_Employee   " +
                    ") as e " +
                    "on Main.SalesPersonID = e.EmployeeID  " +
                    ") as X  " +
                    "group by WeekNo,TMonth,TYear,SalesPersonID,EmployeeCode,EmployeeName, " +
                    "MAGID,MAGName,PGID,PGName,BrandID,BrandName) Sales " +
                    ") Main where 1=1";


            }
            if (nSalesPersonID != -1)
            {
                sSql = sSql + " AND SalesPersonID=" + nSalesPersonID + "";
            }
            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID=" + nBrandID + "";
            }
            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            if (nTGTYear != -1)
            {
                sSql = sSql + " AND TYear=" + nTGTYear + "";
            }
            if (nTGTMonth != -1)
            {
                sSql = sSql + " AND TMonth=" + nTGTMonth + "";
            }
            if (nTGTWeek != -1)
            {
                sSql = sSql + " AND WeekNo=" + nTGTWeek + "";
            }

            sSql = sSql + "group by MAGName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice _oDailySalesReport = new RetailSalesInvoice();
                    _oDailySalesReport.MAGName = reader["MAGName"].ToString();


                    _oDailySalesReport.RTLTGRQty = Convert.ToInt32(reader["RetailTGTQty"].ToString());
                    _oDailySalesReport.DealerTGTQty = Convert.ToInt32(reader["DealerTGTQty"].ToString());
                    _oDailySalesReport.B2BTGTQty = Convert.ToInt32(reader["B2BTGTQty"].ToString());
                    _oDailySalesReport.eStoreTGTQty = Convert.ToInt32(reader["EStoreTGTQty"].ToString());
                    _oDailySalesReport.TotalTGTQty = Convert.ToInt32(reader["TotalTGTQty"].ToString());

                    _oDailySalesReport.RetailTGTVal = Convert.ToDouble(reader["RetailTGTAmt"].ToString());
                    _oDailySalesReport.DealerTGTVal = Convert.ToDouble(reader["DealerTGTAmt"].ToString());
                    _oDailySalesReport.B2BTGTVal = Convert.ToDouble(reader["B2BTGTAmt"].ToString());
                    _oDailySalesReport.eStoreTGTVal = Convert.ToDouble(reader["EStoreTGTAmt"].ToString());
                    _oDailySalesReport.TotalTGTVal = Convert.ToDouble(reader["TotalTGTAmt"].ToString());


                    _oDailySalesReport.RTLSalesQty = Convert.ToInt32(reader["RetailSalesQty"].ToString());
                    _oDailySalesReport.DealerSalesQty = Convert.ToInt32(reader["DealerSalesQty"].ToString());
                    _oDailySalesReport.B2BSalesQty = Convert.ToInt32(reader["B2BSalesQty"].ToString());
                    _oDailySalesReport.eStoreSalesQty = Convert.ToInt32(reader["EStoreSalesQty"].ToString());
                    _oDailySalesReport.TotalSalesQty = Convert.ToInt32(reader["TotalSalesQty"].ToString());


                    _oDailySalesReport.RTLSalesVal = Convert.ToDouble(reader["RetailSalesAmt"].ToString());
                    _oDailySalesReport.DealerSalesVal = Convert.ToDouble(reader["DealerSalesAmt"].ToString());
                    _oDailySalesReport.B2BSalesVal = Convert.ToDouble(reader["B2BSalesAmt"].ToString());
                    _oDailySalesReport.eStoreSalesVal = Convert.ToDouble(reader["EStoreSalesAmt"].ToString());
                    _oDailySalesReport.TotalSalesVal = Convert.ToDouble(reader["TotalSalesAmt"].ToString());



                    _oDailySalesReport.RTLQtyPercentage = Convert.ToDouble(reader["RTLQtyPercentage"].ToString());
                    _oDailySalesReport.DealerQtyPercentage = Convert.ToDouble(reader["DealerQtyPercentage"].ToString());
                    _oDailySalesReport.B2BQtyPercentage = Convert.ToDouble(reader["B2BQtyPercentage"].ToString());
                    _oDailySalesReport.eStoreQtyPercentage = Convert.ToDouble(reader["eStoreQtyPercentage"].ToString());

                    _oDailySalesReport.RTLValPercentage = Convert.ToDouble(reader["RTLValPercentage"].ToString());
                    _oDailySalesReport.DealerValPercentage = Convert.ToDouble(reader["DealerValPercentage"].ToString());
                    _oDailySalesReport.B2BValPercentage = Convert.ToDouble(reader["B2BValPercentage"].ToString());
                    _oDailySalesReport.eStoreValPercentage = Convert.ToDouble(reader["eStoreValPercentage"].ToString());

                    InnerList.Add(_oDailySalesReport);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDailyProjection(DateTime dtDate,int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nType == (int)Dictionary.DeailyProjectionType.Sales_Value)
            {
                sSql = "Select Main.*, " +
                            "isnull(nullif(Actual,0)/nullif(Projection,0)*100,0) as Ach From  " +
                            "( " +
                            "Select DataID,DataName=Case when DataID=1 then 'Retail' " +
                            "when DataID=2 then 'B2C' " +
                            "when DataID=3 then 'B2B' " +
                            "when DataID=4 then 'HPA' " +
                            "when DataID=5 then 'Dealer' " +
                            "else 'eStore' end, " +
                            "sum(Projection) Projection,sum(Actual) Actual " +
                            "From  " +
                            "( " +
                            "Select 1 as DataID,0 Projection,0 Actual " +
                            "Union All " +
                            "Select 2,0 Projection,0 Actual " +
                            "Union All " +
                            "Select 3,0 Projection,0 Actual  " +
                            "Union All " +
                            "Select 4,0 Projection,0 Actual  " +
                            "Union All " +
                            "Select 5,0 Projection,0 Actual  " +
                            "Union All " +
                            "Select 6,0 Projection,0 Actual " +
                            "Union All  " +
                            "Select DataID,Projection,0 As Actual " +
                            "From dbo.t_OutletDailyProjection where DataType=" + (int)Dictionary.DeailyProjectionType.Sales_Value + " " +
                            "and ProjectionDate='" + dtDate + "' " +
                            "Union all " +
                            "Select SalesType,0 Projection,sum(InvoiceAmount) Actual  " +
                            "From t_SalesInvoice a,t_RetailConsumer b " +
                            "where a.SundryCustomerID=b.ConsumerID " +
                            "and InvoiceTypeID not in (6,7,8,9,10,11,12) " +
                            "and InvoiceDate='" + dtDate + "' " +
                            "group by SalesType " +
                            ") A group by DataID " +
                            ") Main where DataID not in (2,4)";
            }
            else if (nType == (int)Dictionary.DeailyProjectionType.Sales_Qty)
            {
                sSql = "Select DataID,DataName,Sum(Projection) as Projection, Sum(Actual) as Actual, " +
                            "isnull(nullif(Sum(Actual),0)/nullif(Sum(Projection),0)*100,0) as Ach From  " +
                            "( " +
                            "Select DataID,PdtgroupName as DataName,Projection,0 As Actual " +
                            "From dbo.t_OutletDailyProjection a,t_ProductGroup b " +
                            "where a.DataID=b.PdtGroupID and DataType=" + (int)Dictionary.DeailyProjectionType.Sales_Qty + " " +
                            "and ProjectionDate='" + dtDate + "' and IsActive=1 " +
                            "Union All " +
                            "Select PdtGroupID as DataID,PdtgroupName as MAGName,0 Projection,0 Actual " +
                            "From t_ProductGroup where PdtGroupType=2 and IsActive=1 " +
                            "Union All " +
                            "Select MAGID as DataID,MAGName,0 Projection,sum(Quantity+FreeQty) as Actual " +
                            "From t_SalesInvoice a,t_salesInvoiceDetail b,v_ProductDetails c " +
                            "where a.InvoiceID=b.invoiceID and b.ProductID=c.ProductID " +
                            "and InvoiceTypeID not in (6,7,8,9,10,11,12) " +
                            "and InvoiceDate='" + dtDate + "' " +
                            "group by MAGID,MAGName " +
                            ") Main  GROUP BY DataID,DataName";
            }
            else
            {
                sSql = "Select DataID,DataName=Case when DataID=1 then 'Footfall' " +
                            "when DataID=2 then 'PJP' " +
                            "when DataID=3 then 'Phone' " +
                            "when DataID=4 then 'SMS' " +
                            "when DataID=5 then 'email' " +
                            "else 'Other' end,sum(Projection) Projection,sum(Actual) Actual, " +
                            "isnull(nullif(Sum(Actual),0)/nullif(Sum(Projection),0)*100,0) as Ach from  " +
                            "( " +
                            "Select 1 AS DataID,0 as Projection,0 As Actual " +
                            "Union All " +
                            "Select 2,0 as Projection,0 As Actual " +
                            "Union All " +
                            "Select 3,0 as Projection,0 As Actual " +
                            "Union All " +
                            "Select 4,0 as Projection,0 As Actual " +
                            "Union All " +
                            "Select 5,0 as Projection,0 As Actual " +
                            "Union All " +
                            "Select DataID,Projection,0 As Actual From dbo.t_OutletDailyProjection where DataType=" + (int)Dictionary.DeailyProjectionType.Other + " " +
                            "and ProjectionDate='" + dtDate + "' " +
                            ") Main group by DataID";

            }


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RetailSalesInvoice oDailyProjection = new RetailSalesInvoice();
                    oDailyProjection.DataID = int.Parse(reader["DataID"].ToString());
                    oDailyProjection.DataName = reader["DataName"].ToString();
                    oDailyProjection.Projection = Convert.ToDouble(reader["Projection"].ToString());
                    oDailyProjection.Actual = Convert.ToDouble(reader["Actual"].ToString());
                    oDailyProjection.Achievement = Convert.ToDouble(reader["Ach"].ToString());
                    InnerList.Add(oDailyProjection);
                }
                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDailyProjectionRT(DateTime dtDate, int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nType == (int)Dictionary.DeailyProjectionType.Sales_Value)
            {
                sSql = "Select Main.*, " +
                            "isnull(nullif(Actual,0)/nullif(Projection,0)*100,0) as Ach From  " +
                            "( " +
                            "Select DataID,DataName=Case when DataID=1 then 'Retail' " +
                            "when DataID=2 then 'B2C' " +
                            "when DataID=3 then 'B2B' " +
                            "when DataID=4 then 'HPA' " +
                            "when DataID=5 then 'Dealer' " +
                            "else 'eStore' end, " +
                            "sum(Projection) Projection,sum(Actual) Actual " +
                            "From  " +
                            "( " +
                            "Select 1 as DataID,0 Projection,0 Actual " +
                            "Union All " +
                            "Select 2,0 Projection,0 Actual " +
                            "Union All " +
                            "Select 3,0 Projection,0 Actual  " +
                            "Union All " +
                            "Select 4,0 Projection,0 Actual  " +
                            "Union All " +
                            "Select 5,0 Projection,0 Actual  " +
                            "Union All " +
                            "Select 6,0 Projection,0 Actual " +
                            "Union All  " +
                            "Select DataID,Projection,0 As Actual " +
                            "From dbo.t_OutletDailyProjection where DataType=" + (int)Dictionary.DeailyProjectionType.Sales_Value + " " +
                            "and WarehouseID=" + Utility.WarehouseID + " and ProjectionDate='" + dtDate + "' " +
                            "Union all " +
                            "Select SalesType,0 Projection,sum(InvoiceAmount) Actual  " +
                            "From t_SalesInvoice a,t_RetailConsumer b " +
                            "where a.SundryCustomerID=b.ConsumerID and a.WarehouseID=b.WarehouseID " +
                            "and InvoiceTypeID not in (6,7,8,9,10,11,12) " +
                            "and a.WarehouseID=" + Utility.WarehouseID + " and InvoiceDate='" + dtDate + "' " +
                            "group by SalesType " +
                            ") A group by DataID " +
                            ") Main where DataID not in (2,4)";
            }
            else if (nType == (int)Dictionary.DeailyProjectionType.Sales_Qty)
            {
                sSql = "Select DataID,DataName,Sum(Projection) as Projection, Sum(Actual) as Actual, " +
                            "isnull(nullif(Sum(Actual),0)/nullif(Sum(Projection),0)*100,0) as Ach From  " +
                            "( " +
                            "Select DataID,PdtgroupName as DataName,Projection,0 As Actual " +
                            "From dbo.t_OutletDailyProjection a,t_ProductGroup b " +
                            "where a.WarehouseID=" + Utility.WarehouseID + " and a.DataID=b.PdtGroupID and DataType=" + (int)Dictionary.DeailyProjectionType.Sales_Qty + " " +
                            "and ProjectionDate='" + dtDate + "' and IsActive=1 " +
                            "Union All " +
                            "Select PdtGroupID as DataID,PdtgroupName as MAGName,0 Projection,0 Actual " +
                            "From t_ProductGroup where PdtGroupType=2 and IsActive=1 " +
                            "Union All " +
                            "Select MAGID as DataID,MAGName,0 Projection,sum(Quantity+FreeQty) as Actual " +
                            "From t_SalesInvoice a,t_salesInvoiceDetail b,v_ProductDetails c " +
                            "where a.WarehouseID=" + Utility.WarehouseID + " and a.InvoiceID=b.invoiceID and b.ProductID=c.ProductID " +
                            "and InvoiceTypeID not in (6,7,8,9,10,11,12) " +
                            "and InvoiceDate='" + dtDate + "' " +
                            "group by MAGID,MAGName " +
                            ") Main  GROUP BY DataID,DataName";
            }
            else
            {
                sSql = "Select DataID,DataName=Case when DataID=1 then 'Footfall' " +
                            "when DataID=2 then 'PJP' " +
                            "when DataID=3 then 'Phone' " +
                            "when DataID=4 then 'SMS' " +
                            "when DataID=5 then 'email' " +
                            "else 'Other' end,sum(Projection) Projection,sum(Actual) Actual, " +
                            "isnull(nullif(Sum(Actual),0)/nullif(Sum(Projection),0)*100,0) as Ach from  " +
                            "( " +
                            "Select 1 AS DataID,0 as Projection,0 As Actual " +
                            "Union All " +
                            "Select 2,0 as Projection,0 As Actual " +
                            "Union All " +
                            "Select 3,0 as Projection,0 As Actual " +
                            "Union All " +
                            "Select 4,0 as Projection,0 As Actual " +
                            "Union All " +
                            "Select 5,0 as Projection,0 As Actual " +
                            "Union All " +
                            "Select DataID,Projection,0 As Actual From dbo.t_OutletDailyProjection where WarehouseID=" + Utility.WarehouseID + " and DataType=" + (int)Dictionary.DeailyProjectionType.Other + " " +
                            "and ProjectionDate='" + dtDate + "' " +
                            ") Main group by DataID";

            }


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RetailSalesInvoice oDailyProjection = new RetailSalesInvoice();
                    oDailyProjection.DataID = int.Parse(reader["DataID"].ToString());
                    oDailyProjection.DataName = reader["DataName"].ToString();
                    oDailyProjection.Projection = Convert.ToDouble(reader["Projection"].ToString());
                    oDailyProjection.Actual = Convert.ToDouble(reader["Actual"].ToString());
                    oDailyProjection.Achievement = Convert.ToDouble(reader["Ach"].ToString());
                    InnerList.Add(oDailyProjection);
                }
                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetInvoiceDiscountChargeAll(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select InvoiceID,ProductID,WHID,DiscountTypeID, " +
                        "Amount,isnull(InstrumentNo, '') InstrumentNo, " +
                        "isnull(Description, '') Description From t_SalesInvoiceDiscount " +
                        "where InvoiceID = " + nInvoiceID + "";


            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice oRetailSalesInvoice = new RetailSalesInvoice();
                    oRetailSalesInvoice.ProductID = int.Parse(reader["ProductID"].ToString());
                    oRetailSalesInvoice.WarehouseID = int.Parse(reader["WHID"].ToString());
                    oRetailSalesInvoice.DiscountTypeID = int.Parse(reader["DiscountTypeID"].ToString());
                    oRetailSalesInvoice.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oRetailSalesInvoice.InstrumentNo = reader["InstrumentNo"].ToString();
                    oRetailSalesInvoice.Description = reader["Description"].ToString();
                    InnerList.Add(oRetailSalesInvoice);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshInvoiceForEmail(DateTime dFormDate, DateTime dToDate)
        {
            dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select ConsumerName,InvoiceID,InvoiceNo,InvoiceDate,b.Email from t_SalesInvoice a, t_RetailConsumer b " +
                        "where a.SundryCustomerID = b.ConsumerID and a.WarehouseID = b.WarehouseID " +
                        "and isnull(IsSentEmil,0)= 0 and InvoiceDate between '" + dFormDate + "' and '" + dToDate + "' " +
                        "and InvoiceDate< '" + dToDate + "' and SalesType not in (2,5) and isnull(b.IsVerifiedEmail, 0)= 1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice oCommonClass = new RetailSalesInvoice();
                    oCommonClass.ConsumerName = (string)reader["ConsumerName"];
                    oCommonClass.InvoiceNo = (string)reader["InvoiceNo"];
                    oCommonClass.Email = (string)reader["Email"];
                    oCommonClass.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oCommonClass.InvoiceID = (int)reader["InvoiceID"];
                    InnerList.Add(oCommonClass);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshEmployeeTarget(string sCode)
        {
            
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select * From t_EmployeeTarget where IsExportAble=1 and EmployeeCode='" + sCode + "'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice oCommonClass = new RetailSalesInvoice();
                    oCommonClass.EmployeeCode = (string)reader["EmployeeCode"];
                    oCommonClass.EmployeeName = (string)reader["EmployeeName"];
                    oCommonClass.MAGName = (string)reader["MAGName"];
                    oCommonClass.Brand = (string)reader["BrandName"];
                    oCommonClass.ShowroomCode = (string)reader["OutletName"];
                    oCommonClass.TargetQty = (int)reader["TargetQty"];
                    oCommonClass.Target = Convert.ToDouble(reader["TargetValue"].ToString());

                    InnerList.Add(oCommonClass);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshSRMEmployee()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select distinct EmployeeCode,OutletName,EmployeeName From t_EmployeeTarget where IsExportAble=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailSalesInvoice oCommonClass = new RetailSalesInvoice();
                    oCommonClass.ShowroomCode = (string)reader["OutletName"];
                    oCommonClass.EmployeeCode = (string)reader["EmployeeCode"];
                    oCommonClass.EmployeeName = (string)reader["EmployeeName"];

                    InnerList.Add(oCommonClass);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

}

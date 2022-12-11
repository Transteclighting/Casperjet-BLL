using System;
using System.Collections.Generic;
using System.Text;

namespace CJ.Class
{
    /// <summary>
    /// Message dictionary class
    /// </summary>
    public class Dictionary
    {
        /// <summary>
        /// General Status
        /// </summary>
        public enum GeneralStatus
        {
            All = 0,
            Active = 1,
            Inactive = 2
        }

        public enum IsVatApplicableonNetPrice
        {
            NO = 0,
            YES = 1,

        }
        public enum HRUniformDistributionStatus
        {
            Create = 1,
            Delivered = 2,

        }

        /// <summary>
        /// Brand Level
        /// </summary>
        public enum BrandLevel
        {
            MasterBrand = 1,
            SubBrand = 2,
        }
        public enum SalesOrderFactoryStatus
        {
            Create = 1,
            Partial_Delivery=2,
            Delivered=3,
            Cancel = 4,
        }


        public enum IPDCFileTrackingStatus
        {
            Create = 1,
            Pending = 2,
            Delivered = 3,
            Modified = 4,
            Cancel = 5,
        }


        public enum CSDJobBillReceiveType
        {
            Regular_Receive = 1,
            Pending_Receive = 2,
        }
        public enum CACProjectSecurity
        {
            Tender_security = 1,
            Advance_collection = 2,
            Performance_security = 3,
            Security_Deposit = 4,
        }
        public enum CACSMSSale
        {
            Create = 1,
            Approved = 2,

        }
        public enum DiscountType
        {
            Percent = 0,
            Amount = 1,
        }
        public enum BankDiscountStatus
        {
            Create = 1,
            Approved = 2,
        }
        public enum ASGWaiseFreeEMIStatus
        {
            Create = 1,
            Approved = 2,
        }

        public enum MAGBrandWiseDiscount
        {
            Create = 1,
            Approved = 2,
        }

        public enum B2BDiscountStatus
        {
            Create = 1,
            Approved = 2,
        }
        public enum POSDiscountChargeTableMAP
        {
            t_SalesInvoiceScratchCardInfoNew = 1,
            t_PromoTP = 2,
            t_PromoCP = 3,
            t_PromoDiscountB2B = 4,
            t_PromoDiscountMAGBrandB2C = 5,
            t_PromoDiscountBank = 6,
            t_PromoDiscountSpecial = 7,
            t_EMIExtendedCharge = 8,
            t_PromoDiscountMAGBrandDealer = 9,
            t_PromoDiscountMAGBrandDealerMargin = 50,

        }

        //public enum QuotationInvoiceType
        //{
        //    Invoice = 1,
        //    Non_Invoice = 2,
        //}

        /// <summary>
        ///     /// Geo Location Level
        /// </summary>
        public enum GeoLocationLevel
        {
            District = 1,
            Thana = 2,
        }

        public enum JobLocation
        {
            HO = 1,
        }

        public enum VisitFrequency
        {
            Weekly = 1,
            TwiceInWeek = 2,
            Daily = 7,
            Forthnight = 8,
        }

        /// <summary>
        /// Inventory Category
        /// </summary>
        public enum InventoryCategory
        {
            INVENTORY = 1,
            NON_INVENTORY = 2,
        }
        public enum QuotationInvoiceType
        {
            Invoice = 1,
            Non_Invoice = 2,
        }

        public enum CACProjectInvoiceType
        {
            Invoice = 1,
            Others = 2,
        }

        public enum QuotationHistoryType
        {
            FollowUp = 1,
            Non_FollowUp = 2,
        }
        /// <summary>
        /// Inventory Cate
        /// </summary>
        public enum InventoryCate
        {
            Regular = 1,
            Aged = 2,
            IPB = 3,
            Discontinue = 4,
            Others = 5,
        }

        public enum ProductHistoryType
        {
            InventoryCategory = 1
            
        }
        /// <summary>
        /// Product Stock Tran Type
        /// </summary>
        public enum ProductStockTranType
        {
            GOODS_RECEIVE = 1,
            TRANSFER = 3,
            INVOICE = 5,
            ADD_STOCK = 7,
            DEDUCT_STOCK = 8,
            ISSUE_SALES_PROMOTION = 9,
            ISSUE_FIXED_ASSET = 10,
            ISSUE_CE_SERVICE_REPLACEMENT = 11,
            RETURN_DEFECTIVE_PRODUCT = 12,
            ISSUE_COMPANY_CONSUMPTION = 13,
            ISSUE_LE_SERVICE_REPLACENENT = 14,
            ISSUE_PRODUCT_RETURN_TO_SUPPLIER = 15,
            ISSUE_FOR_PRODUCTION = 16,
            DELIVERY_BREAKAGE_REPLACEMENT = 17,
            ISSUE_SHORT_DELIVERY_PRODUCT = 18,
            ISSUE_SCRAP_SALE = 19,
            ISSUE_DEFECTIVE_OR_SCRAP = 20,
            RECEIVE_SERVICE_DEFECTIVE_PRODUCT = 21,
            RETURN_SALES_PROMOTION = 22,
            RETURN_FIXED_ASSET = 23,
            ISSUE_FOR_CANNIBALIZE = 24,
            ALL = -1,
        }

        /// <summary>
        /// CAC Product Stock Tran Type
        /// </summary>
        public enum CACProductStockTranType
        {
            GOODS_RECEIVE = 1,
            ADD_STOCK = 2,
            ISSUE_CHALLAN = 3,
            DEDUCT_STOCK = 4,
        }

        public enum CACProductStockTranStatus
        {
            Create = 1,
            Approved = 2
        }


        //public enum DeliveryShipmentVendor
        //{
        //    Company_Vehicle = 0,
        //    Rent_Bandhu = 1,
        //    Rent_Hasnath = 2,
        //    Parcel = 3,
        //    Self = 4,
        //    Other = 5
        //}

        public enum DeliveryShipmentVendor
        {
            Company_Vehicle = 0,
            Rent_Aroma = 1,
            Rent_Bandhu = 2,
            Rent_Hasnath = 3,
            Rent_Local = 4,
            Rent_Tutul = 5
        }
        public enum LogDeliveryShipmentDeliveryMode
        {
            Direct_Delivery = 1,
            Parcel_Delivery = 2,
            Self_Delivery = 3,
        }
        public enum PettyCashExpenseStatus
        {
            Create = 1,
            Send_To_HO = 2,
            Approved = 3,
            Reject = 4,
        }

        public enum LogDeliveryShipmentVendorType
        {
            Direct_Vendor = 1,
            Parcel_Vendor = 2,
        }
        public enum LogDeliveryShipmentParcelType
        {
            Direct_Parcel = 1,
            Indirect_Parcel = 2,
        }


        public enum TDDeliveryShipmentStatus
        {
            Undelivered = 0,
            Processing_Delivery = 1,
            Delivered = 2,
            Bill_Approved = 3,
        }

        /// <summary>
        /// Replace Claim Stock Tran Type
        /// </summary>
        public enum ReplaceClaimStockTranType
        {
            GOODS_RECEIVE = 1,
            CLAIM_RECEIVED = 2,
            TRANSFER = 3,
            INVOICE = 4,
            ADD_STOCK = 5,
            DEDUCT_STOCK = 6,
            REENGINNER_GOODS_RECEIVE = 7,
        }
        /// <summary>
        /// Item Category
        /// </summary>
        public enum ItemCategory
        {
            Finished_Product = 1,
            Raw_Material = 2,
            Spare_Parts = 3,
            Gift_Item = 4,
            Sample_Item = 5,
            Acccessories_Item = 6,
        }
        /// <summary>
        /// Replacement Status
        /// </summary>
        public enum ReplacementStatus
        {
            REPLACEMENT_CLAIM_RECEIVE_AT_SERVICE = 1,
            REPLACEMENT_CLAIM_RECEIVE_TEAM_REQUIRED = 2,
            REPLACEMENT_CLAIM_RECEIVE_TO_BE_SEND = 3,
            REPLACEMENT_CLAIM_PRODUCT_PHYSICALLY_RECEIVE = 4,
            REPLACEMENT_CLAIM_SEND_TO_BLL = 5,
            REPLACEMENT_CLAIM_ASSESSMENT_COMPLETE = 6,
            REPLACEMENT_CLAIM_ON_CHECKING_BY_ACCOUNT = 7,
            REPLACEMENT_CLAIM_WAITING_FOR_APPROVAL = 8,
            REPLACEMENT_CLAIM_APPROVED = 9,
            REPLACEMENT_CLAIM_REPLACED = 10,
            REPLACEMENT_CLAIM_CANCEL = 13,
        }
        /// <summary>
        /// Barcode Applicable
        /// </summary>
        public enum BarcodeApplicable
        {
            NO = 0,
            YES = 1,
        }

        public enum DeliveryShipmentTranType
        {
            Challan = 0,
            Invoice = 1,
        }

        /// <summary>
        /// Replace Claim Approval Status
        /// </summary>
        public enum ApprovalStatus
        {
            INACTIVE = 0,
            ACTIVE = 1,
        }
        /// <summary>
        /// Provision Type
        /// </summary>
        public enum ProvisionType
        {
            SC = 1,
            SE = 2,
            TP = 3,
            ANP = 4,
            PW = 5, // Product Replacement
            PF = 6,
        }
        /// <summary>
        /// Replacement Fault
        /// </summary>
        public enum ReplacementFault
        {
            REPLACEMENT_FAULT_PINMISSING = 1,
            REPLACEMENT_FAULT_BADSOLDER = 2,
            REPLACEMENT_FAULT_OXIDIZED = 3,
            REPLACEMENT_FAULT_LOOSECAP = 4,
            REPLACEMENT_FAULT_SHORTLIFE = 5,
            REPLACEMENT_FAULT_COILBROKE = 6,
            REPLACEMENT_FAULT_OTHERBRAND = 7,
            REPLACEMENT_FAULT_OKLAMP = 8,
            REPLACEMENT_FAULT_LIFEOVER = 9,
            REPLACEMENT_FAULT_BROKENLAMP = 10,
            REPLACEMENT_FAULT_NOCARTON = 11,
            REPLACEMENT_FAULT_BADCIRCUIT = 12,
            REPLACEMENT_FAULT_LOOSETUBE = 13,
            REPLACEMENT_FAULT_RUSTYLAMP = 14,
            REPLACEMENT_FAULT_BADTUBE = 15,
            REPLACEMENT_FAULT_TEMPLAMP = 16,
        }

        /// <summary>
        /// Replace Claim challan Module
        /// </summary>
        public enum ReplaceChallanStatus
        {
            Received = 1,
            Approved = 2,
            Delivered = 3,
        }

        /// <summary>
        /// Replace Claim WareHouse 
        /// /// </summary>
        public enum ReplaceWareHouse
        {
            SystemWH = 1,
            ProductionWH = 2,
            ReengineeredWH = 3,
            ReplaceCentralWH = 4,
        }

        public enum ReplaceProductTran
        {
            StockReceive = 1,
            StockIssue = 2,
        }


        public enum ID_Type
        {
            ReplaceClaimNo,
        }

        /// <summary>
        /// Sypply Type
        /// </summary>
        public enum SupplyType
        {
            LOCAL = 1,
            IMPORTED = 2,
        }

        public enum VATType
        {
            LOCAL_5 = 1,
            LOCAL_15 = 2,
            IMPORTED_15 = 3,
            VAT_Exempted = 4,
            IMPORTED_5 = 5,
            Service_Charge_10 = 6,
            Spar_Parts_5 = 7,
            Transpotation_15= 8,
        }
        /// <summary>
        /// SCM Status
        /// </summary>
        public enum SCMStatus
        {
            PSI = 1,
            OrderPlace = 2,
            PIReceive = 3,
            LCProcessing = 4,
            LCOpening = 5,
            Shipment = 6,
            CustomClearance = 7,
            Release = 8,
            ReadyForGRD = 9,
            Billing = 10,
            ProductReceived = 11,
            LogAcknowledgement = 12,
        }

        public enum SCMLCRequisitionStatus
        {
            Create = 1,
            Review = 2,
            Approved = 3,
            Reject = 4,

        }


        /// <summary>
        /// SCM Status
        /// </summary>
        /// 
        public enum SCMBOMStockLocation
        {
            BEIL_Logistics = 1,
            BEIL_Production_Floor = 2,
        }
        /// <summary>
        /// SCM Status
        /// </summary>
        /// 
        public enum BEILMaterialRequisitionStatus
        {
            Create = 1,
            Authorised = 2,
            Approved = 3,
            Issued = 4,
            Received = 5,
        }


        public enum ReportKeyfrmInvoiceRegister
        {
            Invoice_Register_All = 0,
            ASG_Wise_Sale_For_Apps_All = 1,
            Invoice_Register_Retail_Other = 2,
            Invoice_Register_Dealer = 3,
            ASG_Wise_Sale_For_Apps_Retail_Other = 4,
            ASG_Wise_Sale_For_Apps_Dealer = 5,
        }

        public enum ReportKeyfrmSaleQtyNValue
        {
            Sale_Qty_and_Value_All = 0,
            Sale_Qty_and_Value_Retail_Other = 1,
            Sale_Qty_and_Value_Dealer = 2,
        }

        public enum ReportKeyfrmSalesTrandReport
        {
            Sales_Trand_All = 0,
            Sales_Trand_Retail_Other = 1,
            Sales_Trand_Dealer = 2,
        }

        /// <summary>
        /// IsLC
        /// </summary>
        public enum IsLC
        {
            NONLC = 0,
            LC = 1,
        }
        public enum IsIndoorItem
        {
            No = 0,
            Yes = 1,
        }
        public enum ProductionType
        {
            CBU = 1,
            SKD = 2,
            FG = 3,
            Repair = 4,
        }

        public enum LCMComponent
        {
            Chassis = 1,
            LED_Bar = 2,
            Opencell = 3,
            TCon = 4,
        }
        public enum LCMStatus
        {
            Stage_1 = 1,
            Stage_2 = 2,
            Stage_3 = 3,
            Stage_4 = 4,
        }
        public enum LCMQCStatus
        {
            Repaired = 1,
            Replaced = 2,
            NDF = 3,
        }
        public enum LCMRootcause
        {
            Man = 1,
            Machine = 2,
            Materials = 3,
            Environment = 4,

        }

        /// <summary>
        /// Currency
        /// </summary>
        public enum Currency
        {
            BDT = 1,
            USDollar = 2,
            CNY = 3,
            KPW = 4,
            Euro=5,
        }

        public enum SCMPaymentModality
        {
            Local_Cash = 1,
            Local_LC = 2,
            Foreign_LC = 3,
        }
        public enum SCMPortofDischarge
        {
            CTG_Airport = 1,
            Dhaka_Airport = 2,
        }
        public enum SCMShippedBy
        {
            Sea = 1,
            Air = 2,
        }
        /// <summary>
        /// VAT Challan Type
        /// </summary>
        public enum ChallanType
        {
            VAT_11 = 1,
            VAT_11_KA = 2,
            VAT_63 = 3,
            VAT_6_5 = 4,
            VAT_6_7 = 5,

        }
        /// <summary>
        /// Duty Type
        /// </summary>
        public enum DutyType
        {
            VAT = 1,
            ATV = 2,
            Other = 3,
        }

        public enum DutyAccount
        {
            MUSHAK_11KA = 1,
            MUSHAK_11 = 2,
            MUSHAK_6_3 = 3,
        }
        public enum DutyAccountNew
        {
            MUSHAK_11KA = 1,
            MUSHAK_11 = 2,
            MUSHAK_6_3 = 3,
            MUSHAK_6_5 = 4,
            MUSHAK_6_7 = 5,
        }

        /// <summary>
        /// Duty Tran Type.it must synchronize in t_DutyTranType table
        /// </summary>
        public enum DutyTranType
        {
            INVOICE = 1,
            TRANSFER = 2,
            REVERSE_RETURN = 3,
            TREASURY_CHALLAN = 4,
            PURCHASE_REBATE = 5,
            SUPPLY_REBATE = 6,
            BANK_CHARGER_REBATE = 7,
            INSURANCE_REBATE = 8,
            GLOBAL_TASK_REBATE = 9,
            CREDIT_NOTE = 10,
            Service_VAT = 11,
            Service_TRANSFER = 12,
            Service_CASH_SALE = 13
        }
        /// <summary>
        /// Credit Limit Checking criteria
        /// </summary>
        public enum CreditLimitCheck
        {
            Any = 1,
            Maximum = 2,
            Minimum = 3,
        }

        /// <summary>
        ///IS EMI For Bank
        /// </summary>
        public enum IsEMI
        {
            No = 0,
            Yes = 1,
        }
        public enum EMITenureStatus
        {
            Create = 0,
            Approved = 1,
        }

        public enum ToolManagement
        {
            Create = 1,
            Approved = 2,
        }

        public enum ToolManagementStatus
        {
            //Create = 1,
            //Approved = 2,
            Received = 1,
            Issued = 2,
        }

        public enum ToolManagementWarehouse
        {
            System = 1,
            Sound = 2,
            Damage = 3,
        }

        public enum TechnicianBlockStatus
        {
            Create = 0,
            Approved = 1,
        }
        /// <summary>
        /// Company Info
        /// </summary>
        public enum CompanyInfo
        {
            TEL = 1,
            BEIL = 2,
            BLL = 3,
            TCL = 4,
            TML = 5,
            SYSTEM = 6,
            Excel = 7,
        }
        public enum CompanyID
        {
            TEL = 82941,
            BEIL = 82942,
            BLL = 82943,
            TML = 82944,
            TMCL = 82945,
        }
        /// <summary>
        /// Company Info
        /// </summary>
        public enum SBU
        {
            Distribution = 1,
            Retail = 2,
            IBP = 3,
            ALL = 4,
            ENA = 5,
            System = 6,

        }

        /// <summary>
        /// Product Group Type
        /// </summary>
        public enum BudgetTargetProductGroupType
        {
            Product = 1,
            MAG = 2,
            ProductCategory = 3,
            None = 4,
            ASG = 5,
            PG = 6,
            AG = 7,
        }
        /// <summary>
        /// Plan Type
        /// </summary>
        public enum PlanType
        {
            Budget = 1,
            Target = 2,
        }
        /// <summary>
        /// Market Scope Type
        /// </summary>
        public enum MarketScopeType
        {
            National = 1,
            Area = 2,
            Territory = 3,
            Customer = 4,
        }
        /// <summary>
        /// Period Type
        /// </summary>
        public enum PeriodType
        {
            Yearly = 1,
            Quaterly = 2,
            Monthly = 3,
            Weekly = 4,
            Daily = 5,
        }
        /// <summary>
        /// TD Plan Stage
        /// </summary>
        public enum TDPlanStage
        {
            No_Plan = 0,
            Executive_Plan = 1,
            OutletManager_Plan = 2,
            ZonalManager_Plan = 3,
            NationalManager_Plan = 4,
        }
        /// <summary>
        /// Plan version Status
        /// </summary>
        public enum PlanVersionStatus
        {
            Submit = 1,
            Approve = 2,
        }
        /// <summary>
        /// Plan version Type
        /// </summary>
        public enum PlanVersionType
        {
            ExecutiveWeekTarget = 1,
            PGWiseTargetValue = 2,
            MAGWiseTargetQty = 3,
            CustomerTargetQty = 4,
            ExecutiveLeadTarget = 5,
            ExecutiveMAGWeekTargetQty = 6,
            OpportunityTarget = 7,
            PlanDealerMAGTarget = 8,
        }


        /// <summary>
        /// IB Invoice Status
        /// </summary>
        public enum IBInvoiceStatus
        {
            Paid = 1,
            UnPaid = 2,
            PartialPaid = 3,
        }

        /// <summary>
        /// User Type
        /// </summary>
        public enum UserType
        {
            Administrator = 1,
            Power_User = 2,
            Normal = 3,
            Guest = 4,
        }
        /// <summary>
        /// Stationary Tran Type
        /// </summary>
        public enum StationaryTranType
        {
            Requisition = 1,
            Purchase = 2,
            Issue = 3,
        }

        public enum OfficeTranStatus
        {
            Create = 0,
            Send_To_HO = 1,
            Approve_By_HO = 2,
            Reject_By_HO = 3,

        }
        public enum UnsouldDefectiveCategory
        {
            LOG_Delivery = 1,
            LOG_Handling = 2,
            TD_Display = 3,
            TD_Handling = 4,
            TD_Home_Delivery = 5,
            Manufacturering = 6,
            Others = 7,
            Before_2018 = 8,
            QC_Failed_MKT_Approved = 9,
            LOG_Handling_MKT_Approved = 10,
            QC_Pass_MKT_Approved = 11,
        }

        public enum RepairStatus
        {
            Repaired_and_Stock = 1,
            Repaired_and_Discount = 2,
            Scrap_Declared = 3,
            Work_in_Progress = 4,
            Pending_for_Parts = 5,
            No_Progress = 6
        }

        public enum IsPenaltyApplicable
        {
            No=1,
            Yes=2
        }
        public enum UnsouldDefectiveTechRecommandation
        {
            Stock = 1,
            Discount = 2,
            Scrap = 3,
            CW_Service = 4,
            Pending = 5,
        }
        public enum UnsouldDefectiveProductStatus
        {
            Create = 1,
            Send_To_HO = 2,
            Assessed_Plan = 3,
            Assessed = 4,
            Discount_Approved = 5,
            Log_Noted = 6,
            Log_Return = 7,
            Reject = 8,
            Invoiced = 9,

        }

        public enum POSUnsouldDefectiveProductStatus
        {
            Create = 1,
            Send_To_HO = 2,
            Assessed = 3,
            Discount_Approved = 4,
            Reject = 5,
            Invoiced = 6,

        }

        public enum POSUnsouldDefectiveProductStatusNew
        {
            Create = 1,
            Send_To_HO = 2,
            Assessed = 3,
            Discount_Approved = 4,
            Reject = 5,
            Invoiced = 6,
            Convert_To_Sound_Stock = 7,
            Transfer_To_Other_Outlet = 8,
        }
        public enum IsDefectiveAcknowledged
        {
            Yes = 1,
            No = 0,
        }

        /// <summary>
        /// Lot Type
        /// </summary>
        public enum ProductionLotType
        {
            TV = 1,
            Ref = 2,
            AC = 3,
            FRZ = 4,
        }

        /// <summary>
        /// Lot Type
        /// </summary>
        public enum ProductionWorkType
        {
            NewProduction = 1,
            Rework = 2,
        }

        /// <summary>
        /// ProductionStatus
        /// </summary>
        public enum ProductionStatus
        {
            Create = 1,
            Plan = 2,
            PartialPlan = 3,
            Actual = 4,
            PartialActual = 5,
            Cancel = 6,
        }

        public enum SuperOutlet
        {
            TDD = 187,
            TID = 186,

        }


        /// <summary>
        /// Customer Verification Status
        /// </summary>
        public enum CustomerVerificationStatus
        {
            NotVerified = 0,
            Verified = 1,

        }

        public enum BusinessUnitSubProject
        {
            Production = 1,
            TD = 2,
            Project_CAC = 3,
            Project_Lighting = 4,
            CSD = 5,
            Common = 6,

        }
        public enum CSDYesOrNoStatus
        {
            YES = 1,
            No =2,
        }
        /// <summary>
        /// Customer Verification Status
        /// </summary>
        public enum CustomerVerificationDataType
        {

            BusinessNature = 1,
            CompanyType = 2,
            CompanyCategory = 3,
            VerifiedThtough = 4,

        }

        /// <summary>
        /// ProductionStatus
        /// </summary>
        public enum ProductionLotDeliveryStatus
        {
            Create = 1,
        }

        /// <summary>
        /// Stationary Tran Type
        /// </summary>
        public enum OfficeItemType
        {
            Stationary = 1,
            Toiletry = 2,
            Other = 3,
        }
        /// <summary>
        /// PC Type
        /// </summary>
        public enum PCType
        {
            Desktop = 1,
            Laptop = 2,
            Server = 3,
        }
        /// <summary>
        /// TEL Accessories
        /// </summary>
        public enum TELAccessories
        {
            Printer = 1,
            Scaner = 2,
            Modem = 3,
            UPS = 4,
            Network_Accessories = 5,
        }
        /// <summary>
        /// Selection Mode
        /// </summary>
        public enum SelectionMode
        {
            NOT_SELECTED = 0,
        }
        /// <summary>
        /// Employee Job Type
        /// </summary>
        public enum JobType
        {
            SALES_PERSONS = 1,
        }

        /// <summary>
        /// Transport Mode
        /// </summary>
        public enum ModeOfTransport
        {
            SEA = 0,
            AIR = 1,
            LAND = 2,
        }

        /// <summary>
        /// Proforma Invoice Status
        /// </summary>
        public enum ProformaInvoiceStatus
        {
            Received = 0,
            Apply_for_Approval = 1,
            Approved = 2,
            LC_Opened = 3,
            Cancelled = 4,

        }
        public enum ReportGroupOption
        {
            Channel = 1,
            Area = 2,
            Territory = 3,
            Channel_Geo = 4,
            Area_Geo = 5,
            Territory_Geo = 6,
        }
        /// <summary>
        /// LC Type
        /// </summary>
        public enum LCType
        {
            LC_At_Sight = 0,
            Covered_By_Buyer = 1,

        }
        /// <summary>
        /// Insurance Type
        /// </summary>
        public enum InsuranceType
        {
            Covered_By_Supplier = 0,
            Deferred = 1,

        }

        /// <summary>
        /// Customer Type
        /// </summary>        
        public enum CustomerType
        {
            OwnShowroom = 5,
            Lighting = 2,
            EPS_EzeeBuy = 98,
            TMLEPS_EzeeBuy = 213,
            TD_HPA = 244,
            TD_Corporate = 249,
            Inactive_Electronics = 219,
        }

        public enum POSCustomerType
        {
            Electronics_Dealer_TEL = 2,
            Own_Showroom_TEL = 5,
            Electronics_Exclusive_Dealer_TEL = 217,
            Inactive_Electronics_TEL = 219,
            TD_HPA_TEL = 244,
            B2C_TEL = 245,
            B2B_TEL = 249,
            B2B_TML = 202,
            SES_TML = 209,
            TML_RETAIL = 210,
            B2C_TML = 217,
        }
        
        /// <summary>
        /// POS Invoice Type
        /// </summary>        
        public enum POSInvoiceType
        {
            General_Invoice = 0,
            Bulk_Invoice = 1,
        }
        /// <summary>
        /// POS WEB Module
        /// </summary>        
        public enum POSWEBModule
        {
            SalesPlan = 1,
            FoolFall = 2,
            FootFallVsSaleReport = 3,
        }
        /// <summary>
        /// POS Day Start End Log Type
        /// </summary>        
        public enum DayStartEndLogType
        {
            DayStart = 1,
            DayEnd = 2,
        }
        /// <summary>
        /// POS Invoice UI Control
        /// </summary>        
        public enum POSInvoiceUIControl
        {
            RetailInvoice = 1,
            CorporateInvoice_B2C = 2,
            CorporateInvoice_B2B = 3,
            RetailInvoice_HPA = 4,
            DealerInvoice = 5,
            eStore = 6,
        }
        /// <summary>
        /// POS SalesType
        /// </summary>        
        public enum SalesType
        {
            Retail = 1,
            B2C = 2,
            B2B = 3,
            HPA = 4,
            Dealer = 5,
            eStore = 6,
        }

        /// <summary>
        /// POS Channel
        /// </summary>        
        public enum POSChannel
        {
            Retail = 1,
            B2B = 2,
            Dealer = 3,
            eStore = 4,
        }
        public enum SpacialDiscountCustType
        {
            Customer = 1,
            Consumer = 2,

        }
        public enum SpacialDiscountStatus
        {
            Create = 1,
            Send_To_HO = 2,
            Approved = 3,
            Rejected = 4,
            Invoiced = 5,
        }
        /// <summary>
        ///CustomerTypeSalesLead
        /// </summary>  
        /// 


        public enum SalesLeadMark
        {
            Yes = 1,
            No = 0,
            NA = 2,
        }


        public enum CustomerTypeSalesLead
        {
            Retail = 1,
            B2C = 2,
            B2B = 3,
            HPA = 4,
            Dealer = 5,
            EStore = 6,
        }

        /// <summary>
        ///Lead Conversion Possibility
        /// </summary>        
        public enum LeadConversionPossibility
        {
            Low = 1,
            Medium = 2,
            High = 3,
        }

        public enum LeadSource
        {
            General = 0,
            Activation = 1,
        }
        public enum IsValidLead
        {
            Invalid = 0,
            Valid = 1,
        }

        public enum LeadStatus
        {
            Valid = 1,
            Invalid = 2,
            Not_Reached = 3,
        }


        public enum IsHVACLead
        {
            No = 0,
            Yes = 1,
        }

        /// <summary>
        ///SalesLeadStatusPOS
        /// </summary>        
        public enum SalesLeadStatusPOS
        {
            Create = 1,
            Send_To_HO = 2,
            Sales_Executed = 3,
            Cancel = 4,
            In_Progress = 5,
            No_Answer = 6,
            Follow_Up = 7,
            Product_Not_Available = 8,

        }


        /// <summary>
        ///SalesLeadStatusPOS
        /// </summary>        
        public enum SalesLeadStatusUpdatePOS
        {
            Cancel = 4,
            In_Progress = 5,
            No_Answer = 6,
            Follow_Up = 7,
            Product_Not_Available = 8,
        }

        /// <summary>
        ///PotentialCustomer
        /// </summary>        
        public enum PotentialCustomer
        {
            Create = 1,
            Send_To_HO = 2,
            Convert_to_Lead = 3,
        }

        public enum PotentialCustomerType
        {
            POS = 1,
            WEB_Contact_Us = 2,
            WEB_Bulk_Sales_Request = 3,
            HO = 4,
            Collected_Contact = 5,
            Registered_Customer = 8,
        }

        public enum PotentialCustomerSource
        {
            POS = 1,
            WEB_Contact_Us = 2,
            WEB_Bulk_Sales_Request = 3,
            HO = 4,
            Collected_Contact = 5,
            Sales = 6,
            Service = 7,
            Registered_Customer = 8,
            Facebook = 9,
            Inbound_Call = 10,
            Reve_Chat = 11,
            Web_Order = 12,
            Others = 13,

        }

        /// <summary>
        ///OutboundStatus
        /// </summary>        
        public enum OutboundStatus
        {
            Potential = 1,
            Invalid_Number = 2,
            Switched_Off = 3,
            Not_Answer = 4,
            Not_Sure = 5,
            Not_Interested = 6,
            Visited_To_Outlet_But_Not_Purchased = 7,
            Call_Later = 8,
            Interested = 9,
            Bought_From_Other_Brand = 10,
            Convert_To_Lead = 11,
            No_Lineup = 12,
            Offered_Price_Is_Not_Suitable = 13,
            Out_of_Dhaka = 14,
            Info = 15,
            Extended_EMI = 16,
            Higher_Purchase_Cash = 17,
            International_Credit_Card = 18,
            Showroom_Address = 19,
            Not_Reachable = 20,
            Higher_Purchase_Card = 21,
        }
        /// <summary>
        /// ShowroomAssetType
        /// </summary>        
        public enum ShowroomAssetType
        {
            POSMachine = 1,
        }

        /// <summary>
        /// ShowroomAssetType
        /// </summary>        
        public enum ShowroomWHType
        {
            MainWH = 1,
            SubWH = 2,
        }

        public enum ConsumerAdvancePaymentMode
        {
            Cash = 1,
            Card = 2,
        }
        public enum ConsumerAdvancePaymentTranType
        {
            Advance = 1,
            Adjust = 2,
        }
        /// <summary>
        /// Credit Card Type
        /// </summary>        
        public enum CreditCardType
        {
            VISA = 1,
            MASTER = 2,
            AMEX = 3,
            NEXUS = 4,
            JCB = 5,
        }

        public enum DiscountChargeType
        {
            Discount = 0,
            Charge = 1,
            Free_Product=2,
        }

        public enum DiscountChargeItem
        {
            // Scratch_Card_Discount = 1,
            Trade_Promotion = 2,
            Consumer_Promotion = 3,
            B2B_Discount = 4,
            B2C_Discount = 5,
            Bank_Discount = 6,
            Special_Discount = 7,
            Extended_EMI_Charge = 8,
            Dealer_Discount = 9,
            Dealer_Margin = 50,
        }
        public enum IsSystemDiscountChargeItem
        {
            Scratch_Card_Discount = 1,
            Trade_Promotion = 2,
            Consumer_Promotion = 3,
            B2B_Discount = 4,
            B2C_Discount = 5,
            Bank_Discount = 6,
            Special_Discount = 7,
            Extended_EMI_Charge = 8,
            Dealer_Discount = 9,
            Dealer_Margin = 50,
        }

        /// <summary>
        /// Credit Card Type
        /// </summary>        
        public enum CreditCardCategory
        {
            DebitCard = 1,
            CreditCard = 2,

        }

        /// <summary> 
        /// Over Stock Reason For BLL
        /// </summary>        
        public enum OverStockReason
        {
            SpecialOrder = 1,
            SeasonalDemand = 2,
            MOQ = 3,
            Stocking = 4,
        }
        /// <summary>
        /// Retail Customer Type
        /// </summary>        
        public enum RetailCustomerType
        {
            General = 0,
            Special = 1,
        }
        /// <summary>
        /// Price Option ID
        /// </summary>
        public enum PriceOption
        {
            NSP = 1,
            RSP = 2,
            Special_Price = 3,
            Cost_Price = 4,
            Trade_Price = 5,
            MRP = 6,
        }
        /// <summary>
        /// Receivable Data Category
        /// </summary>
        public enum ReceivableDataCategory
        {
            None = 0,
            Price = 1,
            Stock_Serial = 2,
        }
        /// <summary>
        /// Receivable Data Type
        /// </summary>
        public enum ReceivableDataType
        {
            None = 0,
            MaxPriceID = 1,
            CP = 2,
            NSP = 3,
            RSP = 4,
        }
        /// <summary>
        /// Active Or InActive Status
        /// </summary>        
        public enum ActiveOrInActiveStatus
        {
            INACTIVE = 0,
            ACTIVE = 1,
        }

        /// <summary>
        /// Yes Or No Status
        /// </summary>        
        public enum YesOrNoStatus
        {
            NO = 0,
            YES = 1,
        }
        public enum CACProjectType
        {
            Product = 1,
            Supplier = 2,
        }
        public enum IsVerified
        {
            Not_Verified = 0,
            Verified = 1,
        }
        public enum QuotationStatus
        {
            Create = 0,
            Submit = 1,
            PO_WO = 2,
            Cancel = 3,
        }
        public enum OutletFeasibilityStatus
        {
            Create = 1,
            Approve = 2,

        }
        public enum OutletMarketType
        {
            Main_Competitors = 1,
            Transtec_Competitors = 2,
            Dealer_Competitors = 3,
        }
        public enum CACProjectStatus
        {
            Create = 1,
            Running = 2,
            Complete = 3,
            Pending = 4,
            Cancel = 5,
            Handover = 6,
        }
        /// <summary>
        /// In Or Out Status
        /// </summary>        
        public enum InOrOutStatus
        {
            IN = 1,
            OUT = 2,
        }
        /// <summary>
        /// Product Or Amount Status
        /// </summary>        
        public enum ProductOrAmountStatus
        {
            Product = 1,
            Amount = 2,
        }

        public enum ReportType
        {
            SKU_WISE = 1,
            AG_WISE = 2,
            ASG_WISE = 3,
            MAG_WISE = 4,
            PG_WISE = 5,
            SUPPLIER_WISE = 6,
            SBU_WISE = 7,
            CHANNEL_WISE = 8,
            AREA_WISE = 9,
            CUSTOMER_WISE = 10,
            TERRITORY_WISE = 11,
            BRAND_WISE = 12,
            BRAND_AND_ASG_WISE = 13,
            Central = 14,
            Warehouse_Location_Wise = 15,
            INVOICE_WISE = 16,
        }
        /// <summary>
        /// Gift Voucher Status D:\Local\TEL\CasperJet\CJ.POS\Invoice\frmSalesInvoiceDiscount.cs
        /// </summary>
        public enum GiftVoucherStatus
        {
            Create = 0,
            Transfer = 1,
            Sold = 2,
            Redeem = 3,
        }
        /// <summary>
        /// Credit Approval Status
        /// </summary>        
        public enum CreditApprovalStatus
        {
            Create = 0,
            Approve = 1,
            Cancel = 2,
        }
        /// <summary>
        /// Customer Transection Type
        /// </summary>        
        public enum TransectionType
        {
            //RECEIVE=1,
            //INVOICE=2,
            CREDIT_INVOICE = 1,//CR
            CASH_INVOICE = 2,//CR
            EPS_INVOICE = 3,//CR
            CASH_RECEIVE = 4,//DR
            CREDIT_RECEIVE = 5,//DR
            EPS_INSTALLMENT = 6,//DR
            EPS_INTEREST_REVERSE = 7,//DR
            CREDIT_INVOICE_REVERSE = 13,//DR
            CASH_INVOICE_REVERSE = 14,//DR
            EPS_INVOICE_REVERSE = 15,//DR
            CREDIT_RECEIVE_REVERSE = 16,//CR
            CASH_RECEIVE_REVERSE = 17,//CR
            EPS_INSTALLMENT_REVERSE = 18,//CR

            //This are additional Transaction Type used to merge MDB Data(old system Transaction Type)
            ADJUSTMENT = 19, //Credit Adjustment
            ADJUSTMENT_REVERSE = 20,

            ADJUSTMENT_FOR_TRADE_PROMOTION = 21,//CR
            ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE = 22,

            ADJUSTMENT_FOR_SE_CPM = 23,////CR//SE = Selling Expense ; CPM = Customer Profit Margin
            ADJUSTMENT_FOR_SE_CPM_REVERSE = 24,

            INITIAL_ADJUSTMENT_CREDIT = 25,//Other Adjustment
            INITIAL_ADJUSTMENT_DEBIT = 26,
            CANCELED_CR = 27,//CR
            CANCELED_DR = 28,
            INCOME_TAX_DEDUCTED_AT_SOURCE = 31,//CR
            VAT_DEDUCTED_AT_SOURCE = 32,//CR
            DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT = 33,//CR
            SPECIAL_DISCOUNT_IF_ANY = 34,//CR
            ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY = 35,//CR
            // for TML
            CO_OP_EXPENSE = 36,//CR
            PRICE_PROTECTION = 37,//CR
        }
        /// <summary>
        /// Customer Transaction Adjustment Type
        /// </summary>
        /// 
        public enum CustomerTranGroup
        {
            Sales = 1,
            Collection = 2,
            Adjustment = 3,
        }
        public enum CollectionType
        {
            SALES_COLLECTION_CREDIT = 1,
            SALES_COLLECTION_CASH = 2,
            BONUS_PROVISSION = 3,
            MISC_ADJUSTMENT = 4,
        }
        /// <summary>
        /// Product Type
        /// </summary>
        public enum ProductType
        {
            CE = 1,
            EB4 = 2,//EB4 Product
            LE_Import = 3,
            PL = 4,
            RAW_METETRIALS = 5,

        }
        /// <summary>
        /// System Define Channel
        /// </summary>
        public enum SystemChannel
        {
            SYS_CHANNEL = 1,
        }
        /// <summary>
        /// System Define Ware house
        /// </summary>
        public enum SystemWarehouse
        {
            SYS_WAREHOUSE = 1,
        }
        /// <summary>
        /// System Define Ware house
        /// </summary>
        public enum Warehouse
        {
            CentralRetailWarehouse = 70,
            Service_Return_Stock_from_TD_Outlet = 123,
        }
        /// <summary>
        /// Instrument Type
        /// </summary>        
        public enum InstrumentType
        {
            DD = 0,
            PAYORDER = 1,
            CASH = 2,
            CHEQUE = 3,
            TT = 4,
            CREDIT_CARD = 5,
            BG=6,
            BEFTN=7,
            RTGS=8,
            Adjustment=9,
        }
        /// <summary>
        /// DCS Cheking Status
        /// </summary>        
        public enum DCSCheckingStatus
        {
            UnCheck = 0,
            Checked = 1,
            Pending = 2,
            Cancel = 3,
        }
        public enum DCSAdditionalInsturement
        {
            Additional_Amount = 101,
            Others = 201,
        }
        public enum DCSType
        {
            Invoice = 1,
            CashCollectNDeposit = 2,
            CreditCollection = 3,
            ExtendedWarrantyCollection = 4,
        }
        /// <summary>
        /// Foot Fall 
        /// </summary> 
        /// 

        public enum FootFallCustType
        {
            WalkIn = 0,
            Corporate = 1,
            OutdoorIndividual = 2,
        }
        public enum Installment
        {
            NA = 0,
            _3 = 1,
            _6 = 2,
            _9 = 3,
            _12 = 4,
            _18 = 5,
            _24 = 6,
        }
        public enum ExpectedWeek
        {
            NA = 0,
            Week_1 = 1,
            Week_2 = 2,
            Week_3 = 3,
            Week_4 = 4,
            Week_5 = 5,
            Week_6 = 6,
        }
        public enum YesNAStatus
        {
            NA = 0,
            Yes = 1,
        }
        public enum ReasonforNotbuying
        {
            NoStock = 1,
            CustomerPositive = 2,
            CustomerUndecided = 3,
        }

        //
        public enum FootFallIsDisclosed
        {
            No = 0,
            Yes = 1,
        }
        public enum FootFallIsCloseFollowup
        {
            No = 0,
            Yes = 1,
        }

        public enum FootFallIsConversion
        {
            No = 0,
            Yes = 1,
        }
        public enum DeailyProjectionType
        {
            Sales_Value = 1,
            Sales_Qty = 2,
            Other = 3,
        }
        public enum DeailyProjectionOtherData
        {
            Footfall = 1,
            PJP = 2,
            Phone = 3,
            SMS = 4,
            email = 5,
        }

        public enum FootFallReason
        {
            Stock_Unavailable = 0,
            KISTI_Installment = 1,
            Instabuy_on_CreditCard = 2,
            Lack_of_feature = 3,
            Price_Factor = 4,
            Visit_Again = 5,
            Choice_Other_Brand = 6,
            Others = 7,
        }
        public enum FootFallModeofFollowup
        {
            PhoneCall = 0,
            SMS = 1,
            Email = 2,
            Physical_Visit = 3,
        }
        public enum FootFallContactResult
        {
            Time_Needed = 0,
            Not_Decided = 1,
            Not_Interested = 2,
            Already_Bought = 3,
        }
        public enum FootFallDetailType
        {
            Brand = 0,
            Reason = 1,
        }
        public enum FootFallIsContacted
        {
            False = 0,
            True = 1,
        }

        /// <summary>
        /// Instrument Status 
        /// </summary>        
        public enum InstrumentStatus
        {
            NONE = 0,
            NOT_APPROVED = 1,
            APPROVED = 2,
            ALL = 3,
        }

        public enum TranSide
        {
            IN = 1,
            OUT = 2,
        }

        /// <summary>
        /// TransectionSide Description
        /// </summary>        
        public enum TransectionSide
        {
            CREDIT = 1,
            DEBIT = 2,
        }

        public enum TPorKPISettlement
        {
            TP = 1,
            KPI = 2,
        }

        /// <summary>
        /// Invoice Process flow determine how Product delivery made against invoice
        /// </summary>        
        public enum InvoiceProcessFlow
        {
            Invoice_For_Order = 1,
            Invoice_And_Booking = 2,
            Invoice_And_Delivery = 3,
            Invoice_From_Remote_Location = 4,
        }
        /// <summary>
        /// determine increase or decrease of warehouse stock 
        /// </summary>
        public enum StockUpdateSide
        {

            STOCK_DECREASE = 2,
            STOCK_INCREASE = 1,
        }
        public enum UploadStatus
        {
            Uploaded = 1,
            Downloaded = 2,
        }
        public enum StockTransactionStatus
        {
            COMPLETE = 1,
            TRANSIT = 2,
            CANCEL = 3,
            REVERSE = 4,
            PENDING = 5,
        }
        /// <summary>
        /// Session Key Description
        /// </summary>        
        public enum SessionKey
        {
            KEY_PREV_PAGE,
            KEY_MSG,
            KEY_FORWARD,
            KEY_CODE,
            KEY_PARENTS_ID
        }
        /// <summary>
        /// WareHouseStatus Description Description
        /// </summary>
        public enum WareHouseStockType
        {
            SOUND = 1,
            DAMAGE = 2,
            FULLY_DAMAGE = 3,
            Aesthetic_Defective = 4,
            Functional_Defective = 5,
        }
        public enum ProductTransaction
        {
            RECEIVE_FROM_SUPPLIER = 1,
            RECEIVE_FROM_ANOTHER_WAREHOUSE = 2,//4 become 2 when receive the product by the target warehouse
            TRANSFER = 3,
            ISSUE_TO_ANOTHER_WAREHOUSE = 4,//Stock in Transit
            INVOICE = 5,
            REVERSE_INVOICE = 6,
        }
        /// <summary>
        /// Product Heirarchy
        /// </summary>
        public enum ProductGroupType
        {
            ProductGroup = 1,
            MAG = 2,
            ASG = 3,
            AG = 4,
            Product = 5,
        }
        public enum HRPayrollOtherBenifitPaymentType
        {
            PaymentType = 1,
            PaymentName = 2,
        }
        public enum HROverTimeEmployee
        {
            Create = 1,
            Approved = 2,
        }
        public enum TPVATProductStatus
        {
            Inactive = 0,
            Active = 1
        }
        /// <summary>
        /// MapEmployeeType
        /// </summary>        
        public enum MapEmployeeType
        {
            ProductManager = 1,
            CategoryManager = 2,
        }

        /// <summary>
        /// MapEmployeeType
        /// </summary>        
        public enum MapGroupType
        {
            Brand = 1,
            MAG = 2,
        }

        /// <summary>
        /// Invoice Type
        /// </summary>
        public enum InvoiceType
        {
            CREDIT = 1,
            CASH = 2,
            REPLACEMENT = 3,
            EPS = 4,
            EASY_BUY = 5,
            CREDIT_REVERSE = 6,
            CASH_REVERSE = 7,
            REPLACEMENT_REVERSE = 8,
            EPS_REVERSE = 9,
            EASY_BUY_REVERSE = 10,
            REVERSE = 11,
            PRODUCT_RETURN = 12,
            IB_SERVICE_INVOICE = 13,
            CANCEL_INVOICE = 14,
            ISSUE_SALES_PROMOTION = 15,
            ISSUE_SALES_PROMOTION_REVERSE = 16,
            BREAKAGE_REPLACEMENT = 17,
        }
        /// <summary>
        /// Invoice Status
        /// </summary>
        public enum InvoiceStatus
        {
            All = -1,
            UNDELIVERED = 1,
            DELIVERED = 2,
            CANCEL = 3,
            REVERSE = 4,
            PENDING = 5, //complete after money transaction complete
            PROCESSING_DELIVERY = 6, //print delivery note to load goods to carrier
            PRODUCT_RETURN = 7,
            UNDELIVERED_DUE_TO_STOCK_LIMIT = 8,
        }

        /// <summary>
        /// Invoice ReverseStatus
        /// </summary>
        public enum ReverseStatus
        {
            Create = 1,
            Send_To_HO = 2,
            Recommended = 3,
            Approved = 4,
            Reject = 5,
            Reversed = 6,
        }

        /// <summary>
        /// Invoice Reverse StockType
        /// </summary>
        public enum StockType
        {
            Unused = 1,
            Used = 2
        }
        /// <summary>
        /// Market Heirarchy
        /// </summary>
        public enum MarketGroupType
        {
            Area = 1,
            Territory = 2,
        }
        /// <summary>


        /// Geo Location Heirarchy
        /// </summary>
        public enum GeoLocationType
        {
            District = 1,
            Thana = 2,
        }
        /// <summary>
        /// <summary>
        /// Geo Location Category
        /// </summary>
        public enum ThanaCategory
        {
            Outer = 1,
            Metro = 2,
        }
        /// <summary>
        /// ShowRoom Type
        /// </summary>
        public enum ShowRoomType
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
        }
        /// <summary>
        /// ShowRoom Type
        /// </summary>
        public enum DistanceType
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
        }
        /// <summary>
        /// Various Order Type
        /// </summary>
        public enum OrderType
        {
            CREDIT = 1,
            CASH = 2,
        }
        /// <summary>
        /// Various Order Status
        /// </summary>
        public enum OrderStatus
        {
            All = 0,
            Received = 1,
            Confirmed = 2,
            Pending = 3,
            Canceled = 4,
            Invoiced = 5,
            Reject_Due_To_Less_Credit = 6,
            Cancle_Due_To_Less_Stock = 7,

        }
        public enum AndroidOrderStatus
        {
            Incomplete = 0,
            Complete = 1,
        }
        public enum OrderStat
        {
            Received = 1,
            Confirmed = 2,
            Pending = 3,
            Canceled = 4,
            Invoiced = 5,
            Reject_Due_To_Less_Credit = 6,
            Cancle_Due_To_Less_Stock = 7,

        }
        /// <summary>
        /// Stock transaction item type
        /// </summary>
        public enum TransactionItemType
        {
            ADD = 1,
            Update = 2,
            Cancel = 3,
        }
        /// <summary>
        /// Differant Types of WarehouseType
        /// </summary>
        public enum WarehouseType
        {
            SYSTEM = 1,//if the is used by the system
            DISTRIBUTION = 2,//used by main distribution
            CHANNEL = 3,//used by channel
            SHOWROOM = 4, //showroom type warehouse
        }
        /// <summary>
        /// Channel Type
        /// </summary>
        public enum ChannelType
        {
            SYSTEM = 1,//if the is used by the system
            DISTRIBUTION = 2,//used by main distribution
            ACTUAL = 3,
        }


        /// <summary>
        /// Row Type
        /// </summary>
        public enum RowStatus
        {
            ADD = 1,
            UPDATE = 2,
            DELETE = 3,
            CANCEL = 4,
            CANCEL_AND_FREEZ = 5,//cancel before sent to remote location
            NOSTATUS = 6,
        }
        public enum Terminal
        {
            Head_Office = 1,
            Branch_Office = 2,
        }

        /// <summary>
        /// B2B CustomerEntry  POS
        /// </summary>
        public enum B2BCustomerStatus
        {
            Create = 1,
            Send_To_HO = 2,
            Approve_By_HO = 3,
            Reject = 4,
        }

        /// <summary>
        /// Row Type
        /// </summary>
        public enum RowType
        {
            SYSTEM = 1,
            USER_DEFINED = 2,
        }
        /// <summary>
        /// List of Loging Objects 
        /// </summary>
        public enum Objects
        {
            PRODUCT_TRANSACTION = 1,
            PRODUCT_INFO = 2,

        }
        /// <summary>
        /// Application Type
        /// </summary>
        public enum ApplicationType
        {
            WEB = 1,
            WINDOWS = 2,
            WEB_N_WINDOWS = 3,
        }
        /// <summary>
        /// 
        /// </summary>
        public enum MenuType
        {
            ReportGroup = 1,
            ToolStripOrMenu = 3,
            Buttton = 4,
        }

        /// <summary>
        /// PurchaseRequisition Status
        /// </summary>
        public enum PurchaseRequisitionStatus
        {
            All = -1,
            NOT_APPROVED = 0,
            APPROVED = 1,
            LC_OPENED = 2,
            RECEIVED = 3,
            CANCELED = 4,

        }

        public enum CommercialInvoiceStatus
        {
            INVOICE = 0,
            SHIPMENT = 1,
            RECEIVED_AT_PORT = 2,
            RECEIVED_AT_WH_PARTIAL = 3,
            RECEIVED_AT_WH_FULLY = 4,
            CANCELED = 5,
        }

        /// <summary>
        /// Email Type
        /// </summary>
        public enum EmailType
        {
            Individual = 0,
            Common = 1,
            Group = 2,
        }

        /// <summary>
        /// Email Status
        /// </summary>
        public enum EmailStatus
        {
            Submitted = 0,
            Created = 1,
            Blocked = 2,
            Deleted = 3,
        }

        /// <summary>
        /// IT Component
        /// </summary>
        public enum ITComponent
        {
            Laptop = 0,
            Desktop = 1,
            Printer = 2,
            Monitor = 3,
            UPS = 4,
            Internet = 5,
            Mouse = 6,
            Keyboard = 7,
            Modem = 8,
            Switch = 9,
            HDD = 10,
            ODD = 11,
            RAM = 12,
            Scanner = 13,
            TAB = 14,
        }

        /// <summary>
        /// IT Requisition Justification
        /// </summary>
        public enum ITJustification
        {
            NewlyJoined = 0,
            Outdated = 1,
            OutofOrder = 2,
            Stolen = 3,
            WillJoin = 4,
        }

        /// <summary>
        /// IT Requisition Status
        /// </summary>
        public enum ITReqStatus
        {
            Submitted = 0,
            Working = 1,
            Done = 2,
            Cancelled = 3,
        }

        /// <summary>
        /// IT Requisition Priority
        /// </summary>
        public enum ITReqPriority
        {
            Urgent = 0,
            High = 1,
            Mid = 2,
            Low = 3,
        }

        /// <summary>
        /// IT Equipment Stock 
        /// </summary>
        public enum ITEquipmentStock
        {
            MIS = 0,
            User = 1,
            Defective = 2,
            Repair = 3,
            Loan = 4,
        }
        /// <summary>
        /// IT Equipment System Stock 
        /// </summary>
        public enum ITEquipmentSystemStock
        {
            System = -1,

        }
        /// <summary>
        /// IT Equipment Stock 
        /// </summary>
        public enum ITEquipmentTranStatus
        {
            Stored = 0,
            Allotted = 1,
            Defective = 2,
            Discarded = 3,
        }
        /// <summary>
        /// Project Approval Type
        /// </summary>
        public enum ProjectType
        {
            New = 1,
            Old = 2,
        }

        public enum ProjectStatus
        {
            Create = 0,
            Planned = 1,
            Working = 2,
            Done = 3,
            Pending = 4,
            Cancelled = 5,
        }
        public enum ProjectSize
        {
            Small = 0,
            Medium = 1,
            Big = 2,

        }
        public enum ProjectPriority
        {
            High = 1,
            Medium = 2,
            Low = 3,
        }
        public enum ProjectResourceType
        {
            Own = 0,
            Third_Party = 1,
        }
        public enum ITProjectType
        {
            Android = 0,
            Desktop = 1,
            WEB = 2,
        }
        /// <summary>
        /// System for Project Approval
        /// </summary>
        public enum System
        {
            CasperJet = 1,
            MyCorner = 2,
        }

        /// <summary>
        /// Supplier Type
        /// </summary>
        public enum SupplierType
        {
            IT = 0,
            Commercial = 1,
            Corporate = 2,

        }
        public enum SupplierChaannelType
        {
            Others = 0,
            CAC = 1,

        }
        public enum ITEquipmentTranType
        {
            Purchase = 0,
            Assign_To_User = 1,
            Return_MIS = 2,
            Return_Supplier = 3,
            Get_back_Supplier = 4,
            Defect = 5,
            Repair = 6,
            Discard = 7,
            Stolen = 8,
        }

        ///====================================
        /// <summary>
        /// Enum of Human Resources System
        /// </summary>
        /// ===================================

        /// <summary>
        /// Employee Status
        /// </summary>
        public enum HREmployeeStatus
        {
            NotEmployed = 0,
            Contractual = 1,
            Confirmed = 2,
            Suspended = 3,
            Retired = 4,
            Resigned = 5,
            Cancelled = 6,
            Terminated = 7
        }

        public enum HRAssessmentStatus
        {
            Ready_To_Assess = 0,
            Create = 1,
            Submit = 2,
            Assessed = 3,
            Send_To_HRD = 4,
            Cancel = 5,
            FinalAssessed = 6,
        }

        public enum HREmployeeHistoryType
        {
            Company = 1,
            Department = 2,
            Designation = 3,
            Job_Grade = 4,
            Equivalent_Grade = 5,
            Location = 6,
            Shift = 7,
            Status = 8,
            Section = 9,
            BU = 10,
            OutletEmployeeType=11,
            ProductCategory=12
        }


        public enum Gender
        {
            Male = 1,
            Female = 2,
        }
        public enum HROutStationDuty
        {
            Create = 1,
            Approved = 2,
            Reject = 3,
        }

        /// <summary>
        /// Employee Floor
        /// </summary>
        public enum HREmployeeFloor
        {
            Ground_Floor = 0,
            Frist_Floor = 1,
            Second_Floor = 2,
            Third_Floor = 3,
            Forth_Floor = 4,
            Fifth_Floor = 5,
        }

        /// <summary>
        /// Employee Status
        /// </summary>
        public enum HRAttendanceStatus
        {
            Absent = 0,
            Present = 1,
            Late = 2,
            Holiday = 3,
            Leave = 4,
            OutStation = 5
        }

        public enum HRRecruitmentStatus
        {
            Create = 0,
            Approved = 1,
        }
        public enum HRCVStatus
        {
            Submit = 0,

        }

        /// <summary>
        /// HR Attendance Status For Outlet
        /// </summary>
        public enum HRAttendanceStatusForOutlet
        {
            Present = 1,
            Roster = 2,
            Leave = 3,
            OutStation = 4,
        }


        /// <summary>
        /// HR Check In & Out Status For Outlet
        /// </summary>
        public enum HRCheckStatusForOutlet
        {
            CheckIn = 1,
            CheckOut = 2,
        }

        /// <summary>
        /// HR OverTime Status
        /// </summary>
        public enum HROverTimeStatus
        {
            Create = 1,
            Approved = 2,
            Reject = 3,
        }
        public enum HRAssessmentType
        {
            Yearly = 1,
            Confirmation = 2,
        }

        public enum HRManpowerVacancyType
        {
            New = 0,
            Replacement = 1,
        }

        public enum HRManpowerPositionLevel
        {
            Manager = 0,
            Officer = 1,
            Supervisor = 2,
            Staff = 3,
            Casual = 4,
        }

        public enum HRManpowerAgeLevel
        {
            Eighteen_Plus = 0,
            Twenty_Plus = 1,
            TwentyFive_Plus = 2,
            Thirty_Plus = 3,
            Forty_Plus = 4,
            Fifty_Plus = 5,
        }
        public enum HRManpowerEmployeementType
        {
            Permanent = 0,
            Contractual = 1,
            Casual = 2,

        }

        public enum HRManpowerContractPeriod
        {
            Six_Months = 0,
            One_Year = 1,
            Others = 2,
            NA = 3,

        }
        public enum HRManpowerEmploymentStatus
        {
            Full_Time_Reglar = 0,
            Part_Time_Reglar = 1,
        }
        public enum HRManpowerEducationalQualification
        {
            Masters = 0,
            Bachelor = 1,
            Diploma = 1,
            Above_Five_Pass = 1,
        }
        public enum HRManpowerExperience
        {
            Ten_Year_Plus = 0,
            Five_Year_Plus = 1,
            Three_Year_Plus = 2,
            Fresh_Six_Month_Plus = 3,

        }





        /// <summary>
        /// Leave Type
        /// </summary>
        public enum LeaveType
        {
            Sick_Leave = 0,
            Earned_Leave = 1,
            Casual_Leave = 2,
            Maternity_Leave = 3,
            Paternity_Leave = 4,
            Leave_Without_Pay = 5,
        }

        public enum LeaveStatus
        {
            Applied = 1,
            Approved = 2,
            Reject = 3,
            Cancelled = 4,
            Acknowledged = 5,
            ReadyForApproved = 6,
        }
        public enum PartialTypeLeave
        {
            FullDay = 0,
            FirstHalf = 1,
            SecondHalf = 2,

        }
        public enum HRLoanStatus
        {
            Running = 1,
            Closed = 2,
        }
        public enum HRLoanType
        {
            Article = 1,
            BuildingOrCash = 2,
            SalaryAdvance = 3,
            Emergency = 4,
            ProvidentFund = 5,
        }
        public enum HRLoanArticle
        {
            AC = 1,
            TV = 2,
            REF = 3,
        }
        /// <summary>
        /// Half Day Leave
        /// </summary>
        public enum HalfDayLeave
        {
            NONE = 1,
            FIRST_HALF = 2,
            SECOND_HALF = 3
        }
        /// <summary>
        /// HR Relaym Status
        /// </summary>
        public enum HRRelayStatus
        {
            Active = 1,
            Inactive = 2
        }
        /// <summary>
        /// Medical Claim Type
        /// </summary>
        public enum MedicalClaimType
        {
            Medical_Allowance = 0,
            Hospitalization = 1
        }

        /// Allowance Deduction Type
        /// </summary>
        public enum AllowanceDeductionType
        {
            Add = 1,
            Deduct = 2,
        }
        /// <summary>
        /// Employee Allowance
        /// </summary>
        public enum HREmployeeAllowance
        {
            BasicSalary = 8, //Add
            ConsolidateSalary = 9, //Add
            HouseRent = 10, //Add
            CarAllowance = 11, //Add
            Conveyance = 12, //Add
            EntertainmentAllowance = 13, //Add
            FestivalBonus = 14, //Add
            SpecialAllowance = 15, //Add
            LFA = 16, //Add
            PF = 17, //Deduct
            PFLoan = 18, //Deduct
            ArticleLoanTV = 19, //Deduct
            ArticleLoanRef = 20, //Deduct
            ArticleLoanAC = 21, //Deduct
            EPSLoan = 22, //Deduct
            EmergencyLoan = 23, //Deduct
            CarLoan = 24, //Deduct
            NonRotatingShift = 25, //Add
            AITSalary = 26, //Deduct
            MobileBill = 27, //Deduct
            AdvanceSalary = 28, //Deduct
            OtherDeduction = 29, //Deduct
            MedicalAllowanceforStaff = 30, //Add
            OverTimeExpense = 31, //Add
            LunchExpense = 32, //Add
            NightShiftAllowance = 33, //Add
            ChildEducationAllowance = 34, //Add
            BuildingLoan = 35, //Deduct
            HouseMaintenance = 36, //Add
            Utilityexpense = 37, //Add
            Canteenexpense = 38, //Add
            Otherexpense = 39, //Add
            Driverexpense = 40, //Add
            Serventexpense = 41, //Add
            RotatingShift = 42, //Add


        }
        public enum MonthShortName
        {
            Jan = 1,
            Feb = 2,
            Mar = 3,
            Apr = 4,
            May = 5,
            Jun = 6,
            Jul = 7,
            Aug = 8,
            Sep = 9,
            Oct = 10,
            Nov = 11,
            Dec = 12,
        }
        public enum PayrollType
        {
            Officer = 1,
            Supervisor = 2,
            Staff = 3,
        }
        public enum PayrollStatus
        {
            Create = 1,
            Verify = 2,
            Approve = 3,
            Send_to_Accpac = 4,
            Post_at_Accpac = 5,
        }
        public enum PayrollSettings
        {
            FullSalary = 1,
            FestivalBonus = 2,
            LFA = 3,
            AREAR = 4,
        }
        public enum PayrollAddDeductStatus
        {
            Create = 1,
            Approve = 2,
        }
        /// Allowance Group Type
        /// </summary>
        public enum AllowanceGroupType
        {
            GrossSalary = 1,
            Deduction = 2,
            Expense = 3,
            Subsidy = 4,
        }

        public enum MobileSIMStatus
        {

            Active = 1,
            Inactive = 2,
            Personalized = 3,
        }
        public enum MobileCreaditLimitType
        {
            Limited = 1,
            Actual = 2
        }
        public enum MobileUserType
        {
            Employee = 1,
            NonEmployee = 2
        }
        public enum MobileSpecialUserCategory
        {
            DMS = 1,
            SA_JSA = 2,
            DMS_CNA = 3,
            DMS_TMO = 4
        }
        public enum MobileDeductApproveStatus
        {
            NotApplicable = 0,
            Pending = 1,
            Approved = 2,
            Rejected = 3,
            Partial = 4
        }
        public enum MobileBillStatus
        {
            Saved = 1,
            Unsaved = 2
        }

        public enum SimAssignFor
        {
            VoiceCall =1,
            InternetModem =2
        }

        public enum CONGradeID
        {
            CON_Officer = 83077,
            CON_Supervisor = 83101,
            CON_Staff = 83102,
        }

        public enum HRBaseStationType
        {
            HeadOfficer = 1,
            Field = 2,
        }

        public enum HRPositionMarketGroup
        {
            Area = 1,
            Territory = 2,
            Customer = 3,
        }

        //=====================================
        /// <summary>
        /// Product Filtering Criteria
        /// </summary>
        public enum OuletCatagory
        {
            A = 0,
            B = 1,
            C = 2,
            D = 3,
            SPC = 4
        }
        public enum OuletSubCatagory
        {
            Gold = 0,
            Silver = 1,
            Bronze = 2,
        }
        public enum DMSMarketType
        {
            General = 0,
            Mall = 1

        }
        /// <summary>
        ///Outlet Type
        /// </summary>
        public enum OutletType
        {
            Electric = 1,
            Grocery = 2,
            SuperMarket = 3,
            Hardware = 4,
            Others = 5
        }
        //=====================================
        /// <summary>
        /// DMS M Tran Type
        /// </summary>
        public enum DMSMTranType
        {
            Stock = 0,
            Sales = 1

        }
        //=====================================
        /// <summary>
        /// Ecommerce 
        /// </summary>
        public enum ECOrderStatus
        {
            Submitted = 1,
            Confirm_Stock_Outlet = 2,
            UnAvailable_Stock_Outlet = 3,
            Stock_to_be_Available_Within_2WD = 6,
            Stock_No_Longer_Available = 7,
            Stock_to_be_Available_later = 10,
            Order_Confirmation_from_Customer = 11,
            Pick_Up_DD_Extended = 12,
            Confirm_Payment = 4,
            Product_Delivered = 5,
            Happy_Call = 8,
            Cancel = 9

            //Submitted = 1,
            //Confirm_Stock_Outlet = 2,
            //UnAvailable_Stock_Outlet = 3,
            //Confirm_Payment = 4,
            //Product_Delivered = 5,
            //Confirm_Stock_HO = 6,
            //UnAvailable_Stock_HO = 7,
            //Happy_Call = 8,
            //Cancel = 9,

        }
        public enum ECommerceOrderStatus
        {
            Create = 1,
            Assigned = 2,
            Invoiced = 3,
            Cancel = 4
        }
        public enum ECommerceChallanStatus
        {
            Create = 1,
            Handedover_To_Delivery_Person = 2,
            Deliverded = 3,
            Cancel = 4
        }
        public enum ECommercePaymentType
        {
            PrePaid = 1,
            Cash_On_Delivery = 2
        }
        public enum ECProductAction
        {
            Product = 0,
            Price = 1,
            Stock = 2
        }
        public enum ECStatus
        {
            New = 0,
            Update = 1,
            Delete = 2,
        }
        public enum ECIsRead
        {
            No = 0,
            Yes = 1
        }
        public enum ECOPaymentMode
        {
            Electronic = 1,
            Cash = 2

        }
        public enum ECDeliveryMode
        {
            Store_Delivery = 1,
            Home_Delivery = 2
        }
        public enum SundryCustomerType
        {
            WebStoreCustomer = 1,
            RetailCustomer = 2,

        }

        public enum CommissionStatus
        {
            Create = 1,
            Approved = 2,

        }

        public enum DSRSalaryStatus
        {
            Create = 1,
            Approved = 2,

        }

        public enum SalesLeadStatus
        {
            Create = 0,
            Assign = 1,
            SalesExecuted = 2,
            Cancel = 3,
            Pending = 4,
            NotExecute = 5,
        }
        /// <summary>
        /// POS data transfer type
        /// </summary>

        public enum DataTransferType
        {
            Add = 1,
            Edit = 2,
            Delete = 3,

        }
        public enum IsDownload
        {
            No = 1,
            Yes = 2,
        }

        public enum CompanyLoanStatus
        {
            Create = 1,
            Running = 2,
            Settled = 3,
            Overdue = 4,
            Cancel = 5,
        }
        public enum CompanyLoanType
        {
            OBU_Upass = 1,
            LTR = 2,
            STL_Time = 3,
            Long_term = 4,
        }
        public enum CompanyLoanTranType
        {
            Receive = 1,
            Payment = 2,
            Interest = 3,
            QuarterEnd = 4,
        }
        //=====================================
        /// <summary>
        /// POS Requisition Status
        /// </summary>

        public enum StockRequisitionStatus
        {
            Create = 0,
            Send_To_HO = 1,
            Approve_By_HO = 2,
            Reject_By_HO = 3,
            Transfer_To_Branch = 4,
            Receive_At_Branch = 5,
            Receive_at_Logistics = 6,

        }
        public enum StockRequisitionType
        {
            Requisition = 0,
            ISGM = 1,
            Return_To_HO = 2,
            Send_To_CSD = 3
        }

        public enum SpOrderStatus
        {
            Create = 1,
            Approve  =2
        }
        public enum StockRequisitionUIControl
        {
            Stock_Requisition_Create = 0,
            ISGM_Create = 1,
            Return_To_HO_Create = 2,
            Send_To_CSD_Create = 3,
            Stock_Requisition_Receive = 4,
            ISGM_Receive = 5,
            Receive_at_CSD = 6,
            Return_To_HO_Receive = 7,
            ISGM_Authorization_at_HO = 8,
            Product_Transfer_to_Outlet = 9,
            Stock_Requisition_Authorization = 10,
            Send_To_CSD_Authorization = 11,
            Receive_at_HO_from_CSD = 12,
            Return_To_HO_Authorization = 13,
        }
        public enum ProductSerialStatus
        {
            Send_from_HO_to_Outlet = 0,
            Received_at_Outlet = 1,
            Send_from_Outlet_to_HO = 2,
            Received_at_HO = 3,
            Send_from_Outlet_to_Outlet = 4,
            Send_from_Outlet_CSD = 5,
            Receive_at_CSD = 6,
            Send_from_CSD_to_Outlet = 7,
            Send_from_CSD_to_HO = 8,
            Sold = 9,
            Defective = 10,
            Reject_tran_by_Management = 11,
            Booking = 12,
        }
        public enum SalesPromSlabDiscountType
        {
            None = 0,
            FlatAmount = 1,
            Parcent = 2,
        }


        public enum SalesPromOfferType
        {
            Product = 0,
            FlatAmount = 1,
            Parcent = 2,
            EMI = 3,
        }

        public enum PromoWarrantyStatus
        {
            Create = 1,
            Approved = 2,
            Reject = 3,
        }
        public enum PromoWarrantyFormType
        {
            Add = 1,
            Edit = 2,
            Approved = 3,
            Inactive = 4,
        }

        public enum PromoContributionType
        {
            Amount = 1,
            Parcent = 2,
        }
        public enum SalesPromStatus
        {
            Create = 0,
            Approved = 1,
        }

        //Old
        public enum ProductRequisitionStatus
        {
            Submitted = 0,
            Authorized = 1,
            Transfer_Out = 2,
            Transfer_Received = 3,
            Cancel = 4,
            ALL = 5,
        }
        /// <summary>
        /// POS ISGM Status
        /// </summary>

        public enum ProductISGMStatus
        {
            Submitted = 0,
            Authorized = 1,
            Send_By_FromWarehouse = 2,
            Received_By_ToWarehouse = 3,
            Cancel = 4,
            ALL = 5,
        }
        /// <summary>
        /// Sales Promotion Discount Type
        /// </summary>

        public enum SalesPromotionDiscountType
        {
            Percent = 1,
            Amount = 2,
            Product = 3,
        }
        public enum ConsumerPromotionProductGroupType
        {
            Product = 1,
            PG = 2,
            MAG = 3,
            ASG = 4,
            AG = 5,
        }
        /// <summary>
        /// POS ISGM Synch Type
        /// </summary>

        public enum ISGMTransferStatus
        {
            NotTransfer = 0,
            Submitted_ISGM_Transfer = 1,
            Cancel_ISGM_Transfer = 2,

        }
        /// <summary>
        /// Transfer Status To Cassiopeia
        /// </summary>

        public enum TransferStatus
        {
            NotTransfer = 0,
            RequisitionTransfer = 1,
            StockTransfer = 2,
            Transfer = 3,

        }
        /// <summary>
        /// Barcode Status
        /// </summary>

        public enum BarcodeStatus
        {
            Create = 1,
            Transfer = 2,
            Sale = 3,
            Request_For_ISGM = 4,
            ISGM = 5,
            Retrun_HO = 6,
            Return_CSD = 7,

        }
        /// <summary>
        /// Barcode Trantype
        /// </summary>

        public enum BarcodeTranType
        {
            Create = 1,
            Transfer = 2,
            Sale = 3,
            Request_For_ISGM = 4,
            ISGM = 5,
            Retrun_HO = 6,
            Return_CSD = 7,

        }
        /// <summary>
        /// Barcode Active
        /// </summary>
        public enum BarcodeIsActive
        {
            Active = 1,
            NotActive = 2,
            Lock = 3,
        }

        public enum VATPaidProductSerialStatus
        {
            Create = 1,
            Send_from_Outlet_to_HO = 2,
            Send_from_Outlet_to_Outlet = 4,
            Send_from_Outlet_CSD = 5,
            Sold = 9,
        }

        /// <summary>
        /// Payment Mode
        /// </summary>
        public enum PaymentMode
        {
            Cash = 1,
            Credit_Card = 2,
            Advance_Payment = 3,
            EPS = 4,
            Gift_Voucher = 5,
            Approve_Credit = 6,
            Holcim_Eid_Coupon = 7,
            Uttara_Motors_Gift_Voucher = 8,
            Sanmar_Gift_Voucher = 9,
            Dealer_Advance_Adjust = 10,
            Exchange_Offer = 11,
            Customer_BG = 12,
            Exchange_Offer_Money_Receipt = 13,
            ECommerce = 14,
            BKASH = 15,
            IPDC = 16,
            NEXUS_PAY = 17,
            IPAY = 18,
            E_Commerce = 19,
            CreditLimit = 20,

        }



        public enum PaymentModeType
        {
            Cash = 1,
            Card = 2,
            MobilePayment = 3,
            Credit = 4,
            Other = 5,

        }

        public enum IsActive
        {
            InActive = 0,
            Active = 1,
        }
        public enum EMIManagement
        {
            Pending = 0,
            Send_To_Bank = 1,
        }

        //public enum EMITenureStatus
        //{
        //    Create = 0,
        //    Approved = 1,
        //}


        /// <summary>
        /// Outlet Display Position Status 
        /// </summary>
        public enum DisplayPositionStatus
        {
            Blank = 0,
            Fill = 1,
        }
        /// <summary>
        /// Fixed Asset Transaction Type
        /// </summary>

        public enum FATransactionType
        {
            Purchase = 0,
            Transfer = 1,
            DefectOrRepair = 2,

        }
        /// <summary>
        /// CLP TranType 
        /// </summary>

        public enum CLPTranType
        {
            INVOICE = 1,
            REVERSE_INVOICE = 2,

        }
        /// <summary>
        /// Dealer order delivery point
        /// </summary>

        public enum DealerOrderDeliveryPoint
        {
            HO_Branch = 1,
            Outlet = 2,

        }
        /// <summary>
        /// Current Stock filtering Criteria
        /// </summary>
        public enum StockPositionFilteringCriteria
        {
            SelectedChannel_SelectedWarehouse = 1,
            SelectedChannel_ALLWarehouse = 2,
            AllChannel_ALLWarehouse = 3
        }
        /// <summary>
        /// Product Filtering Criteria
        /// </summary>
        public enum ProductFilteringCriteria
        {
            All = 0,
            Active = 1,
            Inactive = 2
        }
        public enum InvoiceSelectionCriteria
        {
            Between_Date = 1,
            BETWEEN_VAT_CHALLAN_NO = 2,
            BEWEEN_INVOICE_NO = 3,
            BY_CUSTOMER_ID = 4,
            ALL = 5,
            BEWEEN_INVOICE_ID = 6,
            VAT_AMOUNT = 7,
        }
        public enum ExpenseType
        {

            Others = 0,
            Fuel = 1,
            Repairing = 2,
            Traffice = 3,
        }

        /// <summary>
        /// EPS
        /// </summary>
        public enum EPSStatus
        {
            Running = 0,
            Closed = 1,
            EarlyClosed = 2,
            Reverse = 3,
        }
        public enum EPSIsDue
        {
            Yes = 0,
            No = 1,
        }
        public enum EPSIsEarlyClose
        {
            Yes = 1,
            No = 0,
        }
        public enum EPSEmployeeStatus
        {
            Regular = 0,
            TopManagement = 1,
            Resigned = 2,
        }

        public enum OutletEmployeeType
        {
            Manager = 1,
            Executive = 2,
            ShopAssistant = 3,
            SPC = 4,
            HPC = 5,
        }

        public enum ProductCategory
        {
            NA = 0,
            Electronics = 1,
            Appliances = 2,
            Mobile = 3,
        }

        /// <summary>
        /// CSD_Complain Management Criteria
        /// </summary>
        public enum ActionCriteria
        {
            Solved = 0,
            Under_Process = 1,
            MgtAction_DecisionReq = 2,
        }
        public enum SearchingCriteria
        {

            All = -1,
            Solved = 0,
            Under_Process = 1,
            MgtAction_DecisionReq = 2,
        }
        public enum AgainstWhom
        {

            Technician = 0,
            Sales_Personnel = 1,
            CallCenterAgent = 2,
            FrontDeskAgent = 3,
            ServiceExecutive_TD = 4,
            InterService = 5,
            ZonalSupervisor = 6,
            Management = 7,
            Marketting = 8,
            ReplacementTeam = 9,
            ProductTeam = 10,

        }
        public enum ComplainerType
        {
            Customer = 0,
            Dealer = 1,
            TranscomDigital = 2,
            CustomerReference = 3,
            TDSpecial = 4,
            Lighting = 5,

        }
        public enum ComplainType
        {
            Quality = 0,
            Commitment = 1,
            Dealings = 2,
            Performance = 3,
            Skill = 4,
            Price = 5,
            Bill = 6,
        }

        public enum Source
        {

            DuringInBoundCall = 0,
            DuringOutBoundCall = 1,
            DuringHappyCall = 2,
            By_Email = 3,

        }
        public enum ComplainCat_BeforeSale
        {

            Dealings = 0,
            HomeDelivery = 1,
            Demo_Install = 2,
            Product = 3,
            SalesTeam = 4,
            Campaign = 5,

        }
        public enum ComplainCat_AfterSale
        {

            HomeCall = 0,
            Walking = 1,
            Installation = 2,
            Others = 3,
            Claim = 4,
            Replacment = 5,


        }
        public enum ComplainHappyCall
        {
            All = -1,
            Satisfy = 0,
            Moderate = 1,
            Dissatisfy = 2,
            NotDone = 9,
        }
        public enum ComplainFurtherActionRequired
        {
            False = 0,
            True = 1,
        }
        public enum ComplainCetagory
        {
            BeforeSale = 1,
            AfterSale = 2,
        }

        public enum ComplainStatus
        {
            All = -1,
            Receive = 0,
            Assign = 1,
            //Action = 2,
            Solved = 5,
            UnderProcess = 6,
            MgtActionReq = 7,
            HappyCall = 3,
            Cancel = 4,
        }
        /// <summary>
        /// Warranty Parameter
        /// </summary>

        public enum IsPrintWarrantyCard
        {
            No = 0,
            Yes = 1,
        }
        public enum IsStoreBarcode
        {
            No = 0,
            Yes = 1,
        }
        public enum IsCurrent
        {
            No = 0,
            Yes = 1,
        }
        public enum WarratnyCardCustInfo
        {
            NoCustomer = 1,
            PrimaryCustomer = 2,
            SundryCustomer = 3,
        }

        /// <summary>
        /// CSD_Inquiry Management Criteria
        /// </summary>

        public enum InquiryType
        {
            Customer = 0,
            Dealer = 1,
            TranscomDigital = 2,
            CustomerReference = 3,
            ZonalSupervisor = 4,
            InterService = 5,
            Lighting = 6,
        }
        public enum IsWEBQuery
        {
            No = 0,
            Yes = 1,
        }
        public enum InquiryLvwTypes
        {
            InquiryCategory = 1,
            InqueryResponse = 2,
            InqueryReferOutlet = 3,
            InquerySaleNoExecuted = 4,
        }
        public enum InquiryCategoryBeforeSale
        {
            ProductInformation = 0,
            ProductPrice = 1,
            ProductAvailability = 2,
            ServiceAvailability = 3,
            Outletlocation_Contact = 4,
            ServiceTime_DayOff = 5,
            PromotionalActivity = 6,
            ServiceWarranty = 7,
            UnsoldDefectiveStatus = 8,
            ClaimSettlementInfo = 10,
            Others = 9,
        }
        public enum InquiryCategoryAfterSale
        {
            JobStatus = 0,
            HomeCallService_Schedule = 1,
            TP_AreaService = 2,
            IS_information = 3,
            Warranty_ServiceCharge = 4,
            PickUp_Drop = 5,
            BackUp_Support = 6,
            OfficeTiming = 7,
            SpareAvailability = 8,
            SparePrice = 9,
            Others = 10,
            CSDLocation = 11,
        }
        public enum ResponseType
        {
            No_Response = 0,
            Response = 1
        }
        public enum InquiryResponse
        {
            Yes = 0,
            Refer = 1,
        }
        public enum InquiryReferChannel
        {

            TD = 0,
            Dealer = 1,
            Lighting = 2,

        }
        public enum Solve
        {
            None = 0,
            InBoundCall = 1,
            OutBoundCall = 2,

        }
        public enum InquirySalesExecuated
        {
            Yes = 1,
            No = 2,
        }
        public enum InquirySalesNoExecuatedReason
        {

            NotInterested = 0,
            Price_Factor = 1,
            Colour_Size = 2,
            Unavailability = 3,
            LaterPlan = 4,
            Other = 5,

        }
        public enum InquiryCommunicationStatus
        {
            False = 0,
            True = 1,
        }

        /// <summary>
        /// CSD_Replace Management Criteria
        /// </summary>
        public enum ReplaceStatusCriteria
        {
            All = -1,
            Raise = 0,
            Approve = 1,
            DepositToLog = 2,
            IssueFromLog = 3,
            SentToCSD = 4,
            ReceiveAtCSD = 5,
            InformToCustomer = 6,
            Delivered = 7,
            PaperAcknowledge = 8,
            HappyCall = 9,
            Cancel = 10,
        }
        public enum ReplaceFromWH
        {
            CentralWH = 0,
            Showroom = 1,
        }
        public enum ReplaceModeofDelivery
        {
            WalkIn = 0,
            HomeDelivery = 1,
            ByCourier = 2,
            ByHW_Vehicle = 3,
        }
        public enum ReplacePapersLocation
        {
            Workshop = 0,
            Logistics = 1,
            SendToCSD = 2,
            ReceiveAtCSD = 3,
            ALL = 4,
        }
        public enum ReplaceReasonType
        {
            Technical_Supervisor = 1,
            Technical_Manager = 2,
            Customer_Service_Manager = 3,
            Head_of_Service = 4,
        }
        public enum JobPriority
        {
            General = 1,
            High = 2,
            Medium = 3,
            Urgent = 4,
        }
        public enum Channel
        {
            EnA_Distribution = 3,
            TD_Retail = 4,
            TD_Corporate = 5,
            B2B = 13,
            Head_Office = 97,
            ThirtPartyService = 98,
            Others = 99,
            
        }
        public enum FullProductOrAccessory
        {
            FullProduct = 1,
            Accessory = 2,
        }
        public enum CallType
        {
            GeneralCall = 1,
            ProactiveCall = 2,
            HappyCall = 3,
        }
        public enum CallCategory
        {
            InBoundCall = 1,
            OutBoundCall = 2,
        }
        public enum UnsoldOrCustomersProduct
        {
            Unsold_Product = 1,
            Customers_Product = 2,
        }

        public enum UnsoldDefectiveProductType
        {
            Aesthetic_Major = 1,
            Aesthetic_Minor = 2,
            Functional = 3,
            Both = 4
        }

        public enum POSUnsoldDefectiveProductType
        {
            Aesthetic = 1,
            Functional = 2,
        }
        public enum JobTransportation
        {
            CustomerOwn = 1,
            TELVehicle = 2,
            Courier = 3
        }
        public enum ProductLocation
        {
            At_FrontDesk = 1,
            Send_to_Workshop = 2,
            At_Workshop = 3,
            Send_to_FrontDesk = 4,
            Customers_House = 5
        }
        public enum ProductPhysicalLocation
        {
            CentralService = 1,
            OuterService = 2
        }
        public enum LiveDemoStatus
        {
            Stock = 1,
            Sold = 2
        }

        public enum ClaimType
        {
            Replacement = 1,
            KPI = 2,
            TP = 3,
            Others = 4
        }

        public enum LiveDemoInvStatus
        {
            Sold = 1,
            UnSold = 2
        }

        public enum OwnOrOtherTechnician
        {
            Own_Technician = 1,
            ThirdParty_Technician = 2
        }
        public enum CSDJobType
        {
            FullWarranty = 1,
            Paid = 2,
            ServiceWarranty = 3,
            ComponentWarranty = 4
        }
        public enum WarrantyClaimDistribution
        {
            No = 0,
            Yes = 1,
        }
        public enum CSDAccessories
        {
            Available = 1,
            Not_Available = 2,
            Na = 3,
        }
        public enum CSDFunctionalType
        {
            Ok = 1,
            Not_Ok = 2,
        }
        public enum CSDCartonCorkSheetType
        {
            Good = 1,
            Fair = 2,
            Poor = 3,
            Na=4,
        }
        public enum CSDTechnicalReportStockType
        {
            Stock =1,
            Discount = 2,
            Scrap = 3,
            Pending = 4,
        }
        public enum CSDTechnicianTransportationStatus
        {
            Create = 1,
            Cancel = 2,
            PartiallyApproved = 3,
            Approved = 4,
            Rejected = 5
        }


        public enum CSDTechnicianTransportationMode
        {
            Bus = 1,
            Uber = 2,
            CNG = 3,
        }
        public enum CSDBillStatus
        {
            Partial = 1,
            Paid = 2
        }
        public enum CSDTPBillStatus
        {
            Pending = 1,
            Paid = 2

        }
        public enum CSDJobBillStatus
        {
            Send = 0,
            Received = 1,
        }
        public enum CSDServiceChargeType
        {
            Service_Charge = 1,
            Inspection_Charge = 2,
            Installation_Charge = 3,
            Re_Installation_Charge = 4,
            Dismantling_Charge = 5
        }
        public enum ChallanCreateFrom
        {
            FrontDesk = 1,
            Workshop = 2,
        }
        public enum ProductMovementStatus
        {
            Create = 0,
            Send_to_Workshop = 1,
            Receive_at_Workshop = 2,
            Send_to_Front = 3,
            Receive_at_Front = 4,
            None = 9,
        }
        public enum JobStatus
        {
            WalkinJobCreated = 0,
            HomecallJobCreated = 1,
            InstallationJobCreated = 2,
            InterServiceJobCreated = 3,
            AssignedToTechnician = 4,
            Untouched = 5,
            WorkInProgress = 6,
            Estimated = 7,
            EstimateApproved = 8,
            EstimateNotApproved = 9,
            Critical = 10,
            Pending = 11,
            ReadyForTest = 12,
            Repaired = 13,
            Return = 14,
            Replace = 15,
            ReturnFromCustomer = 16,
            ServiceProvided = 17,
            TransportRequired = 18,
            ConvertedFromHomeCall = 19,
            Cancel = 20,

            //Only History Status Start
            ChangeTechnician = 21,
            SentToWorkshop = 22,
            ReceivedAtworkshop = 23,
            SentToFrontDesk = 24,
            ReceivedAtFrontDesk = 25,
            //Only History Status End

            ReadyForDelivery = 26,
            Delivered = 27
        }
        public enum JobStatusSub
        {
            Pending_for_Local_Parts = 1,
            Pending_for_Foreign_Parts = 2,
            Pending_for_Management_Decision = 3,
            Pending_for_Customer_Decision = 4,
            Scheduled = 5,
            Re_Scheduled = 6
        }
        public enum SMSModel
        {
            Late = 1,
            Absent = 2,
            Birthday = 3,
            BirthdayGroup = 4,
        }
        public enum CSDSMSModel
        {
            HCall_Install_AssignSchedule_Technician = 1,
            HCall_Install_AssignSchedule_Supervisor_TPTech_Job = 2,
            HCall_Install_AssignSchedule_Customer = 3,
            HCall_Install_AssignSchedule_Source = 4,
            HCall_Install_AssignSchedule_TPManager = 5,
            HCall_Install_AssignSchedule_Supervisor_OwnTech_Job = 6,
            HCall_Install_CreateJob_Customer = 7,
            HCall_Install_Assign_Re_Schedule_Customer = 8,
            WalkIn_HCall_EDD_Extention_Customer_Source = 9,
            WalkIn_HCall_EDD_ExtentionForParts_Customer_Source = 10,
            WalkIn_Replace_EDDExtention_Customer_Source = 11,
            WalkIn_HCall_Estimate_Confirmation_Customer = 12,
            WalkIn_HCall_Install_Bill_acknowledgement_Customer = 13,
            WalkIn_Delivery_Warranty_Product_Customer = 14,
            WalkIn_Delivery_Paid_Product_Customer = 15,
            WalkIn_Replace_Product_Delivery_Customer = 16,
            WalkIn_Return_Product_Delivery_Customer = 17,
            WalkIn_CreateJob_Customer_Source = 18,

            WalkIn_Assign_Only_Outer_Service_Technician = 19,
            WalkIn_Assign_Only_Outer_Service_TPManager = 20,
            WalkIn_Assign_Only_Outer_Service_Supervisor = 21

        }
        public enum TypeOfJobSMS
        {
            Installation_Schedule = 0,
            Installation_ReSchedule = 1,
            HomeCall_Schedule = 2,
            HomeCall_ReSchedule = 3,
            WalkIn_Estimated = 4,
            WalkIn_Receive = 5,
            WalkIn_RFD_Warranty = 6,//RFD=ReadyForDelivery
            WalkIn_RFD_Paid = 7,
            WalkIn_RFD_ServiceWarranty = 8,
            WalkIn_RFD_ComponentWarranty = 9,
            WalkIn_Return = 10,
            EDD_Extention = 11,
            InterServicePaidJob_ScheduleDateTime = 12,
            LongPending_RFD_7Days = 13,
            LongPending_RFD_14Days = 14,
            LongPending_RFD_21Days = 15,
            Replace_Product_EDD = 16,
            Replaced_Product_Delivery = 17,
            Vehicle_Schedule_ReSchedule = 18,
            Pending_Spare_Import = 19,
        }
        /// <summary>
        /// CSD_Spare Loan Status Criteria
        /// </summary>

        public enum SpareLoanStatus
        {
            Raise = 0,
            Approve = 1,
            ReceiveFromWH = 2,
            AddStock = 3,
            IssueAgainstJob = 4,
            AddSpareOrder = 5,
            ReceiveFromSupplier = 5,
            SpareReFixed = 5,
        }
        public enum SMSHistoryStatus
        {
            Create = 1,
            Send = 2,
            Problematic = 3,
            Resent = 4,
            Cancel = 5
        }
        /// <summary>
        /// CSD_Inter Service Paid Job
        /// </summary>

        public enum ISPaidJobStatus
        {
            All = -1,
            Receive = 0,
            Assign = 1,
            WorkInProgress = 2,
            ServiceProvided = 3,
            ConvertToCSDJob = 4,
            Pending = 5,
            Cancel = 6,
        }
        /// <summary>
        /// CSD_Technical Supervisor
        /// </summary>

        public enum SupervisorCategory
        {
            Electronics = 0,
            HomeAppliance = 1,
            Residential_AC = 2,
        }
        public enum SMSServerType
        {
            OwnServer = 1,
            ThirdPartyServer = 2,
        }
        public enum CSDMapping
        {
            TS_VS_IS = 0,
            POS_VS_IS = 1,
            Fault_VS_MajorFaultCate = 2,
            Spare_VS_MajorSpareCate = 3,
        }
        /// <summary>
        /// CSD_Technician Skill Type
        /// </summary>
        public enum CSDTechnicianSkillType
        {
            WorkTypeSkill = 1,
            BrandSkill = 2
        }


        /// <summary>
        /// CSD Technician Type
        /// </summary>
        public enum CSDTechnicianType
        {
            Own = 1,
            ThirdParty = 2
        }

        /// <summary>
        /// CSD Own Technician  Type
        /// </summary>
        public enum CSDOwnTechnicianType
        {
            Variable = 1,
            NonVariable = 2
        }
        public enum TechnicianWorkType
        {
            Installation = 1,
            Repair = 2
        }

        public enum CSDBackupProductTranType
        {
            Issue = 1,
            Return = 2
        }
        /// <summary>
        /// CSD_SMS
        /// </summary>

        public enum CSDSMSType
        {
            Installation_ScheduleDateTime = 0,
            Installation_ReScheduleDateTime = 1,
            HomeCall_ScheduleDateTime = 2,
            HomeCall_ReScheduleDateTime = 3,
            WalkIn_Estimated = 4,
            WalkIn_ReceiveByTELVehicle = 5,
            WalkIn_ReceiveByCourier = 6,
            WalkIn_ReadyForDelivery_FullWarranty = 7,
            WalkIn_ReadyForDelivery_Paid = 8,
            WalkIn_ReadyForDelivery_ServiceWarranty = 9,
            WalkIn_ReadyForReturn_Paid = 10,
            LongPending_ReadyForDelivery_7Days = 11,
            ExpectedDeliveryDateExtention = 12,
            InterServicePaidJob_ScheduleDateTime = 13,
            LongPending_ReadyForDelivery_14Days = 14,
            LongPending_ReadyForDelivery_21Days = 15,
            Replace_Expected_Feedback_Date = 16,
            Replaced_Product_Delivery_Info = 17,
            Vehicle_Schedule_ReSchedule = 18,
        }
        public enum CSDSMSStatus
        {
            UnSend = 0,
            Sent = 1,
            ReSent = 2,
            Cancel = 3,
            ReGenerate = 4,
        }
        public enum CSDSMSSvrStatus
        {
            Submitted = 1,
            Sent = 2,
            Failed = 3,
            Cancel = 4,
        }

        public enum IsHappyCall
        {
            No = 0,
            Yes = 1
        }
        public enum HaveBackupset
        {
            No = 0,
            Yes = 1
        }
        public enum CSDServiceType//should be deleted -- main enum ServiceType
        {
            WalkIn = 1,
            Home_Call = 2,
            Inter_Service = 3,
            Installation = 4
        }
        /// <summary>
        /// CJ.CSD
        /// </summary>
        public enum ServiceType
        {
            Walkin = 1,
            HomeCall = 2,
            //InterService = 3,
            Installation = 3,
        }
        public enum CSDIsWarantyValid
        {
            No = 0,
            Yes = 1
        }
        public enum CSDHappyCallStatus
        {
            Satisfy = 1,
            Moderate = 2,
            Dissatisfy = 3,
            NoResponse = 4,
            //BanForever = 5,
            CallBack = 5,
            NumBusy = 6,
            Switched_Off=7
        }

        public enum CSDMark
        {
            VeryDissatisfied_1 = 1,
            Dissatisfied_2 = 2,
            Natural_3 = 3,
            Satisfied_4 = 4,
            VerySatisfied_5 = 5,
            Yes = 6,
            No = 7,
            NA = 8

        }

        /// <summary>
        /// CSD_Vehicle Requisition
        /// </summary>

        public enum VehicleRequisitionType
        {
            PickUp = 1,
            Drop = 2,
        }
        public enum VehicleRequisitionStatus
        {
            Requisition = 0,
            Schedule = 1,
            ReSchedule = 2,
            Done = 3,
            Suspend = 4,
            Cancel = 5
        }
        public enum CSDTypeofVehicleforSchedule
        {
            CSD_CoveredVan = 0,
            CSD_MicroBus = 1,
            Log_Vehicle = 2,
            TD_Vehicle = 3,
            Admin_Vehicle = 4,
            Rental_Vehicle = 5,
            Others = 6
        }
        public enum CSDVehicleSchedulePendingReason
        {
            ScheduleNotMatched = 0,
            CustomerWillInfoLater = 1
        }
        /// <summary>
        /// CSD_Inter Service Spare Part Requisition
        /// </summary>

        public enum ISVRequisitionStatus
        {
            Receive = 0,
            Partial_Issue = 1,
            Full_Issue = 2,
            Suspend = 3,
            Cancel = 4,
            Pending = 5
        }
        public enum ISVRequisitionSubStatus
        {
            FromStock = 0,
            FromLoanSet = 1,
            LocalPurchase = 2,
            ForeignOrder = 3,
            LoanRequisition = 4,
            Suspend = 5,
            Rejected = 6
        }
        public enum ISVRequisitionDeliveryMode
        {
            ByCourier = 1,
            HandToHand = 2
        }
        public enum InterServiceGrade
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4
        }
        public enum InterServiceCategory
        {
            Electronics = 1,
            Appliances = 2,
            Both = 3,
            Aircondition = 4
        }
        public enum SparePartsGroupCategory
        {
            MainCategory = 1,
            SubCategory = 2
        }
        public enum StoreCategory
        {
            Parent = 1,
            Child = 2,
            Transaction = 3
        }
        public enum Store
        {
            SystemStore = -1,
            CentralSoundStore = 2
        }
        public enum SparePartTranType
        {
            SparePartReceive_GRD = 1,
            IssueAgainstJob = 2,
            ReturnFromJob = 3,
            SparePartSale = 4,
            AdvanceIssueToTechnician = 5,
            RetrunFormTechnician = 6,
            AddStock = 7,
            DeductStock = 8,
            ReturnDefectiveSpare = 9,
            IssueForScrapSale = 10,
            IssueInterServiceJob = 11,
            IssueToBranch = 12,
            ReturnFromBranch = 13,
            Transfer = 14,
            IssueToInternalParty = 15,
            ReturnToSuplier = 16,
            SparePartCreditSale = 17

        }
        public enum SparePartUSP
        {
            Manual = 1,
            Auto = 2
        }

        public enum SparePartTranStatus
        {
            Create = 1,
            Approved = 2,

        }
        public enum SparePartTranSide
        {
            IN = 1,
            OUT = 2,
            Other = 3,
        }
        /// <summary>
        /// CSD Parts Supplier Category
        /// </summary>

        public enum PartsSupplierCategory
        {
            Foreign = 0,
            Local = 1,
            Others = 2,
        }
        /// <summary>
        /// CSD Exchange Offer
        /// </summary>

        public enum ExchangeOfferStatus
        {
            Create = 0,
            Assign = 1,
            SalesExecuted = 2,
            Cancel = 3,

        }

        /// <summary>
        /// CSD Exchange Offer Deposit Type
        /// </summary>

        public enum ExchangeOfferDepositType
        {
            Vender_Deposit = 1,
            Fund_Transfer_Parent_To_Child = 2,
            Fund_Transfer_Child_To_Parent = 3,
            Money_Receipt = 4,

        }

        /// <summary>
        /// CSD Exchange Offer
        /// </summary>

        public enum ExchangeOfferHappyCall
        {
            YetToCall = 0,
            Executed = 1,
            NotExecuted = 2,

        }
        public enum ExchangeOfferStatusForCombo
        {
            Assign = 1,
            Suspend = 2,
            Exchanged = 3,
            NotExchange = 4,
            SalesExecuted = 5,
            Cancel = 6,
            HappyCall = 7,
        }
        public enum ExchangeOfferMRStatus
        {
            InActive = 0,
            Active = 1,
            Transfered = 2,
            SalesExecuted = 3,

        }

        public enum ExOType
        {
            Product = 0,
            NotHappyReason = 1,
        }
        public enum ExOVenderIsActive
        {
            False = 0,
            True = 1,
        }
        public enum ExchangeProduct
        {
            CTV = 0,
            HTV = 1,
            Refrigerator = 2,
            Freezer = 3,
            AC_Split = 4,
            AC_Window = 5,
        }
        public enum ExOIsExchange
        {
            NA = 0,
            No = 1,
            Yes = 2,
        }
        public enum ExOIsSaleExecuted
        {
            NA = 0,
            No = 1,
            Yes = 2,
        }
        public enum ExOHappyStatus
        {
            Happy = 0,
            Satisfy = 1,
            NotHappy = 2,
        }
        public enum ExONotExchangeReason
        {
            NA = 0,
            Price = 1,
            NotAgreed = 2,
        }
        public enum ExOHaveRemote
        {
            NA = 0,
            No = 1,
            Yes = 2,
        }
        public enum ExOProductCondition
        {
            Fucnctional = 0,
            Dead = 1,
        }
        public enum ExOContactMode
        {
            Call = 0,
            Walkin = 1,
        }

        public enum ExOVenderDepositType
        {
            SecurityDeposit = 0,
            PaymentReceive = 1,
        }
        public enum ExONotHappyReason
        {
            PriceIsNotAppropriate = 0,
            DelayInResponse = 1,
            CommunicationGap = 2,
            LackOfCommitment = 3,
        }
        public enum ExOMRStatus
        {
            Create = 0,
            Exchange = 1,
            Redeem = 2,
            Cancel = 3,
        }

        /// <summary>
        /// CSD Parts Cash Sale to Customer Or Inter service
        /// </summary>

        public enum CustOrISV
        {
            Customer = 1,
            InterService = 2,
        }

        public enum RouteType
        {

            Non_Cluster = 1,
            Cluster = 2,
            Institution = 3,
            Thana = 4,

        }
        public enum DmsOrderType
        {
            Order = 1,
            SpotSales = 2,
        }
        public enum ProductMovingType
        {
            Undefine = 0,
            Fast = 1,
            Slow = 2,
        }
        public enum DMSSecondarySalesOrderStatus
        {
            Submit = 0,
            Send_To_HO = 1,
            Approved_By_HO = 2,
            Reject_By_HO = 3,
            Partial_Invoiced = 4,
            Invoiced = 5,
        }

        public enum Designation
        {
            //SA = 1,
            //JSA = 2,
            //DSR = 3,
            //TSO = 4,

            ESO = 1,
            GSO = 2,
            SO = 3,
            DSR = 4,
            TSM = 5,
            SGSO = 6,
        }

        public enum OrderTakerTownType
        {
            Metro = 1,
            Urban = 2,
            Rural = 3,
            
        }

        public enum OrderTakerAccountType
        {
            //SA = 1,
            //JSA = 2,
            //DSR = 3,
            //TSO = 4,

            BKash = 1,
            DBBL = 2,
            Rocket = 3,

        }
        public enum GeoType
        {
            Thana = 1,
            Pourosova = 2,
            CityCorp = 3,
        }

        public enum DayID
        {
            Saturday = 1,
            Sunday = 2,
            Monday = 3,
            Tuesday = 4,
            Wednesday = 5,
            Thursday = 6,
        }
        public enum VisitdayID
        {
            Saturday = 1,
            Sunday = 2,
            Monday = 3,
            Tuesday = 4,
            Wednesday = 5,
            Thursday = 6,
        }

        public enum AndroidMenuType
        {
            MainMenu = 1,
            SubMenu = 2,
            Button = 3,
        }
        public enum AndroidAppID
        {
            CJ_Apps = 1,
            CJ_Digital = 2,
            CJ_Lighting = 3,
            E_Csd = 4,
            E_DMS = 5,
            CJ_FieldForce = 6,
            All = -9,
        }
        public enum AndroidAppRegStatus
        {
            Active = 1,
            InActive = 2,
        }
        public enum AndroidAppAuthenticateMode
        {
            IMEI = 1,
            SIMSerial = 2,
        }
        public enum EmployeeType
        {
            Regular = 1,
            Infra = 2,
        }
        public enum SAPaymentMode
        {
            Adjustment = 1,
            Bkash = 2,
            DBBL = 3,
        }
        public enum PaymentType
        {
            DB = 1,
            Bkash = 2,
            DBBL = 3,

        }
        public enum DesignationDSR
        {
            ESO = 1,
            GSO = 2,
            SO = 3,
            DSR = 4,
            TSM = 5,
            SGSO = 6,

        }

        public enum DayPlanStatus
        {
            Create = 1,
            Approve = 2,
            Reject = 3,
            Cancel = 4,
            Send_To_HO = 5
        }

        public enum SentFrom
        {
            Android = 1,
            Desktop = 2
        }


        public enum OfferTypeSC
        {
            Discount = 1,
            FreeProduct = 2,
            Both = 3
        }
        public enum HRAttendanceDataProcessLog
        {
            DataLoad = 1,
            DataProcess = 2
        }
        public enum ExchangeOfferDataType
        {
            ProductGroup = 1,
            Outlet = 2,
            Brand = 3
        }
        public enum ExchangeOfeerStatus
        {
            Create = 1,
            Approved = 2,
        }
        /// <summary>
        /// // Expense Head TypeID for Vehicle Management Module
        /// </summary>

        //public enum ReportType
        //{
        //    SKU_WISE = 1,
        //    AG_WISE = 2,
        //    ASG_WISE = 3,
        //    MAG_WISE = 4,
        //    PG_WISE = 5,
        //    SUPPLIER_WISE = 6,
        //    SBU_WISE = 7,
        //    CHANNEL_WISE = 8,
        //    AREA_WISE = 9,
        //    CUSTOMER_WISE = 10,
        //    TERRITORY_WISE = 11,
        //    BRAND_WISE = 12,
        //    BRAND_AND_ASG_WISE = 13,
        //    Central = 14,
        //    Warehouse_Location_Wise = 15,
        //}
        /// <summary>
        ///  Generic messages
        /// </summary>
        public static readonly string MSG_ITEMS_NOT_FOUND = "There is no items to show.";
        public static readonly string MSG_SAVE_CONFIRMATION = " Record saved successfully.";
        public static readonly string MSG_UPDATE_CONFIRMATION = "Record update successfully.";
        public static readonly string MSG_DELETE_CONFIRMATION = "Record delete successfully.";
        public static readonly string MSG_CREATE_CONFIRMATION = "Record Create successfully.";
        public static readonly string MSG_CANNOT_DELETE_FOR_HIARER_AND_LOWER_KEY = "Receord can not be deleted for it parents or child.";
        public static readonly string MSG_CANNOT_DELETE_FOR_ITS_TRANSECTION = "Receord can not be deleted for its Transection";
        public static readonly string MSG_DELETE_MISING = "There is no record for selected item to delete";
        public static readonly string MSG_UPDATE_MISING = "There is no record for selected item to Update";
        public static readonly string MSG_DUPLICATE_CODE = "is duplicate";
        /// <summary>
        ///  Data type format
        /// </summary>
        public static readonly string DATA_FORMAT_ORA_DATE = "dd-MMM-yyyy";
        public static readonly string DATA_FORMAT_ORA_MONTH = "MMM-yyyy";

        /// <summary>
        /// Specific error messages
        /// </summary>
        public static readonly string ERR_MSG_CONFIRM_PWD_MISMATCH = "Confirm password does not match.";
        public static readonly string ERR_MSG_CURRENT_PWD_MISMATCH = "Current password does not match your login password.";

        /// <summary>
        /// Data Error 
        /// </summary>
        public static readonly string ERR_MSG_TABLE_HAS_ERROR = "There was an error in the data table.";
        public static readonly string ERR_TABLE_HAS_ZERO_ROW = "There was no or zero data in the data table.";
        /// <summary>
        /// Developer error messages
        /// </summary>
        public static readonly string ERR_MSG_DATA_TYPE_MISMATCH = "Data type does not match.";
        public static readonly string ERR_MSG_DATA_MISSING = " is required.";
        public static readonly string ERR_MSG_STRING_TOO_LONG = "Input string is too long.";
        public static readonly string ERR_MSG_STRING_TOO_SHORT = "Input string is too short.";
        public static readonly string ERR_MSG_DUPLICATE_CODE = "Code already exist in the system.";
        public static readonly string ERR_MSG_DATA_NOT_FOUND = "Specified data does not exist in the system.";
        public static readonly string ERR_MSG_CODE_NOT_FOUND = "Specified code does not exist in the system.";
        public static readonly string ERR_MSG_INVALID_FORMAT = "Input format is invalid.";
        public static readonly string ERR_MSG_NUMBER_OUT_OF_RANGE = "Input number is out of range.";
        public static readonly string ERR_MSG_DATE_OUT_OF_RANGE = "Input date is out of range.";
        public static readonly string ERR_MSG_DATASET_NULL = " table not in Packet ";
        public static readonly string ERR_MSG_MISSING_ACTIONID = "Invalid Action Id.";
        public static readonly string ERR_MSG_UNSUP_ACTIONID = "Unsuported Action Id.";
        public static readonly string ERR_MSG_ERROR_IN_REPORT = "There is an Error during processing Report";


        /// <summary>
        /// Database Error Message 
        /// </summary>
        public static readonly string ERR_MSG_SEND_MSG_FAILED = "Message Cannot be send";
        public static readonly string ERR_MSG_DB_OP_FAILED = "Database operation failed.";
        public static readonly string ERR_MSG_DB_CONN_FAILED = "Database Connect Close or access dynied.\nPlease contact your system administrator";
        public static readonly string ERR_MSG_DB_TRAN_FAILED = "There was an error during process Transaction";
        public static readonly string ERR_MSG_DB_COMM_FAILED = "There was an error during commit Transction";
        public static readonly string ERR_MSG_DB_CLOSE_FAILED = "There was an error during close Connection";
        public static readonly string ERR_MSG_DB_OPEN_FAILED = "There was an error during open Connection";
        public static readonly string ERR_MSG_DB_ROLLBACK_FAILED = "There was an error during rollback Transaction";
        public static readonly string ERR_MSG_DB_FAILD_WIN = "There was an error during database operation. The details of the error can be found in log. You may contact your system addministrator ";
        public static readonly string ERR_MSG_DB_FAILD_WEB = "<p style=\"margin-top: 0; margin-bottom: 0\" align=\"center\"><b> " +
                                                                    "<font face=\"Verdana\" color=\"#FF0000\">There was an error during database " +
                                                                    "operation.</font></b></p>" +
                                                                    "<p style=\"margin-top: 0; margin-bottom: 0\" align=\"center\"><b>" +
                                                                    "<font face=\"Verdana\" color=\"#FF0000\">The detail of the error can be found in log " +
                                                                    "file.</font></b></p>" +
                                                                    "<p style=\"margin-top: 0; margin-bottom: 0\" align=\"center\"><b>" +
                                                                    "<font face=\"Verdana\" color=\"#FF0000\">You may contact your <i>System " +
                                                                    "Administrator</i> for help.</font></b></p>";



        /// <summary>
        /// Security Error Message
        /// </summary>
        public static readonly string ERR_MSG_ATHENTICATION_FAILD = "Invalid User ID or Password. Please try again";
        public static readonly string ERR_MSG_INVALID_PRIVILEGE_WIN = "Access denied. You have no permission to execute the action.";
        public static readonly string ERR_MSG_INVALID_PRIVILEGE_WEB = "<p align=\"center\"><font color=\"#FF0000\" face=\"Verdana\" size=\"2\"><i>Sorry</i>" +
                                                                  "Access denied. You have no permission to execute the action.</font></p>" +
                                                                  "<p align=\"center\"><font face=\"Verdana\" size=\"2\"><a href=\"javascript:history.back()\">Back</a></font></p>" +
                                                                  "<p align=\"center\"></p>";
        /// <summary>
        /// Regulare Expression
        /// </summary>
        public static readonly string REG_EX_CODE = @"^[\w_]{1,30}$";
        public static readonly string REG_EX_NAME = @"^[^*]+$";
        public static readonly string REG_EX_PERSON_NAME = @"^[\w-. ]{1,50}$";
        public static readonly string REG_EX_DESCRIPTION = "^[^*]{1,200}$";
        public static readonly string REG_EX_DECIMAL = "^[^*]+$";
        public static readonly string REG_EX_LONG = "^[0-9]{1,3}$";
        public static readonly string REG_EX_PHONE = "^[^*]+$";
        public static readonly string REG_EX_CELL_PHONE = "^[0-9]{1,20}$";
        public static readonly string REG_EX_ADDRESS = "^[^*]+$";
        public static readonly string REG_EX_FAX = @"^[^*]+$";
        public static readonly string REG_EX_EMAIL = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
        public static readonly string REG_EX_TEL_EMAIL = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public static readonly string REG_EX_URL = @"http://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?";


    }
}








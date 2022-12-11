// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Aug 03, 2015
// Time : 12:49 PM
// Description: Class for UnsoldDefectiveProduct.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Class
{
    public class UnsoldDefectiveProduct
    {
        SystemInfo oSystemInfo;
        private int _nDefectiveID;
        private string _sDefectiveNo;
        private int _nWarehouseID;
        private int _nProductID;
        private string _sBarcodeSL;
        private int _nDefectiveType;
        private string _sFault;
        private string _sReason;
        private object _sRemarks;
        private int _nStatus;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private string _sRefTranNo;
        private object _dRefTranDate;
        private object _ProposeDicAmount;
        private object _dtRefInvoiceDate;
        private object _sRefInvoiceNo;
        private string _sShowroomCode;
        private string _sProductCode;
        private string _sProductName;
        private string _sStatusName;
        private string _sStockStatusName;
        private string _sDefectiveTypeName;
        private string _sProductDescription;
        private string _sShowroomName;
        private object _nDefectiveCategory;
        private object _sAssessmentFindings;
        private object _nIsRepairable;
        private object _sAccessories;
        private object _sTechRecommandation;
        private object _sTechRemarks;
        private object _nIsLocallySaleable;
        private object _PaneltyAmount;

        private int _nWarehouseGroupID;
        private int _nWarehouseParentID;
        private int _nPGID;
        private int _nMAGID;
        private int _nASGID;
        private int _nAGID;
        private int _nBrandID;
        private string _sWarehouseGroupName;
        private string _sWarehouseParentName;
        private string _sWarehouse;
      
        private int _nOpeningStock;
        private double _fOpeningStockValue;
        private int _nTranStockIn;
        private int _nTranStockOut;
        private int _nClosingStock;
        private double _fClosingStockValue;
        private int _nCurrentStock;

        public int WarehouseGroupID
        {
            get { return _nWarehouseGroupID; }
            set { _nWarehouseGroupID = value; }
        }
        public int WarehouseParentID
        {
            get { return _nWarehouseParentID; }
            set { _nWarehouseParentID = value; }
        }
        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public int OpeningStock
        {
            get { return _nOpeningStock; }
            set { _nOpeningStock = value; }
        }
        public int TranStockIn
        {
            get { return _nTranStockIn; }
            set { _nTranStockIn = value; }
        }
        public int TranStockOut
        {
            get { return _nTranStockOut; }
            set { _nTranStockOut = value; }
        }
        public int ClosingStock
        {
            get { return _nClosingStock; }
            set { _nClosingStock = value; }
        }
        public int CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }

        public double OpeningStockValue
        {
            get { return _fOpeningStockValue; }
            set { _fOpeningStockValue = value; }
        }
        private double _InValue;
        public double InValue
        {
            get { return _InValue; }
            set { _InValue = value; }
        }
        private double _InVatAmount;
        public double InVatAmount
        {
            get { return _InVatAmount; }
            set { _InVatAmount = value; }
        }
        private double _OutValue;
        public double OutValue
        {
            get { return _OutValue; }
            set { _OutValue = value; }
        }
        private double _OutVatAmount;
        public double OutVatAmount
        {
            get { return _OutVatAmount; }
            set { _OutVatAmount = value; }
        }
        public double ClosingStockValue
        {
            get { return _fClosingStockValue; }
            set { _fClosingStockValue = value; }
        }
       
        public string WarehouseGroupName
        {
            get { return _sWarehouseGroupName; }
            set { _sWarehouseGroupName = value.Trim(); }
        }
        public string WarehouseParentName
        {
            get { return _sWarehouseParentName; }
            set { _sWarehouseParentName = value.Trim(); }
        }
        public string Warehouse
        {
            get { return _sWarehouse; }
            set { _sWarehouse = value.Trim(); }
        }

        private string _sOriginalSL;
        public string OriginalSL
        {
            get { return _sOriginalSL; }
            set { _sOriginalSL = value.Trim(); }
        }
        private string _sAGName;
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value.Trim(); }
        }
        private string _sASGName;
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value.Trim(); }
        }
        private string _sMAGName;
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }
        private string _sPGName;
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value.Trim(); }
        }
        private string _sBrandDesc;
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value.Trim(); }
        }
        // <summary>
        // Get set property for ProductID
        // </summary>
        public object ProposeDicAmount
        {
            get { return _ProposeDicAmount; }
            set { _ProposeDicAmount = value; }
        }


        // <summary>
        // Get set property for DefectiveID
        // </summary>
        public int DefectiveID
        {
            get { return _nDefectiveID; }
            set { _nDefectiveID = value; }
        }

        // <summary>
        // Get set property for BarcodeSL
        // </summary>
        public string DefectiveNo
        {
            get { return _sDefectiveNo; }
            set { _sDefectiveNo = value.Trim(); }
        }

        public object RefInvoiceNo
        {
            get { return _sRefInvoiceNo; }
            set { _sRefInvoiceNo = value; }
        }

        private object _dtApproveDate;
        public object ApproveDate
        {
            get { return _dtApproveDate; }
            set { _dtApproveDate = value; }
        }
        private object _nApproveBy;

        private double _CostPrice;
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }

        private double _NSP;
        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }

        private double _RSP;
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }

        private double _VAT;
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }

        private int _nIsPenaltyApplicable;
        public int IsPenaltyApplicable
        {
            get { return _nIsPenaltyApplicable; }
            set { _nIsPenaltyApplicable = value; }
        }

        private int _IsDefectiveAcknowledged;
        public int IsDefectiveAcknowledged
        {
            get { return _IsDefectiveAcknowledged; }
            set { _IsDefectiveAcknowledged = value; }
        }



        private string _sAcknowledgmentRemarks;
        public string AcknowledgmentRemarks
        {
            get { return _sAcknowledgmentRemarks; }
            set { _sAcknowledgmentRemarks = value; }
        }
        private int _FromWH;
        public int FromWH
        {
            get { return _FromWH; }
            set { _FromWH = value; }
        }
        private int _ToWH;
        public int ToWH
        {
            get { return _ToWH; }
            set { _ToWH = value; }
        }
        private object _ExpSalesDate;
        public object ExpSalesDate
        {
            get { return _ExpSalesDate; }
            set { _ExpSalesDate = value; }
        }

        



        private object _nIsLocallyRepaired;
        public object IsLocallyRepaired
        {
            get { return _nIsLocallyRepaired; }
            set { _nIsLocallyRepaired = value; }
        }
        private object _sRepairStatus;
        public object RepairStatus
        {
            get { return _sRepairStatus; }
            set { _sRepairStatus = value; }
        }
        public object ApproveBy
        {
            get { return _nApproveBy; }
            set { _nApproveBy = value; }
        }
        public object RefInvoiceDate
        {
            get { return _dtRefInvoiceDate; }
            set { _dtRefInvoiceDate = value; }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        // <summary>
        // Get set property for BarcodeSL
        // </summary>
        public string BarcodeSL
        {
            get { return _sBarcodeSL; }
            set { _sBarcodeSL = value.Trim(); }
        }



        // <summary>
        // Get set property for DefectiveType
        // </summary>
        public int DefectiveType
        {
            get { return _nDefectiveType; }
            set { _nDefectiveType = value; }
        }

        // <summary>
        // Get set property for Fault
        // </summary>
        public string Fault
        {
            get { return _sFault; }
            set { _sFault = value.Trim(); }
        }

        // <summary>
        // Get set property for Reason
        // </summary>
        public string Reason
        {
            get { return _sReason; }
            set { _sReason = value.Trim(); }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public object Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        private int _nStockStatus;
        public int StockStatus
        {
            get { return _nStockStatus; }
            set { _nStockStatus = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for StatusName
        // </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }

        public string StockStatusName
        {
            get { return _sStockStatusName; }
            set { _sStockStatusName = value.Trim(); }
        }

        public string DefectiveTypeName
        {
            get { return _sDefectiveTypeName; }
            set { _sDefectiveTypeName = value.Trim(); }
        }

        public string ProductDescription
        {
            get { return _sProductDescription; }
            set { _sProductDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for RefTranNo
        // </summary>
        public string RefTranNo
        {
            get { return _sRefTranNo; }
            set { _sRefTranNo = value.Trim(); }
        }

        private object _sJobNo;
        public object JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
        }
        private string _sIsCreateJob;
        public string IsCreateJob
        {
            get { return _sIsCreateJob; }
            set { _sIsCreateJob = value.Trim(); }
        }
        private object _ApproveDicAmount;
        public object ApproveDicAmount
        {
            get { return _ApproveDicAmount; }
            set { _ApproveDicAmount = value; }
        }
        private object _dtJobDate;
        public object JobDate
        {
            get { return _dtJobDate; }
            set { _dtJobDate = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public object RefTranDate
        {
            get { return _dRefTranDate; }
            set { _dRefTranDate = value; }
        }
        // <summary>
        // Get set property for ShowroomName
        // </summary>
        public string ShowroomName
        {
            get { return _sShowroomName; }
            set { _sShowroomName = value.Trim(); }
        }


        // <summary>
        // Get set property for DefectiveCategory
        // </summary>
        public object DefectiveCategory
        {
            get { return _nDefectiveCategory; }
            set { _nDefectiveCategory = value; }
        }

        // <summary>
        // Get set property for AssessmentFindings
        // </summary>
        public object AssessmentFindings
        {
            get { return _sAssessmentFindings; }
            set { _sAssessmentFindings = value; }
        }

        // <summary>
        // Get set property for IsRepairable
        // </summary>
        public object IsRepairable
        {
            get { return _nIsRepairable; }
            set { _nIsRepairable = value; }
        }

        // <summary>
        // Get set property for Accessories
        // </summary>
        public object Accessories
        {
            get { return _sAccessories; }
            set { _sAccessories = value; }
        }

        // <summary>
        // Get set property for TechRecommandation
        // </summary>
        public object TechRecommandation
        {
            get { return _sTechRecommandation; }
            set { _sTechRecommandation = value; }
        }

        // <summary>
        // Get set property for TechRemarks
        // </summary>
        public object TechRemarks
        {
            get { return _sTechRemarks; }
            set { _sTechRemarks = value; }
        }

        // <summary>
        // Get set property for IsLocallySaleable
        // </summary>
        public object IsLocallySaleable
        {
            get { return _nIsLocallySaleable; }
            set { _nIsLocallySaleable = value; }
        }

        // <summary>
        // Get set property for PaneltyAmount
        // </summary>
        public object PaneltyAmount
        {
            get { return _PaneltyAmount; }
            set { _PaneltyAmount = value; }
        }
        // <summary>
        // Get set property for ShowroomCode
        // </summary>
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }
        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }
        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        

        public void Add()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_UnsoldDefectiveProduct (DefectiveID,DefectiveNo, WarehouseID, ProductID, " +
                "BarcodeSL, DefectiveType, Fault, Reason, Remarks, ProposeDicAmount, Status, CreateUserID, CreateDate, RefTranNo, " +
                "RefTranDate, JobNo, ApproveDicAmount,ApproveBy,ApproveDate,RefInvoiceNo,RefInvoiceDate, DefectiveCategory,AssessmentFindings,IsRepairable,Accessories,TechRecommandation,TechRemarks,IsLocallySaleable,PaneltyAmount,IsLocallyRepaired,RepairStatus,  OriginalSL,IsPenaltyApplicable,IsDefectiveAcknowledged,AcknowledgmentRemarks,ExpSalesDate,FromWH,ToWH) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("DefectiveNo", _sDefectiveNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);
                cmd.Parameters.AddWithValue("JobNo", _sJobNo);

                cmd.Parameters.AddWithValue("ApproveDicAmount", _ApproveDicAmount);
                cmd.Parameters.AddWithValue("ApproveBy", _nApproveBy);
                cmd.Parameters.AddWithValue("ApproveDate", _dtApproveDate);
                if (RefInvoiceNo != null)
                    cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                else cmd.Parameters.AddWithValue("RefInvoiceNo", null);
                if (_dtRefInvoiceDate != null)
                    cmd.Parameters.AddWithValue("RefInvoiceDate", _dtRefInvoiceDate);
                else cmd.Parameters.AddWithValue("RefInvoiceDate", null);


                cmd.Parameters.AddWithValue("DefectiveCategory", _nDefectiveCategory);
                cmd.Parameters.AddWithValue("AssessmentFindings", _sAssessmentFindings);
                cmd.Parameters.AddWithValue("IsRepairable", _nIsRepairable);
                cmd.Parameters.AddWithValue("Accessories", _sAccessories);
                cmd.Parameters.AddWithValue("TechRecommandation", _sTechRecommandation);
                cmd.Parameters.AddWithValue("TechRemarks", _sTechRemarks);
                cmd.Parameters.AddWithValue("IsLocallySaleable", _nIsLocallySaleable);
                cmd.Parameters.AddWithValue("PaneltyAmount", _PaneltyAmount);
                cmd.Parameters.AddWithValue("IsLocallyRepaired", _nIsLocallyRepaired);
                cmd.Parameters.AddWithValue("RepairStatus", _sRepairStatus);
                //cmd.Parameters.AddWithValue("JobNo", _sJobNo);

                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                if (_nIsPenaltyApplicable != 0)
                    cmd.Parameters.AddWithValue("IsPenaltyApplicable", _nIsPenaltyApplicable);
                else cmd.Parameters.AddWithValue("IsPenaltyApplicable", null);
                if (_IsDefectiveAcknowledged != 0)
                    cmd.Parameters.AddWithValue("IsDefectiveAcknowledged", _IsDefectiveAcknowledged);
                else cmd.Parameters.AddWithValue("IsDefectiveAcknowledged", null);
                if (_sAcknowledgmentRemarks != "")
                    cmd.Parameters.AddWithValue("AcknowledgmentRemarks", _sAcknowledgmentRemarks);
                else cmd.Parameters.AddWithValue("AcknowledgmentRemarks", null);
                if (_ExpSalesDate != null)
                    cmd.Parameters.AddWithValue("ExpSalesDate", _ExpSalesDate);
                else cmd.Parameters.AddWithValue("ExpSalesDate", null);
                if (_FromWH != 0)
                    cmd.Parameters.AddWithValue("FromWH", _FromWH);
                else cmd.Parameters.AddWithValue("FromWH", null);
                if (_ToWH != 0)
                    cmd.Parameters.AddWithValue("ToWH", _ToWH);
                else cmd.Parameters.AddWithValue("ToWH", null);



                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddNew()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_UnsoldDefectiveProductNew (DefectiveID,DefectiveNo, WarehouseID, ProductID, " +
                "BarcodeSL, DefectiveType, Fault, Reason, Remarks, ProposeDicAmount, Status, CreateUserID, CreateDate, RefTranNo, " +
                "RefTranDate, JobNo, ApproveDicAmount,ApproveBy,ApproveDate,RefInvoiceNo,RefInvoiceDate, DefectiveCategory,AssessmentFindings,Accessories,TechRecommandation,TechRemarks,IsLocallySaleable,PaneltyAmount,  OriginalSL,IsPenaltyApplicable,IsDefectiveAcknowledged,AcknowledgmentRemarks,ExpSalesDate,FromWH,ToWH) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("DefectiveNo", _sDefectiveNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                if (_ApproveDicAmount != null)
                    cmd.Parameters.AddWithValue("ApproveDicAmount", _ApproveDicAmount);
                if (_nApproveBy != null)
                    cmd.Parameters.AddWithValue("ApproveBy", _nApproveBy);
                if (_dtApproveDate != null)
                    cmd.Parameters.AddWithValue("ApproveDate", _dtApproveDate);
                if (RefInvoiceNo != null)
                    cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                else cmd.Parameters.AddWithValue("RefInvoiceNo", null);
                if (_dtRefInvoiceDate != null)
                    cmd.Parameters.AddWithValue("RefInvoiceDate", _dtRefInvoiceDate);
                else cmd.Parameters.AddWithValue("RefInvoiceDate", null);

                if (_nDefectiveCategory != null)
                    cmd.Parameters.AddWithValue("DefectiveCategory", _nDefectiveCategory);
                if (_sAssessmentFindings != null)
                    cmd.Parameters.AddWithValue("AssessmentFindings", _sAssessmentFindings);
                if (_sAccessories != null)
                    cmd.Parameters.AddWithValue("Accessories", _sAccessories);
                if (_sTechRecommandation != null)
                    cmd.Parameters.AddWithValue("TechRecommandation", _sTechRecommandation);
                if (_sTechRemarks != null)
                    cmd.Parameters.AddWithValue("TechRemarks", _sTechRemarks);
                if (_nIsLocallySaleable != null)
                    cmd.Parameters.AddWithValue("IsLocallySaleable", _nIsLocallySaleable);
                if (_PaneltyAmount != null)
                    cmd.Parameters.AddWithValue("PaneltyAmount", _PaneltyAmount);
                if (_sJobNo != null)
                    cmd.Parameters.AddWithValue("JobNo", _sJobNo);

                if (_nIsPenaltyApplicable != 0)
                    cmd.Parameters.AddWithValue("IsPenaltyApplicable", _nIsPenaltyApplicable);
                else cmd.Parameters.AddWithValue("IsPenaltyApplicable", null);
                if (_IsDefectiveAcknowledged != 0)
                    cmd.Parameters.AddWithValue("IsDefectiveAcknowledged", _IsDefectiveAcknowledged);
                else cmd.Parameters.AddWithValue("IsDefectiveAcknowledged", null);
                if (_sAcknowledgmentRemarks != "")
                    cmd.Parameters.AddWithValue("AcknowledgmentRemarks", _sAcknowledgmentRemarks);
                else cmd.Parameters.AddWithValue("AcknowledgmentRemarks", null);
                if (_ExpSalesDate != null)
                    cmd.Parameters.AddWithValue("ExpSalesDate", _ExpSalesDate);
                else cmd.Parameters.AddWithValue("ExpSalesDate", null);
                if (_FromWH != 0)
                    cmd.Parameters.AddWithValue("FromWH", _FromWH);
                else cmd.Parameters.AddWithValue("FromWH", null);
                if (_ToWH != 0)
                    cmd.Parameters.AddWithValue("ToWH", _ToWH);
                else cmd.Parameters.AddWithValue("ToWH", null);



                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertDefectiveProduct()
        {
            int nMaxDefectiveID = 0;
            int nMaxNextDefectiveNo = 0;
            string sKeyWord = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([DefectiveID]) FROM t_UnsoldDefectiveProduct";
                cmd.CommandText = sSql;
                object MaxDefectiveID = cmd.ExecuteScalar();
                if (MaxDefectiveID == DBNull.Value)
                {
                    nMaxDefectiveID = 1;
                }
                else
                {
                    nMaxDefectiveID = int.Parse(MaxDefectiveID.ToString()) + 1;

                }
                _nDefectiveID = nMaxDefectiveID;

                string sShortCode = "";
                DateTime dOperationDate;

                oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();
                sShortCode = oSystemInfo.Shortcode;
                dOperationDate = Convert.ToDateTime(oSystemInfo.OperationDate);

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = " Select NextUnsoldDefectiveNo From t_NextNo ";
                sKeyWord = "UDM";

                cmd.CommandText = sSql;
                object MaxNextDefectiveNo = cmd.ExecuteScalar();
                if (MaxNextDefectiveNo == DBNull.Value)
                {
                    nMaxNextDefectiveNo = 1;
                }
                else
                {
                    nMaxNextDefectiveNo = int.Parse(MaxNextDefectiveNo.ToString());

                }

                _sDefectiveNo = sKeyWord + "-" + sShortCode + "-" + dOperationDate.Year.ToString() + "-" + nMaxNextDefectiveNo.ToString("0000");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_UnsoldDefectiveProduct (DefectiveID,DefectiveNo, WarehouseID, ProductID, BarcodeSL,OriginalSL, DefectiveType, Fault, Reason, Remarks, Status, CreateUserID, CreateDate, RefTranNo, RefTranDate , ProposeDicAmount) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;



                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("DefectiveNo", _sDefectiveNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);


                cmd.ExecuteNonQuery();
                cmd.Dispose();



                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_NextNo Set NextUnsoldDefectiveNo = ?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("NextUnsoldDefectiveNo", nMaxNextDefectiveNo + 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_UnsoldDefectiveProduct";
                oDataTran.DataID = Convert.ToInt32(_nDefectiveID);
                oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                if (oDataTran.CheckData() == false)
                {
                    oDataTran.AddForTDPOS();
                }



            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertDefectiveProductRT()
        {
            int nMaxDefectiveID = 0;
            int nMaxNextDefectiveNo = 0;
            string sKeyWord = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([DefectiveID]) FROM t_UnsoldDefectiveProduct where WarehouseID=" + Utility.WarehouseID + "";

                cmd.CommandText = sSql;
                object MaxDefectiveID = cmd.ExecuteScalar();
                if (MaxDefectiveID == DBNull.Value)
                {
                    nMaxDefectiveID = 1;
                }
                else
                {
                    nMaxDefectiveID = int.Parse(MaxDefectiveID.ToString()) + 1;

                }
                _nDefectiveID = nMaxDefectiveID;
                
                DateTime dOperationDate;

                dOperationDate =DateTime.Now.Date;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = " Select NextUnsoldDefectiveNo From t_Showroom where WarehouseID=" + Utility.WarehouseID + "";
                sKeyWord = "UDM";

                cmd.CommandText = sSql;
                object MaxNextDefectiveNo = cmd.ExecuteScalar();
                if (MaxNextDefectiveNo == DBNull.Value)
                {
                    nMaxNextDefectiveNo = 1;
                }
                else
                {
                    nMaxNextDefectiveNo = int.Parse(MaxNextDefectiveNo.ToString());

                }

                _sDefectiveNo = sKeyWord + "-" + Utility.Shortcode + "-" + dOperationDate.Year.ToString() + "-" + nMaxNextDefectiveNo.ToString("0000");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_UnsoldDefectiveProduct (DefectiveID,DefectiveNo, WarehouseID, ProductID, BarcodeSL,OriginalSL, DefectiveType, Fault, Reason, Remarks, Status, CreateUserID, CreateDate, RefTranNo, RefTranDate , ProposeDicAmount) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("DefectiveNo", _sDefectiveNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
                

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_Showroom Set NextUnsoldDefectiveNo = ? where WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("NextUnsoldDefectiveNo", nMaxNextDefectiveNo + 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                



            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertDefectiveProductForReverseInvoice(int nWarehouseID)
        {
            int nMaxDefectiveID = 0;
            int nMaxNextDefectiveNo = 0;
            string sKeyWord = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                string sShortCode = "";
                
                sShortCode = "HO";

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = " select max(DefectiveID) from t_UnsoldDefectiveProduct  where WarehouseID= "+nWarehouseID+"";
                sKeyWord = "UDM";

                cmd.CommandText = sSql;
                object MaxNextDefectiveNo = cmd.ExecuteScalar();
                if (MaxNextDefectiveNo == DBNull.Value)
                {
                    nMaxNextDefectiveNo = 1;
                }
                else
                {
                    nMaxNextDefectiveNo = int.Parse(MaxNextDefectiveNo.ToString())+1;

                }

                _sDefectiveNo = sKeyWord + "-" + sShortCode + "-" + DateTime.Today.Year.ToString() + "-" + nMaxNextDefectiveNo.ToString("0000");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_UnsoldDefectiveProduct (DefectiveID,DefectiveNo, WarehouseID, ProductID, BarcodeSL,OriginalSL, DefectiveType, Fault, Reason, Remarks, Status, CreateUserID, CreateDate, RefTranNo, RefTranDate , ProposeDicAmount, JobNo) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.AddWithValue("DefectiveID", nMaxNextDefectiveNo);
                cmd.Parameters.AddWithValue("DefectiveNo", _sDefectiveNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                cmd.Parameters.AddWithValue("JobNo", _sJobNo);


                cmd.ExecuteNonQuery();
                cmd.Dispose();



                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_UnsoldDefectiveProduct";
                oDataTran.DataID = Convert.ToInt32(nMaxNextDefectiveNo);
                oDataTran.WarehouseID = _nWarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;

                oDataTran.AddForTDPOS();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertDefectiveProductNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_UnsoldDefectiveProductNew (DefectiveID,DefectiveNo, WarehouseID, ProductID, BarcodeSL,OriginalSL, DefectiveType, Fault, Reason, Remarks, Status, CreateUserID, CreateDate, RefTranNo, RefTranDate , ProposeDicAmount, JobNo) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("DefectiveNo", _sDefectiveNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                cmd.Parameters.AddWithValue("JobNo", _sJobNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_UnsoldDefectiveProduct SET WarehouseID = ?, ProductID = ?, BarcodeSL = ?,OriginalSL=?,DefectiveType=?, Fault = ?, Reason = ?, Remarks = ?, Status = ?, CreateUserID = ?, CreateDate = ?, RefTranNo = ?,RefTranDate= ? WHERE DefectiveID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddForWeb()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_UnsoldDefectiveProduct (DefectiveID, DefectiveNo, WarehouseID, ProductID, BarcodeSL,DefectiveType, Fault, Reason, Remarks, ProposeDicAmount, Status, CreateUserID, CreateDate, RefTranNo, RefTranDate, JobNo, ApproveDicAmount, ApproveBy, ApproveDate, RefInvoiceNo, RefInvoiceDate, DefectiveCategory, AssessmentFindings, IsRepairable, Accessories, TechRecommandation, TechRemarks, IsLocallySaleable, PaneltyAmount, IsLocallyRepaired, RepairStatus,OriginalSL, IsPenaltyApplicable,IsDefectiveAcknowledged,AcknowledgmentRemarks,ExpSalesDate,FromWH,ToWH) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("DefectiveNo", _sDefectiveNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);

                if (_sJobNo != null)
                    cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                else cmd.Parameters.AddWithValue("JobNo", null);
                if (_ApproveDicAmount != null)
                    cmd.Parameters.AddWithValue("ApproveDicAmount", _ApproveDicAmount);
                else cmd.Parameters.AddWithValue("ApproveDicAmount", null);
                if (_nApproveBy != null)
                    cmd.Parameters.AddWithValue("ApproveBy", _nApproveBy);
                else cmd.Parameters.AddWithValue("ApproveBy", null);
                if (_dtApproveDate != null)
                    cmd.Parameters.AddWithValue("ApproveDate", _dtApproveDate);
                else cmd.Parameters.AddWithValue("ApproveDate", null);
                if (_sRefInvoiceNo != null)
                    cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                else cmd.Parameters.AddWithValue("RefInvoiceNo", null);
                if (_dtRefInvoiceDate != null)
                    cmd.Parameters.AddWithValue("RefInvoiceDate", _dtRefInvoiceDate);
                else cmd.Parameters.AddWithValue("RefInvoiceDate", null);
                if (_nDefectiveCategory != null)
                    cmd.Parameters.AddWithValue("DefectiveCategory", _nDefectiveCategory);
                else cmd.Parameters.AddWithValue("DefectiveCategory", null);
                if (_sAssessmentFindings != null)
                    cmd.Parameters.AddWithValue("AssessmentFindings", _sAssessmentFindings);
                else cmd.Parameters.AddWithValue("AssessmentFindings", null);
                if (_nIsRepairable != null)
                    cmd.Parameters.AddWithValue("IsRepairable", _nIsRepairable);
                else cmd.Parameters.AddWithValue("IsRepairable", null);
                if (_sAccessories != null)
                    cmd.Parameters.AddWithValue("Accessories", _sAccessories);
                else cmd.Parameters.AddWithValue("Accessories", null);
                if (_sTechRecommandation != null)
                    cmd.Parameters.AddWithValue("TechRecommandation", _sTechRecommandation);
                else cmd.Parameters.AddWithValue("TechRecommandation", null);
                if (_sTechRemarks != null)
                    cmd.Parameters.AddWithValue("TechRemarks", _sTechRemarks);
                else cmd.Parameters.AddWithValue("TechRemarks", null);
                if (_nIsLocallySaleable != null)
                    cmd.Parameters.AddWithValue("IsLocallySaleable", _nIsLocallySaleable);
                else cmd.Parameters.AddWithValue("IsLocallySaleable", null);
                if (_PaneltyAmount != null)
                    cmd.Parameters.AddWithValue("PaneltyAmount", _PaneltyAmount);
                else cmd.Parameters.AddWithValue("PaneltyAmount", null);
                if (_nIsLocallyRepaired != null)
                    cmd.Parameters.AddWithValue("IsLocallyRepaired", _nIsLocallyRepaired);
                else cmd.Parameters.AddWithValue("IsLocallyRepaired", null);
                if (_sRepairStatus != null)
                    cmd.Parameters.AddWithValue("RepairStatus", _sRepairStatus);
                else cmd.Parameters.AddWithValue("RepairStatus", null);
                if (_sOriginalSL != null)
                    cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                else cmd.Parameters.AddWithValue("OriginalSL", null);
                if (_nIsPenaltyApplicable != 0)
                    cmd.Parameters.AddWithValue("IsPenaltyApplicable", _nIsPenaltyApplicable);
                else cmd.Parameters.AddWithValue("IsPenaltyApplicable", null);
                if (_IsDefectiveAcknowledged != 0)
                    cmd.Parameters.AddWithValue("IsDefectiveAcknowledged", _IsDefectiveAcknowledged);
                else cmd.Parameters.AddWithValue("IsDefectiveAcknowledged", null);
                if (_sAcknowledgmentRemarks != null)
                    cmd.Parameters.AddWithValue("AcknowledgmentRemarks", _sAcknowledgmentRemarks);
                else cmd.Parameters.AddWithValue("AcknowledgmentRemarks", null);
                if (_ExpSalesDate != null)
                    cmd.Parameters.AddWithValue("ExpSalesDate", _ExpSalesDate);
                else cmd.Parameters.AddWithValue("ExpSalesDate", null);
                if (_FromWH != null)
                    cmd.Parameters.AddWithValue("FromWH", _FromWH);
                else cmd.Parameters.AddWithValue("FromWH", null);
                if (_ToWH != null)
                    cmd.Parameters.AddWithValue("ToWH", _ToWH);
                else cmd.Parameters.AddWithValue("ToWH", null);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddForWebNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_UnsoldDefectiveProductNew (DefectiveID, DefectiveNo, WarehouseID, ProductID, BarcodeSL,DefectiveType, Fault, Reason, Remarks, ProposeDicAmount, Status, CreateUserID, CreateDate, RefTranNo, RefTranDate, JobNo, ApproveDicAmount, ApproveBy, ApproveDate, RefInvoiceNo, RefInvoiceDate, DefectiveCategory, AssessmentFindings, Accessories, TechRecommandation, TechRemarks, IsLocallySaleable, PaneltyAmount, OriginalSL, IsPenaltyApplicable,IsDefectiveAcknowledged,AcknowledgmentRemarks,ExpSalesDate,FromWH,ToWH) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("DefectiveNo", _sDefectiveNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);

                if (_sJobNo != null)
                    cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                else cmd.Parameters.AddWithValue("JobNo", null);
                if (_ApproveDicAmount != null)
                    cmd.Parameters.AddWithValue("ApproveDicAmount", _ApproveDicAmount);
                else cmd.Parameters.AddWithValue("ApproveDicAmount", null);
                if (_nApproveBy != null)
                    cmd.Parameters.AddWithValue("ApproveBy", _nApproveBy);
                else cmd.Parameters.AddWithValue("ApproveBy", null);
                if (_dtApproveDate != null)
                    cmd.Parameters.AddWithValue("ApproveDate", _dtApproveDate);
                else cmd.Parameters.AddWithValue("ApproveDate", null);
                if (_sRefInvoiceNo != null)
                    cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                else cmd.Parameters.AddWithValue("RefInvoiceNo", null);
                if (_dtRefInvoiceDate != null)
                    cmd.Parameters.AddWithValue("RefInvoiceDate", _dtRefInvoiceDate);
                else cmd.Parameters.AddWithValue("RefInvoiceDate", null);
                if (_nDefectiveCategory != null)
                    cmd.Parameters.AddWithValue("DefectiveCategory", _nDefectiveCategory);
                else cmd.Parameters.AddWithValue("DefectiveCategory", null);
                if (_sAssessmentFindings != null)
                    cmd.Parameters.AddWithValue("AssessmentFindings", _sAssessmentFindings);
                else cmd.Parameters.AddWithValue("AssessmentFindings", null);
                
                if (_sAccessories != null)
                    cmd.Parameters.AddWithValue("Accessories", _sAccessories);
                else cmd.Parameters.AddWithValue("Accessories", null);
                if (_sTechRecommandation != null)
                    cmd.Parameters.AddWithValue("TechRecommandation", _sTechRecommandation);
                else cmd.Parameters.AddWithValue("TechRecommandation", null);
                if (_sTechRemarks != null)
                    cmd.Parameters.AddWithValue("TechRemarks", _sTechRemarks);
                else cmd.Parameters.AddWithValue("TechRemarks", null);
                if (_nIsLocallySaleable != null)
                    cmd.Parameters.AddWithValue("IsLocallySaleable", _nIsLocallySaleable);
                else cmd.Parameters.AddWithValue("IsLocallySaleable", null);
                if (_PaneltyAmount != null)
                    cmd.Parameters.AddWithValue("PaneltyAmount", _PaneltyAmount);
                else cmd.Parameters.AddWithValue("PaneltyAmount", null);
               
                if (_sOriginalSL != null)
                    cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                else cmd.Parameters.AddWithValue("OriginalSL", null);
                if (_nIsPenaltyApplicable != 0)
                    cmd.Parameters.AddWithValue("IsPenaltyApplicable", _nIsPenaltyApplicable);
                else cmd.Parameters.AddWithValue("IsPenaltyApplicable", null);
                if (_IsDefectiveAcknowledged != 0)
                    cmd.Parameters.AddWithValue("IsDefectiveAcknowledged", _IsDefectiveAcknowledged);
                else cmd.Parameters.AddWithValue("IsDefectiveAcknowledged", null);
                if (_sAcknowledgmentRemarks != null)
                    cmd.Parameters.AddWithValue("AcknowledgmentRemarks", _sAcknowledgmentRemarks);
                else cmd.Parameters.AddWithValue("AcknowledgmentRemarks", null);
                if (_ExpSalesDate != null)
                    cmd.Parameters.AddWithValue("ExpSalesDate", _ExpSalesDate);
                else cmd.Parameters.AddWithValue("ExpSalesDate", null);
                if (_FromWH != 0)
                    cmd.Parameters.AddWithValue("FromWH", _FromWH);
                else cmd.Parameters.AddWithValue("FromWH", null);
                if (_ToWH != 0)
                    cmd.Parameters.AddWithValue("ToWH", _ToWH);
                else cmd.Parameters.AddWithValue("ToWH", null);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditStatusForDatatransfer()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_UnsoldDefectiveProduct SET DefectiveNo = ?, ProductID = ?, BarcodeSL = ?, " +
                       "DefectiveType = ?, Fault = ?, Reason = ?, Remarks = ?, ProposeDicAmount = ?, Status = ?, "+
                       "CreateUserID = ?, CreateDate = ?, RefTranNo = ?, RefTranDate = ?, JobNo = ?, ApproveDicAmount = ?, "+
                       "ApproveBy = ?, ApproveDate = ?, RefInvoiceNo = ?, RefInvoiceDate = ?, DefectiveCategory = ?,  "+
                       "AssessmentFindings = ?, IsRepairable = ?, Accessories = ?, TechRecommandation = ?, "+
                       "TechRemarks = ?, IsLocallySaleable = ?, PaneltyAmount = ?,IsLocallyRepaired = ?, RepairStatus = ?,OriginalSL=?,IsPenaltyApplicable=?,IsDefectiveAcknowledged=?,AcknowledgmentRemarks=?,ExpSalesDate=?,FromWH=?,ToWH=? WHERE DefectiveID = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DefectiveNo", _sDefectiveNo);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                if (_sRemarks != null)
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                else cmd.Parameters.AddWithValue("Remarks", null);
                if (_ProposeDicAmount != null)
                    cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                else cmd.Parameters.AddWithValue("ProposeDicAmount", null);          
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);
                if (_sJobNo != null)
                    cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                else cmd.Parameters.AddWithValue("JobNo", null);
                if (_ApproveDicAmount != null)
                    cmd.Parameters.AddWithValue("ApproveDicAmount", _ApproveDicAmount);
                else cmd.Parameters.AddWithValue("ApproveDicAmount", null);
                if (_nApproveBy != null)
                    cmd.Parameters.AddWithValue("ApproveBy", _nApproveBy);
                else cmd.Parameters.AddWithValue("ApproveBy", null);
                if (_dtApproveDate != null)
                    cmd.Parameters.AddWithValue("ApproveDate", _dtApproveDate);
                else cmd.Parameters.AddWithValue("ApproveDate", null);
                if (_sRefInvoiceNo != null)
                    cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                else cmd.Parameters.AddWithValue("RefInvoiceNo", null);
                if (_dtRefInvoiceDate != null)
                    cmd.Parameters.AddWithValue("RefInvoiceDate", _dtRefInvoiceDate);
                else cmd.Parameters.AddWithValue("RefInvoiceDate", null);
                if (_nDefectiveCategory != null)
                    cmd.Parameters.AddWithValue("DefectiveCategory", _nDefectiveCategory);
                else cmd.Parameters.AddWithValue("DefectiveCategory", null);
                if (_sAssessmentFindings != null)
                    cmd.Parameters.AddWithValue("AssessmentFindings", _sAssessmentFindings);
                else cmd.Parameters.AddWithValue("AssessmentFindings", null);
                if (_nIsRepairable != null)
                    cmd.Parameters.AddWithValue("IsRepairable", _nIsRepairable);
                else cmd.Parameters.AddWithValue("IsRepairable", null);
                if (_sAccessories != null)
                    cmd.Parameters.AddWithValue("Accessories", _sAccessories);
                else cmd.Parameters.AddWithValue("Accessories", null);
                if (_sTechRecommandation != null)
                    cmd.Parameters.AddWithValue("TechRecommandation", _sTechRecommandation);
                else cmd.Parameters.AddWithValue("TechRecommandation", null);
                if (_sTechRemarks != null)
                    cmd.Parameters.AddWithValue("TechRemarks", _sTechRemarks);
                else cmd.Parameters.AddWithValue("TechRemarks", null);
                if (_nIsLocallySaleable != null)
                    cmd.Parameters.AddWithValue("IsLocallySaleable", _nIsLocallySaleable);
                else cmd.Parameters.AddWithValue("IsLocallySaleable", null);
                if (_PaneltyAmount != null)
                    cmd.Parameters.AddWithValue("PaneltyAmount", _PaneltyAmount);
                else cmd.Parameters.AddWithValue("PaneltyAmount", null);
                if (_nIsLocallyRepaired != null)
                    cmd.Parameters.AddWithValue("IsLocallyRepaired", _nIsLocallyRepaired);
                else cmd.Parameters.AddWithValue("IsLocallyRepaired", null);
                if (_sRepairStatus != null)
                    cmd.Parameters.AddWithValue("RepairStatus", _sRepairStatus);
                else cmd.Parameters.AddWithValue("RepairStatus", null);
                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                cmd.Parameters.AddWithValue("IsPenaltyApplicable", _nIsPenaltyApplicable);
                cmd.Parameters.AddWithValue("IsDefectiveAcknowledged", _IsDefectiveAcknowledged);
                cmd.Parameters.AddWithValue("AcknowledgmentRemarks", _sAcknowledgmentRemarks);
                cmd.Parameters.AddWithValue("ExpSalesDate", _ExpSalesDate);
                cmd.Parameters.AddWithValue("FromWH", _FromWH);
                cmd.Parameters.AddWithValue("ToWH", _ToWH);

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditStatusForDatatransferNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_UnsoldDefectiveProductNew SET DefectiveNo = ?, ProductID = ?, BarcodeSL = ?, " +
                       "DefectiveType = ?, Fault = ?, Reason = ?, Remarks = ?, ProposeDicAmount = ?, Status = ?, " +
                       "CreateUserID = ?, CreateDate = ?, RefTranNo = ?, RefTranDate = ?, JobNo = ?, ApproveDicAmount = ?, " +
                       "ApproveBy = ?, ApproveDate = ?, RefInvoiceNo = ?, RefInvoiceDate = ?, DefectiveCategory = ?,  " +
                       "AssessmentFindings = ?,  Accessories = ?, TechRecommandation = ?, " +
                       "TechRemarks = ?, IsLocallySaleable = ?, PaneltyAmount = ?,OriginalSL=?,IsPenaltyApplicable=?,IsDefectiveAcknowledged=?,AcknowledgmentRemarks=?,ExpSalesDate=?,FromWH=?,ToWH=? WHERE DefectiveID = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DefectiveNo", _sDefectiveNo);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                if (_sRemarks != null)
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                else cmd.Parameters.AddWithValue("Remarks", null);
                if (_ProposeDicAmount != null)
                    cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                else cmd.Parameters.AddWithValue("ProposeDicAmount", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);
                if (_sJobNo != null)
                    cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                else cmd.Parameters.AddWithValue("JobNo", null);
                if (_ApproveDicAmount != null)
                    cmd.Parameters.AddWithValue("ApproveDicAmount", _ApproveDicAmount);
                else cmd.Parameters.AddWithValue("ApproveDicAmount", null);
                if (_nApproveBy != null)
                    cmd.Parameters.AddWithValue("ApproveBy", _nApproveBy);
                else cmd.Parameters.AddWithValue("ApproveBy", null);
                if (_dtApproveDate != null)
                    cmd.Parameters.AddWithValue("ApproveDate", _dtApproveDate);
                else cmd.Parameters.AddWithValue("ApproveDate", null);
                if (_sRefInvoiceNo != null)
                    cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                else cmd.Parameters.AddWithValue("RefInvoiceNo", null);
                if (_dtRefInvoiceDate != null)
                    cmd.Parameters.AddWithValue("RefInvoiceDate", _dtRefInvoiceDate);
                else cmd.Parameters.AddWithValue("RefInvoiceDate", null);
                if (_nDefectiveCategory != null)
                    cmd.Parameters.AddWithValue("DefectiveCategory", _nDefectiveCategory);
                else cmd.Parameters.AddWithValue("DefectiveCategory", null);
                if (_sAssessmentFindings != null)
                    cmd.Parameters.AddWithValue("AssessmentFindings", _sAssessmentFindings);
                else cmd.Parameters.AddWithValue("AssessmentFindings", null);
               
                if (_sAccessories != null)
                    cmd.Parameters.AddWithValue("Accessories", _sAccessories);
                else cmd.Parameters.AddWithValue("Accessories", null);
                if (_sTechRecommandation != null)
                    cmd.Parameters.AddWithValue("TechRecommandation", _sTechRecommandation);
                else cmd.Parameters.AddWithValue("TechRecommandation", null);
                if (_sTechRemarks != null)
                    cmd.Parameters.AddWithValue("TechRemarks", _sTechRemarks);
                else cmd.Parameters.AddWithValue("TechRemarks", null);
                if (_nIsLocallySaleable != null)
                    cmd.Parameters.AddWithValue("IsLocallySaleable", _nIsLocallySaleable);
                else cmd.Parameters.AddWithValue("IsLocallySaleable", null);
                if (_PaneltyAmount != null)
                    cmd.Parameters.AddWithValue("PaneltyAmount", _PaneltyAmount);
                else cmd.Parameters.AddWithValue("PaneltyAmount", null);
               
                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                cmd.Parameters.AddWithValue("IsPenaltyApplicable", _nIsPenaltyApplicable);
                cmd.Parameters.AddWithValue("IsDefectiveAcknowledged", _IsDefectiveAcknowledged);
                cmd.Parameters.AddWithValue("AcknowledgmentRemarks", _sAcknowledgmentRemarks);
                cmd.Parameters.AddWithValue("ExpSalesDate", _ExpSalesDate);
                cmd.Parameters.AddWithValue("FromWH", _FromWH);
                cmd.Parameters.AddWithValue("ToWH", _ToWH);

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus(int nDefectiveID, string sRemarks, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "UPDATE t_UnsoldDefectiveProduct SET Status = ? WHERE DefectiveID = ?";
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("DefectiveID", nDefectiveID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();

                UnsoldDefectiveProductHistory oUnsoldDefectiveProductHistory = new UnsoldDefectiveProductHistory();
                oUnsoldDefectiveProductHistory.DefectiveID = Convert.ToInt32(nDefectiveID);
                oUnsoldDefectiveProductHistory.WarehouseID = Convert.ToInt32(nWarehouseID);
                oUnsoldDefectiveProductHistory.Remarks = sRemarks;
                oUnsoldDefectiveProductHistory.Status = _nStatus;
                oUnsoldDefectiveProductHistory.CreateDate = DateTime.Now.Date;
                oUnsoldDefectiveProductHistory.CreateUserID = Utility.UserId;

                oUnsoldDefectiveProductHistory.Add();

                cmd = DBController.Instance.GetCommand();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_UnsoldDefectiveProduct";
                oDataTran.DataID = Convert.ToInt32(nDefectiveID);
                oDataTran.WarehouseID = nWarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;

                oDataTran.AddForTDPOS();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateJobNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "UPDATE t_UnsoldDefectiveProduct SET JobNo = ? WHERE DefectiveID = ? and WarehouseID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_UnsoldDefectiveProduct";
                oDataTran.DataID = Convert.ToInt32(_nDefectiveID);
                oDataTran.WarehouseID = _nWarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;

                oDataTran.AddForTDPOS();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateAcknowledge()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "UPDATE t_UnsoldDefectiveProduct SET IsDefectiveAcknowledged = ?,AcknowledgmentRemarks=? WHERE DefectiveID = ? and WarehouseID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsDefectiveAcknowledged", _IsDefectiveAcknowledged);
                cmd.Parameters.AddWithValue("AcknowledgmentRemarks", _sAcknowledgmentRemarks);
                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);


              

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_UnsoldDefectiveProduct";
                oDataTran.DataID = Convert.ToInt32(_nDefectiveID);
                oDataTran.WarehouseID = _nWarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;

                oDataTran.AddForTDPOS();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateFromTOWH()
        {

            try
            {
                OleDbCommand cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "UPDATE t_UnsoldDefectiveProductNew SET FromWH = ?,ToWH = ?,Status=" + (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Transfer_To_Other_Outlet + " WHERE BarcodeSL=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FromWH", _FromWH);
                cmd.Parameters.AddWithValue("ToWH", _ToWH);

                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                OleDbCommand cmds = DBController.Instance.GetCommand();
                cmds.CommandText = "UPDATE t_UnsoldDefectiveProduct SET FromWH = ?,ToWH = ?,Status=" + (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Transfer_To_Other_Outlet + " WHERE DefectiveNo=(  " +
                                  "Select DefectiveNo From t_UnsoldDefectiveProductNew where BarcodeSL = ?)";
                cmds.CommandType = CommandType.Text;

                cmds.Parameters.AddWithValue("FromWH", _FromWH);
                cmds.Parameters.AddWithValue("ToWH", _ToWH);

                cmds.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);

                cmds.ExecuteNonQuery();
                cmds.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateAssessmentData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_UnsoldDefectiveProduct set " +
                                "DefectiveType = ?,ProposeDicAmount = ?,Status = ?, " +
                                "ApproveDicAmount = ?,ApproveBy = ?,ApproveDate = ?,DefectiveCategory = ?, " +
                                "AssessmentFindings = ?,IsRepairable = ?,Accessories = ?,TechRecommandation = ?, " +
                                "TechRemarks = ?,IsLocallySaleable = ?,PaneltyAmount = ?, IsLocallyRepaired = ?,RepairStatus = ?,IsPenaltyApplicable=? where DefectiveID = ? and WarehouseID =?";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApproveDicAmount", _ApproveDicAmount);
                if (_dtApproveDate != DBNull.Value)
                {
                    cmd.Parameters.AddWithValue("ApproveBy", _nApproveBy);
                    cmd.Parameters.AddWithValue("ApproveDate", _dtApproveDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApproveBy", null);
                    cmd.Parameters.AddWithValue("ApproveDate", null);
                }
                if (_nDefectiveCategory != DBNull.Value)
                    cmd.Parameters.AddWithValue("DefectiveCategory", _nDefectiveCategory);
                else cmd.Parameters.AddWithValue("DefectiveCategory", null);
                cmd.Parameters.AddWithValue("AssessmentFindings", _sAssessmentFindings);
                if (_nIsRepairable != DBNull.Value)
                    cmd.Parameters.AddWithValue("IsRepairable", _nIsRepairable);
                else cmd.Parameters.AddWithValue("IsRepairable", null);

                cmd.Parameters.AddWithValue("Accessories", _sAccessories);
                cmd.Parameters.AddWithValue("TechRecommandation", _sTechRecommandation);
                cmd.Parameters.AddWithValue("TechRemarks", _sTechRemarks);
                if (_nIsLocallySaleable != DBNull.Value)
                    cmd.Parameters.AddWithValue("IsLocallySaleable", _nIsLocallySaleable);
                else cmd.Parameters.AddWithValue("IsLocallySaleable", null);

                cmd.Parameters.AddWithValue("PaneltyAmount", _PaneltyAmount);

                if (_nIsLocallyRepaired != DBNull.Value)
                {
                    cmd.Parameters.AddWithValue("IsLocallyRepaired", _nIsLocallyRepaired);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IsLocallyRepaired", null);
                }
                if (_sRepairStatus != null)
                {
                    cmd.Parameters.AddWithValue("RepairStatus", _sRepairStatus);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RepairStatus", null);
                }
                cmd.Parameters.AddWithValue("IsPenaltyApplicable", _nIsPenaltyApplicable);

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();
                UnsoldDefectiveProductHistory oUnsoldDefectiveProductHistory = new UnsoldDefectiveProductHistory();
                oUnsoldDefectiveProductHistory.DefectiveID = Convert.ToInt32(_nDefectiveID);
                oUnsoldDefectiveProductHistory.WarehouseID = Convert.ToInt32(_nWarehouseID);
                oUnsoldDefectiveProductHistory.Remarks = _sAssessmentFindings.ToString();
                oUnsoldDefectiveProductHistory.Status = _nStatus;
                oUnsoldDefectiveProductHistory.CreateDate = DateTime.Now.Date;
                oUnsoldDefectiveProductHistory.CreateUserID = Utility.UserId;
                oUnsoldDefectiveProductHistory.Add();

                //cmd = DBController.Instance.GetCommand();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_UnsoldDefectiveProduct";
                oDataTran.DataID = Convert.ToInt32(_nDefectiveID);
                oDataTran.WarehouseID = _nWarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;

                oDataTran.AddForTDPOS();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateCreateData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Update t_UnsoldDefectiveProduct set " +
                                "DefectiveType = ?,ProposeDicAmount = ?, " +
                                "ApproveDicAmount = ?, OriginalSL=?, DefectiveCategory = ?, " +
                                "AssessmentFindings = ?,IsRepairable = ?,Accessories = ?,TechRecommandation = ?, " +
                                "TechRemarks = ?,IsLocallySaleable = ?,PaneltyAmount = ?, IsLocallyRepaired = ?,RepairStatus = ?,IsPenaltyApplicable=?,ExpSalesDate=? where DefectiveID = ? and WarehouseID =?";

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                cmd.Parameters.AddWithValue("ApproveDicAmount", _ApproveDicAmount);


                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);

                if (_nDefectiveCategory != DBNull.Value)
                    cmd.Parameters.AddWithValue("DefectiveCategory", _nDefectiveCategory);
                else cmd.Parameters.AddWithValue("DefectiveCategory", null);
                cmd.Parameters.AddWithValue("AssessmentFindings", _sAssessmentFindings);
                if (_nIsRepairable != DBNull.Value)
                    cmd.Parameters.AddWithValue("IsRepairable", _nIsRepairable);
                else cmd.Parameters.AddWithValue("IsRepairable", null);

                cmd.Parameters.AddWithValue("Accessories", _sAccessories);
                cmd.Parameters.AddWithValue("TechRecommandation", _sTechRecommandation);
                cmd.Parameters.AddWithValue("TechRemarks", _sTechRemarks);
                if (_nIsLocallySaleable != DBNull.Value)
                    cmd.Parameters.AddWithValue("IsLocallySaleable", _nIsLocallySaleable);
                else cmd.Parameters.AddWithValue("IsLocallySaleable", null);

                cmd.Parameters.AddWithValue("PaneltyAmount", _PaneltyAmount);

                if (_nIsLocallyRepaired != DBNull.Value)
                {
                    cmd.Parameters.AddWithValue("IsLocallyRepaired", _nIsLocallyRepaired);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IsLocallyRepaired", null);
                }
                if (_sRepairStatus != null)
                {
                    cmd.Parameters.AddWithValue("RepairStatus", _sRepairStatus);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RepairStatus", null);
                }

                cmd.Parameters.AddWithValue("IsPenaltyApplicable", _nIsPenaltyApplicable);
                cmd.Parameters.AddWithValue("ExpSalesDate", _ExpSalesDate);
                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();
                UnsoldDefectiveProductHistory oUnsoldDefectiveProductHistory = new UnsoldDefectiveProductHistory();
                oUnsoldDefectiveProductHistory.DefectiveID = Convert.ToInt32(_nDefectiveID);
                oUnsoldDefectiveProductHistory.WarehouseID = Convert.ToInt32(_nWarehouseID);
                oUnsoldDefectiveProductHistory.Remarks = _sAssessmentFindings.ToString();
                oUnsoldDefectiveProductHistory.Status = _nStatus;
                oUnsoldDefectiveProductHistory.CreateDate = DateTime.Now.Date;
                oUnsoldDefectiveProductHistory.CreateUserID = Utility.UserId;
                oUnsoldDefectiveProductHistory.Add();

                //cmd = DBController.Instance.GetCommand();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_UnsoldDefectiveProduct";
                oDataTran.DataID = Convert.ToInt32(_nDefectiveID);
                oDataTran.WarehouseID = _nWarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;

                oDataTran.AddForTDPOS();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateInvoiceData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "UPDATE t_UnsoldDefectiveProduct SET RefInvoiceNo= ?, RefInvoiceDate = ?, Status = ? WHERE DefectiveID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                cmd.Parameters.AddWithValue("RefInvoiceDate", _dtRefInvoiceDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                //cmd = DBController.Instance.GetCommand();

                //UnsoldDefectiveProductHistory oUnsoldDefectiveProductHistory = new UnsoldDefectiveProductHistory();
                //oUnsoldDefectiveProductHistory.DefectiveID = Convert.ToInt32(_nDefectiveID);
                //oUnsoldDefectiveProductHistory.WarehouseID = Convert.ToInt32(_nWarehouseID);
                //oUnsoldDefectiveProductHistory.Remarks = _sRemarks;
                //oUnsoldDefectiveProductHistory.Status = _nStatus;
                //oUnsoldDefectiveProductHistory.CreateDate = DateTime.Now.Date;
                //oUnsoldDefectiveProductHistory.CreateUserID = Utility.UserId;
                //oUnsoldDefectiveProductHistory.Add();

                cmd = DBController.Instance.GetCommand();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_UnsoldDefectiveProduct";
                oDataTran.DataID = Convert.ToInt32(_nDefectiveID);
                oDataTran.WarehouseID = _nWarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                if (oDataTran.CheckData() == false)
                {
                    oDataTran.AddForTDPOS();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateInvoiceDataRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "UPDATE t_UnsoldDefectiveProduct SET RefInvoiceNo= ?, RefInvoiceDate = ?, Status = ? WHERE DefectiveID = ? and WarehouseID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                cmd.Parameters.AddWithValue("RefInvoiceDate", _dtRefInvoiceDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateInvoiceDataPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "UPDATE t_UnsoldDefectiveProduct SET BarcodeSL = ?,OriginalSL=?,DefectiveType = ?,Fault = ?,Reason = ?,Remarks = ?,ProposeDicAmount = ?,Status = ?,  " +
                                  "RefTranNo = ?,RefTranDate = ?,JobNo = ?,RefInvoiceNo = ?,RefInvoiceDate = ? WHERE DefectiveID = ? and WarehouseID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);
                cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                if (RefInvoiceNo != null)
                    cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                else cmd.Parameters.AddWithValue("RefInvoiceNo", null);
                if (_dtRefInvoiceDate != DBNull.Value)
                    cmd.Parameters.AddWithValue("RefInvoiceDate", _dtRefInvoiceDate);
                else cmd.Parameters.AddWithValue("RefInvoiceDate", null);

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateInvoiceDataPOSNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "UPDATE t_UnsoldDefectiveProductNew SET BarcodeSL = ?,OriginalSL=?,DefectiveType = ?,Fault = ?,Reason = ?,Remarks = ?,ProposeDicAmount = ?,Status = ?,  " +
                                  "RefTranNo = ?,RefTranDate = ?,JobNo = ?,RefInvoiceNo = ?,RefInvoiceDate = ? WHERE DefectiveID = ? and WarehouseID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("RefTranNo", _sRefTranNo);
                cmd.Parameters.AddWithValue("RefTranDate", _dRefTranDate);
                cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                if (RefInvoiceNo != null)
                    cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                else cmd.Parameters.AddWithValue("RefInvoiceNo", null);
                if (_dtRefInvoiceDate != DBNull.Value)
                    cmd.Parameters.AddWithValue("RefInvoiceDate", _dtRefInvoiceDate);
                else cmd.Parameters.AddWithValue("RefInvoiceDate", null);

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditDefectiveProduct()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_UnsoldDefectiveProduct SET ProductID = ?, BarcodeSL = ?,OriginalSL=?,DefectiveType = ?, Fault = ?, Reason = ?, Remarks = ? , ProposeDicAmount = ? WHERE DefectiveID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);
                //cmd.Parameters.AddWithValue("JobNo", _sJobNo);

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_UnsoldDefectiveProduct";
                oDataTran.DataID = Convert.ToInt32(_nDefectiveID);
                oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                if (oDataTran.CheckData() == false)
                {
                    oDataTran.AddForTDPOS();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditDefectiveProductRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_UnsoldDefectiveProduct SET ProductID = ?, BarcodeSL = ?,OriginalSL=?,DefectiveType = ?, Fault = ?, Reason = ?, Remarks = ? , ProposeDicAmount = ? WHERE DefectiveID = ? and WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.Parameters.AddWithValue("OriginalSL", _sOriginalSL);
                cmd.Parameters.AddWithValue("DefectiveType", _nDefectiveType);
                cmd.Parameters.AddWithValue("Fault", _sFault);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ProposeDicAmount", _ProposeDicAmount);

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_UnsoldDefectiveProduct WHERE [DefectiveID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_UnsoldDefectiveProduct where DefectiveID =?";
                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDefectiveID = (int)reader["DefectiveID"];
                    _sDefectiveNo = (string)reader["DefectiveNo"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nProductID = (int)reader["ProductID"];
                    _sBarcodeSL = (string)reader["BarcodeSL"];
                    _sOriginalSL = (string)reader["OriginalSL"];
                    _nDefectiveType = (int)reader["DefectiveType"];
                    _sFault = (string)reader["Fault"];
                    _sReason = (string)reader["Reason"];
                    _sRemarks = (string)reader["Remarks"];
                    _nStatus = (int)reader["Status"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _sRefTranNo = (string)reader["RefTranNo"];
                    _dRefTranDate = Convert.ToDateTime(reader["RefTranDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckDefectiveIDHOEnd()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_UnsoldDefectiveProduct where DefectiveID =? and WarehouseID=?";
            cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
            cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
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
        public bool CheckDefectiveIDHOEndNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_UnsoldDefectiveProductNew where DefectiveID =? and WarehouseID=?";
            cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
            cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
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
        public bool GetDefectiveIDByBarcode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT isnull(MAX(DefectiveID),0) as DefectiveID FROM t_UnsoldDefectiveProduct where BarcodeSL =?";
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDefectiveID = (int)reader["DefectiveID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (_nDefectiveID != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GetDefectiveIDByBarcodeRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT isnull(MAX(DefectiveID),0) as DefectiveID FROM t_UnsoldDefectiveProduct where BarcodeSL =? and WarehouseID=" + Utility.WarehouseID + "";
                cmd.Parameters.AddWithValue("BarcodeSL", _sBarcodeSL);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDefectiveID = (int)reader["DefectiveID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (_nDefectiveID != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class UnsoldDefectiveProducts : CollectionBase
    {
        public UnsoldDefectiveProduct this[int i]
        {
            get { return (UnsoldDefectiveProduct)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(UnsoldDefectiveProduct oUnsoldDefectiveProduct)
        {
            InnerList.Add(oUnsoldDefectiveProduct);
        }
        public int GetIndex(int nDefectiveID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].DefectiveID == nDefectiveID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_UnsoldDefectiveProduct";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader(); 
                while (reader.Read())
                {
                    UnsoldDefectiveProduct oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                    oUnsoldDefectiveProduct.DefectiveID = (int)reader["DefectiveID"];
                    oUnsoldDefectiveProduct.DefectiveNo = (string)reader["DefectiveNo"];
                    oUnsoldDefectiveProduct.WarehouseID = (int)reader["WarehouseID"];
                    oUnsoldDefectiveProduct.ProductID = (int)reader["ProductID"];
                    oUnsoldDefectiveProduct.BarcodeSL = (string)reader["BarcodeSL"];
                    oUnsoldDefectiveProduct.OriginalSL = (string)reader["OriginalSL"];
                    oUnsoldDefectiveProduct.DefectiveType = (int)reader["DefectiveType"];
                    oUnsoldDefectiveProduct.Fault = (string)reader["Fault"];
                    oUnsoldDefectiveProduct.Reason = (string)reader["Reason"];
                    oUnsoldDefectiveProduct.Remarks = (string)reader["Remarks"];
                    oUnsoldDefectiveProduct.Status = (int)reader["Status"];
                    oUnsoldDefectiveProduct.CreateUserID = (int)reader["CreateUserID"];
                    oUnsoldDefectiveProduct.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oUnsoldDefectiveProduct.RefTranNo = (string)reader["RefTranNo"];
                    oUnsoldDefectiveProduct.RefTranDate = Convert.ToDateTime(reader["RefTranDate"].ToString());
                    InnerList.Add(oUnsoldDefectiveProduct);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForHO(DateTime dFromDate, DateTime dToDate, int nStatus, string sBarcodeSL, bool IsCheck, string sDefectiveNo, string sProductName, string sShowroom, string sJobNo,string sIsCreateJob,int nDefectiveType, int nPGID, int nMAGID, int nASGID, int nAGID, string sBrandID, int nType)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select a.*, isnull(b.JobNo, '') CSDJobNo,   " +
                    "b.CreateDate as JobDate,case when b.JobNo is null then 'NO' else 'YES' end as IsCreateJob  " +
                    "From  " +
                    "(  " +
                    "Select DefectiveID, DefectiveNo, a.WarehouseID,  " +
                    "ShowroomCode, a.ProductID, ProductCode, ProductName,AGID, AGName,ASGID, ASGName,  " +
                    "MAGID,MAGName,PGID, PGName,BrandID, BrandDesc,isnull(c.CostPrice,0) CostPrice,isnull(c.NSP,0) NSP,isnull(c.RSP,0) RSP,isnull(c.VAT,0) VAT,BarcodeSL,OriginalSL, DefectiveType, Fault, Reason, isnull(a.Remarks, '') Remarks,  " +
                    "ProposeDicAmount, a.Status, a.CreateUserID, a.CreateDate, isnull(RefTranNo, '') RefTranNo,  " +
                    "RefTranDate, isnull(ApproveDicAmount, 0) ApproveDicAmount, a.JobNo,  " +
                    "isnull(ApproveBy, -1) ApproveBy, ApproveDate, isnull(RefInvoiceNo, '') RefInvoiceNo,  " +
                    "RefInvoiceDate, isnull(DefectiveCategory, 0) DefectiveCategory, isnull(AssessmentFindings, '') AssessmentFindings,  " +
                    "isnull(IsRepairable, 0) IsRepairable, isnull(Accessories, '') Accessories,  " +
                    "isnull(TechRecommandation, 0) TechRecommandation, isnull(TechRemarks, '') TechRemarks,  " +
                    "isnull(IsLocallySaleable, '') IsLocallySaleable, isnull(PaneltyAmount, 0) PaneltyAmount,isnull(IsLocallyRepaired,0) IsLocallyRepaired,isnull(RepairStatus,'') RepairStatus,isnull(IsPenaltyApplicable,0) IsPenaltyApplicable,isnull(IsDefectiveAcknowledged, 0) IsDefectiveAcknowledged,ExpSalesDate,isnull(AcknowledgmentRemarks,'') AcknowledgmentRemarks  " +
                    "From t_UnsoldDefectiveProduct a, t_Showroom b, v_ProductDetails c  " +
                    "where a.WarehouseID = b.WarehouseID and a.ProductID = C.ProductID  " +
                    ") a  " +
                    "Left outer Join  " +
                    "(  " +
                    "Select * From  t_CSDJob  " +
                    ") b  " +
                    "on a.JobNo = b.JobNo  " +
                    ") Main where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sBarcodeSL != "")
            {
                sSql = sSql + " AND BarcodeSL like '%" + sBarcodeSL + "%'";
            }
            if (sDefectiveNo != "")
            {
                sSql = sSql + " AND DefectiveNo  like '%" + sDefectiveNo + "%'";
            }
            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName  like '%" + sProductName + "%'";
            }
            if (sShowroom != "")
            {
                sSql = sSql + " AND ShowroomCode  like '%" + sShowroom + "%'";
            }
            if (sJobNo != "")
            {
                sSql = sSql + " AND CSDJobNo  like '%" + sJobNo + "%'";
            }
            if (sIsCreateJob != "<All>")
            {
                sSql = sSql + " AND IsCreateJob='" + sIsCreateJob + "'";
            }
            if (nDefectiveType != 0)
            {
                sSql = sSql + " AND DefectiveType=" + nDefectiveType + "";
            }

            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID=" + nASGID + "";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }

            //if (nBrandID != -1)
            //{
            //    sSql = sSql + " AND BrandID=" + nBrandID + "";
            //}
            if (sBrandID != "")
            {
                sSql = sSql + " AND BrandID IN (" + sBrandID + ") ";
            }
            if (nType == 1)
            {
                sSql = sSql + " AND IsDefectiveAcknowledged = 1 ";
            }

            sSql = sSql + " Order by DefectiveID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UnsoldDefectiveProduct oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                    oUnsoldDefectiveProduct.DefectiveID = (int)reader["DefectiveID"];
                    oUnsoldDefectiveProduct.DefectiveNo = (string)reader["DefectiveNo"];
                    oUnsoldDefectiveProduct.WarehouseID = (int)reader["WarehouseID"];
                    oUnsoldDefectiveProduct.ShowroomCode = (string)reader["ShowroomCode"];
                    oUnsoldDefectiveProduct.ProductID = (int)reader["ProductID"];
                    oUnsoldDefectiveProduct.ProductCode = (string)reader["ProductCode"];
                    oUnsoldDefectiveProduct.ProductName = (string)reader["ProductName"];
                    oUnsoldDefectiveProduct.AGName = (string)reader["AGName"];
                    oUnsoldDefectiveProduct.ASGName = (string)reader["ASGName"];
                    oUnsoldDefectiveProduct.MAGName = (string)reader["MAGName"];
                    oUnsoldDefectiveProduct.PGName = (string)reader["PGName"];
                    oUnsoldDefectiveProduct.BrandDesc = (string)reader["BrandDesc"];

                    oUnsoldDefectiveProduct.BarcodeSL = (string)reader["BarcodeSL"];
                    if (reader["OriginalSL"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.OriginalSL = (string)reader["OriginalSL"];
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.OriginalSL = "";
                    }
                    oUnsoldDefectiveProduct.DefectiveType = (int)reader["DefectiveType"];
                    oUnsoldDefectiveProduct.Fault = (string)reader["Fault"];
                    oUnsoldDefectiveProduct.Reason = (string)reader["Reason"];
                    oUnsoldDefectiveProduct.Remarks = (string)reader["Remarks"];
                    oUnsoldDefectiveProduct.ProposeDicAmount = Convert.ToDouble(reader["ProposeDicAmount"].ToString());
                    oUnsoldDefectiveProduct.Status = (int)reader["Status"];
                    oUnsoldDefectiveProduct.CreateUserID = (int)reader["CreateUserID"];
                    oUnsoldDefectiveProduct.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oUnsoldDefectiveProduct.RefTranNo = (string)reader["RefTranNo"];

                    if (reader["RefTranDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.RefTranDate = Convert.ToDateTime(reader["RefTranDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.RefTranDate = "";
                    }

                    if (reader["JobDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.JobDate = Convert.ToDateTime(reader["JobDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.JobDate = "";
                    }
                    if (reader["ApproveDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.ApproveDate = "";
                    }

                    if (reader["RefInvoiceDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.RefInvoiceDate = Convert.ToDateTime(reader["RefInvoiceDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.RefInvoiceDate = "";
                    }

                    oUnsoldDefectiveProduct.JobNo = (string)reader["CSDJobNo"];
                    oUnsoldDefectiveProduct.IsCreateJob = (string)reader["IsCreateJob"];
                    oUnsoldDefectiveProduct.ApproveDicAmount = Convert.ToDouble(reader["ApproveDicAmount"].ToString());
                    oUnsoldDefectiveProduct.ApproveBy = (int)reader["ApproveBy"];
                    oUnsoldDefectiveProduct.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    oUnsoldDefectiveProduct.DefectiveCategory = (int)reader["DefectiveCategory"];
                    oUnsoldDefectiveProduct.AssessmentFindings = (string)reader["AssessmentFindings"];
                    oUnsoldDefectiveProduct.IsRepairable = (int)reader["IsRepairable"];
                    oUnsoldDefectiveProduct.Accessories = (string)reader["Accessories"];
                    oUnsoldDefectiveProduct.TechRecommandation = (int)reader["TechRecommandation"];
                    oUnsoldDefectiveProduct.TechRemarks = (string)reader["TechRemarks"];
                    oUnsoldDefectiveProduct.IsLocallySaleable = (int)reader["IsLocallySaleable"];
                    oUnsoldDefectiveProduct.PaneltyAmount = Convert.ToDouble(reader["PaneltyAmount"].ToString());

                    oUnsoldDefectiveProduct.RepairStatus = (string)reader["RepairStatus"];
                    oUnsoldDefectiveProduct.IsLocallyRepaired = (int)reader["IsLocallyRepaired"];
                    oUnsoldDefectiveProduct.IsPenaltyApplicable = (int)reader["IsPenaltyApplicable"];
                    oUnsoldDefectiveProduct.IsDefectiveAcknowledged = (int)reader["IsDefectiveAcknowledged"];
                    oUnsoldDefectiveProduct.AcknowledgmentRemarks = (string)reader["AcknowledgmentRemarks"];
                    if (reader["ExpSalesDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.ExpSalesDate = (DateTime)reader["ExpSalesDate"];
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.ExpSalesDate = null;
                    }

                    oUnsoldDefectiveProduct.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    oUnsoldDefectiveProduct.NSP = Convert.ToDouble(reader["NSP"].ToString());
                    oUnsoldDefectiveProduct.RSP = Convert.ToDouble(reader["RSP"].ToString());
                    oUnsoldDefectiveProduct.VAT = Convert.ToDouble(reader["VAT"].ToString());


                    InnerList.Add(oUnsoldDefectiveProduct);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForPOS(DateTime dFromDate, DateTime dToDate, int nStatus, string sBarcodeSL, bool IsCheck, string sDefectiveNo, string sProductCode, string sProductName,int nStockStatus,int nDefectiveType)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "Select DefectiveID, DefectiveNo, a.WarehouseID,  " +
                    "ShowroomCode, a.ProductID, ProductCode, ProductName, AGName, ASGName,    " +
                    "MAGName, PGName, BrandDesc, BarcodeSL, OriginalSL, DefectiveType, Fault, Reason, isnull(a.Remarks, '') Remarks,    " +
                    "ProposeDicAmount, a.Status, a.CreateUserID, a.CreateDate, isnull(RefTranNo, '') RefTranNo,    " +
                    "RefTranDate, isnull(ApproveDicAmount, 0) ApproveDicAmount, isnull(a.JobNo,'') JobNo,    " +
                    "isnull(ApproveBy, -1) ApproveBy, ApproveDate, isnull(RefInvoiceNo, '') RefInvoiceNo,    " +
                    "RefInvoiceDate, isnull(DefectiveCategory, -1) DefectiveCategory, isnull(AssessmentFindings, '') AssessmentFindings,    " +
                    "isnull(IsRepairable, -1) IsRepairable, isnull(Accessories, '') Accessories,    " +
                    "isnull(TechRecommandation, -1) TechRecommandation, isnull(TechRemarks, '') TechRemarks,    " +
                    "isnull(IsLocallySaleable, '') IsLocallySaleable, isnull(PaneltyAmount, 0) PaneltyAmount,isnull(IsLocallyRepaired, -1) IsLocallyRepaired,isnull(RepairStatus, '') RepairStatus, isnull(IsPenaltyApplicable,0) IsPenaltyApplicable, d.Status as StockStatus  " +
                    //"isnull(IsDefectiveAcknowledged,0) IsDefectiveAcknowledged,isnull(AcknowledgmentRemarks, '') AcknowledgmentRemarks,ExpSalesDate,isnull(FromWH, -1) FromWH,isnull(ToWH, -1) ToWH  " +
                    "From t_UnsoldDefectiveProduct a, t_Showroom b, v_ProductDetails c, t_ProductStockSerial d  " +
                    "where a.WarehouseID = b.WarehouseID and a.ProductID = C.ProductID and a.BarcodeSL = d.ProductSerialNo";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " and a.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and a.CreateDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }
            if (nDefectiveType != 0)
            {
                sSql = sSql + " AND a.DefectiveType=" + nDefectiveType + "";
            }

            if (nStockStatus != -1)
            {
                sSql = sSql + " AND d.Status=" + nStockStatus + "";
            }
            if (sBarcodeSL != "")
            {
                sSql = sSql + " AND BarcodeSL like '%" + sBarcodeSL + "%'";
            }
            if (sDefectiveNo != "")
            {
                sSql = sSql + " AND DefectiveNo  like '%" + sDefectiveNo + "%'";
            }
            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode  like '%" + sProductCode + "%'";
            }
            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName  like '%" + sProductName + "%'";
            }
            sSql = sSql + " Order by DefectiveID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UnsoldDefectiveProduct oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                    oUnsoldDefectiveProduct.StockStatus = (int)reader["StockStatus"];
                    oUnsoldDefectiveProduct.DefectiveID = (int)reader["DefectiveID"];
                    oUnsoldDefectiveProduct.DefectiveNo = (string)reader["DefectiveNo"];
                    oUnsoldDefectiveProduct.WarehouseID = (int)reader["WarehouseID"];
                    oUnsoldDefectiveProduct.ShowroomCode = (string)reader["ShowroomCode"];
                    oUnsoldDefectiveProduct.ProductID = (int)reader["ProductID"];
                    oUnsoldDefectiveProduct.ProductCode = (string)reader["ProductCode"];
                    oUnsoldDefectiveProduct.ProductName = (string)reader["ProductName"];
                    oUnsoldDefectiveProduct.AGName = (string)reader["AGName"];
                    oUnsoldDefectiveProduct.ASGName = (string)reader["ASGName"];
                    oUnsoldDefectiveProduct.MAGName = (string)reader["MAGName"];
                    oUnsoldDefectiveProduct.PGName = (string)reader["PGName"];
                    oUnsoldDefectiveProduct.BrandDesc = (string)reader["BrandDesc"];
                    oUnsoldDefectiveProduct.BarcodeSL = (string)reader["BarcodeSL"];
                    if (reader["OriginalSL"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.OriginalSL = (string)reader["OriginalSL"];
                    }
                    oUnsoldDefectiveProduct.DefectiveType = (int)reader["DefectiveType"];
                    oUnsoldDefectiveProduct.Fault = (string)reader["Fault"];
                    oUnsoldDefectiveProduct.Reason = (string)reader["Reason"];
                    oUnsoldDefectiveProduct.Remarks = (string)reader["Remarks"];
                    oUnsoldDefectiveProduct.ProposeDicAmount = Convert.ToDouble(reader["ProposeDicAmount"].ToString());
                    oUnsoldDefectiveProduct.Status = (int)reader["Status"];
                    oUnsoldDefectiveProduct.CreateUserID = (int)reader["CreateUserID"];
                    oUnsoldDefectiveProduct.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oUnsoldDefectiveProduct.RefTranNo = (string)reader["RefTranNo"];
                    if (reader["RefTranDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.RefTranDate = Convert.ToDateTime(reader["RefTranDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.RefTranDate = "";
                    }
                    
                    if (reader["ApproveDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.ApproveDate = "";
                    }
                    if (reader["RefInvoiceDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.RefInvoiceDate = Convert.ToDateTime(reader["RefInvoiceDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.RefInvoiceDate = "";
                    }
                    oUnsoldDefectiveProduct.JobNo = (string)reader["JobNo"];
                    //oUnsoldDefectiveProduct.IsCreateJob = (string)reader["IsCreateJob"];
                    oUnsoldDefectiveProduct.ApproveDicAmount = Convert.ToDouble(reader["ApproveDicAmount"].ToString());
                    oUnsoldDefectiveProduct.ApproveBy = (int)reader["ApproveBy"];
                    oUnsoldDefectiveProduct.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    oUnsoldDefectiveProduct.DefectiveCategory = (int)reader["DefectiveCategory"];
                    oUnsoldDefectiveProduct.AssessmentFindings = (string)reader["AssessmentFindings"];
                    oUnsoldDefectiveProduct.IsRepairable = (int)reader["IsRepairable"];
                    oUnsoldDefectiveProduct.Accessories = (string)reader["Accessories"];
                    oUnsoldDefectiveProduct.TechRecommandation = (int)reader["TechRecommandation"];
                    oUnsoldDefectiveProduct.TechRemarks = (string)reader["TechRemarks"];
                    oUnsoldDefectiveProduct.IsLocallySaleable = (int)reader["IsLocallySaleable"];
                    oUnsoldDefectiveProduct.PaneltyAmount = Convert.ToDouble(reader["PaneltyAmount"].ToString());
                    oUnsoldDefectiveProduct.RepairStatus = (string)reader["RepairStatus"];
                    oUnsoldDefectiveProduct.IsPenaltyApplicable = (int)reader["IsPenaltyApplicable"];
                    oUnsoldDefectiveProduct.IsLocallyRepaired = (int)reader["IsLocallyRepaired"];


                    //oUnsoldDefectiveProduct.IsDefectiveAcknowledged = (int)reader["IsDefectiveAcknowledged"];
                    //oUnsoldDefectiveProduct.AcknowledgmentRemarks = (string)reader["AcknowledgmentRemarks"];
                    //oUnsoldDefectiveProduct.FromWH = (int)reader["FromWH"];
                    //oUnsoldDefectiveProduct.ToWH = (int)reader["ToWH"];
                    //if (reader["ExpSalesDate"] != DBNull.Value)
                    //{
                    //    oUnsoldDefectiveProduct.ExpSalesDate = Convert.ToDateTime(reader["ExpSalesDate"].ToString());
                    //}
                    //else
                    //{
                    //    oUnsoldDefectiveProduct.ExpSalesDate = "";
                    //}

                    InnerList.Add(oUnsoldDefectiveProduct);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForPOSNew(DateTime dFromDate, DateTime dToDate, int nStatus, string sBarcodeSL, bool IsCheck, string sDefectiveNo, string sProductCode, string sProductName, int nStockStatus, int nDefectiveType)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "Select DefectiveID, DefectiveNo, a.WarehouseID,  " +
                    "ShowroomCode, a.ProductID, ProductCode, ProductName, AGName, ASGName,    " +
                    "MAGName, PGName, BrandDesc, BarcodeSL, OriginalSL, DefectiveType, Fault, Reason, isnull(a.Remarks, '') Remarks,    " +
                    "ProposeDicAmount, a.Status, a.CreateUserID, a.CreateDate, isnull(RefTranNo, '') RefTranNo,    " +
                    "RefTranDate, isnull(ApproveDicAmount, 0) ApproveDicAmount, isnull(a.JobNo,'') JobNo,    " +
                    "isnull(ApproveBy, -1) ApproveBy, ApproveDate, isnull(RefInvoiceNo, '') RefInvoiceNo,    " +
                    "RefInvoiceDate, isnull(DefectiveCategory, -1) DefectiveCategory, isnull(AssessmentFindings, '') AssessmentFindings,    " +
                    "isnull(IsRepairable, -1) IsRepairable, isnull(Accessories, '') Accessories,    " +
                    "isnull(TechRecommandation, -1) TechRecommandation, isnull(TechRemarks, '') TechRemarks,    " +
                    "isnull(IsLocallySaleable, '') IsLocallySaleable, isnull(PaneltyAmount, 0) PaneltyAmount,isnull(IsLocallyRepaired, -1) IsLocallyRepaired,isnull(RepairStatus, '') RepairStatus, isnull(IsPenaltyApplicable,0) IsPenaltyApplicable, d.Status as StockStatus,  " +
                    "isnull(IsDefectiveAcknowledged,0) IsDefectiveAcknowledged,isnull(AcknowledgmentRemarks, '') AcknowledgmentRemarks,ExpSalesDate,isnull(FromWH, -1) FromWH,isnull(ToWH, -1) ToWH  " +
                    "From t_UnsoldDefectiveProduct a, t_Showroom b, v_ProductDetails c, t_ProductStockSerial d  " +
                    "where a.WarehouseID = b.WarehouseID and a.ProductID = C.ProductID and a.BarcodeSL = d.ProductSerialNo";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " and a.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and a.CreateDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }
            if (nDefectiveType != 0)
            {
                sSql = sSql + " AND a.DefectiveType=" + nDefectiveType + "";
            }

            if (nStockStatus != -1)
            {
                sSql = sSql + " AND d.Status=" + nStockStatus + "";
            }
            if (sBarcodeSL != "")
            {
                sSql = sSql + " AND BarcodeSL like '%" + sBarcodeSL + "%'";
            }
            if (sDefectiveNo != "")
            {
                sSql = sSql + " AND DefectiveNo  like '%" + sDefectiveNo + "%'";
            }
            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode  like '%" + sProductCode + "%'";
            }
            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName  like '%" + sProductName + "%'";
            }
            sSql = sSql + " Order by DefectiveID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UnsoldDefectiveProduct oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                    oUnsoldDefectiveProduct.StockStatus = (int)reader["StockStatus"];
                    oUnsoldDefectiveProduct.DefectiveID = (int)reader["DefectiveID"];
                    oUnsoldDefectiveProduct.DefectiveNo = (string)reader["DefectiveNo"];
                    oUnsoldDefectiveProduct.WarehouseID = (int)reader["WarehouseID"];
                    oUnsoldDefectiveProduct.ShowroomCode = (string)reader["ShowroomCode"];
                    oUnsoldDefectiveProduct.ProductID = (int)reader["ProductID"];
                    oUnsoldDefectiveProduct.ProductCode = (string)reader["ProductCode"];
                    oUnsoldDefectiveProduct.ProductName = (string)reader["ProductName"];
                    oUnsoldDefectiveProduct.AGName = (string)reader["AGName"];
                    oUnsoldDefectiveProduct.ASGName = (string)reader["ASGName"];
                    oUnsoldDefectiveProduct.MAGName = (string)reader["MAGName"];
                    oUnsoldDefectiveProduct.PGName = (string)reader["PGName"];
                    oUnsoldDefectiveProduct.BrandDesc = (string)reader["BrandDesc"];
                    oUnsoldDefectiveProduct.BarcodeSL = (string)reader["BarcodeSL"];
                    if (reader["OriginalSL"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.OriginalSL = (string)reader["OriginalSL"];
                    }
                    oUnsoldDefectiveProduct.DefectiveType = (int)reader["DefectiveType"];
                    oUnsoldDefectiveProduct.Fault = (string)reader["Fault"];
                    oUnsoldDefectiveProduct.Reason = (string)reader["Reason"];
                    oUnsoldDefectiveProduct.Remarks = (string)reader["Remarks"];
                    oUnsoldDefectiveProduct.ProposeDicAmount = Convert.ToDouble(reader["ProposeDicAmount"].ToString());
                    oUnsoldDefectiveProduct.Status = (int)reader["Status"];
                    oUnsoldDefectiveProduct.CreateUserID = (int)reader["CreateUserID"];
                    oUnsoldDefectiveProduct.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oUnsoldDefectiveProduct.RefTranNo = (string)reader["RefTranNo"];
                    if (reader["RefTranDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.RefTranDate = Convert.ToDateTime(reader["RefTranDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.RefTranDate = "";
                    }

                    if (reader["ApproveDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.ApproveDate = "";
                    }
                    if (reader["RefInvoiceDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.RefInvoiceDate = Convert.ToDateTime(reader["RefInvoiceDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.RefInvoiceDate = "";
                    }
                    oUnsoldDefectiveProduct.JobNo = (string)reader["JobNo"];
                    //oUnsoldDefectiveProduct.IsCreateJob = (string)reader["IsCreateJob"];
                    oUnsoldDefectiveProduct.ApproveDicAmount = Convert.ToDouble(reader["ApproveDicAmount"].ToString());
                    oUnsoldDefectiveProduct.ApproveBy = (int)reader["ApproveBy"];
                    oUnsoldDefectiveProduct.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    oUnsoldDefectiveProduct.DefectiveCategory = (int)reader["DefectiveCategory"];
                    oUnsoldDefectiveProduct.AssessmentFindings = (string)reader["AssessmentFindings"];
                    oUnsoldDefectiveProduct.IsRepairable = (int)reader["IsRepairable"];
                    oUnsoldDefectiveProduct.Accessories = (string)reader["Accessories"];
                    oUnsoldDefectiveProduct.TechRecommandation = (int)reader["TechRecommandation"];
                    oUnsoldDefectiveProduct.TechRemarks = (string)reader["TechRemarks"];
                    oUnsoldDefectiveProduct.IsLocallySaleable = (int)reader["IsLocallySaleable"];
                    oUnsoldDefectiveProduct.PaneltyAmount = Convert.ToDouble(reader["PaneltyAmount"].ToString());
                    oUnsoldDefectiveProduct.RepairStatus = (string)reader["RepairStatus"];
                    oUnsoldDefectiveProduct.IsPenaltyApplicable = (int)reader["IsPenaltyApplicable"];
                    oUnsoldDefectiveProduct.IsLocallyRepaired = (int)reader["IsLocallyRepaired"];


                    oUnsoldDefectiveProduct.IsDefectiveAcknowledged = (int)reader["IsDefectiveAcknowledged"];
                    oUnsoldDefectiveProduct.AcknowledgmentRemarks = (string)reader["AcknowledgmentRemarks"];
                    oUnsoldDefectiveProduct.FromWH = (int)reader["FromWH"];
                    oUnsoldDefectiveProduct.ToWH = (int)reader["ToWH"];
                    if (reader["ExpSalesDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.ExpSalesDate = Convert.ToDateTime(reader["ExpSalesDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.ExpSalesDate = "";
                    }

                    InnerList.Add(oUnsoldDefectiveProduct);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshForPOSRT(DateTime dFromDate, DateTime dToDate, int nStatus, string sBarcodeSL, bool IsCheck, string sDefectiveNo, string sProductCode, string sProductName, int nStockStatus, int nDefectiveType)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "Select DefectiveID, DefectiveNo, a.WarehouseID,  " +
                    "ShowroomCode, a.ProductID, ProductCode, ProductName, AGName, ASGName,    " +
                    "MAGName, PGName, BrandDesc, BarcodeSL, OriginalSL, DefectiveType, Fault, Reason, isnull(a.Remarks, '') Remarks,    " +
                    "ProposeDicAmount, a.Status, a.CreateUserID, a.CreateDate, isnull(RefTranNo, '') RefTranNo,    " +
                    "RefTranDate, isnull(ApproveDicAmount, 0) ApproveDicAmount, isnull(a.JobNo,'') JobNo,    " +
                    "isnull(ApproveBy, -1) ApproveBy, ApproveDate, isnull(RefInvoiceNo, '') RefInvoiceNo,    " +
                    "RefInvoiceDate, isnull(DefectiveCategory, -1) DefectiveCategory, isnull(AssessmentFindings, '') AssessmentFindings,    " +
                    "isnull(IsRepairable, -1) IsRepairable, isnull(Accessories, '') Accessories,    " +
                    "isnull(TechRecommandation, -1) TechRecommandation, isnull(TechRemarks, '') TechRemarks,    " +
                    "isnull(IsLocallySaleable, '') IsLocallySaleable, isnull(PaneltyAmount, 0) PaneltyAmount,isnull(IsLocallyRepaired, -1) IsLocallyRepaired,isnull(RepairStatus, '') RepairStatus, isnull(IsPenaltyApplicable,0) IsPenaltyApplicable, d.Status as StockStatus,  " +
                    "isnull(IsDefectiveAcknowledged,0) IsDefectiveAcknowledged,isnull(AcknowledgmentRemarks, '') AcknowledgmentRemarks,ExpSalesDate,isnull(FromWH, -1) FromWH,isnull(ToWH, -1) ToWH  " +
                    "From t_UnsoldDefectiveProduct a, t_Showroom b, v_ProductDetails c, t_ProductStockSerial d  " +
                    "where a.WarehouseID = b.WarehouseID and a.ProductID = C.ProductID and a.BarcodeSL = d.ProductSerialNo and b.WarehouseID=" + Utility.WarehouseID + "";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " and a.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and a.CreateDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }
            if (nDefectiveType != 0)
            {
                sSql = sSql + " AND a.DefectiveType=" + nDefectiveType + "";
            }

            if (nStockStatus != -1)
            {
                sSql = sSql + " AND d.Status=" + nStockStatus + "";
            }
            if (sBarcodeSL != "")
            {
                sSql = sSql + " AND BarcodeSL like '%" + sBarcodeSL + "%'";
            }
            if (sDefectiveNo != "")
            {
                sSql = sSql + " AND DefectiveNo  like '%" + sDefectiveNo + "%'";
            }
            if (sProductCode != "")
            {
                sSql = sSql + " AND ProductCode  like '%" + sProductCode + "%'";
            }
            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName  like '%" + sProductName + "%'";
            }
            sSql = sSql + " Order by DefectiveID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UnsoldDefectiveProduct oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                    oUnsoldDefectiveProduct.StockStatus = (int)reader["StockStatus"];
                    oUnsoldDefectiveProduct.DefectiveID = (int)reader["DefectiveID"];
                    oUnsoldDefectiveProduct.DefectiveNo = (string)reader["DefectiveNo"];
                    oUnsoldDefectiveProduct.WarehouseID = (int)reader["WarehouseID"];
                    oUnsoldDefectiveProduct.ShowroomCode = (string)reader["ShowroomCode"];
                    oUnsoldDefectiveProduct.ProductID = (int)reader["ProductID"];
                    oUnsoldDefectiveProduct.ProductCode = (string)reader["ProductCode"];
                    oUnsoldDefectiveProduct.ProductName = (string)reader["ProductName"];
                    oUnsoldDefectiveProduct.AGName = (string)reader["AGName"];
                    oUnsoldDefectiveProduct.ASGName = (string)reader["ASGName"];
                    oUnsoldDefectiveProduct.MAGName = (string)reader["MAGName"];
                    oUnsoldDefectiveProduct.PGName = (string)reader["PGName"];
                    oUnsoldDefectiveProduct.BrandDesc = (string)reader["BrandDesc"];
                    oUnsoldDefectiveProduct.BarcodeSL = (string)reader["BarcodeSL"];
                    if (reader["OriginalSL"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.OriginalSL = (string)reader["OriginalSL"];
                    }
                    oUnsoldDefectiveProduct.DefectiveType = (int)reader["DefectiveType"];
                    oUnsoldDefectiveProduct.Fault = (string)reader["Fault"];
                    oUnsoldDefectiveProduct.Reason = (string)reader["Reason"];
                    oUnsoldDefectiveProduct.Remarks = (string)reader["Remarks"];
                    oUnsoldDefectiveProduct.ProposeDicAmount = Convert.ToDouble(reader["ProposeDicAmount"].ToString());
                    oUnsoldDefectiveProduct.Status = (int)reader["Status"];
                    oUnsoldDefectiveProduct.CreateUserID = (int)reader["CreateUserID"];
                    oUnsoldDefectiveProduct.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oUnsoldDefectiveProduct.RefTranNo = (string)reader["RefTranNo"];
                    if (reader["RefTranDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.RefTranDate = Convert.ToDateTime(reader["RefTranDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.RefTranDate = "";
                    }

                    if (reader["ApproveDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.ApproveDate = "";
                    }
                    if (reader["RefInvoiceDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.RefInvoiceDate = Convert.ToDateTime(reader["RefInvoiceDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.RefInvoiceDate = "";
                    }
                    oUnsoldDefectiveProduct.JobNo = (string)reader["JobNo"];
                    //oUnsoldDefectiveProduct.IsCreateJob = (string)reader["IsCreateJob"];
                    oUnsoldDefectiveProduct.ApproveDicAmount = Convert.ToDouble(reader["ApproveDicAmount"].ToString());
                    oUnsoldDefectiveProduct.ApproveBy = (int)reader["ApproveBy"];
                    oUnsoldDefectiveProduct.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    oUnsoldDefectiveProduct.DefectiveCategory = (int)reader["DefectiveCategory"];
                    oUnsoldDefectiveProduct.AssessmentFindings = (string)reader["AssessmentFindings"];
                    oUnsoldDefectiveProduct.IsRepairable = (int)reader["IsRepairable"];
                    oUnsoldDefectiveProduct.Accessories = (string)reader["Accessories"];
                    oUnsoldDefectiveProduct.TechRecommandation = (int)reader["TechRecommandation"];
                    oUnsoldDefectiveProduct.TechRemarks = (string)reader["TechRemarks"];
                    oUnsoldDefectiveProduct.IsLocallySaleable = (int)reader["IsLocallySaleable"];
                    oUnsoldDefectiveProduct.PaneltyAmount = Convert.ToDouble(reader["PaneltyAmount"].ToString());
                    oUnsoldDefectiveProduct.RepairStatus = (string)reader["RepairStatus"];
                    oUnsoldDefectiveProduct.IsPenaltyApplicable = (int)reader["IsPenaltyApplicable"];
                    oUnsoldDefectiveProduct.IsLocallyRepaired = (int)reader["IsLocallyRepaired"];


                    oUnsoldDefectiveProduct.IsDefectiveAcknowledged = (int)reader["IsDefectiveAcknowledged"];
                    oUnsoldDefectiveProduct.AcknowledgmentRemarks = (string)reader["AcknowledgmentRemarks"];
                    oUnsoldDefectiveProduct.FromWH = (int)reader["FromWH"];
                    oUnsoldDefectiveProduct.ToWH = (int)reader["ToWH"];
                    if (reader["ExpSalesDate"] != DBNull.Value)
                    {
                        oUnsoldDefectiveProduct.ExpSalesDate = Convert.ToDateTime(reader["ExpSalesDate"].ToString());
                    }
                    else
                    {
                        oUnsoldDefectiveProduct.ExpSalesDate = "";
                    }

                    InnerList.Add(oUnsoldDefectiveProduct);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void LoadDataForReport(string sDefectiveNo, string sBarcodeSL, int nStatus, int nStockStatus,int nDefectiveType,bool IsCurrentDefective)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = "Select DefectiveID,DefectiveNo,'['+ProductCode+'] '+ProductName as ProductName,BarcodeSL,OriginalSL,DefectiveType, " +
                    "isnull(Fault, '') Fault,isnull(Reason, '') Reason,isnull(Remarks, '') Remarks,a.Status,c.Status as StockStatus, " +
                    "isnull(ProposeDicAmount, 0) ProposeDicAmount,isnull(ApproveDicAmount, 0) ApproveDicAmount, " +
                    "isnull(PaneltyAmount, 0) PaneltyAmount, isnull(RefTranNo, '') RefTranNo,isnull(JobNo, '') JobNo, " +
                    "isnull(RefInvoiceNo, '') RefInvoiceNo,isnull(DefectiveCategory, -1) DefectiveCategory, " +
                    "isnull(AssessmentFindings, '') AssessmentFindings,isnull(Accessories, '') Accessories,isnull(TechRecommandation, -1) TechRecommandation,CreateDate " +
                    "From dbo.t_UnsoldDefectiveProduct a, t_Product b,t_ProductStockSerial c " +
                    "where a.ProductID = b.ProductID and a.BarcodeSL = c.ProductSerialNo";

            }

            if (sDefectiveNo != "")
            {
                sSql = sSql + " AND DefectiveNo  like '%" + sDefectiveNo + "%'";
            }

            if (sBarcodeSL != "")
            {
                sSql = sSql + " AND BarcodeSL like '%" + sBarcodeSL + "%'";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }

            if (nStockStatus != -1)
            {
                sSql = sSql + " AND c.Status=" + nStockStatus + "";
            }

            if (nDefectiveType != 0)
            {
                sSql = sSql + " AND a.DefectiveType=" + nDefectiveType + "";
            }
            if (IsCurrentDefective == true)
            {
                sSql = sSql + " AND c.Status=1";
            }
            sSql = sSql + " Order by DefectiveID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UnsoldDefectiveProduct oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();

                    oUnsoldDefectiveProduct.DefectiveID = int.Parse(reader["DefectiveID"].ToString());
                    oUnsoldDefectiveProduct.DefectiveNo = (reader["DefectiveNo"].ToString());
                    oUnsoldDefectiveProduct.ProductName = (reader["ProductName"].ToString());
                    oUnsoldDefectiveProduct.BarcodeSL = (reader["BarcodeSL"].ToString());
                    oUnsoldDefectiveProduct.OriginalSL = (reader["OriginalSL"].ToString());
                    oUnsoldDefectiveProduct.Fault = (reader["Fault"].ToString());
                    oUnsoldDefectiveProduct.DefectiveType = int.Parse(reader["DefectiveType"].ToString());
                    oUnsoldDefectiveProduct.DefectiveTypeName = Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), oUnsoldDefectiveProduct.DefectiveType);
                    oUnsoldDefectiveProduct.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oUnsoldDefectiveProduct.Status = int.Parse(reader["Status"].ToString());
                    oUnsoldDefectiveProduct.StatusName = Enum.GetName(typeof(Dictionary.POSUnsouldDefectiveProductStatus), oUnsoldDefectiveProduct.Status);
                    oUnsoldDefectiveProduct.StockStatus = int.Parse(reader["StockStatus"].ToString());
                    oUnsoldDefectiveProduct.StockStatusName = Enum.GetName(typeof(Dictionary.ProductSerialStatus), oUnsoldDefectiveProduct.StockStatus);
                    oUnsoldDefectiveProduct.Fault = (reader["Fault"].ToString());
                    oUnsoldDefectiveProduct.Reason = (reader["Reason"].ToString());
                    oUnsoldDefectiveProduct.Remarks = (reader["Remarks"].ToString());
                    oUnsoldDefectiveProduct.ProposeDicAmount = Convert.ToDouble(reader["ProposeDicAmount"].ToString());
                    oUnsoldDefectiveProduct.JobNo = (reader["JobNo"].ToString());
                    oUnsoldDefectiveProduct.ApproveDicAmount = Convert.ToDouble(reader["ApproveDicAmount"].ToString());
                    oUnsoldDefectiveProduct.RefInvoiceNo = (reader["RefInvoiceNo"].ToString());
                    oUnsoldDefectiveProduct.RefTranNo = (reader["RefTranNo"].ToString());
                    oUnsoldDefectiveProduct.PaneltyAmount = Convert.ToDouble(reader["PaneltyAmount"].ToString());
                    try
                    {
                        oUnsoldDefectiveProduct.DefectiveCategory = Enum.GetName(typeof(Dictionary.UnsouldDefectiveCategory), int.Parse(reader["DefectiveCategory"].ToString()));
                    }
                    catch
                    {
                        oUnsoldDefectiveProduct.DefectiveCategory = "";
                    }
                    try
                    {
                        oUnsoldDefectiveProduct.TechRecommandation = Enum.GetName(typeof(Dictionary.UnsouldDefectiveTechRecommandation), int.Parse(reader["TechRecommandation"].ToString()));
                    }
                    catch
                    {
                        oUnsoldDefectiveProduct.TechRecommandation = "";
                    }
                    oUnsoldDefectiveProduct.Accessories = (reader["Accessories"].ToString());
                    oUnsoldDefectiveProduct.AssessmentFindings = (reader["AssessmentFindings"].ToString());


                    InnerList.Add(oUnsoldDefectiveProduct);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void LoadDataForReportRT(string sDefectiveNo, string sBarcodeSL, int nStatus, int nStockStatus, int nDefectiveType, bool IsCurrentDefective)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = "Select DefectiveID,DefectiveNo,'['+ProductCode+'] '+ProductName as ProductName,BarcodeSL,OriginalSL,DefectiveType, " +
                    "isnull(Fault, '') Fault,isnull(Reason, '') Reason,isnull(Remarks, '') Remarks,a.Status,c.Status as StockStatus, " +
                    "isnull(ProposeDicAmount, 0) ProposeDicAmount,isnull(ApproveDicAmount, 0) ApproveDicAmount, " +
                    "isnull(PaneltyAmount, 0) PaneltyAmount, isnull(RefTranNo, '') RefTranNo,isnull(JobNo, '') JobNo, " +
                    "isnull(RefInvoiceNo, '') RefInvoiceNo,isnull(DefectiveCategory, -1) DefectiveCategory, " +
                    "isnull(AssessmentFindings, '') AssessmentFindings,isnull(Accessories, '') Accessories,isnull(TechRecommandation, -1) TechRecommandation,CreateDate " +
                    "From dbo.t_UnsoldDefectiveProduct a, t_Product b,t_ProductStockSerial c " +
                    "where a.ProductID = b.ProductID and a.BarcodeSL = c.ProductSerialNo and a.WarehouseID=" + Utility.WarehouseID + "";

            }

            if (sDefectiveNo != "")
            {
                sSql = sSql + " AND DefectiveNo  like '%" + sDefectiveNo + "%'";
            }

            if (sBarcodeSL != "")
            {
                sSql = sSql + " AND BarcodeSL like '%" + sBarcodeSL + "%'";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }

            if (nStockStatus != -1)
            {
                sSql = sSql + " AND c.Status=" + nStockStatus + "";
            }

            if (nDefectiveType != 0)
            {
                sSql = sSql + " AND a.DefectiveType=" + nDefectiveType + "";
            }
            if (IsCurrentDefective == true)
            {
                sSql = sSql + " AND c.Status=1";
            }
            sSql = sSql + " Order by DefectiveID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UnsoldDefectiveProduct oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();

                    oUnsoldDefectiveProduct.DefectiveID = int.Parse(reader["DefectiveID"].ToString());
                    oUnsoldDefectiveProduct.DefectiveNo = (reader["DefectiveNo"].ToString());
                    oUnsoldDefectiveProduct.ProductName = (reader["ProductName"].ToString());
                    oUnsoldDefectiveProduct.BarcodeSL = (reader["BarcodeSL"].ToString());
                    oUnsoldDefectiveProduct.OriginalSL = (reader["OriginalSL"].ToString());
                    oUnsoldDefectiveProduct.Fault = (reader["Fault"].ToString());
                    oUnsoldDefectiveProduct.DefectiveType = int.Parse(reader["DefectiveType"].ToString());
                    oUnsoldDefectiveProduct.DefectiveTypeName = Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), oUnsoldDefectiveProduct.DefectiveType);
                    oUnsoldDefectiveProduct.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oUnsoldDefectiveProduct.Status = int.Parse(reader["Status"].ToString());
                    oUnsoldDefectiveProduct.StatusName = Enum.GetName(typeof(Dictionary.POSUnsouldDefectiveProductStatus), oUnsoldDefectiveProduct.Status);
                    oUnsoldDefectiveProduct.StockStatus = int.Parse(reader["StockStatus"].ToString());
                    oUnsoldDefectiveProduct.StockStatusName = Enum.GetName(typeof(Dictionary.ProductSerialStatus), oUnsoldDefectiveProduct.StockStatus);
                    oUnsoldDefectiveProduct.Fault = (reader["Fault"].ToString());
                    oUnsoldDefectiveProduct.Reason = (reader["Reason"].ToString());
                    oUnsoldDefectiveProduct.Remarks = (reader["Remarks"].ToString());
                    oUnsoldDefectiveProduct.ProposeDicAmount = Convert.ToDouble(reader["ProposeDicAmount"].ToString());
                    oUnsoldDefectiveProduct.JobNo = (reader["JobNo"].ToString());
                    oUnsoldDefectiveProduct.ApproveDicAmount = Convert.ToDouble(reader["ApproveDicAmount"].ToString());
                    oUnsoldDefectiveProduct.RefInvoiceNo = (reader["RefInvoiceNo"].ToString());
                    oUnsoldDefectiveProduct.RefTranNo = (reader["RefTranNo"].ToString());
                    oUnsoldDefectiveProduct.PaneltyAmount = Convert.ToDouble(reader["PaneltyAmount"].ToString());
                    try
                    {
                        oUnsoldDefectiveProduct.DefectiveCategory = Enum.GetName(typeof(Dictionary.UnsouldDefectiveCategory), int.Parse(reader["DefectiveCategory"].ToString()));
                    }
                    catch
                    {
                        oUnsoldDefectiveProduct.DefectiveCategory = "";
                    }
                    try
                    {
                        oUnsoldDefectiveProduct.TechRecommandation = Enum.GetName(typeof(Dictionary.UnsouldDefectiveTechRecommandation), int.Parse(reader["TechRecommandation"].ToString()));
                    }
                    catch
                    {
                        oUnsoldDefectiveProduct.TechRecommandation = "";
                    }
                    oUnsoldDefectiveProduct.Accessories = (reader["Accessories"].ToString());
                    oUnsoldDefectiveProduct.AssessmentFindings = (reader["AssessmentFindings"].ToString());


                    InnerList.Add(oUnsoldDefectiveProduct);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void UnsoldDefectiveReport(DateTime dDFromDate, DateTime dDToDate, string sQueryExpr)//(int nWarehouseGroupID, int nWarehouseParentID, int nWarehouseID, int nPGID, int nMAGID, int nASGID, int nAGID, int nBrandID, string sProductCode, string sProductDesc)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = String.Format(@"Select * From 
                        (
                        Select PGID,MAGID,ASGID,AGID,BrandID,ProductType,vp.IsActive,main.WarehouseID,WarehouseParentID,WarehouseGroupName,WarehouseGroupID,
                        WarehouseParentName,case WarehouseParentID when 7 then ShortCode else  '['+WarehouseCode+'] '+WarehouseName end as Warehouse,
                        main.ProductID,PGName,MAGName,ASGName,AGName,BrandDesc,ProductCode,ProductName,
                        sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty) as OpeningStock,
                        (sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty))* CostPrice as OpeningStockValue,
                        sum(TranStockIn) TranStockIn,sum(TranStockOut) TranStockOut,
                        (sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty))+sum(TranStockIn)-sum(TranStockOut) as ClosingStock,
                        ((sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty))+sum(TranStockIn)-sum(TranStockOut))*CostPrice as ClosingStockValue,
                        sum(CurrentStock) CurrentStock
                        From 
                        (
                        ----Current Stock----
                        Select WHID as WarehouseID,ProductID,0 StockInQty,0 StockOutQty,0 as TranStockIn,0 as TranStockOut,count(ProductSerialNo) CurrentStock 
                        From t_ProductStockSerialHO 
                        group by WHID,ProductID
                        ----END Current Stock----
                        Union All
                        ---Opening Stock Tran--
                        Select FromWHID as WarehouseID,ProductID,0 as StockInQty,count(ProductSerialNo) as StockOutQty,0 as TranStockIn,0 as TranStockOut,0 CurrentStock 
                        From t_ProductStockTran a,t_ProductTransferProductSerial b 
                        where a.TranID=b.TranID and TranTypeID<>5 and TranDate between '{0}' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy')
                        group by FromWHID,ProductID
                        Union All
                        Select WarehouseID,ProductID,
                        count(ProductSerialNo) as StockInQty, 0 as StockOutQty,0 as TranStockIn,
                        0 as TranStockOut,0 as CurrentStock  From t_SalesInvoice a,t_SalesInvoiceProductSerial b 
                        where a.RefInvoiceID=b.InvoiceID and InvoiceTypeID in (6,7,8,9,10,11,12,16) 
                        and InvoiceDate between '{0}' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and InvoiceDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy')
                        group by WarehouseID,ProductID
                        Union All
                        Select WarehouseID,ProductID,
                        0 as StockInQty, count(ProductSerialNo) as StockOutQty,0 as TranStockIn,
                        0 as TranStockOut,0 as CurrentStock  From t_SalesInvoice a,t_SalesInvoiceProductSerial b 
                        where a.InvoiceID=b.InvoiceID and InvoiceTypeID not in (6,7,8,9,10,11,12,16) 
                        and InvoiceDate between '{0}' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and InvoiceDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy')
                        group by WarehouseID,ProductID
                        Union All
                        Select ToWHID as WarehouseID,ProductID,count(ProductSerialNo) as StockInQty,0 as StockOutQty,0 as TranStockIn,0 as TranStockOut,0 CurrentStock 
                        From t_ProductStockTran a,t_ProductTransferProductSerial b 
                        where a.TranID=b.TranID and TranTypeID<>5 and TranDate between '{0}' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy')
                        group by ToWHID,ProductID
                        ---End Opening Stock Tran--
                        Union All
                        ---Tran--
                        Select FromWHID as WarehouseID,ProductID,0 as StockInQty,0 as StockOutQty,
                        0 as TranStockIn,count(ProductSerialNo) as TranStockOut,0 as CurrentStock
                        From t_ProductStockTran a,t_ProductTransferProductSerial b 
                        where a.TranID=b.TranID and TranTypeID<>5 and TranDate between '{0}' 
                        and '{1}' and TranDate<'{1}'
                        group by FromWHID,ProductID
                        Union All
                        Select WarehouseID,ProductID,
                        0 as StockInQty, 0 as StockOutQty,count(ProductSerialNo) as TranStockIn,
                        0 as TranStockOut,0 as CurrentStock  From t_SalesInvoice a,t_SalesInvoiceProductSerial b 
                        where a.RefInvoiceID=b.InvoiceID and InvoiceTypeID in (6,7,8,9,10,11,12,16) 
                        and InvoiceDate between '{0}' 
                        and '{1}' and InvoiceDate<'{1}'
                        group by WarehouseID,ProductID
                        Union All
                        Select WarehouseID,ProductID,
                        0 as StockInQty, 0 as StockOutQty,0 as TranStockIn,
                        count(ProductSerialNo) as TranStockOut,0 as CurrentStock  From t_SalesInvoice a,t_SalesInvoiceProductSerial b 
                        where a.InvoiceID=b.InvoiceID and InvoiceTypeID not in (6,7,8,9,10,11,12,16) 
                        and InvoiceDate between '{0}' 
                        and '{1}' and InvoiceDate<'{1}'
                        group by WarehouseID,ProductID
                        Union All
                        Select ToWHID as WarehouseID,ProductID,0 as StockInQty,0 as StockOutQty,count(ProductSerialNo) as TranStockIn,0 as TranStockOut,0 as CurrentStock
                        From t_ProductStockTran a,t_ProductTransferProductSerial b 
                        where a.TranID=b.TranID and TranTypeID<>5 and TranDate between '{0}' and '{1}' and TranDate<'{1}'
                        group by ToWHID,ProductID
                        ---End Tran--
                        ) Main , v_productdetails vp, v_WarehouseDetails wh 
                        where (main.productid=vp.productid) and main.WarehouseID=wh.WarehouseID 
                        and main.warehouseid<>1

                        group by case WarehouseParentID when 7 then ShortCode else  '['+WarehouseCode+'] '+WarehouseName end,
                        main.ProductID,PGName,MAGName,ASGName,AGName,BrandDesc,ProductCode,ProductName,CostPrice,
                        WarehouseGroupName,WarehouseParentName,PGID,MAGID,ASGID,AGID,BrandID,ProductType,vp.IsActive,main.WarehouseID,WarehouseParentID,WarehouseGroupName,WarehouseGroupID

                        ) Final where 1=1 ", dDFromDate, dDToDate);

            if (sQueryExpr != "")
            {
                sSql= sSql + sQueryExpr;
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UnsoldDefectiveProduct oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();

                    oUnsoldDefectiveProduct.WarehouseGroupName = reader["WarehouseGroupName"].ToString();
                    oUnsoldDefectiveProduct.WarehouseParentName = (reader["WarehouseParentName"].ToString());
                    oUnsoldDefectiveProduct.Warehouse = (reader["Warehouse"].ToString());
                    oUnsoldDefectiveProduct.PGName = (reader["PGName"].ToString());
                    oUnsoldDefectiveProduct.MAGName = (reader["MAGName"].ToString());
                    oUnsoldDefectiveProduct.ASGName = (reader["ASGName"].ToString());
                    oUnsoldDefectiveProduct.AGName = (reader["AGName"].ToString());
                    oUnsoldDefectiveProduct.BrandDesc = (reader["BrandDesc"].ToString());
                    oUnsoldDefectiveProduct.ProductCode = (reader["ProductCode"].ToString());
                    oUnsoldDefectiveProduct.ProductName = (reader["ProductName"].ToString());
                    oUnsoldDefectiveProduct.ProductID = int.Parse(reader["ProductID"].ToString());
                    oUnsoldDefectiveProduct.OpeningStock = int.Parse(reader["OpeningStock"].ToString());
                    oUnsoldDefectiveProduct.OpeningStockValue = double.Parse(reader["OpeningStockValue"].ToString());
                    oUnsoldDefectiveProduct.TranStockIn = int.Parse(reader["TranStockIn"].ToString());
                    oUnsoldDefectiveProduct.TranStockOut = int.Parse(reader["TranStockOut"].ToString());
                    oUnsoldDefectiveProduct.ClosingStock = int.Parse(reader["ClosingStock"].ToString());
                    oUnsoldDefectiveProduct.ClosingStockValue = double.Parse(reader["ClosingStockValue"].ToString());
                    oUnsoldDefectiveProduct.CurrentStock = int.Parse(reader["CurrentStock"].ToString());
                    

                    InnerList.Add(oUnsoldDefectiveProduct);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public void GetStockPositionForVAT(DateTime dFromDate, DateTime dToDate, int nWarehouseParentID, int nWarehouseID, int nPGID, int nMAGID, int nASGID, int nAGID, int nBrandID, int nProductID,string sReportType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sReportType == "Excluded Inter Tran")
            {
                sSql = "Select * From " +
                    "( " +
                    "Select WarehouseGroupID,WarehouseGroupName,WarehouseParentID,WarehouseParentName,Main.WarehouseID,case WarehouseParentID when 7 then ShortCode else  WarehouseName end as Warehouse, " +
                    "main.ProductID,PGID,PGName,MAGID,MAGName,ASGID,ASGName,AGID,AGName,BrandID,BrandDesc,ProductCode,ProductName,isnull(TradePrice,0) TradePrice, " +
                    "isnull(VAT,0) VATPercent,sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty) as OpeningStock, " +
                    "(sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty))* isnull(CostPrice,0) as OpeningStockValue, " +
                    "sum(TranStockInQty) InQty,sum(TranStockInQty)*isnull(TradePrice,0) as InValue,sum(TranStockInQty)*isnull(TradePrice,0)*isnull(VAT,0) as InVatAmount, " +
                    "sum(TranStockOutQty) OutQty,sum(TranStockOutQty)*isnull(TradePrice,0) as OutValue,sum(TranStockOutQty)*isnull(TradePrice,0)*isnull(VAT,0) as OutVatAmount, " +
                    "(sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty))+sum(TranStockInQty)-sum(TranStockOutQty) as ClosingStock, " +
                    "((sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty))+sum(TranStockInQty)-sum(TranStockOutQty))*isnull(TradePrice,0) as ClosingStockValue,sum(CurrentStock) CurrentStock " +
                    "From  " +
                    "( " +
                    //--For Opening Stock---
                    "Select WarehouseID,ProductID,0 StockInQty,0 StockOutQty,0 as TranStockInQty,0 as TranStockOutQty,CurrentStock From t_ProductStock  " +
                    "Union All " +
                    //-- -Invoice---
                    "Select WarehouseID,ProductID,0 as StockInQty,case when InvoiceTypeID in (6,7,8,9,10,11,12,16) then sum(Quantity+FreeQty)*-1 else sum(Quantity+FreeQty) end as StockOutQty, " +
                    "0 as TranStockInQty,0 as TranStockOutQty,0 CurrentStock  " +
                    "From t_SalesInvoice a,t_SalesInvoiceDetail b  " +
                    "where a.InvoiceID=b.InvoiceID and InvoiceStatus not in (1,3,5,6,8) and InvoiceDate between '" + dFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and InvoiceDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                    "group by WarehouseID,ProductID,InvoiceTypeID,InvoiceNo,InvoiceDate " +
                    //--_End Invoice---
                    "Union All " +
                    "Select FromWHID,ProductID,0 as StockInQty,Qty as StockOutQty,0 as TranStockInQty,0 as TranStockOutQty,0 CurrentStock  " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b " +
                    "where a.TranID=b.TranID and TranDate between '" + dFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                    "and a.Status=1 and TranTypeID<>5 " +
                    "Union All " +
                    "Select ToWHID,ProductID,Qty as StockInQty,0 as StockOutQty,0 as TranStockInQty,0 as TranStockOutQty,0 CurrentStock " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b " +
                    "where a.TranID=b.TranID and TranDate between '" + dFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                    "and a.Status=1 and TranTypeID<>5 " +
                    //--End Opening Stock---
                    "Union All " +
                    //-- -For Tran Data--
                    //---Invoice Out---
                    "Select WarehouseID,ProductID,0 StockInQty,0 StockOutQty,0 as TranStockInQty,sum(Quantity+FreeQty) as TranStockOutQty,0 CurrentStock  " +
                    "From t_SalesInvoice a,t_SalesInvoiceDetail b  " +
                    "where a.InvoiceID=b.InvoiceID and  InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "' " +
                    "and InvoiceTypeID not in (6,7,8,9,10,11,12,16) and InvoiceStatus not in (1,3,5,6,8) " +
                    "group by WarehouseID,ProductID,InvoiceTypeID,InvoiceNo,InvoiceDate " +
                    //--End Invoice Out---
                    "Union All " +
                    //-- -Invoice In---
                    "Select WarehouseID,ProductID,0 StockInQty,0 StockOutQty,sum(Quantity+FreeQty) as TranStockInQty,0 as TranStockOutQty,0 CurrentStock  " +
                    "From t_SalesInvoice a,t_SalesInvoiceDetail b  " +
                    "where a.InvoiceID=b.InvoiceID and  InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "' " +
                    "and InvoiceTypeID in (6,7,8,9,10,11,12,16) and InvoiceStatus not in (1,3,5,6,8) " +
                    "group by WarehouseID,ProductID,InvoiceTypeID,InvoiceNo,InvoiceDate " +
                    //--End Invoice In---
                    "Union All " +
                    //--Out--
                    "Select FromWHID,ProductID,0 StockInQty,0 StockOutQty,0 as TranStockInQty,Qty as TranStockOutQty,0 CurrentStock  " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b " +
                    "where a.TranID=b.TranID and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' " +
                    "and a.Status=1 and TranTypeID<>5 " +
                    "and a.TranID not in (Select TranID From t_ProductStockTran a,t_Warehouse b,t_Warehouse c " +
                    "where a.FromWHID=b.WarehouseID and a.ToWHID=c.WarehouseID  " +
                    "and b.WarehouseParentID=c.WarehouseParentID and b.WarehouseParentID<>7 and c.WarehouseParentID<>7) " +
                    //--END OUT--
                    "Union All " +
                    //--In--
                    "Select ToWHID,ProductID,0 StockInQty,0 StockOutQty,Qty as TranStockInQty,0 as TranStockOutQty,0 CurrentStock " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b " +
                    "where a.TranID=b.TranID and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' " +
                    "and a.Status=1 and TranTypeID<>5 " +
                    "and a.TranID not in (Select TranID From t_ProductStockTran a,t_Warehouse b,t_Warehouse c " +
                    "where a.FromWHID=b.WarehouseID and a.ToWHID=c.WarehouseID  " +
                    "and b.WarehouseParentID=c.WarehouseParentID and b.WarehouseParentID<>7 and c.WarehouseParentID<>7) " +
                    //--END In--
                    //---End For Tran Data--
                    ") Main , v_productdetails vp, v_WarehouseDetails wh where (main.productid=vp.productid) and main.WarehouseID=wh.WarehouseID and main.warehouseid<>1 " +
                    "and vp.VATApplicable=1 " +
                    "group by case WarehouseParentID when 7 then ShortCode else  WarehouseName end,main.ProductID,PGID,PGName,MAGID,MAGName,ASGID,ASGName,AGID,AGName,BrandID,BrandDesc,ProductCode,ProductName,isnull(CostPrice,0),isnull(TradePrice,0), " +
                    "isnull(VAT,0),WarehouseGroupID,WarehouseGroupName,WarehouseParentID,WarehouseParentName,Main.WarehouseID " +
                    ") RAWData where OpeningStock+InQty+OutQty<>0";

                if (nWarehouseParentID != -1)
                {
                    sSql = sSql + " and WarehouseParentID=" + nWarehouseParentID + "";
                }
                if (nWarehouseID != -1)
                {
                    sSql = sSql + " and WarehouseID=" + nWarehouseID + "";
                }
                //if (nWarehouseGroupID != -1)
                //{
                //    sSql = sSql + " and WarehouseGroupID=" + nWarehouseGroupID + "";
                //}
                if (nPGID != -1)
                {
                    sSql = sSql + " and PGID=" + nPGID + "";
                }
                if (nMAGID != -1)
                {
                    sSql = sSql + " and MAGID=" + nMAGID + "";
                }
                if (nASGID != -1)
                {
                    sSql = sSql + " and ASGID=" + nASGID + "";
                }
                if (nAGID != -1)
                {
                    sSql = sSql + " and AGID=" + nAGID + "";
                }
                if (nBrandID != -1)
                {
                    sSql = sSql + " and BrandID=" + nBrandID + "";
                }
                if (nProductID != -1)
                {
                    sSql = sSql + " and ProductID=" + nProductID + "";
                }
                sSql = sSql + " order by WarehouseID,ProductCode ";
            }
            else
            {
                sSql = "Select * From " +
                    "( " +
                    "Select WarehouseGroupID,WarehouseGroupName,WarehouseParentID,WarehouseParentName,Main.WarehouseID,case WarehouseParentID when 7 then ShortCode else  WarehouseName end as Warehouse, " +
                    "main.ProductID,PGID,PGName,MAGID,MAGName,ASGID,ASGName,AGID,AGName,BrandID,BrandDesc,ProductCode,ProductName,isnull(TradePrice,0) TradePrice, " +
                    "isnull(VAT,0) VATPercent,sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty) as OpeningStock, " +
                    "(sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty))* isnull(CostPrice,0) as OpeningStockValue, " +
                    "sum(TranStockInQty) InQty,sum(TranStockInQty)*isnull(TradePrice,0) as InValue,sum(TranStockInQty)*isnull(TradePrice,0)*isnull(VAT,0) as InVatAmount, " +
                    "sum(TranStockOutQty) OutQty,sum(TranStockOutQty)*isnull(TradePrice,0) as OutValue,sum(TranStockOutQty)*isnull(TradePrice,0)*isnull(VAT,0) as OutVatAmount, " +
                    "(sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty))+sum(TranStockInQty)-sum(TranStockOutQty) as ClosingStock, " +
                    "((sum(CurrentStock)+sum(StockOutQty)-sum(StockInQty))+sum(TranStockInQty)-sum(TranStockOutQty))*isnull(TradePrice,0) as ClosingStockValue,sum(CurrentStock) CurrentStock " +
                    "From  " +
                    "( " +
                    //--For Opening Stock---
                    "Select WarehouseID,ProductID,0 StockInQty,0 StockOutQty,0 as TranStockInQty,0 as TranStockOutQty,CurrentStock From t_ProductStock  " +
                    "Union All " +
                    //-- -Invoice---
                    "Select WarehouseID,ProductID,0 as StockInQty,case when InvoiceTypeID in (6,7,8,9,10,11,12,16) then sum(Quantity+FreeQty)*-1 else sum(Quantity+FreeQty) end as StockOutQty, " +
                    "0 as TranStockInQty,0 as TranStockOutQty,0 CurrentStock  " +
                    "From t_SalesInvoice a,t_SalesInvoiceDetail b  " +
                    "where a.InvoiceID=b.InvoiceID and InvoiceStatus not in (1,3,5,6,8) and InvoiceDate between '" + dFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and InvoiceDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                    "group by WarehouseID,ProductID,InvoiceTypeID,InvoiceNo,InvoiceDate " +
                    //--_End Invoice---
                    "Union All " +
                    "Select FromWHID,ProductID,0 as StockInQty,Qty as StockOutQty,0 as TranStockInQty,0 as TranStockOutQty,0 CurrentStock  " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b " +
                    "where a.TranID=b.TranID and TranDate between '" + dFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                    "and a.Status=1 and TranTypeID<>5 " +
                    "Union All " +
                    "Select ToWHID,ProductID,Qty as StockInQty,0 as StockOutQty,0 as TranStockInQty,0 as TranStockOutQty,0 CurrentStock " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b " +
                    "where a.TranID=b.TranID and TranDate between '" + dFromDate + "' and FORMAT(GetDate()+1, 'dd-MMM-yyyy') and TranDate<FORMAT(GetDate()+1, 'dd-MMM-yyyy') " +
                    "and a.Status=1 and TranTypeID<>5 " +
                    //--End Opening Stock---
                    "Union All " +
                    //-- -For Tran Data--
                    //---Invoice Out---
                    "Select WarehouseID,ProductID,0 StockInQty,0 StockOutQty,0 as TranStockInQty,sum(Quantity+FreeQty) as TranStockOutQty,0 CurrentStock  " +
                    "From t_SalesInvoice a,t_SalesInvoiceDetail b  " +
                    "where a.InvoiceID=b.InvoiceID and  InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "' " +
                    "and InvoiceTypeID not in (6,7,8,9,10,11,12,16) and InvoiceStatus not in (1,3,5,6,8) " +
                    "group by WarehouseID,ProductID,InvoiceTypeID,InvoiceNo,InvoiceDate " +
                    //--End Invoice Out---
                    "Union All " +
                    //-- -Invoice In---
                    "Select WarehouseID,ProductID,0 StockInQty,0 StockOutQty,sum(Quantity+FreeQty) as TranStockInQty,0 as TranStockOutQty,0 CurrentStock  " +
                    "From t_SalesInvoice a,t_SalesInvoiceDetail b  " +
                    "where a.InvoiceID=b.InvoiceID and  InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "' " +
                    "and InvoiceTypeID in (6,7,8,9,10,11,12,16) and InvoiceStatus not in (1,3,5,6,8) " +
                    "group by WarehouseID,ProductID,InvoiceTypeID,InvoiceNo,InvoiceDate " +
                    //--End Invoice In---
                    "Union All " +
                    //--Out--
                    "Select FromWHID,ProductID,0 StockInQty,0 StockOutQty,0 as TranStockInQty,Qty as TranStockOutQty,0 CurrentStock  " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b " +
                    "where a.TranID=b.TranID and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' " +
                    "and a.Status=1 and TranTypeID<>5 " +
                    //--END OUT--
                    "Union All " +
                    //--In--
                    "Select ToWHID,ProductID,0 StockInQty,0 StockOutQty,Qty as TranStockInQty,0 as TranStockOutQty,0 CurrentStock " +
                    "From t_ProductStockTran a,t_ProductStockTranItem b " +
                    "where a.TranID=b.TranID and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' " +
                    "and a.Status=1 and TranTypeID<>5 " +
                    //--END In--
                    //---End For Tran Data--
                    ") Main , v_productdetails vp, v_WarehouseDetails wh where (main.productid=vp.productid) and main.WarehouseID=wh.WarehouseID and main.warehouseid<>1 " +
                    "and vp.VATApplicable=1 " +
                    "group by case WarehouseParentID when 7 then ShortCode else  WarehouseName end,main.ProductID,PGID,PGName,MAGID,MAGName,ASGID,ASGName,AGID,AGName,BrandID,BrandDesc,ProductCode,ProductName,isnull(CostPrice,0),isnull(TradePrice,0), " +
                    "isnull(VAT,0),WarehouseGroupID,WarehouseGroupName,WarehouseParentID,WarehouseParentName,Main.WarehouseID " +
                    ") RAWData where OpeningStock+InQty+OutQty<>0";

                if (nWarehouseParentID != -1)
                {
                    sSql = sSql + " and WarehouseParentID=" + nWarehouseParentID + "";
                }
                if (nWarehouseID != -1)
                {
                    sSql = sSql + " and WarehouseID=" + nWarehouseID + "";
                }
                //if (nWarehouseGroupID != -1)
                //{
                //    sSql = sSql + " and WarehouseGroupID=" + nWarehouseGroupID + "";
                //}
                if (nPGID != -1)
                {
                    sSql = sSql + " and PGID=" + nPGID + "";
                }
                if (nMAGID != -1)
                {
                    sSql = sSql + " and MAGID=" + nMAGID + "";
                }
                if (nASGID != -1)
                {
                    sSql = sSql + " and ASGID=" + nASGID + "";
                }
                if (nAGID != -1)
                {
                    sSql = sSql + " and AGID=" + nAGID + "";
                }
                if (nBrandID != -1)
                {
                    sSql = sSql + " and BrandID=" + nBrandID + "";
                }
                if (nProductID != -1)
                {
                    sSql = sSql + " and ProductID=" + nProductID + "";
                }
                sSql = sSql + " order by WarehouseID,ProductCode ";

            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UnsoldDefectiveProduct oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();

                    oUnsoldDefectiveProduct.WarehouseGroupName = reader["WarehouseGroupName"].ToString();
                    oUnsoldDefectiveProduct.WarehouseParentName = (reader["WarehouseParentName"].ToString());
                    oUnsoldDefectiveProduct.Warehouse = (reader["Warehouse"].ToString());
                    oUnsoldDefectiveProduct.PGName = (reader["PGName"].ToString());
                    oUnsoldDefectiveProduct.MAGName = (reader["MAGName"].ToString());
                    oUnsoldDefectiveProduct.ASGName = (reader["ASGName"].ToString());
                    oUnsoldDefectiveProduct.AGName = (reader["AGName"].ToString());
                    oUnsoldDefectiveProduct.BrandDesc = (reader["BrandDesc"].ToString());
                    oUnsoldDefectiveProduct.ProductCode = (reader["ProductCode"].ToString());
                    oUnsoldDefectiveProduct.ProductName = (reader["ProductName"].ToString());
                    oUnsoldDefectiveProduct.ProductID = int.Parse(reader["ProductID"].ToString());
                    oUnsoldDefectiveProduct.OpeningStock = int.Parse(reader["OpeningStock"].ToString());
                    oUnsoldDefectiveProduct.OpeningStockValue = double.Parse(reader["OpeningStockValue"].ToString());
                    oUnsoldDefectiveProduct.VAT = double.Parse(reader["VATPercent"].ToString());
                    oUnsoldDefectiveProduct.TranStockIn = int.Parse(reader["InQty"].ToString());
                    oUnsoldDefectiveProduct.InValue = double.Parse(reader["InValue"].ToString());
                    oUnsoldDefectiveProduct.InVatAmount = double.Parse(reader["InVatAmount"].ToString());

                    oUnsoldDefectiveProduct.TranStockOut = int.Parse(reader["OutQty"].ToString());
                    oUnsoldDefectiveProduct.OutValue = double.Parse(reader["OutValue"].ToString());
                    oUnsoldDefectiveProduct.OutVatAmount = double.Parse(reader["OutVatAmount"].ToString());
                    oUnsoldDefectiveProduct.ClosingStock = int.Parse(reader["ClosingStock"].ToString());
                    oUnsoldDefectiveProduct.ClosingStockValue = double.Parse(reader["ClosingStockValue"].ToString());
                    oUnsoldDefectiveProduct.CurrentStock = int.Parse(reader["CurrentStock"].ToString());


                    InnerList.Add(oUnsoldDefectiveProduct);

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


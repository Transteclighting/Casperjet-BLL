// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Dec 14, 2015
// Time : 04:41 PM
// Description: Class for SalesLead.
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
using CJ.Class.Library;

namespace CJ.Class
{
    public class SalesLead
    {
        SystemInfo oSystemInfo;
        private int _nLeadID;
        private string _sLeadNo;
        private DateTime _dLeadDate;
        private DateTime _dExpExecuteDate;
        private int _nCustomerType;
        private string _sCompanyName;
        private string _sName;
        private string _sAddress;
        private string _sContactNo;
        private string _sEmail;
        private string _sProfession;
        private string _sAgeLevel;
        private string _sIncomLevel;
        private int _nMAGID;
        private int _nBrandID;
        private string _sModelName;
        private DateTime _dNextFollowUpDate;
        private double _LeadAmount;
        private int _nStatus;
        private int _nQty;
        private string _sRemarks;
        private string _sReason;
        private string _sInvoiceNo;
        private object _dtInvoiceDate;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private object _dUpdateDate;
        private int _nUpdateUserID;
        private int _nWarehouseID;
        private string _sShowroomCode;
        private int _nSalesPersonID;
        private int _nTerminal;
        private string _sSalesPerson;
        private int _nConversionPossibility;
        private int _nHistoryID;
        private object _dtCancelDate;

        private string _sChannel;
        private string _sEmployeeCode;
        private string _sEmployeename;
        private double _LeadTarget;
        private double _InitialLead;
        private double _NewLead;
        private double _ShiftedLead;
        private double _CancelledLeadAmt;
        private double _ConverttoSalesAmt;
        private double _TotalLeadAmt;
        private double _ShortFall;
        private int _nInitialLeadQty;
        private double _Achievment;

        private int _nNewLeadQty;
        private int _nShiftedLeadQty;
        private int _nCancelledLeadQty;
        private int _nConverttoSalesQty;
        private int _nTotalLeadQty;
        private int _nIsExistingConsumer;
        private int _nCustomerID;
        private int _nConsumerID;
        private string _sConsumerCode;
        private int _nType;
        private int _nOutboundCallID;
        private int _nLeadSource;
        private string _sActivationName; 
        private int _nIsHVACLead;
        private int _nLeadStatus;
        public int LeadSource
        {
            get { return _nLeadSource; }
            set { _nLeadSource = value; }
        }
        private int _nActivationID;
        public int ActivationID
        {
            get { return _nActivationID; }
            set { _nActivationID = value; }
        }
        public string ActivationName
        {
            get { return _sActivationName; }
            set { _sActivationName = value.Trim(); }
        }
        private DateTime _dtStartDate;
        public DateTime StartDate
        {
            get { return _dtStartDate; }
            set { _dtStartDate = value; }
        }
        private DateTime _dtEndDate;
        public DateTime EndDate
        {
            get { return _dtEndDate; }
            set { _dtEndDate = value; }
        }
        private int _nIsActive;
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        public int IsHVACLead
        {
            get { return _nIsHVACLead; }
            set { _nIsHVACLead = value; }
        }

        public int OutboundCallID
        {
            get { return _nOutboundCallID; }
            set { _nOutboundCallID = value; }
        }

        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }

        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public int ConsumerID
        {
            get { return _nConsumerID; }
            set { _nConsumerID = value; }
        }
        private int _nIsValidLead;
        public int IsValidLead
        {
            get { return _nIsValidLead; }
            set { _nIsValidLead = value; }
        }

        private int _nIsVerified;
        public int IsVerified
        {
            get { return _nIsVerified; }
            set { _nIsVerified = value; }
        }

        public int IsExistingConsumer
        {
            get { return _nIsExistingConsumer; }
            set { _nIsExistingConsumer = value; }
        }
        private string _sRefLeadNo;
        public string RefLeadNo
        {
            get { return _sRefLeadNo; }
            set { _sRefLeadNo = value.Trim(); }
        }
        public string ConsumerCode
        {
            get { return _sConsumerCode; }
            set { _sConsumerCode = value.Trim(); }
        }

        public string Channel
        {
            get { return _sChannel; }
            set { _sChannel = value.Trim(); }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }
        public string Employeename
        {
            get { return _sEmployeename; }
            set { _sEmployeename = value.Trim(); }
        }
        public double LeadTarget
        {
            get { return _LeadTarget; }
            set { _LeadTarget = value; }
        }
        private string _sDistrictName;
        public string DistrictName
        {
            get { return _sDistrictName; }
            set { _sDistrictName = value; }
        }

        private string _sPGName;
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }
        private string _sAGName;
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value; }
        }
        private string _sASGName;
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }

        private string _sThanaName;
        public string ThanaName
        {
            get { return _sThanaName; }
            set { _sThanaName = value; }
        }

        private int _nDistrictID;
        public int DistrictID
        {
            get { return _nDistrictID; }
            set { _nDistrictID = value; }
        }


        private int _nSalesQty;
        public int SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }
        private double _InvoiceAmount;
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }

        private int _nThanaID;
        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        public int InitialLeadQty
        {
            get { return _nInitialLeadQty; }
            set { _nInitialLeadQty = value; }
        }
        public double InitialLead
        {
            get { return _InitialLead; }
            set { _InitialLead = value; }
        }


        public int NewLeadQty
        {
            get { return _nNewLeadQty; }
            set { _nNewLeadQty = value; }
        }
        public double NewLead
        {
            get { return _NewLead; }
            set { _NewLead = value; }
        }

        public int ShiftedLeadQty
        {
            get { return _nShiftedLeadQty; }
            set { _nShiftedLeadQty = value; }
        }
        public double ShiftedLead
        {
            get { return _ShiftedLead; }
            set { _ShiftedLead = value; }
        }


        public int CancelledLeadQty
        {
            get { return _nCancelledLeadQty; }
            set { _nCancelledLeadQty = value; }
        }
        public double CancelledLeadAmt
        {
            get { return _CancelledLeadAmt; }
            set { _CancelledLeadAmt = value; }
        }

        public int ConverttoSalesQty
        {
            get { return _nConverttoSalesQty; }
            set { _nConverttoSalesQty = value; }
        }
        public double ConverttoSalesAmt
        {
            get { return _ConverttoSalesAmt; }
            set { _ConverttoSalesAmt = value; }
        }


        public int TotalLeadQty
        {
            get { return _nTotalLeadQty; }
            set { _nTotalLeadQty = value; }
        }

        public double TotalLeadAmt
        {
            get { return _TotalLeadAmt; }
            set { _TotalLeadAmt = value; }
        }
        public double ShortFall
        {
            get { return _ShortFall; }
            set { _ShortFall = value; }
        }

        public double Achievment
        {
            get { return _Achievment; }
            set { _Achievment = value; }
        }

        public object CancelDate
        {
            get { return _dtCancelDate; }
            set { _dtCancelDate = value; }
        }

        public object InvoiceDate
        {
            get { return _dtInvoiceDate; }
            set { _dtInvoiceDate = value; }
        }

        public int HistoryID
        {
            get { return _nHistoryID; }
            set { _nHistoryID = value; }
        }

        // <summary>
        // Get set property for ConversionPossibility
        // </summary>
        public int ConversionPossibility 

        {
            get { return _nConversionPossibility; }
            set { _nConversionPossibility = value; }
        }

        public string SalesPerson
        {
            get { return _sSalesPerson; }
            set { _sSalesPerson = value.Trim(); }
        }

        // <summary>
        // Get set property for Terminal
        // </summary>
        public int Terminal
        {
            get { return _nTerminal; }
            set { _nTerminal = value; }
        }

        // <summary>
        // Get set property for SalesPersonID
        // </summary>
        public int SalesPersonID
        {
            get { return _nSalesPersonID; }
            set { _nSalesPersonID = value; }
        }


        // <summary>
        // Get set property for InvoiceNo
        // </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }


        // <summary>
        // Get set property for LeadNo
        // </summary>
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
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
        // Get set property for LeadID
        // </summary>
        public int LeadID
        {
            get { return _nLeadID; }
            set { _nLeadID = value; }
        }

        // <summary>
        // Get set property for LeadNo
        // </summary>
        public string LeadNo
        {
            get { return _sLeadNo; }
            set { _sLeadNo = value.Trim(); }
        }

        // <summary>
        // Get set property for LeadDate
        // </summary>
        public DateTime LeadDate
        {
            get { return _dLeadDate; }
            set { _dLeadDate = value; }
        }

        // <summary>
        // Get set property for ExpExecuteDate
        // </summary>
        public DateTime ExpExecuteDate
        {
            get { return _dExpExecuteDate; }
            set { _dExpExecuteDate = value; }
        }

        // <summary>
        // Get set property for CustomerType
        // </summary>
        public int CustomerType
        {
            get { return _nCustomerType; }
            set { _nCustomerType = value; }
        }

        // <summary>
        // Get set property for CompanyName
        // </summary>
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }
        private string _sBrandDesc;
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value.Trim(); }
        }

        private string _sMAGName;
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }

        // <summary>
        // Get set property for Name
        // </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value.Trim(); }
        }

        // <summary>
        // Get set property for Address
        // </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }

        // <summary>
        // Get set property for ContactNo
        // </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Email
        // </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }

        // <summary>
        // Get set property for Profession
        // </summary>
        public string Profession
        {
            get { return _sProfession; }
            set { _sProfession = value.Trim(); }
        }

        // <summary>
        // Get set property for AgeLevel
        // </summary>
        public string AgeLevel
        {
            get { return _sAgeLevel; }
            set { _sAgeLevel = value.Trim(); }
        }

        // <summary>
        // Get set property for IncomLevel
        // </summary>
        public string IncomLevel
        {
            get { return _sIncomLevel; }
            set { _sIncomLevel = value.Trim(); }
        }
        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }

        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }
        private int _nProductID;
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        // <summary>
        // Get set property for MAGID
        // </summary>
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        // <summary>
        // Get set property for BrandID
        // </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        // <summary>
        // Get set property for ModelName
        // </summary>
        public string ModelName
        {
            get { return _sModelName; }
            set { _sModelName = value.Trim(); }
        }

        // <summary>
        // Get set property for NextFollowUpDate
        // </summary>
        public DateTime NextFollowUpDate
        {
            get { return _dNextFollowUpDate; }
            set { _dNextFollowUpDate = value; }
        }

        // <summary>
        // Get set property for LeadAmount
        // </summary>
        public double LeadAmount
        {
            get { return _LeadAmount; }
            set { _LeadAmount = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
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
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
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
        // Get set property for UpdateDate
        // </summary>
        public object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }



        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        public int LeadStatus
        {
            get { return _nLeadStatus; }
            set { _nLeadStatus = value; }
        }

        public void Add()
        {
            int nMaxLeadID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LeadID]) FROM t_SalesLeadManagement";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLeadID = 1;
                }
                else
                {
                    nMaxLeadID = Convert.ToInt32(maxID) + 1;
                }
                _nLeadID = nMaxLeadID;
                sSql = " INSERT INTO t_SalesLeadManagement (LeadID, WarehouseID, LeadNo, LeadDate, ExpExecuteDate, "+
                       " CustomerType, CompanyName, Name, Address, ContactNo, Email, Profession, AgeLevel, IncomLevel, "+
                       " MAGID, BrandID, ModelName, NextFollowUpDate, LeadAmount, Status, Remarks, Reason, CancelDate, "+
                       " InvoiceNo, InvoiceDate, CreateDate, CreateUserID, UpdateDate, UpdateUserID, SalesPersonID, "+
                       " Terminal, ConversionPossibility) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LeadID", _nLeadID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("CustomerType", _nCustomerType);
                cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Profession", _sProfession);
                cmd.Parameters.AddWithValue("AgeLevel", _sAgeLevel);
                cmd.Parameters.AddWithValue("IncomLevel", _sIncomLevel);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("ModelName", _sModelName);
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("LeadAmount", _LeadAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                if (_dtCancelDate != "")
                {
                    cmd.Parameters.AddWithValue("CancelDate", _dtCancelDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CancelDate", null);
                }
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                if (_dtInvoiceDate != "")
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", _dtInvoiceDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", null);
                }
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("ConversionPossibility", _nConversionPossibility);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddForWEB()
        {
            int nMaxLeadID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LeadID]) FROM t_SalesLeadManagement";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLeadID = 1;
                }
                else
                {
                    nMaxLeadID = Convert.ToInt32(maxID) + 1;
                }
                _nLeadID = nMaxLeadID;
                sSql = " INSERT INTO t_SalesLeadManagement (LeadID, WarehouseID, LeadNo, LeadDate, ExpExecuteDate, " +
                       " CustomerType, CompanyName, Name, Address, ContactNo, Email, Profession, AgeLevel, IncomLevel, " +
                       " MAGID, BrandID, ModelName, NextFollowUpDate, LeadAmount, Status, Remarks, Reason, CancelDate, " +
                       " InvoiceNo, InvoiceDate, CreateDate, CreateUserID, UpdateDate, UpdateUserID, SalesPersonID, " +
                       " Terminal, ConversionPossibility, Qty, IsExistingConsumer, RefLeadNo, LeadSource, ActivationID,ProductID,ThanaID,ConsumerID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LeadID", _nLeadID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("CustomerType", _nCustomerType);
                cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Profession", _sProfession);
                cmd.Parameters.AddWithValue("AgeLevel", _sAgeLevel);
                cmd.Parameters.AddWithValue("IncomLevel", _sIncomLevel);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("ModelName", _sModelName);
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("LeadAmount", _LeadAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                if (_dtCancelDate != null)
                {
                    cmd.Parameters.AddWithValue("CancelDate", _dtCancelDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CancelDate", null);
                }
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                if (_dtInvoiceDate != null)
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", _dtInvoiceDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", null);
                }
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                if (_dUpdateDate != null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                }
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("ConversionPossibility", _nConversionPossibility);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("IsExistingConsumer", _nIsExistingConsumer);
                cmd.Parameters.AddWithValue("RefLeadNo", _sRefLeadNo);

                cmd.Parameters.AddWithValue("LeadSource", _nLeadSource);
                cmd.Parameters.AddWithValue("ActivationID", _nActivationID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void AddHistory()
        {
            int nMaxHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([HistoryID]) FROM [t_SalesLeadManagementHistory] where WarehouseID=" + _nWarehouseID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxHistoryID = 1;
                }
                else
                {
                    nMaxHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nHistoryID = nMaxHistoryID;
                sSql = "INSERT INTO t_SalesLeadManagementHistory (HistoryID, LeadNo, WarehouseID, ExpExecuteDate, Remarks, Status, CreateDate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_SalesLeadManagementHistory";
                oDataTran.DataID = Convert.ToInt32(_nHistoryID);
                oDataTran.WarehouseID = _nWarehouseID;
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

        public void AddHistoryRT()
        {
            int nMaxHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([HistoryID]) FROM [t_SalesLeadManagementHistory] where WarehouseID=" + _nWarehouseID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxHistoryID = 1;
                }
                else
                {
                    nMaxHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nHistoryID = nMaxHistoryID;
                sSql = "INSERT INTO t_SalesLeadManagementHistory (HistoryID, LeadNo, WarehouseID, ExpExecuteDate, Remarks, Status, CreateDate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                TELLib _oTelLib = new TELLib();
                cmd.Parameters.AddWithValue("CreateDate", _oTelLib.ServerDateTime());

                cmd.ExecuteNonQuery();
                cmd.Dispose();
               

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddHistoryWEB()
        {
            int nMaxHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([HistoryID]) FROM [t_SalesLeadManagementHistory] where WarehouseID=" + _nWarehouseID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxHistoryID = 1;
                }
                else
                {
                    nMaxHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nHistoryID = nMaxHistoryID;

                sSql = "INSERT INTO t_SalesLeadManagementHistory (HistoryID, LeadNo, WarehouseID, ExpExecuteDate, Remarks, Status, CreateDate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);

                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateHistory()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLeadManagementHistory SET ExpExecuteDate = ? WHERE HistoryID = ? and WarehouseID = ? and LeadNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdatePotentialData(int nID,int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PotentialCustomerList SET UpdateDate='" + DateTime.Now + "',UpdateUserID = " + Utility.UserId + ", LeadNo = ?,LeadDate = ?,Status = " + (int)Dictionary.PotentialCustomer.Convert_to_Lead + " where ID = " + nID + " and Outlet = " + nWHID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);



                cmd.ExecuteNonQuery();
                cmd.Dispose();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_PotentialCustomerList";
                oDataTran.DataID = Convert.ToInt32(nID);
                oDataTran.WarehouseID = nWHID;
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

        public void UpdatePotentialDataRT(int nID, int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PotentialCustomerList SET UpdateDate='" + DateTime.Now + "',UpdateUserID = " + Utility.UserId + ", LeadNo = ?,LeadDate = ?,Status = " + (int)Dictionary.PotentialCustomer.Convert_to_Lead + " where ID = " + nID + " and Outlet = " + nWHID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);



                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Insert()
        {
            int nMaxLeadID = 0;
            string sKeyWord = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([LeadID]) FROM t_SalesLeadManagement";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLeadID = 1;
                }
                else
                {
                    nMaxLeadID = Convert.ToInt32(maxID) + 1;
                }
                _nLeadID = nMaxLeadID;


                string sShortCode = "";
                string sLeadNo = "";
                DateTime dToday = DateTime.Today;
                if (_nTerminal == (int)Dictionary.Terminal.Branch_Office)
                {
                    DateTime dOperationDate;
                    oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();
                    sShortCode = oSystemInfo.Shortcode;
                    sLeadNo = "Lead-" + sShortCode + "-" + dToday.ToString("yy") + _nLeadID.ToString("000");
                    _sLeadNo = sLeadNo;
                }
                else
                {
                    sLeadNo = "Lead-" + "HO" + "-" + dToday.ToString("yy") + _nLeadID.ToString("000");
                    _sLeadNo = sLeadNo;
                }


                cmd.CommandText = "INSERT INTO t_SalesLeadManagement (LeadID,WarehouseID, LeadNo, LeadDate, " +
                                  "ExpExecuteDate, CustomerType, CompanyName, Name, Address, ContactNo, Email, " +
                                  "Profession, AgeLevel, IncomLevel, MAGID, BrandID, ModelName, NextFollowUpDate, " +
                                  "LeadAmount, Status, Remarks, Reason, InvoiceNo,  CreateDate, CreateUserID, " +
                                  "UpdateDate, UpdateUserID, SalesPersonID, Terminal, ConversionPossibility, Qty, IsExistingConsumer, RefLeadNo, LeadSource, ActivationID, IsValidLead,ThanaID,ProductID,IsHVACLead) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;



                cmd.Parameters.AddWithValue("LeadID", _nLeadID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("CustomerType", _nCustomerType);
                if (_sCompanyName != null)
                {
                    cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CompanyName", null);
                }
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                if (_sProfession != null)
                {
                    cmd.Parameters.AddWithValue("Profession", _sProfession);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Profession", null);
                }
                if (_sAgeLevel != null)
                {
                    cmd.Parameters.AddWithValue("AgeLevel", _sAgeLevel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("AgeLevel", null);
                }
                if (_sIncomLevel != null)
                {
                    cmd.Parameters.AddWithValue("IncomLevel", _sIncomLevel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IncomLevel", null);
                }
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                if (_sModelName != null)
                {
                    cmd.Parameters.AddWithValue("ModelName", _sModelName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ModelName", null);
                }
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("LeadAmount", _LeadAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }

                cmd.Parameters.AddWithValue("Reason", null);
                cmd.Parameters.AddWithValue("InvoiceNo", null);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("ConversionPossibility", _nConversionPossibility);
                cmd.Parameters.AddWithValue("Qty", _nQty);


                if (_nIsExistingConsumer != null)
                {
                    cmd.Parameters.AddWithValue("IsExistingConsumer", _nIsExistingConsumer);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IsExistingConsumer", 0);
                }
                if (_sRefLeadNo != null)
                {
                    cmd.Parameters.AddWithValue("RefLeadNo", _sRefLeadNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RefLeadNo", null);
                }
                cmd.Parameters.AddWithValue("LeadSource", _nLeadSource);
                cmd.Parameters.AddWithValue("ActivationID", _nActivationID);
                cmd.Parameters.AddWithValue("IsValidLead", _nIsValidLead);

                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("IsHVACLead", _nIsHVACLead);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void InsertForPOS()
        {
            int nMaxLeadID = 0;
            string sKeyWord = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([LeadID]) FROM t_SalesLeadManagement";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLeadID = 1;
                }
                else
                {
                    nMaxLeadID = Convert.ToInt32(maxID) + 1;
                }
                _nLeadID = nMaxLeadID;


                string sShortCode = "";
                string sLeadNo = "";
                DateTime dToday = DateTime.Today;
                if (_nTerminal == (int)Dictionary.Terminal.Branch_Office)
                {
                    DateTime dOperationDate;
                    oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();
                    sShortCode = oSystemInfo.Shortcode;
                    sLeadNo = "Lead-" + sShortCode + "-" + dToday.ToString("yy") + _nLeadID.ToString("000");
                    _sLeadNo = sLeadNo;
                }
                else
                {
                    sLeadNo = "Lead-" + "HO" + "-" + dToday.ToString("yy") + _nLeadID.ToString("000");
                    _sLeadNo = sLeadNo;
                }


                cmd.CommandText = "INSERT INTO t_SalesLeadManagement (LeadID,WarehouseID, LeadNo, LeadDate, " +
                                  "ExpExecuteDate, CustomerType, CompanyName, Name, Address, ContactNo, Email, " +
                                  "Profession, AgeLevel, IncomLevel, MAGID, BrandID, ModelName, NextFollowUpDate, " +
                                  "LeadAmount, Status, Remarks, Reason, InvoiceNo,  CreateDate, CreateUserID, " +
                                  "UpdateDate, UpdateUserID, SalesPersonID, Terminal, ConversionPossibility, Qty, " +
                                  "IsExistingConsumer, RefLeadNo, LeadSource, ActivationID,ConsumerID,ProductID,ThanaID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;



                cmd.Parameters.AddWithValue("LeadID", _nLeadID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("CustomerType", _nCustomerType);
                if (_sCompanyName != null)
                {
                    cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CompanyName", null);
                }
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                if (_sProfession != null)
                {
                    cmd.Parameters.AddWithValue("Profession", _sProfession);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Profession", null);
                }
                if (_sAgeLevel != null)
                {
                    cmd.Parameters.AddWithValue("AgeLevel", _sAgeLevel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("AgeLevel", null);
                }
                if (_sIncomLevel != null)
                {
                    cmd.Parameters.AddWithValue("IncomLevel", _sIncomLevel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IncomLevel", null);
                }
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                if (_sModelName != null)
                {
                    cmd.Parameters.AddWithValue("ModelName", _sModelName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ModelName", null);
                }
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("LeadAmount", _LeadAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }

                cmd.Parameters.AddWithValue("Reason", null);
                cmd.Parameters.AddWithValue("InvoiceNo", null);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("ConversionPossibility", _nConversionPossibility);
                cmd.Parameters.AddWithValue("Qty", _nQty);


                if (_nIsExistingConsumer != null)
                {
                    cmd.Parameters.AddWithValue("IsExistingConsumer", _nIsExistingConsumer);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IsExistingConsumer", 0);
                }
                if (_sRefLeadNo != null)
                {
                    cmd.Parameters.AddWithValue("RefLeadNo", _sRefLeadNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RefLeadNo", null);
                }
                cmd.Parameters.AddWithValue("LeadSource", _nLeadSource);
                cmd.Parameters.AddWithValue("ActivationID", _nActivationID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_SalesLeadManagement";
                oDataTran.DataID = Convert.ToInt32(_nLeadID);
                oDataTran.WarehouseID = _nWarehouseID;
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

        public void InsertForPOSRT()
        {
            int nMaxLeadID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([LeadID]) FROM t_SalesLeadManagement where WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLeadID = 1;
                }
                else
                {
                    nMaxLeadID = Convert.ToInt32(maxID) + 1;
                }
                _nLeadID = nMaxLeadID;


                string sShortCode = "";
                string sLeadNo = "";
                DateTime dToday = DateTime.Today;
                if (_nTerminal == (int)Dictionary.Terminal.Branch_Office)
                {
                    sShortCode = Utility.Shortcode;
                    sLeadNo = "Lead-" + sShortCode + "-" + dToday.ToString("yy") + _nLeadID.ToString("000");
                    _sLeadNo = sLeadNo;
                }
                else
                {
                    sLeadNo = "Lead-" + "HO" + "-" + dToday.ToString("yy") + _nLeadID.ToString("000");
                    _sLeadNo = sLeadNo;
                }


                cmd.CommandText = "INSERT INTO t_SalesLeadManagement (LeadID,WarehouseID, LeadNo, LeadDate, " +
                                  "ExpExecuteDate, CustomerType, CompanyName, Name, Address, ContactNo, Email, " +
                                  "Profession, AgeLevel, IncomLevel, MAGID, BrandID, ModelName, NextFollowUpDate, " +
                                  "LeadAmount, Status, Remarks, Reason, InvoiceNo,  CreateDate, CreateUserID, " +
                                  "UpdateDate, UpdateUserID, SalesPersonID, Terminal, ConversionPossibility, Qty, " +
                                  "IsExistingConsumer, RefLeadNo, LeadSource, ActivationID,ConsumerID,ProductID,ThanaID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";


                cmd.CommandType = CommandType.Text;



                cmd.Parameters.AddWithValue("LeadID", _nLeadID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("CustomerType", _nCustomerType);
                if (_sCompanyName != null)
                {
                    cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CompanyName", null);
                }
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                if (_sProfession != null)
                {
                    cmd.Parameters.AddWithValue("Profession", _sProfession);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Profession", null);
                }
                if (_sAgeLevel != null)
                {
                    cmd.Parameters.AddWithValue("AgeLevel", _sAgeLevel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("AgeLevel", null);
                }
                if (_sIncomLevel != null)
                {
                    cmd.Parameters.AddWithValue("IncomLevel", _sIncomLevel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IncomLevel", null);
                }
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                if (_sModelName != null)
                {
                    cmd.Parameters.AddWithValue("ModelName", _sModelName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ModelName", null);
                }
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("LeadAmount", _LeadAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }

                cmd.Parameters.AddWithValue("Reason", null);
                cmd.Parameters.AddWithValue("InvoiceNo", null);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("ConversionPossibility", _nConversionPossibility);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                if (_nIsExistingConsumer != null)
                {
                    cmd.Parameters.AddWithValue("IsExistingConsumer", _nIsExistingConsumer);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IsExistingConsumer", 0);
                }
                if (_sRefLeadNo != null)
                {
                    cmd.Parameters.AddWithValue("RefLeadNo", _sRefLeadNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RefLeadNo", null);
                }
                cmd.Parameters.AddWithValue("LeadSource", _nLeadSource);
                cmd.Parameters.AddWithValue("ActivationID", _nActivationID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);

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
                sSql = "UPDATE t_SalesLeadManagement SET LeadDate = ?, ExpExecuteDate = ?, CustomerType = ?,  "+
                       "CompanyName = ?, Name = ?, Address = ?, ContactNo = ?, Email = ?, Profession = ?, AgeLevel = ?,  "+
                       "IncomLevel = ?, MAGID = ?, BrandID = ?, ModelName = ?, NextFollowUpDate = ?, LeadAmount = ?,  "+
                       "Remarks = ?,UpdateDate = ?, UpdateUserID = ?, SalesPersonID = ?,ConversionPossibility = ?, Status = ?, "+
                       "IsExistingConsumer = ?, RefLeadNo = ?, LeadSource = ?, ActivationID = ?  WHERE LeadID = ?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("CustomerType", _nCustomerType);
                if (_sCompanyName != null)
                {
                    cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CompanyName", null);
                }
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                if (_sProfession != null)
                {
                    cmd.Parameters.AddWithValue("Profession", _sProfession);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Profession", null);
                }
                if (_sAgeLevel != null)
                {
                    cmd.Parameters.AddWithValue("AgeLevel", _sAgeLevel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("AgeLevel", null);
                }
                if (_sIncomLevel != null)
                {
                    cmd.Parameters.AddWithValue("IncomLevel", _sIncomLevel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IncomLevel", null);
                }
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);

                if (_sModelName != null)
                {
                    cmd.Parameters.AddWithValue("ModelName", _sModelName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ModelName", null);
                }
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("LeadAmount", _LeadAmount);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }

                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("ConversionPossibility", _nConversionPossibility);
                cmd.Parameters.AddWithValue("Status", _nStatus);



                if (_nIsExistingConsumer != null)
                {
                    cmd.Parameters.AddWithValue("IsExistingConsumer", _nIsExistingConsumer);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IsExistingConsumer", 0);
                }
                if (_sRefLeadNo != null)
                {
                    cmd.Parameters.AddWithValue("RefLeadNo", _sRefLeadNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RefLeadNo", null);
                }
                cmd.Parameters.AddWithValue("LeadSource", _nLeadSource);
                cmd.Parameters.AddWithValue("ActivationID", _nActivationID);


                cmd.Parameters.AddWithValue("LeadID", _nLeadID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //cmd = DBController.Instance.GetCommand();
                //oSystemInfo = new SystemInfo();
                //oSystemInfo.Refresh();

                //DataTran oDataTran = new DataTran();
                //oDataTran.TableName = "t_SalesLeadManagement";
                //oDataTran.DataID = Convert.ToInt32(_nLeadID);
                //oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                //oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                //oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                //oDataTran.BatchNo = 0;
                //if (oDataTran.CheckData() == false)
                //{
                //    oDataTran.AddForTDPOS();
                //}
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLeadManagement SET LeadDate = ?, ExpExecuteDate = ?, CustomerType = ?,  " +
                       "CompanyName = ?, Name = ?, Address = ?, ContactNo = ?, Email = ?, Profession = ?, AgeLevel = ?,  " +
                       "IncomLevel = ?, MAGID = ?, BrandID = ?, ModelName = ?, NextFollowUpDate = ?, LeadAmount = ?,  " +
                       "Remarks = ?,UpdateDate = ?, UpdateUserID = ?, SalesPersonID = ?,ConversionPossibility = ?, Status = ?, Qty = ?, " +
                       "IsExistingConsumer = ?, RefLeadNo = ?, LeadSource = ?, ActivationID = ?, ConsumerID = ?,ProductID = ?,ThanaID= ?  WHERE LeadID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("CustomerType", _nCustomerType);
                if (_sCompanyName != null)
                {
                    cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CompanyName", null);
                }
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                if (_sProfession != null)
                {
                    cmd.Parameters.AddWithValue("Profession", _sProfession);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Profession", null);
                }
                if (_sAgeLevel != null)
                {
                    cmd.Parameters.AddWithValue("AgeLevel", _sAgeLevel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("AgeLevel", null);
                }
                if (_sIncomLevel != null)
                {
                    cmd.Parameters.AddWithValue("IncomLevel", _sIncomLevel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IncomLevel", null);
                }
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);

                if (_sModelName != null)
                {
                    cmd.Parameters.AddWithValue("ModelName", _sModelName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ModelName", null);
                }
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("LeadAmount", _LeadAmount);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }

                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("ConversionPossibility", _nConversionPossibility);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Qty", _nQty);

                if (_nIsExistingConsumer != null)
                {
                    cmd.Parameters.AddWithValue("IsExistingConsumer", _nIsExistingConsumer);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IsExistingConsumer", 0);
                }
                if (_sRefLeadNo != null)
                {
                    cmd.Parameters.AddWithValue("RefLeadNo", _sRefLeadNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RefLeadNo", null);
                }
                cmd.Parameters.AddWithValue("LeadSource", _nLeadSource);
                cmd.Parameters.AddWithValue("ActivationID", _nActivationID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("LeadID", _nLeadID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_SalesLeadManagement";
                oDataTran.DataID = Convert.ToInt32(_nLeadID);
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

        public void EditForPOSRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLeadManagement SET LeadDate = ?, ExpExecuteDate = ?, CustomerType = ?,  " +
                       "CompanyName = ?, Name = ?, Address = ?, ContactNo = ?, Email = ?, Profession = ?, AgeLevel = ?,  " +
                       "IncomLevel = ?, MAGID = ?, BrandID = ?, ModelName = ?, NextFollowUpDate = ?, LeadAmount = ?,  " +
                       "Remarks = ?,UpdateDate = ?, UpdateUserID = ?, SalesPersonID = ?,ConversionPossibility = ?, Status = ?, Qty = ?, " +
                       "IsExistingConsumer = ?, RefLeadNo = ?, LeadSource = ?, ActivationID = ?, ConsumerID = ?,ProductID = ?,ThanaID= ?  WHERE LeadID = ? and WarehouseID=" + Utility.WarehouseID + "";


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("CustomerType", _nCustomerType);
                if (_sCompanyName != null)
                {
                    cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CompanyName", null);
                }
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                if (_sProfession != null)
                {
                    cmd.Parameters.AddWithValue("Profession", _sProfession);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Profession", null);
                }
                if (_sAgeLevel != null)
                {
                    cmd.Parameters.AddWithValue("AgeLevel", _sAgeLevel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("AgeLevel", null);
                }
                if (_sIncomLevel != null)
                {
                    cmd.Parameters.AddWithValue("IncomLevel", _sIncomLevel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IncomLevel", null);
                }
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);

                if (_sModelName != null)
                {
                    cmd.Parameters.AddWithValue("ModelName", _sModelName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ModelName", null);
                }
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("LeadAmount", _LeadAmount);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }
                TELLib oTELLib = new TELLib();

                cmd.Parameters.AddWithValue("UpdateDate", oTELLib.ServerDateTime().Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("ConversionPossibility", _nConversionPossibility);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Qty", _nQty);

                if (_nIsExistingConsumer != null)
                {
                    cmd.Parameters.AddWithValue("IsExistingConsumer", _nIsExistingConsumer);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IsExistingConsumer", 0);
                }
                if (_sRefLeadNo != null)
                {
                    cmd.Parameters.AddWithValue("RefLeadNo", _sRefLeadNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RefLeadNo", null);
                }
                cmd.Parameters.AddWithValue("LeadSource", _nLeadSource);
                cmd.Parameters.AddWithValue("ActivationID", _nActivationID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("LeadID", _nLeadID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLeadManagement SET LeadDate = ?, ExpExecuteDate = ?, CustomerType = ?, "+
                        "CompanyName = ?, Name = ?, Address = ?, ContactNo = ?, Email = ?, Profession = ?, "+
                        "AgeLevel = ?, IncomLevel = ?, MAGID = ?, BrandID = ?, ModelName = ?, NextFollowUpDate = ?, "+
                        "LeadAmount = ?, Remarks = ?,UpdateDate = ?, UpdateUserID = ?, InvoiceNo = ?, InvoiceDate = ?, Reason = ?, CancelDate =?, " +
                        "Status = ?, SalesPersonID = ?, Terminal = ?, ConversionPossibility = ?  WHERE LeadNo = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("CustomerType", _nCustomerType);
                cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Profession", _sProfession);
                cmd.Parameters.AddWithValue("AgeLevel", _sAgeLevel);
                cmd.Parameters.AddWithValue("IncomLevel", _sIncomLevel);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("ModelName", _sModelName);
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("LeadAmount", _LeadAmount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                if (_dtInvoiceDate != "")
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", _dtInvoiceDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", null);
                }

                cmd.Parameters.AddWithValue("Reason", _sReason);
                if (_dtCancelDate != "")
                {
                    cmd.Parameters.AddWithValue("CancelDate", _dtCancelDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CancelDate", null);
                }
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("ConversionPossibility", _nConversionPossibility);


                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateForWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLeadManagement SET LeadDate = ?, ExpExecuteDate = ?, CustomerType = ?, " +
                        "CompanyName = ?, Name = ?, Address = ?, ContactNo = ?, Email = ?, Profession = ?, " +
                        "AgeLevel = ?, IncomLevel = ?, MAGID = ?, BrandID = ?, ModelName = ?, NextFollowUpDate = ?, " +
                        "LeadAmount = ?, Remarks = ?,UpdateDate = ?, UpdateUserID = ?, InvoiceNo = ?, InvoiceDate = ?, Reason = ?, CancelDate =?, " +
                        "Status = ?, SalesPersonID = ?, Terminal = ?, ConversionPossibility = ?, Qty = ?, IsExistingConsumer = ?, RefLeadNo = ?, LeadSource = ?,ActivationID = ?,ProductID = ?,ThanaID = ?,ConsumerID = ?  WHERE LeadNo = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("CustomerType", _nCustomerType);
                cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Profession", _sProfession);
                cmd.Parameters.AddWithValue("AgeLevel", _sAgeLevel);
                cmd.Parameters.AddWithValue("IncomLevel", _sIncomLevel);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("ModelName", _sModelName);
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("LeadAmount", _LeadAmount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                if (_dUpdateDate != null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                }
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                if (_dtInvoiceDate != null)
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", _dtInvoiceDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InvoiceDate", null);
                }

                cmd.Parameters.AddWithValue("Reason", _sReason);
                if (_dtCancelDate != null)
                {
                    cmd.Parameters.AddWithValue("CancelDate", _dtCancelDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CancelDate", null);
                }
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("ConversionPossibility", _nConversionPossibility);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("IsExistingConsumer", _nIsExistingConsumer);
                cmd.Parameters.AddWithValue("RefLeadNo", _sRefLeadNo);
                cmd.Parameters.AddWithValue("LeadSource", _nLeadSource);
                cmd.Parameters.AddWithValue("ActivationID", _nActivationID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);

                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLeadManagement SET Status = ?, Reason = ?,CancelDate = ?, UpdateDate = ?, UpdateUserID = ? WHERE LeadID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("CancelDate", _dtCancelDate);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("LeadID", _nLeadID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_SalesLeadManagement";
                oDataTran.DataID = Convert.ToInt32(_nLeadID);
                oDataTran.WarehouseID = oSystemInfo.WarehouseID;
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

        public void AssignOutlet()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLeadManagement SET WarehouseID = ?, SalesPersonID = ?, UpdateDate = ?, UpdateUserID = ? WHERE LeadID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("LeadID", _nLeadID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_SalesLeadManagement";
                oDataTran.DataID = Convert.ToInt32(_nLeadID);
                oDataTran.WarehouseID = Convert.ToInt32(_nWarehouseID);
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                if (oDataTran.CheckData())
                {

                }
                else
                {
                    oDataTran.AddForTDPOS();
                }
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
                sSql = "DELETE FROM t_SalesLeadManagement WHERE [LeadID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeadID", _nLeadID);
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
                cmd.CommandText = "SELECT * FROM t_SalesLeadManagement where LeadID =?";
                cmd.Parameters.AddWithValue("LeadID", _nLeadID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLeadID = (int)reader["LeadID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _sLeadNo = (string)reader["LeadNo"];
                    _dLeadDate = Convert.ToDateTime(reader["LeadDate"].ToString());
                    _dExpExecuteDate = Convert.ToDateTime(reader["ExpExecuteDate"].ToString());
                    _nCustomerType = (int)reader["CustomerType"];
                    _sCompanyName = (string)reader["CompanyName"];
                    _sName = (string)reader["Name"];
                    _sAddress = (string)reader["Address"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sEmail = (string)reader["Email"];
                    _sProfession = (string)reader["Profession"];
                    _sAgeLevel = (string)reader["AgeLevel"];
                    _sIncomLevel = (string)reader["IncomLevel"];
                    _nMAGID = (int)reader["MAGID"];
                    _nBrandID = (int)reader["BrandID"];
                    _sModelName = (string)reader["ModelName"];
                    _dNextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    _LeadAmount = Convert.ToDouble(reader["LeadAmount"].ToString());
                    _nStatus = (int)reader["Status"];
                    _sRemarks = (string)reader["Remarks"];
                    _sReason = (string)reader["Reason"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = (object)reader["UpdateDate"];
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByLeadNo(int nType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                if (nType == (int)Dictionary.POSInvoiceUIControl.eStore)
                {
                    cmd.CommandText = "Select a.*,isnull(ConsumerCode,'') ConsumerCode " +
                                    "From " +
                                    "( " +
                                    "SELECT Type, LeadID, LeadNo, CustomerType, CompanyName, " +
                                    "Name, Address, ContactNo, Email, ConsumerID " +
                                    "FROM " +
                                    "( " +
                                    "SELECT 1 as Type, LeadID, WarehouseID, LeadNo, " +
                                    "LeadDate, ExpExecuteDate, CustomerType, " +
                                    "CompanyName, Name, Address, isnull(ConsumerID, 0) ConsumerID, " +
                                    "ContactNo, Email, Profession, AgeLevel, IncomLevel, " +
                                    "MAGID, BrandID, ModelName, NextFollowUpDate, " +
                                    "LeadAmount, Status, isnull(Remarks, '') Remarks, " +
                                    "Reason, CreateDate, " +
                                    "CreateUserID, UpdateDate, UpdateUserID, IsExistingConsumer, RefLeadNo " +
                                    "FROM t_SalesLeadManagement where Status not in (3, 4) and CustomerType = 6 " +
                                    "Union All " +
                                    "Select 2 as Type, EcomOrderID as LeadID, WarehouseID, OrderNo LeadNo, " +
                                    "OrderDate LeadDate, OrderDate ExpExecuteDate, 6 CustomerType, " +
                                    "'' CompanyName, ConsumerName Name, a.DeliveryAddress Address, 0 ConsumerID, " +
                                    "ContactNo, a.Email, '' Profession, '' AgeLevel, '' IncomLevel, " +
                                    "- 1 MAGID, -1 BrandID, '' ModelName, OrderDate NextFollowUpDate, " +
                                    "Amount LeadAmount, Status, isnull(Remarks, '') Remarks, " +
                                    "'' Reason, OrderDate CreateDate, " +
                                    "- 1 CreateUserID, OrderDate UpdateDate, -1 UpdateUserID, 0 IsExistingConsumer, '' RefLeadNo " +
                                    "From t_SalesinvoiceEcommerce a, t_Showroom b " +
                                    "where a.Outlet = b.ShowroomCode and Status not in (3, 4) " +
                                    ") Main where LeadNo = '" + _sLeadNo + "' " +
                                    ") a " +
                                    "Left outer Join " +
                                    "( " +
                                    "Select * From t_RetailConsumer " +
                                    ") b " +
                                    "on a.ConsumerID = b.ConsumerID ";
                }
                else
                {
                    cmd.CommandText = "Select 1 as Type,LeadID,LeadNo,CustomerType,isnull(CompanyName,'') CompanyName, " +
                                    "Name,a.Address,ContactNo,a.Email,isnull(a.ConsumerID, 0) ConsumerID, " +
                                    "isnull(ConsumerCode, '') ConsumerCode " +
                                    "From " +
                                    "( " +
                                    "SELECT * FROM t_SalesLeadManagement where Status not in (" + (int)Dictionary.SalesLeadStatusPOS.Sales_Executed + "," + (int)Dictionary.SalesLeadStatusPOS.Cancel + ") and LeadNo = '" + _sLeadNo + "' " +
                                    ") a " +
                                    "Left outer join " +
                                    "( " +
                                    "Select * From t_RetailConsumer " +
                                    ") b " +
                                    "on a.ConsumerID = b.ConsumerID";
                }

                //cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nType = (int)reader["Type"];
                    _nLeadID = (int)reader["LeadID"];
                    _sLeadNo = (string)reader["LeadNo"];
                    _nCustomerType = (int)reader["CustomerType"];
                    if (_sCompanyName != null)
                    {
                        _sCompanyName = (string)reader["CompanyName"];
                    }
                    else
                    {
                        _sCompanyName = "";
                    }
                    _sName = (string)reader["Name"];
                    _sAddress = (string)reader["Address"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sEmail = (string)reader["Email"];
                    _nConsumerID = (int)reader["ConsumerID"];
                    _sConsumerCode = (string)reader["ConsumerCode"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByLeadNoRT(int nType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                if (nType == (int)Dictionary.POSInvoiceUIControl.eStore)
                {
                    cmd.CommandText = "Select a.*,isnull(ConsumerCode,'') ConsumerCode " +
                                    "From " +
                                    "( " +
                                    "SELECT WarehouseID,Type, LeadID, LeadNo, CustomerType, CompanyName, " +
                                    "Name, Address, ContactNo, Email, ConsumerID " +
                                    "FROM " +
                                    "( " +
                                    "SELECT 1 as Type, LeadID, WarehouseID, LeadNo, " +
                                    "LeadDate, ExpExecuteDate, CustomerType, " +
                                    "CompanyName, Name, Address, isnull(ConsumerID, 0) ConsumerID, " +
                                    "ContactNo, Email, Profession, AgeLevel, IncomLevel, " +
                                    "MAGID, BrandID, ModelName, NextFollowUpDate, " +
                                    "LeadAmount, Status, isnull(Remarks, '') Remarks, " +
                                    "Reason, CreateDate, " +
                                    "CreateUserID, UpdateDate, UpdateUserID, IsExistingConsumer, RefLeadNo " +
                                    "FROM t_SalesLeadManagement where Status not in (3, 4) and CustomerType = 6 " +
                                    "Union All " +
                                    "Select 2 as Type, EcomOrderID as LeadID, WarehouseID, OrderNo LeadNo, " +
                                    "OrderDate LeadDate, OrderDate ExpExecuteDate, 6 CustomerType, " +
                                    "'' CompanyName, ConsumerName Name, a.DeliveryAddress Address, 0 ConsumerID, " +
                                    "ContactNo, a.Email, '' Profession, '' AgeLevel, '' IncomLevel, " +
                                    "- 1 MAGID, -1 BrandID, '' ModelName, OrderDate NextFollowUpDate, " +
                                    "Amount LeadAmount, Status, isnull(Remarks, '') Remarks, " +
                                    "'' Reason, OrderDate CreateDate, " +
                                    "- 1 CreateUserID, OrderDate UpdateDate, -1 UpdateUserID, 0 IsExistingConsumer, '' RefLeadNo " +
                                    "From t_SalesinvoiceEcommerce a, t_Showroom b " +
                                    "where a.Outlet = b.ShowroomCode and Status not in (3, 4) " +
                                    ") Main where LeadNo = '" + _sLeadNo + "' " +
                                    ") a " +
                                    "Left outer Join " +
                                    "( " +
                                    "Select * From t_RetailConsumer " +
                                    ") b " +
                                    "on a.ConsumerID = b.ConsumerID and a.WarehouseID=b.WarehouseID ";
                }
                else
                {
                    cmd.CommandText = "Select 1 as Type,LeadID,LeadNo,CustomerType,isnull(CompanyName,'') CompanyName, " +
                                    "Name,a.Address,ContactNo,a.Email,isnull(a.ConsumerID, 0) ConsumerID, " +
                                    "isnull(ConsumerCode, '') ConsumerCode " +
                                    "From " +
                                    "( " +
                                    "SELECT * FROM t_SalesLeadManagement where Status not in (" + (int)Dictionary.SalesLeadStatusPOS.Sales_Executed + "," + (int)Dictionary.SalesLeadStatusPOS.Cancel + ") and LeadNo = '" + _sLeadNo + "' " +
                                    ") a " +
                                    "Left outer join " +
                                    "( " +
                                    "Select * From t_RetailConsumer " +
                                    ") b " +
                                    "on a.ConsumerID = b.ConsumerID and a.WarehouseID=b.WarehouseID";
                }

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nType = (int)reader["Type"];
                    _nLeadID = (int)reader["LeadID"];
                    _sLeadNo = (string)reader["LeadNo"];
                    _nCustomerType = (int)reader["CustomerType"];
                    if (_sCompanyName != null)
                    {
                        _sCompanyName = (string)reader["CompanyName"];
                    }
                    else
                    {
                        _sCompanyName = "";
                    }
                    _sName = (string)reader["Name"];
                    _sAddress = (string)reader["Address"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sEmail = (string)reader["Email"];
                    _nConsumerID = (int)reader["ConsumerID"];
                    _sConsumerCode = (string)reader["ConsumerCode"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateInvoiceStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLeadManagement SET InvoiceNo = ?,InvoiceDate = ?, Status = ?, UpdateUserID = ?, UpdateDate = ? WHERE LeadID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dtInvoiceDate);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.SalesLeadStatusPOS.Sales_Executed);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("LeadID", _nLeadID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_SalesLeadManagement";
                oDataTran.DataID = Convert.ToInt32(_nLeadID);
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

        public void UpdateInvoiceStatusRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLeadManagement SET InvoiceNo = ?,InvoiceDate = ?, Status = ?, UpdateUserID = ?, UpdateDate = ? WHERE LeadID = ? and WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dtInvoiceDate);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.SalesLeadStatusPOS.Sales_Executed);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("LeadID", _nLeadID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_SalesLeadManagement";
                oDataTran.DataID = Convert.ToInt32(_nLeadID);
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
        public void GetCustomerByLeadNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT LeadID,isnull(WarehouseID,-1) WarehouseID,LeadNo,LeadDate,ExpExecuteDate, " +
                                "CustomerType,isnull(CompanyName,'') CompanyName,Name,Address,ContactNo,Email, " +
                                "isnull(Profession,'') Profession,isnull(AgeLevel,'') AgeLevel,isnull(IncomLevel,'') IncomLevel, " +
                                "MAGID,BrandID,isnull(ModelName,'') ModelName,NextFollowUpDate,LeadAmount,Status, " +
                                "isnull(Remarks,'') Remarks,isnull(Reason,'') Reason,isnull(InvoiceNo,'') InvoiceNo, " +
                                "CreateDate,CreateUserID,isnull(SalesPersonID,-1) SalesPersonID,isnull(Terminal,2) Terminal, " +
                                "isnull(ConversionPossibility,1) ConversionPossibility,isnull(Qty,1) Qty, " +
                                "isnull(IsExistingConsumer,0) IsExistingConsumer,isnull(RefLeadNo,'') RefLeadNo " +
                                "FROM t_SalesLeadManagement where LeadNo = ? and WarehouseID = ?";


                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.Parameters.AddWithValue("WarehouseID",  _nWarehouseID);
                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLeadID = (int)reader["LeadID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _sLeadNo = (string)reader["LeadNo"];
                    _dLeadDate = Convert.ToDateTime(reader["LeadDate"].ToString());
                    _dExpExecuteDate = Convert.ToDateTime(reader["ExpExecuteDate"].ToString());
                    _nCustomerType = (int)reader["CustomerType"];
                    _sCompanyName = (string)reader["CompanyName"];
                    _sName = (string)reader["Name"];
                    _sAddress = (string)reader["Address"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sEmail = (string)reader["Email"];
                    _sProfession = (string)reader["Profession"];
                    _sAgeLevel = (string)reader["AgeLevel"];
                    _sIncomLevel = (string)reader["IncomLevel"];
                    _nMAGID = (int)reader["MAGID"];
                    _nBrandID = (int)reader["BrandID"];
                    _sModelName = (string)reader["ModelName"];
                    _dNextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    _LeadAmount = Convert.ToDouble(reader["LeadAmount"].ToString());
                    _nStatus = (int)reader["Status"];
                    _sRemarks = (string)reader["Remarks"];
                    _sReason = (string)reader["Reason"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _nSalesPersonID = (int)reader["SalesPersonID"];
                    _nTerminal = (int)reader["Terminal"];
                    _nConversionPossibility = (int)reader["ConversionPossibility"];
                    _nQty = (int)reader["Qty"];
                    _nIsExistingConsumer = (int)reader["IsExistingConsumer"];
                    _sRefLeadNo = (string)reader["RefLeadNo"];



                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetLeadLeadIDbyNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesLeadManagement where LeadNo =?";
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLeadID = (int)reader["LeadID"];
                    _sLeadNo = (string)reader["LeadNo"];
                    _nCustomerType = (int)reader["CustomerType"];
                    if (_sCompanyName != null)
                    {
                        _sCompanyName = (string)reader["CompanyName"];
                    }
                    else
                    {
                        _sCompanyName = "";
                    }
                    _sName = (string)reader["Name"];
                    _sAddress = (string)reader["Address"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sEmail = (string)reader["Email"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetSalesInvoiceConsumerID(string sLeadNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;

            string sSql = "Select ConsumerID,c.CustomerID From t_SalesInvoice a,t_SalesLeadManagement b,t_RetailConsumer c " +
                          "where a.InvoiceNo=b.invoiceNo and a.SundryCustomerID=c.ConsumerID and  " +
                          "LeadNo='" + sLeadNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nConsumerID = (int)reader["ConsumerID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetLeadIDByContactNo(string sMobileNo,int nSalesType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nLeadID = 0;
            try
            {
                cmd.CommandText = "SELECT isnull(max(LeadID),0) LeadID FROM t_SalesLeadManagement where Status not in (3,4) and ContactNo='" + sMobileNo + "' and CustomerType=" + nSalesType + "";
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nLeadID = Convert.ToInt32(reader["LeadID"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nLeadID;
        }

        public int GetLeadIDByContactNoRT(string sMobileNo, int nSalesType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nLeadID = 0;
            try
            {
                cmd.CommandText = "SELECT isnull(max(LeadID),0) LeadID FROM t_SalesLeadManagement where WarehouseID =" + Utility.WarehouseID + " and Status not in (3,4) and ContactNo='" + sMobileNo + "' and CustomerType=" + nSalesType + "";
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nLeadID = Convert.ToInt32(reader["LeadID"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nLeadID;
        }
        public void UpdateHOLead()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLeadManagement SET WarehouseID = ?,LeadDate  = ?,ExpExecuteDate  = ?,  " +
                       "CustomerType = ?,CompanyName = ?,Name = ?,  " +
                       "Address  = ?,ContactNo  = ?,Email  = ?,Profession  = ?,AgeLevel  = ?,IncomLevel  = ?,MAGID  = ?,  " +
                       "BrandID  = ?,ModelName  = ?,NextFollowUpDate  = ?,LeadAmount  = ?,Status  = ?,Remarks  = ?,  " +
                       "UpdateDate  = ?,UpdateUserID  = ?,SalesPersonID  = ?,ConversionPossibility  = ?,Qty  = ?,  " +
                       "IsExistingConsumer  = ?,RefLeadNo  = ?,LeadSource  = ?,ActivationID  = ?,IsValidLead  = ?, "+
                       "IsVerified = ?,VerifiedBy = ?,VerifiedDate = ?,ThanaID = ?,ProductID = ?  WHERE LeadNo = ?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("LeadDate", _dLeadDate);
                cmd.Parameters.AddWithValue("ExpExecuteDate", _dExpExecuteDate);
                cmd.Parameters.AddWithValue("CustomerType", _nCustomerType);
                cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Profession", _sProfession);
                cmd.Parameters.AddWithValue("AgeLevel", _sAgeLevel);
                cmd.Parameters.AddWithValue("IncomLevel", _sIncomLevel);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("ModelName", _sModelName);
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("LeadAmount", _LeadAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("ConversionPossibility", _nConversionPossibility);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("IsExistingConsumer", _nIsExistingConsumer);
                cmd.Parameters.AddWithValue("RefLeadNo", _sRefLeadNo);
                cmd.Parameters.AddWithValue("LeadSource", _nLeadSource);
                cmd.Parameters.AddWithValue("ActivationID", _nActivationID);
                cmd.Parameters.AddWithValue("IsValidLead", _nIsValidLead);
                cmd.Parameters.AddWithValue("IsVerified", (int)Dictionary.YesOrNoStatus.YES);
                cmd.Parameters.AddWithValue("VerifiedBy", Utility.UserId);
                cmd.Parameters.AddWithValue("VerifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class SalesLeads : CollectionBase
    {
        public SalesLead this[int i]
        {
            get { return (SalesLead)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesLead oSalesLead)
        {
            InnerList.Add(oSalesLead);
        }
        public int GetIndex(int nLeadID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].LeadID == nLeadID)
                {
                    return i;
                }
            }
            return -1;
        }


        public int GetActivationIndex(int nActivationID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ActivationID == nActivationID)
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
            string sSql = "SELECT * FROM t_SalesLeadManagement";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLead oSalesLead = new SalesLead();
                    oSalesLead.LeadID = (int)reader["LeadID"];
                    oSalesLead.WarehouseID = (int)reader["WarehouseID"];
                    oSalesLead.LeadNo = (string)reader["LeadNo"];
                    oSalesLead.LeadDate = Convert.ToDateTime(reader["LeadDate"].ToString());
                    oSalesLead.ExpExecuteDate = Convert.ToDateTime(reader["ExpExecuteDate"].ToString());
                    oSalesLead.CustomerType = (int)reader["CustomerType"];
                    oSalesLead.CompanyName = (string)reader["CompanyName"];
                    oSalesLead.Name = (string)reader["Name"];
                    oSalesLead.Address = (string)reader["Address"];
                    oSalesLead.ContactNo = (string)reader["ContactNo"];
                    oSalesLead.Email = (string)reader["Email"];
                    oSalesLead.Profession = (string)reader["Profession"];
                    oSalesLead.AgeLevel = (string)reader["AgeLevel"];
                    oSalesLead.IncomLevel = (string)reader["IncomLevel"];
                    oSalesLead.MAGID = (int)reader["MAGID"];
                    oSalesLead.BrandID = (int)reader["BrandID"];
                    oSalesLead.ModelName = (string)reader["ModelName"];
                    oSalesLead.NextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    oSalesLead.LeadAmount = Convert.ToDouble(reader["LeadAmount"].ToString());
                    oSalesLead.Status = (int)reader["Status"];
                    oSalesLead.Remarks = (string)reader["Remarks"];
                    oSalesLead.Reason = (string)reader["Reason"];
                    oSalesLead.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesLead.CreateUserID = (int)reader["CreateUserID"];
                    oSalesLead.UpdateDate = (object)reader["UpdateDate"];
                    oSalesLead.UpdateUserID = (int)reader["UpdateUserID"];
                    InnerList.Add(oSalesLead);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLeadHistory(string sLeadNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select CreateDate,isnull(Remarks,'') Remarks,Status From t_SalesLeadManagementHistory where LeadNo='" + sLeadNo + "'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLead oSalesLead = new SalesLead();
                    oSalesLead.Status = (int)reader["Status"];
                    oSalesLead.Remarks = (string)reader["Remarks"];
                    oSalesLead.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oSalesLead);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, DateTime dExpFromDate, DateTime dExpToDate, int nCustType, int nStatus, string sCompany, string sName, string sContact, string sLeadNo, bool IsCheck, bool IsCheckExpdt, int nSalesPersonID,int nLeadSource,int nMAGID,int nBrandID,bool IsNxtFDate,DateTime dtNxtFromDate,DateTime dtNxtTodate,int nASGID,int nAGID,int nPGID,string sProductName,string sModelName)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            dExpToDate = dExpToDate.AddDays(1);
            dtNxtTodate = dtNxtTodate.AddDays(1);
            string sSql = "";

            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select a.*, isnull('[' + EmployeeCode + ']' + EmployeeName, '') as SalesPerson,  " +
                    "isnull(ActivationName, '')  ActivationName,  " +
                    "isnull(ThanaName, '') ThanaName, isnull(DistrictID, -1) DistrictID,  " +
                    "isnull(DistrictName, '') DistrictName,isnull(SalesQty,0) SalesQty,isnull(InvoiceAmount,0) InvoiceAmount  " +
                    "From  " +
                    "(  " +
                    "Select xx.*,  " +
                    "isnull(ProductCode, '') ProductCode,  " +
                    "isnull(ProductName, '') ProductName,  " +
                    "isnull(ProductModel, '') ProductModel,isnull(AGID,-1) AGID,isnull(AGName,'') AGName,isnull(ASGID,-1) ASGID,isnull(ASGName,'') ASGName From  " +
                    "(  " +
                    "Select a.*, ShowroomCode, BrandDesc, c.PdtGroupName as MAGName, " +
                    "e.PdtGroupID as PGID,e.PdtGroupName as PGName " +
                    "From t_SalesLeadManagement a, t_Showroom b, t_ProductGroup c, t_Brand d, " +
                    "t_ProductGroup e " +
                    "where a.WarehouseID = b.WarehouseID and a.MAGID = c.PdtGroupID " +
                    "and a.BrandID = d.BrandID and c.ParentID = e.PdtGroupID  " +
                    ") xx  " +
                    "Left Outer Join  " +
                    "(  " +
                    "Select * From v_ProductDetails  " +
                    ") yy on xx.ProductID = yy.ProductID  " +
                    ") a  " +
                    "Left Outer Join  " +
                    "(  " +
                    "Select * From t_Employee  " +
                    ") b  " +
                    "on a.SalesPersonID = b.EmployeeID  " +
                    "left outer join  " +
                    "(  " +
                    "Select * From t_TDActivation  " +
                    ") c  " +
                    "on a.ActivationID = c.ActivationID  " +
                    "left outer join  " +
                    "(  " +
                    "Select a.GeoLocationID as ThanaID, a.GeoLocationName as ThanaName,  " +
                    "b.GeoLocationID as DistrictID, b.GeoLocationName as DistrictName  " +
                    "From t_GeoLocation a, t_GeoLocation b  " +
                    "where a.GeoLocationType = 2 and a.ParentID = b.GeoLocationID  " +
                    ") d  " +
                    "on a.ThanaID = d.ThanaID  " +
                    "left outer Join  " +
                    "(  " +
                    "Select InvoiceNo, SalesQty, InvoiceAmount  " +
                    "From t_SalesInvoice a,(  " +
                    "Select InvoiceID, sum(Quantity)SalesQty  " +
                    "From t_SalesInvoiceDetail group by InvoiceID) b  " +
                    "where a.InvoiceID = b.InvoiceID  " +
                    ") e  " +
                    "on a.InvoiceNo = e.InvoiceNo  " +
                    ") Main where 1 = 1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and LeadDate between '" + dFromDate + "' and '" + dToDate + "' and LeadDate<'" + dToDate + "' ";
            }
            if (IsCheckExpdt == false)
            {
                sSql = sSql + " and ExpExecuteDate between '" + dExpFromDate + "' and '" + dExpToDate + "' and ExpExecuteDate<'" + dExpToDate + "' ";
            }
            if (IsNxtFDate == false)
            {
                sSql = sSql + " and NextFollowUpDate between '" + dtNxtFromDate + "' and '" + dtNxtTodate + "' and NextFollowUpDate<'" + dtNxtTodate + "' ";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (nSalesPersonID != -1)
            {
                sSql = sSql + " AND SalesPersonID=" + nSalesPersonID + "";
            }

            if (nCustType != -1)
            {
                sSql = sSql + " AND CustomerType=" + nCustType + "";
            }

            if (sCompany != "")
            {
                sSql = sSql + " AND CompanyName like '%" + sCompany + "%'";
            }
            if (sName != "")
            {
                sSql = sSql + " AND Name like '%" + sName + "%'";
            }
            if (sContact != "")
            {
                sSql = sSql + " AND ContactNo like '%" + sContact + "%'";
            }
            if (sLeadNo != "")
            {
                sSql = sSql + " AND LeadNo like '%" + sLeadNo + "%'";
            }
            if (nLeadSource != -1)
            {
                sSql = sSql + " AND isnull(LeadSource,0)=" + nLeadSource + "";
            }

            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID=" + nBrandID + "";
            }


            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }

            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID=" + nASGID + "";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }


            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%' or ProductCode like '%" + sProductName + "%'";
            }
            if (sModelName != "")
            {
                sSql = sSql + " AND ModelName like '%" + sModelName + "%'";
            }
            sSql = sSql + " Order by LeadID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLead oSalesLead = new SalesLead();
                    oSalesLead.LeadID = (int)reader["LeadID"];
                    oSalesLead.WarehouseID = (int)reader["WarehouseID"];
                    oSalesLead.ShowroomCode = (string)reader["ShowroomCode"];
                    oSalesLead.LeadNo = (string)reader["LeadNo"];
                    oSalesLead.LeadDate = Convert.ToDateTime(reader["LeadDate"].ToString());
                    oSalesLead.ExpExecuteDate = Convert.ToDateTime(reader["ExpExecuteDate"].ToString());
                    oSalesLead.CustomerType = (int)reader["CustomerType"];
                    if (reader["CompanyName"] != DBNull.Value)
                    {
                        oSalesLead.CompanyName = (string)reader["CompanyName"];
                    }
                    else
                    {
                        oSalesLead.CompanyName = "";
                    }

                    oSalesLead.Name = (string)reader["Name"];
                    oSalesLead.Address = (string)reader["Address"];
                    oSalesLead.ContactNo = (string)reader["ContactNo"];
                    oSalesLead.Email = (string)reader["Email"];

                    if (reader["Profession"] != DBNull.Value)
                    {
                        oSalesLead.Profession = (string)reader["Profession"];
                    }
                    else
                    {
                        oSalesLead.Profession = "";
                    }
                    if (reader["AgeLevel"] != DBNull.Value)
                    {
                        oSalesLead.AgeLevel = (string)reader["AgeLevel"];
                    }
                    else
                    {
                        oSalesLead.AgeLevel = "";
                    }
                    if (reader["IncomLevel"] != DBNull.Value)
                    {
                        oSalesLead.IncomLevel = (string)reader["IncomLevel"];
                    }
                    else
                    {
                        oSalesLead.IncomLevel = "";
                    }
                    if (reader["InvoiceNo"] != DBNull.Value)
                    {
                        oSalesLead.InvoiceNo = (string)reader["InvoiceNo"];
                    }
                    else
                    {
                        oSalesLead.InvoiceNo = "";
                    }

                    oSalesLead.MAGID = (int)reader["MAGID"];
                    oSalesLead.MAGName = (string)reader["MAGName"];
                    oSalesLead.BrandID = (int)reader["BrandID"];
                    oSalesLead.BrandDesc = (string)reader["BrandDesc"];
                    oSalesLead.ModelName = (string)reader["ModelName"];
                    oSalesLead.NextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    oSalesLead.LeadAmount = Convert.ToDouble(reader["LeadAmount"].ToString());
                    oSalesLead.Status = (int)reader["Status"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oSalesLead.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oSalesLead.Remarks = "";
                    }
                    if (reader["Reason"] != DBNull.Value)
                    {
                        oSalesLead.Reason = (string)reader["Reason"];
                    }
                    else
                    {
                        oSalesLead.Reason = "";
                    }
                    oSalesLead.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesLead.CreateUserID = (int)reader["CreateUserID"];

                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oSalesLead.UpdateDate = (object)reader["UpdateDate"];
                    }
                    else
                    {
                        oSalesLead.UpdateDate = "";
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oSalesLead.UpdateUserID = (int)reader["UpdateUserID"];
                    }
                    else
                    {
                        oSalesLead.UpdateUserID = 1;
                    }
                    if (reader["SalesPersonID"] != DBNull.Value)
                    {
                        oSalesLead.SalesPersonID = (int)reader["SalesPersonID"];
                    }
                    else
                    {
                        oSalesLead.SalesPersonID = 1;
                    }
                    if (reader["Terminal"] != DBNull.Value)
                    {
                        oSalesLead.Terminal = (int)reader["Terminal"];
                    }
                    else
                    {
                        oSalesLead.Terminal = (int)Dictionary.Terminal.Branch_Office;
                    }
                    if (reader["SalesPerson"] != DBNull.Value)
                    {
                        oSalesLead.SalesPerson = (string)reader["SalesPerson"];
                    }
                    else
                    {
                        oSalesLead.SalesPerson = "";
                    }

                    if (reader["ConversionPossibility"] != DBNull.Value)
                    {
                        oSalesLead.ConversionPossibility = (int)reader["ConversionPossibility"];
                    }
                    else
                    {
                        oSalesLead.ConversionPossibility = -1;
                    }

                    if (reader["Qty"] != DBNull.Value)
                    {
                        oSalesLead.Qty = (int)reader["Qty"];
                    }
                    else
                    {
                        oSalesLead.Qty = 1;
                    }
                    if (reader["IsExistingConsumer"] != DBNull.Value)
                    {
                        oSalesLead.IsExistingConsumer = (int)reader["IsExistingConsumer"];
                    }
                    else
                    {
                        oSalesLead.IsExistingConsumer = 0;
                    }
                    if (reader["RefLeadNo"] != DBNull.Value)
                    {
                        oSalesLead.RefLeadNo = (string)reader["RefLeadNo"];
                    }
                    else
                    {
                        oSalesLead.RefLeadNo = "";
                    }

                    if (reader["LeadSource"] != DBNull.Value)
                    {
                        oSalesLead.LeadSource = (int)reader["LeadSource"];
                    }
                    else
                    {
                        oSalesLead.LeadSource = 0;
                    }
                    if (reader["ActivationID"] != DBNull.Value)
                    {
                        oSalesLead.ActivationID = (int)reader["ActivationID"];
                    }
                    else
                    {
                        oSalesLead.ActivationID = -1;
                    }

                    if (reader["ProductID"] != DBNull.Value)
                    {
                        oSalesLead.ProductID = (int)reader["ProductID"];
                    }
                    else
                    {
                        oSalesLead.ProductID = -1;
                    }
                    if (reader["ProductCode"] != DBNull.Value)
                    {
                        oSalesLead.ProductCode = (string)reader["ProductCode"];
                    }
                    else
                    {
                        oSalesLead.ProductCode = "";
                    }
                    if (reader["ProductName"] != DBNull.Value)
                    {
                        oSalesLead.ProductName = (string)reader["ProductName"];
                    }
                    else
                    {
                        oSalesLead.ProductName = "";
                    }


                    if (reader["ThanaID"] != DBNull.Value)
                    {
                        oSalesLead.ThanaID = (int)reader["ThanaID"];
                    }
                    else
                    {
                        oSalesLead.ThanaID = -1;
                    }
                    oSalesLead.DistrictID = (int)reader["DistrictID"];

                    oSalesLead.ThanaName = (string)reader["ThanaName"];
                    oSalesLead.DistrictName = (string)reader["DistrictName"];

                    oSalesLead.PGName = (string)reader["PGName"];
                    oSalesLead.AGName = (string)reader["AGName"];
                    oSalesLead.ASGName = (string)reader["ASGName"];


                    oSalesLead.SalesQty = Convert.ToInt32(reader["SalesQty"].ToString());
                    oSalesLead.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oSalesLead.ActivationName = (string)reader["ActivationName"];


                    InnerList.Add(oSalesLead);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshforRT(DateTime dFromDate, DateTime dToDate, DateTime dExpFromDate, DateTime dExpToDate, int nCustType, int nStatus, string sCompany, string sName, string sContact, string sLeadNo, bool IsCheck, bool IsCheckExpdt, int nSalesPersonID, int nLeadSource, int nMAGID, int nBrandID, bool IsNxtFDate, DateTime dtNxtFromDate, DateTime dtNxtTodate, int nASGID, int nAGID, int nPGID, string sProductName, string sModelName)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            dExpToDate = dExpToDate.AddDays(1);
            dtNxtTodate = dtNxtTodate.AddDays(1);
            string sSql = "";

            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select a.*, isnull('[' + EmployeeCode + ']' + EmployeeName, '') as SalesPerson,  " +
                    "isnull(ActivationName, '')  ActivationName,  " +
                    "isnull(ThanaName, '') ThanaName, isnull(DistrictID, -1) DistrictID,  " +
                    "isnull(DistrictName, '') DistrictName,isnull(SalesQty,0) SalesQty,isnull(InvoiceAmount,0) InvoiceAmount  " +
                    "From  " +
                    "(  " +
                    "Select xx.*,  " +
                    "isnull(ProductCode, '') ProductCode,  " +
                    "isnull(ProductName, '') ProductName,  " +
                    "isnull(ProductModel, '') ProductModel,isnull(AGID,-1) AGID,isnull(AGName,'') AGName,isnull(ASGID,-1) ASGID,isnull(ASGName,'') ASGName From  " +
                    "(  " +
                    "Select a.*, ShowroomCode, BrandDesc, c.PdtGroupName as MAGName, " +
                    "e.PdtGroupID as PGID,e.PdtGroupName as PGName " +
                    "From t_SalesLeadManagement a, t_Showroom b, t_ProductGroup c, t_Brand d, " +
                    "t_ProductGroup e " +
                    "where a.WarehouseID = b.WarehouseID and a.MAGID = c.PdtGroupID " +
                    "and a.BrandID = d.BrandID and c.ParentID = e.PdtGroupID and b.WarehouseID=" + Utility.WarehouseID + "  " +
                    ") xx  " +
                    "Left Outer Join  " +
                    "(  " +
                    "Select * From v_ProductDetails  " +
                    ") yy on xx.ProductID = yy.ProductID  " +
                    ") a  " +
                    "Left Outer Join  " +
                    "(  " +
                    "Select * From t_Employee  " +
                    ") b  " +
                    "on a.SalesPersonID = b.EmployeeID  " +
                    "left outer join  " +
                    "(  " +
                    "Select * From t_TDActivation  " +
                    ") c  " +
                    "on a.ActivationID = c.ActivationID  " +
                    "left outer join  " +
                    "(  " +
                    "Select a.GeoLocationID as ThanaID, a.GeoLocationName as ThanaName,  " +
                    "b.GeoLocationID as DistrictID, b.GeoLocationName as DistrictName  " +
                    "From t_GeoLocation a, t_GeoLocation b  " +
                    "where a.GeoLocationType = 2 and a.ParentID = b.GeoLocationID  " +
                    ") d  " +
                    "on a.ThanaID = d.ThanaID  " +
                    "left outer Join  " +
                    "(  " +
                    "Select InvoiceNo, SalesQty, InvoiceAmount  " +
                    "From t_SalesInvoice a,(  " +
                    "Select InvoiceID, sum(Quantity)SalesQty  " +
                    "From t_SalesInvoiceDetail group by InvoiceID) b  " +
                    "where a.InvoiceID = b.InvoiceID  " +
                    ") e  " +
                    "on a.InvoiceNo = e.InvoiceNo  " +
                    ") Main where 1 = 1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and LeadDate between '" + dFromDate + "' and '" + dToDate + "' and LeadDate<'" + dToDate + "' ";
            }
            if (IsCheckExpdt == false)
            {
                sSql = sSql + " and ExpExecuteDate between '" + dExpFromDate + "' and '" + dExpToDate + "' and ExpExecuteDate<'" + dExpToDate + "' ";
            }
            if (IsNxtFDate == false)
            {
                sSql = sSql + " and NextFollowUpDate between '" + dtNxtFromDate + "' and '" + dtNxtTodate + "' and NextFollowUpDate<'" + dtNxtTodate + "' ";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (nSalesPersonID != -1)
            {
                sSql = sSql + " AND SalesPersonID=" + nSalesPersonID + "";
            }

            if (nCustType != -1)
            {
                sSql = sSql + " AND CustomerType=" + nCustType + "";
            }

            if (sCompany != "")
            {
                sSql = sSql + " AND CompanyName like '%" + sCompany + "%'";
            }
            if (sName != "")
            {
                sSql = sSql + " AND Name like '%" + sName + "%'";
            }
            if (sContact != "")
            {
                sSql = sSql + " AND ContactNo like '%" + sContact + "%'";
            }
            if (sLeadNo != "")
            {
                sSql = sSql + " AND LeadNo like '%" + sLeadNo + "%'";
            }
            if (nLeadSource != -1)
            {
                sSql = sSql + " AND isnull(LeadSource,0)=" + nLeadSource + "";
            }

            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }

            if (nBrandID != -1)
            {
                sSql = sSql + " AND BrandID=" + nBrandID + "";
            }


            if (nPGID != -1)
            {
                sSql = sSql + " AND PGID=" + nPGID + "";
            }

            if (nASGID != -1)
            {
                sSql = sSql + " AND ASGID=" + nASGID + "";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }


            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%' or ProductCode like '%" + sProductName + "%'";
            }
            if (sModelName != "")
            {
                sSql = sSql + " AND ModelName like '%" + sModelName + "%'";
            }
            sSql = sSql + " Order by LeadID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLead oSalesLead = new SalesLead();
                    oSalesLead.LeadID = (int)reader["LeadID"];
                    oSalesLead.WarehouseID = (int)reader["WarehouseID"];
                    oSalesLead.ShowroomCode = (string)reader["ShowroomCode"];
                    oSalesLead.LeadNo = (string)reader["LeadNo"];
                    oSalesLead.LeadDate = Convert.ToDateTime(reader["LeadDate"].ToString());
                    oSalesLead.ExpExecuteDate = Convert.ToDateTime(reader["ExpExecuteDate"].ToString());
                    oSalesLead.CustomerType = (int)reader["CustomerType"];
                    if (reader["CompanyName"] != DBNull.Value)
                    {
                        oSalesLead.CompanyName = (string)reader["CompanyName"];
                    }
                    else
                    {
                        oSalesLead.CompanyName = "";
                    }

                    oSalesLead.Name = (string)reader["Name"];
                    oSalesLead.Address = (string)reader["Address"];
                    oSalesLead.ContactNo = (string)reader["ContactNo"];
                    oSalesLead.Email = (string)reader["Email"];

                    if (reader["Profession"] != DBNull.Value)
                    {
                        oSalesLead.Profession = (string)reader["Profession"];
                    }
                    else
                    {
                        oSalesLead.Profession = "";
                    }
                    if (reader["AgeLevel"] != DBNull.Value)
                    {
                        oSalesLead.AgeLevel = (string)reader["AgeLevel"];
                    }
                    else
                    {
                        oSalesLead.AgeLevel = "";
                    }
                    if (reader["IncomLevel"] != DBNull.Value)
                    {
                        oSalesLead.IncomLevel = (string)reader["IncomLevel"];
                    }
                    else
                    {
                        oSalesLead.IncomLevel = "";
                    }
                    if (reader["InvoiceNo"] != DBNull.Value)
                    {
                        oSalesLead.InvoiceNo = (string)reader["InvoiceNo"];
                    }
                    else
                    {
                        oSalesLead.InvoiceNo = "";
                    }

                    oSalesLead.MAGID = (int)reader["MAGID"];
                    oSalesLead.MAGName = (string)reader["MAGName"];
                    oSalesLead.BrandID = (int)reader["BrandID"];
                    oSalesLead.BrandDesc = (string)reader["BrandDesc"];
                    oSalesLead.ModelName = (string)reader["ModelName"];
                    oSalesLead.NextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    oSalesLead.LeadAmount = Convert.ToDouble(reader["LeadAmount"].ToString());
                    oSalesLead.Status = (int)reader["Status"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oSalesLead.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oSalesLead.Remarks = "";
                    }
                    if (reader["Reason"] != DBNull.Value)
                    {
                        oSalesLead.Reason = (string)reader["Reason"];
                    }
                    else
                    {
                        oSalesLead.Reason = "";
                    }
                    oSalesLead.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesLead.CreateUserID = (int)reader["CreateUserID"];

                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oSalesLead.UpdateDate = (object)reader["UpdateDate"];
                    }
                    else
                    {
                        oSalesLead.UpdateDate = "";
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oSalesLead.UpdateUserID = (int)reader["UpdateUserID"];
                    }
                    else
                    {
                        oSalesLead.UpdateUserID = 1;
                    }
                    if (reader["SalesPersonID"] != DBNull.Value)
                    {
                        oSalesLead.SalesPersonID = (int)reader["SalesPersonID"];
                    }
                    else
                    {
                        oSalesLead.SalesPersonID = 1;
                    }
                    if (reader["Terminal"] != DBNull.Value)
                    {
                        oSalesLead.Terminal = (int)reader["Terminal"];
                    }
                    else
                    {
                        oSalesLead.Terminal = (int)Dictionary.Terminal.Branch_Office;
                    }
                    if (reader["SalesPerson"] != DBNull.Value)
                    {
                        oSalesLead.SalesPerson = (string)reader["SalesPerson"];
                    }
                    else
                    {
                        oSalesLead.SalesPerson = "";
                    }

                    if (reader["ConversionPossibility"] != DBNull.Value)
                    {
                        oSalesLead.ConversionPossibility = (int)reader["ConversionPossibility"];
                    }
                    else
                    {
                        oSalesLead.ConversionPossibility = -1;
                    }

                    if (reader["Qty"] != DBNull.Value)
                    {
                        oSalesLead.Qty = (int)reader["Qty"];
                    }
                    else
                    {
                        oSalesLead.Qty = 1;
                    }
                    if (reader["IsExistingConsumer"] != DBNull.Value)
                    {
                        oSalesLead.IsExistingConsumer = (int)reader["IsExistingConsumer"];
                    }
                    else
                    {
                        oSalesLead.IsExistingConsumer = 0;
                    }
                    if (reader["RefLeadNo"] != DBNull.Value)
                    {
                        oSalesLead.RefLeadNo = (string)reader["RefLeadNo"];
                    }
                    else
                    {
                        oSalesLead.RefLeadNo = "";
                    }

                    if (reader["LeadSource"] != DBNull.Value)
                    {
                        oSalesLead.LeadSource = (int)reader["LeadSource"];
                    }
                    else
                    {
                        oSalesLead.LeadSource = 0;
                    }
                    if (reader["ActivationID"] != DBNull.Value)
                    {
                        oSalesLead.ActivationID = (int)reader["ActivationID"];
                    }
                    else
                    {
                        oSalesLead.ActivationID = -1;
                    }

                    if (reader["ProductID"] != DBNull.Value)
                    {
                        oSalesLead.ProductID = (int)reader["ProductID"];
                    }
                    else
                    {
                        oSalesLead.ProductID = -1;
                    }
                    if (reader["ProductCode"] != DBNull.Value)
                    {
                        oSalesLead.ProductCode = (string)reader["ProductCode"];
                    }
                    else
                    {
                        oSalesLead.ProductCode = "";
                    }
                    if (reader["ProductName"] != DBNull.Value)
                    {
                        oSalesLead.ProductName = (string)reader["ProductName"];
                    }
                    else
                    {
                        oSalesLead.ProductName = "";
                    }


                    if (reader["ThanaID"] != DBNull.Value)
                    {
                        oSalesLead.ThanaID = (int)reader["ThanaID"];
                    }
                    else
                    {
                        oSalesLead.ThanaID = -1;
                    }
                    oSalesLead.DistrictID = (int)reader["DistrictID"];

                    oSalesLead.ThanaName = (string)reader["ThanaName"];
                    oSalesLead.DistrictName = (string)reader["DistrictName"];

                    oSalesLead.PGName = (string)reader["PGName"];
                    oSalesLead.AGName = (string)reader["AGName"];
                    oSalesLead.ASGName = (string)reader["ASGName"];


                    oSalesLead.SalesQty = Convert.ToInt32(reader["SalesQty"].ToString());
                    oSalesLead.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oSalesLead.ActivationName = (string)reader["ActivationName"];


                    InnerList.Add(oSalesLead);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForHO(DateTime dFromDate, DateTime dToDate, int nCustType, int nStatus, string sCompany, string sName, string sContact, string sLeadNo, bool IsCheck, int nWHID, int nTerminal, int nLeadSource, int nActivation, int nIsVelid, int nIsverified,int _isHVACLead, int nLeadStatus)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From  " +
                    "(    " +
                    "Select isnull(a.ThanaID,-1) ThanaID,isnull(DistrictID,-1) DistrictID,isnull(g.ThanaName,'') ThanaName,  " +
                    "isnull(g.DistrictName,'') DistrictName,LeadID,isnull(a.WarehouseID,-1) WarehouseID,isnull(ShowroomCode,'') ShowroomCode,    " +
                    "LeadNo,LeadDate,ExpExecuteDate,CustomerType,CompanyName,      " +
                    "Name,Address,a.ContactNo,a.Email,Profession,AgeLevel,    " +
                    "IncomLevel,MAGID,a.BrandID,ModelName,NextFollowUpDate,     " +
                    "LeadAmount,Status,Remarks,Reason,CreateDate,CreateUserID,    " +
                    "UpdateDate,UpdateUserID,SalesPersonID,ConversionPossibility,      " +
                    "isnull(Terminal,2) as Terminal,isnull(InvoiceNo,'')  InvoiceNo,   " +
                    "'[' +EmployeeCode+']'+ EmployeeName as SalesPerson, isnull(Qty,1) Qty,    " +
                    "IsExistingConsumer,RefLeadNo,LeadSource,isnull(a.ActivationID,-1) ActivationID,isnull(ActivationName,'') ActivationName, isnull(IsValidLead,0) IsValidLead,isnull(IsVerified,0) IsVerified,isnull(a.ProductID,-1) ProductID,isnull(p.ProductCode,'') ProductCode, " +
                    "isnull(P.ProductName, '') ProductName,isnull(p.ProductModel, '') ProductModel,isnull(IsHVACLead,0) IsHVACLead, isnull(LeadStatusID,2) LeadStatus From     " +
                    "(Select * From t_SalesLeadManagement) a    " +
                    "Left Outer Join     " +
                    "(Select * From t_Employee) b     " +
                    "on a.SalesPersonID=b.EmployeeID    " +
                    "Left Outer Join     " +
                    "(Select * From t_Showroom) c    " +
                    "on a.WarehouseID=c.WarehouseID  " +
                    "Left Outer Join   " +
                    "(  " +
                    "Select a.GeoLocationID as ThanaID,a.GeoLocationName as ThanaName,a.ParentID as DistrictID,b.GeoLocationName as DistrictName   " +
                    "From t_GeoLocation a,t_GeoLocation b   " +
                    "where a.GeoLocationType=2 and a.ParentID=b.GeoLocationID  " +
                    ") G  on a.ThanaID=g.ThanaID  " +
                    "Left Outer Join " +
                    "( " +
                    "Select * From t_Product " +
                    ") P on a.ProductID = p.ProductID  " +
                    "Left Outer Join     " +
                    "(Select ActivationID,ActivationName From t_tdactivation) i     " +
                    "on a.ActivationID=i.ActivationID     " +
                    ") Main where isnull(IsHVACLead,0) =" + _isHVACLead + "";
                 

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and LeadDate between '" + dFromDate + "' and '" + dToDate + "' and LeadDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (nWHID != -1)
            {
                sSql = sSql + " AND WarehouseID=" + nWHID + "";
            }

            if (nCustType != -1)
            {
                sSql = sSql + " AND CustomerType=" + nCustType + "";
            }
            if (nTerminal != -1)
            {
                sSql = sSql + " AND Terminal=" + nTerminal + "";
            }
            if (sCompany != "")
            {
                sSql = sSql + " AND CompanyName like '%" + sCompany + "%'";
            }
            if (sName != "")
            {
                sSql = sSql + " AND Name like '%" + sName + "%'";
            }
            if (sContact != "")
            {
                sSql = sSql + " AND ContactNo like '%" + sContact + "%'";
            }
            if (sLeadNo != "")
            {
                sSql = sSql + " AND LeadNo like '%" + sLeadNo + "%'";
            }
            if (nIsVelid != -1)
            {
                sSql = sSql + " AND IsValidLead =" + nIsVelid + "";
            }

            if (nLeadSource != -1)
            {
                sSql = sSql + " AND LeadSource =" + nLeadSource + "";
            }

            if (nActivation != -1)
            {
                sSql = sSql + " AND ActivationID =" + nActivation + "";
            }

            if (nIsverified != -1)
            {
                sSql = sSql + " AND IsVerified =" + nIsverified + "";
            }

            if (nLeadStatus != -1)
            {
                sSql = sSql + " AND LeadStatus =" + nLeadStatus + "";
            }       

            sSql = sSql + " Order by LeadID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLead oSalesLead = new SalesLead();
                    oSalesLead.ThanaID = (int)reader["ThanaID"];
                    oSalesLead.DistrictID = (int)reader["DistrictID"];
                    oSalesLead.ThanaName = (string)reader["ThanaName"];
                    oSalesLead.DistrictName = (string)reader["DistrictName"];
                    oSalesLead.ProductName = (string)reader["ProductName"];
                    oSalesLead.ProductCode = (string)reader["ProductCode"];
                    oSalesLead.ProductID = (int)reader["ProductID"];
                    oSalesLead.LeadID = (int)reader["LeadID"];
                    oSalesLead.WarehouseID = (int)reader["WarehouseID"];
                    oSalesLead.ShowroomCode = (string)reader["ShowroomCode"];
                    oSalesLead.InvoiceNo = (string)reader["InvoiceNo"];
                    oSalesLead.LeadNo = (string)reader["LeadNo"];
                    oSalesLead.LeadDate = Convert.ToDateTime(reader["LeadDate"].ToString());
                    oSalesLead.ExpExecuteDate = Convert.ToDateTime(reader["ExpExecuteDate"].ToString());
                    oSalesLead.CustomerType = (int)reader["CustomerType"];
                    if (reader["CompanyName"] != DBNull.Value)
                    {
                        oSalesLead.CompanyName = (string)reader["CompanyName"];
                    }
                    else
                    {
                        oSalesLead.CompanyName = "";
                    }

                    oSalesLead.Name = (string)reader["Name"];
                    oSalesLead.Address = (string)reader["Address"];
                    oSalesLead.ContactNo = (string)reader["ContactNo"];
                    oSalesLead.Email = (string)reader["Email"];

                    if (reader["Profession"] != DBNull.Value)
                    {
                        oSalesLead.Profession = (string)reader["Profession"];
                    }
                    else
                    {
                        oSalesLead.Profession = "";
                    }
                    if (reader["AgeLevel"] != DBNull.Value)
                    {
                        oSalesLead.AgeLevel = (string)reader["AgeLevel"];
                    }
                    else
                    {
                        oSalesLead.AgeLevel = "";
                    }
                    if (reader["IncomLevel"] != DBNull.Value)
                    {
                        oSalesLead.IncomLevel = (string)reader["IncomLevel"];
                    }
                    else
                    {
                        oSalesLead.IncomLevel = "";
                    }


                    oSalesLead.MAGID = (int)reader["MAGID"];
                    oSalesLead.BrandID = (int)reader["BrandID"];
                    oSalesLead.ModelName = (string)reader["ModelName"];
                    oSalesLead.NextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    oSalesLead.LeadAmount = Convert.ToDouble(reader["LeadAmount"].ToString());
                    oSalesLead.Status = (int)reader["Status"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oSalesLead.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oSalesLead.Remarks = "";
                    }
                    if (reader["Reason"] != DBNull.Value)
                    {
                        oSalesLead.Reason = (string)reader["Reason"];
                    }
                    else
                    {
                        oSalesLead.Reason = "";
                    }
                    oSalesLead.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesLead.CreateUserID = (int)reader["CreateUserID"];

                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oSalesLead.UpdateDate = (object)reader["UpdateDate"];
                    }
                    else
                    {
                        oSalesLead.UpdateDate = "";
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oSalesLead.UpdateUserID = (int)reader["UpdateUserID"];
                    }
                    else
                    {
                        oSalesLead.UpdateUserID = 1;
                    }
                    if (reader["SalesPersonID"] != DBNull.Value)
                    {
                        oSalesLead.SalesPersonID = (int)reader["SalesPersonID"];
                    }
                    else
                    {
                        oSalesLead.SalesPersonID = 1;
                    }
                    if (reader["Terminal"] != DBNull.Value)
                    {
                        oSalesLead.Terminal = (int)reader["Terminal"];
                    }
                    else
                    {
                        oSalesLead.Terminal = (int)Dictionary.Terminal.Branch_Office;
                    }
                    if (reader["SalesPerson"] != DBNull.Value)
                    {
                        oSalesLead.SalesPerson = (string)reader["SalesPerson"];
                    }
                    else
                    {
                        oSalesLead.SalesPerson = "";
                    }
                    oSalesLead.Qty = (int)reader["Qty"];
                    /////
                    if (reader["IsExistingConsumer"] != DBNull.Value)
                    {
                        oSalesLead.IsExistingConsumer = (int)reader["IsExistingConsumer"];
                    }
                    else
                    {
                        oSalesLead.IsExistingConsumer = 0;
                    }
                    if (reader["RefLeadNo"] != DBNull.Value)
                    {
                        oSalesLead.RefLeadNo = (string)reader["RefLeadNo"];
                    }
                    else
                    {
                        oSalesLead.RefLeadNo = "";
                    }

                    if (reader["LeadSource"] != DBNull.Value)
                    {
                        oSalesLead.LeadSource = (int)reader["LeadSource"];
                    }
                    else
                    {
                        oSalesLead.LeadSource = 0;
                    }
                    if (reader["ActivationID"] != DBNull.Value)
                    {
                        oSalesLead.ActivationID = (int)reader["ActivationID"];
                    }
                    else
                    {
                        oSalesLead.ActivationID = -1;
                    }

                    if (reader["ActivationName"] != DBNull.Value)
                    {
                        oSalesLead.ActivationName = (string)reader["ActivationName"];
                    }
                    else
                    {
                        oSalesLead.ActivationName = "";
                    }


                    if (reader["IsValidLead"] != DBNull.Value)
                    {
                        oSalesLead.IsValidLead = (int)reader["IsValidLead"];
                    }
                    else
                    {
                        oSalesLead.IsValidLead = 0;
                    }
                    if (reader["ConversionPossibility"] != DBNull.Value)
                    {
                        oSalesLead.ConversionPossibility = (int)reader["ConversionPossibility"];
                    }
                    else
                    {
                        oSalesLead.ConversionPossibility = 1;
                    }
                    if (reader["IsVerified"] != DBNull.Value)
                    {
                        oSalesLead.IsVerified = (int)reader["IsVerified"];
                    }
                    else
                    {
                        oSalesLead.IsVerified = 0;
                    }

                    if (reader["LeadStatus"] != DBNull.Value)
                    {
                        oSalesLead.LeadStatus = (int)reader["LeadStatus"];
                    }
                    else
                    {
                        oSalesLead.LeadStatus = 2;
                    }

                    InnerList.Add(oSalesLead);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void Refresh(string sCompany, string sName, string sContact, int nCustomerType)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            if (nCustomerType == -1)
            {
                sSql = "Select* From " +
                    "( " +
                    "Select a.*, isnull(ConsumerCode, '') ConsumerCode From " +
                    "( " +
                    "SELECT * FROM t_SalesLeadManagement " +
                    ") a " +
                    "Left outer join " +
                    "( " +
                    "Select * From t_RetailConsumer " +
                    ") b " +
                    "on a.ConsumerID = b.ConsumerID " +
                    ") x where 1 = 1";

            }
            else if (nCustomerType == (int)Dictionary.POSInvoiceUIControl.eStore)
            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select a.*, isnull(ConsumerCode, '') ConsumerCode  " +
                    "From  " +
                    "(  " +
                    "SELECT isnull(ConsumerID, 0) ConsumerID, LeadID, WarehouseID, LeadNo,  " +
                    "LeadDate, ExpExecuteDate, CustomerType,  " +
                    "CompanyName, Name, Address,  " +
                    "ContactNo, Email, Profession, AgeLevel, IncomLevel,  " +
                    "MAGID, BrandID, ModelName, NextFollowUpDate,  " +
                    "LeadAmount, Status, isnull(Remarks, '') Remarks,  " +
                    "Reason, CreateDate,  " +
                    "CreateUserID, UpdateDate, UpdateUserID, IsExistingConsumer, RefLeadNo  " +
                    "FROM t_SalesLeadManagement where Status not in (3, 4) and CustomerType = 6  " +
                    "Union All  " +
                    "Select 0 as ConsumerID, EcomOrderID as LeadID, WarehouseID, OrderNo LeadNo,  " +
                    "OrderDate LeadDate, OrderDate ExpExecuteDate, 6 CustomerType,  " +
                    "'' CompanyName, ConsumerName Name, a.DeliveryAddress Address,  " +
                    "ContactNo, a.Email, '' Profession, '' AgeLevel, '' IncomLevel,  " +
                    "- 1 MAGID, -1 BrandID, '' ModelName, OrderDate NextFollowUpDate,  " +
                    "Amount LeadAmount, Status, isnull(Remarks, '') Remarks,  " +
                    "'' Reason, OrderDate CreateDate,  " +
                    "- 1 CreateUserID, OrderDate UpdateDate, -1 UpdateUserID, 0 IsExistingConsumer, '' RefLeadNo  " +
                    "From t_SalesinvoiceEcommerce a, t_Showroom b  " +
                    "where a.Outlet = b.ShowroomCode and Status not in (3, 4)  " +
                    ") a  " +
                    "Left outer Join  " +
                    "(  " +
                    "Select * From t_RetailConsumer  " +
                    ") b  " +
                    "on a.ConsumerID = b.ConsumerID  " +
                    ") x where 1 = 1";
            }
            else
            {
                sSql = "Select* From " +
                        "( " +
                        "Select a.*, isnull(ConsumerCode, '') ConsumerCode From " +
                        "( " +
                        "SELECT * FROM t_SalesLeadManagement where Status not in (3,4) and CustomerType = " + nCustomerType + "  " +
                        ") a " +
                        "Left outer join " +
                        "( " +
                        "Select * From t_RetailConsumer " +
                        ") b " +
                        "on a.ConsumerID = b.ConsumerID " +
                        ") x where 1 = 1";

               // sSql = " SELECT * FROM t_SalesLeadManagement where Status not in (3,4) and CustomerType = " + nCustomerType + "";

            }

            if (sCompany != "")
            {
                sSql = sSql + " AND CompanyName like '%" + sCompany + "%'";
            }
            if (sName != "")
            {
                sSql = sSql + " AND Name like '%" + sName + "%'";
            }
            if (sContact != "")
            {
                sSql = sSql + " AND ContactNo like '%" + sContact + "%'";
            }

            sSql = sSql + " Order by LeadID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLead oSalesLead = new SalesLead();
                    oSalesLead.LeadID = (int)reader["LeadID"];
                    oSalesLead.WarehouseID = (int)reader["WarehouseID"];
                    oSalesLead.LeadNo = (string)reader["LeadNo"];
                    oSalesLead.LeadDate = Convert.ToDateTime(reader["LeadDate"].ToString());
                    oSalesLead.ExpExecuteDate = Convert.ToDateTime(reader["ExpExecuteDate"].ToString());
                    oSalesLead.CustomerType = (int)reader["CustomerType"];
                    if (reader["CompanyName"] != DBNull.Value)
                    {
                        oSalesLead.CompanyName = (string)reader["CompanyName"];
                    }
                    else
                    {
                        oSalesLead.CompanyName = "";
                    }

                    oSalesLead.Name = (string)reader["Name"];
                    oSalesLead.Address = (string)reader["Address"];
                    oSalesLead.ContactNo = (string)reader["ContactNo"];
                    oSalesLead.Email = (string)reader["Email"];

                    if (reader["Profession"] != DBNull.Value)
                    {
                        oSalesLead.Profession = (string)reader["Profession"];
                    }
                    else
                    {
                        oSalesLead.Profession = "";
                    }
                    if (reader["AgeLevel"] != DBNull.Value)
                    {
                        oSalesLead.AgeLevel = (string)reader["AgeLevel"];
                    }
                    else
                    {
                        oSalesLead.AgeLevel = "";
                    }
                    if (reader["IncomLevel"] != DBNull.Value)
                    {
                        oSalesLead.IncomLevel = (string)reader["IncomLevel"];
                    }
                    else
                    {
                        oSalesLead.IncomLevel = "";
                    }


                    oSalesLead.MAGID = (int)reader["MAGID"];
                    oSalesLead.BrandID = (int)reader["BrandID"];
                    oSalesLead.ModelName = (string)reader["ModelName"];
                    oSalesLead.NextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    oSalesLead.LeadAmount = Convert.ToDouble(reader["LeadAmount"].ToString());
                    oSalesLead.Status = (int)reader["Status"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oSalesLead.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oSalesLead.Remarks = "";
                    }
                    if (reader["Reason"] != DBNull.Value)
                    {
                        oSalesLead.Reason = (string)reader["Reason"];
                    }
                    else
                    {
                        oSalesLead.Reason = "";
                    }
                    oSalesLead.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesLead.CreateUserID = (int)reader["CreateUserID"];

                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oSalesLead.UpdateDate = (object)reader["UpdateDate"];
                    }
                    else
                    {
                        oSalesLead.UpdateDate = "";
                    }
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oSalesLead.UpdateUserID = (int)reader["UpdateUserID"];
                    }
                    else
                    {
                        oSalesLead.UpdateUserID = 1;
                    }

                    if (reader["IsExistingConsumer"] != DBNull.Value)
                    {
                        oSalesLead.IsExistingConsumer = (int)reader["IsExistingConsumer"];
                    }
                    else
                    {
                        oSalesLead.IsExistingConsumer = 0;
                    }
                    if (reader["RefLeadNo"] != DBNull.Value)
                    {
                        oSalesLead.RefLeadNo = (string)reader["RefLeadNo"];
                    }
                    else
                    {
                        oSalesLead.RefLeadNo = "";
                    }

                    if (reader["ConsumerID"] != DBNull.Value)
                    {
                        oSalesLead.ConsumerID = (int)reader["ConsumerID"];
                    }
                    else
                    {
                        oSalesLead.ConsumerID = 0;
                    }
                    if (reader["ConsumerCode"] != DBNull.Value)
                    {
                        oSalesLead.ConsumerCode = (string)reader["ConsumerCode"];
                    }
                    else
                    {
                        oSalesLead.ConsumerCode = "";
                    }

                    InnerList.Add(oSalesLead);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void LeadTgtVsAchExecutiveWise(int nWarehouseID, DateTime dtFirstDateOfThisMonth,DateTime dtLastDateOfThisMonth, int nTYear, int nTMonth, int nEmpID)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select s.*,isnull(nullif(ConverttoSalesAmt,0)/nullif(TotalLeadAmt,0)*100,0) as Achievment From (Select Main.*,((InitialLeadQty+NewLeadQty)- (ShiftedLeadQty+CancelledLeadQty)) as TotalLeadQty, " +
                   "((InitialLead+NewLead)- (ShiftedLead+CancelledLeadAmt)) as TotalLeadAmt, " +
                   " LeadTarget-((InitialLead+NewLead)- (ShiftedLead+CancelledLeadAmt)) as ShortFall,EmployeeCode,EmployeeName  " +
                   //" isnull(nullif(ConverttoSalesAmt,0)/(nullif(InitialLead,0)+nullif(NewLead,0))*100,0) as Achievment " +
                   " From  " +
                   " ( " +
                   " Select SalesPersonID,Channel, " +
                   " sum(isnull(LeadTarget,0)) as LeadTarget, " +
                   " sum(isnull(InitialLeadQty,0)) as InitialLeadQty,sum(isnull(InitialLead,0)) as InitialLead, " +
                   " sum(isnull(NewLeadQty,0)) as NewLeadQty,sum(isnull(NewLead,0)) as NewLead, " +
                   " sum(isnull(ShiftedLeadQty,0)) as ShiftedLeadQty,sum(isnull(ShiftedLead,0)) as ShiftedLead, " +
                   " sum(isnull(CancelledLeadQty,0)) as CancelledLeadQty,sum(isnull(CancelledLeadAmt,0)) as CancelledLeadAmt, " +
                   " sum(isnull(ConverttoSalesQty,0)) as ConverttoSalesQty,sum(isnull(ConverttoSalesAmt,0)) as ConverttoSalesAmt   " +
                   " From  " +
                   " (  " + //--Target---
                   " Select SalesPersonID,Channel=Case when Channel=3 then 'Dealer' " +
                   " when Channel=4 then 'Retail' " +
                   " when Channel=13 then 'B2B' "+
                   " when Channel=16 then 'e-Store' " +
                   " else 'Other' end,sum(TargetAmount) as LeadTarget,0 as InitialLeadQty,0 as InitialLead, 0 as NewLeadQty,0 as NewLead, " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty,0 as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt " +
                   " From t_PLanExecutiveLeadTarget where CustomerID=(Select CustomerID From t_Showroom where WarehouseID=" + nWarehouseID + ")  " +
                   " and TargetType=" + (int)Dictionary.PlanVersionType.ExecutiveLeadTarget + "and TMonth=" + nTMonth + " and TYear=" + nTYear + " " +
                   " group by SalesPersonID,Channel " +
                   " Union All " +
                // ---End Target---
                // ----InitialLead---
                   " Select SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,count(LeadID) as InitialLeadQty, " +
                   " sum(LeadAmount) as InitialLead,0 as NewLeadQty,0 as NewLead, " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty, " +
                   " 0 as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt " +
                   " From t_SalesLeadManagement  " +
                   " where month(ExpExecuteDate)=" + nTMonth + " and Year(ExpExecuteDate)=" + nTYear + " and WarehouseID=" + nWarehouseID + "   " +
                   " and  LeadDate<'" + dtFirstDateOfThisMonth + "' and LeadID not in  " +
                   " (Select LeadID From (Select WarehouseID,LeadID,LeadNo From  " +
                   " (Select WarehouseID,LeadID,LeadNo,CancelDate=Case when CancelDate is not null then CancelDate " +
                   " when CancelDate<>'' then CancelDate else UpdateDate end   " +
                   " From t_SalesLeadManagement where LeadDate<'" + dtFirstDateOfThisMonth + "' " +
                   " and Status=4 ) a where CancelDate<'" + dtFirstDateOfThisMonth + "' " +
                   " Union All " +
                   " Select WarehouseID,LeadID,LeadNo " +
                   " From t_SalesLeadManagement where LeadDate<'" + dtFirstDateOfThisMonth + "' and InvoiceDate<'" + dtFirstDateOfThisMonth + "' " +
                   " and Status=3 ) a) " +
                   " group by SalesPersonID,CustomerType " +
                   " Union All " +
                // ---End InitialLead-----
                // ---New Lead-----
                   " Select SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty,0 as InitialLead,count(LeadID) as NewLeadQty, " +
                   " sum(LeadAmount) as NewLead, 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty, " +
                   " 0 as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt " +
                   " From t_SalesLeadManagement  " +
                   " where WarehouseID=" + nWarehouseID + " and month(ExpExecuteDate)=" + nTMonth + " and Year(ExpExecuteDate)=" + nTYear + " " +
                   " and Month(LeadDate)=" + nTMonth + " and Year(LeadDate)=" + nTYear + " group by SalesPersonID,CustomerType " +
                   " Union All " +
                // ---End New Lead----- "+
                // ----ShiftedLead---
                   " Select SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty, 0 as InitialLead,0 as NewLeadQty, 0 as NewLead, " +
                   " count(LeadID) as ShiftedLeadQty,sum(LeadAmount) as ShiftedLead,0 as CancelledLeadQty,0 as CancelledLeadAmt, " +
                   " 0 as ConverttoSalesQty,0 as ConverttoSalesAmt " +
                   " From t_SalesLeadManagement where LeadNo in  " +
                   " (Select LeadNo From  " +
                   " (Select LeadNo,max(ExpExecuteDate) ExpExecuteDate From t_SalesLeadManagementHistory where LeadNo in ( " +
                   " Select LeadNo From t_SalesLeadManagement  " +
                   " where month(ExpExecuteDate)=" + nTMonth + " and Year(ExpExecuteDate)=" + nTYear + " and  " +
                   " LeadID not in (Select LeadID From (Select WarehouseID,LeadID,LeadNo From  " +
                   " (Select WarehouseID,LeadID,LeadNo,CancelDate=Case when CancelDate is not null then CancelDate " +
                   " when CancelDate<>'' then CancelDate else UpdateDate end   " +
                   " From t_SalesLeadManagement where LeadDate<'" + dtFirstDateOfThisMonth + "' " +
                   " and Status=4 ) a where CancelDate<'" + dtFirstDateOfThisMonth + "' " +
                   " Union All " +
                   " Select WarehouseID,LeadID,LeadNo " +
                   " From t_SalesLeadManagement where LeadDate<'" + dtFirstDateOfThisMonth + "' and InvoiceDate<'" + dtFirstDateOfThisMonth + "' " +
                   " and Status=3 ) a))  " +
                   " group by LeadNo) Main where ExpExecuteDate > '" + dtLastDateOfThisMonth + "'   " +// --last day of selected month 
                   " )  and WarehouseID=" + nWarehouseID + " " +
                   " group by SalesPersonID,CustomerType " +
                   " Union All " +
                // ----END ShiftedLead---
                // ----Cancel----
                   " Select SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty,0 as InitialLead, 0 as NewLeadQty,0 as NewLead, " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,count(LeadID) as CancelledLeadQty, " +
                   " sum(LeadAmount) as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt   " +
                   " From t_SalesLeadManagement  " +
                   " where WarehouseID=" + nWarehouseID + " and  " +
                   " month(ExpExecuteDate)=" + nTMonth + " and Year(ExpExecuteDate)=" + nTYear + " and Status=4 " +
                   " group by SalesPersonID,CustomerType " +
                   " Union All " +
                // ----END Cancel----
                // ---ConverttoSalesAmt---
                   " Select a.SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty,0 as InitialLead, 0 as NewLeadQty,0 as NewLead, " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty, " +
                   " 0 as CancelledLeadAmt,count(InvoiceID) as ConverttoSalesQty,sum(InvoiceAmount) as ConverttoSalesAmt  " +
                   " From t_SalesLeadManagement a,t_SalesInvoice b " +
                   " where a.InvoiceNo=b.InvoiceNo and a.WarehouseID=b.WarehouseID and a.WarehouseID=" + nWarehouseID + " and  " +
                   " month(ExpExecuteDate)=" + nTMonth + "  and Year(ExpExecuteDate)=" + nTYear + " and Status=3 " +
                   " group by a.SalesPersonID,CustomerType " +
                // ---END ConverttoSalesAmt----
                   " )  a group by SalesPersonID,Channel " +
                   " ) Main,t_Employee b where Main.SalesPersonID=b.EmployeeID) s where 1=1";

            if (nEmpID != -1)
            {
                sSql = sSql + " AND SalesPersonID=" + nEmpID + "";
            }
            //sSql = sSql + "  order by CustomerType";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLead _oSalesLead = new SalesLead();
                    _oSalesLead.SalesPersonID = Convert.ToInt32(reader["SalesPersonID"].ToString());
                    _oSalesLead.Channel = reader["Channel"].ToString();
                    _oSalesLead.EmployeeCode = reader["EmployeeCode"].ToString();
                    _oSalesLead.Employeename = reader["Employeename"].ToString();
                    _oSalesLead.LeadTarget = Convert.ToDouble(reader["LeadTarget"].ToString());


                    _oSalesLead.InitialLeadQty = Convert.ToInt32(reader["InitialLeadQty"].ToString());
                    _oSalesLead.InitialLead = Convert.ToDouble(reader["InitialLead"].ToString());

                    _oSalesLead.NewLeadQty = Convert.ToInt32(reader["NewLeadQty"].ToString());
                    _oSalesLead.NewLead = Convert.ToDouble(reader["NewLead"].ToString());

                    _oSalesLead.ShiftedLeadQty = Convert.ToInt32(reader["ShiftedLeadQty"].ToString());
                    _oSalesLead.ShiftedLead = Convert.ToDouble(reader["ShiftedLead"].ToString());

                    _oSalesLead.CancelledLeadQty = Convert.ToInt32(reader["CancelledLeadQty"].ToString());
                    _oSalesLead.CancelledLeadAmt = Convert.ToDouble(reader["CancelledLeadAmt"].ToString());

                    _oSalesLead.ConverttoSalesQty = Convert.ToInt32(reader["ConverttoSalesQty"].ToString());
                    _oSalesLead.ConverttoSalesAmt = Convert.ToDouble(reader["ConverttoSalesAmt"].ToString());

                    _oSalesLead.TotalLeadQty = Convert.ToInt32(reader["TotalLeadQty"].ToString());
                    _oSalesLead.TotalLeadAmt = Convert.ToDouble(reader["TotalLeadAmt"].ToString());

                    _oSalesLead.ShortFall = Convert.ToDouble(reader["ShortFall"].ToString());

                    _oSalesLead.Achievment = Convert.ToDouble(reader["Achievment"].ToString());
                    InnerList.Add(_oSalesLead);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void LeadTgtVsAchExecutiveWiseRetail(int nWarehouseID, DateTime dtFirstDateOfThisMonth, DateTime dtLastDateOfThisMonth, int nTYear, int nTMonth, int nEmpID)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select s.*,isnull(nullif(ConverttoSalesAmt,0)/nullif(TotalLeadAmt,0)*100,0) as Achievment From (Select Main.*,((InitialLeadQty+NewLeadQty)- (ShiftedLeadQty+CancelledLeadQty)) as TotalLeadQty, " +
                   "((InitialLead+NewLead)- (ShiftedLead+CancelledLeadAmt)) as TotalLeadAmt, " +
                   " LeadTarget-((InitialLead+NewLead)- (ShiftedLead+CancelledLeadAmt)) as ShortFall,EmployeeCode,EmployeeName  " +
                   //" isnull(nullif(ConverttoSalesAmt,0)/(nullif(InitialLead,0)+nullif(NewLead,0))*100,0) as Achievment " +
                   " From  " +
                   " ( " +
                   " Select SalesPersonID,Channel, " +
                   " sum(isnull(LeadTarget,0)) as LeadTarget, " +
                   " sum(isnull(InitialLeadQty,0)) as InitialLeadQty,sum(isnull(InitialLead,0)) as InitialLead, " +
                   " sum(isnull(NewLeadQty,0)) as NewLeadQty,sum(isnull(NewLead,0)) as NewLead, " +
                   " sum(isnull(ShiftedLeadQty,0)) as ShiftedLeadQty,sum(isnull(ShiftedLead,0)) as ShiftedLead, " +
                   " sum(isnull(CancelledLeadQty,0)) as CancelledLeadQty,sum(isnull(CancelledLeadAmt,0)) as CancelledLeadAmt, " +
                   " sum(isnull(ConverttoSalesQty,0)) as ConverttoSalesQty,sum(isnull(ConverttoSalesAmt,0)) as ConverttoSalesAmt   " +
                   " From  " +
                   " (  " + //--Target---
                   " Select SalesPersonID,Channel=Case when Channel=3 then 'Dealer' " +
                   " when Channel=4 then 'Retail' " +
                   " when Channel=13 then 'B2B' " +
                   " when Channel=16 then 'e-Store' " +
                   " else 'Other' end,sum(TargetAmount) as LeadTarget,0 as InitialLeadQty,0 as InitialLead, 0 as NewLeadQty,0 as NewLead, " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty,0 as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt " +
                   " From t_PLanExecutiveLeadTarget where Channel<>3 and CustomerID=(Select CustomerID From t_Showroom where WarehouseID=" + nWarehouseID + ")  " +
                   " and TargetType=" + (int)Dictionary.PlanVersionType.ExecutiveLeadTarget + "and TMonth=" + nTMonth + " and TYear=" + nTYear + " " +
                   " group by SalesPersonID,Channel " +
                   " Union All " +
                   // ---End Target---
                   // ----InitialLead---
                   " Select SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,count(LeadID) as InitialLeadQty, " +
                   " sum(LeadAmount) as InitialLead,0 as NewLeadQty,0 as NewLead, " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty, " +
                   " 0 as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt " +
                   " From t_SalesLeadManagement  " +
                   " where Customertype<>5 and month(ExpExecuteDate)=" + nTMonth + " and Year(ExpExecuteDate)=" + nTYear + " and WarehouseID=" + nWarehouseID + "   " +
                   " and  LeadDate<'" + dtFirstDateOfThisMonth + "' and LeadID not in  " +
                   " (Select LeadID From (Select WarehouseID,LeadID,LeadNo From  " +
                   " (Select WarehouseID,LeadID,LeadNo,CancelDate=Case when CancelDate is not null then CancelDate " +
                   " when CancelDate<>'' then CancelDate else UpdateDate end   " +
                   " From t_SalesLeadManagement where Customertype<>5 and LeadDate<'" + dtFirstDateOfThisMonth + "' " +
                   " and Status=4 ) a where CancelDate<'" + dtFirstDateOfThisMonth + "' " +
                   " Union All " +
                   " Select WarehouseID,LeadID,LeadNo " +
                   " From t_SalesLeadManagement where Customertype<>5 and LeadDate<'" + dtFirstDateOfThisMonth + "' and InvoiceDate<'" + dtFirstDateOfThisMonth + "' " +
                   " and Status=3 ) a) " +
                   " group by SalesPersonID,CustomerType " +
                   " Union All " +
                   // ---End InitialLead-----
                   // ---New Lead-----
                   " Select SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty,0 as InitialLead,count(LeadID) as NewLeadQty, " +
                   " sum(LeadAmount) as NewLead, 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty, " +
                   " 0 as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt " +
                   " From t_SalesLeadManagement  " +
                   " where Customertype<>5 and WarehouseID=" + nWarehouseID + " and month(ExpExecuteDate)=" + nTMonth + " and Year(ExpExecuteDate)=" + nTYear + " " +
                   " and Month(LeadDate)=" + nTMonth + " and Year(LeadDate)=" + nTYear + " group by SalesPersonID,CustomerType " +
                   " Union All " +
                   // ---End New Lead----- "+
                   // ----ShiftedLead---
                   " Select SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty, 0 as InitialLead,0 as NewLeadQty, 0 as NewLead, " +
                   " count(LeadID) as ShiftedLeadQty,sum(LeadAmount) as ShiftedLead,0 as CancelledLeadQty,0 as CancelledLeadAmt, " +
                   " 0 as ConverttoSalesQty,0 as ConverttoSalesAmt " +
                   " From t_SalesLeadManagement where Customertype<>5 and LeadNo in  " +
                   " (Select LeadNo From  " +
                   " (Select LeadNo,max(ExpExecuteDate) ExpExecuteDate From t_SalesLeadManagementHistory where LeadNo in ( " +
                   " Select LeadNo From t_SalesLeadManagement  " +
                   " where Customertype<>5 and month(ExpExecuteDate)=" + nTMonth + " and Year(ExpExecuteDate)=" + nTYear + " and  " +
                   " LeadID not in (Select LeadID From (Select WarehouseID,LeadID,LeadNo From  " +
                   " (Select WarehouseID,LeadID,LeadNo,CancelDate=Case when CancelDate is not null then CancelDate " +
                   " when CancelDate<>'' then CancelDate else UpdateDate end   " +
                   " From t_SalesLeadManagement where Customertype<>5 and LeadDate<'" + dtFirstDateOfThisMonth + "' " +
                   " and Status=4 ) a where CancelDate<'" + dtFirstDateOfThisMonth + "' " +
                   " Union All " +
                   " Select WarehouseID,LeadID,LeadNo " +
                   " From t_SalesLeadManagement where Customertype<>5 and LeadDate<'" + dtFirstDateOfThisMonth + "' and InvoiceDate<'" + dtFirstDateOfThisMonth + "' " +
                   " and Status=3 ) a))  " +
                   " group by LeadNo) Main where ExpExecuteDate > '" + dtLastDateOfThisMonth + "'   " +// --last day of selected month 
                   " )  and WarehouseID=" + nWarehouseID + " " +
                   " group by SalesPersonID,CustomerType " +
                   " Union All " +
                   // ----END ShiftedLead---
                   // ----Cancel----
                   " Select SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty,0 as InitialLead, 0 as NewLeadQty,0 as NewLead, " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,count(LeadID) as CancelledLeadQty, " +
                   " sum(LeadAmount) as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt   " +
                   " From t_SalesLeadManagement  " +
                   " where Customertype<>5 and WarehouseID=" + nWarehouseID + " and  " +
                   " month(ExpExecuteDate)=" + nTMonth + " and Year(ExpExecuteDate)=" + nTYear + " and Status=4 " +
                   " group by SalesPersonID,CustomerType " +
                   " Union All " +
                   // ----END Cancel----
                   // ---ConverttoSalesAmt---
                   " Select a.SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty,0 as InitialLead, 0 as NewLeadQty,0 as NewLead, " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty, " +
                   " 0 as CancelledLeadAmt,count(InvoiceID) as ConverttoSalesQty,sum(InvoiceAmount) as ConverttoSalesAmt  " +
                   " From t_SalesLeadManagement a,t_SalesInvoice b " +
                   " where a.Customertype<>5 and a.InvoiceNo=b.InvoiceNo and a.WarehouseID=b.WarehouseID and a.WarehouseID=" + nWarehouseID + " and  " +
                   " month(ExpExecuteDate)=" + nTMonth + "  and Year(ExpExecuteDate)=" + nTYear + " and Status=3 " +
                   " group by a.SalesPersonID,CustomerType " +
                   // ---END ConverttoSalesAmt----
                   " )  a group by SalesPersonID,Channel " +
                   " ) Main,t_Employee b where Main.SalesPersonID=b.EmployeeID) s where 1=1";

            if (nEmpID != -1)
            {
                sSql = sSql + " AND SalesPersonID=" + nEmpID + "";
            }
            //sSql = sSql + "  order by CustomerType";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLead _oSalesLead = new SalesLead();
                    _oSalesLead.SalesPersonID = Convert.ToInt32(reader["SalesPersonID"].ToString());
                    _oSalesLead.Channel = reader["Channel"].ToString();
                    _oSalesLead.EmployeeCode = reader["EmployeeCode"].ToString();
                    _oSalesLead.Employeename = reader["Employeename"].ToString();
                    _oSalesLead.LeadTarget = Convert.ToDouble(reader["LeadTarget"].ToString());


                    _oSalesLead.InitialLeadQty = Convert.ToInt32(reader["InitialLeadQty"].ToString());
                    _oSalesLead.InitialLead = Convert.ToDouble(reader["InitialLead"].ToString());

                    _oSalesLead.NewLeadQty = Convert.ToInt32(reader["NewLeadQty"].ToString());
                    _oSalesLead.NewLead = Convert.ToDouble(reader["NewLead"].ToString());

                    _oSalesLead.ShiftedLeadQty = Convert.ToInt32(reader["ShiftedLeadQty"].ToString());
                    _oSalesLead.ShiftedLead = Convert.ToDouble(reader["ShiftedLead"].ToString());

                    _oSalesLead.CancelledLeadQty = Convert.ToInt32(reader["CancelledLeadQty"].ToString());
                    _oSalesLead.CancelledLeadAmt = Convert.ToDouble(reader["CancelledLeadAmt"].ToString());

                    _oSalesLead.ConverttoSalesQty = Convert.ToInt32(reader["ConverttoSalesQty"].ToString());
                    _oSalesLead.ConverttoSalesAmt = Convert.ToDouble(reader["ConverttoSalesAmt"].ToString());

                    _oSalesLead.TotalLeadQty = Convert.ToInt32(reader["TotalLeadQty"].ToString());
                    _oSalesLead.TotalLeadAmt = Convert.ToDouble(reader["TotalLeadAmt"].ToString());

                    _oSalesLead.ShortFall = Convert.ToDouble(reader["ShortFall"].ToString());

                    _oSalesLead.Achievment = Convert.ToDouble(reader["Achievment"].ToString());
                    InnerList.Add(_oSalesLead);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void LeadTgtVsAchExecutiveWiseRT(int nWarehouseID, DateTime dtFirstDateOfThisMonth, DateTime dtLastDateOfThisMonth, int nTYear, int nTMonth, int nEmpID)//Shuvo
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select s.*,isnull(nullif(ConverttoSalesAmt,0)/nullif(TotalLeadAmt,0)*100,0) as Achievment From (Select Main.*,((InitialLeadQty+NewLeadQty)- (ShiftedLeadQty+CancelledLeadQty)) as TotalLeadQty, " +
                   "((InitialLead+NewLead)- (ShiftedLead+CancelledLeadAmt)) as TotalLeadAmt, " +
                   " LeadTarget-((InitialLead+NewLead)- (ShiftedLead+CancelledLeadAmt)) as ShortFall,EmployeeCode,EmployeeName  " +
                   //" isnull(nullif(ConverttoSalesAmt,0)/(nullif(InitialLead,0)+nullif(NewLead,0))*100,0) as Achievment " +
                   " From  " +
                   " ( " +
                   " Select SalesPersonID,Channel, " +
                   " sum(isnull(LeadTarget,0)) as LeadTarget, " +
                   " sum(isnull(InitialLeadQty,0)) as InitialLeadQty,sum(isnull(InitialLead,0)) as InitialLead, " +
                   " sum(isnull(NewLeadQty,0)) as NewLeadQty,sum(isnull(NewLead,0)) as NewLead, " +
                   " sum(isnull(ShiftedLeadQty,0)) as ShiftedLeadQty,sum(isnull(ShiftedLead,0)) as ShiftedLead, " +
                   " sum(isnull(CancelledLeadQty,0)) as CancelledLeadQty,sum(isnull(CancelledLeadAmt,0)) as CancelledLeadAmt, " +
                   " sum(isnull(ConverttoSalesQty,0)) as ConverttoSalesQty,sum(isnull(ConverttoSalesAmt,0)) as ConverttoSalesAmt   " +
                   " From  " +
                   " (  " + //--Target---
                   " Select SalesPersonID,Channel=Case when Channel=3 then 'Dealer' " +
                   " when Channel=4 then 'Retail' " +
                   " when Channel=13 then 'B2B' " +
                   " when Channel=16 then 'e-Store' " +
                   " else 'Other' end,sum(TargetAmount) as LeadTarget,0 as InitialLeadQty,0 as InitialLead, 0 as NewLeadQty,0 as NewLead, " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty,0 as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt " +
                   " From t_PLanExecutiveLeadTarget where CustomerID=(Select CustomerID From t_Showroom where WarehouseID=" + nWarehouseID + ")  " +
                   " and TargetType=" + (int)Dictionary.PlanVersionType.ExecutiveLeadTarget + "and TMonth=" + nTMonth + " and TYear=" + nTYear + " " +
                   " group by SalesPersonID,Channel " +
                   " Union All " +
                   // ---End Target---
                   // ----InitialLead---
                   " Select SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,count(LeadID) as InitialLeadQty, " +
                   " sum(LeadAmount) as InitialLead,0 as NewLeadQty,0 as NewLead, " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty, " +
                   " 0 as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt " +
                   " From t_SalesLeadManagement  " +
                   " where month(ExpExecuteDate)=" + nTMonth + " and Year(ExpExecuteDate)=" + nTYear + " and WarehouseID=" + nWarehouseID + "   " +
                   " and  LeadDate<'" + dtFirstDateOfThisMonth + "' and LeadID not in  " +
                   " (Select LeadID From (Select WarehouseID,LeadID,LeadNo From  " +
                   " (Select WarehouseID,LeadID,LeadNo,CancelDate=Case when CancelDate is not null then CancelDate " +
                   " when CancelDate<>'' then CancelDate else UpdateDate end   " +
                   " From t_SalesLeadManagement where LeadDate<'" + dtFirstDateOfThisMonth + "' " +
                   " and Status=4 ) a where CancelDate<'" + dtFirstDateOfThisMonth + "' " +
                   " Union All " +
                   " Select WarehouseID,LeadID,LeadNo " +
                   " From t_SalesLeadManagement where LeadDate<'" + dtFirstDateOfThisMonth + "' and InvoiceDate<'" + dtFirstDateOfThisMonth + "' " +
                   " and Status=3 ) a) " +
                   " group by SalesPersonID,CustomerType " +
                   " Union All " +
                   // ---End InitialLead-----
                   // ---New Lead-----
                   " Select SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty,0 as InitialLead,count(LeadID) as NewLeadQty, " +
                   " sum(LeadAmount) as NewLead, 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty, " +
                   " 0 as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt " +
                   " From t_SalesLeadManagement  " +
                   " where WarehouseID=" + nWarehouseID + " and month(ExpExecuteDate)=" + nTMonth + " and Year(ExpExecuteDate)=" + nTYear + " " +
                   " and Month(LeadDate)=" + nTMonth + " and Year(LeadDate)=" + nTYear + " group by SalesPersonID,CustomerType " +
                   " Union All " +
                   // ---End New Lead----- "+
                   // ----ShiftedLead---
                   " Select SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty, 0 as InitialLead,0 as NewLeadQty, 0 as NewLead, " +
                   " count(LeadID) as ShiftedLeadQty,sum(LeadAmount) as ShiftedLead,0 as CancelledLeadQty,0 as CancelledLeadAmt, " +
                   " 0 as ConverttoSalesQty,0 as ConverttoSalesAmt " +
                   " From t_SalesLeadManagement where LeadNo in  " +
                   " (Select LeadNo From  " +
                   " (Select LeadNo,max(ExpExecuteDate) ExpExecuteDate From t_SalesLeadManagementHistory where LeadNo in ( " +
                   " Select LeadNo From t_SalesLeadManagement  " +
                   " where month(ExpExecuteDate)=" + nTMonth + " and Year(ExpExecuteDate)=" + nTYear + " and  " +
                   " LeadID not in (Select LeadID From (Select WarehouseID,LeadID,LeadNo From  " +
                   " (Select WarehouseID,LeadID,LeadNo,CancelDate=Case when CancelDate is not null then CancelDate " +
                   " when CancelDate<>'' then CancelDate else UpdateDate end   " +
                   " From t_SalesLeadManagement where LeadDate<'" + dtFirstDateOfThisMonth + "' " +
                   " and Status=4 ) a where CancelDate<'" + dtFirstDateOfThisMonth + "' " +
                   " Union All " +
                   " Select WarehouseID,LeadID,LeadNo " +
                   " From t_SalesLeadManagement where LeadDate<'" + dtFirstDateOfThisMonth + "' and InvoiceDate<'" + dtFirstDateOfThisMonth + "' " +
                   " and Status=3 ) a))  " +
                   " group by LeadNo) Main where ExpExecuteDate > '" + dtLastDateOfThisMonth + "'   " +// --last day of selected month 
                   " )  and WarehouseID=" + nWarehouseID + " " +
                   " group by SalesPersonID,CustomerType " +
                   " Union All " +
                   // ----END ShiftedLead---
                   // ----Cancel----
                   " Select SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty,0 as InitialLead, 0 as NewLeadQty,0 as NewLead, " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,count(LeadID) as CancelledLeadQty, " +
                   " sum(LeadAmount) as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt   " +
                   " From t_SalesLeadManagement  " +
                   " where WarehouseID=" + nWarehouseID + " and  " +
                   " month(ExpExecuteDate)=" + nTMonth + " and Year(ExpExecuteDate)=" + nTYear + " and Status=4 " +
                   " group by SalesPersonID,CustomerType " +
                   " Union All " +
                   // ----END Cancel----
                   // ---ConverttoSalesAmt---
                   " Select a.SalesPersonID, " +
                   " Channel=Case when CustomerType=1 then 'Retail' " +
                   " when CustomerType=3 then 'B2B' " +
                   " when CustomerType=5 then 'Dealer' " +
                   " when CustomerType=6 then 'e-Store' " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty,0 as InitialLead, 0 as NewLeadQty,0 as NewLead, " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty, " +
                   " 0 as CancelledLeadAmt,count(InvoiceID) as ConverttoSalesQty,sum(InvoiceAmount) as ConverttoSalesAmt  " +
                   " From t_SalesLeadManagement a,t_SalesInvoice b " +
                   " where a.InvoiceNo=b.InvoiceNo and a.WarehouseID=b.WarehouseID and a.WarehouseID=" + nWarehouseID + " and  " +
                   " month(ExpExecuteDate)=" + nTMonth + "  and Year(ExpExecuteDate)=" + nTYear + " and Status=3 " +
                   " group by a.SalesPersonID,CustomerType " +
                   // ---END ConverttoSalesAmt----
                   " )  a group by SalesPersonID,Channel " +
                   " ) Main,t_Employee b where Main.SalesPersonID=b.EmployeeID) s where 1=1";

            if (nEmpID != -1)
            {
                sSql = sSql + " AND SalesPersonID=" + nEmpID + "";
            }
            //sSql = sSql + "  order by CustomerType";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLead _oSalesLead = new SalesLead();
                    _oSalesLead.SalesPersonID = Convert.ToInt32(reader["SalesPersonID"].ToString());
                    _oSalesLead.Channel = reader["Channel"].ToString();
                    _oSalesLead.EmployeeCode = reader["EmployeeCode"].ToString();
                    _oSalesLead.Employeename = reader["Employeename"].ToString();
                    _oSalesLead.LeadTarget = Convert.ToDouble(reader["LeadTarget"].ToString());


                    _oSalesLead.InitialLeadQty = Convert.ToInt32(reader["InitialLeadQty"].ToString());
                    _oSalesLead.InitialLead = Convert.ToDouble(reader["InitialLead"].ToString());

                    _oSalesLead.NewLeadQty = Convert.ToInt32(reader["NewLeadQty"].ToString());
                    _oSalesLead.NewLead = Convert.ToDouble(reader["NewLead"].ToString());

                    _oSalesLead.ShiftedLeadQty = Convert.ToInt32(reader["ShiftedLeadQty"].ToString());
                    _oSalesLead.ShiftedLead = Convert.ToDouble(reader["ShiftedLead"].ToString());

                    _oSalesLead.CancelledLeadQty = Convert.ToInt32(reader["CancelledLeadQty"].ToString());
                    _oSalesLead.CancelledLeadAmt = Convert.ToDouble(reader["CancelledLeadAmt"].ToString());

                    _oSalesLead.ConverttoSalesQty = Convert.ToInt32(reader["ConverttoSalesQty"].ToString());
                    _oSalesLead.ConverttoSalesAmt = Convert.ToDouble(reader["ConverttoSalesAmt"].ToString());

                    _oSalesLead.TotalLeadQty = Convert.ToInt32(reader["TotalLeadQty"].ToString());
                    _oSalesLead.TotalLeadAmt = Convert.ToDouble(reader["TotalLeadAmt"].ToString());

                    _oSalesLead.ShortFall = Convert.ToDouble(reader["ShortFall"].ToString());

                    _oSalesLead.Achievment = Convert.ToDouble(reader["Achievment"].ToString());
                    InnerList.Add(_oSalesLead);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetActivation()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_TDActivation where IsActive=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLead oSalesLead = new SalesLead();
                    oSalesLead.ActivationID = (int)reader["ActivationID"];
                    oSalesLead.ActivationName = (string)reader["ActivationName"];
                    oSalesLead.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    oSalesLead.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    oSalesLead.IsActive = (int)reader["IsActive"];
                    oSalesLead.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesLead.CreateUserID = (int)reader["CreateUserID"];
                    InnerList.Add(oSalesLead);
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


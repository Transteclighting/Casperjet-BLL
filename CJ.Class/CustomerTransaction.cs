// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: June 20, 2011
// Time : 12.00 PM
// Description: Class for Customer Transaction.
// Modify Person And Date: Hakim
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
    public class CustomerTransaction : CollectionBase
    {
        private int _EntryLocationID;
        public int EntryLocationID
        {
            get { return _EntryLocationID; }
            set { _EntryLocationID = value; }
        }
        private int _TranID;
        private string _TranNo;
        private int _CustomerID;
        private long _InvoiceID;
        private DateTime _TranDate;
        private int _TranTypeID;
        private double _Amount;
        private string _InstrumentNo;
        private object _InstrumentDate;
        private int _InstrumentType;
        private int _InstrumentStatus;
        private int _BranchID;
        private string _BranchName;
        private int _EntryUserID;
        private DateTime _EntryDate;
        private int _UpdateUserID;
        private DateTime _UpdateDate;
        private string _Remarks;
        private double _UnAdjustedAmount;
        private string _UploadStatus;
        private DateTime _UploadDate;
        private DateTime _DownloadDate;
        private int _RowStatus;
        private int _Terminal;
        private string _Copy;
        private int _EmployeeID;
        private int _UserID;
        private Employee _oEmployee;
        private Branch _oBranch;
        private string _CustomerName;
        private string _ParentCustomerName;
        private string _TranTypeGroupName;
        private string _TranTypeName;
        private CustomerTranType _oTranType;
        private int _TranTypeGroupID;

        public int TranTypeGroupID
        {
            get { return _TranTypeGroupID; }
            set { _TranTypeGroupID = value; }
        }
        public string ParentCustomerName
        {
            get { return _ParentCustomerName; }
            set { _ParentCustomerName = value; }
        }
        public string TranTypeGroupName
        {
            get { return _TranTypeGroupName; }
            set { _TranTypeGroupName = value; }
        }
        public string TranTypeName
        {
            get { return _TranTypeName; }
            set { _TranTypeName = value; }
        }
        public CustomerTranType CustomerTranType
        {
            get
            {
                if (_oTranType == null)
                {
                    _oTranType = new CustomerTranType();
                    _oTranType.TranTypeID = (int)_TranTypeID;
                    _oTranType.Refresh();
                }

                return _oTranType;
            }
        }
        public Employee Employee
        {
            get
            {
                if (_oEmployee == null)
                {
                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = (int)_EmployeeID;
                    _oEmployee.Refresh();
                }

                return _oEmployee;
            }
        }
        public Branch Branch
        {
            get
            {
                if (_oBranch == null)
                {
                    _oBranch = new Branch();
                    _oBranch.BranchID = _BranchID;
                    _oBranch.Refresh();
                }
                return _oBranch;
            }
        }
        private Warehouse _oWarehouse;
        public Warehouse Warehouse
        {
            get
            {
                if (_oWarehouse == null)
                {
                    _oWarehouse = new Warehouse();

                }
                return _oWarehouse;
            }
        }
        private double _ReceiveAmount;
        public double ReceiveAmount
        {
            get { return _ReceiveAmount; }
            set { _ReceiveAmount = value; }
        }

        private double _BalanceAmount;
        public double BalanceAmount
        {
            get { return _BalanceAmount; }
            set { _BalanceAmount = value; }
        }

        /// <summary>
        /// Get set property for TranID
        /// </summary>
        public string Copy
        {
            get { return _Copy; }
            set { _Copy = value; }
        }
        public int TranID
        {
            get { return _TranID; }
            set { _TranID = value; }
        }
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        /// <summary>
        /// Get set property for TranNo
        /// </summary>
        public string TranNo
        {
            get { return _TranNo; }
            set { _TranNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for CustomerID
        /// </summary>
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public long InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }
        /// <summary>
        /// Get set property for TranDate
        /// </summary>
        public DateTime TranDate
        {
            get { return _TranDate; }
            set { _TranDate = value; }
        }
        /// <summary>
        /// Get set property for TranTypeID
        /// </summary>
        public int TranTypeID
        {
            get { return _TranTypeID; }
            set { _TranTypeID = value; }
        }
        private int _TranSide;
        public int TranSide
        {
            get { return _TranSide; }
            set { _TranSide = value; }
        }
        /// <summary>
        /// Get set property for Amount
        /// </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        /// <summary>
        /// Get set property for InstrumentNo
        /// </summary>
        public string InstrumentNo
        {
            get { return _InstrumentNo; }
            set { _InstrumentNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for InstrumentDate
        /// </summary>
        public object InstrumentDate
        {
            get { return _InstrumentDate; }
            set { _InstrumentDate = value; }
        }
        /// <summary>
        /// Get set property for InstrumentType
        /// </summary>
        public int InstrumentType
        {
            get { return _InstrumentType; }
            set { _InstrumentType = value; }
        }
        /// <summary>
        /// Get set property for InstrumentStatus
        /// </summary>
        public int InstrumentStatus
        {
            get { return _InstrumentStatus; }
            set { _InstrumentStatus = value; }
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
        /// Get set property for BranchName
        /// </summary>
        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for EntryUserID
        /// </summary>
        public int EntryUserID
        {
            get { return _EntryUserID; }
            set { _EntryUserID = value; }
        }
        /// <summary>
        /// Get set property for EntryDate
        /// </summary>
        public DateTime EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }
        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _UpdateUserID; }
            set { _UpdateUserID = value; }
        }
        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _UpdateDate; }
            set { _UpdateDate = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value.Trim(); }
        }
        /// <summary>
        /// Get set property for UnAdjustedAmount
        /// </summary>           
        public double UnAdjustedAmount
        {
            get { return _UnAdjustedAmount; }
            set { _UnAdjustedAmount = value; }
        }
        /// <summary>
        /// Get set property for UploadStatus
        /// </summary>
        public string UploadStatus
        {
            get { return _UploadStatus; }
            set { _UploadStatus = value.Trim(); }
        }
        /// <summary>
        /// Get set property for UploadDate
        /// </summary>
        public DateTime UploadDate
        {
            get { return _UploadDate; }
            set { _UploadDate = value; }
        }
        /// <summary>
        /// Get set property for DownloadDate
        /// </summary>
        public DateTime DownloadDate
        {
            get { return _DownloadDate; }
            set { _DownloadDate = value; }
        }
        /// <summary>
        /// Get set property for RowStatus
        /// </summary>
        public int RowStatus
        {
            get { return _RowStatus; }
            set { _RowStatus = value; }
        }
        /// <summary>
        /// Get set property for Terminal
        /// </summary>
        public int Terminal
        {
            get { return _Terminal; }
            set { _Terminal = value; }
        }
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }


        private string _sCustomerCode;
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        private string _sCustomerName;
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        private string _sInstrumentTypeName;
        public string InstrumentTypeName
        {
            get { return _sInstrumentTypeName; }
            set { _sInstrumentTypeName = value; }
        }
        private string _sBankName;
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value; }
        }

        SystemInfo _oSystemInfo;



        private InvoiceWisePayments oInvoiceWisePayments;
        public InvoiceWisePayments InvoiceWisePayments
        {
            get
            {
                if (oInvoiceWisePayments == null)
                {
                    oInvoiceWisePayments = new InvoiceWisePayments();
                }
                return oInvoiceWisePayments;
            }
        }

        public InvoiceWisePayment this[int i]
        {
            get { return (InvoiceWisePayment)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(InvoiceWisePayment oInvoiceWisePayment)
        {
            InnerList.Add(oInvoiceWisePayment);
        }

        public void InsertForPOS(int nWarehoseID, DateTime dOperationDate)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT NextMoneyReceiptNo FROM t_NextDocumentNo";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = nWarehoseID;
                _oWarehouse.POSReresh();
                _TranNo = "CT-" + _oWarehouse.Shortcode + "-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                    "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName, " +
                    "EntryUserID,EntryDate,UpdateUserID,UpdateDate,Remarks,UnAdjustedAmount,UploadStatus, " +
                    "UploadDate,DownloadDate,RowStatus,Terminal) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                }
                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);

                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", dOperationDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UnAdjustedAmount", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = " Update t_NextDocumentNo SET NextMoneyReceiptNo = ?";
                cmd.Parameters.AddWithValue("NextMoneyReceiptNo", nNextMoneyReceiptNo + 1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                cmd.CommandText = sSql;
                object maxRecordID = cmd.ExecuteScalar();
                if (maxRecordID == DBNull.Value)
                {
                    nRecordID = 1;
                }
                else
                {
                    nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_InvoiceWisePayment (RecordID,CustomerTranID,InvoiceID,CustomerID, " +
                "Amount,CreateDate,CreateUserID) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RecordID", nRecordID);
                cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateDate", dOperationDate);
                cmd.Parameters.AddWithValue("CreateUserID", _UserID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_CustomerAccount set CurrentBalance = CurrentBalance + ? where CustomerID = ?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForPOSRT(int nWarehoseID, DateTime dOperationDate)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT NextMoneyReceiptNo FROM t_NextDocumentNo";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = nWarehoseID;
                _oWarehouse.POSReresh();
                _TranNo = "CT-" + _oWarehouse.Shortcode + "-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                    "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName, " +
                    "EntryUserID,EntryDate,UpdateUserID,UpdateDate,Remarks,UnAdjustedAmount,UploadStatus, " +
                    "UploadDate,DownloadDate,RowStatus,Terminal,EntryLocationID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                }
                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);

                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", dOperationDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UnAdjustedAmount", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("EntryLocationID", _EntryLocationID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = " Update t_NextDocumentNo SET NextMoneyReceiptNo = ?";
                cmd.Parameters.AddWithValue("NextMoneyReceiptNo", nNextMoneyReceiptNo + 1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                cmd.CommandText = sSql;
                object maxRecordID = cmd.ExecuteScalar();
                if (maxRecordID == DBNull.Value)
                {
                    nRecordID = 1;
                }
                else
                {
                    nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_InvoiceWisePayment (RecordID,CustomerTranID,InvoiceID,CustomerID, " +
                "Amount,CreateDate,CreateUserID) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RecordID", nRecordID);
                cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateDate", dOperationDate);
                cmd.Parameters.AddWithValue("CreateUserID", _UserID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_CustomerAccount set CurrentBalance = CurrentBalance + ? where CustomerID = ?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForPOSNew(int nWarehoseID, DateTime dOperationDate, double _BGAmount)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT NextMoneyReceiptNo FROM t_NextDocumentNo";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = nWarehoseID;
                _oWarehouse.POSReresh();
                _TranNo = "CT-" + _oWarehouse.Shortcode + "-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                    "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName, " +
                    "EntryUserID,EntryDate,UpdateUserID,UpdateDate,Remarks,UnAdjustedAmount,UploadStatus, " +
                    "UploadDate,DownloadDate,RowStatus,Terminal) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                }
                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);

                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", dOperationDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UnAdjustedAmount", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = " Update t_NextDocumentNo SET NextMoneyReceiptNo = ?";
                cmd.Parameters.AddWithValue("NextMoneyReceiptNo", nNextMoneyReceiptNo + 1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                cmd.CommandText = sSql;
                object maxRecordID = cmd.ExecuteScalar();
                if (maxRecordID == DBNull.Value)
                {
                    nRecordID = 1;
                }
                else
                {
                    nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_InvoiceWisePayment (RecordID,CustomerTranID,InvoiceID,CustomerID, " +
                "Amount,CreateDate,CreateUserID) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RecordID", nRecordID);
                cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateDate", dOperationDate);
                cmd.Parameters.AddWithValue("CreateUserID", _UserID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (_BGAmount > 0)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance = CurrentBalance - ? where CustomerID = ?";
                    cmd.Parameters.AddWithValue("CurrentBalance", _BGAmount);
                    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_SalesInvoice set DueAmount = ? where InvoiceNo = ?";
                    cmd.Parameters.AddWithValue("DueAmount", _BGAmount);
                    cmd.Parameters.AddWithValue("InvoiceNo", _InstrumentNo);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForPOSRT(int nWarehoseID, DateTime dOperationDate, double _BGAmount)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT NextMoneyReceiptNo FROM t_Showroom where WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
                _TranNo = "CT-" + Utility.Shortcode + "-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                    "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName, " +
                    "EntryUserID,EntryDate,UpdateUserID,UpdateDate,Remarks,UnAdjustedAmount,UploadStatus, " +
                    "UploadDate,DownloadDate,RowStatus,Terminal,EntryLocationID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                }
                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);

                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", dOperationDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UnAdjustedAmount", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("EntryLocationID", Utility.LocationID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = " Update t_Showroom SET NextMoneyReceiptNo = ? where WarehouseID=" + Utility.WarehouseID + "";
                cmd.Parameters.AddWithValue("NextMoneyReceiptNo", nNextMoneyReceiptNo + 1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                cmd.CommandText = sSql;
                object maxRecordID = cmd.ExecuteScalar();
                if (maxRecordID == DBNull.Value)
                {
                    nRecordID = 1;
                }
                else
                {
                    nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_InvoiceWisePayment (RecordID,CustomerTranID,InvoiceID,CustomerID, " +
                "Amount,CreateDate,CreateUserID) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RecordID", nRecordID);
                cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateDate", dOperationDate);
                cmd.Parameters.AddWithValue("CreateUserID", _UserID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (_BGAmount > 0)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance = CurrentBalance - ? where CustomerID = ?";
                    cmd.Parameters.AddWithValue("CurrentBalance", _BGAmount);
                    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_SalesInvoice set DueAmount = ? where InvoiceNo = ?";
                    cmd.Parameters.AddWithValue("DueAmount", _BGAmount);
                    cmd.Parameters.AddWithValue("InvoiceNo", _InstrumentNo);
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForPOSCollection(int nWarehoseID, DateTime dOperationDate)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT NextMoneyReceiptNo FROM t_NextDocumentNo";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = nWarehoseID;
                _oWarehouse.POSReresh();
                _TranNo = "CT-" + _oWarehouse.Shortcode + "-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                    "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName, " +
                    "EntryUserID,EntryDate,UpdateUserID,UpdateDate,Remarks,UnAdjustedAmount,UploadStatus, " +
                    "UploadDate,DownloadDate,RowStatus,Terminal) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", dOperationDate.Date);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                }
                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);

                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("EntryDate", dOperationDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UnAdjustedAmount", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = " Update t_NextDocumentNo SET NextMoneyReceiptNo = ?";
                cmd.Parameters.AddWithValue("NextMoneyReceiptNo", nNextMoneyReceiptNo + 1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (InvoiceWisePayment oInvoiceWisePayment in this)
                {

                    cmd = DBController.Instance.GetCommand();
                    sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                    cmd.CommandText = sSql;
                    object maxRecordID = cmd.ExecuteScalar();
                    if (maxRecordID == DBNull.Value)
                    {
                        nRecordID = 1;
                    }
                    else
                    {
                        nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                    }

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("RecordID", nRecordID);
                    cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                    cmd.Parameters.AddWithValue("InvoiceID", oInvoiceWisePayment.InvoiceID);
                    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                    cmd.Parameters.AddWithValue("Amount", oInvoiceWisePayment.Amount);
                    cmd.Parameters.AddWithValue("CreateDate", dOperationDate);
                    cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "UPDATE t_SalesInvoice " +
                                      "SET  DueAmount = DueAmount - ?, UpdateUserID = ?, UpdateDate = ?, RowStatus = ?, UploadStatus = ?, UploadDate = ?, DownloadDate = ? " +
                                      " WHERE InvoiceID = ? ";

                    cmd.CommandType = CommandType.Text;


                    cmd.Parameters.AddWithValue("DueAmount", oInvoiceWisePayment.Amount);
                    cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("UpdateDate", dOperationDate);
                    cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.UPDATE);
                    cmd.Parameters.AddWithValue("UploadStatus", null);
                    cmd.Parameters.AddWithValue("UploadDate", null);
                    cmd.Parameters.AddWithValue("DownloadDate", null);
                    cmd.Parameters.AddWithValue("InvoiceID", oInvoiceWisePayment.InvoiceID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();


                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_CustomerTran";
                oDataTran.DataID = _TranID;
                oDataTran.WarehouseID = nWarehoseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;

                oDataTran.Add();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForHOCollection(int nWarehoseID, DateTime dOperationDate)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT NextMoneyReceiptNo FROM t_NextDocumentNo";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
                _oWarehouse = new Warehouse();
                _oWarehouse.WarehouseID = nWarehoseID;
                _oWarehouse.POSReresh();
                _TranNo = "CT-" + _oWarehouse.Shortcode + "-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                    "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName, " +
                    "EntryUserID,EntryDate,UpdateUserID,UpdateDate,Remarks,UnAdjustedAmount,UploadStatus, " +
                    "UploadDate,DownloadDate,RowStatus,Terminal,EntryLocationID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", dOperationDate.Date);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                }
                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);

                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("EntryDate", dOperationDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UnAdjustedAmount", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("EntryLocationID", _EntryLocationID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = " Update t_NextDocumentNo SET NextMoneyReceiptNo = ?";
                cmd.Parameters.AddWithValue("NextMoneyReceiptNo", nNextMoneyReceiptNo + 1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (InvoiceWisePayment oInvoiceWisePayment in this)
                {

                    cmd = DBController.Instance.GetCommand();
                    sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                    cmd.CommandText = sSql;
                    object maxRecordID = cmd.ExecuteScalar();
                    if (maxRecordID == DBNull.Value)
                    {
                        nRecordID = 1;
                    }
                    else
                    {
                        nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                    }

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("RecordID", nRecordID);
                    cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                    cmd.Parameters.AddWithValue("InvoiceID", oInvoiceWisePayment.InvoiceID);
                    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                    cmd.Parameters.AddWithValue("Amount", oInvoiceWisePayment.Amount);
                    cmd.Parameters.AddWithValue("CreateDate", dOperationDate);
                    cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "UPDATE t_SalesInvoice " +
                                      "SET  DueAmount = DueAmount - ?, UpdateUserID = ?, UpdateDate = ?, RowStatus = ?, UploadStatus = ?, UploadDate = ?, DownloadDate = ? " +
                                      " WHERE InvoiceID = ? ";

                    cmd.CommandType = CommandType.Text;


                    cmd.Parameters.AddWithValue("DueAmount", oInvoiceWisePayment.Amount);
                    cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("UpdateDate", dOperationDate);
                    cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.UPDATE);
                    cmd.Parameters.AddWithValue("UploadStatus", null);
                    cmd.Parameters.AddWithValue("UploadDate", null);
                    cmd.Parameters.AddWithValue("DownloadDate", null);
                    cmd.Parameters.AddWithValue("InvoiceID", oInvoiceWisePayment.InvoiceID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();


                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_CustomerTran";
                oDataTran.DataID = _TranID;
                oDataTran.WarehouseID = nWarehoseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;

                oDataTran.Add();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForPOSCollectionRT(int nWarehoseID, DateTime dOperationDate)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT NextMoneyReceiptNo FROM t_Showroom where WarehouseID=" + nWarehoseID + "";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
     
                _TranNo = "CT-" + Utility.Shortcode + "-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                    "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName, " +
                    "EntryUserID,EntryDate,UpdateUserID,UpdateDate,Remarks,UnAdjustedAmount,UploadStatus, " +
                    "UploadDate,DownloadDate,RowStatus,Terminal,EntryLocationID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", dOperationDate.Date);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                }
                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);

                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("EntryDate", dOperationDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UnAdjustedAmount", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("EntryLocationID", Utility.LocationID);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = " Update t_Showroom SET NextMoneyReceiptNo = ? where WarehouseID=" + nWarehoseID + "";
                cmd.Parameters.AddWithValue("NextMoneyReceiptNo", nNextMoneyReceiptNo + 1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (InvoiceWisePayment oInvoiceWisePayment in this)
                {

                    cmd = DBController.Instance.GetCommand();
                    sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                    cmd.CommandText = sSql;
                    object maxRecordID = cmd.ExecuteScalar();
                    if (maxRecordID == DBNull.Value)
                    {
                        nRecordID = 1;
                    }
                    else
                    {
                        nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                    }

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("RecordID", nRecordID);
                    cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                    cmd.Parameters.AddWithValue("InvoiceID", oInvoiceWisePayment.InvoiceID);
                    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                    cmd.Parameters.AddWithValue("Amount", oInvoiceWisePayment.Amount);
                    cmd.Parameters.AddWithValue("CreateDate", dOperationDate);
                    cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "UPDATE t_SalesInvoice " +
                                      "SET  DueAmount = DueAmount - ?, UpdateUserID = ?, UpdateDate = ?, RowStatus = ?, UploadStatus = ?, UploadDate = ?, DownloadDate = ? " +
                                      " WHERE InvoiceID = ? ";

                    cmd.CommandType = CommandType.Text;


                    cmd.Parameters.AddWithValue("DueAmount", oInvoiceWisePayment.Amount);
                    cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("UpdateDate", dOperationDate);
                    cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.UPDATE);
                    cmd.Parameters.AddWithValue("UploadStatus", null);
                    cmd.Parameters.AddWithValue("UploadDate", null);
                    cmd.Parameters.AddWithValue("DownloadDate", null);
                    cmd.Parameters.AddWithValue("InvoiceID", oInvoiceWisePayment.InvoiceID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertForHOCollection(int nWarehoseID, int nCustomerTranGroup, bool _bTranSide)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT NextMoneyReceiptNo FROM t_NextMoneyReceiptNo";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
                _TranNo = "CT-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                    "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName, " +
                    "EntryUserID,EntryDate,UpdateUserID,UpdateDate,Remarks,UnAdjustedAmount,UploadStatus, " +
                    "UploadDate,DownloadDate,RowStatus,Terminal,EntryLocationID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (nCustomerTranGroup == (int)Dictionary.CustomerTranGroup.Collection)
                {
                    if (_InstrumentType == 2)
                    {
                        cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                        cmd.Parameters.AddWithValue("InstrumentDate", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                        cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                    }
                    cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                    cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);

                    if (_InstrumentType == 2)
                    {
                        cmd.Parameters.AddWithValue("BranchID", null);
                        cmd.Parameters.AddWithValue("BranchName", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("BranchID", _BranchID);
                        cmd.Parameters.AddWithValue("BranchName", _BranchName);
                    }
                }
                else
                {

                    cmd.Parameters.AddWithValue("InstrumentNo", null);
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                    cmd.Parameters.AddWithValue("InstrumentType", null);
                    cmd.Parameters.AddWithValue("InstrumentStatus", null);
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }

                cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UnAdjustedAmount", _UnAdjustedAmount);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", (int)Dictionary.Terminal.Head_Office);
                cmd.Parameters.AddWithValue("EntryLocationID", (int)Dictionary.JobLocation.HO);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = " Update t_NextMoneyReceiptNo SET NextMoneyReceiptNo = ?";
                cmd.Parameters.AddWithValue("NextMoneyReceiptNo", nNextMoneyReceiptNo + 1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                foreach (InvoiceWisePayment oInvoiceWisePayment in this)
                {

                    cmd = DBController.Instance.GetCommand();
                    sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                    cmd.CommandText = sSql;
                    object maxRecordID = cmd.ExecuteScalar();
                    if (maxRecordID == DBNull.Value)
                    {
                        nRecordID = 1;
                    }
                    else
                    {
                        nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                    }

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("RecordID", nRecordID);
                    cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                    cmd.Parameters.AddWithValue("InvoiceID", oInvoiceWisePayment.InvoiceID);
                    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                    cmd.Parameters.AddWithValue("Amount", oInvoiceWisePayment.Amount);
                    cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "UPDATE t_SalesInvoice " +
                                      "SET  DueAmount = DueAmount - ?, UpdateUserID = ?, UpdateDate = ?, RowStatus = ?, UploadStatus = ?, UploadDate = ?, DownloadDate = ? " +
                                      " WHERE InvoiceID = ? ";

                    cmd.CommandType = CommandType.Text;


                    cmd.Parameters.AddWithValue("DueAmount", oInvoiceWisePayment.Amount);
                    cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.UPDATE);
                    cmd.Parameters.AddWithValue("UploadStatus", null);
                    cmd.Parameters.AddWithValue("UploadDate", null);
                    cmd.Parameters.AddWithValue("DownloadDate", null);
                    cmd.Parameters.AddWithValue("InvoiceID", oInvoiceWisePayment.InvoiceID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                cmd = DBController.Instance.GetCommand();
                if (_bTranSide)
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                else cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance-? where CustomerID=?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                if (nWarehoseID != 0)
                {
                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_CustomerTran";
                    oDataTran.DataID = _TranID;
                    oDataTran.WarehouseID = nWarehoseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.Add();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CancelCustomerTransaction()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " Update t_CustomerTran SET UploadStatus = ?, RowStatus=? where TranNo=?";
                cmd.Parameters.AddWithValue("UploadStatus", _UploadStatus);
                cmd.Parameters.AddWithValue("RowStatus", _RowStatus);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ApproveCustomerTransaction()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " Update t_CustomerTran SET InstrumentStatus = ? where TranNo=?";
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddTranForWeb(int nLocationID)
        {
            int nMaxTranID = 0;
            int nRecordID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                    "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName, " +
                    "EntryUserID,EntryDate,UpdateUserID,UpdateDate,Remarks,UnAdjustedAmount,UploadStatus, " +
                    "UploadDate,DownloadDate,RowStatus,Terminal,EntryLocationID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                }
                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);

                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                cmd.Parameters.AddWithValue("EntryUserID", _EntryUserID);
                cmd.Parameters.AddWithValue("EntryDate", _EntryDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UnAdjustedAmount", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", (int)Dictionary.Terminal.Branch_Office);
                cmd.Parameters.AddWithValue("EntryLocationID", nLocationID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (InvoiceWisePayment oInvoiceWisePayment in this)
                {

                    cmd = DBController.Instance.GetCommand();
                    sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                    cmd.CommandText = sSql;
                    object maxRecordID = cmd.ExecuteScalar();
                    if (maxRecordID == DBNull.Value)
                    {
                        nRecordID = 1;
                    }
                    else
                    {
                        nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                    }

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("RecordID", nRecordID);
                    cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                    cmd.Parameters.AddWithValue("InvoiceID", oInvoiceWisePayment.InvoiceID);
                    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                    cmd.Parameters.AddWithValue("Amount", oInvoiceWisePayment.Amount);
                    cmd.Parameters.AddWithValue("CreateDate", _EntryDate);
                    cmd.Parameters.AddWithValue("CreateUserID", _EntryUserID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "UPDATE t_SalesInvoice " +
                                      "SET  DueAmount = DueAmount - ?, UpdateUserID = ?, UpdateDate = ?, RowStatus = ?, UploadStatus = ?, UploadDate = ?, DownloadDate = ? " +
                                      " WHERE InvoiceID = ? ";

                    cmd.CommandType = CommandType.Text;


                    cmd.Parameters.AddWithValue("DueAmount", oInvoiceWisePayment.Amount);
                    cmd.Parameters.AddWithValue("UpdateUserID", _EntryUserID);
                    cmd.Parameters.AddWithValue("UpdateDate", _EntryDate);
                    cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.UPDATE);
                    cmd.Parameters.AddWithValue("UploadStatus", null);
                    cmd.Parameters.AddWithValue("UploadDate", null);
                    cmd.Parameters.AddWithValue("DownloadDate", null);
                    cmd.Parameters.AddWithValue("InvoiceID", oInvoiceWisePayment.InvoiceID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RetailInsertForReverse(int nWarehoseID)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT NextMoneyReceiptNo FROM t_NextDocumentNo";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
                _oSystemInfo = new SystemInfo();
                _oSystemInfo.Refresh();

                _TranNo = "CT-" + _oSystemInfo.Shortcode + "-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                                  "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName,"+
                                  "EntryUserID,EntryDate,Remarks,RowStatus,Terminal) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                
                try
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                }
                catch
                {

                    cmd.Parameters.AddWithValue("InstrumentNo", null);
                }
                try
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                }
                catch
                {

                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }

                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);
                
                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", _TranDate);

                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);

                cmd.Parameters.AddWithValue("Terminal", (int)Dictionary.Terminal.Branch_Office);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = " Update t_NextDocumentNo SET NextMoneyReceiptNo = ?";
                cmd.Parameters.AddWithValue("MoneyReceiptNo", nNextMoneyReceiptNo + 1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                cmd.CommandText = sSql;
                object maxRecordID = cmd.ExecuteScalar();
                if (maxRecordID == DBNull.Value)
                {
                    nRecordID = 1;
                }
                else
                {
                    nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RecordID", nRecordID);
                cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateDate", Convert.ToDateTime(_oSystemInfo.OperationDate));
                cmd.Parameters.AddWithValue("CreateUserID", _UserID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance-? where CustomerID=?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RetailInsertForReverseRT(int nWarehoseID)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT NextMoneyReceiptNo FROM t_NextDocumentNo";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
                _oSystemInfo = new SystemInfo();
                _oSystemInfo.Refresh();

                _TranNo = "CT-" + _oSystemInfo.Shortcode + "-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                                  "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName," +
                                  "EntryUserID,EntryDate,Remarks,RowStatus,Terminal,EntryLocationID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);

                try
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                }
                catch
                {

                    cmd.Parameters.AddWithValue("InstrumentNo", null);
                }
                try
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                }
                catch
                {

                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }

                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);

                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", _TranDate);

                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("EntryLocationID", _EntryLocationID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = " Update t_NextDocumentNo SET NextMoneyReceiptNo = ?";
                cmd.Parameters.AddWithValue("MoneyReceiptNo", nNextMoneyReceiptNo + 1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                cmd.CommandText = sSql;
                object maxRecordID = cmd.ExecuteScalar();
                if (maxRecordID == DBNull.Value)
                {
                    nRecordID = 1;
                }
                else
                {
                    nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RecordID", nRecordID);
                cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateDate", Convert.ToDateTime(_oSystemInfo.OperationDate));
                cmd.Parameters.AddWithValue("CreateUserID", _UserID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance-? where CustomerID=?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }







        public void AddTran(bool IsTrue)
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, "+
                                  "InstrumentNo,EntryUserID,EntryDate,Remarks,RowStatus,Terminal) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", _TranDate);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                if (IsTrue)
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance-? where CustomerID=?";
                else cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }








        public void AddTranWEB(bool IsTrue,int nEntryLocationID)
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, "+
                                   "InstrumentNo,EntryUserID,EntryDate,Remarks,RowStatus,Terminal,EntryLocationID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", _TranDate);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);
                cmd.Parameters.AddWithValue("EntryLocationID", nEntryLocationID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                if (IsTrue)
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance-? where CustomerID=?";
                else cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddTranNew()
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = @"INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount,
                    InstrumentNo,EntryUserID,EntryDate,Remarks,RowStatus,Terminal) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", _TranDate);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);


                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddTranNewRT()
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = @"INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount,
                    InstrumentNo,EntryUserID,EntryDate,Remarks,RowStatus,Terminal,EntryLocationID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", _TranDate);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);
                cmd.Parameters.AddWithValue("EntryLocationID", Utility.LocationID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddPOS(bool IsTrue)
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                                  "InstrumentNo,EntryUserID,EntryDate,Remarks,RowStatus,Terminal) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", _TranDate);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                if (IsTrue)
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance-? where CustomerID=?";
                else cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();

                _oSystemInfo = new SystemInfo();
                _oSystemInfo.Refresh();
                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_CustomerTran";
                oDataTran.DataID = _TranID;
                oDataTran.WarehouseID = _oSystemInfo.WarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;

                oDataTran.Add();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddPOSDealer(bool IsTrue)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            _oSystemInfo = new SystemInfo();
            _oSystemInfo.Refresh();
            try
            {
                sSql = "SELECT NextMoneyReceiptNo FROM t_NextMoneyReceiptNo";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
                _TranNo = _oSystemInfo.Shortcode.ToString() + "-CT-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                                  "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName,EntryUserID,EntryDate,Remarks,RowStatus,Terminal) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_InstrumentType != (int)Dictionary.InstrumentType.CASH)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                    cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                    cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", null);
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                    cmd.Parameters.AddWithValue("InstrumentType", null);
                    cmd.Parameters.AddWithValue("InstrumentStatus", null);
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }

                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", _TranDate);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (_ReceiveAmount != 0)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = " Update t_NextMoneyReceiptNo SET NextMoneyReceiptNo = ?";
                    cmd.Parameters.AddWithValue("MoneyReceiptNo", nNextMoneyReceiptNo + 1);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                cmd.CommandText = sSql;
                object maxRecordID = cmd.ExecuteScalar();
                if (maxRecordID == DBNull.Value)
                {
                    nRecordID = 1;
                }
                else
                {
                    nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RecordID", nRecordID);
                cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateDate", _oSystemInfo.OperationDate);
                cmd.Parameters.AddWithValue("CreateUserID", _UserID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                if (IsTrue)
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance-? where CustomerID=?";
                else cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_CustomerTran";
                oDataTran.DataID = _TranID;
                oDataTran.WarehouseID = _oSystemInfo.WarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;

                oDataTran.Add();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddForRetailInvoice(bool IsTrue)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT NextMoneyReceiptNo FROM t_NextMoneyReceiptNo";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
                _TranNo = "CT-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                                  "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName,EntryUserID,EntryDate,Remarks,RowStatus,Terminal) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_InstrumentType != (int)Dictionary.InstrumentType.CASH)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                    cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                    cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", null);
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                    cmd.Parameters.AddWithValue("InstrumentType", null);
                    cmd.Parameters.AddWithValue("InstrumentStatus", null);
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }

                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", _TranDate);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", _Terminal);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //if (_ReceiveAmount != 0)
                //{
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = " Update t_NextMoneyReceiptNo SET NextMoneyReceiptNo = ?";
                cmd.Parameters.AddWithValue("MoneyReceiptNo", nNextMoneyReceiptNo + 1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //}

                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                cmd.CommandText = sSql;
                object maxRecordID = cmd.ExecuteScalar();
                if (maxRecordID == DBNull.Value)
                {
                    nRecordID = 1;
                }
                else
                {
                    nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RecordID", nRecordID);
                cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("CreateUserID", _UserID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (IsTrue == true)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance = CurrentBalance + ? where CustomerID=?";
                    cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertBulkTran(int nTranSide)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            try
            {

                sSql = "SELECT NextMoneyReceiptNo FROM t_NextMoneyReceiptNo";
                cmd.CommandText = sSql;
                object NextMoneyReceiptNo = cmd.ExecuteScalar();
                if (NextMoneyReceiptNo == DBNull.Value)
                {
                    nNextMoneyReceiptNo = 1;
                }
                else
                {
                    nNextMoneyReceiptNo = int.Parse(NextMoneyReceiptNo.ToString());

                }
                _TranNo = "CT-" + nNextMoneyReceiptNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                                  "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName,EntryUserID,EntryDate,Remarks,RowStatus,Terminal) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);
                if (_BranchID != -1)
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                else cmd.Parameters.AddWithValue("BranchID", null);

                cmd.Parameters.AddWithValue("BranchName", _BranchName);
                cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", (int)Dictionary.Terminal.Branch_Office);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = " Update t_NextMoneyReceiptNo SET NextMoneyReceiptNo = ?";
                cmd.Parameters.AddWithValue("MoneyReceiptNo", nNextMoneyReceiptNo + 1);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (InvoiceWisePayment oInvoiceWisePayment in this)
                {

                    cmd = DBController.Instance.GetCommand();
                    sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                    cmd.CommandText = sSql;
                    object maxRecordID = cmd.ExecuteScalar();
                    if (maxRecordID == DBNull.Value)
                    {
                        nRecordID = 1;
                    }
                    else
                    {
                        nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                    }

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("RecordID", nRecordID);
                    cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                    cmd.Parameters.AddWithValue("InvoiceID", oInvoiceWisePayment.InvoiceID);
                    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                    cmd.Parameters.AddWithValue("Amount", oInvoiceWisePayment.Amount);
                    cmd.Parameters.AddWithValue("CreateDate", _TranDate);
                    cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "UPDATE t_SalesInvoice " +
                                      "SET  DueAmount = DueAmount - ?, UpdateUserID = ?, UpdateDate = ?, RowStatus = ?, UploadStatus = ?, UploadDate = ?, DownloadDate = ? " +
                                      " WHERE InvoiceID = ? ";

                    cmd.CommandType = CommandType.Text;


                    cmd.Parameters.AddWithValue("DueAmount", oInvoiceWisePayment.Amount);
                    cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("UpdateDate", _TranDate);
                    cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.UPDATE);
                    cmd.Parameters.AddWithValue("UploadStatus", null);
                    cmd.Parameters.AddWithValue("UploadDate", null);
                    cmd.Parameters.AddWithValue("DownloadDate", null);
                    cmd.Parameters.AddWithValue("InvoiceID", oInvoiceWisePayment.InvoiceID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

                cmd = DBController.Instance.GetCommand();
                if (nTranSide == (int)Dictionary.TransectionSide.CREDIT)
                {
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                }
                else
                {
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance-? where CustomerID=?";
                }
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void SendRetailInsert(int nWarehoseID, double _BGAmount,bool IsTrue)
        {
            int nMaxTranID = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                                  "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName,EntryUserID,EntryDate,Remarks,RowStatus,Terminal) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_InstrumentType == 2)
                {
                    if (_InstrumentNo != "")
                    {
                        cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("InstrumentNo", null);
                    }
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                }
                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);

                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                cmd.CommandText = sSql;
                object maxRecordID = cmd.ExecuteScalar();
                if (maxRecordID == DBNull.Value)
                {
                    nRecordID = 1;
                }
                else
                {
                    nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RecordID", nRecordID);
                cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("CreateUserID", _UserID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "UPDATE t_SalesInvoice " +
                                  "SET  InvoiceStatus = ?, UpdateUserID = ?, UpdateDate = ?, RowStatus = ?, UploadStatus = ?, UploadDate = ?, DownloadDate = ? " +
                                  " WHERE InvoiceID = ? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.UNDELIVERED);
                //cmd.Parameters.AddWithValue("DueAmount", _Amount);
                cmd.Parameters.AddWithValue("UpdateUserID", _UserID);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.UPDATE);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                if (IsTrue)
                {
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                }
                else
                {
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance-? where CustomerID=?";
                }
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SendRetailInsertWEB(int nWarehoseID, double _BGAmount, bool IsTrue,int nEntryLocationID)
        {
            int nMaxTranID = 0;
            int nRecordID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                _TranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, " +
                                   "InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,BranchID,BranchName, "+
                                   "EntryUserID,EntryDate,Remarks,RowStatus,Terminal,EntryLocationID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);


                if (_InstrumentType == 2)
                {
                    if (_InstrumentNo != "")
                    {
                        cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("InstrumentNo", null);
                    }
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                }
                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);

                if (_InstrumentType == 2)
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                cmd.Parameters.AddWithValue("EntryUserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", (int)Dictionary.Terminal.Branch_Office);
                cmd.Parameters.AddWithValue("EntryLocationID", nEntryLocationID);

                
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                cmd.CommandText = sSql;
                object maxRecordID = cmd.ExecuteScalar();
                if (maxRecordID == DBNull.Value)
                {
                    nRecordID = 1;
                }
                else
                {
                    nRecordID = int.Parse(maxRecordID.ToString()) + 1;

                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RecordID", nRecordID);
                cmd.Parameters.AddWithValue("CustomerTranID", _TranID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("CreateUserID", _UserID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "UPDATE t_SalesInvoice " +
                                  "SET  InvoiceStatus = ?, UpdateUserID = ?, UpdateDate = ?, RowStatus = ?, UploadStatus = ?, UploadDate = ?, DownloadDate = ? " +
                                  " WHERE InvoiceID = ? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.UNDELIVERED);
                //cmd.Parameters.AddWithValue("DueAmount", _Amount);
                cmd.Parameters.AddWithValue("UpdateUserID", _UserID);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.UPDATE);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                if (IsTrue)
                {
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                }
                else
                {
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance-? where CustomerID=?";
                }
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTranID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_InvoiceWisePayment where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _TranID = Convert.ToInt32(reader["CustomerTranID"]);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.*,CustomerCode, CustomerName, InstrumentTypeName=CASE " +
                            "When InstrumentType=0 then 'DD' When InstrumentType=1 then 'PAYORDER' " +
                            "When InstrumentType=2 then 'CASH' When InstrumentType=3 then 'CHEQUE' " +
                            "When InstrumentType=4 then 'TT' When InstrumentType=5 then 'CREDIT_CARD' end,BankBranchName, BankName, BranchAddress " +
                            " FROM t_CustomerTran a INNER JOIN  " +
                            "(Select CustomerID,CustomerCode, CustomerName from t_Customer) b ON a.CustomerID=b.CustomerID " +
                            "Left OUter JOIN " +
                            "(select BranchID, a.Name as BankBranchName,b.Name as BankName, Address as BranchAddress from t_BankBranch a " +
                            "INNER JOIN t_Bank b on a.BankID=b.BankID)Bank ON Bank.BranchID=a.BranchID where TranID=? ";

            cmd.Parameters.AddWithValue("TranID", _TranID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _TranNo = (string)reader["TranNo"];
                    _TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _CustomerID = (int)reader["CustomerID"];
                    _sCustomerCode = reader["CustomerCode"].ToString();
                    _sCustomerName = reader["CustomerName"].ToString();
                    _sInstrumentTypeName = reader["InstrumentTypeName"].ToString();
                    if (reader["InstrumentType"] != DBNull.Value)
                    {
                        _InstrumentType = (int)reader["InstrumentType"];
                        if (_InstrumentType != (int)Dictionary.InstrumentType.CASH)
                        {
                            _InstrumentNo = (string)reader["InstrumentNo"];
                            _InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                            _BranchID = (int)reader["BranchID"];
                            _sBankName = reader["BankName"].ToString();
                            if (reader["BranchName"] != DBNull.Value)
                            {
                                _BranchName = reader["BranchName"].ToString();
                            }
                            else
                            {
                                _BranchName = reader["BankBranchName"].ToString();
                            }

                        }
                        else
                        {
                            _InstrumentNo = "N/A";
                            _InstrumentDate = Convert.ToDateTime("01-Jan-2000");
                            _BranchID = -1;
                            _sBankName = "N/A";
                            _BranchName = "N/A";
                        }
                    }
                    else
                    {
                        _InstrumentNo = "N/A";
                        _InstrumentDate = Convert.ToDateTime("01-Jan-2000");
                        _BranchID = -1;
                        _sBankName = "N/A";
                        _BranchName = "N/A";
                    }
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    // _Remarks = (string)reader["Remarks"];
                    _Remarks = Convert.ToString(reader["Remarks"]);

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckTranNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_CustomerTran where TranNo=?";
            cmd.Parameters.AddWithValue("TranNo", _TranNo);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _TranID = Convert.ToInt32(reader["TranID"]);
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0) return true;
            else return false;

        }


        public int GetLocationByWHID(int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nLocationID = 0;
            string sSql = "Select LocationID From t_Showroom where WarehouseID=" + nWarehouseID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nLocationID = Convert.ToInt32(reader["LocationID"]);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nLocationID;

        }

        public bool CheckCustomerAccount(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_CustomerAccount where CustomerID=?";
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _BalanceAmount = Convert.ToDouble(reader["CurrentBalance"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0) return true;
            else return false;

        }
        public void GetTranNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CustomerTran where TranID=?";
            cmd.Parameters.AddWithValue("TranID", _TranID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _TranNo = reader["TranNo"].ToString();
                    //_TranTypeID = Convert.ToInt32(reader["TranTypeID"].ToString());
                    //_Amount = Convert.ToDouble(reader["Amount"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void SendCustomerTran(int nWarehoseID, bool IsHOEnd)
        {
            int nMaxTranID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nTranID = 0;
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_CustomerTran";
                cmd.CommandText = sSql;
                object maxTranID = cmd.ExecuteScalar();
                if (maxTranID == DBNull.Value)
                {
                    nMaxTranID = 1;
                }
                else
                {
                    nMaxTranID = int.Parse(maxTranID.ToString()) + 1;

                }
                nTranID = nMaxTranID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CustomerTran VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", nTranID);
                cmd.Parameters.AddWithValue("TranNo", _TranNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_InstrumentNo != "")
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", null);
                }

                if (_InstrumentDate != null)
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                else cmd.Parameters.AddWithValue("InstrumentDate", null);

                if (_InstrumentType != -1)
                {
                    cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentType", null);
                }
                if (_InstrumentStatus != -1)
                {
                    cmd.Parameters.AddWithValue("InstrumentStatus", _InstrumentStatus);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentStatus", null);
                }
                if (_BranchID != -1)
                {
                    cmd.Parameters.AddWithValue("BranchID", _BranchID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchID", null);
                }
                if (_BranchName != "")
                {
                    cmd.Parameters.AddWithValue("BranchName", _BranchName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                cmd.Parameters.AddWithValue("EntryUserID", _EntryUserID);
                cmd.Parameters.AddWithValue("EntryDate", _EntryDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UnAdjustedAmount", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", (int)Dictionary.Terminal.Head_Office);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                AppLogger.LogInfo("Successfully Upload Customer Tran");

            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Uploading Customer Tran /" + ex.Message);
            }
            //string sInvoiceNo = _InvoiceID;

            int nTranSide = 0;
            nTranSide = _TranSide;
            try
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                if (nTranSide == 1)
                {
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance = CurrentBalance + ? where CustomerID=?";
                }
                else if (nTranSide == 2)
                {
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance = CurrentBalance - ? where CustomerID=?";
                }
                cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                AppLogger.LogInfo("Successfully Uploaded & Editted Customer Account");
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error Uploading & Editted Customer Account /" + ex.Message);
            }

            foreach (InvoiceWisePayment oIWP in this)
            {
                try
                {
                    string Sql = "";
                    int nMaxRecordID = 0;
                    int nRecordID = 0;

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    Sql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
                    cmd.CommandText = Sql;
                    object maxRecordID = cmd.ExecuteScalar();
                    if (maxRecordID == DBNull.Value)
                    {
                        nMaxRecordID = 1;
                    }
                    else
                    {
                        nMaxRecordID = int.Parse(maxRecordID.ToString()) + 1;

                    }
                    nRecordID = nMaxRecordID;

                    long nInvoiceID = 0;
                    SalesInvoice oSalesinvoice = new SalesInvoice();
                    oSalesinvoice.GetIDByInvoiceNo(oIWP.InvoiceNo);
                    nInvoiceID = oSalesinvoice.InvoiceID;

                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "INSERT INTO t_InvoiceWisePayment VALUES(?,?,?,?,?,?,?)";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("RecordID", nRecordID);
                    cmd.Parameters.AddWithValue("CustomerTranID", nTranID);
                    cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                    cmd.Parameters.AddWithValue("Amount", oIWP.Amount);
                    cmd.Parameters.AddWithValue("CreateDate", _EntryDate);
                    cmd.Parameters.AddWithValue("CreateUserID", _EntryUserID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    AppLogger.LogInfo("Successfully Uploaded Invoice Wise Payment");


                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "UPDATE t_SalesInvoice " +
                                      "SET  DueAmount = DueAmount - " + oIWP.Amount + ", UpdateUserID = ?, UpdateDate = ?, RowStatus = ?, UploadStatus = ?, UploadDate = ?, DownloadDate = ? " +
                                      " WHERE InvoiceID = ? ";

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("UpdateUserID", _EntryUserID);
                    cmd.Parameters.AddWithValue("UpdateDate", _EntryDate);
                    cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.UPDATE);
                    cmd.Parameters.AddWithValue("UploadStatus", null);
                    cmd.Parameters.AddWithValue("UploadDate", null);
                    cmd.Parameters.AddWithValue("DownloadDate", null);
                    cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Error Uploading Invoice Wise Payment /" + ex.Message);
                }

            }
            
        }

        public void GetInvoiceWisePaymentForDataSet(int nTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select a.*,InvoiceNo From t_InvoiceWisePayment a,t_Salesinvoice b where a.InvoiceID=b.invoiceID and CustomerTranID=" + nTranID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InvoiceWisePayment oItem = new InvoiceWisePayment();

                    oItem.RecordID = int.Parse(reader["RecordID"].ToString());
                    oItem.CustomerTranID = int.Parse(reader["CustomerTranID"].ToString());
                    oItem.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oItem.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    oItem.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oItem.InvoiceNo = (reader["InvoiceNo"].ToString());
                    oItem.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oItem.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oItem);
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
    public class CustomerTransactionReport : CollectionBase
    {
        public CustomerTransaction this[int i]
        {
            get { return (CustomerTransaction)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CustomerTransaction oCustomerTransaction)
        {
            InnerList.Add(oCustomerTransaction);
        }

        public void Refresh(int nTranID)
        {
            InnerList.Clear();

            CustomerTransaction oCustomerTransaction = new CustomerTransaction();
            oCustomerTransaction.Copy = "Money Receipt Accounts Copy";
            InnerList.Add(oCustomerTransaction);

            oCustomerTransaction = new CustomerTransaction();
            oCustomerTransaction.Copy = "Money Receipt Customer Copy";
            InnerList.Add(oCustomerTransaction);



            InnerList.TrimToSize();


        }

        public void RefreshForDataSending(int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CustomerTran a inner join t_DataTransfer b on b.DataID=a.TranID "
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? Order By TranID ";

            cmd.Parameters.AddWithValue("TableName", "t_CustomerTran");
            cmd.Parameters.AddWithValue("IsDownload", 1);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerTransaction _oCustomerTransaction = new CustomerTransaction();

                    _oCustomerTransaction.TranID = Convert.ToInt32(reader["TranID"].ToString());
                    _oCustomerTransaction.TranNo = reader["TranNo"].ToString();
                    _oCustomerTransaction.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _oCustomerTransaction.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _oCustomerTransaction.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _oCustomerTransaction.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    if (reader["InstrumentNo"] != DBNull.Value)
                    {
                        _oCustomerTransaction.InstrumentNo = reader["InstrumentNo"].ToString();
                    }
                    else
                    {
                        _oCustomerTransaction.InstrumentNo = "";
                    }
                    if (reader["InstrumentDate"] != DBNull.Value)
                    {
                        _oCustomerTransaction.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    }
                    else
                    {

                    }
                    if (reader["InstrumentType"] != DBNull.Value)
                    {
                        _oCustomerTransaction.InstrumentType = Convert.ToInt32(reader["InstrumentType"]);
                    }
                    else
                    {
                        _oCustomerTransaction.InstrumentType = -1;
                    }
                    if (reader["InstrumentStatus"] != DBNull.Value)
                    {
                        _oCustomerTransaction.InstrumentStatus = int.Parse(reader["InstrumentStatus"].ToString());
                    }
                    else
                    {
                        _oCustomerTransaction.InstrumentStatus = -1;
                    }
                    if (reader["BranchID"] != DBNull.Value)
                    {
                        _oCustomerTransaction.BranchID = int.Parse(reader["BranchID"].ToString());
                    }
                    else
                    {
                        _oCustomerTransaction.BranchID = -1;
                    }
                    if (reader["BranchName"] != DBNull.Value)
                    {
                        _oCustomerTransaction.BranchName = reader["BranchName"].ToString();
                    }
                    else
                    {
                        _oCustomerTransaction.BranchName = "";
                    }
                    _oCustomerTransaction.EntryUserID = int.Parse(reader["EntryUserID"].ToString());
                    _oCustomerTransaction.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        _oCustomerTransaction.Remarks = reader["Remarks"].ToString();
                    }
                    else
                    {
                        _oCustomerTransaction.Remarks = "";
                    }
                    _oCustomerTransaction.InvoiceWisePayments.Refresh(_oCustomerTransaction.TranID);

                    InnerList.Add(_oCustomerTransaction);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForDataDownload(int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CustomerTran a inner join t_DataTransfer b on b.DataID=a.TranID "
                          + " inner join t_CustomerTranType c on c.TranTypeID = a.TranTypeID" 
                          + " where b.TableName=? and "
                          + " b.IsDownload= ? and b.WarehouseID= ? Order By TranID ";

            cmd.Parameters.AddWithValue("TableName", "t_CustomerTran");
            cmd.Parameters.AddWithValue("IsDownload", 1);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerTransaction _oCustomerTransaction = new CustomerTransaction();

                    _oCustomerTransaction.TranID = Convert.ToInt32(reader["TranID"].ToString());
                    _oCustomerTransaction.TranNo = reader["TranNo"].ToString();
                    _oCustomerTransaction.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _oCustomerTransaction.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _oCustomerTransaction.TranTypeID = int.Parse(reader["TranTypeID"].ToString());
                    _oCustomerTransaction.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _oCustomerTransaction.TranSide = Convert.ToInt32(reader["TranSide"].ToString());
                    if (reader["InstrumentNo"] != DBNull.Value)
                    {
                        _oCustomerTransaction.InstrumentNo = reader["InstrumentNo"].ToString();
                    }
                    else
                    {
                        _oCustomerTransaction.InstrumentNo = "";
                    }
                    if (reader["InstrumentDate"] != DBNull.Value)
                    {
                        _oCustomerTransaction.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    }
                    else
                    {
                        _oCustomerTransaction.InstrumentDate = null;
                    }
                    if (reader["InstrumentType"] != DBNull.Value)
                    {
                        _oCustomerTransaction.InstrumentType = Convert.ToInt32(reader["InstrumentType"]);
                    }
                    else
                    {
                        _oCustomerTransaction.InstrumentType = -1;
                    }
                    if (reader["InstrumentStatus"] != DBNull.Value)
                    {
                        _oCustomerTransaction.InstrumentStatus = int.Parse(reader["InstrumentStatus"].ToString());
                    }
                    else
                    {
                        _oCustomerTransaction.InstrumentStatus = -1;
                    }
                    if (reader["BranchID"] != DBNull.Value)
                    {
                        _oCustomerTransaction.BranchID = int.Parse(reader["BranchID"].ToString());
                    }
                    else
                    {
                        _oCustomerTransaction.BranchID = -1;
                    }
                    if (reader["BranchName"] != DBNull.Value)
                    {
                        _oCustomerTransaction.BranchName = reader["BranchName"].ToString();
                    }
                    else
                    {
                        _oCustomerTransaction.BranchName = "";
                    }
                    _oCustomerTransaction.EntryUserID = int.Parse(reader["EntryUserID"].ToString());
                    _oCustomerTransaction.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        _oCustomerTransaction.Remarks = reader["Remarks"].ToString();
                    }
                    else
                    {
                        _oCustomerTransaction.Remarks = "";
                    }
                    _oCustomerTransaction.InvoiceWisePayments.Refresh(_oCustomerTransaction.TranID);

                    InnerList.Add(_oCustomerTransaction);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetTransaction(DateTime dtFromDate, DateTime dtToDate, String txtTranNo)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select TranID, TranNo,TranDate, Amount,(CustomerName+' ['+CustomerCode+']') as Customer  FROM t_CustomerTran a INNER JOIN " +
                            "(Select CustomerID,CustomerCode, CustomerName from t_Customer) b ON a.CustomerID=b.CustomerID " +
                            "Where InstrumentType Is NOT Null and TranDate between ? and ? and TranDate < ?   ";

            cmd.Parameters.AddWithValue("TranDate", dtFromDate);
            cmd.Parameters.AddWithValue("TranDate", dtToDate);
            cmd.Parameters.AddWithValue("TranDate", dtToDate);

            if (txtTranNo != "")
            {
                sSql = sSql + " AND TranNo ='" + txtTranNo + "'";
            }
            sSql = sSql + " order by TranID ASC ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerTransaction _oCustomerTransaction = new CustomerTransaction();

                    _oCustomerTransaction.TranID = Convert.ToInt32(reader["TranID"].ToString());
                    _oCustomerTransaction.TranNo = reader["TranNo"].ToString();
                    _oCustomerTransaction.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _oCustomerTransaction.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _oCustomerTransaction.CustomerName = reader["Customer"].ToString();

                    InnerList.Add(_oCustomerTransaction);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetTransactionForPos(DateTime dtFromDate, DateTime dtToDate, String txtTranNo)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select TranID, TranNo,TranDate, Amount,(CustomerName+' ['+CustomerCode+']') as Customer  FROM t_CustomerTran a INNER JOIN " +
                            "(Select CustomerID,CustomerCode, CustomerName from t_Customer) b ON a.CustomerID=b.CustomerID " +
                            "Where InstrumentType Is NOT Null and TranTypeID=" + (int)Dictionary.TransectionType.CREDIT_RECEIVE + "and TranDate between ? and ? and TranDate < ?   ";

            cmd.Parameters.AddWithValue("TranDate", dtFromDate);
            cmd.Parameters.AddWithValue("TranDate", dtToDate);
            cmd.Parameters.AddWithValue("TranDate", dtToDate);

            if (txtTranNo != "")
            {
                sSql = sSql + " AND TranNo ='" + txtTranNo + "'";
            }
            sSql = sSql + " order by TranID ASC ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerTransaction _oCustomerTransaction = new CustomerTransaction();

                    _oCustomerTransaction.TranID = Convert.ToInt32(reader["TranID"].ToString());
                    _oCustomerTransaction.TranNo = reader["TranNo"].ToString();
                    _oCustomerTransaction.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _oCustomerTransaction.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _oCustomerTransaction.CustomerName = reader["Customer"].ToString();

                    InnerList.Add(_oCustomerTransaction);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetTransactionForPosRT(DateTime dtFromDate, DateTime dtToDate, String txtTranNo)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select TranID, TranNo,TranDate, Amount,(CustomerName+' ['+CustomerCode+']') as Customer  FROM t_CustomerTran a INNER JOIN " +
                            "t_Customer b ON a.CustomerID=b.CustomerID " +
                            "Where a.EntryLocationID=" + Utility.LocationID + " and InstrumentType Is NOT Null and TranTypeID=" + (int)Dictionary.TransectionType.CREDIT_RECEIVE + "and TranDate between ? and ? and TranDate < ?   ";

            cmd.Parameters.AddWithValue("TranDate", dtFromDate);
            cmd.Parameters.AddWithValue("TranDate", dtToDate);
            cmd.Parameters.AddWithValue("TranDate", dtToDate);

            if (txtTranNo != "")
            {
                sSql = sSql + " AND TranNo ='" + txtTranNo + "'";
            }
            sSql = sSql + " order by TranID ASC ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerTransaction _oCustomerTransaction = new CustomerTransaction();

                    _oCustomerTransaction.TranID = Convert.ToInt32(reader["TranID"].ToString());
                    _oCustomerTransaction.TranNo = reader["TranNo"].ToString();
                    _oCustomerTransaction.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _oCustomerTransaction.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _oCustomerTransaction.CustomerName = reader["Customer"].ToString();

                    InnerList.Add(_oCustomerTransaction);

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

    public class InvoiceWisePayment
    {
        private int _nRecordID;
        private int _nCustomerTranID;
        private long _nInvoiceID;
        private int _nCustomerID;
        private double _Amount;
        private DateTime _dCreateDate;
        private int _nCreateUserID;

        public int RecordID
        {
            get { return _nRecordID; }
            set { _nRecordID = value; }
        }
        public int CustomerTranID
        {
            get { return _nCustomerTranID; }
            set { _nCustomerTranID = value; }
        }
        public long InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        private string _sInvoiceNo;
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }

        private double _AdvanceAmt;
        public double AdvanceAmt
        {
            get { return _AdvanceAmt; }
            set { _AdvanceAmt = value; }
        }

        public void CheckAdvanceAmt(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select TranID,TranDate,Amount,IsNull(RcvAmount,0)RcvAmount, (Amount-IsNull(RcvAmount,0))as AdvanceAmt from t_customerTran a " +
                            "Left outer join (SELECT CustomerTranID,Sum(Amount)RcvAmount FROM t_InvoiceWisePayment group by CustomerTranID)as b " +
                            "ON a.TranID=b.CustomerTranID Where TranID=?";
            cmd.Parameters.AddWithValue("TranID", nTranID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AdvanceAmt = Convert.ToDouble(reader["AdvanceAmt"].ToString());
                    _dCreateDate = Convert.ToDateTime(reader["TranDate"].ToString());
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void DeleteByInvoiceID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_InvoiceWisePayment WHERE [InvoiceID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }


    }
    public class InvoiceWisePayments : CollectionBase
    {
        public InvoiceWisePayment this[int i]
        {
            get { return (InvoiceWisePayment)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(InvoiceWisePayment oInvoiceWisePayment)
        {
            InnerList.Add(oInvoiceWisePayment);
        }

        public void Refresh(int nTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.*,b.InvoiceNo FROM t_InvoiceWisePayment a INNER JOIN (Select InvoiceID, InvoiceNo from t_SalesInvoice)b " +
                            "ON a.InvoiceID=b.InvoiceID where CustomerTranID=? ";

            cmd.Parameters.AddWithValue("CustomerTranID", nTranID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    InvoiceWisePayment oInvoiceWisePayment = new InvoiceWisePayment();


                    oInvoiceWisePayment.RecordID = Convert.ToInt32(reader["RecordID"].ToString());
                    oInvoiceWisePayment.CustomerTranID = Convert.ToInt32(reader["CustomerTranID"].ToString());
                    oInvoiceWisePayment.InvoiceID = Convert.ToInt32(reader["InvoiceID"].ToString());
                    oInvoiceWisePayment.CustomerID = Convert.ToInt32(reader["CustomerID"].ToString());
                    oInvoiceWisePayment.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oInvoiceWisePayment.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oInvoiceWisePayment.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oInvoiceWisePayment.InvoiceNo = reader["InvoiceNo"].ToString();

                    InnerList.Add(oInvoiceWisePayment);

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
    public class CustomerTranGroup
    {
        private int _nTranGroupID;
        private string _sTranGroupName;

        public int TranGroupID
        {
            get { return _nTranGroupID; }
            set { _nTranGroupID = value; }
        }
        public string TranGroupName
        {
            get { return _sTranGroupName; }
            set { _sTranGroupName = value; }
        }

    }

    public class CustomerTranGroups : CollectionBase
    {
        public CustomerTranGroup this[int i]
        {
            get { return (CustomerTranGroup)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CustomerTranGroup oCustomerTranGroup)
        {
            InnerList.Add(oCustomerTranGroup);
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select TranGroupID, TranGroupName from t_CustomerTranGroup Order by TranGroupID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerTranGroup oCustomerTranGroup = new CustomerTranGroup();

                    oCustomerTranGroup.TranGroupID = Convert.ToInt32(reader["TranGroupID"].ToString());
                    oCustomerTranGroup.TranGroupName = (string)reader["TranGroupName"];

                    InnerList.Add(oCustomerTranGroup);

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


    public class CustomerTranType
    {
        private int _nTranTypeID;
        private string _sTranTypeCode;
        private string _sTranTypeName;
        private int _nTranSide;
        private string _sTranSideName;

        public int TranTypeID
        {
            get { return _nTranTypeID; }
            set { _nTranTypeID = value; }
        }
        public string TranTypeCode
        {
            get { return _sTranTypeCode; }
            set { _sTranTypeCode = value; }
        }
        public string TranTypeName
        {
            get { return _sTranTypeName; }
            set { _sTranTypeName = value; }
        }
        public int TranSide
        {
            get { return _nTranSide; }
            set { _nTranSide = value; }
        }
        public string TranSideName
        {
            get { return _sTranSideName; }
            set { _sTranSideName = value; }
        }

        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select TranTypeID, TranTypeName from t_CustomerTranType Order by TranTypeID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerTranType oCustomerTranType = new CustomerTranType();

                    oCustomerTranType.TranTypeID = Convert.ToInt32(reader["TranTypeID"].ToString());
                    oCustomerTranType.TranTypeName = (string)reader["TranTypeName"];
                    
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
    public class CustomerTranTypes : CollectionBase
    {
        public CustomerTranType this[int i]
        {
            get { return (CustomerTranType)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CustomerTranType oCustomerTranType)
        {
            InnerList.Add(oCustomerTranType);
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select TranTypeID, TranTypeCode, TranTypeName, TranSide, CASE When TranSide = 1 then 'CREDIT' else 'DEBIT' end as TranSideName from t_CustomerTranType Order by TranTypeID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerTranType oCustomerTranType = new CustomerTranType();

                    oCustomerTranType.TranTypeID = Convert.ToInt32(reader["TranTypeID"].ToString());
                    oCustomerTranType.TranTypeCode = (string)reader["TranTypeCode"];
                    oCustomerTranType.TranTypeName = (string)reader["TranTypeName"];
                    oCustomerTranType.TranSide = Convert.ToInt32(reader["TranSide"].ToString());
                    oCustomerTranType.TranSideName = (string)reader["TranSideName"];

                    InnerList.Add(oCustomerTranType);

                }
                reader.Close();
                InnerList.TrimToSize();

               

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshWithAll()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select TranTypeID, TranTypeCode, TranTypeName, TranSide, CASE When TranSide = 1 then 'CREDIT' else 'DEBIT' end as TranSideName from t_CustomerTranType Order by TranTypeID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                CustomerTranType oCustomerTranType;
                while (reader.Read())
                {
                    oCustomerTranType = new CustomerTranType();

                    oCustomerTranType.TranTypeID = Convert.ToInt32(reader["TranTypeID"].ToString());
                    oCustomerTranType.TranTypeName = (string)reader["TranTypeName"];
                    InnerList.Add(oCustomerTranType);

                }
                //reader.Close();

                //oCustomerTranType = new CustomerTranType {TranTypeID = -1, TranSideName = "<ALL>"};
                //InnerList.Add(oCustomerTranType);
                //InnerList.TrimToSize();

                //cmd.ExecuteNonQuery();
                //cmd.Dispose();


                oCustomerTranType = new CustomerTranType {TranTypeID = -1, TranTypeName = "ALL"};
                InnerList.Add(oCustomerTranType);

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshByGroup(int TranGroupID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select TranTypeID,TranSide,TranTypeName+' ['+TranTypeCode+'] '+'['+case when TranSide=1 then 'Credit' else 'Debit' end +']' as TranTypeName From t_CustomerTranType where TranGroupID=" + TranGroupID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerTranType oCustomerTranType = new CustomerTranType();

                    oCustomerTranType.TranTypeID = Convert.ToInt32(reader["TranTypeID"].ToString());
                    oCustomerTranType.TranTypeName = (string)reader["TranTypeName"];
                    oCustomerTranType.TranSide = Convert.ToInt32(reader["TranSide"].ToString());

                    InnerList.Add(oCustomerTranType);

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
    public class CustomerTransactions : CollectionBase
    {
        public CustomerTransaction this[int i]
        {
            get { return (CustomerTransaction)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CustomerTransaction oCustomerTransaction)
        {
            InnerList.Add(oCustomerTransaction);
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate, string sInstrumentNo, string sTranNo, int nInstrumentStatus,int nCustomerID,int nParentCustomerID,int nCustomerTranTypeGroupID, int nCustomerTranTypeID, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select TranNo,TranDate,CustomerName + ' ['+CustomerCode+'] ' as [CustomerName] ,ParentCustomerName + ' ['+ParentCustomerCode+'] ' as [ParentCustomerName],TranGroupName,TranTypeName+' ['+TranTypeCode+'] '+'['+case when TranSide=1 then 'Credit' else 'Debit' end +']' as TranTypeName,Amount,InstrumentNo,InstrumentStatus,c.TranGroupID,TranID,InstrumentType,Remarks, f.Name as BankName,e.Name as BranchName,CustomerCode,InstrumentDate,RowStatus from t_CustomerTran a " +
                            "inner join t_CustomerTranType b on a.TranTypeID = b.TranTypeID "+
                            "inner join t_CustomerTranGroup c on c.TranGroupID = b.TranGroupID " +
                            "inner join v_CustomerDetails d on d.CustomerID = a.CustomerID "+
                            "left join t_BankBranch e on e.BranchID=a.BranchID left join t_Bank f on f.BankID=e.BankID " +
                            "where c.TranGroupName <> 'Sales' ";

            if (IsCheck == false)
            {
                sSql = sSql + " AND a.TranDate between '" + dFromDate + "' and '" + dToDate + "' ";
            }

            if (sInstrumentNo != "")
            {
                sSql = sSql + " AND InstrumentNo like '%" + sInstrumentNo + "%'";
            }
            if (sTranNo != "")
            {
                sSql = sSql + " AND a.TranNo like '%" + sTranNo + "%'";
            }
            if (nInstrumentStatus != -1)
            {
                sSql = sSql + " AND a.InstrumentStatus = '" + nInstrumentStatus + "'";
            }
            if (nCustomerID != -1 && nCustomerID != 0)
            {
                sSql = sSql + " AND a.CustomerID=" + nCustomerID + "";
            }
            if (nParentCustomerID != -1 && nParentCustomerID != 0)
            {
                sSql = sSql + " AND d.ParentCustomerID=" + nParentCustomerID + "";
            }
            if (nCustomerTranTypeGroupID != -1)
            {
                sSql = sSql + " AND c.TranGroupID=" + nCustomerTranTypeGroupID + "";
            }
            if (nCustomerTranTypeID != -1)
            {
                sSql = sSql + " AND b.TranTypeID=" + nCustomerTranTypeID + "";
            }
            sSql = sSql + " Order by TranID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerTransaction oCustomerTransaction = new CustomerTransaction();

                    oCustomerTransaction.TranNo = reader["TranNo"].ToString();
                    oCustomerTransaction.TranDate = (DateTime)reader["TranDate"];
                    oCustomerTransaction.CustomerName = reader["CustomerName"].ToString();
                    if (reader["ParentCustomerName"] == DBNull.Value)
                    {
                        oCustomerTransaction.ParentCustomerName = "";
                    }
                    else
                    {
                        oCustomerTransaction.ParentCustomerName = (string)reader["ParentCustomerName"];
                    }
                    oCustomerTransaction.TranTypeGroupName = reader["TranGroupName"].ToString();
                    oCustomerTransaction.TranTypeName = (string)reader["TranTypeName"];
                    oCustomerTransaction.Amount = (double)reader["Amount"];
                    if (reader["InstrumentNo"] == DBNull.Value)
                    {
                        oCustomerTransaction.InstrumentNo = "";
                    }
                    else
                    {
                        oCustomerTransaction.InstrumentNo = (string)reader["InstrumentNo"];
                    }
                    if (reader["InstrumentStatus"] == DBNull.Value)
                    {
                        oCustomerTransaction.InstrumentStatus = 0;
                    }
                    else
                    {
                        oCustomerTransaction.InstrumentStatus = (int)reader["InstrumentStatus"];
                    }
                    oCustomerTransaction.TranTypeGroupID = (int)reader["TranGroupID"];
                    oCustomerTransaction.TranID = (int)reader["TranID"];
                    if (reader["InstrumentType"] == DBNull.Value)
                    {
                        oCustomerTransaction.InstrumentType = 0;
                    }
                    else
                    {
                        oCustomerTransaction.InstrumentType = (int)reader["InstrumentType"];
                    }

                    if (reader["RowStatus"] == DBNull.Value)
                    {
                        oCustomerTransaction.RowStatus = 0;
                    }
                    else
                    {
                        oCustomerTransaction.RowStatus = Convert.ToInt32(reader["RowStatus"]);
                    }

                    if (reader["Remarks"] == DBNull.Value)
                    {
                        oCustomerTransaction.Remarks = "";
                    }
                    else
                    {
                        oCustomerTransaction.Remarks = reader["Remarks"].ToString();
                    }
                    if (reader["BankName"] == DBNull.Value)
                    {
                        oCustomerTransaction.BankName = "";
                    }
                    else
                    {
                        oCustomerTransaction.BankName = reader["BankName"].ToString();
                    }
                    if (reader["BranchName"] == DBNull.Value)
                    {
                        oCustomerTransaction.BranchName = "";
                    }
                    else
                    {
                        oCustomerTransaction.BranchName = reader["BranchName"].ToString();
                    }
                    oCustomerTransaction.CustomerCode = reader["CustomerCode"].ToString();
                    if (reader["InstrumentDate"] == DBNull.Value)
                    {
                        oCustomerTransaction.InstrumentDate = DateTime.Today.Date;
                    }
                    else
                    {
                        oCustomerTransaction.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"]);
                    }
                    InnerList.Add(oCustomerTransaction);

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

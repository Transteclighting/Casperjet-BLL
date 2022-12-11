// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Aug, 2011
// Time : 10:00 AM
// Description: Class for EPS Customer Transaction.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class EPSCustomerTransaction
    {
        private int _TranID;
        private string _TranNo;
        private int _CustomerID;
        private long _InvoiceID;
        private DateTime _TranDate;
        private int _TranTypeID;
        private double _Amount;
        private string _InstrumentNo;
        private DateTime _InstrumentDate;
        private int _InstrumentType;
        private int _InstrumentStatus;
        private int _BranchID;
        private string _BranchName;
        private int _EntryUserID;
        private DateTime _EntryDate;
        private int _UpdateUserID;
        private DateTime _UpdateDate;
        private string _Remarks;
        private string _UnAdjustedAmount;
        private string _UploadStatus;
        private DateTime _UploadDate;
        private DateTime _DownloadDate;
        private DateTime _RowStatus;
        private DateTime _Terminal;
        private string _Copy;
        private int _EmployeeID;
        private int _InstallmentNo;
        private int _EPSCustomerID;
        private double _PrincipalAmount;
        private double _InterestAmount;
        private int _nOrderID;
        private int _nIsEarlyClose;

        private EPSCustomer _oEPSCustomer;

        public EPSCustomer EPSCustomer
        {
            get
            {
                if (_oEPSCustomer == null)
                {
                    _oEPSCustomer = new EPSCustomer();
                    _oEPSCustomer.EPSCustomerID = _EPSCustomerID;
                    _oEPSCustomer.RefreshByEPSCustomer();
                }

                return _oEPSCustomer;
            }
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
        public DateTime InstrumentDate
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
        public string UnAdjustedAmount
        {
            get { return _UnAdjustedAmount; }
            set { _UnAdjustedAmount = value.Trim(); }
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
        public DateTime RowStatus
        {
            get { return _RowStatus; }
            set { _RowStatus = value; }
        }

        /// <summary>
        /// Get set property for Terminal
        /// </summary>
        public DateTime Terminal
        {
            get { return _Terminal; }
            set { _Terminal = value; }
        }
        /// <summary>
        /// Get set property for InstallmentNo
        /// </summary>
        public int InstallmentNo
        {
            get { return _InstallmentNo; }
            set { _InstallmentNo = value; }
        }

        /// <summary>
        /// Get set property for EPSCustomerID
        /// </summary>
        public int EPSCustomerID
        {
            get { return _EPSCustomerID; }
            set { _EPSCustomerID = value; }
        }

        /// <summary>
        /// Get set property for PrincipalAmount
        /// </summary>
        public double PrincipalAmount
        {
            get { return _PrincipalAmount; }
            set { _PrincipalAmount = value; }
        }

        /// <summary>
        /// Get set property for InterestAmount
        /// </summary>
        public double InterestAmount
        {
            get { return _InterestAmount; }
            set { _InterestAmount = value; }
        }
        /// <summary>
        /// Get set property for OrderID
        /// </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }
        /// <summary>
        /// Get set property for IsEarlyClose
        /// </summary>
        public int IsEarlyClose
        {
            get { return _nIsEarlyClose; }
            set { _nIsEarlyClose = value; }
        }
        


        public void Insert(bool IsTrue)
        {
            int nMaxTranID = 0;
            int nNextMoneyReceiptNo = 0;           

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
                _TranNo = "EPS-" + nNextMoneyReceiptNo.ToString();

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

                cmd.CommandText = "INSERT INTO t_CustomerTran (TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount, "+
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
                    cmd.Parameters.AddWithValue("InstrumentNo", null);
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
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);
                cmd.Parameters.AddWithValue("UnAdjustedAmount", null);
                cmd.Parameters.AddWithValue("UploadStatus", null);
                cmd.Parameters.AddWithValue("UploadDate", null);
                cmd.Parameters.AddWithValue("DownloadDate", null);
                cmd.Parameters.AddWithValue("RowStatus", (short)Dictionary.RowStatus.ADD);
                cmd.Parameters.AddWithValue("Terminal", null);
                cmd.Parameters.AddWithValue("EntryLocationID", (int)Dictionary.JobLocation.HO);
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (IsTrue == true)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = " Update t_NextMoneyReceiptNo SET NextMoneyReceiptNo = ?";
                    cmd.Parameters.AddWithValue("MoneyReceiptNo", nNextMoneyReceiptNo + 1);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance+? where CustomerID=?";
                    cmd.Parameters.AddWithValue("CurrentBalance", _Amount);
                    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update t_CustomerAccount set CurrentBalance=CurrentBalance-? where CustomerID=?";
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
        public void InsertDetail()
        {
            int nRecordID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                string sSql = "SELECT MAX([RecordID]) FROM t_InvoiceWisePayment";
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
                cmd.Parameters.AddWithValue("Amount", _PrincipalAmount);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "UPDATE t_SalesInvoice " +
                                  "SET  DueAmount = DueAmount - ?, UpdateUserID = ?, UpdateDate = ? " +
                                  " WHERE InvoiceID = ? ";

                cmd.CommandType = CommandType.Text;
              
                cmd.Parameters.AddWithValue("DueAmount", _PrincipalAmount);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Today.Date);
              
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_EPSCollection VALUES(?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _TranID);
                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("InstallmentNo", _InstallmentNo);
                cmd.Parameters.AddWithValue("EPSCustomerID", _EPSCustomerID);
                cmd.Parameters.AddWithValue("PrincipalAmount", _PrincipalAmount);
                cmd.Parameters.AddWithValue("InterestAmount", _InterestAmount);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateIsDue()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_EPSSalesDetail SET IsDue=1, IsEarlyClose=? where OrderID=? and InstallmentNo=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsEarlyClose", _nIsEarlyClose);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("InstallmentNo", _InstallmentNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateClosingBalance(double _ClosingBalance)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_EPSSalesDetail SET ClosingBalance=ClosingBalance-? where OrderID=? and InstallmentNo=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ClosingBalance", _ClosingBalance);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("InstallmentNo", _InstallmentNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

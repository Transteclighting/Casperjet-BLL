// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 23, 2014
// Time :  11:44 AM
// Description: Class for ConsumerBalanceTran.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class.BasicData;
using CJ.Class;

namespace CJ.Class.POS
{
    public class ConsumerBalanceTran
    {
        private int _nBalanceTranID;
        private int _nConsumerID;
        private int _nCustomerID;
        private Dictionary.ConsumerAdvancePaymentTranType _nTranType;
        private Dictionary.TransectionSide _nTranSide;
        private string _sAdvancePaymentNo;
        private string _sInvoiceNo;
        private string _sPurpose;
        private int _nProductID;
        private Dictionary.ConsumerAdvancePaymentMode _nPaymentMode;
        private string _sRemarks;
        private int _nIsUpload;
        private int _nCreateUserID;
        private object _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        private int _nBankID;
        private int _nPOSMachineID;
        private int _nCardType;
        private int _nCardCategory;
        private string _InstrumentNo;
        private object _InstrumentDate;
        private int _nJobID;
        private string _sAdvanceStatus;
        private object _dAdjustDate;

        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }
        public int POSMachineID
        {
            get { return _nPOSMachineID; }
            set { _nPOSMachineID = value; }
        }
        
        public int CardType
        {
            get { return _nCardType; }
            set { _nCardType = value; }
        }
        public int CardCategory
        {
            get { return _nCardCategory; }
            set { _nCardCategory = value; }
        }
        public string InstrumentNo
        {
            get { return _InstrumentNo; }
            set { _InstrumentNo = value.Trim(); }
        }
        public object InstrumentDate
        {
            get { return _InstrumentDate; }
            set { _InstrumentDate = value; }
        }

        private string _sApprovalNo;
        public string ApprovalNo
        {
            get { return _sApprovalNo; }
            set { _sApprovalNo = value; }
        }


        private int _IsEMI;
        public int IsEMI
        {
            get { return _IsEMI; }
            set { _IsEMI = value; }
        }
        private int _NoOfInstallment;
        public int NoOfInstallment
        {
            get { return _NoOfInstallment; }
            set { _NoOfInstallment = value; }
        }


        public int BalanceTranID
        {
            get { return _nBalanceTranID; }
            set { _nBalanceTranID = value; }
        }
        public int ConsumerID
        {
            get { return _nConsumerID; }
            set { _nConsumerID = value; }
        }
        public string BankName { get; set; }
        public string PaymentModeName { get; set; }
        public string CardTypeName { get; set; }
        public string POSMachin { get; set; }
        public string CardCategoryName { get; set; }
        public string IsEMIName { get; set; }
        private int _nSalesType;
        public int SalesType
        {
            get { return _nSalesType; }
            set { _nSalesType = value; }
        }
        public string PaymentDetail { get; set; }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public Dictionary.ConsumerAdvancePaymentTranType TranType
        {
            get { return _nTranType; }
            set { _nTranType = value; }
        }
        public Dictionary.TransectionSide TranSide
        {
            get { return _nTranSide; }
            set { _nTranSide = value; }
        }
        public string AdvancePaymentNo
        {
            get { return _sAdvancePaymentNo; }
            set { _sAdvancePaymentNo = value; }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        public string Purpose
        {
            get { return _sPurpose; }
            set { _sPurpose = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        private int _nAdvancePaymentMode;
        public int AdvancePaymentMode
        {
            get { return _nAdvancePaymentMode; }
            set { _nAdvancePaymentMode = value; }
        }
        public Dictionary.ConsumerAdvancePaymentMode PaymentMode
        {
            get { return _nPaymentMode; }
            set { _nPaymentMode = value; }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        public int IsUpload
        {
            get { return _nIsUpload; }
            set { _nIsUpload = value; }
        }

        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        public object CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        private double _Amount;
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        private string _sConsumerCode;
        public string ConsumerCode
        {
            get { return _sConsumerCode; }
            set { _sConsumerCode = value; }
        }
        private string _sConsumerName;
        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value; }
        }
        private string _sAddress;
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }
        private string _sContactNo;
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value; }
        }

        private double _ReceiveAmount;
        public double ReceiveAmount
        {
            get { return _ReceiveAmount; }
            set { _ReceiveAmount = value; }
        }
        private double _AdjustAmount;
        public double AdjustAmount
        {
            get { return _AdjustAmount; }
            set { _AdjustAmount = value; }
        }
        private double _Balance;
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        private string _sJobNo;
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
        }

        public string AdvanceStatus
        {
            get { return _sAdvanceStatus; }
            set { _sAdvanceStatus = value; }
        }

        public object AdjustDate
        {
            get { return _dAdjustDate; }
            set { _dAdjustDate = value; }
        }

        public void Add(bool IsTrue, bool UpdateNextNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxBalanceTranID = 0;

            try
            {
                sSql = "SELECT MAX([BalanceTranID]) FROM t_ConsumerBalanceTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBalanceTranID = 1;
                }
                else
                {
                    nMaxBalanceTranID = Convert.ToInt32(maxID) + 1;
                }
                if (IsTrue)
                {
                    _nBalanceTranID = nMaxBalanceTranID;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_ConsumerBalanceTran (BalanceTranID,ConsumerID,CustomerID,TranType, TranSide, " +
                       "AdvancePaymentNo,InvoiceNo,Amount, Purpose,ProductID,PaymentMode,Remarks,IsUpload,CreateUserID, "+ 
                       "CreateDate,InstrumentNo,InstrumentDate,BankID,CardType,POSMachineID,CardCategory,ApprovalNo,IsEMI,NoOfInstallment)  " +
                       "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BalanceTranID", _nBalanceTranID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("AdvancePaymentNo", _sAdvancePaymentNo);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Purpose", _sPurpose);
                if (_nProductID != -1)
                {
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductID", null);
                }
                cmd.Parameters.AddWithValue("PaymentMode", _nPaymentMode);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsUpload", _nIsUpload);

                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                if (Convert.ToInt32(_nPaymentMode) == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", Convert.ToDateTime(_InstrumentDate));
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                cmd.Parameters.AddWithValue("BankID", _nBankID); 
                cmd.Parameters.AddWithValue("CardType", _nCardType);
                cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);

                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("IsEMI", _IsEMI);
                cmd.Parameters.AddWithValue("NoOfInstallment", _NoOfInstallment);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (IsTrue)
                {
                    if (UpdateNextNo)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextNo set NextAdvancePaymentNo = NextAdvancePaymentNo + 1";
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    SystemInfo _oSystemInfo = new SystemInfo();
                    _oSystemInfo.Refresh();
                    DataTran _oDataTran = new DataTran();
                    _oDataTran.TableName = "t_ConsumerBalanceTran";
                    _oDataTran.DataID = _nBalanceTranID;
                    _oDataTran.WarehouseID = _oSystemInfo.WarehouseID;
                    _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    _oDataTran.BatchNo = 0;
                    _oDataTran.CreateDate = Convert.ToDateTime(_oSystemInfo.OperationDate);
                    _oDataTran.AddForTDPOS();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AddForRT(bool IsTrue, bool UpdateNextNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxBalanceTranID = 0;

            try
            {
                sSql = "SELECT MAX([BalanceTranID]) FROM t_ConsumerBalanceTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBalanceTranID = 1;
                }
                else
                {
                    nMaxBalanceTranID = Convert.ToInt32(maxID) + 1;
                }
                if (IsTrue)
                {
                    _nBalanceTranID = nMaxBalanceTranID;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_ConsumerBalanceTran (BalanceTranID,ConsumerID,CustomerID,TranType, TranSide, " +
                       "AdvancePaymentNo,InvoiceNo,Amount, Purpose,ProductID,PaymentMode,Remarks,IsUpload,CreateUserID, " +
                       "CreateDate,InstrumentNo,InstrumentDate,BankID,CardType,POSMachineID,CardCategory,ApprovalNo,IsEMI,NoOfInstallment,WarehouseID)  " +
                       "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BalanceTranID", _nBalanceTranID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("AdvancePaymentNo", _sAdvancePaymentNo);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Purpose", _sPurpose);
                if (_nProductID != -1)
                {
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductID", null);
                }
                cmd.Parameters.AddWithValue("PaymentMode", _nPaymentMode);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsUpload", _nIsUpload);

                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                if (Convert.ToInt32(_nPaymentMode) == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", Convert.ToDateTime(_InstrumentDate));
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("CardType", _nCardType);
                cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("IsEMI", _IsEMI);
                cmd.Parameters.AddWithValue("NoOfInstallment", _NoOfInstallment);
                cmd.Parameters.AddWithValue("WarehouseID", Utility.WarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (IsTrue)
                {
                    if (UpdateNextNo)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_Showroom set NextAdvancePaymentNo = NextAdvancePaymentNo + 1 where WarehouseID=" + Utility.WarehouseID + "";
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void AddForWeb(bool IsTrue, bool UpdateNextNo,int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "insert into t_ConsumerBalanceTran (BalanceTranID,ConsumerID,CustomerID,TranType, TranSide, " +
                       "AdvancePaymentNo,InvoiceNo,Amount, Purpose,ProductID,PaymentMode,Remarks,IsUpload,CreateUserID, "+
                       "CreateDate,InstrumentNo,InstrumentDate,BankID,CardType,POSMachineID,CardCategory,ApprovalNo, "+
                       "IsEMI,NoOfInstallment,WarehouseID)  " +
                       "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BalanceTranID", _nBalanceTranID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("AdvancePaymentNo", _sAdvancePaymentNo);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Purpose", _sPurpose);
                if (_nProductID != -1)
                {
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductID", null);
                }
                cmd.Parameters.AddWithValue("PaymentMode", _nPaymentMode);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsUpload", _nIsUpload);

                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                if (Convert.ToInt32(_nPaymentMode) == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", Convert.ToDateTime(_InstrumentDate));
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("CardType", _nCardType);
                cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);

                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("IsEMI", _IsEMI);
                cmd.Parameters.AddWithValue("NoOfInstallment", _NoOfInstallment);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (IsTrue)
                {
                    if (UpdateNextNo)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextNo set NextAdvancePaymentNo = NextAdvancePaymentNo + 1";
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public void AddAdvance(bool IsTrue, bool UpdateNextNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxBalanceTranID = 0;

            try
            {
                sSql = "SELECT MAX([BalanceTranID]) FROM t_ConsumerBalanceTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBalanceTranID = 1;
                }
                else
                {
                    nMaxBalanceTranID = Convert.ToInt32(maxID) + 1;
                }
                if (IsTrue)
                {
                    _nBalanceTranID = nMaxBalanceTranID;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "Insert into t_ConsumerBalanceTran (BalanceTranID,ConsumerID,CustomerID,TranType, TranSide, " +
                       "AdvancePaymentNo,InvoiceNo,Amount, Purpose,ProductID,PaymentMode,Remarks,IsUpload, " +
                       "CreateUserID,CreateDate,InstrumentNo,InstrumentDate,BankID,CardType, "+
                       "POSMachineID,CardCategory,ApprovalNo,IsEMI,NoOfInstallment)  " +
                       "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BalanceTranID", _nBalanceTranID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("AdvancePaymentNo", _sAdvancePaymentNo);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Purpose", _sPurpose);
                if (_nProductID != -1)
                {
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductID", null);
                }
                cmd.Parameters.AddWithValue("PaymentMode", _nAdvancePaymentMode);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsUpload", _nIsUpload);

                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                try
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", Convert.ToDateTime(_InstrumentDate));
                }
                catch
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("CardType", _nCardType);
                cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("IsEMI", _IsEMI);
                cmd.Parameters.AddWithValue("NoOfInstallment", _NoOfInstallment);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (IsTrue)
                {
                    if (UpdateNextNo)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_NextNo set NextAdvancePaymentNo = NextAdvancePaymentNo + 1";
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                    SystemInfo oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();
                    DataTran oDataTran = new DataTran
                    {
                        TableName = "t_ConsumerBalanceTran",
                        DataID = _nBalanceTranID,
                        WarehouseID = oSystemInfo.WarehouseID,
                        TransferType = (int) Dictionary.DataTransferType.Add,
                        IsDownload = (int) Dictionary.IsDownload.No,
                        BatchNo = 0,
                        CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate)
                    };
                    oDataTran.AddForTDPOS();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AddAdvancePOSRT(bool IsTrue, bool UpdateNextNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxBalanceTranID = 0; 

            try
            {
                sSql = "SELECT MAX([BalanceTranID]) FROM t_ConsumerBalanceTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBalanceTranID = 1;
                }
                else
                {
                    nMaxBalanceTranID = Convert.ToInt32(maxID) + 1;
                }
                if (IsTrue)
                {
                    _nBalanceTranID = nMaxBalanceTranID;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "Insert into t_ConsumerBalanceTran (BalanceTranID,ConsumerID,CustomerID,TranType, TranSide, " +
                       "AdvancePaymentNo,InvoiceNo,Amount, Purpose,ProductID,PaymentMode,Remarks,IsUpload, " +
                       "CreateUserID,CreateDate,InstrumentNo,InstrumentDate,BankID,CardType, " +
                       "POSMachineID,CardCategory,ApprovalNo,IsEMI,NoOfInstallment,WarehouseID)  " +
                       "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BalanceTranID", _nBalanceTranID);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("AdvancePaymentNo", _sAdvancePaymentNo);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Purpose", _sPurpose);
                if (_nProductID != -1)
                {
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductID", null);
                }
                cmd.Parameters.AddWithValue("PaymentMode", _nAdvancePaymentMode);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsUpload", _nIsUpload);

                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                try
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", Convert.ToDateTime(_InstrumentDate));
                }
                catch
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("CardType", _nCardType);
                cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("IsEMI", _IsEMI);
                cmd.Parameters.AddWithValue("NoOfInstallment", _NoOfInstallment);
                cmd.Parameters.AddWithValue("WarehouseID", Utility.WarehouseID);
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (IsTrue)
                {
                    if (UpdateNextNo)
                    {
                        cmd = DBController.Instance.GetCommand();
                        cmd.CommandText = "update t_Showroom set NextAdvancePaymentNo = NextAdvancePaymentNo + 1 Where WarehouseId = (Select WarehouseId from t_UserMapForPOS Where UserId = "+Utility.UserId+")";
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
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
                sSql = "Update t_ConsumerBalanceTran Set ConsumerID=?,CustomerID=?,TranType=?,TranSide=?,Amount=?, Purpose=?,ProductID=?, " +
                       "PaymentMode=?,Remarks=?,UpdateUserID=?,UpdateDate=?,InstrumentNo=?,InstrumentDate=?,BankID=?,CardType=?,POSMachineID=?,CardCategory=?,ApprovalNo=?,IsEMI=?,NoOfInstallment=? "+
                       "Where BalanceTranID = ? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Purpose", _sPurpose);
                if (_nProductID != -1)
                {
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductID", null);
                }
                cmd.Parameters.AddWithValue("PaymentMode", _nAdvancePaymentMode);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                if (Convert.ToInt32(_nPaymentMode) == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", Convert.ToDateTime(_InstrumentDate));
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }

                
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("CardType", _nCardType);
                cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("IsEMI", _IsEMI);
                cmd.Parameters.AddWithValue("NoOfInstallment", _NoOfInstallment);



                cmd.Parameters.AddWithValue("BalanceTranID", _nBalanceTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_ConsumerBalanceTran Set ConsumerID=?,CustomerID=?,TranType=?,TranSide=?,Amount=?, Purpose=?,ProductID=?, " +
                       "PaymentMode=?,Remarks=?,UpdateUserID=?,UpdateDate=?,InstrumentNo=?,InstrumentDate=?,BankID=?,CardType=?,POSMachineID=?,CardCategory=?,ApprovalNo=?,IsEMI=?,NoOfInstallment=? " +
                       "Where BalanceTranID = ? and WarehouseID=" + Utility.WarehouseID + " ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Purpose", _sPurpose);
                if (_nProductID != -1)
                {
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ProductID", null);
                }
                cmd.Parameters.AddWithValue("PaymentMode", _nAdvancePaymentMode);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                if (Convert.ToInt32(_nPaymentMode) == 2)
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", Convert.ToDateTime(_InstrumentDate));
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }


                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("CardType", _nCardType);
                cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("IsEMI", _IsEMI);
                cmd.Parameters.AddWithValue("NoOfInstallment", _NoOfInstallment);



                cmd.Parameters.AddWithValue("BalanceTranID", _nBalanceTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddConsumerBalance()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "insert into t_ConsumerBalance (ConsumerID,CustomerID,Amount) VALUES(?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsuerID", _nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddConsumerBalanceWEB(int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "insert into t_ConsumerBalance (ConsumerID,CustomerID,Amount,WarehouseID) VALUES(?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsuerID", _nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("WarehouseID", nWHID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateConsumerBalance(bool IsTrue, double Amount)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (IsTrue)
                {
                    sSql = "Update t_ConsumerBalance SET Amount = Amount + ? WHERE ConsumerID=? AND CustomerID=? ";
                }
                else
                {
                    sSql = "Update t_ConsumerBalance SET Amount = Amount - ? WHERE ConsumerID=? AND CustomerID=? ";
                }

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Amount", Amount);

                cmd.Parameters.AddWithValue("ConsuerID", _nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateConsumerBalanceWEB(bool IsTrue, double Amount,int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (IsTrue)
                {
                    sSql = "Update t_ConsumerBalance SET Amount = Amount + ? WHERE ConsumerID=? AND CustomerID=? and WarehouseID=" + nWHID + " ";
                }
                else
                {
                    sSql = "Update t_ConsumerBalance SET Amount = Amount - ? WHERE ConsumerID=? AND CustomerID=? and WarehouseID=" + nWHID + " ";
                }

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Amount", Amount);
                cmd.Parameters.AddWithValue("ConsuerID", _nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckConsumerBalance()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            try
            {
                sSql = "Select * from t_ConsumerBalance Where ConsumerID=? AND CustomerID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsuerID", _nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);

                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    nCount++;
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Select * from t_ConsumerBalanceTran Where BalanceTranID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BalanceTranID", _nBalanceTranID);
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nIsUpload = int.Parse(reader["IsUpload"].ToString());
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public double GetAdvanceAmountByDate(DateTime dFromDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime dToDate = dFromDate.AddDays(1);
            string sSql = "";
            double _Amt = 0;
            try
            {
                sSql = "Select sum(Amount) as Amount from t_ConsumerBalanceTran Where TranType=1 and " +
                "CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate < '" + dToDate + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        _Amt = Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else
                    {
                        _Amt = 0;
                    }
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amt;

        }

        public double GetAdvanceAmountByDateRT(DateTime dFromDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime dToDate = dFromDate.AddDays(1);
            string sSql = "";
            double _Amt = 0;
            try
            {
                sSql = "Select sum(Amount) as Amount from (Select a.* From t_ConsumerBalanceTran a,t_RetailConsumer b " +
                "where a.CustomerID=b.CustomerID and a.ConsumerID=b.ConsumerID and b.WarehouseID=" + Utility.WarehouseID + " " +
                ") A Where TranType=1 and " +
                "CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate < '" + dToDate + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        _Amt = Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else
                    {
                        _Amt = 0;
                    }
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amt;

        }
        public double GetAdvanceAmountByDateNew(DateTime dFromDate, int nPaymentMode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime dToDate = dFromDate.AddDays(1);
            string sSql = "";
            double _Amt = 0;
            try
            {
                sSql = "Select sum(Amount) as Amount from t_ConsumerBalanceTran Where TranType=1 and " +
                "CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate < '" + dToDate + "' and PaymentMode=" + nPaymentMode + "";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        _Amt = Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else
                    {
                        _Amt = 0;
                    }
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amt;

        }
        public double GetAdvanceAmountByDateHO(DateTime dFromDate, int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime dToDate = dFromDate.AddDays(1);
            string sSql = "";
            double _Amt = 0;
            try
            {
                sSql = "Select isnull(SUM(Amount),0) as Amount from t_ConsumerBalanceTran Where TranType=1 and CustomerID=" + nCustomerID + " and " +
                "CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate < '" + dToDate + "' ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        _Amt = Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else
                    {
                        _Amt = 0;
                    }
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amt;

        }
        public int GetNextAPNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nNextAPNo = 0;
            try
            {
                sSql = "Select * from t_NextNo ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nNextAPNo = int.Parse(reader["NextAdvancePaymentNo"].ToString());
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nNextAPNo;

        }
        public bool CheckConsumerBalanceTran()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            try
            {
                sSql = "select * from t_ConsumerBalanceTran Where BalanceTranID=? and ConsumerID=? and CustomerID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BalanceTranID", _nBalanceTranID);
                cmd.Parameters.AddWithValue("ConsumerID",_nConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);

                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }

        public double GetConsumerBalance()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "select a.ConsumerID, ConsumerCode,Amount from t_ConsumerBalance a, t_RetailConsumer b "+
                        "Where a.ConsumerID=b.ConsumerID and ConsumerCode=? ";
                cmd.Parameters.AddWithValue("ConsumerCode", _sConsumerCode);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerID = (int)reader["ConsumerID"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;

        }

        public double GetConsumerBalanceNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "select a.ConsumerID, ConsumerCode,sum(Amount) Amount  " +
                    "from t_ConsumerBalance a, t_RetailConsumer b  " +
                    "Where a.ConsumerID = b.ConsumerID and ConsumerCode = ? " +
                    "group by a.ConsumerID, ConsumerCode";


                cmd.Parameters.AddWithValue("ConsumerCode", _sConsumerCode);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerID = (int)reader["ConsumerID"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;

        }

        public double GetConsumerBalanceNewOther(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "select a.ConsumerID, ConsumerCode,sum(Amount) Amount  " +
                    "from t_ConsumerBalance a, t_RetailConsumer b  " +
                    "Where a.ConsumerID = b.ConsumerID and ConsumerCode = ? and a.CustomerID = " + nCustomerID + "  " +
                    "group by a.ConsumerID, ConsumerCode";


                cmd.Parameters.AddWithValue("ConsumerCode", _sConsumerCode);


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nConsumerID = (int)reader["ConsumerID"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;

        }

        public void AddAdvanceCSD(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxBalanceTranID = 0;

            try
            {
                sSql = "SELECT MAX([BalanceTranID]) FROM t_CSDCustomerBalanceTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBalanceTranID = 1;
                }
                else
                {
                    nMaxBalanceTranID = Convert.ToInt32(maxID) + 1;
                }
                if (IsTrue)
                {
                    _nBalanceTranID = nMaxBalanceTranID;
                }
                string sAdvancePaymentNo = "CSD-ADV-" + _nBalanceTranID.ToString("000000");
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "Insert into t_CSDCustomerBalanceTran (BalanceTranID,JobID,AdvancePaymentNo," +
                       "Amount, PaymentMode,Remarks, " +
                       "CreateUserID,CreateDate,InstrumentNo,InstrumentDate,BankID,CardType, " +
                       "POSMachineID,CardCategory,ApprovalNo,AdvanceStatus)  " +
                       "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BalanceTranID", _nBalanceTranID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("AdvancePaymentNo", sAdvancePaymentNo);
                cmd.Parameters.AddWithValue("Amount", _Amount);
               
                cmd.Parameters.AddWithValue("PaymentMode", _nAdvancePaymentMode);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                try
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", Convert.ToDateTime(_InstrumentDate));
                }
                catch
                {
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                }
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("CardType", _nCardType);
                cmd.Parameters.AddWithValue("POSMachineID", _nPOSMachineID);
                cmd.Parameters.AddWithValue("CardCategory", _nCardCategory);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("AdvanceStatus", _nTranType);

                _sAdvancePaymentNo = sAdvancePaymentNo;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public int AddBillAdvance(string _sBillNo,DateTime _dBillDate, int CreateUserID, double fAmount)
        {
            int nMaxBillID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BillID]) FROM t_CSDJobBill";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBillID = 1;
                }
                else
                {
                    nMaxBillID = Convert.ToInt32(maxID) + 1;
                }
                
                sSql = "INSERT INTO t_CSDJobBill (BillID, BillNo, BillDate, JobID, MaterialCharge, ActualMatCharge, InspectionCharge, ActualInsCharge, ServiceCharge, ActualSerCharge,InstallationCharge,ActualInstallationCharge,OtherCharge, SPDiscount, SCDiscount, InTranportationCharge, OutTranportationCharge, TotalBill, CurrentPayable, ReceivedAmount, UserID, Remarks, BillStatus,DeliveryLocation,AdvanceAmount,AdjustAmount) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BillID", nMaxBillID);
                cmd.Parameters.AddWithValue("BillNo", _sBillNo);
                cmd.Parameters.AddWithValue("BillDate", _dBillDate);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("MaterialCharge", 0);
                cmd.Parameters.AddWithValue("ActualMatCharge", 0);
                cmd.Parameters.AddWithValue("InspectionCharge", 0);
                cmd.Parameters.AddWithValue("ActualInsCharge", 0);
                cmd.Parameters.AddWithValue("ServiceCharge", 0);
                cmd.Parameters.AddWithValue("ActualSerCharge", 0);
                cmd.Parameters.AddWithValue("InstallationCharge", 0);
                cmd.Parameters.AddWithValue("ActualInstallationCharge", 0);
                cmd.Parameters.AddWithValue("OtherCharge", 0);
                cmd.Parameters.AddWithValue("SPDiscount", 0);
                cmd.Parameters.AddWithValue("SCDiscount", 0);
                cmd.Parameters.AddWithValue("InTranportationCharge", 0);
                cmd.Parameters.AddWithValue("OutTranportationCharge", 0);
                cmd.Parameters.AddWithValue("TotalBill", 0);
                cmd.Parameters.AddWithValue("CurrentPayable", 0);
                cmd.Parameters.AddWithValue("ReceivedAmount", 0);
                cmd.Parameters.AddWithValue("UserID", CreateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("BillStatus", (int)Dictionary.CSDBillStatus.Paid);
                cmd.Parameters.AddWithValue("DeliveryLocation", Utility.JobLocation);
                cmd.Parameters.AddWithValue("AdvanceAmount", fAmount);
                cmd.Parameters.AddWithValue("AdjustAmount", 0);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return nMaxBillID;
        }
        public void AddBillHistoryAdvance(int nBillID,DateTime dBillDate, string sMoneyReceiptNo, double fAmount,int nInstrumentType, string sInsNo, object sInsDate, int nBankID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_CSDJobBillHistory (BillID, ReceiveableAmount, SCDiscount, SPDiscount, NetPayable, " +
                " ReceiveAmount, ReceiveDate, InstrumentType, InstrumentDate, BankID, InstrumentNo, BillRemarks, MoneyReceiptNo, " +
                " IsPending,ReceiveType,IsAdvance) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BillID", nBillID);
                cmd.Parameters.AddWithValue("ReceiveableAmount", 0);
                cmd.Parameters.AddWithValue("SCDiscount", 0);
                cmd.Parameters.AddWithValue("SPDiscount", 0);
                cmd.Parameters.AddWithValue("NetPayable", fAmount);
                cmd.Parameters.AddWithValue("ReceiveAmount", fAmount);
                cmd.Parameters.AddWithValue("ReceiveDate", dBillDate); 
                cmd.Parameters.AddWithValue("InstrumentType", nInstrumentType);
                cmd.Parameters.AddWithValue("InstrumentDate", Convert.ToDateTime(sInsDate));
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("InstrumentNo", sInsNo);
                cmd.Parameters.AddWithValue("BillRemarks", "");
                cmd.Parameters.AddWithValue("MoneyReceiptNo", sMoneyReceiptNo);
                cmd.Parameters.AddWithValue("IsPending", (int)Dictionary.YesOrNoStatus.NO);
                cmd.Parameters.AddWithValue("ReceiveType", (int)Dictionary.CSDJobBillReceiveType.Regular_Receive);
                cmd.Parameters.AddWithValue("IsAdvance", 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


    }
    public class ConsumerBalanceTrans : CollectionBase
    {
        public ConsumerBalanceTran this[int i]
        {
            get { return (ConsumerBalanceTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ConsumerBalanceTran oConsumerBalanceTran)
        {
            InnerList.Add(oConsumerBalanceTran);
        }
        public void Refresh(String sConsumerCode, String sConsumerName, String sContactNo, int nBalance)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select a.ConsumerID, a.CustomerID, ConsumerCode, ConsumerName, Amount, Address, CellNo from t_ConsumerBalance a, " +
                          "t_RetailConsumer b Where a.ConsumerID=b.ConsumerID ";
            
            if(sConsumerCode!="")
            {
                sSql = sSql + " AND ConsumerCode='" + sConsumerCode + "'";
            }
            if (sConsumerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sConsumerName + "%'";
            }
            if (sContactNo != "")
            {
                sSql = sSql + " AND CellNo like '%" + sContactNo + "%'";
            }
            if (nBalance > 0)
            {
                if (nBalance == 1)
                {
                    sSql = sSql + " AND Amount > 0 ";
                }
                else
                {
                    sSql = sSql + " AND Amount = 0 ";
                }
            }

            sSql = sSql + "Order by a.ConsumerID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();

                    oConsumerBalanceTran.ConsumerID = (int)reader["ConsumerID"];
                    oConsumerBalanceTran.CustomerID = (int)reader["CustomerID"];
                    oConsumerBalanceTran.ConsumerCode = (string)reader["ConsumerCode"];
                    oConsumerBalanceTran.ConsumerName = (string)reader["ConsumerName"];
                    oConsumerBalanceTran.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oConsumerBalanceTran.Address = (string)reader["Address"];
                    oConsumerBalanceTran.ContactNo = (string)reader["CellNo"];

                    InnerList.Add(oConsumerBalanceTran);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshPOSRT(String sConsumerCode, String sConsumerName, String sContactNo, int nBalance)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select b.SalesType,a.ConsumerID, a.CustomerID, ConsumerCode, ConsumerName, Amount, Address, CellNo from t_ConsumerBalance a, " +
                          "t_RetailConsumer b Where a.ConsumerID=b.ConsumerID and a.WarehouseID = b.WarehouseId and a.WarehouseId =" + Utility.WarehouseID;

            if (sConsumerCode != "")
            {
                sSql = sSql + " AND ConsumerCode='" + sConsumerCode + "'";
            }
            if (sConsumerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sConsumerName + "%'";
            }
            if (sContactNo != "")
            {
                sSql = sSql + " AND CellNo like '%" + sContactNo + "%'";
            }
            if (nBalance > 0)
            {
                if (nBalance == 1)
                {
                    sSql = sSql + " AND Amount > 0 ";
                }
                else
                {
                    sSql = sSql + " AND Amount = 0 ";
                }
            }

            sSql = sSql + "Order by a.ConsumerID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();

                    oConsumerBalanceTran.ConsumerID = (int)reader["ConsumerID"];
                    oConsumerBalanceTran.CustomerID = (int)reader["CustomerID"];
                    oConsumerBalanceTran.SalesType = (int)reader["SalesType"];
                    oConsumerBalanceTran.ConsumerCode = (string)reader["ConsumerCode"];
                    oConsumerBalanceTran.ConsumerName = (string)reader["ConsumerName"];
                    oConsumerBalanceTran.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oConsumerBalanceTran.Address = (string)reader["Address"];
                    oConsumerBalanceTran.ContactNo = (string)reader["CellNo"];

                    InnerList.Add(oConsumerBalanceTran);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshTran(int nConsumerID, int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Balance = 0;

            //string sSql = " select BalanceTranID,IsNull(AdvancePaymentNo,'') as AdvancePaymentNo,Amount,InvoiceNo,ConsumerID, CustomerID, " +
            //              " IsNull(Purpose,'') as Purpose,a.ProductID, IsNull(('['+ProductCode+'] '+ProductName),'') as ProductName, "+
            //              " IsNull(PaymentMode,'') as PaymentMode, IsNull(Remarks,'') as Remarks,IsUpload, CreateDate, TranType,  "+
            //              " TranSide from t_ConsumerBalanceTran a Left Outer Join t_Product b "+
            //              " ON a.ProductID=b.ProductID Where ConsumerID=" + nConsumerID + " and CustomerID=" + nCustomerID + " ";

            string sSql = "Select main.*, " +
                          "case when PaymentMode=2 then CardCategory+'# '+left(InstrumentNo,4)+'******'+right(InstrumentNo,4)+' | '+BankName+ " +
                          "case when IsEMI='Yes' then ' | EMI: '+cast(NoOfInstallment as varchar)+' Months' else '' end " +
                          "when isnull(InvoiceNo,'')<>'' then '' else PaymentModeName end as PaymentDetail From  " +
                          "( " +
                          "Select BalanceTranID,IsNull(AdvancePaymentNo,'') as AdvancePaymentNo,Amount,InvoiceNo,ConsumerID, CustomerID,  " +
                          "IsNull(Purpose,'') as Purpose,isnull(a.ProductID,-1) ProductID, IsNull(('['+ProductCode+'] '+ProductName),'') as ProductName, a.PaymentMode, " +
                          "IsNull(PaymentModeName,'') as PaymentModeName, IsNull(Remarks,'') as Remarks,IsUpload, a.CreateDate, TranType,   " +
                          "TranSide,isnull(c.Name,'')  as BankName,case when CardType=1 then 'VISA' " +
                          "when CardType=2 then 'MASTER' " +
                          "when CardType=3 then 'AMEX' " +
                          "when CardType=4 then 'NEXUS' " +
                          "when CardType=5 then 'JCB' " +
                          "else '' end as CardType, " +
                          "isnull(d.AssetName,'')  as POSMachin, " +
                          "case when CardCategory=1 then 'DebitCard' when CardCategory=2 then 'CreditCard' else '' end as CardCategory, " +
                          "isnull(ApprovalNo,'') ApprovalNo,case when a.IsEMI=1 then 'Yes' when a.IsEMI=0 then 'No' else '' end as IsEMI, " +
                          "isnull(NoOfInstallment,'') NoOfInstallment,isnull(InstrumentNo,'') InstrumentNo " +
                          "from t_ConsumerBalanceTran a  " +
                          "Left outer Join t_Product b ON a.ProductID=b.ProductID  " +
                          "Left outer Join t_Bank c on a.BankID=c.BankID " +
                          "Left outer Join t_ShowroomAsset d on a.POSMachineID=d.AssetID " +
                          "Left outer Join t_PaymentMode e on a.PaymentMode=e.PaymentModeID " +
                          "Where ConsumerID= " + nConsumerID + " and CustomerID= " + nCustomerID + "  " +
                          ") Main order by CreateDate";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();

                    oConsumerBalanceTran.BalanceTranID = (int)reader["BalanceTranID"];
                    oConsumerBalanceTran.AdvancePaymentNo = (string)reader["AdvancePaymentNo"];
                    oConsumerBalanceTran.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oConsumerBalanceTran.InvoiceNo = (string)reader["InvoiceNo"];
                    oConsumerBalanceTran.ConsumerID = (int)reader["ConsumerID"];
                    oConsumerBalanceTran.CustomerID = (int)reader["CustomerID"];
                    oConsumerBalanceTran.Purpose = (string)reader["Purpose"];
                    if (reader["ProductID"] != DBNull.Value)
                    {
                        oConsumerBalanceTran.ProductID = (int)reader["ProductID"];
                    }
                    else
                    {
                        oConsumerBalanceTran.ProductID = 0;
                    }
                    oConsumerBalanceTran.ProductName = (string)reader["ProductName"];
                    oConsumerBalanceTran.PaymentModeName = (string)reader["PaymentModeName"];
                    //oConsumerBalanceTran.PaymentMode = (Dictionary.ConsumerAdvancePaymentMode)reader["PaymentMode"];
                    oConsumerBalanceTran.Remarks = (string)reader["Remarks"];
                    oConsumerBalanceTran.IsUpload = (int)reader["IsUpload"];
                    oConsumerBalanceTran.CreateDate = Convert.ToDateTime(reader["CreateDate"]).ToString("dd-MMM-yyyy");
                    oConsumerBalanceTran.TranType = (Dictionary.ConsumerAdvancePaymentTranType)reader["TranType"];
                    oConsumerBalanceTran.TranSide = (Dictionary.TransectionSide)reader["TranSide"];
                   
                    oConsumerBalanceTran.BankName = (string)reader["BankName"];
                    oConsumerBalanceTran.CardTypeName = (string)reader["CardType"];
                    oConsumerBalanceTran.POSMachin = (string)reader["POSMachin"];
                    oConsumerBalanceTran.CardCategoryName = (string)reader["CardCategory"];
                    oConsumerBalanceTran.IsEMIName = (string)reader["IsEMI"];
                    oConsumerBalanceTran.NoOfInstallment = (int)reader["NoOfInstallment"];
                    oConsumerBalanceTran.InstrumentNo = (string)reader["InstrumentNo"];
                    oConsumerBalanceTran.PaymentDetail = (string)reader["PaymentDetail"];
                    

                    if (Convert.ToInt32(reader["TranSide"]) == (int)Dictionary.TransectionSide.CREDIT)
                    {
                        oConsumerBalanceTran.ReceiveAmount = Convert.ToDouble(reader["Amount"].ToString());
                        oConsumerBalanceTran.AdjustAmount = 0;
                        _Balance = _Balance + oConsumerBalanceTran.ReceiveAmount;
                    }
                    else
                    {
                        oConsumerBalanceTran.ReceiveAmount = 0;
                        oConsumerBalanceTran.AdjustAmount = Convert.ToDouble(reader["Amount"].ToString());
                        _Balance = _Balance - oConsumerBalanceTran.AdjustAmount;
                    }
                    oConsumerBalanceTran.Balance = _Balance;
                    InnerList.Add(oConsumerBalanceTran);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshTranRT(int nConsumerID, int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Balance = 0;

            string sSql = "Select main.*, " +
                          "case when PaymentMode=2 then CardCategory+'# '+left(InstrumentNo,4)+'******'+right(InstrumentNo,4)+' | '+BankName+ " +
                          "case when IsEMI='Yes' then ' | EMI: '+cast(NoOfInstallment as varchar)+' Months' else '' end " +
                          "when isnull(InvoiceNo,'')<>'' then '' else PaymentModeName end as PaymentDetail From  " +
                          "( " +
                          "Select BalanceTranID,IsNull(AdvancePaymentNo,'') as AdvancePaymentNo,Amount,InvoiceNo,ConsumerID, CustomerID,  " +
                          "IsNull(Purpose,'') as Purpose,isnull(a.ProductID,-1) ProductID, IsNull(('['+ProductCode+'] '+ProductName),'') as ProductName, a.PaymentMode, " +
                          "IsNull(PaymentModeName,'') as PaymentModeName, IsNull(Remarks,'') as Remarks,IsUpload, a.CreateDate, TranType,   " +
                          "TranSide,isnull(c.Name,'')  as BankName,case when CardType=1 then 'VISA' " +
                          "when CardType=2 then 'MASTER' " +
                          "when CardType=3 then 'AMEX' " +
                          "when CardType=4 then 'NEXUS' " +
                          "when CardType=5 then 'JCB' " +
                          "else '' end as CardType, " +
                          "isnull(d.AssetName,'')  as POSMachin, " +
                          "case when CardCategory=1 then 'DebitCard' when CardCategory=2 then 'CreditCard' else '' end as CardCategory, " +
                          "isnull(ApprovalNo,'') ApprovalNo,case when a.IsEMI=1 then 'Yes' when a.IsEMI=0 then 'No' else '' end as IsEMI, " +
                          "isnull(NoOfInstallment,'') NoOfInstallment,isnull(InstrumentNo,'') InstrumentNo " +
                          "from t_ConsumerBalanceTran a  " +
                          "Left outer Join t_Product b ON a.ProductID=b.ProductID  " +
                          "Left outer Join t_Bank c on a.BankID=c.BankID " +
                          "Left outer Join t_ShowroomAsset d on a.POSMachineID=d.AssetID " +
                          "Left outer Join t_PaymentMode e on a.PaymentMode=e.PaymentModeID " +
                          "Where a.WarehouseID=" + Utility.WarehouseID + " and ConsumerID= " + nConsumerID + " and CustomerID= " + nCustomerID + "  " +
                          ") Main order by CreateDate";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();

                    oConsumerBalanceTran.BalanceTranID = (int)reader["BalanceTranID"];
                    oConsumerBalanceTran.AdvancePaymentNo = (string)reader["AdvancePaymentNo"];
                    oConsumerBalanceTran.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oConsumerBalanceTran.InvoiceNo = (string)reader["InvoiceNo"];
                    oConsumerBalanceTran.ConsumerID = (int)reader["ConsumerID"];
                    oConsumerBalanceTran.CustomerID = (int)reader["CustomerID"];
                    oConsumerBalanceTran.Purpose = (string)reader["Purpose"];
                    if (reader["ProductID"] != DBNull.Value)
                    {
                        oConsumerBalanceTran.ProductID = (int)reader["ProductID"];
                    }
                    else
                    {
                        oConsumerBalanceTran.ProductID = 0;
                    }
                    oConsumerBalanceTran.ProductName = (string)reader["ProductName"];
                    oConsumerBalanceTran.PaymentModeName = (string)reader["PaymentModeName"];
                    //oConsumerBalanceTran.PaymentMode = (Dictionary.ConsumerAdvancePaymentMode)reader["PaymentMode"];
                    oConsumerBalanceTran.Remarks = (string)reader["Remarks"];
                    oConsumerBalanceTran.IsUpload = (int)reader["IsUpload"];
                    oConsumerBalanceTran.CreateDate = Convert.ToDateTime(reader["CreateDate"]).ToString("dd-MMM-yyyy");
                    oConsumerBalanceTran.TranType = (Dictionary.ConsumerAdvancePaymentTranType)reader["TranType"];
                    oConsumerBalanceTran.TranSide = (Dictionary.TransectionSide)reader["TranSide"];

                    oConsumerBalanceTran.BankName = (string)reader["BankName"];
                    oConsumerBalanceTran.CardTypeName = (string)reader["CardType"];
                    oConsumerBalanceTran.POSMachin = (string)reader["POSMachin"];
                    oConsumerBalanceTran.CardCategoryName = (string)reader["CardCategory"];
                    oConsumerBalanceTran.IsEMIName = (string)reader["IsEMI"];
                    oConsumerBalanceTran.NoOfInstallment = (int)reader["NoOfInstallment"];
                    oConsumerBalanceTran.InstrumentNo = (string)reader["InstrumentNo"];
                    oConsumerBalanceTran.PaymentDetail = (string)reader["PaymentDetail"];


                    if (Convert.ToInt32(reader["TranSide"]) == (int)Dictionary.TransectionSide.CREDIT)
                    {
                        oConsumerBalanceTran.ReceiveAmount = Convert.ToDouble(reader["Amount"].ToString());
                        oConsumerBalanceTran.AdjustAmount = 0;
                        _Balance = _Balance + oConsumerBalanceTran.ReceiveAmount;
                    }
                    else
                    {
                        oConsumerBalanceTran.ReceiveAmount = 0;
                        oConsumerBalanceTran.AdjustAmount = Convert.ToDouble(reader["Amount"].ToString());
                        _Balance = _Balance - oConsumerBalanceTran.AdjustAmount;
                    }
                    oConsumerBalanceTran.Balance = _Balance;
                    InnerList.Add(oConsumerBalanceTran);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshCSD(string sBranType, bool isCreateDateRangeChecked,DateTime dtCreateFromDate, DateTime dtCreateToDate,string sJobNo, String sAdvanceNo, String sConsumerName, String sContactNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            double _Balance = 0;
            string sSql = "select A.JobID,JobNo,AdvancePaymentNo,InstrumentDate as ReceiveDate,CustomerName,Amount,IsNULL(AdjustAmount,0) AdjustAmount,PaymentMode,CustomerAddress,(case when AdvanceStatus=1 then 'Advance' else 'Adjustment' end) as AdvanceStatus, " +
                          "MobileNo,B.ProductID,C.ProductName,PaymentModeName from t_CSDCustomerBalanceTran A, t_CSDJob B, t_Product C,t_PaymentMode D " +
                          "where A.JobID=B.JobID and B.ProductID=C.ProductID and A.PaymentMode=D.PaymentModeID";


            if (!isCreateDateRangeChecked)
            {
                sSql += " AND a.CreateDate BETWEEN'" + dtCreateFromDate + "'AND '" + dtCreateToDate + "' AND a.CreateDate < '" + dtCreateToDate + "'";
            }
            if (sJobNo != "")
            {
                sSql = sSql + " AND JobNo='" + sJobNo + "'";
            }
            if (sConsumerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sConsumerName + "%'";
            }
            if (sContactNo != "")
            {
                sSql = sSql + " AND MobileNo like '%" + sContactNo + "%'";
            }
            if (sAdvanceNo != "")
            {
                sSql = sSql + " AND AdvancePaymentNo like '%" + sAdvanceNo + "%'";
            }
            if (sBranType == "Samsung")
            {
                sSql += " and C.BrandID in (19,38) ";
            }
            else if (sBranType == "Other")
            {
                sSql += " and C.BrandID not in (19,38) ";
            }

            sSql = sSql + " Order by a.JobID,BalanceTranID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();
                    
                    oConsumerBalanceTran.JobNo = (string)reader["JobNo"];
                    oConsumerBalanceTran.AdvancePaymentNo = (string)reader["AdvancePaymentNo"];
                    oConsumerBalanceTran.ConsumerName = (string)reader["CustomerName"];
                    oConsumerBalanceTran.Address = (string)reader["CustomerAddress"];
                    oConsumerBalanceTran.ContactNo = (string)reader["MobileNo"];
                    oConsumerBalanceTran.InstrumentDate = Convert.ToDateTime(reader["ReceiveDate"]);
                    oConsumerBalanceTran.PaymentModeName = (string)reader["PaymentModeName"];
                    oConsumerBalanceTran.AdvanceStatus = (string)reader["AdvanceStatus"];
                    oConsumerBalanceTran.ReceiveAmount = Convert.ToDouble(reader["Amount"].ToString());
                    oConsumerBalanceTran.AdjustAmount = Convert.ToDouble(reader["AdjustAmount"].ToString());

                    _Balance = _Balance + oConsumerBalanceTran.ReceiveAmount - oConsumerBalanceTran.AdjustAmount;
                    oConsumerBalanceTran.Balance = _Balance;

                    InnerList.Add(oConsumerBalanceTran);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshTranCSD(string sAdvanceNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Balance = 0;

            //string sSql = " select BalanceTranID,IsNull(AdvancePaymentNo,'') as AdvancePaymentNo,Amount,InvoiceNo,ConsumerID, CustomerID, " +
            //              " IsNull(Purpose,'') as Purpose,a.ProductID, IsNull(('['+ProductCode+'] '+ProductName),'') as ProductName, "+
            //              " IsNull(PaymentMode,'') as PaymentMode, IsNull(Remarks,'') as Remarks,IsUpload, CreateDate, TranType,  "+
            //              " TranSide from t_ConsumerBalanceTran a Left Outer Join t_Product b "+
            //              " ON a.ProductID=b.ProductID Where ConsumerID=" + nConsumerID + " and CustomerID=" + nCustomerID + " ";

            string sSql = String.Format(@"Select main.*, IsNULL((case when PaymentMode=2 then 
                CardCategory+'# '+left(InstrumentNo,4)+'******'+right(InstrumentNo,4)+' | '+BankName+ 
                PaymentModeName  when PaymentMode in(15,23) then PaymentModeName +' | '+ InstrumentNo end),'') as PaymentDetail From  ( Select BalanceTranID,IsNull(AdvancePaymentNo,'') as AdvancePaymentNo,JobNo,Amount,IsNull(AdjustAmount,0) AdjustAmount,CustomerName,CustomerAddress,MobileNo,
                --isnull(a.ProductID,-1) ProductID, IsNull(('['+ProductCode+'] '+ProductName),'') as ProductName, 
                a.PaymentMode, IsNull(PaymentModeName,'') as PaymentModeName, IsNull(a.Remarks,'') as Remarks, a.CreateDate, 
                (case when AdvanceStatus=1 then 'Advance' else 'Adjustment' end) as AdvanceStatus,isnull(c.Name,'')  as BankName,
                case when CardType=1 then 'VISA' when CardType=2 then 'MASTER' when CardType=3 then 'AMEX' when CardType=4 then 'NEXUS' when CardType=5 then 'JCB' else '' end as CardType, isnull(d.AssetName,'')  as POSMachin, case when CardCategory=1 then 'DebitCard' when CardCategory=2 then 'CreditCard' else '' end as CardCategory, isnull(ApprovalNo,'') ApprovalNo,isnull(InstrumentNo,'') InstrumentNo,AdjustDate from t_CSDCustomerBalanceTran a  
                --Left outer Join t_Product b ON a.ProductID=b.ProductID  
                Left outer Join t_Bank c on a.BankID=c.BankID Left outer Join t_ShowroomAsset d on a.POSMachineID=d.AssetID 
                Left outer Join t_PaymentMode e on a.PaymentMode=e.PaymentModeID
                Left outer Join t_CSDJob f on a.JobID=f.JobID
                Where AdvancePaymentNo= '{0}'  ) Main order by CreateDate", sAdvanceNo);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ConsumerBalanceTran oConsumerBalanceTran = new ConsumerBalanceTran();

                    oConsumerBalanceTran.BalanceTranID = (int)reader["BalanceTranID"];
                    oConsumerBalanceTran.AdvancePaymentNo = (string)reader["AdvancePaymentNo"];
                    oConsumerBalanceTran.JobNo = (string)reader["JobNo"];
                    oConsumerBalanceTran.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oConsumerBalanceTran.ConsumerName= (string)reader["CustomerName"];
                    oConsumerBalanceTran.Address = (string)reader["CustomerAddress"];
                    oConsumerBalanceTran.ContactNo = (string)reader["MobileNo"];
                    oConsumerBalanceTran.PaymentModeName = (string)reader["PaymentModeName"];
                    //oConsumerBalanceTran.PaymentMode = (Dictionary.ConsumerAdvancePaymentMode)reader["PaymentMode"];
                    oConsumerBalanceTran.Remarks = (string)reader["Remarks"];
                    oConsumerBalanceTran.CreateDate = Convert.ToDateTime(reader["CreateDate"]).ToString("dd-MMM-yyyy");
                    //oConsumerBalanceTran.TranType = (Dictionary.ConsumerAdvancePaymentTranType)reader["AdvanceStatus"];
                    oConsumerBalanceTran.AdvanceStatus = (string)reader["AdvanceStatus"];
                    oConsumerBalanceTran.BankName = (string)reader["BankName"];
                    oConsumerBalanceTran.CardTypeName = (string)reader["CardType"];
                    oConsumerBalanceTran.POSMachin = (string)reader["POSMachin"];
                    oConsumerBalanceTran.CardCategoryName = (string)reader["CardCategory"];
                    oConsumerBalanceTran.InstrumentNo = (string)reader["InstrumentNo"];
                    oConsumerBalanceTran.PaymentDetail = (string)reader["PaymentDetail"];
                    oConsumerBalanceTran.ReceiveAmount = Convert.ToDouble(reader["Amount"].ToString());
                    oConsumerBalanceTran.AdjustAmount = Convert.ToDouble(reader["AdjustAmount"].ToString());
                    try
                    {
                        oConsumerBalanceTran.AdjustDate = Convert.ToDateTime(reader["AdjustDate"]).ToString("dd-MMM-yyyy");
                    }
                    catch
                    {
                        oConsumerBalanceTran.AdjustDate = "";
                    }
                    _Balance = _Balance + oConsumerBalanceTran.ReceiveAmount - oConsumerBalanceTran.AdjustAmount;

                    //if (Convert.ToInt32(reader["TranSide"]) == (int)Dictionary.TransectionSide.CREDIT)
                    //{
                    //    oConsumerBalanceTran.ReceiveAmount = Convert.ToDouble(reader["Amount"].ToString());
                    //    oConsumerBalanceTran.AdjustAmount = 0;
                    //    _Balance = _Balance + oConsumerBalanceTran.ReceiveAmount;
                    //}
                    //else
                    //{
                    //    oConsumerBalanceTran.ReceiveAmount = 0;
                    //    oConsumerBalanceTran.AdjustAmount = Convert.ToDouble(reader["Amount"].ToString());
                    //    _Balance = _Balance - oConsumerBalanceTran.AdjustAmount;
                    //}
                    oConsumerBalanceTran.Balance = _Balance;
                    InnerList.Add(oConsumerBalanceTran);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 27, 2014
// Time :  01:00 PM
// Description: Class for Data DCS.
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
    public class DCSDetail
    {

        private int _nDCSID;
        private int _nCustomerID;
        private int _nDCSType;
        private int _nInvoiceID;
        private string _sInvoiceNo;
        private int _nInstrumentID;
        private double _Amount;
        private int _nBankAccountID;
        private string _sBankBranch;
        private string _sInstrumentNo;
        private object _dInstrumentDate;
        private int _nStatus;
        private string _sRemarks;
        private double _Cash;
        private double _CreditCard;
        private double _AdvanceAdjusted;
        private double _Others;
        private double _B2BCredit;
        private double _CreditCollection;
        private double _CustomerBG;
        private string _sDCSTypeName;
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public string DCSTypeName
        {
            get { return _sDCSTypeName; }
            set { _sDCSTypeName = value; }
        }
        public int DCSID
        {
            get { return _nDCSID; }
            set { _nDCSID = value; }
        }
        public int DCSType
        {
            get { return _nDCSType; }
            set { _nDCSType = value; }
        }
        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        public int InstrumentID
        {
            get { return _nInstrumentID; }
            set { _nInstrumentID = value; }
        }
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public int BankAccountID
        {
            get { return _nBankAccountID; }
            set { _nBankAccountID = value; }
        }
        public string BankBranch
        {
            get { return _sBankBranch; }
            set { _sBankBranch = value; }
        }
        public string InstrumentNo
        {
            get { return _sInstrumentNo; }
            set { _sInstrumentNo = value; }
        }
        public object InstrumentDate
        {
            get { return _dInstrumentDate; }
            set { _dInstrumentDate = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        public double Cash
        {
            get { return _Cash; }
            set { _Cash = value; }
        }
        public double CreditCard
        {
            get { return _CreditCard; }
            set { _CreditCard = value; }
        }
        public double AdvanceAdjusted
        {
            get { return _AdvanceAdjusted; }
            set { _AdvanceAdjusted = value; }
        }
        public double B2BCredit
        {
            get { return _B2BCredit; }
            set { _B2BCredit = value; }
        }
        public double Others
        {
            get { return _Others; }
            set { _Others = value; }
        }
        public double CustomerBG
        {
            get { return _CustomerBG; }
            set { _CustomerBG = value; }
        }

        public double CreditCollection
        {
            get { return _CreditCollection; }
            set { _CreditCollection = value; }
        }

        private string _sBankAccount;
        public string BankAccount
        {
            get { return _sBankAccount; }
            set { _sBankAccount = value; }
        }
        private string _sInstrumentName;
        public string InstrumentName
        {
            get { return _sInstrumentName; }
            set { _sInstrumentName = value; }
        }

        public void Insert(int nDCSID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_DCSDetail(DCSID, DCSType, InvoiceID, InstrumentID, Amount, "+
                "BankAccountID, BankBranch, InstrumentNo, InstrumentDate, Status, Remarks) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DCSID", nDCSID);
                cmd.Parameters.AddWithValue("DCSType", _nDCSType);
                if (_nInvoiceID != -1)
                    cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                else cmd.Parameters.AddWithValue("InvoiceID", null);
                if (_nInstrumentID != -1)
                    cmd.Parameters.AddWithValue("InstrumentID", _nInstrumentID);
                else cmd.Parameters.AddWithValue("InstrumentID", null);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_nBankAccountID != -1)
                    cmd.Parameters.AddWithValue("BankAccountID", _nBankAccountID);
                else cmd.Parameters.AddWithValue("BankAccountID",null);
                cmd.Parameters.AddWithValue("BankBranch", _sBankBranch);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Insert(int nDCSID, int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_DCSDetail(DCSID, CustomerID,DCSType, InvoiceID, InstrumentID, Amount, " +
                "BankAccountID, BankBranch, InstrumentNo, InstrumentDate, Status, Remarks) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DCSID", nDCSID);
                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.Parameters.AddWithValue("DCSType", _nDCSType);
                if (_nInvoiceID != -1)
                    cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                else cmd.Parameters.AddWithValue("InvoiceID", null);
                if (_nInstrumentID != -1)
                    cmd.Parameters.AddWithValue("InstrumentID", _nInstrumentID);
                else cmd.Parameters.AddWithValue("InstrumentID", null);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                if (_nBankAccountID != -1)
                    cmd.Parameters.AddWithValue("BankAccountID", _nBankAccountID);
                else cmd.Parameters.AddWithValue("BankAccountID", null);
                cmd.Parameters.AddWithValue("BankBranch", _sBankBranch);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetAmountByType(DateTime dFromDate)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select Sum(Cash) as Cash, Sum(CreditCard) as CreditCard, Sum(AdvanceAdjusted) as AdvanceAdjusted, " +
                            "Sum(B2BCredit) as B2BCredit,Sum(CustomerBG) as CustomerBG,Sum(Others) as Others, Sum(InvoiceAmount) as InvoiceAmount from t_DCSDetail a,  " +
                            "( " +
                            "select InvoiceID,  " +
                            "SUM(CASE When PaymentModeID = 1 then Amount else 0 end) as Cash,  " +
                            "SUM(CASE When PaymentModeID = 2 then Amount else 0 end) as CreditCard,  " +
                            "SUM(CASE When PaymentModeID = 3 then Amount else 0 end) as AdvanceAdjusted,  " +
                            "SUM(CASE When PaymentModeID = 6 then Amount else 0 end) as B2BCredit,  " +
                            "SUM(CASE When PaymentModeID = 12 then Amount else 0 end) as CustomerBG,  " +
                            "SUM(CASE When PaymentModeID Not IN (1,2,3,6,12) then Amount else 0 end) as Others  " +
                            "from dbo.t_SalesInvoicePaymentMode Group by InvoiceID " +
                            ")b,  " +
                            "(Select InvoiceID, InvoiceNo, InvoiceAmount from t_SalesInvoice  " +
                            "where InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "') as c  " +
                            "Where DCSType = 1 and a.InvoiceID=b.InvoiceID and a.InvoiceID = c.InvoiceID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    if (reader["Cash"] != DBNull.Value)
                        _Cash = Convert.ToDouble(reader["Cash"].ToString());
                    else _Cash = 0;

                    if (reader["CreditCard"] != DBNull.Value)
                        _CreditCard = Convert.ToDouble(reader["CreditCard"].ToString());
                    else _CreditCard = 0;

                    if (reader["AdvanceAdjusted"] != DBNull.Value)
                        _AdvanceAdjusted = Convert.ToDouble(reader["AdvanceAdjusted"].ToString());
                    else _AdvanceAdjusted = 0;

                    if (reader["B2BCredit"] != DBNull.Value)
                        _B2BCredit = Convert.ToDouble(reader["B2BCredit"].ToString());
                    else _B2BCredit = 0;

                    if (reader["CustomerBG"] != DBNull.Value)
                        _CustomerBG = Convert.ToDouble(reader["CustomerBG"].ToString());
                    else _CustomerBG = 0;

                    if (reader["Others"] != DBNull.Value)
                        _Others = Convert.ToDouble(reader["Others"].ToString());
                    else _Others = 0;

                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _Amount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _Amount = 0;

                }

                reader.Close();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetAmountByTypeRT(DateTime dFromDate)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select Sum(Cash) as Cash, Sum(CreditCard) as CreditCard, Sum(AdvanceAdjusted) as AdvanceAdjusted, " +
                            "Sum(B2BCredit) as B2BCredit,Sum(CustomerBG) as CustomerBG,Sum(Others) as Others, Sum(InvoiceAmount) as InvoiceAmount from t_DCSDetail a,  " +
                            "( " +
                            "select InvoiceID,  " +
                            "SUM(CASE When PaymentModeID = 1 then Amount else 0 end) as Cash,  " +
                            "SUM(CASE When PaymentModeID = 2 then Amount else 0 end) as CreditCard,  " +
                            "SUM(CASE When PaymentModeID = 3 then Amount else 0 end) as AdvanceAdjusted,  " +
                            "SUM(CASE When PaymentModeID = 6 then Amount else 0 end) as B2BCredit,  " +
                            "SUM(CASE When PaymentModeID = 12 then Amount else 0 end) as CustomerBG,  " +
                            "SUM(CASE When PaymentModeID Not IN (1,2,3,6,12) then Amount else 0 end) as Others  " +
                            "from dbo.t_SalesInvoicePaymentMode Group by InvoiceID " +
                            ")b,  " +
                            "(Select InvoiceID, InvoiceNo, InvoiceAmount from t_SalesInvoice  " +
                            "where WarehouseID=" + Utility.WarehouseID + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "') as c  " +
                            "Where a.CustomerID=" + Utility.CustomerID + " and DCSType = 1 and a.InvoiceID=b.InvoiceID and a.InvoiceID = c.InvoiceID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    if (reader["Cash"] != DBNull.Value)
                        _Cash = Convert.ToDouble(reader["Cash"].ToString());
                    else _Cash = 0;

                    if (reader["CreditCard"] != DBNull.Value)
                        _CreditCard = Convert.ToDouble(reader["CreditCard"].ToString());
                    else _CreditCard = 0;

                    if (reader["AdvanceAdjusted"] != DBNull.Value)
                        _AdvanceAdjusted = Convert.ToDouble(reader["AdvanceAdjusted"].ToString());
                    else _AdvanceAdjusted = 0;

                    if (reader["B2BCredit"] != DBNull.Value)
                        _B2BCredit = Convert.ToDouble(reader["B2BCredit"].ToString());
                    else _B2BCredit = 0;

                    if (reader["CustomerBG"] != DBNull.Value)
                        _CustomerBG = Convert.ToDouble(reader["CustomerBG"].ToString());
                    else _CustomerBG = 0;

                    if (reader["Others"] != DBNull.Value)
                        _Others = Convert.ToDouble(reader["Others"].ToString());
                    else _Others = 0;

                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _Amount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _Amount = 0;

                }

                reader.Close();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetAmountByTypeHO(DateTime dFromDate, int nCustomerID)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select Sum(Cash) as Cash, Sum(CreditCard) as CreditCard, Sum(AdvanceAdjusted) as AdvanceAdjusted, " +
                            "Sum(B2BCredit) as B2BCredit,Sum(Others) as Others, Sum(InvoiceAmount) as InvoiceAmount from t_DCSDetail a,  " +
                            "( " +
                            "select InvoiceID,  " +
                            "SUM(CASE When PaymentModeID = 1 then Amount else 0 end) as Cash,  " +
                            "SUM(CASE When PaymentModeID = 2 then Amount else 0 end) as CreditCard,  " +
                            "SUM(CASE When PaymentModeID = 3 then Amount else 0 end) as AdvanceAdjusted,  " +
                            "SUM(CASE When PaymentModeID = 6 then Amount else 0 end) as B2BCredit,  " +
                            "SUM(CASE When PaymentModeID Not IN (1,2,3,6) then Amount else 0 end) as Others  " +
                            "from dbo.t_SalesInvoicePaymentMode Group by InvoiceID " +
                            ")b,  " +
                            "(Select InvoiceID, InvoiceNo, InvoiceAmount from t_SalesInvoice a,t_Showroom b " +
                            "where a.WarehouseID=b.WarehouseID and b.CustomerID = " + nCustomerID + " " +
                            " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "') as c  " +
                            "Where DCSType = 1 and a.InvoiceID=b.InvoiceID and a.InvoiceID = c.InvoiceID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    if (reader["Cash"] != DBNull.Value)
                        _Cash = Convert.ToDouble(reader["Cash"].ToString());
                    else _Cash = 0;

                    if (reader["CreditCard"] != DBNull.Value)
                        _CreditCard = Convert.ToDouble(reader["CreditCard"].ToString());
                    else _CreditCard = 0;

                    if (reader["AdvanceAdjusted"] != DBNull.Value)
                        _AdvanceAdjusted = Convert.ToDouble(reader["AdvanceAdjusted"].ToString());
                    else _AdvanceAdjusted = 0;

                    if (reader["B2BCredit"] != DBNull.Value)
                        _B2BCredit = Convert.ToDouble(reader["B2BCredit"].ToString());
                    else _B2BCredit = 0;

                    if (reader["Others"] != DBNull.Value)
                        _Others = Convert.ToDouble(reader["Others"].ToString());
                    else _Others = 0;

                    if (reader["InvoiceAmount"] != DBNull.Value)
                        _Amount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    else _Amount = 0;

                }

                reader.Close();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetExtendedWarrantyAmount(int nDCSID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select sum(Cash) Cash, sum(CreditCard) CreditCard From " +
                        "( " +
                        "Select case when PaymentModeID = 1 then SUM(a.Amount) else 0 end as Cash, " +
                        "case when PaymentModeID = 2 then SUM(a.Amount) else 0 end as CreditCard " +
                        "From t_DCSDetail a, t_ExtendedWarranty b " +
                        "where DCSID = " + nDCSID + " and DCSType = " + (int)Dictionary.DCSType.ExtendedWarrantyCollection + " and a.InvoiceID = b.ID  group by DCSID, CertificateNo, PaymentModeID, b.InstrumentNo " +
                        ") a";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    if (reader["Cash"] != DBNull.Value)
                        _Cash = Convert.ToDouble(reader["Cash"].ToString());
                    else _Cash = 0;

                    if (reader["CreditCard"] != DBNull.Value)
                        _CreditCard = Convert.ToDouble(reader["CreditCard"].ToString());
                    else _CreditCard = 0;

                }

                reader.Close();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetExtendedWarrantyAmountRT(int nDCSID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select sum(Cash) Cash, sum(CreditCard) CreditCard From " +
                        "( " +
                        "Select case when PaymentModeID = 1 then SUM(a.Amount) else 0 end as Cash, " +
                        "case when PaymentModeID = 2 then SUM(a.Amount) else 0 end as CreditCard " +
                        "From (Select * From t_DCSDetail where CustomerID=" + Utility.CustomerID + ") a, (Select * From t_ExtendedWarranty where WarehouseID=" + Utility.WarehouseID + ") b " +
                        "where DCSID = " + nDCSID + " and DCSType = " + (int)Dictionary.DCSType.ExtendedWarrantyCollection + " and a.InvoiceID = b.ID  group by DCSID, CertificateNo, PaymentModeID, b.InstrumentNo " +
                        ") a";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    if (reader["Cash"] != DBNull.Value)
                        _Cash = Convert.ToDouble(reader["Cash"].ToString());
                    else _Cash = 0;

                    if (reader["CreditCard"] != DBNull.Value)
                        _CreditCard = Convert.ToDouble(reader["CreditCard"].ToString());
                    else _CreditCard = 0;

                }

                reader.Close();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetCollectionAmountHO(int nDCSID, int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSQL = "";
            try
            {
                sSQL = "Select isnull(Sum(Amount),0) as Amount From t_DCSDetail where DCSID = ? and CustomerID = ? and DCSType=" + (int)Dictionary.DCSType.CreditCollection + " ";

                cmd.Parameters.AddWithValue("DCSID", nDCSID);
                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _CreditCollection = Convert.ToDouble(reader["Amount"].ToString());
                }
                reader.Close();
            }
            catch
            {
                _CreditCollection = 0;
            }

            return _CreditCollection;
        }

        public double GetCollectionAmount(int nDCSID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSQL = "";
            try
            {
                sSQL = "Select Sum(Amount) as Amount From t_DCSDetail where DCSID = ? and DCSType=" + (int)Dictionary.DCSType.CreditCollection + " ";

                cmd.Parameters.AddWithValue("DCSID", nDCSID);

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _CreditCollection = Convert.ToDouble(reader["Amount"].ToString());
                }
                reader.Close();
            }
            catch
            {
                _CreditCollection = 0;
            }

            return _CreditCollection;
        }

        public double GetCollectionAmountRT(int nDCSID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSQL = "";
            try
            {
                sSQL = "Select Sum(Amount) as Amount From t_DCSDetail where CustomerID=" + Utility.CustomerID + " and DCSID = ? and DCSType=" + (int)Dictionary.DCSType.CreditCollection + " ";

                cmd.Parameters.AddWithValue("DCSID", nDCSID);

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _CreditCollection = Convert.ToDouble(reader["Amount"].ToString());
                }
                reader.Close();
            }
            catch
            {
                _CreditCollection = 0;
            }

            return _CreditCollection;
        }

    }
    public class DCS : CollectionBase
    {
        private int _nDCSID;
        private int _nCustomerID;
        private string _sDCSNo;
        private DateTime _dDCSDate;
        private double _CollectionAmount;
        private double _AdditionalAmount;
        private double _Other_Amount_Debit;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nIsUpload;
        private string _sShowroomCode;

        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value; }
        }

        public int DCSID
        {
            get { return _nDCSID; }
            set { _nDCSID = value; }
        }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public string DCSNo
        {
            get { return _sDCSNo; }
            set { _sDCSNo = value; }
        }
        public DateTime DCSDate
        {
            get { return _dDCSDate; }
            set { _dDCSDate = value; }
        }
        public double CollectionAmount
        {
            get { return _CollectionAmount; }
            set { _CollectionAmount = value; }
        }
        public double AdditionalAmount
        {
            get { return _AdditionalAmount; }
            set { _AdditionalAmount = value; }
        }
        public double Other_Amount_Debit
        {
            get { return _Other_Amount_Debit; }
            set { _Other_Amount_Debit = value; }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        public DateTime CreateDate
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
        public int IsUpload
        {
            get { return _nIsUpload; }
            set { _nIsUpload = value; }
        }

        private string _sCreditCardType;
        public string CreditCardType
        {
            get { return _sCreditCardType; }
            set { _sCreditCardType = value; }
        }
        private double _CreditCardAmount;
        public double CreditCardAmount
        {
            get { return _CreditCardAmount; }
            set { _CreditCardAmount = value; }
        }

        private double _B2BCreditAmt;
        public double B2BCreditAmt
        {
            get { return _B2BCreditAmt; }
            set { _B2BCreditAmt = value; }
        }
        private string _sBankName;
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value; }
        }
        private string _sAssetName;
        public string AssetName
        {
            get { return _sAssetName; }
            set { _sAssetName = value; }
        }
        private int _nInstallmentNo;
        public int InstallmentNo
        {
            get { return _nInstallmentNo; }
            set { _nInstallmentNo = value; }
        }
        private string _sInstrument;
        public string Instrument
        {
            get { return _sInstrument; }
            set { _sInstrument = value; }
        }
        private string _sInvoiceNo;
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }
        private bool _bFlag;
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        public DCSDetail this[int i]
        {
            get { return (DCSDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DCSDetail oDCSDetail)
        {
            InnerList.Add(oDCSDetail);
        }
        public void Insert(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxDCSID = 0;

            try
            {
                sSql = "SELECT MAX([DCSID]) FROM t_DCS";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDCSID = 1;
                }
                else
                {
                    nMaxDCSID = Convert.ToInt32(maxID) + 1;
                }
                if (IsTrue)
                {
                    _nDCSID = nMaxDCSID;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_DCS (DCSID,CustomerID, DCSNo, DCSDate, CollectionAmount, AdditionalAmount,Other_Amount_Debit, Remarks, CreateUserID,CreateDate, IsUpload)  " +
                       "VALUES(?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DCSID", _nDCSID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DCSNo", _sDCSNo);
                cmd.Parameters.AddWithValue("DCSDate", _dDCSDate);
                cmd.Parameters.AddWithValue("CollectionAmount", _CollectionAmount);
                cmd.Parameters.AddWithValue("AdditionalAmount", _AdditionalAmount);
                cmd.Parameters.AddWithValue("Other_Amount_Debit", _Other_Amount_Debit);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("IsUpload", _nIsUpload);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (DCSDetail oItem in this)
                {
                    if (IsTrue)
                    {
                        oItem.Insert(_nDCSID);
                    }
                    else
                    {
                        oItem.Insert(_nDCSID, _nCustomerID);
                    }
                }

                if (IsTrue)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_NextNo set NextDCSNo = NextDCSNo + 1";
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    SystemInfo _oSystemInfo = new SystemInfo();
                    _oSystemInfo.Refresh();
                    DataTran _oDataTran = new DataTran();
                    _oDataTran.TableName = "t_DCS";
                    _oDataTran.DataID = _nDCSID;
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

        public void InsertRT(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxDCSID = 0;

            try
            {
                sSql = "SELECT MAX([DCSID]) FROM t_DCS where CustomerID=" + Utility.CustomerID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDCSID = 1;
                }
                else
                {
                    nMaxDCSID = Convert.ToInt32(maxID) + 1;
                }
                if (IsTrue)
                {
                    _nDCSID = nMaxDCSID;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_DCS (DCSID,CustomerID, DCSNo, DCSDate, CollectionAmount, AdditionalAmount,Other_Amount_Debit, Remarks, CreateUserID,CreateDate, IsUpload)  " +
                       "VALUES(?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DCSID", _nDCSID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DCSNo", _sDCSNo);
                cmd.Parameters.AddWithValue("DCSDate", _dDCSDate);
                cmd.Parameters.AddWithValue("CollectionAmount", _CollectionAmount);
                cmd.Parameters.AddWithValue("AdditionalAmount", _AdditionalAmount);
                cmd.Parameters.AddWithValue("Other_Amount_Debit", _Other_Amount_Debit);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("IsUpload", _nIsUpload);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (DCSDetail oItem in this)
                {
                    if (IsTrue)
                    {
                        oItem.Insert(_nDCSID);
                    }
                    else
                    {
                        oItem.Insert(_nDCSID, _nCustomerID);
                    }
                }

                if (IsTrue)
                {
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "update t_Showroom set NextDCSNo = NextDCSNo + 1 where WarehouseID=" + Utility.WarehouseID + "";
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
        public void RefreshDCSDetail()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.*,InvoiceNo From  " +
                        "(select * from t_DCSDetail where  DCSType=1 and DCSID=" + _nDCSID + ") a  " +
                        "left Outer JOIN   " +
                        "(Select InvoiceID, InvoiceNo from t_SalesInvoice)b   " +
                        "ON a.InvoiceID=b.InvoiceID   " +
                        "Union All  " +
                        "select DCSID,DCSType,Null InvoiceID,InstrumentID,Amount,  " +
                        "BankAccountID,BankBranch,InstrumentNo,InstrumentDate,  " +
                        "Status,Remarks,Null InvoiceNo from t_DCSDetail where  DCSType<>1 and DCSID=" + _nDCSID + "";


            //cmd.Parameters.AddWithValue("DCSID", _nDCSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCSDetail oDCSDetail = new DCSDetail();

                    oDCSDetail.DCSID = (int)reader["DCSID"];
                    oDCSDetail.DCSType = (int)reader["DCSType"];
                    if (reader["InvoiceID"] != DBNull.Value)
                    {
                        oDCSDetail.InvoiceID = (int)reader["InvoiceID"];
                        oDCSDetail.InvoiceNo = (string)reader["InvoiceNo"];
                    }
                    else
                    {
                        oDCSDetail.InvoiceID = -1;
                        oDCSDetail.InvoiceNo = "";
                    }
                    if (reader["InstrumentID"] != DBNull.Value)
                    {
                        oDCSDetail.InstrumentID = (int)reader["InstrumentID"];
                    }
                    else
                    {
                        oDCSDetail.InstrumentID = -1;
                    }
                    if (reader["InstrumentNo"] != DBNull.Value)
                    {
                        oDCSDetail.InstrumentNo = (string)reader["InstrumentNo"];
                    }
                    else
                    {
                        oDCSDetail.InstrumentNo = "";
                    }
                    if (reader["InstrumentDate"] != DBNull.Value)
                    {
                        oDCSDetail.InstrumentDate =Convert.ToDateTime(reader["InstrumentDate"]);
                    }
                    else
                    {
                        oDCSDetail.InstrumentDate = null;
                    }
                    oDCSDetail.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    if (reader["BankAccountID"] != DBNull.Value)
                    {
                        oDCSDetail.BankAccountID = (int)reader["BankAccountID"];
                    }
                    else
                    {
                        oDCSDetail.BankAccountID = -1;
                    }
                    if (reader["BankBranch"] != DBNull.Value)
                    {
                        oDCSDetail.BankBranch = (string)reader["BankBranch"];
                    }
                    else
                    {
                        oDCSDetail.BankBranch = "";
                    }
                    oDCSDetail.Status = (int)reader["Status"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oDCSDetail.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oDCSDetail.Remarks = "";
                    }
                    InnerList.Add(oDCSDetail);
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
        public void RefreshDCSDetailHO()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select * from t_DCSDetail a " +
                       " left Outer JOIN (Select InvoiceID, InvoiceNo from t_SalesInvoice)b " +
                       " ON a.InvoiceID=b.InvoiceID Where DCSID = ? and CustomerID= ?";


            cmd.Parameters.AddWithValue("DCSID", _nDCSID);
            cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCSDetail oDCSDetail = new DCSDetail();

                    oDCSDetail.DCSID = (int)reader["DCSID"];
                    oDCSDetail.CustomerID = (int)reader["CustomerID"];
                    oDCSDetail.DCSType = (int)reader["DCSType"];
                    if (reader["InvoiceID"] != DBNull.Value)
                    {
                        oDCSDetail.InvoiceID = (int)reader["InvoiceID"];
                        //oDCSDetail.InvoiceNo = (string)reader["InvoiceNo"];
                    }
                    else
                    {
                        oDCSDetail.InvoiceID = -1;
                        //oDCSDetail.InvoiceNo = "";
                    }
                    if (reader["InvoiceNo"] != DBNull.Value)
                    {
                        oDCSDetail.InvoiceNo = (string)reader["InvoiceNo"];
                    }
                    else
                    {
                        oDCSDetail.InvoiceNo = "";
                    }
                    if (reader["InstrumentID"] != DBNull.Value)
                    {
                        oDCSDetail.InstrumentID = (int)reader["InstrumentID"];
                    }
                    else
                    {
                        oDCSDetail.InstrumentID = -1;
                    }
                    if (reader["InstrumentNo"] != DBNull.Value)
                    {
                        oDCSDetail.InstrumentNo = (string)reader["InstrumentNo"];
                    }
                    else
                    {
                        oDCSDetail.InstrumentNo = "";
                    }
                    if (reader["InstrumentDate"] != DBNull.Value)
                    {
                        oDCSDetail.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"]);
                    }
                    else
                    {
                        oDCSDetail.InstrumentDate = null;
                    }
                    oDCSDetail.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    if (reader["BankAccountID"] != DBNull.Value)
                    {
                        oDCSDetail.BankAccountID = (int)reader["BankAccountID"];
                    }
                    else
                    {
                        oDCSDetail.BankAccountID = -1;
                    }
                    if (reader["BankBranch"] != DBNull.Value)
                    {
                        oDCSDetail.BankBranch = (string)reader["BankBranch"];
                    }
                    else
                    {
                        oDCSDetail.BankBranch = "";
                    }
                    oDCSDetail.Status = (int)reader["Status"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oDCSDetail.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oDCSDetail.Remarks = "";
                    }
                    InnerList.Add(oDCSDetail);
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

        public void RefreshDCSDetailPOS()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select * from t_DCSDetail a " +
                       " left Outer JOIN (Select InvoiceID, InvoiceNo from t_SalesInvoice)b " +
                       " ON a.InvoiceID=b.InvoiceID Where DCSID = ?";


            cmd.Parameters.AddWithValue("DCSID", _nDCSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCSDetail oDCSDetail = new DCSDetail();

                    oDCSDetail.DCSID = (int)reader["DCSID"];

                    oDCSDetail.DCSType = (int)reader["DCSType"];
                    if (reader["InvoiceID"] != DBNull.Value)
                    {
                        oDCSDetail.InvoiceID = (int)reader["InvoiceID"];
                        //oDCSDetail.InvoiceNo = (string)reader["InvoiceNo"];
                    }
                    else
                    {
                        oDCSDetail.InvoiceID = -1;
                        //oDCSDetail.InvoiceNo = "";
                    }
                    if (reader["InvoiceNo"] != DBNull.Value)
                    {
                        oDCSDetail.InvoiceNo = (string)reader["InvoiceNo"];
                    }
                    else
                    {
                        oDCSDetail.InvoiceNo = "";
                    }
                    if (reader["InstrumentID"] != DBNull.Value)
                    {
                        oDCSDetail.InstrumentID = (int)reader["InstrumentID"];
                    }
                    else
                    {
                        oDCSDetail.InstrumentID = -1;
                    }
                    if (reader["InstrumentNo"] != DBNull.Value)
                    {
                        oDCSDetail.InstrumentNo = (string)reader["InstrumentNo"];
                    }
                    else
                    {
                        oDCSDetail.InstrumentNo = "";
                    }
                    if (reader["InstrumentDate"] != DBNull.Value)
                    {
                        oDCSDetail.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"]);
                    }
                    else
                    {
                        oDCSDetail.InstrumentDate = null;
                    }
                    oDCSDetail.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    if (reader["BankAccountID"] != DBNull.Value)
                    {
                        oDCSDetail.BankAccountID = (int)reader["BankAccountID"];
                    }
                    else
                    {
                        oDCSDetail.BankAccountID = -1;
                    }
                    if (reader["BankBranch"] != DBNull.Value)
                    {
                        oDCSDetail.BankBranch = (string)reader["BankBranch"];
                    }
                    else
                    {
                        oDCSDetail.BankBranch = "";
                    }
                    oDCSDetail.Status = (int)reader["Status"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oDCSDetail.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oDCSDetail.Remarks = "";
                    }
                    InnerList.Add(oDCSDetail);
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
        public void RefreshDCSDetail(int nDCSType, DateTime _CollectionDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime dToDate = _CollectionDate.AddDays(1);

            string sSql = " select DCSTypes,DCSID,InvoiceNo,Cash, CreditCard, AdvanceAdjusted,B2BCredit,CustomerBG, Others,InvoiceAmount, c.InstrumentNo from t_DCSDetail a, " +
                            "(select InvoiceID, " +
                            "SUM(CASE When PaymentModeID = 1 then Amount else 0 end) as Cash, " +
                            "SUM(CASE When PaymentModeID = 2 then Amount else 0 end) as CreditCard, " +
                            "SUM(CASE When PaymentModeID = 3 then Amount else 0 end) as AdvanceAdjusted, " +
                            "SUM(CASE When PaymentModeID = 6 then Amount else 0 end) as B2BCredit, " +
                            "SUM(CASE When PaymentModeID = 12 then Amount else 0 end) as CustomerBG, " +
                            "SUM(CASE When PaymentModeID Not IN (1,2,3,6,12) then Amount else 0 end) as Others " +
                            "from dbo.t_SalesInvoicePaymentMode Group by InvoiceID)b, " +
                            "(Select " + (int)Dictionary.DCSType.Invoice + " as DCSTypes,a.InvoiceID, InvoiceNo, InvoiceAmount, ISNULL(InstrumentNo,'') as InstrumentNo from t_SalesInvoice a " +
                            "Left Outer JOIN (select InvoiceID, InstrumentNo from t_SalesInvoicePaymentMode where PaymentModeID=6) b ON a.InvoiceID=b.InvoiceID) as c " +
                            "Where DCSID = ? and DCSType =" + (int)Dictionary.DCSType.Invoice + " and a.InvoiceID=b.InvoiceID and a.InvoiceID = c.InvoiceID " +
                            "Union All " +
                            "Select  " + (int)Dictionary.DCSType.CreditCollection + " as DCSType,DCSID, b.ApprovalNo, c.Amount,0 as CreditCard, 0 as AdvanceAdjusted,0 as B2BCredit,0 as CustomerBG, " +
                            "0 as Others,0 as InvoiceAmount,'' as  InstrumentNo " +
                            "from dbo.t_CustomerCreditApprovalCollection a, dbo.t_CustomerCreditApproval b,t_DCSDetail c " +
                            "Where a.CreditApprovalID=b.CreditApprovalID and c.InvoiceID=b.CreditApprovalID and  " +
                            "a.WarehouseID=b.WarehouseID and a.CustomerID=b.CustomerID  " +
                            "and  DCSID = ? and  a.CreateDate Between '" + _CollectionDate + "' and '" + dToDate + "' and a.CreateDate < '" + dToDate + "' and  " +
                            " DCSType =" + (int)Dictionary.DCSType.CreditCollection + " " +
                            "Union All " +
                            "Select " + (int)Dictionary.DCSType.CreditCollection + " as DCSType,DCSID, TranNo, b.Amount,0 as CreditCard, 0 as AdvanceAdjusted,0 as B2BCredit, 0 as CustomerBG, " +
                            "0 as Others,0 as InvoiceAmount,'' as  InstrumentNo  " +
                            "From t_CustomerTran a,t_DCSDetail b " +
                            "where b.InvoiceID=a.TranID and TranTypeID=5 and  " +
                            "TranDate Between '" + _CollectionDate + "' and '" + dToDate + "'  " +
                            "and TranDate < '" + dToDate + "' and DCSID = ?  " +
                            "Union All " +
                            "Select " + (int)Dictionary.DCSType.ExtendedWarrantyCollection + " as DCSType,DCSID,CertificateNo,case when PaymentModeID=1 then SUM(a.Amount) else 0 end as Cash, " +
                            "case when PaymentModeID=2 then SUM(a.Amount) else 0 end as CreditCard, " +
                            "0 as AdvanceAdjusted,0 B2BCredit,0 CustomerBG,0	Others,sum(a.Amount)	InvoiceAmount,b.InstrumentNo " +
                            "From t_DCSDetail a,t_ExtendedWarranty b  " +
                            "where DCSID=? and DCSType=" + (int)Dictionary.DCSType.ExtendedWarrantyCollection + " and a.InvoiceID=b.ID  group by DCSID,CertificateNo,PaymentModeID,b.InstrumentNo";

                            cmd.Parameters.AddWithValue("DCSID", _nDCSID);
                            cmd.Parameters.AddWithValue("DCSID", _nDCSID);
                            cmd.Parameters.AddWithValue("DCSID", _nDCSID);
                            cmd.Parameters.AddWithValue("DCSID", _nDCSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCSDetail oDCSDetail = new DCSDetail();

                    oDCSDetail.DCSID = (int)reader["DCSID"];
                    oDCSDetail.DCSType = (int)reader["DCSTypes"];
                    if (oDCSDetail.DCSType == (int)Dictionary.DCSType.Invoice)
                    {
                        oDCSDetail.DCSTypeName = "INV";
                    }
                    else if (oDCSDetail.DCSType == (int)Dictionary.DCSType.CreditCollection)
                    {
                        oDCSDetail.DCSTypeName = "CC";
                    }
                    else if (oDCSDetail.DCSType == (int)Dictionary.DCSType.ExtendedWarrantyCollection)
                    {
                        oDCSDetail.DCSTypeName = "EWC";
                    }
                    else
                    {
                        oDCSDetail.DCSTypeName = "Other";
                    }
                    oDCSDetail.InvoiceNo = (string)reader["InvoiceNo"];
                    oDCSDetail.Cash = Convert.ToDouble(reader["Cash"].ToString());
                    oDCSDetail.CreditCard = Convert.ToDouble(reader["CreditCard"].ToString());
                    oDCSDetail.AdvanceAdjusted = Convert.ToDouble(reader["AdvanceAdjusted"].ToString());
                    oDCSDetail.B2BCredit = Convert.ToDouble(reader["B2BCredit"].ToString());
                    oDCSDetail.CustomerBG = Convert.ToDouble(reader["CustomerBG"].ToString());
                    oDCSDetail.Others = Convert.ToDouble(reader["Others"].ToString());
                    oDCSDetail.Amount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oDCSDetail.InstrumentNo = (string)reader["InstrumentNo"];

                    InnerList.Add(oDCSDetail);
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

        public void RefreshDCSDetailRT(int nDCSType, DateTime _CollectionDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime dToDate = _CollectionDate.AddDays(1);

            string sSql = " select DCSTypes,DCSID,InvoiceNo,Cash, CreditCard, AdvanceAdjusted,B2BCredit,CustomerBG, Others,InvoiceAmount, c.InstrumentNo from (Select * From t_DCSDetail where a.CustomerID=" + Utility.CustomerID + ") a, " +
                            "(select InvoiceID, " +
                            "SUM(CASE When PaymentModeID = 1 then Amount else 0 end) as Cash, " +
                            "SUM(CASE When PaymentModeID = 2 then Amount else 0 end) as CreditCard, " +
                            "SUM(CASE When PaymentModeID = 3 then Amount else 0 end) as AdvanceAdjusted, " +
                            "SUM(CASE When PaymentModeID = 6 then Amount else 0 end) as B2BCredit, " +
                            "SUM(CASE When PaymentModeID = 12 then Amount else 0 end) as CustomerBG, " +
                            "SUM(CASE When PaymentModeID Not IN (1,2,3,6,12) then Amount else 0 end) as Others " +
                            "from dbo.t_SalesInvoicePaymentMode Group by InvoiceID) b, " +
                            "(Select " + (int)Dictionary.DCSType.Invoice + " as DCSTypes,a.InvoiceID, InvoiceNo, InvoiceAmount, ISNULL(InstrumentNo,'') as InstrumentNo from t_SalesInvoice a " +
                            "Left Outer JOIN (select InvoiceID, InstrumentNo from t_SalesInvoicePaymentMode where PaymentModeID=6) b ON a.InvoiceID=b.InvoiceID and a.WarehouseID=" + Utility.WarehouseID + ") as c " +
                            "Where DCSID = ? and DCSType =" + (int)Dictionary.DCSType.Invoice + " and a.InvoiceID=b.InvoiceID and a.InvoiceID = c.InvoiceID " +
                            "Union All " +
                            "Select  " + (int)Dictionary.DCSType.CreditCollection + " as DCSType,DCSID, b.ApprovalNo, c.Amount,0 as CreditCard, 0 as AdvanceAdjusted,0 as B2BCredit,0 as CustomerBG, " +
                            "0 as Others,0 as InvoiceAmount,'' as  InstrumentNo " +
                            "from dbo.t_CustomerCreditApprovalCollection a, dbo.t_CustomerCreditApproval b,t_DCSDetail c " +
                            "Where a.CreditApprovalID=b.CreditApprovalID and a.CustomerID=" + Utility.CustomerID + " and c.InvoiceID=b.CreditApprovalID and  " +
                            "a.WarehouseID=b.WarehouseID and a.CustomerID=b.CustomerID  " +
                            "and  DCSID = ? and  a.CreateDate Between '" + _CollectionDate + "' and '" + dToDate + "' and a.CreateDate < '" + dToDate + "' and  " +
                            " DCSType =" + (int)Dictionary.DCSType.CreditCollection + " " +
                            "Union All " +
                            "Select " + (int)Dictionary.DCSType.CreditCollection + " as DCSType,DCSID, TranNo, b.Amount,0 as CreditCard, 0 as AdvanceAdjusted,0 as B2BCredit, 0 as CustomerBG, " +
                            "0 as Others,0 as InvoiceAmount,'' as  InstrumentNo  " +
                            "From t_CustomerTran a,t_DCSDetail b " +
                            "where b.InvoiceID=a.TranID and TranTypeID=5 and  " +
                            "TranDate Between '" + _CollectionDate + "' and '" + dToDate + "'  " +
                            "and TranDate < '" + dToDate + "' and b.CustomerID=" + Utility.CustomerID + " and DCSID = ?  " +
                            "Union All " +
                            "Select " + (int)Dictionary.DCSType.ExtendedWarrantyCollection + " as DCSType,DCSID,CertificateNo,case when PaymentModeID=1 then SUM(a.Amount) else 0 end as Cash, " +
                            "case when PaymentModeID=2 then SUM(a.Amount) else 0 end as CreditCard, " +
                            "0 as AdvanceAdjusted,0 B2BCredit,0 CustomerBG,0	Others,sum(a.Amount)	InvoiceAmount,b.InstrumentNo " +
                            "From t_DCSDetail a,t_ExtendedWarranty b  " +
                            "where DCSID=? and a.CustomerID=" + Utility.CustomerID + " and DCSType=" + (int)Dictionary.DCSType.ExtendedWarrantyCollection + " and a.InvoiceID=b.ID  group by DCSID,CertificateNo,PaymentModeID,b.InstrumentNo";

            cmd.Parameters.AddWithValue("DCSID", _nDCSID);
            cmd.Parameters.AddWithValue("DCSID", _nDCSID);
            cmd.Parameters.AddWithValue("DCSID", _nDCSID);
            cmd.Parameters.AddWithValue("DCSID", _nDCSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCSDetail oDCSDetail = new DCSDetail();

                    oDCSDetail.DCSID = (int)reader["DCSID"];
                    oDCSDetail.DCSType = (int)reader["DCSTypes"];
                    if (oDCSDetail.DCSType == (int)Dictionary.DCSType.Invoice)
                    {
                        oDCSDetail.DCSTypeName = "INV";
                    }
                    else if (oDCSDetail.DCSType == (int)Dictionary.DCSType.CreditCollection)
                    {
                        oDCSDetail.DCSTypeName = "CC";
                    }
                    else if (oDCSDetail.DCSType == (int)Dictionary.DCSType.ExtendedWarrantyCollection)
                    {
                        oDCSDetail.DCSTypeName = "EWC";
                    }
                    else
                    {
                        oDCSDetail.DCSTypeName = "Other";
                    }
                    oDCSDetail.InvoiceNo = (string)reader["InvoiceNo"];
                    oDCSDetail.Cash = Convert.ToDouble(reader["Cash"].ToString());
                    oDCSDetail.CreditCard = Convert.ToDouble(reader["CreditCard"].ToString());
                    oDCSDetail.AdvanceAdjusted = Convert.ToDouble(reader["AdvanceAdjusted"].ToString());
                    oDCSDetail.B2BCredit = Convert.ToDouble(reader["B2BCredit"].ToString());
                    oDCSDetail.CustomerBG = Convert.ToDouble(reader["CustomerBG"].ToString());
                    oDCSDetail.Others = Convert.ToDouble(reader["Others"].ToString());
                    oDCSDetail.Amount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oDCSDetail.InstrumentNo = (string)reader["InstrumentNo"];

                    InnerList.Add(oDCSDetail);
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
        public void RefreshDCSDetailHO(int nDCSType, DateTime _CollectionDate, int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DateTime dToDate = _CollectionDate.AddDays(1);

            string sSql = " select DCSID,CustomerID,InvoiceNo,Cash, CreditCard, AdvanceAdjusted,B2BCredit,CustomerBG, Others,InvoiceAmount, c.InstrumentNo from t_DCSDetail a, " +
                            "(select InvoiceID, " +
                            "SUM(CASE When PaymentModeID = 1 then Amount else 0 end) as Cash, " +
                            "SUM(CASE When PaymentModeID = 2 then Amount else 0 end) as CreditCard, " +
                            "SUM(CASE When PaymentModeID = 3 then Amount else 0 end) as AdvanceAdjusted, " +
                            "SUM(CASE When PaymentModeID = 6 then Amount else 0 end) as B2BCredit, " +
                            "SUM(CASE When PaymentModeID = 12 then Amount else 0 end) as CustomerBG, " +
                            "SUM(CASE When PaymentModeID Not IN (1,2,3,6) then Amount else 0 end) as Others " +
                            "from dbo.t_SalesInvoicePaymentMode Group by InvoiceID)b, " +
                            "(Select a.InvoiceID, InvoiceNo, InvoiceAmount, ISNULL(InstrumentNo,'') as InstrumentNo from t_SalesInvoice a " +
                            "Left Outer JOIN (select InvoiceID, InstrumentNo from t_SalesInvoicePaymentMode where PaymentModeID=6) b ON a.InvoiceID=b.InvoiceID) as c " +
                            "Where DCSID = ? and DCSType =" + (int)Dictionary.DCSType.Invoice + " and a.InvoiceID=b.InvoiceID and a.InvoiceID = c.InvoiceID and  CustomerID = " + nCustomerID + " " +
                            "Union All " +
                            "Select  DCSID,c.CustomerID, b.ApprovalNo, c.Amount,0 as CreditCard, 0 as AdvanceAdjusted,0 as B2BCredit,0 as CustomerBG, " +
                            "0 as Others,0 as InvoiceAmount,'' as  InstrumentNo " +
                            "from dbo.t_CustomerCreditApprovalCollection a, dbo.t_CustomerCreditApproval b,t_DCSDetail c " +
                            "Where a.CreditApprovalID=b.CreditApprovalID and c.InvoiceID=b.CreditApprovalID and  " +
                            "a.WarehouseID=b.WarehouseID and a.CustomerID=b.CustomerID  " +
                            "and  DCSID = ? and  a.CreateDate Between '" + _CollectionDate + "' and '" + dToDate + "' and a.CreateDate < '" + dToDate + "' and  " +
                            " DCSType =" + (int)Dictionary.DCSType.CreditCollection + " and c.CustomerID = " + nCustomerID + "" +

                            " Union All " +
                            "Select DCSID, b.CustomerID, TranNo, b.Amount,0 as CreditCard, 0 as AdvanceAdjusted,0 as B2BCredit,0 as CustomerBG,  " +
                            "0 as Others,0 as InvoiceAmount,'' as  InstrumentNo  " +
                            "From t_CustomerTran a,t_DCSDetail b " +
                            "where b.InvoiceID=a.TranID and TranTypeID=5 and a.CustomerID=b.CustomerID and  " +
                            "TranDate Between '" + _CollectionDate + "' and '" + dToDate + "'  " +
                            "and TranDate < '" + dToDate + "' and DCSID = ?  " +
                            " Union All " +
                            "Select DCSID,b.CustomerID, CertificateNo,case when PaymentModeID=1 then SUM(a.Amount) else 0 end as Cash, " +
                            "case when PaymentModeID=2 then SUM(a.Amount) else 0 end as CreditCard, " +
                            "0 as AdvanceAdjusted,0 B2BCredit,0 CustomerBG,0	Others,sum(a.Amount)	InvoiceAmount,b.InstrumentNo " +
                            "From t_DCSDetail a,(select y.CustomerID, x.* from t_ExtendedWarranty x,t_RetailConsumer y where x.ConsumerID = y.ConsumerID and x.WarehouseID = y.WarehouseID) b  " +
                            "where DCSID=? and a.CustomerID=b.CustomerID and DCSType=" + (int)Dictionary.DCSType.ExtendedWarrantyCollection + " and a.InvoiceID=b.ID  group by DCSID,b.CustomerID,CertificateNo,PaymentModeID,b.InstrumentNo";
            

            cmd.Parameters.AddWithValue("DCSID", _nDCSID);
            cmd.Parameters.AddWithValue("DCSID", _nDCSID);
            cmd.Parameters.AddWithValue("DCSID", _nDCSID);
            cmd.Parameters.AddWithValue("DCSID", _nDCSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCSDetail oDCSDetail = new DCSDetail();

                    oDCSDetail.DCSID = (int)reader["DCSID"];
                    oDCSDetail.CustomerID = (int)reader["CustomerID"];
                    oDCSDetail.InvoiceNo = (string)reader["InvoiceNo"];
                    oDCSDetail.Cash = Convert.ToDouble(reader["Cash"].ToString());
                    oDCSDetail.CreditCard = Convert.ToDouble(reader["CreditCard"].ToString());
                    oDCSDetail.AdvanceAdjusted = Convert.ToDouble(reader["AdvanceAdjusted"].ToString());
                    oDCSDetail.B2BCredit = Convert.ToDouble(reader["B2BCredit"].ToString());
                    oDCSDetail.CustomerBG = Convert.ToDouble(reader["CustomerBG"].ToString());
                    oDCSDetail.Others = Convert.ToDouble(reader["Others"].ToString());
                    oDCSDetail.Amount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oDCSDetail.InstrumentNo = (string)reader["InstrumentNo"];

                    InnerList.Add(oDCSDetail);
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
        public int GetNextNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nNextDCSNo = 0;
            try
            {
                sSql = "Select * from t_NextNo ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nNextDCSNo = int.Parse(reader["NextDCSNo"].ToString());
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nNextDCSNo;

        }

        public int GetNextDCSNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nNextDCSNo = 0;
            try
            {
                sSql = "Select NextDCSNo from t_Showroom where WarehouseID=" + Utility.WarehouseID + " ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nNextDCSNo = int.Parse(reader["NextDCSNo"].ToString());
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nNextDCSNo;

        }
        public string GetDcsPaymentDetail(int nDCSID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            string sPaymentDetail = "";
            try
            {
                sSql =
                    "Select 'Cash:'+cast(isnull(sum(case when isnull(PaymentModeType,5) = 1 then d.Amount end),0) as varchar) " +
                    "+ ', ' + " +
                    "'Card & Mobile Payment:' + cast(isnull(sum(case when isnull(PaymentModeType, 5)  in (2, 3) then d.Amount end), 0) as varchar) " +
                    "+ ', ' + " +
                    "'Credit:' + cast(isnull(sum(case when isnull(PaymentModeType, 5) = 4 then d.Amount end), 0) as varchar) " +
                    "+ ', ' + " +
                    "'Other:' + cast(isnull(sum(case when isnull(PaymentModeType, 5) = 5 then d.Amount end), 0) as varchar) as PaymentDetail " +
                    "From t_DCS a,t_DCSDetail b, t_SalesInvoice c,t_SalesInvoicePaymentMode d, t_PaymentMode e " +
                    "where DCSType = 1 and a.DCSID = b.DCSID and b.InvoiceID = c.InvoiceID and c.InvoiceID = d.InvoiceID " +
                    "and d.PaymentModeID = e.PaymentModeID and a.DCSID = " + nDCSID + "";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sPaymentDetail = (reader["PaymentDetail"].ToString());
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sPaymentDetail;

        }

        public string GetDcsPaymentDetailRT(int nDCSID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            string sPaymentDetail = "";
            try
            {
                sSql =
                    "Select 'Cash:'+cast(isnull(sum(case when isnull(PaymentModeType,5) = 1 then d.Amount end),0) as varchar) " +
                    "+ ', ' + " +
                    "'Card & Mobile Payment:' + cast(isnull(sum(case when isnull(PaymentModeType, 5)  in (2, 3) then d.Amount end), 0) as varchar) " +
                    "+ ', ' + " +
                    "'Credit:' + cast(isnull(sum(case when isnull(PaymentModeType, 5) = 4 then d.Amount end), 0) as varchar) " +
                    "+ ', ' + " +
                    "'Other:' + cast(isnull(sum(case when isnull(PaymentModeType, 5) = 5 then d.Amount end), 0) as varchar) as PaymentDetail " +
                    "From t_DCS a,t_DCSDetail b, t_SalesInvoice c,t_SalesInvoicePaymentMode d, t_PaymentMode e " +
                    "where DCSType = 1 and a.DCSID = b.DCSID and b.InvoiceID = c.InvoiceID and c.InvoiceID = d.InvoiceID " +
                    "and d.PaymentModeID = e.PaymentModeID and a.CustomerID=b.CustomerID and a.CustomerID=" + Utility.CustomerID + " and a.DCSID = " + nDCSID + "";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sPaymentDetail = (reader["PaymentDetail"].ToString());
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sPaymentDetail;

        }

        public double GetAdditionalAmtRcv(DateTime dFromDate)
        {

            DateTime dToDate = dFromDate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            double _Amount = 0;
            try
            {
                sSql = "select SUM(Amount) as Amount from t_DCS a, t_DCSDetail b Where a.DCSID=b.DCSID "+
                "and DCSType=1 and InstrumentID=101 and DCSDate between '" + dFromDate + "' and '" + dToDate + "' " +
                "and DCSDate < '" + dToDate + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else
                    {
                        _Amount = 0;
                    }
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;

        }
        public double GetAdditionalAmtRcvHO(DateTime dFromDate, int nCustomerID)
        {

            DateTime dToDate = dFromDate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            double _Amount = 0;
            try
            {
                sSql = "select isnull(SUM(Amount),0) as Amount from t_DCS a, t_DCSDetail b " +
                        "Where a.DCSID=b.DCSID and a.CustomerID=b.CustomerID   " +
                        "and a.CustomerID=" + nCustomerID + " and  "+
                        "DCSType=1 and InstrumentID=101 and  "+
                        "DCSDate between '" + dFromDate + "' and '" + dToDate + "' " +
                        "and DCSDate < '" + dToDate + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else
                    {
                        _Amount = 0;
                    }
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;

        }
        public double GetAdditionalAmtDeposit(DateTime dFromDate)
        {

            DateTime dToDate = dFromDate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            double _Amount = 0;
            try
            {
                sSql = "select SUM(Amount) as Amount from t_DCS a, t_DCSDetail b Where a.DCSID=b.DCSID " +
                "and DCSType=2 and InstrumentID=201 and DCSDate between '" + dFromDate + "' and '" + dToDate + "' " +
                "and DCSDate < '" + dToDate + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else
                    {
                        _Amount = 0;
                    }
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;

        }
        public double GetAdditionalAmtDepositHO(DateTime dFromDate, int nCustomerID)
        {

            DateTime dToDate = dFromDate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            double _Amount = 0;
            try
            {
                sSql = "select isnull(SUM(Amount),0) as Amount from t_DCS a, t_DCSDetail b  "+
                    "Where a.DCSID=b.DCSID and a.CustomerID=b.CustomerID and a.CustomerID= " + nCustomerID + "  " +
                    "and DCSType=2 and InstrumentID=201 and DCSDate between '" + dFromDate + "' and '" + dToDate + "' " +
                    "and DCSDate < '" + dToDate + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else
                    {
                        _Amount = 0;
                    }
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;

        }
        public void GetDepositDetail(int nDCSID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select InstrumentName,Amount,Account,DepositedBranch, InstrumentNo, " +
                          "  InstrumentDate, Remarks from  " +
                          " (select InstrumentName,Amount,BankAccountID,IsNull(BankBranch,'') as DepositedBranch,  " +
                          " IsNull(InstrumentNo,'') as InstrumentNo,  " +
                          " InstrumentDate, IsNull(Remarks,'') as Remarks from t_DCSDetail a, dbo.t_DCSInstrument b  " +
                          " Where a.InstrumentID=b.InstrumentID and DCSID=?) as Depo, " +
                          " (Select BankAccountID,(Name +' ['+BankAccountNo+']') as Account from  " +
                          " (select BankAccountID, BankAccountNo,BankID  from t_BankAccount) a,  " +
                          " (select BankID, Name from t_Bank)b Where a.BankID=b.BankID) as Acct " +
                          " Where Depo.BankAccountID=Acct.BankAccountID ";

            cmd.Parameters.AddWithValue("DCSID", nDCSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCSDetail oDCSDetail = new DCSDetail();

                    oDCSDetail.InstrumentName = (string)reader["InstrumentName"];
                    oDCSDetail.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDCSDetail.BankAccount = (string)reader["Account"];
                    oDCSDetail.BankBranch = (string)reader["DepositedBranch"];
                    oDCSDetail.InstrumentNo = (string)reader["InstrumentNo"];
                    oDCSDetail.InstrumentDate = (object)reader["InstrumentDate"];
                    oDCSDetail.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oDCSDetail);
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

        public void GetDepositDetailRT(int nDCSID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select InstrumentName,Amount,Account,DepositedBranch, InstrumentNo, " +
                          "  InstrumentDate, Remarks from  " +
                          " (select InstrumentName,Amount,BankAccountID,IsNull(BankBranch,'') as DepositedBranch,  " +
                          " IsNull(InstrumentNo,'') as InstrumentNo,  " +
                          " InstrumentDate, IsNull(Remarks,'') as Remarks from t_DCSDetail a, dbo.t_DCSInstrument b  " +
                          " Where and a.CustomerID=" + Utility.CustomerID + " and a.InstrumentID=b.InstrumentID and DCSID=?) as Depo, " +
                          " (Select BankAccountID,(Name +' ['+BankAccountNo+']') as Account from  " +
                          " (select BankAccountID, BankAccountNo,BankID  from t_BankAccount) a,  " +
                          " (select BankID, Name from t_Bank)b Where a.BankID=b.BankID) as Acct " +
                          " Where Depo.BankAccountID=Acct.BankAccountID ";

            cmd.Parameters.AddWithValue("DCSID", nDCSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCSDetail oDCSDetail = new DCSDetail();

                    oDCSDetail.InstrumentName = (string)reader["InstrumentName"];
                    oDCSDetail.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDCSDetail.BankAccount = (string)reader["Account"];
                    oDCSDetail.BankBranch = (string)reader["DepositedBranch"];
                    oDCSDetail.InstrumentNo = (string)reader["InstrumentNo"];
                    oDCSDetail.InstrumentDate = (object)reader["InstrumentDate"];
                    oDCSDetail.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oDCSDetail);
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
        public void GetDepositDetailHO(int nDCSID, int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select InstrumentName,Amount,Account,DepositedBranch, InstrumentNo, " +
                          " InstrumentDate, Remarks from  " +
                          " (select InstrumentName,Amount,BankAccountID,IsNull(BankBranch,'') as DepositedBranch,  " +
                          " IsNull(InstrumentNo,'') as InstrumentNo,  " +
                          " InstrumentDate, IsNull(Remarks,'') as Remarks from t_DCSDetail a, dbo.t_DCSInstrument b  " +
                          " Where a.InstrumentID=b.InstrumentID and DCSID = ? and CustomerID = ?) as Depo, " +
                          " (Select BankAccountID,(Name +' ['+BankAccountNo+']') as Account from  " +
                          " (select BankAccountID, BankAccountNo,BankID  from t_BankAccount) a,  " +
                          " (select BankID, Name from t_Bank)b Where a.BankID=b.BankID) as Acct " +
                          " Where Depo.BankAccountID=Acct.BankAccountID ";

            cmd.Parameters.AddWithValue("DCSID", nDCSID);
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCSDetail oDCSDetail = new DCSDetail();

                    oDCSDetail.InstrumentName = (string)reader["InstrumentName"];
                    oDCSDetail.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDCSDetail.BankAccount = (string)reader["Account"];
                    oDCSDetail.BankBranch = (string)reader["DepositedBranch"];
                    oDCSDetail.InstrumentNo = (string)reader["InstrumentNo"];
                    oDCSDetail.InstrumentDate = (object)reader["InstrumentDate"];
                    oDCSDetail.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oDCSDetail);
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
        public bool CheckDCSDate(DateTime dFromDate, int nCustomerID)
        {

            DateTime dToDate = dFromDate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            try
            {
                sSql = "select DCSID from t_DCS Where DCSDate Between  '" + dFromDate + "' and '" + dToDate + "' and DCSDate < '" + dToDate + "' and CustomerID=" + nCustomerID + "";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;

        }
        public void CheckDCSNo(string sDCSNo)
        {


            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            try
            {
                sSql = "select * from t_DCS Where DCSNo='" + sDCSNo + "'";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag = false;

        }

        public DateTime LastDcsDate(DateTime _dtSystemDate)
        {


            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            DateTime dtLstDCSDate = _dtSystemDate.Date;
            try
            {
                sSql = "Select isnull(max(DCSDate),getdate()-2) as DCSDate From t_DCS";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dtLstDCSDate = Convert.ToDateTime(reader["DCSDate"].ToString());
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dtLstDCSDate;

        }
    }
    public class DCSs : CollectionBase
    {
        public DCS this[int i]
        {
            get { return (DCS)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(DCS oDCS)
        {
            InnerList.Add(oDCS);
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, String sDCSCode, bool IsCheck)
        {

            DateTime _dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select * from t_DCS Where 1=1 ";

            if (!IsCheck)
            {
                sSql = sSql + " AND DCSDate between '" + dFromDate + "' AND '" + _dToDate + "' AND DCSDate < '" + _dToDate + "'";
            }

            if (sDCSCode != "")
            {
                sSql = sSql + " AND DCSNo='" + sDCSCode + "'";
            }

            sSql = sSql + " Order by DCSID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCS oDCS = new DCS();

                    oDCS.DCSID = (int)reader["DCSID"];
                    oDCS.DCSNo = (string)reader["DCSNo"];
                    oDCS.DCSDate = Convert.ToDateTime(reader["DCSDate"].ToString());
                    oDCS.CollectionAmount = Convert.ToDouble(reader["CollectionAmount"].ToString());
                    oDCS.AdditionalAmount = Convert.ToDouble(reader["AdditionalAmount"].ToString());
                    oDCS.Other_Amount_Debit = Convert.ToDouble(reader["Other_Amount_Debit"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oDCS.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oDCS.Remarks = "";
                    }
                    oDCS.CreateUserID = (int)reader["CreateUserID"];
                    oDCS.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDCS.IsUpload = (int)reader["IsUpload"];
                    oDCS.RefreshDCSDetailHO();

                    InnerList.Add(oDCS);
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

        public void RefreshPOS(DateTime dFromDate, DateTime dToDate, String sDCSCode, bool IsCheck)
        {

            DateTime _dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select * from t_DCS Where 1=1 ";

            if (!IsCheck)
            {
                sSql = sSql + " AND DCSDate between '" + dFromDate + "' AND '" + _dToDate + "' AND DCSDate < '" + _dToDate + "'";
            }

            if (sDCSCode != "")
            {
                sSql = sSql + " AND DCSNo='" + sDCSCode + "'";
            }

            sSql = sSql + " Order by DCSID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCS oDCS = new DCS();

                    oDCS.DCSID = (int)reader["DCSID"];
                    oDCS.DCSNo = (string)reader["DCSNo"];
                    oDCS.DCSDate = Convert.ToDateTime(reader["DCSDate"].ToString());
                    oDCS.CollectionAmount = Convert.ToDouble(reader["CollectionAmount"].ToString());
                    oDCS.AdditionalAmount = Convert.ToDouble(reader["AdditionalAmount"].ToString());
                    oDCS.Other_Amount_Debit = Convert.ToDouble(reader["Other_Amount_Debit"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oDCS.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oDCS.Remarks = "";
                    }
                    oDCS.CreateUserID = (int)reader["CreateUserID"];
                    oDCS.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDCS.IsUpload = (int)reader["IsUpload"];
                    oDCS.RefreshDCSDetailPOS();

                    InnerList.Add(oDCS);
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

        public void RefreshRT(DateTime dFromDate, DateTime dToDate, String sDCSCode, bool IsCheck)
        {

            DateTime _dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select * from t_DCS Where CustomerID=" + Utility.CustomerID + " ";

            if (!IsCheck)
            {
                sSql = sSql + " AND DCSDate between '" + dFromDate + "' AND '" + _dToDate + "' AND DCSDate < '" + _dToDate + "'";
            }

            if (sDCSCode != "")
            {
                sSql = sSql + " AND DCSNo='" + sDCSCode + "'";
            }

            sSql = sSql + " Order by DCSID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCS oDCS = new DCS();

                    oDCS.DCSID = (int)reader["DCSID"];
                    oDCS.DCSNo = (string)reader["DCSNo"];
                    oDCS.DCSDate = Convert.ToDateTime(reader["DCSDate"].ToString());
                    oDCS.CollectionAmount = Convert.ToDouble(reader["CollectionAmount"].ToString());
                    oDCS.AdditionalAmount = Convert.ToDouble(reader["AdditionalAmount"].ToString());
                    oDCS.Other_Amount_Debit = Convert.ToDouble(reader["Other_Amount_Debit"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oDCS.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oDCS.Remarks = "";
                    }
                    oDCS.CreateUserID = (int)reader["CreateUserID"];
                    oDCS.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDCS.IsUpload = (int)reader["IsUpload"];
                    oDCS.RefreshDCSDetailHO();

                    InnerList.Add(oDCS);
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
        public void Refresh(DateTime dFromDate)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * From (select CASE When CardType = 1 then 'VISA'When CardType = 2 then 'MASTER' " +
                           " When CardType = 3 then 'AMEX' else 'NEXUS' end as Card,Amount, Name as Bank, " +
                           " AssetName, IsNull(NoOfInstallment,0) as NoOfInstallment, IsNull(InstrumentNo,'') as InstrumentNo " +
                           " from t_SalesInvoicePaymentMode a, t_SalesInvoice b, t_Bank c,  " +
                           " (select AssetID, AssetName from t_ShowroomAsset Where AssetType=" + (int)Dictionary.ShowroomAssetType.POSMachine + ") as d " +
                           " Where PaymentModeID = 2 and " +
                           " a.InvoiceID = b.InvoiceID and InvoiceStatus = 2 and a.BankID=c.BankID and a.POSMachineID=d.AssetID " +
                           " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'" +
                           " and a.InvoiceID Not IN ( " +
                           " Select RefInvoiceID from t_SalesInvoice Where InvoiceStatus = " + (int)Dictionary.InvoiceStatus.REVERSE + " and " +
                           " InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "')  " +

                           " Union All " +
                           " Select CASE When CardType = 1 then 'VISA'When CardType = 2 then 'MASTER' " +
                           " When CardType = 3 then 'AMEX' else 'NEXUS' end as Card,Amount,Name as BankName,AssetName,0 as NoOfInstallment,InstrumentNo " +
                           " From t_ExtendedWarranty a, t_Bank b,t_ShowroomAsset c " +
                           " where a.BankID = b.BankID and a.POSMachineID = c.AssetID and IssueDate between '" + dFromDate + "' and '" + dToDate + "' " +
                           " and IssueDate < '" + dToDate + "' and PaymentModeID = " + (int)Dictionary.PaymentMode.Credit_Card + ") Main ";

            sSql = sSql + " ORDER BY Card  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCS oDCS = new DCS();

                    oDCS.CreditCardType = (string)reader["Card"];
                    oDCS.CreditCardAmount = Convert.ToDouble(reader["Amount"].ToString());
                    oDCS.BankName = (string)reader["Bank"];
                    oDCS.AssetName = (string)reader["AssetName"];
                    oDCS.InstallmentNo = (int)reader["NoOfInstallment"];
                    oDCS.Instrument = (string)reader["InstrumentNo"];

                    InnerList.Add(oDCS);
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

        public void RefreshRT(DateTime dFromDate)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * From (select CASE When CardType = 1 then 'VISA'When CardType = 2 then 'MASTER' " +
                           " When CardType = 3 then 'AMEX' else 'NEXUS' end as Card,Amount, Name as Bank, " +
                           " AssetName, IsNull(NoOfInstallment,0) as NoOfInstallment, IsNull(InstrumentNo,'') as InstrumentNo " +
                           " from t_SalesInvoicePaymentMode a, t_SalesInvoice b, t_Bank c,  " +
                           " (select AssetID, AssetName from t_ShowroomAsset Where AssetType=" + (int)Dictionary.ShowroomAssetType.POSMachine + ") as d " +
                           " Where PaymentModeID = 2 and " +
                           " a.InvoiceID = b.InvoiceID and b.WarehouseID=" + Utility.WarehouseID + " and InvoiceStatus = 2 and a.BankID=c.BankID and a.POSMachineID=d.AssetID " +
                           " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'" +
                           " and a.InvoiceID Not IN ( " +
                           " Select RefInvoiceID from t_SalesInvoice Where InvoiceStatus = " + (int)Dictionary.InvoiceStatus.REVERSE + " and " +
                           " InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "')  " +
                           " Union All " +
                           " Select CASE When CardType = 1 then 'VISA'When CardType = 2 then 'MASTER' " +
                           " When CardType = 3 then 'AMEX' else 'NEXUS' end as Card,Amount,Name as BankName,AssetName,0 as NoOfInstallment,InstrumentNo " +
                           " From t_ExtendedWarranty a, t_Bank b,t_ShowroomAsset c " +
                           " where a.WarehouseID=" + Utility.WarehouseID + " a.BankID = b.BankID and a.POSMachineID = c.AssetID and IssueDate between '" + dFromDate + "' and '" + dToDate + "' " +
                           " and IssueDate < '" + dToDate + "' and PaymentModeID = " + (int)Dictionary.PaymentMode.Credit_Card + ") Main ";

            sSql = sSql + " ORDER BY Card  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCS oDCS = new DCS();

                    oDCS.CreditCardType = (string)reader["Card"];
                    oDCS.CreditCardAmount = Convert.ToDouble(reader["Amount"].ToString());
                    oDCS.BankName = (string)reader["Bank"];
                    oDCS.AssetName = (string)reader["AssetName"];
                    oDCS.InstallmentNo = (int)reader["NoOfInstallment"];
                    oDCS.Instrument = (string)reader["InstrumentNo"];

                    InnerList.Add(oDCS);
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
        public void RefreshHO1(DateTime dFromDate, int nCustomerID)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select CASE When CardType = 1 then 'VISA'When CardType = 2 then 'MASTER' " +
                           " When CardType = 3 then 'AMEX' else 'NEXUS' end as Card,Amount, Name as Bank, " +
                           " AssetName, IsNull(NoOfInstallment,0) as NoOfInstallment, IsNull(InstrumentNo,'') as InstrumentNo " +
                           " from t_SalesInvoicePaymentMode a, t_SalesInvoice b, t_Bank c,t_Showroom H,  " +
                           " (select AssetID, AssetName from t_ShowroomAsset Where AssetType=" + (int)Dictionary.ShowroomAssetType.POSMachine + ") as d " +
                           " Where b.WarehouseID=H.WarehouseID and H.CustomerID = " + nCustomerID + " and PaymentModeID = 2 and " +
                           " a.InvoiceID = b.InvoiceID and InvoiceStatus = 2 and a.BankID=c.BankID and a.POSMachineID=d.AssetID " +
                           " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'" +
                           " and a.InvoiceID Not IN ( " +
                           " Select RefInvoiceID from t_SalesInvoice a,t_Showroom b Where a.WarehouseID=b.WarehouseID  " +
                           "and b.CustomerID=" + nCustomerID + " and InvoiceStatus = " + (int)Dictionary.InvoiceStatus.REVERSE + " and " +
                           " InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "')";

            sSql = sSql + " ORDER BY Card  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCS oDCS = new DCS();

                    oDCS.CreditCardType = (string)reader["Card"];
                    oDCS.CreditCardAmount = Convert.ToDouble(reader["Amount"].ToString());
                    oDCS.BankName = (string)reader["Bank"];
                    oDCS.AssetName = (string)reader["AssetName"];
                    oDCS.InstallmentNo = (int)reader["NoOfInstallment"];
                    oDCS.Instrument = (string)reader["InstrumentNo"];

                    InnerList.Add(oDCS);
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
        public void RefreshForHO(DateTime dFromDate, DateTime dToDate, String sDCSCode,int nCustomerID, bool IsCheck)
        {

            DateTime _dToDate = dToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select a.*,ShowroomCode from t_DCS a,t_Showroom b  "+
                          " Where a.CustomerID=b.CustomerID and 1=1 ";

            if (!IsCheck)
            {
                sSql = sSql + " AND DCSDate between '" + dFromDate + "' AND '" + _dToDate + "' AND DCSDate < '" + _dToDate + "'";
            }

            if (sDCSCode != "")
            {
                sSql = sSql + " AND DCSNo like '%" + sDCSCode + "%'";
            }
            if (nCustomerID != -1)
            {
                sSql = sSql + " AND a.CustomerID=" + nCustomerID + "";
            }

            sSql = sSql + " Order by DCSID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DCS oDCS = new DCS();

                    oDCS.DCSID = (int)reader["DCSID"];
                    oDCS.CustomerID = (int)reader["CustomerID"];
                    oDCS.ShowroomCode = (string)reader["ShowroomCode"];
                    oDCS.DCSNo = (string)reader["DCSNo"];
                    oDCS.DCSDate = Convert.ToDateTime(reader["DCSDate"].ToString());
                    oDCS.CollectionAmount = Convert.ToDouble(reader["CollectionAmount"].ToString());
                    oDCS.AdditionalAmount = Convert.ToDouble(reader["AdditionalAmount"].ToString());
                    oDCS.Other_Amount_Debit = Convert.ToDouble(reader["Other_Amount_Debit"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oDCS.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oDCS.Remarks = "";
                    }
                    oDCS.CreateUserID = (int)reader["CreateUserID"];
                    oDCS.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDCS.IsUpload = (int)reader["IsUpload"];
                    oDCS.RefreshDCSDetailHO();

                    InnerList.Add(oDCS);
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

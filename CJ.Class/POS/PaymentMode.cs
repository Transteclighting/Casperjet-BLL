// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: March 10, 2014
// Time :  10:57 AM
// Description: Class for Payment Mode
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.POS
{
    public class PaymentMode
    {
        private int _nPaymentModeID;
        private int _nPaymentModeType;
        private string _sPaymentModeName;
        private int _nIsActive;
        private int _nCreateUserID;
        private string _sSalesType;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        private bool _bFlag;
        private double _Amount;
        private int _nNoOfInstallment;
        public int NoOfInstallment
        {
            get { return _nNoOfInstallment; }
            set { _nNoOfInstallment = value; }
        }
        private int _nIsEMI;
        public int IsEMI
        {
            get { return _nIsEMI; }
            set { _nIsEMI = value; }
        }
        public int PaymentModeType
        {
            get { return _nPaymentModeType; }
            set { _nPaymentModeType = value; }
        }
        public string SalesType
        {
            get { return _sSalesType; }
            set { _sSalesType = value; }
        }
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public int PaymentModeID
        {
            get { return _nPaymentModeID; }
            set { _nPaymentModeID = value; }
        }
        private string _sBankName;
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value; }
        }
        private string _sCreditPeriod;
        public string CreditPeriod
        {
            get { return _sCreditPeriod; }
            set { _sCreditPeriod = value; }
        }
        public string PaymentModeName
        {
            get { return _sPaymentModeName; }
            set { _sPaymentModeName = value; }
        }
        private string _sEMIDetail;
        public string EMIDetail
        {
            get { return _sEMIDetail; }
            set { _sEMIDetail = value; }
        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
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
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        int nCount = 0;

        private double _Cash;
        public double Cash
        {
            get { return _Cash; }
            set { _Cash = value; }
        }
        private double _CreditCard;
        public double CreditCard
        {
            get { return _CreditCard; }
            set { _CreditCard = value; }
        }
        private double _AdvancePayment;
        public double AdvancePayment
        {
            get { return _AdvancePayment; }
            set { _AdvancePayment = value; }
        }
        private double _B2BCredit;
        public double B2BCredit
        {
            get { return _B2BCredit; }
            set { _B2BCredit = value; }
        }
        private double _Others;
        public double Others
        {
            get { return _Others; }
            set { _Others = value; }
        }
        private double _CreditLimit;
        public double CreditLimit
        {
            get { return _CreditLimit; }
            set { _CreditLimit = value; }
        }

        private double _BankGuaranty;
        public double BankGuaranty
        {
            get { return _BankGuaranty; }
            set { _BankGuaranty = value; }
        }

        private double _CurrentBalance;
        public double CurrentBalance
        {
            get { return _CurrentBalance; }
            set { _CurrentBalance = value; }
        }
        private int _nIsMandatoryInstrumentNo;
        public int IsMandatoryInstrumentNo
        {
            get { return _nIsMandatoryInstrumentNo; }
            set { _nIsMandatoryInstrumentNo = value; }
        }
        private int _nBankID;
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }
        private int _nIsFinancialInstitution;
        public int IsFinancialInstitution
        {
            get { return _nIsFinancialInstitution; }
            set { _nIsFinancialInstitution = value; }
        }
        private int _nIsReceivableItem;
        public int IsReceivableItem
        {
            get { return _nIsReceivableItem; }
            set { _nIsReceivableItem = value; }
        }

        public int IsEligableforAdvance { get; set; }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxPaymentModeID = 0;


            try
            {
                sSql = "SELECT MAX([PaymentModeID]) FROM t_PaymentMode";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPaymentModeID = 1;
                }
                else
                {
                    nMaxPaymentModeID = Convert.ToInt32(maxID) + 1;
                }
                if (_nPaymentModeID == 0)
                {
                    _nPaymentModeID = nMaxPaymentModeID;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql =
                    "insert into t_PaymentMode (PaymentModeID,PaymentModeName,PaymentModeType,IsActive,CreateUserID,CreateDate,SalesType,IsReceivableItem,IsFinancialInstitution,BankID,IsMandatoryInstrumentNo,IsEligableforAdvance)  VALUES(?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("PaymentModeID", _nPaymentModeID);
                cmd.Parameters.AddWithValue("PaymentModeName", _sPaymentModeName);
                cmd.Parameters.AddWithValue("PaymentModeType", _nPaymentModeType);
                
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("SalesType", _sSalesType);

                cmd.Parameters.AddWithValue("IsReceivableItem", _nIsReceivableItem);
                cmd.Parameters.AddWithValue("IsFinancialInstitution", _nIsFinancialInstitution);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("IsMandatoryInstrumentNo", _nIsMandatoryInstrumentNo);
                cmd.Parameters.AddWithValue("IsEligableforAdvance", IsEligableforAdvance);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void AddforPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql =
                    "insert into t_PaymentMode (PaymentModeID,PaymentModeName,IsActive,CreateUserID,CreateDate,SalesType,IsReceivableItem,IsFinancialInstitution,BankID,IsMandatoryInstrumentNo,IsEligableforAdvance,PaymentModeType)  VALUES(?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("PaymentModeID", _nPaymentModeID);
                cmd.Parameters.AddWithValue("PaymentModeName", _sPaymentModeName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("SalesType", _sSalesType);
                cmd.Parameters.AddWithValue("IsReceivableItem", _nIsReceivableItem);
                cmd.Parameters.AddWithValue("IsFinancialInstitution", _nIsFinancialInstitution);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("IsMandatoryInstrumentNo", _nIsMandatoryInstrumentNo);
                cmd.Parameters.AddWithValue("IsEligableforAdvance", IsEligableforAdvance);
                cmd.Parameters.AddWithValue("PaymentModeType", _nPaymentModeType);
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
                sSql =
                    "Update t_PaymentMode Set PaymentModeName=?,PaymentModeType=?,IsActive=?,UpdateUserID=?,UpdateDate=?,SalesType=?,IsReceivableItem=?,IsFinancialInstitution=?,BankID=?,IsMandatoryInstrumentNo=?,IsEligableforAdvance=? Where PaymentModeID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PaymentModeName", _sPaymentModeName);
                cmd.Parameters.AddWithValue("PaymentModeType", _nPaymentModeType);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("SalesType", _sSalesType);
                cmd.Parameters.AddWithValue("IsReceivableItem", _nIsReceivableItem);
                cmd.Parameters.AddWithValue("IsFinancialInstitution", _nIsFinancialInstitution);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("IsMandatoryInstrumentNo", _nIsMandatoryInstrumentNo);
                cmd.Parameters.AddWithValue("IsEligableforAdvance", IsEligableforAdvance);

                cmd.Parameters.AddWithValue("PaymentModeID", _nPaymentModeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql =
                    "Update t_PaymentMode Set PaymentModeName=?,IsActive=?,CreateUserID=?,CreateDate=?,SalesType = ?,IsReceivableItem=?,IsFinancialInstitution=?,BankID=?,IsMandatoryInstrumentNo=?,IsEligableforAdvance=?,PaymentModeType=? Where PaymentModeID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PaymentModeName", _sPaymentModeName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("SalesType", _sSalesType);
                cmd.Parameters.AddWithValue("IsReceivableItem", _nIsReceivableItem);
                cmd.Parameters.AddWithValue("IsFinancialInstitution", _nIsFinancialInstitution);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("IsMandatoryInstrumentNo", _nIsMandatoryInstrumentNo);
                cmd.Parameters.AddWithValue("IsEligableforAdvance", IsEligableforAdvance);
                cmd.Parameters.AddWithValue("PaymentModeType", _nPaymentModeType);

                cmd.Parameters.AddWithValue("PaymentModeID", _nPaymentModeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool CheckPaymentMode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            nCount = 0;
            try
            {
                sSql = "Select * from t_PaymentMode Where PaymentModeID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PaymentModeID", _nPaymentModeID);
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            nCount = 0;
            try
            {
                sSql = "Select PaymentModeID,PaymentModeName,IsActive,CreateUserID,CreateDate,isnull(IsReceivableItem,0) IsReceivableItem,isnull(IsFinancialInstitution,0) IsFinancialInstitution,isnull(BankID,-1) BankID from t_PaymentMode Where PaymentModeID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PaymentModeID", _nPaymentModeID);
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPaymentModeID = int.Parse(reader["PaymentModeID"].ToString());
                    _sPaymentModeName = (string)reader["PaymentModeName"];
                    _nIsActive = int.Parse(reader["IsActive"].ToString());
                    _nCreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    _nIsReceivableItem = (int)reader["IsReceivableItem"];
                    _nIsFinancialInstitution = (int)reader["IsFinancialInstitution"];
                    _nBankID = (int)reader["BankID"];

                    nCount++;
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetInvoicePaymentMode(DateTime dFromDate)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                //sSql = "select " +
                //    "SUM(CASE When PaymentModeID=1 then Amount else 0 end) as Cash, " +
                //    "SUM(CASE When PaymentModeID=2 then Amount else 0 end) as CreditCard, " +
                //    "SUM(CASE When PaymentModeID=3 then Amount else 0 end) as AdvancePayment, " +
                //    "SUM(CASE When PaymentModeID=6 then Amount else 0 end) as B2BCredit, " +
                //    "SUM(CASE When PaymentModeID=12 then Amount else 0 end) as BankGuaranty, " +
                //    "SUM(CASE When PaymentModeID NOT IN (1,2,3,6,12) then Amount else 0 end) as Others " +
                //    "from  " +
                //    "( " +
                //    "select a.InvoiceID, PaymentModeID, sum(Amount) as Amount  " +
                //    "from dbo.t_SalesInvoicePaymentMode a,  " +
                //    "(Select InvoiceID from t_SalesInvoice  " +
                //    "Where InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' and " +
                //    "InvoiceStatus=" + (int)Dictionary.InvoiceStatus.DELIVERED + ") b " +
                //    "Where a.InvoiceID=b.InvoiceID " +
                //    "group by a.InvoiceID, PaymentModeID " +
                //    ") a ";
                sSql = "Select sum(Cash) Cash,sum(CreditCard) CreditCard,sum(AdvancePayment) AdvancePayment, " +
                    "sum(B2BCredit) B2BCredit,sum(BankGuaranty) BankGuaranty,sum(Others) Others " +
                    "From  " +
                    "( " +
                    "select SUM(CASE When PaymentModeID=1 then Amount else 0 end) as Cash,  " +
                    "SUM(CASE When PaymentModeID=2 then Amount else 0 end) as CreditCard,  " +
                    "SUM(CASE When PaymentModeID=3 then Amount else 0 end) as AdvancePayment,  " +
                    "SUM(CASE When PaymentModeID=6 then Amount else 0 end) as B2BCredit,  " +
                    "SUM(CASE When PaymentModeID=12 then Amount else 0 end) as BankGuaranty,  " +
                    "SUM(CASE When PaymentModeID NOT IN (1,2,3,6,12) then Amount else 0 end) as Others  " +
                    "from   " +
                    "(  " +
                    "select a.InvoiceID, PaymentModeID, sum(Amount) as Amount   " +
                    "from dbo.t_SalesInvoicePaymentMode a,   " +
                    "(Select InvoiceID from t_SalesInvoice   " +
                    "Where InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' and   " +
                    "InvoiceStatus =" + (int)Dictionary.InvoiceStatus.DELIVERED + ") b  " +
                    "Where a.InvoiceID=b.InvoiceID  " +
                    "group by a.InvoiceID, PaymentModeID  " +
                    ") a  " +
                    "Union All " +
                    "Select sum(Cash) Cash,sum(CreditCard) CreditCard,0 as AdvancePayment,0 as B2BCredit,0 as BankGuaranty,0 as Others From  " +
                    "( " +
                    "Select case when PaymentModeID=1 then sum(Amount) else 0 end as Cash, " +
                    "case when PaymentModeID=2 then sum(Amount) else 0 end as CreditCard  From t_ExtendedWarranty where IssueDate Between '" + dFromDate + "' and '" + dToDate + "' " +
                    "and IssueDate<'" + dToDate + "' group by PaymentModeID " +
                    ") a  " +
                    ") Main ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    if (reader["Cash"] != DBNull.Value)
                    {
                        _Cash = Convert.ToDouble(reader["Cash"].ToString());
                    }
                    else
                    {
                        _Cash = 0;
                    }
                    if (reader["CreditCard"] != DBNull.Value)
                    {
                        _CreditCard = Convert.ToDouble(reader["CreditCard"].ToString());
                    }
                    else
                    {
                        _CreditCard = 0;
                    }
                    if (reader["AdvancePayment"] != DBNull.Value)
                    {
                        _AdvancePayment = Convert.ToDouble(reader["AdvancePayment"].ToString());
                    }
                    else
                    {
                        _AdvancePayment = 0;
                    }

                    if (reader["B2BCredit"] != DBNull.Value)
                    {
                        _B2BCredit = Convert.ToDouble(reader["B2BCredit"].ToString());
                    }
                    else
                    {
                        _B2BCredit = 0;
                    }
                    if (reader["BankGuaranty"] != DBNull.Value)
                    {
                        _BankGuaranty = Convert.ToDouble(reader["BankGuaranty"].ToString());
                    }
                    else
                    {
                        _BankGuaranty = 0;
                    }

                    if (reader["Others"] != DBNull.Value)
                    {
                        _Others = Convert.ToDouble(reader["Others"].ToString());
                    }
                    else
                    {
                        _Others = 0;
                    }

                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetInvoicePaymentModeRT(DateTime dFromDate)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "Select sum(Cash) Cash,sum(CreditCard) CreditCard,sum(AdvancePayment) AdvancePayment, " +
                    "sum(B2BCredit) B2BCredit,sum(BankGuaranty) BankGuaranty,sum(Others) Others " +
                    "From  " +
                    "( " +
                    "select SUM(CASE When PaymentModeID=1 then Amount else 0 end) as Cash,  " +
                    "SUM(CASE When PaymentModeID=2 then Amount else 0 end) as CreditCard,  " +
                    "SUM(CASE When PaymentModeID=3 then Amount else 0 end) as AdvancePayment,  " +
                    "SUM(CASE When PaymentModeID=6 then Amount else 0 end) as B2BCredit,  " +
                    "SUM(CASE When PaymentModeID=12 then Amount else 0 end) as BankGuaranty,  " +
                    "SUM(CASE When PaymentModeID NOT IN (1,2,3,6,12) then Amount else 0 end) as Others  " +
                    "from   " +
                    "(  " +
                    "select a.InvoiceID, PaymentModeID, sum(Amount) as Amount   " +
                    "from dbo.t_SalesInvoicePaymentMode a,   " +
                    "(Select InvoiceID from t_SalesInvoice   " +
                    "Where WarehouseID=" + Utility.WarehouseID + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' and   " +
                    "InvoiceStatus =" + (int)Dictionary.InvoiceStatus.DELIVERED + ") b  " +
                    "Where a.InvoiceID=b.InvoiceID  " +
                    "group by a.InvoiceID, PaymentModeID  " +
                    ") a  " +
                    "Union All " +
                    "Select sum(Cash) Cash,sum(CreditCard) CreditCard,0 as AdvancePayment,0 as B2BCredit,0 as BankGuaranty,0 as Others From  " +
                    "( " +
                    "Select case when PaymentModeID=1 then sum(Amount) else 0 end as Cash, " +
                    "case when PaymentModeID=2 then sum(Amount) else 0 end as CreditCard  From t_ExtendedWarranty where WarehouseID=" + Utility.WarehouseID + " and IssueDate Between '" + dFromDate + "' and '" + dToDate + "' " +
                    "and IssueDate<'" + dToDate + "' group by PaymentModeID " +
                    ") a  " +
                    ") Main ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    if (reader["Cash"] != DBNull.Value)
                    {
                        _Cash = Convert.ToDouble(reader["Cash"].ToString());
                    }
                    else
                    {
                        _Cash = 0;
                    }
                    if (reader["CreditCard"] != DBNull.Value)
                    {
                        _CreditCard = Convert.ToDouble(reader["CreditCard"].ToString());
                    }
                    else
                    {
                        _CreditCard = 0;
                    }
                    if (reader["AdvancePayment"] != DBNull.Value)
                    {
                        _AdvancePayment = Convert.ToDouble(reader["AdvancePayment"].ToString());
                    }
                    else
                    {
                        _AdvancePayment = 0;
                    }

                    if (reader["B2BCredit"] != DBNull.Value)
                    {
                        _B2BCredit = Convert.ToDouble(reader["B2BCredit"].ToString());
                    }
                    else
                    {
                        _B2BCredit = 0;
                    }
                    if (reader["BankGuaranty"] != DBNull.Value)
                    {
                        _BankGuaranty = Convert.ToDouble(reader["BankGuaranty"].ToString());
                    }
                    else
                    {
                        _BankGuaranty = 0;
                    }

                    if (reader["Others"] != DBNull.Value)
                    {
                        _Others = Convert.ToDouble(reader["Others"].ToString());
                    }
                    else
                    {
                        _Others = 0;
                    }

                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetInvoicePaymentModeHO(DateTime dFromDate, int nCustomerID)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "select " +
                    "SUM(CASE When PaymentModeID=1 then Amount else 0 end) as Cash, " +
                    "SUM(CASE When PaymentModeID=2 then Amount else 0 end) as CreditCard, " +
                    "SUM(CASE When PaymentModeID=3 then Amount else 0 end) as AdvancePayment, " +
                    "SUM(CASE When PaymentModeID=6 then Amount else 0 end) as B2BCredit, " +
                    "SUM(CASE When PaymentModeID NOT IN (1,2,3,6) then Amount else 0 end) as Others " +
                    "from  " +
                    "( " +
                    "select a.InvoiceID, PaymentModeID, sum(Amount) as Amount  " +
                    "from dbo.t_SalesInvoicePaymentMode a,  " +
                    "(Select InvoiceID from t_SalesInvoice  a,t_Showroom b " +
                    "Where  a.WarehouseID=b.WarehouseID and b.CustomerID = " + nCustomerID + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' and " +
                    "InvoiceStatus=" + (int)Dictionary.InvoiceStatus.DELIVERED + ") b " +
                    "Where a.InvoiceID=b.InvoiceID " +
                    "group by a.InvoiceID, PaymentModeID " +
                    ") a ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    if (reader["Cash"] != DBNull.Value)
                    {
                        _Cash = Convert.ToDouble(reader["Cash"].ToString());
                    }
                    else
                    {
                        _Cash = 0;
                    }
                    if (reader["CreditCard"] != DBNull.Value)
                    {
                        _CreditCard = Convert.ToDouble(reader["CreditCard"].ToString());
                    }
                    else
                    {
                        _CreditCard = 0;
                    }
                    if (reader["AdvancePayment"] != DBNull.Value)
                    {
                        _AdvancePayment = Convert.ToDouble(reader["AdvancePayment"].ToString());
                    }
                    else
                    {
                        _AdvancePayment = 0;
                    }

                    if (reader["B2BCredit"] != DBNull.Value)
                    {
                        _B2BCredit = Convert.ToDouble(reader["B2BCredit"].ToString());
                    }
                    else
                    {
                        _B2BCredit = 0;
                    }

                    if (reader["Others"] != DBNull.Value)
                    {
                        _Others = Convert.ToDouble(reader["Others"].ToString());
                    }
                    else
                    {
                        _Others = 0;
                    }

                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public double GetRevInvCard(DateTime dFromDate)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            double _Amount = 0;
            try
            {
                sSql = "select Sum(Amount) as Amount from t_SalesInvoicePaymentMode a, " +
                " t_SalesInvoice b Where a.InvoiceID=b.InvoiceID " +
                " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' " +
                " and InvoiceStatus=" + (int)Dictionary.InvoiceStatus.REVERSE + " and PaymentModeID=" + (int)Dictionary.PaymentMode.Credit_Card + " ";

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

        public double GetRevInvCardRT(DateTime dFromDate)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            double _Amount = 0;
            try
            {
                sSql = "select Sum(Amount) as Amount from t_SalesInvoicePaymentMode a, " +
                " t_SalesInvoice b Where a.InvoiceID=b.InvoiceID and b.WarehouseID=" + Utility.WarehouseID + " " +
                " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' " +
                " and InvoiceStatus=" + (int)Dictionary.InvoiceStatus.REVERSE + " and PaymentModeID=" + (int)Dictionary.PaymentMode.Credit_Card + " ";

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
        public double GetRevInvBG(DateTime dFromDate)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            double _Amount = 0;
            try
            {
                sSql = "select Sum(Amount) as Amount from t_SalesInvoicePaymentMode a, " +
                " t_SalesInvoice b Where a.InvoiceID=b.InvoiceID " +
                " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' " +
                " and InvoiceStatus=" + (int)Dictionary.InvoiceStatus.REVERSE + " and PaymentModeID=" + (int)Dictionary.PaymentMode.Customer_BG + " ";

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

        public double GetRevInvBGRT(DateTime dFromDate)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            double _Amount = 0;
            try
            {
                sSql = "select Sum(Amount) as Amount from t_SalesInvoicePaymentMode a, " +
                " t_SalesInvoice b Where WarehouseID=" + Utility.WarehouseID + " and a.InvoiceID=b.InvoiceID " +
                " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' " +
                " and InvoiceStatus=" + (int)Dictionary.InvoiceStatus.REVERSE + " and PaymentModeID=" + (int)Dictionary.PaymentMode.Customer_BG + " ";

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
        public double GetRevInvCardHO(DateTime dFromDate, int nCustomerID)
        {
            DateTime dToDate = dFromDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            double _Amount = 0;
            try
            {
                sSql = "select isnull(Sum(Amount),0) as Amount from t_SalesInvoicePaymentMode a, " +
                " t_SalesInvoice b,t_Showroom c Where a.InvoiceID=b.InvoiceID and b.CustomerID=c.CustomerID and c.CustomerID=" + nCustomerID + " " +
                " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "' " +
                " and InvoiceStatus=" + (int)Dictionary.InvoiceStatus.REVERSE + " and PaymentModeID=" + (int)Dictionary.PaymentMode.Credit_Card + " ";

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
        public double CheckBGAmount(int nCustomerID, DateTime dtInvoiceDate, double _Amount)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            nCount = 0;
            double _Balance = 0;
            try
            {
                sSql = "Select (BGAmount+CurrentBalance+CreditLimit)-" + _Amount + " Balance From  " +
                        "(  " +
                        "Select sum(CurrentBalance) CurrentBalance,Sum(BGAmount) BGAmount,sum(CreditLimit) CreditLimit   " +
                        "From   " +
                        "(  " +
                        "Select isnull(sum(CurrentBalance),0) CurrentBalance, 0 BGAmount,0 CreditLimit   " +
                        "From t_CustomerAccount where CustomerID= " + nCustomerID + "  " +
                        "Union All  " +
                        "Select 0 CurrentBalance,isnull(Sum(BGAmount),0) as BGAmount,0 CreditLimit   " +
                        "From t_CustomerBankGuaranty where EffectiveDate<='" + dtInvoiceDate + "'  " +
                        "and ExpiryDate>='" + dtInvoiceDate + "' and IsActive=1 and CustomerID=" + nCustomerID + "  " +
                        "Union All   " +
                        "Select  0 CurrentBalance,0 as BGAmount,isnull(MaxCreditLimit,0) CreditLimit  " +
                        "From t_CustomerCreditLimit where CreditLimitID = (  " +
                        "Select max(CreditLimitID) CreditLimitID From  " +
                        "(  " +
                        "select CreditLimitID, CustomerID, DATEADD(dd, 0, DATEDIFF(dd, 0, EffectiveDate)) EffectiveDate,  " +
                        "DATEADD(dd, 0, DATEDIFF(dd, 0, ExpiryDate)) ExpiryDate, MaxCreditLimit from t_CustomerCreditLimit  " +
                        ") a where Customerid = " + nCustomerID + " and EffectiveDate <= '" + dtInvoiceDate + "'  " +
                        "and ExpiryDate >= '" + dtInvoiceDate + "')  " +
                        ") a   " +
                        ") Main";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Balance = Convert.ToDouble(reader["Balance"].ToString());
                    nCount++;
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Balance;
        }
        public void GetCustomerBalance(DateTime dInvoiceDate, int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Select sum(CurrentBalance) CurrentBalance,sum(BGAmount) BankGuaranty,sum(CreditLimit) CreditLimit From  " +
                       "(  " +
                       "Select isnull(Sum(CurrentBalance),0) CurrentBalance,0 BGAmount,0 CreditLimit   " +
                       "From t_CustomerAccount where CustomerID=" + nCustomerID + "  " +
                       "Union All  " +
                       "Select 0 CurrentBalance,isnull(Sum(BGAmount),0) as BGAmount,0 CreditLimit     " +
                       "From t_CustomerBankGuaranty where EffectiveDate<='" + dInvoiceDate + "'    " +
                       "and ExpiryDate>='" + dInvoiceDate + "' and IsActive=1 and CustomerID= " + nCustomerID + "  " +
                       "Union All  " +
                       "Select  0 CurrentBalance,0 as BGAmount,isnull(MaxCreditLimit,0) CreditLimit  " +
                       "From t_CustomerCreditLimit where CreditLimitID = (  " +
                       "Select max(CreditLimitID) CreditLimitID From  " +
                       "(  " +
                       "select CreditLimitID, CustomerID, DATEADD(dd, 0, DATEDIFF(dd, 0, EffectiveDate)) EffectiveDate,  " +
                       "DATEADD(dd, 0, DATEDIFF(dd, 0, ExpiryDate)) ExpiryDate, MaxCreditLimit from t_CustomerCreditLimit  " +
                       ") a where Customerid = " + nCustomerID + " and EffectiveDate <= '" + dInvoiceDate + "'  " +
                       "and ExpiryDate >= '" + dInvoiceDate + "')  " +
                       ") Main";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    if (reader["CurrentBalance"] != DBNull.Value)
                    {
                        _CurrentBalance = Convert.ToDouble(reader["CurrentBalance"].ToString());
                    }
                    else
                    {
                        _CurrentBalance = 0;
                    }
                    if (reader["BankGuaranty"] != DBNull.Value)
                    {
                        _BankGuaranty = Convert.ToDouble(reader["BankGuaranty"].ToString());
                    }
                    else
                    {
                        _BankGuaranty = 0;
                    }

                    if (reader["CreditLimit"] != DBNull.Value)
                    {
                        _CreditLimit = Convert.ToDouble(reader["CreditLimit"].ToString());
                    }
                    else
                    {
                        _CreditLimit = 0;
                    }
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        
    }
    public class PaymentModes : CollectionBase
    {
        public PaymentMode this[int i]
        {
            get { return (PaymentMode)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public int GetIndex(int nPaymentModeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].PaymentModeID == nPaymentModeID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Add(PaymentMode oPaymentMode)
        {
            InnerList.Add(oPaymentMode);
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT PaymentModeID,PaymentModeName,IsActive,CreateUserID,CreateDate,SalesType, " +
                        "isnull(IsReceivableItem, 0) IsReceivableItem,isnull(IsFinancialInstitution, 0) IsFinancialInstitution, " +
                        "isnull(a.BankID, -1) BankID,isnull(b.Name, '') as BankName, " +
                        "isnull(IsMandatoryInstrumentNo, 0) IsMandatoryInstrumentNo,isnull(IsEligableforAdvance,0) IsEligableforAdvance,isnull(PaymentModeType," + (int)Dictionary.PaymentModeType.Other + ") PaymentModeType FROM t_PaymentMode a " +
                        "left Outer join t_Bank b on a.BankID = b.BankID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    PaymentMode oPaymentMode = new PaymentMode();
                    oPaymentMode.PaymentModeID = (int)reader["PaymentModeID"];
                    oPaymentMode.PaymentModeName = (string)reader["PaymentModeName"];
                    oPaymentMode.IsActive = (int)reader["IsActive"];
                    oPaymentMode.CreateUserID = (int)reader["CreateUserID"];
                    oPaymentMode.CreateDate = (DateTime)reader["CreateDate"];
                    oPaymentMode.SalesType = (string)reader["SalesType"];
                    oPaymentMode.IsReceivableItem = (int)reader["IsReceivableItem"];
                    oPaymentMode.IsFinancialInstitution = (int)reader["IsFinancialInstitution"];
                    oPaymentMode.BankID = (int)reader["BankID"];
                    oPaymentMode.BankName = (string)reader["BankName"];
                    oPaymentMode.IsMandatoryInstrumentNo = (int)reader["IsMandatoryInstrumentNo"];
                    oPaymentMode.IsEligableforAdvance = (int) reader["IsEligableforAdvance"];
                    oPaymentMode.PaymentModeType = (int)reader["PaymentModeType"];
                    InnerList.Add(oPaymentMode);
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


        public void RefreshBySalesType(int nSalesType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT PaymentModeID,PaymentModeName,IsActive,isnull(IsReceivableItem,0) IsReceivableItem,isnull(IsFinancialInstitution,0) IsFinancialInstitution,isnull(BankID,-1) BankID,isnull(IsMandatoryInstrumentNo,0) IsMandatoryInstrumentNo FROM t_PaymentMode where IsActive=1 and SalesType like '%" + nSalesType + "%'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    PaymentMode oPaymentMode = new PaymentMode();

                    oPaymentMode.PaymentModeID = (int)reader["PaymentModeID"];
                    oPaymentMode.PaymentModeName = (string)reader["PaymentModeName"];
                    oPaymentMode.IsActive = (int)reader["IsActive"];
                    oPaymentMode.IsReceivableItem = (int)reader["IsReceivableItem"];
                    oPaymentMode.IsFinancialInstitution = (int)reader["IsFinancialInstitution"];
                    oPaymentMode.BankID = (int)reader["BankID"];
                    oPaymentMode.IsMandatoryInstrumentNo= (int)reader["IsMandatoryInstrumentNo"];
                    InnerList.Add(oPaymentMode);
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
        public void GetPaymentModeForAdvance(int nSalesType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql =
                "SELECT PaymentModeID,PaymentModeName,IsActive,isnull(IsReceivableItem,0) IsReceivableItem,isnull(IsFinancialInstitution,0) IsFinancialInstitution,isnull(BankID,-1) BankID,isnull(IsMandatoryInstrumentNo,0) IsMandatoryInstrumentNo,  " +
                "isnull(IsEligableforAdvance,0) IsEligableforAdvance,isnull(PaymentModeType," + (int)Dictionary.PaymentModeType.Other + ") PaymentModeType FROM t_PaymentMode where IsActive=1 and SalesType like '%" +
                nSalesType + "%' and isnull(IsEligableforAdvance,0)=" + (int)Dictionary.YesOrNoStatus.YES + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    PaymentMode oPaymentMode = new PaymentMode();

                    oPaymentMode.PaymentModeID = (int)reader["PaymentModeID"];
                    oPaymentMode.PaymentModeName = (string)reader["PaymentModeName"];
                    oPaymentMode.IsActive = (int)reader["IsActive"];
                    oPaymentMode.IsReceivableItem = (int)reader["IsReceivableItem"];
                    oPaymentMode.IsFinancialInstitution = (int)reader["IsFinancialInstitution"];
                    oPaymentMode.BankID = (int)reader["BankID"];
                    oPaymentMode.IsMandatoryInstrumentNo = (int)reader["IsMandatoryInstrumentNo"];
                    oPaymentMode.IsEligableforAdvance = (int)reader["IsEligableforAdvance"];
                    oPaymentMode.PaymentModeType = (int)reader["PaymentModeType"];
                    InnerList.Add(oPaymentMode);
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

        public void GetPaymentByInvoice(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "Select a.PaymentModeID,PaymentModeName,sum(Amount) Amount  " +
            //            "From t_SalesInvoicePaymentModeNew a,t_PaymentMode b  " +
            //            "where a.PaymentModeID = b.PaymentModeID and InvoiceID = " + nInvoiceID + "  " +
            //            "group by a.PaymentModeID,PaymentModeName";

            string sSql = @"Select a.PaymentModeID,PaymentModeName,isnull(CreditPeriod,'') CreditPeriod,sum(Amount) Amount   
                        From t_SalesInvoicePaymentModeNew a
                        join t_PaymentMode b on a.PaymentModeID = b.PaymentModeID 
                        left outer join 
                        (
                        Select ApprovalNo,'For '+cast(isnull(CreditPeriod,0) as varchar)+' days' CreditPeriod 
                        from t_CustomerCreditApproval
                        ) c on a.InstrumentNo=c.ApprovalNo
                        where  InvoiceID =  " + nInvoiceID + @"
                        group by a.PaymentModeID,PaymentModeName,isnull(CreditPeriod,'')";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    PaymentMode oPaymentMode = new PaymentMode();

                    oPaymentMode.PaymentModeID = (int)reader["PaymentModeID"];
                    oPaymentMode.PaymentModeName = (string)reader["PaymentModeName"];
                    oPaymentMode.Amount = (double)reader["Amount"];
                    oPaymentMode.CreditPeriod = (string)reader["CreditPeriod"];

                    InnerList.Add(oPaymentMode);
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

        public void GetEMiDetail(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select 'PCode:' + ProductCode + '|Bank:' + Name +  " +
                        "'|EMI:' + Cast(NoOfInstallment as varchar) + '|Amount:' + Cast(Amount as varchar) EMIDetail  " +
                        "From t_SalesInvoicePaymentModeNew a, t_Bank b,t_Product c  " +
                        "where a.IsEMI = 1 and A.BankID = b.BankID and a.ProductID = c.ProductID  " +
                        "and InvoiceID = " + nInvoiceID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    PaymentMode oPaymentMode = new PaymentMode();
                    oPaymentMode.EMIDetail = (string)reader["EMIDetail"];

                    InnerList.Add(oPaymentMode);
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

        public void GetPaymentMode(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select PaymentModeName,IsEMI,NoOfInstallment,sum(Amount) Amount From ( "+
                        "Select case when PaymentModeID=2 then b.Name+' ('+CardCategory+')' else PaymentModeName end as PaymentModeName,  " +
                        "Amount,isnull(a.IsEMI,0) IsEMI,isnull(NoOfInstallment,0) NoOfInstallment From   " +
                        "(  " +
                        "Select InvoiceID,PaymentModeName,Amount,IsEMI,NoOfInstallment,a.BankID,a.PaymentModeID,  " +
                        "case when CardCategory=1 and a.PaymentModeID=2 then 'Debit Card'   " +
                        "when CardCategory=2 and a.PaymentModeID=2 then 'Credit Card'   " +
                        "else '' end as CardCategory   " +
                        "From t_SalesInvoicePaymentMode a,t_PaymentMode b   " +
                        "where a.PaymentModeID=b.PaymentModeID   " +
                        ")  a  " +
                        "Left Outer Join   " +
                        "(  " +
                        "Select * From t_Bank   " +
                        ") b on a.BankID=b.BankID where InvoiceID=" + nInvoiceID + " ) Main group by PaymentModeName,IsEMI,NoOfInstallment";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PaymentMode oPaymentMode = new PaymentMode();
                    oPaymentMode.PaymentModeName = (string)reader["PaymentModeName"];
                    oPaymentMode.Amount = (double)reader["Amount"];
                    oPaymentMode.IsEMI = (int)reader["IsEMI"];
                    oPaymentMode.NoOfInstallment = (int)reader["NoOfInstallment"];
                    InnerList.Add(oPaymentMode);
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
    }
}

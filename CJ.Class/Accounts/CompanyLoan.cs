// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Dec 13, 2018
// Time : 02:39 PM
// Description: Class for CompanyLoan.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class CompanyLoan
    {
        private int _nID;
        private int _nCompanyID;
        private string _sLoanNumber;
        private int _nLoanType;
        private int _nBankID;
        private string _sLCNumber;
        private DateTime _dReceiveDate;
        private double _Amount;
        private string _sCurrency;
        private double _ConversionRate;
        private double _BDTAmount;
        private double _CurrentInterestRate;
        private int _nDurationDays;
        private DateTime _dExpireDate;
        private string _sPurposeOfLoan;
        private string _sSupplyType;
        private int _nStatus;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        private string _sBankCode;
        private string _sBankName;
        private string _sCreateUser;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        // <summary>
        // Get set property for LoanNumber
        // </summary>
        public string LoanNumber
        {
            get { return _sLoanNumber; }
            set { _sLoanNumber = value.Trim(); }
        }

        // <summary>
        // Get set property for LoanType
        // </summary>
        public int LoanType
        {
            get { return _nLoanType; }
            set { _nLoanType = value; }
        }

        // <summary>
        // Get set property for BankID
        // </summary>
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }

        // <summary>
        // Get set property for LCNumber
        // </summary>
        public string LCNumber
        {
            get { return _sLCNumber; }
            set { _sLCNumber = value.Trim(); }
        }

        // <summary>
        // Get set property for ReceiveDate
        // </summary>
        public DateTime ReceiveDate
        {
            get { return _dReceiveDate; }
            set { _dReceiveDate = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        // <summary>
        // Get set property for Currency
        // </summary>
        public string Currency
        {
            get { return _sCurrency; }
            set { _sCurrency = value.Trim(); }
        }

        // <summary>
        // Get set property for ConversionRate
        // </summary>
        public double ConversionRate
        {
            get { return _ConversionRate; }
            set { _ConversionRate = value; }
        }

        // <summary>
        // Get set property for BDTAmount
        // </summary>
        public double BDTAmount
        {
            get { return _BDTAmount; }
            set { _BDTAmount = value; }
        }

        // <summary>
        // Get set property for CurrentInterestRate
        // </summary>
        public double CurrentInterestRate
        {
            get { return _CurrentInterestRate; }
            set { _CurrentInterestRate = value; }
        }

        // <summary>
        // Get set property for DurationDays
        // </summary>
        public int DurationDays
        {
            get { return _nDurationDays; }
            set { _nDurationDays = value; }
        }

        // <summary>
        // Get set property for ExpireDate
        // </summary>
        public DateTime ExpireDate
        {
            get { return _dExpireDate; }
            set { _dExpireDate = value; }
        }

        // <summary>
        // Get set property for PurposeOfLoan
        // </summary>
        public string PurposeOfLoan
        {
            get { return _sPurposeOfLoan; }
            set { _sPurposeOfLoan = value.Trim(); }
        }

        // <summary>
        // Get set property for SupplyType
        // </summary>
        public string SupplyType
        {
            get { return _sSupplyType; }
            set { _sSupplyType = value.Trim(); }
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
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        public string BankCode
        {
            get { return _sBankCode; }
            set { _sBankCode = value; }
        }
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value; }
        }
        public string CreateUser
        {
            get { return _sCreateUser; }
            set { _sCreateUser = value; }
        }

        private double _TotalPayment;
        public double TotalPayment
        {
            get { return _TotalPayment; }
            set { _TotalPayment = value; }
        }

        private double _PayablePrincipal;
        public double PayablePrincipal
        {
            get { return _PayablePrincipal; }
            set { _PayablePrincipal = value; }
        }

        private double _PayableInterest;
        public double PayableInterest
        {
            get { return _PayableInterest; }
            set { _PayableInterest = value; }
        }

        private object _LastPaymentDate;
        public object LastPaymentDate
        {
            get { return _LastPaymentDate; }
            set { _LastPaymentDate = value; }
        }

        private object _LastQuarterEndDate;
        public object LastQuarterEndDate
        {
            get { return _LastQuarterEndDate; }
            set { _LastQuarterEndDate = value; }
        }


        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CompanyLoan";
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
                sSql = "INSERT INTO t_CompanyLoan (ID, CompanyID, LoanNumber, LoanType, BankID, "+
                    " LCNumber, ReceiveDate, Amount, Currency, ConversionRate, BDTAmount, CurrentInterestRate, "+
                    " DurationDays, ExpireDate, PurposeOfLoan, SupplyType, Status, Remarks, CreateUserID, CreateDate, "+
                    " TotalPayment, PayablePrincipal, PayableInterest, LastPaymentDate, LastQuarterEndDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("LoanNumber", _sLoanNumber);
                cmd.Parameters.AddWithValue("LoanType", _nLoanType);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("LCNumber", _sLCNumber);
                cmd.Parameters.AddWithValue("ReceiveDate", _dReceiveDate);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Currency", _sCurrency);
                cmd.Parameters.AddWithValue("ConversionRate", _ConversionRate);
                cmd.Parameters.AddWithValue("BDTAmount", _BDTAmount);
                cmd.Parameters.AddWithValue("CurrentInterestRate", _CurrentInterestRate);
                cmd.Parameters.AddWithValue("DurationDays", _nDurationDays);
                cmd.Parameters.AddWithValue("ExpireDate", _dExpireDate);
                cmd.Parameters.AddWithValue("PurposeOfLoan", _sPurposeOfLoan);
                cmd.Parameters.AddWithValue("SupplyType", _sSupplyType);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("TotalPayment", _TotalPayment);
                cmd.Parameters.AddWithValue("PayablePrincipal", _PayablePrincipal);
                cmd.Parameters.AddWithValue("PayableInterest", _PayableInterest);
                cmd.Parameters.AddWithValue("LastPaymentDate", _LastPaymentDate);
                cmd.Parameters.AddWithValue("LastQuarterEndDate", _LastQuarterEndDate);

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
                sSql = "UPDATE t_CompanyLoan SET CompanyID = ?, LoanType = ?, BankID = ?, LCNumber = ?, ReceiveDate = ?, Amount = ?, Currency = ?, ConversionRate = ?, BDTAmount = ?, CurrentInterestRate = ?, DurationDays = ?, ExpireDate = ?, PurposeOfLoan = ?, SupplyType = ?,  Remarks = ?, UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("LoanType", _nLoanType);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("LCNumber", _sLCNumber);
                cmd.Parameters.AddWithValue("ReceiveDate", _dReceiveDate);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Currency", _sCurrency);
                cmd.Parameters.AddWithValue("ConversionRate", _ConversionRate);
                cmd.Parameters.AddWithValue("BDTAmount", _BDTAmount);
                cmd.Parameters.AddWithValue("CurrentInterestRate", _CurrentInterestRate);
                cmd.Parameters.AddWithValue("DurationDays", _nDurationDays);
                cmd.Parameters.AddWithValue("ExpireDate", _dExpireDate);
                cmd.Parameters.AddWithValue("PurposeOfLoan", _sPurposeOfLoan);
                cmd.Parameters.AddWithValue("SupplyType", _sSupplyType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdatePayment()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CompanyLoan SET PayablePrincipal = PayablePrincipal - ?, TotalPayment = TotalPayment + ?, PayableInterest = PayableInterest + ?, LastPaymentDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PayablePrincipal", _PayablePrincipal);
                cmd.Parameters.AddWithValue("TotalPayment", _TotalPayment);
                cmd.Parameters.AddWithValue("PayableInterest", _PayableInterest);
                cmd.Parameters.AddWithValue("LastPaymentDate", _LastPaymentDate);               

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateQuarterEndHeader()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CompanyLoan SET PayablePrincipal = PayablePrincipal + ?, PayableInterest = ?, LastQuarterEndDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PayablePrincipal", _PayablePrincipal);
                cmd.Parameters.AddWithValue("PayableInterest", _PayableInterest);
                cmd.Parameters.AddWithValue("LastQuarterEndDate", _LastQuarterEndDate);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_CompanyLoanInterest WHERE [LoanID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LoanID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                sSql = "DELETE FROM t_CompanyLoanHistory WHERE [LoanID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LoanID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                sSql = "DELETE FROM t_CompanyLoan WHERE [ID]=?";
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

        public void StatusChange()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_CompanyLoan SET Status = ? WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateLoanNumber()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_CompanyLoan SET LoanNumber = ? WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LoanNumber", _sLoanNumber);
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM t_CompanyLoan where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _sLoanNumber = (string)reader["LoanNumber"];
                    _nLoanType = (int)reader["LoanType"];
                    _nBankID = (int)reader["BankID"];
                    _sLCNumber = (string)reader["LCNumber"];
                    _dReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _sCurrency = (string)reader["Currency"];
                    _ConversionRate = Convert.ToDouble(reader["ConversionRate"].ToString());
                    _BDTAmount = Convert.ToDouble(reader["BDTAmount"].ToString());
                    _CurrentInterestRate = Convert.ToDouble(reader["CurrentInterestRate"].ToString());
                    _nDurationDays = (int)reader["DurationDays"];
                    _dExpireDate = Convert.ToDateTime(reader["ExpireDate"].ToString());
                    _sPurposeOfLoan = (string)reader["PurposeOfLoan"];
                    _sSupplyType = (string)reader["SupplyType"];
                    _nStatus = (int)reader["Status"];
                    _sRemarks = (string)reader["Remarks"];
                    if (reader["TotalPayment"] != DBNull.Value)
                        _TotalPayment = Convert.ToDouble(reader["TotalPayment"]);
                    else
                        _TotalPayment = 0;
                    if (reader["PayablePrincipal"] != DBNull.Value)
                        _PayablePrincipal = Convert.ToDouble(reader["PayablePrincipal"]);
                    else
                        _PayablePrincipal = 0;
                    if (reader["PayableInterest"] != DBNull.Value)
                        _PayableInterest = Convert.ToDouble(reader["PayableInterest"]);
                    else
                        _PayableInterest = 0;
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"]);

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public object GetLastPaymentDate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_CompanyLoan where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["LastPaymentDate"] != DBNull.Value)
                        _LastPaymentDate = reader["LastPaymentDate"];
                    else _LastPaymentDate = null;
                }
                
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

           return _LastPaymentDate;
        }

        public bool CheckLoanNumber()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CompanyLoan where LoanNumber =?";
                cmd.Parameters.AddWithValue("LoanNumber", _sLoanNumber);
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

            if (nCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class CompanyLoans : CollectionBase
    {
        public CompanyLoan this[int i]
        {
            get { return (CompanyLoan)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CompanyLoan oCompanyLoan)
        {
            InnerList.Add(oCompanyLoan);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime _dReceiveDateFrom, DateTime _dReceiveDateTo, DateTime _dExpireDateFrom, DateTime _dExpireDateTo, DateTime _dCreateDateFrom, DateTime _dCreateDateTo, bool chkReceiveDateRangeChecked, bool chkExpireDateRangeChecked, bool chkCreateDateRangeChecked, string sLoanNumber, string sLCNumber, int nBankID, int nStatus, int nLoanType)
        {
            _dReceiveDateTo = _dReceiveDateTo.AddDays(1);
            _dExpireDateTo = _dExpireDateTo.AddDays(1);
            _dCreateDateTo = _dCreateDateTo.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT a.*, b.Code as BankCode, b.Description as BankName, c.UserFullName as CreateUser "+
                          " FROM t_CompanyLoan a, t_Bank b, t_User c Where a.BankID = b.BankID and a.CreateUserID = c.UserID ";
            if (!chkReceiveDateRangeChecked)
            {
                sSql += " and a.ReceiveDate between '"+ _dReceiveDateFrom + "' and '"+ _dReceiveDateTo + "' and a.ReceiveDate < '"+ _dReceiveDateTo + "' ";
            }
            if (!chkExpireDateRangeChecked)
            {
                sSql += " and a.ExpireDate between '" + _dExpireDateFrom + "' and '" + _dExpireDateTo + "' and a.ExpireDate < '" + _dExpireDateTo + "' ";
            }
            if (!chkCreateDateRangeChecked)
            {
                sSql += " and a.CreateDate between '" + _dCreateDateFrom + "' and '" + _dCreateDateTo + "' and a.CreateDate < '" + _dCreateDateTo + "' ";
            }
            if (sLoanNumber != "")
            {
                sSql += " and LoanNumber = '"+ sLoanNumber + "' ";
            }
            if (sLCNumber != "")
            {
                sSql += " and LCNumber = '" + sLCNumber + "' ";
            }
            if (nBankID != 0)
            {
                sSql += " and a.BankID = " + nBankID + " ";
            }
            if (nStatus != 0)
            {
                sSql += " and a.Status = " + nStatus + " ";
            }
            if (nLoanType != 0)
            {
                sSql += " and a.LoanType = " + nLoanType + " ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyLoan oCompanyLoan = new CompanyLoan();
                    oCompanyLoan.ID = (int)reader["ID"];
                    oCompanyLoan.CompanyID = (int)reader["CompanyID"];
                    oCompanyLoan.LoanNumber = (string)reader["LoanNumber"];
                    oCompanyLoan.LoanType = (int)reader["LoanType"];
                    oCompanyLoan.BankID = (int)reader["BankID"];
                    oCompanyLoan.LCNumber = (string)reader["LCNumber"];
                    oCompanyLoan.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    oCompanyLoan.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oCompanyLoan.Currency = (string)reader["Currency"];
                    oCompanyLoan.ConversionRate = Convert.ToDouble(reader["ConversionRate"].ToString());
                    oCompanyLoan.BDTAmount = Convert.ToDouble(reader["BDTAmount"].ToString());
                    oCompanyLoan.CurrentInterestRate = Convert.ToDouble(reader["CurrentInterestRate"].ToString());
                    oCompanyLoan.DurationDays = (int)reader["DurationDays"];
                    oCompanyLoan.ExpireDate = Convert.ToDateTime(reader["ExpireDate"].ToString());
                    oCompanyLoan.PurposeOfLoan = (string)reader["PurposeOfLoan"];
                    oCompanyLoan.SupplyType = (string)reader["SupplyType"];
                    oCompanyLoan.Status = (int)reader["Status"];
                    if (reader["TotalPayment"] != DBNull.Value)
                        oCompanyLoan.TotalPayment = Convert.ToDouble(reader["TotalPayment"]);
                    else
                        oCompanyLoan.TotalPayment = 0;
                    if (reader["PayablePrincipal"] != DBNull.Value)
                        oCompanyLoan.PayablePrincipal = Convert.ToDouble(reader["PayablePrincipal"]);
                    else
                        oCompanyLoan.PayablePrincipal = 0;
                    if (reader["PayableInterest"] != DBNull.Value)
                        oCompanyLoan.PayableInterest = Convert.ToDouble(reader["PayableInterest"]);
                    else
                        oCompanyLoan.PayableInterest = 0;
                    oCompanyLoan.Remarks = (string)reader["Remarks"];
                    oCompanyLoan.CreateUserID = (int)reader["CreateUserID"];
                    oCompanyLoan.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    oCompanyLoan.BankCode = (string)reader["BankCode"];
                    oCompanyLoan.BankName = (string)reader["BankName"];
                    oCompanyLoan.CreateUser = (string)reader["CreateUser"];

                    InnerList.Add(oCompanyLoan);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetQuarterEndEligibleData()
        {
            
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select * from [dbo].[t_CompanyLoan] Where Status = " + (int)Dictionary.CompanyLoanStatus.Running + " ";
            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyLoan oCompanyLoan = new CompanyLoan();
                    oCompanyLoan.ID = (int)reader["ID"];
                    oCompanyLoan.CompanyID = (int)reader["CompanyID"];
                    oCompanyLoan.LoanNumber = (string)reader["LoanNumber"];
                    oCompanyLoan.LoanType = (int)reader["LoanType"];
                    oCompanyLoan.BankID = (int)reader["BankID"];
                    oCompanyLoan.LCNumber = (string)reader["LCNumber"];
                    oCompanyLoan.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    oCompanyLoan.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oCompanyLoan.Currency = (string)reader["Currency"];
                    oCompanyLoan.ConversionRate = Convert.ToDouble(reader["ConversionRate"].ToString());
                    oCompanyLoan.BDTAmount = Convert.ToDouble(reader["BDTAmount"].ToString());
                    oCompanyLoan.CurrentInterestRate = Convert.ToDouble(reader["CurrentInterestRate"].ToString());
                    oCompanyLoan.DurationDays = (int)reader["DurationDays"];
                    oCompanyLoan.ExpireDate = Convert.ToDateTime(reader["ExpireDate"].ToString());
                    oCompanyLoan.PurposeOfLoan = (string)reader["PurposeOfLoan"];
                    oCompanyLoan.SupplyType = (string)reader["SupplyType"];
                    oCompanyLoan.Status = (int)reader["Status"];
                    if (reader["TotalPayment"] != DBNull.Value)
                        oCompanyLoan.TotalPayment = Convert.ToDouble(reader["TotalPayment"]);
                    else
                        oCompanyLoan.TotalPayment = 0;
                    if (reader["PayablePrincipal"] != DBNull.Value)
                        oCompanyLoan.PayablePrincipal = Convert.ToDouble(reader["PayablePrincipal"]);
                    else
                        oCompanyLoan.PayablePrincipal = 0;
                    if (reader["PayableInterest"] != DBNull.Value)
                        oCompanyLoan.PayableInterest = Convert.ToDouble(reader["PayableInterest"]);
                    else
                        oCompanyLoan.PayableInterest = 0;
                    oCompanyLoan.Remarks = (string)reader["Remarks"];
                    oCompanyLoan.CreateUserID = (int)reader["CreateUserID"];
                    oCompanyLoan.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    //oCompanyLoan.BankCode = (string)reader["BankCode"];
                    //oCompanyLoan.BankName = (string)reader["BankName"];
                    //oCompanyLoan.CreateUser = (string)reader["CreateUser"];

                    InnerList.Add(oCompanyLoan);
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


// <summary>
// Compamy: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Jun 14, 2016
// Time : 10:37 AM
// Description: Class for HRLoan.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using System.Globalization;

namespace CJ.Class.HR
{
    public class HRLoanDetail
    {
        private int _nLoanDetailID;
        private int _nLoanID;
        private int _nInstallmentNo;
        private double _BalancePrincipal;
        private double _PrincipalPayable;
        private double _InterestPayable;
        private double _TotalPayable;
        private DateTime _dPaymentDate;
        private int _nIsDue;
        private int _nIsEarlyClose;
        private int _nIsBonus;

        private int _nCreateUserID;
        private DateTime _dCreateDate;


        // <summary>
        // Get set property for LoanDetailID
        // </summary>
        public int LoanDetailID
        {
            get { return _nLoanDetailID; }
            set { _nLoanDetailID = value; }
        }

        // <summary>
        // Get set property for LoanID
        // </summary>
        public int LoanID
        {
            get { return _nLoanID; }
            set { _nLoanID = value; }
        }

        // <summary>
        // Get set property for InstallmentNo
        // </summary>
        public int InstallmentNo
        {
            get { return _nInstallmentNo; }
            set { _nInstallmentNo = value; }
        }

        // <summary>
        // Get set property for BalancePrincipal
        // </summary>
        public double BalancePrincipal
        {
            get { return _BalancePrincipal; }
            set { _BalancePrincipal = value; }
        }

        // <summary>
        // Get set property for PrincipalPayable
        // </summary>
        public double PrincipalPayable
        {
            get { return _PrincipalPayable; }
            set { _PrincipalPayable = value; }
        }

        // <summary>
        // Get set property for InterestPayable
        // </summary>
        public double InterestPayable
        {
            get { return _InterestPayable; }
            set { _InterestPayable = value; }
        }

        // <summary>
        // Get set property for TotalPayable
        // </summary>
        public double TotalPayable
        {
            get { return _TotalPayable; }
            set { _TotalPayable = value; }
        }

        // <summary>
        // Get set property for PaymentDate
        // </summary>
        public DateTime PaymentDate
        {
            get { return _dPaymentDate; }
            set { _dPaymentDate = value; }
        }

        // <summary>
        // Get set property for IsDue
        // </summary>
        public int IsDue
        {
            get { return _nIsDue; }
            set { _nIsDue = value; }
        }

        // <summary>
        // Get set property for IsEarlyClose
        // </summary>
        public int IsEarlyClose
        {
            get { return _nIsEarlyClose; }
            set { _nIsEarlyClose = value; }
        }

        // <summary>
        // Get set property for IsBonus
        // </summary>
        public int IsBonus
        {
            get { return _nIsBonus; }
            set { _nIsBonus = value; }
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

        private string _sRemarks;
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        private string _sEMIStatusName;
        
        public string EMIStatusName
        {
            get { return _sEMIStatusName; }
            set { _sEMIStatusName = value; }
        }

        public void Add(int nLoanID)
        {
            int nMaxLoanDetailID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LoanDetailID]) FROM t_HRLoanDetail";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLoanDetailID = 1;
                }
                else
                {
                    nMaxLoanDetailID = Convert.ToInt32(maxID) + 1;
                }
                _nLoanDetailID = nMaxLoanDetailID;
                sSql = "INSERT INTO t_HRLoanDetail (LoanDetailID, LoanID, InstallmentNo, BalancePrincipal, PrincipalPayable, InterestPayable, TotalPayable, PaymentDate, IsDue, IsEarlyClose, IsBonus) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LoanDetailID", _nLoanDetailID);
                cmd.Parameters.AddWithValue("LoanID", nLoanID);
                cmd.Parameters.AddWithValue("InstallmentNo", _nInstallmentNo);
                cmd.Parameters.AddWithValue("BalancePrincipal", _BalancePrincipal);
                cmd.Parameters.AddWithValue("PrincipalPayable", _PrincipalPayable);
                cmd.Parameters.AddWithValue("InterestPayable", _InterestPayable);
                cmd.Parameters.AddWithValue("TotalPayable", _TotalPayable);
                cmd.Parameters.AddWithValue("PaymentDate", _dPaymentDate);
                cmd.Parameters.AddWithValue("IsDue", _nIsDue);
                cmd.Parameters.AddWithValue("IsEarlyClose", _nIsEarlyClose);
                cmd.Parameters.AddWithValue("IsBonus", _nIsBonus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public bool CheckEMI()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT Count(*) as DueTotal FROM t_HRLoanDetail where IsDue = " + (int)Dictionary.YesOrNoStatus.NO + " and LoanID =?"; ;
                cmd.Parameters.AddWithValue("LoanID", _nLoanID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount = (int)reader["DueTotal"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckDue(int nLoanID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT Count(*) as DueTotal FROM t_HRLoanDetail where IsDue = " + (int)Dictionary.YesOrNoStatus.YES + " and LoanID =?"; ;
                cmd.Parameters.AddWithValue("LoanID", nLoanID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount = (int)reader["DueTotal"];
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

        public void GetLoanDetail(int _nLoanID, int nTMonth, int nTYear)
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRLoanDetail Where LoanID =  " + _nLoanID + " and Month(PaymentDate)=" + nTMonth + " and Year(PaymentDate)=" + nTYear + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    _nLoanDetailID = (int)reader["LoanDetailID"];
                    _nLoanID = (int)reader["LoanID"];
                    _nInstallmentNo = (int)reader["InstallmentNo"];
                    _BalancePrincipal = Convert.ToDouble(reader["BalancePrincipal"].ToString());
                    _PrincipalPayable = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                    _InterestPayable = Convert.ToDouble(reader["InterestPayable"].ToString());
                    _TotalPayable = Convert.ToDouble(reader["TotalPayable"].ToString());
                    _dPaymentDate = Convert.ToDateTime(reader["PaymentDate"].ToString());
                    _nIsDue = (int)reader["IsDue"];
                    if (_nIsDue == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        _sEMIStatusName = "Due";
                    }
                    else
                    {
                        _sEMIStatusName = "Paid";
                    }
                    _nIsEarlyClose = (int)reader["IsEarlyClose"];
                    _nIsBonus = (int)reader["IsBonus"];

                    
                }
                reader.Close();
             
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLoanDetailByInstallment(int _nLoanID, int nInstallmentNo)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from dbo.t_HRLoanDetail Where LoanID=" + _nLoanID + " and InstallmentNo=" + nInstallmentNo + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    _nLoanDetailID = (int)reader["LoanDetailID"];
                    _nLoanID = (int)reader["LoanID"];
                    _nInstallmentNo = (int)reader["InstallmentNo"];
                    _BalancePrincipal = Convert.ToDouble(reader["BalancePrincipal"].ToString());
                    _PrincipalPayable = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                    _InterestPayable = Convert.ToDouble(reader["InterestPayable"].ToString());
                    _TotalPayable = Convert.ToDouble(reader["TotalPayable"].ToString());
                    _dPaymentDate = Convert.ToDateTime(reader["PaymentDate"].ToString());
                    _nIsDue = (int)reader["IsDue"];
                    if (_nIsDue == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        _sEMIStatusName = "Due";
                    }
                    else
                    {
                        _sEMIStatusName = "Paid";
                    }
                    _nIsEarlyClose = (int)reader["IsEarlyClose"];
                    _nIsBonus = (int)reader["IsBonus"];


                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateEMI(int nLoanDetailID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update dbo.t_HRLoanDetail SET IsDue = " + (int)Dictionary.YesOrNoStatus.NO + " Where LoanDetailID=" + nLoanDetailID + " ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateEarlySettle(int nLoanID, int nInstallmentNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update dbo.t_HRLoanDetail SET IsDue =" + (int)Dictionary.YesOrNoStatus.NO + ",  IsEarlyClose = " + (int)Dictionary.YesOrNoStatus.YES + " Where LoanID=" + nLoanID + " and InstallmentNo=" + nInstallmentNo + "  ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddEarlySettle()
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = " Insert Into dbo.t_HRLoanEarlySettle (LoanID, PrincipalAmount, InterestAmount, SettlementDate, " +
                       " CreateUserID, CreateDate, Remarks) VALUES(?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LoanID", _nLoanID);
                cmd.Parameters.AddWithValue("PrincipalAmount", _PrincipalPayable);
                cmd.Parameters.AddWithValue("InterestAmount", _InterestPayable);
                cmd.Parameters.AddWithValue("SettlementDate", _dPaymentDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class HRLoan : CollectionBase
    {
        private int _nLoanID;
        private string _sLoanNo;
        private int _nEmployeeID;
        private int _nCompanyID;
        private string _sDepartmentName;
        private int _nLoanTypeID;
        private int _nArticleType;
        private double _BalancePrincipal;
        private double _AllocatedAmount;
        private DateTime _dDisburseDate;
        private double _DownPayment;
        private int _nNoOfInstallment;
        private double _InterestRate;
        private double _CurrentBalance;
        private int _nStatus;
        private string _HRLoanStatus;
        private string _nIsDue;
        private string _nIsEarlyClose;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;




        public string HRLoanStatus
        {
            get { return _HRLoanStatus; }
            set { _HRLoanStatus = value.Trim(); }
        }
        // <summary>
        // Get set property for LoanID
        // </summary>
        public int LoanID
        {
            get { return _nLoanID; }
            set { _nLoanID = value; }
        }

        // <summary>
        // Get set property for LoanNo
        // </summary>
        public string LoanNo
        {
            get { return _sLoanNo; }
            set { _sLoanNo = value.Trim(); }
        }

        // <summary>
        // Get set property for EmployeeID
        // </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
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
        // Get set property for LoanTypeID
        // </summary>
        public int LoanTypeID
        {
            get { return _nLoanTypeID; }
            set { _nLoanTypeID = value; }
        }

        // <summary>
        // Get set property for ArticleType
        // </summary>
        public int ArticleType
        {
            get { return _nArticleType; }
            set { _nArticleType = value; }
        }
        // <summary>
        // Get set property for BalancePrincipal
        // </summary>
        public double BalancePrincipal
        {
            get { return _BalancePrincipal; }
            set { _BalancePrincipal = value; }
        }
        // <summary>
        // Get set property for AllocatedAmount
        // </summary>
        public double AllocatedAmount
        {
            get { return _AllocatedAmount; }
            set { _AllocatedAmount = value; }
        }

        // <summary>
        // Get set property for DisburseDate
        // </summary>
        public DateTime DisburseDate
        {
            get { return _dDisburseDate; }
            set { _dDisburseDate = value; }
        }

        // <summary>
        // Get set property for DownPayment
        // </summary>
        public double DownPayment
        {
            get { return _DownPayment; }
            set { _DownPayment = value; }
        }

        // <summary>
        // Get set property for NoOfInstallment
        // </summary>
        public int NoOfInstallment
        {
            get { return _nNoOfInstallment; }
            set { _nNoOfInstallment = value; }
        }

        // <summary>
        // Get set property for InterestRate
        // </summary>
        public double InterestRate
        {
            get { return _InterestRate; }
            set { _InterestRate = value; }
        }

        // <summary>
        // Get set property for CurrentBalance
        // </summary>
        public double CurrentBalance
        {
            get { return _CurrentBalance; }
            set { _CurrentBalance = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
       
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public string IsEarlyClose
        {
            get { return _nIsEarlyClose; ; }
            set { _nIsEarlyClose = value; }
        }
        public string IsDue  
        {
            get { return _nIsDue; }
            set { _nIsDue = value; }
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
        
        private string _sEmployeeCode;
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value; }
        }
        private string _sEmployeeName;
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value; }
        }        
        private string _sUserName;
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }

        private double _AL_TV;
        public double AL_TV
        {
            get { return _AL_TV; }
            set { _AL_TV = value; }
        }
        private double _AL_Ref;
        public double AL_Ref
        {
            get { return _AL_Ref; }
            set { _AL_Ref = value; }
        }
        private double _AL_AC;
        public double AL_AC
        {
            get { return _AL_AC; }
            set { _AL_AC = value; }
        }
        private double _BuildingLoan;
        public double BuildingLoan
        {
            get { return _BuildingLoan; }
            set { _BuildingLoan = value; }
        }
        private double _BuildingLoanInt;
        public double BuildingLoanInt
        {
            get { return _BuildingLoanInt; }
            set { _BuildingLoanInt = value; }
        }
        private double _SalaryAdvance;
        public double SalaryAdvance
        {
            get { return _SalaryAdvance; }
            set { _SalaryAdvance = value; }
        }
        private double _EmergencyLoan;
        public double EmergencyLoan
        {
            get { return _EmergencyLoan; }
            set { _EmergencyLoan = value; }
        }
        private double _PFLoan;
        public double PFLoan
        {
            get { return _PFLoan; }
            set { _PFLoan = value; }
        }
        private int _IsBonus;
        public int IsBonus
        {
            get { return _IsBonus; }
            set { _IsBonus = value; }
        }
        private string _sLoanStatusName;
        public string LoanStatusName
        {
            get { return _sLoanStatusName; }
            set { _sLoanStatusName = value; }
        }
        private string _sLoanTypeName;
        public string LoanTypeName
        {
            get { return _sLoanTypeName; }
            set { _sLoanTypeName = value; }
        }
        private double _PrincipalPayable;
        public double PrincipalPayable
        {
            get { return _PrincipalPayable; }
            set { _PrincipalPayable = value; }
        }
        private double _InterestPayable;
        public double InterestPayable
        {
            get { return _InterestPayable; }
            set { _InterestPayable = value; }
        }
        private double _TotalPayable;
        public double TotalPayable
        {
            get { return _TotalPayable; }
            set { _TotalPayable = value; }
        }

        public HRLoanDetail this[int i]
        {
            get { return (HRLoanDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRLoanDetail oHRLoanDetail)
        {
            InnerList.Add(oHRLoanDetail);
        }

        public void Add()
        {
            int nMaxLoanID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LoanID]) FROM t_HRLoan";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLoanID = 1;
                }
                else
                {
                    nMaxLoanID = Convert.ToInt32(maxID) + 1;
                }
                _nLoanID = nMaxLoanID;
                sSql = "INSERT INTO t_HRLoan (LoanID, LoanNo, EmployeeID, CompanyID, LoanTypeID, ArticleType, AllocatedAmount, DisburseDate, DownPayment, NoOfInstallment, InterestRate, CurrentBalance, Status, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LoanID", _nLoanID);
                cmd.Parameters.AddWithValue("LoanNo", _sLoanNo);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("LoanTypeID", _nLoanTypeID);
                cmd.Parameters.AddWithValue("ArticleType", _nArticleType);
                cmd.Parameters.AddWithValue("AllocatedAmount", _AllocatedAmount);
                cmd.Parameters.AddWithValue("DisburseDate", _dDisburseDate);
                cmd.Parameters.AddWithValue("DownPayment", _DownPayment);
                cmd.Parameters.AddWithValue("NoOfInstallment", _nNoOfInstallment);
                cmd.Parameters.AddWithValue("InterestRate", _InterestRate);
                cmd.Parameters.AddWithValue("CurrentBalance", _CurrentBalance);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (HRLoanDetail oItem in this)
                {
                    oItem.Add(_nLoanID);
                }
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
                sSql = "UPDATE t_HRLoan SET LoanNo = ?, EmployeeID = ?, CompanyID = ?, LoanTypeID = ?, ArticleType = ?, AllocatedAmount = ?, DisburseDate = ?, DownPayment = ?, NoOfInstallment = ?, InterestRate = ?, CurrentBalance = ?, Status = ?, CreateUserID = ?, CreateDate = ?, UpdateUserID = ?, UpdateDate = ? WHERE LoanID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LoanNo", _sLoanNo);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("LoanTypeID", _nLoanTypeID);
                cmd.Parameters.AddWithValue("ArticleType", _nArticleType);
                cmd.Parameters.AddWithValue("AllocatedAmount", _AllocatedAmount);
                cmd.Parameters.AddWithValue("DisburseDate", _dDisburseDate);
                cmd.Parameters.AddWithValue("DownPayment", _DownPayment);
                cmd.Parameters.AddWithValue("NoOfInstallment", _nNoOfInstallment);
                cmd.Parameters.AddWithValue("InterestRate", _InterestRate);
                cmd.Parameters.AddWithValue("CurrentBalance", _CurrentBalance);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("LoanID", _nLoanID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void UpdateCurrentBalance(bool _bFlag, double CurrentBalance, int nLoanID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (_bFlag)
                {
                    sSql = "UPDATE t_HRLoan SET CurrentBalance = CurrentBalance + " + CurrentBalance + " WHERE LoanID = " + nLoanID + " ";
                }
                else
                {
                    sSql = "UPDATE t_HRLoan SET CurrentBalance = CurrentBalance - " + CurrentBalance + " WHERE LoanID = " + nLoanID + " ";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void UpdateStatus(int nLoanID, int nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "UPDATE t_HRLoan SET Status = " + nStatus + " WHERE LoanID = " + nLoanID + " ";
             
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

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
                sSql = "DELETE FROM t_HRLoanDetail WHERE [LoanID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LoanID", _nLoanID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                sSql = "DELETE FROM t_HRLoan WHERE [LoanID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LoanID", _nLoanID);
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
                cmd.CommandText = "SELECT a.*, LoanTypeName FROM t_HRLoan a, t_HRLoantype b where a.LoanTypeID=b.LoanTypeID and LoanID = ? ";
                cmd.Parameters.AddWithValue("LoanID", _nLoanID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLoanID = (int)reader["LoanID"];
                    _sLoanNo = (string)reader["LoanNo"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _nLoanTypeID = (int)reader["LoanTypeID"];
                    _sLoanTypeName = (string)reader["LoanTypeName"];
                    _nArticleType = (int)reader["ArticleType"];
                    _AllocatedAmount = Convert.ToDouble(reader["AllocatedAmount"].ToString());
                    _dDisburseDate = Convert.ToDateTime(reader["DisburseDate"].ToString());
                    _DownPayment = Convert.ToDouble(reader["DownPayment"].ToString());
                    _nNoOfInstallment = (int)reader["NoOfInstallment"];
                    _InterestRate = Convert.ToDouble(reader["InterestRate"].ToString());
                    _CurrentBalance = Convert.ToDouble(reader["CurrentBalance"].ToString());
                    _nStatus = (int)reader["Status"];
                    _sLoanStatusName = Enum.GetName(typeof(Dictionary.HRLoanStatus), _nStatus);
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    RefreshLoanDetail(_nLoanID);
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void RefreshLoanDetail(int _nLoanID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRLoanDetail Where LoanID =  " + _nLoanID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    HRLoanDetail oHRLoanDetail = new HRLoanDetail();

                    oHRLoanDetail.LoanDetailID = (int)reader["LoanDetailID"];
                    oHRLoanDetail.LoanID = (int)reader["LoanID"];
                    oHRLoanDetail.InstallmentNo = (int)reader["InstallmentNo"];
                    oHRLoanDetail.BalancePrincipal = Convert.ToDouble(reader["BalancePrincipal"].ToString());
                    oHRLoanDetail.PrincipalPayable = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                    oHRLoanDetail.InterestPayable = Convert.ToDouble(reader["InterestPayable"].ToString());
                    oHRLoanDetail.TotalPayable = Convert.ToDouble(reader["TotalPayable"].ToString());
                    oHRLoanDetail.PaymentDate = Convert.ToDateTime(reader["PaymentDate"].ToString());
                    oHRLoanDetail.IsDue = (int)reader["IsDue"];
                    if (oHRLoanDetail.IsDue == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        oHRLoanDetail.EMIStatusName = "Due";
                    }
                    else
                    {
                        oHRLoanDetail.EMIStatusName = "Paid";
                    }
                    oHRLoanDetail.IsEarlyClose = (int)reader["IsEarlyClose"];
                    oHRLoanDetail.IsBonus = (int)reader["IsBonus"];

                    InnerList.Add(oHRLoanDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void GetDueLoanDetail(int _nLoanID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRLoanDetail Where LoanID =  " + _nLoanID + " and IsDue = " + (int)Dictionary.YesOrNoStatus.YES + " Order by InstallmentNo ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    HRLoanDetail oHRLoanDetail = new HRLoanDetail();

                    oHRLoanDetail.LoanDetailID = (int)reader["LoanDetailID"];
                    oHRLoanDetail.LoanID = (int)reader["LoanID"];
                    oHRLoanDetail.InstallmentNo = (int)reader["InstallmentNo"];
                    oHRLoanDetail.BalancePrincipal = Convert.ToDouble(reader["BalancePrincipal"].ToString());
                    oHRLoanDetail.PrincipalPayable = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                    oHRLoanDetail.InterestPayable = Convert.ToDouble(reader["InterestPayable"].ToString());
                    oHRLoanDetail.TotalPayable = Convert.ToDouble(reader["TotalPayable"].ToString());
                    oHRLoanDetail.PaymentDate = Convert.ToDateTime(reader["PaymentDate"].ToString());
                    oHRLoanDetail.IsDue = (int)reader["IsDue"];
                    if (oHRLoanDetail.IsDue == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        oHRLoanDetail.EMIStatusName = "Due";
                    }
                    else
                    {
                        oHRLoanDetail.EMIStatusName = "Paid";
                    }
                    oHRLoanDetail.IsEarlyClose = (int)reader["IsEarlyClose"];
                    oHRLoanDetail.IsBonus = (int)reader["IsBonus"];

                    InnerList.Add(oHRLoanDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public double GetBonusAmount(int nEmployeeID, int nCompnayID, int nMonth, int nYear)
        {
            double _Amount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select PrincipalPayable from t_HRLoanDetail a, t_HRLoan b Where a.LoanID=b.LoanID and IsBonus=" + (int)Dictionary.YesOrNoStatus.YES + " " +
                           " and EmployeeID=" + nEmployeeID + " and CompanyID = " + nCompnayID + " and IsDue = " + (int)Dictionary.YesOrNoStatus.YES + " and Month(PaymentDate) = " + nMonth + " and Year(PaymentDate) = " + nYear + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    _Amount = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                    
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;
        }
        
        public int GetTotalLoan(int nLoanTypeID, DateTime _dFromDate, DateTime _dToDate, int nCompnayID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nLoanTypeID <= 5)
            {
                sSql = "Select Count(*)Count from dbo.t_HRLoan Where CompanyID = " + nCompnayID + " and LoanTypeID=" + nLoanTypeID + " and " +
                                " DisburseDate between '" + _dFromDate + "' and '" + _dToDate + "' and DisburseDate < '" + _dToDate + "' ";
            }
            else
            {
                sSql = "Select Count(*)Count from dbo.t_HRLoan Where CompanyID = " + nCompnayID + " and LoanTypeID > 5 and " +//1 to 5 Basic Loan and > 5 Others Loan Like motor cycle, mobile etc
                                    " DisburseDate between '" + _dFromDate + "' and '" + _dToDate + "' and DisburseDate < '" + _dToDate + "' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    nCount = (int)reader["Count"];
                  
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nCount;
        }
        
        public void GetLoanByEmployee(int nEmployeeID, int nMonth, int nYear)
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select EmployeeID, " +
                          "  Sum(CASE When LoanTypeID = 1 and ArticleType = 1 then TotalPayable else 0 end) as AL_AC,  " +
                          "  Sum(CASE When LoanTypeID = 1 and ArticleType = 2 then TotalPayable else 0 end) as AL_TV,  " +
                          "  Sum(CASE When LoanTypeID = 1 and ArticleType = 3 then TotalPayable else 0 end) as AL_Ref, " +
                          "  Sum(CASE When LoanTypeID = 2 then TotalPayable else 0 end) as BuildingLoan,  " +
                          "  Sum(CASE When LoanTypeID = 2 then InterestPayable else 0 end) as BuildingLoanInt, "+
                          "  Sum(CASE When LoanTypeID = 3 then TotalPayable else 0 end) as SalaryAdvance,  " +
                          "  Sum(CASE When LoanTypeID = 4 then TotalPayable else 0 end) as EmergencyLoan,  " +
                          "  Sum(CASE When LoanTypeID = 5 then TotalPayable else 0 end) as PFLoan, Sum(IsBonus) as IsBonus  " + // Bonus sum becz for december | Bulding & Others Loan show multiple data thats why...
                          "  from dbo.t_HRLoan a, dbo.t_HRLoanDetail b Where a.LoanID=b.LoanID and EmployeeID=" + nEmployeeID + "  " +
                          "  and Month(PaymentDate) = " + nMonth + " and Status = " + (int)Dictionary.HRLoanStatus.Running + " and IsDue = " + (int)Dictionary.YesOrNoStatus.YES + " " +
                          "  and Year(PaymentDate) = " + nYear + " Group By EmployeeID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _AL_TV = (double)reader["AL_TV"];
                    _AL_Ref = (double)reader["AL_Ref"];
                    _AL_AC = (double)reader["AL_AC"];
                    _BuildingLoan = (double)reader["BuildingLoan"];
                    _BuildingLoanInt = (double)reader["BuildingLoanInt"];
                    _SalaryAdvance = (double)reader["SalaryAdvance"];
                    _EmergencyLoan = (double)reader["EmergencyLoan"];
                    _PFLoan = (double)reader["PFLoan"];
                    _IsBonus = (int)reader["IsBonus"];

                    
                }
                reader.Close();
          
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public double GetOtherLoanByEmployee(int nEmployeeID, int nCompnayID, int nMonth, int nYear)
        {
            double _Amount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select Sum(PrincipalPayable+InterestPayable) as Amount from t_HRLoan a, t_HRLoanDetail b Where a.LoanID=b.LoanID and IsDue=" + (int)Dictionary.YesOrNoStatus.YES + " and Year(PaymentDate)=" + nYear + " " +
                           " and Month(PaymentDate)=" + nMonth + " and EmployeeID=" + nEmployeeID + " and CompanyID = " + nCompnayID + " and LoanTypeID > " + (int)Dictionary.HRLoanType.ProvidentFund + " ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        _Amount = (double)reader["Amount"];
                    }
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _Amount;
        }
        
        

    }
    public class HRLoans : CollectionBase
    {
        public HRLoan this[int i]
        {
            get { return (HRLoan)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRLoan oHRLoan)
        {
            InnerList.Add(oHRLoan);
        }
        public int GetIndex(int nLoanID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].LoanID == nLoanID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dtFromDate, DateTime dtToDate, string sLoanNo, int nEmployeeID, int nStatus, int nLoanType, int nArticleType, int nCompany, bool bChkAll)
        {
            dtToDate = dtToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select a.*, EmployeeCode, EmployeeName, UserFullName as UserName, LoanTypeName, " +
                          " IsNull(PrincipalPayable,0) as PrincipalPayable, IsNull(InterestPayable,0) as InterestPayable,  " +
                          " IsNull(TotalPayable,0) as TotalPayable from dbo.t_HRLoan a  " +
                          " INNER JOIN t_User b ON a.CreateUserID=b.UserID " +
                          " INNER JOIN t_Employee c ON a.EmployeeID=c.EmployeeID " +
                          " INNER JOIN t_HRLoantype d ON a.LoanTypeID=d.LoanTypeID " +
                          " Left Outer JOIN " +
                          " (Select LoanID, Sum(PrincipalPayable) as PrincipalPayable,Sum(InterestPayable) as InterestPayable,  " +
                          " Sum(TotalPayable) as TotalPayable from t_HRLoanDetail Where IsDue=1 Group by LoanID)e " +
                          " ON a.LoanID=e.LoanID Where  1=1 ";
            if (!bChkAll)
            {
                sSql = sSql + " and DisburseDate Between '" + dtFromDate + "' and '" + dtToDate + "' and DisburseDate < '" + dtToDate + "' ";
            }
            if (sLoanNo != "")
            {
                sSql = sSql + " and LoanNo = '" + sLoanNo + "' ";
            }
            if (nEmployeeID != 0)
            {
                sSql = sSql + " and a.EmployeeID = " + nEmployeeID + " ";
            }
            if (nStatus > 0)
            {
                sSql = sSql + " and a.Status = " + nStatus + " ";
            }
            if (nLoanType > 0)
            {
                sSql = sSql + " and a.LoanTypeID = " + nLoanType + " ";
            }
            if (nArticleType > 0)
            {
                sSql = sSql + " and ArticleType = " + nArticleType + " ";
            }
            if (nCompany == 0)
            {
                sSql = sSql + " and a.CompanyID IN (Select DataID from dbo.t_UserPermissionData Where DataType='Company' and UserID=" + Utility.UserId + ") ";
            }
            else
            {
                sSql = sSql + " and a.CompanyID = " + nCompany + " ";
            }
            sSql = sSql + " Order by DisburseDate ";
                          
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRLoan oHRLoan = new HRLoan();
                    oHRLoan.LoanID = (int)reader["LoanID"];
                    if (reader["LoanNo"] != DBNull.Value)
                    {
                        oHRLoan.LoanNo = (string)reader["LoanNo"];
                    }
                    else
                    {
                        oHRLoan.LoanNo = "";
                    }
                    oHRLoan.EmployeeID = (int)reader["EmployeeID"];
                    oHRLoan.CompanyID = (int)reader["CompanyID"];
                    oHRLoan.LoanTypeID = (int)reader["LoanTypeID"];
                    oHRLoan.LoanTypeName = (string)reader["LoanTypeName"];
                    oHRLoan.ArticleType = (int)reader["ArticleType"];
                    oHRLoan.AllocatedAmount = Convert.ToDouble(reader["AllocatedAmount"].ToString());
                    oHRLoan.DisburseDate = Convert.ToDateTime(reader["DisburseDate"].ToString());
                    oHRLoan.DownPayment = Convert.ToDouble(reader["DownPayment"].ToString());
                    oHRLoan.NoOfInstallment = (int)reader["NoOfInstallment"];
                    oHRLoan.InterestRate = Convert.ToDouble(reader["InterestRate"].ToString());
                    oHRLoan.CurrentBalance = Convert.ToDouble(reader["CurrentBalance"].ToString());
                    oHRLoan.PrincipalPayable = Convert.ToDouble(reader["PrincipalPayable"].ToString());
                    oHRLoan.InterestPayable = Convert.ToDouble(reader["InterestPayable"].ToString());
                    oHRLoan.TotalPayable = Convert.ToDouble(reader["TotalPayable"].ToString());
                    oHRLoan.Status = (int)reader["Status"];
                    oHRLoan.CreateUserID = (int)reader["CreateUserID"];
                    oHRLoan.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRLoan.EmployeeCode = (string)reader["EmployeeCode"];
                    oHRLoan.EmployeeName = (string)reader["EmployeeName"];
                    oHRLoan.UserName = (string)reader["UserName"];
                  

                    InnerList.Add(oHRLoan);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLoanListByEmployee(int nEmployeeID)
        {
           
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select * from dbo.t_HRLoan Where EmployeeID=" + nEmployeeID + " and Status=" + (int)Dictionary.HRLoanStatus.Running + " ";
            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRLoan oHRLoan = new HRLoan();
                    oHRLoan.LoanID = (int)reader["LoanID"];
                    if (reader["LoanNo"] != DBNull.Value)
                    {
                        oHRLoan.LoanNo = (string)reader["LoanNo"];
                    }
                    else
                    {
                        oHRLoan.LoanNo = "";
                    }
                    oHRLoan.EmployeeID = (int)reader["EmployeeID"];
                    oHRLoan.CompanyID = (int)reader["CompanyID"];
                                        oHRLoan.LoanTypeID = (int)reader["LoanTypeID"];
                    oHRLoan.ArticleType = (int)reader["ArticleType"];
                    oHRLoan.AllocatedAmount = Convert.ToDouble(reader["AllocatedAmount"].ToString());
                    oHRLoan.DisburseDate = Convert.ToDateTime(reader["DisburseDate"].ToString());
                    oHRLoan.DownPayment = Convert.ToDouble(reader["DownPayment"].ToString());
                    oHRLoan.NoOfInstallment = (int)reader["NoOfInstallment"];
                    oHRLoan.InterestRate = Convert.ToDouble(reader["InterestRate"].ToString());
                    oHRLoan.CurrentBalance = Convert.ToDouble(reader["CurrentBalance"].ToString());
                    oHRLoan.Status = (int)reader["Status"];
                    oHRLoan.CreateUserID = (int)reader["CreateUserID"];
                    oHRLoan.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());


                    InnerList.Add(oHRLoan);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }





        public void GetLoanScheduleForReport(int nEmployeeID,int nCompanyID, int nDepartmentID, int nIsDue,int nIsEarlyClose,int nTMonth,int nTYear,int nLoanType,int nSubLoanType)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select a.LoanID, EmployeeCode, EmployeeName, DepartmentName, LoanNo, a.EmployeeID, a.CompanyID," 
                           +" a.LoanTypeID, LoanTypeName, ArticleType, DownPayment, BalancePrincipal, PrincipalPayable, InterestPayable, TotalPayable," 
                           +" IsDue, IsEarlyClose from dbo.t_HRLoan a, "
                           +" (Select LoanID, BalancePrincipal, PrincipalPayable, InterestPayable, TotalPayable, PaymentDate, IsDue, IsEarlyClose from t_HRLoanDetail Where IsEarlyClose = 0 "
                           +" UNION ALL "
                           +" Select LoanID, PrincipalAmount as BalancePrincipal, PrincipalAmount as PrincipalPayable, InterestAmount as InterestPayable, "
                           +" (PrincipalAmount+InterestAmount) as TotalPayable, SettlementDate as PaymentDate, 0 as IsDue, 1 as IsEarlyClose from dbo.t_HRLoanEarlySettle) b, "
                           +" v_EmployeeDetails c, t_HRLoanType d "
                           +" Where a.LoanID=b.LoanID and a.EmployeeID=c.EmployeeID and a.LoanTypeID=d.LoanTypeID"
                           +" and Month(PaymentDate)= " + nTMonth + " and Year(PaymentDate)= " + nTYear + " AND a.CompanyID = " + nCompanyID + "";
            
            if (nIsDue != -1)
            {
                sSql += " AND IsDue = " + nIsDue + " ";
            }
            if (nIsEarlyClose != -1)
            {
                sSql += " AND IsEarlyClose = " + nIsEarlyClose + " ";
            }
            if (nEmployeeID != -1)
            {
                sSql += " AND c.EmployeeID= '" + nEmployeeID + "' ";
            }
            if (nDepartmentID != -1) 
            {
                sSql += " AND DepartmentID = " + nDepartmentID + " "; 
            }
            if (nLoanType != -1)
            {
                sSql += " AND a.LoanTypeID = " + nLoanType + " ";
            }
            if (nSubLoanType != -1)
            {
                sSql += " AND ArticleType = " + nSubLoanType + " ";
            }
            sSql += " Order by DepartmentName, EmployeeCode, a.LoanTypeID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRLoan oHRLoan = new HRLoan();
                    oHRLoan.EmployeeCode = (string)reader["EmployeeCode"];
                    oHRLoan.EmployeeName = (string)reader["EmployeeName"];
                    oHRLoan.LoanNo = (string)reader["LoanNo"];
                    oHRLoan.DepartmentName = (string)reader["DepartmentName"];
                    int nLoanTypeID=Convert.ToInt32(reader["LoanTypeID"]);
                    int nArticleID = Convert.ToInt32(reader["ArticleType"]);
                    if (nLoanTypeID == (int)Dictionary.HRLoanType.Article)
                    {
                        oHRLoan.LoanTypeName = (string)reader["LoanTypeName"] + "-" + Enum.GetName(typeof(Dictionary.HRLoanArticle), nArticleID);
                    }
                    else
                    {
                        oHRLoan.LoanTypeName = (string)reader["LoanTypeName"];
                    }
                    oHRLoan.BalancePrincipal = (double)reader["BalancePrincipal"];
                    oHRLoan.PrincipalPayable = (double)reader["PrincipalPayable"];
                    oHRLoan.InterestPayable = (double)reader["InterestPayable"];
                    oHRLoan.TotalPayable = (double)reader["TotalPayable"];
                    if ((int)reader["IsDue"] == 1)
                    {
                        oHRLoan.IsDue = "Due";
                    }
                    else
                    {
                        oHRLoan.IsDue = "Paid";
                    }

                    if ((int)reader["IsEarlyClose"] == 1)
                    {
                        oHRLoan.IsEarlyClose = "Yes";
                    }
                    else
                    {
                        oHRLoan.IsEarlyClose = "No";
                    }
                                    
                    InnerList.Add(oHRLoan);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }



        public void GetLoanDisbursmentForReport(int nCompanyID, int nDepartmentID,int nLoanType,int nSubLoanType,int nTMonth, int nTYear)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.LoanID, EmployeeCode, EmployeeName, DepartmentName, LoanNo, a.EmployeeID, a.CompanyID," 
                          +" a.LoanTypeID, LoanTypeName, ArticleType, AllocatedAmount,"
                          + " DisburseDate, DownPayment,Status, NoOfInstallment, InterestRate from dbo.t_HRLoan a, v_EmployeeDetails c, t_HRLoanType d"
                          +" Where a.EmployeeID=c.EmployeeID and a.LoanTypeID=d.LoanTypeID"
                          + " and Month(DisburseDate)= " + nTMonth + " and Year(DisburseDate)= " + nTYear + " and a.CompanyID = " + nCompanyID + " ";

            
            
            if (nDepartmentID != -1)
            {
                sSql += " AND DepartmentID = " + nDepartmentID + " ";
            }
            if (nLoanType != -1)
            {
                sSql += " AND a.LoanTypeID = "+nLoanType+" ";
            }
            if (nSubLoanType != -1)
            {
                sSql += "AND a.ArticleType = " + nSubLoanType + " ";
            }

            sSql += " Order by DepartmentName, EmployeeCode, a.LoanTypeID, ArticleType";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRLoan oHRLoan = new HRLoan();
                    oHRLoan.EmployeeCode = (string)reader["EmployeeCode"];
                    oHRLoan.EmployeeName = (string)reader["EmployeeName"];
                    oHRLoan.LoanNo = (string)reader["LoanNo"];
                    oHRLoan.DepartmentName = (string)reader["DepartmentName"];
                    oHRLoan.ArticleType = (int)reader["ArticleType"];
                    if ((int)reader["LoanTypeID"] == (int)Dictionary.HRLoanType.Article)
                    {
                        oHRLoan.LoanTypeName = (string)reader["LoanTypeName"] + "-" + Enum.GetName(typeof(Dictionary.HRLoanArticle), oHRLoan.ArticleType);
                    }
                    else
                    {
                        oHRLoan.LoanTypeName = (string)reader["LoanTypeName"];
                    }
                    if ((int)reader["Status"] == 1)
                    {
                        oHRLoan.HRLoanStatus = "Running";
                    }
                    else
                    {
                        oHRLoan.HRLoanStatus = "Closed";
                    }
                    
                    oHRLoan.AllocatedAmount = (double)reader["AllocatedAmount"];
                    oHRLoan.DownPayment = (double)reader["DownPayment"];
                    oHRLoan.NoOfInstallment = (int)reader["NoOfInstallment"];
                    oHRLoan.InterestRate = (double)reader["InterestRate"];
                    oHRLoan.DisburseDate = Convert.ToDateTime(reader["DisburseDate"].ToString()); 
                    InnerList.Add(oHRLoan);
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

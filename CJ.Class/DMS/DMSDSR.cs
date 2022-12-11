// <summary>
// Compamy: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Aug 11, 2015
// Time : 11:47 AM
// Description: Class for DMSDSR.
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
    public class DMSDSR
    {
        private int _nTranID;
        private int _nDSRID;
        private int _nDistributorID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sAreaName;
        private string _sTerritoryName;
        private int _nDSRCode;
        private string _sDSRName;
        private string _sDSRMobile;
        private string _sDesignation;
        private string _sPaymentmode;
        private string _sPaymentType;
        private int _nIsactive;
        private DateTime _dTranDate;
        
        private int _nMonth;
        private int _nYear;

        private int _nWorkingDay;
        private int _nWorkingDayAcual;
        private int _nTotalDay;
        private int _nSalaryDay;
        private int _nDaysinMonth;

        private double _nTotalSalary;
        private double _nFixedSalary;
        private double _nVariableSalary;
        private double _nTADA;
        private double _nAllowance;
        private double _nOthers;
        private double _nMobileBill;
        private double _nDeduction;
        private double _nCalculatedSalary;
        private double _nNetPayable;
        private double _nSales;
        private double _nTarget;
        private double _nAch;
        private int _nStatus;        
        private string _sRemarks;
        private int _nDataCount;
        private string _sEmployeeType;
        private DateTime _dJoiningDate;
        
        private string _sBkashAccountNo;
        private double _nTotalTADA;
        private double _nTotalAllowance;
        private double _nTotalOthers;
        private int _nIsHeldUp;

        private double _nDailyTADA;
        private double _nDailySpcAllowance;
        private double _nOthersAllowance;
        private int _nCustomerID;
        private int _nIsCurrent;
        private DateTime _dUpdatedDate;

        private string _sGrade;
        private string _sPosition;
        private double _nBasic;

        private string _sDBBLAccNo;
        private string _sDBBLMobNo;
        private string _sShortName;
        private int _nRegionID;

        private DateTime _dDOB;
        public DateTime DOB
        {
            get { return _dDOB; }
            set { _dDOB = value; }
        }

        public int RegionID
        {
            get { return _nRegionID; }
            set { _nRegionID = value; }
        }

        private string _sRegionName;
        public string RegionName
        {
            get { return _sRegionName; }
            set { _sRegionName = value; }
        }
        private string _sTownType;
        public string TownType
        {
            get { return _sTownType; }
            set { _sTownType = value; }
        }
        private string _sAccountType;
        public string AccountType
        {
            get { return _sAccountType; }
            set { _sAccountType = value; }
        }

        private string _sDistrictName;
        public string DistrictName
        {
            get { return _sDistrictName; }
            set { _sDistrictName = value; }
        }

        private int _nSLNo;
        public int SLNo
        {
            get { return _nSLNo; }
            set { _nSLNo = value; }
        }

        private int _nAreaID;

        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
        }

        private int _nTerritoryID;

        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }
        }


        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }
        }
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value; }
        }
       
        public int Month
        {
            get { return _nMonth; }
            set { _nMonth = value; }
        }

        public int Year
        {
            get { return _nYear; }
            set { _nYear = value; }
        }

        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }
        public double TotalSalary
        {
            get { return _nTotalSalary; }
            set { _nTotalSalary = value; }
        }

        public double FixedSalary
        {
            get { return _nFixedSalary; }
            set { _nFixedSalary = value; }
        }

        public double VariableSalary
        {
            get { return _nVariableSalary; }
            set { _nVariableSalary = value; }
        }
        public double TADA
        {
            get { return _nTADA; }
            set { _nTADA = value; }
        }
        public double TotalTADA
        {
            get { return _nTotalTADA; }
            set { _nTotalTADA = value; }
        }

        public double TotalAllowance
        {
            get { return _nTotalAllowance; }
            set { _nTotalAllowance = value; }
        }

        public double TotalOthers
        {
            get { return _nTotalOthers; }
            set { _nTotalOthers = value; }
        }

        public double Allowance
        {
            get { return _nAllowance; }
            set { _nAllowance = value; }
        }
        public double Others
        {
            get { return _nOthers; }
            set { _nOthers = value; }
        }

        public double MobileBill
        {
            get { return _nMobileBill; }
            set { _nMobileBill = value; }
        }

        public double Deduction
        {
            get { return _nDeduction; }
            set { _nDeduction = value; }
        }
        public double Sales
        {
            get { return _nSales; }
            set { _nSales = value; }
        }
        public double Target
        {
            get { return _nTarget; }
            set { _nTarget = value; }
        }

        public double Ach
        {
            get { return _nAch; }
            set { _nAch = value; }
        }
        public double CalculatedSalary
        {
            get { return _nCalculatedSalary; }
            set { _nCalculatedSalary = value; }
        }
        public double Netpayable
        {
            get { return _nNetPayable; }
            set { _nNetPayable = value; }
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
        public string Designation
        {
            get { return _sDesignation; }
            set { _sDesignation = value; }
        }
        public string PaymentMode
        {
            get { return _sPaymentmode; }
            set { _sPaymentmode = value; }
        }
        public string PaymentType
        {
            get { return _sPaymentType; }
            set { _sPaymentType = value; }
        }
        public int WorkingDay
        {
            get { return _nWorkingDay; }
            set { _nWorkingDay = value; }
        }

        private int _Holiday;
        public int Hoiliday
        {
            get { return _Holiday; }
            set { _Holiday = value; }
        }

    
        public int TotalDay
        {
            get { return _nTotalDay; }
            set { _nTotalDay = value; }
        }
        public int SalaryDay
        {
            get { return _nSalaryDay; }
            set { _nSalaryDay = value; }
        }
        public int WorkingDayActual
        {
            get { return _nWorkingDayAcual; }
            set { _nWorkingDayAcual = value; }
        }

        private int _SpcWD;
        public int SpcWD
        {
            get { return _SpcWD; }
            set { _SpcWD = value; }
        }
        public int DaysinMonth
        {
            get { return _nDaysinMonth; }
            set { _nDaysinMonth = value; }
        }
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }
        public int DataCount
        {
            get { return _nDataCount; }
            set { _nDataCount = value; }
        }
        public string EmployeeType
        {
            get { return _sEmployeeType; }
            set { _sEmployeeType = value; }
        }
        public string BkashAccountNo
        {
            get { return _sBkashAccountNo; }
            set { _sBkashAccountNo = value; }
        }
        public DateTime JoiningDate
        {
            get { return _dJoiningDate; }
            set { _dJoiningDate = value; }
        }
        private DateTime _dResignDate;
        public DateTime ResignDate
        {
            get { return _dResignDate; }
            set { _dResignDate = value; }
        }
        public int IsHeldUp
        {
            get { return _nIsHeldUp; }
            set { _nIsHeldUp = value; }
        }

        public double DailyTADA
        {
            get { return _nDailyTADA; }
            set { _nDailyTADA = value; }
        }

        public double DailySpcAllowance
        {
            get { return _nDailySpcAllowance; }
            set { _nDailySpcAllowance = value; }
        }

        public double OthersAllowance
        {
            get { return _nOthersAllowance; }
            set { _nOthersAllowance = value; }
        }

        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        public DateTime UpdatedDate
        {
            get { return _dUpdatedDate; }
            set { _dUpdatedDate = value; }
        }

        public int IsCurrent
        {
            get { return _nIsCurrent; }
            set { _nIsCurrent = value; }
        }

        public string Grade
        {
            get { return _sGrade; }
            set { _sGrade = value; }
        }

        public string Position
        {
            get { return _sPosition; }
            set { _sPosition = value; }
        }

        public string DBBLAccNo
        {
            get { return _sDBBLAccNo; }
            set { _sDBBLAccNo = value; }
        }

        public string DBBLMobNo
        {
            get { return _sDBBLMobNo; }
            set { _sDBBLMobNo = value; }
        }

        public string ShortName
        {
            get { return _sShortName; }
            set { _sShortName = value.Trim(); }
        }

        // <summary>
        // Get set property for DSRID
        // </summary>
        public int DSRID
        {
            get { return _nDSRID; }
            set { _nDSRID = value; }
        }

        // <summary>
        // Get set property for DistributorID
        // </summary>
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }

        // <summary>
        // Get set property for DSRCode
        // </summary>
        public int DSRCode
        {
            get { return _nDSRCode; }
            set { _nDSRCode = value; }
        }

        // <summary>
        // Get set property for DSRName
        // </summary>
        public string DSRName
        {
            get { return _sDSRName; }
            set { _sDSRName = value.Trim(); }
        }

        // <summary>
        // Get set property for DSRMobile
        // </summary>
        public string DSRMobile
        {
            get { return _sDSRMobile; }
            set { _sDSRMobile = value.Trim(); }
        }

        // <summary>
        // Get set property for Isactive
        // </summary>
        public int Isactive
        {
            get { return _nIsactive; }
            set { _nIsactive = value; }
        }
        public double Basic
        {
            get { return _nBasic; }
            set { _nBasic = value; }
        }

        private double _nLWPDeduction;
        public double LWPDeduction
        {
            get { return _nLWPDeduction; }
            set { _nLWPDeduction = value; }
        }

        private int _nLWP;
        public int LWP
        {
            get { return _nLWP; }
            set { _nLWP = value; }
        }

        private double _ExcessInternet;
        public double ExcessInternet
        {
            get { return _ExcessInternet; }
            set { _ExcessInternet = value; }
        }

        private double _Repair;
        public double Repair
        {
            get { return _Repair; }
            set { _Repair = value; }
        }

        private double _Addition;
        public double Addition
        {
            get { return _Addition; }
            set { _Addition = value; }
        }
        private double _TabDeduction;
        public double TabDeduction
        {
            get { return _TabDeduction; }
            set { _TabDeduction = value; }
        }

        private int _StrikeRate;
        public int StrikeRate
        {
            get { return _StrikeRate; }
            set { _StrikeRate = value; }
        }
        public void Add()
        {
            int nMaxDSRID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DSRID]) FROM t_DMSDSR";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDSRID = 1;
                }
                else
                {
                    nMaxDSRID = Convert.ToInt32(maxID) + 1;
                }
                _nDSRID = nMaxDSRID;
                sSql = "INSERT INTO t_DMSDSR (DSRID, DistributorID, DSRCode, DSRName, DSRMobile, Isactive) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("DSRCode", _nDSRCode);
                cmd.Parameters.AddWithValue("DSRName", _sDSRName);
                cmd.Parameters.AddWithValue("DSRMobile", _sDSRMobile);
                cmd.Parameters.AddWithValue("Isactive", _nIsactive);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddDSRSalary()
        {

            int nTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSDSRSalary";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nTranID = 1;
                }
                else
                {
                    nTranID = Convert.ToInt32(maxID) + 1;
                }
                _nTranID = nTranID;

                sSql = " INSERT INTO t_DMSDSRSalary values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("Month",_nMonth );
                cmd.Parameters.AddWithValue("Year", _nYear);
                cmd.Parameters.AddWithValue("PaymentMode", _sPaymentmode);
                cmd.Parameters.AddWithValue("PaymentType", _sPaymentType);
                cmd.Parameters.AddWithValue("SalesTO", _nSales);
                cmd.Parameters.AddWithValue("TGTTO", _nTarget);
                cmd.Parameters.AddWithValue("Ach", _nAch);

                cmd.Parameters.AddWithValue("WorkingDay", _nSalaryDay);
                cmd.Parameters.AddWithValue("WorkingDayActual", _nWorkingDayAcual);


                cmd.Parameters.AddWithValue("FixedSalary", _nFixedSalary);
             //   cmd.Parameters.AddWithValue("Variable", _nVariableSalary);
                cmd.Parameters.AddWithValue("TotalTADA", _nTADA);
                cmd.Parameters.AddWithValue("TotalAllowance", _nTotalAllowance);
                cmd.Parameters.AddWithValue("Others", _nOthers);


                //cmd.Parameters.AddWithValue("TADA", _nTADA);
                //cmd.Parameters.AddWithValue("Allowance", _nAllowance);
                //cmd.Parameters.AddWithValue("Others", _nOthers);

                cmd.Parameters.AddWithValue("MobileBill", _nMobileBill);
                cmd.Parameters.AddWithValue("Deduction", _nDeduction);
                cmd.Parameters.AddWithValue("CalculatedSalary", _nCalculatedSalary);
                cmd.Parameters.AddWithValue("NetPayable", _nNetPayable);
                cmd.Parameters.AddWithValue("Remarks", Remarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsHeldUp", _nIsHeldUp);
                         


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddDSRBasicSalary()
        {

            int nTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSDSRSalary";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nTranID = 1;
                }
                else
                {
                    nTranID = Convert.ToInt32(maxID) + 1;
                }
                _nTranID = nTranID;

                sSql = " INSERT INTO t_DMSDSRSalary values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("Month", _nMonth);
                cmd.Parameters.AddWithValue("Year", _nYear);
                cmd.Parameters.AddWithValue("PaymentMode", _sPaymentmode);
                cmd.Parameters.AddWithValue("PaymentType", _sPaymentType);
                cmd.Parameters.AddWithValue("SalesTO", _nSales);
                cmd.Parameters.AddWithValue("TargetTO", _nTarget);
                cmd.Parameters.AddWithValue("Ach", _nAch);

                cmd.Parameters.AddWithValue("WorkingDay",_nSalaryDay);
                cmd.Parameters.AddWithValue("WorkingDayActual", _nWorkingDayAcual);


                cmd.Parameters.AddWithValue("FixedSalary", _nFixedSalary);
            //    cmd.Parameters.AddWithValue("VariableSalary", _nVariableSalary);
                cmd.Parameters.AddWithValue("TADA", _nTADA);
                cmd.Parameters.AddWithValue("Allowance", _nTotalAllowance);
                cmd.Parameters.AddWithValue("Others", _nOthers);               

                cmd.Parameters.AddWithValue("MobileBill", _nMobileBill);
                cmd.Parameters.AddWithValue("Deduction", _nDeduction);
                cmd.Parameters.AddWithValue("CalculatedSlary", _nCalculatedSalary);
                cmd.Parameters.AddWithValue("NetPayable", _nNetPayable);
                cmd.Parameters.AddWithValue("Remarks", Remarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsHeldUp", _nIsHeldUp);
                cmd.ExecuteScalar();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddDSRBasicSalaryDetails()
        {

            int nTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TranID]) FROM t_DMSDSRSalary";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nTranID = 1;
                }
                else
                {
                    nTranID = Convert.ToInt32(maxID) + 1;
                }
                _nTranID = nTranID;

                sSql = " INSERT INTO t_DMSDSRBasicSalaryDetails values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("Month", _nMonth);
                cmd.Parameters.AddWithValue("Year", _nYear);
                cmd.Parameters.AddWithValue("PaymentMode", _sPaymentmode);
                cmd.Parameters.AddWithValue("PaymentType", _sPaymentType);
                cmd.Parameters.AddWithValue("SalesTO", _nSales);
                cmd.Parameters.AddWithValue("TargetTO", _nTarget);
                cmd.Parameters.AddWithValue("Ach", _nAch);

                cmd.Parameters.AddWithValue("WorkingDay", _nSalaryDay);
                cmd.Parameters.AddWithValue("WorkingDayActual", _nWorkingDayAcual);
                cmd.Parameters.AddWithValue("SpcWD", _SpcWD);


                cmd.Parameters.AddWithValue("FixedSalary", _nFixedSalary);
                cmd.Parameters.AddWithValue("VariableSalary", _nVariableSalary);
                cmd.Parameters.AddWithValue("TADA", _nTotalTADA);
                cmd.Parameters.AddWithValue("Allowance", _nTotalAllowance);
                cmd.Parameters.AddWithValue("Others", _nOthers);

                cmd.Parameters.AddWithValue("MobileBill", _nMobileBill);
                cmd.Parameters.AddWithValue("Deduction", _nDeduction);
                cmd.Parameters.AddWithValue("CalculatedSlary", _nCalculatedSalary);
                cmd.Parameters.AddWithValue("NetPayable", _nNetPayable);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsHeldUp", _nIsHeldUp);



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
                sSql = "UPDATE t_DMSDSR SET DistributorID = ?, DSRCode = ?, DSRName = ?, DSRMobile = ?, Isactive = ? WHERE DSRID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("DSRCode", _nDSRCode);
                cmd.Parameters.AddWithValue("DSRName", _sDSRName);
                cmd.Parameters.AddWithValue("DSRMobile", _sDSRMobile);
                cmd.Parameters.AddWithValue("Isactive", _nIsactive);

                cmd.Parameters.AddWithValue("DSRID", _nDSRID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateSalary()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = " update t_DMSDSRSalary set TADA= ?,Allowance=?, Others=?, NetPayable= ?, Deduction=?,WorkingDayActual=?, Remarks= ?, Status=? where TRanID= ? and DSRID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TADA", _nTotalTADA);
                cmd.Parameters.AddWithValue("Allowance", _nTotalAllowance);
                cmd.Parameters.AddWithValue("Others", _nTotalOthers);

                cmd.Parameters.AddWithValue("NetPayable", _nNetPayable);
                cmd.Parameters.AddWithValue("Deduction", _nDeduction);
                cmd.Parameters.AddWithValue("WorkingDayActual", _nWorkingDayAcual);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);              
                               
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
                sSql = "DELETE FROM t_DMSDSR WHERE [DSRID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteDSRSalary(int mMonth, int mYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = " delete from t_DMSDSRSalary where Month=" + mMonth + " and Year=" + mYear+ " and status=1  ";
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
        public void DeleteDSRSalary_BasicDetails(int mMonth, int mYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = " delete from t_DMSDSRBasicSalaryDetails where Month=" + mMonth + " and Year=" + mYear + " and status=1  ";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_DMSDSR where DSRID =?";
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDSRID = (int)reader["DSRID"];
                    _nDistributorID = (int)reader["DistributorID"];
                    _nDSRCode = (int)reader["DSRCode"];
                    _sDSRName = (string)reader["DSRName"];
                    _sDSRMobile = (string)reader["DSRMobile"];
                    _nIsactive = (int)reader["Isactive"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void CheckSalaryData(int mMonth, int mYear)
        {
            int nCount = 0;
          
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select count(DSRID)as DCount from t_DMSDSRSalary where Month=" + mMonth + " and Year=" + mYear + " and status=2  ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {                  
                  _nDataCount = Convert.ToInt32(reader["DCount"]);
                    nCount++;                   
                }
                reader.Close();
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddDSRDetails()
        {
            int nMaxTranID = 0;
            int nMaxDSRID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbCommand cmd2 = DBController.Instance.GetCommand();
            string sSql = "";
            string sSql2 = "";
            try
            {
                sSql = "SELECT MAX([TranID])as TranID FROM t_DMSDSRDetails";
                sSql2 = "SELECT MAX([DSRID]) as DSRID FROM t_DMSDSRDetails";

                cmd.CommandText = sSql;
                cmd2.CommandText = sSql2;
                object maxID = cmd.ExecuteScalar();
                object dsrid = cmd2.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTranID = 1;

                }
                else
                {
                    nMaxTranID = Convert.ToInt32(maxID) + 1;
                }

                if (dsrid == DBNull.Value)
                {
                    nMaxDSRID = 1;

                }
                else
                {
                    nMaxDSRID = Convert.ToInt32(dsrid) + 1;
                }

                _nTranID = nMaxTranID;
                _nDSRID = nMaxDSRID;

                sSql = "INSERT INTO t_DMSDSRDetails (TranID, DSRID, CustomerID, DSRCode, DSRName, ShortName,DateofBirth, DSRMobile, Designation, EmployeeType, PaymentMode, PaymentType, IsHeldUp, JoiningDate, UpdatedDate, FixedSalary,VariableSalary, DailyTADA, DailySpcAllowance, OthersAllowance, MobileBill, BkashAccountNo,DBBLAccNo,DBBLMobNo, IsCurrent, Grade, Position, TownType, AccountType) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DSRCode", _nDSRCode);
                cmd.Parameters.AddWithValue("DSRName", _sDSRName);
                cmd.Parameters.AddWithValue("ShortName", _sShortName);
                cmd.Parameters.AddWithValue("DSRMobile", _sDSRMobile);
                cmd.Parameters.AddWithValue("DateofBirth", _dDOB);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("EmployeeType", _sEmployeeType);
                cmd.Parameters.AddWithValue("PaymentMode", _sPaymentmode);
                cmd.Parameters.AddWithValue("PaymentType", _sPaymentType);
                cmd.Parameters.AddWithValue("IsHeldUp", _nIsHeldUp);
                cmd.Parameters.AddWithValue("JoiningDate", _dJoiningDate);
                cmd.Parameters.AddWithValue("UpdatedDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("FixedSalary", _nFixedSalary);
                cmd.Parameters.AddWithValue("VariableSalary", _nVariableSalary);
                cmd.Parameters.AddWithValue("DailyTADA", _nDailyTADA);
                cmd.Parameters.AddWithValue("DailySpcAllowance", _nDailySpcAllowance);
                cmd.Parameters.AddWithValue("OthersAllowance", _nOthersAllowance);
                cmd.Parameters.AddWithValue("MobileBill", _nMobileBill);
                cmd.Parameters.AddWithValue("BkashAccountNo", _sBkashAccountNo);
                cmd.Parameters.AddWithValue("DBBLAccNo", _sDBBLAccNo);
                cmd.Parameters.AddWithValue("DBBLMobNo", _sDBBLMobNo);
                cmd.Parameters.AddWithValue("IsCurrent", _nIsCurrent);
                cmd.Parameters.AddWithValue("Grade", _sGrade);
                cmd.Parameters.AddWithValue("Position", _sPosition);
                cmd.Parameters.AddWithValue("TownType", _sTownType);
                cmd.Parameters.AddWithValue("AccountType", _sAccountType);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditDSRDetails()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            //try
            //{
                sSql = "UPDATE t_DMSDSRDetails SET DSRID = ?, CustomerID = ?, DSRCode = ?, DSRName = ?, ShortName = ?, DSRMobile = ?, Designation = ?,DateofBirth = ?, EmployeeType = ?, PaymentMode = ?, PaymentType = ?, IsHeldUp = ?, JoiningDate = ?, UpdatedDate = ?, FixedSalary = ?,VariableSalary = ?, DailyTADA = ?, DailySpcAllowance = ?, OthersAllowance = ?, MobileBill = ?, BkashAccountNo = ?, DBBLAccNo = ?, DBBLMobNo= ?, IsCurrent = ?, Grade = ?, Position = ?, TownType = ?, AccountType = ?, ResignDate = ? WHERE TranID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DSRCode", _nDSRCode);
                cmd.Parameters.AddWithValue("DSRName", _sDSRName);
                cmd.Parameters.AddWithValue("ShortName", _sShortName);
                cmd.Parameters.AddWithValue("DSRMobile", _sDSRMobile);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("DateofBirth", _dDOB);
                cmd.Parameters.AddWithValue("EmployeeType", _sEmployeeType);
                cmd.Parameters.AddWithValue("PaymentMode", _sPaymentmode);
                cmd.Parameters.AddWithValue("PaymentType", _sPaymentType);
                cmd.Parameters.AddWithValue("IsHeldUp", _nIsHeldUp);
                cmd.Parameters.AddWithValue("JoiningDate", _dJoiningDate);
                cmd.Parameters.AddWithValue("UpdatedDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("FixedSalary", _nFixedSalary);
                cmd.Parameters.AddWithValue("VariableSalary", _nVariableSalary);
                cmd.Parameters.AddWithValue("DailyTADA", _nDailyTADA);
                cmd.Parameters.AddWithValue("DailySpcAllowance", _nDailySpcAllowance);
                cmd.Parameters.AddWithValue("OthersAllowance", _nOthersAllowance);
                cmd.Parameters.AddWithValue("MobileBill", _nMobileBill);
                cmd.Parameters.AddWithValue("BkashAccountNo", _sBkashAccountNo);
                cmd.Parameters.AddWithValue("DBBLAccNo", _sDBBLAccNo);
                cmd.Parameters.AddWithValue("DBBLMobNo", _sDBBLMobNo);
                cmd.Parameters.AddWithValue("IsCurrent", _nIsCurrent);
                cmd.Parameters.AddWithValue("Grade", _sGrade);
                cmd.Parameters.AddWithValue("Position", _sPosition);
                cmd.Parameters.AddWithValue("TownType", _sTownType);
                cmd.Parameters.AddWithValue("AccountType", _sAccountType);
                cmd.Parameters.AddWithValue("ResignDate", _dResignDate);
                cmd.Parameters.AddWithValue("TranID", _nTranID);
             


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
        }
    }
    public class DMSDSRs : CollectionBase
    {
        public DMSDSR this[int i]
        {
            get { return (DMSDSR)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DMSDSR oDMSDSR)
        {
            InnerList.Add(oDMSDSR);
        }
        public int GetIndex(int nDSRID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].DSRID == nDSRID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(int nCustomerId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_dmsdsr where Isactive =1 and distributorid= ?  ";
            cmd.Parameters.AddWithValue("DistributorID", nCustomerId);
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSDSR oDMSDSR = new DMSDSR();
                    oDMSDSR.DSRID = (int)reader["DSRID"];
                    oDMSDSR.DistributorID = (int)reader["DistributorID"];
                    oDMSDSR.DSRCode = (int)reader["DSRCode"];
                    oDMSDSR.DSRName = (string)reader["DSRName"];
                    oDMSDSR.DSRMobile = (string)reader["DSRMobile"];
                    
                    oDMSDSR.DSRID = (int)reader["DSRID"];

                    InnerList.Add(oDMSDSR);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CheckSalaryData(int mMonth, int mYear)
        {
            int nCount = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select count(DSRID)as DCount from t_DMSDSRSalary where Month=" + mMonth + " and Year=" + mYear + " and status=2  ";
                      

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSDSR oDMSDSR = new DMSDSR();
                    oDMSDSR.DataCount =Convert.ToInt32(reader["DCount"]);
                    nCount++;

                    InnerList.Add(oDMSDSR);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //public void RefreshDSRSalary(int nMonth, int nYear, DateTime dStartDate, DateTime dEndDate)
        //{
            
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();



        //    string sSql = " select CustomerCode,CustomerName,AreaName,TerritoryName,isnull(SysWorkingDay,0)As SysWorkingDay, Total.*,   " +
        //                " (DailyTADA*WorkingDay)as TotalTADA,(DailySpcAllowance*WorkingDay)as TotalAllowance,(OthersAllowance*WorkingDay)as TotalOthers, DAY(DATEADD(DD,-1,DATEADD(MM,DATEDIFF(MM,-1,'" + dStartDate + "'),0)))as DaysinMonth " +
        //                " from  " +
        //                " ( " +
        //                " select Main.*,isnull(TargetTO,0)As TargetTO,isnull(SalesTO,0)As SalesTO,isnull(Deduction,0)As Deduction, isnull(Ach,0)as Ach, isnull(TotalDay,0)As TotalDay, " +
        //                " isnull(SalaryDay,0)As SalaryDay, isnull(WorkingDay,0)As WorkingDay  " +
        //                " from  " +
        //                " (  " +
        //                " select * from t_DMSDSRDetails where Iscurrent=1  " +
        //                " )As Main  " +
        //                " left outer join  " +
        //                " (  " +
        //                " select DSRID,DSRCode,TargetTO,SalesTO,isnull(Deduction,0)as Deduction, round(isnull((SalesTO/nullif (TargetTO,0))*100,0),0)As Ach ,TotalDay,SalaryDay,WorkingDay  " +
        //                " from t_DMSDSRSalaryTgt   " +
        //                " where SalaryMonth between '" + dStartDate + "' and '" + dEndDate + "' and  SalaryMonth < '" + dEndDate + "' " +
        //                " )as Days on Main.DSRCode=Days.DSRCode  " +
        //                " )As Total  " +
        //                " left outer join (select CustomerId,CustomerCode,CustomerName,AreaName,TerritoryName from v_CustomerDetails )as Cust on Total.CustomerID=Cust.CustomerID  " +
        //                " left outer join " +
        //                " (  " +
        //                " select DSRID, count(TranDate)as SysWorkingDay   " +
        //                " from   " +
        //                " (   " +
        //                " select distinct TranDate,DSRID    " +
        //                " from    " +
        //                " (    " +
        //                " select distinct TranDate,RouteID   " +
        //                " from t_DMSProductTran a, t_DMSOutlet b  " +
        //                " where TranTypeID=2 and TranDate between '" + dStartDate + "' and '" + dEndDate + "' and  TranDate < '" + dEndDate + "' " +
        //                " and a.OutletID=b.OutletID   " +
        //                " )As Q1   " +
        //                " left outer join ( select DSRID,RouteID from t_DMSRoute )as Q2 on Q1.RouteID=Q2.RouteID   " +
        //                " group by TranDate,DSRID " +
        //                " )As Final group by DSRID " +
        //                " )as Dcount on Total.DSRID=Dcount.DSRID  ";




        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
               
        //        while (reader.Read())
        //        {
        //            DMSDSR oDMSDSR = new DMSDSR();

                      
        //            oDMSDSR.CustomerCode = (string)reader["CustomerCode"];
        //            oDMSDSR.DistributorID = (int)reader["CustomerID"];
        //            oDMSDSR.CustomerName = (string)reader["CustomerName"];
        //            oDMSDSR.AreaName = (string)reader["AreaName"];

        //            oDMSDSR.DSRID = (int)reader["DSRID"];
        //            oDMSDSR.DSRCode = (int)reader["DSRCode"];
        //            oDMSDSR.DSRName = (string)reader["DSRName"];
        //            oDMSDSR.Designation = (string)reader["Designation"];
        //            oDMSDSR.PaymentMode = (string)reader["PaymentMode"];
        //            oDMSDSR.PaymentType = (string)reader["PaymentType"];

        //            oDMSDSR.FixedSalary = Convert.ToDouble(reader["FixedSalary"]);
        //            oDMSDSR.TADA = Convert.ToDouble(reader["DailyTADA"]);
        //            oDMSDSR.Allowance = Convert.ToDouble(reader["DailySpcAllowance"]);
        //            oDMSDSR.Others = Convert.ToDouble(reader["OthersAllowance"]);

        //            oDMSDSR.TotalTADA = Convert.ToDouble(reader["TotalTADA"]);
        //            oDMSDSR.TotalAllowance = Convert.ToDouble(reader["TotalAllowance"]);
        //            oDMSDSR.TotalOthers = Convert.ToDouble(reader["TotalOthers"]);

        //            oDMSDSR.JoiningDate = Convert.ToDateTime(reader["JoiningDate"]);
        //            oDMSDSR.MobileBill = Convert.ToDouble(reader["MobileBill"]);
        //            oDMSDSR.Deduction = Convert.ToDouble(reader["Deduction"]);
        //            oDMSDSR.Others = Convert.ToDouble(reader["OthersAllowance"]);

        //            oDMSDSR.WorkingDay = (int)reader["WorkingDay"];
        //            oDMSDSR.WorkingDayActual=(int)reader["WorkingDay"];
        //            oDMSDSR.TotalDay = (int)reader["TotalDay"];
        //            oDMSDSR.SalaryDay = (int)reader["SalaryDay"];
        //            oDMSDSR.DaysinMonth = (int)reader["DaysinMonth"];

        //            oDMSDSR.Sales = Convert.ToDouble(reader["SalesTO"]);
        //            oDMSDSR.Target = Convert.ToDouble(reader["TargetTO"]);
        //            oDMSDSR.Ach = Convert.ToDouble(reader["Ach"]);
        //            oDMSDSR.IsHeldUp = Convert.ToInt16(reader["IsHeldUp"]);
                    

        //            if (oDMSDSR.JoiningDate.Month==nMonth && oDMSDSR.JoiningDate.Year==nYear)
        //            {
        //                oDMSDSR.CalculatedSalary = (((oDMSDSR.FixedSalary / oDMSDSR.DaysinMonth) * (oDMSDSR.SalaryDay)) + (oDMSDSR.TotalTADA + oDMSDSR.TotalAllowance + oDMSDSR.TotalOthers + oDMSDSR.MobileBill) - oDMSDSR.Deduction);
        //                oDMSDSR.Netpayable = (((oDMSDSR.FixedSalary / oDMSDSR.DaysinMonth) * (oDMSDSR.SalaryDay)) + (oDMSDSR.TotalTADA + oDMSDSR.TotalAllowance + oDMSDSR.TotalOthers + oDMSDSR.MobileBill) - oDMSDSR.Deduction);
        //                oDMSDSR.FixedSalary = ((oDMSDSR.FixedSalary / oDMSDSR.DaysinMonth) * (oDMSDSR.SalaryDay));

        //            }

        //            else
        //            {
        //                if (oDMSDSR.SalaryDay >= oDMSDSR.TotalDay)
        //                {
        //                    oDMSDSR.CalculatedSalary = (oDMSDSR.FixedSalary + (oDMSDSR.TotalTADA + oDMSDSR.TotalAllowance + oDMSDSR.TotalOthers + oDMSDSR.MobileBill) - oDMSDSR.Deduction);
        //                    oDMSDSR.Netpayable = (oDMSDSR.FixedSalary + (oDMSDSR.TotalTADA + oDMSDSR.TotalAllowance + oDMSDSR.TotalOthers + oDMSDSR.MobileBill) - oDMSDSR.Deduction);
        //                }

        //                if (oDMSDSR.SalaryDay < oDMSDSR.TotalDay)
        //                {
        //                    try
        //                    {
        //                        oDMSDSR.CalculatedSalary = (((oDMSDSR.FixedSalary / oDMSDSR.DaysinMonth) * (oDMSDSR.SalaryDay)) + (oDMSDSR.TotalTADA + oDMSDSR.TotalAllowance + oDMSDSR.TotalOthers + oDMSDSR.MobileBill) - oDMSDSR.Deduction);
        //                        oDMSDSR.Netpayable = (((oDMSDSR.FixedSalary / oDMSDSR.DaysinMonth) * (oDMSDSR.SalaryDay)) + (oDMSDSR.TotalTADA + oDMSDSR.TotalAllowance + oDMSDSR.TotalOthers + oDMSDSR.MobileBill) - oDMSDSR.Deduction);
        //                        oDMSDSR.FixedSalary = ((oDMSDSR.FixedSalary / oDMSDSR.DaysinMonth) * (oDMSDSR.SalaryDay));
        //                    }

        //                    catch (Exception ex)
        //                    {
        //                        oDMSDSR.CalculatedSalary = 0;
        //                        oDMSDSR.Netpayable = 0;
        //                    }
        //                }
        //            }
                    
        //            oDMSDSR.Month=nMonth;
        //            oDMSDSR.Year=nYear;
        //            oDMSDSR.Status =(int) Dictionary.DSRSalaryStatus.Create;
        //            oDMSDSR.Remarks = "";
                    
        //            InnerList.Add(oDMSDSR);
        //        }

        //        reader.Close();
        //        InnerList.TrimToSize();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        public void RefreshDSRBasicSalary(int nMonth, int nYear, DateTime dStartDate, DateTime dEndDate)
        {
            DateTime Salarymonth = new DateTime(nYear,nMonth, 1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"
            Select Main.DSRID,DS.DSRCode,DS.DSRName,DS.Designation,
            DS.PaymentMode,
            DS.PaymentType,
            Main.FixedSalary,
            Main.VariableSalary,
            DS.DailyTADA,
            DS.JoiningDate, 
            nullif(DS.ResignDate,null) as ResignDate, 
            DS.MobileBill,
            Main.LWPDeduction,
            Main.TABDeduction,
            Main.TotalDay,Main.SalaryDay,Main.WorkingDay,Main.LWP,Main.LWPDeduction,
            Main.SalesTO,Main.TargetTO,
            round(isnull((SalesTO / nullif(TargetTO, 0)) * 100, 0), 0)As Ach,
            TotalDeduction,
            DS.IsHeldUp,Main.Remarks
            from(
            select * from t_DMSDSRSalaryProcess
            ) as Main
            left join t_DMSDSRDetails DS on DS.DSRID = Main.DSRID
            where Main.SalaryMonth = '" + Salarymonth.ToString("dd-MMM-yyyy")+"' ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DMSDSR oDMSDSR = new DMSDSR();
                    oDMSDSR.DSRID = (int)reader["DSRID"];
                    oDMSDSR.DSRCode = (int)reader["DSRCode"];
                    oDMSDSR.DSRName = (string)reader["DSRName"];
                    oDMSDSR.Designation = (string)reader["Designation"];
                    oDMSDSR.PaymentMode = (string)reader["PaymentMode"];
                    oDMSDSR.PaymentType = (string)reader["PaymentType"];
                    oDMSDSR.FixedSalary = Convert.ToDouble(reader["FixedSalary"]);
                    oDMSDSR.VariableSalary = Convert.ToDouble(reader["VariableSalary"]);
                    oDMSDSR.TADA = Convert.ToDouble(reader["DailyTADA"]);
                    oDMSDSR.JoiningDate = Convert.ToDateTime(reader["JoiningDate"]);
                    if (reader["ResignDate"] != DBNull.Value)
                    {
                        oDMSDSR.ResignDate = Convert.ToDateTime(reader["ResignDate"]);
                    }
                    oDMSDSR.MobileBill = 0;
                    oDMSDSR.LWPDeduction = Convert.ToDouble(reader["LWPDeduction"]);
                    oDMSDSR.TabDeduction = Convert.ToDouble(reader["TABDeduction"]);
                    oDMSDSR.Deduction = Convert.ToDouble(reader["TotalDeduction"]);
                    oDMSDSR.WorkingDay = (int)reader["WorkingDay"];
                    oDMSDSR.WorkingDayActual = (int)reader["WorkingDay"];
                    oDMSDSR.TotalDay = (int)reader["TotalDay"];
                    oDMSDSR.SalaryDay = (int)reader["SalaryDay"];
                    oDMSDSR.DaysinMonth = (int)reader["TotalDay"];
                    oDMSDSR.LWP = (int)reader["LWP"];
                    oDMSDSR.Sales = Convert.ToDouble(reader["SalesTO"]);
                    oDMSDSR.Target = Convert.ToDouble(reader["TargetTO"]);
                    oDMSDSR.Ach = Convert.ToDouble(reader["Ach"]);
                    oDMSDSR.IsHeldUp = Convert.ToInt16(reader["IsHeldUp"]);
                    oDMSDSR.Remarks = Convert.ToString(reader["Remarks"]);


                    //oDMSDSR.CustomerCode = (string)reader["CustomerCode"];
                    //oDMSDSR.DistributorID = (int)reader["CustomerID"];
                    //oDMSDSR.CustomerName = (string)reader["CustomerName"];
                    //oDMSDSR.AreaName = (string)reader["AreaName"];
                    //oDMSDSR.Allowance = Convert.ToDouble(reader["DailySpcAllowance"]);
                    //oDMSDSR.Others = Convert.ToDouble(reader["OthersAllowance"]);
                    //oDMSDSR.TotalTADA = Convert.ToDouble(reader["TotalTADA"]);
                    //oDMSDSR.TotalAllowance = Convert.ToDouble(reader["TotalAllowance"]);
                    //oDMSDSR.TotalOthers = Convert.ToDouble(reader["TotalOthers"]);
                    //oDMSDSR.MobileBill = Convert.ToDouble(reader["MobileBill"]);
                    //oDMSDSR.Others = Convert.ToDouble(reader["OthersAllowance"]);

                    if (oDMSDSR.JoiningDate.Month==nMonth && oDMSDSR.JoiningDate.Year==nYear)
                    {
                        if (reader["ResignDate"] != DBNull.Value)
                        {
                            if (Convert.ToDateTime(oDMSDSR.ResignDate).Month == nMonth && oDMSDSR.Year == nYear)
                            {
                                int Absent = (oDMSDSR.JoiningDate.Day - 1) + (oDMSDSR.DaysinMonth - Convert.ToDateTime(oDMSDSR.ResignDate).Day);          
                                oDMSDSR.WorkingDayActual = oDMSDSR.DaysinMonth - Absent;

                                if (oDMSDSR.WorkingDayActual > oDMSDSR.SalaryDay)
                                {
                                    oDMSDSR.WorkingDayActual = oDMSDSR.SalaryDay;
                                }

                                double perDay = oDMSDSR.FixedSalary / oDMSDSR.DaysinMonth;

                                oDMSDSR.CalculatedSalary = perDay * oDMSDSR.WorkingDayActual;
                                oDMSDSR.Netpayable = (perDay * oDMSDSR.WorkingDayActual)-oDMSDSR.Deduction;
                                oDMSDSR.Deduction = oDMSDSR.FixedSalary - oDMSDSR.Netpayable;                               
                                

                            }
                        }

                        else
                        {
                            int Absent = (oDMSDSR.JoiningDate.Day - 1);
                            
                            oDMSDSR.WorkingDayActual = oDMSDSR.DaysinMonth - Absent;
                            if (oDMSDSR.WorkingDayActual > oDMSDSR.SalaryDay)
                            {
                                oDMSDSR.WorkingDayActual = oDMSDSR.SalaryDay;
                            }
                            double perDay = oDMSDSR.FixedSalary / oDMSDSR.DaysinMonth;
                            oDMSDSR.CalculatedSalary = perDay * oDMSDSR.WorkingDayActual;
                            oDMSDSR.Netpayable = (perDay * oDMSDSR.WorkingDayActual)-oDMSDSR.Deduction;
                            oDMSDSR.Deduction = oDMSDSR.FixedSalary - oDMSDSR.Netpayable-(perDay*Absent);

                        }

                    }

                    else
                    {
                            oDMSDSR.CalculatedSalary = (oDMSDSR.FixedSalary-oDMSDSR.Deduction);
                            oDMSDSR.Netpayable = (oDMSDSR.CalculatedSalary);
                            oDMSDSR.Deduction = oDMSDSR.Deduction;
                       
                    }

                    oDMSDSR.Month = nMonth;
                    oDMSDSR.Year = nYear;
                    oDMSDSR.Status = (int)Dictionary.DSRSalaryStatus.Create;                  

                    InnerList.Add(oDMSDSR);
                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshDSRSalary(int nMonth, int nYear, DateTime dStartDate, DateTime dEndDate)
        {
            int SAD = 0;
            DateTime Salarymonth = new DateTime(nYear, nMonth, 1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"
                            Select Main.DSRID,DS.DSRCode,DS.DSRName,DS.Designation,
                            DS.PaymentMode,DS.PaymentType,DS.DailySpcAllowance,
                            Main.FixedSalary,DS.VariableSalary,
                            DS.DailyTADA,DS.MobileBill,
                            Main.LWPDeduction,Main.TABDeduction,
                            Main.ExcessInternet,Main.Repair,Main.Others,Main.Addition,
                            Main.TotalDay,Main.SalaryDay,
                            --(Main.SalaryDay-Main.LWP) as WorkingDayActual,
                            SDS.WorkingDayActual,SDS.SpcWD,
                            Main.LWP,Main.LWPDeduction,Main.SalesTO,Main.TargetTO,
                            round(isnull((Main.SalesTO / nullif(Main.TargetTO, 0)) * 100, 0), 0)As Ach,
                            TotalDeduction,DS.IsHeldUp,SDS.Deduction,SDS.NetPayable,
                            isnull(SR.StrikeRate,0) as StrikeRate,isnull(SR.Exception,0) as Exception,Main.Remarks
                            from(
                            select * from t_DMSDSRSalaryProcess
                            ) as Main
                            left join t_DMSDSRDetails DS on DS.DSRID = Main.DSRID
                            left join t_DMSDSRBasicSalaryDetails SDS on SDS.DSRID=Main.DSRID
                            left join t_DMSStrikeRate SR on SR.DSRCOde=Main.DSRCode and Cast(Main.SalaryMonth as datetime)=cast(SR.SalesMonth as datetime)

                            where Main.SalaryMonth = '" + Salarymonth.ToString("dd-MMM-yyyy") + "' ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DMSDSR oDMSDSR = new DMSDSR();
                    oDMSDSR.DSRID = (int)reader["DSRID"];
                    oDMSDSR.DSRCode = (int)reader["DSRCode"];
                    oDMSDSR.DSRName = (string)reader["DSRName"];
                    oDMSDSR.Designation = (string)reader["Designation"];
                    oDMSDSR.PaymentMode = (string)reader["PaymentMode"];
                    oDMSDSR.PaymentType = (string)reader["PaymentType"];
                    oDMSDSR.FixedSalary = Convert.ToDouble(reader["FixedSalary"]);                   
                    oDMSDSR.DailyTADA = Convert.ToDouble(reader["DailyTADA"]);
                    oDMSDSR.MobileBill = Convert.ToDouble(reader["MobileBill"]);
                    oDMSDSR.LWPDeduction = Convert.ToDouble(reader["LWPDeduction"]);
                    oDMSDSR.ExcessInternet = Convert.ToDouble(reader["ExcessInternet"]);
                    oDMSDSR.Repair = Convert.ToDouble(reader["Repair"]);
                    oDMSDSR.Others = Convert.ToDouble(reader["Others"]);
                    oDMSDSR.Addition = Convert.ToDouble(reader["Addition"]);
                    oDMSDSR.TabDeduction = Convert.ToDouble(reader["TabDeduction"]);
                    oDMSDSR.WorkingDayActual = (int)reader["WorkingDayActual"];
                    oDMSDSR.SpcWD = (int)reader["SpcWD"];
                    oDMSDSR.SalaryDay = (int)reader["SalaryDay"];
                    oDMSDSR.DaysinMonth = (int)reader["TotalDay"];
                    oDMSDSR.DailySpcAllowance= Convert.ToDouble(reader["DailySpcAllowance"]);
                    oDMSDSR.LWP = (int)reader["LWP"];
                    oDMSDSR.Sales = Convert.ToDouble(reader["SalesTO"]);
                    oDMSDSR.Target = Convert.ToDouble(reader["TargetTO"]);
                    oDMSDSR.Ach = Convert.ToDouble(reader["Ach"]);
                    oDMSDSR.IsHeldUp = Convert.ToInt16(reader["IsHeldUp"]);
                    oDMSDSR.Deduction = Convert.ToInt16(reader["Deduction"]);
                    oDMSDSR.Basic = Convert.ToInt16(reader["NetPayable"]);
                    oDMSDSR.Remarks = (string)reader["Remarks"]; 
                    int StrikeRate= Convert.ToInt16(reader["StrikeRate"]);
                    int Exception= Convert.ToInt16(reader["Exception"]);

                    if (Exception == 0)
                    {
                        if (StrikeRate < 30)
                        {
                            oDMSDSR.DailyTADA = 0;
                        }
                        else if (StrikeRate >= 30 && StrikeRate <= 39)
                        {
                            oDMSDSR.DailyTADA = oDMSDSR.DailyTADA * .5;
                        }
                        else if (StrikeRate >= 40 && StrikeRate <= 49)
                        {
                            oDMSDSR.DailyTADA = oDMSDSR.DailyTADA * .8;
                        }

                        else if (StrikeRate >= 50 && StrikeRate <= 59)
                        {
                            oDMSDSR.DailyTADA = oDMSDSR.DailyTADA * 1;
                        }

                        else if (StrikeRate >= 60)
                        {
                            oDMSDSR.DailyTADA = oDMSDSR.DailyTADA * 1.1;
                        }
                    }

                    if (oDMSDSR.Designation=="GSO")
                    {
                        //if (oDMSDSR.Sales >= 400000)
                        //{
                        //    //Set Variable Salary Only WHo are a=eligible to Get.
                        //    oDMSDSR.VariableSalary = Convert.ToDouble(reader["VariableSalary"]);

                        //    //if (oDMSDSR.WorkingDayActual >= oDMSDSR.SalaryDay)
                        //    //{
                        //    //    SAD = oDMSDSR.WorkingDayActual - oDMSDSR.SalaryDay;
                        //    //    oDMSDSR.TotalAllowance = SAD * oDMSDSR.DailySpcAllowance;
                        //    //}
                        //   // SAD = oDMSDSR.WorkingDayActual - oDMSDSR.SalaryDay;


                        //    oDMSDSR.TotalAllowance = oDMSDSR.SpcWD * oDMSDSR.DailySpcAllowance;
                        //    oDMSDSR.TADA = oDMSDSR.DailyTADA * oDMSDSR.WorkingDayActual;
                        //    oDMSDSR.CalculatedSalary = oDMSDSR.FixedSalary + oDMSDSR.VariableSalary + oDMSDSR.TADA + oDMSDSR.MobileBill + oDMSDSR.Addition +oDMSDSR.TotalAllowance - (oDMSDSR.FixedSalary);
                        //    oDMSDSR.Netpayable = oDMSDSR.CalculatedSalary;
                        //    oDMSDSR.Deduction = (oDMSDSR.FixedSalary);
                        //}                    

                        //else
                        //{
                            //if (oDMSDSR.WorkingDayActual >= oDMSDSR.SalaryDay)
                            //{
                            //    SAD = oDMSDSR.WorkingDayActual - oDMSDSR.SalaryDay;
                            //    oDMSDSR.TotalAllowance = SAD * oDMSDSR.DailySpcAllowance;
                            //}
                            oDMSDSR.TotalAllowance = oDMSDSR.SpcWD * oDMSDSR.DailySpcAllowance;
                            oDMSDSR.TADA = oDMSDSR.DailyTADA * oDMSDSR.WorkingDayActual;
                            oDMSDSR.CalculatedSalary = oDMSDSR.FixedSalary + oDMSDSR.TADA + oDMSDSR.MobileBill + oDMSDSR.Addition +oDMSDSR.TotalAllowance- (oDMSDSR.FixedSalary);
                            oDMSDSR.Netpayable = oDMSDSR.CalculatedSalary;
                            oDMSDSR.Deduction = (oDMSDSR.FixedSalary);

                       // }

                    }

                    else
                    {
                        //if (oDMSDSR.WorkingDayActual >= oDMSDSR.SalaryDay)
                        //{
                        //    SAD = oDMSDSR.WorkingDayActual - oDMSDSR.SalaryDay;
                        //    oDMSDSR.TotalAllowance = SAD * oDMSDSR.DailySpcAllowance;
                        //}
                        oDMSDSR.TotalAllowance = oDMSDSR.SpcWD * oDMSDSR.DailySpcAllowance;
                        oDMSDSR.TADA = oDMSDSR.DailyTADA * oDMSDSR.WorkingDayActual;
                        oDMSDSR.CalculatedSalary = oDMSDSR.FixedSalary + oDMSDSR.TADA + oDMSDSR.MobileBill + oDMSDSR.Addition+oDMSDSR.TotalAllowance - (oDMSDSR.FixedSalary);
                        oDMSDSR.Netpayable = oDMSDSR.CalculatedSalary;
                        oDMSDSR.Deduction = (oDMSDSR.FixedSalary);


                    }

                    oDMSDSR.Month = nMonth;
                    oDMSDSR.Year = nYear;
                    oDMSDSR.Status = (int)Dictionary.DSRSalaryStatus.Create;                  

                    InnerList.Add(oDMSDSR);
                }

                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshSalary(int nMonth, int nYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = @" select Q1.*,DSRCode,DSRName,CustomerID,CustomerCode,CustomerName,AreaName   
                            from(
                            select * from t_DMSDSRSalary where Month = "+nMonth+@" and Year = "+nYear+@"
                            ) as Q1
                            left outer join
                            (
                            select DSRID, DSRCode, DSRName, VariableSalary, a.CustomerID, CustomerCode, CustomerName, AreaName
                            from t_DMSDSRDetails a, v_CustomerDetails b
                            where a.CustomerID = b.CustomerID
                            ) as Q2 on Q1.DSRID = Q2.DSRID
                            order by AreaName,CustomerCode,TranID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSDSR oDMSDSR = new DMSDSR();
                    oDMSDSR.TranID = (int)reader["TranID"];
                    oDMSDSR.DSRID = (int)reader["DSRID"];
                    oDMSDSR.TranDate=Convert.ToDateTime(reader["TranDate"]);
                    oDMSDSR.Month =Convert.ToInt16(reader["Month"]);
                    oDMSDSR.Year = Convert.ToInt16(reader["Year"]);
                    oDMSDSR.PaymentMode = (string)reader["PaymentMode"];
                    oDMSDSR.PaymentType = (string)reader["PaymentType"];
                    oDMSDSR.Ach = Convert.ToDouble(reader["Ach"]);
                    oDMSDSR.WorkingDay = (int)reader["WorkingDay"];
                    oDMSDSR.WorkingDayActual = (int)reader["WorkingDayActual"];
                    oDMSDSR.FixedSalary = Convert.ToDouble(reader["FixedSalary"]);
                   // oDMSDSR.VariableSalary = Convert.ToDouble(reader["VariableSalary"]);
                    oDMSDSR.VariableSalary = Convert.ToDouble(0);

                    //oDMSDSR.TADA = Convert.ToDouble(reader["TADA"]);
                    //oDMSDSR.Allowance = Convert.ToDouble(reader["Allowance"]);
                    //oDMSDSR.Others = Convert.ToDouble(reader["Others"]);

                    oDMSDSR.TotalTADA = Convert.ToDouble(reader["TADA"]);
                    oDMSDSR.TotalAllowance = Convert.ToDouble(reader["Allowance"]);
                    oDMSDSR.TotalOthers= Convert.ToDouble(reader["Others"]);

                    oDMSDSR.MobileBill = Convert.ToDouble(reader["MobileBill"]);
                    oDMSDSR.Deduction = Convert.ToDouble(reader["Deduction"]);
                    oDMSDSR.CalculatedSalary = Convert.ToDouble(reader["CalculatedSlary"]);
                    oDMSDSR.Netpayable = Convert.ToDouble(reader["Netpayable"]);
                    oDMSDSR.Remarks =Convert.ToString(reader["Remarks"]);
                    oDMSDSR.Status =Convert.ToInt16(reader["Status"]);
                    oDMSDSR.DSRCode = Convert.ToInt16(reader["DSRCode"]);
                    oDMSDSR.DSRName = (string)reader["DSRName"];       
                    oDMSDSR.CustomerCode = (string)reader["CustomerCode"];                    
                    oDMSDSR.CustomerName = (string)reader["CustomerName"];
                    oDMSDSR.AreaName = (string)reader["AreaName"];                                            
                    oDMSDSR.Status =Convert.ToInt16(reader["Status"]);
                    InnerList.Add(oDMSDSR);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void PrintSalary(int nMonth, int nYear, int PrintType,string ReportType)
        {
 
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"select ROW_NUMBER() over (order by DSRCode)as SLNo,RegionID,RegionName,AreaID,AreaName,TerritoryID,
            Territoryname,CustomerCode,CustomerName,DistrictName, DSRCode,DSRName,Designation,JoiningDate,EmployeeType,BKashAccountNo,AccountType, 
            TownType,DailyTADA ,
            Q1.*,Basic ,StrikeRate
            from 
            ( 
            select Main.*,LWPDeduction,TABDeduction,DSR.OtherDeduction,Addition,ActualWD from
            (
            select * from t_DMSDSRSalary
            ) as Main
            left join 
            (
            Select DSRID,LWPDeduction,TABDeduction,Others as OtherDeduction,Addition ,SalaryMonth,(WorkingDay-LWP) as ActualWD from t_DMSDSRSalaryProcess 
            where ( Month(SalaryMonth)=" + nMonth + @" and YEAR(SalaryMonth)=" + nYear + @")
            ) as DSR on DSR.DSRID=Main.DSRID and( Main.Month=Month(DSR.SalaryMonth) and Main.Year=Year(DSR.SalaryMonth))

            where  Month=" + nMonth + @"  and Year= " + nYear + @"

            )as Q1 
            left outer join 
            (  

            Select SS.*,isnull(SSS.StrikeRate,0) as StrikeRate from
            (
            select DSRID,a.DSRCode,DSRName,Designation,EmployeeType,JoiningDate,BKashAccountNo,FixedSalary as Basic,  
            a.CustomerID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryID,Territoryname, RegionID,RegionName, TownType, AccountType,DistrictName,DailyTADA  
            from t_DMSDSRDetails a, v_CustomerDetails b 
            where a.CustomerID=b.CustomerID and a.IsCurrent=1 and b.IsActive=1
            ) as SS 
            Left outer join 
            (
            Select DSRCODE,StrikeRate from t_DMSStrikeRate where   month(SalesMonth)=" + nMonth + @" and year(SalesMonth)=" + nYear + @"
            ) as SSS on SS.DSRCode=SSS.DSRCode 

            )as Q2 on Q1.DSRID=Q2.DSRID ";
                 
            if (PrintType==1)
            {
            sSql = sSql + " where  IsHeldup=1 order by RegionID,AreaID,TerritoryID";
            }
            if (PrintType == 0)
            {
            sSql = sSql + " where  IsHeldup=0 order by RegionID,AreaID,TerritoryID";
            }                

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSDSR oDMSDSR = new DMSDSR();

                    oDMSDSR.SLNo = Convert.ToInt16(reader["SLNo"]);
                    oDMSDSR.RegionID = (int)reader["RegionID"];
                    oDMSDSR.RegionName = (string)reader["RegionName"];
                    oDMSDSR.AreaID = (int)reader["AreaID"];
                    oDMSDSR.AreaName = (string)reader["AreaName"];
                    oDMSDSR.TerritoryID = (int)reader["TerritoryID"];
                    oDMSDSR.TerritoryName = (string)reader["TerritoryName"];
                    oDMSDSR.CustomerCode = (string)reader["CustomerCode"];
                    oDMSDSR.CustomerName = (string)reader["CustomerName"];
                    oDMSDSR.DistrictName = (string)reader["DistrictName"];
                    oDMSDSR.DSRCode = Convert.ToInt16(reader["DSRCode"]);
                    oDMSDSR.DSRName = (string)reader["DSRName"];
                    oDMSDSR.Designation = (string)reader["Designation"];
                    oDMSDSR.JoiningDate = Convert.ToDateTime(reader["JoiningDate"]);
                    oDMSDSR.EmployeeType = (string)reader["EmployeeType"];
                    oDMSDSR.BkashAccountNo = (string)reader["BkashAccountNo"];
                    if (reader["TownType"] != DBNull.Value)
                    {
                        oDMSDSR.TownType = (string)reader["TownType"];
                    }
                    else
                    {
                        oDMSDSR.TownType = "";
                    }
                    if (reader["AccountType"] != DBNull.Value)
                    {
                        oDMSDSR.AccountType = (string)reader["AccountType"];
                    }
                    else
                    {
                        oDMSDSR.AccountType = "";
                    }


                    oDMSDSR.TranID = (int)reader["TranID"];
                    oDMSDSR.DSRID = (int)reader["DSRID"];
                    oDMSDSR.TranDate = Convert.ToDateTime(reader["TranDate"]);
                    oDMSDSR.Month = Convert.ToInt16(reader["Month"]);
                    oDMSDSR.Year = Convert.ToInt16(reader["Year"]);
                    oDMSDSR.PaymentMode = (string)reader["PaymentMode"];
                    oDMSDSR.PaymentType = (string)reader["PaymentType"];
                    oDMSDSR.Sales = Convert.ToDouble(reader["SalesTO"]);
                    oDMSDSR.Target = Convert.ToDouble(reader["TargetTO"]);
                    oDMSDSR.Ach = Convert.ToDouble(reader["Ach"]);
                    oDMSDSR.WorkingDay = (int)reader["WorkingDay"];
                   // oDMSDSR.WorkingDayActual = (int)reader["ActualWD"];
                    oDMSDSR.WorkingDayActual = (int)reader["WorkingDayActual"];
                    oDMSDSR.FixedSalary = Convert.ToDouble(reader["FixedSalary"]);


                    if (ReportType != "Basic")
                    {
                        oDMSDSR.VariableSalary = Convert.ToDouble(reader["VariableSalary"]);
                        oDMSDSR.TotalTADA = Convert.ToDouble(reader["TADA"]);
                        oDMSDSR.MobileBill = Convert.ToDouble(reader["MobileBill"]);
                        oDMSDSR.StrikeRate = Convert.ToInt16(reader["StrikeRate"]);
                        oDMSDSR.DailyTADA = Convert.ToDouble(reader["DailyTADA"]);
                    }
                    else
                    {
                        oDMSDSR.VariableSalary = 0;
                        oDMSDSR.TotalTADA = 0;
                        oDMSDSR.MobileBill = 0;
                        oDMSDSR.StrikeRate = 0;
                        oDMSDSR.DailyTADA = 0;
                    }
            

                    oDMSDSR.Allowance = Convert.ToDouble(reader["Allowance"]);
                    oDMSDSR.TotalOthers = Convert.ToDouble(reader["Others"]);
        
                    oDMSDSR.Deduction = Convert.ToDouble(reader["Deduction"]);
                    oDMSDSR.CalculatedSalary = Convert.ToDouble(reader["CalculatedSlary"]);
                    oDMSDSR.Netpayable = Convert.ToDouble(reader["Netpayable"]);
                    oDMSDSR.Remarks = Convert.ToString(reader["Remarks"]);
                    oDMSDSR.Status = Convert.ToInt16(reader["Status"]);
                   
                    oDMSDSR.Basic = Convert.ToDouble(reader["Basic"]);
                    oDMSDSR.LWPDeduction = Convert.ToDouble(reader["LWPDeduction"]);
                    oDMSDSR.TabDeduction = Convert.ToDouble(reader["TabDeduction"]);
                    oDMSDSR.Others = Convert.ToDouble(reader["OtherDeduction"]);
                    oDMSDSR.Addition = Convert.ToDouble(reader["Addition"]) + Convert.ToDouble(reader["Allowance"]);

                    //oDMSDSR.TADA = Convert.ToDouble(reader["TADA"]);
                    //oDMSDSR.Allowance = Convert.ToDouble(reader["Allowance"]);
                    //oDMSDSR.Others = Convert.ToDouble(reader["Others"]);     
                    InnerList.Add(oDMSDSR);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBYDSRName(int nCustomerId)
        {
            DMSDSR oDMSDSR;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_dmsdsr where distributorid= ? ";
            cmd.Parameters.AddWithValue("DistributorID", nCustomerId);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDMSDSR = new DMSDSR();
                    //DMSDSR oDMSDSR = new DMSDSR();
                    oDMSDSR.DSRID = (int)reader["DSRID"];
                    //if (reader["RouteName"] != DBNull.Value)
                    oDMSDSR.DSRName = (string)reader["DSRName"];
                    InnerList.Add(oDMSDSR);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByCustomerID(int nCustomerID)
        {
            DMSDSR oDMSDSR;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT  * FROM t_DMSDSRDetails WHERE CustomerID= ? ";
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDMSDSR = new DMSDSR();
                    oDMSDSR.DSRID = (int)reader["DSRID"];
                    oDMSDSR.DistributorID = (int)reader["CustomerID"];
                    oDMSDSR.DSRCode = (int)reader["DSRCode"];
                    oDMSDSR.DSRName = (string)reader["DSRName"];
                    oDMSDSR.DSRMobile = (string)reader["DSRMobile"];

                    InnerList.Add(oDMSDSR);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void SelectDMSDSRByCustomerID(int nCustomerID)
        {
            DMSDSR oDMSDSR;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT  * FROM t_DMSDSR WHERE DistributorID= ? ";
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDMSDSR = new DMSDSR();
                    oDMSDSR.DSRID = (int)reader["DSRID"];
                    oDMSDSR.DistributorID = (int)reader["DistributorID"];
                    oDMSDSR.DSRCode = (int)reader["DSRCode"];
                    oDMSDSR.DSRName = (string)reader["DSRName"];
                    oDMSDSR.DSRMobile = (string)reader["DSRMobile"];

                    InnerList.Add(oDMSDSR);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshDSRDetailsparam(int nDSRCode, string sDSRName, string sCustomerName)
        {
            InnerList.Clear();
            if(!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            {

                sSql = @" Select  AreaName,TerritoryName,CustomerName, a.*,isnull(shortName,'NA') as SName 
                        from t_DMSDSRDetails a,v_CustomerDetails b 
                       where a.CustomerID=b.Customerid "; 

            }

            if (nDSRCode != 0)
            {
                sSql = sSql + " AND DSRCode like '%" + nDSRCode + "%'";
            }

            if (sDSRName != "")
            {
                sSql = sSql + " AND DSRName like '%" + sDSRName + "%'";
            }

            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            }

            //if (nCustomerID != 0)
            //{
            //    sSql = sSql + " AND CustomerID like '%" + nCustomerID + "%'";
            //}

            //if (nIsCurrent != -1)
            //{
            //    sSql = sSql + " AND IsCurrent=" + nIsCurrent + "";
            //}

            sSql = sSql + " Order by AreaName,TerritoryName,CustomerName ";

            try
            {

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSDSR oDMSDSR = new DMSDSR();
                    oDMSDSR.TranID = (int)reader["TranID"];
                    oDMSDSR.DSRID = (int)reader["DSRID"];
                    oDMSDSR.CustomerID = (int)reader["CustomerID"];
                    oDMSDSR.DSRCode = Convert.ToInt32(reader["DSRCode"]);
                    oDMSDSR.DSRName = (string)reader["DSRName"];
                    oDMSDSR.ShortName = (string)reader["SName"];
                    oDMSDSR.DSRMobile = (string)reader["DSRMobile"];
                    oDMSDSR.Designation = (string)reader["Designation"];
                    oDMSDSR.EmployeeType = (string)reader["EmployeeType"];
                    oDMSDSR.PaymentMode = (string)reader["PaymentMode"];
                    oDMSDSR.PaymentType = (string)reader["PaymentType"];
                    oDMSDSR.IsHeldUp = Convert.ToInt32(reader["IsHeldUp"]);
                    oDMSDSR.JoiningDate = Convert.ToDateTime(reader["JoiningDate"]);
                    oDMSDSR.DOB = Convert.ToDateTime(reader["DateofBirth"]);

                    if (reader["ResignDate"] != DBNull.Value)
                    {
                        oDMSDSR.ResignDate = Convert.ToDateTime(reader["ResignDate"]);
                    }
                    else
                    {
                        oDMSDSR.ResignDate = DateTime.Today;
                    }

                    if (reader["TownType"] != DBNull.Value)
                    {
                        oDMSDSR.TownType = (string)reader["TownType"];
                    }
                    else
                    {
                        oDMSDSR.TownType = "";
                    }
                    if (reader["AccountType"] != DBNull.Value)
                    {
                        oDMSDSR.AccountType = (string)reader["AccountType"];
                    }
                    else
                    {
                        oDMSDSR.AccountType = "";
                    }
                    oDMSDSR.UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"]);
                    oDMSDSR.FixedSalary = Convert.ToDouble(reader["FixedSalary"]);
                   // oDMSDSR.VariableSalary = Convert.ToDouble(reader["VariableSalary"]);
                    if (reader["VariableSalary"] != DBNull.Value)
                    {
                        oDMSDSR.VariableSalary = Convert.ToDouble(reader["VariableSalary"]);
                    }
                    else
                    {
                        oDMSDSR.VariableSalary = 0;
                    }
                    oDMSDSR.DailyTADA = Convert.ToDouble(reader["DailyTADA"]);
                    oDMSDSR.DailySpcAllowance = Convert.ToDouble(reader["DailySpcAllowance"]);
                    oDMSDSR.OthersAllowance = Convert.ToDouble(reader["OthersAllowance"]);
                    oDMSDSR.MobileBill = Convert.ToDouble(reader["MobileBill"]);
                    oDMSDSR.BkashAccountNo = (string)reader["BkashAccountNo"];
                    oDMSDSR.DBBLAccNo = (string)reader["DBBLAccNo"];
                    oDMSDSR.DBBLMobNo = (string)reader["DBBLMobNo"];
                    oDMSDSR.IsCurrent = Convert.ToInt32(reader["IsCurrent"]);
                    oDMSDSR.Grade = (string)reader["Grade"];
                    oDMSDSR.Position = (string)reader["Position"];
                    oDMSDSR.AreaName = Convert.ToString(reader["AreaName"]);
                    oDMSDSR.TerritoryName = Convert.ToString(reader["TerritoryName"]);
                    oDMSDSR.CustomerName = Convert.ToString(reader["CustomerName"]);
                    InnerList.Add(oDMSDSR);
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



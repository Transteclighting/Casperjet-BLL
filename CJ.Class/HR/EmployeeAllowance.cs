// <summary>
// Compamy: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Jun 18, 2016
// Time : 02:02 PM
// Description: Class for HRPayrollEmployeeAllowance.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Class.HR
{
    public class EmployeeAllowance
    {
        private int _nID;
        private int _nEmployeeID;
        private int _nAllowanceID;
        private int _nCompanyID;
        private double _Amount;
        private int _nEffectiveYear;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
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
        // Get set property for AllowanceID
        // </summary>
        public int AllowanceID
        {
            get { return _nAllowanceID; }
            set { _nAllowanceID = value; }
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
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        // <summary>
        // Get set property for EffectiveYear
        // </summary>
        public int EffectiveYear
        {
            get { return _nEffectiveYear; }
            set { _nEffectiveYear = value; }
        }

        private double _BasicSalary;
        public double BasicSalary
        {
            get { return _BasicSalary; }
            set { _BasicSalary = value; }
        }
        private double _ConsolidateSalary;
        public double ConsolidateSalary
        {
            get { return _ConsolidateSalary; }
            set { _ConsolidateSalary = value; }
        }
        private double _HouseRent;
        public double HouseRent
        {
            get { return _HouseRent; }
            set { _HouseRent = value; }
        }
        private double _CarAllowance;
        public double CarAllowance
        {
            get { return _CarAllowance; }
            set { _CarAllowance = value; }
        }
        private double _Conveyance;
        public double Conveyance
        {
            get { return _Conveyance; }
            set { _Conveyance = value; }
        }
        private double _EntertainmentAllowance;
        public double EntertainmentAllowance
        {
            get { return _EntertainmentAllowance; }
            set { _EntertainmentAllowance = value; }
        }
        private double _FestivalBonus;
        public double FestivalBonus
        {
            get { return _FestivalBonus; }
            set { _FestivalBonus = value; }
        }
        private double _SpecialAllowance;
        public double SpecialAllowance
        {
            get { return _SpecialAllowance; }
            set { _SpecialAllowance = value; }
        }
        private double _LFA;
        public double LFA
        {
            get { return _LFA; }
            set { _LFA = value; }
        }
        private double _PF;
        public double PF
        {
            get { return _PF; }
            set { _PF = value; }
        }
        private double _PFLoan;
        public double PFLoan
        {
            get { return _PFLoan; }
            set { _PFLoan = value; }
        }
        private double _PFLoanPrincipal;
        public double PFLoanPrincipal
        {
            get { return _PFLoanPrincipal; }
            set { _PFLoanPrincipal = value; }
        }
        private double _PFLoanInterest;
        public double PFLoanInterest
        {
            get { return _PFLoanInterest; }
            set { _PFLoanInterest = value; }
        }
        private double _ArticleLoanAC;
        public double ArticleLoanAC
        {
            get { return _ArticleLoanAC; }
            set { _ArticleLoanAC = value; }
        }
        private double _ArticleLoanTV;
        public double ArticleLoanTV
        {
            get { return _ArticleLoanTV; }
            set { _ArticleLoanTV = value; }
        }
        private double _ArticleLoanRef;
        public double ArticleLoanRef
        {
            get { return _ArticleLoanRef; }
            set { _ArticleLoanRef = value; }
        }
        private double _EPSLoan;
        public double EPSLoan
        {
            get { return _EPSLoan; }
            set { _EPSLoan = value; }
        }
        private double _EmergencyLoan;
        public double EmergencyLoan
        {
            get { return _EmergencyLoan; }
            set { _EmergencyLoan = value; }
        }
        private double _CarLoan;
        public double CarLoan
        {
            get { return _CarLoan; }
            set { _CarLoan = value; }
        }
        private double _NonRotatingShift;
        public double NonRotatingShift
        {
            get { return _NonRotatingShift; }
            set { _NonRotatingShift = value; }
        }
        private double _AITSalary;
        public double AITSalary
        {
            get { return _AITSalary; }
            set { _AITSalary = value; }
        }
        private double _MobileBill;
        public double MobileBill
        {
            get { return _MobileBill; }
            set { _MobileBill = value; }
        }
        private double _AdvanceSalary;
        public double AdvanceSalary
        {
            get { return _AdvanceSalary; }
            set { _AdvanceSalary = value; }
        }
        private double _OtherDeduction;
        public double OtherDeduction
        {
            get { return _OtherDeduction; }
            set { _OtherDeduction = value; }
        }
        private double _MedicalAllowanceforStaff;
        public double MedicalAllowanceforStaff
        {
            get { return _MedicalAllowanceforStaff; }
            set { _MedicalAllowanceforStaff = value; }
        }
        private double _OverTime;
        public double OverTime
        {
            get { return _OverTime; }
            set { _OverTime = value; }
        }
        private double _Lunch;
        public double Lunch
        {
            get { return _Lunch; }
            set { _Lunch = value; }
        }
        private double _NightShiftAllowance;
        public double NightShiftAllowance
        {
            get { return _NightShiftAllowance; }
            set { _NightShiftAllowance = value; }
        }
        private double _ChildEducationAllowance;
        public double ChildEducationAllowance
        {
            get { return _ChildEducationAllowance; }
            set { _ChildEducationAllowance = value; }
        }
        private double _BuildingLoan;
        public double BuildingLoan
        {
            get { return _BuildingLoan; }
            set { _BuildingLoan = value; }
        }
        private double _BuildingLoanPrincipal;
        public double BuildingLoanPrincipal
        {
            get { return _BuildingLoanPrincipal; }
            set { _BuildingLoanPrincipal = value; }
        }
        private double _BuildingLoanInterest;
        public double BuildingLoanInterest
        {
            get { return _BuildingLoanInterest; }
            set { _BuildingLoanInterest = value; }
        }
        private double _HouseMaintenance;
        public double HouseMaintenance
        {
            get { return _HouseMaintenance; }
            set { _HouseMaintenance = value; }
        }
        private double _OtherScheme;
        public double OtherScheme
        {
            get { return _OtherScheme; }
            set { _OtherScheme = value; }
        }
        private double _UtilityExpense;
        public double UtilityExpense
        {
            get { return _UtilityExpense; }
            set { _UtilityExpense = value; }
        }
        private double _CanteenExpense;
        public double CanteenExpense
        {
            get { return _CanteenExpense; }
            set { _CanteenExpense = value; }
        }
        private double _OtherExpense;
        public double OtherExpense
        {
            get { return _OtherExpense; }
            set { _OtherExpense = value; }
        }
        private double _DriverExpense;
        public double DriverExpense
        {
            get { return _DriverExpense; }
            set { _DriverExpense = value; }
        }
        private double _ServentExpense;
        public double ServentExpense
        {
            get { return _ServentExpense; }
            set { _ServentExpense = value; }
        }
        private double _RotatingShift;
        public double RotatingShift
        {
            get { return _RotatingShift; }
            set { _RotatingShift = value; }
        }


        private string _sCode;
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value; }
        }
        private string _sName;
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }
        private int _nType;
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }
        private int _nSort;
        public int Sort
        {
            get { return _nSort; }
            set { _nSort = value; }
        }
        private int _nGroupID;
        public int GroupID
        {
            get { return _nGroupID; }
            set { _nGroupID = value; }
        }
        private string _sGroupName;
        public string GroupName
        {
            get { return _sGroupName; }
            set { _sGroupName = value; }
        }
        private string _sDesignation;
        public string Designation
        {
            get { return _sDesignation; }
            set { _sDesignation = value; }
        }
        private string _sJobLocation;
        public string JobLocation
        {
            get { return _sJobLocation; }
            set { _sJobLocation = value; }
        }
        private string _sCompanyName;
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value; }
        }
        private int _nDepartmentID;
        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }
        }
        private string _sDepartmentName;
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value; }
        }
        private int _nIsSet;
        public int IsSet
        {
            get { return _nIsSet; }
            set { _nIsSet = value; }
        }
        private int _nTMonth;
        public int TMonth
        {
            get { return _nTMonth; }
            set { _nTMonth = value; }
        }
        private int _nTYear;
        public int TYear
        {
            get { return _nTYear; }
            set { _nTYear = value; }
        }
        private double _Amount1;
        public double Amount1
        {
            get { return _Amount1; }
            set { _Amount1 = value; }
        }
        private double _Difference;
        public double Difference
        {
            get { return _Difference; }
            set { _Difference = value; }
        }
        private string _sDescription;
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }
        private int _nTotalEmpl;
        public int TotalEmpl
        {
            get { return _nTotalEmpl; }
            set { _nTotalEmpl = value; }
        }
        
        private double _NetPayableSupervisor;
        public double NetPayableSupervisor
        {
            get { return _NetPayableSupervisor; }
            set { _NetPayableSupervisor = value; }
        }
        private string _AmountInWord;
        public string AmountInWord
        {
            get { return _AmountInWord; }
            set { _AmountInWord = value; }
        }
        private string _sOverTimeHour;
        public string OverTimeHour
        {
            get { return _sOverTimeHour; }
            set { _sOverTimeHour = value; }
        }
        private string _sNotes;
        public string Notes
        {
            get { return _sNotes; }
            set { _sNotes = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRPayrollEmployeeAllowance";
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
                sSql = "INSERT INTO t_HRPayrollEmployeeAllowance (ID, EmployeeID, AllowanceID, CompanyID, Amount, EffectiveYear) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("AllowanceID", _nAllowanceID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("EffectiveYear", _nEffectiveYear);

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
                sSql = "UPDATE t_HRPayrollEmployeeAllowance SET EmployeeID = ?, AllowanceID = ?, CompanyID = ?, Amount = ?, EffectiveYear = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("AllowanceID", _nAllowanceID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("EffectiveYear", _nEffectiveYear);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete(int nCompanyID, int nEmployeeID, int nEffectiveYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_HRPayrollEmployeeAllowance WHERE CompanyID=? and EmployeeID=? and EffectiveYear = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyID", nCompanyID);
                cmd.Parameters.AddWithValue("EmployeeID", nEmployeeID);
                cmd.Parameters.AddWithValue("EffectiveYear", nEffectiveYear);

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
                cmd.CommandText = "SELECT * FROM t_HRPayrollEmployeeAllowance where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nAllowanceID = (int)reader["AllowanceID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nEffectiveYear = (int)reader["EffectiveYear"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public double GetAllowance(int nEmployeeID, int nAllowanceID, int nYear, int nCompanyID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Amount = 0;
            try
            {
                cmd.CommandText = " Select Amount from dbo.t_HRPayrollEmployeeAllowance Where EmployeeID=" + nEmployeeID + " and CompanyID = "+ nCompanyID + " " +
                                  " and AllowanceID = " + nAllowanceID + " and EffectiveYear=" + nYear + " ";
               
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
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Amount;
        }
       
        public int AllwoanceGroupItem(int nGroupID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int _Item = 0;
            try
            {
                cmd.CommandText = " Select Count(ID) as Count from dbo.t_HRAllowanceDeduction Where IsPayrollItem=1 and IsActive=1 and GroupID=" + nGroupID + " ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Count"] != DBNull.Value)
                    {
                        _Item = Convert.ToInt32(reader["Count"].ToString());
                    }
                    else
                    {
                        _Item = 0;
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Item;
        }
        
        public void Refresh(int nEmployeeID, int nConpanyID, int nYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " Select a.EmployeeID, GradeID, " +
                                   " Sum(Case When AllowanceID = 8 then Amount else 0 end) as BasicSalary, " +
                                   " Sum(Case When AllowanceID = 9 then Amount else 0 end) as ConsolidateSalary, " +
                                   " Sum(Case When AllowanceID = 10 then Amount else 0 end) as HouseRent, " +
                                   " Sum(Case When AllowanceID = 11 then Amount else 0 end) as CarAllowance, " +
                                   " Sum(Case When AllowanceID = 12 then Amount else 0 end) as Conveyance, " +
                                   " Sum(Case When AllowanceID = 13 then Amount else 0 end) as EntertainmentAllowance, " +
                                   " Sum(Case When AllowanceID = 14 then Amount else 0 end) as FestivalBonus, " +
                                   " Sum(Case When AllowanceID = 15 then Amount else 0 end) as SpecialAllowance, " +
                                   " Sum(Case When AllowanceID = 16 then Amount else 0 end) as LFA, " +
                                   " Sum(Case When AllowanceID = 17 then Amount else 0 end) as PF, " +
                                   " Sum(Case When AllowanceID = 18 then Amount else 0 end) as PFLoan, " +
                                   " Sum(Case When AllowanceID = 19 then Amount else 0 end) as ArticleLoanTV, " +
                                   " Sum(Case When AllowanceID = 20 then Amount else 0 end) as ArticleLoanRef, " +
                                   " Sum(Case When AllowanceID = 21 then Amount else 0 end) as ArticleLoanAC, " +
                                   " Sum(Case When AllowanceID = 22 then Amount else 0 end) as EPSLoan, " +
                                   " Sum(Case When AllowanceID = 23 then Amount else 0 end) as EmergencyLoan, " +
                                   " Sum(Case When AllowanceID = 24 then Amount else 0 end) as CarLoan, " +
                                   " Sum(Case When AllowanceID = 25 then Amount else 0 end) as NonRotatingShift, " +
                                   " Sum(Case When AllowanceID = 26 then Amount else 0 end) as AITSalary, " +
                                   " Sum(Case When AllowanceID = 27 then Amount else 0 end) as MobileBill, " +
                                   " Sum(Case When AllowanceID = 28 then Amount else 0 end) as AdvanceSalary, " +
                                   " Sum(Case When AllowanceID = 29 then Amount else 0 end) as OtherDeduction,  " +
                                   " Sum(Case When AllowanceID = 30 then Amount else 0 end) as MedicalAllowanceforStaff,  " +
                                   " Sum(Case When AllowanceID = 31 then Amount else 0 end) as OverTime,  " +
                                   " Sum(Case When AllowanceID = 32 then Amount else 0 end) as Lunch,  " +
                                   " Sum(Case When AllowanceID = 33 then Amount else 0 end) as NightShiftAllowance,  " +
                                   " Sum(Case When AllowanceID = 34 then Amount else 0 end) as ChildEducationAllowance, " +
                                   " Sum(Case When AllowanceID = 35 then Amount else 0 end) as BuildingLoan,  " +
                                   " Sum(Case When AllowanceID = 36 then Amount else 0 end) as HouseMaintenance,   " +
                                   " Sum(Case When AllowanceID = 37 then Amount else 0 end) as UtilityExpense,  " + 
                                   " Sum(Case When AllowanceID = 38 then Amount else 0 end) as CanteenExpense,  " + 
                                   " Sum(Case When AllowanceID = 39 then Amount else 0 end) as OtherExpense,  " + 
                                   " Sum(Case When AllowanceID = 40 then Amount else 0 end) as DriverExpense,  " + 
                                   " Sum(Case When AllowanceID = 41 then Amount else 0 end) as ServentExpense,  " + 
                                   " Sum(Case When AllowanceID = 42 then Amount else 0 end) as RotatingShift  " + 
                                   " from  dbo.t_HRPayrollEmployeeAllowance a, v_EmployeeDetails b  " +
                                   " Where a.EmployeeID = b.EmployeeID and a.EmployeeID=" + nEmployeeID + " and a.CompanyID=" + nConpanyID + " and EffectiveYear=" + nYear + " group by a.EmployeeID, GradeID ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _BasicSalary = (double)reader["BasicSalary"];
                    _ConsolidateSalary = (double)reader["ConsolidateSalary"];
                    _HouseRent = (double)reader["HouseRent"];
                    _CarAllowance = (double)reader["CarAllowance"];
                    _Conveyance = (double)reader["Conveyance"];
                    _EntertainmentAllowance = (double)reader["EntertainmentAllowance"];
                    _FestivalBonus = (double)reader["FestivalBonus"];
                    _SpecialAllowance = (double)reader["SpecialAllowance"];
                    _LFA = (double)reader["LFA"];
                    _PF = (double)reader["PF"];
                    _PFLoan = (double)reader["PFLoan"];
                    _ArticleLoanTV = (double)reader["ArticleLoanTV"];
                    _ArticleLoanRef = (double)reader["ArticleLoanRef"];
                    _ArticleLoanAC = (double)reader["ArticleLoanAC"];
                    _EPSLoan = (double)reader["EPSLoan"];
                    _EmergencyLoan = (double)reader["EmergencyLoan"];
                    _CarLoan = (double)reader["CarLoan"];
                    _NonRotatingShift = (double)reader["NonRotatingShift"];
                    _AITSalary = (double)reader["AITSalary"];
                    _MobileBill = (double)reader["MobileBill"];
                    _AdvanceSalary = (double)reader["AdvanceSalary"];
                    _OtherDeduction = (double)reader["OtherDeduction"];
                    _MedicalAllowanceforStaff = (double)reader["MedicalAllowanceforStaff"];
                    _OverTime = (double)reader["OverTime"];
                    _Lunch = (double)reader["Lunch"];
                    _NightShiftAllowance = (double)reader["NightShiftAllowance"];
                    _ChildEducationAllowance = (double)reader["ChildEducationAllowance"];
                    _BuildingLoan = (double)reader["BuildingLoan"];
                    _HouseMaintenance = (double)reader["HouseMaintenance"];
                    _UtilityExpense = (double)reader["UtilityExpense"];
                    _CanteenExpense = (double)reader["CanteenExpense"];
                    _OtherExpense = (double)reader["OtherExpense"];
                    _DriverExpense = (double)reader["DriverExpense"];
                    _ServentExpense = (double)reader["ServentExpense"];
                    _RotatingShift = (double)reader["RotatingShift"];
  
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckAllowance(int nEmployeeID, int nConpanyID, int nYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int _nCount = 0;
            try
            {
                cmd.CommandText = " select count (*) as Count from t_HRPayrollEmployeeAllowance Where EmployeeID=" + nEmployeeID + " and CompanyID=" + nConpanyID + " and EffectiveYear = " + nYear + " ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Count"] != DBNull.Value)
                    {
                        _nCount = Convert.ToInt32(reader["Count"].ToString());
                    }
                    else
                    {
                        _nCount = 0;
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (_nCount != 0)
                return true;
            else return false;
        }

        public double GetBasicSalaryPercentForConEmployee(double _Amount, int nCompanyID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Percent = 0;

            try
            {
                cmd.CommandText = " Select BasicSalaryPercent from dbo.t_HRConEmployeeBasicCalculation "+
                                  " Where " + _Amount + " between StartAmount and EndAmount and CompanyID=" + nCompanyID + " ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["BasicSalaryPercent"] != DBNull.Value)
                    {
                        _Percent = Convert.ToDouble(reader["BasicSalaryPercent"].ToString());
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Percent;
        }
    }
    public class EmployeeAllowances : CollectionBase
    {
        public EmployeeAllowance this[int i]
        {
            get { return (EmployeeAllowance)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(EmployeeAllowance oEmployeeAllowance)
        {
            InnerList.Add(oEmployeeAllowance);
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

        public void GetAllowance()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select ID, Code, Name, Type, Sort, GroupID from dbo.t_HRAllowanceDeduction Where IsPayrollItem=1 and IsActive=1 Order by GroupID, Sort ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeAllowance oHRPayrollEmployeeAllowance = new EmployeeAllowance();

                    oHRPayrollEmployeeAllowance.ID = (int)reader["ID"];
                    oHRPayrollEmployeeAllowance.Code = (string)reader["Code"];
                    oHRPayrollEmployeeAllowance.Name = (string)reader["Name"];
                    oHRPayrollEmployeeAllowance.Type = (int)reader["Type"];
                    oHRPayrollEmployeeAllowance.Sort = (int)reader["Sort"];
                    oHRPayrollEmployeeAllowance.GroupID = (int)reader["GroupID"];

                    InnerList.Add(oHRPayrollEmployeeAllowance);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDetail(int nCompanyID, int nEmployeeID, int nDepartmentID, int nIsSet, int nEffectiveYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select x.EmployeeID, EmployeeCode, EmployeeName, DesignationName, " +
                          "  CompanyID, CompanyCode, DepartmentID, DepartmentName, EffectiveYear, (IsNull(GrossSalary,0) - IsNull(DeductAmount,0)) as TakehomeSalary, IsSet from  " +
                          "  ( " +
                          "  Select a.EmployeeID, EmployeeCode, EmployeeName, DesignationName,  " +
                          "  a.CompanyID, CompanyCode, a.DepartmentID, DepartmentName,a.EffectiveYear, Sum(Amount) as GrossSalary, " +
                          "  CASE When Sum(Amount) > 0 then 1 else 0 end as IsSet  from  " +
                          "  ( " +
                          "  Select EmployeeID, EmployeeCode, EmployeeName, DesignationName,  " +
                          "  CompanyID, CompanyCode, DepartmentID, DepartmentName, " + nEffectiveYear + " as EffectiveYear  " +
                          "  from v_EmployeeDetails Where CompanyID="+ nCompanyID + " and IsPayrollEmployee =" + (int)Dictionary.YesOrNoStatus.YES + " and EMPStatus IN (" + (int)Dictionary.HREmployeeStatus.Contractual + "," + (int)Dictionary.HREmployeeStatus.Confirmed + ") " +
                          "  )a " +
                          "  Left Outer JOIN " +
                          "  (Select * from t_HRPayrollEmployeeAllowance Where CompanyID=" + nCompanyID + " and EffectiveYear = " + nEffectiveYear + " and AllowanceID Not IN (" + (int)Dictionary.HREmployeeAllowance.FestivalBonus + "," + (int)Dictionary.HREmployeeAllowance.LFA + ")) b  " +
                          " ON a.EmployeeID=b.EmployeeID " +
                          "  Group by a.EmployeeID, EmployeeCode, EmployeeName, DesignationName,  " +
                          "  a.CompanyID, CompanyCode, a.DepartmentID, DepartmentName,  a.EffectiveYear " +
                          "  ) x  " +
                          "  Left Outer JOIN " +
                          "  ( " +
                          "  Select EmployeeID, Sum(Amount) as DeductAmount from t_HRPayrollEmployeeAllowance  " +
                          "  Where CompanyID=" + nCompanyID + " and EffectiveYear = " + nEffectiveYear + " and AllowanceID IN (" + (int)Dictionary.HREmployeeAllowance.PF + "," + (int)Dictionary.HREmployeeAllowance.AITSalary + ") Group by EmployeeID  " +
                          "  ) C ON x.EmployeeID=C.EmployeeID Where 1=1 ";

            if (nCompanyID != 0)
            {
                sSql = sSql + " and CompanyID = " + nCompanyID + " ";
            }
            if (nEmployeeID != 0)
            {
                sSql = sSql + "and x.EmployeeID = " + nEmployeeID + " ";
            }
            if (nDepartmentID != 0)
            {
                sSql = sSql + "and DepartmentID = " + nDepartmentID + " ";
            }
            if (nIsSet != -1)
            {
                sSql = sSql + " and IsSet = " + nIsSet + " ";
            }
            //

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeAllowance oHRPayrollEmployeeAllowance = new EmployeeAllowance();

                    oHRPayrollEmployeeAllowance.EmployeeID = (int)reader["EmployeeID"];
                    oHRPayrollEmployeeAllowance.Code = (string)reader["EmployeeCode"];
                    oHRPayrollEmployeeAllowance.Name = (string)reader["EmployeeName"];
                    oHRPayrollEmployeeAllowance.Designation = (string)reader["DesignationName"];
                    oHRPayrollEmployeeAllowance.CompanyID = (int)reader["CompanyID"];
                    oHRPayrollEmployeeAllowance.CompanyName = (string)reader["CompanyCode"];
                    oHRPayrollEmployeeAllowance.DepartmentID = (int)reader["DepartmentID"];
                    oHRPayrollEmployeeAllowance.DepartmentName = (string)reader["DepartmentName"];
                    oHRPayrollEmployeeAllowance.EffectiveYear = (int)reader["EffectiveYear"];
                    if (reader["TakehomeSalary"] != DBNull.Value)
                    {
                        oHRPayrollEmployeeAllowance.Amount = (double)reader["TakehomeSalary"];
                    }
                    else
                    {
                        oHRPayrollEmployeeAllowance.Amount = 0;
                    }
                    oHRPayrollEmployeeAllowance.IsSet = (int)reader["IsSet"];

                    InnerList.Add(oHRPayrollEmployeeAllowance);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nEmployeeID, int nCompanyID, int nYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRPayrollEmployeeAllowance Where EmployeeID = " + nEmployeeID + " and CompanyID = " + nCompanyID + " and EffectiveYear = " + nYear + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeAllowance oHRPayrollEmployeeAllowance = new EmployeeAllowance();

                    oHRPayrollEmployeeAllowance.ID = (int)reader["ID"];
                    oHRPayrollEmployeeAllowance.EmployeeID = (int)reader["EmployeeID"];
                    oHRPayrollEmployeeAllowance.AllowanceID = (int)reader["AllowanceID"];
                    oHRPayrollEmployeeAllowance.CompanyID = (int)reader["CompanyID"];
                    oHRPayrollEmployeeAllowance.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oHRPayrollEmployeeAllowance.EffectiveYear = (int)reader["EffectiveYear"];

                    InnerList.Add(oHRPayrollEmployeeAllowance);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CompareReportData(int nEmployeeID, int nCompanyID, int nDepartmentID, int nMonth, int nYear, int nMonth1, int nYear1, int nType, int nStatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select a.ID, Code, Name, GroupID, IsNull(CEditedAmount,0) as CEditedAmount, IsNull(PEditedAmount,0) as PEditedAmount, (IsNull(CEditedAmount,0)-IsNull(PEditedAmount,0)) as Difference from dbo.t_HRAllowanceDeduction a " +
                          "  Left Outer JOIN " +
                          "  ( " +
                          "  Select ItemID, Sum(CEditedAmount) as CEditedAmount, Sum(PEditedAmount) as PEditedAmount from " +
                          "  ( " +
                          "  select ItemID, Sum(EditedAmount) as CEditedAmount, 0 as PEditedAmount from t_HRPayroll a, t_HRPayrollItem b, t_Employee c Where a.PayrollID=b.PayrollID and b.EmployeeID=c.EmployeeID ";
            if (nEmployeeID != 0)
            {
                sSql = sSql + " and b.EmployeeID = " + nEmployeeID + " ";
            }
            if (nCompanyID != 0)
            {
                sSql = sSql + " and a.CompanyID=" + nCompanyID + " ";
            }
            if (nDepartmentID != 0)
            {
                sSql = sSql + " and DepartmentID=" + nDepartmentID + " ";
            }
            if (nType != 0)
            {
                sSql = sSql + " and Type = " + nType + " ";
            }
            if (nStatus != 0)
            {
                sSql = sSql + " and Status =" + nStatus + " ";
            }

            sSql = sSql + "  and TMonth = " + nMonth + " and TYear = " + nYear + "   Group by ItemID " +
                          "  UNION ALL " +
                          "  select ItemID, 0 as CEditedAmount, Sum(EditedAmount) as PEditedAmount from t_HRPayroll a, t_HRPayrollItem b, t_Employee c Where a.PayrollID=b.PayrollID and b.EmployeeID=c.EmployeeID ";
            if (nEmployeeID != 0)
            {
                sSql = sSql + " and b.EmployeeID = " + nEmployeeID + " ";
            }
            if (nCompanyID != 0)
            {
                sSql = sSql + " and a.CompanyID=" + nCompanyID + " ";
            }
            if (nDepartmentID != 0)
            {
                sSql = sSql + " and DepartmentID=" + nDepartmentID + " ";
            }
            if (nType != 0)
            {
                sSql = sSql + " and Type = " + nType + " ";
            }
            if (nStatus != 0)
            {
                sSql = sSql + " and Status =" + nStatus + " ";
            }
            sSql = sSql + "  and TMonth = " + nMonth1 + " and TYear = " + nYear1 + " Group by ItemID " +
                          "  )a Group by ItemID )b ON b.ItemID=a.ID Where IsPayrollItem=" + (int)Dictionary.YesOrNoStatus.YES + " Order by GroupID, Sort ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeAllowance oHRPayrollEmployeeAllowance = new EmployeeAllowance();

                    oHRPayrollEmployeeAllowance.ID = (int)reader["ID"];
                    oHRPayrollEmployeeAllowance.Code = (string)reader["Code"];
                    oHRPayrollEmployeeAllowance.Name = (string)reader["Name"];
                    oHRPayrollEmployeeAllowance.GroupID = (int)reader["GroupID"];
                    oHRPayrollEmployeeAllowance.GroupName = Enum.GetName(typeof(Dictionary.AllowanceGroupType), oHRPayrollEmployeeAllowance.GroupID);
                    oHRPayrollEmployeeAllowance.Amount = Convert.ToDouble(reader["CEditedAmount"].ToString());
                    oHRPayrollEmployeeAllowance.Amount1 = Convert.ToDouble(reader["PEditedAmount"].ToString());
                    oHRPayrollEmployeeAllowance.Difference = Convert.ToDouble(reader["Difference"].ToString());

                    InnerList.Add(oHRPayrollEmployeeAllowance);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public double RefreshPayrollID(int nPayrollID, int nMonth, int nYear, int nCompnayID, bool IsSalary, bool IsOfficerCash, bool bDeptSort)
        {
            InnerList.Clear();
            double _Amount = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                sSQL = " Select a.*, IsNull(BuildingPrincipal,0) as BuildingPrincipal, IsNull(BuildingInterest,0) as BuildingInterest, " +
                                  " IsNull(PFPrincipal,0) as PFPrincipal, IsNull(PFInterest,0) as PFInterest, IsNull(OtherLoan,0) as OtherScheme from  " +
                                  " ( Select a.EmployeeID, EmployeeCode, EmployeeName, DesignationName, DepartmentName, c.CompanyName, TMonth, TYear,IsNull(b.Description,'') as Description, " +
                                  " Sum(Case When ItemID = 8 then EditedAmount else 0 end) as BasicSalary, " +
                                  " Sum(Case When ItemID = 9 then EditedAmount else 0 end) as ConsolidateSalary, " +
                                  " Sum(Case When ItemID = 10 then EditedAmount else 0 end) as HouseRent, " +
                                  " Sum(Case When ItemID = 11 then EditedAmount else 0 end) as CarAllowance, " +
                                  " Sum(Case When ItemID = 12 then EditedAmount else 0 end) as Conveyance, " +
                                  " Sum(Case When ItemID = 13 then EditedAmount else 0 end) as EntertainmentAllowance, " +
                                  " Sum(Case When ItemID = 14 then EditedAmount else 0 end) as FestivalBonus, " +
                                  " Sum(Case When ItemID = 15 then EditedAmount else 0 end) as SpecialAllowance, " +
                                  " Sum(Case When ItemID = 16 then EditedAmount else 0 end) as LFA, " +
                                  " Sum(Case When ItemID = 17 then EditedAmount else 0 end) as PF, " +
                                  " Sum(Case When ItemID = 18 then EditedAmount else 0 end) as PFLoan, " +
                                  " Sum(Case When ItemID = 19 then EditedAmount else 0 end) as ArticleLoanTV, " +
                                  " Sum(Case When ItemID = 20 then EditedAmount else 0 end) as ArticleLoanRef, " +
                                  " Sum(Case When ItemID = 21 then EditedAmount else 0 end) as ArticleLoanAC, " +
                                  " Sum(Case When ItemID = 22 then EditedAmount else 0 end) as EPSLoan, " +
                                  " Sum(Case When ItemID = 23 then EditedAmount else 0 end) as EmergencyLoan, " +
                                  " Sum(Case When ItemID = 24 then EditedAmount else 0 end) as CarLoan, " +
                                  " Sum(Case When ItemID = 25 then EditedAmount else 0 end) as NonRotatingShift, " +
                                  " Sum(Case When ItemID = 26 then EditedAmount else 0 end) as AITSalary, " +
                                  " Sum(Case When ItemID = 27 then EditedAmount else 0 end) as MobileBill, " +
                                  " Sum(Case When ItemID = 28 then EditedAmount else 0 end) as AdvanceSalary, " +
                                  " Sum(Case When ItemID = 29 then EditedAmount else 0 end) as OtherDeduction,  " +
                                  " Sum(Case When ItemID = 30 then EditedAmount else 0 end) as MedicalAllowanceforStaff,  " +
                                  " Sum(Case When ItemID = 31 then EditedAmount else 0 end) as OverTime,  " +
                                  " Sum(Case When ItemID = 32 then EditedAmount else 0 end) as Lunch,  " +
                                  " Sum(Case When ItemID = 33 then EditedAmount else 0 end) as NightShiftAllowance,  " +
                                  " Sum(Case When ItemID = 34 then EditedAmount else 0 end) as ChildEducationAllowance, " +
                                  " Sum(Case When ItemID = 35 then EditedAmount else 0 end) as BuildingLoan,  " +
                                  " Sum(Case When ItemID = 36 then EditedAmount else 0 end) as HouseMaintenance,   " +
                                  " Sum(Case When ItemID = 37 then EditedAmount else 0 end) as UtilityExpense,  " +
                                  " Sum(Case When ItemID = 38 then EditedAmount else 0 end) as CanteenExpense,  " +
                                  " Sum(Case When ItemID = 39 then EditedAmount else 0 end) as OtherExpense,  " +
                                  " Sum(Case When ItemID = 40 then EditedAmount else 0 end) as DriverExpense,  " +
                                  " Sum(Case When ItemID = 41 then EditedAmount else 0 end) as ServentExpense,  " +
                                  " Sum(Case When ItemID = 42 then EditedAmount else 0 end) as RotatingShift  " +
                                  " from  dbo.t_HRPayrollItem a, t_HRPayroll b, t_Company c, v_EmployeeDetails d Where a.PayrollID=b.PayrollID  " +
                                  " and b.CompanyID = c.CompanyID and a.EmployeeID=d.EmployeeID and a.PayrollID=" + nPayrollID + " " +
                                  " group by a.EmployeeID, EmployeeCode, EmployeeName, DesignationName, DepartmentName, c.CompanyName, TMonth, TYear, b.Description)a Left Outer JOIN " +
                                  " ( " +
                                  "  Select EmployeeID,  Sum(Case When LoanTypeID = 2 then PrincipalPayable else 0 end) as BuildingPrincipal,  " +
                                  "  Sum(Case When LoanTypeID = 2 then InterestPayable else 0 end) as BuildingInterest,  " +
                                  "  Sum(Case When LoanTypeID = 5 then PrincipalPayable else 0 end) as PFPrincipal,  " +
                                  "  Sum(Case When LoanTypeID = 5 then InterestPayable else 0 end) as PFInterest,  " +
                                  " Sum(Case When LoanTypeID > 5 then TotalPayable else 0 end) as OtherLoan from t_HRLoan a, t_HRLoanDetail b  " +
                                  "  Where a.LoanID=b.LoanID  and Month(PaymentDate) = " + nMonth + " and Year (PaymentDate) = " + nYear + " and IsEarlyClose= 0 " +
                                  "  and CompanyID =" + nCompnayID + " group by EmployeeID " +
                                  "  ) b " +
                                  "  ON a.EmployeeID = b.EmployeeID ";
                if (IsOfficerCash)
                {
                    sSQL = sSQL + " Where HouseMaintenance+UtilityExpense+Lunch+DriverExpense+ServentExpense+CarAllowance <> 0 ";
                    if (bDeptSort)
                    {
                        sSQL = sSQL + " Order by DepartmentName, EmployeeCode";
                    }
                    else
                    {
                        sSQL = sSQL + " Order by EmployeeCode";
                    }
                }
                else
                {
                    if (bDeptSort)
                    {
                        sSQL = sSQL + " Order by DepartmentName, EmployeeCode";
                    }
                    else
                    {
                        sSQL = sSQL + " Order by EmployeeCode";
                    }
                }
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeAllowance oHRPayrollAllow = new EmployeeAllowance();

                    oHRPayrollAllow.EmployeeID = (int)reader["EmployeeID"];
                    
                    Employee oEmployee = new Employee();
                    oEmployee.GetEmpJoblocation(oHRPayrollAllow.EmployeeID);
                    oHRPayrollAllow.JobLocation = oEmployee.JoblocationName;
                    oHRPayrollAllow.Code = (string)reader["EmployeeCode"];
                    oHRPayrollAllow.Name = (string)reader["EmployeeName"];
                    oHRPayrollAllow.Designation = (string)reader["DesignationName"];
                    oHRPayrollAllow.DepartmentName = (string)reader["DepartmentName"];
                    oHRPayrollAllow.CompanyName = (string)reader["CompanyName"];
                    oHRPayrollAllow.TMonth = (int)reader["TMonth"];
                    oHRPayrollAllow.TYear = (int)reader["TYear"];
                    oHRPayrollAllow.Description = (string)reader["Description"];
                    oHRPayrollAllow.BasicSalary = (double)reader["BasicSalary"];
                    oHRPayrollAllow.ConsolidateSalary = (double)reader["ConsolidateSalary"];
                    oHRPayrollAllow.HouseRent = (double)reader["HouseRent"];
                    oHRPayrollAllow.CarAllowance = (double)reader["CarAllowance"];
                    oHRPayrollAllow.Conveyance = (double)reader["Conveyance"];
                    oHRPayrollAllow.EntertainmentAllowance = (double)reader["EntertainmentAllowance"];
                    oHRPayrollAllow.FestivalBonus = (double)reader["FestivalBonus"];
                    oHRPayrollAllow.SpecialAllowance = (double)reader["SpecialAllowance"];
                    oHRPayrollAllow.LFA = (double)reader["LFA"];
                    oHRPayrollAllow.PF = (double)reader["PF"];
                    oHRPayrollAllow.PFLoan = (double)reader["PFLoan"];
                    if (IsSalary)
                    {
                        oHRPayrollAllow.PFLoanPrincipal = (double)reader["PFPrincipal"];
                        oHRPayrollAllow.PFLoanInterest = (double)reader["PFInterest"];
                        oHRPayrollAllow.BuildingLoanPrincipal = (double)reader["BuildingPrincipal"];
                        oHRPayrollAllow.BuildingLoanInterest = (double)reader["BuildingInterest"];
                    }
                    else
                    {
                        oHRPayrollAllow.PFLoanPrincipal = 0;
                        oHRPayrollAllow.PFLoanInterest = 0;
                        oHRPayrollAllow.BuildingLoanPrincipal = 0;
                        oHRPayrollAllow.BuildingLoanInterest = 0;
                    }
                    oHRPayrollAllow.ArticleLoanTV = (double)reader["ArticleLoanTV"];
                    oHRPayrollAllow.ArticleLoanRef = (double)reader["ArticleLoanRef"];
                    oHRPayrollAllow.ArticleLoanAC = (double)reader["ArticleLoanAC"];
                    oHRPayrollAllow.EPSLoan = (double)reader["EPSLoan"];
                    oHRPayrollAllow.EmergencyLoan = (double)reader["EmergencyLoan"];
                    oHRPayrollAllow.CarLoan = (double)reader["CarLoan"];
                    oHRPayrollAllow.NonRotatingShift = (double)reader["NonRotatingShift"];
                    oHRPayrollAllow.AITSalary = (double)reader["AITSalary"];
                    oHRPayrollAllow.MobileBill = (double)reader["MobileBill"];
                    oHRPayrollAllow.AdvanceSalary = (double)reader["AdvanceSalary"];
                    oHRPayrollAllow.OtherDeduction = (double)reader["OtherDeduction"];
                    oHRPayrollAllow.MedicalAllowanceforStaff = (double)reader["MedicalAllowanceforStaff"];
                    oHRPayrollAllow.OverTime = (double)reader["OverTime"];
                    oHRPayrollAllow.Lunch = (double)reader["Lunch"];
                    oHRPayrollAllow.NightShiftAllowance = (double)reader["NightShiftAllowance"];
                    oHRPayrollAllow.ChildEducationAllowance = (double)reader["ChildEducationAllowance"];
                    oHRPayrollAllow.BuildingLoan = (double)reader["BuildingLoan"];
                    oHRPayrollAllow.OtherScheme = (double)reader["OtherScheme"];
                    oHRPayrollAllow.HouseMaintenance = (double)reader["HouseMaintenance"];
                    oHRPayrollAllow.UtilityExpense = (double)reader["UtilityExpense"];
                    oHRPayrollAllow.CanteenExpense = (double)reader["CanteenExpense"];
                    oHRPayrollAllow.OtherExpense = (double)reader["OtherExpense"];
                    oHRPayrollAllow.DriverExpense = (double)reader["DriverExpense"];
                    oHRPayrollAllow.ServentExpense = (double)reader["ServentExpense"];
                    oHRPayrollAllow.RotatingShift = (double)reader["RotatingShift"];

                    HROverTime _oOverTime = new HROverTime();
                    int nMinute = _oOverTime.GetOverTime(oHRPayrollAllow.TMonth, oHRPayrollAllow.TYear, oHRPayrollAllow.EmployeeID);
                    double _Hour = _oOverTime.GetHour(nMinute);
                    string x = _Hour.ToString("0.00");
                    x = x.Replace(".", " : ");
                    if (_Hour != 0)
                    {
                        oHRPayrollAllow.OverTimeHour = "[hh:mm - " + x + "]";
                    }
                    else
                    {
                        oHRPayrollAllow.OverTimeHour = "";
                    }
                    HRPayrollAddDeduct _oAddDeduct = new HRPayrollAddDeduct();
                    oHRPayrollAllow.Notes = _oAddDeduct.GetNotes(oHRPayrollAllow.TMonth, oHRPayrollAllow.TYear, oHRPayrollAllow.EmployeeID, nCompnayID);

                    oHRPayrollAllow.NetPayableSupervisor = (oHRPayrollAllow.BasicSalary + oHRPayrollAllow.ConsolidateSalary + oHRPayrollAllow.HouseRent + oHRPayrollAllow.NightShiftAllowance + oHRPayrollAllow.Conveyance + oHRPayrollAllow.EntertainmentAllowance + oHRPayrollAllow.SpecialAllowance + oHRPayrollAllow.RotatingShift + oHRPayrollAllow.NonRotatingShift + oHRPayrollAllow.OverTime + oHRPayrollAllow.ChildEducationAllowance + oHRPayrollAllow.LFA + oHRPayrollAllow.MedicalAllowanceforStaff + oHRPayrollAllow.FestivalBonus + oHRPayrollAllow.Lunch + oHRPayrollAllow.OtherExpense) - (oHRPayrollAllow.PF + oHRPayrollAllow.PFLoanPrincipal + oHRPayrollAllow.PFLoanInterest + oHRPayrollAllow.ArticleLoanTV + oHRPayrollAllow.ArticleLoanRef + oHRPayrollAllow.ArticleLoanAC + oHRPayrollAllow.EPSLoan + oHRPayrollAllow.EmergencyLoan + oHRPayrollAllow.BuildingLoanPrincipal + oHRPayrollAllow.BuildingLoanInterest + oHRPayrollAllow.AITSalary + oHRPayrollAllow.MobileBill + oHRPayrollAllow.AdvanceSalary + oHRPayrollAllow.OtherDeduction);
                    TELLib _oTELLib = new TELLib();
                    oHRPayrollAllow.AmountInWord = _oTELLib.TakaWords(oHRPayrollAllow.NetPayableSupervisor);
                    _Amount = _Amount + oHRPayrollAllow.NetPayableSupervisor;

                    InnerList.Add(oHRPayrollAllow);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _Amount;
        }

        public double RefreshPayrollIDFactory(int nPayrollID, int nMonth, int nYear, int nCompnayID, bool IsSalary, bool IsOfficerCash, bool bDeptSort)
        {
            InnerList.Clear();
            double _Amount = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                sSQL = " Select a.*, IsNull(BuildingPrincipal,0) as BuildingPrincipal, IsNull(BuildingInterest,0) as BuildingInterest, " +
                                  " IsNull(PFPrincipal,0) as PFPrincipal, IsNull(PFInterest,0) as PFInterest, IsNull(OtherLoan,0) as OtherScheme from  " +
                                  " ( Select a.EmployeeID, EmployeeCode, EmployeeName, DesignationName, DepartmentName, c.CompanyName, TMonth, TYear,IsNull(b.Description,'') as Description, " +
                                  " Sum(Case When ItemID = 8 then EditedAmount else 0 end) as BasicSalary, " +
                                  " Sum(Case When ItemID = 9 then EditedAmount else 0 end) as ConsolidateSalary, " +
                                  " Sum(Case When ItemID = 10 then EditedAmount else 0 end) as HouseRent, " +
                                  " Sum(Case When ItemID = 11 then EditedAmount else 0 end) as CarAllowance, " +
                                  " Sum(Case When ItemID = 12 then EditedAmount else 0 end) as Conveyance, " +
                                  " Sum(Case When ItemID = 13 then EditedAmount else 0 end) as EntertainmentAllowance, " +
                                  " Sum(Case When ItemID = 14 then EditedAmount else 0 end) as FestivalBonus, " +
                                  " Sum(Case When ItemID = 15 then EditedAmount else 0 end) as SpecialAllowance, " +
                                  " Sum(Case When ItemID = 16 then EditedAmount else 0 end) as LFA, " +
                                  " Sum(Case When ItemID = 17 then EditedAmount else 0 end) as PF, " +
                                  " Sum(Case When ItemID = 18 then EditedAmount else 0 end) as PFLoan, " +
                                  " Sum(Case When ItemID = 19 then EditedAmount else 0 end) as ArticleLoanTV, " +
                                  " Sum(Case When ItemID = 20 then EditedAmount else 0 end) as ArticleLoanRef, " +
                                  " Sum(Case When ItemID = 21 then EditedAmount else 0 end) as ArticleLoanAC, " +
                                  " Sum(Case When ItemID = 22 then EditedAmount else 0 end) as EPSLoan, " +
                                  " Sum(Case When ItemID = 23 then EditedAmount else 0 end) as EmergencyLoan, " +
                                  " Sum(Case When ItemID = 24 then EditedAmount else 0 end) as CarLoan, " +
                                  " Sum(Case When ItemID = 25 then EditedAmount else 0 end) as NonRotatingShift, " +
                                  " Sum(Case When ItemID = 26 then EditedAmount else 0 end) as AITSalary, " +
                                  " Sum(Case When ItemID = 27 then EditedAmount else 0 end) as MobileBill, " +
                                  " Sum(Case When ItemID = 28 then EditedAmount else 0 end) as AdvanceSalary, " +
                                  " Sum(Case When ItemID = 29 then EditedAmount else 0 end) as OtherDeduction,  " +
                                  " Sum(Case When ItemID = 30 then EditedAmount else 0 end) as MedicalAllowanceforStaff,  " +
                                  " Sum(Case When ItemID = 31 then EditedAmount else 0 end) as OverTime,  " +
                                  " Sum(Case When ItemID = 32 then EditedAmount else 0 end) as Lunch,  " +
                                  " Sum(Case When ItemID = 33 then EditedAmount else 0 end) as NightShiftAllowance,  " +
                                  " Sum(Case When ItemID = 34 then EditedAmount else 0 end) as ChildEducationAllowance, " +
                                  " Sum(Case When ItemID = 35 then EditedAmount else 0 end) as BuildingLoan,  " +
                                  " Sum(Case When ItemID = 36 then EditedAmount else 0 end) as HouseMaintenance,   " +
                                  " Sum(Case When ItemID = 37 then EditedAmount else 0 end) as UtilityExpense,  " +
                                  " Sum(Case When ItemID = 38 then EditedAmount else 0 end) as CanteenExpense,  " +
                                  " Sum(Case When ItemID = 39 then EditedAmount else 0 end) as OtherExpense,  " +
                                  " Sum(Case When ItemID = 40 then EditedAmount else 0 end) as DriverExpense,  " +
                                  " Sum(Case When ItemID = 41 then EditedAmount else 0 end) as ServentExpense,  " +
                                  " Sum(Case When ItemID = 42 then EditedAmount else 0 end) as RotatingShift  " +
                                  " from  dbo.t_HRPayrollItem a, t_HRPayroll b, t_Company c, v_EmployeeDetails d Where a.PayrollID=b.PayrollID  " +
                                  " and b.CompanyID = c.CompanyID and a.EmployeeID=d.EmployeeID and a.PayrollID=" + nPayrollID + " " +
                                  " group by a.EmployeeID, EmployeeCode, EmployeeName, DesignationName, DepartmentName, c.CompanyName, TMonth, TYear, b.Description)a Left Outer JOIN " +
                                  " ( " +
                                  "  Select EmployeeID,  Sum(Case When LoanTypeID = 2 then PrincipalPayable else 0 end) as BuildingPrincipal,  " +
                                  "  Sum(Case When LoanTypeID = 2 then InterestPayable else 0 end) as BuildingInterest,  " +
                                  "  Sum(Case When LoanTypeID = 5 then PrincipalPayable else 0 end) as PFPrincipal,  " +
                                  "  Sum(Case When LoanTypeID = 5 then InterestPayable else 0 end) as PFInterest,  " +
                                  " Sum(Case When LoanTypeID > 5 then TotalPayable else 0 end) as OtherLoan from t_HRLoan a, t_HRLoanDetail b  " +
                                  "  Where a.LoanID=b.LoanID  and Month(PaymentDate) = " + nMonth + " and Year (PaymentDate) = " + nYear + " and IsEarlyClose= 0 " +
                                  "  and CompanyID =" + nCompnayID + " group by EmployeeID " +
                                  "  ) b " +
                                  "  ON a.EmployeeID = b.EmployeeID ";
                if (IsOfficerCash)
                {
                    sSQL = sSQL + " Where HouseMaintenance+UtilityExpense+Lunch+DriverExpense+ServentExpense <> 0 ";
                    if (bDeptSort)
                    {
                        sSQL = sSQL + " Order by DepartmentName, EmployeeCode";
                    }
                    else
                    {
                        sSQL = sSQL + " Order by EmployeeCode";
                    }
                }
                else
                {
                    if (bDeptSort)
                    {
                        sSQL = sSQL + " Order by DepartmentName, EmployeeCode";
                    }
                    else
                    {
                        sSQL = sSQL + " Order by EmployeeCode";
                    }
                }
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeAllowance oHRPayrollAllow = new EmployeeAllowance();

                    oHRPayrollAllow.EmployeeID = (int)reader["EmployeeID"];

                    Employee oEmployee = new Employee();
                    oEmployee.GetEmpJoblocation(oHRPayrollAllow.EmployeeID);
                    oHRPayrollAllow.JobLocation = oEmployee.JoblocationName;
                    oHRPayrollAllow.Code = (string)reader["EmployeeCode"];
                    oHRPayrollAllow.Name = (string)reader["EmployeeName"];
                    oHRPayrollAllow.Designation = (string)reader["DesignationName"];
                    oHRPayrollAllow.DepartmentName = (string)reader["DepartmentName"];
                    oHRPayrollAllow.CompanyName = (string)reader["CompanyName"];
                    oHRPayrollAllow.TMonth = (int)reader["TMonth"];
                    oHRPayrollAllow.TYear = (int)reader["TYear"];
                    oHRPayrollAllow.Description = (string)reader["Description"];
                    oHRPayrollAllow.BasicSalary = (double)reader["BasicSalary"];
                    oHRPayrollAllow.ConsolidateSalary = (double)reader["ConsolidateSalary"];
                    oHRPayrollAllow.HouseRent = (double)reader["HouseRent"];
                    oHRPayrollAllow.CarAllowance = (double)reader["CarAllowance"];
                    oHRPayrollAllow.Conveyance = (double)reader["Conveyance"];
                    oHRPayrollAllow.EntertainmentAllowance = (double)reader["EntertainmentAllowance"];
                    oHRPayrollAllow.FestivalBonus = (double)reader["FestivalBonus"];
                    oHRPayrollAllow.SpecialAllowance = (double)reader["SpecialAllowance"];
                    oHRPayrollAllow.LFA = (double)reader["LFA"];
                    oHRPayrollAllow.PF = (double)reader["PF"];
                    oHRPayrollAllow.PFLoan = (double)reader["PFLoan"];
                    if (IsSalary)
                    {
                        oHRPayrollAllow.PFLoanPrincipal = (double)reader["PFPrincipal"];
                        oHRPayrollAllow.PFLoanInterest = (double)reader["PFInterest"];
                        oHRPayrollAllow.BuildingLoanPrincipal = (double)reader["BuildingPrincipal"];
                        oHRPayrollAllow.BuildingLoanInterest = (double)reader["BuildingInterest"];
                    }
                    else
                    {
                        oHRPayrollAllow.PFLoanPrincipal = 0;
                        oHRPayrollAllow.PFLoanInterest = 0;
                        oHRPayrollAllow.BuildingLoanPrincipal = 0;
                        oHRPayrollAllow.BuildingLoanInterest = 0;
                    }
                    oHRPayrollAllow.ArticleLoanTV = (double)reader["ArticleLoanTV"];
                    oHRPayrollAllow.ArticleLoanRef = (double)reader["ArticleLoanRef"];
                    oHRPayrollAllow.ArticleLoanAC = (double)reader["ArticleLoanAC"];
                    oHRPayrollAllow.EPSLoan = (double)reader["EPSLoan"];
                    oHRPayrollAllow.EmergencyLoan = (double)reader["EmergencyLoan"];
                    oHRPayrollAllow.CarLoan = (double)reader["CarLoan"];
                    oHRPayrollAllow.NonRotatingShift = (double)reader["NonRotatingShift"];
                    oHRPayrollAllow.AITSalary = (double)reader["AITSalary"];
                    oHRPayrollAllow.MobileBill = (double)reader["MobileBill"];
                    oHRPayrollAllow.AdvanceSalary = (double)reader["AdvanceSalary"];
                    oHRPayrollAllow.MedicalAllowanceforStaff = (double)reader["MedicalAllowanceforStaff"];
                    oHRPayrollAllow.OverTime = (double)reader["OverTime"];
                    oHRPayrollAllow.Lunch = (double)reader["Lunch"];
                    oHRPayrollAllow.NightShiftAllowance = (double)reader["NightShiftAllowance"];
                    oHRPayrollAllow.ChildEducationAllowance = (double)reader["ChildEducationAllowance"];
                    oHRPayrollAllow.BuildingLoan = (double)reader["BuildingLoan"];
                    oHRPayrollAllow.OtherScheme = (double)reader["OtherScheme"];
                    oHRPayrollAllow.HouseMaintenance = (double)reader["HouseMaintenance"];
                    oHRPayrollAllow.UtilityExpense = (double)reader["UtilityExpense"];
                    oHRPayrollAllow.CanteenExpense = (double)reader["CanteenExpense"];
                    oHRPayrollAllow.DriverExpense = (double)reader["DriverExpense"];
                    oHRPayrollAllow.ServentExpense = (double)reader["ServentExpense"];
                    oHRPayrollAllow.RotatingShift = (double)reader["RotatingShift"];
                    //oHRPayrollAllow.Amount1 = oHRPayrollAllow.MobileBill + oHRPayrollAllow.PF;
                    oHRPayrollAllow.OtherExpense = (double)reader["OtherExpense"]+ (double)reader["NightShiftAllowance"]+ (double)reader["EntertainmentAllowance"]+ (double)reader["SpecialAllowance"]+ (double)reader["NonRotatingShift"]+ (double)reader["RotatingShift"]+ (double)reader["ChildEducationAllowance"]+ (double)reader["LFA"]+ (double)reader["FestivalBonus"];
                    oHRPayrollAllow.OtherDeduction = (double)reader["OtherDeduction"]+ (double)reader["PF"] + (double)reader["PFLoan"]+ (double)reader["PFInterest"]+ (double)reader["ArticleLoanRef"]+ (double)reader["ArticleLoanAC"]+ (double)reader["ArticleLoanTV"]+ (double)reader["EPSLoan"]+ (double)reader["EmergencyLoan"]+ (double)reader["BuildingLoan"]+ (double)reader["BuildingInterest"]+ (double)reader["AITSalary"]+ (double)reader["MobileBill"]+ (double)reader["AdvanceSalary"];

                    HROverTime _oOverTime = new HROverTime();
                    int nMinute = _oOverTime.GetOverTime(oHRPayrollAllow.TMonth, oHRPayrollAllow.TYear, oHRPayrollAllow.EmployeeID);
                    double _Hour = _oOverTime.GetHour(nMinute);
                    string x = _Hour.ToString("0.00");
                    x = x.Replace(".", " : ");
                    if (_Hour != 0)
                    {
                        oHRPayrollAllow.OverTimeHour = "" + x + "";
                    }
                    else
                    {
                        oHRPayrollAllow.OverTimeHour = "";
                    }
                    HRPayrollAddDeduct _oAddDeduct = new HRPayrollAddDeduct();
                    oHRPayrollAllow.Notes = _oAddDeduct.GetNotes(oHRPayrollAllow.TMonth, oHRPayrollAllow.TYear, oHRPayrollAllow.EmployeeID, nCompnayID);

                    oHRPayrollAllow.NetPayableSupervisor = (oHRPayrollAllow.BasicSalary + oHRPayrollAllow.ConsolidateSalary + oHRPayrollAllow.HouseRent + oHRPayrollAllow.NightShiftAllowance + oHRPayrollAllow.Conveyance + oHRPayrollAllow.EntertainmentAllowance + oHRPayrollAllow.SpecialAllowance + oHRPayrollAllow.RotatingShift + oHRPayrollAllow.NonRotatingShift + oHRPayrollAllow.OverTime + oHRPayrollAllow.ChildEducationAllowance + oHRPayrollAllow.LFA + oHRPayrollAllow.MedicalAllowanceforStaff + oHRPayrollAllow.FestivalBonus + oHRPayrollAllow.Lunch + oHRPayrollAllow.OtherExpense) - (oHRPayrollAllow.PF + oHRPayrollAllow.PFLoanPrincipal + oHRPayrollAllow.PFLoanInterest + oHRPayrollAllow.ArticleLoanTV + oHRPayrollAllow.ArticleLoanRef + oHRPayrollAllow.ArticleLoanAC + oHRPayrollAllow.EPSLoan + oHRPayrollAllow.EmergencyLoan + oHRPayrollAllow.BuildingLoanPrincipal + oHRPayrollAllow.BuildingLoanInterest + oHRPayrollAllow.AITSalary + oHRPayrollAllow.MobileBill + oHRPayrollAllow.AdvanceSalary + oHRPayrollAllow.OtherDeduction);
                    TELLib _oTELLib = new TELLib();
                    oHRPayrollAllow.AmountInWord = _oTELLib.TakaWords(oHRPayrollAllow.NetPayableSupervisor);
                    _Amount = _Amount + oHRPayrollAllow.NetPayableSupervisor;

                    InnerList.Add(oHRPayrollAllow);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _Amount;
        }
        public void RefreshPayrollStaffTopSheet(int nMonth, int nYear, int nCompnayID, int nPayrollSettings)
        {
            InnerList.Clear();
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                sSQL = " Select PayrollID,CompanyName,	Description, Count(*) as Empltotal,	Sum(BasicSalary) as BasicSalary,	Sum(ConsolidateSalary) as ConsolidateSalary, " +
                       " Sum(HouseRent) as HouseRent,	Sum(CarAllowance) as CarAllowance,	Sum(Conveyance) as Conveyance,	 " +
                       " Sum(EntertainmentAllowance) as EntertainmentAllowance,	Sum(FestivalBonus) as FestivalBonus,	Sum(SpecialAllowance) as SpecialAllowance,	 " +
                       " Sum(LFA) as LFA,	Sum(PF) as PF,	Sum(PFLoan) as PFLoan,	Sum(ArticleLoanTV) as ArticleLoanTV,	Sum(ArticleLoanRef) as ArticleLoanRef,	Sum(ArticleLoanAC) as ArticleLoanAC, " +
                       " Sum(EPSLoan) as EPSLoan,	Sum(EmergencyLoan) as EmergencyLoan,	Sum(CarLoan) as CarLoan,	Sum(NonRotatingShift) as NonRotatingShift,	Sum(AITSalary) as AITSalary,	 " +
                       " Sum(MobileBill) as MobileBill,	Sum(AdvanceSalary) as AdvanceSalary,	Sum(OtherDeduction) as OtherDeduction,	Sum(MedicalAllowanceforStaff) as MedicalAllowanceforStaff,	 " +
                       " Sum(OverTime) as OverTime,	Sum(Lunch) as Lunch, Sum(NightShiftAllowance) as NightShiftAllowance,	Sum(ChildEducationAllowance) as ChildEducationAllowance,	 " +
                       " Sum(BuildingLoan) as BuildingLoan,	Sum(HouseMaintenance) as HouseMaintenance,	Sum(UtilityExpense) as UtilityExpense, " +
                       " Sum(CanteenExpense) as CanteenExpense,	Sum(OtherExpense) as OtherExpense,	Sum(DriverExpense) as DriverExpense,	 " +
                       " Sum(ServentExpense) as ServentExpense,	Sum(RotatingShift) as RotatingShift,	Sum(BuildingPrincipal) as BuildingPrincipal, " +
                       " Sum(BuildingInterest) as BuildingInterest,	Sum(PFPrincipal) as PFPrincipal,	Sum(PFInterest) as PFInterest,	Sum(OtherScheme) as OtherScheme " +
                       " from (  " +
                       " Select a.*, IsNull(BuildingPrincipal,0) as BuildingPrincipal, IsNull(BuildingInterest,0) as BuildingInterest, " +
                      " IsNull(PFPrincipal,0) as PFPrincipal, IsNull(PFInterest,0) as PFInterest, IsNull(OtherLoan,0) as OtherScheme from  " +
                      " ( Select a.PayrollID,a.EmployeeID, EmployeeCode, EmployeeName, DesignationName, DepartmentName, c.CompanyName, TMonth, TYear,IsNull(b.Description,'') as Description, " +
                      " Sum(Case When ItemID = 8 then EditedAmount else 0 end) as BasicSalary, " +
                      " Sum(Case When ItemID = 9 then EditedAmount else 0 end) as ConsolidateSalary, " +
                      " Sum(Case When ItemID = 10 then EditedAmount else 0 end) as HouseRent, " +
                      " Sum(Case When ItemID = 11 then EditedAmount else 0 end) as CarAllowance, " +
                      " Sum(Case When ItemID = 12 then EditedAmount else 0 end) as Conveyance, " +
                      " Sum(Case When ItemID = 13 then EditedAmount else 0 end) as EntertainmentAllowance, " +
                      " Sum(Case When ItemID = 14 then EditedAmount else 0 end) as FestivalBonus, " +
                      " Sum(Case When ItemID = 15 then EditedAmount else 0 end) as SpecialAllowance, " +
                      " Sum(Case When ItemID = 16 then EditedAmount else 0 end) as LFA, " +
                      " Sum(Case When ItemID = 17 then EditedAmount else 0 end) as PF, " +
                      " Sum(Case When ItemID = 18 then EditedAmount else 0 end) as PFLoan, " +
                      " Sum(Case When ItemID = 19 then EditedAmount else 0 end) as ArticleLoanTV, " +
                      " Sum(Case When ItemID = 20 then EditedAmount else 0 end) as ArticleLoanRef, " +
                      " Sum(Case When ItemID = 21 then EditedAmount else 0 end) as ArticleLoanAC, " +
                      " Sum(Case When ItemID = 22 then EditedAmount else 0 end) as EPSLoan, " +
                      " Sum(Case When ItemID = 23 then EditedAmount else 0 end) as EmergencyLoan, " +
                      " Sum(Case When ItemID = 24 then EditedAmount else 0 end) as CarLoan, " +
                      " Sum(Case When ItemID = 25 then EditedAmount else 0 end) as NonRotatingShift, " +
                      " Sum(Case When ItemID = 26 then EditedAmount else 0 end) as AITSalary, " +
                      " Sum(Case When ItemID = 27 then EditedAmount else 0 end) as MobileBill, " +
                      " Sum(Case When ItemID = 28 then EditedAmount else 0 end) as AdvanceSalary, " +
                      " Sum(Case When ItemID = 29 then EditedAmount else 0 end) as OtherDeduction,  " +
                      " Sum(Case When ItemID = 30 then EditedAmount else 0 end) as MedicalAllowanceforStaff,  " +
                      " Sum(Case When ItemID = 31 then EditedAmount else 0 end) as OverTime,  " +
                      " Sum(Case When ItemID = 32 then EditedAmount else 0 end) as Lunch,  " +
                      " Sum(Case When ItemID = 33 then EditedAmount else 0 end) as NightShiftAllowance,  " +
                      " Sum(Case When ItemID = 34 then EditedAmount else 0 end) as ChildEducationAllowance, " +
                      " Sum(Case When ItemID = 35 then EditedAmount else 0 end) as BuildingLoan,  " +
                      " Sum(Case When ItemID = 36 then EditedAmount else 0 end) as HouseMaintenance,   " +
                      " Sum(Case When ItemID = 37 then EditedAmount else 0 end) as UtilityExpense,  " +
                      " Sum(Case When ItemID = 38 then EditedAmount else 0 end) as CanteenExpense,  " +
                      " Sum(Case When ItemID = 39 then EditedAmount else 0 end) as OtherExpense,  " +
                      " Sum(Case When ItemID = 40 then EditedAmount else 0 end) as DriverExpense,  " +
                      " Sum(Case When ItemID = 41 then EditedAmount else 0 end) as ServentExpense,  " +
                      " Sum(Case When ItemID = 42 then EditedAmount else 0 end) as RotatingShift  " +
                      " from  dbo.t_HRPayrollItem a, t_HRPayroll b, t_Company c, v_EmployeeDetails d Where a.PayrollID=b.PayrollID  " +
                      " and b.CompanyID = c.CompanyID and a.EmployeeID=d.EmployeeID and Type=" + (int)Dictionary.PayrollType.Staff + " and a.PayrollID IN ";
                
                if (nPayrollSettings == (int)Dictionary.PayrollSettings.FullSalary)
                {
                    sSQL = sSQL + " (Select distinct a.PayrollID from dbo.t_HRPayrollSettings a, t_HRPayroll b "+
                    " Where a.PayrollID=b.PayrollID and SettingsID = " + (int)Dictionary.PayrollSettings.FullSalary + " and TMonth=" + nMonth + " and TYear = " + nYear + " and CompanyID=" + nCompnayID + ") ";
                }
                else if (nPayrollSettings == (int)Dictionary.PayrollSettings.FestivalBonus)
                {
                    sSQL = sSQL + " (Select distinct a.PayrollID from dbo.t_HRPayrollSettings a, t_HRPayroll b "+
                    " Where a.PayrollID=b.PayrollID and SettingsID = " + (int)Dictionary.PayrollSettings.FestivalBonus + " and TMonth=" + nMonth + " and TYear = " + nYear + " and CompanyID=" + nCompnayID + "  " +
                    " and a.PayrollID Not IN (Select distinct PayrollID from dbo.t_HRPayrollSettings Where SettingsID IN (" + (int)Dictionary.PayrollSettings.FullSalary + "," + (int)Dictionary.PayrollSettings.LFA + ")))";
                }
                else if (nPayrollSettings == (int)Dictionary.PayrollSettings.LFA)
                {
                    sSQL = sSQL + " (Select distinct a.PayrollID from dbo.t_HRPayrollSettings a, t_HRPayroll b "+
                    " Where a.PayrollID=b.PayrollID and SettingsID = " + (int)Dictionary.PayrollSettings.LFA + " and TMonth=" + nMonth + " and TYear = " + nYear + " and CompanyID=" + nCompnayID + " " +
                    " and a.PayrollID Not IN (Select distinct PayrollID from dbo.t_HRPayrollSettings Where SettingsID IN (" + (int)Dictionary.PayrollSettings.FullSalary + "," + (int)Dictionary.PayrollSettings.FestivalBonus + "))) ";
                }
                else if (nPayrollSettings == (int)Dictionary.PayrollSettings.AREAR)
                {
                    sSQL = sSQL + " (Select distinct a.PayrollID from dbo.t_HRPayrollSettings a, t_HRPayroll b "+
                    " Where a.PayrollID=b.PayrollID and SettingsID = " + (int)Dictionary.PayrollSettings.AREAR + " and TMonth=" + nMonth + " and TYear = " + nYear + " and CompanyID=" + nCompnayID + ") ";
                }

                sSQL = sSQL + " group by a.PayrollID, a.EmployeeID, EmployeeCode, EmployeeName, DesignationName, DepartmentName, c.CompanyName, TMonth, TYear, b.Description)a Left Outer JOIN " +
                " ( " +
                "  Select EmployeeID,  Sum(Case When LoanTypeID = 2 then PrincipalPayable else 0 end) as BuildingPrincipal,  " +
                "  Sum(Case When LoanTypeID = 2 then InterestPayable else 0 end) as BuildingInterest,  " +
                "  Sum(Case When LoanTypeID = 5 then PrincipalPayable else 0 end) as PFPrincipal,  " +
                "  Sum(Case When LoanTypeID = 5 then InterestPayable else 0 end) as PFInterest,  " +
                " Sum(Case When LoanTypeID > 5 then TotalPayable else 0 end) as OtherLoan from t_HRLoan a, t_HRLoanDetail b  " +
                "  Where a.LoanID=b.LoanID  and Month(PaymentDate) = " + nMonth + " and Year (PaymentDate) = " + nYear + " and IsEarlyClose= 0 " +
                "  and CompanyID =" + nCompnayID + " group by EmployeeID " +
                "  ) b " +
                "  ON a.EmployeeID = b.EmployeeID ) x Group by PayrollID,CompanyName,	Description Order by PayrollID ";
                

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeAllowance oHRPayrollAllow = new EmployeeAllowance();

                    oHRPayrollAllow.CompanyName = (string)reader["CompanyName"];
                    oHRPayrollAllow.TotalEmpl = (int)reader["Empltotal"];
                    oHRPayrollAllow.Description = (string)reader["Description"];
                    oHRPayrollAllow.BasicSalary = (double)reader["BasicSalary"];
                    oHRPayrollAllow.ConsolidateSalary = (double)reader["ConsolidateSalary"];
                    oHRPayrollAllow.HouseRent = (double)reader["HouseRent"];
                    oHRPayrollAllow.CarAllowance = (double)reader["CarAllowance"];
                    oHRPayrollAllow.Conveyance = (double)reader["Conveyance"];
                    oHRPayrollAllow.EntertainmentAllowance = (double)reader["EntertainmentAllowance"];
                    oHRPayrollAllow.FestivalBonus = (double)reader["FestivalBonus"];
                    oHRPayrollAllow.SpecialAllowance = (double)reader["SpecialAllowance"];
                    oHRPayrollAllow.LFA = (double)reader["LFA"];
                    oHRPayrollAllow.PF = (double)reader["PF"];
                    oHRPayrollAllow.PFLoan = (double)reader["PFLoan"];
                    if (nPayrollSettings == (int)Dictionary.PayrollSettings.FullSalary)
                    {
                        oHRPayrollAllow.PFLoanPrincipal = (double)reader["PFPrincipal"];
                        oHRPayrollAllow.PFLoanInterest = (double)reader["PFInterest"];
                        oHRPayrollAllow.BuildingLoanPrincipal = (double)reader["BuildingPrincipal"];
                        oHRPayrollAllow.BuildingLoanInterest = (double)reader["BuildingInterest"];
                    }
                    else
                    {
                        oHRPayrollAllow.PFLoanPrincipal = 0;
                        oHRPayrollAllow.PFLoanInterest = 0;
                        oHRPayrollAllow.BuildingLoanPrincipal = 0;
                        oHRPayrollAllow.BuildingLoanInterest = 0;
                    }
                    oHRPayrollAllow.ArticleLoanTV = (double)reader["ArticleLoanTV"];
                    oHRPayrollAllow.ArticleLoanRef = (double)reader["ArticleLoanRef"];
                    oHRPayrollAllow.ArticleLoanAC = (double)reader["ArticleLoanAC"];
                    oHRPayrollAllow.EPSLoan = (double)reader["EPSLoan"];
                    oHRPayrollAllow.EmergencyLoan = (double)reader["EmergencyLoan"];
                    oHRPayrollAllow.CarLoan = (double)reader["CarLoan"];
                    oHRPayrollAllow.NonRotatingShift = (double)reader["NonRotatingShift"];
                    oHRPayrollAllow.AITSalary = (double)reader["AITSalary"];
                    oHRPayrollAllow.MobileBill = (double)reader["MobileBill"];
                    oHRPayrollAllow.AdvanceSalary = (double)reader["AdvanceSalary"];
                    oHRPayrollAllow.OtherDeduction = (double)reader["OtherDeduction"];
                    oHRPayrollAllow.MedicalAllowanceforStaff = (double)reader["MedicalAllowanceforStaff"];
                    oHRPayrollAllow.OverTime = (double)reader["OverTime"];
                    oHRPayrollAllow.Lunch = (double)reader["Lunch"];
                    oHRPayrollAllow.NightShiftAllowance = (double)reader["NightShiftAllowance"];
                    oHRPayrollAllow.ChildEducationAllowance = (double)reader["ChildEducationAllowance"];
                    oHRPayrollAllow.BuildingLoan = (double)reader["BuildingLoan"];
                    oHRPayrollAllow.OtherScheme = (double)reader["OtherScheme"];
                    oHRPayrollAllow.HouseMaintenance = (double)reader["HouseMaintenance"];
                    oHRPayrollAllow.UtilityExpense = (double)reader["UtilityExpense"];
                    oHRPayrollAllow.CanteenExpense = (double)reader["CanteenExpense"];
                    oHRPayrollAllow.OtherExpense = (double)reader["OtherExpense"];
                    oHRPayrollAllow.DriverExpense = (double)reader["DriverExpense"];
                    oHRPayrollAllow.ServentExpense = (double)reader["ServentExpense"];
                    oHRPayrollAllow.RotatingShift = (double)reader["RotatingShift"];

                    InnerList.Add(oHRPayrollAllow);
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


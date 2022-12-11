// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Jun 21, 2016
// Time : 03:30 PM
// Description: Class for HRPayroll.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class HRPayrollItem
    {
        private int _nPayrollItemID;
        private int _nPayrollID;
        private int _nEmployeeID;
        private int _nItemID;
        private double _CalculatedAmount;
        private double _EditedAmount;

        // <summary>
        // Get set property for PayrollItemID
        // </summary>
        public int PayrollItemID
        {
            get { return _nPayrollItemID; }
            set { _nPayrollItemID = value; }
        }

        // <summary>
        // Get set property for PayrollDetailID
        // </summary>
        public int PayrollID
        {
            get { return _nPayrollID; }
            set { _nPayrollID = value; }
        }

        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        // <summary>
        // Get set property for ItemID
        // </summary>
        public int ItemID
        {
            get { return _nItemID; }
            set { _nItemID = value; }
        }

        // <summary>
        // Get set property for CalculatedAmount
        // </summary>
        public double CalculatedAmount
        {
            get { return _CalculatedAmount; }
            set { _CalculatedAmount = value; }
        }

        // <summary>
        // Get set property for EditedAmount
        // </summary>
        public double EditedAmount
        {
            get { return _EditedAmount; }
            set { _EditedAmount = value; }
        }

        private int _nCompanyID;
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }
        private string _sVendorID;
        public string VendorID
        {
            get { return _sVendorID; }
            set { _sVendorID = value; }
        }
        private string _sVendorName;
        public string VendorName
        {
            get { return _sVendorName; }
            set { _sVendorName = value; }
        }
        private string _sDistributionSet;
        public string DistributionSet
        {
            get { return _sDistributionSet; }
            set { _sDistributionSet = value; }
        }
        private string _sDistributionID;
        public string DistributionID
        {
            get { return _sDistributionID; }
            set { _sDistributionID = value; }
        }
        private string _sDristributionDes;
        public string DristributionDes
        {
            get { return _sDristributionDes; }
            set { _sDristributionDes = value; }
        }

        private string _sPayrollDes;
        public string PayrollDes
        {
            get { return _sPayrollDes; }
            set { _sPayrollDes = value; }
        }

        private double _CurrentAmount;
        public double CurrentAmount
        {
            get { return _CurrentAmount; }
            set { _CurrentAmount = value; }
        }

        private double _PreviousAmount;
        public double PreviousAmount
        {
            get { return _PreviousAmount; }
            set { _PreviousAmount = value; }
        }

        private int _nStatus;
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        private string _sDistributionType;
        public string DistributionType
        {
            get { return _sDistributionType; }
            set { _sDistributionType = value; }
        }

        private string _sVendorType;
        public string VendorType
        {
            get { return _sVendorType; }
            set { _sVendorType = value; }
        }

        public void Add(int nPayrollID)
        {
            int nMaxPayrollItemID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([PayrollItemID]) FROM t_HRPayrollItem";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPayrollItemID = 1;
                }
                else
                {
                    nMaxPayrollItemID = Convert.ToInt32(maxID) + 1;
                }
                _nPayrollItemID = nMaxPayrollItemID;
                sSql = "INSERT INTO t_HRPayrollItem (PayrollItemID, PayrollID, EmployeeID, ItemID, CalculatedAmount, EditedAmount) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PayrollItemID", _nPayrollItemID);
                cmd.Parameters.AddWithValue("PayrollID", nPayrollID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("ItemID", _nItemID);
                cmd.Parameters.AddWithValue("CalculatedAmount", _CalculatedAmount);
                cmd.Parameters.AddWithValue("EditedAmount", _EditedAmount);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshPayrollItem(int nPayrollID, int nEmployeeID, int nItemID)
        {
          
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRPayrollItem Where PayrollID = " + nPayrollID + " and EmployeeID = " + nEmployeeID + " and ItemID=" + nItemID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nPayrollItemID = (int)reader["PayrollItemID"];
                    _nPayrollID = (int)reader["PayrollID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nItemID = (int)reader["ItemID"];
                    _CalculatedAmount = Convert.ToDouble(reader["CalculatedAmount"].ToString());
                    _EditedAmount = Convert.ToDouble(reader["EditedAmount"].ToString());

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetArearItemValue(int nEmployeeID, int nCompanyID, int nAllowanceID, int nMonth, int nYear, string sArearMonths, string sArearYear)
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select ItemID, CurrentAmount, PreviousAmount from  " +
                          "  ( " +
                          "  Select ItemID, Sum(CurrentAmount) as CurrentAmount, Sum(PreviousAmount) as PreviousAmount from  " +
                          "  ( " +
                          "  select ItemID, EditedAmount as CurrentAmount, 0 as PreviousAmount from dbo.t_HRPayroll a, t_HRPayrollItem b, t_HRPayrollSettings c " +
                          "  Where a.PayrollID=b.PayrollID and a.PayrollID=c.PayrollID and EmployeeID=" + nEmployeeID + " and CompanyID = " + nCompanyID + " " +
                          "  and SettingsID=" + (int)Dictionary.PayrollSettings.FullSalary + " and TMonth=" + nMonth + " and TYear=" + nYear + " and Status IN (" + (int)Dictionary.PayrollStatus.Approve + "," + (int)Dictionary.PayrollStatus.Send_to_Accpac + "," + (int)Dictionary.PayrollStatus.Post_at_Accpac + ") " +
                          "  UNION ALL " +
                          "  select ItemID, 0 as CurrentAmount, Sum(EditedAmount) as PreviousAmount from dbo.t_HRPayroll a, t_HRPayrollItem b, t_HRPayrollSettings c " +
                          "  Where a.PayrollID=b.PayrollID and a.PayrollID=c.PayrollID and EmployeeID=" + nEmployeeID + " and CompanyID = " + nCompanyID + " " +
                          "  and SettingsID=" + (int)Dictionary.PayrollSettings.FullSalary + " and TMonth IN (" + sArearMonths + ") and TYear IN (" + sArearYear + ") and Status IN (" + (int)Dictionary.PayrollStatus.Approve + "," + (int)Dictionary.PayrollStatus.Send_to_Accpac + "," + (int)Dictionary.PayrollStatus.Post_at_Accpac + ") Group by ItemID " +
                          "  )x Group by ItemID " +
                          "  )a, " +
                          "  (select AllowanceID from dbo.t_HRPayrollEmployeeAllowance Where EffectiveYear=" + nYear + "  " +
                          "  and EmployeeID=" + nEmployeeID + " and CompanyID = " + nCompanyID + " )b Where a.ItemID=b.AllowanceID and ItemID=" + nAllowanceID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nItemID = (int)reader["ItemID"];
                    _CurrentAmount = Convert.ToDouble(reader["CurrentAmount"].ToString());
                    _PreviousAmount = Convert.ToDouble(reader["PreviousAmount"].ToString());

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteMapERPPayroll()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_MapERPHRPayroll WHERE [PayrollID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddtoAccpac(int nPayrollID, int nMonth, int nYear)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_MapERPHRPayroll (PayrollID, CompanyID, Month, Year, PayrollDes, VendorID, VendorName, "+
                    " VendorType, DistributionID, DistributionSet, DistributionDes, DistributionType, Amount, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PayrollID", nPayrollID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("Month", nMonth);
                cmd.Parameters.AddWithValue("Year", nYear);
                cmd.Parameters.AddWithValue("PayrollDes", _sPayrollDes);
                cmd.Parameters.AddWithValue("VendorID", _sVendorID);
                cmd.Parameters.AddWithValue("VendorName", _sVendorName);
                cmd.Parameters.AddWithValue("VendorType", _sVendorType);
                cmd.Parameters.AddWithValue("DistributionID", _sDistributionID);
                cmd.Parameters.AddWithValue("DistributionSet", _sDistributionSet);
                cmd.Parameters.AddWithValue("DistributionDes", _sDristributionDes);
                cmd.Parameters.AddWithValue("DistributionType", _sDistributionType);
                cmd.Parameters.AddWithValue("Amount", _EditedAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class HRPayroll : CollectionBase
    {
        private int _nPayrollID;
        private int _nEmployeeID;// 
        private string _sEmployeeName;//
        private string _sEmployeeCode;//
        private int _nCompanyID;
        private string _sCompanyCode;
        private string _sCompanyName;
        private int _nDepartmentID;//
        private string _sDepartmrntName;//
        private string _sDesignationName;//
        private double _nEditedAmount;//
        private int _nTMonth;
        private int _nTYear;
        private int _nType;
        private int _nStatus;
        private string _sDescription;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private DateTime _dPunchDate;
        private string _sStatusName;


        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value; }
        }

        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }
        }

        public string DepartmrntName
        {
            get { return _sDepartmrntName; }
            set { _sDepartmrntName = value; }
        }

        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }
        public string DesignationName
        {
            get { return _sDesignationName; }
            set { _sDesignationName = value; }
        }

        public double EditedAmount
        {
            get { return _nEditedAmount; }
            set { _nEditedAmount = value; }
        }
        // <summary>
        // Get set property for PayrollID
        // </summary>
        public int PayrollID
        {
            get { return _nPayrollID; }
            set { _nPayrollID = value; }
        }
        
        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        public string CompanyCode
        {
            get { return _sCompanyCode; }
            set { _sCompanyCode = value; }
        }
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value; }
        }

        // <summary>
        // Get set property for TMonth
        // </summary>
        public int TMonth
        {
            get { return _nTMonth; }
            set { _nTMonth = value; }
        }

        // <summary>
        // Get set property for TYear
        // </summary>
        public int TYear
        {
            get { return _nTYear; }
            set { _nTYear = value; }
        }

        // <summary>
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
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
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
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

        public DateTime PunchDate
        {
            get { return _dPunchDate; }
            set { _dPunchDate = value; }
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

        private int _nNoOfEmpl;
        public int NoOfEmpl
        {
            get { return _nNoOfEmpl; }
            set { _nNoOfEmpl = value; }
        }
        private double _GrossSalary;
        public double GrossSalary
        {
            get { return _GrossSalary; }
            set { _GrossSalary = value; }
        }
        private double _Deduct;
        public double Deduct
        {
            get { return _Deduct; }
            set { _Deduct = value; }
        }
        private double _NetSalary;
        public double NetSalary
        {
            get { return _NetSalary; }
            set { _NetSalary = value; }
        }
        private double _Expense;
        public double Expense
        {
            get { return _Expense; }
            set { _Expense = value; }
        }
        private double _Subsidy;
        public double Subsidy
        {
            get { return _Subsidy; }
            set { _Subsidy = value; }
        }
        private double _TotalSalary;
        public double TotalSalary
        {
            get { return _TotalSalary; }
            set { _TotalSalary = value; }
        }
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _sCode;
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value; }
        }
        private object _nApproveBy;
        public object ApproveBy
        {
            get { return _nApproveBy; }
            set { _nApproveBy = value; }
        }
        private string _sApproveUserName;
        public string ApproveUserName
        {
            get { return _sApproveUserName; }
            set { _sApproveUserName = value; }
        }
        private object _dApproveDate;
        public object ApproveDate
        {
            get { return _dApproveDate; }
            set { _dApproveDate = value; }
        }
        private object _nVerifiedBy;
        public object VerifiedBy
        {
            get { return _nVerifiedBy; }
            set { _nVerifiedBy = value; }
        }
        private string _sVerifiedUserName;
        public string VerifiedUserName
        {
            get { return _sVerifiedUserName; }
            set { _sVerifiedUserName = value; }
        }
        private object _dVerifiedDate;
        public object VerifiedDate
        {
            get { return _dVerifiedDate; }
            set { _dVerifiedDate = value; }
        }




        public HRPayrollItem this[int i]
        {
            get { return (HRPayrollItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(HRPayrollItem oHRPayrollItem)
        {
            InnerList.Add(oHRPayrollItem);
        }

        public int GetIndex(int nPayrollItemID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].PayrollItemID == nPayrollItemID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void RefreshPayrollItem()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRPayrollItem Where PayrollID = " + _nPayrollID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayrollItem oHRPayrollItem = new HRPayrollItem();

                    oHRPayrollItem.PayrollItemID = (int)reader["PayrollItemID"];
                    oHRPayrollItem.PayrollID = (int)reader["PayrollID"];
                    oHRPayrollItem.EmployeeID = (int)reader["EmployeeID"];
                    oHRPayrollItem.ItemID = (int)reader["ItemID"];
                    oHRPayrollItem.CalculatedAmount = Convert.ToDouble(reader["CalculatedAmount"].ToString());
                    oHRPayrollItem.EditedAmount = Convert.ToDouble(reader["EditedAmount"].ToString());
                    
                    InnerList.Add(oHRPayrollItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetEmployeePFForReport(int nCompanyID, int nDepartmentID, int nEmployeeID, int nTMonth, int nTYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select EmployeeCode, EmployeeName, DesignationName, DepartmentName, EditedAmount"
                    + " from dbo.t_HRPayroll a, dbo.t_HRPayrollItem b, v_EmployeeDetails c"
                    + " Where a.PayrollID=b.PayrollID and b.EmployeeID=c.EmployeeID"
                    + "  AND ItemID=" + (int)Dictionary.HREmployeeAllowance.PF + " AND Tmonth= " + nTMonth + " AND TYear= " + nTYear + " AND a.CompanyID = " + nCompanyID + " ";

            if(nEmployeeID != -1)
            {
                sSql += " AND b.EmployeeID = " + nEmployeeID + " ";
            }
            if(nDepartmentID != -1)
            {
                sSql += " AND DepartmentID=" + nDepartmentID + " ";
            }
            sSql += " Order by EmployeeCode ";
            try
            {               
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayroll oHRPayroll = new HRPayroll();
                    oHRPayroll.EmployeeCode = (string)reader["EmployeeCode"];
                    oHRPayroll.EmployeeName = (string)reader["EmployeeName"];
                    oHRPayroll.DesignationName = (string)reader["DesignationName"];
                    oHRPayroll.DepartmrntName = (string)reader["DepartmentName"];
                    oHRPayroll.EditedAmount = (double)reader["EditedAmount"];
                    InnerList.Add(oHRPayroll);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void GetEmployeeByPayrollID()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " SELECT Max (PayrollItemID) as PayrollItemID, EmployeeID " +
                                  " FROM t_HRPayrollItem Where PayrollID = ? Group by EmployeeID  " +
                                  " order by PayrollItemID ";

                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayrollItem oHRPayrollItem = new HRPayrollItem();

                    oHRPayrollItem.EmployeeID = (int)reader["EmployeeID"];
                    InnerList.Add(oHRPayrollItem);

                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetTotalEmployeeByPayrollID()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " Select Count(*) as Count from ( SELECT EmployeeID " +
                                    " FROM t_HRPayrollItem Where PayrollID = ? Group by EmployeeID )x ";

                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);

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

        public void Add(bool bFlag)
        {
            int nMaxPayrollID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (bFlag)
                {
                    sSql = "SELECT MAX([PayrollID]) FROM t_HRPayroll";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxPayrollID = 1;
                    }
                    else
                    {
                        nMaxPayrollID = Convert.ToInt32(maxID) + 1;
                    }
                    _nPayrollID = nMaxPayrollID;

                    sSql = "INSERT INTO t_HRPayroll (PayrollID, Code, CompanyID, TMonth, TYear, Type, Status, Description, NoOfEmployee, GrossSalary, Deduction, NetSalary, Expense, Subsidy, TotalSalary, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);
                    cmd.Parameters.AddWithValue("Code", _sCode);
                    cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                    cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                    cmd.Parameters.AddWithValue("TYear", _nTYear);
                    cmd.Parameters.AddWithValue("Type", _nType);
                    cmd.Parameters.AddWithValue("Status", _nStatus);
                    cmd.Parameters.AddWithValue("Description", _sDescription);
                    cmd.Parameters.AddWithValue("NoOfEmployee", _nNoOfEmpl);
                    cmd.Parameters.AddWithValue("GrossSalary", _GrossSalary);
                    cmd.Parameters.AddWithValue("Deduction", _Deduct);
                    cmd.Parameters.AddWithValue("NetSalary", _NetSalary);
                    cmd.Parameters.AddWithValue("Expense", _Expense);
                    cmd.Parameters.AddWithValue("Subsidy", _Subsidy);
                    cmd.Parameters.AddWithValue("TotalSalary", _TotalSalary);
                    cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                    cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }                                               

                foreach (HRPayrollItem oItem in this)
                {
                    oItem.Add(_nPayrollID);
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
                sSql = "UPDATE t_HRPayroll SET CompanyID = ?, TMonth = ?, TYear = ?, Type = ?, Description = ?, NoOfEmployee = ?, GrossSalary = ?, Deduction = ?, NetSalary = ?, Expense = ?, Subsidy = ?, TotalSalary = ?, UpdateUserID = ?, UpdateDate = ? WHERE PayrollID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("NoOfEmployee", _nNoOfEmpl);
                cmd.Parameters.AddWithValue("GrossSalary", _GrossSalary);
                cmd.Parameters.AddWithValue("Deduction", _Deduct);
                cmd.Parameters.AddWithValue("NetSalary", _NetSalary);
                cmd.Parameters.AddWithValue("Expense", _Expense);
                cmd.Parameters.AddWithValue("Subsidy", _Subsidy);
                cmd.Parameters.AddWithValue("TotalSalary", _TotalSalary);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditNoOfEmployee(int nNoOfEmpl)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPayroll SET NoOfEmployee = ? WHERE PayrollID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("NoOfEmployee", nNoOfEmpl);

                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);

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
                cmd = DBController.Instance.GetCommand();
                sSql = "DELETE FROM t_HRPayrollSettings WHERE [PayrollID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                sSql = "DELETE FROM t_HRPayrollItem WHERE [PayrollID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                sSql = "DELETE FROM t_HRPayroll WHERE [PayrollID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteItem()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_HRPayrollItem WHERE [PayrollID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);
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
                cmd.CommandText = "SELECT * FROM t_HRPayroll where PayrollID =?";
                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPayrollID = (int)reader["PayrollID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _nTMonth = (int)reader["TMonth"];
                    _nTYear = (int)reader["TYear"];
                    _nType = (int)reader["Type"];
                    _nStatus = (int)reader["Status"];
                    _sDescription = (string)reader["Description"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public int PayrollCount(int nCompanyID, int nMonth, int nYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCode = 0;
            try
            {
                cmd.CommandText = " Select a.PayrollID, RIGHT(Code, 2)Code from t_HRPayroll a, " +
                                   " (SELECT Max(PayrollID) PayrollID FROM t_HRPayroll where CompanyID =" + nCompanyID + " and TMonth=" + nMonth + " and TYear = " + nYear + " )b " +
                                   " Where a.PayrollID=b.PayrollID ";
              
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCode = Convert.ToInt32(reader["Code"]);
                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nCode;
        }

        public void Approve()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPayroll SET Status = ?, ApproveBy = ?, ApproveDate = ? WHERE PayrollID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApproveBy", _nApproveBy);
                cmd.Parameters.AddWithValue("ApproveDate", _dApproveDate);

                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void StatusUpdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPayroll SET Status = ? WHERE PayrollID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Verify()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HRPayroll SET Status = ?, VerifiedBy = ?, VerifiedDate = ? WHERE PayrollID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("VerifiedBy", _nVerifiedBy);
                cmd.Parameters.AddWithValue("VerifiedDate", _dVerifiedDate);

                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public double GetTakehomeSalary(int nEmployeeID, int nCompanyID, int nYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Amount = 0;
            try
            {
                cmd.CommandText = " Select Sum(Amount) as Amount from dbo.t_HRPayrollEmployeeAllowance " +
                                  " Where EmployeeID=" + nEmployeeID + " and CompanyID = " + nCompanyID + " and EffectiveYear=" + nYear + " " +
                                  " and AllowanceID IN ( "+
                                  " " + (int)Dictionary.HREmployeeAllowance.BasicSalary + ", "+
                                  " " + (int)Dictionary.HREmployeeAllowance.HouseRent + ", "+
                                  " " + (int)Dictionary.HREmployeeAllowance.CarAllowance + ", "+
                                  " " + (int)Dictionary.HREmployeeAllowance.MedicalAllowanceforStaff + ", " +
                                  " " + (int)Dictionary.HREmployeeAllowance.Conveyance + ", "+
                                  " " + (int)Dictionary.HREmployeeAllowance.EntertainmentAllowance + ", "+
                                  " " + (int)Dictionary.HREmployeeAllowance.SpecialAllowance + ", "+
                                  " " + (int)Dictionary.HREmployeeAllowance.LunchExpense + ", "+
                                  " " + (int)Dictionary.HREmployeeAllowance.Utilityexpense + ", "+
                                  " " + (int)Dictionary.HREmployeeAllowance.NonRotatingShift + ", " +
                                  " " + (int)Dictionary.HREmployeeAllowance.ChildEducationAllowance + ", " +
                                  " " + (int)Dictionary.HREmployeeAllowance.RotatingShift + ", " +
                                  " " + (int)Dictionary.HREmployeeAllowance.Serventexpense + ") ";

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

        public void RefreshPayrollforAccpac(int nCompanyID, int nMonth, int nYear, int nPayrollID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select a.CompanyID, a.EmployeeID, VendorID, VendorName, VendorType, DistributionSet, DistributionID, DristributionDesc, DistributionType, CJAllowanceID, IsNull(Amount,0) as Amount from  " +
                           " (Select CompanyID, EmployeeID, VendorID, VendorName, VendorType, DistributionSet, DistributionID, DristributionDesc, CJAllowanceID from " +
                           " ( " +
                           " Select a.CompanyID, EmployeeID, ('I'+a.EmployeeCode) as VendorID, EmployeeName as VendorName, a.DistributionSet, b.DepartmentCode, ASG,  " +
                           " AccpacAllowanceID, (b.DepartmentCode + ASG + CONVERT(varchar(10), AccpacAllowanceID)) as  DistributionID, Description as DristributionDesc, CJAllowanceID,  " +
                           " Case When GradeType=1 then 'Officer'  When GradeType=2 then 'Supervisor' else 'Staff' end as VendorType "+
                           " from dbo.t_MapERPHREmployeeDistributionSet a, t_MapERPHRDistributionSet b,  " +
                           " t_MapERPHRAccpacCJAllowanceID c, v_EmployeeDetails d " +
                           " Where a.DistributionSet=b.DistributionSet and a.CompanyID=b.CompanyID  " +
                           " and a.CompanyID=c.CompanyID and d.CompanyID=a.CompanyID and d.EmployeeCode=a.EmployeeCode " +
                           " ) as x) as a " +
                           " INNER JOIN " +
                // --Payroll Amt Start
                           " (Select CompanyID, EmployeeID, ItemID, DistributionType, Sum(Amount) as Amount " +
                           " From  " +
                           " ( " +
                           " Select CompanyID, EmployeeID, ItemID, CASE When GroupID = 1 then 'Salary' " +
                           " When GroupID = 2 then 'Deduction' When GroupID = 3 then 'Expense' When GroupID = 4 then 'Subsidy' else '?' end as DistributionType, CASE When GroupID = 2 then EditedAmount *-1 else EditedAmount end as Amount  " +
                           " from dbo.t_HRPayroll a, dbo.t_HRPayrollItem b, (Select ID, GroupID from dbo.t_HRAllowanceDeduction where IsPayrollItem=1)c " +
                           " Where a.PayrollID=b.PayrollID  and b.ItemID=c.ID and a.PayrollID=" + nPayrollID + " and ItemID Not IN (21,25,38,42,35,18) " +
                           
                           " UNION ALL " +
                           
                           " Select CompanyID, EmployeeID, ItemID, DistributionType, Case When DistributionType = 'Deduction' then Amount * -1 else Amount end as Amount from "+
                           " ( " +
                           " Select CompanyID, EmployeeID, ItemID, CASE When ItemID = 39 then 'Expense' When ItemID = 29 then 'Deduction' else 'Salary' end as DistributionType, Amount from  " +
                           " ( " +
                           " Select CompanyID, EmployeeID, ItemID = Case When ItemID = 38 then 39 When ItemID = 21 then 29 else 104 end, " +
                           " EditedAmount  as Amount from dbo.t_HRPayroll a, dbo.t_HRPayrollItem b Where a.PayrollID=b.PayrollID and a.PayrollID=" + nPayrollID + " " +
                           " and ItemID IN (21,25,38,42) " +
                           " )x " +
                           " )z " +
                           
                           " UNION ALL " +

                           " Select a.CompanyID, EmployeeID, 105 as ItemID, 'Salary' as DistributionType, " +
                           " EditedAmount as Amount from dbo.t_HRPayroll a, dbo.t_HRPayrollItem b, dbo.t_HRAllowanceDeduction c " +
                           " Where a.PayrollID=b.PayrollID  and b.ItemID=c.ID  " +
                           " and a.PayrollID= " + nPayrollID + " and b.ItemID = 17  " +

                           " UNION ALL  " +
                           " Select a.CompanyID, EmployeeID, 106 as ItemID, 'Deduction' as DistributionType,  " +
                           " EditedAmount *-1 as Amount from dbo.t_HRPayroll a, dbo.t_HRPayrollItem b, dbo.t_HRAllowanceDeduction c " +
                           " Where a.PayrollID=b.PayrollID  and b.ItemID=c.ID  " +
                           " and a.PayrollID= " + nPayrollID + " and b.ItemID = 17  " +

                           " UNION ALL " +
                           " Select CompanyID, x.EmployeeID, AllownaceID, 'Deduction' as DistributionType, Amount " +
                           " from  " +
                           " ( " +
                           " Select CompanyID,  EmployeeID, a.LoanID, 35 as AllownaceID, 'BuildingPrincipal' as AllowanceDes, (PrincipalPayable * -1) as Amount  from t_HRLoan a, t_HRLoanDetail b   " +
                           " Where a.LoanID=b.LoanID  and LoanTypeID = 2 and Month(PaymentDate) =  " + nMonth + "  and Year (PaymentDate) = " + nYear + "  and IsEarlyClose= 0 and CompanyID = " + nCompanyID + " " +
                           " UNION ALL " +
                           " Select CompanyID, EmployeeID,a.LoanID, 103 as AllownaceID, 'BuildingInterest' as AllowanceDes, (InterestPayable * -1) as Amount  from t_HRLoan a, t_HRLoanDetail b   " +
                           " Where a.LoanID=b.LoanID  and LoanTypeID = 2 and Month(PaymentDate) =  " + nMonth + "  and Year (PaymentDate) = " + nYear + "  and IsEarlyClose= 0 and CompanyID = " + nCompanyID + " " +
                           " UNION ALL " +
                           " Select CompanyID, EmployeeID,a.LoanID, 18 as AllownaceID, 'PFPrincipal' as AllowanceDes, (PrincipalPayable * -1) as Amount  from t_HRLoan a, t_HRLoanDetail b   " +
                           " Where a.LoanID=b.LoanID  and LoanTypeID = 5 and Month(PaymentDate) =  " + nMonth + "  and Year (PaymentDate) = " + nYear + "  and IsEarlyClose= 0 and CompanyID = " + nCompanyID + " " +
                           " UNION ALL " +
                           " Select CompanyID, EmployeeID,a.LoanID, 101 as AllownaceID, 'PFInterest' as AllowanceDes, (InterestPayable * -1) as Amount  from t_HRLoan a, t_HRLoanDetail b   " +
                           " Where a.LoanID=b.LoanID  and LoanTypeID = 5 and Month(PaymentDate) =  " + nMonth + "  and Year (PaymentDate) = " + nYear + "  and IsEarlyClose= 0 and CompanyID = " + nCompanyID + " " +
                           " ) as x, (Select distinct EmployeeID from dbo.t_HRPayrollItem Where PayrollID=" + nPayrollID + " ) y where x.EmployeeID=y.EmployeeID and Amount != 0 " +
                           " ) as Final Group by CompanyID, EmployeeID, ItemID, DistributionType)b " +
                           " ON a.CompanyID = b.CompanyID and a.EmployeeID=b.EmployeeID and a.CJAllowanceID = b.ItemID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayrollItem oHRPayrollItem = new HRPayrollItem();

                    oHRPayrollItem.CompanyID = (int)reader["CompanyID"];
                    oHRPayrollItem.EmployeeID = (int)reader["EmployeeID"];
                    oHRPayrollItem.VendorID = (string)reader["VendorID"];
                    oHRPayrollItem.VendorName = (string)reader["VendorName"];
                    oHRPayrollItem.VendorType = (string)reader["VendorType"];
                    oHRPayrollItem.DistributionSet = (string)reader["DistributionSet"];
                    oHRPayrollItem.DistributionID = (string)reader["DistributionID"];
                    oHRPayrollItem.DristributionDes = (string)reader["DristributionDesc"];
                    oHRPayrollItem.ItemID = (int)reader["CJAllowanceID"];
                    oHRPayrollItem.EditedAmount = Convert.ToDouble(reader["Amount"].ToString());
                    oHRPayrollItem.DistributionType = (string)reader["DistributionType"];

                    InnerList.Add(oHRPayrollItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshPayrollforAccpacBEIL(int nCompanyID, int nMonth, int nYear, int nPayrollID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select PayrollID, a.CompanyID, Month, Year, PayrollDesc, VendorID, VendorName, VendorType, DistributionID, DistributionSet, DristributionDesc, DistributionType, IsNull(Amount,0) as Amount, 0 as Status from  " +
                           " ( " +
                           " Select PayrollID, CompanyID, Month, Year, PayrollDesc, EmployeeID, VendorID, VendorName, VendorType, DistributionSet, DistributionID, DristributionDesc, CJAllowanceID from  " +
                           " (  " +
                           " Select e.PayrollID, b.CompanyID, f.TMonth as Month, f.TYear as Year, f.Description as PayrollDesc,  " +
                           " d.EmployeeID, (a.EmployeeCode) as VendorID, EmployeeName as VendorName, a.DistributionSet,    " +
                           " AccpacAllowanceID, DistributionCode as  DistributionID,  " +
                           " c.Description as DristributionDesc, CJAllowanceID, Case When GradeType=1 then 'Officer'   " +
                           " When GradeType=2 then 'Supervisor' else 'Staff' end as VendorType  " +
                           " from dbo.t_MapERPBEILHREmployeeDistributionSet a, t_MapERPBEILHRDistributionSet b,   " +
                           " t_MapERPHRAccpacCJAllowanceID c, v_EmployeeDetails d, (Select distinct PayrollID, EmployeeID from t_HRPayrollItem) e, t_HRPayroll f  " +
                           " Where a.DistributionSet = b.DistributionSet and b.CompanyID = c.CompanyID  " +
                           " and d.EmployeeCode = a.EmployeeCode and b.AllowanceID = c.AccpacAllowanceID  " +
                           " and e.EmployeeID = d.EmployeeID and e.PayrollID = f.PayrollID " +
                           " and f.PayrollID = " + nPayrollID + " and DistributionType = 'S' and b.CompanyID = " + nCompanyID + " " +
                           " ) as x) as a  " +
                           " INNER JOIN " +
                // --Payroll Amt Start
                           " (Select CompanyID, EmployeeID, ItemID, DistributionType, Sum(Amount) as Amount " +
                           " From  " +
                           " ( " +
                           " Select CompanyID, EmployeeID, ItemID, CASE When GroupID = 1 then 'Salary' " +
                           " When GroupID = 2 then 'Deduction' When GroupID = 3 then 'Expense' When GroupID = 4 then 'Subsidy' else '?' end as DistributionType, CASE When GroupID = 2 then EditedAmount *-1 else EditedAmount end as Amount  " +
                           " from dbo.t_HRPayroll a, dbo.t_HRPayrollItem b, (Select ID, GroupID from dbo.t_HRAllowanceDeduction where IsPayrollItem=1)c " +
                           " Where a.PayrollID=b.PayrollID  and b.ItemID=c.ID and a.PayrollID=" + nPayrollID + " and ItemID Not IN (21,25,38,42,35,18) " +

                           " UNION ALL " +

                           " Select CompanyID, EmployeeID, ItemID, DistributionType, Case When DistributionType = 'Deduction' then Amount * -1 else Amount end as Amount from " +
                           " ( " +
                           " Select CompanyID, EmployeeID, ItemID, CASE When ItemID = 39 then 'Expense' When ItemID = 29 then 'Deduction' else 'Salary' end as DistributionType, Amount from  " +
                           " ( " +
                           " Select CompanyID, EmployeeID, ItemID = Case When ItemID = 38 then 39 When ItemID = 21 then 29 else 104 end, " +
                           " EditedAmount  as Amount from dbo.t_HRPayroll a, dbo.t_HRPayrollItem b Where a.PayrollID=b.PayrollID and a.PayrollID=" + nPayrollID + " " +
                           " and ItemID IN (21,25,38,42) " +
                           " )x " +
                           " )z " +

                           " UNION ALL " +

                           " Select a.CompanyID, EmployeeID, 105 as ItemID, 'Salary' as DistributionType, " +
                           " EditedAmount as Amount from dbo.t_HRPayroll a, dbo.t_HRPayrollItem b, dbo.t_HRAllowanceDeduction c " +
                           " Where a.PayrollID=b.PayrollID  and b.ItemID=c.ID  " +
                           " and a.PayrollID= " + nPayrollID + " and b.ItemID = 17  " +

                           " UNION ALL  " +
                           " Select a.CompanyID, EmployeeID, 106 as ItemID, 'Deduction' as DistributionType,  " +
                           " EditedAmount *-1 as Amount from dbo.t_HRPayroll a, dbo.t_HRPayrollItem b, dbo.t_HRAllowanceDeduction c " +
                           " Where a.PayrollID=b.PayrollID  and b.ItemID=c.ID  " +
                           " and a.PayrollID= " + nPayrollID + " and b.ItemID = 17  " +

                           " UNION ALL " +
                           " Select CompanyID, x.EmployeeID, AllownaceID, 'Deduction' as DistributionType, Amount " +
                           " from  " +
                           " ( " +
                           " Select CompanyID,  EmployeeID, a.LoanID, 35 as AllownaceID, 'BuildingPrincipal' as AllowanceDes, (PrincipalPayable * -1) as Amount  from t_HRLoan a, t_HRLoanDetail b   " +
                           " Where a.LoanID=b.LoanID  and LoanTypeID = 2 and Month(PaymentDate) =  " + nMonth + "  and Year (PaymentDate) = " + nYear + "  and IsEarlyClose= 0 and CompanyID = " + nCompanyID + " " +
                           " UNION ALL " +
                           " Select CompanyID, EmployeeID,a.LoanID, 103 as AllownaceID, 'BuildingInterest' as AllowanceDes, (InterestPayable * -1) as Amount  from t_HRLoan a, t_HRLoanDetail b   " +
                           " Where a.LoanID=b.LoanID  and LoanTypeID = 2 and Month(PaymentDate) =  " + nMonth + "  and Year (PaymentDate) = " + nYear + "  and IsEarlyClose= 0 and CompanyID = " + nCompanyID + " " +
                           " UNION ALL " +
                           " Select CompanyID, EmployeeID,a.LoanID, 18 as AllownaceID, 'PFPrincipal' as AllowanceDes, (PrincipalPayable * -1) as Amount  from t_HRLoan a, t_HRLoanDetail b   " +
                           " Where a.LoanID=b.LoanID  and LoanTypeID = 5 and Month(PaymentDate) =  " + nMonth + "  and Year (PaymentDate) = " + nYear + "  and IsEarlyClose= 0 and CompanyID = " + nCompanyID + " " +
                           " UNION ALL " +
                           " Select CompanyID, EmployeeID,a.LoanID, 101 as AllownaceID, 'PFInterest' as AllowanceDes, (InterestPayable * -1) as Amount  from t_HRLoan a, t_HRLoanDetail b   " +
                           " Where a.LoanID=b.LoanID  and LoanTypeID = 5 and Month(PaymentDate) =  " + nMonth + "  and Year (PaymentDate) = " + nYear + "  and IsEarlyClose= 0 and CompanyID = " + nCompanyID + " " +
                           " ) as x, (Select distinct EmployeeID from dbo.t_HRPayrollItem Where PayrollID=" + nPayrollID + " ) y where x.EmployeeID=y.EmployeeID and Amount != 0 " +
                           " ) as Final Group by CompanyID, EmployeeID, ItemID, DistributionType)b " +
                           " ON a.CompanyID = b.CompanyID and a.EmployeeID=b.EmployeeID and a.CJAllowanceID = b.ItemID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayrollItem oHRPayrollItem = new HRPayrollItem();

                    oHRPayrollItem.CompanyID = (int)reader["CompanyID"];
                    oHRPayrollItem.VendorID = (string)reader["VendorID"];
                    oHRPayrollItem.VendorName = (string)reader["VendorName"];
                    oHRPayrollItem.VendorType = (string)reader["VendorType"];
                    oHRPayrollItem.DistributionSet = (string)reader["DistributionSet"];
                    oHRPayrollItem.DistributionID = (string)reader["DistributionID"];
                    oHRPayrollItem.DristributionDes = (string)reader["DristributionDesc"];
                    oHRPayrollItem.EditedAmount = Convert.ToDouble(reader["Amount"].ToString());
                    oHRPayrollItem.DistributionType = (string)reader["DistributionType"];

                    InnerList.Add(oHRPayrollItem);
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
    
    public class HRPayrolls : CollectionBase
    {
        public HRPayroll this[int i]
        {
            get { return (HRPayroll)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRPayroll oHRPayroll)
        {
            InnerList.Add(oHRPayroll);
        }
        public int GetIndex(int nPayrollID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].PayrollID == nPayrollID)
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
            string sSql = "SELECT * FROM t_HRPayroll ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayroll oHRPayroll = new HRPayroll();
                    oHRPayroll.PayrollID = (int)reader["PayrollID"];
                    oHRPayroll.CompanyID = (int)reader["CompanyID"];
                    oHRPayroll.TMonth = (int)reader["TMonth"];
                    oHRPayroll.TYear = (int)reader["TYear"];
                    oHRPayroll.Type = (int)reader["Type"];
                    oHRPayroll.Status = (int)reader["Status"];
                    oHRPayroll.Description = (string)reader["Description"];
                    oHRPayroll.CreateUserID = (int)reader["CreateUserID"];
                    oHRPayroll.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRPayroll.UpdateUserID = (int)reader["UpdateUserID"];
                    oHRPayroll.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    
                    InnerList.Add(oHRPayroll);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshData(int nCompanyID, int nStatus, int nMonth, int nYear, int nType, string sCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select a.*, x.UserName as VerifiedUser, y.UserName as ApprovedUser from  " +
                          " ( " +
                          " Select PayrollID, Code, c.CompanyID, CompanyCode, CompanyName, TMonth, TYear, Type, c.Description, Status,  " +
                          " NoOfEmployee, GrossSalary, Deduction,  NetSalary, Expense, Subsidy, TotalSalary, UserName, CreateDate, VerifiedBy,  " +
                          " VerifiedDate, ApproveBy, ApproveDate from  t_HRPayroll c, t_user d, t_Company e " +
                          " Where  c.CreateUserID=d.UserID and c.CompanyID=e.CompanyID and TMonth = " + nMonth + " and TYear = " + nYear + " " +
                          " )a Left Outer JOIN t_user x ON x.UserID=a.VerifiedBy Left Outer JOIN t_user y ON y.UserID=a.ApproveBy Where 1=1 ";

            if (nCompanyID == 0)
            {
                sSql = sSql + " and CompanyID IN (Select DataID from dbo.t_UserPermissionData Where DataType='Company' and UserID=" + Utility.UserId + ") ";
            }
            else
            {
                sSql = sSql + " and CompanyID = " + nCompanyID + " ";
            }
            if (nStatus > 0)
            {
                sSql = sSql + " and Status = " + nStatus + " ";
            }
            if (nType > 0)
            {
                sSql = sSql + " and Type = " + nType + " ";
            }
            if (sCode != "")
            {
                sSql = sSql + " and Code = '" + sCode + "' ";
            }
            sSql = sSql + " Order by PayrollID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayroll oHRPayroll = new HRPayroll();

                    oHRPayroll.PayrollID = (int)reader["PayrollID"];
                    oHRPayroll.Code = (string)reader["Code"];
                    oHRPayroll.CompanyID = (int)reader["CompanyID"];
                    oHRPayroll.CompanyCode = (string)reader["CompanyCode"];
                    oHRPayroll.CompanyName = (string)reader["CompanyName"];
                    oHRPayroll.TMonth = (int)reader["TMonth"];
                    oHRPayroll.TYear = (int)reader["TYear"];
                    oHRPayroll.Type = (int)reader["Type"];
                    oHRPayroll.Status = (int)reader["Status"];
                    oHRPayroll.Description = (string)reader["Description"];
                    oHRPayroll.NoOfEmpl = (int)reader["NoOfEmployee"];
                    oHRPayroll.GrossSalary = (double)reader["GrossSalary"];
                    oHRPayroll.Deduct = (double)reader["Deduction"];
                    oHRPayroll.NetSalary = (double)reader["NetSalary"];
                    oHRPayroll.Expense = (double)reader["Expense"];
                    oHRPayroll.Subsidy = (double)reader["Subsidy"];
                    oHRPayroll.TotalSalary = (double)reader["TotalSalary"];
                    oHRPayroll.UserName = (string)reader["UserName"];
                    oHRPayroll.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["VerifiedUser"] != DBNull.Value)
                        oHRPayroll.VerifiedUserName = (string)reader["VerifiedUser"];
                    else oHRPayroll.VerifiedUserName = "";
                    oHRPayroll.VerifiedDate = reader["VerifiedDate"];
                    if (reader["ApprovedUser"] != DBNull.Value)
                        oHRPayroll.ApproveUserName = (string)reader["ApprovedUser"];
                    else oHRPayroll.ApproveUserName = "";
                    oHRPayroll.ApproveDate = reader["ApproveDate"];

                    oHRPayroll.RefreshPayrollItem();

                    InnerList.Add(oHRPayroll);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool GetUnmapEmployee(int nPayrollID, int nCompanyID)
        {
            InnerList.Clear();
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select a.EmployeeCode, EmployeeName, DepartmentName, DesignationName from "+
                          " (Select distinct a.EmployeeID, EmployeeCode, EmployeeName, DepartmentName, DesignationName   "+
                          " from dbo.t_HRPayrollItem a, v_EmployeeDetails b Where a.EmployeeID=b.EmployeeID and PayrollID = " + nPayrollID + ") a " +
                          " Left Outer JOIN ";
            if (nCompanyID == (int)Dictionary.CompanyID.BLL)
            {
                sSql += " dbo.t_MapERPHREmployeeDistributionSet b ";
            }
            else if (nCompanyID == (int)Dictionary.CompanyID.BEIL)
            {
                sSql += " dbo.t_MapERPBEILHREmployeeDistributionSet b ";
            }
            sSql += " ON a.EmployeeCode=b.EmployeeCode where DistributionSet is null Order by DepartmentName ";

           

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayroll oHRPayroll = new HRPayroll();

                    oHRPayroll.EmployeeCode = (string)reader["EmployeeCode"];
                    oHRPayroll.EmployeeName = (string)reader["EmployeeName"];
                    oHRPayroll.DepartmrntName = (string)reader["DepartmentName"];
                    oHRPayroll.DesignationName = (string)reader["DesignationName"];

                    InnerList.Add(oHRPayroll);
                    nCount++;
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool GetPostPayrollID()
        {
            InnerList.Clear();
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select a.PayrollID from t_HRPayroll a, (Select distinct PayrollID from dbo.t_MapERPHRPayroll Where Status = 1) b  " +
                          " Where Status=4 and a.PayrollID =  b.PayrollID ";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayroll oHRPayroll = new HRPayroll();

                    oHRPayroll.PayrollID = (int)reader["PayrollID"];

                    InnerList.Add(oHRPayroll);
                    nCount++;
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}


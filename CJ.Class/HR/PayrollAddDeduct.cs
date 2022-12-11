// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Jul 24, 2016
// Time : 10:12 AM
// Description: Class for HRPayrollAddDeduct.
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
using CJ.Class;

namespace CJ.Class.HR
{
    public class HRPayrollAddDeduct
    {
        private int _nID;
        private int _nCompanyID;
        private int _nEmployeeID;
        private int _nMonth;
        private int _nYear;
        private int _nAllowanceID;
        private string _sAllowanceName;
        private double _Amount;
        private int _nType;
        private string _sRemarks;
        private int _nStatus;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;


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
        // Get set property for EmployeeID
        // </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        // <summary>
        // Get set property for Month
        // </summary>
        public int Month
        {
            get { return _nMonth; }
            set { _nMonth = value; }
        }

        // <summary>
        // Get set property for Year
        // </summary>
        public int Year
        {
            get { return _nYear; }
            set { _nYear = value; }
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
        // Get set property for Allowance Name
        // </summary>
        public string AllowanceName
        {
            get { return _sAllowanceName; }
            set { _sAllowanceName = value; }
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
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
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
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
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

        private string _sCompanyCode;
        public string CompanyCode
        {
            get { return _sCompanyCode; }
            set { _sCompanyCode = value; }
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
        private object _nApproveBy;
        public object ApproveBy
        {
            get { return _nApproveBy; }
            set { _nApproveBy = value; }
        }

        private object _ApproveDate;
        public object ApproveDate
        {
            get { return _ApproveDate; }
            set { _ApproveDate = value; }
        }
        private string _sCreateUser;
        public string CreateUser
        {
            get { return _sCreateUser; }
            set { _sCreateUser = value; }
        }
        private string _sApproveUser;
        public string ApproveUser
        {
            get { return _sApproveUser; }
            set { _sApproveUser = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRPayrollAddDeduct";
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
                sSql = "INSERT INTO t_HRPayrollAddDeduct (ID, CompanyID, EmployeeID, Month, Year, AllowanceID, Amount, Type, Remarks, Status, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Month", _nMonth);
                cmd.Parameters.AddWithValue("Year", _nYear);
                cmd.Parameters.AddWithValue("AllowanceID", _nAllowanceID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddForBulk()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRPayrollAddDeduct";
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
                sSql = "INSERT INTO t_HRPayrollAddDeduct (ID, CompanyID, EmployeeID, Month, Year, AllowanceID, Amount, Type, Remarks, Status, CreateUserID, CreateDate, ApproveBy, ApproveDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Month", _nMonth);
                cmd.Parameters.AddWithValue("Year", _nYear);
                cmd.Parameters.AddWithValue("AllowanceID", _nAllowanceID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                if (_nStatus == (int) Dictionary.PayrollAddDeductStatus.Approve)
                {
                    cmd.Parameters.AddWithValue("ApproveBy", Utility.UserId);
                    cmd.Parameters.AddWithValue("ApproveDate", DateTime.Now);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApproveBy", null);
                    cmd.Parameters.AddWithValue("ApproveDate", null);

                }

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
                sSql = "UPDATE t_HRPayrollAddDeduct SET CompanyID = ?, EmployeeID = ?, Month = ?, Year = ?, AllowanceID = ?, Amount = ?, Type = ?, Remarks = ?, UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Month", _nMonth);
                cmd.Parameters.AddWithValue("Year", _nYear);
                cmd.Parameters.AddWithValue("AllowanceID", _nAllowanceID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Type", _nType);
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
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_HRPayrollAddDeduct WHERE [ID]=?";
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

        public void Approve()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_HRPayrollAddDeduct SET Status=?, ApproveBy=?, ApproveDate=? WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApproveBy", _nApproveBy);
                cmd.Parameters.AddWithValue("ApproveDate", _ApproveDate);

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
                cmd.CommandText = "SELECT * FROM t_HRPayrollAddDeduct where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nMonth = (int)reader["Month"];
                    _nYear = (int)reader["Year"];
                    _nAllowanceID = (int)reader["AllowanceID"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nType = (int)reader["Type"];
                    _sRemarks = (string)reader["Remarks"];
                    _nStatus = (int)reader["Status"];
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

        public double GetAmount(int nCompanyID, int nEmployeeID, int nMonth, int nYear, int nType, bool IsNightShift)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Amount = 0;
            try
            {
                string sSql = "";

                sSql = " select Sum(Amount) as Amount from t_HRPayrollAddDeduct Where Status = " + (int)Dictionary.PayrollAddDeductStatus.Approve + " and Month=" + nMonth + " " +
                                  " and Year=" + nYear + " and Type=" + nType + " and CompanyID=" + nCompanyID + " and EmployeeID=" + nEmployeeID + " ";
                if (IsNightShift)
                {
                    sSql = sSql + " and AllowanceID = " + (int)Dictionary.HREmployeeAllowance.NightShiftAllowance + " ";
                }
                else
                {
                    sSql = sSql + " and AllowanceID != " + (int)Dictionary.HREmployeeAllowance.NightShiftAllowance + " ";
                }

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Amount"] != DBNull.Value)
                    {
                        _Amount = Convert.ToDouble(reader["Amount"].ToString());
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

        public string GetNotes(int nMonth, int nYear, int nEmployeeID, int nCompanyID)
        {
            string sNote = "";
            string sPrefix = "";
            TELLib _oTELLib = new TELLib();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select Type, Amount, Remarks from dbo.t_HRPayrollAddDeduct Where Month=" + nMonth + " and Year = " + nYear + " and EmployeeID = " + nEmployeeID + " " +
                          " and CompanyID=" + nCompanyID + " and AllowanceID != " + (int)Dictionary.HREmployeeAllowance.NightShiftAllowance + " and Status=" + (int)Dictionary.PayrollAddDeductStatus.Approve + " Order by ID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                   string _Taka = _oTELLib.TakaFormat(_Amount);
                   _Taka = ExcludeDecimal(_Taka);
                    _nType = (int)reader["Type"];
                   string _sType = Enum.GetName(typeof(Dictionary.AllowanceDeductionType), _nType);
                    _sRemarks = (string)reader["Remarks"];

                    if (sNote != "")
                    {
                        sPrefix = " | ";
                    }
                    else
                    {
                        sPrefix = "Note: ";
                    }

                    sNote = sNote + "" + sPrefix + "" + _sType + " Tk." + _Taka + "/= for " + _sRemarks + " ";
                }
                reader.Close();
             
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sNote;
        }

        private string ExcludeDecimal(string sAmount)
        {
            string sResult = "";
            sResult = sAmount.Remove(sAmount.Length - 3);
            return sResult;
        }
    }
    public class HRPayrollAddDeducts : CollectionBase
    {
        public HRPayrollAddDeduct this[int i]
        {
            get { return (HRPayrollAddDeduct)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRPayrollAddDeduct oHRPayrollAddDeduct)
        {
            InnerList.Add(oHRPayrollAddDeduct);
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
        public void Refresh(int nCompanyID, int nEmployeeID, int nMonth, int nYear, int nStatus, bool bIsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select ID, a.CompanyID, CompanyCode, Month, Year, AllowanceID, Type, CASE When AllowanceID = " + (int)Dictionary.HREmployeeAllowance.NightShiftAllowance + " then 'Night Shift' else 'Others' end as AllowanceName, Amount, Remarks, Status, a.EmployeeID, EmployeeCode, EmployeeName, " +
                          " d.UserFullName as CreateUser, CreateDate, e.UserFullName as ApproveUser, ApproveDate " +
                          " from dbo.t_HRPayrollAddDeduct a INNER JOIN t_Employee b " +
                          " ON a.EmployeeID=b.EmployeeID " +
                          " INNER JOIN t_Company c ON a.CompanyID=c.CompanyID " +
                          " INNER JOIN t_User d ON a.CreateUserID=d.UserID " +
                          " Left Outer JOIN t_User e ON a.ApproveBy=e.UserID Where 1=1 ";
         
            if (nCompanyID == 0)
            {
                sSql = sSql + " and a.CompanyID IN (Select DataID from dbo.t_UserPermissionData Where DataType='Company' and UserID=" + Utility.UserId + ") ";
            }
            else
            {
                sSql = sSql + " and a.CompanyID = " + nCompanyID + " ";
            }

            if (nEmployeeID != 0)
            {
                sSql = sSql + " and a.EmployeeID=" + nEmployeeID + " ";
            }
            if (!bIsCheck)
            {
                sSql = sSql + " and Month=" + nMonth + " and Year=" + nYear + " ";
            }
            if (nStatus != 0)
            {
                sSql = sSql + " and Status=" + nStatus + " ";
            }
            sSql = sSql + " Order by ID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayrollAddDeduct oHRPayrollAddDeduct = new HRPayrollAddDeduct();
                    
                    oHRPayrollAddDeduct.ID = (int)reader["ID"];
                    oHRPayrollAddDeduct.CompanyID = (int)reader["CompanyID"];
                    oHRPayrollAddDeduct.CompanyCode = (string)reader["CompanyCode"];
                    oHRPayrollAddDeduct.EmployeeID = (int)reader["EmployeeID"];
                    oHRPayrollAddDeduct.EmployeeCode = (string)reader["EmployeeCode"];
                    oHRPayrollAddDeduct.EmployeeName = (string)reader["EmployeeName"];
                    oHRPayrollAddDeduct.Month = (int)reader["Month"];
                    oHRPayrollAddDeduct.Year = (int)reader["Year"];
                    oHRPayrollAddDeduct.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oHRPayrollAddDeduct.Type = (int)reader["Type"];
                    oHRPayrollAddDeduct.AllowanceID = (int)reader["AllowanceID"];
                    oHRPayrollAddDeduct.AllowanceName = (string)reader["AllowanceName"];
                    oHRPayrollAddDeduct.Remarks = (string)reader["Remarks"];
                    oHRPayrollAddDeduct.Status = (int)reader["Status"];
                    oHRPayrollAddDeduct.CreateUser = (string)reader["CreateUser"];
                    oHRPayrollAddDeduct.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["ApproveUser"] != DBNull.Value)
                    {
                        oHRPayrollAddDeduct.ApproveUser = (string)reader["ApproveUser"];
                    }
                    else
                    {
                        oHRPayrollAddDeduct.ApproveUser = "";
                    }
                    if (reader["ApproveDate"] != DBNull.Value)
                    {
                        oHRPayrollAddDeduct.ApproveDate = Convert.ToDateTime(reader["ApproveDate"].ToString());
                    }
                    else
                    {
                        oHRPayrollAddDeduct.ApproveDate = null;
                    }

                    InnerList.Add(oHRPayrollAddDeduct);
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


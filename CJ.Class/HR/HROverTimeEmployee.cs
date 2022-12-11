// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Sep 03, 2019
// Time : 02:13 PM
// Description: Class for HROverTimeEmployeedetails.
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
    public class HROverTimeEmployeedetails
    {
        private int _nID;
        private int _nOverTimeID;
        private int _nEmployeeID;
        private int _nCompanyID;
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private string _sDescription;
        private DateTime _dOvertimeDate;
        private DateTime _dCreateDate;
        private string _sDepartmentName;
        private string _sDesignationName;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for OverTimeID
        // </summary>
        public int OverTimeID
        {
            get { return _nOverTimeID; }
            set { _nOverTimeID = value; }
        }
        public DateTime OvertimeDate
        {
            get { return _dOvertimeDate; }
            set { _dOvertimeDate = value; }
        }
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        // <summary>
        // Get set property for EmployeeID
        // </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value.Trim(); }
        }
        public string DesignationName
        {
            get { return _sDesignationName; }
            set { _sDesignationName = value.Trim(); }
        }
        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        public void Add(int _nOverTimeID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HROverTimeEmployeedetails";
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
                sSql = "INSERT INTO t_HROverTimeEmployeedetails (ID,OverTimeID, EmployeeID) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);

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
                sSql = "UPDATE t_HROverTimeEmployeedetails SET OverTimeID = ?, EmployeeID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);

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
                sSql = "DELETE FROM t_HROverTimeEmployeedetails WHERE [ID]=?";
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
        public void DeleteByEmployeeOvertime(int _nOverTimeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_HROverTimeEmployeedetails WHERE OverTimeID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
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
                cmd.CommandText = "SELECT * FROM t_HROverTimeEmployeedetails where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nOverTimeID = (int)reader["OverTimeID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByHROverTimeDetails(int _nOverTimeID )
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_HROverTimeEmployeedetails where OverTimeID =?";
                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nOverTimeID = (int)reader["OverTimeID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class HROverTimeEmployee : CollectionBase
    {
        public HROverTimeEmployeedetails this[int i]
        {
            get { return (HROverTimeEmployeedetails)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HROverTimeEmployeedetails oHROverTimeEmployeedetails)
        {
            InnerList.Add(oHROverTimeEmployeedetails);
        }
        private int _nOverTimeID;
        private int _nEmployeeID;
        private int _nCompanyID;
        private string _sDescription;
        private DateTime _dOvertimeDate;
        private int _nStatus;
        private int _nCreateUser;
        private DateTime _dCreateDate;
        private int _nApprovedUser;
        private DateTime _dApprovedDate;
        private string _sCompanyName;
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private string _sDepartmentName;
        private string _sDesignationName;


        // <summary>
        // Get set property for OverTimeID
        // </summary>
        public int OverTimeID
        {
            get { return _nOverTimeID; }
            set { _nOverTimeID = value; }
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
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value.Trim(); }
        }
        public string DesignationName
        {
            get { return _sDesignationName; }
            set { _sDesignationName = value.Trim(); }
        }

        // <summary>
        // Get set property for OvertimeDate
        // </summary>
        public DateTime OvertimeDate
        {
            get { return _dOvertimeDate; }
            set { _dOvertimeDate = value; }
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
        // Get set property for CreateUser
        // </summary>
        public int CreateUser
        {
            get { return _nCreateUser; }
            set { _nCreateUser = value; }
        }

        public int ApprovedUser
        {
            get { return _nApprovedUser; }
            set { _nApprovedUser = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public DateTime ApprovedDate
        {
            get { return _dApprovedDate; }
            set { _dApprovedDate = value; }
        }

        public void Add()
        {
            int nMaxOverTimeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OverTimeID]) FROM t_HROverTimeEmployee";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOverTimeID = 1;
                }
                else
                {
                    nMaxOverTimeID = Convert.ToInt32(maxID) + 1;
                }
                _nOverTimeID = nMaxOverTimeID;
                sSql = "INSERT INTO t_HROverTimeEmployee (OverTimeID,CompanyID, Description, OvertimeDate, Status, CreateUser, CreateDate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
                //cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("OvertimeDate", _dOvertimeDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUser", _nCreateUser);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                foreach (HROverTimeEmployeedetails oHROverTimeEmployeedetails in this)
                {
                    oHROverTimeEmployeedetails.Add(_nOverTimeID);
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
                sSql = "UPDATE t_HROverTimeEmployee SET CompanyID = ?, Description = ?, OvertimeDate = ?, Status = ? WHERE OverTimeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("OvertimeDate", _dOvertimeDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                foreach (HROverTimeEmployeedetails oHROverTimeEmployeedetails in this)
                {
                    oHROverTimeEmployeedetails.Add(_nOverTimeID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Approved()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_HROverTimeEmployee SET Status = 2, ApprovedUser = ?, ApprovedDate = ? WHERE OverTimeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ApprovedUser", _nApprovedUser);
                cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);

                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);

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
                sSql = "DELETE FROM t_HROverTimeEmployee WHERE [OverTimeID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteByHROverTime(int _nOverTimeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_HROverTimeEmployee WHERE OverTimeID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //foreach (HROverTimeEmployeedetails oHROverTimeEmployeedetails in this)
                //{
                //    oHROverTimeEmployeedetails.DeleteByEmployeeOvertime(_nOverTimeID);
                //}
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
                cmd.CommandText = "SELECT * FROM t_HROverTimeEmployee where OverTimeID =?";
                cmd.Parameters.AddWithValue("OverTimeID", _nOverTimeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOverTimeID = (int)reader["OverTimeID"];                    
                    _nCompanyID = (int)reader["CompanyID"];
                    _sDescription = (string)reader["Description"];
                    _dOvertimeDate = Convert.ToDateTime(reader["OvertimeDate"].ToString());
                    _nStatus = (int)reader["Status"];
                    _nCreateUser = (int)reader["CreateUser"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class HROverTimeEmployees : CollectionBase
    {
        public HROverTimeEmployee this[int i]
        {
            get { return (HROverTimeEmployee)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HROverTimeEmployee oHROverTimeEmployee)
        {
            InnerList.Add(oHROverTimeEmployee);
        }
        public int GetIndex(int nOverTimeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OverTimeID == nOverTimeID)
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
            string sSql = "SELECT * FROM t_HROverTimeEmployee";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HROverTimeEmployee oHROverTimeEmployee = new HROverTimeEmployee();
                    oHROverTimeEmployee.OverTimeID = (int)reader["OverTimeID"];
                    oHROverTimeEmployee.CompanyID = (int)reader["CompanyID"];
                    oHROverTimeEmployee.Description = (string)reader["Description"];
                    oHROverTimeEmployee.OvertimeDate = Convert.ToDateTime(reader["OvertimeDate"].ToString());
                    oHROverTimeEmployee.Status = (int)reader["Status"];
                    oHROverTimeEmployee.CreateUser = (int)reader["CreateUser"];
                    oHROverTimeEmployee.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oHROverTimeEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByOverTimeEmployee(int nCompanyID, int nStatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from(Select * from t_HROverTimeEmployee)a Left Outer Join(Select * from t_Company a)b on a.CompanyID=b.CompanyID Where 1=1";
            if (nCompanyID == 0)
            {
                sSql = sSql + " and a.CompanyID IN (Select DataID from dbo.t_UserPermissionData Where DataType='Company' and UserID=" + Utility.UserId + ") ";
            }
            else
            {
                sSql = sSql + " and a.CompanyID = " + nCompanyID + " ";
            }
            if (nStatus > 0)
            {
                sSql = sSql + " and Status = " + nStatus + " ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HROverTimeEmployee oHROverTimeEmployee = new HROverTimeEmployee();
                    oHROverTimeEmployee.OverTimeID = (int)reader["OverTimeID"];
                    oHROverTimeEmployee.CompanyID = (int)reader["CompanyID"];
                    oHROverTimeEmployee.Description = (string)reader["Description"];
                    oHROverTimeEmployee.OvertimeDate = Convert.ToDateTime(reader["OvertimeDate"].ToString());
                    oHROverTimeEmployee.Status = (int)reader["Status"];
                    oHROverTimeEmployee.CreateUser = (int)reader["CreateUser"];
                    oHROverTimeEmployee.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHROverTimeEmployee.CompanyName= (string)reader["CompanyName"];
                    InnerList.Add(oHROverTimeEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByOverTimeEmployeedetails(int nOverTimeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_HROverTimeEmployeedetails a,t_Employee b where a.EmployeeID=b.EmployeeID and OverTimeID="+nOverTimeID+"";
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HROverTimeEmployee oHROverTimeEmployee = new HROverTimeEmployee();
                    oHROverTimeEmployee.OverTimeID = (int)reader["OverTimeID"];
                    oHROverTimeEmployee.EmployeeID = (int)reader["EmployeeID"];
                    oHROverTimeEmployee.EmployeeCode = (string)reader["EmployeeCode"];
                    oHROverTimeEmployee.EmployeeName = (string)reader["EmployeeName"];

                    InnerList.Add(oHROverTimeEmployee);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void PrintByOverTimeEmployeedetails(int nOverTimeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_HROverTimeEmployee a,t_HROverTimeEmployeedetails b,v_EmployeeDetails c where a.OverTimeID=b.OverTimeID and b.EmployeeID=c.EmployeeID and a.OverTimeID="+nOverTimeID+"";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HROverTimeEmployeedetails oHROverTimeEmployee = new HROverTimeEmployeedetails();
                    oHROverTimeEmployee.OverTimeID = (int)reader["OverTimeID"];
                    oHROverTimeEmployee.EmployeeID = (int)reader["EmployeeID"];
                    oHROverTimeEmployee.EmployeeCode = (string)reader["EmployeeCode"];
                    oHROverTimeEmployee.EmployeeName = (string)reader["EmployeeName"];
                    oHROverTimeEmployee.Description= (string)reader["Description"];
                    oHROverTimeEmployee.DepartmentName= (string)reader["DepartmentName"];
                    oHROverTimeEmployee.DesignationName = (string)reader["DesignationName"];
                    oHROverTimeEmployee.OvertimeDate = Convert.ToDateTime(reader["OvertimeDate"].ToString());
                    oHROverTimeEmployee.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oHROverTimeEmployee);
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


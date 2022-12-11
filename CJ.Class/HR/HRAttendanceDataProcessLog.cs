// <summary>
// Company: Transcom Electronics Limited
// Author: Zahid Hasan
// Date: May 24, 2021
// Time : 05:18 PM
// Description: Class for HRAttendanceDataProcessLog.
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
    public class HRAttendanceDataProcessLog
    {
        private int _nId;
        private int _nLogType;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private string _sCompany;
        private string _sOnlyFactory;
        private string _sDepartment;
        private string _sLogShift;
        private int _nEmployeeId;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private string _sUserFullName;
        private string _sEmployeeName;


        // <summary>
        // Get set property for Id
        // </summary>
        public int Id
        {
            get { return _nId; }
            set { _nId = value; }
        }

        // <summary>
        // Get set property for LogType
        // </summary>
        public int LogType
        {
            get { return _nLogType; }
            set { _nLogType = value; }
        }

        // <summary>
        // Get set property for FromDate
        // </summary>
        public DateTime FromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; }
        }

        // <summary>
        // Get set property for ToDate
        // </summary>
        public DateTime ToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; }
        }

        // <summary>
        // Get set property for Company
        // </summary>
        public string Company
        {
            get { return _sCompany; }
            set { _sCompany = value.Trim(); }
        }

        // <summary>
        // Get set property for OnlyFactory
        // </summary>
        public string OnlyFactory
        {
            get { return _sOnlyFactory; }
            set { _sOnlyFactory = value.Trim(); }
        }

        // <summary>
        // Get set property for Department
        // </summary>
        public string Department
        {
            get { return _sDepartment; }
            set { _sDepartment = value.Trim(); }
        }

        // <summary>
        // Get set property for LogShift
        // </summary>
        public string LogShift
        {
            get { return _sLogShift; }
            set { _sLogShift = value.Trim(); }
        }

        // <summary>
        // Get set property for Employee
        // </summary>
        public int EmployeeId
        {
            get { return _nEmployeeId; }
            set { _nEmployeeId = value; }
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
        // Get set property for UserFullName
        // </summary>
        public string UserFullName
        {
            get { return _sUserFullName; }
            set { _sUserFullName = value; }
        }
        // <summary>
        // Get set property for UserFullName
        // </summary>
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public void Add(string sSystem)
        {
            int nMaxId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([Id]) FROM t_HRAttendanceDataProcessLog";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxId = 1;
                }
                else
                {
                    nMaxId = Convert.ToInt32(maxID) + 1;
                }
                _nId = nMaxId;
                sSql = "INSERT INTO t_HRAttendanceDataProcessLog (Id, LogType, FromDate, ToDate, Company, OnlyFactory, Department, LogShift, EmployeeId, CreateUserID, CreateDate, System) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Id", _nId);
                cmd.Parameters.AddWithValue("LogType", _nLogType);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Company", _sCompany);
                cmd.Parameters.AddWithValue("OnlyFactory", _sOnlyFactory);
                cmd.Parameters.AddWithValue("Department", _sDepartment);
                cmd.Parameters.AddWithValue("LogShift", _sLogShift);
                cmd.Parameters.AddWithValue("EmployeeId", _nEmployeeId);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("System", sSystem);

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
                sSql = "UPDATE t_HRAttendanceDataProcessLog SET LogType = ?, FromDate = ?, ToDate = ?, Company = ?, OnlyFactory = ?, Department = ?, LogShift = ?, Employee = ?, CreateUserID = ?, CreateDate = ? WHERE Id = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LogType", _nLogType);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Company", _sCompany);
                cmd.Parameters.AddWithValue("OnlyFactory", _sOnlyFactory);
                cmd.Parameters.AddWithValue("Department", _sDepartment);
                cmd.Parameters.AddWithValue("LogShift", _sLogShift);
                cmd.Parameters.AddWithValue("EmployeeId", _nEmployeeId);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("Id", _nId);

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
                sSql = "DELETE FROM t_HRAttendanceDataProcessLog WHERE [Id]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Id", _nId);
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
                cmd.CommandText = "SELECT * FROM t_HRAttendanceDataProcessLog where Id =?";
                cmd.Parameters.AddWithValue("Id", _nId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nId = (int)reader["Id"];
                    _nLogType = (int)reader["LogType"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _sCompany = (string)reader["Company"];
                    _sOnlyFactory = (string)reader["OnlyFactory"];
                    _sDepartment = (string)reader["Department"];
                    _sLogShift = (string)reader["LogShift"];
                    _nEmployeeId = (int)reader["EmployeeId"];
                    _nCreateUserID = (int)reader["CreateUserID"];
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
    public class HRAttendanceDataProcessLogs : CollectionBase
    {
        public HRAttendanceDataProcessLog this[int i]
        {
            get { return (HRAttendanceDataProcessLog)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRAttendanceDataProcessLog oHRAttendanceDataProcessLog)
        {
            InnerList.Add(oHRAttendanceDataProcessLog);
        }
        public int GetIndex(int nId)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].Id == nId)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, int iType)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.*,b.UserFullName, isnull(c.EmployeeName,'') as EmployeeName from t_HRAttendanceDataProcessLog a INNER JOIN t_User b ON a.CreateUserID = b.UserID left outer join t_Employee c ON a.EmployeeId = c.EmployeeID Where CreateDate between '" + dFromDate + "' and '"+ dToDate + "' and CreateDate < '"+ dToDate + "'";
            if (iType > 0)
            {
                sSql += " and LogType=" + iType;
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRAttendanceDataProcessLog oHRAttendanceDataProcessLog = new HRAttendanceDataProcessLog();
                    oHRAttendanceDataProcessLog.Id = (int)reader["Id"];
                    oHRAttendanceDataProcessLog.LogType = (int)reader["LogType"];
                    oHRAttendanceDataProcessLog.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oHRAttendanceDataProcessLog.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oHRAttendanceDataProcessLog.Company = (string)reader["Company"];
                    oHRAttendanceDataProcessLog.OnlyFactory = (string)reader["OnlyFactory"];
                    oHRAttendanceDataProcessLog.Department = (string)reader["Department"];
                    oHRAttendanceDataProcessLog.LogShift = (string)reader["LogShift"];
                    oHRAttendanceDataProcessLog.EmployeeId = (int)reader["EmployeeId"];
                    oHRAttendanceDataProcessLog.CreateUserID = (int)reader["CreateUserID"];
                    oHRAttendanceDataProcessLog.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRAttendanceDataProcessLog.UserFullName = (string)reader["UserFullName"];
                    oHRAttendanceDataProcessLog.EmployeeName = (string)reader["EmployeeName"];
                    InnerList.Add(oHRAttendanceDataProcessLog);
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


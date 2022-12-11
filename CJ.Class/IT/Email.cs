// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 01, 2011
// Time :  12:00 PM
// Description: Class for Email.
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
    public class Email
    {
        private int _nEmailID;
        private DateTime _dCreateDate;
        private string _sEmailAddress;
        private string _sCompanyName;
        private int _nType;
        private bool _bWebAccess;
        private double _nQuota;
        private int _nStatus;

        private object _nEmployeeID;
        private Employee _oEmployee;

        private bool _bReadDB;

        /// <summary>
        /// Get set property for EmailID
        /// </summary>
        public int EmailID
        {
            get { return _nEmailID; }
            set { _nEmailID = value; }
        }

        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        /// <summary>
        /// Get set property for EmailAddress
        /// </summary>
        public string EmailAddress
        {
            get { return _sEmailAddress; }
            set { _sEmailAddress = value.Trim(); }
        }

        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Type
        /// </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }

        /// <summary>
        /// Get set property for WebAccess
        /// </summary>
        public bool WebAccess
        {
            get { return _bWebAccess; }
            set { _bWebAccess = value; }
        }

        /// <summary>
        /// Get set property for Quota
        /// </summary>
        public double Quota
        {
            get { return _nQuota; }
            set { _nQuota = value; }
        }

        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        /// <summary>
        /// Get set property for EmployeeID
        /// </summary>
        public object EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        public Employee Employee
        {
            get
            {
                if (_oEmployee == null && _nEmployeeID != null)
                {
                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = (int)_nEmployeeID;
                    if (_bReadDB) _oEmployee.Refresh();
                }

                return _oEmployee;
            }
        }

        /// <summary>
        /// Get set property for ?
        /// </summary>
        public bool ReadDB
        {
            get { return _bReadDB; }
            set { _bReadDB = value; }
        }

        public void Add()
        {
            int nMaxEmailID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([EmailID]) FROM t_Email";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxEmailID = 1;
                }
                else
                {
                    nMaxEmailID = Convert.ToInt32(maxID) + 1;
                }
                _nEmailID = nMaxEmailID;

                sSql = "INSERT INTO t_Email(EmailID,CreateDate,"
                    + " EmailAddress,Type,WebAccess,Status,Quota,EmployeeID)"
                    + " VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EmailID", _nEmailID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("EmailAddress", _sEmailAddress);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("WebAccess", _bWebAccess);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Quota", _nQuota);
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

                sSql = "UPDATE t_Email SET CreateDate=?, EmailAddress=?, Type=?,"
                    + " WebAccess=?, Status=?, Quota=?, EmployeeID=?"
                    + " WHERE EmailID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("EmailAddress", _sEmailAddress);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("WebAccess", _bWebAccess);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Quota", _nQuota);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("EmailID", _nEmailID);

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
                sSql = "DELETE FROM t_Email WHERE [EmailID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EmailID", _nEmailID);
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
                cmd.CommandText = "SELECT * FROM t_Email where EmailID =?";
                cmd.Parameters.AddWithValue("EmailID", _nEmailID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEmailID = (int)reader["EmailID"];
                    _dCreateDate = (DateTime)reader["CreateDate"];
                    _sEmailAddress = (string)reader["EmailAddress"];
                    _nStatus = (int)reader["Status"];
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
    public class Emails : CollectionBase
    {
        public Email this[int i]
        {
            get { return (Email)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Email oEmail)
        {
            InnerList.Add(oEmail);
        }

        public int GetIndex(int nEmailID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].EmailID == nEmailID)
                {
                    return i;
                }
            }
            return -1;
        }
        //txtName.Text,(Dictionary.GeneralStatus)cboStatus.SelectedIndex
        public void Refresh(string sName,Dictionary.EmailType nEmailType, Dictionary.EmailStatus nEmailStatus,int nCompanyID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            if (nCompanyID != 0)
            {
                sSql = sSql + "select * from t_Email A"
               + " INNER join v_EmployeeDetails B"
               + " on A.EmployeeID=B.EmployeeID  AND CompanyID=" + nCompanyID + " "; 
                
            }
            else
            {
                sSql = sSql + "select * from t_Email A"
                + " left outer join v_EmployeeDetails B"
                + " on A.EmployeeID=B.EmployeeID";
            }

            string sClause = "";

            if (sName != "")
            {
                if (sClause == "") sClause = " WHERE EmailAddress LIKE ?";
                else sClause = sClause + " AND EmailAddress LIKE ?";
                cmd.Parameters.AddWithValue("EmailAddress", "%" + sName + "%");
            }

            if ((int)nEmailType > -1)
            {
                if (sClause == "") sClause = " WHERE Type = ?";
                else sClause = sClause + " AND Type = ?";
                cmd.Parameters.AddWithValue("Type", nEmailType);
            }

            if ((int)nEmailStatus > -1)
            {
                if (sClause == "") sClause = " WHERE Status = ?";
                else sClause = sClause + " AND Status = ?";
                cmd.Parameters.AddWithValue("Status", nEmailStatus);
            }
            //if (sCompanyName != "")
            //{
            //    sSql = sSql + " and CompanyName = '" + sCompanyName + "'";
            //}


            sClause = sClause + " ORDER BY CreateDate Desc";
            cmd.CommandText = sSql + sClause;

            try
            {
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Email oEmail = new Email();

                    oEmail.EmailID = (int)reader["EmailID"];
                    oEmail.CreateDate = (DateTime)reader["CreateDate"];
                    oEmail.EmailAddress = reader["EmailAddress"].ToString();
                    oEmail.Status = (int)reader["Status"];
                    oEmail.CompanyName = reader["CompanyName"].ToString();
                    oEmail.Type = (int)reader["Type"];
                    oEmail.Quota = Convert.ToDouble(reader["Quota"]);
                    oEmail.WebAccess=Convert.ToBoolean(reader["WebAccess"]);
                    if(reader["EmployeeID"] is DBNull)
                    {
                        oEmail.EmployeeID=null;
                    }
                    else
                    {
                        oEmail.EmployeeID=(int)reader["EmployeeID"];
                        oEmail.Employee.EmployeeCode = reader["EmployeeCode"].ToString();
                        oEmail.Employee.EmployeeName = reader["EmployeeName"].ToString();
                        oEmail.Employee.Company.CompanyCode = reader["CompanyCode"].ToString();
                        oEmail.Employee.Company.CompanyName= reader["CompanyName"].ToString();
                        oEmail.Employee.Department.DepartmentName = reader["DepartmentName"].ToString();
                    }
                    InnerList.Add(oEmail);
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


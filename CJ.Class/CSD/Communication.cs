// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Oct 14, 2014
// Time : 10:26 AM
// Description: Class for CSDCommunication.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
    public class Communication
    {
        private int _nCommunicationID;
        private int _nJobID;
        private int _nCallCategory;
        private string _sRemarks;
        private object _dNextCommDate;
        private int _nCreateUserID;
        private string _sUserName;
        private DateTime _dCreateDate;
        private int _nCallType;
        private int _nResponseType;
        private object _nProactiveCallID;




        // <summary>
        // Get set property for UserName
        // </summary>
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }

        // <summary>
        // Get set property for CommunicationID
        // </summary>
        public int CommunicationID
        {
            get { return _nCommunicationID; }
            set { _nCommunicationID = value; }
        }

        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        // <summary>
        // Get set property for CallCategory
        // </summary>
        public int CallCategory
        {
            get { return _nCallCategory; }
            set { _nCallCategory = value; }
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
        // Get set property for NextCommDate
        // </summary>
        public object NextCommDate
        {
            get { return _dNextCommDate; }
            set { _dNextCommDate = value; }
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
        // Get set property for CallType
        // </summary>
        public int CallType
        {
            get { return _nCallType; }
            set { _nCallType = value; }
        }

        // <summary>
        // Get set property for ResponseType
        // </summary>
        public int ResponseType
        {
            get { return _nResponseType; }
            set { _nResponseType = value; }
        }

        // <summary>
        // Get set property for ProactiveCallID
        // </summary>
        public object ProactiveCallID
        {
            get { return _nProactiveCallID; }
            set { _nProactiveCallID = value; }
        }

        public void Add()
        {
            int nMaxCommunicationID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CommunicationID]) FROM t_CSDCommunication";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCommunicationID = 1;
                }
                else
                {
                    nMaxCommunicationID = Convert.ToInt32(maxID) + 1;
                }
                _nCommunicationID = nMaxCommunicationID;
                sSql = "INSERT INTO t_CSDCommunication (CommunicationID, JobID, CallCategory, Remarks, NextCommDate, CreateUserID, CreateDate, CallType, ResponseType, ProactiveCallID) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CommunicationID", _nCommunicationID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("CallCategory", _nCallCategory);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                if (_dNextCommDate != null)
                    cmd.Parameters.AddWithValue("NextCommDate", _dNextCommDate);
                else cmd.Parameters.AddWithValue("NextCommDate", null);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CallType", _nCallType);
                cmd.Parameters.AddWithValue("ResponseType", _nResponseType);
                if (_nProactiveCallID != null)
                    cmd.Parameters.AddWithValue("ProactiveCallID", _nProactiveCallID);
                else cmd.Parameters.AddWithValue("ProactiveCallID", null);

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
                sSql = "DELETE FROM t_CSDCommunication WHERE [CommunicationID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CommunicationID", _nCommunicationID);
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
                cmd.CommandText = "SELECT * FROM t_CSDCommunication where CommunicationID =?";
                cmd.Parameters.AddWithValue("CommunicationID", _nCommunicationID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCommunicationID = (int)reader["CommunicationID"];
                    _nJobID = (int)reader["JobID"];
                    _nCallCategory = (int)reader["CallCategory"];
                    _sRemarks = (string)reader["Remarks"];
                    _dNextCommDate = Convert.ToDateTime(reader["NextCommDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCallType = (int)reader["CallType"];
                    _nResponseType = (int)reader["ResponseType"];
                    _nProactiveCallID = (int)reader["ProactiveCallID"];
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
    public class Communications : CollectionBase
    {
        public Communication this[int i]
        {
            get { return (Communication)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(Communication oCommunication)
        {
            InnerList.Add(oCommunication);
        }
        public int GetIndex(int nCommunicationID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CommunicationID == nCommunicationID)
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
            string sSql = "SELECT * FROM t_CSDCommunication";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Communication oCommunication = new Communication();

                    oCommunication.CommunicationID = (int)reader["CommunicationID"];
                    oCommunication.JobID = (int)reader["JobID"];
                    oCommunication.CallCategory = (int)reader["CallCategory"];
                    oCommunication.Remarks = (string)reader["Remarks"];
                    oCommunication.NextCommDate = Convert.ToDateTime(reader["NextCommDate"].ToString());
                    oCommunication.CreateUserID = (int)reader["CreateUserID"];
                    oCommunication.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCommunication.CallType = (int)reader["CallType"];
                    oCommunication.ResponseType = (int)reader["ResponseType"];
                    oCommunication.ProactiveCallID = (int)reader["ProactiveCallID"];

                    InnerList.Add(oCommunication);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByJobID(int nJobID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDCommunication a INNER JOIN t_User b ON a.CreateUserID = b.UserID WHERE JobID = '" + nJobID + "'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Communication oCommunication = new Communication();

                    oCommunication.CommunicationID = (int)reader["CommunicationID"];
                    oCommunication.JobID = (int)reader["JobID"];
                    oCommunication.CallCategory = (int)reader["CallCategory"];
                    oCommunication.Remarks = (string)reader["Remarks"];
                    if (reader["NextCommDate"] != DBNull.Value)
                    {
                        oCommunication.NextCommDate = Convert.ToDateTime(reader["NextCommDate"].ToString());
                    }                    
                    oCommunication.CreateUserID = (int)reader["CreateUserID"];
                    if (reader["UserName"] != DBNull.Value)
                    {
                        oCommunication.UserName = (string)reader["UserName"];
                    }                    
                    if (reader["CreateDate"] != DBNull.Value)
                    {
                        oCommunication.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    }
                    
                    oCommunication.CallType = (int)reader["CallType"];
                    oCommunication.ResponseType = (int)reader["ResponseType"];
                    if (reader["ProactiveCallID"] != DBNull.Value)
                    {
                        oCommunication.ProactiveCallID = (int)reader["ProactiveCallID"];
                    }                    

                    InnerList.Add(oCommunication);
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


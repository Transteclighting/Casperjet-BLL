// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Aug 29, 2015
// Time : 11:04 AM
// Description: Class for SCMProcessHistory.
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
    public class SCMProcessHistory
    {
        private int _nHistoryID;
        private string _sTableName;
        private int _nDateID;
        private int _nStatusID;
        private int _dExpectedGRDWeek;
        private int _dExpectedGRDYear;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nTranType;


        // <summary>
        // Get set property for HistoryID
        // </summary>
        public int HistoryID
        {
            get { return _nHistoryID; }
            set { _nHistoryID = value; }
        }

        // <summary>
        // Get set property for TableName
        // </summary>
        public string TableName
        {
            get { return _sTableName; }
            set { _sTableName = value.Trim(); }
        }

        // <summary>
        // Get set property for DateID
        // </summary>
        public int DateID
        {
            get { return _nDateID; }
            set { _nDateID = value; }
        }

        // <summary>
        // Get set property for StatusID
        // </summary>
        public int StatusID
        {
            get { return _nStatusID; }
            set { _nStatusID = value; }
        }

        // <summary>
        // Get set property for ExpectedGRDWeek
        // </summary>
        public int ExpectedGRDWeek
        {
            get { return _dExpectedGRDWeek; }
            set { _dExpectedGRDWeek = value; }
        }

        // <summary>
        // Get set property for ExpectedGRDYear
        // </summary>
        public int ExpectedGRDYear
        {
            get { return _dExpectedGRDYear; }
            set { _dExpectedGRDYear = value; }
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
        // Get set property for TranType
        // </summary>
        public int TranType
        {
            get { return _nTranType; }
            set { _nTranType = value; }
        }

        public void Add()
        {
            int nMaxHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([HistoryID]) FROM t_SCMProcessHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxHistoryID = 1;
                }
                else
                {
                    nMaxHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nHistoryID = nMaxHistoryID;
                sSql = "INSERT INTO t_SCMProcessHistory (HistoryID, TableName, DateID, StatusID, ExpectedGRDWeek, ExpectedGRDYear, Remarks, CreateUserID, CreateDate, TranType) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.Parameters.AddWithValue("TableName", _sTableName);
                cmd.Parameters.AddWithValue("DateID", _nDateID);
                cmd.Parameters.AddWithValue("StatusID", _nStatusID);
                cmd.Parameters.AddWithValue("ExpectedGRDWeek", _dExpectedGRDWeek);
                cmd.Parameters.AddWithValue("ExpectedGRDYear", _dExpectedGRDYear);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                

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
                sSql = "UPDATE t_SCMProcessHistory SET TableName = ?, DateID = ?, StatusID = ?, ExpectedGRDWeek = ?,ExpectedGRDYear = ?, Remarks = ?, CreateUserID = ?, CreateDate = ? WHERE HistoryID = ?, TranType = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TableName", _sTableName);
                cmd.Parameters.AddWithValue("DateID", _nDateID);
                cmd.Parameters.AddWithValue("StatusID", _nStatusID);
                cmd.Parameters.AddWithValue("ExpectedGRDWeek", _dExpectedGRDWeek);
                cmd.Parameters.AddWithValue("ExpectedGRDYear", _dExpectedGRDYear);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                
                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);

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
                sSql = "DELETE FROM t_SCMProcessHistory WHERE [HistoryID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
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
                cmd.CommandText = "SELECT * FROM t_SCMProcessHistory where HistoryID =?";
                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nHistoryID = (int)reader["HistoryID"];
                    _sTableName = (string)reader["TableName"];
                    _nDateID = (int)reader["DateID"];
                    _nStatusID = (int)reader["StatusID"];
                    _dExpectedGRDWeek = (int)reader["ExpectedGRDWeek"];
                    _dExpectedGRDYear = (int)reader["ExpectedGRDYear"];
                    _sRemarks = (string)reader["Remarks"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nTranType = (int)reader["TranType"];
                    
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
    public class SCMProcessHistorys : CollectionBase
    {
        public SCMProcessHistory this[int i]
        {
            get { return (SCMProcessHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMProcessHistory oSCMProcessHistory)
        {
            InnerList.Add(oSCMProcessHistory);
        }
        public int GetIndex(int nHistoryID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].HistoryID == nHistoryID)
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
            string sSql = "SELECT * FROM t_SCMProcessHistory";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                    oSCMProcessHistory.HistoryID = (int)reader["HistoryID"];
                    oSCMProcessHistory.TableName = (string)reader["TableName"];
                    oSCMProcessHistory.DateID = (int)reader["DateID"];
                    oSCMProcessHistory.StatusID = (int)reader["StatusID"];
                    oSCMProcessHistory.ExpectedGRDWeek = (int)reader["ExpectedGRDWeek"];
                    oSCMProcessHistory.ExpectedGRDYear = (int)reader["ExpectedGRDYear"];
                    oSCMProcessHistory.Remarks = (string)reader["Remarks"];
                    oSCMProcessHistory.CreateUserID = (int)reader["CreateUserID"];
                    oSCMProcessHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSCMProcessHistory.TranType = (int)reader["TranType"];
                    
                    InnerList.Add(oSCMProcessHistory);
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


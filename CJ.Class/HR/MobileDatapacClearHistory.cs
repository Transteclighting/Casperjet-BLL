// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Aug 21, 2016
// Time : 10:31 AM
// Description: Class for MobileDatapcClearHistory.
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
    public class MobileDatapcClearHistory
    {
        private int _nID;
        private int _nMobileID;
        private DateTime _dDate;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private string _sRemarks;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for MobileID
        // </summary>
        public int MobileID
        {
            get { return _nMobileID; }
            set { _nMobileID = value; }
        }

        // <summary>
        // Get set property for Date
        // </summary>
        public DateTime Date
        {
            get { return _dDate; }
            set { _dDate = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_MobileDatapcClearHistory";
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
                sSql = "INSERT INTO t_MobileDatapcClearHistory (ID, MobileID, Date, CreateUserID, CreateDate, Remarks) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("MobileID", _nMobileID);
                cmd.Parameters.AddWithValue("Date", _dDate);
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
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_MobileDatapcClearHistory SET MobileID = ?, Date = ?, CreateUserID = ?, CreateDate = ?, Remarks = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MobileID", _nMobileID);
                cmd.Parameters.AddWithValue("Date", _dDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

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
                sSql = "DELETE FROM t_MobileDatapcClearHistory WHERE [ID]=?";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_MobileDatapcClearHistory where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nMobileID = (int)reader["MobileID"];
                    _dDate = Convert.ToDateTime(reader["Date"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
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
    public class MobileDatapcClearHistorys : CollectionBase
    {
        public MobileDatapcClearHistory this[int i]
        {
            get { return (MobileDatapcClearHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MobileDatapcClearHistory oMobileDatapcClearHistory)
        {
            InnerList.Add(oMobileDatapcClearHistory);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_MobileDatapcClearHistory";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MobileDatapcClearHistory oMobileDatapcClearHistory = new MobileDatapcClearHistory();
                    oMobileDatapcClearHistory.ID = (int)reader["ID"];
                    oMobileDatapcClearHistory.MobileID = (int)reader["MobileID"];
                    oMobileDatapcClearHistory.Date = Convert.ToDateTime(reader["Date"].ToString());
                    oMobileDatapcClearHistory.CreateUserID = (int)reader["CreateUserID"];
                    oMobileDatapcClearHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oMobileDatapcClearHistory.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oMobileDatapcClearHistory);
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


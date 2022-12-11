using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class 
{
    public class QuotationHistory
    {
        private int _nHistoryID;
        private int _nQuotationID;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nStatus;
        private string _sRemarks;
        private int _nType;


        // <summary>
        // Get set property for HistoryID 
        // </summary>
        public int HistoryID
        {
            get { return _nHistoryID; }
            set { _nHistoryID = value; }
        }

        // <summary>
        // Get set property for QuotationID
        // </summary>
        public int QuotationID
        {
            get { return _nQuotationID; }
            set { _nQuotationID = value; }
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
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

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

        public void Add()
        {
            int nMaxHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([HistoryID]) FROM t_QuotationHistory";
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
                sSql = "INSERT INTO t_QuotationHistory (HistoryID, QuotationID, CreateUserID, CreateDate, Status, Remarks,Type) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Type", _nType);

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
                sSql = "UPDATE t_QuotationHistory SET QuotationID = ?, CreateUserID = ?, CreateDate = ?, Status = ?, Remarks = ? WHERE HistoryID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("QuotationID", _nQuotationID);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

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
                sSql = "DELETE FROM t_QuotationHistory WHERE [HistoryID]=?";
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
                cmd.CommandText = "SELECT * FROM t_QuotationHistory where HistoryID =?";
                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nHistoryID = (int)reader["HistoryID"];
                    _nQuotationID = (int)reader["QuotationID"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nStatus = (int)reader["Status"];
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
    public class QuotationHistorys : CollectionBase
    {
        public QuotationHistory this[int i]
        {
            get { return (QuotationHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(QuotationHistory oQuotationHistory)
        {
            InnerList.Add(oQuotationHistory);
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
            string sSql = "SELECT * FROM t_QuotationHistory";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    QuotationHistory oQuotationHistory = new QuotationHistory();
                    oQuotationHistory.HistoryID = (int)reader["HistoryID"];
                    oQuotationHistory.QuotationID = (int)reader["QuotationID"];
                    oQuotationHistory.CreateUserID = (int)reader["CreateUserID"];
                    oQuotationHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oQuotationHistory.Status = (int)reader["Status"];
                    oQuotationHistory.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oQuotationHistory);
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



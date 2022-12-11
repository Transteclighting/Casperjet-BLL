// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Nov 02, 2015
// Time : 05:12 PM
// Description: Class for UnsoldDefectiveProductHistory.
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
    public class UnsoldDefectiveProductHistory
    {
        private int _nHistoryID;
        private int _nDefectiveID;
        private int _nWarehouseID;
        private string _sRemarks;
        private int _nStatus;
        private DateTime _dCreateDate;
        private int _nCreateUserID;


        // <summary>
        // Get set property for HistoryID
        // </summary>
        public int HistoryID
        {
            get { return _nHistoryID; }
            set { _nHistoryID = value; }
        }

        // <summary>
        // Get set property for DefectiveID
        // </summary>
        public int DefectiveID
        {
            get { return _nDefectiveID; }
            set { _nDefectiveID = value; }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
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
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        public void Add()
        {
            int nMaxHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([HistoryID]) FROM t_UnsoldDefectiveProductHistory";
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
                sSql = "INSERT INTO t_UnsoldDefectiveProductHistory (HistoryID, DefectiveID, WarehouseID, Remarks, Status, CreateDate, CreateUserID) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);

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
                sSql = "UPDATE t_UnsoldDefectiveProductHistory SET DefectiveID = ?, WarehouseID = ?, Remarks = ?, Status = ?, CreateDate = ?, CreateUserID = ? WHERE HistoryID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);

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
                sSql = "DELETE FROM t_UnsoldDefectiveProductHistory WHERE [HistoryID]=?";
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
                cmd.CommandText = "SELECT * FROM t_UnsoldDefectiveProductHistory where HistoryID =?";
                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nHistoryID = (int)reader["HistoryID"];
                    _nDefectiveID = (int)reader["DefectiveID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _sRemarks = (string)reader["Remarks"];
                    _nStatus = (int)reader["Status"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
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
    public class UnsoldDefectiveProductHistorys : CollectionBase
    {
        public UnsoldDefectiveProductHistory this[int i]
        {
            get { return (UnsoldDefectiveProductHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(UnsoldDefectiveProductHistory oUnsoldDefectiveProductHistory)
        {
            InnerList.Add(oUnsoldDefectiveProductHistory);
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
            string sSql = "SELECT * FROM t_UnsoldDefectiveProductHistory";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UnsoldDefectiveProductHistory oUnsoldDefectiveProductHistory = new UnsoldDefectiveProductHistory();
                    oUnsoldDefectiveProductHistory.HistoryID = (int)reader["HistoryID"];
                    oUnsoldDefectiveProductHistory.DefectiveID = (int)reader["DefectiveID"];
                    oUnsoldDefectiveProductHistory.WarehouseID = (int)reader["WarehouseID"];
                    oUnsoldDefectiveProductHistory.Remarks = (string)reader["Remarks"];
                    oUnsoldDefectiveProductHistory.Status = (int)reader["Status"];
                    oUnsoldDefectiveProductHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oUnsoldDefectiveProductHistory.CreateUserID = (int)reader["CreateUserID"];
                    InnerList.Add(oUnsoldDefectiveProductHistory);
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


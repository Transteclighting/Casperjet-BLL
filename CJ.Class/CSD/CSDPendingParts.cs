
// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Feb 11, 2017
// Time : 01:41 PM
// Description: Class for CSDPendingSpareParts.
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
    public class CSDPendingSpareParts
    {
        private string _sSl;
        private int _nID;
        private int _nJobID;
        private int _nPartsID;
        private string _sPartsCode;
        private string _sPartsName;
        private string _UnitPrice;
        private string _nQty;
        private string _sTotalPrice;
        private int _nCreateUserID;
        private DateTime _dCreateDate;



        // <summary>
        // Get set property for Sl
        // </summary>
        public string Sl
        {
            get { return _sSl; }
            set { _sSl = value; }
        }

        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
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
        // Get set property for PartsID
        // </summary>
        public int PartsID
        {
            get { return _nPartsID; }
            set { _nPartsID = value; }
        }
        // <summary>
        // Get set property for PartsCode
        // </summary>
        public string PartsCode
        {
            get { return _sPartsCode; }
            set { _sPartsCode = value; }
        }
        // <summary>
        // Get set property for PartsName
        // </summary>
        public string PartsName
        {
            get { return _sPartsName; }
            set { _sPartsName = value; }
        }

        // <summary>
        // Get set property for UnitPrice
        // </summary>
        public string UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        // <summary>
        // Get set property for Qty
        // </summary>
        public string Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        // <summary>
        // Get set property for TotalPrice
        // </summary>
        public string TotalPrice
        {
            get { return _sTotalPrice; }
            set { _sTotalPrice = value; }
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

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDPendingSpareParts";
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
                sSql = "INSERT INTO t_CSDPendingSpareParts (ID, JobID, PartsID, UnitPrice, Qty, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("PartsID", _nPartsID);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("Qty", _nQty);
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
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDPendingSpareParts SET JobID = ?, PartsID = ?, UnitPrice = ?, Qty = ?, CreateUserID = ?, CreateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("PartsID", _nPartsID);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

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
                sSql = "DELETE FROM t_CSDPendingSpareParts WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CSDPendingSpareParts where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nJobID = (int)reader["JobID"];
                    _nPartsID = (int)reader["PartsID"];
                    _UnitPrice = Convert.ToString(reader["UnitPrice"]);
                    _nQty = Convert.ToString(reader["Qty"]);
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
    public class CSDPendingSparePartss : CollectionBase
    {
        public CSDPendingSpareParts this[int i]
        {
            get { return (CSDPendingSpareParts)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDPendingSpareParts oCSDPendingSpareParts)
        {
            InnerList.Add(oCSDPendingSpareParts);
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
            string sSql = "SELECT * FROM t_CSDPendingSpareParts";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDPendingSpareParts oCSDPendingSpareParts = new CSDPendingSpareParts();
                    oCSDPendingSpareParts.ID = (int)reader["ID"];
                    oCSDPendingSpareParts.JobID = (int)reader["JobID"];
                    oCSDPendingSpareParts.PartsID = (int)reader["PartsID"];
                    oCSDPendingSpareParts.UnitPrice = Convert.ToString(reader["UnitPrice"]);
                    oCSDPendingSpareParts.Qty = Convert.ToString(reader["Qty"]);
                    oCSDPendingSpareParts.CreateUserID = (int)reader["CreateUserID"];
                    oCSDPendingSpareParts.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDPendingSpareParts);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPendingPartsAgaintsJob(int nJobID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select a.*,b.*,TotalPrice=Qty*UnitPrice from dbo.t_CSDPendingSpareParts a,dbo.t_CSDSpareParts b where a.PartsID = b.SparePartID AND JobID =" + nJobID + "";
            try
            {
                int nSl = 1;
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDPendingSpareParts oCSDPendingSpareParts = new CSDPendingSpareParts();
                    oCSDPendingSpareParts.Sl = nSl.ToString();
                    oCSDPendingSpareParts.ID = (int)reader["ID"];
                    oCSDPendingSpareParts.JobID = (int)reader["JobID"];
                    oCSDPendingSpareParts.PartsID = (int)reader["PartsID"];
                    oCSDPendingSpareParts.PartsCode = (string)reader["Code"];
                    oCSDPendingSpareParts.PartsName = (string)reader["Name"];
                    oCSDPendingSpareParts.UnitPrice = Convert.ToString(reader["UnitPrice"]);
                    oCSDPendingSpareParts.TotalPrice = Convert.ToString(reader["TotalPrice"]);
                    oCSDPendingSpareParts.Qty = Convert.ToString(reader["Qty"]);
                    oCSDPendingSpareParts.CreateUserID = (int)reader["CreateUserID"];
                    oCSDPendingSpareParts.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDPendingSpareParts);
                    nSl++;
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



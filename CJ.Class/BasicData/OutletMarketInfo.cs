// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Oct 24, 2020
// Time : 11:52 AM
// Description: Class for OutletMarketInfo.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.BasicData
{
    public class OutletMarketInfo
    {
        private int _nID;
        private string _sDescription;
        private int _nMarketType;
        private int _nCreateUser;
        private DateTime _dCreateDate;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for MarketType
        // </summary>
        public int MarketType
        {
            get { return _nMarketType; }
            set { _nMarketType = value; }
        }

        // <summary>
        // Get set property for CreateUser
        // </summary>
        public int CreateUser
        {
            get { return _nCreateUser; }
            set { _nCreateUser = value; }
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
                sSql = "SELECT MAX([ID]) FROM t_OutletMarketInfo";
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
                sSql = "INSERT INTO t_OutletMarketInfo (ID, Description, MarketType, CreateUser, CreateDate) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("MarketType", _nMarketType);
                cmd.Parameters.AddWithValue("CreateUser", _nCreateUser);
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
                sSql = "UPDATE t_OutletMarketInfo SET Description = ?, MarketType = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("MarketType", _nMarketType);
                //cmd.Parameters.AddWithValue("CreateUser", _nCreateUser);
                //cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

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
                sSql = "DELETE FROM t_OutletMarketInfo WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_OutletMarketInfo where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sDescription = (string)reader["Description"];
                    _nMarketType = (int)reader["MarketType"];
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
    public class OutletMarketInfos : CollectionBase
    {
        public OutletMarketInfo this[int i]
        {
            get { return (OutletMarketInfo)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletMarketInfo oOutletMarketInfo)
        {
            InnerList.Add(oOutletMarketInfo);
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
            string sSql = "SELECT * FROM t_OutletMarketInfo";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletMarketInfo oOutletMarketInfo = new OutletMarketInfo();
                    oOutletMarketInfo.ID = (int)reader["ID"];
                    oOutletMarketInfo.Description = (string)reader["Description"];
                    oOutletMarketInfo.MarketType = (int)reader["MarketType"];
                    oOutletMarketInfo.CreateUser = (int)reader["CreateUser"];
                    oOutletMarketInfo.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oOutletMarketInfo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByType(int nMarketType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_OutletMarketInfo where MarketType="+ nMarketType + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletMarketInfo oOutletMarketInfo = new OutletMarketInfo();
                    oOutletMarketInfo.ID = (int)reader["ID"];
                    oOutletMarketInfo.Description = (string)reader["Description"];
                    oOutletMarketInfo.MarketType = (int)reader["MarketType"];
                    oOutletMarketInfo.CreateUser = (int)reader["CreateUser"];
                    oOutletMarketInfo.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oOutletMarketInfo);
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



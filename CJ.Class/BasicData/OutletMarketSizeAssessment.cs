// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Nov 03, 2020
// Time : 11:52 AM
// Description: Class for OutletMarketSizeAssessment.
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
    public class OutletMarketSizeAssessment
    {
        private int _nID;
        private string _sDescription;
        private int _nMarketType;
        private int _nShopSize;
        private int _nAvgSale;
        private int _nLEDQty;
        private int _nREFQty;
        private int _nACQty;


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
        // Get set property for ShopSize
        // </summary>
        public int ShopSize
        {
            get { return _nShopSize; }
            set { _nShopSize = value; }
        }

        // <summary>
        // Get set property for AvgSale
        // </summary>
        public int AvgSale
        {
            get { return _nAvgSale; }
            set { _nAvgSale = value; }
        }

        // <summary>
        // Get set property for LEDQty
        // </summary>
        public int LEDQty
        {
            get { return _nLEDQty; }
            set { _nLEDQty = value; }
        }

        // <summary>
        // Get set property for REFQty
        // </summary>
        public int REFQty
        {
            get { return _nREFQty; }
            set { _nREFQty = value; }
        }

        // <summary>
        // Get set property for ACQty
        // </summary>
        public int ACQty
        {
            get { return _nACQty; }
            set { _nACQty = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_OutletMarketSizeAssessment";
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
                sSql = "INSERT INTO t_OutletMarketSizeAssessment (ID, Description, MarketType, ShopSize, AvgSale, LEDQty, REFQty, ACQty) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("MarketType", _nMarketType);
                cmd.Parameters.AddWithValue("ShopSize", _nShopSize);
                cmd.Parameters.AddWithValue("AvgSale", _nAvgSale);
                cmd.Parameters.AddWithValue("LEDQty", _nLEDQty);
                cmd.Parameters.AddWithValue("REFQty", _nREFQty);
                cmd.Parameters.AddWithValue("ACQty", _nACQty);

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
                sSql = "UPDATE t_OutletMarketSizeAssessment SET Description = ?, MarketType = ?, ShopSize = ?, AvgSale = ?, LEDQty = ?, REFQty = ?, ACQty = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("MarketType", _nMarketType);
                cmd.Parameters.AddWithValue("ShopSize", _nShopSize);
                cmd.Parameters.AddWithValue("AvgSale", _nAvgSale);
                cmd.Parameters.AddWithValue("LEDQty", _nLEDQty);
                cmd.Parameters.AddWithValue("REFQty", _nREFQty);
                cmd.Parameters.AddWithValue("ACQty", _nACQty);

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
                sSql = "DELETE FROM t_OutletMarketSizeAssessment WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_OutletMarketSizeAssessment where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sDescription = (string)reader["Description"];
                    _nMarketType = (int)reader["MarketType"];
                    _nShopSize = (int)reader["ShopSize"];
                    _nAvgSale = (int)reader["AvgSale"];
                    _nLEDQty = (int)reader["LEDQty"];
                    _nREFQty = (int)reader["REFQty"];
                    _nACQty = (int)reader["ACQty"];
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
    public class OutletMarketSizeAssessments : CollectionBase
    {
        public OutletMarketSizeAssessment this[int i]
        {
            get { return (OutletMarketSizeAssessment)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletMarketSizeAssessment oOutletMarketSizeAssessment)
        {
            InnerList.Add(oOutletMarketSizeAssessment);
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
            string sSql = "SELECT * FROM t_OutletMarketSizeAssessment";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletMarketSizeAssessment oOutletMarketSizeAssessment = new OutletMarketSizeAssessment();
                    oOutletMarketSizeAssessment.ID = (int)reader["ID"];
                    oOutletMarketSizeAssessment.Description = (string)reader["Description"];
                    oOutletMarketSizeAssessment.MarketType = (int)reader["MarketType"];
                    oOutletMarketSizeAssessment.ShopSize = (int)reader["ShopSize"];
                    oOutletMarketSizeAssessment.AvgSale = (int)reader["AvgSale"];
                    oOutletMarketSizeAssessment.LEDQty = (int)reader["LEDQty"];
                    oOutletMarketSizeAssessment.REFQty = (int)reader["REFQty"];
                    oOutletMarketSizeAssessment.ACQty = (int)reader["ACQty"];
                    InnerList.Add(oOutletMarketSizeAssessment);
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



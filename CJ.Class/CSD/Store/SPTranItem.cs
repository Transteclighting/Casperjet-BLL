// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Mar 01, 2017
// Time : 12:55 PM
// Description: Class for CSDSPTranItem.
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
    public class CSDSPTranItem
    {
        private int _nSPTranItemID;
        private int _nSPTranID;
        private int _nSparePartID;
        private int _nQty;
        private double _CostPrice;
        private double _SalePrice;
        private string _sCode;
        private string _sName;


        // <summary>
        // Get set property for SPTranItemID
        // </summary>
        public int SPTranItemID
        {
            get { return _nSPTranItemID; }
            set { _nSPTranItemID = value; }
        }

        public string Code
        {
            get { return _sCode; }
            set { _sCode = value; }
        }
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }

        // <summary>
        // Get set property for SPTranID
        // </summary>
        public int SPTranID
        {
            get { return _nSPTranID; }
            set { _nSPTranID = value; }
        }

        // <summary>
        // Get set property for SparePartID
        // </summary>
        public int SparePartID
        {
            get { return _nSparePartID; }
            set { _nSparePartID = value; }
        }

        // <summary>
        // Get set property for Qty
        // </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        // <summary>
        // Get set property for CostPrice
        // </summary>
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }

        // <summary>
        // Get set property for SalePrice
        // </summary>
        public double SalePrice
        {
            get { return _SalePrice; }
            set { _SalePrice = value; }
        }

        public void Add()
        {
            int nMaxSPTranItemID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SPTranItemID]) FROM t_CSDSPTranItem";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSPTranItemID = 1;
                }
                else
                {
                    nMaxSPTranItemID = Convert.ToInt32(maxID) + 1;
                }
                _nSPTranItemID = nMaxSPTranItemID;
                sSql = "INSERT INTO t_CSDSPTranItem (SPTranItemID, SPTranID, SparePartID, Qty, CostPrice, SalePrice) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SPTranItemID", _nSPTranItemID);
                cmd.Parameters.AddWithValue("SPTranID", _nSPTranID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                cmd.Parameters.AddWithValue("SalePrice", _SalePrice);

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
                sSql = "UPDATE t_CSDSPTranItem SET SPTranID = ?, SparePartID = ?, Qty = ?, CostPrice = ?, SalePrice = ? WHERE SPTranItemID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SPTranID", _nSPTranID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                cmd.Parameters.AddWithValue("SalePrice", _SalePrice);

                cmd.Parameters.AddWithValue("SPTranItemID", _nSPTranItemID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateQty()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDSPTranItem   SET Qty = ? WHERE SPTranID = ? AND SparePartID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("SPTranID", _nSPTranID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);

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
                sSql = "DELETE FROM t_CSDSPTranItem WHERE [SPTranItemID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SPTranItemID", _nSPTranItemID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteByTranID(int nTranID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_CSDSPTranItem WHERE [SPTranID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SPTranID", nTranID);
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
                cmd.CommandText = "SELECT * FROM t_CSDSPTranItem where SPTranItemID =?";
                cmd.Parameters.AddWithValue("SPTranItemID", _nSPTranItemID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSPTranItemID = (int)reader["SPTranItemID"];
                    _nSPTranID = (int)reader["SPTranID"];
                    _nSparePartID = (int)reader["SparePartID"];
                    _nQty = (int)reader["Qty"];
                    _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    _SalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
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
    public class CSDSPTranItems : CollectionBase
    {
        public CSDSPTranItem this[int i]
        {
            get { return (CSDSPTranItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDSPTranItem oCSDSPTranItem)
        {
            InnerList.Add(oCSDSPTranItem);
        }
        public int GetIndex(int nSPTranItemID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SPTranItemID == nSPTranItemID)
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
            string sSql = "SELECT * FROM t_CSDSPTranItem";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDSPTranItem oCSDSPTranItem = new CSDSPTranItem();
                    oCSDSPTranItem.SPTranItemID = (int)reader["SPTranItemID"];
                    oCSDSPTranItem.SPTranID = (int)reader["SPTranID"];
                    oCSDSPTranItem.SparePartID = (int)reader["SparePartID"];
                    oCSDSPTranItem.Qty = (int)reader["Qty"];
                    oCSDSPTranItem.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    oCSDSPTranItem.SalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
                    InnerList.Add(oCSDSPTranItem);
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


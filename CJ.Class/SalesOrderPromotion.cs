// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Jan 15, 2015
// Time : 05:18 PM
// Description: Class for SalesOrderPromotion.
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
    public class SalesOrderPromotion
    {
        private int _nID;
        private int _nOrderID;
        private int _nSalesPromotionID;
        private int _nSlabID;
        private int _nType;
        private double _DiscountAmount;
        private int _nFreeProductID;
        private int _nFreeQty;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for OrderID
        // </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }

        // <summary>
        // Get set property for SalesPromotionID
        // </summary>
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }

        // <summary>
        // Get set property for SlabID
        // </summary>
        public int SlabID
        {
            get { return _nSlabID; }
            set { _nSlabID = value; }
        }

        // <summary>
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }

        // <summary>
        // Get set property for DiscountAmount
        // </summary>
        public double DiscountAmount
        {
            get { return _DiscountAmount; }
            set { _DiscountAmount = value; }
        }

        // <summary>
        // Get set property for FreeProductID
        // </summary>
        public int FreeProductID
        {
            get { return _nFreeProductID; }
            set { _nFreeProductID = value; }
        }

        // <summary>
        // Get set property for FreeQty
        // </summary>
        public int FreeQty
        {
            get { return _nFreeQty; }
            set { _nFreeQty = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_SalesOrderPromotion";
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
                sSql = "INSERT INTO t_SalesOrderPromotion (ID, OrderID, SalesPromotionID, SlabID, Type, DiscountAmount, FreeProductID, FreeQty) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("DiscountAmount", _DiscountAmount);
                cmd.Parameters.AddWithValue("FreeProductID", _nFreeProductID);
                cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);

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
                sSql = "UPDATE t_SalesOrderPromotion SET OrderID = ?, SalesPromotionID = ?, SlabID = ?, Type = ?, DiscountAmount = ?, FreeProductID = ?, FreeQty = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("SlabID", _nSlabID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("DiscountAmount", _DiscountAmount);
                cmd.Parameters.AddWithValue("FreeProductID", _nFreeProductID);
                cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);

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
                sSql = "DELETE FROM t_SalesOrderPromotion WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_SalesOrderPromotion where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nOrderID = (int)reader["OrderID"];
                    _nSalesPromotionID = (int)reader["SalesPromotionID"];
                    _nSlabID = (int)reader["SlabID"];
                    _nType = (int)reader["Type"];
                    _DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    _nFreeProductID = (int)reader["FreeProductID"];
                    _nFreeQty = (int)reader["FreeQty"];
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
    public class SalesOrderPromotions : CollectionBase
    {
        public SalesOrderPromotion this[int i]
        {
            get { return (SalesOrderPromotion)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesOrderPromotion oSalesOrderPromotion)
        {
            InnerList.Add(oSalesOrderPromotion);
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
            string sSql = "SELECT * FROM t_SalesOrderPromotion";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrderPromotion oSalesOrderPromotion = new SalesOrderPromotion();
                    oSalesOrderPromotion.ID = (int)reader["ID"];
                    oSalesOrderPromotion.OrderID = (int)reader["OrderID"];
                    oSalesOrderPromotion.SalesPromotionID = (int)reader["SalesPromotionID"];
                    oSalesOrderPromotion.SlabID = (int)reader["SlabID"];
                    oSalesOrderPromotion.Type = (int)reader["Type"];
                    oSalesOrderPromotion.DiscountAmount = Convert.ToDouble(reader["DiscountAmount"].ToString());
                    oSalesOrderPromotion.FreeProductID = (int)reader["FreeProductID"];
                    oSalesOrderPromotion.FreeQty = (int)reader["FreeQty"];
                    InnerList.Add(oSalesOrderPromotion);
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



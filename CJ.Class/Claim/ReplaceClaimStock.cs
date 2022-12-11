// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Sep 12, 2012
// Time : 11.00 AM
// Description: Class for Replace Claim Stock
// Modify Person And Date: Dipak Kumar Chakraborty
 // Date : May 21, 2015
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.POS;
using CJ.Class.Web.UI.Class;
using CJ.Class.Duty;

namespace CJ.Class
{
    public class ReplaceClaimStock
    {
        private int _nProductID;
        private int _nWarehouseID;
        private int _StockType;
        private int _nCurrentStock;
        private int _nBookingStock;
        private int _nChannelID;
        private int _nStatus;
        private bool _bFlag;
        protected int _nQty;

        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        public int StockType
        {
            get { return _StockType; }
            set { _StockType = value; }
        }

        public int CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }
        public int BookingStock
        {
            get { return _nBookingStock; }
            set { _nBookingStock = value; }
        }

        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }

        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }


        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " INSERT INTO t_ReplaceClaimStock VALUES (?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("StockType", _StockType);
                cmd.Parameters.AddWithValue("CurrentStock", _nCurrentStock);
                cmd.Parameters.AddWithValue("BookingStock", _nBookingStock);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCurrentStock(bool IsTrue)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (IsTrue)
                sSql = "update t_ReplaceClaimStock set CurrentStock=CurrentStock + ? where WarehouseID= ? and  ProductID = ? ";
            else sSql = "update t_ReplaceClaimStock set CurrentStock=CurrentStock - ? where  WarehouseID=? and  ProductID = ? ";

            try
            {
                cmd.CommandText = "SELECT CurrentStock FROM t_ReplaceClaimStock where WarehouseID=? and ProductID = ? ";
                 cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                //cmd.Parameters.AddWithValue("Qty", _nQty); 
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                object CurrentStock = cmd.ExecuteScalar();
                if (IsTrue)
                {
                    _bFlag = true;
                }
                else
                {
                    if (int.Parse(CurrentStock.ToString()) < _nQty)
                    {
                        _bFlag = false;
                    }
                    else
                    {
                        _bFlag = true;
                    }
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("CurrentStock", _nQty);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void UpdateRepStock(bool IsTrue)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (IsTrue)
                sSql = "update t_ReplaceClaimStock set CurrentStock=CurrentStock + ? where  ProductID = ? ";
            else sSql = "update t_ReplaceClaimStock set CurrentStock=CurrentStock - ? where  ProductID = ? ";

            try
            {
                cmd.CommandText = "SELECT CurrentStock FROM t_ReplaceClaimStock where ProductID = ? ";
                // cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                //cmd.Parameters.AddWithValue("Qty", _nQty); 
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                object CurrentStock = cmd.ExecuteScalar();
                if (IsTrue)
                {
                    _bFlag = true;
                }
                else
                {
                    if (int.Parse(CurrentStock.ToString()) < _nQty)
                    {
                        _bFlag = false;
                    }
                    else
                    {
                        _bFlag = true;
                    }
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("CurrentStock", _nQty);
                //cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool CheckProductStock()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_ReplaceClaimStock where  ProductID = ?";
            // cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
            cmd.Parameters.AddWithValue("ProductID", _nProductID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) return true;
            else return false;


        }

        public void GetCurrentStock(int nWarehouseId, int nProductId)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select (Currentstock - BookingStock) as SelableStock from t_ReplaceClaimStock where WarehouseId= ? and ProductID= ?";

                cmd.Parameters.AddWithValue("WarehouseId", nWarehouseId);
                cmd.Parameters.AddWithValue("ProductId", nProductId);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCurrentStock = Convert.ToInt16(reader["SelableStock"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}
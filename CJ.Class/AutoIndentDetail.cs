// <summary>
// Company: Transcom Electronics Limited
// Author: Akif Ahmed
// Date: Jun 23, 2019
// Time : 03:39 PM
// Description: Class for AutoIndentDetail.
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
    public class AutoIndentDetail
    {
        private int _nAutoIndentID;
        private double _UnitPrice;
        private int _nProductID;
        private int _nQuantity;
        private int _nConfirmQuantity;
        private double _AdjustedDPAmount;
        private double _AdjustedPWAmount;
        private double _AdjustedTPAmount;
        private double _PromotionalDiscount;
        private int _nIsFreeProduct;
        private int _nFreeQty;
        private int _nReason;


        // <summary>
        // Get set property for AutoIndentID
        // </summary>
        public int AutoIndentID
        {
            get { return _nAutoIndentID; }
            set { _nAutoIndentID = value; }
        }

        // <summary>
        // Get set property for UnitPrice
        // </summary>
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        // <summary>
        // Get set property for Quantity
        // </summary>
        public int Quantity
        {
            get { return _nQuantity; }
            set { _nQuantity = value; }
        }

        // <summary>
        // Get set property for ConfirmQuantity
        // </summary>
        public int ConfirmQuantity
        {
            get { return _nConfirmQuantity; }
            set { _nConfirmQuantity = value; }
        }

        // <summary>
        // Get set property for AdjustedDPAmount
        // </summary>
        public double AdjustedDPAmount
        {
            get { return _AdjustedDPAmount; }
            set { _AdjustedDPAmount = value; }
        }

        // <summary>
        // Get set property for AdjustedPWAmount
        // </summary>
        public double AdjustedPWAmount
        {
            get { return _AdjustedPWAmount; }
            set { _AdjustedPWAmount = value; }
        }

        // <summary>
        // Get set property for AdjustedTPAmount
        // </summary>
        public double AdjustedTPAmount
        {
            get { return _AdjustedTPAmount; }
            set { _AdjustedTPAmount = value; }
        }

        // <summary>
        // Get set property for PromotionalDiscount
        // </summary>
        public double PromotionalDiscount
        {
            get { return _PromotionalDiscount; }
            set { _PromotionalDiscount = value; }
        }

        // <summary>
        // Get set property for IsFreeProduct
        // </summary>
        public int IsFreeProduct
        {
            get { return _nIsFreeProduct; }
            set { _nIsFreeProduct = value; }
        }

        // <summary>
        // Get set property for FreeQty
        // </summary>
        public int FreeQty
        {
            get { return _nFreeQty; }
            set { _nFreeQty = value; }
        }

        // <summary>
        // Get set property for Reason
        // </summary>
        public int Reason
        {
            get { return _nReason; }
            set { _nReason = value; }
        }

        public void Add()
        {
            int nMaxAutoIndentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                
                sSql = "INSERT INTO t_AutoIndentDetail (AutoIndentID, UnitPrice, ProductID, Quantity, ConfirmQuantity, AdjustedDPAmount, AdjustedPWAmount, AdjustedTPAmount, PromotionalDiscount, IsFreeProduct, FreeQty, Reason) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AutoIndentID", _nAutoIndentID);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("ConfirmQuantity", _nConfirmQuantity);
                cmd.Parameters.AddWithValue("AdjustedDPAmount", _AdjustedDPAmount);
                cmd.Parameters.AddWithValue("AdjustedPWAmount", _AdjustedPWAmount);
                cmd.Parameters.AddWithValue("AdjustedTPAmount", _AdjustedTPAmount);
                cmd.Parameters.AddWithValue("PromotionalDiscount", _PromotionalDiscount);
                cmd.Parameters.AddWithValue("IsFreeProduct", _nIsFreeProduct);
                cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);
                cmd.Parameters.AddWithValue("Reason", _nReason);

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
                sSql = "UPDATE t_AutoIndentDetail SET UnitPrice = ?, ProductID = ?, Quantity = ?, ConfirmQuantity = ?, AdjustedDPAmount = ?, AdjustedPWAmount = ?, AdjustedTPAmount = ?, PromotionalDiscount = ?, IsFreeProduct = ?, FreeQty = ?, Reason = ? WHERE AutoIndentID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("ConfirmQuantity", _nConfirmQuantity);
                cmd.Parameters.AddWithValue("AdjustedDPAmount", _AdjustedDPAmount);
                cmd.Parameters.AddWithValue("AdjustedPWAmount", _AdjustedPWAmount);
                cmd.Parameters.AddWithValue("AdjustedTPAmount", _AdjustedTPAmount);
                cmd.Parameters.AddWithValue("PromotionalDiscount", _PromotionalDiscount);
                cmd.Parameters.AddWithValue("IsFreeProduct", _nIsFreeProduct);
                cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);
                cmd.Parameters.AddWithValue("Reason", _nReason);

                cmd.Parameters.AddWithValue("AutoIndentID", _nAutoIndentID);

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
                sSql = "DELETE FROM t_AutoIndentDetail WHERE [AutoIndentID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("AutoIndentID", _nAutoIndentID);
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
                cmd.CommandText = "SELECT * FROM t_AutoIndentDetail where AutoIndentID =?";
                cmd.Parameters.AddWithValue("AutoIndentID", _nAutoIndentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nAutoIndentID = (int)reader["AutoIndentID"];
                    _UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    _nProductID = (int)reader["ProductID"];
                    _nQuantity = (int)reader["Quantity"];
                    _nConfirmQuantity = (int)reader["ConfirmQuantity"];
                    _AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    _AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    _AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
                    _PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    _nIsFreeProduct = (int)reader["IsFreeProduct"];
                    _nFreeQty = (int)reader["FreeQty"];
                    _nReason = (int)reader["Reason"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddToSalesOrderDetail()
        {
            int nMaxAutoIndentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = @"INSERT INTO t_SalesOrderDetail (OrderID, UnitPrice, ProductID, Quantity, ConfirmQuantity, AdjustedDPAmount, AdjustedPWAmount, AdjustedTPAmount, PromotionalDiscount, IsFreeProduct, FreeQty, Reason) VALUES
                    ("+ _nAutoIndentID + ","+ _UnitPrice + ","+ _nProductID + ","+ _nQuantity + ","+ _nConfirmQuantity + ","+ _AdjustedDPAmount*_UnitPrice + ","+ _AdjustedPWAmount *_UnitPrice+ ","+ _AdjustedTPAmount*_UnitPrice + ","+ _PromotionalDiscount + ",null,0,null)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("AutoIndentID", _nAutoIndentID);
                //cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                //cmd.Parameters.AddWithValue("ProductID", _nProductID);
                //cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                //cmd.Parameters.AddWithValue("ConfirmQuantity", _nConfirmQuantity);
                //cmd.Parameters.AddWithValue("AdjustedDPAmount", _AdjustedDPAmount);
                //cmd.Parameters.AddWithValue("AdjustedPWAmount", _AdjustedPWAmount);
                //cmd.Parameters.AddWithValue("AdjustedTPAmount", _AdjustedTPAmount);
                //cmd.Parameters.AddWithValue("PromotionalDiscount", _PromotionalDiscount);
                //cmd.Parameters.AddWithValue("IsFreeProduct", _nIsFreeProduct);
                //cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);
                //cmd.Parameters.AddWithValue("Reason", _nReason);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class AutoIndentDetails : CollectionBase
    {
        public AutoIndentDetail this[int i]
        {
            get { return (AutoIndentDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(AutoIndentDetail oAutoIndentDetail)
        {
            InnerList.Add(oAutoIndentDetail);
        }
        public int GetIndex(int nAutoIndentID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].AutoIndentID == nAutoIndentID)
                {
                    return i;
                }
            }
            return -1;
        }
        public List<AutoIndentDetail> Refresh()
        {
            var list = new List<AutoIndentDetail>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_AutoIndentDetail";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AutoIndentDetail oAutoIndentDetail = new AutoIndentDetail();
                    oAutoIndentDetail.AutoIndentID = (int)reader["AutoIndentID"];
                    oAutoIndentDetail.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oAutoIndentDetail.ProductID = (int)reader["ProductID"];
                    oAutoIndentDetail.Quantity = (int)reader["Quantity"];
                    oAutoIndentDetail.ConfirmQuantity = (int)reader["ConfirmQuantity"];
                    oAutoIndentDetail.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    oAutoIndentDetail.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    oAutoIndentDetail.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
                    oAutoIndentDetail.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    oAutoIndentDetail.IsFreeProduct = Int32.Parse(reader["IsFreeProduct"].ToString());
                    oAutoIndentDetail.FreeQty = Int32.Parse(reader["FreeQty"].ToString());
                    oAutoIndentDetail.Reason = Int32.Parse(reader["Reason"].ToString());
                    InnerList.Add(oAutoIndentDetail);
                    list.Add(oAutoIndentDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }
        public List<AutoIndentDetail> getByAutoIndentID(int id)
        {
            List<AutoIndentDetail> list = new List<AutoIndentDetail>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_AutoIndentDetail where AutoIndentID="+id;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AutoIndentDetail oAutoIndentDetail = new AutoIndentDetail();
                    oAutoIndentDetail.AutoIndentID = (int)reader["AutoIndentID"];
                    oAutoIndentDetail.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oAutoIndentDetail.ProductID = (int)reader["ProductID"];
                    oAutoIndentDetail.Quantity = (int)reader["Quantity"];
                    oAutoIndentDetail.ConfirmQuantity = (int)reader["ConfirmQuantity"];
                    oAutoIndentDetail.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    oAutoIndentDetail.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    oAutoIndentDetail.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
                    oAutoIndentDetail.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    oAutoIndentDetail.IsFreeProduct = Int32.Parse(reader["IsFreeProduct"].ToString());
                    oAutoIndentDetail.FreeQty = Int32.Parse(reader["FreeQty"].ToString());
                    oAutoIndentDetail.Reason = Int32.Parse(reader["Reason"].ToString());
                    InnerList.Add(oAutoIndentDetail);
                    list.Add(oAutoIndentDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }
    }
}


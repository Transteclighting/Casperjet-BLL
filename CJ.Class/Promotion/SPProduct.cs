// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Dec 28, 2011
// Time :  03:00 PM
// Description: Class for Promotion.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Promotion
{
    public class SPProduct
    {
        private int _nSalesPromotionID;
        private int _nProductID;
        private int _nQty;
        private bool _bFlag;

        /// <summary>
        /// Get set property for SalesPromotionID
        /// </summary>
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }
        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        /// <summary>
        /// Get set property for Qty
        /// </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        /// <summary>
        /// Get set property for Flag
        /// </summary>
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }


        private int _nFreeProductID;
        private int _nFreeQty;
        private double _Discount;

        public int FreeProductID
        {
            get { return _nFreeProductID;}
            set { _nFreeProductID = value;}
        }
        public int FreeQty
        {
            get { return _nFreeQty; }
            set { _nFreeQty = value; }
        }
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }


        public void Insert()
        {                 
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_SalesPromoProduct VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", 0);              

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
                sSql = "DELETE FROM t_SalesPromoProduct WHERE SalesPromotionID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);               

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
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromoProduct where  SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {                  
                    _nProductID = int.Parse(reader["ProductID"].ToString());
                    nCount++;
                }
                reader.Close();
            
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount > 1)
            {
                _bFlag = true;
            }
            else
            {
                _bFlag = false;
            }
        }
    }

    public class SPProducts : CollectionBase
    {
        public SPProduct this[int i]
        {
            get { return (SPProduct)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPProduct oSPProduct)
        {
            InnerList.Add(oSPProduct);
        }
        public void Refresh(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromoProduct where  SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPProduct oSPProduct = new SPProduct();
                    oSPProduct.ProductID = int.Parse(reader["ProductID"].ToString());
                    oSPProduct.Qty = int.Parse(reader["Qty"].ToString());
                    InnerList.Add(oSPProduct);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshOtherThenTD(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_Salespromotiondetail where  SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPProduct oSPProduct = new SPProduct();
                    oSPProduct.ProductID = int.Parse(reader["ProductID"].ToString());
                    oSPProduct.Qty = int.Parse(reader["SalesQty"].ToString());
                    oSPProduct.FreeProductID = int.Parse(reader["FreeProductID"].ToString());
                    oSPProduct.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    oSPProduct.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    InnerList.Add(oSPProduct);
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

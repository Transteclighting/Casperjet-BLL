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
    public class SPFreeProduct
    {
        private int _nCPSID;
        private int _nProductID;
        private int _nQty;


        /// <summary>
        /// Get set property for CPSID
        /// </summary>
        public int CPSID
        {
            get { return _nCPSID; }
            set { _nCPSID = value; }
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
        private int _nSlabNo;
        public int SlabNo
        {
            get { return _nSlabNo; }
            set { _nSlabNo = value; }
        }
        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_SalesPromoFreeProduct VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CPSID", _nCPSID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _nQty);

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
                sSql = "DELETE FROM t_SalesPromoFreeProduct WHERE CPSID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CPSID", _nCPSID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByCPSID(int nCPSID)
        {
       
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromoFreeProduct where CPSID = ?";
            cmd.Parameters.AddWithValue("CPSID", nCPSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPFreeProduct oSPFreeProduct = new SPFreeProduct();

                   _nCPSID = int.Parse(reader["CPSID"].ToString());
                   _nProductID = int.Parse(reader["ProductID"].ToString());
                   _nQty = int.Parse(reader["Qty"].ToString());
                }

                reader.Close();
                
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class SPFreeProducts : CollectionBase
    {
        public SPFreeProduct this[int i]
        {
            get { return (SPFreeProduct)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPFreeProduct oSPFreeProduct)
        {
            InnerList.Add(oSPFreeProduct);
        }
        public void Refresh(int nCPSID, int nSlabNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromoFreeProduct where CPSID = ?";
            cmd.Parameters.AddWithValue("CPSID", nCPSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPFreeProduct oSPFreeProduct = new SPFreeProduct();

                    oSPFreeProduct.CPSID = int.Parse(reader["CPSID"].ToString());
                    oSPFreeProduct.ProductID = int.Parse(reader["ProductID"].ToString());
                    oSPFreeProduct.Qty = int.Parse(reader["Qty"].ToString());
                    oSPFreeProduct.SlabNo = nSlabNo;
                    
                    InnerList.Add(oSPFreeProduct);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nCPSID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select a.*, ProductCode, ProductName from t_SalesPromoFreeProduct a, t_Product b where a.ProductID=b.ProductID and CPSID = ?";
            cmd.Parameters.AddWithValue("CPSID", nCPSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPFreeProduct oSPFreeProduct = new SPFreeProduct();

                    oSPFreeProduct.CPSID = int.Parse(reader["CPSID"].ToString());
                    oSPFreeProduct.ProductID = int.Parse(reader["ProductID"].ToString());
                    oSPFreeProduct.Qty = int.Parse(reader["Qty"].ToString());
                    oSPFreeProduct.ProductCode = (string)reader["ProductCode"];
                    oSPFreeProduct.ProductName = (string)reader["ProductName"];

                    InnerList.Add(oSPFreeProduct);
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

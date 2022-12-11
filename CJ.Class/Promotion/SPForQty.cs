// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jan 05, 2015
// Time :  06:52 PM
// Description: Class for Sales promotion For Qty.
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
    public class SPForQty
    {
        private int _nSalesPromotionID;
        private int _nQty;

        /// <summary>
        /// Get set property for SalesPromotionID
        /// </summary>
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }

        /// <summary>
        /// Get set property for Qty
        /// </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_SalesPromoForQty VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
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
                sSql = "DELETE FROM t_SalesPromoForQty WHERE SalesPromotionID=? ";
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
        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_SalesPromoForQty SET Qty = ? WHERE SalesPromotionID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public void Refresh(int nSalesPromotionID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromoForQty where  SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
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
    public class SPForQtys : CollectionBase
    {
        public SPForQty this[int i]
        {
            get { return (SPForQty)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPForQty oSPForQty)
        {
            InnerList.Add(oSPForQty);
        }
        
    }
}



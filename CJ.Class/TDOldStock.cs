// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 19, 2012
// Time :  05:00 PM
// Description: Class for old td stock.
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace CJ.Class
{
    public class TDOldStock
    {

        private int _WHID;
        private int _ProductID;
        private int _StockQty;
        private int _RemainderQty;


        /// <summary>
        /// Get set property for WHID
        /// </summary>
        public int WHID
        {
            get { return _WHID; }
            set { _WHID = value; }
        }

        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        /// <summary>
        /// Get set property for StockQty
        /// </summary>
        public int StockQty
        {
            get { return _StockQty; }
            set { _StockQty = value; }
        }

        /// <summary>
        /// Get set property for RemainderQty
        /// </summary>
        public int RemainderQty
        {
            get { return _RemainderQty; }
            set { _RemainderQty = value; }
        }

        public bool CheckQuantity()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM temp_TDStock where WHID =? and ProductID=?";

            cmd.Parameters.AddWithValue("WHID", _WHID);
            cmd.Parameters.AddWithValue("ProductID", _ProductID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _RemainderQty = (int)reader["RemainderQty"];
                    if (_RemainderQty > 0)
                        nCount++;
                }
                reader.Close();
              

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return false;
            else return true;
        }

        public int GetVatQuantity(int nInvoiceQty)
        {
            int nVatQty = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM temp_TDStock where WHID =? and ProductID=?";

            cmd.Parameters.AddWithValue("WHID", _WHID);
            cmd.Parameters.AddWithValue("ProductID", _ProductID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _RemainderQty = (int)reader["RemainderQty"];
                    if (_RemainderQty >= nInvoiceQty)
                        nVatQty = nInvoiceQty;
                    else nVatQty = _RemainderQty;
                }
                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nVatQty;
        }
        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE temp_TDStock SET RemainderQty = RemainderQty-? where WHID =? and ProductID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RemainderQty", _RemainderQty);
                cmd.Parameters.AddWithValue("WHID", _WHID);
                cmd.Parameters.AddWithValue("ProductID", _ProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: January 09, 2014
// Time :  20:00 PM
// Description: Class for SalesDataSync.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Class.Process
{
    public class SalesDataSync
    {

        private int _nInvoiceID;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private string _sCustomer;
        private string _sWarehouse;
        private double _InvoiceAmount;

        private string _sProductCode;
        private string _sProductName;
        private int _nQty;
        private double _UnitPrice;


        /// <summary>
        /// Get set property for InvoiceID
        /// </summary>
        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }

        /// <summary>
        /// Get set property for InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }

        /// <summary>
        /// Get set property for InvoiceDate
        /// </summary>
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }

        /// <summary>
        /// Get set property for Customer
        /// </summary>
        public string Customer
        {
            get { return _sCustomer; }
            set { _sCustomer = value; }
        }

        /// <summary>
        /// Get set property for Warehouse
        /// </summary>
        public string Warehouse
        {
            get { return _sWarehouse; }
            set { _sWarehouse = value; }
        }

        /// <summary>
        /// Get set property for InvoiceAmount
        /// </summary>
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }

        /// <summary>
        /// Get set property for ProductCode
        /// </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        /// <summary>
        /// Get set property for ProductName
        /// </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
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
        /// Get set property for UnitPrice
        /// </summary>
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        
        public void DeleteWSSalesInvoice(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            try
            {
                sSql = "Delete FROM t_WSSalesInvoiceDetail where InvoiceID =?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
            try
            {
                cmd = DBController.Instance.GetCommand();

                sSql = "Delete FROM t_WSSalesInvoice where InvoiceID =?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

    }
    public class SalesDataSyncs : CollectionBase
    {

        public SalesDataSync this[int i]
        {
            get { return (SalesDataSync)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesDataSync oSalesDataSync)
        {
            InnerList.Add(oSalesDataSync);
        }
        //public int GetIndex(int nGeoLocationID)
        //{
        //    int i;
        //    for (i = 0; i < this.Count; i++)
        //    {
        //        if (this[i].GeoLocationID == nGeoLocationID)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}


        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select InvoiceID, InvoiceNo, InvoiceDate, (CustomerName+' ['+CustomerCode+']')as Customer, " +
                    "(WarehouseName +' ['+WarehouseCode+']')Warehouse, InvoiceAmount from t_wsSalesinvoice a, t_Customer b,t_Warehouse c  " +
                    "Where a.CustomerID=b.CustomerID and a.WarehouseID=c.WarehouseID Order by InvoiceID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesDataSync oSalesDataSync = new SalesDataSync();

                    oSalesDataSync.InvoiceID = Convert.ToInt32(reader["InvoiceID"].ToString());
                    oSalesDataSync.InvoiceNo = (string)reader["InvoiceNo"];
                    oSalesDataSync.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oSalesDataSync.Customer = (string)reader["Customer"];
                    oSalesDataSync.Warehouse = (string)reader["Warehouse"];
                    oSalesDataSync.InvoiceAmount =Convert.ToDouble(reader["InvoiceAmount"].ToString());


                    InnerList.Add(oSalesDataSync);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshItem(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT ProductCode, ProductName,UnitPrice,Quantity FROM t_WSSalesInvoicedetail a, "+
                            "t_Product b where a.ProductID=b.ProductID and InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesDataSync oSalesDataSync = new SalesDataSync();

                    oSalesDataSync.ProductCode = (string)reader["ProductCode"];
                    oSalesDataSync.ProductName = (string)reader["ProductName"];
                    oSalesDataSync.Qty = int.Parse(reader["Quantity"].ToString());
                    oSalesDataSync.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());


                    InnerList.Add(oSalesDataSync);
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


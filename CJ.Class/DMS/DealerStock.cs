
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: March 18, 2014
// Time :  11:24 AM
// Description: Class for DMS Dealer Stock
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class DealerStock
    {


        private string _sProductCode;
        private string _sProductName;
        private string _sDealerCode;
        private DateTime _dEntryDate;
        private int _nPreviousStock;
        private int _nCurrentStock;
        private int _nStockQty;
        private double _UnitPrice;


        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public string DealerCode
        {
            get { return _sDealerCode; }
            set { _sDealerCode = value; }
        }
        public DateTime EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
        }
        public int PreviousStock
        {
            get { return _nPreviousStock; }
            set { _nPreviousStock = value; }
        }
        public int CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }
        public int StockQty
        {
            get { return _nStockQty; }
            set { _nStockQty = value; }
        }
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

       
        public void Add()
        {         

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO TELAddDB.dbo.t_DealerStock VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);
                cmd.Parameters.AddWithValue("DealerCode", _sDealerCode);
                cmd.Parameters.AddWithValue("ProductCode", _sProductCode);
                cmd.Parameters.AddWithValue("StockQty", _nStockQty);
              
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class DealerStocks : CollectionBase
    {

        public DealerStock this[int i]
        {
            get { return (DealerStock)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DealerStock oDealerStock)
        {
            InnerList.Add(oDealerStock);
        }


        public void GetDealerProduct(DateTime dTrnaDate, string sDealerCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select x.*,IsNull(stockQty,0)StockQty  from " +
                            "( " +
                            "select a.ProductCode,ProductName from TELAddDB.dbo.t_DealerProduct a,  " +
                            "(Select ProductCode, ProductName from t_Product) b " +
                            "Where a.ProductCode=b.ProductCode and IsActive=1  " +
                            ")x " +
                            "Left Outer JOIN " +
                            "( " +
                            "select a.ProductCode,stockQty from " +
                            "(select Max(EntryDate)EntryDate,DealerCode,ProductCode from  " +
                            "TELAddDB.dbo.t_DealerStock Where EntryDate <> '" + dTrnaDate + "' and DealerCode='" + sDealerCode + "' " +
                            "Group by DealerCode,ProductCode)a, TELAddDB.dbo.t_DealerStock b " +
                            "Where a.EntryDate=b.EntryDate and a.DealerCode=b.DealerCode and a.ProductCode=b.ProductCode " +
                            ")y  " +
                            "ON ltrim(rtrim(x.ProductCode))=ltrim(rtrim(y.ProductCode)) ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DealerStock oDealerStock = new DealerStock();

                    oDealerStock.ProductCode = (string)reader["ProductCode"];
                    oDealerStock.ProductName = (string)reader["ProductName"];
                    oDealerStock.PreviousStock = Convert.ToInt32(reader["StockQty"].ToString());
                    
                    InnerList.Add(oDealerStock);
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


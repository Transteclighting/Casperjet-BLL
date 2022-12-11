using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Library;
using CJ.Class;

namespace CJ.Class.ANDROID
{
    public class BLL
    {
        TELLib _TELLib;

        public double GetBLLYTDSalesValue()
        {
            double nBLLYTDSaleValue = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select isnull(sum(p2.CRCYR) - abs(sum(p2.DbCYR)),0) as YTDSales " +
                                    "from " +
                                    "(    " +
                                    "select sum(Invoiceamount) as CRCYR, 0 as DbCYR " +
                                    "from BLLSysDB.dbo.t_salesInvoice " +
                                    "where (InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) " +
                                    "group by  CustomerID " +
                                    "union all " +
                                    "select 0 as CRCYR,sum(Invoiceamount) as DbCYR " +
                                    "from BLLSysDB.dbo.t_salesInvoice " +
                                    "where (InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3) " +
                                    ") " +
                                    "as p2  ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nBLLYTDSaleValue = Convert.ToDouble(reader["YTDSales"].ToString());

                }

                reader.Close();
                return nBLLYTDSaleValue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetBLLMTDSalesValue()
        {
            double nBLLMTDSaleValue = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select isnull(sum(p2.CRCYR) - abs(sum(p2.DbCYR)),0) as MTDSales  " +
                                "from  " +
                                "( " +
                                "select sum(Invoiceamount) as CRCYR, 0 as DbCYR " +
                                "from BLLSysDB.dbo.t_salesInvoice " +
                                "where  (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) " +
                                "group by  CustomerID " +
                                "union all " +
                                "select 0 as CRCYR,sum(Invoiceamount) as DbCYR " +
                                "from BLLSysDB.dbo.t_salesInvoice " +
                                "where (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3) " +
                                ") " +
                                "as p2  ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nBLLMTDSaleValue = Convert.ToDouble(reader["MTDSales"].ToString());

                }

                reader.Close();
                return nBLLMTDSaleValue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetBLLLMSalesValue()
        {
            _TELLib = new TELLib();
            DateTime dFDLM = _TELLib.FirstDayofLastMonth(DateTime.Today);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            double sResult = 0;
            try
            {
                cmd.CommandText = " select isnull(sum(p2.CRCYR) - abs(sum(p2.DbCYR)),0) as LMSales  " +
                                    "from   " +
                                    "(  " +
                                    "select sum(Invoiceamount) as CRCYR, 0 as DbCYR  " +
                                    "from BLLSysDB.dbo.t_salesInvoice  " +
                                    "where  InvoiceDate BETWEEN '" + dFDLM + "' AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  " +
                                    "group by  CustomerID  " +
                                    "union all  " +
                                    "select 0 as CRCYR,sum(Invoiceamount) as DbCYR  " +
                                    "from BLLSysDB.dbo.t_salesInvoice  " +
                                    "where InvoiceDate BETWEEN '" + dFDLM + "' AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) and invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)  " +
                                    ")  " +
                                    "as p2";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sResult = Convert.ToDouble(reader["LMSales"].ToString());

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetBLLDTDSalesValue()
        {
            double BLLDTDSaleValue = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);

            try
            {
                cmd.CommandText = " select isnull(sum(p2.CRCYR) - abs(sum(p2.DbCYR)),0) as DTDSales  " +
                                "from  " +
                                "( " +
                                "select sum(Invoiceamount) as CRCYR, 0 as DbCYR " +
                                "from BLLSysDB.dbo.t_salesInvoice " +
                                "where InvoiceDate BETWEEN ? AND ? AND InvoiceDate < ? and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) " +
                                "group by  CustomerID " +
                                "union all " +
                                "select 0 as CRCYR,sum(Invoiceamount) as DbCYR " +
                                "from BLLSysDB.dbo.t_salesInvoice " +
                                "where InvoiceDate BETWEEN ? AND ? AND InvoiceDate < ? and invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3) " +
                                ") " +
                                "as p2  ";


                cmd.Parameters.AddWithValue("InvoiceDate", dFromDate);
                cmd.Parameters.AddWithValue("InvoiceDate", dToDate);
                cmd.Parameters.AddWithValue("InvoiceDate", dToDate);

                cmd.Parameters.AddWithValue("InvoiceDate", dFromDate);
                cmd.Parameters.AddWithValue("InvoiceDate", dToDate);
                cmd.Parameters.AddWithValue("InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BLLDTDSaleValue = Convert.ToDouble(reader["DTDSales"].ToString());

                }

                reader.Close();
                return BLLDTDSaleValue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetBLLStockValue()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            try
            {
                cmd.CommandText = " select Sum(StockQty) as StockQty, Sum(StockVal) as StockVal " +
                                    "from " +
                                    "(select AGName,StockQty,(CostPrice*StockQty) StockVal " +
                                    "from (select ProductID,sum(CurrentStock) as StockQty " +
                                    "from BLLSysDB.dbo.t_ProductStock A " +
                                    "inner join BLLSysDB.dbo.t_Warehouse WH " +
                                    "on  A.WarehouseID=WH.WarehouseID " +
                                    "where WH.WarehouseParentID not in (1,9,10) " +
                                    "group by ProductID) AA " +
                                    "inner join BLLSysDB.dbo.v_ProductDetails Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sResult = sResult + reader["StockQty"].ToString() + " Val: Tk. ";
                    sResult = sResult + oTELLib.TakaFormat(Convert.ToDouble(reader["StockVal"].ToString()));

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetBLLASGWiseStock()
        {
            string sResult = "";
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName, Sum(StockQty) as StockQty, Sum(StockVal) as StockVal " +
                                    "from " +
                                    "(select ASGName,StockQty,(CostPrice*StockQty) StockVal " +
                                    "from (select ProductID,sum(CurrentStock) as StockQty " +
                                    "from BLLSysDB.dbo.t_ProductStock A " +
                                    "inner join BLLSysDB.dbo.t_Warehouse WH " +
                                    "on  A.WarehouseID=WH.WarehouseID " +
                                    "where WH.WarehouseParentID not in (1,9,10) " +
                                    "group by ProductID) AA " +
                                    "inner join BLLSysDB.dbo.v_ProductDetails Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sResult = sResult + (string)reader["ASGName"] + ": Qty=";
                    sResult = sResult + reader["StockQty"].ToString() + " Val=Tk. ";
                    sResult = sResult + oTELLib.TakaFormat(Convert.ToDouble(reader["StockVal"].ToString())) + "\n";

                }

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetBLLASGWiseSaleLY()
        {
            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM BLLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "BLLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()) -1) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()))) AND " +
                                    "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()))) AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM BLLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "BLLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()) - 1) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()))) AND " +
                                    "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()))) AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join BLLSysDB.dbo.v_ProductDetails Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    //Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                //string X = Qty + " (" + sResult + ")";

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetBLLASGWiseSaleYTD()
        {
            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM BLLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "BLLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND " +
                                    "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM BLLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "BLLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND " +
                                    "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join BLLSysDB.dbo.v_ProductDetails Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    //Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                //string X = Qty + " (" + sResult + ")";

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetBLLASGWiseSaleMTD()
        {
            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM BLLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "BLLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                    "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                                    "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM BLLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "BLLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                    "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                                    "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join BLLSysDB.dbo.v_ProductDetails Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    //Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                //string X = Qty + " (" + sResult + ")";

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetBLLASGWiseSaleLM()
        {
            string sResult = "";
            double Qty = 0;
            _TELLib = new TELLib();
            DateTime dFDLM = _TELLib.FirstDayofLastMonth(DateTime.Today);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM BLLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "BLLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN '" + dFDLM + "' AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                    "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM BLLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "BLLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN '" + dFDLM + "' AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                    "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join BLLSysDB.dbo.v_ProductDetails Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    //Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                //string X = Qty + " (" + sResult + ")";

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetBLLASGWiseSaleWTD()
        {
            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            DateTime dtFromDate = oTELLib.FirstDayOfWeek(DateTime.Today);
            DateTime dtToDate = dtFromDate.Date.AddDays(8);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT     ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM BLLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "BLLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM BLLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "BLLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join BLLSysDB.dbo.v_ProductDetails Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.Parameters.AddWithValue("im.InvoiceDate", dtFromDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dtToDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dtToDate);

                cmd.Parameters.AddWithValue("im.InvoiceDate", dtFromDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dtToDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dtToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    //Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                //string X = Qty + " (" + sResult + ")";

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetBLLASGWiseSaleDTD()
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);

            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText =   "select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT     ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM BLLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "BLLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? " +
                                    "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM BLLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "BLLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? " +
                                    "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join BLLSysDB.dbo.v_ProductDetails Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    //Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                //string X = Qty + " (" + sResult + ")";

                reader.Close();
                return sResult;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSPTOBLL GetBLLTOReport()
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);
            DSPTOBLL oDSPTOBLL = new DSPTOBLL();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select isnull(CMTOTEBLSec,0) As CurrentMonthSS,isnull(MTDPriTO,0) AS MTDSales,isnull(LMTDPriTO,0) AS LMMTDSales, AreaID, AreaName, " +
                                  "isnull(round (((MTDPriTO-LMTDPriTO)/nullif(LMTDPriTO,0))*100,0),0) as PriGth ,isnull(TGTTO,0) AS PMTarget, isnull(round((MTDPriTO/nullif(TGTTO,0))*100,0),0)as PriAch, "  +
                                  "isnull(round((CMTOTEBLSec/nullif(TGTTO,0))*100,0),0)as SecAch, isnull(LMTOTEBLSec,0) as LMMTDSec,isnull((((CMTOTEBLSec-LMTOTEBLSec)*100/nullif(LMTOTEBLSec,0))),0) as SecGth " +

                                  "from " +
                                  "( " +

                                  "select AreaID, AreaName, sum(TGTTO)as TGTTO, sum(MTDPriTO) as MTDPriTO, sum(LMTDPriTO)as LMTDPriTO, sum(CMTOTEBLSec)as CMTOTEBLSec, sum(LMTOTEBLSec)as LMTOTEBLSec " +
                                  "from " +
                                  "(  " +
                                  "select AreaID, AreaName,final.CustomerCode,TGTTO,MTDPriTO,LMTDPriTO,CMTOTEBLSec,LMTOTEBLSec " +
                                  "from " +
                                  "( " +
                                  "select isnull(F1.CustomerCode,F2.CustomerCode) as CustomerCode,  isnull(TGTTO,0)as TGTTO, isnull(MTDPriTO,0)as MTDPriTO, isnull(LMTDPriTO,0)as LMTDPriTO, " +
                                  "ISNULL(F2.CMTOTEBLSec, 0) AS CMTOTEBLSec, ISNULL(F2.LMTOTEBLSec, 0) AS LMTOTEBLSec  " +
                                  "from " +
                                  "( " +
                                  "select isnull(Q1.CustomerCode,Q2.CustomerCode) as CustomerCode,  isnull(TGTTO,0)as TGTTO, isnull(MTDPriTO,0)as MTDPriTO, isnull(LMTDPriTO,0)as LMTDPriTO " +
                                  "from " +
                                  "( " +
                                  "SELECT     ISNULL(MTD.CustomerCode, TMonth.CustomerCode) AS CustomerCode, ISNULL(TMonth.MonthAmount, 0) AS MTDPriTO,  " +
                                  "ISNULL(MTD.LMTDAmount, 0) AS LMTDPriTO  " +
                                  "FROM   " + 
                                  "( " +
                                  "SELECT CustomerCode, SUM(Amount) AS MonthAmount  " +
                                  "FROM   " +
                                  "( " +
                                  "SELECT CustomerCode, ISNULL(SUM(crAmount) - ABS(SUM(drAmount)), 0) AS Amount  " +
                                  "FROM  " +
                                  "( " +
                                  "SELECT v.CustomerCode, SUM(a.InvoiceAmount) AS crAmount, 0 AS drAmount  " +
                                  "FROM BLLSysDB.dbo.t_SalesInvoice a, BLLSysDB.dbo.v_CustomerDetails v " +
                                  "where  a.CustomerID = v.CustomerID  and a.InvoiceDate>= CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+0,0),106) " +
                                  "AND a.InvoiceDate <  DATEADD(day, 0, CONVERT(VARCHAR(25), DATEADD(month, 0, GETDATE()), 106)) " +
                                  "AND a.InvoiceTypeID IN (1, 2, 4, 5) AND a.InvoiceStatus NOT IN (3) AND v.ChannelID IN (2, 12) " +
                                  "GROUP BY v.CustomerCode " +
 
                                  "UNION ALL " +

                                  "SELECT     v.CustomerCode, 0 AS crAmount, SUM(a.InvoiceAmount) AS drAmount  " + 
                                  "FROM BLLSysDB.dbo.t_SalesInvoice AS a,  BLLSysDB.dbo.v_CustomerDetails  v  " +
                                  "where  a.CustomerID = v.CustomerID  and a.InvoiceDate >= CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+0,0),106)  " + 
                                  "AND (a.InvoiceDate < DATEADD(day, 0, CONVERT(VARCHAR(25), DATEADD(month, 0, GETDATE()), 106))) " +
                                  "AND (a.InvoiceTypeID IN (6, 7, 8, 9, 10, 12)) AND (a.InvoiceStatus NOT IN (3)) AND (v.ChannelID IN (2, 12)) " +
                                  "GROUP BY v.CustomerCode" +
                                  ") AS p2 GROUP BY CustomerCode " +
                                  ") AS TELBLL  " +
                                 " GROUP BY CustomerCode " +
                                 ") AS TMonth  " +

                                 " FULL OUTER JOIN " + 
                                 " ( " +
                                 "SELECT  CustomerCode, SUM(Amount) AS LMTDAmount " +
                                 "FROM  " +
                                 "( " +
                                 "SELECT CustomerCode, ISNULL(SUM(crAmount) - ABS(SUM(drAmount)), 0) AS Amount " +
                                 "FROM   " +
                                 "(  " +
                                 "SELECT v.CustomerCode, SUM(a.InvoiceAmount) AS crAmount, 0 AS drAmount  " +
                                 "FROM  BLLSysDB.dbo.t_SalesInvoice a,  BLLSysDB.dbo.v_CustomerDetails v " +
                                 "where a.CustomerID = v.CustomerID and a.InvoiceDate >=  CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-1,0),106) " +
                                 "AND a.InvoiceDate < DATEADD(day, 0, CONVERT(VARCHAR(25), DATEADD(month, -1, GETDATE()), 106)) AND (a.InvoiceTypeID IN (1,2,4,5)) " + 
                                 "AND (a.InvoiceStatus NOT IN (3)) AND (v.ChannelID IN (2, 12))  " +
                                 "GROUP BY v.CustomerCode  " +
 
                                 "UNION ALL  " +

                                 "SELECT  v.CustomerCode, 0 AS crAmount, SUM(a.InvoiceAmount) AS drAmount  " +
                                 "FROM BLLSysDB.dbo.t_SalesInvoice a, BLLSysDB.dbo.v_CustomerDetails v  " +
                                 "where a.CustomerID = v.CustomerID and a.InvoiceDate >= CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-1,0),106) " +
                                 " and a.InvoiceDate <  CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+0,0),106) AND  (a.InvoiceTypeID IN (6, 7, 8, 9, 10, 12)) AND (a.InvoiceStatus NOT IN (3)) AND (v.ChannelID IN (2, 12)) " +
                                 "GROUP BY v.CustomerCode " +
                                 ") AS p2_1  " +
                                 "GROUP BY CustomerCode " +
                                 " ) AS TELBLLLM  " +
                                 "GROUP BY CustomerCode " +
                                 ") AS MTD  ON TMonth.CustomerCode = MTD.CustomerCode " +
                                 " ) as Q1 " +

                                 "full outer join " +
                                 "( " +
                                 "SELECT b.CustomerCode, b.CustomerID, SUM(a.Turnover) AS TGTTO " +   
                                 "FROM  BLLSysDB.dbo.t_PlanBudgetTarget a, BLLSysDB.dbo.v_CustomerDetails b " +
                                 "where  a.MarketGroupID = b.CustomerID and a.PeriodDate >= CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+0,0),106) " +
                                 "AND  a.PeriodDate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and (b.ChannelID = 2) " +
                                 "GROUP BY  b.CustomerCode, b.CustomerID " +
                                 ")as Q2 on Q1.CustomerCode=Q2.CustomerCode " +
                                ")as F1 " +
                                "full outer join " +
                                "( " +
                                "SELECT  ISNULL(CM.CustomerID, LMTD.CustomerID)  AS Customercode, ISNULL(CM.CMTOTEBL, 0) AS CMTOTEBLSec, ISNULL(LMTD.LMTOTEBL, 0) AS LMTOTEBLSec " +
                                "FROM  " +
                                "( " +
                                "SELECT     CustomerID, SUM(TEBL) AS CMTOTEBL " +
                                "FROM  TELSysDB.dbo.t_SMSDailySecondarySalesCollection  " +
                               "WHERE (TranDate BETWEEN CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+0,0),106) AND  DATEADD(day, 0, CONVERT(VARCHAR(25), DATEADD(month, 0, GETDATE()), 106))) " + 
                               "AND  (TranDate <  DATEADD(day, 0, CONVERT(VARCHAR(25), DATEADD(month, 0, GETDATE()), 106))) " +
                               "GROUP BY CustomerID " +
                               ")  AS CM FULL OUTER JOIN  " + 
                               "(  " +
                               "SELECT CustomerID, SUM(TEBL) AS LMTOTEBL  FROM  TELSysDB.dbo.t_SMSDailySecondarySalesCollection   " +   
                               "WHERE  (TranDate >=  CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-1,0),106)) AND " +
                               "(TranDate < DATEADD(day, 0, CONVERT(VARCHAR(25), DATEADD(month, -1, GETDATE()), 106)))  " + 
                               "GROUP BY CustomerID " +
                               ")AS LMTD ON CM.CustomerID = LMTD.CustomerID " +
                               ") as F2 on F1.Customercode=F2.Customercode " +
                               ")as Final " +
                               "left outer join " +
                               "( " +
                               "select CustomerCode, AreaID, AreaName from BLLSysDB.dbo.v_Customerdetails" + 
                               ")as info on Final.CustomerCode=info.CustomerCode " +
                               ")as TTL " +
                               "where areaID not in (185) " +
                               "group by AreaID, AreaName " +
                               ") as GFinal"; 

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSPTOBLL.TOBLLRow oTOBLLRow = oDSPTOBLL.TOBLL.NewTOBLLRow();
                    oTOBLLRow.CurrentMonthSS = reader["CurrentMonthSS"].ToString();
                    oTOBLLRow.MTDSales = reader["MTDSales"].ToString();
                    oTOBLLRow.LMMTDSales = reader["LMMTDSales"].ToString();
                    oTOBLLRow.Areaid = reader["Areaid"].ToString();
                    oTOBLLRow.AreaName = reader["AreaName"].ToString();
                    oTOBLLRow.PriGth = reader["PriGth"].ToString();
                    oTOBLLRow.PMTarget = reader["PMTarget"].ToString();
                    oTOBLLRow.PriAch = reader["PriAch"].ToString();
                    oTOBLLRow.SecAch = reader["SecAch"].ToString();
                    oTOBLLRow.LMMTDSec = reader["LMMTDSec"].ToString();
                    oTOBLLRow.SecGth = reader["SecGth"].ToString();

                    oDSPTOBLL.TOBLL.AddTOBLLRow(oTOBLLRow);
                   
                    
    
                }

                oDSPTOBLL.AcceptChanges();

                reader.Close();
                return oDSPTOBLL;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSPBLLAndroidDashboard GetDSPBLLAndroidDashboard(string sAreaName, string sTerritoryName)
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);
            DSPBLLAndroidDashboard oDSPBLLAndroidDashboard = new DSPBLLAndroidDashboard();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select * from DWDB.dbo.t_BLLAndroidDashboard where Area like '%"+sAreaName+"%' and Territory like '%"+sTerritoryName+"%'";

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSPBLLAndroidDashboard.BLLAndroidDashboardRow oBLLAndroidDashboardRow = oDSPBLLAndroidDashboard.BLLAndroidDashboard.NewBLLAndroidDashboardRow();
                    oBLLAndroidDashboardRow.Area = reader["Area"].ToString();
                    oBLLAndroidDashboardRow.Territory = reader["Territory"].ToString();
                    oBLLAndroidDashboardRow.CustomerCode = reader["CustomerCode"].ToString();
                    oBLLAndroidDashboardRow.CustomerName = reader["CustomerName"].ToString();
                    oBLLAndroidDashboardRow.CurrentOutstanding = reader["CurrentOutstanding"].ToString();
                    oBLLAndroidDashboardRow.TGTPrimaryValue = reader["TGTPrimaryValue"].ToString();
                    oBLLAndroidDashboardRow.MTDPriSalesValue = reader["MTDPriSalesValue"].ToString();
                    oBLLAndroidDashboardRow.Ach = reader["Ach"].ToString();
                    oBLLAndroidDashboardRow.TGTSecondaryValue = reader["TGTSecondaryValue"].ToString();
                    oBLLAndroidDashboardRow.MTDSecSalesValue = reader["MTDSecSalesValue"].ToString();
                    oBLLAndroidDashboardRow.CurrentStockValue = reader["CurrentStockValue"].ToString();
                    oBLLAndroidDashboardRow.Ach1 = reader["Ach1"].ToString();

                    oDSPBLLAndroidDashboard.BLLAndroidDashboard.AddBLLAndroidDashboardRow(oBLLAndroidDashboardRow);
                    



                }

                oDSPBLLAndroidDashboard.AcceptChanges();

                reader.Close();
                return oDSPBLLAndroidDashboard;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSPBLLAreaWiseAndroidDashboard GetDSPBLLAreaWiseAndroidDashboard()
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);
            DSPBLLAreaWiseAndroidDashboard oDSPBLLAreaWiseAndroidDashboard = new DSPBLLAreaWiseAndroidDashboard();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select * from DWDB.dbo.t_BLLAreaWiseAndroidDashboard";

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSPBLLAreaWiseAndroidDashboard.BLLAreaWiseAndroidDashboardRow oBLLAreaWiseAndroidDashboardRow = oDSPBLLAreaWiseAndroidDashboard.BLLAreaWiseAndroidDashboard.NewBLLAreaWiseAndroidDashboardRow();
                  
                    oBLLAreaWiseAndroidDashboardRow.Area = reader["Area"].ToString();
                    oBLLAreaWiseAndroidDashboardRow.CurrentOutstanding = reader["CurrentOutstanding"].ToString();
                    oBLLAreaWiseAndroidDashboardRow.TGTPrimaryValue = reader["TGTPrimaryValue"].ToString();
                    oBLLAreaWiseAndroidDashboardRow.MTDPriSalesValue = reader["MTDPriSalesValue"].ToString();
                    oBLLAreaWiseAndroidDashboardRow.Ach = reader["Ach"].ToString();
                    oBLLAreaWiseAndroidDashboardRow.TGTSecondaryValue = reader["TGTSecondaryValue"].ToString();
                    oBLLAreaWiseAndroidDashboardRow.MTDSecSalesValue = reader["MTDSecSalesValue"].ToString();
                    oBLLAreaWiseAndroidDashboardRow.CurrentStockValue = reader["CurrentStockValue"].ToString();
                    oBLLAreaWiseAndroidDashboardRow.Ach1 = reader["Ach1"].ToString();

                    oDSPBLLAreaWiseAndroidDashboard.BLLAreaWiseAndroidDashboard.AddBLLAreaWiseAndroidDashboardRow(oBLLAreaWiseAndroidDashboardRow);
                    




                }

                oDSPBLLAreaWiseAndroidDashboard.AcceptChanges();

                reader.Close();
                return oDSPBLLAreaWiseAndroidDashboard;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSPBLLTerritoryWiseAndroidDashboard GetDSPBLLTerritoryWiseAndroidDashboard(string sAreaName)
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);
            DSPBLLTerritoryWiseAndroidDashboard oDSPBLLTerritoryWiseAndroidDashboard = new DSPBLLTerritoryWiseAndroidDashboard();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select * from [DWDB].[dbo].[t_BLLTerritoryWiseAndroidDashboard] where Area like '%"+sAreaName+"%' ";

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSPBLLTerritoryWiseAndroidDashboard.BLLTerritoryWiseAndroidDashboardRow oBLLTerritoryWiseAndroidDashboardRow = oDSPBLLTerritoryWiseAndroidDashboard.BLLTerritoryWiseAndroidDashboard.NewBLLTerritoryWiseAndroidDashboardRow();
                    oBLLTerritoryWiseAndroidDashboardRow.Area = reader["Area"].ToString();
                    oBLLTerritoryWiseAndroidDashboardRow.Territory = reader["Territory"].ToString();
                    oBLLTerritoryWiseAndroidDashboardRow.CurrentOutstanding = reader["CurrentOutstanding"].ToString();
                    oBLLTerritoryWiseAndroidDashboardRow.TGTPrimaryValue = reader["TGTPrimaryValue"].ToString();
                    oBLLTerritoryWiseAndroidDashboardRow.MTDPriSalesValue = reader["MTDPriSalesValue"].ToString();
                    oBLLTerritoryWiseAndroidDashboardRow.Ach = reader["Ach"].ToString();
                    oBLLTerritoryWiseAndroidDashboardRow.TGTSecondaryValue = reader["TGTSecondaryValue"].ToString();
                    oBLLTerritoryWiseAndroidDashboardRow.MTDSecSalesValue = reader["MTDSecSalesValue"].ToString();
                    oBLLTerritoryWiseAndroidDashboardRow.CurrentStockValue = reader["CurrentStockValue"].ToString();
                    oBLLTerritoryWiseAndroidDashboardRow.Ach1 = reader["Ach1"].ToString();

                    oDSPBLLTerritoryWiseAndroidDashboard.BLLTerritoryWiseAndroidDashboard.AddBLLTerritoryWiseAndroidDashboardRow(oBLLTerritoryWiseAndroidDashboardRow);




                }

                oDSPBLLTerritoryWiseAndroidDashboard.AcceptChanges();

                reader.Close();
                return oDSPBLLTerritoryWiseAndroidDashboard;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSPSalesTarget GetSalesAcheivementReportQtyBLL(string sASGName,string sBrandDesc)
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);
            DSPSalesTarget oDSPTOBLL = new DSPSalesTarget();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select AreaID,AreaName,ASGName, BrandDesc, TGTTO, SalesQty,isnull(round((SalesQty/nullif(TGTTO,0))*100,0),0)as Ach " +
                                  "from " +
                                  "( " +
                                  "select AreaID,AreaName,ASGName, BrandDesc,sum(TGTTO)as TGTTO, sum(SalesQty)as SalesQty " +
                                  "from " +
                                  "( " +
                                  "select final.CustomerCode,final.ASGName,final.BrandDesc, AreaID,AreaName, TGTTO, SalesQty " +
                                  "from " +
                                  "( " +
                                  "select isnull(Q1.CustomerCode,Q2.customerCode)as CustomerCode, Q2.ASGName, Q2.BrandDesc, isnull(TGTTO,0)as TGTTO, isnull(SalesQty,0)as SalesQty " +
                                  "from " +
                                  "( " +
                                  "SELECT b.CustomerCode, b.CustomerID, SUM(a.Qty) AS TGTTO  " +
                                  "FROM  BLLSysDB.dbo.t_PlanBudgetTarget a, BLLSysDB.dbo.v_CustomerDetails b " +
                                  "where  a.MarketGroupID = b.CustomerID and a.PeriodDate >=  CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+0,0),106) " +
                                  "AND  a.PeriodDate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and (b.ChannelID = 2) " +
                                  "GROUP BY  b.CustomerCode, b.CustomerID " +
                                  ")As Q1 " +

                                  "Full outer join " +
                                  "( " +


                                  "select customerCode, ASGName, BrandDesc, ProductCode, ProductName, cast(convert(nvarchar(12),InvoiceDate,106)as Datetime) as InvoiceDate, sum(SalesQty)as SalesQty " +
                                  "from " +
                                  "( " +
                                  "select customerCode, ASGName, BrandDesc, ProductCode, ProductName, InvoiceDate, isnull (sum(QtySA)- sum(QtyRA),0) as SalesQty " +
                                  "from " +
                                  "( " +
                                  "select  customerCode, ASGName, BrandDesc,ProductCode, ProductName, InvoiceDate, sum (Quantity) as QtySA, 0 as  QtyRA  " +
                                  "from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d " +
                                  "where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (1,2,3,4,5,17) and invoiceStatus not in (3) " +
                                  "and invoicedate between CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-0,0),106)  and CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "and invoicedate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "group by customerCode, ASGName, BrandDesc,b.ProductID, ProductCode, ProductName, InvoiceDate " +

                                  "union all " +

                                  "select  customerCode, ASGName, BrandDesc, ProductCode, ProductName, InvoiceDate, 0 as  QtySA,  sum(Quantity) as QtyRA " +
                                "from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d " +
                                "where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3) " +
                                "and invoicedate between CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-0,0),106) and CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and invoicedate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                "group by  customerCode,ASGName,BrandDesc, ProductCode, ProductName, InvoiceDate " +
                                ") as b " +
                                "group by  customerCode, ASGName, BrandDesc, ProductCode, ProductName, InvoiceDate " +
                                ") TELBLL " +
                                "group by customerCode, ASGName, BrandDesc, ProductCode, ProductName, InvoiceDate " +

                                ")As Q2 on Q1.CustomerCode=Q2.customerCode " +
                                ") as Final " +
                                "inner join " +
                                "( " +
                                "select CustomerCode,AreaID,AreaName from v_CustomerDetails " +
                                ")as Cust on Final.CustomerCode=Cust.CustomerCode " +

                                ")as QQ1 " +
                                "group by AreaID,AreaName ,ASGName, BrandDesc " +
                                ") as QQ3 " +
                                "where ASGName like '%"+sASGName+"%' and BrandDesc like '%"+sBrandDesc+"%' ";

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSPSalesTarget.SalesTargetRow oTOBLLRow = oDSPTOBLL.SalesTarget.NewSalesTargetRow();

                    oTOBLLRow.AraeID = reader["AreaID"].ToString();
                    oTOBLLRow.AreaName = reader["AreaName"].ToString();
                    oTOBLLRow.PMTarget = reader["TGTTO"].ToString();
                    oTOBLLRow.PriGth = reader["SalesQty"].ToString();
                    oTOBLLRow.PriAch = reader["Ach"].ToString();


                    oDSPTOBLL.SalesTarget.AddSalesTargetRow(oTOBLLRow);



                }

                oDSPTOBLL.AcceptChanges();

                reader.Close();
                return oDSPTOBLL;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSPSalesTarget GetSalesAcheivementReportBLL()
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);
            DSPSalesTarget oDSPTOBLL = new DSPSalesTarget();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select AreaID,AreaName, TGTTO, SalesTO,isnull(round((SalesTO/nullif(TGTTO,0))*100,0),0)as Ach " +
                                  "from " +
                                  "( " +

                                  "select AreaID,AreaName,sum(TGTTO)as TGTTO, sum(SalesTO)as SalesTO " +
                                  "from " +
                                  "( " +
                                  "select final.CustomerCode, AreaID,AreaName, TGTTO, SalesTO " +
                                  "from " +
                                  "( " +
                                  "select isnull(Q1.CustomerCode,Q2.CustomerCode)as CustomerCode, isnull(TGTTO,0)as TGTTO, isnull(Amount,0)as SalesTO " +
                                  "from " +
                                  "( " +
                                  "SELECT b.CustomerCode, b.CustomerID, SUM(a.Turnover) AS TGTTO " +    
                                  "FROM  BLLSysDB.dbo.t_PlanBudgetTarget a, BLLSysDB.dbo.v_CustomerDetails b  " +
                                  "where  a.MarketGroupID = b.CustomerID and a.PeriodDate >=  CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+0,0),106) " +
                                  "AND  a.PeriodDate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and (b.ChannelID = 2) " +
                                  "GROUP BY  b.CustomerCode, b.CustomerID " +
                                  ")As Q1 " +

                                  "Full outer join " +
                                  "( " +
                                  "select CustomerCode, sum (Amount)as Amount " +    
                                  "from " +
                                  "( " + 
                                  "select CustomerCode,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount " +      
                                  "from " +    
                                  "( " +   
                                  "select CustomerCode,sum(invoiceamount) as crAmount, 0 as drAmount " +
                                  "from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " + 
                                  "where invoicedate between CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-0,0),106)  and CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "and invoicedate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                                  "group by  CustomerCode " +
                                  "union all  " +    
                                  "select CustomerCode, 0 as crAmount,sum(invoiceamount) as drAmount " +
                                  "from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " +     
                                  "where invoicedate between CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-0,0),106) and CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and invoicedate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                                  "group by  CustomerCode " + 
                                  ")as p2  " +  
                                  "group by CustomerCode " +
                                  ") as TELBLL " +
                                  "group by  CustomerCode " +
                                  ")As Q2 on Q1.CustomerCode=Q2.CustomerCode " +
                                  ") as Final " +
                                  "inner join " +
                                  "( " +
                                  "select CustomerCode,AreaID,AreaName from BLLSysDB.dbo.v_CustomerDetails " +
                                  ")as Cust on Final.CustomerCode=Cust.CustomerCode " +
                                  ")as QQ1 " +
                                  "group by AreaID,AreaName " +
                                  ") as QQ3";

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSPSalesTarget.SalesTargetRow oTOBLLRow = oDSPTOBLL.SalesTarget.NewSalesTargetRow();

                    oTOBLLRow.AraeID = reader["AreaID"].ToString();
                    oTOBLLRow.AreaName = reader["AreaName"].ToString();
                    oTOBLLRow.PMTarget = reader["TGTTO"].ToString();
                    oTOBLLRow.PriGth = reader["SalesTO"].ToString();
                    oTOBLLRow.PriAch = reader["Ach"].ToString();


                    oDSPTOBLL.SalesTarget.AddSalesTargetRow(oTOBLLRow);



                }

                oDSPTOBLL.AcceptChanges();

                reader.Close();
                return oDSPTOBLL;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSPTerritorySalesTarget GetTerritorySalesAcheivementReportBLL(string sAreaName)
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);
            DSPTerritorySalesTarget oDSPTerritorySalesTarget = new DSPTerritorySalesTarget();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select AreaID,AreaName,TerritoryID,TerritoryName, TGTTO, SalesTO,isnull(round((SalesTO/nullif(TGTTO,0))*100,0),0)as Ach " +
                                  "from  " +
                                  "( " +
                                  "select AreaID,AreaName,TerritoryID,TerritoryName,sum(TGTTO)as TGTTO, sum(SalesTO)as SalesTO " + 
                                  "from  " +
                                  "( " + 
                                  "select final.CustomerCode, AreaID,AreaName,TerritoryID,TerritoryName, TGTTO, SalesTO " + 
                                  "from  " +
                                  "( " + 
                                  "select isnull(Q1.CustomerCode,Q2.CustomerCode)as CustomerCode, isnull(TGTTO,0)as TGTTO, isnull(Amount,0)as SalesTO " +
                                  "from " +
                                  "( " + 
                                  "SELECT b.CustomerCode, b.CustomerID, SUM(a.Turnover) AS TGTTO " +     
                                  "FROM  BLLSysDB.dbo.t_PlanBudgetTarget a, BLLSysDB.dbo.v_CustomerDetails b   " +
                                  "where  a.MarketGroupID = b.CustomerID and a.PeriodDate >=  CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+0,0),106) " +
                                  "AND  a.PeriodDate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and (b.ChannelID = 2) " +
                                  "GROUP BY  b.CustomerCode, b.CustomerID " +
                                  ")As Q1 " +

                                  "Full outer join " +
                                  "( " +
                                  "select CustomerCode, sum (Amount)as Amount " +    
                                  "from " +
                                  "(  " +
                                  "select CustomerCode,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount  " +     
                                  "from " +    
                                  "(  " +  
                                  "select CustomerCode,sum(invoiceamount) as crAmount, 0 as drAmount " +
                                  "from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " + 
                                  "where invoicedate between CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-0,0),106)  and CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "and invoicedate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " + 
                                  "and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                                  "group by  CustomerCode  " +
                                  "union all " +      
                                  "select CustomerCode, 0 as crAmount,sum(invoiceamount) as drAmount " + 
                                  "from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v " +      
                                  "where invoicedate between CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-0,0),106) and CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and invoicedate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                                  "group by  CustomerCode  " + 
                                  ")as p2  " +   
                                  "group by CustomerCode " +
                                  ") as TELBLL " + 
                                  "group by  CustomerCode " + 
                                  ")As Q2 on Q1.CustomerCode=Q2.CustomerCode  " +
                                  ") as Final  " +
                                  "inner join  " +
                                  "( " +  
                                  "select CustomerCode,AreaID,AreaName,TerritoryID,TerritoryName from BLLSysDB.dbo.v_CustomerDetails " +
                                  ")as Cust on Final.CustomerCode=Cust.CustomerCode " + 
                                  ")as QQ1 " + 
                                  "group by AreaID,AreaName,TerritoryID,TerritoryName " +
                                  ") as QQ3 where AreaName like '%"+sAreaName+"%'";
                
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);4
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSPTerritorySalesTarget.TerritorySalesTargetRow oTerritorySalesTargetRow = oDSPTerritorySalesTarget.TerritorySalesTarget.NewTerritorySalesTargetRow();


                    oTerritorySalesTargetRow.AraeID = reader["AreaID"].ToString();
                    oTerritorySalesTargetRow.AreaName = reader["AreaName"].ToString();
                    oTerritorySalesTargetRow.TerritoryID = reader["TerritoryID"].ToString();
                    oTerritorySalesTargetRow.TerritoryName = reader["TerritoryName"].ToString();
                    oTerritorySalesTargetRow.PMTarget = reader["TGTTO"].ToString();
                    oTerritorySalesTargetRow.PriGth = reader["SalesTO"].ToString();
                    oTerritorySalesTargetRow.PriAch = reader["Ach"].ToString();

                    oDSPTerritorySalesTarget.TerritorySalesTarget.AddTerritorySalesTargetRow(oTerritorySalesTargetRow);
                    



                }

                oDSPTerritorySalesTarget.AcceptChanges();

                reader.Close();
                return oDSPTerritorySalesTarget;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSPTerritorySalesTarget GetTerritorySalesAcheivementReportQtyBLL(string sAreaName,string sASGName,string sBrandDesc)
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);
            DSPTerritorySalesTarget oDSPTerritorySalesTarget = new DSPTerritorySalesTarget();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select AreaID,AreaName,TerritoryID,TerritoryName, ASGName,BrandDesc,TGTTO, SalesQty,isnull(round((SalesQty/nullif(TGTTO,0))*100,0),0)as Ach " +
                                  "from " +
                                  "( " +
                                  "select AreaID,AreaName,TerritoryID,TerritoryName,ASGName,BrandDesc,sum(TGTTO)as TGTTO, sum(SalesQty)as SalesQty " +
                                  "from " +
                                  "( " +
                                  "select final.CustomerCode,final.ASGName,final.BrandDesc, AreaID,AreaName,TerritoryID,TerritoryName, TGTTO, SalesQty " +
                                  "from " +
                                  "( " +
                                  "select isnull(Q1.CustomerCode,Q2.customerCode)as CustomerCode,Q2.ASGName, Q2.BrandDesc ,isnull(TGTTO,0)as TGTTO, isnull(SalesQty,0)as SalesQty " +
                                  "from " +
                                  "( " +
                                  "SELECT b.CustomerCode, b.CustomerID, SUM(a.Qty) AS TGTTO " +
                                  "FROM  BLLSysDB.dbo.t_PlanBudgetTarget a, BLLSysDB.dbo.v_CustomerDetails b " +
                                  "where  a.MarketGroupID = b.CustomerID and a.PeriodDate >=  CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+0,0),106) " +
                                  "AND  a.PeriodDate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and (b.ChannelID = 2) " +
                                  "GROUP BY  b.CustomerCode, b.CustomerID " +
                                  ")As Q1 " +

                                  "Full outer join " +
                                  "( " +


                                  "select customerCode, ASGName, BrandDesc, ProductCode, ProductName, cast(convert(nvarchar(12),InvoiceDate,106)as Datetime) as InvoiceDate, sum(SalesQty)as SalesQty " +
                                  "from " +
                                  "( " +
                                  "select customerCode, ASGName, BrandDesc, ProductCode, ProductName, InvoiceDate, isnull (sum(QtySA)- sum(QtyRA),0) as SalesQty " +
                                  "from " +
                                  "( " +
                                  "select  customerCode, ASGName, BrandDesc,ProductCode, ProductName, InvoiceDate, sum (Quantity) as QtySA, 0 as  QtyRA " +
                                  "from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d " +
                                  "where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (1,2,3,4,5,17) and invoiceStatus not in (3) " +
                                  "and invoicedate between CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-0,0),106)  and CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "and invoicedate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "group by customerCode, ASGName, BrandDesc,b.ProductID, ProductCode, ProductName, InvoiceDate " +

                                  "union all " +

                                  "select  customerCode, ASGName, BrandDesc, ProductCode, ProductName, InvoiceDate, 0 as  QtySA,  sum(Quantity) as QtyRA " +
                                  "from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d " +
                                  "where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3) " +
                                  "and invoicedate between CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-0,0),106) and CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and invoicedate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "group by  customerCode,ASGName,BrandDesc, ProductCode, ProductName, InvoiceDate " +
                                  ") as b " +
                                  "group by  customerCode, ASGName, BrandDesc, ProductCode, ProductName, InvoiceDate " +
                                  ") TELBLL " +
                                  "group by customerCode, ASGName, BrandDesc, ProductCode, ProductName, InvoiceDate " +

                                  ")As Q2 on Q1.CustomerCode=Q2.customerCode " +
                                  ") as Final " +
                                  "inner join " +
                                  "( " +
                                  "select CustomerCode,AreaID,AreaName,TerritoryID,TerritoryName from v_CustomerDetails " +
                                  ")as Cust on Final.CustomerCode=Cust.CustomerCode " +

                                  ")as QQ1 " +
                                  "group by AreaID,AreaName,TerritoryID,TerritoryName ,ASGName,BrandDesc " +
                                  ") as QQ3 " +
                                  "where AreaName like '%"+sAreaName+"%'  and ASGName like '%"+sASGName+"%' and BrandDesc l;xike '%"+sBrandDesc+"%'";


                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);4
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSPTerritorySalesTarget.TerritorySalesTargetRow oTerritorySalesTargetRow = oDSPTerritorySalesTarget.TerritorySalesTarget.NewTerritorySalesTargetRow();


                    oTerritorySalesTargetRow.AraeID = reader["AreaID"].ToString();
                    oTerritorySalesTargetRow.AreaName = reader["AreaName"].ToString();
                    oTerritorySalesTargetRow.TerritoryID = reader["TerritoryID"].ToString();
                    oTerritorySalesTargetRow.TerritoryName = reader["TerritoryName"].ToString();
                    oTerritorySalesTargetRow.PMTarget = reader["TGTTO"].ToString();
                    oTerritorySalesTargetRow.PriGth = reader["SalesQty"].ToString();
                    oTerritorySalesTargetRow.PriAch = reader["Ach"].ToString();

                    oDSPTerritorySalesTarget.TerritorySalesTarget.AddTerritorySalesTargetRow(oTerritorySalesTargetRow);




                }

                oDSPTerritorySalesTarget.AcceptChanges();

                reader.Close();
                return oDSPTerritorySalesTarget;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSPTerritorySalesTarget GetAreaTerritorySalesAcheivementReportBLL(string sAreaName,string sTerritoryName)
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);
            DSPTerritorySalesTarget oDSPTerritorySalesTarget = new DSPTerritorySalesTarget();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select final.CustomerCode,final.CustomerName, AreaID,AreaName,TerritoryID,TerritoryName, TGTTO, SalesTO ,isnull(round((SalesTO/nullif(TGTTO,0))*100,0),0)as Ach  " + 
                                  "from " +  
                                  "( " +   
                                  "select isnull(Q1.CustomerCode,Q2.CustomerCode)as CustomerCode,Q2.CustomerName, isnull(TGTTO,0)as TGTTO, isnull(Amount,0)as SalesTO " + 
                                  "from " + 
                                  "( " +  
                                  "SELECT b.CustomerCode, b.CustomerID,b.CustomerName, SUM(a.Turnover) AS TGTTO  " +    
                                  "FROM  BLLSysDB.dbo.t_PlanBudgetTarget a, BLLSysDB.dbo.v_CustomerDetails b  " + 
                                  "where  a.MarketGroupID = b.CustomerID and a.PeriodDate >=  CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+0,0),106) " +
                                  "AND  a.PeriodDate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and (b.ChannelID = 2) " +
                                  "GROUP BY  b.CustomerCode, b.CustomerID ,b.CustomerName " +
                                  ")As Q1 " + 

                                  "Full outer join " + 
                                  "( " + 
                                  "select CustomerCode,CustomerName, sum (Amount)as Amount " +     
                                  "from " + 
                                  "( " +  
                                  "select CustomerCode,CustomerName,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount " +       
                                  "from " +     
                                  "( " +    
                                  "select CustomerCode,CustomerName,sum(invoiceamount) as crAmount, 0 as drAmount " +
                                  "from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " +  
                                  "where invoicedate between CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-0,0),106)  and CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "and invoicedate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " + 
                                  "and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                                  "group by CustomerCode  ,CustomerName " +
                                  "union all  " +     
                                  "select CustomerCode,CustomerName, 0 as crAmount,sum(invoiceamount) as drAmount " + 
                                  "from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v    " +   
                                  "where invoicedate between CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-0,0),106) and CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and invoicedate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " + 
                                  "group by  CustomerCode ,CustomerName " + 
                                  ")as p2  " +    
                                  "group by CustomerCode,CustomerName " +
                                  ") as TELBLL  " +
                                  "group by  CustomerCode ,CustomerName " +
                                  ")As Q2 on Q1.CustomerCode=Q2.CustomerCode " + 
                                  ") as Final " + 
                                  "inner join " +  
                                  "( " +  
                                  "select CustomerCode,CustomerName,AreaID,AreaName,TerritoryID,TerritoryName from BLLSysDB.dbo.v_CustomerDetails " +
                                  ")as Cust on Final.CustomerCode=Cust.CustomerCode  " +
                                  "where AreaName like '%"+sAreaName+"%' and TerritoryName like '%"+sTerritoryName+"%' ";

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);4
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSPTerritorySalesTarget.TerritorySalesTargetRow oTerritorySalesTargetRow = oDSPTerritorySalesTarget.TerritorySalesTarget.NewTerritorySalesTargetRow();


                    oTerritorySalesTargetRow.AraeID = reader["AreaID"].ToString();
                    oTerritorySalesTargetRow.AreaName = reader["AreaName"].ToString();
                    oTerritorySalesTargetRow.TerritoryID = reader["TerritoryID"].ToString();
                    oTerritorySalesTargetRow.TerritoryName = reader["TerritoryName"].ToString();
                    oTerritorySalesTargetRow.PMTarget = reader["TGTTO"].ToString();
                    oTerritorySalesTargetRow.PriGth = reader["SalesTO"].ToString();
                    oTerritorySalesTargetRow.PriAch = reader["Ach"].ToString();
                    oTerritorySalesTargetRow.CustomerName = reader["CustomerName"].ToString();

                    oDSPTerritorySalesTarget.TerritorySalesTarget.AddTerritorySalesTargetRow(oTerritorySalesTargetRow);




                }

                oDSPTerritorySalesTarget.AcceptChanges();

                reader.Close();
                return oDSPTerritorySalesTarget;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSPTerritorySalesTarget GetAreaTerritorySalesAcheivementReportQtyBLL(string sAreaName, string sTerritoryName,string sASGName,string sBrandDesc)
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);
            DSPTerritorySalesTarget oDSPTerritorySalesTarget = new DSPTerritorySalesTarget();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "select AreaID,AreaName,TerritoryID,TerritoryName, ASGName,BrandDesc,TGTTO, SalesQty,isnull(round((SalesQty/nullif(TGTTO,0))*100,0),0)as Ach " +
                                  "from " + 
                                  "( " +
                                  "select AreaID,AreaName,TerritoryID,TerritoryName,ASGName,BrandDesc,sum(TGTTO)as TGTTO, sum(SalesQty)as SalesQty " +
                                  "from " + 
                                  "( " +
                                  "select final.CustomerCode,final.ASGName,final.BrandDesc, AreaID,AreaName,TerritoryID,TerritoryName, TGTTO, SalesQty " +
                                  "from " + 
                                  "( " + 
                                  "select isnull(Q1.CustomerCode,Q2.customerCode)as CustomerCode,Q2.ASGName, Q2.BrandDesc ,isnull(TGTTO,0)as TGTTO, isnull(SalesQty,0)as SalesQty " +
                                  "from " + 
                                  "( " + 
                                  "SELECT b.CustomerCode, b.CustomerID, SUM(a.Qty) AS TGTTO " +
                                  "FROM  BLLSysDB.dbo.t_PlanBudgetTarget a, BLLSysDB.dbo.v_CustomerDetails b " +
                                  "where  a.MarketGroupID = b.CustomerID and a.PeriodDate >=  CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+0,0),106) " +
                                  "AND  a.PeriodDate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and (b.ChannelID = 2) " +
                                  "GROUP BY  b.CustomerCode, b.CustomerID " +
                                  ")As Q1 " +

                                  "Full outer join " +
                                  "( " + 


                                  "select customerCode, ASGName, BrandDesc, ProductCode, ProductName, cast(convert(nvarchar(12),InvoiceDate,106)as Datetime) as InvoiceDate, sum(SalesQty)as SalesQty " +
                                  "from " + 
                                  "( " + 
                                  "select customerCode, ASGName, BrandDesc, ProductCode, ProductName, InvoiceDate, isnull (sum(QtySA)- sum(QtyRA),0) as SalesQty " +
                                  "from " + 
                                  "( " + 
                                  "select  customerCode, ASGName, BrandDesc,ProductCode, ProductName, InvoiceDate, sum (Quantity) as QtySA, 0 as  QtyRA " +
                                  "from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d " +
                                  "where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (1,2,3,4,5,17) and invoiceStatus not in (3) " +
                                  "and invoicedate between CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-0,0),106)  and CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "and invoicedate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "group by customerCode, ASGName, BrandDesc,b.ProductID, ProductCode, ProductName, InvoiceDate " +

                                  "union all " + 

                                  "select  customerCode, ASGName, BrandDesc, ProductCode, ProductName, InvoiceDate, 0 as  QtySA,  sum(Quantity) as QtyRA " +
                                  "from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d " +
                                  "where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3) " + 
                                  "and invoicedate between CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())-0,0),106) and CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) and invoicedate < CONVERT(VARCHAR(25),DATEADD(month,datediff(month,0,getdate())+1,0),106) " +
                                  "group by  customerCode,ASGName,BrandDesc, ProductCode, ProductName, InvoiceDate " +
                                  ") as b " +
                                  "group by  customerCode, ASGName, BrandDesc, ProductCode, ProductName, InvoiceDate " +
                                  ") TELBLL " +
                                  "group by customerCode, ASGName, BrandDesc, ProductCode, ProductName, InvoiceDate " +

                                  ")As Q2 on Q1.CustomerCode=Q2.customerCode " +
                                  ") as Final " +
                                  "inner join " +
                                  "( " + 
                                  "select CustomerCode,AreaID,AreaName,TerritoryID,TerritoryName from v_CustomerDetails " +
                                  ")as Cust on Final.CustomerCode=Cust.CustomerCode " +

                                  ")as QQ1 " + 
                                  "group by AreaID,AreaName,TerritoryID,TerritoryName ,ASGName,BrandDesc " +
                                  ") as QQ3 " +
                                  "where AreaName like '%"+sAreaName+"%' and TerritoryName like '%"+sTerritoryName+"%' and ASGName like '%"+sASGName+"%' and BrandDesc like '%"+sBrandDesc+"%'";

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);4
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                //cmd.Parameters.AddWithValue("im.InvoiceDate", dFromDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);
                //cmd.Parameters.AddWithValue("im.InvoiceDate", dToDate);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSPTerritorySalesTarget.TerritorySalesTargetRow oTerritorySalesTargetRow = oDSPTerritorySalesTarget.TerritorySalesTarget.NewTerritorySalesTargetRow();


                    oTerritorySalesTargetRow.AraeID = reader["AreaID"].ToString();
                    oTerritorySalesTargetRow.AreaName = reader["AreaName"].ToString();
                    oTerritorySalesTargetRow.TerritoryID = reader["TerritoryID"].ToString();
                    oTerritorySalesTargetRow.TerritoryName = reader["TerritoryName"].ToString();
                    oTerritorySalesTargetRow.PMTarget = reader["TGTTO"].ToString();
                    oTerritorySalesTargetRow.PriGth = reader["SalesQty"].ToString();
                    oTerritorySalesTargetRow.PriAch = reader["Ach"].ToString();
                    oTerritorySalesTargetRow.CustomerName = reader["CustomerName"].ToString();

                    oDSPTerritorySalesTarget.TerritorySalesTarget.AddTerritorySalesTargetRow(oTerritorySalesTargetRow);




                }

                oDSPTerritorySalesTarget.AcceptChanges();

                reader.Close();
                return oDSPTerritorySalesTarget;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetBLLReceivable()
        {
            TELLib oTELLib = new TELLib();
            string Receivable = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select Sum(Balance)*(-1) as Receivable from BLLSysDB.dbo.v_CustomerDetails ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Receivable = oTELLib.TakaFormat(Convert.ToDouble(reader["Receivable"].ToString()));
                }

                reader.Close();
                return Receivable;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

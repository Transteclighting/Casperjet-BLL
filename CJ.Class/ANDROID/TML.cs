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
    public class TML
    {
        public double GetTMLYTDSalesValue()
        {
            double nTMLYTDSaleValue = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select isnull(sum(p2.CRCYR) - abs(sum(p2.DbCYR)),0) as YTDSales " +
                                    "from " +
                                    "(    " +
                                    "select sum(Invoiceamount) as CRCYR, 0 as DbCYR " +
                                    "from TMLSysDB.dbo.t_salesInvoice " +
                                    "where (InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) " +
                                    "group by  CustomerID " +
                                    "union all " +
                                    "select 0 as CRCYR,sum(Invoiceamount) as DbCYR " +
                                    "from TMLSysDB.dbo.t_salesInvoice " +
                                    "where (InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3) " +
                                    ") " +
                                    "as p2  ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nTMLYTDSaleValue = Convert.ToDouble(reader["YTDSales"].ToString());

                }

                reader.Close();
                return nTMLYTDSaleValue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetTMLMTDSalesValue()
        {
            double nTMLMTDSaleValue = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select isnull(sum(p2.CRCYR) - abs(sum(p2.DbCYR)),0) as MTDSales  " +
                                "from  " +
                                "( " +
                                "select sum(Invoiceamount) as CRCYR, 0 as DbCYR " +
                                "from TMLSysDB.dbo.t_salesInvoice " +
                                "where  (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) " +
                                "group by  CustomerID " +
                                "union all " +
                                "select 0 as CRCYR,sum(Invoiceamount) as DbCYR " +
                                "from TMLSysDB.dbo.t_salesInvoice " +
                                "where (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3) " +
                                ") " +
                                "as p2  ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nTMLMTDSaleValue = Convert.ToDouble(reader["MTDSales"].ToString());

                }

                reader.Close();
                return nTMLMTDSaleValue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetTMLLMSalesValue()
        {
            TELLib oTELLib = new TELLib();
            DateTime Today = DateTime.Now.Date;
            DateTime FirstDateOfCurrentMonth = oTELLib.FirstDayofMonth(Today);
            DateTime FistDateOfLastMonth = oTELLib.FirstDayofLastMonth(Today);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double sResult = 0;
            try
            {
                //cmd.CommandText =" select isnull(sum(p2.CRCYR) - abs(sum(p2.DbCYR)),0) as LMSales  " +
                //                    "from   " +
                //                    "(  " +
                //                    "select sum(Invoiceamount) as CRCYR, 0 as DbCYR  " +
                //                    "from TMLSysDB.dbo.t_salesInvoice  " +
                //                    "where  InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())-1) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  " +
                //                    "group by  CustomerID  " +
                //                    "union all  " +
                //                    "select 0 as CRCYR,sum(Invoiceamount) as DbCYR  " +
                //                    "from TMLSysDB.dbo.t_salesInvoice  " +
                //                    "where InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())-1) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) and invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)  " +
                //                    ")  " +
                //                    "as p2";

                cmd.CommandText = " select isnull(sum(p2.CRCYR) - abs(sum(p2.DbCYR)),0) as LMSales  " +
                    "from   " +
                    "(  " +
                    "select sum(Invoiceamount) as CRCYR, 0 as DbCYR  " +
                    "from TMLSysDB.dbo.t_salesInvoice  " +
                    "where  InvoiceDate BETWEEN '" + FistDateOfLastMonth + "' AND '" + FirstDateOfCurrentMonth + "' AND InvoiceDate < '" + FirstDateOfCurrentMonth + "' and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  " +
                    "group by  CustomerID  " +
                    "union all  " +
                    "select 0 as CRCYR,sum(Invoiceamount) as DbCYR  " +
                    "from TMLSysDB.dbo.t_salesInvoice  " +
                    "where InvoiceDate BETWEEN '" + FistDateOfLastMonth + "' AND '" + FirstDateOfCurrentMonth + "' AND InvoiceDate < '" + FirstDateOfCurrentMonth + "' and invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)  " +
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

        public double GetTMLLDSalesValue()
        {
            double TMLLDSaleValue = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DateTime dFromDate = DateTime.Today.AddDays(-1);
            DateTime dToDate = DateTime.Today;

            try
            {
                cmd.CommandText = " select isnull(sum(p2.CRCYR) - abs(sum(p2.DbCYR)),0) as DTDSales  " +
                                "from  " +
                                "( " +
                                "select sum(Invoiceamount) as CRCYR, 0 as DbCYR " +
                                "from TMLSysDB.dbo.t_salesInvoice " +
                                "where InvoiceDate BETWEEN ? AND ? AND InvoiceDate < ? and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) " +
                                "group by  CustomerID " +
                                "union all " +
                                "select 0 as CRCYR,sum(Invoiceamount) as DbCYR " +
                                "from TMLSysDB.dbo.t_salesInvoice " +
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
                    TMLLDSaleValue = Convert.ToDouble(reader["DTDSales"].ToString());

                }

                reader.Close();
                return TMLLDSaleValue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public double GetTMLDTDSalesValue()
        {
            double TMLDTDSaleValue = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);

            try
            {
                cmd.CommandText = " select isnull(sum(p2.CRCYR) - abs(sum(p2.DbCYR)),0) as DTDSales  " +
                                "from  " +
                                "( " +
                                "select sum(Invoiceamount) as CRCYR, 0 as DbCYR " +
                                "from TMLSysDB.dbo.t_salesInvoice " +
                                "where InvoiceDate BETWEEN ? AND ? AND InvoiceDate < ? and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) " +
                                "group by  CustomerID " +
                                "union all " +
                                "select 0 as CRCYR,sum(Invoiceamount) as DbCYR " +
                                "from TMLSysDB.dbo.t_salesInvoice " +
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
                    TMLDTDSaleValue = Convert.ToDouble(reader["DTDSales"].ToString());

                }

                reader.Close();
                return TMLDTDSaleValue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTMLStockValue()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            try
            {
                cmd.CommandText = " select Sum(StockQty) as StockQty, Sum(StockVal) as StockVal " +
                                    "from " +
                                    "(select ASGName,StockQty,(CostPrice*StockQty) StockVal " +
                                    "from (select ProductID,sum(CurrentStock) as StockQty " +
                                    "from TMLSysDB.dbo.t_ProductStock A " +
                                    "inner join TMLSysDB.dbo.t_Warehouse WH " +
                                    "on  A.WarehouseID=WH.WarehouseID " +
                                    "where WH.WarehouseParentID not in (1,9,10) " +
                                    "group by ProductID) AA " +
                                    "inner join TMLSysDB.dbo.v_ProductDetails Prod " +
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
        public string GetTMLAGWiseStock()
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
                                    "from TMLSysDB.dbo.t_ProductStock A " +
                                    "inner join TMLSysDB.dbo.t_Warehouse WH " +
                                    "on  A.WarehouseID=WH.WarehouseID " +
                                    "where WH.WarehouseParentID not in (1,9,10) " +
                                    "group by ProductID) AA " +
                                    "inner join TMLSysDB.dbo.v_ProductDetails Prod " +
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
        public string GetTMLAGWiseSaleLY()
        {
            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select AGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select AGName,SalesQty " +
                                    "from (SELECT     ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())-1) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND " +
                                    "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()))) AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())-1) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) +1)) AND " +
                                    "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()))) AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join TMLSysDB.dbo.v_ProductDetails Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by AGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["AGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTMLAGWiseSaleYTD()
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
                                    "from (SELECT     ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND " +
                                    "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE())+1)) AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) +1)) AND " +
                                    "(im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join TMLSysDB.dbo.v_ProductDetails Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTMLAGWiseSaleMTD()
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
                                    "from (SELECT     ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                    "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                                    "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE (im.InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                                    "AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (im.InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                                    "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join TMLSysDB.dbo.v_ProductDetails Prod " +
                                    "on Prod.ProductID=AA.ProductID " +
                                    "where Prod.ItemCategory=1) BB " +
                                    "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTMLAGWiseSaleLM()
        {
            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            DateTime Today = DateTime.Now.Date;
            DateTime FirstDateOfCurrentMonth = oTELLib.FirstDayofMonth(Today);
            DateTime FistDateOfLastMonth = oTELLib.FirstDayofLastMonth(Today);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                //cmd.CommandText = " select AGName,Sum(SalesQty) as SalesQty " +
                //                    "from " +
                //                    "(select AGName,SalesQty " +
                //                    "from (SELECT     ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                //                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                //                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                //                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                //                    "WHERE im.InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())-1) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                //                    "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                //                    "GROUP BY cd.ProductID " +
                //                    "UNION ALL " +
                //                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                //                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                //                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                //                    "WHERE im.InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())-1) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND InvoiceDate < CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                //                    "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                //                    "GROUP BY cd.ProductID) AS p2 " +
                //                    "GROUP BY ProductID) AA " +
                //                    "inner join TMLSysDB.dbo.v_ProductDetails Prod " +
                //                    "on Prod.ProductID=AA.ProductID " +
                //                    "where Prod.ItemCategory=1) BB " +
                //                    "group by AGName ";

                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                   "from " +
                                   "(select ASGName,SalesQty " +
                                   "from (SELECT     ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                   "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                   "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                   "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                   "WHERE im.InvoiceDate BETWEEN '" + FistDateOfLastMonth + "' AND '" + FirstDateOfCurrentMonth + "' AND InvoiceDate < '" + FirstDateOfCurrentMonth + "' " +
                                   "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                   "GROUP BY cd.ProductID " +
                                   "UNION ALL " +
                                   "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                   "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                   "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                   "WHERE im.InvoiceDate BETWEEN '" + FistDateOfLastMonth + "' AND '" + FirstDateOfCurrentMonth + "' AND InvoiceDate < '" + FirstDateOfCurrentMonth + "' " +
                                   "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                   "GROUP BY cd.ProductID) AS p2 " +
                                   "GROUP BY ProductID) AA " +
                                   "inner join TMLSysDB.dbo.v_ProductDetails Prod " +
                                   "on Prod.ProductID=AA.ProductID " +
                                   "where Prod.ItemCategory=1) BB " +
                                   "group by ASGName ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    sResult = sResult + (string)reader["ASGName"] + ": ";
                    sResult = sResult + reader["SalesQty"].ToString() + " ";
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTMLAGWiseSaleWTD()
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
                                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join TMLSysDB.dbo.v_ProductDetails Prod " +
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
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string GetTMLAGWiseSaleLD()
        {
            DateTime dFromDate = DateTime.Today.AddDays(-1);
            DateTime dToDate = DateTime.Today;

            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT     ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? " +
                                    "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? " +
                                    "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join TMLSysDB.dbo.v_ProductDetails Prod " +
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
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string GetTMLAGWiseSaleDTD()
        {
            DateTime dFromDate = DateTime.Today;
            DateTime dToDate = DateTime.Today.AddDays(1);

            string sResult = "";
            double Qty = 0;
            TELLib oTELLib = new TELLib();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select ASGName,Sum(SalesQty) as SalesQty " +
                                    "from " +
                                    "(select ASGName,SalesQty " +
                                    "from (SELECT     ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                                    "FROM  (SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? " +
                                    "AND (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID " +
                                    "UNION ALL " +
                                    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                                    "FROM TMLSysDB.dbo.t_SalesInvoice AS im INNER JOIN " +
                                    "TMLSysDB.dbo.t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                                    "WHERE im.InvoiceDate BETWEEN ? AND ? AND im.InvoiceDate < ? " +
                                    "AND (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                                    "GROUP BY cd.ProductID) AS p2 " +
                                    "GROUP BY ProductID) AA " +
                                    "inner join TMLSysDB.dbo.v_ProductDetails Prod " +
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
                    Qty = Qty + Convert.ToDouble(reader["SalesQty"].ToString());

                }

                string X = Qty + " (" + sResult + ")";

                reader.Close();
                return X;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetTMLReceivable()
        {
            TELLib oTELLib = new TELLib();
            string Receivable = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select Sum(Balance)*(-1) as Receivable from TMLSysDB.dbo.v_CustomerDetails ";

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
        public DSProductPrice GetProductPrice()
        {
            DSProductPrice oDSProdPrice = new DSProductPrice();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select AGName,AGPrior,substring(ProductName,16,20)ProductName,PetName,Prod.NSP,Prod.RSP,Prod.MRP " +
                                "from TMLSysDB.dbo.t_FinishedGoodsPrice FGP  " +
                                "inner join (Select ASGID,ItemCategory,AGName,ProductID, IsNull(NSP,0)NSP, IsNull(RSP,0)RSP, " +
                                "IsNull(MRP,0)MRP, ProductName,PetName,InventoryCategory,  " +
                                "AGPrior=CASE When AGname='Smart' then 1 When AGname='Touch' then 2 else 3 end " +
                                "from TMLSysDB.dbo.v_ProductDetails) Prod  " +
                                "on FGP.ProductID=Prod.ProductID  " +
                                "where IsCurrent=1 and InventoryCategory=1 and ASGID=4  " +
                                "order by AGPrior, Prod.RSP desc ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSProductPrice.ProductPriceRow oProductPriceRow = oDSProdPrice.ProductPrice.NewProductPriceRow();
                    oProductPriceRow.Category = reader["AGName"].ToString();
                    oProductPriceRow.ProductName = reader["ProductName"].ToString();
                    oProductPriceRow.PetName = reader["PetName"].ToString();
                    oProductPriceRow.NSP = reader["NSP"].ToString();
                    oProductPriceRow.RSP = reader["RSP"].ToString();
                    oProductPriceRow.MRP = reader["MRP"].ToString();

                    oDSProdPrice.ProductPrice.AddProductPriceRow(oProductPriceRow);
                }
                oDSProdPrice.AcceptChanges();

                reader.Close();
                return oDSProdPrice;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSProductStock GetProductStock()
        {
            DSProductStock oDSProdStock = new DSProductStock();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select AGName, ProductName,PetName,AGPrior,CostPrice,Sum(StockQty) as StockQty, Sum(StockVal) as StockVal " +
                            "from   " +
                            "(  " +
                            "select AGName,substring(ProductName,16,20)ProductName,PetName,StockQty,CostPrice,(CostPrice*StockQty) StockVal,AGPrior " +
                            "from (select ProductID,sum(CurrentStock) as StockQty   " +
                            "from TMLSysDB.dbo.t_ProductStock A   " +
                            "inner join TMLSysDB.dbo.t_Warehouse WH  " +
                            "on  A.WarehouseID=WH.WarehouseID   " +
                            "where WH.WarehouseParentID not in (1,9,10)   " +
                            "group by ProductID  " +
                            ") AA   " +
                            "inner join (Select ASGID,ItemCategory,AGName,ProductID, IsNull(CostPrice,0)CostPrice, ProductName,PetName,  " +
                            "AGPrior=CASE When AGname='Smart' then 1 When AGname='Touch' then 2 else 3 end " +
                            "from TMLSysDB.dbo.v_ProductDetails) Prod   " +
                            "on Prod.ProductID=AA.ProductID   " +
                            "where Prod.ItemCategory=1and ASGID=4 " +
                            ") BB   " +
                            "group by AGName,ProductName,PetName,AGPrior,CostPrice  " +
                            "Order by AGPrior,CostPrice DESC";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSProductStock.ProductStockRow oProductStockRow = oDSProdStock.ProductStock.NewProductStockRow();
                    oProductStockRow.ASGName = reader["AGName"].ToString();
                    oProductStockRow.ProductName = reader["ProductName"].ToString();
                    oProductStockRow.PetName = reader["PetName"].ToString();
                    oProductStockRow.StockQty = int.Parse(reader["StockQty"].ToString());
                    oProductStockRow.StockValue = Convert.ToDouble(reader["StockVal"].ToString());

                    oDSProdStock.ProductStock.AddProductStockRow(oProductStockRow);
                }
                oDSProdStock.AcceptChanges();

                reader.Close();
                return oDSProdStock;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSPerformanceTML GetPerformance()
        {
            DSPerformanceTML oDSPerformanceTML = new DSPerformanceTML();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            TELLib _oTELLib=new TELLib();

            DateTime FirstDayOfCurrentMonth = _oTELLib.FirstDayofMonth(DateTime.Today);
            DateTime FirstDayOfLastMonth = FirstDayOfCurrentMonth.AddMonths(-1);
            DateTime Today = DateTime.Today;
            DateTime LMTD = Today.AddMonths(-1);


            try
            {
                cmd.CommandText = "Select channel,agname,CustTypePrior,Sum(tqty)tqty,Sum(tvalue)tvalue,Sum(mtdqty)mtdqty,Sum(mtdValue)mtdValue,Sum(LMTDQty)LMTDQty,Sum(LMTDValue)LMTDValue from " +
                                    "( " +
                                    "select m.channel,m.agname,IsNUll(tqty,0)tqty,IsNull(tvalue,0)tvalue,IsNull(mtdsalesqty,0)mtdqty, " +
                                    "IsNull(mtdValue,0)mtdValue,IsNull((mtdValue/tvalue)*100,0) as Acheivement,IsNull(LMSalesQty,0)LMTDQty,IsNull(LMValue,0)LMTDValue,custtypesl,CustTypePrior from  " +
                                    "(select channel,agname,custtypesl,CustTypePrior, sum(mtdsalesqty) as mtdsalesqty,sum(mtdValue) as mtdValue,sum(LMSalesQty) as LMSalesQty, " +
                                    "sum(LMValue) as LMValue from  " +
                                    "(select case CustomerTypeName when 'SMDP' then 'SMDP' when 'SES' then 'SES' when 'SIS' then 'Basundhara' " +
                                    "when 'GRT' then 'Basundhara' when 'Corporate' then 'Corporate' when 'TML_RETAIL' then 'TMLRETAIL'  " +
                                    "when 'EPS/EzeeBuy' then 'EPS' else 'Others' end channel, " +
                                    "case CustomerTypeName when 'SMDP' then 1 when 'SIS' then 2 when 'GRT' then 2 when 'SES' then 3  " +
                                    "when 'Corporate' then 4 when 'TML_RETAIL' then 5  " +
                                    "when 'EPS/EzeeBuy' then 6 else 7 end CustTypePrior, " +
                                    "agname, sum(mtdsalesqty) as mtdsalesqty,sum(mtdValue) as mtdValue,sum(LMSalesQty) as LMSalesQty, " +
                                    "sum(LMValue) as LMValue,custtypesl " +
                                    " from  " +
                                    "(select ProductID,convert(int,ProductCode)ProductCode,substring(ProductName,16,11) as PName,agname,ProductModel,  " +
                                    "CustomerID,b.CustomerCode, b.CustomerName,case when customerid in(214,269,381) then 'SIS' else CustomerTypeName end CustomerTypeName " +
                                    ",pos as custtypesl from tmlsysdb.dbo.v_ProductDetails a, tmlsysdb.dbo.v_CustomerDetails b,tmlsysdb.dbo.t_customertype c " +
                                    "where b.customertypeid=c.custtypeid and itemcategory=1  " +
                                    ") A " +
                                    "left outer join " +
                                    "(select productid,customerid,sum(mtdsalesqty) as mtdsalesqty,sum(mtdValue) as mtdValue,sum(LMSalesQty) as LMSalesQty, " +
                                    "sum(LMValue) as LMValue from " +
                                    "(select ProductID,unitprice,CustomerID,invdate, isnull(sum(p2.CR) - abs(sum(p2.DR)),0) as mtdSalesQty, " +
                                    "(isnull(sum(p2.CR) - abs(sum(p2.DR)),0))*unitprice as mtdValue,0 as LMSalesQty,0 as LMValue " +
                                    "from " +
                                    "( " +
                                    "select cast(convert(varchar,invoicedate,106) as datetime) as InvDate,ProductID,unitprice,CustomerID,    " +
                                    "sum(Quantity) as CR, 0 as DR,sum(isnull(FreeQty,0)) as FreeCR, 0 as FreeDR     " +
                                    "from tmlsysdb.dbo.t_salesInvoice im,  tmlsysdb.dbo.t_salesInvoiceDetail cd     " +
                                    "where  im.InvoiceID = cd.InvoiceID and    " +
                                    "im.invoicetypeid in (1,2,3,4,5,15) and invoicestatus not in (3)     " +
                                    "group by  cast(convert(varchar,invoicedate,106) as datetime),ProductID,unitprice,CustomerID     " +
                                    "union all      " +
                                    "select cast(convert(varchar,invoicedate,106) as datetime) as InvDate,ProductID,unitprice,CustomerID,    " +
                                    "0 as CR, sum(Quantity)  as DR,0 as FreeCR, sum(isnull(FreeQty,0)) as FreeDR     " +
                                    "from tmlsysdb.dbo.t_salesInvoice im,   " +
                                    "tmlsysdb.dbo.t_salesInvoiceDetail cd     " +
                                    "where  im.InvoiceID = cd.InvoiceID and    " +
                                    "im.invoicetypeid in (6,7,8,9,10,12,16) and invoicestatus not in (3)     " +
                                    "group by  cast(convert(varchar,invoicedate,106) as datetime),ProductID,unitprice,CustomerID " +
                                    ")     " +
                                    "as p2 " +
                                    "where InvDate between '" + FirstDayOfCurrentMonth + "' and '" + Today + "' " +
                                    "group by InvDate,ProductID,unitprice,CustomerID " +
                    //MTD 
                                    "union " +
                                    "select ProductID,unitprice,CustomerID,invdate,0 as mtdsalesqty,0 as mtdValue,isnull(sum(p2.CR) - abs(sum(p2.DR)),0) as LMSalesQty, " +
                                    "(isnull(sum(p2.CR) - abs(sum(p2.DR)),0))*unitprice as LMValue " +
                                    "from " +
                                    "( " +
                                    "select cast(convert(varchar,invoicedate,106) as datetime) as InvDate,ProductID,unitprice,CustomerID,    " +
                                    "sum(Quantity) as CR, 0 as DR,sum(isnull(FreeQty,0)) as FreeCR, 0 as FreeDR     " +
                                    "from tmlsysdb.dbo.t_salesInvoice im,  tmlsysdb.dbo.t_salesInvoiceDetail cd     " +
                                    "where  im.InvoiceID = cd.InvoiceID and    " +
                                    "im.invoicetypeid in (1,2,3,4,5,15) and invoicestatus not in (3)     " +
                                    "group by  cast(convert(varchar,invoicedate,106) as datetime),ProductID,unitprice,CustomerID     " +
                                    "union all      " +
                                    "select cast(convert(varchar,invoicedate,106) as datetime) as InvDate,ProductID,unitprice,CustomerID,    " +
                                    "0 as CR, sum(Quantity)  as DR,0 as FreeCR, sum(isnull(FreeQty,0)) as FreeDR     " +
                                    "from tmlsysdb.dbo.t_salesInvoice im,   " +
                                    "tmlsysdb.dbo.t_salesInvoiceDetail cd     " +
                                    "where  im.InvoiceID = cd.InvoiceID and    " +
                                    "im.invoicetypeid in (6,7,8,9,10,12,16) and invoicestatus not in (3)     " +
                                    "group by  cast(convert(varchar,invoicedate,106) as datetime),ProductID,unitprice,CustomerID " +
                                    ")     " +
                                    "as p2 " +
                                    "where InvDate between '" + FirstDayOfLastMonth + "' and '" + LMTD + "' " +
                                    "group by InvDate,ProductID,unitprice,CustomerID " +
                    //LM 
                                    ") x " +
                                    "group by productid,customerid) c " +
                                    "on a.productid=c.productid and a.customerid=c.customerid " +
                                    "group by CustomerTypeName,agname,custtypesl) v " +
                                    "group by channel,agname,custtypesl,CustTypePrior) m " +
                                    "left outer join  " +
                                    "(select * from TMLAddDB.dbo.t_MonthChannelAGtgt  " +
                                    "where tmonth=datepart(mm,getdate()) and tyear=datepart(year,getdate())) n " +
                                    "on (m.channel=n.channel and m.agname=n.agname) " +
                                    ")x Group by channel,agname,CustTypePrior " +
                                    "order by CustTypePrior";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSPerformanceTML.PerformanceRow oPerformanceRow = oDSPerformanceTML.Performance.NewPerformanceRow();

                    oPerformanceRow.Channel = reader["channel"].ToString();
                    oPerformanceRow.AGName = reader["AGName"].ToString();
                    oPerformanceRow.TargetQty =int.Parse(reader["tqty"].ToString());
                    oPerformanceRow.TargetValue =Convert.ToDouble(reader["tvalue"].ToString());
                    oPerformanceRow.MTDQty = int.Parse(reader["mtdqty"].ToString());
                    oPerformanceRow.MTDValue = Convert.ToDouble(reader["mtdValue"].ToString());
                    //oPerformanceRow.Acheivement = Convert.ToDouble(reader["Acheivement"].ToString());
                    oPerformanceRow.LMTDQty = int.Parse(reader["LMTDQty"].ToString());
                    oPerformanceRow.LMTDValue = Convert.ToDouble(reader["LMTDValue"].ToString());

                    oDSPerformanceTML.Performance.AddPerformanceRow(oPerformanceRow);
                }
                oDSPerformanceTML.AcceptChanges();


                reader.Close();
                return oDSPerformanceTML;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}

// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: March 31, 2011
// Time : 11:00 AM
// Description: Form for printing Stock Position Report
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Report
{
    public class StockPositionReport
    {
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private string _sPGName;
        private string _sMAGName;
        private string _sASGName;
        private string _sAGName;
        private string _sBrandName;
        private int _nWarehouseID;
        private string _sWHCode;
        private string _sWHName;
        private string _sWHPCode;
        private string _sWHPName;
        private int _nStockQty;
        private double _nCStockValue;
        private int _nBookingQty;
        private double _NSP;
        private double _RSP;
        private double _YTDSale;
        private double _MTDSale;


        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

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

        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }

        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }

        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }

        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value; }
        }

        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }

        public int WHID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        public string WHCode
        {
            get { return _sWHCode; }
            set { _sWHCode = value; }
        }

        public string WHName
        {
            get { return _sWHName; }
            set { _sWHName = value; }
        }

        public string WHPCode
        {
            get { return _sWHPCode; }
            set { _sWHPCode = value; }
        }

        public string WHPName
        {
            get { return _sWHPName; }
            set { _sWHPName = value; }
        }


        public int StockQty
        {
            get { return _nStockQty; }
            set { _nStockQty = value; }
        }

        public double CStockValue
        {
            get { return _nCStockValue; }
            set { _nCStockValue = value; }
        }

        public int BookingQty
        {
            get { return _nBookingQty; }
            set { _nBookingQty = value; }
        }
        public double NSP
        {
            get { return _NSP; }
            set { _NSP = value; }
        }
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }

        public double YTDSale
        {
            get { return _YTDSale; }
            set { _YTDSale = value; }
        }
        public double MTDSale
        {
            get { return _MTDSale; }
            set { _MTDSale = value; }
        }     

    }
    public class StockPositionReports : CollectionBase
    {

        public StockPositionReport this[int i]
        {
            get { return (StockPositionReport)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(StockPositionReport oStockPosition)
        {
            InnerList.Add(oStockPosition);
        }




        public void Refresh(int nPGID, int nMAGID, int nASGID, int nAGID, int nBrandID, int nWHPID, int nWHID, string sProductCode, string sProductName)
        {
            int nCount = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";  
            
            try
            {
                sSql = @"select A.ProductID, ProductCode, ProductName,PGName,MAGName,ASGName,AGName,BrandDesc,CostPrice, "
                    + " A.WarehouseID WHID,IsNull(WarehouseCode,'--') as WHCode,WarehouseName as WHName,WarehouseParentCode as WHPCode,WarehouseParentName as WHPName, "
                    + " CurrentStock, isnull((CurrentStock * CostPrice),0) as CStockValue,BookingStock "
                    + " from t_ProductStock A "
                    + " inner join v_ProductDetails B "
                    + " on A.ProductID=B.ProductID "
                    + " inner join v_WarehouseDetails C "
                    + " on A.WarehouseID=C.WarehouseID "
                    + " where A.WarehouseID<>1 and A.CurrentStock>0";


                string sClause = "";

                if (nPGID > 0)
                {
                    sClause = " AND B.PGID=?";
                    cmd.Parameters.AddWithValue("PGID", nPGID);
                }

                if (nMAGID > 0)
                {
                    sClause = sClause + " AND B.MAGID=?";
                    cmd.Parameters.AddWithValue("MAGID", nMAGID);
                }

                if (nASGID > 0)
                {
                    sClause = sClause + " AND B.ASGID=?";
                    cmd.Parameters.AddWithValue("ASGID", nASGID);
                }

                if (nAGID > 0)
                {
                    sClause = sClause + " AND B.AGID=?";
                    cmd.Parameters.AddWithValue("AGID", nAGID);
                }

                if (nBrandID > 0)
                {
                    sClause = sClause + " AND B.BrandID=?";
                    cmd.Parameters.AddWithValue("BrandID", nBrandID);
                }

                if (nWHPID > 0)
                {
                    sClause = sClause + " AND C.WarehouseParentID=?";
                    cmd.Parameters.AddWithValue("WHPID", nWHPID);
                }

                if (nWHID > 0)
                {
                    sClause = sClause + " AND C.WarehouseID=?";
                    cmd.Parameters.AddWithValue("WHID", nWHID);
                }

                if (sProductCode != "")
                {
                    sClause = sClause + " AND B.ProductCode LIKE ?";
                    cmd.Parameters.AddWithValue("ProductCode", "%" + sProductCode + "%");
                }

                if (sProductName != "")
                {
                    sClause = sClause + " AND B.ProductName LIKE ?";
                    cmd.Parameters.AddWithValue("ProductName", "%" + sProductName + "%");
                }

                cmd.CommandText = sSql + sClause;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockPositionReport oRptStockPosition = new StockPositionReport();
                    oRptStockPosition.ProductID = (int)reader["ProductID"];
                    oRptStockPosition.ProductCode = (string)reader["ProductCode"];
                    oRptStockPosition.ProductName = (string)reader["ProductName"];
                    oRptStockPosition.PGName = (string)reader["PGName"];               
                    oRptStockPosition.MAGName = (string)reader["MAGName"];
                    oRptStockPosition.ASGName = (string)reader["ASGName"];
                    oRptStockPosition.AGName = (string)reader["AGName"];
                    oRptStockPosition.BrandName = (string)reader["BrandDesc"];

                    oRptStockPosition.WHID = (int)reader["WHID"];
                    oRptStockPosition.WHCode = (string)reader["WHCode"];
                    oRptStockPosition.WHName = (string)reader["WHName"];
                    oRptStockPosition.WHPCode = (string)reader["WHPCode"];
                    oRptStockPosition.WHPName = (string)reader["WHPName"];

                    oRptStockPosition.StockQty = Convert.ToInt32(reader["CurrentStock"]);
                    oRptStockPosition.BookingQty = Convert.ToInt32(reader["BookingStock"]);
                    oRptStockPosition.CStockValue = Convert.ToDouble(reader["CStockValue"]);
                    nCount++;
                    InnerList.Add(oRptStockPosition);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void GetOpeningStock(DateTime dDate,int nPGID, int nMAGID, int nASGID, int nAGID, int nBrandID, int nWHPID, int nWHID, string sProductCode, string sProductName)
        {
            int nCount = 0;
            DateTime dTranFromDate = dDate;
            DateTime dTranToDate = DateTime.Today.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = @"select A.ProductID, ProductCode, ProductName,PGName,MAGName,ASGName,AGName,BrandDesc,D.CostPrice, "
                    + " A.WarehouseID WHID,IsNull(WarehouseCode,'--') as WHCode,WarehouseName as WHName,WarehouseParentCode as WHPCode,WarehouseParentName as WHPName,  "
                    + " CurrentStock, isnull((CurrentStock * D.CostPrice),0) as CStockValue "
                    + " from "
                    + " ( "
                    + " select x.ProductID,x.warehouseid    "
                    + " ,((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as CurrentStock     "
                    + " From "
                    + " (  "
                    + " select Productid,warehouseid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock   "
                    + " where channelid <> 1 and warehouseid <> 1   "
                    + " group by ProductID,warehouseid  "
                    + " ) as x   "
                    + " left outer join  "
                    + " (  "
                    + " select sd.productid,towhid,sum(qty)as qty "
                    + " from t_productStockTran sm, t_productStockTranItem sd   "
                    + " where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?  "
                    + " group by sd.productid,towhid "
                    + " ) as y on x.productid = y.productid and x.warehouseid = y.towhid "
                    + " left outer join   "
                    + " (  "
                    + " select sd.productid,Fromwhid, sum(qty)as qty  "
                    + " from t_productStockTran sm, t_productStockTranItem sd   "
                    + " where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ?  "
                    + " group by sd.productid,Fromwhid "
                    + " )as z on x.productid = z.productid and x.warehouseid = z.Fromwhid "
                    + " ) as A "
                    + " inner join  "
                    + " ( "
                    + " select * from v_ProductDetails  "
                    + " ) as B on A.ProductID=B.ProductID "
                    + " inner join  "
                    + " ( "
                    + " select * from v_WarehouseDetails  "
                    + " ) as C on A.WarehouseID=C.WarehouseID  "

                    + "left outer join "
                    + " (select AA.ProductID, CostPrice "
                    + "from t_FinishedGoodsPrice AA "
                    + " inner join "
                    + " (select ProductID, max(PriceID) as MaxPriceID "
                    + " from t_FinishedGoodsPrice "
                    + " where EffectiveDate<=? "
                    + " group by ProductID) BB "
                    + " on AA.ProductID=BB.ProductID and AA.PriceID=BB.MaxPriceID) D "
                    + " on A.ProductID=D.ProductID "

                    + " where A.WarehouseID<>1 and A.CurrentStock>0 ";

                //Stock Transaction date range
                cmd.Parameters.AddWithValue("TranDate", dTranFromDate);
                cmd.Parameters.AddWithValue("TranDate", dTranToDate);

                cmd.Parameters.AddWithValue("TranDate", dTranFromDate);
                cmd.Parameters.AddWithValue("TranDate", dTranToDate);

                cmd.Parameters.AddWithValue("TranDate", dTranFromDate);

                string sClause = "";

                if (nPGID > 0)
                {
                    sClause = " AND B.PGID=?";
                    cmd.Parameters.AddWithValue("PGID", nPGID);
                }

                if (nMAGID > 0)
                {
                    sClause = sClause + " AND B.MAGID=?";
                    cmd.Parameters.AddWithValue("MAGID", nMAGID);
                }

                if (nASGID > 0)
                {
                    sClause = sClause + " AND B.ASGID=?";
                    cmd.Parameters.AddWithValue("ASGID", nASGID);
                }

                if (nAGID > 0)
                {
                    sClause = sClause + " AND B.AGID=?";
                    cmd.Parameters.AddWithValue("AGID", nAGID);
                }

                if (nBrandID > 0)
                {
                    sClause = sClause + " AND B.BrandID=?";
                    cmd.Parameters.AddWithValue("BrandID", nBrandID);
                }

                if (nWHPID > 0)
                {
                    sClause = sClause + " AND C.WarehouseParentID=?";
                    cmd.Parameters.AddWithValue("WHPID", nWHPID);
                }

                if (nWHID > 0)
                {
                    sClause = sClause + " AND C.WarehouseID=?";
                    cmd.Parameters.AddWithValue("WHID", nWHID);
                }

                if (sProductCode != "")
                {
                    sClause = sClause + " AND B.ProductCode LIKE ?";
                    cmd.Parameters.AddWithValue("ProductCode", "%" + sProductCode + "%");
                }

                if (sProductName != "")
                {
                    sClause = sClause + " AND B.ProductName LIKE ?";
                    cmd.Parameters.AddWithValue("ProductName", "%" + sProductName + "%");
                }

                cmd.CommandText = sSql + sClause;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockPositionReport oRptStockPosition = new StockPositionReport();
                    oRptStockPosition.ProductID = (int)reader["ProductID"];
                    oRptStockPosition.ProductCode = (string)reader["ProductCode"];
                    oRptStockPosition.ProductName = (string)reader["ProductName"];
                    oRptStockPosition.PGName = (string)reader["PGName"];
                    oRptStockPosition.MAGName = (string)reader["MAGName"];
                    oRptStockPosition.ASGName = (string)reader["ASGName"];
                    oRptStockPosition.AGName = (string)reader["AGName"];
                    oRptStockPosition.BrandName = (string)reader["BrandDesc"];

                    oRptStockPosition.WHID = (int)reader["WHID"];
                    oRptStockPosition.WHCode = (string)reader["WHCode"];
                    oRptStockPosition.WHName = (string)reader["WHName"];
                    oRptStockPosition.WHPCode = (string)reader["WHPCode"];
                    oRptStockPosition.WHPName = (string)reader["WHPName"];

                    oRptStockPosition.StockQty = Convert.ToInt32(reader["CurrentStock"]);
                    oRptStockPosition.BookingQty = 0;
                    oRptStockPosition.CStockValue = Convert.ToDouble(reader["CStockValue"]);
                    nCount++;
                    InnerList.Add(oRptStockPosition);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetStockSales(DateTime dDate, int nPGID, int nMAGID, int nASGID, int nAGID, int nBrandID, int nWHPID, int nWHID, string sProductCode, string sProductName)
        {
            DateTime dTranFromDate = dDate;
            DateTime dTranToDate = DateTime.Today.Date.AddDays(1);

            DateTime dMTDFromDate = new DateTime(dDate.Year, dDate.Month, 1);
            DateTime dMTDTodate = dDate;
            DateTime dYTDFromDate = new DateTime(dDate.Year,1,1);
            DateTime dYTDTodate = dDate;

            int nCount = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = @"select A.ProductID, ProductCode, ProductName,PGName,MAGName,ASGName,AGName,BrandDesc,CostPrice, NSP, RSP, "
                        + " A.WarehouseID WHID,WarehouseCode as WHCode,WarehouseName as WHName,WarehouseParentCode as WHPCode, "
                        + " WarehouseParentName as WHPName,   "
                        + " isnull(CurrentStock,0) as CurrentStock, isnull((CurrentStock * CostPrice),0) as CStockValue, "
                        + " isnull(MonthlySalesQty,0) as MonthlySalesQty, "
                        + " isnull(YearlySalesQty,0) as YearlySalesQty "
                        + " from "
                        + " ( "
                        + " Select isnull(sales.ProductID,stock.ProductID) as ProductID, stock.Warehouseid as Warehouseid,  "
                        + " isnull(CurrentStock,0) as CurrentStock, isnull(MonthlySalesQty,0) as MonthlySalesQty,  "
                        + " isnull(YearlySalesQty,0) as YearlySalesQty  from "
                        + " ( "
                        + " select A.ProductID, A.WarehouseID,CurrentStock "
                        + " from "
                        + " ( "
                        + " select x.ProductID,x.warehouseid,   "
                        + " ((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as CurrentStock    "
                        + " From "
                        + " (  "
                        + " select Productid,warehouseid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue  "
                        + " from t_productstock   "
                        + " where channelid <> 1 and warehouseid <> 1   "
                        + " group by ProductID,warehouseid  "
                        + " ) as x   "
                        + " left outer join  "
                        + " (  "
                        + " select sd.productid,towhid,sum(qty)as qty "
                        + " from t_productStockTran sm, t_productStockTranItem sd   "
                        + " where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ? "
                        + " group by sd.productid,towhid "
                        + " ) as y on x.productid = y.productid and x.warehouseid = y.towhid "
                        + " left outer join   "
                        + " (  "
                        + " select sd.productid,Fromwhid, sum(qty)as qty  "
                        + " from t_productStockTran sm, t_productStockTranItem sd   "
                        + " where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ? "
                        + " group by sd.productid,Fromwhid "
                        + " )as z on x.productid = z.productid and x.warehouseid = z.Fromwhid "
                        + " ) as A "
                        + " ) as stock "
                        + " full outer join "
                        + " ( "
                        + " Select ProductID,sum(MonthlySalesQty) as MonthlySalesQty, sum(YearlySalesQty) as YearlySalesQty    "
                        + " from    "
                        + " (    "
                        + " Select    "
                        + " isnull(a.Customerid,b.CustomerID) as CustomerID,isnull(a.ProductID,b.ProductID) as ProductID, "
                        + " isnull(MonthlySalesQty,0) as MonthlySalesQty, isnull(YearlySalesQty,0) as YearlySalesQty "
                        + " from    "
                        + " (    "
                        + " select CustomerID,Productid, sum(QuantityCr - QuantityDr) as MonthlySalesQty   "
                        + " from     "
                        + " (      "
                        + " select SID.ProductID,CustomerID ,     "
                        + " sum(quantity) as QuantityCr , sum(unitPrice*Quantity) as AmountCr, 0 as QuantityDr, 0 as AmountDr   "
                        + " from t_salesinvoice IM, t_salesInvoiceDetail SID    "
                        + " where im.Invoiceid = Sid.Invoiceid  and im.Invoicedate between ? and ? and InvoiceDate < ? "
                        + " and im.invoicetypeid in(?,?,?,?) and InvoiceStatus not in (?)  "
                        + " group by CustomerID,ProductID    "
                        + " union all      "
                        + " select SID.ProductID,CustomerID,      "
                        + " 0 as QuantityCr , 0 as AmountCr, sum(quantity) as QuantityDr, sum(unitPrice*Quantity) as AmountDr       "
                        + " from t_salesinvoice IM, t_salesInvoiceDetail SID     "
                        + " where im.Invoiceid = Sid.Invoiceid  and im.Invoicedate between ? and ? and InvoiceDate < ? "
                        + " and im.invoicetypeid in(?,?,?,?,?)  and InvoiceStatus not in (?)   "
                        + " group by CustomerID,ProductID    "
                        + " ) as Q1      "
                        + " group by CustomerID,ProductID "
                        + " )as a    "
                        + " full outer join    "
                        + " (    "
                        + " select CustomerID,Productid, sum(QuantityCr - QuantityDr) as YearlySalesQty    "
                        + " from      "
                        + " (      "
                        + " select SID.ProductID,CustomerID,      "
                        + " sum(quantity) as QuantityCr , sum(unitPrice*Quantity) as AmountCr, 0 as QuantityDr, 0 as AmountDr  "
                        + " from t_salesinvoice IM, t_salesInvoiceDetail SID    "
                        + " where im.Invoiceid = Sid.Invoiceid  and im.Invoicedate between ? and ? and InvoiceDate < ? "
                        + " and im.invoicetypeid in(?,?,?,?) and InvoiceStatus not in (?)    "
                        + " group by CustomerID,ProductID      "
                        + " union all      "
                        + " select SID.ProductID,CustomerID,    "
                        + " 0 as QuantityCr , 0 as AmountCr, sum(quantity) as QuantityDr, sum(unitPrice*Quantity) as AmountDr     "
                        + " from t_salesinvoice IM, t_salesInvoiceDetail SID     "
                        + " where im.Invoiceid = Sid.Invoiceid  and im.Invoicedate between ? and ? and InvoiceDate < ? "
                        + " and im.invoicetypeid in(?,?,?,?,?)  and InvoiceStatus not in (?)    "
                        + " group by CustomerID,ProductID    "
                        + " ) as Q1      "
                        + " group by CustomerID,ProductID     "
                        + " ) as b on a.Customerid = b.CustomerID and a.ProductID = b.ProductID  "
                        + " )as sales    "
                        + " Group By ProductID    "
                        + " ) as sales on sales.ProductID = stock.ProductID "
                        + " ) as A "
                        + " inner join   "
                        + " (  "
                        + " select * from v_ProductDetails   "
                        + " ) as B on A.ProductID=B.ProductID  "
                        + " inner join "
                        + " ( "
                        + " select * from v_WarehouseDetails  "
                        + " ) as C on A.WarehouseID=C.WarehouseID  "
                        + " where (CurrentStock + MonthlySalesQty + YearlySalesQty) <>0  ";

                //Stock Transaction date range
                cmd.Parameters.AddWithValue("TranDate", dTranFromDate);
                cmd.Parameters.AddWithValue("TranDate", dTranToDate);

                cmd.Parameters.AddWithValue("TranDate", dTranFromDate);
                cmd.Parameters.AddWithValue("TranDate", dTranToDate);

                cmd.Parameters.AddWithValue("InvoiceDate", dMTDFromDate);
                cmd.Parameters.AddWithValue("InvoiceDate", dMTDTodate);
                cmd.Parameters.AddWithValue("InvoiceDate", dMTDTodate);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
                cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


                cmd.Parameters.AddWithValue("InvoiceDate", dMTDFromDate);
                cmd.Parameters.AddWithValue("InvoiceDate", dMTDTodate);
                cmd.Parameters.AddWithValue("InvoiceDate", dMTDTodate);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
                cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

                cmd.Parameters.AddWithValue("InvoiceDate", dYTDFromDate);
                cmd.Parameters.AddWithValue("InvoiceDate", dYTDTodate);
                cmd.Parameters.AddWithValue("InvoiceDate", dYTDTodate);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
                cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


                cmd.Parameters.AddWithValue("InvoiceDate", dYTDFromDate);
                cmd.Parameters.AddWithValue("InvoiceDate", dYTDTodate);
                cmd.Parameters.AddWithValue("InvoiceDate", dYTDTodate);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
                cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
                cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);               


                string sClause = "";

                if (nPGID > 0)
                {
                    sClause = " AND B.PGID=?";
                    cmd.Parameters.AddWithValue("PGID", nPGID);
                }

                if (nMAGID > 0)
                {
                    sClause = sClause + " AND B.MAGID=?";
                    cmd.Parameters.AddWithValue("MAGID", nMAGID);
                }

                if (nASGID > 0)
                {
                    sClause = sClause + " AND B.ASGID=?";
                    cmd.Parameters.AddWithValue("ASGID", nASGID);
                }

                if (nAGID > 0)
                {
                    sClause = sClause + " AND B.AGID=?";
                    cmd.Parameters.AddWithValue("AGID", nAGID);
                }

                if (nBrandID > 0)
                {
                    sClause = sClause + " AND B.BrandID=?";
                    cmd.Parameters.AddWithValue("BrandID", nBrandID);
                }

                if (nWHPID > 0)
                {
                    sClause = sClause + " AND C.WarehouseParentID=?";
                    cmd.Parameters.AddWithValue("WHPID", nWHPID);
                }

                if (nWHID > 0)
                {
                    sClause = sClause + " AND C.WarehouseID=?";
                    cmd.Parameters.AddWithValue("WHID", nWHID);
                }

                if (sProductCode != "")
                {
                    sClause = sClause + " AND B.ProductCode LIKE ?";
                    cmd.Parameters.AddWithValue("ProductCode", "%" + sProductCode + "%");
                }

                if (sProductName != "")
                {
                    sClause = sClause + " AND B.ProductName LIKE ?";
                    cmd.Parameters.AddWithValue("ProductName", "%" + sProductName + "%");
                }

                cmd.CommandText = sSql + sClause;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   
                        StockPositionReport oRptStockPosition = new StockPositionReport();
                        oRptStockPosition.ProductID = (int)reader["ProductID"];
                        oRptStockPosition.ProductCode = (string)reader["ProductCode"];
                        oRptStockPosition.ProductName = (string)reader["ProductName"];
                        oRptStockPosition.PGName = (string)reader["PGName"];
                        oRptStockPosition.MAGName = (string)reader["MAGName"];
                        oRptStockPosition.ASGName = (string)reader["ASGName"];
                        oRptStockPosition.AGName = (string)reader["AGName"];
                        oRptStockPosition.BrandName = (string)reader["BrandDesc"];

                        oRptStockPosition.WHID = (int)reader["WHID"];
                        oRptStockPosition.WHCode = (string)reader["WHCode"];
                        oRptStockPosition.WHName = (string)reader["WHName"];
                        oRptStockPosition.WHPCode = (string)reader["WHPCode"];
                        oRptStockPosition.WHPName = (string)reader["WHPName"];

                        try
                        {
                            oRptStockPosition.NSP = Convert.ToDouble(reader["NSP"].ToString());
                        }
                        catch
                        {
                            oRptStockPosition.NSP =0;
                        }
                        try
                        {
                            oRptStockPosition.RSP = Convert.ToDouble(reader["RSP"].ToString());
                        }
                        catch
                        {
                            oRptStockPosition.RSP = 0;
                        }
                        try
                        {
                             oRptStockPosition.YTDSale = Convert.ToDouble(reader["YearlySalesQty"].ToString());
                        }
                        catch
                        {
                            oRptStockPosition.YTDSale = 0;
                        }
                        try
                        {
                            oRptStockPosition.MTDSale = Convert.ToDouble(reader["MonthlySalesQty"].ToString());
                        }
                        catch
                        {
                            oRptStockPosition.MTDSale = 0;
                        }                      

                        oRptStockPosition.StockQty = Convert.ToInt32(reader["CurrentStock"].ToString());
                        oRptStockPosition.BookingQty = 0;
                        oRptStockPosition.CStockValue = Convert.ToDouble(reader["CStockValue"].ToString());
                        nCount++;
                        InnerList.Add(oRptStockPosition);
                    
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

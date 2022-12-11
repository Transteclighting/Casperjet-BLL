// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: Mar 14, 2012
// Time :  12:30 PM
// Description: Budget vs Sales Analysis Country Summary
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
    [Serializable]
    public class rptSalesVsBudgetCountry
    {
        public int _nSBUID;
        public string _sSBUCode;
        public string _sSBUName;
        public int _nAreaId;
        public string _sAreaCode;
        public string _sAreaName;
        public int _nTerritoryId;
        public string _sTerritoryCode;
        public string _sTerritoryName;
        public int _nCustomerId;
        public string _sCustomerCode;
        public string _sCustomerName;
        public int _nCustomerTypeId;
        public string _sCustomerTypeCode;
        public string _sCustomerTypeName;
        public int _nAGID;
        public string _sAGCode;
        public string _sAGName;
        public int _nProductID;
        public string _sProductCode;
        public string _sProductName;
        public int _nTGID;
        public string _sTGCode;
        public string _sTGName;
        public int _nPGID;
        public string _sPGCode;
        public string _sPGName;
        public int _nMAGId;
        public string _sMAGCode;
        public string _sMAGName;
        public int _nASGId;
        public string _sASGCode;
        public string _sASGName;
        public int _nBrandID;
        public string _sBrandCode;
        public string _sBrandName;
        public int _nChannelId;
        public string _sChannelCode;
        public string _sChannelName;
        public double _Quantity;
        public double _StockValue;
        public double _SalesQty;
        public double _SalesAmt;
        public double _MonthlySalesQty;
        public double _MonthlySalesAmt;
        public double _MonthlyBudgetQty;
        public double _MonthlyBudgetAmt;
        public double _YearlySalesQty;
        public double _YearlySalesAmt;
        public double _YearlyBudgetQty;
        public double _YearlyBudgetAmt;
        public double _TotalOutstanding;
        public double _TotalCreditLimit;
        public double _TGPosition;
        public double _CustomerProfit;
        public double _CustomerSellExp;
        public double _TradePromotion;
        public double _Advertisement;
        public double _ProductDiscount;
        public double _VAT;
        public string _SupplyType;
        public double _VATApplicable;
        public double _TradePrice;
        public double _CostPrice;
        public int _nPTGSTID;
        public string _sPTGSTName;
        public double _PTGSTPosition;
        public int _nPTGTID;
        public string _sPTGTName;
        public double _PTGTPosition;



        public int SBUID
        {
            get { return _nSBUID; }
            set { _nSBUID = value; }
        }
        public string SBUCode
        {
            get { return _sSBUCode; }
            set { _sSBUCode = value; }
        }
        public string SBUName
        {
            get { return _sSBUName; }
            set { _sSBUName = value; }
        }
        public int AreaId
        {
            get { return _nAreaId; }
            set { _nAreaId = value; }
        }
        public string AreaCode
        {
            get { return _sAreaCode; }
            set { _sAreaCode = value; }
        }
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }
        }
        public int TerritoryId
        {
            get { return _nTerritoryId; }
            set { _nTerritoryId = value; }
        }
        public string TerritoryCode
        {
            get { return _sTerritoryCode; }
            set { _sTerritoryCode = value; }
        }
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value; }
        }
        public int CustomerId
        {
            get { return _nCustomerId; }
            set { _nCustomerId = value; }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }

        public int CustomerTypeId
        {
            get { return _nCustomerTypeId; }
            set { _nCustomerTypeId = value; }
        }
        public string CustomerTypeCode
        {
            get { return _sCustomerTypeCode; }
            set { _sCustomerTypeCode = value; }
        }
        public string CustomerTypeName
        {
            get { return _sCustomerTypeName; }
            set { _sCustomerTypeName = value; }
        }
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }
        public string AGCode
        {
            get { return _sAGCode; }
            set { _sAGCode = value; }
        }
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value; }
        }
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
        public int TGID
        {
            get { return _nTGID; }
            set { _nTGID = value; }
        }
        public string TGCode
        {
            get { return _sTGCode; }
            set { _sTGCode = value; }
        }
        public string TGName
        {
            get { return _sTGName; }
            set { _sTGName = value; }
        }
        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }
        public string PGCode
        {
            get { return _sPGCode; }
            set { _sPGCode = value; }
        }
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }
        public int MAGId
        {
            get { return _nMAGId; }
            set { _nMAGId = value; }
        }
        public string MAGCode
        {
            get { return _sMAGCode; }
            set { _sMAGCode = value; }
        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }
        public int ASGId
        {
            get { return _nASGId; }
            set { _nASGId = value; }
        }
        public string ASGCode
        {
            get { return _sASGCode; }
            set { _sASGCode = value; }
        }
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public string BrandCode
        {
            get { return _sBrandCode; }
            set { _sBrandCode = value; }
        }
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }
        public int ChannelId
        {
            get { return _nChannelId; }
            set { _nChannelId = value; }
        }
        public string ChannelCode
        {
            get { return _sChannelCode; }
            set { _sChannelCode = value; }
        }
        public string ChannelName
        {
            get { return _sChannelName; }
            set { _sChannelName = value; }
        }
        public double Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public double StockValue
        {
            get { return _StockValue; }
            set { _StockValue = value; }
        }
        public double SalesQty
        {
            get { return _SalesQty; }
            set { _SalesQty = value; }
        }
        public double SalesAmt
        {
            get { return _SalesAmt; }
            set { _SalesAmt = value; }
        }
        public double MonthlySalesQty
        {
            get { return _MonthlySalesQty; }
            set { _MonthlySalesQty = value; }
        }
        public double MonthlySalesAmt
        {
            get { return _MonthlySalesAmt; }
            set { _MonthlySalesAmt = value; }
        }
        public double MonthlyBudgetQty
        {
            get { return _MonthlyBudgetQty; }
            set { _MonthlyBudgetQty = value; }
        }
        public double MonthlyBudgetAmt
        {
            get { return _MonthlyBudgetAmt; }
            set { _MonthlyBudgetAmt = value; }
        }
        public double YearlySalesQty
        {
            get { return _YearlySalesQty; }
            set { _YearlySalesQty = value; }
        }
        public double YearlySalesAmt
        {
            get { return _YearlySalesAmt; }
            set { _YearlySalesAmt = value; }
        }
        public double YearlyBudgetQty
        {
            get { return _YearlyBudgetQty; }
            set { _YearlyBudgetQty = value; }
        }
        public double YearlyBudgetAmt
        {
            get { return _YearlyBudgetAmt; }
            set { _YearlyBudgetAmt = value; }
        }
        public double TotalOutstanding
        {
            get { return _TotalOutstanding; }
            set { _TotalOutstanding = value; }
        }
        public double TotalCreditLimit
        {
            get { return _TotalCreditLimit; }
            set { _TotalCreditLimit = value; }
        }
        public double TGPosition
        {
            get { return _TGPosition; }
            set { _TGPosition = value; }
        }
        public double CustomerProfit
        {
            get { return _CustomerProfit; }
            set { _CustomerProfit = value; }
        }
        public double CustomerSellExp
        {
            get { return _CustomerSellExp; }
            set { _CustomerSellExp = value; }
        }
        public double TradePromotion
        {
            get { return _TradePromotion; }
            set { _TradePromotion = value; }
        }
        public double Advertisement
        {
            get { return _Advertisement; }
            set { _Advertisement = value; }
        }
        public double ProductDiscount
        {
            get { return _ProductDiscount; }
            set { _ProductDiscount = value; }
        }
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        public string SupplyType
        {
            get { return _SupplyType; }
            set { _SupplyType = value; }
        }
        public double VATApplicable
        {
            get { return _VATApplicable; }
            set { _VATApplicable = value; }
        }
        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }
        public int PTGSTID
        {
            get { return _nPTGSTID; }
            set { _nPTGSTID = value; }
        }
        public string PTGSTName
        {
            get { return _sPTGSTName; }
            set { _sPTGSTName = value; }
        }
        public double PTGSTPosition
        {
            get { return _PTGSTPosition; }
            set { _PTGSTPosition = value; }
        }

        public int PTGTID
        {
            get { return _nPTGTID; }
            set { _nPTGTID = value; }
        }
        public string PTGTName
        {
            get { return _sPTGTName; }
            set { _sPTGTName = value; }
        }
        public double PTGTPosition
        {
            get { return _PTGTPosition; }
            set { _PTGTPosition = value; }
        }
    }

    public class rptSalesVsBudgetCountrys : CollectionBaseCustom
    {
        public void Add(rptSalesVsBudgetCountry oSalesVsBudgetCountry)
        {
            this.List.Add(oSalesVsBudgetCountry);
        }
        public rptSalesVsBudgetCountry this[Int32 Index]
        {
            get
            {
                return (rptSalesVsBudgetCountry)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptSalesVsBudgetCountry))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        public void SalesVsBudgetCountrySummary(DateTime dbFromDate, DateTime dbToDate)
        {
            DateTime adbFromDate;
            DateTime adbToDate;

            adbFromDate = dbFromDate.AddDays(1);
            adbToDate = dbToDate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("Select  ");
            sQueryStringMaster.Append(" PGID,PGCode,PGName   ");
            sQueryStringMaster.Append(",MAGID,MAGCode,MAGName  ");
            sQueryStringMaster.Append(",ASGID,ASGCode,ASGName ");
            sQueryStringMaster.Append(",BrandID,BrandCode,BrandDesc as BrandName, ");
            sQueryStringMaster.Append("sum (OpeningStock)as Quantity, sum (OpeningStockValue)as StockValue, ");
            sQueryStringMaster.Append("sum(YearlySalesQty)as YearlySalesQty,sum(YearlySalesAmount)as YearlySalesAmt, ");
            sQueryStringMaster.Append("sum(MonthlySalesQty)as MonthlySalesQty,sum(MonthlySalesAmount)as MonthlySalesAmt, ");
            sQueryStringMaster.Append("sum(YearlyBudgetQty)as YearlyBudgetQty,sum(YearlyBudgetAmt)as YearlybudgetAmt ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select ProductDetails.* ");
            sQueryStringMaster.Append(",Stock.SBUID,Stock.SBUCode, Stock.SBUName,Stock.OpeningStock, Stock.OpeningStockValue ");
            sQueryStringMaster.Append(",isnull(sales.YearlySalesQty,0) as  YearlySalesQty , isnull(sales.YearlySalesAmount,0) as YearlySalesAmount ");
            sQueryStringMaster.Append(",isnull(sales.MonthlySalesQty,0) as  MonthlySalesQty , isnull(sales.MonthlySalesAmount,0) as MonthlySalesAmount ");
            sQueryStringMaster.Append(",isnull(Budget.YearlyBudgetQty,0) as YearlyBudgetQty,isnull(Budget.YearlyBudgetAmount,0) as  YearlyBudgetAmt   ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select x.productid, x.SBUID,x.SBUCode,x.SBUName, sum(isnull(x.currentstock,0))as currentstock  ");
            sQueryStringMaster.Append(",sum(isnull(y.qty,0)) as stockin, sum(isnull(z.qty,0)) as stockout  ");
            sQueryStringMaster.Append(",sum(isnull(x.currentstock,0)) + sum(isnull(z.qty,0)) - sum(isnull(y.qty,0)) as OpeningStock  ");
            sQueryStringMaster.Append(",sum(isnull(x.StockValue,0)) + sum(isnull(z.StockValue,0)) - sum(isnull(y.StockValue,0)) as OpeningStockValue  ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select pr.Productid,ch.ChannelID,sb.SBUID, sb.SBUCode,sb.SBUName,Warehouseid,sum(CurrentStock) as CurrentStock, sum(CurrentStock * CostPrice) as StockValue  ");
            sQueryStringMaster.Append("from t_productstock pr, t_channel ch, t_SBU sb, t_FinishedGoodsPrice fgp  ");
            sQueryStringMaster.Append("where pr.channelid = ch.channelid and  sb.SBUID = ch.SBUID and pr.channelid <> ? and warehouseid <> ? and fgp.ProductID = pr.ProductID and fgp.IsCurrent = 1 ");
            sQueryStringMaster.Append("group by pr.ProductID,ch.ChannelID,sb.SBUID, sb.SBUCode,sb.SBUName,Warehouseid  ");
            sQueryStringMaster.Append(") as x  ");
            sQueryStringMaster.Append("Full outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select sd.productid,ToChannelID,Towhid,SBUID, sum(qty)as qty, sum(stockPrice*Qty) as StockValue  ");
            sQueryStringMaster.Append("from t_productStockTran sm, t_productStockTranItem sd, t_channel ch  ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid and sm.ToChannelID = ch.ChannelID and towhid <> ? and tochannelid <> ? and trandate between ? and ?   ");
            sQueryStringMaster.Append("group by sd.productid,ToChannelID,SBUID,Towhid  ");
            sQueryStringMaster.Append(") as y  ");
            sQueryStringMaster.Append("on x.productid = y.productid and x.ChannelID = y.ToChannelID and x.SBUID = y.SBUID and x.WarehouseID = y.ToWHID   ");
            sQueryStringMaster.Append("Full outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select sd.productid,FromChannelID,SBUID,Fromwhid,  sum(qty)as qty, sum(stockPrice*Qty) as StockValue  ");
            sQueryStringMaster.Append("from t_productStockTran sm, t_productStockTranItem sd, t_channel ch   ");
            sQueryStringMaster.Append("where sd.tranid  = sm.tranid and sm.FromChannelID = ch.ChannelID and Fromwhid <> ? and FromChannelid <> ? and trandate between ? and ?  ");
            sQueryStringMaster.Append("group by sd.productid,FromChannelID,SBUID, Fromwhid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as z  ");
            sQueryStringMaster.Append("on x.productid = Z.productid and x.ChannelID = Z.FromChannelID and x.SBUID = z.SBUID and x.WarehouseID = z.FromWHID  ");
            sQueryStringMaster.Append("Group by  ");
            sQueryStringMaster.Append("x.productid,x.SBUID, x.SBUCode,x.SBUName ");
            sQueryStringMaster.Append(") as Stock ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select  ProductID ");
            sQueryStringMaster.Append(",SBUID ");
            sQueryStringMaster.Append(",sum(YearlySalesQty) as YearlySalesQty, sum(YearlySalesAmount) as YearlySalesAmount  ");
            sQueryStringMaster.Append(",sum(MonthlySalesQty) as   MonthlySalesQty, sum(MonthlySalesAmount) as MonthlySalesAmount ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("SELECT  qqq.ProductID, qqq2.* ");
            sQueryStringMaster.Append(",qqq.YearlySalesQty, qqq.YearlySalesAmount, isnull(qqq1.MonthlySalesQty,0) as MonthlySalesQty ,isnull( qqq1.MonthlySalesAmount,0) as MonthlySalesAmount ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select Productid,CustomerID ");
            sQueryStringMaster.Append(",isnull(sum(QuantityCr)-abs(sum(QuantityDr)),0) as YearlySalesQty, isnull(sum(AmountCr)-abs(sum(AmountDr)),0) as YearlySalesAmount   ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID ");
            sQueryStringMaster.Append(",sum(quantity) as QuantityCr , sum(unitPrice*Quantity) as AmountCr, 0 as QuantityDr, 0 as AmountDr   ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ? and im.Invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in(?,?,?,?)  and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID ");
            sQueryStringMaster.Append("union all   ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID ");
            sQueryStringMaster.Append(",0 as QuantityCr , 0 as AmountCr, sum(quantity) as QuantityDr, sum(unitPrice*Quantity) as AmountDr   ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ? and im.Invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in(?,?,?,?,?)  and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as qq group by Productid,CustomerID ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as qqq   ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select Productid,CustomerID ");
            sQueryStringMaster.Append(",isnull(sum(QuantityCr)-abs(sum(QuantityDr)),0) as MonthlySalesQTY, isnull(sum(AmountCr)-abs(sum(AmountDr)),0) as MonthlySalesAmount   ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID ");
            sQueryStringMaster.Append(",sum(quantity) as QuantityCr , sum(unitPrice*Quantity) as AmountCr, 0 as QuantityDr, 0 as AmountDr   ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ? and im.Invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in(?,?,?,?)  and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID ");
            sQueryStringMaster.Append("union all   ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID ");
            sQueryStringMaster.Append(",0 as QuantityCr , 0 as AmountCr, sum(quantity) as QuantityDr, sum(unitPrice*Quantity) as AmountDr   ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ? and im.Invoicedate< ?  ");
            sQueryStringMaster.Append("and im.invoicetypeid in(?,?,?,?,?)  and invoicestatus not in (?)   ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as qq group by Productid,CustomerID ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as qqq1   ");
            sQueryStringMaster.Append("on qqq.ProductID = qqq1.ProductID and qqq.CustomerID = qqq1.CustomerID  ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("(select * from v_customerDetails) ");
            sQueryStringMaster.Append("as qqq2 on qqq.customerid = qqq2.customerid  ");
            sQueryStringMaster.Append(") as Sales  ");
            sQueryStringMaster.Append("group by SBUID, ProductID ");
            sQueryStringMaster.Append(") as Sales ");
            sQueryStringMaster.Append("on stock.SBUID = sales.SBUID and Stock.ProductID = Sales.ProductID ");
            sQueryStringMaster.Append("left outer join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select SBUID,ProductGroupID as ProductID, Sum(Qty) as YearlyBudgetQty,Sum(Turnover) as YearlyBudgetAmount    ");
            sQueryStringMaster.Append("from t_planbudgettarget   ");
            sQueryStringMaster.Append("where plantype in (?) and productgrouptype in (?) and year(perioddate) = year(?)   ");
            sQueryStringMaster.Append("Group By SBUID,ProductGroupID   ");
            sQueryStringMaster.Append(") as Budget   ");
            sQueryStringMaster.Append("on Budget.Productid = Stock.Productid and Budget.SBUID = Stock.SBUID   ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from v_ProductDetails ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as ProductDetails on ProductDetails.ProductID = Stock.ProductID ");
            sQueryStringMaster.Append(")as FinalQuery ");
            sQueryStringMaster.Append("where OpeningStock <> 0 or YearlySalesQty <> 0 or YearlyBudgetQty <> 0  ");
            sQueryStringMaster.Append("Group By  ");
            sQueryStringMaster.Append("PGID,PGCode,PGName   ");
            sQueryStringMaster.Append(",MAGID,MAGCode,MAGName  ");
            sQueryStringMaster.Append(",ASGID,ASGCode,ASGName ");
            sQueryStringMaster.Append(",BrandID,BrandCode,BrandDesc ");


            cmd.CommandTimeout = 0;
            cmd.CommandText = sQueryStringMaster.ToString();

            cmd.Parameters.AddWithValue("ChannelType", (short)Dictionary.ChannelType.SYSTEM);
            cmd.Parameters.AddWithValue("WarehouseType", (short)Dictionary.WarehouseType.SYSTEM);

            cmd.Parameters.AddWithValue("WarehouseType", (short)Dictionary.WarehouseType.SYSTEM);
            cmd.Parameters.AddWithValue("ChannelType", (short)Dictionary.ChannelType.SYSTEM);
            cmd.Parameters.AddWithValue("TranDate", adbFromDate);
            cmd.Parameters.AddWithValue("TranDate", adbToDate);

            cmd.Parameters.AddWithValue("WarehouseType", (short)Dictionary.WarehouseType.SYSTEM);
            cmd.Parameters.AddWithValue("ChannelType", (short)Dictionary.ChannelType.SYSTEM);
            cmd.Parameters.AddWithValue("TranDate", adbFromDate);
            cmd.Parameters.AddWithValue("TranDate", adbToDate);
 
            cmd.Parameters.AddWithValue("InvoiceDate", dbFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", adbToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", adbToDate);

            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dbFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", adbToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", adbToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dbFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", adbToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", adbToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("InvoiceDate", dbFromDate);
            cmd.Parameters.AddWithValue("InvoiceDate", adbToDate);
            cmd.Parameters.AddWithValue("InvoiceDate", adbToDate);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("PlanType", Dictionary.PlanType.Budget);
            cmd.Parameters.AddWithValue("ProductGroupType", Dictionary.BudgetTargetProductGroupType.Product);
            cmd.Parameters.AddWithValue("PeriodDate", dbToDate);


            GetSalesVsBudgetCountryWise(cmd);

        }

        private void GetSalesVsBudgetCountryWise(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptSalesVsBudgetCountry oItem = new rptSalesVsBudgetCountry();

                    oItem.SBUID = -1;
                    oItem.SBUCode = "";
                    oItem.SBUName = "";
                    oItem.AreaId = -1;
                    oItem.AreaCode = "";
                    oItem.AreaName = "";
                    oItem.TerritoryId = -1;
                    oItem.TerritoryCode = "";
                    oItem.TerritoryName = "";
                    oItem.CustomerId = -1;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";
                    oItem.CustomerTypeId = -1;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";
                    oItem.AGID = -1;
                    oItem.AGCode = "";
                    oItem.AGName = "";
                    oItem.ProductID = -1;
                    oItem.ProductCode = "";
                    oItem.ProductName = "";
                    oItem.TGID = -1;
                    oItem.TGCode = "";
                    oItem.TGName = "";
                    oItem.PGID = -1;
                    oItem.PGCode = "";
                    oItem.PGName = "";
                    oItem.MAGId = -1;
                    oItem.MAGCode = "";
                    oItem.MAGName = "";

                    if (reader["ASGID"] != DBNull.Value)
                        oItem.ASGId = Convert.ToInt32(reader["ASGID"]);
                    else oItem.ASGId = -1;

                    oItem.ASGCode = "";

                    if (reader["ASGName"] != DBNull.Value)
                        oItem.ASGName = (string)reader["ASGName"];
                    else oItem.ASGName = "";
                    oItem.BrandID = -1;
                    oItem.BrandCode = "";
                    if (reader["BrandName"] != DBNull.Value)
                        oItem.BrandName = (string)reader["BrandName"];
                    else oItem.BrandName = "";
                    oItem.ChannelId = -1;
                    oItem.ChannelCode = "";
                    oItem.ChannelName = "";
                    if (reader["Quantity"] != DBNull.Value)
                        oItem.Quantity = Convert.ToDouble(reader["Quantity"]);
                    else oItem.Quantity = 0;
                    if (reader["StockValue"] != DBNull.Value)
                        oItem.StockValue = Convert.ToDouble(reader["StockValue"]);
                    else oItem.StockValue = 0;
                    oItem.SalesQty = 0;
                    oItem.SalesAmt = 0;
                    if (reader["MonthlySalesQty"] != DBNull.Value)
                        oItem.MonthlySalesQty = Convert.ToDouble(reader["MonthlySalesQty"]);
                    else oItem.MonthlySalesQty = 0;
                    if (reader["MonthlySalesAmt"] != DBNull.Value)
                        oItem.MonthlySalesAmt = Convert.ToDouble(reader["MonthlySalesAmt"]);
                    else oItem.MonthlySalesAmt = 0;
                    oItem.MonthlyBudgetQty = 0;
                    oItem.MonthlyBudgetAmt = 0;
                    if (reader["YearlySalesQty"] != DBNull.Value)
                        oItem.YearlySalesQty = Convert.ToDouble(reader["YearlySalesQty"]);
                    else oItem.YearlySalesQty = 0;
                    if (reader["YearlySalesAmt"] != DBNull.Value)
                        oItem.YearlySalesAmt = Convert.ToDouble(reader["YearlySalesAmt"]);
                    else oItem.YearlySalesAmt = 0;
                    if (reader["YearlyBudgetQty"] != DBNull.Value)
                        oItem.YearlyBudgetQty = Convert.ToDouble(reader["YearlyBudgetQty"]);
                    else oItem.YearlyBudgetQty = 0;
                    if (reader["YearlyBudgetAmt"] != DBNull.Value)
                        oItem.YearlyBudgetAmt = Convert.ToDouble(reader["YearlyBudgetAmt"]);
                    else oItem.YearlyBudgetAmt = 0;
                    oItem.TotalOutstanding = 0;
                    oItem.TotalCreditLimit = 0;
                    oItem.TGPosition = 0;
                    oItem.CustomerProfit = 0;
                    oItem.CustomerSellExp = 0;
                    oItem.TradePromotion = 0;
                    oItem.Advertisement = 0;
                    oItem.ProductDiscount = 0;
                    oItem.VAT = 0;
                    oItem.SupplyType = "";
                    oItem.VATApplicable = 0;
                    oItem.TradePrice = 0;
                    oItem.CostPrice = 0;
                    oItem.PTGSTID = -1;
                    oItem.PTGSTName = "";
                    oItem.PTGSTPosition = 0;
                    oItem.PTGTID = -1;
                    oItem.PTGTName = "";
                    oItem.PTGTPosition = 0;


                    Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void FromDataSetSalesVsBudgetCountryWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptSalesVsBudgetCountry oSalesVsBudgetCountry = new rptSalesVsBudgetCountry();

                    oSalesVsBudgetCountry.SBUID = -1;
                    oSalesVsBudgetCountry.SBUCode = "";
                    oSalesVsBudgetCountry.SBUName = "";
                    oSalesVsBudgetCountry.AreaId = -1;
                    oSalesVsBudgetCountry.AreaCode = "";
                    oSalesVsBudgetCountry.AreaName = "";
                    oSalesVsBudgetCountry.TerritoryId = -1;
                    oSalesVsBudgetCountry.TerritoryCode = "";
                    oSalesVsBudgetCountry.TerritoryName = "";
                    oSalesVsBudgetCountry.CustomerId = -1;
                    oSalesVsBudgetCountry.CustomerCode = "";
                    oSalesVsBudgetCountry.CustomerName = "";
                    oSalesVsBudgetCountry.CustomerTypeId = -1;
                    oSalesVsBudgetCountry.CustomerTypeCode = "";
                    oSalesVsBudgetCountry.CustomerTypeName = "";
                    oSalesVsBudgetCountry.AGID = -1;
                    oSalesVsBudgetCountry.AGCode = "";
                    oSalesVsBudgetCountry.AGName = "";
                    oSalesVsBudgetCountry.ProductID = -1;
                    oSalesVsBudgetCountry.ProductCode = "";
                    oSalesVsBudgetCountry.ProductName = "";
                    oSalesVsBudgetCountry.TGID = -1;
                    oSalesVsBudgetCountry.TGCode = "";
                    oSalesVsBudgetCountry.TGName = "";
                    oSalesVsBudgetCountry.PGID = -1;
                    oSalesVsBudgetCountry.PGCode = "";
                    oSalesVsBudgetCountry.PGName = "";
                    oSalesVsBudgetCountry.MAGId = -1;
                    oSalesVsBudgetCountry.MAGCode = "";
                    oSalesVsBudgetCountry.MAGName = "";
                    oSalesVsBudgetCountry.ASGId = Convert.ToInt32(oRow["ASGId"].ToString());
                    oSalesVsBudgetCountry.ASGCode = "";
                    oSalesVsBudgetCountry.ASGName = (string)oRow["ASGName"];
                    oSalesVsBudgetCountry.BrandID = -1;
                    oSalesVsBudgetCountry.BrandCode = "";
                    oSalesVsBudgetCountry.BrandName = (string)oRow["BrandName"];
                    oSalesVsBudgetCountry.ChannelId = -1;
                    oSalesVsBudgetCountry.ChannelCode = "";
                    oSalesVsBudgetCountry.ChannelName = "";
                    oSalesVsBudgetCountry.Quantity = (double)oRow["Quantity"];
                    oSalesVsBudgetCountry.StockValue = (double)oRow["StockValue"];
                    oSalesVsBudgetCountry.SalesQty = 0;
                    oSalesVsBudgetCountry.SalesAmt = 0;
                    oSalesVsBudgetCountry.MonthlySalesQty = (double)oRow["MonthlySalesQty"];
                    oSalesVsBudgetCountry.MonthlySalesAmt = (double)oRow["MonthlySalesAmt"];
                    oSalesVsBudgetCountry.MonthlyBudgetQty = 0;
                    oSalesVsBudgetCountry.MonthlyBudgetAmt = 0;
                    oSalesVsBudgetCountry.YearlySalesQty = (double)oRow["YearlySalesQty"];
                    oSalesVsBudgetCountry.YearlySalesAmt = (double)oRow["YearlySalesAmt"];
                    oSalesVsBudgetCountry.YearlyBudgetQty = (double)oRow["YearlyBudgetQty"];
                    oSalesVsBudgetCountry.YearlyBudgetAmt = (double)oRow["YearlyBudgetAmt"];
                    oSalesVsBudgetCountry.TotalOutstanding = 0;
                    oSalesVsBudgetCountry.TotalCreditLimit = 0;
                    oSalesVsBudgetCountry.TGPosition = 0;
                    oSalesVsBudgetCountry.CustomerProfit = 0;
                    oSalesVsBudgetCountry.CustomerSellExp = 0;
                    oSalesVsBudgetCountry.TradePromotion = 0;
                    oSalesVsBudgetCountry.Advertisement = 0;
                    oSalesVsBudgetCountry.ProductDiscount = 0;
                    oSalesVsBudgetCountry.VAT = 0;
                    oSalesVsBudgetCountry.SupplyType = "";
                    oSalesVsBudgetCountry.VATApplicable = 0;
                    oSalesVsBudgetCountry.TradePrice = 0;
                    oSalesVsBudgetCountry.CostPrice = 0;
                    oSalesVsBudgetCountry.PTGSTID = -1;
                    oSalesVsBudgetCountry.PTGSTName = "";
                    oSalesVsBudgetCountry.PTGSTPosition = 0;
                    oSalesVsBudgetCountry.PTGTID = -1;
                    oSalesVsBudgetCountry.PTGTName = "";
                    oSalesVsBudgetCountry.PTGTPosition = 0;

                    InnerList.Add(oSalesVsBudgetCountry);
                }

                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

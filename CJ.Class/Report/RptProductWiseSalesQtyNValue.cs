// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: Feb 29, 2012
// Time :  11:00 AM
// Description: Product Wise Sales Qty N Value [146]
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
    
   public class RptProductWiseSalesQtyNValue
    {
        public int _nASGID;
        public string _sASGCode;
        public string _sASGName;

        public int _nAGID;
        public string _sAGCode;
        public string _sAGName;

        public int _nMAGID;
        public string _sMAGCode;
        public string _sMAGName;

        public int _nBrandID;
        public string _sBrandCode;
        public string _sBrandName;

        public int _nPGID;
        public string _sPGCode;
        public string _sPGName;     

        public int _nProductID;
        public string _sProductCode;
        public string _sProductName;
        
        public int _VATApplicable;
        public int _sSupplyType;
        public int _SalesQty;
        public double _SalesAmt;
        public double _VAT;
        public double _CostPrice;
        public double _TradePrice;
        public double _ProductDiscount;
        public double _VatAmount;


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
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
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
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
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
        
        public int VATApplicable
        {
            get { return _VATApplicable; }
            set { _VATApplicable = value; }
        }

       public int SupplyType
       {
           get { return _sSupplyType; }
           set { _sSupplyType = value; }
       }
       public int SalesQty
       {
           get { return _SalesQty; }
           set { _SalesQty = value; }
       }
       
       public double SalesAmt
       {
           get { return _SalesAmt; }
           set { _SalesAmt = value; }
       }

       public double VAT
       {
           get { return _VAT; }
           set { _VAT = value; }
       }

       public double CostPrice
       {
           get { return _CostPrice; }
           set { _CostPrice = value; }
       }

       public double TradePrice
       {
           get { return _TradePrice; }
           set { _TradePrice = value; }
       }

       public double ProductDiscount 
       {
           get { return _ProductDiscount; }
           set { _ProductDiscount = value; }
       }
       public double VatAmount
       {
           get { return _VatAmount; }
           set { _VatAmount = value; }
       }
       
    }

    public class RptProductWiseSalesQtyNValueDetails : CollectionBaseCustom
    {
        public void Add(RptProductWiseSalesQtyNValue oRptProductWiseSalesQtyNValue)
        {
            this.List.Add(oRptProductWiseSalesQtyNValue);
        }
        public RptProductWiseSalesQtyNValue this[Int32 Index]
        {
            get
            {
                return (RptProductWiseSalesQtyNValue)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptProductWiseSalesQtyNValue))))
                {
                    throw new Exception(" Type can't be converted");
                }
                this.List[Index] = value;
            }
        }


        public void ProductWiseSalesQtyNValue( DateTime dYFromDate, DateTime dYTodate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Product Wise Sales Qty and Value [146]

            //  Between Date Query  

            sQueryStringMaster.Append("select ");
            sQueryStringMaster.Append("ASGID,ASGCode,ASGName      ");
            sQueryStringMaster.Append(",AGID,AGCode,AGName      ");
            sQueryStringMaster.Append(",MAGID,MAGCode,MAGName      ");
            sQueryStringMaster.Append(",BrandID,BrandCode, BrandDesc as BrandName   ");
            sQueryStringMaster.Append(",PGID,PGCode,PGName      ");
            sQueryStringMaster.Append(",Sales.ProductID,ProductCode,ProductName,VatApplicable,SupplyType   ");
            sQueryStringMaster.Append(",sum(isnull(SalesQTY,0)) as SalesQty,sum(isnull(SalesAmount,0)) as SalesAmt       ");
            sQueryStringMaster.Append(",sum(isnull(Sales.VAT,0)) as VAT, sum(isnull(Sales.CostPrice,0)) as CostPrice, sum(isnull(Sales.TradePrice,0)) as TradePrice, sum(isnull(Discount,0)) as ProductDiscount ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select       ");
            sQueryStringMaster.Append("Productid,CustomerID, VATAmount      ");
            sQueryStringMaster.Append(",(sum(QuantityCr)-sum(QuantityDr)) as SalesQty, (sum(AmountCr)-sum(AmountDr)) as SalesAmount       ");
            sQueryStringMaster.Append(",(sum(VATCr)-sum(VATDr)) as VAT, (sum(DiscountCr)-sum(DiscountDr)) as Discount , (sum(CostPriceCr) - sum(CostPriceDr)) as CostPrice,(sum(TradePriceCr) - sum(TradePriceDr)) as TradePrice ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID       ");
            sQueryStringMaster.Append(",sum(quantity + isnull(freeQty,0)) as QuantityCr , sum(unitPrice*(Quantity+ isnull(freeQty,0))) as AmountCr, 0 as QuantityDr, 0 as AmountDr    ");
            sQueryStringMaster.Append(",sum((quantity+ isnull(freeQty,0))*SID.TradePrice*VATAmount) as VATCr , abs(sum((Quantity+ isnull(freeQty,0))*SID.CostPrice)) as  CostPriceCr, abs(sum((quantity+ isnull(freeQty,0))*SID.TradePrice)) as TradePriceCr, sum(ProductDiscount*Quantity) as DiscountCr, 0 as VATDr,0 as CostPriceDr, 0 as TradePriceDr, 0 as DiscountDr,VATAmount        ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ?   and    Invoicedate < ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)     ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID,VATAmount  ");
            sQueryStringMaster.Append("Union All ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID         ");
            sQueryStringMaster.Append(",0 as QuantityCr , 0 as AmountCr, abs( sum(quantity + isnull(freeQty,0))) as QuantityDr, abs (sum(unitPrice*(Quantity+ isnull(freeQty,0)))) as AmountDr       ");
            sQueryStringMaster.Append(",0 as VATCr, 0 as CostPriceCr, 0 as TradePriceCr  , 0 as DiscountCr,abs (sum((quantity+ isnull(freeQty,0))*SID.TradePrice*VATAmount)) as VATDr, abs (sum((Quantity+ isnull(freeQty,0))*SID.CostPrice)) as  CostPriceDr, abs (sum((quantity+ isnull(freeQty,0))*SID.TradePrice)) as TradePriceDr, abs (sum(ProductDiscount*Quantity)) as DiscountDr,VATAmount         ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID    ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ?   and    Invoicedate < ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?,?,?) and invoicestatus not in (?)     ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID,VATAmount      ");
            sQueryStringMaster.Append(")as s ");
            sQueryStringMaster.Append("Group by Productid,CustomerID, VATAmount ");
            sQueryStringMaster.Append(") as Sales ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from v_ProductDetails ");
            sQueryStringMaster.Append(") as pd on sales.Productid = pd.Productid ");
            sQueryStringMaster.Append("group by  ");
            sQueryStringMaster.Append("ASGID,ASGCode,ASGName      ");
            sQueryStringMaster.Append(",AGID,AGCode,AGName      ");
            sQueryStringMaster.Append(",MAGID,MAGCode,MAGName      ");
            sQueryStringMaster.Append(",BrandID,BrandCode, BrandDesc ");
            sQueryStringMaster.Append(",PGID,PGCode,PGName      ");
            sQueryStringMaster.Append(",Sales.ProductID,ProductCode,ProductName,VatApplicable,SupplyType  ");

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYTodate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dYTodate.AddDays(1));

            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYTodate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dYTodate.AddDays(1));

            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            GetProductWiseSalesQtyNValue(oCmd, 0);
        }

        public void ProductSalNValueVATAmount(DateTime dYFromDate, DateTime dYTodate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Product Wise Sales Qty and Value [146]

            //  VAT Amount  

            sQueryStringMaster.Append("select ");
            sQueryStringMaster.Append("ASGID,ASGCode,ASGName      ");
            sQueryStringMaster.Append(",AGID,AGCode,AGName      ");
            sQueryStringMaster.Append(",MAGID,MAGCode,MAGName      ");
            sQueryStringMaster.Append(",BrandID,BrandCode, BrandDesc as BrandName   ");
            sQueryStringMaster.Append(",PGID,PGCode,PGName      ");
            sQueryStringMaster.Append(",Sales.ProductID,ProductCode,ProductName,VatApplicable,SupplyType,VatAmount   ");
            sQueryStringMaster.Append(",sum(isnull(SalesQTY,0)) as SalesQty,sum(isnull(SalesAmount,0)) as SalesAmt       ");
            sQueryStringMaster.Append(",sum(isnull(Sales.VAT,0)) as VAT, sum(isnull(Sales.CostPrice,0)) as CostPrice, sum(isnull(Sales.TradePrice,0)) as TradePrice, sum(isnull(Discount,0)) as ProductDiscount ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select       ");
            sQueryStringMaster.Append("Productid,CustomerID, VATAmount      ");
            sQueryStringMaster.Append(",(sum(QuantityCr)-sum(QuantityDr)) as SalesQty, (sum(AmountCr)-sum(AmountDr)) as SalesAmount       ");
            sQueryStringMaster.Append(",(sum(VATCr)-sum(VATDr)) as VAT, (sum(DiscountCr)-sum(DiscountDr)) as Discount , (sum(CostPriceCr) - sum(CostPriceDr)) as CostPrice,(sum(TradePriceCr) - sum(TradePriceDr)) as TradePrice ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID       ");
            sQueryStringMaster.Append(",sum(quantity + isnull(freeQty,0)) as QuantityCr , sum(unitPrice*(Quantity+ isnull(freeQty,0))) as AmountCr, 0 as QuantityDr, 0 as AmountDr    ");
            sQueryStringMaster.Append(",sum((quantity+ isnull(freeQty,0))*SID.TradePrice*VATAmount) as VATCr , abs(sum((Quantity+ isnull(freeQty,0))*SID.CostPrice)) as  CostPriceCr, abs(sum((quantity+ isnull(freeQty,0))*SID.TradePrice)) as TradePriceCr, sum(ProductDiscount*Quantity) as DiscountCr, 0 as VATDr,0 as CostPriceDr, 0 as TradePriceDr, 0 as DiscountDr,VATAmount        ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ?   and    Invoicedate < ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)     ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID,VATAmount  ");
            sQueryStringMaster.Append("Union All ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID         ");
            sQueryStringMaster.Append(",0 as QuantityCr , 0 as AmountCr, abs( sum(quantity + isnull(freeQty,0))) as QuantityDr, abs (sum(unitPrice*(Quantity+ isnull(freeQty,0)))) as AmountDr       ");
            sQueryStringMaster.Append(",0 as VATCr, 0 as CostPriceCr, 0 as TradePriceCr  , 0 as DiscountCr,abs (sum((quantity+ isnull(freeQty,0))*SID.TradePrice*VATAmount)) as VATDr, abs (sum((Quantity+ isnull(freeQty,0))*SID.CostPrice)) as  CostPriceDr, abs (sum((quantity+ isnull(freeQty,0))*SID.TradePrice)) as TradePriceDr, abs (sum(ProductDiscount*Quantity)) as DiscountDr,VATAmount         ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID    ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ?   and    Invoicedate < ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?,?,?) and invoicestatus not in (?)     ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID,VATAmount      ");
            sQueryStringMaster.Append(")as s ");
            sQueryStringMaster.Append("Group by Productid,CustomerID, VATAmount ");
            sQueryStringMaster.Append(") as Sales ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from v_ProductDetails ");
            sQueryStringMaster.Append(") as pd on sales.Productid = pd.Productid ");
            sQueryStringMaster.Append("group by  ");
            sQueryStringMaster.Append("ASGID,ASGCode,ASGName      ");
            sQueryStringMaster.Append(",AGID,AGCode,AGName      ");
            sQueryStringMaster.Append(",MAGID,MAGCode,MAGName      ");
            sQueryStringMaster.Append(",BrandID,BrandCode, BrandDesc ");
            sQueryStringMaster.Append(",PGID,PGCode,PGName      ");
            sQueryStringMaster.Append(",Sales.ProductID,ProductCode,ProductName,VatApplicable,SupplyType,VatAmount  ");
            
            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYTodate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dYTodate.AddDays(1));

            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYTodate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dYTodate.AddDays(1));

            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            GetProductWiseSalesQtyNValue(oCmd, 1);
        }

        public void ProductSalNValueVATChallan(DateTime dYFromDate, DateTime dYTodate, string FromChall, string ToChall)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Product Wise Sales Qty and Value [146]
            //  VAT Challan Wise 

            sQueryStringMaster.Append("select ");
            sQueryStringMaster.Append("ASGID,ASGCode,ASGName      ");
            sQueryStringMaster.Append(",AGID,AGCode,AGName      ");
            sQueryStringMaster.Append(",MAGID,MAGCode,MAGName      ");
            sQueryStringMaster.Append(",BrandID,BrandCode, BrandDesc as BrandName   ");
            sQueryStringMaster.Append(",PGID,PGCode,PGName      ");
            sQueryStringMaster.Append(",Sales.ProductID,ProductCode,ProductName,VatApplicable,SupplyType   ");
            sQueryStringMaster.Append(",sum(isnull(SalesQTY,0)) as SalesQty,sum(isnull(SalesAmount,0)) as SalesAmt       ");
            sQueryStringMaster.Append(",sum(isnull(Sales.VAT,0)) as VAT, sum(isnull(Sales.CostPrice,0)) as CostPrice, sum(isnull(Sales.TradePrice,0)) as TradePrice, sum(isnull(Discount,0)) as ProductDiscount ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select       ");
            sQueryStringMaster.Append("Productid,CustomerID, VATAmount      ");
            sQueryStringMaster.Append(",(sum(QuantityCr)-sum(QuantityDr)) as SalesQty, (sum(AmountCr)-sum(AmountDr)) as SalesAmount       ");
            sQueryStringMaster.Append(",(sum(VATCr)-sum(VATDr)) as VAT, (sum(DiscountCr)-sum(DiscountDr)) as Discount , (sum(CostPriceCr) - sum(CostPriceDr)) as CostPrice,(sum(TradePriceCr) - sum(TradePriceDr)) as TradePrice ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID       ");
            sQueryStringMaster.Append(",sum(quantity + isnull(freeQty,0)) as QuantityCr , sum(unitPrice*(Quantity+ isnull(freeQty,0))) as AmountCr, 0 as QuantityDr, 0 as AmountDr    ");
            sQueryStringMaster.Append(",sum((quantity+ isnull(freeQty,0))*SID.TradePrice*VATAmount) as VATCr , abs(sum((Quantity+ isnull(freeQty,0))*SID.CostPrice)) as  CostPriceCr, abs(sum((quantity+ isnull(freeQty,0))*SID.TradePrice)) as TradePriceCr, sum(ProductDiscount*Quantity) as DiscountCr, 0 as VATDr,0 as CostPriceDr, 0 as TradePriceDr, 0 as DiscountDr,VATAmount        ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ?   and    Invoicedate < ? and im.VATChallanNo between ? and ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?)     ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID,VATAmount  ");
            sQueryStringMaster.Append("Union All ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID         ");
            sQueryStringMaster.Append(",0 as QuantityCr , 0 as AmountCr, abs( sum(quantity + isnull(freeQty,0))) as QuantityDr, abs (sum(unitPrice*(Quantity+ isnull(freeQty,0)))) as AmountDr       ");
            sQueryStringMaster.Append(",0 as VATCr, 0 as CostPriceCr, 0 as TradePriceCr  , 0 as DiscountCr,abs (sum((quantity+ isnull(freeQty,0))*SID.TradePrice*VATAmount)) as VATDr, abs (sum((Quantity+ isnull(freeQty,0))*SID.CostPrice)) as  CostPriceDr, abs (sum((quantity+ isnull(freeQty,0))*SID.TradePrice)) as TradePriceDr, abs (sum(ProductDiscount*Quantity)) as DiscountDr,VATAmount         ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID    ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ?   and    Invoicedate < ? and im.VATChallanNo between ? and ? ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?,?,?) and invoicestatus not in (?)     ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID,VATAmount      ");
            sQueryStringMaster.Append(")as s ");
            sQueryStringMaster.Append("Group by Productid,CustomerID, VATAmount ");
            sQueryStringMaster.Append(") as Sales ");
            sQueryStringMaster.Append("inner join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from v_ProductDetails ");
            sQueryStringMaster.Append(") as pd on sales.Productid = pd.Productid ");
            sQueryStringMaster.Append("group by  ");
            sQueryStringMaster.Append("ASGID,ASGCode,ASGName      ");
            sQueryStringMaster.Append(",AGID,AGCode,AGName      ");
            sQueryStringMaster.Append(",MAGID,MAGCode,MAGName      ");
            sQueryStringMaster.Append(",BrandID,BrandCode, BrandDesc ");
            sQueryStringMaster.Append(",PGID,PGCode,PGName      ");
            sQueryStringMaster.Append(",Sales.ProductID,ProductCode,ProductName,VatApplicable,SupplyType  ");


            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();


            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYTodate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dYTodate.AddDays(1));

            oCmd.Parameters.AddWithValue("VATChallanNo", FromChall);
            oCmd.Parameters.AddWithValue("VATChallanNo", ToChall);

            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);


            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYTodate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dYTodate.AddDays(1));

            oCmd.Parameters.AddWithValue("VATChallanNo", FromChall);
            oCmd.Parameters.AddWithValue("VATChallanNo", ToChall);


            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.ISSUE_SALES_PROMOTION_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REPLACEMENT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            
            GetProductWiseSalesQtyNValue(oCmd,0);
        }


        public void GetProductWiseSalesQtyNValue(OleDbCommand cmd,int nVatAmount)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptProductWiseSalesQtyNValue oItem = new RptProductWiseSalesQtyNValue();

                    if (reader["PGID"] != DBNull.Value)
                        oItem.PGID =Convert.ToInt32(reader["PGID"]);
                    else oItem.PGID = -1;

                    if (reader["PGCode"] != DBNull.Value)
                        oItem.PGCode = (string)reader["PGCode"];
                    else oItem.PGCode = "";

                    if (reader["PGName"] != DBNull.Value)
                        oItem.PGName = (string)reader["PGName"];
                    else oItem.PGName = "";

                    if (reader["MAGID"] != DBNull.Value)
                        oItem.MAGID =Convert.ToInt32(reader["MAGID"]);
                    else oItem.MAGID = -1;

                    if (reader["MAGCode"] != DBNull.Value)
                        oItem.MAGCode = (string)reader["MAGCode"];
                    else oItem.MAGCode = "";

                    if (reader["MAGName"] != DBNull.Value)
                        oItem.MAGName = (string)reader["MAGName"];
                    else oItem.MAGName = "";

                    if (reader["ASGID"] != DBNull.Value)
                        oItem.ASGID = Convert.ToInt32( reader["ASGID"]);
                    else oItem.ASGID = -1;

                    if (reader["ASGCode"] != DBNull.Value)
                        oItem.ASGCode = (string)reader["ASGCode"];
                    else oItem.ASGCode = "";

                    if (reader["ASGName"] != DBNull.Value)
                        oItem.ASGName = (string)reader["ASGName"];
                    else oItem.ASGName = "";

                    if (reader["AGID"] != DBNull.Value)
                        oItem.AGID =Convert.ToInt32(reader["AGID"]);
                    else oItem.AGID = -1;

                    if (reader["AGCode"] != DBNull.Value)
                        oItem.AGCode = (string)reader["AGCode"];
                    else oItem.AGCode = "";

                    if (reader["AGName"] != DBNull.Value)
                        oItem.AGName = (string)reader["AGName"];
                    else oItem.AGName = "";

                    if (reader["BrandID"] != DBNull.Value)
                        oItem.BrandID =Convert.ToInt32(reader["BrandID"]);
                    else oItem.BrandID = -1;

                    if (reader["BrandCode"] != DBNull.Value)
                        oItem.BrandCode = (string)reader["BrandCode"];
                    else oItem.BrandCode = "";

                    if (reader["BrandName"] != DBNull.Value)
                        oItem.BrandName = (string)reader["BrandName"];
                    else oItem.BrandName = "";                    

                    if (reader["ProductID"] != DBNull.Value)
                        oItem.ProductID =Convert.ToInt32(reader["ProductID"]);
                    else oItem.ProductID = 0;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    
                    if (reader["VATApplicable"] != DBNull.Value)
                        oItem.VATApplicable = Convert.ToInt32(reader["VATApplicable"]);
                    else oItem.VATApplicable = 0;

                    if (reader["SupplyType"] != DBNull.Value)
                        oItem.SupplyType =Convert.ToInt32(reader["SupplyType"]);
                    else oItem.SupplyType = 0;

                    if (reader["SalesQty"] != DBNull.Value)
                        oItem.SalesQty = Convert.ToInt32(reader["SalesQty"]);
                    else oItem.SalesQty = 0;

                    if (reader["SalesAmt"] != DBNull.Value)
                        oItem.SalesAmt = Convert.ToDouble(reader["SalesAmt"]);
                    else oItem.SalesAmt = 0;

                    if (reader["VAT"] != DBNull.Value)
                        oItem.VAT = Convert.ToDouble(reader["VAT"]);
                    else oItem.VAT = 0;

                    if (reader["SalesAmt"] != DBNull.Value)
                        oItem.CostPrice = Convert.ToDouble(reader["CostPrice"]);
                    else oItem.CostPrice = 0;

                    if (reader["TradePrice"] != DBNull.Value)
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"]);
                    else oItem.TradePrice = 0;

                    if (reader["ProductDiscount"] != DBNull.Value)
                        oItem.ProductDiscount = Convert.ToDouble(reader["ProductDiscount"]);
                    else oItem.ProductDiscount = 0;

                    if (nVatAmount > 0)
                    {
                        if (reader["VatAmount"] != DBNull.Value)
                            oItem.VatAmount = Convert.ToDouble(reader["VatAmount"]);
                        else oItem.VatAmount = 0;
                    }

                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void FromDataSetProductWiseSalesQtyNValue(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptProductWiseSalesQtyNValue oRptProductWiseSalesQtyNValue = new RptProductWiseSalesQtyNValue();

                    oRptProductWiseSalesQtyNValue.PGID = Convert.ToInt32(oRow["PGID"].ToString());
                    oRptProductWiseSalesQtyNValue.PGCode = (string)oRow["PGCode"];
                    oRptProductWiseSalesQtyNValue.PGName = (string)oRow["PGName"];

                    oRptProductWiseSalesQtyNValue.MAGID = Convert.ToInt32(oRow["MAGID"].ToString());
                    oRptProductWiseSalesQtyNValue.MAGCode = (string)oRow["MAGCode"];
                    oRptProductWiseSalesQtyNValue.MAGName = (string)oRow["MAGName"];

                    oRptProductWiseSalesQtyNValue.ASGID = Convert.ToInt32(oRow["ASGId"].ToString());
                    oRptProductWiseSalesQtyNValue.ASGCode = (string)oRow["ASGCode"];
                    oRptProductWiseSalesQtyNValue.ASGName = (string)oRow["ASGName"];

                    oRptProductWiseSalesQtyNValue.AGID = Convert.ToInt32(oRow["AGID"].ToString());
                    oRptProductWiseSalesQtyNValue.AGCode = (string)oRow["AGCode"];
                    oRptProductWiseSalesQtyNValue.AGName = (string)oRow["AGName"];

                    oRptProductWiseSalesQtyNValue.ProductID = Convert.ToInt32(oRow["ProductID"].ToString());
                    oRptProductWiseSalesQtyNValue.ProductCode = (string)oRow["ProductCode"];
                    oRptProductWiseSalesQtyNValue.ProductName = (string)oRow["ProductName"];

                    oRptProductWiseSalesQtyNValue.BrandID = Convert.ToInt32(oRow["BrandID"].ToString());
                    oRptProductWiseSalesQtyNValue.BrandCode = (string)oRow["BrandCode"];
                    oRptProductWiseSalesQtyNValue.BrandName = (string)oRow["BrandName"];
                   
                                        
                    oRptProductWiseSalesQtyNValue.VATApplicable = Convert.ToInt32(oRow["VATApplicable"]);
                    oRptProductWiseSalesQtyNValue.SupplyType =Convert.ToInt32(oRow["SupplyType"]);
                    oRptProductWiseSalesQtyNValue.SalesQty = Convert.ToInt32(oRow["SalesQty"]);
                    oRptProductWiseSalesQtyNValue.SalesAmt = Convert.ToDouble(oRow["SalesAmt"]);                    
                    oRptProductWiseSalesQtyNValue.VAT = Convert.ToDouble(oRow["VAT"]);
                    oRptProductWiseSalesQtyNValue.CostPrice = Convert.ToDouble(oRow["CostPrice"]);
                    oRptProductWiseSalesQtyNValue.TradePrice = Convert.ToDouble(oRow["TradePrice"]);
                    oRptProductWiseSalesQtyNValue.ProductDiscount = Convert.ToDouble(oRow["ProductDiscount"]);
                    oRptProductWiseSalesQtyNValue.VatAmount = Convert.ToDouble(oRow["VatAmount"]);


                    InnerList.Add(oRptProductWiseSalesQtyNValue);
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

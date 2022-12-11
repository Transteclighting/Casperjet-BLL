// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Sept 21, 2011
// Time" :  03:00 PM
// Descriptio: Product Sales Qty and Value Customer Wise [61]
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
    [Serializable]
    public class ProductSalesQtyandValueCustomerWise
    {
        private long _SBUID;
        private string _sSBUCode;
        private string _sSBUName;
        private int _nChannelID;
        private string _sChannelCode;
        private string _sChannelName;
        private int _nAreaID;
        private string _sAreaCode;
        private string _sAreaName;
        private int _nTerritoryID;
        private string _sTerritoryCode;
        private string _sTerritoryName;
        private int _nCustomerTypeID;
        private string _sCustomerTypeCode;
        private string _sCustomerTypeName; 

        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName; 
        private long _PGID;
        private string _sPGCode;
        private string _sPGName;
        private long _MAGID;
        private string _sMAGCode;
        private string _sMAGName;
        private long _ASGID;
        private string _sASGCode;
        private string _sASGName;
        private long _AGID;
        private string _sAGCode;
        private string _sAGName;
        private long _BrandID;
        private string _sBrandCode;
        private string _sBrandName;
        private long _WarehouseID;
        private string _sWarehouseCode;
        private string _sWarehouseName;
       
        private int _nProductID;
        private string _nProductCode;
        private string _sProductName;
        private long _nSalesQty;
        private double _SalesAmt;
        private double _AdjustedDPAmount;
        private double _AdjustedTPAmount;
        private double _AdjustedPWAmount;
        private double _VAT;
        private double _ProductDiscount;
        public long _ProductCodeInNumber;
        private string _sRegion;

        
        
        public long SBUID
        {
            get { return _SBUID; }
            set { _SBUID = value; }
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
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
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
        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
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
        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }
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
        public int CustomerTypeID
        {
            get { return _nCustomerTypeID; }
            set { _nCustomerTypeID = value; }
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

        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
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
        public long PGID
        {
            get { return _PGID; }
            set { _PGID = value; }
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
        public long MAGID
        {
            get { return _MAGID; }
            set { _MAGID = value; }
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
        public long ASGID
        {
            get { return _ASGID; }
            set { _ASGID = value; }
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

        public long AGID
        {
            get { return _AGID; }
            set { _AGID = value; }
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
        public long BrandID
        {
            get { return _BrandID; }
            set { _BrandID = value; }
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

        public long WarehouseID
        {
            get { return _WarehouseID; }
            set { _WarehouseID = value; }
        }

        public string WarehouseCode
        {
            get { return _sWarehouseCode; }
            set { _sWarehouseCode = value; }
        }

        public string WarehouseName
        {
            get { return _sWarehouseName; }
            set { _sWarehouseName = value; }
        }

        
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public string ProductCode
        {
            get { return _nProductCode; }
            set { _nProductCode = value; }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public long SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }
        public double SalesAmt
        {
            get { return _SalesAmt; }
            set { _SalesAmt = value; }
        }
        
        public double AdjustedDPAmount
        {
            get { return _AdjustedDPAmount; }
            set { _AdjustedDPAmount = value; }
        }
        public double AdjustedTPAmount
        {
            get { return _AdjustedTPAmount; }
            set { _AdjustedTPAmount = value; }
        }
        public double AdjustedPWAmount
        {
            get { return _AdjustedPWAmount; }
            set { _AdjustedPWAmount = value; }
        }

        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        public double ProductDiscount
        {
            get { return _ProductDiscount; }
            set { _ProductDiscount = value; }
        }
        public long ProductCodeInNumber
        {
            get { return _ProductCodeInNumber; }
            set { _ProductCodeInNumber = value; }
        }
        public string Region
        {
            get { return _sRegion; }
            set { _sRegion = value; }
        }
                       
    }

    public class ProductSalesQtyandValueCustomerWiseDetails: CollectionBaseCustom
    {
        public void Add(ProductSalesQtyandValueCustomerWise oProductSalesQtyandValueCustomerWise)
        {
            this.List.Add(oProductSalesQtyandValueCustomerWise);
        }
        public ProductSalesQtyandValueCustomerWise this[Int32 Index]
        {
            get
            {
                return (ProductSalesQtyandValueCustomerWise)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(ChannelASGwiseProfitability))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void ProductSalesQtyCustomerwise(DateTime dYFromDate, DateTime dYToDate)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Query for report 61.............  

            sQueryStringMaster.Append("select     ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName      ");
            sQueryStringMaster.Append(",ChannelID, ChannelCode, ChannelDescription as ChannelName    ");
            sQueryStringMaster.Append(",CustomerTypeID, CustomerTypeCode, CustomerTypeName    ");        
               
            if (Utility.CompanyInfo == "TML")
                sQueryStringMaster.Append(",RegionName,AreaID,AreaCode, AreaName     ");
            else sQueryStringMaster.Append(",AreaID,AreaCode, AreaName     ");

            sQueryStringMaster.Append(",TerritoryID,TerritoryCode,TerritoryName   ");
            sQueryStringMaster.Append(",qqq.CustomerID,CustomerCode,CustomerName   ");
            sQueryStringMaster.Append(",PGID, PGCode, PGName      ");
            sQueryStringMaster.Append(",MAGID, MAGCode, MAGName      ");
            sQueryStringMaster.Append(",ASGID, ASGCode, ASGName       ");
            sQueryStringMaster.Append(",AGID, AGCode, AGName      ");
            sQueryStringMaster.Append(",qqq.ProductID,ProductCode,ProductName     ");
            sQueryStringMaster.Append(",BrandID, BrandCode, BrandDesc as BrandName   ");
            sQueryStringMaster.Append(",w.WarehouseID, WarehouseCode, WarehouseName  ");
            sQueryStringMaster.Append(",sum(isnull(SalesQTY,0)) as SalesQty,sum(isnull(SalesAmount,0)) as SalesAmt  ");
            sQueryStringMaster.Append(",sum(isnull(AdjustedDPAmount,0)) as AdjustedDPAmount,sum(isnull(AdjustedTPAmount,0)) as AdjustedTPAmount,sum(isnull(AdjustedPWAmount,0)) as AdjustedPWAmount         ");
            sQueryStringMaster.Append(",sum(isnull(qqq.VAT,0)) as VAT,sum(isnull(qqq.Discount,0)) as ProductDiscount        ");
            sQueryStringMaster.Append("from    ");
            sQueryStringMaster.Append("(      ");
            sQueryStringMaster.Append("select Productid,CustomerID, WarehouseID    ");
            sQueryStringMaster.Append(",isnull(sum(QuantityCr)-abs(sum(QuantityDr)),0) as SalesQty, isnull(sum(AmountCr)-abs(sum(AmountDr)),0) as SalesAmount   ");
            sQueryStringMaster.Append(",isnull(sum(AdjustedDPAmountCr)-abs(sum(AdjustedDPAmountdr)),0) as AdjustedDPAmount, isnull(sum(AdjustedTPAmountCr)-abs(sum(AdjustedTPAmountdr)),0) as AdjustedTPAmount   ");
            sQueryStringMaster.Append(", isnull(sum(AdjustedPWAmountCr)-abs(sum(AdjustedPWAmountdr)),0) as AdjustedPWAmount    ");
            sQueryStringMaster.Append(",isnull(sum(VATCr)-abs(sum(VATDr)),0) as VAT, isnull(sum(DiscountCr)-abs(sum(DiscountDr)),0) as Discount     ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(      ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID,WarehouseID    ");
            sQueryStringMaster.Append(",sum(quantity) as QuantityCr , sum(unitPrice*Quantity) as AmountCr, sum(Quantity*isnull(AdjustedDPAmount,0)) as AdjustedDPAmountCr  ");
            sQueryStringMaster.Append(",sum(Quantity*isnull(AdjustedTPAmount,0)) as AdjustedTPAmountCr, sum(Quantity*isnull(AdjustedPWAmount,0)) as AdjustedPWAmountCr    ");
            sQueryStringMaster.Append(",sum(quantity*SID.TradePrice*VATAmount) as VATCr , sum(ProductDiscount*Quantity) as DiscountCr  ");
            sQueryStringMaster.Append(", 0 as QuantityDr, 0 as AmountDr, 0 as AdjustedDPAmountdr,0 as AdjustedTPAmountdr,0 as AdjustedPWAmountdr   ");
            sQueryStringMaster.Append(", 0 as VATDr, 0 as DiscountDr         ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID    ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ? and im.Invoicedate < ?     ");
            sQueryStringMaster.Append("and im.invoicetypeid in(?,?,?,?)  and invoicestatus not in (?)      ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID, WarehouseID    ");
            sQueryStringMaster.Append("union all      ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID, WarehouseID    ");
            sQueryStringMaster.Append(",0 as QuantityCr , 0 as AmountCr, 0 as AdjustedDPAmountCr,0 as AdjustedTPAmountCr,0 as AdjustedPWAmountCr , 0 as VATCr , 0 as DiscountCr   ");
            sQueryStringMaster.Append(", sum(quantity) as QuantityDr, sum(unitPrice*Quantity) as AmountDr, sum(Quantity*isnull(AdjustedDPAmount,0)) as AdjustedDPAmountdr  ");
            sQueryStringMaster.Append(",sum(Quantity*isnull(AdjustedTPAmount,0)) as AdjustedTPAmountdr, sum(Quantity*isnull(AdjustedPWAmount,0)) as AdjustedPWAmountdr       ");
            sQueryStringMaster.Append(",sum(quantity*SID.TradePrice*VATAmount) as VATDr , sum(ProductDiscount*Quantity) as DiscountDr   ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID    ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ? and im.Invoicedate < ?      ");
            sQueryStringMaster.Append("and im.invoicetypeid in(?,?,?,?,?)  and invoicestatus not in (?)      ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID, WarehouseID    ");
            sQueryStringMaster.Append(")      ");
            sQueryStringMaster.Append("as qq group by Productid,CustomerID,WarehouseID    ");
            sQueryStringMaster.Append(")      ");
            sQueryStringMaster.Append("as qqq      ");
            sQueryStringMaster.Append("inner join (select warehouseID, WarehouseCode, WarehouseName from t_warehouse) w on w.warehouseId=qqq.warehouseId  ");
            sQueryStringMaster.Append("Inner join    ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select * from v_customerDetails   ");
            sQueryStringMaster.Append(")    ");
            sQueryStringMaster.Append("as qqq2 on qqq.customerid = qqq2.customerid     ");
            sQueryStringMaster.Append("Inner join    ");
            sQueryStringMaster.Append("(   ");         
            if (Utility.CompanyInfo == "TML")
                sQueryStringMaster.Append("select * from v_ProductDetails where itemcategory=1   ");
            else sQueryStringMaster.Append("select * from v_ProductDetails ");
            sQueryStringMaster.Append(")    ");
            sQueryStringMaster.Append("as qqq3 on qqq.Productid = qqq3.Productid     ");
            sQueryStringMaster.Append("group by    ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName      ");
            sQueryStringMaster.Append(",ChannelID, ChannelCode, ChannelDescription    ");
            sQueryStringMaster.Append(",CustomerTypeID, CustomerTypeCode, CustomerTypeName    ");
                     
              
            if (Utility.CompanyInfo == "TML")
                sQueryStringMaster.Append(",RegionName,AreaID,AreaCode, AreaName     ");
            else sQueryStringMaster.Append(",AreaID,AreaCode, AreaName     ");

            sQueryStringMaster.Append(",TerritoryID,TerritoryCode,TerritoryName   ");
            sQueryStringMaster.Append(",qqq.CustomerID,CustomerCode,CustomerName   ");
            sQueryStringMaster.Append(",PGID, PGCode, PGName      ");
            sQueryStringMaster.Append(",MAGID, MAGCode, MAGName      ");
            sQueryStringMaster.Append(",ASGID, ASGCode, ASGName       ");
            sQueryStringMaster.Append(",AGID,AGCode, AGName      ");
            sQueryStringMaster.Append(",qqq.ProductID,ProductCode,ProductName     ");
            sQueryStringMaster.Append(",BrandID, BrandCode, BrandDesc    ");
            sQueryStringMaster.Append(",w.WarehouseID, WarehouseCode, WarehouseName   ");


            
            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();


            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate",  dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate",  dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate",  dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
            
            GetDataProductSalesQtyCustomerwise(oCmd); 
            
        }
        public void GetDataProductSalesQtyCustomerwise(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductSalesQtyandValueCustomerWise oItem = new ProductSalesQtyandValueCustomerWise();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = (long)reader["SBUID"];
                    else oItem.SBUID = 0;                
                   
                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)reader["SBUCode"];
                    else oItem.SBUCode = "";

                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";

                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = (int)reader["ChannelID"];
                    else oItem.ChannelID = -1;

                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";

                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";

                    if (reader["AreaID"] != DBNull.Value)
                        oItem.AreaID = (int)reader["AreaID"];
                    else oItem.AreaID = -1;

                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)reader["AreaCode"];
                    else oItem.AreaCode = "";

                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";

                    if (reader["TerritoryID"] != DBNull.Value)
                        oItem.TerritoryID = (int)reader["TerritoryID"];
                    else oItem.TerritoryID = -1;

                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = (string)reader["TerritoryCode"];
                    else oItem.TerritoryCode = "";

                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";

                    if (reader["CustomerTypeID"] != DBNull.Value)
                        oItem.CustomerTypeID = (int)reader["CustomerTypeID"];
                    else oItem.CustomerTypeID = -1;

                    if (reader["CustomerTypeCode"] != DBNull.Value)
                        oItem.CustomerTypeCode = (string)reader["CustomerTypeCode"];
                    else oItem.CustomerTypeCode = "";

                    if (reader["CustomerTypeName"] != DBNull.Value)
                        oItem.CustomerTypeName = (string)reader["CustomerTypeName"];
                    else oItem.CustomerTypeName = "";

                    if (reader["CustomerID"] != DBNull.Value)
                        oItem.CustomerID = (int)reader["CustomerID"];
                    else oItem.CustomerID = -1;

                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";

                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";

                    
                    if (reader["PGID"] != DBNull.Value)
                        oItem.PGID = (int)reader["PGID"];
                    else oItem.PGID = -1;

                    if (reader["PGCode"] != DBNull.Value)
                        oItem.PGCode = (string)reader["PGCode"];
                    else oItem.PGCode = "";

                    if (reader["PGName"] != DBNull.Value)
                        oItem.PGName = (string)reader["PGName"];
                    else oItem.PGName = "";

                    if (reader["MAGID"] != DBNull.Value)
                        oItem.MAGID = (int)reader["MAGID"];
                    else oItem.MAGID = -1;

                    if (reader["MAGCode"] != DBNull.Value)
                        oItem.MAGCode = (string)reader["MAGCode"];
                    else oItem.MAGCode = "";

                    if (reader["MAGName"] != DBNull.Value)
                        oItem.MAGName = (string)reader["MAGName"];
                    else oItem.MAGName = "";

                    if (reader["ASGID"] != DBNull.Value)
                        oItem.ASGID = (int)reader["ASGID"];
                    else oItem.ASGID = -1;

                    if (reader["ASGCode"] != DBNull.Value)
                        oItem.ASGCode = (string)reader["ASGCode"];
                    else oItem.ASGCode = "";

                    if (reader["ASGName"] != DBNull.Value)
                        oItem.ASGName = (string)reader["ASGName"];
                    else oItem.ASGName = "";

                    if (reader["AGID"] != DBNull.Value)
                        oItem.AGID = (int)reader["AGID"];
                    else oItem.AGID = -1;

                    if (reader["AGCode"] != DBNull.Value)
                        oItem.AGCode = (string)reader["AGCode"];
                    else oItem.AGCode = "";

                    if (reader["AGName"] != DBNull.Value)
                        oItem.AGName = (string)reader["AGName"];
                    else oItem.AGName = "";
                    
                    if (reader["BrandID"] != DBNull.Value)
                        oItem.BrandID = (int)reader["BrandID"];
                    else oItem.BrandID = -1;

                    if (reader["BrandCode"] != DBNull.Value)
                        oItem.BrandCode = (string)reader["BrandCode"];
                    else oItem.BrandCode = "";

                    if (reader["BrandName"] != DBNull.Value)
                        oItem.BrandName = (string)reader["BrandName"];
                    else oItem.BrandName = "";

                    if (reader["WarehouseID"] != DBNull.Value)
                        oItem.WarehouseID = (int)reader["WarehouseID"];
                    else oItem.WarehouseID = -1;
                    if (reader["WarehouseCode"] != DBNull.Value)
                        oItem.WarehouseCode = (string)reader["WarehouseCode"];
                    else oItem.WarehouseCode = "";
                    if (reader["WarehouseName"] != DBNull.Value)
                        oItem.WarehouseName = (string)reader["WarehouseName"];
                    else oItem.WarehouseName = "";

                    if (reader["ProductID"] != DBNull.Value)
                        oItem.ProductID = (int)reader["ProductID"];
                    else oItem.ProductID = -1;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";                    

                    if (reader["SalesQty"] != DBNull.Value)
                        oItem.SalesQty = Convert.ToInt64 (reader["SalesQty"]);
                    else oItem.SalesQty = -1;

                    if (reader["SalesAmt"] != DBNull.Value)
                        oItem.SalesAmt = (double)reader["SalesAmt"];
                    else oItem.SalesAmt = -1;

                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                        oItem.AdjustedDPAmount = (double)reader["AdjustedDPAmount"];
                    else oItem.AdjustedDPAmount = -1;
                    
                    if (reader["AdjustedTPAmount"] != DBNull.Value)
                        oItem.AdjustedTPAmount = (double)reader["AdjustedTPAmount"];
                    else oItem.AdjustedTPAmount = -1;

                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                        oItem.AdjustedPWAmount = (double)reader["AdjustedPWAmount"];
                    else oItem.AdjustedPWAmount = -1;
                    
                    if (reader["VAT"] != DBNull.Value)
                        oItem.VAT = (double)reader["VAT"];
                    else oItem.VAT = -1;

                    if (reader["ProductDiscount"] != DBNull.Value)
                        oItem.ProductDiscount = (double)reader["ProductDiscount"];
                    else oItem.ProductDiscount = -1;

                    try
                    {
                        oItem.ProductCodeInNumber = Convert.ToInt64((string)reader["ProductCode"]);
                    }
                    catch
                    {
                        oItem.ProductCodeInNumber = 1;
                    }

                    if (Utility.CompanyInfo == "TML")
                        oItem.Region = (string)reader["RegionName"];
                    else oItem.Region = "";
                                     
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
        public void FromDataSetProductSalesQtyCustomerwise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    ProductSalesQtyandValueCustomerWise oProductSalesQtyandValueCustomerWise = new ProductSalesQtyandValueCustomerWise();

                    oProductSalesQtyandValueCustomerWise.SBUID = Convert.ToInt32(oRow["SBUID"]);
                    oProductSalesQtyandValueCustomerWise.SBUCode = (string)oRow["SBUCode"];
                    oProductSalesQtyandValueCustomerWise.SBUName = (string)oRow["SBUName"];
                    oProductSalesQtyandValueCustomerWise.ChannelID = Convert.ToInt32(oRow["ChannelID"]);
                    oProductSalesQtyandValueCustomerWise.ChannelCode = (string)oRow["ChannelCode"];
                    oProductSalesQtyandValueCustomerWise.ChannelName = (string)oRow["ChannelName"];
                    oProductSalesQtyandValueCustomerWise.AreaID = Convert.ToInt32(oRow["AreaID"]);
                    oProductSalesQtyandValueCustomerWise.AreaCode = (string)oRow["AreaCode"];
                    oProductSalesQtyandValueCustomerWise.AreaName = (string)oRow["AreaName"];
                    oProductSalesQtyandValueCustomerWise.TerritoryID = Convert.ToInt32(oRow["TerritoryID"]);
                    oProductSalesQtyandValueCustomerWise.TerritoryCode = (string)oRow["TerritoryCode"];  
                    oProductSalesQtyandValueCustomerWise.TerritoryName = (string)oRow["TerritoryName"];
                    oProductSalesQtyandValueCustomerWise.CustomerTypeID = Convert.ToInt32(oRow["CustomerTypeID"]);
                    oProductSalesQtyandValueCustomerWise.CustomerTypeCode = (string)oRow["CustomerTypeCode"];
                    oProductSalesQtyandValueCustomerWise.CustomerTypeName = (string)oRow["CustomerTypeName"];

                    oProductSalesQtyandValueCustomerWise.CustomerID = Convert.ToInt32(oRow["CustomerID"]);
                    oProductSalesQtyandValueCustomerWise.CustomerCode = (string)oRow["CustomerCode"];
                    oProductSalesQtyandValueCustomerWise.CustomerName = (string)oRow["CustomerName"];

                    oProductSalesQtyandValueCustomerWise.ProductID = Convert.ToInt32(oRow["ProductID"]);
                    oProductSalesQtyandValueCustomerWise.ProductCode = (string)oRow["ProductCode"];
                    oProductSalesQtyandValueCustomerWise.ProductName = (string)oRow["ProductName"];                    

                    oProductSalesQtyandValueCustomerWise.PGID = Convert.ToInt32(oRow["PGID"]);
                    oProductSalesQtyandValueCustomerWise.PGCode = (string)oRow["PGCode"];
                    oProductSalesQtyandValueCustomerWise.PGName = (string)oRow["PGName"];
                    oProductSalesQtyandValueCustomerWise.MAGID = Convert.ToInt32(oRow["MAGID"]);
                    oProductSalesQtyandValueCustomerWise.MAGCode = (string)oRow["MAGCode"];
                    oProductSalesQtyandValueCustomerWise.MAGName = (string)oRow["MAGName"];
                    oProductSalesQtyandValueCustomerWise.ASGID = Convert.ToInt32(oRow["ASGID"]);
                    oProductSalesQtyandValueCustomerWise.ASGCode = (string)oRow["ASGCode"];
                    oProductSalesQtyandValueCustomerWise.ASGName = (string)oRow["ASGName"];
                    oProductSalesQtyandValueCustomerWise.AGID = Convert.ToInt32(oRow["AGID"]);
                    oProductSalesQtyandValueCustomerWise.AGCode = (string)oRow["AGCode"];
                    oProductSalesQtyandValueCustomerWise.AGName = (string)oRow["AGName"];
                    oProductSalesQtyandValueCustomerWise.BrandID = Convert.ToInt32(oRow["BrandID"]);
                    oProductSalesQtyandValueCustomerWise.BrandCode = (string)oRow["BrandCode"];
                    oProductSalesQtyandValueCustomerWise.BrandName = (string)oRow["BrandName"];
                    //oProductSalesQtyandValueCustomerWise.WarehouseID = Convert.ToInt32(oRow["WarehouseID"]);
                    //oProductSalesQtyandValueCustomerWise.WarehouseCode = (string)oRow["WarehouseCode"];
                    //oProductSalesQtyandValueCustomerWise.WarehouseName = (string)oRow["WarehouseName"]; 

                    
                    oProductSalesQtyandValueCustomerWise.SalesQty = Convert.ToInt32(oRow["SalesQty"]);
                    oProductSalesQtyandValueCustomerWise.SalesAmt = Convert.ToInt32(oRow["SalesAmt"]);
                    oProductSalesQtyandValueCustomerWise.AdjustedDPAmount = Convert.ToInt32(oRow["AdjustedDPAmount"]);
                    oProductSalesQtyandValueCustomerWise.AdjustedTPAmount = Convert.ToInt32(oRow["AdjustedTPAmount"]);
                    oProductSalesQtyandValueCustomerWise.AdjustedPWAmount = Convert.ToInt32(oRow["AdjustedPWAmount"]);
                    oProductSalesQtyandValueCustomerWise.VAT = Convert.ToInt32(oRow["VAT"]);
                    oProductSalesQtyandValueCustomerWise.ProductDiscount = Convert.ToInt32(oRow["ProductDiscount"]);
                    oProductSalesQtyandValueCustomerWise.ProductCodeInNumber = Convert.ToInt32(oRow["ProductCode"]);
                    if (Utility.CompanyInfo == "TEL")
                        oProductSalesQtyandValueCustomerWise.Region = "";
                    if (Utility.CompanyInfo == "TML")
                        oProductSalesQtyandValueCustomerWise.Region = oRow["Region"].ToString();

                    InnerList.Add(oProductSalesQtyandValueCustomerWise);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ProductSalesQtyTerritorywise(DateTime dYFromDate, DateTime dYToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Query for report [62]  

           sQueryStringMaster.Append(" select SBUID,SBUName, ChannelID, ChannelDescription as ChannelName, AreaID,AreaName,TerritoryID,TerritoryName,PGID,PGName, MAGID, MAGName, ASGID, ASGName   ");    
           sQueryStringMaster.Append(" ,AGID, AGName, qqq.ProductID,ProductCode,ProductName  ");   
           sQueryStringMaster.Append(" ,BrandID, BrandDesc as BrandName   ");
           sQueryStringMaster.Append(" ,sum(isnull(SalesQTY,0)) as SalesQty,sum(isnull(SalesAmount,0)) as SalesAmt  ");
           sQueryStringMaster.Append(" ,sum(isnull(AdjustedDPAmount,0)) as AdjustedDPAmount,sum(isnull(AdjustedTPAmount,0)) as AdjustedTPAmount,sum(isnull(AdjustedPWAmount,0)) as AdjustedPWAmount    ");
           sQueryStringMaster.Append(" ,sum(isnull(qqq.VAT,0)) as VAT,sum(isnull(qqq.Discount,0)) as ProductDiscount   ");     
           sQueryStringMaster.Append("  from  ");   
           sQueryStringMaster.Append(" (  ");     
           sQueryStringMaster.Append(" select Productid,CustomerID    ");
           sQueryStringMaster.Append(" ,isnull(sum(QuantityCr)-abs(sum(QuantityDr)),0) as SalesQty, isnull(sum(AmountCr)-abs(sum(AmountDr)),0) as SalesAmount   ");
           sQueryStringMaster.Append(" ,isnull(sum(AdjustedDPAmountCr)-abs(sum(AdjustedDPAmountdr)),0) as AdjustedDPAmount, isnull(sum(AdjustedTPAmountCr)-abs(sum(AdjustedTPAmountdr)),0) as AdjustedTPAmount   ");
           sQueryStringMaster.Append(" , isnull(sum(AdjustedPWAmountCr)-abs(sum(AdjustedPWAmountdr)),0) as AdjustedPWAmount  ");  
           sQueryStringMaster.Append(" ,isnull(sum(VATCr)-abs(sum(VATDr)),0) as VAT, isnull(sum(DiscountCr)-abs(sum(DiscountDr)),0) as Discount     ");
           sQueryStringMaster.Append(" from ");  
           sQueryStringMaster.Append(" (  ");    
           sQueryStringMaster.Append(" select SID.Productid,IM.CustomerID    ");
           sQueryStringMaster.Append(" ,sum(quantity) as QuantityCr , sum(unitPrice*Quantity) as AmountCr, sum(Quantity*isnull(AdjustedDPAmount,0)) as AdjustedDPAmountCr  ");
           sQueryStringMaster.Append(" ,sum(Quantity*isnull(AdjustedTPAmount,0)) as AdjustedTPAmountCr, sum(Quantity*isnull(AdjustedPWAmount,0)) as AdjustedPWAmountCr   "); 
           sQueryStringMaster.Append(" ,sum(quantity*SID.TradePrice*VATAmount) as VATCr , sum(ProductDiscount*Quantity) as DiscountCr  ");
           sQueryStringMaster.Append(" , 0 as QuantityDr, 0 as AmountDr, 0 as AdjustedDPAmountdr,0 as AdjustedTPAmountdr,0 as AdjustedPWAmountdr   ");
           sQueryStringMaster.Append(" , 0 as VATDr, 0 as DiscountDr    ");     
           sQueryStringMaster.Append(" from t_salesinvoice IM, t_salesInvoiceDetail SID    ");
           sQueryStringMaster.Append(" where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between  ?  and ?  and im.Invoicedate < ?     ");
           sQueryStringMaster.Append(" and im.invoicetypeid in(1,2,4,5)  and invoicestatus not in (3)   ");   
           sQueryStringMaster.Append(" group by SID.Productid,IM.CustomerID    ");
           sQueryStringMaster.Append(" union all  ");    
           sQueryStringMaster.Append(" select SID.Productid,IM.CustomerID  ");  
           sQueryStringMaster.Append(" ,0 as QuantityCr , 0 as AmountCr, 0 as AdjustedDPAmountCr,0 as AdjustedTPAmountCr,0 as AdjustedPWAmountCr , 0 as VATCr , 0 as DiscountCr ");  
           sQueryStringMaster.Append(" , sum(quantity) as QuantityDr, sum(unitPrice*Quantity) as AmountDr, sum(Quantity*isnull(AdjustedDPAmount,0)) as AdjustedDPAmountdr  ");
           sQueryStringMaster.Append(" ,sum(Quantity*isnull(AdjustedTPAmount,0)) as AdjustedTPAmountdr, sum(Quantity*isnull(AdjustedPWAmount,0)) as AdjustedPWAmountdr  ");     
           sQueryStringMaster.Append(" ,sum(quantity*SID.TradePrice*VATAmount) as VATDr , sum(ProductDiscount*Quantity) as DiscountDr ");  
           sQueryStringMaster.Append(" from t_salesinvoice IM, t_salesInvoiceDetail SID    ");
           sQueryStringMaster.Append(" where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between  ? and  ?  and im.Invoicedate < ?    ");
           sQueryStringMaster.Append(" and im.invoicetypeid in(6,7,9,10,12)  and invoicestatus not in (3)   ");   
           sQueryStringMaster.Append(" group by SID.Productid,IM.CustomerID  ");  
           sQueryStringMaster.Append(" )   ");   
           sQueryStringMaster.Append(" as qq group by Productid,CustomerID    ");
           sQueryStringMaster.Append(" )   ");   
           sQueryStringMaster.Append(" as qqq  ");     
           sQueryStringMaster.Append(" Inner join ");   
           sQueryStringMaster.Append(" (   ");
           sQueryStringMaster.Append(" select * from v_customerDetails   ");
           sQueryStringMaster.Append(" )    ");
           sQueryStringMaster.Append(" as qqq2 on qqq.customerid = qqq2.customerid     ");
           sQueryStringMaster.Append(" Inner join   "); 
           sQueryStringMaster.Append(" (   ");
           sQueryStringMaster.Append(" select * from v_ProductDetails   ");
           sQueryStringMaster.Append(" )    ");
           sQueryStringMaster.Append(" as qqq3 on qqq.Productid = qqq3.Productid     ");
           sQueryStringMaster.Append(" group by  SBUID,SBUCode,SBUName, ChannelID, ChannelCode, ChannelDescription, AreaID, AreaCode, AreaName, TerritoryID,TerritoryCode,TerritoryName,   ");
           sQueryStringMaster.Append(" PGID, PGCode, PGName, MAGID, MAGCode, MAGName, ASGID, ASGCode, ASGName, AGID,AGCode, AGName, qqq.ProductID,ProductCode,ProductName     ");
           sQueryStringMaster.Append(" ,BrandID, BrandCode, BrandDesc    ");

                
            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYFromDate);
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate.AddDays(1));


            oCmd.Parameters.AddWithValue("im.Invoicedate", dYFromDate);
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate.AddDays(1));
            GetDataProductSalesQtyTerritorywise(oCmd);

        }
        public void GetDataProductSalesQtyTerritorywise(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductSalesQtyandValueCustomerWise oItem = new ProductSalesQtyandValueCustomerWise();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = (long)reader["SBUID"];
                    else oItem.SBUID = -1;
                    
                    oItem.SBUCode = "";
                   
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";

                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = (int)reader["ChannelID"];
                    else oItem.ChannelID = -1;

                    oItem.ChannelCode = "";

                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";

                    if (reader["AreaID"] != DBNull.Value)
                        oItem.AreaID = (int)reader["AreaID"];
                    else oItem.AreaID = -1;

                    oItem.AreaCode = "";

                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";

                    if (reader["TerritoryID"] != DBNull.Value)
                        oItem.TerritoryID = (int)reader["TerritoryID"];
                    else oItem.TerritoryID = -1;
                    
                    oItem.TerritoryCode = "";
                    
                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";

                    oItem.CustomerTypeID = 0;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";

                    oItem.CustomerID = 0;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";


                    if (reader["PGID"] != DBNull.Value)
                        oItem.PGID = (int)reader["PGID"];
                    else oItem.PGID = -1;

                    oItem.PGCode = "";

                    if (reader["PGName"] != DBNull.Value)
                        oItem.PGName = (string)reader["PGName"];
                    else oItem.PGName = "";

                    if (reader["MAGID"] != DBNull.Value)
                        oItem.MAGID = (int)reader["MAGID"];
                    else oItem.MAGID = -1;

                    oItem.MAGCode = "";

                    if (reader["MAGName"] != DBNull.Value)
                        oItem.MAGName = (string)reader["MAGName"];
                    else oItem.MAGName = "";

                    if (reader["ASGID"] != DBNull.Value)
                        oItem.ASGID = (int)reader["ASGID"];
                    else oItem.ASGID = -1;

                    oItem.ASGCode = "";

                    if (reader["ASGName"] != DBNull.Value)
                        oItem.ASGName = (string)reader["ASGName"];
                    else oItem.ASGName = "";

                    if (reader["AGID"] != DBNull.Value)
                        oItem.AGID = (int)reader["AGID"];
                    else oItem.AGID = -1;

                    oItem.AGCode = "";

                    if (reader["AGName"] != DBNull.Value)
                        oItem.AGName = (string)reader["AGName"];
                    else oItem.AGName = "";

                    if (reader["BrandID"] != DBNull.Value)
                        oItem.BrandID = (int)reader["BrandID"];
                    else oItem.BrandID = -1;

                    oItem.BrandCode = "";

                    if (reader["BrandName"] != DBNull.Value)
                        oItem.BrandName = (string)reader["BrandName"];
                    else oItem.BrandName = "";
                                                   
                    
                    if (reader["ProductID"] != DBNull.Value)
                        oItem.ProductID = (int)reader["ProductID"];
                    else oItem.ProductID = -1;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    
                    
                    if (reader["SalesQty"] != DBNull.Value)
                        oItem.SalesQty = Convert.ToInt64(reader["SalesQty"]);
                    else oItem.SalesQty = -1;

                    if (reader["SalesAmt"] != DBNull.Value)
                        oItem.SalesAmt = (double)reader["SalesAmt"];
                    else oItem.SalesAmt = -1;

                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                        oItem.AdjustedDPAmount = (double)reader["AdjustedDPAmount"];
                    else oItem.AdjustedDPAmount = -1;

                    if (reader["AdjustedTPAmount"] != DBNull.Value)
                        oItem.AdjustedTPAmount = (double)reader["AdjustedTPAmount"];
                    else oItem.AdjustedTPAmount = -1;

                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                        oItem.AdjustedPWAmount = (double)reader["AdjustedPWAmount"];
                    else oItem.AdjustedPWAmount = -1;

                    if (reader["VAT"] != DBNull.Value)
                        oItem.VAT = (double)reader["VAT"];
                    else oItem.VAT = -1;

                    if (reader["ProductDiscount"] != DBNull.Value)
                        oItem.ProductDiscount = (double)reader["ProductDiscount"];
                    else oItem.ProductDiscount = -1;

                    oItem.Region = "";

                    try
                    {
                        oItem.ProductCodeInNumber = Convert.ToInt64((string)reader["ProductCode"]);
                    }
                    catch
                    {
                        oItem.ProductCodeInNumber = 1;
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
        public void FromDataSetProductSalesQtyTerritorywise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    ProductSalesQtyandValueCustomerWise oProductSalesQtyandValueCustomerWise = new ProductSalesQtyandValueCustomerWise();

                    oProductSalesQtyandValueCustomerWise.SBUID = Convert.ToInt32(oRow["SBUID"]);
                    oProductSalesQtyandValueCustomerWise.SBUCode = (string)oRow["SBUCode"];
                    oProductSalesQtyandValueCustomerWise.SBUName = (string)oRow["SBUName"];

                    oProductSalesQtyandValueCustomerWise.ChannelID = Convert.ToInt32(oRow["ChannelID"]);
                    oProductSalesQtyandValueCustomerWise.ChannelCode = (string)oRow["ChannelCode"];
                    oProductSalesQtyandValueCustomerWise.ChannelName = (string)oRow["ChannelName"];

                    oProductSalesQtyandValueCustomerWise.AreaID = Convert.ToInt32(oRow["AreaID"]);
                    oProductSalesQtyandValueCustomerWise.AreaCode = (string)oRow["AreaCode"];
                    oProductSalesQtyandValueCustomerWise.AreaName = (string)oRow["AreaName"];

                    oProductSalesQtyandValueCustomerWise.TerritoryID = Convert.ToInt32(oRow["TerritoryID"]);
                    oProductSalesQtyandValueCustomerWise.TerritoryCode = (string)oRow["TerritoryCode"];
                    oProductSalesQtyandValueCustomerWise.TerritoryName = (string)oRow["TerritoryName"];
                    
                    oProductSalesQtyandValueCustomerWise.PGID = Convert.ToInt32(oRow["PGID"]);
                    oProductSalesQtyandValueCustomerWise.PGCode = (string)oRow["PGCode"];
                    oProductSalesQtyandValueCustomerWise.PGName = (string)oRow["PGName"];

                    oProductSalesQtyandValueCustomerWise.MAGID = Convert.ToInt32(oRow["MAGID"]);
                    oProductSalesQtyandValueCustomerWise.MAGCode = (string)oRow["MAGCode"];
                    oProductSalesQtyandValueCustomerWise.MAGName = (string)oRow["MAGName"];

                    oProductSalesQtyandValueCustomerWise.ASGID = Convert.ToInt32(oRow["ASGID"]);
                    oProductSalesQtyandValueCustomerWise.ASGCode = (string)oRow["ASGCode"];
                    oProductSalesQtyandValueCustomerWise.ASGName = (string)oRow["ASGName"];
                    
                    oProductSalesQtyandValueCustomerWise.AGID = Convert.ToInt32(oRow["AGID"]);
                    oProductSalesQtyandValueCustomerWise.AGCode = (string)oRow["AGCode"];
                    oProductSalesQtyandValueCustomerWise.AGName = (string)oRow["AGName"];

                    oProductSalesQtyandValueCustomerWise.BrandID = Convert.ToInt32(oRow["BrandID"]);
                    oProductSalesQtyandValueCustomerWise.BrandCode = (string)oRow["BrandCode"];
                    oProductSalesQtyandValueCustomerWise.BrandName = (string)oRow["BrandName"];

                    oProductSalesQtyandValueCustomerWise.ProductID = Convert.ToInt32(oRow["ProductID"]);
                    oProductSalesQtyandValueCustomerWise.ProductCode = (string)oRow["ProductCode"];
                    oProductSalesQtyandValueCustomerWise.ProductName = (string)oRow["ProductName"];

                    oProductSalesQtyandValueCustomerWise.CustomerID = -1;
                    oProductSalesQtyandValueCustomerWise.CustomerCode = "" ;
                    oProductSalesQtyandValueCustomerWise.CustomerName = "";

                    oProductSalesQtyandValueCustomerWise.CustomerTypeID = -1;
                    oProductSalesQtyandValueCustomerWise.CustomerTypeCode = "";
                    oProductSalesQtyandValueCustomerWise.CustomerTypeName = "";

                    oProductSalesQtyandValueCustomerWise.Region = "";

                    oProductSalesQtyandValueCustomerWise.SalesQty = Convert.ToInt32(oRow["SalesQty"]);
                    oProductSalesQtyandValueCustomerWise.SalesAmt = Convert.ToInt32(oRow["SalesAmt"]);
                    oProductSalesQtyandValueCustomerWise.AdjustedDPAmount = Convert.ToInt32(oRow["AdjustedDPAmount"]);
                    oProductSalesQtyandValueCustomerWise.AdjustedTPAmount = Convert.ToInt32(oRow["AdjustedTPAmount"]);
                    oProductSalesQtyandValueCustomerWise.AdjustedPWAmount = Convert.ToInt32(oRow["AdjustedPWAmount"]);
                    oProductSalesQtyandValueCustomerWise.VAT = Convert.ToInt32(oRow["VAT"]);
                    oProductSalesQtyandValueCustomerWise.ProductDiscount = Convert.ToInt32(oRow["ProductDiscount"]);
                    oProductSalesQtyandValueCustomerWise.ProductCodeInNumber = Convert.ToInt32(oRow["ProductCode"]);


                    InnerList.Add(oProductSalesQtyandValueCustomerWise);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ProductSalesQtyAreawise(DateTime dYFromDate, DateTime dYToDate)
            {
              dYToDate = dYToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Query for report [63] 
 
            	    
	           sQueryStringMaster.Append("  select SBUID,SBUName, ChannelID, ChannelDescription as ChannelName, AreaID,AreaName, PGID,PGName, MAGID, MAGName, ASGID, ASGName  ");     
               sQueryStringMaster.Append("  ,AGID, AGName, qqq.ProductID,ProductCode,ProductName  ");   
               sQueryStringMaster.Append("  ,BrandID, BrandDesc as BrandName  ");  
               sQueryStringMaster.Append("  ,sum(isnull(SalesQTY,0)) as SalesQty,sum(isnull(SalesAmount,0)) as SalesAmt "); 
               sQueryStringMaster.Append("  ,sum(isnull(AdjustedDPAmount,0)) as AdjustedDPAmount,sum(isnull(AdjustedTPAmount,0)) as AdjustedTPAmount,sum(isnull(AdjustedPWAmount,0)) as AdjustedPWAmount   ");      
               sQueryStringMaster.Append("  ,sum(isnull(qqq.VAT,0)) as VAT,sum(isnull(qqq.Discount,0)) as ProductDiscount   ");     
               sQueryStringMaster.Append("  from  ");   
               sQueryStringMaster.Append("  (   ");   
               sQueryStringMaster.Append("  select Productid,CustomerID  ");  
               sQueryStringMaster.Append("  ,isnull(sum(QuantityCr)-abs(sum(QuantityDr)),0) as SalesQty, isnull(sum(AmountCr)-abs(sum(AmountDr)),0) as SalesAmount   ");
               sQueryStringMaster.Append("  ,isnull(sum(AdjustedDPAmountCr)-abs(sum(AdjustedDPAmountdr)),0) as AdjustedDPAmount, isnull(sum(AdjustedTPAmountCr)-abs(sum(AdjustedTPAmountdr)),0) as AdjustedTPAmount  "); 
               sQueryStringMaster.Append("  , isnull(sum(AdjustedPWAmountCr)-abs(sum(AdjustedPWAmountdr)),0) as AdjustedPWAmount ");   
               sQueryStringMaster.Append("  ,isnull(sum(VATCr)-abs(sum(VATDr)),0) as VAT, isnull(sum(DiscountCr)-abs(sum(DiscountDr)),0) as Discount  ");   
               sQueryStringMaster.Append("  from  "); 
               sQueryStringMaster.Append("  (     "); 
               sQueryStringMaster.Append("  select SID.Productid,IM.CustomerID  ");  
               sQueryStringMaster.Append("  ,sum(quantity) as QuantityCr , sum(unitPrice*Quantity) as AmountCr, sum(Quantity*isnull(AdjustedDPAmount,0)) as AdjustedDPAmountCr  ");
               sQueryStringMaster.Append("  ,sum(Quantity*isnull(AdjustedTPAmount,0)) as AdjustedTPAmountCr, sum(Quantity*isnull(AdjustedPWAmount,0)) as AdjustedPWAmountCr    ");
               sQueryStringMaster.Append("  ,sum(quantity*SID.TradePrice*VATAmount) as VATCr , sum(ProductDiscount*Quantity) as DiscountCr  ");
               sQueryStringMaster.Append("  , 0 as QuantityDr, 0 as AmountDr, 0 as AdjustedDPAmountdr,0 as AdjustedTPAmountdr,0 as AdjustedPWAmountdr   ");
               sQueryStringMaster.Append("  , 0 as VATDr, 0 as DiscountDr     ");    
               sQueryStringMaster.Append("  from t_salesinvoice IM, t_salesInvoiceDetail SID    ");
               sQueryStringMaster.Append("  where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ? and im.Invoicedate < ?  ");   
               sQueryStringMaster.Append("  and im.invoicetypeid in(1,2,4,5)  and invoicestatus not in (3)  ");    
               sQueryStringMaster.Append("  group by SID.Productid,IM.CustomerID    ");
               sQueryStringMaster.Append("  union all   ");   
               sQueryStringMaster.Append("  select SID.Productid,IM.CustomerID    ");
               sQueryStringMaster.Append("  ,0 as QuantityCr , 0 as AmountCr, 0 as AdjustedDPAmountCr,0 as AdjustedTPAmountCr,0 as AdjustedPWAmountCr , 0 as VATCr , 0 as DiscountCr   ");
               sQueryStringMaster.Append("  , sum(quantity) as QuantityDr, sum(unitPrice*Quantity) as AmountDr, sum(Quantity*isnull(AdjustedDPAmount,0)) as AdjustedDPAmountdr   ");
               sQueryStringMaster.Append("  ,sum(Quantity*isnull(AdjustedTPAmount,0)) as AdjustedTPAmountdr, sum(Quantity*isnull(AdjustedPWAmount,0)) as AdjustedPWAmountdr   ");    
               sQueryStringMaster.Append("  ,sum(quantity*SID.TradePrice*VATAmount) as VATDr , sum(ProductDiscount*Quantity) as DiscountDr   ");
               sQueryStringMaster.Append("  from t_salesinvoice IM, t_salesInvoiceDetail SID  ");  
               sQueryStringMaster.Append("  where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between  ?  and ? and im.Invoicedate < ?  ");    
               sQueryStringMaster.Append("  and im.invoicetypeid in(6,7,9,10,12)  and invoicestatus not in (3)   ");   
               sQueryStringMaster.Append("  group by SID.Productid,IM.CustomerID  ");  
               sQueryStringMaster.Append("  )    ");  
               sQueryStringMaster.Append("  as qq group by Productid,CustomerID    ");
               sQueryStringMaster.Append("  )      ");
               sQueryStringMaster.Append("  as qqq    ");  
               sQueryStringMaster.Append("  Inner join   "); 
               sQueryStringMaster.Append("  (  "); 
               sQueryStringMaster.Append("  select * from v_customerDetails ");  
               sQueryStringMaster.Append("  )  ");  
               sQueryStringMaster.Append("  as qqq2 on qqq.customerid = qqq2.customerid   ");  
               sQueryStringMaster.Append("  Inner join  ");  
               sQueryStringMaster.Append("  (  "); 
               sQueryStringMaster.Append("  select * from v_ProductDetails  "); 
               sQueryStringMaster.Append("  )  ");  
               sQueryStringMaster.Append("  as qqq3 on qqq.Productid = qqq3.Productid  ");   
               sQueryStringMaster.Append("  group by  SBUID,SBUCode,SBUName, ChannelID, ChannelCode, ChannelDescription, AreaID, AreaCode, AreaName,  ");  
               sQueryStringMaster.Append("  PGID, PGCode, PGName, MAGID, MAGCode, MAGName, ASGID, ASGCode, ASGName, AGID,AGCode, AGName, qqq.ProductID,ProductCode,ProductName   ");
               sQueryStringMaster.Append("  ,BrandID, BrandDesc    ");
                 
            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYFromDate);
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate);
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate);


            oCmd.Parameters.AddWithValue("im.Invoicedate", dYFromDate);
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate);
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate);
            GetDataProductSalesQtyAreawise(oCmd);

        }
        public void GetDataProductSalesQtyAreawise(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductSalesQtyandValueCustomerWise oItem = new ProductSalesQtyandValueCustomerWise();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = (long)reader["SBUID"];
                    else oItem.SBUID = -1;

                    oItem.SBUCode = "";

                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = ""; 

                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = (int)reader["ChannelID"];
                    else oItem.ChannelID = -1;

                    oItem.ChannelCode = "";

                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";

                    if (reader["AreaID"] != DBNull.Value)
                        oItem.AreaID = (int)reader["AreaID"];
                    else oItem.AreaID = -1;

                    oItem.AreaCode = "";

                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";

                    oItem.TerritoryID = 0;
                    oItem.TerritoryCode = "";
                    oItem.TerritoryName = "";                    

                    oItem.CustomerTypeID = 0;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";

                    oItem.CustomerID = 0;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";


                    if (reader["PGID"] != DBNull.Value)
                        oItem.PGID = (int)reader["PGID"];
                    else oItem.PGID = -1;

                    oItem.PGCode = "";

                    if (reader["PGName"] != DBNull.Value)
                        oItem.PGName = (string)reader["PGName"];
                    else oItem.PGName = "";

                    if (reader["MAGID"] != DBNull.Value)
                        oItem.MAGID = (int)reader["MAGID"];
                    else oItem.MAGID = -1;

                    oItem.MAGCode = "";

                    if (reader["MAGName"] != DBNull.Value)
                        oItem.MAGName = (string)reader["MAGName"];
                    else oItem.MAGName = "";

                    if (reader["ASGID"] != DBNull.Value)
                        oItem.ASGID = (int)reader["ASGID"];
                    else oItem.ASGID = -1;

                    oItem.ASGCode = "";

                    if (reader["ASGName"] != DBNull.Value)
                        oItem.ASGName = (string)reader["ASGName"];
                    else oItem.ASGName = "";

                    if (reader["AGID"] != DBNull.Value)
                        oItem.AGID = (int)reader["AGID"];
                    else oItem.AGID = -1;

                    oItem.AGCode = "";

                    if (reader["AGName"] != DBNull.Value)
                        oItem.AGName = (string)reader["AGName"];
                    else oItem.AGName = "";

                    if (reader["BrandID"] != DBNull.Value)
                        oItem.BrandID = (int)reader["BrandID"];
                    else oItem.BrandID = -1;

                    oItem.BrandCode = "";

                    if (reader["BrandName"] != DBNull.Value)
                        oItem.BrandName = (string)reader["BrandName"];
                    else oItem.BrandName = "";

                    if (reader["ProductID"] != DBNull.Value)
                        oItem.ProductID = (int)reader["ProductID"];
                    else oItem.ProductID = -1;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";                                                   
                    
                    if (reader["SalesQty"] != DBNull.Value)
                        oItem.SalesQty = Convert.ToInt64(reader["SalesQty"]);
                    else oItem.SalesQty = -1;

                    if (reader["SalesAmt"] != DBNull.Value)
                        oItem.SalesAmt = (double)reader["SalesAmt"];
                    else oItem.SalesAmt = -1;

                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                        oItem.AdjustedDPAmount = (double)reader["AdjustedDPAmount"];
                    else oItem.AdjustedDPAmount = -1;

                    if (reader["AdjustedTPAmount"] != DBNull.Value)
                        oItem.AdjustedTPAmount = (double)reader["AdjustedTPAmount"];
                    else oItem.AdjustedTPAmount = -1;

                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                        oItem.AdjustedPWAmount = (double)reader["AdjustedPWAmount"];
                    else oItem.AdjustedPWAmount = -1;

                    if (reader["VAT"] != DBNull.Value)
                        oItem.VAT = (double)reader["VAT"];
                    else oItem.VAT = -1;

                    if (reader["ProductDiscount"] != DBNull.Value)
                        oItem.ProductDiscount = (double)reader["ProductDiscount"];
                    else oItem.ProductDiscount = -1;

                    oItem.Region = "";

                    try
                    {
                        oItem.ProductCodeInNumber = Convert.ToInt64((string)reader["ProductCode"]);
                    }
                    catch
                    {
                        oItem.ProductCodeInNumber = 1;
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
        public void FromDataSetProductSalesQtyAreawise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    ProductSalesQtyandValueCustomerWise oProductSalesQtyandValueCustomerWise = new ProductSalesQtyandValueCustomerWise();

                    oProductSalesQtyandValueCustomerWise.SBUID = Convert.ToInt32(oRow["SBUID"]);
                    oProductSalesQtyandValueCustomerWise.SBUCode = "";
                    oProductSalesQtyandValueCustomerWise.SBUName = (string)oRow["SBUName"];

                    oProductSalesQtyandValueCustomerWise.ChannelID = Convert.ToInt32(oRow["ChannelID"]);
                    oProductSalesQtyandValueCustomerWise.ChannelCode = "";
                    oProductSalesQtyandValueCustomerWise.ChannelName = (string)oRow["ChannelName"];

                    oProductSalesQtyandValueCustomerWise.AreaID = Convert.ToInt32(oRow["AreaID"]);
                    oProductSalesQtyandValueCustomerWise.AreaCode = "";
                    oProductSalesQtyandValueCustomerWise.AreaName = (string)oRow["AreaName"];

                    oProductSalesQtyandValueCustomerWise.TerritoryID = 0;
                    oProductSalesQtyandValueCustomerWise.TerritoryCode = "";
                    oProductSalesQtyandValueCustomerWise.TerritoryName = "";

                    oProductSalesQtyandValueCustomerWise.PGID = Convert.ToInt32(oRow["PGID"]);
                    oProductSalesQtyandValueCustomerWise.PGCode = "";
                    oProductSalesQtyandValueCustomerWise.PGName = (string)oRow["PGName"];

                    oProductSalesQtyandValueCustomerWise.MAGID = Convert.ToInt32(oRow["MAGID"]);
                    oProductSalesQtyandValueCustomerWise.MAGCode = "";
                    oProductSalesQtyandValueCustomerWise.MAGName = (string)oRow["MAGName"];

                    oProductSalesQtyandValueCustomerWise.ASGID = Convert.ToInt32(oRow["ASGID"]);
                    oProductSalesQtyandValueCustomerWise.ASGCode = "";
                    oProductSalesQtyandValueCustomerWise.ASGName = (string)oRow["ASGName"];

                    oProductSalesQtyandValueCustomerWise.AGID = Convert.ToInt32(oRow["AGID"]);
                    oProductSalesQtyandValueCustomerWise.AGCode = "";
                    oProductSalesQtyandValueCustomerWise.AGName = (string)oRow["AGName"];

                    oProductSalesQtyandValueCustomerWise.BrandID = Convert.ToInt32(oRow["BrandID"]);
                    oProductSalesQtyandValueCustomerWise.BrandCode = "";
                    oProductSalesQtyandValueCustomerWise.BrandName = (string)oRow["BrandName"];

                    oProductSalesQtyandValueCustomerWise.ProductID = Convert.ToInt32(oRow["ProductID"]);
                    oProductSalesQtyandValueCustomerWise.ProductCode = (string)oRow["ProductCode"];
                    oProductSalesQtyandValueCustomerWise.ProductName = (string)oRow["ProductName"];

                    oProductSalesQtyandValueCustomerWise.CustomerID = 0;
                    oProductSalesQtyandValueCustomerWise.CustomerCode = "";
                    oProductSalesQtyandValueCustomerWise.CustomerName = "";

                    oProductSalesQtyandValueCustomerWise.CustomerTypeID = 0;
                    oProductSalesQtyandValueCustomerWise.CustomerTypeCode = "";
                    oProductSalesQtyandValueCustomerWise.CustomerTypeName = "";

                    oProductSalesQtyandValueCustomerWise.Region = "";

                    oProductSalesQtyandValueCustomerWise.SalesQty = Convert.ToInt32(oRow["SalesQty"]);
                    oProductSalesQtyandValueCustomerWise.SalesAmt = Convert.ToInt32(oRow["SalesAmt"]);
                    oProductSalesQtyandValueCustomerWise.AdjustedDPAmount = Convert.ToInt32(oRow["AdjustedDPAmount"]);
                    oProductSalesQtyandValueCustomerWise.AdjustedTPAmount = Convert.ToInt32(oRow["AdjustedTPAmount"]);
                    oProductSalesQtyandValueCustomerWise.AdjustedPWAmount = Convert.ToInt32(oRow["AdjustedPWAmount"]);
                    oProductSalesQtyandValueCustomerWise.VAT = Convert.ToInt32(oRow["VAT"]);
                    oProductSalesQtyandValueCustomerWise.ProductDiscount = Convert.ToInt32(oRow["ProductDiscount"]);
                    oProductSalesQtyandValueCustomerWise.ProductCodeInNumber = Convert.ToInt32(oRow["ProductCode"]);
                    

                    InnerList.Add(oProductSalesQtyandValueCustomerWise);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ProductSalesQtyCustomerTypewise(DateTime dYFromDate, DateTime dYToDate)
        {
           
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Query for report [64] 

            sQueryStringMaster.Append("select   ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName    ");
            sQueryStringMaster.Append(",ChannelID, ChannelCode, ChannelDescription as ChannelName  ");
            sQueryStringMaster.Append(",CustomerTypeID,CustomerTypeCode,CustomerTypeName ");
            sQueryStringMaster.Append(",PGID, PGCode, PGName    ");
            sQueryStringMaster.Append(",MAGID, MAGCode, MAGName    ");
            sQueryStringMaster.Append(",ASGID, ASGCode, ASGName     ");
            sQueryStringMaster.Append(",AGID, AGCode, AGName    ");
            sQueryStringMaster.Append(",qqq.ProductID,ProductCode,ProductName   ");
            sQueryStringMaster.Append(",BrandID, BrandCode, BrandDesc as BrandName ");
            sQueryStringMaster.Append(",sum(isnull(SalesQTY,0)) as SalesQty,sum(isnull(SalesAmount,0)) as SalesAmt       ");
            sQueryStringMaster.Append(",sum(isnull(qqq.VAT,0)) as VAT,sum(isnull(qqq.Discount,0)) as ProductDiscount      ");
            sQueryStringMaster.Append("from  ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select Productid,CustomerID  ");
            sQueryStringMaster.Append(",isnull(sum(QuantityCr)-abs(sum(QuantityDr)),0) as SalesQty, isnull(sum(AmountCr)-abs(sum(AmountDr)),0) as SalesAmount    ");
            sQueryStringMaster.Append(",isnull(sum(VATCr)-abs(sum(VATDr)),0) as VAT, isnull(sum(DiscountCr)-abs(sum(DiscountDr)),0) as Discount   ");
            sQueryStringMaster.Append("from ");
            sQueryStringMaster.Append("(    ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID  ");
            sQueryStringMaster.Append(",sum(quantity) as QuantityCr , sum(unitPrice*Quantity) as AmountCr ");
            sQueryStringMaster.Append(",sum(quantity*SID.TradePrice*VATAmount) as VATCr , sum(ProductDiscount*Quantity) as DiscountCr     ");
            sQueryStringMaster.Append(", 0 as QuantityDr, 0 as AmountDr, 0 as VATDr, 0 as DiscountDr       ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID  ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ? and im.Invoicedate< ?   ");
            sQueryStringMaster.Append("and im.invoicetypeid in(?,?,?,?)  and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID  ");
            sQueryStringMaster.Append("union all    ");
            sQueryStringMaster.Append("select SID.Productid,IM.CustomerID  ");
            sQueryStringMaster.Append(",0 as QuantityCr , 0 as AmountCr, 0 as VATCr , 0 as DiscountCr ");
            sQueryStringMaster.Append(", sum(quantity) as QuantityDr, sum(unitPrice*Quantity) as AmountDr   ");
            sQueryStringMaster.Append(",sum(quantity*SID.TradePrice*VATAmount) as VATDr , sum(ProductDiscount*Quantity) as DiscountDr ");
            sQueryStringMaster.Append("from t_salesinvoice IM, t_salesInvoiceDetail SID  ");
            sQueryStringMaster.Append("where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ? and im.Invoicedate< ?    ");
            sQueryStringMaster.Append("and im.invoicetypeid in(?,?,?,?,?)  and invoicestatus not in (?)    ");
            sQueryStringMaster.Append("group by SID.Productid,IM.CustomerID  ");
            sQueryStringMaster.Append(")    ");
            sQueryStringMaster.Append("as qq group by Productid,CustomerID  ");
            sQueryStringMaster.Append(")    ");
            sQueryStringMaster.Append("as qqq    ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from v_customerDetails  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as qqq2 on qqq.customerid = qqq2.customerid   ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from v_ProductDetails ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as qqq3 on qqq.Productid = qqq3.Productid   ");
            sQueryStringMaster.Append("group by  ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName    ");
            sQueryStringMaster.Append(",ChannelID, ChannelCode, ChannelDescription  ");
            sQueryStringMaster.Append(",CustomerTypeID,CustomerTypeCode,CustomerTypeName ");
            sQueryStringMaster.Append(",PGID, PGCode, PGName    ");
            sQueryStringMaster.Append(",MAGID, MAGCode, MAGName    ");
            sQueryStringMaster.Append(",ASGID, ASGCode, ASGName     ");
            sQueryStringMaster.Append(",AGID,AGCode, AGName    ");
            sQueryStringMaster.Append(",qqq.ProductID,ProductCode,ProductName   ");
            sQueryStringMaster.Append(",BrandID, BrandCode, BrandDesc  ");
            
                      
 
                      
            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);

            GetDataProductSalesQtyCustomerTypewise(oCmd);

        }
        public void GetDataProductSalesQtyCustomerTypewise(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductSalesQtyandValueCustomerWise oItem = new ProductSalesQtyandValueCustomerWise();


                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = (long)reader["SBUID"];
                    else oItem.SBUID = 0;

                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)reader["SBUCode"];
                    else oItem.SBUCode = "";

                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";

                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = (int)reader["ChannelID"];
                    else oItem.ChannelID = -1;

                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";

                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";


                    oItem.AreaID = 0;

                    oItem.AreaCode = "";

                    oItem.AreaName = "";


                    oItem.TerritoryID = 0;

                    oItem.TerritoryCode = "";

                    oItem.TerritoryName = "";
                    

                    if (reader["CustomerTypeID"] != DBNull.Value)
                        oItem.CustomerTypeID = (int)reader["CustomerTypeID"];
                    else oItem.CustomerTypeID = -1;

                    if (reader["CustomerTypeCode"] != DBNull.Value)
                        oItem.CustomerTypeCode = (string)reader["CustomerTypeCode"];
                    else oItem.CustomerTypeCode = "";

                    if (reader["CustomerTypeName"] != DBNull.Value)
                        oItem.CustomerTypeName = (string)reader["CustomerTypeName"];
                    else oItem.CustomerTypeName = "";


                    oItem.CustomerID = 0;
                    oItem.CustomerCode = "";
                    oItem.CustomerName="";                

                    
                    if (reader["PGID"] != DBNull.Value)
                        oItem.PGID = (int)reader["PGID"];
                    else oItem.PGID = -1;

                    if (reader["PGCode"] != DBNull.Value)
                        oItem.PGCode = (string)reader["PGCode"];
                    else oItem.PGCode = "";

                    if (reader["PGName"] != DBNull.Value)
                        oItem.PGName = (string)reader["PGName"];
                    else oItem.PGName = "";

                    if (reader["MAGID"] != DBNull.Value)
                        oItem.MAGID = (int)reader["MAGID"];
                    else oItem.MAGID = -1;

                    if (reader["MAGCode"] != DBNull.Value)
                        oItem.MAGCode = (string)reader["MAGCode"];
                    else oItem.MAGCode = "";

                    if (reader["MAGName"] != DBNull.Value)
                        oItem.MAGName = (string)reader["MAGName"];
                    else oItem.MAGName = "";

                    if (reader["ASGID"] != DBNull.Value)
                        oItem.ASGID = (int)reader["ASGID"];
                    else oItem.ASGID = -1;

                    if (reader["ASGCode"] != DBNull.Value)
                        oItem.ASGCode = (string)reader["ASGCode"];
                    else oItem.ASGCode = "";

                    if (reader["ASGName"] != DBNull.Value)
                        oItem.ASGName = (string)reader["ASGName"];
                    else oItem.ASGName = "";

                    if (reader["AGID"] != DBNull.Value)
                        oItem.AGID = (int)reader["AGID"];
                    else oItem.AGID = -1;

                    if (reader["AGCode"] != DBNull.Value)
                        oItem.AGCode = (string)reader["AGCode"];
                    else oItem.AGCode = "";

                    if (reader["AGName"] != DBNull.Value)
                        oItem.AGName = (string)reader["AGName"];
                    else oItem.AGName = "";

                    if (reader["BrandID"] != DBNull.Value)
                        oItem.BrandID = (int)reader["BrandID"];
                    else oItem.BrandID = -1;

                    if (reader["BrandCode"] != DBNull.Value)
                        oItem.BrandCode = (string)reader["BrandCode"];
                    else oItem.BrandCode = "";

                    if (reader["BrandName"] != DBNull.Value)
                        oItem.BrandName = (string)reader["BrandName"];
                    else oItem.BrandName = "";

                    if (reader["ProductID"] != DBNull.Value)
                        oItem.ProductID = (int)reader["ProductID"];
                    else oItem.ProductID = -1;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    if (reader["SalesQty"] != DBNull.Value)
                        oItem.SalesQty = Convert.ToInt64(reader["SalesQty"]);
                    else oItem.SalesQty = -1;

                    if (reader["SalesAmt"] != DBNull.Value)
                        oItem.SalesAmt = (double)reader["SalesAmt"];
                    else oItem.SalesAmt = -1;


                    oItem.AdjustedDPAmount = 0;
                    oItem.AdjustedTPAmount = 0;                    
                    oItem.AdjustedPWAmount = 0;
                   

                    if (reader["VAT"] != DBNull.Value)
                        oItem.VAT = (double)reader["VAT"];
                    else oItem.VAT = -1;

                    if (reader["ProductDiscount"] != DBNull.Value)
                        oItem.ProductDiscount = (double)reader["ProductDiscount"];
                    else oItem.ProductDiscount = -1;

                    try
                    {
                        oItem.ProductCodeInNumber = Convert.ToInt64((string)reader["ProductCode"]);
                    }
                    catch
                    {
                        oItem.ProductCodeInNumber = 1;
                    }
                    if (Utility.CompanyInfo == "TEL")
                        oItem.Region = "";
                    if (Utility.CompanyInfo == "TML")
                        oItem.Region = (string)reader["RegionName"];
                                       
                    
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
        public void FromDataSetProductSalesQtyCustomerTypewise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    ProductSalesQtyandValueCustomerWise oProductSalesQtyandValueCustomerWise = new ProductSalesQtyandValueCustomerWise();

                    oProductSalesQtyandValueCustomerWise.SBUID = Convert.ToInt32(oRow["SBUID"]);
                    oProductSalesQtyandValueCustomerWise.SBUCode = (string)oRow["SBUCode"];
                    oProductSalesQtyandValueCustomerWise.SBUName = (string)oRow["SBUName"];

                    oProductSalesQtyandValueCustomerWise.ChannelID = Convert.ToInt32(oRow["ChannelID"]);
                    oProductSalesQtyandValueCustomerWise.ChannelCode = (string)oRow["ChannelCode"];
                    oProductSalesQtyandValueCustomerWise.ChannelName = (string)oRow["ChannelName"];

                    oProductSalesQtyandValueCustomerWise.CustomerTypeID = Convert.ToInt32(oRow["CustomerTypeID"]);
                    oProductSalesQtyandValueCustomerWise.CustomerTypeCode = (string)oRow["CustomerTypeCode"];
                    oProductSalesQtyandValueCustomerWise.CustomerTypeName = (string)oRow["CustomerTypeName"];

                    oProductSalesQtyandValueCustomerWise.AreaID = 0;
                    oProductSalesQtyandValueCustomerWise.AreaCode = "";
                    oProductSalesQtyandValueCustomerWise.AreaName = "";

                    oProductSalesQtyandValueCustomerWise.TerritoryID =0 ;
                    oProductSalesQtyandValueCustomerWise.TerritoryCode = "";
                    oProductSalesQtyandValueCustomerWise.TerritoryName = "";

                    oProductSalesQtyandValueCustomerWise.PGID = Convert.ToInt32(oRow["PGID"]);
                    oProductSalesQtyandValueCustomerWise.PGCode = (string)oRow["PGCode"];
                    oProductSalesQtyandValueCustomerWise.PGName = (string)oRow["PGName"];

                    oProductSalesQtyandValueCustomerWise.MAGID = Convert.ToInt32(oRow["MAGID"]);
                    oProductSalesQtyandValueCustomerWise.MAGCode = (string)oRow["MAGCode"];
                    oProductSalesQtyandValueCustomerWise.MAGName = (string)oRow["MAGName"];

                    oProductSalesQtyandValueCustomerWise.ASGID = Convert.ToInt32(oRow["ASGID"]);
                    oProductSalesQtyandValueCustomerWise.ASGCode = (string)oRow["ASGCode"];
                    oProductSalesQtyandValueCustomerWise.ASGName = (string)oRow["ASGName"];

                    oProductSalesQtyandValueCustomerWise.AGID = Convert.ToInt32(oRow["AGID"]);
                    oProductSalesQtyandValueCustomerWise.AGCode = (string)oRow["AGCode"];
                    oProductSalesQtyandValueCustomerWise.AGName = (string)oRow["AGName"];

                    oProductSalesQtyandValueCustomerWise.BrandID = Convert.ToInt32(oRow["BrandID"]);
                    oProductSalesQtyandValueCustomerWise.BrandCode = (string)oRow["BrandCode"];
                    oProductSalesQtyandValueCustomerWise.BrandName = (string)oRow["BrandName"];

                    oProductSalesQtyandValueCustomerWise.ProductID = Convert.ToInt32(oRow["ProductID"]);
                    oProductSalesQtyandValueCustomerWise.ProductCode = (string)oRow["ProductCode"];
                    oProductSalesQtyandValueCustomerWise.ProductName = (string)oRow["ProductName"];

                    oProductSalesQtyandValueCustomerWise.CustomerID = 0;
                    oProductSalesQtyandValueCustomerWise.CustomerCode = "";
                    oProductSalesQtyandValueCustomerWise.CustomerName = "";                

                    oProductSalesQtyandValueCustomerWise.Region = "";

                    oProductSalesQtyandValueCustomerWise.SalesQty = Convert.ToInt32(oRow["SalesQty"]);
                    oProductSalesQtyandValueCustomerWise.SalesAmt = Convert.ToInt32(oRow["SalesAmt"]);
                    oProductSalesQtyandValueCustomerWise.AdjustedDPAmount = 0;
                    oProductSalesQtyandValueCustomerWise.AdjustedTPAmount = 0;
                    oProductSalesQtyandValueCustomerWise.AdjustedPWAmount = 0;
                    oProductSalesQtyandValueCustomerWise.VAT = Convert.ToInt32(oRow["VAT"]);
                    oProductSalesQtyandValueCustomerWise.ProductDiscount = Convert.ToInt32(oRow["ProductDiscount"]);
                    oProductSalesQtyandValueCustomerWise.ProductCodeInNumber = Convert.ToInt32(oRow["ProductCode"]);
                                        
                    InnerList.Add(oProductSalesQtyandValueCustomerWise);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void ProductWiseSalesQtyNVale(DateTime dYFromDate, DateTime dYToDate)
        {
            dYToDate = dYToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();


        }
    
    }
   
}

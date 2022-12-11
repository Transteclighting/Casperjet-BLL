// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Sept 24, 2011
// Time" :  03:00 PM
// Descriptio: Product Sales Qty and Value Country Summary [65]
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
    public class ProductSalesQtyandValueCountrySummary
    {
     
        private long _PGID;
        private string _sPGName;
        private long _MAGID;
        private string _sMAGName;
        private long _ASGID;
        private string _sASGName;
        private long _AGID;
        private string _sAGName;
        private long _BrandID;
        private string _sBrandName;
        private int _nProductID;
        private int _nProductCode;
        private string _sProductName;
        private long _nSalesQty;
        private double _SalesAmt;
        private double _AdjustedDPAmount;
        private double _AdjustedTPAmount;
        private double _AdjustedPWAmount;
        private double _VAT;
        private double _ProductDiscount;

        
        public long PGID
        {
            get { return _PGID; }
            set { _PGID = value; }
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
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }
                  
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public int ProductCode
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

        public double GrossAmount { get; set; }
    }

        public class ProductSalesQtyandValueCountrySummaryDetails : CollectionBaseCustom
        {
             public void Add(ProductSalesQtyandValueCountrySummary oProductSalesQtyandValueCountrySummary)
              {
                  this.List.Add(oProductSalesQtyandValueCountrySummary);
              }
        public ProductSalesQtyandValueCountrySummary this[Int32 Index]
        {
            get
            {
                return (ProductSalesQtyandValueCountrySummary)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(ProductSalesQtyandValueCountrySummary))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }


        public void ProductSalesQtyCountrySummary(DateTime dYFromDate, DateTime dYToDate,string sProductName, string sProductCode,int nPgid,int nMagID,int nAsgID,int nAgID,int nBrandID)
        {
            dYToDate = dYToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            //sSql = " select PGID,PGName, MAGID, MAGName, ASGID, ASGName, AGID, AGName, qqq.ProductID, "
            //+ " ProductCode,ProductName, BrandID, BrandDesc as BrandName, sum(isnull(SalesQTY,0)) as SalesQty,sum(isnull(SalesAmount,0)) as SalesAmt "
            //+ " ,sum(isnull(AdjustedDPAmount,0)) as AdjustedDPAmount,sum(isnull(AdjustedTPAmount,0)) as AdjustedTPAmount,sum(isnull(AdjustedPWAmount,0)) as AdjustedPWAmount "
            //+ " ,sum(isnull(qqq.VAT,0)) as VAT,sum(isnull(qqq.Discount,0)) as ProductDiscount  "
            //+ " from "
            //+ " (     "
            //+ " select Productid,CustomerID, isnull(sum(QuantityCr)-abs(sum(QuantityDr)),0) as SalesQty, isnull(sum(AmountCr)-abs(sum(AmountDr)),0) as SalesAmount   "
            //+ " ,isnull(sum(AdjustedDPAmountCr)-abs(sum(AdjustedDPAmountdr)),0) as AdjustedDPAmount, isnull(sum(AdjustedTPAmountCr)-abs(sum(AdjustedTPAmountdr)),0) as AdjustedTPAmount   "
            //+ " , isnull(sum(AdjustedPWAmountCr)-abs(sum(AdjustedPWAmountdr)),0) as AdjustedPWAmount    "
            //+ " ,isnull(sum(VATCr)-abs(sum(VATDr)),0) as VAT, isnull(sum(DiscountCr)-abs(sum(DiscountDr)),0) as Discount     "
            //+ " from   "
            //+ " (      "
            //+ " select SID.Productid,IM.CustomerID, sum(quantity) as QuantityCr , sum(unitPrice*Quantity) as AmountCr, sum(Quantity*isnull(AdjustedDPAmount,0)) as AdjustedDPAmountCr  "
            //+ " ,sum(Quantity*isnull(AdjustedTPAmount,0)) as AdjustedTPAmountCr, sum(Quantity*isnull(AdjustedPWAmount,0)) as AdjustedPWAmountCr    "
            //+ " ,sum(quantity*SID.TradePrice*VATAmount) as VATCr , sum(ProductDiscount*Quantity) as DiscountCr  "
            //+ " , 0 as QuantityDr, 0 as AmountDr, 0 as AdjustedDPAmountdr,0 as AdjustedTPAmountdr,0 as AdjustedPWAmountdr   "
            //+ " , 0 as VATDr, 0 as DiscountDr         "
            //+ " from t_salesinvoice IM, t_salesInvoiceDetail SID    "
            //+ "  where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between '" + dYFromDate + "' and '" + dYToDate + "' and im.Invoicedate < '" + dYToDate + "'     "
            //+ " and im.invoicetypeid in(1,2,4,5)  and invoicestatus not in (3)   "
            //+ " group by SID.Productid,IM.CustomerID    "
            //+ " union all      "
            //+ " select SID.Productid,IM.CustomerID    "
            //+ " ,0 as QuantityCr , 0 as AmountCr, 0 as AdjustedDPAmountCr,0 as AdjustedTPAmountCr,0 as AdjustedPWAmountCr , 0 as VATCr , 0 as DiscountCr   "
            //+ " , sum(quantity) as QuantityDr, sum(unitPrice*Quantity) as AmountDr, sum(Quantity*isnull(AdjustedDPAmount,0)) as AdjustedDPAmountdr  "
            //+ " ,sum(Quantity*isnull(AdjustedTPAmount,0)) as AdjustedTPAmountdr, sum(Quantity*isnull(AdjustedPWAmount,0)) as AdjustedPWAmountdr      "
            //+ " ,sum(quantity*SID.TradePrice*VATAmount) as VATDr , sum(ProductDiscount*Quantity) as DiscountDr   "
            //+ "  from t_salesinvoice IM, t_salesInvoiceDetail SID    "
            //+ " where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between '" + dYFromDate + "' and '" + dYToDate + "' and im.Invoicedate < '" + dYToDate + "'     "
            //+ " and im.invoicetypeid in(6,7,9,10,12)  and invoicestatus not in (3)      "
            //+ " group by SID.Productid,IM.CustomerID    "
            //+ "  )      "
            //+ " as qq group by Productid,CustomerID    "
            //+ " )      "
            //+ "  as qqq "
            //+ " Inner join    "
            //+ " (   "
            //+ "  select * from v_customerDetails   "
            //+ " )    "
            //+ " as qqq2 on qqq.customerid = qqq2.customerid  "
            //+ " Inner join    "
            //+ " (   "
            //+ " select * from v_ProductDetails   "
            //+ " )    "
            //+ " as qqq3 on qqq.Productid = qqq3.Productid     "
            //+ " group by    "
            //+ " PGID, PGCode, PGName, MAGID, MAGCode, MAGName, ASGID, ASGCode, ASGName, AGID,AGCode, AGName, qqq.ProductID,ProductCode,ProductName, BrandID, BrandCode, BrandDesc    ";


            sSql = "Select PGID,PGName,MAGID,MAGName,ASGID,ASGName,AGID,AGName,a.ProductID,ProductCode, " +
                   "ProductName,BrandID,BrandDesc as BrandName,sum(SalesQty) as SalesQty,sum(GrossAmount) GrossAmount,sum(NetSale) as SalesAmt, " +
                   "0 as AdjustedDPAmount,0 as AdjustedTPAmount,0 as AdjustedPWAmount,sum(a.VAT) VAT, " +
                   "sum(a.Discount) as ProductDiscount " +
                   "From DWDB.DBO.t_SalesDataCustomerProduct a, v_ProductDetails b " +
                   "where InvoiceDate between '" + dYFromDate + "' and '" + dYToDate + "' and InvoiceDate < '" +
                   dYToDate + "' " +
                   "and a.ProductID = b.ProductID and CompanyName = 'TEL'";
            if (sProductName != "")
            {
                sSql = sSql + " and ProductName like '%" + sProductName + "%'";
            }
            if (sProductCode != "")
            {
                sSql = sSql + " and ProductCode = '" + sProductCode + "'";
            }

            if (nPgid != -1)
            {
                sSql = sSql + " and PGID = '" + nPgid + "'";
            }
            if (nMagID != -1)
            {
                sSql = sSql + " and MAGID = '" + nMagID + "'";
            }
            if (nAsgID != -1)
            {
                sSql = sSql + " and ASGID = '" + nAsgID + "'";
            }
            if (nAgID != -1)
            {
                sSql = sSql + " and AGID = '" + nAgID + "'";
            }
            if (nBrandID != -1)
            {
                sSql = sSql + " and BrandID = '" + nBrandID + "'";
            }
            sSql = sSql +
                   " group by PGID,PGName,MAGID,MAGName,ASGID,ASGName,AGID,AGName,a.ProductID,ProductCode,ProductName,BrandID,BrandDesc";
            cmd.CommandTimeout = 0;
          cmd.CommandText = sSql;   
          GetDataProductSalesQtyandValueCountrySummary(cmd); 
          
        }


        public void GetDataProductSalesQtyandValueCountrySummary(OleDbCommand cmd)
        { 
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductSalesQtyandValueCountrySummary oItem = new ProductSalesQtyandValueCountrySummary();
                                        
                    if (reader["PGID"] != DBNull.Value)
                        oItem.PGID = (int)reader["PGID"];
                    else oItem.PGID = -1;

                    if (reader["PGName"] != DBNull.Value)
                        oItem.PGName = (string)reader["PGName"];
                    else oItem.PGName = "";

                    if (reader["MAGID"] != DBNull.Value)
                        oItem.MAGID = (int)reader["MAGID"];
                    else oItem.MAGID = -1;

                    if (reader["MAGName"] != DBNull.Value)
                        oItem.MAGName = (string)reader["MAGName"];
                    else oItem.MAGName = "";

                    if (reader["ASGID"] != DBNull.Value)
                        oItem.ASGID = (int)reader["ASGID"];
                    else oItem.ASGID = -1;

                    if (reader["ASGName"] != DBNull.Value)
                        oItem.ASGName = (string)reader["ASGName"];
                    else oItem.ASGName = "";

                    if (reader["AGID"] != DBNull.Value)
                        oItem.AGID = (int)reader["AGID"];
                    else oItem.AGID = -1;

                    if (reader["AGName"] != DBNull.Value)
                        oItem.AGName = (string)reader["AGName"];
                    else oItem.AGName = "";                                       
                                        
                    if (reader["ProductID"] != DBNull.Value)
                        oItem.ProductID = (int)reader["ProductID"];
                    else oItem.ProductID = -1;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = Convert.ToInt32(reader["ProductCode"]);
                    else oItem.ProductCode = -1;

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    if (reader["BrandID"] != DBNull.Value)
                        oItem.BrandID = (int)reader["BrandID"];
                    else oItem.BrandID = -1;

                    if (reader["BrandName"] != DBNull.Value)
                        oItem.BrandName = (string)reader["BrandName"];
                    else oItem.BrandName = "";
                                        
                    if (reader["SalesQty"] != DBNull.Value)
                        oItem.SalesQty = Convert.ToInt64 (reader["SalesQty"]);
                    else oItem.SalesQty = 0;

                    if (reader["GrossAmount"] != DBNull.Value)
                        oItem.GrossAmount = (double)reader["GrossAmount"];
                    else oItem.GrossAmount = 0;


                    if (reader["SalesAmt"] != DBNull.Value)
                        oItem.SalesAmt = (double) reader["SalesAmt"];
                    else oItem.SalesAmt = 0;

                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"]);
                    else oItem.AdjustedDPAmount = 0;
                    
                    if (reader["AdjustedTPAmount"] != DBNull.Value)
                        oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"]);
                    else oItem.AdjustedTPAmount = 0;

                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"]);
                    else oItem.AdjustedPWAmount = 0;
                    
                    if (reader["VAT"] != DBNull.Value)
                        oItem.VAT = Convert.ToDouble(reader["VAT"]);
                    else oItem.VAT = -1;

                    if (reader["ProductDiscount"] != DBNull.Value)
                        oItem.ProductDiscount = Convert.ToDouble(reader["ProductDiscount"]);
                    else oItem.ProductDiscount = 0;

                   Add(oItem);
                }
                reader.Close();
              

            }
            catch (Exception ex)
            {
                throw (ex);
            }        
        }

        public void FromDataSetProductSalesQtyandValueCountrySummary(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    ProductSalesQtyandValueCountrySummary oProductSalesQtyandValueCountrySummary = new ProductSalesQtyandValueCountrySummary();
                    
                    
                    oProductSalesQtyandValueCountrySummary.PGID = Convert.ToInt32(oRow["PGID"]);
                    oProductSalesQtyandValueCountrySummary.PGName = (string)oRow["PGName"];
                    oProductSalesQtyandValueCountrySummary.MAGID = Convert.ToInt32(oRow["MAGID"]);
                    oProductSalesQtyandValueCountrySummary.MAGName = (string)oRow["MAGName"];
                    oProductSalesQtyandValueCountrySummary.ASGID = Convert.ToInt32(oRow["ASGID"]);
                    oProductSalesQtyandValueCountrySummary.ASGName = (string)oRow["ASGName"];
                    oProductSalesQtyandValueCountrySummary.AGID = Convert.ToInt32(oRow["AGID"]);
                    oProductSalesQtyandValueCountrySummary.AGName = (string)oRow["AGName"];
                    oProductSalesQtyandValueCountrySummary.BrandID = Convert.ToInt32(oRow["BrandID"]);
                    oProductSalesQtyandValueCountrySummary.BrandName = (string)oRow["BrandName"];
                    oProductSalesQtyandValueCountrySummary.ProductID = Convert.ToInt32(oRow["ProductID"]);
                    oProductSalesQtyandValueCountrySummary.ProductCode = Convert.ToInt32(oRow["ProductCode"]);
                    oProductSalesQtyandValueCountrySummary.ProductName = (string)oRow["ProductName"];
                    oProductSalesQtyandValueCountrySummary.SalesQty = Convert.ToInt32(oRow["SalesQty"]);
                    oProductSalesQtyandValueCountrySummary.SalesAmt = Convert.ToInt32(oRow["SalesAmt"]);
                    oProductSalesQtyandValueCountrySummary.AdjustedDPAmount = Convert.ToInt32(oRow["AdjustedDPAmount"]);
                    oProductSalesQtyandValueCountrySummary.AdjustedTPAmount = Convert.ToInt32(oRow["AdjustedTPAmount"]);
                    oProductSalesQtyandValueCountrySummary.AdjustedPWAmount = Convert.ToInt32(oRow["AdjustedPWAmount"]);
                    oProductSalesQtyandValueCountrySummary.VAT = Convert.ToInt32(oRow["VAT"]);
                    oProductSalesQtyandValueCountrySummary.ProductDiscount = Convert.ToInt32(oRow["ProductDiscount"]);

                    InnerList.Add(oProductSalesQtyandValueCountrySummary);
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

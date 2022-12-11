// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: January 12, 2012
// Time :  11:00 AM
// Description: Class for Month Wise SKU Wise Sales Qty.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Light
{
    public class SKUWiseSalesQty
    {
        private string _sASGName;
        private string _sProductCode;
        private string _sProductName;
        private int _nJanSalesQty;
        private int _nFebSalesQty;
        private int _nMarSalesQty;
        private int _nAprSalesQty;
        private int _nMaySalesQty;
        private int _nJunSalesQty;
        private int _nJulSalesQty;
        private int _nAugSalesQty;
        private int _nSepSalesQty;
        private int _nOctSalesQty;
        private int _nNovSalesQty;
        private int _nDecSalesQty;
        private int _nTotalSalesQty;


        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
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

        public int JanSalesQty
        {
            get { return _nJanSalesQty; }
            set { _nJanSalesQty = value; }
        }
        public int FebSalesQty
        {
            get { return _nFebSalesQty; }
            set { _nFebSalesQty = value; }
        }
        public int MarSalesQty
        {
            get { return _nMarSalesQty; }
            set { _nMarSalesQty = value; }
        }
        public int AprSalesQty
        {
            get { return _nAprSalesQty; }
            set { _nAprSalesQty = value; }
        }
        public int MaySalesQty
        {
            get { return _nMaySalesQty; }
            set { _nMaySalesQty = value; }
        }
        public int JunSalesQty
        {
            get { return _nJunSalesQty; }
            set { _nJunSalesQty = value; }
        }
        public int JulSalesQty
        {
            get { return _nJulSalesQty; }
            set { _nJulSalesQty = value; }
        }
        public int AugSalesQty
        {
            get { return _nAugSalesQty; }
            set { _nAugSalesQty = value; }
        }
        public int SepSalesQty
        {
            get { return _nSepSalesQty; }
            set { _nSepSalesQty = value; }
        }
        public int OctSalesQty
        {
            get { return _nOctSalesQty; }
            set { _nOctSalesQty = value; }
        }
        public int NovSalesQty
        {
            get { return _nNovSalesQty; }
            set { _nNovSalesQty = value; }
        }
        public int DecSalesQty
        {
            get { return _nDecSalesQty; }
            set { _nDecSalesQty = value; }
        }
        public int TotalSalesQty
        {
            get { return _nTotalSalesQty; }
            set { _nTotalSalesQty = value; }
        }
    }

    public class SKUWiseSalesQtys : CollectionBase
    {
        public SKUWiseSalesQty this[int i]
        {
            get { return (SKUWiseSalesQty)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SKUWiseSalesQty oSKUWiseSalesQty)
        {
            InnerList.Add(oSKUWiseSalesQty);
        }

        public void SKUSalesSummayALL(DateTime dbFromDate, DateTime dbTODate, DateTime dCYFromDate, DateTime dCYToDate)
        {
            dbTODate = dbTODate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @"
                    select  
                    ASGName, trsales.ProductCode, ProductName,
                    sum(isnull(JanSales,0)) as JanSalesQty, sum(isnull(FebSales,0)) as FebSalesQty, sum(isnull(MarSales,0)) as MarSalesQty, sum(isnull(AprSales,0)) as AprSalesQty,  
                    sum(isnull(MaySales,0)) as MaySalesQty, sum(isnull(JunSales,0)) as JunSalesQty, sum(isnull(JulSales,0)) as JulSalesQty, sum(isnull(AugSales,0)) as AugSalesQty, 
                    sum(isnull(SepSales,0)) as SepSalesQty, sum(isnull(OctSales,0)) as OctSalesQty, sum(isnull(NovSales,0)) as NovSalesQty, sum(isnull(DecSales,0)) as DecSalesQty
                    from
                    (
                    select 
                    isnull(sales.customerCode,target.customerCode) as CustomerCode, isnull (sales.ProductCode,target.ProductCode)as ProductCode,
                    isnull(JanSales,0) as JanSales, isnull(FebSales,0) as FebSales, isnull(MarSales,0) as MarSales, isnull(AprSales,0) as AprSales,  
                    isnull(MaySales,0) as MaySales, isnull(JunSales,0) as JunSales, isnull(JulSales,0) as JulSales, isnull(AugSales,0) as AugSales, 
                    isnull(SepSales,0) as SepSales, isnull(OctSales,0) as OctSales, isnull(NovSales,0) as NovSales, isnull(DecSales,0) as DecSales 
                     
                    from
                    (
                    Select isnull(tel.customerCode,bel.customerCode) as CustomerCode, isnull(tel.productCode,bel.productCode)as Productcode

                    from
                    (
                    select CustomerCode,ProductCode   

                    from telsysdb.dbo.t_planbudgettarget a, telsysdb.dbo.v_customerdetails b, telsysdb.dbo.t_product c 
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID

                    group by  CustomerCode,ProductCode
                    )as tel 

                    full outer join
                    (
                    select CustomerCode,ProductCode   

                    from bllsysdb.dbo.t_planbudgettarget a, bllsysdb.dbo.v_customerdetails b, bllsysdb.dbo.t_product c      
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID
                    group by  CustomerCode,ProductCode
                    )as bel on tel.CustomerCode = bel.CustomerCode and tel.ProductCode = bel.ProductCode
                    ) as Target

                    Full outer join
                    (
                    Select isnull(tel.CustomerCode,bel.CustomerCode) as CustomerCode, isnull(tel.productCode,bel.productCode) as ProductCode,
                    (isnull(tel.JanSales,0)+isnull(bel.JanSales,0))as JanSales, (isnull(tel.FebSales,0)+isnull(bel.FebSales,0))as FebSales, (isnull(tel.MarSales,0)+isnull(bel.MarSales,0))as MarSales, 
                    (isnull(tel.AprSales,0)+isnull(bel.AprSales,0))as AprSales, (isnull(tel.MaySales,0)+isnull(bel.MaySales,0))as MaySales, (isnull(tel.JunSales,0)+isnull(bel.JunSales,0))as JunSales,
                    (isnull(tel.JulSales,0)+isnull(bel.JulSales,0))as JulSales, (isnull(tel.AugSales,0)+isnull(bel.AugSales,0))as AugSales, (isnull(tel.SepSales,0)+isnull(bel.SepSales,0))as SepSales,
                    (isnull(tel.OctSales,0)+isnull(bel.OctSales,0))as OctSales, (isnull(tel.NovSales,0)+isnull(bel.NovSales,0))as NovSales, (isnull(tel.DecSales,0)+isnull(bel.DecSales,0))as DecSales

                    from
                    (
                    select p2.CustomerCode,p2.ProductCode    
                    , isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales, isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales, isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales     
                    , isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales, isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales, isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales    
                    , isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales, isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales, isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales   
                    , isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales, isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales, isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales
                      
                    from     
                    (    
                    select CustomerCode, ProductCode,   
                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as CRJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as CRFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as CRMarCYR,   
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as CRAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as CRMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as CRJunCYR,
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as CRJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as CRAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as CRSepCYR,
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as CROctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as CRNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as CRDcmCYR,
                                        
                      
                    0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,    
                    0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR
                         
                    from telsysdb.dbo.t_salesInvoice im,  telsysdb.dbo.t_salesInvoiceDetail cd, telsysdb.dbo.v_customerdetails c, telsysdb.dbo.t_product d    
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and cd.productid = d.productid and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (1,2,4,5) and invoicestatus not in (3)
                        
                    group by  CustomerCode,ProductCode   
                     
                    UNION ALL   
                     
                    select CustomerCode,ProductCode,    
                    0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,    
                    0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  

                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as DbJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as DbFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as DbMarCYR,    
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as DbAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as DbMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as DbJunCYR,    
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as DbJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as DbAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as DbSepCYR,    
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR

                    from telsysdb.dbo.t_salesInvoice im,  telsysdb.dbo.t_salesInvoiceDetail cd, telsysdb.dbo.v_customerdetails c, telsysdb.dbo.t_product d     
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and  cd.productid = d.productid and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)    
                    group by  CustomerCode,ProductCode 
                    )    
                    as p2   
                    group by p2.CustomerCode,p2.ProductCode
                    ) as  Tel
                    full outer join
                    (
                    select p2.CustomerCode,p2.ProductCode   
                    , isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales, isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales, isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales     
                    , isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales, isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales, isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales    
                    , isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales, isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales, isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales    
                    , isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales, isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales, isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales
                      
                    from     
                    (    
                    select CustomerCode, ProductCode,   
                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as CRJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as CRFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as CRMarCYR,   
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as CRAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as CRMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as CRJunCYR,
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as CRJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as CRAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as CRSepCYR,
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as CROctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as CRNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as CRDcmCYR,
                                        
                    0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,    
                    0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR
                          
                    from bllsysdb.dbo.t_salesInvoice im,  bllsysdb.dbo.t_salesInvoiceDetail cd, bllsysdb.dbo.v_customerdetails c,bllsysdb.dbo.t_product d   
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and cd.ProductID = d.ProductID and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (1,2,4,5) and invoicestatus not in (3)    
                    group by  CustomerCode,ProductCode   

                    UNION ALL   

                    select CustomerCode,ProductCode,    
                    0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,    
                    0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  
                           
                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as DbJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as DbFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as DbMarCYR,    
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as DbAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as DbMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as DbJunCYR,    
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as DbJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as DbAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as DbSepCYR,    
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR

                    from bllsysdb.dbo.t_salesInvoice im,  bllsysdb.dbo.t_salesInvoiceDetail cd, bllsysdb.dbo.v_customerdetails c, bllsysdb.dbo.t_product d    
                    where  im.InvoiceID = cd.InvoiceID and im.customerid = c.customerid and channelid =2 and cd.ProductID = d.ProductID and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)    
                    group by  CustomerCode,ProductCode   
                    )    
                    as p2   
                    group by p2.CustomerCode,p2.ProductCode 
                    ) as  bel on tel.CustomerCode = bel.CustomerCode and tel.productCode = bel.productCode
                    ) as Sales on sales.customerCode = target.customerCode and sales.ProductCode = target.ProductCode
                    )as trsales  
                    inner join
                    (
                    select * from telsysdb.dbo.v_customerdetails where channelid = 2 
                    ) as cd on trsales.customerCode = cd.customerCode
                    inner join
                    (
                    select * from telsysdb.dbo.v_productdetails  
                    ) as pd on trsales.productCode = pd.productCode 
                    group by trsales.ProductCode, ProductName, ASGName";

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sSql.ToString();

            cmd.Parameters.AddWithValue("invoicedate", dCYFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dCYToDate);
            cmd.Parameters.AddWithValue("invoicedate", dCYFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dCYToDate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    if (Convert.ToInt32(reader["JanSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["FebSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MarSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AprSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MaySalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JunSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JulSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AugSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["SepSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["OctSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["FebSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["NovSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["DecSalesQty"].ToString()) > 0)
                    {
                        SKUWiseSalesQty oSKUSalesQty = new SKUWiseSalesQty();
                        oSKUSalesQty.ProductName = (string)reader["ProductName"];
                        oSKUSalesQty.ProductCode = (string)reader["ProductCode"];
                        oSKUSalesQty.ASGName = (string)reader["ASGName"];
                        oSKUSalesQty.JanSalesQty = Convert.ToInt32(reader["JanSalesQty"].ToString());
                        oSKUSalesQty.FebSalesQty = Convert.ToInt32(reader["FebSalesQty"].ToString());
                        oSKUSalesQty.MarSalesQty = Convert.ToInt32(reader["MarSalesQty"].ToString());
                        oSKUSalesQty.AprSalesQty = Convert.ToInt32(reader["AprSalesQty"].ToString());
                        oSKUSalesQty.MaySalesQty = Convert.ToInt32(reader["MaySalesQty"].ToString());
                        oSKUSalesQty.JunSalesQty = Convert.ToInt32(reader["JunSalesQty"].ToString());
                        oSKUSalesQty.JulSalesQty = Convert.ToInt32(reader["JulSalesQty"].ToString());
                        oSKUSalesQty.AugSalesQty = Convert.ToInt32(reader["AugSalesQty"].ToString());
                        oSKUSalesQty.SepSalesQty = Convert.ToInt32(reader["SepSalesQty"].ToString());
                        oSKUSalesQty.OctSalesQty = Convert.ToInt32(reader["OctSalesQty"].ToString());
                        oSKUSalesQty.NovSalesQty = Convert.ToInt32(reader["NovSalesQty"].ToString());
                        oSKUSalesQty.DecSalesQty = Convert.ToInt32(reader["DecSalesQty"].ToString());
                        oSKUSalesQty.TotalSalesQty = oSKUSalesQty.JanSalesQty + oSKUSalesQty.FebSalesQty + oSKUSalesQty.MarSalesQty + oSKUSalesQty.AprSalesQty + oSKUSalesQty.MaySalesQty + oSKUSalesQty.JunSalesQty + oSKUSalesQty.JulSalesQty + oSKUSalesQty.AugSalesQty + oSKUSalesQty.SepSalesQty + oSKUSalesQty.OctSalesQty + oSKUSalesQty.NovSalesQty + oSKUSalesQty.DecSalesQty;

                        InnerList.Add(oSKUSalesQty);
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SKUSalesSummayASG(DateTime dbFromDate, DateTime dbTODate,DateTime dCYFromDate, DateTime dCYToDate, String sASG)
        {
            dbTODate = dbTODate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @"
                    select  
                    ASGName, trsales.ProductCode, ProductName,
                    sum(isnull(JanSales,0)) as JanSalesQty, sum(isnull(FebSales,0)) as FebSalesQty, sum(isnull(MarSales,0)) as MarSalesQty, sum(isnull(AprSales,0)) as AprSalesQty,  
                    sum(isnull(MaySales,0)) as MaySalesQty, sum(isnull(JunSales,0)) as JunSalesQty, sum(isnull(JulSales,0)) as JulSalesQty, sum(isnull(AugSales,0)) as AugSalesQty, 
                    sum(isnull(SepSales,0)) as SepSalesQty, sum(isnull(OctSales,0)) as OctSalesQty, sum(isnull(NovSales,0)) as NovSalesQty, sum(isnull(DecSales,0)) as DecSalesQty
                    from
                    (
                    select 
                    isnull(sales.customerCode,target.customerCode) as CustomerCode, isnull (sales.ProductCode,target.ProductCode)as ProductCode,
                    isnull(JanSales,0) as JanSales, isnull(FebSales,0) as FebSales, isnull(MarSales,0) as MarSales, isnull(AprSales,0) as AprSales,  
                    isnull(MaySales,0) as MaySales, isnull(JunSales,0) as JunSales, isnull(JulSales,0) as JulSales, isnull(AugSales,0) as AugSales, 
                    isnull(SepSales,0) as SepSales, isnull(OctSales,0) as OctSales, isnull(NovSales,0) as NovSales, isnull(DecSales,0) as DecSales 
                     
                    from
                    (
                    Select isnull(tel.customerCode,bel.customerCode) as CustomerCode, isnull(tel.productCode,bel.productCode)as Productcode

                    from
                    (
                    select CustomerCode,ProductCode   

                    from telsysdb.dbo.t_planbudgettarget a, telsysdb.dbo.v_customerdetails b, telsysdb.dbo.t_product c 
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID

                    group by  CustomerCode,ProductCode
                    )as tel 

                    full outer join
                    (
                    select CustomerCode,ProductCode   

                    from bllsysdb.dbo.t_planbudgettarget a, bllsysdb.dbo.v_customerdetails b, bllsysdb.dbo.t_product c      
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID
                    group by  CustomerCode,ProductCode
                    )as bel on tel.CustomerCode = bel.CustomerCode and tel.ProductCode = bel.ProductCode
                    ) as Target

                    Full outer join
                    (
                    Select isnull(tel.CustomerCode,bel.CustomerCode) as CustomerCode, isnull(tel.productCode,bel.productCode) as ProductCode,
                    (isnull(tel.JanSales,0)+isnull(bel.JanSales,0))as JanSales, (isnull(tel.FebSales,0)+isnull(bel.FebSales,0))as FebSales, (isnull(tel.MarSales,0)+isnull(bel.MarSales,0))as MarSales, 
                    (isnull(tel.AprSales,0)+isnull(bel.AprSales,0))as AprSales, (isnull(tel.MaySales,0)+isnull(bel.MaySales,0))as MaySales, (isnull(tel.JunSales,0)+isnull(bel.JunSales,0))as JunSales,
                    (isnull(tel.JulSales,0)+isnull(bel.JulSales,0))as JulSales, (isnull(tel.AugSales,0)+isnull(bel.AugSales,0))as AugSales, (isnull(tel.SepSales,0)+isnull(bel.SepSales,0))as SepSales,
                    (isnull(tel.OctSales,0)+isnull(bel.OctSales,0))as OctSales, (isnull(tel.NovSales,0)+isnull(bel.NovSales,0))as NovSales, (isnull(tel.DecSales,0)+isnull(bel.DecSales,0))as DecSales

                    from
                    (
                    select p2.CustomerCode,p2.ProductCode    
                    , isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales, isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales, isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales     
                    , isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales, isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales, isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales    
                    , isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales, isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales, isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales   
                    , isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales, isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales, isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales
                      
                    from     
                    (    
                    select CustomerCode, ProductCode,   
                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as CRJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as CRFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as CRMarCYR,   
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as CRAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as CRMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as CRJunCYR,
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as CRJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as CRAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as CRSepCYR,
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as CROctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as CRNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as CRDcmCYR,
                                        
                      
                    0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,    
                    0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR
                         
                    from telsysdb.dbo.t_salesInvoice im,  telsysdb.dbo.t_salesInvoiceDetail cd, telsysdb.dbo.v_customerdetails c, telsysdb.dbo.t_product d    
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and cd.productid = d.productid and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (1,2,4,5) and invoicestatus not in (3)
                        
                    group by  CustomerCode,ProductCode   
                     
                    UNION ALL   
                     
                    select CustomerCode,ProductCode,    
                    0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,    
                    0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  

                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as DbJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as DbFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as DbMarCYR,    
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as DbAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as DbMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as DbJunCYR,    
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as DbJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as DbAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as DbSepCYR,    
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR

                    from telsysdb.dbo.t_salesInvoice im,  telsysdb.dbo.t_salesInvoiceDetail cd, telsysdb.dbo.v_customerdetails c, telsysdb.dbo.t_product d     
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and  cd.productid = d.productid and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)    
                    group by  CustomerCode,ProductCode 
                    )    
                    as p2   
                    group by p2.CustomerCode,p2.ProductCode
                    ) as  Tel
                    full outer join
                    (
                    select p2.CustomerCode,p2.ProductCode   
                    , isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales, isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales, isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales     
                    , isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales, isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales, isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales    
                    , isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales, isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales, isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales    
                    , isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales, isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales, isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales
                      
                    from     
                    (    
                    select CustomerCode, ProductCode,   
                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as CRJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as CRFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as CRMarCYR,   
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as CRAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as CRMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as CRJunCYR,
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as CRJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as CRAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as CRSepCYR,
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as CROctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as CRNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as CRDcmCYR,
                                        
                    0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,    
                    0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR
                          
                    from bllsysdb.dbo.t_salesInvoice im,  bllsysdb.dbo.t_salesInvoiceDetail cd, bllsysdb.dbo.v_customerdetails c,bllsysdb.dbo.t_product d   
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and cd.ProductID = d.ProductID and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (1,2,4,5) and invoicestatus not in (3)    
                    group by  CustomerCode,ProductCode   

                    UNION ALL   

                    select CustomerCode,ProductCode,    
                    0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,    
                    0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  
                           
                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as DbJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as DbFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as DbMarCYR,    
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as DbAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as DbMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as DbJunCYR,    
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as DbJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as DbAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as DbSepCYR,    
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR

                    from bllsysdb.dbo.t_salesInvoice im,  bllsysdb.dbo.t_salesInvoiceDetail cd, bllsysdb.dbo.v_customerdetails c, bllsysdb.dbo.t_product d    
                    where  im.InvoiceID = cd.InvoiceID and im.customerid = c.customerid and channelid =2 and cd.ProductID = d.ProductID and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)    
                    group by  CustomerCode,ProductCode   
                    )    
                    as p2   
                    group by p2.CustomerCode,p2.ProductCode 
                    ) as  bel on tel.CustomerCode = bel.CustomerCode and tel.productCode = bel.productCode
                    ) as Sales on sales.customerCode = target.customerCode and sales.ProductCode = target.ProductCode
                    )as trsales  
                    inner join
                    (
                    select * from telsysdb.dbo.v_customerdetails where channelid = 2 
                    ) as cd on trsales.customerCode = cd.customerCode
                    inner join
                    (
                    select * from telsysdb.dbo.v_productdetails  
                    ) as pd on trsales.productCode = pd.productCode and ASGName = ? 
                    group by trsales.ProductCode, ProductName, ASGName";

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sSql.ToString();

            cmd.Parameters.AddWithValue("invoicedate", dCYFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dCYToDate);
            cmd.Parameters.AddWithValue("invoicedate", dCYFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dCYToDate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("ASGName", sASG);



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    if (Convert.ToInt32(reader["JanSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["FebSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MarSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AprSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MaySalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JunSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JulSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AugSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["SepSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["OctSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["FebSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["NovSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["DecSalesQty"].ToString()) > 0)
                    {
                        SKUWiseSalesQty oSKUSalesQty = new SKUWiseSalesQty();
                        oSKUSalesQty.ProductName = (string)reader["ProductName"];
                        oSKUSalesQty.ProductCode = (string)reader["ProductCode"];
                        oSKUSalesQty.ASGName = (string)reader["ASGName"];
                        oSKUSalesQty.JanSalesQty = Convert.ToInt32(reader["JanSalesQty"].ToString());
                        oSKUSalesQty.FebSalesQty = Convert.ToInt32(reader["FebSalesQty"].ToString());
                        oSKUSalesQty.MarSalesQty = Convert.ToInt32(reader["MarSalesQty"].ToString());
                        oSKUSalesQty.AprSalesQty = Convert.ToInt32(reader["AprSalesQty"].ToString());
                        oSKUSalesQty.MaySalesQty = Convert.ToInt32(reader["MaySalesQty"].ToString());
                        oSKUSalesQty.JunSalesQty = Convert.ToInt32(reader["JunSalesQty"].ToString());
                        oSKUSalesQty.JulSalesQty = Convert.ToInt32(reader["JulSalesQty"].ToString());
                        oSKUSalesQty.AugSalesQty = Convert.ToInt32(reader["AugSalesQty"].ToString());
                        oSKUSalesQty.SepSalesQty = Convert.ToInt32(reader["SepSalesQty"].ToString());
                        oSKUSalesQty.OctSalesQty = Convert.ToInt32(reader["OctSalesQty"].ToString());
                        oSKUSalesQty.NovSalesQty = Convert.ToInt32(reader["NovSalesQty"].ToString());
                        oSKUSalesQty.DecSalesQty = Convert.ToInt32(reader["DecSalesQty"].ToString());
                        oSKUSalesQty.TotalSalesQty = oSKUSalesQty.JanSalesQty + oSKUSalesQty.FebSalesQty + oSKUSalesQty.MarSalesQty + oSKUSalesQty.AprSalesQty + oSKUSalesQty.MaySalesQty + oSKUSalesQty.JunSalesQty + oSKUSalesQty.JulSalesQty + oSKUSalesQty.AugSalesQty + oSKUSalesQty.SepSalesQty + oSKUSalesQty.OctSalesQty + oSKUSalesQty.NovSalesQty + oSKUSalesQty.DecSalesQty;

                        InnerList.Add(oSKUSalesQty);
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SKUSalesSummayBrand(DateTime dbFromDate, DateTime dbTODate,DateTime dCYFromDate, DateTime dCYToDate, String sBrand)
        {
            dbTODate = dbTODate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @"
                    select  
                    ASGName, trsales.ProductCode, ProductName,
                    sum(isnull(JanSales,0)) as JanSalesQty, sum(isnull(FebSales,0)) as FebSalesQty, sum(isnull(MarSales,0)) as MarSalesQty, sum(isnull(AprSales,0)) as AprSalesQty,  
                    sum(isnull(MaySales,0)) as MaySalesQty, sum(isnull(JunSales,0)) as JunSalesQty, sum(isnull(JulSales,0)) as JulSalesQty, sum(isnull(AugSales,0)) as AugSalesQty, 
                    sum(isnull(SepSales,0)) as SepSalesQty, sum(isnull(OctSales,0)) as OctSalesQty, sum(isnull(NovSales,0)) as NovSalesQty, sum(isnull(DecSales,0)) as DecSalesQty
                    from
                    (
                    select 
                    isnull(sales.customerCode,target.customerCode) as CustomerCode, isnull (sales.ProductCode,target.ProductCode)as ProductCode,
                    isnull(JanSales,0) as JanSales, isnull(FebSales,0) as FebSales, isnull(MarSales,0) as MarSales, isnull(AprSales,0) as AprSales,  
                    isnull(MaySales,0) as MaySales, isnull(JunSales,0) as JunSales, isnull(JulSales,0) as JulSales, isnull(AugSales,0) as AugSales, 
                    isnull(SepSales,0) as SepSales, isnull(OctSales,0) as OctSales, isnull(NovSales,0) as NovSales, isnull(DecSales,0) as DecSales 
                     
                    from
                    (
                    Select isnull(tel.customerCode,bel.customerCode) as CustomerCode, isnull(tel.productCode,bel.productCode)as Productcode

                    from
                    (
                    select CustomerCode,ProductCode   

                    from telsysdb.dbo.t_planbudgettarget a, telsysdb.dbo.v_customerdetails b, telsysdb.dbo.t_product c 
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID

                    group by  CustomerCode,ProductCode
                    )as tel 

                    full outer join
                    (
                    select CustomerCode,ProductCode   

                    from bllsysdb.dbo.t_planbudgettarget a, bllsysdb.dbo.v_customerdetails b, bllsysdb.dbo.t_product c      
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID
                    group by  CustomerCode,ProductCode
                    )as bel on tel.CustomerCode = bel.CustomerCode and tel.ProductCode = bel.ProductCode
                    ) as Target

                    Full outer join
                    (
                    Select isnull(tel.CustomerCode,bel.CustomerCode) as CustomerCode, isnull(tel.productCode,bel.productCode) as ProductCode,
                    (isnull(tel.JanSales,0)+isnull(bel.JanSales,0))as JanSales, (isnull(tel.FebSales,0)+isnull(bel.FebSales,0))as FebSales, (isnull(tel.MarSales,0)+isnull(bel.MarSales,0))as MarSales, 
                    (isnull(tel.AprSales,0)+isnull(bel.AprSales,0))as AprSales, (isnull(tel.MaySales,0)+isnull(bel.MaySales,0))as MaySales, (isnull(tel.JunSales,0)+isnull(bel.JunSales,0))as JunSales,
                    (isnull(tel.JulSales,0)+isnull(bel.JulSales,0))as JulSales, (isnull(tel.AugSales,0)+isnull(bel.AugSales,0))as AugSales, (isnull(tel.SepSales,0)+isnull(bel.SepSales,0))as SepSales,
                    (isnull(tel.OctSales,0)+isnull(bel.OctSales,0))as OctSales, (isnull(tel.NovSales,0)+isnull(bel.NovSales,0))as NovSales, (isnull(tel.DecSales,0)+isnull(bel.DecSales,0))as DecSales

                    from
                    (
                    select p2.CustomerCode,p2.ProductCode    
                    , isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales, isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales, isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales     
                    , isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales, isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales, isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales    
                    , isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales, isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales, isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales   
                    , isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales, isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales, isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales
                      
                    from     
                    (    
                    select CustomerCode, ProductCode,   
                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as CRJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as CRFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as CRMarCYR,   
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as CRAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as CRMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as CRJunCYR,
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as CRJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as CRAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as CRSepCYR,
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as CROctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as CRNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as CRDcmCYR,
                                        
                      
                    0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,    
                    0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR
                         
                    from telsysdb.dbo.t_salesInvoice im,  telsysdb.dbo.t_salesInvoiceDetail cd, telsysdb.dbo.v_customerdetails c, telsysdb.dbo.t_product d    
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and cd.productid = d.productid and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (1,2,4,5) and invoicestatus not in (3)
                        
                    group by  CustomerCode,ProductCode   
                     
                    UNION ALL   
                     
                    select CustomerCode,ProductCode,    
                    0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,    
                    0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  

                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as DbJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as DbFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as DbMarCYR,    
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as DbAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as DbMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as DbJunCYR,    
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as DbJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as DbAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as DbSepCYR,    
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR

                    from telsysdb.dbo.t_salesInvoice im,  telsysdb.dbo.t_salesInvoiceDetail cd, telsysdb.dbo.v_customerdetails c, telsysdb.dbo.t_product d     
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and  cd.productid = d.productid and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)    
                    group by  CustomerCode,ProductCode 
                    )    
                    as p2   
                    group by p2.CustomerCode,p2.ProductCode
                    ) as  Tel
                    full outer join
                    (
                    select p2.CustomerCode,p2.ProductCode   
                    , isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales, isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales, isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales     
                    , isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales, isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales, isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales    
                    , isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales, isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales, isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales    
                    , isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales, isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales, isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales
                      
                    from     
                    (    
                    select CustomerCode, ProductCode,   
                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as CRJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as CRFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as CRMarCYR,   
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as CRAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as CRMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as CRJunCYR,
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as CRJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as CRAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as CRSepCYR,
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as CROctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as CRNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as CRDcmCYR,
                                        
                    0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,    
                    0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR
                          
                    from bllsysdb.dbo.t_salesInvoice im,  bllsysdb.dbo.t_salesInvoiceDetail cd, bllsysdb.dbo.v_customerdetails c,bllsysdb.dbo.t_product d   
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and cd.ProductID = d.ProductID and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (1,2,4,5) and invoicestatus not in (3)    
                    group by  CustomerCode,ProductCode   

                    UNION ALL   

                    select CustomerCode,ProductCode,    
                    0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,    
                    0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  
                           
                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as DbJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as DbFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as DbMarCYR,    
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as DbAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as DbMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as DbJunCYR,    
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as DbJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as DbAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as DbSepCYR,    
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR

                    from bllsysdb.dbo.t_salesInvoice im,  bllsysdb.dbo.t_salesInvoiceDetail cd, bllsysdb.dbo.v_customerdetails c, bllsysdb.dbo.t_product d    
                    where  im.InvoiceID = cd.InvoiceID and im.customerid = c.customerid and channelid =2 and cd.ProductID = d.ProductID and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)    
                    group by  CustomerCode,ProductCode   
                    )    
                    as p2   
                    group by p2.CustomerCode,p2.ProductCode 
                    ) as  bel on tel.CustomerCode = bel.CustomerCode and tel.productCode = bel.productCode
                    ) as Sales on sales.customerCode = target.customerCode and sales.ProductCode = target.ProductCode
                    )as trsales  
                    inner join
                    (
                    select * from telsysdb.dbo.v_customerdetails where channelid = 2 
                    ) as cd on trsales.customerCode = cd.customerCode
                    inner join
                    (
                    select * from telsysdb.dbo.v_productdetails  
                    ) as pd on trsales.productCode = pd.productCode and Branddesc = ?
                    group by trsales.ProductCode, ProductName, ASGName";

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sSql.ToString();

            cmd.Parameters.AddWithValue("invoicedate", dCYFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dCYToDate);
            cmd.Parameters.AddWithValue("invoicedate", dCYFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dCYToDate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("Branddesc", sBrand);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    if (Convert.ToInt32(reader["JanSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["FebSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MarSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AprSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MaySalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JunSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JulSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AugSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["SepSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["OctSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["FebSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["NovSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["DecSalesQty"].ToString()) > 0)
                    {
                        SKUWiseSalesQty oSKUSalesQty = new SKUWiseSalesQty();
                        oSKUSalesQty.ProductName = (string)reader["ProductName"];
                        oSKUSalesQty.ProductCode = (string)reader["ProductCode"];
                        oSKUSalesQty.ASGName = (string)reader["ASGName"];
                        oSKUSalesQty.JanSalesQty = Convert.ToInt32(reader["JanSalesQty"].ToString());
                        oSKUSalesQty.FebSalesQty = Convert.ToInt32(reader["FebSalesQty"].ToString());
                        oSKUSalesQty.MarSalesQty = Convert.ToInt32(reader["MarSalesQty"].ToString());
                        oSKUSalesQty.AprSalesQty = Convert.ToInt32(reader["AprSalesQty"].ToString());
                        oSKUSalesQty.MaySalesQty = Convert.ToInt32(reader["MaySalesQty"].ToString());
                        oSKUSalesQty.JunSalesQty = Convert.ToInt32(reader["JunSalesQty"].ToString());
                        oSKUSalesQty.JulSalesQty = Convert.ToInt32(reader["JulSalesQty"].ToString());
                        oSKUSalesQty.AugSalesQty = Convert.ToInt32(reader["AugSalesQty"].ToString());
                        oSKUSalesQty.SepSalesQty = Convert.ToInt32(reader["SepSalesQty"].ToString());
                        oSKUSalesQty.OctSalesQty = Convert.ToInt32(reader["OctSalesQty"].ToString());
                        oSKUSalesQty.NovSalesQty = Convert.ToInt32(reader["NovSalesQty"].ToString());
                        oSKUSalesQty.DecSalesQty = Convert.ToInt32(reader["DecSalesQty"].ToString());
                        oSKUSalesQty.TotalSalesQty = oSKUSalesQty.JanSalesQty + oSKUSalesQty.FebSalesQty + oSKUSalesQty.MarSalesQty + oSKUSalesQty.AprSalesQty + oSKUSalesQty.MaySalesQty + oSKUSalesQty.JunSalesQty + oSKUSalesQty.JulSalesQty + oSKUSalesQty.AugSalesQty + oSKUSalesQty.SepSalesQty + oSKUSalesQty.OctSalesQty + oSKUSalesQty.NovSalesQty + oSKUSalesQty.DecSalesQty;

                        InnerList.Add(oSKUSalesQty);
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SKUSalesSummayBrandASG(DateTime dbFromDate, DateTime dbTODate,DateTime dCYFromDate, DateTime dCYToDate, String sBrand, String sASG)
        {
            dbTODate = dbTODate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @"
                    select  
                    ASGName, trsales.ProductCode, ProductName,
                    sum(isnull(JanSales,0)) as JanSalesQty, sum(isnull(FebSales,0)) as FebSalesQty, sum(isnull(MarSales,0)) as MarSalesQty, sum(isnull(AprSales,0)) as AprSalesQty,  
                    sum(isnull(MaySales,0)) as MaySalesQty, sum(isnull(JunSales,0)) as JunSalesQty, sum(isnull(JulSales,0)) as JulSalesQty, sum(isnull(AugSales,0)) as AugSalesQty, 
                    sum(isnull(SepSales,0)) as SepSalesQty, sum(isnull(OctSales,0)) as OctSalesQty, sum(isnull(NovSales,0)) as NovSalesQty, sum(isnull(DecSales,0)) as DecSalesQty
                    from
                    (
                    select 
                    isnull(sales.customerCode,target.customerCode) as CustomerCode, isnull (sales.ProductCode,target.ProductCode)as ProductCode,
                    isnull(JanSales,0) as JanSales, isnull(FebSales,0) as FebSales, isnull(MarSales,0) as MarSales, isnull(AprSales,0) as AprSales,  
                    isnull(MaySales,0) as MaySales, isnull(JunSales,0) as JunSales, isnull(JulSales,0) as JulSales, isnull(AugSales,0) as AugSales, 
                    isnull(SepSales,0) as SepSales, isnull(OctSales,0) as OctSales, isnull(NovSales,0) as NovSales, isnull(DecSales,0) as DecSales 
                     
                    from
                    (
                    Select isnull(tel.customerCode,bel.customerCode) as CustomerCode, isnull(tel.productCode,bel.productCode)as Productcode

                    from
                    (
                    select CustomerCode,ProductCode   

                    from telsysdb.dbo.t_planbudgettarget a, telsysdb.dbo.v_customerdetails b, telsysdb.dbo.t_product c 
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID

                    group by  CustomerCode,ProductCode
                    )as tel 

                    full outer join
                    (
                    select CustomerCode,ProductCode   

                    from bllsysdb.dbo.t_planbudgettarget a, bllsysdb.dbo.v_customerdetails b, bllsysdb.dbo.t_product c      
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID
                    group by  CustomerCode,ProductCode
                    )as bel on tel.CustomerCode = bel.CustomerCode and tel.ProductCode = bel.ProductCode
                    ) as Target

                    Full outer join
                    (
                    Select isnull(tel.CustomerCode,bel.CustomerCode) as CustomerCode, isnull(tel.productCode,bel.productCode) as ProductCode,
                    (isnull(tel.JanSales,0)+isnull(bel.JanSales,0))as JanSales, (isnull(tel.FebSales,0)+isnull(bel.FebSales,0))as FebSales, (isnull(tel.MarSales,0)+isnull(bel.MarSales,0))as MarSales, 
                    (isnull(tel.AprSales,0)+isnull(bel.AprSales,0))as AprSales, (isnull(tel.MaySales,0)+isnull(bel.MaySales,0))as MaySales, (isnull(tel.JunSales,0)+isnull(bel.JunSales,0))as JunSales,
                    (isnull(tel.JulSales,0)+isnull(bel.JulSales,0))as JulSales, (isnull(tel.AugSales,0)+isnull(bel.AugSales,0))as AugSales, (isnull(tel.SepSales,0)+isnull(bel.SepSales,0))as SepSales,
                    (isnull(tel.OctSales,0)+isnull(bel.OctSales,0))as OctSales, (isnull(tel.NovSales,0)+isnull(bel.NovSales,0))as NovSales, (isnull(tel.DecSales,0)+isnull(bel.DecSales,0))as DecSales

                    from
                    (
                    select p2.CustomerCode,p2.ProductCode    
                    , isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales, isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales, isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales     
                    , isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales, isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales, isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales    
                    , isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales, isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales, isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales   
                    , isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales, isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales, isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales
                      
                    from     
                    (    
                    select CustomerCode, ProductCode,   
                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as CRJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as CRFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as CRMarCYR,   
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as CRAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as CRMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as CRJunCYR,
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as CRJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as CRAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as CRSepCYR,
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as CROctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as CRNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as CRDcmCYR,
                                        
                      
                    0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,    
                    0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR
                         
                    from telsysdb.dbo.t_salesInvoice im,  telsysdb.dbo.t_salesInvoiceDetail cd, telsysdb.dbo.v_customerdetails c, telsysdb.dbo.t_product d    
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and cd.productid = d.productid and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (1,2,4,5) and invoicestatus not in (3)
                        
                    group by  CustomerCode,ProductCode   
                     
                    UNION ALL   
                     
                    select CustomerCode,ProductCode,    
                    0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,    
                    0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  

                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as DbJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as DbFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as DbMarCYR,    
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as DbAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as DbMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as DbJunCYR,    
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as DbJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as DbAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as DbSepCYR,    
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR

                    from telsysdb.dbo.t_salesInvoice im,  telsysdb.dbo.t_salesInvoiceDetail cd, telsysdb.dbo.v_customerdetails c, telsysdb.dbo.t_product d     
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and  cd.productid = d.productid and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)    
                    group by  CustomerCode,ProductCode 
                    )    
                    as p2   
                    group by p2.CustomerCode,p2.ProductCode
                    ) as  Tel
                    full outer join
                    (
                    select p2.CustomerCode,p2.ProductCode   
                    , isnull(sum(p2.CRJanCYR) - abs(sum(p2.DbJanCYR)),0) as JanSales, isnull(sum(p2.CRFebCYR) - abs(sum(p2.DbFebCYR)),0) as FebSales, isnull(sum(p2.CRMarCYR) - abs(sum(p2.DbMarCYR)),0) as MarSales     
                    , isnull(sum(p2.CRAprCYR) - abs(sum(p2.DbAprCYR)),0) as AprSales, isnull(sum(p2.CRMayCYR) - abs(sum(p2.DbMayCYR)),0) as MaySales, isnull(sum(p2.CRJunCYR) - abs(sum(p2.DbJunCYR)),0) as JunSales    
                    , isnull(sum(p2.CRJulCYR) - abs(sum(p2.DbJulCYR)),0) as JulSales, isnull(sum(p2.CRAugCYR) - abs(sum(p2.DbAugCYR)),0) as AugSales, isnull(sum(p2.CRSepCYR) - abs(sum(p2.DbSepCYR)),0) as SepSales    
                    , isnull(sum(p2.CROctCYR) - abs(sum(p2.DbOctCYR)),0) as OctSales, isnull(sum(p2.CRNovCYR) - abs(sum(p2.DbNovCYR)),0) as NovSales, isnull(sum(p2.CRDcmCYR) - abs(sum(p2.DbDcmCYR)),0) as DecSales
                      
                    from     
                    (    
                    select CustomerCode, ProductCode,   
                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as CRJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as CRFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as CRMarCYR,   
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as CRAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as CRMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as CRJunCYR,
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as CRJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as CRAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as CRSepCYR,
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as CROctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as CRNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as CRDcmCYR,
                                        
                    0 as DbJanCYR, 0 as DbFebCYR, 0 as DbMarCYR, 0 as DbAprCYR, 0 as DbMayCYR, 0 as DbJunCYR,    
                    0 as DbJulCYR, 0 as DbAugCYR, 0 as DbSepCYR, 0 as DbOctCYR, 0 as DbNovCYR, 0 as DbDcmCYR
                          
                    from bllsysdb.dbo.t_salesInvoice im,  bllsysdb.dbo.t_salesInvoiceDetail cd, bllsysdb.dbo.v_customerdetails c,bllsysdb.dbo.t_product d   
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and cd.ProductID = d.ProductID and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (1,2,4,5) and invoicestatus not in (3)    
                    group by  CustomerCode,ProductCode   

                    UNION ALL   

                    select CustomerCode,ProductCode,    
                    0 as CRJanCYR, 0 as CRFebCYR, 0 as CRMarCYR, 0 as CRAprCYR, 0 as CRMayCYR, 0 as CRJunCYR,    
                    0 as CRJulCYR, 0 as CRAugCYR, 0 as CRSepCYR, 0 as CROctCYR, 0 as CRNovCYR, 0 as CRDcmCYR,  
                           
                    sum(case month(invoicedate) when 1 then Quantity else 0 end) as DbJanCYR, sum(case month(invoicedate) when 2 then Quantity else 0 end) as DbFebCYR, sum(case month(invoicedate) when 3 then Quantity else 0 end) as DbMarCYR,    
                    sum(case month(invoicedate) when 4 then Quantity else 0 end) as DbAprCYR, sum(case month(invoicedate) when 5 then Quantity else 0 end) as DbMayCYR, sum(case month(invoicedate) when 6 then Quantity else 0 end) as DbJunCYR,    
                    sum(case month(invoicedate) when 7 then Quantity else 0 end) as DbJulCYR, sum(case month(invoicedate) when 8 then Quantity else 0 end) as DbAugCYR, sum(case month(invoicedate) when 9 then Quantity else 0 end) as DbSepCYR,    
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR, sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR

                    from bllsysdb.dbo.t_salesInvoice im,  bllsysdb.dbo.t_salesInvoiceDetail cd, bllsysdb.dbo.v_customerdetails c, bllsysdb.dbo.t_product d    
                    where  im.InvoiceID = cd.InvoiceID and im.customerid = c.customerid and channelid =2 and cd.ProductID = d.ProductID and 
                    invoicedate between ? and  ? and invoicedate< ? and im.invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3)    
                    group by  CustomerCode,ProductCode   
                    )    
                    as p2   
                    group by p2.CustomerCode,p2.ProductCode 
                    ) as  bel on tel.CustomerCode = bel.CustomerCode and tel.productCode = bel.productCode
                    ) as Sales on sales.customerCode = target.customerCode and sales.ProductCode = target.ProductCode
                    )as trsales  
                    inner join
                    (
                    select * from telsysdb.dbo.v_customerdetails where channelid = 2 
                    ) as cd on trsales.customerCode = cd.customerCode
                    inner join
                    (
                    select * from telsysdb.dbo.v_productdetails  
                    ) as pd on trsales.productCode = pd.productCode and ASGName = ? and Branddesc = ?
                    group by trsales.ProductCode, ProductName, ASGName";

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sSql.ToString();

            cmd.Parameters.AddWithValue("invoicedate", dCYFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dCYToDate);
            cmd.Parameters.AddWithValue("invoicedate", dCYFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dCYToDate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("invoicedate", dbFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);
            cmd.Parameters.AddWithValue("invoicedate", dbTODate);

            cmd.Parameters.AddWithValue("ASGName", sASG);
            cmd.Parameters.AddWithValue("Branddesc", sBrand);


            try
             {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    if (Convert.ToInt32(reader["JanSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["FebSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MarSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AprSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MaySalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JunSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JulSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AugSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["SepSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["OctSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["FebSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["NovSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["DecSalesQty"].ToString()) > 0)
                    {
                        SKUWiseSalesQty oSKUSalesQty = new SKUWiseSalesQty();
                        oSKUSalesQty.ProductName = (string)reader["ProductName"];
                        oSKUSalesQty.ProductCode = (string)reader["ProductCode"];
                        oSKUSalesQty.ASGName = (string)reader["ASGName"];
                        oSKUSalesQty.JanSalesQty = Convert.ToInt32(reader["JanSalesQty"].ToString());
                        oSKUSalesQty.FebSalesQty = Convert.ToInt32(reader["FebSalesQty"].ToString());
                        oSKUSalesQty.MarSalesQty = Convert.ToInt32(reader["MarSalesQty"].ToString());
                        oSKUSalesQty.AprSalesQty = Convert.ToInt32(reader["AprSalesQty"].ToString());
                        oSKUSalesQty.MaySalesQty = Convert.ToInt32(reader["MaySalesQty"].ToString());
                        oSKUSalesQty.JunSalesQty = Convert.ToInt32(reader["JunSalesQty"].ToString());
                        oSKUSalesQty.JulSalesQty = Convert.ToInt32(reader["JulSalesQty"].ToString());
                        oSKUSalesQty.AugSalesQty = Convert.ToInt32(reader["AugSalesQty"].ToString());
                        oSKUSalesQty.SepSalesQty = Convert.ToInt32(reader["SepSalesQty"].ToString());
                        oSKUSalesQty.OctSalesQty = Convert.ToInt32(reader["OctSalesQty"].ToString());
                        oSKUSalesQty.NovSalesQty = Convert.ToInt32(reader["NovSalesQty"].ToString());
                        oSKUSalesQty.DecSalesQty = Convert.ToInt32(reader["DecSalesQty"].ToString());
                        oSKUSalesQty.TotalSalesQty = oSKUSalesQty.JanSalesQty + oSKUSalesQty.FebSalesQty + oSKUSalesQty.MarSalesQty + oSKUSalesQty.AprSalesQty + oSKUSalesQty.MaySalesQty + oSKUSalesQty.JunSalesQty + oSKUSalesQty.JulSalesQty + oSKUSalesQty.AugSalesQty + oSKUSalesQty.SepSalesQty + oSKUSalesQty.OctSalesQty + oSKUSalesQty.NovSalesQty + oSKUSalesQty.DecSalesQty;

                        InnerList.Add(oSKUSalesQty);
                    }
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

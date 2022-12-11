// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: January 25, 2012
// Time :  12:00 PM
// Description: Class for Month Wise Territory Wise Target vs Ach.
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
    public class rptMonthTerritoryTargetvsAch
    {
        private string _sAreaName;
        private string _sDistributorName;
        private string _sTerritoryName;
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
        private double _JanTargetQty;
        private double _FebTargetQty;
        private double _MarTargetQty;
        private double _AprTargetQty;
        private double _MayTargetQty;
        private double _JunTargetQty;
        private double _JulTargetQty;
        private double _AugTargetQty;
        private double _SepTargetQty;
        private double _OctTargetQty;
        private double _NovTargetQty;
        private double _DecTargetQty;
        private double _TotalTargetQty;
        private double _JanAch;
        private double _FebAch;
        private double _MarAch;
        private double _AprAch;
        private double _MayAch;
        private double _JunAch;
        private double _JulAch;
        private double _AugAch;
        private double _SepAch;
        private double _OctAch;
        private double _NovAch;
        private double _DecAch;
        private double _TotalAch;


        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }
        }

        public string DistributorName
        {
            get { return _sDistributorName; }
            set { _sDistributorName = value; }
        }

        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value; }
        }

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
        public double JanTargetQty
        {
            get { return _JanTargetQty; }
            set { _JanTargetQty = value; }
        }
        public double FebTargetQty
        {
            get { return _FebTargetQty; }
            set { _FebTargetQty = value; }
        }
        public double MarTargetQty
        {
            get { return _MarTargetQty; }
            set { _MarTargetQty = value; }
        }
        public double AprTargetQty
        {
            get { return _AprTargetQty; }
            set { _AprTargetQty = value; }
        }
        public double MayTargetQty
        {
            get { return _MayTargetQty; }
            set { _MayTargetQty = value; }
        }
        public double JunTargetQty
        {
            get { return _JunTargetQty; }
            set { _JunTargetQty = value; }
        }
        public double JulTargetQty
        {
            get { return _JulTargetQty; }
            set { _JulTargetQty = value; }
        }
        public double AugTargetQty
        {
            get { return _AugTargetQty; }
            set { _AugTargetQty = value; }
        }
        public double SepTargetQty
        {
            get { return _SepTargetQty; }
            set { _SepTargetQty = value; }
        }
        public double OctTargetQty
        {
            get { return _OctTargetQty; }
            set { _OctTargetQty = value; }
        }
        public double NovTargetQty
        {
            get { return _NovTargetQty; }
            set { _NovTargetQty = value; }
        }
        public double DecTargetQty
        {
            get { return _DecTargetQty; }
            set { _DecTargetQty = value; }
        }
        public double TotalTargetQty
        {
            get { return _TotalTargetQty; }
            set { _TotalTargetQty = value; }
        }
        public double JanAch
        {
            get { return _JanAch; }
            set { _JanAch = value; }
        }
        public double FebAch
        {
            get { return _FebAch; }
            set { _FebAch = value; }
        }
        public double MarAch
        {
            get { return _MarAch; }
            set { _MarAch = value; }
        }
        public double AprAch
        {
            get { return _AprAch; }
            set { _AprAch = value; }
        }
        public double MayAch
        {
            get { return _MayAch; }
            set { _MayAch = value; }
        }
        public double JunAch
        {
            get { return _JunAch; }
            set { _JunAch = value; }
        }
        public double JulAch
        {
            get { return _JulAch; }
            set { _JulAch = value; }
        }
        public double AugAch
        {
            get { return _AugAch; }
            set { _AugAch = value; }
        }
        public double SepAch
        {
            get { return _SepAch; }
            set { _SepAch = value; }
        }
        public double OctAch
        {
            get { return _OctAch; }
            set { _OctAch = value; }
        }
        public double NovAch
        {
            get { return _NovAch; }
            set { _NovAch = value; }
        }
        public double DecAch
        {
            get { return _DecAch; }
            set { _DecAch = value; }
        }

        public double TotalAch
        {
            get { return _TotalAch; }
            set { _TotalAch = value; }
        }
    }

    public class rptMonthTerritoryTargetvsAchs : CollectionBase
    {
        public rptMonthTerritoryTargetvsAch this[int i]
        {
            get { return (rptMonthTerritoryTargetvsAch)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(rptMonthTerritoryTargetvsAch oTerritoryWise)
        {
            InnerList.Add(oTerritoryWise);
        }

        public void TerritoryWiseSalesvsTargetAll(DateTime dbFromDate, DateTime dbTODate, DateTime dCYFromDate, DateTime dCYToDate)
        {
            dbTODate = dbTODate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @"
                    select TerritoryName, AreaName,

                    sum(isnull(JanSales,0)) as JanSalesQty, sum(isnull(FebSales,0)) as FebSalesQty, sum(isnull(MarSales,0)) as MarSalesQty, sum(isnull(AprSales,0)) as AprSalesQty,  
                    sum(isnull(MaySales,0)) as MaySalesQty, sum(isnull(JunSales,0)) as JunSalesQty, sum(isnull(JulSales,0)) as JulSalesQty, sum(isnull(AugSales,0)) as AugSalesQty, 
                    sum(isnull(SepSales,0)) as SepSalesQty, sum(isnull(OctSales,0)) as OctSalesQty, sum(isnull(NovSales,0)) as NovSalesQty, sum(isnull(DecSales,0)) as DecSalesQty,
                    sum(isnull(JanTarget,0))as JanTargetQty, sum(isnull(FebTarget,0))as FebTargetQty, sum(isnull(MarTarget,0))as MarTargetQty, sum(isnull(AprTarget,0))as AprTargetQty,  
                    sum(isnull(MayTarget,0))as MayTargetQty, sum(isnull(JunTarget,0))as JunTargetQty, sum(isnull(JulTarget,0))as JulTargetQty, sum(isnull(AugTarget,0))as AugTargetQty,  
                    sum(isnull(SepTarget,0))as SepTargetQty, sum(isnull(OctTarget,0))as OctTargetQty, sum(isnull(NovTarget,0))as NovTargetQty, sum(isnull(DecTarget,0))as DecTargetQty
                      
                    from
                    (
                    select 
                    isnull(sales.customerCode,target.customerCode) as CustomerCode, isnull (sales.ProductCode,target.ProductCode)as ProductCode,
                    isnull(JanSales,0) as JanSales, isnull(FebSales,0) as FebSales, isnull(MarSales,0) as MarSales, isnull(AprSales,0) as AprSales,  
                    isnull(MaySales,0) as MaySales, isnull(JunSales,0) as JunSales, isnull(JulSales,0) as JulSales, isnull(AugSales,0) as AugSales, 
                    isnull(SepSales,0) as SepSales, isnull(OctSales,0) as OctSales, isnull(NovSales,0) as NovSales, isnull(DecSales,0) as DecSales,
                    isnull(Jan,0)as JanTarget, isnull(Feb,0)as FebTarget, isnull(Mar,0)as MarTarget, isnull(Apr,0)as AprTarget,  
                    isnull(May,0)as MayTarget, isnull(Jun,0)as JunTarget, isnull(Jul,0)as JulTarget, isnull(Aug,0)as AugTarget,  
                    isnull(Sep,0)as SepTarget, isnull(Oct,0)as OctTarget, isnull(Nov,0)as NovTarget, isnull(Dec,0)as DecTarget

                    from
                    (
                    Select isnull(tel.customerCode,bel.customerCode) as CustomerCode, isnull(tel.productCode,bel.productCode)as Productcode,
                    (isnull(tel.Jan,0)+isnull(bel.Jan,0))as Jan,(isnull(tel.Feb,0)+isnull(bel.Feb,0))as Feb,(isnull(tel.Mar,0)+isnull(bel.Mar,0))as Mar,
                    (isnull(tel.Apr,0)+isnull(bel.Apr,0))as Apr,(isnull(tel.May,0)+isnull(bel.May,0))as May,(isnull(tel.Jun,0)+isnull(bel.Jun,0))as Jun,
                    (isnull(tel.Jul,0)+isnull(bel.Jul,0))as Jul,(isnull(tel.Aug,0)+isnull(bel.Aug,0))as Aug,(isnull(tel.Sep,0)+isnull(bel.Sep,0))as Sep,
                    (isnull(tel.Oct,0)+isnull(bel.Oct,0))as Oct,(isnull(tel.Nov,0)+isnull(bel.Nov,0))as Nov,(isnull(tel.Dec,0)+isnull(bel.Dec,0))as Dec

                    from
                    (
                    select CustomerCode,ProductCode,   
                    sum(case month(Perioddate) when 1 then Qty else 0 end) as Jan, sum(case month(Perioddate) when 2 then Qty else 0 end) as Feb, sum(case month(Perioddate) when 3 then Qty else 0 end) as Mar, 
                    sum(case month(Perioddate) when 4 then Qty else 0 end) as Apr, sum(case month(Perioddate) when 5 then Qty else 0 end) as May, sum(case month(Perioddate) when 6 then Qty else 0 end) as Jun,  
                    sum(case month(Perioddate) when 7 then Qty else 0 end) as Jul, sum(case month(Perioddate) when 8 then Qty else 0 end) as Aug, sum(case month(Perioddate) when 9 then Qty else 0 end) as Sep,   
                    sum(case month(Perioddate) when 10 then Qty else 0 end) as Oct, sum(case month(Perioddate) when 11 then Qty else 0 end) as Nov, sum(case month(Perioddate) when 12 then Qty else 0 end) as Dec

                    from telsysdb.dbo.t_planbudgettarget a, telsysdb.dbo.v_customerdetails b, telsysdb.dbo.t_product c 
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID

                    group by  CustomerCode,ProductCode
                    )as tel 
                    full outer join
                    (
                    select CustomerCode,ProductCode,   
                    sum(case month(Perioddate) when 1 then Qty else 0 end) as Jan, sum(case month(Perioddate) when 2 then Qty else 0 end) as Feb, sum(case month(Perioddate) when 3 then Qty else 0 end) as Mar,    
                    sum(case month(Perioddate) when 4 then Qty else 0 end) as Apr, sum(case month(Perioddate) when 5 then Qty else 0 end) as May, sum(case month(Perioddate) when 6 then Qty else 0 end) as Jun,  
                    sum(case month(Perioddate) when 7 then Qty else 0 end) as Jul, sum(case month(Perioddate) when 8 then Qty else 0 end) as Aug, sum(case month(Perioddate) when 9 then Qty else 0 end) as Sep,  
                    sum(case month(Perioddate) when 10 then Qty else 0 end) as Oct, sum(case month(Perioddate) when 11 then Qty else 0 end) as Nov, sum(case month(Perioddate) when 12 then Qty else 0 end) as Dec

                    from bllsysdb.dbo.t_planbudgettarget a, bllsysdb.dbo.v_customerdetails b, bllsysdb.dbo.t_product c      
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID
                    group by  CustomerCode,ProductCode
                    )as bel on tel.CustomerCode = bel.CustomerCode and tel.ProductCode = bel.ProductCode
                    ) as Target
                    Full outer join
                    (
                    Select isnull(tel.CustomerCode,bel.CustomerCode) as CustomerCode, isnull(tel.productCode,bel.productCode) as ProductCode,
                    (isnull(tel.JanSales,0)+isnull(bel.JanSales,0))as JanSales, (isnull(tel.FebSales,0)+isnull(bel.FebSales,0))as FebSales,(isnull(tel.MarSales,0)+isnull(bel.MarSales,0))as MarSales,
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
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR,sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR


                    from bllsysdb.dbo.t_salesInvoice im,  bllsysdb.dbo.t_salesInvoiceDetail cd, bllsysdb.dbo.v_customerdetails c, bllsysdb.dbo.t_product d    
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and cd.ProductID = d.ProductID and 
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

                    group by TerritoryName, AreaName ";

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

                    if (Convert.ToInt32(reader["JanSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["FebSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MarSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AprSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MaySalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JunSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JulSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AugSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["SepSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["OctSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["NovSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["DecSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JanTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["FebTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["MarTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["AprTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["MayTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["JunTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["JulTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["AugTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["SepTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["OctTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["NovTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["DecTargetQty"].ToString()) > 0)
                    {
                        rptMonthTerritoryTargetvsAch oTerritoryWise = new rptMonthTerritoryTargetvsAch();
                        //rptMonthWiseAreaTerritoryDistributorWiseTargetvsAchievement oAreaWiseQty = new rptMonthWiseAreaTerritoryDistributorWiseTargetvsAchievement();

                        oTerritoryWise.TerritoryName = (string)reader["TerritoryName"];
                        oTerritoryWise.AreaName = (string)reader["AreaName"];
                        oTerritoryWise.JanSalesQty = Convert.ToInt32(reader["JanSalesQty"].ToString());
                        oTerritoryWise.FebSalesQty = Convert.ToInt32(reader["FebSalesQty"].ToString());
                        oTerritoryWise.MarSalesQty = Convert.ToInt32(reader["MarSalesQty"].ToString());
                        oTerritoryWise.AprSalesQty = Convert.ToInt32(reader["AprSalesQty"].ToString());
                        oTerritoryWise.MaySalesQty = Convert.ToInt32(reader["MaySalesQty"].ToString());
                        oTerritoryWise.JunSalesQty = Convert.ToInt32(reader["JunSalesQty"].ToString());
                        oTerritoryWise.JulSalesQty = Convert.ToInt32(reader["JulSalesQty"].ToString());
                        oTerritoryWise.AugSalesQty = Convert.ToInt32(reader["AugSalesQty"].ToString());
                        oTerritoryWise.SepSalesQty = Convert.ToInt32(reader["SepSalesQty"].ToString());
                        oTerritoryWise.OctSalesQty = Convert.ToInt32(reader["OctSalesQty"].ToString());
                        oTerritoryWise.NovSalesQty = Convert.ToInt32(reader["NovSalesQty"].ToString());
                        oTerritoryWise.DecSalesQty = Convert.ToInt32(reader["DecSalesQty"].ToString());
                        oTerritoryWise.TotalSalesQty = oTerritoryWise.JanSalesQty + oTerritoryWise.FebSalesQty + oTerritoryWise.MarSalesQty + oTerritoryWise.AprSalesQty + oTerritoryWise.MaySalesQty + oTerritoryWise.JunSalesQty + oTerritoryWise.JulSalesQty + oTerritoryWise.AugSalesQty + oTerritoryWise.SepSalesQty + oTerritoryWise.OctSalesQty + oTerritoryWise.NovSalesQty + oTerritoryWise.DecSalesQty;
                        oTerritoryWise.JanTargetQty = (double)reader["JanTargetQty"];
                        oTerritoryWise.FebTargetQty = (double)reader["FebTargetQty"];
                        oTerritoryWise.MarTargetQty = (double)reader["MarTargetQty"];
                        oTerritoryWise.AprTargetQty = (double)reader["AprTargetQty"];
                        oTerritoryWise.MayTargetQty = (double)reader["MayTargetQty"];
                        oTerritoryWise.JunTargetQty = (double)reader["JunTargetQty"];
                        oTerritoryWise.JulTargetQty = (double)reader["JulTargetQty"];
                        oTerritoryWise.AugTargetQty = (double)reader["AugTargetQty"];
                        oTerritoryWise.SepTargetQty = (double)reader["SepTargetQty"];
                        oTerritoryWise.OctTargetQty = (double)reader["OctTargetQty"];
                        oTerritoryWise.NovTargetQty = (double)reader["NovTargetQty"];
                        oTerritoryWise.DecTargetQty = (double)reader["DecTargetQty"];
                        oTerritoryWise.TotalTargetQty = oTerritoryWise.JanTargetQty + oTerritoryWise.FebTargetQty + oTerritoryWise.MarTargetQty + oTerritoryWise.AprTargetQty + oTerritoryWise.MayTargetQty + oTerritoryWise.JunTargetQty + oTerritoryWise.JulTargetQty + oTerritoryWise.AugTargetQty + oTerritoryWise.SepTargetQty + oTerritoryWise.OctTargetQty + oTerritoryWise.NovTargetQty + oTerritoryWise.DecTargetQty;

                        oTerritoryWise.JanAch = ((oTerritoryWise.JanSalesQty) / (oTerritoryWise.JanTargetQty)) * 100;
                        oTerritoryWise.FebAch = ((oTerritoryWise.FebSalesQty) / (oTerritoryWise.FebTargetQty)) * 100;
                        oTerritoryWise.MarAch = ((oTerritoryWise.MarSalesQty) / (oTerritoryWise.MarTargetQty)) * 100;
                        oTerritoryWise.AprAch = ((oTerritoryWise.AprSalesQty) / (oTerritoryWise.AprTargetQty)) * 100;
                        oTerritoryWise.MayAch = ((oTerritoryWise.MaySalesQty) / (oTerritoryWise.MayTargetQty)) * 100;
                        oTerritoryWise.JunAch = ((oTerritoryWise.JunSalesQty) / (oTerritoryWise.JunTargetQty)) * 100;
                        oTerritoryWise.JulAch = ((oTerritoryWise.JulSalesQty) / (oTerritoryWise.JulTargetQty)) * 100;
                        oTerritoryWise.AugAch = ((oTerritoryWise.AugSalesQty) / (oTerritoryWise.AugTargetQty)) * 100;
                        oTerritoryWise.SepAch = ((oTerritoryWise.SepSalesQty) / (oTerritoryWise.SepTargetQty)) * 100;
                        oTerritoryWise.OctAch = ((oTerritoryWise.OctSalesQty) / (oTerritoryWise.OctTargetQty)) * 100;
                        oTerritoryWise.NovAch = ((oTerritoryWise.NovSalesQty) / (oTerritoryWise.NovTargetQty)) * 100;
                        oTerritoryWise.DecAch = ((oTerritoryWise.DecSalesQty) / (oTerritoryWise.DecTargetQty)) * 100;
                        oTerritoryWise.TotalAch = ((oTerritoryWise.TotalSalesQty) / (oTerritoryWise.TotalTargetQty)) * 100;

                        InnerList.Add(oTerritoryWise);
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

        public void TerritoryWiseSalesvsTargetASG(DateTime dbFromDate, DateTime dbTODate, DateTime dCYFromDate, DateTime dCYToDate, string sASG)
        {
            dbTODate = dbTODate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @"
                    select TerritoryName, AreaName,

                    sum(isnull(JanSales,0)) as JanSalesQty, sum(isnull(FebSales,0)) as FebSalesQty, sum(isnull(MarSales,0)) as MarSalesQty, sum(isnull(AprSales,0)) as AprSalesQty,  
                    sum(isnull(MaySales,0)) as MaySalesQty, sum(isnull(JunSales,0)) as JunSalesQty, sum(isnull(JulSales,0)) as JulSalesQty, sum(isnull(AugSales,0)) as AugSalesQty, 
                    sum(isnull(SepSales,0)) as SepSalesQty, sum(isnull(OctSales,0)) as OctSalesQty, sum(isnull(NovSales,0)) as NovSalesQty, sum(isnull(DecSales,0)) as DecSalesQty,
                    sum(isnull(JanTarget,0))as JanTargetQty, sum(isnull(FebTarget,0))as FebTargetQty, sum(isnull(MarTarget,0))as MarTargetQty, sum(isnull(AprTarget,0))as AprTargetQty,  
                    sum(isnull(MayTarget,0))as MayTargetQty, sum(isnull(JunTarget,0))as JunTargetQty, sum(isnull(JulTarget,0))as JulTargetQty, sum(isnull(AugTarget,0))as AugTargetQty,  
                    sum(isnull(SepTarget,0))as SepTargetQty, sum(isnull(OctTarget,0))as OctTargetQty, sum(isnull(NovTarget,0))as NovTargetQty, sum(isnull(DecTarget,0))as DecTargetQty
                      
                    from
                    (
                    select 
                    isnull(sales.customerCode,target.customerCode) as CustomerCode, isnull (sales.ProductCode,target.ProductCode)as ProductCode,
                    isnull(JanSales,0) as JanSales, isnull(FebSales,0) as FebSales, isnull(MarSales,0) as MarSales, isnull(AprSales,0) as AprSales,  
                    isnull(MaySales,0) as MaySales, isnull(JunSales,0) as JunSales, isnull(JulSales,0) as JulSales, isnull(AugSales,0) as AugSales, 
                    isnull(SepSales,0) as SepSales, isnull(OctSales,0) as OctSales, isnull(NovSales,0) as NovSales, isnull(DecSales,0) as DecSales,
                    isnull(Jan,0)as JanTarget, isnull(Feb,0)as FebTarget, isnull(Mar,0)as MarTarget, isnull(Apr,0)as AprTarget,  
                    isnull(May,0)as MayTarget, isnull(Jun,0)as JunTarget, isnull(Jul,0)as JulTarget, isnull(Aug,0)as AugTarget,  
                    isnull(Sep,0)as SepTarget, isnull(Oct,0)as OctTarget, isnull(Nov,0)as NovTarget, isnull(Dec,0)as DecTarget

                    from
                    (
                    Select isnull(tel.customerCode,bel.customerCode) as CustomerCode, isnull(tel.productCode,bel.productCode)as Productcode,
                    (isnull(tel.Jan,0)+isnull(bel.Jan,0))as Jan,(isnull(tel.Feb,0)+isnull(bel.Feb,0))as Feb,(isnull(tel.Mar,0)+isnull(bel.Mar,0))as Mar,
                    (isnull(tel.Apr,0)+isnull(bel.Apr,0))as Apr,(isnull(tel.May,0)+isnull(bel.May,0))as May,(isnull(tel.Jun,0)+isnull(bel.Jun,0))as Jun,
                    (isnull(tel.Jul,0)+isnull(bel.Jul,0))as Jul,(isnull(tel.Aug,0)+isnull(bel.Aug,0))as Aug,(isnull(tel.Sep,0)+isnull(bel.Sep,0))as Sep,
                    (isnull(tel.Oct,0)+isnull(bel.Oct,0))as Oct,(isnull(tel.Nov,0)+isnull(bel.Nov,0))as Nov,(isnull(tel.Dec,0)+isnull(bel.Dec,0))as Dec

                    from
                    (
                    select CustomerCode,ProductCode,   
                    sum(case month(Perioddate) when 1 then Qty else 0 end) as Jan, sum(case month(Perioddate) when 2 then Qty else 0 end) as Feb, sum(case month(Perioddate) when 3 then Qty else 0 end) as Mar, 
                    sum(case month(Perioddate) when 4 then Qty else 0 end) as Apr, sum(case month(Perioddate) when 5 then Qty else 0 end) as May, sum(case month(Perioddate) when 6 then Qty else 0 end) as Jun,  
                    sum(case month(Perioddate) when 7 then Qty else 0 end) as Jul, sum(case month(Perioddate) when 8 then Qty else 0 end) as Aug, sum(case month(Perioddate) when 9 then Qty else 0 end) as Sep,   
                    sum(case month(Perioddate) when 10 then Qty else 0 end) as Oct, sum(case month(Perioddate) when 11 then Qty else 0 end) as Nov, sum(case month(Perioddate) when 12 then Qty else 0 end) as Dec

                    from telsysdb.dbo.t_planbudgettarget a, telsysdb.dbo.v_customerdetails b, telsysdb.dbo.t_product c 
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID

                    group by  CustomerCode,ProductCode
                    )as tel 
                    full outer join
                    (
                    select CustomerCode,ProductCode,   
                    sum(case month(Perioddate) when 1 then Qty else 0 end) as Jan, sum(case month(Perioddate) when 2 then Qty else 0 end) as Feb, sum(case month(Perioddate) when 3 then Qty else 0 end) as Mar,    
                    sum(case month(Perioddate) when 4 then Qty else 0 end) as Apr, sum(case month(Perioddate) when 5 then Qty else 0 end) as May, sum(case month(Perioddate) when 6 then Qty else 0 end) as Jun,  
                    sum(case month(Perioddate) when 7 then Qty else 0 end) as Jul, sum(case month(Perioddate) when 8 then Qty else 0 end) as Aug, sum(case month(Perioddate) when 9 then Qty else 0 end) as Sep,  
                    sum(case month(Perioddate) when 10 then Qty else 0 end) as Oct, sum(case month(Perioddate) when 11 then Qty else 0 end) as Nov, sum(case month(Perioddate) when 12 then Qty else 0 end) as Dec

                    from bllsysdb.dbo.t_planbudgettarget a, bllsysdb.dbo.v_customerdetails b, bllsysdb.dbo.t_product c      
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID
                    group by  CustomerCode,ProductCode
                    )as bel on tel.CustomerCode = bel.CustomerCode and tel.ProductCode = bel.ProductCode
                    ) as Target
                    Full outer join
                    (
                    Select isnull(tel.CustomerCode,bel.CustomerCode) as CustomerCode, isnull(tel.productCode,bel.productCode) as ProductCode,
                    (isnull(tel.JanSales,0)+isnull(bel.JanSales,0))as JanSales, (isnull(tel.FebSales,0)+isnull(bel.FebSales,0))as FebSales,(isnull(tel.MarSales,0)+isnull(bel.MarSales,0))as MarSales,
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
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR,sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR


                    from bllsysdb.dbo.t_salesInvoice im,  bllsysdb.dbo.t_salesInvoiceDetail cd, bllsysdb.dbo.v_customerdetails c, bllsysdb.dbo.t_product d    
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and cd.ProductID = d.ProductID and 
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

                    group by TerritoryName, AreaName ";

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

                    if (Convert.ToInt32(reader["JanSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["FebSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MarSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AprSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MaySalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JunSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JulSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AugSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["SepSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["OctSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["NovSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["DecSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JanTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["FebTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["MarTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["AprTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["MayTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["JunTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["JulTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["AugTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["SepTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["OctTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["NovTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["DecTargetQty"].ToString()) > 0)
                    {
                        rptMonthTerritoryTargetvsAch oTerritoryWise = new rptMonthTerritoryTargetvsAch();
                        //rptMonthWiseAreaTerritoryDistributorWiseTargetvsAchievement oAreaWiseQty = new rptMonthWiseAreaTerritoryDistributorWiseTargetvsAchievement();

                        oTerritoryWise.TerritoryName = (string)reader["TerritoryName"];
                        oTerritoryWise.AreaName = (string)reader["AreaName"];
                        oTerritoryWise.JanSalesQty = Convert.ToInt32(reader["JanSalesQty"].ToString());
                        oTerritoryWise.FebSalesQty = Convert.ToInt32(reader["FebSalesQty"].ToString());
                        oTerritoryWise.MarSalesQty = Convert.ToInt32(reader["MarSalesQty"].ToString());
                        oTerritoryWise.AprSalesQty = Convert.ToInt32(reader["AprSalesQty"].ToString());
                        oTerritoryWise.MaySalesQty = Convert.ToInt32(reader["MaySalesQty"].ToString());
                        oTerritoryWise.JunSalesQty = Convert.ToInt32(reader["JunSalesQty"].ToString());
                        oTerritoryWise.JulSalesQty = Convert.ToInt32(reader["JulSalesQty"].ToString());
                        oTerritoryWise.AugSalesQty = Convert.ToInt32(reader["AugSalesQty"].ToString());
                        oTerritoryWise.SepSalesQty = Convert.ToInt32(reader["SepSalesQty"].ToString());
                        oTerritoryWise.OctSalesQty = Convert.ToInt32(reader["OctSalesQty"].ToString());
                        oTerritoryWise.NovSalesQty = Convert.ToInt32(reader["NovSalesQty"].ToString());
                        oTerritoryWise.DecSalesQty = Convert.ToInt32(reader["DecSalesQty"].ToString());
                        oTerritoryWise.TotalSalesQty = oTerritoryWise.JanSalesQty + oTerritoryWise.FebSalesQty + oTerritoryWise.MarSalesQty + oTerritoryWise.AprSalesQty + oTerritoryWise.MaySalesQty + oTerritoryWise.JunSalesQty + oTerritoryWise.JulSalesQty + oTerritoryWise.AugSalesQty + oTerritoryWise.SepSalesQty + oTerritoryWise.OctSalesQty + oTerritoryWise.NovSalesQty + oTerritoryWise.DecSalesQty;
                        oTerritoryWise.JanTargetQty = (double)reader["JanTargetQty"];
                        oTerritoryWise.FebTargetQty = (double)reader["FebTargetQty"];
                        oTerritoryWise.MarTargetQty = (double)reader["MarTargetQty"];
                        oTerritoryWise.AprTargetQty = (double)reader["AprTargetQty"];
                        oTerritoryWise.MayTargetQty = (double)reader["MayTargetQty"];
                        oTerritoryWise.JunTargetQty = (double)reader["JunTargetQty"];
                        oTerritoryWise.JulTargetQty = (double)reader["JulTargetQty"];
                        oTerritoryWise.AugTargetQty = (double)reader["AugTargetQty"];
                        oTerritoryWise.SepTargetQty = (double)reader["SepTargetQty"];
                        oTerritoryWise.OctTargetQty = (double)reader["OctTargetQty"];
                        oTerritoryWise.NovTargetQty = (double)reader["NovTargetQty"];
                        oTerritoryWise.DecTargetQty = (double)reader["DecTargetQty"];
                        oTerritoryWise.TotalTargetQty = oTerritoryWise.JanTargetQty + oTerritoryWise.FebTargetQty + oTerritoryWise.MarTargetQty + oTerritoryWise.AprTargetQty + oTerritoryWise.MayTargetQty + oTerritoryWise.JunTargetQty + oTerritoryWise.JulTargetQty + oTerritoryWise.AugTargetQty + oTerritoryWise.SepTargetQty + oTerritoryWise.OctTargetQty + oTerritoryWise.NovTargetQty + oTerritoryWise.DecTargetQty;

                        oTerritoryWise.JanAch = ((oTerritoryWise.JanSalesQty) / (oTerritoryWise.JanTargetQty)) * 100;
                        oTerritoryWise.FebAch = ((oTerritoryWise.FebSalesQty) / (oTerritoryWise.FebTargetQty)) * 100;
                        oTerritoryWise.MarAch = ((oTerritoryWise.MarSalesQty) / (oTerritoryWise.MarTargetQty)) * 100;
                        oTerritoryWise.AprAch = ((oTerritoryWise.AprSalesQty) / (oTerritoryWise.AprTargetQty)) * 100;
                        oTerritoryWise.MayAch = ((oTerritoryWise.MaySalesQty) / (oTerritoryWise.MayTargetQty)) * 100;
                        oTerritoryWise.JunAch = ((oTerritoryWise.JunSalesQty) / (oTerritoryWise.JunTargetQty)) * 100;
                        oTerritoryWise.JulAch = ((oTerritoryWise.JulSalesQty) / (oTerritoryWise.JulTargetQty)) * 100;
                        oTerritoryWise.AugAch = ((oTerritoryWise.AugSalesQty) / (oTerritoryWise.AugTargetQty)) * 100;
                        oTerritoryWise.SepAch = ((oTerritoryWise.SepSalesQty) / (oTerritoryWise.SepTargetQty)) * 100;
                        oTerritoryWise.OctAch = ((oTerritoryWise.OctSalesQty) / (oTerritoryWise.OctTargetQty)) * 100;
                        oTerritoryWise.NovAch = ((oTerritoryWise.NovSalesQty) / (oTerritoryWise.NovTargetQty)) * 100;
                        oTerritoryWise.DecAch = ((oTerritoryWise.DecSalesQty) / (oTerritoryWise.DecTargetQty)) * 100;
                        oTerritoryWise.TotalAch = ((oTerritoryWise.TotalSalesQty) / (oTerritoryWise.TotalTargetQty)) * 100;

                        InnerList.Add(oTerritoryWise);
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

        public void TerritoryWiseSalesvsTargetBrand(DateTime dbFromDate, DateTime dbTODate, DateTime dCYFromDate, DateTime dCYToDate, string sBrand)
        {
            dbTODate = dbTODate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @"
                    select TerritoryName, AreaName,

                    sum(isnull(JanSales,0)) as JanSalesQty, sum(isnull(FebSales,0)) as FebSalesQty, sum(isnull(MarSales,0)) as MarSalesQty, sum(isnull(AprSales,0)) as AprSalesQty,  
                    sum(isnull(MaySales,0)) as MaySalesQty, sum(isnull(JunSales,0)) as JunSalesQty, sum(isnull(JulSales,0)) as JulSalesQty, sum(isnull(AugSales,0)) as AugSalesQty, 
                    sum(isnull(SepSales,0)) as SepSalesQty, sum(isnull(OctSales,0)) as OctSalesQty, sum(isnull(NovSales,0)) as NovSalesQty, sum(isnull(DecSales,0)) as DecSalesQty,
                    sum(isnull(JanTarget,0))as JanTargetQty, sum(isnull(FebTarget,0))as FebTargetQty, sum(isnull(MarTarget,0))as MarTargetQty, sum(isnull(AprTarget,0))as AprTargetQty,  
                    sum(isnull(MayTarget,0))as MayTargetQty, sum(isnull(JunTarget,0))as JunTargetQty, sum(isnull(JulTarget,0))as JulTargetQty, sum(isnull(AugTarget,0))as AugTargetQty,  
                    sum(isnull(SepTarget,0))as SepTargetQty, sum(isnull(OctTarget,0))as OctTargetQty, sum(isnull(NovTarget,0))as NovTargetQty, sum(isnull(DecTarget,0))as DecTargetQty
                      
                    from
                    (
                    select 
                    isnull(sales.customerCode,target.customerCode) as CustomerCode, isnull (sales.ProductCode,target.ProductCode)as ProductCode,
                    isnull(JanSales,0) as JanSales, isnull(FebSales,0) as FebSales, isnull(MarSales,0) as MarSales, isnull(AprSales,0) as AprSales,  
                    isnull(MaySales,0) as MaySales, isnull(JunSales,0) as JunSales, isnull(JulSales,0) as JulSales, isnull(AugSales,0) as AugSales, 
                    isnull(SepSales,0) as SepSales, isnull(OctSales,0) as OctSales, isnull(NovSales,0) as NovSales, isnull(DecSales,0) as DecSales,
                    isnull(Jan,0)as JanTarget, isnull(Feb,0)as FebTarget, isnull(Mar,0)as MarTarget, isnull(Apr,0)as AprTarget,  
                    isnull(May,0)as MayTarget, isnull(Jun,0)as JunTarget, isnull(Jul,0)as JulTarget, isnull(Aug,0)as AugTarget,  
                    isnull(Sep,0)as SepTarget, isnull(Oct,0)as OctTarget, isnull(Nov,0)as NovTarget, isnull(Dec,0)as DecTarget

                    from
                    (
                    Select isnull(tel.customerCode,bel.customerCode) as CustomerCode, isnull(tel.productCode,bel.productCode)as Productcode,
                    (isnull(tel.Jan,0)+isnull(bel.Jan,0))as Jan,(isnull(tel.Feb,0)+isnull(bel.Feb,0))as Feb,(isnull(tel.Mar,0)+isnull(bel.Mar,0))as Mar,
                    (isnull(tel.Apr,0)+isnull(bel.Apr,0))as Apr,(isnull(tel.May,0)+isnull(bel.May,0))as May,(isnull(tel.Jun,0)+isnull(bel.Jun,0))as Jun,
                    (isnull(tel.Jul,0)+isnull(bel.Jul,0))as Jul,(isnull(tel.Aug,0)+isnull(bel.Aug,0))as Aug,(isnull(tel.Sep,0)+isnull(bel.Sep,0))as Sep,
                    (isnull(tel.Oct,0)+isnull(bel.Oct,0))as Oct,(isnull(tel.Nov,0)+isnull(bel.Nov,0))as Nov,(isnull(tel.Dec,0)+isnull(bel.Dec,0))as Dec

                    from
                    (
                    select CustomerCode,ProductCode,   
                    sum(case month(Perioddate) when 1 then Qty else 0 end) as Jan, sum(case month(Perioddate) when 2 then Qty else 0 end) as Feb, sum(case month(Perioddate) when 3 then Qty else 0 end) as Mar, 
                    sum(case month(Perioddate) when 4 then Qty else 0 end) as Apr, sum(case month(Perioddate) when 5 then Qty else 0 end) as May, sum(case month(Perioddate) when 6 then Qty else 0 end) as Jun,  
                    sum(case month(Perioddate) when 7 then Qty else 0 end) as Jul, sum(case month(Perioddate) when 8 then Qty else 0 end) as Aug, sum(case month(Perioddate) when 9 then Qty else 0 end) as Sep,   
                    sum(case month(Perioddate) when 10 then Qty else 0 end) as Oct, sum(case month(Perioddate) when 11 then Qty else 0 end) as Nov, sum(case month(Perioddate) when 12 then Qty else 0 end) as Dec

                    from telsysdb.dbo.t_planbudgettarget a, telsysdb.dbo.v_customerdetails b, telsysdb.dbo.t_product c 
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID

                    group by  CustomerCode,ProductCode
                    )as tel 
                    full outer join
                    (
                    select CustomerCode,ProductCode,   
                    sum(case month(Perioddate) when 1 then Qty else 0 end) as Jan, sum(case month(Perioddate) when 2 then Qty else 0 end) as Feb, sum(case month(Perioddate) when 3 then Qty else 0 end) as Mar,    
                    sum(case month(Perioddate) when 4 then Qty else 0 end) as Apr, sum(case month(Perioddate) when 5 then Qty else 0 end) as May, sum(case month(Perioddate) when 6 then Qty else 0 end) as Jun,  
                    sum(case month(Perioddate) when 7 then Qty else 0 end) as Jul, sum(case month(Perioddate) when 8 then Qty else 0 end) as Aug, sum(case month(Perioddate) when 9 then Qty else 0 end) as Sep,  
                    sum(case month(Perioddate) when 10 then Qty else 0 end) as Oct, sum(case month(Perioddate) when 11 then Qty else 0 end) as Nov, sum(case month(Perioddate) when 12 then Qty else 0 end) as Dec

                    from bllsysdb.dbo.t_planbudgettarget a, bllsysdb.dbo.v_customerdetails b, bllsysdb.dbo.t_product c      
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID
                    group by  CustomerCode,ProductCode
                    )as bel on tel.CustomerCode = bel.CustomerCode and tel.ProductCode = bel.ProductCode
                    ) as Target
                    Full outer join
                    (
                    Select isnull(tel.CustomerCode,bel.CustomerCode) as CustomerCode, isnull(tel.productCode,bel.productCode) as ProductCode,
                    (isnull(tel.JanSales,0)+isnull(bel.JanSales,0))as JanSales, (isnull(tel.FebSales,0)+isnull(bel.FebSales,0))as FebSales,(isnull(tel.MarSales,0)+isnull(bel.MarSales,0))as MarSales,
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
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR,sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR


                    from bllsysdb.dbo.t_salesInvoice im,  bllsysdb.dbo.t_salesInvoiceDetail cd, bllsysdb.dbo.v_customerdetails c, bllsysdb.dbo.t_product d    
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and cd.ProductID = d.ProductID and 
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

                    group by TerritoryName, AreaName ";

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

                    if (Convert.ToInt32(reader["JanSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["FebSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MarSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AprSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MaySalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JunSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JulSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AugSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["SepSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["OctSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["NovSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["DecSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JanTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["FebTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["MarTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["AprTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["MayTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["JunTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["JulTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["AugTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["SepTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["OctTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["NovTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["DecTargetQty"].ToString()) > 0)
                    {
                        rptMonthTerritoryTargetvsAch oTerritoryWise = new rptMonthTerritoryTargetvsAch();
                        //rptMonthWiseAreaTerritoryDistributorWiseTargetvsAchievement oAreaWiseQty = new rptMonthWiseAreaTerritoryDistributorWiseTargetvsAchievement();

                        oTerritoryWise.TerritoryName = (string)reader["TerritoryName"];
                        oTerritoryWise.AreaName = (string)reader["AreaName"];
                        oTerritoryWise.JanSalesQty = Convert.ToInt32(reader["JanSalesQty"].ToString());
                        oTerritoryWise.FebSalesQty = Convert.ToInt32(reader["FebSalesQty"].ToString());
                        oTerritoryWise.MarSalesQty = Convert.ToInt32(reader["MarSalesQty"].ToString());
                        oTerritoryWise.AprSalesQty = Convert.ToInt32(reader["AprSalesQty"].ToString());
                        oTerritoryWise.MaySalesQty = Convert.ToInt32(reader["MaySalesQty"].ToString());
                        oTerritoryWise.JunSalesQty = Convert.ToInt32(reader["JunSalesQty"].ToString());
                        oTerritoryWise.JulSalesQty = Convert.ToInt32(reader["JulSalesQty"].ToString());
                        oTerritoryWise.AugSalesQty = Convert.ToInt32(reader["AugSalesQty"].ToString());
                        oTerritoryWise.SepSalesQty = Convert.ToInt32(reader["SepSalesQty"].ToString());
                        oTerritoryWise.OctSalesQty = Convert.ToInt32(reader["OctSalesQty"].ToString());
                        oTerritoryWise.NovSalesQty = Convert.ToInt32(reader["NovSalesQty"].ToString());
                        oTerritoryWise.DecSalesQty = Convert.ToInt32(reader["DecSalesQty"].ToString());
                        oTerritoryWise.TotalSalesQty = oTerritoryWise.JanSalesQty + oTerritoryWise.FebSalesQty + oTerritoryWise.MarSalesQty + oTerritoryWise.AprSalesQty + oTerritoryWise.MaySalesQty + oTerritoryWise.JunSalesQty + oTerritoryWise.JulSalesQty + oTerritoryWise.AugSalesQty + oTerritoryWise.SepSalesQty + oTerritoryWise.OctSalesQty + oTerritoryWise.NovSalesQty + oTerritoryWise.DecSalesQty;
                        oTerritoryWise.JanTargetQty = (double)reader["JanTargetQty"];
                        oTerritoryWise.FebTargetQty = (double)reader["FebTargetQty"];
                        oTerritoryWise.MarTargetQty = (double)reader["MarTargetQty"];
                        oTerritoryWise.AprTargetQty = (double)reader["AprTargetQty"];
                        oTerritoryWise.MayTargetQty = (double)reader["MayTargetQty"];
                        oTerritoryWise.JunTargetQty = (double)reader["JunTargetQty"];
                        oTerritoryWise.JulTargetQty = (double)reader["JulTargetQty"];
                        oTerritoryWise.AugTargetQty = (double)reader["AugTargetQty"];
                        oTerritoryWise.SepTargetQty = (double)reader["SepTargetQty"];
                        oTerritoryWise.OctTargetQty = (double)reader["OctTargetQty"];
                        oTerritoryWise.NovTargetQty = (double)reader["NovTargetQty"];
                        oTerritoryWise.DecTargetQty = (double)reader["DecTargetQty"];
                        oTerritoryWise.TotalTargetQty = oTerritoryWise.JanTargetQty + oTerritoryWise.FebTargetQty + oTerritoryWise.MarTargetQty + oTerritoryWise.AprTargetQty + oTerritoryWise.MayTargetQty + oTerritoryWise.JunTargetQty + oTerritoryWise.JulTargetQty + oTerritoryWise.AugTargetQty + oTerritoryWise.SepTargetQty + oTerritoryWise.OctTargetQty + oTerritoryWise.NovTargetQty + oTerritoryWise.DecTargetQty;

                        oTerritoryWise.JanAch = ((oTerritoryWise.JanSalesQty) / (oTerritoryWise.JanTargetQty)) * 100;
                        oTerritoryWise.FebAch = ((oTerritoryWise.FebSalesQty) / (oTerritoryWise.FebTargetQty)) * 100;
                        oTerritoryWise.MarAch = ((oTerritoryWise.MarSalesQty) / (oTerritoryWise.MarTargetQty)) * 100;
                        oTerritoryWise.AprAch = ((oTerritoryWise.AprSalesQty) / (oTerritoryWise.AprTargetQty)) * 100;
                        oTerritoryWise.MayAch = ((oTerritoryWise.MaySalesQty) / (oTerritoryWise.MayTargetQty)) * 100;
                        oTerritoryWise.JunAch = ((oTerritoryWise.JunSalesQty) / (oTerritoryWise.JunTargetQty)) * 100;
                        oTerritoryWise.JulAch = ((oTerritoryWise.JulSalesQty) / (oTerritoryWise.JulTargetQty)) * 100;
                        oTerritoryWise.AugAch = ((oTerritoryWise.AugSalesQty) / (oTerritoryWise.AugTargetQty)) * 100;
                        oTerritoryWise.SepAch = ((oTerritoryWise.SepSalesQty) / (oTerritoryWise.SepTargetQty)) * 100;
                        oTerritoryWise.OctAch = ((oTerritoryWise.OctSalesQty) / (oTerritoryWise.OctTargetQty)) * 100;
                        oTerritoryWise.NovAch = ((oTerritoryWise.NovSalesQty) / (oTerritoryWise.NovTargetQty)) * 100;
                        oTerritoryWise.DecAch = ((oTerritoryWise.DecSalesQty) / (oTerritoryWise.DecTargetQty)) * 100;
                        oTerritoryWise.TotalAch = ((oTerritoryWise.TotalSalesQty) / (oTerritoryWise.TotalTargetQty)) * 100;

                        InnerList.Add(oTerritoryWise);
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

        public void TerritoryWiseSalesvsTargetBrandASG(DateTime dbFromDate, DateTime dbTODate, DateTime dCYFromDate, DateTime dCYToDate, string sBrand, string sASG)
        {
            dbTODate = dbTODate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @"
                    select TerritoryName, AreaName,

                    sum(isnull(JanSales,0)) as JanSalesQty, sum(isnull(FebSales,0)) as FebSalesQty, sum(isnull(MarSales,0)) as MarSalesQty, sum(isnull(AprSales,0)) as AprSalesQty,  
                    sum(isnull(MaySales,0)) as MaySalesQty, sum(isnull(JunSales,0)) as JunSalesQty, sum(isnull(JulSales,0)) as JulSalesQty, sum(isnull(AugSales,0)) as AugSalesQty, 
                    sum(isnull(SepSales,0)) as SepSalesQty, sum(isnull(OctSales,0)) as OctSalesQty, sum(isnull(NovSales,0)) as NovSalesQty, sum(isnull(DecSales,0)) as DecSalesQty,
                    sum(isnull(JanTarget,0))as JanTargetQty, sum(isnull(FebTarget,0))as FebTargetQty, sum(isnull(MarTarget,0))as MarTargetQty, sum(isnull(AprTarget,0))as AprTargetQty,  
                    sum(isnull(MayTarget,0))as MayTargetQty, sum(isnull(JunTarget,0))as JunTargetQty, sum(isnull(JulTarget,0))as JulTargetQty, sum(isnull(AugTarget,0))as AugTargetQty,  
                    sum(isnull(SepTarget,0))as SepTargetQty, sum(isnull(OctTarget,0))as OctTargetQty, sum(isnull(NovTarget,0))as NovTargetQty, sum(isnull(DecTarget,0))as DecTargetQty
                      
                    from
                    (
                    select 
                    isnull(sales.customerCode,target.customerCode) as CustomerCode, isnull (sales.ProductCode,target.ProductCode)as ProductCode,
                    isnull(JanSales,0) as JanSales, isnull(FebSales,0) as FebSales, isnull(MarSales,0) as MarSales, isnull(AprSales,0) as AprSales,  
                    isnull(MaySales,0) as MaySales, isnull(JunSales,0) as JunSales, isnull(JulSales,0) as JulSales, isnull(AugSales,0) as AugSales, 
                    isnull(SepSales,0) as SepSales, isnull(OctSales,0) as OctSales, isnull(NovSales,0) as NovSales, isnull(DecSales,0) as DecSales,
                    isnull(Jan,0)as JanTarget, isnull(Feb,0)as FebTarget, isnull(Mar,0)as MarTarget, isnull(Apr,0)as AprTarget,  
                    isnull(May,0)as MayTarget, isnull(Jun,0)as JunTarget, isnull(Jul,0)as JulTarget, isnull(Aug,0)as AugTarget,  
                    isnull(Sep,0)as SepTarget, isnull(Oct,0)as OctTarget, isnull(Nov,0)as NovTarget, isnull(Dec,0)as DecTarget

                    from
                    (
                    Select isnull(tel.customerCode,bel.customerCode) as CustomerCode, isnull(tel.productCode,bel.productCode)as Productcode,
                    (isnull(tel.Jan,0)+isnull(bel.Jan,0))as Jan,(isnull(tel.Feb,0)+isnull(bel.Feb,0))as Feb,(isnull(tel.Mar,0)+isnull(bel.Mar,0))as Mar,
                    (isnull(tel.Apr,0)+isnull(bel.Apr,0))as Apr,(isnull(tel.May,0)+isnull(bel.May,0))as May,(isnull(tel.Jun,0)+isnull(bel.Jun,0))as Jun,
                    (isnull(tel.Jul,0)+isnull(bel.Jul,0))as Jul,(isnull(tel.Aug,0)+isnull(bel.Aug,0))as Aug,(isnull(tel.Sep,0)+isnull(bel.Sep,0))as Sep,
                    (isnull(tel.Oct,0)+isnull(bel.Oct,0))as Oct,(isnull(tel.Nov,0)+isnull(bel.Nov,0))as Nov,(isnull(tel.Dec,0)+isnull(bel.Dec,0))as Dec

                    from
                    (
                    select CustomerCode,ProductCode,   
                    sum(case month(Perioddate) when 1 then Qty else 0 end) as Jan, sum(case month(Perioddate) when 2 then Qty else 0 end) as Feb, sum(case month(Perioddate) when 3 then Qty else 0 end) as Mar, 
                    sum(case month(Perioddate) when 4 then Qty else 0 end) as Apr, sum(case month(Perioddate) when 5 then Qty else 0 end) as May, sum(case month(Perioddate) when 6 then Qty else 0 end) as Jun,  
                    sum(case month(Perioddate) when 7 then Qty else 0 end) as Jul, sum(case month(Perioddate) when 8 then Qty else 0 end) as Aug, sum(case month(Perioddate) when 9 then Qty else 0 end) as Sep,   
                    sum(case month(Perioddate) when 10 then Qty else 0 end) as Oct, sum(case month(Perioddate) when 11 then Qty else 0 end) as Nov, sum(case month(Perioddate) when 12 then Qty else 0 end) as Dec

                    from telsysdb.dbo.t_planbudgettarget a, telsysdb.dbo.v_customerdetails b, telsysdb.dbo.t_product c 
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID

                    group by  CustomerCode,ProductCode
                    )as tel 
                    full outer join
                    (
                    select CustomerCode,ProductCode,   
                    sum(case month(Perioddate) when 1 then Qty else 0 end) as Jan, sum(case month(Perioddate) when 2 then Qty else 0 end) as Feb, sum(case month(Perioddate) when 3 then Qty else 0 end) as Mar,    
                    sum(case month(Perioddate) when 4 then Qty else 0 end) as Apr, sum(case month(Perioddate) when 5 then Qty else 0 end) as May, sum(case month(Perioddate) when 6 then Qty else 0 end) as Jun,  
                    sum(case month(Perioddate) when 7 then Qty else 0 end) as Jul, sum(case month(Perioddate) when 8 then Qty else 0 end) as Aug, sum(case month(Perioddate) when 9 then Qty else 0 end) as Sep,  
                    sum(case month(Perioddate) when 10 then Qty else 0 end) as Oct, sum(case month(Perioddate) when 11 then Qty else 0 end) as Nov, sum(case month(Perioddate) when 12 then Qty else 0 end) as Dec

                    from bllsysdb.dbo.t_planbudgettarget a, bllsysdb.dbo.v_customerdetails b, bllsysdb.dbo.t_product c      
                    where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4)  
                    and perioddate between ? and ?  and a.MarketGroupID = b.customerid and channelid = 2 and a.ProductGroupID = c.ProductID
                    group by  CustomerCode,ProductCode
                    )as bel on tel.CustomerCode = bel.CustomerCode and tel.ProductCode = bel.ProductCode
                    ) as Target
                    Full outer join
                    (
                    Select isnull(tel.CustomerCode,bel.CustomerCode) as CustomerCode, isnull(tel.productCode,bel.productCode) as ProductCode,
                    (isnull(tel.JanSales,0)+isnull(bel.JanSales,0))as JanSales, (isnull(tel.FebSales,0)+isnull(bel.FebSales,0))as FebSales,(isnull(tel.MarSales,0)+isnull(bel.MarSales,0))as MarSales,
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
                    sum(case month(invoicedate) when 10 then Quantity else 0 end) as DbOctCYR,sum(case month(invoicedate) when 11 then Quantity else 0 end) as DbNovCYR, sum(case month(invoicedate) when 12 then Quantity else 0 end) as DbDcmCYR


                    from bllsysdb.dbo.t_salesInvoice im,  bllsysdb.dbo.t_salesInvoiceDetail cd, bllsysdb.dbo.v_customerdetails c, bllsysdb.dbo.t_product d    
                    where  im.InvoiceID = cd.InvoiceID and  im.customerid = c.customerid and channelid =2 and cd.ProductID = d.ProductID and 
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
                    ) as pd on trsales.productCode = pd.productCode and Branddesc = ? and ASGName = ?

                    group by TerritoryName, AreaName ";

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
            cmd.Parameters.AddWithValue("ASGName", sASG);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    if (Convert.ToInt32(reader["JanSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["FebSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MarSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AprSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["MaySalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JunSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JulSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["AugSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["SepSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["OctSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["NovSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["DecSalesQty"].ToString()) > 0 || Convert.ToInt32(reader["JanTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["FebTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["MarTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["AprTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["MayTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["JunTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["JulTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["AugTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["SepTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["OctTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["NovTargetQty"].ToString()) > 0 || Convert.ToInt32(reader["DecTargetQty"].ToString()) > 0)
                    {
                        rptMonthTerritoryTargetvsAch oTerritoryWise = new rptMonthTerritoryTargetvsAch();
                        //rptMonthWiseAreaTerritoryDistributorWiseTargetvsAchievement oAreaWiseQty = new rptMonthWiseAreaTerritoryDistributorWiseTargetvsAchievement();

                        oTerritoryWise.TerritoryName = (string)reader["TerritoryName"];
                        oTerritoryWise.AreaName = (string)reader["AreaName"];
                        oTerritoryWise.JanSalesQty = Convert.ToInt32(reader["JanSalesQty"].ToString());
                        oTerritoryWise.FebSalesQty = Convert.ToInt32(reader["FebSalesQty"].ToString());
                        oTerritoryWise.MarSalesQty = Convert.ToInt32(reader["MarSalesQty"].ToString());
                        oTerritoryWise.AprSalesQty = Convert.ToInt32(reader["AprSalesQty"].ToString());
                        oTerritoryWise.MaySalesQty = Convert.ToInt32(reader["MaySalesQty"].ToString());
                        oTerritoryWise.JunSalesQty = Convert.ToInt32(reader["JunSalesQty"].ToString());
                        oTerritoryWise.JulSalesQty = Convert.ToInt32(reader["JulSalesQty"].ToString());
                        oTerritoryWise.AugSalesQty = Convert.ToInt32(reader["AugSalesQty"].ToString());
                        oTerritoryWise.SepSalesQty = Convert.ToInt32(reader["SepSalesQty"].ToString());
                        oTerritoryWise.OctSalesQty = Convert.ToInt32(reader["OctSalesQty"].ToString());
                        oTerritoryWise.NovSalesQty = Convert.ToInt32(reader["NovSalesQty"].ToString());
                        oTerritoryWise.DecSalesQty = Convert.ToInt32(reader["DecSalesQty"].ToString());
                        oTerritoryWise.TotalSalesQty = oTerritoryWise.JanSalesQty + oTerritoryWise.FebSalesQty + oTerritoryWise.MarSalesQty + oTerritoryWise.AprSalesQty + oTerritoryWise.MaySalesQty + oTerritoryWise.JunSalesQty + oTerritoryWise.JulSalesQty + oTerritoryWise.AugSalesQty + oTerritoryWise.SepSalesQty + oTerritoryWise.OctSalesQty + oTerritoryWise.NovSalesQty + oTerritoryWise.DecSalesQty;
                        oTerritoryWise.JanTargetQty = (double)reader["JanTargetQty"];
                        oTerritoryWise.FebTargetQty = (double)reader["FebTargetQty"];
                        oTerritoryWise.MarTargetQty = (double)reader["MarTargetQty"];
                        oTerritoryWise.AprTargetQty = (double)reader["AprTargetQty"];
                        oTerritoryWise.MayTargetQty = (double)reader["MayTargetQty"];
                        oTerritoryWise.JunTargetQty = (double)reader["JunTargetQty"];
                        oTerritoryWise.JulTargetQty = (double)reader["JulTargetQty"];
                        oTerritoryWise.AugTargetQty = (double)reader["AugTargetQty"];
                        oTerritoryWise.SepTargetQty = (double)reader["SepTargetQty"];
                        oTerritoryWise.OctTargetQty = (double)reader["OctTargetQty"];
                        oTerritoryWise.NovTargetQty = (double)reader["NovTargetQty"];
                        oTerritoryWise.DecTargetQty = (double)reader["DecTargetQty"];
                        oTerritoryWise.TotalTargetQty = oTerritoryWise.JanTargetQty + oTerritoryWise.FebTargetQty + oTerritoryWise.MarTargetQty + oTerritoryWise.AprTargetQty + oTerritoryWise.MayTargetQty + oTerritoryWise.JunTargetQty + oTerritoryWise.JulTargetQty + oTerritoryWise.AugTargetQty + oTerritoryWise.SepTargetQty + oTerritoryWise.OctTargetQty + oTerritoryWise.NovTargetQty + oTerritoryWise.DecTargetQty;

                        oTerritoryWise.JanAch = ((oTerritoryWise.JanSalesQty) / (oTerritoryWise.JanTargetQty)) * 100;
                        oTerritoryWise.FebAch = ((oTerritoryWise.FebSalesQty) / (oTerritoryWise.FebTargetQty)) * 100;
                        oTerritoryWise.MarAch = ((oTerritoryWise.MarSalesQty) / (oTerritoryWise.MarTargetQty)) * 100;
                        oTerritoryWise.AprAch = ((oTerritoryWise.AprSalesQty) / (oTerritoryWise.AprTargetQty)) * 100;
                        oTerritoryWise.MayAch = ((oTerritoryWise.MaySalesQty) / (oTerritoryWise.MayTargetQty)) * 100;
                        oTerritoryWise.JunAch = ((oTerritoryWise.JunSalesQty) / (oTerritoryWise.JunTargetQty)) * 100;
                        oTerritoryWise.JulAch = ((oTerritoryWise.JulSalesQty) / (oTerritoryWise.JulTargetQty)) * 100;
                        oTerritoryWise.AugAch = ((oTerritoryWise.AugSalesQty) / (oTerritoryWise.AugTargetQty)) * 100;
                        oTerritoryWise.SepAch = ((oTerritoryWise.SepSalesQty) / (oTerritoryWise.SepTargetQty)) * 100;
                        oTerritoryWise.OctAch = ((oTerritoryWise.OctSalesQty) / (oTerritoryWise.OctTargetQty)) * 100;
                        oTerritoryWise.NovAch = ((oTerritoryWise.NovSalesQty) / (oTerritoryWise.NovTargetQty)) * 100;
                        oTerritoryWise.DecAch = ((oTerritoryWise.DecSalesQty) / (oTerritoryWise.DecTargetQty)) * 100;
                        oTerritoryWise.TotalAch = ((oTerritoryWise.TotalSalesQty) / (oTerritoryWise.TotalTargetQty)) * 100;

                        InnerList.Add(oTerritoryWise);
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class ASGPriandSecQty
    {
        private int _nAreaID;
        private string _sAreaName;
        private int _nTerritoryID;
        private string _sTerritoryName;
        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private DateTime _dTranDate;
        private double _nSSPGLS;
        private double _nSSTGLS;
        private double _nSSCFL;
        private double _nSSTL;
        private double _nSSLED;
        private double _nPriPGLS;
        private double _nPriTGLS;
        private double _nPriTCFL;
        private double _nPriTTL;
        private double _nPriLED;
        private double _nTGTPGLS;
        private double _nTGTTGLS;
        private double _nTGTTCFL;
        private double _nTGTTTL;
        private double _nTGTLED;
        private double _nSTKPGLS;
        private double _nSTKTGLS;
        private double _nSTKCFL;
        private double _nSTKTL;
        private double _nSTKLED;

        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value.Trim(); }
        }

        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
        }

        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set {_sTerritoryName=value.Trim(); }
        }

        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }
        }

        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }

        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }

        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }

        public double SSPGLS
        {
            get { return _nSSPGLS; }
            set { _nSSPGLS = value; }
        }

        public double SSTGLS
        {
            get { return _nSSTGLS; }
            set { _nSSTGLS = value; }
        }

        public double SSCFL
        {
            get { return _nSSCFL; }
            set { _nSSCFL = value; }
        }

        public double SSTL
        {
            get { return _nSSTL; }
            set { _nSSTL = value; }
        }

        public double SSLED
        {
            get { return _nSSLED; }
            set { _nSSLED = value; }
        }

        public double PriPGLS
        {
            get { return _nPriPGLS; }
            set { _nPriPGLS = value; }
        }

        public double PriTGLS
        {
            get { return _nPriTGLS; }
            set { _nPriTGLS = value; }
        }

        public double PriTCFL
        {
            get { return _nPriTCFL; }
            set { _nPriTCFL = value; }
        }

        public double PriTTL
        {
            get { return _nPriTTL; }
            set { _nPriTTL = value; }
        }

        public double PriLED
        {
            get { return _nPriLED; }
            set { _nPriLED = value; }
        }

        public double TGTPGLS
        {
            get { return _nTGTPGLS; }
            set { _nTGTPGLS = value; }
        }

        public double TGTTGLS
        {
            get { return _nTGTTGLS; }
            set { _nTGTTGLS = value; }
        }

        public double TGTTCFL
        {
            get { return _nTGTTCFL; }
            set { _nTGTTCFL = value; }
        }

        public double TGTTTL
        {
            get { return _nTGTTTL; }
            set { _nTGTTTL = value; }
        }

        public double TGTLED
        {
            get { return _nTGTLED; }
            set { _nTGTLED = value; }
        }

        public double STKPGLS
        {
            get { return _nSTKPGLS; }
            set { _nSTKPGLS = value; }
        }

        public double STKTGLS
        {
            get { return _nSTKTGLS; }
            set { _nSTKTGLS = value; }
        }

        public double STKCFL
        {
            get { return _nSTKCFL; }
            set { _nSTKCFL = value; }
        }

        public double STKTL
        {
            get { return _nSTKTL; }
            set { _nSTKTL = value; }
        }

        public double STKLED
        {
            get { return _nSTKLED; }
            set { _nSTKLED = value; }
        }


    }

    public class ASGPriandSecQtys : CollectionBaseCustom
    {
        public void Add(ASGPriandSecQty oASGPriandSecQty)
        {
            this.List.Add(oASGPriandSecQty);
        }

        public ASGPriandSecQty this[Int32 Index]
        {
            get
            {
                return (ASGPriandSecQty)this.List[Index];
            }

            set
            {
                if (!(value.GetType().Equals(typeof(ASGPriandSecQty))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        

        public void PriandSecQty(int nUserID, DateTime dDFromDate, DateTime dDToDate, int nAreaID, int nTerritoryID, int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            int nCustID=0;

//            sSql = @" Set dateformat dmy 
//                      select  Final.customerID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryID,TerritoryName, TranDate, SSPGLS, SSTGLS, SSCFL, SSTL, SSLED, PriPGLS, 
//                      PriTGLS, PriTCFL, PriTTL, PriLED, TGTPGLS, TGTTGLS, TGTTCFL, TGTTTL,TGTLED " +
//                    " from " +
//                    " ( " +
//                    " select isnull(SLS.customerID,TGT.MarketGroupID)as customerID, isnull(SLS.TranDate,TGT.PeriodDate)as TranDate, " +
//                    " isnull(SSPGLS,0)as SSPGLS,isnull(SSTGLS,0)as SSTGLS,isnull(SSCFL,0)as SSCFL,isnull(SSTL,0)as SSTL,isnull(SSLED,0)as SSLED, " +
//                    " isnull(PriPGLS,0)as PriPGLS,isnull(PriTGLS,0)as PriTGLS,isnull(PriTCFL,0)as PriTCFL,isnull(PriTTL,0)as PriTTL,isnull(PriLED,0)as PriLED," +
//                    " isnull(TGTPGLS,0)as TGTPGLS, isnull(TGTTGLS,0)as TGTTGLS, isnull(TGTTCFL,0)as TGTTCFL, isnull(TGTTTL,0)as TGTTTL, isnull(TGTLED,0)as TGTLED " +
//                    " from " +
//                    " ( " +
//                    " select customerID,  TranDate, SSPGLS, SSTGLS, SSCFL, SSTL, SSLED, PriPGLS, PriTGLS, PriTCFL, PriTTL, PriLED " +
//                    " from " +
//                    " ( " +
//                    " select isnull(Sec.DistributorID,Pri.customerID)as customerID, isnull(Sec.TranDate,Pri.InvoiceDate)as TranDate, " +  
//                    " isnull(SSPGLS,0)as SSPGLS,isnull(SSTGLS,0)as SSTGLS,isnull(SSCFL,0)as SSCFL,isnull(SSTL,0)as SSTL,isnull(SSLED,0)as SSLED, " +  
//                    " isnull(PriPGLS,0)as PriPGLS,isnull(PriTGLS,0)as PriTGLS,isnull(PriTCFL,0)as PriTCFL,isnull(PriTTL,0)as PriTTL,isnull(PriLED,0)as PriLED " +  
//                    " from " +
//                    " ( " +
//                    " select DistributorID,Qty.TranDate, PGLS as SSPGLS, TGLS as SSTGLS,TCFL as SSCFL, TTL as SSTL, LED as SSLED " +  
//                    " from " +
//                    " ( " +
//                    " select DistributorID, TranDate,sum(case ASGID when 125 then (case BrandID when 1 then SalesQty  else 0 end)  else 0 end ) as PGLS, " +  
//                    " sum(case ASGID when 125 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as TGLS, " +  
//                    " sum(case ASGID when 126 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as TCFL, " +  
//                    " sum(case ASGID when 127 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as TTL, " +  
//                    " sum(case ASGID when 679 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as LED " +  

//                    " from " +
//                    " ( " +
//                    " select DistributorID,ASGID,BrandID,TranDate, sum(SalesQty)as SalesQty " +  
//                    " from " +  
//                    " ( " +  
//                    " select DistributorID,ProductID,TranDate, sum(Qty)as SalesQty " +  
//                    " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b " +  
//                    " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dDFromDate + "' and '" + dDToDate + "' " +
//                    " and Trandate <'" + dDToDate + "' " + 
//                    " group by DistributorID,ProductID, TranDate " +  
//                    " ) " +
//                    " as SLTP " +  
//                    " inner join " +  
//                    " ( " +  
//                    " select * from BLLSysDB.dbo.v_ProductDetails " +  
//                    " ) " +  
//                    " Q5 on SLTP.ProductID=Q5.ProductID " +  
//                    " group by DistributorID,ASGID,BrandID,TranDate " +  
//                    " ) " +  
//                    " as Final " +  
//                    " group by DistributorID,TranDate " +  
//                    " ) " +  
//                    " As Qty " +  
//                    " ) " +  
//                    " as Sec " +  

//                    " full outer join " +  

//                    " ( " +  
//                    " select customerID, InvoiceDate, sum(case ASGID when 125 then (case BrandID when 1 then SalesQty  else 0 end)  else 0 end ) as PriPGLS, " +  
//                    " sum(case ASGID when 125 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as PriTGLS, " +  
//                    " sum(case ASGID when 126 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as PriTCFL, " +  
//                    " sum(case ASGID when 127 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as PriTTL, " +  
//                    " sum(case ASGID when 679 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as PriLED " +  
//                    " from " +  
//                    " ( " +  

//                    " select customerCode,customerID, ASGID,BrandID,  cast(convert(nvarchar(12),InvoiceDate,106)as Datetime) as InvoiceDate, sum(SalesQty)as SalesQty " +  
//                    " from " +  
//                    " ( " +  
//                    " select customerCode,customerID, ASGID,ASGName, BrandDesc,BrandID, InvoiceDate, isnull (sum(QtySA)- sum(QtyRA),0) as SalesQty " +  
//                    " from " +  
//                    " ( " +  
//                    " select  customerCode,c.customerID, ASGID,ASGName, BrandDesc,BrandID, InvoiceDate, sum (Quantity) as QtySA, 0 as  QtyRA " +  
//                    " from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d " +  
//                    " where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2) and InvoicetypeID in (1,2,4,5) and invoiceStatus not in (3)" +  
//                    " and Invoicedate between '" + dDFromDate + "' and '" + dDToDate + "' " +
//                    " and Invoicedate <'" + dDToDate + "' " + 
//                    " group by customerCode,c.customerID, ASGID,ASGName, BrandDesc,BrandID, InvoiceDate " +

//                    " union all " + 

//                    " select  customerCode,c.customerID, ASGID,ASGName, BrandDesc,BrandID, InvoiceDate, 0 as  QtySA,  sum(Quantity) as QtyRA " +
//                    " from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d " +
//                    " where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2) and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3) " +
//                    " and Invoicedate between  '" + dDFromDate + "' and '" + dDToDate + "' " + 
//                    " and Invoicedate <'" + dDToDate + "' " + 
//                    " group by  customerCode,c.customerID,ASGID,ASGName,BrandDesc,BrandID, InvoiceDate " +
//                    " ) " +
//                    " as b " +
//                    " group by  customerCode,customerID, ASGID,ASGName, BrandDesc, BrandID,InvoiceDate " +
//                    " ) " +
//                    " TELBLL " +
//                    "group by customerCode,customerID, ASGID,BrandID, InvoiceDate " +
//                    " ) " +
//                    " as Final " +
//                    " group by customerID,InvoiceDate " +
//                    " ) " +
//                    " as Pri on sec.DistributorID=Pri.CustomerID and sec.TranDate=Pri.InvoiceDate " +
//                    " ) " +
//                    " as PriSec " +
//                    " ) " +
//                    " as SLS " +

//                    " full outer join " +
//                    " ( " +
//                    " select  MarketGroupID,PeriodDate, " +
//                    " sum(case ASGID when 125 then (case BrandID when 1 then TGTQty  else 0 end)  else 0 end ) as TGTPGLS, " +
//                    " sum(case ASGID when 125 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTTGLS, " +
//                    " sum(case ASGID when 126 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTTCFL, " +
//                    " sum(case ASGID when 127 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTTTL, " +
//                    " sum(case ASGID when 679 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTLED " +
//                    " from " +  
//                    " ( " +  
//                    " SELECT  MarketGroupID,ProductGroupID,ASGID,BrandID,PeriodDate, round(sum(Qty),0) AS TGTQty " +      
//                    " FROM  BLLSysDB.dbo.t_PlanBudgetTarget a, v_ProductDetails b " +
//                    " where PeriodDate between '" + dDFromDate + "' and '" + dDToDate + "' " +  
//                    " and PeriodDate <'" + dDToDate + "' " +
//                    " and a.ProductGroupID=b.ProductID " +
//                    " GROUP BY MarketGroupID,ProductGroupID,ASGID,BrandID,PeriodDate " +
//                    " ) " +
//                    " As TGT " +
//                    " group by MarketGroupID,PeriodDate " +
//                    " ) " +
//                    " as TGT on SLS.customerID=TGT.MarketGroupID and SLS.TranDate=TGT.PeriodDate " +
//                    " ) " +
//                    " as Final " +
//                    " inner join " +
//                    " ( " +
//                    " select customerID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryID,TerritoryName from v_CustomerDetails " +
//                    " ) " +
//                    " as Cust on Final.customerID=Cust.customerID where ";


            sSql = @"     Set dateformat dmy   
            select  customerID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryID,TerritoryName, TranDate, SSPGLS, SSTGLS, SSCFL, SSTL, SSLED, PriPGLS, 
            PriTGLS, PriTCFL, PriTTL, PriLED, TGTPGLS, TGTTGLS, TGTTCFL, TGTTTL,TGTLED,isnull(STKPGLS,0)as STKPGLS, isnull(STKTGLS,0)as STKTGLS,
            isnull(STKCFL,0)as STKCFL,isnull(STKTL,0)as STKTL,isnull(STKLED,0)as STKLED " + 
            " from " +
            " ( " +
            " select  Final.customerID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryID,TerritoryName, TranDate, SSPGLS, SSTGLS, SSCFL, SSTL, SSLED, PriPGLS, " +
            " PriTGLS, PriTCFL, PriTTL, PriLED, TGTPGLS, TGTTGLS, TGTTCFL, TGTTTL,TGTLED " +
            " from " +  
            " ( " +  
            " select isnull(SLS.customerID,TGT.MarketGroupID)as customerID, isnull(SLS.TranDate,TGT.PeriodDate)as TranDate, " +  
            " isnull(SSPGLS,0)as SSPGLS,isnull(SSTGLS,0)as SSTGLS,isnull(SSCFL,0)as SSCFL,isnull(SSTL,0)as SSTL,isnull(SSLED,0)as SSLED, " +  
            " isnull(PriPGLS,0)as PriPGLS,isnull(PriTGLS,0)as PriTGLS,isnull(PriTCFL,0)as PriTCFL,isnull(PriTTL,0)as PriTTL,isnull(PriLED,0)as PriLED, " +
            " isnull(TGTPGLS,0)as TGTPGLS, isnull(TGTTGLS,0)as TGTTGLS, isnull(TGTTCFL,0)as TGTTCFL, isnull(TGTTTL,0)as TGTTTL, isnull(TGTLED,0)as TGTLED  " +
            " from  " +
            " (  " +
            " select customerID,  TranDate, SSPGLS, SSTGLS, SSCFL, SSTL, SSLED, PriPGLS, PriTGLS, PriTCFL, PriTTL, PriLED " +  
            " from  " +
            " (  " +
            " select isnull(Sec.DistributorID,Pri.customerID)as customerID, isnull(Sec.TranDate,Pri.InvoiceDate)as TranDate,    " +
            " isnull(SSPGLS,0)as SSPGLS,isnull(SSTGLS,0)as SSTGLS,isnull(SSCFL,0)as SSCFL,isnull(SSTL,0)as SSTL,isnull(SSLED,0)as SSLED,    " +
            " isnull(PriPGLS,0)as PriPGLS,isnull(PriTGLS,0)as PriTGLS,isnull(PriTCFL,0)as PriTCFL,isnull(PriTTL,0)as PriTTL,isnull(PriLED,0)as PriLED    " +
            " from  " +
            " (  " +
            " select DistributorID,Qty.TranDate, PGLS as SSPGLS, TGLS as SSTGLS,TCFL as SSCFL, TTL as SSTL, LED as SSLED " +   
            " from  " +
            " (  " +
            " select DistributorID, TranDate,sum(case ASGID when 125 then (case BrandID when 1 then SalesQty  else 0 end)  else 0 end ) as PGLS,    " +
            " sum(case ASGID when 125 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as TGLS,    " +
            " sum(case ASGID when 126 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as TCFL,    " +
            " sum(case ASGID when 127 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as TTL,   " + 
            " sum(case ASGID when 679 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as LED " +   

            " from  " +
            " (  " +
            " select DistributorID,ASGID,BrandID,TranDate, sum(SalesQty)as SalesQty " +   
            " from    " +
            " (    " +
            " select DistributorID,ProductID,TranDate, sum(Qty)as SalesQty    " +
            " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b    " +
            " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dDFromDate + "' and '" + dDToDate + "' " +
            " and Trandate < '" + dDToDate + "'   " +
            " group by DistributorID,ProductID, TranDate " +   
            " )  " +
            " as SLTP    " +
            " inner join " +   
            " (    " +
            " select * from BLLSysDB.dbo.v_ProductDetails " +   
            " )    " +
            " Q5 on SLTP.ProductID=Q5.ProductID    " +
            " group by DistributorID,ASGID,BrandID,TranDate " +   
            " )    " +
            " as Final    " +
            " group by DistributorID,TranDate " +   
            " )    " +
            " As Qty  " +  
            " )    " +
            " as Sec    " +

            " full outer join " +   

            " (    " +
            " select customerID, InvoiceDate, sum(case ASGID when 125 then (case BrandID when 1 then SalesQty  else 0 end)  else 0 end ) as PriPGLS,   " + 
            " sum(case ASGID when 125 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as PriTGLS,    " +
            " sum(case ASGID when 126 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as PriTCFL,    " +
            " sum(case ASGID when 127 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as PriTTL,   " + 
            " sum(case ASGID when 679 then (case BrandID when 4 then SalesQty  else 0 end)  else 0 end ) as PriLED " +   
            " from    " +
            " (    " +

            " select customerCode,customerID, ASGID,BrandID,  cast(convert(nvarchar(12),InvoiceDate,106)as Datetime) as InvoiceDate, sum(SalesQty)as SalesQty    " +
            " from    " +
            " (    " +
            " select customerCode,customerID, ASGID,ASGName, BrandDesc,BrandID, InvoiceDate, isnull (sum(QtySA)- sum(QtyRA),0) as SalesQty    " +
            " from " +   
            " ( " +   
            " select  customerCode,c.customerID, ASGID,ASGName, BrandDesc,BrandID, InvoiceDate, sum (Quantity) as QtySA, 0 as  QtyRA    " +
            " from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d    " +
            " where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2) and InvoicetypeID in (1,2,4,5) and invoiceStatus not in (3)   " +
            " and Invoicedate between '" + dDFromDate + "' and '" + dDToDate + "' " +
            " and Invoicedate < '" + dDToDate + "'   " +
            " group by customerCode,c.customerID, ASGID,ASGName, BrandDesc,BrandID, InvoiceDate " + 

            " union all   " +

            " select  customerCode,c.customerID, ASGID,ASGName, BrandDesc,BrandID, InvoiceDate, 0 as  QtySA,  sum(Quantity) as QtyRA  " +
            " from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d  " +
            " where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2) and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3)  " +
            " and Invoicedate between  '" + dDFromDate + "' and '" + dDToDate + "'  " +
            " and Invoicedate < '" + dDToDate + "'   " +
            " group by  customerCode,c.customerID,ASGID,ASGName,BrandDesc,BrandID, InvoiceDate " + 
            " )  " +
            " as b  " +
            " group by  customerCode,customerID, ASGID,ASGName, BrandDesc, BrandID,InvoiceDate " + 
            " )  " +
            " TELBLL  " +
            " group by customerCode,customerID, ASGID,BrandID, InvoiceDate " + 
            " )  " +
            " as Final  " +
            " group by customerID,InvoiceDate  " +
            " )  " +
            " as Pri on sec.DistributorID=Pri.CustomerID and sec.TranDate=Pri.InvoiceDate " +  
            " )  " +
            " as PriSec " +  
            " )  " +
            " as SLS  " +

            " full outer join " + 
            " ( " +
            " select  MarketGroupID,PeriodDate,  " +
            " sum(case ASGID when 125 then (case BrandID when 1 then TGTQty  else 0 end)  else 0 end ) as TGTPGLS,  " +
            " sum(case ASGID when 125 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTTGLS,  " +
            " sum(case ASGID when 126 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTTCFL,  " +
            " sum(case ASGID when 127 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTTTL,  " +
            " sum(case ASGID when 679 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTLED " + 
            " from    " +
            " (    " +
            " SELECT  MarketGroupID,ProductGroupID,ASGID,BrandID,PeriodDate, round(sum(Qty),0) AS TGTQty " +       
            " FROM  BLLSysDB.dbo.t_PlanBudgetTarget a, v_ProductDetails b  " +
            " where PeriodDate between '" + dDFromDate + "' and '" + dDToDate + "' " +
            " and PeriodDate < '" + dDToDate + "'  " +
            " and a.ProductGroupID=b.ProductID  " +
            " GROUP BY MarketGroupID,ProductGroupID,ASGID,BrandID,PeriodDate " + 
            " )  " +
            " As TGT  " +
            " group by MarketGroupID,PeriodDate " + 
            " )  " +
            " as TGT on SLS.customerID=TGT.MarketGroupID and SLS.TranDate=TGT.PeriodDate " + 
            " )  " +
            " as Final  " +
            " inner join " +  
            " (  " +
            " select customerID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryID,TerritoryName from v_CustomerDetails " +  
            " )  " +
            " as Cust on Final.customerID=Cust.customerID " +
            " )as SlsPriSec " +
            
            " left outer join " +
            " ( " +
            " select DistributorID, " +
            " sum(case when ASGID=125 then (case when BrandID=1 then Stock else 0 end) else 0 end) STKPGLS, " +
            " sum(case when ASGID=125 then (case when BrandID=4 then Stock else 0 end) else 0 end) STKTGLS, " +
            " sum(case when ASGID=126 then (case when BrandID=4 then Stock else 0 end) else 0 end) STKCFL, " +
            " sum(case when ASGID=127 then (case when BrandID=4 then Stock else 0 end) else 0 end) STKTL, " +
            " sum(case when ASGID=679 then (case when BrandID=4 then Stock else 0 end) else 0 end) STKLED " +
            " from " +
            " ( " +
            " select DistributorID,a.ProductID,b.ASGID,b.BrandID, sum(CurrentStock)as Stock " +
            " from t_DMSProductStock a, v_ProductDetails b " +
            " where a.ProductID=b.ProductID and DistributorID in (select DistributorID from t_DMSUser) " + 
            " group by DistributorID,a.ProductID,b.ASGID,b.BrandID " +
            " )As Stk "+
            " group by DistributorID " +
            " ) as CRStock on SlsPriSec.customerID=CRStock.DistributorID where " ;



            if (nCustomerID > -1)
            {
                sSql = sSql + "  customerID= '" + nCustomerID + "'";

            }
            else
            {
                sSql = sSql + " customerid IN (select CustomerID from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and Isactive=1 )";
                cmd.Parameters.AddWithValue("UserID", nUserID);

            }
            if (nAreaID != -1)
            {
                sSql = sSql + " and areaid = " + nAreaID + "";

            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and territoryid = " + nTerritoryID + "";

            }
             sSql = sSql + " Order by customerID,TranDate ";

            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ASGPriandSecQty oASGPriandSecQty = new ASGPriandSecQty();
                    {


                        oASGPriandSecQty.AreaID = (int)reader["AreaID"];
                        oASGPriandSecQty.AreaName = (string)reader["Areaname"].ToString();
                        oASGPriandSecQty.TerritoryID = (int)reader["TerritoryID"];
                        oASGPriandSecQty.TerritoryName = (string)reader["Territoryname"].ToString();
                        oASGPriandSecQty.CustomerID = Convert.ToInt16(reader["CustomerID"]);
                        oASGPriandSecQty.CustomerCode =(string) reader["CustomerCode"].ToString();
                        oASGPriandSecQty.CustomerName = (string)reader["CustomerName"].ToString();
                        oASGPriandSecQty.TranDate = Convert.ToDateTime(reader["TranDate"]);
                        oASGPriandSecQty.SSPGLS=Convert.ToDouble (reader ["SSPGLS"]);
                        oASGPriandSecQty.SSTGLS=Convert.ToDouble (reader ["SSTGLS"]);
                        oASGPriandSecQty.SSCFL=Convert.ToDouble (reader ["SSCFL"]);
                        oASGPriandSecQty.SSTL=Convert.ToDouble (reader ["SSTL"]);
                        oASGPriandSecQty.SSLED=Convert.ToDouble (reader ["SSLED"]);
                        oASGPriandSecQty.PriPGLS=Convert.ToDouble (reader ["PriPGLS"]);
                        oASGPriandSecQty.PriTGLS=Convert.ToDouble (reader ["PriTGLS"]);
                        oASGPriandSecQty.PriTCFL=Convert.ToDouble (reader ["PriTCFL"]);
                        oASGPriandSecQty.PriTTL=Convert.ToDouble (reader ["PriTTL"]);
                        oASGPriandSecQty.PriLED=Convert.ToDouble (reader ["PriLED"]);
                        oASGPriandSecQty.TGTPGLS=Convert.ToDouble (reader ["TGTPGLS"]);
                        oASGPriandSecQty.TGTTGLS=Convert.ToDouble (reader ["TGTTGLS"]);
                        oASGPriandSecQty.TGTTCFL = Convert.ToDouble(reader["TGTTCFL"]);
                        oASGPriandSecQty.TGTTTL=Convert.ToDouble (reader ["TGTTTL"]);
                        oASGPriandSecQty.TGTLED = Convert.ToDouble(reader["TGTLED"]);

                        if (oASGPriandSecQty.CustomerID != nCustID)
                        {

                            oASGPriandSecQty.STKPGLS = Convert.ToDouble(reader["STKPGLS"]);
                            oASGPriandSecQty.STKTGLS = Convert.ToDouble(reader["STKTGLS"]);
                            oASGPriandSecQty.STKCFL = Convert.ToDouble(reader["STKCFL"]);
                            oASGPriandSecQty.STKTL = Convert.ToDouble(reader["STKTL"]);
                            oASGPriandSecQty.STKLED = Convert.ToDouble(reader["STKLED"]);

                            nCustID = oASGPriandSecQty.CustomerID;

                        }
                        else
                        {
                            oASGPriandSecQty.STKPGLS = 0;
                            oASGPriandSecQty.STKTGLS = 0;
                            oASGPriandSecQty.STKTL = 0;
                            oASGPriandSecQty.STKLED = 0;
                                                    
                        }


                        InnerList.Add(oASGPriandSecQty);
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

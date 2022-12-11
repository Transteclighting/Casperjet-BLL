using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
    public class FootFallReport
    {
        private string _sZone;
        private string _sOutlet;
        private string _sASG;
        private int _nTarget;
        private int _nRQFootFall;
        private int _nActFootFall;
        private string _sBrand;
        private int _nSalesQty;

        private int _nMonth;
        private int _nYear;

        public string Zone
        {
            get { return _sZone; }
            set { _sZone = value; }
        }
        public int SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }
        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value; }
        }
        public int Year
        {
            get { return _nYear; }
            set { _nYear = value; }
        }
        public int Month
        {
            get { return _nMonth; }
            set { _nMonth = value;}
        }        
        public string Outlet
        {
            get { return _sOutlet; }
            set { _sOutlet = value; }
        }
        public string ASG
        {
            get { return _sASG; }
            set { _sASG = value; }
        }
        public int Target
        {
            get { return _nTarget; }
            set { _nTarget = value; }
        }
        public int RQFootFall
        {
            get { return _nRQFootFall; }
            set { _nRQFootFall = value; }
        }
        public int ActFootFall
        {
            get { return _nActFootFall; }
            set { _nActFootFall = value; }
        }
        
    }

    public class FootFallReports : CollectionBaseCustom
    {

        public void Add(FootFallReport oFootFall)
        {
            this.List.Add(oFootFall);
        }
        public FootFallReport this[int i]
        {
            get { return (FootFallReport)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void GetFootFallData( int nTDZoneID,int nOutletID,int nASGID, int nMonth, int nYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select ZoneID,TDZone,OutletID,OutletCode,BrandID,Brand,ASGID,ASGName,CurrMnthTgt,round((CurrMnthTgt*ReqFFPercent),0) CurrMonthReqiredFF,MTDActFF,MTDSalesQty " +
                          "from ( select ZoneID,TDZone,OutletID,OutletCode,BrandID,Brand,detail1.ASGID ASGID,ASGName,CurrMnthTgt,MTDActFF,MTDSalesQty,round(isnull(RequiredFFPercentage,0),2) ReqFFPercent " +
                          "from ( select ZoneID,TDZone,OutletID,OutletCode,BrandID,Branddesc Brand,ASGID,ASGName,sum(CurrMnthTgt) CurrMnthTgt,sum(MTDActFF) MTDActFF,sum(MTDSalesQty) MTDSalesQty " +
                          "from ( select ZoneID,TDZone,vc.CustomerID OutletID,OutletCode,ProductID,CurrMnthTgt,MTDActFF,MTDSalesQty " +
                          "from ( select isnull(tgff.CustomerID,currsl.CustomerID) CustomerID,isnull(tgff.ProductID,currsl.ProductID) ProductID,isnull(CurrMnthTgt,0) CurrMnthTgt,isnull(MTDActFF,0) MTDActFF,isnull(MTDSalesQty,0) MTDSalesQty " +
                          "from ( select isnull(tgt.MarketGroupID,ff.CustomerID) CustomerID,isnull(tgt.ProductGroupID,ff.ProductID) ProductID,isnull(CurrMnthTgt,0) CurrMnthTgt,isnull(MTDActFF,0) MTDActFF " +
                          "from ( select MarketGroupID,ProductGroupID,sum(Qty) CurrMnthTgt from t_PlanBudgetTarget " +
                          "Where versionNo=14 and PlanType=2 and SBUID=2 and ProductGroupType=1 and stage=4 and month(perioddate)=" + nMonth + " and year(perioddate)=" + nYear + " " +
                          "Group by MarketGroupID,ProductGroupID ) tgt full outer join ( select OutletID CustomerID,ProductID,sum(quantity) MTDActFF from telsysdb.dbo.t_FootFallManagement ff " +
                          "where iscurrent=1 and month(ff.footfalldate)=" + nMonth + " and year(ff.footfalldate)=" + nYear + " group by OutletID,ProductID ) ff on tgt.MarketGroupID=ff.CustomerID and tgt.ProductGroupID=ff.ProductID " +
                          ") tgff full outer join ( select Customerid,ProductID,isnull((sum(crqty)- sum(drqty)),0) as MTDSalesQty from ( select v.Customerid Customerid,ProductID,sum(quantity)as crqty,0 as drqty " +
                          "from t_salesinvoice sa, t_salesinvoicedetail sd,v_customerdetails v where sa.invoiceid = sd.invoiceid and month(invoicedate)=" + nMonth + " and year(invoicedate)=" + nYear + " " +
                          "and invoicetypeid in (1,2,4,5)and invoicestatus not in (3) and sa.customerid=v.customerid and channelid=4 and v.customerid not in(789,7,2170,2171) " +
                          "Group by v.Customerid,ProductID union all select v.Customerid Customerid,ProductID,0 as crqty,sum(quantity)as drqty from t_salesinvoice sa, t_salesinvoicedetail sd,v_customerdetails v " +
                          "where sa.invoiceid = sd.invoiceid and month(invoicedate)=" + nMonth + " and year(invoicedate)=" + nYear + " " +
                          "and invoicetypeid in (6,7,9,10,12)and invoicestatus not in (3) and sa.customerid=v.customerid and channelid=4 and v.customerid not in(789,7,2170,2171) " +
                          "Group by v.Customerid,ProductID )as FinalQuery Group by Customerid,ProductID ) currsl on tgff.CustomerID=currsl.CustomerID and tgff.ProductID=currsl.ProductID " +
                          ") tgffsl inner join ( select CustomerID,left(customername,3) OutletCode,territoryid ZoneID,territoryname TDZone from v_customerdetails where channelid=4 and customerid not in(789,7,2170,2171) " +
                          ") vc on tgffsl.CustomerID=vc.CustomerID ) detail inner join (select ProductID,BrandID,Branddesc,ASGID,ASGName from v_productdetails) p on detail.ProductID=p.ProductID " +
                          "group by ZoneID,TDZone,OutletID,OutletCode,BrandID,Branddesc,ASGID,ASGName ) detail1 left outer join (select * from teladddb.dbo.t_tempReqFF) rqff on detail1.ASGID=rqff.ASGID ) detail2 where 1=1";


            if (nTDZoneID != -1)
            {
                sSql = sSql + " and ZoneID=" + nTDZoneID + "  ";
            }
            if (nASGID != -1)
            {
                sSql = sSql + " and ASGID=" + nASGID + "  ";
            }

            if (nOutletID != -1)
            {
                sSql = sSql + " and OutletID=" + nOutletID + "  ";
            }
            cmd.CommandTimeout = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FootFallReport oFootFall = new FootFallReport();
                    oFootFall.Zone = (string)reader["TDZone"];
                    oFootFall.Outlet = (string)reader["OutletCode"];
                    oFootFall.Brand = (string)reader["Brand"];
                    oFootFall.ASG = (string)reader["ASGName"];
                    oFootFall.Target = int.Parse(reader["CurrMnthTgt"].ToString());
                    oFootFall.RQFootFall = int.Parse(reader["CurrMonthReqiredFF"].ToString());
                    oFootFall.ActFootFall = int.Parse(reader["MTDActFF"].ToString());
                    oFootFall.SalesQty = int.Parse(reader["MTDSalesQty"].ToString());
                    InnerList.Add(oFootFall);
                }
                reader.Close();
                InnerList.TrimToSize();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}


// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Mar 25, 2013
// Time" :  4:30 PM
// Description: Area Wise TGT & Sales Report in Amount 
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
    public class RptAreaWiseSalesTO
    {
        private int _nAreaID;
        private string _sAreaName;
        private string _dRegionName;
        private double _dMonthTgtTO;
        private double _dMTDSalesAmt;
        private double _dWTDTGTTO;
        private double _dCWSalesAmt;
        private double _dLWShFall;


        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
        }
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }
        }
        public string RegionName
        {
            get { return _dRegionName; }
            set { _dRegionName = value; }
        }
        public double MonthTgtTO
        {
            get { return _dMonthTgtTO; }
            set { _dMonthTgtTO = value; }
        }
        public double MTDSalesAmt
        {
            get { return _dMTDSalesAmt; }
            set { _dMTDSalesAmt = value; }
        }
        public double WTDTGTTO
        {
            get { return _dWTDTGTTO; }
            set { _dWTDTGTTO = value; }
        }
        public double CWSalesAmt
        {
            get { return _dCWSalesAmt; }
            set { _dCWSalesAmt = value; }
        }
        public double LWShFall
        {
            get { return _dLWShFall; }
            set { _dLWShFall = value; }
        }



    }

    public class RptAreaWiseSalesTOdetails : CollectionBaseCustom
    {

        public void Add(RptAreaWiseSalesTO oRptAreaWiseSalesTO)
        {
            this.List.Add(oRptAreaWiseSalesTO);
        }

        public RptAreaWiseSalesTO this[Int32 Index]
        {
            get
            {
                return (RptAreaWiseSalesTO)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptAreaWiseSalesTO))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }


        public void AreaWiseSalesTO(DateTime dYFromDate, DateTime dYToDate)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Query for Sales & Tgt TO

            
                   sQueryStringMaster.Append( " Set dateformat dmy ");
                   sQueryStringMaster.Append( " select TGT.AreaID,TGT.AreaName,TGT.RegionName,TGT.MonthTgtTO,Sales.MTDSalesAmt,TGT.WTDTGTTO, Sales.CWSalesAmt,TGT.LWShFall ");
                   sQueryStringMaster.Append( " from ");
                   sQueryStringMaster.Append( " ( ");
                   sQueryStringMaster.Append( " select q1.AreaID,q1.AreaName,q1.RegionName,MonthTgtTO,q2.WTDTGTTO, q3.LWShFall ");
                   sQueryStringMaster.Append( " from ");
                   sQueryStringMaster.Append(" ( ");
                   sQueryStringMaster.Append(" select AreaID,AreaName,RegionName,sum(TgtTO) as MonthTgtTO ");
                   sQueryStringMaster.Append(" from TELAdddb.dbo.t_LightTargetTO  ");
                   sQueryStringMaster.Append(" where Tgtdate between '01-Mar-2013' and '31-Mar-2013' ");
                   sQueryStringMaster.Append(" and TranID=1 ");
                   sQueryStringMaster.Append(" group by AreaID,AreaName,RegionName ");
                   sQueryStringMaster.Append(" ) as q1 ");

                   sQueryStringMaster.Append(" left outer join ");
                   sQueryStringMaster.Append(" ( ");
                   sQueryStringMaster.Append(" select AreaID,AreaName,RegionName,sum(TgtTO) as WTDTGTTO ");
                   sQueryStringMaster.Append(" from TELAdddb.dbo.t_LightTargetTO  ");
                   sQueryStringMaster.Append(" where Tgtdate between '01-Mar-2013' and '31-Mar-2013' ");
                   sQueryStringMaster.Append(" and TranID=2 ");
                   sQueryStringMaster.Append(" group by AreaID,AreaName,RegionName ");
                   sQueryStringMaster.Append(" ) as q2 on q1.AreaID=q2.AreaID ");

                   sQueryStringMaster.Append(" left outer join ");
                   sQueryStringMaster.Append(" (  ");

                   sQueryStringMaster.Append(" select AreaID,AreaName,RegionName,sum(TgtTO) as LWShFall ");
                   sQueryStringMaster.Append(" from TELAdddb.dbo.t_LightTargetTO  ");
                   sQueryStringMaster.Append(" where Tgtdate between '01-Mar-2013' and '31-Mar-2013' ");
                   sQueryStringMaster.Append(" and TranID=3 ");
                   sQueryStringMaster.Append(" group by AreaID,AreaName,RegionName ");
                   sQueryStringMaster.Append(" )as q3 on  q1.AreaID=q3.AreaID ");

                   sQueryStringMaster.Append(" ) as TGT ");
                   sQueryStringMaster.Append(" left outer join ");

                   sQueryStringMaster.Append(" ( ");

                   sQueryStringMaster.Append("  select MTD.AreaID,MTD.AreaName, MTDAmount as MTDSalesAmt,isnull(WTD.CWAmount,0)as CWSalesAmt ");
                   sQueryStringMaster.Append("  from ");
                   sQueryStringMaster.Append(" ( ");

                   sQueryStringMaster.Append(" select SLTO.AreaID,SLTO.AreaName, sum(SLTO.Amount)as MTDAmount ");
                   sQueryStringMaster.Append(" from ");
                   sQueryStringMaster.Append(" ( ");
                   sQueryStringMaster.Append(" select SalesTO.CustomerCode,SalesTO.CustomerName, SalesTO.AreaID,SalesTO.AreaName,SalesTO.ChannelDescription, SalesTO.Invoicedate, SalesTO.Amount, SalesTO.Company ");
                   sQueryStringMaster.Append(" from ");
                   sQueryStringMaster.Append(" ( ");
                   sQueryStringMaster.Append(" select SalesAmt.CustomerCode,SalesAmt.Company, b.CustomerName, b.AreaID,b.AreaName,b.ChannelDescription, cast(convert(nvarchar(12),invoicedate,106)as Datetime) as Invoicedate, Amount ");
                   sQueryStringMaster.Append(" from ");
                   sQueryStringMaster.Append(" ( ");

                  sQueryStringMaster.Append("  select CustomerCode,invoicedate,Company, sum (Amount)as Amount     ");
                  sQueryStringMaster.Append("  from ");
                  sQueryStringMaster.Append("  (  ");

                  sQueryStringMaster.Append("  select CustomerCode,invoicedate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount, 'TEL' as Company      ");
                  sQueryStringMaster.Append("  from      ");
                  sQueryStringMaster.Append("  (    ");
                  sQueryStringMaster.Append("  select CustomerCode,invoicedate, sum(invoiceamount) as crAmount, 0 as drAmount ");
                  sQueryStringMaster.Append("  from telsysdb.dbo.t_salesInvoice a, telsysdb.dbo.v_customerdetails v    ");
                  sQueryStringMaster.Append("  where invoicedate between '01-Mar-2013' and '01-Apr-2013' and invoicedate <'01-Apr-2013' ");
                  sQueryStringMaster.Append("  and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2)  ");
                  sQueryStringMaster.Append("  group by  CustomerCode,invoicedate  ");
                  sQueryStringMaster.Append("  union all     ");
                  sQueryStringMaster.Append("  select CustomerCode,month(invoicedate)as MonthNO, 0 as crAmount,sum(invoiceamount) as drAmount ");
                  sQueryStringMaster.Append("  from telsysdb.dbo.t_salesInvoice a, telsysdb.dbo.v_customerdetails v        ");
                  sQueryStringMaster.Append("  where invoicedate between '01-Mar-2013' and '01-Apr-2013' and invoicedate <'01-Apr-2013' ");
                  sQueryStringMaster.Append("  and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2)    ");
                  sQueryStringMaster.Append("  group by  CustomerCode,invoicedate  ");
                  sQueryStringMaster.Append("  )as p2    ");
                  sQueryStringMaster.Append("  group by CustomerCode,invoicedate ");

                  sQueryStringMaster.Append("  Union all  ");

                  sQueryStringMaster.Append("  select CustomerCode,invoicedate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount, 'BLL' as Company          ");
                  sQueryStringMaster.Append("  from      ");
                  sQueryStringMaster.Append("  (     ");
                  sQueryStringMaster.Append("  select CustomerCode,invoicedate,sum(invoiceamount) as crAmount, 0 as drAmount ");
                  sQueryStringMaster.Append("  from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v    ");
                  sQueryStringMaster.Append("  where invoicedate between '01-Mar-2013' and '01-Apr-2013' and invoicedate <'01-Apr-2013' ");
                  sQueryStringMaster.Append("  and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2)  ");
                  sQueryStringMaster.Append("  group by  CustomerCode,invoicedate  ");
                  sQueryStringMaster.Append(" union all      ");
                  sQueryStringMaster.Append("  select CustomerCode,month(invoicedate)as MonthNO, 0 as crAmount,sum(invoiceamount) as drAmount ");
                  sQueryStringMaster.Append("  from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v        ");
                  sQueryStringMaster.Append("  where invoicedate between '01-Mar-2013' and '01-Apr-2013' and invoicedate <'01-Apr-2013' ");
                  sQueryStringMaster.Append("  and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) ");
                  sQueryStringMaster.Append("  group by  CustomerCode,invoicedate  ");
                  sQueryStringMaster.Append("  )as p2    ");
                  sQueryStringMaster.Append("  group by CustomerCode,invoicedate ");
                  sQueryStringMaster.Append("  ) as TELBLL ");
                  sQueryStringMaster.Append("  group by  CustomerCode,invoicedate, Company ");

                  sQueryStringMaster.Append("  ) as SalesAmt ");
                  sQueryStringMaster.Append("  inner join ");
                  sQueryStringMaster.Append("  ( ");
                  sQueryStringMaster.Append("  Select CustomerCode,CustomerName,AreaID, AreaName, ChannelDescription from BLLsysdb.dbo.v_customerdetails  ");
                  sQueryStringMaster.Append("  ) as b on SalesAmt.customerCode = b.Customercode ");
                  sQueryStringMaster.Append("  ) SalesTO ");
                  sQueryStringMaster.Append("  )as SLTO ");
                  sQueryStringMaster.Append("  group by SLTO.AreaID,SLTO.AreaName ");

                  sQueryStringMaster.Append("  ) as MTD ");

                  sQueryStringMaster.Append(" left outer join ");
                  sQueryStringMaster.Append("  ( ");
                  sQueryStringMaster.Append("  select SLTO.AreaID,SLTO.AreaName, sum(SLTO.Amount)as CWAmount ");
                  sQueryStringMaster.Append("  from ");
                  sQueryStringMaster.Append("  ( ");
                  sQueryStringMaster.Append("  select SalesTO.CustomerCode,SalesTO.CustomerName, SalesTO.AreaID,SalesTO.AreaName,SalesTO.ChannelDescription, SalesTO.Invoicedate, SalesTO.Amount, SalesTO.Company ");
                  sQueryStringMaster.Append("  from ");
                  sQueryStringMaster.Append("  ( ");
                  sQueryStringMaster.Append("  select SalesAmt.CustomerCode,SalesAmt.Company, b.CustomerName, b.AreaID,b.AreaName,b.ChannelDescription, cast(convert(nvarchar(12),invoicedate,106)as Datetime) as Invoicedate, Amount ");
                  sQueryStringMaster.Append("  from ");
                  sQueryStringMaster.Append("  ( ");

                  sQueryStringMaster.Append("  select CustomerCode,invoicedate,Company, sum (Amount)as Amount     ");
                  sQueryStringMaster.Append("  from ");
                  sQueryStringMaster.Append("  (  ");

                  sQueryStringMaster.Append("  select CustomerCode,invoicedate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount, 'TEL' as Company      ");
                  sQueryStringMaster.Append("  from      ");
                  sQueryStringMaster.Append("  (    ");
                  sQueryStringMaster.Append("  select CustomerCode,invoicedate, sum(invoiceamount) as crAmount, 0 as drAmount ");
                  sQueryStringMaster.Append("  from telsysdb.dbo.t_salesInvoice a, telsysdb.dbo.v_customerdetails v    ");
                  sQueryStringMaster.Append("  where invoicedate between '23-Mar-2013' and '30-Mar-2013' and invoicedate <'30-Mar-2013' ");
                  sQueryStringMaster.Append("  and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2)  ");
                  sQueryStringMaster.Append("  group by  CustomerCode,invoicedate  ");
                  sQueryStringMaster.Append("  union all      ");
                  sQueryStringMaster.Append("  select CustomerCode,month(invoicedate)as MonthNO, 0 as crAmount,sum(invoiceamount) as drAmount ");
                  sQueryStringMaster.Append("  from telsysdb.dbo.t_salesInvoice a, telsysdb.dbo.v_customerdetails v        ");
                  sQueryStringMaster.Append("  where invoicedate between '23-Mar-2013' and '30-Mar-2013' and invoicedate <'30-Mar-2013' ");
                  sQueryStringMaster.Append("  and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2)    ");
                  sQueryStringMaster.Append("  group by  CustomerCode,invoicedate  ");
                  sQueryStringMaster.Append("  )as p2   ");
                  sQueryStringMaster.Append("  group by CustomerCode,invoicedate ");
                  sQueryStringMaster.Append("  Union all ");
                 sQueryStringMaster.Append("   select CustomerCode,invoicedate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount, 'BLL' as Company    ");     
                 sQueryStringMaster.Append("   from     ");
                 sQueryStringMaster.Append("   (    ");
                 sQueryStringMaster.Append("   select CustomerCode,invoicedate,sum(invoiceamount) as crAmount, 0 as drAmount ");
                 sQueryStringMaster.Append("   select CustomerCode,invoicedate,sum(invoiceamount) as crAmount, 0 as drAmount ");
                 sQueryStringMaster.Append("   from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v ");
                 sQueryStringMaster.Append("   select CustomerCode,invoicedate,sum(invoiceamount) as crAmount, 0 as drAmount ");
                 sQueryStringMaster.Append("   where invoicedate between '23-Mar-2013' and '30-Mar-2013' and invoicedate <'30-Mar-2013' ");
                 sQueryStringMaster.Append("   and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) "); 
                 sQueryStringMaster.Append("   select CustomerCode,invoicedate,sum(invoiceamount) as crAmount, 0 as drAmount ");
                 sQueryStringMaster.Append("   group by  CustomerCode,invoicedate ");
                 sQueryStringMaster.Append("   union all      ");
                 sQueryStringMaster.Append("   select CustomerCode,month(invoicedate)as MonthNO, 0 as crAmount,sum(invoiceamount) as drAmount ");
                 sQueryStringMaster.Append("   from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v        ");
                 sQueryStringMaster.Append("   where invoicedate between '23-Mar-2013' and '30-Mar-2013' and invoicedate <'30-Mar-2013' ");
                 sQueryStringMaster.Append("   and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) ");
                 sQueryStringMaster.Append("   group by  CustomerCode,invoicedate  ");
                 sQueryStringMaster.Append("   )as p2    ");
                 sQueryStringMaster.Append("   group by CustomerCode,invoicedate ");
                 sQueryStringMaster.Append("   ) as TELBLL ");
                 sQueryStringMaster.Append("   group by  CustomerCode,invoicedate, Company ");

                 sQueryStringMaster.Append("   ) as SalesAmt ");
                 sQueryStringMaster.Append("   inner join ");
                 sQueryStringMaster.Append("   ( ");
                 sQueryStringMaster.Append("   Select CustomerCode,CustomerName,AreaID, AreaName, ChannelDescription from BLLsysdb.dbo.v_customerdetails  ");
                 sQueryStringMaster.Append("   ) as b on SalesAmt.customerCode = b.Customercode ");
                 sQueryStringMaster.Append("   ) SalesTO ");
                 sQueryStringMaster.Append("   )as SLTO ");
                 sQueryStringMaster.Append("   group by SLTO.AreaID,SLTO.AreaName ");
                 sQueryStringMaster.Append("   ) as WTD on MTD.AreaID=WTD.AreaID ");
                 sQueryStringMaster.Append("  )as Sales on TGT.AreaID=Sales.AreaID ");

            
            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();


            //oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));
            //oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));

            //oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));

            //oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));

            //oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));
            //oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));

            //oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));

            //oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));
            //oCmd.Parameters.AddWithValue("CustomerCode", (string)sCustomerCode);



            //oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));
            //oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));


            //oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));

            //oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));
            //oCmd.Parameters.AddWithValue("CustomerCode", (string)sCustomerCode);

            //oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));
            //oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));

            //oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));

            //oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));
            //oCmd.Parameters.AddWithValue("CustomerCode", (string)sCustomerCode);


           // GetDataCustomerTranTELNBLL(oCmd);

        }
    
    
    }
}

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using CJ.Class;
using CJ.Class.ANDROID;

public partial class jBLLRoutewiseSalesTran : System.Web.UI.Page
{
    ReportDocument rptFile;

    protected void Page_Load(object sender, EventArgs e)
    {

        //if (!IsPostBack)
        //{

        string sCustomerID = Request.QueryString.Get("CustID");
        string sCompany = Request.QueryString.Get("Company");
        string sUser = Request.QueryString.Get("UserName");
        string sReqType = Request.QueryString.Get("ReqType");
        string sCompanyFullName = "Bangladesh Lamps Limited";


        //   string sCustomerID ="140";                

            try
            {
                rptFile = new ReportDocument();
                rptFile.Load(Server.MapPath("Report/rptBLLRouteWiseSales.rpt"));
                
                DBController.Instance.OpenNewConnection();
                DSBLLRouteWiseSales oDSBLLRouteWiseSales = GetDatsetRoute(sCustomerID);
              //  DSBLLRouteWiseSales oDSBLLRouteWiseSales = GetDatRouteLM(sCustomerID);
               

                DBController.Instance.CloseConnection();                
                rptFile.SetDataSource(oDSBLLRouteWiseSales);         
                              
                
                 CRViewer.DisplayToolbar = true;
                 CRViewer.ReportSource = rptFile;        
                          
               
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
                
            }
        //}

    }


    private DSBLLRouteWiseSales GetDatRouteLM(string sDBID)
    {
        DSBLLRouteWiseSales oDSBLLRouteWiseSales = new DSBLLRouteWiseSales();
        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSQL = "";

        sSQL = " select RoutePro.DistributorID,CustomerCode,CustomerName,RoutePro.RouteID,RouteName, DayID,  RouteType, DeliveryDay, OrderType, " +
                  " isnull(MTDTO,0)as MTDTO,isnull(LMTO,0)as LMTO, isnull(BalTO,0)as BalTO, isnull(TGTTO,0)As TGTTO,     " +
                  " isnull(LMTGLS,0)as LMTGLS, isnull(MTDTGLS,0)as MTDTGLS, isnull(LMPGLS,0)as LMPGLS, isnull(MTDPGLS,0)As MTDPGLS, isnull(LMCFL,0)as LMCFL, " +
                  "  isnull(MTDCFL,0)as MTDCFL,isnull(LMTL,0)as LMTL, isnull(MTDTL,0)as MTDTL, isnull(TGTTGLS,0)As TGTTGLS, isnull(TGTPGLS,0)as TGTPGLS, isnull(TGTCFL,0)as TGTCFL,isnull(TGTTL,0)as TGTTL, " +
                  "  isnull(PGLSQty,0)as PGLSQty, isnull(PGLSVal,0)as PGLSVal, isnull(TGLSQty,0)as TGLSQty,isnull(TGLSVal,0)as TGLSVal,isnull(CFLQty,0)as CFLQty, " +
                  "  isnull(CFLVal,0)as CFLVal, isnull(TLQty,0)as TLQty, isnull(TLVal,0)as TLVal, isnull(STKVal,0)as STKVal, isnull(VisitPlan,0)as VisitPlan,isnull(Visited,0)as Visited " +
                  " from  " +
                  " (  " +
                  "  select Q3.DistributorID,CustomerCode,CustomerName,Q3.RouteID,RouteName,Q3.DayID, VisitPlan,Visitfrequency,DayName, isnull(Visited,0)as Visited, RouteType, DeliveryDay, OrderType      " +
                  " from   " +
                  " ( " +
                  "  select p1.DistributorID,CustomerCode,CustomerName, p1.RouteID, RouteName,DayID,Visitfrequency,DayName,  VisitPlan, RouteType,  DeliveryDay,OrderType   " +
                  "  from " +
                  " ( " +
                  " select a.DistributorID, a.RouteID,RouteName,isnull(a.DayID,0)as DayID,Visitfrequency,DayName, totalDelivery as VisitPlan, RouteType,  isnull(deliveryDay,'NA')as  DeliveryDay,isnull(OrderType,'NA')As OrderType   " +
                  " from BLLSysDB.dbo.t_DMSRoute a,BLLSysDB.dbo.t_DMSDeliverySchedule b   " +
                  " where   a.DayID=b.DayID and TranMonth=DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and DistributorID= '" + sDBID + "' " +
                  " )as P1 " +
                  " inner join   " +
                  " BLLSysDB.dbo.t_Customer as Cust on P1.DistributorID=Cust.CustomerID     " +

                 "  )as Q3  " +
                 "  left outer join  " +
                 "  (  " +
                 "  select a.DistributorID, c.RouteID, count(Trandate)as Visited  " +
                 "  from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSOutlet b , BLLSysDB.dbo.t_DMSRoute c   " +
                 "  where TranTypeID=2 and TranDate between   DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and  DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0))   " +
                 "  and a.DistributorID= '" + sDBID + "' and a.OutletID=b.OutletID  and b.RouteID=c.RouteID     " +
                 "  group by a.DistributorID, c.RouteID,Visitfrequency,DayID    " +
                 "  )As Q4 on Q3.RouteID=Q4.RouteID " +
                 "   ) as RoutePro " +
                 "   left outer join " +
                 "  ( " +
                 "   select SaTO.DistributorID, SaTO.RouteID,MTDTO, LMTO,BalTO,TGTTO,     " +
                 "   LMTGLS,MTDTGLS,LMPGLS,MTDPGLS,LMCFL,MTDCFL,LMTL,MTDTL,isnull(TGTTGLS,0)As TGTTGLS, isnull(TGTPGLS,0)as TGTPGLS, isnull(TGTCFL,0)as TGTCFL,isnull(TGTTL,0)as TGTTL, " +
                 "    PGLSQty,PGLSVal,TGLSQty,TGLSVal,CFLQty,CFLVal,TLQty,TLVal,STKVal      " +
                 "   from     " +
                 "   (   " +
                 "   select SaTO.DistributorID, SaTO.RouteID,  isnull(MTDTO,0)as MTDTO, isnull(LMTO,0)as LMTO, " +
                 "   isnull(BalTO,0)as BalTO, isnull(TGTTO,0)as TGTTO,isnull(LMTGLS,0)as LMTGLS,isnull(MTDTGLS,0)as MTDTGLS, isnull(LMPGLS,0)as LMPGLS,isnull(MTDPGLS,0)as MTDPGLS, isnull(LMCFL,0)as LMCFL, isnull(MTDCFL,0)as MTDCFL,isnull(LMTL,0)as LMTL,isnull(MTDTL,0)as MTDTL    " +
                 "   from     " +
                 "   (  " +
            //   ---------------Start of Main Query-------------------   

                " select STO.DistributorID, STO.RouteID,  MTDTO, LMTO,BalTO, TGTTO      " +
                "    from     " +
                "    (       " +
                "    select DistributorID,RouteID, sum(isnull(MTDTO,0)) as MTDTO,sum(isnull(LMTO,0)) as LMTO,sum(LMTO-MTDTO)as BalTO, sum(isnull(TGTTO,0))as TGTTO      " +
                "   from     " +
                "    (      " +
                "    select a.DistributorID, RouteID, sum(NetAmount) as MTDTO,0 as LMTO, 0 as TGTTO      " +
                "    from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSOutlet b     " +
                "    where TranTypeID=2 and TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0))     " +
                "    and a.DistributorID= '" + sDBID + "'  and a.OutletID=b.OutletID    " +
                "    group by a.DistributorID, RouteID     " +
                "    union all     " +
                "    select a.DistributorID, RouteID, 0 as MTDTO, sum(NetAmount) as LMTO, 0 as TGTTO   " +
                "    from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSOutlet b   " +
                "    where TranTypeID=2 and TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(DAY, -(DAY(GETDATE())), GETDATE())    " +
                "    and a.DistributorID= '" + sDBID + "' and a.OutletID=b.OutletID  " +
                "    group by a.DistributorID, RouteID  " +
                "    union all     " +
                "    select DistributorID, RouteID,0 as MTDTO,0 as LMTO, sum(TSOTargetTO) as TGTTO   " +
                "    from BLLSysDB.dbo.t_DMSTargetTO    " +
                "    where TGTDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0))  " +
                "    and DistributorID= '" + sDBID + "'     " +
                "    group by DistributorID, RouteID     " +
                "    )As SlsTGT   " +
                "    group by DistributorID,RouteID   " +
                "    )As STO    " +

               //     --------------End of Main Query-------------------  

                "    )As SaTO " +
                "    left outer join " +
                "    (	 " +

               //    ---------------Start of Sales Qty-------------------  

               "     select isnull(Q1.DistributorID,Q2.DistributorID)as DistributorID,isnull(Q1.RouteID,Q2.RouteID)as RouteID,    " +
               "     isnull(MTDTGLS,0)as MTDTGLS,isnull(LMTGLS,0)as LMTGLS, isnull(MTDPGLS,0)as MTDPGLS, isnull(LMPGLS,0)As LMPGLS,isnull(MTDCFL,0)As MTDCFL,isnull(LMCFL,0)As LMCFL, isnull(MTDTL,0)As MTDTL,isnull(LMTL,0)as LMTL    " +
               "     from   " +
               "     (  " +
               "     select DistributorID,RouteID,     " +
               "     sum(case ASGID when 125 then (case BrandID when 4 then MTDQty  else 0 end)  else 0 end ) as MTDTGLS,     " +
               "     sum(case ASGID when 125 then (case BrandID when 1 then MTDQty  else 0 end)  else 0 end ) as MTDPGLS,    " +
               "     sum(case ASGID when 126 then (case BrandID when 4 then MTDQty  else 0 end)  else 0 end ) as MTDCFL,     " +
               "     sum(case ASGID when 127 then (case BrandID when 4 then MTDQty  else 0 end)  else 0 end ) as MTDTL      " +
               "     from  " +
               "     (   " +
               "     select a.DistributorID,a.OutletID,d.RouteID,ASGID,BrandID,ASGName,BrandDesc, sum(Qty)as MTDQty   " +
               "     from BLLSysDB.dbo.t_DMSProductTran a,BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c ,BLLSysDB.dbo.t_DMSOutlet d   " +
               "     where TranTypeID=2 and TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0))   " +
               "     and a.DistributorID= '" + sDBID + "' and a.TranID=b.TranID and b.ProductID=c.ProductID  and a.OutletID=d.OutletID  " +
               "     group by a.DistributorID,a.OutletID,d.RouteID,ASGID,BrandID,ASGName,BrandDesc   " +
               "     )MTD   " +
               "      group by DistributorID,RouteID    " +
               "     )As Q1   " +
               "     full outer join   " +
               "     (   " +
               "     select DistributorID,RouteID,    " +
               "     sum(case ASGID when 125 then (case BrandID when 4 then LMQty  else 0 end)  else 0 end ) as LMTGLS,   " +
               "     sum(case ASGID when 125 then (case BrandID when 1 then LMQty  else 0 end)  else 0 end ) as LMPGLS,   " +
               "     sum(case ASGID when 126 then (case BrandID when 4 then LMQty  else 0 end)  else 0 end ) as LMCFL,   " +
               "     sum(case ASGID when 127 then (case BrandID when 4 then LMQty  else 0 end)  else 0 end ) as LMTL   " +
               "     from  " +
               "     (  " +
               "     select a.DistributorID,a.OutletID,d.RouteID,ASGID,BrandID,ASGName,BrandDesc, sum(Qty)as LMQty    " +
               "     from BLLSysDB.dbo.t_DMSProductTran a,BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c , BLLSysDB.dbo.t_DMSOutlet d    " +
               "     where TranTypeID=2 and TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(DAY, -(DAY(GETDATE())), GETDATE())  " +
               "     and a.DistributorID='" + sDBID + "' and a.TranID=b.TranID and b.ProductID=c.ProductID  and  a.OutletID=d.OutletID   " +
               "     group by a.DistributorID,a.OutletID,d.RouteID,ASGID,BrandID,ASGName,BrandDesc  " +
               "     )MTD   " +
               "     group by DistributorID,RouteID   " +
               "     )as Q2 on Q1.DistributorID=Q2.DistributorID and Q1.RouteID=Q2.RouteID " +

               //     ---------------------- End of Sales Qty------------------- 
               "     )as ASGQty on SaTO.DistributorID=ASGQty.DistributorID and SaTO.RouteID=ASGQty.RouteID   " +

               "  )as SaTO " +

               "      left outer join    " +
               "     (     " +
               "     select DistributorID,RouteID,     " +
               "     sum(case ASGID when 125 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTTGLS,   " +
               "     sum(case ASGID when 125 then (case BrandID when 1 then TGTQty  else 0 end)  else 0 end ) as TGTPGLS,   " +
               "     sum(case ASGID when 126 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTCFL,   " +
               "     sum(case ASGID when 127 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTTL   " +
               "     from   " +
               "     (    " +
               "     select a.DistributorID,a.RouteID,ASGID,BrandID,sum(TSOTGTQty)as TGTQty   " +
               "     from BLLSysDB.dbo.t_DMSASGTarget a, t_DMSRoute b     " +
               "     where TargetDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0)) " +
            // Isactive 
               "     and a.RouteID=b.RouteID   and a.DistributorID= '" + sDBID + "'  " +
               "    group by a.DistributorID,a.RouteID,ASGID,BrandID    " +
               "     )as Q1    " +
               "     where RouteID<>0 and DistributorID= '" + sDBID + "'  " +
               "     group by DistributorID,RouteID     " +
               "     )as TGTQty on SaTO.RouteID=TGTQty.RouteID	 " +

               "	inner join   " +
               "     ( " +
               "     select DistributorID,   " +
               "     sum(case ASGID when 125 then (case BrandID when 1 then CrStock  else 0 end)  else 0 end ) as PGLSQty,	 " +
               "     sum(case ASGID when 125 then (case BrandID when 1 then STKVal  else 0 end)  else 0 end ) as PGLSVal,  " +

               "     sum(case ASGID when 125 then (case BrandID when 4 then CrStock  else 0 end)  else 0 end ) as TGLSQty, " +
               "     sum(case ASGID when 125 then (case BrandID when 4 then STKVal  else 0 end)  else 0 end ) as TGLSVal, " +

               "     sum(case ASGID when 126 then (case BrandID when 4 then CrStock  else 0 end)  else 0 end ) as CFLQty,	" +
               "     sum(case ASGID when 126 then (case BrandID when 4 then STKVal  else 0 end)  else 0 end ) as CFLVal, " +

               "     sum(case ASGID when 127 then (case BrandID when 4 then CrStock  else 0 end)  else 0 end ) as TLQty, " +
               "     sum(case ASGID when 127 then (case BrandID when 4 then STKVal  else 0 end)  else 0 end ) as TLVal, " +
               "     sum(STKVal)as STKVal " +

               "     from  " +
               "    (  " +
               "    select DistributorID, ASGID,BrandID,ASGName,BrandDesc, sum(CurrentStock)as CrStock, round(sum(STKVal),0)as STKVal " +
               "    from  " +
               "    (  " +
               "    select DistributorID,a.productID,ASGID,ASGName,BrandID, BrandDesc, CurrentStock, NSP, (NSP*CurrentStock*.95)as STKVal       " +
               "    from BLLSysDB.dbo.t_DMSProductStock a, BLLSysDB.dbo.V_ProductDetails b  " +
               "    where a.ProductID=b.ProductID and DistributorID= '" + sDBID + "'   " +
               "    and CurrentStock>0   " +
               "    )As ASGStock   " +
               "    group by DistributorID,ASGID,BrandID,ASGName,BrandDesc   " +
               "    )As Stk  " +
               "    group by DistributorID	 " +
               "   )As StkVal on SaTO.DistributorID=StkVal.DistributorID 	" +
               "    )as SalnTGt on   RoutePro.RouteID=SalnTGt.RouteID " +
               "    order by RoutePro.DayID    ";    
  



        try
        {

            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DSBLLRouteWiseSales.RouteSalesRow oRouteSalesRow = oDSBLLRouteWiseSales.RouteSales.NewRouteSalesRow();

               // oRouteSalesRow.DistributorID = Convert.ToInt32(reader["DistributorID"]);
               // oRouteSalesRow.CustomerCode = reader["CustomerCode"].ToString();
               // oRouteSalesRow.CustomerName = reader["CustomerName"].ToString();
               // oRouteSalesRow.RouteID = Convert.ToInt32(reader["RouteID"]);
               // oRouteSalesRow.RouteName = reader["RouteName"].ToString();
               // oRouteSalesRow.RouteType = reader["RouteType"].ToString();
               // oRouteSalesRow.DayID = Convert.ToInt32(reader["DayID"]);
               // oRouteSalesRow.DeliveryDay = reader["DeliveryDay"].ToString();
               // oRouteSalesRow.OrderType = reader["OrderType"].ToString();

               // oRouteSalesRow.MTDTO = Convert.ToDouble(reader["MTDTO"]);
               // oRouteSalesRow.LMTO = Convert.ToDouble(reader["LMTO"]);
               // oRouteSalesRow.BalTO = Convert.ToDouble(reader["BalTO"]);
               // oRouteSalesRow.TGTTO = Convert.ToDouble(reader["TGTTO"]);

               // oRouteSalesRow.LMTGLS = Convert.ToDouble(reader["LMTGLS"]);
               // oRouteSalesRow.TGTTGLS = Convert.ToInt32(reader["TGTTGLS"]);
               // oRouteSalesRow.MTDTGLS = Convert.ToDouble(reader["MTDTGLS"]);

               // oRouteSalesRow.LMPGLS = Convert.ToDouble(reader["LMPGLS"]);
               // oRouteSalesRow.TGTPGLS = Convert.ToDouble(reader["TGTPGLS"]);
               // oRouteSalesRow.MTDPGLS = Convert.ToDouble(reader["MTDPGLS"]);

               // oRouteSalesRow.LMCFL = Convert.ToDouble(reader["LMCFL"]);
               // oRouteSalesRow.TGTCFL = Convert.ToDouble(reader["TGTCFL"]);
               // oRouteSalesRow.MTDCFL = Convert.ToDouble(reader["MTDCFL"]);

               // oRouteSalesRow.LMTL = Convert.ToDouble(reader["LMTL"]);
               // oRouteSalesRow.TGTTL = Convert.ToDouble(reader["TGTTL"]);
               // oRouteSalesRow.MTDTL = Convert.ToDouble(reader["MTDTL"]);
               // oRouteSalesRow.STKVal = Convert.ToDouble(reader["STKVal"]);
               //// oRouteSalesRow.Visit = Convert.ToInt16(reader["Visit"]);
               // oRouteSalesRow.VisitPlan = Convert.ToInt16(reader["VisitPlan"]);
               // oRouteSalesRow.Visited = Convert.ToInt16(reader["Visited"]);
                
                
               // oRouteSalesRow.PGLSQty = Convert.ToInt32(reader["PGLSQty"]);
               // oRouteSalesRow.PGLSVal = Convert.ToDouble(reader["PGLSVal"]);

               // oRouteSalesRow.TGLSQty = Convert.ToInt32(reader["TGLSQty"]);
               // oRouteSalesRow.TGLSVal = Convert.ToDouble(reader["TGLSVal"]);

               // oRouteSalesRow.CFLQty = Convert.ToInt32(reader["CFLQty"]);
               // oRouteSalesRow.CFLVal = Convert.ToDouble(reader["CFLVal"]);

               // oRouteSalesRow.TLQty = Convert.ToInt32(reader["TLQty"]);
               // oRouteSalesRow.TLVal = Convert.ToDouble(reader["TLVal"]);



                oRouteSalesRow.DistributorID = Convert.ToInt32(reader["DistributorID"]);
                oRouteSalesRow.CustomerCode = reader["CustomerCode"].ToString();
                oRouteSalesRow.CustomerName = reader["CustomerName"].ToString();
                oRouteSalesRow.RouteID = Convert.ToInt32(reader["RouteID"]);
                oRouteSalesRow.RouteName = reader["RouteName"].ToString();
                oRouteSalesRow.RouteType = reader["RouteType"].ToString();
                oRouteSalesRow.DayID = Convert.ToInt32(reader["DayID"]);
                oRouteSalesRow.DeliveryDay = reader["DeliveryDay"].ToString();
                oRouteSalesRow.OrderType = reader["OrderType"].ToString();

                oRouteSalesRow.MTDTO = Convert.ToDouble(reader["MTDTO"]);
                oRouteSalesRow.LMTO = Convert.ToDouble(reader["LMTO"]);
                oRouteSalesRow.BalTO = Convert.ToDouble(reader["BalTO"]);
                oRouteSalesRow.TGTTO = Convert.ToDouble(reader["TGTTO"]);

                oRouteSalesRow.LMTGLS = Convert.ToDouble(reader["LMTGLS"]);
                //oRouteSalesRow.TGTTGLS = Convert.ToDouble(reader["TGTTGLS"]); 
                oRouteSalesRow.TGTTGLS = Convert.ToInt32(reader["TGTTGLS"]);
                oRouteSalesRow.MTDTGLS = Convert.ToDouble(reader["MTDTGLS"]);

                oRouteSalesRow.LMPGLS = Convert.ToDouble(reader["LMPGLS"]);
                oRouteSalesRow.TGTPGLS = Convert.ToInt32(reader["TGTPGLS"]);
                oRouteSalesRow.MTDPGLS = Convert.ToDouble(reader["MTDPGLS"]);

                oRouteSalesRow.LMCFL = Convert.ToDouble(reader["LMCFL"]);
                oRouteSalesRow.TGTCFL = Convert.ToInt32(reader["TGTCFL"]);
                oRouteSalesRow.MTDCFL = Convert.ToDouble(reader["MTDCFL"]);

                oRouteSalesRow.LMTL = Convert.ToDouble(reader["LMTL"]);
                oRouteSalesRow.TGTTL = Convert.ToInt32(reader["TGTTL"]);
                oRouteSalesRow.MTDTL = Convert.ToDouble(reader["MTDTL"]);
                oRouteSalesRow.STKVal = Convert.ToDouble(reader["STKVal"]);
                //  oRouteSalesRow.Visit = Convert.ToInt16(reader["Visit"]);                
                oRouteSalesRow.VisitPlan = Convert.ToInt16(reader["VisitPlan"]);
                oRouteSalesRow.Visited = Convert.ToInt16(reader["Visited"]);

                oRouteSalesRow.PGLSQty = Convert.ToInt32(reader["PGLSQty"]);
                oRouteSalesRow.PGLSVal = Convert.ToDouble(reader["PGLSVal"]);

                oRouteSalesRow.TGLSQty = Convert.ToInt32(reader["TGLSQty"]);
                oRouteSalesRow.TGLSVal = Convert.ToDouble(reader["TGLSVal"]);

                oRouteSalesRow.CFLQty = Convert.ToInt32(reader["CFLQty"]);
                oRouteSalesRow.CFLVal = Convert.ToDouble(reader["CFLVal"]);

                oRouteSalesRow.TLQty = Convert.ToInt32(reader["TLQty"]);
                oRouteSalesRow.TLVal = Convert.ToDouble(reader["TLVal"]);




                oDSBLLRouteWiseSales.RouteSales.AddRouteSalesRow(oRouteSalesRow);

            }
            oDSBLLRouteWiseSales.AcceptChanges();

            return oDSBLLRouteWiseSales;
        }

        catch (Exception ex)
        {
            throw (ex);
        }

    }

    private DSBLLRouteWiseSales GetDatsetRoute(string sDBID)
    {
        DSBLLRouteWiseSales oDSBLLRouteWiseSales = new DSBLLRouteWiseSales();
        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSQL = "";

      
        sSQL = " select Final.DistributorID,CustomerCode,CustomerName,Final.RouteID,RouteName, DayID,  RouteType, DeliveryDay, OrderType, "+
                     " (MTDTO) as MTDTO,(LMTO )as LMTO,  BalTO,  TGTTO, LMTGLS, MTDTGLS,  LMPGLS, MTDPGLS,  LMCFL, MTDCFL, LMTL, MTDTL,  TGTTGLS, TGTPGLS, TGTCFL, TGTTL , " +
                     " PGLSQty, (PGLSVal)as PGLSVal, TGLSQty, (TGLSVal)as TGLSVal,CFLQty, (CFLVal)as CFLVal, TLQty, (TLVal) as TLVal, STKVal, VisitPlan, Visited " +
                     " from "+
                     " (       " +  
                     " select RoutePro.DistributorID,CustomerCode,CustomerName,RoutePro.RouteID,RouteName, DayID,  RouteType, DeliveryDay, OrderType, " +
                     " isnull(MTDTO,0)as MTDTO,isnull(LMTO,0)as LMTO, isnull(BalTO,0)as BalTO, isnull(TGTTO,0)As TGTTO,     " +
                     " isnull(LMTGLS,0)as LMTGLS, isnull(MTDTGLS,0)as MTDTGLS, isnull(LMPGLS,0)as LMPGLS, isnull(MTDPGLS,0)As MTDPGLS, isnull(LMCFL,0)as LMCFL, " +
                     " isnull(MTDCFL,0)as MTDCFL,isnull(LMTL,0)as LMTL, isnull(MTDTL,0)as MTDTL, isnull(TGTTGLS,0)as TGTTGLS, isnull(TGTPGLS,0)as TGTPGLS, isnull(TGTCFL,0)as TGTCFL,isnull(TGTTL,0)as TGTTL , " +
                     " isnull(PGLSQty,0)as PGLSQty, isnull(PGLSVal,0)as PGLSVal, isnull(TGLSQty,0)as TGLSQty,isnull(TGLSVal,0)as TGLSVal,isnull(CFLQty,0)as CFLQty , " +
                     " isnull(CFLVal,0)as CFLVal, isnull(TLQty,0)as TLQty, isnull(TLVal,0)as TLVal, isnull(STKVal,0)as STKVal, isnull(VisitPlan,0)as VisitPlan,isnull(Visited,0)as Visited " +
                     " from  " +
                     " (  " +
                     "  select Q3.DistributorID,CustomerCode,CustomerName,Q3.RouteID,RouteName,Q3.DayID, VisitPlan,Visitfrequency,DayName, isnull(Visited,0)as Visited, RouteType, DeliveryDay, OrderType      " +
                     " from   " +
                     " ( " +
                     "  select p1.DistributorID,CustomerCode,CustomerName, p1.RouteID, RouteName,DayID,Visitfrequency,DayName,  VisitPlan, RouteType,  DeliveryDay,OrderType   " +
                     "  from " +
                     " ( " +
                     " select a.DistributorID, a.RouteID,RouteName,isnull(a.DayID,0)as DayID,Visitfrequency,DayName, totalDelivery as VisitPlan, RouteType,  isnull(deliveryDay,'NA')as  DeliveryDay,isnull(OrderType,'NA')As OrderType   " +
                     " from BLLSysDB.dbo.t_DMSRoute a,BLLSysDB.dbo.t_DMSDeliverySchedule b   " +
                     " where   a.DayID=b.DayID and TranMonth=DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and DistributorID= '" + sDBID + "' " +
                     " )as P1 " +
                     " inner join   " +
                     " BLLSysDB.dbo.t_Customer as Cust on P1.DistributorID=Cust.CustomerID     " +

                    "  )as Q3  " +
                    "  left outer join  " +
                    "  (  " +
                    "  select a.DistributorID, c.RouteID, count(Trandate)as Visited  " +
                    "  from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSOutlet b , BLLSysDB.dbo.t_DMSRoute c   " +
                    "  where TranTypeID=2 and TranDate between   DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and  DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0))   " +
                    "  and a.DistributorID= '" + sDBID + "' and a.OutletID=b.OutletID  and b.RouteID=c.RouteID     " +
                    "  group by a.DistributorID, c.RouteID,Visitfrequency,DayID    " +
                    "  )As Q4 on Q3.RouteID=Q4.RouteID " +
                    "   ) as RoutePro " +
                    "   left outer join " +
                    "  ( " +
                    "   select SaTO.DistributorID, SaTO.RouteID,MTDTO, LMTO,BalTO,TGTTO,     " +
                    "   LMTGLS,MTDTGLS,LMPGLS,MTDPGLS,LMCFL,MTDCFL,LMTL,MTDTL,isnull(TGTTGLS,0)As TGTTGLS, isnull(TGTPGLS,0)as TGTPGLS, isnull(TGTCFL,0)as TGTCFL,isnull(TGTTL,0)as TGTTL, " +
                    "   PGLSQty,PGLSVal,TGLSQty,TGLSVal,CFLQty,CFLVal,TLQty,TLVal,STKVal      " +
                    "   from     " +
                    "   (   " +
                    "   select SaTO.DistributorID, SaTO.RouteID,  isnull(MTDTO,0)as MTDTO, isnull(LMTO,0)as LMTO, " +
                    "   isnull(BalTO,0)as BalTO, isnull(TGTTO,0)as TGTTO,isnull(LMTGLS,0)as LMTGLS,isnull(MTDTGLS,0)as MTDTGLS, isnull(LMPGLS,0)as LMPGLS,isnull(MTDPGLS,0)as MTDPGLS, isnull(LMCFL,0)as LMCFL, isnull(MTDCFL,0)as MTDCFL,isnull(LMTL,0)as LMTL,isnull(MTDTL,0)as MTDTL    " +
                    "   from     " +
                    "   (  " +
                 //   ---------------Start of Main Query-------------------   

                   " select STO.DistributorID, STO.RouteID,  MTDTO, LMTO,BalTO, TGTTO      " +
                   "    from     " +
                   "    (       " +
                   "    select DistributorID,RouteID, sum(isnull(MTDTO,0)) as MTDTO,sum(isnull(LMTO,0)) as LMTO,sum(LMTO-MTDTO)as BalTO, sum(isnull(TGTTO,0))as TGTTO      " +
                   "   from     " +
                   "    (      " +
                   "    select a.DistributorID, RouteID, sum(NetAmount) as MTDTO,0 as LMTO, 0 as TGTTO      " +
                   "    from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSOutlet b     " +
                   "    where TranTypeID=2 and TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0))     " +
                   "    and a.DistributorID= '" + sDBID + "'  and a.OutletID=b.OutletID    " +
                   "    group by a.DistributorID, RouteID     " +
                   "    union all     " +
                   "    select a.DistributorID, RouteID, 0 as MTDTO, sum(NetAmount) as LMTO, 0 as TGTTO   " +
                   "    from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSOutlet b   " +
                   "    where TranTypeID=2 and TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(DAY, -(DAY(GETDATE())), GETDATE())    " +
                   "    and a.DistributorID= '" + sDBID + "' and a.OutletID=b.OutletID  " +
                   "    group by a.DistributorID, RouteID  " +
                   "    union all     " +
                   "    select DistributorID, RouteID,0 as MTDTO,0 as LMTO, sum(TSOTargetTO) as TGTTO   " +
                   "    from BLLSysDB.dbo.t_DMSTargetTO    " +
                   "    where TGTDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0))  " +
                   "    and DistributorID= '" + sDBID + "'     " +
                   "    group by DistributorID, RouteID     " +
                   "    )As SlsTGT   " +
                   "    group by DistributorID,RouteID   " +
                   "    )As STO    " +

                  //     --------------End of Main Query-------------------  

                   "    )As SaTO " +
                   "    left outer join " +
                   "    (	 " +

                  //    ---------------Start of Sales Qty-------------------  

                  "     select isnull(Q1.DistributorID,Q2.DistributorID)as DistributorID,isnull(Q1.RouteID,Q2.RouteID)as RouteID,    " +
                  "     isnull(MTDTGLS,0)as MTDTGLS,isnull(LMTGLS,0)as LMTGLS, isnull(MTDPGLS,0)as MTDPGLS, isnull(LMPGLS,0)As LMPGLS,isnull(MTDCFL,0)As MTDCFL,isnull(LMCFL,0)As LMCFL, isnull(MTDTL,0)As MTDTL,isnull(LMTL,0)as LMTL    " +
                  "     from   " +
                  "     (  " +
                  "     select DistributorID,RouteID,     " +
                  "     sum(case ASGID when 125 then (case BrandID when 4 then MTDQty  else 0 end)  else 0 end ) as MTDTGLS,     " +
                  "     sum(case ASGID when 125 then (case BrandID when 1 then MTDQty  else 0 end)  else 0 end ) as MTDPGLS,    " +
                  "     sum(case ASGID when 126 then (case BrandID when 4 then MTDQty  else 0 end)  else 0 end ) as MTDCFL,     " +
                  "     sum(case ASGID when 127 then (case BrandID when 4 then MTDQty  else 0 end)  else 0 end ) as MTDTL      " +
                  "     from  " +
                  "     (   " +
                  "     select a.DistributorID,a.OutletID,d.RouteID,ASGID,BrandID,ASGName,BrandDesc, sum(Qty)as MTDQty   " +
                  "     from BLLSysDB.dbo.t_DMSProductTran a,BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c ,BLLSysDB.dbo.t_DMSOutlet d   " +
                  "     where TranTypeID=2 and TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0))   " +
                  "     and a.DistributorID= '" + sDBID + "' and a.TranID=b.TranID and b.ProductID=c.ProductID  and a.OutletID=d.OutletID  " +
                  "     group by a.DistributorID,a.OutletID,d.RouteID,ASGID,BrandID,ASGName,BrandDesc   " +
                  "     )MTD   " +
                  "      group by DistributorID,RouteID    " +
                  "     )As Q1   " +
                  "     full outer join   " +
                  "     (   " +
                  "     select DistributorID,RouteID,    " +
                  "     sum(case ASGID when 125 then (case BrandID when 4 then LMQty  else 0 end)  else 0 end ) as LMTGLS,   " +
                  "     sum(case ASGID when 125 then (case BrandID when 1 then LMQty  else 0 end)  else 0 end ) as LMPGLS,   " +
                  "     sum(case ASGID when 126 then (case BrandID when 4 then LMQty  else 0 end)  else 0 end ) as LMCFL,   " +
                  "     sum(case ASGID when 127 then (case BrandID when 4 then LMQty  else 0 end)  else 0 end ) as LMTL   " +
                  "     from  " +
                  "     (  " +
                  "     select a.DistributorID,a.OutletID,d.RouteID,ASGID,BrandID,ASGName,BrandDesc, sum(Qty)as LMQty    " +
                  "     from BLLSysDB.dbo.t_DMSProductTran a,BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c , BLLSysDB.dbo.t_DMSOutlet d    " +
                  "     where TranTypeID=2 and TranDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(DAY, -(DAY(GETDATE())), GETDATE())  " +
                  "     and a.DistributorID='" + sDBID + "' and a.TranID=b.TranID and b.ProductID=c.ProductID  and  a.OutletID=d.OutletID   " +
                  "     group by a.DistributorID,a.OutletID,d.RouteID,ASGID,BrandID,ASGName,BrandDesc  " +
                  "     )MTD   " +
                  "     group by DistributorID,RouteID   " +
                  "     )as Q2 on Q1.DistributorID=Q2.DistributorID and Q1.RouteID=Q2.RouteID " +

                  //     ---------------------- End of Sales Qty------------------- 
                  "     )as ASGQty on SaTO.DistributorID=ASGQty.DistributorID and SaTO.RouteID=ASGQty.RouteID   " +

                  "  )as SaTO " +

                  "      left outer join    " +
                  "     (     " +
                  "     select DistributorID,RouteID,     " +
                  "     sum(case ASGID when 125 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTTGLS,   " +
                  "     sum(case ASGID when 125 then (case BrandID when 1 then TGTQty  else 0 end)  else 0 end ) as TGTPGLS,   " +
                  "     sum(case ASGID when 126 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTCFL,   " +
                  "     sum(case ASGID when 127 then (case BrandID when 4 then TGTQty  else 0 end)  else 0 end ) as TGTTL   " +
                  "     from   " +
                  "     (    " +
                  "     select a.DistributorID,a.RouteID,ASGID,BrandID,sum(TSOTGTQty)as TGTQty   " +
                  "     from BLLSysDB.dbo.t_DMSASGTarget a, BLLSysDB.dbo.t_DMSRoute b     " +
                  "     where TargetDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and DATEADD (dd, -1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) +1, 0)) " +
            // Isactive 
                  "     and a.RouteID=b.RouteID   and a.DistributorID= '" + sDBID + "'  " +
                  "    group by a.DistributorID,a.RouteID,ASGID,BrandID    " +
                  "     )as Q1    " +
                  "     where RouteID<>0 and DistributorID= '" + sDBID + "'  " +
                  "     group by DistributorID,RouteID     " +
                  "     )as TGTQty on SaTO.RouteID=TGTQty.RouteID	 " +

                  "	inner join   " +
                  "     ( " +
                  "     select DistributorID,   " +
                  "     sum(case ASGID when 125 then (case BrandID when 1 then CrStock  else 0 end)  else 0 end ) as PGLSQty,	 " +
                  "     sum(case ASGID when 125 then (case BrandID when 1 then STKVal  else 0 end)  else 0 end ) as PGLSVal,  " +

                  "     sum(case ASGID when 125 then (case BrandID when 4 then CrStock  else 0 end)  else 0 end ) as TGLSQty, " +
                  "     sum(case ASGID when 125 then (case BrandID when 4 then STKVal  else 0 end)  else 0 end ) as TGLSVal, " +

                  "     sum(case ASGID when 126 then (case BrandID when 4 then CrStock  else 0 end)  else 0 end ) as CFLQty,	" +
                  "     sum(case ASGID when 126 then (case BrandID when 4 then STKVal  else 0 end)  else 0 end ) as CFLVal, " +

                  "     sum(case ASGID when 127 then (case BrandID when 4 then CrStock  else 0 end)  else 0 end ) as TLQty, " +
                  "     sum(case ASGID when 127 then (case BrandID when 4 then STKVal  else 0 end)  else 0 end ) as TLVal, " +
                  "     sum(STKVal)as STKVal " +

                  "     from  " +
                  "    (  " +
                  "    select DistributorID, ASGID,BrandID,ASGName,BrandDesc, sum(CurrentStock)as CrStock, round(sum(STKVal),0)as STKVal " +
                  "    from  " +
                  "    (  " +
                  "    select DistributorID,a.productID,ASGID,ASGName,BrandID, BrandDesc, CurrentStock, NSP, (NSP*CurrentStock*.95)as STKVal       " +
                  "    from BLLSysDB.dbo.t_DMSProductStock a, BLLSysDB.dbo.V_ProductDetails b  " +
                  "    where a.ProductID=b.ProductID and DistributorID= '" + sDBID + "'   " +
                  "    and CurrentStock>0   " +
                  "    )As ASGStock   " +
                  "    group by DistributorID,ASGID,BrandID,ASGName,BrandDesc   " +
                  "    )As Stk  " +
                  "    group by DistributorID	 " +
                  "   )As StkVal on SaTO.DistributorID=StkVal.DistributorID 	" +
                  "    )as SalnTGt on   RoutePro.RouteID=SalnTGt.RouteID " +
                  "   )As Final   order by Final.DayID "; 
                            

        try
        {

            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DSBLLRouteWiseSales.RouteSalesRow oRouteSalesRow = oDSBLLRouteWiseSales.RouteSales.NewRouteSalesRow();


                oRouteSalesRow.DistributorID = Convert.ToInt32(reader["DistributorID"]);
                oRouteSalesRow.CustomerCode = reader["CustomerCode"].ToString();
                oRouteSalesRow.CustomerName = reader["CustomerName"].ToString();
                oRouteSalesRow.RouteID = Convert.ToInt32(reader["RouteID"]);
                oRouteSalesRow.RouteName = reader["RouteName"].ToString();
                oRouteSalesRow.RouteType = reader["RouteType"].ToString();
                oRouteSalesRow.DayID = Convert.ToInt32(reader["DayID"]);
                oRouteSalesRow.DeliveryDay = reader["DeliveryDay"].ToString();
                oRouteSalesRow.OrderType = reader["OrderType"].ToString();

                oRouteSalesRow.MTDTO = Convert.ToDouble(reader["MTDTO"]);
                oRouteSalesRow.LMTO = Convert.ToDouble(reader["LMTO"]);
                oRouteSalesRow.BalTO = Convert.ToDouble(reader["BalTO"]);
                oRouteSalesRow.TGTTO = Convert.ToDouble(reader["TGTTO"]);

                oRouteSalesRow.LMTGLS = Convert.ToDouble(reader["LMTGLS"]);
                oRouteSalesRow.TGTTGLS = Convert.ToDouble(reader["TGTTGLS"]);              
                oRouteSalesRow.MTDTGLS = Convert.ToDouble(reader["MTDTGLS"]);

                oRouteSalesRow.LMPGLS = Convert.ToDouble(reader["LMPGLS"]);
                oRouteSalesRow.TGTPGLS = Convert.ToDouble(reader["TGTPGLS"]);
                oRouteSalesRow.MTDPGLS = Convert.ToDouble(reader["MTDPGLS"]);

                oRouteSalesRow.LMCFL = Convert.ToDouble(reader["LMCFL"]);
                oRouteSalesRow.TGTCFL = Convert.ToDouble(reader["TGTCFL"]);
                oRouteSalesRow.MTDCFL = Convert.ToDouble(reader["MTDCFL"]);

                oRouteSalesRow.LMTL = Convert.ToDouble(reader["LMTL"]);
                oRouteSalesRow.TGTTL = Convert.ToDouble(reader["TGTTL"]);
                oRouteSalesRow.MTDTL = Convert.ToDouble(reader["MTDTL"]);
                oRouteSalesRow.STKVal = Convert.ToDouble(reader["STKVal"]);

              //  oRouteSalesRow.Visit = Convert.ToInt16(reader["Visit"]);
                oRouteSalesRow.VisitPlan = Convert.ToInt16(reader["VisitPlan"]);
                oRouteSalesRow.Visited = Convert.ToInt16(reader["Visited"]);
               
                oRouteSalesRow.PGLSQty = Convert.ToInt32(reader["PGLSQty"]);
                oRouteSalesRow.PGLSVal = Convert.ToDouble(reader["PGLSVal"]);

                oRouteSalesRow.TGLSQty = Convert.ToInt32(reader["TGLSQty"]);
                oRouteSalesRow.TGLSVal = Convert.ToDouble(reader["TGLSVal"]);

                oRouteSalesRow.CFLQty = Convert.ToInt32(reader["CFLQty"]);
                oRouteSalesRow.CFLVal = Convert.ToDouble(reader["CFLVal"]);

                oRouteSalesRow.TLQty = Convert.ToInt32(reader["TLQty"]);
                oRouteSalesRow.TLVal = Convert.ToDouble(reader["TLVal"]);

                oDSBLLRouteWiseSales.RouteSales.AddRouteSalesRow(oRouteSalesRow);

               
            }
            oDSBLLRouteWiseSales.AcceptChanges();

            return oDSBLLRouteWiseSales;
        }

        catch (Exception ex)
        {
            throw (ex);
        }

    }
    
    protected void Page_Unload(object sender, EventArgs e)
    {
        if (rptFile != null)
        {
            rptFile.Close();
            rptFile.Dispose();
        }
    }
}

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



public partial class JBLLDBWiseSalesTran : System.Web.UI.Page
{
    ReportDocument rptFile;

    protected void Page_Load(object sender, EventArgs e)
    {
      
       
             string sAreaID = Request.QueryString.Get("AreaID");
             string sCompany = Request.QueryString.Get("Company");
             string sUser = Request.QueryString.Get("UserName");
             string sReqType = Request.QueryString.Get("ReqType");

            string sCompanyFullName = "Bangladesh Lamps Limited";
           
            //string sAreaID ="0";
            int nAreaID = 0;

            if (sAreaID != "")
            {
                nAreaID = Convert.ToInt32(sAreaID);
            }
            else nAreaID = 0;
           
             

            try
            {
                if (nAreaID > 0)
                {

                    rptFile = new ReportDocument();
                    rptFile.Load(Server.MapPath("Report/rptBLLDBTargetSalesCollection.rpt"));

                    DBController.Instance.OpenNewConnection();
                    BLLDSTargetSalesColl oBLLDSTargetSalesColl = GetDatsetDBLM(sAreaID);

                    DBController.Instance.CloseConnection();
                    rptFile.SetDataSource(oBLLDSTargetSalesColl);

                    CRViewer.DisplayToolbar = true;
                    CRViewer.ReportSource = rptFile;
                }

                else
                {
                    rptFile = new ReportDocument();
                    rptFile.Load(Server.MapPath("Report/rptBLLAreaTargetSalesCollection.rpt"));

                    DBController.Instance.OpenNewConnection();
                    BLLDSTargetSalesColl oBLLDSTargetSalesColl = GetDatsetSummary();

                    DBController.Instance.CloseConnection();
                    rptFile.SetDataSource(oBLLDSTargetSalesColl);

                    CRViewer.DisplayToolbar = true;
                    CRViewer.ReportSource = rptFile;
                
                }


            }
            catch (Exception ex)
            {
                string ss = ex.Message;

            }
    

    }

    private BLLDSTargetSalesColl GetDatsetSummary()
    {
        BLLDSTargetSalesColl oBLLDSTargetSalesColl = new BLLDSTargetSalesColl();
        OleDbCommand cmd = DBController.Instance.GetCommand();


        string sSQL = "";

        sSQL = " select  DistributorID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryName,ChannelID,LMPriTGT,  LMSecTGT,  LMPriTO,  (LMSecTO)as LMSecTO, PriTGT, PriTO,SecTGT,(SecTO )as SecTO, STKValue, Receivables, Coll, BGAmount,DMS   " +
               "    from  " +
               "    (  " +
               "    select  DistributorID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryName,ChannelID, LMPriTGT,  LMSecTGT,  LMPriTO,  LMSecTO, PriTGT, PriTO,SecTGT, SecTO,STKVal as STKValue ,   " +
               "    Receivables, Coll, isnull(BG_CRlimit,0)as BGAmount,DMS   " +
               "    from    " +
               "    (   " +
               "    select  DistributorID, sum(LMPriTGT) as LMPriTGT, sum(LMSecTGT) as LMSecTGT, sum(LMPriTO) as LMPriTO, sum(LMSecTO)as LMSecTO, sum(PriTGT)as PriTGT,sum(PriTO)as PriTO,sum(SecTGT)as SecTGT, sum(SecTO)as SecTO, sum(Coll)as Coll, sum(STKVal) as STKVal   " +
               "    from   " +
               "    (   " +
               "    select DistributorID,0 as LMPriTGT, 0 as LMSecTGT, 0 as LMPriTO, 0 LMSecTO, 0 as PriTGT, 0 as PriTO,  0 as SecTGT, SecTO,0 as Coll,0 as STKVal   " +
               "    from   " +
               "    (   " +
              //     ---- Start of Secondry Sales------------  
               "    select DistributorID, sum(Amount) as SecTO   " +
               "    from   " +
               "   (   " +
               "    select DistributorID, sum(NetAmount)as Amount    " +
               "    from BLLSysDB.dbo.t_DMSProductTran    " +
               "    where TranTypeID=2 and Trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and Trandate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)     " +
               "    and DistributorID in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)     " +
               "    group by DistributorID   " +
               "    union all  " +
               "    select b.CustomerID,  sum(TEBL) as Amount   " +
               "    from TELSysDB.dbo.t_SMSDailySecondarySalesCollection a, BLLSysDB.dbo.t_Customer b   " +
               "    where trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and Trandate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and a.CustomerID=b.CustomerCode   " +
               "    and b.CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)    " +
               "    group by b.CustomerID  " +
               "    )as TTO  " +
               "    group by DistributorID   " +
               "    )As SeTO   " +
            //    -- End of Secondry Sales----  
               "    union all    " +
            //    -- Start of Secondry Target----  

               "    select CustomerID,0 as LMPriTGT, 0 as LMSecTGT, 0 as LMPriTO, 0 LMSecTO, TGTTO as PriTGT,0 as PriTO,SecTGTTO as SecTGT, 0 as SecTO, 0 as Coll,0 as STKVal   " +
               "    from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLsysDB.dbo.t_Customer b     " +
               "    where TGTDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and  TGTDate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)     " +
               "    and a.Customercode=b.Customercode    " +
            //    -- End of Secondry Target----
               "    union all   " +
            //     -- Start of Primary Sales----  
               "    select CustomerID, 0 as LMPriTGT, 0 as LMSecTGT, 0 as LMPriTO, 0 LMSecTO, 0 as PriTGT,sum (Amount)as PriTO,0 as SecTGT, 0 as SecTO ,0 as Coll,0 as STKVal     " +
               "    from  " +
               "    (   " +
               "    select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount          " +
               "    from  " +
               "    (    " +
               "    select CustomerID,sum(invoiceamount) as crAmount, 0 as drAmount " +
               "    from bllsysdb.dbo.t_salesInvoice " +
               "    where invoicedate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and invoicedate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  " +
               "    and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3) " +
               "    group by  CustomerID " +
               "    union all " +
               "    select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount " +
               "    from bllsysdb.dbo.t_salesInvoice " +
               "    where invoicedate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and invoicedate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) " +
               "    and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)   " +
               "    group by  CustomerID    " +
               "    )as p2      " +
               "    group by CustomerID  " +
               "    ) as TELBLL  " +
               "    group by  CustomerID   " +
            //     -- End of Primary Sales----  
               "    union all  " +
            //     -- Start  of Collection ----  
               "    select customerid,0 as LMPriTGT, 0 as LMSecTGT, 0 as LMPriTO, 0 LMSecTO, 0 as PriTGT,0 as PriTO,0 as SecTGT, 0 as SecTO, Coll,0 as STKVal " +
               "    from  " +
               "    (  " +
               "    select  customerid, sum(CreditAmount-DebitAmount)as Coll   " +
               "    from   " +
               "      (   " +
               "     select customerid, sum(amount)as CreditAmount, 0 as DebitAmount  from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt    " +
               "    where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and TranDate <CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)   " +
               "     group by customerid      " +
               "    union all      " +
               "    select customerid, 0 as CreditAmount, sum(amount)as DebitAmount  from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt      " +
               "    where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)  and ct.TranDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and TranDate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  " +
               "    group by customerid   " +
               "    )as Colle   " +
               "    group by customerid   " +
               "    )As Col  " +
            //    -- End  of Collection ----  
               "   union all  " +
            //    -- Start  of Stock Value ----   
               "    select DistributorID, 0 as LMPriTGT, 0 as LMSecTGT, 0 as LMPriTO, 0 LMSecTO, 0 as PriTGT,0 as PriTO,0 as SecTGT, 0 as SecTO,0 as Coll,STKVal    " +
               "    from    " +
               "    (    " +
               "    select DistributorID,   round(sum(STKVal),0)as STKVal    " +
               "    from    " +
               "    (    " +
               "     select DistributorID,a.productID,ASGID,ASGName,BrandID, BrandDesc, CurrentStock, NSP, (NSP*CurrentStock*.95)as STKVal         " +
               "    from BLLSysDB.dbo.t_DMSProductStock a, BLLSysDB.dbo.V_ProductDetails b        " +
               "    where a.ProductID=b.ProductID and DistributorID in (select DistributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)   " +
               "    and CurrentStock>0     " +
               "    )As ASGStock     " +
               "    group by DistributorID   " +
               "    )as STK    " +
            //     -- End  of Stock Value ----  
               "    union all " +

               //     -- Start of Last Month Sales ---- 

               "    select DistributorID, round(sum(LMPriTGT),0)as LMPriTGT,round(sum(LMSecTGT),0) as LMSecTGT,round(sum(LMPriTO),0) As LMPriTO, round(sum(LMSecTO),0)as  LMSecTO, 0 as PriTGT,0 as PriTO,0 as SecTGT, 0 as SecTO,0 as Coll,0 as STKVal " +
               "    from " +
               "    ( " +
               "    select DistributorID,0 as LMPriTGT,0 as LMSecTGT, 0 as LMPriTO, sum(Amount) as LMSecTO   " +
               "    from   " +
               "    (    " +

               "     select CustomerID as DistributorID, sum(Amount)as Amount "+
               "     from dwdb.dbo.t_BLLSecondarySales "+
               "     where  trandate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and Trandate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  "+
               "     group by CustomerID " +

               //"    select DistributorID, sum(NetAmount)as Amount    " +
               //"    from BLLSysDB.dbo.t_DMSProductTran    " +
               //"    where TranTypeID=2 and Trandate between   DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and  DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and Trandate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0) " +
               //"    and DistributorID in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)     " +
               //"    group by DistributorID    " +
               //"    union all   " +
               //"    select b.CustomerID,  sum(TEBL) as Amount    " +
               //"    from TELSysDB.dbo.t_SMSDailySecondarySalesCollection a, BLLSysDB.dbo.t_Customer b    " +
               //"    where trandate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and Trandate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0) " +
               //"    and a.CustomerID=b.CustomerCode    " +
               //"    and b.CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)     " +
               //"    group by b.CustomerID   " +


               "    )as TTO  " +
               "    group by DistributorID " +

               "    union all " +

               "    select CustomerID, 0 as LMPriTGT,0 as LMSecTGT, sum (Amount)as LMPriTO, 0 as  LMSecTO " +
               "    from   " +
               "    (   " +
               "    select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount  " +
               "    from  " +
               "    (    " +
               "    select CustomerID,sum(invoiceamount) as crAmount, 0 as drAmount  " +
               "    from bllsysdb.dbo.t_salesInvoice    " +
               "    where invoicedate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and invoicedate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0)   " +
               "    and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3)    " +
               "    group by  CustomerID  " +
               "    union all       " +
               "    select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount   " +
               "    from bllsysdb.dbo.t_salesInvoice  " +
               "    where invoicedate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and invoicedate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0)     " +
               "    and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)    " +
               "    group by  CustomerID   " +
               "    )as p2     " +
               "    group by CustomerID  " +
               "    ) as TELBLL  " +
               "    group by  CustomerID  " +
               "    union all " +
               "    select CustomerID,TGTTO as LMPriTGT,SecTGTTO as LMSecTGT, 0 as LMPriTO, 0 as  LMSecTO   " +
               "    from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLsysDB.dbo.t_Customer b     " +
               "    where TGTDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and  TGTDate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0)     " +
               "    and a.Customercode=b.Customercode " +
               "    )As LMTO " +
               "    group by DistributorID " +

               //    --  End of Last Month Sales----
               "    )as Final   " +
               "    group by DistributorID   " +
               "    ) as Total   " +

               "   left outer join  " +
               "   (   " +
               "   select CustomerID, sum(MinCreditLimit) as BG_CRlimit,sum(MaxCreditLimit)as MaxCreditLimit   " +
               "   from BLLSysDB.dbo.t_CustomerCreditlimit    " +
               "   where getDate() between effectivedate and ExpiryDate group by CustomerID  " +
               "   )As CRLim on Total.DistributorID=CRLim.CustomerID   " +
               "   left outer join   " +
               "   (  " +
               "   select customerID, CustomerCode,CustomerName,AreaID,AreaName,TerritoryName,ChannelID,round((Currentbalance*-1),0)as Receivables,isnull(b.Isactive,0)as DMS    " +
               "   from BLLSysDB.dbo.v_customerDetails a left outer join BLLSysDB.dbo.t_DMSuser b on a.customerID=b.DistributorID   " +
               "   )as Cust on Total.DistributorID=Cust.CustomerID  " +
               "   )as Gtotal  " +
               "   order by ChannelID  ";


        try
        {

            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                BLLDSTargetSalesColl.TargetSalesCollRow oTargetSalesCollRow = oBLLDSTargetSalesColl.TargetSalesColl.NewTargetSalesCollRow();

                oTargetSalesCollRow.DistributorID = Convert.ToInt32(reader["DistributorID"]);
                oTargetSalesCollRow.CustomerCode = reader["CustomerCode"].ToString();
                oTargetSalesCollRow.CustomerName = reader["CustomerName"].ToString();
                oTargetSalesCollRow.AreaID = Convert.ToInt32(reader["AreaID"]);
                oTargetSalesCollRow.AreaName = reader["AreaName"].ToString();
                oTargetSalesCollRow.TerritoryName = reader["TerritoryName"].ToString();
                oTargetSalesCollRow.ChannelID = Convert.ToInt32(reader["ChannelID"]);

                oTargetSalesCollRow.PriTGT = Convert.ToDouble(reader["PriTGT"]);
                oTargetSalesCollRow.PriTO = Convert.ToDouble(reader["PriTO"]);

                oTargetSalesCollRow.SecTGT = Convert.ToDouble(reader["SecTGT"]);
                oTargetSalesCollRow.SecTO = Convert.ToDouble(reader["SecTO"]);

                oTargetSalesCollRow.STKValue = Convert.ToDouble(reader["STKValue"]);
                oTargetSalesCollRow.Receivables = Convert.ToDouble(reader["Receivables"]);

                oTargetSalesCollRow.Coll = Convert.ToDouble(reader["Coll"]);
                oTargetSalesCollRow.BGAmount = Convert.ToDouble(reader["BGAmount"]);
                oTargetSalesCollRow.DMS = Convert.ToInt16(reader["DMS"]);

                oTargetSalesCollRow.LMPriTGT = Convert.ToDouble(reader["LMPriTGT"]);
                oTargetSalesCollRow.LMSecTGT = Convert.ToDouble(reader["LMSecTGT"]);

                oTargetSalesCollRow.LMPriTO = Convert.ToDouble(reader["LMPriTO"]);
                oTargetSalesCollRow.LMSecTO = Convert.ToDouble(reader["LMSecTO"]);


                oBLLDSTargetSalesColl.TargetSalesColl.AddTargetSalesCollRow(oTargetSalesCollRow);
            }

            oBLLDSTargetSalesColl.AcceptChanges();

            return oBLLDSTargetSalesColl;
        }

        catch (Exception ex)
        {
            throw (ex);
        }

    }
  
    private BLLDSTargetSalesColl GetDatsetDBLM(string sAreaID)
    {
        BLLDSTargetSalesColl oBLLDSTargetSalesColl = new BLLDSTargetSalesColl();

        OleDbCommand cmd = DBController.Instance.GetCommand();


        string sSQL = "";

        sSQL = " select  DistributorID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryName,ChannelID,LMPriTGT,  LMSecTGT,  LMPriTO,  (LMSecTO)as LMSecTO, PriTGT, PriTO,SecTGT, (SecTO )as SecTO,STKValue, Receivables, Coll, BGAmount,DMS   " +
               "    from  " +
               "    (  " +
               "    select  DistributorID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryName,ChannelID, LMPriTGT,  LMSecTGT,  LMPriTO,  LMSecTO, PriTGT, PriTO,SecTGT, SecTO,STKVal as STKValue ,   " +
               "    Receivables, Coll, isnull(BG_CRlimit,0)as BGAmount,DMS   " +
               "    from    " +
               "    (   " +
               "    select  DistributorID, sum(LMPriTGT) as LMPriTGT, sum(LMSecTGT) as LMSecTGT, sum(LMPriTO) as LMPriTO, sum(LMSecTO)as LMSecTO, sum(PriTGT)as PriTGT,sum(PriTO)as PriTO,sum(SecTGT)as SecTGT, sum(SecTO)as SecTO, sum(Coll)as Coll, sum(STKVal) as STKVal   " +
               "    from   " +
               "    (   " +
               "    select DistributorID,0 as LMPriTGT, 0 as LMSecTGT, 0 as LMPriTO, 0 LMSecTO, 0 as PriTGT, 0 as PriTO,  0 as SecTGT, SecTO,0 as Coll,0 as STKVal   " +
               "    from   " +
               "    (   " +
              //     ---- Start of Secondry Sales------------  
               "    select DistributorID, sum(Amount) as SecTO   " +
               "    from   " +
               "   (   " +
               "    select DistributorID, sum(NetAmount)as Amount    " +
               "    from BLLSysDB.dbo.t_DMSProductTran    " +
               "    where TranTypeID=2 and Trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and Trandate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)     " +
               "    and DistributorID in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)     " +
               "    group by DistributorID   " +
               "    union all  " +
               "    select b.CustomerID,  sum(TEBL) as Amount   " +
               "    from TELSysDB.dbo.t_SMSDailySecondarySalesCollection a, BLLSysDB.dbo.t_Customer b   " +
               "    where trandate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and Trandate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and a.CustomerID=b.CustomerCode   " +
               "    and b.CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)    " +
               "    group by b.CustomerID  " +
               "    )as TTO  " +
               "    group by DistributorID   " +
               "    )As SeTO   " +
            //    -- End of Secondry Sales----  
               "    union all    " +
            //    -- Start of Secondry Target----  

               "    select CustomerID,0 as LMPriTGT, 0 as LMSecTGT, 0 as LMPriTO, 0 LMSecTO, TGTTO as PriTGT,0 as PriTO,SecTGTTO as SecTGT, 0 as SecTO, 0 as Coll,0 as STKVal   " +
               "    from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLsysDB.dbo.t_Customer b     " +
               "    where TGTDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  and  TGTDate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)     " +
               "    and a.Customercode=b.Customercode    " +
            //    -- End of Secondry Target----
               "    union all   " +
            //     -- Start of Primary Sales----  
               "    select CustomerID, 0 as LMPriTGT, 0 as LMSecTGT, 0 as LMPriTO, 0 LMSecTO, 0 as PriTGT,sum (Amount)as PriTO,0 as SecTGT, 0 as SecTO ,0 as Coll,0 as STKVal     " +
               "    from  " +
               "    (   " +
               "    select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount          " +
               "    from  " +
               "    (    " +
               "    select CustomerID,sum(invoiceamount) as crAmount, 0 as drAmount " +
               "    from bllsysdb.dbo.t_salesInvoice " +
               "    where invoicedate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and invoicedate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  " +
               "    and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3) " +
               "    group by  CustomerID " +
               "    union all " +
               "    select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount " +
               "    from bllsysdb.dbo.t_salesInvoice " +
               "    where invoicedate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and invoicedate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) " +
               "    and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)   " +
               "    group by  CustomerID    " +
               "    )as p2      " +
               "    group by CustomerID  " +
               "    ) as TELBLL  " +
               "    group by  CustomerID   " +
            //     -- End of Primary Sales----  
               "    union all  " +
            //     -- Start  of Collection ----  
               "    select customerid,0 as LMPriTGT, 0 as LMSecTGT, 0 as LMPriTO, 0 LMSecTO, 0 as PriTGT,0 as PriTO,0 as SecTGT, 0 as SecTO, Coll,0 as STKVal " +
               "    from  " +
               "    (  " +
               "    select  customerid, sum(CreditAmount-DebitAmount)as Coll   " +
               "    from   " +
               "      (   " +
               "     select customerid, sum(amount)as CreditAmount, 0 as DebitAmount  from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt    " +
               "    where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and TranDate <CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)   " +
               "     group by customerid      " +
               "    union all      " +
               "    select customerid, 0 as CreditAmount, sum(amount)as DebitAmount  from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt      " +
               "    where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)  and ct.TranDate between DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106) and TranDate < CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,getdate()))-1),DATEADD(mm,1,getdate())),106)  " +
               "    group by customerid   " +
               "    )as Colle   " +
               "    group by customerid   " +
               "    )As Col  " +
            //    -- End  of Collection ----  
               "   union all  " +
               //    -- Start  of Stock Value ----   
               "    select DistributorID, 0 as LMPriTGT, 0 as LMSecTGT, 0 as LMPriTO, 0 LMSecTO, 0 as PriTGT,0 as PriTO,0 as SecTGT, 0 as SecTO,0 as Coll,STKVal    " +
               "    from    " +
               "    (    " +
               "    select DistributorID,   round(sum(STKVal),0)as STKVal    " +
               "    from    " +
               "    (    " +
               "     select DistributorID,a.productID,ASGID,ASGName,BrandID, BrandDesc, CurrentStock, NSP, (NSP*CurrentStock*.95)as STKVal         " +
               "    from BLLSysDB.dbo.t_DMSProductStock a, BLLSysDB.dbo.V_ProductDetails b        " +
               "    where a.ProductID=b.ProductID and DistributorID in (select DistributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)   " +
               "    and CurrentStock>0     " +
               "    )As ASGStock     " +
               "    group by DistributorID   " +
               "    )as STK    " +
              //     -- End  of Stock Value ----  
               "    union all " +

               //     -- Start of Last Month Sales ---- 

               "    select DistributorID, round(sum(LMPriTGT),0)as LMPriTGT,round(sum(LMSecTGT),0) as LMSecTGT,round(sum(LMPriTO),0) As LMPriTO, round(sum(LMSecTO),0)as  LMSecTO, 0 as PriTGT,0 as PriTO,0 as SecTGT, 0 as SecTO,0 as Coll,0 as STKVal " +
               "    from " +
               "    ( " +
               "    select DistributorID,0 as LMPriTGT,0 as LMSecTGT, 0 as LMPriTO, sum(Amount) as LMSecTO   " +
               "    from   " +
               "    (    " +
               "     select CustomerID as DistributorID, sum(Amount)as Amount "+
               "     from dwdb.dbo.t_BLLSecondarySales "+
               "     where  trandate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and Trandate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  "+
               "     group by CustomerID " +
                              
               //"    select DistributorID, sum(NetAmount)as Amount    " +
               //"    from BLLSysDB.dbo.t_DMSProductTran    " +
               //"    where TranTypeID=2 and Trandate between   DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and  DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and Trandate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0) " +
               //"    and DistributorID in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)     " +
               //"    group by DistributorID    " +
               //"    union all   " +
               //"    select b.CustomerID,  sum(TEBL) as Amount    " +
               //"    from TELSysDB.dbo.t_SMSDailySecondarySalesCollection a, BLLSysDB.dbo.t_Customer b    " +
               //"    where trandate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and Trandate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0) " +
               //"    and a.CustomerID=b.CustomerCode    " +
               //"    and b.CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)     " +
               //"    group by b.CustomerID   " +

               "    )as TTO  " +
               "    group by DistributorID " +

               "    union all " +

               "    select CustomerID, 0 as LMPriTGT,0 as LMSecTGT, sum (Amount)as LMPriTO, 0 as  LMSecTO " +
               "    from   " +
               "    (   " +
               "    select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount  " +
               "    from  " +
               "    (    " +
               "    select CustomerID,sum(invoiceamount) as crAmount, 0 as drAmount  " +
               "    from bllsysdb.dbo.t_salesInvoice    " +
               "    where invoicedate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and invoicedate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0)   " +
               "    and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3)    " +
               "    group by  CustomerID  " +
               "    union all       " +
               "    select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount   " +
               "    from bllsysdb.dbo.t_salesInvoice  " +
               "    where invoicedate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(month, DATEDIFF(month, 0, getdate()), 0) and invoicedate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0)     " +
               "    and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)    " +
               "    group by  CustomerID   " +
               "    )as p2     " +
               "    group by CustomerID  " +
               "    ) as TELBLL  " +
               "    group by  CustomerID  " +
               "    union all " +
               "    select CustomerID,TGTTO as LMPriTGT,SecTGTTO as LMSecTGT, 0 as LMPriTO, 0 as  LMSecTO   " +
               "    from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLsysDB.dbo.t_Customer b     " +
               "    where TGTDate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) - 1, 0) and DATEADD(month, DATEDIFF(month, 0, getdate()), 0)  and  TGTDate < DATEADD(month, DATEDIFF(month, 0, getdate()), 0)     " +
               "    and a.Customercode=b.Customercode " +
               "    )As LMTO " +
               "    group by DistributorID " +

               //    --  End of Last Month Sales----
               "    )as Final   " +
               "    group by DistributorID   " +
               "    ) as Total   " +

               "   left outer join  " +
               "   (   " +
               "   select CustomerID, sum(MinCreditLimit) as BG_CRlimit,sum(MaxCreditLimit)as MaxCreditLimit   " +
               "   from BLLSysDB.dbo.t_CustomerCreditlimit    " +
               "   where getDate() between effectivedate and ExpiryDate  group by CustomerID   " +
               "   )As CRLim on Total.DistributorID=CRLim.CustomerID   " +
               "   left outer join   " +
               "   (  " +
               "   select customerID, CustomerCode,CustomerName,AreaID,AreaName,TerritoryName,ChannelID,round((Currentbalance*-1),0)as Receivables,isnull(b.Isactive,0)as DMS    " +
               "   from BLLSysDB.dbo.v_customerDetails a left outer join BLLSysDB.dbo.t_DMSuser b on a.customerID=b.DistributorID   " +
               "   )as Cust on Total.DistributorID=Cust.CustomerID  " +
               "   )as Gtotal  " +
               "    where AreaID =  " + sAreaID + " " +
               "   order by ChannelID,AreaName,TerritoryName ";
 

        try
        {

            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                BLLDSTargetSalesColl.TargetSalesCollRow oTargetSalesCollRow = oBLLDSTargetSalesColl.TargetSalesColl.NewTargetSalesCollRow();

                oTargetSalesCollRow.DistributorID = Convert.ToInt32(reader["DistributorID"]);
                oTargetSalesCollRow.CustomerCode = reader["CustomerCode"].ToString();
                oTargetSalesCollRow.CustomerName = reader["CustomerName"].ToString();
                oTargetSalesCollRow.AreaID = Convert.ToInt32(reader["AreaID"]);
                oTargetSalesCollRow.AreaName = reader["AreaName"].ToString();
                oTargetSalesCollRow.TerritoryName = reader["TerritoryName"].ToString();
                oTargetSalesCollRow.ChannelID = Convert.ToInt32(reader["ChannelID"]);

                oTargetSalesCollRow.PriTGT = Convert.ToDouble(reader["PriTGT"]);
                oTargetSalesCollRow.PriTO = Convert.ToDouble(reader["PriTO"]);

                oTargetSalesCollRow.SecTGT = Convert.ToDouble(reader["SecTGT"]);
                oTargetSalesCollRow.SecTO = Convert.ToDouble(reader["SecTO"]);

                oTargetSalesCollRow.STKValue = Convert.ToDouble(reader["STKValue"]);
                oTargetSalesCollRow.Receivables = Convert.ToDouble(reader["Receivables"]);

                oTargetSalesCollRow.Coll = Convert.ToDouble(reader["Coll"]);
                oTargetSalesCollRow.BGAmount = Convert.ToDouble(reader["BGAmount"]);
                oTargetSalesCollRow.DMS = Convert.ToInt16(reader["DMS"]);

                oTargetSalesCollRow.LMPriTGT = Convert.ToDouble(reader["LMPriTGT"]);
                oTargetSalesCollRow.LMSecTGT = Convert.ToDouble(reader["LMSecTGT"]);

                oTargetSalesCollRow.LMPriTO = Convert.ToDouble(reader["LMPriTO"]);
                oTargetSalesCollRow.LMSecTO = Convert.ToDouble(reader["LMSecTO"]);


                oBLLDSTargetSalesColl.TargetSalesColl.AddTargetSalesCollRow(oTargetSalesCollRow);
            }

            oBLLDSTargetSalesColl.AcceptChanges();

            return oBLLDSTargetSalesColl;
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

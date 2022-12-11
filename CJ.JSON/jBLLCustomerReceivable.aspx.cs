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
using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.ANDROID;

public partial class jBLLCustomerReceivable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sType = c.Request.Form["Type"].Trim();


            //string sUser = "hrashid";

            //string sType = "Area";
            //string sCompany = "BLL";
            //string sDatabase = "x";

            Datas oDatas = new Datas();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oDataChannel = new Data();
            Data _oDataArea = new Data();
            DBController.Instance.OpenNewConnection();

            if (sType == "Channel")
            {
                oDatas.GetChannel();
            }

            else if (sType == "Area")
            {
                oDatas.GetArea();

                int nCount = 0;
                foreach (Data oData in oDatas)
                {
                    if (nCount == 0)
                    {
                        _oDataTotal = new Data();
                        _oDatas.Add(_oDataTotal);
                        _oDataTotal.AreaName = "Total";
                        _oDataTotal.Type = "Total";
                        _oDataTotal.Value = "Success";
                        nCount++;
                    }
                    if (_oDataChannel.ChannelName != oData.ChannelName)
                    {
                        _oDataChannel = new Data();
                        _oDatas.Add(_oDataChannel);
                        _oDataChannel.ChannelName = oData.ChannelName;
                        _oDataChannel.AreaName = oData.ChannelName;
                        _oDataChannel.Type = "Channel";
                        _oDataChannel.Value = "Success";
                    }

                    _oDataArea = new Data();
                    _oDataArea.Value = "Success";

                    _oDataArea.ChannelID = oData.ChannelID;
                    _oDataArea.ChannelName = oData.ChannelName;
                    _oDataArea.AreaID = oData.AreaID;
                    _oDataArea.AreaName = oData.AreaName;
                    _oDataArea.TotRecValue = oData.TotRecValue;
                    _oDataArea.CRLimitValue = oData.CRLimitValue;
                    _oDataArea.BGValue = oData.BGValue;
                    _oDataArea.Age30DayValue = oData.Age30DayValue;
                    _oDataArea.Age60DayValue = oData.Age60DayValue;
                    _oDataArea.Age90DayValue = oData.Age90DayValue;
                    _oDataArea.AgeGrt90DayValue = oData.AgeGrt90DayValue;                    
                    _oDataArea.Type = "Area";
                    _oDatas.Add(_oDataArea);

                    _oDataTotal.TotRecValue = _oDataTotal.TotRecValue + oData.TotRecValue;
                    _oDataTotal.CRLimitValue = _oDataTotal.CRLimitValue + oData.CRLimitValue;
                    _oDataTotal.BGValue = _oDataTotal.BGValue + oData.BGValue;
                    _oDataTotal.Age30DayValue = _oDataTotal.Age30DayValue + oData.Age30DayValue;
                    _oDataTotal.Age60DayValue = _oDataTotal.Age60DayValue + oData.Age60DayValue;
                    _oDataTotal.Age90DayValue = _oDataTotal.Age90DayValue + oData.Age90DayValue;
                    _oDataTotal.AgeGrt90DayValue = _oDataTotal.AgeGrt90DayValue + oData.AgeGrt90DayValue;
                    

                    _oDataChannel.TotRecValue = _oDataChannel.TotRecValue + oData.TotRecValue;
                    _oDataChannel.CRLimitValue = _oDataChannel.CRLimitValue + oData.CRLimitValue;
                    _oDataChannel.BGValue = _oDataChannel.BGValue + oData.BGValue;
                    _oDataChannel.Age30DayValue = _oDataChannel.Age30DayValue + oData.Age30DayValue;
                    _oDataChannel.Age60DayValue = _oDataChannel.Age60DayValue + oData.Age60DayValue;
                    _oDataChannel.Age90DayValue= _oDataChannel.Age90DayValue + oData.Age90DayValue;
                    _oDataChannel.AgeGrt90DayValue = _oDataChannel.AgeGrt90DayValue + oData.AgeGrt90DayValue;
                    

                }
            }
            else if (sType == "Customer")
            {
                oDatas.GetCustomer();
            }

            DBController.Instance.CloseConnection();

            if (sType == "Area")
            {
                Data oData = new Data();
                //oData.InsertReportLog(sUser);
            }
            if (sType == "Channel")
            {
                string sOutput = JsonConvert.SerializeObject(oDatas.getResult(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }

            if (sType == "Area")
            {
                string sOutput = JsonConvert.SerializeObject(_oDatas.getAreaResult(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "Customer")
            {
                string sOutput = JsonConvert.SerializeObject(oDatas.getCustomerResult(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }

        }
    }

    public class Data
    {
        public string ChannelID;
        public string ChannelName;
        public string AreaID;
        public string AreaName;
        public string CustomerName;
        public string IsActive;
        public string Type;

        public double TotRecValue;
        public double CRLimitValue;
        public double BGValue;
        public double Age30DayValue;
        public double Age60DayValue;
        public double Age90DayValue;
        public double AgeGrt90DayValue;
  


        public string TotRecValueText;
        public string CRLimitValueText;
        public string BGValueText;
        public string Age30DayValueText;
        public string Age60DayValueText;

        public string Age90DayValueText;
        public string AgeGrt90DayValueText;
        

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10003";
            string sReportName = "BLL-Customer Receivable";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
    }

    public class Datas : CollectionBase
    {

        public Data this[int i]
        {
            get { return (Data)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Data oData)
        {
            InnerList.Add(oData);
        }
        private string ExcludeDecimal(string sAmount)
        {
            string sResult = "";
            sResult = sAmount.Remove(sAmount.Length - 3);
            return sResult;
        }
        public void GetChannel()
        {

            InnerList.Clear();

            //string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();



            string sSQL = @"-----------------Channel----------------
            select ChannelID,Channel, TotRec,  ActRec, InActRec,
            CRLimit, BGAmount,  Age30 as Age30Day, Age60 as Age60Day,  Age90 as Age90Day, 
            AgeGrt90Day= case when  (Age30+Age60+Age90) <0 then (TotRec+ (Age30+Age60+Age90) ) else 
            (TotRec- (Age30+Age60+Age90) ) end
            from
            (
            select ChannelID,ChannelDescription as Channel, TotRec,  ActRec, InActRec,
            CRLimit, BGAmount, In30Day, Coll30, (In30Day- Coll30) as Age30,
            In60Day, Coll60,(In60Day- Coll60) as Age60, 
            In90Day, Coll90, (In90Day- Coll90) as Age90
            from
            (
            select ChannelID,ChannelDescription,sum(TotRec)As TotRec, sum(ActRec)as ActRec,sum(InActRec)as InActRec,
            sum(CRLimit) as CRLimit,sum(BGAmount) as BGAmount,sum(MTDAge) as In30Day,sum(CM_Coll30) as Coll30,  
            sum(LMAge60) as In60Day,sum(CM_Coll60) as Coll60, sum(LMAge90) as In90Day,
            sum(CM_Coll90) as Coll90
            from
            (
            select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName, Cust.CustomerID, CustomerName, 
            TotRec, ActRec, InActRec, CRLimit,
            isnull(MTDAge30, 0) as MTDAge, ISNULL(CM_Coll30,0) as CM_Coll30, 
            isnull(LMAge60, 0) as LMAge60, ISNULL(CM_Coll60,0) as CM_Coll60, 
            isnull(LMAge90, 0) as LMAge90, ISNULL(CM_Coll90,0) as CM_Coll90,
            isnull(BGAmount,0) as BGAmount , Isactive

            from
            (
            select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName, Q1.CustomerID, CustomerName, (ActRec + InActRec) as TotRec, ActRec, InActRec, isnull(CRLimit, 0)As CRLimit, Isactive
            from
            (
            select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName,
            CustomerID, CustomerName, Isactive, ActRec, InActRec
            from
            (
            select ChannelID, ChannelDescription, RegionID, RegionShortName as RegionName, TerritoryID, TerritoryShortName as TerrritoryName,
            CustomerID, CustomerName, Isactive, (CurrentBalance * -1) ActRec, 0 as InActRec
            from BLLSysDB.dbo.v_Customerdetails
            where Isactive = 1
            union all
            select ChannelID, ChannelDescription, RegionID, RegionShortName as RegionName, TerritoryID, TerritoryShortName as TerrritoryName,
            CustomerID, CustomerName, Isactive, 0 as ActRec, (CurrentBalance * -1) InActRec
            from BLLSysDB.dbo.v_Customerdetails
            where Isactive = 0
            ) as Rec
            ) as Q1
            left outer join
            (
            select distinct CustomerID, MinCreditLimit as CRLimit
            from BLLSysDB.dbo.t_CustomerCreditLimit
            where Convert(datetime, replace(convert(varchar, EffectiveDate, 6), '', '-'), 1) <= Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)
            and expiryDate > = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)
            ) as Q2 on Q1.CustomerID = Q2.CustomerID
            ) as Cust
            left outer join
            (
            select CustomerID, sum(MTDAge30) as MTDAge30, sum(CM_Coll30) as CM_Coll30, sum(LMAge60) as LMAge60,
            sum(CM_Coll60) as CM_Coll60, sum(LMAge90) as LMAge90, sum(CM_Coll90) as CM_Coll90
            from
            (
            -------------AG30Sales Start------------------
            select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as MTDAge30, 0 as CM_Coll30, 
            0 as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90 
            from 
            (
            select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
            from bllsysdb.dbo.t_salesInvoice 
            where invoicedate between  dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
            and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
            group by CustomerID 
            union all 
            select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
            from bllsysdb.dbo.t_salesInvoice  
            where invoicedate between  dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
            and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
            group by CustomerID 
            )as asg30 group by CustomerID
            -------------AG30Sayes End-------------------------
            union all
            -------------AG30 Coll Start---------------------
            select customerid, 0 as MTDAge30, sum(CreditAmount-DebitAmount)as CM_Coll30, 0 as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
            from 
            ( 
            select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
             dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))  and getDate()
            group by customerid
            union all
            select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
             dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
            group by customerid 
            )as Colle30  group by customerid
            -------------AG30 Coll End---------------------
            union all
            -------------AG60 Sales Start---------------------
            select CustomerID, 0 as MTDAge30,0 as CM_Coll30, isnull(sum(crAmount) - abs(sum(drAmount)),0) as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
            from
            (
            select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
            from bllsysdb.dbo.t_salesInvoice 
            where invoicedate between  dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
            group by CustomerID 
            union all 
            select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
            from bllsysdb.dbo.t_salesInvoice  
            where invoicedate between  dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
            group by CustomerID
            ) asg60 group by CustomerID
            -------------AG60 Sales End---------------------
            union all
            -------------AG60 Coll Start---------------------
            select customerid, 0 as MTDAge30,0 as CM_Coll30,0 as LMAge60, sum(CreditAmount-DebitAmount)as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
            from 
            ( 
            select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
             dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and
             dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            group by customerid
            union all
            select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
             dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            group by customerid 
            )as Colle60  group by customerid
            -------------AG60 Coll End---------------------
            union all
            -------------AG90 Sales Start---------------------
            select CustomerID, 0 as MTDAge30,0 as CM_Coll30, 0 as LMAge60,0 as CM_Coll60, isnull(sum(crAmount) - abs(sum(drAmount)),0) as LMAge90, 0 as CM_Coll90
            from
            (
            select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
            from bllsysdb.dbo.t_salesInvoice 
            where invoicedate between   dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
            group by CustomerID 
            union all 
            select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
            from bllsysdb.dbo.t_salesInvoice  
            where invoicedate between  dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
            group by CustomerID
            ) as asg90 group by CustomerID
            -------------AG90 Sales End---------------------
            union all
            -------------AG90 Coll Start---------------------
            select customerid, 0 as MTDAge30,0 as CM_Coll30, 0 as LMAge60,0 as CM_Coll60,0 as LMAge90, sum(CreditAmount-DebitAmount)as CM_Coll90
            from 
            ( 
            select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
             dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            group by customerid
            union all
            select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
             dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            group by customerid 
            )as Colle90  group by customerid
            -------------AG90 Coll End---------------------
            ) as Tage group by CustomerID
            ) as Age on Cust.CustomerID = Age.CustomerID
            left outer join
            (
            select CustomerID, sum(BGAmount) as BGAmount from t_CustomerBankGuarantee
            where expiryDate >= getdate() and isactive = 1
            group by CustomerID
            ) as BG on Cust.CustomerID = BG.CustomerID
            )As Final
            group by ChannelID,ChannelDescription 
            ) as xx 
            ) as xy order by ChannelID, Channel";

            //// Modified Field 90day, 90Day +, BG Amount ---- Hrashid 15-Jan-2020
            //string sSQL = @"select ChannelID,ChannelDescription,sum(TotRec)As TotRec, sum(ActRec)as ActRec,sum(InActRec)as InActRec,
            //            sum(CRLimit) as CRLimit,sum(MTDAge) as Age30Day,  
            //            sum(LMAge60) as Age60Day, sum(LMAge90) as Age90Day, sum(LMAge_grt90) as AgeGrt90Day, 
            //            sum(BGAmount) as BGAmount
            //            from
            //            (
            //            select ChannelID, ChannelDescription, AreaID, AreaName, TerritoryID, TerrritoryName, Cust.CustomerID, CustomerName, TotRec, ActRec, InActRec, CRLimit,
            //            isnull(MTDAge30, 0) as MTDAge, isnull(LMAge60, 0) as LMAge60, isnull(LMAge90, 0) as LMAge90, isnull(LMAge_grt90, 0) as LMAge_grt90,
            //            isnull(BGAmount,0) as BGAmount , Isactive
            //            from
            //            (
            //            select ChannelID, ChannelDescription, AreaID, AreaName, TerritoryID, TerrritoryName, Q1.CustomerID, CustomerName, (ActRec + InActRec) as TotRec, ActRec, InActRec, isnull(CRLimit, 0)As CRLimit, Isactive
            //            from
            //            (
            //            select ChannelID, ChannelDescription, AreaID, AreaName, TerritoryID, TerrritoryName,
            //            CustomerID, CustomerName, Isactive, ActRec, InActRec
            //            from
            //            (
            //            select ChannelID, ChannelDescription, AreaID, AreashortName as AreaName, TerritoryID, TerritoryShortName as TerrritoryName,
            //            CustomerID, CustomerName, Isactive, (CurrentBalance * -1) ActRec, 0 as InActRec
            //            from BLLSysDB.dbo.v_Customerdetails
            //            where Isactive = 1
            //            union all
            //            select ChannelID, ChannelDescription, AreaID, AreashortName as AreaName, TerritoryID, TerritoryShortName as TerrritoryName,
            //            CustomerID, CustomerName, Isactive, 0 as ActRec, (CurrentBalance * -1) InActRec
            //            from BLLSysDB.dbo.v_Customerdetails
            //            where Isactive = 0
            //            ) as Rec
            //            ) as Q1
            //            left outer join
            //            (
            //            select distinct CustomerID, MinCreditLimit as CRLimit
            //            from BLLSysDB.dbo.t_CustomerCreditLimit
            //            where Convert(datetime, replace(convert(varchar, EffectiveDate, 6), '', '-'), 1) <= Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)
            //            and expiryDate > = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)
            //            ) as Q2 on Q1.CustomerID = Q2.CustomerID
            //            ) as Cust
            //            left outer join
            //            (
            //            select CustomerID, sum(MTDAge30) as MTDAge30, sum(LMAge60) as LMAge60, sum(LMAge90) as LMAge90, sum(LMAge_grt90) as LMAge_grt90
            //            from
            //            (
            //            select CustomerID, sum(round(DueAmount, 0)) as MTDAge30, 0 as LMAge60, 0 as LMAge90, 0 as LMAge_grt90
            //            from BLLSysDB.dbo.t_SalesInvoice
            //            where Invoicedate between dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
            //            and DueAmount > 0
            //            group by CustomerID
            //            union all
            //            select CustomerID, 0 as MTDAge30, sum(round(DueAmount, 0)) as LMAge60, 0 as LMAge90, 0 as LMAge_grt90
            //            from BLLSysDB.dbo.t_SalesInvoice
            //            where Invoicedate between  dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //            and  dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //            and DueAmount > 0
            //            group by CustomerID
            //            union all
            //            select CustomerID, 0 as MTDAge30, 0 as LMAge60, sum(round(DueAmount, 0)) as LMAge90, 0 as LMAge_grt90
            //            from BLLSysDB.dbo.t_SalesInvoice
            //            where Invoicedate between dateadd(day, -90, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //            and  dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //            and DueAmount > 0
            //            group by CustomerID
            //            union all
            //            select CustomerID, 0 as MTDAge30, 0 as LMAge60, 0 as LMAge90, sum(round(DueAmount, 0)) as LMAge_grt90
            //            from BLLSysDB.dbo.t_SalesInvoice
            //            where Invoicedate < dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //            and DueAmount > 0
            //            group by CustomerID
            //            ) as Tage group by CustomerID
            //            ) as Age on Cust.CustomerID = Age.CustomerID
            //            left outer join
            //            (
            //            select CustomerID, sum(BGAmount) as BGAmount from t_CustomerBankGuarantee
            //            where expiryDate >= getdate() and isactive = 1
            //            group by CustomerID
            //            ) as BG on Cust.CustomerID = BG.CustomerID
            //            )As Final
            //            group by ChannelID,ChannelDescription order by ChannelID, ChannelDescription ";

            //sSQL = " select ChannelID,ChannelDescription,sum(TotRec)As TotRec, sum(ActRec)as ActRec,sum(InActRec)as InActRec,sum(CRLimit)as CRLimit,sum(MTDAge)as Age30Day, "+
            //        "   sum(LMAge)as Age60Day "+
            //        "   from "+
            //        "   ( "+
            //        "   select ChannelID,ChannelDescription,AreaID,AreaName,TerritoryID,TerrritoryName,Cust.CustomerID,CustomerName,TotRec,ActRec,InActRec, CRLimit,  "+ 
            //        "   isnull(MTDAge,0)as MTDAge, isnull(LMAge,0)as LMAge,Isactive "+
            //        "   from "+
            //        "   (  "+
            //        "   select ChannelID,ChannelDescription,AreaID,AreaName,TerritoryID,TerrritoryName,Q1.CustomerID,CustomerName,(ActRec+InActRec)as TotRec,ActRec,InActRec,isnull(CRLimit,0)As CRLimit,Isactive "+
            //        "   from "+
            //        "   ( "+
            //        "   select ChannelID,ChannelDescription,AreaID, AreaName,TerritoryID, TerrritoryName, "+
            //        "   CustomerID,CustomerName,Isactive,ActRec,InActRec "+
            //        "   from "+
            //        "   ( "+
            //        "   select ChannelID,ChannelDescription,AreaID,AreashortName as AreaName,TerritoryID, TerritoryShortName as TerrritoryName, "+
            //        "   CustomerID,CustomerName,Isactive, (CurrentBalance*-1) ActRec, 0 as InActRec "+
            //        "   from BLLSysDB.dbo.v_Customerdetails  "+
            //        "   where Isactive=1 "+
            //        "   union all "+
            //        "   select ChannelID,ChannelDescription,AreaID,AreashortName as AreaName,TerritoryID, TerritoryShortName as TerrritoryName, "+
            //        "   CustomerID,CustomerName,Isactive,0 as ActRec,(CurrentBalance*-1) InActRec "+
            //        "   from BLLSysDB.dbo.v_Customerdetails  " +
            //        "   where Isactive=0 "+
            //        "   ) as Rec "+
            //        "   )as Q1 "+
            //        "   left outer join "+
            //        "   ( "+
            //        "   select distinct CustomerID,MinCreditLimit as CRLimit "+
            //        "   from BLLSysDB.dbo.t_CustomerCreditLimit " +
            //        // "   where Effectivedate <= getdate() and ExpiryDate >=getdate() "+
            //        " where Convert(datetime,replace(convert(varchar, EffectiveDate,6),'','-'),1) <=  Convert(datetime,replace(convert(varchar, GETDATE(),6),'','-'),1) " +
            //        " and expiryDate> = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1) "+
            //        "   )as Q2 on Q1.CustomerID=Q2.CustomerID  "+
            //        "   )as Cust "+
            //        "   left outer join "+
            //        "   ( "+
            //        "   select isnull(Q1.CustomerID,Q2.CustomerID)as CustomerID, isnull(MTDAge,0)as MTDAge, isnull(LMAge,0)as LMAge "+
            //        "   from "+
            //        "   ( "+
            //        "   select CustomerID, sum(round(DueAmount,0))as MTDAge "+
            //        "   from BLLSysDB.dbo.t_SalesInvoice  " +
            //        "   where Invoicedate between dateadd(day,-30,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and getDate()  "+
            //        "   and DueAmount>0 "+
            //        "   group by CustomerID "+
            //        "   )as Q1 "+
            //        "   full outer join "+
            //        "   ( "+
            //        "  select CustomerID, sum(round(DueAmount,0))as LMAge "+
            //        "   from BLLSysDB.dbo.t_SalesInvoice  " +
            //        "   where Invoicedate between dateadd(day,-60,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and getdate()   "+
            //        "   and DueAmount>0 "+
            //        "   group by CustomerID "+
            //        "   )as Q2 on Q1.CustomerID=Q2.CustomerID "+
            //        "   )as Age on Cust.CustomerID=Age.CustomerID " +
            //        "   )As Final  "+
            //        "   group by ChannelID,ChannelDescription order by ChannelID,ChannelDescription "; 


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.ChannelID = reader["ChannelID"].ToString();
                    oData.ChannelName = reader["Channel"].ToString();
                    oData.TotRecValue= Convert.ToDouble(reader["TotRec"]);
                    oData.CRLimitValue = Convert.ToDouble(reader["CRLimit"]);
                    oData.BGValue = Convert.ToDouble(reader["BGAmount"]);
                    oData.Age30DayValue = Convert.ToDouble(reader["Age30Day"]);
                    oData.Age60DayValue = Convert.ToDouble(reader["Age60Day"]);
                    oData.Age90DayValue = Convert.ToDouble(reader["Age90Day"]);
                    oData.AgeGrt90DayValue = Convert.ToDouble(reader["AgeGrt90Day"]);              
                    InnerList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetArea()
        {

            InnerList.Clear();

            //string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSQL = @" Select ChannelID, Channel, RegionID, RegionName, Isnull(sum(TotRec/1000),0) as  TotRec, 
            IsNull(sum(ActRec/1000),0) as   ActRec, IsNull(sum(InActRec/1000),0) as  InActRec,
            IsNull(sum(CRLimit/1000),0) as CRLimit, IsNull(sum(BGAmount/1000),0) as  BGAmount,
            IsNull(sum(Age30Day/1000),0) as Age30Day, IsNull(sum(Age60Day/1000),0) as  Age60Day,  Isnull(sum(Age90Day/1000),0) as  Age90Day, IsNull(sum(AgeGrt90Day/1000),0) as AgeGrt90Day
from
(
-----------------Channel----------------
select ChannelID, ChannelDescription as Channel, RegionID, RegionName, TotRec,  ActRec, InActRec,
CRLimit, BGAmount,  Age30 as Age30Day, Age60 as Age60Day,  Age90 as Age90Day, 
AgeGrt90Day= case when  (Age30+Age60+Age90) <0 then (TotRec+ (Age30+Age60+Age90) ) else 
(TotRec- (Age30+Age60+Age90) ) end
from
(
select ChannelID, ChannelDescription, RegionID, RegionName, TotRec,  ActRec, InActRec,
CRLimit, BGAmount, In30Day, Coll30, (In30Day- Coll30) as Age30,
In60Day, Coll60,(In60Day- Coll60) as Age60, 
In90Day, Coll90, (In90Day- Coll90) as Age90
from
(
select ChannelID, ChannelDescription, RegionID, RegionName,sum(TotRec)As TotRec, sum(ActRec)as ActRec,sum(InActRec)as InActRec,
sum(CRLimit) as CRLimit,sum(BGAmount) as BGAmount,sum(MTDAge) as In30Day,sum(CM_Coll30) as Coll30,  
sum(LMAge60) as In60Day,sum(CM_Coll60) as Coll60, sum(LMAge90) as In90Day,
sum(CM_Coll90) as Coll90
from
(
select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName, Cust.CustomerID, CustomerName, 
TotRec, ActRec, InActRec, CRLimit,
isnull(MTDAge30, 0) as MTDAge, ISNULL(CM_Coll30,0) as CM_Coll30, 
isnull(LMAge60, 0) as LMAge60, ISNULL(CM_Coll60,0) as CM_Coll60, 
isnull(LMAge90, 0) as LMAge90, ISNULL(CM_Coll90,0) as CM_Coll90,
isnull(BGAmount,0) as BGAmount 

from
(
select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName, Q1.CustomerID, CustomerName, (ActRec + InActRec) as TotRec, ActRec, InActRec, isnull(CRLimit, 0)As CRLimit, Isactive
from
(
select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName,
CustomerID, CustomerName, Isactive, ActRec, InActRec
from
(
select ChannelID, ChannelDescription, RegionID, RegionShortName as RegionName, TerritoryID, TerritoryShortName as TerrritoryName,
CustomerID, CustomerName, Isactive, (CurrentBalance * -1) ActRec, 0 as InActRec
from BLLSysDB.dbo.v_Customerdetails
where Isactive = 1
union all
select ChannelID, ChannelDescription, RegionID, RegionShortName as RegionName, TerritoryID, TerritoryShortName as TerrritoryName,
CustomerID, CustomerName, Isactive, 0 as ActRec, (CurrentBalance * -1) InActRec
from BLLSysDB.dbo.v_Customerdetails
where Isactive = 0
) as Rec
) as Q1
left outer join
(
select distinct CustomerID, MinCreditLimit as CRLimit
from BLLSysDB.dbo.t_CustomerCreditLimit
where Convert(datetime, replace(convert(varchar, EffectiveDate, 6), '', '-'), 1) <= Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)
and expiryDate > = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)
) as Q2 on Q1.CustomerID = Q2.CustomerID
) as Cust
left outer join
(
select CustomerID, sum(MTDAge30) as MTDAge30, sum(CM_Coll30) as CM_Coll30, sum(LMAge60) as LMAge60,
sum(CM_Coll60) as CM_Coll60, sum(LMAge90) as LMAge90, sum(CM_Coll90) as CM_Coll90
from
(
-------------AG30Sales Start------------------
select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as MTDAge30, 0 as CM_Coll30, 
0 as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90 
from 
(
select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
from bllsysdb.dbo.t_salesInvoice 
where invoicedate between  dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
group by CustomerID 
union all 
select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
from bllsysdb.dbo.t_salesInvoice  
where invoicedate between  dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
group by CustomerID 
)as asg30 group by CustomerID
-------------AG30Sayes End-------------------------
union all
-------------AG30 Coll Start---------------------
select customerid, 0 as MTDAge30, sum(CreditAmount-DebitAmount)as CM_Coll30, 0 as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
from 
( 
select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
 dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))  and getDate()
group by customerid
union all
select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
 dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
group by customerid 
)as Colle30  group by customerid
-------------AG30 Coll End---------------------
union all
-------------AG60 Sales Start---------------------
select CustomerID, 0 as MTDAge30,0 as CM_Coll30, isnull(sum(crAmount) - abs(sum(drAmount)),0) as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
from
(
select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
from bllsysdb.dbo.t_salesInvoice 
where invoicedate between  dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
 dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
group by CustomerID 
union all 
select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
from bllsysdb.dbo.t_salesInvoice  
where invoicedate between  dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
 dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
group by CustomerID
) asg60 group by CustomerID
-------------AG60 Sales End---------------------
union all
-------------AG60 Coll Start---------------------
select customerid, 0 as MTDAge30,0 as CM_Coll30,0 as LMAge60, sum(CreditAmount-DebitAmount)as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
from 
( 
select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
 dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and
 dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
group by customerid
union all
select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
 dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
 dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
group by customerid 
)as Colle60  group by customerid
-------------AG60 Coll End---------------------
union all
-------------AG90 Sales Start---------------------
select CustomerID, 0 as MTDAge30,0 as CM_Coll30, 0 as LMAge60,0 as CM_Coll60, isnull(sum(crAmount) - abs(sum(drAmount)),0) as LMAge90, 0 as CM_Coll90
from
(
select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
from bllsysdb.dbo.t_salesInvoice 
where invoicedate between   dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
 dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
group by CustomerID 
union all 
select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
from bllsysdb.dbo.t_salesInvoice  
where invoicedate between  dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
 dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
group by CustomerID
) as asg90 group by CustomerID
-------------AG90 Sales End---------------------
union all
-------------AG90 Coll Start---------------------
select customerid, 0 as MTDAge30,0 as CM_Coll30, 0 as LMAge60,0 as CM_Coll60,0 as LMAge90, sum(CreditAmount-DebitAmount)as CM_Coll90
from 
( 
select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
 dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
 dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
group by customerid
union all
select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
 dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
 dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
group by customerid 
)as Colle90  group by customerid
-------------AG90 Coll End---------------------
) as Tage group by CustomerID
) as Age on Cust.CustomerID = Age.CustomerID
left outer join
(
select CustomerID, sum(BGAmount) as BGAmount from t_CustomerBankGuarantee
where expiryDate >= getdate() and isactive = 1
group by CustomerID
) as BG on Cust.CustomerID = BG.CustomerID
)As Final group by ChannelID, ChannelDescription, RegionID, RegionName
) as xx 
) as xy 
) as ff group by ChannelID, Channel, RegionID, RegionName order by ChannelID,RegionID, RegionName ";
            //-----------------Channel----------------
            //select ChannelID,ChannelDescription,RegionID, RegionName, TotRec,  ActRec, InActRec,
            //CRLimit, BGAmount,  Age30 as Age30Day, Age60 as Age60Day,  Age90 as Age90Day, 
            //AgeGrt90Day= case when  (Age30+Age60+Age90) <0 then (TotRec+ (Age30+Age60+Age90) ) else 
            //(TotRec- (Age30+Age60+Age90) ) end
            //from
            //(
            //select ChannelID,ChannelDescription,RegionID, RegionName, TotRec,  ActRec, InActRec,
            //CRLimit, BGAmount, In30Day, Coll30, (In30Day- Coll30) as Age30,
            //In60Day, Coll60,(In60Day- Coll60) as Age60, 
            //In90Day, Coll90, (In90Day- Coll90) as Age90
            //from
            //(
            //select ChannelID,ChannelDescription,RegionID, RegionName,sum(TotRec)As TotRec, sum(ActRec)as ActRec,sum(InActRec)as InActRec,
            //sum(CRLimit) as CRLimit,sum(BGAmount) as BGAmount,sum(MTDAge) as In30Day,sum(CM_Coll30) as Coll30,  
            //sum(LMAge60) as In60Day,sum(CM_Coll60) as Coll60, sum(LMAge90) as In90Day,
            //sum(CM_Coll90) as Coll90
            //from
            //(
            //select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName, Cust.CustomerID, CustomerName, 
            //TotRec, ActRec, InActRec, CRLimit,
            //isnull(MTDAge30, 0) as MTDAge, ISNULL(CM_Coll30,0) as CM_Coll30, 
            //isnull(LMAge60, 0) as LMAge60, ISNULL(CM_Coll60,0) as CM_Coll60, 
            //isnull(LMAge90, 0) as LMAge90, ISNULL(CM_Coll90,0) as CM_Coll90,
            //isnull(BGAmount,0) as BGAmount , Isactive

            //from
            //(
            //select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName, Q1.CustomerID, CustomerName, (ActRec + InActRec) as TotRec, ActRec, InActRec, isnull(CRLimit, 0)As CRLimit, Isactive
            //from
            //(
            //select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName,
            //CustomerID, CustomerName, Isactive, ActRec, InActRec
            //from
            //(
            //select ChannelID, ChannelDescription, RegionID, RegionShortName as RegionName, TerritoryID, TerritoryShortName as TerrritoryName,
            //CustomerID, CustomerName, Isactive, (CurrentBalance * -1) ActRec, 0 as InActRec
            //from BLLSysDB.dbo.v_Customerdetails
            //where Isactive = 1
            //union all
            //select ChannelID, ChannelDescription, RegionID, RegionShortName as RegionName, TerritoryID, TerritoryShortName as TerrritoryName,
            //CustomerID, CustomerName, Isactive, 0 as ActRec, (CurrentBalance * -1) InActRec
            //from BLLSysDB.dbo.v_Customerdetails
            //where Isactive = 0
            //) as Rec
            //) as Q1
            //left outer join
            //(
            //select distinct CustomerID, MinCreditLimit as CRLimit
            //from BLLSysDB.dbo.t_CustomerCreditLimit
            //where Convert(datetime, replace(convert(varchar, EffectiveDate, 6), '', '-'), 1) <= Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)
            //and expiryDate > = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)
            //) as Q2 on Q1.CustomerID = Q2.CustomerID
            //) as Cust
            //left outer join
            //(
            //select CustomerID, sum(MTDAge30) as MTDAge30, sum(CM_Coll30) as CM_Coll30, sum(LMAge60) as LMAge60,
            //sum(CM_Coll60) as CM_Coll60, sum(LMAge90) as LMAge90, sum(CM_Coll90) as CM_Coll90
            //from
            //(
            //-------------AG30Sales Start------------------
            //select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as MTDAge30, 0 as CM_Coll30, 
            //0 as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90 
            //from 
            //(
            //select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
            //from bllsysdb.dbo.t_salesInvoice 
            //where invoicedate between  dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
            //and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
            //group by CustomerID 
            //union all 
            //select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
            //from bllsysdb.dbo.t_salesInvoice  
            //where invoicedate between  dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
            //and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
            //group by CustomerID 
            //)as asg30 group by CustomerID
            //-------------AG30Sayes End-------------------------
            //union all
            //-------------AG30 Coll Start---------------------
            //select customerid, 0 as MTDAge30, sum(CreditAmount-DebitAmount)as CM_Coll30, 0 as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
            //from 
            //( 
            //select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            //where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
            //    dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))  and getDate()
            //group by customerid
            //union all
            //select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            //where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
            //    dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
            //group by customerid 
            //)as Colle30  group by customerid
            //-------------AG30 Coll End---------------------
            //union all
            //-------------AG60 Sales Start---------------------
            //select CustomerID, 0 as MTDAge30,0 as CM_Coll30, isnull(sum(crAmount) - abs(sum(drAmount)),0) as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
            //from
            //(
            //select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
            //from bllsysdb.dbo.t_salesInvoice 
            //where invoicedate between  dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
            //    dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
            //group by CustomerID 
            //union all 
            //select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
            //from bllsysdb.dbo.t_salesInvoice  
            //where invoicedate between  dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
            //    dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
            //group by CustomerID
            //) asg60 group by CustomerID
            //-------------AG60 Sales End---------------------
            //union all
            //-------------AG60 Coll Start---------------------
            //select customerid, 0 as MTDAge30,0 as CM_Coll30,0 as LMAge60, sum(CreditAmount-DebitAmount)as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
            //from 
            //( 
            //select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            //where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
            //    dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and
            //    dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //group by customerid
            //union all
            //select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            //where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
            //    dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
            //    dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //group by customerid 
            //)as Colle60  group by customerid
            //-------------AG60 Coll End---------------------
            //union all
            //-------------AG90 Sales Start---------------------
            //select CustomerID, 0 as MTDAge30,0 as CM_Coll30, 0 as LMAge60,0 as CM_Coll60, isnull(sum(crAmount) - abs(sum(drAmount)),0) as LMAge90, 0 as CM_Coll90
            //from
            //(
            //select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
            //from bllsysdb.dbo.t_salesInvoice 
            //where invoicedate between   dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
            //    dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
            //group by CustomerID 
            //union all 
            //select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
            //from bllsysdb.dbo.t_salesInvoice  
            //where invoicedate between  dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
            //    dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
            //group by CustomerID
            //) as asg90 group by CustomerID
            //-------------AG90 Sales End---------------------
            //union all
            //-------------AG90 Coll Start---------------------
            //select customerid, 0 as MTDAge30,0 as CM_Coll30, 0 as LMAge60,0 as CM_Coll60,0 as LMAge90, sum(CreditAmount-DebitAmount)as CM_Coll90
            //from 
            //( 
            //select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            //where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
            //    dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
            //    dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //group by customerid
            //union all
            //select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            //where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
            //    dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
            //    dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            //group by customerid 
            //)as Colle90  group by customerid
            //-------------AG90 Coll End---------------------
            //) as Tage group by CustomerID
            //) as Age on Cust.CustomerID = Age.CustomerID
            //left outer join
            //(
            //select CustomerID, sum(BGAmount) as BGAmount from t_CustomerBankGuarantee
            //where expiryDate >= getdate() and isactive = 1
            //group by CustomerID
            //) as BG on Cust.CustomerID = BG.CustomerID
            //)As Final
            //group by ChannelID,ChannelDescription,RegionID, RegionName 
            //) as xx 
            //) as xy order by ChannelID, ChannelDescription ";
//----------------Area--------------
//select ChannelID,Channel, RegionID,Region,sum(TotRec/1000)As TotRec, sum(ActRec/1000)as ActRec,
//sum(InActRec/1000)as InActRec,sum(CRLimit/1000)as CRLimit,sum(BGAmount/1000) as BGAmount,
//sum(MTDAge/1000)as Age30Day,  
//sum(LMAge60/1000)as Age60Day, sum(LMAge90/1000)as Age90Day, sum(LMAge_grt90/1000)as AgeGrt90Day
//from  
//(  
//select ChannelID,ChannelDescription as Channel ,RegionID,Region,TerritoryID,TerrritoryName,Cust.CustomerID,CustomerName,
//TotRec,ActRec,InActRec, CRLimit,   
//isnull(MTDAge30,0)as MTDAge, isnull(LMAge60,0)as LMAge60, isnull(LMAge90,0) as LMAge90, isnull(LMAge_grt90,0) as LMAge_grt90,Isactive, isnull(BGAmount,0) as BGAmount   
//from  
//(  
//select ChannelID,ChannelDescription,RegionID,Region,TerritoryID,TerrritoryName,Q1.CustomerID,CustomerName,
//(ActRec+InActRec)as TotRec,ActRec,InActRec,isnull(CRLimit,0)As CRLimit,Isactive  
//from  
//(  
//select ChannelID,ChannelDescription,RegionID, Region,TerritoryID, TerrritoryName,  
//CustomerID,CustomerName,Isactive,ActRec,InActRec  
//from  
//(  
//select ChannelID,ChannelDescription,RegionID,RegionShortName as Region,TerritoryID, TerritoryShortName as TerrritoryName,  
//CustomerID,CustomerName,Isactive,isnull((CurrentBalance*-1),0) ActRec, 0 as InActRec  
//from BLLSysDB.dbo.v_Customerdetails   
//where Isactive=1  
//union all  
//select ChannelID,ChannelDescription,RegionID,RegionShortName as Region,TerritoryID, TerritoryShortName as TerrritoryName,  
//CustomerID,CustomerName,Isactive,0 as ActRec,isnull((CurrentBalance*-1),0) InActRec  
//from BLLSysDB.dbo.v_Customerdetails   
//where Isactive=0  
//) as Rec  
//)as Q1  
//left outer join  
//(  
//select distinct CustomerID,MinCreditLimit as CRLimit  
//from BLLSysDB.dbo.t_CustomerCreditLimit  
//where Convert(datetime,replace(convert(varchar, EffectiveDate,6),'','-'),1) <=  Convert(datetime,replace(convert(varchar, GETDATE(),6),'','-'),1)  
//and expiryDate> = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)  
//)as Q2 on Q1.CustomerID=Q2.CustomerID   
//)as Cust  
//left outer join  
//(  
//select CustomerID, sum(MTDAge30)as MTDAge30, sum(LMAge60) as LMAge60, sum(LMAge90) as LMAge90, sum(LMAge_grt90) as LMAge_grt90       
//from
//(
//select CustomerID, sum(round(DueAmount,0))as MTDAge30, 0 as LMAge60, 0 as LMAge90, 0 as LMAge_grt90       
//from BLLSysDB.dbo.t_SalesInvoice   
//where Invoicedate between  dateadd(day,-30,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and getDate()   
//and DueAmount>0  
//group by CustomerID  
//union all
//select CustomerID, 0 as MTDAge30, sum(round(DueAmount,0))as LMAge60, 0 as LMAge90, 0 as LMAge_grt90  
//from BLLSysDB.dbo.t_SalesInvoice   
//where Invoicedate between  dateadd(day,-60,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) 
//and  dateadd(day,-31,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))
//and DueAmount>0  
//group by CustomerID 
//union all
//select CustomerID, 0 as MTDAge30, 0 as LMAge60, sum(round(DueAmount,0)) as LMAge90, 0 as LMAge_grt90     
//from BLLSysDB.dbo.t_SalesInvoice   
//where Invoicedate between  dateadd(day,-90,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) 
//and  dateadd(day,-61,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) 
//and DueAmount>0  
//group by CustomerID
//union all
//select CustomerID,0 as MTDAge30, 0 as LMAge60, 0 as LMAge90, sum(round(DueAmount,0))as LMAge_grt90   
//from BLLSysDB.dbo.t_SalesInvoice   
//where Invoicedate < dateadd(day,-91,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))  
//and DueAmount>0  
//group by CustomerID
//) as Tage group by CustomerID
//)as Age on Cust.CustomerID=Age.CustomerID  
//left outer join
//(
//select CustomerID, sum(BGAmount)as BGAmount from t_CustomerBankGuarantee
//where expiryDate >= getdate() and isactive=1
//group by CustomerID
//) as BG on Cust.CustomerID=BG.CustomerID 
//)As Final  
//group by ChannelID,Channel, RegionID,Region order by ChannelID,RegionID,Region";

            // Modified Field 90day, 90Day +, BG Amount ---- Hrashid 15-Jan-2020
            //string sSQL = @"select ChannelID,Channel, AreaID,AreaName,sum(TotRec/1000)As TotRec, sum(ActRec/1000)as ActRec,
            //        sum(InActRec/1000)as InActRec,sum(CRLimit/1000)as CRLimit,
            //        sum(MTDAge/1000)as Age30Day,  
            //        sum(LMAge60/1000)as Age60Day, sum(LMAge90/1000)as Age90Day, sum(LMAge_grt90/1000)as AgeGrt90Day,
            //        sum(BGAmount/1000) as BGAmount  
            //        from  
            //        (  
            //        select ChannelID,ChannelDescription as Channel ,AreaID,AreaName,TerritoryID,TerrritoryName,Cust.CustomerID,CustomerName,
            //        TotRec,ActRec,InActRec, CRLimit,   
            //        isnull(MTDAge30,0)as MTDAge, isnull(LMAge60,0)as LMAge60, isnull(LMAge90,0) as LMAge90, isnull(LMAge_grt90,0) as LMAge_grt90,Isactive, isnull(BGAmount,0) as BGAmount   
            //        from  
            //        (  
            //        select ChannelID,ChannelDescription,AreaID,AreaName,TerritoryID,TerrritoryName,Q1.CustomerID,CustomerName,
            //        (ActRec+InActRec)as TotRec,ActRec,InActRec,isnull(CRLimit,0)As CRLimit,Isactive  
            //        from  
            //        (  
            //        select ChannelID,ChannelDescription,AreaID, AreaName,TerritoryID, TerrritoryName,  
            //        CustomerID,CustomerName,Isactive,ActRec,InActRec  
            //        from  
            //        (  
            //        select ChannelID,ChannelDescription,AreaID,AreashortName as AreaName,TerritoryID, TerritoryShortName as TerrritoryName,  
            //        CustomerID,CustomerName,Isactive,isnull((CurrentBalance*-1),0) ActRec, 0 as InActRec  
            //        from BLLSysDB.dbo.v_Customerdetails   
            //        where Isactive=1  
            //        union all  
            //        select ChannelID,ChannelDescription,AreaID,AreashortName as AreaName,TerritoryID, TerritoryShortName as TerrritoryName,  
            //        CustomerID,CustomerName,Isactive,0 as ActRec,isnull((CurrentBalance*-1),0) InActRec  
            //        from BLLSysDB.dbo.v_Customerdetails   
            //        where Isactive=0  
            //        ) as Rec  
            //        )as Q1  
            //        left outer join  
            //        (  
            //        select distinct CustomerID,MinCreditLimit as CRLimit  
            //        from BLLSysDB.dbo.t_CustomerCreditLimit  
            //        where Convert(datetime,replace(convert(varchar, EffectiveDate,6),'','-'),1) <=  Convert(datetime,replace(convert(varchar, GETDATE(),6),'','-'),1)  
            //        and expiryDate> = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)  
            //        )as Q2 on Q1.CustomerID=Q2.CustomerID   
            //        )as Cust  
            //        left outer join  
            //        (  
            //        select CustomerID, sum(MTDAge30)as MTDAge30, sum(LMAge60) as LMAge60, sum(LMAge90) as LMAge90, sum(LMAge_grt90) as LMAge_grt90       
            //        from
            //        (
            //        select CustomerID, sum(round(DueAmount,0))as MTDAge30, 0 as LMAge60, 0 as LMAge90, 0 as LMAge_grt90       
            //        from BLLSysDB.dbo.t_SalesInvoice   
            //        where Invoicedate between dateadd(day,-30,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and getDate()   
            //        and DueAmount>0  
            //        group by CustomerID  
            //        union all
            //        select CustomerID, 0 as MTDAge30, sum(round(DueAmount,0))as LMAge60, 0 as LMAge90, 0 as LMAge_grt90  
            //        from BLLSysDB.dbo.t_SalesInvoice   
            //        where Invoicedate between  dateadd(day,-60,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) 
            //        and  dateadd(day,-31,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))
            //        and DueAmount>0  
            //        group by CustomerID 
            //        union all
            //        select CustomerID, 0 as MTDAge30, 0 as LMAge60, sum(round(DueAmount,0)) as LMAge90, 0 as LMAge_grt90     
            //        from BLLSysDB.dbo.t_SalesInvoice   
            //        where Invoicedate between dateadd(day,-90,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) 
            //        and  dateadd(day,-61,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) 
            //        and DueAmount>0  
            //        group by CustomerID
            //        union all
            //        select CustomerID,0 as MTDAge30, 0 as LMAge60, 0 as LMAge90, sum(round(DueAmount,0))as LMAge_grt90   
            //        from BLLSysDB.dbo.t_SalesInvoice   
            //        where Invoicedate < dateadd(day,-91,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))  
            //        and DueAmount>0  
            //        group by CustomerID
            //        ) as Tage group by CustomerID
            //        )as Age on Cust.CustomerID=Age.CustomerID  
            //        left outer join
            //        (
            //        select CustomerID, sum(BGAmount)as BGAmount from t_CustomerBankGuarantee
            //        where expiryDate >= getdate() and isactive=1
            //        group by CustomerID
            //        ) as BG on Cust.CustomerID=BG.CustomerID 
            //        )As Final  
            //        group by ChannelID,Channel, AreaID,AreaName order by ChannelID,AreaID,AreaName";


            //sSQL = " select ChannelID,Channel, AreaID,AreaName,sum(TotRec/1000)As TotRec, sum(ActRec/1000)as ActRec,sum(InActRec/1000)as InActRec,sum(CRLimit/1000)as CRLimit,sum(MTDAge/1000)as Age30Day, " +
            //       "   sum(LMAge/1000)as Age60Day " +
            //       "  from " +
            //       "  ( " +
            //       "  select ChannelID,ChannelDescription as Channel ,AreaID,AreaName,TerritoryID,TerrritoryName,Cust.CustomerID,CustomerName,TotRec,ActRec,InActRec, CRLimit,  " +
            //       "  isnull(MTDAge,0)as MTDAge, isnull(LMAge,0)as LMAge,Isactive " +
            //       "  from " +
            //       "  ( " +
            //       "  select ChannelID,ChannelDescription,AreaID,AreaName,TerritoryID,TerrritoryName,Q1.CustomerID,CustomerName,(ActRec+InActRec)as TotRec,ActRec,InActRec,isnull(CRLimit,0)As CRLimit,Isactive " +
            //       "  from " +
            //       "  ( " +
            //       "  select ChannelID,ChannelDescription,AreaID, AreaName,TerritoryID, TerrritoryName, " +
            //       "  CustomerID,CustomerName,Isactive,ActRec,InActRec " +
            //       "  from " +
            //       "  ( " +
            //       "  select ChannelID,ChannelDescription,AreaID,AreashortName as AreaName,TerritoryID, TerritoryShortName as TerrritoryName, " +
            //       "  CustomerID,CustomerName,Isactive,isnull((CurrentBalance*-1),0) ActRec, 0 as InActRec " +
            //       "  from BLLSysDB.dbo.v_Customerdetails  " +
            //       "  where Isactive=1 " +
            //       "  union all " +
            //       "  select ChannelID,ChannelDescription,AreaID,AreashortName as AreaName,TerritoryID, TerritoryShortName as TerrritoryName, " +
            //       "  CustomerID,CustomerName,Isactive,0 as ActRec,isnull((CurrentBalance*-1),0) InActRec " +
            //       "  from BLLSysDB.dbo.v_Customerdetails  " +
            //       "  where Isactive=0 " +
            //       "  ) as Rec " +
            //       "  )as Q1 " +
            //       "  left outer join " +
            //       "  ( " +
            //       "  select distinct CustomerID,MinCreditLimit as CRLimit " +
            //       "  from BLLSysDB.dbo.t_CustomerCreditLimit " +
            //      // "  where Effectivedate <= getdate() and ExpiryDate >=getdate() " +
            //       " where Convert(datetime,replace(convert(varchar, EffectiveDate,6),'','-'),1) <=  Convert(datetime,replace(convert(varchar, GETDATE(),6),'','-'),1) " +
            //       " and expiryDate> = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1) " +
            //       "  )as Q2 on Q1.CustomerID=Q2.CustomerID  " +
            //       "  )as Cust " +
            //       "  left outer join " +
            //       "  ( " +
            //       "  select isnull(Q1.CustomerID,Q2.CustomerID)as CustomerID, isnull(MTDAge,0)as MTDAge, isnull(LMAge,0)as LMAge " +
            //       "  from " +
            //       "  ( " +
            //       "  select CustomerID, sum(round(DueAmount,0))as MTDAge " +
            //       "  from BLLSysDB.dbo.t_SalesInvoice  " +
            //       "  where Invoicedate between dateadd(day,-30,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and getDate()  " +
            //       "  and DueAmount>0 " +
            //       "  group by CustomerID " +
            //       "  )as Q1 " +
            //       "  full outer join " +
            //       "  ( " +
            //       "  select CustomerID, sum(round(DueAmount,0))as LMAge " +
            //       "  from BLLSysDB.dbo.t_SalesInvoice  " +
            //       "  where Invoicedate between dateadd(day,-60,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and getdate()   " +
            //       "  and DueAmount>0 " +
            //       "  group by CustomerID " +
            //       "  )as Q2 on Q1.CustomerID=Q2.CustomerID " +
            //       "  )as Age on Cust.CustomerID=Age.CustomerID " +
            //       "  )As Final " +
            //       "  group by ChannelID,Channel, AreaID,AreaName order by ChannelID,AreaID,AreaName ";



            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.ChannelID = reader["ChannelID"].ToString();
                    oData.ChannelName = reader["Channel"].ToString();
                    oData.AreaID = reader["RegionID"].ToString();
                    oData.AreaName = reader["RegionName"].ToString();                    
                    oData.TotRecValue = Convert.ToDouble(reader["TotRec"]);
                    oData.CRLimitValue = Convert.ToDouble(reader["CRLimit"]);
                    oData.BGValue = Convert.ToDouble(reader["BGAmount"]);
                    oData.Age30DayValue = Convert.ToDouble(reader["Age30Day"]);
                    oData.Age60DayValue = Convert.ToDouble(reader["Age60Day"]);
                    oData.Age90DayValue = Convert.ToDouble(reader["Age90Day"]);
                    oData.AgeGrt90DayValue = Convert.ToDouble(reader["AgeGrt90Day"]);


                    InnerList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetCustomer()
        {

            InnerList.Clear();

           // string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = @" select RegionID, CustomerID, CustomerName,Isactive, IsNull(sum(TotRec/1000),0) as  TotRec, IsNull(sum(ActRec/1000),0) as   ActRec, IsNull(sum(InActRec/1000),0) as  InActRec,
            IsNull(sum(CRLimit/1000),0) as CRLimit,IsNull(sum(BGAmount/1000),0) as  BGAmount,IsNull(sum(Age30Day/1000),0) as Age30Day, 
            IsNull(sum(Age60Day/1000),0) as  Age60Day,  IsNull(sum(Age90Day/1000),0) as  Age90Day,  IsNull(sum(AgeGrt90Day/1000),0) as AgeGrt90Day
            from
            (
            -----------------Channel----------------
            select RegionID, CustomerID, CustomerName,Isactive, TotRec,  ActRec, InActRec,
            CRLimit, BGAmount,  Age30 as Age30Day, Age60 as Age60Day,  Age90 as Age90Day, 
            AgeGrt90Day= case when  (Age30+Age60+Age90) <0 then (TotRec+ (Age30+Age60+Age90) ) else 
            (TotRec- (Age30+Age60+Age90) ) end
            from
            (
            select RegionID, CustomerID, CustomerName,Isactive, TotRec,  ActRec, InActRec,
            CRLimit, BGAmount, In30Day, Coll30, (In30Day- Coll30) as Age30,
            In60Day, Coll60,(In60Day- Coll60) as Age60, 
            In90Day, Coll90, (In90Day- Coll90) as Age90
            from
            (
            select RegionID,CustomerID, CustomerName,Isactive,sum(TotRec)As TotRec, sum(ActRec)as ActRec,sum(InActRec)as InActRec,
            sum(CRLimit) as CRLimit,sum(BGAmount) as BGAmount,sum(MTDAge) as In30Day,sum(CM_Coll30) as Coll30,  
            sum(LMAge60) as In60Day,sum(CM_Coll60) as Coll60, sum(LMAge90) as In90Day,
            sum(CM_Coll90) as Coll90
            from
            (
            select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName, Cust.CustomerID, CustomerName, 
            TotRec, ActRec, InActRec, CRLimit,
            isnull(MTDAge30, 0) as MTDAge, ISNULL(CM_Coll30,0) as CM_Coll30, 
            isnull(LMAge60, 0) as LMAge60, ISNULL(CM_Coll60,0) as CM_Coll60, 
            isnull(LMAge90, 0) as LMAge90, ISNULL(CM_Coll90,0) as CM_Coll90,
            isnull(BGAmount,0) as BGAmount , Isactive

            from
            (
            select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName, Q1.CustomerID, CustomerName, (ActRec + InActRec) as TotRec, ActRec, InActRec, isnull(CRLimit, 0)As CRLimit, Isactive
            from
            (
            select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName,
            CustomerID, CustomerName, Isactive, ActRec, InActRec
            from
            (
            select ChannelID, ChannelDescription, RegionID, RegionShortName as RegionName, TerritoryID, TerritoryShortName as TerrritoryName,
            CustomerID, CustomerName, Isactive, (CurrentBalance * -1) ActRec, 0 as InActRec
            from BLLSysDB.dbo.v_Customerdetails
            where Isactive = 1
            union all
            select ChannelID, ChannelDescription, RegionID, RegionShortName as RegionName, TerritoryID, TerritoryShortName as TerrritoryName,
            CustomerID, CustomerName, Isactive, 0 as ActRec, (CurrentBalance * -1) InActRec
            from BLLSysDB.dbo.v_Customerdetails
            where Isactive = 0
            ) as Rec
            ) as Q1
            left outer join
            (
            select distinct CustomerID, MinCreditLimit as CRLimit
            from BLLSysDB.dbo.t_CustomerCreditLimit
            where Convert(datetime, replace(convert(varchar, EffectiveDate, 6), '', '-'), 1) <= Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)
            and expiryDate > = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)
            ) as Q2 on Q1.CustomerID = Q2.CustomerID
            ) as Cust
            left outer join
            (
            select CustomerID, sum(MTDAge30) as MTDAge30, sum(CM_Coll30) as CM_Coll30, sum(LMAge60) as LMAge60,
            sum(CM_Coll60) as CM_Coll60, sum(LMAge90) as LMAge90, sum(CM_Coll90) as CM_Coll90
            from
            (
            -------------AG30Sales Start------------------
            select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as MTDAge30, 0 as CM_Coll30, 
            0 as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90 
            from 
            (
            select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
            from bllsysdb.dbo.t_salesInvoice 
            where invoicedate between  dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
            and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
            group by CustomerID 
            union all 
            select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
            from bllsysdb.dbo.t_salesInvoice  
            where invoicedate between  dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
            and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
            group by CustomerID 
            )as asg30 group by CustomerID
            -------------AG30Sayes End-------------------------
            union all
            -------------AG30 Coll Start---------------------
            select customerid, 0 as MTDAge30, sum(CreditAmount-DebitAmount)as CM_Coll30, 0 as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
            from 
            ( 
            select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
             dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))  and getDate()
            group by customerid
            union all
            select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
             dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
            group by customerid 
            )as Colle30  group by customerid
            -------------AG30 Coll End---------------------
            union all
            -------------AG60 Sales Start---------------------
            select CustomerID, 0 as MTDAge30,0 as CM_Coll30, isnull(sum(crAmount) - abs(sum(drAmount)),0) as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
            from
            (
            select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
            from bllsysdb.dbo.t_salesInvoice 
            where invoicedate between  dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
            group by CustomerID 
            union all 
            select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
            from bllsysdb.dbo.t_salesInvoice  
            where invoicedate between  dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
            group by CustomerID
            ) asg60 group by CustomerID
            -------------AG60 Sales End---------------------
            union all
            -------------AG60 Coll Start---------------------
            select customerid, 0 as MTDAge30,0 as CM_Coll30,0 as LMAge60, sum(CreditAmount-DebitAmount)as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
            from 
            ( 
            select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
             dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and
             dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            group by customerid
            union all
            select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
             dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            group by customerid 
            )as Colle60  group by customerid
            -------------AG60 Coll End---------------------
            union all
            -------------AG90 Sales Start---------------------
            select CustomerID, 0 as MTDAge30,0 as CM_Coll30, 0 as LMAge60,0 as CM_Coll60, isnull(sum(crAmount) - abs(sum(drAmount)),0) as LMAge90, 0 as CM_Coll90
            from
            (
            select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
            from bllsysdb.dbo.t_salesInvoice 
            where invoicedate between   dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
            group by CustomerID 
            union all 
            select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
            from bllsysdb.dbo.t_salesInvoice  
            where invoicedate between  dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
            group by CustomerID
            ) as asg90 group by CustomerID
            -------------AG90 Sales End---------------------
            union all
            -------------AG90 Coll Start---------------------
            select customerid, 0 as MTDAge30,0 as CM_Coll30, 0 as LMAge60,0 as CM_Coll60,0 as LMAge90, sum(CreditAmount-DebitAmount)as CM_Coll90
            from 
            ( 
            select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
             dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            group by customerid
            union all
            select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
             dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
             dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
            group by customerid 
            )as Colle90  group by customerid
            -------------AG90 Coll End---------------------
            ) as Tage group by CustomerID
            ) as Age on Cust.CustomerID = Age.CustomerID
            left outer join
            (
            select CustomerID, sum(BGAmount) as BGAmount from t_CustomerBankGuarantee
            where expiryDate >= getdate() and isactive = 1
            group by CustomerID
            ) as BG on Cust.CustomerID = BG.CustomerID
            )As Final group by RegionID,CustomerID,CustomerName,Isactive 
            ) as xx 
            ) as xy 
            ) as ff group by RegionID, CustomerID, CustomerName,Isactive order by RegionID,CustomerID,CustomerName";

//select RegionID, CustomerID, CustomerName,Isactive, sum(TotRec/1000) as  TotRec, sum(ActRec/1000) as   ActRec,sum(InActRec/1000) as  InActRec,
//sum(CRLimit/1000) as CRLimit,sum(BGAmount/1000) as  BGAmount,sum(Age30Day/1000) as Age30Day, sum(Age60Day/1000) as  Age60Day,  sum(Age90Day/1000) as  Age90Day, 
//sum(AgeGrt90Day/1000) as AgeGrt90Day
//from
//(
//-----------------Channel----------------
//select RegionID, CustomerID, CustomerName,Isactive, TotRec,  ActRec, InActRec,
//CRLimit, BGAmount,  Age30 as Age30Day, Age60 as Age60Day,  Age90 as Age90Day, 
//AgeGrt90Day= case when  (Age30+Age60+Age90) <0 then (TotRec+ (Age30+Age60+Age90) ) else 
//(TotRec- (Age30+Age60+Age90) ) end
//from
//(
//select RegionID, CustomerID, CustomerName,Isactive, TotRec,  ActRec, InActRec,
//CRLimit, BGAmount, In30Day, Coll30, (In30Day- Coll30) as Age30,
//In60Day, Coll60,(In60Day- Coll60) as Age60, 
//In90Day, Coll90, (In90Day- Coll90) as Age90
//from
//(
//select RegionID,CustomerID, CustomerName,Isactive,sum(TotRec)As TotRec, sum(ActRec)as ActRec,sum(InActRec)as InActRec,
//sum(CRLimit) as CRLimit,sum(BGAmount) as BGAmount,sum(MTDAge) as In30Day,sum(CM_Coll30) as Coll30,  
//sum(LMAge60) as In60Day,sum(CM_Coll60) as Coll60, sum(LMAge90) as In90Day,
//sum(CM_Coll90) as Coll90
//from
//(
//select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName, Cust.CustomerID, CustomerName, 
//TotRec, ActRec, InActRec, CRLimit,
//isnull(MTDAge30, 0) as MTDAge, ISNULL(CM_Coll30,0) as CM_Coll30, 
//isnull(LMAge60, 0) as LMAge60, ISNULL(CM_Coll60,0) as CM_Coll60, 
//isnull(LMAge90, 0) as LMAge90, ISNULL(CM_Coll90,0) as CM_Coll90,
//isnull(BGAmount,0) as BGAmount , Isactive

//from
//(
//select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName, Q1.CustomerID, CustomerName, (ActRec + InActRec) as TotRec, ActRec, InActRec, isnull(CRLimit, 0)As CRLimit, Isactive
//from
//(
//select ChannelID, ChannelDescription, RegionID, RegionName, TerritoryID, TerrritoryName,
//CustomerID, CustomerName, Isactive, ActRec, InActRec
//from
//(
//select ChannelID, ChannelDescription, RegionID, RegionShortName as RegionName, TerritoryID, TerritoryShortName as TerrritoryName,
//CustomerID, CustomerName, Isactive, (CurrentBalance * -1) ActRec, 0 as InActRec
//from BLLSysDB.dbo.v_Customerdetails
//where Isactive = 1
//union all
//select ChannelID, ChannelDescription, RegionID, RegionShortName as RegionName, TerritoryID, TerritoryShortName as TerrritoryName,
//CustomerID, CustomerName, Isactive, 0 as ActRec, (CurrentBalance * -1) InActRec
//from BLLSysDB.dbo.v_Customerdetails
//where Isactive = 0
//) as Rec
//) as Q1
//left outer join
//(
//select distinct CustomerID, MinCreditLimit as CRLimit
//from BLLSysDB.dbo.t_CustomerCreditLimit
//where Convert(datetime, replace(convert(varchar, EffectiveDate, 6), '', '-'), 1) <= Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)
//and expiryDate > = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)
//) as Q2 on Q1.CustomerID = Q2.CustomerID
//) as Cust
//left outer join
//(
//select CustomerID, sum(MTDAge30) as MTDAge30, sum(CM_Coll30) as CM_Coll30, sum(LMAge60) as LMAge60,
//sum(CM_Coll60) as CM_Coll60, sum(LMAge90) as LMAge90, sum(CM_Coll90) as CM_Coll90
//from
//(
//-------------AG30Sales Start------------------
//select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as MTDAge30, 0 as CM_Coll30, 
//0 as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90 
//from 
//(
//select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
//from bllsysdb.dbo.t_salesInvoice 
//where invoicedate between  dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
//and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
//group by CustomerID 
//union all 
//select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
//from bllsysdb.dbo.t_salesInvoice  
//where invoicedate between  dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
//and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
//group by CustomerID 
//)as asg30 group by CustomerID
//-------------AG30Sayes End-------------------------
//union all
//-------------AG30 Coll Start---------------------
//select customerid, 0 as MTDAge30, sum(CreditAmount-DebitAmount)as CM_Coll30, 0 as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
//from 
//( 
//select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
//where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
// dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))  and getDate()
//group by customerid
//union all
//select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
//where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
// dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and getDate()
//group by customerid 
//)as Colle30  group by customerid
//-------------AG30 Coll End---------------------
//union all
//-------------AG60 Sales Start---------------------
//select CustomerID, 0 as MTDAge30,0 as CM_Coll30, isnull(sum(crAmount) - abs(sum(drAmount)),0) as LMAge60,0 as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
//from
//(
//select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
//from bllsysdb.dbo.t_salesInvoice 
//where invoicedate between  dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
// dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
//and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
//group by CustomerID 
//union all 
//select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
//from bllsysdb.dbo.t_salesInvoice  
//where invoicedate between  dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
// dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
//and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
//group by CustomerID
//) asg60 group by CustomerID
//-------------AG60 Sales End---------------------
//union all
//-------------AG60 Coll Start---------------------
//select customerid, 0 as MTDAge30,0 as CM_Coll30,0 as LMAge60, sum(CreditAmount-DebitAmount)as CM_Coll60, 0 as LMAge90, 0 as CM_Coll90
//from 
//( 
//select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
//where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
// dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and
// dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
//group by customerid
//union all
//select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
//where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
// dateadd(day, -60, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
// dateadd(day, -31, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
//group by customerid 
//)as Colle60  group by customerid
//-------------AG60 Coll End---------------------
//union all
//-------------AG90 Sales Start---------------------
//select CustomerID, 0 as MTDAge30,0 as CM_Coll30, 0 as LMAge60,0 as CM_Coll60, isnull(sum(crAmount) - abs(sum(drAmount)),0) as LMAge90, 0 as CM_Coll90
//from
//(
//select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
//from bllsysdb.dbo.t_salesInvoice 
//where invoicedate between   dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
// dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
//and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
//group by CustomerID 
//union all 
//select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
//from bllsysdb.dbo.t_salesInvoice  
//where invoicedate between  dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
// dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
//and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
//group by CustomerID
//) as asg90 group by CustomerID
//-------------AG90 Sales End---------------------
//union all
//-------------AG90 Coll Start---------------------
//select customerid, 0 as MTDAge30,0 as CM_Coll30, 0 as LMAge60,0 as CM_Coll60,0 as LMAge90, sum(CreditAmount-DebitAmount)as CM_Coll90
//from 
//( 
//select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
//where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
// dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
// dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
//group by customerid
//union all
//select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt
//where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)and ct.TranDate between 
// dateadd(day, -91, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and 
// dateadd(day, -61, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))
//group by customerid 
//)as Colle90  group by customerid
//-------------AG90 Coll End---------------------
//) as Tage group by CustomerID
//) as Age on Cust.CustomerID = Age.CustomerID
//left outer join
//(
//select CustomerID, sum(BGAmount) as BGAmount from t_CustomerBankGuarantee
//where expiryDate >= getdate() and isactive = 1
//group by CustomerID
//) as BG on Cust.CustomerID = BG.CustomerID
//)As Final group by RegionID,CustomerID,CustomerName,Isactive 
//) as xx 
//) as xy 
//) as ff group by RegionID, CustomerID, CustomerName,Isactive "; 
//---------------------------- Customer-----------------
//select RegionID,CustomerID,CustomerName,IsActive,sum(TotRec/1000)As TotRec, sum(ActRec/1000)as ActRec,
//sum(InActRec/1000)as InActRec,sum(CRLimit/1000)as CRLimit, sum(BGAmount/1000) as BGAmount, 
//sum(MTDAge/1000)as Age30Day,  
//sum(LMAge60/1000)as Age60Day, sum(LMAge90/1000)as Age90Day, sum(LMAge_grt90/1000)as AgeGrt90Day 
//from  
//(  
//select ChannelID,ChannelDescription,RegionID,RegionName,TerritoryID,TerrritoryName,Cust.CustomerID,CustomerName,TotRec,ActRec,InActRec, CRLimit,   
//isnull(MTDAge30,0)as MTDAge, isnull(LMAge60,0)as LMAge60, isnull(LMAge90,0) as LMAge90, isnull(LMAge_grt90,0) as LMAge_grt90,Isactive,isnull(BGAmount,0) as BGAmount   
//from  
//(  
//select ChannelID,ChannelDescription,RegionID,RegionName,TerritoryID,TerrritoryName,Q1.CustomerID,CustomerName,
//(ActRec+InActRec)as TotRec,ActRec,InActRec,isnull(CRLimit,0)As CRLimit,Isactive  
//from  
//(  
//select ChannelID,ChannelDescription,RegionID, RegionName,TerritoryID, TerrritoryName,  
//CustomerID,CustomerName,Isactive,ActRec,InActRec  
//from  
//(  
//select ChannelID,ChannelDescription,RegionID,RegionShortName as RegionName,TerritoryID, TerritoryShortName as TerrritoryName,  
//CustomerID,CustomerName,Isactive,isnull((CurrentBalance*-1),0) ActRec, 0 as InActRec  
//from BLLSysDB.dbo.v_Customerdetails   
//where Isactive=1  
//union all  
//select ChannelID,ChannelDescription,RegionID,RegionShortName as RegionName,TerritoryID, TerritoryShortName as TerrritoryName,  
//CustomerID,CustomerName,Isactive,0 as ActRec,isnull((CurrentBalance*-1),0) InActRec  
//from BLLSysDB.dbo.v_Customerdetails   
//where Isactive=0  
//) as Rec  
//)as Q1  
//left outer join  
//(  
//select distinct CustomerID,MinCreditLimit as CRLimit  
//from BLLSysDB.dbo.t_CustomerCreditLimit  

//where Convert(datetime,replace(convert(varchar, EffectiveDate,6),'','-'),1) <=  Convert(datetime,replace(convert(varchar, GETDATE(),6),'','-'),1)  
//and expiryDate> = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)  
//)as Q2 on Q1.CustomerID=Q2.CustomerID   
//)as Cust  
//left outer join  
//(  
//select CustomerID, sum(MTDAge30)as MTDAge30, sum(LMAge60) as LMAge60, sum(LMAge90) as LMAge90, sum(LMAge_grt90) as LMAge_grt90       
//from
//(
//select CustomerID, sum(round(DueAmount,0))as MTDAge30, 0 as LMAge60, 0 as LMAge90, 0 as LMAge_grt90       
//from BLLSysDB.dbo.t_SalesInvoice   
//where Invoicedate between dateadd(day,-30,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and getDate()   
//and DueAmount>0  
//group by CustomerID  
//union all
//select CustomerID, 0 as MTDAge30, sum(round(DueAmount,0))as LMAge60, 0 as LMAge90, 0 as LMAge_grt90  
//from BLLSysDB.dbo.t_SalesInvoice   
//where Invoicedate between  dateadd(day,-60,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) 
//and  dateadd(day,-31,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))
//and DueAmount>0  
//group by CustomerID 
//union all
//select CustomerID, 0 as MTDAge30, 0 as LMAge60, sum(round(DueAmount,0)) as LMAge90, 0 as LMAge_grt90     
//from BLLSysDB.dbo.t_SalesInvoice   
//where Invoicedate between dateadd(day,-90,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) 
//and  dateadd(day,-61,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) 
//and DueAmount>0  
//group by CustomerID
//union all
//select CustomerID,0 as MTDAge30, 0 as LMAge60, 0 as LMAge90, sum(round(DueAmount,0))as LMAge_grt90   
//from BLLSysDB.dbo.t_SalesInvoice   
//where Invoicedate < dateadd(day,-91,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))  
//and DueAmount>0  
//group by CustomerID
//) as Tage group by CustomerID
//)as Age on Cust.CustomerID=Age.CustomerID
//left outer join
//(
//select CustomerID, sum(BGAmount)as BGAmount from t_CustomerBankGuarantee
//where expiryDate >= getdate() and isactive=1
//group by CustomerID
//) as BG on Cust.CustomerID=BG.CustomerID 
//)As Final  
//group by RegionID,CustomerID,CustomerName,IsActive order by RegionID,CustomerID,CustomerName";

            // Modified Field 90day, 90Day +, BG Amount ---- Hrashid 15-Jan-2020
            //string sSQL = @"select AreaID,CustomerID,CustomerName,IsActive,sum(TotRec/1000)As TotRec, sum(ActRec/1000)as ActRec,
            //                sum(InActRec/1000)as InActRec,sum(CRLimit/1000)as CRLimit,
            //                sum(MTDAge/1000)as Age30Day,  
            //                sum(LMAge60/1000)as Age60Day, sum(LMAge90/1000)as Age90Day, sum(LMAge_grt90/1000)as AgeGrt90Day, sum(BGAmount/1000) as BGAmount  
            //                from  
            //                (  
            //                select ChannelID,ChannelDescription,AreaID,AreaName,TerritoryID,TerrritoryName,Cust.CustomerID,CustomerName,TotRec,ActRec,InActRec, CRLimit,   
            //                isnull(MTDAge30,0)as MTDAge, isnull(LMAge60,0)as LMAge60, isnull(LMAge90,0) as LMAge90, isnull(LMAge_grt90,0) as LMAge_grt90,Isactive,isnull(BGAmount,0) as BGAmount   
            //                from  
            //                (  
            //                select ChannelID,ChannelDescription,AreaID,AreaName,TerritoryID,TerrritoryName,Q1.CustomerID,CustomerName,
            //                (ActRec+InActRec)as TotRec,ActRec,InActRec,isnull(CRLimit,0)As CRLimit,Isactive  
            //                from  
            //                (  
            //                select ChannelID,ChannelDescription,AreaID, AreaName,TerritoryID, TerrritoryName,  
            //                CustomerID,CustomerName,Isactive,ActRec,InActRec  
            //                from  
            //                (  
            //                select ChannelID,ChannelDescription,AreaID,AreashortName as AreaName,TerritoryID, TerritoryShortName as TerrritoryName,  
            //                CustomerID,CustomerName,Isactive,isnull((CurrentBalance*-1),0) ActRec, 0 as InActRec  
            //                from BLLSysDB.dbo.v_Customerdetails   
            //                where Isactive=1  
            //                union all  
            //                select ChannelID,ChannelDescription,AreaID,AreashortName as AreaName,TerritoryID, TerritoryShortName as TerrritoryName,  
            //                CustomerID,CustomerName,Isactive,0 as ActRec,isnull((CurrentBalance*-1),0) InActRec  
            //                from BLLSysDB.dbo.v_Customerdetails   
            //                where Isactive=0  
            //                ) as Rec  
            //                )as Q1  
            //                left outer join  
            //                (  
            //                select distinct CustomerID,MinCreditLimit as CRLimit  
            //                from BLLSysDB.dbo.t_CustomerCreditLimit  

            //                where Convert(datetime,replace(convert(varchar, EffectiveDate,6),'','-'),1) <=  Convert(datetime,replace(convert(varchar, GETDATE(),6),'','-'),1)  
            //                and expiryDate> = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1)  
            //                )as Q2 on Q1.CustomerID=Q2.CustomerID   
            //                )as Cust  
            //                left outer join  
            //                (  
            //                select CustomerID, sum(MTDAge30)as MTDAge30, sum(LMAge60) as LMAge60, sum(LMAge90) as LMAge90, sum(LMAge_grt90) as LMAge_grt90       
            //                from
            //                (
            //                select CustomerID, sum(round(DueAmount,0))as MTDAge30, 0 as LMAge60, 0 as LMAge90, 0 as LMAge_grt90       
            //                from BLLSysDB.dbo.t_SalesInvoice   
            //                where Invoicedate between dateadd(day,-30,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and getDate()   
            //                and DueAmount>0  
            //                group by CustomerID  
            //                union all
            //                select CustomerID, 0 as MTDAge30, sum(round(DueAmount,0))as LMAge60, 0 as LMAge90, 0 as LMAge_grt90  
            //                from BLLSysDB.dbo.t_SalesInvoice   
            //                where Invoicedate between  dateadd(day,-60,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) 
            //                and  dateadd(day,-31,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))
            //                and DueAmount>0  
            //                group by CustomerID 
            //                union all
            //                select CustomerID, 0 as MTDAge30, 0 as LMAge60, sum(round(DueAmount,0)) as LMAge90, 0 as LMAge_grt90     
            //                from BLLSysDB.dbo.t_SalesInvoice   
            //                where Invoicedate between dateadd(day,-90,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) 
            //                and  dateadd(day,-61,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) 
            //                and DueAmount>0  
            //                group by CustomerID
            //                union all
            //                select CustomerID,0 as MTDAge30, 0 as LMAge60, 0 as LMAge90, sum(round(DueAmount,0))as LMAge_grt90   
            //                from BLLSysDB.dbo.t_SalesInvoice   
            //                where Invoicedate < dateadd(day,-91,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106))  
            //                and DueAmount>0  
            //                group by CustomerID
            //                ) as Tage group by CustomerID
            //                )as Age on Cust.CustomerID=Age.CustomerID
            //                left outer join
            //                (
            //                select CustomerID, sum(BGAmount)as BGAmount from t_CustomerBankGuarantee
            //                where expiryDate >= getdate() and isactive=1
            //                group by CustomerID
            //                ) as BG on Cust.CustomerID=BG.CustomerID 
            //                )As Final  
            //                group by AreaID,CustomerID,CustomerName,IsActive order by AreaID,CustomerID,CustomerName ";

            //sSQL = " select AreaID,CustomerID,CustomerName,IsActive,sum(TotRec/1000)As TotRec, sum(ActRec/1000)as ActRec,sum(InActRec/1000)as InActRec,sum(CRLimit/1000)as CRLimit,sum(MTDAge/1000)as Age30Day, " +
            //       "  sum(LMAge/1000)as Age60Day " +
            //       " from " +
            //       " ( " +
            //       " select ChannelID,ChannelDescription,AreaID,AreaName,TerritoryID,TerrritoryName,Cust.CustomerID,CustomerName,TotRec,ActRec,InActRec, CRLimit,  " +
            //       " isnull(MTDAge,0)as MTDAge, isnull(LMAge,0)as LMAge,Isactive " +
            //       " from " +
            //       " ( " +
            //       " select ChannelID,ChannelDescription,AreaID,AreaName,TerritoryID,TerrritoryName,Q1.CustomerID,CustomerName,(ActRec+InActRec)as TotRec,ActRec,InActRec,isnull(CRLimit,0)As CRLimit,Isactive " +
            //       " from " +
            //       " ( " +
            //       " select ChannelID,ChannelDescription,AreaID, AreaName,TerritoryID, TerrritoryName, " +
            //       " CustomerID,CustomerName,Isactive,ActRec,InActRec " +
            //       " from " +
            //       " ( " +
            //       " select ChannelID,ChannelDescription,AreaID,AreashortName as AreaName,TerritoryID, TerritoryShortName as TerrritoryName, " +
            //       " CustomerID,CustomerName,Isactive,isnull((CurrentBalance*-1),0) ActRec, 0 as InActRec " +
            //       " from BLLSysDB.dbo.v_Customerdetails  " +
            //       " where Isactive=1 " +
            //       " union all " +
            //       " select ChannelID,ChannelDescription,AreaID,AreashortName as AreaName,TerritoryID, TerritoryShortName as TerrritoryName, " +
            //       " CustomerID,CustomerName,Isactive,0 as ActRec,isnull((CurrentBalance*-1),0) InActRec " +
            //       " from BLLSysDB.dbo.v_Customerdetails  " +
            //       " where Isactive=0 " +
            //       " ) as Rec " +
            //       " )as Q1 " +
            //       " left outer join " +
            //       " ( " +
            //       " select distinct CustomerID,MinCreditLimit as CRLimit " +
            //       " from BLLSysDB.dbo.t_CustomerCreditLimit " +
            //       // " where Effectivedate <= getdate() and ExpiryDate >=getdate() " +
            //       " where Convert(datetime,replace(convert(varchar, EffectiveDate,6),'','-'),1) <=  Convert(datetime,replace(convert(varchar, GETDATE(),6),'','-'),1) " +
            //       " and expiryDate> = Convert(datetime, replace(convert(varchar, GETDATE(), 6), '', '-'), 1) " +
            //       " )as Q2 on Q1.CustomerID=Q2.CustomerID  " +
            //       " )as Cust " +
            //       " left outer join " +
            //       " ( " +
            //       " select isnull(Q1.CustomerID,Q2.CustomerID)as CustomerID, isnull(MTDAge,0)as MTDAge, isnull(LMAge,0)as LMAge " +
            //       " from " +
            //       " ( " +
            //       " select CustomerID, sum(round(DueAmount,0))as MTDAge " +
            //       " from BLLSysDB.dbo.t_SalesInvoice  " +
            //       " where Invoicedate between dateadd(day,-30,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and getDate()  " +
            //       " and DueAmount>0 " +
            //       " group by CustomerID " +
            //       " )as Q1 " +
            //       " full outer join " +
            //       " ( " +
            //       " select CustomerID, sum(round(DueAmount,0))as LMAge " +
            //       " from BLLSysDB.dbo.t_SalesInvoice  " +
            //       " where Invoicedate between dateadd(day,-60,CONVERT(VARCHAR(25),dateadd(month,-0,getdate()),106)) and getdate()   " +
            //       " and DueAmount>0 " +
            //       " group by CustomerID " +
            //       " )as Q2 on Q1.CustomerID=Q2.CustomerID " +
            //       " )as Age on Cust.CustomerID=Age.CustomerID " +
            //       " )As Final " +
            //       " group by AreaID,CustomerID,CustomerName,IsActive order by AreaID,CustomerID,CustomerName";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data oData = new Data();
                    oData.AreaID = reader["RegionID"].ToString();
                    oData.CustomerName = reader["CustomerName"].ToString();
                    oData.TotRecValue = Convert.ToDouble(reader["TotRec"]);
                    oData.CRLimitValue = Convert.ToDouble(reader["CRLimit"]);
                    oData.BGValue = Convert.ToDouble(reader["BGAmount"]);
                    oData.Age30DayValue = Convert.ToDouble(reader["Age30Day"]);
                    oData.Age60DayValue = Convert.ToDouble(reader["Age60Day"]);
                    oData.Age90DayValue = Convert.ToDouble(reader["Age90Day"]);
                    oData.AgeGrt90DayValue = Convert.ToDouble(reader["AgeGrt90Day"]);

                    oData.IsActive = reader["IsActive"].ToString();

                    InnerList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public List<Data> getResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.ChannelID = oData.ChannelID;               
                _oData.ChannelName = oData.ChannelName;
                _oData.TotRecValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TotRecValue));
                _oData.CRLimitValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CRLimitValue));
                _oData.BGValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.BGValue));
                _oData.Age30DayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Age30DayValue));
                _oData.Age60DayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Age60DayValue));
                _oData.Age90DayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Age90DayValue));
                _oData.AgeGrt90DayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.AgeGrt90DayValue));

                _oData.Value = "Success";

                eList.Add(_oData);
            }
            return eList;

        }
        public List<Data> getAreaResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.ChannelID = oData.ChannelID;
                _oData.AreaID = oData.AreaID;
                _oData.AreaName = oData.AreaName;
                _oData.Type = oData.Type;
                _oData.TotRecValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TotRecValue));
                _oData.CRLimitValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CRLimitValue));
                _oData.BGValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.BGValue));
                _oData.Age30DayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Age30DayValue));
                _oData.Age60DayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Age60DayValue));
                _oData.Age90DayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Age90DayValue));
                _oData.AgeGrt90DayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.AgeGrt90DayValue));

                _oData.Value = "Success";

                eList.Add(_oData);
            }
            return eList;

        }
        public List<Data> getCustomerResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.AreaID = oData.AreaID;               
                _oData.CustomerName = oData.CustomerName;
                _oData.TotRecValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TotRecValue));
                _oData.CRLimitValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CRLimitValue));
                _oData.BGValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.BGValue));
                _oData.Age30DayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Age30DayValue));
                _oData.Age60DayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Age60DayValue));
                _oData.Age90DayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Age90DayValue));
                _oData.AgeGrt90DayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.AgeGrt90DayValue));
                _oData.IsActive = oData.IsActive;
                _oData.Value = "Success";

                eList.Add(_oData);
            }
            return eList;

        }

    }
}
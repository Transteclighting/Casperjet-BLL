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
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.ANDROID;

public partial class jBLLDailySales : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            //string sUser = c.Request.Form["UserName"].Trim();

            string sUser = "hakim";

            string sDate = "";
            string sAndroidAppID = "";
            DateTime dDate = DateTime.Now.Date;
            if (c.Request.Form["Date"] != null)
            {
                sDate = c.Request.Form["Date"].Trim();
            }
            if (c.Request.Form["AndroidAppID"] != null)
            {
                sAndroidAppID = c.Request.Form["AndroidAppID"].Trim();
            }
            else
            {
                sAndroidAppID = Convert.ToString((int)Dictionary.AndroidAppID.CJ_Apps);
            }
            try
            {
                dDate = Convert.ToDateTime(sDate);
            }
            catch(Exception ex)
            {
                dDate = DateTime.Now.Date;
            }
            Datas oDatas = new Datas();

            DBController.Instance.OpenNewConnection();
            oDatas.GetData(dDate, sAndroidAppID, sUser);
            DBController.Instance.CloseConnection();
            Data _oData = new Data();
            _oData.InsertReportLog(sUser);

            string sOutput = JsonConvert.SerializeObject(oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());

        }
    } 
    public class Data
    {
        // C = Current, M = Month, P=Primary, T=Target, L=Last, Y=Year, A=Actual

        public string ID;
        public string AreaName;
        public string AreaID;
        public string TerritoryName;
        public string TerritoryID;
        public string ShortName;
        public string FullName;
        public string CustomerID;
        public string CustomerCode;
        public string Type;
        public string Value;
        public string IsActive;
        public string ActiveStatus;
        public string DSRMobileNo;
        public string DSRName;
        public string TSMMobileNo;
        public string TSMName;
        public string TSOMobileNo;
        public string TSOName;
        public string ResponsiblePerson;
        public string MobileNo;

        public double PriTarValue;
        public double PriActValue;
        public double SecTarValue;
        public double SecActValue;
        public double CollTarValue;
        public double CollCash;
        public double CollAdj;
        public double CollActValue;
        public string InvoiceDate;

        public string PriTarValueText;
        public string PriActValueText;
        public string SecTarValueText;
        public string SecActValueText;
        public string CollTarValueText;
        public string CollCashText;
        public string CollAdjText;
        public string CollActValueText;

        public string PriPercText;
        public string SecPercText;
        public string CollPercText;
        public string NameOfDayText;
        public string WeekNo;
        public string WeekText;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10041";
            string sReportName = "BLL-Daily Sales & Collection [210]";
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
        public void GetData(DateTime dDate, string sAndroidAppID, string sUser)
        {
            TELLib _oTELLib = new TELLib();

            DateTime dFromDate = _oTELLib.FirstDayofMonth(dDate);
            DateTime dToDate = dDate.AddDays(1);

            DSBLLDailySales oDSNational = new DSBLLDailySales();
            DSBLLDailySales oDSNationalWeek = new DSBLLDailySales();

            DSBLLDailySales oDSArea = new DSBLLDailySales();
            DSBLLDailySales oDSAreaWeek = new DSBLLDailySales();

            DSBLLDailySales oDSTerritory = new DSBLLDailySales();
            DSBLLDailySales oDSTerritoryWeek = new DSBLLDailySales();

            DSBLLDailySales oDSCustomer = new DSBLLDailySales();
            DSBLLDailySales oDSCustomerWeek = new DSBLLDailySales();

            DSBLLDailySales oDSNationalSumm = new DSBLLDailySales();
            DSBLLDailySales oDSAreaSumm = new DSBLLDailySales();
            DSBLLDailySales oDSTerritorySumm = new DSBLLDailySales();
            DSBLLDailySales oDSCustomerSumm = new DSBLLDailySales();

            DSBLLDailySales oDSAll = new DSBLLDailySales();

            oDSNationalSumm = GetRowDataSummary(dFromDate, dToDate, "National", sAndroidAppID, sUser);
            oDSNational = GetRowData(dFromDate, dToDate, "National", sAndroidAppID, sUser);
            oDSNationalWeek = GetRowDataWeek(oDSNational, dFromDate, "National");//Week

            oDSAreaSumm = GetRowDataSummary(dFromDate, dToDate, "Area", sAndroidAppID, sUser);
            oDSArea = GetRowData(dFromDate, dToDate, "Area", sAndroidAppID, sUser);
            oDSAreaWeek = GetWeekDataArea(dFromDate, dToDate, "Area", sAndroidAppID, sUser);//Week

            oDSTerritorySumm = GetRowDataSummary(dFromDate, dToDate, "Territory", sAndroidAppID, sUser);
            oDSTerritory = GetRowData(dFromDate, dToDate, "Territory", sAndroidAppID, sUser);
            oDSTerritoryWeek = GetWeekDataTerritory(dFromDate, dToDate, "Territory", sAndroidAppID, sUser);//Week
            

            oDSCustomerSumm = GetRowDataSummary(dFromDate, dToDate, "Customer", sAndroidAppID, sUser);
            oDSCustomer = GetRowData(dFromDate, dToDate, "Customer", sAndroidAppID, sUser);
            oDSCustomerWeek = GetWeekDataDistributor(dFromDate, dToDate, "Customer", sAndroidAppID, sUser);//week
            

            oDSAll.Merge(oDSNationalSumm);
            oDSAll.Merge(oDSNationalWeek);//Week
            oDSAll.Merge(oDSNational);

            oDSAll.Merge(oDSAreaSumm);
            oDSAll.Merge(oDSAreaWeek);//Week
            oDSAll.Merge(oDSArea);

            oDSAll.Merge(oDSTerritorySumm);
            oDSAll.Merge(oDSTerritoryWeek);//week
            oDSAll.Merge(oDSTerritory);

            oDSAll.Merge(oDSCustomerSumm);
            oDSAll.Merge(oDSCustomerWeek);//week
            oDSAll.Merge(oDSCustomer);

            oDSAll.AcceptChanges();

            Data _oData;

            foreach (DSBLLDailySales.DailySalesRow oDailySalesRow in oDSAll.DailySales)
            {
                _oData = new Data();

                _oData.Type = oDailySalesRow.Type;
                _oData.ID = oDailySalesRow.ID;
                _oData.PriActValue = oDailySalesRow.PriActValue;
                _oData.SecActValue = oDailySalesRow.SecActValue;
                _oData.PriTarValue = oDailySalesRow.PriTarValue;
                _oData.SecTarValue = oDailySalesRow.SecTarValue;
                _oData.CollTarValue = oDailySalesRow.CollTarValue;
                _oData.CollCash = oDailySalesRow.CollCash;
                _oData.CollAdj = oDailySalesRow.CollAdj;
                _oData.CollActValue = oDailySalesRow.CollActValue;
                _oData.InvoiceDate = oDailySalesRow.Date;

                InnerList.Add(_oData);
            }

        }
        private DSBLLDailySales GetRowDataSummary(DateTime dFromDate, DateTime dToDate, string sType, string sAndroidAppID, string sUser)
        {
            DSBLLDailySales oDSBLLDailySales = new DSBLLDailySales();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            if (sType == "National")
            {
                sSQL = " Select 'National' as Type, 0 as ID, ";
            }
            else if (sType == "Area")
            {
                sSQL = " Select 'Area' as Type, AreaID as ID, ";
            }
            else if (sType == "Territory")
            {
                sSQL = " Select 'Territory' as Type, TerritoryID as ID, ";
            }
            else
            {
                sSQL = " Select 'Customer' as Type, a.CustomerID as ID, ";
            }
            sSQL = sSQL + " 'Total' as InvoiceDate, Sum(PriActual) as PriActual, Sum(SecActual) as SecActual, Sum(PriTarget) as PriTarget, Sum(SecTarget) as SecTarget, Sum(CollTarget) as CollTarget, Sum(CollCash) as CollCash, Sum(CollAdj) as CollAdj, (Sum(CollCash)+Sum(CollAdj)) as CollActual from " +
                   " ( " +
                   " Select CustomerID, InvoiceDate, Sum(PriActual) as PriActual, Sum(SecActual) as SecActual, Sum(PriTarget) as PriTarget, " +
                   " Sum(SecTarget) as SecTarget, Sum(CollTarget) as CollTarget, Sum(CollCash) as CollCash, Sum(CollAdj) as CollAdj, (Sum(CollCash)+Sum(CollAdj)) as CollActual from " +
                   " ( " +
                // ----Primary ----
                   " select CustomerID, InvoiceDate, sum (Amount)as PriActual,0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj  " +
                   " from " +
                   " (  " +
                   " select CustomerID,InvoiceDate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount  " +
                   " from  " +
                   " ( " +
                   " select a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1) as InvoiceDate, sum(invoiceamount) as crAmount, 0 as drAmount " +
                   " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " +
                   " where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                   " and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2)  " +
                   " group by a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1)  " +
                   " union all  " +
                   " select a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1) as InvoiceDate,0 as crAmount,sum(invoiceamount) as drAmount " +
                   " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " +
                   " where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                   " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                   " group by a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1)  " +
                   " )as p2  " +
                   " group by CustomerID,InvoiceDate " +
                   " ) as TELBLL " +
                   " group by CustomerID,InvoiceDate " +
                   " UNION ALL " +
               
                   // ------- Start Of Secondary -----------

                   " select  CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as PriActual, sum(Amount * .95 )as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj " +
                   " from DWDB.dbo.t_BLLSecondarySales " +
                   " where Trandate between '" + dFromDate + "' and '" + dToDate + "' and Trandate < '" + dToDate + "' " +
                   " group by CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +

                    //----------Collection Target-------
                  " UNION ALL " +
                  " select CustomerID, TargetDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, Sum(Amount) as CollTarget, " +
                  " 0 as CollCash, 0 as CollAdj from BLLSysDB.dbo.t_CalendarSales a " +
                  " Left Outer JOIN  " +
                  " BLLSysDB.dbo.t_PlanDailyCollection b ON a.TDate=b.TargetDate " +
                  " Where Year(a.TDate)=" + nYear + " and Month(a.TDate)=" + nMonth + " and CustomerID is not null " +
                  " Group by CustomerID, TargetDate " +

                //--- Primary Target-------
                   " UNION ALL " +
                   " select CustomerID, TDate, 0 as PriActual, 0 as SecActual, round(sum(TGTTO)/(select Count(*) from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1),0) as PriTarget , " +
                   " 0 As SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj  " +
                   " from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLSysDB.dbo.t_Customer b, " +
                   " (select TDate from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1) c " +
                   " where TGTDate between '" + dFromDate + "' and '" + dToDate + "' and TGTDate < '" + dToDate + "'  " +
                   " and a.CustomerCode=b.CustomerCode  " +
                   " group by b.CustomerID, TDate  " +

                   //--- Secondary Target-------
                   " UNION ALL " +
                   " select CustomerID, TDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget , " +
                   " round(sum(TSMTGTTO)/(select Count(*) from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1),0) As SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj  " +
                   " from BLLSysDB.dbo.t_DMSTargetTo a, BLLSysDB.dbo.t_Customer b, " +
                   " (select TDate from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1) c " +
                   " where TGTDate between '" + dFromDate + "' and '" + dToDate + "' and TGTDate < '" + dToDate + "'  " +
                   " and a.DistributorID=b.CustomerID  " +
                   " group by b.CustomerID, TDate  " +

                    //---------------Collection Start Cash---------
                   " UNION ALL " +
                   " select CustomerID,TranDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, sum(CreditAmount-DebitAmount) as CollCash, 0 as CollAdj" +
                   " from  " +
                   " (  " +
                   " select ct.CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27) and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.Customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +
                   " UNION ALL " +
                   " select ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28)and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 "+
                   " group by ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1)  " +
                   " )as Colle  " +
                   " group by CustomerID,TranDate " +
                //---------------Collection Start Adjustment---------
                   " UNION ALL " +
                   " select CustomerID,TranDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, sum(CreditAmount-DebitAmount) as CollAdj" +
                   " from  " +
                   " (  " +
                   " select ct.CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(19,21) and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.Customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +
                   " UNION ALL " +
                   " select ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(20)and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1)  " +
                   " )as Colle  " +
                   " group by CustomerID, TranDate " +
                   " ) Final Group by CustomerID,InvoiceDate " +
                   " ) a, BLLSysDB.dbo.v_CustomerDetails b Where a.CustomerID=b.CustomerID ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUser + "')) ";
            }
            if (sType == "National")
            {
                //sSQL = sSQL + " Group by InvoiceDate ";
            }
            else if (sType == "Area")
            {
                sSQL = sSQL + " Group by AreaID ";
            }
            else if (sType == "Territory")
            {
                sSQL = sSQL + " Group by TerritoryID ";
            }
            else
            {
                sSQL = sSQL + " Group by a.CustomerID ";
            }

            //sSQL = sSQL + " order by InvoiceDate ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader() ;
                while (reader.Read())
                {
                    DSBLLDailySales.DailySalesRow oDailySalesRow = oDSBLLDailySales.DailySales.NewDailySalesRow();
                    Data oData = new Data();

                    oDailySalesRow.Type = reader["Type"].ToString();
                    oDailySalesRow.ID = reader["ID"].ToString();

                    if (reader["PriActual"] != DBNull.Value)
                        oDailySalesRow.PriActValue = Convert.ToDouble(reader["PriActual"]);
                    else oDailySalesRow.PriActValue = 0;

                    if (reader["SecActual"] != DBNull.Value)
                        oDailySalesRow.SecActValue = Convert.ToDouble(reader["SecActual"]);
                    else oDailySalesRow.SecActValue = 0;

                    if (reader["PriTarget"] != DBNull.Value)
                        oDailySalesRow.PriTarValue = Convert.ToDouble(reader["PriTarget"]);
                    else oDailySalesRow.PriTarValue = 0;

                    if (reader["SecTarget"] != DBNull.Value)
                        oDailySalesRow.SecTarValue = Convert.ToDouble(reader["SecTarget"]);
                    else oDailySalesRow.SecTarValue = 0;

                    if (reader["CollTarget"] != DBNull.Value)
                        oDailySalesRow.CollTarValue = Convert.ToDouble(reader["CollTarget"]);
                    else oDailySalesRow.CollTarValue = 0;

                    if (reader["CollActual"] != DBNull.Value)
                        oDailySalesRow.CollActValue = Convert.ToDouble(reader["CollActual"]);
                    else oDailySalesRow.CollActValue = 0;

                    if (reader["CollCash"] != DBNull.Value)
                        oDailySalesRow.CollCash = Convert.ToDouble(reader["CollCash"]);
                    else oDailySalesRow.CollCash = 0;

                    if (reader["CollAdj"] != DBNull.Value)
                        oDailySalesRow.CollAdj = Convert.ToDouble(reader["CollAdj"]);
                    else oDailySalesRow.CollAdj = 0;

                    oDailySalesRow.Date = reader["InvoiceDate"].ToString();

                    oDSBLLDailySales.DailySales.AddDailySalesRow(oDailySalesRow);
                    oDSBLLDailySales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLDailySales;
        }

        private DSBLLDailySales GetRowDataWeek(DSBLLDailySales oDSBLLDailySales, DateTime dDate, string sType)
        {
            DSBLLDailySales oDSBLLDailySalesWeek = new DSBLLDailySales();
            try
            {
                Datas _oDatas = new Datas();
                _oDatas.GetWeekNo(dDate);

                foreach (Data oData in _oDatas)
                {

                    DSBLLDailySales _oDSBLLDailySales = new DSBLLDailySales();
                    DataRow[] oDR = oDSBLLDailySales.DailySales.Select(" WeekNo= '" + oData.WeekNo + "'");
                    _oDSBLLDailySales.Merge(oDR);
                    _oDSBLLDailySales.AcceptChanges();

                    double _PriActValue = 0;
                    double _SecActValue = 0;
                    double _PriTarValue = 0;
                    double _SecTarValue = 0;
                    double _CollTarValue = 0;
                    double _CollActValue = 0;
                    double _CollCash = 0;
                    double _CollAdj = 0;

                    foreach (DSBLLDailySales.DailySalesRow _oDailySalesRow in _oDSBLLDailySales.DailySales)
                    {


                        _PriActValue = _PriActValue + _oDailySalesRow.PriActValue;
                        _SecActValue = _SecActValue + _oDailySalesRow.SecActValue;
                        _PriTarValue = _PriTarValue + _oDailySalesRow.PriTarValue;
                        _SecTarValue = _SecTarValue + _oDailySalesRow.SecTarValue;
                        _CollTarValue = _CollTarValue + _oDailySalesRow.CollTarValue;
                        _CollActValue = _CollActValue + _oDailySalesRow.CollActValue;
                        _CollCash = _CollCash + _oDailySalesRow.CollCash;
                        _CollAdj = _CollAdj + _oDailySalesRow.CollAdj;

                    }

                    DSBLLDailySales.DailySalesRow oDailySalesRow = oDSBLLDailySalesWeek.DailySales.NewDailySalesRow();

                    oDailySalesRow.ID = "0";
                    oDailySalesRow.Type = "National";

                    oDailySalesRow.Date = oData.WeekText;
                    oDailySalesRow.PriActValue = _PriActValue;
                    oDailySalesRow.SecActValue = _SecActValue;
                    oDailySalesRow.PriTarValue = _PriTarValue;
                    oDailySalesRow.SecTarValue = _SecTarValue;
                    oDailySalesRow.CollTarValue = _CollTarValue;
                    oDailySalesRow.CollActValue = _CollActValue;
                    oDailySalesRow.CollCash = _CollCash;
                    oDailySalesRow.CollAdj = _CollAdj;

                    oDSBLLDailySalesWeek.DailySales.AddDailySalesRow(oDailySalesRow);
                    oDSBLLDailySalesWeek.AcceptChanges();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLDailySalesWeek;
        }

        private DSBLLDailySales GetRowData(DateTime dFromDate, DateTime dToDate, string sType, string sAndroidAppID, string sUser)
        {
            DSBLLDailySales oDSBLLDailySales = new DSBLLDailySales();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            if (sType == "National")
            {
                sSQL = " Select 'National' as Type, 0 as ID, ";
            }
            else if (sType == "Area")
            {
                sSQL = " Select 'Area' as Type, AreaID as ID, ";
            }
            else if (sType == "Territory")
            {
                sSQL = " Select 'Territory' as Type, TerritoryID as ID, ";
            }
            else
            {
                sSQL = " Select 'Customer' as Type, a.CustomerID as ID, ";
            }
            sSQL = sSQL + " WeekNo, InvoiceDate, Sum(PriActual) as PriActual, Sum(SecActual) as SecActual, Sum(PriTarget) as PriTarget, Sum(SecTarget) as SecTarget, Sum(CollTarget) as CollTarget, Sum(CollCash) as CollCash, Sum(CollAdj) as CollAdj, (Sum(CollCash) + Sum(CollAdj)) as CollActual from " +
                   " ( " +
                   " Select CustomerID, InvoiceDate, Sum(PriActual) as PriActual, Sum(SecActual) as SecActual, Sum(PriTarget) as PriTarget, " +
                   " Sum(SecTarget) as SecTarget, Sum(CollTarget) as CollTarget, Sum(CollCash) as CollCash, Sum(CollAdj) as CollAdj,  (Sum(CollCash) + Sum(CollAdj)) as CollActual from " +
                   " ( " +
                // ----Primary ----
                   " select CustomerID, InvoiceDate, sum (Amount)as PriActual,0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj  " +
                   " from " +
                   " (  " +
                   " select CustomerID,InvoiceDate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount  " +
                   " from  " +
                   " ( " +
                   " select a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1) as InvoiceDate, sum(invoiceamount) as crAmount, 0 as drAmount " +
                   " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " +
                   " where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                   " and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2)  " +
                   " group by a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1)  " +
                   " union all  " +
                   " select a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1) as InvoiceDate,0 as crAmount,sum(invoiceamount) as drAmount " +
                   " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " +
                   " where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                   " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                   " group by a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1)  " +
                   " )as p2  " +
                   " group by CustomerID,InvoiceDate " +
                   " ) as TELBLL " +
                   " group by CustomerID,InvoiceDate " +
                   " UNION ALL " +
                // -------Start Of Secondary-----------

                   " select  CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as PriActual, sum(Amount * .95)as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj " +
                   " from DWDB.dbo.t_BLLSecondarySales " +
                   " where Trandate between '" + dFromDate + "' and '" + dToDate + "' and Trandate < '" + dToDate + "' " +
                   " group by CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +

                    //----------Collection Target-------
                  " UNION ALL " +
                  " select CustomerID, TargetDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, Sum(Amount) as CollTarget, " +
                  " 0 as CollCash, 0 as CollAdj from BLLSysDB.dbo.t_CalendarSales a " +
                  " Left Outer JOIN  " +
                  " BLLSysDB.dbo.t_PlanDailyCollection b ON a.TDate=b.TargetDate " +
                  " Where Year(a.TDate)=" + nYear + " and Month(a.TDate)=" + nMonth + " and CustomerID is not null " +
                  " Group by CustomerID, TargetDate " +

                   " UNION ALL " +
                   " select CustomerID, TDate, 0 as PriActual, 0 as SecActual, round(sum(TGTTO)/(select Count(*) from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1),0) as PriTarget , " +
                   " round(sum(SecTGTTO)/(select Count(*) from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1),0) As SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj  " +
                   " from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLSysDB.dbo.t_Customer b, " +
                   " (select TDate from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1) c " +
                   " where TGTDate between '" + dFromDate + "' and '" + dToDate + "' and TGTDate < '" + dToDate + "'  " +
                   " and a.CustomerCode=b.CustomerCode  " +
                   " group by b.CustomerID, TDate  " +

                    //---------------Collection Start Cash---------
                   " UNION ALL " +
                   " select CustomerID,TranDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, sum(CreditAmount-DebitAmount)as CollCash, 0 as CollAdj " +
                   " from  " +
                   " (  " +
                   " select ct.CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust  " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27) and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.Customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +
                   " UNION ALL " +
                   " select ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust  " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28)and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1)  " +
                   " )as Colle  " +
                   " group by CustomerID,TranDate " +
                //---------------Collection Start Adjustment---------
                   " UNION ALL " +
                   " select CustomerID,TranDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, sum(CreditAmount-DebitAmount) as CollAdj " +
                   " from  " +
                   " (  " +
                   " select ct.CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust  " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(19,21) and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.Customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +
                   " UNION ALL " +
                   " select ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust  " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(20)and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1)  " +
                   " )as Colle  " +
                   " group by CustomerID, TranDate " +
                   " ) Final Group by CustomerID,InvoiceDate " +
                   " ) a, BLLSysDB.dbo.v_CustomerDetails b, dbo.t_CalendarWeek c Where a.CustomerID=b.CustomerID and InvoiceDate between FromDate and ToDate ";

            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUser + "')) ";
            }

            if (sType == "National")
            {
                sSQL = sSQL + " Group by WeekNo, InvoiceDate ";
            }
            else if (sType == "Area")
            {
                sSQL = sSQL + " Group by AreaID, WeekNo, InvoiceDate ";
            }
            else if (sType == "Territory")
            {
                sSQL = sSQL + " Group by TerritoryID, WeekNo, InvoiceDate ";
            }
            else
            {
                sSQL = sSQL + " Group by a.CustomerID, WeekNo, InvoiceDate ";
            }

            sSQL = sSQL + " order by WeekNo, InvoiceDate ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLDailySales.DailySalesRow oDailySalesRow = oDSBLLDailySales.DailySales.NewDailySalesRow();
                    Data oData = new Data();

                    oDailySalesRow.Type = reader["Type"].ToString();
                    oDailySalesRow.ID = reader["ID"].ToString();

                    if (reader["PriActual"] != DBNull.Value)
                        oDailySalesRow.PriActValue = Convert.ToDouble(reader["PriActual"]);
                    else oDailySalesRow.PriActValue = 0;

                    if (reader["SecActual"] != DBNull.Value)
                        oDailySalesRow.SecActValue = Convert.ToDouble(reader["SecActual"]);
                    else oDailySalesRow.SecActValue = 0;

                    if (reader["PriTarget"] != DBNull.Value)
                        oDailySalesRow.PriTarValue = Convert.ToDouble(reader["PriTarget"]);
                    else oDailySalesRow.PriTarValue = 0;

                    if (reader["SecTarget"] != DBNull.Value)
                        oDailySalesRow.SecTarValue = Convert.ToDouble(reader["SecTarget"]);
                    else oDailySalesRow.SecTarValue = 0;

                    if (reader["CollTarget"] != DBNull.Value)
                        oDailySalesRow.CollTarValue = Convert.ToDouble(reader["CollTarget"]);
                    else oDailySalesRow.CollTarValue = 0;

                    if (reader["CollActual"] != DBNull.Value)
                        oDailySalesRow.CollActValue = Convert.ToDouble(reader["CollActual"]);
                    else oDailySalesRow.CollActValue = 0;

                    if (reader["CollCash"] != DBNull.Value)
                        oDailySalesRow.CollCash = Convert.ToDouble(reader["CollCash"]);
                    else oDailySalesRow.CollCash = 0;

                    if (reader["CollAdj"] != DBNull.Value)
                        oDailySalesRow.CollAdj = Convert.ToDouble(reader["CollAdj"]);
                    else oDailySalesRow.CollAdj = 0;

                    oDailySalesRow.Date = Convert.ToDateTime(reader["InvoiceDate"]).ToString("dd-MMM-yyyy");
                    oDailySalesRow.WeekNo = reader["WeekNo"].ToString();

                    oDSBLLDailySales.DailySales.AddDailySalesRow(oDailySalesRow);
                    oDSBLLDailySales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLDailySales;
        }

        private DSBLLDailySales GetWeekDataArea(DateTime dFromDate, DateTime dToDate, string sType, string sAndroidAppID, string sUser)
        {
            DSBLLDailySales oDSBLLDailySales = new DSBLLDailySales();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL = sSQL + " Select 'Area' as Type, AreaID as ID, WeekNo, Sum(PriActual) as PriActual, Sum(SecActual) as SecActual, Sum(PriTarget) as PriTarget, Sum(SecTarget) as SecTarget, Sum(CollTarget) as CollTarget, Sum(CollCash) as CollCash, Sum(CollAdj) as CollAdj, (Sum(CollCash) + Sum(CollAdj)) as CollActual from " +
                   " ( " +
                   " Select CustomerID, InvoiceDate, Sum(PriActual) as PriActual, Sum(SecActual) as SecActual, Sum(PriTarget) as PriTarget, " +
                   " Sum(SecTarget) as SecTarget, Sum(CollTarget) as CollTarget, Sum(CollCash) as CollCash, Sum(CollAdj) as CollAdj,  (Sum(CollCash) + Sum(CollAdj)) as CollActual from " +
                   " ( " +
                // ----Primary ----
                   " select CustomerID, InvoiceDate, sum (Amount)as PriActual,0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj  " +
                   " from " +
                   " (  " +
                   " select CustomerID,InvoiceDate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount  " +
                   " from  " +
                   " ( " +
                   " select a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1) as InvoiceDate, sum(invoiceamount) as crAmount, 0 as drAmount " +
                   " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " +
                   " where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                   " and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2)  " +
                   " group by a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1)  " +
                   " union all  " +
                   " select a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1) as InvoiceDate,0 as crAmount,sum(invoiceamount) as drAmount " +
                   " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " +
                   " where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                   " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                   " group by a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1)  " +
                   " )as p2  " +
                   " group by CustomerID,InvoiceDate " +
                   " ) as TELBLL " +
                   " group by CustomerID,InvoiceDate " +
                   " UNION ALL " +
                // -------Start Of Secondary-----------

                   " select  CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as PriActual, sum(Amount * .95)as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj " +
                   " from DWDB.dbo.t_BLLSecondarySales " +
                   " where Trandate between '" + dFromDate + "' and '" + dToDate + "' and Trandate < '" + dToDate + "' " +
                   " group by CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +

                    //----------Collection Target-------
                  " UNION ALL " +
                  " select CustomerID, TargetDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, Sum(Amount) as CollTarget, " +
                  " 0 as CollCash, 0 as CollAdj from BLLSysDB.dbo.t_CalendarSales a " +
                  " Left Outer JOIN  " +
                  " BLLSysDB.dbo.t_PlanDailyCollection b ON a.TDate=b.TargetDate " +
                  " Where Year(a.TDate)=" + nYear + " and Month(a.TDate)=" + nMonth + " and CustomerID is not null " +
                  " Group by CustomerID, TargetDate " +

                   " UNION ALL " +
                   " select CustomerID, TDate, 0 as PriActual, 0 as SecActual, round(sum(TGTTO)/(select Count(*) from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1),0) as PriTarget , " +
                   " round(sum(SecTGTTO)/(select Count(*) from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1),0) As SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj  " +
                   " from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLSysDB.dbo.t_Customer b, " +
                   " (select TDate from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1) c " +
                   " where TGTDate between '" + dFromDate + "' and '" + dToDate + "' and TGTDate < '" + dToDate + "'  " +
                   " and a.CustomerCode=b.CustomerCode  " +
                   " group by b.CustomerID, TDate  " +

                    //---------------Collection Start Cash---------
                   " UNION ALL " +
                   " select CustomerID,TranDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, sum(CreditAmount-DebitAmount)as CollCash, 0 as CollAdj " +
                   " from  " +
                   " (  " +
                   " select ct.CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt , BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27) and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "'  and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.Customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +
                   " UNION ALL " +
                   " select ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28)and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1)  " +
                   " )as Colle  " +
                   " group by CustomerID,TranDate " +
                //---------------Collection Start Adjustment---------
                   " UNION ALL " +
                   " select CustomerID,TranDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, sum(CreditAmount-DebitAmount) as CollAdj " +
                   " from  " +
                   " (  " +
                   " select ct.CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(19,21) and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "'  and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.Customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +
                   " UNION ALL " +
                   " select ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(20)and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1)  " +
                   " )as Colle  " +
                   " group by CustomerID, TranDate " +
                   " ) Final Group by CustomerID,InvoiceDate " +
                   " ) a, BLLSysDB.dbo.v_CustomerDetails b, (Select ('W-'+CONVERT(VARCHAR(2),WeekNo)+' [' + CONVERT(VARCHAR(2),DATEPART(d,FromDate)) + '-' "+
                   " + CONVERT(VARCHAR(2),DATEPART(d,ToDate))+']') as WeekNo, FromDate, ToDate from dbo.t_CalendarWeek) c Where a.CustomerID=b.CustomerID and InvoiceDate between FromDate and ToDate ";

            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUser + "')) ";
            }


            sSQL = sSQL + " Group by AreaID, WeekNo ";
           

            sSQL = sSQL + " order by WeekNo ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLDailySales.DailySalesRow oDailySalesRow = oDSBLLDailySales.DailySales.NewDailySalesRow();
                    Data oData = new Data();

                    oDailySalesRow.Type = reader["Type"].ToString();
                    oDailySalesRow.ID = reader["ID"].ToString();
                    oDailySalesRow.PriActValue = Convert.ToDouble(reader["PriActual"]);
                    oDailySalesRow.SecActValue = Convert.ToDouble(reader["SecActual"]);
                    oDailySalesRow.PriTarValue = Convert.ToDouble(reader["PriTarget"]);
                    oDailySalesRow.SecTarValue = Convert.ToDouble(reader["SecTarget"]);
                    oDailySalesRow.CollTarValue = Convert.ToDouble(reader["CollTarget"]);
                    oDailySalesRow.CollActValue = Convert.ToDouble(reader["CollActual"]);
                    oDailySalesRow.CollCash = Convert.ToDouble(reader["CollCash"]);
                    oDailySalesRow.CollAdj = Convert.ToDouble(reader["CollAdj"]);
                    oDailySalesRow.WeekNo = reader["WeekNo"].ToString();
                    oDailySalesRow.Date = oDailySalesRow.WeekNo;

                    oDSBLLDailySales.DailySales.AddDailySalesRow(oDailySalesRow);
                    oDSBLLDailySales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLDailySales;
        }

        private DSBLLDailySales GetWeekDataTerritory(DateTime dFromDate, DateTime dToDate, string sType, string sAndroidAppID, string sUser)
        {
            DSBLLDailySales oDSBLLDailySales = new DSBLLDailySales();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL = sSQL + " Select 'Territory' as Type, TerritoryID as ID, WeekNo, Sum(PriActual) as PriActual, Sum(SecActual) as SecActual, Sum(PriTarget) as PriTarget, Sum(SecTarget) as SecTarget, Sum(CollTarget) as CollTarget, Sum(CollCash) as CollCash, Sum(CollAdj) as CollAdj, (Sum(CollCash) + Sum(CollAdj)) as CollActual from " +
                   " ( " +
                   " Select CustomerID, InvoiceDate, Sum(PriActual) as PriActual, Sum(SecActual) as SecActual, Sum(PriTarget) as PriTarget, " +
                   " Sum(SecTarget) as SecTarget, Sum(CollTarget) as CollTarget, Sum(CollCash) as CollCash, Sum(CollAdj) as CollAdj,  (Sum(CollCash) + Sum(CollAdj)) as CollActual from " +
                   " ( " +
                // ----Primary ----
                   " select CustomerID, InvoiceDate, sum (Amount)as PriActual,0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj  " +
                   " from " +
                   " (  " +
                   " select CustomerID,InvoiceDate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount  " +
                   " from  " +
                   " ( " +
                   " select a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1) as InvoiceDate, sum(invoiceamount) as crAmount, 0 as drAmount " +
                   " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " +
                   " where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                   " and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2)  " +
                   " group by a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1)  " +
                   " union all  " +
                   " select a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1) as InvoiceDate,0 as crAmount,sum(invoiceamount) as drAmount " +
                   " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " +
                   " where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                   " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                   " group by a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1)  " +
                   " )as p2  " +
                   " group by CustomerID,InvoiceDate " +
                   " ) as TELBLL " +
                   " group by CustomerID,InvoiceDate " +
                   " UNION ALL " +
                // -------Start Of Secondary-----------

                   " select  CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as PriActual, sum(Amount * .95)as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj " +
                   " from DWDB.dbo.t_BLLSecondarySales " +
                   " where Trandate between '" + dFromDate + "' and '" + dToDate + "' and Trandate < '" + dToDate + "' " +
                   " group by CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +

                    //----------Collection Target-------
                  " UNION ALL " +
                  " select CustomerID, TargetDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, Sum(Amount) as CollTarget, " +
                  " 0 as CollCash, 0 as CollAdj from BLLSysDB.dbo.t_CalendarSales a " +
                  " Left Outer JOIN  " +
                  " BLLSysDB.dbo.t_PlanDailyCollection b ON a.TDate=b.TargetDate " +
                  " Where Year(a.TDate)=" + nYear + " and Month(a.TDate)=" + nMonth + " and CustomerID is not null " +
                  " Group by CustomerID, TargetDate " +

                   " UNION ALL " +
                   " select CustomerID, TDate, 0 as PriActual, 0 as SecActual, round(sum(TGTTO)/(select Count(*) from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1),0) as PriTarget , " +
                   " round(sum(SecTGTTO)/(select Count(*) from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1),0) As SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj  " +
                   " from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLSysDB.dbo.t_Customer b, " +
                   " (select TDate from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1) c " +
                   " where TGTDate between '" + dFromDate + "' and '" + dToDate + "' and TGTDate < '" + dToDate + "'  " +
                   " and a.CustomerCode=b.CustomerCode  " +
                   " group by b.CustomerID, TDate  " +

                    //---------------Collection Start Cash---------
                   " UNION ALL " +
                   " select CustomerID,TranDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, sum(CreditAmount-DebitAmount)as CollCash, 0 as CollAdj " +
                   " from  " +
                   " (  " +
                   " select ct.CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27) and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.Customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +
                   " UNION ALL " +
                   " select ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28)and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1)  " +
                   " )as Colle  " +
                   " group by CustomerID,TranDate " +
                //---------------Collection Start Adjustment---------
                   " UNION ALL " +
                   " select CustomerID,TranDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, sum(CreditAmount-DebitAmount) as CollAdj " +
                   " from  " +
                   " (  " +
                   " select ct.CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(19,21) and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "'  and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.Customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +
                   " UNION ALL " +
                   " select ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(20)and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1)  " +
                   " )as Colle  " +
                   " group by CustomerID, TranDate " +
                   " ) Final Group by CustomerID,InvoiceDate " +
                   " ) a, BLLSysDB.dbo.v_CustomerDetails b, (Select ('W-'+CONVERT(VARCHAR(2),WeekNo)+' [' + CONVERT(VARCHAR(2),DATEPART(d,FromDate)) + '-' " +
                   " + CONVERT(VARCHAR(2),DATEPART(d,ToDate))+']') as WeekNo, FromDate, ToDate from dbo.t_CalendarWeek) c Where a.CustomerID=b.CustomerID and InvoiceDate between FromDate and ToDate ";

            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUser + "')) ";
            }


            sSQL = sSQL + " Group by TerritoryID, WeekNo ";


            sSQL = sSQL + " order by WeekNo ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLDailySales.DailySalesRow oDailySalesRow = oDSBLLDailySales.DailySales.NewDailySalesRow();
                    Data oData = new Data();

                    oDailySalesRow.Type = reader["Type"].ToString();
                    oDailySalesRow.ID = reader["ID"].ToString();
                    oDailySalesRow.PriActValue = Convert.ToDouble(reader["PriActual"]);
                    oDailySalesRow.SecActValue = Convert.ToDouble(reader["SecActual"]);
                    oDailySalesRow.PriTarValue = Convert.ToDouble(reader["PriTarget"]);
                    oDailySalesRow.SecTarValue = Convert.ToDouble(reader["SecTarget"]);
                    oDailySalesRow.CollTarValue = Convert.ToDouble(reader["CollTarget"]);
                    oDailySalesRow.CollActValue = Convert.ToDouble(reader["CollActual"]);
                    oDailySalesRow.CollCash = Convert.ToDouble(reader["CollCash"]);
                    oDailySalesRow.CollAdj = Convert.ToDouble(reader["CollAdj"]);
                    oDailySalesRow.WeekNo = reader["WeekNo"].ToString();
                    oDailySalesRow.Date = oDailySalesRow.WeekNo;

                    oDSBLLDailySales.DailySales.AddDailySalesRow(oDailySalesRow);
                    oDSBLLDailySales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLDailySales;
        }

        private DSBLLDailySales GetWeekDataDistributor(DateTime dFromDate, DateTime dToDate, string sType, string sAndroidAppID, string sUser)
        {
            DSBLLDailySales oDSBLLDailySales = new DSBLLDailySales();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL = sSQL + " Select 'Customer' as Type, a.CustomerID as ID, WeekNo, Sum(PriActual) as PriActual, Sum(SecActual) as SecActual, Sum(PriTarget) as PriTarget, Sum(SecTarget) as SecTarget, Sum(CollTarget) as CollTarget, Sum(CollCash) as CollCash, Sum(CollAdj) as CollAdj, (Sum(CollCash) + Sum(CollAdj)) as CollActual from " +
                   " ( " +
                   " Select CustomerID, InvoiceDate, Sum(PriActual) as PriActual, Sum(SecActual) as SecActual, Sum(PriTarget) as PriTarget, " +
                   " Sum(SecTarget) as SecTarget, Sum(CollTarget) as CollTarget, Sum(CollCash) as CollCash, Sum(CollAdj) as CollAdj,  (Sum(CollCash) + Sum(CollAdj)) as CollActual from " +
                   " ( " +
                // ----Primary ----
                   " select CustomerID, InvoiceDate, sum (Amount)as PriActual,0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj  " +
                   " from " +
                   " (  " +
                   " select CustomerID,InvoiceDate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount  " +
                   " from  " +
                   " ( " +
                   " select a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1) as InvoiceDate, sum(invoiceamount) as crAmount, 0 as drAmount " +
                   " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " +
                   " where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                   " and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2)  " +
                   " group by a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1)  " +
                   " union all  " +
                   " select a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1) as InvoiceDate,0 as crAmount,sum(invoiceamount) as drAmount " +
                   " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v  " +
                   " where invoicedate between '" + dFromDate + "' and '" + dToDate + "' and invoicedate < '" + dToDate + "' " +
                   " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                   " group by a.CustomerID,Convert(datetime,replace(convert(varchar, InvoiceDate,6),'','-'),1)  " +
                   " )as p2  " +
                   " group by CustomerID,InvoiceDate " +
                   " ) as TELBLL " +
                   " group by CustomerID,InvoiceDate " +
                   " UNION ALL " +
                // -------Start Of Secondary-----------

                   " select  CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as PriActual, sum(Amount * .95)as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj " +
                   " from DWDB.dbo.t_BLLSecondarySales " +
                   " where Trandate between '" + dFromDate + "' and '" + dToDate + "' and Trandate < '" + dToDate + "' " +
                   " group by CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +

                    //----------Collection Target-------
                  " UNION ALL " +
                  " select CustomerID, TargetDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, Sum(Amount) as CollTarget, " +
                  " 0 as CollCash, 0 as CollAdj from BLLSysDB.dbo.t_CalendarSales a " +
                  " Left Outer JOIN  " +
                  " BLLSysDB.dbo.t_PlanDailyCollection b ON a.TDate=b.TargetDate " +
                  " Where Year(a.TDate)=" + nYear + " and Month(a.TDate)=" + nMonth + " and CustomerID is not null " +
                  " Group by CustomerID, TargetDate " +

                   " UNION ALL " +
                   " select CustomerID, TDate, 0 as PriActual, 0 as SecActual, round(sum(TGTTO)/(select Count(*) from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1),0) as PriTarget , " +
                   " round(sum(SecTGTTO)/(select Count(*) from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1),0) As SecTarget, 0 as CollTarget, 0 as CollCash, 0 as CollAdj  " +
                   " from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLSysDB.dbo.t_Customer b, " +
                   " (select TDate from BLLSysDB.dbo.t_CalendarSales where Year(TDate)=" + nYear + " and Month(TDate)=" + nMonth + " and IsSalesDay=1) c " +
                   " where TGTDate between '" + dFromDate + "' and '" + dToDate + "' and TGTDate < '" + dToDate + "'  " +
                   " and a.CustomerCode=b.CustomerCode  " +
                   " group by b.CustomerID, TDate  " +

                    //---------------Collection Start Cash---------
                   " UNION ALL " +
                   " select CustomerID,TranDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, sum(CreditAmount-DebitAmount)as CollCash, 0 as CollAdj " +
                   " from  " +
                   " (  " +
                   " select ct.CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27) and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "'  and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.Customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +
                   " UNION ALL " +
                   " select ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28)and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1)  " +
                   " )as Colle  " +
                   " group by CustomerID,TranDate " +
                //---------------Collection Start Adjustment---------
                   " UNION ALL " +
                   " select CustomerID,TranDate, 0 as PriActual, 0 as SecActual, 0 as PriTarget, 0 as SecTarget, 0 as CollTarget, 0 as CollCash, sum(CreditAmount-DebitAmount) as CollAdj " +
                   " from  " +
                   " (  " +
                   " select ct.CustomerID,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, sum(amount)as CreditAmount, 0 as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(19,21) and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "'  and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.Customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) " +
                   " UNION ALL " +
                   " select ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1) as TranDate, 0 as CreditAmount, sum(amount)as DebitAmount from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt, BLLSysDB.dbo.v_CustomerDetails cust " +
                   " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(20)and ct.TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate < '" + dToDate + "' and ct.CustomerID=cust.CustomerID and channelid=2 " +
                   " group by ct.customerid,Convert(datetime,replace(convert(varchar, TranDate,6),'','-'),1)  " +
                   " )as Colle  " +
                   " group by CustomerID, TranDate " +
                   " ) Final Group by CustomerID,InvoiceDate " +
                   " ) a, BLLSysDB.dbo.v_CustomerDetails b, (Select ('W-'+CONVERT(VARCHAR(2),WeekNo)+' [' + CONVERT(VARCHAR(2),DATEPART(d,FromDate)) + '-' " +
                   " + CONVERT(VARCHAR(2),DATEPART(d,ToDate))+']') as WeekNo, FromDate, ToDate from dbo.t_CalendarWeek) c Where a.CustomerID=b.CustomerID and InvoiceDate between FromDate and ToDate ";

            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUser + "')) ";
            }


            sSQL = sSQL + " Group by a.CustomerID, WeekNo ";


            sSQL = sSQL + " order by WeekNo ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLDailySales.DailySalesRow oDailySalesRow = oDSBLLDailySales.DailySales.NewDailySalesRow();
                    Data oData = new Data();

                    oDailySalesRow.Type = reader["Type"].ToString();
                    oDailySalesRow.ID = reader["ID"].ToString();
                    if (reader["PriActual"] != DBNull.Value)
                        oDailySalesRow.PriActValue = Convert.ToDouble(reader["PriActual"]);
                    else oDailySalesRow.PriActValue = 0;

                    if (reader["SecActual"] != DBNull.Value)
                        oDailySalesRow.SecActValue = Convert.ToDouble(reader["SecActual"]);
                    else oDailySalesRow.SecActValue = 0;

                    if (reader["PriTarget"] != DBNull.Value)
                        oDailySalesRow.PriTarValue = Convert.ToDouble(reader["PriTarget"]);
                    else oDailySalesRow.PriTarValue = 0;

                    if (reader["SecTarget"] != DBNull.Value)
                        oDailySalesRow.SecTarValue = Convert.ToDouble(reader["SecTarget"]);
                    else oDailySalesRow.SecTarValue = 0;

                    if (reader["CollTarget"] != DBNull.Value)
                        oDailySalesRow.CollTarValue = Convert.ToDouble(reader["CollTarget"]);
                    else oDailySalesRow.CollTarValue = 0;

                    if (reader["CollActual"] != DBNull.Value)
                        oDailySalesRow.CollActValue = Convert.ToDouble(reader["CollActual"]);
                    else oDailySalesRow.CollActValue = 0;

                    if (reader["CollCash"] != DBNull.Value)
                        oDailySalesRow.CollCash = Convert.ToDouble(reader["CollCash"]);
                    else oDailySalesRow.CollCash = 0;

                    if (reader["CollAdj"] != DBNull.Value)
                        oDailySalesRow.CollAdj = Convert.ToDouble(reader["CollAdj"]);
                    else oDailySalesRow.CollAdj = 0;

                    oDailySalesRow.WeekNo = reader["WeekNo"].ToString();
                    oDailySalesRow.Date = oDailySalesRow.WeekNo;

                    oDSBLLDailySales.DailySales.AddDailySalesRow(oDailySalesRow);
                    oDSBLLDailySales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLDailySales;
        }

        private void GetWeekNo(DateTime dFromDate)
        {
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;
            string sSQL = "";

            Data _oData;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            //string _WeekNo = "";
            
            cmd = DBController.Instance.GetCommand();

            sSQL = " Select WeekNo, FromDate, ToDate from dbo.t_CalendarWeek Where CMonth = " + nMonth + " and CYear = " + nYear + " Order by WeekNo ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oData = new Data();

                    _oData.WeekNo = reader["WeekNo"].ToString();

                    DateTime _FromDate = Convert.ToDateTime(reader["FromDate"]);
                    DateTime _ToDate = Convert.ToDateTime(reader["ToDate"]);


                    _oData.WeekText = "W-" + reader["WeekNo"].ToString() + " [" + _FromDate.Day.ToString() + "-" + _ToDate.Day.ToString() + "]";

                    InnerList.Add(_oData);
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

                _oData.Type = oData.Type;
                _oData.ID = oData.ID;

                _oData.PriActValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriActValue));
                _oData.SecActValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecActValue));
                _oData.PriTarValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriTarValue));
                _oData.SecTarValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecTarValue));
                _oData.CollTarValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CollTarValue));
                _oData.CollActValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CollActValue));
                _oData.CollCashText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CollCash));
                _oData.CollAdjText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CollAdj));
                _oData.InvoiceDate = oData.InvoiceDate;
                try
                {
                    _oData.NameOfDayText = Convert.ToDateTime(oData.InvoiceDate).ToString("ddd");
                }
                catch
                {
                    _oData.NameOfDayText = "";
                }

                if (oData.PriTarValue > 0)
                {
                    _oData.PriPercText = Convert.ToString(Math.Round((oData.PriActValue / oData.PriTarValue) * 100));
                }
                else
                {
                    _oData.PriPercText = "0";
                }
                if (oData.SecTarValue > 0)
                {
                    _oData.SecPercText = Convert.ToString(Math.Round((oData.SecActValue / oData.SecTarValue) * 100));
                }
                else
                {
                    _oData.SecPercText = "0";
                }
                if (oData.CollTarValue > 0)
                {
                    _oData.CollPercText = Convert.ToString(Math.Round((oData.CollActValue / oData.CollTarValue) * 100));
                }
                else
                {
                    _oData.CollPercText = "0";
                }
                eList.Add(_oData);

            }
            return eList;

        }
    }
}




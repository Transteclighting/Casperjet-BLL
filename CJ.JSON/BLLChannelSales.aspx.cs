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

public partial class BLLChannelSales : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            //string sUser = "hakim";


            Datas oDatas = new Datas();

            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataNational = new Data();
            Data _oDataChannel = new Data();
            Data _oDataArea = new Data();
            Data _oDataTerritory = new Data();
            Data _oDataRegionName = new Data();

            int nCount = 0;

            DBController.Instance.OpenNewConnection();
            oDatas.GetData();
            DBController.Instance.CloseConnection();

            foreach (Data oData in oDatas)
            {
                if (nCount == 0)
                {
                    _oDataNational = new Data();
                    _oDatas.Add(_oDataNational);
                    _oDataNational.ChannelName = "National";
                    _oDataNational.Type = "National";
                    _oDataNational.Value = "Success";
                    nCount++;
                }
                if (_oDataChannel.Channel != oData.Channel)
                {
                    _oDataChannel = new Data();
                    _oDatas.Add(_oDataChannel);
                    _oDataChannel.Channel = oData.Channel;
                    _oDataChannel.ChannelName = oData.Channel;
                    _oDataChannel.Type = "Channel";
                    _oDataChannel.Value = "Success";
                }

                //if (_oDataRegionName.RegionName != oData.RegionName)
                //{
                //    _oDataRegionName = new Data();
                //    _oDatas.Add(_oDataRegionName);
                //    _oDataRegionName.RegionName = oData.RegionName;
                //    _oDataRegionName.ChannelName = oData.RegionName;
                //    _oDataRegionName.Type = "RegionName";
                //    _oDataRegionName.Value = "Success";

                //}

                if (_oDataArea.AreaName != oData.AreaName)
                {
                    _oDataArea = new Data();
                    _oDatas.Add(_oDataArea);
                    _oDataArea.AreaName = oData.AreaName;
                    _oDataArea.ChannelName = oData.AreaName;
                    _oDataArea.Type = "Area";
                    _oDataArea.Value = "Success";
                }

                _oDataTerritory = new Data();
                _oDataTerritory.ChannelName = oData.TerritoryName;
                _oDataTerritory.Type = "Territory";
                _oDataTerritory.Value = "Success";

                _oDataTerritory.CMSTValue = oData.CMSTValue;
                _oDataTerritory.LMTValue = oData.LMTValue;

                _oDataTerritory.TodayValue = oData.TodayValue;
                _oDataTerritory.LDValue = oData.LDValue;
                _oDataTerritory.YTDValue = oData.YTDValue;

                _oDataTerritory.CMSAMTDValue = oData.CMSAMTDValue;
                _oDataTerritory.LMSAMTDValue = oData.LMSAMTDValue;
                _oDataTerritory.LMSAValue = oData.LMSAValue;
                _oDataTerritory.LYSAValue = oData.LYSAValue;
                _oDataTerritory.LYCMSAMTDValue = oData.LYCMSAMTDValue;

                _oDataTerritory.LYYTDSAValue = oData.LYYTDSAValue;

                _oDatas.Add(_oDataTerritory);

                _oDataNational.CMSTValue = _oDataNational.CMSTValue + oData.CMSTValue;
                _oDataNational.LMTValue = _oDataNational.LMTValue + oData.LMTValue;
                _oDataNational.TodayValue = _oDataNational.TodayValue + oData.TodayValue;
                _oDataNational.LDValue = _oDataNational.LDValue + oData.LDValue;
                _oDataNational.YTDValue = _oDataNational.YTDValue + oData.YTDValue;
                _oDataNational.CMSAMTDValue = _oDataNational.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataNational.LMSAMTDValue = _oDataNational.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataNational.LMSAValue = _oDataNational.LMSAValue + oData.LMSAValue;
                _oDataNational.LYSAValue = _oDataNational.LYSAValue + oData.LYSAValue;
                _oDataNational.LYCMSAMTDValue = _oDataNational.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                _oDataNational.LYYTDSAValue = _oDataNational.LYYTDSAValue + oData.LYYTDSAValue;

                _oDataChannel.CMSTValue = _oDataChannel.CMSTValue + oData.CMSTValue;
                _oDataChannel.LMTValue = _oDataChannel.LMTValue + oData.LMTValue;
                _oDataChannel.TodayValue = _oDataChannel.TodayValue + oData.TodayValue;
                _oDataChannel.LDValue = _oDataChannel.LDValue + oData.LDValue;
                _oDataChannel.YTDValue = _oDataChannel.YTDValue + oData.YTDValue;
                _oDataChannel.CMSAMTDValue = _oDataChannel.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataChannel.LMSAMTDValue = _oDataChannel.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataChannel.LMSAValue = _oDataChannel.LMSAValue + oData.LMSAValue;
                _oDataChannel.LYSAValue = _oDataChannel.LYSAValue + oData.LYSAValue;
                _oDataChannel.LYCMSAMTDValue = _oDataChannel.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                _oDataChannel.LYYTDSAValue = _oDataChannel.LYYTDSAValue + oData.LYYTDSAValue;

                _oDataArea.CMSTValue = _oDataArea.CMSTValue + oData.CMSTValue;
                _oDataArea.LMTValue = _oDataArea.LMTValue + oData.LMTValue;
                _oDataArea.TodayValue = _oDataArea.TodayValue + oData.TodayValue;
                _oDataArea.LDValue = _oDataArea.LDValue + oData.LDValue;
                _oDataArea.YTDValue = _oDataArea.YTDValue + oData.YTDValue;
                _oDataArea.CMSAMTDValue = _oDataArea.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataArea.LMSAMTDValue = _oDataArea.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataArea.LMSAValue = _oDataArea.LMSAValue + oData.LMSAValue;
                _oDataArea.LYSAValue = _oDataArea.LYSAValue + oData.LYSAValue;
                _oDataArea.LYCMSAMTDValue = _oDataArea.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                _oDataArea.LYYTDSAValue = _oDataArea.LYYTDSAValue + oData.LYYTDSAValue;

            }
            _oData.InsertReportLog(sUser);
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());

        }
    }
    public class Data
    {

        public string AreaName;
        public string TerritoryName;
        public string ChannelName;
        public string Channel;
        public string Type;
        public string Value;

        public double TodayValue;
        public double LDValue;
        public double LMValue;
        public double YTDValue;
        public double LYValue;
        public double LMTValue;

        public double CMSTValue;
        public double CMSAMTDValue;
        public double LMSAMTDValue;
        public double LMSAValue;
        public double LYSAValue;
        public double LYCMSAMTDValue;
        public double LYYTDSAValue;

        public string TodayValueText;
        public string LDValueText;
        public string YTDValueText;
        public string LYValueText;
        public string LMTValueText;

        public string CMSTValueText;
        public string CMSAMTDValueText;
        public string LMSAMTDValueText;
        public string LMSAValueText;
        public string LYCMSAMTDValueText;
        public string LYYTDSAValueText;

        public string GSCMMTDPercText;
        public string GSLMMTDPercText;
        public string GSLMFullPercText;
        public string GSLYCMMTDPercText;

        public string MTDTargetText;
        public string MTDPercentText;
        public string YTDGthPercText;

        public string RegionName;


        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10036";
            string sReportName = "BLL-Channel Sales";
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
        public void GetData()
        {
            TELLib _oTELLib = new TELLib();

            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);
            DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(dFromDate);
            DateTime _FirstDayofLastMonth = _oTELLib.FirstDayofLastMonth(dFromDate);
            DateTime _FirstDayofThisYear = _oTELLib.FirstDayofThisYear(dFromDate);
            DateTime _FirstDayofLastYear = _oTELLib.FirstDayofLastYear(dFromDate);
            DateTime _FirstDayofNextYear = _FirstDayofThisYear.AddYears(1);
            DateTime _FirstDayofNextMonth = _FirstDayofMonth.AddMonths(1);
            DateTime _ToDateOfLastMonth = dToDate.AddMonths(-1);

            DateTime _FristDayofLastYearThisMonth = _FirstDayofMonth.AddYears(-1);
            DateTime _FristDayofLastYearNextMonth = _FirstDayofNextMonth.AddYears(-1);
            DateTime _ToDateofLastYearThisMonth = dToDate.AddYears(-1);


            DSBLLPerformanceAnalysis oDSCustomer = new DSBLLPerformanceAnalysis();

            DSBLLPerformanceAnalysis oDSCMST = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLMT = new DSBLLPerformanceAnalysis();

            DSBLLPerformanceAnalysis oDSToday = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSYTD = new DSBLLPerformanceAnalysis();

            DSBLLPerformanceAnalysis oDSCMSAMTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLMSAMTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLMSA = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLYCMSAMTD = new DSBLLPerformanceAnalysis();

            DSBLLPerformanceAnalysis oDSLYSA = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLYYTDSA = new DSBLLPerformanceAnalysis();


            oDSCustomer = GetCustomerList();
            oDSCMST = GetRawDataTarget("PrimaryTarget", _FirstDayofMonth, _FirstDayofNextMonth);
            oDSLMT = GetRawDataTarget("PrimaryTarget", _FirstDayofLastMonth, _FirstDayofMonth);

            oDSToday = GetRawData("PrimaryActual", dFromDate, dToDate);
            oDSLD = GetRawData("PrimaryActual", dLastDate, dFromDate);
            oDSYTD = GetRawData("PrimaryActual", _FirstDayofThisYear, dToDate);

            oDSCMSAMTD = GetRawData("PrimaryActual", _FirstDayofMonth, dToDate);
            oDSLMSAMTD = GetRawData("PrimaryActual", _FirstDayofLastMonth, _ToDateOfLastMonth);
            oDSLMSA = GetRawData("PrimaryActual", _FirstDayofLastMonth, _FirstDayofMonth);
            oDSLYCMSAMTD = GetRawData("PrimaryActual", _FristDayofLastYearThisMonth, _ToDateofLastYearThisMonth);
            oDSLYSA = GetRawData("PrimaryActual", _FirstDayofLastYear, _FirstDayofThisYear);
            oDSLYYTDSA = GetRawData("PrimaryActual", _FirstDayofLastYear, _ToDateofLastYearThisMonth);

            Data _oData;
            InnerList.Clear();

            foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow in oDSCustomer.BLLPerformanceAnalysis)
            {

                _oData = new Data();

                _oData.AreaName = oBLLPerformanceAnalysisRow.AreaName;
                _oData.TerritoryName = oBLLPerformanceAnalysisRow.TerritoryName;
                _oData.ChannelName = oBLLPerformanceAnalysisRow.Channel;
                _oData.Channel = oBLLPerformanceAnalysisRow.Channel;
               // _oData.RegionName = oBLLPerformanceAnalysisRow.RegionName;


                //-----------
                // Current Month Primary Target
                DSBLLPerformanceAnalysis oDSCMSTFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMST = oDSCMST.BLLPerformanceAnalysis.Select(" FullName= '" + oBLLPerformanceAnalysisRow.FullName + "'");
                oDSCMSTFiltered.Merge(oDRCMST);
                oDSCMSTFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSTRow in oDSCMSTFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSTValue = Convert.ToDouble(oDSCMSTRow.Amount);
                }

                //-----------
                // Last Month Primary Target
                DSBLLPerformanceAnalysis oDSLMTFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMT = oDSLMT.BLLPerformanceAnalysis.Select(" FullName= '" + oBLLPerformanceAnalysisRow.FullName + "'");
                oDSLMTFiltered.Merge(oDRLMT);
                oDSLMTFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMTRow in oDSLMTFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMTValue = Convert.ToDouble(oDSLMTRow.Amount);
                }


                // Today Primary Achievement
                DSBLLPerformanceAnalysis oDSTodayFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRToday = oDSToday.BLLPerformanceAnalysis.Select(" FullName= '" + oBLLPerformanceAnalysisRow.FullName + "'");
                oDSTodayFiltered.Merge(oDRToday);
                oDSTodayFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSTodayRow in oDSTodayFiltered.BLLPerformanceAnalysis)
                {
                    _oData.TodayValue = Convert.ToDouble(oDSTodayRow.Amount);
                }

                // Last Day Primary Achievement
                DSBLLPerformanceAnalysis oDSLDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLD = oDSLD.BLLPerformanceAnalysis.Select(" FullName= '" + oBLLPerformanceAnalysisRow.FullName + "'");
                oDSLDFiltered.Merge(oDRLD);
                oDSLDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLDRow in oDSLDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LDValue = Convert.ToDouble(oDSLDRow.Amount);
                }

                // YTD Primary Achievement
                DSBLLPerformanceAnalysis oDSYTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRYTD = oDSYTD.BLLPerformanceAnalysis.Select(" FullName= '" + oBLLPerformanceAnalysisRow.FullName + "'");
                oDSYTDFiltered.Merge(oDRYTD);
                oDSYTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSYTDRow in oDSYTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.YTDValue = Convert.ToDouble(oDSYTDRow.Amount);
                }

                // Current Month Primary Achievement MTD
                DSBLLPerformanceAnalysis oDSCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMSAMTD = oDSCMSAMTD.BLLPerformanceAnalysis.Select(" FullName= '" + oBLLPerformanceAnalysisRow.FullName + "'");
                oDSCMSAMTDFiltered.Merge(oDRCMSAMTD);
                oDSCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSAMTDRow in oDSCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSAMTDValue = Convert.ToDouble(oDSCMSAMTDRow.Amount);
                }

                // Last Month Primary Achievement MTD
                DSBLLPerformanceAnalysis oDSLMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSAMTD = oDSLMSAMTD.BLLPerformanceAnalysis.Select(" FullName= '" + oBLLPerformanceAnalysisRow.FullName + "'");
                oDSLMSAMTDFiltered.Merge(oDRLMSAMTD);
                oDSLMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSAMTDRow in oDSLMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAMTDValue = Convert.ToDouble(oDSLMSAMTDRow.Amount);
                }

                // Last Month Primary Achievement
                DSBLLPerformanceAnalysis oDSLMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSA = oDSLMSA.BLLPerformanceAnalysis.Select(" FullName= '" + oBLLPerformanceAnalysisRow.FullName + "'");
                oDSLMSAFiltered.Merge(oDRLMSA);
                oDSLMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSARow in oDSLMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAValue = Convert.ToDouble(oDSLMSARow.Amount);
                }

                // Last Year This Month MTD Primary Achievement
                DSBLLPerformanceAnalysis oDSLYCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYCMSAMTD = oDSLYCMSAMTD.BLLPerformanceAnalysis.Select(" FullName= '" + oBLLPerformanceAnalysisRow.FullName + "'");
                oDSLYCMSAMTDFiltered.Merge(oDRLYCMSAMTD);
                oDSLYCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSAMTDRow in oDSLYCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYCMSAMTDValue = Convert.ToDouble(oDSLYCMSAMTDRow.Amount);
                }

                // Last Year Primary Achievement
                DSBLLPerformanceAnalysis oDSLYSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYSA = oDSLYSA.BLLPerformanceAnalysis.Select(" FullName= '" + oBLLPerformanceAnalysisRow.FullName + "'");
                oDSLYSAFiltered.Merge(oDRLYSA);
                oDSLYSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYSARow in oDSLYSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYSAValue = Convert.ToDouble(oDSLYSARow.Amount);
                }

                // Last Year YTD Primary Achievement
                DSBLLPerformanceAnalysis oDSLYYTDSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYYTDSA = oDSLYYTDSA.BLLPerformanceAnalysis.Select(" FullName= '" + oBLLPerformanceAnalysisRow.FullName + "'");
                oDSLYYTDSAFiltered.Merge(oDRLYYTDSA);
                oDSLYYTDSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYYTDSARow in oDSLYYTDSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYYTDSAValue = Convert.ToDouble(oDSLYYTDSARow.Amount);
                }

                InnerList.Add(_oData);
            }


        }
        
        public DSBLLPerformanceAnalysis GetRawData(string sType, DateTime dFromDate, DateTime dTodate)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sType == "PrimaryActual")
            {
                cmd = DBController.Instance.GetCommand();

                sSQL =
                       " Select (Region+Area+Territory) as MIX, Value " +
                       " From  " +
                       " ( " +
                       " select b.RegionShortName as Region, AreaShortName as Area, TerritoryShortName as Territory, sum (Amount)as Value    " +
                       " from   " +
                       " (    " +
                       " select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount  " +
                       " from   " +
                       " (     " +
                       " select CustomerID,sum(invoiceamount) as crAmount, 0 as drAmount  " +
                       " from bllsysdb.dbo.t_salesInvoice  " +
                       " where invoicedate between '" + dFromDate + "' and '" + dTodate + "' and invoicedate < '" + dTodate + "'   " +
                       " and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3)  " +
                       " group by  CustomerID  " +
                       " union all  " +
                       " select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount  " +
                       " from bllsysdb.dbo.t_salesInvoice  " +
                       " where invoicedate between '" + dFromDate + "' and '" + dTodate + "' and invoicedate < '" + dTodate + "'  " +
                       " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)    " +
                       " group by  CustomerID  " +
                       " )as p2 " +
                       " group by CustomerID " +
                       " ) as TELBLL, DWDB.dbo.t_CustomerDetails b Where TELBLL.CustomerID=b.CustomerID and CompanyName='BLL'  " +
                       " group by b.RegionShortName, AreaShortName, TerritoryShortName " +
                       " )x ";



                //" Select(Region + Area + Territory) as MIX, Value " +
                //" From " +
                //" ( " +
                //" select RegionShortName as Region, AreaShortName as Area, " +
                //" TerritoryShortName as Territory, sum(Amount) as Value " +
                //" from " +
                //" ( " +
                //" select CustomerID, isnull(sum(crAmount) - abs(sum(drAmount)), 0) as Amount " +
                //" from " +
                //" ( " +
                //" select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount " +
                //" from bllsysdb.dbo.t_salesInvoice " +
                //" where invoicedate between '" + dFromDate + "' and '" + dTodate + "' and invoicedate < '" + dTodate + "' " +
                //" and invoicetypeid in (1, 2, 3, 4, 5, 17) and invoicestatus not in (3) " +
                //" group by  CustomerID " +
                //" union all " +
                //" select CustomerID, 0 as crAmount, sum(invoiceamount) as drAmount " +
                //" from bllsysdb.dbo.t_salesInvoice " +
                //" where invoicedate between '" + dFromDate + "' and '" + dTodate + "' and invoicedate < '" + dTodate + "' " +
                //" and invoicetypeid in (6, 7, 8, 9, 10, 12) and invoicestatus not in (3) " +
                //" group by  CustomerID " +
                //" ) as p2 " +
                //" group by CustomerID " +
                //" ) as TELBLL " +
                //" inner join " +
                //" ( " +
                //" Select a.RegionShortName, b.AreaShortName, b.TerritoryShortName, b.CustomerID " +
                //" from " +
                //" BLLSysDB.dbo.v_CustomerDetails a, DWDB.dbo.t_CustomerDetails b " +
                //" where a.CustomerID = b.CustomerID and CompanyName = 'BLL' " +
                //" ) as Cust on TELBLL.CustomerID = Cust.CustomerID " +
                //" group by RegionShortName,AreaShortName, TerritoryShortName " +
                //" )x ";



            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.FullName = reader["MIX"].ToString();
                    oBLLPerformanceAnalysisRow.Amount = Convert.ToDouble(reader["Value"]);

                    oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.AddBLLPerformanceAnalysisRow(oBLLPerformanceAnalysisRow);
                    oDSBLLPerformanceAnalysis.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }


            return oDSBLLPerformanceAnalysis;
        }

        public DSBLLPerformanceAnalysis GetRawDataTarget(string sType, DateTime dFromDate, DateTime dTodate)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            if (sType == "PrimaryTarget")
            {
                sSQL =

            " select (RegionShortName+ AreaShortName+TerritoryShortName) as MIX, Sum(TGTTO) as Amount " +
            " from TELAddDB.dbo.t_DistributorDayTGTTO a, DWDB.dbo.t_CustomerDetails b " +
            " where TGTDate between '" + dFromDate + "' and '" + dTodate + "'  and  TGTDate < '" + dTodate + "'  " +
            " and a.Customercode=b.Customercode and CompanyName='BLL' " +
            " Group by RegionShortName, AreaShortName, TerritoryShortName ";

                //" select(RegionShortName + b.AreaShortName + b.TerritoryShortName) as MIX, Sum(TGTTO) as Amount " +
                //" from TELAddDB.dbo.t_DistributorDayTGTTO a, DWDB.dbo.t_CustomerDetails b, BLLSysDB.dbo.v_CustomerDetails c " +
                //" where TGTDate between '" + dFromDate + "' and '" + dTodate + "'  and TGTDate < '" + dTodate + "' " +
                //" and a.Customercode = b.Customercode and CompanyName = 'BLL'  and b.CustomerID = c.CustomerID " +
                //" Group by RegionShortName, b.AreaShortName, b.TerritoryShortName ";

            }



            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.FullName = reader["MIX"].ToString();
                    oBLLPerformanceAnalysisRow.Amount = Convert.ToDouble(reader["Amount"]);

                    oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.AddBLLPerformanceAnalysisRow(oBLLPerformanceAnalysisRow);
                    oDSBLLPerformanceAnalysis.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLPerformanceAnalysis;
        }
        
        public DSBLLPerformanceAnalysis GetCustomerList()
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL =
            " Select Distinct (RegionShortName + AreaShortName+TerritoryShortName) as MIX, RegionShortName, " +
            " AreaShortName, AreaSort, TerritoryShortName, TerritorySort from DWDB.dbo.t_CustomerDetails Where CompanyName='BLL'  " +
            " Order by RegionShortName,AreaSort, TerritorySort ";


            //"  Select Distinct (RegionShortName + a.AreaShortName + a.TerritoryShortName) as MIX, RegionShortName, " +
            //"  a.AreaShortName, a.AreaSort, a.TerritoryShortName, a.TerritorySort from DWDB.dbo.t_CustomerDetails a, BLLSysDB.dbo.v_CustomerDetails b  Where CompanyName = 'BLL' " +
            //"  and a.CustomerID = b.CustomerID " +
            //"  Order by RegionShortName, AreaSort, TerritorySort ";



            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.FullName = reader["MIX"].ToString();
                    //oBLLPerformanceAnalysisRow.Channel = reader["ChannelDescription"].ToString();
                    oBLLPerformanceAnalysisRow.Channel = reader["RegionShortName"].ToString();
                   // oBLLPerformanceAnalysisRow.RegionName = reader["RegionShortName"].ToString();
                    oBLLPerformanceAnalysisRow.AreaName = reader["AreaShortName"].ToString();
                    oBLLPerformanceAnalysisRow.TerritoryName = reader["TerritoryShortName"].ToString();
                    

                    oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.AddBLLPerformanceAnalysisRow(oBLLPerformanceAnalysisRow);
                    oDSBLLPerformanceAnalysis.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLPerformanceAnalysis;
        }
        
        public List<Data> getResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            DateTime dFromDate = DateTime.Now;

            DateTime LastDayOfMonth = _oTELLib.LastDayofMonth(dFromDate);
            int nLastDayCM = LastDayOfMonth.Day;
            int nDay = dFromDate.Day;

            foreach (Data oData in this)
            {

                _oData = new Data();
                _oData.ChannelName = oData.ChannelName;

                _oData.Type = oData.Type;
                _oData.Value = oData.Value;


                _oData.CMSTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSTValue));
                _oData.LMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMTValue));

                _oData.TodayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TodayValue));
                _oData.LDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDValue));
                _oData.YTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue));

                _oData.CMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSAMTDValue));
                _oData.LMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMSAMTDValue));
                _oData.LMSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMSAValue));
                _oData.LYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYSAValue));
                _oData.LYCMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYCMSAMTDValue));

                _oData.LYYTDSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTDSAValue));

                double _MTDTarget = 0;
                //Performance

                if (oData.CMSTValue > 0)
                {
                    _oData.GSCMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue / oData.CMSTValue) * 100));
                    _MTDTarget = oData.CMSTValue / nLastDayCM * nDay;
                    _oData.MTDTargetText = ExcludeDecimal(_oTELLib.TakaFormat(_MTDTarget));
                    _oData.MTDPercentText = Convert.ToString(Math.Round((oData.CMSAMTDValue / _MTDTarget) * 100));
                }
                else
                {
                    _oData.GSCMMTDPercText = "0";
                    _oData.MTDTargetText = "0";
                    _oData.MTDPercentText = "0";
                }

                if (oData.LMSAMTDValue > 0)
                {
                    _oData.GSLMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue - oData.LMSAMTDValue) / oData.LMSAMTDValue * 100));
                }
                else
                {
                    _oData.GSLMMTDPercText = "0";
                }

                if (oData.LMTValue > 0)
                {
                    _oData.GSLMFullPercText = Convert.ToString(Math.Round((oData.LMSAValue / oData.LMTValue) * 100));
                }
                else
                {
                    _oData.GSLMFullPercText = "0";
                }
                if (oData.LYCMSAMTDValue > 0)
                {
                    _oData.GSLYCMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue - oData.LYCMSAMTDValue) / oData.LYCMSAMTDValue * 100));
                }
                else
                {
                    _oData.GSLYCMMTDPercText = "0";
                }

                if (oData.LYYTDSAValue > 0)
                {
                    _oData.YTDGthPercText = Convert.ToString(Math.Round((oData.YTDValue - oData.LYYTDSAValue) / oData.LYYTDSAValue * 100));
                }
                else
                {
                    _oData.YTDGthPercText = "0";
                }


                eList.Add(_oData);
            }
            return eList;

        }
    }
}



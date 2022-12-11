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

public partial class jBLLSecondaryBeatSalesAnalysisQty : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            //string sUser = c.Request.Form["UserName"].Trim();
            //string sType = c.Request.Form["Type"].Trim();
            //string sAreaID = c.Request.Form["AreaID"].Trim();
            //string sTerritoryID = c.Request.Form["TerritoryID"].Trim();
            //string sCustomerID = c.Request.Form["CustomerID"].Trim();
            //string sRouteTypeID = c.Request.Form["RouteTypeID"].Trim();
            //string sRouteID = c.Request.Form["RouteID"].Trim();

            string sUser = "hrashid";
            string sType = "Customer";
            string sAreaID = "3";
            string sTerritoryID = "300";
            string sCustomerID = "1777";
            string sRouteTypeID = "1";
            string sRouteID = "1216";

            if (sType == "National")
            {
                if (Convert.ToInt32(sCustomerID) > 0)
                {
                    sType = "Customer";
                }
            }

            string sDate = "";
            string sAndroidAppID = "";
            string sDSRID = "";
            DateTime dDate = DateTime.Now.Date;
            if (c.Request.Form["Date"] != null)
            {
                sDate = c.Request.Form["Date"].Trim();
            }
            if (c.Request.Form["DSRID"] != null)
            {
                sDSRID = c.Request.Form["DSRID"].Trim();
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
            catch (Exception ex)
            {
                dDate = DateTime.Now.Date;
            }
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Datas oDatas = new Datas();
            Data _oDataASGAll = new Data();

            Data _oDataASG = new Data();

            oDatas.GetData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, dDate, sAndroidAppID, sUser, sDSRID);
            #region Loop
            foreach (Data oData in oDatas)
            {
                if (_oDataASGAll.ASGName != oData.ASGName)
                {
                    #region ASG
                    //All
                    _oDataASGAll = new Data();
                    _oDatas.Add(_oDataASGAll);
                    _oDataASGAll.ASGID = oData.ASGID;
                    _oDataASGAll.ASGName = oData.ASGName;
                    _oDataASGAll.RouteTypeID = "0";
                    _oDataASGAll.Value = "Success";
                    _oDataASGAll.DBBufferStockQty = oData.DBBufferStockQty;
                    _oDataASGAll.DBStockQty = oData.DBStockQty;

                    #endregion
                }

                _oDataASG = new Data();
                _oDataASG.Value = "Success";
                _oDataASG.ASGID = oData.ASGID;
                _oDataASG.ASGName = oData.ASGName;
                _oDataASG.CMSTQty = oData.CMSTQty;
                _oDataASG.CMSAMTDQty = oData.CMSAMTDQty;
                _oDataASG.LMSAMTDQty = oData.LMSAMTDQty;
                _oDataASG.LMSAQty = oData.LMSAQty;
                _oDataASG.LYCMSAQty = oData.LYCMSAQty;
                _oDataASG.LYCMSAMTDQty = oData.LYCMSAMTDQty;
                _oDataASG.RouteTypeID = oData.RouteTypeID;
                _oDataASG.DBBufferStockQty = oData.DBBufferStockQty;
                _oDataASG.DBStockQty = oData.DBStockQty;

                _oDataASG.LDQty = oData.LDQty;
                _oDataASG.YTDQty = oData.YTDQty;
                _oDataASG.LYYTDQty = oData.LYYTDQty;
                _oDataASG.LYQty = oData.LYQty;

                _oDataASG.LDOrderQty = oData.LDOrderQty;
                _oDataASG.MTDOrderQty = oData.MTDOrderQty;
                _oDataASG.SlabTargetQty = oData.SlabTargetQty;
                _oDataASG.MTDSlabActualQty = oData.MTDSlabActualQty;
                _oDataASG.TodayTarget =  oData.TodayTarget;

                _oDatas.Add(_oDataASG);

                _oDataASGAll.CMSTQty = _oDataASGAll.CMSTQty + oData.CMSTQty;
                _oDataASGAll.CMSAMTDQty = _oDataASGAll.CMSAMTDQty + oData.CMSAMTDQty;
                _oDataASGAll.LMSAMTDQty = _oDataASGAll.LMSAMTDQty + oData.LMSAMTDQty;
                _oDataASGAll.LMSAQty = _oDataASGAll.LMSAQty + oData.LMSAQty;
                _oDataASGAll.LYCMSAQty = _oDataASGAll.LYCMSAQty + oData.LYCMSAQty;
                _oDataASGAll.LYCMSAMTDQty = _oDataASGAll.LYCMSAMTDQty + oData.LYCMSAMTDQty;

                _oDataASGAll.LDQty = _oDataASGAll.LDQty + oData.LDQty;
                _oDataASGAll.YTDQty = _oDataASGAll.YTDQty + oData.YTDQty;
                _oDataASGAll.LYYTDQty = _oDataASGAll.LYYTDQty + oData.LYYTDQty;
                _oDataASGAll.LYQty = _oDataASGAll.LYQty + oData.LYQty;

                _oDataASGAll.LDOrderQty = _oDataASGAll.LDOrderQty + oData.LDOrderQty;
                _oDataASGAll.MTDOrderQty = _oDataASGAll.MTDOrderQty + oData.MTDOrderQty;
                _oDataASGAll.SlabTargetQty = _oDataASGAll.SlabTargetQty + oData.SlabTargetQty;
                _oDataASGAll.MTDSlabActualQty = _oDataASGAll.MTDSlabActualQty + oData.MTDSlabActualQty;
                _oDataASGAll.TodayTarget = _oDataASGAll.TodayTarget + oData.TodayTarget;
            }
            #endregion

            _oData.InsertReportLog(sUser);

            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());

        }
    }
    public class Data
    {
        // C = Current, M = Month, P=Primary, T=Target, L=Last, Y=Year, A=Actual

        public string ASGID;
        public string ASGName;
        public string RouteTypeID;
        public string Value;

        public int CMSTQty;
        public int CMSAMTDQty;
        public int LMSAMTDQty;
        public int LMSAQty;
        public int LYCMSAQty; 
        public int LYCMSAMTDQty;
        public double LDQty;
        public double YTDQty;
        public double LYYTDQty;
        public double LYQty;
        public int DBStockQty;
        public int DBBufferStockQty;

        public int LDOrderQty;
        public int MTDOrderQty;
        public int SlabTargetQty;
        public int MTDSlabActualQty;

        public string CMSTQtyText;
        public string CMSAMTDQtyText;
        public string LMSAMTDQtyText;
        public string LMSAQtyText;
        public string LYCMSAQtyText;
        public string LYCMSAMTDQtyText;
        public string LDQtyText;
        public string YTDQtyText;
        public string LYYTDQtyText;
        public string LYQtyText;
        public string DBStockQtyText;
        public string DBBufferStockQtyText;

        public string LDOrderQtyText;
        public string MTDOrderQtyText;
        public string SlabTargetQtyText;
        public string MTDSlabActualQtyText;

        public string GSCMMTDPercText;
        public string GSLMMTDPercText;
        public string GSLMFullPercText;
        public string GSLYCMFullPercText;
        public string GSLYCMMTDPercText;
        public string StockPercText;

        public string GSYTDQtyPercText;

        public string LDOrderPercText;
        public string MTDDeliveryPercText;
        public string MTDSlabPercText;
        public string MTDSlabContributionPercText;
        public string MTDRetailQtyText;
        public string TodayTarget;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10039";
            string sReportName = "BLL-Route Sales Qty (ASG)";
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
        
        public void GetData(string sType, string sAreaID, string sTerritoryID, string sCustomerID, string sRouteTypeID, string sRouteID, DateTime dDate, string sAndroidAppID, string sUserName, string sDSRID)
        {
            TELLib _oTELLib = new TELLib();

            //DateTime dFromDate = DateTime.Now.Date;
            DateTime dFromDate = dDate;
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
            DSBLLPerformanceAnalysis oDSCMSAMTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLMSAMTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLMSA = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLYCMSA = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLYCMSAMTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSDBStock = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSDBBufferStock = new DSBLLPerformanceAnalysis();

            DSBLLPerformanceAnalysis oDSLD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSYTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLYYTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLY = new DSBLLPerformanceAnalysis();

            DSBLLPerformanceAnalysis oDSLDOrder = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSMTDOrder = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSSlabTarget = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSSlabSales = new DSBLLPerformanceAnalysis();

            DBController.Instance.OpenNewConnection();

            oDSCustomer = GetASGList();
            oDSCMST = GetRawDataTarget(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofMonth, _FirstDayofNextMonth, sAndroidAppID, sUserName, sDSRID);
            oDSCMSAMTD = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofMonth, dToDate, sAndroidAppID, sUserName, sDSRID);
            oDSLMSAMTD = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofLastMonth, _ToDateOfLastMonth, sAndroidAppID, sUserName, sDSRID);
            oDSLMSA = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofLastMonth, _FirstDayofMonth, sAndroidAppID, sUserName, sDSRID);
            oDSLYCMSA = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FristDayofLastYearThisMonth, _FristDayofLastYearNextMonth, sAndroidAppID, sUserName, sDSRID);
            oDSLYCMSAMTD = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FristDayofLastYearThisMonth, _ToDateofLastYearThisMonth, sAndroidAppID, sUserName, sDSRID);
            oDSDBStock = GetCustomerStock(sType, sAreaID, sTerritoryID, sCustomerID, sAndroidAppID, sUserName);
            oDSDBBufferStock = GetBufferStock(sType, sAreaID, sTerritoryID, sCustomerID, sAndroidAppID, sUserName);


            oDSLD = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, dLastDate, dFromDate, sAndroidAppID, sUserName, sDSRID);
            oDSYTD = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofThisYear, dToDate, sAndroidAppID, sUserName, sDSRID);
            oDSLYYTD = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofLastYear, _ToDateofLastYearThisMonth, sAndroidAppID, sUserName, sDSRID);
            oDSLY = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofLastYear, _FirstDayofThisYear, sAndroidAppID, sUserName, sDSRID);

            oDSLDOrder = GetOrderData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, dLastDate, dFromDate, sAndroidAppID, sUserName, sDSRID);
            oDSMTDOrder = GetOrderData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofMonth, dToDate, sAndroidAppID, sUserName, sDSRID);
            oDSSlabTarget = GetRawDataSlabTarget(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofMonth, dToDate, sAndroidAppID, sUserName, sDSRID);
            oDSSlabSales = GetRawDataSlabSales(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofMonth, dToDate, sAndroidAppID, sUserName, sDSRID);

            Data _oData;
            InnerList.Clear();

            foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow in oDSCustomer.BLLPerformanceAnalysis)
            {

                _oData = new Data();

                _oData.ASGID = oBLLPerformanceAnalysisRow.ASGID.ToString();
                _oData.ASGName = oBLLPerformanceAnalysisRow.ASGName;
                _oData.RouteTypeID = oBLLPerformanceAnalysisRow.RouteTypeID;

                //-----------
                // Current Month Secondary Target
                DSBLLPerformanceAnalysis oDSCMSTFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMST = oDSCMST.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSCMSTFiltered.Merge(oDRCMST);
                oDSCMSTFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSTRow in oDSCMSTFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSTQty = Convert.ToInt32(oDSCMSTRow.Qty);
                }

                // Current Month Secondary Achievement MTD
                DSBLLPerformanceAnalysis oDSCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMSAMTD = oDSCMSAMTD.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSCMSAMTDFiltered.Merge(oDRCMSAMTD);
                oDSCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSAMTDRow in oDSCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSAMTDQty = Convert.ToInt32(oDSCMSAMTDRow.Qty);
                }

                // Last Month Secondary Achievement MTD
                DSBLLPerformanceAnalysis oDSLMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSAMTD = oDSLMSAMTD.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSLMSAMTDFiltered.Merge(oDRLMSAMTD);
                oDSLMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSAMTDRow in oDSLMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAMTDQty = Convert.ToInt32(oDSLMSAMTDRow.Qty);
                }

                // Last Month Secondary Achievement
                DSBLLPerformanceAnalysis oDSLMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSA = oDSLMSA.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSLMSAFiltered.Merge(oDRLMSA);
                oDSLMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSARow in oDSLMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAQty = Convert.ToInt32(oDSLMSARow.Qty);
                }

                // Last Year This Month Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYCMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYCMSA = oDSLYCMSA.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSLYCMSAFiltered.Merge(oDRLYCMSA);
                oDSLYCMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSARow in oDSLYCMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYCMSAQty = Convert.ToInt32(oDSLYCMSARow.Qty);
                }

                // Last Year This Month MTD Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYCMSAMTD = oDSLYCMSAMTD.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSLYCMSAMTDFiltered.Merge(oDRLYCMSAMTD);
                oDSLYCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSAMTDRow in oDSLYCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYCMSAMTDQty = Convert.ToInt32(oDSLYCMSAMTDRow.Qty);
                }

                // DB Stock
                DSBLLPerformanceAnalysis oDSDBStockFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRDBStock = oDSDBStock.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "'");
                oDSDBStockFiltered.Merge(oDRDBStock);
                oDSDBStockFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSDBStockRow in oDSDBStockFiltered.BLLPerformanceAnalysis)
                {
                    _oData.DBStockQty = Convert.ToInt32(oDSDBStockRow.Qty);
                }

                // DB Buffer Stock
                DSBLLPerformanceAnalysis oDSDBBufferStockFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRDBBufferStock = oDSDBBufferStock.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "'");
                oDSDBBufferStockFiltered.Merge(oDRDBBufferStock);
                oDSDBBufferStockFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSDBBufferStockRow in oDSDBBufferStockFiltered.BLLPerformanceAnalysis)
                {
                    _oData.DBBufferStockQty = Convert.ToInt32(oDSDBBufferStockRow.Qty);
                }

                // Last Day Secondary Achievement
                DSBLLPerformanceAnalysis oDSLDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLD = oDSLD.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSLDFiltered.Merge(oDRLD);
                oDSLDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLDRow in oDSLDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LDQty = Convert.ToDouble(oDSLDRow.Qty);
                }
                // YTD Secondary Achievement
                DSBLLPerformanceAnalysis oDSYTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRYTD = oDSYTD.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSYTDFiltered.Merge(oDRYTD);
                oDSYTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSYTDRow in oDSYTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.YTDQty = Convert.ToDouble(oDSYTDRow.Qty);
                }
                // LYYTD Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYYTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYYTD = oDSLYYTD.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSLYYTDFiltered.Merge(oDRLYYTD);
                oDSLYYTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYYTDRow in oDSLYYTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYYTDQty = Convert.ToDouble(oDSLYYTDRow.Qty);
                }
                // LY Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLY = oDSLY.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSLYFiltered.Merge(oDRLY);
                oDSLYFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYRow in oDSLYFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYQty = Convert.ToDouble(oDSLYRow.Qty);
                }
                // LD Order Qty
                DSBLLPerformanceAnalysis oDSLDOrderFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLDOrder = oDSLDOrder.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSLDOrderFiltered.Merge(oDRLDOrder);
                oDSLDOrderFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLDOrderRow in oDSLDOrderFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LDOrderQty = Convert.ToInt32(oDSLDOrderRow.Qty);
                }
                // MTD Order Qty
                DSBLLPerformanceAnalysis oDSMTDOrderFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRMTDOrder = oDSMTDOrder.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSMTDOrderFiltered.Merge(oDRMTDOrder);
                oDSMTDOrderFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSMTDOrderRow in oDSMTDOrderFiltered.BLLPerformanceAnalysis)
                {
                    _oData.MTDOrderQty = Convert.ToInt32(oDSMTDOrderRow.Qty);
                }
                // MTD Slab Target Qty
                DSBLLPerformanceAnalysis oDSMTDSlabTargetFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRMTDSlabTarget = oDSSlabTarget.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSMTDSlabTargetFiltered.Merge(oDRMTDSlabTarget);
                oDSMTDSlabTargetFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSMTDSlabTargetRow in oDSMTDSlabTargetFiltered.BLLPerformanceAnalysis)
                {
                    _oData.SlabTargetQty = Convert.ToInt32(oDSMTDSlabTargetRow.Qty);
                }
                // MTD Slab Sales Qty
                DSBLLPerformanceAnalysis oDSMTDSlabSalesFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRMTDSlabSales = oDSSlabSales.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "' and RouteTypeID='" + oBLLPerformanceAnalysisRow.RouteTypeID + "'");
                oDSMTDSlabSalesFiltered.Merge(oDRMTDSlabSales);
                oDSMTDSlabSalesFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSMTDSlabSalesRow in oDSMTDSlabSalesFiltered.BLLPerformanceAnalysis)
                {
                    _oData.MTDSlabActualQty = Convert.ToInt32(oDSMTDSlabSalesRow.Qty);
                }

                InnerList.Add(_oData);
            }


        }
        
        public DSBLLPerformanceAnalysis GetRawData(string sType, string sAreaID, string sTerritoryID, string sCustomerID, string sRouteTypeID, string sRouteID, DateTime dFromDate, DateTime dTodate, string sAndroidAppID, string sUserName, string sDSRID)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL = " Select ASGID, RouteTypeID, Sum(RTQty)as Qty from " +
                  "  ( " +
                  "  select DistributorID,RouteID,RouteTypeID,DSRID,ASGID, sum(Qty)as RTQty  " +
                  "  from " +
                  "  ( " +
                  "  select e.DistributorID,d.RouteID,RouteTypeID,DSRID,ASGID,sum(Qty)as Qty  " +
                  "  from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, DWDB.dbo.t_ProductDetails c, BLLSysDB.dbo.t_DMSOutlet d, BLLSysDB.dbo.t_DMSRoute e  " +
                  "  where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dFromDate + "'  and '" + dTodate + "'   and Trandate < '" + dTodate + "'   " +
                  "  and b.ProductID=c.ProductID and a.OutletID=d.outletID and d.RouteID=e.RouteID and CompanyName='BLL' " +
                  "  group by e.DistributorID,d.RouteID,RouteTypeID,DSRID, ASGID " +
                  "  union all " +
                  "  select DistributorID,RouteID, RouteTypeID, DSRID,c.ASGID,sum(Qty)as RtQty  " +
                  "  from BLLSysDB.dbo.t_DMSRoute a, DWDB.dbo.t_SMSSecondarySales b, DWDB.dbo.t_SMSSecondarySalesItem c,  " +
                  "  (Select Distinct ASGID, ASGName,ASGSort from DWDB.dbo.t_ProductDetails Where companyName='BLL') d " +
                  "  Where RouteName='SMS Route' and a.DistributorID=b.CustomerID and b.TranID=c.TranID " +
                  "  and TranDate between '" + dFromDate + "'  and '" + dTodate + "'   and Trandate < '" + dTodate + "' and c.ASGID=d.ASGID " +
                  "  group by DistributorID, TranDate,RouteID, RouteTypeID,DSRID,c.ASGID " +
                  "  )as Total group by DistributorID,RouteID,RouteTypeID,DSRID,ASGID " +
                  "  )a, dwdb.dbo.t_CustomerDetails b Where a.DistributorID=b.customerID and companyname='BLL' ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            if(sType != "National")
            {
                if (sType == "Area")
                {
                    sSQL = sSQL + "  and AreaID = '" + sAreaID + "' ";
                }
                else if (sType == "Territory")
                {
                    sSQL = sSQL + "  and TerritoryID = '" + sTerritoryID + "' ";
                }
                else if (sType == "Customer")
                {
                    sSQL = sSQL + "  and CustomerID = " + sCustomerID + " ";
                }
                else if (sType == "Route")
                {
                    sSQL = sSQL + " and DSRID=" + sDSRID + " and CustomerID = " + sCustomerID + " ";
                }
                else 
                {
                    sSQL = sSQL + "  and RouteID=" + sRouteID + " ";
                }
            }
            sSQL = sSQL + "  Group by ASGID, RouteTypeID ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = Convert.ToInt32(reader["ASGID"]);
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();
                    oBLLPerformanceAnalysisRow.Qty = Convert.ToInt32(reader["Qty"]);

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
        
        public DSBLLPerformanceAnalysis GetOrderData(string sType, string sAreaID, string sTerritoryID, string sCustomerID, string sRouteTypeID, string sRouteID, DateTime dFromDate, DateTime dTodate, string sAndroidAppID, string sUserName, string sDSRID)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL = " Select ASGID, RouteTypeID, Sum(Qty)as Qty from " +
                   " ( " +
                   " Select * from  " +
                   " ( " +
                   " select 126 as ASGID, DistributorID, DSRID, RouteTypeID, sum(CFLQty)as Qty  " +
                   " from BLLSysDB.dbo.t_SMSRouteOrder a,BLLSysDB.dbo.t_DMSRoute b  " +
                   " where orderDate between '" + dFromDate + "' and '" + dTodate + "' and orderDate < '" + dTodate + "'  and a.RouteCode=b.RouteID " +
                   " group by DistributorID, RouteTypeID, DSRID  " +
                   " UNION ALL " +
                   " select 125 as ASGID, DistributorID, DSRID, RouteTypeID, sum(GLSQty)as Qty  " +
                   " from BLLSysDB.dbo.t_SMSRouteOrder a,BLLSysDB.dbo.t_DMSRoute b  " +
                   " where orderDate between '" + dFromDate + "' and '" + dTodate + "' and orderDate < '" + dTodate + "'  and a.RouteCode=b.RouteID " +
                   " group by DistributorID, RouteTypeID, DSRID  " +
                   " UNION ALL " +
                   " select 127 as ASGID, DistributorID, DSRID, RouteTypeID, sum(TLQty)as Qty  " +
                   " from BLLSysDB.dbo.t_SMSRouteOrder a,BLLSysDB.dbo.t_DMSRoute b  " +
                   " where orderDate between '" + dFromDate + "' and '" + dTodate + "' and orderDate < '" + dTodate + "'  and a.RouteCode=b.RouteID " +
                   " group by DistributorID, RouteTypeID, DSRID  " +
                   " UNION ALL " +
                   " select 714 as ASGID, DistributorID, DSRID, RouteTypeID, sum(LEDQty) as Qty  " +
                   " from BLLSysDB.dbo.t_SMSRouteOrder a,BLLSysDB.dbo.t_DMSRoute b  " +
                   " where orderDate between '" + dFromDate + "' and '" + dTodate + "' and orderDate < '" + dTodate + "'  and a.RouteCode=b.RouteID " +
                   " group by DistributorID, RouteTypeID, DSRID  " +
                   " ) a, DWDB.dbo.t_CustomerDetails b Where a.DistributorID=b.customerID and companyname='BLL' ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            if (sType != "National")
            {
                if (sType == "Area")
                {
                    sSQL = sSQL + "  and AreaID = '" + sAreaID + "' ";
                }
                else if (sType == "Territory")
                {
                    sSQL = sSQL + "  and TerritoryID = '" + sTerritoryID + "' ";
                }
                else if (sType == "Customer")
                {
                    sSQL = sSQL + "  and CustomerID = " + sCustomerID + " ";
                }
                else if (sType == "Route")
                {
                    sSQL = sSQL + " and DSRID=" + sDSRID + " and CustomerID = " + sCustomerID + " ";
                }
                else
                {
                    sSQL = sSQL + "  and RouteID=" + sRouteID + " ";
                }
            }
            sSQL = sSQL + "  )x  Group by ASGID, RouteTypeID ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = Convert.ToInt32(reader["ASGID"]);
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();
                    oBLLPerformanceAnalysisRow.Qty = Convert.ToInt32(reader["Qty"]);

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
        
        public DSBLLPerformanceAnalysis GetRawDataTarget(string sType, string sAreaID, string sTerritoryID, string sCustomerID, string sRouteTypeID, string sRouteID, DateTime dFromDate, DateTime dTodate, string sAndroidAppID, string sUserName, string sDSRID)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();
            sSQL = " select a.ASGID, RouteTypeID, Sum(TSMTGTQty) as Qty from bllsysdb.dbo.t_DMSASGTarget a, DWDB.dbo.t_CustomerDetails b, " +
                   " BLLSysDB.dbo.t_DMSRoute c  " +
                   " Where a.DistributorID=b.CustomerID and CompanyName='BLL' and a.RouteID=c.RouteID " +
                   " and Targetdate between '" + dFromDate + "'  and '" + dTodate + "'   and Targetdate < '" + dTodate + "' ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            if (sType != "National")
            {
                if (sType == "Area")
                {
                    sSQL = sSQL + "  and AreaID = '" + sAreaID + "' ";
                }
                else if (sType == "Territory")
                {
                    sSQL = sSQL + "  and TerritoryID = '" + sTerritoryID + "' ";
                }
                else if (sType == "Customer")
                {
                    sSQL = sSQL + "  and CustomerID = " + sCustomerID + " ";
                }
                else if (sType == "Route")
                {
                    sSQL = sSQL + " and DSRID=" + sDSRID + " and CustomerID = " + sCustomerID + " ";
                }
                else
                {
                    sSQL = sSQL + "  and a.RouteID=" + sRouteID + " ";
                }
            }
            sSQL = sSQL + "  Group by a.ASGID, RouteTypeID ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = Convert.ToInt32(reader["ASGID"]);
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();
                    oBLLPerformanceAnalysisRow.Qty = Convert.ToInt32(reader["Qty"]);

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
        
        public DSBLLPerformanceAnalysis GetRawDataSlabTarget(string sType, string sAreaID, string sTerritoryID, string sCustomerID, string sRouteTypeID, string sRouteID, DateTime dFromDate, DateTime dTodate, string sAndroidAppID, string sUserName, string sDSRID)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL = " select a.ASGID, RouteTypeID, sum(TSMTGTQty)as Qty "+
                   " from BLLSysDb.dbo.t_DMSASGTarget a, BLLSysDb.dbo.t_DMSClusterOutlet b, "+
                   " BLLSysDb.dbo.t_DMSRoute c, "+
                   " (select * from dwdb.dbo.t_CustomerDetails where CompanyName='BLL')as d "+
                   " where TargetDate between '" + dFromDate + "' and '" + dTodate + "' and TargetDate < '" + dTodate + "' " +
                   " and OutletID>0 and a.OutletID=b.RetailID and b.RouteID=c.RouteID and  b.CustomerID=d.CustomerID  ";

            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            if (sType != "National")
            {
                if (sType == "Area")
                {
                    sSQL = sSQL + "  and AreaID = '" + sAreaID + "' ";
                }
                else if (sType == "Territory")
                {
                    sSQL = sSQL + "  and TerritoryID = '" + sTerritoryID + "' ";
                }
                else if (sType == "Customer")
                {
                    sSQL = sSQL + "  and d.CustomerID = " + sCustomerID + " ";
                }
                else if (sType == "Route")
                {
                    sSQL = sSQL + " and DSRID=" + sDSRID + " and d.CustomerID = " + sCustomerID + " ";
                }
                else
                {
                    sSQL = sSQL + "  and c.RouteID=" + sRouteID + " ";
                }
            }
            sSQL = sSQL + " group by RouteTypeID, a.ASGID ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = Convert.ToInt32(reader["ASGID"]);
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();
                    oBLLPerformanceAnalysisRow.Qty = Convert.ToInt32(reader["Qty"]);

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
        
        public DSBLLPerformanceAnalysis GetRawDataSlabSales(string sType, string sAreaID, string sTerritoryID, string sCustomerID, string sRouteTypeID, string sRouteID, DateTime dFromDate, DateTime dTodate, string sAndroidAppID, string sUserName, string sDSRID)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();
            sSQL = " select ASGID,RouteTypeID, sum(Qty)As Qty " +
                   " from " +
                   " ( " +
                   " select OutletID, ASGID,RouteID, Qty " +
                   " from " +
                   " ( " +
                   //" select OutletID, ASGID, sum(Qty)as Qty " +
                   //" from BLLSysDb.dbo.t_DMSASGWiseSales a, BLLSysDb.dbo.t_DMSASGWiseSalesDetails b " +
                   //" where EntryDate between '" + dFromDate + "' and '" + dTodate + "' and EntryDate < '" + dTodate + "' " +
                   //" and a.ID=b.SalesID  " +
                   //" group by OutletID, ASGID " +

                   //" select  OutletID,ASGID, sum(Qty)as Qty " +
                   //" from BLLSysDb.dbo.t_DMSKACSales a,BLLSysDb.dbo.t_DMSKACSalesItem b, BLLSysDb.dbo.v_ProductDetails c, BLLSysDb.dbo.t_DMSClusterOutlet d " +
                   //" where a.TransactionID=b.TranID and TranDate between '" + dFromDate + "' and '" + dTodate + "' and TranDate < '" + dTodate + "' " +
                   //" and b.ProductID=c.ProductID and a.OutletID=d.RetailID " +
                   //" group by OutletID,ASGID " +

                   " select  OutletID,ASGID, sum(SaleQty)as Qty " +
                   " from BLLSysDb.dbo.t_DMSOrder a,BLLSysDb.dbo.t_DMSOrderItem b, BLLSysDb.dbo.v_ProductDetails c, BLLSysDb.dbo.t_DMSClusterOutlet d " +
                   " where a.TranID=b.TranID and DeliveryDate between '" + dFromDate + "' and '" + dTodate + "' and DeliveryDate < '" + dTodate + "' " +
                   " and b.ProductID=c.ProductID and a.OutletID=d.RetailID and a.IsDelivered=1 and DeliveryAmount>0 and d.SlabOutlet=1 " +
                   " group by OutletID,ASGID " +

                   " )As Q1 " +
                   " inner join BLLSysDb.dbo.t_DMSClusteroutlet as Q2 on Q1.OutletID=Q2.RetailID " +
                   " )As Total " +
                   " inner join BLLSysDb.dbo.t_DMSRoute as Q3 on Total.RouteID=Q3.RouteID " +
                   " inner join  (select * from dwdb.dbo.t_CustomerDetails where CompanyName='BLL')as b on Q3.DistributorID=b.CustomerID " +
                   " Where 1=1  ";

            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            if (sType != "National")
            {
                if (sType == "Area")
                {
                    sSQL = sSQL + "  and AreaID = '" + sAreaID + "' ";
                }
                else if (sType == "Territory")
                {
                    sSQL = sSQL + "  and TerritoryID = '" + sTerritoryID + "' ";
                }
                else if (sType == "Customer")
                {
                    sSQL = sSQL + "  and CustomerID = " + sCustomerID + " ";
                }
                else if (sType == "Route")
                {
                    sSQL = sSQL + " and DSRID=" + sDSRID + " and CustomerID = " + sCustomerID + " ";
                }
                else
                {
                    sSQL = sSQL + "  and Total.RouteID=" + sRouteID + " ";
                }
            }
            sSQL = sSQL + " group by ASGID, RouteTypeID ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = Convert.ToInt32(reader["ASGID"]);
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();
                    oBLLPerformanceAnalysisRow.Qty = Convert.ToInt32(reader["Qty"]);

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
        
        public DSBLLPerformanceAnalysis GetCustomerStock(string sType, string sAreaID, string sTerritoryID, string sCustomerID, string sAndroidAppID, string sUserName)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();
            sSQL = " select ASGID, sum(CRStock) as CRStock, round(sum(StockVal),0)as StockVal " +
                   " from " +
                   " ( " +
                   " select a.ProductID,ASGID,a.DistributorID,NSP, sum(CurrentStock)as CRStock, sum(CurrentStock*NSP*.95)as StockVal " +
                   " from BLLSysDB.dbo.t_DMSProductStock a, BLLSysDB.dbo.t_DMSuser b, BLLSysDB.dbo.v_ProductDetails c, DWDB.dbo.t_CustomerDetails d " +
                   " where a.DistributorID=b.DistributorID and CurrentStock >=0 and a.DistributorID in  " +
                   " (select DistributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1) and a.ProductID=c.ProductID and a.DistributorID=d.CustomerID  " +
                   " and d.CompanyName='BLL' ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and d.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            if (sType != "National")
            {
                if (sType == "Area")
                {
                    sSQL = sSQL + "  and d.AreaID = '" + sAreaID + "' ";
                }
                else if (sType == "Territory")
                {
                    sSQL = sSQL + "  and d.TerritoryID = '" + sTerritoryID + "' ";
                }
                else if (sType == "Customer")
                {
                    sSQL = sSQL + "  and d.CustomerID = " + sCustomerID + " ";
                }

            }
            sSQL = sSQL + "  group by a.ProductID,ASGID,a.DistributorID, NSP)as Q1 Group by ASGID ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = Convert.ToInt32(reader["ASGID"]);
                    oBLLPerformanceAnalysisRow.Qty = Convert.ToInt32(reader["CRStock"]);

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

        public DSBLLPerformanceAnalysis GetBufferStock(string sType, string sAreaID, string sTerritoryID, string sCustomerID, string sAndroidAppID, string sUserName)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();
            sSQL = " select ASGID, Sum(BufferStock) as BufferStock from BLLsysDB.dbo.t_BufferStock a, " +
                   " BLLSysDB.dbo.v_ProductDetails b, DWDB.dbo.t_CustomerDetails c " +
                   " Where a.CustomerID=c.CustomerID and a.ProductID=b.ProductID and c.CompanyName='BLL' ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and a.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            if (sType != "National")
            {
                if (sType == "Area")
                {
                    sSQL = sSQL + "  and AreaID = '" + sAreaID + "' ";
                }
                else if (sType == "Territory")
                {
                    sSQL = sSQL + "  and TerritoryID = '" + sTerritoryID + "' ";
                }
                else if (sType == "Customer")
                {
                    sSQL = sSQL + "  and c.CustomerID = " + sCustomerID + " ";
                }

            }
            sSQL = sSQL + "  Group by ASGID ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = Convert.ToInt32(reader["ASGID"]);
                    oBLLPerformanceAnalysisRow.Qty = Convert.ToInt32(reader["BufferStock"]);

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
        
        public DSBLLPerformanceAnalysis GetASGList()
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            //sSQL = " Select * from (Select ASGID, ASGName, ASGSort from DWDB.dbo.t_ProductDetails where CompanyName='BLL' " +
            //       " and ASGID IN (126,125,127,139,140,708,712,713,714,715, 739,752,695) Group by ASGID, ASGName, ASGSort) a, " +
            //       " (Select RouteTypeID from BLLSysDB.dbo.t_DMSRoute Group by RouteTypeID)b  Order by ASGSort ";

            sSQL = " Select * from (Select ASGID, ASGName, ASGSort from DWDB.dbo.t_ProductDetails where CompanyName='BLL' " +
                   " and ASGID not IN (129, 130, 131, 132, 135, 138, 142, 438, 656, 672, 677, 760, 762, 764, 767) Group by ASGID, ASGName, ASGSort) a, " +
                   " (Select RouteTypeID from BLLSysDB.dbo.t_DMSRoute Group by RouteTypeID)b Order by ASGSort ";



            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = (int)reader["ASGID"];
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();

                    if (reader["ASGName"].ToString() != "CFL")
                    {
                        oBLLPerformanceAnalysisRow.ASGName = reader["ASGName"].ToString();
                    }
                    else
                    {
                        oBLLPerformanceAnalysisRow.ASGName = reader["ASGName"].ToString()+"-Green";
                    }
                    

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
            CalendarWeek oCalendarWeek = new CalendarWeek();
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();

            foreach (Data oData in this)
            {

                _oData = new Data();
                int nRemainingDay = oCalendarWeek.GetReamainingDateBLL();

                _oData.ASGName = oData.ASGName;
                _oData.RouteTypeID = oData.RouteTypeID;
                _oData.CMSTQtyText = oData.CMSTQty.ToString();
                _oData.CMSAMTDQtyText = oData.CMSAMTDQty.ToString();
                _oData.LMSAMTDQtyText = oData.LMSAMTDQty.ToString();
                _oData.LMSAQtyText = oData.LMSAQty.ToString();
                _oData.LYCMSAQtyText = oData.LYCMSAQty.ToString();
                _oData.LYCMSAMTDQtyText = oData.LYCMSAMTDQty.ToString();
                _oData.DBStockQtyText = oData.DBStockQty.ToString();
                _oData.DBBufferStockQtyText = oData.DBBufferStockQty.ToString();

                _oData.LDQtyText = oData.LDQty.ToString();
                _oData.YTDQtyText = oData.YTDQty.ToString();
                _oData.LYYTDQtyText = oData.LYYTDQty.ToString();
                _oData.LYQtyText = oData.LYQty.ToString();

                _oData.LDOrderQtyText = oData.LDOrderQty.ToString();
                _oData.MTDOrderQtyText = oData.MTDOrderQty.ToString();
                _oData.SlabTargetQtyText = oData.SlabTargetQty.ToString();
                _oData.MTDSlabActualQtyText = oData.MTDSlabActualQty.ToString();
                _oData.MTDRetailQtyText = Convert.ToString(oData.CMSAMTDQty - oData.MTDSlabActualQty);
                
                int _balance = oData.CMSTQty - oData.CMSAMTDQty;
                if (_balance > 0)
                {
                    _oData.TodayTarget = Convert.ToString(Math.Round(Convert.ToDouble(_balance) / nRemainingDay,0));
                }
                else
                {
                    _oData.TodayTarget = "0";
                }

                if (oData.CMSTQty > 0)
                {
                    _oData.GSCMMTDPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.CMSAMTDQty) / oData.CMSTQty) * 100));
                }
                else
                {
                    _oData.GSCMMTDPercText = "0";
                }

                if (oData.LMSAMTDQty > 0)
                {
                    _oData.GSLMMTDPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.CMSAMTDQty) - oData.LMSAMTDQty) / oData.LMSAMTDQty * 100));
                }
                else
                {
                    _oData.GSLMMTDPercText = "0";
                }

                if (oData.CMSTQty > 0)
                {
                    _oData.GSLMFullPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.LMSAQty) / oData.CMSTQty) * 100));
                }
                else
                {
                    _oData.GSLMFullPercText = "0";
                }
                if (oData.CMSTQty > 0)
                {
                    _oData.GSLYCMFullPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.LYCMSAQty) / oData.CMSTQty) * 100));
                }
                else
                {
                    _oData.GSLYCMFullPercText = "0";
                }
                if (oData.LYCMSAMTDQty > 0)
                {
                    _oData.GSLYCMMTDPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.CMSAMTDQty) - oData.LYCMSAMTDQty) / oData.LYCMSAMTDQty * 100));
                }
                else
                {
                    _oData.GSLYCMMTDPercText = "0";
                }
                if (oData.DBBufferStockQty > 0)
                {
                    _oData.StockPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.DBStockQty) / oData.DBBufferStockQty) * 100));
                }
                else
                {
                    _oData.StockPercText = "0";
                }
                if (oData.LYYTDQty > 0)
                {
                    _oData.GSYTDQtyPercText = Convert.ToString(Math.Round((oData.YTDQty - oData.LYYTDQty) / oData.LYYTDQty * 100));
                }
                else
                {
                    _oData.GSYTDQtyPercText = "0";
                }
                if (oData.LDOrderQty > 0)
                {
                    _oData.LDOrderPercText = Convert.ToString(Math.Round((oData.LDQty/oData.LDOrderQty) * 100));
                }
                else
                {
                    _oData.LDOrderPercText = "0";
                }
                if (oData.MTDOrderQty > 0)
                {
                    _oData.MTDDeliveryPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.CMSAMTDQty) / oData.MTDOrderQty) * 100));
                }
                else
                {
                    _oData.MTDDeliveryPercText = "0";
                }
                if (oData.SlabTargetQty > 0)
                {
                    _oData.MTDSlabPercText = Convert.ToString(Math.Round((oData.MTDSlabActualQty / Convert.ToDouble(oData.SlabTargetQty)) * 100));
                }
                else
                {
                    _oData.MTDSlabPercText = "0";
                }
                if (oData.CMSAMTDQty > 0)
                {
                    _oData.MTDSlabContributionPercText = Convert.ToString(Math.Round((oData.MTDSlabActualQty / Convert.ToDouble(oData.CMSAMTDQty)) * 100));
                }
                else
                {
                    _oData.MTDSlabContributionPercText = "0";
                }
                eList.Add(_oData);

            }
            return eList;

        }
    }

}



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

public partial class jBLLPerformanceAnalysis : System.Web.UI.Page
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
            Data _oDataArea = new Data();
            Data _oDataTerritory = new Data();
            Data _oDataCustomer = new Data();
            Data _oDataRouteType = new Data();

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
                    _oDataNational.ShortName = "National";
                    _oDataNational.CustomerCode = "National";
                    _oDataNational.FullName = "National";
                    _oDataNational.AreaID = "0";
                    _oDataNational.TerritoryID = "0";
                    _oDataNational.sReouteID = "0";
                    _oDataNational.Type = "National";
                    _oDataNational.Value = "Success";
                    _oDataNational.IsActive = "1";
                    nCount++;
                }
                if (_oDataArea.AreaName != oData.AreaName)
                {
                    _oDataArea = new Data();
                    _oDatas.Add(_oDataArea);
                    _oDataArea.AreaName = oData.AreaName;
                    _oDataArea.ShortName = oData.AreaName;
                    _oDataArea.CustomerCode = "Area";
                    _oDataArea.FullName = oData.AreaName;
                    _oDataArea.AreaID = oData.AreaID;
                    _oDataArea.TerritoryID = oData.TerritoryID;
                    _oDataArea.sReouteID = oData.sReouteID;
                    _oDataArea.Type = "Area";
                    _oDataArea.Value = "Success";
                    _oDataArea.IsActive = "1";
                }
                if (_oDataTerritory.TerritoryName != oData.TerritoryName)
                {
                    _oDataTerritory = new Data();
                    _oDatas.Add(_oDataTerritory);
                    _oDataTerritory.TerritoryName = oData.TerritoryName;
                    _oDataTerritory.ShortName = oData.TerritoryName;
                    _oDataTerritory.CustomerCode = "Territory";
                    _oDataTerritory.FullName = oData.TerritoryName;
                    _oDataTerritory.AreaID = oData.AreaID;
                    _oDataTerritory.TerritoryID = oData.TerritoryID;
                    _oDataTerritory.sReouteID = oData.sReouteID;
                    _oDataTerritory.Type = "Territory";
                    _oDataTerritory.Value = "Success";
                    _oDataTerritory.IsActive = "1";
                }

                _oDataCustomer = new Data();
                _oDataCustomer.Value = "Success";

                //_oDataCustomer.ShortName = oData.ShortName;
                _oDataCustomer.ShortName = oData.Route;
                _oDataCustomer.CustomerCode = oData.CustomerCode;
                _oDataCustomer.FullName = oData.Route;
                //_oDataCustomer.FullName = "DSR: " + oData.DSRName + " | " + oData.DSRMobileNo;

                _oDataCustomer.CMSTValue = oData.CMSTValue;
                _oDataCustomer.CMSAMTDValue = oData.CMSAMTDValue;
                _oDataCustomer.LMSAMTDValue = oData.LMSAMTDValue;
                _oDataCustomer.LMSAValue = oData.LMSAValue;
                _oDataCustomer.LYCMSAValue = _oData.LYCMSAValue;
                _oDataCustomer.AreaID = oData.AreaID;
                _oDataCustomer.TerritoryID = oData.TerritoryID;
                _oDataCustomer.sReouteID = oData.sReouteID;
                _oDataCustomer.IsActive = oData.IsActive;
                _oDataCustomer.Type = "Customer";
                _oDatas.Add(_oDataCustomer);

                _oDataNational.CMSTValue = _oDataNational.CMSTValue + oData.CMSTValue;
                _oDataNational.CMSAMTDValue = _oDataNational.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataNational.LMSAMTDValue = _oDataNational.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataNational.LMSAValue = _oDataNational.LMSAValue + oData.LMSAValue;
                _oDataNational.LYCMSAValue = _oDataNational.LYCMSAValue + _oData.LYCMSAValue;

                _oDataArea.CMSTValue = _oDataArea.CMSTValue + oData.CMSTValue;
                _oDataArea.CMSAMTDValue = _oDataArea.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataArea.LMSAMTDValue = _oDataArea.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataArea.LMSAValue = _oDataArea.LMSAValue + oData.LMSAValue;
                _oDataArea.LYCMSAValue = _oDataArea.LYCMSAValue + _oData.LYCMSAValue;

                _oDataTerritory.CMSTValue = _oDataTerritory.CMSTValue + oData.CMSTValue;
                _oDataTerritory.CMSAMTDValue = _oDataTerritory.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataTerritory.LMSAMTDValue = _oDataTerritory.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataTerritory.LMSAValue = _oDataTerritory.LMSAValue + oData.LMSAValue;
                _oDataTerritory.LYCMSAValue = _oDataTerritory.LYCMSAValue + _oData.LYCMSAValue;
            }
            _oData.InsertReportLog(sUser);

            TELLib _oTELLib = new TELLib();
            DateTime dFromDate = DateTime.Now.Date;
            int DayOfYear = dFromDate.DayOfYear;
            int TotalDayOfYear = _oTELLib.GetDaysInYear(dFromDate.Year);
            int DayOfMonth = dFromDate.Day;
            DateTime dLastDateOfMonth = _oTELLib.LastDayofMonth(dFromDate);
            int TotalDayOfMonth = dLastDateOfMonth.Day;

            //int xx = _oTELLib.LastDayofMonth(dFromDate.Day);
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(DayOfMonth, TotalDayOfMonth, DayOfYear, TotalDayOfYear), Formatting.Indented);
            Response.Write(sOutput.ToString());

        }
    }
    public class Data
    {
        // C = Current, M = Month, P=Primary, T=Target, L=Last, Y=Year, A=Actual

        public string AreaName;
        public string AreaID;
        public string TerritoryName;
        public string TerritoryID;
        public string ShortName;
        public string FullName;
        public string CustomerCode;
        public string Route;
        public int nReouteID;
        public string sReouteID;
        public string Type;
        public string Value;
        public string IsActive;
        public string ActiveStatus;
        public string RouteTypeID;
        public string RouteTypeName;
        public string DSRMobileNo;
        public string DSRName;

        public double CMSTValue;
        public double CMSAMTDValue;
        public double LMSAMTDValue;
        public double LMSAValue;
        public double LYCMSAValue;

        public string CMSTValueText;
        public string CMSAMTDValueText;
        public string LMSAMTDValueText;
        public string LMSAValueText;
        public string LYCMSAValueText;

        public string GSCMMTDPercText;
        public string GSLMMTDPercText;
        public string GSLMFullPercText;
        public string GSLYCMFullPercText;


        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10035";
            string sReportName = "BLL-Route Sales (Value/ASG Qty)";
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
            DSBLLPerformanceAnalysis oDSCMSAMTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLMSAMTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLMSA = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLYCMSA = new DSBLLPerformanceAnalysis();

            #region Collapse

            
            //DSBLLPerformanceAnalysis oDSCMSA = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSLMPA = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSLMSA = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSLMPAMTD = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSLMSAMTD = new DSBLLPerformanceAnalysis();

            //DSBLLPerformanceAnalysis oDSLYCMPAMTD = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSLYCMPA = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSLYCMSAMTD = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSLYCMSA = new DSBLLPerformanceAnalysis();


            //DSBLLPerformanceAnalysis oDSCYPA = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSCYSA = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSLYPA = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSLYSA = new DSBLLPerformanceAnalysis();

            //DSBLLPerformanceAnalysis oDSCMTarget = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSLMTarget = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSCYTarget = new DSBLLPerformanceAnalysis();

            //DSBLLPerformanceAnalysis oDSStockValue = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSBG = new DSBLLPerformanceAnalysis();

            //DSBLLPerformanceAnalysis oDSCollMTD = new DSBLLPerformanceAnalysis();
            //DSBLLPerformanceAnalysis oDSCollLM = new DSBLLPerformanceAnalysis();
            #endregion
            oDSCustomer = GetCustomerList();
            oDSCMST = GetRawDataTarget(_FirstDayofMonth, _FirstDayofNextMonth);
            oDSCMSAMTD = GetRawData("SecondaryActual", _FirstDayofMonth, dToDate);
            oDSLMSAMTD = GetRawData("SecondaryActual", _FirstDayofLastMonth, _ToDateOfLastMonth);
            oDSLMSA = GetRawData("SecondaryActual", _FirstDayofLastMonth, _FirstDayofMonth);
            oDSLYCMSA = GetRawData("SecondaryActual", _FristDayofLastYearThisMonth, _FristDayofLastYearNextMonth);

            #region Collapse

            //oDSCMPA = GetRawData("PrimaryActual", _FirstDayofMonth, dToDate);
            //

            //oDSLMPA = GetRawData("PrimaryActual", _FirstDayofLastMonth, _FirstDayofMonth);
            //oDSLMPAMTD = GetRawData("PrimaryActual", _FirstDayofLastMonth, _ToDateOfLastMonth);
            //oDSLMSA = GetRawData("SecondaryActual", _FirstDayofLastMonth, _FirstDayofMonth);
            //oDSLMSAMTD = GetRawData("SecondaryActual", _FirstDayofLastMonth, _ToDateOfLastMonth);

            //oDSLYCMPAMTD = GetRawData("PrimaryActual", _FristDayofLastYearThisMonth, _ToDateofLastYearThisMonth);
            //oDSLYCMPA = GetRawData("PrimaryActual", _FristDayofLastYearThisMonth, _FristDayofLastYearNextMonth);
            //oDSLYCMSAMTD = GetRawData("SecondaryActual", _FristDayofLastYearThisMonth, _ToDateofLastYearThisMonth);
            //oDSLYCMSA = GetRawData("SecondaryActual", _FristDayofLastYearThisMonth, _FristDayofLastYearNextMonth);

            //oDSCYPA = GetRawData("PrimaryActual", _FirstDayofThisYear, dToDate);
            //oDSCYSA = GetRawData("SecondaryActual", _FirstDayofThisYear, dToDate);
            //oDSLYPA = GetRawData("PrimaryActual", _FirstDayofLastYear, _FirstDayofThisYear);
            //oDSLYSA = GetRawData("SecondaryActual", _FirstDayofLastYear, _FirstDayofThisYear);

            //oDSCMTarget = GetRawDataTarget(_FirstDayofMonth, _FirstDayofNextMonth);
            //oDSLMTarget = GetRawDataTarget(_FirstDayofLastMonth, _FirstDayofMonth);
            //oDSCYTarget = GetRawDataTarget(_FirstDayofThisYear, _FirstDayofNextYear);

            //oDSStockValue = GetRawData("StockValue", dFromDate, dToDate);
            //oDSBG = GetRawData("BG", dFromDate, dToDate);

            //oDSCollMTD = GetRawData("Collection", _FirstDayofMonth, dToDate);
            //oDSCollLM = GetRawData("Collection", _FirstDayofLastMonth, _FirstDayofMonth);

            #endregion

            Data _oData;
            InnerList.Clear();

            foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow in oDSCustomer.BLLPerformanceAnalysis)
            {

                _oData = new Data();

                _oData.AreaName = oBLLPerformanceAnalysisRow.AreaName;
                _oData.TerritoryName = oBLLPerformanceAnalysisRow.TerritoryName;
                _oData.FullName = oBLLPerformanceAnalysisRow.CustomerName;
                _oData.ShortName = oBLLPerformanceAnalysisRow.CustomerShortName;
                _oData.CustomerCode = oBLLPerformanceAnalysisRow.CustomerCode;
                _oData.AreaID = oBLLPerformanceAnalysisRow.AreaID;
                _oData.TerritoryID = oBLLPerformanceAnalysisRow.TerritoryID;
                _oData.nReouteID = oBLLPerformanceAnalysisRow.RouteID;
                _oData.sReouteID = oBLLPerformanceAnalysisRow.RouteID.ToString();
                _oData.Route = oBLLPerformanceAnalysisRow.RouteName;
                _oData.IsActive = oBLLPerformanceAnalysisRow.IsActive;
                _oData.DSRMobileNo = oBLLPerformanceAnalysisRow.DSRMobileNo;
                _oData.DSRName = oBLLPerformanceAnalysisRow.DSRName;

                //-----------
                // Current Month Secondary Target
                DSBLLPerformanceAnalysis oDSCMSTFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMST = oDSCMST.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSCMSTFiltered.Merge(oDRCMST);
                oDSCMSTFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSTRow in oDSCMSTFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSTValue = Convert.ToDouble(oDSCMSTRow.Amount);
                }

                // Current Month Secondary Achievement MTD
                DSBLLPerformanceAnalysis oDSCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMSAMTD = oDSCMSAMTD.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSCMSAMTDFiltered.Merge(oDRCMSAMTD);
                oDSCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSAMTDRow in oDSCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSAMTDValue = Convert.ToDouble(oDSCMSAMTDRow.Amount);
                }

                // Last Month Secondary Achievement MTD
                DSBLLPerformanceAnalysis oDSLMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSAMTD = oDSLMSAMTD.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLMSAMTDFiltered.Merge(oDRLMSAMTD);
                oDSLMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSAMTDRow in oDSLMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAMTDValue = Convert.ToDouble(oDSLMSAMTDRow.Amount);
                }

                // Last Month Secondary Achievement
                DSBLLPerformanceAnalysis oDSLMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSA = oDSLMSA.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLMSAFiltered.Merge(oDRLMSA);
                oDSLMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSARow in oDSLMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAValue = Convert.ToDouble(oDSLMSARow.Amount);
                }

                // Last Year This Month Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYCMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYCMSA = oDSLYCMSA.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLYCMSAFiltered.Merge(oDRLYCMSA);
                oDSLYCMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSARow in oDSLYCMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYCMSAValue = Convert.ToDouble(oDSLYCMSARow.Amount);
                }
                #region Collapse
                ////Collection LM
                //DSBLLPerformanceAnalysis oDSCollLMFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRCollLM = oDSCollLM.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSCollLMFiltered.Merge(oDRCollLM);
                //oDSCollLMFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCollLMRow in oDSCollLMFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.CollectionLM = Convert.ToDouble(oDSCollLMRow.Amount);
                //}

                ////StockValue
                //DSBLLPerformanceAnalysis oDSStockValueFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRStockValue = oDSStockValue.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSStockValueFiltered.Merge(oDRStockValue);
                //oDSStockValueFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSStockValueRow in oDSStockValueFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.StockValue = Convert.ToDouble(oDSStockValueRow.Amount);
                //}

                ////BG
                //DSBLLPerformanceAnalysis oDSBGFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRBG = oDSBG.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSBGFiltered.Merge(oDRBG);
                //oDSBGFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSBGRow in oDSBGFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.BG = Convert.ToDouble(oDSBGRow.Amount);
                //}


                ////LYCMPAMTD
                //DSBLLPerformanceAnalysis oDSLYCMPAMTDFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRLYCMPAMTD = oDSLYCMPAMTD.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSLYCMPAMTDFiltered.Merge(oDRLYCMPAMTD);
                //oDSLYCMPAMTDFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMPAMTDRow in oDSLYCMPAMTDFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.LYCMPAMTDValue = Convert.ToDouble(oDSLYCMPAMTDRow.Amount);
                //}

                ////LYCMPA
                //DSBLLPerformanceAnalysis oDSLYCMPAFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRLYCMPA = oDSLYCMPA.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSLYCMPAFiltered.Merge(oDRLYCMPA);
                //oDSLYCMPAFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMPARow in oDSLYCMPAFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.LYCMPAValue = Convert.ToDouble(oDSLYCMPARow.Amount);
                //}

                ////LYCMSAMTD
                //DSBLLPerformanceAnalysis oDSLYCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRLYCMSAMTD = oDSLYCMSAMTD.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSLYCMSAMTDFiltered.Merge(oDRLYCMSAMTD);
                //oDSLYCMSAMTDFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSAMTDRow in oDSLYCMSAMTDFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.LYCMSAMTDValue = Convert.ToDouble(oDSLYCMSAMTDRow.Amount);
                //}

                ////LYCMSA
                //DSBLLPerformanceAnalysis oDSLYCMSAFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRLYCMSA = oDSLYCMSA.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSLYCMSAFiltered.Merge(oDRLYCMSA);
                //oDSLYCMSAFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSARow in oDSLYCMSAFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.LYCMSAValue = Convert.ToDouble(oDSLYCMSARow.Amount);
                //}

                ////------------








                ////CMPA
                //DSBLLPerformanceAnalysis oDSCMPAFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRCMPA = oDSCMPA.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSCMPAFiltered.Merge(oDRCMPA);
                //oDSCMPAFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMPARow in oDSCMPAFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.CMPAValue = Convert.ToDouble(oDSCMPARow.Amount);
                //}

                ////CMSA
                //DSBLLPerformanceAnalysis oDSCMSAFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRCMSA = oDSCMSA.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSCMSAFiltered.Merge(oDRCMSA);
                //oDSCMSAFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSARow in oDSCMSAFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.CMSAValue = Convert.ToDouble(oDSCMSARow.Amount);
                //}

                ////LMPA
                //DSBLLPerformanceAnalysis oDSLMPAFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRLMPA = oDSLMPA.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSLMPAFiltered.Merge(oDRLMPA);
                //oDSLMPAFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMPARow in oDSLMPAFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.LMPAValue = Convert.ToDouble(oDSLMPARow.Amount);
                //}

                ////LMPAMTD
                //DSBLLPerformanceAnalysis oDSLMPAMTDFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRLMPAMTD = oDSLMPAMTD.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSLMPAMTDFiltered.Merge(oDRLMPAMTD);
                //oDSLMPAMTDFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMPAMTDRow in oDSLMPAMTDFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.LMPAMTDValue = Convert.ToDouble(oDSLMPAMTDRow.Amount);
                //}

                ////LMSA
                //DSBLLPerformanceAnalysis oDSLMSAFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRLMSA = oDSLMSA.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSLMSAFiltered.Merge(oDRLMSA);
                //oDSLMSAFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSARow in oDSLMSAFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.LMSAValue = Convert.ToDouble(oDSLMSARow.Amount);
                //}

                ////LMSAMTD
                //DSBLLPerformanceAnalysis oDSLMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRLMSAMTD = oDSLMSAMTD.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSLMSAMTDFiltered.Merge(oDRLMSAMTD);
                //oDSLMSAMTDFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSAMTDRow in oDSLMSAMTDFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.LMSAMTDValue = Convert.ToDouble(oDSLMSAMTDRow.Amount);
                //}

                ////CYPA
                //DSBLLPerformanceAnalysis oDSCYPAFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRCYPA = oDSCYPA.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSCYPAFiltered.Merge(oDRCYPA);
                //oDSCYPAFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCYPARow in oDSCYPAFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.CYPAValue = Convert.ToDouble(oDSCYPARow.Amount);
                //}

                ////CYSA
                //DSBLLPerformanceAnalysis oDSCYSAFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRCYSA = oDSCYSA.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSCYSAFiltered.Merge(oDRCYSA);
                //oDSCYSAFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCYSARow in oDSCYSAFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.CYSAValue = Convert.ToDouble(oDSCYSARow.Amount);
                //}

                ////LYPA
                //DSBLLPerformanceAnalysis oDSLYPAFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRLYPA = oDSLYPA.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSLYPAFiltered.Merge(oDRLYPA);
                //oDSLYPAFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYPARow in oDSLYPAFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.LYPAValue = Convert.ToDouble(oDSLYPARow.Amount);
                //}

                ////LYSA
                //DSBLLPerformanceAnalysis oDSLYSAFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRLYSA = oDSLYSA.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSLYSAFiltered.Merge(oDRLYSA);
                //oDSLYSAFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYSARow in oDSLYSAFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.LYSAValue = Convert.ToDouble(oDSLYSARow.Amount);
                //}

                ////CMTarget
                //DSBLLPerformanceAnalysis oDSCMTargetFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRCMTarget = oDSCMTarget.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSCMTargetFiltered.Merge(oDRCMTarget);
                //oDSCMTargetFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMTargetRow in oDSCMTargetFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.CMPTValue = Convert.ToDouble(oDSCMTargetRow.PrimaryTarget);
                //    _oData.CMSTValue = Convert.ToDouble(oDSCMTargetRow.SecondaryTarget);
                //}

                ////LMTarget
                //DSBLLPerformanceAnalysis oDSLMTargetFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRLMTarget = oDSLMTarget.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSLMTargetFiltered.Merge(oDRLMTarget);
                //oDSLMTargetFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMTargetRow in oDSLMTargetFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.LMPTValue = Convert.ToDouble(oDSLMTargetRow.PrimaryTarget);
                //    _oData.LMSTValue = Convert.ToDouble(oDSLMTargetRow.SecondaryTarget);
                //}

                ////CYTarget
                //DSBLLPerformanceAnalysis oDSCYTargetFiltered = new DSBLLPerformanceAnalysis();
                //DataRow[] oDRCYTarget = oDSCYTarget.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "'");
                //oDSCYTargetFiltered.Merge(oDRCYTarget);
                //oDSCYTargetFiltered.AcceptChanges();
                //foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCYTargetRow in oDSCYTargetFiltered.BLLPerformanceAnalysis)
                //{
                //    _oData.CYPTValue = Convert.ToDouble(oDSCYTargetRow.PrimaryTarget);
                //    _oData.CYSTValue = Convert.ToDouble(oDSCYTargetRow.SecondaryTarget);
                //}
                #endregion
                InnerList.Add(_oData);
            }


        }
        public DSBLLPerformanceAnalysis GetRawData(string sType, DateTime dFromDate, DateTime dTodate)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sType == "SecondaryActual")
            {
                cmd = DBController.Instance.GetCommand();
                //Old
                //sSQL = " Select b.RouteID as RouteID, Sum(NetAmount) as Value from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSOutlet b " +
                //       " where a.OutletID=b.OutletID and TranTypeID=2 and Trandate between '" + dFromDate + "' and '" + dTodate + "'   " +
                //       " and Trandate < '" + dTodate + "'  Group by b.RouteID ";

                //New
                sSQL = " Select RouteID, Sum(Value *.95) as Value From " +
                "( " +
                "Select b.RouteID as RouteID, Sum(NetAmount) as Value from BLLSysDB.dbo.t_DMSProductTran a,  " +
                "BLLSysDB.dbo.t_DMSOutlet b, BLLSysDB.dbo.t_DMSUser c  " +
                "where a.OutletID=b.OutletID and a.DistributorID=c.DistributorID and Trandate >=ActivatedDate  "+
                "and TranTypeID=2 and Trandate between '" + dFromDate + "' and '" + dTodate + "' " +
                "and Trandate < '" + dTodate + "' Group by b.RouteID " +
                "UNION ALL " +
                "SElect b.RouteID, Value from " +
                "( " +
                "Select CustomerID, Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales a, BLLSysDB.dbo.t_DMSUser b Where  " +
                "Trandate between '" + dFromDate + "' and '" + dTodate + "' " +
                "and Trandate < '" + dTodate + "' and ActivatedDate > Trandate and a.CustomerID=b.DistributorID Group by CustomerID " +
                "UNION ALL " +
                "Select CustomerID, Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales Where  " +
                "Trandate between '" + dFromDate + "' and '" + dTodate + "' " +
                "and Trandate < '" + dTodate + "' and CustomerID Not IN (Select DistributorID From BLLSysDB.dbo.t_DMSUser Where IsActive=1)  " +
                "Group by CustomerID " +
                ") a, " +
                "(Select RouteID, DistributorID from BLLSysDB.dbo.t_DMSRoute Where RouteName='SMS Route')b " +
                "Where a.CustomerID=b.DistributorID " +
                ")x Group by RouteID ";


            }
            #region Collapse

            //if (sType == "PrimaryActual")
            //{
            //    cmd = DBController.Instance.GetCommand();
            //    sSQL = " select CustomerID, sum (Amount)as Value " +
            //           " from   " +
            //           " (    " +
            //           " select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount " +
            //           " from   " +
            //           " (     " +
            //           " select CustomerID,sum(invoiceamount) as crAmount, 0 as drAmount  " +
            //           " from bllsysdb.dbo.t_salesInvoice  " +
            //           " where invoicedate between '" + dFromDate + "' and '" + dTodate + "'  and invoicedate < '" + dTodate + "' " +
            //           " and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3)  " +
            //           " group by  CustomerID  " +
            //           " union all  " +
            //           " select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount  " +
            //           " from bllsysdb.dbo.t_salesInvoice  " +
            //           " where invoicedate between '" + dFromDate + "' and '" + dTodate + "'  and invoicedate < '" + dTodate + "'  " +
            //           " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)    " +
            //           " group by CustomerID     " +
            //           " )as p2       " +
            //           " group by CustomerID   " +
            //           " ) as TELBLL   " +
            //           " group by CustomerID ";
            //}
            //else if (sType == "SecondaryActual")
            //{
            //    cmd = DBController.Instance.GetCommand();
            //    sSQL = " select DistributorID as CustomerID, sum(Amount) as Value  " +
            //          " from     " +
            //          " (    " +
            //          " select DistributorID, sum(NetAmount)as Amount      " +
            //          " from BLLSysDB.dbo.t_DMSProductTran      " +
            //          " where TranTypeID=2 and Trandate between '" + dFromDate + "' and '" + dTodate + "'  and Trandate < '" + dTodate + "'  " +
            //          " and DistributorID in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)       " +
            //          " group by DistributorID     " +
            //          " union all     " +
            //          " select b.CustomerID,  sum(TEBL) as Amount     " +
            //          " from TELSysDB.dbo.t_SMSDailySecondarySalesCollection a, BLLSysDB.dbo.t_Customer b     " +
            //          " where trandate between '" + dFromDate + "' and '" + dTodate + "'  and Trandate < '" + dTodate + "' and a.CustomerID=b.CustomerCode    " +
            //          " and b.CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)      " +
            //          " group by b.CustomerID    " +
            //          " )as TTO    " +
            //          " group by DistributorID  ";
            //}
            //else if (sType == "StockValue")
            //{
            //    cmd = DBController.Instance.GetCommand();
            //    sSQL = " select DistributorID as CustomerID, round(sum(STKVal),0)as Value " +
            //           " from     " +
            //           " (     " +
            //           " select DistributorID,a.productID,ASGID,ASGName,BrandID, BrandDesc, CurrentStock, NSP, (NSP*CurrentStock*.95)as STKVal          " +
            //           " from BLLSysDB.dbo.t_DMSProductStock a, BLLSysDB.dbo.V_ProductDetails b         " +
            //           " where a.ProductID=b.ProductID and DistributorID in (select DistributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)    " +
            //           " and CurrentStock>0      " +
            //           " )As ASGStock      " +
            //           " group by DistributorID ";
            //}
            //else if (sType == "BG")
            //{
            //    cmd = DBController.Instance.GetCommand();
            //    sSQL = " select CustomerID, Sum(MinCreditLimit) as Value  " +
            //    " from BLLSysDB.dbo.t_CustomerCreditlimit " +
            //    " where '" + dFromDate + "' between effectivedate and ExpiryDate " +
            //    " Group by CustomerID ";
            //}
            //else if (sType == "Collection")
            //{
            //    cmd = DBController.Instance.GetCommand();
            //    sSQL = " select  CustomerID, sum(CreditAmount-DebitAmount)as Value    " +
            //           " from     " +
            //           " (     " +
            //           " select customerid, sum(amount)as CreditAmount, 0 as DebitAmount  from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt      " +
            //           " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between '" + dFromDate + "' and '" + dTodate + "'  and  ct.TranDate < '" + dTodate + "'     " +
            //           " group by customerid        " +
            //           " union all        " +
            //           " select customerid, 0 as CreditAmount, sum(amount)as DebitAmount  from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt        " +
            //           " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)  and ct.TranDate between '" + dFromDate + "' and '" + dTodate + "'  and  ct.TranDate < '" + dTodate + "'    " +
            //           " group by customerid     " +
            //           " )as Coll     " +
            //           " group by CustomerID  ";
            //}
            #endregion
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.RouteID = Convert.ToInt32(reader["RouteID"]);
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
        
        public DSBLLPerformanceAnalysis GetRawDataTarget(DateTime dFromDate, DateTime dTodate)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis(); 

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

                cmd = DBController.Instance.GetCommand();
                //, string sType, string sValue
                //if (sType == "All")
                {
                    sSQL = " select RouteID, SUM(TSMTGTTO)Amount from BLLSysDB.dbo.t_DMSTargetTO Where TGTDate Between '" + dFromDate + "' " +
                            " and '" + dTodate + "' and TGTDate < '" + dTodate + "' Group by RouteID";
                }
                //else if (sType == "All")
                //{ 
                
                
                //}


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.RouteID = Convert.ToInt32(reader["RouteID"]);
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

            //sSQL = " Select CustomerID, CustomerCode, CustomerName, CustomerShortName, AreaID, AreaShortName, TerritoryID, " +
            //       " TerritoryShortName, RouteID, RouteName, b.IsActive, RouteTypeID, Case When RouteTypeID=1 then 'Non Cluster' " +
            //       " When RouteTypeID=2 then 'Cluster' When RouteTypeID=3 then 'Institution' else 'Others' end as RTType   " +
            //       " from BLLSysDB.dbo.v_CustomerDetails a, BLLSysDB.dbo.t_DMSRoute b Where a.CustomerID=b.DistributorID  " +
            //       " Order by AreaSort, TerritorySort, CustomerID, RouteTypeID, RouteName";

                sSQL = " Select CustomerID, CustomerCode, CustomerName, CustomerShortName, AreaID, AreaShortName, TerritoryID, " +
                "TerritoryShortName, RouteID, RouteName, IsActive, RouteTypeID, RTType,DSRMobileNo, AreaSort, TerritorySort, IsNull(DSRName,'')DSRName from " +
                "( " +
                "Select CustomerID, CustomerCode, CustomerName, CustomerShortName, AreaID, AreaShortName, TerritoryID,  " +
                "TerritoryShortName, RouteID, RouteName, b.IsActive, RouteTypeID, Case When RouteTypeID=1 then 'Non Cluster'  " +
                "When RouteTypeID=2 then 'Cluster' When RouteTypeID=3 then 'Institution' else 'Others' end as RTType,  " +
                "DSRMobileNo, DSRID, AreaSort, TerritorySort    " +
                "from BLLSysDB.dbo.v_CustomerDetails a, BLLSysDB.dbo.t_DMSRoute b " +
                "Where a.CustomerID=b.DistributorID  " +
                ")a " +
                "Left OUter JOIN " +
                "(select DSRID, DSRName from BLLSysDB.dbo.t_DMSDSR)b ON a.DSRID=b.DSRID " +
                "Order by AreaSort, TerritorySort, CustomerID, RouteTypeID, RouteName ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.CustomerID = reader["CustomerID"].ToString();
                    oBLLPerformanceAnalysisRow.CustomerCode = reader["CustomerCode"].ToString();
                    oBLLPerformanceAnalysisRow.CustomerName = reader["CustomerName"].ToString();
                    if (reader["CustomerShortName"] != DBNull.Value)
                        oBLLPerformanceAnalysisRow.CustomerShortName = reader["CustomerShortName"].ToString();
                    else oBLLPerformanceAnalysisRow.CustomerShortName = "Null";
                    oBLLPerformanceAnalysisRow.AreaName = reader["AreaShortName"].ToString();
                    oBLLPerformanceAnalysisRow.TerritoryName = reader["TerritoryShortName"].ToString();
                    oBLLPerformanceAnalysisRow.RouteID = Convert.ToInt32(reader["RouteID"]);
                    oBLLPerformanceAnalysisRow.RouteName = reader["RouteName"].ToString();

                    oBLLPerformanceAnalysisRow.AreaID = reader["AreaID"].ToString();
                    oBLLPerformanceAnalysisRow.TerritoryID = reader["TerritoryID"].ToString();
                    oBLLPerformanceAnalysisRow.IsActive = reader["IsActive"].ToString();
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();
                    oBLLPerformanceAnalysisRow.RouteTypeName = reader["RTType"].ToString();
                    oBLLPerformanceAnalysisRow.DSRMobileNo = reader["DSRMobileNo"].ToString();
                    oBLLPerformanceAnalysisRow.DSRName = reader["DSRName"].ToString();

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
        public List<Data> getResult(int DayOfMonth, int TotalDayOfMonth, int DayOfYear, int TotalDayOfYear)
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            int nCount = 0;
            foreach (Data oData in this)
            {
                nCount = 1;
                double _Val = oData.CMSAMTDValue + oData.LMSAMTDValue + oData.LMSAValue + oData.LYCMSAValue;
                if (oData.IsActive == "0")
                {
                    if (_Val == 0)
                    {
                        nCount = 0;
                    }
                }
                if (nCount != 0)
                {
                    _oData = new Data();
                    _oData.ShortName = oData.ShortName;
                    _oData.FullName = oData.FullName;
                    _oData.CustomerCode = oData.CustomerCode;
                    _oData.AreaID = oData.AreaID;
                    _oData.TerritoryID = oData.TerritoryID;
                    _oData.sReouteID = oData.sReouteID;
                    _oData.Type = oData.Type;
                    _oData.Value = oData.Value;
                    if (oData.IsActive == "1")
                        _oData.ActiveStatus = "Y";
                    else _oData.ActiveStatus = "N";


                    _oData.CMSTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSTValue));
                    _oData.CMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSAMTDValue));
                    _oData.LMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMSAMTDValue));
                    _oData.LMSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMSAValue));
                    _oData.LYCMSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYCMSAValue));

                    //Performance

                    if (oData.CMSTValue > 0)
                    {
                        _oData.GSCMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue / oData.CMSTValue) * 100));
                    }
                    else
                    {
                        _oData.GSCMMTDPercText = "0";
                    }

                    if (oData.CMSTValue > 0)
                    {
                        _oData.GSLMMTDPercText = Convert.ToString(Math.Round((oData.LMSAMTDValue / oData.CMSTValue) * 100));
                    }
                    else
                    {
                        _oData.GSLMMTDPercText = "0";
                    }

                    if (oData.CMSTValue > 0)
                    {
                        _oData.GSLMFullPercText = Convert.ToString(Math.Round((oData.LMSAValue / oData.CMSTValue) * 100));
                    }
                    else
                    {
                        _oData.GSLMFullPercText = "0";
                    }
                    if (oData.CMSTValue > 0)
                    {
                        _oData.GSLYCMFullPercText = Convert.ToString(Math.Round((oData.LYCMSAValue / oData.CMSTValue) * 100));
                    }
                    else
                    {
                        _oData.GSLYCMFullPercText = "0";
                    }
                    eList.Add(_oData);

                }

            }
            return eList;

        }
    }
}



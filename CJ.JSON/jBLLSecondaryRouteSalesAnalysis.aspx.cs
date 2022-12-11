
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

public partial class jBLLSecondaryRouteSalesAnalysis : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            
            //string sUser = "hakim";
            string sDate = "";
            DateTime dDate = DateTime.Now.Date;
            if (c.Request.Form["Date"] != null)
            {
                sDate = c.Request.Form["Date"].Trim();
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
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataNational = new Data();
            Data _oDataArea = new Data();
            Data _oDataTerritory = new Data();
            Data _oDataCustomer = new Data();
            Data _oDataRouteType = new Data();
            Data _oDataRoute = new Data();

            int nCount = 0;

            DBController.Instance.OpenNewConnection();
            oDatas.GetData(dDate);
            DBController.Instance.CloseConnection();
            #region Loop
            foreach (Data oData in oDatas)
            {
                if (nCount == 0)
                {
                    _oDataNational = new Data();
                    _oDatas.Add(_oDataNational);
                    _oDataNational.ShortName = "National";
                    _oDataNational.CustomerCode = "National";
                    _oDataNational.FullName = " NSM: Ahsan Ullah | 01730097382";
                    _oDataNational.ResponsiblePerson = " NSM: Ahsan Ullah";
                    _oDataNational.MobileNo = "01730097382";
                    //_oDataNational.FullName = "National";
                    _oDataNational.AreaID = "0";
                    _oDataNational.TerritoryID = "0";
                    _oDataNational.CustomerID = "0";
                    _oDataNational.RouteTypeID = "0";
                    _oDataNational.sRouteID = "0";
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
                    _oDataArea.FullName = " ";
                    _oDataArea.ResponsiblePerson = " ";
                    _oDataArea.MobileNo = " ";
                    //_oDataArea.FullName = oData.AreaName;
                    _oDataArea.AreaID = oData.AreaID;
                    _oDataArea.TerritoryID = oData.TerritoryID;
                    _oDataArea.CustomerID = oData.CustomerID;
                    _oDataArea.RouteTypeID = oData.RouteTypeID;
                    _oDataArea.sRouteID = oData.sRouteID;
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
                    _oDataTerritory.FullName = " TSM: " + oData.TSMName + " | " + oData.TSMMobileNo;
                    _oDataTerritory.ResponsiblePerson = " TSM: " + oData.TSMName;
                    _oDataTerritory.MobileNo = oData.TSMMobileNo;
                    //_oDataTerritory.FullName = oData.TerritoryName;
                    _oDataTerritory.AreaID = oData.AreaID;
                    _oDataTerritory.TerritoryID = oData.TerritoryID;
                    _oDataTerritory.CustomerID = oData.CustomerID;
                    _oDataTerritory.RouteTypeID = oData.RouteTypeID;
                    _oDataTerritory.sRouteID = oData.sRouteID;
                    _oDataTerritory.Type = "Territory";
                    _oDataTerritory.Value = "Success";
                    _oDataTerritory.IsActive = "1";
                }
                if (_oDataCustomer.CustomerID != oData.CustomerID)
                {
                    _oDataCustomer = new Data();
                    _oDatas.Add(_oDataCustomer);
                    _oDataCustomer.CustomerID = oData.CustomerID;
                    _oDataCustomer.ShortName = oData.ShortName;
                    _oDataCustomer.CustomerCode = oData.CustomerCode;
                    _oDataCustomer.FullName = " TSO: " + oData.TSOName + " | " + oData.TSOMobileNo;
                    _oDataCustomer.ResponsiblePerson = " TSO: " + oData.TSOName;
                    _oDataCustomer.MobileNo = oData.TSOMobileNo;
                    //_oDataCustomer.FullName = oData.FullName;                   
                    _oDataCustomer.AreaID = oData.AreaID;
                    _oDataCustomer.TerritoryID = oData.TerritoryID;
                    _oDataCustomer.CustomerID = oData.CustomerID;
                    _oDataCustomer.RouteTypeID = oData.RouteTypeID;
                    _oDataCustomer.sRouteID = oData.sRouteID;
                    _oDataCustomer.Type = "Customer";
                    _oDataCustomer.Value = "Success";
                    _oDataCustomer.IsActive = oData.IsActiveDB;
                }
                if (_oDataRouteType.RouteTypeID != oData.RouteTypeID || _oDataRouteType.CustomerID != oData.CustomerID)
                {
                    _oDataRouteType = new Data();
                    _oDatas.Add(_oDataRouteType);
                    _oDataRouteType.RouteTypeID = oData.RouteTypeID;
                    _oDataRouteType.ShortName = oData.RouteTypeName;
                    _oDataRouteType.CustomerCode = "RouteType";
                    if (Convert.ToInt32(_oDataRouteType.RouteTypeID) == (int)Dictionary.RouteType.Non_Cluster)
                    {
                        _oDataRouteType.FullName = " DSR: " + oData.DSRName + " | " + oData.DSRMobileNo;
                        _oDataRouteType.ResponsiblePerson = " DSR: " + oData.DSRName;
                        _oDataRouteType.MobileNo = oData.DSRMobileNo;
                    }
                    else if (Convert.ToInt32(_oDataRouteType.RouteTypeID) == (int)Dictionary.RouteType.Cluster)
                    {
                        _oDataRouteType.FullName = " SA: " + oData.DSRName + " | " + oData.DSRMobileNo;
                        _oDataRouteType.ResponsiblePerson = " SA: " + oData.DSRName;
                        _oDataRouteType.MobileNo = oData.DSRMobileNo;
                    }
                    else
                    {
                        _oDataRouteType.FullName = " TSO: " + oData.TSOName + " | " + oData.TSOMobileNo;
                        _oDataRouteType.ResponsiblePerson = " TSO: " + oData.TSOName;
                        _oDataRouteType.MobileNo = oData.TSOMobileNo;
                    }

                    //_oDataRouteType.FullName = oData.RouteTypeName;
                    _oDataRouteType.AreaID = oData.AreaID;
                    _oDataRouteType.TerritoryID = oData.TerritoryID;
                    _oDataRouteType.CustomerID = oData.CustomerID;
                    _oDataRouteType.RouteTypeID = oData.RouteTypeID;
                    _oDataRouteType.sRouteID = oData.sRouteID;
                    _oDataRouteType.Type = "RouteType";
                    _oDataRouteType.Value = "Success";
                    _oDataRouteType.IsActive = "1";
                }

                _oDataRoute = new Data();
                _oDataRoute.Value = "Success";

                //_oDataCustomer.ShortName = oData.ShortName;
                _oDataRoute.ShortName = oData.Route;
                _oDataRoute.CustomerCode = oData.CustomerCode;
                //_oDataRoute.FullName = oData.Route;
                _oDataRoute.FullName = " DSR: " + oData.DSRName + " | " + oData.DSRMobileNo;
                _oDataRoute.ResponsiblePerson = " DSR: " + oData.DSRName;
                _oDataRoute.MobileNo = oData.DSRMobileNo;
                _oDataRoute.CMSTValue = oData.CMSTValue;
                _oDataRoute.CMSAMTDValue = oData.CMSAMTDValue;
                _oDataRoute.LMSAMTDValue = oData.LMSAMTDValue;
                _oDataRoute.LMSAValue = oData.LMSAValue;
                _oDataRoute.LYCMSAValue = oData.LYCMSAValue;
                _oDataRoute.LYCMSAMTDValue = oData.LYCMSAMTDValue;

                _oDataRoute.AreaID = oData.AreaID;
                _oDataRoute.TerritoryID = oData.TerritoryID;
                _oDataRoute.CustomerID = oData.CustomerID;
                _oDataRoute.RouteTypeID = oData.RouteTypeID;
                _oDataRoute.sRouteID = oData.sRouteID;
                _oDataRoute.IsActive = oData.IsActive;
                _oDataRoute.Type = "Route";
                _oDatas.Add(_oDataRoute);

                _oDataNational.CMSTValue = _oDataNational.CMSTValue + oData.CMSTValue;
                _oDataNational.CMSAMTDValue = _oDataNational.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataNational.LMSAMTDValue = _oDataNational.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataNational.LMSAValue = _oDataNational.LMSAValue + oData.LMSAValue;
                _oDataNational.LYCMSAValue = _oDataNational.LYCMSAValue + oData.LYCMSAValue;
                _oDataNational.LYCMSAMTDValue = _oDataNational.LYCMSAMTDValue + oData.LYCMSAMTDValue;

                _oDataArea.CMSTValue = _oDataArea.CMSTValue + oData.CMSTValue;
                _oDataArea.CMSAMTDValue = _oDataArea.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataArea.LMSAMTDValue = _oDataArea.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataArea.LMSAValue = _oDataArea.LMSAValue + oData.LMSAValue;
                _oDataArea.LYCMSAValue = _oDataArea.LYCMSAValue + oData.LYCMSAValue;
                _oDataArea.LYCMSAMTDValue = _oDataArea.LYCMSAMTDValue + oData.LYCMSAMTDValue;

                _oDataTerritory.CMSTValue = _oDataTerritory.CMSTValue + oData.CMSTValue;
                _oDataTerritory.CMSAMTDValue = _oDataTerritory.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataTerritory.LMSAMTDValue = _oDataTerritory.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataTerritory.LMSAValue = _oDataTerritory.LMSAValue + oData.LMSAValue;
                _oDataTerritory.LYCMSAValue = _oDataTerritory.LYCMSAValue + oData.LYCMSAValue;
                _oDataTerritory.LYCMSAMTDValue = _oDataTerritory.LYCMSAMTDValue + oData.LYCMSAMTDValue;

                _oDataCustomer.CMSTValue = _oDataCustomer.CMSTValue + oData.CMSTValue;
                _oDataCustomer.CMSAMTDValue = _oDataCustomer.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataCustomer.LMSAMTDValue = _oDataCustomer.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataCustomer.LMSAValue = _oDataCustomer.LMSAValue + oData.LMSAValue;
                _oDataCustomer.LYCMSAValue = _oDataCustomer.LYCMSAValue + oData.LYCMSAValue;
                _oDataCustomer.LYCMSAMTDValue = _oDataCustomer.LYCMSAMTDValue + oData.LYCMSAMTDValue;

                _oDataRouteType.CMSTValue = _oDataRouteType.CMSTValue + oData.CMSTValue;
                _oDataRouteType.CMSAMTDValue = _oDataRouteType.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataRouteType.LMSAMTDValue = _oDataRouteType.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataRouteType.LMSAValue = _oDataRouteType.LMSAValue + oData.LMSAValue;
                _oDataRouteType.LYCMSAValue = _oDataRouteType.LYCMSAValue + oData.LYCMSAValue;
                _oDataRouteType.LYCMSAMTDValue = _oDataRouteType.LYCMSAMTDValue + oData.LYCMSAMTDValue;

            }
            #endregion
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
        public string CustomerID;
        public string CustomerCode;
        public string Route;
        public int nRouteID;
        public string sRouteID;
        public string Type;
        public string Value;
        public string IsActive;
        public string IsActiveDB;
        public string ActiveStatus;
        public string RouteTypeID;
        public string RouteTypeName;
        public string DSRMobileNo;
        public string DSRName;
        public string TSMMobileNo;
        public string TSMName;
        public string TSOMobileNo;
        public string TSOName;
        public string ResponsiblePerson;
        public string MobileNo;


        public double CMSTValue;
        public double CMSAMTDValue;
        public double LMSAMTDValue;
        public double LMSAValue;
        public double LYCMSAValue;
        public double LYCMSAMTDValue;

        public string CMSTValueText;
        public string CMSAMTDValueText;
        public string LMSAMTDValueText;
        public string LMSAValueText;
        public string LYCMSAValueText;
        public string LYCMSAMTDValueText;

        public string GSCMMTDPercText;
        public string GSLMMTDPercText;
        public string GSLMFullPercText;
        public string GSLYCMFullPercText;
        public string GSLYCMMTDPercText;

        public string DayPassing;


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
        public void GetData(DateTime dDate)
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
            oDSLYCMSAMTD = GetRawData("SecondaryActual", _FristDayofLastYearThisMonth, _ToDateofLastYearThisMonth);

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
                _oData.CustomerID = oBLLPerformanceAnalysisRow.CustomerID;
                _oData.CustomerCode = oBLLPerformanceAnalysisRow.CustomerCode;
                _oData.AreaID = oBLLPerformanceAnalysisRow.AreaID;
                _oData.TerritoryID = oBLLPerformanceAnalysisRow.TerritoryID;
                _oData.nRouteID = oBLLPerformanceAnalysisRow.RouteID;
                _oData.sRouteID = oBLLPerformanceAnalysisRow.RouteID.ToString();
                _oData.Route = oBLLPerformanceAnalysisRow.RouteName;
                _oData.RouteTypeID = oBLLPerformanceAnalysisRow.RouteTypeID;
                _oData.RouteTypeName = oBLLPerformanceAnalysisRow.RouteTypeName;
                _oData.IsActive = oBLLPerformanceAnalysisRow.IsActive;
                _oData.IsActiveDB = oBLLPerformanceAnalysisRow.IsActiveDB;
                _oData.DSRMobileNo = oBLLPerformanceAnalysisRow.DSRMobileNo;
                _oData.DSRName = oBLLPerformanceAnalysisRow.DSRName;
                _oData.TSMMobileNo = oBLLPerformanceAnalysisRow.TSMMobileNo;
                _oData.TSMName = oBLLPerformanceAnalysisRow.TSMName;
                _oData.TSOMobileNo = oBLLPerformanceAnalysisRow.TSOMobileNo;
                _oData.TSOName = oBLLPerformanceAnalysisRow.TSOName;


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

                // Last Year This Month MTD Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYCMSAMTD = oDSLYCMSAMTD.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLYCMSAMTDFiltered.Merge(oDRLYCMSAMTD);
                oDSLYCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSAMTDRow in oDSLYCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYCMSAMTDValue = Convert.ToDouble(oDSLYCMSAMTDRow.Amount);
                }


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
                {
                    sSQL = " select RouteID, SUM(TSMTGTTO)Amount from BLLSysDB.dbo.t_DMSTargetTO Where TGTDate Between '" + dFromDate + "' " +
                            " and '" + dTodate + "' and TGTDate < '" + dTodate + "' Group by RouteID";
                }


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
            //       " TerritoryShortName, RouteID, RouteName, a.IsActive as IsActiveDB, b.IsActive as IsActiveRT, RouteTypeID, Case When RouteTypeID=1 then 'Non Cluster' " +
            //       " When RouteTypeID=2 then 'Cluster' When RouteTypeID=3 then 'Institution' else 'Others' end as RTType   " +
            //       " from BLLSysDB.dbo.v_CustomerDetails a, BLLSysDB.dbo.t_DMSRoute b Where a.CustomerID=b.DistributorID  " +
            //       " Order by AreaSort, TerritorySort, CustomerID, RouteTypeID, RouteName";

            sSQL = " Select CustomerID, CustomerCode, CustomerName, CustomerShortName, AreaID, AreaShortName, a.TerritoryID, " +
               "TerritoryShortName, RouteID, RouteName, IsActiveDB, IsActiveRT, RouteTypeID, RTType,DSRMobileNo, AreaSort, TerritorySort, "+
               "IsNull(DSRName,'')as DSRName, IsNull(TSMName,'') as TSMName, IsNull(TSMContactNo,'') as TSMContactNo, "+
               "IsNull(TSOName,'') as TSOName, IsNull(TSOContactNo,'') as TSOContactNo from " +
               "( " +
               "Select CustomerID, CustomerCode, CustomerName, CustomerShortName, AreaID, AreaShortName, TerritoryID,  " +
               "TerritoryShortName, RouteID, RouteName, a.IsActive as IsActiveDB, b.IsActive as IsActiveRT, RouteTypeID, Case When RouteTypeID=1 then 'Non Cluster'  " +
               "When RouteTypeID=2 then 'Cluster' When RouteTypeID=3 then 'Institution' else 'Others' end as RTType,  " +
               "DSRMobileNo, DSRID, AreaSort, TerritorySort    " +
               "from BLLSysDB.dbo.v_CustomerDetails a, BLLSysDB.dbo.t_DMSRoute b " +
               "Where a.CustomerID=b.DistributorID  " +
               ")a " +
               "Left OUter JOIN " +
               "(select DSRID, DSRName from BLLSysDB.dbo.t_DMSDSR)b ON a.DSRID=b.DSRID " +
               "Left OUter JOIN " +
               "(Select MarketGroupID as TerritoryID, EmployeeName as TSMName, MobileNo as TSMContactNo from BLLSysDB.dbo.t_MarketGroup a,  " +
               "t_Employee b Where a.EmployeeID=b.EmployeeID and MarketGroupType=2)c " +
               "ON a.TerritoryID=c.TerritoryID " +
               "Left Outer JOIN "+
               "(select DistributorID, EmployeeName as TSOName, b.MobileNo as TSOContactNo from BLLSysDB.dbo.t_DMSUser a, "+
               "t_Employee b Where a.EmployeeID=b.EmployeeID)d "+
               "ON a.CustomerID=d.DistributorID " +
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
                    oBLLPerformanceAnalysisRow.IsActiveDB = reader["IsActiveDB"].ToString();
                    oBLLPerformanceAnalysisRow.IsActive = reader["IsActiveRT"].ToString();
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();
                    oBLLPerformanceAnalysisRow.RouteTypeName = reader["RTType"].ToString();
                    oBLLPerformanceAnalysisRow.DSRMobileNo = reader["DSRMobileNo"].ToString();
                    oBLLPerformanceAnalysisRow.DSRName = reader["DSRName"].ToString();
                    oBLLPerformanceAnalysisRow.TSMMobileNo = reader["TSMContactNo"].ToString();
                    oBLLPerformanceAnalysisRow.TSMName = reader["TSMName"].ToString();
                    oBLLPerformanceAnalysisRow.TSOMobileNo = reader["TSOContactNo"].ToString();
                    oBLLPerformanceAnalysisRow.TSOName = reader["TSOName"].ToString();

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

            //int nDay = DateTime.Today.Day;
            //DateTime _dLastDateOfThisMonth = _oTELLib.LastDayofMonth(DateTime.Today);
            //int nTotalDay = _dLastDateOfThisMonth.Day;

            int nCount = 0;
            foreach (Data oData in this)
            {
                nCount = 1;
                double _Val = oData.CMSAMTDValue + oData.LMSAMTDValue + oData.LMSAValue + oData.LYCMSAValue + oData.LYCMSAMTDValue;
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
                    _oData.ResponsiblePerson = oData.ResponsiblePerson;
                    _oData.MobileNo = oData.MobileNo;
                    _oData.CustomerCode = oData.CustomerCode;
                    _oData.AreaID = oData.AreaID;
                    _oData.TerritoryID = oData.TerritoryID;
                    _oData.CustomerID = oData.CustomerID;
                    _oData.RouteTypeID = oData.RouteTypeID;
                    _oData.sRouteID = oData.sRouteID;
                    _oData.Type = oData.Type;
                    _oData.Value = oData.Value;
                    if (oData.IsActive == "1")
                        _oData.ActiveStatus = "Y";
                    else _oData.ActiveStatus = "N";

                    double DayPassing = Math.Round(Convert.ToDouble(DayOfMonth) / TotalDayOfMonth * 100);
                    _oData.DayPassing = DayPassing.ToString();
                    _oData.CMSTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSTValue));
                    _oData.CMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSAMTDValue));
                    _oData.LMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMSAMTDValue));
                    _oData.LMSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMSAValue));
                    _oData.LYCMSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYCMSAValue));
                    _oData.LYCMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYCMSAMTDValue));

                    //Performance

                    if (oData.CMSTValue > 0)
                    {
                        _oData.GSCMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue / oData.CMSTValue) * 100));
                    }
                    else
                    {
                        _oData.GSCMMTDPercText = "0";
                    }

                    if (oData.LMSAMTDValue > 0)
                    {
                        _oData.GSLMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue - oData.LMSAMTDValue) / oData.LMSAMTDValue * 100));
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
                    if (oData.LYCMSAMTDValue > 0)
                    {
                        _oData.GSLYCMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue - oData.LYCMSAMTDValue) / oData.LYCMSAMTDValue * 100));
                    }
                    else
                    {
                        _oData.GSLYCMMTDPercText = "0";
                    }
                    eList.Add(_oData);

                }

            }
            return eList;

        }
    }
}



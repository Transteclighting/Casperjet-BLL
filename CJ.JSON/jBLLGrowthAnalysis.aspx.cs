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

public partial class jBLLGrowthAnalysis : System.Web.UI.Page
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
                    _oDataNational.Type = "National";
                    _oDataNational.Value = "Success";
                    _oDataNational.CustomerID = "0";
                    _oDataNational.AreaID = "0";
                    _oDataNational.TerritoryID = "0";
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
                    _oDataArea.Type = "Area";
                    _oDataArea.Value = "Success";
                    _oDataArea.CustomerID = oData.CustomerID;
                    _oDataArea.AreaID = oData.AreaID;
                    _oDataArea.TerritoryID = oData.TerritoryID;
                }
                if (_oDataTerritory.TerritoryName != oData.TerritoryName)
                {
                    _oDataTerritory = new Data();
                    _oDatas.Add(_oDataTerritory);
                    _oDataTerritory.TerritoryName = oData.TerritoryName;
                    _oDataTerritory.ShortName = oData.TerritoryName;
                    _oDataTerritory.CustomerCode = "Territory";
                    _oDataTerritory.FullName = oData.TerritoryName;
                    _oDataTerritory.Type = "Territory";
                    _oDataTerritory.Value = "Success";
                    _oDataTerritory.CustomerID = oData.CustomerID;
                    _oDataTerritory.AreaID = oData.AreaID;
                    _oDataTerritory.TerritoryID = oData.TerritoryID;
                }

                _oDataCustomer = new Data();
                _oDataCustomer.Value = "Success";

                _oDataCustomer.ShortName = oData.ShortName;
                _oDataCustomer.CustomerCode = oData.CustomerCode;
                _oDataCustomer.FullName = oData.FullName;

                _oDataCustomer.CustomerID = oData.CustomerID;
                _oDataCustomer.AreaID = oData.AreaID;
                _oDataCustomer.TerritoryID = oData.TerritoryID;

                _oDataCustomer.CMPTValue = oData.CMPTValue;
                _oDataCustomer.CMPAValue = oData.CMPAValue;
                _oDataCustomer.CMSTValue = oData.CMSTValue;
                _oDataCustomer.CMSAValue = oData.CMSAValue;
                _oDataCustomer.LMPTValue = oData.LMPTValue;
                _oDataCustomer.LMPAValue = oData.LMPAValue;
                _oDataCustomer.LMSTValue = oData.LMSTValue;
                _oDataCustomer.LMSAValue = oData.LMSAValue;
                _oDataCustomer.CYPTValue = oData.CYPTValue;
                _oDataCustomer.CYPAValue = oData.CYPAValue;
                _oDataCustomer.CYSTValue = oData.CYSTValue;
                _oDataCustomer.CYSAValue = oData.CYSAValue;
                _oDataCustomer.LYPAValue = oData.LYPAValue;
                _oDataCustomer.LYSAValue = oData.LYSAValue;
                _oDataCustomer.Receivables = oData.Receivables;
                _oDataCustomer.StockValue = oData.StockValue;
                _oDataCustomer.BG = oData.BG;
                _oDataCustomer.Collection = oData.Collection;
                _oDataCustomer.CollectionLM = oData.CollectionLM;

                _oDataCustomer.LMPAMTDValue = oData.LMPAMTDValue;
                _oDataCustomer.LMSAMTDValue = oData.LMSAMTDValue;

                _oDataCustomer.LYCMPAMTDValue = _oData.LYCMPAMTDValue;
                _oDataCustomer.LYCMPAValue = _oData.LYCMPAValue;
                _oDataCustomer.LYCMSAMTDValue = _oData.LYCMSAMTDValue;
                _oDataCustomer.LYCMSAValue = _oData.LYCMSAValue;


                _oDataCustomer.Type = "Customer";
                _oDatas.Add(_oDataCustomer);

                _oDataNational.CMPTValue = _oDataNational.CMPTValue + oData.CMPTValue;
                _oDataNational.CMPAValue = _oDataNational.CMPAValue + oData.CMPAValue;
                _oDataNational.CMSTValue = _oDataNational.CMSTValue + oData.CMSTValue;
                _oDataNational.CMSAValue = _oDataNational.CMSAValue + oData.CMSAValue;
                _oDataNational.LMPTValue = _oDataNational.LMPTValue + oData.LMPTValue;
                _oDataNational.LMPAValue = _oDataNational.LMPAValue + oData.LMPAValue;
                _oDataNational.LMSTValue = _oDataNational.LMSTValue + oData.LMSTValue;
                _oDataNational.LMSAValue = _oDataNational.LMSAValue + oData.LMSAValue;
                _oDataNational.CYPTValue = _oDataNational.CYPTValue + oData.CYPTValue;
                _oDataNational.CYPAValue = _oDataNational.CYPAValue + oData.CYPAValue;
                _oDataNational.CYSTValue = _oDataNational.CYSTValue + oData.CYSTValue;
                _oDataNational.CYSAValue = _oDataNational.CYSAValue + oData.CYSAValue;
                _oDataNational.LYPAValue = _oDataNational.LYPAValue + oData.LYPAValue;
                _oDataNational.LYSAValue = _oDataNational.LYSAValue + oData.LYSAValue;
                _oDataNational.Receivables = _oDataNational.Receivables + oData.Receivables;
                _oDataNational.StockValue = _oDataNational.StockValue + oData.StockValue;
                _oDataNational.BG = _oDataNational.BG + oData.BG;
                _oDataNational.Collection = _oDataNational.Collection + oData.Collection;
                _oDataNational.CollectionLM = _oDataNational.CollectionLM + oData.CollectionLM;

                _oDataNational.LMPAMTDValue = _oDataNational.LMPAMTDValue + oData.LMPAMTDValue;
                _oDataNational.LMSAMTDValue = _oDataNational.LMSAMTDValue + oData.LMSAMTDValue;
                
                _oDataNational.LYCMPAMTDValue = _oDataNational.LYCMPAMTDValue + _oData.LYCMPAMTDValue;
                _oDataNational.LYCMPAValue = _oDataNational.LYCMPAValue + _oData.LYCMPAValue;
                _oDataNational.LYCMSAMTDValue = _oDataNational.LYCMSAMTDValue + _oData.LYCMSAMTDValue;
                _oDataNational.LYCMSAValue = _oDataNational.LYCMSAValue + _oData.LYCMSAValue;

                _oDataArea.CMPTValue = _oDataArea.CMPTValue + oData.CMPTValue;
                _oDataArea.CMPAValue = _oDataArea.CMPAValue + oData.CMPAValue;
                _oDataArea.CMSTValue = _oDataArea.CMSTValue + oData.CMSTValue;
                _oDataArea.CMSAValue = _oDataArea.CMSAValue + oData.CMSAValue;
                _oDataArea.LMPTValue = _oDataArea.LMPTValue + oData.LMPTValue;
                _oDataArea.LMPAValue = _oDataArea.LMPAValue + oData.LMPAValue;
                _oDataArea.LMSTValue = _oDataArea.LMSTValue + oData.LMSTValue;
                _oDataArea.LMSAValue = _oDataArea.LMSAValue + oData.LMSAValue;
                _oDataArea.CYPTValue = _oDataArea.CYPTValue + oData.CYPTValue;
                _oDataArea.CYPAValue = _oDataArea.CYPAValue + oData.CYPAValue;
                _oDataArea.CYSTValue = _oDataArea.CYSTValue + oData.CYSTValue;
                _oDataArea.CYSAValue = _oDataArea.CYSAValue + oData.CYSAValue;
                _oDataArea.LYPAValue = _oDataArea.LYPAValue + oData.LYPAValue;
                _oDataArea.LYSAValue = _oDataArea.LYSAValue + oData.LYSAValue;
                _oDataArea.Receivables = _oDataArea.Receivables + oData.Receivables;
                _oDataArea.StockValue = _oDataArea.StockValue + oData.StockValue;
                _oDataArea.BG = _oDataArea.BG + oData.BG;
                _oDataArea.Collection = _oDataArea.Collection + oData.Collection;
                _oDataArea.CollectionLM = _oDataArea.CollectionLM + oData.CollectionLM;

                _oDataArea.LMPAMTDValue = _oDataArea.LMPAMTDValue + oData.LMPAMTDValue;
                _oDataArea.LMSAMTDValue = _oDataArea.LMSAMTDValue + oData.LMSAMTDValue;

                _oDataArea.LYCMPAMTDValue = _oDataArea.LYCMPAMTDValue + _oData.LYCMPAMTDValue;
                _oDataArea.LYCMPAValue = _oDataArea.LYCMPAValue + _oData.LYCMPAValue;
                _oDataArea.LYCMSAMTDValue = _oDataArea.LYCMSAMTDValue + _oData.LYCMSAMTDValue;
                _oDataArea.LYCMSAValue = _oDataArea.LYCMSAValue + _oData.LYCMSAValue;



                _oDataTerritory.CMPTValue = _oDataTerritory.CMPTValue + oData.CMPTValue;
                _oDataTerritory.CMPAValue = _oDataTerritory.CMPAValue + oData.CMPAValue;
                _oDataTerritory.CMSTValue = _oDataTerritory.CMSTValue + oData.CMSTValue;
                _oDataTerritory.CMSAValue = _oDataTerritory.CMSAValue + oData.CMSAValue;
                _oDataTerritory.LMPTValue = _oDataTerritory.LMPTValue + oData.LMPTValue;
                _oDataTerritory.LMPAValue = _oDataTerritory.LMPAValue + oData.LMPAValue;
                _oDataTerritory.LMSTValue = _oDataTerritory.LMSTValue + oData.LMSTValue;
                _oDataTerritory.LMSAValue = _oDataTerritory.LMSAValue + oData.LMSAValue;
                _oDataTerritory.CYPTValue = _oDataTerritory.CYPTValue + oData.CYPTValue;
                _oDataTerritory.CYPAValue = _oDataTerritory.CYPAValue + oData.CYPAValue;
                _oDataTerritory.CYSTValue = _oDataTerritory.CYSTValue + oData.CYSTValue;
                _oDataTerritory.CYSAValue = _oDataTerritory.CYSAValue + oData.CYSAValue;
                _oDataTerritory.LYPAValue = _oDataTerritory.LYPAValue + oData.LYPAValue;
                _oDataTerritory.LYSAValue = _oDataTerritory.LYSAValue + oData.LYSAValue;
                _oDataTerritory.Receivables = _oDataTerritory.Receivables + oData.Receivables;
                _oDataTerritory.StockValue = _oDataTerritory.StockValue + oData.StockValue;
                _oDataTerritory.BG = _oDataTerritory.BG + oData.BG;
                _oDataTerritory.Collection = _oDataTerritory.Collection + oData.Collection;
                _oDataTerritory.CollectionLM = _oDataTerritory.CollectionLM + oData.CollectionLM;

                _oDataTerritory.LMPAMTDValue = _oDataTerritory.LMPAMTDValue + oData.LMPAMTDValue;
                _oDataTerritory.LMSAMTDValue = _oDataTerritory.LMSAMTDValue + oData.LMSAMTDValue;

                _oDataTerritory.LYCMPAMTDValue = _oDataTerritory.LYCMPAMTDValue + _oData.LYCMPAMTDValue;
                _oDataTerritory.LYCMPAValue = _oDataTerritory.LYCMPAValue + _oData.LYCMPAValue;
                _oDataTerritory.LYCMSAMTDValue = _oDataTerritory.LYCMSAMTDValue + _oData.LYCMSAMTDValue;
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
        public string CustomerID;
        public string ShortName;
        public string FullName;
        public string CustomerCode;
        public string Type;


        public double LMPAMTDValue;
        public double LMSAMTDValue;
        public double LYCMPAMTDValue;
        public double LYCMPAValue;
        public double LYCMSAMTDValue;
        public double LYCMSAValue;

        public string LMPAMTDValueText;
        public string LMSAMTDValueText;
        public string LYCMPAMTDValueText;
        public string LYCMPAValueText;
        public string LYCMSAMTDValueText;
        public string LYCMSAValueText;


        public double CMPTValue;
        public double CMPAValue;
        public double CMSTValue;
        public double CMSAValue;
        public double LMPTValue;
        public double LMPAValue;
        public double LMSTValue;
        public double LMSAValue;
        public double CYPTValue;
        public double CYPAValue;
        public double CYSTValue;
        public double CYSAValue;
        public double LYPAValue;
        public double LYSAValue;
        public double StockValue;
        public double Collection;
        public double CollectionLM;
        public double Receivables;
        public double BG;

        public string CMPTValueText;
        public string CMPAValueText;
        public string CMSTValueText;
        public string CMSAValueText;
        public string LMPTValueText;
        public string LMPAValueText;
        public string LMSTValueText;
        public string LMSAValueText;
        public string CYPTValueText;
        public string CYPAValueText;
        public string CYSTValueText;
        public string CYSAValueText;
        public string LYPAValueText;
        public string LYSAValueText;

        public string StockValueText;
        public string CollectionText;
        public string CollectionLMText;
        public string ReceivablesText;
        public string BGText;

        public string CMPTMTDValueText;
        public string CMSTMTDValueText;
        public string CYPTMTDValueText;
        public string CYSTMTDValueText;

        //Percent
        public string CMPMTDPercText;
        public string CMPPercText;
        public string CMSMTDPercText;
        public string CMSPercText;
        public string LMPPercText;
        public string LMSPercText;
        public string CYPMTDPercText;
        public string CYPPercText;
        public string CYSMTDPercText;
        public string CYSPercText;

        //Growth
        public string GPLMMTDPercText;
        public string GPLMFullPercText;
        public string GPLYCMMTDPercText;
        public string GPLYCMFullPercText;

        public string GSLMMTDPercText;
        public string GSLMFullPercText;
        public string GSLYCMMTDPercText;
        public string GSLYCMFullPercText;


        public string Value; 

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10034";
            string sReportName = "BLL Growth Analysis";
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

            DSBLLGrowthAnalysis oDSCustomer = new DSBLLGrowthAnalysis();

            DSBLLGrowthAnalysis oDSCMPA = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSCMSA = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSLMPA = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSLMSA = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSLMPAMTD = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSLMSAMTD = new DSBLLGrowthAnalysis();

            DSBLLGrowthAnalysis oDSLYCMPAMTD = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSLYCMPA = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSLYCMSAMTD = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSLYCMSA = new DSBLLGrowthAnalysis();


            DSBLLGrowthAnalysis oDSCYPA = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSCYSA = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSLYPA = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSLYSA = new DSBLLGrowthAnalysis();

            DSBLLGrowthAnalysis oDSCMTarget = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSLMTarget = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSCYTarget = new DSBLLGrowthAnalysis();

            DSBLLGrowthAnalysis oDSStockValue = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSBG = new DSBLLGrowthAnalysis();

            DSBLLGrowthAnalysis oDSCollMTD = new DSBLLGrowthAnalysis();
            DSBLLGrowthAnalysis oDSCollLM = new DSBLLGrowthAnalysis();

            oDSCustomer = GetCustomerList();

            oDSCMPA = GetRawData("PrimaryActual", _FirstDayofMonth, dToDate);
            oDSCMSA = GetRawData("SecondaryActual", _FirstDayofMonth, dToDate);
            oDSLMPA = GetRawData("PrimaryActual", _FirstDayofLastMonth, _FirstDayofMonth);
            oDSLMPAMTD = GetRawData("PrimaryActual", _FirstDayofLastMonth, _ToDateOfLastMonth);
            oDSLMSA = GetRawData("SecondaryActual", _FirstDayofLastMonth, _FirstDayofMonth);
            oDSLMSAMTD = GetRawData("SecondaryActual", _FirstDayofLastMonth, _ToDateOfLastMonth);

            oDSLYCMPAMTD = GetRawData("PrimaryActual", _FristDayofLastYearThisMonth, _ToDateofLastYearThisMonth);
            oDSLYCMPA = GetRawData("PrimaryActual", _FristDayofLastYearThisMonth, _FristDayofLastYearNextMonth);
            oDSLYCMSAMTD = GetRawData("SecondaryActual", _FristDayofLastYearThisMonth, _ToDateofLastYearThisMonth);
            oDSLYCMSA = GetRawData("SecondaryActual", _FristDayofLastYearThisMonth, _FristDayofLastYearNextMonth);

            oDSCYPA = GetRawData("PrimaryActual", _FirstDayofThisYear, dToDate);
            oDSCYSA = GetRawData("SecondaryActual", _FirstDayofThisYear, dToDate);
            oDSLYPA = GetRawData("PrimaryActual", _FirstDayofLastYear, _FirstDayofThisYear);
            oDSLYSA = GetRawData("SecondaryActual", _FirstDayofLastYear, _FirstDayofThisYear);

            oDSCMTarget = GetRawDataTarget(_FirstDayofMonth, _FirstDayofNextMonth);
            oDSLMTarget = GetRawDataTarget(_FirstDayofLastMonth, _FirstDayofMonth);
            oDSCYTarget = GetRawDataTarget(_FirstDayofThisYear, _FirstDayofNextYear);

            oDSStockValue = GetRawData("StockValue", dFromDate, dToDate);
            oDSBG = GetRawData("BG", dFromDate, dToDate);

            oDSCollMTD = GetRawData("Collection", _FirstDayofMonth, dToDate);
            oDSCollLM = GetRawData("Collection", _FirstDayofLastMonth, _FirstDayofMonth);

            Data _oData;
            InnerList.Clear();

            foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oBLLGrowthAnalysisRow in oDSCustomer.BLLGrowthAnalysis)
            {

                _oData = new Data();

                _oData.AreaName = oBLLGrowthAnalysisRow.AreaName;
                _oData.TerritoryName = oBLLGrowthAnalysisRow.TerritoryName;
                _oData.FullName = oBLLGrowthAnalysisRow.CustomerName;
                _oData.ShortName = oBLLGrowthAnalysisRow.CustomerShortName;
                _oData.CustomerCode = oBLLGrowthAnalysisRow.CustomerCode;
                _oData.Receivables = oBLLGrowthAnalysisRow.CurrentBalance;

                _oData.CustomerID = oBLLGrowthAnalysisRow.CustomerID.ToString();
                _oData.AreaID = oBLLGrowthAnalysisRow.AreaID;
                _oData.TerritoryID = oBLLGrowthAnalysisRow.TerritoryID;
                
                //-----------

                //Collection MTD
                DSBLLGrowthAnalysis oDSCollMTDFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRCollMTD = oDSCollMTD.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSCollMTDFiltered.Merge(oDRCollMTD);
                oDSCollMTDFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSCollMTDRow in oDSCollMTDFiltered.BLLGrowthAnalysis)
                {
                    _oData.Collection = Convert.ToDouble(oDSCollMTDRow.Amount);
                }
                //Collection LM
                DSBLLGrowthAnalysis oDSCollLMFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRCollLM = oDSCollLM.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSCollLMFiltered.Merge(oDRCollLM);
                oDSCollLMFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSCollLMRow in oDSCollLMFiltered.BLLGrowthAnalysis)
                {
                    _oData.CollectionLM = Convert.ToDouble(oDSCollLMRow.Amount);
                }

                //StockValue
                DSBLLGrowthAnalysis oDSStockValueFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRStockValue = oDSStockValue.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSStockValueFiltered.Merge(oDRStockValue);
                oDSStockValueFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSStockValueRow in oDSStockValueFiltered.BLLGrowthAnalysis)
                {
                    _oData.StockValue = Convert.ToDouble(oDSStockValueRow.Amount);
                }

                //BG
                DSBLLGrowthAnalysis oDSBGFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRBG = oDSBG.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSBGFiltered.Merge(oDRBG);
                oDSBGFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSBGRow in oDSBGFiltered.BLLGrowthAnalysis)
                {
                    _oData.BG = Convert.ToDouble(oDSBGRow.Amount);
                }


                //LYCMPAMTD
                DSBLLGrowthAnalysis oDSLYCMPAMTDFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRLYCMPAMTD = oDSLYCMPAMTD.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSLYCMPAMTDFiltered.Merge(oDRLYCMPAMTD);
                oDSLYCMPAMTDFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSLYCMPAMTDRow in oDSLYCMPAMTDFiltered.BLLGrowthAnalysis)
                {
                    _oData.LYCMPAMTDValue = Convert.ToDouble(oDSLYCMPAMTDRow.Amount);
                }

                //LYCMPA
                DSBLLGrowthAnalysis oDSLYCMPAFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRLYCMPA = oDSLYCMPA.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSLYCMPAFiltered.Merge(oDRLYCMPA);
                oDSLYCMPAFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSLYCMPARow in oDSLYCMPAFiltered.BLLGrowthAnalysis)
                {
                    _oData.LYCMPAValue = Convert.ToDouble(oDSLYCMPARow.Amount);
                }

                //LYCMSAMTD
                DSBLLGrowthAnalysis oDSLYCMSAMTDFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRLYCMSAMTD = oDSLYCMSAMTD.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSLYCMSAMTDFiltered.Merge(oDRLYCMSAMTD);
                oDSLYCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSLYCMSAMTDRow in oDSLYCMSAMTDFiltered.BLLGrowthAnalysis)
                {
                    _oData.LYCMSAMTDValue = Convert.ToDouble(oDSLYCMSAMTDRow.Amount);
                }

                //LYCMSA
                DSBLLGrowthAnalysis oDSLYCMSAFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRLYCMSA = oDSLYCMSA.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSLYCMSAFiltered.Merge(oDRLYCMSA);
                oDSLYCMSAFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSLYCMSARow in oDSLYCMSAFiltered.BLLGrowthAnalysis)
                {
                    _oData.LYCMSAValue = Convert.ToDouble(oDSLYCMSARow.Amount);
                }

                //------------








                //CMPA
                DSBLLGrowthAnalysis oDSCMPAFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRCMPA = oDSCMPA.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSCMPAFiltered.Merge(oDRCMPA);
                oDSCMPAFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSCMPARow in oDSCMPAFiltered.BLLGrowthAnalysis)
                {
                    _oData.CMPAValue = Convert.ToDouble(oDSCMPARow.Amount);
                }

                //CMSA
                DSBLLGrowthAnalysis oDSCMSAFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRCMSA = oDSCMSA.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSCMSAFiltered.Merge(oDRCMSA);
                oDSCMSAFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSCMSARow in oDSCMSAFiltered.BLLGrowthAnalysis)
                {
                    _oData.CMSAValue = Convert.ToDouble(oDSCMSARow.Amount);
                }

                //LMPA
                DSBLLGrowthAnalysis oDSLMPAFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRLMPA = oDSLMPA.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSLMPAFiltered.Merge(oDRLMPA);
                oDSLMPAFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSLMPARow in oDSLMPAFiltered.BLLGrowthAnalysis)
                {
                    _oData.LMPAValue = Convert.ToDouble(oDSLMPARow.Amount);
                }

                //LMPAMTD
                DSBLLGrowthAnalysis oDSLMPAMTDFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRLMPAMTD = oDSLMPAMTD.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSLMPAMTDFiltered.Merge(oDRLMPAMTD);
                oDSLMPAMTDFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSLMPAMTDRow in oDSLMPAMTDFiltered.BLLGrowthAnalysis)
                {
                    _oData.LMPAMTDValue = Convert.ToDouble(oDSLMPAMTDRow.Amount);
                }

                //LMSA
                DSBLLGrowthAnalysis oDSLMSAFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRLMSA = oDSLMSA.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSLMSAFiltered.Merge(oDRLMSA);
                oDSLMSAFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSLMSARow in oDSLMSAFiltered.BLLGrowthAnalysis)
                {
                    _oData.LMSAValue = Convert.ToDouble(oDSLMSARow.Amount);
                }

                //LMSAMTD
                DSBLLGrowthAnalysis oDSLMSAMTDFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRLMSAMTD = oDSLMSAMTD.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSLMSAMTDFiltered.Merge(oDRLMSAMTD);
                oDSLMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSLMSAMTDRow in oDSLMSAMTDFiltered.BLLGrowthAnalysis)
                {
                    _oData.LMSAMTDValue = Convert.ToDouble(oDSLMSAMTDRow.Amount);
                }

                //CYPA
                DSBLLGrowthAnalysis oDSCYPAFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRCYPA = oDSCYPA.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSCYPAFiltered.Merge(oDRCYPA);
                oDSCYPAFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSCYPARow in oDSCYPAFiltered.BLLGrowthAnalysis)
                {
                    _oData.CYPAValue = Convert.ToDouble(oDSCYPARow.Amount);
                }

                //CYSA
                DSBLLGrowthAnalysis oDSCYSAFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRCYSA = oDSCYSA.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSCYSAFiltered.Merge(oDRCYSA);
                oDSCYSAFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSCYSARow in oDSCYSAFiltered.BLLGrowthAnalysis)
                {
                    _oData.CYSAValue = Convert.ToDouble(oDSCYSARow.Amount);
                }

                //LYPA
                DSBLLGrowthAnalysis oDSLYPAFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRLYPA = oDSLYPA.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSLYPAFiltered.Merge(oDRLYPA);
                oDSLYPAFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSLYPARow in oDSLYPAFiltered.BLLGrowthAnalysis)
                {
                    _oData.LYPAValue = Convert.ToDouble(oDSLYPARow.Amount);
                }

                //LYSA
                DSBLLGrowthAnalysis oDSLYSAFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRLYSA = oDSLYSA.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSLYSAFiltered.Merge(oDRLYSA);
                oDSLYSAFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSLYSARow in oDSLYSAFiltered.BLLGrowthAnalysis)
                {
                    _oData.LYSAValue = Convert.ToDouble(oDSLYSARow.Amount);
                }

                //CMTarget
                DSBLLGrowthAnalysis oDSCMTargetFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRCMTarget = oDSCMTarget.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSCMTargetFiltered.Merge(oDRCMTarget);
                oDSCMTargetFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSCMTargetRow in oDSCMTargetFiltered.BLLGrowthAnalysis)
                {
                    _oData.CMPTValue = Convert.ToDouble(oDSCMTargetRow.PrimaryTarget);
                    _oData.CMSTValue = Convert.ToDouble(oDSCMTargetRow.SecondaryTarget);
                }

                //LMTarget
                DSBLLGrowthAnalysis oDSLMTargetFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRLMTarget = oDSLMTarget.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSLMTargetFiltered.Merge(oDRLMTarget);
                oDSLMTargetFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSLMTargetRow in oDSLMTargetFiltered.BLLGrowthAnalysis)
                {
                    _oData.LMPTValue = Convert.ToDouble(oDSLMTargetRow.PrimaryTarget);
                    _oData.LMSTValue = Convert.ToDouble(oDSLMTargetRow.SecondaryTarget);
                }

                //CYTarget
                DSBLLGrowthAnalysis oDSCYTargetFiltered = new DSBLLGrowthAnalysis();
                DataRow[] oDRCYTarget = oDSCYTarget.BLLGrowthAnalysis.Select(" CustomerID= '" + oBLLGrowthAnalysisRow.CustomerID + "'");
                oDSCYTargetFiltered.Merge(oDRCYTarget);
                oDSCYTargetFiltered.AcceptChanges();
                foreach (DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oDSCYTargetRow in oDSCYTargetFiltered.BLLGrowthAnalysis)
                {
                    _oData.CYPTValue = Convert.ToDouble(oDSCYTargetRow.PrimaryTarget);
                    _oData.CYSTValue = Convert.ToDouble(oDSCYTargetRow.SecondaryTarget);
                }

                InnerList.Add(_oData);
            }


        }
        public DSBLLGrowthAnalysis GetRawData(string sType, DateTime dFromDate, DateTime dTodate)
        {
            DSBLLGrowthAnalysis oDSBLLGrowthAnalysis = new DSBLLGrowthAnalysis();

            string sSQL = "";
            #region DTD Sales
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sType == "PrimaryActual")
            {
                cmd = DBController.Instance.GetCommand();
                sSQL = " select CustomerID, sum (Amount)as Value " +
                       " from   " +
                       " (    " +
                       " select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as Amount " +
                       " from   " +
                       " (     " +
                       " select CustomerID,sum(invoiceamount) as crAmount, 0 as drAmount  " +
                       " from bllsysdb.dbo.t_salesInvoice  " +
                       " where invoicedate between '" + dFromDate + "' and '" + dTodate + "'  and invoicedate < '" + dTodate + "' " +
                       " and invoicetypeid in (1,2,3,4,5,17) and invoicestatus not in (3)  " +
                       " group by  CustomerID  " +
                       " union all  " +
                       " select CustomerID, 0 as crAmount,sum(invoiceamount) as drAmount  " +
                       " from bllsysdb.dbo.t_salesInvoice  " +
                       " where invoicedate between '" + dFromDate + "' and '" + dTodate + "'  and invoicedate < '" + dTodate + "'  " +
                       " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3)    " +
                       " group by CustomerID     " +
                       " )as p2       " +
                       " group by CustomerID   " +
                       " ) as TELBLL   " +
                       " group by CustomerID ";
            }
            else if (sType == "SecondaryActual")
            {
                cmd = DBController.Instance.GetCommand();
                sSQL = " select DistributorID as CustomerID, sum(Amount) as Value  " +
                      " from     " +
                      " (    " +
                      " select DistributorID, sum(NetAmount)as Amount      " +
                      " from BLLSysDB.dbo.t_DMSProductTran      " +
                      " where TranTypeID=2 and Trandate between '" + dFromDate + "' and '" + dTodate + "'  and Trandate < '" + dTodate + "'  " +
                      " and DistributorID in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)       " +
                      " group by DistributorID     " +
                      " union all     " +
                      " select b.CustomerID,  sum(TEBL) as Amount     " +
                      " from TELSysDB.dbo.t_SMSDailySecondarySalesCollection a, BLLSysDB.dbo.t_Customer b     " +
                      " where trandate between '" + dFromDate + "' and '" + dTodate + "'  and Trandate < '" + dTodate + "' and a.CustomerID=b.CustomerCode    " +
                      " and b.CustomerID not in (select distributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)      " +
                      " group by b.CustomerID    " +
                      " )as TTO    " +
                      " group by DistributorID  ";
            }
            else if (sType == "StockValue")
            {
                cmd = DBController.Instance.GetCommand();
                sSQL = " select DistributorID as CustomerID, round(sum(STKVal),0)as Value " +
                       " from     " +
                       " (     " +
                       " select DistributorID,a.productID,ASGID,ASGName,BrandID, BrandDesc, CurrentStock, NSP, (NSP*CurrentStock*.95)as STKVal          " +
                       " from BLLSysDB.dbo.t_DMSProductStock a, BLLSysDB.dbo.V_ProductDetails b         " +
                       " where a.ProductID=b.ProductID and DistributorID in (select DistributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1)    " +
                       " and CurrentStock>0      " +
                       " )As ASGStock      " +
                       " group by DistributorID ";
            }
            else if (sType == "BG")
            {
                cmd = DBController.Instance.GetCommand();
                sSQL = " select CustomerID, Sum(MinCreditLimit) as Value  " +
                " from BLLSysDB.dbo.t_CustomerCreditlimit " +
                " where '" + dFromDate + "' between effectivedate and ExpiryDate " +
                " Group by CustomerID ";
            }
            else if (sType == "Collection")
            {
                cmd = DBController.Instance.GetCommand();
                sSQL = " select  CustomerID, sum(CreditAmount-DebitAmount)as Value    " +
                       " from     " +
                       " (     " +
                       " select customerid, sum(amount)as CreditAmount, 0 as DebitAmount  from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt      " +
                       " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between '" + dFromDate + "' and '" + dTodate + "'  and  ct.TranDate < '" + dTodate + "'     " +
                       " group by customerid        " +
                       " union all        " +
                       " select customerid, 0 as CreditAmount, sum(amount)as DebitAmount  from BLLSysDB.dbo.t_customerTran ct, BLLSysDB.dbo.t_customerTrantype ctt        " +
                       " where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20)  and ct.TranDate between '" + dFromDate + "' and '" + dTodate + "'  and  ct.TranDate < '" + dTodate + "'    " +
                       " group by customerid     " +
                       " )as Coll     " +
                       " group by CustomerID  ";
            }
            
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oBLLGrowthAnalysisRow = oDSBLLGrowthAnalysis.BLLGrowthAnalysis.NewBLLGrowthAnalysisRow();

                    oBLLGrowthAnalysisRow.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    oBLLGrowthAnalysisRow.Amount = Convert.ToDouble(reader["Value"]);

                    oDSBLLGrowthAnalysis.BLLGrowthAnalysis.AddBLLGrowthAnalysisRow(oBLLGrowthAnalysisRow);
                    oDSBLLGrowthAnalysis.AcceptChanges();
                 }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion

            return oDSBLLGrowthAnalysis;
        }
        public DSBLLGrowthAnalysis GetRawDataTarget(DateTime dFromDate, DateTime dTodate)
        {
            DSBLLGrowthAnalysis oDSBLLGrowthAnalysis = new DSBLLGrowthAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

                cmd = DBController.Instance.GetCommand();
                sSQL = " select CustomerID, Sum(TGTTO) as PrimaryTarget, Sum(SecTGTTO) as SecondaryTarget  " +
                       " from TELAddDB.dbo.t_DistributorDayTGTTO a, BLLsysDB.dbo.t_Customer b      " +
                       " where TGTDate between '" + dFromDate + "' and '" + dTodate + "'  and  TGTDate < '" + dTodate + "' " +
                       " and a.Customercode=b.Customercode Group by CustomerID ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oBLLGrowthAnalysisRow = oDSBLLGrowthAnalysis.BLLGrowthAnalysis.NewBLLGrowthAnalysisRow();

                    oBLLGrowthAnalysisRow.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    oBLLGrowthAnalysisRow.PrimaryTarget = Convert.ToDouble(reader["PrimaryTarget"]);
                    oBLLGrowthAnalysisRow.SecondaryTarget = Convert.ToDouble(reader["SecondaryTarget"]);

                    oDSBLLGrowthAnalysis.BLLGrowthAnalysis.AddBLLGrowthAnalysisRow(oBLLGrowthAnalysisRow);
                    oDSBLLGrowthAnalysis.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLGrowthAnalysis;
        }
        public DSBLLGrowthAnalysis GetCustomerList()
        {
            DSBLLGrowthAnalysis oDSBLLGrowthAnalysis = new DSBLLGrowthAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();
            sSQL = " select CustomerID, CustomerCode, CustomerName, IsNull(CustomerShortName,CustomerName) as CustomerShortName, " +
                   " AreaShortName, TerritoryShortName,AreaID, TerritoryID, (CurrentBalance * -1) as CurrentBalance from BLLSysDB.dbo.v_CustomerDetails where  " +
                   "  ChannelID=2 Order by AreaSort, TerritorySort, CustomerShortName  ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLGrowthAnalysis.BLLGrowthAnalysisRow oBLLGrowthAnalysisRow = oDSBLLGrowthAnalysis.BLLGrowthAnalysis.NewBLLGrowthAnalysisRow();

                    oBLLGrowthAnalysisRow.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    oBLLGrowthAnalysisRow.CustomerCode = reader["CustomerCode"].ToString();
                    oBLLGrowthAnalysisRow.CustomerName = reader["CustomerName"].ToString();
                    oBLLGrowthAnalysisRow.CustomerShortName = reader["CustomerShortName"].ToString();
                    oBLLGrowthAnalysisRow.AreaName = reader["AreaShortName"].ToString();
                    oBLLGrowthAnalysisRow.TerritoryName = reader["TerritoryShortName"].ToString();
                    oBLLGrowthAnalysisRow.AreaID = reader["AreaID"].ToString();
                    oBLLGrowthAnalysisRow.TerritoryID = reader["TerritoryID"].ToString();

                    if (reader["CurrentBalance"] != DBNull.Value)
                        oBLLGrowthAnalysisRow.CurrentBalance = Convert.ToDouble(reader["CurrentBalance"]);
                    else oBLLGrowthAnalysisRow.CurrentBalance = 0;

                    oDSBLLGrowthAnalysis.BLLGrowthAnalysis.AddBLLGrowthAnalysisRow(oBLLGrowthAnalysisRow);
                    oDSBLLGrowthAnalysis.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLGrowthAnalysis;
        }
        public List<Data> getResult(int DayOfMonth, int TotalDayOfMonth, int DayOfYear, int TotalDayOfYear)
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.ShortName = oData.ShortName;
                _oData.FullName = oData.FullName;
                _oData.CustomerCode = oData.CustomerCode;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;
                _oData.CustomerID = oData.CustomerID;
                _oData.AreaID = oData.AreaID;
                _oData.TerritoryID = oData.TerritoryID;

                _oData.CMPTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMPTValue));
                _oData.CMPAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMPAValue));
                _oData.CMSTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSTValue));
                _oData.CMSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSAValue));
                _oData.LMPTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMPTValue));
                _oData.LMPAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMPAValue));
                _oData.LMSTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMSTValue));
                _oData.LMSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMSAValue));
                _oData.CYPTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CYPTValue));
                _oData.CYPAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CYPAValue));
                _oData.CYSTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CYSTValue));
                _oData.CYSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CYSAValue));
                _oData.LYPAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYPAValue));
                _oData.LYSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYSAValue));
                _oData.ReceivablesText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Receivables));
                _oData.StockValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.StockValue));
                _oData.BGText = ExcludeDecimal(_oTELLib.TakaFormat(oData.BG));
                _oData.CollectionText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Collection));
                _oData.CollectionLMText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CollectionLM));

                double CMPTMTDValue = (oData.CMPTValue / TotalDayOfMonth * DayOfMonth);
                _oData.CMPTMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(CMPTMTDValue));

                double CMSTMTDValue = (oData.CMSTValue / TotalDayOfMonth * DayOfMonth);
                _oData.CMSTMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(CMSTMTDValue));

                if (CMPTMTDValue > 0)
                    _oData.CMPMTDPercText = Convert.ToString(Math.Round((oData.CMPAValue / CMPTMTDValue * 100), 0));
                else _oData.CMPMTDPercText = "0";

                if (oData.CMPTValue > 0)
                    _oData.CMPPercText = Convert.ToString(Math.Round((oData.CMPAValue / oData.CMPTValue * 100), 0));
                else _oData.CMPPercText = "0";

                if (CMSTMTDValue > 0)
                    _oData.CMSMTDPercText = Convert.ToString(Math.Round((oData.CMSAValue / CMSTMTDValue * 100), 0));
                else _oData.CMSMTDPercText = "0";

                if (oData.CMSTValue > 0)
                    _oData.CMSPercText = Convert.ToString(Math.Round((oData.CMSAValue / oData.CMSTValue * 100), 0));
                else _oData.CMSPercText = "0";

                if (oData.LMPTValue > 0)
                    _oData.LMPPercText = Convert.ToString(Math.Round((oData.LMPAValue / oData.LMPTValue * 100), 0));
                else _oData.LMPPercText = "0";

                if (oData.LMSTValue > 0)
                    _oData.LMSPercText = Convert.ToString(Math.Round((oData.LMSAValue / oData.LMSTValue * 100), 0));
                else _oData.LMSPercText = "0";


                double CYPTMTDValue = (oData.CYPTValue / TotalDayOfYear * DayOfYear);
                _oData.CYPTMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(CYPTMTDValue));

                double CYSTMTDValue = (oData.CYSTValue / TotalDayOfYear * DayOfYear);
                _oData.CYSTMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(CYSTMTDValue));

                if (CYPTMTDValue > 0)
                    _oData.CYPMTDPercText = Convert.ToString(Math.Round((oData.CYPAValue / CYPTMTDValue * 100), 0));
                else _oData.CYPMTDPercText = "0";

                if (oData.CYPTValue > 0)
                    _oData.CYPPercText = Convert.ToString(Math.Round((oData.CYPAValue / oData.CYPTValue * 100), 0));
                else _oData.CYPPercText = "0";

                if (CYSTMTDValue > 0)
                    _oData.CYSMTDPercText = Convert.ToString(Math.Round((oData.CYSAValue / CYSTMTDValue * 100), 0));
                else _oData.CYSMTDPercText = "0";

                if (oData.CYSTValue > 0)
                    _oData.CYSPercText = Convert.ToString(Math.Round((oData.CYSAValue / oData.CYSTValue * 100), 0));
                else _oData.CYSPercText = "0";

                //Growth

                if (oData.LMPAMTDValue > 0)
                {
                    _oData.GPLMMTDPercText = Convert.ToString(Math.Round(((oData.CMPAValue / oData.LMPAMTDValue) * 100) - 100));
                }
                else
                {
                    _oData.GPLMMTDPercText = "0";
                }

                if (oData.LMPAValue > 0)
                {
                    _oData.GPLMFullPercText = Convert.ToString(Math.Round(((oData.CMPAValue / oData.LMPAValue) * 100) - 100));
                }
                else
                {
                    _oData.GPLMFullPercText = "0";
                }
                if (oData.LMSAMTDValue > 0)
                {
                    _oData.GSLMMTDPercText = Convert.ToString(Math.Round(((oData.CMSAValue / oData.LMSAMTDValue) * 100) - 100));
                }
                else
                {
                    _oData.GSLMMTDPercText = "0";
                }

                if (oData.LMSAValue > 0)
                {
                    _oData.GSLMFullPercText = Convert.ToString(Math.Round(((oData.CMSAValue / oData.LMSAValue) * 100) - 100));
                }
                else
                {
                    _oData.GSLMFullPercText = "0";
                }

                //----------

                if (oData.LYCMPAMTDValue > 0)
                {
                    _oData.GPLYCMMTDPercText = Convert.ToString(Math.Round(((oData.CMPAValue / oData.LYCMPAMTDValue) * 100) - 100));
                }
                else
                {
                    _oData.GPLYCMMTDPercText = "0";
                }

                if (oData.LYCMPAValue > 0)
                {
                    _oData.GPLYCMFullPercText = Convert.ToString(Math.Round(((oData.CMPAValue / oData.LYCMPAValue) * 100) - 100));
                }
                else
                {
                    _oData.GPLYCMFullPercText = "0";
                }
                if (oData.LYCMSAMTDValue > 0)
                {
                    _oData.GSLYCMMTDPercText = Convert.ToString(Math.Round(((oData.CMSAValue / oData.LYCMSAMTDValue) * 100) - 100));
                }
                else
                {
                    _oData.GSLYCMMTDPercText = "0";
                }

                if (oData.LYCMSAValue > 0)
                {
                    _oData.GSLYCMFullPercText = Convert.ToString(Math.Round(((oData.CMSAValue / oData.LYCMSAValue) * 100) - 100));
                }
                else
                {
                    _oData.GSLYCMFullPercText = "0";
                }

                eList.Add(_oData);
            }
            return eList;

        }
    }
}


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

using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.ANDROID;
using CJ.Class.Library;

public partial class jBLLPriSecTO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            HttpContext c = HttpContext.Current;
            //string sUser = c.Request.Form["UserName"].Trim();

             string sUser = "hrashid";
            
            TargetVsAchs oTargetVsAchs = new TargetVsAchs();
            TargetVsAch _oTargetVsAch = new TargetVsAch();
            DBController.Instance.OpenNewConnection();
            DateTime dStartDateofWeek = Convert.ToDateTime(_oTargetVsAch.GetWeekFromDate());
           

            oTargetVsAchs.RefreshBLLTOMTD();
                  
            
            DBController.Instance.CloseConnection();

            TELLib oTELLib = new TELLib();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oDataArea = new Data();
            Data _oDataZone = new Data();
            Data _oDataOutlet = new Data();
            int nCount = 0;
            foreach (TargetVsAch oTargetVsAch in oTargetVsAchs)
            {

                if (nCount == 0)
                {
                    _oDataTotal = new Data();
                    _oDatas.Add(_oDataTotal);
                    _oDataTotal.Outlet = "Total";
                    _oDataTotal.Type = "Total";
                    _oDataTotal.Value = "Success";                  
                    nCount++;
                }
                if (_oDataArea.AreaName != oTargetVsAch.AreaName)
                {
                    _oDataArea = new Data();
                    _oDatas.Add(_oDataArea);
                    _oDataArea.AreaID =Convert.ToInt32(oTargetVsAch.AreaID).ToString();   // New Code for Area
                    _oDataArea.AreaName = oTargetVsAch.AreaName;
                    _oDataArea.Outlet = oTargetVsAch.AreaName;
                    _oDataArea.Type = "Area";
                    _oDataArea.Value = "Success";                    
                }
                if (_oDataZone.TerritoryName != oTargetVsAch.TerritoryName)
                {
                    _oDataZone = new Data();
                    _oDatas.Add(_oDataZone);
                    _oDataZone.TerritoryName = oTargetVsAch.TerritoryName;
                    _oDataZone.Outlet = oTargetVsAch.TerritoryName;
                    _oDataZone.Type = "Territory";
                    _oDataZone.Value = "Success";
                                       
                }

                _oDataOutlet = new Data();
                _oDataOutlet.Value = "Success";

                _oDataOutlet.CustomerID =Convert.ToInt32(oTargetVsAch.CustomerID).ToString();
                _oDataOutlet.Outlet = oTargetVsAch.CustomerName;
                _oDataOutlet.TGTTO = oTargetVsAch.TGTTO;
                _oDataOutlet.SecTGTTO = oTargetVsAch.SecTGTTO;
                _oDataOutlet.PriTO = oTargetVsAch.PriTO;                
                _oDataOutlet.SecTO = oTargetVsAch.SecTO;               
                _oDataOutlet.Receivables = oTargetVsAch.Receivables;
                _oDataOutlet.PriStockVal = oTargetVsAch.PriStockVal;
                _oDataOutlet.SecStockVal = oTargetVsAch.SecStockVal;
                _oDataOutlet.Type = "Distributor";
                            
                _oDatas.Add(_oDataOutlet);

                _oDataTotal.TGTTO = _oDataTotal.TGTTO + oTargetVsAch.TGTTO;
                _oDataTotal.SecTGTTO = _oDataTotal.SecTGTTO + oTargetVsAch.SecTGTTO;
                _oDataTotal.PriTO = _oDataTotal.PriTO + oTargetVsAch.PriTO;               
                _oDataTotal.SecTO = _oDataTotal.SecTO + oTargetVsAch.SecTO;
                _oDataTotal.Receivables = _oDataTotal.Receivables + oTargetVsAch.Receivables;
                _oDataTotal.PriStockVal = _oDataTotal.PriStockVal + oTargetVsAch.PriStockVal;
                _oDataTotal.SecStockVal = _oDataTotal.SecStockVal + oTargetVsAch.SecStockVal;
                              

                _oDataArea.TGTTO = _oDataArea.TGTTO + oTargetVsAch.TGTTO;
                _oDataArea.SecTGTTO = _oDataArea.SecTGTTO + oTargetVsAch.SecTGTTO;
                _oDataArea.PriTO = _oDataArea.PriTO + oTargetVsAch.PriTO;
                _oDataArea.SecTO = _oDataArea.SecTO + oTargetVsAch.SecTO;
                _oDataArea.Receivables = _oDataArea.Receivables + oTargetVsAch.Receivables;
                _oDataArea.PriStockVal = _oDataArea.PriStockVal + oTargetVsAch.PriStockVal;
                _oDataArea.SecStockVal = _oDataArea.SecStockVal + oTargetVsAch.SecStockVal;


                _oDataZone.TGTTO = _oDataZone.TGTTO + oTargetVsAch.TGTTO;
                _oDataZone.SecTGTTO = _oDataZone.SecTGTTO + oTargetVsAch.SecTGTTO;
                _oDataZone.PriTO = _oDataZone.PriTO + oTargetVsAch.PriTO;
                _oDataZone.SecTO = _oDataZone.SecTO + oTargetVsAch.SecTO;
                _oDataZone.Receivables = _oDataZone.Receivables + oTargetVsAch.Receivables;
                _oDataZone.PriStockVal = _oDataZone.PriStockVal + oTargetVsAch.PriStockVal;
                _oDataZone.SecStockVal = _oDataZone.SecStockVal + oTargetVsAch.SecStockVal;
            }
            Data oData = new Data();
            oData.InsertReportLog(sUser);    

            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());


        }
    }
    private string ExcludeDecimal(string sAmount)
    {
        string sResult = "";
        sResult = sAmount.Remove(sAmount.Length - 3);
        return sResult;
    }
    public class Data
    {
        public string ChannelName;
        public string AreaID;
        public string AreaName;
        public string TerritoryName;
        public string CustomerID;
        public string CustomerName;
        public string Type;
        public string Outlet;
        public string RegionID;
        public string RegionName;

        //public string LWeekNo;
        //public string LSMonth;
        //public string LSDate;
        //public string LEDate;
        //public double LTAmt;
        //public double LSAmt;



        public double TGTTO;        
        public double SecTGTTO;
        public double PriTO;
        public double SecTO;
        public double Receivables;
        public double PriStockVal;
        public double SecStockVal;
       // public double PriAch;       
       // public double SecAch;


        public string TGTTOText;
        public string SecTGTTOText;
        public string PriTOText;
        public string PriAchText;
        public string SecTOText;
        public string SecAchText;
        public string ReceivablesText;
        public string PriStockValText;
        public string SecStockValText;

        public string PriAch;
        public string SecAch;
        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10019";
            string sReportName = "BLL-Target Vs Ach TO";
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
        public List<Data> getResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            foreach (Data oData in this)
            {
                _oData = new Data();

                _oData.ChannelName = oData.ChannelName;
                _oData.AreaID = oData.AreaID;
                _oData.AreaName = oData.AreaName;
                _oData.TerritoryName = oData.TerritoryName;
                _oData.CustomerID = oData.CustomerID;
                _oData.CustomerName = oData.CustomerName;

                _oData.Value = oData.Value;
                _oData.Outlet = oData.Outlet; 
                _oData.Type = oData.Type;


                _oData.TGTTOText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TGTTO));
                _oData.SecTGTTOText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecTGTTO));
                _oData.PriTOText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriTO));               
                _oData.SecTOText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecTO));               
                _oData.ReceivablesText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Receivables));
                _oData.PriStockValText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriStockVal));
                _oData.SecStockValText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecStockVal));


                if (oData.TGTTO > 0)
                {
                    _oData.PriAch = (Math.Round((oData.PriTO / oData.TGTTO) * 100)).ToString();
                }
                else
                {
                    _oData.PriAch = "0";
                }
                if (oData.TGTTO > 0)
                {
                    _oData.SecAch = (Math.Round((oData.SecTO / oData.SecTGTTO) * 100)).ToString();
                }
                else
                {
                    _oData.SecAch = "0";
                }
                



                eList.Add(_oData);
            }
            return eList;

        }
    }
}


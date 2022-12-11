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

public partial class jBLLSalesSummaryValue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sDataType = c.Request.Form["DataType"].Trim();

            //string sDataType = "Sec";
            //string sUser = "dipak";


            TargetVsAchs oTargetVsAchs = new TargetVsAchs();
            TargetVsAch _oTargetVsAch = new TargetVsAch();

            DBController.Instance.OpenNewConnection();

            if (sDataType == "Pri")
            {
                oTargetVsAchs.PriSalesValueBLL();
            }
            else if (sDataType == "Sec")
            {
              
                oTargetVsAchs.SecSalesValueBLLDWH();
            }

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

                _oDataOutlet.Outlet = oTargetVsAch.CustomerName;
                _oDataOutlet.DTD = oTargetVsAch.DTD;
                _oDataOutlet.LD = oTargetVsAch.LD;
                _oDataOutlet.MTD = oTargetVsAch.MTD;
                _oDataOutlet.LM = oTargetVsAch.LM;
                _oDataOutlet.YTD = oTargetVsAch.YTD;
                _oDataOutlet.Type = "Distributor";
                _oDatas.Add(_oDataOutlet);

                _oDataTotal.DTD = _oDataTotal.DTD + oTargetVsAch.DTD;
                _oDataTotal.LD = _oDataTotal.LD + oTargetVsAch.LD;
                _oDataTotal.MTD = _oDataTotal.MTD + oTargetVsAch.MTD;
                _oDataTotal.LM = _oDataTotal.LM + oTargetVsAch.LM;
                _oDataTotal.YTD = _oDataTotal.YTD + oTargetVsAch.YTD;


                _oDataArea.DTD = _oDataArea.DTD + oTargetVsAch.DTD;
                _oDataArea.LD = _oDataArea.LD + oTargetVsAch.LD;
                _oDataArea.MTD = _oDataArea.MTD + oTargetVsAch.MTD;
                _oDataArea.LM = _oDataArea.LM + oTargetVsAch.LM;
                _oDataArea.YTD = _oDataArea.YTD + oTargetVsAch.YTD;


                _oDataZone.DTD = _oDataZone.DTD + oTargetVsAch.DTD;
                _oDataZone.LD = _oDataZone.LD + oTargetVsAch.LD;
                _oDataZone.MTD = _oDataZone.MTD + oTargetVsAch.MTD;
                _oDataZone.LM = _oDataZone.LM + oTargetVsAch.LM;
                _oDataZone.YTD = _oDataZone.YTD + oTargetVsAch.YTD;
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
       
        public string AreaName;
        public string TerritoryName;
        public string CustomerName;
        public string Type;
        public string Outlet;           

        public double DTD;
        public double LD;
        public double MTD;
        public double LM;
        public double YTD;

        public string DTDText;
        public string LDText;
        public string MTDText;
        public string LMText;
        public string YTDText;
               
        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10023";
            string sReportName = "BLL-Sales Summary value";
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

                
                _oData.AreaName = oData.AreaName;
                _oData.TerritoryName = oData.TerritoryName;
                _oData.CustomerName = oData.CustomerName;
                _oData.Value = oData.Value;

                _oData.Outlet = oData.Outlet;
                _oData.Type = oData.Type;              

                _oData.DTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.DTD));
                _oData.LDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LD));
                _oData.MTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTD));
                _oData.LMText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LM));
                _oData.YTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTD));
                              
                eList.Add(_oData);
            }
            return eList;

        }
    }

}

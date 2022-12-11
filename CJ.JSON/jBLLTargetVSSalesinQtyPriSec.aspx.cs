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


public partial class jBLLTargetVSSalesinQtyPriSec : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            string sASGName = c.Request.Form["ASGName"].Trim();
            string sBrandName = c.Request.Form["BrandName"].Trim();

          //string sCompany = c.Request.Form["Company"].Trim();
            TargetVsAchs oTargetVsAchs = new TargetVsAchs();
            TargetVsAch _oTargetVsAch = new TargetVsAch();
            DBController.Instance.OpenNewConnection();

            //string sASGName = "GLS";
            //string sBrandName = "Philips";


            oTargetVsAchs.SalesAndTGTQty(sASGName, sBrandName);
            
           // oTargetVsAchs.SalesAndTGTQty(e);


            DBController.Instance.CloseConnection();

            TELLib oTELLib = new TELLib();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oDataChannel = new Data();
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

                if (_oDataChannel.ChannelName != oTargetVsAch.Channelname)
                {
                    _oDataChannel = new Data();
                    _oDatas.Add(_oDataChannel);
                    _oDataChannel.ChannelName = oTargetVsAch.Channelname;
                    _oDataChannel.AreaName = oTargetVsAch.Channelname;
                    _oDataChannel.Type = "Channel";
                    _oDataChannel.Value = "Success";
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

                _oDataOutlet.CustomerID = Convert.ToInt32(oTargetVsAch.CustomerID).ToString();
                _oDataOutlet.Outlet = oTargetVsAch.CustomerName;

                _oDataOutlet.ASGName = oTargetVsAch.ASGName;
                _oDataOutlet.BrandDesc = oTargetVsAch.BrandDesc;

                _oDataOutlet.TGTQty = oTargetVsAch.TGTQty;
                _oDataOutlet.PriQty = oTargetVsAch.PriQty;
                _oDataOutlet.SecTGT = oTargetVsAch.SecTGT;
                _oDataOutlet.SecQty = oTargetVsAch.SecQty;
               
                _oDataOutlet.Type = "Distributor";

                _oDatas.Add(_oDataOutlet);

                _oDataTotal.TGTQty = _oDataTotal.TGTQty + oTargetVsAch.TGTQty;
                _oDataTotal.PriQty = _oDataTotal.PriQty + oTargetVsAch.PriQty;
                _oDataTotal.SecTGT = _oDataTotal.SecTGT + oTargetVsAch.SecTGT;
                _oDataTotal.SecQty = _oDataTotal.SecQty + oTargetVsAch.SecQty;

                _oDataChannel.TGTQty = _oDataChannel.TGTQty + oTargetVsAch.TGTQty;
                _oDataChannel.PriQty = _oDataChannel.PriQty + oTargetVsAch.PriQty;
                _oDataChannel.SecTGT = _oDataChannel.SecTGT + oTargetVsAch.SecTGT;
                _oDataChannel.SecQty = _oDataChannel.SecQty + oTargetVsAch.SecQty;


                _oDataArea.TGTQty = _oDataArea.TGTQty + oTargetVsAch.TGTQty;
                _oDataArea.PriQty = _oDataArea.PriQty + oTargetVsAch.PriQty;
                _oDataArea.SecTGT = _oDataArea.SecTGT + oTargetVsAch.SecTGT;
                _oDataArea.SecQty = _oDataArea.SecQty + oTargetVsAch.SecQty;


                _oDataZone.TGTQty = _oDataZone.TGTQty + oTargetVsAch.TGTQty;
                _oDataZone.PriQty = _oDataZone.PriQty + oTargetVsAch.PriQty;
                _oDataZone.SecTGT = _oDataZone.SecTGT + oTargetVsAch.SecTGT;
                _oDataZone.SecQty = _oDataZone.SecQty + oTargetVsAch.SecQty;

                
            }

            Data oData = new Data();
           // oData.InsertReportLog(sUser);

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
        public string AreaName;
        public string TerritoryName;
        public string CustomerID;
        public string CustomerName;
        public string ASGName;
        public string BrandDesc;
        public string Type;
        public string Outlet;



        public double TGTQty;
        public double PriQty;
        public double SecTGT;
        public double SecQty;



        public string TGTQtyText;
        public string PriQtyText;
        public string SecTGTText;
        public string SecQtyText;       

        public string PriAch;
        public string SecAch;
        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10019";
            string sReportName = "BLL-Target Vs Ach in Qty";
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
                _oData.AreaName = oData.AreaName;
                _oData.TerritoryName = oData.TerritoryName;
                _oData.CustomerID = oData.CustomerID;
                _oData.CustomerName = oData.CustomerName;
                _oData.ASGName = oData.ASGName;
                _oData.BrandDesc = oData.BrandDesc;

                _oData.Value = oData.Value;
                _oData.Outlet = oData.Outlet;
                _oData.Type = oData.Type; 

                _oData.TGTQtyText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TGTQty));
                _oData.PriQtyText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriQty));
               
                _oData.SecTGTText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecTGT));
                _oData.SecQtyText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecQty));
                

                if (oData.TGTQty > 0)
                {
                    _oData.PriAch = (Math.Round((oData.PriQty / oData.TGTQty) * 100)).ToString();
                }
                else
                {
                    _oData.PriAch = "0";
                }
                if (oData.SecTGT > 0)
                {
                    _oData.SecAch = (Math.Round((oData.SecQty / oData.SecTGT) * 100)).ToString();
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

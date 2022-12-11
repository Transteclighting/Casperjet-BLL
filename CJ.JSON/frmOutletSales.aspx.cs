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

public partial class frmOutletSales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            TELs oTELs = new TELs();
            DBController.Instance.OpenNewConnection();
            oTELs.RefreshOutlet(sCompany);
            DBController.Instance.CloseConnection();
            
            TELLib oTELLib = new TELLib();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oDataArea = new Data();
            Data _oDataZone = new Data();
            Data _oDataOutlet = new Data();
            int nCount = 0;
            foreach (TEL oTEL in oTELs)
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
                if (_oDataArea.AreaName != oTEL.AreaName)
                {
                    _oDataArea = new Data();
                    _oDatas.Add(_oDataArea);
                    _oDataArea.AreaName = oTEL.AreaName;
                    _oDataArea.Outlet = oTEL.AreaName;
                    _oDataArea.Type = "Area";
                    _oDataArea.Value = "Success";
                }
                if (_oDataZone.TerritoryName != oTEL.TerritoryName)
                {
                    _oDataZone = new Data();
                    _oDatas.Add(_oDataZone);
                    _oDataZone.TerritoryName = oTEL.TerritoryName;
                    _oDataZone.Outlet = oTEL.TerritoryName;
                    _oDataZone.Type = "Zone";
                    _oDataZone.Value = "Success";
                }

                _oDataOutlet = new Data();
                _oDataOutlet.Value = "Success";

                _oDataOutlet.Outlet = oTEL.Outlet;
                _oDataOutlet.DTD = oTEL.DTD;
                _oDataOutlet.LD = oTEL.LD;
                _oDataOutlet.MTD = oTEL.MTD;
                _oDataOutlet.LM = oTEL.LM;
                _oDataOutlet.YTD = oTEL.YTD;
                //_oDataOutlet.LYYTD = oTEL.LYYTD;
                _oDataOutlet.Type = "Outlet";
                _oDatas.Add(_oDataOutlet);

                _oDataTotal.DTD = _oDataTotal.DTD + oTEL.DTD;
                _oDataTotal.LD = _oDataTotal.LD + oTEL.LD;
                _oDataTotal.MTD = _oDataTotal.MTD + oTEL.MTD;
                _oDataTotal.LM = _oDataTotal.LM + oTEL.LM;
                _oDataTotal.YTD = _oDataTotal.YTD + oTEL.YTD;
                //_oDataTotal.LYYTD = _oDataTotal.LYYTD + oTEL.LYYTD;

                _oDataArea.DTD =  _oDataArea.DTD + oTEL.DTD;
                _oDataArea.LD = _oDataArea.LD + oTEL.LD;
                _oDataArea.MTD = _oDataArea.MTD + oTEL.MTD;
                _oDataArea.LM = _oDataArea.LM + oTEL.LM;
                _oDataArea.YTD = _oDataArea.YTD + oTEL.YTD;
                //_oDataArea.LYYTD = _oDataArea.LYYTD + oTEL.LYYTD;

                _oDataZone.DTD = _oDataZone.DTD + oTEL.DTD;
                _oDataZone.LD = _oDataZone.LD + oTEL.LD;
                _oDataZone.MTD = _oDataZone.MTD + oTEL.MTD;
                _oDataZone.LM = _oDataZone.LM + oTEL.LM;
                _oDataZone.YTD = _oDataZone.YTD + oTEL.YTD;
                //_oDataZone.LYYTD = _oDataZone.LYYTD + oTEL.LYYTD;

            }

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
        public string Type;
        public string Outlet;

        public double DTD;
        public double LD;
        public double MTD;
        public double LM;
        public double YTD;
        public double LYYTD;

        public string DTDText;
        public string LDText;
        public string LMText;
        public string MTDText;
        public string YTDText;
        public string LYYTDText;
     

        public string Value;
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
            TELLib _oTELLib =new TELLib();
            List<Data> eList = new List<Data>();
            foreach(Data oData in this)
            {
                _oData = new Data();
                _oData.AreaName = oData.AreaName;
                _oData.TerritoryName = oData.TerritoryName;
                _oData.Value = oData.Value;
                _oData.Outlet = oData.Outlet;
                _oData.Type = oData.Type;
                _oData.DTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.DTD));
                _oData.LDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LD));
                _oData.MTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTD));
                _oData.LMText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LM));
                _oData.YTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTD));
                _oData.LYYTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTD));

                eList.Add(_oData);
            }
            return eList;

        }
    }
}

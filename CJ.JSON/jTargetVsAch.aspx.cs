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

public partial class jTargetVsAch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            //string sUser = c.Request.Form["UserName"].Trim();
            //string sCompany = c.Request.Form["Company"].Trim();
            TargetVsAchs oTargetVsAchs = new TargetVsAchs();
            TargetVsAch _oTargetVsAch = new TargetVsAch();
            DBController.Instance.OpenNewConnection();
            DateTime dStartDateofWeek = Convert.ToDateTime(_oTargetVsAch.GetWeekFromDate());
            oTargetVsAchs.Refresh(dStartDateofWeek);
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

                    _oDataTotal.LWeekNo = oTargetVsAch.LWeekNo;
                    _oDataTotal.LSMonth = oTargetVsAch.LSMonth;
                    _oDataTotal.LSDate = oTargetVsAch.LSDate;
                    _oDataTotal.LEDate = oTargetVsAch.LEDate;

                    _oDataTotal.CWeekNo = oTargetVsAch.CWeekNo;
                    _oDataTotal.CSMonth = oTargetVsAch.CSMonth;
                    _oDataTotal.CSDate = oTargetVsAch.CSDate;
                    _oDataTotal.CEDate = oTargetVsAch.CEDate;


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

                    _oDataArea.LWeekNo = oTargetVsAch.LWeekNo;
                    _oDataArea.LSMonth = oTargetVsAch.LSMonth;
                    _oDataArea.LSDate = oTargetVsAch.LSDate;
                    _oDataArea.LEDate = oTargetVsAch.LEDate;

                    _oDataArea.CWeekNo = oTargetVsAch.CWeekNo;
                    _oDataArea.CSMonth = oTargetVsAch.CSMonth;
                    _oDataArea.CSDate = oTargetVsAch.CSDate;
                    _oDataArea.CEDate = oTargetVsAch.CEDate;
                }
                if (_oDataZone.TerritoryName != oTargetVsAch.TerritoryName)
                {
                    _oDataZone = new Data();
                    _oDatas.Add(_oDataZone);
                    _oDataZone.TerritoryName = oTargetVsAch.TerritoryName;
                    _oDataZone.Outlet = oTargetVsAch.TerritoryName;
                    _oDataZone.Type = "Zone";
                    _oDataZone.Value = "Success";

                    _oDataZone.LWeekNo = oTargetVsAch.LWeekNo;
                    _oDataZone.LSMonth = oTargetVsAch.LSMonth;
                    _oDataZone.LSDate = oTargetVsAch.LSDate;
                    _oDataZone.LEDate = oTargetVsAch.LEDate;

                    _oDataZone.CWeekNo = oTargetVsAch.CWeekNo;
                    _oDataZone.CSMonth = oTargetVsAch.CSMonth;
                    _oDataZone.CSDate = oTargetVsAch.CSDate;
                    _oDataZone.CEDate = oTargetVsAch.CEDate;
                }

                _oDataOutlet = new Data();
                _oDataOutlet.Value = "Success";

                _oDataOutlet.Outlet = oTargetVsAch.Outlet;
                _oDataOutlet.LTAmt = oTargetVsAch.LTAmt;
                _oDataOutlet.LSAmt = oTargetVsAch.LSAmt;
                _oDataOutlet.CTAmt = oTargetVsAch.CTAmt;
                _oDataOutlet.CSAmt = oTargetVsAch.CSAmt;
                _oDataOutlet.WTDTar = oTargetVsAch.WTDTar;
                _oDataOutlet.Type = "Outlet";

                _oDataOutlet.LWeekNo = oTargetVsAch.LWeekNo;
                _oDataOutlet.LSMonth = oTargetVsAch.LSMonth;
                _oDataOutlet.LSDate = oTargetVsAch.LSDate;
                _oDataOutlet.LEDate = oTargetVsAch.LEDate;

                _oDataOutlet.CWeekNo = oTargetVsAch.CWeekNo;
                _oDataOutlet.CSMonth = oTargetVsAch.CSMonth;
                _oDataOutlet.CSDate = oTargetVsAch.CSDate;
                _oDataOutlet.CEDate = oTargetVsAch.CEDate;
                _oDatas.Add(_oDataOutlet);

                _oDataTotal.LTAmt = _oDataTotal.LTAmt + oTargetVsAch.LTAmt;
                _oDataTotal.LSAmt = _oDataTotal.LSAmt + oTargetVsAch.LSAmt;
                _oDataTotal.CTAmt = _oDataTotal.CTAmt + oTargetVsAch.CTAmt;
                _oDataTotal.CSAmt = _oDataTotal.CSAmt + oTargetVsAch.CSAmt;
                _oDataTotal.WTDTar = _oDataTotal.WTDTar + oTargetVsAch.WTDTar;

                _oDataArea.LTAmt = _oDataArea.LTAmt + oTargetVsAch.LTAmt;
                _oDataArea.LSAmt = _oDataArea.LSAmt + oTargetVsAch.LSAmt;
                _oDataArea.CTAmt = _oDataArea.CTAmt + oTargetVsAch.CTAmt;
                _oDataArea.CSAmt = _oDataArea.CSAmt + oTargetVsAch.CSAmt;
                _oDataArea.WTDTar = _oDataArea.WTDTar + oTargetVsAch.WTDTar;

                _oDataZone.LTAmt = _oDataZone.LTAmt + oTargetVsAch.LTAmt;
                _oDataZone.LSAmt = _oDataZone.LSAmt + oTargetVsAch.LSAmt;
                _oDataZone.CTAmt = _oDataZone.CTAmt + oTargetVsAch.CTAmt;
                _oDataZone.CSAmt = _oDataZone.CSAmt + oTargetVsAch.CSAmt;
                _oDataZone.WTDTar = _oDataZone.WTDTar + oTargetVsAch.WTDTar;


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

        public string LWeekNo;
        public string LSMonth;
        public string LSDate;
        public string LEDate;
        public double LTAmt;
        public double LSAmt;

        public string CWeekNo;
        public string CSMonth;
        public string CSDate;
        public string CEDate;
        public double CTAmt;
        public double CSAmt;
        public double WTDTar;

        public string LTAmtText;
        public string LSAmtText;
        public string CTAmtText;
        public string CSAmtText;
        public string WTDTarText;
        public string LPercent;
        public string CPercent;
        public string WTDPercent;

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
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            foreach (Data oData in this)
            {
                _oData = new Data();

                _oData.AreaName = oData.AreaName;
                _oData.TerritoryName = oData.TerritoryName;
                _oData.Value = oData.Value;
                _oData.Outlet = oData.Outlet;
                _oData.Type = oData.Type;

                _oData.LWeekNo = oData.LWeekNo;
                _oData.LSMonth = oData.LSMonth;
                _oData.LSDate = oData.LSDate;
                _oData.LEDate = oData.LEDate;

                _oData.CWeekNo = oData.CWeekNo;
                _oData.CSMonth = oData.CSMonth;
                _oData.CSDate = oData.CSDate;
                _oData.CEDate = oData.CEDate;

                _oData.LTAmtText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LTAmt));
                _oData.LSAmtText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LSAmt));
                _oData.CTAmtText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CTAmt));
                _oData.CSAmtText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CSAmt));
                _oData.WTDTarText = ExcludeDecimal(_oTELLib.TakaFormat(oData.WTDTar));


                if (oData.LTAmt > 0)
                {
                    _oData.LPercent = (Math.Round((oData.LSAmt / oData.LTAmt) * 100)).ToString();
                }
                else
                {
                    _oData.LPercent = "0";
                }
                if (oData.CTAmt > 0)
                {
                    _oData.CPercent = (Math.Round((oData.CSAmt / oData.CTAmt) * 100)).ToString();
                }
                else
                {
                    _oData.CPercent = "0";
                }
                if (oData.WTDTar > 0)
                {
                    _oData.WTDPercent = (Math.Round((oData.CSAmt / oData.WTDTar) * 100)).ToString();
                }
                else
                {
                    _oData.WTDPercent = "0";
                }

                eList.Add(_oData);
            }
            return eList;

        }
    }
}

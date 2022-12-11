
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

public partial class jDealerSecondarySales : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();

            //string sCompany = "TEL";
            //string sUser = "hakim"; 

            Datas oDatas = new Datas();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oDataArea = new Data();
            Data _oDataZone = new Data(); 
            Data _oDataOutlet = new Data();
            int nCount = 0;

            DBController.Instance.OpenNewConnection();

            oDatas.GetData(sCompany);
            DBController.Instance.CloseConnection();

            foreach (Data oData in oDatas)
            {
                if (nCount == 0)
                {
                    _oDataTotal = new Data();
                    _oDatas.Add(_oDataTotal);
                    _oDataTotal.Outlet = "Total";
                    _oDataTotal.Type = "Total";
                }
                if (_oDataArea.AreaName != oData.AreaName)
                {
                    _oDataTotal.Value = "Success";
                    nCount++;
                    _oDataArea = new Data();
                    _oDatas.Add(_oDataArea);
                    _oDataArea.AreaName = oData.AreaName;
                    _oDataArea.Outlet = oData.AreaName;
                    _oDataArea.Type = "Area";
                    _oDataArea.Value = "Success";
                }
                if (_oDataZone.ZoneName != oData.ZoneName)
                {
                    _oDataZone = new Data();
                    _oDatas.Add(_oDataZone);
                    _oDataZone.ZoneName = oData.ZoneName;
                    _oDataZone.Outlet = oData.ZoneName;
                    _oDataZone.Type = "Zone";
                    _oDataZone.Value = "Success";
                }

                _oDataOutlet = new Data();
                _oDataOutlet.Value = "Success";

                _oDataOutlet.Outlet = oData.Outlet;
                _oDataOutlet.DTDValue = oData.DTDValue;
                _oDataOutlet.LDValue = oData.LDValue;
                _oDataOutlet.MTDValue = oData.MTDValue;
                _oDataOutlet.LMValue = oData.LMValue;
                _oDataOutlet.YTDValue = oData.YTDValue;
                _oDataOutlet.LYValue = oData.LYValue;
                _oDataOutlet.CMTValue = oData.CMTValue;
                _oDataOutlet.MTDTValue = oData.MTDTValue;
                _oDataOutlet.LMTValue = oData.LMTValue;
                _oDataOutlet.LYYTDValue = oData.LYYTDValue;

                _oDataOutlet.Type = "Outlet";
                _oDatas.Add(_oDataOutlet);

                _oDataTotal.DTDValue = _oDataTotal.DTDValue + oData.DTDValue;
                _oDataTotal.LDValue = _oDataTotal.LDValue + oData.LDValue;
                _oDataTotal.MTDValue = _oDataTotal.MTDValue + oData.MTDValue;
                _oDataTotal.LMValue = _oDataTotal.LMValue + oData.LMValue;
                _oDataTotal.YTDValue = _oDataTotal.YTDValue + oData.YTDValue;
                _oDataTotal.LYValue = _oDataTotal.LYValue + oData.LYValue;
                _oDataTotal.CMTValue = _oDataTotal.CMTValue + oData.CMTValue;
                _oDataTotal.MTDTValue = _oDataTotal.MTDTValue + oData.MTDTValue;
                _oDataTotal.LMTValue = _oDataTotal.LMTValue + oData.LMTValue;
                _oDataTotal.LYYTDValue = _oDataTotal.LYYTDValue + oData.LYYTDValue;

                _oDataArea.DTDValue = _oDataArea.DTDValue + oData.DTDValue;
                _oDataArea.LDValue = _oDataArea.LDValue + oData.LDValue;
                _oDataArea.MTDValue = _oDataArea.MTDValue + oData.MTDValue;
                _oDataArea.LMValue = _oDataArea.LMValue + oData.LMValue;
                _oDataArea.YTDValue = _oDataArea.YTDValue + oData.YTDValue;
                _oDataArea.LYValue = _oDataArea.LYValue + oData.LYValue;
                _oDataArea.CMTValue = _oDataArea.CMTValue + oData.CMTValue;
                _oDataArea.MTDTValue = _oDataArea.MTDTValue + oData.MTDTValue;
                _oDataArea.LMTValue = _oDataArea.LMTValue + oData.LMTValue;
                _oDataArea.LYYTDValue = _oDataArea.LYYTDValue + oData.LYYTDValue;

                _oDataZone.DTDValue = _oDataZone.DTDValue + oData.DTDValue;
                _oDataZone.LDValue = _oDataZone.LDValue + oData.LDValue;
                _oDataZone.MTDValue = _oDataZone.MTDValue + oData.MTDValue;
                _oDataZone.LMValue = _oDataZone.LMValue + oData.LMValue;
                _oDataZone.YTDValue = _oDataZone.YTDValue + oData.YTDValue;
                _oDataZone.LYValue = _oDataZone.LYValue + oData.LYValue;
                _oDataZone.CMTValue = _oDataZone.CMTValue + oData.CMTValue;
                _oDataZone.MTDTValue = _oDataZone.MTDTValue + oData.MTDTValue;
                _oDataZone.LMTValue = _oDataZone.LMTValue + oData.LMTValue;
                _oDataZone.LYYTDValue = _oDataZone.LYYTDValue + oData.LYYTDValue;

            }

            _oData.InsertReportLog(sUser);
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());
  
        }
    }
    public class Data
    {
        public string AreaName;
        public string ZoneName;
        public string Outlet;
        public string Type;

        public double DTDValue;
        public double LDValue;
        public double MTDValue;
        public double LMValue;
        public double YTDValue;
        public double LYValue;

        public double CMTValue;
        public double MTDTValue;
        public double LMTValue;

        public double LYYTDValue;
        public double LYMTDValue;
        public double LYCMValue;


        public string DTDValueText;
        public string LDValueText;
        public string LMValueText;
        public string MTDValueText;
        public string YTDValueText;
        public string LYValueText;

        public string CMTValueText;
        public string MTDTValueText;
        public string LMTValueText;

        public string LYYTDValueText;
        public string LYMTDValueText;
        public string LYCMValueText;

        public string CMPercText;
        public string MTDPercText;
        public string LMPercText;
        public string YTDGthPercText;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10014";
            string sReportName = "TEL-DMS Qty and Value";
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
       
        public void GetData(string sCompany)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select AreaName, TerritoryName, CustomerName, Today, LastDay, CMTarget, MTDTarget, ThisMonth, LastMonthTarget, LastMonth, "+
                   " ThisYear, LastYear, LYYTD, LYMTD, LYCM from DWDB.dbo.t_DMSOutletSales Where Company='" + sCompany + "' Order by AreaSort, TerritorySort, CustomerName";
            try
            {
                Data _oData;
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oData = new Data();
                    _oData.AreaName = reader["AreaName"].ToString();
                    _oData.ZoneName = reader["TerritoryName"].ToString();
                    _oData.Outlet = reader["CustomerName"].ToString();

                    _oData.DTDValue = Convert.ToDouble(reader["Today"]);
                    _oData.LDValue = Convert.ToDouble(reader["LastDay"]);
                    _oData.MTDValue = Convert.ToDouble(reader["ThisMonth"]);
                    _oData.LMValue = Convert.ToDouble(reader["LastMonth"]);
                    _oData.YTDValue = Convert.ToDouble(reader["ThisYear"]);
                    _oData.LYValue = Convert.ToDouble(reader["LastYear"]);

                    _oData.LYYTDValue = Convert.ToDouble(reader["LYYTD"]);
                    _oData.LYMTDValue = Convert.ToDouble(reader["LYMTD"]);
                    _oData.LYCMValue = Convert.ToDouble(reader["LYCM"]);

                    _oData.CMTValue = Convert.ToDouble(reader["CMTarget"]);
                    _oData.MTDTValue = Convert.ToDouble(reader["MTDTarget"]);
                    _oData.LMTValue = Convert.ToDouble(reader["LastMonthTarget"]);


                    InnerList.Add(_oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public List<Data> getResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();

            DateTime dFromDate = DateTime.Now.Date;
            int nThisYear = dFromDate.Year;
            int nThisMonth = dFromDate.Month;

            DateTime LastDayOfMonth = _oTELLib.LastDayofMonth(dFromDate);
            int nLastDayCM = LastDayOfMonth.Day;
            int nDay = dFromDate.Day;

            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.Outlet = oData.Outlet;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;

                _oData.DTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.DTDValue));
                _oData.LDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDValue));
                _oData.MTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDValue));
                _oData.LMValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMValue));
                _oData.YTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue));
                _oData.LYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYValue));
                _oData.CMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMTValue));
                _oData.LMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMTValue));
                _oData.LYYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTDValue));

                double _MTDTarget = 0;
                if (oData.CMTValue > 0)
                {
                    //_MTDTarget = oData.CMTValue / nLastDayCM * nDay;
                    _MTDTarget = oData.MTDTValue;
                    
                    _oData.MTDTValueText = ExcludeDecimal(_oTELLib.TakaFormat(_MTDTarget));
                }
                else
                {
                    _oData.MTDTValueText = "0";
                }


                if (oData.CMTValue > 0)
                {
                    _oData.CMPercText = Convert.ToString(Math.Round((oData.MTDValue / oData.CMTValue) * 100));
                }
                else
                {
                    _oData.CMPercText = "0";
                }
                if (_MTDTarget > 0)
                {
                    _oData.MTDPercText = Convert.ToString(Math.Round((oData.MTDValue / _MTDTarget) * 100));
                }
                else
                {
                    _oData.MTDPercText = "0";
                }
                if (oData.LMTValue > 0)
                {
                    _oData.LMPercText = Convert.ToString(Math.Round((oData.LMValue / oData.LMTValue) * 100));
                }
                else
                {
                    _oData.LMPercText = "0";
                }
                if (oData.LYYTDValue > 0)
                {
                    _oData.YTDGthPercText = Convert.ToString(Math.Round(((oData.YTDValue / oData.LYYTDValue) * 100) - 100));
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


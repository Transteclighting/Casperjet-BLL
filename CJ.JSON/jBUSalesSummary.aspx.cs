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
using System.Data.OleDb;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.ANDROID;
using CJ.Class.Library;

public partial class jBUSalesSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            //string sCompany = c.Request.Form["Company"].Trim();

            //string sUser = "hakim";
            string sCompany = "TEL";


            Data _oData = new Data();
            _oData.InsertReportLog(sUser);

            Datas oDatas = new Datas();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oBUData = new Data();
            int nCount = 0;
            DBController.Instance.OpenNewConnection();
            oDatas.GetData();
            foreach (Data oData in oDatas)
            {
                if (nCount == 0)
                {
                    _oDataTotal = new Data();
                    _oDatas.Add(_oDataTotal);
                    _oDataTotal.Name = "Total";
                    _oDataTotal.Type = "Type1";
                    _oDataTotal.Value = "Success";
                    nCount++;

                }

                _oBUData = new Data();
                _oBUData.Value = "Success";

                _oBUData.Name = oData.Name;
                _oBUData.DTDValue = oData.DTDValue;
                _oBUData.LDValue = oData.LDValue;
                _oBUData.MTDValue = oData.MTDValue;
                _oBUData.LMValue = oData.LMValue;
                _oBUData.YTDValue = oData.YTDValue;
                _oBUData.LYValue = oData.LYValue;
                _oBUData.CMTValue = oData.CMTValue;
                _oBUData.MTDTValue = oData.MTDTValue;
                _oBUData.LMTValue = oData.LMTValue;
                _oBUData.LYYTDValue = oData.LYYTDValue;
                _oBUData.YBLYValue = oData.YBLYValue;

                _oBUData.Type = "Type2";
                _oDatas.Add(_oBUData);

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
                _oDataTotal.YBLYValue = _oDataTotal.YBLYValue + oData.YBLYValue;

            }

            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());
            DBController.Instance.CloseConnection();
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
        public string Name;
        public string Type;

        public double DTDValue;
        public double LDValue;
        public double MTDValue;
        public double LMValue;
        public double YTDValue;
        public double LYValue;
        public double YBLYValue;

        public double CMTValue;
        public double MTDTValue;
        public double LMTValue;

        public double LYYTDValue;
        public double LYMTDValue;
        public double LYCMValue;

        public string DTDText;
        public string LDText;
        public string LMText;
        public string MTDText;
        public string YTDText;
        public string LYText;
        public string LYYTDText;

        public string LMTarText;
        public string LMPercText;
        public string CMTarText;
        public string CMPercText;
        public string MTDTarText;
        public string MTDPercText;
        public string YTDGthPercText;
        public string YBLYGthPercText;

        //public double CMTarget;
        //public double MTDTarget;
        //public double LMTarget;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10047";
            string sReportName = "BU wise Sales Summary";
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

        double LMTarget = 0;
        double CMTarget = 0;
        double MTDTarget = 0;
        double LMSales = 0;
        double MTDSales = 0;
        double _YTD = 0;
        double _LYYTD = 0;
        double _YBLY = 0;
        double _LY = 0;

        public void GetData()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = "Select ID, BUName, Today, LastDay, CMTarget, MTDTarget, ThisMonth, LMTarget, " +
                    "LastMonth, ThisYear, LYYTD, LastYear, YBLY, Sort from DWDB.[dbo].[t_BUWiseSales] Order by Sort";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oData = new Data();
                    _oData.Name = (string)reader["BUName"];
                    //_oData.Type = "Type2";
                    _oData.DTDValue = Convert.ToDouble(reader["Today"]);
                    _oData.LDValue = Convert.ToDouble(reader["LastDay"]);
                    _oData.MTDValue = Convert.ToDouble(reader["ThisMonth"]);
                    _oData.LMValue = Convert.ToDouble(reader["LastMonth"]);
                    _oData.YTDValue = Convert.ToDouble(reader["ThisYear"]);
                    _oData.LYValue = Convert.ToDouble(reader["LastYear"]);

                    _oData.LYYTDValue = Convert.ToDouble(reader["LYYTD"]);
                    //_oData.LYMTDValue = Convert.ToDouble(reader["LYMTD"]);
                    _oData.YBLYValue = Convert.ToDouble(reader["YBLY"]);

                    _oData.CMTValue = Convert.ToDouble(reader["CMTarget"]);
                    _oData.MTDTValue = Convert.ToDouble(reader["MTDTarget"]);
                    _oData.LMTValue = Convert.ToDouble(reader["LMTarget"]);

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
            List<Data> eList = new List<Data>();
            TELLib _oTELLib = new TELLib();
            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.Name = oData.Name;
                _oData.Type = oData.Type;
                _oData.DTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.DTDValue));
                _oData.LDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDValue));
                _oData.CMTarText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMTValue)); 
                _oData.MTDTarText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDTValue)); 
                _oData.MTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDValue));

                if (oData.CMTValue > 0)
                    _oData.CMPercText = Convert.ToString(Math.Round((oData.MTDValue / oData.CMTValue) * 100));
                else 
                    _oData.CMPercText = "0";

                if (oData.MTDTValue > 0)
                    _oData.MTDPercText = Convert.ToString(Math.Round((oData.MTDValue / oData.MTDTValue) * 100));
                else
                    _oData.MTDPercText = "0";

                if (oData.LMTValue > 0)
                    _oData.LMPercText = Convert.ToString(Math.Round((oData.LMValue / oData.LMTValue) * 100));
                else
                    _oData.LMPercText = "0";

               

                _oData.LMTarText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMTValue)); 
                _oData.LMText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMValue)); 

               
                _oData.YTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue)); 
                _oData.LYYTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTDValue)); 
                _oData.LYText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYValue));

                if (oData.LYYTDValue > 0)
                    _oData.YTDGthPercText = Convert.ToString(Math.Round(((oData.YTDValue / oData.LYYTDValue) * 100) - 100));
                else
                    _oData.YTDGthPercText = "0";

                if (oData.YBLYValue > 0)
                    _oData.YBLYGthPercText = Convert.ToString(Math.Round(((oData.LYValue / oData.YBLYValue) * 100) - 100));
                else
                    _oData.YBLYGthPercText = "0";

                _oData.Value = "Success";
                eList.Add(_oData);
            }


            return eList;

        }

    }
}

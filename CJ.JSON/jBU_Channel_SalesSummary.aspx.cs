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

public partial class jBU_Channel_SalesSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();

            //string sUser = "hakim";

            Data _oData = new Data();
            _oData.InsertReportLog(sUser);

            Datas oDatas = new Datas();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oBUData = new Data();

            DSBUChannelSalesSummary _oDSDSBUChannelSalesSummary = new DSBUChannelSalesSummary();
            DBController.Instance.OpenNewConnection();
            
            _oDSDSBUChannelSalesSummary = oDatas.ReorganizeData(sUser);

            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(_oDSDSBUChannelSalesSummary), Formatting.Indented);
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
        public string Parent;

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

        public DSBUChannelSalesSummary GetData(string sUser)
        {
            DSBUChannelSalesSummary oDSDSBUChannelSalesSummary = new DSBUChannelSalesSummary();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = " Select * from (Select 'Total' as Type, 'Total' as Description, NULL as ParentName, Sum(Today)Today, Sum(LastDay)LastDay, Sum(CMTarget)CMTarget, " +
                   " Sum(MTDTarget)MTDTarget, Sum(ThisMonth)ThisMonth, Sum(LMTarget)LMTarget, Sum(LastMonth)LastMonth, Sum(ThisYear)ThisYear,  " +
                   " Sum(LYYTD)LYYTD, Sum(LastYear)LastYear, Sum(YBLY)YBLY, 0 as Sort, 1 as Priority from DWDB.DBO.t_BUWiseSalesNew a, " +
                   " (Select SBUName as BU from t_SBU a where a.SBUID IN(Select value from fn_split((select UserSBUs from t_User Where UserName = '" + sUser + "'),',')) )b " +
                   " Where Type = 'BU' and a.Description = b.BU " +
                   " UNION ALL " +
                   " Select Type, Description, ParentName, Today, LastDay, CMTarget, MTDTarget, ThisMonth, LMTarget, " +
                   " LastMonth, ThisYear, LYYTD, LastYear, YBLY, Sort, 2 as Priority from DWDB.DBO.t_BUWiseSalesNew a, " +
                   " (Select SBUName as BU from t_SBU a where a.SBUID IN(Select value from fn_split((select UserSBUs from t_User Where UserName = '" + sUser + "'),',')))b " +
                   " Where Type = 'BU' and a.Description = b.BU " +
                   " UNION ALL " +
                   " Select Type, Description, ParentName, Today, LastDay, CMTarget, MTDTarget, ThisMonth, LMTarget, " +
                   " LastMonth, ThisYear, LYYTD, LastYear, YBLY, Sort, 3 as Priority from DWDB.DBO.t_BUWiseSalesNew Where Type != 'BU') final where ThisYear+LastYear>0 Order by Priority, Sort ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBUChannelSalesSummary.BUChannelSalesSummaryRow oBUChannelSalesSummaryRow = oDSDSBUChannelSalesSummary.BUChannelSalesSummary.NewBUChannelSalesSummaryRow();

                    oBUChannelSalesSummaryRow.Type = (string)reader["Type"];
                    oBUChannelSalesSummaryRow.Description = reader["Description"].ToString().Trim();
                    if (reader["ParentName"] == DBNull.Value)
                    {
                        oBUChannelSalesSummaryRow.ParentName = "";
                    }
                    else
                    {
                        oBUChannelSalesSummaryRow.ParentName = (string)reader["ParentName"];
                    }
                    
                    oBUChannelSalesSummaryRow.Today = Convert.ToDouble(reader["Today"]);
                    oBUChannelSalesSummaryRow.LastDay = Convert.ToDouble(reader["LastDay"]);
                    oBUChannelSalesSummaryRow.ThisMonth = Convert.ToDouble(reader["ThisMonth"]);
                    oBUChannelSalesSummaryRow.LastMonth = Convert.ToDouble(reader["LastMonth"]);
                    oBUChannelSalesSummaryRow.ThisYear = Convert.ToDouble(reader["ThisYear"]);
                    oBUChannelSalesSummaryRow.LastYear = Convert.ToDouble(reader["LastYear"]);
                    oBUChannelSalesSummaryRow.LYYTD = Convert.ToDouble(reader["LYYTD"]);
                    oBUChannelSalesSummaryRow.YBLY = Convert.ToDouble(reader["YBLY"]);
                    oBUChannelSalesSummaryRow.CMTarget = Convert.ToDouble(reader["CMTarget"]);
                    oBUChannelSalesSummaryRow.MTDTarget = Convert.ToDouble(reader["MTDTarget"]);
                    oBUChannelSalesSummaryRow.LMTarget = Convert.ToDouble(reader["LMTarget"]);

                    oDSDSBUChannelSalesSummary.BUChannelSalesSummary.AddBUChannelSalesSummaryRow(oBUChannelSalesSummaryRow);
                    oDSDSBUChannelSalesSummary.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSDSBUChannelSalesSummary;
        }

        public DSBUChannelSalesSummary ReorganizeData(string sUser)
        {

            DSBUChannelSalesSummary oDSRawData = new DSBUChannelSalesSummary();
            oDSRawData = GetData(sUser);

            //Get Total
            DSBUChannelSalesSummary oDSData = new DSBUChannelSalesSummary();
            DataRow[] oDRTotal = oDSRawData.BUChannelSalesSummary.Select(" Type= 'Total'");
            oDSData.Merge(oDRTotal);
            oDSData.AcceptChanges();


            //Get BU
            DSBUChannelSalesSummary oDSBU = new DSBUChannelSalesSummary();
            DataRow[] oDRBU = oDSRawData.BUChannelSalesSummary.Select(" Type= 'BU'");
            oDSBU.Merge(oDRBU);
            oDSBU.AcceptChanges();
            foreach (DSBUChannelSalesSummary.BUChannelSalesSummaryRow oDSBURow in oDSBU.BUChannelSalesSummary)
            {
                DataRow[] oDRSelectedBURow = oDSRawData.BUChannelSalesSummary.Select(" Description = '" + oDSBURow.Description + "' and Type= 'BU'");
                oDSData.Merge(oDRSelectedBURow);
                oDSData.AcceptChanges();

                //Get Channel
                DSBUChannelSalesSummary oDSChannel = new DSBUChannelSalesSummary();
                DataRow[] oDRChannelRow = oDSRawData.BUChannelSalesSummary.Select(" Type= 'Channel' and ParentName='" + oDSBURow.Description + "'");
                oDSChannel.Merge(oDRChannelRow);
                oDSChannel.AcceptChanges();

                foreach (DSBUChannelSalesSummary.BUChannelSalesSummaryRow oDSChannelRow in oDSChannel.BUChannelSalesSummary)
                {

                    DataRow[] oDRSelectedChannelRow = oDSRawData.BUChannelSalesSummary.Select(" Type= 'Channel' and Description = '" + oDSChannelRow.Description + "' and ParentName = '" + oDSChannelRow.ParentName + "'");
                    oDSData.Merge(oDRSelectedChannelRow);
                    oDSData.AcceptChanges();

                    //Get Customer Type
                    DSBUChannelSalesSummary oDSCustomerType = new DSBUChannelSalesSummary();
                    DataRow[] oDRCustomerTypeRow = oDSRawData.BUChannelSalesSummary.Select(" Type= 'CustomerType' and ParentName = '" + oDSChannelRow.Description + "' ");
                    oDSCustomerType.Merge(oDRCustomerTypeRow);
                    oDSCustomerType.AcceptChanges();

                    oDSData.Merge(oDSCustomerType);
                    oDSData.AcceptChanges();
                }

            }
            return oDSData;



        }
        public List<Data> getResult(DSBUChannelSalesSummary oDSDSBUChannelSalesSummary)
        {
            Data _oData;
            List<Data> eList = new List<Data>();
            TELLib _oTELLib = new TELLib();
            foreach (DSBUChannelSalesSummary.BUChannelSalesSummaryRow oDSBURow in oDSDSBUChannelSalesSummary.BUChannelSalesSummary)
            {
                _oData = new Data();
                _oData.Name = oDSBURow.Description;
                _oData.Parent = oDSBURow.ParentName;
                _oData.Type = oDSBURow.Type;
                _oData.DTDText = ExcludeDecimal(_oTELLib.TakaFormat(oDSBURow.Today));
                _oData.LDText = ExcludeDecimal(_oTELLib.TakaFormat(oDSBURow.LastDay));
                _oData.CMTarText = ExcludeDecimal(_oTELLib.TakaFormat(oDSBURow.CMTarget)); 
                _oData.MTDTarText = ExcludeDecimal(_oTELLib.TakaFormat(oDSBURow.MTDTarget)); 
                _oData.MTDText = ExcludeDecimal(_oTELLib.TakaFormat(oDSBURow.ThisMonth));

                if (oDSBURow.CMTarget > 0)
                    _oData.CMPercText = Convert.ToString(Math.Round((oDSBURow.ThisMonth / oDSBURow.CMTarget) * 100));
                else 
                    _oData.CMPercText = "0";

                if (oDSBURow.MTDTarget > 0)
                    _oData.MTDPercText = Convert.ToString(Math.Round((oDSBURow.ThisMonth / oDSBURow.MTDTarget) * 100));
                else
                    _oData.MTDPercText = "0";

                if (oDSBURow.LMTarget > 0)
                    _oData.LMPercText = Convert.ToString(Math.Round((oDSBURow.LastMonth / oDSBURow.LMTarget) * 100));
                else
                    _oData.LMPercText = "0";

                _oData.LMTarText = ExcludeDecimal(_oTELLib.TakaFormat(oDSBURow.LMTarget)); 
                _oData.LMText = ExcludeDecimal(_oTELLib.TakaFormat(oDSBURow.LastMonth)); 
               
                _oData.YTDText = ExcludeDecimal(_oTELLib.TakaFormat(oDSBURow.ThisYear)); 
                _oData.LYYTDText = ExcludeDecimal(_oTELLib.TakaFormat(oDSBURow.LYYTD)); 
                _oData.LYText = ExcludeDecimal(_oTELLib.TakaFormat(oDSBURow.LastYear));

                if (oDSBURow.LYYTD > 0)
                    _oData.YTDGthPercText = Convert.ToString(Math.Round(((oDSBURow.ThisYear / oDSBURow.LYYTD) * 100) - 100));
                else
                    _oData.YTDGthPercText = "0";

                if (oDSBURow.YBLY > 0)
                    _oData.YBLYGthPercText = Convert.ToString(Math.Round(((oDSBURow.LastYear / oDSBURow.YBLY) * 100) - 100));
                else
                    _oData.YBLYGthPercText = "0";

                _oData.Value = "Success";
                eList.Add(_oData);
            }

            return eList;

        }

    }
}

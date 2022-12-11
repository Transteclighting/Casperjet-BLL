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

public partial class BLLChannelSalesRevised : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            //string sUser = c.Request.Form["UserName"].Trim();
            string sUser = "hakim";


            Datas oDatas = new Datas();

            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataNational = new Data();
            Data _oDataChannel = new Data();
            Data _oDataArea = new Data();
            Data _oDataTerritory = new Data();
            Data _oDataRegionName = new Data();

            int nCount = 0;

            DBController.Instance.OpenNewConnection();
            //oDatas.GetData();
            DBController.Instance.CloseConnection();

            foreach (Data oData in oDatas)
            {
                if (nCount == 0)
                {
                    _oDataNational = new Data();
                    _oDatas.Add(_oDataNational);
                    _oDataNational.ChannelName = "National";
                    _oDataNational.Type = "National";
                    _oDataNational.Value = "Success";
                    nCount++;
                }
                if (_oDataChannel.Channel != oData.Channel)
                {
                    _oDataChannel = new Data();
                    _oDatas.Add(_oDataChannel);
                    _oDataChannel.Channel = oData.Channel;
                    _oDataChannel.ChannelName = oData.Channel;
                    _oDataChannel.Type = "Channel";
                    _oDataChannel.Value = "Success";
                }

                //if (_oDataRegionName.RegionName != oData.RegionName)
                //{
                //    _oDataRegionName = new Data();
                //    _oDatas.Add(_oDataRegionName);
                //    _oDataRegionName.RegionName = oData.RegionName;
                //    _oDataRegionName.ChannelName = oData.RegionName;
                //    _oDataRegionName.Type = "RegionName";
                //    _oDataRegionName.Value = "Success";

                //}

                if (_oDataArea.AreaName != oData.AreaName)
                {
                    _oDataArea = new Data();
                    _oDatas.Add(_oDataArea);
                    _oDataArea.AreaName = oData.AreaName;
                    _oDataArea.ChannelName = oData.AreaName;
                    _oDataArea.Type = "Area";
                    _oDataArea.Value = "Success";
                }

                _oDataTerritory = new Data();
                _oDataTerritory.ChannelName = oData.TerritoryName;
                _oDataTerritory.Type = "Territory";
                _oDataTerritory.Value = "Success";

                _oDataTerritory.CMSTValue = oData.CMSTValue;
                _oDataTerritory.LMTValue = oData.LMTValue;

                _oDataTerritory.TodayValue = oData.TodayValue;
                _oDataTerritory.LDValue = oData.LDValue;
                _oDataTerritory.YTDValue = oData.YTDValue;

                _oDataTerritory.CMSAMTDValue = oData.CMSAMTDValue;
                _oDataTerritory.LMSAMTDValue = oData.LMSAMTDValue;
                _oDataTerritory.LMSAValue = oData.LMSAValue;
                _oDataTerritory.LYSAValue = oData.LYSAValue;
                _oDataTerritory.LYCMSAMTDValue = oData.LYCMSAMTDValue;

                _oDataTerritory.LYYTDSAValue = oData.LYYTDSAValue;

                _oDatas.Add(_oDataTerritory);

                _oDataNational.CMSTValue = _oDataNational.CMSTValue + oData.CMSTValue;
                _oDataNational.LMTValue = _oDataNational.LMTValue + oData.LMTValue;
                _oDataNational.TodayValue = _oDataNational.TodayValue + oData.TodayValue;
                _oDataNational.LDValue = _oDataNational.LDValue + oData.LDValue;
                _oDataNational.YTDValue = _oDataNational.YTDValue + oData.YTDValue;
                _oDataNational.CMSAMTDValue = _oDataNational.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataNational.LMSAMTDValue = _oDataNational.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataNational.LMSAValue = _oDataNational.LMSAValue + oData.LMSAValue;
                _oDataNational.LYSAValue = _oDataNational.LYSAValue + oData.LYSAValue;
                _oDataNational.LYCMSAMTDValue = _oDataNational.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                _oDataNational.LYYTDSAValue = _oDataNational.LYYTDSAValue + oData.LYYTDSAValue;

                _oDataChannel.CMSTValue = _oDataChannel.CMSTValue + oData.CMSTValue;
                _oDataChannel.LMTValue = _oDataChannel.LMTValue + oData.LMTValue;
                _oDataChannel.TodayValue = _oDataChannel.TodayValue + oData.TodayValue;
                _oDataChannel.LDValue = _oDataChannel.LDValue + oData.LDValue;
                _oDataChannel.YTDValue = _oDataChannel.YTDValue + oData.YTDValue;
                _oDataChannel.CMSAMTDValue = _oDataChannel.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataChannel.LMSAMTDValue = _oDataChannel.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataChannel.LMSAValue = _oDataChannel.LMSAValue + oData.LMSAValue;
                _oDataChannel.LYSAValue = _oDataChannel.LYSAValue + oData.LYSAValue;
                _oDataChannel.LYCMSAMTDValue = _oDataChannel.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                _oDataChannel.LYYTDSAValue = _oDataChannel.LYYTDSAValue + oData.LYYTDSAValue;

                _oDataArea.CMSTValue = _oDataArea.CMSTValue + oData.CMSTValue;
                _oDataArea.LMTValue = _oDataArea.LMTValue + oData.LMTValue;
                _oDataArea.TodayValue = _oDataArea.TodayValue + oData.TodayValue;
                _oDataArea.LDValue = _oDataArea.LDValue + oData.LDValue;
                _oDataArea.YTDValue = _oDataArea.YTDValue + oData.YTDValue;
                _oDataArea.CMSAMTDValue = _oDataArea.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataArea.LMSAMTDValue = _oDataArea.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataArea.LMSAValue = _oDataArea.LMSAValue + oData.LMSAValue;
                _oDataArea.LYSAValue = _oDataArea.LYSAValue + oData.LYSAValue;
                _oDataArea.LYCMSAMTDValue = _oDataArea.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                _oDataArea.LYYTDSAValue = _oDataArea.LYYTDSAValue + oData.LYYTDSAValue;

            }
            _oData.InsertReportLog(sUser);
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());

        }
    }
    public class Data
    {

        public string AreaName;
        public string TerritoryName;
        public string ChannelName;
        public string Channel;
        public string Type;
        public string Value;
        public string RegionName;



        public double TodayValue;
        public double LDValue;
        public double LMValue;
        public double YTDValue;
        public double LYValue;
        public double LMTValue;

        public double CMSTValue;
        public double CMSAMTDValue;
        public double LMSAMTDValue;
        public double LMSAValue;
        public double LYSAValue;
        public double LYCMSAMTDValue;
        public double LYYTDSAValue;



        public string TodayValueText;
        public string LDValueText;
        public string YTDValueText;
        public string LYValueText;
        public string LMTValueText;

        public string CMSTValueText;
        public string CMSAMTDValueText;
        public string LMSAMTDValueText;
        public string LMSAValueText;
        public string LYCMSAMTDValueText;
        public string LYYTDSAValueText;

        public string GSCMMTDPercText;
        public string GSLMMTDPercText;
        public string GSLMFullPercText;
        public string GSLYCMMTDPercText;

        public string MTDTargetText;
        public string MTDPercentText;
        public string YTDGthPercText;




        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10036";
            string sReportName = "BLL-Channel Sales";
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

        //public void GetData(string sCompany, int nYear, string sMonth)
        //{

        //    string sSQL = "";
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    sSQL = " Select TranMonth, MonthName, WarehouseCode,Zone, Area, TotalNOC, " +
        //           " OldCustNOC, NewCustNOC,TotalVal, OldCustVal, NewCustVal " +
        //           " from  " +
        //           " ( " +
        //           " Select TranMonth, MonthName, WarehouseCode,  " +
        //           " SUM(TotalNOC) as TotalNOC, SUM(OldCustNOC) as OldCustNOC, SUM(NewCustNOC) as NewCustNOC, " +
        //           " SUM(TotalVal) as TotalVal, SUM(OldCustVal) as OldCustVal, SUM(NewCustVal) as NewCustVal " +
        //           " from  " +
        //           " ( " +
        //           " Select TranMonth, CASE When TranMonth = 1 then 'Jan' When TranMonth = 2 then 'Feb' " +
        //           " When TranMonth = 3 then 'Mar' When TranMonth = 4 then 'Apr' " +
        //           " When TranMonth = 5 then 'May' When TranMonth = 6 then 'Jun' " +
        //           " When TranMonth = 7 then 'Jul' When TranMonth = 8 then 'Aug' " +
        //           " When TranMonth = 9 then 'Sep' When TranMonth = 10 then 'Oct' " +
        //           " When TranMonth = 11 then 'Nov' When TranMonth = 12 then 'Dec' end as MonthName, " +
        //           " WarehouseCode, (OldCustNOC + NewCustNOC) as TotalNOC, OldCustNOC, NewCustNOC,  " +
        //           " (OldCustVal + NewCustVal) as TotalVal, OldCustVal, NewCustVal  " +
        //           " from DWDB.dbo.t_RetailCustomerSumm WHERE TranYear=" + nYear + " and Company='" + sCompany + "'  " +
        //           " ) x Group by TranMonth, MonthName, WarehouseCode " +
        //           " )a, " +
        //           " (Select ShowroomCode, Zone, Area from TELSysDB.dbo.t_Showroom a,   " +
        //           " (select CustomerID, TerritoryShortName as Zone,  " +
        //           " AreaShortName as Area from DWDB.dbo.t_CustomerDetails Where CompanyName='TEL' and CustomerTypeID=5)b " +//Shouldn't Change Company Name TEL because both TEL, TML share Market group from TEL. - Hakim
        //           " Where a.CustomerID=b.CustomerID and IsPOSActive=1)b  " +
        //           " Where a.WarehouseCode=b.ShowroomCode and MonthName='" + sMonth + "' " +
        //           " Order by Area, Zone, WarehouseCode ";

        //    try
        //    {
        //        cmd.CommandText = sSQL;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Data _oData = new Data();

        //            _oData.Outlet = (string)reader["WarehouseCode"];
        //            _oData.TerritoryName = (string)reader["Zone"];
        //            _oData.AreaName = (string)reader["Area"];

        //            _oData.TotalNOC = Convert.ToInt32(reader["TotalNOC"]);
        //            _oData.OldNOC = Convert.ToInt32(reader["OldCustNOC"]);
        //            _oData.NewNOC = Convert.ToInt32(reader["NewCustNOC"]);

        //            _oData.TotalVal = Convert.ToDouble(reader["TotalVal"]);
        //            _oData.OldVal = Convert.ToDouble(reader["OldCustVal"]);
        //            _oData.NewVal = Convert.ToDouble(reader["NewCustVal"]);

        //            InnerList.Add(_oData);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }



        //}
        public List<Data> getResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            DateTime dFromDate = DateTime.Now;

            DateTime LastDayOfMonth = _oTELLib.LastDayofMonth(dFromDate);
            int nLastDayCM = LastDayOfMonth.Day;
            int nDay = dFromDate.Day;

            foreach (Data oData in this)
            {

                _oData = new Data();
                _oData.ChannelName = oData.ChannelName;

                _oData.Type = oData.Type;
                _oData.Value = oData.Value;


                _oData.CMSTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSTValue));
                _oData.LMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMTValue));

                _oData.TodayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TodayValue));
                _oData.LDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDValue));
                _oData.YTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue));

                _oData.CMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSAMTDValue));
                _oData.LMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMSAMTDValue));
                _oData.LMSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMSAValue));
                _oData.LYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYSAValue));
                _oData.LYCMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYCMSAMTDValue));

                _oData.LYYTDSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTDSAValue));

                double _MTDTarget = 0;
                //Performance

                if (oData.CMSTValue > 0)
                {
                    _oData.GSCMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue / oData.CMSTValue) * 100));
                    _MTDTarget = oData.CMSTValue / nLastDayCM * nDay;
                    _oData.MTDTargetText = ExcludeDecimal(_oTELLib.TakaFormat(_MTDTarget));
                    _oData.MTDPercentText = Convert.ToString(Math.Round((oData.CMSAMTDValue / _MTDTarget) * 100));
                }
                else
                {
                    _oData.GSCMMTDPercText = "0";
                    _oData.MTDTargetText = "0";
                    _oData.MTDPercentText = "0";
                }

                if (oData.LMSAMTDValue > 0)
                {
                    _oData.GSLMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue - oData.LMSAMTDValue) / oData.LMSAMTDValue * 100));
                }
                else
                {
                    _oData.GSLMMTDPercText = "0";
                }

                if (oData.LMTValue > 0)
                {
                    _oData.GSLMFullPercText = Convert.ToString(Math.Round((oData.LMSAValue / oData.LMTValue) * 100));
                }
                else
                {
                    _oData.GSLMFullPercText = "0";
                }
                if (oData.LYCMSAMTDValue > 0)
                {
                    _oData.GSLYCMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue - oData.LYCMSAMTDValue) / oData.LYCMSAMTDValue * 100));
                }
                else
                {
                    _oData.GSLYCMMTDPercText = "0";
                }

                if (oData.LYYTDSAValue > 0)
                {
                    _oData.YTDGthPercText = Convert.ToString(Math.Round((oData.YTDValue - oData.LYYTDSAValue) / oData.LYYTDSAValue * 100));
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



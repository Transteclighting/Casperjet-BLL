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

public partial class BLLChannelSalesNew : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            //string sUser = "hrashid";


            Datas oDatas = new Datas();
             
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataNational = new Data();
            Data _oDataChannel = new Data();
            Data _oDataArea = new Data();
            Data _oDataTerritory = new Data();
            Data _oDataRegionName = new Data();


            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
           
            //oDatas.GetData();
                    
            _oData.InsertReportLog(sUser);
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());

            DBController.Instance.CloseConnection();

        }
    }
    public class Data
    {

        public string Channel;
        public string Type;
        public string Name;

        public string TodayValueText;
        public string LDValueText;
        public string CMTValueText;
        public string MTDTValueText;
        public string MTDValueText;
        public string LMTValueText;
        public string LMValueText;
        public string YTDValueText;
        public string LYYTDValueText;
        public string LYValueText;
        public string LMMTDValueText;

        public string CMPercentText;
        public string MTDPercentText;
        public string LMPercentText;
        public string YTDGthPercText;
        public string MTDGthPercText;


        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10036";
            string sReportName = "BLL-Channel Pri Sales";
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
        public DSBLLChannelSales GetData()
        {
            TELLib _oTELLib = new TELLib();


            DSBLLChannelSales oDSRawData = new DSBLLChannelSales();

            oDSRawData = GetRawData();

            //Get Total
            DSBLLChannelSales oDSData = new DSBLLChannelSales();
            DataRow[] oDRTotal = oDSRawData.BLLChannelSales.Select(" Type= 'All'");
            oDSData.Merge(oDRTotal);
            oDSData.AcceptChanges();


            //Get Region
            DSBLLChannelSales oDSRegion = new DSBLLChannelSales();
            DataRow[] oDRRegion = oDSRawData.BLLChannelSales.Select(" Type= 'Region'");
            oDSRegion.Merge(oDRRegion);
            oDSRegion.AcceptChanges();
            foreach (DSBLLChannelSales.BLLChannelSalesRow oDSRegionRow in oDSRegion.BLLChannelSales)
            {
                DataRow[] oDRSelectedRegionRow = oDSRawData.BLLChannelSales.Select(" Channel = '" + oDSRegionRow.Channel + "' and Type= 'Region' and Id='" + oDSRegionRow.Id + "' ");
                oDSData.Merge(oDRSelectedRegionRow);
                oDSData.AcceptChanges();

                //Get Area
                DSBLLChannelSales oDSArea = new DSBLLChannelSales();
                DataRow[] oDRAreaRow = oDSRawData.BLLChannelSales.Select(" Channel = '" + oDSRegionRow.Channel + "' and Type= 'Area' and ParentId='" + oDSRegionRow.Id + "' ");
                oDSArea.Merge(oDRAreaRow);
                oDSArea.AcceptChanges();

                foreach (DSBLLChannelSales.BLLChannelSalesRow oDSAreaRow in oDSArea.BLLChannelSales)
                {

                    DataRow[] oDRSelectedAreaRow = oDSRawData.BLLChannelSales.Select(" Channel = '" + oDSAreaRow.Channel + "' and Type= 'Area' and Id='" + oDSAreaRow.Id + "' ");
                    oDSData.Merge(oDRSelectedAreaRow);
                    oDSData.AcceptChanges();

                    //Get Territory
                    DSBLLChannelSales oDSTerritory = new DSBLLChannelSales();
                    DataRow[] oDRTerritoryRow = oDSRawData.BLLChannelSales.Select(" Channel = '" + oDSAreaRow.Channel + "' and Type= 'Territory' and ParentId='" + oDSAreaRow.Id + "' ");
                    oDSTerritory.Merge(oDRTerritoryRow);
                    oDSTerritory.AcceptChanges();

                    oDSData.Merge(oDSTerritory);
                    oDSData.AcceptChanges();
                }

            }
            return oDSData;



        }
        
        public DSBLLChannelSales GetRawData()
        {
            DSBLLChannelSales oDSBLLChannelSales = new DSBLLChannelSales();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

                cmd = DBController.Instance.GetCommand();

                sSQL = @" Select * from 
                (
                Select 0 as Id, 'All' as Channel, 'All' as Type, 1 as TypeId, 'Total' as Name, 0 as ParentId, 0 as Sort,
                Sum(TD_Amount) as TD_Amount, Sum(LastDay_Amount) as LastDay_Amount, Sum(FullTarget) as FullTarget,
                Sum(MTD_Target) as MTD_Target, Sum(MTD_Amount) as MTD_Amount, Sum(LM_Target) as LM_Target,
                Sum(LM_Amount) as LM_Amount, Sum(YTD_Amount) as YTD_Amount, Sum(LY_YTD) as LY_YTD, Sum(LYFUll_Amount) as LYFUll_Amount,
                sum(LM_MTD) as LM_MTD
                from dWDB.[dbo].[t_ChannelSales]

                UNION ALL

                Select 0 as Id, ChannelType as Channel, 'All' as Type, 1 as TypeId, 'Total' as Name, 0 as ParentId, 0 as Sort,
                Sum(TD_Amount) as TD_Amount, Sum(LastDay_Amount) as LastDay_Amount, Sum(FullTarget) as FullTarget,
                Sum(MTD_Target) as MTD_Target, Sum(MTD_Amount) as MTD_Amount, Sum(LM_Target) as LM_Target,
                Sum(LM_Amount) as LM_Amount, Sum(YTD_Amount) as YTD_Amount, Sum(LY_YTD) as LY_YTD, Sum(LYFUll_Amount) as LYFUll_Amount,
                sum(LM_MTD) as LM_MTD
                from dWDB.[dbo].[t_ChannelSales] group by ChannelType

                UNION ALL

                Select  RegionId as Id, 'All' as Channel, 'Region' as Type, 2 as TypeId, RegionName as Name, Case When ChannelType = 'GTM' then 1 else 2 end as ParentId, RegionSort as Sort,
                Sum(TD_Amount) as TD_Amount, Sum(LastDay_Amount) as LastDay_Amount, Sum(FullTarget) as FullTarget,
                Sum(MTD_Target) as MTD_Target, Sum(MTD_Amount) as MTD_Amount, Sum(LM_Target) as LM_Target,
                Sum(LM_Amount) as LM_Amount, Sum(YTD_Amount) as YTD_Amount, Sum(LY_YTD) as LY_YTD, Sum(LYFUll_Amount) as LYFUll_Amount,
                sum(LM_MTD) as LM_MTD
                from dWDB.[dbo].[t_ChannelSales] group by RegionId, ChannelType, RegionName, ChannelType, RegionSort
                UNION ALL
                Select  RegionId as Id, ChannelType as Channel, 'Region' as Type, 2 as TypeId, RegionName as Name, Case When ChannelType = 'GTM' then 1 else 2 end as ParentId, RegionSort as Sort,
                Sum(TD_Amount) as TD_Amount, Sum(LastDay_Amount) as LastDay_Amount, Sum(FullTarget) as FullTarget,
                Sum(MTD_Target) as MTD_Target, Sum(MTD_Amount) as MTD_Amount, Sum(LM_Target) as LM_Target,
                Sum(LM_Amount) as LM_Amount, Sum(YTD_Amount) as YTD_Amount, Sum(LY_YTD) as LY_YTD, Sum(LYFUll_Amount) as LYFUll_Amount,
                sum(LM_MTD) as LM_MTD
                from dWDB.[dbo].[t_ChannelSales] group by RegionId, ChannelType, RegionName, ChannelType, RegionSort

                UNION ALL
                Select AreaId as Id, 'All' as Channel, 'Area' as Type, 3 as TypeId, AreaName as Name, RegionId as ParentId, AreaSort as Sort,
                Sum(TD_Amount) as TD_Amount, Sum(LastDay_Amount) as LastDay_Amount, Sum(FullTarget) as FullTarget,
                Sum(MTD_Target) as MTD_Target, Sum(MTD_Amount) as MTD_Amount, Sum(LM_Target) as LM_Target,
                Sum(LM_Amount) as LM_Amount, Sum(YTD_Amount) as YTD_Amount, Sum(LY_YTD) as LY_YTD, Sum(LYFUll_Amount) as LYFUll_Amount,
                sum(LM_MTD) as LM_MTD
                from dWDB.[dbo].[t_ChannelSales] group by AreaId, ChannelType, AreaName, RegionId, AreaSort
                UNION ALL
                Select AreaId as Id, ChannelType as Channel, 'Area' as Type, 3 as TypeId, AreaName as Name, RegionId as ParentId, AreaSort as Sort,
                Sum(TD_Amount) as TD_Amount, Sum(LastDay_Amount) as LastDay_Amount, Sum(FullTarget) as FullTarget,
                Sum(MTD_Target) as MTD_Target, Sum(MTD_Amount) as MTD_Amount, Sum(LM_Target) as LM_Target,
                Sum(LM_Amount) as LM_Amount, Sum(YTD_Amount) as YTD_Amount, Sum(LY_YTD) as LY_YTD, Sum(LYFUll_Amount) as LYFUll_Amount,
                sum(LM_MTD) as LM_MTD
                from dWDB.[dbo].[t_ChannelSales] group by AreaId, ChannelType, AreaName, RegionId, AreaSort

                UNION ALL

                Select TerritoryId as Id, 'All' as Channel, 'Territory' as Type, 4 as TypeId, TerritoryName as Name, AreaId as ParentId, TerritorySort as Sort,
                Sum(TD_Amount) as TD_Amount, Sum(LastDay_Amount) as LastDay_Amount, Sum(FullTarget) as FullTarget,
                Sum(MTD_Target) as MTD_Target, Sum(MTD_Amount) as MTD_Amount, Sum(LM_Target) as LM_Target,
                Sum(LM_Amount) as LM_Amount, Sum(YTD_Amount) as YTD_Amount, Sum(LY_YTD) as LY_YTD, Sum(LYFUll_Amount) as LYFUll_Amount,
                sum(LM_MTD) as LM_MTD
                from dWDB.[dbo].[t_ChannelSales] group by TerritoryId, ChannelType, TerritoryName, AreaId, TerritorySort
                UNION ALL
                Select TerritoryId as Id, ChannelType as Channel, 'Territory' as Type, 4 as TypeId, TerritoryName as Name, AreaId as ParentId, TerritorySort as Sort,
                Sum(TD_Amount) as TD_Amount, Sum(LastDay_Amount) as LastDay_Amount, Sum(FullTarget) as FullTarget,
                Sum(MTD_Target) as MTD_Target, Sum(MTD_Amount) as MTD_Amount, Sum(LM_Target) as LM_Target,
                Sum(LM_Amount) as LM_Amount, Sum(YTD_Amount) as YTD_Amount, Sum(LY_YTD) as LY_YTD, Sum(LYFUll_Amount) as LYFUll_Amount,
                sum(LM_MTD) as LM_MTD
                from dWDB.[dbo].[t_ChannelSales] group by TerritoryId, ChannelType, TerritoryName, AreaId, TerritorySort
                ) final order by TypeId, Channel, sort  ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLChannelSales.BLLChannelSalesRow oBLLChannelSalesRow = oDSBLLChannelSales.BLLChannelSales.NewBLLChannelSalesRow();


                    oBLLChannelSalesRow.Id = Convert.ToInt32(reader["Id"]);
                    oBLLChannelSalesRow.Channel = reader["Channel"].ToString();
                    oBLLChannelSalesRow.Type = reader["Type"].ToString();
                    oBLLChannelSalesRow.TypeId = Convert.ToInt32(reader["TypeId"]);
                    oBLLChannelSalesRow.Name = reader["Name"].ToString();
                    oBLLChannelSalesRow.ParentId = Convert.ToInt32(reader["ParentId"]);
                    oBLLChannelSalesRow.Sort = Convert.ToInt32(reader["Sort"]);
                    oBLLChannelSalesRow.TodayValue = Convert.ToDouble(reader["TD_Amount"]);
                    oBLLChannelSalesRow.LDValue = Convert.ToDouble(reader["LastDay_Amount"]);
                    oBLLChannelSalesRow.CMTValue = Convert.ToDouble(reader["FullTarget"]);
                    oBLLChannelSalesRow.MTDTValue = Convert.ToDouble(reader["MTD_Target"]);
                    oBLLChannelSalesRow.MTDValue = Convert.ToDouble(reader["MTD_Amount"]);
                    oBLLChannelSalesRow.LMTValue = Convert.ToDouble(reader["LM_Target"]);
                    oBLLChannelSalesRow.LMValue = Convert.ToDouble(reader["LM_Amount"]);
                    oBLLChannelSalesRow.YTDValue = Convert.ToDouble(reader["YTD_Amount"]);
                    oBLLChannelSalesRow.LYYTDValue = Convert.ToDouble(reader["LY_YTD"]);
                    oBLLChannelSalesRow.LYValue = Convert.ToDouble(reader["LYFUll_Amount"]);
                    oBLLChannelSalesRow.LMMTDValue= Convert.ToDouble(reader["LM_MTD"]);


                    oDSBLLChannelSales.BLLChannelSales.AddBLLChannelSalesRow(oBLLChannelSalesRow);
                    oDSBLLChannelSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }


            return oDSBLLChannelSales;
        }

        
        
        
        public List<Data> getResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            DateTime dFromDate = DateTime.Now;

            DateTime LastDayOfMonth = _oTELLib.LastDayofMonth(dFromDate);
            int nLastDayCM = LastDayOfMonth.Day;
            int nDay = dFromDate.Day;

            DSBLLChannelSales oDSData = new DSBLLChannelSales();
            oDSData = GetData();

            foreach (DSBLLChannelSales.BLLChannelSalesRow oDSDataRow in oDSData.BLLChannelSales)
            {

                _oData = new Data();
                _oData.Channel = oDSDataRow.Channel;
                _oData.Type = oDSDataRow.Type;
                _oData.Name = oDSDataRow.Name;

                _oData.TodayValueText = ExcludeDecimal(_oTELLib.TakaFormat(oDSDataRow.TodayValue));
                _oData.LDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oDSDataRow.LDValue));
                _oData.CMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oDSDataRow.CMTValue));
                _oData.MTDTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oDSDataRow.MTDTValue));
                _oData.MTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oDSDataRow.MTDValue));

                _oData.LMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oDSDataRow.LMTValue));
                _oData.LMValueText = ExcludeDecimal(_oTELLib.TakaFormat(oDSDataRow.LMValue));
                _oData.YTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oDSDataRow.YTDValue));
                _oData.LYYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oDSDataRow.LYYTDValue));
                _oData.LYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oDSDataRow.LYValue));
                _oData.LMMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oDSDataRow.LYValue));

                //Performance

                if (oDSDataRow.CMTValue > 0)
                {
                    _oData.CMPercentText = Convert.ToString(Math.Round((oDSDataRow.MTDValue / oDSDataRow.CMTValue) * 100));
                    _oData.MTDPercentText = Convert.ToString(Math.Round((oDSDataRow.MTDValue / oDSDataRow.MTDTValue) * 100));
                }
                else
                {
                    _oData.CMPercentText = "0";
                    _oData.MTDPercentText = "0";
                }

                if (oDSDataRow.LMTValue > 0)
                {
                    _oData.LMPercentText = Convert.ToString(Math.Round((oDSDataRow.LMValue / oDSDataRow.LMTValue)  *100));
                }
                else
                {
                    _oData.LMPercentText = "0";
                }
                
                if (oDSDataRow.LYYTDValue > 0)
                {
                    _oData.YTDGthPercText = Convert.ToString(Math.Round((oDSDataRow.YTDValue - oDSDataRow.LYYTDValue) / oDSDataRow.LYYTDValue * 100));
                }
                else
                {
                    _oData.YTDGthPercText = "0";
                }

                if (oDSDataRow.LMMTDValue > 0)
                {
                    _oData.MTDGthPercText = Convert.ToString(Math.Round((oDSDataRow.MTDValue - oDSDataRow.LMMTDValue) / oDSDataRow.LMMTDValue * 100));
                }
                else
                {
                    _oData.MTDGthPercText = "0";
                }


                eList.Add(_oData);
            }
            return eList;

        }
    }
}



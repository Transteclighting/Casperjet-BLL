using System;
using System.Data;
using System.Configuration;
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

public partial class jOutletSalesChannelValue : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();

            //string sUser = "hakim";

            Data _oData = new Data();
            Datas oDatas = new Datas();
            DBController.Instance.OpenNewConnection();
            oDatas.GetData();
            DBController.Instance.CloseConnection();
          
            _oData.InsertReportLog(sUser);

            string sOutput = JsonConvert.SerializeObject(oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());
  
        }
    }
    public class Data
    {
        public string Company;
        public string Channel;
        public string AreaName;
        public string ZoneName;
        public string Outlet;
        public string Type;
        public string Name;
        public string Condition;

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
        public double YBLYValue;

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
        public string YBLYValueText;

        public string CMPercText;
        public string MTDPercText;
        public string LMPercText;
        public string YTDGthPercText;
        public string LYGthPercText;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10005";
            string sReportName = "Outlet Sales Value";
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

        public void GetData()
        {
            string[] arr = new string[4];
            arr[0] = "All";
            arr[1] = "Retail";
            arr[2] = "B2B";
            arr[3] = "Dealer"; 

            Datas oDatas = new Datas();
            DSOutletSalesChannelValue _oDSSalesVal = new DSOutletSalesChannelValue();
            _oDSSalesVal = oDatas.FillDataSet(_oDSSalesVal);


            DSOutletSalesChannelValue _oDSFilteredData = new DSOutletSalesChannelValue();
            DSOutletSalesChannelValue.FilteredDataRow oFilteredDataRow;

            //Company TEL
            foreach (string Channel4ComTEL in arr)
            {
                oFilteredDataRow = _oDSFilteredData.FilteredData.NewFilteredDataRow();
                oFilteredDataRow.Name = "National";
                oFilteredDataRow.Type = "National";
                oFilteredDataRow.Condition = " Company='TEL' and Outlet='National' and Channel = '" + Channel4ComTEL + "'";
                _oDSFilteredData.FilteredData.AddFilteredDataRow(oFilteredDataRow);
                _oDSFilteredData.AcceptChanges();
            }
            //Company TML
            foreach (string Channel4ComTML in arr)
            {
                oFilteredDataRow = _oDSFilteredData.FilteredData.NewFilteredDataRow();
                oFilteredDataRow.Name = "National";
                oFilteredDataRow.Type = "National";
                oFilteredDataRow.Condition = " Company='TML' and Outlet='National' and Channel = '" + Channel4ComTML + "' ";
                _oDSFilteredData.FilteredData.AddFilteredDataRow(oFilteredDataRow);
                _oDSFilteredData.AcceptChanges();
            }

            Datas oAreas = new Datas();
            oAreas.GetArea();            
           

            foreach (Data oArea in oAreas)
            {
                foreach (string Channel4Area in arr)
                {
                    oFilteredDataRow = _oDSFilteredData.FilteredData.NewFilteredDataRow();
                    oFilteredDataRow.Name = oArea.AreaName;
                    oFilteredDataRow.Type = "Area";
                    oFilteredDataRow.Condition = " AreaName='" + oArea.AreaName + "' and Company='" + oArea.Company + "' and Channel='" + Channel4Area + "' ";
                    _oDSFilteredData.FilteredData.AddFilteredDataRow(oFilteredDataRow);
                    _oDSFilteredData.AcceptChanges();
                }


                Datas oZones = new Datas();
                oZones.GetZone(oArea.AreaName, oArea.Company);
                foreach (Data oZone in oZones)
                {
                    foreach (string Channel4Territory in arr)
                    {
                        oFilteredDataRow = _oDSFilteredData.FilteredData.NewFilteredDataRow();
                        oFilteredDataRow.Name = oZone.ZoneName;
                        oFilteredDataRow.Type = "Zone";
                        oFilteredDataRow.Condition = " ZoneName='" + oZone.ZoneName + "' and AreaName='" + oArea.AreaName + "' and Company='" + oArea.Company + "' and Channel='" + Channel4Territory + "' ";
                        _oDSFilteredData.FilteredData.AddFilteredDataRow(oFilteredDataRow);
                        _oDSFilteredData.AcceptChanges();
                    }

                    Datas oOutlets = new Datas();
                    oOutlets.GetOutlet(oZone.ZoneName, oArea.Company);
                    foreach (Data oOutlet in oOutlets)
                    {                       
                        oFilteredDataRow = _oDSFilteredData.FilteredData.NewFilteredDataRow();
                        oFilteredDataRow.Name = oOutlet.Outlet;
                        oFilteredDataRow.Type = "Outlet";
                        oFilteredDataRow.Condition = " Outlet='" + oOutlet.Outlet + "' and Company='" + oArea.Company + "'";
                        _oDSFilteredData.FilteredData.AddFilteredDataRow(oFilteredDataRow);
                        _oDSFilteredData.AcceptChanges();
                    }
                
                }
            
            }
            Data _oData;
            InnerList.Clear();
            foreach (DSOutletSalesChannelValue.FilteredDataRow oDSFilteredRow in _oDSFilteredData.FilteredData)
            {
                string y = oDSFilteredRow.Name;

                DSOutletSalesChannelValue _oDSOutletChannelValue = new DSOutletSalesChannelValue();

                DSOutletSalesChannelValue oDSFilteredData = new DSOutletSalesChannelValue();
                DataRow[] oDR = _oDSSalesVal.OutletSalesChannel.Select(oDSFilteredRow.Condition);
                oDSFilteredData.Merge(oDR);
                oDSFilteredData.AcceptChanges();

                _oData = new Data();             

                foreach (DSOutletSalesChannelValue.OutletSalesChannelRow oDSRow in oDSFilteredData.OutletSalesChannel)
                {
                    

                    if (oDSFilteredRow.Type == "National")
                    {
                        _oData.Company = oDSRow.Company;
                        _oData.Channel = oDSRow.Channel;
                        _oData.Name = oDSFilteredRow.Name;
                        _oData.Type = oDSFilteredRow.Type;
                        _oData.DTDValue = _oData.DTDValue + Convert.ToDouble(oDSRow.DTDValue);
                        _oData.LDValue = _oData.LDValue + Convert.ToDouble(oDSRow.LDValue);
                        _oData.MTDValue = _oData.MTDValue + Convert.ToDouble(oDSRow.MTDValue);
                        _oData.LMValue = _oData.LMValue + Convert.ToDouble(oDSRow.LMValue);
                        _oData.YTDValue = _oData.YTDValue + Convert.ToDouble(oDSRow.YTDValue);
                        _oData.LYValue = _oData.LYValue + Convert.ToDouble(oDSRow.LYValue);
                        _oData.LYYTDValue = _oData.LYYTDValue + Convert.ToDouble(oDSRow.LYYTDValue);
                        _oData.CMTValue = _oData.CMTValue + Convert.ToDouble(oDSRow.CMTValue);
                        _oData.MTDTValue = _oData.MTDTValue + Convert.ToDouble(oDSRow.MTDTValue);
                        _oData.LMTValue = _oData.LMTValue + Convert.ToDouble(oDSRow.LMTValue);
                        _oData.YBLYValue = _oData.YBLYValue + Convert.ToDouble(oDSRow.YBLYValue);
                    }
                    else if (oDSFilteredRow.Type == "Area" || oDSFilteredRow.Type == "Zone")
                    {
                        _oData.Company = oDSRow.Company;
                        _oData.Channel = oDSRow.Channel;
                        _oData.Name = oDSFilteredRow.Name;
                        _oData.Type = oDSFilteredRow.Type;
                        _oData.DTDValue = _oData.DTDValue + Convert.ToDouble(oDSRow.DTDValue);
                        _oData.LDValue = _oData.LDValue + Convert.ToDouble(oDSRow.LDValue);
                        _oData.MTDValue = _oData.MTDValue + Convert.ToDouble(oDSRow.MTDValue);
                        _oData.LMValue = _oData.LMValue + Convert.ToDouble(oDSRow.LMValue);
                        _oData.YTDValue = _oData.YTDValue + Convert.ToDouble(oDSRow.YTDValue);
                        _oData.LYValue = _oData.LYValue + Convert.ToDouble(oDSRow.LYValue);
                        _oData.LYYTDValue = _oData.LYYTDValue + Convert.ToDouble(oDSRow.LYYTDValue);
                        _oData.CMTValue = _oData.CMTValue + Convert.ToDouble(oDSRow.CMTValue);
                        _oData.MTDTValue = _oData.MTDTValue + Convert.ToDouble(oDSRow.MTDTValue);
                        _oData.LMTValue = _oData.LMTValue + Convert.ToDouble(oDSRow.LMTValue);
                        _oData.YBLYValue = _oData.YBLYValue + Convert.ToDouble(oDSRow.YBLYValue);
                    }
                    else if (oDSFilteredRow.Type == "Outlet")
                    {
                        _oData = new Data(); 
                        _oData.Company = oDSRow.Company;
                        _oData.Channel = oDSRow.Channel;
                        _oData.Name = oDSRow.Outlet;
                        _oData.Type = oDSFilteredRow.Type;
                        _oData.DTDValue = Convert.ToDouble(oDSRow.DTDValue);
                        _oData.LDValue =  Convert.ToDouble(oDSRow.LDValue);
                        _oData.MTDValue =  Convert.ToDouble(oDSRow.MTDValue);
                        _oData.LMValue = Convert.ToDouble(oDSRow.LMValue);
                        _oData.YTDValue = Convert.ToDouble(oDSRow.YTDValue);
                        _oData.LYValue = Convert.ToDouble(oDSRow.LYValue);
                        _oData.LYYTDValue = Convert.ToDouble(oDSRow.LYYTDValue);
                        _oData.CMTValue = Convert.ToDouble(oDSRow.CMTValue);
                        _oData.MTDTValue = Convert.ToDouble(oDSRow.MTDTValue);
                        _oData.LMTValue = Convert.ToDouble(oDSRow.LMTValue);
                        _oData.YBLYValue = Convert.ToDouble(oDSRow.YBLYValue);
                        
                        InnerList.Add(_oData);
                    }
 
                }
                if (oDSFilteredRow.Type != "Outlet")
                {
                    InnerList.Add(_oData);
                }
            }

        }

        public DSOutletSalesChannelValue FillDataSet(DSOutletSalesChannelValue oDSOutletSalesChannelValue)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select Company, 'National' as Outlet, 'All' as Channel,  Sum(Today) as Today, Sum(LastDay) as LastDay, Sum(CMTarget) as CMTarget, "+
                   " Sum(MTDTarget) as MTDTarget, Sum(ThisMonth) as ThisMonth, Sum(LMTarget) as LMTarget, Sum(LastMonth) as LastMonth,   "+
                   " Sum(ThisYear) as ThisYear, Sum(LastYear) as LastYear, Sum(LYYTD) as LYYTD, Sum(IsNull(YBLY,0)) as YBLY,   " +
                   " 0 as AreaSort, 'National' as AreaName, 0 as TerritorySort, 'National' as TerritoryName from DWDB.dbo.t_OutletChannelSales  "+
                   " Group by Company "+
                   " UNION ALL " +
                   " Select Company, 'National' as Outlet, Channel,  Sum(Today) as Today, Sum(LastDay) as LastDay, Sum(CMTarget) as CMTarget, " +
                   " Sum(MTDTarget) as MTDTarget, Sum(ThisMonth) as ThisMonth, Sum(LMTarget) as LMTarget, Sum(LastMonth) as LastMonth,   " +
                   " Sum(ThisYear) as ThisYear, Sum(LastYear) as LastYear, Sum(LYYTD) as LYYTD, Sum(IsNull(YBLY,0)) as YBLY,   " +
                   " 0 as AreaSort, 'National' as AreaName, 0 as TerritorySort, 'National' as TerritoryName from DWDB.dbo.t_OutletChannelSales  " +
                   " Group by Company, Channel " +
                   " UNION ALL " +
                   " Select * from (Select Company, Outlet, 'All' as Channel,  Sum(Today) as Today, Sum(LastDay) as LastDay, Sum(CMTarget) as CMTarget, " +
                   " Sum(MTDTarget) as MTDTarget, Sum(ThisMonth) as ThisMonth, Sum(LMTarget) as LMTarget, Sum(LastMonth) as LastMonth,  " +
                   " Sum(ThisYear) as ThisYear, Sum(LastYear) as LastYear, Sum(LYYTD) as LYYTD, Sum(IsNull(YBLY,0)) as YBLY,  " +
                   " AreaSort, AreaName, TerritorySort, TerritoryName from DWDB.dbo.t_OutletChannelSales " +
                   " Group by Company, Outlet, AreaSort, AreaName, TerritorySort, TerritoryName " +
                   " UNION ALL  " +
                   " Select Company, Outlet, Channel,  Today, LastDay, CMTarget, MTDTarget, ThisMonth, LMTarget, LastMonth,  " +
                   " ThisYear, LastYear, LYYTD, IsNull(YBLY,0) YBLY, AreaSort, AreaName, TerritorySort, TerritoryName from DWDB.dbo.t_OutletChannelSales ) x " +
                   " Order by Company, AreaSort, TerritorySort, Outlet, Channel ";
            try
            {
                
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSalesChannelValue.OutletSalesChannelRow oOutletSalesChannelRow = oDSOutletSalesChannelValue.OutletSalesChannel.NewOutletSalesChannelRow();


                    oOutletSalesChannelRow.Company = reader["Company"].ToString();
                    oOutletSalesChannelRow.Outlet = reader["Outlet"].ToString();
                    oOutletSalesChannelRow.Channel = reader["Channel"].ToString();

                    oOutletSalesChannelRow.DTDValue = Convert.ToDouble(reader["Today"]);
                    oOutletSalesChannelRow.LDValue = Convert.ToDouble(reader["LastDay"]);
                    oOutletSalesChannelRow.MTDValue = Convert.ToDouble(reader["ThisMonth"]);
                    oOutletSalesChannelRow.LMValue = Convert.ToDouble(reader["LastMonth"]);
                    oOutletSalesChannelRow.YTDValue = Convert.ToDouble(reader["ThisYear"]);
                    oOutletSalesChannelRow.LYValue = Convert.ToDouble(reader["LastYear"]);

                    oOutletSalesChannelRow.LYYTDValue = Convert.ToDouble(reader["LYYTD"]);

                    oOutletSalesChannelRow.CMTValue = Convert.ToDouble(reader["CMTarget"]);
                    oOutletSalesChannelRow.MTDTValue = Convert.ToDouble(reader["MTDTarget"]);
                    oOutletSalesChannelRow.LMTValue = Convert.ToDouble(reader["LMTarget"]);
                    oOutletSalesChannelRow.YBLYValue = Convert.ToDouble(reader["YBLY"]);

                    oOutletSalesChannelRow.AreaName = reader["AreaName"].ToString();
                    oOutletSalesChannelRow.ZoneName = reader["TerritoryName"].ToString();

                    oDSOutletSalesChannelValue.OutletSalesChannel.AddOutletSalesChannelRow(oOutletSalesChannelRow);
                    oDSOutletSalesChannelValue.AcceptChanges();

                    
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSOutletSalesChannelValue;
        }

        public void GetArea()
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select distinct Company, AreaName, AreaSort from DWDB.dbo.t_OutletChannelSales Order by Company, AreaSort ";
            try
            {
                Data _oData;
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oData = new Data();

                    _oData.Company = reader["Company"].ToString();
                    _oData.AreaName = reader["AreaName"].ToString();

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

        public void GetZone(string sArea, string sCompany)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select distinct TerritoryName, AreaName, TerritorySort from DWDB.dbo.t_OutletChannelSales  "+
                   " Where AreaName = '" + sArea + "' and Company = '" + sCompany + "' Order by TerritorySort ";
            try
            {
                Data _oData;
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oData = new Data();

                    _oData.ZoneName = reader["TerritoryName"].ToString();

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

        public void GetOutlet(string sTerritory, string sCompany)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select distinct Outlet from DWDB.dbo.t_OutletChannelSales Where TerritoryName = '" + sTerritory + "' and Company = '" + sCompany + "' Order by Outlet ";
            try
            {
                Data _oData;
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oData = new Data();

                    _oData.Outlet = reader["Outlet"].ToString();

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
                _oData.Name = oData.Name;
                _oData.Company = oData.Company;
                _oData.Channel = oData.Channel;
                _oData.Value = "Success";

                _oData.DTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.DTDValue));
                _oData.LDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDValue));
                _oData.MTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDValue));
                _oData.LMValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMValue));
                _oData.YTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue));
                _oData.LYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYValue));
                _oData.CMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMTValue));
                _oData.LMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMTValue));
                _oData.LYYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTDValue));
                _oData.YBLYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YBLYValue));

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
                if (oData.YBLYValue > 0)
                {
                    _oData.LYGthPercText = Convert.ToString(Math.Round(((oData.LYValue / oData.YBLYValue) * 100) - 100));
                }
                else
                {
                    _oData.LYGthPercText = "0";
                }
                


                eList.Add(_oData);
            }
            return eList;

        }
    }
}


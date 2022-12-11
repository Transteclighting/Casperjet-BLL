using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Data.OleDb;
using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.Library;



public partial class jOutletSalesChannelValueUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            //string sUser = "hakim";
            //string sCompany = "TEL";

            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sIsDealerSales = "";
            //try
            //{
            //    sIsDealerSales = c.Request.Form["IsDealerSales"].Trim();
            //}
            //catch
            //{
            //    sIsDealerSales = "No";
            //}
            if (c.Request.Form["IsDealerSales"] != null)
            {
                sIsDealerSales = c.Request.Form["IsDealerSales"].Trim();
            }
            else
            {
                sIsDealerSales = "No";
            }

            //string sUser = "hakim";
            //string sCompany = "TEL";

            Data _oData = new Data();
            Datas oDatas = new Datas();
            if(!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            oDatas.GetData(sCompany, sIsDealerSales);
           
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
        public string BusinessType;

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



        public string TodayTarget;
        public string TodayPercText;
        public string LastdayTarget;
        public string LastdayPercText;
        public string LYMTD;
        public string MTDGthPercText;

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
        DSOutletSalesChannelValue _oDSSalesVal = new DSOutletSalesChannelValue();
        DSOutletSalesChannelValue oDSFilteredData = new DSOutletSalesChannelValue();
        private bool Fill_DS(string sCondition)
        {          
            DataRow[] oDR = _oDSSalesVal.OutletSalesChannel.Select(sCondition);
            oDSFilteredData.Merge(oDR);
            oDSFilteredData.AcceptChanges();

            if (oDR.Length > 0)
                return true;
            else return false;

        }
        public void GetData(string sCompany,string sIsDealerSales)
        {
         
            Datas oDatas = new Datas();

            _oDSSalesVal = oDatas.FillData(_oDSSalesVal, sCompany, sIsDealerSales);

            Datas _oAreas = new Datas();
            _oAreas.GetAllArea(sCompany, sIsDealerSales);

            string sCondition = "";

            sCondition = " Type = 'National' and Outlet= 'National'";
            if(Fill_DS(sCondition))
            { 
                foreach (Data oArea in _oAreas)
                {
                    sCondition = " Type = 'Area' and Outlet= '" + oArea.AreaName + "'  and ParentName='National' ";
                    if (Fill_DS(sCondition))
                    {

                        Datas _oZones = new Datas();
                        _oZones.GetAllZone(sCompany, oArea.AreaName, sIsDealerSales);

                        foreach (Data oZone in _oZones)
                        {
                            //Get Zone
                            sCondition = " Type= 'Territory' and Outlet= '" + oZone.ZoneName + "' and ParentName='" + oArea.AreaName + "'";
                            if (Fill_DS(sCondition))
                            {
                                //Get Outlet by Zone
                                sCondition = " Type= 'Outlet' and ParentName='" + oZone.ZoneName + "'";
                                Fill_DS(sCondition);
                            }

                        }
                    }

                }

            }

        }

        public DSOutletSalesChannelValue FillData(DSOutletSalesChannelValue oDSOutletSalesChannelValue, String sCompany, String sIsDealerSales)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = @" Select Type, Company, Outlet, Channel, Today, LastDay, CMTarget, MTDTarget, ThisMonth, LMTarget, 
                    LastMonth, ThisYear, LastYear, LYYTD, YBLY, AreaSort, AreaName, TerritorySort, TerritoryName, 
                    BusinessType, ParentName,TodayTarget,LastdayTarget, LYMTDSales as LYMTD 
                    from DWDB.dbo.t_OutletChannelSalesForApp Where Company = '{0}'";

            //sSQL = @" Select Type, Company, Outlet, Channel, Today, LastDay, CMTarget, MTDTarget, ThisMonth, LMTarget, 
            //        LastMonth, ThisYear, LastYear, LYYTD, YBLY, AreaSort, AreaName, TerritorySort, TerritoryName, 
            //        BusinessType, ParentName from DWDB.dbo.t_OutletChannelSalesForAppNew Where Company = '{0}' and IsDealerSales='{1}'";

            sSQL = string.Format(sSQL, sCompany, sIsDealerSales);
            try
            {

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSalesChannelValue.OutletSalesChannelRow oOutletSalesChannelRow = oDSOutletSalesChannelValue.OutletSalesChannel.NewOutletSalesChannelRow();

                    oOutletSalesChannelRow.Type = reader["Type"].ToString();
                    oOutletSalesChannelRow.ParentName = reader["ParentName"].ToString();
                    oOutletSalesChannelRow.Company = reader["Company"].ToString();
                    oOutletSalesChannelRow.BusinessType = reader["BusinessType"].ToString();
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

                    oOutletSalesChannelRow.TodayTarget = Convert.ToDouble(reader["TodayTarget"]);
                    oOutletSalesChannelRow.LastdayTarget = Convert.ToDouble(reader["LastdayTarget"]);
                    oOutletSalesChannelRow.LYMTD = Convert.ToDouble(reader["LYMTD"]);


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

        public void GetAllArea(string sCompany,string sIsDealerSales)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select distinct Outlet as AreaName, ParentName, AreaSort from DWDB.dbo.t_OutletChannelSalesForApp Where Company = '" + sCompany + "' and Type = 'Area' Order by AreaSort ";
            //sSQL = " Select distinct Outlet as AreaName, ParentName, AreaSort from DWDB.dbo.t_OutletChannelSalesForAppNew Where IsDealerSales='" + sIsDealerSales + "' and  Company = '" + sCompany + "' and Type = 'Area' Order by AreaSort ";
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
                    _oData.Name = reader["ParentName"].ToString();

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

        public void GetAllZone(string sCompany, string sAreaName,string sIsDealerSales)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select distinct Outlet as TerritoryName, ParentName, TerritorySort from DWDB.dbo.t_OutletChannelSalesForApp Where Company = '" + sCompany + "' and  ParentName = '" + sAreaName + "' and Type = 'Territory' Order by TerritorySort ";
            //sSQL = " Select distinct Outlet as TerritoryName, ParentName, TerritorySort from DWDB.dbo.t_OutletChannelSalesForAppNew Where Company = '" + sCompany + "' and IsDealerSales='" + sIsDealerSales + "' and  ParentName = '" + sAreaName + "' and Type = 'Territory' Order by TerritorySort ";
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
                    _oData.Name = reader["ParentName"].ToString();

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
           foreach (DSOutletSalesChannelValue.OutletSalesChannelRow oData in oDSFilteredData.OutletSalesChannel)
            {
                _oData = new Data();
                _oData.Outlet = oData.Outlet;
                _oData.Type = oData.Type;
                _oData.Name = oData.Outlet;
                _oData.Company = oData.Company;
                _oData.Channel = oData.Channel;
                _oData.BusinessType = oData.BusinessType;
                _oData.Value = "Success";

                _oData.DTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.DTDValue));

                if (oData.TodayTarget > 0)
                {
                    _oData.TodayPercText = Convert.ToString(Math.Round((oData.DTDValue / oData.TodayTarget) * 100));
                }
                else
                {
                    _oData.TodayPercText = "0";
                }

                _oData.LDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDValue));

                if (oData.LastdayTarget > 0)
                {
                    _oData.LastdayPercText = Convert.ToString(Math.Round((oData.LDValue / oData.LastdayTarget) * 100));
                }
                else
                {
                    _oData.LastdayPercText = "0";
                }

                _oData.MTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDValue));
                _oData.LMValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMValue));
                _oData.YTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue));
                _oData.LYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYValue));
                _oData.CMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMTValue));
                _oData.LMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMTValue));
                _oData.LYYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTDValue));
                _oData.YBLYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YBLYValue));

                _oData.TodayTarget = ExcludeDecimal(_oTELLib.TakaFormat(oData.TodayTarget));
                _oData.LastdayTarget = ExcludeDecimal(_oTELLib.TakaFormat(oData.LastdayTarget));
                _oData.LYMTD = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYMTD));

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

                if (oData.LYMTD > 0)
                {
                    _oData.MTDGthPercText = Convert.ToString(Math.Round(((oData.MTDTValue / oData.LYMTD) * 100) - 100));
                }
                else
                {
                    _oData.MTDGthPercText = "0";
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
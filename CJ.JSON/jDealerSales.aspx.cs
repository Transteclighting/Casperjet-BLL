using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.ANDROID;


public partial class jDealerSales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            //string sUser = c.Request.Form["UserName"].Trim();
            //string sCompany = c.Request.Form["Company"].Trim();

            string sUser = "hakim";
            string sCompany = "TEL";

            Data _oData = new Data();
            Datas oDatas = new Datas();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            oDatas.GetData();

            DBController.Instance.CloseConnection();
            _oData.InsertReportLog(sUser);
            string sOutput = JsonConvert.SerializeObject(oDatas.getResult(), Formatting.Indented);
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


        public string ContactNo;
        public string Incharge;
        public string Type;
        public string Name;
        public string ZoneName;
        public string AreaName;
        public string BusinessType;
        public string Channel;
        public string BrandType;
        public string SalesPersonID;
        public string EmployeeCode;
        public string EmployeeName;

        public string Today;
        public string LastDay;
        public string CMTarget;
        public string MTDTarget;
        public string ThisMonth;
        public string LMTarget;
        public string LastMonth;
        public string ThisYear;
        public string LYYTD;
        public string LastYear;
        public string YBLY;
        public string CMLeadTgtQty;
        public string CMLeadTgtVal;

        public string Parent;
        public string Sort;
        public string IsActive;
        public string OwnTP;
        public string EmployeeType;

        //public string LMPercText;
        //public string CMPercText;
        //public string MTDPercText;
        //public string YTDGthPercText;
        public string YBLYGthPercText;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "";
            string sReportName = "Dealer Sales Summary []";
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
        int _Lead_Exces_Short_Qty;
        double _Lead_Exces_Short_Amt;
        int _CMLeadTargetQty;
        double _CMLeadTargetValue;



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
        public void GetData()
        {

            Datas oDatas = new Datas();

            _oDSSalesVal = oDatas.FillData(_oDSSalesVal);

            Datas _oAreas = new Datas();
            _oAreas.GetAllArea();

            string sCondition = "";

            sCondition = " Type = 'National' and Name= 'National'";
            if (Fill_DS(sCondition))
            {
                foreach (Data oArea in _oAreas)
                {
                    sCondition = " Type = 'Area' and Name= '" + oArea.AreaName + "'  and ParentName='National' ";
                    if (Fill_DS(sCondition))
                    {

                        Datas _oZones = new Datas();
                        _oZones.GetAllZone(oArea.AreaName);

                        foreach (Data oZone in _oZones)
                        {
                            //Get Zone
                            sCondition = " Type= 'Territory' and Name= '" + oZone.ZoneName + "' and ParentName='" + oArea.AreaName + "'";
                            if (Fill_DS(sCondition))
                            {
                                //Get Outlet by Zone
                                sCondition = " Type= 'Customer' and ParentName='" + oZone.ZoneName + "'";
                                Fill_DS(sCondition);
                            }

                        }
                    }

                }

            }

        }


        public void GetAllArea()
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = @"Select distinct Name as AreaName, Parent, Sort
                    from DWDB.dbo.t_DealerSalesSummary
                    Where Type = 'Area' Order by Sort";
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
                    _oData.Name = reader["Parent"].ToString();

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
        public DSOutletSalesChannelValue FillData(DSOutletSalesChannelValue oDSOutletSalesChannelValue)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = "Select Type,Name,BrandType,Today,LastDay,CMTarget,MTDTarget,ThisMonth,LMTarget,LastMonth, " +
                   "ThisYear,LYYTD,LastYear,YBLY,Parent,Sort,Incharge,ContactNo From DWDB.dbo.t_DealerSalesSummary where 1=1";
            
            try
            {

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSalesChannelValue.OutletSalesChannelRow oOutletSalesChannelRow = oDSOutletSalesChannelValue.OutletSalesChannel.NewOutletSalesChannelRow();

                    oOutletSalesChannelRow.Type = reader["Type"].ToString();
                    oOutletSalesChannelRow.ParentName = reader["Parent"].ToString();
                    oOutletSalesChannelRow.BrandType = reader["BrandType"].ToString();
                    oOutletSalesChannelRow.Name = reader["Name"].ToString();

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
                    oOutletSalesChannelRow.Sort = Convert.ToInt32(reader["Sort"]);
                    
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
            int i = oDSOutletSalesChannelValue.OutletSalesChannel.Count;
            return oDSOutletSalesChannelValue;
        }

        public void GetAllZone(string sAreaName)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = "Select distinct Name as TerritoryName, Parent, Sort  " +
                "from DWDB.dbo.t_DealerSalesSummary  " +
                "Where Type = 'Zone' and Parent = '"+ sAreaName + "' Order by Sort";

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
                    _oData.Name = reader["Parent"].ToString();

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
                _oData.Type = oData.Type;
                _oData.Name = oData.Name;
                //_oData.Channel = oData.Channel;
                _oData.BrandType = oData.BrandType;
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
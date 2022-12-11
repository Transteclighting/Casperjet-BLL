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

public partial class jOutletWiseInvoiceLeadCustomerTraceForApp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            //string sUser = c.Request.Form["UserName"].Trim();

            string sUser = "hakim";

            Data _oData = new Data();
            _oData.InsertReportLog(sUser);

            Datas oDatas = new Datas();
            Datas _oDatas = new Datas();

            DBController.Instance.OpenNewConnection();
            oDatas.GetData();
            DBController.Instance.CloseConnection();
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
        public string Type;
        public string Name;
        public string AreaName;
        public int AreaSort;
        public string TerritoryName;
        public int TerritorySort;
        public string PGCategoryName;
        public string ParentName;
        public double TodayTargetQty;
        public double TodayTargetValue;
        public double LastdayTargetQty;
        public double LastdayTargetValue;
        public double NextdayTargetQty;
        public double NextdayTargetValue;
        public int ThisWeekTargetQty;
        public double ThisWeekTargetValue;
        public int LastWeekTargetQty;
        public double LastWeekTargetValue;
        public int ThisMonthTargetQty;
        public double ThisMonthTargetValue;
        public int LastMonthTargetQty;
        public double LastMonthTargetValue;
        public int TodaySalesQty;
        public double TodayNetSale;
        public int LastdaySalesQty;
        public double LastdayNetSale;
        public int ThisWeekSalesQty;
        public double ThisWeekNetSale;
        public int LastWeekSalesQty;
        public double LastWeekNetSale;
        public int ThisMonthSalesQty;
        public double ThisMonthNetSale;
        public int LastMonthSalesQty;
        public double LastMonthNetSale;
        public int TodayNoOfInvoice;
        public int LastdayNoOfInvoice;
        public int ThisWeekNoOfInvoice;
        public int LastWeekNoOfInvoice;
        public int ThisMonthNoOfInvoice;
        public int LastMonthNoOfInvoice;
        public int TodayNoOfLead;
        public double TodayLeadAmount;
        public int LastdayNoOfLead;
        public double LastdayLeadAmount;
        public int ThisWeekNoOfLead;
        public double ThisWeekLeadAmount;
        public int LastWeekNoOfLead;
        public double LastWeekLeadAmount;
        public int ThisMonthNoOfLead;
        public double ThisMonthLeadAmount;
        public int LastMonthNoOfLead;
        public double LastMonthLeadAmount;
        public int TodayNoOfConvertedLead;
        public double TodayNetSaleConvertedLead;
        public int LastdayNoOfConvertedLead;
        public double LastdayNetSaleConvertedLead;
        public int ThisWeekNoOfConvertedLead;
        public double ThisWeekNetSaleConvertedLead;
        public int ThisMonthNoOfConvertedLead;
        public double ThisMonthNetSaleConvertedLead;
        public int LastMonthNoOfConvertedLead;
        public double LastMonthNetSaleConvertedLead;
        public double LMASP;
        public int ToDayReqCustomer;
        public int LastDayReqCustomer;
        public int NextDayReqCustomer;
        public int ThisWeekReqCustomer;
        public int LastWeekReqCustomer;
        public int LastMonthReqCustomer;
        public int ThisMonthReqCustomer;

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

        
//-----------------------------------------

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
            sSQL = @"Select Type, Name, AreaName, AreaSort, TerritoryName, TerritorySort, PGCategoryName, 
                    ParentName, TodayTargetQty, TodayTargetValue, LastdayTargetQty, LastdayTargetValue, NextdayTargetQty, 
                    NextdayTargetValue, ThisWeekTargetQty, ThisWeekTargetValue, LastWeekTargetQty, LastWeekTargetValue, 
                    ThisMonthTargetQty, ThisMonthTargetValue, LastMonthTargetQty, LastMonthTargetValue, TodaySalesQty, 
                    TodayNetSale, LastdaySalesQty, LastdayNetSale, ThisWeekSalesQty, ThisWeekNetSale, LastWeekSalesQty, 
                    LastWeekNetSale, ThisMonthSalesQty, ThisMonthNetSale, LastMonthSalesQty, LastMonthNetSale, 
                    TodayNoOfInvoice, LastdayNoOfInvoice, ThisWeekNoOfInvoice, LastWeekNoOfInvoice, ThisMonthNoOfInvoice, 
                    LastMonthNoOfInvoice, TodayNoOfLead, TodayLeadAmount, LastdayNoOfLead, LastdayLeadAmount, 
                    ThisWeekNoOfLead, ThisWeekLeadAmount, LastWeekNoOfLead, LastWeekLeadAmount, ThisMonthNoOfLead, 
                    ThisMonthLeadAmount, LastMonthNoOfLead, LastMonthLeadAmount, TodayNoOfConvertedLead, TodayNetSaleConvertedLead, 
                    LastdayNoOfConvertedLead, LastdayNetSaleConvertedLead, ThisWeekNoOfConvertedLead, ThisWeekNetSaleConvertedLead, 
                    ThisMonthNoOfConvertedLead, ThisMonthNetSaleConvertedLead, LastMonthNoOfConvertedLead, LastMonthNetSaleConvertedLead, 
                    LMASP, ToDayReqCustomer, LastDayReqCustomer, NextDayReqCustomer, ThisWeekReqCustomer, LastWeekReqCustomer, 
                    LastMonthReqCustomer, ThisMonthReqCustomer From DWDB.[dbo].[t_OutletWiseInvoiceLeadCustomerTraceForApp]
                    order by Type, Name, PGCategoryName";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oData = new Data();
                    _oData.Type = (string)reader["Type"];
                    _oData.Name = (string)reader["Name"];
                    _oData.AreaName = (string)reader["AreaName"];
                    _oData.AreaSort = Convert.ToInt32(reader["AreaSort"]);
                    _oData.TerritoryName = (string)reader["TerritoryName"];
                    _oData.TerritorySort = Convert.ToInt32(reader["TerritorySort"]);
                    _oData.PGCategoryName = (string)reader["PGCategoryName"];
                    if (reader["ParentName"] != DBNull.Value)
                    {
                        _oData.ParentName = (string)reader["ParentName"];
                    }
                    else
                    {
                        _oData.ParentName = "";
                    }
                    
                    _oData.TodayTargetQty = Convert.ToDouble(reader["TodayTargetQty"]);
                    _oData.TodayTargetValue = Convert.ToDouble(reader["TodayTargetValue"]);
                    _oData.LastdayTargetQty = Convert.ToDouble(reader["LastdayTargetQty"]);
                    _oData.LastdayTargetValue = Convert.ToDouble(reader["LastdayTargetValue"]);
                    _oData.NextdayTargetQty = Convert.ToDouble(reader["NextdayTargetQty"]);
                    _oData.NextdayTargetValue = Convert.ToDouble(reader["NextdayTargetValue"]);
                    _oData.ThisWeekTargetQty = Convert.ToInt32(reader["ThisWeekTargetQty"]);
                    _oData.ThisWeekTargetValue = Convert.ToDouble(reader["ThisWeekTargetValue"]);
                    _oData.LastWeekTargetQty = Convert.ToInt32(reader["LastWeekTargetQty"]);
                    _oData.LastWeekTargetValue = Convert.ToDouble(reader["LastWeekTargetValue"]);
                    _oData.ThisMonthTargetQty = Convert.ToInt32(reader["ThisMonthTargetQty"]);
                    _oData.ThisMonthTargetValue = Convert.ToDouble(reader["ThisMonthTargetValue"]);
                    _oData.LastMonthTargetQty = Convert.ToInt32(reader["LastMonthTargetQty"]);
                    _oData.LastMonthTargetValue = Convert.ToDouble(reader["LastMonthTargetValue"]);
                    _oData.TodaySalesQty = Convert.ToInt32(reader["TodaySalesQty"]);
                    _oData.TodayNetSale = Convert.ToDouble(reader["TodayNetSale"]);
                    _oData.LastdaySalesQty = Convert.ToInt32(reader["LastdaySalesQty"]);
                    _oData.LastdayNetSale = Convert.ToDouble(reader["LastdayNetSale"]);
                    _oData.ThisWeekSalesQty = Convert.ToInt32(reader["ThisWeekSalesQty"]);
                    _oData.ThisWeekNetSale = Convert.ToDouble(reader["ThisWeekNetSale"]);
                    _oData.LastWeekSalesQty = Convert.ToInt32(reader["LastWeekSalesQty"]);
                    _oData.LastWeekNetSale = Convert.ToDouble(reader["LastWeekNetSale"]);
                    _oData.ThisMonthSalesQty = Convert.ToInt32(reader["ThisMonthSalesQty"]);
                    _oData.ThisMonthNetSale = Convert.ToDouble(reader["ThisMonthNetSale"]);
                    _oData.LastMonthSalesQty = Convert.ToInt32(reader["LastMonthSalesQty"]);
                    _oData.LastMonthNetSale = Convert.ToDouble(reader["LastMonthNetSale"]);
                    _oData.TodayNoOfInvoice = Convert.ToInt32(reader["TodayNoOfInvoice"]);
                    _oData.LastdayNoOfInvoice = Convert.ToInt32(reader["LastdayNoOfInvoice"]);
                    _oData.ThisWeekNoOfInvoice = Convert.ToInt32(reader["ThisWeekNoOfInvoice"]);
                    _oData.LastWeekNoOfInvoice = Convert.ToInt32(reader["LastWeekNoOfInvoice"]);
                    _oData.ThisMonthNoOfInvoice = Convert.ToInt32(reader["ThisMonthNoOfInvoice"]);
                    _oData.LastMonthNoOfInvoice = Convert.ToInt32(reader["LastMonthNoOfInvoice"]);
                    _oData.TodayNoOfLead = Convert.ToInt32(reader["TodayNoOfLead"]);
                    _oData.TodayLeadAmount = Convert.ToDouble(reader["TodayLeadAmount"]);
                    _oData.LastdayNoOfLead = Convert.ToInt32(reader["LastdayNoOfLead"]);
                    _oData.LastdayLeadAmount = Convert.ToDouble(reader["LastdayLeadAmount"]);
                    _oData.ThisWeekNoOfLead = Convert.ToInt32(reader["ThisWeekNoOfLead"]);
                    _oData.ThisWeekLeadAmount = Convert.ToDouble(reader["ThisWeekLeadAmount"]);
                    _oData.LastWeekNoOfLead = Convert.ToInt32(reader["LastWeekNoOfLead"]);
                    _oData.LastWeekLeadAmount = Convert.ToDouble(reader["LastWeekLeadAmount"]);
                    _oData.ThisMonthNoOfLead = Convert.ToInt32(reader["ThisMonthNoOfLead"]);
                    _oData.ThisMonthLeadAmount = Convert.ToDouble(reader["ThisMonthLeadAmount"]);
                    _oData.LastMonthNoOfLead = Convert.ToInt32(reader["LastMonthNoOfLead"]);
                    _oData.LastMonthLeadAmount = Convert.ToDouble(reader["LastMonthLeadAmount"]);
                    _oData.TodayNoOfConvertedLead = Convert.ToInt32(reader["TodayNoOfConvertedLead"]);
                    _oData.TodayNetSaleConvertedLead = Convert.ToDouble(reader["TodayNetSaleConvertedLead"]);
                    _oData.LastdayNoOfConvertedLead = Convert.ToInt32(reader["LastdayNoOfConvertedLead"]);
                    _oData.LastdayNetSaleConvertedLead = Convert.ToDouble(reader["LastdayNetSaleConvertedLead"]);
                    _oData.ThisWeekNoOfConvertedLead = Convert.ToInt32(reader["ThisWeekNoOfConvertedLead"]);
                    _oData.ThisWeekNetSaleConvertedLead = Convert.ToDouble(reader["ThisWeekNetSaleConvertedLead"]);
                    _oData.ThisMonthNoOfConvertedLead = Convert.ToInt32(reader["ThisMonthNoOfConvertedLead"]);
                    _oData.ThisMonthNetSaleConvertedLead = Convert.ToDouble(reader["ThisMonthNetSaleConvertedLead"]);
                    _oData.LastMonthNoOfConvertedLead = Convert.ToInt32(reader["LastMonthNoOfConvertedLead"]);
                    _oData.LastMonthNetSaleConvertedLead = Convert.ToDouble(reader["LastMonthNetSaleConvertedLead"]);
                    _oData.LMASP = Convert.ToDouble(reader["LMASP"]);
                    _oData.ToDayReqCustomer = Convert.ToInt32(reader["ToDayReqCustomer"]);
                    _oData.LastDayReqCustomer = Convert.ToInt32(reader["LastDayReqCustomer"]);
                    _oData.NextDayReqCustomer = Convert.ToInt32(reader["NextDayReqCustomer"]);
                    _oData.ThisWeekReqCustomer = Convert.ToInt32(reader["ThisWeekReqCustomer"]);
                    _oData.LastWeekReqCustomer = Convert.ToInt32(reader["LastWeekReqCustomer"]);
                    _oData.LastMonthReqCustomer = Convert.ToInt32(reader["LastMonthReqCustomer"]);
                    _oData.ThisMonthReqCustomer = Convert.ToInt32(reader["ThisMonthReqCustomer"]);


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
                //_oData.DTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.DTDValue));
                //_oData.LDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDValue));
                //_oData.CMTarText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMTValue)); 
                //_oData.MTDTarText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDTValue)); 
                //_oData.MTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDValue));

                //if (oData.CMTValue > 0)
                //    _oData.CMPercText = Convert.ToString(Math.Round((oData.MTDValue / oData.CMTValue) * 100));
                //else 
                //    _oData.CMPercText = "0";

                //if (oData.MTDTValue > 0)
                //    _oData.MTDPercText = Convert.ToString(Math.Round((oData.MTDValue / oData.MTDTValue) * 100));
                //else
                //    _oData.MTDPercText = "0";

                //if (oData.LMTValue > 0)
                //    _oData.LMPercText = Convert.ToString(Math.Round((oData.LMValue / oData.LMTValue) * 100));
                //else
                //    _oData.LMPercText = "0";

               

                //_oData.LMTarText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMTValue)); 
                //_oData.LMText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMValue)); 

               
                //_oData.YTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue)); 
                //_oData.LYYTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTDValue)); 
                //_oData.LYText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYValue));

                //if (oData.LYYTDValue > 0)
                //    _oData.YTDGthPercText = Convert.ToString(Math.Round(((oData.YTDValue / oData.LYYTDValue) * 100) - 100));
                //else
                //    _oData.YTDGthPercText = "0";

                //if (oData.YBLYValue > 0)
                //    _oData.YBLYGthPercText = Convert.ToString(Math.Round(((oData.LYValue / oData.YBLYValue) * 100) - 100));
                //else
                //    _oData.YBLYGthPercText = "0";

                _oData.Value = "Success";
                eList.Add(_oData);
            }


            return eList;

        }

    }
}

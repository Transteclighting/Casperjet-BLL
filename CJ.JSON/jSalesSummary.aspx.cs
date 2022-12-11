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

public partial class jSalesSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();

            //string sUser = "hakim";
            //string sCompany = "TEL";

            string sDatabase = "x";
            if (sCompany == "TEL")
            {
                sDatabase = "TELSysDB";
            }
            else if (sCompany == "TML")
            {
                sDatabase = "TMLSysDB";
            }
            if (sCompany == "TEL")
            {
                Data _oData = new Data();
                _oData.InsertReportLog(sUser);
            }
            Datas _oDatas = new Datas();
            DBController.Instance.OpenNewConnection();
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(sCompany, sDatabase), Formatting.Indented);
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
            string sReportCode = "A10001";
            string sReportName = "Sales Summary";
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

        public List<Data> getResult(string sCompany, string sDatabase)
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            TEL _oTEL = new TEL();
            List<Data> eList = new List<Data>();

            DateTime dFromDate = DateTime.Now.Date;
           
            int nThisYear = dFromDate.Year;
            int nThisMonth = dFromDate.Month;

            DateTime dLastMonth = dFromDate.AddMonths(-1);
            int nLastYear = dLastMonth.Year;
            int nLastMonth = dLastMonth.Month;

            DateTime LastDayOfMonth = _oTELLib.LastDayofMonth(dFromDate);
            int nLastDayCM = LastDayOfMonth.Day;
            int nDay = dFromDate.Day;

            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);
            //DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(dFromDate);
            //DateTime _FirstDayofLastMonth = _oTELLib.FirstDayofLastMonth(dFromDate);

            //DateTime _FirstDayofThisYear = _oTELLib.FirstDayofThisYear(dFromDate);
            //DateTime _FirstDayofLastYear = _FirstDayofThisYear.AddYears(-1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            //sSQL = "Select Type, Name, DTD, LD, MTD, LM, YTD, LY, LYYTD, YBLY from DWDB.dbo.t_ChannelSalesSummary Where Company='" + sCompany + "' Order by ID";

            //sSQL = " Select 'Type1' as Type, 'National' as Name, Sum(DTD) DTD, Sum(LD)LD, Sum(MTD) as MTD, Sum(LM) as LM, Sum(YTD) as YTD, Sum(LY) as LY, Sum(LYYTD) as LYYTD, Sum(YBLY) as YBLY from " +
            //    "( " +
            //    "Select DTD, LD, MTD, LM, YTD, LY, LYYTD, YBLY from DWDB.dbo.t_ChannelSalesSummary Where Name = 'TD' and Company = '" + sCompany + "' " +
            //    "UNION ALL " +
            //    "Select DTD, LD, MTD, LM, YTD, LY, LYYTD, YBLY from DWDB.dbo.t_ChannelSalesSummary Where Name = 'Others' and Company = 'TEL' " +
            //    ")x " +
            //    "UNION ALL " +
            //    "Select Type, Name, DTD, LD, MTD, LM, YTD, LY, LYYTD, YBLY from DWDB.dbo.t_ChannelSalesSummary Where Name NOT IN('CAC', 'National') and Company = '" + sCompany + "'";

            sSQL = " Select 'Type1' as Type, 'National' as Name, Sum(DTD) DTD, Sum(LD)LD, Sum(MTD) as MTD, Sum(LM) as LM, Sum(YTD) as YTD, Sum(LY) as LY, Sum(LYYTD) as LYYTD, Sum(YBLY) as YBLY " +
            "from(Select DTD, LD, MTD, LM, YTD, LY, LYYTD, YBLY from DWDB.dbo.t_ChannelSalesSummary " +
            "Where Name = 'TD' and Company = 'TEL' UNION ALL Select DTD, LD, MTD, LM, YTD, LY, LYYTD, YBLY " +
            "from DWDB.dbo.t_ChannelSalesSummary Where Name = 'Others' and Company = '" + sCompany + "')x " +
            "UNION ALL " +
            "Select Type, Name, DTD, LD, MTD, LM, YTD, LY, LYYTD, YBLY from DWDB.dbo.t_ChannelSalesSummary " +
            "Where Name IN('TD', 'Retail', 'B2B') and Company = '" + sCompany + "' ";
            if(sCompany == "TEL")
            {
                sSQL += "UNION ALL " +
                "Select 'Type2' as Type, 'Retail+B2B' as Name, Sum(DTD) as DTD, Sum(LD) as LD, Sum(MTD) as MTD,  " +
                "Sum(LM) as LM, Sum(YTD) as YTD, Sum(LY) as LY, Sum(LYYTD) as LYYTD, Sum(YBLY) as YBLY from DWDB.dbo.t_ChannelSalesSummary " +
                "Where Name IN('Retail', 'B2B') and Company = '" + sCompany + "' ";
            }
            sSQL += "UNION ALL " +
            "Select Type, Name, DTD, LD, MTD, LM, YTD, LY, LYYTD, YBLY from DWDB.dbo.t_ChannelSalesSummary " +
            "Where Name IN('Dealer', 'Others') and Company = '" + sCompany + "' ";


            double TDMTDTarget = 0;
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oData = new Data();
                    _oData.Name = (string)reader["Name"];
                    _oData.Type = (string)reader["Type"];
                    _oData.DTDText = ExcludeDecimal(_oTELLib.TakaFormat(Convert.ToDouble(reader["DTD"])));
                    _oData.LDText = ExcludeDecimal(_oTELLib.TakaFormat(Convert.ToDouble(reader["LD"])));

                    if (sCompany == "TEL")
                    {
                        if (_oData.Name == "National")
                        {
                            GetTarget("TEL", "");

                            //CMTarget = GetTargetTotalTEL(dFromDate);
                            //LMTarget = GetTargetTotalTEL(dLastMonth);

                            //double temp = GetTargetTD("TEL", "MTDT");

                            //double temp1 = GetTargetTEL(dFromDate, "CAC");
                            //CMTarget = CMTarget + temp1;

                            //temp1 = Math.Round(temp1 / nLastDayCM * nDay, 0);
                            //MTDTarget = MTDTarget + temp1;

                            //LMTarget = LMTarget + GetTargetTEL(dLastMonth, "CAC");
                           
                        }
                        else if (_oData.Name == "TD")
                        {
                            //LMTarget = GetTargetTD("TEL", "LMT");
                            //CMTarget = GetTargetTD("TEL", "CMT");
                            //MTDTarget = GetTargetTD("TEL", "MTDT");
                            //TDMTDTarget = MTDTarget;
                            GetTarget("TEL", "");
                        }
                        else if (_oData.Name == "Retail")
                        {
                            //LMTarget = GetTargetTD("TEL", "LMT");
                            //CMTarget = GetTargetTD("TEL", "CMT");
                            //double temp = GetB2BDealerTarget(nThisYear, nThisMonth);
                            //CMTarget = CMTarget - temp;
                            //temp = Math.Round(temp / nLastDayCM * nDay,0);
                            //MTDTarget = TDMTDTarget - temp;


                            //double temp1 = GetB2BDealerTarget(nLastYear, nLastMonth);
                            //LMTarget = LMTarget - temp1;
                            GetTarget("TEL", "Retail");
                            
                        }
                        else if (_oData.Name == "B2B")
                        {
                            GetTarget("TEL", "B2B");
                        }
                        else if (_oData.Name == "Retail+B2B")
                        {
                            GetTarget("TEL", "Retail','B2B");
                        }
                        else if (_oData.Name == "Dealer")
                        {
                            GetTarget("TEL", "Dealer");
                   
                        }
                        else if (_oData.Name == "CAC")
                        {
                            LMTarget = GetTargetTEL(dLastMonth, _oData.Name);
                            CMTarget = GetTargetTEL(dFromDate, _oData.Name);
                            MTDTarget = Math.Round(CMTarget / nLastDayCM * nDay, 0);
                        }
                        else
                        {
                            LMTarget = GetTargetTEL(dLastMonth, _oData.Name);
                            CMTarget = GetTargetTEL(dFromDate, _oData.Name);
                            MTDTarget = Math.Round(CMTarget / nLastDayCM * nDay, 0);
                        }
                    }
                    else
                    {
                        if (_oData.Name == "National")
                        {
                            GetTarget("TML", "");
                            //LMTarget = GetTargetTDTML(nLastYear, nLastMonth);
                            //CMTarget = GetTargetTDTML(nThisYear, nThisMonth);
                        }
                        else if (_oData.Name == "TD")
                        {
                            GetTarget("TML", "");
                            //LMTarget = GetTargetTD("TML", "LMT");
                            //CMTarget = GetTargetTD("TML", "CMT");
                        }
                        else if (_oData.Name == "Retail")
                        {
                            GetTarget("TML", "Retail");
                        }
                        else if (_oData.Name == "B2B")
                        {
                            GetTarget("TML", "B2B");
                        }
                    }
                    double _LMActual = Convert.ToDouble(reader["LM"]);
                    _oData.LMText = ExcludeDecimal(_oTELLib.TakaFormat(_LMActual));

                    
                    _oData.LMTarText = ExcludeDecimal(_oTELLib.TakaFormat(LMTarget));

                    if (LMTarget > 0)
                    {
                        _oData.LMPercText = Convert.ToString(Math.Round((_LMActual / LMTarget) * 100));
                    }
                    else
                    {
                        _oData.LMPercText = "0";
                    }


                    double _MTDActual = Convert.ToDouble(reader["MTD"]);
                    _oData.MTDText = ExcludeDecimal(_oTELLib.TakaFormat(_MTDActual));

                    
                    _oData.CMTarText = ExcludeDecimal(_oTELLib.TakaFormat(CMTarget));
                    if (CMTarget > 0)
                    {
                        _oData.CMPercText = Convert.ToString(Math.Round((_MTDActual / CMTarget) * 100));
                    }
                    else
                    {
                        _oData.CMPercText = "0";
                    }
                    double _MTDTarget = 0;
                    if (CMTarget > 0)
                    {
                        _MTDTarget = MTDTarget;
                        _oData.MTDTarText = ExcludeDecimal(_oTELLib.TakaFormat(_MTDTarget));
                    }
                    else
                    {
                        _oData.MTDTarText = "0";
                    }
                    if (_MTDTarget > 0)
                    {
                        _oData.MTDPercText = Convert.ToString(Math.Round((_MTDActual / _MTDTarget) * 100));
                    }
                    else
                    {
                        _oData.MTDPercText = "0";
                    }

                    _oData.YTDText = ExcludeDecimal(_oTELLib.TakaFormat(Convert.ToDouble(reader["YTD"])));
                    _oData.LYYTDText = ExcludeDecimal(_oTELLib.TakaFormat(Convert.ToDouble(reader["LYYTD"])));
                    _oData.LYText = ExcludeDecimal(_oTELLib.TakaFormat(Convert.ToDouble(reader["LY"])));

                    double _YTD = Convert.ToDouble(reader["YTD"]);
                    double _LYYTD = Convert.ToDouble(reader["LYYTD"]);
                    double _YBLY = Convert.ToDouble(reader["YBLY"]);
                    double _LY = Convert.ToDouble(reader["LY"]);

                    if (_LYYTD > 0)
                    {
                        _oData.YTDGthPercText = Convert.ToString(Math.Round(((_YTD / _LYYTD) * 100) - 100));
                    }
                    else
                    {
                        _oData.YTDGthPercText = "0";
                    }

                    if (_YBLY > 0)
                    {
                        _oData.YBLYGthPercText = Convert.ToString(Math.Round(((_LY / _YBLY) * 100) - 100));
                    }
                    else
                    {
                        _oData.YBLYGthPercText = "0";
                    }
                    //

                    _oData.Value = "Success";
                    eList.Add(_oData);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }

          
            return eList;

        }

        public double GetTarget(string sCompany, string sChannel)
        {
            double _Value = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";

            sSQL = " Select Sum(CMTarget) as CMTarget, Sum(MTDTarget) as MTDTarget, Sum(LMTarget) as LMTarget "+
                   " from DWDB.dbo.t_OutletChannelSales Where Company = '" + sCompany + "' ";

            if (sChannel != "")
            {
                sSQL = sSQL + " and Channel IN ('" + sChannel + "') ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    CMTarget = Convert.ToDouble(reader["CMTarget"]);
                    MTDTarget = Convert.ToDouble(reader["MTDTarget"]);
                    LMTarget = Convert.ToDouble(reader["LMTarget"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return _Value;
        }

        public double GetTargetTD(string sCompany, string sType)
        {
            double _Value = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = "Select Sum(CMTarget) as CMTarget, Sum(MTDTarget) as MTDTarget, Sum(LastMonthTarget) as LastMonthTarget from DWDB.dbo.t_OutletSales Where Company='" + sCompany + "' ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (sType == "CMT")
                    {
                        _Value = Convert.ToDouble(reader["CMTarget"]);
                    }
                    else if (sType == "MTDT")
                    {
                        _Value = Convert.ToDouble(reader["MTDTarget"]);
                    }
                    else if (sType == "LMT")
                    {
                        _Value = Convert.ToDouble(reader["LastMonthTarget"]);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return _Value;
        }

        public double GetB2BDealerTarget(int nYear, int nMonth)
        {
            double _Value = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = "Select Sum(Value) as Value from TELSysDB.dbo.t_PlanMonthChannelTarget Where Year=" + nYear + " and Month=" + nMonth + " and Channel IN ('B2B','Dealer') ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Value = Convert.ToDouble(reader["Value"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return _Value;
        }

        public double GetTargetTEL(DateTime _Date, string sChannel)
        {
            double _Value = 0;
            int nYear  =_Date.Year;
            int nMonth = _Date.Month;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = "Select Value from TELSysDB.dbo.t_PlanMonthChannelTarget Where Year=" + nYear + " and Month=" + nMonth + " and Channel='" + sChannel + "'";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Value = Convert.ToDouble(reader["Value"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return _Value;
        }
        
        public double GetTargetTotalTEL(DateTime _Date)
        {
            int nYear = _Date.Year;
            int nMonth = _Date.Month;
            double _Value = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = " Select Sum(TargetValue) as Value from TELSysDB.dbo.t_PlanMAGWeekTargetQty Where TYear=" + nYear + " and TMonth=" + nMonth + " ";
                  

       //     sSQL = "Select Sum(Value) as Value from " +
       //" ( " +
       //" Select Sum(TargetValue) as Value from TELSysDB.dbo.t_PlanMAGWeekTargetQty Where TYear=" + nYear + " and TMonth=" + nMonth + " " +
       //" UNION ALL " +
       //" Select Value from TELSysDB.dbo.t_PlanMonthChannelTarget Where Year=" + nYear + " and Month=" + nMonth + " and Channel ='CAC' " +
       //" )x";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Value = Convert.ToDouble(reader["Value"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return _Value;
        }
        
        public double GetTargetTDTEL(int nYear, int nMonth)
        {
            double _Value = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = "Select Sum(TargetValue) as Value from TELSysDB.dbo.t_PlanMAGWeekTargetQty Where TYear=" + nYear + " and TMonth=" + nMonth + "";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Value = Convert.ToDouble(reader["Value"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return _Value;
        }
        
        public double GetTargetTDTML(int nYear, int nMonth)
        {
            double _Value = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = "Select Sum(TargetAmount) as Value from TMLSysDB.dbo.t_PlanExecutiveWeekTarget Where TYear=" + nYear + " and Category='Mobile' and TMonth=" + nMonth + "";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Value = Convert.ToDouble(reader["Value"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return _Value;
        }
    }
}

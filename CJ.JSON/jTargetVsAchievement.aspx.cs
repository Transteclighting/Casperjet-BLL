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
using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.ANDROID;

public partial class jTargetVsAchievement : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sType = c.Request.Form["Type"].Trim();
            //string sCompany = "TEL";
            //string sType = "Weekly";
            string sDatabase = "x";

            if (sCompany == "TEL")
            {
                sDatabase = "TELSysDB";
            }
            else if (sCompany == "TML")
            {
                sDatabase = "TMLSysDB";
            }

            Datas oDatas = new Datas();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oDataArea = new Data();
            Data _oDataZone = new Data();
            Data _oDataOutlet = new Data();
            int nCount = 0;

            DBController.Instance.OpenNewConnection();
            if (sType == "Weekly")
            {
                oDatas.GetData(sCompany, sDatabase);
            }
            DBController.Instance.CloseConnection();

            foreach (Data oData in oDatas)
            {
                if (nCount == 0)
                {
                    _oDataTotal = new Data();
                    _oDatas.Add(_oDataTotal);
                    _oDataTotal.Outlet = "Total";
                    _oDataTotal.Type = "Total";
                    _oDataTotal.Value = "Success";

                    _oDataTotal.LastStartYear = oData.LastStartYear;
                    _oDataTotal.LastStartMonth = oData.LastStartMonth;
                    _oDataTotal.LastStartDay = oData.LastStartDay;
                    _oDataTotal.LastEndDay = oData.LastEndDay;
                    _oDataTotal.ThisWeekNo = oData.ThisWeekNo;
                    _oDataTotal.ThisMonthNo = oData.ThisMonthNo;
                    _oDataTotal.ThisYearNo = oData.ThisYearNo;
                    _oDataTotal.ThisStartDay = oData.ThisStartDay;
                    _oDataTotal.ThisEndDay = oData.ThisEndDay;

                    nCount++;
                }
                if (_oDataArea.AreaName != oData.AreaName)
                {
                    _oDataArea = new Data();
                    _oDatas.Add(_oDataArea);
                    _oDataArea.AreaName = oData.AreaName;
                    _oDataArea.Outlet = oData.AreaName;
                    _oDataArea.Type = "Area";
                    _oDataArea.Value = "Success";

                    _oDataArea.LastStartYear = oData.LastStartYear;
                    _oDataArea.LastStartMonth = oData.LastStartMonth;
                    _oDataArea.LastStartDay = oData.LastStartDay;
                    _oDataArea.LastEndDay = oData.LastEndDay;
                    _oDataArea.ThisWeekNo = oData.ThisWeekNo;
                    _oDataArea.ThisMonthNo = oData.ThisMonthNo;
                    _oDataArea.ThisYearNo = oData.ThisYearNo;
                    _oDataArea.ThisStartDay = oData.ThisStartDay;
                    _oDataArea.ThisEndDay = oData.ThisEndDay;
                }
                if (_oDataZone.TerritoryName != oData.TerritoryName)
                {
                    _oDataZone = new Data();
                    _oDatas.Add(_oDataZone);
                    _oDataZone.TerritoryName = oData.TerritoryName;
                    _oDataZone.Outlet = oData.TerritoryName;
                    _oDataZone.Type = "Zone";
                    _oDataZone.Value = "Success";

                    _oDataZone.LastStartYear = oData.LastStartYear;
                    _oDataZone.LastStartMonth = oData.LastStartMonth;
                    _oDataZone.LastStartDay = oData.LastStartDay;
                    _oDataZone.LastEndDay = oData.LastEndDay;
                    _oDataZone.ThisWeekNo = oData.ThisWeekNo;
                    _oDataZone.ThisMonthNo = oData.ThisMonthNo;
                    _oDataZone.ThisYearNo = oData.ThisYearNo;
                    _oDataZone.ThisStartDay = oData.ThisStartDay;
                    _oDataZone.ThisEndDay = oData.ThisEndDay;
                }

                _oDataOutlet = new Data();
                _oDataOutlet.Value = "Success";

                _oDataOutlet.Outlet = oData.Outlet;
                _oDataOutlet.MTLWTarAmt = oData.MTLWTarAmt;
                _oDataOutlet.MTLWAchAmt = oData.MTLWAchAmt;
                _oDataOutlet.CWTarAmt = oData.CWTarAmt;
                _oDataOutlet.WTDTarAmt = oData.WTDTarAmt;
                _oDataOutlet.WTDAchAmt = oData.WTDAchAmt;
                _oDataOutlet.Type = "Outlet";

                _oDataOutlet.LastStartYear = oData.LastStartYear;
                _oDataOutlet.LastStartMonth = oData.LastStartMonth;
                _oDataOutlet.LastStartDay = oData.LastStartDay;
                _oDataOutlet.LastEndDay = oData.LastEndDay;
                _oDataOutlet.ThisWeekNo = oData.ThisWeekNo;
                _oDataOutlet.ThisMonthNo = oData.ThisMonthNo;
                _oDataOutlet.ThisYearNo = oData.ThisYearNo;
                _oDataOutlet.ThisStartDay = oData.ThisStartDay;
                _oDataOutlet.ThisEndDay = oData.ThisEndDay;

                _oDatas.Add(_oDataOutlet);

                _oDataTotal.MTLWTarAmt = _oDataTotal.MTLWTarAmt + oData.MTLWTarAmt;
                _oDataTotal.MTLWAchAmt = _oDataTotal.MTLWAchAmt + oData.MTLWAchAmt;
                _oDataTotal.CWTarAmt = _oDataTotal.CWTarAmt + oData.CWTarAmt;
                _oDataTotal.WTDTarAmt = _oDataTotal.WTDTarAmt + oData.WTDTarAmt;
                _oDataTotal.WTDAchAmt = _oDataTotal.WTDAchAmt + oData.WTDAchAmt;

                _oDataArea.MTLWTarAmt = _oDataArea.MTLWTarAmt + oData.MTLWTarAmt;
                _oDataArea.MTLWAchAmt = _oDataArea.MTLWAchAmt + oData.MTLWAchAmt;
                _oDataArea.CWTarAmt = _oDataArea.CWTarAmt + oData.CWTarAmt;
                _oDataArea.WTDTarAmt = _oDataArea.WTDTarAmt + oData.WTDTarAmt;
                _oDataArea.WTDAchAmt = _oDataArea.WTDAchAmt + oData.WTDAchAmt;

                _oDataZone.MTLWTarAmt = _oDataZone.MTLWTarAmt + oData.MTLWTarAmt;
                _oDataZone.MTLWAchAmt = _oDataZone.MTLWAchAmt + oData.MTLWAchAmt;
                _oDataZone.CWTarAmt = _oDataZone.CWTarAmt + oData.CWTarAmt;
                _oDataZone.WTDTarAmt = _oDataZone.WTDTarAmt + oData.WTDTarAmt;
                _oDataZone.WTDAchAmt = _oDataZone.WTDAchAmt + oData.WTDAchAmt;
            }
            if (sCompany == "TEL")
            {
                if (sType == "Weekly")
                {
                    _oData.InsertReportLog(sUser);
                }
            }
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());
            
        }
    }
    public class Data
    {
        public string AreaName;
        public string TerritoryName;
        public string Type;
        public string Outlet;

        public string LastStartYear;
        public string LastStartMonth;
        public string LastStartDay;
        public string LastEndDay;
        public string ThisWeekNo;
        public string ThisMonthNo;
        public string ThisYearNo;
        public string ThisStartDay;
        public string ThisEndDay;

        public double MTLWTarAmt;
        public double MTLWAchAmt;
        public double CWTarAmt;
        public double WTDTarAmt;
        public double WTDAchAmt;

        public string MTLWTarAmtText;
        public string MTLWAchAmtText;
        public string CWTarAmtText;
        public string WTDTarAmtText;
        public string WTDAchAmtText;

        public string LPercent;
        public string ShortFallPercent;
        public string CPercent;
        public string WTDPercent;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10012";
            string sReportName = "Target-Vs-Achievement";
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
        public void GetData(string sCompany, string sDatabase)
        {
            TELLib _oTELLib = new TELLib();
            DSTarVsAch oDSOutlet = new DSTarVsAch();
            DSTarVsAch oDSMonthToLastWkTar = new DSTarVsAch();
            DSTarVsAch oDSMonthToLastWkAch = new DSTarVsAch();
            DSTarVsAch oDSThisWkTar = new DSTarVsAch();
            DSTarVsAch oDSWTDTar = new DSTarVsAch();
            DSTarVsAch oDSWTDAch = new DSTarVsAch();

            DateTime dToday = DateTime.Now.Date;

            DateTime dThisWeekStartDate = GetWeekStartDate(dToday);
            DateTime dLastDateOfLastWeek = dThisWeekStartDate.AddDays(-1);
            DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(dLastDateOfLastWeek);
            int nLastYear = _FirstDayofMonth.Year;
            int nLastMonth = _FirstDayofMonth.Month;
            int nLastStartDay = _FirstDayofMonth.Day;
            int nLastEndDay = dLastDateOfLastWeek.Day;

            DateTime dThisWeekEndDate = GetWeekLastDate(dToday);
            int nThisYear = dThisWeekStartDate.Year;
            int nThisMonth = dThisWeekStartDate.Month;
            int nThisStartDay = dThisWeekStartDate.Day;
            int nThisEndDay = dThisWeekEndDate.Day;

            int nWeekNo = GetWeekNo(dToday);
            TimeSpan _Day = dThisWeekEndDate - dThisWeekStartDate;
            int WeekDays = (int)_Day.TotalDays + 1;

            TimeSpan Day = dToday - dThisWeekStartDate;
            int WeekToDays = (int)Day.TotalDays + 1;

            string sSQL = "";
            #region Outlet 
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSQL = " Select right(AreaName,6) as AreaName, right(TerritoryName,6) as TerritoryName,Outlet, WarehouseID " +
                   " from  " +
                   " (  " +
                   " Select ShowroomCode as Outlet, AreaName, TerritoryName, WarehouseID from " + sDatabase + ".dbo.t_Showroom a " +
                   " INNER JOIN  " +
                   " (select CustomerID, left(AreaName,9) as AreaName, left(TerritoryName,9) as TerritoryName from  " +
                   " DWDB.dbo.t_CustomerDetails Where CompanyName='" + sCompany + "')b  " +
                   " ON a.CustomerID=b.CustomerID  " +
                   " Where IsPOSActive=1  " +
                   " )a order by AreaName, TerritoryName, Outlet";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSTarVsAch.TarVsAchRow oTarVsAchRow = oDSOutlet.TarVsAch.NewTarVsAchRow();

                    oTarVsAchRow.Area = reader["AreaName"].ToString();
                    oTarVsAchRow.Territory = reader["TerritoryName"].ToString();
                    oTarVsAchRow.Outlet = reader["Outlet"].ToString();
                    oTarVsAchRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    oTarVsAchRow.LastStartYear = nLastYear.ToString();
                    oTarVsAchRow.LastStartMonth = nLastMonth.ToString();
                    oTarVsAchRow.LastStartDay = nLastStartDay.ToString();
                    oTarVsAchRow.LastEndDay = nLastEndDay.ToString();
                    oTarVsAchRow.ThisWeekNo = nWeekNo.ToString();
                    oTarVsAchRow.ThisMonthNo = nThisMonth.ToString();
                    oTarVsAchRow.ThisYearNo = nThisYear.ToString();
                    oTarVsAchRow.ThisStartDay = nThisStartDay.ToString();
                    oTarVsAchRow.ThisEndDay = nThisEndDay.ToString();

                    oDSOutlet.TarVsAch.AddTarVsAchRow(oTarVsAchRow);
                    oDSOutlet.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region Month to Last week Target
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " select WarehouseID, Sum(TargetAmount) as TargetAmount from " + sDatabase + ".dbo.t_PlanExecutiveWeekTarget a, " +
                   " " + sDatabase + ".dbo.t_Showroom b Where  b.CustomerID = a.CustomerID and TYear=" + nLastYear + " and TMonth=" + nLastMonth + " and WeekNo IN " +
                   " (Select WeekNo from TELSysDB.dbo.t_CalendarWeek where FromDate between '" + _FirstDayofMonth + "' and '" + dLastDateOfLastWeek + "') " +
                   " Group by WarehouseID ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSTarVsAch.TarVsAchRow oTarVsAchRow = oDSMonthToLastWkTar.TarVsAch.NewTarVsAchRow();

                    oTarVsAchRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    oTarVsAchRow.Amount = reader["TargetAmount"].ToString();

                    oDSMonthToLastWkTar.TarVsAch.AddTarVsAchRow(oTarVsAchRow);
                    oDSMonthToLastWkTar.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region Month to Last week Ach
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " select a.WarehouseID, Sum(NetSale) as SaleVal from DWDB.dbo.t_SalesDataCustomerProduct a,  " +
                   " " + sDatabase + ".dbo.t_Showroom b Where b.WarehouseID=a.WarehouseID and  " +
                   " InvoiceDate between '" + _FirstDayofMonth + "' and '" + dLastDateOfLastWeek + "' and CompanyName='" + sCompany + "'  " +
                   " group by  a.WarehouseID ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSTarVsAch.TarVsAchRow oTarVsAchRow = oDSMonthToLastWkAch.TarVsAch.NewTarVsAchRow();

                    oTarVsAchRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    oTarVsAchRow.Amount = reader["SaleVal"].ToString();

                    oDSMonthToLastWkAch.TarVsAch.AddTarVsAchRow(oTarVsAchRow);
                    oDSMonthToLastWkAch.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region This Week Target
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " select WarehouseID, Sum(TargetAmount) as TargetAmount from " + sDatabase + ".dbo.t_PlanExecutiveWeekTarget a, " +
                   " " + sDatabase + ".dbo.t_Showroom b Where  b.CustomerID=a.CustomerID and TYear=" + nThisYear + " and TMonth=" + nThisMonth + " and WeekNo=" + nWeekNo + " Group by WarehouseID ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSTarVsAch.TarVsAchRow oTarVsAchRow = oDSThisWkTar.TarVsAch.NewTarVsAchRow();

                    oTarVsAchRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    oTarVsAchRow.Amount = reader["TargetAmount"].ToString();

                    oDSThisWkTar.TarVsAch.AddTarVsAchRow(oTarVsAchRow);
                    oDSThisWkTar.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region WTD Target
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select WarehouseID, CASE When TargetAmount > 0 then (TargetAmount / " + WeekDays + " * " + WeekToDays + ")else 0 end as TargetAmount from " +
                   " ( " +
                   " select WarehouseID, Sum(TargetAmount) as TargetAmount from " + sDatabase + ".dbo.t_PlanExecutiveWeekTarget a,  " +
                   " " + sDatabase + ".dbo.t_Showroom b Where  b.CustomerID=a.CustomerID and TYear=" + nThisYear + " and TMonth=" + nThisMonth + " and WeekNo=" + nWeekNo + " " +
                   " Group by WarehouseID)a";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSTarVsAch.TarVsAchRow oTarVsAchRow = oDSWTDTar.TarVsAch.NewTarVsAchRow();

                    oTarVsAchRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    oTarVsAchRow.Amount = reader["TargetAmount"].ToString();

                    oDSWTDTar.TarVsAch.AddTarVsAchRow(oTarVsAchRow);
                    oDSWTDTar.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
             #endregion
            #region WTD Ach
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " select a.WarehouseID, Sum(NetSale) as SaleVal from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                   " " + sDatabase + ".dbo.t_Showroom b Where b.WarehouseID=a.WarehouseID and  " +
                   " InvoiceDate between '" + dThisWeekStartDate + "' and '" + dThisWeekEndDate + "' and CompanyName='" + sCompany + "'  " +
                   " group by  a.WarehouseID ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSTarVsAch.TarVsAchRow oTarVsAchRow = oDSWTDAch.TarVsAch.NewTarVsAchRow();

                    oTarVsAchRow.WarehouseID = Convert.ToInt32(reader["WarehouseID"]);
                    oTarVsAchRow.Amount = reader["SaleVal"].ToString();

                    oDSWTDAch.TarVsAch.AddTarVsAchRow(oTarVsAchRow);
                    oDSWTDAch.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion

            Data _oData;
            InnerList.Clear();

            foreach (DSTarVsAch.TarVsAchRow oTarVsAchRow in oDSOutlet.TarVsAch)
            {

                _oData = new Data();
                _oData.AreaName = oTarVsAchRow.Area;
                _oData.TerritoryName = oTarVsAchRow.Territory;
                _oData.Outlet = oTarVsAchRow.Outlet;

                _oData.LastStartYear = oTarVsAchRow.LastStartYear;
                _oData.LastStartMonth = oTarVsAchRow.LastStartMonth;
                _oData.LastStartDay = oTarVsAchRow.LastStartDay;
                _oData.LastEndDay = oTarVsAchRow.LastEndDay;
                _oData.ThisWeekNo = oTarVsAchRow.ThisWeekNo;
                _oData.ThisMonthNo = oTarVsAchRow.ThisMonthNo;
                _oData.ThisYearNo = oTarVsAchRow.ThisYearNo;
                _oData.ThisStartDay = oTarVsAchRow.ThisStartDay;
                _oData.ThisEndDay = oTarVsAchRow.ThisEndDay;

                //Month to Last Week Target
                DSTarVsAch oDSFilteredMTLWTar = new DSTarVsAch();
                DataRow[] oDRMTLWTar = oDSMonthToLastWkTar.TarVsAch.Select(" WarehouseID= " + oTarVsAchRow.WarehouseID + "");
                oDSFilteredMTLWTar.Merge(oDRMTLWTar);
                oDSFilteredMTLWTar.AcceptChanges();

                foreach (DSTarVsAch.TarVsAchRow oMTLWTarVsAchRowRow in oDSFilteredMTLWTar.TarVsAch)
                {
                    _oData.MTLWTarAmt = Convert.ToDouble(oMTLWTarVsAchRowRow.Amount);
                }

                //Month To Last Week Ach
                DSTarVsAch oDSFilteredMTLWAch = new DSTarVsAch();
                DataRow[] oDRMTLWAch = oDSMonthToLastWkAch.TarVsAch.Select(" WarehouseID= " + oTarVsAchRow.WarehouseID + "");
                oDSFilteredMTLWAch.Merge(oDRMTLWAch);
                oDSFilteredMTLWAch.AcceptChanges();

                foreach (DSTarVsAch.TarVsAchRow oMTLWAchTarVsAchRowRow in oDSFilteredMTLWAch.TarVsAch)
                {
                    _oData.MTLWAchAmt = Convert.ToDouble(oMTLWAchTarVsAchRowRow.Amount);
                }

                //This Week Target
                DSTarVsAch oDSFilteredThisWeekTar = new DSTarVsAch();
                DataRow[] oDRThisWkTar = oDSThisWkTar.TarVsAch.Select(" WarehouseID= " + oTarVsAchRow.WarehouseID + "");
                oDSFilteredThisWeekTar.Merge(oDRThisWkTar);
                oDSFilteredThisWeekTar.AcceptChanges();

                foreach (DSTarVsAch.TarVsAchRow oThisWkTarRow in oDSFilteredThisWeekTar.TarVsAch)
                {
                    _oData.CWTarAmt = Convert.ToDouble(oThisWkTarRow.Amount);
                }
                //Week To Date Target
                DSTarVsAch oDSFilteredWTDTar = new DSTarVsAch();
                DataRow[] oDRWTDTar = oDSWTDTar.TarVsAch.Select(" WarehouseID= " + oTarVsAchRow.WarehouseID + "");
                oDSFilteredWTDTar.Merge(oDRWTDTar);
                oDSFilteredWTDTar.AcceptChanges();

                foreach (DSTarVsAch.TarVsAchRow oWTDTarRow in oDSFilteredWTDTar.TarVsAch)
                {
                    _oData.WTDTarAmt = Convert.ToDouble(oWTDTarRow.Amount);
                }
                //Week to Date Ach
                DSTarVsAch oDSFilteredWTDAch = new DSTarVsAch();
                DataRow[] oDRWTDAch = oDSWTDAch.TarVsAch.Select(" WarehouseID= " + oTarVsAchRow.WarehouseID + "");
                oDSFilteredWTDAch.Merge(oDRWTDAch);
                oDSFilteredWTDAch.AcceptChanges();

                foreach (DSTarVsAch.TarVsAchRow oWTDAchRow in oDSFilteredWTDAch.TarVsAch)
                {
                    _oData.WTDAchAmt = Convert.ToDouble(oWTDAchRow.Amount);
                }

                InnerList.Add(_oData);
            }
            

        }
        private DateTime GetWeekStartDate(DateTime dDate)
        {
            DateTime _Date = DateTime.Today;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = " select CYear, CMonth, WeekNo, FromDate, ToDate from TELSysDB.dbo.t_CalendarWeek where '" + dDate + "' between FromDate and ToDate ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Date = Convert.ToDateTime(reader["FromDate"]);

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _Date;
        }
        private DateTime GetWeekLastDate(DateTime dDate)
        {
            DateTime _Date = DateTime.Today;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = " select CYear, CMonth, WeekNo, FromDate, ToDate from TELSysDB.dbo.t_CalendarWeek where '" + dDate + "' between FromDate and ToDate ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Date = Convert.ToDateTime(reader["ToDate"]);

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _Date;
        }
        private int GetWeekNo(DateTime dDate)
        {
            int nWeekNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = " select CYear, CMonth, WeekNo, FromDate, ToDate from TELSysDB.dbo.t_CalendarWeek where '" + dDate + "' between FromDate and ToDate ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nWeekNo = Convert.ToInt32(reader["WeekNo"]);

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return nWeekNo;
        }
        public List<Data> getResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.Outlet = oData.Outlet;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;

                _oData.LastStartYear = oData.LastStartYear;
                _oData.LastStartMonth = oData.LastStartMonth;
                _oData.LastStartDay = oData.LastStartDay;
                _oData.LastEndDay = oData.LastEndDay;
                _oData.ThisWeekNo = oData.ThisWeekNo;
                _oData.ThisMonthNo = oData.ThisMonthNo;
                _oData.ThisYearNo = oData.ThisYearNo;
                _oData.ThisStartDay = oData.ThisStartDay;
                _oData.ThisEndDay = oData.ThisEndDay;

                _oData.MTLWTarAmtText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTLWTarAmt));
                _oData.MTLWAchAmtText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTLWAchAmt));
                _oData.CWTarAmtText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CWTarAmt));
                _oData.WTDTarAmtText = ExcludeDecimal(_oTELLib.TakaFormat(oData.WTDTarAmt));
                _oData.WTDAchAmtText = ExcludeDecimal(_oTELLib.TakaFormat(oData.WTDAchAmt));

                if (oData.MTLWTarAmt > 0)
                {
                    _oData.LPercent = (Math.Round((oData.MTLWAchAmt / oData.MTLWTarAmt) * 100)).ToString();
                }
                else
                {
                    _oData.LPercent = "0";
                }
                if (oData.MTLWTarAmt > 0)
                {
                    double temp = Math.Round((oData.MTLWAchAmt / oData.MTLWTarAmt) * 100);
                    if (temp < 100)
                    {
                        _oData.ShortFallPercent = (Math.Round(100 - temp)).ToString();
                    }
                    else
                    {
                        _oData.ShortFallPercent = "0";
                    }
                }
                else
                {
                    _oData.LPercent = "0";
                }

                if (oData.CWTarAmt > 0)
                {
                    _oData.CPercent = (Math.Round((oData.WTDAchAmt / oData.CWTarAmt) * 100)).ToString();
                }
                else
                {
                    _oData.CPercent = "0";
                }
                if (oData.WTDTarAmt > 0)
                {
                    _oData.WTDPercent = (Math.Round((oData.WTDAchAmt / oData.WTDTarAmt) * 100)).ToString();
                }
                else
                {
                    _oData.WTDPercent = "0";
                }

                eList.Add(_oData);
            }
            return eList;

        }
    }
}

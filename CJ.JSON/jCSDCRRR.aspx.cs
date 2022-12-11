
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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.ANDROID;


public partial class jCSDCRRR : System.Web.UI.Page
{
    ReportDocument rptFile;
    protected void Page_Load(object sender, EventArgs e)
    {

        string sMonth = Request.QueryString.Get("Month");
        string sYear = Request.QueryString.Get("Year");
        string sWeekNo = Request.QueryString.Get("WeekNo");
        string sUser = Request.QueryString.Get("UserName");

        //string sMonth = "2";
        //string sYear = "2022";
        //string sUser = "hakim";

        try
        {
            rptFile = new ReportDocument();
            rptFile.Load(Server.MapPath("Report/rptjCSDCRRR.rpt"));
            Data oData = new Data();
            DBController.Instance.OpenNewConnection();
            DSReportLog oDSReportLog = GetDSReportLog(sYear, sMonth, sWeekNo);
            DBController.Instance.CloseConnection();

            rptFile.SetDataSource(oDSReportLog);
            CRViewer.ReportSource = rptFile;
            CRViewer.DisplayToolbar = true;
            oData.InsertReportLog(sUser);
        }
        catch (Exception ex)
        {
            string ss = ex.Message;
        }

    }
    public class Data
    {
        TELLib _oTELLib;

        public int CY;
        public int LY;

        public double JanCY;
        public double JanLY;
        public double JanTCY;
        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10025";
            string sReportName = "Report View Log";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        if (rptFile != null)
        {
            rptFile.Close();
            rptFile.Dispose();
        }
    }

    private DSReportLog GetDSReportLog(string sYear, string sMonth, string sWeekNo)
    {

        DSReportLog oDSReportLog = new DSReportLog();

        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSQL = "";

        //sSQL = " SELECT a.ReportCode, b.Description as ReportName, a.UserName, c.UserFullName, Year(LogDate) AS 'Year', " +
        //       " CONVERT(CHAR(3), LogDate, 109)+', '+CONVERT(CHAR(4), LogDate, 120) AS 'MonthYear',  " +
        //       " RIGHT('0' + RTRIM(DATEPART(dd, LogDate)), 2) AS 'Day',   " +
        //       " Convert(datetime,replace(convert(varchar,LogDate,6),'','-'),1) AS 'LogDate', a.LogDate as LogDateDetail " +
        //       " FROM TELSysDB.dbo.t_ReportLog a, TELSysDB.dbo.t_A_Menu b, TELSysDB.dbo.t_User c " + 
        //       " WHERE a.ReportCode = b.MenuCode and a.UserName = c.UserName and Month(LogDate)= '" + sMonth + "' and Year(LogDate)='" + sYear + "' " +
        //       " ORDER BY a.LogDate ";


        sSQL = "Select ReportCode, ReportName, a.UserName,UserFullName, Year,MonthYear,Day,LogDate, LogDateDetail, IsNull(Sort,99) Sort from " +
            "( " +
            "SELECT a.ReportCode, b.Description as ReportName, a.UserName, c.UserFullName, Year(LogDate) AS 'Year',  " +
            "CONVERT(CHAR(3), LogDate, 109)+', '+CONVERT(CHAR(4), LogDate, 120) AS 'MonthYear',  " +
            "RIGHT('0' + RTRIM(DATEPART(dd, LogDate)), 2) AS 'Day',   " +
            "Convert(datetime,replace(convert(varchar,LogDate,6),'','-'),1) AS 'LogDate', a.LogDate as LogDateDetail " +
            "FROM TELSysDB.dbo.t_ReportLog a, TELSysDB.dbo.t_A_Menu b, t_User c " +
            "WHERE a.ReportCode = b.MenuCode and a.UserName = c.UserName and Month(LogDate)= '" + sMonth + "' and Year(LogDate)='" + sYear + "' " +
            ")a Left Outer JOIN TELAddDB.dbo.t_AppsLogUserSort b ON a.UserName=b.UserName ";


        cmd.CommandText = sSQL;
        cmd.CommandType = CommandType.Text;
        IDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            DSReportLog.ReportLogRow oReportLogRow = oDSReportLog.ReportLog.NewReportLogRow();

            oReportLogRow.ReportCode = reader["ReportCode"].ToString();
            oReportLogRow.ReportName = reader["ReportName"].ToString();
            oReportLogRow.UserName = reader["UserName"].ToString();
            oReportLogRow.UserFullName = reader["UserFullName"].ToString();
            oReportLogRow.Year = Convert.ToInt32(reader["Year"]);
            oReportLogRow.MonthYear = reader["MonthYear"].ToString();
            oReportLogRow.Day = reader["Day"].ToString();
            oReportLogRow.LogDate = Convert.ToDateTime(reader["LogDate"]);
            oReportLogRow.LogDateDetail = Convert.ToDateTime(reader["LogDateDetail"]);
            oReportLogRow.Sort = Convert.ToInt32(reader["Sort"]);
            oDSReportLog.ReportLog.AddReportLogRow(oReportLogRow);
        }

        oDSReportLog.AcceptChanges();

        return oDSReportLog;
    }
}



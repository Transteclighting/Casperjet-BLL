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

public partial class frmDayPlanOutletWise : System.Web.UI.Page
{
    ReportDocument rptFile;
    protected void Page_Load(object sender, EventArgs e)
    {
        //DateTime sFromDate =Convert.ToDateTime( Request.QueryString.Get("Plandate"));
        //DateTime sTodate = Convert.ToDateTime(Request.QueryString.Get("Plandate"));
        //string sUser = Request.QueryString.Get("UserName");
        //string sArea = Request.QueryString.Get("AreaName");
        //string sTerritory = Request.QueryString.Get("TerritoryName");
        //string sShowroomCode = Request.QueryString.Get("ShowroomCode");
        //string sExecutiveType = Request.QueryString.Get("ExecutiveType");

        //try
        //{
        //    rptFile = new ReportDocument();
        //    rptFile.Load(Server.MapPath("Report/rptDayPlanOutletWise.rpt"));
        //    DayPlanOutletWises oDayPlanOutletWises = new DayPlanOutletWises();
        //    DBController.Instance.OpenNewConnection();
        //    //DSReportLog oDSReportLog = GetDSReportLog(sYear, sMonth);
        //    oDayPlanOutletWises.RefreshByDayPlanOutletWise(sFromDate,sTodate,sArea,sTerritory,sShowroomCode,sExecutiveType);
        //    DBController.Instance.CloseConnection();
        //    rptFile.SetDataSource(oDayPlanOutletWises);
        //    rptFile.SetParameterValue("PlanDate", sFromDate);
        //    rptFile.SetParameterValue("PlanDate", sTodate);
        //    rptFile.SetParameterValue("AreaName", sArea);
        //    rptFile.SetParameterValue("TerritoryName", sTerritory);
        //    rptFile.SetParameterValue("ExecutiveType", sExecutiveType);
        //    rptFile.SetParameterValue("Outlet", sShowroomCode);
        //    //CRViewer.ReportSource = rptFile;
        //    //CRViewer.DisplayToolbar = true;
        //    Data oData = new Data();
        //    oData.InsertReportLog(sUser);
        //}
        //catch (Exception ex)
        //{
        //    string ss = ex.Message;
        //}
    }
    public class Data
    {
        public string EmployeeName;
        public int PlanQty;
        public string AreaName;
        public string TerritoryName;
        public string EmployeeCode;
        public string EmployeeType;
        public int CheckinQty;
        public string ShowroomCode;
        public DateTime PlanDate;
        public int LeadQty;
        public double LeadValue;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10025";
            string sReportName = "Day Plan Outlet Wise";
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
}
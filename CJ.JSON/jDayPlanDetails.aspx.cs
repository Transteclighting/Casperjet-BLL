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

public partial class jDayPlanDetails : System.Web.UI.Page
{
    ReportDocument rptFile;
    protected void Page_Load(object sender, EventArgs e)
    {
        //DateTime sPlandate =Convert.ToDateTime( Request.QueryString.Get("Plandate"));
        //string sEmployeeCode = Request.QueryString.Get("EmployeeCode");
        //string sCustomerType = Request.QueryString.Get("PlanDescription");
        //string sUser = Request.QueryString.Get("UserName");

        DateTime sPlandate = Convert.ToDateTime("20-Apr-2020");
        string sEmployeeCode = "1071";
        string sCustomerType = "B2B";
        string sUser = "kanij";

        try
        {
            rptFile = new ReportDocument();
            rptFile.Load(Server.MapPath("Report/rptDayPlanDetails.rpt"));
            DayPlanOutletWises oDayPlanOutletWises = new DayPlanOutletWises();
            DBController.Instance.OpenNewConnection();
            oDayPlanOutletWises.RefreshByDayPlanDetails(sPlandate, sEmployeeCode, sCustomerType);
            DBController.Instance.CloseConnection();
            rptFile.SetDataSource(oDayPlanOutletWises);
            rptFile.SetParameterValue("PlanDate", sPlandate);;
            rptFile.SetParameterValue("EmployeeCode", sEmployeeCode);
            rptFile.SetParameterValue("CustomerType", sCustomerType);
            CRViewer.ReportSource = rptFile;
            CRViewer.DisplayToolbar = true;
            Data oData = new Data();
            oData.InsertReportLog(sUser);
        }
        catch (Exception ex)
        {
            string ss = ex.Message;
        }
    }
    public class Data
    {

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10054";
            string sReportName = "Day Plan Details";
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
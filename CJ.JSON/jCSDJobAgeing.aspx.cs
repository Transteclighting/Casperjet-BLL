using System;
using System.Data;
using System.Configuration;
using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;
using CJ.Class;
using CrystalDecisions.Web;

public partial class jCSDJobAgeing : System.Web.UI.Page
{
    ReportDocument rptFile;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            try
            {
                Data oData = new Data();
                //string sUser = Request.QueryString.Get("UserName");
                string sUser = "sajib";
                string sAssignToTech = "4','5";
                string sYetToAssign = "0','1','2','3";
                rptFile = new ReportDocument();
                rptFile.Load(Server.MapPath("Report/rptCSDJobAgeingReport.rpt"));
                DSJobs oDSJobs = new DSJobs();
                DBController.Instance.OpenNewConnection();
                oDSJobs = GetDataSet(oDSJobs, "Pending for Parts", true, false, "11");
                oDSJobs = GetDataSet(oDSJobs, "Critical", false, false, "10");
                oDSJobs = GetDataSet(oDSJobs, "Assign to Tech", false, false, sAssignToTech);
                oDSJobs = GetDataSet(oDSJobs, "Work In Progress", false, false, "6");
                oDSJobs = GetDataSet(oDSJobs, "Ready For Test", false, false, "12");
                oDSJobs = GetDataSet(oDSJobs, "Pick-Up Service", false, false, "18");
                oDSJobs = GetDataSet(oDSJobs, "Pending/Unsettled", true, true, "11");
                oDSJobs = GetDataSet(oDSJobs, "Estimated", false, false, "7");
                oDSJobs = GetDataSet(oDSJobs, "Estimate Approved", false, false, "8");
                oDSJobs = GetDataSet(oDSJobs, "Estimate Not Approve", false, false, "9");
                oDSJobs = GetDataSet(oDSJobs, "Yet to Assign", false, false, sYetToAssign);
                DBController.Instance.CloseConnection();

                oDSJobs.AcceptChanges();
                CRViewer.ToolPanelView = ToolPanelViewType.None;

                rptFile.SetDataSource(oDSJobs);
                CRViewer.ReportSource = rptFile;
                oData.InsertReportLog(sUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #region
        /* --Pending For Parts
         Select 'Pending For Parts' as Status,
sum(Case when Age > 30 and JobType = 1 then x else 0 end) as "W>30Qty",
sum(Case when Age > 30 and JobType <> 1 then x else 0 end) as "P>30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType = 1 then x else 0 end) as "W15-30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType <> 1 then x else 0 end) as "P15-30Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType = 1 then x else 0 end) as "W08-14Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType <> 1 then x else 0 end) as "P08-14Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType = 1 then x else 0 end) as "W04-07Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType <> 1 then x else 0 end) as "P04-07Qty",
sum(Case when Age = 3 and JobType = 1 then x else 0 end) as W3Qty,
sum(Case when Age = 3 and JobType <> 1 then x else 0 end) as P3Qty,
sum(Case when Age = 2 and JobType = 1 then x else 0 end) as W2Qty,
sum(Case when Age = 2 and JobType <> 1 then x else 0 end) as P2Qty,
sum(Case when Age < 2 and JobType = 1 then x else 0 end) as W0Qty,
sum(Case when Age < 2 and JobType <> 1 then x else 0 end) as P0Qty
from
( 
select JobNo, JobType, 1 as x, convert(int,getdate()-JobCreationDate) as Age from Job a, t_JobStatus b
Where a.JobStatus=b.JobStatusID and ServiceType IN (1,2,4) 
 and IsDelivered=0 and PendingID = 243
and JobStatus=11)x
         * 
         * 
         * -------Schedule/Reschedule
         Select 'Schedule/ReSchedule' as Status,
sum(Case when Age > 30 and JobType = 1 then x else 0 end) as "W>30Qty",
sum(Case when Age > 30 and JobType <> 1 then x else 0 end) as "P>30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType = 1 then x else 0 end) as "W15-30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType <> 1 then x else 0 end) as "P15-30Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType = 1 then x else 0 end) as "W08-14Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType <> 1 then x else 0 end) as "P08-14Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType = 1 then x else 0 end) as "W04-07Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType <> 1 then x else 0 end) as "P04-07Qty",
sum(Case when Age = 3 and JobType = 1 then x else 0 end) as W3Qty,
sum(Case when Age = 3 and JobType <> 1 then x else 0 end) as P3Qty,
sum(Case when Age = 2 and JobType = 1 then x else 0 end) as W2Qty,
sum(Case when Age = 2 and JobType <> 1 then x else 0 end) as P2Qty,
sum(Case when Age < 2 and JobType = 1 then x else 0 end) as W0Qty,
sum(Case when Age < 2 and JobType <> 1 then x else 0 end) as P0Qty
from
( 
select JobNo, JobType, 1 as x, convert(int,getdate()-JobCreationDate) as Age from Job a, t_JobStatus b
Where a.JobStatus=b.JobStatusID and ServiceType IN (1,2,4) 
 and IsDelivered=0 and PendingID <> 243
and JobStatus=11)x
         * 
         * 
         --- Critical-----
         Select 'Critical' as Status,
sum(Case when Age > 30 and JobType = 1 then x else 0 end) as "W>30Qty",
sum(Case when Age > 30 and JobType <> 1 then x else 0 end) as "P>30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType = 1 then x else 0 end) as "W15-30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType <> 1 then x else 0 end) as "P15-30Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType = 1 then x else 0 end) as "W08-14Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType <> 1 then x else 0 end) as "P08-14Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType = 1 then x else 0 end) as "W04-07Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType <> 1 then x else 0 end) as "P04-07Qty",
sum(Case when Age = 3 and JobType = 1 then x else 0 end) as W3Qty,
sum(Case when Age = 3 and JobType <> 1 then x else 0 end) as P3Qty,
sum(Case when Age = 2 and JobType = 1 then x else 0 end) as W2Qty,
sum(Case when Age = 2 and JobType <> 1 then x else 0 end) as P2Qty,
sum(Case when Age < 2 and JobType = 1 then x else 0 end) as W0Qty,
sum(Case when Age < 2 and JobType <> 1 then x else 0 end) as P0Qty
from
( 
select JobNo, JobType, 1 as x, convert(int,getdate()-JobCreationDate) as Age from Job a, t_JobStatus b
Where a.JobStatus=b.JobStatusID and ServiceType IN (1,2,4) 
 and IsDelivered=0 
and JobStatus=10)x
         * 
         * 
         * 
         -- Assign To Tech
         Select 'AssignToTech' as Status,
sum(Case when Age > 30 and JobType = 1 then x else 0 end) as "W>30Qty",
sum(Case when Age > 30 and JobType <> 1 then x else 0 end) as "P>30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType = 1 then x else 0 end) as "W15-30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType <> 1 then x else 0 end) as "P15-30Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType = 1 then x else 0 end) as "W08-14Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType <> 1 then x else 0 end) as "P08-14Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType = 1 then x else 0 end) as "W04-07Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType <> 1 then x else 0 end) as "P04-07Qty",
sum(Case when Age = 3 and JobType = 1 then x else 0 end) as W3Qty,
sum(Case when Age = 3 and JobType <> 1 then x else 0 end) as P3Qty,
sum(Case when Age = 2 and JobType = 1 then x else 0 end) as W2Qty,
sum(Case when Age = 2 and JobType <> 1 then x else 0 end) as P2Qty,
sum(Case when Age < 2 and JobType = 1 then x else 0 end) as W0Qty,
sum(Case when Age < 2 and JobType <> 1 then x else 0 end) as P0Qty
from
( 
select JobNo, JobType, 1 as x, convert(int,getdate()-JobCreationDate) as Age from Job a, t_JobStatus b
Where a.JobStatus=b.JobStatusID and ServiceType IN (1,2,4) 
 and IsDelivered=0 
and JobStatus in (4,5))x
         * 
         * 
         ---- Yet to Assing----
         Select 'YetToAssign' as Status,
sum(Case when Age > 30 and JobType = 1 then x else 0 end) as "W>30Qty",
sum(Case when Age > 30 and JobType <> 1 then x else 0 end) as "P>30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType = 1 then x else 0 end) as "W15-30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType <> 1 then x else 0 end) as "P15-30Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType = 1 then x else 0 end) as "W08-14Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType <> 1 then x else 0 end) as "P08-14Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType = 1 then x else 0 end) as "W04-07Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType <> 1 then x else 0 end) as "P04-07Qty",
sum(Case when Age = 3 and JobType = 1 then x else 0 end) as W3Qty,
sum(Case when Age = 3 and JobType <> 1 then x else 0 end) as P3Qty,
sum(Case when Age = 2 and JobType = 1 then x else 0 end) as W2Qty,
sum(Case when Age = 2 and JobType <> 1 then x else 0 end) as P2Qty,
sum(Case when Age < 2 and JobType = 1 then x else 0 end) as W0Qty,
sum(Case when Age < 2 and JobType <> 1 then x else 0 end) as P0Qty
from
( 
select JobNo, JobType, 1 as x, convert(int,getdate()-JobCreationDate) as Age from Job a, t_JobStatus b
Where a.JobStatus=b.JobStatusID and ServiceType IN (1,2,4) 
 and IsDelivered=0 
and JobStatus < 4)x
         * 
         
         * 
         * 
         --- WIP---
         *
         Select 'WorkInProgress' as Status,
sum(Case when Age > 30 and JobType = 1 then x else 0 end) as "W>30Qty",
sum(Case when Age > 30 and JobType <> 1 then x else 0 end) as "P>30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType = 1 then x else 0 end) as "W15-30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType <> 1 then x else 0 end) as "P15-30Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType = 1 then x else 0 end) as "W08-14Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType <> 1 then x else 0 end) as "P08-14Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType = 1 then x else 0 end) as "W04-07Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType <> 1 then x else 0 end) as "P04-07Qty",
sum(Case when Age = 3 and JobType = 1 then x else 0 end) as W3Qty,
sum(Case when Age = 3 and JobType <> 1 then x else 0 end) as P3Qty,
sum(Case when Age = 2 and JobType = 1 then x else 0 end) as W2Qty,
sum(Case when Age = 2 and JobType <> 1 then x else 0 end) as P2Qty,
sum(Case when Age < 2 and JobType = 1 then x else 0 end) as W0Qty,
sum(Case when Age < 2 and JobType <> 1 then x else 0 end) as P0Qty
from
( 
select JobNo, JobType, 1 as x, convert(int,getdate()-JobCreationDate) as Age from Job a, t_JobStatus b
Where a.JobStatus=b.JobStatusID and ServiceType IN (1,2,4) 
 and IsDelivered=0 
and JobStatus = 6)x
         * 
         * 
         ----Ready for Test----
         *
         Select 'ReadyForTest' as Status,
sum(Case when Age > 30 and JobType = 1 then x else 0 end) as "W>30Qty",
sum(Case when Age > 30 and JobType <> 1 then x else 0 end) as "P>30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType = 1 then x else 0 end) as "W15-30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType <> 1 then x else 0 end) as "P15-30Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType = 1 then x else 0 end) as "W08-14Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType <> 1 then x else 0 end) as "P08-14Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType = 1 then x else 0 end) as "W04-07Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType <> 1 then x else 0 end) as "P04-07Qty",
sum(Case when Age = 3 and JobType = 1 then x else 0 end) as W3Qty,
sum(Case when Age = 3 and JobType <> 1 then x else 0 end) as P3Qty,
sum(Case when Age = 2 and JobType = 1 then x else 0 end) as W2Qty,
sum(Case when Age = 2 and JobType <> 1 then x else 0 end) as P2Qty,
sum(Case when Age < 2 and JobType = 1 then x else 0 end) as W0Qty,
sum(Case when Age < 2 and JobType <> 1 then x else 0 end) as P0Qty
from
( 
select JobNo, JobType, 1 as x, convert(int,getdate()-JobCreationDate) as Age from Job a, t_JobStatus b
Where a.JobStatus=b.JobStatusID and ServiceType IN (1,2,4) 
 and IsDelivered=0 
and JobStatus = 12)x
         * 
         * 
         * 
         ---- TR----
         Select 'TransportRequired' as Status,
sum(Case when Age > 30 and JobType = 1 then x else 0 end) as "W>30Qty",
sum(Case when Age > 30 and JobType <> 1 then x else 0 end) as "P>30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType = 1 then x else 0 end) as "W15-30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType <> 1 then x else 0 end) as "P15-30Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType = 1 then x else 0 end) as "W08-14Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType <> 1 then x else 0 end) as "P08-14Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType = 1 then x else 0 end) as "W04-07Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType <> 1 then x else 0 end) as "P04-07Qty",
sum(Case when Age = 3 and JobType = 1 then x else 0 end) as W3Qty,
sum(Case when Age = 3 and JobType <> 1 then x else 0 end) as P3Qty,
sum(Case when Age = 2 and JobType = 1 then x else 0 end) as W2Qty,
sum(Case when Age = 2 and JobType <> 1 then x else 0 end) as P2Qty,
sum(Case when Age < 2 and JobType = 1 then x else 0 end) as W0Qty,
sum(Case when Age < 2 and JobType <> 1 then x else 0 end) as P0Qty
from
( 
select JobNo, JobType, 1 as x, convert(int,getdate()-JobCreationDate) as Age from Job a, t_JobStatus b
Where a.JobStatus=b.JobStatusID and ServiceType IN (1,2,4) 
 and IsDelivered=0 
and JobStatus = 18)x
         * 
         ---Estimate Approve---
         
         Select 'EstimateApprove' as Status,
sum(Case when Age > 30 and JobType = 1 then x else 0 end) as "W>30Qty",
sum(Case when Age > 30 and JobType <> 1 then x else 0 end) as "P>30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType = 1 then x else 0 end) as "W15-30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType <> 1 then x else 0 end) as "P15-30Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType = 1 then x else 0 end) as "W08-14Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType <> 1 then x else 0 end) as "P08-14Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType = 1 then x else 0 end) as "W04-07Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType <> 1 then x else 0 end) as "P04-07Qty",
sum(Case when Age = 3 and JobType = 1 then x else 0 end) as W3Qty,
sum(Case when Age = 3 and JobType <> 1 then x else 0 end) as P3Qty,
sum(Case when Age = 2 and JobType = 1 then x else 0 end) as W2Qty,
sum(Case when Age = 2 and JobType <> 1 then x else 0 end) as P2Qty,
sum(Case when Age < 2 and JobType = 1 then x else 0 end) as W0Qty,
sum(Case when Age < 2 and JobType <> 1 then x else 0 end) as P0Qty
from
( 
select JobNo, JobType, 1 as x, convert(int,getdate()-JobCreationDate) as Age from Job a, t_JobStatus b
Where a.JobStatus=b.JobStatusID and ServiceType IN (1,2,4) 
 and IsDelivered=0 
and JobStatus = 8)x
         * 
         * 
         * 
         ---- Estimate Not Approve---
         Select 'EstimateNotApprove' as Status,
sum(Case when Age > 30 and JobType = 1 then x else 0 end) as "W>30Qty",
sum(Case when Age > 30 and JobType <> 1 then x else 0 end) as "P>30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType = 1 then x else 0 end) as "W15-30Qty",
sum(Case when Age >= 15 and Age <= 30 and JobType <> 1 then x else 0 end) as "P15-30Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType = 1 then x else 0 end) as "W08-14Qty",
sum(Case when Age >= 8 and Age <= 14 and JobType <> 1 then x else 0 end) as "P08-14Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType = 1 then x else 0 end) as "W04-07Qty",
sum(Case when Age >= 4 and Age <= 7 and JobType <> 1 then x else 0 end) as "P04-07Qty",
sum(Case when Age = 3 and JobType = 1 then x else 0 end) as W3Qty,
sum(Case when Age = 3 and JobType <> 1 then x else 0 end) as P3Qty,
sum(Case when Age = 2 and JobType = 1 then x else 0 end) as W2Qty,
sum(Case when Age = 2 and JobType <> 1 then x else 0 end) as P2Qty,
sum(Case when Age < 2 and JobType = 1 then x else 0 end) as W0Qty,
sum(Case when Age < 2 and JobType <> 1 then x else 0 end) as P0Qty
from
( 
select JobNo, JobType, 1 as x, convert(int,getdate()-JobCreationDate) as Age from Job a, t_JobStatus b
Where a.JobStatus=b.JobStatusID and ServiceType IN (1,2,4) 
 and IsDelivered=0 
and JobStatus = 9)x
         */
        #endregion
    }
    public class Data
    {
        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10027";
            string sReportName = "CSD Job Ageing Report";
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
    private DSJobs GetDataSet(DSJobs oDSJobs, string sStatus, bool IsPending, bool IsSchedule, string sJobStatus)
    {

        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSQL = "";

        //sSQL = " Select '" + sStatus + "' as Status, " +
        //       " sum(Case when Age > 30 and JobType = 1 then x else 0 end) as WSeg7, " +
        //       " sum(Case when Age > 30 and JobType <> 1 then x else 0 end) as PSeg7, " +
        //       " sum(Case when Age >= 15 and Age <= 30 and JobType = 1 then x else 0 end) as WSeg6, " +
        //       " sum(Case when Age >= 15 and Age <= 30 and JobType <> 1 then x else 0 end) as PSeg6, " +
        //       " sum(Case when Age >= 8 and Age <= 14 and JobType = 1 then x else 0 end) as WSeg5, " +
        //       " sum(Case when Age >= 8 and Age <= 14 and JobType <> 1 then x else 0 end) as PSeg5, " +
        //       " sum(Case when Age >= 4 and Age <= 7 and JobType = 1 then x else 0 end) as WSeg4, " +
        //       " sum(Case when Age >= 4 and Age <= 7 and JobType <> 1 then x else 0 end) as PSeg4, " +
        //       " sum(Case when Age = 3 and JobType = 1 then x else 0 end) as WSeg3, " +
        //       " sum(Case when Age = 3 and JobType <> 1 then x else 0 end) as PSeg3, " +
        //       " sum(Case when Age = 2 and JobType = 1 then x else 0 end) as WSeg2, " +
        //       " sum(Case when Age = 2 and JobType <> 1 then x else 0 end) as PSeg2, " +
        //       " sum(Case when Age < 2 and JobType = 1 then x else 0 end) as WSeg1, " +
        //       " sum(Case when Age < 2 and JobType <> 1 then x else 0 end) as PSeg1 " +
        //       " from " +
        //       " (  " +
        //       " select JobNo, JobType, 1 as x, convert(int,getdate()-JobCreationDate) as Age from  " +
        //       " TELServiceDB.dbo.Job a, TELServiceDB.dbo.t_JobStatus b " +
        //       " Where a.JobStatus=b.JobStatusID and ServiceType IN (1,2,4)  " +
        //       " and IsDelivered = 0 ";

        //if (IsPending == true)
        //{
        //    if (IsSchedule == false)
        //    {
        //        sSQL = sSQL + " and PendingID = 243 ";
        //    }
        //    else
        //    {
        //        sSQL = sSQL + " and PendingID <> 243 ";
        //    }
        //}
        //sSQL = sSQL + " and JobStatus IN ('" + sJobStatus + "'))x";

        sSQL = " Select '" + sStatus + "' as Status, " +
               " sum(Case when Age > 30 and JobType = 1 then x else 0 end) as WSeg7, " +
               " sum(Case when Age > 30 and JobType <> 1 then x else 0 end) as PSeg7, " +
               " sum(Case when Age >= 15 and Age <= 30 and JobType = 1 then x else 0 end) as WSeg6, " +
               " sum(Case when Age >= 15 and Age <= 30 and JobType <> 1 then x else 0 end) as PSeg6, " +
               " sum(Case when Age >= 8 and Age <= 14 and JobType = 1 then x else 0 end) as WSeg5, " +
               " sum(Case when Age >= 8 and Age <= 14 and JobType <> 1 then x else 0 end) as PSeg5, " +
               " sum(Case when Age >= 4 and Age <= 7 and JobType = 1 then x else 0 end) as WSeg4, " +
               " sum(Case when Age >= 4 and Age <= 7 and JobType <> 1 then x else 0 end) as PSeg4, " +
               " sum(Case when Age = 3 and JobType = 1 then x else 0 end) as WSeg3, " +
               " sum(Case when Age = 3 and JobType <> 1 then x else 0 end) as PSeg3, " +
               " sum(Case when Age = 2 and JobType = 1 then x else 0 end) as WSeg2, " +
               " sum(Case when Age = 2 and JobType <> 1 then x else 0 end) as PSeg2, " +
               " sum(Case when Age < 2 and JobType = 1 then x else 0 end) as WSeg1, " +
               " sum(Case when Age < 2 and JobType <> 1 then x else 0 end) as PSeg1 " +
               " from " +
               " (  " +
               " select JobNo, JobType, 1 as x, convert(int,getdate()-CreateDate) as Age from  " +
               " t_CSDJob a, t_CSDJobStatus b " +
               " Where a.Status=b.StatusID and ServiceType IN (1,2,4)  " +
               " and IsDelivered = 0 ";

        //if (IsPending == true)
        //{
        //    if (IsSchedule == false)
        //    {
        //        sSQL = sSQL + " and PendingID = 243 ";
        //    }
        //    else
        //    {
        //        sSQL = sSQL + " and PendingID <> 243 ";
        //    }
        //}
        sSQL = sSQL + " and Status IN ('" + sJobStatus + "'))x";



        cmd.CommandText = sSQL;
        cmd.CommandType = CommandType.Text;
        IDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            DSJobs.AgeingRow oAgeingRow = oDSJobs.Ageing.NewAgeingRow();

            oAgeingRow.Status = reader["Status"].ToString();

            if (reader["WSeg7"] != DBNull.Value)
            {
                oAgeingRow.WSeg7 = Convert.ToInt32(reader["WSeg7"]);
            }
            else
            {
                oAgeingRow.WSeg7 = 0;
            }
            if (reader["PSeg7"] != DBNull.Value)
            {
                oAgeingRow.PSeg7 = Convert.ToInt32(reader["PSeg7"]);
            }
            else
            {
                oAgeingRow.PSeg7 = 0;
            }
            if (reader["WSeg6"] != DBNull.Value)
            {
                oAgeingRow.WSeg6 = Convert.ToInt32(reader["WSeg6"]);
            }
            else
            {
                oAgeingRow.WSeg6 = 0;
            }
            if (reader["PSeg6"] != DBNull.Value)
            {
                oAgeingRow.PSeg6 = Convert.ToInt32(reader["PSeg6"]);
            }
            else
            {
                oAgeingRow.PSeg6 = 0;
            }
            if (reader["WSeg5"] != DBNull.Value)
            {
                oAgeingRow.WSeg5 = Convert.ToInt32(reader["WSeg5"]);
            }
            else
            {
                oAgeingRow.WSeg5 = 0;
            }
            if (reader["PSeg5"] != DBNull.Value)
            {
                oAgeingRow.PSeg5 = Convert.ToInt32(reader["PSeg5"]);
            }
            else
            {
                oAgeingRow.PSeg5 = 0;
            }
            if (reader["WSeg4"] != DBNull.Value)
            {
                oAgeingRow.WSeg4 = Convert.ToInt32(reader["WSeg4"]);
            }
            else
            {
                oAgeingRow.WSeg4 = 0;
            }
            if (reader["PSeg4"] != DBNull.Value)
            {
                oAgeingRow.PSeg4 = Convert.ToInt32(reader["PSeg4"]);
            }
            else
            {
                oAgeingRow.PSeg4 = 0;
            }
            if (reader["WSeg3"] != DBNull.Value)
            {
                oAgeingRow.WSeg3 = Convert.ToInt32(reader["WSeg3"]);
            }
            else
            {
                oAgeingRow.WSeg3 = 0;
            }
            if (reader["PSeg3"] != DBNull.Value)
            {
                oAgeingRow.PSeg3 = Convert.ToInt32(reader["PSeg3"]);
            }
            else
            {
                oAgeingRow.PSeg3 = 0;
            }
            if (reader["WSeg2"] != DBNull.Value)
            {
                oAgeingRow.WSeg2 = Convert.ToInt32(reader["WSeg2"]);
            }
            else
            {
                oAgeingRow.WSeg2 = 0;
            }
            if (reader["PSeg2"] != DBNull.Value)
            {
                oAgeingRow.PSeg2 = Convert.ToInt32(reader["PSeg2"]);
            }
            else
            {
                oAgeingRow.PSeg2 = 0;
            }
            if (reader["WSeg1"] != DBNull.Value)
            {
                oAgeingRow.WSeg1 = Convert.ToInt32(reader["WSeg1"]);
            }
            else
            {
                oAgeingRow.WSeg1 = 0;
            }
            if (reader["PSeg1"] != DBNull.Value)
            {
                oAgeingRow.PSeg1 = Convert.ToInt32(reader["PSeg1"]);
            }
            else
            {
                oAgeingRow.PSeg1 = 0;
            }

            oDSJobs.Ageing.AddAgeingRow(oAgeingRow);
        }

        oDSJobs.AcceptChanges();

        return oDSJobs;
    }
}

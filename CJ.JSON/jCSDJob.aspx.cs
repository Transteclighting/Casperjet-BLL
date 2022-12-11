using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using CJ.Class;



public partial class jCSDJob : System.Web.UI.Page 
{
    ReportDocument rptFile;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
		{
            string sUser = Request.QueryString.Get("UserName");
            DateTime dDate = Convert.ToDateTime(Request.QueryString.Get("Date"));
            
            Datas _oDatas = new Datas();
            string sOutput = "";

            try
            {
                rptFile = new ReportDocument();
                rptFile.Load(Server.MapPath("Report/rptCSDJobSummary.rpt"));
                Data oData = new Data();
                DBController.Instance.OpenNewConnection();
                DSJobs oDSJobs = oData.ReceiveSummary(dDate);
                DBController.Instance.CloseConnection();
                CRViewer.ToolPanelView = ToolPanelViewType.None;
                rptFile.SetDataSource(oDSJobs);
                CRViewer.ReportSource = rptFile;
                oData.InsertReportLog(sUser);
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
            }
		}
    }
    public class Data
    {
        


        public DSJobs ReceiveSummary(DateTime dDate)
        {
            //DateTime dToday = DateTime.Today;
            DateTime dToday = dDate;
            
            DateTime dNextDay = dToday.AddDays(1);
            DateTime dDay2 = dToday.AddDays(-1);
            DateTime dDay3 = dToday.AddDays(-2);
            DateTime dDay4 = dToday.AddDays(-3);
            DateTime dDay5 = dToday.AddDays(-4);
            DateTime dDay6 = dToday.AddDays(-5);
            DateTime dDay7 = dToday.AddDays(-6);

            int Installation = 3;
            int InHome = 2;
            int CarryIn = 1;


            DSJobs oDSJobs =  new DSJobs();
            DSJobs.ReceiveSummaryRow oReceiveSummaryRow = oDSJobs.ReceiveSummary.NewReceiveSummaryRow();

            oReceiveSummaryRow.JobType = "Installation";
            oReceiveSummaryRow.Day1R = GetJob(Installation, dToday, dNextDay);
            oReceiveSummaryRow.Day2R = GetJob(Installation, dDay2, dToday);
            oReceiveSummaryRow.Day3R = GetJob(Installation, dDay3, dDay2);
            oReceiveSummaryRow.Day4R = GetJob(Installation, dDay4, dDay3);
            oReceiveSummaryRow.Day5R = GetJob(Installation, dDay5, dDay4);
            oReceiveSummaryRow.Day6R = GetJob(Installation, dDay6, dDay5);
            oReceiveSummaryRow.Day7R = GetJob(Installation, dDay7, dDay6);

            oReceiveSummaryRow.Day1D = GetDeliveredJob(Installation, dToday, dNextDay);
            oReceiveSummaryRow.Day2D = GetDeliveredJob(Installation, dDay2, dToday);
            oReceiveSummaryRow.Day3D = GetDeliveredJob(Installation, dDay3, dDay2);
            oReceiveSummaryRow.Day4D = GetDeliveredJob(Installation, dDay4, dDay3);
            oReceiveSummaryRow.Day5D = GetDeliveredJob(Installation, dDay5, dDay4);
            oReceiveSummaryRow.Day6D = GetDeliveredJob(Installation, dDay6, dDay5);
            oReceiveSummaryRow.Day7D = GetDeliveredJob(Installation, dDay7, dDay6);

            oDSJobs.ReceiveSummary.AddReceiveSummaryRow(oReceiveSummaryRow);
            oDSJobs.AcceptChanges();

            oReceiveSummaryRow = oDSJobs.ReceiveSummary.NewReceiveSummaryRow();
            oReceiveSummaryRow.JobType = "In Home";
            oReceiveSummaryRow.Day1R = GetJob(InHome, dToday, dNextDay);
            oReceiveSummaryRow.Day2R = GetJob(InHome, dDay2, dToday);
            oReceiveSummaryRow.Day3R = GetJob(InHome, dDay3, dDay2);
            oReceiveSummaryRow.Day4R = GetJob(InHome, dDay4, dDay3);
            oReceiveSummaryRow.Day5R = GetJob(InHome, dDay5, dDay4);
            oReceiveSummaryRow.Day6R = GetJob(InHome, dDay6, dDay5);
            oReceiveSummaryRow.Day7R = GetJob(InHome, dDay7, dDay6);

            oReceiveSummaryRow.Day1D = GetDeliveredJob(InHome, dToday, dNextDay);
            oReceiveSummaryRow.Day2D = GetDeliveredJob(InHome, dDay2, dToday);
            oReceiveSummaryRow.Day3D = GetDeliveredJob(InHome, dDay3, dDay2);
            oReceiveSummaryRow.Day4D = GetDeliveredJob(InHome, dDay4, dDay3);
            oReceiveSummaryRow.Day5D = GetDeliveredJob(InHome, dDay5, dDay4);
            oReceiveSummaryRow.Day6D = GetDeliveredJob(InHome, dDay6, dDay5);
            oReceiveSummaryRow.Day7D = GetDeliveredJob(InHome, dDay7, dDay6);

            oDSJobs.ReceiveSummary.AddReceiveSummaryRow(oReceiveSummaryRow);
            oDSJobs.AcceptChanges();

            oReceiveSummaryRow = oDSJobs.ReceiveSummary.NewReceiveSummaryRow();
            oReceiveSummaryRow.JobType = "Carry In";
            oReceiveSummaryRow.Day1R = GetJob(CarryIn, dToday, dNextDay);
            oReceiveSummaryRow.Day2R = GetJob(CarryIn, dDay2, dToday);
            oReceiveSummaryRow.Day3R = GetJob(CarryIn, dDay3, dDay2);
            oReceiveSummaryRow.Day4R = GetJob(CarryIn, dDay4, dDay3);
            oReceiveSummaryRow.Day5R = GetJob(CarryIn, dDay5, dDay4);
            oReceiveSummaryRow.Day6R = GetJob(CarryIn, dDay6, dDay5);
            oReceiveSummaryRow.Day7R = GetJob(CarryIn, dDay7, dDay6);

            oReceiveSummaryRow.Day1D = GetDeliveredJobWk(CarryIn, dToday, dNextDay);
            oReceiveSummaryRow.Day2D = GetDeliveredJobWk(CarryIn, dDay2, dToday);
            oReceiveSummaryRow.Day3D = GetDeliveredJobWk(CarryIn, dDay3, dDay2);
            oReceiveSummaryRow.Day4D = GetDeliveredJobWk(CarryIn, dDay4, dDay3);
            oReceiveSummaryRow.Day5D = GetDeliveredJobWk(CarryIn, dDay5, dDay4);
            oReceiveSummaryRow.Day6D = GetDeliveredJobWk(CarryIn, dDay6, dDay5);
            oReceiveSummaryRow.Day7D = GetDeliveredJobWk(CarryIn, dDay7, dDay6);

            oDSJobs.ReceiveSummary.AddReceiveSummaryRow(oReceiveSummaryRow);
            oDSJobs.AcceptChanges();

            oDSJobs.Parameter.AddParameterRow(Convert.ToDateTime(dToday).ToString("dd-MMM-yyyy"), Convert.ToDateTime(dDay2).ToString("dd-MMM-yyyy"), Convert.ToDateTime(dDay3).ToString("dd-MMM-yyyy"), Convert.ToDateTime(dDay4).ToString("dd-MMM-yyyy"), Convert.ToDateTime(dDay5).ToString("dd-MMM-yyyy"), Convert.ToDateTime(dDay6).ToString("dd-MMM-yyyy"), Convert.ToDateTime(dDay7).ToString("dd-MMM-yyyy"), Convert.ToDateTime(dDate).ToString("dd-MMM-yyyy"));
            oDSJobs.AcceptChanges();

            return oDSJobs;
        }

        private int GetJob(int nServiceType, DateTime dFromDate, DateTime dToDate)
        {
            int nJobCount = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSQL = " select Count(JobID) as JobCount from t_CSDJob Where ServiceType=" + nServiceType + " " +
                   " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and " +
                   " CreateDate < '" + dToDate + "' and Status <> 20 ";
           
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nJobCount = Convert.ToInt32(reader["JobCount"]);
                }
                reader.Close();
                //InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nJobCount;
        }
        private int GetDeliveredJob(int nServiceType, DateTime dFromDate, DateTime dToDate)
        {
            int nJobCount = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //sSQL = " select Count(a.JobID) as JobCount from TELServiceDB.dbo.Job a, TELServiceDB.dbo.JobHistory b  " +
            //" Where a.JobID = b.JobID and ServiceType = " + nServiceType + "  " +
            //" and TranDate between '" + dFromDate + "' and '" + dToDate + "' and  " +
            //" TranDate < '" + dToDate + "' and JobStatus <> 20 and Status = 'Service Provided'";

            sSQL = " select Count(a.JobID) as JobCount from t_CSDJob a, t_CSDJobHistory b  " +
            " Where a.JobID = b.JobID and a.ServiceType = " + nServiceType + "  " +
            " and b.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and  " +
            " b.CreateDate < '" + dToDate + "' and Status <> 20 and StatusID = 17 ";



            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nJobCount = Convert.ToInt32(reader["JobCount"]);
                }
                reader.Close();
                //InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nJobCount;
        }
        private int GetDeliveredJobIS(int nServiceType, DateTime dFromDate, DateTime dToDate)
        {
            int nJobCount = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //sSQL = " select Count(JobID) as JobCount from TELServiceDB.dbo.Job Where ServiceType=" + nServiceType + " " +
            //" and DeliveryDate between '" + dFromDate + "' and '" + dToDate + "' and " +
            //" DeliveryDate < '" + dToDate + "' and JobStatus <> 20 and IsDelivered=1";

            sSQL = " select Count(JobID) as JobCount from t_CSDJob Where ServiceType=" + nServiceType + " " +
            " and DeliveryDate between '" + dFromDate + "' and '" + dToDate + "' and " +
            " DeliveryDate < '" + dToDate + "' and Status <> 20 and IsDelivered=1";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nJobCount = Convert.ToInt32(reader["JobCount"]);
                }
                reader.Close();
                //InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nJobCount;
        }
        private int GetDeliveredJobWk(int nServiceType, DateTime dFromDate, DateTime dToDate)
        {
            int nJobCount = 0;
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //sSQL = " select Count(a.JobID) as JobCount from TELServiceDB.dbo.Job a, TELServiceDB.dbo.JobHistory b "+
            //       " Where a.JobID = b.JobID and ServiceType = " + nServiceType + "  " +
            //       " and TranDate between '" + dFromDate + "' and '" + dToDate + "' and  " +
            //       " TranDate < '" + dToDate + "' and JobStatus <> 20 and Status = 'Ready for Delivery(Repaired)'";

            sSQL = " select Count(a.JobID) as JobCount from t_CSDJob a, t_CSDJobHistory b " +
                   " Where a.JobID = b.JobID and a.ServiceType = " + nServiceType + "  " +
                   " and b.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and  " +
                   " b.CreateDate < '" + dToDate + "' and Status <> 20 and StatusID = 26 ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nJobCount = Convert.ToInt32(reader["JobCount"]);
                }
                reader.Close();
                //InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nJobCount;
        }
        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10026";
            string sReportName = "CSD Job Receive/Delivery";
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
        /*
        public List<Data> GetDataByJobNo(String sJobNo)
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "Select Job.JobID, SerialNo, JobNo, IsDelivered = CASE When IsDelivered =1 then 'Yes' else 'No' end, ServiceType= Case when ServiceType=1 Then 'WalkIn' " +
                                "when ServiceType =2 Then 'HomeCall' when ServiceType =3 Then 'InterService' " +
                                "when ServiceType =4 Then 'Installation' else 'Nothing' end,  " +
                                "JobType= Case when JobType=1 Then 'Full Warranty' " +
                                "when JobType =2 Then 'Paid' when JobType =3 Then 'Only Service Warranty' " +
                                "else 'Others' end, RefferenceJobNo, ReceivingCounter, Remarks, prod.Code as ProductCode, prod.Name as ProductName,  " +
                                "IsNull(vProd.ASGName,'CTV')ASGName,  " +
                                "FullOrAccessories, AccessoryID, bd.Description as PrimaryFault, FaultFromTech ActualFault,CustomerName, Job.Mobile, FirstAddress as CustomerAddress,  " +
                                "JobStatusName, JobCreationDate,  " +
                                "Isnull(T.Name,Isnull(Cha.Name,ISV.Name)) as AssignTo, convert(datetime,replace(convert(varchar,DeliveryDate,6),' ','-'),1)as EDD, " +
                                "convert(int,getdate()-JobCreationDate) as Days,CCJLM.Instruction " +
                                "from TELServiceDB.dbo.Job Job INNER JOIN TELServiceDB.dbo.Product prod ON Job.ProductID=prod.ProductID " +
                                "Left Outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) as vProd " +
                                "ON vProd.ProductCode=prod.Code " +
                                "INNER JOIN TELServiceDB.dbo.t_JobStatus as JS ON JS.JobStatusID=Job.JobStatus " +
                                "INNER JOIN TELServiceDB.dbo.BasicDescription bd ON bd.DescriptionID=Job.FaultDescriptionID " +
                                "left outer join TELServiceDB.dbo.Technician T " +
                                "on Job.TechnicianID=T.ID " +
                                "left outer join (select * from TELServiceDB.dbo.Channel where Type=4) Cha " +
                                "on Job.ThirdPartyID=Cha.ID " +
                                "left outer join TELServiceDB.dbo.InterService ISV " +
                                "on Job.InterServiceID=ISV.ID " +
                                "Left Outer Join " +
                                "( " +
                                "select CCJL.* from TELServiceDB.dbo.CallCentJobList CCJL " +
                                "inner join " +
                                "(select JobID,Max(CallCentJobListID) as ID  " +
                                "from (Select * from TELServiceDB.dbo.CallCentJobList Where Instruction <> 'Sent SMS about the Job status')A  group by JobID) B " +
                                "on CCJL.JobID=B.JobID and CCJL.CallCentJobListID=B.ID " +
                                ") CCJLM " +
                                "on Job.JobID=CCJLM.JobID " +
                                " Where JobNo=" + sJobNo + "";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.Value = "Success";

                    oData.JobNo = reader["JobNo"].ToString();
                    oData.JCD = Convert.ToDateTime(reader["JobCreationDate"]).ToString("dd-MMM-yyyy h:m:s tt");
                    oData.ServiceType = reader["ServiceType"].ToString();
                    oData.JobType = reader["JobType"].ToString();
                    oData.ASG = reader["ASGName"].ToString();
                    oData.JobStatus = reader["JobStatusName"].ToString();
                    oData.EDD = Convert.ToDateTime(reader["EDD"]).ToString("dd-MMM-yyyy");
                    oData.Instruction = reader["Instruction"].ToString();
                    oData.Days = reader["Days"].ToString();
                    oData.AssignTo = reader["AssignTo"].ToString();
                    oData.ProductCode = reader["ProductCode"].ToString();
                    oData.ProductName = reader["ProductName"].ToString();
                    oData.SerialNo = reader["SerialNo"].ToString();
                    oData.PrimaryFault = reader["PrimaryFault"].ToString();
                    oData.ActualFault = reader["ActualFault"].ToString();
                    oData.ReferenceJob = reader["RefferenceJobNo"].ToString();
                    oData.JobRemarks = reader["Remarks"].ToString();
                    oData.ReceivingCounter = reader["ReceivingCounter"].ToString();
                    oData.CustomerName = reader["CustomerName"].ToString();
                    oData.Mobile = reader["Mobile"].ToString();
                    oData.Address = reader["CustomerAddress"].ToString();
                    oData.IsDelivered = reader["IsDelivered"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }

        public List<Data> GetData(String sType, String sReqData)
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "select JobNo, CustomerName, JobCreationDate, JobStatusName from TELServiceDB.dbo.Job a, " +
            "TELServiceDB.dbo.t_JobStatus b where a.JobStatus=b.JobStatusID ";

            if (sType == "MobileNo")
            {

                sSQL = sSQL + " and Mobile like '%" + sReqData + "%'";

            }
            else if (sType == "SerialNo")
            {

                sSQL = sSQL + " and SerialNo='" + sReqData + "'";

            }
            else if (sType == "Customer")
            {

                sSQL = sSQL + " and CustomerName like '%" + sReqData + "%' ";

            }
            sSQL = sSQL + " order by JobCreationDate desc";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.Value = "Success";

                    oData.JobNo = reader["JobNo"].ToString();
                    oData.JCD = Convert.ToDateTime(reader["JobCreationDate"]).ToString("dd-MMM-yyyy");
                    oData.JobStatus = reader["JobStatusName"].ToString();
                    oData.CustomerName = reader["CustomerName"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }
*/
    }
}



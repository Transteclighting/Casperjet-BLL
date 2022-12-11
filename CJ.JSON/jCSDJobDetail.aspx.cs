using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;


public partial class jCSDJobDetail : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
		{
			HttpContext c = HttpContext.Current;
            string sReqData = c.Request.Form["ReqData"].Trim();
            string sUser = c.Request.Form["UserName"].Trim();
            string sType = c.Request.Form["Type"].Trim();

            Datas _oDatas = new Datas();
            string sOutput = "";
            Data oData = new Data();
            DBController.Instance.OpenNewConnection();

            if (sType == "JobNo")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetDataByJobNo(sReqData), Formatting.Indented);
                Response.Write(sOutput);
                oData.InsertReportLog(sUser);
            }
            else
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetData(sType, sReqData), Formatting.Indented);
                Response.Write(sOutput);
                oData.InsertReportLog(sUser);
            }

            DBController.Instance.CloseConnection();
		}
    }
    public class Data
    {
        public string JobNo;
        public string JCD;
        public string ServiceType;
        public string JobType;
        public string ASG;
        public string JobStatus;
        public string EDD;
        public string Instruction;
        public string Days;
        public string AssignTo;
        public string ProductCode;
        public string ProductName;
        public string SerialNo;
        public string PrimaryFault;
        public string ActualFault;
        public string ReferenceJob;
        public string JobRemarks;
        public string ReceivingCounter;
        public string CustomerName;
        public string Mobile;
        public string Address;
        public string IsDelivered;
        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10007";
            string sReportName = "TEL-CSD Job Search";
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

        public List<Data> GetDataByJobNo(String sJobNo)
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSQL = "Select Job.JobID, SerialNo, JobNo, IsDelivered = CASE When IsDelivered =1 then 'Yes' else 'No' end, ServiceType= Case when ServiceType=1 Then 'WalkIn' " +
            //                    "when ServiceType =2 Then 'HomeCall' when ServiceType =3 Then 'InterService' " +
            //                    "when ServiceType =4 Then 'Installation' else 'Nothing' end,  " +
            //                    "JobType= Case when JobType=1 Then 'Full Warranty' " +
            //                    "when JobType =2 Then 'Paid' when JobType =3 Then 'Only Service Warranty' " +
            //                    "else 'Others' end, RefferenceJobNo, ReceivingCounter, Remarks, prod.Code as ProductCode, prod.Name as ProductName,  " +
            //                    "IsNull(vProd.ASGName,'CTV')ASGName,  " +
            //                    "FullOrAccessories, AccessoryID, bd.Description as PrimaryFault, FaultFromTech ActualFault,CustomerName, Job.Mobile, FirstAddress as CustomerAddress,  " +
            //                    "JobStatusName, JobCreationDate,  " +
            //                    "Isnull(T.Name,Isnull(Cha.Name,ISV.Name)) as AssignTo, convert(datetime,replace(convert(varchar,DeliveryDate,6),' ','-'),1)as EDD, " +
            //                    "convert(int,getdate()-JobCreationDate) as Days,CCJLM.Instruction " +
            //                    "from TELServiceDB.dbo.Job Job INNER JOIN TELServiceDB.dbo.Product prod ON Job.ProductID=prod.ProductID " +
            //                    "Left Outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) as vProd " +
            //                    "ON vProd.ProductCode=prod.Code " +
            //                    "INNER JOIN TELServiceDB.dbo.t_JobStatus as JS ON JS.JobStatusID=Job.JobStatus " +
            //                    "INNER JOIN TELServiceDB.dbo.BasicDescription bd ON bd.DescriptionID=Job.FaultDescriptionID " +
            //                    "left outer join TELServiceDB.dbo.Technician T " +
            //                    "on Job.TechnicianID=T.ID " +
            //                    "left outer join (select * from TELServiceDB.dbo.Channel where Type=4) Cha " +
            //                    "on Job.ThirdPartyID=Cha.ID " +
            //                    "left outer join TELServiceDB.dbo.InterService ISV " +
            //                    "on Job.InterServiceID=ISV.ID " +
            //                    "Left Outer Join " +
            //                    "( " +
            //                    "select CCJL.* from TELServiceDB.dbo.CallCentJobList CCJL " +
            //                    "inner join " +
            //                    "(select JobID,Max(CallCentJobListID) as ID  " +
            //                    "from (Select * from TELServiceDB.dbo.CallCentJobList Where Instruction <> 'Sent SMS about the Job status')A  group by JobID) B " +
            //                    "on CCJL.JobID=B.JobID and CCJL.CallCentJobListID=B.ID " +
            //                    ") CCJLM " +
            //                    "on Job.JobID=CCJLM.JobID " +
            //                    " Where JobNo=" + sJobNo + "";

            string sSQL = "Select Job.JobID, ProductSerialNo, JobNo, IsDelivered = CASE When IsDelivered =1 then 'Yes' else 'No' end, ServiceType= Case when ServiceType=1 Then 'WalkIn' " +
                            "when ServiceType = 2 Then 'HomeCall' when ServiceType = 3 Then 'InterService' " +
                            "when ServiceType = 4 Then 'Installation' else 'Nothing' end, " +
                            "JobType = Case when JobType = 1 Then 'Full Warranty' " +
                            "when JobType = 2 Then 'Paid' when JobType = 3 Then 'Only Service Warranty' " +
                            "else 'Others' end, ReferenceJobNo, Job.Remarks, prod.ProductCode as ProductCode, prod.ProductName as ProductName,  " +
                            "IsNull(vProd.ASGName, 'CTV')ASGName,  " +
                            "FullOrAccessories, AccessoryID, bd.FaultDescription as PrimaryFault,CustomerName, Job.MobileNo,CustomerAddress, " +
                            "StatusName, Job.CreateDate,   " +
                            "Isnull(T.Name, Isnull(Cha.ChannelDescription, ISV.Name)) as AssignTo, convert(datetime, replace(convert(varchar, DeliveryDate, 6), ' ', '-'), 1) as EDD,  " +
                            "convert(int, getdate() - Job.CreateDate) as Days,isnull(CCJLM.Remarks,'N/A') as Description  " +
                            "from t_CSDJob Job INNER JOIN t_Product prod ON Job.ProductID = prod.ProductID " +
                            "Left Outer JOIN(Select ProductCode, ASGName from v_ProductDetails) as vProd " +
                            "ON vProd.ProductCode = prod.ProductCode " +
                            "INNER JOIN t_CSDJobStatus as JS ON JS.StatusID = Job.Status " +
                            "INNER JOIN t_CSDProductFault bd ON bd.FaultID = Job.PrimaryFaultID " +
                            "left outer join t_CSDTechnician T " +
                            "on Job.AssignTo = T.TechnicianID " +
                            "left outer join(select * from t_Channel where ChannelType = 4) Cha " +
                            "on Job.SalesChannelID = Cha.ChannelID " +
                            "left outer join t_CSDInterService ISV " +
                            "on Job.OwnOrOtherTechnician = ISV.InterServiceID " +
                            "Left Outer Join " +
                            "( " +
                            "select CCJL.* from t_CSDCustomerSatisfaction  CCJL " +
                            "inner join " +
                            "(select JobID, Max(ID) as ID " +
                            "from(Select * from t_CSDCustomerSatisfaction)A  group by JobID) B " +
                            "on CCJL.JobID = B.JobID and CCJL.ID = B.ID " +
                            ") CCJLM " +
                            "on Job.JobID = CCJLM.JobID " +
                            "Where JobNo = '"+ sJobNo + "'";

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
                    oData.JCD = Convert.ToDateTime(reader["CreateDate"]).ToString("dd-MMM-yyyy h:m:s tt");
                    oData.ServiceType = reader["ServiceType"].ToString();
                    oData.JobType = reader["JobType"].ToString();
                    oData.ASG = reader["ASGName"].ToString();
                    oData.JobStatus = reader["StatusName"].ToString();
                    oData.Instruction = reader["Description"].ToString();
                    oData.Days = reader["Days"].ToString();
                    oData.AssignTo = reader["AssignTo"].ToString();
                    oData.ProductCode = reader["ProductCode"].ToString();
                    oData.ProductName = reader["ProductName"].ToString();
                    oData.SerialNo = reader["ProductSerialNo"].ToString();
                    oData.PrimaryFault = reader["PrimaryFault"].ToString();
                    oData.ReferenceJob = reader["ReferenceJobNo"].ToString();
                    oData.JobRemarks = reader["Remarks"].ToString();
                    oData.CustomerName = reader["CustomerName"].ToString();
                    oData.Mobile = reader["MobileNo"].ToString();
                    oData.Address = reader["CustomerAddress"].ToString();
                    oData.IsDelivered = reader["IsDelivered"].ToString();
                    if (reader["EDD"] != DBNull.Value)
                    {
                        oData.EDD = Convert.ToDateTime(reader["EDD"]).ToString("dd-MMM-yyyy");
                    }

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

            //string sSQL = "select JobNo, CustomerName, JobCreationDate, JobStatusName from TELServiceDB.dbo.Job a, " +
            //"TELServiceDB.dbo.t_JobStatus b where a.JobStatus=b.JobStatusID ";
            //if (sType == "MobileNo")
            //{

            //    sSQL = sSQL + " and Mobile like '%" + sReqData + "%'";

            //}
            //else if (sType == "SerialNo")
            //{

            //    sSQL = sSQL + " and SerialNo='" + sReqData + "'";

            //}
            //else if (sType == "Customer")
            //{

            //    sSQL = sSQL + " and CustomerName like '%" + sReqData + "%' ";

            //}
            //sSQL = sSQL + " order by JobCreationDate desc";

            string sSQL = "select JobNo, CustomerName, CreateDate, StatusName,MobileNo,ProductSerialNo from t_CSDJob a, t_CSDJobStatus b where a.Status=b.StatusID";

            if (sType == "MobileNo")
            {

                sSQL = sSQL + " and MobileNo like '%" + sReqData + "%'";

            }
            else if (sType == "SerialNo")
            {

                sSQL = sSQL + " and ProductSerialNo='" + sReqData + "'";

            }
            else if (sType == "Customer")
            {

                sSQL = sSQL + " and CustomerName like '%" + sReqData + "%' ";

            }
            sSQL = sSQL + " order by CreationDate desc";

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
                    //oData.JCD = Convert.ToDateTime(reader["JobCreationDate"]).ToString("dd-MMM-yyyy");
                    oData.JCD = Convert.ToDateTime(reader["CreationDate"]).ToString("dd-MMM-yyyy");
                    oData.JobStatus = reader["StatusName"].ToString();
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

    }
}


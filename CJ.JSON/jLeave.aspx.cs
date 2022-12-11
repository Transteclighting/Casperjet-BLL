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
using System.Collections.Generic;
using CJ.Class;


public partial class jLeave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUserName = c.Request.Form["UserName"].Trim();
            //string sUserName = "hakim";
            DateTime dDate = DateTime.Now.Date;
            dDate = dDate.AddDays(-30);

            EmployeeLeaves oEmployeeLeaves = new EmployeeLeaves();
            DBController.Instance.OpenNewConnection();
            oEmployeeLeaves.GetLeave(dDate);
            DBController.Instance.CloseConnection();


            List<Data> eList = new List<Data>();
            foreach (EmployeeLeave oEmployeeLeave in oEmployeeLeaves)
            {
                Data _oData = new Data();
                _oData.Value = "Success";
                _oData.EmployeeCode = oEmployeeLeave.EmployeeCode.ToString();
                _oData.EmployeeName = oEmployeeLeave.EmployeeName.ToString();
                _oData.CompanyCode = oEmployeeLeave.CompanyCode.ToString(); 
                _oData.DepartmentCode = oEmployeeLeave.DepartmentCode.ToString();

                _oData.LeaveTypeName = oEmployeeLeave.LeaveTypeName.ToString();
                _oData.LeaveStartDate = oEmployeeLeave.LeaveStartDate.ToString("dd-MMM-yyyy");
                _oData.LeaveEndDate = oEmployeeLeave.LeaveEndDate.ToString("dd-MMM-yyyy");
                _oData.Days = oEmployeeLeave.Days.ToString();

                eList.Add(_oData);
            }
            Data oData = new Data();
            oData.InsertReportLog(sUserName);
            string sOutput = JsonConvert.SerializeObject(eList, Formatting.Indented);
            Response.Write(sOutput.ToString());
        }
    }
    public class Data
    {
        public string EmployeeCode;
        public string EmployeeName;
        public string CompanyCode;
        public string DepartmentCode;
        public string LeaveTypeName;
        public string LeaveStartDate;
        public string LeaveEndDate;
        public string Days;
        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10031";
            string sReportName = "Leave Report";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
    }
}

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
using CJ.Class.ANDROID;
using CJ.Class.Library;

public partial class JBLLPhoneBook : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            HttpContext c = HttpContext.Current;
            //string sUser = c.Request.Form["UserName"].Trim();
            //string sCompany = c.Request.Form["Company"].Trim();
            string sUser = "hrashid";
            string sAndroidAppID = "";
            if (c.Request.Form["AndroidAppID"] != null)
            {
                sAndroidAppID = c.Request.Form["AndroidAppID"].Trim();
            }
            else
            {
                sAndroidAppID = Convert.ToString((int)Dictionary.AndroidAppID.CJ_Apps);
            }



            TargetVsAchs oTargetVsAchs = new TargetVsAchs();
            TargetVsAch _oTargetVsAch = new TargetVsAch();
            DBController.Instance.OpenNewConnection();

            DateTime dStartDateofWeek = Convert.ToDateTime(_oTargetVsAch.GetWeekFromDate());

            //oTargetVsAchs.Refresh(dStartDateofWeek);
            oTargetVsAchs.GetBLLPhonebook(sAndroidAppID, sUser);

            DBController.Instance.CloseConnection();


            //DMSData _oDMSData = new DMSData();
            List<DMSData> eList = new List<DMSData>();

            foreach (TargetVsAch oTargetVsAch in oTargetVsAchs)
            {
                DMSData _oDMSData = new DMSData();
                _oDMSData.Value = "Success";
                _oDMSData.MarketGroupID = Convert.ToInt32(oTargetVsAch.MarketGroupID).ToString();
                _oDMSData.EmployeeID = Convert.ToInt32(oTargetVsAch.EmployeeID).ToString();
                _oDMSData.Location = oTargetVsAch.Location.ToString();
                _oDMSData.EmployeeName = oTargetVsAch.EmployeeName.ToString();
                _oDMSData.Position = oTargetVsAch.Position.ToString();
                _oDMSData.MobileNumber = oTargetVsAch.MobileNumber.ToString();
                _oDMSData.DepartmentID = Convert.ToInt32(oTargetVsAch.DepartmentID).ToString();



                //_oDMSData.AreaName = oTargetVsAch.AreaName.ToString();
                //_oDMSData.CustomerName = oTargetVsAch.CustomerName.ToString();
                //_oDMSData.OperationDate = Convert.ToDateTime(oTargetVsAch.OperationDate).ToString("dd-MMM-yyyy");
                //_oDMSData.MobileNo = oTargetVsAch.MobileNo.ToString();
                //_oDMSData.DBType = Convert.ToInt16(oTargetVsAch.DBType).ToString();

                eList.Add(_oDMSData);

            }


            DMSData oData = new DMSData();
            oData.InsertReportLog(sUser);

            string sOutput = JsonConvert.SerializeObject(eList, Formatting.Indented);
            Response.Write(sOutput.ToString());


        }


    }
    public class DMSData
    {
        //public string AreaName;
        //public string CustomerName;
        //public string OperationDate;
        //public string DBType;
        //public string MobileNo;
        public string MarketGroupID;
        public string EmployeeID;
        public string Location;
        public string EmployeeName;
        public string Position;
        public string MobileNumber;
        public string DepartmentID;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10021";
            string sReportName = "BLL PhoneBook";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
    }

}


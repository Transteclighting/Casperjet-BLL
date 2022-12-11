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

public partial class frmPOSOperationDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUserName = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            DayStartEndLogs oDayStartEndLogs = new DayStartEndLogs();
            string sDB = "";
            if (sCompany == "TEL")
            {
                sDB = "TELSysDB";
            }
            else if (sCompany == "TML")
            {
                sDB = "TMLSysDB";
            }
            DBController.Instance.OpenNewConnection();
            oDayStartEndLogs.GetLog(sDB);
            DBController.Instance.CloseConnection();


            List<Data> eList = new List<Data>();
            foreach (DayStartEndLog oDayStartEndLog in oDayStartEndLogs)
            {
                Data _oData = new Data();
                _oData.Value = "Success";
                _oData.Outlet = oDayStartEndLog.WarehouseCode;
                _oData.LastClosingDate = Convert.ToDateTime(oDayStartEndLog.LastClosingDate).ToString("dd-MMM-yyyy");
                _oData.Days = oDayStartEndLog.Days.ToString();
                _oData.MobileNo = oDayStartEndLog.MobileNo.ToString();
                _oData.Type = oDayStartEndLog.Type.ToString();
                eList.Add(_oData);
            }

            if (sCompany == "TEL")
            {
                Data oData = new Data();
                oData.InsertReportLog(sUserName);
            }
            string sOutput = JsonConvert.SerializeObject(eList, Formatting.Indented);
            Response.Write(sOutput.ToString());
        }
    }
    public class Data
    {
        public string Outlet;
        public string LastClosingDate;
        public string Days;
        public string MobileNo;
        public string Type;
        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10006";
            string sReportName = "POS Day Close";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
    }
}


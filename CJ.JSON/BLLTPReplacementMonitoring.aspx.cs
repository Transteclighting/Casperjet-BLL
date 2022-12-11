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
public partial class BLLTPReplacementMonitoring : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            //string sCompany = c.Request.Form["Company"].Trim();
           // string sUser = "hrashid";
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

            oTargetVsAchs.GetDMSSalesStatus(sAndroidAppID, sUser);

            DBController.Instance.CloseConnection();


            //DMSData _oDMSData = new DMSData();
            List<DMSData> eList = new List<DMSData>();

            foreach (TargetVsAch oTargetVsAch in oTargetVsAchs)
            {
                DMSData _oDMSData = new DMSData();
                //oTargetVsAch. = "Success";
                _oDMSData.CustomerName = oTargetVsAch.CustomerName.ToString();
                _oDMSData.OperationDate = Convert.ToDateTime(oTargetVsAch.OperationDate).ToString("dd-MMM-yyyy");
                _oDMSData.SalesQty = Convert.ToInt16(oTargetVsAch.SalesQty).ToString();
                _oDMSData.TPQty= Convert.ToInt16(oTargetVsAch.TPQty).ToString();
                _oDMSData.IssueQty = Convert.ToInt16(oTargetVsAch.IssueQty).ToString();
                

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
        
        public string CustomerName;
        public string OperationDate;
        public string SalesQty;
        public string TPQty;
        public string IssueQty;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10022";
            string sReportName = "BLL-DMS TP Replacement Monitoring";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
    }
}
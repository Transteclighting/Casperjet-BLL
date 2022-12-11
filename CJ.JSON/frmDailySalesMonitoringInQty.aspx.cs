using CJ.Class;
using CJ.Class.ANDROID;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmDailySalesMonitoringInQty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            HttpContext c = HttpContext.Current;
            //string sUser = c.Request.Form["UserName"].Trim();
            //    string sCompany = c.Request.Form["Company"].Trim();
            string sUser = "akif";
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

            //DateTime dStartDateofWeek = Convert.ToDateTime(_oTargetVsAch.GetWeekFromDate());

            //oTargetVsAchs.Refresh(dStartDateofWeek);
            oTargetVsAchs.DailySalesMonitoringInQty();

            DBController.Instance.CloseConnection();


            //DMSData _oDMSData = new DMSData();
            List<DMSData> eList = new List<DMSData>();

            foreach (TargetVsAch oTargetVsAch in oTargetVsAchs)
            {
                DMSData _oDMSData = new DMSData();
                _oDMSData.value = "Success";
                _oDMSData.RegionName = oTargetVsAch.RegionName.ToString();
                _oDMSData.AreaID = oTargetVsAch.AreaID;
                _oDMSData.AreaName = oTargetVsAch.AreaName;
                _oDMSData.TerritoryID = oTargetVsAch.TerritorID;
                _oDMSData.TerritoryName = oTargetVsAch.TerritoryName;
                _oDMSData.CustomerID = oTargetVsAch.CustomerID;
                _oDMSData.CustomerCode = oTargetVsAch.CustomerCode;
                _oDMSData.CustomerName = oTargetVsAch.CustomerName;
                _oDMSData.DSRID = oTargetVsAch.DSRID;
                _oDMSData.DSRCode = oTargetVsAch.DSRCode;
                _oDMSData.DSRName = oTargetVsAch.DSRName;
                _oDMSData.MAGName = oTargetVsAch.MAGName;
                _oDMSData.ASGName = oTargetVsAch.ASGName;
                _oDMSData.TotalTGT = oTargetVsAch.TotalTGT;
                _oDMSData.MTDTGTQty = oTargetVsAch.MTDTGTQty;
                _oDMSData.MTDSalesQty = oTargetVsAch.MTDSalesQty;
                _oDMSData.Balance = oTargetVsAch.Balance;
                _oDMSData.WTGTQty = oTargetVsAch.WTGTQty;
                _oDMSData.WSalesQty = oTargetVsAch.WSalesQty;
                _oDMSData.LOQty = oTargetVsAch.LOQty;
                _oDMSData.LDQty = oTargetVsAch.LDQty;
                _oDMSData.DayTGTQty = oTargetVsAch.DayTGTQty;

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
        public string RegionName;
        public int AreaID;
        public string AreaName;
        public int TerritoryID;
        public string TerritoryName;
        public int CustomerID;
        public string CustomerCode;
        public string CustomerName;
        public int DSRID;
        public string DSRCode;
        public string DSRName;
        public string MAGName;
        public string ASGName;
        public double TotalTGT;
        public double MTDTGTQty;
        public double MTDSalesQty;
        public double Balance;
        public double WTGTQty;
        public double WSalesQty;
        public double LOQty;
        public double LDQty;
        public double DayTGTQty;
        public string value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10047";
            string sReportName = "Daily Sales Monitoring in Qty";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
    }
}
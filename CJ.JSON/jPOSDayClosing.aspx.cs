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
using System.Data.OleDb;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.ANDROID;

public partial class jPOSDayClosing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUserName = c.Request.Form["UserName"].Trim();
            //string sUserName = "hakim";
    
            Datas oDatas = new Datas();
            DBController.Instance.OpenNewConnection();

            Data oData = new Data();
            oData.InsertReportLog(sUserName);

            string sOutput = JsonConvert.SerializeObject(oDatas.Refresh(), Formatting.Indented);
            Response.Write(sOutput.ToString());
            DBController.Instance.CloseConnection();
        }
    }
    public class Data
    {
        public string Company;
        public string Outlet;
        public string POSDayClose;
        public string Days;
        public string DCSDate;
        public string Days1;
        public string MobileNo;
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
        public List<Data> Refresh()
        {
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select * from (Select 'TEL' as Company, ShowroomCode, LastClosingDate, " +
                          "  convert(int,Convert(datetime,replace(convert(varchar, getdate(),6),'','-'),1)-LastClosingDate) as Days,DCSDate as LastDCSDate,  " +
                          "  convert(int,Convert(datetime,replace(convert(varchar, getdate(),6),'','-'),1)-DCSDate) as Days1 , MobileNo from  " +
                          "  TELSysDB.dbo.t_Showroom a " +
                          "  Left Outer JOIN " +
                          "  (select WarehouseID, max(Convert(datetime,replace(convert(varchar, OperationDate,6),'','-'),1)) as LastClosingDate    " +
                          "  from  TELSysDB.dbo.t_DayStartEndLog Where Type=2 Group by WarehouseID)b  " +
                          "  ON a.WarehouseID=b.WarehouseID  " +
                          "  Left Outer JOIN " +
                          "  (Select WarehouseID, DCSDate from (select CustomerID, max(Convert(datetime,replace(convert(varchar, DCSDate,6),'','-'),1)) as DCSDate from TELSysDB.dbo.t_DCS Group by CustomerID) as a, " +
                          "  TELSysDB.dbo.t_Showroom b Where a.CustomerID=b.CustomerID)c   " +
                          "  ON a.WarehouseID=c.WarehouseID " +
                          "  UNION ALL " +
                          "  Select 'TML' as Company, ShowroomCode, LastClosingDate,  " +
                          "  convert(int,Convert(datetime,replace(convert(varchar, getdate(),6),'','-'),1)-LastClosingDate) as Days,DCSDate as LastDCSDate,  " +
                          "  convert(int,Convert(datetime,replace(convert(varchar, getdate(),6),'','-'),1)-DCSDate) as Days1 , MobileNo from  " +
                          "  TMLSysDB.dbo.t_Showroom a " +
                          "  Left Outer JOIN " +
                          "  (select WarehouseID, max(Convert(datetime,replace(convert(varchar, OperationDate,6),'','-'),1)) as LastClosingDate    " +
                          "  from  TMLSysDB.dbo.t_DayStartEndLog Where Type=2 Group by WarehouseID)b  " +
                          "  ON a.WarehouseID=b.WarehouseID  " +
                          "  Left Outer JOIN " +
                          "  (Select WarehouseID, DCSDate from (select CustomerID, max(Convert(datetime,replace(convert(varchar, DCSDate,6),'','-'),1)) as DCSDate from TMLSysDB.dbo.t_DCS Group by CustomerID) as a, " +
                          "  TMLSysDB.dbo.t_Showroom b Where a.CustomerID=b.CustomerID)c   " +
                          "  ON a.WarehouseID=c.WarehouseID " +
                          "   ) a Where LastClosingDate is not null and ShowroomCode Not IN (Select ShowroomCode from t_Showroom where IsShowDayCloseReport = 0) " +
                          "  Order by Company, Days desc, Days1 Desc, ShowroomCode  ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Data oData = new Data();

                    oData.Company = (string)reader["Company"];
                    oData.Outlet = (string)reader["ShowroomCode"];
                    oData.POSDayClose = Convert.ToDateTime(reader["LastClosingDate"]).ToString("dd-MMM-yyyy");
                    oData.Days = Convert.ToInt32(reader["Days"]).ToString("00");
                    if (reader["LastDCSDate"] != DBNull.Value)
                    {
                        oData.DCSDate = Convert.ToDateTime(reader["LastDCSDate"]).ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        oData.DCSDate = "01-Jan-2016";
                    }
                    if (reader["Days1"] != DBNull.Value)
                        oData.Days1 = Convert.ToInt32(reader["Days1"]).ToString("00");
                    else oData.Days1 = "0";
                    oData.MobileNo = reader["MobileNo"].ToString();
                    oData.Value = "Success";
                    eList.Add(oData);
                }
                reader.Close();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }
    }
}


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

public partial class jFieldForceAttendance : System.Web.UI.Page
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
        public string EmployeeCode;
        public string EmployeeName;
        public string Designation;
        public string Department;
        public string CompanyCode;
        public string JobLocationName;
        public string BU;
        public string AreaName;
        public string TerritoryName;
        public string ShowroomCode;
        //public string Type;
        public string Latitude;
        public string Longitude;
        public string CheckinAddress;
        public string LastCheckTime;
        public string Distance;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10058";
            string sReportName = "Daily Field Force Attendance";
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
            string sSql = @"select EmployeeCode,EmployeeName,Designation,Department,CompanyCode,JobLocationName,BU,AreaName,TerritoryName, ShowroomCode,LastCheckTime, Convert(varchar, CONVERT(NUMERIC(18, 2),CONVERT(NUMERIC(18, 2), SQRT(POWER(69.1 * ( Latitude - ShowroomLatitude), 2) + POWER(69.1 * ( ShowroomLongitude  - Longitude )* COS(Latitude / 57.3), 2)))*1.60934))+' KM' as Distance,Address as CheckinAddress,CAST(Latitude as varchar) as Latitude,CAST(Longitude as varchar) as Longitude from (
                Select EmployeeCode,EmployeeName,DesignationName as Designation,DepartmentName as Department,
                CompanyCode,JobLocationName,b.SBUName as BU,AreaName,TerritoryName, c.ShowroomCode, CAST(Type as varchar) as Type,CAST(a.Latitude as float) as Latitude,CAST(a.Longitude as float) as Longitude,a.Address,
                CONVERT(VARCHAR,FORMAT(CheckTime,'hh:mm tt')) as LastCheckTime,CAST(d.Latitude as float) as ShowroomLatitude,CAST(d.Longitude as float) as ShowroomLongitude
                From
                (
                Select a.* From t_DayTracker a,
                (
                Select TrackId trackid,EmployeeId,CheckTime LastCheckTime From t_DayTracker
                where Convert(date, CheckTime) between convert(date, GETDATE()) and convert(date, GETDATE()+1) and CONVERT(date, CheckTime)< convert(date, GETDATE()+1)
                and Type =1
                ) b where a.TrackId=b.TrackId and a.EmployeeId=b.EmployeeId
                ) a,v_EmployeeDetails b,t_Showroom c,v_CustomerDetails d
                where a.EmployeeId=b.EmployeeID and EMPStatus in (1,2) and b.SBUID=2
                and b.LocationID=c.LocationID and c.CustomerID=d.CustomerID
                ) DD
            ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Data oData = new Data();

                    oData.EmployeeCode = (string)reader["EmployeeCode"];
                    oData.EmployeeName = (string)reader["EmployeeName"];
                    oData.Designation = (string)reader["Designation"];
                    oData.Department = (string)reader["Department"];
                    oData.CompanyCode = (string)reader["CompanyCode"];
                    oData.JobLocationName = (string)reader["JobLocationName"];
                    oData.BU = (string)reader["BU"];
                    oData.AreaName = (string)reader["AreaName"];
                    oData.TerritoryName = (string)reader["TerritoryName"];
                    oData.ShowroomCode = (string)reader["ShowroomCode"];
                    //oData.Type = (string)reader["Type"];
                    oData.Latitude = (string)reader["Latitude"];
                    oData.Longitude = (string)reader["Longitude"];
                    oData.CheckinAddress = (string)reader["CheckinAddress"];
                  

                    if (reader["LastCheckTime"] != DBNull.Value)
                    {
                        oData.LastCheckTime = Convert.ToDateTime(reader["LastCheckTime"]).ToString("dd-MMM-yyyy");
                    }
                    oData.Distance = (string)reader["Distance"];

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


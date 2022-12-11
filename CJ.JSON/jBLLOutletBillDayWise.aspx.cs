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

using System.Data.OleDb;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.ANDROID;

public partial class jBLLOutletBillDayWise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sType = c.Request.Form["Type"].Trim();
            string sAndroidAppID = c.Request.Form["AndroidAppID"].Trim();
            string sDate = c.Request.Form["Date"].Trim();
            string sDataID = c.Request.Form["DataID"].Trim();

            //string sUser = "hakim";
            //string sType = "Area";
            //string sAndroidAppID = "1";
            //string sDataID = "251";
            //string sDate = "";

            DateTime dDate = DateTime.Now.Date;
            try
            {
                dDate = Convert.ToDateTime(sDate);
            }
            catch (Exception ex)
            {
                dDate = DateTime.Now.Date;
            }

            Datas oDatas = new Datas();
            Data _oData = new Data();
            Datas _oDatas = new Datas();


            DBController.Instance.OpenNewConnection();
            _oDatas.GetData(dDate, sType, sDataID, sAndroidAppID, sUser);
            DBController.Instance.CloseConnection();

            _oData.InsertReportLog(sUser);

            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());

        }
    }
    public class Data
    {
        public string Date;

        public int BillEO;
        public int BillHS;
        public int BillDS;
        public int BillES;
        public int BillMS;
        public int BillGS;
        public int BillOS;
        public int TotalBill;

        public string BillEOText;
        public string BillHSText;
        public string BillDSText;
        public string BillESText;
        public string BillMSText;
        public string BillGSText;
        public string BillOSText;
        public string TotalBillText;
        public string Type;
        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10046";
            string sReportName = "BLL-Numeric Distribution (Day wise)";
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

        private string ExcludeDecimal(string sAmount)
        {
            string sResult = "";
            sResult = sAmount.Remove(sAmount.Length - 3);
            return sResult;
        }

        public void GetData(DateTime dDate, string sType, string sDataID, string sAndroidAppID, string sUser)
        {

            DSBLLNumericDistribution oDSTotal = new DSBLLNumericDistribution();
            DSBLLNumericDistribution oDSlWeek = new DSBLLNumericDistribution();
            DSBLLNumericDistribution oDSDaily = new DSBLLNumericDistribution();

            DSBLLNumericDistribution oDSAll = new DSBLLNumericDistribution();

            oDSTotal = TotalBill(dDate, sType, sDataID, sAndroidAppID, sUser);
            oDSlWeek = WeeklyBill(dDate, sType, sDataID, sAndroidAppID, sUser);
            oDSDaily = DailyBill(dDate, sType, sDataID, sAndroidAppID, sUser);

            oDSAll.Merge(oDSTotal);
            oDSAll.Merge(oDSlWeek);
            oDSAll.Merge(oDSDaily);

            oDSAll.AcceptChanges();

            Data _oData;

            foreach (DSBLLNumericDistribution.NumericDistributionRow oRow in oDSAll.NumericDistribution)
            {
                _oData = new Data();

                _oData.Date = oRow.BillDate;
                _oData.Type = oRow.Type;
                _oData.BillEO = Convert.ToInt32(oRow.BillEO);
                _oData.BillHS = Convert.ToInt32(oRow.BillHS);
                _oData.BillDS = Convert.ToInt32(oRow.BillDS);
                _oData.BillES = Convert.ToInt32(oRow.BillES);
                _oData.BillMS = Convert.ToInt32(oRow.BillMS);
                _oData.BillGS = Convert.ToInt32(oRow.BillGS);
                _oData.BillOS = Convert.ToInt32(oRow.BillOS);
                _oData.TotalBill = Convert.ToInt32(oRow.TotalBill);

                InnerList.Add(_oData);
            }

        }

        public DSBLLNumericDistribution TotalBill(DateTime dFromDate, string sType, string sDataID, string sAndroidAppID, string sUser)
        {
            DSBLLNumericDistribution oDSBLLNumericDistribution = new DSBLLNumericDistribution();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select 'Total' as Total, " +
                   " Sum(Bill_1EO)as BillEO,sum(Bill_2HS)As BillHS, sum(Bill_3DS)As BillDS,sum(Bill_4ES)As BillES,  " +
                   " sum(Bill_5MS)As BillMS,sum( Bill_6GS)as BillGS, sum(Bill_7OS)As BillOS, sum(TotalBill)as TotalBill " +
                   " from " +
                   " ( " +
                   " select AreaID,AreaName, TerritoryID,TerritoryName,DistrictName,CustomerID,CustomerCode,CustomerName,DSRID,DSRCode,DSRName,BeatCode, BeatName, BillDate, " +
                   " isnull(Bill_1EO,0)as Bill_1EO,isnull(Bill_2HS,0)As Bill_2HS, isnull(Bill_3DS,0)As Bill_3DS,isnull(Bill_4ES,0)As Bill_4ES,  " +
                   " isnull(Bill_5MS,0)As Bill_5MS,isnull( Bill_6GS,0)as Bill_6GS, isnull(Bill_7OS,0)As Bill_7OS, isnull((Bill_1EO+Bill_2HS+Bill_3DS+Bill_4ES+Bill_5MS+Bill_6GS+Bill_7OS),0)as TotalBill " +
                   " from " +
                   " ( " +
                   " select RouteID, BillDate, " +
                   " sum(case when RetailTypeID=1 then  TotBill else 0 end )as Bill_1EO, " +
                   " sum(case when RetailTypeID=2 then  TotBill else 0 end )as Bill_2HS, " +
                   " sum(case when RetailTypeID=3 then  TotBill else 0 end )as Bill_3DS, " +
                   " sum(case when RetailTypeID=4 then  TotBill else 0 end )as Bill_4ES, " +
                   " sum(case when RetailTypeID=5 then  TotBill else 0 end )as Bill_5MS, " +
                   " sum(case when RetailTypeID=6 then  TotBill else 0 end )as Bill_6GS, " +
                   " sum(case when RetailTypeID in (7,null) then  TotBill else 0 end )as Bill_7OS " +
                   " from " +
                   " ( " +
                   " select a.RouteID,RetailTypeID,CONVERT(datetime,Replace(CONVERT(VARCHAR(11), OperationDate, 106),' ', '-')) AS BillDate, count(distinct OutletID)As TotBill " +
                   " from BLLSysDB.dbo.t_DMSOutletWiseBillingInfo a, BLLSysDB.dbo.t_DMSClusterOutlet b " +
                   " where Month(Operationdate) = " + nMonth + " and Year(Operationdate) = " + nYear + "  " +
                   " and a.OutletID=b.RetailID " +
                   " group by a.RouteID,RetailTypeID,OperationDate  " +
                   " )As Bill group by RouteID,BillDate " +
                   " )As TotBill " +
                   " inner join " +
                   " ( " +
                   " select a.DSRID, DSRCode,DSRName, RouteID as BeatCode, RouteName as BeatName, RouteTypeID,RouteType, " +
                   " a.IsActive as IsActiveRT, AreaID,AreaName, TerritoryID,TerritoryName,DistrictName,CustomerID, CustomerCode,CustomerName  " +
                   " from BLLSysDB.dbo.t_DMSRoute a, BLLSysDB.dbo.t_DMSDSR b, BLLSysDB.dbo.v_CustomerDetails c  " +
                   " Where a.DSRID=b.DSRID and a.DistributorID=c.CustomerID  ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and c.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUser + "')) ";
            }
            sSQL = sSQL + " )as Main  on TotBill.RouteID=Main.BeatCode " +
            " ) final  ";

            if (sType == "National")
            {
                sSQL = sSQL + " Where 1 = 1 ";
            }
            else if (sType == "Area")
            {
                sSQL = sSQL + " Where AreaID = '" + sDataID + "' ";
            }
            else if (sType == "Territory")
            {
                sSQL = sSQL + " Where TerritoryID = '" + sDataID + "' ";
            }
            else if (sType == "Customer")
            {
                sSQL = sSQL + " Where CustomerID = '" + sDataID + "' ";
            }
            else if (sType == "Route")
            {
                sSQL = sSQL + " Where DSRID = '" + sDataID + "' ";
            }
            else if (sType == "Beat")
            {
                sSQL = sSQL + " Where BeatCode = '" + sDataID + "' ";
            }

            try
            {
                Data _oData;
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLNumericDistribution.NumericDistributionRow oRow = oDSBLLNumericDistribution.NumericDistribution.NewNumericDistributionRow();
                    _oData = new Data();

                    oRow.BillDate = reader["Total"].ToString();
                    oRow.Type = "Total";
                    oRow.BillEO = reader["BillEO"].ToString();
                    oRow.BillHS = reader["BillHS"].ToString();
                    oRow.BillDS = reader["BillDS"].ToString();
                    oRow.BillES = reader["BillES"].ToString();
                    oRow.BillMS = reader["BillMS"].ToString();
                    oRow.BillGS = reader["BillGS"].ToString();
                    oRow.BillOS = reader["BillOS"].ToString();
                    oRow.TotalBill = reader["TotalBill"].ToString();

                    oDSBLLNumericDistribution.NumericDistribution.AddNumericDistributionRow(oRow);
                    oDSBLLNumericDistribution.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSBLLNumericDistribution;
        }

        public DSBLLNumericDistribution WeeklyBill(DateTime dFromDate, string sType, string sDataID, string sAndroidAppID, string sUser)
        {
            DSBLLNumericDistribution oDSBLLNumericDistribution = new DSBLLNumericDistribution();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select WeekNo , " +
                   " Sum(BillEO)as BillEO,sum(BillHS)As BillHS, sum(BillDS)As BillDS,sum(BillES)As BillES,  " +
                   " sum(BillMS)As BillMS,sum( BillGS)as BillGS, sum(BillOS)As BillOS, sum(TotalBill)as TotalBill " +
                   " from " +
                   " ( " +
                   " Select BillDate , " +
                   " Sum(Bill_1EO)as BillEO,sum(Bill_2HS)As BillHS, sum(Bill_3DS)As BillDS,sum(Bill_4ES)As BillES,  " +
                   " sum(Bill_5MS)As BillMS,sum( Bill_6GS)as BillGS, sum(Bill_7OS)As BillOS, sum(TotalBill)as TotalBill " +
                   " from " +
                   " ( " +
                   " select AreaID,AreaName, TerritoryID,TerritoryName,DistrictName,CustomerID,CustomerCode,CustomerName,DSRID,DSRCode,DSRName,BeatCode, BeatName, BillDate, " +
                   " isnull(Bill_1EO,0)as Bill_1EO,isnull(Bill_2HS,0)As Bill_2HS, isnull(Bill_3DS,0)As Bill_3DS,isnull(Bill_4ES,0)As Bill_4ES,  " +
                   " isnull(Bill_5MS,0)As Bill_5MS,isnull( Bill_6GS,0)as Bill_6GS, isnull(Bill_7OS,0)As Bill_7OS, isnull((Bill_1EO+Bill_2HS+Bill_3DS+Bill_4ES+Bill_5MS+Bill_6GS+Bill_7OS),0)as TotalBill " +
                   " from " +
                   " ( " +
                   " select RouteID, BillDate, " +
                   " sum(case when RetailTypeID=1 then  TotBill else 0 end )as Bill_1EO, " +
                   " sum(case when RetailTypeID=2 then  TotBill else 0 end )as Bill_2HS, " +
                   " sum(case when RetailTypeID=3 then  TotBill else 0 end )as Bill_3DS, " +
                   " sum(case when RetailTypeID=4 then  TotBill else 0 end )as Bill_4ES, " +
                   " sum(case when RetailTypeID=5 then  TotBill else 0 end )as Bill_5MS, " +
                   " sum(case when RetailTypeID=6 then  TotBill else 0 end )as Bill_6GS, " +
                   " sum(case when RetailTypeID in (7,null) then  TotBill else 0 end )as Bill_7OS " +
                   " from " +
                   " ( " +
                   " select a.RouteID,RetailTypeID,CONVERT(datetime,Replace(CONVERT(VARCHAR(11), OperationDate, 106),' ', '-')) AS BillDate, count(distinct OutletID)As TotBill " +
                   " from BLLSysDB.dbo.t_DMSOutletWiseBillingInfo a, BLLSysDB.dbo.t_DMSClusterOutlet b " +
                   " where Month(Operationdate) = " + nMonth + " and Year(Operationdate) = " + nYear + "  " +
                   " and a.OutletID=b.RetailID " +
                   " group by a.RouteID,RetailTypeID,OperationDate  " +
                   " )As Bill group by RouteID,BillDate " +
                   " )As TotBill " +
                   " inner join " +
                   " ( " +
                   " select a.DSRID, DSRCode,DSRName, RouteID as BeatCode, RouteName as BeatName, RouteTypeID,RouteType, " +
                   " a.IsActive as IsActiveRT, AreaID,AreaName, TerritoryID,TerritoryName,DistrictName,CustomerID, CustomerCode,CustomerName  " +
                   " from BLLSysDB.dbo.t_DMSRoute a, BLLSysDB.dbo.t_DMSDSR b, BLLSysDB.dbo.v_CustomerDetails c  " +
                   " Where a.DSRID=b.DSRID and a.DistributorID=c.CustomerID  ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and c.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUser + "')) ";
            }
            sSQL = sSQL + " )as Main  on TotBill.RouteID=Main.BeatCode " +
                   " ) final  ";

            if (sType == "National")
            {
                sSQL = sSQL + " Where 1 = 1 ";
            }
            else if (sType == "Area")
            {
                sSQL = sSQL + " Where AreaID = '" + sDataID + "' ";
            }
            else if (sType == "Territory")
            {
                sSQL = sSQL + " Where TerritoryID = '" + sDataID + "' ";
            }
            else if (sType == "Customer")
            {
                sSQL = sSQL + " Where CustomerID = '" + sDataID + "' ";
            }
            else if (sType == "Route")
            {
                sSQL = sSQL + " Where DSRID = '" + sDataID + "' ";
            }
            else if (sType == "Beat")
            {
                sSQL = sSQL + " Where BeatCode = '" + sDataID + "' ";
            }
            sSQL = sSQL + " Group by BillDate )x, ";

            sSQL = sSQL + " (Select ('W-'+CONVERT(VARCHAR(2),WeekNo)+' [' + CONVERT(VARCHAR(2),DATEPART(d,FromDate)) + '-' + " +
                    " CONVERT(VARCHAR(2),DATEPART(d,ToDate))+']') as WeekNo, FromDate, ToDate from TELSysDB.dbo.t_CalendarWeek)Cal  " +
                    " Where BillDate between FromDate and ToDate Group by WeekNo Order by WeekNo ";

            try
            {
                Data _oData;
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLNumericDistribution.NumericDistributionRow oRow = oDSBLLNumericDistribution.NumericDistribution.NewNumericDistributionRow();
                    _oData = new Data();

                    oRow.BillDate = reader["WeekNo"].ToString();
                    oRow.Type = "Week";
                    oRow.BillEO = reader["BillEO"].ToString();
                    oRow.BillHS = reader["BillHS"].ToString();
                    oRow.BillDS = reader["BillDS"].ToString();
                    oRow.BillES = reader["BillES"].ToString();
                    oRow.BillMS = reader["BillMS"].ToString();
                    oRow.BillGS = reader["BillGS"].ToString();
                    oRow.BillOS = reader["BillOS"].ToString();
                    oRow.TotalBill = reader["TotalBill"].ToString();

                    oDSBLLNumericDistribution.NumericDistribution.AddNumericDistributionRow(oRow);
                    oDSBLLNumericDistribution.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSBLLNumericDistribution;
        }

        public DSBLLNumericDistribution DailyBill(DateTime dFromDate, string sType, string sDataID, string sAndroidAppID, string sUser)
        {
            DSBLLNumericDistribution oDSBLLNumericDistribution = new DSBLLNumericDistribution();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            int nYear = dFromDate.Year;
            int nMonth = dFromDate.Month;

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select BillDate , " +
                   " Sum(Bill_1EO)as BillEO,sum(Bill_2HS)As BillHS, sum(Bill_3DS)As BillDS,sum(Bill_4ES)As BillES,  " +
                   " sum(Bill_5MS)As BillMS,sum( Bill_6GS)as BillGS, sum(Bill_7OS)As BillOS, sum(TotalBill)as TotalBill " +
                   " from " +
                   " ( " +
                   " select AreaID,AreaName, TerritoryID,TerritoryName,DistrictName,CustomerID,CustomerCode,CustomerName,DSRID,DSRCode,DSRName,BeatCode, BeatName, BillDate, " +
                   " isnull(Bill_1EO,0)as Bill_1EO,isnull(Bill_2HS,0)As Bill_2HS, isnull(Bill_3DS,0)As Bill_3DS,isnull(Bill_4ES,0)As Bill_4ES,  " +
                   " isnull(Bill_5MS,0)As Bill_5MS,isnull( Bill_6GS,0)as Bill_6GS, isnull(Bill_7OS,0)As Bill_7OS, isnull((Bill_1EO+Bill_2HS+Bill_3DS+Bill_4ES+Bill_5MS+Bill_6GS+Bill_7OS),0)as TotalBill " +
                   " from " +
                   " ( " +
                   " select RouteID, BillDate, " +
                   " sum(case when RetailTypeID=1 then  TotBill else 0 end )as Bill_1EO, " +
                   " sum(case when RetailTypeID=2 then  TotBill else 0 end )as Bill_2HS, " +
                   " sum(case when RetailTypeID=3 then  TotBill else 0 end )as Bill_3DS, " +
                   " sum(case when RetailTypeID=4 then  TotBill else 0 end )as Bill_4ES, " +
                   " sum(case when RetailTypeID=5 then  TotBill else 0 end )as Bill_5MS, " +
                   " sum(case when RetailTypeID=6 then  TotBill else 0 end )as Bill_6GS, " +
                   " sum(case when RetailTypeID in (7,null) then  TotBill else 0 end )as Bill_7OS " +
                   " from " +
                   " ( " +
                   " select a.RouteID,RetailTypeID,CONVERT(datetime,Replace(CONVERT(VARCHAR(11), OperationDate, 106),' ', '-')) AS BillDate, count(distinct OutletID)As TotBill " +
                   " from BLLSysDB.dbo.t_DMSOutletWiseBillingInfo a, BLLSysDB.dbo.t_DMSClusterOutlet b " +
                   " where Month(Operationdate) = " + nMonth + " and Year(Operationdate) = " + nYear + "  " +
                   " and a.OutletID=b.RetailID " +
                   " group by a.RouteID,RetailTypeID,OperationDate  " +
                   " )As Bill group by RouteID,BillDate " +
                   " )As TotBill " +
                   " inner join " +
                   " ( " +
                   " select a.DSRID, DSRCode,DSRName, RouteID as BeatCode, RouteName as BeatName, RouteTypeID,RouteType, " +
                   " a.IsActive as IsActiveRT, AreaID,AreaName, TerritoryID,TerritoryName,DistrictName,CustomerID, CustomerCode,CustomerName  " +
                   " from BLLSysDB.dbo.t_DMSRoute a, BLLSysDB.dbo.t_DMSDSR b, BLLSysDB.dbo.v_CustomerDetails c  " +
                   " Where a.DSRID=b.DSRID and a.DistributorID=c.CustomerID  ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and c.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUser + "')) ";
            }
            sSQL = sSQL + " )as Main  on TotBill.RouteID=Main.BeatCode " +
                   " ) final  ";

            if (sType == "National")
            {
                sSQL = sSQL + " Where 1 = 1 ";
            }
            else if (sType == "Area")
            {
                sSQL = sSQL + " Where AreaID = '" + sDataID + "' ";
            }
            else if (sType == "Territory")
            {
                sSQL = sSQL + " Where TerritoryID = '" + sDataID + "' ";
            }
            else if (sType == "Customer")
            {
                sSQL = sSQL + " Where CustomerID = '" + sDataID + "' ";
            }
            else if (sType == "Route")
            {
                sSQL = sSQL + " Where DSRID = '" + sDataID + "' ";
            }
            else if (sType == "Beat")
            {
                sSQL = sSQL + " Where BeatCode = '" + sDataID + "' ";
            }

            sSQL = sSQL + " Group by BillDate Order by BillDate ";

            try
            {
                Data _oData;
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLNumericDistribution.NumericDistributionRow oRow = oDSBLLNumericDistribution.NumericDistribution.NewNumericDistributionRow();
                    _oData = new Data();

                    oRow.BillDate = Convert.ToDateTime(reader["BillDate"]).ToString("dd-MMM-yyyy") + ", " + Convert.ToDateTime(reader["BillDate"]).ToString("ddd");
                    oRow.Type = "Day";
                    oRow.BillEO = reader["BillEO"].ToString();
                    oRow.BillHS = reader["BillHS"].ToString();
                    oRow.BillDS = reader["BillDS"].ToString();
                    oRow.BillES = reader["BillES"].ToString();
                    oRow.BillMS = reader["BillMS"].ToString();
                    oRow.BillGS = reader["BillGS"].ToString();
                    oRow.BillOS = reader["BillOS"].ToString();
                    oRow.TotalBill = reader["TotalBill"].ToString();

                    oDSBLLNumericDistribution.NumericDistribution.AddNumericDistributionRow(oRow);
                    oDSBLLNumericDistribution.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLNumericDistribution;
        }

        public List<Data> getResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();


            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.Date = oData.Date;
                _oData.Type = oData.Type;
                _oData.Value = "Success";

                _oData.BillEOText = oData.BillEO.ToString();
                _oData.BillHSText = oData.BillHS.ToString();
                _oData.BillDSText = oData.BillDS.ToString();
                _oData.BillESText = oData.BillES.ToString();
                _oData.BillMSText = oData.BillMS.ToString();
                _oData.BillGSText = oData.BillGS.ToString();
                _oData.BillOSText = oData.BillOS.ToString();
                _oData.TotalBillText = oData.TotalBill.ToString();

                eList.Add(_oData);
            }

            return eList;
        }

    }
}



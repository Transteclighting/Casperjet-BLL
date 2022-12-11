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

public partial class jBLLOutletBillSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sType = c.Request.Form["Type"].Trim();
            string sDate = c.Request.Form["Date"].Trim();
            string sCustomerID = c.Request.Form["CustomerID"].Trim();

            //string sUser = "hakim";
            //string sType = "Summary";
            //string sCustomerID = "140";
            //string sDate = "";

            string sAndroidAppID = "";
            if (c.Request.Form["AndroidAppID"] != null)
            {
                sAndroidAppID = c.Request.Form["AndroidAppID"].Trim();
            }
            else
            {
                sAndroidAppID = Convert.ToString((int)Dictionary.AndroidAppID.CJ_Apps);
            }

            DateTime dDate = DateTime.Now.Date;
            try
            {
                dDate = Convert.ToDateTime(sDate);
            }
            catch (Exception ex)
            {
                dDate = DateTime.Now.Date;
            }
            string sMonth = dDate.Month.ToString();
            string sYear = dDate.Year.ToString();

            Datas oDatas = new Datas();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oDataArea = new Data();
            Data _oDataZone = new Data();
            Data _oDataOutlet = new Data();

            Data _oDataRoute = new Data();
            Data _oDataBeat = new Data();

            int nCount = 0;

            DBController.Instance.OpenNewConnection();
            if (sType == "Summary")
            {
                oDatas.GetData(sMonth, sYear, sAndroidAppID, sUser);
            }
            else if (sType == "Beat")
            {
                oDatas.GetBeatData(sMonth, sYear, sCustomerID);
            }
            DBController.Instance.CloseConnection();

            #region Summary

            if (sType == "Summary")
            {
                foreach (Data oData in oDatas)
                {
                    if (nCount == 0)
                    {
                        _oDataTotal = new Data();
                        _oDatas.Add(_oDataTotal);
                        _oDataTotal.Outlet = "National";
                        _oDataTotal.Type = "National";
                        _oDataTotal.ID = "0";
                        _oDataTotal.AreaID = "0";
                        _oDataTotal.TerritoryID = "0";
                        _oDataTotal.CustomerID = "0";
                        _oDataTotal.Value = "Success";
                        nCount++;
                    }
                    if (_oDataArea.AreaName != oData.AreaName)
                    {
                        _oDataArea = new Data();
                        _oDatas.Add(_oDataArea);
                        _oDataArea.AreaName = oData.AreaName;
                        _oDataArea.Outlet = oData.AreaName;
                        _oDataArea.Type = "Area";
                        _oDataArea.ID = oData.AreaID;
                        _oDataArea.Value = "Success";
                        _oDataArea.AreaID = oData.AreaID;
                        _oDataArea.TerritoryID = oData.TerritoryID;
                        _oDataArea.CustomerID = oData.CustomerID;
                    }
                    if (_oDataZone.ZoneName != oData.ZoneName)
                    {
                        _oDataZone = new Data();
                        _oDatas.Add(_oDataZone);
                        _oDataZone.ZoneName = oData.ZoneName;
                        _oDataZone.Outlet = oData.ZoneName;
                        _oDataZone.Type = "Territory";
                        _oDataZone.ID = oData.TerritoryID;
                        _oDataZone.Value = "Success";
                        _oDataZone.AreaID = oData.AreaID;
                        _oDataZone.TerritoryID = oData.TerritoryID;
                        _oDataZone.CustomerID = oData.CustomerID;
                    }

                    _oDataOutlet = new Data();
                    _oDataOutlet.Value = "Success";
                    _oDataOutlet.ID = oData.CustomerID;
                    _oDataOutlet.AreaID = oData.AreaID;
                    _oDataOutlet.TerritoryID = oData.TerritoryID;
                    _oDataOutlet.CustomerID = oData.CustomerID;


                    _oDataOutlet.Outlet = oData.Outlet;
                    _oDataOutlet.TotEO = oData.TotEO;
                    _oDataOutlet.BillEO = oData.BillEO;
                    _oDataOutlet.TotHS = oData.TotHS;
                    _oDataOutlet.BillHS = oData.BillHS;
                    _oDataOutlet.TotDS = oData.TotDS;
                    _oDataOutlet.BillDS = oData.BillDS;
                    _oDataOutlet.TotES = oData.TotES;
                    _oDataOutlet.BillES = oData.BillES;
                    _oDataOutlet.TotMS = oData.TotMS;
                    _oDataOutlet.BillMS = oData.BillMS;
                    _oDataOutlet.TotGS = oData.TotGS;
                    _oDataOutlet.BillGS = oData.BillGS;
                    _oDataOutlet.TotOS = oData.TotOS;
                    _oDataOutlet.BillOS = oData.BillOS;
                    _oDataOutlet.TotalOutlet = oData.TotalOutlet;
                    _oDataOutlet.TotalBill = oData.TotalBill;

                    _oDataOutlet.Type = "Customer";
                    _oDatas.Add(_oDataOutlet);


                    _oDataTotal.TotEO = _oDataTotal.TotEO + oData.TotEO;
                    _oDataTotal.BillEO = _oDataTotal.BillEO + oData.BillEO;
                    _oDataTotal.TotHS = _oDataTotal.TotHS + oData.TotHS;
                    _oDataTotal.BillHS = _oDataTotal.BillHS + oData.BillHS;
                    _oDataTotal.TotDS = _oDataTotal.TotDS + oData.TotDS;
                    _oDataTotal.BillDS = _oDataTotal.BillDS + oData.BillDS;
                    _oDataTotal.TotES = _oDataTotal.TotES + oData.TotES;
                    _oDataTotal.BillES = _oDataTotal.BillES + oData.BillES;
                    _oDataTotal.TotMS = _oDataTotal.TotMS + oData.TotMS;
                    _oDataTotal.BillMS = _oDataTotal.BillMS + oData.BillMS;
                    _oDataTotal.TotGS = _oDataTotal.TotGS + oData.TotGS;
                    _oDataTotal.BillGS = _oDataTotal.BillGS + oData.BillGS;
                    _oDataTotal.TotOS = _oDataTotal.TotOS + oData.TotOS;
                    _oDataTotal.BillOS = _oDataTotal.BillOS + oData.BillOS;
                    _oDataTotal.TotalOutlet = _oDataTotal.TotalOutlet + oData.TotalOutlet;
                    _oDataTotal.TotalBill = _oDataTotal.TotalBill + oData.TotalBill;



                    _oDataArea.TotEO = _oDataArea.TotEO + oData.TotEO;
                    _oDataArea.BillEO = _oDataArea.BillEO + oData.BillEO;
                    _oDataArea.TotHS = _oDataArea.TotHS + oData.TotHS;
                    _oDataArea.BillHS = _oDataArea.BillHS + oData.BillHS;
                    _oDataArea.TotDS = _oDataArea.TotDS + oData.TotDS;
                    _oDataArea.BillDS = _oDataArea.BillDS + oData.BillDS;
                    _oDataArea.TotES = _oDataArea.TotES + oData.TotES;
                    _oDataArea.BillES = _oDataArea.BillES + oData.BillES;
                    _oDataArea.TotMS = _oDataArea.TotMS + oData.TotMS;
                    _oDataArea.BillMS = _oDataArea.BillMS + oData.BillMS;
                    _oDataArea.TotGS = _oDataArea.TotGS + oData.TotGS;
                    _oDataArea.BillGS = _oDataArea.BillGS + oData.BillGS;
                    _oDataArea.TotOS = _oDataArea.TotOS + oData.TotOS;
                    _oDataArea.BillOS = _oDataArea.BillOS + oData.BillOS;
                    _oDataArea.TotalOutlet = _oDataArea.TotalOutlet + oData.TotalOutlet;
                    _oDataArea.TotalBill = _oDataArea.TotalBill + oData.TotalBill;


                    _oDataZone.TotEO = _oDataZone.TotEO + oData.TotEO;
                    _oDataZone.BillEO = _oDataZone.BillEO + oData.BillEO;
                    _oDataZone.TotHS = _oDataZone.TotHS + oData.TotHS;
                    _oDataZone.BillHS = _oDataZone.BillHS + oData.BillHS;
                    _oDataZone.TotDS = _oDataZone.TotDS + oData.TotDS;
                    _oDataZone.BillDS = _oDataZone.BillDS + oData.BillDS;
                    _oDataZone.TotES = _oDataZone.TotES + oData.TotES;
                    _oDataZone.BillES = _oDataZone.BillES + oData.BillES;
                    _oDataZone.TotMS = _oDataZone.TotMS + oData.TotMS;
                    _oDataZone.BillMS = _oDataZone.BillMS + oData.BillMS;
                    _oDataZone.TotGS = _oDataZone.TotGS + oData.TotGS;
                    _oDataZone.BillGS = _oDataZone.BillGS + oData.BillGS;
                    _oDataZone.TotOS = _oDataZone.TotOS + oData.TotOS;
                    _oDataZone.BillOS = _oDataZone.BillOS + oData.BillOS;
                    _oDataZone.TotalOutlet = _oDataZone.TotalOutlet + oData.TotalOutlet;
                    _oDataZone.TotalBill = _oDataZone.TotalBill + oData.TotalBill;

                }
            }
            #endregion

            #region Beat

            if (sType == "Beat")
            {
                foreach (Data oData in oDatas)
                {
                    if (nCount == 0)
                    {
                        _oDataTotal = new Data();
                        _oDatas.Add(_oDataTotal);
                        _oDataTotal.Outlet = "Total";
                        _oDataTotal.Type = "National";
                        _oDataTotal.ID = "0";
                        _oDataTotal.AreaID = oData.AreaID;
                        _oDataTotal.TerritoryID = oData.TerritoryID;
                        _oDataTotal.CustomerID = oData.CustomerID;
                        _oDataTotal.RouteID = "0";
                        _oDataTotal.BeatID = "0";

                        _oDataTotal.AreaName = oData.AreaName;
                        _oDataTotal.ZoneName = oData.ZoneName;
                        _oDataTotal.CustomerName = oData.CustomerName;
                        _oDataTotal.RouteName = oData.RouteName;
                        _oDataTotal.BeatName = oData.BeatName;

                        _oDataTotal.Value = "Success";
                        nCount++;
                    }
                    if (_oDataRoute.RouteName != oData.RouteName)
                    {
                        _oDataRoute = new Data();
                        _oDatas.Add(_oDataRoute);
                        _oDataRoute.RouteName = oData.RouteName;
                        _oDataRoute.Outlet = oData.RouteName;
                        _oDataRoute.Type = "Route";
                        _oDataRoute.ID = oData.RouteID;
                        _oDataRoute.Value = "Success";
                        _oDataRoute.AreaID = oData.AreaID;
                        _oDataRoute.TerritoryID = oData.TerritoryID;
                        _oDataRoute.CustomerID = oData.CustomerID;

                        _oDataRoute.RouteID = oData.RouteID;
                        _oDataRoute.BeatID = oData.BeatID;

                        _oDataRoute.AreaName = oData.AreaName;
                        _oDataRoute.ZoneName = oData.ZoneName;
                        _oDataRoute.CustomerName = oData.CustomerName;
                        //_oDataRoute.RouteName = oData.RouteName;
                        _oDataRoute.BeatName = oData.BeatName;

                    }


                    _oDataBeat = new Data();
                    _oDataBeat.Value = "Success";
                    _oDataBeat.ID = oData.BeatID;
                    _oDataBeat.AreaID = oData.AreaID;
                    _oDataBeat.TerritoryID = oData.TerritoryID;
                    _oDataBeat.CustomerID = oData.CustomerID;

                    _oDataBeat.RouteID = oData.RouteID;
                    _oDataBeat.BeatID = oData.BeatID;

                    _oDataBeat.AreaName = oData.AreaName;
                    _oDataBeat.ZoneName = oData.ZoneName;
                    _oDataBeat.CustomerName = oData.CustomerName;
                    _oDataBeat.RouteName = oData.RouteName;
                    _oDataBeat.BeatName = oData.BeatName;


                    _oDataBeat.Outlet = oData.BeatName;
                    _oDataBeat.TotEO = oData.TotEO;
                    _oDataBeat.BillEO = oData.BillEO;
                    _oDataBeat.TotHS = oData.TotHS;
                    _oDataBeat.BillHS = oData.BillHS;
                    _oDataBeat.TotDS = oData.TotDS;
                    _oDataBeat.BillDS = oData.BillDS;
                    _oDataBeat.TotES = oData.TotES;
                    _oDataBeat.BillES = oData.BillES;
                    _oDataBeat.TotMS = oData.TotMS;
                    _oDataBeat.BillMS = oData.BillMS;
                    _oDataBeat.TotGS = oData.TotGS;
                    _oDataBeat.BillGS = oData.BillGS;
                    _oDataBeat.TotOS = oData.TotOS;
                    _oDataBeat.BillOS = oData.BillOS;
                    _oDataBeat.TotalOutlet = oData.TotalOutlet;
                    _oDataBeat.TotalBill = oData.TotalBill;

                    _oDataBeat.Type = "Beat";
                    _oDatas.Add(_oDataBeat);

                    _oDataTotal.TotEO = _oDataTotal.TotEO + oData.TotEO;
                    _oDataTotal.BillEO = _oDataTotal.BillEO + oData.BillEO;
                    _oDataTotal.TotHS = _oDataTotal.TotHS + oData.TotHS;
                    _oDataTotal.BillHS = _oDataTotal.BillHS + oData.BillHS;
                    _oDataTotal.TotDS = _oDataTotal.TotDS + oData.TotDS;
                    _oDataTotal.BillDS = _oDataTotal.BillDS + oData.BillDS;
                    _oDataTotal.TotES = _oDataTotal.TotES + oData.TotES;
                    _oDataTotal.BillES = _oDataTotal.BillES + oData.BillES;
                    _oDataTotal.TotMS = _oDataTotal.TotMS + oData.TotMS;
                    _oDataTotal.BillMS = _oDataTotal.BillMS + oData.BillMS;
                    _oDataTotal.TotGS = _oDataTotal.TotGS + oData.TotGS;
                    _oDataTotal.BillGS = _oDataTotal.BillGS + oData.BillGS;
                    _oDataTotal.TotOS = _oDataTotal.TotOS + oData.TotOS;
                    _oDataTotal.BillOS = _oDataTotal.BillOS + oData.BillOS;
                    _oDataTotal.TotalOutlet = _oDataTotal.TotalOutlet + oData.TotalOutlet;
                    _oDataTotal.TotalBill = _oDataTotal.TotalBill + oData.TotalBill;

                    _oDataRoute.TotEO = _oDataRoute.TotEO + oData.TotEO;
                    _oDataRoute.BillEO = _oDataRoute.BillEO + oData.BillEO;
                    _oDataRoute.TotHS = _oDataRoute.TotHS + oData.TotHS;
                    _oDataRoute.BillHS = _oDataRoute.BillHS + oData.BillHS;
                    _oDataRoute.TotDS = _oDataRoute.TotDS + oData.TotDS;
                    _oDataRoute.BillDS = _oDataRoute.BillDS + oData.BillDS;
                    _oDataRoute.TotES = _oDataRoute.TotES + oData.TotES;
                    _oDataRoute.BillES = _oDataRoute.BillES + oData.BillES;
                    _oDataRoute.TotMS = _oDataRoute.TotMS + oData.TotMS;
                    _oDataRoute.BillMS = _oDataRoute.BillMS + oData.BillMS;
                    _oDataRoute.TotGS = _oDataRoute.TotGS + oData.TotGS;
                    _oDataRoute.BillGS = _oDataRoute.BillGS + oData.BillGS;
                    _oDataRoute.TotOS = _oDataRoute.TotOS + oData.TotOS;
                    _oDataRoute.BillOS = _oDataRoute.BillOS + oData.BillOS;
                    _oDataRoute.TotalOutlet = _oDataRoute.TotalOutlet + oData.TotalOutlet;
                    _oDataRoute.TotalBill = _oDataRoute.TotalBill + oData.TotalBill;

                }
            }
            #endregion

            if (sType == "Summary")
            {
                _oData.InsertReportLog(sUser);
            }
            else if (sType == "Beat")
            {
                _oData.InsertReportLogRoute(sUser);
            }


            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());

        }
    }
    public class Data
    {
        public string AreaName;
        public string ZoneName;
        public string Outlet;
        public string Type;
        public string ID;
        public string AreaID;
        public string TerritoryID;
        public string CustomerID;

        public string RouteID;
        public string RouteName;
        public string BeatID;
        public string BeatName;
        public string CustomerName;

        public int TotEO;
        public int BillEO;
        public int TotHS;
        public int BillHS;
        public int TotDS;
        public int BillDS;
        public int TotES;
        public int BillES;
        public int TotMS;
        public int BillMS;
        public int TotGS;
        public int BillGS;
        public int TotOS;
        public int BillOS;
        public int TotalOutlet;
        public int TotalBill;

        public string TotEOText;
        public string BillEOText;
        public string EOPerc;

        public string TotHSText;
        public string BillHSText;
        public string HSPerc;

        public string TotDSText;
        public string BillDSText;
        public string DSPerc;

        public string TotESText;
        public string BillESText;
        public string ESPerc;

        public string TotMSText;
        public string BillMSText;
        public string MSPerc;

        public string TotGSText;
        public string BillGSText;
        public string GSPerc;

        public string TotOSText;
        public string BillOSText;
        public string OSPerc;

        public string TotalOutletText;
        public string TotalBillText;
        public string TotalPerc;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10044";
            string sReportName = "BLL-Numeric Distribution (ND) [212]";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }

        public void InsertReportLogRoute(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10045";
            string sReportName = "BLL-Numeric Distribution Route/Beat";
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

        public void GetData(string sMonth, string sYear, string sAndroidAppID, string sUser)
        {
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select a.CustomerID, CustomerName, AreaID, AreaSort, AreaShortName, TerritoryID, TerritorySort, TerritoryShortName, " +
                   " Month, Year, TotEO, BillEO, TotHS, BillHS, TotDS, BillDS, TotES, BillES, TotMS, BillMS, TotGS, BillGS, TotOS,  " +
                   " BillOS, TotalOutlet, TotalBill from DWDB.dbo.t_BLLOutletBilling a,  " +
                   " (Select CustomerID, CustomerName, AreaID, AreaSort, AreaShortName, TerritoryID, TerritorySort,  " +
                   " TerritoryShortName  from DWDB.dbo.t_CustomerDetails Where CompanyName='BLL')b " +
                   " Where a.CustomerID=b.CustomerID and Month = '" + sMonth + "' and Year = '" + sYear + "' ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUser + "')) ";
            }
            sSQL = sSQL + " Order by AreaSort, TerritorySort, CustomerName ";
            try
            {
                Data _oData;
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oData = new Data();

                    _oData.AreaName = reader["AreaShortName"].ToString();
                    _oData.ZoneName = reader["TerritoryShortName"].ToString();
                    _oData.Outlet = reader["CustomerName"].ToString();
                    _oData.AreaID = reader["AreaID"].ToString();
                    _oData.TerritoryID = reader["TerritoryID"].ToString();
                    _oData.CustomerID = reader["CustomerID"].ToString();

                    _oData.TotEO = Convert.ToInt32(reader["TotEO"]);
                    _oData.BillEO = Convert.ToInt32(reader["BillEO"]);
                    _oData.TotHS = Convert.ToInt32(reader["TotHS"]);
                    _oData.BillHS = Convert.ToInt32(reader["BillHS"]);
                    _oData.TotDS = Convert.ToInt32(reader["TotDS"]);
                    _oData.BillDS = Convert.ToInt32(reader["BillDS"]);
                    _oData.TotES = Convert.ToInt32(reader["TotES"]);
                    _oData.BillES = Convert.ToInt32(reader["BillES"]);
                    _oData.TotMS = Convert.ToInt32(reader["TotMS"]);
                    _oData.BillMS = Convert.ToInt32(reader["BillMS"]);
                    _oData.TotGS = Convert.ToInt32(reader["TotGS"]);
                    _oData.BillGS = Convert.ToInt32(reader["BillGS"]);
                    _oData.TotOS = Convert.ToInt32(reader["TotOS"]);
                    _oData.BillOS = Convert.ToInt32(reader["BillOS"]);
                    _oData.TotalOutlet = Convert.ToInt32(reader["TotalOutlet"]);
                    _oData.TotalBill = Convert.ToInt32(reader["TotalBill"]);

                    InnerList.Add(_oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetBeatData(string sMonth, string sYear, string sCustomerID)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select AreaID, AreaName, TerritoryID, TerritoryName, CustomerID, CustomerName, DSRID as RouteID, DSRName as RouteName, BeatID, BeatName, TMonth, TYear, " +
                   " sum(Tot_1EO)As TotEO,sum(Bill_1EO)as BillEO, Sum(Tot_2HS)as TotHS, Sum(Bill_2HS)As BillHS, " +
                   " Sum(Tot_3DS)as TotDS,  Sum(Bill_3DS)As BillDS,Sum(Tot_4ES)As TotES,Sum(Bill_4ES)As BillES, " +
                   " sum(Tot_5MS)As TotMS, Sum(Bill_5MS)As BillMS, Sum(Tot_6GS)As TotGS, sum(Bill_6GS)as BillGS, " +
                   " Sum(Tot_7OS)as TotOS, Sum(Bill_7OS)As BillOS,Sum(TotalOutlet)as TotalOutlet, Sum(TotalBill)as TotalBill " +
                   " from  " +
                   " ( " +
                   " select AreaID,AreaName, TerritoryID,TerritoryName,CustomerID,CustomerCode,CustomerName,DSRID,DSRCode,DSRName,BeatID,BeatName,TMonth,TYear, " +
                   " isnull(Tot_1EO,0)As Tot_1EO, isnull(Tot_2HS,0)as Tot_2HS, isnull(Tot_3DS,0)as Tot_3DS, isnull(Tot_4ES,0)As Tot_4ES, " +
                   " isnull(Tot_5MS,0)As Tot_5MS, isnull(Tot_6GS,0)As Tot_6GS, isnull(Tot_7OS,0)as Tot_7OS,isnull((Tot_1EO+Tot_2HS+Tot_3DS+Tot_4ES+Tot_5MS+Tot_6GS+Tot_7OS),0)as TotalOutlet, " +
                   " isnull(Bill_1EO,0)as Bill_1EO,isnull(Bill_2HS,0)As Bill_2HS, isnull(Bill_3DS,0)As Bill_3DS,isnull(Bill_4ES,0)As Bill_4ES, isnull(Bill_5MS,0)As Bill_5MS,isnull( Bill_6GS,0)as Bill_6GS,  " +
                   " isnull(Bill_7OS,0)As Bill_7OS, isnull((Bill_1EO+Bill_2HS+Bill_3DS+Bill_4ES+Bill_5MS+Bill_6GS+Bill_7OS),0)as TotalBill " +
                   " from " +
                   " ( " +
                   " select b.DSRID, DSRCode,DSRName, RouteID as BeatID, RouteName as BeatName, RouteTypeID,RouteType, AreaID,AreaName, TerritoryID,TerritoryName,CustomerID,CustomerCode,CustomerName  " +
                   " from BLLSysDB.dbo.t_DMSRoute a, BLLSysDB.dbo.t_DMSDSR b, BLLSysDB.dbo.v_CustomerDetails c  " +
                   " Where a.DSRID=b.DSRID and a.DistributorID=c.CustomerID  and CustomerID = '" + sCustomerID + "' " +
                   " )As Main  " +
                   " left outer join " +
                   " ( " +
                //---------------------Total Outlet  Start--------
                   " select RouteID,  " +
                   " sum(case when RetailTypeID=1 then  TotalOutlet else 0 end )as Tot_1EO, " +
                   " sum(case when RetailTypeID=2 then  TotalOutlet else 0 end )as Tot_2HS, " +
                   " sum(case when RetailTypeID=3 then  TotalOutlet else 0 end )as Tot_3DS, " +
                   " sum(case when RetailTypeID=4 then  TotalOutlet else 0 end )as Tot_4ES, " +
                   " sum(case when RetailTypeID=5 then  TotalOutlet else 0 end )as Tot_5MS, " +
                   " sum(case when RetailTypeID=6 then  TotalOutlet else 0 end )as Tot_6GS, " +
                   " sum(case when RetailTypeID in (7,null) then  TotalOutlet else 0 end )as Tot_7OS " +
                   " from " +
                   " ( " +
                   " select RouteID, RetailTypeID, count(RetailID)as TotalOutlet " +
                   " from BLLSysDB.dbo.t_DMSClusterOutlet " +
                   " group by  RouteID, RetailTypeID " +
                   " )As TotalOut group by RouteID " +
                   " ) TTLOut on Main.BeatID=TTLOut.RouteID " +
                // ---------------- Total Outlet End--------
                   " left outer join " +
                   " ( " +
                // ---------------------Billing Start--------
                   " select RouteID,  " +
                   " sum(case when RetailTypeID=1 then  TotBill else 0 end )as Bill_1EO, " +
                   " sum(case when RetailTypeID=2 then  TotBill else 0 end )as Bill_2HS, " +
                   " sum(case when RetailTypeID=3 then  TotBill else 0 end )as Bill_3DS, " +
                   " sum(case when RetailTypeID=4 then  TotBill else 0 end )as Bill_4ES, " +
                   " sum(case when RetailTypeID=5 then  TotBill else 0 end )as Bill_5MS, " +
                   " sum(case when RetailTypeID=6 then  TotBill else 0 end )as Bill_6GS, " +
                   " sum(case when RetailTypeID in (7,null) then  TotBill else 0 end )as Bill_7OS " +
                   " from " +
                   " ( " +
                   " select a.RouteID,RetailTypeID, count(distinct OutletID)As TotBill " +
                   " from BLLSysDB.dbo.t_DMSOutletWiseBillingInfo a, BLLSysDB.dbo.t_DMSClusterOutlet b " +
                   " where Month(Operationdate) = '" + sMonth + "' and  Year(Operationdate) = '" + sYear + "' " +
                   " and a.OutletID=b.RetailID " +
                   " group by a.RouteID,RetailTypeID  " +
                   " )As Bill group by RouteID " +
                // ---------------------Billing End--------
                   " )As Billing on Main.BeatID=Billing.RouteID " +
                //----------------Tran Month and Year----
                   " inner join " +
                   " ( " +
                   " select distinct DistributorID, month(tranDate)as TMonth, Year (tranDate)as TYear " +
                   " from BLLSysDB.dbo.t_DMSProductTran where Month(TranDate) = '" + sMonth + "' and  Year(TranDate) = '" + sYear + "' " +
                   " )As BillTran on Main.CustomerID=BillTran.DistributorID " +
                   " )x Group by AreaID, AreaName, TerritoryID, TerritoryName, CustomerID, CustomerName, DSRID, DSRName,BeatID,BeatName,TMonth,TYear " +
                   " Order by DSRName, BeatName ";
            try
            {
                Data _oData;
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oData = new Data();

                    _oData.RouteID = reader["RouteID"].ToString();
                    _oData.RouteName = reader["RouteName"].ToString();
                    _oData.BeatID = reader["BeatID"].ToString();
                    _oData.BeatName = reader["BeatName"].ToString();

                    _oData.AreaID = reader["AreaID"].ToString();
                    _oData.AreaName = reader["AreaName"].ToString();
                    _oData.TerritoryID = reader["TerritoryID"].ToString();
                    _oData.ZoneName = reader["TerritoryName"].ToString();
                    _oData.CustomerID = reader["CustomerID"].ToString();
                    _oData.Outlet = reader["CustomerName"].ToString();
                    _oData.CustomerName = reader["CustomerName"].ToString();

                    _oData.TotEO = Convert.ToInt32(reader["TotEO"]);
                    _oData.BillEO = Convert.ToInt32(reader["BillEO"]);
                    _oData.TotHS = Convert.ToInt32(reader["TotHS"]);
                    _oData.BillHS = Convert.ToInt32(reader["BillHS"]);
                    _oData.TotDS = Convert.ToInt32(reader["TotDS"]);
                    _oData.BillDS = Convert.ToInt32(reader["BillDS"]);
                    _oData.TotES = Convert.ToInt32(reader["TotES"]);
                    _oData.BillES = Convert.ToInt32(reader["BillES"]);
                    _oData.TotMS = Convert.ToInt32(reader["TotMS"]);
                    _oData.BillMS = Convert.ToInt32(reader["BillMS"]);
                    _oData.TotGS = Convert.ToInt32(reader["TotGS"]);
                    _oData.BillGS = Convert.ToInt32(reader["BillGS"]);
                    _oData.TotOS = Convert.ToInt32(reader["TotOS"]);
                    _oData.BillOS = Convert.ToInt32(reader["BillOS"]);
                    _oData.TotalOutlet = Convert.ToInt32(reader["TotalOutlet"]);
                    _oData.TotalBill = Convert.ToInt32(reader["TotalBill"]);

                    InnerList.Add(_oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        
        public List<Data> getResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();


            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.Outlet = oData.Outlet;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;
                _oData.ID = oData.ID;
                _oData.AreaID = oData.AreaID;
                _oData.TerritoryID = oData.TerritoryID;
                _oData.CustomerID = oData.CustomerID;

                _oData.AreaName = oData.AreaName;
                _oData.ZoneName = oData.ZoneName;
                _oData.Outlet = oData.Outlet;
                _oData.CustomerName = oData.CustomerName;


                _oData.RouteID = oData.RouteID;
                _oData.RouteName = oData.RouteName;
                _oData.BeatID = oData.BeatID;
                _oData.BeatName = oData.BeatName;

                _oData.TotEOText = oData.TotEO.ToString();
                _oData.BillEOText = oData.BillEO.ToString();
                if (oData.TotEO > 0)
                    _oData.EOPerc = Convert.ToString(Math.Round(Convert.ToDouble(oData.BillEO) / oData.TotEO * 100,0));
                else _oData.EOPerc = "0";

                _oData.TotHSText = oData.TotHS.ToString();
                _oData.BillHSText = oData.BillHS.ToString();
                if (oData.TotHS > 0)
                    _oData.HSPerc = Convert.ToString(Math.Round(Convert.ToDouble(oData.BillHS) / oData.TotHS * 100, 0));
                else _oData.HSPerc = "0";

                _oData.TotDSText = oData.TotDS.ToString();
                _oData.BillDSText = oData.BillDS.ToString();
                if (oData.TotDS > 0)
                    _oData.DSPerc = Convert.ToString(Math.Round(Convert.ToDouble(oData.BillDS) / oData.TotDS * 100, 0));
                else _oData.DSPerc = "0";

                _oData.TotESText = oData.TotES.ToString();
                _oData.BillESText = oData.BillES.ToString();
                if (oData.TotES > 0)
                    _oData.ESPerc = Convert.ToString(Math.Round(Convert.ToDouble(oData.BillES) / oData.TotES * 100, 0));
                else _oData.ESPerc = "0";

                _oData.TotMSText = oData.TotMS.ToString();
                _oData.BillMSText = oData.BillMS.ToString();
                if (oData.TotMS > 0)
                    _oData.MSPerc = Convert.ToString(Math.Round(Convert.ToDouble(oData.BillMS) / oData.TotMS * 100, 0));
                else _oData.MSPerc = "0";

                _oData.TotGSText = oData.TotGS.ToString();
                _oData.BillGSText = oData.BillGS.ToString();
                if (oData.TotGS > 0)
                    _oData.GSPerc = Convert.ToString(Math.Round(Convert.ToDouble(oData.BillGS) / oData.TotGS * 100, 0));
                else _oData.GSPerc = "0";

                _oData.TotOSText = oData.TotOS.ToString();
                _oData.BillOSText = oData.BillOS.ToString();
                if (oData.TotOS > 0)
                    _oData.OSPerc = Convert.ToString(Math.Round(Convert.ToDouble(oData.BillOS) / oData.TotOS * 100, 0));
                else _oData.OSPerc = "0";

                _oData.TotalOutletText = oData.TotalOutlet.ToString();
                _oData.TotalBillText = oData.TotalBill.ToString();
                if (oData.TotalOutlet > 0)
                    _oData.TotalPerc = Convert.ToString(Math.Round(Convert.ToDouble(oData.TotalBill) / oData.TotalOutlet * 100, 0));
                else _oData.TotalPerc = "0";


                eList.Add(_oData);
            }
            return eList;

        }
    
    }
}


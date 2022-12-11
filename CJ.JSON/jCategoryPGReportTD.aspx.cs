
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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.ANDROID;


public partial class jCategoryPGReportTD : System.Web.UI.Page
{
    ReportDocument rptFile;
    protected void Page_Load(object sender, EventArgs e)
    {

        string sYear = Request.QueryString.Get("Year");
        string sMonth = Request.QueryString.Get("Month");
        string sWeek = Request.QueryString.Get("Week");
        string sRegion = Request.QueryString.Get("Region");
        string sArea = Request.QueryString.Get("Area");
        string sOutlet = Request.QueryString.Get("Outlet");
        string sUser = Request.QueryString.Get("UserName");
        string sParamMonth = "";

        //string sYear = "2022";
        //string sMonth = "2";
        //string sWeek = "5";
        //string sRegion = "All";
        //string sArea = "All";
        //string sOutlet = "DDS";
        //string sUser = "hakim";

        try
        {
            //DSTargetVsActualTD oDSTargetVsActualTD = new DSTargetVsActualTD();
            //DSTargetVsActualTD oDSParameter = new DSTargetVsActualTD();

            rptFile = new ReportDocument();
            rptFile.Load(Server.MapPath("Report/rptPGWeekPositionTargetVsActual.rpt"));
            Data oData = new Data();
            DBController.Instance.OpenNewConnection();
            DSTargetVsActualTD oDSTargetVsActualTD = GetDSReport(sYear, sMonth, sWeek, sRegion, sArea, sOutlet);
            DBController.Instance.CloseConnection();

            sParamMonth = oData.GetMonth(sMonth);

            oDSTargetVsActualTD.Parameter.AddParameterRow(sYear, sParamMonth, sWeek, sRegion, sArea, sOutlet);
            oDSTargetVsActualTD.AcceptChanges();
            rptFile.SetDataSource(oDSTargetVsActualTD);
            CRViewer.ReportSource = rptFile;
            CRViewer.DisplayToolbar = true;
            oData.InsertReportLog(sUser);
        }
        catch (Exception ex)
        {
            string ss = ex.Message;
        }

    }
    public class Data
    {
        TELLib _oTELLib;

        public int CY;
        public int LY;

        public double JanCY;
        public double JanLY;
        public double JanTCY;
        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10060";
            string sReportName = "Category Sales";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
        public string GetMonth(string nMonth)
        {
            String sMonth = "";
            if (nMonth == "1")
            {
                sMonth = "Jan";
            }
            else if (nMonth == "2")
            {
                sMonth = "Feb";
            }
            else if (nMonth == "3")
            {
                sMonth = "Mar";
            }
            else if (nMonth == "4")
            {
                sMonth = "Apr";
            }
            else if (nMonth == "5")
            {
                sMonth = "May";
            }
            else if (nMonth == "6")
            {
                sMonth = "Jun";
            }
            else if (nMonth == "7")
            {
                sMonth = "Jul";
            }
            else if (nMonth == "8")
            {
                sMonth = "Aug";
            }
            else if (nMonth == "9")
            {
                sMonth = "Sep";
            }
            else if (nMonth == "10")
            {
                sMonth = "Oct";
            }
            else if (nMonth == "11")
            {
                sMonth = "Nov";
            }
            else if (nMonth == "12")
            {
                sMonth = "Dec";
            }
            return sMonth;
        }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        if (rptFile != null)
        {
            rptFile.Close();
            rptFile.Dispose();
        }
    }

    private DSTargetVsActualTD GetDSReport(string sYear, string sMonth, string sWeek, string sRegion, string sArea, string sOutlet)
    {

        DSTargetVsActualTD oDSTargetVsActualTD = new DSTargetVsActualTD();

        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSQL = "";

        sSQL = " Select PGName,PGCategory,sum(TargetQty) TargetQty,sum(TargetAmount) TargetValue, " +
        " sum(SalesQty) SalesQty,sum(NetSales) NetSales,GETDATE() as SystemDate From(" +
        " Select a.Channel, WeekNo, CMonth, " +
        " CYear, ShowroomCode, a.WarehouseID, MAGID, e.ParentID as BrandID, SalesPersonID, 0 TargetQty, " +
        " 0 TargetAmount, SalesQty, NetSales From DWDB.dbo.t_InvoiceWiseSalesDetail a join " +
        " TELSYSDB.DBO.t_Showroom b on a.WarehouseID = b.WarehouseID  join TELSYSDB.DBO.t_Product c " +
        " on a.ProductID = c.ProductID join TELSysDB.dbo.v_ProductGroup d on c.ProductGroupID = d.AGID " +
        " join TElSYSdb.dbo.t_Brand e on c.BrandID = e.BrandID join TELSysDB.dbo.t_CalendarWeek f " +
        " on a.InvoiceDate between f.FromDate and f.ToDate where Company = 'TEL' and BUID = 2 " +

        " Union All " +

        " Select c.ChannelShortName, WeekNo, TMonth, TYear, ShowroomCode, b.WarehouseID, " +
        " MAGID, BrandID, SalesPersonID, TargetQty, TargetAmount, 0 as SalesQty, 0 as NetSales " +
        " From TELSysDB.dbo.t_PlanExecutiveLeadTarget a join TELSysDB.dbo.t_Showroom b " +
        " on a.CustomerID = b.CustomerID join TElSYSdb.dbo.t_Channel c on a.Channel = c.ChannelID " +
        " where TargetType = 6 and a.Channel in (4, 13) " +
        " ) main join TELSysDB.dbo.t_Employee SE " +
        " on main.SalesPersonID = se.EmployeeID " +
        " join " +
        " (Select mag.PdtGroupID as MAGID, mag.PdtGroupName " +
        " as MAGName, pg.PdtGroupID as PGID, pg.PdtGroupName as PGname, pg.PGCategory, PG.POS " +
        " From TELSysDB.dbo.t_ProductGroup MAG join TELSysDB.dbo.t_ProductGroup PG " +
        " on mag.PdtGroupType = 2 and mag.ParentID = pg.PdtGroupID) MAGPG on main.MAGID = MAGPG.MAGID " +
        " join TELSysDB.dbo.t_Brand Brand on main.BrandID = Brand.BrandID " +
        " left outer join " +
        " (select WarehouseID, ShowroomCode, b.EmployeeID as BMID, b.EmployeeCode as BMCode, " +
        " b.EmployeeName as BMName from TELSysDB.dbo.t_HRPosition a join TELSysDB.dbo.t_Employee b " +
        " on a.EmployeeID = b.employeeid join TElSYSDB.dbo.t_Showroom c on b.LocationID = c.LocationID " +
        " where role = 11 and sbuid = 2) BM on main.WarehouseID = BM.WarehouseID " +
        " Left outer join " +
        " (Select distinct EMP.EmployeeID as ABMID, emp.EmployeeCode " +
        " as ABMCode, emp.EmployeeName as ABMName, SE.ProductGroupID as PGID, WarehouseID From " +
        " TELSysDB.dbo.t_HRPosition SE join TELSysDB.dbo.t_HRPosition ABM on " +
        " se.ParentID = ABM.PositionID join TELSysDB.dbo.t_Employee EMP on " +
        " ABM.EmployeeID = emp.EmployeeID " +
        " join t_showroom sr on(emp.LocationID = sr.LocationID) where SE.role = 12) ABM " +
        " on MAGPG.PGID = ABM.PGID and main.WarehouseID = abm.WarehouseID " +
        " where CMonth = '" + sMonth + "' and CYear = '" + sYear + "' ";

        if (sWeek != "All")
        {
            sSQL += " and WeekNo = '"+ sWeek + "' ";
        }

        //Outlet
        if (sOutlet != "All")
        {
            sSQL += " and main.WarehouseID = (Select top 1 WarehouseID from t_Showroom Where ShowroomCode = '" + sOutlet + "') ";
        }
        else if (sArea != "All")
        {
            //Area--
            sSQL += " and main.WarehouseID IN (Select WarehouseID from t_Customer a, t_Showroom b, t_MarketGroup c Where " +
        " a.CustomerID = b.CustomerID and a.MarketGroupID = c.MarketGroupID " +
        " and c.ChannelID = 4 and c.MarketGroupType = 2 and ShortName = '"+ sArea + "') ";
        }
        else if (sRegion != "All")
        {
            //Region--
            sSQL += " and main.WarehouseID IN ( " +
        " Select WarehouseID from t_Customer a, t_Showroom b Where a.CustomerID = b.CustomerID " +
        " and a.MarketGroupID IN(" +
        " Select MarketGroupID from t_MarketGroup where MarketGroupType = 2 and ParentID IN(" +
        " Select MarketGroupID from t_MarketGroup Where MarketGroupType = 1 " +
        " and ChannelID = 4 and ShortName = '"+ sRegion + "'))) ";
        }

        sSQL +=" and TargetQty+TargetAmount + SalesQty + NetSales != 0 " +
        " group by PGname,PGCategory, POS order by PGCategory, POS ";

        cmd.CommandText = sSQL;
        cmd.CommandType = CommandType.Text;
        IDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            DSTargetVsActualTD.TargetVaActualTDRow oTargetVaActualTDRow = oDSTargetVsActualTD.TargetVaActualTD.NewTargetVaActualTDRow();

            oTargetVaActualTDRow.Category = reader["PGCategory"].ToString();
            oTargetVaActualTDRow.PGName = reader["PGName"].ToString();
            oTargetVaActualTDRow.TargetQty = Convert.ToInt32(reader["TargetQty"]);
            oTargetVaActualTDRow.ActualQty = Convert.ToInt32(reader["SalesQty"]);
            oTargetVaActualTDRow.TargetValue = Convert.ToDouble(reader["TargetValue"]);
            oTargetVaActualTDRow.ActualValue = Convert.ToDouble(reader["NetSales"]);

            oDSTargetVsActualTD.TargetVaActualTD.AddTargetVaActualTDRow(oTargetVaActualTDRow);
            oDSTargetVsActualTD.AcceptChanges();
        }

        

        return oDSTargetVsActualTD;
    }
}



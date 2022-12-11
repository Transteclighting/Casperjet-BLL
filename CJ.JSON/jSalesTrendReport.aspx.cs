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
using CJ.Class.ANDROID;

public partial class jSalesTrendReport : System.Web.UI.Page
{
    ReportDocument rptFile;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sValue = Request.QueryString.Get("Value");
            string sCompany = Request.QueryString.Get("Company");
            string sUser = Request.QueryString.Get("UserName");
            string sReqType = Request.QueryString.Get("ReqType");

            //string sValue = "TD";
            //string sCompany = "TEL";
            //string sUser = "Hakim";
            //string sReqType = "AllSale";


            string sCompanyFullName = "";
            string sValueType = "";
            string sCustGroupID = "";
            string sDatabase = "x";
            if (sCompany == "TEL")
            {
                sDatabase = "TELSysDB";
                sCompanyFullName = "Transcom Electronics Limited";
            }
            else if (sCompany == "TML")
            {
                sDatabase = "TMLSysDB";
                sCompanyFullName = "Transcom Mobiles Limited";
            }
            #region
            if (sCompany == "TEL")
            {
                if (sValue == "Area-1")
                {
                    sCustGroupID = "18";
                    sValueType = "Area";
                }
                else if (sValue == "Area-2")
                {
                    sCustGroupID = "19";
                    sValueType = "Area";
                }
                else if (sValue == "Area-3")
                {
                    sCustGroupID = "311";
                    sValueType = "Area";
                }
                else if (sValue == "Zone-A")
                {
                    sCustGroupID = "175";
                    sValueType = "Zone";
                }
                else if (sValue == "Zone-B")
                {
                    sCustGroupID = "135";
                    sValueType = "Zone";
                }
                else if (sValue == "Zone-C")
                {
                    sCustGroupID = "313";
                    sValueType = "Zone";
                }
                else if (sValue == "Zone-D")
                {
                    sCustGroupID = "312";
                    sValueType = "Zone";
                }
                else if (sValue == "Zone-E")
                {
                    sCustGroupID = "314";
                    sValueType = "Zone";
                }
                else if (sValue == "Total")
                {
                    sCustGroupID = "";
                    sValueType = "Total";
                }
                else
                {
                    sCustGroupID = "";
                    sValueType = "Outlet";
                }
            }
            else
            {
                if (sValue == "Area-1")
                {
                    sCustGroupID = "1";
                    sValueType = "Area";
                }
                else if (sValue == "Area-2")
                {
                    sCustGroupID = "2";
                    sValueType = "Area";
                }
                else if (sValue == "Area-3")
                {
                    sCustGroupID = "5";
                    sValueType = "Area";
                }
                else if (sValue == "Zone-A")
                {
                    sCustGroupID = "43";
                    sValueType = "Zone";
                }
                else if (sValue == "Zone-B")
                {
                    sCustGroupID = "44";
                    sValueType = "Zone";
                }
                else if (sValue == "Zone-C")
                {
                    sCustGroupID = "62";
                    sValueType = "Zone";
                }
                else if (sValue == "Zone-D")
                {
                    sCustGroupID = "63";
                    sValueType = "Zone";
                }
                else if (sValue == "Zone-E")
                {
                    sCustGroupID = "73";
                    sValueType = "Zone";
                }
                else if (sValue == "Total")
                {
                    sCustGroupID = "";
                    sValueType = "Total";
                }
                else
                {
                    sCustGroupID = "";
                    sValueType = "Outlet";
                }
            }
            #endregion
            try
            {
                rptFile = new ReportDocument();
                rptFile.Load(Server.MapPath("Report/rptSalesTrend.rpt"));
                Data oData = new Data();
                DBController.Instance.OpenNewConnection();
                DSSalesTrend oDSSalesTrend = GetDataSet(sCompany, sDatabase, sValue, sValueType, sCustGroupID, sReqType);
                oData.GetLYSaleYTD(sCompany, sDatabase, sValue, sValueType, sCustGroupID, sReqType);
                oData.GetCYSaleYTD(sCompany, sDatabase, sValue, sValueType, sCustGroupID, sReqType);
                DBController.Instance.CloseConnection();
                
                oData.FillData(oDSSalesTrend);
                oDSSalesTrend.Parameter.AddParameterRow(sCompanyFullName, sValue, oData.JanCY, oData.JanLY, oData.FebCY, oData.FebLY, oData.MarCY, oData.MarLY, oData.AprCY, oData.AprLY, oData.MayCY, oData.MayLY, oData.JunCY, oData.JunLY, oData.JulCY, oData.JulLY, oData.AugCY, oData.AugLY, oData.SepCY, oData.SepLY, oData.OctCY, oData.OctLY, oData.NovCY, oData.NovLY, oData.DecCY, oData.DecLY, oData.AsOfTodayCY, oData.AsOfTodayLY, oData.CY, oData.LY, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "");
                oDSSalesTrend.AcceptChanges();

                rptFile.SetDataSource(oDSSalesTrend);
                CRViewer.ReportSource = rptFile;
                oData.InsertReportLog(sUser);
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
            }
        }

    }
    public class Data
    {
        public int CY;
        public int LY;
        public double JanCY;
        public double JanLY;
        public double FebCY;
        public double FebLY;
        public double MarCY;
        public double MarLY;
        public double AprCY;
        public double AprLY;
        public double MayCY;
        public double MayLY;
        public double JunCY;
        public double JunLY;
        public double JulCY;
        public double JulLY;
        public double AugCY;
        public double AugLY;
        public double SepCY;
        public double SepLY;
        public double OctCY;
        public double OctLY;
        public double NovCY;
        public double NovLY;
        public double DecCY;
        public double DecLY;

        public double AsOfTodayCY;
        public double AsOfTodayLY;

        public string Value;


        public void FillData(DSSalesTrend oDSSalesTrend)
        {
            DSSalesTrend oDSFilteredData = new DSSalesTrend();
            int nYear = DateTime.Today.Year;
            int nLastYear = nYear - 1;
            CY = nYear;
            LY = nLastYear;
            foreach (DSSalesTrend.SalesTrendRow oSalesTrendRow in oDSSalesTrend.SalesTrend)
            {
                #region Jan
                //Jan CY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRJanCY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Jan' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRJanCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSJanCYRow in oDSFilteredData.SalesTrend)
                {
                    JanCY = Convert.ToDouble(oDSJanCYRow.SalesValue);
                }
                //Jan LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRJanLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Jan' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRJanLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSJanLYRow in oDSFilteredData.SalesTrend)
                {
                    JanLY = Convert.ToDouble(oDSJanLYRow.SalesValue);
                }
                #endregion
                #region Feb
                //Feb CY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRFebCY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Feb' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRFebCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSFebCYRow in oDSFilteredData.SalesTrend)
                {
                    FebCY = Convert.ToDouble(oDSFebCYRow.SalesValue);
                }
                //Feb LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRFebLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Feb' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRFebLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSFebLYRow in oDSFilteredData.SalesTrend)
                {
                    FebLY = Convert.ToDouble(oDSFebLYRow.SalesValue);
                }
                #endregion
                #region Mar
                //Mar CY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRMarCY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Mar' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRMarCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSMarCYRow in oDSFilteredData.SalesTrend)
                {
                    MarCY = Convert.ToDouble(oDSMarCYRow.SalesValue);
                }
                //Mar LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRMarLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Mar' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRMarLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSMarLYRow in oDSFilteredData.SalesTrend)
                {
                    MarLY = Convert.ToDouble(oDSMarLYRow.SalesValue);
                }
               #endregion
                #region Apr
                //Apr CY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRAprCY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Apr' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRAprCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSAprCYRow in oDSFilteredData.SalesTrend)
                {
                    AprCY = Convert.ToDouble(oDSAprCYRow.SalesValue);
                }
                //Apr LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRAprLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Apr' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRAprLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSAprLYRow in oDSFilteredData.SalesTrend)
                {
                    AprLY = Convert.ToDouble(oDSAprLYRow.SalesValue);
                }
                #endregion
                #region May
                //May CY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRMayCY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'May' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRMayCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSMayCYRow in oDSFilteredData.SalesTrend)
                {
                    MayCY = Convert.ToDouble(oDSMayCYRow.SalesValue);
                }
                //May LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRMayLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'May' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRMayLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSMayLYRow in oDSFilteredData.SalesTrend)
                {
                    MayLY = Convert.ToDouble(oDSMayLYRow.SalesValue);
                }
                #endregion
                #region Jun
                //Jun CY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRJunCY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Jun' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRJunCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSJunCYRow in oDSFilteredData.SalesTrend)
                {
                    JunCY = Convert.ToDouble(oDSJunCYRow.SalesValue);
                }
                //Jun LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRJunLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Jun' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRJunLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSJunLYRow in oDSFilteredData.SalesTrend)
                {
                    JunLY = Convert.ToDouble(oDSJunLYRow.SalesValue);
                }
                #endregion
                #region Jul
                //Jul CY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRJulCY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Jul' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRJulCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSJulCYRow in oDSFilteredData.SalesTrend)
                {
                    JulCY = Convert.ToDouble(oDSJulCYRow.SalesValue);
                }
                //Jul LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRJulLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Jul' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRJulLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSJulLYRow in oDSFilteredData.SalesTrend)
                {
                    JulLY = Convert.ToDouble(oDSJulLYRow.SalesValue);
                }
                #endregion
                #region Aug
                //Aug CY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRAugCY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Aug' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRAugCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSAugCYRow in oDSFilteredData.SalesTrend)
                {
                    AugCY = Convert.ToDouble(oDSAugCYRow.SalesValue);
                }
                //Aug LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRAugLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Aug' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRAugLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSAugLYRow in oDSFilteredData.SalesTrend)
                {
                    AugLY = Convert.ToDouble(oDSAugLYRow.SalesValue);
                }
                #endregion
                #region Sep
                //Sep CY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRSepCY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Sep' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRSepCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSSepCYRow in oDSFilteredData.SalesTrend)
                {
                    SepCY = Convert.ToDouble(oDSSepCYRow.SalesValue);
                }
                //Sep LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRSepLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Sep' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRSepLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSSepLYRow in oDSFilteredData.SalesTrend)
                {
                    SepLY = Convert.ToDouble(oDSSepLYRow.SalesValue);
                }
                #endregion
                #region Oct
                //Oct CY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDROctCY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Oct' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDROctCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSOctCYRow in oDSFilteredData.SalesTrend)
                {
                    OctCY = Convert.ToDouble(oDSOctCYRow.SalesValue);
                }
                //Oct LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDROctLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Oct' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDROctLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSOctLYRow in oDSFilteredData.SalesTrend)
                {
                    OctLY = Convert.ToDouble(oDSOctLYRow.SalesValue);
                }
               #endregion
                #region Nov
                //Nov CY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRNovCY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Nov' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRNovCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSNovCYRow in oDSFilteredData.SalesTrend)
                {
                    NovCY = Convert.ToDouble(oDSNovCYRow.SalesValue);
                }
                //Nov LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRNovLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Nov' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRNovLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSNovLYRow in oDSFilteredData.SalesTrend)
                {
                    NovLY = Convert.ToDouble(oDSNovLYRow.SalesValue);
                }
                #endregion
                #region Dec
                //Dec CY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRDecCY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Dec' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRDecCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSDecCYRow in oDSFilteredData.SalesTrend)
                {
                    DecCY = Convert.ToDouble(oDSDecCYRow.SalesValue);
                }
                //Dec LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRDecLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Dec' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRDecLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSDecLYRow in oDSFilteredData.SalesTrend)
                {
                    DecLY = Convert.ToDouble(oDSDecLYRow.SalesValue);
                }
                #endregion
            }
        }

        public void GetLYSaleYTD(string sCompany, string sDB, string sValue, string sValueType, string sCustGroupID, string sReqType)
        {
            int nYear = DateTime.Today.Year;

            DateTime _Date = DateTime.Today;
            _Date = _Date.AddDays(1);

            int nLastYear = nYear - 1;
            DateTime _TodayLastYear = _Date.AddYears(-1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sReqType == "OutletSale")
            {
                sSQL = " select Sum(NetSale) as NetSale   " +
                "from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDB + ".dbo.t_Showroom b , DWDB.dbo.t_CustomerDetails c  " +
                "where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' " +
                "and a.WarehouseID=b.WarehouseID  and c.CustomerID=a.CustomerID  " +
                "and InvoiceDate between '01-Jan - " + nLastYear + "' and '" + _TodayLastYear + "' and InvoiceDate < '" + _TodayLastYear + "' ";
                if (sValueType != "Total")
                {
                    if (sValueType == "Area")
                    {
                        sSQL = sSQL + "and c.AreaID = '" + sCustGroupID + "' ";
                    }
                    else if (sValueType == "Zone")
                    {
                        sSQL = sSQL + "and c.TerritoryID = '" + sCustGroupID + "' ";
                    }
                    else
                    {
                        sSQL = sSQL + "and b.ShowroomCode = '" + sValue + "' ";
                    }
                }
            }
            else if (sReqType == "AllSale")
            {
                if (sValue == "Total")
                {
                    sSQL = " select Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails c  " +
                    "where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'  " +
                    "and c.CustomerID=a.CustomerID  " +
                    "and InvoiceDate between '01-Jan- " + nLastYear + "' and '"+ _TodayLastYear + "' and InvoiceDate < '" + _TodayLastYear + "' ";
                }
                else if (sValue == "TD")
                {
                    sSQL = " select Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b, " +
                           " " + sDB + ".dbo.t_Showroom c where a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  " +
                           " and b.CustomerID=a.CustomerID and a.WarehouseID=c.WarehouseID  " +
                           " and InvoiceDate between '01-Jan- " + nLastYear + "' and '" + _TodayLastYear + "' and InvoiceDate < '" + _TodayLastYear + "' ";
                }
                else if (sValue == "Retail")
                {
                    sSQL = " select Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b " +
                           " where a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  " +
                           " and b.CustomerID=a.CustomerID  " +
                           " and InvoiceDate between '01-Jan- " + nLastYear + "' and '" + _TodayLastYear + "' and InvoiceDate < '" + _TodayLastYear + "' ";
                    if (sCompany == "TEL")
                    {
                        sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                    }
                    else if (sCompany == "TML")
                    {
                        sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";

                    }
                }
                else if (sValue == "B2B")
                {
                    sSQL = " select Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b " +
                           " where a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  " +
                           " and b.CustomerID=a.CustomerID  " +
                           " and InvoiceDate between '01-Jan- " + nLastYear + "' and '" + _TodayLastYear + "' and InvoiceDate < '" + _TodayLastYear + "' ";
                    if (sCompany == "TEL")
                    {
                        sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                    }
                    else if (sCompany == "TML")
                    {
                        sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";

                    }
                }
                else if (sValue == "Dealer")
                {
                    sSQL = " select Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b " +
                           " where a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  " +
                           " and b.CustomerID=a.CustomerID  " +
                           " and InvoiceDate between '01-Jan- " + nLastYear + "' and '" + _TodayLastYear + "' and InvoiceDate < '" + _TodayLastYear + "' ";
                    if (sCompany == "TEL")
                    {
                        sSQL = sSQL + " and ChannelID IN (3,15) ";
                    }
                    else if (sCompany == "TML")
                    {
                        //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";

                    }
                }
                else if (sValue == "CAC")
                {
                    sSQL = " select Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b " +
                           " where a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  " +
                           " and b.CustomerID=a.CustomerID  " +
                           " and InvoiceDate between '01-Jan- " + nLastYear + "' and '" + _TodayLastYear + "' and InvoiceDate < '" + _TodayLastYear + "' ";
                    if (sCompany == "TEL")
                    {
                        sSQL = sSQL + " and ChannelID IN (5) ";
                    }
                    else if (sCompany == "TML")
                    {
                        //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";

                    }
                }
            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    AsOfTodayLY = Convert.ToDouble(reader["NetSale"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                AsOfTodayLY = 0;
            }
            

            
        }
        public void GetCYSaleYTD(string sCompany, string sDB, string sValue, string sValueType, string sCustGroupID, string sReqType)
        {
            int nYear = DateTime.Today.Year;

            DateTime _Date = DateTime.Today;
            _Date = _Date.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sReqType == "OutletSale")
            {
                sSQL = " select Sum(NetSale) as NetSale   " +
                "from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDB + ".dbo.t_Showroom b , DWDB.dbo.t_CustomerDetails c  " +
                "where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' " +
                "and a.WarehouseID=b.WarehouseID  and c.CustomerID=a.CustomerID  " +
                "and InvoiceDate between '01-Jan - " + nYear + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "' ";
                if (sValueType != "Total")
                {
                    if (sValueType == "Area")
                    {
                        sSQL = sSQL + "and c.AreaID = '" + sCustGroupID + "' ";
                    }
                    else if (sValueType == "Zone")
                    {
                        sSQL = sSQL + "and c.TerritoryID = '" + sCustGroupID + "' ";
                    }
                    else
                    {
                        sSQL = sSQL + "and b.ShowroomCode = '" + sValue + "' ";
                    }
                }
            }
            else if (sReqType == "AllSale")
            {
                if (sValue == "Total")
                {
                    sSQL = " select Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails c  " +
                    "where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'  " +
                    "and c.CustomerID=a.CustomerID  " +
                    "and InvoiceDate between '01-Jan- " + nYear + "' and ' " + _Date + "' and InvoiceDate < '" + _Date + "' ";
                }
                else if (sValue == "TD")
                {
                    sSQL = " select Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b, " +
                           " " + sDB + ".dbo.t_Showroom c where a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  " +
                           " and b.CustomerID=a.CustomerID and a.WarehouseID=c.WarehouseID  " +
                           " and InvoiceDate between '01-Jan- " + nYear + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "' ";
                }
                else if (sValue == "Retail")
                {
                    sSQL = " select Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b " +
                           " where a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  " +
                           " and b.CustomerID=a.CustomerID " +
                           " and InvoiceDate between '01-Jan- " + nYear + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "' ";

                    if (sCompany == "TEL")
                    {
                        sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                    }
                    else if (sCompany == "TML")
                    {
                        sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";

                    }
                }
                else if (sValue == "B2B")
                {
                    sSQL = " select Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b " +
                           " where a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  " +
                           " and b.CustomerID=a.CustomerID " +
                           " and InvoiceDate between '01-Jan- " + nYear + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "' ";

                    if (sCompany == "TEL")
                    {
                        sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                    }
                    else if (sCompany == "TML")
                    {
                        sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";

                    }
                }
                else if (sValue == "Dealer")
                {
                    sSQL = " select Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b " +
                           " where a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  " +
                           " and b.CustomerID=a.CustomerID " +
                           " and InvoiceDate between '01-Jan- " + nYear + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "' ";

                    if (sCompany == "TEL")
                    {
                        sSQL = sSQL + " and ChannelID IN (3,15) ";
                    }
                    else if (sCompany == "TML")
                    {
                        //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";

                    }
                }
                else if (sValue == "CAC")
                {
                    sSQL = " select Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b " +
                           " where a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  " +
                           " and b.CustomerID=a.CustomerID " +
                           " and InvoiceDate between '01-Jan- " + nYear + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "' ";

                    if (sCompany == "TEL")
                    {
                        sSQL = sSQL + " and ChannelID IN (5) ";
                    }
                    else if (sCompany == "TML")
                    {
                        //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";

                    }
                }
            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    AsOfTodayCY = Convert.ToDouble(reader["NetSale"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                AsOfTodayCY = 0;
            }
        }
        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10009";
            string sReportName = "Sales Trend Report";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
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
    private DSSalesTrend GetDataSet(string sCompany, string sDB, string sValue, string sValueType, string sCustGroupID, string sReqType)
    {
        int nYear = DateTime.Today.Year;
        int nLastYear = nYear - 1;
        int nNextYear = nYear + 1;

        DSSalesTrend oDSSalesTrend = new DSSalesTrend();
        
        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSQL = "";
        if (sReqType == "OutletSale")
        {
            sSQL = " select 'Total' as Outlet, Year(InvoiceDate) as Year, Month(InvoiceDate) as Month, " +
            "CONVERT(CHAR(3), InvoiceDate, 109) AS MonthName,  " +
            "Sum(NetSale) as NetSale   " +
            "from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDB + ".dbo.t_Showroom b , DWDB.dbo.t_CustomerDetails c " +
            "where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' " +
            "and a.WarehouseID=b.WarehouseID  and c.CustomerID=a.CustomerID " +
            "and InvoiceDate between '01-Jan- " + nLastYear + "' and '01-Jan- " + nNextYear + "' and InvoiceDate < '01-Jan- " + nNextYear + "' ";
            if (sValueType != "Total")
            {
                if (sValueType == "Area")
                {
                    sSQL = sSQL + "and c.AreaID = '" + sCustGroupID + "' ";
                }
                else if (sValueType == "Zone")
                {
                    sSQL = sSQL + "and c.TerritoryID = '" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "and b.ShowroomCode = '" + sValue + "' ";
                }
            }
            sSQL = sSQL + " Group by  Year(InvoiceDate), Month(InvoiceDate), CONVERT(CHAR(3), InvoiceDate, 109)  " +
            " Order by Year(InvoiceDate), Month(InvoiceDate)";
        }
        else if (sReqType == "AllSale")
        {
            if (sValue == "Total")
            { 
            sSQL = "select 'Total' as Outlet, Year(InvoiceDate) as Year, Month(InvoiceDate) as Month, "+
                   " CONVERT(CHAR(3), InvoiceDate, 109) AS MonthName,   "+
                   " Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails c  "+
                   " where a.CompanyName='" + sCompany + " ' and c.CompanyName='" + sCompany + " '  " +
                   " and c.CustomerID=a.CustomerID  "+
                   " and InvoiceDate between '01-Jan- " + nLastYear + "' and '01-Jan- " + nNextYear + "'  " +
                   " and InvoiceDate < '01-Jan- " + nNextYear + "'  " +
                   " Group by  Year(InvoiceDate), Month(InvoiceDate), CONVERT(CHAR(3), InvoiceDate, 109)   "+
                   " Order by Year(InvoiceDate), Month(InvoiceDate)";
            }
            else if (sValue == "TD")
            {
                sSQL = " select 'Total' as Outlet, Year(InvoiceDate) as Year, Month(InvoiceDate) as Month, " +
                       "  CONVERT(CHAR(3), InvoiceDate, 109) AS MonthName,   " +
                       "  Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b, " + sDB + ".dbo.t_Showroom c    " +
                       "  where a.CompanyName='" + sCompany + " ' and b.CompanyName='" + sCompany + " '   " +
                       "  and b.CustomerID=a.CustomerID  and a.WarehouseID=c.WarehouseID  " +
                       "  and InvoiceDate between '01-Jan- " + nLastYear + "' and '01-Jan- " + nNextYear + "'   " +
                       "  and InvoiceDate < '01-Jan- " + nNextYear + "'   " +
                       "  Group by  Year(InvoiceDate), Month(InvoiceDate), CONVERT(CHAR(3), InvoiceDate, 109)    " +
                       "  Order by Year(InvoiceDate), Month(InvoiceDate)";
            }
            else if (sValue == "Retail")
            {
                sSQL = " select 'Total' as Outlet, Year(InvoiceDate) as Year, Month(InvoiceDate) as Month, " +
                       "  CONVERT(CHAR(3), InvoiceDate, 109) AS MonthName,   " +
                       "  Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b   " +
                       "  where a.CompanyName='" + sCompany + " ' and b.CompanyName='" + sCompany + " '   " +
                       "  and b.CustomerID=a.CustomerID  " +
                       "  and InvoiceDate between '01-Jan- " + nLastYear + "' and '01-Jan- " + nNextYear + "'   " +
                       "  and InvoiceDate < '01-Jan- " + nNextYear + "'   ";
                if(sCompany=="TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                
                }
                sSQL = sSQL + "  Group by  Year(InvoiceDate), Month(InvoiceDate), CONVERT(CHAR(3), InvoiceDate, 109)    " +
                       "  Order by Year(InvoiceDate), Month(InvoiceDate)";
            }
            else if (sValue == "B2B")
            {
                sSQL = " select 'Total' as Outlet, Year(InvoiceDate) as Year, Month(InvoiceDate) as Month, " +
                       "  CONVERT(CHAR(3), InvoiceDate, 109) AS MonthName,   " +
                       "  Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b   " +
                       "  where a.CompanyName='" + sCompany + " ' and b.CompanyName='" + sCompany + " '   " +
                       "  and b.CustomerID=a.CustomerID  " +
                       "  and InvoiceDate between '01-Jan- " + nLastYear + "' and '01-Jan- " + nNextYear + "'   " +
                       "  and InvoiceDate < '01-Jan- " + nNextYear + "'   ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";

                }
                sSQL = sSQL + "  Group by  Year(InvoiceDate), Month(InvoiceDate), CONVERT(CHAR(3), InvoiceDate, 109)    " +
                       "  Order by Year(InvoiceDate), Month(InvoiceDate)";
            }
            else if (sValue == "Dealer")
            {
                sSQL = " select 'Total' as Outlet, Year(InvoiceDate) as Year, Month(InvoiceDate) as Month, " +
                       "  CONVERT(CHAR(3), InvoiceDate, 109) AS MonthName,   " +
                       "  Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b   " +
                       "  where a.CompanyName='" + sCompany + " ' and b.CompanyName='" + sCompany + " '   " +
                       "  and b.CustomerID=a.CustomerID  " +
                       "  and InvoiceDate between '01-Jan- " + nLastYear + "' and '01-Jan- " + nNextYear + "'   " +
                       "  and InvoiceDate < '01-Jan- " + nNextYear + "'   ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";

                }
                sSQL = sSQL + "  Group by  Year(InvoiceDate), Month(InvoiceDate), CONVERT(CHAR(3), InvoiceDate, 109)    " +
                       "  Order by Year(InvoiceDate), Month(InvoiceDate)";
            }
            else if (sValue == "CAC")
            {
                sSQL = " select 'Total' as Outlet, Year(InvoiceDate) as Year, Month(InvoiceDate) as Month, " +
                       "  CONVERT(CHAR(3), InvoiceDate, 109) AS MonthName,   " +
                       "  Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_CustomerDetails b   " +
                       "  where a.CompanyName='" + sCompany + " ' and b.CompanyName='" + sCompany + " '   " +
                       "  and b.CustomerID=a.CustomerID  " +
                       "  and InvoiceDate between '01-Jan- " + nLastYear + "' and '01-Jan- " + nNextYear + "'   " +
                       "  and InvoiceDate < '01-Jan- " + nNextYear + "'   ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";

                }
                sSQL = sSQL + "  Group by  Year(InvoiceDate), Month(InvoiceDate), CONVERT(CHAR(3), InvoiceDate, 109)    " +
                       "  Order by Year(InvoiceDate), Month(InvoiceDate)";
            }
        }
        
        cmd.CommandText = sSQL;
        cmd.CommandType = CommandType.Text;
        IDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            DSSalesTrend.SalesTrendRow oSalesTrendRow = oDSSalesTrend.SalesTrend.NewSalesTrendRow();

            oSalesTrendRow.Outlet = reader["Outlet"].ToString();
            oSalesTrendRow.Year = Convert.ToInt32(reader["Year"]);
            oSalesTrendRow.MonthName = reader["MonthName"].ToString();
            oSalesTrendRow.Month = Convert.ToInt32(reader["Month"]);
            oSalesTrendRow.SalesValue = Convert.ToDouble(reader["NetSale"]);

            oDSSalesTrend.SalesTrend.AddSalesTrendRow(oSalesTrendRow);
        }

        oDSSalesTrend.AcceptChanges();
        
        return oDSSalesTrend;
    }
}

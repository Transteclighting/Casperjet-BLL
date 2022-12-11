
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


public partial class jBLLSalesTrendReport : System.Web.UI.Page
{
    ReportDocument rptFile;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sDataID = Request.QueryString.Get("DataID");  
            string sDataType = Request.QueryString.Get("DataType");
            string sReportType = Request.QueryString.Get("ReportType");
            string sRouteTypeID = Request.QueryString.Get("RouteTypeID");
            string sDate = Request.QueryString.Get("Date");
            string sUser = Request.QueryString.Get("UserName");
            string sFilteredValue = Request.QueryString.Get("FilteredValue");
            string sAdditionalValue = Request.QueryString.Get("AdditionalValue");
            string sDSRID = Request.QueryString.Get("DSRID");
            string sAndroidAppID = Request.QueryString.Get("AndroidAppID");

            //string sDataID = "140";
            //string sDataType = "National";
            //string sReportType = "Value";
            //string sRouteTypeID = "1";
            //string sDate = "29-Feb-2016";
            //string sUser = "Hakim";
            //string sFilteredValue = "CFL";
            //string sAdditionalValue = "";
            //string sDSRID = "59";
            //string sAndroidAppID = "3";

            DateTime dDate;
            try
            {
                dDate = Convert.ToDateTime(sDate);
            }
            catch
            {
                dDate = DateTime.Now.Date;
            }
            if (sAndroidAppID == null)
            {
                sAndroidAppID = Convert.ToString((int)Dictionary.AndroidAppID.CJ_Apps);
            }

            string sCompanyFullName = "Bangladesh Lamps Limited";

            try
            {
                rptFile = new ReportDocument();
                if (sReportType == "Value")
                {
                    rptFile.Load(Server.MapPath("Report/rptSalesTrendOutlet.rpt"));
                }
                else if (sReportType == "Qty")
                {
                    rptFile.Load(Server.MapPath("Report/rptBLLSalesTrendQty.rpt"));
                }
                
                Data oData = new Data();
                DBController.Instance.OpenNewConnection();
                DSSalesTrend oDSSalesTrend = GetDataSet(sDataID, sDataType, sRouteTypeID, dDate, sReportType, sFilteredValue, sDSRID, sAndroidAppID, sUser);
                DSSalesTrend oDSSalesTrendTarget = GetDataSetTarget(sDataID, sDataType, sRouteTypeID, dDate, sReportType, sFilteredValue, sDSRID, sAndroidAppID, sUser);

                DSSalesTrend oDSTarVsAch = oData.FillTarVsActu(oDSSalesTrend, oDSSalesTrendTarget, dDate);

                oData.GetLYSaleYTD(sDataID, sDataType, sRouteTypeID, dDate, sReportType, sFilteredValue, sDSRID, sAndroidAppID, sUser);
                oData.GetCYSaleYTD(sDataID, sDataType, sRouteTypeID, dDate, sReportType, sFilteredValue, sDSRID, sAndroidAppID, sUser);
                oData.GetLYSaleMTD(sDataID, sDataType, sRouteTypeID, dDate, sReportType, sFilteredValue, sDSRID, sAndroidAppID, sUser);
                oData.GetCYSaleMTD(sDataID, sDataType, sRouteTypeID, dDate, sReportType, sFilteredValue, sDSRID, sAndroidAppID, sUser);
                oData.GetCYTargetYTD(sDataID, sDataType, sRouteTypeID, dDate, sReportType, sFilteredValue, sDSRID, sAndroidAppID, sUser);
                oData.GetCYTargetMTD(sDataID, sDataType, sRouteTypeID, dDate, sReportType, sFilteredValue, sDSRID, sAndroidAppID, sUser);
                
                DBController.Instance.CloseConnection();

                oData.FillData(oDSSalesTrend, dDate);
                oData.FillDataTarget(oDSSalesTrendTarget, dDate);
                oData.InsertReportLog(sUser, sReportType);

                oDSSalesTrend.Parameter.AddParameterRow(sCompanyFullName, sFilteredValue, oData.JanCY, oData.JanLY, oData.FebCY, oData.FebLY, oData.MarCY, oData.MarLY, oData.AprCY, oData.AprLY, oData.MayCY, oData.MayLY, oData.JunCY, oData.JunLY, oData.JulCY, oData.JulLY, oData.AugCY, oData.AugLY, oData.SepCY, oData.SepLY, oData.OctCY, oData.OctLY, oData.NovCY, oData.NovLY, oData.DecCY, oData.DecLY, oData.AsOfTodayCY, oData.AsOfTodayLY, oData.CY, oData.LY, oData.JanTCY, oData.FebTCY, oData.MarTCY, oData.AprTCY, oData.MayTCY, oData.JunTCY, oData.JulTCY, oData.AugTCY, oData.SepTCY, oData.OctTCY, oData.NovTCY, oData.DecTCY, oData.MTDCY, oData.MTDLY, oData.MTDTarCY, oData.AsOfTodayTCY, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", sAdditionalValue);
                oDSSalesTrend.Merge(oDSTarVsAch);
                oDSSalesTrend.AcceptChanges();

                rptFile.SetDataSource(oDSSalesTrend);
                CRViewer.ReportSource = rptFile;
                
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
            }
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

        public double FebCY;
        public double FebLY;
        public double FebTCY;

        public double MarCY;
        public double MarLY;
        public double MarTCY;

        public double AprCY;
        public double AprLY;
        public double AprTCY;

        public double MayCY;
        public double MayLY;
        public double MayTCY;

        public double JunCY;
        public double JunLY;
        public double JunTCY;

        public double JulCY;
        public double JulLY;
        public double JulTCY;

        public double AugCY;
        public double AugLY;
        public double AugTCY;

        public double SepCY;
        public double SepLY;
        public double SepTCY;

        public double OctCY;
        public double OctLY;
        public double OctTCY;

        public double NovCY;
        public double NovLY;
        public double NovTCY;

        public double DecCY;
        public double DecLY;
        public double DecTCY;

        public double AsOfTodayCY;
        public double AsOfTodayLY;
        public double AsOfTodayTCY;

        public double MTDCY;
        public double MTDLY;
        public double MTDTarCY;

        public string Value;

        public DSSalesTrend FillTarVsActu(DSSalesTrend oDSActual, DSSalesTrend oDSTarget, DateTime dDate)
        {
            DSSalesTrend oDSTarVsAch = new DSSalesTrend();
            foreach (DSSalesTrend.SalesTrendRow oTargetRow in oDSTarget.SalesTrend)
            {
                DSSalesTrend.TarVsAchRow oDSTargetRow = oDSTarVsAch.TarVsAch.NewTarVsAchRow();

                oDSTargetRow.Type = oTargetRow.Type;
                oDSTargetRow.Month = oTargetRow.Month;
                oDSTargetRow.Value = oTargetRow.TargetValue;

                oDSTarVsAch.TarVsAch.AddTarVsAchRow(oDSTargetRow);
            }
            int nYear = dDate.Year;
            foreach (DSSalesTrend.SalesTrendRow oActualRow in oDSActual.SalesTrend)
            {
                if (oActualRow.Year == nYear)
                {
                    DSSalesTrend.TarVsAchRow oDSActualRow = oDSTarVsAch.TarVsAch.NewTarVsAchRow();

                    oDSActualRow.Type = oActualRow.Type;
                    oDSActualRow.Month = oActualRow.Month;
                    oDSActualRow.Value = oActualRow.SalesValue;

                    oDSTarVsAch.TarVsAch.AddTarVsAchRow(oDSActualRow);
                }
            }

            oDSTarVsAch.AcceptChanges();

            return oDSTarVsAch;
        }
        public void FillData(DSSalesTrend oDSSalesTrend, DateTime dDate)
        {
            DSSalesTrend oDSFilteredData = new DSSalesTrend();
            int nYear = dDate.Year;
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
        public void FillDataTarget(DSSalesTrend oDSSalesTrendTarget, DateTime dDate)
        {
            DSSalesTrend oDSFilteredData = new DSSalesTrend();
            int nYear = dDate.Year;
            foreach (DSSalesTrend.SalesTrendRow oSalesTrendRow in oDSSalesTrendTarget.SalesTrend)
            {
                #region Jan
                //Jan TCY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRJanCY = oDSSalesTrendTarget.SalesTrend.Select(" MonthName= 'Jan' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRJanCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSJanCYRow in oDSFilteredData.SalesTrend)
                {
                    JanTCY = Convert.ToDouble(oDSJanCYRow.TargetValue);
                }
                #endregion
                #region Feb
                //Feb TCY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRFebCY = oDSSalesTrendTarget.SalesTrend.Select(" MonthName= 'Feb' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRFebCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSFebCYRow in oDSFilteredData.SalesTrend)
                {
                    FebTCY = Convert.ToDouble(oDSFebCYRow.TargetValue);
                }
                #endregion
                #region Mar
                //Mar TCY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRMarCY = oDSSalesTrendTarget.SalesTrend.Select(" MonthName= 'Mar' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRMarCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSMarCYRow in oDSFilteredData.SalesTrend)
                {
                    MarTCY = Convert.ToDouble(oDSMarCYRow.TargetValue);
                }
                #endregion
                #region Apr
                //Apr TCY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRAprCY = oDSSalesTrendTarget.SalesTrend.Select(" MonthName= 'Apr' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRAprCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSAprCYRow in oDSFilteredData.SalesTrend)
                {
                    AprTCY = Convert.ToDouble(oDSAprCYRow.TargetValue);
                }
                #endregion
                #region May
                //May TCY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRMayCY = oDSSalesTrendTarget.SalesTrend.Select(" MonthName= 'May' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRMayCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSMayCYRow in oDSFilteredData.SalesTrend)
                {
                    MayTCY = Convert.ToDouble(oDSMayCYRow.TargetValue);
                }
                #endregion
                #region Jun
                //Jun TCY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRJunCY = oDSSalesTrendTarget.SalesTrend.Select(" MonthName= 'Jun' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRJunCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSJunCYRow in oDSFilteredData.SalesTrend)
                {
                    JunTCY = Convert.ToDouble(oDSJunCYRow.TargetValue);
                }
                #endregion
                #region Jul
                //Jul TCY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRJulCY = oDSSalesTrendTarget.SalesTrend.Select(" MonthName= 'Jul' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRJulCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSJulCYRow in oDSFilteredData.SalesTrend)
                {
                    JulTCY = Convert.ToDouble(oDSJulCYRow.TargetValue);
                }
                #endregion
                #region Aug
                //Aug TCY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRAugCY = oDSSalesTrendTarget.SalesTrend.Select(" MonthName= 'Aug' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRAugCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSAugCYRow in oDSFilteredData.SalesTrend)
                {
                    AugTCY = Convert.ToDouble(oDSAugCYRow.TargetValue);
                }
                #endregion
                #region Sep
                //Sep TCY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRSepCY = oDSSalesTrendTarget.SalesTrend.Select(" MonthName= 'Sep' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRSepCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSSepCYRow in oDSFilteredData.SalesTrend)
                {
                    SepTCY = Convert.ToDouble(oDSSepCYRow.TargetValue);
                }
                #endregion
                #region Oct
                //Oct TCY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDROctCY = oDSSalesTrendTarget.SalesTrend.Select(" MonthName= 'Oct' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDROctCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSOctCYRow in oDSFilteredData.SalesTrend)
                {
                    OctTCY = Convert.ToDouble(oDSOctCYRow.TargetValue);
                }
                #endregion
                #region Nov
                //Nov TCY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRNovCY = oDSSalesTrendTarget.SalesTrend.Select(" MonthName= 'Nov' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRNovCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSNovCYRow in oDSFilteredData.SalesTrend)
                {
                    NovTCY = Convert.ToDouble(oDSNovCYRow.TargetValue);
                }
                #endregion
                #region Dec
                //Dec TCY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRDecCY = oDSSalesTrendTarget.SalesTrend.Select(" MonthName= 'Dec' and Year= " + nYear + "");
                oDSFilteredData.Merge(oDRDecCY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSDecCYRow in oDSFilteredData.SalesTrend)
                {
                    DecTCY = Convert.ToDouble(oDSDecCYRow.TargetValue);
                }
                #endregion
            }
        }

        public void GetLYSaleYTD(string sDataID, string sDataType, string sRouteTypeID, DateTime dDate, string sReportType, string sFilteredValue, string sDSRID, string sAndroidAppID, string sUserName)
        {
            int nYear = dDate.Year;

            DateTime _Date = dDate;
            _Date = _Date.AddDays(1);

            int nLastYear = nYear - 1;
            DateTime _TodayLastYear = _Date.AddYears(-1);
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sReportType == "Value")
            {
                sSQL = "Select Sum(Value) as Value from " +
                   " ( " +
                   " Select RouteID, Year, Month, MonthName, Sum(Value) as Value From  " +
                   " (  " +
                   " Select b.RouteID as RouteID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName, " +
                   " Sum(NetAmount) as Value from BLLSysDB.dbo.t_DMSProductTran a,   " +
                   " BLLSysDB.dbo.t_DMSOutlet b, BLLSysDB.dbo.t_DMSUser c   " +
                   " where a.OutletID=b.OutletID and a.DistributorID=c.DistributorID and Trandate >=ActivatedDate  " +
                   " and TranTypeID=2 and Trandate between '01-Jan-" + nLastYear + "' and '" + _TodayLastYear + "' and Trandate < '" + _TodayLastYear + "'  " +
                   " Group by b.RouteID , Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                   " UNION ALL  " +
                   " SElect b.RouteID, Year, Month, MonthName, Value from  " +
                   " (  " +
                   " Select CustomerID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName, " +
                   " Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales a, BLLSysDB.dbo.t_DMSUser b Where   " +
                   " Trandate between '01-Jan-" + nLastYear + "' and '" + _TodayLastYear + "' and Trandate < '" + _TodayLastYear + "'  " +
                   " and ActivatedDate > Trandate and a.CustomerID=b.DistributorID  " +
                   " Group by CustomerID, Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                   " UNION ALL  " +
                   " Select CustomerID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName,  " +
                   " Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales Where   " +
                   " Trandate between '01-Jan-" + nLastYear + "' and '" + _TodayLastYear + "' and Trandate < '" + _TodayLastYear + "'  " +
                   " and CustomerID Not IN (Select DistributorID From BLLSysDB.dbo.t_DMSUser Where IsActive=1)   " +
                   " Group by CustomerID,Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                   " ) a,  " +
                   " (Select RouteID, DistributorID from BLLSysDB.dbo.t_DMSRoute Where RouteName='SMS Route')b  " +
                   " Where a.CustomerID=b.DistributorID  " +
                   " )x Group by RouteID, Year, Month, MonthName " +
                   " )a, (select RouteID, DistributorID, RouteTypeID, DSRID from BLLSysDB.dbo.t_DMSRoute)b,  " +
                   " (Select CustomerID,AreaID, TerritoryID from DWDB.dbo.t_CustomerDetails where CompanyName='BLL')c " +
                   " Where a.RouteID=b.RouteID and b.DistributorID=c.CustomerID ";
                if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                {
                    sSQL = sSQL + " and c.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
                }
                if (sDataType != "National")
                {
                    if (sDataType == "Area")
                    {
                        sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Territory")
                    {
                        sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Customer")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Route")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                    }
                    else
                    {
                        sSQL = sSQL + "and b.RouteID = '" + sDataID + "' ";
                    }
                }
            }
            else if (sReportType == "Qty")
            {
                sSQL = " Select Sum(Qty)as Value from " +
                       " (  " +
                       " select DistributorID,RouteID,RouteTypeID, DSRID, Year, Month, MonthName, Qty   " +
                       " from  " +
                       " (  " +
                       " select a.DistributorID, d.RouteID,RouteTypeID, DSRID, Year(TranDate) as Year, Month(TranDate) as Month,  " +
                       " CONVERT(CHAR(3), TranDate, 109) AS MonthName, Qty   " +
                       " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, DWDB.dbo.t_ProductDetails c,  " +
                       " BLLSysDB.dbo.t_DMSOutlet d, BLLSysDB.dbo.t_DMSRoute e   " +
                       " where TranTypeID in (2) and a.TranID=b.TranID and Trandate  " +
                       " between '01-Jan- " + nLastYear + "'  and '" + _TodayLastYear + "' and Trandate < '" + _TodayLastYear + "'    " +
                       " and b.ProductID=c.ProductID and a.OutletID=d.outletID and d.RouteID=e.RouteID and CompanyName='BLL' and ASGName='" + sFilteredValue + "' " +
                       " UNION ALL " +
                       " select DistributorID,RouteID, RouteTypeID, DSRID, Year(TranDate) as Year, Month(TranDate) as Month,  " +
                       " CONVERT(CHAR(3), TranDate, 109) AS MonthName, Qty   " +
                       " from BLLSysDB.dbo.t_DMSRoute a, DWDB.dbo.t_SMSSecondarySales b, DWDB.dbo.t_SMSSecondarySalesItem c,   " +
                       " (Select Distinct ASGID, ASGName,ASGSort from DWDB.dbo.t_ProductDetails Where companyName='BLL' and ASGName='" + sFilteredValue + "') d  " +
                       " Where RouteName='SMS Route' and a.DistributorID=b.CustomerID and b.TranID=c.TranID  " +
                       " and TranDate between '01-Jan-" + nLastYear + "'  and '" + _TodayLastYear + "' and Trandate < '" + _TodayLastYear + "' and c.ASGID=d.ASGID  " +
                       " )as Total " +
                       " )a, dwdb.dbo.t_CustomerDetails b Where a.DistributorID=b.customerID and companyname='BLL'";
                if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                {
                    sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
                }
                if (sDataType != "National")
                {
                    if (sDataType == "Area")
                    {
                        sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Territory")
                    {
                        sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Customer")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Route")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                    }
                    else
                    {
                        sSQL = sSQL + "and RouteID = '" + sDataID + "' ";
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
                    AsOfTodayLY = Convert.ToDouble(reader["Value"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                AsOfTodayLY = 0;
            }

        }
        public void GetCYSaleYTD(string sDataID, string sDataType, string sRouteTypeID, DateTime dDate, string sReportType, string sFilteredValue, string sDSRID, string sAndroidAppID, string sUserName)
        {
            int nYear = dDate.Year;

            DateTime _Date = dDate;
            _Date = _Date.AddDays(1);
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sReportType == "Value")
            {
                sSQL = "Select Sum(Value) as Value from " +
                  " ( " +
                  " Select RouteID, Year, Month, MonthName, Sum(Value) as Value From  " +
                  " (  " +
                  " Select b.RouteID as RouteID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName, " +
                  " Sum(NetAmount) as Value from BLLSysDB.dbo.t_DMSProductTran a,   " +
                  " BLLSysDB.dbo.t_DMSOutlet b, BLLSysDB.dbo.t_DMSUser c   " +
                  " where a.OutletID=b.OutletID and a.DistributorID=c.DistributorID and Trandate >=ActivatedDate  " +
                  " and TranTypeID=2 and Trandate between '01-Jan-" + nYear + "' and '" + _Date + "' and Trandate < '" + _Date + "'  " +
                  " Group by b.RouteID , Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                  " UNION ALL  " +
                  " SElect b.RouteID, Year, Month, MonthName, Value from  " +
                  " (  " +
                  " Select CustomerID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName, " +
                  " Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales a, BLLSysDB.dbo.t_DMSUser b Where   " +
                  " Trandate between '01-Jan-" + nYear + "' and '" + _Date + "' and Trandate < '" + _Date + "'  " +
                  " and ActivatedDate > Trandate and a.CustomerID=b.DistributorID  " +
                  " Group by CustomerID, Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                  " UNION ALL  " +
                  " Select CustomerID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName,  " +
                  " Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales Where   " +
                  " Trandate between '01-Jan-" + nYear + "' and '" + _Date + "' and Trandate < '" + _Date + "'  " +
                  " and CustomerID Not IN (Select DistributorID From BLLSysDB.dbo.t_DMSUser Where IsActive=1)   " +
                  " Group by CustomerID,Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                  " ) a,  " +
                  " (Select RouteID, DistributorID from BLLSysDB.dbo.t_DMSRoute Where RouteName='SMS Route')b  " +
                  " Where a.CustomerID=b.DistributorID  " +
                  " )x Group by RouteID, Year, Month, MonthName " +
                  " )a, (select RouteID, DistributorID, RouteTypeID, DSRID from BLLSysDB.dbo.t_DMSRoute)b,  " +
                  " (Select CustomerID,AreaID, TerritoryID from DWDB.dbo.t_CustomerDetails where CompanyName='BLL')c " +
                  " Where a.RouteID=b.RouteID and b.DistributorID=c.CustomerID ";
                if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                {
                    sSQL = sSQL + " and c.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
                }
                if (sDataType != "National")
                {
                    if (sDataType == "Area")
                    {
                        sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Territory")
                    {
                        sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Customer")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Route")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                    }
                    else
                    {
                        sSQL = sSQL + "and b.RouteID = '" + sDataID + "' ";
                    }
                }
            }
            else if (sReportType == "Qty")
            {
                sSQL = " Select Sum(Qty)as Value from " +
                       " (  " +
                       " select DistributorID,RouteID,RouteTypeID, DSRID, Year, Month, MonthName, Qty   " +
                       " from  " +
                       " (  " +
                       " select a.DistributorID, d.RouteID,RouteTypeID,DSRID, Year(TranDate) as Year, Month(TranDate) as Month,  " +
                       " CONVERT(CHAR(3), TranDate, 109) AS MonthName, Qty   " +
                       " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, DWDB.dbo.t_ProductDetails c,  " +
                       " BLLSysDB.dbo.t_DMSOutlet d, BLLSysDB.dbo.t_DMSRoute e   " +
                       " where TranTypeID in (2) and a.TranID=b.TranID and Trandate  " +
                       " between '01-Jan- " + nYear + "'  and '" + _Date + "' and Trandate < '" + _Date + "'    " +
                       " and b.ProductID=c.ProductID and a.OutletID=d.outletID and d.RouteID=e.RouteID and CompanyName='BLL' and ASGName='" + sFilteredValue + "' " +
                       " UNION ALL " +
                       " select DistributorID,RouteID, RouteTypeID, DSRID, Year(TranDate) as Year, Month(TranDate) as Month,  " +
                       " CONVERT(CHAR(3), TranDate, 109) AS MonthName, Qty   " +
                       " from BLLSysDB.dbo.t_DMSRoute a, DWDB.dbo.t_SMSSecondarySales b, DWDB.dbo.t_SMSSecondarySalesItem c,   " +
                       " (Select Distinct ASGID, ASGName,ASGSort from DWDB.dbo.t_ProductDetails Where companyName='BLL' and ASGName='" + sFilteredValue + "') d  " +
                       " Where RouteName='SMS Route' and a.DistributorID=b.CustomerID and b.TranID=c.TranID  " +
                       " and TranDate between '01-Jan-" + nYear + "'  and '" + _Date + "' and Trandate < '" + _Date + "' and c.ASGID=d.ASGID  " +
                       " )as Total " +
                       " )a, dwdb.dbo.t_CustomerDetails b Where a.DistributorID=b.customerID and companyname='BLL' ";
                if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                {
                    sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
                }
                if (sDataType != "National")
                {
                    if (sDataType == "Area")
                    {
                        sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Territory")
                    {
                        sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Customer")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Route")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                    }
                    else
                    {
                        sSQL = sSQL + "and RouteID = '" + sDataID + "' ";
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
                    AsOfTodayCY = Convert.ToDouble(reader["Value"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                AsOfTodayCY = 0;
            }
        }
        public void GetLYSaleMTD(string sDataID, string sDataType, string sRouteTypeID, DateTime dDate, string sReportType, string sFilteredValue, string sDSRID, string sAndroidAppID, string sUserName)
        {
            _oTELLib = new TELLib();

            DateTime _Date = dDate;
            _Date = _Date.AddYears(-1);
            DateTime _dFirstDate = _oTELLib.FirstDayofMonth(_Date);
            _Date = _Date.AddDays(1);
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sReportType == "Value")
            {
                sSQL = "Select Sum(Value) as Value from " +
                 " ( " +
                 " Select RouteID, Year, Month, MonthName, Sum(Value) as Value From  " +
                 " (  " +
                 " Select b.RouteID as RouteID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName, " +
                 " Sum(NetAmount) as Value from BLLSysDB.dbo.t_DMSProductTran a,   " +
                 " BLLSysDB.dbo.t_DMSOutlet b, BLLSysDB.dbo.t_DMSUser c   " +
                 " where a.OutletID=b.OutletID and a.DistributorID=c.DistributorID and Trandate >= ActivatedDate  " +
                 " and TranTypeID=2 and Trandate between '" + _dFirstDate + "' and '" + _Date + "' and Trandate < '" + _Date + "'  " +
                 " Group by b.RouteID , Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                 " UNION ALL  " +
                 " SElect b.RouteID, Year, Month, MonthName, Value from  " +
                 " (  " +
                 " Select CustomerID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName, " +
                 " Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales a, BLLSysDB.dbo.t_DMSUser b Where   " +
                 " Trandate between '" + _dFirstDate + "' and '" + _Date + "' and Trandate < '" + _Date + "'  " +
                 " and ActivatedDate > Trandate and a.CustomerID=b.DistributorID  " +
                 " Group by CustomerID, Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                 " UNION ALL  " +
                 " Select CustomerID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName,  " +
                 " Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales Where   " +
                 " Trandate between '" + _dFirstDate + "' and '" + _Date + "' and Trandate < '" + _Date + "'  " +
                 " and CustomerID Not IN (Select DistributorID From BLLSysDB.dbo.t_DMSUser Where IsActive=1)   " +
                 " Group by CustomerID,Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                 " ) a,  " +
                 " (Select RouteID, DistributorID from BLLSysDB.dbo.t_DMSRoute Where RouteName='SMS Route')b  " +
                 " Where a.CustomerID=b.DistributorID  " +
                 " )x Group by RouteID, Year, Month, MonthName " +
                 " )a, (select RouteID, DistributorID, RouteTypeID, DSRID from BLLSysDB.dbo.t_DMSRoute)b,  " +
                 " (Select CustomerID,AreaID, TerritoryID from DWDB.dbo.t_CustomerDetails where CompanyName='BLL')c " +
                 " Where a.RouteID=b.RouteID and b.DistributorID=c.CustomerID ";
                if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                {
                    sSQL = sSQL + " and c.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
                }
                if (sDataType != "National")
                {
                    if (sDataType == "Area")
                    {
                        sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Territory")
                    {
                        sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Customer")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Route")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                    }
                    else
                    {
                        sSQL = sSQL + "and b.RouteID = '" + sDataID + "' ";
                    }
                }
            }
            else if (sReportType == "Qty")
            {
                sSQL = " Select Sum(Qty)as Value from " +
                       " (  " +
                       " select DistributorID,RouteID,RouteTypeID, DSRID, Year, Month, MonthName, Qty   " +
                       " from  " +
                       " (  " +
                       " select a.DistributorID, d.RouteID,RouteTypeID,DSRID, Year(TranDate) as Year, Month(TranDate) as Month,  " +
                       " CONVERT(CHAR(3), TranDate, 109) AS MonthName, Qty   " +
                       " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, DWDB.dbo.t_ProductDetails c,  " +
                       " BLLSysDB.dbo.t_DMSOutlet d, BLLSysDB.dbo.t_DMSRoute e   " +
                       " where TranTypeID in (2) and a.TranID=b.TranID and Trandate  " +
                       " between '" + _dFirstDate + "'  and '" + _Date + "' and Trandate < '" + _Date + "'    " +
                       " and b.ProductID=c.ProductID and a.OutletID=d.outletID and d.RouteID=e.RouteID and CompanyName='BLL' and ASGName='" + sFilteredValue + "' " +
                       " UNION ALL " +
                       " select DistributorID,RouteID, RouteTypeID, DSRID, Year(TranDate) as Year, Month(TranDate) as Month,  " +
                       " CONVERT(CHAR(3), TranDate, 109) AS MonthName, Qty   " +
                       " from BLLSysDB.dbo.t_DMSRoute a, DWDB.dbo.t_SMSSecondarySales b, DWDB.dbo.t_SMSSecondarySalesItem c,   " +
                       " (Select Distinct ASGID, ASGName,ASGSort from DWDB.dbo.t_ProductDetails Where companyName='BLL' and ASGName='" + sFilteredValue + "') d  " +
                       " Where RouteName='SMS Route' and a.DistributorID=b.CustomerID and b.TranID=c.TranID  " +
                       " and TranDate between '" + _dFirstDate + "'  and '" + _Date + "' and Trandate < '" + _Date + "' and c.ASGID=d.ASGID  " +
                       " )as Total " +
                       " )a, dwdb.dbo.t_CustomerDetails b Where a.DistributorID=b.customerID and companyname='BLL' ";
                if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                {
                    sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
                }
                if (sDataType != "National")
                {
                    if (sDataType == "Area")
                    {
                        sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Territory")
                    {
                        sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Customer")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Route")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                    }
                    else
                    {
                        sSQL = sSQL + "and RouteID = '" + sDataID + "' ";
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
                    MTDLY = Convert.ToDouble(reader["Value"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MTDLY = 0;
            }
        }
        public void GetCYSaleMTD(string sDataID, string sDataType, string sRouteTypeID, DateTime dDate, string sReportType, string sFilteredValue, string sDSRID, string sAndroidAppID, string sUserName)
        {
            _oTELLib = new TELLib();

            DateTime _Date = dDate;
            DateTime _dFirstDate = _oTELLib.FirstDayofMonth(_Date);
            _Date = _Date.AddDays(1);
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sReportType == "Value")
            {
                sSQL = "Select Sum(Value) as Value from " +
                 " ( " +
                 " Select RouteID, Year, Month, MonthName, Sum(Value) as Value From  " +
                 " (  " +
                 " Select b.RouteID as RouteID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName, " +
                 " Sum(NetAmount) as Value from BLLSysDB.dbo.t_DMSProductTran a,   " +
                 " BLLSysDB.dbo.t_DMSOutlet b, BLLSysDB.dbo.t_DMSUser c   " +
                 " where a.OutletID=b.OutletID and a.DistributorID=c.DistributorID and Trandate >=ActivatedDate  " +
                 " and TranTypeID=2 and Trandate between '" + _dFirstDate + "' and '" + _Date + "' and Trandate < '" + _Date + "'  " +
                 " Group by b.RouteID , Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                 " UNION ALL  " +
                 " SElect b.RouteID, Year, Month, MonthName, Value from  " +
                 " (  " +
                 " Select CustomerID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName, " +
                 " Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales a, BLLSysDB.dbo.t_DMSUser b Where   " +
                 " Trandate between '" + _dFirstDate + "' and '" + _Date + "' and Trandate < '" + _Date + "'  " +
                 " and ActivatedDate > Trandate and a.CustomerID=b.DistributorID  " +
                 " Group by CustomerID, Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                 " UNION ALL  " +
                 " Select CustomerID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName,  " +
                 " Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales Where   " +
                 " Trandate between '" + _dFirstDate + "' and '" + _Date + "' and Trandate < '" + _Date + "'  " +
                 " and CustomerID Not IN (Select DistributorID From BLLSysDB.dbo.t_DMSUser Where IsActive=1)   " +
                 " Group by CustomerID,Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                 " ) a,  " +
                 " (Select RouteID, DistributorID from BLLSysDB.dbo.t_DMSRoute Where RouteName='SMS Route')b  " +
                 " Where a.CustomerID=b.DistributorID  " +
                 " )x Group by RouteID, Year, Month, MonthName " +
                 " )a, (select RouteID, DistributorID, RouteTypeID, DSRID from BLLSysDB.dbo.t_DMSRoute)b,  " +
                 " (Select CustomerID,AreaID, TerritoryID from DWDB.dbo.t_CustomerDetails where CompanyName='BLL')c " +
                 " Where a.RouteID=b.RouteID and b.DistributorID=c.CustomerID ";
                if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                {
                    sSQL = sSQL + " and c.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
                }
                if (sDataType != "National")
                {
                    if (sDataType == "Area")
                    {
                        sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Territory")
                    {
                        sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Customer")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Route")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                    }
                    else
                    {
                        sSQL = sSQL + "and b.RouteID = '" + sDataID + "' ";
                    }
                }
            }
            else if (sReportType == "Qty")
            {
                sSQL = " Select Sum(Qty)as Value from " +
                       " (  " +
                       " select DistributorID,RouteID,RouteTypeID, DSRID, Year, Month, MonthName, Qty   " +
                       " from  " +
                       " (  " +
                       " select a.DistributorID, d.RouteID,RouteTypeID,DSRID, Year(TranDate) as Year, Month(TranDate) as Month,  " +
                       " CONVERT(CHAR(3), TranDate, 109) AS MonthName, Qty   " +
                       " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, DWDB.dbo.t_ProductDetails c,  " +
                       " BLLSysDB.dbo.t_DMSOutlet d, BLLSysDB.dbo.t_DMSRoute e   " +
                       " where TranTypeID in (2) and a.TranID=b.TranID and Trandate  " +
                       " between '" + _dFirstDate + "'  and '" + _Date + "' and Trandate < '" + _Date + "'    " +
                       " and b.ProductID=c.ProductID and a.OutletID=d.outletID and d.RouteID=e.RouteID and CompanyName='BLL' and ASGName='" + sFilteredValue + "' " +
                       " UNION ALL " +
                       " select DistributorID,RouteID, RouteTypeID, DSRID, Year(TranDate) as Year, Month(TranDate) as Month,  " +
                       " CONVERT(CHAR(3), TranDate, 109) AS MonthName, Qty   " +
                       " from BLLSysDB.dbo.t_DMSRoute a, DWDB.dbo.t_SMSSecondarySales b, DWDB.dbo.t_SMSSecondarySalesItem c,   " +
                       " (Select Distinct ASGID, ASGName,ASGSort from DWDB.dbo.t_ProductDetails Where companyName='BLL' and ASGName='" + sFilteredValue + "') d  " +
                       " Where RouteName='SMS Route' and a.DistributorID=b.CustomerID and b.TranID=c.TranID  " +
                       " and TranDate between '" + _dFirstDate + "'  and '" + _Date + "' and Trandate < '" + _Date + "' and c.ASGID=d.ASGID  " +
                       " )as Total " +
                       " )a, dwdb.dbo.t_CustomerDetails b Where a.DistributorID=b.customerID and companyname='BLL' ";
                if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                {
                    sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
                }
                if (sDataType != "National")
                {
                    if (sDataType == "Area")
                    {
                        sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Territory")
                    {
                        sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Customer")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Route")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                    }
                    else
                    {
                        sSQL = sSQL + "and RouteID = '" + sDataID + "' ";
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
                    MTDCY = Convert.ToDouble(reader["Value"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MTDCY = 0;
            }
        }
        public void GetCYTargetYTD(string sDataID, string sDataType, string sRouteTypeID, DateTime dDate, string sReportType, string sFilteredValue, string sDSRID, string sAndroidAppID, string sUserName)
        {
            _oTELLib = new TELLib();
            int nYear = dDate.Year;
            int nMonth = dDate.Month;
            int nDay = dDate.Day;

            DateTime _Date = dDate;
            _Date = _oTELLib.LastDayofMonth(_Date);
            int nLastDay = _Date.Day;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            string sSQL = "";
            if (sReportType == "Value")
            {
                sSQL = " Select  Sum(Value) as Value from  " +
                "(  " +
                "select RouteID, SUM(TSMTGTTO) as Value  " +
                "from BLLSysDB.dbo.t_DMSTargetTO Where Year(TGTDate)=" + nYear + "  and Month(TGTDate) < " + nMonth + " Group by RouteID  " +
                "UNION ALL " +
                "select RouteID, round(Sum(TSMTGTTO)/" + nLastDay + "*" + nDay + ",0) as Value  " +
                "from BLLSysDB.dbo.t_DMSTargetTO Where Year(TGTDate)=" + nYear + "  and Month(TGTDate) = " + nMonth + " Group by RouteID  " +
                ") a,  " +
                "(select RouteID, DistributorID, RouteTypeID, DSRID from BLLSysDB.dbo.t_DMSRoute)b,    " +
                "(Select CustomerID,AreaID, TerritoryID from DWDB.dbo.t_CustomerDetails where CompanyName='BLL')c   " +
                "Where a.RouteID=b.RouteID and b.DistributorID=c.CustomerID ";
                if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                {
                    sSQL = sSQL + " and c.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
                }
                if (sDataType != "National")
                {
                    if (sDataType == "Area")
                    {
                        sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Territory")
                    {
                        sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Customer")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Route")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                    }
                    else
                    {
                        sSQL = sSQL + "and b.RouteID = '" + sDataID + "' ";
                    }
                }
            }
            else if (sReportType == "Qty")
            {
                sSQL = " select  Sum(TSMTGTQty) as Value " +
                       " from  " +
                       " ( " +
                       " select RouteID, ASGID, DistributorID, TSMTGTQty from BLLSysDB.dbo.t_DMSASGTarget Where Year(TargetDate)=" + nYear + " and Month(TargetDate) < " + nMonth + " " +
                       " UNION ALL " +
                       " select RouteID, ASGID, DistributorID, round(TSMTGTQty/" + nLastDay + "*" + nDay + ",0) as TSMTGTQty from BLLSysDB.dbo.t_DMSASGTarget Where Year(TargetDate)=" + nYear + " and Month(TargetDate) = " + nMonth + " " +
                       " )a, DWDB.dbo.t_CustomerDetails b, " +
                       " BLLSysDB.dbo.t_DMSRoute c, (Select distinct ASGID, ASGName from DWDB.dbo.t_ProductDetails Where CompanyName='BLL' and ASGName='" + sFilteredValue + "') d " +
                       " Where a.DistributorID=b.CustomerID and b.CompanyName='BLL' and a.RouteID=c.RouteID and a.ASGID=d.ASGID ";
                if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                {
                    sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
                }
                if (sDataType != "National")
                {
                    if (sDataType == "Area")
                    {
                        sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Territory")
                    {
                        sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Customer")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Route")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                    }
                    else
                    {
                        sSQL = sSQL + "and RouteID = '" + sDataID + "' ";
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
                    AsOfTodayTCY = Convert.ToDouble(reader["Value"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                AsOfTodayTCY = 0;
            }
        }
        public void GetCYTargetMTD(string sDataID, string sDataType, string sRouteTypeID, DateTime dDate, string sReportType, string sFilteredValue, string sDSRID, string sAndroidAppID, string sUserName)
        {
            _oTELLib = new TELLib();
            int nYear = dDate.Year;
            int nMonth = dDate.Month;
            int nDay = dDate.Day;
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            DateTime _Date = dDate;
            _Date = _oTELLib.LastDayofMonth(_Date);
            int nLastDay = _Date.Day;

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sReportType == "Value")
            {
                sSQL = " Select  Sum(Value) as Value from  " +
                "(  " +
                "select RouteID, round(Sum(TSMTGTTO)/" + nLastDay + "*" + nDay + ",0) as Value  " +
                "from BLLSysDB.dbo.t_DMSTargetTO Where Year(TGTDate)=" + nYear + "  and Month(TGTDate) = " + nMonth + " Group by RouteID  " +
                ") a,  " +
                "(select RouteID, DistributorID, RouteTypeID, DSRID from BLLSysDB.dbo.t_DMSRoute)b,    " +
                "(Select CustomerID,AreaID, TerritoryID from DWDB.dbo.t_CustomerDetails where CompanyName='BLL')c   " +
                "Where a.RouteID=b.RouteID and b.DistributorID=c.CustomerID ";
                if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                {
                    sSQL = sSQL + " and c.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
                }
                if (sDataType != "National")
                {
                    if (sDataType == "Area")
                    {
                        sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Territory")
                    {
                        sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Customer")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Route")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                    }
                    else
                    {
                        sSQL = sSQL + "and b.RouteID = '" + sDataID + "' ";
                    }
                }
            }
            else if (sReportType == "Qty")
            {
                sSQL = " select  Sum(TSMTGTQty) as Value " +
                       " from  " +
                       " ( " +
                       " select RouteID, ASGID, DistributorID, round(TSMTGTQty/" + nLastDay + "*" + nDay + ",0) as TSMTGTQty from BLLSysDB.dbo.t_DMSASGTarget Where Year(TargetDate)=" + nYear + " and Month(TargetDate) = " + nMonth + " " +
                       " )a, DWDB.dbo.t_CustomerDetails b, " +
                       " BLLSysDB.dbo.t_DMSRoute c, (Select distinct ASGID, ASGName from DWDB.dbo.t_ProductDetails Where CompanyName='BLL' and ASGName='" + sFilteredValue + "') d " +
                       " Where a.DistributorID=b.CustomerID and b.CompanyName='BLL' and a.RouteID=c.RouteID and a.ASGID=d.ASGID ";
                if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
                {
                    sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
                }
                if (sDataType != "National")
                {
                    if (sDataType == "Area")
                    {
                        sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Territory")
                    {
                        sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Customer")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                    }
                    else if (sDataType == "Route")
                    {
                        sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                    }
                    else
                    {
                        sSQL = sSQL + "and RouteID = '" + sDataID + "' ";
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
                    MTDTarCY = Convert.ToDouble(reader["Value"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MTDTarCY = 0;
            }
        }
        public void InsertReportLog(string sUser, string sReportType)
        {
            ReportLog oReportLog;
            if (sReportType == "Value")
            {
                oReportLog = new ReportLog();
                string sReportCode = "A10037";
                string sReportName = "BLL-Secondary Sales Trend (Value)";
                string connStr;
                connStr = ConfigurationManager.AppSettings["jConnectionString"];
                oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
            }
            else if (sReportType == "Qty")
            {
                oReportLog = new ReportLog();
                string sReportCode = "A10038";
                string sReportName = "BLL-Secondary Sales Trend (Qty)";
                string connStr;
                connStr = ConfigurationManager.AppSettings["jConnectionString"];
                oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
            }
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
    private DSSalesTrend GetDataSet(string sDataID, string sDataType, string sRouteTypeID, DateTime dDate, string sReportType, string sFilteredValue, string sDSRID, string sAndroidAppID, string sUserName)
    {
        int nYear = dDate.Year;
        int nLastYear = nYear - 1;
        int nNextYear = nYear + 1;
        DateTime dToDate = dDate.AddDays(1);
        DSSalesTrend oDSSalesTrend = new DSSalesTrend();
        int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSQL = "";
        if (sReportType == "Value")
        {
            sSQL = "Select 'Total' as Outlet, Year, Month, MonthName, Sum(Value) as Value from " +
                   " ( " +
                   " Select RouteID, Year, Month, MonthName, Sum(Value) as Value From  " +
                   " (  " +
                   " Select b.RouteID as RouteID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName, " +
                   " Sum(NetAmount) as Value from BLLSysDB.dbo.t_DMSProductTran a,   " +
                   " BLLSysDB.dbo.t_DMSOutlet b, BLLSysDB.dbo.t_DMSUser c   " +
                   " where a.OutletID=b.OutletID and a.DistributorID=c.DistributorID and Trandate >=ActivatedDate  " +
                   " and TranTypeID=2 and Trandate between '01-Jan-" + nLastYear + "' and '01-Jan-" + nNextYear + "' and Trandate < '01-Jan-" + nNextYear + "' and TranDate < '" + dToDate + "' " +
                   " Group by b.RouteID , Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                   " UNION ALL  " +
                   " SElect b.RouteID, Year, Month, MonthName, Value from  " +
                   " (  " +
                   " Select CustomerID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName, " +
                   " Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales a, BLLSysDB.dbo.t_DMSUser b Where   " +
                   " Trandate between '01-Jan-" + nLastYear + "' and '01-Jan-" + nNextYear + "' and Trandate < '01-Jan-" + nNextYear + "' and TranDate < '" + dToDate + "' " +
                   " and ActivatedDate > Trandate and a.CustomerID=b.DistributorID  " +
                   " Group by CustomerID, Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                   " UNION ALL  " +
                   " Select CustomerID, Year(TranDate) as Year, Month(TranDate) as Month, CONVERT(CHAR(3), TranDate, 109) AS MonthName,  " +
                   " Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales Where   " +
                   " Trandate between '01-Jan-" + nLastYear + "' and '01-Jan-" + nNextYear + "' and Trandate < '01-Jan-" + nNextYear + "' and TranDate < '" + dToDate + "' " +
                   " and CustomerID Not IN (Select DistributorID From BLLSysDB.dbo.t_DMSUser Where IsActive=1)   " +
                   " Group by CustomerID,Year(TranDate), Month(TranDate), CONVERT(CHAR(3), TranDate, 109)  " +
                   " ) a,  " +
                   " (Select RouteID, DistributorID from BLLSysDB.dbo.t_DMSRoute Where RouteName='SMS Route')b  " +
                   " Where a.CustomerID=b.DistributorID  " +
                   " )x Group by RouteID, Year, Month, MonthName " +
                   " )a, (select RouteID, DistributorID, RouteTypeID, DSRID from BLLSysDB.dbo.t_DMSRoute)b,  " +
                   " (Select CustomerID,AreaID, TerritoryID from DWDB.dbo.t_CustomerDetails where CompanyName='BLL')c " +
                   " Where a.RouteID=b.RouteID and b.DistributorID=c.CustomerID ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and c.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            if (sDataType != "National")
            {
                if (sDataType == "Area")
                {
                    sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                }
                else if (sDataType == "Territory")
                {
                    sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                }
                else if (sDataType == "Customer")
                {
                    sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                }
                else if (sDataType == "Route")
                {
                    sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                }
                else
                {
                    sSQL = sSQL + "and b.RouteID = '" + sDataID + "' ";
                }
            }
            sSQL = sSQL + " Group by Year, Month, MonthName ";
        }
        else if (sReportType == "Qty")
        {
            sSQL = " Select 'Total' as Outlet, Year, Month, MonthName, Sum(Qty)as Value from " +
                   " (  " +
                   " select DistributorID,RouteID,RouteTypeID, DSRID, Year, Month, MonthName, Qty   " +
                   " from  " +
                   " (  " +
                   " select a.DistributorID, d.RouteID,RouteTypeID,DSRID, Year(TranDate) as Year, Month(TranDate) as Month,  " +
                   " CONVERT(CHAR(3), TranDate, 109) AS MonthName, Qty   " +
                   " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, DWDB.dbo.t_ProductDetails c,  " +
                   " BLLSysDB.dbo.t_DMSOutlet d, BLLSysDB.dbo.t_DMSRoute e   " +
                   " where TranTypeID in (2) and a.TranID=b.TranID and Trandate  " +
                   " between '01-Jan- " + nLastYear + "'  and '01-Jan-" + nNextYear + "'   and Trandate < '01-Jan-" + nNextYear + "'    " +
                   " and b.ProductID=c.ProductID and a.OutletID=d.outletID and d.RouteID=e.RouteID and CompanyName='BLL' and ASGName='" + sFilteredValue + "' " +
                   " UNION ALL " +
                   " select DistributorID,RouteID, RouteTypeID, DSRID, Year(TranDate) as Year, Month(TranDate) as Month,  " +
                   " CONVERT(CHAR(3), TranDate, 109) AS MonthName, Qty   " +
                   " from BLLSysDB.dbo.t_DMSRoute a, DWDB.dbo.t_SMSSecondarySales b, DWDB.dbo.t_SMSSecondarySalesItem c,   " +
                   " (Select Distinct ASGID, ASGName,ASGSort from DWDB.dbo.t_ProductDetails Where companyName='BLL' and ASGName='" + sFilteredValue + "') d  " +
                   " Where RouteName='SMS Route' and a.DistributorID=b.CustomerID and b.TranID=c.TranID  " +
                   " and TranDate between '01-Jan-" + nLastYear + "'  and '01-Jan-" + nNextYear + "'   and Trandate < '01-Jan-" + nNextYear + "' and c.ASGID=d.ASGID  " +
                   " )as Total " +
                   " )a, dwdb.dbo.t_CustomerDetails b Where a.DistributorID=b.customerID and companyname='BLL'";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            if (sDataType != "National")
            {
                if (sDataType == "Area")
                {
                    sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                }
                else if (sDataType == "Territory")
                {
                    sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                }
                else if (sDataType == "Customer")
                {
                    sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                }
                else if (sDataType == "Route")
                {
                    sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID =" + sDSRID + " ";
                }
                else
                {
                    sSQL = sSQL + "and RouteID = '" + sDataID + "' ";
                }
            }
            sSQL = sSQL + " Group by Year, Month, MonthName ";
        }
        cmd.CommandText = sSQL;
        cmd.CommandType = CommandType.Text;
        IDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            DSSalesTrend.SalesTrendRow oSalesTrendRow = oDSSalesTrend.SalesTrend.NewSalesTrendRow();

            oSalesTrendRow.Outlet = reader["Outlet"].ToString();
            oSalesTrendRow.Year = Convert.ToInt32(reader["Year"]);
            oSalesTrendRow.sYear = reader["Year"].ToString();
            oSalesTrendRow.MonthName = reader["MonthName"].ToString();
            oSalesTrendRow.Month = Convert.ToInt32(reader["Month"]);
            oSalesTrendRow.SalesValue = Convert.ToDouble(reader["Value"]);
            oSalesTrendRow.Type = "Actual";
            oDSSalesTrend.SalesTrend.AddSalesTrendRow(oSalesTrendRow);
        }

        oDSSalesTrend.AcceptChanges();

        return oDSSalesTrend;
    }
    private DSSalesTrend GetDataSetTarget(string sDataID, string sDataType, string sRouteTypeID, DateTime dDate, string sReportType, string sFilteredValue, string sDSRID, string sAndroidAppID, string sUserName)
    {
        TELLib _oTELLib = new TELLib();
        int nYear = dDate.Year;
        DateTime LastDayOfMonth = _oTELLib.LastDayofMonth(dDate);
        DateTime dToDate = LastDayOfMonth.AddDays(1);
        DSSalesTrend oDSSalesTrend = new DSSalesTrend();
        int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSQL = "";
        if (sReportType == "Value")
        {
            sSQL = " Select  'Total' as Outlet, Year, Month, MonthName, Sum(Value) as Value from " +
                   " ( " +
                   " select RouteID, Year(TGTDate) as Year, Month(TGTDate) as Month, CASE When Month(TGTDate) = 1 then 'Jan'  " +
                   " When Month(TGTDate) = 2 then 'Feb' When Month(TGTDate) = 3 then 'Mar'  " +
                   " When Month(TGTDate) = 4 then 'Apr' When Month(TGTDate) = 5 then 'May'  " +
                   " When Month(TGTDate) = 6 then 'Jun' When Month(TGTDate) = 7 then 'Jul'  " +
                   " When Month(TGTDate) = 8 then 'Aug' When Month(TGTDate) = 9 then 'Sep'  " +
                   " When Month(TGTDate) = 10 then 'Oct' When Month(TGTDate) = 11 then 'Nov' else 'Dec' end  " +
                   " as MonthName, SUM(TSMTGTTO) as Value from BLLSysDB.dbo.t_DMSTargetTO Where Year(TGTDate)=" + nYear + " and TGTDate < '" + dToDate + "' " +
                   " Group by RouteID, Year(TGTDate),Month(TGTDate) " +
                   " ) a, (select RouteID, DistributorID, RouteTypeID, DSRID from BLLSysDB.dbo.t_DMSRoute)b,  " +
                   " (Select CustomerID,AreaID, TerritoryID from DWDB.dbo.t_CustomerDetails where CompanyName='BLL')c " +
                   " Where a.RouteID=b.RouteID and b.DistributorID=c.CustomerID ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and c.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            if (sDataType != "National")
            {
                if (sDataType == "Area")
                {
                    sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                }
                else if (sDataType == "Territory")
                {
                    sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                }
                else if (sDataType == "Customer")
                {
                    sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                }
                else if (sDataType == "Route")
                {
                    sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                }
                else
                {
                    sSQL = sSQL + "and b.RouteID = '" + sDataID + "' ";
                }
            }
            sSQL = sSQL + " Group by Month, Year, MonthName ";
        }
        else if (sReportType == "Qty")
        {
            sSQL = " select 'Total' as Outlet, Year(TargetDate) as Year, Month(TargetDate) as Month, " +
                   " CONVERT(CHAR(3), TargetDate, 109) AS MonthName, Sum(TSMTGTQty) as Value  " +
                   " from BLLSysDB.dbo.t_DMSASGTarget a, DWDB.dbo.t_CustomerDetails b,  " +
                   " BLLSysDB.dbo.t_DMSRoute c, (Select distinct ASGID, ASGName from DWDB.dbo.t_ProductDetails Where CompanyName='BLL' and ASGName='" + sFilteredValue + "') d  " +
                   " Where a.DistributorID=b.CustomerID and b.CompanyName='BLL' and a.RouteID=c.RouteID and a.ASGID=d.ASGID  " +
                   " and Year(TargetDate)=" + nYear + " and TargetDate < '" + dToDate + "' ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and b.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            if (sDataType != "National")
            {
                if (sDataType == "Area")
                {
                    sSQL = sSQL + "and AreaID = '" + sDataID + "' ";
                }
                else if (sDataType == "Territory")
                {
                    sSQL = sSQL + "and TerritoryID = '" + sDataID + "' ";
                }
                else if (sDataType == "Customer")
                {
                    sSQL = sSQL + "and CustomerID = '" + sDataID + "' ";
                }
                else if (sDataType == "Route")
                {
                    sSQL = sSQL + "and CustomerID = '" + sDataID + "' and DSRID=" + sDSRID + " ";
                }
                else
                {
                    sSQL = sSQL + "and c.RouteID = '" + sDataID + "' ";
                }
            }
            sSQL = sSQL + " Group by Year(TargetDate), Month(TargetDate),CONVERT(CHAR(3), TargetDate, 109) ";
        }
        

        cmd.CommandText = sSQL;
        cmd.CommandType = CommandType.Text;
        IDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            DSSalesTrend.SalesTrendRow oSalesTrendRow = oDSSalesTrend.SalesTrend.NewSalesTrendRow();

            oSalesTrendRow.Outlet = reader["Outlet"].ToString();
            oSalesTrendRow.Year = Convert.ToInt32(reader["Year"]);
            oSalesTrendRow.sYear = reader["Year"].ToString();
            oSalesTrendRow.MonthName = reader["MonthName"].ToString();
            oSalesTrendRow.Month = Convert.ToInt32(reader["Month"]);
            oSalesTrendRow.TargetValue = Convert.ToDouble(reader["Value"]);
            oSalesTrendRow.Type = "Target";

            oDSSalesTrend.SalesTrend.AddSalesTrendRow(oSalesTrendRow);
        }

        oDSSalesTrend.AcceptChanges();

        return oDSSalesTrend;
    }
}


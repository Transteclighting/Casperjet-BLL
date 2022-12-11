
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


public partial class jProductCategorySummary : System.Web.UI.Page
{
    ReportDocument rptFile;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sEmployeeID = Request.QueryString.Get("EmployeeID");
            string sCompany = Request.QueryString.Get("Company");
            string sUser = Request.QueryString.Get("UserName");
            string sCategoryType = Request.QueryString.Get("CategoryType");
            string sEmployeeName = Request.QueryString.Get("EmployeeName");


            //string sEmployeeID = "83449";
            //string sCompany = "TEL";
            //string sUser = "Hakim";
            //string sCategoryType = "MAG";
            //string sEmployeeName = "Saikat";

            string sCompanyFullName = "";
            string sValue = "";
            if (sCategoryType == "Brand")
            {
                sValue = "Month Wise Summary for PM: " + sEmployeeName;
            }
            else
            {
                sValue = "Month Wise Summary for CM: " + sEmployeeName;
            }
            if (sCompany == "TEL")
            {
                //sDatabase = "TELSysDB";
                sCompanyFullName = "Transcom Electronics Limited";
            }
            else if (sCompany == "TML")
            {
                //sDatabase = "TMLSysDB";
                sCompanyFullName = "Transcom Mobiles Limited";
            }
            
            try
            {
                rptFile = new ReportDocument();
                rptFile.Load(Server.MapPath("Report/rptCategorySalesTrendSumm.rpt"));
                Data oData = new Data();
                DBController.Instance.OpenNewConnection();
                DSSalesTrend oDSSalesTrend = GetDataSet(sCompany, sEmployeeID, sCategoryType);
                DSSalesTrend oDSSalesTrendTarget = GetDataSetTarget(sCompany, sEmployeeID, sCategoryType);

                DSSalesTrend oDSTarVsAch = oData.FillTarVsActu(oDSSalesTrend, oDSSalesTrendTarget);

                oData.GetLYSaleYTD(sCompany, sEmployeeID, sCategoryType);
                oData.GetCYSaleYTD(sCompany, sEmployeeID, sCategoryType);
                oData.GetLYSaleMTD(sCompany, sEmployeeID, sCategoryType);
                oData.GetCYSaleMTD(sCompany, sEmployeeID, sCategoryType);
                oData.GetCYTargetYTD(sCompany, sEmployeeID, sCategoryType);
                oData.GetCYTargetMTD(sCompany, sEmployeeID, sCategoryType);
                
                DBController.Instance.CloseConnection();

                oData.FillData(oDSSalesTrend);
                oData.FillDataTarget(oDSSalesTrendTarget);


                oDSSalesTrend.Parameter.AddParameterRow(sCompanyFullName, sValue, oData.JanCY, oData.JanLY, oData.FebCY, oData.FebLY, oData.MarCY, oData.MarLY, oData.AprCY, oData.AprLY, oData.MayCY, oData.MayLY, oData.JunCY, oData.JunLY, oData.JulCY, oData.JulLY, oData.AugCY, oData.AugLY, oData.SepCY, oData.SepLY, oData.OctCY, oData.OctLY, oData.NovCY, oData.NovLY, oData.DecCY, oData.DecLY, oData.AsOfTodayCY, oData.AsOfTodayLY, oData.CY, oData.LY, oData.JanTCY, oData.FebTCY, oData.MarTCY, oData.AprTCY, oData.MayTCY, oData.JunTCY, oData.JulTCY, oData.AugTCY, oData.SepTCY, oData.OctTCY, oData.NovTCY, oData.DecTCY, oData.MTDCY, oData.MTDLY, oData.MTDTarCY, oData.AsOfTodayTCY, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "");
                oDSSalesTrend.Merge(oDSTarVsAch);
                oDSSalesTrend.AcceptChanges();

                rptFile.SetDataSource(oDSSalesTrend);
                CRViewer.ReportSource = rptFile;
                //oData.InsertReportLog(sUser);
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

        public DSSalesTrend FillTarVsActu(DSSalesTrend oDSActual, DSSalesTrend oDSTarget)
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
            int nYear = DateTime.Today.Year;
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
        public void FillDataTarget(DSSalesTrend oDSSalesTrendTarget)
        {
            DSSalesTrend oDSFilteredData = new DSSalesTrend();
            int nYear = DateTime.Today.Year;
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
        public void GetLYSaleYTD(string sCompany, string sEmployeeID, string sCategoryType) 
        {
            int nYear = DateTime.Today.Year;

            DateTime _Date = DateTime.Today;
            _Date = _Date.AddDays(1);

            int nLastYear = nYear - 1;
            DateTime _TodayLastYear = _Date.AddYears(-1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sCategoryType == "Brand")
            {
                sSQL = " select Sum(NetSale) as NetSale " +
                " from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails c   " +
                " where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and c.ProductID=a.ProductID  " +
                " and BrandID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                " Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=1) " +
                " and InvoiceDate between '01-Jan-" + nLastYear + "' and '" + _TodayLastYear + "' and InvoiceDate < '" + _TodayLastYear + "'";
            }
            else if (sCategoryType == "MAG")
            {
                sSQL = " select Sum(NetSale) as NetSale " +
                " from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails c   " +
                " where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and c.ProductID=a.ProductID  " +
                " and MAGID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                " Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=2) " +
                " and InvoiceDate between '01-Jan-" + nLastYear + "' and '" + _TodayLastYear + "' and InvoiceDate < '" + _TodayLastYear + "'";
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
        public void GetCYSaleYTD(string sCompany, string sEmployeeID, string sCategoryType)
        {
            int nYear = DateTime.Today.Year;

            DateTime _Date = DateTime.Today;
            _Date = _Date.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";

            if (sCategoryType == "Brand")
            {
                sSQL = " select Sum(NetSale) as NetSale " +
                " from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails c   " +
                " where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and c.ProductID=a.ProductID  " +
                " and BrandID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                " Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=1) " +
                " and InvoiceDate between '01-Jan-" + nYear + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "'";
            }
            else if (sCategoryType == "MAG")
            {
                sSQL = " select Sum(NetSale) as NetSale " +
                " from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails c   " +
                " where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and c.ProductID=a.ProductID  " +
                " and MAGID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                " Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=2) " +
                " and InvoiceDate between '01-Jan-" + nYear + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "'";
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
        public void GetLYSaleMTD(string sCompany, string sEmployeeID, string sCategoryType)
        {
            _oTELLib = new TELLib();

            DateTime _Date = DateTime.Today;
            _Date = _Date.AddYears(-1);
            DateTime _dFirstDate = _oTELLib.FirstDayofMonth(_Date);
            _Date = _Date.AddDays(1);
            
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sCategoryType == "Brand")
            {
                sSQL = " select Sum(NetSale) as NetSale " +
                " from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails c   " +
                " where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and c.ProductID=a.ProductID  " +
                " and BrandID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                " Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=1) " +
                " and InvoiceDate between '" + _dFirstDate + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "'";
            }
            else if (sCategoryType == "MAG")
            {
                sSQL = " select Sum(NetSale) as NetSale " +
                " from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails c   " +
                " where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and c.ProductID=a.ProductID  " +
                " and MAGID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                " Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=2) " +
                " and InvoiceDate between '" + _dFirstDate + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "'";
            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MTDLY = Convert.ToDouble(reader["NetSale"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MTDLY = 0;
            }
        }
        public void GetCYSaleMTD(string sCompany, string sEmployeeID, string sCategoryType)
        {
            _oTELLib = new TELLib();

            DateTime _Date = DateTime.Today;
            DateTime _dFirstDate = _oTELLib.FirstDayofMonth(_Date);
            _Date = _Date.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sCategoryType == "Brand")
            {
                sSQL = " select Sum(NetSale) as NetSale " +
                " from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails c   " +
                " where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and c.ProductID=a.ProductID  " +
                " and BrandID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                " Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=1) " +
                " and InvoiceDate between '" + _dFirstDate + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "'";
            }
            else if (sCategoryType == "MAG")
            {
                sSQL = " select Sum(NetSale) as NetSale " +
                " from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails c   " +
                " where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and c.ProductID=a.ProductID  " +
                " and MAGID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                " Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=2) " +
                " and InvoiceDate between '" + _dFirstDate + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "'";
            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MTDCY = Convert.ToDouble(reader["NetSale"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MTDCY = 0;
            }
        }
        public void GetCYTargetYTD(string sCompany, string sEmployeeID, string sCategoryType)
        {
            _oTELLib = new TELLib();
            int nYear = DateTime.Today.Year;
            int nMonth = DateTime.Today.Month;
            int nDay = DateTime.Today.Day;
            
            DateTime _Date = DateTime.Today;
            _Date = _oTELLib.LastDayofMonth(_Date);
            int nLastDay = _Date.Day;

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sCategoryType == "Brand")
            {
                sSQL = " Select Sum(TargetValue) as TargetValue from " +
                "( " +
                "select Sum(TargetValue) as TargetValue from TELSysDB.dbo.t_PlanMAGWeekTargetQty  " +
                "Where TYear = " + nYear + " and TMonth < " + nMonth + " and "+
                "BrandID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                "Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=1) ";
                sSQL = sSQL + "UNION ALL " +
                "select round(Sum(TargetValue)/" + nLastDay + "*" + nDay + ",0) as TargetValue from TELSysDB.dbo.t_PlanMAGWeekTargetQty  " +
                "Where TYear = " + nYear + " and TMonth = " + nMonth + " and " +
                "BrandID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                "Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=1) ";
                sSQL = sSQL + ") as Final";
            }
            else if (sCategoryType == "MAG")
            {
                sSQL = " Select Sum(TargetValue) as TargetValue from " +
                "( " +
                "select Sum(TargetValue) as TargetValue from TELSysDB.dbo.t_PlanMAGWeekTargetQty  " +
                "Where TYear = " + nYear + " and TMonth < " + nMonth + " and " +
                "MAGID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                "Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=2) ";
                sSQL = sSQL + "UNION ALL " +
                "select round(Sum(TargetValue)/" + nLastDay + "*" + nDay + ",0) as TargetValue from TELSysDB.dbo.t_PlanMAGWeekTargetQty  " +
                "Where TYear = " + nYear + " and TMonth = " + nMonth + " and " +
                "MAGID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                "Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=2) ";
                sSQL = sSQL + ") as Final";
            }
            
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    AsOfTodayTCY = Convert.ToDouble(reader["TargetValue"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                AsOfTodayTCY = 0;
            }
        }
        public void GetCYTargetMTD(string sCompany, string sEmployeeID, string sCategoryType)
        {
            _oTELLib = new TELLib();
            int nYear = DateTime.Today.Year;
            int nMonth = DateTime.Today.Month;
            int nDay = DateTime.Today.Day;

            DateTime _Date = DateTime.Today;
            _Date = _oTELLib.LastDayofMonth(_Date);
            int nLastDay = _Date.Day;

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            if (sCategoryType == "Brand")
            {
                sSQL = "select round(Sum(TargetValue)/" + nLastDay + "*" + nDay + ",0) as TargetValue from TELSysDB.dbo.t_PlanMAGWeekTargetQty  " +
                "where TYear = " + nYear + " and TMonth = " + nMonth + " and BrandID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                "Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=1)";
            }
            else if (sCategoryType == "MAG")
            {
                sSQL = "select round(Sum(TargetValue)/" + nLastDay + "*" + nDay + ",0) as TargetValue from TELSysDB.dbo.t_PlanMAGWeekTargetQty  " +
                "where TYear = " + nYear + " and TMonth = " + nMonth + " and MAGID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                "Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=2)";
            }
            
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MTDTarCY = Convert.ToDouble(reader["TargetValue"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MTDTarCY = 0;
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
    private DSSalesTrend GetDataSet(string sCompany, string sEmployeeID, string sCategoryType)
    {
        int nYear = DateTime.Today.Year;
        int nLastYear = nYear - 1;
        int nNextYear = nYear + 1;

        DSSalesTrend oDSSalesTrend = new DSSalesTrend();

        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSQL = "";
        if (sCategoryType == "Brand")
        {
            sSQL = " select 'Total' as Outlet, Year(InvoiceDate) as Year, Month(InvoiceDate) as Month, " +
                   " CONVERT(CHAR(3), InvoiceDate, 109) AS MonthName,   " +
                   " Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                   " DWDB.dbo.t_ProductDetails c  " +
                   " where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' " +
                   " and a.ProductID=c.ProductID  " +
                   " and InvoiceDate between '01-Jan-" + nLastYear + "' and '01-Jan-" + nNextYear + "' and InvoiceDate < '01-Jan-" + nNextYear + "'  " +
                   " and BrandID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                   " Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=1) " +
                   " Group by  Year(InvoiceDate), Month(InvoiceDate), CONVERT(CHAR(3), InvoiceDate, 109)  " +
                   " Order by Year(InvoiceDate), Month(InvoiceDate)";
        }
        else if (sCategoryType == "MAG")
        {
            sSQL = " select 'Total' as Outlet, Year(InvoiceDate) as Year, Month(InvoiceDate) as Month, " +
                 " CONVERT(CHAR(3), InvoiceDate, 109) AS MonthName,   " +
                 " Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                 " DWDB.dbo.t_ProductDetails c  " +
                 " where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' " +
                 " and a.ProductID=c.ProductID  " +
                 " and InvoiceDate between '01-Jan-" + nLastYear + "' and '01-Jan-" + nNextYear + "' and InvoiceDate < '01-Jan-" + nNextYear + "'  " +
                 " and MAGID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                 " Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=2) " +
                 " Group by  Year(InvoiceDate), Month(InvoiceDate), CONVERT(CHAR(3), InvoiceDate, 109)  " +
                 " Order by Year(InvoiceDate), Month(InvoiceDate)";
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
            oSalesTrendRow.SalesValue = Convert.ToDouble(reader["NetSale"]);
            oSalesTrendRow.Type = "Actual";
            oDSSalesTrend.SalesTrend.AddSalesTrendRow(oSalesTrendRow);
        }

        oDSSalesTrend.AcceptChanges();

        return oDSSalesTrend;
    }
    private DSSalesTrend GetDataSetTarget(string sCompany, string sEmployeeID, string sCategoryType)
    {
        int nYear = DateTime.Today.Year;
        int nLastYear = nYear - 1;

        DSSalesTrend oDSSalesTrend = new DSSalesTrend();

        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSQL = "";
        if (sCategoryType == "Brand")
        {
            sSQL = " select 'Total' as Outlet, TYear, TMonth, CASE When TMonth = 1 then 'Jan' " +
                   " When TMonth = 2 then 'Feb' When TMonth = 3 then 'Mar'  " +
                   " When TMonth = 4 then 'Apr' When TMonth = 5 then 'May'  " +
                   " When TMonth = 6 then 'Jun' When TMonth = 7 then 'Jul'  " +
                   " When TMonth = 8 then 'Aug' When TMonth = 9 then 'Sep'  " +
                   " When TMonth = 10 then 'Oct' When TMonth = 11 then 'Nov' else 'Dec' end  " +
                   " as MonthName, Sum(TargetValue) as TargetValue from TELSysDB.dbo.t_PlanMAGWeekTargetQty a " +
                   " where BrandID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                   " Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=1) " +
                   " and TYear = " + nYear + " Group by TMonth, TYear ";
        }
        else if (sCategoryType == "MAG")
        {
            sSQL = " select 'Total' as Outlet, TYear, TMonth, CASE When TMonth = 1 then 'Jan' " +
                   " When TMonth = 2 then 'Feb' When TMonth = 3 then 'Mar'  " +
                   " When TMonth = 4 then 'Apr' When TMonth = 5 then 'May'  " +
                   " When TMonth = 6 then 'Jun' When TMonth = 7 then 'Jul'  " +
                   " When TMonth = 8 then 'Aug' When TMonth = 9 then 'Sep'  " +
                   " When TMonth = 10 then 'Oct' When TMonth = 11 then 'Nov' else 'Dec' end  " +
                   " as MonthName, Sum(TargetValue) as TargetValue from TELSysDB.dbo.t_PlanMAGWeekTargetQty a " +
                   " where MAGID IN (select DataID from TELSysDB.dbo.t_MapProductGroupItem a, TELSysDB.dbo.t_MapProductGroup b " +
                   " Where a.ID=b.ID and EmployeeID='" + sEmployeeID + "' and MapGroupType=2) " +
                   " and TYear = " + nYear + " Group by TMonth, TYear ";
        }
      

        cmd.CommandText = sSQL;
        cmd.CommandType = CommandType.Text;
        IDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            DSSalesTrend.SalesTrendRow oSalesTrendRow = oDSSalesTrend.SalesTrend.NewSalesTrendRow();

            oSalesTrendRow.Outlet = reader["Outlet"].ToString();
            oSalesTrendRow.Year = Convert.ToInt32(reader["TYear"]);
            oSalesTrendRow.sYear = reader["TYear"].ToString();
            oSalesTrendRow.MonthName = reader["MonthName"].ToString();
            oSalesTrendRow.Month = Convert.ToInt32(reader["TMonth"]);
            oSalesTrendRow.TargetValue = Convert.ToDouble(reader["TargetValue"]);
            oSalesTrendRow.Type = "Target";

            oDSSalesTrend.SalesTrend.AddSalesTrendRow(oSalesTrendRow);
        }

        oDSSalesTrend.AcceptChanges();

        return oDSSalesTrend;
    }
}



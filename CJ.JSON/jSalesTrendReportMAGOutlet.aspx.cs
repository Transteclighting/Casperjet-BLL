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


public partial class jSalesTrendReportMAGOutlet : System.Web.UI.Page
{
    ReportDocument rptFile;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sValue = Request.QueryString.Get("Value");
            string sCompany = Request.QueryString.Get("Company");
            string sUser = Request.QueryString.Get("UserName");
            string sMAG = Request.QueryString.Get("MAG");

            //string sValue = "DGC";
            //string sCompany = "TEL";
            //string sUser = "Hakim";
            //string sMAG = "HTV";

            string sChannel = "TD";

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
                rptFile.Load(Server.MapPath("Report/rptSalesTrendMAGOutlet.rpt"));
                Data oData = new Data();
                DBController.Instance.OpenNewConnection();
                DSSalesTrend oDSSalesTrend = GetDataSet(sCompany, sDatabase, sValue, sValueType, sCustGroupID, sMAG);
                DSSalesTrend oDSSalesTrendTarget = GetDataSetTarget(sCompany, sDatabase, sValue, sValueType, sCustGroupID, sMAG);

                DSSalesTrend oDSTarVsAch = oData.FillTarVsActu(oDSSalesTrend, oDSSalesTrendTarget);

                oData.GetLYSaleYTD(sCompany, sDatabase, sValue, sValueType, sCustGroupID, sMAG);
                oData.GetCYSaleYTD(sCompany, sDatabase, sValue, sValueType, sCustGroupID, sMAG);
                oData.GetLYSaleMTD(sCompany, sDatabase, sValue, sValueType, sCustGroupID, sMAG);
                oData.GetCYSaleMTD(sCompany, sDatabase, sValue, sValueType, sCustGroupID, sMAG);
                oData.GetCYTargetYTD(sCompany, sDatabase, sValue, sValueType, sCustGroupID, sMAG);
                oData.GetCYTargetMTD(sCompany, sDatabase, sValue, sValueType, sCustGroupID, sMAG);
                
                DBController.Instance.CloseConnection();

                oData.FillData(oDSSalesTrend);
                oData.FillDataTarget(oDSSalesTrendTarget);


                oDSSalesTrend.Parameter.AddParameterRow(sCompanyFullName, sValue, oData.JanCY, oData.JanLY, oData.FebCY, oData.FebLY, oData.MarCY, oData.MarLY, oData.AprCY, oData.AprLY, oData.MayCY, oData.MayLY, oData.JunCY, oData.JunLY, 
                    oData.JulCY, oData.JulLY, oData.AugCY, oData.AugLY, oData.SepCY, oData.SepLY, oData.OctCY, oData.OctLY, oData.NovCY, oData.NovLY, oData.DecCY, oData.DecLY, oData.YTD_CY_Val, oData.YTD_LY_Val, oData.CY, oData.LY, 
                    oData.JanTCY, oData.FebTCY, oData.MarTCY, oData.AprTCY, oData.MayTCY, oData.JunTCY, oData.JulTCY, oData.AugTCY, oData.SepTCY, oData.OctTCY, oData.NovTCY, oData.DecTCY, oData.MTD_CY_Val,
                    oData.MTD_LY_Val, oData.MTD_TCY_Val, oData.YTD_TCY_Val, oData.JanCYQty, oData.JanLYQty, oData.JanTCYQty, oData.FebCYQty, oData.FebLYQty, oData.FebTCYQty, oData.MarCYQty, oData.MarLYQty, 
                    oData.MarTCYQty, oData.AprCYQty, oData.AprLYQty, oData.AprTCYQty, oData.MayCYQty, oData.MayLYQty, oData.MayTCYQty, oData.JunCYQty, oData.JunLYQty, oData.JunTCYQty, oData.JulCYQty, 
                    oData.JulLYQty, oData.JulTCYQty, oData.AugCYQty, oData.AugLYQty, oData.AugTCYQty, oData.SepCYQty, oData.SepLYQty, oData.SepTCYQty, oData.OctCYQty, oData.OctLYQty, oData.OctTCYQty,
                    oData.NovCYQty, oData.NovLYQty, oData.NovTCYQty, oData.DecCYQty, oData.DecLYQty, oData.DecTCYQty, oData.YTD_CY_Qty, oData.YTD_LY_Qty, oData.YTD_TCY_Qty, oData.MTD_CY_Qty, oData.MTD_LY_Qty, oData.MTD_TCY_Qty, sMAG, sValue, sChannel,"");
                oDSSalesTrend.Merge(oDSTarVsAch);
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
        TELLib _oTELLib;

        public int CY;
        public int LY;

        public double JanCY;
        public double JanLY;
        public double JanTCY;
        public int JanCYQty;
        public int JanLYQty;
        public int JanTCYQty;

        public double FebCY;
        public double FebLY;
        public double FebTCY;
        public int FebCYQty;
        public int FebLYQty;
        public int FebTCYQty;

        public double MarCY;
        public double MarLY;
        public double MarTCY;
        public int MarCYQty;
        public int MarLYQty;
        public int MarTCYQty;

        public double AprCY;
        public double AprLY;
        public double AprTCY;
        public int AprCYQty;
        public int AprLYQty;
        public int AprTCYQty;

        public double MayCY;
        public double MayLY;
        public double MayTCY;
        public int MayCYQty;
        public int MayLYQty;
        public int MayTCYQty;

        public double JunCY;
        public double JunLY;
        public double JunTCY;
        public int JunCYQty;
        public int JunLYQty;
        public int JunTCYQty;

        public double JulCY;
        public double JulLY;
        public double JulTCY;
        public int JulCYQty;
        public int JulLYQty;
        public int JulTCYQty;

        public double AugCY;
        public double AugLY;
        public double AugTCY;
        public int AugCYQty;
        public int AugLYQty;
        public int AugTCYQty;

        public double SepCY;
        public double SepLY;
        public double SepTCY;
        public int SepCYQty;
        public int SepLYQty;
        public int SepTCYQty;

        public double OctCY;
        public double OctLY;
        public double OctTCY;
        public int OctCYQty;
        public int OctLYQty;
        public int OctTCYQty;

        public double NovCY;
        public double NovLY;
        public double NovTCY;
        public int NovCYQty;
        public int NovLYQty;
        public int NovTCYQty;

        public double DecCY;
        public double DecLY;
        public double DecTCY;
        public int DecCYQty;
        public int DecLYQty;
        public int DecTCYQty;

        public double YTD_CY_Val;
        public double YTD_LY_Val;
        public double YTD_TCY_Val;
        public int YTD_CY_Qty;
        public int YTD_LY_Qty;
        public int YTD_TCY_Qty;

        public double MTD_CY_Val;
        public double MTD_LY_Val;
        public double MTD_TCY_Val;
        public int MTD_CY_Qty;
        public int MTD_LY_Qty;
        public int MTD_TCY_Qty;

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
                oDSTargetRow.Qty = oTargetRow.TargetQty;

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
                    oDSActualRow.Qty = oActualRow.SalesQty;

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
                    JanCYQty = Convert.ToInt32(oDSJanCYRow.SalesQty);
                }
                //Jan LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRJanLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Jan' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRJanLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSJanLYRow in oDSFilteredData.SalesTrend)
                {
                    JanLY = Convert.ToDouble(oDSJanLYRow.SalesValue);
                    JanLYQty = Convert.ToInt32(oDSJanLYRow.SalesQty);
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
                    FebCYQty = Convert.ToInt32(oDSFebCYRow.SalesQty);
                }
                //Feb LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRFebLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Feb' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRFebLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSFebLYRow in oDSFilteredData.SalesTrend)
                {
                    FebLY = Convert.ToDouble(oDSFebLYRow.SalesValue);
                    FebLYQty = Convert.ToInt32(oDSFebLYRow.SalesQty);
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
                    MarCYQty = Convert.ToInt32(oDSMarCYRow.SalesQty);
                }
                //Mar LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRMarLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Mar' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRMarLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSMarLYRow in oDSFilteredData.SalesTrend)
                {
                    MarLY = Convert.ToDouble(oDSMarLYRow.SalesValue);
                    MarLYQty = Convert.ToInt32(oDSMarLYRow.SalesQty);
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
                    AprCYQty = Convert.ToInt32(oDSAprCYRow.SalesQty);
                }
                //Apr LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRAprLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Apr' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRAprLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSAprLYRow in oDSFilteredData.SalesTrend)
                {
                    AprLY = Convert.ToDouble(oDSAprLYRow.SalesValue);
                    AprLYQty = Convert.ToInt32(oDSAprLYRow.SalesQty);
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
                    MayCYQty = Convert.ToInt32(oDSMayCYRow.SalesQty);
                }
                //May LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRMayLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'May' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRMayLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSMayLYRow in oDSFilteredData.SalesTrend)
                {
                    MayLY = Convert.ToDouble(oDSMayLYRow.SalesValue);
                    MayLYQty = Convert.ToInt32(oDSMayLYRow.SalesQty);
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
                    JunCYQty = Convert.ToInt32(oDSJunCYRow.SalesQty);
                }
                //Jun LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRJunLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Jun' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRJunLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSJunLYRow in oDSFilteredData.SalesTrend)
                {
                    JunLY = Convert.ToDouble(oDSJunLYRow.SalesValue);
                    JunLYQty = Convert.ToInt32(oDSJunLYRow.SalesQty);
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
                    JulCYQty = Convert.ToInt32(oDSJulCYRow.SalesQty);
                }
                //Jul LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRJulLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Jul' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRJulLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSJulLYRow in oDSFilteredData.SalesTrend)
                {
                    JulLY = Convert.ToDouble(oDSJulLYRow.SalesValue);
                    JulLYQty = Convert.ToInt32(oDSJulLYRow.SalesQty);
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
                    AugCYQty = Convert.ToInt32(oDSAugCYRow.SalesQty);
                }
                //Aug LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRAugLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Aug' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRAugLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSAugLYRow in oDSFilteredData.SalesTrend)
                {
                    AugLY = Convert.ToDouble(oDSAugLYRow.SalesValue);
                    AugLYQty = Convert.ToInt32(oDSAugLYRow.SalesQty);
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
                    SepCYQty = Convert.ToInt32(oDSSepCYRow.SalesQty);
                }
                //Sep LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRSepLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Sep' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRSepLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSSepLYRow in oDSFilteredData.SalesTrend)
                {
                    SepLY = Convert.ToDouble(oDSSepLYRow.SalesValue);
                    SepLYQty = Convert.ToInt32(oDSSepLYRow.SalesQty);
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
                    OctCYQty = Convert.ToInt32(oDSOctCYRow.SalesQty);
                }
                //Oct LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDROctLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Oct' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDROctLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSOctLYRow in oDSFilteredData.SalesTrend)
                {
                    OctLY = Convert.ToDouble(oDSOctLYRow.SalesValue);
                    OctLYQty = Convert.ToInt32(oDSOctLYRow.SalesQty);
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
                    NovCYQty = Convert.ToInt32(oDSNovCYRow.SalesQty);
                }
                //Nov LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRNovLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Nov' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRNovLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSNovLYRow in oDSFilteredData.SalesTrend)
                {
                    NovLY = Convert.ToDouble(oDSNovLYRow.SalesValue);
                    NovLYQty = Convert.ToInt32(oDSNovLYRow.SalesQty);
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
                    DecCYQty = Convert.ToInt32(oDSDecCYRow.SalesQty);
                }
                //Dec LY
                oDSFilteredData = new DSSalesTrend();
                DataRow[] oDRDecLY = oDSSalesTrend.SalesTrend.Select(" MonthName= 'Dec' and Year= " + nLastYear + "");
                oDSFilteredData.Merge(oDRDecLY);
                oDSFilteredData.AcceptChanges();

                foreach (DSSalesTrend.SalesTrendRow oDSDecLYRow in oDSFilteredData.SalesTrend)
                {
                    DecLY = Convert.ToDouble(oDSDecLYRow.SalesValue);
                    DecLYQty = Convert.ToInt32(oDSDecLYRow.SalesQty);
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
                    JanTCYQty = Convert.ToInt32(oDSJanCYRow.TargetQty);
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
                    FebTCYQty = Convert.ToInt32(oDSFebCYRow.TargetQty);
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
                    MarTCYQty = Convert.ToInt32(oDSMarCYRow.TargetQty);
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
                    AprTCYQty = Convert.ToInt32(oDSAprCYRow.TargetQty);
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
                    MayTCYQty = Convert.ToInt32(oDSMayCYRow.TargetQty);
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
                    JunTCYQty = Convert.ToInt32(oDSJunCYRow.TargetQty);
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
                    JulTCYQty = Convert.ToInt32(oDSJulCYRow.TargetQty);
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
                    AugTCYQty = Convert.ToInt32(oDSAugCYRow.TargetQty);
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
                    SepTCYQty = Convert.ToInt32(oDSSepCYRow.TargetQty);
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
                    OctTCYQty = Convert.ToInt32(oDSOctCYRow.TargetQty);
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
                    NovTCYQty = Convert.ToInt32(oDSNovCYRow.TargetQty);
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
                    DecTCYQty = Convert.ToInt32(oDSDecCYRow.TargetQty);
                }
                #endregion
            }
        }
        public void GetLYSaleYTD(string sCompany, string sDB, string sValue, string sValueType, string sCustGroupID, string sMAG)
        {
            int nYear = DateTime.Today.Year;

            DateTime _Date = DateTime.Today;
            _Date = _Date.AddDays(1);

            int nLastYear = nYear - 1;
            DateTime _TodayLastYear = _Date.AddYears(-1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            sSQL = " select Sum(NetSale) as NetSale, Sum(SalesQty+FreeQty) as SalesQty   " +
            "from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDB + ".dbo.t_Showroom b , DWDB.dbo.t_CustomerDetails c , DWDB.dbo.t_ProductDetails d  " +
            "where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' " +
            "and a.WarehouseID=b.WarehouseID  and c.CustomerID=b.CustomerID  and a.ProductID = d.ProductID and MAGName='" + sMAG + "' " +
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
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    YTD_LY_Val = Convert.ToDouble(reader["NetSale"]);
                    YTD_LY_Qty = Convert.ToInt32(reader["SalesQty"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                YTD_LY_Val = 0;
                YTD_LY_Qty = 0;
            }
        }
        public void GetCYSaleYTD(string sCompany, string sDB, string sValue, string sValueType, string sCustGroupID, string sMAG)
        {
            int nYear = DateTime.Today.Year;

            DateTime _Date = DateTime.Today;
            _Date = _Date.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";

            sSQL = " select Sum(NetSale) as NetSale, Sum(SalesQty+FreeQty) as SalesQty   " +
            "from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDB + ".dbo.t_Showroom b , DWDB.dbo.t_CustomerDetails c, DWDB.dbo.t_ProductDetails d  " +
            "where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' " +
            "and a.WarehouseID=b.WarehouseID  and c.CustomerID=b.CustomerID and a.ProductID = d.ProductID and MAGName='" + sMAG + "' " +
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
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    YTD_CY_Val = Convert.ToDouble(reader["NetSale"]);
                    YTD_CY_Qty = Convert.ToInt32(reader["SalesQty"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                YTD_CY_Val = 0;
                YTD_CY_Qty = 0;
            }
        }
        public void GetLYSaleMTD(string sCompany, string sDB, string sValue, string sValueType, string sCustGroupID, string sMAG)
        {
            _oTELLib = new TELLib();

            DateTime _Date = DateTime.Today;
            _Date = _Date.AddYears(-1);
            DateTime _dFirstDate = _oTELLib.FirstDayofMonth(_Date);
            _Date = _Date.AddDays(1);
            
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            sSQL = " select Sum(NetSale) as NetSale, Sum(SalesQty+FreeQty) as SalesQty    " +
            "from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDB + ".dbo.t_Showroom b , DWDB.dbo.t_CustomerDetails c, DWDB.dbo.t_ProductDetails d  " +
            "where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' " +
            "and a.WarehouseID=b.WarehouseID  and c.CustomerID=b.CustomerID  and a.ProductID = d.ProductID and MAGName='" + sMAG + "' " +
            "and InvoiceDate between '" + _dFirstDate + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "' ";
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
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MTD_LY_Val = Convert.ToDouble(reader["NetSale"]);
                    MTD_LY_Qty = Convert.ToInt32(reader["SalesQty"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MTD_LY_Val = 0;
                MTD_LY_Qty = 0;
            }
        }
        public void GetCYSaleMTD(string sCompany, string sDB, string sValue, string sValueType, string sCustGroupID, string sMAG)
        {
            _oTELLib = new TELLib();

            DateTime _Date = DateTime.Today;
            DateTime _dFirstDate = _oTELLib.FirstDayofMonth(_Date);
            _Date = _Date.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "";
            sSQL = " select Sum(NetSale) as NetSale, Sum(SalesQty+FreeQty) as SalesQty   " +
            "from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDB + ".dbo.t_Showroom b , DWDB.dbo.t_CustomerDetails c, DWDB.dbo.t_ProductDetails d  " +
            "where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' " +
            "and a.WarehouseID=b.WarehouseID  and c.CustomerID=b.CustomerID  and a.ProductID = d.ProductID and MAGName='" + sMAG + "' " +
            "and InvoiceDate between '" + _dFirstDate + "' and '" + _Date + "' and InvoiceDate < '" + _Date + "' ";
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
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MTD_CY_Val = Convert.ToDouble(reader["NetSale"]);
                    MTD_CY_Qty = Convert.ToInt32(reader["SalesQty"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MTD_CY_Val = 0;
                MTD_CY_Qty = 0;
            }
        }
        public void GetCYTargetYTD(string sCompany, string sDB, string sValue, string sValueType, string sCustGroupID, string sMAG)
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

            sSQL = " Select Sum(TargetValue) as TargetValue, Sum(TargetQty) as TargetQty from " +
            "( " +
            "select Sum(TargetValue) as TargetValue, Sum(TargetQty) as TargetQty from " + sDB + ".dbo.t_PlanMAGWeekTargetQty a,  " +
            "DWDB.dbo.t_CustomerDetails b, " + sDB + ".dbo.t_Showroom c where  a.CustomerID=c.CustomerID and  " +
            "a.CustomerID = b.CustomerID and b.CompanyName='" + sCompany + "'  and a.MAGID = (select distinct MAGID from DWDB.dbo.t_ProductDetails where CompanyName='" + sCompany + "' and MAGName='" + sMAG + "') " +
            "and TYear = " + nYear + " and TMonth < " + nMonth + " ";
            if (sValueType != "Total")
            {
                if (sValueType == "Area")
                {
                    sSQL = sSQL + "and b.AreaID = '" + sCustGroupID + "' ";
                }
                else if (sValueType == "Zone")
                {
                    sSQL = sSQL + "and b.TerritoryID = '" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "and c.ShowroomCode = '" + sValue + "' ";
                }
            }

            sSQL = sSQL + "UNION ALL " +
            "select round(Sum(TargetValue)/" + nLastDay + "*" + nDay + ",0) as TargetValue, round(Sum(TargetQty)/" + nLastDay + "*" + nDay + ",0) as TargetQty from " + sDB + ".dbo.t_PlanMAGWeekTargetQty a,  " +
            "DWDB.dbo.t_CustomerDetails b, " + sDB + ".dbo.t_Showroom c where  a.CustomerID=c.CustomerID and  " +
            "a.CustomerID = b.CustomerID and b.CompanyName='" + sCompany + "'  and a.MAGID = (select distinct MAGID from DWDB.dbo.t_ProductDetails where CompanyName='" + sCompany + "' and MAGName='" + sMAG + "') " +
            "and TYear = " + nYear + " and TMonth = " + nMonth + " ";
            if (sValueType != "Total")
            {
                if (sValueType == "Area")
                {
                    sSQL = sSQL + "and b.AreaID = '" + sCustGroupID + "' ";
                }
                else if (sValueType == "Zone")
                {
                    sSQL = sSQL + "and b.TerritoryID = '" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "and c.ShowroomCode = '" + sValue + "' ";
                }
            }
            sSQL = sSQL + ") as Final";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    YTD_TCY_Val = Convert.ToDouble(reader["TargetValue"]);
                    YTD_TCY_Qty = Convert.ToInt32(reader["TargetQty"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                YTD_TCY_Val = 0;
                YTD_TCY_Qty = 0;
            }
        }
        public void GetCYTargetMTD(string sCompany, string sDB, string sValue, string sValueType, string sCustGroupID, string sMAG)
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

            sSQL = "select round(Sum(TargetValue)/" + nLastDay + "*" + nDay + ",0) as TargetValue, round(Sum(TargetQty)/" + nLastDay + "*" + nDay + ",0) as TargetQty from " + sDB + ".dbo.t_PlanMAGWeekTargetQty a,  " +
            "DWDB.dbo.t_CustomerDetails b, " + sDB + ".dbo.t_Showroom c where  a.CustomerID=c.CustomerID and  " +
            "a.CustomerID = b.CustomerID and b.CompanyName='" + sCompany + "'  and a.MAGID = (select distinct MAGID from DWDB.dbo.t_ProductDetails where CompanyName='" + sCompany + "' and MAGName='" + sMAG + "') " +
            "and TYear = " + nYear + " and TMonth = " + nMonth + " ";
            if (sValueType != "Total")
            {
                if (sValueType == "Area")
                {
                    sSQL = sSQL + "and b.AreaID = '" + sCustGroupID + "' ";
                }
                else if (sValueType == "Zone")
                {
                    sSQL = sSQL + "and b.TerritoryID = '" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "and c.ShowroomCode = '" + sValue + "' ";
                }
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MTD_TCY_Val = Convert.ToDouble(reader["TargetValue"]);
                    MTD_TCY_Qty = Convert.ToInt32(reader["TargetQty"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MTD_TCY_Val = 0;
                MTD_TCY_Qty = 0;
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
    private DSSalesTrend GetDataSet(string sCompany, string sDB, string sValue, string sValueType, string sCustGroupID, string sMAG)
    {
        int nYear = DateTime.Today.Year;
        int nLastYear = nYear - 1;
        int nNextYear = nYear + 1;

        DSSalesTrend oDSSalesTrend = new DSSalesTrend();

        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSQL = "";

        sSQL = " select 'Total' as Outlet, Year(InvoiceDate) as Year, Month(InvoiceDate) as Month, " +
        "CONVERT(CHAR(3), InvoiceDate, 109) AS MonthName,  " +
        "Sum(NetSale) as NetSale, Sum(SalesQty+FreeQty) as SalesQty   " +
        "from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDB + ".dbo.t_Showroom b , DWDB.dbo.t_CustomerDetails c, DWDB.dbo.t_ProductDetails d " +
        "where a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' " +
        "and a.WarehouseID=b.WarehouseID  and c.CustomerID=b.CustomerID and a.ProductID = d.ProductID and MAGName='"+sMAG+"' " +
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
            oSalesTrendRow.SalesQty = Convert.ToInt32(reader["SalesQty"]);
            oSalesTrendRow.SalesValue = Convert.ToDouble(reader["NetSale"]);
            oSalesTrendRow.Type = "Actual";
            oDSSalesTrend.SalesTrend.AddSalesTrendRow(oSalesTrendRow);
        }

        oDSSalesTrend.AcceptChanges();

        return oDSSalesTrend;
    }
    private DSSalesTrend GetDataSetTarget(string sCompany, string sDB, string sValue, string sValueType, string sCustGroupID, string sMAG)
    {
        int nYear = DateTime.Today.Year;
        int nLastYear = nYear - 1;

        DSSalesTrend oDSSalesTrend = new DSSalesTrend();

        OleDbCommand cmd = DBController.Instance.GetCommand();
        string sSQL = "";

        sSQL = " select 'Total' as Outlet, TYear, TMonth, CASE When TMonth = 1 then 'Jan' " +
        " When TMonth = 2 then 'Feb' When TMonth = 3 then 'Mar' " +
        " When TMonth = 4 then 'Apr' When TMonth = 5 then 'May' " +
        " When TMonth = 6 then 'Jun' When TMonth = 7 then 'Jul' " +
        " When TMonth = 8 then 'Aug' When TMonth = 9 then 'Sep' " +
        " When TMonth = 10 then 'Oct' When TMonth = 11 then 'Nov' else 'Dec' end " +
        " as MonthName, Sum(TargetQty) as TargetQty, Sum(TargetValue) as TargetValue from " + sDB + ".dbo.t_PlanMAGWeekTargetQty a,  " +
        " DWDB.dbo.t_CustomerDetails b , t_Showroom c where a.CustomerID=c.CustomerID and " +
        " a.CustomerID = b.CustomerID and b.CompanyName='" + sCompany + "' and a.MAGID = (select distinct MAGID from DWDB.dbo.t_ProductDetails where CompanyName='" + sCompany + "' and MAGName='"+sMAG+"') " +
        " and TYear = " + nYear + " ";
        if (sValueType != "Total")
        {
            if (sValueType == "Area")
            {
                sSQL = sSQL + "and b.AreaID = '" + sCustGroupID + "' ";
            }
            else if (sValueType == "Zone")
            {
                sSQL = sSQL + "and b.TerritoryID = '" + sCustGroupID + "' ";
            }
            else
            {
                sSQL = sSQL + "and c.ShowroomCode = '" + sValue + "' ";
            }
        }
        sSQL = sSQL + " Group by TMonth, TYear ";

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
            oSalesTrendRow.TargetQty = Convert.ToInt32(reader["TargetQty"]);
            oSalesTrendRow.TargetValue = Convert.ToDouble(reader["TargetValue"]);
            oSalesTrendRow.Type = "Target";

            oDSSalesTrend.SalesTrend.AddSalesTrendRow(oSalesTrendRow);
        }

        oDSSalesTrend.AcceptChanges();

        return oDSSalesTrend;
    }
}


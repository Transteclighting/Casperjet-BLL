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

using CJ.Class;
using CJ.Class.Report;
using CJ.Report;

public partial class Report_frmYearlyWattageWiseSalesQuantityCountrySummeryWise : System.Web.UI.Page
{
    rptYearlySKUNationals _oYearlySKUNational = new rptYearlySKUNationals();
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    private DateTime _LYStartingDate;
    private DateTime _LYEndingDate;
    private DateTime _CYEndingDate;
    private DateTime _LYCumEndingDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DBController.Instance.OpenNewConnection();
            if (!IsPostBack)
            {
                LoadAllCombo();
                cboStDay.Text = DateTime.Today.Day.ToString();
                cboStMonth.Text = DateTime.Today.Month.ToString();
                cboStYear.Text = DateTime.Today.Year.ToString();
            }
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Load All Combo (Channel Wise) =" + ex);
        }

    }

    private void LoadAllCombo()
    {
        DBController.Instance.OpenNewConnection();

        User oUser = (User)Session["User"];

        ProductGroups oProductGroups = new ProductGroups();
        oProductGroups.GETPG();
        cmbProductType.DataTextField = "PdtGroupName";
        cmbProductType.DataValueField = "PdtGroupId";
        cmbProductType.DataSource = oProductGroups;
        cmbProductType.DataBind();
        cmbProductType.SelectedIndex = oProductGroups.Count - 1;

        ProductGroups oMAG = new ProductGroups();
        oMAG.GETMAG();
        cmbMAG.DataTextField = "PdtGroupName";
        cmbMAG.DataValueField = "PdtGroupId";
        cmbMAG.DataSource = oMAG;
        cmbMAG.DataBind();
        cmbMAG.SelectedIndex = oMAG.Count - 1;

        ProductGroups oASG = new ProductGroups();
        oASG.GETASG();
        cmbASG.DataTextField = "PdtGroupName";
        cmbASG.DataValueField = "PdtGroupId";
        cmbASG.DataSource = oASG;
        cmbASG.DataBind();
        cmbASG.SelectedIndex = oASG.Count - 1;

        ProductGroups oAG = new ProductGroups();
        oAG.GETAG();
        cmbAG.DataTextField = "PdtGroupName";
        cmbAG.DataValueField = "PdtGroupId";
        cmbAG.DataSource = oAG;
        cmbAG.DataBind();
        cmbAG.SelectedIndex = oAG.Count - 1;

        Brands oBrands = new Brands();
        oBrands.GetBrand();
        cmbBrand.DataTextField = "BrandDesc";
        cmbBrand.DataValueField = "BrandID";
        cmbBrand.DataSource = oBrands;
        cmbBrand.DataBind();
        cmbBrand.SelectedIndex = oBrands.Count - 1;
    }
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        this.lblFromDateError.Visible = false;
        this.lblMessage.Visible = false;

        if (cboStMonth.SelectedValue != "0" && cboStYear.SelectedValue != "0" && cboStDay.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse("1"), int.Parse("1"));
            _LYStartingDate = new DateTime((int.Parse(cboStYear.SelectedValue) - 1), int.Parse("1"), int.Parse("1"));
        }
        else
        {
            this.lblFromDateError.Visible = true;
            this.lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }
        if (cboStMonth.SelectedValue != "0" && cboStYear.SelectedValue != "0" && cboStDay.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
            _LYCumEndingDate = new DateTime((int.Parse(cboStYear.SelectedValue) - 1), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
            _LYEndingDate = new DateTime((int.Parse(cboStYear.SelectedValue) - 1), int.Parse("12"), int.Parse("31"));
            _CYEndingDate = new DateTime((int.Parse(cboStYear.SelectedValue)), int.Parse("12"), int.Parse("31"));
        }
        else
        {
            this.lblFromDateError.Visible = true;
            this.lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }

        GetYearlySKUWiseNationalSales();
        if (_oYearlySKUNational != null)
        {
            fillReport();
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Data";
        }

    }

    private void GetYearlySKUWiseNationalSales()
    {

        try
        {
            DBController.Instance.OpenNewConnection();
            _oYearlySKUNational = new rptYearlySKUNationals();
            _oYearlySKUNational.YearlySKUNationalWise(_dStartingDate, _dEndingDate, _LYStartingDate, _LYEndingDate, _CYEndingDate, _LYCumEndingDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  Sales Summary Report (Channel Wise) =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = _oYearlySKUNational.ToDataSet();

        string sExpr = "";

        string sSort;

        lblMessage.Visible = false;
        sExpr = "ProductName like '%" + txtName.Text.Trim() + "%'";

        sSort = "ProductCodeInNumber ASC";

        if (txtCode.Text.Trim() != "")
        {
            sExpr = sExpr + " and ProductCode = '" + txtCode.Text.Trim() + "'";
        }

        if (int.Parse(cmbProductType.SelectedValue) != -1)
        {
            sExpr = sExpr + " and PGID = '" + cmbProductType.SelectedValue + "'";
        }
        if (int.Parse(cmbMAG.SelectedValue) != -1)
        {
            sExpr = sExpr + " and MAGID = '" + cmbMAG.SelectedValue + "'";
        }
        if (int.Parse(cmbBrand.SelectedValue) != -1)
        {
            sExpr = sExpr + " and BrandID = '" + cmbBrand.SelectedValue + "'";
        }

        if (int.Parse(cmbASG.SelectedValue) != -1)
        {
            sExpr = sExpr + " and ASGID = '" + cmbASG.SelectedValue + "'";
        }
        if (int.Parse(cmbAG.SelectedValue) != -1)
        {
            sExpr = sExpr + " and AGID = '" + cmbAG.SelectedValue + "'";
        }
        if (Convert.ToInt16(cmbActive.SelectedValue.ToString()) != 2)
        {
            sExpr = sExpr + " and IsActive = '" + cmbActive.SelectedValue + "'";
        }

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _oYearlySKUNational.FromDataSetForYearlySKUNationalWise(_oDS);
        else _oYearlySKUNational = null;
    }

    private void fillReport()
    {
        string sCompanyName = Utility.CompanyName;
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptYearlyWattageWiseSalesQuantityCountrySummeryWise));

        doc.SetDataSource(_oYearlySKUNational);
        doc.SetParameterValue("CompanyName", sCompanyName);

        doc.SetParameterValue("User Name", this.Context.User.Identity.Name);

        _dEndingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));

        doc.SetParameterValue("EndDate", _dEndingDate);

        doc.SetParameterValue("Report_Name", Table1.Rows[0].Cells[0].InnerText.Trim());
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;

        Response.Redirect("frmReportViewer.aspx");
    }
}

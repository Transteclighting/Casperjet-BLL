
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
using CJ.Class.CSD;
using CJ.Class.Report;
using CJ.Report.CSD;
using CJ.Report;


public partial class Report_CSD_frmProductPerformantceReportSKUWise : System.Web.UI.Page
{

    ProductPerformanceReportDetails _oProductPerformanceReportDetails = new ProductPerformanceReportDetails();
    
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    Utilities _oUtilities;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            DBController.Instance.OpenNewConnection();
            if (!IsPostBack)
            {

                cboStDay.Text = DateTime.Today.Day.ToString();
                cboStMonth.Text = DateTime.Today.Month.ToString();
                cboStYear.Text = DateTime.Today.Year.ToString();

                cboEndDay.Text = DateTime.Today.Day.ToString();
                cboEndMonth.Text = DateTime.Today.Month.ToString();
                cboEndYear.Text = DateTime.Today.Year.ToString();

                LoadAllCombo();
            }
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Load All Combo (SKU Wise) =" + ex);
        }

    }

    public void LoadAllCombo()
    {
        DBController.Instance.OpenNewConnection();

        //User oUser = (User)Session["User"];

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
            _dStartingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
        }
        else
        {
            this.lblFromDateError.Visible = true;
            this.lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }
        if (cboStMonth.SelectedValue != "0" && cboStYear.SelectedValue != "0" && cboStDay.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cboEndYear.SelectedValue), int.Parse(cboEndMonth.SelectedValue), int.Parse(cboEndDay.SelectedValue));
        }
        else
        {
            this.lblFromDateError.Visible = true;
            this.lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }

        GetProductPerformanceData();
        if (_oProductPerformanceReportDetails != null)
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

    private void GetProductPerformanceData()
    {
        try
        {
            DBController.Instance.OpenNewConnection();
            _oProductPerformanceReportDetails = new ProductPerformanceReportDetails();
            _oProductPerformanceReportDetails.ProductWisePerformanceReport(_dStartingDate, _dEndingDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  Product Performance Report (SKU Wise) =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = _oProductPerformanceReportDetails.ToDataSet();

        string sExpr = "";

        sExpr = "ProductName like '%" + txtName.Text.Trim() + "%'";

        if (txtProductCode.Text.Trim() != "")
        {
            sExpr = sExpr + " and ProductCode = '" + txtProductCode.Text.Trim() + "'";
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

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _oProductPerformanceReportDetails.FromDataSetProductPerformanceReport(_oDS);

        else _oProductPerformanceReportDetails = null;
    }

    private void fillReport()
    {
        string sCompanyName = Utility.CompanyName;
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptProductPerformanceReport));

        doc.SetDataSource(_oProductPerformanceReportDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);

        doc.SetParameterValue("ASG",cmbASG.SelectedItem.Text);
        doc.SetParameterValue("MAG",cmbMAG.SelectedItem.Text);
        doc.SetParameterValue("Brand",cmbBrand.SelectedItem.Text);
       
        doc.SetParameterValue("EntryBy", this.Context.User.Identity.Name);

        _dStartingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
        _dEndingDate = new DateTime(int.Parse(cboEndYear.SelectedValue), int.Parse(cboEndMonth.SelectedValue), int.Parse(cboEndDay.SelectedValue));

        doc.SetParameterValue("StDate", _dStartingDate);
        doc.SetParameterValue("EndDate", _dEndingDate);

        doc.SetParameterValue("Report_Name", Table1.Rows[0].Cells[0].InnerText.Trim());
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;

        Response.Redirect("~/Report/frmReportViewer.aspx");
    }
}



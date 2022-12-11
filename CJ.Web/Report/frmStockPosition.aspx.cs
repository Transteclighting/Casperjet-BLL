// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: Oct 13, 2011
// Time : 11:00 AM
// Description: Form for printing Stock Position Report
// Modify Person And Date:
// </summary>

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

using CJ.Report;
using CJ.Class;
using CJ.Class.Report;



public partial class frmRPTStockPosition : System.Web.UI.Page
{
    DateTime dDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {
            loadAllCombo();
        }
        DBController.Instance.CloseConnection();
    }

    private void loadAllCombo()
    {
        ProductGroups oProductGroups = new ProductGroups();
        oProductGroups.GETPG();
        cmbPG.DataTextField = "PdtGroupName";
        cmbPG.DataValueField = "PdtGroupId";
        cmbPG.DataSource = oProductGroups;
        cmbPG.DataBind();
        cmbPG.SelectedIndex = oProductGroups.Count - 1;

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

        Warehouses oWarehouses = new Warehouses();
        oWarehouses.GetWarehouse();
        cmbWarehouse.DataTextField = "WarehouseName";
        cmbWarehouse.DataValueField = "WarehouseID";
        cmbWarehouse.DataSource = oWarehouses;
        cmbWarehouse.DataBind();
        cmbWarehouse.SelectedIndex = oWarehouses.Count - 1;

        Warehouses oWHParent = new Warehouses();
        oWHParent.GetWarehouseParent();
        cmbWHP.DataTextField = "WarehouseParentName";
        cmbWHP.DataValueField = "WarehouseParentID";
        cmbWHP.DataSource = oWHParent;
        cmbWHP.DataBind();
        cmbWHP.SelectedIndex = oWHParent.Count - 1;

        Brands oBrands = new Brands();
        oBrands.GetBrand();
        cmbBrand.DataTextField = "BrandDesc";
        cmbBrand.DataValueField = "BrandID";
        cmbBrand.DataSource = oBrands;
        cmbBrand.DataBind();
        cmbBrand.SelectedIndex = oBrands.Count - 1;


        //From Date
        this.cmbStDay.Text = DateTime.Today.Day.ToString();
        this.cmbStMonth.Text = DateTime.Today.Month.ToString();
        this.cmbStYear.Text = DateTime.Today.Year.ToString();

    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        string sReportDetails="";
        string sReportFilter = "";

        if (Convert.ToInt32(cmbPG.SelectedValue) !=-1) sReportFilter = "PG: " + cmbPG.SelectedItem.Text;
        if (Convert.ToInt32(cmbMAG.SelectedValue) != -1) sReportFilter = sReportFilter + "  MAG: " + cmbMAG.SelectedItem.Text;
        if (Convert.ToInt32(cmbASG.SelectedValue) != -1) sReportFilter = sReportFilter + "  ASG: " + cmbASG.SelectedItem.Text;
        if (Convert.ToInt32(cmbAG.SelectedValue) != -1) sReportFilter = sReportFilter + "  AG: " + cmbAG.SelectedItem.Text;
        if (Convert.ToInt32(cmbBrand.SelectedValue) != -1) sReportFilter = sReportFilter + "  Brand: " + cmbBrand.SelectedItem.Text;
        if (Convert.ToInt32(cmbWHP.SelectedValue) != -1) sReportFilter = sReportFilter + "  WHP: " + cmbWHP.SelectedItem.Text;
        if (Convert.ToInt32(cmbWarehouse.SelectedValue) != -1) sReportFilter = sReportFilter + "  WH: " + cmbWarehouse.SelectedItem.Text;
        if (txtProductCode.Text != "") sReportFilter = sReportFilter + "  SKU Code: " + txtProductCode.Text;  
        if(txtName.Text!="") sReportFilter = sReportFilter + "  SKU Name: " + txtName.Text;

        StockPositionReports oRptStockPositions = new StockPositionReports();
        DBController.Instance.OpenNewConnection();

        int nPGID = Convert.ToInt32(cmbPG.SelectedValue);
        int nMAGID = Convert.ToInt32(cmbMAG.SelectedValue);
        int nASGID = Convert.ToInt32(cmbASG.SelectedValue);
        int nAGID = Convert.ToInt32(cmbAG.SelectedValue);
        int nBrandID = Convert.ToInt32(cmbBrand.SelectedValue);
        int nWHPID = Convert.ToInt32(cmbWHP.SelectedValue);
        int nWHID = Convert.ToInt32(cmbWarehouse.SelectedValue);
        string sProductCode = txtProductCode.Text;
        string sProductName = txtName.Text;

        if (rdoCurrent.Checked == true)
        {
            oRptStockPositions.Refresh(nPGID, nMAGID, nASGID, nAGID, nBrandID, nWHPID, nWHID, sProductCode, sProductName);
        }
        else
        {
            try
            {
                dDate = new DateTime((int.Parse(cmbStYear.SelectedValue)), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
            }
            catch
            {
                return;
            }
            oRptStockPositions.GetOpeningStock(dDate, nPGID, nMAGID, nASGID, nAGID, nBrandID, nWHPID, nWHID, sProductCode, sProductName);
        }
        DBController.Instance.CloseConnection();
        
        CrystalDecisions.CrystalReports.Engine.ReportClass oReport=new CrystalDecisions.CrystalReports.Engine.ReportClass();
        if (rdoASG.Checked)
        {
            if (rdoWHP.Checked)
            {
                sReportDetails = "ASG & Parent WH wise Summary";
                oReport = ReportFactory.GetReport(typeof(rptStockASGWHP));
                oReport.SetDataSource(oRptStockPositions);
            }
            else
            {
                sReportDetails = "ASG & Warehouse wise Summary";
                oReport = ReportFactory.GetReport(typeof(rptStockASGWH));
                oReport.SetDataSource(oRptStockPositions);
            }
        }
        else if (rdoAG.Checked)
        {
            if (rdoWHP.Checked)
            {
                sReportDetails = "AG & Parent WH wise Summary";
                oReport = ReportFactory.GetReport(typeof(rptStockAGWHP));
                oReport.SetDataSource(oRptStockPositions);
            }
            else
            {
                sReportDetails = "AG & Warehouse wise Summary";
                oReport = ReportFactory.GetReport(typeof(rptStockAGWHQty));
                oReport.SetDataSource(oRptStockPositions);
            }
        }
        else if (rdoProduct.Checked)
        {
            if (rdoWHP.Checked)
            {
                sReportDetails = "Product(SKU) & Parent WH wise Summary";
                oReport = ReportFactory.GetReport(typeof(rptStockSKUWHP));
                oReport.SetDataSource(oRptStockPositions);
            }
            else
            {
                sReportDetails = "Product(SKU) & Warehouse wise Details";
                oReport = ReportFactory.GetReport(typeof(rptStockSKUWHQty));
                oReport.SetDataSource(oRptStockPositions);
            }
        }
        Session["Doc"] = (object)oReport;


        string sCompanyName = Utility.CompanyName;
        string sReportName=Table1.Rows[0].Cells[0].InnerText.Trim();
        
        oReport.SetParameterValue("CompanyName", sCompanyName);
        oReport.SetParameterValue("Report_Name", sReportName + ": " + sReportDetails);
        oReport.SetParameterValue("ReportFilter", sReportFilter);
        oReport.SetParameterValue("User Name", this.Context.User.Identity.Name);
        //_dStartingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
        //doc.SetParameterValue("StDate", _dStartingDate);

        
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();

        Response.Redirect("frmReportViewer.aspx");
    }

    private void ControlsEnable()
    {
        cmbWarehouse.Enabled = rdoWH.Checked;

        cmbAG.Enabled = (rdoAG.Checked || rdoProduct.Checked);
        txtName.Enabled = rdoProduct.Checked;
        txtProductCode.Enabled = rdoProduct.Checked;
    }

    protected void rdoWHP_CheckedChanged(object sender, EventArgs e)
    {
        ControlsEnable();
    }

    protected void rdoWH_CheckedChanged(object sender, EventArgs e)
    {
        ControlsEnable();
    }
    protected void rdoASG_CheckedChanged(object sender, EventArgs e)
    {
        ControlsEnable();
    }
    protected void rdoAG_CheckedChanged(object sender, EventArgs e)
    {
        ControlsEnable();
    }
    protected void rdoProduct_CheckedChanged(object sender, EventArgs e)
    {
        ControlsEnable();
    }
    protected void rdoCurrent_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoCurrent.Checked == true)
        {
            rdoToDate.Checked = false;

            cmbStDay.Visible = false;
            cmbStMonth.Visible = false;
            cmbStYear.Visible = false;
        }
    }
    protected void rdoToDate_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoToDate.Checked == true)
        {
            rdoCurrent.Checked = false;

            cmbStDay.Visible = true;
            cmbStMonth.Visible = true;
            cmbStYear.Visible = true;
        }
        else
        {
            cmbStDay.Visible = false;
            cmbStMonth.Visible = false;
            cmbStYear.Visible = false;
        }
    }
    protected void cmbStDay_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

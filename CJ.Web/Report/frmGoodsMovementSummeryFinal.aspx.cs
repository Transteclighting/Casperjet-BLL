// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shahnoor Saeed
// Date: July 07, 2011
// Time :  12:00 PM
// Description: Goods Movement Summary SKU Wise
// Modify Person And Date:
// </summary>

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using CJ.Class;
using CJ.Class.Report;
using CJ.Report;


public partial class Report_frmGoodsMovementSummeryFinal : System.Web.UI.Page
{
    private WarehouseStocks _oWarehouseStocks;
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    string _sExpr;
    string _sQueryExpr;
    string _sFilteringDetails;
    private string _sSortingCriteria = "";
    private bool _IsSummary = true;
    string[] sReportName;

    protected void Page_Load(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {
            loadAllCombo();
        }
        DBController.Instance.CloseConnection();
    }
    private void ControlsEnable()
    {
        if (rdoASG.Checked)
        {
            cmbAG.Enabled = false;
            cmbAG.SelectedIndex = cmbAG.Items.Count -1;
            cmbActive.Enabled = false;
            cmbActive.SelectedIndex = cmbActive.Items.Count - 1;
            cmbPT.Enabled = false;
            cmbPT.SelectedIndex = cmbPT.Items.Count - 1;
            txtCode.Enabled = false;
            txtCode.Text = ""; 
            txtName.Enabled = false;
            txtName.Text = "";
        }
        if (rdoAG.Checked)
        {
            cmbAG.Enabled = true;
            cmbActive.Enabled = false;
            cmbActive.SelectedIndex = cmbActive.Items.Count -1;
            cmbPT.Enabled = false;
            cmbPT.SelectedIndex = cmbPT.Items.Count - 1;
            txtCode.Enabled = false;
            txtCode.Text = ""; 
            txtName.Enabled = false;
            txtName.Text = "";
        }
        if (rdoProduct.Checked)
        {
            cmbAG.Enabled = true;
            cmbPT.Enabled = true;
            cmbActive.Enabled = true;
            txtCode.Enabled = true;
            txtName.Enabled = true;
        }
        
    }

    protected void lnkShowGoodsMovementAll_Click(object sender, EventArgs e)
    {
        this.lblFromDateError.Visible = false;
        this.lblToDateError.Visible = false;
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
        if (cboEndDay.SelectedValue != "0" && cboEndMonth.SelectedValue != "0" && cboEndDay.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cboEndYear.SelectedValue), int.Parse(cboEndMonth.SelectedValue), int.Parse(cboEndDay.SelectedValue));
        }
        else
        {
            this.lblToDateError.Visible = true;
            this.lblToDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }
                
        makeClause();
        getGoodsMovement();
        if (_oWarehouseStocks != null)
        {
            showGoodsMovementAll();
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Data";
        }
        
    }
    private void loadAllCombo()
    {
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

        Warehouses oWarehouses = new Warehouses();
        oWarehouses.GetWarehouse();
        cmbWareHouse.DataTextField = "WarehouseName";
        cmbWareHouse.DataValueField = "WarehouseID";
        cmbWareHouse.DataSource = oWarehouses;
        cmbWareHouse.DataBind();
        cmbWareHouse.SelectedIndex = oWarehouses.Count - 1;

        Warehouses oWHParent = new Warehouses();
        oWHParent.GetWarehouseParent();
        cmbWarehouseLocation.DataTextField = "WarehouseParentName";
        cmbWarehouseLocation.DataValueField = "WarehouseParentID";
        cmbWarehouseLocation.DataSource = oWHParent;
        cmbWarehouseLocation.DataBind();
        cmbWarehouseLocation.SelectedIndex = oWHParent.Count - 1;

        Brands oBrands = new Brands();
        oBrands.GetBrand();
        cmbBrand.DataTextField = "BrandDesc";
        cmbBrand.DataValueField = "BrandID";
        cmbBrand.DataSource = oBrands;
        cmbBrand.DataBind();
        cmbBrand.SelectedIndex = oBrands.Count - 1;

             
        DataSet oDSProductType;
        oDSProductType = new DataSet();

        DataTable oTable = new DataTable("ProductType");

        DataColumn idColumn = new DataColumn("ID", Type.GetType("System.Int64"));
        DataColumn nameColumn = new DataColumn("Name", Type.GetType("System.String"));

        oTable.Columns.Add(idColumn);
        oTable.Columns.Add(nameColumn);

        DataRow oRow;
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductType)))
        {
            oRow = oTable.NewRow();
            oRow["ID"] = GetEnum;
            oRow["Name"] = Enum.GetName(typeof(Dictionary.ProductType), GetEnum);
            oTable.Rows.Add(oRow);
        }

        oRow = oTable.NewRow();
        oRow["Name"] = "<ALL>";
        oTable.Rows.Add(oRow);
        oDSProductType.Merge(oTable);
        oDSProductType.AcceptChanges();

        this.cmbPT.DataTextField = "Name";
        this.cmbPT.DataValueField = "ID";
        cmbPT.DataSource = oDSProductType.Tables["ProductType"];
        cmbPT.DataBind();
        cmbPT.SelectedIndex = cmbPT.Items.Count - 1;

        //From Date
        this.cboStDay.Text = DateTime.Today.Day.ToString();
        this.cboStMonth.Text = DateTime.Today.Month.ToString();
        this.cboStYear.Text = DateTime.Today.Year.ToString();

        //To Date
        this.cboEndDay.Text = DateTime.Today.Day.ToString();
        this.cboEndMonth.Text = DateTime.Today.Month.ToString();
        this.cboEndYear.Text = DateTime.Today.Year.ToString();
                
    }
    private void makeClause()
    {
        _sExpr = "ProductName like '%" + txtName.Text.Trim() + "%'";
        _sSortingCriteria = "ProductCodeInNumber ASC";
        _sQueryExpr = "";
        _sFilteringDetails = "";
        if (txtCode.Text.Trim() != "")
        {
            _sExpr = _sExpr + " and ProductCode = '" + txtCode.Text.Trim() + "'";
            _sFilteringDetails = _sFilteringDetails + " Product Code: " + txtCode.Text.Trim() + ";";

            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where ProductCode IN ('" + txtCode.Text.Trim() + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND ProductCode IN ('" + txtCode.Text.Trim() + "')";
            }
        }
        if (int.Parse(cmbProductType.SelectedValue.ToString()) != -1)
        {
            _sExpr = _sExpr + " and PGID = '" + cmbProductType.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " Product Group: " + cmbProductType.SelectedItem.ToString().Trim() + ";";

            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where PGID IN ('" + cmbProductType.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND PGID IN ('" + cmbProductType.SelectedValue + "')";
            }
        }
        if (int.Parse(cmbMAG.SelectedValue.ToString()) != -1)
        {
            _sExpr = _sExpr + " and MAGID = '" + cmbMAG.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " Main Article Group: " + cmbMAG.SelectedItem.ToString().Trim() + ";";

            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where MAGID IN ('" + cmbMAG.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND MAGID IN ('" + cmbMAG.SelectedValue + "')";
            }
        }
        if (int.Parse(cmbASG.SelectedValue.ToString()) != -1)
        {
            _sExpr = _sExpr + " and ASGID = '" + cmbASG.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " Article Sup Group: " + cmbASG.SelectedItem.ToString().Trim() + ";";
            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where ASGID IN ('" + cmbASG.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND ASGID IN ('" + cmbASG.SelectedValue + "')";
            }
        }
        if (int.Parse(cmbAG.SelectedValue.ToString()) != -1)
        {
            _sExpr = _sExpr + " and AGID = '" + cmbAG.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " Article Group: " + cmbAG.SelectedItem.ToString().Trim() + ";";

            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where AGID IN ('" + cmbAG.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND AGID IN ('" + cmbAG.SelectedValue + "')";
            }
        }
        if (int.Parse(cmbBrand.SelectedValue.ToString()) != -1)
        {
            _sExpr = _sExpr + " and BrandID = '" + cmbBrand.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " Brand: " + cmbBrand.SelectedItem.ToString().Trim() + ";";

            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where BrandID IN ('" + cmbBrand.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND BrandID IN ('" + cmbBrand.SelectedValue + "')";
            }
        }
        if (cmbPT.SelectedValue.ToString() != "")
        {
            _sExpr = _sExpr + " and ProductType = '" + cmbPT.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " Product Type: " + cmbPT.SelectedItem.ToString().Trim() + ";";

            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where ProductType IN ('" + cmbPT.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND ProductType IN ('" + cmbPT.SelectedValue + "')";
            }
        }
        else
        {
            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where ProductType IN (1,2,3,4,5,6,7,8,9)";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND ProductType IN (1,2,3,4,5,6,7,8,9)";
            }
        }
        if (int.Parse(cmbWarehouseLocation.SelectedValue.ToString()) != -1)
        {
            //_sExpr = _sExpr + " and WarehouseParentID = '" + cmbWarehouseLocation.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " Warehouse Location: " + cmbWarehouseLocation.SelectedItem.ToString().Trim() + ";";

            //if (_sQueryExpr.Trim().Length == 0)
            //{
            //    _sQueryExpr = "Where WarehouseParentID IN ('" + cmbWarehouseLocation.SelectedValue + "')";
            //}
            //else
            //{
            //    _sQueryExpr = _sQueryExpr + " AND WarehouseParentID IN ('" + cmbWarehouseLocation.SelectedValue + "')";
            //}
        }

        if (int.Parse(cmbWareHouse.SelectedValue.ToString()) != -1)
        {
            //_sExpr = _sExpr + " and WarehouseID = '" + cmbWareHouse.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " Warehouse: " + cmbWareHouse.SelectedItem.ToString().Trim() + ";";
            _IsSummary = false;
            //if (_sQueryExpr.Trim().Length == 0)
            //{
            //    _sQueryExpr = "Where WarehouseID IN ('" + cmbWareHouse.SelectedValue + "')";
            //}
            //else
            //{
            //    _sQueryExpr = _sQueryExpr + " AND WarehouseID IN ('" + cmbWareHouse.SelectedValue + "')";
            //}
        }
        if (Convert.ToInt16(cmbActive.SelectedValue.ToString()) != 2)
        {
            _sExpr = _sExpr + " and IsActive = '" + cmbActive.SelectedValue.ToString() + "'";
            _sFilteringDetails = _sFilteringDetails + " Product Continuation: " + cmbActive.SelectedItem.ToString().Trim() + ";";
            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where IsActive  IN ('" + cmbActive.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND IsActive  IN ('" + cmbActive.SelectedValue + "')";
            }
        }

    }
    private void getGoodsMovement()
    {
        //Day Starting and Ending Date
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate;

        string sQueryExpr = _sQueryExpr.ToString();

        try
        {
            _oWarehouseStocks = new WarehouseStocks();
            DBController.Instance.OpenNewConnection();
            if (rdoProduct.Checked)
            {
                int nWarehouseID = 0;
                int nParentWarehouseID = 0;
                int nIsWarehouseWise = 0;
                if (int.Parse(cmbWarehouseLocation.SelectedValue.ToString()) != -1)
                {
                    nParentWarehouseID = int.Parse(cmbWarehouseLocation.SelectedValue);
                }
                if (int.Parse(cmbWareHouse.SelectedValue.ToString()) != -1)
                {
                    nWarehouseID = int.Parse(cmbWareHouse.SelectedValue);
                    nIsWarehouseWise = 1;
                }
                
                if (nParentWarehouseID == 0 && nWarehouseID == 0)
                {
                    _oWarehouseStocks.GoodsMovementSummarySKUWise(dDFromDate, dDToDate, sQueryExpr);
                }
                else
                {
                    _oWarehouseStocks.GoodsMovementSummarySKUWiseNEW(dDFromDate, dDToDate, sQueryExpr, nParentWarehouseID, nWarehouseID, nIsWarehouseWise);
                }
            }
            else if (rdoAG.Checked)
            {
                _oWarehouseStocks.GoodsMovementSummaryAGWise(dDFromDate, dDToDate, sQueryExpr);
            }
            else if (rdoASG.Checked)
            {
                _oWarehouseStocks.GoodsMovementSummaryASGWise(dDFromDate, dDToDate, sQueryExpr);
            }
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: Goods Movement Summary Report =" + ex);
        }

    }
    private void showGoodsMovementAll()
    {
        lblMessage.Visible = false;
        string sCompanyName = Utility.CompanyName;
        
        
        if (rdoProduct.Checked)
        {
            sReportName = Table1.Rows[0].Cells[0].InnerText.ToString().Trim().Split('[');
            sReportName[0] = sReportName[0] + "SKU Wise Summary [609]";
        }
        else if (rdoAG.Checked)
        {
            sReportName = Table1.Rows[0].Cells[0].InnerText.ToString().Trim().Split('[');
            sReportName[0] = sReportName[0] + "AG Wise Summary [609]";
        }
        else if (rdoASG.Checked)
        {
            sReportName = Table1.Rows[0].Cells[0].InnerText.ToString().Trim().Split('[');
            sReportName[0] = sReportName[0] + "ASG Wise Summary [609]";
        }
        ////Solution of the problem: Maximum report processing jobs limit issue in Crystal Report
        ////http://geekswithblogs.net/technetbytes/archive/2007/07/17/114008.aspx

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = new CrystalDecisions.CrystalReports.Engine.ReportClass();
        if (rdoProduct.Checked)
        {
            doc = ReportFactory.GetReport(typeof(rptGoodsMonvementSummeryFinal));
            doc.SetDataSource(_oWarehouseStocks);
        }
        else if (rdoAG.Checked)
        {
            doc = ReportFactory.GetReport(typeof(rptGoodsMonvementSummeryAGWise));
            doc.SetDataSource(_oWarehouseStocks);
        }
        else if (rdoASG.Checked)
        {
            doc = ReportFactory.GetReport(typeof(rptGoodsMonvementSummeryASGWise));
            doc.SetDataSource(_oWarehouseStocks);
        }
        
        //CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptGoodsMonvementSummeryFinal));
        //doc.SetDataSource(_oWarehouseStocks);

        doc.SetParameterValue("User Name", this.Context.User.Identity.Name);
        doc.SetParameterValue("StDate", _dStartingDate);
        doc.SetParameterValue("EndDate", _dEndingDate);
        doc.SetParameterValue("CompanyName", sCompanyName);

        doc.SetParameterValue("Report_Name", sReportName[0]);
        doc.SetParameterValue("IsSummary", _IsSummary);
        doc.SetParameterValue("FilteringDetails", _sFilteringDetails);
        Session["ReportName"] = sReportName[0].ToString();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

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
}


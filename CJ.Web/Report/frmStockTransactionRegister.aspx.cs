// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shahnoor Saeed
// Date: July 20, 2011
// Time :  9:18 AM
// Description: Stock Transaction Register
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

public partial class Report_frmStockTransactionRegister : System.Web.UI.Page
{
    private StockTransactionRegisters _oStockTransactionRegisters;
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
    protected void lnkShowReport_Click(object sender, EventArgs e)
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
        getStockTransactionRegister();
        if (_oStockTransactionRegisters != null)
        {
            showStockTransactionRegister();
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
        cmbFromWarehouse.DataTextField = "WarehouseName";
        cmbFromWarehouse.DataValueField = "WarehouseID";
        cmbFromWarehouse.DataSource = oWarehouses;
        cmbFromWarehouse.DataBind();
        cmbFromWarehouse.SelectedIndex = oWarehouses.Count - 1;

        Warehouses oToWarehouses = new Warehouses();
        oToWarehouses.GetWarehouse();
        cmbToWareHouse.DataTextField = "WarehouseName";
        cmbToWareHouse.DataValueField = "WarehouseID";
        cmbToWareHouse.DataSource = oToWarehouses;
        cmbToWareHouse.DataBind();
        cmbToWareHouse.SelectedIndex = oToWarehouses.Count - 1;

        Brands oBrands = new Brands();
        oBrands.GetBrand();
        cmbBrand.DataTextField = "BrandDesc";
        cmbBrand.DataValueField = "BrandID";
        cmbBrand.DataSource = oBrands;
        cmbBrand.DataBind();
        cmbBrand.SelectedIndex = oBrands.Count - 1;

        ProductStockTranTypes oProductStockTranTypes = new ProductStockTranTypes();
        oProductStockTranTypes.GetProductStockTranType();
        cmbTranType.DataTextField = "TranTypeName";
        cmbTranType.DataValueField = "TranTypeID";
        cmbTranType.DataSource = oProductStockTranTypes;
        cmbTranType.DataBind();
        cmbTranType.SelectedIndex = oProductStockTranTypes.Count - 1;

        
        //From Date
        this.cboStDay.Text = DateTime.Today.Day.ToString();
        this.cboStMonth.Text = DateTime.Today.Month.ToString();
        this.cboStYear.Text = DateTime.Today.Year.ToString();

        //To Date
        this.cboEndDay.Text = DateTime.Today.Day.ToString();
        this.cboEndMonth.Text = DateTime.Today.Month.ToString();
        this.cboEndYear.Text = DateTime.Today.Year.ToString();

    }
    private void ControlsEnable()
    {
        if (rdoASG.Checked)
        {
            cmbAG.Enabled = false;
            cmbAG.SelectedIndex = cmbAG.Items.Count - 1;
            txtCode.Enabled = false;
            txtCode.Text = "";
            txtName.Enabled = false;
            txtName.Text = "";

        }
        if (rdoAG.Checked)
        {
            cmbAG.Enabled = true;
            txtCode.Enabled = false;
            txtCode.Text = "";
            txtName.Enabled = false;
            txtName.Text = "";
        }
        if (rdoProduct.Checked)
        {
            cmbAG.Enabled = true;
            txtCode.Enabled = true;
            txtName.Enabled = true;
        }
        
    }
    protected void rdoProduct_CheckedChanged(object sender, EventArgs e)
    {
        ControlsEnable();
    }
    protected void rdoAG_CheckedChanged(object sender, EventArgs e)
    {
        ControlsEnable();
    }
    protected void rdoASG_CheckedChanged(object sender, EventArgs e)
    {
        ControlsEnable();
    }
    protected void cmbTranType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ALL)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = true;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.GOODS_RECEIVE)
        {
            cmbFromWarehouse.Enabled = false;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = true;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.TRANSFER)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = true;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.INVOICE)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = true;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ADD_STOCK)
        {
            cmbFromWarehouse.Enabled = false;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = true;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.DEDUCT_STOCK)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ISSUE_SALES_PROMOTION)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ISSUE_FIXED_ASSET)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ISSUE_CE_SERVICE_REPLACEMENT)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.RETURN_DEFECTIVE_PRODUCT)
        {
            cmbFromWarehouse.Enabled = false;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = true;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ISSUE_COMPANY_CONSUMPTION)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ISSUE_LE_SERVICE_REPLACENENT)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ISSUE_PRODUCT_RETURN_TO_SUPPLIER)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ISSUE_FOR_PRODUCTION)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.DELIVERY_BREAKAGE_REPLACEMENT)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ISSUE_SHORT_DELIVERY_PRODUCT)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ISSUE_SCRAP_SALE)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ISSUE_DEFECTIVE_OR_SCRAP)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.RECEIVE_SERVICE_DEFECTIVE_PRODUCT)
        {
            cmbFromWarehouse.Enabled = false;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = true;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.RETURN_SALES_PROMOTION)
        {
            cmbFromWarehouse.Enabled = false;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = true;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.RETURN_FIXED_ASSET)
        {
            cmbFromWarehouse.Enabled = false;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = true;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) == (int)Dictionary.ProductStockTranType.ISSUE_FOR_CANNIBALIZE)
        {
            cmbFromWarehouse.Enabled = true;
            cmbFromWarehouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
            cmbToWareHouse.Enabled = false;
            cmbToWareHouse.SelectedIndex = cmbFromWarehouse.Items.Count - 1;
        }
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

        if (int.Parse(cmbFromWarehouse.SelectedValue.ToString()) != -1)
        {
            _sExpr = _sExpr + " and WarehouseID = '" + cmbFromWarehouse.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " From Warehouse: " + cmbFromWarehouse.SelectedItem.ToString().Trim() + ";";
            _IsSummary = false;
            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where WarehouseID IN ('" + cmbFromWarehouse.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND WarehouseID IN ('" + cmbFromWarehouse.SelectedValue + "')";
            }
        }

        if (int.Parse(cmbToWareHouse.SelectedValue.ToString()) != -1)
        {
            _sExpr = _sExpr + " and WarehouseID = '" + cmbToWareHouse.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " TO Warehouse: " + cmbToWareHouse.SelectedItem.ToString().Trim() + ";";
            _IsSummary = false;
            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where WarehouseID IN ('" + cmbToWareHouse.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND WarehouseID IN ('" + cmbToWareHouse.SelectedValue + "')";
            }
        }
        if (int.Parse(cmbTranType.SelectedValue.ToString()) != -1)
        {
            _sExpr = _sExpr + " and TranTypeID = '" + cmbTranType.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " Tran Type: " + cmbTranType.SelectedItem.ToString().Trim() + ";";
            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where TranTypeID IN ('" + cmbTranType.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND TranTypeID IN ('" + cmbTranType.SelectedValue + "')";
            }
        }
        if (Convert.ToInt16(cmbTranSide.SelectedValue.ToString()) != 3)
        {
            _sExpr = _sExpr + " and TransactionSide = '" + cmbTranSide.SelectedValue.ToString() + "'";
            _sFilteringDetails = _sFilteringDetails + " Tran Side: " + cmbTranSide.SelectedItem.ToString().Trim() + ";";
            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = "Where TransactionSide  IN ('" + cmbTranSide.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND TransactionSide  IN ('" + cmbTranSide.SelectedValue + "')";
            }
        }

    }
    private void getStockTransactionRegister()
    {
        //Day Starting and Ending Date
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate;

        string sQueryExpr = _sQueryExpr.ToString();

        try
        {
            _oStockTransactionRegisters = new StockTransactionRegisters();

            DBController.Instance.OpenNewConnection();
            
            _oStockTransactionRegisters.StockTransactionRegister(dDFromDate, dDToDate, sQueryExpr);
            
            DBController.Instance.CloseConnection();

            //if (rdoProduct.Checked)
            //{
            //    _oStockTransactionRegisters.StockTransactionRegister(dDFromDate, dDToDate, sQueryExpr);
            //}
            //else if (rdoAG.Checked)
            //{
            //    _oWarehouseStocks.GoodsMovementSummaryAGWise(dDFromDate, dDToDate, sQueryExpr);
            //}
            //else if (rdoASG.Checked)
            //{
            //    _oWarehouseStocks.GoodsMovementSummaryASGWise(dDFromDate, dDToDate, sQueryExpr);
            //}
            //DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: Stock Transaction Register Report =" + ex);
        }

    }
    private void showStockTransactionRegister()
    {
        lblMessage.Visible = false;
        string sCompanyName = Utility.CompanyName;


        if (rdoProduct.Checked)
        {
            sReportName = Table1.Rows[0].Cells[0].InnerText.ToString().Trim().Split('[');
            sReportName[0] = sReportName[0] + "SKU Wise [603]";
        }
        else if (rdoAG.Checked)
        {
            sReportName = Table1.Rows[0].Cells[0].InnerText.ToString().Trim().Split('[');
            sReportName[0] = sReportName[0] + "AG Wise [603]";
        }
        else if (rdoASG.Checked)
        {
            sReportName = Table1.Rows[0].Cells[0].InnerText.ToString().Trim().Split('[');
            sReportName[0] = sReportName[0] + "ASG Wise [603]";
        }
        ////Solution of the problem: Maximum report processing jobs limit issue in Crystal Report
        ////http://geekswithblogs.net/technetbytes/archive/2007/07/17/114008.aspx

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = new CrystalDecisions.CrystalReports.Engine.ReportClass();
        if (rdoProduct.Checked)
        {
            doc = ReportFactory.GetReport(typeof(rptStockTransactionRegisterSKUWise));
            doc.SetDataSource(_oStockTransactionRegisters);
        }
        else if (rdoAG.Checked)
        {
            doc = ReportFactory.GetReport(typeof(rptStockTransactionRegisterAGWise));
            doc.SetDataSource(_oStockTransactionRegisters);
        }
        else if (rdoASG.Checked)
        {
            doc = ReportFactory.GetReport(typeof(rptStockTransactionRegisterASGWise));
            doc.SetDataSource(_oStockTransactionRegisters);
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
}

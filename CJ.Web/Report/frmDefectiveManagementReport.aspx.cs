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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


public partial class Report_frmDefectiveManagementReport : System.Web.UI.Page
{
    private UnsoldDefectiveProducts _oUDPs;
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    string _sExpr;
    string _sQueryExpr;
    string _sFilteringDetails;
    private string _sSortingCriteria = "";
    private bool _IsSummary = true;
    string[] sReportName;

    int nWarehouseGroupID;
    int nWarehouseParentID; int nWarehouseID;
    int nPGID;
    int nMAGID;
    int nASGID;
    int nAGID;
    int nBrandID;
    string sProductCode="";
    string sProductDesc="";


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
            cmbAG.Enabled = true;
            cmbPT.Enabled = true;
            cmbActive.Enabled = true;
            txtCode.Enabled = true;
            txtName.Enabled = true;
       
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
        if (_oUDPs != null)
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
        oMAG.RefreshForAll(Convert.ToInt32(cmbProductType.Text));
        cmbMAG.DataTextField = "PdtGroupName";
        cmbMAG.DataValueField = "PdtGroupId";
        cmbMAG.DataSource = oMAG;
        cmbMAG.DataBind();
        cmbMAG.SelectedIndex = oMAG.Count - 1;

        ProductGroups oASG = new ProductGroups();
        oASG.RefreshForAll(Convert.ToInt32(cmbMAG.Text));
        cmbASG.DataTextField = "PdtGroupName";
        cmbASG.DataValueField = "PdtGroupId";
        cmbASG.DataSource = oASG;
        cmbASG.DataBind();
        cmbASG.SelectedIndex = oASG.Count - 1;

        ProductGroups oAG = new ProductGroups();
        //oAG.GETAG();
        oAG.RefreshForAll(Convert.ToInt32(cmbASG.Text));
        cmbAG.DataTextField = "PdtGroupName";
        cmbAG.DataValueField = "PdtGroupId";
        cmbAG.DataSource = oAG;
        cmbAG.DataBind();
        cmbAG.SelectedIndex = oAG.Count - 1;

        Warehouses oWHGroup = new Warehouses();
        oWHGroup.GetWarehouseGroup();
        cmbWHGroup.DataTextField = "WarehouseGroupName";
        cmbWHGroup.DataValueField = "WarehouseGroupID";
        cmbWHGroup.DataSource = oWHGroup;
        cmbWHGroup.DataBind();
        cmbWHGroup.SelectedIndex = oWHGroup.Count - 1;


        Warehouses oWHParent = new Warehouses();
        oWHParent.GetWarehouseParent();
        cmbWarehouseLocation.DataTextField = "WarehouseParentName";
        cmbWarehouseLocation.DataValueField = "WarehouseParentID";
        cmbWarehouseLocation.DataSource = oWHParent;
        cmbWarehouseLocation.DataBind();
        cmbWarehouseLocation.SelectedIndex = oWHParent.Count - 1;

        Warehouses oWarehouses = new Warehouses();
        oWarehouses.GetWarehouseAgainstGroup(-1,-1);
        cmbWareHouse.DataTextField = "WarehouseName";
        cmbWareHouse.DataValueField = "WarehouseID";
        cmbWareHouse.DataSource = oWarehouses;
        cmbWareHouse.DataBind();
        cmbWareHouse.SelectedIndex = oWarehouses.Count - 1;


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
                _sQueryExpr = " AND ProductCode IN ('" + txtCode.Text.Trim() + "')";
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
                _sQueryExpr = " AND PGID IN ('" + cmbProductType.SelectedValue + "')";
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
                _sQueryExpr = " AND MAGID IN ('" + cmbMAG.SelectedValue + "')";
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
                _sQueryExpr = " AND ASGID IN ('" + cmbASG.SelectedValue + "')";
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
                _sQueryExpr = " AND AGID IN ('" + cmbAG.SelectedValue + "')";
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
                _sQueryExpr = " AND BrandID IN ('" + cmbBrand.SelectedValue + "')";
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
                _sQueryExpr = " AND ProductType IN ('" + cmbPT.SelectedValue + "')";
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
                _sQueryExpr = " AND ProductType IN (1,2,3,4,5,6,7,8,9)";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND ProductType IN (1,2,3,4,5,6,7,8,9)";
            }
        }

        if (int.Parse(cmbWHGroup.SelectedValue.ToString()) != -1)
        {
            _sExpr = _sExpr + " and WarehouseGroupID = '" + cmbWHGroup.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " Warehouse Group: " + cmbWHGroup.SelectedItem.ToString().Trim() + ";";

            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = " AND WarehouseGroupID IN ('" + cmbWHGroup.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND WarehouseGroupID IN ('" + cmbWHGroup.SelectedValue + "')";
            }
        }

        if (int.Parse(cmbWarehouseLocation.SelectedValue.ToString()) != -1)
        {
            _sExpr = _sExpr + " and WarehouseParentID = '" + cmbWarehouseLocation.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " Warehouse Location: " + cmbWarehouseLocation.SelectedItem.ToString().Trim() + ";";

            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = " AND WarehouseParentID IN ('" + cmbWarehouseLocation.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND WarehouseParentID IN ('" + cmbWarehouseLocation.SelectedValue + "')";
            }
        }

        if (int.Parse(cmbWareHouse.SelectedValue.ToString()) != -1)
        {
            _sExpr = _sExpr + " and WarehouseID = '" + cmbWareHouse.SelectedValue + "'";
            _sFilteringDetails = _sFilteringDetails + " Warehouse: " + cmbWareHouse.SelectedItem.ToString().Trim() + ";";
            _IsSummary = false;
            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = " AND WarehouseID IN ('" + cmbWareHouse.SelectedValue + "')";
            }
            else
            {
                _sQueryExpr = _sQueryExpr + " AND WarehouseID IN ('" + cmbWareHouse.SelectedValue + "')";
            }
        }
        if (Convert.ToInt16(cmbActive.SelectedValue.ToString()) != 2)
        {
            _sExpr = _sExpr + " and IsActive = '" + cmbActive.SelectedValue.ToString() + "'";
            _sFilteringDetails = _sFilteringDetails + " Product Continuation: " + cmbActive.SelectedItem.ToString().Trim() + ";";
            if (_sQueryExpr.Trim().Length == 0)
            {
                _sQueryExpr = " AND IsActive  IN ('" + cmbActive.SelectedValue + "')";
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
            _oUDPs = new UnsoldDefectiveProducts();
            DBController.Instance.OpenNewConnection();
            _oUDPs.UnsoldDefectiveReport(dDFromDate, dDToDate, sQueryExpr);
            //_oUDPs.UnsoldDefectiveReport(nWarehouseGroupID, nWarehouseParentID, nWarehouseID, nPGID, nMAGID, nASGID, nAGID, nBrandID, sProductCode, sProductDesc);
            
            
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: Barcode Based Goods Movement Summary Report" + ex);
        }

    }
    private void showGoodsMovementAll()
    {
        lblMessage.Visible = false;
        string sCompanyName = Utility.CompanyName;

        sReportName = Table1.Rows[0].Cells[0].InnerText.ToString().Trim().Split('[');
        sReportName[0] = sReportName[0] + "Summary [613]";

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = new CrystalDecisions.CrystalReports.Engine.ReportClass();

        doc = ReportFactory.GetReport(typeof(rptDefectiveProductReport));
        doc.SetDataSource(_oUDPs);

        //ReportDocument rpt = new ReportDocument();
        //rpt.Load(HttpContext.Current.Server.MapPath("rptDefectiveProductReport.rpt"));
        //rpt.SetDataSource(_oUDPs);
        //rpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "sales");



        doc.SetParameterValue("User Name", this.Context.User.Identity.Name);
        doc.SetParameterValue("StDate", _dStartingDate);
        doc.SetParameterValue("EndDate", _dEndingDate);
        doc.SetParameterValue("CompanyName", sCompanyName);

        doc.SetParameterValue("Report_Name", sReportName[0]);
        //doc.SetParameterValue("IsSummary", _IsSummary);
        doc.SetParameterValue("FilteringDetails", _sFilteringDetails);

        Session["ReportName"] = sReportName[0].ToString();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

    }
 
    protected void rdoProduct_CheckedChanged(object sender, EventArgs e)
    {
        ControlsEnable();
    }

    protected void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();

        ProductGroups oMAG = new ProductGroups();
        oMAG.RefreshForAll(Convert.ToInt32(cmbProductType.Text));
        cmbMAG.DataTextField = "PdtGroupName";
        cmbMAG.DataValueField = "PdtGroupId";
        cmbMAG.DataSource = oMAG;
        cmbMAG.DataBind();
        cmbMAG.SelectedIndex = oMAG.Count - 1;

        DBController.Instance.CloseConnection();
    }

    protected void cmbMAG_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();

        ProductGroups oASG = new ProductGroups();
        oASG.RefreshForAll(Convert.ToInt32(cmbMAG.Text));
        cmbASG.DataTextField = "PdtGroupName";
        cmbASG.DataValueField = "PdtGroupId";
        cmbASG.DataSource = oASG;
        cmbASG.DataBind();
        cmbASG.SelectedIndex = oASG.Count - 1;
        DBController.Instance.CloseConnection();
    }

    protected void cmbASG_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();

        ProductGroups oAG = new ProductGroups();
        //oAG.GETAG();
        oAG.RefreshForAll(Convert.ToInt32(cmbASG.Text));
        cmbAG.DataTextField = "PdtGroupName";
        cmbAG.DataValueField = "PdtGroupId";
        cmbAG.DataSource = oAG;
        cmbAG.DataBind();
        cmbAG.SelectedIndex = oAG.Count - 1;
        DBController.Instance.CloseConnection();
    }

    protected void cmbWHGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();

        Warehouses oWarehouses = new Warehouses();
        oWarehouses.GetWarehouseAgainstGroup(Convert.ToInt32(cmbWHGroup.Text), Convert.ToInt32(cmbWarehouseLocation.Text));
        cmbWareHouse.DataTextField = "WarehouseName";
        cmbWareHouse.DataValueField = "WarehouseID";
        cmbWareHouse.DataSource = oWarehouses;
        cmbWareHouse.DataBind();
        cmbWareHouse.SelectedIndex = oWarehouses.Count - 1;
        DBController.Instance.CloseConnection();
    }

    protected void cmbWarehouseLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();

        Warehouses oWarehouses = new Warehouses();
        oWarehouses.GetWarehouseAgainstGroup(Convert.ToInt32(cmbWHGroup.Text), Convert.ToInt32(cmbWarehouseLocation.Text));
        cmbWareHouse.DataTextField = "WarehouseName";
        cmbWareHouse.DataValueField = "WarehouseID";
        cmbWareHouse.DataSource = oWarehouses;
        cmbWareHouse.DataBind();
        cmbWareHouse.SelectedIndex = oWarehouses.Count - 1;
        DBController.Instance.CloseConnection();
    }
}


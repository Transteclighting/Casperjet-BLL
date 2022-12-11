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
using CJ.Class.Web.UI.Class;

public partial class Report_frmProductSalesQtyinTD : System.Web.UI.Page
{
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    RptSalesSKUwiseforTDdetails _oRptSalesSKUwiseforTDdetails;
    protected void Page_Load(object sender, EventArgs e)
    {
         DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {
            cmbStDay.Text = DateTime.Today.Day.ToString();
            cmbStMonth.Text = DateTime.Today.Month.ToString();
            cmbStYear.Text = DateTime.Today.Year.ToString();

            cmbEndDay.Text = DateTime.Today.Day.ToString();
            cmbEndMonth.Text = DateTime.Today.Month.ToString();
            cmbEndYear.Text = DateTime.Today.Year.ToString();
            
            LoadAllCombo();
        }
        DBController.Instance.CloseConnection();

    }

     public void LoadAllCombo()
    {
        DBController.Instance.OpenNewConnection();

        User oUser = (User)Session["User"];
        
         SBUs oSBUs = new SBUs();
       
        MarketGroups oMarketGroups = new MarketGroups();
        oMarketGroups.GetArea(oUser.UserId);
        if (oMarketGroups.Count > 0)
        {
            Session.Add("Area", oMarketGroups);
            cmbArea.DataTextField = "MarketGroupDesc";
            cmbArea.DataValueField = "MarketGroupID";
            cmbArea.DataSource = oMarketGroups;
            cmbArea.DataBind();
            cmbArea.SelectedIndex = oMarketGroups.Count - 1;
        }
        else
        {
            MarketGroup oMarketGroup = new MarketGroup();
            oMarketGroup.MarketGroupID = 0;
            oMarketGroup.MarketGroupDesc = "No Permission";
            oMarketGroups.Add(oMarketGroup);

            cmbArea.DataTextField = "MarketGroupDesc";
            cmbArea.DataValueField = "MarketGroupID";
            cmbArea.DataSource = oMarketGroups;
            cmbArea.DataBind();
        }

        oMarketGroups = new MarketGroups();
        oMarketGroups.GetTerritory(oUser.UserId);
        if (oMarketGroups.Count > 0)
        {
            Session.Add("Territory", oMarketGroups);
            cmbTerritory.DataTextField = "MarketGroupDesc";
            cmbTerritory.DataValueField = "MarketGroupID";
            cmbTerritory.DataSource = oMarketGroups;
            cmbTerritory.DataBind();
            cmbTerritory.SelectedIndex = oMarketGroups.Count - 1;
        }
        else
        {
            MarketGroup oMarketGroup = new MarketGroup();
            oMarketGroup.MarketGroupID = 0;
            oMarketGroup.MarketGroupDesc = "No Permission";
            oMarketGroups.Add(oMarketGroup);

            cmbTerritory.DataTextField = "MarketGroupDesc";
            cmbTerritory.DataValueField = "MarketGroupID";
            cmbTerritory.DataSource = oMarketGroups;
            cmbTerritory.DataBind();
        }

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

    protected void lnkShowReportB_Click(object sender, EventArgs e)
    {
        MarketGroups _oArea = (MarketGroups)Session["Area"];
        MarketGroups _oTerritory = (MarketGroups)Session["Territory"];

        if (cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0" && cmbStDay.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select valid date ";
            return;
        }
        if (cmbEndMonth.SelectedValue != "0" && cmbEndYear.SelectedValue != "0" && cmbEndDay.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cmbEndYear.SelectedValue), int.Parse(cmbEndMonth.SelectedValue), int.Parse(cmbEndDay.SelectedValue));
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select valid date ";
            return;
        }
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate;

        _oRptSalesSKUwiseforTDdetails = new RptSalesSKUwiseforTDdetails();
        DBController.Instance.OpenNewConnection();

        _oRptSalesSKUwiseforTDdetails.ProductSalesQtyforTD(_dStartingDate, _dEndingDate);
        DBController.Instance.CloseConnection();
        DataSet oDS = new DataSet();
        oDS = _oRptSalesSKUwiseforTDdetails.ToDataSet();

        string sExpr = "";

        sExpr = "ProductName like '%" + txtPCode.Text.Trim() + "%'";
               
        
        if ((txtPCode.Text) != "")
        {
            sExpr = sExpr + " and ProductCode = '" + txtPCode.Text + "'";
        }
        if ((txtCode.Text) != "")
        {
            sExpr = sExpr + " and OutletCode = '" + txtCode.Text + "'";
        }

        if ((txtPName.Text) != "")
        {
            sExpr = sExpr + " and ProductName = '" + txtPName.Text + "'";
        }              

        if (int.Parse(cmbArea.SelectedValue) != -1)
        {
            sExpr = sExpr + " and AreaID = '" + cmbArea.SelectedValue + "'";
        }
        else sExpr = sExpr + " and AreaID in (" + GetAllArea() + ")";

        if (int.Parse(cmbTerritory.SelectedValue) != -1)
        {
            sExpr = sExpr + " and TerritoryID = '" + cmbTerritory.SelectedValue + "'";
        }
        else sExpr = sExpr + " and TerritoryID in (" + GetAllTerritory() + ")";

       
        if (int.Parse(cmbProductType.SelectedValue) != -1)
        {
            sExpr = sExpr + " and PGID = '" + cmbProductType.SelectedValue + "'";
        }
        if (int.Parse(cmbMAG.SelectedValue) != -1)
        {
            sExpr = sExpr + " and MAGID = '" + cmbMAG.SelectedValue + "'";
        }
        if (int.Parse(cmbASG.SelectedValue) != -1)
        {
            sExpr = sExpr + " and ASGID = '" + cmbASG.SelectedValue + "'";
        }
        if (int.Parse(cmbAG.SelectedValue) != -1)
        {
            sExpr = sExpr + " and AGID = '" + cmbAG.SelectedValue + "'";
        }
        if (int.Parse(cmbBrand.SelectedValue) != -1)
        {
            sExpr = sExpr + " and BrandID = '" + cmbBrand.SelectedValue + "'";
        }        

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _oRptSalesSKUwiseforTDdetails.FromDataSetProductSalesQtyforTD(_oDS);
        else _oRptSalesSKUwiseforTDdetails = null;

        if (_oRptSalesSKUwiseforTDdetails != null)
        {
            FillReport();
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = " No Data ";
        }
    }

    public void FillReport()
    {
        string sCompanyName = Utility.CompanyName;
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesReportSKUwiseTD));

        doc.SetDataSource(_oRptSalesSKUwiseforTDdetails);
        doc.SetParameterValue("CompanyName", sCompanyName);        
        doc.SetParameterValue("Area", cmbArea.SelectedItem.Text);
        doc.SetParameterValue("Territory", cmbTerritory.SelectedItem.Text);
        doc.SetParameterValue("PG", cmbProductType.SelectedItem.Text);
        doc.SetParameterValue("MAG", cmbMAG.SelectedItem.Text);
        doc.SetParameterValue("ASG", cmbASG.SelectedItem.Text);
        doc.SetParameterValue("AG", cmbAG.SelectedItem.Text);
        doc.SetParameterValue("Brand", cmbBrand.SelectedItem.Text);
        doc.SetParameterValue("StDate", _dStartingDate);
        doc.SetParameterValue("EndDate", _dEndingDate);
        doc.SetParameterValue("ReportName", " Product Sales Quantity Outlet Wise [68]");
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

    }

    public string GetAllArea()
    {
        MarketGroups _oMarketGroups = (MarketGroups)Session["Area"];
        string sPermission = "";

        foreach (MarketGroup oMarketGroup in _oMarketGroups)
        {
            if (sPermission == "")
                sPermission = oMarketGroup.MarketGroupID.ToString();
            else
                sPermission = sPermission + "," + oMarketGroup.MarketGroupID.ToString();

        }
        return sPermission;
    }
    public string GetAllTerritory()
    {
        MarketGroups _oMarketGroups = (MarketGroups)Session["Territory"];
        string sPermission = "";

        foreach (MarketGroup oMarketGroup in _oMarketGroups)
        {
            if (sPermission == "")
                sPermission = oMarketGroup.MarketGroupID.ToString();
            else
                sPermission = sPermission + "," + oMarketGroup.MarketGroupID.ToString();

        }
        return sPermission;
    }
}

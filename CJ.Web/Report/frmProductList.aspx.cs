using System;
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

public partial class Report_frmProductList : System.Web.UI.Page
{
    RptOficialPriceListDetails _RptOficialPriceListDetails;

    protected void Page_Load(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {
            LoadAllCombo();
        }
        DBController.Instance.CloseConnection();


    }
    protected void btnShowReport_Click(object sender, EventArgs e)
    {

        _RptOficialPriceListDetails = new RptOficialPriceListDetails();
        DBController.Instance.OpenNewConnection();
        _RptOficialPriceListDetails.OfficialPriceList();
        DBController.Instance.CloseConnection();
        DataSet oDS = new DataSet();
        oDS = _RptOficialPriceListDetails.ToDataSet();

        string sExpr = "";

        sExpr = " ProductName like '%" + txtName.Text.Trim() + "%'";

        if ((txtProductCode.Text) != "")
        {
            sExpr = sExpr + " and ProductCode = '" + txtProductCode.Text + "'";
        }

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

        if (CmbSupply.SelectedValue.ToString() != "")
        {
            sExpr = sExpr + " and SupplyType = '" + CmbSupply.SelectedValue + "'";
        }

        if (Convert.ToInt32(CmbVatApplicable.SelectedValue.ToString()) != 2)
        {
            sExpr = sExpr + " and VatApplicable = '" + CmbVatApplicable.SelectedValue + "'";
        }

        if (int.Parse(cmbActive.SelectedValue) != -1)
        {
            sExpr = sExpr + " and IsActive = '" + cmbActive.SelectedValue + "'";
        }

        

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _RptOficialPriceListDetails.FromDataSetOfficialPriceList(_oDS);
        else _RptOficialPriceListDetails = null;

        if (_RptOficialPriceListDetails != null)
        {
            FillReport();
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = " No Data ";
        }   
         

    }

    public void LoadAllCombo()
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
    public void FillReport()
    {
        string sCompanyName = Utility.CompanyName;
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptProductDetailwithHaierkey));
        doc.SetDataSource(_RptOficialPriceListDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("ProductGroup", cmbProductType.SelectedItem.Text);
        doc.SetParameterValue("MAG", cmbMAG.SelectedItem.Text);
        doc.SetParameterValue("ASG", cmbASG.SelectedItem.Text);
        doc.SetParameterValue("AG", cmbAG.SelectedItem.Text);
        doc.SetParameterValue("Brand", cmbBrand.SelectedItem.Text);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("Status", cmbActive.SelectedItem.Text);
        doc.SetParameterValue("ReportName", " Product Details [100]");
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

    }
    
}

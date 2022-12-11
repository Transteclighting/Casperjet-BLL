
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

public partial class Report_frmWarehouseWiseStockReport : System.Web.UI.Page
{
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    RptWarehouseWiseStockReportDetails _RptWarehouseWiseStockReportDetails;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {
            cmbStDay.Text = DateTime.Today.Day.ToString();
            cmbStMonth.Text = DateTime.Today.Month.ToString();
            cmbStYear.Text = DateTime.Today.Year.ToString();            

            LoadAllCombo();
        }
        DBController.Instance.CloseConnection();

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


    protected void btnShowReport_Click(object sender, EventArgs e)
    {
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
        
        DateTime dDFromDate = _dStartingDate;
        _dStartingDate = _dStartingDate.AddDays(1);
        _dEndingDate = DateTime.Today.AddDays(1);

        _RptWarehouseWiseStockReportDetails = new RptWarehouseWiseStockReportDetails();
        DBController.Instance.OpenNewConnection();
        _RptWarehouseWiseStockReportDetails.WarehouseWiseStockReport(_dStartingDate, _dEndingDate);
        DBController.Instance.CloseConnection();
        DataSet oDS = new DataSet();
        oDS = _RptWarehouseWiseStockReportDetails.ToDataSet();
        string sExpr = "";
        
        sExpr = "ProductName like '%" + txtName.Text.Trim() + "%'";

        if ((txtName.Text) != "")
        {
            sExpr = sExpr + " and CustomerName like '%" + txtName.Text.Trim() + "%'";
        }
        if ((txtCode.Text) != "")
        {
            sExpr = sExpr + " and ProductCode = '" + txtCode.Text + "'";
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
        if (int.Parse(cmbActive.SelectedValue) != -1)
        {
            sExpr = sExpr + " and IsActive = '" + cmbActive.SelectedValue + "'";
        }      


        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _RptWarehouseWiseStockReportDetails.FromDataSetWarehouseWiseStockReport(_oDS);
        else _RptWarehouseWiseStockReportDetails = null;

        if (_RptWarehouseWiseStockReportDetails != null)
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
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCrosstabWarehouseLogisticsStock));

        doc.SetDataSource(_RptWarehouseWiseStockReportDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);        
        doc.SetParameterValue("PG", cmbProductType.SelectedItem.Text);
        doc.SetParameterValue("MAG", cmbMAG.SelectedItem.Text);
        doc.SetParameterValue("ASG", cmbASG.SelectedItem.Text);
        doc.SetParameterValue("AG", cmbAG.SelectedItem.Text);
        doc.SetParameterValue("Brand", cmbBrand.SelectedItem.Text);
        doc.SetParameterValue("Date", _dStartingDate.AddDays(-1));        
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("ReportName", "Warehouse wise Logistics Stock Report [293]");
        Session["ReportName"] = "Warehouse wise Logistics Stock Report [293]";
        //Session["ReportName"] = "Warehouse wise Logistics Stock Report [293]";
        //Session.Add("ReportName", "Warehouse wise Logistics Stock Report [293]");
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

    }
}

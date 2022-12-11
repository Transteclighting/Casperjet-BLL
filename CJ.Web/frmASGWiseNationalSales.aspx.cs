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

public partial class frmASGWiseNationalSales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllCombo();
        }
       
    }    

    private void LoadAllCombo()
    {
        RptASWWiseNationalSales oRptASWWiseNationalSales = new RptASWWiseNationalSales();

        cbBrandName.Items.Clear();
        DBController.Instance.OpenNewConnection();
        oRptASWWiseNationalSales.GetDataBrandName();

        foreach (RptASWWiseNational oBrand in oRptASWWiseNationalSales)
        {
            cbBrandName.Items.Add(oBrand.BrandName);           

        }

        CbASGName.Items.Clear();
        DBController.Instance.OpenNewConnection();
        oRptASWWiseNationalSales.GetDataASGName();

        foreach (RptASWWiseNational oBrand in oRptASWWiseNationalSales)        {
            
        CbASGName.Items.Add(oBrand.ASGName);

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        rptASGWiseNatioalSales orptASGWiseNatioalSales = new rptASGWiseNatioalSales();
        orptASGWiseNatioalSales.GetASWWiseNationalSale( cbBrandName.Text);
        rptASGWiseNationalSales oReport = new rptASGWiseNationalSales();
        oReport.SetDataSource(orptASGWiseNatioalSales);

        Session["Doc"] = (object)oReport;
        Response.Redirect("frmASGWiseNationalSalesReportViewer.aspx");
        

    }
    protected void cbBrandName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

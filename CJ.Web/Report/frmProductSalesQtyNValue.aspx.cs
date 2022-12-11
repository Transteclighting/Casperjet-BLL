/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Dipak Kumar Chakraborty
/// Date: March 19, 2012
/// Time : 12:00 PM
/// Description:ProductSalesQuantityNValueReport[146]
/// Modify Person And Date:
/// </summary>

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

public partial class Report_frmProductSalesQtyNValue : System.Web.UI.Page
{
    Utilities _oUtilities;
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    RptProductWiseSalesQtyNValueDetails _RptProductWiseSalesQtyNValueDetails;
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


        _oUtilities = new Utilities();
        _oUtilities.GetSupplyType();
        cmbSupply.DataTextField = "Satus";
        cmbSupply.DataValueField = "SatusId";
        cmbSupply.DataSource = _oUtilities;
        cmbSupply.DataBind();
        cmbSupply.SelectedIndex = _oUtilities.Count - 1;
        Session.Add("Utilities", _oUtilities);

        
    }
    
    protected void lnkShowReportB_Click(object sender, EventArgs e)
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

        _RptProductWiseSalesQtyNValueDetails = new RptProductWiseSalesQtyNValueDetails();
        DBController.Instance.OpenNewConnection();

        if (this.rdoVATAmount.Checked)
        {
            _RptProductWiseSalesQtyNValueDetails.ProductSalNValueVATAmount(_dStartingDate, _dEndingDate);
        
        }
                
        if (this.rdoDateRange.Checked )
        {
             _RptProductWiseSalesQtyNValueDetails.ProductWiseSalesQtyNValue(_dStartingDate, _dEndingDate);
        
        }

        else if (this.rdoVATChallanRange.Checked)
        {
            if (txtFromVATChallanNo.Text != "" && txtToVATChallanNo.Text != "")
            {
            _RptProductWiseSalesQtyNValueDetails.ProductSalNValueVATChallan(_dStartingDate, _dEndingDate, txtFromVATChallanNo.Text, txtToVATChallanNo.Text);
            }

            else _RptProductWiseSalesQtyNValueDetails.ProductWiseSalesQtyNValue(_dStartingDate, _dEndingDate);
        }
                
        DBController.Instance.CloseConnection();
        DataSet oDS = new DataSet();
        oDS = _RptProductWiseSalesQtyNValueDetails.ToDataSet();

        string sExpr;
        lblMessage.Visible = true;

        sExpr = "ProductName like '%" + txtPName.Text.Trim() + "%'";

        if (txtPCode.Text.Trim() != "")
        {
            sExpr = sExpr + " and ProductCode = '" + txtPCode.Text.Trim() + "'";
        }
        if (int.Parse( cmbProductType.SelectedValue )!= -1)
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

        if (int.Parse(cmbSupply.SelectedValue) != -1)
        {
            sExpr = sExpr + " and SupplyType = '" + cmbSupply.SelectedValue + "'";
        }

        if (cmbVatApplicable.SelectedValue != "ALL")
        {
            sExpr = sExpr + " and VatApplicable = '" + cmbVatApplicable.SelectedValue + "'";
        }

        if (rdoVATAmount.Checked == true)
        {
            if (Convert.ToDouble(cmbActive.SelectedValue.ToString()) != 2)
            {
                sExpr = sExpr + " and VatAmount = '" + cmbActive.SelectedValue + "'";
            }
        }    

        
        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _RptProductWiseSalesQtyNValueDetails.FromDataSetProductWiseSalesQtyNValue(_oDS);
        else _RptProductWiseSalesQtyNValueDetails = null;

        if (_RptProductWiseSalesQtyNValueDetails != null)
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
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptProductSalesQtyNValue));

        doc.SetDataSource(_RptProductWiseSalesQtyNValueDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("PG", cmbProductType.SelectedItem.Text);
        doc.SetParameterValue("MAG", cmbMAG.SelectedItem.Text);
        doc.SetParameterValue("ASG", cmbASG.SelectedItem.Text);
        doc.SetParameterValue("AG", cmbAG.SelectedItem.Text);
        doc.SetParameterValue("Brand", cmbBrand.SelectedItem.Text);
        doc.SetParameterValue("SupplyType", cmbSupply.SelectedItem.Text);
        doc.SetParameterValue("VatApplicable", cmbVatApplicable.SelectedItem.Text);        
        doc.SetParameterValue("StDate", _dStartingDate);
        doc.SetParameterValue("EndDate", _dEndingDate);
        doc.SetParameterValue("ReportName", "Product Wise Sales Quantity and Value [146]");
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

    }
}

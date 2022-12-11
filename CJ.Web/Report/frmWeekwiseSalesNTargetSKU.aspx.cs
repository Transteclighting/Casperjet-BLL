using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
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

public partial class Report_frmWeekwiseSalesNTargetSKU : System.Web.UI.Page
{
    DateTime _dStartingDate = new DateTime();
    DateTime _dEndingDate = new DateTime();
    RptWeekwiseSalesNationaldetails _RptWeekwiseSalesNationaldetails;

    protected void Page_Load(object sender, EventArgs e)
    {

        DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {
            LoadAllCombo();
            cmbStDay.Text = DateTime.Today.Date.Day.ToString();
            cmbStMonth.Text = DateTime.Today.Date.Month.ToString();
            cmbStYear.Text = DateTime.Today.Date.Year.ToString();

            cmbEndDay.Text = DateTime.Today.Date.Day.ToString();
            cmbEndMonth.Text = DateTime.Today.Date.Month.ToString();
            cmbEndYear.Text = DateTime.Today.Date.Year.ToString();
        }
        DBController.Instance.CloseConnection();

    }

    public void LoadAllCombo()
    {
        DBController.Instance.OpenNewConnection();

        User oUser = (User)Session["User"];

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

        _RptWeekwiseSalesNationaldetails = new RptWeekwiseSalesNationaldetails();
        DBController.Instance.OpenNewConnection();

        _RptWeekwiseSalesNationaldetails.WeekwiseSalesNational(_dStartingDate, _dEndingDate);

        DBController.Instance.CloseConnection();
        DataSet oDS = new DataSet();
        oDS = _RptWeekwiseSalesNationaldetails.ToDataSet();

        string sExpr;
        lblMessage.Visible = true;

        sExpr = "";

        if (int.Parse(cmbASG.SelectedValue) != -1)
        {
            sExpr = sExpr + " ASGID = '" + cmbASG.SelectedValue + "'";
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
            _RptWeekwiseSalesNationaldetails.FromDataSetWeekwiseSales(_oDS);
        else _RptWeekwiseSalesNationaldetails = null;

        if (_RptWeekwiseSalesNationaldetails != null)
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
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(WeekwiseSalesNational));

        doc.SetDataSource(_RptWeekwiseSalesNationaldetails);
        doc.SetParameterValue("CompanyName", sCompanyName);        
        doc.SetParameterValue("ASG", cmbASG.SelectedItem.Text);        
        doc.SetParameterValue("Brand", cmbBrand.SelectedItem.Text);       
        doc.SetParameterValue("StDate", _dStartingDate);
        doc.SetParameterValue("EndDate", _dEndingDate);
        doc.SetParameterValue("ReportName", "Week wise Daily Sales Report SKU wise [66] ");
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");
    }  
}

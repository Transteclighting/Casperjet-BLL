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

public partial class Report_frmDayWiseVAT : System.Web.UI.Page
{
    private VATReportsDetails _oVATReportsDetails;
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;  

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cmbStDay.Text = DateTime.Today.Day.ToString();
            cmbStMonth.Text = DateTime.Today.Month.ToString();
            cmbStYear.Text = DateTime.Today.Year.ToString();

            cmbStDay1.Text = DateTime.Today.Day.ToString();
            cmbStMonth1.Text = DateTime.Today.Month.ToString();
            cmbStYear1.Text = DateTime.Today.Year.ToString();

        }

    }

    protected void lnkShowReportB_Click(object sender, EventArgs e)
    {
        
        _oVATReportsDetails = new VATReportsDetails();

        if (cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0" && cmbStDay.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
        }
        else
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please select valid date ";
            return;

        }
        if (cmbStMonth1.SelectedValue != "0" && cmbStYear1.SelectedValue != "0" && cmbStDay1.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cmbStYear1.SelectedValue), int.Parse(cmbStMonth1.SelectedValue), int.Parse(cmbStDay1.SelectedValue));
        }
        else
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please select valid date ";
            return;

        }

        if (this.rdoSalesVat.Checked)
        {
            GetDayWiseVAT();
            fillReport();
        }

        else if (this.rdoItemwise.Checked)
        {
            GetItemwiseVAT();
            fillReportItemwise();
        }

        else if (this.rdoTotal.Checked)
        {
            GetTotalVAT();
            fillReportTotal();
        }

        else if (this.rdoComparison.Checked)
        {
            GetVATComparison();
            fillReportComparison();
 
        }

    }

    private void GetDayWiseVAT()
    {
        //Day Starting and Ending Date
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate;

        _oVATReportsDetails = new VATReportsDetails();

        try
        {
            DBController.Instance.OpenNewConnection();
            _oVATReportsDetails.VATReports(_dStartingDate, _dEndingDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: Error in Purchase register =" + ex);
        }

    }

    private void fillReport()
    {
        string sCompanyName = Utility.CompanyName;

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesVatDayWise));
        doc.SetDataSource(_oVATReportsDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("StDay", _dStartingDate);
        doc.SetParameterValue("EndDay", _dEndingDate);
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

    }

    private void GetItemwiseVAT()
    {
        //Day Starting and Ending Date
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate;

        _oVATReportsDetails = new VATReportsDetails();

        try
        {
            DBController.Instance.OpenNewConnection();
            _oVATReportsDetails.VATItem(_dStartingDate, _dEndingDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: Error in Purchase register =" + ex);
        }
 
    }

    private void fillReportItemwise()
    {
        string sCompanyName = Utility.CompanyName;

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptItemWiseVAT));
        doc.SetDataSource(_oVATReportsDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("StDay", _dStartingDate);
        doc.SetParameterValue("EndDay", _dEndingDate);
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");
 
    }

    private void GetTotalVAT()
    {
        //Day Starting and Ending Date
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate;

        _oVATReportsDetails = new VATReportsDetails();

        try
        {
            DBController.Instance.OpenNewConnection();
            _oVATReportsDetails.VATTotal(_dStartingDate, _dEndingDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: Error in Purchase register =" + ex);
        }
 
    }

    private void fillReportTotal()
    {
        string sCompanyName = Utility.CompanyName;

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptTotalVAT));
        doc.SetDataSource(_oVATReportsDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("StDay", _dStartingDate);
        doc.SetParameterValue("EndDay", _dEndingDate);
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");
 
    }

    private void GetVATComparison()
    {
        //Day Starting and Ending Date
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate;

        _oVATReportsDetails = new VATReportsDetails();

        try
        {
            DBController.Instance.OpenNewConnection();
            _oVATReportsDetails.VATComparison(_dStartingDate, _dEndingDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: Error in Purchase register =" + ex);
        }
 
    }
    private void fillReportComparison()
    {
        string sCompanyName = Utility.CompanyName;

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVATComparison));
        doc.SetDataSource(_oVATReportsDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("StDay", _dStartingDate);
        doc.SetParameterValue("EndDay", _dEndingDate);
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");
 
    }
    protected void rdoSalesVat_CheckedChanged(object sender, EventArgs e)
    {
        rdoSalesVat.Checked = true;
        rdoItemwise.Checked = false;
        rdoTotal.Checked = false;
        rdoComparison.Checked = false;
    }
    protected void rdoItemwise_CheckedChanged(object sender, EventArgs e)
    {
        rdoSalesVat.Checked = false;
        rdoItemwise.Checked = true;
        rdoTotal.Checked = false;
        rdoComparison.Checked = false;
    }
    protected void rdoTotal_CheckedChanged(object sender, EventArgs e)
    {
        rdoSalesVat.Checked = false;
        rdoItemwise.Checked = false;
        rdoTotal.Checked = true;
        rdoComparison.Checked = false;
    }
    protected void rdoComparison_CheckedChanged(object sender, EventArgs e)
    {
        rdoSalesVat.Checked = false;
        rdoItemwise.Checked = false;
        rdoTotal.Checked = false;
        rdoComparison.Checked = true;
    }
}

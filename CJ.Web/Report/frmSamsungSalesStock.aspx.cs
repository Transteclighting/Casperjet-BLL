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
using CJ.Report.SamsungReport;

public partial class Report_frmSamsungSalesStock : System.Web.UI.Page
{
    Customer _oCustomer;
    Customers _oCustomers;
    DateTime _dStartingDate;
    DateTime _dEndingDate;
    rptSamsungSalesStocks _orptSamsungSalesStock;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            DBController.Instance.OpenNewConnection();
            if (!IsPostBack)
            {

                cboStDay.Text = "1";
                cboStMonth.Text = DateTime.Today.Month.ToString();
                cboStYear.Text = DateTime.Today.Year.ToString();

                cboEndDay.Text = DateTime.Today.Day.ToString();
                cboEndMonth.Text = DateTime.Today.Month.ToString();
                cboEndYear.Text = DateTime.Today.Year.ToString();

                LoadAllCombo();
            }
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Load All Combo (ASG Wise) =" + ex);
        }
    }

    public void LoadAllCombo()
    {
        DBController.Instance.OpenNewConnection();

        //User oUser = (User)Session["User"];

        ProductGroups oASG = new ProductGroups();
        oASG.GETASG();
        cmbASG.DataTextField = "PdtGroupName";
        cmbASG.DataValueField = "PdtGroupId";
        cmbASG.DataSource = oASG;
        cmbASG.DataBind();
        cmbASG.SelectedIndex = oASG.Count - 1;

        _oCustomers = new Customers();
        _oCustomers.GetTDOutletAll();
        cmbOutlet.DataTextField = "CustomerName";
        cmbOutlet.DataValueField = "CustomerID";
        cmbOutlet.DataSource = _oCustomers;
        cmbOutlet.DataBind();
        cmbOutlet.SelectedIndex = _oCustomers.Count - 1;


    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        this.lblFromDateError.Visible = false;
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
        if (cboStMonth.SelectedValue != "0" && cboStYear.SelectedValue != "0" && cboStDay.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cboEndYear.SelectedValue), int.Parse(cboEndMonth.SelectedValue), int.Parse(cboEndDay.SelectedValue));
        }
        else
        {
            this.lblFromDateError.Visible = true;
            this.lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }

        GetSamsungSalesStock();
        if (_orptSamsungSalesStock != null)
        {
            fillReport(_dStartingDate, _dEndingDate);
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Data";
        }
    }

    private void GetSamsungSalesStock()
    {
        try
        {
            DBController.Instance.OpenNewConnection();
            _orptSamsungSalesStock = new rptSamsungSalesStocks();
            _orptSamsungSalesStock.Refresh(_dStartingDate, _dEndingDate, cmbOutlet.SelectedValue, cmbASG.SelectedValue, txtProductCode.Text,txtName.Text);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  Product Performance Report (SKU Wise) =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = _orptSamsungSalesStock.ToDataSet();

        string sExpr = "";

        //if (txtName.Text.Trim() != "")
        //{
        //    sExpr = sExpr + " and ProductName like '%" + txtName.Text.Trim() + "%'";
        //}
        //if (txtProductCode.Text.Trim() != "")
        //{
        //    sExpr = sExpr + " and ProductCode = '" + txtProductCode.Text.Trim() + "'";
        //}

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _orptSamsungSalesStock.FromDataSetSamsungProductSalesStock(_oDS);

        else _orptSamsungSalesStock = null;
    }

    private void fillReport(DateTime dFromDate, DateTime dToDate)
    {
        string sCompanyName = Utility.CompanyName;
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSamsungProductSalesOutletWise));

        doc.SetDataSource(_orptSamsungSalesStock);
        doc.SetParameterValue("CompanyName", sCompanyName);
        
        doc.SetParameterValue("ASG", cmbASG.SelectedItem.Text);
        doc.SetParameterValue("Outlet", cmbOutlet.SelectedItem.Text);
        doc.SetParameterValue("FromDate", dFromDate);
        doc.SetParameterValue("ToDate", dToDate);


        if (txtProductCode.Text.Trim() != "")
        {
            doc.SetParameterValue("ProductCode", txtProductCode.Text);
        }
        else
        {
            doc.SetParameterValue("ProductCode", "ALL");
        }
        if (txtName.Text.Trim() != "")
        {
            doc.SetParameterValue("ProductName", txtName.Text);
        }
        else
        {
            doc.SetParameterValue("ProductName", "ALL");
        }
        _dStartingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
        _dEndingDate = new DateTime(int.Parse(cboEndYear.SelectedValue), int.Parse(cboEndMonth.SelectedValue), int.Parse(cboEndDay.SelectedValue));

        /* doc.SetParameterValue("StDate", _dStartingDate);
         doc.SetParameterValue("EndDate", _dEndingDate);
        
         doc.SetParameterValue("Report_Name", Table1.Rows[0].Cells[0].InnerText.Trim());*/
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;

        Response.Redirect("~/Report/frmReportViewer.aspx");
    }
}

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

public partial class Report_frmInvoiceRegisterERP : System.Web.UI.Page
{
    DateTime _dStartingDate = new DateTime();
    DateTime _dEndDate = new DateTime();
    rptInvoiceRegisterERPReport orptInvoiceRegisterERPReport;
    string _DataRange = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        lblFrom.Text = "Invoice From";
        lblTo.Text = "Invoice To";

        lblCustomerCode.Visible = false;
        txtFromInvoiceID.Visible = true;
        txtToInvoiceID.Visible = true;

        cboStDay.Visible = false;
        cboStMonth.Visible = false;
        cboStYear.Visible = false;

        cboEndDay.Visible = false;
        cboEndMonth.Visible = false;
        cboEndYear.Visible = false;

        txtCustomerCode.Visible = false;
    }
   
    protected void lnkShowReportB_Click(object sender, EventArgs e)
    {
        int nInvoiceSearchType=Convert.ToInt32(cmbInvoiceSearchType.SelectedValue);

        if ( nInvoiceSearchType== Convert.ToInt32(Dictionary.InvoiceSelectionCriteria.BEWEEN_INVOICE_ID))
        {
            long FromInvoiceID=0;
            long ToInvoiceID=0;
            try
            {
                FromInvoiceID=Convert.ToInt64(txtFromInvoiceID.Text.Trim());
               ToInvoiceID=Convert.ToInt64(txtToInvoiceID.Text.Trim());
            }
            catch
            {
                lblErrMessage.Visible = true;
                lblErrMessage.Text = "Place Check your input";
                return;

            }
            orptInvoiceRegisterERPReport = new rptInvoiceRegisterERPReport();
            DBController.Instance.OpenNewConnection();
            orptInvoiceRegisterERPReport.GetInvoiceRegisterERP(DateTime.Today, DateTime.Today, FromInvoiceID, ToInvoiceID, "", "", -1, nInvoiceSearchType);
            DBController.Instance.CloseConnection();
            _DataRange = "Invoice Details From Invoice ID " + txtFromInvoiceID.Text.Trim() + " To " + txtToInvoiceID.Text.Trim(); 
          
        }

        if (nInvoiceSearchType == Convert.ToInt32(Dictionary.InvoiceSelectionCriteria.BEWEEN_INVOICE_NO))
        {
            orptInvoiceRegisterERPReport = new rptInvoiceRegisterERPReport();
            DBController.Instance.OpenNewConnection();
            orptInvoiceRegisterERPReport.GetInvoiceRegisterERP(DateTime.Today, DateTime.Today, -1, -1, Convert.ToString(txtFromInvoiceID.Text.Trim()), Convert.ToString(txtToInvoiceID.Text.Trim()), -1, nInvoiceSearchType);
            DBController.Instance.CloseConnection();
            _DataRange = "Invoice Details From Invoice No. " + txtFromInvoiceID.Text.Trim() + " To " + txtToInvoiceID.Text.Trim(); 
        }
        if (nInvoiceSearchType == Convert.ToInt32(Dictionary.InvoiceSelectionCriteria.Between_Date))
        {
            if (getDate())
            {
                orptInvoiceRegisterERPReport = new rptInvoiceRegisterERPReport();
                DBController.Instance.OpenNewConnection();
                orptInvoiceRegisterERPReport.GetInvoiceRegisterERP(_dStartingDate, _dEndDate, -1, -1, "", "", -1, nInvoiceSearchType);
                DBController.Instance.CloseConnection();
                _DataRange = "Invoice Details From Invoice Date " + _dStartingDate.ToShortDateString() + " To " + _dEndDate.ToShortDateString(); 
            }
            else
            {
                lblFromDateError.Visible = true;
                lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
                return;
            }
        }
        if (nInvoiceSearchType == Convert.ToInt32(Dictionary.InvoiceSelectionCriteria.BY_CUSTOMER_ID))
        {
            long CustomerID = 0;
          
            try
            {
                CustomerID = Convert.ToInt64(txtCustomerCode.Text.Trim());
               
            }
            catch
            {
                lblErrMessage.Visible = true;
                lblErrMessage.Text = "Place Check your input";
                return;

            }
            if (getDate())
            {
                orptInvoiceRegisterERPReport = new rptInvoiceRegisterERPReport();
                DBController.Instance.OpenNewConnection();
                orptInvoiceRegisterERPReport.GetInvoiceRegisterERP(_dStartingDate, _dEndDate, -1, -1, "", "", CustomerID, nInvoiceSearchType);
                DBController.Instance.CloseConnection();
                _DataRange = "Invoice Details List for Customer Code: " + txtCustomerCode.Text.Trim() + " Date From " + _dStartingDate.ToShortDateString() + " To " + _dEndDate.ToShortDateString();
            }
            else
            {
                lblFromDateError.Visible = true;
                lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
                return;
            }
        }
        if (orptInvoiceRegisterERPReport != null)
        {
            Int64 nInvoiceID = 0;
            double nTotalDiscount = 0;
            double nOtherCharge = 0;
            foreach (rptInvoiceRegisterERP orptInvoiceRegisterERP in orptInvoiceRegisterERPReport)
            {
                if (orptInvoiceRegisterERP.InvoiceID != nInvoiceID)
                {
                    nTotalDiscount = nTotalDiscount + orptInvoiceRegisterERP.Discount;
                    nOtherCharge = nOtherCharge + orptInvoiceRegisterERP.OtherCharge;
                    nInvoiceID = orptInvoiceRegisterERP.InvoiceID;
                }
            }

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptInvoiceRegistorDetailERP));
            doc.SetDataSource(orptInvoiceRegisterERPReport);

            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("GrandDiscount", Math.Abs(nTotalDiscount));
            doc.SetParameterValue("OtherCharge", Math.Abs(nOtherCharge));
            //doc.SetParameterValue("fromInvoiceID", Convert.ToInt64(txtFromInvoiceID.Text.Trim()));
            //doc.SetParameterValue("ToInvoiceID", Convert.ToInt64(txtToInvoiceID.Text.Trim()));
            doc.SetParameterValue("DataRange", _DataRange);
            doc.SetParameterValue("EntryBy", Context.User.Identity.Name);

            doc.SetParameterValue("Report_Name", Table2.Rows[0].Cells[0].InnerText.Trim());
            Session["ReportName"] = Table2.Rows[0].Cells[0].InnerText.Trim();
            Session["Doc"] = (object)doc;
            Response.Redirect("frmReportViewer.aspx");
        }

    }
    private bool getDate()
    {
        if (cboStDay.SelectedValue != "0" && cboStMonth.SelectedValue != "0" && cboStYear.SelectedValue != "0")
        {
            try
            {
                _dStartingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
            }
            catch
            {
                lblFromDateError.Visible = true;
                lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
                return false;
            }
        }
        else
        {
            lblFromDateError.Visible = true;
            lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return false;
        }
        if (cboEndDay.SelectedValue != "0" && cboEndMonth.SelectedValue != "0" && cboEndYear.SelectedValue != "0")
        {
            try
            {
                _dEndDate = new DateTime(int.Parse(cboEndYear.SelectedValue), int.Parse(cboEndMonth.SelectedValue), int.Parse(cboEndDay.SelectedValue));
            }
            catch
            {
                lblToDateError.Visible = true;
                lblToDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
                return false;
            }
        }
        else
        {
            lblToDateError.Visible = true;
            lblToDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return false;
        }
        return true;
    }
    protected void cmbInvoiceSearchType_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (Convert.ToInt32(cmbInvoiceSearchType.SelectedValue) == Convert.ToInt32(Dictionary.InvoiceSelectionCriteria.Between_Date))
        {

            cboStDay.Text = DateTime.Today.Date.Day.ToString();
            cboStMonth.Text = DateTime.Today.Date.Month.ToString();
            cboStYear.Text = DateTime.Today.Date.Year.ToString();

            cboEndDay.Text = DateTime.Today.Date.Day.ToString();
            cboEndMonth.Text = DateTime.Today.Date.Month.ToString();
            cboEndYear.Text = DateTime.Today.Date.Year.ToString();

            lblFrom.Text = "Date From";
            lblTo.Text = "Date To";
            lblTo.Visible = true;
            lblFrom.Visible = true;
            lblCustomerCode.Visible = false;

            txtFromInvoiceID.Visible = false;
            txtToInvoiceID.Visible = false;
            txtCustomerCode.Visible = false;

            cboStDay.Visible = true;
            cboStMonth.Visible = true;
            cboStYear.Visible = true;

            cboEndDay.Visible = true;
            cboEndMonth.Visible = true;
            cboEndYear.Visible = true;
        }
        else if (Convert.ToInt32(cmbInvoiceSearchType.SelectedValue) == Convert.ToInt32(Dictionary.InvoiceSelectionCriteria.BY_CUSTOMER_ID))
        {
            cboStDay.Text = DateTime.Today.Date.Day.ToString();
            cboStMonth.Text = DateTime.Today.Date.Month.ToString();
            cboStYear.Text = DateTime.Today.Date.Year.ToString();

            cboEndDay.Text = DateTime.Today.Date.Day.ToString();
            cboEndMonth.Text = DateTime.Today.Date.Month.ToString();
            cboEndYear.Text = DateTime.Today.Date.Year.ToString();

            lblFrom.Visible = true;
            lblTo.Visible = true;
            lblCustomerCode.Visible = true;
            lblCustomerCode.Text = "Customer Code";

            txtCustomerCode.Visible = true;
            txtFromInvoiceID.Visible = false;
            txtToInvoiceID.Visible = false;

            cboStDay.Visible = true;
            cboStMonth.Visible = true;
            cboStYear.Visible = true;

            cboEndDay.Visible = true;
            cboEndMonth.Visible = true;
            cboEndYear.Visible = true;
        }
        else
        {
            lblFrom.Text = "Invoice From";
            lblTo.Text = "Invocie To";
            lblTo.Visible = true;
            lblFrom.Visible = true;
            lblCustomerCode.Visible = false;

            txtFromInvoiceID.Visible = true;
            txtToInvoiceID.Visible = true;

            txtCustomerCode.Visible = false;
            cboStDay.Visible = false;
            cboStMonth.Visible = false;
            cboStYear.Visible = false;

            cboEndDay.Visible = false;
            cboEndMonth.Visible = false;
            cboEndYear.Visible = false;
        }

    }
}

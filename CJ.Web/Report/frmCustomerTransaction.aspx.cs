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

public partial class Report_frmCustomerTransaction : System.Web.UI.Page
{
    private CustomerTransactionLedgerDetails _oCustomerTransactionLedgerDetails;
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    Customer _oCustomer;
    CustomerDetail _oCustomerDetail;
    double _ClosingOS = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            cboStDay.Text = DateTime.Today.Day.ToString();
            cboStMonth.Text = DateTime.Today.Month.ToString();
            cboStYear.Text = DateTime.Today.Year.ToString();

            cboStDay1.Text = DateTime.Today.Day.ToString();
            cboStMonth1.Text = DateTime.Today.Month.ToString();
            cboStYear1.Text = DateTime.Today.Year.ToString();

        }


    }
    protected void lnkShowReportB_Click(object sender, EventArgs e)
    {
        CustomerDetail oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];

        if (oCustomerDetail == null)
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please select a customer";
            return;

        }
        if (cboStMonth.SelectedValue != "0" && cboStYear.SelectedValue != "0" && cboStDay.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
        }
        else
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please select valid date ";
            return;

        }
        if (cboStMonth1.SelectedValue != "0" && cboStYear1.SelectedValue != "0" && cboStDay1.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cboStYear1.SelectedValue), int.Parse(cboStMonth1.SelectedValue), int.Parse(cboStDay1.SelectedValue));
        }
        else
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please select valid date ";
            return;

        }

        getCustomerTransectionLedger();
        fillReport();

    }

    private void getCustomerTransectionLedger()
    {

        //Day Starting and Ending Date
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate.AddDays(1);
        //Channels _oChanneles = (Channels)Session["Channeles"];
        CustomerDetail oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];

        _oCustomerTransactionLedgerDetails = new CustomerTransactionLedgerDetails();

        try
        {
            DBController.Instance.OpenNewConnection();
            bool IsMainReport = false;
            if (CheckBox1.Checked == false)
            {
                IsMainReport = true;
            }
            else
            {
                IsMainReport = false;
            }
            _ClosingOS = _oCustomerTransactionLedgerDetails.CustomerTransection(_dStartingDate, _dEndingDate, oCustomerDetail.CustomerID, IsMainReport);
            _oCustomerTransactionLedgerDetails.GetCustomerTransection();
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: Error in Customer Transaction Ledger =" + ex);
        }

    }
    private void fillReport()
    {
        string sCompanyName = Utility.CompanyName;

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCustomerTransactionLedger));

        doc.SetDataSource(_oCustomerTransactionLedgerDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("StDay", _dStartingDate);
        doc.SetParameterValue("EndDay", _dEndingDate);
        doc.SetParameterValue("ClosingOS", _ClosingOS);

        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        if (CheckBox1.Checked == false)
        {
            doc.SetParameterValue("ReportDesc", "Customer Transection Ledge [800]");
        }
        else
        {
            doc.SetParameterValue("ReportDesc", "Customer Transection Ledge (With Credit Approval Transaction) [800]");
        }

        
        Session["Doc"] = (object)doc;

        Response.Redirect("frmReportViewer.aspx");

    }
    protected void cboStDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();

        _oCustomer = new Customer();
        _oCustomer.CustomerCode = txtCustomerCode.Text;
        _oCustomer.GetCustomerID();
        Session.Add("Customer", _oCustomer);

    }
    protected void txtCustomerCode_TextChanged(object sender, EventArgs e)
    {
        btGo_Click(null, null);
    }
    protected void btGo_Click(object sender, EventArgs e)
    {
        if (txtCustomerCode.Text != "")
        {
            lbMsg.Visible = false;
            DBController.Instance.OpenNewConnection();
            _oCustomer = new Customer();
            _oCustomer.CustomerCode = txtCustomerCode.Text;
            _oCustomer.GetCustomerID();
            if (_oCustomer.Flag == false)
            {
                lbMsg.Visible = true;
                lbMsg.Text = "Please Input Valid Customer Code";
                return;
            }
            _oCustomerDetail = new CustomerDetail();
            _oCustomerDetail.CustomerID = _oCustomer.CustomerID;
            _oCustomerDetail.refresh();

            txtCustomerName.Text = _oCustomerDetail.CustomerName;
            Session.Add("CustomerDetail", _oCustomerDetail);

            DBController.Instance.CloseConnection();
        }
    }

    
}

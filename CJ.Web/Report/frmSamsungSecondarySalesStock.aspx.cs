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

public partial class Report_frmSamsungSecondarySalesStock : System.Web.UI.Page
{
    Customers _oCustomers;
    Customer oCustomer;
    FFSalesPerson _oFFSalesPerson;
    ProductDetails _oProductDetails;
    ProductGroups _oMAG;
    //rptTDSalesPlans _orptTDSalesPlans;
    SamsungSecondarySalesStocks _oSamsungSecondarySalesStocks;
    DateTime _dStartingDate;
    DateTime _dEndingDate;
    //DateTime _dStartingDate;

    Utility _oUtility;

    protected void Page_Load(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {

            cboStDay.Text = DateTime.Today.Day.ToString();
            cboStMonth.Text = DateTime.Today.Month.ToString();
            cboStYear.Text = DateTime.Today.Year.ToString();

            cboEndDay.Text = DateTime.Today.Day.ToString();
            cboEndMonth.Text = DateTime.Today.Month.ToString();
            cboEndYear.Text = DateTime.Today.Year.ToString();


            LoadAllCombo();
        }
    }
    
    public void LoadAllCombo()
    {
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();

        
        ProductDetails _oASG = new ProductDetails();
        _oASG.GetASGAll();

        int ASGID = Convert.ToInt32(cmbASG.SelectedIndex);
        ProductDetails _oAG = new ProductDetails();
        _oAG.GetAGAll();

        DBController.Instance.CloseConnection();


        cmbASG.DataTextField = "ASGName";
        cmbASG.DataValueField = "ASGID";
        cmbASG.DataSource = _oASG;
        cmbASG.DataBind();
        cmbASG.SelectedIndex = _oASG.Count - 1;


        cmbAG.DataTextField = "AGName";
        cmbAG.DataValueField = "AGID";
        cmbAG.DataSource = _oAG;
        cmbAG.DataBind();
        cmbAG.SelectedIndex = _oAG.Count - 1;

    }

        protected void lnkShowReportB_Click(object sender, EventArgs e)
        {
            if (cboStMonth.SelectedValue != "0" && cboStYear.SelectedValue != "0" && cboStDay.SelectedValue!="0")
            {
                _dStartingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please select valid date ";
                return;
            }
            if (cboEndDay.SelectedValue != "0" && cboEndMonth.SelectedValue != "0" && cboEndYear.SelectedValue != "0")
            {
                _dEndingDate = new DateTime(int.Parse(cboEndYear.SelectedValue), int.Parse(cboEndMonth.SelectedValue), int.Parse(cboEndDay.SelectedValue));
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please select valid date ";
                return;
            }
        _oSamsungSecondarySalesStocks = new SamsungSecondarySalesStocks();
        DBController.Instance.OpenNewConnection();
        User oUser = (User)Session["User"];

        ProductDetails _oASG = new ProductDetails();
        _oASG.GetASGAll();
        ProductDetails _oAG = new ProductDetails();
        _oAG.GetAGAll();

        int nCustomer = 0;
        int nASGID = 0;
        int nAGID = 0;



        if (_oASG.Count > 0)
        {
            if (cmbASG.Text != "All")
            {
                nASGID = _oASG[cmbASG.SelectedIndex].ASGID;
            }
            else
            {
                nASGID = -1;
            }
        }

        if (_oAG.Count > 0)
        {
            if (cmbAG.Text != "All")
            {
                nAGID = _oAG[cmbAG.SelectedIndex].AGID;
            }
            else
            {
                nAGID = -1;
            }
        }

        _oSamsungSecondarySalesStocks.GetSecondarySalesStock(nCustomer,  nASGID, nAGID , txtPCode.Text, txtProductName.Text, _dStartingDate, _dEndingDate);

        DBController.Instance.CloseConnection();

        if (_oSamsungSecondarySalesStocks != null)
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
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSamsungSecondarySalesStock));

        doc.SetDataSource(_oSamsungSecondarySalesStocks);


        //doc.SetParameterValue("PGName", cmbProductGroup.Text);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("ASGName", cmbASG.SelectedItem.Text);
        doc.SetParameterValue("AGName", cmbAG.SelectedItem.Text);

        if (txtCustomerName.Text.Trim() != "")
        {
            doc.SetParameterValue("Customer", txtCustomerName.Text);
        }
        else
        {
            doc.SetParameterValue("Customer", "ALL");
        }

        if (txtPCode.Text.Trim() != "")
        {
            doc.SetParameterValue("ProductCode", txtPCode.Text);
        }
        else
        {
            doc.SetParameterValue("ProductCode", "ALL");
        }
        if (txtProductName.Text.Trim() != "")
        {
            doc.SetParameterValue("ProductName", txtProductName.Text);
        }
        else
        {
            doc.SetParameterValue("ProductName", "ALL");
        }

        doc.SetParameterValue("FromDate", _dStartingDate);
        doc.SetParameterValue("ToDate", _dEndingDate);

        doc.SetParameterValue("DateTime", DateTime.Now);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        //doc.SetParameterValue("Report_Name", Table1.Rows[0].Cells[0].InnerText.Trim());
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

    }
}

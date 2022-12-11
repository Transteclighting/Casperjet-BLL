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

public partial class Report_PurchaseRegisterM16 : System.Web.UI.Page
{
    private PurchaseRegisterDetails _oPurchaseRegisterDetails;
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

        //ProductDetail oProductDetail = (ProductDetail)Session["ProductDetail"];

        //if (oProductDetail == null)
        //{
        //    lbMsg.Visible = true;
        //    lbMsg.Text = "Please Select a customer";
        //    return;
        //}
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
        GetproductpurchaseRegister();
        fillReport();

    }

    private void GetproductpurchaseRegister()
    {
        //Day Starting and Ending Date
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate;


        ProductDetail oProductDetail = (ProductDetail)Session["ProductDetail"];

        _oPurchaseRegisterDetails = new PurchaseRegisterDetails();

        try
        {
            DBController.Instance.OpenNewConnection();
            _oPurchaseRegisterDetails.PurchaseRegister(_dStartingDate, _dEndingDate, txtProductCode.Text);
            _oPurchaseRegisterDetails.GetPurchaseRegister();
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

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptPurchaseAccountsMusok16));
        doc.SetDataSource(_oPurchaseRegisterDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("StDay", _dStartingDate);
        doc.SetParameterValue("EndDay", _dEndingDate);
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

    }

    protected void btGo_Click(object sender, EventArgs e)
    {
        
    }    
    protected void btCustomerSearch_Click1(object sender, EventArgs e)
    {

    }
   
}

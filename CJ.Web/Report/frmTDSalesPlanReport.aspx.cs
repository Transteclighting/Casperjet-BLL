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

public partial class Report_frmTDSalesPlanReport : System.Web.UI.Page
{
    Customers _oCustomers;
    Customer oCustomer;
    FFSalesPerson _oFFSalesPerson;
    ProductDetails _oProductDetails;
    ProductGroups _oMAG;
    rptTDSalesPlans _orptTDSalesPlans;
    DateTime _dStartingDate;

    Utility _oUtility;

    protected void Page_Load(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {

            cmbStMonth.Text = DateTime.Today.Month.ToString();
            cmbStYear.Text = DateTime.Today.Year.ToString();


            LoadAllCombo();
        }
    }

    public void LoadAllCombo()
    {
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);
        _oFFSalesPerson = new FFSalesPerson();
        _oFFSalesPerson.GetPlanEntryStageByUserID(oUser.UserId);

        int pgId = Convert.ToInt32(cmbMAG.SelectedIndex);
        ProductDetails _oASG = new ProductDetails();
        _oASG.GetASGAll();

        _oProductDetails = new ProductDetails();
        _oProductDetails.GetPGNameForSalesPlan();

        DBController.Instance.CloseConnection();


        if (_oCustomers.Count > 0)
        {
            cmbOutlet.DataSource = _oCustomers;
            cmbOutlet.DataTextField = "CustomerName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("FootFallCustomers", oCustomer);
        }
        else
        {
            oCustomer = new Customer();
            oCustomer.CustomerName = "No Permission";
            _oCustomers.Add(oCustomer);

            cmbOutlet.DataSource = _oCustomers;
            cmbOutlet.DataTextField = "CustomerName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("TDSalesPlans", oCustomer);
        }
        //Get PG

        cmbProductGroup.DataSource = _oProductDetails;
        cmbProductGroup.DataTextField = "PGName";
        cmbProductGroup.DataBind();
        cmbProductGroup.SelectedIndex = _oProductDetails.Count - 1;
        Session.Add("PG", _oProductDetails);



        int nPGID = 0;
        nPGID = _oProductDetails[cmbProductGroup.SelectedIndex].PGID;
        DBController.Instance.OpenNewConnection();
        ProductDetails _oPDs = new ProductDetails();
        _oPDs.GetMAGByPG();
        DBController.Instance.CloseConnection();


        cmbMAG.DataTextField = "MAGName";
        cmbMAG.DataValueField = "MAGID";
        cmbMAG.DataSource = _oPDs;
        cmbMAG.DataBind();
        cmbMAG.SelectedIndex = _oPDs.Count - 1;


        cmbASG.DataValueField = "ASGName";
        cmbASG.DataSource = _oASG;
        cmbASG.DataBind();
        cmbASG.SelectedIndex = _oASG.Count - 1;

    }
    protected void lnkShowReportB_Click(object sender, EventArgs e)
    {
        if (cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), 1);
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select valid date ";
            return;
        }
        _orptTDSalesPlans = new rptTDSalesPlans();
        DBController.Instance.OpenNewConnection();
        User oUser = (User)Session["User"];
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);

        ProductDetails _oASG = new ProductDetails();
        _oASG.GetASGAll();

        _oProductDetails = new ProductDetails();
        _oProductDetails.GetPGNameForSalesPlan();

        ProductDetails _oPDs = new ProductDetails();
        _oPDs.GetMAGByPG();


        int nCustomer =0;
        int nPGID = 0;
        int nMAGID = 0;
        int nASGID = 0;
        if (_oCustomers.Count > 0)
        {
            if (cmbOutlet.Text != "All")
            {
                nCustomer = _oCustomers[cmbOutlet.SelectedIndex].CustomerID;
            }
            else
            {
                nCustomer = -1;
            }
        }
        if (_oProductDetails.Count > 0)
        {
            if (cmbProductGroup.Text != "All")
            {
                nPGID = _oProductDetails[cmbProductGroup.SelectedIndex].PGID;
            }
            else
            {
                nPGID = -1;
            }
        }
        if (_oPDs.Count > 0)
        {
            if (cmbMAG.Text != "All")
            {
                nMAGID = _oPDs[cmbMAG.SelectedIndex].MAGID;
            }
            else
            {
                nMAGID = -1;
            }
        }
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

        _orptTDSalesPlans.GetTDSalesPlan(nCustomer, nPGID, nMAGID, nASGID, txtPCode.Text, txtProductName.Text, _dStartingDate);

        DBController.Instance.CloseConnection();

        if (_orptTDSalesPlans != null)
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
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesPlan));

        doc.SetDataSource(_orptTDSalesPlans);


        doc.SetParameterValue("PGName",cmbProductGroup.Text);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("MAGName", cmbMAG.SelectedItem.Text);
        doc.SetParameterValue("ASGName", cmbASG.SelectedItem.Text);
        doc.SetParameterValue("Outlet", cmbOutlet.SelectedItem.Text);

        doc.SetParameterValue("Month", cmbStMonth.SelectedItem.Text);
        doc.SetParameterValue("Year", cmbStYear.Text);

        doc.SetParameterValue("DateTime", DateTime.Now);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("Report_Name", Table1.Rows[0].Cells[0].InnerText.Trim());
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

    }
}

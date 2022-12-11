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

public partial class Report_frmFootFallSalesLeadReport : System.Web.UI.Page
{
    MarketGroups oMarketGroup;
    ProductDetails _oASG;
    Customers _oCustomers;
    Customer oCustomer;
    rptFootfallSalesLeads orptSalesReport;
    DateTime _dStartingDate;
    DateTime _dEndDate;
    Utility _oUtility;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCombo();
            cboFRDay.Text = DateTime.Today.Date.Day.ToString();
            cboFRMonth.Text = DateTime.Today.Date.Month.ToString();
            cboFRYear.Text = DateTime.Today.Date.Year.ToString();

            cboTODay.Text = DateTime.Today.Date.Day.ToString();
            cboTOMonth.Text = DateTime.Today.Date.Month.ToString();
            cboTOYear.Text = DateTime.Today.Date.Year.ToString();
        }
    }

    private void LoadCombo()
    {
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();

        /*Load Zone*/
        oMarketGroup = new MarketGroups();
        oMarketGroup.DMSGetTerritoryALl(311); //311 is used for filtering zone

        /*Load ASG*/
        _oASG = new ProductDetails();
        _oASG.GetASGAll();

        /*Load Outlet*/
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);

        DBController.Instance.CloseConnection();

        /* Load ASG */
        cmbASG.DataValueField = "ASGName";
        cmbASG.DataSource = _oASG;
        cmbASG.DataBind();
        cmbASG.SelectedIndex = _oASG.Count - 1;

        /*Load Zone*/
        cmbZone.DataValueField = "MarketGroupDesc";
        cmbZone.DataSource = oMarketGroup;
        cmbZone.DataBind();
        cmbZone.SelectedIndex = oMarketGroup.Count - 1;

        /*Load Outlet*/
        if (_oCustomers.Count > 0)
        {

            cmbOutlet.DataSource = _oCustomers;
            cmbOutlet.DataTextField = "CustomerName";
            cmbOutlet.DataBind();


            if (_oCustomers.Count > 1)
            {
                cmbOutlet.Items.Add("All");
            }
            cmbOutlet.SelectedIndex = _oCustomers.Count;
            Session.Add("FootFallSalesLead", oCustomer);
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
            Session.Add("FootFallSalesLeadReports", oCustomer);
        }

    }
    protected void lnkShowReportB_Click(object sender, EventArgs e)
    {

        if (cboFRDay.SelectedValue != "0" && cboFRMonth.SelectedValue != "0" && cboFRYear.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cboFRYear.SelectedValue), int.Parse(cboFRMonth.SelectedValue), int.Parse(cboFRDay.SelectedValue));
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select valid date ";
            return;
        }
        if (cboTODay.SelectedValue != "0" && cboTOMonth.SelectedValue != "0" && cboTOYear.SelectedValue != "0")
        {
            _dEndDate = new DateTime(int.Parse(cboTOYear.SelectedValue), int.Parse(cboTOMonth.SelectedValue), int.Parse(cboTODay.SelectedValue));
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select valid date ";
            return;
        }

        orptSalesReport = new rptFootfallSalesLeads();
        DBController.Instance.OpenNewConnection();
        _oASG = new ProductDetails();
        _oASG.GetASGAll();

        oMarketGroup = new MarketGroups();
        oMarketGroup.DMSGetTerritoryALl(311); //311 is used for select current zone

        User oUser = (User)Session["User"];
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);

        int nCustomer = 0;
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

        int nASGID = 0;
        if (_oASG.Count > 0)
        {
            if (cmbASG.Text != "ALL")
            {
                nASGID = _oASG[cmbASG.SelectedIndex].ASGID;
            }
            else
            {
                nASGID = -1;
            }
        }

        int nZoneID = 0;
        if (oMarketGroup.Count > 0)
        {
            if (cmbZone.Text != "ALL")
            {
                nZoneID = oMarketGroup[cmbZone.SelectedIndex].MarketGroupID;
            }
            else
            {
                nZoneID = -1;
            }
        }
        orptSalesReport.GetSalesLeadData(nZoneID, nCustomer, nASGID, _dStartingDate, _dEndDate, txtPCode.Text, txtProductName.Text);
        DBController.Instance.CloseConnection();

        if (orptSalesReport != null)
        {
            FillReport();
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = " No Data";
        }
    }

    private void FillReport()
    {
        string sCompanyName = Utility.CompanyName;
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptFootFallSalesLeadReport));
        doc.SetDataSource(orptSalesReport);

        doc.SetParameterValue("Company", sCompanyName);
        doc.SetParameterValue("Zone", cmbZone.SelectedItem.Text);
        doc.SetParameterValue("ASGName", cmbASG.SelectedItem.Text);
        doc.SetParameterValue("Outlet", cmbOutlet.SelectedItem.Text);
        doc.SetParameterValue("FromDate",_dStartingDate.ToString());
        doc.SetParameterValue("ToDate", _dEndDate.ToString());
        doc.SetParameterValue("ReportName", Table1.Rows[0].Cells[0].InnerText.Trim());
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");
    }
}
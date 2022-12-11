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

public partial class Report_frmFootFallReportSalesVSConv : System.Web.UI.Page
{
    ProductDetails _oASG;
    Customer oCustomer;
    Customers _oCustomers;
    DateTime _dStartingDate;
    FootFallReports orptFootFall;
    MarketGroups oMarketGroup;
    Utility _oUtility;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cmbStMonth.Text = DateTime.Today.Month.ToString();
            cmbStYear.Text = DateTime.Today.Year.ToString();
            LoadCombo();
        }

    }

    private void LoadCombo()
    {
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();

        /*Load Outlet*/
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);
        //_oCustomers.GetTDOutletAll();

        _oASG = new ProductDetails();
        _oASG.GetASGAll();

        oMarketGroup = new MarketGroups();
        oMarketGroup.DMSGetTerritoryALl(311);

        DBController.Instance.CloseConnection();

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
            Session.Add("FootFallReports", oCustomer);
        }


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

        orptFootFall = new FootFallReports();
        DBController.Instance.OpenNewConnection();
        _oASG = new ProductDetails();
        _oASG.GetASGAll();

        oMarketGroup = new MarketGroups();
        oMarketGroup.DMSGetTerritoryALl(311);

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
        //oMarketGroup = new MarketGroups();
        //oMarketGroup.DMSGetTerritoryBy(311);
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
        orptFootFall.GetFootFallData(nZoneID, nCustomer, nASGID, Convert.ToInt32(cmbStMonth.SelectedItem.Value), Convert.ToInt32(cmbStYear.SelectedItem.Value));
        DBController.Instance.CloseConnection();

        if (orptFootFall != null)
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
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptFootallSaleVSConv));

        doc.SetDataSource(orptFootFall);
        doc.SetParameterValue("Company", sCompanyName);
        doc.SetParameterValue("Zone", cmbZone.SelectedItem.Text);
        doc.SetParameterValue("ASGName", cmbASG.SelectedItem.Text);
        doc.SetParameterValue("Outlet", cmbOutlet.SelectedItem.Text);
        doc.SetParameterValue("Month", cmbStMonth.SelectedItem.Text);
        doc.SetParameterValue("Year", cmbStYear.SelectedItem.Text);
        doc.SetParameterValue("ReportName", Table1.Rows[0].Cells[0].InnerText.Trim());
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");
    }
}

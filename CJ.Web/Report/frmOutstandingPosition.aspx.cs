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
using CJ.Class.Web.UI.Class;
using CJ.Class.Library;
using CJ.Class.Report;
using CJ.Report;

public partial class Reports_frmOutstandingPosition : System.Web.UI.Page
{
    rptOutstandingPositionReportDetail _orptOutstandingPositionReportDetail;
    Channels _oChanneles;
    MarketGroups _oMarketGroups;
    //DateTime _dFromDate;
    DateTime _dToDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Loadcb();
            
            cbTDay.Text = DateTime.Today.Day.ToString();
            cbTMonth.Text = DateTime.Today.Month.ToString();
            cbTYear.Text = DateTime.Today.Year.ToString();
        }
    }
    public void Loadcb()
    {
        DBController.Instance.OpenNewConnection();

        _oChanneles = new Channels();
        _oChanneles.Refresh();

        _oMarketGroups = new MarketGroups();
        _oMarketGroups.Refresh();

        cmbChannel.DataSource = _oChanneles;
        cmbChannel.DataTextField = "ChannelDescription";
        cmbChannel.DataBind();
        cmbChannel.SelectedIndex = cmbChannel.Items.Count - 1;

        cmbArea.DataSource = _oMarketGroups;
        cmbArea.DataTextField = "MarketGroupDesc";
        cmbArea.DataBind();
        cmbArea.SelectedIndex = cmbArea.Items.Count - 1;


        DBController.Instance.CloseConnection();
        Session.Add("Channeles", _oChanneles);
        Session.Add("MarketGroups", _oMarketGroups);

    }
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;

        Channels _oChanneles = (Channels)Session["Channeles"];
        MarketGroups _oMarketGroups = (MarketGroups)Session["MarketGroups"];

        
        try
        {
            _dToDate = new DateTime(Convert.ToInt32(cbTYear.SelectedValue), Convert.ToInt32(cbTMonth.SelectedValue), Convert.ToInt32(cbTDay.SelectedValue));
        }
        catch
        {
            lblMessage.Text = "Input Date is not correct Formate";
            lblMessage.Visible = true;
            return;
        }
              
        _orptOutstandingPositionReportDetail = new rptOutstandingPositionReportDetail();
        DBController.Instance.OpenNewConnection();
        _orptOutstandingPositionReportDetail.Refresh(_oChanneles[cmbChannel.SelectedIndex].ChannelID, _oMarketGroups[cmbArea.SelectedIndex].MarketGroupID, txtCustomerCode.Text, _dToDate);
        DBController.Instance.CloseConnection();

        //rptOutstandingPosition doc=new rptOutstandingPosition();;
        //Solution of the problem: Maximum report processing jobs limit issue in Crystal Report
        //http://geekswithblogs.net/technetbytes/archive/2007/07/17/114008.aspx
        //By Arif Khan, 2-Jul-2011 12:06 pm
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptOutstandingPosition));
        doc.SetDataSource(_orptOutstandingPositionReportDetail);

        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session.Remove("Doc");
        Session.Add("Doc", doc);
        Response.Redirect("~/Report/frmReportViewer.aspx");

    }
    protected void ByDate_CheckedChanged(object sender, EventArgs e)
    {

    }
}

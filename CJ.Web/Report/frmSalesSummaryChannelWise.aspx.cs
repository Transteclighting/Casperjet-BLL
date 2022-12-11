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


public partial class Report_frmSalesSummaryChannelWise : System.Web.UI.Page
{
    rptSalesSummaryChannels _oSalesSummaryChannel = new rptSalesSummaryChannels();
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;


    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            DBController.Instance.OpenNewConnection();
            if (!IsPostBack)
            {
                LoadAllCombo();
                cboStDay.Text = DateTime.Today.Day.ToString();
                cboStMonth.Text = DateTime.Today.Month.ToString();
                cboStYear.Text = DateTime.Today.Year.ToString();

                cboEndDay.Text = DateTime.Today.Day.ToString();
                cboEndMonth.Text = DateTime.Today.Month.ToString();
                cboEndYear.Text = DateTime.Today.Year.ToString();
            }
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Load All Combo (Channel Wise) =" + ex);
        }

    }

    private void LoadAllCombo()
    {
        User oUser = (User)Session["User"];
        SBUs oSBUs = new SBUs();
        oSBUs.GetSBU(oUser.UserId);
        if (oSBUs.Count > 0)
        {
            Session.Add("SBU", oSBUs);
            cmbSBU.DataTextField = "SBUName";
            cmbSBU.DataValueField = "SBUID";
            cmbSBU.DataSource = oSBUs;
            cmbSBU.DataBind();
            cmbSBU.SelectedIndex = oSBUs.Count - 1;
        }
        else
        {
            SBU oSBU = new SBU();
            oSBU.SBUID = 0;
            oSBU.SBUName = "No Permission";
            oSBUs.Add(oSBU);

            cmbSBU.DataTextField = "SBUName";
            cmbSBU.DataValueField = "SBUID";
            cmbSBU.DataSource = oSBU;
            cmbSBU.DataBind();
        }
    }

    public string GetAllSBU()
    {
        SBUs _oSBUs = (SBUs)Session["SBU"];
        string sPermission = "";

        foreach (SBU oSBU in _oSBUs)
        {
            if (sPermission == "")
                sPermission = oSBU.SBUID.ToString();
            else
                sPermission = sPermission + "," + oSBU.SBUID.ToString();

        }
        return sPermission;
    }
    public string GetAllChannel()
    {
        Channels _oChannels = (Channels)Session["Channel"];
        string sPermission = "";

        foreach (Channel oChannel in _oChannels)
        {
            if (sPermission == "")
                sPermission = oChannel.ChannelID.ToString();
            else
                sPermission = sPermission + "," + oChannel.ChannelID.ToString();

        }
        return sPermission;
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

        GetSalesSummaryChannelWise();
        if (_oSalesSummaryChannel != null)
        {
            fillReport();
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Data";
        }
    }

    private void GetSalesSummaryChannelWise()
    {
        try
        {
            DBController.Instance.OpenNewConnection();
            _oSalesSummaryChannel = new rptSalesSummaryChannels();
            _oSalesSummaryChannel.SalesSummaryChannelWise(_dStartingDate, _dEndingDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  Sales Summary Report (Channel Wise) =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = _oSalesSummaryChannel.ToDataSet();

        string sExpr = "";

        sExpr = "ChannelName like '%" + txtName.Text.Trim() + "%'";

        if (int.Parse(cmbSBU.SelectedValue) != -1)
        {
            sExpr = sExpr + " and SBUID = '" + cmbSBU.SelectedValue + "'";
        }
        else sExpr = sExpr + " and SBUID in (" + GetAllSBU() + ")";

        if (txtChannelCode.Text.Trim()!= "")
        {
            sExpr = sExpr + " and ChannelCode = '" + txtChannelCode.Text.Trim() + "'";
        }


        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _oSalesSummaryChannel.FromDataSetForSalesSummaryChannel(_oDS);
        else _oSalesSummaryChannel = null;
    }

    private void fillReport()
    {
        string sCompanyName = Utility.CompanyName;
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesSummeryChannelWise));

        doc.SetDataSource(_oSalesSummaryChannel);
        doc.SetParameterValue("CompanyName", sCompanyName);

        doc.SetParameterValue("SBU", cmbSBU.SelectedItem.Text);


        doc.SetParameterValue("EntryBy", this.Context.User.Identity.Name);

        _dStartingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
        _dEndingDate = new DateTime(int.Parse(cboEndYear.SelectedValue), int.Parse(cboEndMonth.SelectedValue), int.Parse(cboEndDay.SelectedValue));

        doc.SetParameterValue("StDate", _dStartingDate);
        doc.SetParameterValue("EndDate", _dEndingDate);

        doc.SetParameterValue("Report_Name", Table1.Rows[0].Cells[0].InnerText.Trim());
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;

        Response.Redirect("frmReportViewer.aspx");
    }
}

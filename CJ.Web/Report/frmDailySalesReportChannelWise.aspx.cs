/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Shahnoor Saeed
/// Date: December 26, 2007
/// Time : 1:44 PM
/// Description: Daily Sales Report Customer Wise
/// Transfer to CJ: Arif Khan, 3-Jul-2011.
/// </summary>

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

public partial class Report_frmDailySalesReportChannelWise : System.Web.UI.Page
{
    private DailySalesReports _oDailySalesReports;
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
            }
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Load All Combo (Channel Wise) =" + ex);
        }
    }
    public void LoadAllCombo()
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

        Channels oChannels = new Channels();
        oChannels.GetChannel(oUser.UserId);
        if (oChannels.Count > 0)
        {
            Session.Add("Channel", oChannels);
            cmbChannel.DataTextField = "ChannelDescription";
            cmbChannel.DataValueField = "ChannelID";
            cmbChannel.DataSource = oChannels;
            cmbChannel.DataBind();
            cmbChannel.SelectedIndex = oChannels.Count - 1;
        }
        else
        {
            Channel oChannel = new Channel();
            oChannel.ChannelID = 0;
            oChannel.ChannelDescription = "No Permission";
            oChannels.Add(oChannel);

            cmbChannel.DataTextField = "ChannelDescription";
            cmbChannel.DataValueField = "ChannelID";
            cmbChannel.DataSource = oChannels;
            cmbChannel.DataBind();
        }
      

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
            _dEndingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
        }
        else
        {
            this.lblFromDateError.Visible = true;
            this.lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }


        getDailySalesReportChannelWise();
        if (_oDailySalesReports != null)
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

    private void getDailySalesReportChannelWise()
    {
        //Current Year Starting Date and Ending Date
        DateTime dYFromDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse("1"), int.Parse("1"));
        DateTime dYToDate = new DateTime((int.Parse(cboStYear.SelectedValue)), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));

        //Current Month Starting and Ending Date
        DateTime dMFromDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse("1"));
        DateTime dMToDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));

        //Day Starting and Ending Date
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate;

        try
        {
            _oDailySalesReports = new DailySalesReports();
            DBController.Instance.OpenNewConnection();
            if (rdoNetSales.Checked)
            {
                _oDailySalesReports.DailyNetSalesReportChaneelWise(dYFromDate, dYToDate, dMFromDate, dMToDate, dDFromDate, dDToDate); 
            }
            else
            {
                _oDailySalesReports.DailySalesReportChaneelWise(dYFromDate, dYToDate, dMFromDate, dMToDate, dDFromDate, dDToDate);  
            }
     
            DBController.Instance.CloseConnection();

        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Daily Sales Report (Chaneel Wise) =" + ex);
        }

        DataSet oDS = new DataSet();
        int x = _oDailySalesReports.Count;
        oDS = _oDailySalesReports.ToDataSet();

        string sExpr = "";
        sExpr = "ChannelName like '%" + txtName.Text.Trim() + "%'";

        if (int.Parse(cmbSBU.SelectedValue) != -1)
        {
            sExpr = sExpr + " and SBUID = '" + cmbSBU.SelectedValue + "'";
        }
        else sExpr = sExpr + " and SBUID in (" + GetAllSBU() + ")";

        if (int.Parse(cmbChannel.SelectedValue) != -1)
        {
            sExpr = sExpr + " and ChannelId = '" + cmbChannel.SelectedValue + "'";
        }
        else sExpr = sExpr + " and ChannelId in (" + GetAllChannel() + ")";
     

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _oDailySalesReports.FromDataSetForChannelWise(_oDS);
        else _oDailySalesReports = null;

    }

    private void fillReport()
    {
        string sCompanyName = Utility.CompanyName;      

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptDailySalesReportChannelWise));  

        doc.SetDataSource(_oDailySalesReports);
        doc.SetParameterValue("CompanyName", sCompanyName);

        doc.SetParameterValue("SBU", cmbSBU.SelectedItem.Text);
        doc.SetParameterValue("Channel", cmbChannel.SelectedItem.Text);     

        doc.SetParameterValue("User Name", this.Context.User.Identity.Name);
        _dStartingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
        doc.SetParameterValue("StDate", _dStartingDate);

        doc.SetParameterValue("Report_Name", Table1.Rows[0].Cells[0].InnerText.Trim());
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;

        Response.Redirect("frmReportViewer.aspx");

    }
    public string GetAllSBU()
    {
        SBUs _oSBUs = (SBUs)Session["SBU"];
        string sPermission = "";

        foreach (SBU oSBU in _oSBUs)
        {
            if (oSBU.SBUID != -1)
            {
                if (sPermission == "")
                    sPermission = oSBU.SBUID.ToString();
                else
                    sPermission = sPermission + "," + oSBU.SBUID.ToString();
            }

        }
        return sPermission;
    }
    public string GetAllChannel()
    {
        Channels _oChannels = (Channels)Session["Channel"];
        string sPermission = "";

        foreach (Channel oChannel in _oChannels)
        {
            if (oChannel.ChannelID != -1)
            {
                if (sPermission == "")
                    sPermission = oChannel.ChannelID.ToString();
                else
                    sPermission = sPermission + "," + oChannel.ChannelID.ToString();
            }

        }
        return sPermission;
    }

    
}

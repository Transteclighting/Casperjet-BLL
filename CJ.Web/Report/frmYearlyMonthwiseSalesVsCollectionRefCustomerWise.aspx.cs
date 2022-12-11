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

public partial class Report_frmMonthlySalesVSCollectionRefCustomerWise : System.Web.UI.Page
{
    rptSalesvsCollectionParentCustomers _oSalesvsCollection = new rptSalesvsCollectionParentCustomers();
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
                cmbStDay.Text = DateTime.Today.Day.ToString();
                cmbStMonth.Text = DateTime.Today.Month.ToString();
                cmbStYear.Text = DateTime.Today.Year.ToString();
            }
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Load All Combo (Customer Wise) =" + ex);
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

    protected void lnkShowReportB_Click(object sender, EventArgs e)
    {
        this.lblFromDateError.Visible = false;
        this.lblMessage.Visible = false;

        if (cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0" && cmbStDay.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse("1"), int.Parse("1"));
        }
        else
        {
            this.lblFromDateError.Visible = true;
            this.lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }
        if (cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0" && cmbStDay.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
        }
        else
        {
            this.lblFromDateError.Visible = true;
            this.lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }

        GetYearlySalesvsCollectionRefCustomer();
        if (_oSalesvsCollection != null)
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

    private void GetYearlySalesvsCollectionRefCustomer()
    {
        try
        {
            DBController.Instance.OpenNewConnection();
            _oSalesvsCollection = new rptSalesvsCollectionParentCustomers();
            _oSalesvsCollection.YearlySalesvsCollectionRefCustomer(_dStartingDate, _dEndingDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  Sales Summary Report (Channel Wise) =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = _oSalesvsCollection.ToDataSet();

        string sExpr = "";

        string sSort;

        lblMessage.Visible = false;
        sExpr = "ParentCustomerName like '%" + txtRefCustomerName.Text.Trim() + "%'";

        if (txtRefCustomerCode.Text.Trim() != "")
        {
            sExpr = sExpr + " and ParentCustomerCode = '" + txtRefCustomerCode.Text.Trim() + "'";
        }

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
            _oSalesvsCollection.FromDataYearlySalesvsCollectionRefCustomer(_oDS);
        else _oSalesvsCollection = null;
    }

    private void fillReport()
    {
        string sCompanyName = Utility.CompanyName;
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMonthlySalesVsCollectionParentCustomerWise));

        doc.SetDataSource(_oSalesvsCollection);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("SBU", cmbSBU.SelectedItem.Text);
        doc.SetParameterValue("Channel", cmbChannel.SelectedItem.Text);

        doc.SetParameterValue("User Name", this.Context.User.Identity.Name);

        _dEndingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));

        doc.SetParameterValue("EndDate", _dEndingDate);

        doc.SetParameterValue("Report_Name", Table1.Rows[0].Cells[0].InnerText.Trim());
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();

        Session["Doc"] = (object)doc;

        Response.Redirect("frmReportViewer.aspx");
    }
}

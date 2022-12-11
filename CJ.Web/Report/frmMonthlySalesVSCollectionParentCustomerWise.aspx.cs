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

public partial class Report_frmMonthlySalesVSCollectionParentCustomerWise : System.Web.UI.Page
{
    private rptSalesVSCollections _orptSalesVSCollections;
    DateTime dCFromDate;
    DateTime dCToDate;
    DateTime dLFromDate;
    DateTime dLToDate;

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

    }
}

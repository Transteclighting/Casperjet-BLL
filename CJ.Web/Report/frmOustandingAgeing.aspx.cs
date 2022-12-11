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
using CJ.Class.Library;


public partial class Report_frmOustandingAgeing : System.Web.UI.Page
{
    private DateTime _dStartingDate;
    
    RptOutssandingAgeingCustomerWiseDetauls _RptOutssandingAgeingCustomerWiseDetauls;

    protected void Page_Load(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {
            cmbStDay.Text = DateTime.Today.Day.ToString();
            cmbStMonth.Text = DateTime.Today.Month.ToString();
            cmbStYear.Text = DateTime.Today.Year.ToString();

            LoadAllCombo();
        }
        DBController.Instance.CloseConnection();

    }
    public void LoadAllCombo()
    {
        DBController.Instance.OpenNewConnection();

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
        MarketGroups oMarketGroups = new MarketGroups();
        oMarketGroups.GetArea(oUser.UserId);
        if (oMarketGroups.Count > 0)
        {
            Session.Add("Area", oMarketGroups);
            cmbArea.DataTextField = "MarketGroupDesc";
            cmbArea.DataValueField = "MarketGroupID";
            cmbArea.DataSource = oMarketGroups;
            cmbArea.DataBind();
            cmbArea.SelectedIndex = oMarketGroups.Count - 1;
        }
        else
        {
            MarketGroup oMarketGroup = new MarketGroup();
            oMarketGroup.MarketGroupID = 0;
            oMarketGroup.MarketGroupDesc = "No Permission";
            oMarketGroups.Add(oMarketGroup);

            cmbArea.DataTextField = "MarketGroupDesc";
            cmbArea.DataValueField = "MarketGroupID";
            cmbArea.DataSource = oMarketGroups;
            cmbArea.DataBind();
        }

        oMarketGroups = new MarketGroups();
        oMarketGroups.GetTerritory(oUser.UserId);
        if (oMarketGroups.Count > 0)
        {
            Session.Add("Territory", oMarketGroups);
            cmbTerritory.DataTextField = "MarketGroupDesc";
            cmbTerritory.DataValueField = "MarketGroupID";
            cmbTerritory.DataSource = oMarketGroups;
            cmbTerritory.DataBind();
            cmbTerritory.SelectedIndex = oMarketGroups.Count - 1;
        }
        else
        {
            MarketGroup oMarketGroup = new MarketGroup();
            oMarketGroup.MarketGroupID = 0;
            oMarketGroup.MarketGroupDesc = "No Permission";
            oMarketGroups.Add(oMarketGroup);

            cmbTerritory.DataTextField = "MarketGroupDesc";
            cmbTerritory.DataValueField = "MarketGroupID";
            cmbTerritory.DataSource = oMarketGroups;
            cmbTerritory.DataBind();
        }
        CustomerTypies oCustomerTypies = new CustomerTypies();
        oCustomerTypies.GetCustomerType();
        Session.Add("CustomerType", oCustomerTypies);
        cmbCType.DataTextField = "CustTypeDescription";
        cmbCType.DataValueField = "CustTypeID";
        cmbCType.DataSource = oCustomerTypies;
        cmbCType.DataBind();
        cmbCType.SelectedIndex = oCustomerTypies.Count - 1;

    }
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        SBUs _SBUs = (SBUs)Session["SBU"];
        Channels _oChannels = (Channels)Session["Channel"];
        MarketGroups _oArea = (MarketGroups)Session["Area"];
        MarketGroups _oTerritory = (MarketGroups)Session["Territory"];

        if (cmbStDay.SelectedValue != "0" && cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
            
        }
        else
        {
            //lblErrFrmDate.Visible = true;
            //lblErrFrmDate.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }

        _RptOutssandingAgeingCustomerWiseDetauls = new RptOutssandingAgeingCustomerWiseDetauls();
        DBController.Instance.OpenNewConnection();
        _RptOutssandingAgeingCustomerWiseDetauls.OutstandingAgeingCustomer(_dStartingDate);
        DBController.Instance.CloseConnection();
        DataSet oDS = new DataSet();
        oDS = _RptOutssandingAgeingCustomerWiseDetauls.ToDataSet();

        string sExpr = "";

        sExpr = " CustomerName like '%" + txtName.Text.Trim() + "%'";

        if ((txtName.Text) != "")
        {
            sExpr = sExpr + " and CustomerName like '%" + txtName.Text.Trim() + "%'";
        }

        if ((txtCode.Text) != "")
        {
            sExpr = sExpr + " and CustomerCode= '" + txtCode.Text.Trim() + "'";
        }

        if (int.Parse(cmbSBU.SelectedValue) != -1)
        {
            sExpr = sExpr + " and SBUID = '" + cmbSBU.SelectedValue + "'";
        }
        if (int.Parse(cmbChannel.SelectedValue) != -1)
        {
            sExpr = sExpr + " and ChannelID = '" + cmbChannel.SelectedValue + "'";
        }
        if (int.Parse(cmbArea.SelectedValue) != -1)
        {
            sExpr = sExpr + " and AreaID = '" + cmbArea.SelectedValue + "'";
        }
        if (int.Parse(cmbTerritory.SelectedValue) != -1)
        {
            sExpr = sExpr + " and TerritoryID = '" + cmbTerritory.SelectedValue + "'";
        }
        if (int.Parse(cmbCType.SelectedValue) != -1)
        {
            sExpr = sExpr + " and CustomerTypeID = '" + cmbCType.SelectedValue + "'";
        }

        

        if (int.Parse(cmbActive.SelectedValue) != -1)
        {
            sExpr = sExpr + " and IsActive = '" + cmbActive.SelectedValue + "'";
        }

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _RptOutssandingAgeingCustomerWiseDetauls.FromDataSetOutstandingAgeingCust(_oDS);
        else _RptOutssandingAgeingCustomerWiseDetauls = null;

        if (_RptOutssandingAgeingCustomerWiseDetauls != null)
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
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptOutstandingAgeingCustomerWise));

        doc.SetDataSource(_RptOutssandingAgeingCustomerWiseDetauls);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("StDate", _dStartingDate);
        doc.SetParameterValue("SBU", cmbSBU.SelectedItem.Text);
        doc.SetParameterValue("Channel", cmbChannel.SelectedItem.Text);
        doc.SetParameterValue("Area", cmbArea.SelectedItem.Text);
        doc.SetParameterValue("Territory", cmbTerritory.Text);
        doc.SetParameterValue("CustomerTypeName", cmbCType.Text);
        doc.SetParameterValue("CustomerCode", txtCode.Text);
        doc.SetParameterValue("Status", cmbActive.Text);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("Report_Name", "Outstanding Ageing Customer Wise [515]");
        Session["ReportName"] = "Outstanding Ageing Customer Wise [515]";
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

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
    public string GetAllArea()
    {
        MarketGroups _oMarketGroups = (MarketGroups)Session["Area"];
        string sPermission = "";

        foreach (MarketGroup oMarketGroup in _oMarketGroups)
        {
            if (sPermission == "")
                sPermission = oMarketGroup.MarketGroupID.ToString();
            else
                sPermission = sPermission + "," + oMarketGroup.MarketGroupID.ToString();

        }
        return sPermission;
    }
    public string GetAllTerritory()
    {
        MarketGroups _oMarketGroups = (MarketGroups)Session["Territory"];
        string sPermission = "";

        foreach (MarketGroup oMarketGroup in _oMarketGroups)
        {
            if (sPermission == "")
                sPermission = oMarketGroup.MarketGroupID.ToString();
            else
                sPermission = sPermission + "," + oMarketGroup.MarketGroupID.ToString();

        }
        return sPermission;
    }
    public string GetAllCustomerType()
    {
        CustomerTypies _oCustomerTypies = (CustomerTypies)Session["CustomerType"];
        string sPermission = "";

        foreach (CustomerType oCustomerType in _oCustomerTypies)
        {
            if (sPermission == "")
                sPermission = oCustomerType.CustTypeID.ToString();
            else
                sPermission = sPermission + "," + oCustomerType.CustTypeID.ToString();

        }
        return sPermission;
    }  

}

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

public partial class Report_frmWeeklySalesNCollCustomerwise : System.Web.UI.Page
{
    private DateTime _dStartingDate;
    private DateTime _dStartingDate1;
    private DateTime _dStartingDate2;
    private DateTime _dStartingDate3;
    private DateTime _dStartingDate4;

    private DateTime _dEndingDate1;
    private DateTime _dEndingDate2;
    private DateTime _dEndingDate3;
    private DateTime _dEndingDate4;
    

    RptSalesAndCollReportCustomerWiseDetails _RptSalesAndCollReportCustomerWiseDetails;
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
        TELLib oTELLib =new TELLib();
        SBUs _SBUs = (SBUs)Session["SBU"];
        Channels _oChannels = (Channels)Session["Channel"];
        MarketGroups _oArea = (MarketGroups)Session["Area"];
        MarketGroups _oTerritory = (MarketGroups)Session["Territory"];
        

        if (cmbStDay.SelectedValue != "0" && cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0")
        {
            _dStartingDate1 = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), 1);
            _dStartingDate2 = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), 9);
            _dStartingDate3 = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), 17);
            _dStartingDate4 = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), 24);
            _dStartingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
        }
        else
        {
            lblErrFrmDate.Visible = true;
            lblErrFrmDate.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }


        if (cmbStDay.SelectedValue != "0" && cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0")
        {
            _dEndingDate1 = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), 8);
            _dEndingDate2 = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), 16);
            _dEndingDate3 = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), 23);
            _dEndingDate4 = oTELLib.LastDayofMonth(_dStartingDate1);

        }
        else
        {
            lblErrFrmDate.Visible = true;
            lblErrFrmDate.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }

        _RptSalesAndCollReportCustomerWiseDetails = new RptSalesAndCollReportCustomerWiseDetails();
        DBController.Instance.OpenNewConnection();
        _RptSalesAndCollReportCustomerWiseDetails.SalesAndCollReportCustomerWise(_dStartingDate1, _dEndingDate1, _dStartingDate2, _dEndingDate2, _dStartingDate3, _dEndingDate3, _dStartingDate4, _dEndingDate4, _dStartingDate);
        DBController.Instance.CloseConnection();
        DataSet oDS = new DataSet();
        oDS = _RptSalesAndCollReportCustomerWiseDetails.ToDataSet();

        string sExpr = "";

        sExpr = " CustomerName like '%" + txtName.Text.Trim() + "%'";

        if ((txtName.Text) != "")
        {
            sExpr = sExpr + " and CustomerName like '%" + txtName.Text.Trim() + "%'";
        }

        if ((txtCode.Text) != "")
        {
            sExpr = sExpr + " and CustomerCode= '" + txtCode.Text.Trim() + "%'";
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
            _RptSalesAndCollReportCustomerWiseDetails.FromDataSetSalesAndCollReport(_oDS);
        else _RptSalesAndCollReportCustomerWiseDetails = null;

        if (_RptSalesAndCollReportCustomerWiseDetails != null)
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
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptWeeklySalesNCollCustomerwise));

        doc.SetDataSource(_RptSalesAndCollReportCustomerWiseDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);        
        doc.SetParameterValue("Date", _dStartingDate);
        doc.SetParameterValue("Channel",cmbChannel.SelectedItem.Text);
        doc.SetParameterValue("Area", cmbArea.SelectedItem.Text);
        doc.SetParameterValue("Territory", cmbTerritory.Text);
        doc.SetParameterValue("CustomerType",cmbCType.Text);
        doc.SetParameterValue("Status", cmbActive.Text); 
        doc.SetParameterValue("User Name", this.Context.User.Identity.Name);
        doc.SetParameterValue("Report_Name", "Monthly Week Wise Sales And Collection Report Customer Wise [410]");
        Session["ReportName"] = "Monthly Week Wise Sales And Collection Report Customer Wise [410]";        
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

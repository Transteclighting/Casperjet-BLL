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



/// <summary>
/// Public Class For Daily Sales Report Customer Wise
/// </summary>
public partial class Report_frmDailySalesReportCustomerWise : System.Web.UI.Page
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
            AppLogger.LogError("Web: error in Load All Combo (Customer Wise) =" + ex);
        }
    }

    /// <summary>
    /// Public Class For Load Combo
    /// </summary>
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
        cmbCustType.DataTextField = "CustTypeDescription";
        cmbCustType.DataValueField = "CustTypeID";
        cmbCustType.DataSource = oCustomerTypies;
        cmbCustType.DataBind();
        cmbCustType.SelectedIndex = oCustomerTypies.Count - 1;
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

        getDailySalesReportCustomerWise();
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

    private void getDailySalesReportCustomerWise()
    {
        //Current Year Starting Date and Ending Date
        DateTime dYFromDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse("1"), int.Parse("1"));
        DateTime dYToDate = new DateTime((int.Parse(cboStYear.SelectedValue)), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
        
        //Current Month Starting and Ending Date
        DateTime dMFromDate=new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse("1"));
        DateTime dMToDate=new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
        
        //Day Starting and Ending Date
        DateTime dDFromDate=_dStartingDate;
        DateTime dDToDate=_dEndingDate;

        try
        {
            _oDailySalesReports = new DailySalesReports();
            DBController.Instance.OpenNewConnection();
            //_oDailySalesReports.DailySalesReportCustomerWise(dYFromDate, dYToDate, dMFromDate, dMToDate, dDFromDate, dDToDate);
            

            if (rdoNetSales.Checked)
            {
                _oDailySalesReports.DailyNetSalesReportCustomerWise(dYFromDate, dYToDate, dMFromDate, dMToDate, dDFromDate, dDToDate);
            }
            else
            {
                _oDailySalesReports.DailySalesReportCustomerWise(dYFromDate, dYToDate, dMFromDate, dMToDate, dDFromDate, dDToDate);
            }
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Daily Sales Report (Customer Wise) =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = _oDailySalesReports.ToDataSet();

        string sExpr="";
        sExpr = "CustomerName like '%" + txtName.Text.Trim() + "%'";
        if (txtName.Text != "")
            sExpr = sExpr + " and  CustomerCode like '%" + txtCustomerCode.Text.Trim() + "%'";

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

        if (int.Parse(cmbCustType.SelectedValue) != -1)
        {           
            sExpr = sExpr + " and CustomerTypeID = '" + cmbCustType.SelectedValue + "'";
        }
        else sExpr = sExpr + " and CustomerTypeID in (" + GetAllCustomerType() + ")";

        if (int.Parse(cmbArea.SelectedValue) != -1)
        {
            sExpr = sExpr + " and AreaId = '" + cmbArea.SelectedValue + "'";
        }
        else sExpr = sExpr + " and AreaId in (" + GetAllArea() + ")";

        if (int.Parse(cmbTerritory.SelectedValue) != -1)
        {
            sExpr = sExpr + " and TerritoryId = '" + cmbTerritory.SelectedValue + "'";
        }
        else sExpr = sExpr + " and TerritoryId in (" + GetAllTerritory()+ ")";

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS=new DataSet();     
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count>0)
            _oDailySalesReports.FromDataSetForCustomerWise(_oDS);
        else _oDailySalesReports = null;
       
    }

    private void fillReport()
    {     
        string sCompanyName = Utility.CompanyName;      
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptDailySalesReportCustomerWise));  

        doc.SetDataSource(_oDailySalesReports);
        doc.SetParameterValue("CompanyName", sCompanyName);

        doc.SetParameterValue("SBU", cmbSBU.SelectedItem.Text);
        doc.SetParameterValue("Channel", cmbChannel.SelectedItem.Text);
        doc.SetParameterValue("Area", cmbArea.SelectedItem.Text);
        doc.SetParameterValue("Territory", cmbTerritory.SelectedItem.Text);
        //doc.SetParameterValue("CustomerType", cmbCustType.SelectedItem.Text);

        doc.SetParameterValue("User Name", this.Context.User.Identity.Name);
        _dStartingDate = new DateTime(int.Parse(cboStYear.SelectedValue), int.Parse(cboStMonth.SelectedValue), int.Parse(cboStDay.SelectedValue));
        doc.SetParameterValue("StDate", _dStartingDate);

        doc.SetParameterValue("Report_Name", Table1.Rows[0].Cells[0].InnerText.Trim());
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();       
        Session["Doc"] = (object)doc;     
     
        Response.Redirect("frmReportViewer.aspx");

    }

   
}

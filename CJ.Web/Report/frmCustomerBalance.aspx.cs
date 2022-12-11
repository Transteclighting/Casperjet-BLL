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

public partial class Report_frmCustomeroutstanding : System.Web.UI.Page
{
    rptOutstandingPositionReportDetail _orptOutstandingPositionReportDetail;
    Channels _oChanneles;
    MarketGroups _oMarketGroups;
    private DateTime _dStartingDate;
    private DateTime _dCurrentDate;
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {
            LoadAllCombo();

            CurrentOutstanding.Checked = true;
        }
        DBController.Instance.CloseConnection();


    }
    protected void lnkShowReportB_Click(object sender, EventArgs e)
    {
        Channels _oChannels = (Channels)Session["Channel"];
        MarketGroups _oArea = (MarketGroups)Session["Area"];
        MarketGroups _oTerritory = (MarketGroups)Session["Territory"];
        CustomerTypies _oCustomerTypies = (CustomerTypies)Session["CustomerType"];
        
        if (this.CurrentOutstanding.Checked)
        {
            
            _orptOutstandingPositionReportDetail = new rptOutstandingPositionReportDetail();
            DBController.Instance.OpenNewConnection();
            _orptOutstandingPositionReportDetail.CustomerOutstanding();
            DBController.Instance.CloseConnection();

            DataSet oDS = new DataSet();
            oDS = _orptOutstandingPositionReportDetail.ToDataSet();


            string sExpr = "";
            sExpr = "CustomerName like '%" + txtName.Text.Trim() + "%'";

            if ((txtName.Text) != "")
            {
                sExpr = sExpr + " and CustomerName like '%" + txtName.Text.Trim() + "%'";
            }

            if ((txtCustomerCode.Text) != "")
            {
                sExpr = sExpr + " and CustomerCode = '" + txtCustomerCode.Text + "'";
            }
            if (int.Parse(cmbActive.SelectedValue) != 2)
            {
                sExpr = sExpr + " and Status= '" + cmbActive.SelectedValue + "'";
            }

            if (int.Parse(cmbChannel.SelectedValue) != -1)
            {
                sExpr = sExpr + " and ChannelID = '" + cmbChannel.SelectedValue + "'";
            }
            else sExpr = sExpr + " and ChannelID in (" + GetAllChannel() + ")";


            if (int.Parse(cmbArea.SelectedValue) != -1)
            {
                sExpr = sExpr + " and AreaID = '" + cmbArea.SelectedValue + "'";
            }
            else sExpr = sExpr + " and AreaID in (" + GetAllArea() + ")";

            if (int.Parse(cmbTerritory.SelectedValue) != -1)
            {
                sExpr = sExpr + " and TerritoryID = '" + cmbTerritory.SelectedValue + "'";
            }
            else sExpr = sExpr + " and TerritoryID in (" + GetAllTerritory() + ")";


            DataRow[] oDR = oDS.Tables[0].Select(sExpr);

            DataSet _oDS = new DataSet();
            _oDS.Merge(oDR);
            _oDS.AcceptChanges();
            if (_oDS.Tables.Count > 0)
                _orptOutstandingPositionReportDetail.FromDataSetForCustomerOutstanding(_oDS);
            else _orptOutstandingPositionReportDetail = null;

            if (_orptOutstandingPositionReportDetail.Count > 0)
                fillReport();
        }

        else if (this.ByODate.Checked)
        {
           _dStartingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
           _dCurrentDate = DateTime.Today.Date.AddDays(1);
            
            
            _orptOutstandingPositionReportDetail = new rptOutstandingPositionReportDetail();
            DBController.Instance.OpenNewConnection();
            _orptOutstandingPositionReportDetail.CustomerOpeningOutstanding(_dStartingDate, _dCurrentDate);
            DBController.Instance.CloseConnection();

            DataSet oDS = new DataSet();
            oDS = _orptOutstandingPositionReportDetail.ToDataSet();


            string sExpr = "";
            sExpr = "CustomerName like '%" + txtName.Text.Trim() + "%'";

            if ((txtCustomerCode.Text) != "")
            {
                sExpr = sExpr + " and CustomerCode = '" + txtCustomerCode.Text + "'";
            }
            if (int.Parse(cmbActive.SelectedValue) != 2)
            {
                sExpr = sExpr + " and IsActive= '" + cmbActive.SelectedValue + "'";
            }

            if (int.Parse(cmbChannel.SelectedValue) != -1)
            {
                sExpr = sExpr + " and ChannelID = '" + cmbChannel.SelectedValue + "'";
            }
            else sExpr = sExpr + " and ChannelID in (" + GetAllChannel() + ")";


            if (int.Parse(cmbArea.SelectedValue) != -1)
            {
                sExpr = sExpr + " and AreaID = '" + cmbArea.SelectedValue + "'";
            }
            else sExpr = sExpr + " and AreaID in (" + GetAllArea() + ")";

            if (int.Parse(cmbTerritory.SelectedValue) != -1)
            {
                sExpr = sExpr + " and TerritoryID = '" + cmbTerritory.SelectedValue + "'";
            }
            else sExpr = sExpr + " and TerritoryID in (" + GetAllTerritory() + ")";


            DataRow[] oDR = oDS.Tables[0].Select(sExpr);

            DataSet _oDS = new DataSet();
            _oDS.Merge(oDR);
            _oDS.AcceptChanges();
            if (_oDS.Tables.Count > 0)
                _orptOutstandingPositionReportDetail.FromDataSetOpeningOutstanding(_oDS);
            else _orptOutstandingPositionReportDetail = null;

            if (_orptOutstandingPositionReportDetail.Count > 0)
                fillReport();

        }

        else if (this.ByCDate.Checked)
        {
            DateTime dDFromDate = _dStartingDate;
            DateTime dDToDate = _dCurrentDate;

            if (cmbClMonth.SelectedValue != "0" && cmbClYear.SelectedValue != "0" && cmbClDay.SelectedValue != "0")
            {
                _dStartingDate = new DateTime(int.Parse(cmbClYear.SelectedValue), int.Parse(cmbClMonth.SelectedValue), int.Parse(cmbClDay.SelectedValue));
                _dCurrentDate = DateTime.Today.Date.AddDays(1);
            }

            _orptOutstandingPositionReportDetail = new rptOutstandingPositionReportDetail();
            DBController.Instance.OpenNewConnection();
            _orptOutstandingPositionReportDetail.CustomerClosingOutstanding(_dStartingDate, _dCurrentDate);
            DBController.Instance.CloseConnection();

            DataSet oDS = new DataSet();
            oDS = _orptOutstandingPositionReportDetail.ToDataSet();


            string sExpr = "";
            sExpr = "CustomerName like '%" + txtName.Text.Trim() + "%'";

            if ((txtCustomerCode.Text) != "")
            {
                sExpr = sExpr + " and CustomerCode = '" + txtCustomerCode.Text + "'";
            }
            if (int.Parse(cmbActive.SelectedValue) != 2)
            {
                sExpr = sExpr + " and IsActive= '" + cmbActive.SelectedValue + "'";
            }

            if (int.Parse(cmbChannel.SelectedValue) != -1)
            {
                sExpr = sExpr + " and ChannelID = '" + cmbChannel.SelectedValue + "'";
            }
            else sExpr = sExpr + " and ChannelID in (" + GetAllChannel() + ")";


            if (int.Parse(cmbArea.SelectedValue) != -1)
            {
                sExpr = sExpr + " and AreaID = '" + cmbArea.SelectedValue + "'";
            }
            else sExpr = sExpr + " and AreaID in (" + GetAllArea() + ")";

            if (int.Parse(cmbTerritory.SelectedValue) != -1)
            {
                sExpr = sExpr + " and TerritoryID = '" + cmbTerritory.SelectedValue + "'";
            }
            else sExpr = sExpr + " and TerritoryID in (" + GetAllTerritory() + ")";


            DataRow[] oDR = oDS.Tables[0].Select(sExpr);

            DataSet _oDS = new DataSet();
            _oDS.Merge(oDR);
            _oDS.AcceptChanges();
            if (_oDS.Tables.Count > 0)
                _orptOutstandingPositionReportDetail.FromDataSetClosingOutstanding(_oDS);
            else _orptOutstandingPositionReportDetail = null;

            if (_orptOutstandingPositionReportDetail.Count > 0)
                fillReport();
                  
        }
             
    }

    private void GetCustomerClosingbalance()
    {
        //Day Starting and Ending Date

        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dCurrentDate;
        int nStatus;

        _orptOutstandingPositionReportDetail = new rptOutstandingPositionReportDetail();
        
        try
        {
            DBController.Instance.OpenNewConnection();

            _orptOutstandingPositionReportDetail.CustomerClosingOutstanding(dDFromDate, dDToDate);

            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Customer Opening Outstanding =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = _orptOutstandingPositionReportDetail.ToDataSet();

        string sExpr = "";

        sExpr = "CustomerName like '%" + txtName.Text.Trim() + "%'";

        if (int.Parse(cmbChannel.SelectedValue) != -1)
        {
            sExpr = sExpr + " and ChannelCode = '" + cmbChannel.SelectedValue + "'";
        }
        else sExpr = sExpr + " and ChannelCode in (" + GetAllChannel() + ")";

        if (int.Parse(cmbActive.SelectedValue) != 2)
        {
            sExpr = sExpr + " and Isactive= '" + cmbActive.SelectedValue + "'";
        }
        if (int.Parse(cmbArea.SelectedValue) != -1)
        {
            sExpr = sExpr + " and AreaCode = '" + cmbArea.SelectedValue + "'";
        }
        else sExpr = sExpr + " and AreaCode in (" + GetAllArea() + ")";

        if (int.Parse(cmbTerritory.SelectedValue) != -1)
        {
            sExpr = sExpr + " and TerritoryCode = '" + cmbTerritory.SelectedValue + "'";
        }
        else sExpr = sExpr + " and TerritoryCode in (" + GetAllTerritory() + ")";
               
        
        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _orptOutstandingPositionReportDetail.FromDataSetClosingOutstanding(_oDS);
        else _orptOutstandingPositionReportDetail = null;

        if (_orptOutstandingPositionReportDetail.Count > 0)
            fillReport();
    
    
    }
    
    private void getDataCustomerBalance()
    {           
       
        //Day Starting and Ending Date

        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dCurrentDate;
        int nStatus;

        _orptOutstandingPositionReportDetail = new rptOutstandingPositionReportDetail();
        
       
        try
        {
            DBController.Instance.OpenNewConnection();

            _orptOutstandingPositionReportDetail.CustomerOpeningOutstanding(dDFromDate, dDToDate);
            
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Customer Opening Outstanding =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = _orptOutstandingPositionReportDetail.ToDataSet();

        string sExpr = "";

        sExpr = "CustomerName like '%" + txtName.Text.Trim() + "%'";

        if (int.Parse(cmbChannel.SelectedValue) != -1)
        {
            sExpr = sExpr + " and ChannelCode = '" + cmbChannel.SelectedValue + "'";
        }
        else sExpr = sExpr + " and ChannelCode in (" + GetAllChannel() + ")";

        if (int.Parse(cmbActive.SelectedValue) != 2)
        {
            sExpr = sExpr + " and IsActive= '" + cmbActive.SelectedValue + "'";
        }
        if (int.Parse(cmbArea.SelectedValue) != -1)
        {
            sExpr = sExpr + " and AreaCode = '" + cmbArea.SelectedValue + "'";
        }
        else sExpr = sExpr + " and AreaCode in (" + GetAllArea() + ")";

        if (int.Parse(cmbTerritory.SelectedValue) != -1)
        {
            sExpr = sExpr + " and TerritoryCode = '" + cmbTerritory.SelectedValue + "'";
        }
        else sExpr = sExpr + " and TerritoryCode in (" + GetAllTerritory() + ")";

        if (int.Parse(cmbCustType.SelectedValue) != -1)
        {
            sExpr = sExpr + " and CustomerTypeCode = '" + cmbCustType.SelectedValue + "'";
        }
                
        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
          _orptOutstandingPositionReportDetail.FromDataSetOpeningOutstanding(_oDS);
        else _orptOutstandingPositionReportDetail = null;

      if (_orptOutstandingPositionReportDetail.Count > 0)
          fillReport();
             
    }

    public void LoadAllCombo()
    {
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
        cmbCustType.DataTextField = "CustTypeDescription";
        cmbCustType.DataValueField = "CustTypeID";
        cmbCustType.DataSource = oCustomerTypies;
        cmbCustType.DataBind();
        cmbCustType.SelectedIndex = oCustomerTypies.Count - 1;
    }

    private void fillReport()
    {
        
        string sCompanyName = Utility.CompanyName;
       
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCustomerOutstanding));

        doc.SetDataSource(_orptOutstandingPositionReportDetail);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("Loginuser", this.Context.User.Identity.Name);
        // new
        if (CurrentOutstanding.Checked==true)
        {
        doc.SetParameterValue("ReportType", " Current Outstanding ");
        doc.SetParameterValue("Reportdate",DateTime.Today.Date);
            

        }
        else if ( ByODate.Checked==true)
        {
            doc.SetParameterValue("ReportType", " Opening Outstanding ");
            doc.SetParameterValue("Reportdate", _dStartingDate);
        }
        else if (ByCDate.Checked == true)
        {
            doc.SetParameterValue("ReportType", " Closing Outstanding ");
            doc.SetParameterValue("Reportdate", _dStartingDate);
        }
        
        // end new 
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");       

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
    //public string GetAllCustomerType()
    //{
        //CustomerType _oCustomerType = (CustomerType)Session["CustomerTypeName"];
                
        //string sPermission = "";

        //foreach (CustomerType oCustomerType in _oCustomerType)
        //{
        //    if (sPermission == "")
        //        sPermission = oCustomerType.CustTypeCode.ToString();
        //    else
        //        sPermission = sPermission + "," + oCustomerType.CustTypeCode.ToString();

        //}
        //return sPermission;
   // }


    protected void cmbChannel_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void CurrentOutstanding_CheckedChanged(object sender, EventArgs e)
    {
        CurrentOutstanding.Checked = true;
        ByODate.Checked = false;
        ByCDate.Checked = false;

    }
    protected void ByODate_CheckedChanged(object sender, EventArgs e)
    {
        CurrentOutstanding.Checked = false;
        ByODate.Checked = true;
        ByCDate.Checked = false;
    }
    protected void ByCDate_CheckedChanged(object sender, EventArgs e)
    {
        CurrentOutstanding.Checked = false;
        ByODate.Checked = false;
        ByCDate.Checked = true;
    }
}

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

public partial class Report_frmMonthlySalesVSCollectionCustomerWise : System.Web.UI.Page
{
    private rptSalesVSCollections _orptSalesVSCollections;

    DateTime dCYFromDate;
    DateTime dCYToDate;
    DateTime dLYCFromDate;
    DateTime dLYCToDate;
    DateTime dLYFromDate;
    DateTime dLYToDate;
    DateTime dFromDate;
    DateTime dToDate;
    string sReportType = "";

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
                rdoSBU_CheckedChanged(null,null);
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

    protected void rdoSBU_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoSBU.Checked == true)
        {
            rdoChannel.Checked = false;
            rdoArea.Checked = false;
            rdoTerritory.Checked = false;
            rdoCustomer.Checked = false;
            rdoParentCustomer.Checked = false;

            cmbSBU.Enabled = true;
            cmbChannel.Enabled = false;
            cmbArea.Enabled = false;
            cmbTerritory.Enabled = false;
            cmbCustType.Enabled = false;
            cmbActive.Enabled = false;
            txtCustomerCode.Enabled = false;
            txtName.Enabled = false;
            txtRefCustomerCode.Enabled = false;
            txtRefCustomerName.Enabled = false;
        }
    }
    protected void rdoChannel_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoChannel.Checked == true)
        {
            rdoSBU.Checked = false;
            rdoArea.Checked = false;
            rdoTerritory.Checked = false;
            rdoCustomer.Checked = false;
            rdoParentCustomer.Checked = false;

            cmbSBU.Enabled = true;
            cmbChannel.Enabled = true;
            cmbArea.Enabled = false;
            cmbTerritory.Enabled = false;
            cmbCustType.Enabled = false;
            cmbActive.Enabled = false;
            txtCustomerCode.Enabled = false;
            txtName.Enabled = false;
            txtRefCustomerCode.Enabled = false;
            txtRefCustomerName.Enabled = false;
        }
    }
    protected void rdoArea_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoArea.Checked == true)
        {
            rdoChannel.Checked = false;
            rdoSBU.Checked = false;
            rdoTerritory.Checked = false;
            rdoCustomer.Checked = false;
            rdoParentCustomer.Checked = false;

            cmbSBU.Enabled = true;
            cmbChannel.Enabled = true;
            cmbArea.Enabled = true;
            cmbTerritory.Enabled = false;
            cmbCustType.Enabled = false;
            cmbActive.Enabled = false;
            txtCustomerCode.Enabled = false;
            txtName.Enabled = false;
            txtRefCustomerCode.Enabled = false;
            txtRefCustomerName.Enabled = false;
           
        }
    }
    protected void rdoTerritory_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoTerritory.Checked == true)
        {
            rdoChannel.Checked = false;
            rdoArea.Checked = false;
            rdoSBU.Checked = false;
            rdoCustomer.Checked = false;
            rdoParentCustomer.Checked = false;

            cmbSBU.Enabled = true;
            cmbChannel.Enabled = true;
            cmbArea.Enabled = true;
            cmbTerritory.Enabled = true;
            cmbCustType.Enabled = false;
            cmbActive.Enabled = false;
            txtCustomerCode.Enabled = false;
            txtName.Enabled = false;
            txtRefCustomerCode.Enabled = false;
            txtRefCustomerName.Enabled = false;
        }
    }
    protected void rdoCustomer_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoCustomer.Checked == true)
        {
            rdoChannel.Checked = false;
            rdoArea.Checked = false;
            rdoTerritory.Checked = false;
            rdoSBU.Checked = false;
            rdoParentCustomer.Checked = false;

            cmbSBU.Enabled = true;
            cmbChannel.Enabled = true;
            cmbArea.Enabled = true;
            cmbTerritory.Enabled = true;
            cmbCustType.Enabled = true;
            cmbActive.Enabled = true;
            txtCustomerCode.Enabled = true;
            txtName.Enabled = true;
            txtRefCustomerCode.Enabled = true;
            txtRefCustomerName.Enabled = true;
           
        }
    }
    protected void rdoParentCustomer_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoParentCustomer.Checked == true)
        {
            rdoChannel.Checked = false;
            rdoArea.Checked = false;
            rdoTerritory.Checked = false;
            rdoCustomer.Checked = false;
            rdoSBU.Checked = false;

            cmbSBU.Enabled = true;
            cmbChannel.Enabled = true;
            cmbArea.Enabled = false;
            cmbTerritory.Enabled = false;
            cmbCustType.Enabled = false;
            cmbActive.Enabled = false;
            txtCustomerCode.Enabled = false;
            txtName.Enabled = false;
            txtRefCustomerCode.Enabled = true;
            txtRefCustomerName.Enabled = true;
        }
    }   

    protected void lnkShowReportB_Click(object sender, EventArgs e)
    {
        this.lblFromDateError.Visible = false;
        this.lblMessage.Visible = false;

        try
        {
            //Current Year Starting Date and Ending Date
            dCYFromDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse("1"), int.Parse("1"));
            dCYToDate = new DateTime((int.Parse(cmbStYear.SelectedValue)), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));

            //Last Year Cumulative Starting Date and Ending Date
            dLYCFromDate = new DateTime((int.Parse(cmbStYear.SelectedValue) - 1), int.Parse("1"), int.Parse("1"));
            dLYCToDate = new DateTime((int.Parse(cmbStYear.SelectedValue)-1), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));


            //Last Year Starting Date and Ending Date
            dLYFromDate = new DateTime((int.Parse(cmbStYear.SelectedValue) - 1), int.Parse("1"), int.Parse("1"));
            dLYToDate = new DateTime((int.Parse(cmbStYear.SelectedValue) - 1), int.Parse("12"), int.Parse("31"));          

            //for outstanding- Starting Date and Ending Date
            dFromDate = new DateTime((int.Parse(cmbStYear.SelectedValue)), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
            dToDate = DateTime.Today.Date;
          


        }
        catch
        {
            this.lblFromDateError.Visible = true;
            this.lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }

        if (rdoCustomer.Checked == true)
        {
            sReportType = rdoCustomer.Text;
            GetMonthlySalesVsCollectionCustomerWise();
           
        }
        if (rdoSBU.Checked == true)
        {
            sReportType = rdoSBU.Text;
            GetMonthlySalesVsCollectionSBUWise();
           
        }
        if (rdoChannel.Checked == true)
        {
            sReportType = rdoChannel.Text;
            GetMonthlySalesVsCollectionChannelWise();
           
        }
        if (rdoArea.Checked == true)
        {
            sReportType = rdoArea.Text;
            GetMonthlySalesVsCollectionChannelWise();
           
        }
        if (rdoTerritory.Checked == true)
        {
            sReportType = rdoTerritory.Text;
            GetMonthlySalesVsCollectionTerritoryWise();
          
        }
        if (rdoParentCustomer.Checked == true)
        {
            sReportType = rdoParentCustomer.Text;
            GetYearlyMonthlySalesVsCollectionCustomerWise();           
        }
    
    }

    private void GetMonthlySalesVsCollectionCustomerWise()
    {
        try
        {
            _orptSalesVSCollections = new rptSalesVSCollections();
            DBController.Instance.OpenNewConnection();
            _orptSalesVSCollections.GetMonthlySalesVsCollectionCustomerWise(dCYFromDate, dCYToDate, dLYCFromDate, dLYCToDate, dLYFromDate, dLYToDate, dFromDate, dToDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  (Customer Wise) =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = _orptSalesVSCollections.ToDataSet();

        string sExpr = "";
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

        if (int.Parse(cmbArea.SelectedValue) != -1)
        {
            sExpr = sExpr + " and AreaId = '" + cmbArea.SelectedValue + "'";
        }
        else sExpr = sExpr + " and AreaId in (" + GetAllArea() + ")";

        if (int.Parse(cmbTerritory.SelectedValue) != -1)
        {
            sExpr = sExpr + " and TerritoryId = '" + cmbTerritory.SelectedValue + "'";
        }
        else sExpr = sExpr + " and TerritoryId in (" + GetAllTerritory() + ")";

        if (int.Parse(cmbCustType.SelectedValue) != -1)
        {
            sExpr = sExpr + " and CustomerTypeID = '" + cmbCustType.SelectedValue + "'";
        }
        else sExpr = sExpr + " and CustomerTypeID in (" + GetAllCustomerType() + ")";

        if (Convert.ToInt16(cmbActive.SelectedValue.ToString()) != 2)
        {
            sExpr = sExpr + " and IsActive = '" + cmbActive.SelectedValue + "'";
        }

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _orptSalesVSCollections.FromDataSetCustomerWise(_oDS);
        else _orptSalesVSCollections = null;

        if (_orptSalesVSCollections != null)
        {          
            lblMessage.Visible = false;

            string sCompanyName = Utility.CompanyName;
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMonthlySalesVsCollectionCustomerWise));

            doc.SetDataSource(_orptSalesVSCollections);
            doc.SetParameterValue("CompanyName", sCompanyName);

            doc.SetParameterValue("SBU", cmbSBU.SelectedItem.Text);
            doc.SetParameterValue("Channel", cmbChannel.SelectedItem.Text);
            doc.SetParameterValue("Area", cmbArea.SelectedItem.Text);
            doc.SetParameterValue("Territory", cmbTerritory.SelectedItem.Text);
            doc.SetParameterValue("CustomerType", cmbCustType.SelectedItem.Text);
            doc.SetParameterValue("User Name", this.Context.User.Identity.Name);
            doc.SetParameterValue("StDate", dLYCFromDate);
            doc.SetParameterValue("EndDate", dLYCToDate);

            doc.SetParameterValue("Report_Name", "Yearly Month Wise Sales Vs Collection "+ sReportType +" [235]");
            Session["ReportName"] = Table2.Rows[0].Cells[0].InnerText.Trim();
            Session["Doc"] = (object)doc;

            Response.Redirect("frmReportViewer.aspx");
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Data";
            return;
        }
    }

    private void GetYearlyMonthlySalesVsCollectionCustomerWise()
    {
        try
        {
            _orptSalesVSCollections = new rptSalesVSCollections();
            DBController.Instance.OpenNewConnection();
            _orptSalesVSCollections.GetYearlyMonthlySalesVsCollectionParentCustomerWise(dCYFromDate, dCYToDate,dFromDate, dToDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  Yearly Month Wise Sales Vs Collection " + sReportType + ex);
            this.lblMessage.Visible = true;
            this.lblMessage.Text = "Error....";
            return;
        }

        DataSet oDS = new DataSet();
        oDS = _orptSalesVSCollections.ToDataSet();

        string sExpr = "";
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

       
        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _orptSalesVSCollections.FromDataSetParentCustomerWise(_oDS);
        else _orptSalesVSCollections = null;

        if (_orptSalesVSCollections != null)
        {
            lblMessage.Visible = false;

            string sCompanyName = Utility.CompanyName;
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMonthlySalesVsCollectionParentCustomerWise));

            doc.SetDataSource(_orptSalesVSCollections);
            doc.SetParameterValue("CompanyName", sCompanyName);

            doc.SetParameterValue("SBU", cmbSBU.SelectedItem.Text);
            doc.SetParameterValue("Channel", cmbChannel.SelectedItem.Text);        
            doc.SetParameterValue("User Name", this.Context.User.Identity.Name);
            doc.SetParameterValue("StDate", dLYCFromDate);
            doc.SetParameterValue("EndDate", dLYCToDate);

            doc.SetParameterValue("Report_Name", "Yearly Month Wise Sales Vs Collection " + sReportType + " [235]");
            Session["ReportName"] = Table2.Rows[0].Cells[0].InnerText.Trim();
            Session["Doc"] = (object)doc;

            Response.Redirect("frmReportViewer.aspx");
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Data";
            return;
        }
    }

    private void GetMonthlySalesVsCollectionSBUWise()
    {
        try
        {
            _orptSalesVSCollections = new rptSalesVSCollections();
            DBController.Instance.OpenNewConnection();
            _orptSalesVSCollections.GetMonthlySalesVsCollectionSBUWise(dCYFromDate, dCYToDate, dLYCFromDate, dLYCToDate, dLYFromDate, dLYToDate, dFromDate, dToDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  Yearly Month Wise Sales Vs Collection " + sReportType  + ex);
            this.lblMessage.Visible = true;
            this.lblMessage.Text = "Error....";
            return;
        }

        DataSet oDS = new DataSet();
        oDS = _orptSalesVSCollections.ToDataSet();

        string sExpr = "";
       
        if (int.Parse(cmbSBU.SelectedValue) != -1)
        {
            sExpr = sExpr + " SBUID = '" + cmbSBU.SelectedValue + "'";
        }
        else sExpr = sExpr + " SBUID in (" + GetAllSBU() + ")";
      
        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _orptSalesVSCollections.FromDataSetSBUWise(_oDS);
        else _orptSalesVSCollections = null;

        if (_orptSalesVSCollections != null)
        {
            lblMessage.Visible = false;

            string sCompanyName = Utility.CompanyName;
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMonthlySalesVsCollectionSBUWise));

            doc.SetDataSource(_orptSalesVSCollections);
            doc.SetParameterValue("CompanyName", sCompanyName);

            doc.SetParameterValue("SBU", cmbSBU.SelectedItem.Text);         
            doc.SetParameterValue("User Name", this.Context.User.Identity.Name);
            doc.SetParameterValue("StDate", dLYCFromDate);
            doc.SetParameterValue("EndDate", dLYCToDate);

            doc.SetParameterValue("Report_Name", "Yearly Month Wise Sales Vs Collection " + sReportType + " [235]");
            Session["ReportName"] = "Yearly Month Wise Sales Vs Collection " + sReportType + " [235]";
            Session["Doc"] = (object)doc;

            Response.Redirect("frmReportViewer.aspx");
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Data";
            return;
        }
    }

    private void GetMonthlySalesVsCollectionChannelWise()
    {
        try
        {
            _orptSalesVSCollections = new rptSalesVSCollections();
            DBController.Instance.OpenNewConnection();
            _orptSalesVSCollections.GetMonthlySalesVsCollectionChannelWise(dCYFromDate, dCYToDate, dLYCFromDate, dLYCToDate, dLYFromDate, dLYToDate, dFromDate, dToDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  Yearly Month Wise Sales Vs Collection " + sReportType + ex);
            this.lblMessage.Visible = true;
            this.lblMessage.Text = "Error....";
            return;
        }

        DataSet oDS = new DataSet();
        oDS = _orptSalesVSCollections.ToDataSet();

        string sExpr = "";

        if (int.Parse(cmbSBU.SelectedValue) != -1)
        {
            sExpr = sExpr + " SBUID = '" + cmbSBU.SelectedValue + "'";
        }
        else sExpr = sExpr + " SBUID in (" + GetAllSBU() + ")";

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
            _orptSalesVSCollections.FromDataSetChannelWise(_oDS);
        else _orptSalesVSCollections = null;

        if (_orptSalesVSCollections != null)
        {
            lblMessage.Visible = false;

            string sCompanyName = Utility.CompanyName;
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMonthlySalesVsCollectionChannelWise));

            doc.SetDataSource(_orptSalesVSCollections);
            doc.SetParameterValue("CompanyName", sCompanyName);

            doc.SetParameterValue("SBU", cmbSBU.SelectedItem.Text);
            doc.SetParameterValue("Channel", cmbChannel.SelectedItem.Text);
            doc.SetParameterValue("User Name", this.Context.User.Identity.Name);
            doc.SetParameterValue("StDate", dLYCFromDate);
            doc.SetParameterValue("EndDate", dLYCToDate);

            doc.SetParameterValue("Report_Name", "Yearly Month Wise Sales Vs Collection " + sReportType + " [235]");
            Session["ReportName"] = "Yearly Month Wise Sales Vs Collection " + sReportType + " [235]";
            Session["Doc"] = (object)doc;

            Response.Redirect("frmReportViewer.aspx");
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Data";
            return;
        }
    }

    private void GetMonthlySalesVsCollectionAreaWise()
    {
        try
        {
            _orptSalesVSCollections = new rptSalesVSCollections();
            DBController.Instance.OpenNewConnection();
            _orptSalesVSCollections.GetMonthlySalesVsCollectionAreaWise(dCYFromDate, dCYToDate, dLYCFromDate, dLYCToDate, dLYFromDate, dLYToDate, dFromDate, dToDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  Yearly Month Wise Sales Vs Collection " + sReportType + ex);
            this.lblMessage.Visible = true;
            this.lblMessage.Text = "Error....";
            return;
        }

        DataSet oDS = new DataSet();
        oDS = _orptSalesVSCollections.ToDataSet();

        string sExpr = "";

        if (int.Parse(cmbSBU.SelectedValue) != -1)
        {
            sExpr = sExpr + " SBUID = '" + cmbSBU.SelectedValue + "'";
        }
        else sExpr = sExpr + " SBUID in (" + GetAllSBU() + ")";

        if (int.Parse(cmbChannel.SelectedValue) != -1)
        {
            sExpr = sExpr + " and ChannelId = '" + cmbChannel.SelectedValue + "'";
        }
        else sExpr = sExpr + " and ChannelId in (" + GetAllChannel() + ")";

        if (int.Parse(cmbArea.SelectedValue) != -1)
        {
            sExpr = sExpr + " and AreaId = '" + cmbArea.SelectedValue + "'";
        }
        else sExpr = sExpr + " and AreaId in (" + GetAllArea() + ")";

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _orptSalesVSCollections.FromDataSetAreaWise(_oDS);
        else _orptSalesVSCollections = null;

        if (_orptSalesVSCollections != null)
        {
            lblMessage.Visible = false;

            string sCompanyName = Utility.CompanyName;
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMonthlySalesVsCollectionAreaWise));

            doc.SetDataSource(_orptSalesVSCollections);
            doc.SetParameterValue("CompanyName", sCompanyName);

            doc.SetParameterValue("SBU", cmbSBU.SelectedItem.Text);
            doc.SetParameterValue("Channel", cmbChannel.SelectedItem.Text);
            doc.SetParameterValue("Area", cmbArea.SelectedItem.Text);
            doc.SetParameterValue("User Name", this.Context.User.Identity.Name);
            doc.SetParameterValue("StDate", dLYCFromDate);
            doc.SetParameterValue("EndDate", dLYCToDate);

            doc.SetParameterValue("Report_Name", "Yearly Month Wise Sales Vs Collection " + sReportType + " [235]");
            Session["ReportName"] = "Yearly Month Wise Sales Vs Collection " + sReportType + " [235]";
            Session["Doc"] = (object)doc;

            Response.Redirect("frmReportViewer.aspx");
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Data";
            return;
        }
    }

    private void GetMonthlySalesVsCollectionTerritoryWise()
    {
        try
        {
            _orptSalesVSCollections = new rptSalesVSCollections();
            DBController.Instance.OpenNewConnection();
            _orptSalesVSCollections.GetMonthlySalesVsCollectionTerritoryWise(dCYFromDate, dCYToDate, dLYCFromDate, dLYCToDate, dLYFromDate, dLYToDate, dFromDate, dToDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  Yearly Month Wise Sales Vs Collection " + sReportType + ex);
            this.lblMessage.Visible = true;
            this.lblMessage.Text = "Error....";
            return;
        }

        DataSet oDS = new DataSet();
        oDS = _orptSalesVSCollections.ToDataSet();

        string sExpr = "";

        if (int.Parse(cmbSBU.SelectedValue) != -1)
        {
            sExpr = sExpr + " SBUID = '" + cmbSBU.SelectedValue + "'";
        }
        else sExpr = sExpr + " SBUID in (" + GetAllSBU() + ")";

        if (int.Parse(cmbChannel.SelectedValue) != -1)
        {
            sExpr = sExpr + " and ChannelId = '" + cmbChannel.SelectedValue + "'";
        }
        else sExpr = sExpr + " and ChannelId in (" + GetAllChannel() + ")";

        if (int.Parse(cmbArea.SelectedValue) != -1)
        {
            sExpr = sExpr + " and AreaId = '" + cmbArea.SelectedValue + "'";
        }
        else sExpr = sExpr + " and AreaId in (" + GetAllArea() + ")";

        if (int.Parse(cmbTerritory.SelectedValue) != -1)
        {
            sExpr = sExpr + " and TerritoryId = '" + cmbTerritory.SelectedValue + "'";
        }
        else sExpr = sExpr + " and TerritoryId in (" + GetAllTerritory() + ")";

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _orptSalesVSCollections.FromDataSetTerritoryWise(_oDS);
        else _orptSalesVSCollections = null;

        if (_orptSalesVSCollections != null)
        {
            lblMessage.Visible = false;

            string sCompanyName = Utility.CompanyName;
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMonthlySalesVsCollectionTerritoryWise));

            doc.SetDataSource(_orptSalesVSCollections);
            doc.SetParameterValue("CompanyName", sCompanyName);

            doc.SetParameterValue("SBU", cmbSBU.SelectedItem.Text);
            doc.SetParameterValue("Channel", cmbChannel.SelectedItem.Text);
            doc.SetParameterValue("Area", cmbArea.SelectedItem.Text);
            doc.SetParameterValue("Territory", cmbTerritory.SelectedItem.Text);
            doc.SetParameterValue("User Name", this.Context.User.Identity.Name);
            doc.SetParameterValue("StDate", dLYCFromDate);
            doc.SetParameterValue("EndDate", dLYCToDate);

            doc.SetParameterValue("Report_Name", "Yearly Month Wise Sales Vs Collection " + sReportType + " [235]");
            Session["ReportName"] = "Yearly Month Wise Sales Vs Collection " + sReportType + " [235]";
            Session["Doc"] = (object)doc;

            Response.Redirect("frmReportViewer.aspx");
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "No Data";
            return;
        }
    }
   
}

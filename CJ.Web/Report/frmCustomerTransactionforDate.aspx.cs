using System;
using CJ.Class;
using CJ.Class.Report;
using CJ.Report;

public partial class Report_frmCustomerTransactionforDate : System.Web.UI.Page
{
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    Utilities _oUtilities;
    Users _oUsers;
    CustomerTranTypes _oCustomerTranTypes;

    RptCustomerTransactionDetails _oRptCustomerTransactionDetails;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {
            cmbStDay.Text = DateTime.Today.Day.ToString();
            cmbStMonth.Text = DateTime.Today.Month.ToString();
            cmbStYear.Text = DateTime.Today.Year.ToString();

            cmbEndDay.Text = DateTime.Today.Day.ToString();
            cmbEndMonth.Text = DateTime.Today.Month.ToString();
            cmbEndYear.Text = DateTime.Today.Year.ToString();

            LoadAllCombo();

        }
    }
       public void LoadAllCombo()
        {
        DBController.Instance.OpenNewConnection();
        User oUser = (User)Session["User"];
        
        SBUs oSbUs = new SBUs();
        oSbUs.GetSBU(oUser.UserId);
        if (oSbUs.Count > 0)
        {
            Session.Add("SBU", oSbUs);
            cmbSBU.DataTextField = "SBUName";
            cmbSBU.DataValueField = "SBUID";
            cmbSBU.DataSource = oSbUs;
            cmbSBU.DataBind();
            cmbSBU.SelectedIndex = oSbUs.Count - 1;
        }
        else
        {
            SBU oSbu = new SBU();
            oSbu.SBUID = 0;
            oSbu.SBUName = "No Permission";
            oSbUs.Add(oSbu);

            cmbSBU.DataTextField = "SBUName";
            cmbSBU.DataValueField = "SBUID";
            cmbSBU.DataSource = oSbu;
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

        _oCustomerTranTypes = new CustomerTranTypes();
        _oCustomerTranTypes.RefreshWithAll();
        cmbTranType.Items.Clear();
        if (oSbUs.Count > 0)
        {
            Session.Add("CustomerTranType", _oCustomerTranTypes);
            cmbTranType.DataTextField = "TranTypeName";
            cmbTranType.DataValueField = "TranTypeID";
            cmbTranType.DataSource = _oCustomerTranTypes;
            cmbTranType.DataBind();
            cmbTranType.SelectedIndex = _oCustomerTranTypes.Count - 1;
        }

        //Status
        cmbTranSide.Items.Clear();
        cmbTranSide.Items.Add("ALL");
        foreach (int getEnum in Enum.GetValues(typeof(Dictionary.TransectionSide)))
        {
            cmbTranSide.Items.Add(Enum.GetName(typeof(Dictionary.TransectionSide), getEnum));
        }
        cmbTranSide.SelectedIndex = 0;
    }
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        SBUs sbUs = (SBUs)Session["SBU"];
        Channels oChannels = (Channels)Session["Channel"];
        MarketGroups oArea = (MarketGroups)Session["Area"];

        if (cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0" && cmbStDay.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
        }
        else
        {
            lblDateError.Visible = true;
            lblDateError.Text = @"Please select valid date ";
            return;
        }
        if (cmbEndMonth.SelectedValue != "0" && cmbEndYear.SelectedValue != "0" && cmbEndDay.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cmbEndYear.SelectedValue), int.Parse(cmbEndMonth.SelectedValue), int.Parse(cmbEndDay.SelectedValue));
        }
        else
        {
            lblDateError1.Visible = true;
            lblDateError1.Text = @"Please select valid date ";
            return;
        }

        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate;
        string sExpr = "";
        if ((txtName.Text) != "")
        {
            sExpr = " and CustomerName like '%" + txtName.Text.Trim() + "%'";
        }
        if ((txtCustomerCode.Text) != "")
        {
            sExpr = sExpr + " and CustomerCode = '" + txtCustomerCode.Text + "'";
        }
        if (cmbTranSide.SelectedIndex != 0)
        {
            sExpr = sExpr + " and TranSide = " + cmbTranSide.SelectedIndex + "";
        }
        if (int.Parse(cmbTranType.SelectedValue) != -1)
        {
            sExpr = sExpr + " and TranTypeID = '" + cmbTranType.SelectedValue + "'";
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
            sExpr = sExpr + " and TerritoryId = '" + cmbTerritory.SelectedValue + "'";
        }
        _oRptCustomerTransactionDetails = new RptCustomerTransactionDetails();
        DBController.Instance.OpenNewConnection();
        _oRptCustomerTransactionDetails.CustomerTransaction(_dStartingDate, _dEndingDate, sExpr);
        DBController.Instance.CloseConnection();
        //DataSet oDS = new DataSet();
        //oDS = _oRptCustomerTransactionDetails.ToDataSet();

        //string sExpr = "";

        //sExpr = " CustomerName like '%" + txtName.Text.Trim() + "%'";

        //if ((txtCustomerCode.Text) != "")
        //{
        //    sExpr = sExpr + " and CustomerCode = '" + txtCustomerCode.Text + "'";
        //}
        
        
        //if ((cmbTranSide.SelectedIndex) != -1)
        //{
        //    sExpr = sExpr + " and TranSide = '" + cmbTranSide.SelectedIndex + "'";
        //}

        //if (int.Parse(cmbSBU.SelectedValue) != -1)
        //{
        //    sExpr = sExpr + " and SBUID = '" + cmbSBU.SelectedValue + "'";
        //}
        //else sExpr = sExpr + " and SBUID in (" + GetAllSBU() + ")";

        //if (int.Parse(cmbChannel.SelectedValue) != -1)
        //{
        //    sExpr = sExpr + " and ChannelID = '" + cmbChannel.SelectedValue + "'";
        //}
        //else sExpr = sExpr + " and ChannelID in (" + GetAllChannel() + ")";

        //if (int.Parse(cmbArea.SelectedValue) != -1)
        //{
        //    sExpr = sExpr + " and AreaID = '" + cmbArea.SelectedValue + "'";
        //}
        //else sExpr = sExpr + " and AreaID in (" + GetAllArea() + ")";

        //if (int.Parse(cmbTerritory.SelectedValue) != -1)
        //{
        //    sExpr = sExpr + " and TerritoryId = '" + cmbTerritory.SelectedValue + "'";
        //}
        //else sExpr = sExpr + " and TerritoryId in (" + GetAllTerritory() + ")";

                

        //DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        //DataSet _oDS = new DataSet();
        //_oDS.Merge(oDR);
        //_oDS.AcceptChanges();
        //if (_oDS.Tables.Count > 0)
        //    _oRptCustomerTransactionDetails.FromDataSetCustomerTransaction(_oDS);
        //else _oRptCustomerTransactionDetails = null;

        if (_oRptCustomerTransactionDetails.Count > 0)
        {
            FillReport();
        }
        else
        {
            lbMsg.Visible = true;
            lbMsg.Text = @" No Data ";
        }

    }

    public void FillReport()
    {
        string sCompanyName = Utility.CompanyName;
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCustomerTransactionforDate_ ));

        doc.SetDataSource(_oRptCustomerTransactionDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("SBU", cmbSBU.SelectedItem.Text);
        doc.SetParameterValue("Channel", cmbChannel.SelectedItem.Text);
        doc.SetParameterValue("Area", cmbArea.SelectedItem.Text);
        doc.SetParameterValue("Territory", cmbTerritory.SelectedItem.Text);          
        doc.SetParameterValue("StDate", _dStartingDate);
        doc.SetParameterValue("EndDate", _dEndingDate);
        doc.SetParameterValue("ReportName", "Customer Transaction Register Date Range Wise [805]");
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
        Session["Doc"] = (object)doc;
        Response.Redirect("frmReportViewer.aspx");

    }
    //public string GetAllSBU()
    //{
    //    SBUs _oSBUs = (SBUs)Session["SBU"];
    //    string sPermission = "";

    //    foreach (SBU oSBU in _oSBUs)
    //    {
    //        if (sPermission == "")
    //            sPermission = oSBU.SBUID.ToString();
    //        else
    //            sPermission = sPermission + "," + oSBU.SBUID.ToString();

    //    }
    //    return sPermission;
    //}
    //public string GetAllChannel()
    //{
    //    Channels _oChannels = (Channels)Session["Channel"];
    //    string sPermission = "";

    //    foreach (Channel oChannel in _oChannels)
    //    {
    //        if (sPermission == "")
    //            sPermission = oChannel.ChannelID.ToString();
    //        else
    //            sPermission = sPermission + "," + oChannel.ChannelID.ToString();

    //    }
    //    return sPermission;
    //}
    //public string GetAllArea()
    //{
    //    MarketGroups _oMarketGroups = (MarketGroups)Session["Area"];
    //    string sPermission = "";

    //    foreach (MarketGroup oMarketGroup in _oMarketGroups)
    //    {
    //        if (sPermission == "")
    //            sPermission = oMarketGroup.MarketGroupID.ToString();
    //        else
    //            sPermission = sPermission + "," + oMarketGroup.MarketGroupID.ToString();

    //    }
    //    return sPermission;
    //}
    //public string GetAllTerritory()
    //{
    //    MarketGroups _oMarketGroups = (MarketGroups)Session["Territory"];
    //    string sPermission = "";

    //    foreach (MarketGroup oMarketGroup in _oMarketGroups)
    //    {
    //        if (sPermission == "")
    //            sPermission = oMarketGroup.MarketGroupID.ToString();
    //        else
    //            sPermission = sPermission + "," + oMarketGroup.MarketGroupID.ToString();

    //    }
    //    return sPermission;
    //}


}

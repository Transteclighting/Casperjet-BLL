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

public partial class Report_frmDateRangewiseNetsalesWithGrossMarginChannelandASG_wise : System.Web.UI.Page
{
    private ChannelASGwiseProfitabilityDetails _oChannelASGwiseProfitabilityDetails;
    
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    SBUs _oSBUs;
    Channels _oChannels;
    ProductGroups _oProductGroups;
    


    protected void Page_Load(object sender, EventArgs e)
     {
         try
        {
            DBController.Instance.OpenNewConnection();
            if (!IsPostBack)
            {

            cmbStDay.Text = DateTime.Today.Day.ToString();
            cmbStMonth.Text = DateTime.Today.Month.ToString();
            cmbStYear.Text = DateTime.Today.Year.ToString();

            cmbEndDay.Text = DateTime.Today.Day.ToString();
            cmbEndMonth.Text = DateTime.Today.Month.ToString();
            cmbEndYear.Text= DateTime.Today.Year.ToString();

            Loadcb();
            }
        DBController.Instance.CloseConnection();
         }
        catch (Exception ex)
         {
        AppLogger.LogError("Web: error in Load All Combo (Area Wise) =" + ex);
         }
        
    }

    public void Loadcb()
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
        
        ProductGroups oProductGroups = new ProductGroups();
        oProductGroups.GETPG();

        cmbProductType.DataTextField = "PdtGroupName";
        cmbProductType.DataValueField = "PdtGroupId";
        cmbProductType.DataSource = oProductGroups;
        cmbProductType.DataBind();
        cmbProductType.SelectedIndex = oProductGroups.Count - 1;

        ProductGroups oMAG = new ProductGroups();
        oMAG.GETMAG();

        cmbMAG.DataTextField = "PdtGroupName";
        cmbMAG.DataValueField = "PdtGroupId";
        cmbMAG.DataSource = oMAG;
        cmbMAG.DataBind();
        cmbMAG.SelectedIndex = oMAG.Count - 1;

        ProductGroups oASG = new ProductGroups();
        oASG.GETASG();
        cmbASG.DataTextField = "PdtGroupName";
        cmbASG.DataValueField = "PdtGroupId";
        cmbASG.DataSource = oASG;
        cmbASG.DataBind();
        cmbASG.SelectedIndex = oASG.Count - 1;
        
        
        Brands oBrands = new Brands();
        oBrands.GetBrand();
        cmbBrand.DataTextField = "BrandDesc";
        cmbBrand.DataValueField = "BrandID";
        cmbBrand.DataSource = oBrands;
        cmbBrand.DataBind();
        cmbBrand.SelectedIndex = oBrands.Count - 1;
         
    }

    protected void btnShowReport_Click(object sender, EventArgs e)
    {

    }
    protected void lnkShowReportB_Click(object sender, EventArgs e)
    {
        SBUs _SBUs = (SBUs)Session["SBU"];
        Channels _oChannels = (Channels)Session["Channel"];
        ProductGroups _oProductGroups = (ProductGroups)Session["ProductGroups"];
                
        if (cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0" && cmbStDay.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
        }
        else
        {
            //this.lblFromDateError.Visible = true;
            //this.lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }
        if (cmbEndMonth.SelectedValue != "0" && cmbEndYear.SelectedValue != "0" && cmbEndDay.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cmbEndYear.SelectedValue), int.Parse(cmbEndMonth.SelectedValue), int.Parse(cmbEndDay.SelectedValue));
        }
        else
        {
            //this.lblFromDateError.Visible = true;
            //this.lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }
        
        // Begin 
        _oChannelASGwiseProfitabilityDetails = new ChannelASGwiseProfitabilityDetails();
        DBController.Instance.OpenNewConnection();
        _oChannelASGwiseProfitabilityDetails.ASGWiseProfitability(_dStartingDate, _dEndingDate.AddDays(1));
        DBController.Instance.CloseConnection();
        
        DataSet oDS = new DataSet();
        oDS = _oChannelASGwiseProfitabilityDetails.ToDataSet();
        string sExpr = "";
        
        //sExpr = "CustomerName like '%" + txtName.Text.Trim() + "%'";

        if (int.Parse(cmbSBU.SelectedValue) != -1)
        {
            sExpr = sExpr + " SBUID = '" + cmbSBU.SelectedValue + "'";
        }
        else sExpr = sExpr + " SBUID in (" + GetAllSBU() + ")";
        
        if (int.Parse(cmbChannel.SelectedValue) != -1)
        {
            sExpr = sExpr + " and ChannelID = '" + cmbChannel.SelectedValue + "'";
        }
        else sExpr = sExpr + " and ChannelID in (" + GetAllChannel() + ")";

        if (int.Parse(cmbProductType.SelectedValue) != -1)
        {
            sExpr = sExpr + " and PGID = '" + cmbProductType.SelectedValue + "'";
        }
        if (int.Parse(cmbMAG.SelectedValue) != -1)
        {
            sExpr = sExpr + " and MAGID = '" + cmbMAG.SelectedValue + "'";
        }
        if (int.Parse(cmbASG.SelectedValue) != -1)
        {
            sExpr = sExpr + " and ASGID = '" + cmbASG.SelectedValue + "'";
        }
        if (int.Parse(cmbBrand.SelectedValue) != -1)
        {
            sExpr = sExpr + " and BrandID = '" + cmbBrand.SelectedValue + "'";
        }

        
        
        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            _oChannelASGwiseProfitabilityDetails.FromDataSetASGWiseProfitability(_oDS);
        else _oChannelASGwiseProfitabilityDetails = null;

        if (_oChannelASGwiseProfitabilityDetails.Count > 0)
        {
            FillReport();
        }
        
    }

    private void getASGWiseProfitability()
    {       
       
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate.AddDays(1);

      
        //SBU _oSBU = (SBU)Session["SBU"];
        //Channels _oChanneles = (Channels)Session["Channeles"];
        
        
        
        _oChannelASGwiseProfitabilityDetails = new ChannelASGwiseProfitabilityDetails();

      

        try
        {
            DBController.Instance.OpenNewConnection();

            _oChannelASGwiseProfitabilityDetails.ASGWiseProfitability(_dStartingDate, _dEndingDate);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Customer Transaction Ledger =" + ex);
        }

    }

    private void FillReport()
    {
        string sCompanyName = Utility.CompanyName;

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof( rptChannelASGWiseProfitability));

        doc.SetDataSource(_oChannelASGwiseProfitabilityDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("StDay", _dStartingDate);
        doc.SetParameterValue("EndDay", _dEndingDate);
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

}

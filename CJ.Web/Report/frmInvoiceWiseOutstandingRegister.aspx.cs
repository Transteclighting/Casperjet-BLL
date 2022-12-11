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

public partial class Report_frmInvoiceWiseOutstandingRegister : System.Web.UI.Page
{
    InvoiceWiseOutstandingRegisterReport oInvoiceWiseOutstandingRegisterReport;

    protected void Page_Load(object sender, EventArgs e)
    {
         DBController.Instance.OpenNewConnection();
         if (!IsPostBack)
         {
             LoadAllCombo();
             this.cboFRDay.Text = DateTime.Today.Day.ToString();
             this.cboFRMonth.Text = DateTime.Today.Month.ToString();
             this.cboFRYear.Text = DateTime.Today.Year.ToString();
         }
         DBController.Instance.CloseConnection();
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
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        getDailySalesReportCustomerWise();
    }


    private void getDailySalesReportCustomerWise()
    {
      
        try
        {
            oInvoiceWiseOutstandingRegisterReport = new  InvoiceWiseOutstandingRegisterReport();
            DBController.Instance.OpenNewConnection();
            oInvoiceWiseOutstandingRegisterReport.InvoiceWiseOutstandingRegister();
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Daily Sales Report (Customer Wise) =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = oInvoiceWiseOutstandingRegisterReport.ToDataSet();

        string sExp = "";
  
        sExp = "CustomerName like '%" + txtName.Text.Trim() + "%'";

        if (txtCustomerCode.Text.Trim() != "")
        {
            sExp = sExp + " and CustomerCode = '" + txtCustomerCode.Text.Trim() + "'";
        }

        if (txtRefCustomerCode.Text.Trim() != "")
        {
            sExp = sExp + " and ParentCustomerCode = '" + txtRefCustomerCode.Text.Trim() + "'";
        }

        if (txtRefCustomerName.Text.Trim() != "")
        {
            sExp = sExp + " and ParentCustomerName Like  '%" + txtRefCustomerName.Text.Trim() + "%'";
        }

        if (int.Parse(cmbSBU.SelectedValue) != -1)
        {
            sExp = sExp + " and SBUID = '" + cmbSBU.SelectedValue + "'";
        }
        else sExp = sExp + " and SBUID in (" + GetAllSBU() + ")";

        if (int.Parse(cmbChannel.SelectedValue) != -1)
        {
            sExp = sExp + " and ChannelId = '" + cmbChannel.SelectedValue + "'";
        }
        else sExp = sExp + " and ChannelId in (" + GetAllChannel() + ")";

        if (int.Parse(cmbArea.SelectedValue) != -1)
        {
            sExp = sExp + " and AreaId = '" + cmbArea.SelectedValue + "'";
        }
        else sExp = sExp + " and AreaId in (" + GetAllArea() + ")";

        if (int.Parse(cmbTerritory.SelectedValue) != -1)
        {
            sExp = sExp + " and TerritoryId = '" + cmbTerritory.SelectedValue + "'";
        }
        else sExp = sExp + " and TerritoryId in (" + GetAllTerritory() + ")";

        DataRow[] oDR = oDS.Tables[0].Select(sExp);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            oInvoiceWiseOutstandingRegisterReport.FromDataSetForInvoiceWiseOutstandingRegister(_oDS);
        else oInvoiceWiseOutstandingRegisterReport = null;

        if (oInvoiceWiseOutstandingRegisterReport != null)
        {
            string sCompanyName = Utility.CompanyName;
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptInvoiceWiseOutstandingRegister));

            doc.SetDataSource(oInvoiceWiseOutstandingRegisterReport);
            doc.SetParameterValue("CompanyName", sCompanyName);
            doc.SetParameterValue("PrintedBy", this.Context.User.Identity.Name);
            doc.SetParameterValue("Report_Name", Table2.Rows[0].Cells[0].InnerText.Trim());
            Session["ReportName"] = Table2.Rows[0].Cells[0].InnerText.Trim();
            Session["Doc"] = (object)doc;
            Response.Redirect("frmReportViewer.aspx");
        }
    }

   
}

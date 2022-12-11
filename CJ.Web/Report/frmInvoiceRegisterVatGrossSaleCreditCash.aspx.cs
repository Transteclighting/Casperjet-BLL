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


public partial class Report_frmInvoiceRegisterVatGrossSaleCreditCash : System.Web.UI.Page
{
    DateTime _dStartingDate;
    DateTime _dEndingDate;

    long _nFromVATChallanNo;
    long _nToVATChallanNo;
    InvoiceRegisterWithVatGrosssaleReport oInvoiceRegisterWithVatGrosssaleReport;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DBController.Instance.OpenNewConnection();
            if (!IsPostBack)
            {
                LoadAllCombo();
                ////From Date
                this.cboFrDay.Text = DateTime.Today.Date.Day.ToString();
                this.cboFrMonth.Text = DateTime.Today.Date.Month.ToString();
                this.cboFrYear.Text = DateTime.Today.Date.Year.ToString();
                ////To Date
                this.cboToDay.Text = DateTime.Today.Date.Day.ToString();
                this.cboToMonth.Text = DateTime.Today.Date.Month.ToString();
                this.cboToYear.Text = DateTime.Today.Date.Year.ToString();
            }
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Load All Combo () =" + ex);
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
        cmbCustomerType.DataTextField = "CustTypeDescription";
        cmbCustomerType.DataValueField = "CustTypeID";
        cmbCustomerType.DataSource = oCustomerTypies;
        cmbCustomerType.DataBind();
        cmbCustomerType.SelectedIndex = oCustomerTypies.Count - 1;

        GeoLocations oDistrict = new GeoLocations();
        oDistrict.GetAllDistrict();
        Session.Add("District", oDistrict);
        cmbDistrict.DataTextField = "GeoLocationName";
        cmbDistrict.DataValueField = "GeoLocationID";
        cmbDistrict.DataSource = oDistrict;
        cmbDistrict.DataBind();
        cmbDistrict.SelectedIndex = oDistrict.Count - 1;

        GeoLocations oThana = new GeoLocations();
        oThana.GetAllDistrict();
        Session.Add("Thana", oThana);
        cmbThana.DataTextField = "GeoLocationName";
        cmbThana.DataValueField = "GeoLocationID";
        cmbThana.DataSource = oThana;
        cmbThana.DataBind();
        cmbThana.SelectedIndex = oThana.Count - 1;


        Utilities oUtilities = new Utilities();
        oUtilities.GetInoviceType();
        Session.Add("InoviceType", oUtilities);
        cmbInvoiceType.DataTextField = "Satus";
        cmbInvoiceType.DataValueField = "SatusId";
        cmbInvoiceType.DataSource = oUtilities;
        cmbInvoiceType.DataBind();
        cmbInvoiceType.SelectedIndex = oUtilities.Count - 1;

        
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
        int nInvoiceSelectionCriteria = 0;

        if (cboFrDay.SelectedValue != "0" && cboFrMonth.SelectedValue != "0" && cboFrYear.SelectedValue != "0")
        {
            try
            {
                _dStartingDate = new DateTime(int.Parse(cboFrYear.SelectedValue), int.Parse(cboFrMonth.SelectedValue), int.Parse(cboFrDay.SelectedValue));
            }
            catch
            {
                lblFromDate.Visible = true;
                lblFromDate.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
                return;
            }
        }
        else
        {
            lblFromDate.Visible = true;
            lblFromDate.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }

        if (cboToDay.SelectedValue != "0" && cboToMonth.SelectedValue != "0" && cboToYear.SelectedValue != "0")
        {
            try
            {
                _dEndingDate = new DateTime(int.Parse(cboToYear.SelectedValue), int.Parse(cboToMonth.SelectedValue), int.Parse(cboToDay.SelectedValue));
            }
            catch
            {
                lblToDate.Visible = true;
                lblToDate.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
                return;
            }
        }
        else
        {
            lblToDate.Visible = true;
            lblToDate.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }

        if (_dStartingDate > _dEndingDate)
        {
            lblToDate.Visible = true;
            lblToDate.Text = Dictionary.ERR_MSG_INVALID_FORMAT;         
            return;
        }
        try
        {
            if (txtFromVATChallanNo.Text.Trim() != "")
            {
                _nFromVATChallanNo = Convert.ToInt64(txtFromVATChallanNo.Text);
            }
            else
            {
                _nFromVATChallanNo = 0;
            }
        }
        catch
        {
            lblData.Visible = true;
            lblData.Text = "Invalid VAT Challan No";
            return;
        }
        try
        {
            if (txtToVATChallanNo.Text.Trim() != "")
            {
                _nToVATChallanNo = Convert.ToInt64(txtToVATChallanNo.Text);
            }
            else
            {
                _nToVATChallanNo = 0;
            }
        }
        catch
        {
            lblData.Visible = true;
            lblData.Text = "Invalid VAT Challan No";
            return;
        }
        if (_nFromVATChallanNo > 0 && _nToVATChallanNo > 0)
        {
            nInvoiceSelectionCriteria = Convert.ToInt32(Dictionary.InvoiceSelectionCriteria.BETWEEN_VAT_CHALLAN_NO);
        }
        else nInvoiceSelectionCriteria = Convert.ToInt32(Dictionary.InvoiceSelectionCriteria.Between_Date);

        try
        {
            oInvoiceRegisterWithVatGrosssaleReport = new InvoiceRegisterWithVatGrosssaleReport();
            DBController.Instance.OpenNewConnection();
            oInvoiceRegisterWithVatGrosssaleReport.GetInvoiceRegisterWithVatGrosssale(nInvoiceSelectionCriteria,_dStartingDate,_dEndingDate,_nFromVATChallanNo,_nToVATChallanNo,0,0);
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Daily Sales Report (Customer Wise) =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = oInvoiceRegisterWithVatGrosssaleReport.ToDataSet();

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

        if (int.Parse(cmbCustomerType.SelectedValue) != -1)
        {
            sExpr = sExpr + " and CoustomerType = '" + cmbCustomerType.SelectedValue + "'";
        }
        else sExpr = sExpr + " and CoustomerType in (" + GetAllCustomerType() + ")";

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
        if (int.Parse(cmbDistrict.SelectedValue) != -1)
        {
            sExpr = sExpr + " and DistrictID = '" + cmbDistrict.SelectedValue + "'";
        }
        if (int.Parse(cmbThana.SelectedValue) != -1)
        {
            sExpr = sExpr + " and ThanaID = '" + cmbThana.SelectedValue + "'";
        }
        if (Convert.ToInt16(cmbInvoiceType.SelectedValue) != -1)
        {
            sExpr = sExpr + " and InvoiceType ='" + cmbInvoiceType.SelectedValue + "'";
        }

        DataRow[] oDR = oDS.Tables[0].Select(sExpr);

        DataSet _oDS = new DataSet();
        _oDS.Merge(oDR);
        _oDS.AcceptChanges();
        if (_oDS.Tables.Count > 0)
            oInvoiceRegisterWithVatGrosssaleReport.FromDataSetForInvoiceRegisterWithVatGrosssale(_oDS);
        else oInvoiceRegisterWithVatGrosssaleReport = null;


        if (oInvoiceRegisterWithVatGrosssaleReport != null)
        {
            string sCompanyName = Utility.CompanyName;

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptInvoiceRegisterVatGrossSale));
            doc.SetDataSource(oInvoiceRegisterWithVatGrosssaleReport);

            doc.SetParameterValue("CompanyName", sCompanyName);
            doc.SetParameterValue("STDate", _dStartingDate.Date);
            doc.SetParameterValue("EndDate", _dEndingDate.Date);
            doc.SetParameterValue("PrintBy", Context.User.Identity.Name);
            doc.SetParameterValue("Area", cmbArea.SelectedItem.ToString());
            doc.SetParameterValue("Territory", cmbTerritory.SelectedItem.ToString());
            doc.SetParameterValue("SBU", cmbSBU.SelectedItem.ToString());
            doc.SetParameterValue("Channel", cmbChannel.SelectedItem.ToString());
            doc.SetParameterValue("CustomerType", cmbCustomerType.SelectedItem.ToString());
            doc.SetParameterValue("FromVATChallanNo", _nFromVATChallanNo.ToString());
            doc.SetParameterValue("ToVATChallanNo", _nToVATChallanNo.ToString());
            doc.SetParameterValue("Report_Name", Table1.Rows[0].Cells[0].InnerText.Trim());
            Session["ReportName"] = Table1.Rows[0].Cells[0].InnerText.Trim();
            Session["Doc"] = (object)doc;
            Response.Redirect("frmReportViewer.aspx");
        }

    }
}

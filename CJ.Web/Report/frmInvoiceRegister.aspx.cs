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

public partial class Report_frmInvoiceRegister : System.Web.UI.Page
{
    DateTime _dStartingDate = new DateTime();
    DateTime _dEndDate = new DateTime();
    rptInvoiceRegisters _orptInvoiceRegisters;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DBController.Instance.OpenNewConnection();
            if (!IsPostBack)
            {
                LoadAllCombo();
                cboFRDay.Text = DateTime.Today.Date.Day.ToString();
                cboFRMonth.Text = DateTime.Today.Date.Month.ToString();
                cboFRYear.Text = DateTime.Today.Date.Year.ToString();

                cboTODay.Text = DateTime.Today.Date.Day.ToString();
                cboTOMonth.Text = DateTime.Today.Date.Month.ToString();
                cboTOYear.Text = DateTime.Today.Date.Year.ToString();
            }
            DBController.Instance.CloseConnection();
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in Load All Combo (Invoice Register) =" + ex);
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
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        if (cboFRDay.SelectedValue != "0" && cboFRMonth.SelectedValue != "0" && cboFRYear.SelectedValue != "0")
        {
            try
            {
                _dStartingDate = new DateTime(int.Parse(cboFRYear.SelectedValue), int.Parse(cboFRMonth.SelectedValue), int.Parse(cboFRDay.SelectedValue));
            }
            catch
            {
                lblFromDateError.Visible = true;
                lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
                return;
            }
        }
        else
        {
            lblFromDateError.Visible = true;
            lblFromDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }

        if (cboTODay.SelectedValue != "0" && cboTOMonth.SelectedValue != "0" && cboTOYear.SelectedValue != "0")
        {
            try
            {
                _dEndDate = new DateTime(int.Parse(cboTOYear.SelectedValue), int.Parse(cboTOMonth.SelectedValue), int.Parse(cboTODay.SelectedValue));
            }
            catch
            {
                lblToDateError.Visible = true;
                lblToDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
                return;
            }
        }
        else
        {
            lblToDateError.Visible = true;
            lblToDateError.Text = Dictionary.ERR_MSG_INVALID_FORMAT;
            return;
        }
        if(Invoice.Checked==true)
            getInvoiceRegisterReport(); ;
        if (InvoiceDetail.Checked == true)
            getInvoiceRegisterDetailReport();
    }
    private void getInvoiceRegisterReport()
    {
        try
        {
            _orptInvoiceRegisters = new rptInvoiceRegisters(); 
            DBController.Instance.OpenNewConnection();
            _orptInvoiceRegisters.GetInvoiceRegister(_dStartingDate, _dEndDate);
            DBController.Instance.CloseConnection();
            if (_orptInvoiceRegisters.Count <= 0)
            {
                lblErrMessage.Visible = true;
                lblErrMessage.Text = "No Data";
                return;
            }
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  (Invoice Register) =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = _orptInvoiceRegisters.ToDataSet();

        string sExpr = "";
        sExpr = "CustomerName like '%" + txtName.Text.Trim() + "%'";
        if (txtName.Text != "")
            sExpr = sExpr + " and  CustomerCode like '%" + txtCustomerCode.Text.Trim() + "%'";
        if (txtCustomerCode.Text.Trim() != "")
        {
            sExpr = sExpr + " and CustomerCode = '" + txtCustomerCode.Text.Trim() + "'";
        }
        if (txtRefCode.Text.Trim() != "")
        {
            sExpr = sExpr + " and ParentCustomerCode = '" + txtRefCode.Text.Trim() + "'";
        }
        if (txtRefName.Text.Trim() != "")
        {
            sExpr = sExpr + " and ParentCustomerName = '" + txtRefName.Text.Trim() + "'";
        }

        if (txtConfirmed.Text.Trim() != "")
        {
            sExpr = sExpr + " and OrderConfirmedByName = '" + txtConfirmed.Text.Trim() + "'";
        }

        if (txtCredit.Text.Trim() != "")
        {
            sExpr = sExpr + " and InvoiceByName = '" + txtCredit.Text.Trim() + "'";
        }

        if (txtDelivered.Text.Trim() != "")
        {
            sExpr = sExpr + " and DeliveredByName = '" + txtDelivered.Text.Trim() + "'";
        }

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
            _orptInvoiceRegisters.FromDataSetInvoiceRegister(_oDS);
        else _orptInvoiceRegisters = null;

        if (_orptInvoiceRegisters != null)
        {
            lblErrMessage.Visible = false;

            string sCompanyName = Utility.CompanyName;
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptInvoiceRegisterReport));

            doc.SetDataSource(_orptInvoiceRegisters);
            doc.SetParameterValue("CompanyName", sCompanyName);
          
            doc.SetParameterValue("PrintBy", this.Context.User.Identity.Name);
            doc.SetParameterValue("SBUName", cmbSBU.SelectedItem.Text);
            doc.SetParameterValue("ChannelName", cmbChannel.SelectedItem.Text);
            //doc.SetParameterValue("User Name", this.Context.User.Identity.Name);
            doc.SetParameterValue("StDate", _dStartingDate);
            doc.SetParameterValue("EndDate", _dEndDate);

            doc.SetParameterValue("Report_Name", Table2.Rows[0].Cells[0].InnerText.Trim());
            Session["ReportName"] = Table2.Rows[0].Cells[0].InnerText.Trim();
            Session["Doc"] = (object)doc;

            Response.Redirect("frmReportViewer.aspx");
        }
        else
        {
            lblErrMessage.Visible = true;
            lblErrMessage.Text = "No Data";
            return;
        }
    }

    private void getInvoiceRegisterDetailReport()
    {
        try
        {
            _orptInvoiceRegisters = new rptInvoiceRegisters();
            DBController.Instance.OpenNewConnection();
            _orptInvoiceRegisters.GetInvoiceRegisterDetail(_dStartingDate, _dEndDate);
            DBController.Instance.CloseConnection();
            if (_orptInvoiceRegisters.Count <= 0)
            {
                lblErrMessage.Visible = true;
                lblErrMessage.Text = "No Data";
                return;
            }
        }
        catch (Exception ex)
        {
            AppLogger.LogError("Web: error in  (Invoice RegisterDtail) =" + ex);
        }

        DataSet oDS = new DataSet();
        oDS = _orptInvoiceRegisters.ToDataSet();

        string sExpr = "";
        sExpr = "CustomerName like '%" + txtName.Text.Trim() + "%'";
        if (txtName.Text != "")
            sExpr = sExpr + " and  CustomerCode like '%" + txtCustomerCode.Text.Trim() + "%'";
        if (txtCustomerCode.Text.Trim() != "")
        {
            sExpr = sExpr + " and CustomerCode = '" + txtCustomerCode.Text.Trim() + "'";
        }
        if (txtRefCode.Text.Trim() != "")
        {
            sExpr = sExpr + " and ParentCustomerCode = '" + txtRefCode.Text.Trim() + "'";
        }
        if (txtRefName.Text.Trim() != "")
        {
            sExpr = sExpr + " and ParentCustomerName = '" + txtRefName.Text.Trim() + "'";
        }

        if (txtConfirmed.Text.Trim() != "")
        {
            sExpr = sExpr + " and OrderConfirmedByName = '" + txtConfirmed.Text.Trim() + "'";
        }

        if (txtCredit.Text.Trim() != "")
        {
            sExpr = sExpr + " and InvoiceByName = '" + txtCredit.Text.Trim() + "'";
        }

        if (txtDelivered.Text.Trim() != "")
        {
            sExpr = sExpr + " and DeliveredByName = '" + txtDelivered.Text.Trim() + "'";
        }

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
        {          
            _orptInvoiceRegisters.FromDataSetInvoiceRegisterDetail(_oDS);
        }
        else _orptInvoiceRegisters = null;

        if (_orptInvoiceRegisters != null)
        {
            lblErrMessage.Visible = false;
            Int64 nInvoiceID = 0;
            double nTotalDiscount = 0;
            foreach (rptInvoiceRegister _orptInvoiceRegister in _orptInvoiceRegisters)
            {
                if (_orptInvoiceRegister.InvoiceID != nInvoiceID)
                {
                    nTotalDiscount = nTotalDiscount + _orptInvoiceRegister.Discount;
                    nInvoiceID = _orptInvoiceRegister.InvoiceID;
                }
            }

            string sCompanyName = Utility.CompanyName;
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptInvoiceRegisterDetail));

            doc.SetDataSource(_orptInvoiceRegisters);
            doc.SetParameterValue("CompanyName", sCompanyName);
          
            doc.SetParameterValue("SBUName", cmbSBU.SelectedItem.Text);
            doc.SetParameterValue("ChannelName", cmbChannel.SelectedItem.Text);
            doc.SetParameterValue("GrandDiscount", Math.Abs(nTotalDiscount));
            doc.SetParameterValue("StDate", _dStartingDate);
            doc.SetParameterValue("EndDate", _dEndDate);

            doc.SetParameterValue("Report_Name", Table2.Rows[0].Cells[0].InnerText.Trim());
            Session["ReportName"] = Table2.Rows[0].Cells[0].InnerText.Trim();
            Session["Doc"] = (object)doc;

            Response.Redirect("frmReportViewer.aspx");
        }
        else
        {
            lblErrMessage.Visible = true;
            lblErrMessage.Text = "No Data";
            return;
        }
    }
}

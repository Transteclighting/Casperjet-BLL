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

public partial class Report_frmCustomerTypeWiseProductSalesReport : System.Web.UI.Page
{
    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    ProductSalesQtyandValueCustomerWiseDetails _oProductSalesQtyandValueCustomerWiseDetails;
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

        CustomerTypies oCustomerTypies = new CustomerTypies();
        oCustomerTypies.GetCustomerType();
        Session.Add("CustomerType", oCustomerTypies);
        cmbCustomerType.DataTextField = "CustTypeDescription";
        cmbCustomerType.DataValueField = "CustTypeID";
        cmbCustomerType.DataSource = oCustomerTypies;
        cmbCustomerType.DataBind();
        cmbCustomerType.SelectedIndex = oCustomerTypies.Count - 1;


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

        ProductGroups oAG = new ProductGroups();
        oAG.GETAG();
        cmbAG.DataTextField = "PdtGroupName";
        cmbAG.DataValueField = "PdtGroupId";
        cmbAG.DataSource = oAG;
        cmbAG.DataBind();
        cmbAG.SelectedIndex = oAG.Count - 1;

        Brands oBrands = new Brands();
        oBrands.GetBrand();
        cmbBrand.DataTextField = "BrandDesc";
        cmbBrand.DataValueField = "BrandID";
        cmbBrand.DataSource = oBrands;
        cmbBrand.DataBind();
        cmbBrand.SelectedIndex = oBrands.Count - 1;
        
    }

   
    
    public void FillReport()
    {
        string sCompanyName = Utility.CompanyName;
        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesBetweendateCustomerTypeNSKU));

        doc.SetDataSource(_oProductSalesQtyandValueCustomerWiseDetails);
        doc.SetParameterValue("CompanyName", sCompanyName);
        doc.SetParameterValue("Channel", cmbChannel.SelectedItem.Text);
        doc.SetParameterValue("CustomerType", cmbCustomerType.SelectedItem.Text);
        doc.SetParameterValue("PG", cmbProductType.SelectedItem.Text);
        doc.SetParameterValue("MAG", cmbMAG.SelectedItem.Text);
        doc.SetParameterValue("ASG", cmbASG.SelectedItem.Text);
        doc.SetParameterValue("AG", cmbAG.SelectedItem.Text);
        doc.SetParameterValue("Brand", cmbBrand.SelectedItem.Text);
        doc.SetParameterValue("StDate", _dStartingDate);
        doc.SetParameterValue("EndDate", _dEndingDate);
        doc.SetParameterValue("UserName", this.Context.User.Identity.Name);
        doc.SetParameterValue("Report_Name", " Product Sales Quantity and Value CustomerType Wise [64]");
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
    protected void btnShowReport_Click(object sender, EventArgs e)
    {        

        SBUs _SBUs = (SBUs)Session["SBU"];
        Channels _oChannels = (Channels)Session["Channel"];
      

        if (cmbStMonth.SelectedValue != "0" && cmbStYear.SelectedValue != "0" && cmbStDay.SelectedValue != "0")
        {
            _dStartingDate = new DateTime(int.Parse(cmbStYear.SelectedValue), int.Parse(cmbStMonth.SelectedValue), int.Parse(cmbStDay.SelectedValue));
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select valid date ";
            return;
        }
        if (cmbEndMonth.SelectedValue != "0" && cmbEndYear.SelectedValue != "0" && cmbEndDay.SelectedValue != "0")
        {
            _dEndingDate = new DateTime(int.Parse(cmbEndYear.SelectedValue), int.Parse(cmbEndMonth.SelectedValue), int.Parse(cmbEndDay.SelectedValue));
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select valid date ";
            return;
        }
        DateTime dDFromDate = _dStartingDate;
        DateTime dDToDate = _dEndingDate;

        _oProductSalesQtyandValueCustomerWiseDetails = new ProductSalesQtyandValueCustomerWiseDetails();
        DBController.Instance.OpenNewConnection();
        _oProductSalesQtyandValueCustomerWiseDetails.ProductSalesQtyCustomerTypewise(_dStartingDate, _dEndingDate);
        DBController.Instance.CloseConnection();
        DataSet oDS = new DataSet();
        oDS = _oProductSalesQtyandValueCustomerWiseDetails.ToDataSet();

        string sExpr = "";

        sExpr = " AreaName like '%" + txtName.Text.Trim() + "%'";               

        if ((txtCode.Text) != "")
        {
            sExpr = sExpr + " and AreaCode = '" + txtCode.Text + "'";
        }
               

        if (int.Parse(cmbChannel.SelectedValue) != -1)
        {
            sExpr = sExpr + " and ChannelID = '" + cmbChannel.SelectedValue + "'";
        }
        else sExpr = sExpr + " and ChannelID in (" + GetAllChannel() + ")";

        if (int.Parse(cmbCustomerType.SelectedValue) != -1)
        {
            sExpr = sExpr + " and CustomerTypeID = '" + cmbCustomerType.SelectedValue + "'";
        }
               
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
        if (int.Parse(cmbAG.SelectedValue) != -1)
        {
            sExpr = sExpr + " and AGID = '" + cmbAG.SelectedValue + "'";
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
            _oProductSalesQtyandValueCustomerWiseDetails.FromDataSetProductSalesQtyCustomerTypewise(_oDS);
        else _oProductSalesQtyandValueCustomerWiseDetails = null;

        if (_oProductSalesQtyandValueCustomerWiseDetails != null)
        {
            FillReport();
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = " No Data ";
        } 

    }
}

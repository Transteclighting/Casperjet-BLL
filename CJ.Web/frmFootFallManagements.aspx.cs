
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
using CJ.Class.FootFallCust;

public partial class frmFootFallManagements : System.Web.UI.Page
{
    DateTime _dFromDate;
    DateTime _dToDate;
    FootFallManagements _oFootFallManagements;
    FootFallBrands _oFootFallBrands;
    FootFallBrand oFootFallBrand;
    Customer oCustomer;
    Customers _oCustomers;
    bool IsUpdate = false;
    int _nUIControl = 0;

    int nUserID = 0;
    User oUser;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        nUserID = Convert.ToInt32(Request.QueryString["User"]);
        if (nUserID == 0)
        {
            oUser = (User)Session["User"];
        }
        else
        {
            oUser = new User();
            oUser.UserId = nUserID;
            Session.Add("User", oUser);
            Session.Add("UserID", nUserID); ;
        }
        if (!IsPostBack)
        {
            cboStDay.Text = DateTime.Today.Day.ToString();
            cboStMonth.Text = DateTime.Today.Month.ToString();
            cboStYear.Text = DateTime.Today.Year.ToString();
            cbTDay.Text = DateTime.Today.Day.ToString();
            cbTMonth.Text = DateTime.Today.Month.ToString();
            cbTYear.Text = DateTime.Today.Year.ToString();
            Combo();
            lnkShowdata_Click(null, null);
        }
        
    }
    public void Combo()
    {

        //oGiftVouchers = new GiftVouchers();
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);
        DBController.Instance.CloseConnection();
        if (_oCustomers.Count > 0)
        {

            cmbOutlet.DataSource = _oCustomers;
            cmbOutlet.DataTextField = "CustomerName";
            cmbOutlet.DataBind();
            

            if (_oCustomers.Count > 1)
            {
                cmbOutlet.Items.Add("All");
            }
            cmbOutlet.SelectedIndex = _oCustomers.Count;
            Session.Add("FootFallCustomers", oCustomer);
        }
        else
        {
            oCustomer = new Customer();
            oCustomer.CustomerName = "No Permission";
            _oCustomers.Add(oCustomer);

            cmbOutlet.DataSource = _oCustomers;
            cmbOutlet.DataTextField = "CustomerName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("FootFallCustomers", oCustomer);
        }

        //CustomerType
        cmbIsSold.Items.Add("All");
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
        {
         cmbIsSold.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
        }
        cmbIsSold.SelectedIndex = 0;

        //CustomerType
        cmbReason.Items.Add("All");
        cmbReason.Items.Add("Product Sold");
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ReasonforNotbuying)))
        {
           cmbReason.Items.Add(Enum.GetName(typeof(Dictionary.ReasonforNotbuying), GetEnum));
        }
        cmbReason.SelectedIndex = 0;

    } 
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("IsCheck", typeof(bool)));
        dt.Columns.Add(new DataColumn("FootFallNo", typeof(string)));
        dt.Columns.Add(new DataColumn("FootFallDate", typeof(string)));
        dt.Columns.Add(new DataColumn("CustomerName", typeof(string)));
        dt.Columns.Add(new DataColumn("ContactNo", typeof(string)));
        dt.Columns.Add(new DataColumn("IsSold", typeof(string)));
        dt.Columns.Add(new DataColumn("Reason", typeof(string)));


        _oFootFallManagements = new FootFallManagements();
        User oUser = (User)Session["User"];

        DBController.Instance.OpenNewConnection();

        oCustomer = new Customer();
        oCustomer.GetCustomerForFootFall(oUser.UserId);
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);

        if (_oCustomers.Count > 0)
        {
            if (cmbOutlet.Text != "All")
            {
                _oFootFallManagements.Refresh(_dFromDate, _dToDate, _oCustomers[cmbOutlet.SelectedIndex].CustomerID, txtCustomerName.Text, cmbIsSold.SelectedIndex - 1, cmbReason.SelectedIndex - 1, oUser.UserId);
            }
            else
            {
                _oFootFallManagements.Refresh(_dFromDate, _dToDate, -1, txtCustomerName.Text, cmbIsSold.SelectedIndex - 1, cmbReason.SelectedIndex - 1, oUser.UserId);
            }
        }

        foreach (FootFallManagement oFootFallManagement in _oFootFallManagements)
        {

            dr = dt.NewRow();

            dr["IsCheck"] = false;
            dr["FootFallNo"] = oFootFallManagement.FootFallNo.ToString();
            dr["FootFallDate"] = oFootFallManagement.CreateDate.ToString("dd-MMM-yyyy");
            dr["CustomerName"] = oFootFallManagement.CustomerName.ToString();
            dr["ContactNo"] = oFootFallManagement.MobileNo.ToString();
            if (oFootFallManagement.IsProductSold == (int)Dictionary.YesOrNoStatus.YES)
            {
                dr["IsSold"] = "Yes";
            }
            else
            {
                dr["IsSold"] = "No";
            }
            if (oFootFallManagement.ReasonNo == (int)Dictionary.ReasonforNotbuying.NoStock)
            {
                dr["Reason"] = "No Stock";
            }
            else if (oFootFallManagement.ReasonNo == (int)Dictionary.ReasonforNotbuying.CustomerPositive)
            {
                dr["Reason"] = "Cust. Positive";
            }
            else if (oFootFallManagement.ReasonNo == (int)Dictionary.ReasonforNotbuying.CustomerUndecided)
            {
                dr["Reason"] = "Cust. Undecided";
            }
            else
            {
                dr["Reason"] = "Product Sold";
            }

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["FootFallTable"] = dt;
        dvwFootFallCustomer.DataSource = dt;
        dvwFootFallCustomer.DataBind();
        Session.Add("FootFallManagements", _oFootFallManagements);
    }
    protected void lnkShowdata_Click(object sender, EventArgs e)
    {
        try
        {
            _dFromDate = new DateTime(Convert.ToInt32(cboStYear.SelectedValue), Convert.ToInt32(cboStMonth.SelectedValue), Convert.ToInt32(cboStDay.SelectedValue));
        }
        catch
        {
            lblMessage.Text = "Input Date is not correct Formate";
            lblMessage.Visible = true;
            return;
        }
        try
        {
            _dToDate = new DateTime(Convert.ToInt32(cbTYear.SelectedValue), Convert.ToInt32(cbTMonth.SelectedValue), Convert.ToInt32(cbTDay.SelectedValue));
        }
        catch
        {
            lblMessage.Text = "Input Date is not correct Formate";
            lblMessage.Visible = true;
            return;
        }
        lblMessage.Visible = false;
        RefreshGrid();
        Table3.Rows[0].Cells[0].InnerText = "Total Foot Fall" + "[" + dvwFootFallCustomer.Rows.Count + "]";
    }
    private bool validateUIInput(int nUIControl)
    {
        //_nUIControl = 0;
        //_nUIControl = nUIControl;
        //int ChkCount = 0;

        //DataTable dt = (DataTable)ViewState["FootFallTable"];
        //if (dt.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        CheckBox chk = (CheckBox)dvwFootFallCustomer.Rows[i].Cells[0].FindControl("chkBox");
        //        if (chk.Checked)
        //        {
        //            ChkCount = ChkCount + 1;
        //        }
        //    }
        //}
        //else
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "There is no Data";
        //    return false;
        //}
        //if (_nUIControl == 1)
        //{
        //    string IsConv = "";

        //    DataTable dtx = (DataTable)ViewState["FootFallTable"];
        //    if (dtx.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dtx.Rows.Count; i++)
        //        {
        //            CheckBox chk = (CheckBox)dvwFootFallCustomer.Rows[i].Cells[0].FindControl("chkBox");
        //            if (chk.Checked)
        //            {
        //                Label lblIsConversion = (Label)dvwFootFallCustomer.Rows[i].Cells[6].FindControl("IsConversion");
        //                IsConv = lblIsConversion.Text;
        //            }
        //        }
        //    }
        //    if (IsConv == "Yes")
        //    {
        //        lblMessage.Visible = true;
        //        lblMessage.Text = "This Foot Fall already converted to sale";
        //        return false;
        //    }
        //}

        //if (ChkCount == 0)
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "You have to checked a row";
        //    return false;
        //}
        //else if (ChkCount > 1)
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "You have to checked Only One row";
        //    return false;
        //}

        return true;
    }
    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("FootFallManagement");
        _oFootFallManagements = (FootFallManagements)Session["FootFallManagements"];

        LinkButton link = (LinkButton)sender;
        foreach (FootFallManagement oFootFallManagement in _oFootFallManagements)
        {
            if (oFootFallManagement.FootFallNo.ToString() == link.Text)
            {
                IsUpdate = true;
                Session.Add("Update", IsUpdate);
                Session.Add("FootFallManagement", oFootFallManagement);
                break;

            }
        }
        Response.Redirect("frmFootFallManagement.aspx");

    }
    protected void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
    {
        lnkShowdata_Click(null, null);
    }
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        Session.Remove("FootFallManagement");
        IsUpdate = false;
        Session.Add("Update", IsUpdate);
        Response.Redirect("frmFootFallManagement.aspx");

    }
    protected void FollowUpHistory_Click(object sender, EventArgs e)
    {
        //if (validateUIInput(2))
        //{
        //    lblMessage.Visible = false;
        //    Session.Remove("FootFallFollowUPHistory");
        //    DataTable dt = (DataTable)ViewState["FootFallTable"];
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            CheckBox chk = (CheckBox)dvwFootFallCustomer.Rows[i].Cells[0].FindControl("chkBox");
        //            if (chk.Checked)
        //            {
        //                FootFallCustomer oFootFallCustomer = new FootFallCustomer();

        //                LinkButton lblFootFallCode = (LinkButton)dvwFootFallCustomer.Rows[i].Cells[1].FindControl("FootFallCode");

        //                oFootFallCustomer.FootFallCode = lblFootFallCode.Text;
        //                Session.Add("FootFallFollowUPHistory", oFootFallCustomer);
        //                break;
        //            }
        //        }
        //    }
        //    Response.Redirect("frmTDFootFallFollowupHistory.aspx");
        //}
    }
}


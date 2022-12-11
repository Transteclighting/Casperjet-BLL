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

public partial class frmTDFootFallCustomer : System.Web.UI.Page
{
    DateTime _dFromDate;
    DateTime _dToDate;
    FootFallCustomers _oFootFallCustomers;
    FootFallBrands _oFootFallBrands;
    FootFallBrand oFootFallBrand;
    Customer oCustomer;
    Customers _oCustomers;
    bool IsUpdate = false;
    int _nUIControl = 0;
   
    protected void Page_Load(object sender, EventArgs e)
    {
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
        _oFootFallBrands = new FootFallBrands();
        _oFootFallBrands.RefreshForCombo(true);
        DBController.Instance.CloseConnection();
        if (_oCustomers.Count > 0)
        {
            cmbOutlet.DataSource = _oCustomers;
            cmbOutlet.DataTextField = "CustomerName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
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
        cmbASG.DataSource = _oFootFallBrands;
        cmbASG.DataTextField = "ASGName";
        cmbASG.DataValueField = "ASGID";
        cmbASG.DataBind();
        cmbASG.SelectedIndex = _oFootFallBrands.Count - 1;
        Session.Add("FootFallCustomers", oFootFallBrand);

    } 
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("IsCheck", typeof(bool)));
        dt.Columns.Add(new DataColumn("FootFallCode", typeof(string)));
        dt.Columns.Add(new DataColumn("FootFallDate", typeof(string)));
        dt.Columns.Add(new DataColumn("FootFallCustomerName", typeof(string)));
        dt.Columns.Add(new DataColumn("ContactNo", typeof(string)));
        dt.Columns.Add(new DataColumn("ASGName", typeof(string)));
        dt.Columns.Add(new DataColumn("IsConversion", typeof(string)));


        _oFootFallCustomers = new FootFallCustomers();
        User oUser = (User)Session["User"];

        DBController.Instance.OpenNewConnection();

        oCustomer = new Customer();
        oCustomer.GetCustomerForFootFall(oUser.UserId);
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);
        _oFootFallBrands = new FootFallBrands();
        _oFootFallBrands.RefreshForCombo(true);

        if (_oCustomers.Count > 0)
        {
            if (cmbASG.Text != "-1")
            {
                _oFootFallCustomers.Refresh(_dFromDate, _dToDate, _oCustomers[cmbOutlet.SelectedIndex].CustomerID, txtCustomerName.Text, _oFootFallBrands[cmbASG.SelectedIndex].ASGID);
            }
            else
            {
                _oFootFallCustomers.RefreshAll(_dFromDate, _dToDate, _oCustomers[cmbOutlet.SelectedIndex].CustomerID, txtCustomerName.Text);  
            }
        }

        foreach (FootFallCustomer oFootFallCustomer in _oFootFallCustomers)
        {

            dr = dt.NewRow();

            dr["IsCheck"] = false;
            dr["FootFallCode"] = oFootFallCustomer.FootFallCode.ToString();
            dr["FootFallDate"] = oFootFallCustomer.FootFallDate.ToString("dd-MMM-yyyy");
            dr["FootFallCustomerName"] = oFootFallCustomer.Name.ToString();
            dr["ContactNo"] = oFootFallCustomer.ContactNo.ToString();
            dr["ASGName"] = oFootFallCustomer.ASGName.ToString();
            dr["IsConversion"] = oFootFallCustomer.Conversion.ToString();

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["FootFallTable"] = dt;
        dvwFootFallCustomer.DataSource = dt;
        dvwFootFallCustomer.DataBind();
        Session.Add("FootFallCustomers", _oFootFallCustomers);
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
        _nUIControl = 0;
        _nUIControl = nUIControl;
        int ChkCount = 0;

        DataTable dt = (DataTable)ViewState["FootFallTable"];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dvwFootFallCustomer.Rows[i].Cells[0].FindControl("chkBox");
                if (chk.Checked)
                {
                    ChkCount = ChkCount + 1;
                }
            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "There is no Data";
            return false;
        }
        if (_nUIControl == 1)
        {
            string IsConv = "";

            DataTable dtx = (DataTable)ViewState["FootFallTable"];
            if (dtx.Rows.Count > 0)
            {
                for (int i = 0; i < dtx.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)dvwFootFallCustomer.Rows[i].Cells[0].FindControl("chkBox");
                    if (chk.Checked)
                    {
                        Label lblIsConversion = (Label)dvwFootFallCustomer.Rows[i].Cells[6].FindControl("IsConversion");
                        IsConv = lblIsConversion.Text;
                    }
                }
            }
            if (IsConv == "Yes")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "This Foot Fall already converted to sale";
                return false;
            }
        }

        if (ChkCount == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have to checked a row";
            return false;
        }
        else if (ChkCount > 1)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have to checked Only One row";
            return false;
        }

        return true;
    }
    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("FootFallCustomer");
        _oFootFallCustomers = (FootFallCustomers)Session["FootFallCustomers"];

        LinkButton link = (LinkButton)sender;
        foreach (FootFallCustomer oFootFallCustomer in _oFootFallCustomers)
        {
            if (oFootFallCustomer.FootFallCode.ToString() == link.Text)
            {
                IsUpdate = true;
                Session.Add("Update", IsUpdate);
                Session.Add("FootFallCustomer", oFootFallCustomer);
                break;

            }
        }
        Response.Redirect("frmTDFootFallCustomer.aspx");

    }
    protected void lbConversion_Click(object sender, EventArgs e)
    {
        if (validateUIInput(1))
        {
            lblMessage.Visible = false;
            Session.Remove("FootFallConversion");
            DataTable dt = (DataTable)ViewState["FootFallTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)dvwFootFallCustomer.Rows[i].Cells[0].FindControl("chkBox");
                    if (chk.Checked)
                    {
                        FootFallCustomer oFootFallCustomer = new FootFallCustomer();

                        LinkButton lblFootFallCode = (LinkButton)dvwFootFallCustomer.Rows[i].Cells[1].FindControl("FootFallCode");

                        oFootFallCustomer.FootFallCode = lblFootFallCode.Text;
                        Session.Add("FootFallConversion", oFootFallCustomer);
                        break;
                    }
                }
            }
            Response.Redirect("frmTDFootFallConversion.aspx");
        }
    }
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        Session.Remove("FootFallCustomer");
        IsUpdate = false;
        Session.Add("Update", IsUpdate);
        Response.Redirect("frmTDFootFallCustomer.aspx");

    }
    protected void FollowUpHistory_Click(object sender, EventArgs e)
    {
        if (validateUIInput(2))
        {
            lblMessage.Visible = false;
            Session.Remove("FootFallFollowUPHistory");
            DataTable dt = (DataTable)ViewState["FootFallTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)dvwFootFallCustomer.Rows[i].Cells[0].FindControl("chkBox");
                    if (chk.Checked)
                    {
                        FootFallCustomer oFootFallCustomer = new FootFallCustomer();

                        LinkButton lblFootFallCode = (LinkButton)dvwFootFallCustomer.Rows[i].Cells[1].FindControl("FootFallCode");

                        oFootFallCustomer.FootFallCode = lblFootFallCode.Text;
                        Session.Add("FootFallFollowUPHistory", oFootFallCustomer);
                        break;
                    }
                }
            }
            Response.Redirect("frmTDFootFallFollowupHistory.aspx");
        }
    }
}

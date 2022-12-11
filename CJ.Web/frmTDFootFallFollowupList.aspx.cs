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

public partial class frmTDFootFallFollowupList : System.Web.UI.Page
{
    FootFallCustomers _oFootFallCustomers;
    Customers _oCustomers;
    Customer oCustomer;
    DateTime _dFromDate;
    DateTime _dToDate;

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

        //cmbContacted.Items.Add("All");
        //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.FootFallIsContacted)))
        //{
        //    cmbContacted.Items.Add(Enum.GetName(typeof(Dictionary.FootFallIsContacted), GetEnum));
        //}
        //cmbContacted.SelectedIndex = 0;

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
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("IsCheck", typeof(bool)));
        dt.Columns.Add(new DataColumn("FootFallCode", typeof(string)));
        dt.Columns.Add(new DataColumn("FootFallDate", typeof(string)));
        dt.Columns.Add(new DataColumn("FollowupDate", typeof(string)));
        dt.Columns.Add(new DataColumn("FootFallCustomerName", typeof(string)));
        dt.Columns.Add(new DataColumn("ContactNo", typeof(string)));
        dt.Columns.Add(new DataColumn("ASGName", typeof(string)));
        dt.Columns.Add(new DataColumn("FollowUpID", typeof(int)));



        _oFootFallCustomers = new FootFallCustomers();
        User oUser = (User)Session["User"];

        DBController.Instance.OpenNewConnection();

        oCustomer = new Customer();
        oCustomer.GetCustomerForFootFall(oUser.UserId);
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);

        if (_oCustomers.Count > 0)
        {
            _oFootFallCustomers.RefreshProActiveList(_dFromDate, _dToDate, _oCustomers[cmbOutlet.SelectedIndex].CustomerID);
        }

        foreach (FootFallCustomer oFootFallCustomer in _oFootFallCustomers)
        {

            dr = dt.NewRow();

            dr["IsCheck"] = false;
            dr["FootFallCode"] = oFootFallCustomer.FootFallCode.ToString();
            dr["FootFallDate"] = oFootFallCustomer.FootFallDate.ToString("dd-MMM-yyyy");
            dr["FollowupDate"] = oFootFallCustomer.FollowupDate.ToString("dd-MMM-yyyy");
            dr["FootFallCustomerName"] = oFootFallCustomer.Name.ToString();
            dr["ContactNo"] = oFootFallCustomer.ContactNo.ToString();
            dr["ASGName"] = oFootFallCustomer.ASGName.ToString();
            dr["FollowUpID"] = oFootFallCustomer.FollowUpID;
            
            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["FootFallTable"] = dt;
        dvwFootFallCustomer.DataSource = dt;
        dvwFootFallCustomer.DataBind();
        Session.Add("FootFallCustomers", _oFootFallCustomers);
    }
    private bool validateUIInput()
    {
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
    protected void lbFollowUPSetting_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            lblMessage.Visible = false;
            Session.Remove("FootFallFollowUPSetting");
            DataTable dt = (DataTable)ViewState["FootFallTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)dvwFootFallCustomer.Rows[i].Cells[0].FindControl("chkBox");
                    if (chk.Checked)
                    {
                        FootFallCustomer oFootFallCustomer = new FootFallCustomer();

                        Label lblFootFallCode = (Label)dvwFootFallCustomer.Rows[i].Cells[1].FindControl("FootFallCode");
                        Label lblFollowUpID = (Label)dvwFootFallCustomer.Rows[i].Cells[7].FindControl("FollowUpID");


                        oFootFallCustomer.FootFallCode = lblFootFallCode.Text;
                        oFootFallCustomer.FollowUpID = int.Parse(lblFollowUpID.Text.ToString());
                        Session.Add("FootFallFollowUPSetting", oFootFallCustomer);
                        break;
                    }
                }
            }
            Response.Redirect("frmTDFootFallFollowUpSetting.aspx");
        }
    }
    protected void FollowUpHistory_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
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

                        Label lblFootFallCode = (Label)dvwFootFallCustomer.Rows[i].Cells[0].FindControl("FootFallCode");

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

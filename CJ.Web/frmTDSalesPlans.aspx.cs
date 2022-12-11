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

public partial class frmTDSalesPlans : System.Web.UI.Page
{
    DateTime _dFromDate;
    Customer oCustomer;
    Customers _oCustomers;
    TDSalesPlan _oTDSalesPlan;
    TDSalesPlans _oTDSalesPlans;
    bool IsUpdate = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cboStMonth.Text = DateTime.Today.Month.ToString();
            cboStYear.Text = DateTime.Today.Year.ToString();
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
            Session.Add("TDSalesPlans", oCustomer);
        }

    } 
    protected void lnkShowdata_Click(object sender, EventArgs e)
    {
        try
        {
            _dFromDate = new DateTime(Convert.ToInt32(cboStYear.SelectedValue), Convert.ToInt32(cboStMonth.SelectedValue),1);
        }
        catch
        {
            lblMessage.Text = "Input Date is not correct Formate";
            lblMessage.Visible = true;
            return;
        }
        
        lblMessage.Visible = false;
        RefreshGrid();
        Table3.Rows[0].Cells[0].InnerText = "Total" + "[" + dvwTDSalesPlan.Rows.Count + "]";

    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("IsCheck", typeof(bool)));
        dt.Columns.Add(new DataColumn("Code", typeof(string)));
        dt.Columns.Add(new DataColumn("Month", typeof(string)));
        dt.Columns.Add(new DataColumn("Year", typeof(string)));
        dt.Columns.Add(new DataColumn("PGName", typeof(string)));
        dt.Columns.Add(new DataColumn("SalesPerson", typeof(string)));
        dt.Columns.Add(new DataColumn("IsSubmitted", typeof(string)));

        User oUser = (User)Session["User"];

        DBController.Instance.OpenNewConnection();

        oCustomer = new Customer();
        oCustomer.GetCustomerForFootFall(oUser.UserId);
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);
        _oTDSalesPlans = new TDSalesPlans();

        if (_oCustomers.Count > 0)
        {
            //if (cmbASG.Text != "-1")
            //{
            _oTDSalesPlans.Refresh(_dFromDate, _oCustomers[cmbOutlet.SelectedIndex].CustomerID, txtCode.Text);
            //}
            //else
            //{
            //    _oFootFallCustomers.RefreshAll(_dFromDate, _dToDate, _oCustomers[cmbOutlet.SelectedIndex].CustomerID, txtCustomerName.Text);
            //}
        }

        foreach (TDSalesPlan oTDSalesPlan in _oTDSalesPlans)
        {

            dr = dt.NewRow();
            dr["IsCheck"] = false;
            dr["Code"] = oTDSalesPlan.SalesPlanCode.ToString();
            dr["Month"] = oTDSalesPlan.PlanningMonth.ToString("MMM");
            dr["Year"] = oTDSalesPlan.PlanningMonth.ToString("yyyy");
            dr["PGName"] = oTDSalesPlan.PGName.ToString();
            dr["SalesPerson"] = oTDSalesPlan.SalesPerson.ToString();
            dr["IsSubmitted"] = oTDSalesPlan.StatusName.ToString();

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["TDSalesPlan"] = dt;
        dvwTDSalesPlan.DataSource = dt;
        dvwTDSalesPlan.DataBind();
        Session.Add("TDSalesPlans", _oTDSalesPlans);
    }
    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("TDSalesPlan");

        _oTDSalesPlans = (TDSalesPlans)Session["TDSalesPlans"];

        LinkButton link = (LinkButton)sender;
        foreach (TDSalesPlan oTDSalesPlan in _oTDSalesPlans)
        {
            if (oTDSalesPlan.SalesPlanCode.ToString() == link.Text)
            {
                IsUpdate = true;
                Session.Add("Update", IsUpdate);
                Session.Add("TDSalesPlan", oTDSalesPlan);
                break;
            }
        }
        Response.Redirect("frmTDSalesPlan.aspx");
    }
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        Session.Remove("TDSalesPlan");
        IsUpdate = false;
        Session.Add("Update", IsUpdate);
        Response.Redirect("frmTDSalesPlan.aspx");

    }
    protected void lbSubmit_Click(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["TDSalesPlan"];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dvwTDSalesPlan.Rows[i].Cells[0].FindControl("chkBox");
                
                if (chk.Checked)
                {
                    LinkButton lblCode = (LinkButton)dvwTDSalesPlan.Rows[i].Cells[1].FindControl("Code");

                    _oTDSalesPlan = new TDSalesPlan();
                    //_oTDSalesPlan.SalesPlanCode = Convert.ToSingle(lblCode);
                    DBController.Instance.BeginNewTransaction();
                    _oTDSalesPlan.UpdateStatus();
                    DBController.Instance.CommitTran();

                }
            }
        }

    }
    protected void lbDelete_Click(object sender, EventArgs e)
    {
        //DataTable dt = (DataTable)ViewState["TDSalesPlan"];
        //if (dt.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        CheckBox chk = (CheckBox)dvwTDSalesPlan.Rows[i].Cells[0].FindControl("chkBox");

        //        if (chk.Checked)
        //        {
        //            LinkButton lblCode = (LinkButton)dvwTDSalesPlan.Rows[i].Cells[1].FindControl("Code");

        //            _oTDSalesPlan = new TDSalesPlan();
        //            //_oTDSalesPlan.SalesPlanCode = Convert.ToSingle(lblCode);
        //            DBController.Instance.BeginNewTransaction();
        //            _oTDSalesPlan.UpdateStatus();
        //            DBController.Instance.CommitTran();

        //        }
        //    }
        //}

    }
}

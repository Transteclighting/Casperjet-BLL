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

public partial class RetailInvoice_frmRetailInvoices : System.Web.UI.Page
{
    DateTime _dFromDate;
    DateTime _dToDate;
    bool IsUpdate = false;
    Customers _oCustomers;
    Customer _oCustomer;
    User oUser;
    SalesInvoices _oSalesInvoices;
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
            oUser = (User)Session["User"];
            LoadCombo();
            lnkShowdata_Click(null, null);
        }
    }
    private void LoadCombo()
    {
        _oCustomers = new Customers();

        Session.Remove("Customer");

        DBController.Instance.OpenNewConnection();
        _oCustomers.RefreshByPermission(oUser.UserId);
        DBController.Instance.CloseConnection();

        if (_oCustomers.Count > 0)
        {
            cmbOutlet.DataSource = _oCustomers;
            cmbOutlet.DataTextField = "CustomerName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("Customer", _oCustomers[cmbOutlet.SelectedIndex].CustomerID);
        }
        else
        {
            _oCustomer = new Customer();
            _oCustomer.CustomerName = "No Permission";
            _oCustomers.Add(_oCustomer);

            cmbOutlet.DataSource = _oCustomers;
            cmbOutlet.DataTextField = "CustomerName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Remove("Customer");
        }

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
        Table3.Rows[0].Cells[0].InnerText = "Total Invoice" + "[" + dvwRetailInvoices.Rows.Count + "]";

    }
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        Session.Remove("RetailInvoice");
        IsUpdate = false;
        Session.Add("Update", IsUpdate);
        Response.Redirect("frmRetailInvoice.aspx");
    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("IsCheck", typeof(bool)));
        dt.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
        dt.Columns.Add(new DataColumn("InvoiceDate", typeof(string)));
        dt.Columns.Add(new DataColumn("CustomerName", typeof(string)));
        dt.Columns.Add(new DataColumn("Qty", typeof(string)));
        dt.Columns.Add(new DataColumn("InvoiceAmount", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(string)));

        _oSalesInvoices = new SalesInvoices();
        User oUser = (User)Session["User"];

        DBController.Instance.OpenNewConnection();

        _oCustomers = new Customers();
        _oCustomers.RefreshByPermission(oUser.UserId);

        if (_oCustomers.Count > 0)
        {
            _oSalesInvoices.RefreshRetailInvoiceWEB(_dFromDate, _dToDate, _oCustomers[cmbOutlet.SelectedIndex].CustomerID, txtInvoiceNo.Text);
        }
        DBController.Instance.CloseConnection();

        foreach (SalesInvoice oSalesInvoice in _oSalesInvoices)
        {

            dr = dt.NewRow();

            dr["IsCheck"] = false;
            dr["InvoiceNo"] = oSalesInvoice.InvoiceNo.ToString();
            dr["InvoiceDate"] = Convert.ToDateTime(oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy");
            dr["CustomerName"] = oSalesInvoice.CustomerName.ToString();
            dr["Qty"] = oSalesInvoice.Qty.ToString();
            dr["InvoiceAmount"] = oSalesInvoice.InvoiceAmount.ToString();
            dr["Status"] = oSalesInvoice.InvoiceStatusName;

            dt.Rows.Add(dr);

        }
       

        ViewState["RetailInvoiceTable"] = dt;
        dvwRetailInvoices.DataSource = dt;
        dvwRetailInvoices.DataBind();
        Session.Add("RetailInvoices", _oSalesInvoices);
    }
    protected void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
}

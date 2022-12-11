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
using CJ.Class.CSD;
using CJ.Class.FootFallCust;

public partial class frmCustQueryOutlets : System.Web.UI.Page
{
    DateTime _dFromDate;
    DateTime _dToDate;
    Inquirys _oInquirys;
    Customer oCustomer;
    Customers _oCustomers;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("CustomerQuery");
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
            Session.Add("CustomerQuery", oCustomer);
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
            Session.Add("CustomerQuery", oCustomer);
        }
        cmbIsSale.Items.Add("All");
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquirySalesExecuated)))
        {
            cmbIsSale.Items.Add(Enum.GetName(typeof(Dictionary.InquirySalesExecuated), GetEnum));
        }
        cmbIsSale.Items.Add("Blank");
        cmbIsSale.SelectedIndex = -1;
    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("QueryID", typeof(int)));
        dt.Columns.Add(new DataColumn("CreateDate", typeof(string)));
        dt.Columns.Add(new DataColumn("Name", typeof(string)));
        dt.Columns.Add(new DataColumn("ContactNo", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(string)));
        dt.Columns.Add(new DataColumn("Remarks", typeof(string)));



        _oInquirys = new Inquirys();
        User oUser = (User)Session["User"];

        DBController.Instance.OpenNewConnection();

        oCustomer = new Customer();
        oCustomer.GetCustomerForFootFall(oUser.UserId);
        _oCustomers = new Customers();
        _oCustomers.RefreshPermissionForFootFall(oUser.UserId);

        if (_oCustomers.Count > 0)
        {
            _oInquirys.RefreshForWeb(_dFromDate, _dToDate, txtID.Text, txtCustomerName.Text, cmbIsSale.Text,_oCustomers[cmbOutlet.SelectedIndex].CustomerID);
        }

        foreach (Inquiry oInquiry in _oInquirys)
        {

            dr = dt.NewRow();

            dr["QueryID"] = oInquiry.InquiryID.ToString();
            dr["CreateDate"] = oInquiry.CreateDate.ToString("dd-MMM-yyyy");
            dr["Name"] = oInquiry.InqName.ToString();
            dr["ContactNo"] = oInquiry.ContactNo.ToString();
            dr["Status"] = oInquiry.IsSale.ToString();
            dr["Remarks"] = oInquiry.RecvRemarks.ToString();

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["CustomerQueryTable"] = dt;
        dvwCustomerQuery.DataSource = dt;
        dvwCustomerQuery.DataBind();
        Session.Add("CustomerQueries", _oInquirys);
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
        Table3.Rows[0].Cells[0].InnerText = "Total Query" + "[" + dvwCustomerQuery.Rows.Count + "]";
    }
    public void AddSaleExecute(Object sender, EventArgs e)
    {
        Session.Remove("CustomerQuery");
        _oInquirys = (Inquirys)Session["CustomerQueries"];
        
        LinkButton link = (LinkButton)sender;
        foreach (Inquiry oInquiry in _oInquirys)
        {
            if (oInquiry.InquiryID == int.Parse(link.Text))
            {
                Session.Add("CustomerQuery", oInquiry);
                Response.Redirect("frmCustQueryOutlet.aspx");
            }
        }
        

    }

}

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

public partial class frmLeaveApplications : System.Web.UI.Page
{
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
            
            Table3.Rows[0].Cells[0].InnerText = Request.QueryString["param"];
        }
        lnkShowdata_Click(null, null);
    }


    private void RefreshGrid()
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

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("EmployeeCode", typeof(string)));
        dt.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
        dt.Columns.Add(new DataColumn("FromDate", typeof(string)));
        dt.Columns.Add(new DataColumn("ToDate", typeof(string)));
        dt.Columns.Add(new DataColumn("Type", typeof(string)));
        dt.Columns.Add(new DataColumn("Remarks", typeof(string)));





        EmployeeLeaves oEmployeeLeaves = new EmployeeLeaves();
        //lvwEmployeeLeaves.Items.Clear();
        DBController.Instance.OpenNewConnection();
        oEmployeeLeaves.Refresh(_dFromDate, _dToDate);
        //this.Text = "EmployeeLeave " + "[" + oEmployeeLeaves.Count + "]";
        foreach (EmployeeLeave oEmployeeLeave in oEmployeeLeaves)
        {

            dr = dt.NewRow();

            dr["EmployeeCode"] = oEmployeeLeave.Employee.EmployeeCode;
            dr["EmployeeName"] = oEmployeeLeave.Employee.EmployeeName;
            dr["FromDate"] = oEmployeeLeave.LeaveStartDate.ToShortDateString();
            dr["ToDate"] = oEmployeeLeave.LeaveEndDate.ToShortDateString();
            dr["Type"] = oEmployeeLeave.LeaveType.ToString();
            dr["Remarks"] = oEmployeeLeave.Reason;
            dt.Rows.Add(dr);

        }


        ViewState["DepositTable"] = dt;
        dvwDeposit.DataSource = dt;
        dvwDeposit.DataBind();
        Session.Add("EmployeeLeaves", oEmployeeLeaves);
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
        Table3.Rows[0].Cells[0].InnerText = "Leave Applications " + "[" + dvwDeposit.Rows.Count + "]";
    }
    public void EditItem(Object sender, EventArgs e)
    {
        //Session.Remove("ViweOutletTran");
        //oOutletTrans = (OutletTrans)Session["OutletTrans"];

        //LinkButton link = (LinkButton)sender;
        //foreach (OutletTran oOutletTran in oOutletTrans)
        //{
        //    if (oOutletTran.OutletTranNo == link.Text)
        //    {
        //        Session.Add("IsUpdate", true);
        //        Session.Add("ViweOutletTran", oOutletTran);
        //        break;

        //    }
        //}
        //Response.Redirect("frmOutletTran.aspx");

    }
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        //Session.Add("IsUpdate", false);
        Response.Redirect("frmLeaveApplication.aspx");
    }
}

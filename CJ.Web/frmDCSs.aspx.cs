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
using CJ.Class.DCS;

public partial class frmDCSs : System.Web.UI.Page
{
    DateTime _dFromDate;
    DateTime _dToDate;
    OutletDeposits oOutletDeposits;
    Customer oCustomer;
    Bank oBank;
    Branch oBranch;

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

        }
        lnkShowdata_Click(null, null);
    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("DepositNo", typeof(string)));
        dt.Columns.Add(new DataColumn("DepositDate", typeof(string)));
        dt.Columns.Add(new DataColumn("Branch", typeof(string)));
        dt.Columns.Add(new DataColumn("Amount", typeof(string)));

        oOutletDeposits = new OutletDeposits();
        User oUser = (User)Session["User"];

        DBController.Instance.OpenNewConnection();

        oCustomer = new Customer();
        oCustomer.GetCustomerForDCS(oUser.UserId);

        oOutletDeposits.Refresh(_dFromDate, _dToDate, oCustomer.CustomerID, txtDepositNo.Text);

        foreach (OutletDeposit oOutletDeposit in oOutletDeposits)
        {
            string sBank = "";
            double Amount = 0;

            dr = dt.NewRow();

            dr["DepositNo"] = oOutletDeposit.OutletDepositNo;
            dr["DepositDate"] = oOutletDeposit.TranDate.ToString("dd-MMM-yyyy");

            foreach (OutletDepositDetail oOutletDepositDetail in oOutletDeposit)
            {
                oBranch = new Branch();
                oBranch.BranchID = oOutletDepositDetail.DepositBankBranch;
                oBranch.Refresh();
                oBank = new Bank();
                oBank.BankID = oBranch.BankID;
                oBank.Refresh();
                if (sBank == "")
                {
                    sBank = oBank.Name + "/" + oBranch.Name;
                }
                else
                {
                    sBank = sBank + "," + oBank.Name + "/" + oBranch.Name;
                }
                Amount = Amount + oOutletDepositDetail.Amount;
            }
            dr["Branch"] = sBank;
            dr["Amount"] = Amount.ToString();

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["DepositTable"] = dt;
        dvwDeposit.DataSource = dt;
        dvwDeposit.DataBind();
        Session.Add("OutletDeposits", oOutletDeposits);
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
        Table3.Rows[0].Cells[0].InnerText = "Deposit List" + "[" + dvwDeposit.Rows.Count + "]";
    }

    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("ViweOutletDeposit");
        oOutletDeposits = (OutletDeposits)Session["OutletDeposits"];

        LinkButton link = (LinkButton)sender;
        foreach (OutletDeposit oOutletDeposit in oOutletDeposits)
        {
            if (oOutletDeposit.OutletDepositNo == link.Text)
            {
                Session.Add("IsUpdate", true);
                Session.Add("ViweOutletDeposit", oOutletDeposit);
                break;
                
            }
        }
        Response.Redirect("frmDCS.aspx");

    }
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        Session.Add("IsUpdate", false);
        Response.Redirect("frmDCS.aspx");
    }
}
   

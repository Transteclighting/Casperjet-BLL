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

public partial class frmOutletTrans : System.Web.UI.Page
{
    DateTime _dFromDate;
    DateTime _dToDate;
    OutletTrans oOutletTrans;
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
        double nInvoiceAmount;
        double nBankDepositAmount;
        Customers oCustomers=new Customers();
 
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("DepositNo", typeof(string)));
        dt.Columns.Add(new DataColumn("DepositDate", typeof(string)));
        dt.Columns.Add(new DataColumn("Branch", typeof(string)));
        dt.Columns.Add(new DataColumn("InvoiceAmount", typeof(string)));
        dt.Columns.Add(new DataColumn("BankDepositAmount", typeof(string)));
        dt.Columns.Add(new DataColumn("Remarks", typeof(string)));

        oOutletTrans = new OutletTrans();
        User oUser = (User)Session["User"];

        DBController.Instance.OpenNewConnection();
        oCustomers.GetCustomers(oUser.UserId,true);
   
        oCustomer = new Customer();
        oCustomer.GetCustomerForDCS(oUser.UserId);
        
        //???
        oOutletTrans.Refresh(_dFromDate, _dToDate, oCustomer.CustomerID, txtDepositNo.Text);

        foreach (OutletTran oOutletTran in oOutletTrans)
        {
            nInvoiceAmount = 0;
            nBankDepositAmount = 0;

            dr = dt.NewRow();

            dr["DepositNo"] = oOutletTran.OutletTranNo;
            dr["DepositDate"] = oOutletTran.TranDate.ToString("dd-MMM-yyyy");              
            dr["Branch"] = oCustomers[oCustomers.GetIndex(oOutletTran.CustomerID)].CustomerName;

            foreach (OutletTranDetail oOutletTranDetail in oOutletTran)
            {
                if (oOutletTranDetail.TranTypeID == 1)
                {
                    nInvoiceAmount = nInvoiceAmount + oOutletTranDetail.Amount;
                }
                else if (oOutletTranDetail.TranTypeID == 2)
                {
                    nBankDepositAmount = nBankDepositAmount + oOutletTranDetail.Amount;
                }
            }

            dr["InvoiceAmount"] = nInvoiceAmount.ToString();
            dr["BankDepositAmount"] = nBankDepositAmount.ToString();
            dr["Remarks"] = oOutletTran.Remarks;
            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["DepositTable"] = dt;
        dvwDeposit.DataSource = dt;
        dvwDeposit.DataBind();
        Session.Add("OutletTrans", oOutletTrans);
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
        Table3.Rows[0].Cells[0].InnerText = "DCS Collection " + "[" + dvwDeposit.Rows.Count + "]";
    }

    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("ViweOutletTran");
        oOutletTrans = (OutletTrans)Session["OutletTrans"];

        LinkButton link = (LinkButton)sender;
        foreach (OutletTran oOutletTran in oOutletTrans)
        {
            if (oOutletTran.OutletTranNo == link.Text)
            {
                Session.Add("IsUpdate", true);
                Session.Add("ViweOutletTran", oOutletTran);
                break;

            }
        }
        Response.Redirect("frmOutletTran.aspx");

    }
    protected void lbAdd_Click(object sender, EventArgs e)
    {
        Session.Add("IsUpdate", false);
        Response.Redirect("frmOutletTran.aspx");
    }
}


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
using CJ.Class.Web.UI.Class;
using CJ.Class.Library;
using CJ.Class.Report;
using CJ.Report;

public partial class frmCustTranReceive : System.Web.UI.Page
{
    TELLib oLib;
    Banks _oBanks;
    Branchs _oBranchs;
    CustomerTransaction _oCustomerTransaction;
    int nUserID;
    DateTime _dDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptSalesInvoice _oSalesInvoice = (rptSalesInvoice)Session["SalesInvoice"];

            lbInvoiceNo.Text = _oSalesInvoice.InvoiceNo;
            lbInvocieDate.Text = _oSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy");
            lbCustomerCode.Text = _oSalesInvoice.CustomerCode;
            lbCustomerName.Text = _oSalesInvoice.CustomerName;
            lbCustomerBalance.Text = _oSalesInvoice.CustomerBalance.ToString();

            lbTranDate.Text = DateTime.Today.Date.ToString("dd-MMM-yyyy");
            lbInvoiceAmount.Text = _oSalesInvoice.InvoiceAmount.ToString();
            oLib = new TELLib();
            lbReceivedAmount.Text =oLib.TakaFormat(_oSalesInvoice.DueAmount);  
       
           

            LoadInstrumentType();
            LoadAllBank();          
            
            oLib = new TELLib();
            lblTakaInWord.Text = oLib.TakaWords(Convert.ToDouble(lbReceivedAmount.Text));
        }       
    }
    public void LoadInstrumentType()
    {
        foreach (string GetEnum in Enum.GetNames(typeof(Dictionary.InstrumentType)))
        {
            cbType.Items.Add(GetEnum);
        }
        cbType.SelectedIndex = 0;
    }
    public void LoadAllBank()
    {
        _oBanks = new Banks();
        DBController.Instance.OpenNewConnection();
        _oBanks.Refresh();

        cbBank.DataSource = _oBanks;
        cbBank.DataTextField = "Name";
        cbBank.DataBind();
        cbBank.SelectedIndex = 0;
        Session.Add("Banks", _oBanks);
    }
    public void LoadBranchforBank()
    {
        _oBanks = (Banks)Session["Banks"];

        _oBranchs = new Branchs();
        DBController.Instance.OpenNewConnection();
        _oBranchs.Refresh(_oBanks[cbBank.SelectedIndex].BankID);

        cbBranch.DataSource = _oBranchs;
        cbBranch.DataTextField = "Name";
        cbBranch.DataBind();
        cbBranch.SelectedIndex = 0;
        Session.Add("Branchs", _oBranchs);
    }

    protected void cbBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadBranchforBank();
    }
    protected void cbType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbType.Text == "CASH")
        {
            txtInsNo.Text = "";
            txtInsNo.Enabled = false;

            cbBank.Enabled = false;
            cbBranch.Enabled = false;
            cbDate.Enabled = false;
            cbMonth.Enabled = false;
            cbYear.Enabled = false;
        }
        else
        {
            txtInsNo.Text = "";
            txtInsNo.Enabled = true;

            cbBank.Enabled = true;
            cbBranch.Enabled = true;
            cbDate.Enabled = true;
            cbMonth.Enabled = true;
            cbYear.Enabled = true;
        }
    }   
    public bool ValidUIInput()
    {
        if (cbType.Text != "CASH")
        {
            if (txtInsNo.Text == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input No.";
                txtInsNo.Focus();
                return false;
            }
            if (cbBranch.Text == "" || cbBank.Text == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Select a Bank and Branch.";
                txtInsNo.Focus();
                return false;
            }
            try
            {
                _dDate = new DateTime(Convert.ToInt32(cbYear.SelectedValue), Convert.ToInt32(cbMonth.SelectedValue), Convert.ToInt32(cbDate.SelectedValue));
                Session.Add("Date",_dDate);
            }
            catch
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input Valid Date";
                return false;
            }

            return true;
        }
        else return true;
    }
    protected void btSave_Click1(object sender, EventArgs e)
    {
        string sInvoiceHistory = "";
        string sPadding = "";


        if (ValidUIInput())
        {
            rptSalesInvoice _oSalesInvoice = (rptSalesInvoice)Session["SalesInvoice"];
            _oBanks = (Banks)Session["Banks"];
            _oBranchs = (Branchs)Session["Branchs"];
            nUserID = Convert.ToInt32(Session["UserID"].ToString());
            User oUser=(User)Session["User"];
            _oCustomerTransaction = new CustomerTransaction();

            _oCustomerTransaction.InvoiceID = _oSalesInvoice.InvoiceID;
            _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
            _oCustomerTransaction.TranDate = DateTime.Today.Date;
            _oCustomerTransaction.Amount = Convert.ToDouble(lbReceivedAmount.Text);
            _oCustomerTransaction.InstrumentType = cbType.SelectedIndex;
            _oCustomerTransaction.UserID = nUserID;

            if (cbType.Text != "CASH")
            {
                _dDate = (DateTime)Session["Date"];
                Branch oBranch = _oBranchs[cbBranch.SelectedIndex];
                _oCustomerTransaction.InstrumentNo = txtInsNo.Text;
                _oCustomerTransaction.BranchID = oBranch.BranchID;
                if (txtBranchName.Text != "")
                    _oCustomerTransaction.BranchName = txtBranchName.Text;
                else _oCustomerTransaction.BranchName = cbBranch.Text;
                _oCustomerTransaction.InstrumentDate = _dDate;
            }
            if (chk.Checked == true)
            {
                _oCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.APPROVED;
            }
            else _oCustomerTransaction.InstrumentStatus = (short)Dictionary.InstrumentStatus.NOT_APPROVED;

            _oCustomerTransaction.Remarks = txtRemarks.Text;

            if (Utility.CompanyInfo == "TEL")
            {
                
                try
                {
                    
                    DBController.Instance.BeginNewTransaction();
                   // _oCustomerTransaction.Insert();
                    DBController.Instance.CommitTran();


                    CustomerTransactionReport oCustomerTransactionReport = new CustomerTransactionReport();
                    oCustomerTransactionReport.Refresh(_oCustomerTransaction.TranID);

                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCustomerMoneyCollection));

                    doc.SetDataSource(oCustomerTransactionReport);

                    sInvoiceHistory = "Invoice No." + sInvoiceHistory.PadRight(10, ' ') + "\t\t\t\t Amount";
                    sInvoiceHistory = sInvoiceHistory + "\n\n";
                    sInvoiceHistory = sInvoiceHistory + _oSalesInvoice.InvoiceNo.ToString() + sPadding.PadRight((20 - _oSalesInvoice.InvoiceNo.Length), ' ') + "\t\t\t\t" + " " + _oCustomerTransaction.Amount.ToString();
                    if (oUser.EmployeeID != -1)
                    {
                        _oCustomerTransaction.EmployeeID = oUser.EmployeeID;
                        _oCustomerTransaction.Employee.ReadDB = true;
                        doc.SetParameterValue("JobLocation", _oCustomerTransaction.Employee.JobLocation.Description);
                    }
                    else doc.SetParameterValue("JobLocation", "Sadar Road,Mohakhali C/A, Dhaka- 1206, Bangladesh");
                    doc.SetParameterValue("PrintBy", oUser.Username);
                    doc.SetParameterValue("InvoiceList", sInvoiceHistory);
                    doc.SetParameterValue("PrintStatus", "Print By");
                    doc.SetParameterValue("TranNo", _oCustomerTransaction.TranNo);
                    doc.SetParameterValue("TranDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("PrintDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("CustomerCode", _oSalesInvoice.CustomerCode);
                    doc.SetParameterValue("CustomerName", _oSalesInvoice.CustomerName);
                    doc.SetParameterValue("InstrumentType", cbType.Text);
                    doc.SetParameterValue("CompanyInfo", "TEL");
                    doc.SetParameterValue("CompanyName", Utility.CompanyName);
                    if (cbType.Text != "CASH")
                    {
                        doc.SetParameterValue("InstrumentNo", _oCustomerTransaction.InstrumentNo);
                        doc.SetParameterValue("Date", Convert.ToDateTime(_oCustomerTransaction.InstrumentDate).ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("Bank", cbBank.Text);
                        if (txtBranchName.Text != "")
                            doc.SetParameterValue("Branch", txtBranchName.Text);
                        else doc.SetParameterValue("Branch", cbBranch.Text);

                    }
                    else
                    {
                        doc.SetParameterValue("InstrumentNo", "N/A");
                        doc.SetParameterValue("Date", "N/A");
                        doc.SetParameterValue("Bank", "N/A");
                        doc.SetParameterValue("Branch", "N/A");
                    }
                    doc.SetParameterValue("Amount", lbReceivedAmount.Text);
                    doc.SetParameterValue("TK", lblTakaInWord.Text);
                    doc.SetParameterValue("Remarks", txtRemarks.Text);

                    Session.Remove("Doc");
                    Session.Add("Doc", doc);
                    Session["ReportName"] = "Invoice System(Customer Transaction Recevied) [CTR]";
                    Response.Redirect("~/Report/frmReportViewer.aspx");
                }
                catch
                {
                    DBController.Instance.RollbackTransaction();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error.......Please check your input and save again ";
                }

            }
            else if (Utility.CompanyInfo == "TML")
            {

                try
                {

                    DBController.Instance.BeginNewTransaction();
                  //  _oCustomerTransaction.Insert();
                    DBController.Instance.CommitTran();


                    CustomerTransactionReport oCustomerTransactionReport = new CustomerTransactionReport();
                    oCustomerTransactionReport.Refresh(_oCustomerTransaction.TranID);

                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCustomerMoneyCollection));

                    doc.SetDataSource(oCustomerTransactionReport);

                    sInvoiceHistory = "Invoice No." + sInvoiceHistory.PadRight(10, ' ') + "\t\t\t\t Amount";
                    sInvoiceHistory = sInvoiceHistory + "\n\n";
                    sInvoiceHistory = sInvoiceHistory + _oSalesInvoice.InvoiceNo.ToString() + sPadding.PadRight((20 - _oSalesInvoice.InvoiceNo.Length), ' ') + "\t\t\t\t" + " " + _oCustomerTransaction.Amount.ToString();
                    if (oUser.EmployeeID != -1)
                    {
                        _oCustomerTransaction.EmployeeID = oUser.EmployeeID;
                        _oCustomerTransaction.Employee.ReadDB = true;
                        doc.SetParameterValue("JobLocation", _oCustomerTransaction.Employee.JobLocation.Description);
                    }
                    else doc.SetParameterValue("JobLocation", "Sadar Road,Mohakhali C/A, Dhaka- 1206, Bangladesh");
                    doc.SetParameterValue("PrintBy", oUser.Username);
                    doc.SetParameterValue("InvoiceList", sInvoiceHistory);
                    doc.SetParameterValue("PrintStatus", "Print By");
                    doc.SetParameterValue("TranNo", _oCustomerTransaction.TranNo);
                    doc.SetParameterValue("TranDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("PrintDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("CustomerCode", _oSalesInvoice.CustomerCode);
                    doc.SetParameterValue("CustomerName", _oSalesInvoice.CustomerName);
                    doc.SetParameterValue("InstrumentType", cbType.Text);
                    doc.SetParameterValue("CompanyInfo", "TML");
                    doc.SetParameterValue("CompanyName", Utility.CompanyName);
                    if (cbType.Text != "CASH")
                    {
                        doc.SetParameterValue("InstrumentNo", _oCustomerTransaction.InstrumentNo);
                        doc.SetParameterValue("Date", Convert.ToDateTime(_oCustomerTransaction.InstrumentDate).ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("Bank", cbBank.Text);
                        if (txtBranchName.Text != "")
                            doc.SetParameterValue("Branch", txtBranchName.Text);
                        else doc.SetParameterValue("Branch", cbBranch.Text);

                    }
                    else
                    {
                        doc.SetParameterValue("InstrumentNo", "N/A");
                        doc.SetParameterValue("Date", "N/A");
                        doc.SetParameterValue("Bank", "N/A");
                        doc.SetParameterValue("Branch", "N/A");
                    }
                    doc.SetParameterValue("Amount", lbReceivedAmount.Text);
                    doc.SetParameterValue("TK", lblTakaInWord.Text);
                    doc.SetParameterValue("Remarks", txtRemarks.Text);

                    Session.Remove("Doc");
                    Session.Add("Doc", doc);
                    Session["ReportName"] = "Invoice System(Customer Transaction Recevied) [CTR]";
                    Response.Redirect("~/Report/frmReportViewer.aspx");
                }
                catch
                {
                    DBController.Instance.RollbackTransaction();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error.......Please check your input and save again ";
                }

            }
            else if (Utility.CompanyInfo == "BLL")
            {

                try
                {

                    DBController.Instance.BeginNewTransaction();
                  //  _oCustomerTransaction.Insert();
                    DBController.Instance.CommitTran();


                    CustomerTransactionReport oCustomerTransactionReport = new CustomerTransactionReport();
                    oCustomerTransactionReport.Refresh(_oCustomerTransaction.TranID);

                    CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptCustomerMoneyCollectionBLL));

                    doc.SetDataSource(oCustomerTransactionReport);

                    sInvoiceHistory = "Invoice No." + sInvoiceHistory.PadRight(10, ' ') + "\t\t\t\t Amount";
                    sInvoiceHistory = sInvoiceHistory + "\n\n";
                    sInvoiceHistory = sInvoiceHistory + _oSalesInvoice.InvoiceNo.ToString() + sPadding.PadRight((20 - _oSalesInvoice.InvoiceNo.Length), ' ') + "\t\t\t\t" + " " + _oCustomerTransaction.Amount.ToString();
                    if (oUser.EmployeeID != -1)
                    {
                        _oCustomerTransaction.EmployeeID = oUser.EmployeeID;
                        _oCustomerTransaction.Employee.ReadDB = true;
                        doc.SetParameterValue("JobLocation", _oCustomerTransaction.Employee.JobLocation.Description);
                    }
                    else doc.SetParameterValue("JobLocation", "Sadar Road,Mohakhali C/A, Dhaka- 1206, Bangladesh");
                    doc.SetParameterValue("PrintBy", oUser.Username);
                    doc.SetParameterValue("InvoiceList", sInvoiceHistory);
                    doc.SetParameterValue("PrintStatus", "Print By");
                    doc.SetParameterValue("TranNo", _oCustomerTransaction.TranNo);
                    doc.SetParameterValue("TranDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("PrintDate", DateTime.Today.Date.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("CustomerCode", _oSalesInvoice.CustomerCode);
                    doc.SetParameterValue("CustomerName", _oSalesInvoice.CustomerName);
                    doc.SetParameterValue("InstrumentType", cbType.Text);
                    if (cbType.Text != "CASH")
                    {
                        doc.SetParameterValue("InstrumentNo", _oCustomerTransaction.InstrumentNo);
                        doc.SetParameterValue("Date", Convert.ToDateTime(_oCustomerTransaction.InstrumentDate).ToString("dd-MMM-yyyy"));
                        doc.SetParameterValue("Bank", cbBank.Text);
                        if (txtBranchName.Text != "")
                            doc.SetParameterValue("Branch", txtBranchName.Text);
                        else doc.SetParameterValue("Branch", cbBranch.Text);

                    }
                    else
                    {
                        doc.SetParameterValue("InstrumentNo", "N/A");
                        doc.SetParameterValue("Date", "N/A");
                        doc.SetParameterValue("Bank", "N/A");
                        doc.SetParameterValue("Branch", "N/A");
                    }
                    doc.SetParameterValue("Amount", lbReceivedAmount.Text);
                    doc.SetParameterValue("TK", lblTakaInWord.Text);
                    doc.SetParameterValue("Remarks", txtRemarks.Text);

                    Session.Remove("Doc");
                    Session.Add("Doc", doc);
                    Session["ReportName"] = "Invoice System(Customer Transaction Recevied) [CTR]";
                    Response.Redirect("~/Report/frmReportViewer.aspx");
                }
                catch
                {
                    DBController.Instance.RollbackTransaction();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error.......Please check your input and save again ";
                }

            }
        }
    }
}

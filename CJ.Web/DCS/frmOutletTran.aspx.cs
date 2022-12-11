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
using CJ.Report;

public partial class frmOutletTran : System.Web.UI.Page
{
    Customers _oCustomers;
    OutletTranTypes _oOutletTranTypes;
    BankAccounts _oBankAccounts;
    InstrumentTypes _oInstrumentTypes;
    Banks _oBanks;
    OutletTran _oOutletTran;
    OutletTranDetail _oOutletTranDetail;

    //Bank oBank;
    //Branch oBranch;
    DSDCS oDSDCS;

    DateTime _dDate;

    int _nRowIndex = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadShowroom();
            LoadOutletTranType();
            LoadInstrumentType();
            LoadBankAccounts();
            LoadAllBank();

            lbHeaderText.Text = "TD Outlet DCS";


            cmbDate.Text = DateTime.Today.Day.ToString();
            cmbMonth.Text = DateTime.Today.Month.ToString();
            cmbYear.Text = DateTime.Today.Year.ToString();
            cmbDetailDay.Text = DateTime.Today.Day.ToString();
            cmbDetailMonth.Text = DateTime.Today.Month.ToString();
            cmbDetailYear.Text = DateTime.Today.Year.ToString();

            InitializeTranDetailLine();

            _oOutletTran = new OutletTran();
            Session.Add("OutletTran", _oOutletTran);

            if ((bool)Session["IsUpdate"] == true)
            {
                _oOutletTran = (OutletTran)Session["ViweOutletTran"];
                Session.Add("OutletTran", _oOutletTran);
                LoadUIForEdit();
                btSave.Visible = false;
                btPrint.Visible = true;
            }
            else
            {
                btSave.Visible = true;
                btPrint.Visible = false;
            }
        }
    }

    public void LoadShowroom()
    {
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();
        _oCustomers = new Customers();
        _oCustomers.GetCustomers(oUser.UserId,true);
        DBController.Instance.CloseConnection();

        foreach (Customer oCustomer in _oCustomers)
        {
            cmbShowroom.Items.Add(oCustomer.CustomerName);
        }
        cmbShowroom.SelectedIndex = 0;
        Session.Add("Customers", _oCustomers);
    }

    public void LoadOutletTranType()
    {
        _oOutletTranTypes = new OutletTranTypes();
        DBController.Instance.OpenNewConnection();
        _oOutletTranTypes.Refresh();
        DBController.Instance.CloseConnection();

        cmbTranType.Items.Add("[Please select Tran Type]");
        foreach (OutletTranType oOutletTranType in _oOutletTranTypes)
        {
            if (oOutletTranType.TranSide == 1)
            {
                cmbTranType.Items.Add(oOutletTranType.TranTypeName + "(Cr.)");
            }
            else
            {
                cmbTranType.Items.Add(oOutletTranType.TranTypeName + "(Dr.)");
            }
        }
        cmbTranType.SelectedIndex = 0;
        Session.Add("OutletTranTypes", _oOutletTranTypes);

        Table1.Rows[2].Visible = false;
        Table1.Rows[3].Visible = false;
        Table1.Rows[4].Visible = false;
    }

    public void LoadInstrumentType()
    {
        _oInstrumentTypes = new InstrumentTypes();
        DBController.Instance.OpenNewConnection();
        _oInstrumentTypes.Refresh();
        DBController.Instance.CloseConnection();

        foreach (InstrumentType oInstrumentType in _oInstrumentTypes)
        {
            cmbInstrumentType.Items.Add(oInstrumentType.InstrumentTypeName);
        }
        cmbInstrumentType.SelectedIndex = 0;
    }

    public void LoadAllBank()
    {
        _oBanks = new Banks();
        DBController.Instance.OpenNewConnection();
        _oBanks.Refresh();
        DBController.Instance.CloseConnection();

        cmbInstrumentBank.DataSource = _oBanks;
        cmbInstrumentBank.DataTextField = "Name";
        cmbInstrumentBank.DataBind();
        cmbInstrumentBank.SelectedIndex = 0;
        Session.Add("InstrumentBanks", _oBanks);
    }

    public void LoadBankAccounts()
    {
        BankAccounts _oBankAccounts = new BankAccounts();
        DBController.Instance.OpenNewConnection();
        _oBankAccounts.GetAllBankAccount();
        DBController.Instance.CloseConnection();

        cmbDepositBankAccount.Items.Add("[Please select Account]");
        foreach (BankAccount oBankAccount in _oBankAccounts)
        {
            cmbDepositBankAccount.Items.Add(oBankAccount.BankAccountNo + " - " + oBankAccount.BankBranchName);
        }

        cmbDepositBankAccount.SelectedIndex = 0;
        Session.Add("BankAccounts", _oBankAccounts);

    }

    public void LoadUIForEdit()
    {
        _oOutletTran = (OutletTran)Session["OutletTran"];
        txtRemarks.Text = _oOutletTran.Remarks;

        cmbDate.Text = _oOutletTran.TranDate.Day.ToString();
        cmbYear.Text = _oOutletTran.TranDate.Year.ToString();

        if (ViewState["TranDetailTable"] != null)
        {
            DataTable dtTranDetailTable = (DataTable)ViewState["TranDetailTable"];
            DataRow drTranDetailRow = null;

            dtTranDetailTable.Rows.Clear();

            foreach (OutletTranDetail oOutletTranDetail in _oOutletTran)
            {
                drTranDetailRow = dtTranDetailTable.NewRow();
                drTranDetailRow["TranType"] = _oOutletTranTypes.GetOutletTranType(oOutletTranDetail.TranTypeID).TranTypeName;
                if (oOutletTranDetail.TranTypeID == 1)
                {
                    drTranDetailRow["Description"] = oOutletTranDetail.BankAccountNo + "/" + oOutletTranDetail.InstrumentNo + "/" + oOutletTranDetail.InstrumentDate.ToShortDateString();
                }
                else if (oOutletTranDetail.TranTypeID == 2)
                {
                    drTranDetailRow["Description"] = oOutletTranDetail.InvoiceNo + "/" + oOutletTranDetail.InstrumentDate.ToShortDateString();
                }
                else
                {
                    drTranDetailRow["Description"] = "";
                }

                drTranDetailRow["InstrumentType"] = oOutletTranDetail.InstrumentType;
                drTranDetailRow["Amount"] = oOutletTranDetail.Amount.ToString();
                drTranDetailRow["BranchID"] = oOutletTranDetail.BankBranchName;
                drTranDetailRow["TypeID"] = oOutletTranDetail.InstrumentType;

                dtTranDetailTable.Rows.Add(drTranDetailRow);

            }

            ViewState["TranDetailTable"] = dtTranDetailTable;
            gdvTranDetail.DataSource = dtTranDetailTable;
            gdvTranDetail.DataBind();
        }
        LoadTranDetailControls();

        double _DepositAmount = 0;

        foreach (OutletTranDetail oOutletTranDetail in _oOutletTran)
        {
            _DepositAmount = _DepositAmount + oOutletTranDetail.Amount;
        }
        txtTotalDeposit.Text = _DepositAmount.ToString();
    }


    protected void cmbTranType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbTranType.SelectedIndex == 1)
        {
            Table1.Rows[2].Visible = false;
            Table1.Rows[3].Visible = true;
            Table1.Rows[4].Visible = true;
        }
        else if (cmbTranType.SelectedIndex == 2)
        {
            Table1.Rows[2].Visible = true;
            Table1.Rows[3].Visible = false;
            Table1.Rows[4].Visible = true;

        }
        else
        {
            Table1.Rows[2].Visible = false;
            Table1.Rows[3].Visible = false;
            Table1.Rows[4].Visible = false;
        }

    }

    protected void cmbInstrumentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbInstrumentType.SelectedIndex == 1)
        {
            txtInstrumentNo.Enabled = false;
        }
    }
    
    protected void cmbDepositBankAccount_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbDepositBankAccount.SelectedIndex == 0)
        {
            txtDepositBankBranch.Text = "";
        }
        else
        {
            _oBankAccounts = (BankAccounts)Session["BankAccounts"];
            txtDepositBankBranch.Text = _oBankAccounts[cmbDepositBankAccount.SelectedIndex - 1].BankBranchName; 
        }
    }

    #region Part-1: Transaction Details

    private void InitializeTranDetailControls()
    {
        cmbTranType.SelectedIndex = 0;
        cmbInstrumentType.SelectedIndex = 0;
        txtTranAmount.Text = "";
        cmbDepositBankAccount.SelectedIndex = 0;
        txtInstrumentNo.Text = "";
        txtInvoiceNo.Text = "";
        cmbInstrumentBank.SelectedIndex = 0;
        txtDepositBankBranch.Text = "";
    }
    private void InitializeTranDetailLine()
    {

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("TranType", typeof(string)));
        dt.Columns.Add(new DataColumn("Description", typeof(string)));
        dt.Columns.Add(new DataColumn("InstrumentType", typeof(string)));
        dt.Columns.Add(new DataColumn("Amount", typeof(string)));
        dt.Columns.Add(new DataColumn("BranchID", typeof(string)));
        dt.Columns.Add(new DataColumn("TypeID", typeof(string)));

        dr = dt.NewRow();

        dr["TranType"] = string.Empty;
        dr["Description"] = string.Empty;
        dr["InstrumentType"] = string.Empty;
        dr["Amount"] = string.Empty;
        dr["BranchID"] = string.Empty;
        dr["TypeID"] = string.Empty;

        dt.Rows.Add(dr);

        ViewState["TranDetailTable"] = dt;
        gdvTranDetail.DataSource = dt;
        gdvTranDetail.DataBind();
    }


    private void AddTranDetail()
    {
        _nRowIndex = 1;
        lblMessage.Visible = false;
        _oOutletTran = (OutletTran)Session["OutletTran"];

        if (ViewState["TranDetailTable"] != null)
        {

            DataTable dtTranDetailTable = (DataTable)ViewState["TranDetailTable"];
            DataRow drTranDetailRow = null;


            try
            {
                //Retrive objects from session
                _oOutletTranTypes = (OutletTranTypes)Session["OutletTranTypes"]; 
                _oBankAccounts = (BankAccounts)Session["BankAccounts"];
                _oBanks = (Banks)Session["InstrumentBanks"];

                //Load data in object from control
                _oOutletTranDetail = new OutletTranDetail();
                _oOutletTranDetail.TranTypeID = _oOutletTranTypes[cmbTranType.SelectedIndex-1].TranTypeID;
                _oOutletTranDetail.Amount = Convert.ToDouble(txtTranAmount.Text);
                if (cmbDepositBankAccount.SelectedIndex > 0)
                {
                    _oOutletTranDetail.BankAccountNo = _oBankAccounts[cmbDepositBankAccount.SelectedIndex - 1].BankAccountNo;
                }
                _oOutletTranDetail.BankBranchName = txtDepositBankBranch.Text;
                _oOutletTranDetail.InstrumentType = cmbInstrumentType.SelectedItem.Text;
                _oOutletTranDetail.InstrumentNo = txtInstrumentNo.Text;
                _oOutletTranDetail.InstrumentDate = new DateTime(Convert.ToInt32(cmbDetailYear.SelectedValue), Convert.ToInt32(cmbDetailMonth.SelectedValue), Convert.ToInt32(cmbDetailDay.SelectedValue)); ;
                _oOutletTranDetail.InvoiceNo = txtInvoiceNo.Text;
                _oOutletTranDetail.BankID = _oBanks[cmbInstrumentBank.SelectedIndex].BankID;  
                _oOutletTran.Add(_oOutletTranDetail);

                dtTranDetailTable.Rows.Clear();

                foreach (OutletTranDetail oOutletTranDetail in _oOutletTran)
                {

                    drTranDetailRow = dtTranDetailTable.NewRow();
                    drTranDetailRow["TranType"] = _oOutletTranTypes.GetOutletTranType(oOutletTranDetail.TranTypeID).TranTypeName;
                    if (oOutletTranDetail.TranTypeID == 1)
                    {
                        drTranDetailRow["Description"] = oOutletTranDetail.BankAccountNo + "/" + oOutletTranDetail.InstrumentNo + "/" + oOutletTranDetail.InstrumentDate.ToShortDateString();
                    }
                    else if (oOutletTranDetail.TranTypeID == 2)
                    {
                        drTranDetailRow["Description"] = oOutletTranDetail.InvoiceNo + "/" + oOutletTranDetail.InstrumentDate.ToShortDateString();
                    }
                    else
                    {
                        drTranDetailRow["Description"] ="";
                    }

                    drTranDetailRow["InstrumentType"] = oOutletTranDetail.InstrumentType;
                    drTranDetailRow["Amount"] = oOutletTranDetail.Amount.ToString();
                    drTranDetailRow["BranchID"] = oOutletTranDetail.BankBranchName;
                    drTranDetailRow["TypeID"] = oOutletTranDetail.InstrumentType;

                    dtTranDetailTable.Rows.Add(drTranDetailRow);

                }

                ViewState["TranDetailTable"] = dtTranDetailTable;
                gdvTranDetail.DataSource = dtTranDetailTable;
                gdvTranDetail.DataBind();
               
            }
            catch (Exception ex)
            {

                return;
            }

        }
        else
        {
            Response.Write("ViewState is null");
        }
        //Set Previous Data on Postbacks
        //LoadTranDetailControls();

    }
    private void LoadTranDetailControls()
    {
        _nRowIndex = 0;

        if (ViewState["TranDetailTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["TranDetailTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)gdvTranDetail.Rows[_nRowIndex].Cells[0].FindControl("txtTranType");
                    TextBox box2 = (TextBox)gdvTranDetail.Rows[_nRowIndex].Cells[1].FindControl("txtDescription");
                    TextBox box3 = (TextBox)gdvTranDetail.Rows[_nRowIndex].Cells[2].FindControl("txtAmout");
                    TextBox box4 = (TextBox)gdvTranDetail.Rows[_nRowIndex].Cells[3].FindControl("txtType");
                    TextBox box5 = (TextBox)gdvTranDetail.Rows[_nRowIndex].Cells[4].FindControl("txtBranchID");
                    TextBox box6 = (TextBox)gdvTranDetail.Rows[_nRowIndex].Cells[5].FindControl("txtTypeID");

                    box1.Text = dt.Rows[i]["TranType"].ToString();
                    box2.Text = dt.Rows[i]["Description"].ToString();
                    box3.Text = dt.Rows[i]["Amount"].ToString();
                    box4.Text = dt.Rows[i]["InstrumentType"].ToString();
                    box5.Text = dt.Rows[i]["BranchID"].ToString();
                    box6.Text = dt.Rows[i]["TypeID"].ToString();

                    _nRowIndex++;

                }
            }
        }

    }
    public void checkDuplicateDepositBranch()
    {
        int _nCount = 0;
        if (ViewState["TranDetailTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["TranDetailTable"];

            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dt.Rows)
            {
                if (hTable.Contains(drow["BranchID"]))
                {
                    duplicateList.Add(drow);
                    _nCount++;
                }
                else
                    hTable.Add(drow["BranchID"], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            _oOutletTran = (OutletTran)Session["OutletTran"];
            foreach (DataRow dRow in duplicateList)
            {
                int i = 0;
                foreach (OutletTranDetail oOutletTranDetail in _oOutletTran)
                {
                    //if (oOutletTranDetail.DepositBankBranch == int.Parse(dRow["BranchID"].ToString()))
                    //{
                    //    _oOutletTran.RemoveAt(i);
                    //    break;
                    //}
                    i++;
                }
                dt.Rows.Remove(dRow);
            }

            if (_nCount != 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Duplicate Branch.Please input valid Bramch";
            }

            //Datatable which contains unique records will be return as output.

            ViewState["TranDetailTable"] = dt;
            gdvTranDetail.DataSource = dt;
            gdvTranDetail.DataBind();

            //LoadTranDetailControls();
        }
    }
    protected void btnAddTranDetail_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;

        if (cmbTranType.SelectedIndex == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Select Transaction Type.";
            return;
        }

        try
        {
            double temp = Convert.ToDouble(txtTranAmount.Text);
        }
        catch
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Valid Amount";
            return;
        }

        if (cmbTranType.SelectedIndex==1 && cmbDepositBankAccount.SelectedIndex == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Select Bank Account No";
            return;
        }
        try
        {
            _oBankAccounts= (BankAccounts)Session["BankAccounts"];
        }
        catch
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Select Bank Account No";
            return;
        }

        if (cmbTranType.SelectedIndex == 2 && txtInvoiceNo.Text=="" )
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Invoice No.";
            return;
        }

        AddTranDetail();
        //checkDuplicateDepositBranch();
        LoadTranDetailControls();
        _oOutletTran = (OutletTran)Session["OutletTran"];
        double _DepositAmount = 0;

        foreach (OutletTranDetail oOutletTranDetail in _oOutletTran)
        {
            _DepositAmount = _DepositAmount + oOutletTranDetail.Amount;
        }
        txtTotalDeposit.Text = _DepositAmount.ToString();
        //UpdatePanel2.Update();
        InitializeTranDetailControls();
    }
    protected void DeleteTranDetail(object sender, GridViewDeleteEventArgs e)
    {
        //Retrive objects from session
        _oOutletTranTypes = (OutletTranTypes)Session["OutletTranTypes"]; 
        _oOutletTran = (OutletTran)Session["OutletTran"];

        //GridViewRow row = (GridViewRow)gdvTranDetail.Rows[e.RowIndex];
        //TextBox BranchID = (TextBox)row.FindControl("txtBranchID");

        //int i = 0;
        //foreach (OutletTranDetail oOutletTranDetail in _oOutletTran)
        //{
        //    //if (oOutletTranDetail.BankBranchName == int.Parse(BranchID.Text))
        //    //{
        //    //    _oOutletTran.RemoveAt(i);
        //    //    break;
        //    //}
        //    i++;
        //}

        _oOutletTran.RemoveAt(e.RowIndex);

        if (ViewState["TranDetailTable"] != null)
        {
            DataTable dtTranDetailTable = (DataTable)ViewState["TranDetailTable"];
            DataRow drTranDetailRow = null;

            dtTranDetailTable.Rows.Clear();

            foreach (OutletTranDetail oOutletTranDetail in _oOutletTran)
            {
                drTranDetailRow = dtTranDetailTable.NewRow();
                drTranDetailRow["TranType"] = _oOutletTranTypes.GetOutletTranType(oOutletTranDetail.TranTypeID).TranTypeName;
                if (oOutletTranDetail.TranTypeID == 1)
                {
                    drTranDetailRow["Description"] = oOutletTranDetail.BankAccountNo + "/" + oOutletTranDetail.InstrumentNo + "/" + oOutletTranDetail.InstrumentDate.ToShortDateString();
                }
                else if (oOutletTranDetail.TranTypeID == 2)
                {
                    drTranDetailRow["Description"] = oOutletTranDetail.InvoiceNo + "/" + oOutletTranDetail.InstrumentDate.ToShortDateString();
                }
                else
                {
                    drTranDetailRow["Description"] = "";
                }

                drTranDetailRow["InstrumentType"] = oOutletTranDetail.InstrumentType;
                drTranDetailRow["Amount"] = oOutletTranDetail.Amount.ToString();
                drTranDetailRow["BranchID"] = oOutletTranDetail.BankBranchName;
                drTranDetailRow["TypeID"] = oOutletTranDetail.InstrumentType;

                dtTranDetailTable.Rows.Add(drTranDetailRow);

            }

            ViewState["TranDetailTable"] = dtTranDetailTable;
            gdvTranDetail.DataSource = dtTranDetailTable;
            gdvTranDetail.DataBind();

            if (_oOutletTran.Count > 0)
                LoadTranDetailControls();
            else InitializeTranDetailLine();
            //UpdatePanel2.Update();
        }

    }
    
    #endregion



    #region Final Part: Save & Print DCS
    private bool validateUIInput()
    {

        try
        {
            _dDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmbDate.SelectedValue));

        }
        catch
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Valid Tran Date";
            return false;
        }

    //    _oOutletTranInvoices = (OutletTranInvoices)Session["OutletTranInvoices"];
        _oOutletTran = (OutletTran)Session["OutletTran"];

        if (_oOutletTran.Count <= 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Valid Bank Tran Detail";
            return false;
        }
    //    if (_oOutletTranInvoices.Count <= 0)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = "Please Input Valid Tran Invoice Detail";
    //        return false;
    //    }
        double nTranAmount = 0;
        foreach (OutletTranDetail oOutletTranDetail in _oOutletTran)
        {
            nTranAmount = nTranAmount + oOutletTranDetail.Amount;
        }
    //    double _InvoiceAmount = 0;
    //    foreach (OutletTranInvoice _oOutletTranInvoice in _oOutletTranInvoices)
    //    {
    //        _InvoiceAmount = _InvoiceAmount + _oOutletTranInvoice.Amount;
    //    }

    //    if (_TranAmount != _InvoiceAmount)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = "Total Tran Amount and Total Instrument Amount are not same";
    //        return false;
    //    }
        return true;
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        if (validateUIInput())
        {
            User oUser = (User)Session["User"];
            _oCustomers = (Customers)Session["Customers"];
        //    _oOutletTranInvoices = (OutletTranInvoices)Session["OutletTranInvoices"];
            _oOutletTran = (OutletTran)Session["OutletTran"];

            _oOutletTran.CustomerID = _oCustomers[cmbShowroom.SelectedIndex].CustomerID;
            _oOutletTran.TranDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmbDate.SelectedValue));
            _oOutletTran.UserID = oUser.UserId;
            _oOutletTran.Remarks = txtRemarks.Text;

        //    _oOutletTran.oOutletTranInvoices = new OutletTranInvoices();
        //    foreach (OutletTranInvoice oOutletTranInvoice in _oOutletTranInvoices)
        //    {
        //        _oOutletTran.oOutletTranInvoices.Add(oOutletTranInvoice);
        //    }

            try
            {
                DBController.Instance.BeginNewTransaction();
                _oOutletTran.Insert();
                DBController.Instance.CommitTransaction();
                string[] sSuccedCode =  { " " };
                Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                UIUtility.GetConfirmationMsg("Save", "The Tran", sSuccedCode, null, "DCS/frmOutletTrans.aspx", 0);
                Response.Redirect("../frmMessage.aspx");
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                lblMessage.Visible = true;
                lblMessage.Text = "Error..." + ex;
                return;

            }
        }
    }

    protected void btPrint_Click(object sender, EventArgs e)
    {
        OutletTranType oOutletTranType;
        _oCustomers = (Customers)Session["Customers"];
        _oOutletTranTypes = (OutletTranTypes)Session["OutletTranTypes"]; 
        _oOutletTran = (OutletTran)Session["OutletTran"];
        User oUser = (User)Session["User"];
        Customer oCustomer = (Customer)Session["Customer"];
        oDSDCS = new DSDCS();
        //DBController.Instance.OpenNewConnection();

        //oDSDCS = _oOutletTran.RefreshDetailForReport(oDSDCS);

        //DBController.Instance.CloseConnection();


        foreach (OutletTranDetail oOutletTranDetail in _oOutletTran)
        {
            DSDCS.TranDetailRow oTranDetailRow = oDSDCS.TranDetail.NewTranDetailRow();
            oOutletTranType = _oOutletTranTypes.GetOutletTranType(oOutletTranDetail.TranTypeID);
            oTranDetailRow.TranType = oOutletTranType.TranTypeName;
            oTranDetailRow.InstrumentType = oOutletTranDetail.InstrumentType;
            oTranDetailRow.InstrumentDate= oOutletTranDetail.InstrumentDate.ToShortDateString();

            if (oOutletTranDetail.TranTypeID == 1)
            {
                oTranDetailRow.Description = oOutletTranDetail.BankAccountNo + "/" + oOutletTranDetail.InstrumentNo + "/" + oOutletTranDetail.InstrumentDate.ToShortDateString();
            }
            else if (oOutletTranDetail.TranTypeID == 2)
            {
                oTranDetailRow.Description = oOutletTranDetail.InvoiceNo + "/" + oOutletTranDetail.InstrumentDate.ToShortDateString();
            }
            else
            {
                oTranDetailRow.Description = "";
            }

            if (oOutletTranType.TranSide == 1)
            {
                oTranDetailRow.CrAmount = oOutletTranDetail.Amount;
            }
            else
            {
                oTranDetailRow.DrAmount = oOutletTranDetail.Amount;
            }
            oDSDCS.TranDetail.AddTranDetailRow(oTranDetailRow);
            oDSDCS.AcceptChanges();
        }







        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptDCS));

        doc.SetDataSource(oDSDCS);

        doc.SetParameterValue("OutletCode", _oCustomers[cmbShowroom.SelectedIndex].CustomerName.Substring(0, 3));
        doc.SetParameterValue("OutletName", _oCustomers[cmbShowroom.SelectedIndex].CustomerName);
        doc.SetParameterValue("TranNo", _oOutletTran.OutletTranNo);
        doc.SetParameterValue("TranDate", _oOutletTran.TranDate.ToString("dd-MMM-yyyy"));
        doc.SetParameterValue("User", oUser.Username);

        Session.Remove("Doc");
        Session.Add("Doc", doc);
        Session["ReportName"] = "Daily Oulet Collection [DCS]";
        Response.Redirect("~/Report/frmReportViewer.aspx");
    }



    #endregion


}



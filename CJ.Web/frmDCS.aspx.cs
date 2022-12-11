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

public partial class frmDCS : System.Web.UI.Page
{
    Banks _oDepositBanks;
    Branchs _oDepositBranchs;
    Banks _oInstrumentBanks;
    Branchs _oInstrumentBranchs;
    Bank oBank;
    Branch oBranch;
    Customer oCustomer;
    OutletDeposit oOutletDeposit;
    OutletDepositDetail _oOutletDepositDetail;
    OutletDepositInvoice oOutletDepositInvoice;
    OutletDepositInvoices _oOutletDepositInvoices;
    DSDCS oDSDCS;
      
    DateTime _dDate;

    int _nRowIndex = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadInstrumentType();
            LoadAllBank();
            User oUser = (User)Session["User"];
            DBController.Instance.OpenNewConnection();
            oCustomer = new Customer();
            oCustomer.GetCustomerForDCS(oUser.UserId);
            DBController.Instance.CloseConnection();
            lbHeaderText.Text = "TD Outlet Collection For: "+ oCustomer.CustomerName+"[" + oCustomer.CustomerCode + "]" ;
            Session.Add("Customer", oCustomer);

            cmbDate.Text = DateTime.Today.Day.ToString();
            cmbMonth.Text = DateTime.Today.Month.ToString();
            cmbYear.Text = DateTime.Today.Year.ToString();
            cmbIstDate.Text = DateTime.Today.Day.ToString();
            cmbIstMonth.Text = DateTime.Today.Month.ToString();
            cmbIstYear.Text = DateTime.Today.Year.ToString();

            SetInitialDepositDetaiRow();
            SetInitialInvoiceDepositRow();

            oOutletDeposit = new OutletDeposit();
            Session.Add("OutletDeposit", oOutletDeposit);
            _oOutletDepositInvoices = new OutletDepositInvoices();
            Session.Add("OutletDepositInvoices", _oOutletDepositInvoices);

            if ((bool)Session["IsUpdate"] == true)
            {
                oOutletDeposit = (OutletDeposit)Session["ViweOutletDeposit"];
                Session.Add("OutletDeposit", oOutletDeposit);
                _oOutletDepositInvoices = oOutletDeposit.oOutletDepositInvoices;
                Session.Add("OutletDepositInvoices", _oOutletDepositInvoices);
                SetUI();
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
   
    public void LoadInstrumentType()
    {
        foreach (string GetEnum in Enum.GetNames(typeof(Dictionary.InstrumentType)))
        {
            cmbType.Items.Add(GetEnum);
        }
        cmbType.SelectedIndex = 0;
        foreach (string GetEnum in Enum.GetNames(typeof(Dictionary.InstrumentType)))
        {
            cmbDepositType.Items.Add(GetEnum);            
        }
        cmbDepositType.SelectedIndex = 0;
    }
    public void LoadAllBank()
    {
        _oDepositBanks = new Banks();
        _oInstrumentBanks = new Banks();
        DBController.Instance.OpenNewConnection();
        _oDepositBanks.Refresh();
        _oInstrumentBanks.Refresh();
        DBController.Instance.CloseConnection();

        cbDepositBank.DataSource = _oDepositBanks;
        cbDepositBank.DataTextField = "Name";
        cbDepositBank.DataBind();
        cbDepositBank.SelectedIndex = 0;
        Session.Add("DepositBanks", _oDepositBanks);

        cmbInsBank.DataSource = _oInstrumentBanks;
        cmbInsBank.DataTextField = "Name";
        cmbInsBank.DataBind();
        cmbInsBank.SelectedIndex = 0;
        Session.Add("InstrumentBanks", _oInstrumentBanks);
    }  
    protected void cbBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        _oDepositBanks = (Banks)Session["DepositBanks"];

        _oDepositBranchs = new Branchs();
        DBController.Instance.OpenNewConnection();
        _oDepositBranchs.Refresh(_oDepositBanks[cbDepositBank.SelectedIndex].BankID);
        DBController.Instance.CloseConnection();
        cbDepositBranch.DataSource = _oDepositBranchs;
        cbDepositBranch.DataTextField = "Name";
        cbDepositBranch.DataBind();
        cbDepositBranch.SelectedIndex = 0;
        Session.Add("DepositBranchs", _oDepositBranchs);
        //UpdatePanel1.Update();
       
    }
    protected void cmbInsBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        _oInstrumentBanks = (Banks)Session["InstrumentBanks"];

        _oInstrumentBranchs = new Branchs();
        DBController.Instance.OpenNewConnection();
        _oInstrumentBranchs.Refresh(_oInstrumentBanks[cmbInsBank.SelectedIndex].BankID);
        DBController.Instance.CloseConnection();
        cmbIstBranch.DataSource = _oInstrumentBranchs;
        cmbIstBranch.DataTextField = "Name";
        cmbIstBranch.DataBind();
        cmbIstBranch.SelectedIndex = 0;
        Session.Add("InstrumentBranchs", _oInstrumentBranchs);
        //UpdatePanel3.Update();
    }
 

    /// <summary>
    ///  UI Control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 
    private void SetInitialDepositDetaiRow()
    {

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("BankBranch", typeof(string)));
        dt.Columns.Add(new DataColumn("Type", typeof(string)));
        dt.Columns.Add(new DataColumn("Amount", typeof(string)));
        dt.Columns.Add(new DataColumn("BranchID", typeof(string)));
        dt.Columns.Add(new DataColumn("TypeID", typeof(string)));

        dr = dt.NewRow();

        dr["BankBranch"] = string.Empty;
        dr["Type"] = string.Empty;
        dr["Amount"] = string.Empty;
        dr["BranchID"] = string.Empty;
        dr["TypeID"] = string.Empty;

        dt.Rows.Add(dr);

        //dr = dt.NewRow();
        //Store the DataTable in ViewState

        ViewState["DepositDetailTable"] = dt;
        gdvDepositDetail.DataSource = dt;
        gdvDepositDetail.DataBind();

    }
    private void AddToDepositDetail()
    {
        _nRowIndex = 1;
        lblMessage.Visible = false;
        oOutletDeposit = (OutletDeposit)Session["OutletDeposit"];

        if (ViewState["DepositDetailTable"] != null)
        {

            DataTable dtDepositDetailTable = (DataTable)ViewState["DepositDetailTable"];
            DataRow drDepositDetailRow = null;


            try
            {
                _oDepositBranchs = (Branchs)Session["DepositBranchs"];
                _oOutletDepositDetail = new OutletDepositDetail();
                _oOutletDepositDetail.Amount = Convert.ToDouble(txtDepositAmount.Text);
                _oOutletDepositDetail.DepositBankBranch = _oDepositBranchs[cbDepositBranch.SelectedIndex].BranchID;
                _oOutletDepositDetail.DepositTypeID = cmbDepositType.SelectedIndex;
                oOutletDeposit.Add(_oOutletDepositDetail);
              
                dtDepositDetailTable.Rows.Clear();

                foreach (OutletDepositDetail oOutletDepositDetail in oOutletDeposit)
                {
                    DBController.Instance.OpenNewConnection();                  
                    drDepositDetailRow = dtDepositDetailTable.NewRow();

                    oBranch = new Branch();
                    oBranch.BranchID = oOutletDepositDetail.DepositBankBranch;
                    oBranch.Refresh();
                    oBank = new Bank();
                    oBank.BankID = oBranch.BankID;
                    oBank.Refresh();
                    DBController.Instance.CloseConnection();

                    drDepositDetailRow["BankBranch"] = oBank.Name + "/" + oBranch.Name;
                    drDepositDetailRow["Type"] = Enum.GetName(typeof(Dictionary.InstrumentType), oOutletDepositDetail.DepositTypeID);
                    drDepositDetailRow["Amount"] = oOutletDepositDetail.Amount.ToString();
                    drDepositDetailRow["BranchID"] = oOutletDepositDetail.DepositBankBranch.ToString();
                    drDepositDetailRow["TypeID"] = oOutletDepositDetail.DepositTypeID.ToString();

                    dtDepositDetailTable.Rows.Add(drDepositDetailRow);

                }             

                ViewState["DepositDetailTable"] = dtDepositDetailTable;
                gdvDepositDetail.DataSource = dtDepositDetailTable;
                gdvDepositDetail.DataBind();

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
        //SetPreviousDepositDetail();

    }
    private void SetPreviousDepositDetail()
    {
        _nRowIndex = 0;

        if (ViewState["DepositDetailTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["DepositDetailTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)gdvDepositDetail.Rows[_nRowIndex].Cells[0].FindControl("txtBank");
                    TextBox box2 = (TextBox)gdvDepositDetail.Rows[_nRowIndex].Cells[1].FindControl("txtAmout");
                    TextBox box3 = (TextBox)gdvDepositDetail.Rows[_nRowIndex].Cells[2].FindControl("txtType");
                    TextBox box4 = (TextBox)gdvDepositDetail.Rows[_nRowIndex].Cells[3].FindControl("txtBranchID");
                    TextBox box5 = (TextBox)gdvDepositDetail.Rows[_nRowIndex].Cells[4].FindControl("txtTypeID");

                    box1.Text = dt.Rows[i]["BankBranch"].ToString();
                    box2.Text = dt.Rows[i]["Amount"].ToString();
                    box3.Text = dt.Rows[i]["Type"].ToString();
                    box4.Text = dt.Rows[i]["BranchID"].ToString();
                    box5.Text = dt.Rows[i]["TypeID"].ToString();

                    _nRowIndex++;

                }
            }
        }
       
    }
    public void checkDuplicateDepositBranch()
    {
        int _nCount = 0;
        if (ViewState["DepositDetailTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["DepositDetailTable"];

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
            oOutletDeposit = (OutletDeposit)Session["OutletDeposit"];
            foreach (DataRow dRow in duplicateList)
            {
                int i = 0;
                foreach (OutletDepositDetail oOutletDepositDetail in oOutletDeposit)
                {
                    if (oOutletDepositDetail.DepositBankBranch == int.Parse(dRow["BranchID"].ToString()))
                    {
                        oOutletDeposit.RemoveAt(i);
                        break;
                    }
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

            ViewState["DepositDetailTable"] = dt;
            gdvDepositDetail.DataSource = dt;
            gdvDepositDetail.DataBind();

            SetPreviousDepositDetail();
        }
    }
    protected void btAdd_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;

        try
        {
            double temp = Convert.ToDouble(txtDepositAmount.Text);
        }
        catch
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Valid Amount";
            return;
        }
        if (cbDepositBranch.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Select Branch Name";
            return;
        }
        try
        {
            _oDepositBranchs = (Branchs)Session["DepositBranchs"];
        }
        catch
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Select Branch Name";
            return;
        }

        AddToDepositDetail();
        checkDuplicateDepositBranch();
        oOutletDeposit = (OutletDeposit)Session["OutletDeposit"];
        double _DepositAmount = 0;

        foreach (OutletDepositDetail oOutletDepositDetail in oOutletDeposit)
        {
            _DepositAmount = _DepositAmount + oOutletDepositDetail.Amount;
        }
        txtTotalDeposit.Text = _DepositAmount.ToString();
        //UpdatePanel2.Update();
    }

    private void SetInitialInvoiceDepositRow()
    {

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
        dt.Columns.Add(new DataColumn("InstrumentType", typeof(string)));
        dt.Columns.Add(new DataColumn("IntrumentNo", typeof(string)));
        dt.Columns.Add(new DataColumn("BankBranch", typeof(string)));
        dt.Columns.Add(new DataColumn("Date", typeof(string)));
        dt.Columns.Add(new DataColumn("Amount", typeof(string)));
        dt.Columns.Add(new DataColumn("InstrumentTypeID", typeof(string)));
        dt.Columns.Add(new DataColumn("BranchID", typeof(string)));

        dr = dt.NewRow();

        dr["InvoiceNo"] = string.Empty;
        dr["InstrumentType"] = string.Empty;
        dr["IntrumentNo"] = string.Empty;
        dr["BankBranch"] = string.Empty;
        dr["Date"] = string.Empty;
        dr["Amount"] = string.Empty;
        dr["InstrumentTypeID"] = string.Empty;
        dr["BranchID"] = string.Empty;


        dt.Rows.Add(dr);

        //dr = dt.NewRow();
        //Store the DataTable in ViewState

        ViewState["InvoiceDepositTable"] = dt;
        dvwInvDeposit.DataSource = dt;
        dvwInvDeposit.DataBind();

    }
    private void AddToInvoiceDeposit()
    {
        _nRowIndex = 1;
        lblMessage.Visible = false;

        _oOutletDepositInvoices = (OutletDepositInvoices)Session["OutletDepositInvoices"];

        if (ViewState["InvoiceDepositTable"] != null)
        {

            DataTable dtInvoiceDepositTable = (DataTable)ViewState["InvoiceDepositTable"];
            DataRow drInvoiceDepositRow = null;


            try
            {
                _oInstrumentBranchs = (Branchs)Session["InstrumentBranchs"];

                oOutletDepositInvoice = new OutletDepositInvoice();
                oOutletDepositInvoice.InvoiceNo = txtInvoiceNo.Text;
                oOutletDepositInvoice.InstrumentTypeID = cmbType.SelectedIndex;
                if (oOutletDepositInvoice.InstrumentTypeID != (int)Dictionary.InstrumentType.CASH)
                {
                    oOutletDepositInvoice.InstrumentNo = txtInstrumentNo.Text;
                    oOutletDepositInvoice.InstrumentBankBranch = _oInstrumentBranchs[cmbIstBranch.SelectedIndex].BranchID;
                }
                else
                {
                    oOutletDepositInvoice.InstrumentNo = "";
                    oOutletDepositInvoice.InstrumentBankBranch = 0;
                }
                oOutletDepositInvoice.InstrumentDate = new DateTime(Convert.ToInt32(cmbIstYear.SelectedValue), Convert.ToInt32(cmbIstMonth.SelectedValue), Convert.ToInt32(cmbIstDate.SelectedValue));
                oOutletDepositInvoice.Amount = Convert.ToDouble(txtInsAmount.Text);
                _oOutletDepositInvoices.Add(oOutletDepositInvoice);

                dtInvoiceDepositTable.Rows.Clear();

                foreach (OutletDepositInvoice _oOutletDepositInvoice in _oOutletDepositInvoices)
                {
                    DBController.Instance.OpenNewConnection();

                    drInvoiceDepositRow = dtInvoiceDepositTable.NewRow();

                    oBranch = new Branch();
                    oBranch.BranchID = _oOutletDepositInvoice.InstrumentBankBranch;
                    oBranch.Refresh();
                    oBank = new Bank();
                    oBank.BankID = oBranch.BankID;
                    oBank.Refresh();
                    DBController.Instance.CloseConnection();

                    drInvoiceDepositRow["InvoiceNo"] = _oOutletDepositInvoice.InvoiceNo;
                    drInvoiceDepositRow["InstrumentType"] = Enum.GetName(typeof(Dictionary.InstrumentType), _oOutletDepositInvoice.InstrumentTypeID);
                    if (_oOutletDepositInvoice.InstrumentTypeID != 0)
                    {
                        drInvoiceDepositRow["IntrumentNo"] = _oOutletDepositInvoice.InstrumentNo;
                        drInvoiceDepositRow["BankBranch"] = oBank.Name + "/" + oBranch.Name;
                        drInvoiceDepositRow["BranchID"] = _oOutletDepositInvoice.InstrumentBankBranch.ToString();
                    }
                    else
                    {
                        drInvoiceDepositRow["IntrumentNo"] = "";
                        drInvoiceDepositRow["BankBranch"] = "";
                        drInvoiceDepositRow["BranchID"] = "";
                    }
                    drInvoiceDepositRow["Date"] = _oOutletDepositInvoice.InstrumentDate.ToString("dd-MMM-yyyy");
                    drInvoiceDepositRow["Amount"] = _oOutletDepositInvoice.Amount.ToString();
                    drInvoiceDepositRow["InstrumentTypeID"] = _oOutletDepositInvoice.InstrumentTypeID.ToString();
                

                    dtInvoiceDepositTable.Rows.Add(drInvoiceDepositRow);

                }

                ViewState["InvoiceDepositTable"] = dtInvoiceDepositTable;
                dvwInvDeposit.DataSource = dtInvoiceDepositTable;
                dvwInvDeposit.DataBind();

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
        //SetPreviousDepositDetail();

    }

    public void checkDuplicateInsBranch()
    {
        int _nCount = 0;
        if (ViewState["InvoiceDepositTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["InvoiceDepositTable"];

            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            //foreach (DataRow drow in dt.Rows)
            //{
            //    if (hTable.Contains(drow["InvoiceNo"]))
            //    {
            //        duplicateList.Add(drow);
            //        _nCount++;
            //    }
            //    else
            //        hTable.Add(drow["InvoiceNo"], string.Empty);
            //}

            ////Removing a list of duplicate items from datatable.
            //_oOutletDepositInvoices = (OutletDepositInvoices)Session["OutletDepositInvoices"];
            //foreach (DataRow dRow in duplicateList)
            //{
            //    int i = 0;
            //    foreach (OutletDepositInvoice _oOutletDepositInvoice in _oOutletDepositInvoices)
            //    {
            //        if (_oOutletDepositInvoice.InvoiceNo == dRow["InvoiceNo"].ToString())
            //        {
            //            _oOutletDepositInvoices.RemoveAt(i);
            //            break;
            //        }
            //        i++;
            //    }
            //    dt.Rows.Remove(dRow);
            //}

            //if (_nCount != 0)
            //{
            //    lblMessage.Visible = true;
            //    lblMessage.Text = "Duplicate Invoice No.";
            //}

            //Datatable which contains unique records will be return as output.

            ViewState["InvoiceDepositTable"] = dt;
            dvwInvDeposit.DataSource = dt;
            dvwInvDeposit.DataBind();
            SetPreviousInvoiceDeposit();
        }
    }
    private void SetPreviousInvoiceDeposit()
    {
        _nRowIndex = 0;

        if (ViewState["InvoiceDepositTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["InvoiceDepositTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)dvwInvDeposit.Rows[_nRowIndex].Cells[0].FindControl("txtInvoiceNo");
                    TextBox box2 = (TextBox)dvwInvDeposit.Rows[_nRowIndex].Cells[1].FindControl("txtInstrumentType");
                    TextBox box3 = (TextBox)dvwInvDeposit.Rows[_nRowIndex].Cells[2].FindControl("txtIntrumentNo");
                    TextBox box4 = (TextBox)dvwInvDeposit.Rows[_nRowIndex].Cells[3].FindControl("txtBank");
                    TextBox box5 = (TextBox)dvwInvDeposit.Rows[_nRowIndex].Cells[4].FindControl("txtDate");
                    TextBox box6 = (TextBox)dvwInvDeposit.Rows[_nRowIndex].Cells[5].FindControl("txtAmount");
                    TextBox box7 = (TextBox)dvwInvDeposit.Rows[_nRowIndex].Cells[6].FindControl("txtInstrumentTypeID");
                    TextBox box8 = (TextBox)dvwInvDeposit.Rows[_nRowIndex].Cells[7].FindControl("txtBranchID");

                    box1.Text = dt.Rows[i]["InvoiceNo"].ToString();
                    box2.Text = dt.Rows[i]["InstrumentType"].ToString();
                    box3.Text = dt.Rows[i]["IntrumentNo"].ToString();
                    box4.Text = dt.Rows[i]["BankBranch"].ToString();
                    box5.Text = dt.Rows[i]["Date"].ToString();
                    box6.Text = dt.Rows[i]["Amount"].ToString();
                    box7.Text = dt.Rows[i]["InstrumentTypeID"].ToString();
                    box8.Text = dt.Rows[i]["BranchID"].ToString();

                    _nRowIndex++;

                }
            }
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;

        if (txtInvoiceNo.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Invoice No.";
            return;
        }
        try
        {
            _dDate = new DateTime(Convert.ToInt32(cmbIstYear.SelectedValue), Convert.ToInt32(cmbIstMonth.SelectedValue), Convert.ToInt32(cmbIstDate.SelectedValue));

        }
        catch
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Valid date.";
            return;
        }
        try
        {
            double temp = Convert.ToDouble(txtInsAmount.Text);
        }
        catch
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Valid Amount";
            return;
        }

        if (cmbType.SelectedIndex != (int)Dictionary.InstrumentType.CASH)
        {
            if (cmbIstBranch.Text == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Select Instrument Branch Name";
                return;
            }
            try
            {
                _oInstrumentBranchs = (Branchs)Session["InstrumentBranchs"];
            }
            catch
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Select Instrument Branch Name";
                return;
            }
        }
        AddToInvoiceDeposit();
        checkDuplicateInsBranch();
        _oOutletDepositInvoices = (OutletDepositInvoices)Session["OutletDepositInvoices"];
        double _InvoiceAmount = 0;
        foreach (OutletDepositInvoice _oOutletDepositInvoice in _oOutletDepositInvoices)
        {
            _InvoiceAmount = _InvoiceAmount + _oOutletDepositInvoice.Amount;
        }
        txtTotalInvoiceAmount.Text = _InvoiceAmount.ToString();
        //UpdatePanel4.Update();
    }

    private bool validateUIInput()
    {

        try
        {
            _dDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmbDate.SelectedValue));
            
        }
        catch
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Valid Deposit Date";
            return false;
        }

        _oOutletDepositInvoices = (OutletDepositInvoices)Session["OutletDepositInvoices"];
        oOutletDeposit = (OutletDeposit)Session["OutletDeposit"];

        if (oOutletDeposit.Count <= 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Valid Deposit Detail";
            return false;
        }        
        if (_oOutletDepositInvoices.Count<=0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Valid Deposit Invoice Detail";
            return false;
        }
        double _DepositAmount = 0;
        foreach (OutletDepositDetail oOutletDepositDetail in oOutletDeposit)
        {
            _DepositAmount = _DepositAmount + oOutletDepositDetail.Amount;
        }
        double _InvoiceAmount = 0;
        foreach (OutletDepositInvoice _oOutletDepositInvoice in _oOutletDepositInvoices)
        {
            _InvoiceAmount = _InvoiceAmount + _oOutletDepositInvoice.Amount;
        }
        if (_DepositAmount != _InvoiceAmount)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Total Deposit Amount and Total Instrument Amount are not same";
            return false;
        }
        return true;
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        if (validateUIInput())
        {
            User oUser = (User)Session["User"];
            Customer oCustomer = (Customer)Session["Customer"];
            _oOutletDepositInvoices = (OutletDepositInvoices)Session["OutletDepositInvoices"];
            oOutletDeposit = (OutletDeposit)Session["OutletDeposit"];

            oOutletDeposit.CustomerID = oCustomer.CustomerID;
            oOutletDeposit.TranDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmbDate.SelectedValue));
            oOutletDeposit.UserID = oUser.UserId;
            oOutletDeposit.Remarks = txtRemarks.Text;
            oOutletDeposit.oOutletDepositInvoices = new OutletDepositInvoices();
            foreach (OutletDepositInvoice oOutletDepositInvoice in _oOutletDepositInvoices)
            {
                oOutletDeposit.oOutletDepositInvoices.Add(oOutletDepositInvoice);
            }

            try
            {
                DBController.Instance.BeginNewTransaction();
                oOutletDeposit.Insert();
                DBController.Instance.CommitTransaction();
                string[] sSuccedCode =  { " " };
                Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                UIUtility.GetConfirmationMsg("Save", "The Deposit", sSuccedCode, null, "frmDCSs.aspx", 0);
                Response.Redirect("frmMessage.aspx");
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                lblMessage.Visible = true;
                lblMessage.Text = "Error..."+ex;
                return;

            }
        }
    }

    protected void DepositDeleting(object sender, GridViewDeleteEventArgs e)
    {
        oOutletDeposit = (OutletDeposit)Session["OutletDeposit"];

        GridViewRow row = (GridViewRow)gdvDepositDetail.Rows[e.RowIndex];
        TextBox BranchID = (TextBox)row.FindControl("txtBranchID");

        int i = 0;
        foreach (OutletDepositDetail oOutletDepositDetail in oOutletDeposit)
        {
            if (oOutletDepositDetail.DepositBankBranch == int.Parse(BranchID.Text))
            {
                oOutletDeposit.RemoveAt(i);
                break;
            }
            i++;
        }

        if (ViewState["DepositDetailTable"] != null)
        {
            DataTable dtDepositDetailTable = (DataTable)ViewState["DepositDetailTable"];
            DataRow drDepositDetailRow = null;

            dtDepositDetailTable.Rows.Clear();

            foreach (OutletDepositDetail oOutletDepositDetail in oOutletDeposit)
            {
                DBController.Instance.OpenNewConnection();
                drDepositDetailRow = dtDepositDetailTable.NewRow();

                oBranch = new Branch();
                oBranch.BranchID = oOutletDepositDetail.DepositBankBranch;
                oBranch.Refresh();
                oBank = new Bank();
                oBank.BankID = oBranch.BankID;
                oBank.Refresh();
                DBController.Instance.CloseConnection();

                drDepositDetailRow["BankBranch"] = oBank.Name + "/" + oBranch.Name;
                drDepositDetailRow["Amount"] = oOutletDepositDetail.Amount.ToString();
                drDepositDetailRow["BranchID"] = oOutletDepositDetail.DepositBankBranch.ToString();

                dtDepositDetailTable.Rows.Add(drDepositDetailRow);

            }

            ViewState["DepositDetailTable"] = dtDepositDetailTable;
            gdvDepositDetail.DataSource = dtDepositDetailTable;
            gdvDepositDetail.DataBind();

            if (oOutletDeposit.Count > 0)
                SetPreviousDepositDetail();
            else SetInitialDepositDetaiRow();
        }
      
    }
    protected void InvoiceDeleting(object sender, GridViewDeleteEventArgs e)
    {
        _oOutletDepositInvoices = (OutletDepositInvoices)Session["OutletDepositInvoices"];

        GridViewRow row = (GridViewRow)dvwInvDeposit.Rows[e.RowIndex];
        TextBox InvoiceNo = (TextBox)row.FindControl("txtInvoiceNo");

        int i = 0;
        foreach (OutletDepositInvoice _oOutletDepositInvoice in _oOutletDepositInvoices)
        {
            if (_oOutletDepositInvoice.InvoiceNo == InvoiceNo.Text)
            {
                _oOutletDepositInvoices.RemoveAt(i);
                break;
            }
            i++;
        }    

        if (ViewState["InvoiceDepositTable"] != null)
        {

            DataTable dtInvoiceDepositTable = (DataTable)ViewState["InvoiceDepositTable"];
            DataRow drInvoiceDepositRow = null;

            dtInvoiceDepositTable.Rows.Clear();

            foreach (OutletDepositInvoice _oOutletDepositInvoice in _oOutletDepositInvoices)
            {
                DBController.Instance.OpenNewConnection();

                drInvoiceDepositRow = dtInvoiceDepositTable.NewRow();

                oBranch = new Branch();
                oBranch.BranchID = _oOutletDepositInvoice.InstrumentBankBranch;
                oBranch.Refresh();
                oBank = new Bank();
                oBank.BankID = oBranch.BankID;
                oBank.Refresh();
                DBController.Instance.CloseConnection();

                drInvoiceDepositRow["InvoiceNo"] = _oOutletDepositInvoice.InvoiceNo;
                drInvoiceDepositRow["InstrumentType"] = Enum.GetName(typeof(Dictionary.InstrumentType), _oOutletDepositInvoice.InstrumentTypeID);
                drInvoiceDepositRow["IntrumentNo"] = _oOutletDepositInvoice.InstrumentNo;
                drInvoiceDepositRow["BankBranch"] = oBank.Name + "/" + oBranch.Name;
                drInvoiceDepositRow["Date"] = _oOutletDepositInvoice.InstrumentDate.ToString("dd-MMM-yyyy");
                drInvoiceDepositRow["Amount"] = _oOutletDepositInvoice.Amount.ToString();
                drInvoiceDepositRow["InstrumentTypeID"] = _oOutletDepositInvoice.InstrumentTypeID.ToString();
                drInvoiceDepositRow["BranchID"] = _oOutletDepositInvoice.InstrumentBankBranch.ToString();

                dtInvoiceDepositTable.Rows.Add(drInvoiceDepositRow);

            }

            ViewState["InvoiceDepositTable"] = dtInvoiceDepositTable;
            dvwInvDeposit.DataSource = dtInvoiceDepositTable;
            dvwInvDeposit.DataBind();


            if (_oOutletDepositInvoices.Count > 0)
                SetPreviousInvoiceDeposit();
            else SetInitialInvoiceDepositRow();
        }

    }


    public void SetUI()
    {
        oOutletDeposit = (OutletDeposit)Session["OutletDeposit"];
        txtRemarks.Text = oOutletDeposit.Remarks;

        cmbDate.Text = oOutletDeposit.TranDate.Day.ToString();
        cmbYear.Text =oOutletDeposit.TranDate.Year.ToString();

        if (ViewState["DepositDetailTable"] != null)
        {
            DataTable dtDepositDetailTable = (DataTable)ViewState["DepositDetailTable"];
            DataRow drDepositDetailRow = null;

            dtDepositDetailTable.Rows.Clear();

            foreach (OutletDepositDetail oOutletDepositDetail in oOutletDeposit)
            {
                DBController.Instance.OpenNewConnection();
                drDepositDetailRow = dtDepositDetailTable.NewRow();

                oBranch = new Branch();
                oBranch.BranchID = oOutletDepositDetail.DepositBankBranch;
                oBranch.Refresh();
                oBank = new Bank();
                oBank.BankID = oBranch.BankID;
                oBank.Refresh();
                DBController.Instance.CloseConnection();

                drDepositDetailRow["BankBranch"] = oBank.Name + "/" + oBranch.Name;
                drDepositDetailRow["Type"] = Enum.GetName(typeof(Dictionary.InstrumentType), oOutletDepositDetail.DepositTypeID);
                drDepositDetailRow["Amount"] = oOutletDepositDetail.Amount.ToString();
                drDepositDetailRow["BranchID"] = oOutletDepositDetail.DepositBankBranch.ToString();
                drDepositDetailRow["TypeID"] = oOutletDepositDetail.DepositTypeID.ToString();

                dtDepositDetailTable.Rows.Add(drDepositDetailRow);

            }

            ViewState["DepositDetailTable"] = dtDepositDetailTable;
            gdvDepositDetail.DataSource = dtDepositDetailTable;
            gdvDepositDetail.DataBind();
        }
        SetPreviousDepositDetail();
   
        double _DepositAmount = 0;

        foreach (OutletDepositDetail oOutletDepositDetail in oOutletDeposit)
        {
            _DepositAmount = _DepositAmount + oOutletDepositDetail.Amount;
        }
        txtTotalDeposit.Text = _DepositAmount.ToString();
        _oOutletDepositInvoices = (OutletDepositInvoices)Session["OutletDepositInvoices"];


        if (ViewState["InvoiceDepositTable"] != null)
        {

            DataTable dtInvoiceDepositTable = (DataTable)ViewState["InvoiceDepositTable"];
            DataRow drInvoiceDepositRow = null;

            dtInvoiceDepositTable.Rows.Clear();

            foreach (OutletDepositInvoice _oOutletDepositInvoice in _oOutletDepositInvoices)
            {
                DBController.Instance.OpenNewConnection();

                drInvoiceDepositRow = dtInvoiceDepositTable.NewRow();

                oBranch = new Branch();
                oBranch.BranchID = _oOutletDepositInvoice.InstrumentBankBranch;
                oBranch.Refresh();
                oBank = new Bank();
                oBank.BankID = oBranch.BankID;
                oBank.Refresh();
                DBController.Instance.CloseConnection();

                drInvoiceDepositRow["InvoiceNo"] = _oOutletDepositInvoice.InvoiceNo;
                drInvoiceDepositRow["InstrumentType"] = Enum.GetName(typeof(Dictionary.InstrumentType), _oOutletDepositInvoice.InstrumentTypeID);
                if (_oOutletDepositInvoice.InstrumentTypeID != 0)
                {
                    drInvoiceDepositRow["IntrumentNo"] = _oOutletDepositInvoice.InstrumentNo;
                    drInvoiceDepositRow["BankBranch"] = oBank.Name + "/" + oBranch.Name;
                    drInvoiceDepositRow["BranchID"] = _oOutletDepositInvoice.InstrumentBankBranch.ToString();
                }
                else
                {
                    drInvoiceDepositRow["IntrumentNo"] = "";
                    drInvoiceDepositRow["BankBranch"] = "";
                    drInvoiceDepositRow["BranchID"] = "";
                }
                drInvoiceDepositRow["Date"] = _oOutletDepositInvoice.InstrumentDate.ToString("dd-MMM-yyyy");
                drInvoiceDepositRow["Amount"] = _oOutletDepositInvoice.Amount.ToString();
                drInvoiceDepositRow["InstrumentTypeID"] = _oOutletDepositInvoice.InstrumentTypeID.ToString();
                

                dtInvoiceDepositTable.Rows.Add(drInvoiceDepositRow);

            }

            ViewState["InvoiceDepositTable"] = dtInvoiceDepositTable;
            dvwInvDeposit.DataSource = dtInvoiceDepositTable;
            dvwInvDeposit.DataBind();
        }
        SetPreviousInvoiceDeposit();
     
        double _InvoiceAmount = 0;
        foreach (OutletDepositInvoice _oOutletDepositInvoice in _oOutletDepositInvoices)
        {
            _InvoiceAmount = _InvoiceAmount + _oOutletDepositInvoice.Amount;
        }
        txtTotalInvoiceAmount.Text = _InvoiceAmount.ToString();
    }

    protected void btPrint_Click(object sender, EventArgs e)
    {
        oOutletDeposit = (OutletDeposit)Session["OutletDeposit"];
        User oUser = (User)Session["User"];
        Customer oCustomer = (Customer)Session["Customer"];
        oDSDCS = new DSDCS();
        DBController.Instance.OpenNewConnection();

        oDSDCS = oOutletDeposit.RefreshDetailForReport(oDSDCS);
        oDSDCS = oOutletDeposit.OutletDepositInvoices.RefreshForReport(oDSDCS, oOutletDeposit.OutletDepositID);
      
        DBController.Instance.CloseConnection();

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptDCS));

        doc.SetDataSource(oDSDCS);

        doc.SetParameterValue("OutletCode", oCustomer.CustomerName.Substring(0,3));
        doc.SetParameterValue("OutletName", oCustomer.CustomerName);
        doc.SetParameterValue("DepositNo", oOutletDeposit.OutletDepositNo);
        doc.SetParameterValue("DepositDate", oOutletDeposit.TranDate.ToString("dd-MMM-yyyy"));
        doc.SetParameterValue("User", oUser.Username);

        Session.Remove("Doc");
        Session.Add("Doc", doc);
        Session["ReportName"] = "Daily Oulet Collection [DCS]";
        Response.Redirect("~/Report/frmReportViewer.aspx");
    }
   
    protected void cmbType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbType.SelectedIndex == (int)Dictionary.InstrumentType.CASH)
        {
            txtInstrumentNo.Enabled = false;
            cmbInsBank.Enabled = false;
            cmbIstBranch.Enabled = false;
        }
        else
        {
            txtInstrumentNo.Enabled = true;
            cmbInsBank.Enabled = true;
            cmbIstBranch.Enabled = true;
        }
      
    }
}
    


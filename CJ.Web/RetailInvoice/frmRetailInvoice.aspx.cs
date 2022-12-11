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

public partial class RetailInvoice_frmRetailInvoice : System.Web.UI.Page
{
    WUIUtility _oWUIUtility;
    Warehouses _oWarehouses;
    Warehouse _oWarehouse;
    CustomerDetail _oCustomerDetail;
    Customers _oCustomers;
    Customer _oCustomer;
    ProductDetail _oProductDetail;
    SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
    SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
    SalesInvoice _oSalesInvoice;
    CustomerTransaction _oCustomerTransaction;
    ProductStock _oProductStock;
    ProductStocks _oProductStocks;
    SundryCustomer _oSundryCustomer;
    SundryCustomers _oSundryCustomers;
    rptSalesInvoice _orptSalesInvoice;

    DateTime _dOrderDate;
    DateTime _dDDate;
    int _nRowIndex = 0;
    double _nPriceOption;
    bool IsUpdate = false;
    bool bFlag = true;
    bool IsAlterMOQ = false;
    string _sFeildName;
    User oUser;
    int oTMLRetailChannel = 0;
    int nWarehouseID = 0;
    //int InitializeCondition = 0;
    string sSplit = "";
    TELLib oLib;
    string SL = "";
    bool IsSL = true;
    SalesInvoiceProductSerials oSIPSs;

    protected void Page_Load(object sender, EventArgs e)
    {
        //txtDDAmount.Style["text-align"] = "right";
        txtTotal.Style["text-align"] = "right";
        txtDiscount.Style["text-align"] = "right";
        txtAmounttoPay.Style["text-align"] = "right";

        cbOday.Text = DateTime.Today.Day.ToString();
        cbOmonth.Text = DateTime.Today.Month.ToString();
        cbOyear.Text = DateTime.Today.Year.ToString();

        oTMLRetailChannel = Convert.ToInt32(ConfigurationManager.AppSettings["CentralTMLChannel"].ToString());

        if (!IsPostBack)
        {
            Session.Remove("Warehouse");
            Session.Remove("SalesPromotions");
            oUser = (User)Session["User"];

            Session.Remove("InitializeCondition");
            Session.Add("InitializeCondition", 1);

            LoadCombo();

            SetInitialRow();

        }
    }
    private void LoadCombo()
    {
        _oWarehouses = new Warehouses();
        _oCustomers = new Customers();

        Session.Remove("Warehouse");
        Session.Remove("Customer");

        DBController.Instance.OpenNewConnection();
        _oWarehouses.GetFromWarehouseByUser(oUser.UserId);
        _oCustomers.RefreshByPermission(oUser.UserId);
        DBController.Instance.CloseConnection();


        if (_oWarehouses.Count > 0)
        {
            cbWarehouseName.DataSource = _oWarehouses;
            cbWarehouseName.DataTextField = "WarehouseName";
            cbWarehouseName.DataBind();
            cbWarehouseName.SelectedIndex = 0;
            Session.Add("Warehouse", _oWarehouses[cbWarehouseName.SelectedIndex].WarehouseID);
        }
        else
        {
            _oWarehouse = new Warehouse();
            _oWarehouse.WarehouseName = "No Permission";
            _oWarehouses.Add(_oWarehouse);

            cbWarehouseName.DataSource = _oWarehouses;
            cbWarehouseName.DataTextField = "WarehouseName";
            cbWarehouseName.DataBind();
            cbWarehouseName.SelectedIndex = 0;
            Session.Remove("Warehouse");
        }

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
    private void SetInitialRow()
    {

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("ProductCode", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
        dt.Columns.Add(new DataColumn("UnitPrice", typeof(string)));
        dt.Columns.Add(new DataColumn("Qty", typeof(string)));
        dt.Columns.Add(new DataColumn("GTotal", typeof(string)));
        dt.Columns.Add(new DataColumn("DisAmt", typeof(string)));
        dt.Columns.Add(new DataColumn("TotalPrice", typeof(string)));
        dt.Columns.Add(new DataColumn("Barcode", typeof(string)));
        dt.Columns.Add(new DataColumn("CurrentStock", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductID", typeof(string)));

        dr = dt.NewRow();

        dr["ProductCode"] = string.Empty;
        dr["ProductName"] = string.Empty;
        dr["UnitPrice"] = string.Empty;
        dr["Qty"] = string.Empty;
        dr["GTotal"] = string.Empty;
        dr["DisAmt"] = string.Empty;
        dr["TotalPrice"] = string.Empty;
        dr["Barcode"] = string.Empty;
        dr["CurrentStock"] = string.Empty;
        dr["ProductID"] = string.Empty;

        dt.Rows.Add(dr);

        //dr = dt.NewRow();
        //Store the DataTable in ViewState

        ViewState["RetailInvoiceTable"] = dt;
        dvwRetailInvoice.DataSource = dt;
        dvwRetailInvoice.DataBind();

    }
    private void AddToGrid(bool Istrue)
    {
        _nRowIndex = 0;
        lblMessage.Visible = false;
        if (ViewState["RetailInvoiceTable"] != null)
        {
            int i;
            DataTable dtSalesOrderTable = (DataTable)ViewState["RetailInvoiceTable"];
            DataRow drSalesOrderRow = null;

            if (dtSalesOrderTable.Rows.Count > 0)
            {
                try
                {
                    for (i = 1; i <= dtSalesOrderTable.Rows.Count; i++)
                    {
                        //extract the TextBox values

                        TextBox box1 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[0].FindControl("txtProductCode");
                        TextBox box2 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[1].FindControl("txtProductName");
                        TextBox box3 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[2].FindControl("txtUnitPrice");
                        TextBox box4 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[3].FindControl("txtQty");
                        TextBox box5 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[4].FindControl("txtGTotal");
                        TextBox box6 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[5].FindControl("txtDiscountAmt");
                        TextBox box7 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[6].FindControl("txtTotalPrice");
                        TextBox box8 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[7].FindControl("txtBarcode");
                        TextBox box9 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[8].FindControl("txtCurrentStock");
                        TextBox box10 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[9].FindControl("txtProductID");

                        _oWUIUtility = new WUIUtility();
                        //_oWarehouses = (Warehouses)Session["Warehouses"];
                        nWarehouseID = (int)Session["Warehouse"];
                        _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];


                        if (nWarehouseID == null)
                        {
                            bFlag = false;
                            lblMessage.Visible = true;
                            lblMessage.Text = "Please Select a Customer or Valid Warehouse name";
                            AppLogger.LogWarning("Web: Invalid Warehouse   =" + lblMessage.Text);
                            return;
                        }

                        _oProductDetail = new ProductDetail();
                        _oProductDetail.ProductCode = box1.Text;
                        _oProductDetail.GetMRPByProductCode();

                        if (_oProductDetail.Flag == false)
                        {
                            bFlag = false;
                            lblMessage.Visible = true;
                            lblMessage.Text = "Product Not Found.Please Input Valid Product Code";
                            AppLogger.LogWarning("Web: Product Not Found  =" + lblMessage.Text);
                            return;
                        }

                        drSalesOrderRow = dtSalesOrderTable.NewRow();


                        dtSalesOrderTable.Rows[i - 1]["ProductCode"] = box1.Text;

                        dtSalesOrderTable.Rows[i - 1]["ProductName"] = _oProductDetail.ProductName;

                        dtSalesOrderTable.Rows[i - 1]["UnitPrice"] = _oProductDetail.MRP.ToString();
                        box3.Text = _oProductDetail.MRP.ToString();

                        dtSalesOrderTable.Rows[i - 1]["ProductID"] = _oProductDetail.ProductID;


                        _oWUIUtility.GetCurrentStock(oTMLRetailChannel, nWarehouseID, _oProductDetail.ProductID);
                        Session.Add("WUIUtility", _oWUIUtility);

                        dtSalesOrderTable.Rows[i - 1]["CurrentStock"] = _oWUIUtility.CurrentStock.ToString();
                        dtSalesOrderTable.Rows[i - 1]["Qty"] = box4.Text;

                        if (box3.Text != "" && box4.Text != "")
                        {
                            try
                            {

                                dtSalesOrderTable.Rows[i - 1]["DisAmt"] = "0";

                                double DisAmt = (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["DisAmt"].ToString()));
                                dtSalesOrderTable.Rows[i - 1]["GTotal"] = (Convert.ToDouble(box3.Text) * Convert.ToDouble(box4.Text));
                                dtSalesOrderTable.Rows[i - 1]["TotalPrice"] = (Convert.ToDouble(box3.Text) * Convert.ToDouble(box4.Text)) - DisAmt;
                            }
                            catch
                            {

                                lblMessage.Visible = true;
                                lblMessage.Text = "Please Input Valid Product Quantity or Unit Price Should be Greater than Zero";
                                return;
                            }
                        }
                        else dtSalesOrderTable.Rows[i - 1]["TotalPrice"] = "";

                        _nRowIndex++;

                    }
                    if (Istrue == true)
                        dtSalesOrderTable.Rows.Add(drSalesOrderRow);

                    ViewState["RetailInvoiceTable"] = dtSalesOrderTable;
                    dvwRetailInvoice.DataSource = dtSalesOrderTable;
                    dvwRetailInvoice.DataBind();

                    if (Istrue == true)
                        dvwRetailInvoice.Rows[_nRowIndex].Cells[1].Focus();
                }
                catch (Exception ex)
                {
                    bFlag = false;
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error...." + ex;
                    return;
                }
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        cbWarehouseName.Enabled = false;
        cmbOutlet.Enabled = false;
        SetPreviousData();

    }
    private void SetPreviousData()
    {
        _nRowIndex = 0;

        if (ViewState["RetailInvoiceTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["RetailInvoiceTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[0].FindControl("txtProductCode");
                    TextBox box2 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[1].FindControl("txtProductName");
                    TextBox box3 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[2].FindControl("txtUnitPrice");
                    TextBox box4 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[3].FindControl("txtQty");
                    TextBox box5 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[4].FindControl("txtGTotal");
                    TextBox box6 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[5].FindControl("txtDiscountAmt");
                    TextBox box7 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[6].FindControl("txtTotalPrice");
                    TextBox box8 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[7].FindControl("txtBarcode");
                    TextBox box9 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[8].FindControl("txtCurrentStock");
                    TextBox box10 = (TextBox)dvwRetailInvoice.Rows[_nRowIndex].Cells[9].FindControl("txtProductID");



                    box1.Text = dt.Rows[i]["ProductCode"].ToString();
                    box2.Text = dt.Rows[i]["ProductName"].ToString();
                    box3.Text = dt.Rows[i]["UnitPrice"].ToString();
                    box4.Text = dt.Rows[i]["Qty"].ToString();
                    box5.Text = dt.Rows[i]["GTotal"].ToString();
                    box6.Text = dt.Rows[i]["DisAmt"].ToString();
                    box7.Text = dt.Rows[i]["TotalPrice"].ToString();
                    box8.Text = dt.Rows[i]["Barcode"].ToString();
                    box9.Text = dt.Rows[i]["CurrentStock"].ToString();
                    box10.Text = dt.Rows[i]["ProductID"].ToString();

                    _nRowIndex++;

                }
            }
        }
        GetTotalAmount();
    }
    public void GetTotalAmount()
    {
        txtTotal.Text = "0.00";
        txtAmounttoPay.Text = "0.00";
        double _Total = 0;
        oLib = new TELLib();

        if (ViewState["RetailInvoiceTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["RetailInvoiceTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["TotalPrice"].ToString() != "")
                    {
                        try
                        {
                            _Total = _Total + Convert.ToDouble(dt.Rows[i]["TotalPrice"].ToString());
                        }
                        catch
                        {
                            _Total = 0;
                            lblMessage.Visible = true;
                            lblMessage.Text = "Please Check your Product Details";
                            return;
                        }
                    }

                }
                txtTotal.Text = _Total.ToString();
                txtAmounttoPay.Text = _Total.ToString();
                oLib = new TELLib();
                lvInword.Text = oLib.TakaWords(Convert.ToDouble(txtAmounttoPay.Text));
                Session.Add("Total", _Total);

                //ckbDiscount_CheckedChanged(null, null);
            }
        }

    }
    public void checkDuplicateLineItem()
    {
        int _nCount = 0;
        if (ViewState["RetailInvoiceTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["RetailInvoiceTable"];

            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dt.Rows)
            {
                if (hTable.Contains(drow["ProductCode"]))
                {
                    duplicateList.Add(drow);
                    _nCount++;
                }
                else
                    hTable.Add(drow["ProductCode"], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dt.Rows.Remove(dRow);

            if (_nCount != 0)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Duplicate Item. Please input valid Product Code";
            }

            //Datatable which contains unique records will be return as output.
            ViewState["RetailInvoiceTable"] = dt;
            dvwRetailInvoice.DataSource = dt;
            dvwRetailInvoice.DataBind();
            SetPreviousData();
        }
    }
    protected void rdoNew_CheckedChanged(object sender, EventArgs e)
    {
    }
    protected void rdoExisting_CheckedChanged(object sender, EventArgs e)
    {
    }
    protected void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void txtCustomerCode_TextChanged(object sender, System.EventArgs e)
    {
    }
    protected void txtProductCode_TextChanged(object sender, System.EventArgs e)
    {
        DBController.Instance.OpenNewConnection();

        AddToGrid(false);
        if (bFlag == true)
        {
            checkDuplicateLineItem();
            dvwRetailInvoice.Rows[_nRowIndex - 1].Cells[4].Focus();
        }
        else
        {
            bFlag = true;
        }
        DBController.Instance.CloseConnection();

    }
    protected void btGo_Click(object sender, EventArgs e)
    {
    }
    protected void txtQty_TextChanged(object sender, System.EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        AddToGrid(true);
        DBController.Instance.CloseConnection();
    }
    protected void btnMove_Click(object sender, EventArgs e)
    {
        int IMEIQty = 0;
        string s = txtSerialNo.Text;
        if (txtSerialNo.Text.Trim() != "")
        {
            int a = (int)Session["InitializeCondition"];
            if (a == 1)
            {
                _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();
                Session.Add("InitializeCondition", 0);
            }

            string value = txtSerialNo.Text;
            char[] delimiter = new char[] { '\r', '\n' };
            string[] parts = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {

                sSplit = parts[i].ToString();

                _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                _oSalesInvoiceProductSerial.ProductSerialNo = sSplit.Trim();
                DBController.Instance.OpenNewConnection();
                _oSalesInvoiceProductSerial.GetProductIDByIMEI();


                if (ViewState["RetailInvoiceTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["RetailInvoiceTable"];

                    if (dt.Rows.Count > 0)
                    {
                        for (int x = 0; x < dt.Rows.Count; x++)
                        {

                            if (dt.Rows[x]["ProductCode"] != DBNull.Value && dt.Rows[x]["Qty"] != DBNull.Value)
                            {
                                if (Convert.ToString(dt.Rows[x]["ProductCode"]) == _oSalesInvoiceProductSerial.ProductCode)
                                {

                                    if (dt.Rows[x]["Barcode"] == string.Empty)
                                    {
                                        IMEIQty = 0;
                                        if (IMEIQty <= Convert.ToInt32(dt.Rows[x]["Qty"].ToString()))
                                        {
                                            dt.Rows[x]["Barcode"] = IMEIQty + 1;

                                            _oSalesInvoiceProductSerial.ProductID = _oSalesInvoiceProductSerial.ProductID;
                                            _oSalesInvoiceProductSerial.ProductSerialNo = sSplit;
                                            _oSalesInvoiceProductSerials.Add(_oSalesInvoiceProductSerial);

                                            //oSIPSs.Add(_oSalesInvoiceProductSerial);

                                            //oSIPSs = (SalesInvoiceProductSerials)Session["BarcodeList"];
                                            //Session.Add("BarcodeList", sSplit);
                                            //oSIPSs.Add(_oSalesInvoiceProductSerial);
                                            //Session.Add("ProductSerial", _oCustomers[cmbOutlet.SelectedIndex].CustomerID);
                                            //InitializeCondition = 1;

                                            //int ncount = _oSalesInvoiceProductSerials.Count;
                                        }

                                    }
                                    else
                                    {

                                        if (IMEICheckFromCollection())
                                        {
                                            if (Convert.ToInt32(dt.Rows[x]["Barcode"].ToString()) < Convert.ToInt32(dt.Rows[x]["Qty"].ToString()))
                                            {
                                                dt.Rows[x]["Barcode"] = Convert.ToInt32(dt.Rows[x]["Barcode"].ToString()) + 1;
                                                _oSalesInvoiceProductSerial.ProductID = _oSalesInvoiceProductSerial.ProductID;
                                                _oSalesInvoiceProductSerial.ProductSerialNo = sSplit;

                                                //oSIPSs = (SalesInvoiceProductSerials)Session["BarcodeList"];
                                                //Session.Add("BarcodeList", sSplit);
                                                //oSIPSs.Add(_oSalesInvoiceProductSerial);
                                                _oSalesInvoiceProductSerials.Add(_oSalesInvoiceProductSerial);
                                            }
                                        }
                                        else
                                        {
                                            
                                        }
                                    }

                                }

                            }

                        }

                    }

                }

            }
            Session.Remove("BarcodeList");
            Session.Add("BarcodeList", _oSalesInvoiceProductSerials);
            //Session.Add("BarcodeList", oSIPSs);

            txtSerialNo.Text = "";
            SetPreviousData();
        }
        else
        {
            //MessageBox.Show("There is no IMEI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
    public bool IMEICheckFromCollection()
    {
        //oSIPSs = (SalesInvoiceProductSerials)Session["BarcodeList"];

        //foreach (SalesInvoiceProductSerial oSIPS in oSIPSs)
        foreach (SalesInvoiceProductSerial oSIPS in _oSalesInvoiceProductSerials)
        {
            if (oSIPS.ProductSerialNo != sSplit)
            {
                return true;
            }
        }

        return false;
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        User oUser = (User)Session["User"];
        if (validateUIInput())
        {
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oSalesInvoice = new SalesInvoice();
                _oProductStocks = new ProductStocks();
                _oSundryCustomer = new SundryCustomer();

                _oSundryCustomer = GetDataForSundryCustomerInfo(_oSundryCustomer);
                _oSundryCustomer.Add();

                _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice);
                _oSalesInvoice.SundryCustomerID = _oSundryCustomer.SundryCustomerID;
                _oSalesInvoice.InsertRetailInvoice(false);

                _oProductStock = new ProductStock();
                _oProductStock = GetDataForProductStock(_oProductStock);

                foreach (ProductStock oProductStock in _oProductStocks)
                {
                    _oProductStock.UpdateCurrentStock_POS(true);
                }
                _oCustomerTransaction = new CustomerTransaction();
                _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction);
                _oCustomerTransaction.AddForRetailInvoice(false);

                SalesInvoiceProductSerials SIPSs = (SalesInvoiceProductSerials)Session["BarcodeList"];
                #region Add IMEI
                int nCount = 0;
                int nProductID = 0;
                foreach (SalesInvoiceProductSerial oSIPS in SIPSs)
                {

                    if (nProductID != oSIPS.ProductID)
                    {
                        nCount = 0;
                        oSIPS.InvoiceID = _oSalesInvoice.InvoiceID;
                        oSIPS.ProductID = oSIPS.ProductID;
                        oSIPS.SerialNo = nCount + 1;
                        oSIPS.ProductSerialNo = oSIPS.ProductSerialNo;

                        oSIPS.AddIMEI();
                        nProductID = oSIPS.ProductID;
                        nCount++;
                    }
                    else
                    {
                        oSIPS.InvoiceID = _oSalesInvoice.InvoiceID;
                        oSIPS.ProductID = oSIPS.ProductID;
                        oSIPS.SerialNo = nCount + 1;
                        oSIPS.ProductSerialNo = oSIPS.ProductSerialNo;

                        oSIPS.AddIMEI();
                        nProductID = oSIPS.ProductID;
                        nCount++;
                    }
                }
                #endregion

                DBController.Instance.CommitTran();
                PrintInvoice();
                AppLogger.LogInfo("Web: Successfully Add SaleInvoice  =" + oUser.Username);
                string[] sSuccedCode =  { "" };
                Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                UIUtility.GetConfirmationMsg("Save", "This Transaction", sSuccedCode, null, "RetailInvoice/frmRetailInvoices.aspx", 0);
                
                Response.Redirect("../frmMessage.aspx");
                

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                //AppLogger.LogError("Web: Unuccessfull Add SaleOrder  =" + ex);
                lblMessage.Visible = true;
                lblMessage.Text = "Error.......Please check your input and save again ";
            }
        }

    }
    private bool validateUIInput()
    {
        #region Retail Invoice Master Information Validation
        //_oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];

        if (cbWarehouseName.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Invalid Warehouse Name";
            return false;
        }
        if (cbWarehouseName.Text == "No Permission")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have no permission any Warehouse";
            return false;
        }
        if (cmbOutlet.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Invalid Outlet Name";
            return false;
        }
        if (cmbOutlet.Text == "No Permission")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have no permission any Outlet";
            return false;
        }
        if (txtCustomerName.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Customer Name";
            return false;
        }
        if (txtContactNo.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Customer Cell Number ";
            return false;
        }

        #endregion

        #region Detail
        if (ViewState["RetailInvoiceTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["RetailInvoiceTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ProductID"].ToString() == "")
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please Input Valid Product";
                        return false;
                    }
                    if (dt.Rows[i]["Qty"].ToString() == "")
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please Input Valid Product Quantity";
                        return false;
                    }
                    if (dt.Rows[i]["TotalPrice"].ToString() == "")
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "TotalPrice must greater than 0";
                        return false;
                    }
                    if (dt.Rows[i]["UnitPrice"].ToString() == "")
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "UnitPrice must greater than 0";
                        return false;
                    }
                    if (Convert.ToInt32(dt.Rows[i]["CurrentStock"]) < Convert.ToInt32(dt.Rows[i]["Qty"]))
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Invoice Quantity must less or equal current stock";
                        return false;
                    }
                    if (dt.Rows[i]["Qty"].ToString() != dt.Rows[i]["Barcode"].ToString())
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Barcode Serial Quantity must be equal invoice Quantity";
                        return false;
                    }

                }
            }
            else return false;
        }
        else return false;
        #endregion
        return true;
    }
    public SalesInvoice GetDataForSalesInvoice(SalesInvoice _oSalesInvoice)
    {

        double Charge = 0;

        _oSalesInvoice.InvoiceDate = DateTime.Now;

        _oSalesInvoice.CustomerID = (int)Session["Customer"];
        _oSalesInvoice.DeliveryAddress = txtCustomerAddress.Text;
        _oSalesInvoice.DeliveryDate = DateTime.Now;

        _oSalesInvoice.WarehouseID = (int)Session["Warehouse"];
        try
        {
            _oSalesInvoice.Discount = Convert.ToDouble(txtDiscount.Text);
        }
        catch
        {
            _oSalesInvoice.Discount = 0;
        }
        _oSalesInvoice.Remarks = txtRemarks.Text;

        _oSalesInvoice.InvoiceTypeID = (short)Dictionary.InvoiceType.CASH;

        _oSalesInvoice.UserID = Utility.UserId;
        try
        {
            _oSalesInvoice.InvoiceAmount = Convert.ToDouble(txtAmounttoPay.Text);
        }
        catch
        {
            _oSalesInvoice.InvoiceAmount = 0;
        }
        _oSalesInvoice.DueAmount = 0;
        _oSalesInvoice.PriceOptionID = (int)Dictionary.PriceOption.MRP;

        _oSalesInvoice.OtherCharge = 0;

        if (ViewState["RetailInvoiceTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["RetailInvoiceTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                    _oSalesInvoiceItem.ProductID = int.Parse(dt.Rows[i]["ProductID"].ToString());
                    _oSalesInvoiceItem.UnitPrice = Convert.ToDouble(dt.Rows[i]["UnitPrice"].ToString());
                    _oSalesInvoiceItem.Quantity = int.Parse(dt.Rows[i]["Qty"].ToString());
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = _oSalesInvoiceItem.ProductID;
                    _oProductDetail.Refresh();
                    _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                    _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                    _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                    _oSalesInvoiceItem.AdjustedDPAmount = 0;
                    _oSalesInvoiceItem.AdjustedPWAmount = 0;
                    _oSalesInvoiceItem.AdjustedTPAmount = 0;

                    _oSalesInvoiceItem.PromotionalDiscount = Convert.ToDouble(dt.Rows[i]["DisAmt"].ToString());
                    _oSalesInvoiceItem.IsFreeProduct = 0;
                    _oSalesInvoiceItem.FreeQty = 0;

                    _oSalesInvoice.Add(_oSalesInvoiceItem);
                }
            }
        }

        return _oSalesInvoice;
    }
    public ProductStock GetDataForProductStock(ProductStock _oProductStock)
    {

        _oProductStocks = new ProductStocks();
        int nWarehouseID = (int)Session["Warehouse"];

        if (ViewState["RetailInvoiceTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["RetailInvoiceTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    _oProductStock = new ProductStock();

                    _oProductStock.ProductID = int.Parse(dt.Rows[i]["ProductID"].ToString());
                    _oProductStock.CurrentStockValue = Convert.ToDouble(dt.Rows[i]["UnitPrice"].ToString());
                    _oProductStock.Quantity = int.Parse(dt.Rows[i]["Qty"].ToString());
                    _oProductStock.WarehouseID = nWarehouseID;

                    _oProductStocks.Add(_oProductStock);
                }
            }
        }

        return _oProductStock;
    }
    public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction)
    {
        _oCustomerTransaction.CustomerID = _oSalesInvoice.CustomerID;
        _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
        _oCustomerTransaction.TranDate = DateTime.Now;
        _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
        _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
        _oCustomerTransaction.Terminal = 1;
        _oCustomerTransaction.Remarks = txtRemarks.Text;
        _oCustomerTransaction.UserID = Utility.UserId;
        _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE;
        _oCustomerTransaction.InstrumentType = (int)Dictionary.InstrumentType.CASH;

        return _oCustomerTransaction;
    }
    public SundryCustomer GetDataForSundryCustomerInfo(SundryCustomer _oSundryCustomer)
    {
        _oSundryCustomer.SundryCustomerName = txtCustomerName.Text;
        _oSundryCustomer.CellNo = txtContactNo.Text;
        _oSundryCustomer.PhoneNo = "";
        _oSundryCustomer.Email = txtEmail.Text;
        _oSundryCustomer.Address = txtCustomerAddress.Text;
        _oSundryCustomer.SundryCustomerType = (int)Dictionary.SundryCustomerType.RetailCustomer;
        _oSundryCustomer.CustomerID = (int)Session["Customer"];

        return _oSundryCustomer;
    }

    protected void txtDiscount_TextChanged(object sender, System.EventArgs e)
    {
        double nAmountTOPay;
        try
        {
            nAmountTOPay = Math.Round(Convert.ToDouble(txtTotal.Text) - Convert.ToDouble(txtDiscount.Text));
            txtAmounttoPay.Text = nAmountTOPay.ToString("0.00");
            oLib = new TELLib();
            lvInword.Text = oLib.TakaWords(Convert.ToDouble(txtAmounttoPay.Text));
        }
        catch
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Valid Discount";
        }
    }
    protected void btAddNewRow_Click(object sender, System.EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        AddToGrid(true);
        DBController.Instance.CloseConnection();
    }

    protected void dvwSalesInvoice_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ViewState["RetailInvoiceTable"] != null)
        {

            DataTable dt = (DataTable)ViewState["RetailInvoiceTable"];

            if (dt.Rows.Count > 1)
            {
                DataRow theRowToDelete = dt.Rows[e.RowIndex];
                dt.Rows.Remove(theRowToDelete);
                ViewState["RetailInvoiceTable"] = dt;
                dvwRetailInvoice.DataSource = dt;
                dvwRetailInvoice.DataBind();
                SetPreviousData();
            }
        }
    }

    public void PrintInvoice()
    {
        oLib = new TELLib();
        _orptSalesInvoice = new rptSalesInvoice();
        _orptSalesInvoice.InvoiceID = _oSalesInvoice.InvoiceID;
        _orptSalesInvoice.RefreshForEcommerce();

        CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesInvoiceAutoPrintSTBL));
        doc.SetDataSource(_orptSalesInvoice);

        doc.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);
        doc.SetParameterValue("AmountInWord", oLib.TakaWords(_orptSalesInvoice.InvoiceAmount));
        doc.SetParameterValue("WorkStationName", Utility.GetWorkStationDetails());
        doc.SetParameterValue("InvoiceNo", _orptSalesInvoice.InvoiceNo.ToString());
        doc.SetParameterValue("InvoiceDate", _orptSalesInvoice.InvoiceDate.ToString("dd-MMM-yyyy"));
        doc.SetParameterValue("CustomerName", _orptSalesInvoice.SundryCustomerName.ToString());
        doc.SetParameterValue("Email", _orptSalesInvoice.SCEmail.ToString());
        doc.SetParameterValue("CustomerAddress", _orptSalesInvoice.SCAddress.ToString());
        doc.SetParameterValue("CustomerPhoneNo", _orptSalesInvoice.SCCellNo.ToString());
        //doc.SetParameterValue("CategoryName", _orptSalesInvoice.CustTypeName.ToString());
        //doc.SetParameterValue("Area", _orptSalesInvoice.AreaName.ToString());
        //doc.SetParameterValue("Territory", _orptSalesInvoice.TerritoryName.ToString());
        //doc.SetParameterValue("Thana", _orptSalesInvoice.ChannelName.ToString());
        //doc.SetParameterValue("District", _orptSalesInvoice.DistrictName.ToString());
        doc.SetParameterValue("Discount", oLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.Discount)));
        doc.SetParameterValue("InvoiceAmount", oLib.TakaFormat(Convert.ToDouble(_orptSalesInvoice.InvoiceAmount)));
        doc.SetParameterValue("Remarks", _orptSalesInvoice.Remarks.ToString());
       
        doc.SetParameterValue("WarehouseCode", _orptSalesInvoice.WarehouseName.ToString() + "[ " + _orptSalesInvoice.WarehouseCode.ToString() + " ]");

        doc.SetParameterValue("IsSL", IsSL);
        doc.SetParameterValue("SL", SL);
        doc.SetParameterValue("CompanyInfo", "STBL");
        doc.SetParameterValue("InvoiceHeader", "Customer Copy");
        doc.SetParameterValue("InvoiceTypeName", "Cash Invoice");
       

        Session.Remove("Doc");
        Session.Add("Doc", doc);
        Session["ReportName"] = "Retail Invoice";
        Response.Redirect("~/Report/frmReportViewer.aspx");

    }
}




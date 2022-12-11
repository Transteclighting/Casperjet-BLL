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

public partial class frmSaleOrder : System.Web.UI.Page
{
    SalesOrder _oSalesOrder;
    Customer _oCustomer;
    CustomerDetail _oCustomerDetail;
    Employees _oEmployees;
    Warehouses _oWarehouses=new Warehouses();
    SalesPromotions _oSalesPromotions;
    ProvisionParam oProvisionParam;
    ProductDetail _oProductDetail;
    Users oUsers;
    WUIUtility _oWUIUtility;
    TELLib oLib;
   

    DateTime _dOrderDate;
    DateTime _dDDate;     
    int _nRowIndex = 0;
    double _nPriceOption;
    bool IsUpdate = false;
    bool bFlag = true;
    bool IsAlterMOQ = false;
    string _sFeildName;


    protected void Page_Load(object sender, EventArgs e)
    {
        
        txtDDAmount.Style["text-align"] = "right";
        txtTotal.Style["text-align"] = "right";
        txtDiscount.Style["text-align"] = "right";
        txtAmounttoPay.Style["text-align"] = "right";

        cbOday.Text = DateTime.Today.Day.ToString();
        cbOmonth.Text = DateTime.Today.Month.ToString();
        cbOyear.Text = DateTime.Today.Year.ToString();
      
        if (!IsPostBack)
        {
            Session.Remove("Warehouses");
            Session.Remove("SalesPromotions");
            _oEmployees = new Employees();
            DBController.Instance.OpenNewConnection();
            _oEmployees.GetSalesPerson();
            DBController.Instance.CloseConnection();

            cbSalesPerson.DataSource = _oEmployees;
            cbSalesPerson.DataTextField = "EmployeeName";
            cbSalesPerson.DataBind();
            cbSalesPerson.SelectedIndex = 0;
            Session.Add("Employees", _oEmployees);
            SetInitialRow();

            _oSalesOrder = (SalesOrder)Session["SalesOrder"];
            if (_oSalesOrder != null)
            {              
               ShowUI();
              
            }
           
            oUsers = (Users)Session["Users"];
            foreach (User oUser in oUsers)
            {
                if (oUser.Permission == "M5.12")
                {
                    IsAlterMOQ = true;
                    break;
                }
                else
                {
                    IsAlterMOQ = false;
                }

            }
            Session.Add("AlterMOQ", IsAlterMOQ);

        }     
    }    
   
    public void SetUI(CustomerDetail _oCustomerDetail)
    {
        txtCustomerName.Text = _oCustomerDetail.CustomerName;
        txtCustomerAddress.Text = _oCustomerDetail.CustomerAddress;
        int nUserID = int.Parse(Session["UserID"].ToString());

        if (_oCustomerDetail.ChannelDescription != null)
            lbChannelDescription.Text = _oCustomerDetail.ChannelDescription;
        else lbChannelDescription.Text = "NA";

        if (_oCustomerDetail.CustomerTypeName != null)
            lbCustomerTypeDescription.Text = _oCustomerDetail.CustomerTypeName;
        else lbCustomerTypeDescription.Text = "NA";

        if (_oCustomerDetail.AreaName != null)
            lbAreaDescription.Text = _oCustomerDetail.AreaName;
        else lbAreaDescription.Text = "NA";

        if (_oCustomerDetail.TerritoryName != null)
            lbTerritoryDescription.Text = _oCustomerDetail.TerritoryName;
        else lbTerritoryDescription.Text = "NA";

        if (_oCustomerDetail.ParentCustomerName != null)
            lbBranch.Text = _oCustomerDetail.ParentCustomerName;
        else lbBranch.Text = "NA";

        if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.NSP)
        {
            lbPriceOption.Text = "NSP";
            _sFeildName = "NSP";
            lbPriceOption.Visible = true;
            _nPriceOption = (long)Dictionary.PriceOption.NSP;
        }
        else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.RSP)
        {
            lbPriceOption.Text = "RSP";
            _sFeildName = "RSP";
            lbPriceOption.Visible = true;
            _nPriceOption = (long)Dictionary.PriceOption.RSP;
        }
        else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Special_Price)
        {
            lbPriceOption.Text = "Special Price";
            _sFeildName = "Special Price";
            lbPriceOption.Visible = true;
            _nPriceOption = (long)Dictionary.PriceOption.Special_Price;
        }
        else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Cost_Price)
        {
            lbPriceOption.Text = "Cost Price";
            _sFeildName = "Cost Price";
            lbPriceOption.Visible = true;
            _nPriceOption = (long)Dictionary.PriceOption.Cost_Price;
        }
        else if (_oCustomerDetail.PriceOptionID == (short)Dictionary.PriceOption.Trade_Price)
        {
            lbPriceOption.Text = "Trade Price";
            _sFeildName = "Trade Price";
            lbPriceOption.Visible = true;
            _nPriceOption = (long)Dictionary.PriceOption.Trade_Price;
        }

        if (_oCustomerDetail.DiscountPercent != 0)
        {
            lbDiscount.Text = _oCustomerDetail.DiscountPercent.ToString();
            lbDiscount.Visible = true;
        }
        else
        {
            lbDiscount.Text = "0";
            lbDiscount.Visible = true;
        }
        if (_oCustomerDetail.HaveAmountDisCount == (short)Dictionary.ActiveOrInActiveStatus.ACTIVE)
        {
            lbOtherDiscount.Text = "Other Discount Applicable";
            lbOtherDiscount.Visible = true;
        }
        else
        {
            lbOtherDiscount.Text = "Other Discount Not Applicable";
            lbOtherDiscount.Visible = true;
        }
        if (_oCustomerDetail.CurrentBalance != 0)
        {

            lbCustomerBalance.Visible = true;
            lbCustomerBalance.Text = _oCustomerDetail.CurrentBalance.ToString();
        }
        else
        {
            lbCustomerBalance.Visible = true;
            lbCustomerBalance.Text = "0.00";
        }
        if (_oCustomer.MinCreditLimit != 0)
        {

            lbCreditLimit.Text = _oCustomer.MinCreditLimit.ToString();
        }
        else
        {
            lbCreditLimit.Text = "0.00";
        }
        string sWarehouse = string.Empty;
        try
        {
            sWarehouse = Utility.POSWarehouse;
        }
        catch (Exception ex)
        {
           
        }
            _oWarehouses = new Warehouses();
            _oWarehouses.GetWarehouseName(_oCustomerDetail.ChannelID, sWarehouse, nUserID);

            if (_oWarehouses.Count > 0)
            {
                cbWarehouseName.DataSource = _oWarehouses;
                cbWarehouseName.DataTextField = "WarehouseName";
                cbWarehouseName.DataBind();
              
            }
            else _oWarehouses = null;

            Session.Add("Warehouses", _oWarehouses);
  
            _oSalesPromotions = new SalesPromotions();
            _oSalesPromotions.RefreshForSalesOrder(_oCustomerDetail.CustomerID);

            if (_oSalesPromotions.Count > 0)
            {
                cbSalesPromotion.DataSource = _oSalesPromotions;
                cbSalesPromotion.DataTextField = "SalesPromotionName";
                cbSalesPromotion.DataBind();
            }
            else _oSalesPromotions = null;

            Session.Add("SalesPromotions", _oSalesPromotions);    
           

    }
    protected void txtCustomerCode_TextChanged(object sender, EventArgs e)
    {
        btGo_Click(null,null);
    }
    protected void btGo_Click(object sender, EventArgs e)
    {
        if (txtCustomerCode.Text != "")
        {
            lbMsg.Visible = false;
            DBController.Instance.OpenNewConnection();
            _oCustomer = new Customer();
            _oCustomer.CustomerCode = txtCustomerCode.Text;
            _oCustomer.GetCustomerID();
            if (_oCustomer.Flag == false)
            {
                lbMsg.Visible = true;
                lbMsg.Text = "Please Input Valid Customer Code";
                return;
            }
            int nUserID = Convert.ToInt32(Session["UserID"].ToString());
            if (_oCustomer.CheckCustPermission(nUserID) == false)
            {
                lbMsg.Visible = true;
                lbMsg.Text = "You have no permission for this Customer";
                return;
            }
            _oCustomer.GetCustomerCreditLimit();

            _oCustomerDetail = new CustomerDetail();
            _oCustomerDetail.CustomerID = _oCustomer.CustomerID;
            _oCustomerDetail.refresh();

            SetUI(_oCustomerDetail);
            Session.Add("FeildName", _sFeildName);
            Session.Add("CustomerDetail", _oCustomerDetail);
            DBController.Instance.CloseConnection();
        }
        else
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please Input or select Valid Customer Code";
            AppLogger.LogWarning("Web: Can not find Customer  =" + lbMsg.Text);
            return;
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
        dt.Columns.Add(new DataColumn("SC", typeof(string)));
        dt.Columns.Add(new DataColumn("PW", typeof(string)));
        dt.Columns.Add(new DataColumn("TP", typeof(string)));
        dt.Columns.Add(new DataColumn("TotalPrice", typeof(string)));
        dt.Columns.Add(new DataColumn("PackingQty", typeof(string)));
        dt.Columns.Add(new DataColumn("CurrentStock", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductID", typeof(string)));

        dr = dt.NewRow();
       
        dr["ProductCode"] = string.Empty;
        dr["ProductName"] = string.Empty;
        dr["UnitPrice"] = string.Empty;
        dr["Qty"] = string.Empty;
        dr["GTotal"] = string.Empty;
        dr["SC"] = string.Empty;
        dr["PW"] = string.Empty;
        dr["TP"] = string.Empty;
        dr["TotalPrice"] = string.Empty;
        dr["PackingQty"] = string.Empty;
        dr["CurrentStock"] = string.Empty;
        dr["ProductID"] = string.Empty;

        dt.Rows.Add(dr);

        //dr = dt.NewRow();
        //Store the DataTable in ViewState

        ViewState["SalesOrderTable"] = dt;
        dvwSalesOrder.DataSource = dt;
        dvwSalesOrder.DataBind();

    }
    private void AddToGrid(bool Istrue)
    {
        _nRowIndex = 0;
        lblMessage.Visible = false;
        if (ViewState["SalesOrderTable"] != null)
        {
            int i;
            DataTable dtSalesOrderTable = (DataTable)ViewState["SalesOrderTable"];
            DataRow drSalesOrderRow = null;

            if (dtSalesOrderTable.Rows.Count > 0)
            {
                try
                {
                    for (i = 1; i <= dtSalesOrderTable.Rows.Count; i++)
                    {
                        //extract the TextBox values

                        TextBox box1 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[0].FindControl("txtProductCode");
                        TextBox box2 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[1].FindControl("txtProductName");
                        TextBox box3 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[2].FindControl("txtUnitPrice");
                        TextBox box4 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[3].FindControl("txtQty");
                        TextBox box5 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[4].FindControl("txtGTotal");
                        TextBox box6 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[5].FindControl("txtSC");
                        TextBox box7 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[6].FindControl("txtPW");
                        TextBox box8 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[7].FindControl("txtTP");
                        TextBox box9 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[8].FindControl("txtTotalPrice");
                        TextBox box10 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[9].FindControl("txtPackingQty");
                        TextBox box11 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[10].FindControl("txtCurrentStock");
                        TextBox box12 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[11].FindControl("txtProductID");

                        _oWUIUtility = new WUIUtility();
                        _oWarehouses = (Warehouses)Session["Warehouses"];
                        _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];

                        if (_oWarehouses == null)
                        {
                            bFlag = false;
                            lblMessage.Visible = true;
                            lblMessage.Text = "Please Select a Customer or Valid Warehouse name";
                            AppLogger.LogWarning("Web: Invalid Warehouse   =" + lblMessage.Text);
                            return;
                        }

                        _oProductDetail = new ProductDetail();
                        _oProductDetail.ProductCode = box1.Text;
                        string sUnitPriceType = (string)Session["FeildName"];
                        _oProductDetail.RefreshForSalesOrderByCode(sUnitPriceType);

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

                        if (sUnitPriceType == "NSP")
                        {
                            dtSalesOrderTable.Rows[i - 1]["UnitPrice"] = _oProductDetail.NSP;
                            box3.Text = _oProductDetail.NSP.ToString();
                        }
                        else if (sUnitPriceType == "Special Price")
                        {
                            dtSalesOrderTable.Rows[i - 1]["UnitPrice"] = _oProductDetail.SpecialPrice;
                            box3.Text = _oProductDetail.SpecialPrice.ToString();
                        }
                        else
                        {
                            dtSalesOrderTable.Rows[i - 1]["UnitPrice"] = _oProductDetail.RSP;
                            box3.Text = _oProductDetail.RSP.ToString();
                        }
                        dtSalesOrderTable.Rows[i - 1]["ProductID"] = _oProductDetail.ProductID;


                        _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cbWarehouseName.SelectedIndex].WarehouseID, _oProductDetail.ProductID);
                        Session.Add("WUIUtility", _oWUIUtility);

                        dtSalesOrderTable.Rows[i - 1]["CurrentStock"] = _oWUIUtility.CurrentStock.ToString();
                        dtSalesOrderTable.Rows[i - 1]["Qty"] = box4.Text;

                        if (box3.Text != "" && box4.Text != "")
                        {
                            try
                            {
                                ///Update Grid view 
                                ///Add display SC,PW,TP
                                ///Date: 17.09.2011
                                oProvisionParam = new ProvisionParam();
                                oProvisionParam.GetProvisionParam(_oProductDetail.ProductID, _oCustomerDetail.CustomerTypeID);
                                dtSalesOrderTable.Rows[i - 1]["SC"] = Convert.ToDouble(box3.Text) * oProvisionParam.SC * Convert.ToDouble(box4.Text);
                                dtSalesOrderTable.Rows[i - 1]["PW"] = Convert.ToDouble(box3.Text) * oProvisionParam.PW * Convert.ToDouble(box4.Text);
                                dtSalesOrderTable.Rows[i - 1]["TP"] = Convert.ToDouble(box3.Text) * oProvisionParam.TP * Convert.ToDouble(box4.Text);

                                double TotalProvision = (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["SC"].ToString())) + (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["PW"].ToString())) + (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["TP"].ToString()));
                                dtSalesOrderTable.Rows[i - 1]["GTotal"] = (Convert.ToDouble(box3.Text) * Convert.ToDouble(box4.Text));
                                dtSalesOrderTable.Rows[i - 1]["TotalPrice"] = (Convert.ToDouble(box3.Text) * Convert.ToDouble(box4.Text)) - TotalProvision;
                            }
                            catch
                            {

                                lblMessage.Visible = true;
                                lblMessage.Text = "Please Input Valid Product Quantity or Unit Price Should be Greater than Zero";
                                return;
                            }
                        }
                        else dtSalesOrderTable.Rows[i - 1]["TotalPrice"] = "";
                        long nRem = 0;
                        long nQuotient = 0;

                        if (box4.Text != "" && _oWUIUtility.UOMConversionFactor != 0)
                        {

                            IsAlterMOQ = (bool)Session["AlterMOQ"];

                            nQuotient = Math.DivRem(Convert.ToInt32(box4.Text), _oWUIUtility.UOMConversionFactor, out nRem);
                            if (IsAlterMOQ == false)
                            {
                                if (nRem > 0)
                                {
                                    dtSalesOrderTable.Rows[i - 1]["PackingQty"] = "";
                                    lbMsg.Visible = true;
                                    lbMsg.Text = "Breaking MOQ. Please Enter Full MOQ.MOQ for the " + dtSalesOrderTable.Rows[i - 1]["ProductName"].ToString() + "  is, " + _oWUIUtility.UOMConversionFactor.ToString();
                                    return;

                                }
                                else
                                {

                                    lbMsg.Visible = false;
                                    dtSalesOrderTable.Rows[i - 1]["PackingQty"] = nQuotient.ToString();
                                }
                            }
                            else
                            {
                                dtSalesOrderTable.Rows[i - 1]["PackingQty"] = nQuotient.ToString();
                            }



                        }
                        _nRowIndex++;

                    }
                    if (Istrue == true)
                        dtSalesOrderTable.Rows.Add(drSalesOrderRow);

                    ViewState["SalesOrderTable"] = dtSalesOrderTable;
                    dvwSalesOrder.DataSource = dtSalesOrderTable;
                    dvwSalesOrder.DataBind();

                    if (Istrue == true)
                        dvwSalesOrder.Rows[_nRowIndex].Cells[1].Focus();
                }
                catch(Exception ex)
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
            //Set Previous Data on Postbacks
            SetPreviousData();
    
    }
    private void SetPreviousData()
    {
        _nRowIndex = 0;
 
        if (ViewState["SalesOrderTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["SalesOrderTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[0].FindControl("txtProductCode");
                    TextBox box2 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[1].FindControl("txtProductName");
                    TextBox box3 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[2].FindControl("txtUnitPrice");
                    TextBox box4 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[3].FindControl("txtQty");
                    TextBox box5 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[4].FindControl("txtGTotal");
                    TextBox box6 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[5].FindControl("txtSC");
                    TextBox box7 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[6].FindControl("txtPW");
                    TextBox box8 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[7].FindControl("txtTP");
                    TextBox box9 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[8].FindControl("txtTotalPrice");
                    TextBox box10 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[9].FindControl("txtPackingQty");
                    TextBox box11 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[10].FindControl("txtCurrentStock");
                    TextBox box12 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[11].FindControl("txtProductID");



                    box1.Text = dt.Rows[i]["ProductCode"].ToString();
                    box2.Text = dt.Rows[i]["ProductName"].ToString();
                    box3.Text = dt.Rows[i]["UnitPrice"].ToString();
                    box4.Text = dt.Rows[i]["Qty"].ToString();
                    box5.Text = dt.Rows[i]["GTotal"].ToString();
                    box6.Text = dt.Rows[i]["SC"].ToString();
                    box7.Text = dt.Rows[i]["PW"].ToString();
                    box8.Text = dt.Rows[i]["TP"].ToString();
                    box9.Text = dt.Rows[i]["TotalPrice"].ToString();
                    box10.Text = dt.Rows[i]["PackingQty"].ToString();
                    box11.Text = dt.Rows[i]["CurrentStock"].ToString();
                    box12.Text = dt.Rows[i]["ProductID"].ToString();

                    _nRowIndex++;

                }
            }
        }
        GetTotalAmount();
    }

    protected void txtProductCode_TextChanged(object sender, System.EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
       
        AddToGrid(false);
        if (bFlag == true)
        {
            checkDuplicateLineItem();
            dvwSalesOrder.Rows[_nRowIndex - 1].Cells[4].Focus();
        }
        else
        {
            bFlag = true;
        }
        DBController.Instance.CloseConnection();        

    }   
    protected void txtQty_TextChanged(object sender, System.EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        AddToGrid(true);        
        DBController.Instance.CloseConnection();
    }
    public void checkDuplicateLineItem()
    {
        int _nCount = 0;      
        if (ViewState["SalesOrderTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["SalesOrderTable"];

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
                lblMessage.Visible=true;
                lblMessage.Text = "Duplicate Item.Please input valid Product Code";
            }

            //Datatable which contains unique records will be return as output.
            ViewState["SalesOrderTable"] = dt;
            dvwSalesOrder.DataSource = dt;
            dvwSalesOrder.DataBind();
            SetPreviousData();
        }       
    }   
    public void GetTotalAmount()
    {
        txtTotal.Text = "0.00";
        txtAmounttoPay.Text = "0.00";
        double _Total = 0;
        oLib = new TELLib();

        if (ViewState["SalesOrderTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["SalesOrderTable"];

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
                Session.Add("Total",_Total);

                ckbDiscount_CheckedChanged(null, null);
            }
        }      
      
    }
    protected void btAddNewRow_Click(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        AddToGrid(true);
        DBController.Instance.CloseConnection();
    }
    protected void txtOrderNo_TextChanged(object sender, EventArgs e)
    {
        lbMsg.Visible = false;
        int _nOrderNo;
        _oSalesOrder = new SalesOrder();
        try
        {
            _nOrderNo = int.Parse(txtOrderNo.Text);
        }
        catch
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please Input Valid Order Number";
            return;
        }
        DBController.Instance.OpenNewConnection();
        _oSalesOrder.CheckOrderNo(_nOrderNo);
        DBController.Instance.CloseConnection();
        if (_oSalesOrder.Flag == false)
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Duplicate Sales Order No.Please enter unique Sales Order no";
            txtOrderNo.Text = "";
        }
        else
        {
            txtOrderNo.Text = _nOrderNo.ToString();
            lbMsg.Visible = false;
        }
        Session.Add("SalesOrder", _oSalesOrder);
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
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
    protected void btSave_Click(object sender, EventArgs e)
    {
        lbMsg.Visible=false;
        IsUpdate = (bool)Session["Update"];
        User oUser=(User)Session["User"];
        if (IsUpdate == true)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSalesOrder = (SalesOrder)Session["SalesOrder"];
                    if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
                    {
                        _oSalesOrder.Clear();
                        _oSalesOrder = GetUIData(_oSalesOrder);
                        _oSalesOrder.Update();
                        DBController.Instance.CommitTran();
                        AppLogger.LogInfo("Web: Success fully Update SaleOrder  =" + oUser.Username);
                        string[] sSuccedCode =  { "" };
                        Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                        UIUtility.GetConfirmationMsg("Update", "This Transaction", sSuccedCode, null, "frmSaleOrders.aspx", 0);
                        Response.Redirect("frmMessage.aspx");
                    }
                    else
                    {
                        lbMsg.Visible = true;
                        lbMsg.Text = "Error.......only Received order can be update";
                    }

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Web: Unuccessfull Update SaleOrder  =" + ex);
                    lbMsg.Visible = true;
                    lbMsg.Text = "Error.......Please check your input and save again ";
                }
            }
            else AppLogger.LogWarning("Web: Invalid Input  =" + lbMsg.Text);

        }
        else
        {
            _oSalesOrder = new SalesOrder();

            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSalesOrder = new SalesOrder();
                    _oSalesOrder = GetUIData(_oSalesOrder);
                    _oSalesOrder.Insert(false);
                    _oSalesOrder.CheckOrderNo(_oSalesOrder.OrderNo);
                    if (_oSalesOrder.Flag != true)
                    {
                        DBController.Instance.RollbackTransaction();
                        lbMsg.Visible = true;
                        lbMsg.Text = "Order No Error....Please contact your System Administrator for help.";
                    }
                    else
                    {
                        DBController.Instance.CommitTran();
                        AppLogger.LogInfo("Web: Success fully Add SaleOrder  =" + oUser.Username);
                        string[] sSuccedCode =  { "" };
                        Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                        UIUtility.GetConfirmationMsg("Save", "This Transaction", sSuccedCode, null, "frmSaleOrders.aspx", 0);
                        Response.Redirect("frmMessage.aspx");
                    }

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    AppLogger.LogError("Web: Unuccessfull Add SaleOrder  =" + ex);
                    lbMsg.Visible = true;
                    lbMsg.Text = "Error.......Please check your input and save again ";
                }
            }
        }
    }
    private bool validateUIInput()
    {
        #region Order Master Information Validation
        _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];
        
        if (cbWarehouseName.Text == "")
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please Input Valid Warehouse Name";      
            return false;
        }
        if (txtCustomerAddress.Text == "")
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please Input Delivery Address";     
            return false;
        }        
        if (_oCustomerDetail == null)
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please Select Valid Customer";  
            return false;
        }
         try
        {
            _dOrderDate = new DateTime(Convert.ToInt32(cbOyear.SelectedValue),Convert.ToInt32(cbOmonth.SelectedValue), Convert.ToInt32(cbOday.SelectedValue));
        }
        catch
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please Input Valid Order Date";    
            return false;
        }
        
        #endregion

        if (ViewState["SalesOrderTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["SalesOrderTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ProductID"].ToString() == "")
                    {
                        lbMsg.Visible = true;
                        lbMsg.Text = "Please Input Valid Product";    
                        return false;
                    }
                    if (dt.Rows[i]["Qty"].ToString() == "")
                    {
                        lbMsg.Visible = true;
                        lbMsg.Text = "Please Input Valid Product Quantity";
                        return false;
                    }
                    if (dt.Rows[i]["TotalPrice"].ToString() == "")
                    {
                        lbMsg.Visible = true;
                        lbMsg.Text = "TotalPrice must greater than 0";
                        return false;
                    }
                    if (dt.Rows[i]["UnitPrice"].ToString() == "")
                    {
                        lbMsg.Visible = true;
                        lbMsg.Text = "UnitPrice must greater than 0";
                        return false;
                    }
                    IsAlterMOQ = (bool)Session["AlterMOQ"];
                    if (IsAlterMOQ == false)
                    {
                        if (dt.Rows[i]["PackingQty"].ToString() == "" || int.Parse(dt.Rows[i]["PackingQty"].ToString()) < 1)
                        {
                            _oWarehouses = (Warehouses)Session["Warehouses"];
                            _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];
                            _oWUIUtility = new WUIUtility();
                            _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cbWarehouseName.SelectedIndex].WarehouseID, int.Parse(dt.Rows[i]["ProductID"].ToString()));

                            lbMsg.Visible = true;
                            lbMsg.Text = "Breaking MOQ. Please Enter Full MOQ.MOQ for the " + dt.Rows[i]["ProductName"].ToString() + "  is , " + _oWUIUtility.UOMConversionFactor.ToString();
                            return false;
                        }
                    }

                }
            }
            else return false;
        }
        else return false;

        return true;
    }
    public SalesOrder GetUIData(SalesOrder _oSalesOrder)
    {
        int nUserID = int.Parse(Session["UserID"].ToString());
        _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];
        _oWarehouses = (Warehouses)Session["Warehouses"];
        _oEmployees = (Employees)Session["Employees"];
        _oSalesPromotions = (SalesPromotions)Session["SalesPromotions"];     

      
        _oSalesOrder.OrderDate=_dOrderDate.Date;
        if (rdoCash.Checked == true)
        {
            _oSalesOrder.OrderTypeID = (short)Dictionary.OrderType.CASH;
        }
        else
        {
            _oSalesOrder.OrderTypeID = (short)Dictionary.OrderType.CREDIT;
        }

        _oSalesOrder.CustomerID=_oCustomerDetail.CustomerID;
        _oSalesOrder.DeliveryAddress=txtCustomerAddress.Text;
        _oSalesOrder.SalesPersonID=_oEmployees[cbSalesPerson.SelectedIndex].EmployeeID;
        _oSalesOrder.WarehouseID = _oWarehouses[cbWarehouseName.SelectedIndex].WarehouseID;
        if (cbSalesPromotion.Text != "" && _oSalesPromotions!=null)
            _oSalesOrder.SalesPromotionID = _oSalesPromotions[cbSalesPromotion.SelectedIndex].SalesPromotionID;
        else _oSalesOrder.SalesPromotionID = -1;

        try
        {
            _oSalesOrder.DDDate = new DateTime(Convert.ToInt32(cbDyear.SelectedValue), Convert.ToInt32(cbDmonth.SelectedValue), Convert.ToInt32(cbDday.SelectedValue));
        }
        catch
        {
            _oSalesOrder.DDDate = null;
        }
        _oSalesOrder.DDDetails = txtDDDetail.Text;     
        _oSalesOrder.DDAmount = Convert.ToDouble(txtDDAmount.Text);
        _oSalesOrder.Remarks = txtRemarks.Text;

        try
        {
            _oSalesOrder.Discount = Convert.ToDouble(txtDiscount.Text);
          
        }
        catch
        {
            _oSalesOrder.Discount=0;
        }
        _oSalesOrder.CreateUserID = nUserID;

        if (rdoHO.Checked == true)
        {
            _oSalesOrder.IsHODelivery = (int)Dictionary.DealerOrderDeliveryPoint.HO_Branch;
        }
        else _oSalesOrder.IsHODelivery = (int)Dictionary.DealerOrderDeliveryPoint.Outlet;

        _oSalesOrder.UpdateUserID = nUserID;
        _oSalesOrder.UpdateDate = DateTime.Today.Date;

        // Product Details

        if (ViewState["SalesOrderTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["SalesOrderTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SalesOrderItem _oSalesOrderItem = new SalesOrderItem();

                    ProvisionParam _oProvisionParam = new ProvisionParam();                    

                    _oSalesOrderItem.ProductID = int.Parse(dt.Rows[i]["ProductID"].ToString());
                    _oSalesOrderItem.UnitPrice = Convert.ToDouble(dt.Rows[i]["UnitPrice"].ToString());
                    _oSalesOrderItem.Quantity = int.Parse(dt.Rows[i]["Qty"].ToString());

                    _oProvisionParam.GetProvisionParam(_oSalesOrderItem.ProductID, _oCustomerDetail.CustomerTypeID);

                    _oSalesOrderItem.ConfirmQuantity = 0;
                    _oSalesOrderItem.AdjustedDPAmount = _oSalesOrderItem.UnitPrice * _oProvisionParam.SC;
                    _oSalesOrderItem.AdjustedPWAmount = _oSalesOrderItem.UnitPrice * _oProvisionParam.PW;
                    _oSalesOrderItem.AdjustedTPAmount = _oSalesOrderItem.UnitPrice * _oProvisionParam.TP;
                    _oSalesOrderItem.PromotionalDiscount = 0;
                    _oSalesOrderItem.IsFreeProduct = 0;
                    _oSalesOrderItem.FreeQty = 0;

                    _oSalesOrder.Add(_oSalesOrderItem);
                }
            }
        }
        if (_oSalesOrder.SalesPromotionID != -1)
        {
            foreach (SalesOrderItem oSalesOrderItem in _oSalesOrder)
            {
                ProvisionParam _oProvisionParam = new ProvisionParam();
                if (_oProvisionParam.GetFreeProduct(oSalesOrderItem.ProductID, _oSalesOrder.SalesPromotionID))
                {
                    if (IsOrderProduct(_oSalesOrder, _oProvisionParam.FreeProductID))
                    {
                        oSalesOrderItem.PromotionalDiscount = _oProvisionParam.Discount * oSalesOrderItem.Quantity;
                        oSalesOrderItem.FreeQty = (int)(oSalesOrderItem.Quantity / _oProvisionParam.SalesQty) * _oProvisionParam.FreeQty;
                    }
                    else
                    {
                        SalesOrderItem _oSalesOrderItem = new SalesOrderItem();

                        _oSalesOrderItem.ProductID = _oProvisionParam.FreeProductID;
                        _oSalesOrderItem.UnitPrice = 0;
                        _oSalesOrderItem.Quantity = 0;                    
                        _oSalesOrderItem.ConfirmQuantity = 0;
                        _oSalesOrderItem.AdjustedDPAmount = 0;
                        _oSalesOrderItem.AdjustedPWAmount = 0;
                        _oSalesOrderItem.AdjustedTPAmount = 0;
                        _oSalesOrderItem.PromotionalDiscount = _oProvisionParam.Discount * oSalesOrderItem.Quantity;
                        _oSalesOrderItem.IsFreeProduct = 1;
                        _oSalesOrderItem.FreeQty = (int)(oSalesOrderItem.Quantity / _oProvisionParam.SalesQty) * _oProvisionParam.FreeQty;

                        _oSalesOrder.Add(_oSalesOrderItem);
                    }
                }
            }
        }

        return _oSalesOrder;
    }
    public bool IsOrderProduct(SalesOrder _oSalesOrder,int nProductID)
    {
        foreach (SalesOrderItem oSalesOrderItem in _oSalesOrder)
        {
            if (oSalesOrderItem.ProductID == nProductID)
                return true;
        }
        return false;
    }
    protected void dvwSalesOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
        if (ViewState["SalesOrderTable"] != null)
        {
            
            DataTable dt = (DataTable)ViewState["SalesOrderTable"];

            if (dt.Rows.Count > 1)
            {
                DataRow theRowToDelete = dt.Rows[e.RowIndex];
                dt.Rows.Remove(theRowToDelete);
                ViewState["SalesOrderTable"] = dt;
                dvwSalesOrder.DataSource = dt;
                dvwSalesOrder.DataBind();
                SetPreviousData();
            }
        }
       
    }
    public void ShowUI()
    {
        DBController.Instance.OpenNewConnection();

        _oSalesOrder = (SalesOrder)Session["SalesOrder"];
        Session.Add("OrderID", _oSalesOrder.OrderID);
        txtOrderNo.Text = _oSalesOrder.OrderNo.ToString();

        _dOrderDate = Convert.ToDateTime(_oSalesOrder.OrderDate);
        cbOday.Text = _dOrderDate.Day.ToString();
        cbOmonth.Text = _dOrderDate.Month.ToString();
        cbOyear.Text = _dOrderDate.Year.ToString();

        if (_oSalesOrder.OrderTypeID == (short)Dictionary.OrderType.CASH)
        {
            rdoCash.Checked = true;
            rdoCredit.Checked = false;
        }
        else
        {
            rdoCash.Checked = false;
            rdoCredit.Checked = true;
        }


        _oCustomer = new Customer();
        _oCustomer.CustomerID = _oSalesOrder.CustomerID;
        _oCustomer.GetCustomerCreditLimit();

        _oCustomerDetail = new CustomerDetail();
        _oCustomerDetail.CustomerID = _oSalesOrder.CustomerID;
        _oCustomerDetail.refresh();
        txtCustomerCode.Text = _oCustomerDetail.CustomerCode;

        SetUI(_oCustomerDetail);
        Session.Add("FeildName", _sFeildName);
        Session.Add("CustomerDetail", _oCustomerDetail);

        txtCustomerAddress.Text = _oSalesOrder.DeliveryAddress;
        cbSalesPerson.SelectedIndex = _oEmployees.GetIndex(_oSalesOrder.SalesPersonID);
        cbWarehouseName.SelectedIndex = _oWarehouses.GetIndex(_oSalesOrder.WarehouseID);
        if (_oSalesOrder.SalesPromotionID != -1)
        {
            cbSalesPromotion.SelectedIndex = _oSalesPromotions.GetIndex(_oSalesOrder.SalesPromotionID);
        }
        if (_oSalesOrder.DDDate != DBNull.Value)
        {
            _dDDate = Convert.ToDateTime(_oSalesOrder.DDDate);
            cbDday.Text = _dDDate.Day.ToString();
            cbDmonth.Text = _dDDate.Month.ToString();
            cbDyear.Text = _dDDate.Year.ToString();
        }
        txtDDAmount.Text = _oSalesOrder.DDAmount.ToString();
        txtDDDetail.Text = _oSalesOrder.DDDetails;
        txtRemarks.Text = _oSalesOrder.Remarks;


        int i = 0;
        foreach (SalesOrderItem oSalesOrderItem in _oSalesOrder)
        {
            _oProductDetail = new ProductDetail();
            _oProductDetail.ProductID = oSalesOrderItem.ProductID;
            string sUnitPriceType = (string)Session["FeildName"];
            _oProductDetail.RefreshForSalesOrder(sUnitPriceType);

            TextBox box1 = (TextBox)dvwSalesOrder.Rows[i].Cells[0].FindControl("txtProductCode");
            TextBox box4 = (TextBox)dvwSalesOrder.Rows[i].Cells[3].FindControl("txtQty");
            
            box1.Text = _oProductDetail.ProductCode;
            box4.Text = oSalesOrderItem.Quantity.ToString();          
            ShowLineItem();
            i++;
        }


        if (ViewState["SalesOrderTable"] != null)
        {

            DataTable dt = (DataTable)ViewState["SalesOrderTable"];

            if (dt.Rows.Count > 1)
            {
                DataRow theRowToDelete = dt.Rows[i];
                dt.Rows.Remove(theRowToDelete);
                ViewState["SalesOrderTable"] = dt;
                dvwSalesOrder.DataSource = dt;
                dvwSalesOrder.DataBind();
                SetPrevious();
            }
        }
        if (_oSalesOrder.Discount != 0)
        {
            txtDiscount.Text = _oSalesOrder.Discount.ToString();
            txtDiscount_TextChanged(null, null);
            ckbDiscount.Checked = true;
        }
        else
        {
            txtDiscount.Text = "0.00";
            ckbDiscount.Checked = false;
        }

        DBController.Instance.CloseConnection();
       
    }
    protected void ckbDiscount_CheckedChanged(object sender, EventArgs e)
    {
        double Total = 0;
        _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];
        try
        {
            Total = (double)Session["Total"];
        }
        catch
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please input product details.";
            return ;
        }
        if (ckbDiscount.Checked == true)
        {
            try
            {
                txtDiscount.Text = Convert.ToDouble(Math.Round((Total * _oCustomerDetail.DiscountPercent) / 100)).ToString("0.00");
                txtDiscount_TextChanged(sender, e);

            }
            catch
            {
                txtDiscount.Text = "0.00";
                txtDiscount_TextChanged(sender, e);
            }
        }
        else
        {
            txtDiscount.Text = "0.00";
            txtDiscount_TextChanged(sender, e);
        }
    }
    private void ShowLineItem()
    {
        _nRowIndex = 0;
        lblMessage.Visible = false;
        if (ViewState["SalesOrderTable"] != null)
        {
            int i;
            DataTable dtSalesOrderTable = (DataTable)ViewState["SalesOrderTable"];
            DataRow drSalesOrderRow = null;

            if (dtSalesOrderTable.Rows.Count > 0)
            {

                for (i = 1; i <= dtSalesOrderTable.Rows.Count; i++)
                {
                    //extract the TextBox values
             

                    TextBox box1 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[0].FindControl("txtProductCode");
                    TextBox box2 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[1].FindControl("txtProductName");
                    TextBox box3 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[2].FindControl("txtUnitPrice");
                    TextBox box4 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[3].FindControl("txtQty");
                    TextBox box5 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[4].FindControl("txtSC");
                    TextBox box6 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[5].FindControl("txtPW");
                    TextBox box7 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[6].FindControl("txtTP");
                    TextBox box8 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[7].FindControl("txtTotalPrice");
                    TextBox box9 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[8].FindControl("txtPackingQty");
                    TextBox box10 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[9].FindControl("txtCurrentStock");
                    TextBox box11 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[10].FindControl("txtProductID");
                  

                    _oWUIUtility = new WUIUtility();
                    _oWarehouses = (Warehouses)Session["Warehouses"];
                    _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];

                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductCode = box1.Text;
                    string sUnitPriceType = (string)Session["FeildName"];
                    _oProductDetail.RefreshForSalesOrderByCode(sUnitPriceType);

                    drSalesOrderRow = dtSalesOrderTable.NewRow();
                   
                    dtSalesOrderTable.Rows[i - 1]["ProductCode"] = box1.Text;                   
                    dtSalesOrderTable.Rows[i - 1]["ProductName"] = _oProductDetail.ProductName;

                    if (sUnitPriceType == "NSP")
                    {
                        dtSalesOrderTable.Rows[i - 1]["UnitPrice"] = _oProductDetail.NSP;
                        box3.Text = _oProductDetail.NSP.ToString();
                    }
                    else if (sUnitPriceType == "Special Price")
                    {
                        dtSalesOrderTable.Rows[i - 1]["UnitPrice"] = _oProductDetail.SpecialPrice;
                        box3.Text = _oProductDetail.SpecialPrice.ToString();
                    }
                    else
                    {
                        dtSalesOrderTable.Rows[i - 1]["UnitPrice"] = _oProductDetail.RSP;
                        box3.Text = _oProductDetail.RSP.ToString();
                    }
                    dtSalesOrderTable.Rows[i - 1]["ProductID"] = _oProductDetail.ProductID;
                 

                    _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cbWarehouseName.SelectedIndex].WarehouseID, _oProductDetail.ProductID);
                    Session.Add("WUIUtility", _oWUIUtility);

                    dtSalesOrderTable.Rows[i - 1]["CurrentStock"] = _oWUIUtility.CurrentStock.ToString();
                    dtSalesOrderTable.Rows[i - 1]["Qty"] = box4.Text;

                    oProvisionParam = new ProvisionParam();
                    oProvisionParam.GetProvisionParam(_oProductDetail.ProductID, _oCustomerDetail.CustomerTypeID);
                    dtSalesOrderTable.Rows[i - 1]["SC"] = Convert.ToDouble(box3.Text) * oProvisionParam.SC * Convert.ToDouble(box4.Text);
                    dtSalesOrderTable.Rows[i - 1]["PW"] = Convert.ToDouble(box3.Text) * oProvisionParam.PW * Convert.ToDouble(box4.Text);
                    dtSalesOrderTable.Rows[i - 1]["TP"] = Convert.ToDouble(box3.Text) * oProvisionParam.TP * Convert.ToDouble(box4.Text);

                    double TotalProvision = (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["SC"].ToString())) + (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["PW"].ToString())) + (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["TP"].ToString()));
                    dtSalesOrderTable.Rows[i - 1]["GTotal"] = (Convert.ToDouble(box3.Text) * Convert.ToDouble(box4.Text));
                    dtSalesOrderTable.Rows[i - 1]["TotalPrice"] = (Convert.ToDouble(box3.Text) * Convert.ToDouble(box4.Text)) - TotalProvision;
                   
                    long nRem = 0;
                    long nQuotient = 0;
                    try
                    {
                        nQuotient = Math.DivRem(Convert.ToInt32(box4.Text), _oWUIUtility.UOMConversionFactor, out nRem);
                    }
                    catch
                    {
                        nQuotient = 0;
                    }
                    dtSalesOrderTable.Rows[i - 1]["PackingQty"] = nQuotient.ToString();
                    _nRowIndex++;

                }

                dtSalesOrderTable.Rows.Add(drSalesOrderRow);

                ViewState["SalesOrderTable"] = dtSalesOrderTable;
                dvwSalesOrder.DataSource = dtSalesOrderTable;
                dvwSalesOrder.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        //Set Previous Data on Postbacks
        SetPrevious();

    }
    private void SetPrevious()
    {
        _nRowIndex = 0;

        if (ViewState["SalesOrderTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["SalesOrderTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[0].FindControl("txtProductCode");
                    TextBox box2 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[1].FindControl("txtProductName");
                    TextBox box3 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[2].FindControl("txtUnitPrice");
                    TextBox box4 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[3].FindControl("txtQty");
                    TextBox box5 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[4].FindControl("txtGTotal");
                    TextBox box6 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[5].FindControl("txtSC");
                    TextBox box7 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[6].FindControl("txtPW");
                    TextBox box8 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[7].FindControl("txtTP");
                    TextBox box9 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[8].FindControl("txtTotalPrice");
                    TextBox box10 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[9].FindControl("txtPackingQty");
                    TextBox box11 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[10].FindControl("txtCurrentStock");
                    TextBox box12 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[11].FindControl("txtProductID");

                    box1.ReadOnly = true;
                    box2.ReadOnly = true;
                    box3.ReadOnly = true;
                    box4.ReadOnly = true;
                    box5.ReadOnly = true;
                    box6.ReadOnly = true;

                    box1.Text = dt.Rows[i]["ProductCode"].ToString();
                    box2.Text = dt.Rows[i]["ProductName"].ToString();
                    box3.Text = dt.Rows[i]["UnitPrice"].ToString();
                    box4.Text = dt.Rows[i]["Qty"].ToString();
                    box5.Text = dt.Rows[i]["GTotal"].ToString();
                    box6.Text = dt.Rows[i]["SC"].ToString();
                    box7.Text = dt.Rows[i]["PW"].ToString();
                    box8.Text = dt.Rows[i]["TP"].ToString();
                    box9.Text = dt.Rows[i]["TotalPrice"].ToString();
                    box10.Text = dt.Rows[i]["PackingQty"].ToString();
                    box11.Text = dt.Rows[i]["CurrentStock"].ToString();
                    box12.Text = dt.Rows[i]["ProductID"].ToString();                                   

                    _nRowIndex++;

                }
            }
        }
        GetTotalAmount();
    }

    protected void rdoCash_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoCash.Checked == true)
            rdoCredit.Checked = false;
    }
    protected void rdoCredit_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoCredit.Checked == true)
            rdoCash.Checked = false;
    }
    protected void rdoHO_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoHO.Checked == true)
            rdoOulet.Checked = false;
    }
    protected void rdoOulet_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoOulet.Checked == true)
            rdoHO.Checked = false;
    }
}

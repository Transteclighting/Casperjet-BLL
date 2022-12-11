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

public partial class frmOrderConfirmation : System.Web.UI.Page
{
    SalesOrder _oSalesOrder;
    Customer _oCustomer;
    CustomerDetail _oCustomerDetail;
    Employees _oEmployees;
    Warehouses _oWarehouses = new Warehouses();
    SalesPromotions _oSalesPromotions;
    ProvisionParam oProvisionParam;
    ProductDetail _oProductDetail;
    WUIUtility _oWUIUtility;
    TELLib oLib;
    SalesInvoice _oSalesInvoice;
    ProvisionParam _oProvisionParam;
    CustomerTransaction _oCustomerTransaction;
    ProductTransaction _oProductTransaction;
    Warehouse _oWarehouse;
    Users oUsers;

    DateTime _dOrderDate;
    DateTime _dDDate;
    int _nRowIndex = 0;
    double _nPriceOption;
    double _PromoDis = 0;
    bool IsUpdate = false;
    bool bFlag = true;
    bool IsAlterMOQ = false;
    string _sFeildName;
    int nSalesQty = 0;
    double _PromoDisAmt = 0;

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
                txtOrderNo.Enabled = false;
                ShowUI();

            }            

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
        btGo_Click(null, null);
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
        dt.Columns.Add(new DataColumn("ConfirmQty", typeof(string)));
        dt.Columns.Add(new DataColumn("GTotal", typeof(string)));
        dt.Columns.Add(new DataColumn("SC", typeof(string)));
        dt.Columns.Add(new DataColumn("PW", typeof(string)));
        dt.Columns.Add(new DataColumn("TP", typeof(string)));
        dt.Columns.Add(new DataColumn("TotalPrice", typeof(string)));
        dt.Columns.Add(new DataColumn("PackingQty", typeof(string)));
        dt.Columns.Add(new DataColumn("CurrentStock", typeof(string)));     
        dt.Columns.Add(new DataColumn("PromoDisc", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductID", typeof(string)));

        dr = dt.NewRow();

        dr["ProductCode"] = string.Empty;
        dr["ProductName"] = string.Empty;
        dr["UnitPrice"] = string.Empty;
        dr["Qty"] = string.Empty;
        dr["ConfirmQty"] = string.Empty;
        dr["GTotal"] = string.Empty;
        dr["SC"] = string.Empty;
        dr["PW"] = string.Empty;
        dr["TP"] = string.Empty;
        dr["TotalPrice"] = string.Empty;
        dr["PackingQty"] = string.Empty;
        dr["CurrentStock"] = string.Empty;        
        dr["PromoDisc"] = string.Empty;
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

                for (i = 1; i <= dtSalesOrderTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[0].FindControl("txtProductCode");
                    TextBox box3 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[2].FindControl("txtUnitPrice");
                    TextBox box5 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[4].FindControl("txtConfirmQty");
                    TextBox box6 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[5].FindControl("txtGTotal");
                    TextBox box7 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[6].FindControl("txtSC");
                    TextBox box8 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[7].FindControl("txtPW");
                    TextBox box9 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[8].FindControl("txtTP");
                    TextBox box10 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[9].FindControl("txtTotalPrice");
                    TextBox box11 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[10].FindControl("txtPackingQty");              
                    TextBox box14 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[12].FindControl("txtPromoDisc");
                    TextBox box15 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[13].FindControl("txtProductID");

                    _oWUIUtility = new WUIUtility();
                    _oWarehouses = (Warehouses)Session["Warehouses"];
                    _oSalesOrder = (SalesOrder)Session["SalesOrder"];
                    _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];

                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductCode = box1.Text;
                    _oProductDetail.RefreshByCode();
                    string sUnitPriceType = (string)Session["FeildName"];
                    _oProductDetail.RefreshForSalesOrder(sUnitPriceType);

                    
                    drSalesOrderRow = dtSalesOrderTable.NewRow();                    

                    if (box3.Text != "" && box5.Text != "")
                    {
                        try
                        {
                            ///Update Grid view 
                            ///Add display SC,PW,TP
                            ///Date: 17.09.2011
                            dtSalesOrderTable.Rows[i - 1]["ConfirmQty"] = box5.Text;
                            _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cbWarehouseName.SelectedIndex].WarehouseID, _oProductDetail.ProductID);
                            Session.Add("WUIUtility", _oWUIUtility);
                            oProvisionParam = new ProvisionParam();
                            oProvisionParam.GetProvisionParam(_oProductDetail.ProductID, _oCustomerDetail.CustomerTypeID);
                            dtSalesOrderTable.Rows[i - 1]["SC"] = Convert.ToDouble(box3.Text) * oProvisionParam.SC * Convert.ToDouble(box5.Text);
                            dtSalesOrderTable.Rows[i - 1]["PW"] = Convert.ToDouble(box3.Text) * oProvisionParam.PW * Convert.ToDouble(box5.Text);
                            dtSalesOrderTable.Rows[i - 1]["TP"] = Convert.ToDouble(box3.Text) * oProvisionParam.TP * Convert.ToDouble(box5.Text);

                            double TotalProvision = (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["SC"].ToString())) + (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["PW"].ToString())) + (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["TP"].ToString()));
                            dtSalesOrderTable.Rows[i - 1]["GTotal"] = (Convert.ToDouble(box3.Text) * Convert.ToDouble(box5.Text));
                          
                            if (_oSalesOrder.SalesPromotionID != -1)
                            {
                                ProvisionParam _oProvisionParam = new ProvisionParam();
                                if (_oProvisionParam.GetFreeProduct(_oProductDetail.ProductID, _oSalesOrder.SalesPromotionID))
                                {
                                    //dtSalesOrderTable.Rows[i - 1]["PromoDisc"] = Convert.ToDouble(_oProvisionParam.Discount) * Convert.ToInt32(box5.Text);
                                    dtSalesOrderTable.Rows[i - 1]["PromoDisc"] = (Math.Floor(Convert.ToInt32(box5.Text) / Convert.ToDouble(_oProvisionParam.SalesQty)))* Convert.ToDouble(_oProvisionParam.Discount);
                                }
                                dtSalesOrderTable.Rows[i - 1]["TotalPrice"] = (Convert.ToDouble(box3.Text) * Convert.ToDouble(box5.Text)) - TotalProvision - _oProvisionParam.Discount;
                            }
                            dtSalesOrderTable.Rows[i - 1]["TotalPrice"] = (Convert.ToDouble(box3.Text) * Convert.ToDouble(box5.Text)) - TotalProvision;
                        }
                        catch
                        {

                            lblMessage.Visible = true;
                            lblMessage.Text = "Please Input Valid Product Confirom Quantity Should be Greater than Zero";
                            return;
                        }
                    }
                    else dtSalesOrderTable.Rows[i - 1]["TotalPrice"] = "";
                    long nRem = 0;
                    long nQuotient = 0;

                    if (box5.Text != "" && _oWUIUtility.UOMConversionFactor != 0)
                    {
                        nQuotient = Math.DivRem(Convert.ToInt32(box5.Text), _oWUIUtility.UOMConversionFactor, out nRem);
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
                    TextBox box5 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[4].FindControl("txtConfirmQty");
                    TextBox box6 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[5].FindControl("txtGTotal");
                    TextBox box7 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[6].FindControl("txtSC");
                    TextBox box8 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[7].FindControl("txtPW");
                    TextBox box9 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[8].FindControl("txtTP");
                    TextBox box10 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[9].FindControl("txtTotalPrice");
                    TextBox box11 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[10].FindControl("txtPackingQty");
                    TextBox box12 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[11].FindControl("txtCurrentStock");
                    TextBox box14 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[12].FindControl("txtPromoDisc");
                    TextBox box15 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[13].FindControl("txtProductID");



                    box1.Text = dt.Rows[i]["ProductCode"].ToString();
                    box2.Text = dt.Rows[i]["ProductName"].ToString();
                    box3.Text = dt.Rows[i]["UnitPrice"].ToString();
                    box4.Text = dt.Rows[i]["Qty"].ToString();
                    box5.Text = dt.Rows[i]["ConfirmQty"].ToString();
                    box6.Text = dt.Rows[i]["GTotal"].ToString();
                    box7.Text = dt.Rows[i]["SC"].ToString();
                    box8.Text = dt.Rows[i]["PW"].ToString();
                    box9.Text = dt.Rows[i]["TP"].ToString();
                    box10.Text = dt.Rows[i]["TotalPrice"].ToString();
                    box11.Text = dt.Rows[i]["PackingQty"].ToString();
                    box12.Text = dt.Rows[i]["CurrentStock"].ToString();
                    box14.Text = dt.Rows[i]["PromoDisc"].ToString();
                    box15.Text = dt.Rows[i]["ProductID"].ToString();

                    _nRowIndex++;

                }
            }
        }
        GetTotalAmount();
    }
   
    protected void txtQty_TextChanged(object sender, System.EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        AddToGrid(false);
        DBController.Instance.CloseConnection();
    }
    
    public void GetTotalAmount()
    {
        txtTotal.Text = "0.00";
        txtAmounttoPay.Text = "0.00";

        double _Total = 0;
        _PromoDis = 0;
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
                            _PromoDis = _PromoDis + Convert.ToDouble(dt.Rows[i]["PromoDisc"].ToString());
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
                double DiscountAmt = Convert.ToDouble(txtDiscount.Text);
                txtAmounttoPay.Text = (_Total - _PromoDis - DiscountAmt).ToString();
                oLib = new TELLib();
                lvInword.Text = oLib.TakaWords(Convert.ToDouble(txtAmounttoPay.Text));
                Session.Add("Total", _Total);

                //ckbDiscount_CheckedChanged(null, null);
            }
        }

    }

    protected void btAddNewRow_Click(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        AddToGrid(true);
        DBController.Instance.CloseConnection();
    }  
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        double nAmountTOPay;

        if (IsPostBack)
        {

            _PromoDis = 0;

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
                                _PromoDis = _PromoDis + Convert.ToDouble(dt.Rows[i]["PromoDisc"].ToString());
                            }
                            catch
                            {
                                lblMessage.Visible = true;
                                lblMessage.Text = "Please Check your Product Details";
                                return;
                            }
                        }

                    }

                }
            }
        }


        try
        {
            nAmountTOPay = Math.Round(Convert.ToDouble(txtTotal.Text) - Convert.ToDouble(txtDiscount.Text)- _PromoDis);
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
            chkOrderType.Checked = true;
        }
        else
        {
            chkOrderType.Checked = false;
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
            TextBox box5 = (TextBox)dvwSalesOrder.Rows[i].Cells[4].FindControl("txtConfirmQty");
            TextBox box14 = (TextBox)dvwSalesOrder.Rows[i].Cells[12].FindControl("txtPromoDisc");

            box1.Text = _oProductDetail.ProductCode;
            box4.Text = oSalesOrderItem.Quantity.ToString();

            if (_oSalesOrder.SalesPromotionID != -1)
            {
                nSalesQty = 0;
                _PromoDisAmt = 0;

                ProvisionParam _oProvisionParam = new ProvisionParam();
                if (_oProvisionParam.GetFreeProduct(_oProductDetail.ProductID, _oSalesOrder.SalesPromotionID))
                {
                    nSalesQty = Convert.ToInt32(_oProvisionParam.SalesQty);
                    _PromoDisAmt = Convert.ToDouble(_oProvisionParam.Discount);
                }
                if (nSalesQty != 0)
                {
                    int nInvoiceQty = Convert.ToInt32(box4.Text);
                    double nResult = Math.Floor(Convert.ToDouble(nInvoiceQty) / Convert.ToDouble(nSalesQty));
                    box14.Text = Convert.ToString(_PromoDisAmt * nResult);
                }
                else
                {
                    box14.Text = "0";
                }
            }
            else
            {
                box14.Text = "0";
            }
      
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
        ckbDiscount.Enabled = false;
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
            return;
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
                    TextBox box5 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[4].FindControl("txtConfirmQty");
                    TextBox box6 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[5].FindControl("txtGTotal");
                    TextBox box7 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[6].FindControl("txtSC");
                    TextBox box8 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[7].FindControl("txtPW");
                    TextBox box9 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[8].FindControl("txtTP");
                    TextBox box10 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[9].FindControl("txtTotalPrice");
                    TextBox box11 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[10].FindControl("txtPackingQty");
                    TextBox box12 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[11].FindControl("txtCurrentStock");
                    TextBox box14 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[12].FindControl("txtPromoDisc");
                    TextBox box15 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[13].FindControl("txtProductID");



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
                      

                        _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cbWarehouseName.SelectedIndex].WarehouseID, _oProductDetail.ProductID);
                        Session.Add("WUIUtility", _oWUIUtility);

                        dtSalesOrderTable.Rows[i - 1]["CurrentStock"] = _oWUIUtility.CurrentStock.ToString();
                        dtSalesOrderTable.Rows[i - 1]["Qty"] = box4.Text;
                        dtSalesOrderTable.Rows[i - 1]["ConfirmQty"] = box4.Text;
                        oProvisionParam = new ProvisionParam();
                        oProvisionParam.GetProvisionParam(_oProductDetail.ProductID, _oCustomerDetail.CustomerTypeID);
                        dtSalesOrderTable.Rows[i - 1]["SC"] = Convert.ToDouble(_oProductDetail.NSP) * oProvisionParam.SC * Convert.ToDouble(box4.Text);
                        dtSalesOrderTable.Rows[i - 1]["PW"] = Convert.ToDouble(_oProductDetail.NSP) * oProvisionParam.PW * Convert.ToDouble(box4.Text);
                        dtSalesOrderTable.Rows[i - 1]["TP"] = Convert.ToDouble(_oProductDetail.NSP) * oProvisionParam.TP * Convert.ToDouble(box4.Text);

                        double TotalProvision = (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["SC"].ToString())) + (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["PW"].ToString())) + (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["TP"].ToString()));
                        dtSalesOrderTable.Rows[i - 1]["GTotal"] = (Convert.ToDouble(_oProductDetail.NSP) * Convert.ToDouble(box4.Text));
                        dtSalesOrderTable.Rows[i - 1]["TotalPrice"] = (Convert.ToDouble(_oProductDetail.NSP) * Convert.ToDouble(box4.Text)) - TotalProvision;

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
                        dtSalesOrderTable.Rows[i - 1]["PromoDisc"] = box14.Text;
                    }
                    else if (sUnitPriceType == "Special Price")
                    {
                        dtSalesOrderTable.Rows[i - 1]["UnitPrice"] = _oProductDetail.SpecialPrice;


                        _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cbWarehouseName.SelectedIndex].WarehouseID, _oProductDetail.ProductID);
                        Session.Add("WUIUtility", _oWUIUtility);

                        dtSalesOrderTable.Rows[i - 1]["CurrentStock"] = _oWUIUtility.CurrentStock.ToString();
                        dtSalesOrderTable.Rows[i - 1]["Qty"] = box4.Text;
                        dtSalesOrderTable.Rows[i - 1]["ConfirmQty"] = box4.Text;
                        oProvisionParam = new ProvisionParam();
                        oProvisionParam.GetProvisionParam(_oProductDetail.ProductID, _oCustomerDetail.CustomerTypeID);
                        dtSalesOrderTable.Rows[i - 1]["SC"] = Convert.ToDouble(_oProductDetail.SpecialPrice) * oProvisionParam.SC * Convert.ToDouble(box4.Text);
                        dtSalesOrderTable.Rows[i - 1]["PW"] = Convert.ToDouble(_oProductDetail.SpecialPrice) * oProvisionParam.PW * Convert.ToDouble(box4.Text);
                        dtSalesOrderTable.Rows[i - 1]["TP"] = Convert.ToDouble(_oProductDetail.SpecialPrice) * oProvisionParam.TP * Convert.ToDouble(box4.Text);

                        double TotalProvision = (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["SC"].ToString())) + (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["PW"].ToString())) + (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["TP"].ToString()));
                        dtSalesOrderTable.Rows[i - 1]["GTotal"] = (Convert.ToDouble(_oProductDetail.SpecialPrice) * Convert.ToDouble(box4.Text));
                        dtSalesOrderTable.Rows[i - 1]["TotalPrice"] = (Convert.ToDouble(_oProductDetail.SpecialPrice) * Convert.ToDouble(box4.Text)) - TotalProvision;

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
                        dtSalesOrderTable.Rows[i - 1]["PromoDisc"] = box14.Text;
                    }
                    else
                    {
                        dtSalesOrderTable.Rows[i - 1]["UnitPrice"] = _oProductDetail.RSP;
                      

                        _oWUIUtility.GetCurrentStock(_oCustomerDetail.ChannelID, _oWarehouses[cbWarehouseName.SelectedIndex].WarehouseID, _oProductDetail.ProductID);
                        Session.Add("WUIUtility", _oWUIUtility);

                        dtSalesOrderTable.Rows[i - 1]["CurrentStock"] = _oWUIUtility.CurrentStock.ToString();
                        dtSalesOrderTable.Rows[i - 1]["Qty"] = box4.Text;
                        dtSalesOrderTable.Rows[i - 1]["ConfirmQty"] = box4.Text;
                        oProvisionParam = new ProvisionParam();
                        oProvisionParam.GetProvisionParam(_oProductDetail.ProductID, _oCustomerDetail.CustomerTypeID);
                        dtSalesOrderTable.Rows[i - 1]["SC"] = Convert.ToDouble(_oProductDetail.RSP) * oProvisionParam.SC * Convert.ToDouble(box4.Text);
                        dtSalesOrderTable.Rows[i - 1]["PW"] = Convert.ToDouble(_oProductDetail.RSP) * oProvisionParam.PW * Convert.ToDouble(box4.Text);
                        dtSalesOrderTable.Rows[i - 1]["TP"] = Convert.ToDouble(_oProductDetail.RSP) * oProvisionParam.TP * Convert.ToDouble(box4.Text);

                        double TotalProvision = (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["SC"].ToString())) + (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["PW"].ToString())) + (Convert.ToDouble(dtSalesOrderTable.Rows[i - 1]["TP"].ToString()));
                        dtSalesOrderTable.Rows[i - 1]["GTotal"] = (Convert.ToDouble(_oProductDetail.RSP) * Convert.ToDouble(box4.Text));
                        dtSalesOrderTable.Rows[i - 1]["TotalPrice"] = (Convert.ToDouble(_oProductDetail.RSP) * Convert.ToDouble(box4.Text)) - TotalProvision ;

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
                        dtSalesOrderTable.Rows[i - 1]["PromoDisc"] = box14.Text;
                    }
                    dtSalesOrderTable.Rows[i - 1]["ProductID"] = _oProductDetail.ProductID;
                                      
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
                    TextBox box5 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[4].FindControl("txtConfirmQty");
                    TextBox box6 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[5].FindControl("txtGTotal");
                    TextBox box7 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[6].FindControl("txtSC");
                    TextBox box8 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[7].FindControl("txtPW");
                    TextBox box9 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[8].FindControl("txtTP");
                    TextBox box10 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[9].FindControl("txtTotalPrice");
                    TextBox box11 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[10].FindControl("txtPackingQty");
                    TextBox box12 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[11].FindControl("txtCurrentStock");
                    TextBox box14 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[12].FindControl("txtPromoDisc");
                    TextBox box15 = (TextBox)dvwSalesOrder.Rows[_nRowIndex].Cells[13].FindControl("txtProductID");

                    box1.ReadOnly = true;


                    box1.Text = dt.Rows[i]["ProductCode"].ToString();
                    box2.Text = dt.Rows[i]["ProductName"].ToString();
                    box3.Text = dt.Rows[i]["UnitPrice"].ToString();
                    box4.Text = dt.Rows[i]["Qty"].ToString();
                    box5.Text = dt.Rows[i]["Qty"].ToString();
                    box6.Text = dt.Rows[i]["GTotal"].ToString();
                    box7.Text = dt.Rows[i]["SC"].ToString();
                    box8.Text = dt.Rows[i]["PW"].ToString();
                    box9.Text = dt.Rows[i]["TP"].ToString();
                    box10.Text = dt.Rows[i]["TotalPrice"].ToString();
                    box11.Text = dt.Rows[i]["PackingQty"].ToString();
                    box12.Text = dt.Rows[i]["CurrentStock"].ToString();
                    box14.Text = dt.Rows[i]["PromoDisc"].ToString();
                    box15.Text = dt.Rows[i]["ProductID"].ToString();

                    _nRowIndex++;

                }
            }
        }
        GetTotalAmount();
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

    protected void btSave_Click(object sender, EventArgs e)
    {
        lbMsg.Visible = false;
        IsUpdate = (bool)Session["Update"];
        User oUser = (User)Session["User"];

        if (validateUIInput())
        {
            try
            {
                DBController.Instance.BeginNewTransaction();

                ///
                // for Cash order
                ///
                if (chkOrderType.Checked == true)
                {
                    ///
                    // Update SalesOrder and SalesOrderDetail.
                    ///
                    _oSalesOrder = (SalesOrder)Session["SalesOrder"];
                    if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
                    {
                        _oSalesOrder.Clear();
                        _oSalesOrder = GetUIDataForSalesOrder(_oSalesOrder);
                        _oSalesOrder.Edit();
                        Session.Add("SalesOrder", _oSalesOrder);

                        AppLogger.LogInfo("Web: Success fully Update SaleOrder (Order Confirmation)  =" + oUser.Username);

                    }
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        lbMsg.Visible = true;
                        lbMsg.Text = "Error.......only Received order can be confirm";
                        return;
                    }
                    ///
                    // Insert in SalesInvoice and SalesInvoiceDetail.
                    ///
                    _oSalesInvoice = new SalesInvoice();
                    _oSalesInvoice = GetDataForSalesInvoice(_oSalesInvoice);
                    _oSalesInvoice.Insert(false);
                    Session.Add("SalesInvoice", _oSalesInvoice);
                    ///
                    // Insert in Customer Transaction and Update Customer Account.
                    ///
                    _oCustomerTransaction = new CustomerTransaction();
                    _oCustomerTransaction = GetDataForCustomerTran(_oCustomerTransaction);
                    if (_oCustomerTransaction.CheckTranNo())
                        _oCustomerTransaction.AddTran(true);
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        lbMsg.Visible = true;
                        lbMsg.Text = "Error...Tran no for customer transaction is invalied";
                        AppLogger.LogError("Web: Unuccessfull Confirm Sales Order ,current customer tranno already exist");
                        return;
                    }
                    ///
                    // Insert in Product Transaction and Product transaction detail.
                    ///
                            //_oProductTransaction = new ProductTransaction();            
                            //_oProductTransaction = GetDataForProductTran(_oProductTransaction);
                            //if (_oProductTransaction.CheckTranNo())
                            //    _oProductTransaction.Insert();
                            //else
                            //{
                            //    DBController.Instance.RollbackTransaction();
                            //    lbMsg.Visible = true;
                            //    lbMsg.Text = "Error...Tran no for product transaction is invalied";
                            //    AppLogger.LogError("Web: Unuccessfull Confirm Sales Order ,current product tranno already exist");
                            //    return;
                            //}
                    ///
                    // Update Product Satock
                    ///
                    _oSalesInvoice = (SalesInvoice)Session["SalesInvoice"];
                    _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];

                    foreach (SalesInvoiceItem _oSalesInvoiceItem in _oSalesInvoice)
                    {
                        ProductStock oProductStock = new ProductStock();

                        oProductStock.ProductID = _oSalesInvoiceItem.ProductID;
                        oProductStock.Quantity = _oSalesInvoiceItem.Quantity + _oSalesInvoiceItem.FreeQty;
                        oProductStock.WarehouseID = _oSalesInvoice.WarehouseID;
                        oProductStock.ChannelID = _oCustomerDetail.ChannelID;

                        oProductStock.Edit();
                    }
                    DBController.Instance.CommitTransaction();
                    AppLogger.LogInfo("Web: Success fully Confirm sales order  =" + oUser.Username);
                    string[] sSuccedCode =  { "" };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Confirm", "This Sales Order", sSuccedCode, null, "frmOrderConfirmations.aspx", 0);
                    Response.Redirect("frmMessage.aspx");
                              
                }
                ///
                // for Credit order
                ///
                else
                {
                    ///
                    // Update SalesOrder and SalesOrderDetail.
                    ///
                    _oSalesOrder = (SalesOrder)Session["SalesOrder"];
                    if (_oSalesOrder.OrderStatus == (int)Dictionary.OrderStatus.Received)
                    {
                        _oSalesOrder.Clear();
                        _oSalesOrder = GetUIDataForSalesOrder(_oSalesOrder);
                        _oSalesOrder.Edit();
                        Session.Add("SalesOrder", _oSalesOrder);

                        AppLogger.LogInfo("Web: Success fully Update SaleOrder (Order Confirmation)  =" + oUser.Username);

                    }
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        lbMsg.Visible = true;
                        lbMsg.Text = "Error.......only Received order can be confirm";
                        return;
                    }
                    ///
                    // Update Product Satock
                    ///
                    _oSalesOrder = (SalesOrder)Session["SalesOrder"];
                    _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];

                    foreach (SalesOrderItem _oSalesOrderItem in _oSalesOrder)
                    {
                        ProductStock oProductStock = new ProductStock();

                        oProductStock.ProductID = _oSalesOrderItem.ProductID;
                        oProductStock.Quantity = _oSalesOrderItem.Quantity + _oSalesOrderItem.FreeQty;
                        oProductStock.WarehouseID = _oSalesOrder.WarehouseID;
                        oProductStock.ChannelID = _oCustomerDetail.ChannelID;

                        oProductStock.Edit();
                    }
                    DBController.Instance.CommitTransaction();                    
                    AppLogger.LogInfo("Web: Success fully Confirm sales order  =" + oUser.Username);
                    string[] sSuccedCode =  { "" };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Confirm", "This Sales Order", sSuccedCode, null, "frmOrderConfirmations.aspx", 0);
                    Response.Redirect("frmMessage.aspx");
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                AppLogger.LogError("Web: Unuccessfull Confirm Sales Order  =" + ex);
                lbMsg.Visible = true;
                lbMsg.Text = "Error.......Please check your input and try again ";
            }
        }
        else AppLogger.LogWarning("Web: Invalid Input  =" + lbMsg.Text);

        
        
    }

    private bool validateUIInput()
    {
        #region Order Master Information Validation
        _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];
        if (txtOrderNo.Text == "")
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please Input Valid Order Number";
            return false;
        }
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
            _dOrderDate = new DateTime(Convert.ToInt32(cbOyear.SelectedValue), Convert.ToInt32(cbOmonth.SelectedValue), Convert.ToInt32(cbOday.SelectedValue));
        }
        catch
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please Input Valid Order Date";
            return false;
        }
        try
        {
            double temp = Convert.ToDouble(txtAmounttoPay.Text);
        }
        catch
        {
            lbMsg.Visible = true;
            lbMsg.Text = "Please Check your net invoice amount";
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
                    if (dt.Rows[i]["ConfirmQty"].ToString() == "")
                    {
                        lbMsg.Visible = true;
                        lbMsg.Text = "Please Input Valid Product Confirm Quantity";
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
                    if (int.Parse(dt.Rows[i]["ConfirmQty"].ToString()) > int.Parse(dt.Rows[i]["CurrentStock"].ToString()))
                    {
                        lbMsg.Visible = true;
                        lbMsg.Text = "Confirm Quantity must Less or equal to Current Stock";
                        return false;
                    }

                }
            }
            else return false;
        }
        else return false;

        return true;
    }

    ///
    // Get Data for  SalesOrder and SalesOrderDetail.
    ///
    public SalesOrder GetUIDataForSalesOrder(SalesOrder _oSalesOrder)
    {
        int nUserID = int.Parse(Session["UserID"].ToString());

        _oSalesOrder.ConfirmDate = DateTime.Today.Date;
        _oSalesOrder.ConfirmUserID = nUserID;
        if (chkOrderType.Checked == true)
            _oSalesOrder.OrderStatus = (int)Dictionary.OrderStatus.Invoiced;
        else _oSalesOrder.OrderStatus = (int)Dictionary.OrderStatus.Confirmed;
      
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

                    _oSalesOrderItem.ConfirmQuantity = int.Parse(dt.Rows[i]["ConfirmQty"].ToString());
                    _oSalesOrderItem.AdjustedDPAmount = _oSalesOrderItem.UnitPrice * _oProvisionParam.SC;
                    _oSalesOrderItem.AdjustedPWAmount = _oSalesOrderItem.UnitPrice * _oProvisionParam.PW;
                    _oSalesOrderItem.AdjustedTPAmount = _oSalesOrderItem.UnitPrice * _oProvisionParam.TP;
                    _oSalesOrderItem.PromotionalDiscount = Convert.ToDouble(dt.Rows[i]["PromoDisc"].ToString());

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
                        _oSalesOrderItem.PromotionalDiscount = _oProvisionParam.Discount;
                        _oSalesOrderItem.IsFreeProduct = 1;
                        _oSalesOrderItem.FreeQty = (int)(oSalesOrderItem.Quantity / _oProvisionParam.SalesQty) * _oProvisionParam.FreeQty;

                        _oSalesOrder.Add(_oSalesOrderItem);
                    }
                }
            }
        }
        return _oSalesOrder;
    }

    public bool IsOrderProduct(SalesOrder _oSalesOrder, int nProductID)
    {
        foreach (SalesOrderItem oSalesOrderItem in _oSalesOrder)
        {
            if (oSalesOrderItem.ProductID == nProductID)
                return true;
        }
        return false;
    }
    ///
    // End Get Data for  SalesOrder and SalesOrderDetail.
    ///
    
    ///
    // Get Data for  SalesInvoice and SalesInvoiceDetail.
    ///
    public SalesInvoice GetDataForSalesInvoice(SalesInvoice _oSalesInvoice)
    {
        _oSalesOrder = (SalesOrder)Session["SalesOrder"];
        int nUserID = int.Parse(Session["UserID"].ToString());
        _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];
        _oSalesInvoice.OrderNo = _oSalesOrder.OrderNo.ToString();
        _oSalesInvoice.CustomerID = _oSalesOrder.CustomerID;
        _oSalesInvoice.DeliveryAddress = _oSalesOrder.DeliveryAddress;
        _oSalesInvoice.SalesPersonID = _oSalesOrder.SalesPromotionID;
        _oSalesInvoice.WarehouseID = _oSalesOrder.WarehouseID;
        try
        {
            _oSalesInvoice.Discount = Convert.ToDouble(txtDiscount.Text);
        }
        catch
        {
            _oSalesInvoice.Discount = 0;
        }
        _oSalesInvoice.Remarks = txtRemarks.Text;
        _oSalesInvoice.OrderID = _oSalesOrder.OrderID;
        if (chkOrderType.Checked == true)
        {
            _oSalesInvoice.InvoiceTypeID = (short)Dictionary.OrderType.CASH;
        }
        else
        {
            _oSalesInvoice.InvoiceTypeID = (short)Dictionary.OrderType.CREDIT;
        }
        _oSalesInvoice.UserID = nUserID;
        try
        {
            _oSalesInvoice.InvoiceAmount = Convert.ToDouble(txtAmounttoPay.Text);
        }
        catch
        {
            _oSalesInvoice.InvoiceAmount = 0;
        }
        _oSalesInvoice.PriceOptionID = _oCustomerDetail.PriceOptionID;
        _oSalesInvoice.SalesPromotionID = _oSalesOrder.SalesPromotionID;

        // Product Details

        if (ViewState["SalesOrderTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["SalesOrderTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SalesInvoiceItem _oSalesInvoiceItem = new SalesInvoiceItem();

                    _oProvisionParam = new ProvisionParam();

                    _oSalesInvoiceItem.ProductID = int.Parse(dt.Rows[i]["ProductID"].ToString());
                    _oSalesInvoiceItem.UnitPrice= Convert.ToDouble(dt.Rows[i]["UnitPrice"].ToString());
                    _oSalesInvoiceItem.Quantity = int.Parse(dt.Rows[i]["ConfirmQty"].ToString());
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = _oSalesInvoiceItem.ProductID;
                    _oProductDetail.Refresh();
                    _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                    _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                    if (_oSalesInvoiceItem.UnitPrice == 0)
                        _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                    else _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1+_oSalesInvoiceItem.VATAmount), 4);

                    _oProvisionParam.GetProvisionParam(_oSalesInvoiceItem.ProductID, _oCustomerDetail.CustomerTypeID);
                
                    _oSalesInvoiceItem.AdjustedDPAmount = _oSalesInvoiceItem.UnitPrice * _oProvisionParam.SC;
                    _oSalesInvoiceItem.AdjustedPWAmount = _oSalesInvoiceItem.UnitPrice * _oProvisionParam.PW;
                    _oSalesInvoiceItem.AdjustedTPAmount = _oSalesInvoiceItem.UnitPrice * _oProvisionParam.TP;

                    _oProvisionParam.GetFreeProduct(_oSalesInvoiceItem.ProductID, _oCustomerDetail.CustomerTypeID);

                    //_oSalesInvoiceItem.PromotionalDiscount = (Math.Floor((_oSalesInvoiceItem.Quantity) / Convert.ToDouble(_oProvisionParam.SalesQty))) * Convert.ToDouble(_oProvisionParam.Discount);
                    _oSalesInvoiceItem.PromotionalDiscount = Convert.ToDouble(dt.Rows[i]["PromoDisc"].ToString());
                    _oSalesInvoiceItem.IsFreeProduct = 0;
                    _oSalesInvoiceItem.FreeQty = 0;

                    _oSalesInvoice.Add(_oSalesInvoiceItem);
                }
            }
        }
        if (_oSalesInvoice.SalesPromotionID != -1)
        {
            foreach (SalesInvoiceItem _oSalesInvoiceItem in _oSalesInvoice)
            {
                ProvisionParam _oProvisionParam = new ProvisionParam();
                if (_oProvisionParam.GetFreeProduct(_oSalesInvoiceItem.ProductID, _oSalesInvoice.SalesPromotionID))
                {
                    _oProvisionParam.GetFreeProduct(_oSalesInvoiceItem.ProductID, _oCustomerDetail.CustomerTypeID);

                    if (IsInvoiceProduct(_oSalesInvoice, _oProvisionParam.FreeProductID))
                    {
                        _oSalesInvoiceItem.PromotionalDiscount = (Math.Floor((_oSalesInvoiceItem.Quantity) / Convert.ToDouble(_oProvisionParam.SalesQty))) * Convert.ToDouble(_oProvisionParam.Discount);
                        //_oSalesInvoiceItem.PromotionalDiscount = _oProvisionParam.Discount * _oSalesInvoiceItem.Quantity;
                        _oSalesInvoiceItem.FreeQty = (int)(_oSalesInvoiceItem.Quantity / _oProvisionParam.SalesQty) * _oProvisionParam.FreeQty;
                    }
                    else
                    {
                        _oProvisionParam = new ProvisionParam();

                        _oSalesInvoiceItem.ProductID = _oProvisionParam.FreeProductID;
                        _oSalesInvoiceItem.UnitPrice = 0;
                        _oSalesInvoiceItem.Quantity = 0;

                        _oProductDetail = new ProductDetail();
                        _oProductDetail.ProductID = _oSalesInvoiceItem.ProductID;
                        _oProductDetail.Refresh();
                        _oSalesInvoiceItem.CostPrice = _oProductDetail.CostPrice;
                        _oSalesInvoiceItem.VATAmount = _oProductDetail.Vat;

                        if (_oSalesInvoiceItem.UnitPrice == 0)
                            _oSalesInvoiceItem.TradePrice = _oProductDetail.TradePrice;
                        else _oSalesInvoiceItem.TradePrice = Math.Round(_oSalesInvoiceItem.UnitPrice / (1 + _oSalesInvoiceItem.VATAmount), 4);

                        _oProvisionParam.GetProvisionParam(_oSalesInvoiceItem.ProductID, _oCustomerDetail.CustomerTypeID);

                        _oSalesInvoiceItem.AdjustedDPAmount = 0;
                        _oSalesInvoiceItem.AdjustedPWAmount = 0;
                        _oSalesInvoiceItem.AdjustedTPAmount = 0;
                        
                        _oSalesInvoiceItem.PromotionalDiscount = (Math.Floor((_oSalesInvoiceItem.Quantity) / Convert.ToDouble(_oProvisionParam.SalesQty))) * Convert.ToDouble(_oProvisionParam.Discount);
                       // _oSalesInvoiceItem.PromotionalDiscount = _oProvisionParam.Discount;
                        _oSalesInvoiceItem.IsFreeProduct = 1;
                        _oSalesInvoiceItem.FreeQty = (int)(_oSalesInvoiceItem.Quantity / _oProvisionParam.SalesQty) * _oProvisionParam.FreeQty;

                        _oSalesInvoice.Add(_oSalesInvoiceItem);
                       

                    }
                }
            }
        }
        return _oSalesInvoice;

    }
    public bool IsInvoiceProduct(SalesInvoice _oSalesInvoice, int nProductID)
    {
        foreach (SalesInvoiceItem oSalesInvoiceItem in _oSalesInvoice)
        {
            if (oSalesInvoiceItem.ProductID == nProductID)
                return true;
        }
        return false;
    }
    ///
    // End Get Data for  SalesInvoice and SalesInvoiceDetail.
    ///

    ///
    // Get Data for  Customer Transaction.
    ///

    public CustomerTransaction GetDataForCustomerTran(CustomerTransaction _oCustomerTransaction)
    {
        _oSalesOrder = (SalesOrder)Session["SalesOrder"];
        User oUser = (User)Session["User"];
        int nUserID = int.Parse(Session["UserID"].ToString());
        _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];
        _oSalesInvoice = (SalesInvoice)Session["SalesInvoice"];

        _oCustomerTransaction.CustomerID = _oSalesOrder.CustomerID;
        _oCustomerTransaction.TranNo = _oSalesInvoice.RefDetails;
        _oCustomerTransaction.TranDate = DateTime.Now;       
        _oCustomerTransaction.Amount = _oSalesInvoice.InvoiceAmount;
        _oCustomerTransaction.InstrumentNo = _oSalesInvoice.InvoiceNo;
        _oCustomerTransaction.Terminal = oUser.Employee.JobLocation.JobLocationID;
        _oCustomerTransaction.Remarks = txtRemarks.Text;
        _oCustomerTransaction.UserID = nUserID;
        _oCustomerTransaction.TranTypeID = (int)Dictionary.TransectionType.CASH_INVOICE;

        return _oCustomerTransaction;
    }
    ///
    // End  Customer Transaction.
    ///
    ///
    // Get Data for  Product Transaction.
    ///
    public ProductTransaction GetDataForProductTran(ProductTransaction _oProductTransaction)
    {
        _oSalesOrder = (SalesOrder)Session["SalesOrder"];
        User oUser = (User)Session["User"];
        int nUserID = int.Parse(Session["UserID"].ToString());
        _oCustomerDetail = (CustomerDetail)Session["CustomerDetail"];
        _oSalesInvoice = (SalesInvoice)Session["SalesInvoice"];

        _oProductTransaction.TranNo = _oSalesInvoice.RefDetails;
        _oProductTransaction.TranDate = DateTime.Now;
        _oWarehouse = new Warehouse();
        _oWarehouse.WarehouseID = _oSalesInvoice.WarehouseID;
        _oWarehouse.Reresh();
        _oProductTransaction.FromWHID = _oSalesInvoice.WarehouseID;
        _oProductTransaction.FromChannelID = _oWarehouse.ChannelID;
        _oProductTransaction.UserID = nUserID;
        _oProductTransaction.Remarks = txtRemarks.Text;
        _oProductTransaction.Terminal = oUser.Employee.JobLocation.JobLocationID;

        // Product Detail
        foreach (SalesInvoiceItem _oSalesInvoiceItem in _oSalesInvoice)
        {
            ProductTransactionDetail _oProductTransactionDetail = new ProductTransactionDetail();

            _oProductTransactionDetail.ProductID = _oSalesInvoiceItem.ProductID;
            _oProductTransactionDetail.StockPrice = _oSalesInvoiceItem.CostPrice;
            _oProductTransactionDetail.Qty = _oSalesInvoiceItem.Quantity + _oSalesInvoiceItem.FreeQty;

            _oProductTransaction.Add(_oProductTransactionDetail);
        }

        return _oProductTransaction;
    }
    ///
    // End  Product Transaction.
    ///
}

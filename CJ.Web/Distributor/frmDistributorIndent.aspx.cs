using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CJ.Class.DMS;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.M;

public partial class Distributor_frmDistributorIndent : System.Web.UI.Page
{
    MAreas _oAreas;
    MCustomers _oMCustomers;
    MCustomer oMCustomer;
    MOrder _oMOrder;
    MOrders oMOrders;
    TELLib _oTELLib;
    //ProductDetails oProductDetails;
    Outlets oOutlets;
    //ProductTran oProductTran;
    DMSUser oDMSUser;
    //int _nRowIndex = 0;
    DateTime _dSalesDate;
    //bool IsColor = false;
    string sDay;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           //oDMSUser = (DMSUser)Session["User"];
            cmbday.Text = DateTime.Today.Date.Day.ToString();
            cmbmonth.Text = DateTime.Today.Date.Month.ToString();
            cmbyear.Text = DateTime.Today.Date.Year.ToString();

            sDay = DateTime.Today.Date.ToLongDateString();
            char[] splitchar = { ',' };
            string[] sArr = sDay.Split(splitchar);
            LoadAreas();
            Session.Add("Color", true);
        }

    }
    protected void LnkReport_Click(object sender, EventArgs e)
    {

    }
    protected void cmbday_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadAreas();
    }
    protected void cmbmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadAreas();
    }
    protected void cmbyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadAreas();
    }
    protected void LnkLogout_Click(object sender, EventArgs e)
    {
        Session.RemoveAll();
        Response.Redirect("frmLogon.aspx");
    }

    public void LoadAreas()
    {
        _oAreas = new MAreas();
        DBController.Instance.OpenNewConnection();
       // _oAreas.Refresh((string)Session["UserType"], (string)Session["LoginCode"]);
        _oAreas.Refresh("Customer", "24001403");
        DBController.Instance.CloseConnection();
        Session.Add("Areas", _oAreas);
        cmbOutlet.DataSource = _oAreas;
        cmbOutlet.DataTextField = "AreaName";
        cmbOutlet.DataBind();
        cmbOutlet.SelectedIndex = _oAreas.Count - 1;
        cmbOutlet_SelectedIndexChanged1(null, null);
    }

    
    public void LoadCustomers()
    {
        _oTELLib = new TELLib();
        _oMCustomers = new MCustomers();
        DateTime _dOrderDate = new DateTime(Convert.ToInt32(cmbyear.SelectedValue), Convert.ToInt32(cmbmonth.SelectedValue), Convert.ToInt32(cmbday.SelectedValue));

        DBController.Instance.OpenNewConnection();
        if ((string)Session["UserType"] == "Customer")
        {
            if (Utility.CompanyInfo == "TML")
            {
                _oMCustomers.RefreshByCustomer((string)Session["LoginCode"], _dOrderDate);
            }

            if (Utility.CompanyInfo == "BLL")
            {
                _oMCustomers.RefreshByCustomerBLL((string)Session["LoginCode"], _dOrderDate);
            }

        }
        else
        {
            _oAreas = (MAreas)Session["Areas"];
            string sAreaCode = _oAreas[cmbOutlet.SelectedIndex].AreaCode;

            if (Utility.CompanyInfo == "TML")
            {
                _oMCustomers.RefreshByArea(sAreaCode, _dOrderDate);
            }

            if (Utility.CompanyInfo == "BLL")
            {
                _oMCustomers.RefreshByAreaBLL(sAreaCode, _dOrderDate);
            }

        }
        DBController.Instance.CloseConnection();

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("CustomerCode", typeof(string)));
        dt.Columns.Add(new DataColumn("CustomerName", typeof(string)));
        dt.Columns.Add(new DataColumn("L7DQty", typeof(string)));
        dt.Columns.Add(new DataColumn("TotalOrder", typeof(string)));
        dt.Columns.Add(new DataColumn("Qty", typeof(string)));
        dt.Columns.Add(new DataColumn("OrderValue", typeof(string)));
        dt.Columns.Add(new DataColumn("CustomerID", typeof(string)));

        dr = dt.NewRow();

        dr["CustomerCode"] = string.Empty;
        dr["CustomerName"] = string.Empty;
        dr["L7DQty"] = string.Empty;
        dr["TotalOrder"] = string.Empty;
        dr["Qty"] = string.Empty;
        dr["OrderValue"] = string.Empty;
        dr["CustomerID"] = string.Empty;

        foreach (MCustomer oMCustomer in _oMCustomers)
        {
            dr = dt.NewRow();

            dr["CustomerCode"] = oMCustomer.CustomerCode;
            dr["CustomerName"] = oMCustomer.CustomerName;
            dr["L7DQty"] = oMCustomer.SaleQty;
            dr["TotalOrder"] = oMCustomer.TotalOrder;
            dr["Qty"] = oMCustomer.Result;
            dr["OrderValue"] = _oTELLib.TakaFormat(Convert.ToDouble(oMCustomer.Value.ToString()));
            dr["CustomerID"] = oMCustomer.CustomerID;

            dt.Rows.Add(dr);

        }
        ViewState["SalesTable"] = dt;
        dvwSales.DataSource = dt;
        dvwSales.DataBind();
        setListViewRowFont();

    }

    private void setListViewRowFont()
    {
        DataTable dtCondition = (DataTable)ViewState["SalesTable"];
        if (dtCondition.Rows.Count > 0)
        {
            for (int i = 0; i < dtCondition.Rows.Count; i++)
            {
                Label lblOrder = (Label)dvwSales.Rows[i].Cells[2].FindControl("txtTotalOrder");

                if (Convert.ToInt32(lblOrder.Text.ToString()) != 0)
                {
                    GridViewRow oRow = dvwSales.Rows[i];
                    oRow.ForeColor = Color.Green;
                    oRow.Font.Bold = true;
                }
            }
        }
    }

    public void EditItem(Object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        oMCustomer = new MCustomer();
        DBController.Instance.OpenNewConnection();
        oMCustomer.Refresh(link.Text);
        DBController.Instance.CloseConnection();
        lblCustomer.Text = "Orders of [" + oMCustomer.CustomerCode + "]" + oMCustomer.CustomerName;
        oMOrders = new MOrders();

        _dSalesDate = new DateTime(Convert.ToInt32(cmbyear.SelectedValue), Convert.ToInt32(cmbmonth.SelectedValue), Convert.ToInt32(cmbday.SelectedValue));

        DBController.Instance.OpenNewConnection();
        oMOrders.Refresh(_dSalesDate, oMCustomer.CustomerID);
        DBController.Instance.CloseConnection();

        MOrder oOrder = new MOrder();
        oOrder.OrderNo = "[New Order]";
        oMOrders.Add(oOrder);

        Session.Add("MOrders", oMOrders);
        Session.Add("CustID", oMCustomer.CustomerID);

        cboOrders.DataSource = oMOrders;
        cboOrders.DataTextField = "OrderNo";
        cboOrders.DataBind();
        cboOrders.SelectedIndex = oMOrders.Count - 1;

        cboOrders_SelectedIndexChanged(null, null);
    }



    protected void cboOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        MOrders oMOrders = (MOrders)Session["MOrders"];
        int nCustomerID = (int)Session["CustID"];
        int nOrderID = oMOrders[cboOrders.SelectedIndex].OrderID;
        if (cboOrders.Text != "[New Order]")
        {
            //oMCustomer = new MCustomer();
        }
        _oMOrder = new MOrder();
        DBController.Instance.OpenNewConnection();

        if (Utility.CompanyInfo == "TML")
        {
            _oMOrder.Refresh(nOrderID, nCustomerID);
        }
        if (Utility.CompanyInfo == "BLL")
        {
            _oMOrder.RefreshBLL(nOrderID, nCustomerID);
        }

        if (cboOrders.Text != "[New Order]")
        {
            _oMOrder.GetOrderStatusByOrderID(nOrderID);
        }

        DBController.Instance.CloseConnection();

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("ProductCode", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
        dt.Columns.Add(new DataColumn("MOQ", typeof(string)));
        dt.Columns.Add(new DataColumn("Stock", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductPrice", typeof(string)));
        dt.Columns.Add(new DataColumn("OrderQty", typeof(string)));
        dt.Columns.Add(new DataColumn("RevOrderQty", typeof(string)));
        dt.Columns.Add(new DataColumn("NOrderQty", typeof(string)));
        dt.Columns.Add(new DataColumn("OrderValue", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductID", typeof(string)));

        dr = dt.NewRow();

        dr["ProductCode"] = string.Empty;
        dr["ProductName"] = string.Empty;
        dr["MOQ"] = string.Empty;
        dr["Stock"] = string.Empty;
        dr["ProductPrice"] = string.Empty;
        dr["OrderQty"] = string.Empty;
        dr["RevOrderQty"] = string.Empty;
        dr["NOrderQty"] = string.Empty;

        dr["OrderValue"] = string.Empty;
        dr["ProductID"] = string.Empty;

        foreach (MOrderItem oItem in _oMOrder)
        {
            double _value = 0;

            dr = dt.NewRow();

            dr["ProductCode"] = oItem.AG;
            dr["ProductName"] = oItem.ProductName;

            // dr["MOQ"] = oItem.MOQ; 
            dr["Stock"] = oItem.Stock;
            dr["ProductPrice"] = oItem.ProductPrice;

            if (cboOrders.Text == "[New Order]")
            {
                dr["OrderQty"] = 0;
                dr["RevOrderQty"] = 0;
                dr["NOrderQty"] = 0;
            }
            else
            {
                if (_oMOrder.IsComplete == false)
                {

                    if ((string)Session["UserType"] == "Customer" && _oMOrder.OrderStatus == "CustomerOrder")
                    {
                        dr["OrderQty"] = oItem.OrderQty;
                        dr["RevOrderQty"] = 0;
                        dr["NOrderQty"] = 0;
                        _value = oItem.ProductPrice * oItem.OrderQty;
                    }
                    else if ((string)Session["UserType"] == "Customer" && _oMOrder.OrderStatus == "AreaOrder")
                    {
                        dr["OrderQty"] = oItem.OrderQty;
                        dr["RevOrderQty"] = oItem.RevOrderQty;
                        dr["NOrderQty"] = 0;
                        _value = oItem.ProductPrice * oItem.RevOrderQty;
                    }
                    else if ((string)Session["UserType"] == "Customer" && _oMOrder.OrderStatus == "NationalOrder")
                    {
                        dr["OrderQty"] = oItem.OrderQty;
                        dr["RevOrderQty"] = oItem.RevOrderQty;
                        dr["NOrderQty"] = oItem.NOrderQty;
                        _value = oItem.ProductPrice * oItem.NOrderQty;
                    }
                    else if ((string)Session["UserType"] == "Area" && _oMOrder.OrderStatus == "CustomerOrder")
                    {
                        dr["OrderQty"] = oItem.OrderQty;
                        dr["RevOrderQty"] = oItem.OrderQty;
                        dr["NOrderQty"] = 0;
                        _value = oItem.ProductPrice * oItem.OrderQty;
                    }
                    else if ((string)Session["UserType"] == "Area" && _oMOrder.OrderStatus == "AreaOrder")
                    {
                        dr["OrderQty"] = oItem.OrderQty;
                        dr["RevOrderQty"] = oItem.RevOrderQty;
                        dr["NOrderQty"] = 0;
                        _value = oItem.ProductPrice * oItem.RevOrderQty;
                    }
                    else if ((string)Session["UserType"] == "Area" && _oMOrder.OrderStatus == "NationalOrder")
                    {
                        dr["OrderQty"] = oItem.OrderQty;
                        dr["RevOrderQty"] = oItem.RevOrderQty;
                        dr["NOrderQty"] = oItem.NOrderQty;
                        _value = oItem.ProductPrice * oItem.NOrderQty;
                    }

                    else if ((string)Session["UserType"] == "National" && _oMOrder.OrderStatus == "AreaOrder")
                    {
                        dr["OrderQty"] = oItem.OrderQty;
                        dr["RevOrderQty"] = oItem.RevOrderQty;
                        dr["NOrderQty"] = oItem.RevOrderQty;
                        _value = oItem.ProductPrice * oItem.RevOrderQty;
                    }
                    else if ((string)Session["UserType"] == "National" && _oMOrder.OrderStatus == "NationalOrder")
                    {
                        dr["OrderQty"] = oItem.OrderQty;
                        dr["RevOrderQty"] = oItem.RevOrderQty;
                        dr["NOrderQty"] = oItem.NOrderQty;
                        _value = oItem.ProductPrice * oItem.NOrderQty;
                    }
                    else if ((string)Session["UserType"] == "National" && _oMOrder.OrderStatus == "CustomerOrder")
                    {
                        dr["OrderQty"] = oItem.OrderQty;
                        dr["RevOrderQty"] = oItem.RevOrderQty;
                        dr["NOrderQty"] = oItem.OrderQty;
                        _value = oItem.ProductPrice * oItem.OrderQty;
                    }
                }
                else
                {
                    if (_oMOrder.OrderStatus == "CustomerOrder")
                    {
                        dr["OrderQty"] = oItem.OrderQty;
                        dr["RevOrderQty"] = oItem.RevOrderQty;
                        dr["NOrderQty"] = oItem.NOrderQty;
                        _value = oItem.ProductPrice * oItem.OrderQty;
                    }
                    else if (_oMOrder.OrderStatus == "AreaOrder")
                    {
                        dr["OrderQty"] = oItem.OrderQty;
                        dr["RevOrderQty"] = oItem.RevOrderQty;
                        dr["NOrderQty"] = oItem.NOrderQty;
                        _value = oItem.ProductPrice * oItem.RevOrderQty;
                    }
                    else if (_oMOrder.OrderStatus == "NationalOrder")
                    {
                        dr["OrderQty"] = oItem.OrderQty;
                        dr["RevOrderQty"] = oItem.RevOrderQty;
                        dr["NOrderQty"] = oItem.NOrderQty;
                        _value = oItem.ProductPrice * oItem.NOrderQty;

                    }
                }

            }
            _oTELLib = new TELLib();
            dr["OrderValue"] = _oTELLib.TakaFormat(Convert.ToDouble(_value.ToString()));
            dr["ProductID"] = oItem.ProductID;

            dt.Rows.Add(dr);

        }
        if ((string)Session["UserType"] == "Customer" && (cboOrders.Text == "[New Order]"))
        {
            dvwProduct.Columns[5].Visible = false;
            dvwProduct.Columns[6].Visible = false;
        }
        else if ((string)Session["UserType"] == "Customer" && (cboOrders.Text != "[New Order]"))
        {
            dvwProduct.Columns[5].Visible = true;
            dvwProduct.Columns[6].Visible = true;
        }
        else if ((string)Session["UserType"] == "Area" && (cboOrders.Text == "[New Order]"))
        {
            dvwProduct.Columns[6].Visible = false;
        }
        else if ((string)Session["UserType"] == "Area" && (cboOrders.Text != "[New Order]"))
        {
            dvwProduct.Columns[6].Visible = true;
        }

        ViewState["ProductTable"] = dt;

        dvwProduct.DataSource = dt;
        dvwProduct.DataBind();

        dvwProduct_ReadOnly(null, null);
        GetTotal();
        //UpdatePanel1.Update();


    }

    protected void dvwProduct_ReadOnly(object sender, GridViewRowEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["ProductTable"];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBox txt = (TextBox)dvwProduct.Rows[i].Cells[5].FindControl("txtOrderQty");
                TextBox txt1 = (TextBox)dvwProduct.Rows[i].Cells[6].FindControl("txtRevOrderQty");
                TextBox txt2 = (TextBox)dvwProduct.Rows[i].Cells[7].FindControl("txtNOrderQty");

                MOrders oMOrders = (MOrders)Session["MOrders"];
                int nOrderID = oMOrders[cboOrders.SelectedIndex].OrderID;

                DBController.Instance.OpenNewConnection();
                if (cboOrders.Text != "[New Order]")
                {
                    _oMOrder.GetOrderStatusByOrderID(nOrderID);
                }
                DBController.Instance.CloseConnection();

                if (cboOrders.Text != "[New Order]")
                {
                    if (_oMOrder.IsComplete == true)
                    {
                        txt.ReadOnly = true;
                        txt.BackColor = Color.LightGray;
                        txt1.ReadOnly = true;
                        txt1.BackColor = Color.LightGray;
                        txt2.ReadOnly = true;
                        txt2.BackColor = Color.LightGray;
                    }
                    else
                    {
                        //if ((string)Session["UserType"] == "Customer" && _oMOrder.OrderStatus == "CustomerOrder")
                        if ("Customer"== "Customer" )
                        {
                            txt1.ReadOnly = true;
                            txt1.BackColor = Color.LightGray;
                            txt2.ReadOnly = true;
                            txt2.BackColor = Color.LightGray;
                        }
                        else if ((string)Session["UserType"] == "Customer" && _oMOrder.OrderStatus == "AreaOrder")
                        {
                            txt.ReadOnly = true;
                            txt.BackColor = Color.LightGray;
                            txt1.ReadOnly = true;
                            txt1.BackColor = Color.LightGray;
                            txt2.ReadOnly = true;
                            txt2.BackColor = Color.LightGray;
                        }
                        else if ((string)Session["UserType"] == "Customer" && _oMOrder.OrderStatus == "NationalOrder")
                        {
                            txt.ReadOnly = true;
                            txt.BackColor = Color.LightGray;
                            txt1.ReadOnly = true;
                            txt1.BackColor = Color.LightGray;
                            txt2.ReadOnly = true;
                            txt2.BackColor = Color.LightGray;
                        }
                        else if ((string)Session["UserType"] == "Area" && _oMOrder.OrderStatus == "AreaOrder")
                        {
                            txt.ReadOnly = true;
                            txt.BackColor = Color.LightGray;
                            txt2.ReadOnly = true;
                            txt2.BackColor = Color.LightGray;
                        }
                        else if ((string)Session["UserType"] == "Area" && _oMOrder.OrderStatus == "CustomerOrder")
                        {
                            txt.ReadOnly = true;
                            txt.BackColor = Color.LightGray;
                            txt2.ReadOnly = true;
                            txt2.BackColor = Color.LightGray;
                        }
                        else if ((string)Session["UserType"] == "Area" && _oMOrder.OrderStatus == "NationalOrder")
                        {
                            txt.ReadOnly = true;
                            txt.BackColor = Color.LightGray;
                            txt1.ReadOnly = true;
                            txt1.BackColor = Color.LightGray;
                            txt2.ReadOnly = true;
                            txt2.BackColor = Color.LightGray;
                        }
                        else if ((string)Session["UserType"] == "National")
                        {
                            txt.ReadOnly = true;
                            txt.BackColor = Color.LightGray;
                            txt1.ReadOnly = true;
                            txt1.BackColor = Color.LightGray;
                        }
                        else
                        {
                            txt.ReadOnly = true;
                            txt.BackColor = Color.LightGray;
                            txt1.ReadOnly = true;
                            txt1.BackColor = Color.LightGray;
                            txt2.ReadOnly = true;
                            txt2.BackColor = Color.LightGray;
                        }


                    }
                }
                else
                {
                    if ((string)Session["UserType"] == "Customer")
                    {
                        txt1.ReadOnly = true;
                        txt1.BackColor = Color.LightGray;
                        txt2.ReadOnly = true;
                        txt2.BackColor = Color.LightGray;
                    }
                    else if ((string)Session["UserType"] == "Area")
                    {
                        txt.ReadOnly = true;
                        txt.BackColor = Color.LightGray;
                        txt2.ReadOnly = true;
                        txt2.BackColor = Color.LightGray;
                    }
                    else
                    {
                        txt.ReadOnly = true;
                        txt.BackColor = Color.LightGray;
                        txt1.ReadOnly = true;
                        txt1.BackColor = Color.LightGray;
                    }

                }
            }
        }
    }

    protected void txtOrderQty_TextChanged(object sender, System.EventArgs e)
    {
        GetTotal();
        LoadCustomers();
        //Page_Load(null, null);
        //cmbOutlet_SelectedIndexChanged(null, null);
        //cmbday_SelectedIndexChanged(sender, e);
    }

    public void GetTotal()
    {
        _oTELLib = new TELLib();
        double Totalvalue = 0;

        MOrders oMOrders = (MOrders)Session["MOrders"];
        int nOrderID = oMOrders[cboOrders.SelectedIndex].OrderID;
        DBController.Instance.OpenNewConnection();
        if (cboOrders.Text != "[New Order]")
        {
            _oMOrder.GetOrderStatusByOrderID(nOrderID);
        }

        if (ViewState["ProductTable"] != null)
        {
            DataTable dtSalesOrderTable = (DataTable)ViewState["ProductTable"];
            DataRow drSalesOrderRow = null;
            if (dtSalesOrderTable.Rows.Count > 0)
            {
                for (int i = 0; i < dtSalesOrderTable.Rows.Count; i++)
                {

                    Label txtProductPrice = (Label)dvwProduct.Rows[i].Cells[3].FindControl("ProductPrice");
                    double nProductPrice = Convert.ToDouble(txtProductPrice.Text.ToString());

                    TextBox txtOrderQty = (TextBox)dvwProduct.Rows[i].Cells[4].FindControl("txtOrderQty");
                    TextBox txtRevOrderQty = (TextBox)dvwProduct.Rows[i].Cells[5].FindControl("txtRevOrderQty");
                    TextBox txtNOrderQty = (TextBox)dvwProduct.Rows[i].Cells[6].FindControl("txtNOrderQty");
                    Label lblValue = (Label)dvwProduct.Rows[i].Cells[6].FindControl("OrderValue");

                    drSalesOrderRow = dtSalesOrderTable.NewRow();

                    if (cboOrders.Text != "[New Order]")
                    {
                        if (_oMOrder.OrderStatus == "CustomerOrder")
                        {
                            if (txtProductPrice.Text != "" && txtOrderQty.Text != "0")
                            {
                                dtSalesOrderTable.Rows[i]["OrderValue"] = Convert.ToDouble(txtProductPrice.Text) * Convert.ToDouble(txtOrderQty.Text);
                                lblValue.Text = _oTELLib.TakaFormat(Convert.ToDouble(dtSalesOrderTable.Rows[i]["OrderValue"].ToString()));
                                //lblValue.Text = dtSalesOrderTable.Rows[i]["OrderValue"].ToString();
                                Totalvalue = Totalvalue + Convert.ToDouble(lblValue.Text);
                            }
                        }
                        else if (_oMOrder.OrderStatus == "AreaOrder")
                        {
                            if (txtProductPrice.Text != "" && txtRevOrderQty.Text != "0")
                            {
                                dtSalesOrderTable.Rows[i]["OrderValue"] = Convert.ToDouble(txtProductPrice.Text) * Convert.ToDouble(txtRevOrderQty.Text);

                                lblValue.Text = _oTELLib.TakaFormat(Convert.ToDouble(dtSalesOrderTable.Rows[i]["OrderValue"].ToString()));
                                //lblValue.Text = dtSalesOrderTable.Rows[i]["OrderValue"].ToString();
                                Totalvalue = Totalvalue + Convert.ToDouble(lblValue.Text);
                            }
                        }
                        else if (_oMOrder.OrderStatus == "NationalOrder")
                        {
                            if (txtProductPrice.Text != "" && txtNOrderQty.Text != "0")
                            {
                                dtSalesOrderTable.Rows[i]["OrderValue"] = Convert.ToDouble(txtProductPrice.Text) * Convert.ToDouble(txtNOrderQty.Text);


                                lblValue.Text = _oTELLib.TakaFormat(Convert.ToDouble(dtSalesOrderTable.Rows[i]["OrderValue"].ToString()));
                                //lblValue.Text = dtSalesOrderTable.Rows[i]["OrderValue"].ToString();
                                Totalvalue = Totalvalue + Convert.ToDouble(lblValue.Text);
                            }
                        }
                    }

                }


            }
            lblAmt.Text = "(BDT = " + _oTELLib.TakaFormat(Convert.ToDouble(Totalvalue.ToString())) + " )";

        }
    }



    protected void btSaveOrder_Click(object sender, EventArgs e)
    {
        Save();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

        _oMOrder = new MOrder();
        MOrders oMOrders = (MOrders)Session["MOrders"];
        int nOrderID = oMOrders[cboOrders.SelectedIndex].OrderID;

        if (cboOrders.Text != "[New Order]")
        {
            _oMOrder.GetOrderStatusByOrderID(nOrderID);
            if (_oMOrder.IsComplete == false)
            {

                if ((string)Session["UserType"] == "Customer" && _oMOrder.OrderStatus == "CustomerOrder")
                {
                    DBController.Instance.BeginNewTransaction();
                    _oMOrder.Delete(nOrderID);
                    DBController.Instance.CommitTran();
                    LoadCustomers();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Successful Deleted the order";

                    return;
                }
                else if ((string)Session["UserType"] == "Area" && _oMOrder.OrderStatus == "AreaOrder")
                {
                    DBController.Instance.BeginNewTransaction();
                    _oMOrder.Delete(nOrderID);
                    DBController.Instance.CommitTran();
                    LoadCustomers();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Successful Deleted the order";

                    return;
                }
                else if ((string)Session["UserType"] == "National" && _oMOrder.OrderStatus == "NationalOrder")
                {
                    DBController.Instance.BeginNewTransaction();
                    _oMOrder.Delete(nOrderID);
                    DBController.Instance.CommitTran();
                    LoadCustomers();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Successful Deleted the order";

                    return;
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "The order is not eligible to delete ";
                    return;
                }

            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "The order already captured by HQ";
                return;
            }

        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please select a order to delete";
            return;
        }

    }

    public void Save()
    {
        MOrder oOrder;

        lblMessage.Visible = false;


        if (validateUIInput())
        {
            try
            {
                oOrder = new MOrder();
                oOrder = GetUIData(oOrder);

                if (oOrder.Count <= 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Please input atleast one item";
                    return;

                }
                DBController.Instance.BeginNewTransaction();
                if (cboOrders.Text == "[New Order]")
                {
                    oOrder.Insert();
                }
                else
                {
                    oOrder.Update();
                }
                DBController.Instance.CommitTransaction();

                lblMessage.Visible = true;
                lblMessage.Text = "Successful Add Transaction";
                //Response.Redirect("frmEntryInfo.aspx");
                LoadCustomers();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                lblMessage.Visible = true;
                lblMessage.Text = "Unsuccessful Add Transaction";
            }
        }
    }

    private bool validateUIInput()
    {
        oOutlets = (Outlets)Session["Outlet"];
        try
        {
            _dSalesDate = new DateTime(Convert.ToInt32(cmbyear.SelectedValue), Convert.ToInt32(cmbmonth.SelectedValue), Convert.ToInt32(cmbday.SelectedValue));
        }
        catch
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Valid sales Date";
            return false;
        }
        //if (_dSalesDate < DateTime.Today.Date.AddDays(-2))
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "Please Input Valid sales Date";
        //    return false;
        //}
        //if (oOutlets[cmbOutlet.SelectedIndex].OutletID==-1)
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "Please Select a Outlet";
        //    return false;
        //}
        if (ViewState["ProductTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["ProductTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (dt.Rows[i]["OrderQty"].ToString() != "" || Convert.ToInt32(dt.Rows[i]["OrderQty"].ToString()) != 0)
                    {
                        try
                        {
                            int temp1 = int.Parse(dt.Rows[i]["OrderQty"].ToString());
                        }
                        catch
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "Please input valied quantity";
                            return false;

                        }
                        try
                        {
                            int temp2 = int.Parse(dt.Rows[i]["ProductID"].ToString());
                        }
                        catch
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "Please input valied product";
                            return false;
                        }

                    }

                }
            }
            else return false;
        }
        return true;
    }

    public MOrder GetUIData(MOrder oMOrder)
    {

        oMOrder.CustomerID = (int)Session["CustID"];
        string sUserType = (string)Session["UserType"];

        if (sUserType == "Customer")
        {
            oMOrder.OrderStatus = "CustomerOrder";
        }
        else if (sUserType == "Area")
        {
            oMOrder.OrderStatus = "AreaOrder";
        }
        else if (sUserType == "National")
        {
            oMOrder.OrderStatus = "NationalOrder";
        }

        if (cmbOutlet.Text != "[New Order]")
        {
            MOrders oMOrders = (MOrders)Session["MOrders"];
            int nOrderID = oMOrders[cboOrders.SelectedIndex].OrderID;
            oMOrder.OrderID = nOrderID;
        }



        if (ViewState["ProductTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["ProductTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox Qty = (TextBox)dvwProduct.Rows[i].Cells[4].FindControl("txtOrderQty");
                    TextBox RevQty = (TextBox)dvwProduct.Rows[i].Cells[5].FindControl("txtRevOrderQty");
                    TextBox NQty = (TextBox)dvwProduct.Rows[i].Cells[6].FindControl("txtNOrderQty");
                    //Qty.Text != "" || 
                    if ((Convert.ToInt32(Qty.Text.ToString()) + Convert.ToInt32(RevQty.Text.ToString()) + Convert.ToInt32(NQty.Text.ToString())) > 0)
                    {
                        MOrderItem oItem = new MOrderItem();

                        TextBox txtProductID = (TextBox)dvwProduct.Rows[i].Cells[6].FindControl("txtProductID");
                        oItem.ProductID = Convert.ToInt32(txtProductID.Text.ToString());

                        try
                        {
                            TextBox txtOrderQty = (TextBox)dvwProduct.Rows[i].Cells[4].FindControl("txtOrderQty");
                            oItem.OrderQty = Convert.ToInt32(txtOrderQty.Text.ToString());
                        }
                        catch
                        {
                            oItem.OrderQty = 0;
                        }
                        try
                        {
                            TextBox txtRevOrderQty = (TextBox)dvwProduct.Rows[i].Cells[5].FindControl("txtRevOrderQty");
                            oItem.RevOrderQty = Convert.ToInt32(txtRevOrderQty.Text.ToString());
                        }
                        catch
                        {
                            oItem.RevOrderQty = 0;
                        }
                        try
                        {
                            TextBox txtNOrderQty = (TextBox)dvwProduct.Rows[i].Cells[6].FindControl("txtNOrderQty");
                            oItem.NOrderQty = Convert.ToInt32(txtNOrderQty.Text.ToString());
                        }
                        catch
                        {
                            oItem.NOrderQty = 0;
                        }
                        oMOrder.Add(oItem);
                    }
                }
            }
        }
        return oMOrder;

    }
    protected void dvwSales_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cmbOutlet_SelectedIndexChanged1(object sender, EventArgs e)
    {
        LoadCustomers();

    }
    protected void dvwProduct_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

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
using System.Text.RegularExpressions;
using CJ.Class.HR;
using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Class.Library;
using CJ.Class.FootFallCust;

public partial class ExchangeOffer_ExchangeOffer : System.Web.UI.Page
{

    JobLocation _oJobLocation;
    JobLocations _oJobLocations;
    ExchangeOffer _oExchangeOffer;
    ExchangeOffer oExchangeOffer;
    ExchangeOffers _oExchangeOffers;
    ExchangeOfferHist _oExchangeOfferHist;
    ExchangeOfferDetail _oExchangeOfferDetail;
    bool IsUpdate = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbHeaderText.Text = "Add Exchange Offer";
            cmbDate.Text = DateTime.Today.Day.ToString();
            cmbMonth.Text = DateTime.Today.Month.ToString();
            cmbYear.Text = DateTime.Today.Year.ToString();
            Combo();
            RefreshProduct();

            IsUpdate = (bool)Session["Update"];

            lblExchangeOfferCode.Visible = false;
            lblExchangeOfferCodetext.Visible = false;

            if (IsUpdate == true)
            {
                lbHeaderText.Text = "Edit Exchange Offer";
                oExchangeOffer = (ExchangeOffer)Session["ExchangeOff"];
                Session.Add("ExchangeOffer", oExchangeOffer);
                lblExchangeOfferCode.Visible = true;
                lblExchangeOfferCodetext.Visible = true;
                lblExchangeOfferCode.Text = "Code No: ";
                lblExchangeOfferCodetext.Text = oExchangeOffer.CodeNo;
                SetUI();
            }


        }

    }
    public void SetUI()
    {
        oExchangeOffer = (ExchangeOffer)Session["ExchangeOff"];

        cmbDate.Text = oExchangeOffer.ContactDate.Day.ToString();
        cmbMonth.Text = oExchangeOffer.ContactDate.Month.ToString();
        cmbYear.Text = oExchangeOffer.ContactDate.Year.ToString();
        if (oExchangeOffer.ContactMode == (int)Dictionary.ExOContactMode.Call)
        {
            rdoCall.Checked = true;
            rdoCall.Checked = false;
        }
        else
        {
            rdoCall.Checked = false;
            rdoCall.Checked = true;
        }

        txtCustomerName.Text = oExchangeOffer.CustomerName;
        txtAddress.Text = oExchangeOffer.Address;
        txtContactNo.Text = oExchangeOffer.ContactNo;
        txtRemarks.Text = oExchangeOffer.Remarks;

        User oUser = (User)Session["User"];

        _oJobLocations = new JobLocations();
        DBController.Instance.OpenNewConnection();
        _oJobLocations.RefreshByPermission(oUser.UserId);
        DBController.Instance.CloseConnection();
        cmbOutlet.SelectedIndex = _oJobLocations.GetIndex(oExchangeOffer.JobLocationID);

        SetPreviousProduct();

    }
    private void SetPreviousProduct()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        DropDownList ddl = null;

        Array a = Enum.GetValues(typeof(Dictionary.ExchangeProduct));

        dt.Columns.Add(new DataColumn("IsCheckProduct", typeof(bool)));
        dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
        dt.Columns.Add(new DataColumn("Qty", typeof(string)));
        dt.Columns.Add(new DataColumn("Size", typeof(string)));
        dt.Columns.Add(new DataColumn("Brand", typeof(string)));
        dt.Columns.Add(new DataColumn("cmbHaveRemote", typeof(string)));
        //ddl..Controls.Add("cmbHaveRemote", typeof(string));
        //DropDownList DDLCondition = (DropDownList)gvwProductDetail.Rows[2].Cells[6].FindControl("cmbCondition");
        dt.Columns.Add(new DataColumn("PID", typeof(string)));



        //ddl.SelectedItem.FindControl.Add(new DataColumn("cmbHaveRemote", typeof(int)));
        //dt.Columns.Add(new DropDownList("cmbHaveRemote", typeof(string)));

        DBController.Instance.OpenNewConnection();

        oExchangeOffer = (ExchangeOffer)Session["ExchangeOff"];

        int cnt = 0;
        for (int i = 0; i < a.Length; i++)
        {
            _oExchangeOfferDetail = new ExchangeOfferDetail();

            _oExchangeOfferDetail.ExchangeOfferID = oExchangeOffer.ExchangeOfferID;
            _oExchangeOfferDetail.DetailID = cnt + i;
            _oExchangeOfferDetail.Type = (int)Dictionary.ExOType.Product;

            dr = dt.NewRow();
            if (_oExchangeOfferDetail.CheckExODetail())
            {
                dr["IsCheckProduct"] = false;
            }
            else
            {
                dr["IsCheckProduct"] = true;
                dr["Qty"] = _oExchangeOfferDetail.Quantity;
                dr["Size"] = _oExchangeOfferDetail.ProductSize;
                dr["Brand"] = _oExchangeOfferDetail.BrandName;

            }
            if (i == (int)Dictionary.ExchangeProduct.CTV)
            {
                dr["ProductName"] = "CTV";
            }
            else if (i == (int)Dictionary.ExchangeProduct.HTV)
            {
                dr["ProductName"] = "HTV";
            }
            else if (i == (int)Dictionary.ExchangeProduct.Refrigerator)
            {
                dr["ProductName"] = "Refrigerator";
            }
            else if (i == (int)Dictionary.ExchangeProduct.Freezer)
            {
                dr["ProductName"] = "Freezer";
            }
            else if (i == (int)Dictionary.ExchangeProduct.AC_Split)
            {
                dr["ProductName"] = "AC_Split";
            }
            else if (i == (int)Dictionary.ExchangeProduct.AC_Window)
            {
                dr["ProductName"] = "AC_Window";
            }

            dr["PID"] = cnt + i;

            dt.Rows.Add(dr);
        }


        DBController.Instance.CloseConnection();

        ViewState["ProductTable"] = dt;
        gvwProductDetail.DataSource = dt;
        gvwProductDetail.DataBind();
        Session.Add("ExchangeOffer", _oExchangeOffers);
    }
    public void Combo()
    {
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();
        _oJobLocations = new JobLocations();
        _oJobLocations.RefreshByPermission(oUser.UserId);
        DBController.Instance.CloseConnection();
        if (_oJobLocations.Count > 0)
        {
            cmbOutlet.DataSource = _oJobLocations;
            cmbOutlet.DataTextField = "JobLocationName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("ExchangeOffers", _oJobLocation);
        }
        else
        {
            _oJobLocation = new JobLocation();
            _oJobLocation.JobLocationName = "No Permission";
            _oJobLocations.Add(_oJobLocation);

            cmbOutlet.DataSource = _oJobLocations;
            cmbOutlet.DataTextField = "JobLocationName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("ExchangeOffers", _oJobLocation);
        }

    }
    protected void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void rdoCall_CheckedChanged(object sender, EventArgs e)
    {
        rdoCall.Checked = true;
        rdoWalkin.Checked = false;
    }
    protected void rdoIn_CheckedChanged(object sender, EventArgs e)
    {
        rdoCall.Checked = false;
        rdoWalkin.Checked = true;
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        Save();
    }
    private bool validateUIInput()
    {
        int ChkCount = 0;

        if (cmbOutlet.Text == "No Permission")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have no permission any outlet";
            return false;
        }
        if (txtCustomerName.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Customer Name";
            return false;
        }
        if (txtAddress.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Customer Address";
            return false;
        }
        if (txtContactNo.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Contact No";
            return false;
        }

        DataTable dt = (DataTable)ViewState["ProductTable"];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvwProductDetail.Rows[i].Cells[0].FindControl("chkProduct");
                if (chk.Checked)
                {
                    ChkCount = ChkCount + 1;
                }
            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "There is no Data";
            return false;
        }
        if (ChkCount == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have to checked a Product";
            return false;
        }
       
        DataTable dtQty = (DataTable)ViewState["ProductTable"];
        if (dtQty.Rows.Count > 0)
        {
            for (int i = 0; i < dtQty.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvwProductDetail.Rows[i].Cells[0].FindControl("chkProduct");
                if (chk.Checked)
                {
                    TextBox txtQty = (TextBox)gvwProductDetail.Rows[i].Cells[2].FindControl("txtQty");
                    Regex rgCell = new Regex("[0-9]");
                    if (rgCell.IsMatch(txtQty.Text))
                    {

                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please enter valid quantity";
                        return false;
                    }

                }
            }
        }
        DataTable dtSize = (DataTable)ViewState["ProductTable"];
        if (dtSize.Rows.Count > 0)
        {
            for (int i = 0; i < dtSize.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvwProductDetail.Rows[i].Cells[0].FindControl("chkProduct");
                if (chk.Checked)
                {
                    TextBox txtSize = (TextBox)gvwProductDetail.Rows[i].Cells[3].FindControl("txtSize");

                    if (txtSize.Text=="")
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please enter Product Size";
                        return false;
                    }

                }
            }
        }
        DataTable dtBrand = (DataTable)ViewState["ProductTable"];
        if (dtBrand.Rows.Count > 0)
        {
            for (int i = 0; i < dtBrand.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvwProductDetail.Rows[i].Cells[0].FindControl("chkProduct");
                if (chk.Checked)
                {
                    TextBox txtBrand = (TextBox)gvwProductDetail.Rows[i].Cells[4].FindControl("txtBrand");

                    if (txtBrand.Text == "")
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please enter Brand Name";
                        return false;
                    }

                }
            }
        }
        DataTable dtRemote = (DataTable)ViewState["ProductTable"];
        if (dtRemote.Rows.Count > 0)
        {
            for (int i = 0; i < dtRemote.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvwProductDetail.Rows[i].Cells[0].FindControl("chkProduct");
                if (chk.Checked)
                {

                    DropDownList DDLRemote = (DropDownList)gvwProductDetail.Rows[i].Cells[5].FindControl("cmbHaveRemote");

                    if (DDLRemote.Text == "10")
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please Select 'Have Remote' column";
                        return false;
                    }

                }
            }
        }
        DataTable dtCondition = (DataTable)ViewState["ProductTable"];
        if (dtCondition.Rows.Count > 0)
        {
            for (int i = 0; i < dtCondition.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvwProductDetail.Rows[i].Cells[0].FindControl("chkProduct");
                if (chk.Checked)
                {
                    DropDownList DDLCondition = (DropDownList)gvwProductDetail.Rows[i].Cells[6].FindControl("cmbCondition");

                    if (DDLCondition.Text == "11")
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Please Select Product Condition";
                        return false;
                    }

                }
            }
        }


        return true;
    }
    private void Save()
    {
        lblMessage.Visible = false;

        User oUser = (User)Session["User"];
        Customer oCustomer = (Customer)Session["Customer"];
        IsUpdate = (bool)Session["Update"];
        if (IsUpdate == false)
        {
            if (validateUIInput())
            {
                DBController.Instance.OpenNewConnection();
                oCustomer = new Customer();
                oCustomer.GetCustomerForDCS(oUser.UserId);

                _oExchangeOffer = new ExchangeOffer();
                _oExchangeOfferHist = new ExchangeOfferHist();

                _oExchangeOffer.ContactDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmbDate.SelectedValue));

                if (rdoCall.Checked == true)
                {
                    _oExchangeOffer.ContactMode = (int)Dictionary.ExOContactMode.Call;
                }
                else
                {
                    _oExchangeOffer.ContactMode = (int)Dictionary.ExOContactMode.Walkin;
                }
                _oJobLocations = new JobLocations();
                _oJobLocations.RefreshByPermission(oUser.UserId);

                _oExchangeOffer.JobLocationID = _oJobLocations[cmbOutlet.SelectedIndex].JobLocationID;
                _oExchangeOffer.CustomerName = txtCustomerName.Text;
                _oExchangeOffer.Address = txtAddress.Text;
                _oExchangeOffer.ContactNo = txtContactNo.Text;
                _oExchangeOffer.Remarks = txtRemarks.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oExchangeOffer.Add();

                    _oExchangeOfferHist.ExchangeOfferID = _oExchangeOffer.ExchangeOfferID;
                    _oExchangeOfferHist.Status = (int)Dictionary.ExchangeOfferStatus.Create;
                    _oExchangeOfferHist.Remarks = _oExchangeOffer.Remarks;

                    _oExchangeOfferHist.Add();

                    DataTable rdt = (DataTable)ViewState["ProductTable"];
                    if (rdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < rdt.Rows.Count; i++)
                        {
                            CheckBox chk = (CheckBox)gvwProductDetail.Rows[i].Cells[0].FindControl("chkProduct");
                            if (chk.Checked)
                            {
                                _oExchangeOfferDetail = new ExchangeOfferDetail();

                                Label lblProductID = (Label)gvwProductDetail.Rows[i].Cells[7].FindControl("txtPID");
                                TextBox txtQty = (TextBox)gvwProductDetail.Rows[i].Cells[2].FindControl("txtQty");
                                TextBox txtSize = (TextBox)gvwProductDetail.Rows[i].Cells[3].FindControl("txtSize");
                                TextBox txtBrand = (TextBox)gvwProductDetail.Rows[i].Cells[4].FindControl("txtBrand");
                                DropDownList DDLRemote = (DropDownList)gvwProductDetail.Rows[i].Cells[5].FindControl("cmbHaveRemote");
                                DropDownList DDLCondition = (DropDownList)gvwProductDetail.Rows[i].Cells[6].FindControl("cmbCondition");


                                _oExchangeOfferDetail.ExchangeOfferID = _oExchangeOffer.ExchangeOfferID;
                                _oExchangeOfferDetail.Type = (int)Dictionary.ExOType.Product;
                                _oExchangeOfferDetail.DetailID = Convert.ToInt32(lblProductID.Text.ToString());
                                _oExchangeOfferDetail.Quantity = Convert.ToInt32(txtQty.Text.ToString());
                                _oExchangeOfferDetail.ProductSize = txtSize.Text;
                                _oExchangeOfferDetail.BrandName = txtBrand.Text;
                                _oExchangeOfferDetail.HaveRemortCtrl = Convert.ToInt32(DDLRemote.Text.ToString());
                                _oExchangeOfferDetail.ProductCondition = Convert.ToInt32(DDLCondition.Text.ToString());

                                _oExchangeOfferDetail.Add();
                            }

                        }
                    }
                    DBController.Instance.CommitTransaction();
                    string[] sSuccedCode =  { " " };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Save", "The Exchange Offer", sSuccedCode, null, "ExchangeOffer/frmExchangeOffers.aspx", 0);
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
        else
        {
            if (validateUIInput())
            {
                DBController.Instance.OpenNewConnection();
                oCustomer = new Customer();
                oCustomer.GetCustomerForDCS(oUser.UserId);

                oExchangeOffer = (ExchangeOffer)Session["ExchangeOff"];

                _oExchangeOffer = new ExchangeOffer();
                _oExchangeOfferHist = new ExchangeOfferHist();

                _oExchangeOffer.ContactDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmbDate.SelectedValue));

                if (rdoCall.Checked == true)
                {
                    _oExchangeOffer.ContactMode = (int)Dictionary.ExOContactMode.Call;
                }
                else
                {
                    _oExchangeOffer.ContactMode = (int)Dictionary.ExOContactMode.Walkin;
                }
                _oJobLocations = new JobLocations();
                _oJobLocations.RefreshByPermission(oUser.UserId);
                _oExchangeOffer.ExchangeOfferID = oExchangeOffer.ExchangeOfferID;
                _oExchangeOffer.JobLocationID = _oJobLocations[cmbOutlet.SelectedIndex].JobLocationID;
                _oExchangeOffer.CustomerName = txtCustomerName.Text;
                _oExchangeOffer.Address = txtAddress.Text;
                _oExchangeOffer.ContactNo = txtContactNo.Text;
                _oExchangeOffer.Remarks = txtRemarks.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oExchangeOffer.Edit();

                    _oExchangeOfferHist.ExchangeOfferID = _oExchangeOffer.ExchangeOfferID;
                    _oExchangeOfferHist.Status = (int)Dictionary.ExchangeOfferStatus.Create;
                    _oExchangeOfferHist.Remarks = _oExchangeOffer.Remarks;

                    _oExchangeOfferHist.UpdateRemarks();

                    _oExchangeOfferDetail = new ExchangeOfferDetail();
                    _oExchangeOfferDetail.ExchangeOfferID = _oExchangeOffer.ExchangeOfferID;
                    _oExchangeOfferDetail.Type = (int)Dictionary.ExOType.Product;

                    _oExchangeOfferDetail.Delete();

                    DataTable rdt = (DataTable)ViewState["ProductTable"];
                    if (rdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < rdt.Rows.Count; i++)
                        {
                            CheckBox chk = (CheckBox)gvwProductDetail.Rows[i].Cells[0].FindControl("chkProduct");
                            if (chk.Checked)
                            {
                                _oExchangeOfferDetail = new ExchangeOfferDetail();

                                Label lblProductID = (Label)gvwProductDetail.Rows[i].Cells[7].FindControl("txtPID");
                                TextBox txtQty = (TextBox)gvwProductDetail.Rows[i].Cells[2].FindControl("txtQty");
                                TextBox txtSize = (TextBox)gvwProductDetail.Rows[i].Cells[3].FindControl("txtSize");
                                TextBox txtBrand = (TextBox)gvwProductDetail.Rows[i].Cells[4].FindControl("txtBrand");
                                DropDownList DDLRemote = (DropDownList)gvwProductDetail.Rows[i].Cells[5].FindControl("cmbHaveRemote");
                                DropDownList DDLCondition = (DropDownList)gvwProductDetail.Rows[i].Cells[6].FindControl("cmbCondition");


                                _oExchangeOfferDetail.ExchangeOfferID = _oExchangeOffer.ExchangeOfferID;
                                _oExchangeOfferDetail.Type = (int)Dictionary.ExOType.Product;
                                _oExchangeOfferDetail.DetailID = Convert.ToInt32(lblProductID.Text.ToString());
                                _oExchangeOfferDetail.Quantity = Convert.ToInt32(txtQty.Text.ToString());
                                _oExchangeOfferDetail.ProductSize = txtSize.Text;
                                _oExchangeOfferDetail.BrandName = txtBrand.Text;
                                _oExchangeOfferDetail.HaveRemortCtrl = Convert.ToInt32(DDLRemote.Text.ToString());
                                _oExchangeOfferDetail.ProductCondition = Convert.ToInt32(DDLCondition.Text.ToString());


                                _oExchangeOfferDetail.Add();
                            }

                        }
                    }
                    DBController.Instance.CommitTransaction();
                    string[] sSuccedCode =  { " " };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Save", "The Exchange Offer", sSuccedCode, null, "ExchangeOffer/frmExchangeOffers.aspx", 0);
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
    }
    private void RefreshProduct()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        Array a = Enum.GetValues(typeof(Dictionary.ExchangeProduct));

        dt.Columns.Add(new DataColumn("IsCheckProduct", typeof(bool)));
        dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
        dt.Columns.Add(new DataColumn("Qty", typeof(string)));
        dt.Columns.Add(new DataColumn("Size", typeof(string)));
        dt.Columns.Add(new DataColumn("Brand", typeof(string)));
        dt.Columns.Add(new DataColumn("PID", typeof(string)));


        DBController.Instance.OpenNewConnection();

        int cnt = 0;
        for (int i = 0; i < a.Length; i++)
        {
            dr = dt.NewRow();
            dr["IsCheckProduct"] = false;

            if (i == (int)Dictionary.ExchangeProduct.CTV)
            {
                dr["ProductName"] = "CTV";
            }
            else if (i == (int)Dictionary.ExchangeProduct.HTV)
            {
                dr["ProductName"] = "HTV";
            }
            else if (i == (int)Dictionary.ExchangeProduct.Refrigerator)
            {
                dr["ProductName"] = "Refrigerator";
            }
            else if (i == (int)Dictionary.ExchangeProduct.Freezer)
            {
                dr["ProductName"] = "Freezer";
            }
            else if (i == (int)Dictionary.ExchangeProduct.AC_Split)
            {
                dr["ProductName"] = "AC_Split";
            }
            else if (i == (int)Dictionary.ExchangeProduct.AC_Window)
            {
                dr["ProductName"] = "AC_Window";
            }
            dr["PID"] = cnt + i;

            dt.Rows.Add(dr);
        }

        DBController.Instance.CloseConnection();

        ViewState["ProductTable"] = dt;
        gvwProductDetail.DataSource = dt;
        gvwProductDetail.DataBind();
        Session.Add("ExchangeOffer", _oExchangeOffers);
    }
}

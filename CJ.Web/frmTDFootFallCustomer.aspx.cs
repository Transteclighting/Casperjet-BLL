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
using System.Drawing;

using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Class.Library;
using CJ.Class.FootFallCust;


public partial class frmFootFallCustomer : System.Web.UI.Page
{

    FootFallCustomer oFootFallCustomer;
    FootFallCustomerDetail oFootFallCustomerDetail;
    public ProductDetail oProductDetail;
    FootFallBrands _oFootFallBrands;
    FootFallFollowup _oFootFallFollowup;

    Customer oCustomer;
    Customers oCustomers;
    bool IsUpdate = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbHeaderText.Text = "Add Foot Fall";
            cmbDate.Text = DateTime.Today.Day.ToString();
            cmbMonth.Text = DateTime.Today.Month.ToString();
            cmbYear.Text = DateTime.Today.Year.ToString();
            
            //cboFollowUpDay.Text = DateTime.Today.Day.ToString();
            cboFollowupMonth.Text = DateTime.Today.Month.ToString();
            cboFollowupYear.Text = DateTime.Today.Year.ToString();

            Combo();
            RefreshBrand();
            RefreshReason();

            IsUpdate = (bool)Session["Update"];
            lblFootFallCode.Visible = false;
            lblFootFallCodetext.Visible = false;
            if (IsUpdate == true)
            {
                lbHeaderText.Text = "Edit Foot Fall";
                oFootFallCustomer = (FootFallCustomer)Session["FootFallCustomer"];
                Session.Add("FootFallCustomer", oFootFallCustomer);
                lblFootFallCode.Visible = true;
                lblFootFallCodetext.Visible = true;
                lblFootFallCode.Text = "Foot Fall Code: ";
                lblFootFallCodetext.Text = oFootFallCustomer.FootFallCode;
                SetUI();
            }
            

        }
    }
    public void SetUI()
    {
        oFootFallCustomer = (FootFallCustomer)Session["FootFallCustomer"];

        cmbDate.Text = oFootFallCustomer.FootFallDate.Day.ToString();
        cmbMonth.Text = oFootFallCustomer.FootFallDate.Month.ToString();
        cmbYear.Text = oFootFallCustomer.FootFallDate.Year.ToString();
      


        if (oFootFallCustomer.IsDisclosed == (int)Dictionary.FootFallIsDisclosed.Yes)
        {
            //rdoYes.Checked = true;
            //rdoNo.Checked = false;

            txtContactNo.Enabled = true;
            txtContactNo.BackColor = Color.White;
            txtFootFallCustName.Enabled = true;
            txtFootFallCustName.BackColor = Color.White;
            txtEmail.Enabled = true;
            txtEmail.BackColor = Color.White;
        }
        else
        {
            //rdoNo.Checked = true;
            //rdoYes.Checked = false;

            txtContactNo.Enabled = false;
            txtContactNo.BackColor = Color.LightGray;
            txtFootFallCustName.Enabled = false;
            txtFootFallCustName.BackColor = Color.LightGray;
            txtEmail.Enabled = false;
            txtEmail.BackColor = Color.LightGray;
        }
        cmbCustomerType.SelectedIndex = oFootFallCustomer.FootFallCustType;
        txtFootFallCustName.Text = oFootFallCustomer.Name;
        txtContactNo.Text = oFootFallCustomer.ContactNo;
        txtEmail.Text = oFootFallCustomer.Email;
        txtSpecificModel.Text = oFootFallCustomer.SpecificProduct;
        txtSalesPerson.Text = oFootFallCustomer.SalesPerson;
        cmbContactMode.SelectedIndex = oFootFallCustomer.ContactMode;
        txtRemarks.Text = oFootFallCustomer.Remarks;
        cboFollowUpDay.Text = oFootFallCustomer.FollowupDate.Day.ToString();
        cboFollowupMonth.Text = oFootFallCustomer.FollowupDate.Month.ToString();
        cboFollowupYear.Text = oFootFallCustomer.FollowupDate.Year.ToString();
        _oFootFallBrands = new FootFallBrands();
        DBController.Instance.OpenNewConnection();
        _oFootFallBrands.RefreshForCombo(false);
        DBController.Instance.CloseConnection();
        cmbASG.SelectedIndex = _oFootFallBrands.GetIndex(oFootFallCustomer.ASGID);

        SetPreviousBrand();
        SetPreviousReason();

    }
    public void Combo()
    {
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();
        oCustomers = new Customers();
        oCustomers.RefreshPermissionForFootFall(oUser.UserId);
        DBController.Instance.CloseConnection();
        if (oCustomers.Count > 0)
        {
            cmbOutlet.DataSource = oCustomers;
            cmbOutlet.DataTextField = "CustomerName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("FootFall", oCustomer);
        }
        else
        {
            oCustomer = new Customer();
            oCustomer.CustomerName = "No Permission";
            oCustomers.Add(oCustomer);

            cmbOutlet.DataSource = oCustomers;
            cmbOutlet.DataTextField = "CustomerName";
            cmbOutlet.DataBind();
            cmbOutlet.SelectedIndex = 0;
            Session.Add("FootFall", oCustomer);
        }

        //ASG

        _oFootFallBrands = new FootFallBrands();
        DBController.Instance.OpenNewConnection();
        _oFootFallBrands.RefreshForCombo(false);
        DBController.Instance.CloseConnection();

        cmbASG.DataSource = _oFootFallBrands;
        cmbASG.DataTextField = "ASGName";
        cmbASG.DataBind();
        cmbASG.SelectedIndex = 0;
        Session.Add("ASG", _oFootFallBrands);

        //CustomerType

        
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.FootFallCustType)))
        {
          cmbCustomerType.Items.Add(Enum.GetName(typeof(Dictionary.FootFallCustType), GetEnum));
        }
        cmbCustomerType.SelectedIndex = 0;

        //ContactMode
        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.FootFallModeofFollowup)))
        {
            cmbContactMode.Items.Add(Enum.GetName(typeof(Dictionary.FootFallModeofFollowup), GetEnum));
        }
        cmbContactMode.SelectedIndex = 0;
    }  

    protected void btSave_Click(object sender, EventArgs e)
    {
        Save();
    }

    private void RefreshBrand()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("IsCheckBrand", typeof(bool)));
        dt.Columns.Add(new DataColumn("FootFallBrand", typeof(string)));
        dt.Columns.Add(new DataColumn("ID", typeof(string)));


        DBController.Instance.OpenNewConnection();

        if (IsPostBack)
        {
            _oFootFallBrands = new FootFallBrands();
        }

        _oFootFallBrands.Refresh(_oFootFallBrands[cmbASG.SelectedIndex].ASGID);

        foreach (FootFallBrand oFootFallBrand in _oFootFallBrands)
        {

            dr = dt.NewRow();

            dr["IsCheckBrand"] = false;
            dr["FootFallBrand"] = oFootFallBrand.FootFallBrandName.ToString();
            dr["ID"] = oFootFallBrand.ID.ToString();

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["BrandTable"] = dt;
        dvwBrand.DataSource = dt;
        dvwBrand.DataBind();
        Session.Add("FootFall", _oFootFallBrands);
    }
    private void SetPreviousBrand()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("IsCheckBrand", typeof(bool)));
        dt.Columns.Add(new DataColumn("FootFallBrand", typeof(string)));
        dt.Columns.Add(new DataColumn("ID", typeof(string)));


        DBController.Instance.OpenNewConnection();


        oFootFallCustomer = (FootFallCustomer)Session["FootFallCustomer"];

        _oFootFallBrands.Refresh(oFootFallCustomer.ASGID);

        foreach (FootFallBrand oFootFallBrand in _oFootFallBrands)
        {
            oFootFallCustomerDetail = new FootFallCustomerDetail();
            oFootFallCustomerDetail.FootFallID = oFootFallCustomer.FootFallID;
            oFootFallCustomerDetail.Type = (int)Dictionary.FootFallDetailType.Brand;
            oFootFallCustomerDetail.ID = oFootFallBrand.ID;

            dr = dt.NewRow();
            if(oFootFallCustomerDetail.CheckFFDetail())                 
            {
                dr["IsCheckBrand"] = false;
            }
            else
            {
                dr["IsCheckBrand"] = true;
            }
            dr["FootFallBrand"] = oFootFallBrand.FootFallBrandName.ToString();
            dr["ID"] = oFootFallBrand.ID.ToString();

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["BrandTable"] = dt;
        dvwBrand.DataSource = dt;
        dvwBrand.DataBind();
        Session.Add("FootFall", _oFootFallBrands);
    }
    private void SetPreviousReason()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        Array a = Enum.GetValues(typeof(Dictionary.FootFallReason));

        dt.Columns.Add(new DataColumn("IsCheckReason", typeof(bool)));
        dt.Columns.Add(new DataColumn("Reason", typeof(string)));
        dt.Columns.Add(new DataColumn("RID", typeof(string)));
        dt.Columns.Add(new DataColumn("ReasonDetail", typeof(string)));

        DBController.Instance.OpenNewConnection();

        oFootFallCustomer = (FootFallCustomer)Session["FootFallCustomer"];

        int cnt = 0;
        for (int i = 0; i < a.Length; i++)
        {
            oFootFallCustomerDetail = new FootFallCustomerDetail();
            oFootFallCustomerDetail.FootFallID = oFootFallCustomer.FootFallID;
            oFootFallCustomerDetail.Type = (int)Dictionary.FootFallDetailType.Reason;
            //oFootFallCustomerDetail.ReasonDetail = oFootFallCustomerDetail.ReasonDetail;
            oFootFallCustomerDetail.ID = cnt + i;

            dr = dt.NewRow();
            if (oFootFallCustomerDetail.CheckFFDetail())
            {
                dr["IsCheckReason"] = false;
            }
            else
            {
                dr["IsCheckReason"] = true;
                dr["ReasonDetail"] = oFootFallCustomerDetail.ReasonDetail;
            }
            if (i == (int)Dictionary.FootFallReason.Stock_Unavailable)
            {
                dr["Reason"] = "Stock unavailable";
            }
            else if (i == (int)Dictionary.FootFallReason.KISTI_Installment)
            {
                dr["Reason"] = "KISTI (Installment)";
            }
            else if (i == (int)Dictionary.FootFallReason.Instabuy_on_CreditCard)
            {
                dr["Reason"] = "InstaBuy on credit card";
            }
            else if (i == (int)Dictionary.FootFallReason.Lack_of_feature)
            {
                dr["Reason"] = "Lack of feature";
            }
            else if (i == (int)Dictionary.FootFallReason.Price_Factor)
            {
                dr["Reason"] = "Price factor";
            }
            else if (i == (int)Dictionary.FootFallReason.Visit_Again)
            {
                dr["Reason"] = "Visit again";
            }
            else if (i == (int)Dictionary.FootFallReason.Choice_Other_Brand)
            {
                dr["Reason"] = "Choice Other Brand";
            }
            else if (i == (int)Dictionary.FootFallReason.Others)
            {
                dr["Reason"] = "Others";
            }
            dr["RID"] = cnt + i;

            dt.Rows.Add(dr);
        }

        DBController.Instance.CloseConnection();

        ViewState["ReasonTable"] = dt;
        gvwReason.DataSource = dt;
        gvwReason.DataBind();
        Session.Add("FootFall", _oFootFallBrands);
    }
    private void RefreshReason()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        Array a = Enum.GetValues(typeof(Dictionary.FootFallReason));

        dt.Columns.Add(new DataColumn("IsCheckReason", typeof(bool)));
        dt.Columns.Add(new DataColumn("Reason", typeof(string)));
        dt.Columns.Add(new DataColumn("RID", typeof(string)));
        dt.Columns.Add(new DataColumn("ReasonDetail", typeof(string)));


        DBController.Instance.OpenNewConnection();

        int cnt = 0;
        for (int i = 0; i < a.Length; i++)
        {
            dr = dt.NewRow();
            dr["IsCheckReason"] = false;

            if (i == (int)Dictionary.FootFallReason.Stock_Unavailable)
            {
                dr["Reason"] = "Stock unavailable";
            }
            else if (i == (int)Dictionary.FootFallReason.KISTI_Installment)
            {
                dr["Reason"] = "KISTI (Installment)";
            }
            else if (i == (int)Dictionary.FootFallReason.Instabuy_on_CreditCard)
            {
                dr["Reason"] = "InstaBuy on credit card";
            }
            else if (i == (int)Dictionary.FootFallReason.Lack_of_feature)
            {
                dr["Reason"] = "Lack of feature";
            }
            else if (i == (int)Dictionary.FootFallReason.Price_Factor)
            {
                dr["Reason"] = "Price factor";
            }
            else if (i == (int)Dictionary.FootFallReason.Visit_Again)
            {
                dr["Reason"] = "Visit again";
            }
            else if (i == (int)Dictionary.FootFallReason.Choice_Other_Brand)
            {
                dr["Reason"] = "Choice Other Brand";
            }
            else if (i == (int)Dictionary.FootFallReason.Others)
            {
                dr["Reason"] = "Others";
            }
            
            dr["RID"] = cnt + i;

            dt.Rows.Add(dr);
        }

        DBController.Instance.CloseConnection();

        ViewState["ReasonTable"] = dt;
        gvwReason.DataSource = dt;
        gvwReason.DataBind();
        Session.Add("FootFall", _oFootFallBrands);
    }
    private bool validateUIInput()
    {

        if (cmbOutlet.Text == "No Permission")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have no permission any outlet";
            return false;
        }
        //if (rdoYes.Checked == true)
        //{
            if (txtFootFallCustName.Text.Trim() == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input Name";
                return false;
            }
            if (txtContactNo.Text.Trim() == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input Contact No";
                return false;
            }
        //}
            if (txtSalesPerson.Text.Trim() == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input Sales person";
                return false;
            }
            if (cboFollowUpDay.Text == "0")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input Next Follow up Date";
                return false;
            }


        int CountBrand = 0;
        int CountReason = 0;

        DataTable dt = (DataTable)ViewState["BrandTable"];
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)dvwBrand.Rows[i].Cells[0].FindControl("chkBrand");
                if (chk.Checked)
                {
                    CountBrand = CountBrand + 1;
                }

            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "There is no Brand";
            return false;
        }
        if (CountBrand==0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have to Checked at least a Brand";
            return false;
        }

        DataTable rdt = (DataTable)ViewState["ReasonTable"];
        if (rdt.Rows.Count > 0)
        {
            for (int i = 0; i < rdt.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvwReason.Rows[i].Cells[0].FindControl("chkReason");
                if (chk.Checked)
                {
                    CountReason = CountReason + 1;
                }

            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "There is no Reason";
            return false;
        }
        if (CountReason == 0)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have to Checked at least a Reason";
            return false;
        }

        return true;
    }

    private void Save()
    {
        lblMessage.Visible = false;

        User oUser = (User)Session["User"];
        Customer oCustomer = (Customer)Session["Customer"];
        FootFallBrands _oFootFallBrands = (FootFallBrands)Session["ASG"];
        IsUpdate = (bool)Session["Update"];
        if (IsUpdate == false)
        {
            if (validateUIInput())
            {
                DBController.Instance.OpenNewConnection();
                oCustomer = new Customer();
                oCustomer.GetCustomerForDCS(oUser.UserId);
                FootFallCustomer oFootFallCustomer = new FootFallCustomer();

                oCustomers = new Customers();
                oCustomers.RefreshPermissionForFootFall(oUser.UserId);

                oFootFallCustomer.ShowroomID = oCustomers[cmbOutlet.SelectedIndex].CustomerID;
                oFootFallCustomer.FootFallDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmbDate.SelectedValue));

                //if (rdoYes.Checked == true)
                //{
                oFootFallCustomer.FootFallCustType = cmbCustomerType.SelectedIndex;
                oFootFallCustomer.Name = txtFootFallCustName.Text;
                oFootFallCustomer.ContactNo = txtContactNo.Text;
                oFootFallCustomer.Email = txtEmail.Text;
                oFootFallCustomer.IsDisclosed = (int)Dictionary.FootFallIsDisclosed.Yes;
                oFootFallCustomer.FollowupDate = new DateTime(Convert.ToInt32(cboFollowupYear.SelectedValue), Convert.ToInt32(cboFollowupMonth.SelectedValue), Convert.ToInt32(cboFollowUpDay.SelectedValue));

                //}
                //else
                //{
                //    oFootFallCustomer.Name = null;
                //    oFootFallCustomer.ContactNo = null;
                //    oFootFallCustomer.Email = null;
                //    oFootFallCustomer.IsDisclosed = (int)Dictionary.FootFallIsDisclosed.No;
                //}
                oFootFallCustomer.SpecificProduct = txtSpecificModel.Text;
                oFootFallCustomer.SalesPerson = txtSalesPerson.Text;
                oFootFallCustomer.ContactMode = cmbContactMode.SelectedIndex;
                oFootFallCustomer.Remarks = txtRemarks.Text;


                _oFootFallBrands = new FootFallBrands();
                _oFootFallBrands.RefreshForCombo(false);

                oFootFallCustomer.ASGID = _oFootFallBrands[cmbASG.SelectedIndex].ASGID;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oFootFallCustomer.Add();

                    _oFootFallFollowup = new FootFallFollowup();
                    _oFootFallFollowup.FootFallID = oFootFallCustomer.FootFallID;
                    _oFootFallFollowup.ContactDate = DateTime.Today.Date;
                    _oFootFallFollowup.FollowupDate = oFootFallCustomer.FollowupDate;
                    _oFootFallFollowup.ContactMode = cmbContactMode.SelectedIndex;
                    _oFootFallFollowup.Remarks = oFootFallCustomer.Remarks;
                    _oFootFallFollowup.IsContacted = (int)Dictionary.FootFallIsContacted.False;

                    _oFootFallFollowup.Add(true);

                    DataTable dt = (DataTable)ViewState["BrandTable"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            CheckBox chk = (CheckBox)dvwBrand.Rows[i].Cells[0].FindControl("chkBrand");
                            if (chk.Checked)
                            {
                                oFootFallCustomerDetail = new FootFallCustomerDetail();
                                Label lblBrandID = (Label)dvwBrand.Rows[i].Cells[2].FindControl("txtID");
                                oFootFallCustomerDetail.FootFallID = oFootFallCustomer.FootFallID;
                                oFootFallCustomerDetail.Type = (int)Dictionary.FootFallDetailType.Brand;
                                oFootFallCustomerDetail.ID = Convert.ToInt32(lblBrandID.Text.ToString());
                                oFootFallCustomerDetail.ReasonDetail = "";
                                oFootFallCustomerDetail.Add();
                            }

                        }
                    }
                    DataTable rdt = (DataTable)ViewState["ReasonTable"];
                    if (rdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < rdt.Rows.Count; i++)
                        {
                            CheckBox chk = (CheckBox)gvwReason.Rows[i].Cells[0].FindControl("chkReason");
                            if (chk.Checked)
                            {
                                oFootFallCustomerDetail = new FootFallCustomerDetail();
                                Label lblReasonID = (Label)gvwReason.Rows[i].Cells[3].FindControl("txtRID");
                                TextBox txtReasonDet = (TextBox)gvwReason.Rows[i].Cells[2].FindControl("txtReasonDetail");
                                oFootFallCustomerDetail.FootFallID = oFootFallCustomer.FootFallID;
                                oFootFallCustomerDetail.Type = (int)Dictionary.FootFallDetailType.Reason;
                                oFootFallCustomerDetail.ID = Convert.ToInt32(lblReasonID.Text.ToString());
                                oFootFallCustomerDetail.ReasonDetail = txtReasonDet.Text.ToString();
                                oFootFallCustomerDetail.Add();
                            }

                        }
                    }
                    DBController.Instance.CommitTransaction();
                    string[] sSuccedCode =  { " " };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Save", "The Foot Fall", sSuccedCode, null, "frmTDFootFallCustomers.aspx", 0);
                    Response.Redirect("frmMessage.aspx");

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
                oFootFallCustomer = (FootFallCustomer)Session["FootFallCustomer"];


                cmbOutlet.Enabled = false;

                oFootFallCustomer.FootFallID = oFootFallCustomer.FootFallID;
                oFootFallCustomer.FootFallDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmbDate.SelectedValue));
                oFootFallCustomer.FollowupDate = new DateTime(Convert.ToInt32(cboFollowupYear.SelectedValue), Convert.ToInt32(cboFollowupMonth.SelectedValue), Convert.ToInt32(cboFollowUpDay.SelectedValue));

                //if (rdoYes.Checked == true)
                //{
                oFootFallCustomer.FootFallCustType = cmbCustomerType.SelectedIndex;
                    oFootFallCustomer.Name = txtFootFallCustName.Text;
                    oFootFallCustomer.ContactNo = txtContactNo.Text;
                    oFootFallCustomer.Email = txtEmail.Text;
                    oFootFallCustomer.IsDisclosed = (int)Dictionary.FootFallIsDisclosed.Yes;
                //}
                //else
                //{
                //    oFootFallCustomer.Name = null;
                //    oFootFallCustomer.ContactNo = null;
                //    oFootFallCustomer.Email = null;
                //    oFootFallCustomer.IsDisclosed = (int)Dictionary.FootFallIsDisclosed.No;
                //}
                oFootFallCustomer.SpecificProduct = txtSpecificModel.Text;
                oFootFallCustomer.SalesPerson = txtSalesPerson.Text;
                oFootFallCustomer.ContactMode = cmbContactMode.SelectedIndex;
                oFootFallCustomer.Remarks = txtRemarks.Text;

                _oFootFallBrands = new FootFallBrands();
                _oFootFallBrands.RefreshForCombo(false);
                oFootFallCustomer.ASGID = _oFootFallBrands[cmbASG.SelectedIndex].ASGID;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oFootFallCustomer.Edit();

                    _oFootFallFollowup = new FootFallFollowup();
                    _oFootFallFollowup.FootFallID = oFootFallCustomer.FootFallID;
                    _oFootFallFollowup.ContactDate = DateTime.Today.Date;
                    _oFootFallFollowup.FollowupDate = oFootFallCustomer.FollowupDate;
                    _oFootFallFollowup.ContactMode = cmbContactMode.SelectedIndex;
                    _oFootFallFollowup.Remarks = oFootFallCustomer.Remarks;
                    _oFootFallFollowup.IsContacted = (int)Dictionary.FootFallIsContacted.False;
                    _oFootFallFollowup.RefreshByFFIDNDate();
                    DateTime dNullfieldvalue = Convert.ToDateTime("16 - Dec - 1971");
                    if (_oFootFallFollowup.FollowupDateNull != dNullfieldvalue)
                    {

                    }
                    else
                    {
                        oFootFallCustomer.EditFollowUpDate();
                        _oFootFallFollowup.Add(true);
                    }
                    
                    oFootFallCustomer.DeleteFootFallDetail();
                    DataTable dt = (DataTable)ViewState["BrandTable"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            CheckBox chk = (CheckBox)dvwBrand.Rows[i].Cells[0].FindControl("chkBrand");
                            if (chk.Checked)
                            {
                                oFootFallCustomerDetail = new FootFallCustomerDetail();
                                Label lblBrandID = (Label)dvwBrand.Rows[i].Cells[2].FindControl("txtID");
                                oFootFallCustomerDetail.FootFallID = oFootFallCustomer.FootFallID;
                                oFootFallCustomerDetail.Type = (int)Dictionary.FootFallDetailType.Brand;
                                oFootFallCustomerDetail.ID = Convert.ToInt32(lblBrandID.Text.ToString());
                                oFootFallCustomerDetail.ReasonDetail = "";
                                oFootFallCustomerDetail.Add();
                            }

                        }
                    }
                    DataTable rdt = (DataTable)ViewState["ReasonTable"];
                    if (rdt.Rows.Count > 0)
                    {
                        for (int i = 0; i < rdt.Rows.Count; i++)
                        {
                            CheckBox chk = (CheckBox)gvwReason.Rows[i].Cells[0].FindControl("chkReason");
                            if (chk.Checked)
                            {
                                oFootFallCustomerDetail = new FootFallCustomerDetail();
                                Label lblReasonID = (Label)gvwReason.Rows[i].Cells[2].FindControl("txtRID");
                                TextBox txtReasonDet = (TextBox)gvwReason.Rows[i].Cells[2].FindControl("txtReasonDetail");
                                oFootFallCustomerDetail.FootFallID = oFootFallCustomer.FootFallID;
                                oFootFallCustomerDetail.Type = (int)Dictionary.FootFallDetailType.Reason;
                                oFootFallCustomerDetail.ID = Convert.ToInt32(lblReasonID.Text.ToString());
                                oFootFallCustomerDetail.ReasonDetail = txtReasonDet.Text.ToString();
                                oFootFallCustomerDetail.Add();
                            }

                        }
                    }
                    DBController.Instance.CommitTransaction();
                    string[] sSuccedCode =  { " " };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Update", "The Foot Fall", sSuccedCode, null, "frmTDFootFallCustomers.aspx", 0);
                    Response.Redirect("frmMessage.aspx");

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

    protected void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cmbASG_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("IsCheckBrand", typeof(bool)));
        dt.Columns.Add(new DataColumn("FootFallBrand", typeof(string)));
        dt.Columns.Add(new DataColumn("ID", typeof(string)));

        DBController.Instance.OpenNewConnection();

        FootFallBrands _oFootFallBrands = (FootFallBrands)Session["ASG"];

        _oFootFallBrands.RefreshForCombo(false);
        _oFootFallBrands.Refresh(_oFootFallBrands[cmbASG.SelectedIndex].ASGID);

        foreach (FootFallBrand oFootFallBrand in _oFootFallBrands)
        {

            dr = dt.NewRow();

            dr["IsCheckBrand"] = false;
            dr["FootFallBrand"] = oFootFallBrand.FootFallBrandName.ToString();
            dr["ID"] = oFootFallBrand.ID.ToString();

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["BrandTable"] = dt;
        dvwBrand.DataSource = dt;
        dvwBrand.DataBind();
        Session.Add("ASG", _oFootFallBrands);
    }
    protected void rdoYes_CheckedChanged(object sender, EventArgs e)
    {
    //    txtContactNo.Enabled = true;
    //    txtContactNo.BackColor = Color.White;
    //    txtFootFallCustName.Enabled = true;
    //    txtFootFallCustName.BackColor = Color.White;
    //    txtEmail.Enabled = true;
    //    txtEmail.BackColor = Color.White;
    //    rdoNo.Checked = false;
    //    Label1.Visible = true;
    //    Label2.Visible = true;

    }
    protected void rdoNo_CheckedChanged(object sender, EventArgs e)
    {
    //    txtContactNo.Enabled = false;
    //    txtContactNo.BackColor = Color.LightGray;
    //    txtFootFallCustName.Enabled = false;
    //    txtFootFallCustName.BackColor = Color.LightGray;
    //    txtEmail.Enabled = false;
    //    txtEmail.BackColor = Color.LightGray;
    //    rdoYes.Checked = false;
    //    Label1.Visible = false;
    //    Label2.Visible = false;
    }
}


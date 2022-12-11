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


public partial class frmTDSalesPlan : System.Web.UI.Page
{
    Customers oCustomers;
    Customer oCustomer;
    FFSalesPersons _oFFSalesPersons;
    ProductDetails _oProductDetails;
    TDSalesPlans _oTDSalesPlans;
    TDSalesPlan oTDSalesPlan;
    int nComboLoad = 0;
    bool IsUpdate = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Table5.Rows[0].Visible = false;
            lbHeaderText.Text = "Add Sales Plan";
            cmbMonth.Text = DateTime.Today.Month.ToString();
            cmbYear.Text = DateTime.Today.Year.ToString();

            Combo();
            SetGridData();

            IsUpdate = (bool)Session["Update"];

            if (IsUpdate == true)
            {
                cmbPG.Enabled = false;
                cmbOutlet.Enabled = false;
                cmbMonth.Enabled = false;
                cmbYear.Enabled = false;
                lbHeaderText.Text = "Edit Sales Plan";
                oTDSalesPlan = (TDSalesPlan)Session["TDSalesPlan"];
                Session.Add("SalesPlanCustomer", oTDSalesPlan);
                Table5.Rows[0].Visible = true;
                lblSalesPlanCode.Text = "Sales Plan Code:";
                lblSalesPlanCodetext.Text = oTDSalesPlan.SalesPlanCode;
                oTDSalesPlan = new TDSalesPlan();
                //DBController.Instance.OpenNewConnection();
                //oTDSalesPlan.GetStatus(oTDSalesPlan.SalesPlanCode);
                //DBController.Instance.CloseConnection();
                if (oTDSalesPlan.Status == 0)
                {
                    //gvwPlan.Enabled = false;

                }
                Session.Add("SalesPlanCode", lblSalesPlanCode.Text);
                SetUI();
            }
        }
    }
    public void SetUI()
    {
        oTDSalesPlan = (TDSalesPlan)Session["TDSalesPlan"];
        Combo(); ;
        cmbMonth.Text = oTDSalesPlan.PlanningMonth.Month.ToString();
        cmbYear.Text = oTDSalesPlan.PlanningMonth.Year.ToString();
        
        _oFFSalesPersons = new FFSalesPersons();
        _oProductDetails = new ProductDetails();
        DBController.Instance.OpenNewConnection();
        _oFFSalesPersons.RefreshForCombo(oCustomers[cmbOutlet.SelectedIndex].CustomerID);
        oTDSalesPlan.GetPGIDByCode(oTDSalesPlan.SalesPlanCode);
        _oProductDetails.GetPGNameForSalesPlan();
        DBController.Instance.CloseConnection();
        cmbSalesPerson.SelectedIndex = _oFFSalesPersons.GetIndex(oTDSalesPlan.SalesPersonelID);
        cmbPG.SelectedIndex = _oProductDetails.GetIndexPG(oTDSalesPlan.PGID);
        SetGridData();

    }
    public void Combo()
    {
        User oUser = (User)Session["User"];
        DBController.Instance.OpenNewConnection();
        oCustomers = new Customers();
        oCustomers.RefreshPermissionForFootFall(oUser.UserId);
        DBController.Instance.CloseConnection();

        if (nComboLoad == 0)
        {

            if (oCustomers.Count > 0)
            {
                cmbOutlet.DataSource = oCustomers;
                cmbOutlet.DataTextField = "CustomerName";
                cmbOutlet.DataBind();
                cmbOutlet.SelectedIndex = 0;
                Session.Add("TDSalesPlanCust", oCustomer);
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
                Session.Add("TDSalesPlanCust", oCustomer);
            }


            //Get PG
            _oProductDetails = new ProductDetails();
            DBController.Instance.OpenNewConnection();
            _oProductDetails.GetPGNameForSalesPlan();
            DBController.Instance.CloseConnection();


            cmbPG.DataSource = _oProductDetails;
            cmbPG.DataTextField = "PGName";
            cmbPG.DataBind();
            cmbPG.SelectedIndex = _oProductDetails.Count - 1;
            Session.Add("PG", _oProductDetails);
          
        }

        //Sales Person
        _oFFSalesPersons = new FFSalesPersons();
        DBController.Instance.OpenNewConnection();

        if (cmbOutlet.Text != "No Permission")
        {
            _oFFSalesPersons.RefreshForCombo(oCustomers[cmbOutlet.SelectedIndex].CustomerID);
        }
        DBController.Instance.CloseConnection();
        if (_oFFSalesPersons.Count > 0)
        {
            cmbSalesPerson.DataSource = _oFFSalesPersons;
            cmbSalesPerson.DataTextField = "SalesPersonName";
            cmbSalesPerson.DataBind();
            cmbSalesPerson.SelectedIndex = 0;
            Session.Add("SalesPersonName", _oFFSalesPersons);
        }
        else
        {
            FFSalesPerson oFFSalesPerson = new FFSalesPerson();
            oFFSalesPerson.SalesPersonName = "No Sales Person";
            _oFFSalesPersons.Add(oFFSalesPerson);

            cmbSalesPerson.DataSource = _oFFSalesPersons;
            cmbSalesPerson.DataTextField = "SalesPersonName";
            cmbSalesPerson.DataBind();
            cmbSalesPerson.SelectedIndex = 0;
            Session.Add("SalesPersonName", _oFFSalesPersons);
        }

    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        Save();
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


                oCustomers = new Customers();
                oCustomers.RefreshPermissionForFootFall(oUser.UserId);


                _oFFSalesPersons = new FFSalesPersons();
                _oFFSalesPersons.RefreshForCombo(oCustomers[cmbOutlet.SelectedIndex].CustomerID);

                _oProductDetails = new ProductDetails();
                _oProductDetails.GetPGNameForSalesPlan();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    DataTable rdt = (DataTable)ViewState["PlanTable"];
                    if (rdt.Rows.Count > 0)
                    {

                        for (int i = 0; i < rdt.Rows.Count; i++)
                        {
                            oTDSalesPlan = new TDSalesPlan();

                            oTDSalesPlan.CustomerID = oCustomers[cmbOutlet.SelectedIndex].CustomerID;
                            oTDSalesPlan.SalesPersonelID = _oFFSalesPersons[cmbSalesPerson.SelectedIndex].SalesPersonID;
                            oTDSalesPlan.PlanningMonth = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), 1);
                            oTDSalesPlan.PGID = _oProductDetails[cmbPG.SelectedIndex].PGID;
                            oTDSalesPlan.SalesPlanCode = cmbYear.SelectedValue + cmbMonth.SelectedValue + oCustomers[cmbOutlet.SelectedIndex].CustomerID + _oProductDetails[cmbPG.SelectedIndex].PGID;

                            //oTDSalesPlan.Remarks = txtRemarks.Text;
                            oTDSalesPlan.Status = 0;


                            Label lblASGID = (Label)gvwPlan.Rows[i].Cells[0].FindControl("txtASGID");
                            TextBox txtWeek1 = (TextBox)gvwPlan.Rows[i].Cells[8].FindControl("txtWeek1");
                            TextBox txtWeek2 = (TextBox)gvwPlan.Rows[i].Cells[9].FindControl("txtWeek2");
                            TextBox txtWeek3 = (TextBox)gvwPlan.Rows[i].Cells[10].FindControl("txtWeek3");
                            TextBox txtWeek4 = (TextBox)gvwPlan.Rows[i].Cells[11].FindControl("txtWeek4");
                            TextBox txtWeek5 = (TextBox)gvwPlan.Rows[i].Cells[12].FindControl("txtWeek5");
                            oTDSalesPlan.ASGID = Convert.ToInt32(lblASGID.Text.ToString());
                            if (txtWeek1.Text.Trim() == "")
                            {
                                oTDSalesPlan.Week1 = 0;
                            }
                            else
                            {
                                oTDSalesPlan.Week1 = Convert.ToInt32(txtWeek1.Text.ToString());
                            }
                            if (txtWeek2.Text.Trim() == "")
                            {
                                oTDSalesPlan.Week2 = 0;
                            }
                            else
                            {
                                oTDSalesPlan.Week2 = Convert.ToInt32(txtWeek2.Text.ToString());
                            }
                            if (txtWeek3.Text.Trim() == "")
                            {
                                oTDSalesPlan.Week3 = 0;
                            }
                            else
                            {
                                oTDSalesPlan.Week3 = Convert.ToInt32(txtWeek3.Text.ToString());
                            }
                            if (txtWeek4.Text.Trim() == "")
                            {
                                oTDSalesPlan.Week4 = 0;
                            }
                            else
                            {
                                oTDSalesPlan.Week4 = Convert.ToInt32(txtWeek4.Text.ToString());
                            }
                            if (txtWeek5.Text.Trim() == "")
                            {
                                oTDSalesPlan.Week5 = 0;
                            }
                            else
                            {
                                oTDSalesPlan.Week5 = Convert.ToInt32(txtWeek5.Text.ToString());
                            }
                            oTDSalesPlan.Add();

                        }
                    }
                    DBController.Instance.CommitTransaction();
                    string[] sSuccedCode =  { " " };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Save", "The Sales Plan", sSuccedCode, null, "frmTDSalesPlans.aspx", 0);
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


                oCustomers = new Customers();
                oCustomers.RefreshPermissionForFootFall(oUser.UserId);


                _oFFSalesPersons = new FFSalesPersons();
                _oFFSalesPersons.RefreshForCombo(oCustomers[cmbOutlet.SelectedIndex].CustomerID);

                _oProductDetails = new ProductDetails();
                _oProductDetails.GetPGNameForSalesPlan();
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    DataTable rdt = (DataTable)ViewState["PlanTable"];
                    if (rdt.Rows.Count > 0)
                    {

                        for (int i = 0; i < rdt.Rows.Count; i++)
                        {
                            oTDSalesPlan = new TDSalesPlan();

                            oTDSalesPlan.CustomerID = oCustomers[cmbOutlet.SelectedIndex].CustomerID;
                            oTDSalesPlan.SalesPersonelID = _oFFSalesPersons[cmbSalesPerson.SelectedIndex].SalesPersonID;
                            oTDSalesPlan.PlanningMonth = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), 1);
                            oTDSalesPlan.PGID = _oProductDetails[cmbPG.SelectedIndex].PGID;
                            oTDSalesPlan.SalesPlanCode = cmbYear.SelectedValue + cmbMonth.SelectedValue + oCustomers[cmbOutlet.SelectedIndex].CustomerID + _oProductDetails[cmbPG.SelectedIndex].PGID;

                            //oTDSalesPlan.Remarks = txtRemarks.Text;
                            oTDSalesPlan.Status = 0;


                            Label lblASGID = (Label)gvwPlan.Rows[i].Cells[0].FindControl("txtASGID");
                            TextBox txtWeek1 = (TextBox)gvwPlan.Rows[i].Cells[8].FindControl("txtWeek1");
                            TextBox txtWeek2 = (TextBox)gvwPlan.Rows[i].Cells[9].FindControl("txtWeek2");
                            TextBox txtWeek3 = (TextBox)gvwPlan.Rows[i].Cells[10].FindControl("txtWeek3");
                            TextBox txtWeek4 = (TextBox)gvwPlan.Rows[i].Cells[11].FindControl("txtWeek4");
                            TextBox txtWeek5 = (TextBox)gvwPlan.Rows[i].Cells[12].FindControl("txtWeek5");
                            oTDSalesPlan.ASGID = Convert.ToInt32(lblASGID.Text.ToString());
                            if (txtWeek1.Text.Trim() == "")
                            {
                                oTDSalesPlan.Week1 = 0;
                            }
                            else
                            {
                                oTDSalesPlan.Week1 = Convert.ToInt32(txtWeek1.Text.ToString());
                            }
                            if (txtWeek2.Text.Trim() == "")
                            {
                                oTDSalesPlan.Week2 = 0;
                            }
                            else
                            {
                                oTDSalesPlan.Week2 = Convert.ToInt32(txtWeek2.Text.ToString());
                            }
                            if (txtWeek3.Text.Trim() == "")
                            {
                                oTDSalesPlan.Week3 = 0;
                            }
                            else
                            {
                                oTDSalesPlan.Week3 = Convert.ToInt32(txtWeek3.Text.ToString());
                            }
                            if (txtWeek4.Text.Trim() == "")
                            {
                                oTDSalesPlan.Week4 = 0;
                            }
                            else
                            {
                                oTDSalesPlan.Week4 = Convert.ToInt32(txtWeek4.Text.ToString());
                            }
                            if (txtWeek5.Text.Trim() == "")
                            {
                                oTDSalesPlan.Week5 = 0;
                            }
                            else
                            {
                                oTDSalesPlan.Week5 = Convert.ToInt32(txtWeek5.Text.ToString());
                            }
                            oTDSalesPlan.Edit();

                        }
                    }
                    DBController.Instance.CommitTransaction();
                    string[] sSuccedCode =  { " " };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Edit", "The Sales Plan", sSuccedCode, null, "frmTDSalesPlans.aspx", 0);
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
    private bool validateUIInput()
    {

        //if (cmbOutlet.Text == "No Permission")
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "You have no permission any outlet";
        //    return false;
        //}
        ////if (rdoYes.Checked == true)
        ////{
        //if (txtFootFallCustName.Text.Trim() == "")
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "Please Input Name";
        //    return false;
        //}
        //if (txtContactNo.Text.Trim() == "")
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "Please Input Contact No";
        //    return false;
        //}
        ////}
        //if (txtSalesPerson.Text.Trim() == "")
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "Please Input Sales person";
        //    return false;
        //}
        //if (cboFollowUpDay.Text == "0")
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "Please Input Next Follow up Date";
        //    return false;
        //}


        //int CountBrand = 0;
        //int CountReason = 0;

        //DataTable dt = (DataTable)ViewState["BrandTable"];
        //if (dt.Rows.Count > 0)
        //{
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        CheckBox chk = (CheckBox)dvwBrand.Rows[i].Cells[0].FindControl("chkBrand");
        //        if (chk.Checked)
        //        {
        //            CountBrand = CountBrand + 1;
        //        }

        //    }
        //}
        //else
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "There is no Brand";
        //    return false;
        //}
        //if (CountBrand == 0)
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "You have to Checked at least a Brand";
        //    return false;
        //}

        //DataTable rdt = (DataTable)ViewState["ReasonTable"];
        //if (rdt.Rows.Count > 0)
        //{
        //    for (int i = 0; i < rdt.Rows.Count; i++)
        //    {
        //        CheckBox chk = (CheckBox)gvwReason.Rows[i].Cells[0].FindControl("chkReason");
        //        if (chk.Checked)
        //        {
        //            CountReason = CountReason + 1;
        //        }

        //    }
        //}
        //else
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "There is no Reason";
        //    return false;
        //}
        //if (CountReason == 0)
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "You have to Checked at least a Reason";
        //    return false;
        //}

        return true;
    }
    protected void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
    {
        nComboLoad = 1;
        Combo();
    }
    protected void cmbPG_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetGridData();
    }
    protected void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetGridData();
    }
    protected void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetGridData();
    }
    private void SetGridData()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("ASGID", typeof(string)));
        dt.Columns.Add(new DataColumn("ASGName", typeof(string)));
        dt.Columns.Add(new DataColumn("ASP", typeof(string)));
        dt.Columns.Add(new DataColumn("1stWeek", typeof(string)));
        dt.Columns.Add(new DataColumn("2ndWeek", typeof(string)));
        dt.Columns.Add(new DataColumn("3rdWeek", typeof(string)));
        dt.Columns.Add(new DataColumn("4thWeek", typeof(string)));
        dt.Columns.Add(new DataColumn("5thWeek", typeof(string)));
        dt.Columns.Add(new DataColumn("Week1", typeof(string)));
        dt.Columns.Add(new DataColumn("Week2", typeof(string)));
        dt.Columns.Add(new DataColumn("Week3", typeof(string)));
        dt.Columns.Add(new DataColumn("Week4", typeof(string)));
        dt.Columns.Add(new DataColumn("Week5", typeof(string)));

        DBController.Instance.OpenNewConnection();

        ProductDetails _oProductDetails = (ProductDetails)Session["PG"];
        _oTDSalesPlans = new TDSalesPlans();
        DateTime PlanDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), 1);

        oCustomers = new Customers();
        User oUser = (User)Session["User"];
        oCustomers.RefreshPermissionForFootFall(oUser.UserId);
        int nCustomerID = 0;
        if (oCustomers.Count > 0)
        {
            nCustomerID = oCustomers[cmbOutlet.SelectedIndex].CustomerID;
        }

        if (IsUpdate == false)
        {
            _oTDSalesPlans.GetPlanASGByPGID(PlanDate, nCustomerID, _oProductDetails[cmbPG.SelectedIndex].PGID);
        }
        else
        {
            _oTDSalesPlans.GetDataForEdit(PlanDate, nCustomerID, _oProductDetails[cmbPG.SelectedIndex].PGID);
        }
        
        foreach (TDSalesPlan oTDSalesPlan in _oTDSalesPlans)
        {

            dr = dt.NewRow();

            dr["ASGID"] = oTDSalesPlan.ASGID.ToString();
            dr["ASGName"] = oTDSalesPlan.ASGName.ToString();
            dr["ASP"] = oTDSalesPlan.ASP.ToString();
            dr["1stWeek"] = oTDSalesPlan.SaleWeek1.ToString() + "/" + oTDSalesPlan.Week1.ToString();
            dr["2ndWeek"] = oTDSalesPlan.SaleWeek2.ToString() + "/" + oTDSalesPlan.Week2.ToString();
            dr["3rdWeek"] = oTDSalesPlan.SaleWeek3.ToString() + "/" + oTDSalesPlan.Week3.ToString();
            dr["4thWeek"] = oTDSalesPlan.SaleWeek4.ToString() + "/" + oTDSalesPlan.Week4.ToString();
            dr["5thWeek"] = oTDSalesPlan.SaleWeek5.ToString() + "/" + oTDSalesPlan.Week5.ToString();
            if (IsUpdate == true)
            {
                dr["Week1"] = oTDSalesPlan.eWeek1.ToString();
                dr["Week2"] = oTDSalesPlan.eWeek2.ToString();
                dr["Week3"] = oTDSalesPlan.eWeek3.ToString();
                dr["Week4"] = oTDSalesPlan.eWeek4.ToString();
                dr["Week5"] = oTDSalesPlan.eWeek5.ToString();
            }
            else
            {
                dr["Week1"] = "";
                dr["Week2"] = "";
                dr["Week3"] = "";
                dr["Week4"] = "";
                dr["Week5"] = "";
            }

            dt.Rows.Add(dr);

        }
        DBController.Instance.CloseConnection();

        ViewState["PlanTable"] = dt;
        gvwPlan.DataSource = dt;
        gvwPlan.DataBind();
        Session.Add("ASG", _oTDSalesPlans);
    }
}

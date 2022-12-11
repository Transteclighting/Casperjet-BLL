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
using System.Text.RegularExpressions;

using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Class.Library;
using CJ.Class.FootFallCust;


public partial class frmFootFallManagement : System.Web.UI.Page
{

    FootFallManagement oFootFallManagement;
    FFBrands _oFFBrands;
    FFPriceRanges _oFFPriceRanges;
    FFSalesPersons _oFFSalesPersons;
    public ProductDetail oProductDetail;

    Customer oCustomer;
    Customers oCustomers;
    bool IsUpdate = false;
    int nComboLoad = 0;
    //bool IsCSD = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbHeaderText.Text = "Add Foot Fall";
            cmbDate.Text = DateTime.Today.Day.ToString();
            cmbMonth.Text = DateTime.Today.Month.ToString();
            cmbYear.Text = DateTime.Today.Year.ToString();

            Combo();

            IsUpdate = (bool)Session["Update"];

            Table2.Rows[0].Visible = false;
            Table2.Rows[13].Visible = false;
            Table2.Rows[14].Visible = false;
            Table2.Rows[15].Visible = false;
            Table2.Rows[16].Visible = false;
            Table2.Rows[17].Visible = false;
            Table2.Rows[18].Visible = false;
            Table2.Rows[19].Visible = false;
            Table2.Rows[20].Visible = false;
            Table2.Rows[21].Visible = false;
            Table2.Rows[22].Visible = false;
            Table2.Rows[23].Visible = false;
            Table2.Rows[24].Visible = false;
            Table2.Rows[25].Visible = false;

            if (IsUpdate == true)
            {
                lbHeaderText.Text = "Edit Foot Fall";
                oFootFallManagement = (FootFallManagement)Session["FootFallManagement"];
                Session.Add("FootFallCustomer", oFootFallManagement);
                Table2.Rows[0].Visible = true;
                lblFootFallCode.Text = "Foot Fall No: ";
                lblFootFallCodetext.Text = oFootFallManagement.FootFallNo;
                Session.Add("FootFallNo", lblFootFallCodetext.Text);
                cmbOutlet.Enabled = false;
                SetUI();
            }
        }
    }
    public void SetUI()
    {
        oFootFallManagement = (FootFallManagement)Session["FootFallManagement"];
        
        cmbDate.Text = oFootFallManagement.FootFallDate.Day.ToString();
        cmbMonth.Text = oFootFallManagement.FootFallDate.Month.ToString();
        cmbYear.Text = oFootFallManagement.FootFallDate.Year.ToString();
        cmbOutlet.SelectedIndex = oCustomers.GetIndex(oFootFallManagement.OutletID);
        cmbCustomerType.SelectedIndex = oFootFallManagement.CustomerType;
        txtFootFallCustName.Text = oFootFallManagement.CustomerName;
        txtContactNo.Text = oFootFallManagement.MobileNo;
        txtEmail.Text = oFootFallManagement.Email;
        _oFFSalesPersons = new FFSalesPersons();
        DBController.Instance.OpenNewConnection();
        _oFFSalesPersons.RefreshForCombo(oCustomers[cmbOutlet.SelectedIndex].CustomerID);
        DBController.Instance.CloseConnection();
        cmbSalesPerson.SelectedIndex = _oFFSalesPersons.GetIndex(oFootFallManagement.SalesPersonID);
        txtRemarks.Text = oFootFallManagement.Remarks;
        txtQuantity.Text = Convert.ToInt32(oFootFallManagement.Quantity).ToString();
        txtInvoiceNo.Text = oFootFallManagement.InvoiceNo;
        txtProductCode.Text = oFootFallManagement.ProductCode;
        txtProductName.Text = oFootFallManagement.ProductName;
        if (oFootFallManagement.IsAdvanceBooking == (int)Dictionary.YesNAStatus.Yes)
        {
            chkAdvanceBooking.Checked = true;
        }
        else
        {
            chkAdvanceBooking.Checked = false;
        }
        cmbExpectedWeek.SelectedIndex = oFootFallManagement.ExpectedWeek;

        if (oFootFallManagement.PriceRangeID != -1)
        {
            //_oFFPriceRanges = new FFPriceRanges();
            //_oFFPriceRanges.RefreshForCombo();
            cmbPriceRange.SelectedIndex = _oFFPriceRanges.GetIndex(oFootFallManagement.PriceRangeID);
        }

        if (oFootFallManagement.CompetitionBrand != 0)
        {
            cmbBrand.SelectedIndex = _oFFBrands.GetIndex(oFootFallManagement.CompetitionBrand);
        }
        if (oFootFallManagement.Aesthetic == (int)Dictionary.YesNAStatus.Yes)
        {
            chkAesthetic.Checked = true;
        }
        else
        {
            chkAesthetic.Checked = false;
        }
        if (oFootFallManagement.Functional == (int)Dictionary.YesNAStatus.Yes)
        {
            chkFunctional.Checked = true;
        }
        else
        {
            chkFunctional.Checked = false;
        }
        cmbCredit.SelectedIndex = oFootFallManagement.CreditCard;
        cmbHPA.SelectedIndex = oFootFallManagement.HPA;
        if (oFootFallManagement.Warranty == (int)Dictionary.YesNAStatus.Yes)
        {
            chkWarranty.Checked = true;
        }
        else
        {
            chkWarranty.Checked = false;
        }
        if (oFootFallManagement.Installation == (int)Dictionary.YesNAStatus.Yes)
        {
            chkInstallation.Checked = true;
        }
        else
        {
            chkInstallation.Checked = false;
        }
        if (oFootFallManagement.Delivery == (int)Dictionary.YesNAStatus.Yes)
        {
            chkDelivery.Checked = true;
        }
        else
        {
            chkDelivery.Checked = false;
        }
        if (oFootFallManagement.Exchange == (int)Dictionary.YesNAStatus.Yes)
        {
            chkExchange.Checked = true;
        }
        else
        {
            chkExchange.Checked = false;
        }
        if (oFootFallManagement.IsProductSold == (int)Dictionary.YesOrNoStatus.YES)
        {
            rdoYes.Checked = true;
            rdoNo.Checked = false;

            Table2.Rows[12].Visible = true;
            Table2.Rows[13].Visible = false;
            Table2.Rows[14].Visible = false;
            Table2.Rows[15].Visible = false;
            Table2.Rows[16].Visible = false;
            Table2.Rows[17].Visible = false;
            Table2.Rows[18].Visible = false;
            Table2.Rows[19].Visible = false;
            Table2.Rows[20].Visible = false;
            Table2.Rows[21].Visible = false;
            Table2.Rows[22].Visible = false;
            Table2.Rows[23].Visible = false;
            Table2.Rows[24].Visible = false;
            Table2.Rows[25].Visible = false;
        }
        else
        {
            rdoYes.Checked = false;
            rdoNo.Checked = true;

            if (oFootFallManagement.ReasonNo == (int)Dictionary.ReasonforNotbuying.NoStock)
            {
                rdoNoStock.Checked = true;
                rdoCustPositive.Checked = false;
                rdoUndecided.Checked = false;

                Table2.Rows[12].Visible = false;
                Table2.Rows[13].Visible = true;
                Table2.Rows[14].Visible = true;
                Table2.Rows[15].Visible = false;
                Table2.Rows[16].Visible = false;
                Table2.Rows[17].Visible = false;
                Table2.Rows[18].Visible = false;
                Table2.Rows[19].Visible = false;
                Table2.Rows[20].Visible = false;
                Table2.Rows[21].Visible = false;
                Table2.Rows[22].Visible = false;
                Table2.Rows[23].Visible = false;
                Table2.Rows[24].Visible = false;
                Table2.Rows[25].Visible = false;
            }
            else if (oFootFallManagement.ReasonNo == (int)Dictionary.ReasonforNotbuying.CustomerPositive)
            {
                rdoCustPositive.Checked = true;
                rdoNoStock.Checked = false;
                rdoUndecided.Checked = false;

                Table2.Rows[12].Visible = false;
                Table2.Rows[13].Visible = true;
                Table2.Rows[14].Visible = false;
                Table2.Rows[15].Visible = true;
                Table2.Rows[16].Visible = false;
                Table2.Rows[17].Visible = false;
                Table2.Rows[18].Visible = false;
                Table2.Rows[19].Visible = false;
                Table2.Rows[20].Visible = false;
                Table2.Rows[21].Visible = false;
                Table2.Rows[22].Visible = false;
                Table2.Rows[23].Visible = false;
                Table2.Rows[24].Visible = false;
                Table2.Rows[25].Visible = false;
            }
            else if (oFootFallManagement.ReasonNo == (int)Dictionary.ReasonforNotbuying.CustomerUndecided)
            {
                rdoUndecided.Checked = true;
                rdoNoStock.Checked = false;
                rdoCustPositive.Checked = false;

                Table2.Rows[12].Visible = false;
                Table2.Rows[13].Visible = true;
                Table2.Rows[14].Visible = false;
                Table2.Rows[15].Visible = false;
                Table2.Rows[16].Visible = true;
                Table2.Rows[17].Visible = true;
                Table2.Rows[18].Visible = true;
                Table2.Rows[19].Visible = true;
                Table2.Rows[20].Visible = true;
                Table2.Rows[21].Visible = true;
                Table2.Rows[22].Visible = true;
                Table2.Rows[23].Visible = true;
                Table2.Rows[24].Visible = true;
                Table2.Rows[25].Visible = true;
            }
        }

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

            //FF Brand

            _oFFBrands = new FFBrands();
            DBController.Instance.OpenNewConnection();
            _oFFBrands.RefreshForCombo();
            DBController.Instance.CloseConnection();

            cmbBrand.DataSource = _oFFBrands;
            cmbBrand.DataTextField = "FFBrandName";
            cmbBrand.DataBind();
            cmbBrand.SelectedIndex = _oFFBrands.Count - 1;
            Session.Add("FFBrand", _oFFBrands);

            //CustomerType

            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.FootFallCustType)))
            {
                cmbCustomerType.Items.Add(Enum.GetName(typeof(Dictionary.FootFallCustType), GetEnum));
            }
            cmbCustomerType.SelectedIndex = 0;


            //Expected Week
            cmbExpectedWeek.Items.Add("N/A");
            cmbExpectedWeek.Items.Add("1 Week");
            cmbExpectedWeek.Items.Add("2 Weeks");
            cmbExpectedWeek.Items.Add("3 Weeks");
            cmbExpectedWeek.Items.Add("4 Weeks");
            cmbExpectedWeek.Items.Add("5 Weeks");
            cmbExpectedWeek.Items.Add("6 Weeks");

            //Price Range

            _oFFPriceRanges = new FFPriceRanges();
            DBController.Instance.OpenNewConnection();
            _oFFPriceRanges.RefreshForCombo();
            DBController.Instance.CloseConnection();

            cmbPriceRange.DataSource = _oFFPriceRanges;
            cmbPriceRange.DataTextField = "PriceRange";
            cmbPriceRange.DataBind();
            cmbPriceRange.SelectedIndex = _oFFPriceRanges.Count - 1;
            Session.Add("PriceRange", _oFFPriceRanges);


            //Credit
            cmbCredit.Items.Add("N/A");
            cmbCredit.Items.Add("3 Months");
            cmbCredit.Items.Add("6 Months");
            cmbCredit.Items.Add("9 Months");
            cmbCredit.Items.Add("12 Months");
            cmbCredit.Items.Add("18 Months");
            cmbCredit.Items.Add("24 Months");

            //HPA
            cmbHPA.Items.Add("N/A");
            cmbHPA.Items.Add("3 Months");
            cmbHPA.Items.Add("6 Months");
            cmbHPA.Items.Add("9 Months");
            cmbHPA.Items.Add("12 Months");
            cmbHPA.Items.Add("18 Months");
            cmbHPA.Items.Add("24 Months");
        }

        //FF Sales Person
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
    
    private bool validateUIInput()
    {

        if (cmbOutlet.Text == "No Permission")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "You have no permission any outlet";
            return false;
        }
        if (txtFootFallCustName.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Customer Name";
            return false;
        }
        if (txtContactNo.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input Contact No";
            return false;
        }
        else
        {
            if (txtContactNo.Text.Length != 11)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input Valid Cell No";
                return false;
            }
            Regex rgCell = new Regex("[0-9]");
            if (rgCell.IsMatch(txtContactNo.Text))
            {

            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input Valid Cell No";
                return false;
            }
        }
        if (txtEmail.Text.Trim() != "")
        {
            Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
            Match m = emailregex.Match(txtEmail.Text);
            if (!m.Success)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please enter a Valid Email Address";
                return false;
            }
        }
        if (cmbSalesPerson.Text == "No Sales Person")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "There is no Sales person please contact administrator";
            return false;
        }
        if (txtProductCode.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input product code & Click GO button";
            return false;
        }
        else
        {
            oProductDetail = new ProductDetail();
            oProductDetail.ProductCode = txtProductCode.Text;
            DBController.Instance.OpenNewConnection();
            oProductDetail.RefreshByCode();
            DBController.Instance.CloseConnection();
            if (oProductDetail.Flag == true)
            {
                lblError.Visible = false;
                lblMessage.Visible = false;
                txtProductName.Text = oProductDetail.ProductName;
            }
            else
            {
                lblError.Visible = true;
                txtProductName.Text = "";
                lblError.Text = "Invalid Product Code";
                return false;
            }
        }
        if (txtQuantity.Text.Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Input product quantity";
            return false;
        }
        else
        {
            Regex rgCell = new Regex("[0-9]");
            if (rgCell.IsMatch(txtQuantity.Text))
            {

            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input valid product quantity";
                return false;
            }
        }
        if (rdoYes.Checked == true)
        {
            if (txtInvoiceNo.Text.Trim() == "")
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input Invoice Number";
                return false;
            }

        }
        else
        {
            if (rdoCustPositive.Checked == true)
            {
                if (cmbExpectedWeek.Text == "N/A")
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Please select expected week";
                    return false;
                }
            }
            else if (rdoUndecided.Checked == true)
            {

                if (cmbPriceRange.Text == "N/A" && cmbBrand.Text == "N/A" && chkAesthetic.Checked==false && chkFunctional.Checked==false && 
                    cmbCredit.Text=="N/A" && cmbHPA.Text=="N/A" && chkWarranty.Checked==false && chkInstallation.Checked==false && 
                    chkDelivery.Checked==false && chkExchange.Checked==false)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Please select at least a reason of undecided";
                    return false;
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
        FFBrands _oFFBrands = (FFBrands)Session["FFBrand"];
        IsUpdate = (bool)Session["Update"];

        if (validateUIInput())
        {
            DBController.Instance.OpenNewConnection();
            oCustomer = new Customer();
            oCustomer.GetCustomerForDCS(oUser.UserId);
            FootFallManagement oFootFallManagement = new FootFallManagement();

            oCustomers = new Customers();
            oCustomers.RefreshPermissionForFootFall(oUser.UserId);

            oFootFallManagement.OutletID = oCustomers[cmbOutlet.SelectedIndex].CustomerID;

            oFootFallManagement.FootFallDate = new DateTime(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmbDate.SelectedValue));

            oFootFallManagement.CustomerType = cmbCustomerType.SelectedIndex;
            oFootFallManagement.CustomerName = txtFootFallCustName.Text;
            oFootFallManagement.MobileNo = txtContactNo.Text;
            oFootFallManagement.Email = txtEmail.Text;

            _oFFSalesPersons = new FFSalesPersons();
            _oFFSalesPersons.RefreshForCombo(oCustomers[cmbOutlet.SelectedIndex].CustomerID);

            oFootFallManagement.SalesPersonID = _oFFSalesPersons[cmbSalesPerson.SelectedIndex].SalesPersonID;
            oFootFallManagement.Remarks = txtRemarks.Text;

            oProductDetail = new ProductDetail();
            oProductDetail.ProductCode = txtProductCode.Text;
            oProductDetail.RefreshByCode();
            oFootFallManagement.ProductID = oProductDetail.ProductID;

            oFootFallManagement.Quantity = Convert.ToInt32(txtQuantity.Text.ToString());
            oFootFallManagement.StageType = 0;
            oFootFallManagement.IsCurrent = 1;

            if (rdoYes.Checked == true)
            {
                oFootFallManagement.IsProductSold = (int)Dictionary.YesOrNoStatus.YES;
                oFootFallManagement.InvoiceNo = txtInvoiceNo.Text;

                oFootFallManagement.IsAdvanceBooking = (int)Dictionary.YesNAStatus.NA;
                oFootFallManagement.ExpectedWeek = (int)Dictionary.ExpectedWeek.NA;
                oFootFallManagement.Aesthetic = (int)Dictionary.YesNAStatus.NA;
                oFootFallManagement.Functional = (int)Dictionary.YesNAStatus.NA;
                oFootFallManagement.CreditCard = (int)Dictionary.Installment.NA;
                oFootFallManagement.HPA = (int)Dictionary.Installment.NA;
                oFootFallManagement.Warranty = (int)Dictionary.YesNAStatus.NA;
                oFootFallManagement.Installation = (int)Dictionary.YesNAStatus.NA;
                oFootFallManagement.Delivery = (int)Dictionary.YesNAStatus.NA;
                oFootFallManagement.Exchange = (int)Dictionary.YesNAStatus.NA;
            }
            else
            {
                oFootFallManagement.IsProductSold = (int)Dictionary.YesOrNoStatus.NO;
                oFootFallManagement.InvoiceNo = null;

                if (rdoNoStock.Checked == true)
                {

                    if (chkAdvanceBooking.Checked == true)
                    {
                        oFootFallManagement.IsAdvanceBooking = (int)Dictionary.YesNAStatus.Yes;
                    }
                    else
                    {
                        oFootFallManagement.IsAdvanceBooking = (int)Dictionary.YesNAStatus.NA;
                    }
                    oFootFallManagement.ReasonNo = (int)Dictionary.ReasonforNotbuying.NoStock;
                    oFootFallManagement.ExpectedWeek = (int)Dictionary.ExpectedWeek.NA;
                    oFootFallManagement.Aesthetic = (int)Dictionary.YesNAStatus.NA;
                    oFootFallManagement.Functional = (int)Dictionary.YesNAStatus.NA;
                    oFootFallManagement.CreditCard = (int)Dictionary.Installment.NA;
                    oFootFallManagement.HPA = (int)Dictionary.Installment.NA;
                    oFootFallManagement.Warranty = (int)Dictionary.YesNAStatus.NA;
                    oFootFallManagement.Installation = (int)Dictionary.YesNAStatus.NA;
                    oFootFallManagement.Delivery = (int)Dictionary.YesNAStatus.NA;
                    oFootFallManagement.Exchange = (int)Dictionary.YesNAStatus.NA;

                }
                else if (rdoCustPositive.Checked == true)
                {
                    oFootFallManagement.ExpectedWeek = cmbExpectedWeek.SelectedIndex;

                    if (cmbExpectedWeek.SelectedIndex == (int)Dictionary.ExpectedWeek.Week_1)
                    {
                        oFootFallManagement.FollowupDate = DateTime.Today.AddDays(7);
                    }
                    else if (cmbExpectedWeek.SelectedIndex == (int)Dictionary.ExpectedWeek.Week_2)
                    {
                        oFootFallManagement.FollowupDate = DateTime.Today.AddDays(14);
                    }
                    else if (cmbExpectedWeek.SelectedIndex == (int)Dictionary.ExpectedWeek.Week_3)
                    {
                        oFootFallManagement.FollowupDate = DateTime.Today.AddDays(21);
                    }
                    else if (cmbExpectedWeek.SelectedIndex == (int)Dictionary.ExpectedWeek.Week_4)
                    {
                        oFootFallManagement.FollowupDate = DateTime.Today.AddDays(28);
                    }
                    else if (cmbExpectedWeek.SelectedIndex == (int)Dictionary.ExpectedWeek.Week_5)
                    {
                        oFootFallManagement.FollowupDate = DateTime.Today.AddDays(35);
                    }
                    else if (cmbExpectedWeek.SelectedIndex == (int)Dictionary.ExpectedWeek.Week_6)
                    {
                        oFootFallManagement.FollowupDate = DateTime.Today.AddDays(42);
                    }

                    oFootFallManagement.ReasonNo = (int)Dictionary.ReasonforNotbuying.CustomerPositive;
                    oFootFallManagement.IsAdvanceBooking = (int)Dictionary.YesNAStatus.NA;

                    oFootFallManagement.Aesthetic = (int)Dictionary.YesNAStatus.NA;
                    oFootFallManagement.Functional = (int)Dictionary.YesNAStatus.NA;
                    oFootFallManagement.CreditCard = (int)Dictionary.Installment.NA;
                    oFootFallManagement.HPA = (int)Dictionary.Installment.NA;
                    oFootFallManagement.Warranty = (int)Dictionary.YesNAStatus.NA;
                    oFootFallManagement.Installation = (int)Dictionary.YesNAStatus.NA;
                    oFootFallManagement.Delivery = (int)Dictionary.YesNAStatus.NA;
                    oFootFallManagement.Exchange = (int)Dictionary.YesNAStatus.NA;
                }
                else
                {
                    oFootFallManagement.ReasonNo = (int)Dictionary.ReasonforNotbuying.CustomerUndecided;
                    oFootFallManagement.IsAdvanceBooking = (int)Dictionary.YesOrNoStatus.NO;
                    oFootFallManagement.ExpectedWeek = (int)Dictionary.ExpectedWeek.NA;

                    if (cmbPriceRange.Text != "N/A")
                    {
                        _oFFPriceRanges = new FFPriceRanges();
                        _oFFPriceRanges.RefreshForCombo();
                        oFootFallManagement.PriceRangeID = _oFFPriceRanges[cmbPriceRange.SelectedIndex].PriceRangeID;
                    }

                    if (cmbBrand.Text != "N/A")
                    {
                        _oFFBrands = new FFBrands();
                        _oFFBrands.RefreshForCombo();
                        oFootFallManagement.CompetitionBrand = _oFFBrands[cmbBrand.SelectedIndex].ID;
                    }
                    if (chkAesthetic.Checked == true)
                    {
                        oFootFallManagement.Aesthetic = (int)Dictionary.YesNAStatus.Yes;
                    }
                    else
                    {
                        oFootFallManagement.Aesthetic = (int)Dictionary.YesNAStatus.NA;
                    }
                    if (chkFunctional.Checked == true)
                    {
                        oFootFallManagement.Functional = (int)Dictionary.YesNAStatus.Yes;
                    }
                    else
                    {
                        oFootFallManagement.Functional = (int)Dictionary.YesNAStatus.NA;
                    }

                    oFootFallManagement.CreditCard = cmbCredit.SelectedIndex;
                    oFootFallManagement.HPA = cmbHPA.SelectedIndex;
                    if (chkWarranty.Checked == true)
                    {
                        oFootFallManagement.Warranty = (int)Dictionary.YesNAStatus.Yes;
                    }
                    else
                    {
                        oFootFallManagement.Warranty = (int)Dictionary.YesNAStatus.NA;
                    }
                    if (chkInstallation.Checked == true)
                    {
                        oFootFallManagement.Installation = (int)Dictionary.YesNAStatus.Yes;
                    }
                    else
                    {
                        oFootFallManagement.Installation = (int)Dictionary.YesNAStatus.NA;
                    }
                    if (chkDelivery.Checked == true)
                    {
                        oFootFallManagement.Delivery = (int)Dictionary.YesNAStatus.Yes;
                    }
                    else
                    {
                        oFootFallManagement.Delivery = (int)Dictionary.YesNAStatus.NA;
                    }
                    if (chkExchange.Checked == true)
                    {
                        oFootFallManagement.Exchange = (int)Dictionary.YesNAStatus.Yes;
                    }
                    else
                    {
                        oFootFallManagement.Exchange = (int)Dictionary.YesNAStatus.NA;
                    }

                }

            }

            try
            {
                DBController.Instance.BeginNewTransaction();
                if (IsUpdate == false)
                {
                    oFootFallManagement.Add(true);
                }
                else
                {
                    oFootFallManagement.FootFallNo = (string)Session["FootFallNo"];
                    oFootFallManagement.Add(false);
                }

                DBController.Instance.CommitTransaction();
                string[] sSuccedCode =  { " " };
                Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                UIUtility.GetConfirmationMsg("Save", "The Foot Fall", sSuccedCode, null, "frmFootFallManagements.aspx", 0);
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

    protected void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
    {
        nComboLoad = 1;
        Combo();
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
        //dvwBrand.DataSource = dt;
        //dvwBrand.DataBind();
        Session.Add("ASG", _oFootFallBrands);
    }
    protected void rdoYes_CheckedChanged(object sender, EventArgs e)
    {
        rdoNo.Checked = false;
        Table2.Rows[12].Visible = true;
        Table2.Rows[13].Visible = false;
        Table2.Rows[14].Visible = false;
        Table2.Rows[15].Visible = false;
        Table2.Rows[16].Visible = false;
        Table2.Rows[17].Visible = false;
        Table2.Rows[18].Visible = false;
        Table2.Rows[19].Visible = false;
        Table2.Rows[20].Visible = false;
        Table2.Rows[21].Visible = false;
        Table2.Rows[22].Visible = false;
        Table2.Rows[23].Visible = false;
        Table2.Rows[24].Visible = false;
        Table2.Rows[25].Visible = false;

    }
    protected void rdoNo_CheckedChanged(object sender, EventArgs e)
    {
        rdoYes.Checked = false;

        rdoNoStock.Checked = true;
        rdoCustPositive.Checked = false;
        rdoUndecided.Checked = false;

        Table2.Rows[12].Visible = false;
        Table2.Rows[13].Visible = true;
        Table2.Rows[14].Visible = true;
        Table2.Rows[15].Visible = false;
        Table2.Rows[16].Visible = false;
        Table2.Rows[17].Visible = false;
        Table2.Rows[18].Visible = false;
        Table2.Rows[19].Visible = false;
        Table2.Rows[20].Visible = false;
        Table2.Rows[21].Visible = false;
        Table2.Rows[22].Visible = false;
        Table2.Rows[23].Visible = false;
        Table2.Rows[24].Visible = false;
        Table2.Rows[25].Visible = false;
    }
    protected void rdoNoStock_CheckedChanged(object sender, EventArgs e)
    {
        rdoCustPositive.Checked = false;
        rdoUndecided.Checked = false;
        Table2.Rows[12].Visible = false;
        Table2.Rows[13].Visible = true;
        Table2.Rows[14].Visible = true;
        Table2.Rows[15].Visible = false;
        Table2.Rows[16].Visible = false;
        Table2.Rows[17].Visible = false;
        Table2.Rows[18].Visible = false;
        Table2.Rows[19].Visible = false;
        Table2.Rows[20].Visible = false;
        Table2.Rows[21].Visible = false;
        Table2.Rows[22].Visible = false;
        Table2.Rows[23].Visible = false;
        Table2.Rows[24].Visible = false;
        Table2.Rows[25].Visible = false;
    }
    protected void rdoCustPositive_CheckedChanged(object sender, EventArgs e)
    {
        rdoNoStock.Checked = false;
        rdoUndecided.Checked = false;
        Table2.Rows[12].Visible = false;
        Table2.Rows[13].Visible = true;
        Table2.Rows[14].Visible = false;
        Table2.Rows[15].Visible = true;
        Table2.Rows[16].Visible = false;
        Table2.Rows[17].Visible = false;
        Table2.Rows[18].Visible = false;
        Table2.Rows[19].Visible = false;
        Table2.Rows[20].Visible = false;
        Table2.Rows[21].Visible = false;
        Table2.Rows[22].Visible = false;
        Table2.Rows[23].Visible = false;
        Table2.Rows[24].Visible = false;
        Table2.Rows[25].Visible = false;
    }
    protected void rdoUndecided_CheckedChanged(object sender, EventArgs e)
    {
        rdoNoStock.Checked = false;
        rdoCustPositive.Checked = false;
        Table2.Rows[12].Visible = false;
        Table2.Rows[13].Visible = true;
        Table2.Rows[14].Visible = false;
        Table2.Rows[15].Visible = false;
        Table2.Rows[16].Visible = true;
        Table2.Rows[17].Visible = true;
        Table2.Rows[18].Visible = true;
        Table2.Rows[19].Visible = true;
        Table2.Rows[20].Visible = true;
        Table2.Rows[21].Visible = true;
        Table2.Rows[22].Visible = true;
        Table2.Rows[23].Visible = true;
        Table2.Rows[24].Visible = true;
        Table2.Rows[25].Visible = true;
    }
    protected void txtProductCode_TextChanged(object sender, EventArgs e)
    {   
        btGo_Click(null, null);
    }
    protected void btGo_Click(object sender, EventArgs e)
    {
        oProductDetail = new ProductDetail();
        oProductDetail.ProductCode = txtProductCode.Text;
        DBController.Instance.OpenNewConnection();
        oProductDetail.RefreshByCode();
        DBController.Instance.CloseConnection();
        if (oProductDetail.Flag == true)
        {
            lblError.Visible = false;
            txtProductName.Text = oProductDetail.ProductName;
        }
        else
        {
            lblError.Visible = true;
            txtProductName.Text = "";
            lblError.Text = "Invalid Product Code";
        }
        
    }
}



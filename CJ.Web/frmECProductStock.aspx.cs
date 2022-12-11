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

public partial class frmECProductStock : System.Web.UI.Page
{
    Utilities _oCategory;
    Utilities _oSubCategory;
    Utilities _oBrand;
    ECProductStock oECProductStock;
    ECProductAction oECProductAction;
    ECProductActions _oECProductActions;
    bool IsUpdate = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DBController.Instance.OpenNewConnection();

            _oCategory = new Utilities();
            cmbCategory.Items.Clear();
            _oCategory.GetECCategory();
            cmbCategory.DataSource = _oCategory;
            cmbCategory.DataTextField = "Satus";
            cmbCategory.DataBind();

            _oSubCategory = new Utilities();
            cmbSubCategory.Items.Clear();
            _oSubCategory.GetECSubCategory();
            cmbSubCategory.DataSource = _oSubCategory;
            cmbSubCategory.DataTextField = "Satus";
            cmbSubCategory.DataBind();

            _oBrand = new Utilities();
            cmbBrand.Items.Clear();
            _oBrand.GetECBrand();
            cmbBrand.DataSource = _oBrand;
            cmbBrand.DataTextField = "Satus";
            cmbBrand.DataBind();

            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ECStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ECStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;


            IsUpdate=(bool)Session["IsUpdate"];
            if (IsUpdate)
            {
                SetUI();
                cmbStatus.Enabled = true;
            }
            else
            {
                cmbStatus.Enabled = false;
            }
            DBController.Instance.CloseConnection();
        }
    }
    public void SetUI()
    {
        oECProductStock = (ECProductStock)Session["ECProductStock"];
        txtPCode.Enabled = false;
        txtPCode.Text = oECProductStock.PCode;
        txtPName.Text = oECProductStock.PName;
        cmbCategory.Text = oECProductStock.PCategory;
        cmbSubCategory.Text = oECProductStock.PSubCategory;
        cmbBrand.Text = oECProductStock.PBrand;
        txtRetailPrice.Text = oECProductStock.RetailPrice.ToString();
        txtDiccountedPrice.Text = oECProductStock.DiscountedPrice.ToString();
        txtWebStock.Text = oECProductStock.WebStock.ToString();
        cmbStatus.SelectedIndex = oECProductStock.Status;
 
        _oECProductActions = new ECProductActions();
        _oECProductActions.Refresh(oECProductStock.PCode);
        foreach (ECProductAction oECPA in _oECProductActions)
        {
            if (oECPA.ActionID == (int)Dictionary.ECProductAction.Price)
            {
               chkPrice.Checked = true;
            }
            if (oECPA.ActionID == (int)Dictionary.ECProductAction.Product)
            {
               chkProduct.Checked = true;
            }
            if (oECPA.ActionID == (int)Dictionary.ECProductAction.Stock)
            {
              chkStock.Checked = true;
            }
        
        }

    }

    private bool validateUIInput()
    {
        
        if (txtPCode.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please enter product code.";
            txtPCode.Focus();
            return false;
        }
        if (txtPName.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please enter product name.";
            txtPCode.Focus();
            return false;
        }
        if (txtRetailPrice.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please enter Retail price.";
            txtRetailPrice.Focus();
            return false;
        }
        else
        {
            try
            {
                double temp = Convert.ToDouble(txtRetailPrice.Text);
            }
            catch
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please enter Retail price.";
                txtRetailPrice.Focus();
                return false;
            }
        }
        if (txtDiccountedPrice.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please enter discounted price.";
            txtDiccountedPrice.Focus();
            return false;
        }
        else
        {
            try
            {
                double temp = Convert.ToDouble(txtDiccountedPrice.Text);
            }
            catch
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please enter discounted price.";
                txtDiccountedPrice.Focus();
                return false;
            }
        }
        if (txtWebStock.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please enter web stock.";
            txtWebStock.Focus();
            return false;
        }
        else
        {
            try
            {
                int temp = Convert.ToInt32(txtWebStock.Text);
            }
            catch
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please enter web stock.";
                txtWebStock.Focus();
                return false;
            }
        }
        IsUpdate = (bool)Session["IsUpdate"];
        if (IsUpdate)
        {
            if (cmbStatus.SelectedIndex == (int)Dictionary.ECStatus.New)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please select another status";
                return false;
            }
        }

        return true;
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            IsUpdate = (bool)Session["IsUpdate"];
            if (IsUpdate)
            {
                oECProductStock = (ECProductStock)Session["ECProductStock"];

                oECProductStock.PName = txtPName.Text;
                if (ckbCategory.Checked)
                    oECProductStock.PCategory = txtCategory.Text;
                else oECProductStock.PCategory = cmbCategory.Text;
                if (ckbSubCategory.Checked)
                    oECProductStock.PSubCategory = txtSubCategory.Text;
                else oECProductStock.PSubCategory = cmbSubCategory.Text;
                if (ckbBrand.Checked)
                    oECProductStock.PBrand = txtBrand.Text;
                else oECProductStock.PBrand = cmbBrand.Text;

                oECProductStock.RetailPrice = Convert.ToDouble(txtRetailPrice.Text);
                oECProductStock.DiscountedPrice = Convert.ToDouble(txtDiccountedPrice.Text);
                oECProductStock.WebStock = Convert.ToDouble(txtWebStock.Text);
                DBController.Instance.OpenNewConnection();
                User oUser = (User)Session["User"];
                if (oECProductStock.IsRead == (int)Dictionary.ECIsRead.No)
                {
                    if (oECProductStock.CheckReadPermission(oUser.UserId))
                    {
                        oECProductStock.IsRead = (int)Dictionary.ECIsRead.Yes;
                    }
                    else
                    {
                        oECProductStock.IsRead = (int)Dictionary.ECIsRead.No;
                    }
                }
                else
                {
                    if (oECProductStock.CheckReadPermission(oUser.UserId))
                    {
                        oECProductStock.IsRead = (int)Dictionary.ECIsRead.Yes;
                    }
                    else
                    {
                        oECProductStock.IsRead = (int)Dictionary.ECIsRead.No;
                    }
                }
                oECProductStock.Status = cmbStatus.SelectedIndex;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oECProductStock.Update();
                    oECProductAction = new ECProductAction();
                    oECProductAction.ProductCode = oECProductStock.PCode;
                    oECProductAction.Delete();
                    if (chkProduct.Checked == true)
                    {
                        oECProductAction.ActionID = (int)Dictionary.ECProductAction.Product;
                        oECProductAction.Insert();
                    }
                    if (chkStock.Checked == true)
                    {
                        oECProductAction.ActionID = (int)Dictionary.ECProductAction.Stock;
                        oECProductAction.Insert();
                    }
                    if (chkPrice.Checked == true)
                    {
                        oECProductAction.ActionID = (int)Dictionary.ECProductAction.Price;
                        oECProductAction.Insert();
                    }

                    DBController.Instance.CommitTransaction();
                    string[] sSuccedCode =  { " " };
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Update", "The Product", sSuccedCode, null, "frmECProductStocks.aspx", 0);
                    Response.Redirect("frmMessage.aspx");
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error... " + ex;
                }

            }
            else
            {
                oECProductStock = new ECProductStock();

                oECProductStock.PCode = txtPCode.Text;
                oECProductStock.PName = txtPName.Text;
                if (ckbCategory.Checked)
                    oECProductStock.PCategory = txtCategory.Text;
                else oECProductStock.PCategory = cmbCategory.Text;
                if (ckbSubCategory.Checked)
                    oECProductStock.PSubCategory = txtSubCategory.Text;
                else oECProductStock.PSubCategory = cmbSubCategory.Text;
                if (ckbBrand.Checked)
                    oECProductStock.PBrand = txtBrand.Text;
                else oECProductStock.PBrand = cmbBrand.Text;

                oECProductStock.RetailPrice = Convert.ToDouble(txtRetailPrice.Text);
                oECProductStock.DiscountedPrice = Convert.ToDouble(txtDiccountedPrice.Text);
                oECProductStock.WebStock = Convert.ToDouble(txtWebStock.Text);

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (oECProductStock.CheckPCode())
                    {
                        oECProductStock.Insert();

                        oECProductAction = new ECProductAction();
                        oECProductAction.ProductCode = oECProductStock.PCode;
                        if (chkProduct.Checked == true)
                        {
                            oECProductAction.ActionID = (int)Dictionary.ECProductAction.Product;
                            oECProductAction.Insert();
                        }
                        if (chkStock.Checked == true)
                        {
                            oECProductAction.ActionID = (int)Dictionary.ECProductAction.Stock;
                            oECProductAction.Insert();
                        }
                        if (chkPrice.Checked == true)
                        {
                            oECProductAction.ActionID = (int)Dictionary.ECProductAction.Price;
                            oECProductAction.Insert();
                        }

                    }
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        lblMessage.Visible = true;
                        lblMessage.Text = "This Product Code already exist.";
                        return;
                    }
                    DBController.Instance.CommitTransaction();
                    string[] sSuccedCode =  {" "};
                    Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                    UIUtility.GetConfirmationMsg("Save", "The Product", sSuccedCode, null, "frmECProductStocks.aspx", 0);
                    Response.Redirect("frmMessage.aspx");
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    lblMessage.Visible = true;
                    lblMessage.Text = "Error... " + ex;
                    return;
                }

            }
        }
    }
    protected void ckbCategory_CheckedChanged(object sender, EventArgs e)
    {
        if (ckbCategory.Checked)
        {
            txtCategory.Visible = true;
            cmbCategory.Visible = false;
        }
        else
        {
            txtCategory.Visible = false;
            cmbCategory.Visible = true;
        }
    }
    protected void ckbSubCategory_CheckedChanged(object sender, EventArgs e)
    {
        if (ckbSubCategory.Checked)
        {
            txtSubCategory.Visible = true;
            cmbSubCategory.Visible = false;
        }
        else
        {
            txtSubCategory.Visible = false;
            cmbSubCategory.Visible = true;
        }
    }
    protected void ckbBrand_CheckedChanged(object sender, EventArgs e)
    {
        if (ckbBrand.Checked)
        {
            txtBrand.Visible = true;
            cmbBrand.Visible = false;
        }
        else
        {
            txtBrand.Visible = false;
            cmbBrand.Visible = true;
        }
    }
}

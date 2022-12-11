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

public partial class frmProduct : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Product oProduct= (Product)Session["CODE"];
            if (oProduct != null)
            {
                txtCode.Text = oProduct.ProductCode;
                txtName.Text = oProduct.ProductName;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Product oProduct = (Product)Session["CODE"];
        if (oProduct != null)
        {
            oProduct.ProductCode = txtCode.Text;
            oProduct.ProductName = txtName.Text;
            try
            {
                DBController.Instance.BeginNewTransaction();
                oProduct.Edit();
                DBController.Instance.CommitTransaction();  
                
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();

            }
        }
        else
        {
            oProduct = new Product();
            oProduct.ProductCode = txtCode.Text;
            oProduct.ProductName = txtName.Text;
            try
            {
                DBController.Instance.BeginNewTransaction();
                oProduct.Add();
                DBController.Instance.CommitTransaction();  
                
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();

            }
        }
        Session.Remove("CODE");
    }
}

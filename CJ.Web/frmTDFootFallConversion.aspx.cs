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
using CJ.Class.DCS;
using CJ.Class.FootFallCust;

public partial class frmTDFootFallConversion : System.Web.UI.Page
{
    Customer oCustomer;
    Customers _oCustomers;
    FootFallCustomer oFootFallCustomer;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            oFootFallCustomer = (FootFallCustomer)Session["FootFallConversion"];
            oFootFallCustomer.FootFallCode = oFootFallCustomer.FootFallCode;
            DBController.Instance.OpenNewConnection();
            oFootFallCustomer.RereshByCode();
            DBController.Instance.CloseConnection();
            lblFFCode.Text = oFootFallCustomer.FootFallCode;
            lblName.Text = oFootFallCustomer.Name;
            lblContactNo.Text = oFootFallCustomer.ContactNo;
             
        }
    }
    private bool validateUIInput()
    {
        
        if (txtInvoiceNo.Text.ToString().Trim() == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Please Enter a Invoice Number";
            return false;
        }
       
        return true;
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            lblMessage.Visible = false;
            User oUser = (User)Session["User"];
            Customer oCustomer = (Customer)Session["Customer"];
            FootFallCustomer oFootFallCustomer = (FootFallCustomer)Session["FootFallConversion"];

            oFootFallCustomer.FootFallCode = oFootFallCustomer.FootFallCode;
            oFootFallCustomer.InvoiceNo = txtInvoiceNo.Text;
            oFootFallCustomer.IsConversion = (int)Dictionary.FootFallIsConversion.Yes;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oFootFallCustomer.UpdateSaleConversion();
                DBController.Instance.CommitTransaction();
                string[] sSuccedCode =  { " " };
                Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                UIUtility.GetConfirmationMsg("Save", "The Sale Conversion", sSuccedCode, null, "frmTDFootFallCustomers.aspx", 0);
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

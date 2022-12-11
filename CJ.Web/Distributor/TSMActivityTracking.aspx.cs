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
using CJ.Class.Report;
using CJ.Report;
using CJ.Class.Distribution;

public partial class Distributor_TSMActivityTracking : System.Web.UI.Page
{
    Customer _oCustomer;
    CustomerDetail _oCustomerDetail;
    LightingActivityTracking _oLightingActivityTracking;
    
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cboStDay.Text = DateTime.Today.Day.ToString();
            cboStMonth.Text = DateTime.Today.Month.ToString();
            cboStYear.Text = DateTime.Today.Year.ToString();          

        }       

    }   
    
    protected void dvwZSIActivity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private bool validateUIInput()
    {
        if (txtCustomerCode.Text == "")
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Put a DB Code";
            return false;        
        }

        if (txtTSMCode.Text == "")
        {

            lblTSMCode.Visible = true;
            lblTSMCode.Text = "Put a TSM Code";
            return false;
        }


        if (txtRoute.Text == "")
        {
            lblRoute.Visible = true;
            lblRoute.Text = "Enter Route ";
            return false;
        }
              

        if (txtTotalOutlet.Text == "")
        {
            lblTotalOutlet.Visible = true;
            lblTotalOutlet.Text = "Enter Outlet";
            return false;
        }

        if (txtCashMemo.Text == "")
        {

            lblMemo.Visible = true;
            lblMemo.Text = "Enter CashMemo";
            return false;
        }
        if (txtJSACode.Text == "")
        {
            lblJSACode.Visible = true;
            lblJSACode.Text = "Put JSA Code";
            return false;
        }
       

        if (txtTgtTO.Text== "")
        {
            lblTGTTo.Visible = true;
            lblTGTTo.Text = "Target TO";
            return false;
        }

        if (txtSalesTO.Text == "")
        {
            lblSalesTO.Visible = true;
            lblSalesTO.Text = "Put Sales TO";
            return false;
        }

        if (txtCFLTGTQty.Text == "")
        {

            lblCFLTGT.Visible = true;
            lblCFLTGT.Text = "Put CFL TGT Qty";
            return false;
        }

        if (txtCFLSalesQty.Text == "")
        {
            lblCFlSales.Visible = true;
            lblCFlSales.Text = "Put CFL Sales Qty";
            return false;
        }
        
        return true;
    }

    
  
    public void Save()
    {
        lblSave.Visible = false;
        LightingActivityTracking  _oLightingActivityTracking = new LightingActivityTracking();

        _oLightingActivityTracking.DistributorCode = Convert.ToString(txtCustomerCode.Text.ToString());       
        _oLightingActivityTracking.VisitedArea = Convert.ToString(txtRoute.Text);
        _oLightingActivityTracking.ZSICode = Convert.ToInt16(txtTSMCode.Text.ToString());       
        _oLightingActivityTracking.TranDate = new DateTime(Convert.ToInt32(cboStYear.SelectedValue), Convert.ToInt32(cboStMonth.SelectedValue), Convert.ToInt32(cboStDay.SelectedValue));
        _oLightingActivityTracking.JSACode = Convert.ToInt16(txtJSACode.Text.ToString());
        _oLightingActivityTracking.TotalOutlet = Convert.ToInt16(txtTotalOutlet.Text.ToString());
        _oLightingActivityTracking.CashMemo = Convert.ToInt16(txtCashMemo.Text.ToString());
        _oLightingActivityTracking.TGTTO = Convert.ToInt16(txtTgtTO.Text.ToString());
        _oLightingActivityTracking.SalesTO = Convert.ToInt16(txtSalesTO.Text.ToString());
        _oLightingActivityTracking.CFLTGTQty = Convert.ToInt16(txtCFLTGTQty.Text.ToString());
        _oLightingActivityTracking.CFLSalesTO = Convert.ToInt16(txtCFLSalesQty.Text.ToString());

        DBController.Instance.BeginNewTransaction();
        _oLightingActivityTracking.Add();
        lblSave.Visible = true;
        lblSave.Text = "TSM Tracking Information Save Successfully";
        DBController.Instance.CommitTransaction();
       
        
    }





    protected void txtCustomerCode_TextChanged(object sender, EventArgs e)
    {
        btGo_Click1(null, null);
    }
    protected void btGo_Click1(object sender, EventArgs e)
    {
        if (txtCustomerCode.Text != "")
        {
            lblMessage.Visible = false;
            DBController.Instance.OpenNewConnection();
            _oCustomer = new Customer();
            _oCustomer.CustomerCode = txtCustomerCode.Text;
            _oCustomer.GetCustomerID();
            if (_oCustomer.Flag == false)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please Input Valid Customer Code";
                return;
            }
            txtCustomerName.Text = _oCustomer.CustomerName;
            txtAddress.Text = _oCustomer.CustomerAddress;
                     

            DBController.Instance.CloseConnection();
        }


    }
    protected void btCustomerSearch_Click1(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            Save();
        }
    }
    
}

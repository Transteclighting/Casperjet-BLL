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

public partial class frmCustomerLst : System.Web.UI.Page
{
    private CustomerDetails _oCustomerDetails;
    private Channels _oChanneles;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Loadcb();
        }
    }    
    protected void btnShow_Click(object sender, EventArgs e)
    {      
        _oChanneles = (Channels)Session["Channeles"];
        int nUserID = Convert.ToInt32(Session["UserID"].ToString());

        DBController.Instance.OpenNewConnection();
        _oCustomerDetails = new CustomerDetails();
        _oCustomerDetails.RefreshForSalesOrder(_oChanneles[cmbChannel.SelectedIndex].ChannelID, int.Parse(cmbActive.SelectedValue.ToString()), txtCustomerCode.Text, txtName.Text, nUserID);
        DBController.Instance.CloseConnection();

        grdItemList.DataSource = _oCustomerDetails;
        grdItemList.DataBind();
       
    }
    public void Loadcb()
    {
        DBController.Instance.OpenNewConnection();
        _oChanneles = new Channels();
        _oChanneles.Refresh();

        cmbChannel.DataSource = _oChanneles;
        cmbChannel.DataTextField = "ChannelDescription";
        cmbChannel.DataBind();
        cmbChannel.SelectedIndex = cmbChannel.Items.Count - 1;
        DBController.Instance.CloseConnection();
        Session.Add("Channeles", _oChanneles);

    }
    
}

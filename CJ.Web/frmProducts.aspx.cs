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

public partial class frmProducts : System.Web.UI.Page
{
    Products _oProducts;

    protected void Page_Load(object sender, EventArgs e)
    {
        _oProducts = new Products();
        DBController.Instance.OpenNewConnection();
        _oProducts.Refresh();

        dvwProducts.DataSource = _oProducts;
        dvwProducts.DataBind();
        Table1.Rows[0].Cells[0].InnerText = "Products " + "[" + _oProducts.Count+ "]";
    }

    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("CODE");
        //oDSMarketGroup = (DSMarketGroup)Session["DataTable"];
        LinkButton link = (LinkButton)sender;
        foreach (Product oProduct in _oProducts)
        {
            if (oProduct.ProductCode == link.Text)
            {
                Session.Add("CODE", oProduct);
                break;
            }
        }

        Response.Redirect("frmProduct.aspx");

    }

    protected void dvwProducts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAdd2_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmProduct.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmReportViewer.aspx");
    }
}

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

public partial class frmInvoices : System.Web.UI.Page
{
    Invoices _oInvoices;

    public void EditItem(Object sender, EventArgs e)
    {
        Session.Remove("InvoiceNo");
        //oDSMarketGroup = (DSMarketGroup)Session["DataTable"];
        LinkButton link = (LinkButton)sender;
        foreach (Invoice oInvoice in _oInvoices)
        {
            if (oInvoice.InvoiceNo == link.Text)
            {
                Session.Add("InvoiceNo", oInvoice);
                break;
            }
        }

        Response.Redirect("frmInvoice.aspx");

    }
    protected void btnAdd2_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmInvoice.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        _oInvoices = new Invoices();
        _oInvoices.Refresh();

        dvwInvoices.DataSource = _oInvoices;
        dvwInvoices.DataBind();
        Table1.Rows[0].Cells[0].InnerText = "Invoices " + "[" + _oInvoices.Count + "]";

    }

}

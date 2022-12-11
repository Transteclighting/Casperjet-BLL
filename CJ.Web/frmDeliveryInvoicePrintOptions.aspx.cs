using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Specialized;
using CrystalDecisions.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
using CrystalDecisions.Shared;
using CJ.Class;


public partial class frmDeliveryInvoicePrintOptions : System.Web.UI.Page
{
    private static ReportClass doc = new ReportClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        bool _bIsReprint = (bool)Session["IsReprint"];
        if (_bIsReprint == true)
        {
            lbMsg.Visible = false;
            btCustomerCopy.Text = "RePrint Invoice(Customer Copy) ";
            btGetpassCopy.Text = "RePrint Invoice(Getpass Copy) ";
            btWarehouseCopy.Text = "RePrint Invoice(Warehouse Copy) ";           
        }
        else
        {
            lbMsg.Visible = true;
            btCustomerCopy.Text = "Print Invoice(Customer Copy) ";
            btGetpassCopy.Text = "Print Invoice(Getpass Copy) ";
            btWarehouseCopy.Text = "Print Invoice(Warehouse Copy) ";           
        }
        if (Utility.CompanyInfo == "TEL")
        {
            btPrintVatchallan.Visible = true;
        }
        else btPrintVatchallan.Visible = false;
      
    }  
    protected void btPrintVatchallan_Click(object sender, EventArgs e)
    {
        object doc = (object)Session["VatChallanDoc"];
        Session.Remove("Doc");
        Session.Add("Doc", doc);
        Session["ReportName"] = "Invoice System(VatChallan) [VAT]";
      
        Response.Redirect("~/Report/frmReportViewer.aspx");
    }   
  
    protected void btCustomerGoodsReceived_Click(object sender, EventArgs e)
    {
        doc = (ReportClass)Session["InvoiceDocCus"];
        if (Utility.CompanyInfo != "BLL")
        {
            doc.SetParameterValue("CompanyInfo", Utility.CompanyInfo);
        }
        Session.Remove("Doc");
        Session.Add("Doc", doc);
        Session["ReportName"] = "Invoice System(Invoice- Customer Goods Received Copy) [INV]";
        Response.Redirect("~/Report/frmReportViewer.aspx");
    }
  
    protected void btCustomerCopy_Click(object sender, EventArgs e)
    {
        doc = (ReportClass)Session["InvoiceDoc"];
        doc.SetParameterValue("InvoiceHeader", "Customer Copy");
        if (Utility.CompanyInfo != "BLL")
        {
            doc.SetParameterValue("CompanyInfo", Utility.CompanyInfo);
        }
        Session.Remove("Doc");
        Session.Add("Doc", doc);
        Session["ReportName"] = "Invoice System(Delivery Invoice) [INV]";
        Response.Redirect("~/Report/frmReportViewer.aspx");
    }
    protected void btWarehouseCopy_Click(object sender, EventArgs e)
    {
        doc = (ReportClass)Session["InvoiceDoc"];
        doc.SetParameterValue("InvoiceHeader", "Warehouse Copy");
        if (Utility.CompanyInfo != "BLL")
        {
            doc.SetParameterValue("CompanyInfo", Utility.CompanyInfo);
        }
        Session.Remove("Doc");
        Session.Add("Doc", doc);       
        Session["ReportName"] = "Invoice System(Delivery Invoice) [INV]";
        Response.Redirect("~/Report/frmReportViewer.aspx");
    }
    protected void btGetpassCopy_Click(object sender, EventArgs e)
    {
        doc = (ReportClass)Session["InvoiceDoc"];
        doc.SetParameterValue("InvoiceHeader", "Get Pass Copy");
        if (Utility.CompanyInfo != "BLL")
        {
            doc.SetParameterValue("CompanyInfo", Utility.CompanyInfo);
        }
        Session.Remove("Doc");
        Session.Add("Doc", doc);
        Session["ReportName"] = "Invoice System(Delivery Invoice) [INV]";
        Response.Redirect("~/Report/frmReportViewer.aspx");
    }
}

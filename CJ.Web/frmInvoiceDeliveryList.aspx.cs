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

public partial class frmInvoiceDeliveryList : System.Web.UI.Page
{
    SalesInvoices _oSalesInvoices;
    CustomerTransaction _oCustomerTransaction;
    DateTime _dFromDate;
    DateTime _dToDate;
    Utilities _oUtilitys;
    int nUserID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            _oUtilitys = new Utilities();
            cbSatus.Items.Clear();
            _oUtilitys.GetInvoiceStatus();
            cbSatus.DataSource = _oUtilitys;
            cbSatus.DataTextField = "Satus";
            cbSatus.DataBind();
            cbSatus.SelectedIndex = cbSatus.Items.Count - 1;

            cbFDay.Text = DateTime.Today.Day.ToString();
            cbFMonth.Text = DateTime.Today.Month.ToString();
            cbFYear.Text = DateTime.Today.Year.ToString();
            cbTDay.Text = DateTime.Today.Day.ToString();
            cbTMonth.Text = DateTime.Today.Month.ToString();
            cbTYear.Text = DateTime.Today.Year.ToString();

            Session.Add("Utilitys", _oUtilitys);
            lnkShowdata_Click(null,null);
        }
    }
    protected void lnkShowdata_Click(object sender, EventArgs e)
    {
        try
        {
            _dFromDate = new DateTime(Convert.ToInt32(cbFYear.SelectedValue), Convert.ToInt32(cbFMonth.SelectedValue), Convert.ToInt32(cbFDay.SelectedValue));
        }
        catch
        {
            lblMessage.Text = "Input Date is not correct Formate";
            lblMessage.Visible = true;
            return;
        }
        try
        {
            _dToDate = new DateTime(Convert.ToInt32(cbTYear.SelectedValue), Convert.ToInt32(cbTMonth.SelectedValue), Convert.ToInt32(cbTDay.SelectedValue));
        }
        catch
        {
            lblMessage.Text = "Input Date is not correct Formate";
            lblMessage.Visible = true;
            return;
        }
        lblMessage.Visible = false;
        RefreshGrid();
        Table1.Rows[0].Cells[0].InnerText = "SalesInvoice" + "[" + dvwInvoiceDelivery.Rows.Count + "]";
    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
        dt.Columns.Add(new DataColumn("OrderNo", typeof(string)));
        dt.Columns.Add(new DataColumn("CustomerCode", typeof(string)));
        dt.Columns.Add(new DataColumn("CustomerName", typeof(string)));
        dt.Columns.Add(new DataColumn("InvoiceDate", typeof(string)));
        dt.Columns.Add(new DataColumn("InvoiceAmount", typeof(string)));
        dt.Columns.Add(new DataColumn("InvoiceBy", typeof(string)));
        dt.Columns.Add(new DataColumn("DeliveredBy", typeof(string)));
        dt.Columns.Add(new DataColumn("InvoiceStatus", typeof(string)));
        dt.Columns.Add(new DataColumn("CTNo", typeof(string)));

        DBController.Instance.OpenNewConnection();
        _oSalesInvoices = new SalesInvoices();

        _oUtilitys = (Utilities)Session["Utilitys"];
        nUserID = Convert.ToInt32(Session["UserID"].ToString());
        _oSalesInvoices.RefreshForInvoiceDelivery(_dFromDate, _dToDate, _oUtilitys[cbSatus.SelectedIndex].SatusId, txtInvoiceNo.Text, txtCustomerCode.Text, txtCustomerName.Text, nUserID);

        foreach (SalesInvoice _SalesInvoice in _oSalesInvoices)
        {

            _SalesInvoice.OrderNo = txtOrderNo.Text;

            DateTime _dDate = Convert.ToDateTime(_SalesInvoice.InvoiceDate);

            dr = dt.NewRow();
            dr["InvoiceNo"] = _SalesInvoice.InvoiceNo;
            dr["OrderNo"] = _SalesInvoice.SalesOrder.OrderNo;
            dr["CustomerCode"] = _SalesInvoice.SalesOrder.Customer.CustomerCode;
            dr["CustomerName"] = _SalesInvoice.SalesOrder.Customer.CustomerName;
            dr["InvoiceDate"] = _dDate.ToString("dd-MMM-yyyy");
            dr["InvoiceAmount"] = _SalesInvoice.InvoiceAmount.ToString();

            if (_SalesInvoice.DeliveryUser.Username != "")
                dr["DeliveredBy"] = _SalesInvoice.DeliveryUser.Username;
            else dr["DeliveredBy"] = "NA";
            if (_SalesInvoice.InvoiceUser.Username != "")
                dr["InvoiceBy"] = _SalesInvoice.InvoiceUser.Username;
            else dr["InvoiceBy"] = "NA";

            if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.CANCEL)
            {
                dr["InvoiceStatus"] = "CANCEL";
            }
            if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.DELIVERED)
            {
                dr["InvoiceStatus"] = "DELIVERED";
            }
            if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PENDING)
            {
                dr["InvoiceStatus"] = "PENDING";
            }
            if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PROCESSING_DELIVERY)
            {
                dr["InvoiceStatus"] = "PROCESSING DELIVERY";
            }
            if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.PRODUCT_RETURN)
            {
                dr["InvoiceStatus"] = "PRODUCT RETURN";
            }
            if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.REVERSE)
            {
                dr["InvoiceStatus"] = "REVERSE"; ;
            }
            if (_SalesInvoice.InvoiceStatus == (int)Dictionary.InvoiceStatus.UNDELIVERED)
            {
                dr["InvoiceStatus"] = "UNDELIVERED";
            }

            if (_SalesInvoice.InvoiceStatus == (short)Dictionary.InvoiceStatus.UNDELIVERED_DUE_TO_STOCK_LIMIT)
            {
                dr["InvoiceStatus"] = "UNDELIVERED DUE TO STOCK LIMIT";
            }

            _oCustomerTransaction = new CustomerTransaction();
            _oCustomerTransaction.InvoiceID = _SalesInvoice.InvoiceID;
            _oCustomerTransaction.GetTranID();
            _oCustomerTransaction.Refresh();

            if (_oCustomerTransaction.TranNo != "")
                dr["CTNo"] = _oCustomerTransaction.TranNo;
            else dr["CTNo"] = "NA";

            dt.Rows.Add(dr);
            if (dr["CustomerCode"].ToString() == "")
                dt.Rows.Remove(dr);


        }
        DBController.Instance.CloseConnection();
        //dr = dt.NewRow();
        //Store the DataTable in ViewState

        ViewState["SalesInvoiceTable"] = dt;
        dvwInvoiceDelivery.DataSource = dt;
        dvwInvoiceDelivery.DataBind();
        Session.Add("SalesInvoices", _oSalesInvoices);
    }
}

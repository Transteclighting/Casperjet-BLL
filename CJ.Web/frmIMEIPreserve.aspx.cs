using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using CJ.Class;

public partial class frmIMEIPreserve : System.Web.UI.Page
{
    SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
    SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
    string sSplit = "";
    long _InvoiceID = 0;
    SalesInvoice _oSalesInvoice;
    protected void Page_Load(object sender, EventArgs e)
    {
        _InvoiceID = 0;
        if (!IsPostBack)
        {
            _oSalesInvoice = (SalesInvoice)Session["SalesInvoice"];


            DBController.Instance.OpenNewConnection();
            _oSalesInvoice.GetInvoiceByInvoID(_oSalesInvoice.InvoiceID);
            DBController.Instance.CloseConnection();
            _InvoiceID = _oSalesInvoice.InvoiceID;
            lblOrderNo.Text = _oSalesInvoice.OrderNo;
            lblInvoiceNo.Text = _oSalesInvoice.InvoiceNo;
            lblCustomerCode.Text = _oSalesInvoice.CustomerCode;
            lblCustomerName.Text = _oSalesInvoice.CustomerName;
            int Qty = _oSalesInvoice.Qty;
            RefreshGrid();
            txtIMEI.Height = 25 * Qty;
        }
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (validateUIInput())
        {
            Save();
        } 

    }
    private void RefreshGrid()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("ProductID", typeof(int)));
        dt.Columns.Add(new DataColumn("ProductCode", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
        dt.Columns.Add(new DataColumn("Serial", typeof(int)));
        dt.Columns.Add(new DataColumn("IMEINo", typeof(string)));
        

        DBController.Instance.OpenNewConnection();

        _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();


        _oSalesInvoiceProductSerials.RefreshByInvoiceID(_InvoiceID);

        foreach (SalesInvoiceProductSerial oSalesInvoiceProductSerial in _oSalesInvoiceProductSerials)
        {
            for (int i = 0; i < oSalesInvoiceProductSerial.Quantity; i++)
            {
                dr = dt.NewRow();

                dr["ProductID"] = oSalesInvoiceProductSerial.ProductID;
                dr["ProductCode"] = oSalesInvoiceProductSerial.ProductCode;
                dr["ProductName"] = oSalesInvoiceProductSerial.ProductName;
                dr["Serial"] = i + 1;
                dr["IMEINo"] = "";

                dt.Rows.Add(dr);
            }

        }
        DBController.Instance.CloseConnection();

        ViewState["IMEITable"] = dt;
        dvwIMEI.DataSource = dt;
        dvwIMEI.DataBind();
        Session.Add("IMEIs", _oSalesInvoiceProductSerials);
    }
    private void Save()
    {
        if (ViewState["IMEITable"] != null)
        {
            DataTable dt = (DataTable)ViewState["IMEITable"];
            _oSalesInvoice = (SalesInvoice)Session["SalesInvoice"];


            DBController.Instance.OpenNewConnection();
            _oSalesInvoice.GetInvoiceByInvoID(_oSalesInvoice.InvoiceID);
            //DBController.Instance.CloseConnection();
            _InvoiceID = _oSalesInvoice.InvoiceID;

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    SalesInvoiceProductSerial oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                    Label lblProductID = (Label)dvwIMEI.Rows[i].Cells[1].FindControl("ProductID");
                    Label lblSerial = (Label)dvwIMEI.Rows[i].Cells[3].FindControl("Serial");
                    TextBox txtIMEINo = (TextBox)dvwIMEI.Rows[i].Cells[4].FindControl("IMEINo");

                    oSalesInvoiceProductSerial.InvoiceID = _InvoiceID;
                    oSalesInvoiceProductSerial.ProductID = Convert.ToInt32(lblProductID.Text);
                    oSalesInvoiceProductSerial.SerialNo = Convert.ToInt32(lblSerial.Text);
                    oSalesInvoiceProductSerial.ProductSerialNo = txtIMEINo.Text;
                    DBController.Instance.BeginNewTransaction();
                    oSalesInvoiceProductSerial.AddIMEI();
                    DBController.Instance.CommitTran();
                }
            }
            string[] sSuccedCode =  { " " };
            Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
            UIUtility.GetConfirmationMsg("Save", "The IMEI", sSuccedCode, null, "frmInvoiceDelivery.aspx", 0);
            Response.Redirect("frmMessage.aspx");
        }
    }

    public bool validateUIInput()
    {
        DataTable dt = (DataTable)ViewState["IMEITable"];
        int xx = 0;
        if (dt.Rows.Count > 0)
        {

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                TextBox txtIMEINo = (TextBox)dvwIMEI.Rows[x].Cells[4].FindControl("IMEINo");
                Label txtProductID = (Label)dvwIMEI.Rows[x].Cells[1].FindControl("ProductID");

                xx = Convert.ToInt32(txtProductID.Text);
                if (txtIMEINo.Text != "")
                {
                    _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                    _oSalesInvoiceProductSerial.ProductSerialNo = txtIMEINo.Text;
                    _oSalesInvoiceProductSerial.ProductID = Convert.ToInt32(txtProductID.Text.ToString());
                    DBController.Instance.OpenNewConnection();

                    if (_oSalesInvoiceProductSerial.CheckProductSerial())
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "The Barcode already Used";
                        setListViewRowColor(true);
                        return false;
                    }
                    else
                    {
                        setListViewRowColor(false);
                    }
                    if (_oSalesInvoiceProductSerial.CheckIMEI())
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Invalid IMEI Number";
                        setListViewRowColor(true);
                        return false;
                    }
                    else
                    {
                        setListViewRowColor(false);
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Please Input IMEI Number";
                    setListViewRowColor(true);
                    return false;

                }
            }
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.Text = "There is no data";
            return false;
        }
        return true;
    }
    private void setListViewRowColor(bool IsTrue)
    {
        DataTable dt = (DataTable)ViewState["IMEITable"];

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Label lblProductID = (Label)dvwIMEI.Rows[i].Cells[1].FindControl("ProductID");

                if (Convert.ToInt32(lblProductID.Text.ToString()) != 0)
                {
                    if (IsTrue == true)
                    {
                        GridViewRow oRow = dvwIMEI.Rows[i];
                        oRow.ForeColor = Color.Red;
                        oRow.Font.Bold = true;
                    }
                    else
                    {
                        GridViewRow oRow = dvwIMEI.Rows[i];
                        oRow.ForeColor = Color.White;
                        oRow.Font.Bold = false;
                    }
                }
            }
        }
    }
    protected void btMove_Click(object sender, EventArgs e)
    {
        string value = txtIMEI.Text;
        char[] delimiter = new char[] { '\r', '\n' };
        string[] parts = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < parts.Length; i++)
        {
            sSplit = parts[i].ToString();

            _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
            _oSalesInvoiceProductSerial.ProductSerialNo = sSplit.Trim();
            DBController.Instance.OpenNewConnection();
            _oSalesInvoiceProductSerial.GetProductIDByIMEI();
            DBController.Instance.CloseConnection();

            string xyz = "";

            DataTable dtCondition = (DataTable)ViewState["IMEITable"];
            if (dtCondition.Rows.Count > 0)
            {
                for (int x = 0; x < dtCondition.Rows.Count; x++)
                {
                    TextBox txtIMEINo = (TextBox)dvwIMEI.Rows[x].Cells[4].FindControl("IMEINo");
                    Label lblProductCode = (Label)dvwIMEI.Rows[x].Cells[2].FindControl("ProductCode");

                    if (txtIMEINo.Text == null || txtIMEINo.Text.Trim() == "")
                    {
                        if (lblProductCode.Text + xyz.Trim() == _oSalesInvoiceProductSerial.ProductCode)
                        {
                            txtIMEINo.Text = _oSalesInvoiceProductSerial.ProductSerialNo;
                            xyz = sSplit.Trim();
                        }
                    
                    }
                }
            }

        }
        txtIMEI.Text = "";
    }
}

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

public partial class frmInvoice : System.Web.UI.Page
{
    Products _oProducts;
    Product _oProduct;
    private int _nRowIndex;
    public string _sCustomerCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _oProducts = new Products();
            cboProduct.Items.Clear();
            _oProducts.Refresh();
            cboProduct.DataSource = _oProducts;
            cboProduct.DataTextField = "ProductCode";
            cboProduct.DataBind();
            txtName.Text = _oProducts[cboProduct.SelectedIndex].ProductName;  
            Session.Add("Products", _oProducts);


            //DSInvoiceItem oDS = new DSInvoiceItem();
            //gvwInvoiceItem.DataSource = oDS;
            //gvwInvoiceItem.DataBind();

            SetInitialRow();
        }
    }

    private void SetInitialRow()
    {

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("ItemNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductCode", typeof(string)));
        dt.Columns.Add(new DataColumn("ProductName", typeof(string)));
        dt.Columns.Add(new DataColumn("UnitPrice", typeof(string)));
        dt.Columns.Add(new DataColumn("Qty", typeof(string)));
        dt.Columns.Add(new DataColumn("TotalPrice", typeof(string)));

        dr = dt.NewRow();

        dr["ItemNumber"] = 1;
        dr["ProductCode"] = string.Empty;
        dr["ProductName"] = string.Empty;
        dr["UnitPrice"] = string.Empty;
        dr["Qty"] = string.Empty;
        dr["TotalPrice"] = string.Empty;

        dt.Rows.Add(dr);

        //dr = dt.NewRow();
        //Store the DataTable in ViewState

        ViewState["InvoiceTable"] = dt;
        gvwInvoiceItem.DataSource = dt;
        gvwInvoiceItem.DataBind();
       
    }
    private void AddToGrid(bool Istrue)
    {

        _nRowIndex = 0;

        if (ViewState["InvoiceTable"] != null)
        {
            int i;
            DataTable dtInvoiceTable = (DataTable)ViewState["InvoiceTable"];
            DataRow drInvoiceRow = null;

            if (dtInvoiceTable.Rows.Count > 0)
            {

                for (i = 1; i <= dtInvoiceTable.Rows.Count; i++)
                {
                    //extract the TextBox values

                    TextBox box1 = (TextBox)gvwInvoiceItem.Rows[_nRowIndex].Cells[1].FindControl("TextBox1");
                    TextBox box2 = (TextBox)gvwInvoiceItem.Rows[_nRowIndex].Cells[2].FindControl("TextBox2");
                    TextBox box3 = (TextBox)gvwInvoiceItem.Rows[_nRowIndex].Cells[3].FindControl("TextBox3");
                    TextBox box4 = (TextBox)gvwInvoiceItem.Rows[_nRowIndex].Cells[4].FindControl("TextBox4");
                    TextBox box5 = (TextBox)gvwInvoiceItem.Rows[_nRowIndex].Cells[5].FindControl("TextBox5");

                    drInvoiceRow = dtInvoiceTable.NewRow();
                    drInvoiceRow["ItemNumber"] = i + 1;


                    dtInvoiceTable.Rows[i - 1]["ProductCode"] = box1.Text;
                    _oProduct = new Product();
                    _oProduct.ProductCode = box1.Text;
                    _oProduct.Refresh();
                    dtInvoiceTable.Rows[i - 1]["ProductName"] = _oProduct.ProductName;
                    dtInvoiceTable.Rows[i - 1]["UnitPrice"] = box3.Text;
                    dtInvoiceTable.Rows[i - 1]["Qty"] = box4.Text;
                    try
                    {
                        dtInvoiceTable.Rows[i - 1]["TotalPrice"] = (Convert.ToDouble(box3.Text) * Convert.ToDouble(box4.Text));
                    }
                    catch
                    {
                        dtInvoiceTable.Rows[i - 1]["TotalPrice"] = "";
                        Istrue = false;
                    }
                    _nRowIndex++;

                }

                if (Istrue == true)                
                    dtInvoiceTable.Rows.Add(drInvoiceRow);                   
                
                ViewState["InvoiceTable"] = dtInvoiceTable;
                gvwInvoiceItem.DataSource = dtInvoiceTable;
                gvwInvoiceItem.DataBind();

                if (Istrue == true)
                    gvwInvoiceItem.Rows[_nRowIndex].Cells[1].Focus();

            }
        }
        else
        {
            Response.Write("ViewState is null");
        }        
        //Set Previous Data on Postbacks

        SetPreviousData();

    }

    private void SetPreviousData()
    {
        _nRowIndex = 0;

        if (ViewState["InvoiceTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["InvoiceTable"];

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)gvwInvoiceItem.Rows[_nRowIndex].Cells[1].FindControl("TextBox1");
                    TextBox box2 = (TextBox)gvwInvoiceItem.Rows[_nRowIndex].Cells[2].FindControl("TextBox2");
                    TextBox box3 = (TextBox)gvwInvoiceItem.Rows[_nRowIndex].Cells[3].FindControl("TextBox3");
                    TextBox box4 = (TextBox)gvwInvoiceItem.Rows[_nRowIndex].Cells[4].FindControl("TextBox4");
                    TextBox box5 = (TextBox)gvwInvoiceItem.Rows[_nRowIndex].Cells[5].FindControl("TextBox5");


                    box1.Text = dt.Rows[i]["ProductCode"].ToString();
                    box2.Text = dt.Rows[i]["ProductName"].ToString();
                    box3.Text = dt.Rows[i]["UnitPrice"].ToString();
                    box4.Text = dt.Rows[i]["Qty"].ToString();
                    box5.Text = dt.Rows[i]["TotalPrice"].ToString();

                    _nRowIndex++;

                }
            }
        }
    }
    protected void TextBox1_TextChanged(object sender, System.EventArgs e)
    {
        AddToGrid(false);       
        gvwInvoiceItem.Rows[_nRowIndex-1].Cells[3].Focus();
           
    }
    protected void TextBox3_TextChanged(object sender, System.EventArgs e)
    {
        AddToGrid(false);   
        gvwInvoiceItem.Rows[_nRowIndex-1].Cells[4].Focus();
    }
    protected void TextBox4_TextChanged(object sender, System.EventArgs e)
    {
        AddToGrid(true);
    }
   



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //DSInvoiceItem oDS = (DSInvoiceItem)Session["DSInvoiceItem"];
        //if (oDS == null)
        //{
        //    oDS = new DSInvoiceItem();
        //}
        
        //_oProducts = (Products)Session["Products"];

        //oDS.InvoiceItem.AddInvoiceItemRow(_oProducts[cboProduct.SelectedIndex].ProductID, cboProduct.Text, txtName.Text, Convert.ToInt32(txtQty.Text));  
        //gvwInvoiceItem.DataSource = oDS;
        //gvwInvoiceItem.DataBind();
        //Session.Add("DSInvoiceItem", oDS);
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtInvoiceDate.Text = Calendar1.SelectedDate.ToString("dd-MMM-yyyy");
        Calendar1.Visible = false;
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Invoice oInvoice = (Invoice)Session["Invoice"];
        //if (oInvoice != null)
        //{
        //    oInvoice.InvoiceNo = txtInvoiceNo.Text;
        //    oInvoice.InvoiceDate =Convert.ToDateTime(txtInvoiceDate.Text);
        //    oInvoice.CustomerName = txtCustomerName.Text;
        //    oInvoice.CustomerAddress= txtCustomerAddress.Text;
        //    oInvoice.Edit();
        //}
        //else
        //{
        //    oInvoice = new Invoice();
        //    oInvoice.InvoiceNo = txtInvoiceNo.Text;
        //    oInvoice.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
        //    oInvoice.CustomerName = txtCustomerName.Text;
        //    oInvoice.CustomerAddress = txtCustomerAddress.Text;

        //    DSInvoiceItem oDS = (DSInvoiceItem)Session["DSInvoiceItem"];
        //    foreach (DSInvoiceItem.InvoiceItemRow oRow in oDS.InvoiceItem)
        //    {
        //        InvoiceItem oInvoiceItem=new InvoiceItem();
        //        oInvoiceItem.ProductID = oRow.ProductID;
        //        oInvoiceItem.Qty = oRow.Qty;
        //        oInvoice.Add(oInvoiceItem);
        //    }
        //    oInvoice.Add();
        //}
        //Session.Remove("Invoice");
    }
    protected void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        _oProducts = (Products)Session["Products"];
        txtName.Text = _oProducts[cboProduct.SelectedIndex].ProductName;  
    }
    protected void gvwInvoiceItem_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        Calendar1.Visible = true;
    }

}

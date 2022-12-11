using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.POS;

namespace CJ.POS.RT
{
    public partial class frmAvailableBarcode : Form
    {
        ProductDetail _oProductDetail;
        Product _oProduct;
        ProductBarcodes oProductBarcodes;
        public ProductBarcode _oProductBarcode;
        int _nProductID;
        int _nWarehouseID;
        public int _nCount = 0;
        public string _sBarcode = "";
        public string _sChkBarcode = "";
        string _sBarcodeForDefective = "";
        public string _sIsBarcodeForDefective = "";
        int _nIsInvoice = 0;


       // SystemInfo _oSystemInfo;
        public frmAvailableBarcode(int nProductID, int nWarehouseID,string sBarcodeForDefective,int nIsInvoice)
        {
            InitializeComponent();
            _nProductID = nProductID;
            _nWarehouseID = nWarehouseID;
            _sBarcodeForDefective = sBarcodeForDefective;
            _nIsInvoice = nIsInvoice;

        }
       
        private void frmAvailableBarcode_Load(object sender, EventArgs e)
        {
            CJ.Class.DBController.Instance.OpenNewConnection();
            
            //_oSystemInfo = new SystemInfo();
            //_oSystemInfo.Refresh();

            _oProduct = new Product();
            _oProduct.ProductID = _nProductID;
            _oProduct.RefreshByProductID();

            label1.Text = "Available Barcode List for";
            label2.Text = _oProduct.ProductName;

            lvBarcode.Items.Clear();
            oProductBarcodes = new ProductBarcodes();
            oProductBarcodes.GetProductBarcodeRT(_nProductID, _nWarehouseID);       

            foreach (ProductBarcode oProductBarcode in oProductBarcodes)
            {
                ListViewItem oItem = lvBarcode.Items.Add(oProductBarcode.ProductSerialNo);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oProductBarcode.IsVatPaidProduct));
                oItem.SubItems.Add(oProductBarcode.SaleAfter);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oProductBarcode.IsDefective));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oProductBarcode.IsTransitStock));
                //if (oProductBarcode.IsActive == (int)Dictionary.BarcodeIsActive.Active)
                //oItem.SubItems.Add("Available");
                //if (oProductBarcode.IsActive == (int)Dictionary.BarcodeIsActive.Lock)
                //oItem.SubItems.Add("Lock");

                oItem.Tag = oProductBarcode;
            }
            CJ.Class.DBController.Instance.CloseConnection();
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            if (lvBarcode.Items.Count <=0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < lvBarcode.Items.Count; i++)
            {
                ListViewItem itm = lvBarcode.Items[i];
                if (lvBarcode.Items[i].Checked == true )
                {                 
                    _oProductBarcode = (ProductBarcode)lvBarcode.Items[i].Tag;
                    if (_oProductBarcode.IsTransitStock == (int)Dictionary.YesOrNoStatus.NO)
                    {

                        _nCount++;
                        if (_sBarcode == "")
                        {
                            _sBarcode = _oProductBarcode.ProductSerialNo;
                            _sChkBarcode = "'" + _oProductBarcode.ProductSerialNo + "'";
                        }
                        else
                        {
                            _sBarcode = _sBarcode + "," + _oProductBarcode.ProductSerialNo;
                            _sChkBarcode = _sChkBarcode + "," + "'" + _oProductBarcode.ProductSerialNo + "'";
                        }
                    }
                    else
                    {
                        MessageBox.Show("You cannot select product serial from transit stock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }       

            this.Close();
        }

        private void lvBarcode_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_nIsInvoice == 1)
            {
                if (_sBarcodeForDefective == "")
                {
                    if (lvBarcode.Items[e.Item.Index].Checked)
                    {
                        _sIsBarcodeForDefective = lvBarcode.Items[e.Item.Index].SubItems[3].Text;
                        _sBarcodeForDefective = lvBarcode.Items[e.Item.Index].SubItems[3].Text;
                    }
                }


                if (_sBarcodeForDefective != "")
                {
                    if (lvBarcode.Items[e.Item.Index].Checked)
                    {
                        if (_sBarcodeForDefective != lvBarcode.Items[e.Item.Index].SubItems[3].Text)
                        {
                            lvBarcode.Items[e.Item.Index].Checked = false;
                            MessageBox.Show("You cannot select Defective and Sound Product in same Invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }


            if (lvBarcode.Items[e.Item.Index].Checked)
            {
                if(lvBarcode.Items[e.Item.Index].SubItems[2].Text!="")
                {
                    if (Convert.ToDateTime(lvBarcode.Items[e.Item.Index].SubItems[2].Text) > DateTime.Now.Date)
                    {
                        lvBarcode.Items[e.Item.Index].Checked = false;
                        MessageBox.Show("This Display Item cannot be sold. Sale After the Date of: "+ Convert.ToDateTime(lvBarcode.Items[e.Item.Index].SubItems[2].Text).ToString("dd-MMM-yyyy"), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
        }

        int nCount = 0;
        string sSplit = "";
        
        private void btnValidateBarcode_Click(object sender, EventArgs e)
        {
            if (txtIMEIList.Text.Trim() != "")
            {
                txtIMEIList.ForeColor = Color.Red;
                string value = txtIMEIList.Text;
                char[] delimiter = new char[] { '\r', '\n' };
                string[] parts = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parts.Length; i++)
                {
                    nCount = 0;
                    sSplit = parts[i].ToString();
                    foreach (ProductBarcode oProductBarcode in oProductBarcodes)
                    {
                        if(oProductBarcode.ProductSerialNo== sSplit.Trim() && (oProductBarcode.SaleAfter.ToString()==""|| Convert.ToDateTime(oProductBarcode.SaleAfter)<DateTime.Today.Date)&& oProductBarcode.IsDefective==(int)Dictionary.YesOrNoStatus.NO)
                        {
                            lvBarcode.Items[nCount].Checked = true;
                            txtIMEIList.Text = txtIMEIList.Text.Replace(sSplit.Trim(),"");
                            break;
                        }
                        else 
                        {
                            if (oProductBarcode.ProductSerialNo == sSplit.Trim() && oProductBarcode.SaleAfter.ToString() != "" && Convert.ToDateTime(oProductBarcode.SaleAfter) > DateTime.Today.Date)
                            {
                                MessageBox.Show("'"+sSplit.Trim()+ "'-" + "This is display product, Sale After: "+ oProductBarcode.SaleAfter, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (txtIMEIList.Text.Contains(sSplit.Trim()))
                                {
                                    txtIMEIList.Select(txtIMEIList.Text.IndexOf(sSplit.Trim()), sSplit.Trim().Length);
                                    txtIMEIList.SelectionColor = Color.Black;
                                }
                                break;
                            }
                            else if(oProductBarcode.ProductSerialNo == sSplit.Trim() && oProductBarcode.IsDefective == (int)Dictionary.YesOrNoStatus.YES )
                            {
                                if (_nIsInvoice == 1)
                                {
                                    MessageBox.Show("'" + sSplit.Trim() + "'-" + "This is Defective Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    if (txtIMEIList.Text.Contains(sSplit.Trim()))
                                    {
                                        txtIMEIList.Select(txtIMEIList.Text.IndexOf(sSplit.Trim()), sSplit.Trim().Length);
                                        txtIMEIList.SelectionColor = Color.Black;
                                    }
                                    break;
                                }
                                else
                                {
                                    lvBarcode.Items[nCount].Checked = true;
                                    txtIMEIList.Text = txtIMEIList.Text.Replace(sSplit.Trim(), "");
                                    break;
                                }
                            }
                        }
                        nCount++;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("There is no Barcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
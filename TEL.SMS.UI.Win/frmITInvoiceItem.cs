using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.BE;

namespace TEL.SMS.UI.Win
{
    public partial class frmITInvoiceItem : Form
    {
        private ITProduct _oITProduct;
        public frmITInvoiceItem()
        {
            InitializeComponent();
        }

        public void ShowDialog(ITProduct oITProduct)
        {
            _oITProduct = oITProduct;
            this.ShowDialog();
        }

        private bool ValidateUI()
        {            
            if (this.txtQty.Text == "")
            {
                DialogResult o = MessageBox.Show("Please Insert Quantity.", "IT Invoice Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtQty.Focus();
                return false;
            }
            if (this.txtUnitPrice.Text == "")
            {
                DialogResult o = MessageBox.Show("Please Insert Unit Price.", "IT Invoice Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtUnitPrice.Focus();
                return false;
            }            
            if (this.txtSerialNo.Text == "")
            {
                DialogResult o = MessageBox.Show("Please Insert Serial No.", "IT Invoice Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSerialNo.Focus();
                return false;
            }            
            return true;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateUI()) return;  

            ITProduct.InvoiceItemRow oInvoiceItemRow= _oITProduct.InvoiceItem.NewInvoiceItemRow();
            oInvoiceItemRow.ProductCode = ctlProduct1.SelectedDSProduct.Product[0].ProductID;
            oInvoiceItemRow.ProductDescription = ctlProduct1.SelectedDSProduct.Product[0].ProductDescription;
            oInvoiceItemRow.PartNo = txtPartNo.Text;
            oInvoiceItemRow.Qty = Convert.ToInt64( txtQty.Text);
            oInvoiceItemRow.UnitPrice =Convert.ToDouble(txtUnitPrice.Text);
            _oITProduct.InvoiceItem.AddInvoiceItemRow(oInvoiceItemRow);

            //txtSerialNo.Text.Split();
            string[] sSplit = this.txtSerialNo.Text.Split(new Char[] { ','});
            if(Convert.ToInt64( txtQty.Text)!= sSplit.GetLength(0))
            {
                MessageBox.Show("Serial No is not Matched with Qty");
                _oITProduct.InvoiceItem.Clear();
                return;
            }

            foreach (string s in sSplit)
            {
                ITProduct.InvoiceItemSerialNoRow oSerialNoRow = _oITProduct.InvoiceItemSerialNo.NewInvoiceItemSerialNoRow();
                oSerialNoRow.ProductCode = ctlProduct1.SelectedDSProduct.Product[0].ProductID;
                oSerialNoRow.SerialNo = s.ToString();
                _oITProduct.InvoiceItemSerialNo.AddInvoiceItemSerialNoRow(oSerialNoRow);
            }
            _oITProduct.AcceptChanges();            

            this.Close();
        }
    }
}
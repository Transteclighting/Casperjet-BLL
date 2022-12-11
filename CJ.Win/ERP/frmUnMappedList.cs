using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.ERP;

namespace CJ.Win.ERP
{
    public partial class frmUnMappedList : Form
    {
        ProductCustomerList _oCustomers;
        ProductCustomerList _oProducts;
        ProductCustomerList _oWarehouses;
        public frmUnMappedList()
        {
            InitializeComponent();
        }

        public void ShowDialog(ProductCustomerList oCustomers, ProductCustomerList oProducts, ProductCustomerList oWarehouses)
        {
            _oCustomers = oCustomers;
            _oProducts = oProducts;
            _oWarehouses = oWarehouses;
            DataLoadControl();
            this.ShowDialog();
        }

        private void DataLoadControl()
        {
            foreach (ERPInvoiceProcess oCustomer in _oCustomers)
            {
                ListViewItem oItem = lvwCustomer.Items.Add(oCustomer.CustomerCode);
            }

            foreach (ERPInvoiceProcess oProduct in _oProducts)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oProduct.ProductCode);
            }

            foreach (ERPInvoiceProcess oWarehouse in _oWarehouses)
            {
                ListViewItem oItem = lvwWarehouse.Items.Add(oWarehouse.WarehouseCode);
            }
        }

        private void lvwCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender != lvwCustomer)
                return;
            if (e.Control && e.KeyCode == Keys.C)
                CopyToClipboardCustomer();
        }

        private void CopyToClipboardCustomer()
        {
            var builder = new StringBuilder();
            foreach (ListViewItem item in lvwCustomer.SelectedItems)
            {
                builder.AppendLine(item.SubItems[0].Text);

                Clipboard.SetText(builder.ToString());
            }
        }

        private void lvwProduct_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender != lvwProduct)
                return;
            if (e.Control && e.KeyCode == Keys.C)
                CopyToClipboardProduct();
        }

        private void CopyToClipboardProduct()
        {
            var builder = new StringBuilder();
            foreach (ListViewItem item in lvwProduct.SelectedItems)
            {
                builder.AppendLine(item.SubItems[0].Text);

                Clipboard.SetText(builder.ToString());
            }
        }
        
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CopyToClipboardWarehouse()
        {
            var builder = new StringBuilder();
            foreach (ListViewItem item in lvwWarehouse.SelectedItems)
            {
                builder.AppendLine(item.SubItems[0].Text);
                Clipboard.SetText(builder.ToString());
            }
        }
        private void lvwWarehouse_KeyUp(object sender, KeyEventArgs e)
        {
            if (sender != lvwWarehouse)
                return;
            if (e.Control && e.KeyCode == Keys.C)
                CopyToClipboardWarehouse();
        }
    }
}

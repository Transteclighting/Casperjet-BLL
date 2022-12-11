using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            Products oProducts = new Products();
            lvwProducts.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oProducts.Refresh();

            foreach (Product oProduct in oProducts)
            {
                ListViewItem oItem = lvwProducts.Items.Add(oProduct.ProductCode);
                oItem.SubItems.Add(oProduct.ProductName);
                oItem.Tag = oProduct;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProduct oForm = new frmProduct();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product oProduct = (Product)lvwProducts.SelectedItems[0].Tag;
            DBController.Instance.BeginNewTransaction();
            oProduct.Delete();
            DBController.Instance.CommitTransaction();             
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Product oProduct = (Product)lvwProducts.SelectedItems[0].Tag;
            frmProduct oForm = new frmProduct();
            oForm.ShowDialog(oProduct);
            DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Products oProducts = new Products();
            oProducts.Refresh();
            rptProducts oReport = new rptProducts();
            oReport.SetDataSource(oProducts);
            frmPrintPreview oFrom = new frmPrintPreview();

            oFrom.ShowDialog(oReport);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmSearchGiftProduct : Form
    {
        public string sProductCode;
        public string sProductName;
        public string sProductDesc;
        public int sProductId;
        public ProductDetail _oProductDetail;

        public frmSearchGiftProduct()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshListBySearch();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void refreshListBySearch()
        {
            ProductDetails oProductDetails = new ProductDetails();
            lvwProduct.Items.Clear();
            DBController.Instance.OpenNewConnection();

            oProductDetails.RefreshGiftProduct(txtCode.Text,txtName.Text);

            foreach (ProductDetail oProductDetail in oProductDetails)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oProductDetail.ProductCode);
                oItem.SubItems.Add((oProductDetail.ProductName).ToString());              
                oItem.Tag = oProductDetail;
            }

            this.Text = "Products " + lvwProduct.Items.Count.ToString();

            if (lvwProduct.Items.Count > 0)
            {
                lvwProduct.Items[0].Selected = true;
                lvwProduct.Focus();
            }
        }
        private void returnSelectedProduct()
        {
            foreach (ListViewItem oItem in lvwProduct.SelectedItems)
            {
                _oProductDetail = (ProductDetail)lvwProduct.SelectedItems[0].Tag;

                sProductId = _oProductDetail.ProductID;
                sProductCode = _oProductDetail.ProductCode;             
                sProductName = _oProductDetail.ProductName;

            }

        }
        private void lvwProduct_DoubleClick(object sender, EventArgs e)
        {
            returnSelectedProduct();
            this.Close();
        }

        private void lvwProduct_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwProduct.Sorting == SortOrder.Ascending)
            {
                lvwProduct.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwProduct.Sorting = SortOrder.Ascending;
            }
            lvwProduct.Sort();
        }
        private void lvwProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedProduct();
                this.Close();
            }
        }
    }
}
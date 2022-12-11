using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Accounts;

namespace CJ.Win.Accounts
{
    public partial class frmTPVATProducts : Form
    {
        TPVATProducts _oTPVATProducts;
        public frmTPVATProducts()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        
        private void DataLoadControl()
        {
            lvwTPVATProduct.Items.Clear();
            int nProductID = 0;
            if (ctlProducts1.txtCode.Text == string.Empty)
            {
                nProductID = -1;
            }
            else
            {
                nProductID = ctlProducts1.SelectedSerarchProduct.ProductID;
            }            
            _oTPVATProducts = new TPVATProducts();
            DBController.Instance.OpenNewConnection();
            _oTPVATProducts.RefreshProducts(nProductID);
            this.Text = "TP VAT Product | Total: " + "[" + _oTPVATProducts.Count + "]";
            foreach (TPVATProduct oTPVATProduct in _oTPVATProducts)
            {
                ListViewItem oItem = lvwTPVATProduct.Items.Add(oTPVATProduct.ProductCode);
                oItem.SubItems.Add(oTPVATProduct.ProductName);
                oItem.SubItems.Add(oTPVATProduct.MAGName);
                if (oTPVATProduct.Status == 1)
                {
                    oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.TPVATProductStatus), oTPVATProduct.Status));
                }
                else
                {
                    oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.TPVATProductStatus), oTPVATProduct.Status));
                }
                oItem.Tag = oTPVATProduct;
             }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            frmTPVATProduct _oFrom = new frmTPVATProduct();
            _oFrom.ShowDialog();
            DataLoadControl();
        }
        //private bool validateUIInput()
        //{
        //    if (lvwTPVATProduct.SelectedItems.Count == 0)
        //    {
        //        MessageBox.Show("Please Select a Row To Update Product Status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }
        //    return true;
        //}

        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            frmTPVATProduct _oFrom = new frmTPVATProduct();
            if (lvwTPVATProduct.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row To Update Product Status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TPVATProduct oTPVATProduct = (TPVATProduct)lvwTPVATProduct.SelectedItems[0].Tag;
            _oFrom.ShowDialog(oTPVATProduct);
            DataLoadControl();   
                         
        }
       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTPVATProducts_Load(object sender, EventArgs e)
        {
            DataLoadControl(); 
        }

        private void lvwTPVATProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
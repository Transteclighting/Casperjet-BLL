using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.SupplyChain
{
    public partial class frmSCMShadowPrices : Form
    {
        ProductDetails _oProducts;

        public frmSCMShadowPrices()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSCMShadowPrice oForm = new frmSCMShadowPrice();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPriceList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductDetail oProductDetail = (ProductDetail)lvwPriceList.SelectedItems[0].Tag;
            frmSCMShadowPrice oForm = new frmSCMShadowPrice();
            oForm.ShowDialog(oProductDetail);
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            _oProducts = new ProductDetails();
            lvwPriceList.Items.Clear();

            DBController.Instance.OpenNewConnection();
            _oProducts.RefreshShadowPrice(ctlProduct1.txtCode.Text.Trim());
            DBController.Instance.CloseConnection();

            foreach (ProductDetail oProduct in _oProducts)
            {
                ListViewItem oItem = lvwPriceList.Items.Add(oProduct.ProductCode.ToString());
                oItem.SubItems.Add(oProduct.ProductName.ToString());
                oItem.SubItems.Add(oProduct.AGName.ToString());
                oItem.SubItems.Add(oProduct.ASGName.ToString());
                oItem.SubItems.Add(oProduct.MAGName.ToString());
                oItem.SubItems.Add(oProduct.PGName.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oProduct.RSP).ToString());


                oItem.Tag = oProduct;
            }
            this.Text = "Shadow Products [" + _oProducts.Count + "]";
        }

        private void btnGetdata_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwPriceList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select Data to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductDetail oProductDetail = (ProductDetail)lvwPriceList.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Shadow Price. Product Name: " + oProductDetail.ProductName + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {

                    DBController.Instance.BeginNewTransaction();
                    Product oProduct = new Product();
                    oProduct.DeleteShadowPrice(oProductDetail.ProductID, oProductDetail.ShadowPriceID);

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
    }
}
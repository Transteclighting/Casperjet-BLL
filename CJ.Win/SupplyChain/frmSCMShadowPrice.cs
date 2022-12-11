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
    public partial class frmSCMShadowPrice : Form
    {
        int nPriceID = 0;
        int nProductID = 0;

        public frmSCMShadowPrice()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        public void ShowDialog(ProductDetail oProductDetail)
        {
            this.Tag = oProductDetail;
            DBController.Instance.OpenNewConnection();
            nPriceID = oProductDetail.ShadowPriceID;
            nProductID = oProductDetail.ProductID;
            Product oProduct = new Product();
            oProduct.ProductID = nProductID;
            oProduct.RefreshByID();
            ctlProduct1.txtCode.Text = oProduct.ProductCode;
            ctlProduct1.Enabled = false;
            txtPrice.Text = oProductDetail.RSP.ToString();
            this.ShowDialog();
        }
        private bool ValidateUIInput()
        {

            #region ValidInput


            if (ctlProduct1.txtCode.Text != "")
            {
                ProductDetail _oProductDetail = new ProductDetail();
                _oProductDetail.ProductCode = ctlProduct1.txtCode.Text;
                if (!_oProductDetail.CheckShadowProduct())
                {
                    MessageBox.Show("You have already entered shadow Price for this product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlProduct1.txtCode.Focus();
                    return false;
                }

            }

            #endregion

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                if (ValidateUIInput())
                {
                    Product oProduct = new Product();
                    oProduct.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                    oProduct.RSP = Convert.ToDouble(txtPrice.Text);
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oProduct.AddShadowPrice();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Successfully Add Shadow Price. Product Name: " + ctlProduct1.SelectedSerarchProduct.ProductName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }

            }
            else
            {
                Product oProduct = new Product();
                oProduct.ShadowPriceID = nPriceID;
                oProduct.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                oProduct.RSP = Convert.ToDouble(txtPrice.Text);

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oProduct.EditShadowPrice();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Update Shadow Price. Product Name: " + ctlProduct1.SelectedSerarchProduct.ProductName, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
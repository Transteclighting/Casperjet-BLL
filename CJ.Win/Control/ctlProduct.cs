// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Apr 11, 2012
// Time : 9:56 AM
// Description: Control for the search of Product (CSD Replace Management)
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Win.CSD;

namespace CJ.Win
{
    /// <summary>
    /// Public Class For Job Control
    /// </summary>
    public partial class ctlProduct : System.Windows.Forms.UserControl
    {
        private SerarchProduct _oSerarchProduct;
        /// <summary>
        /// Public Class Change Selection
        /// </summary>
        public event System.EventHandler ChangeSelection;
        /// <summary>
        /// Public Class Change Focus
        /// </summary>
        public event KeyPressEventHandler ChangeFocus;
        /// <summary>
        /// Initialize Component(Constructor)
        /// </summary>
        public ctlProduct()
        {
            InitializeComponent();
        }
        /// <summary>
        /// this property is use for the Selected Product
        /// </summary>
        public SerarchProduct SelectedSerarchProduct
        {
            get
            {
                //if (_oEmployee == null)
                //{
                //    _oEmployee = new Employee();
                //}
                return _oSerarchProduct;
            }
        }

        private void ctlProduct_Resize(object sender, EventArgs e)
        {
            if (this.Width <= 180)
            {
                this.Left = this.Left;
                this.Width = 180;
            }

            txtCode.Width = 100;
            txtCode.Height = 25;
            txtCode.Top = 0;
            txtCode.Left = 0;

            btnPicker.Top = 0;
            btnPicker.Left = txtCode.Width + 2;

            if (this.Height <= 25)
            {
                this.Height = 25;
                txtDescription.Top = 0;
                txtDescription.Left = txtCode.Width + btnPicker.Width + 4;
                txtDescription.Width = this.Width - btnPicker.Width - txtCode.Width - 10;
            }
            else if (this.Height > 25)
            {
                this.Height = 50;
                txtDescription.Top = 25;
                txtDescription.Left = 0;
                txtDescription.Width = this.Width;
            }

        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            _oSerarchProduct = new SerarchProduct();
            frmProductSearch frmProductSearch = new frmProductSearch();
            frmProductSearch.ShowDialog(_oSerarchProduct);

            if (_oSerarchProduct.ProductCode != null)
            {
                txtCode.Text = _oSerarchProduct.ProductCode.ToString();
            }
        }
        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            _oSerarchProduct = new SerarchProduct();

            txtCode.ForeColor = System.Drawing.Color.Red;
            txtDescription.Text = "";

            if (txtCode.Text.Length >= 1 && txtCode.Text.Length <= 25)
            {
                _oSerarchProduct.ProductCode = txtCode.Text;

                DBController.Instance.OpenNewConnection();
                _oSerarchProduct.RefreshByProductCode();

                if (_oSerarchProduct.ProductName == null)
                {
                    _oSerarchProduct = null;
                    AppLogger.LogFatal("There is no data.");
                    return;
                }
                else
                {
                    txtDescription.Text = _oSerarchProduct.ProductName.ToString();
                    txtCode.SelectionStart = 0;
                    txtCode.SelectionLength = txtCode.Text.Length;
                    txtCode.ForeColor = System.Drawing.Color.Empty;
                }
            }
            if (ChangeSelection != null)
                ChangeSelection(this, e);
        }


        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ChangeFocus != null)
            {
                ChangeFocus(sender, e);
            }
        }
    }
}


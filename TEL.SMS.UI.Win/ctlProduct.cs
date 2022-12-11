using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;

namespace TEL.SMS.UI.Win
{
    public partial class ctlProduct : UserControl
    {
        private DSProduct _oDSProduct;

        public event System.EventHandler ChangeSelection;

        public ctlProduct()
        {
            InitializeComponent();
        }
        /// <summary>
        /// this property is use for the Selected Product
        /// </summary>
        public DSProduct SelectedDSProduct
        {
            get
            {
                if (_oDSProduct == null) { _oDSProduct = new DSProduct(); } 
                return _oDSProduct;
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
            txtCode.Height = 20;
            txtCode.Top = 0;
            txtCode.Left = 0;

            btnPicker.Top = 0;
            btnPicker.Left = txtCode.Width + 2;

            if (this.Height <= 20)
            {
                this.Height = 20;
                txtDescription.Top = 0;
                txtDescription.Left = txtCode.Width + btnPicker.Width + 4;
                txtDescription.Width = this.Width - txtDescription.Left;
            }
            else
            {
                this.Height = 40;
                txtDescription.Top = 20;
                txtDescription.Left = 0;
                txtDescription.Width = this.Width;
            }

        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            _oDSProduct= new DSProduct();
            DAProduct oDAProduct = new DAProduct();

            txtCode.ForeColor = System.Drawing.Color.Red;
            txtDescription.Text = "";

            if (txtCode.Text.Length >= 4 && txtCode.Text.Length <=8)
            {
                DBController.Instance.OpenNewConnection();
                oDAProduct.GetProduct(_oDSProduct, txtCode.Text);
                DBController.Instance.CloseConnection();

                if (_oDSProduct.Product.Count>0)
                {
                    txtDescription.Text = _oDSProduct.Product[0].ProductDescription;
                    txtCode.SelectionStart = 0;
                    txtCode.SelectionLength = txtCode.Text.Length;
                    txtCode.ForeColor = System.Drawing.Color.Empty;
                }

            }

            if (ChangeSelection != null)
                ChangeSelection(this,e);
        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            _oDSProduct= new DSProduct();

            frmProducts oForm = new frmProducts();
            oForm.ShowDialog(_oDSProduct);
            if (_oDSProduct.Product.Count > 0)
            {
                txtCode.Text = _oDSProduct.Product[0].ProductID.ToString();
            }
            
        }

    }
}

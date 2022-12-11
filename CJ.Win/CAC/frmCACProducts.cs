using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CAC
{
    public partial class frmCACProducts : Form
    {
        Brands _oBrands;
        int _nType = 0;
        public frmCACProducts(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCACProduct oForm = new frmCACProduct();
            oForm.ShowDialog();
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Load Brand in combo
            _oBrands = new Brands();
            _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);
            _oBrands.RemoveAt(_oBrands.Count - 1);
            cmbBrand.Items.Clear();
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.Items.Add("<All>");
            cmbBrand.SelectedIndex = _oBrands.Count;

        }
        private void DataLoadControl()
        {
            ProductDetails oProducts = new ProductDetails();
            lvwProducts.Items.Clear();
            int nBrandID = -1;
            if (cmbBrand.SelectedIndex > 0 && cmbBrand.SelectedIndex < _oBrands.Count) nBrandID = _oBrands[cmbBrand.SelectedIndex].BrandID;

            DBController.Instance.OpenNewConnection();
            oProducts.RefreshCACProduct(nBrandID, txtCode.Text, txtName.Text);
            this.Text = "CAC Products " + "[" + oProducts.Count + "]";

            foreach (ProductDetail oProduct in oProducts)
            {
                ListViewItem oItem = lvwProducts.Items.Add(oProduct.ProductCode);
                oItem.SubItems.Add(oProduct.ProductName);
                oItem.SubItems.Add(oProduct.ProductModel);
                oItem.SubItems.Add(oProduct.ProductDesc);
                oItem.SubItems.Add(oProduct.AGName);
                oItem.SubItems.Add(oProduct.ASGName);
                oItem.SubItems.Add(oProduct.MAGName);
                oItem.SubItems.Add(oProduct.PGName);
                oItem.SubItems.Add(oProduct.BrandDesc);
                oItem.SubItems.Add(Convert.ToDouble(oProduct.CPBDT).ToString());
                oItem.SubItems.Add(Convert.ToDouble(oProduct.RSP).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ActiveOrInActiveStatus), oProduct.IsActive));
                oItem.Tag = oProduct;
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmCACProducts_Load(object sender, EventArgs e)
        {
            if (_nType == 1)
            {
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnUpdatePrice.Visible = false;
            }
            else if (_nType == 2)
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnUpdatePrice.Visible = true;
            }
            LoadCombos();
        }

        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            if (lvwProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Product to edit price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductDetail oProductDetail = (ProductDetail)lvwProducts.SelectedItems[0].Tag;
            frmCACProductPrice oForm = new frmCACProductPrice();
            oForm.ShowDialog(oProductDetail);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Product to edit price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductDetail oProductDetail = (ProductDetail)lvwProducts.SelectedItems[0].Tag;
            frmCACProduct oForm = new frmCACProduct();
            oForm.ShowDialog(oProductDetail);
        }
    }
}
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
    public partial class frmCACItemSarch : Form
    {
        public string sProductCode;
        public string sProductName;
        public int nProductId;
        public double _CostPrice;
        public int _nStockQty;

        Brands _oBrands;

        ProductDetail _oProductDetail;


        public frmCACItemSarch()
        {
            InitializeComponent();
        }
        private void returnSelectedItem()
        {
            foreach (ListViewItem oItem in lvwProducts.SelectedItems)
            {
                _oProductDetail = (ProductDetail)lvwProducts.SelectedItems[0].Tag;
                nProductId = _oProductDetail.ProductID;
                sProductCode = _oProductDetail.ProductCode;
                sProductName = _oProductDetail.ProductName;
                _CostPrice = _oProductDetail.CPBDT;
                _nStockQty = _oProductDetail.CurrentStock;

            }

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
                oItem.SubItems.Add(Convert.ToInt32(oProduct.CurrentStock).ToString());
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

        private void frmCACItemSarch_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void lvwProducts_DoubleClick(object sender, EventArgs e)
        {
            returnSelectedItem();
            this.Close();
        }

        private void lvwProducts_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwProducts.Sorting == SortOrder.Ascending)
            {
                lvwProducts.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwProducts.Sorting = SortOrder.Ascending;
            }
            lvwProducts.Sort();
        }

        private void lvwProducts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedItem();
                this.Close();
            }
        }
    }
}
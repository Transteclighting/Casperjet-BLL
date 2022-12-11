using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Web.UI.Class;
using CJ.Class.POS;

namespace CJ.POS.RT
{
    public partial class frmSearchProduct : Form
    {
        public int _IsBarcodeItem;
        public int _IsActive;
        public string sProductCode;
        public string sProductName;
        public string sProductDesc;
        public string sProductModel;
        public int sProductId;
        public ProductDetail _oProductDetail;
        public ProductDetails _oProductDetails;
        private ProductGroups _oPG;
        private ProductGroups _oMAG;
        private ProductGroups _oASG;
        private ProductGroups _oAG;
        private Brands _oBrand;
        Utilities oItemCategory;
        public int _nIsVatApplicableonNetPrice;
        int _nIUControl = 0;

        public frmSearchProduct(int nIUControl)
        {
            InitializeComponent();
            _nIUControl = nIUControl;
        }

        private void frmSearchProduct_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            UIControl();
            DBController.Instance.CloseConnection();
        }
        private void UIControl()
        {
            if (_nIUControl == 2)
            {
                lvwProduct.CheckBoxes = true;
                btnGet.Visible = true;
                btSelectAll.Visible = true;
            }
            else
            {
                lvwProduct.CheckBoxes = false;
                btnGet.Visible = false;
                btSelectAll.Visible = false;
            }
            btSelectAll.Text = "Checked All";
        }
        private void LoadCombos()
        {

            cmbStockQty.SelectedIndex = 0;
            //PG
            _oPG = new ProductGroups();
            _oPG.GETPG();
            cboPG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cboPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboPG.SelectedIndex = _oPG.Count - 1;

            //MAG
            _oMAG = new ProductGroups();
            _oMAG.GETMAG();
            cboMAG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cboMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboMAG.SelectedIndex = _oMAG.Count - 1;

            //ASG
            _oASG = new ProductGroups();
            _oASG.GETASG();
            cboASG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cboASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboASG.SelectedIndex = _oASG.Count - 1;

            //AG
            _oAG = new ProductGroups();
            _oAG.GETAG();
            cboAG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cboAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboAG.SelectedIndex = _oAG.Count - 1;

            //Brand
            _oBrand = new Brands();
            _oBrand.GetAllBrand(Dictionary.BrandLevel.MasterBrand);
            cboBrand.Items.Clear();

            foreach (Brand oBrand in _oBrand)
            {
                cboBrand.Items.Add(oBrand.BrandDesc);
            }
            cboBrand.Items.Add("ALL");
            cboBrand.SelectedIndex = _oBrand.Count;

            oItemCategory = new Utilities();
            oItemCategory.GetItemCategory();
            cmbItemCategory.Items.Clear();
            foreach (Utility oUtility in oItemCategory)
            {
                cmbItemCategory.Items.Add(oUtility.Satus);
            }
            cmbItemCategory.SelectedIndex = 0;

        }
        private void refreshListBySearch()
        {
            ProductDetails oProductDetails = new ProductDetails();
            lvwProduct.Items.Clear();
            DBController.Instance.OpenNewConnection();

            int nBrandID = 0;
            if (_oBrand.Count == cboBrand.SelectedIndex)
            {
                nBrandID = -1;
            }
            else
            {
                nBrandID = _oBrand[cboBrand.SelectedIndex].BrandID;
            }
            string sCurrentStock = "";
            if (cmbStockQty.SelectedIndex != 0)
                sCurrentStock = cmbStockQty.Text + txtStockQty.Text;

            oProductDetails.RefreshBySearchRT(_oPG[cboPG.SelectedIndex].PdtGroupID, _oMAG[cboMAG.SelectedIndex].PdtGroupID, _oASG[cboASG.SelectedIndex].PdtGroupID, _oAG[cboAG.SelectedIndex].PdtGroupID, nBrandID, -1, Dictionary.GeneralStatus.All, txtCode.Text, txtName.Text, oItemCategory[cmbItemCategory.SelectedIndex].SatusId, Utility.WarehouseID, sCurrentStock);

            foreach (ProductDetail oProductDetail in oProductDetails)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oProductDetail.ProductCode);
                oItem.SubItems.Add((oProductDetail.ProductName).ToString());
                oItem.SubItems.Add((oProductDetail.Vat * 100).ToString() + '%');                
                oItem.SubItems.Add(oProductDetail.CurrentStock.ToString());

                oItem.Tag = oProductDetail;
            }

            this.Text = "Products " + lvwProduct.Items.Count.ToString();

            if (lvwProduct.Items.Count > 0)
            {
                lvwProduct.Items[0].Selected = true;
                lvwProduct.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwProduct_DoubleClick(object sender, EventArgs e)
        {
            if (_nIUControl == 2)
            {
                MessageBox.Show("Please Checked Product and Click Get Button", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (cbSearchBy.Text != "")
            //{
            refreshListBySearch();
            //}
            //else MessageBox.Show("Please Select a Search option", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void returnSelectedProduct()
        {
            foreach (ListViewItem oItem in lvwProduct.SelectedItems)
            {
                _oProductDetail = (ProductDetail)lvwProduct.SelectedItems[0].Tag;
                _IsBarcodeItem = _oProductDetail.IsBarcodeItem;
                sProductId = _oProductDetail.ProductID;
                sProductCode = _oProductDetail.ProductCode;
                sProductDesc = _oProductDetail.ProductDesc;
                sProductName = _oProductDetail.ProductName;
                sProductModel = _oProductDetail.ProductModel;
                _IsActive = _oProductDetail.IsActive;
                _nIsVatApplicableonNetPrice = _oProductDetail.IsVatApplicableonNetPrice;

            }

        }
        private void lvwProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedProduct();
                this.Close();
            }
        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            if (btSelectAll.Text == "Checked All")
            {
                for (int i = 0; i < lvwProduct.Items.Count; i++)
                {
                    
                    ListViewItem itm = lvwProduct.Items[i];
                    lvwProduct.Items[i].Checked = true;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btSelectAll.Text = "Unchecked All";
                }
            }
            else
            {
                for (int i = 0; i < lvwProduct.Items.Count; i++)
                {
                    ListViewItem itm = lvwProduct.Items[i];
                    lvwProduct.Items[i].Checked = false;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btSelectAll.Text = "Checked All";
                }
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwProduct.Items.Count; i++)
            {
                ListViewItem itm = lvwProduct.Items[i];
                if (lvwProduct.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Checked at least one Product", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                _oProductDetails = new ProductDetails();
                for (int i = 0; i < lvwProduct.Items.Count; i++)
                {
                    if (lvwProduct.Items[i].Checked == true)
                    {
                        _oProductDetail = new ProductDetail();
                        _oProductDetail = (ProductDetail)lvwProduct.Items[i].Tag;
                        _oProductDetails.Add(_oProductDetail);
                    }
                }
            }
            this.Close();
        }

        private void txtStockQty_TextChanged(object sender, EventArgs e)
        {
            if (txtStockQty.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToInt32(txtStockQty.Text);
                    

                }
                catch
                {
                    MessageBox.Show("Please;Input Valid Stock Qty ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStockQty.Text = "";
                }

            }
        }
    }
}
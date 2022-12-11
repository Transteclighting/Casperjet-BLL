// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: February 20, 2011
// Time : 10:00 AM
// Description: General Form for Search Product
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CJ.Class;


namespace CJ.Win
{
    
    public partial class frmSearchProduct : Form
    {
        public int _nISBarcodeItem;
        public int _nIC;
        public double _NSP;
        public double _CP;
        public  string sProductCode;
        public string sProductName;
        public string sProductDesc;
        public string sAgName;


        public int sProductId;
        public ProductDetail _oProductDetail;
        public ProductDetails _oProductDetails;
        ProductDetails oProductDetails;
        private ProductGroups _oPG;
        private ProductGroups _oMAG;
        private ProductGroups _oASG;
        private ProductGroups _oAG;
        private Brands _oBrand;
        Utilities oItemCategory;
        int _nUIControl = 0;

        public frmSearchProduct(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }
        
        private void frmSearchProduct_Load(object sender, EventArgs e)
        {
            if (_nUIControl == 2)
            {
                lvwProduct.CheckBoxes = true;
                chkAll.Visible = true;
                btnGet.Visible = true;
            }
            else
            {
                lvwProduct.CheckBoxes = false;
                chkAll.Visible = false;
                btnGet.Visible = false;
            }
            LoadCombos();
        }
        
        private void LoadCombos()
        {
            //PG
            _oPG = new ProductGroups();
            _oPG.GETPG();
            cboPG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cboPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboPG.SelectedIndex = _oPG.Count -1;

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
            _oBrand.Refresh(Dictionary.BrandLevel.MasterBrand);
            cboBrand.Items.Clear();
            foreach (Brand oBrand in _oBrand)
            {
                cboBrand.Items.Add(oBrand.BrandDesc);
            }
            cboBrand.SelectedIndex = _oBrand.Count - 1;

            oItemCategory = new Utilities();
            oItemCategory.GetItemCategory();
            cmbItemCategory.Items.Clear();
            foreach (Utility oUtility in oItemCategory)
            {
                cmbItemCategory.Items.Add(oUtility.Satus);
            }
            cmbItemCategory.SelectedIndex = 0;
        }
        
        private void frmProducts_Load(object sender, EventArgs e)
        {
         
        }

        private void refreshListBySearch()
        {
           oProductDetails = new ProductDetails();
           lvwProduct.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oProductDetails.RefreshBySearch(_oPG[cboPG.SelectedIndex].PdtGroupID, _oMAG[cboMAG.SelectedIndex].PdtGroupID, _oASG[cboASG.SelectedIndex].PdtGroupID, _oAG[cboAG.SelectedIndex].PdtGroupID, _oBrand[cboBrand.SelectedIndex].BrandID, -1, Dictionary.GeneralStatus.All, txtCode.Text, txtName.Text, oItemCategory[cmbItemCategory.SelectedIndex].SatusId);

           foreach (ProductDetail oProductDetail in oProductDetails)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oProductDetail.ProductCode);
                oItem.SubItems.Add((oProductDetail.ProductName).ToString());
                oItem.SubItems.Add((oProductDetail.ProductDesc).ToString());
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
            refreshListBySearch();
        }

        private void returnSelectedProduct()
        {
            foreach (ListViewItem oItem in lvwProduct.SelectedItems)
            {
                _oProductDetail = (ProductDetail)lvwProduct.SelectedItems[0].Tag;

                sProductId = _oProductDetail.ProductID;
                sProductCode = _oProductDetail.ProductCode;
                sProductDesc = _oProductDetail.ProductDesc;
                sProductName = _oProductDetail.ProductName;
                _nISBarcodeItem = _oProductDetail.IsBarcodeItem;
                sAgName = _oProductDetail.AGName;
                _NSP = _oProductDetail.NSP;
                _CP = _oProductDetail.CostPrice;
                _nIC = _oProductDetail.InventoryCategory;

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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                for (int i = 0; i < lvwProduct.Items.Count; i++)
                {
                    ListViewItem itm = lvwProduct.Items[i];
                    lvwProduct.Items[i].Checked = true;
                }
                chkAll.Text = "Uncheck All";
            }
            else
            {
                for (int i = 0; i < lvwProduct.Items.Count; i++)
                {
                    ListViewItem itm = lvwProduct.Items[i];
                    lvwProduct.Items[i].Checked = false;

                }
                chkAll.Text = "Check All";
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            GetData();
            this.Close();

        }
        
        private void GetData()
        {
            _oProductDetails = new ProductDetails();

            for (int i = 0; i < lvwProduct.Items.Count; i++)
            {
                ListViewItem itm = lvwProduct.Items[i];
                if (lvwProduct.Items[i].Checked == true)
                {
                    ProductDetail oProductDetail = (ProductDetail)lvwProduct.Items[i].Tag;
                    _oProductDetails.Add(oProductDetail);

                }
            }
        }
    }
}
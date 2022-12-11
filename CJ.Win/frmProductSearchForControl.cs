// <summary>
// Compamy: Transcom Electronics Limited
// Author: A. Hakim
// Date: Jul 14, 2016
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
using CJ.Class;

namespace CJ.Win
{
    public partial class frmProductSearchForControl : Form
    {
        //public string sProductCode;
        //public string sProductName;
        //public string sProductDesc;
        //public int sProductId;
        private ProductDetail _oProductDetail;
        //public ProductDetails _oProductDetails;
        ProductDetails oProductDetails;
        private ProductGroups _oPG;
        private ProductGroups _oMAG;
        private ProductGroups _oASG;
        private ProductGroups _oAG;
        private Brands _oBrand;
        Utilities oItemCategory;
        int _nUIControl = 0;

        public frmProductSearchForControl()
        {
            InitializeComponent();
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

        private void frmProductSearchForControl_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void DataLoadControl()
        {
            oProductDetails = new ProductDetails();
            lvwProduct.Items.Clear();
            DBController.Instance.OpenNewConnection();

            oProductDetails.RefreshBySearch(_oPG[cboPG.SelectedIndex].PdtGroupID, _oMAG[cboMAG.SelectedIndex].PdtGroupID, _oASG[cboASG.SelectedIndex].PdtGroupID, _oAG[cboAG.SelectedIndex].PdtGroupID, _oBrand[cboBrand.SelectedIndex].BrandID, -1, Dictionary.GeneralStatus.All, txtCode.Text, txtName.Text, oItemCategory[cmbItemCategory.SelectedIndex].SatusId);

            foreach (ProductDetail oProductDetail in oProductDetails)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oProductDetail.ProductCode);
                oItem.SubItems.Add((oProductDetail.ProductName).ToString());
                oItem.SubItems.Add((oProductDetail.ProductDesc).ToString());
                oItem.Tag = oProductDetail;
            }

            this.Text = "Products " + lvwProduct.Items.Count.ToString();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        public bool ShowDialog(ProductDetail oProductDetail)
        {
            _oProductDetail = oProductDetail;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void lvwProduct_DoubleClick(object sender, EventArgs e)
        {

            ProductDetail oProductDetail = (ProductDetail)lvwProduct.SelectedItems[0].Tag;

            _oProductDetail.ProductCode = oProductDetail.ProductCode;
            _oProductDetail.ProductName = oProductDetail.ProductName;

            this.Close();
        }

        private void lvwProduct_KeyPress(object sender, KeyPressEventArgs e)
        {

            ProductDetail oProductDetail = (ProductDetail)lvwProduct.SelectedItems[0].Tag;

            _oProductDetail.ProductCode = oProductDetail.ProductCode;
            _oProductDetail.ProductName = oProductDetail.ProductName;

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
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
    public partial class frmCACProduct : Form
    {
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        Brands _oBrands;
        string sProductCode = "";
        int nProductID = 0;

        public frmCACProduct()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Load PG in combo
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbProductGroup.Items.Clear();
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbProductGroup.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbProductGroup.Items.Add("<All>");
            cmbProductGroup.SelectedIndex = _oPG.Count;

            //Load Brand in combo
            _oBrands = new Brands();
            _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);
            cmbBrand.Items.Clear();
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.Items.Add("<All>");
            cmbBrand.SelectedIndex = _oBrands.Count;


        }


        public void ShowDialog(ProductDetail oProduct)
        {
            DBController.Instance.OpenNewConnection();
            
            LoadCombos();
            this.Tag = oProduct;

            sProductCode = oProduct.ProductCode;
            nProductID = oProduct.ProductID;
            txtName.Text = oProduct.ProductName;
            txtDesc.Text = oProduct.ProductDesc;
            txtProductModel.Text = oProduct.ProductModel;
            if (oProduct.IsActive == (int)Dictionary.IsActive.Active)
            {
                chkIsActivate.Checked = true;
            }
            else
            {
                chkIsActivate.Checked = false;
            }
            //ProductDetail oProductDetail = oProduct.ProductDetail;
            cmbProductGroup.SelectedIndex = _oPG.GetIndex(oProduct.PGID);
            cmbMAG.SelectedIndex = _oMAG.GetIndex(oProduct.MAGID);
            cmbASG.SelectedIndex = _oASG.GetIndex(oProduct.ASGID);
            cmbAG.SelectedIndex = _oAG.GetIndex(oProduct.AGID);
            cmbBrand.SelectedIndex = _oBrands.GetIndex(oProduct.BrandID);

            this.ShowDialog();
        }

        private void frmCACProduct_Load(object sender, EventArgs e)
        {
            
            if (this.Tag == null)
            {
                this.Text = "Add New Product";
                LoadCombos();
            }
            else
            {
                this.Text = "Edit Product";
            }
        }

        private void cmbProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductGroup.SelectedIndex < 0 || cmbProductGroup.SelectedIndex > _oPG.Count - 1)
            {
                return;
            }
            int nParentID = _oPG[cmbProductGroup.SelectedIndex].PdtGroupID;
            //Load MAG in combo
            _oMAG = new ProductGroups();
            _oMAG.Refresh(nParentID);
            cmbMAG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cmbMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbMAG.Items.Add("<All>");
            cmbMAG.SelectedIndex = _oMAG.Count;
        }

        private void cmbMAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMAG.SelectedIndex < 0 || cmbMAG.SelectedIndex > _oMAG.Count - 1)
            {
                return;
            }
            int nParentID = _oMAG[cmbMAG.SelectedIndex].PdtGroupID;
            //Load ASG in combo
            _oASG = new ProductGroups();
            _oASG.Refresh(nParentID);
            cmbASG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cmbASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbASG.Items.Add("<All>");
            cmbASG.SelectedIndex = _oASG.Count;
        }

        private void cmbASG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbASG.SelectedIndex < 0 || cmbASG.SelectedIndex > _oASG.Count - 1)
            {
                return;
            }
            int nParentID = _oASG[cmbASG.SelectedIndex].PdtGroupID;
            //Load AG in combo
            _oAG = new ProductGroups();
            _oAG.Refresh(nParentID);
            cmbAG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cmbAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbAG.Items.Add("<All>");
            cmbAG.SelectedIndex = _oAG.Count;
        }

        private void Save()
        {
            Product oProduct;
            if (this.Tag == null)
            {
                oProduct = new Product();
                oProduct.ProductName = txtName.Text;
                oProduct.ProductDesc = txtDesc.Text;
                oProduct.ProductModel = txtProductModel.Text;
                oProduct.ProductGroupID = _oAG[cmbAG.SelectedIndex].PdtGroupID;
                oProduct.BrandID = _oBrands[cmbBrand.SelectedIndex].BrandID;
                if (chkIsActivate.Checked == true)
                {
                    oProduct.Active = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    oProduct.Active = (int)Dictionary.IsActive.InActive;
                }
                DBController.Instance.BeginNewTransaction();
                oProduct.InsertCACProduct();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Add Product. Product Code # " + oProduct.ProductCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                oProduct = new Product();
                oProduct.ProductID = nProductID;
                oProduct.ProductName = txtName.Text;
                oProduct.ProductDesc = txtDesc.Text;
                oProduct.ProductModel = txtProductModel.Text;
                oProduct.ProductGroupID = _oAG[cmbAG.SelectedIndex].PdtGroupID;
                oProduct.BrandID = _oBrands[cmbBrand.SelectedIndex].BrandID;
                if (chkIsActivate.Checked == true)
                {
                    oProduct.Active = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    oProduct.Active = (int)Dictionary.IsActive.InActive;
                }

                DBController.Instance.BeginNewTransaction();
                oProduct.EditCACProduct();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Edit Product. Product Code # " + sProductCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

        private bool validateUIInput()
        {
            #region Input Information Validation
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name of the Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtDesc.Text == "")
            {
                MessageBox.Show("Please enter Description of the Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return false;
            }

            if (txtProductModel.Text == "")
            {
                MessageBox.Show("Please enter Model of the Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductModel.Focus();
                return false;
            }

            if (cmbAG.SelectedIndex < 0 || cmbAG.SelectedIndex == cmbAG.Items.Count - 1)
            {
                MessageBox.Show("Please Select a Article Group of the Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAG.Focus();
                return false;
            }

            if (cmbBrand.SelectedIndex < 0 || cmbBrand.SelectedIndex == cmbBrand.Items.Count - 1)
            {
                MessageBox.Show("Please Select a Brand of the Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus();
                return false;
            }
            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
            }
        }
    }
}
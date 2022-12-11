// <summary>
// Compamy: Transcom Electronics Limited
// Primary Author: <Unknown>
// Secondary Author: Arif Khan
// Date: April 10, 2014
// Time :  4:55 PM
// Description: Forms for Product List.
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
using CJ.Report;
using CJ.Win.Security;

namespace CJ.Win
{
    public partial class frmProducts : Form
    {
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;

        Brands _oBrands;
        Brands _oSubBrands;

        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadCombos();
            updateSecurity();
        }

        private void updateSecurity()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Enabled = false;
            btnStautsUpdate.Enabled = false;

            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");

            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {

                    if ("M2.4.4.1" == sPermissionKey)
                    {
                        btnAdd.Enabled = true;
                    }
                    if ("M2.4.4.2" == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }
                    if ("M2.4.4.3" == sPermissionKey)
                    {
                        btnDelete.Enabled = true;
                    }
                    if ("M2.4.4.4" == sPermissionKey)
                    {
                        btnPrint.Enabled = true;
                    }
                    if ("M2.4.4.5" == sPermissionKey)
                    {
                        btnStautsUpdate.Enabled = true;
                    }
                    if ("M2.4.4.6" == sPermissionKey)
                    {
                        btnWebMapping.Enabled = true;
                    }
                }
            }

        }

        private void LoadCombos()
        {
            //Load PG in combo
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Clear();
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.Items.Add("<All>");
            cmbPG.SelectedIndex = _oPG.Count;

            //Load Brand in combo
            _oBrands = new Brands();
            _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);

            //Removing the [ALL] in the Brand Object ??!!
            _oBrands.RemoveAt(_oBrands.Count - 1); 
            //

            cmbBrand.Items.Clear();
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.Items.Add("<All>");
            cmbBrand.SelectedIndex = _oBrands.Count;

            //Load Status in combo
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ActiveOrInActiveStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ActiveOrInActiveStatus), GetEnum));
            }
            cmbStatus.Items.Add("<All>");
            cmbStatus.SelectedIndex = cmbStatus.Items.Count - 1;
        }

        private void DataLoadControl()
        {
            ProductDetails oProducts = new ProductDetails();
            lvwProducts.Items.Clear();

            int nPGID = -1;
            if (cmbPG.SelectedIndex > 0 && cmbPG.SelectedIndex<_oPG.Count) nPGID = _oPG[cmbPG.SelectedIndex].PdtGroupID;

            int nMAGID = -1;
            if (cmbMAG.SelectedIndex > 0 && cmbMAG.SelectedIndex < _oMAG.Count) nMAGID = _oMAG[cmbMAG.SelectedIndex].PdtGroupID;

            int nASGID = -1;
            if (cmbASG.SelectedIndex > 0 && cmbASG.SelectedIndex < _oASG.Count) nASGID = _oASG[cmbASG.SelectedIndex].PdtGroupID;

            int nAGID = -1;
            if (cmbAG.SelectedIndex > 0 && cmbAG.SelectedIndex < _oAG.Count) nAGID = _oAG[cmbAG.SelectedIndex].PdtGroupID;

            int nBrandID = -1;
            if (cmbBrand.SelectedIndex > 0 && cmbBrand.SelectedIndex < _oBrands.Count) nBrandID = _oBrands[cmbBrand.SelectedIndex].BrandID;

            int nSubBrandID = -1;
            if (cmbSubBrand.SelectedIndex > 0 && cmbSubBrand.SelectedIndex < _oSubBrands.Count) nSubBrandID = _oSubBrands[cmbSubBrand.SelectedIndex].BrandID;

            DBController.Instance.OpenNewConnection();
            oProducts.RefreshBySearch(nPGID, nMAGID, nASGID, nAGID, nBrandID, nSubBrandID, (Dictionary.GeneralStatus)(2 - cmbStatus.SelectedIndex), txtCode.Text , txtName.Text , 0);

            this.Text = "Products " + "[" + oProducts.Count + "]";
            foreach (ProductDetail oProduct in oProducts)
            {
                ListViewItem oItem = lvwProducts.Items.Add(oProduct.ProductCode);
                oItem.SubItems.Add(oProduct.ProductName);
                oItem.SubItems.Add(oProduct.ASGName);
                oItem.SubItems.Add(oProduct.MAGName);
                oItem.SubItems.Add(oProduct.PGName);
                oItem.SubItems.Add(oProduct.BrandDesc);
                //oItem.SubItems.Add(oProduct.BrandCode);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ActiveOrInActiveStatus), oProduct.IsActive));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsStoreBarcode), oProduct.IsBarcodeItem));
                oItem.SubItems.Add(oProduct.IsEcomSync == 1 ? "Yes" : "No");
                oItem.Tag = oProduct;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProduct oForm = new frmProduct();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            ProductDetail oProductDetail = (ProductDetail)lvwProducts.SelectedItems[0].Tag;

            //DBController.Instance.OpenNewConnection(); 
            Product oProduct = oProductDetail.Product;
            //DBController.Instance.CloseConnection();

            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Product: " + oProduct.ProductName + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {


                    DBController.Instance.BeginNewTransaction();
                    oProduct.Delete();
                    DBController.Instance.CommitTransaction();
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Product to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductDetail oProductDetail = (ProductDetail)lvwProducts.SelectedItems[0].Tag;
            //DBController.Instance.OpenNewConnection();
            Product oProduct = oProductDetail.Product;
            //DBController.Instance.CloseConnection();
            oProduct.VATApplicable = oProductDetail.VATApplicable;
            oProduct.VATType = oProductDetail.VATType;
            oProduct.IsVatApplicableonNetPrice = oProductDetail.IsVatApplicableonNetPrice;
            oProduct.PetName = oProductDetail.PetName;
            frmProduct oForm = new frmProduct();
            oForm.ShowDialog(oProduct);
            DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Products oProducts = new Products();
            oProducts.Refresh();
            rptProducts oReport = new rptProducts();
            oReport.SetDataSource(oProducts);
            frmPrintPreview oFrom = new frmPrintPreview();

            oFrom.ShowDialog(oReport);
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void cmbPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPG.SelectedIndex < 0)
            {
                return;
            }

            if (_oPG != null && cmbPG.SelectedIndex==_oPG.Count) 
            {
                _oMAG = null;
                cmbMAG.Items.Clear();
                cmbMAG.Items.Add("<All>");
                cmbMAG.SelectedIndex = 0;
                return;
            }

            int nParentID = _oPG[cmbPG.SelectedIndex].PdtGroupID;  
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
            if (cmbMAG.SelectedIndex < 0)
            {
                return;
            }
            if (_oMAG == null)
            {
                _oASG = null;
                cmbASG.Items.Clear();
                cmbASG.Items.Add("<All>");
                cmbASG.SelectedIndex = 0;
                return;
            }
            else
            {
                if (cmbMAG.SelectedIndex == _oMAG.Count)
                {
                    _oASG = null;
                    cmbASG.Items.Clear();
                    cmbASG.Items.Add("<All>");
                    cmbASG.SelectedIndex = 0;
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
        }

        private void cmbASG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbASG.SelectedIndex < 0)
            {
                return;
            }
            if (_oASG == null)
            {
                _oAG = null;
                cmbAG.Items.Clear();
                cmbAG.Items.Add("<All>");
                cmbAG.SelectedIndex = 0;
                return;
            }
            else
            {
                if (cmbASG.SelectedIndex == _oASG.Count)
                {
                    _oAG = null;
                    cmbAG.Items.Clear();
                    cmbAG.Items.Add("<All>");
                    cmbAG.SelectedIndex = 0;
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
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbBrand.SelectedIndex < 0)
            {
                return;
            }

            if (_oBrands != null && cmbBrand.SelectedIndex == _oBrands.Count) 
            {
                _oSubBrands = null;
                cmbSubBrand.Items.Clear();
                cmbSubBrand.Items.Add("<All>");
                cmbSubBrand.SelectedIndex = 0;
                return;
            }

            int nParentID = _oBrands[cmbBrand.SelectedIndex].BrandID;
            //Load SubBrand in combo
            _oSubBrands = new Brands();
            _oSubBrands.Refresh(nParentID);

            //Removing the [ALL] in the Sub Brand Object ??!!
            _oSubBrands.RemoveAt(_oSubBrands.Count - 1);
            //

            cmbSubBrand.Items.Clear();
            foreach (Brand oSubBrand in _oSubBrands)
            {
                cmbSubBrand.Items.Add(oSubBrand.BrandDesc);
            }
            cmbSubBrand.Items.Add("<All>");
            cmbSubBrand.SelectedIndex = _oSubBrands.Count;
        }

        private void btnStautsUpdate_Click(object sender, EventArgs e)
        {
            if (lvwProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Product to Update Status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductDetail oProductDetail = (ProductDetail)lvwProducts.SelectedItems[0].Tag;
            
            frmStatusUpdate oForm = new frmStatusUpdate();
            oForm.ShowDialog(oProductDetail);
            DataLoadControl();
        }

        private void WebMapping_Click(object sender, EventArgs e)
        {
            if (lvwProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Product to Update web mapping.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductDetail oProductDetail = (ProductDetail)lvwProducts.SelectedItems[0].Tag;
            frmWebMappingUpdate oForm = new frmWebMappingUpdate();
            oForm.ShowDialog(oProductDetail);
            DataLoadControl();
        }
    }
}
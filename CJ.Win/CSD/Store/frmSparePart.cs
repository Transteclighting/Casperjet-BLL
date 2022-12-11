using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmSparePart : Form
    {
        SPGroups _oSPSubCats;
        SPGroups _oSPMainCats;
        SPGroup _oSPMainCat;
        ProductDetails _oProductDetailsA;
        ProductDetails _oProductDetailsB;
        SparePartLocations _oSparePartLocations;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        public bool _bIsAnyActivityDone = false;
        ProductGroups _oHSCode;


        public frmSparePart()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            //Spare Main Category
            _oSPMainCats = new SPGroups();
            _oSPMainCats.GetSPMainCat();
            cmbMainCategory.Items.Clear();
            cmbMainCategory.Items.Add("--Select--");
            foreach (SPGroup oSpMainCat in _oSPMainCats)
            {
                cmbMainCategory.Items.Add(oSpMainCat.Name);
            }
            cmbMainCategory.SelectedIndex = 0;

            //product Group
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Clear();
            cmbPG.Items.Add("--Select--");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.SelectedIndex = 0;

            ////Product ASG
            //cmbASG.Items.Add("--Select--");
            //cmbASG.SelectedIndex = 0;

            //Product Brand
            _oProductDetailsB = new ProductDetails();
            _oProductDetailsB.RefreshBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("--Select--");
            foreach (ProductDetail oProductDetail in _oProductDetailsB)
            {
                cmbBrand.Items.Add(oProductDetail.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            //Product SPLocation
            _oSparePartLocations = new SparePartLocations();
            _oSparePartLocations.RefreshForCombo();
            cmbLocation.Items.Clear();
            cmbLocation.Items.Add("--Select--");
            foreach (SparePartLocation oSparePartLocation in _oSparePartLocations)
            {
                cmbLocation.Items.Add(oSparePartLocation.LocationName);
            }
            cmbLocation.SelectedIndex = 0;

            //Load HS Code
            _oHSCode = new ProductGroups();
            _oHSCode.GetHSCodeInfo();
            cmbHSCode.Items.Clear();
            cmbHSCode.Items.Add("<Select a HS Code>");
            foreach (ProductGroup oHsCode in _oHSCode)
            {
                cmbHSCode.Items.Add(oHsCode.HSCode);
            }
            cmbHSCode.SelectedIndex = 0;
        }

        private void cmbMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMainCategory.SelectedIndex != 0)
            {
                //SP Sub Category
                _oSPSubCats = new SPGroups();
                _oSPSubCats.GetSPSubCat(_oSPMainCats[cmbMainCategory.SelectedIndex-1].SPGroupID);
                cmbSubCategory.Items.Clear();
                cmbSubCategory.Items.Add("--Select--");
                foreach (SPGroup oSpGroup in _oSPSubCats)
                {
                    cmbSubCategory.Items.Add(oSpGroup.Name);
                }
                cmbSubCategory.SelectedIndex = 0;
            }
            else
            {
                cmbSubCategory.Items.Clear();
                cmbSubCategory.Items.Add("--Select--");
                cmbSubCategory.SelectedIndex = 0;
            }

        }

        public void ShowDialog(SparePartsR oSparePartsR)
        {
            this.Tag = oSparePartsR;
            LoadCombos();

            txtPartCode.Text = oSparePartsR.Code;
            txtSupplierPartCode.Text = oSparePartsR.SupplierPartCode;
            txtPartName.Text = oSparePartsR.Name;
            txtProductModel.Text = oSparePartsR.ModelNo;
            txtCostPrice.Text = oSparePartsR.CostPrice.ToString();
            txtSalePrice.Text = oSparePartsR.SalePrice.ToString();
            chkIsActive.Checked = oSparePartsR.IsActive == (int)Dictionary.YesOrNoStatus.YES;

            txtReorderLevel.Text = oSparePartsR.ReorderLevel.ToString();
            int nLocation = _oSparePartLocations.GetIndex(oSparePartsR.SparePartLocation.SPLocationID);
            cmbLocation.SelectedIndex = nLocation + 1;

            _oSPMainCat = new SPGroup();
            _oSPMainCat.SPGroupID = oSparePartsR.SPGroupID;
            _oSPMainCat.GetParentID(_oSPMainCat.SPGroupID);

            //cmbMainCategory.SelectedIndex = _oSPMainCats.GetIndex(_oSPMainCat.ParentID);
            int mainCategory = _oSPMainCats.GetIndex(oSparePartsR.SPGroupID);
            cmbMainCategory.SelectedIndex = mainCategory+1;
            cmbMainCategory_SelectedIndexChanged(null, null);
            //cmbSubCategory.SelectedIndex = _oSPSubCats.GetIndex(oSparePartsR.SPGroupID);
            cmbHSCode.SelectedIndex = _oHSCode.GetIndexHSCode(oSparePartsR.HSCodeID) + 1;

            ProductGroup oProductGroup = new ProductGroup();
            oProductGroup.GetPdtGroupAllByAGID(oSparePartsR.AGID);
            int nPg = _oPG.GetIndex(oProductGroup.PGID);
            cmbPG.SelectedIndex = nPg + 1;
            if (_oMAG != null)
            {
                int nMAG = _oMAG.GetIndex(oProductGroup.MAGID);
                cmbMAG.SelectedIndex = nMAG + 1;
            }
            else
            {
                cmbMAG.SelectedIndex = 0;

            }
            if (_oASG != null || oProductGroup.ASGID != 0)
            {
                int nAsg = _oASG.GetIndex(oProductGroup.ASGID);
                cmbASG.SelectedIndex = nAsg + 1;
            }
            else
            {
                cmbASG.SelectedIndex = 0;
            }
            if (oProductGroup.AGID != -1 && oProductGroup.AGID != 0 && oProductGroup.AGID != null)
            {
                int nAg = _oAG.GetIndex(oProductGroup.AGID);
                cmbAG.SelectedIndex = nAg + 1;
            }
            else
            {
                cmbAG.SelectedIndex = 0;
            }

            int nBrand = _oProductDetailsB.GetIndexBrand(oSparePartsR.BrandID);
            cmbBrand.SelectedIndex = nBrand + 1;

            txtPartCode.Enabled = false;
            this.ShowDialog();

        }
        public void ShowDialogs(SparePartsR oSparePartsRpc)
        {
            this.Tag = oSparePartsRpc;
            LoadCombos();

            txtPartCode.Text = oSparePartsRpc.Code;
            txtSupplierPartCode.Text = oSparePartsRpc.SupplierPartCode;
            txtPartName.Text = oSparePartsRpc.Name;
            txtProductModel.Text = oSparePartsRpc.ModelNo;
            txtCostPrice.Text = oSparePartsRpc.CostPrice.ToString();
            txtSalePrice.Text = oSparePartsRpc.SalePrice.ToString();
            if (oSparePartsRpc.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            txtReorderLevel.Text = oSparePartsRpc.ReorderLevel.ToString();
            int nLocation = _oSparePartLocations.GetIndex(oSparePartsRpc.SparePartLocation.SPLocationID);
            cmbLocation.SelectedIndex = nLocation + 1;

            _oSPMainCat = new SPGroup();
            _oSPMainCat.SPGroupID = oSparePartsRpc.SPGroupID;
            _oSPMainCat.GetParentByID(_oSPMainCat.SPGroupID);

            cmbMainCategory.SelectedIndex = _oSPMainCats.GetIndex(_oSPMainCat.ParentID);
            cmbMainCategory_SelectedIndexChanged(null, null);
            cmbSubCategory.SelectedIndex = _oSPSubCats.GetIndex(oSparePartsRpc.SPGroupID);
            cmbASG.SelectedIndex = _oProductDetailsA.GetIndexASG(oSparePartsRpc.ProductDetailASG.ASGID);
            cmbBrand.SelectedIndex = _oProductDetailsB.GetIndexBrand(oSparePartsRpc.ProductDetailBrand.BrandID);

            txtPartName.Enabled = false;
            txtProductModel.Enabled = false;
            txtCostPrice.Enabled = false;
            txtSalePrice.Enabled = false;
            txtReorderLevel.Enabled = false;
            cmbLocation.Enabled = false;
            cmbSubCategory.Enabled = false;
            cmbMainCategory.Enabled = false;
            cmbASG.Enabled = false;
            cmbBrand.Enabled = false;
            this.ShowDialog();
        }
        private bool ValidateUiInput()
        {
            #region Input Information Validation

            if (txtPartCode.Text == "")
            {
                MessageBox.Show("Please Input Part Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPartCode.Focus();
                return false;
            }
            if (txtSupplierPartCode.Text == "")
            {
                MessageBox.Show("Please Input Supplier Part Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierPartCode.Focus();
                return false;
            }
            if (txtPartName.Text == "")
            {
                MessageBox.Show("Please Input Part Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPartName.Focus();
                return false;
            }
            if (txtProductModel.Text == "")
            {
                MessageBox.Show("Please Input Product Model", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductModel.Focus();
                return false;
            }
            if (txtReorderLevel.Text == "")
            {
                MessageBox.Show("Please Input Reorder Level", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReorderLevel.Focus();
                return false;
            }
            else
            {
                Regex rgCell = new Regex("[0-9]");
                if (rgCell.IsMatch(txtReorderLevel.Text))
                {

                }
                else
                {
                    MessageBox.Show("Please Input Valid Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReorderLevel.Focus();
                    return false;
                }

            }
            if (txtCostPrice.Text == "")
            {
                MessageBox.Show("Please Input Cost Price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCostPrice.Focus();
                return false;
            }
            else
            {
                Regex rgCell = new Regex("[0-9]");
                if (rgCell.IsMatch(txtCostPrice.Text))
                {

                }
                else
                {
                    MessageBox.Show("Please Input Valid Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCostPrice.Focus();
                    return false;
                }

            }
            if (txtSalePrice.Text == "")
            {
                MessageBox.Show("Please Input Sale Price", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalePrice.Focus();
                return false;
            }
            else
            {
                Regex rgCell = new Regex("[0-9]");
                if (rgCell.IsMatch(txtSalePrice.Text))
                {

                }
                else
                {
                    MessageBox.Show("Please Input Valid Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSalePrice.Focus();
                    return false;
                }
            }
            //if (this.Tag == null)
            //{
            //    if (cmbIsActive.Text == "False")
            //    {
            //        MessageBox.Show("For First time the Part Should be Inputed Active mode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            if (cmbLocation.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbMainCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select SP Main Category","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            //if (cmbSubCategory.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select SP Sub Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if (cmbPG.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Product Group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbASG.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select ASG", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbAG.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select AG", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUiInput())
            {
                Save();
                Close();
            }
        }
        private void Save()
        {
            if (Tag == null)
            {

                SparePartsR oSparePartsR = new SparePartsR
                {
                    Code = txtPartCode.Text,
                    SupplierPartCode = txtSupplierPartCode.Text,
                    Name = txtPartName.Text,
                    ModelNo = txtProductModel.Text,
                    CostPrice = Convert.ToDouble(txtCostPrice.Text.Trim()),
                    SalePrice = Convert.ToDouble(txtSalePrice.Text.Trim())
                };
                if (chkIsActive.Checked)
                {
                    oSparePartsR.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oSparePartsR.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }
                oSparePartsR.ReorderLevel = Convert.ToInt32(txtReorderLevel.Text.Trim());
                oSparePartsR.LocationID = _oSparePartLocations[cmbLocation.SelectedIndex-1].SPLocationID;
                //SPGroup oSPGroup = _oSPSubCats[cmbSubCategory.SelectedIndex-1];
                //oSparePartsR.SPGroupID = oSPGroup.SPGroupID;
                oSparePartsR.SPGroupID = _oSPMainCats[cmbMainCategory.SelectedIndex - 1].SPGroupID;
                oSparePartsR.AGID = _oAG[cmbAG.SelectedIndex - 1].PdtGroupID; 
                oSparePartsR.BrandID = _oProductDetailsB[cmbBrand.SelectedIndex-1].BrandID;
                oSparePartsR.HSCodeID = _oHSCode[cmbHSCode.SelectedIndex - 1].HSCodeID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (!oSparePartsR.RefreshBySparePartCode())
                    {
                        oSparePartsR.Add();

                        SPPriceHistory oSPPriceHistory = new SPPriceHistory();
                        oSPPriceHistory.SparePartID = oSparePartsR.SparePartID;
                        oSPPriceHistory.CostPrice = Convert.ToDouble(txtCostPrice.Text.Trim());
                        oSPPriceHistory.SalePrice = Convert.ToDouble(txtSalePrice.Text.Trim());

                        oSPPriceHistory.Add();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Refresh(); 
                       // DBController.Instance.CommitTransaction();
                        MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }


                    //DBController.Instance.CommitTransaction();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                //if (txtPartCode.Enabled == false)
                //{


                    SparePartsR oSparePartsR = (SparePartsR)this.Tag;

                {
                    //oSparePartsR.Code = txtPartCode.Text;
                    oSparePartsR.SupplierPartCode = txtSupplierPartCode.Text;
                    oSparePartsR.Name = txtPartName.Text;
                    oSparePartsR.ModelNo = txtProductModel.Text;
                    oSparePartsR.CostPrice = Convert.ToDouble(txtCostPrice.Text.Trim());
                    oSparePartsR.SalePrice = Convert.ToDouble(txtSalePrice.Text.Trim());
                    if (chkIsActive.Checked)
                    {
                        oSparePartsR.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                    }
                    else
                    {
                        oSparePartsR.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                    }
                    oSparePartsR.ReorderLevel = Convert.ToInt32(txtReorderLevel.Text.Trim());
                    oSparePartsR.LocationID = _oSparePartLocations[cmbLocation.SelectedIndex - 1].SPLocationID;
                    //SPGroup oSPGroup = _oSPSubCats[cmbSubCategory.SelectedIndex-1];
                    //oSparePartsR.SPGroupID = oSPGroup.SPGroupID;
                    oSparePartsR.SPGroupID = _oSPMainCats[cmbMainCategory.SelectedIndex - 1].SPGroupID;
                    oSparePartsR.AGID = _oAG[cmbAG.SelectedIndex - 1].PdtGroupID;
                    oSparePartsR.BrandID = _oProductDetailsB[cmbBrand.SelectedIndex - 1].BrandID;
                    oSparePartsR.HSCodeID = _oHSCode[cmbHSCode.SelectedIndex - 1].HSCodeID;
                    SPPriceHistory oSPPriceHistory = new SPPriceHistory();
                    oSPPriceHistory.SparePartID = oSparePartsR.SparePartID;
                    oSPPriceHistory.CostPrice = Convert.ToDouble(txtCostPrice.Text.Trim());
                    oSPPriceHistory.SalePrice = Convert.ToDouble(txtSalePrice.Text.Trim());

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        if (oSPPriceHistory.CheckPriceHistory())
                        {
                            oSPPriceHistory.Add();
                        }

                        oSparePartsR.Edit();

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
               // }
                //else
                //{

                //    SparePartsR oSparePartsR = (SparePartsR)this.Tag;

                //    {
                //        oSparePartsR.Code = txtPartCode.Text;
                //        oSparePartsR.Name = txtPartName.Text;
                //        oSparePartsR.ModelNo = txtProductModel.Text;
                //        oSparePartsR.CostPrice = Convert.ToDouble(txtCostPrice.Text.Trim());
                //        oSparePartsR.SalePrice = Convert.ToDouble(txtSalePrice.Text.Trim());
                //        if (chkIsActive.Checked)
                //        {
                //            oSparePartsR.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                //        }
                //        oSparePartsR.ReorderLevel = Convert.ToInt32(txtReorderLevel.Text.Trim());
                //        oSparePartsR.LocationID = _oSparePartLocations[cmbLocation.SelectedIndex-1].SPLocationID;
                //        SPPriceHistory oSPPriceHistory = new SPPriceHistory();
                //        oSPPriceHistory.SparePartID = oSparePartsR.SparePartID;
                //        oSparePartsR.AGID = _oAG[cmbAG.SelectedIndex - 1].PdtGroupID;
                //        oSparePartsR.BrandID = _oProductDetailsB[cmbBrand.SelectedIndex-1].BrandID;

                //        try
                //        {
                //            DBController.Instance.BeginNewTransaction();

                //            if (oSparePartsR.Flag != false)
                //            {
                //                oSparePartsR.Edit();

                //                DBController.Instance.CommitTransaction();
                //                MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                Refresh();
                //            }
                //            else
                //            {

                //                DBController.Instance.CommitTransaction();
                //                MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //                return;
                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            DBController.Instance.RollbackTransaction();
                //            MessageBox.Show(ex.Message, "Error!!!");
                //        }

                //    }
                //}
            }
            _bIsAnyActivityDone = true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmSparePart_Load(object sender, EventArgs e)
        {
            lblSubCategory.Enabled = false;
            cmbSubCategory.Enabled = false;
            if (this.Tag == null)
            {
                LoadCombos();
                chkIsActive.Checked = true;
            }
            else
            {
                txtPartCode.ReadOnly = true;
                txtPartCode.Enabled = false;
            }
        }

        private void cmbPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPG.SelectedIndex != 0)
            {
                int nParentID = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;
                //Load MAG in combo
                _oMAG = new ProductGroups();
                _oMAG.Refresh(nParentID);
                cmbMAG.Items.Clear();
                cmbMAG.Items.Add("--Select--");
                foreach (ProductGroup oProductGroup in _oMAG)
                {
                    cmbMAG.Items.Add(oProductGroup.PdtGroupName);
                }
                cmbMAG.SelectedIndex = 0;
            }
            else
            {
                cmbMAG.Items.Clear();
                cmbMAG.Items.Add("--Select--");
                cmbMAG.SelectedIndex = 0;
            }
        }

        private void cmbMAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMAG.SelectedIndex != 0)
            {
                int nParentID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;
                //Load ASG in combo
                _oASG = new ProductGroups();
                _oASG.Refresh(nParentID);
                cmbASG.Items.Clear();
                cmbASG.Items.Add("--Select--");
                foreach (ProductGroup oProductGroup in _oASG)
                {
                    cmbASG.Items.Add(oProductGroup.PdtGroupName);
                }
                cmbASG.SelectedIndex = 0;
            }
            else
            {
                cmbASG.Items.Clear();
                cmbASG.Items.Add("--Select--");
                cmbASG.SelectedIndex = 0;
            }

        }

        private void cmbASG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbASG.SelectedIndex != 0)
            {
                int nParentID = _oASG[cmbASG.SelectedIndex - 1].PdtGroupID;
                //Load AG in combo
                _oAG = new ProductGroups();
                _oAG.Refresh(nParentID);
                cmbAG.Items.Clear();
                cmbAG.Items.Add("--Select--");
                foreach (ProductGroup oProductGroup in _oAG)
                {
                    cmbAG.Items.Add(oProductGroup.PdtGroupName);
                }
                cmbAG.SelectedIndex = 0;
            }
            else
            {
                cmbAG.Items.Clear();
                cmbAG.Items.Add("--Select--");
                cmbAG.SelectedIndex = 0;
            }

        }

    }
}
// <summary>
// Compamy: Transcom Electronics Limited
// Primary Author: <Unknown>
// Secondary Author: Arif Khan
// Date: April 10, 2014
// Time :  4:55 PM
// Description: Forms for Add/Edit of Product.
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
using CJ.Class.POS;
using CJ.Class.HR;

namespace CJ.Win
{
    public partial class frmProduct : Form
    {

        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        ProductGroups _oHSCode;




        Brands _oBrands;
        Brands _oSubBrands;

        InventoryCategorys _oInventoryCategorys;
        int nProductID;
        int nInventoryCategoryID;
        public frmProduct()
        {
            InitializeComponent();
        }

        public void ShowDialog(Product oProduct)
        {
            LoadCombos();
            this.Tag = oProduct;
            txtCode.Text = oProduct.ProductCode;
            txtName.Text = oProduct.ProductName;
            txtDesc.Text = oProduct.ProductDesc;
            txtProductModel.Text = oProduct.ProductModel;
            txtPetName.Text = oProduct.PetName;

            chkIsActivate.Checked = oProduct.IsActive;

            txtSmallUOM.Text = oProduct.SmallUnitOfMeasure;
            txtMidUOM.Text = oProduct.MidUnitOfMeasure;
            txtLargeUOM.Text = oProduct.LargeUnitOfMeasure;
            numMSRatio.Value = oProduct.MSRatio;
            numLSRatio.Value = oProduct.LSRatio;
            numMOQ.Value = oProduct.UOMConversionFactor;

            ProductDetail oProductDetail = oProduct.ProductDetail;
            cmbProductGroup.SelectedIndex = _oPG.GetIndex(oProductDetail.PGID);
            cmbMAG.SelectedIndex = _oMAG.GetIndex(oProductDetail.MAGID);
            cmbASG.SelectedIndex = _oASG.GetIndex(oProductDetail.ASGID);
            cmbAG.SelectedIndex = _oAG.GetIndex(oProductDetail.AGID);
            cmbBrand.SelectedIndex = _oBrands.GetIndex(oProductDetail.BrandID);
            cmbSubBrand.SelectedIndex = _oSubBrands.GetIndex(oProductDetail.SubBrandID);
            cmbVatType.SelectedIndex = oProduct.VATType;



            cmbInventoryCategory.SelectedIndex = oProduct.InventoryCategory - 1;
            cmbItemCategory.SelectedIndex = oProduct.ItemCategory - 1;
            cmbProductType.SelectedIndex = oProduct.ProductType - 1;
            cmbSupplyType.SelectedIndex = oProduct.SupplyType - 1;
            //cmbHSCode.SelectedIndex = 0;

            cmbHSCode.SelectedIndex = _oHSCode.GetIndexHSCode(oProductDetail.HSCodeID) + 1;

            cmbVAT.SelectedIndex = oProduct.VATApplicable + 1;
            
            cmbIsBarcodeItem.SelectedIndex = oProduct.IsBarcodeItem;
            if (oProduct.IsVatApplicableonNetPrice == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkVatApplOnNetPrice.Checked = true;
            }
            else
            {
                chkVatApplOnNetPrice.Checked = false;
            }

            nProductID = oProduct.ProductID;
            nInventoryCategoryID = oProduct.InventoryCategory;


            cmbInventoryCategory.Enabled = false;


            Product oProductSpace = new Product();
            oProductSpace.ProductID= oProduct.ProductID;
            oProductSpace.RefreshProductSpace();
            txtStakeLevel.Text = oProductSpace.StakeLevel.ToString();
            txtLength.Text = oProductSpace.Length.ToString();
            txtWeight.Text = oProductSpace.Weight.ToString();
            txtHight.Text = oProductSpace.Hight.ToString();

            this.ShowDialog();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            helpProvider1.SetShowHelp(txtCode, true);
            helpProvider1.SetHelpString(txtCode, "Enter Product Code Here.");

            helpProvider1.SetShowHelp(btnClear, true);
            helpProvider1.SetHelpString(btnClear, "Click here to clear all the input boxes.");


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

        private void LoadCombos()
        {
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

            //Load VAT Applicable
            cmbVAT.Items.Clear();
            cmbVAT.Items.Add("< Select VAT Status >");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbVAT.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbVAT.SelectedIndex = 0;

            //Load InventoryCategory
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InventoryCate)))
            //{
            //    cmbInventoryCategory.Items.Add(Enum.GetName(typeof(Dictionary.InventoryCate), GetEnum));
            //}
            _oInventoryCategorys = new InventoryCategorys();
            _oInventoryCategorys.Refresh();
            cmbInventoryCategory.Items.Clear();
            foreach (InventoryCategory oInventoryCategory in _oInventoryCategorys)
            {
                cmbInventoryCategory.Items.Add(oInventoryCategory.InventoryCategoryName);
            }
            cmbInventoryCategory.Items.Add("<Select an Inventory Category>");
            cmbInventoryCategory.SelectedIndex = cmbInventoryCategory.Items.Count - 1;

            //Load Item Category
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ItemCategory)))
            {
                cmbItemCategory.Items.Add(Enum.GetName(typeof(Dictionary.ItemCategory), GetEnum));
            }
            cmbItemCategory.Items.Add("<Select an Item Category>");
            cmbItemCategory.SelectedIndex = cmbItemCategory.Items.Count - 1;

            //Load Product Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductType)))
            {
                cmbProductType.Items.Add(Enum.GetName(typeof(Dictionary.ProductType), GetEnum));
            }
            cmbProductType.Items.Add("<Select an Product Type>");
            cmbProductType.SelectedIndex = cmbProductType.Items.Count - 1;

            //Load Supply Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SupplyType)))
            {
                cmbSupplyType.Items.Add(Enum.GetName(typeof(Dictionary.SupplyType), GetEnum));
            }
            cmbSupplyType.Items.Add("<Select a Supply Type>");
            cmbSupplyType.SelectedIndex = cmbSupplyType.Items.Count - 1;

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

            //Is Barcode Itme
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsStoreBarcode)))
            {
                cmbIsBarcodeItem.Items.Add(Enum.GetName(typeof(Dictionary.IsStoreBarcode), GetEnum));
            }
            cmbIsBarcodeItem.SelectedIndex = 1;

            //VAT Type
            cmbVatType.Items.Clear();
            cmbVatType.Items.Add("<Select a Vat Type>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.VATType)))
            {
                cmbVatType.Items.Add(Enum.GetName(typeof(Dictionary.VATType), GetEnum));
            }
            cmbVatType.SelectedIndex = 0;
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

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBrand.SelectedIndex < 0 || cmbBrand.SelectedIndex > _oBrands.Count - 1)
            {
                return;
            }

            int nParentID = _oBrands[cmbBrand.SelectedIndex].BrandID;
            //Load SubBrand in combo
            _oSubBrands = new Brands();
            _oSubBrands.Refresh(nParentID);
            cmbSubBrand.Items.Clear();
            foreach (Brand oSubBrand in _oSubBrands)
            {
                cmbSubBrand.Items.Add(oSubBrand.BrandDesc);
            }
            cmbSubBrand.Items.Add("<All>");
            cmbSubBrand.SelectedIndex = _oSubBrands.Count;
        }


        private bool validateUIInput()
        {
            #region Input Information Validation



            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code of the Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

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

            if (cmbAG.SelectedIndex < 0 || cmbAG.SelectedIndex ==cmbAG.Items.Count-1)
            {
                MessageBox.Show("Please Select a Article Group of the Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAG.Focus();
                return false;
            }

            if (cmbSubBrand.SelectedIndex < 0 || cmbSubBrand.SelectedIndex == cmbSubBrand.Items.Count - 1)
            {
                MessageBox.Show("Please Select a Sub Brand of the Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSubBrand.Focus();
                return false;
            }

            if (cmbHSCode.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a HS Code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbHSCode.Focus();
                return false;
            }

            if (cmbSupplyType.SelectedIndex < 0 || cmbSupplyType.SelectedIndex == cmbSupplyType.Items.Count - 1)
            {
                MessageBox.Show("Please Select a Supply Type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupplyType.Focus();
                return false;
            }

            if (cmbVAT.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a VAT Applicable.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVAT.Focus();
                return false;
            }

            if (cmbInventoryCategory.SelectedIndex < 0 || cmbInventoryCategory.SelectedIndex == cmbInventoryCategory.Items.Count - 1)
            {
                MessageBox.Show("Please Select an Inventory Category.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbInventoryCategory.Focus();
                return false;
            }

            if (cmbItemCategory.SelectedIndex < 0 || cmbItemCategory.SelectedIndex == cmbItemCategory.Items.Count - 1)
            {
                MessageBox.Show("Please Select an Item Category.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbItemCategory.Focus();
                return false;
            }

            if (cmbProductType.SelectedIndex < 0 || cmbProductType.SelectedIndex == cmbProductType.Items.Count - 1)
            {
                MessageBox.Show("Please Select a Product Type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProductType.Focus();
                return false;
            }

            if (cmbVatType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a VAT Type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVatType.Focus();
                return false;
            }

            if (txtStakeLevel.Text == "")
            {
                MessageBox.Show("Please enter Stake Level of the Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStakeLevel.Focus();
                return false;
            }

            if (txtLength.Text == "")
            {
                MessageBox.Show("Please enter Length of the Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLength.Focus();
                return false;
            }

            if (txtWeight.Text == "")
            {
                MessageBox.Show("Please enter Weight of the Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWeight.Focus();
                return false;
            }

            if (txtHight.Text == "")
            {
                MessageBox.Show("Please enter Hight of the Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHight.Focus();
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
                this.Close();
            }
        }

        private void Save()
        {
            
            Product oProduct;
            DataSyncManager oDataSyncManager = new DataSyncManager();

            if (this.Tag == null)
            {
                oProduct = new Product();
                oProduct.ProductCode = txtCode.Text.Trim();
                oProduct.ProductName = txtName.Text.Trim();
                oProduct.ProductDesc = txtDesc.Text.Trim();
                oProduct.ProductModel = txtProductModel.Text.Trim();
                oProduct.PetName = txtPetName.Text;
                oProduct.SmallUnitOfMeasure = txtSmallUOM.Text;
                oProduct.MidUnitOfMeasure = txtMidUOM.Text; 
                oProduct.LargeUnitOfMeasure = txtLargeUOM.Text;
                oProduct.MSRatio = Convert.ToInt32(numMSRatio.Value);
                oProduct.LSRatio = Convert.ToInt32(numLSRatio.Value);
                oProduct.UOMConversionFactor = Convert.ToInt32(numMOQ.Value);

                oProduct.ProductGroupID = _oAG[cmbAG.SelectedIndex].PdtGroupID;
                oProduct.BrandID = _oSubBrands[cmbSubBrand.SelectedIndex].BrandID;

                oProduct.EntryDate = dtpEntryDate.Value;

                oProduct.InventoryCategory = cmbInventoryCategory.SelectedIndex+1;
                oProduct.ItemCategory = cmbItemCategory.SelectedIndex + 1;
                oProduct.ProductType = cmbProductType.SelectedIndex + 1;

                oProduct.SupplyType = cmbSupplyType.SelectedIndex+1;
                oProduct.HSCodeID = _oHSCode[cmbHSCode.SelectedIndex - 1].HSCodeID;

                oProduct.VATApplicable = cmbVAT.SelectedIndex - 1;
                oProduct.IsActive = chkIsActivate.Checked;
                oProduct.IsBarcodeItem = cmbIsBarcodeItem.SelectedIndex;

                oProduct.ProductSBUs = "2,3";

                oProduct.VATType = cmbVatType.SelectedIndex;
                if (chkVatApplOnNetPrice.Checked == true)
                {
                    oProduct.IsVatApplicableonNetPrice = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oProduct.IsVatApplicableonNetPrice = (int)Dictionary.YesOrNoStatus.NO;
                }

                try
                {
                    oProduct.StakeLevel = Convert.ToInt32(txtStakeLevel.Text);
                }
                catch
                {
                    oProduct.StakeLevel = 0;
                }
                try
                {
                    oProduct.Length = Convert.ToDouble(txtLength.Text);
                }
                catch
                {
                    oProduct.Length = 0;
                }
                try
                {
                    oProduct.Weight = Convert.ToDouble(txtWeight.Text);
                }
                catch
                {
                    oProduct.Weight = 0;
                }
                try
                {
                    oProduct.Hight = Convert.ToDouble(txtHight.Text);
                }
                catch
                {
                    oProduct.Hight = 0;
                }

                DBController.Instance.BeginNewTransaction();
                oProduct.Add();

                nProductID = oProduct.ProductID;
                InsertHistory();
                oDataSyncManager.SendProductToShowroom(oProduct, Dictionary.DataTransferType.Add);

                #region Send Factory Data
                JobLocations _oJobLocations = new JobLocations();
                _oJobLocations.RefreshFactoryLocation();
                foreach (JobLocation oJobLocation in _oJobLocations)
                {
                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_Product";
                    oDataTran.DataID = nProductID;
                    oDataTran.WarehouseID = oJobLocation.JobLocationID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckDataByLocationID() == false)
                    {
                        oDataTran.AddForFactory();
                    }
                }
                #endregion


                DBController.Instance.CommitTransaction();
            }
            else
            {
                oProduct = (Product)this.Tag;
                oProduct.ProductCode = txtCode.Text;
                oProduct.ProductName = txtName.Text;
                oProduct.ProductDesc = txtDesc.Text;
                oProduct.ProductModel = txtProductModel.Text;
                oProduct.PetName = txtPetName.Text;
                oProduct.SmallUnitOfMeasure = txtSmallUOM.Text;
                oProduct.MidUnitOfMeasure = txtMidUOM.Text;
                oProduct.LargeUnitOfMeasure = txtLargeUOM.Text;
                oProduct.MSRatio = Convert.ToInt32(numMSRatio.Value);
                oProduct.LSRatio = Convert.ToInt32(numLSRatio.Value);
                oProduct.UOMConversionFactor = Convert.ToInt32(numMOQ.Value);

                oProduct.ProductGroupID = _oAG[cmbAG.SelectedIndex].PdtGroupID;
                oProduct.BrandID = _oSubBrands[cmbSubBrand.SelectedIndex].BrandID;

                oProduct.EntryDate = dtpEntryDate.Value;

                oProduct.InventoryCategory = cmbInventoryCategory.SelectedIndex + 1;
                oProduct.ItemCategory = cmbItemCategory.SelectedIndex + 1;
                oProduct.ProductType = cmbProductType.SelectedIndex + 1;

                oProduct.SupplyType = cmbSupplyType.SelectedIndex + 1;
                oProduct.HSCodeID = _oHSCode[cmbHSCode.SelectedIndex - 1].HSCodeID;

                oProduct.VATApplicable = cmbVAT.SelectedIndex - 1;
                oProduct.IsActive = chkIsActivate.Checked;
                oProduct.IsBarcodeItem = cmbIsBarcodeItem.SelectedIndex;

                oProduct.ProductSBUs = "2,3";
                oProduct.VATType = cmbVatType.SelectedIndex;
                if (chkVatApplOnNetPrice.Checked == true)
                {
                    oProduct.IsVatApplicableonNetPrice = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oProduct.IsVatApplicableonNetPrice = (int)Dictionary.YesOrNoStatus.NO;
                }
                oProduct.LastUpdateDate = DateTime.Now;

                try
                {
                    oProduct.StakeLevel = Convert.ToInt32(txtStakeLevel.Text);
                }
                catch
                {
                    oProduct.StakeLevel = 0;
                }
                try
                {
                    oProduct.Length = Convert.ToDouble(txtLength.Text);
                }
                catch
                {
                    oProduct.Length = 0;
                }
                try
                {
                    oProduct.Weight = Convert.ToDouble(txtWeight.Text);
                }
                catch
                {
                    oProduct.Weight = 0;
                }
                try
                {
                    oProduct.Hight = Convert.ToDouble(txtHight.Text);
                }
                catch
                {
                    oProduct.Hight = 0;
                }

                DBController.Instance.BeginNewTransaction();
                oProduct.Edit();

                nProductID = oProduct.ProductID;
                InsertHistory();
                oDataSyncManager.SendProductToShowroom(oProduct, Dictionary.DataTransferType.Edit);

                #region Send Factory Data
                JobLocations _oJobLocations = new JobLocations();
                _oJobLocations.RefreshFactoryLocation();
                foreach (JobLocation oJobLocation in _oJobLocations)
                {
                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_Product";
                    oDataTran.DataID = nProductID;
                    oDataTran.WarehouseID = oJobLocation.JobLocationID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckDataByLocationID() == false)
                    {
                        oDataTran.AddForFactory();
                    }
                }
                #endregion


                DBController.Instance.CommitTransaction();


            }

        }

        private void InsertHistory()
        {
            //Employee oEmpHistory = new Employee();
            //oEmpHistory.EmployeeID = nEmployeeID;
            Product oProductHistory = new Product();
            oProductHistory.ProductID= nProductID;

            if (nInventoryCategoryID != _oInventoryCategorys[cmbInventoryCategory.SelectedIndex].InventoryCategoryID)
            {
                oProductHistory.Type = (int)Dictionary.ProductHistoryType.InventoryCategory;
                oProductHistory.From = nInventoryCategoryID;
                oProductHistory.To = _oInventoryCategorys[cmbInventoryCategory.SelectedIndex].InventoryCategoryID;
                oProductHistory.EffectiveDate = DateTime.Today;//dtEffectiveDate.Value.Date;
                oProductHistory.Remarks = "";
                oProductHistory.AddProductHistory();
            }

            //if (nDepartment != _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID)
            //{
            //    oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.Department;
            //    oEmpHistory.From = nDepartment;
            //    oEmpHistory.To = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;
            //    oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
            //    oEmpHistory.Remarks = sDepartment + " to " + cboDepartment.Text;
            //    oEmpHistory.AddEmployeeHistory();
            //}

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
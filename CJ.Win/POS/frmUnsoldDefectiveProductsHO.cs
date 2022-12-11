using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Win.CSD;
using CJ.Win.Security;

namespace CJ.Win.POS
{
    public partial class frmUnsoldDefectiveProductsHO : Form
    {
        UnsoldDefectiveProduct _oUnsoldDefectiveProduct;
        UnsoldDefectiveProducts _oUnsoldDefectiveProducts;
        bool IsCheck = false;
        int _nType = 0;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;

        Brands _oBrands;
        string _sBrandID = "";


        public frmUnsoldDefectiveProductsHO(int nType)
        {
            InitializeComponent();
            _nType = nType;///1=Call Center,2=Unsold Defective Product
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {
            _oUnsoldDefectiveProducts = new UnsoldDefectiveProducts();
            lvwUnsouldDefectiveProducts.Items.Clear();
            int nStatus = 0;
            if (cmbstatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbstatus.SelectedIndex;
            }

            int nProductID = 0;
            if (ctlProduct1.txtCode.Text == "")
            {
                nProductID = -1;
            }
            else
            {
                nProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nPGID = -1;
            if (cmbPG.SelectedIndex > 0) nPGID = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;

            int nMAGID = -1;
            if (cmbMAG.SelectedIndex > 0) nMAGID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;

            int nASGID = -1;
            if (cmbASG.SelectedIndex > 0) nASGID = _oASG[cmbASG.SelectedIndex - 1].PdtGroupID;

            int nAGID = -1;
            if (cmbAG.SelectedIndex > 0) nAGID = _oAG[cmbAG.SelectedIndex - 1].PdtGroupID;

            //int nBrandID = -1;
            //if (cmbBrand.SelectedIndex > 0) nBrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            string sBrnID = "";
            string sBrandID = _sBrandID;
            if (sBrandID == "")
            {
                if (cmbBrand.SelectedIndex != 0)
                {
                    sBrnID = Convert.ToString(_oBrands[cmbBrand.SelectedIndex - 1].BrandID);
                }

            }
            if (sBrnID != "")
            {
                sBrandID = sBrnID;
            }


            _oUnsoldDefectiveProducts.RefreshForHO(dtFromdate.Value.Date, dtTodate.Value.Date, nStatus, txtBarcode.Text.Trim(), IsCheck, txtDefectiveNo.Text.Trim(), ctlProduct1.txtDescription.Text.Trim(), txtShowroom.Text.Trim(), txtJobNo.Text.Trim(), cmbIsCreateJob.Text, cmbDefectiveType.SelectedIndex, nPGID, nMAGID, nASGID, nAGID, sBrandID,_nType);
            DBController.Instance.CloseConnection();
            foreach (UnsoldDefectiveProduct oUnsoldDefectiveProduct in _oUnsoldDefectiveProducts)
            {
                ListViewItem oItem = lvwUnsouldDefectiveProducts.Items.Add(oUnsoldDefectiveProduct.DefectiveNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), oUnsoldDefectiveProduct.DefectiveType));
                oItem.SubItems.Add(oUnsoldDefectiveProduct.ShowroomCode.ToString());
                oItem.SubItems.Add(oUnsoldDefectiveProduct.ProductCode.ToString());
                oItem.SubItems.Add(oUnsoldDefectiveProduct.ProductName.ToString());
                oItem.SubItems.Add(oUnsoldDefectiveProduct.BarcodeSL.ToString());
                oItem.SubItems.Add(oUnsoldDefectiveProduct.Fault.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oUnsoldDefectiveProduct.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.POSUnsouldDefectiveProductStatus), oUnsoldDefectiveProduct.Status));
                oItem.SubItems.Add(oUnsoldDefectiveProduct.JobNo.ToString());
                oItem.SubItems.Add(oUnsoldDefectiveProduct.IsCreateJob.ToString());
                oItem.SubItems.Add(oUnsoldDefectiveProduct.RefInvoiceNo.ToString());
                if (oUnsoldDefectiveProduct.RefInvoiceDate != "")
                    oItem.SubItems.Add(Convert.ToDateTime(oUnsoldDefectiveProduct.RefInvoiceDate).ToString("dd-MMM-yyyy"));
                else oItem.SubItems.Add("");
                oItem.Tag = oUnsoldDefectiveProduct;
            }
            SetListViewRowColour();
            this.Text = "Unsold Defective Product List [" + _oUnsoldDefectiveProducts.Count + "]";
        }
        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;

            if (_nType == 1)
            {
                btnAssessedPlan.Visible = false;
                btnCancel.Visible = false;
                btnApproved.Visible = false;
                btnJobNoUpdate.Visible = true;
                btnAcknowledge.Visible = false;
                btnEdit.Visible = false;
            }
            else
            {
                btnJobNoUpdate.Visible = false;
                btnAcknowledge.Visible = true;
            }

            cmbstatus.Items.Clear();
            cmbstatus.Items.Add("<All>");
            //Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSUnsouldDefectiveProductStatus)))
            {
                cmbstatus.Items.Add(Enum.GetName(typeof(Dictionary.POSUnsouldDefectiveProductStatus), GetEnum));
            }
            cmbstatus.SelectedIndex = 0;


            cmbIsCreateJob.Items.Clear();
            cmbIsCreateJob.Items.Add("<All>");
            //Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsCreateJob.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            if (_nType == 1)
                cmbIsCreateJob.SelectedIndex = 1;
            else cmbIsCreateJob.SelectedIndex = 0;

            cmbDefectiveType.Items.Clear();
            cmbDefectiveType.Items.Add("<All>");
            //Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSUnsoldDefectiveProductType)))
            {
                cmbDefectiveType.Items.Add(Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), GetEnum));
            }
            cmbDefectiveType.SelectedIndex = 0;


            //Load PG in combo
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Clear();
            cmbPG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.SelectedIndex = 0;

            //Load Brand in combo
            _oBrands = new Brands();
            _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);

            //Removing the [ALL] in the Brand Object ??!!
            _oBrands.RemoveAt(_oBrands.Count - 1);
            //
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

        }
        private void SetListViewRowColour()
        {
            if (lvwUnsouldDefectiveProducts.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwUnsouldDefectiveProducts.Items)
                {
                    if (oItem.SubItems[8].Text == "Create")
                    {
                        oItem.BackColor = Color.MistyRose;
                    }
                    else if (oItem.SubItems[8].Text == "Assessed")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[8].Text == "Discount_Approved")
                    {
                        oItem.BackColor = Color.Transparent;

                    }
                    else if (oItem.SubItems[8].Text == "Reject")
                    {
                        oItem.BackColor = Color.Silver;

                    }
                    else
                    {
                        oItem.BackColor = Color.LightCyan;
                    }

                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoadControl();

        }
        private void updateSecurity()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            btnAssessedPlan.Enabled = false;
            btnEdit.Enabled = false;
            btnApproved.Enabled = false;
            btnCancel.Enabled = false;
            btnAcknowledge.Enabled = false;
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");

            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {

                    if ("M36.10.1" == sPermissionKey)
                    {
                        btnAssessedPlan.Enabled = true;
                    }
                    if ("M36.10.2" == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }
                    if ("M36.10.3" == sPermissionKey)
                    {
                        btnApproved.Enabled = true;
                    }
                    if ("M36.10.4" == sPermissionKey)
                    {
                        btnCancel.Enabled = true;
                    }
                    if ("M36.10.5" == sPermissionKey)
                    {
                        btnAcknowledge.Enabled = true;
                    }
                }
            }

        }
        private void frmUnsoldDefectiveProductsHO_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
            updateSecurity();
            //chkAll.Checked = true;
            //IsCheck = true;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }

        }

        private void btnAssessedPlan_Click(object sender, EventArgs e)
        {

            if (lvwUnsouldDefectiveProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Status Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UnsoldDefectiveProduct oUnsoldDefectiveProduct = (UnsoldDefectiveProduct)lvwUnsouldDefectiveProducts.SelectedItems[0].Tag;
            if (oUnsoldDefectiveProduct.IsCreateJob == "YES")
            {
                if (oUnsoldDefectiveProduct.Status < 4)
                {
                    frmUnsoldDefectiveStatus oForm = new frmUnsoldDefectiveStatus((int)Dictionary.POSUnsouldDefectiveProductStatus.Assessed);
                    oForm.ShowDialog(oUnsoldDefectiveProduct);
                    if (oForm._IsTrue == true)
                        DataLoadControl();
                }
                else
                {
                    MessageBox.Show("Only create status can be able to reject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Plese create a job first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnAssessed_Click(object sender, EventArgs e)
        {

            if (lvwUnsouldDefectiveProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Status Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UnsoldDefectiveProduct oUnsoldDefectiveProduct = (UnsoldDefectiveProduct)lvwUnsouldDefectiveProducts.SelectedItems[0].Tag;
            if (oUnsoldDefectiveProduct.IsCreateJob == "YES")
            {
                if (oUnsoldDefectiveProduct.Status < 4)
                {
                    frmUnsoldDefectiveStatus oForm = new frmUnsoldDefectiveStatus((int)Dictionary.UnsouldDefectiveProductStatus.Assessed);
                    oForm.ShowDialog(oUnsoldDefectiveProduct);
                    DataLoadControl();
                }
                else
                {
                    MessageBox.Show("Only create status can be able to assessment.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Plese create a job first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (lvwUnsouldDefectiveProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Status Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UnsoldDefectiveProduct oUnsoldDefectiveProduct = (UnsoldDefectiveProduct)lvwUnsouldDefectiveProducts.SelectedItems[0].Tag;
            if (oUnsoldDefectiveProduct.Status == (int)Dictionary.POSUnsouldDefectiveProductStatus.Assessed)
            {
                frmUnsoldDefectiveStatus oForm = new frmUnsoldDefectiveStatus((int)Dictionary.POSUnsouldDefectiveProductStatus.Discount_Approved);
                oForm.ShowDialog(oUnsoldDefectiveProduct);
                if (oForm._IsTrue == true)
                    DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only assessed status can be able to discount approval.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void btnLogNoted_Click(object sender, EventArgs e)
        {
            if (lvwUnsouldDefectiveProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Status Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UnsoldDefectiveProduct oUnsoldDefectiveProduct = (UnsoldDefectiveProduct)lvwUnsouldDefectiveProducts.SelectedItems[0].Tag;
            frmUnsoldDefectiveStatus oForm = new frmUnsoldDefectiveStatus((int)Dictionary.UnsouldDefectiveProductStatus.Log_Noted);
            oForm.ShowDialog(oUnsoldDefectiveProduct);
            DataLoadControl();
        }

        private void btnLogReturn_Click(object sender, EventArgs e)
        {
            if (lvwUnsouldDefectiveProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Status Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UnsoldDefectiveProduct oUnsoldDefectiveProduct = (UnsoldDefectiveProduct)lvwUnsouldDefectiveProducts.SelectedItems[0].Tag;
            frmUnsoldDefectiveStatus oForm = new frmUnsoldDefectiveStatus((int)Dictionary.UnsouldDefectiveProductStatus.Log_Return);
            oForm.ShowDialog(oUnsoldDefectiveProduct);
            DataLoadControl();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwUnsouldDefectiveProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Status Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UnsoldDefectiveProduct oUnsoldDefectiveProduct = (UnsoldDefectiveProduct)lvwUnsouldDefectiveProducts.SelectedItems[0].Tag;
            if (oUnsoldDefectiveProduct.Status != (int)Dictionary.POSUnsouldDefectiveProductStatus.Invoiced)
            {
                frmUnsoldDefectiveStatus oForm = new frmUnsoldDefectiveStatus((int)Dictionary.POSUnsouldDefectiveProductStatus.Reject);
                oForm.ShowDialog(oUnsoldDefectiveProduct);
                if (oForm._IsTrue == true)
                    DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only create or assessed status can be able to reject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnJobNoUpdate_Click(object sender, EventArgs e)
        {
            if (lvwUnsouldDefectiveProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Status Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UnsoldDefectiveProduct oUnsoldDefectiveProduct = (UnsoldDefectiveProduct)lvwUnsouldDefectiveProducts.SelectedItems[0].Tag;
            if (oUnsoldDefectiveProduct.IsCreateJob == "NO")
            {
                frmUnsoldDefectiveStatus oForm = new frmUnsoldDefectiveStatus(0);
                oForm.ShowDialog(oUnsoldDefectiveProduct);
                if (oForm._IsTrue == true)
                    DataLoadControl();
            }
            else
            {
                MessageBox.Show("Job# already assigned", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cmbPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbPG.SelectedIndex == 0)
            {
                _oMAG = null;
                cmbMAG.Items.Clear();
                cmbMAG.Items.Add("<All>");
                cmbMAG.SelectedIndex = 0;
                return;
            }
            int nParentID = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;
            //Load MAG in combo
            _oMAG = new ProductGroups();
            _oMAG.Refresh(nParentID);
            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cmbMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbMAG.SelectedIndex = 0;
        }

        private void cmbMAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbMAG.SelectedIndex == 0)
            {
                _oASG = null;
                cmbASG.Items.Clear();
                cmbASG.Items.Add("<All>");
                cmbASG.SelectedIndex = 0;
                return;
            }

            int nParentID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;
            //Load ASG in combo
            _oASG = new ProductGroups();
            _oASG.Refresh(nParentID);
            cmbASG.Items.Clear();
            cmbASG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cmbASG.Items.Add(oProductGroup.PdtGroupName);
            }

            cmbASG.SelectedIndex = 0;
        }    
        

        private void cmbASG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbASG.SelectedIndex == 0)
            {
                _oAG = null;
                cmbAG.Items.Clear();
                cmbAG.Items.Add("<All>");
                cmbAG.SelectedIndex = 0;
                return;
            }

            int nParentID = _oASG[cmbASG.SelectedIndex - 1].PdtGroupID;
            //Load AG in combo
            _oAG = new ProductGroups();
            _oAG.Refresh(nParentID);
            cmbAG.Items.Clear();
            cmbAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cmbAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbAG.SelectedIndex = 0;

        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linklblMultiSelectBrands_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBrandsMultiSelect oForm = new frmBrandsMultiSelect();
            oForm.ShowDialog();
            linklblMultiSelectBrands.Text = "Selected " + oForm._nCount.ToString() + " Brands";
            _sBrandID = "";
            _sBrandID = oForm._sSelectedBrandID;
            if (_sBrandID != "")
            {
                cmbBrand.SelectedIndex = 0;
                cmbBrand.Enabled = false;
            }
            else
            {
                cmbBrand.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwUnsouldDefectiveProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Status Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UnsoldDefectiveProduct oUnsoldDefectiveProduct = (UnsoldDefectiveProduct)lvwUnsouldDefectiveProducts.SelectedItems[0].Tag;
            
            frmUnsoldDefectiveStatus oForm = new frmUnsoldDefectiveStatus(0);
            oForm.ShowDialog1(oUnsoldDefectiveProduct);
            if (oForm._IsTrue == true)
            DataLoadControl();
            
        }

        private void btnAcknowledge_Click(object sender, EventArgs e)
        {
            if (lvwUnsouldDefectiveProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Acknowledge.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UnsoldDefectiveProduct oUnsoldDefectiveProduct = (UnsoldDefectiveProduct)lvwUnsouldDefectiveProducts.SelectedItems[0].Tag;
            //if (oUnsoldDefectiveProduct.IsDefectiveAcknowledged != 1)
            //{
                frmUnsoldDefectiveAcknowledge oForm = new frmUnsoldDefectiveAcknowledge((int)Dictionary.POSUnsouldDefectiveProductStatus.Send_To_HO);
                oForm.ShowDialog(oUnsoldDefectiveProduct);
                if (oForm._IsTrue == true)
                    DataLoadControl();
            //}
            //else
            //{
            //    MessageBox.Show("Already Acknowledged", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
        }


    }
}
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
    public partial class frmProductComponentACIndoors : Form
    {
        bool IsCheck = false;
        Brands _oBrands;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        public frmProductComponentACIndoors()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductComponentACIndoor oForm = new frmProductComponentACIndoor();
            oForm.ShowDialog();
            oForm.Text = "Add Product Component";
            if (oForm._IsLoadData == true)
            {
                DataLoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProductComponent.SelectedItems.Count != 0)
            {
                ProductComponent oProductComponent = (ProductComponent)lvwProductComponent.SelectedItems[0].Tag;
                frmProductComponentACIndoor oForm = new frmProductComponentACIndoor();
                oForm.Text = "Edit Product Component";
                oForm.ShowDialog(oProductComponent);
                if (oForm._IsLoadData == true)
                {
                    DataLoadControl();
                }

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCombo()
        {
            _oBrands = new Brands();
            _oBrands.GetAllBrand(Dictionary.BrandLevel.MasterBrand);
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;


            //PG
            _oPG = new ProductGroups();
            _oPG.GETPG();
            cboPG.Items.Clear();
            cboPG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cboPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboPG.SelectedIndex = 0;

            //MAG
            _oMAG = new ProductGroups();
            _oMAG.GETMAG();
            cboMAG.Items.Clear();
            cboMAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cboMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboMAG.SelectedIndex = 0;

            //ASG
            _oASG = new ProductGroups();
            _oASG.GETASG();
            cboASG.Items.Clear();
            cboASG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cboASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboASG.SelectedIndex = 0;

            //AG
            _oAG = new ProductGroups();
            _oAG.GETAG();
            cboAG.Items.Clear();
            cboAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cboAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboAG.SelectedIndex = 0;
        }
        private void frmProductComponentACIndoors_Load(object sender, EventArgs e)
        {
            LoadCombo();
            DataLoadControl();
        }
        private void DataLoadControl()
        {

            ProductComponents oProductComponents = new ProductComponents();
            lvwProductComponent.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            bool IsCheck = false;
            if (All.Checked == true)
            {
                IsCheck = true;
            }
            else
            {
                IsCheck = false;
            }
            int nBrand = 0;
            if (cmbBrand.SelectedIndex == 0)
            {
                nBrand = -1;
            }
            else
            {
                nBrand = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            }

            int nAG = 0;
            if (cboAG.SelectedIndex == 0)
            {
                nAG = -1;
            }
            else
            {
                nAG = _oAG[cboAG.SelectedIndex - 1].PdtGroupID;
            }

            int nASG = 0;
            if (cboASG.SelectedIndex == 0)
            {
                nASG = -1;
            }
            else
            {
                nASG = _oASG[cboASG.SelectedIndex - 1].PdtGroupID;
            }

            int nMAG = 0;
            if (cboMAG.SelectedIndex == 0)
            {
                nMAG = -1;
            }
            else
            {
                nMAG = _oMAG[cboMAG.SelectedIndex - 1].PdtGroupID;
            }

            int nPG = 0;
            if (cboPG.SelectedIndex == 0)
            {
                nPG = -1;
            }
            else
            {
                nPG = _oPG[cboPG.SelectedIndex - 1].PdtGroupID;
            }
            oProductComponents.GetACIndoorComponent(dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck, txtProductSL.Text.Trim(), txtBarcodeSerial.Text.Trim(), txtPCBSerial.Text.Trim(), nAG, nASG, nMAG, nPG, nBrand, ctlProduct1.txtCode.Text.Trim());
            this.Text = "Total " + "[" + oProductComponents.Count + "]";
            foreach (ProductComponent oProductComponent in oProductComponents)
            {
                ListViewItem oItem = lvwProductComponent.Items.Add(oProductComponent.ProductCode.ToString());
                oItem.SubItems.Add(oProductComponent.ProductName.ToString());
                oItem.SubItems.Add(oProductComponent.CreateDate.ToString("dd-MMM-yyyy H:mm:ss zzz"));
                oItem.SubItems.Add(oProductComponent.AGName.ToString());
                oItem.SubItems.Add(oProductComponent.ASGName.ToString());
                oItem.SubItems.Add(oProductComponent.MAGName.ToString());
                oItem.SubItems.Add(oProductComponent.PGName.ToString());
                oItem.SubItems.Add(oProductComponent.BrandDesc.ToString());
                oItem.SubItems.Add(oProductComponent.ProductSerial.ToString());
                oItem.SubItems.Add(oProductComponent.BarcodeSerial.ToString());
                oItem.SubItems.Add(oProductComponent.PCBSerial.ToString());
                oItem.Tag = oProductComponent;
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void All_CheckedChanged(object sender, EventArgs e)
        {
            if (All.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }
    }
}
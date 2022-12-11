using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using CJ.Class;
using CJ.Report;
using CJ.Class.Report;
using CJ.Class.IT;


namespace CJ.Win.IT
{
    public partial class frmITEquipments : Form
    {
        ITAssets _oIITAssets;
        public bool _bIsSearch = false;
        public string _sAsset;
        //public bool Istrue = false;
        ITEquipmentTypeDetail _oITEquipmentTypeDetail;

        public frmITEquipments()
        {
            InitializeComponent();
           
        }
       
        private void frmITEquipments_Load(object sender, EventArgs e)
        {
            LoadCombos();
            //RefreshData();
        }       
        private void LoadCombos()
        {
            //Type Name
            _oITEquipmentTypeDetail = new ITEquipmentTypeDetail();
            _oITEquipmentTypeDetail.GetITEquipmentType(true);
            foreach (ITEquipmentType oITEquipmentType in _oITEquipmentTypeDetail)
            {
                cbTypeName.Items.Add(oITEquipmentType.TypeName);
            }
            cbTypeName.Text = "ALL";
        }
        public void RefreshData()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            ITEquipmentType _oITEquipmentType = _oITEquipmentTypeDetail[cbTypeName.SelectedIndex];
            _oIITAssets = new ITAssets();
            lvwITAssetList.Items.Clear();
            DBController.Instance.OpenNewConnection();  
            if(Utility.CompanyInfo=="BLL")
            {
                _oIITAssets.RefreshForBLL_TAB(txtAsset.Text, txtSerial.Text, txtModelNo.Text, txtBrand.Text, _oITEquipmentType.TypeID, ctlEmployee1.txtCode.Text);

            }
            else
            {
                _oIITAssets.Refresh(txtAsset.Text, txtSerial.Text, txtModelNo.Text, txtBrand.Text, _oITEquipmentType.TypeID, ctlEmployee1.txtCode.Text);

            }

            foreach (ITAsset oITAsset in _oIITAssets)
            {
                ListViewItem oItem = lvwITAssetList.Items.Add(oITAsset.AssetNo);
                oItem.SubItems.Add(oITAsset.SerialNo);
                oItem.SubItems.Add(oITAsset.ITEquipment.ModelNo);
                oItem.SubItems.Add(oITAsset.ITEquipment.Brand);
                oItem.SubItems.Add(oITAsset.ITEquipment.ProductNo);
                oItem.SubItems.Add(oITAsset.PDate.ToString("dd-MMM-yyyy"));

                if (oITAsset.CurEmployeeID != -1)
                    oItem.SubItems.Add(oITAsset.Employee.EmployeeName);
                else oItem.SubItems.Add("N/A");

                if (oITAsset.StoreID == -1)
                    oItem.SubItems.Add("System Stock");
                else oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ITEquipmentStock), oITAsset.StoreID));                  
                oItem.Tag = oITAsset;
            }
            this.Text = "Equipments " + "[" + _oIITAssets.Count + "]";
        }
        private void txtAsset_TextChanged(object sender, EventArgs e)
        {          
            //RefreshData();
        }     
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmITEquipment oForm = new frmITEquipment();
            oForm.ShowDialog();
            if (oForm.IsTrue == true)
                RefreshData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwITAssetList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ITAsset oITAsset = (ITAsset)lvwITAssetList.SelectedItems[0].Tag;
            frmITEquipment oForm = new frmITEquipment();
            oForm.ShowDialog(oITAsset);
            if (oForm.IsTrue == true)
                RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwITAssetList_DoubleClick(object sender, EventArgs e)
        {
            if (lvwITAssetList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_bIsSearch == true)
            {
                ITAsset oITAsset = (ITAsset)lvwITAssetList.SelectedItems[0].Tag;
                _sAsset = oITAsset.AssetNo;
                this.Close();
            }
            else
            {
                ITAsset oITAsset = (ITAsset)lvwITAssetList.SelectedItems[0].Tag;
                frmITEquipment oForm = new frmITEquipment();
                oForm.ShowDialog(oITAsset);
                RefreshData();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwITAssetList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ITAsset oITAsset = (ITAsset)lvwITAssetList.SelectedItems[0].Tag;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oITAsset.Delete();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Delete The Equipment", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void btHistory_Click(object sender, EventArgs e)
        {
            if (lvwITAssetList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
          
            ITAsset oITAsset = (ITAsset)lvwITAssetList.SelectedItems[0].Tag;
            frmITEquipmentHistory oForm = new frmITEquipmentHistory();
            oForm.ShowDialog(oITAsset);
            RefreshData();

        }

        private void cbTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RefreshData();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
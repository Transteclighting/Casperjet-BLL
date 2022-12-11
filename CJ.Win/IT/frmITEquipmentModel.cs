using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.IT;

namespace CJ.Win.IT
{
    public partial class frmITEquipmentModel : Form
    {
        ITEquipmentTypeDetail _oITEquipmentTypeDetail;
        ITEquipment _oITEquipment;
        ITEquipmentFeatures _oITEquipmentFeatures;
        ITEquipmentDetail _oITEquipmentDetail;
      
        public frmITEquipmentModel()
        {
            InitializeComponent();
        }

        private void frmEquipmentModel_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
        }
        private void LoadCombos()
        {
           //Type Name
            _oITEquipmentTypeDetail = new ITEquipmentTypeDetail();          
            _oITEquipmentTypeDetail.GetITEquipmentType(false);         
            foreach (ITEquipmentType oITEquipmentType in _oITEquipmentTypeDetail)
            {
                cbTypeName.Items.Add(oITEquipmentType.TypeName);
            }
            cbTypeName.SelectedIndex = 0;
        }
        public void ShowDialog(ITEquipment oITEquipment)
        {
            this.Tag = oITEquipment;          
            LoadCombos();            
            txtBrand.Text = oITEquipment.Brand;          
            txtModelNo.Text = oITEquipment.ModelNo; ;
            txtProductNo.Text = oITEquipment.ProductNo;
            txtRemarks.Text = oITEquipment.Remarks;
            cbTypeName.SelectedIndex = _oITEquipmentTypeDetail.GetIndexByID(oITEquipment.TypeID);
           
            foreach (ITEquipmentDetail oITEquipmentDetail in oITEquipment)
            {
                foreach (DataGridViewRow oItemRow in dgvEquipmentFeature.Rows)
                {
                    if (oItemRow.Index < dgvEquipmentFeature.Rows.Count - 1)
                    {
                        if (oItemRow.Cells[0].Value.ToString() == oITEquipmentDetail.FeatureName)
                        {
                            oItemRow.Cells[1].Value = oITEquipmentDetail.FeatureValue;
                        }
                    }

                }

            }

            this.ShowDialog();
        }

        private void cbTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int j = 0;
            ITEquipmentType oITEquipmentType = _oITEquipmentTypeDetail[cbTypeName.SelectedIndex];
            _oITEquipmentFeatures = new ITEquipmentFeatures();
            dgvEquipmentFeature.Rows.Clear();           
            _oITEquipmentFeatures.GetITEquipmentFeature(oITEquipmentType.TypeID);          
            foreach (ITEquipmentFeature oITEquipmentFeature in _oITEquipmentFeatures)
            {
                dgvEquipmentFeature.Rows.Add();
                dgvEquipmentFeature[0, j].Value = oITEquipmentFeature.FeatureName;
                j++;

            }
           
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (ValidInput())
                Save();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Save()
        {
            ITEquipmentType _oITEquipmentType = _oITEquipmentTypeDetail[cbTypeName.SelectedIndex];

            if (this.Tag == null)
            {
                _oITEquipment = new ITEquipment();

                _oITEquipment.Brand = txtBrand.Text;
                _oITEquipment.ModelNo = txtModelNo.Text;
                _oITEquipment.ProductNo = txtProductNo.Text;
                _oITEquipment.Remarks = txtRemarks.Text;
                _oITEquipment.TypeID = _oITEquipmentType.TypeID;

                foreach (DataGridViewRow oItemRow in dgvEquipmentFeature.Rows)
                {

                    if (oItemRow.Index < dgvEquipmentFeature.Rows.Count - 1)
                    {
                        if (oItemRow.Cells[1].Value != null)
                        {
                            _oITEquipmentDetail = new ITEquipmentDetail();
                            _oITEquipmentDetail.FeatureName = oItemRow.Cells[0].Value.ToString();
                            _oITEquipmentDetail.FeatureValue = oItemRow.Cells[1].Value.ToString();
                            _oITEquipment.Add(_oITEquipmentDetail);
                        }
                    }

                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oITEquipment.Insert();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Equipment Model", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                ITEquipment _oITEquipment = (ITEquipment)this.Tag;

                _oITEquipment.Clear();
                _oITEquipment.Brand = txtBrand.Text;
                _oITEquipment.ModelNo = txtModelNo.Text;
                _oITEquipment.ProductNo = txtProductNo.Text;
                _oITEquipment.Remarks = txtRemarks.Text;
                _oITEquipment.TypeID = _oITEquipmentType.TypeID;                

                foreach (DataGridViewRow oItemRow in dgvEquipmentFeature.Rows)
                {

                    if (oItemRow.Index < dgvEquipmentFeature.Rows.Count - 1)
                    {
                        if (oItemRow.Cells[1].Value != null)
                        {
                            _oITEquipmentDetail = new ITEquipmentDetail();
                            _oITEquipmentDetail.FeatureName = oItemRow.Cells[0].Value.ToString();
                            _oITEquipmentDetail.FeatureValue = oItemRow.Cells[1].Value.ToString();
                            _oITEquipment.Add(_oITEquipmentDetail);
                        }
                    }

                }
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oITEquipment.Update();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Equipment Model", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }
        public bool ValidInput()
        {
            

            if (txtBrand.Text == "")
            {
                MessageBox.Show("Please Entry Brand or NA", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBrand.Focus();
                return false;
            }

            if (txtModelNo.Text == "")
            {
                MessageBox.Show("Please Entry Model No or NA", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModelNo.Focus();
                return false;
            }
            if (txtProductNo.Text == "")
            {
                MessageBox.Show("Please Entry Product Number or NA", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductNo.Focus();
                return false;
            }
            if (dgvEquipmentFeature.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Feature Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }     
    }
}
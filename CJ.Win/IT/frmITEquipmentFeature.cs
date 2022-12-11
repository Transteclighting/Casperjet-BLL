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
    public partial class frmITEquipmentFeature : Form
    {
        ITEquipmentTypeDetail _oITEquipmentTypeDetail;
        ITEquipmentFeature _oITEquipmentFeature;
        ITEquipmentFeatures _oITEquipmentFeatures;

        public frmITEquipmentFeature()
        {
            InitializeComponent();
        }

        private void frmITEquipmentFeature_Load(object sender, EventArgs e)
        {
            LoadCombos();
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

        private void cbTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int j = 0;
            ITEquipmentType oITEquipmentType = _oITEquipmentTypeDetail[cbTypeName.SelectedIndex];
            _oITEquipmentFeatures = new ITEquipmentFeatures();
            dgvEquipmentFeature.Rows.Clear();
            DBController.Instance.OpenNewConnection();
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
            _oITEquipmentFeature = new ITEquipmentFeature(); 
            ITEquipmentType _oITEquipmentType = _oITEquipmentTypeDetail[cbTypeName.SelectedIndex];

            try
            {
                DBController.Instance.BeginNewTransaction();

                _oITEquipmentFeature.TypeID = _oITEquipmentType.TypeID;
                _oITEquipmentFeature.Delete();
                foreach (DataGridViewRow oItemRow in dgvEquipmentFeature.Rows)
                {
                    if (oItemRow.Index < dgvEquipmentFeature.Rows.Count - 1)
                    {
                        if (oItemRow.Cells[0].Value != null)
                        {
                            _oITEquipmentFeature = new ITEquipmentFeature();
                            _oITEquipmentFeature.TypeID = _oITEquipmentType.TypeID;
                            _oITEquipmentFeature.FeatureName = oItemRow.Cells[0].Value.ToString();

                            _oITEquipmentFeature.Insert();
                        }
                    }

                }
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Save The Equipment Model", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbTypeName_SelectedIndexChanged(null,null);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
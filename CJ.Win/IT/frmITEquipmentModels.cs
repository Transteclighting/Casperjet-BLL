// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: June 02,2011
// Time : 12.00 PM
// Description: form for IT Equipment Managenet
// Modify Person And Date:
// </summary>

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
    public partial class frmITEquipmentModels : Form
    {
       
        ITEquipmentTypeDetail _oITEquipmentTypeDetail;
        public ITEquipment _oITEquipment;
        bool _bIsSeqarch;

        public frmITEquipmentModels()
        {
            InitializeComponent();
        }

        public void ShowDialog(bool IsSeqarch)
        {
            if (IsSeqarch == true)
            {
                btnAdd.Visible = false;
                btndelete.Visible = false;
                btnEdit.Visible = false;
            }
            _bIsSeqarch = IsSeqarch;
            this.ShowDialog();
        }

        private void frmITEquipments_Load(object sender, EventArgs e)
        {
            //Type Name        
            cbType.Items.Clear();
            _oITEquipmentTypeDetail = new ITEquipmentTypeDetail();
            _oITEquipmentTypeDetail.GetITEquipmentType(false);
            foreach (ITEquipmentType oITEquipmentType in _oITEquipmentTypeDetail)
            {
                cbType.Items.Add(oITEquipmentType.TypeName);
            }
            cbType.SelectedIndex = 0;

            RefreshData();
         
        }       
        public void RefreshData()
        {
            ITEquipmentType _oITEquipmentType = _oITEquipmentTypeDetail[cbType.SelectedIndex];
            ITEquipments oITEquipments = new ITEquipments();
            lvwITEquipmentList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oITEquipments.Refresh(_oITEquipmentType.TypeID, txtModel.Text);

            foreach (ITEquipment oITEquipment in oITEquipments)
            {
                ListViewItem oItem = lvwITEquipmentList.Items.Add(oITEquipment.Brand);             
                oItem.SubItems.Add(oITEquipment.ModelNo);               
                oItem.SubItems.Add(oITEquipment.ProductNo);              
                oItem.Tag = oITEquipment;
            }
            this.Text = "Equipments Models " + "[" + oITEquipments.Count + "]";
        }
        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            if (txtModel.Text !="")
            RefreshData();
        }
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmITEquipmentModel oForm = new frmITEquipmentModel();
            oForm.ShowDialog();
            RefreshData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwITEquipmentList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ITEquipment oITEquipment = (ITEquipment)lvwITEquipmentList.SelectedItems[0].Tag;
            frmITEquipmentModel oForm = new frmITEquipmentModel();
            oForm.ShowDialog(oITEquipment);
            RefreshData();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwITEquipmentList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ITEquipment _oITEquipment = (ITEquipment)lvwITEquipmentList.SelectedItems[0].Tag;
            _oITEquipment.Clear();
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oITEquipment.Delete();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Delete The Equipment", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
            RefreshData();
        }
        private void lvwITEquipmentList_DoubleClick(object sender, EventArgs e)
        {
            if (lvwITEquipmentList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_bIsSeqarch == true)
            {
                _oITEquipment = (ITEquipment)lvwITEquipmentList.SelectedItems[0].Tag;
                this.Close();
            }
            else
            {
                _oITEquipment = (ITEquipment)lvwITEquipmentList.SelectedItems[0].Tag;
                frmITEquipmentModel oForm = new frmITEquipmentModel();
                oForm.ShowDialog(_oITEquipment);
                RefreshData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
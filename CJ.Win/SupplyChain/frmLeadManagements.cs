using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.SupplyChain;

namespace CJ.Win.SupplyChain
{
    public partial class frmLeadManagements : Form
    {
        Brands _oBrands;
        ProductGroups _oProductGroups;
        Leads _oLeads;
        LeadManagements _oLeadManagements;

        public frmLeadManagements()
        {
            InitializeComponent();
        }
        private void LoadCombo()
        {
            //Brand
            _oBrands = new Brands();
            _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;
            
            //Lead
            _oLeads = new Leads();
            _oLeads.Refresh();
            cmbLead.Items.Clear();
            cmbLead.Items.Add("<All>");
            foreach (Lead oLead in _oLeads)
            {
                cmbLead.Items.Add(oLead.LeadDescription);
            }
            cmbLead.SelectedIndex = 0;

            //ASG

            _oProductGroups = new ProductGroups();
            _oProductGroups.Refresh(Dictionary.ProductGroupType.ASG);
            cmbASG.Items.Clear();
            cmbASG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oProductGroups)
            {
                cmbASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbASG.SelectedIndex = 0;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmLeadManagement oform = new frmLeadManagement();
            oform.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwLeadManagement.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LeadManagement oLeadManagement = (LeadManagement)lvwLeadManagement.SelectedItems[0].Tag;
            frmLeadManagement oForm = new frmLeadManagement();
            oForm.ShowDialog(oLeadManagement);
            DataLoadControl();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwLeadManagement.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LeadManagement oLeadManagement = (LeadManagement)lvwLeadManagement.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Lead Setting: " + oLeadManagement.LeadManagementID.ToString() + " ? ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oLeadManagement.Delete();
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmLeadManagements_Load(object sender, EventArgs e)
        {
            LoadCombo();
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            _oLeadManagements = new LeadManagements();
            lvwLeadManagement.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int nBrandID = 0;
            int nASGID = 0;
            int nLeadID = 0;
            if (cmbBrand.SelectedIndex != 0)
            {
                nBrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            }
            else
            {
                nBrandID = - 1;
            }
            if (cmbASG.SelectedIndex != 0)
            {
                nASGID = _oProductGroups[cmbASG.SelectedIndex - 1].PdtGroupID;
            }
            else
            {
                nASGID = - 1;
            }
            if (cmbLead.SelectedIndex != 0)
            {
                nLeadID = _oLeads[cmbLead.SelectedIndex - 1].LeadID;
            }
            else
            {
                nLeadID = - 1;
            }


            _oLeadManagements.Refresh(txtID.Text.Trim(), nBrandID, nASGID, nLeadID);
            this.Text = "Total Lead Setting " + "[" + _oLeadManagements.Count + "]";
            foreach (LeadManagement oLeadManagement in _oLeadManagements)
            {
                ListViewItem oItem = lvwLeadManagement.Items.Add(oLeadManagement.LeadManagementID.ToString());
                oItem.SubItems.Add(oLeadManagement.ASGName);
                oItem.SubItems.Add(oLeadManagement.BrandName);
                oItem.SubItems.Add(oLeadManagement.LeadDesc);
                oItem.SubItems.Add(oLeadManagement.LeadDays.ToString());

                oItem.Tag = oLeadManagement;
            }
        }

        private void lvwLeadManagement_DoubleClick(object sender, EventArgs e)
        {
            if (lvwLeadManagement.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LeadManagement oLeadManagement = (LeadManagement)lvwLeadManagement.SelectedItems[0].Tag;
            frmLeadManagement oForm = new frmLeadManagement();
            oForm.ShowDialog(oLeadManagement);
            DataLoadControl();
        }
    }
}
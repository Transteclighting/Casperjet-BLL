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
    public partial class frmLeadManagement : Form
    {
        LeadManagement _oLeadManagement;
        Brands _oBrands;
        Leads _oLeads;
        ProductGroups _oProductGroups;

        public frmLeadManagement()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUI())
            {
                Save();
                this.Close();
            }
            
        }
        private void Save()
        {
            _oLeadManagement = new LeadManagement();
            if (this.Tag == null)
            {
                _oLeadManagement.ASGID = _oProductGroups[cmbASG.SelectedIndex - 1].PdtGroupID;
                _oLeadManagement.BrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
                _oLeadManagement.LeadID = _oLeads[cmbLead.SelectedIndex - 1].LeadID;
                _oLeadManagement.LeadDays = Convert.ToInt32(txtLeadTime.Text.Trim());

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oLeadManagement.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

            else
            {
                _oLeadManagement = (LeadManagement)this.Tag;

                _oLeadManagement.ASGID = _oProductGroups[cmbASG.SelectedIndex - 1].PdtGroupID;
                _oLeadManagement.BrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
                _oLeadManagement.LeadID = _oLeads[cmbLead.SelectedIndex - 1].LeadID;
                _oLeadManagement.LeadDays = Convert.ToInt32(txtLeadTime.Text.Trim());

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oLeadManagement.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Update Successfully. ID : " + _oLeadManagement.LeadManagementID.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        public void ShowDialog(LeadManagement oLeadManagement)
        {
            this.Tag = oLeadManagement;
            LoadCombo();
            txtLeadTime.Text = oLeadManagement.LeadDays.ToString();
            cmbASG.SelectedIndex = _oProductGroups.GetIndex(oLeadManagement.ASGID) + 1;
            cmbBrand.SelectedIndex = _oBrands.GetIndex(oLeadManagement.BrandID) + 1;
            cmbLead.SelectedIndex = _oLeads.GetIndex(oLeadManagement.LeadID) + 1;
            this.ShowDialog();
        }

        private bool ValidateUI()
        {
            if (cmbASG.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select ASG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbASG.Focus();
                return false;
            }
            if (cmbBrand.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus();
                return false;
            }
            if (cmbLead.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Lead desc", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLead.Focus();
                return false;
            }
            if (txtLeadTime.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Lead Time (Days)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLeadTime.Focus();
                return false;
            }
            else
            {
                try
                {
                    int tmp = Convert.ToInt32(txtLeadTime.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Please Input valid Lead Time (Days)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLeadTime.Focus();
                    return false;
                }
            }
            return true;
        }
        private void LoadCombo()
        {
            //Brand
            _oBrands = new Brands();
            _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<Select>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            //Lead
            _oLeads = new Leads();
            _oLeads.Refresh();
            cmbLead.Items.Clear();
            cmbLead.Items.Add("<Select>");
            foreach (Lead oLead in _oLeads)
            {
                cmbLead.Items.Add(oLead.LeadDescription);
            }
            cmbLead.SelectedIndex = 0;

            //ASG

            _oProductGroups = new ProductGroups();
            _oProductGroups.Refresh(Dictionary.ProductGroupType.ASG);
            cmbASG.Items.Clear();
            cmbASG.Items.Add("<Select>");
            foreach (ProductGroup oProductGroup in _oProductGroups)
            {
                cmbASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbASG.SelectedIndex = 0;

        }

        private void frmLeadManagement_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Lead Setting";
                LoadCombo();
            }
            else
            {
                this.Text = "Edit Lead Setting";
            }
        }
    }
}
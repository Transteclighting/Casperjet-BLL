using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Accounts;

namespace CJ.Win.Accounts
{
    public partial class frmEMIBankMappings : Form
    {

        private Banks _oBanks;
        private EMITenures _oEMITenures;
        private EMIBankMappings _oEMIBankMappings;
        public frmEMIBankMappings()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEMIBankMapping oForm = new frmEMIBankMapping();
            oForm.ShowDialog();
            if (oForm._bActionSave)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwEMIBankMapping.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EMIBankMapping oEMIBankMapping = (EMIBankMapping)lvwEMIBankMapping.SelectedItems[0].Tag;

            frmEMIBankMapping ofrmfrmEMIBankMapping = new frmEMIBankMapping();
            ofrmfrmEMIBankMapping.ShowDialog(oEMIBankMapping);
            if (ofrmfrmEMIBankMapping._bActionSave)
                LoadData();
        }

        private void double_Click(object sender, EventArgs e)
        {
            if (lvwEMIBankMapping.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EMIBankMapping oEMIBankMapping = (EMIBankMapping)lvwEMIBankMapping.SelectedItems[0].Tag;

            frmEMIBankMapping ofrmfrmEMIBankMapping = new frmEMIBankMapping();
            ofrmfrmEMIBankMapping.ShowDialog(oEMIBankMapping);
            if (ofrmfrmEMIBankMapping._bActionSave)
                LoadData();
        }

        private void LoadData()
        {
            lvwEMIBankMapping.Items.Clear();

            string bankId = null;
            string emiTenureId = null;

            if (cmbBank.SelectedIndex != 0)
            {
               bankId = _oBanks[cmbBank.SelectedIndex - 1].BankID.ToString();
            }

            if (cmbTenure.SelectedIndex != 0)
            {
               emiTenureId = _oEMITenures[cmbTenure.SelectedIndex - 1].EMITenureID.ToString();
            }
            DBController.Instance.OpenNewConnection();
            _oEMIBankMappings = new EMIBankMappings();
            _oEMIBankMappings.Refresh(bankId, emiTenureId);
            foreach (EMIBankMapping oEMIBankMapping in _oEMIBankMappings)
            {
                ListViewItem oItem = lvwEMIBankMapping.Items.Add(oEMIBankMapping.BankName.ToString());
                oItem.SubItems.Add(oEMIBankMapping.Tenure.ToString());
                oItem.Tag = oEMIBankMapping;
            }
            this.Text = "EMI Bank Mapping List-" + _oEMIBankMappings.Count + "";
        }

        private void LoadCombo()
        {
            _oBanks = new Banks();
            _oEMITenures = new EMITenures();

            DBController.Instance.OpenNewConnection();

            _oBanks.GetEMIBankForMapping();

            cmbBank.Items.Add("ALL");
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.SelectedIndex = 0;

            _oEMITenures.GetEMITenure();
            cmbTenure.Items.Add("All");
            foreach (EMITenure oEMITenure in _oEMITenures)
            {
                cmbTenure.Items.Add(oEMITenure.Tenure);
            }
            cmbTenure.SelectedIndex = 0;
        }

        private void frmEMIBankMappings_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();
            }
            LoadData();
        }
    }
}

// <summary>
// Compamy: Transcom Electronics Limited
// Author: Uttam kar
// Date: May 2, 2014
// Time :  4:55 PM
// Description: Forms for Add/Edit of Warehouse.
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

namespace CJ.Win.Basic
{
    public partial class frmBankBranches : Form
    {
        Branch _oBranch;
        Branchs _oBranchs;
        public frmBankBranches()
        {
            _oBranch = new Branch();
            _oBranchs = new Branchs();
            InitializeComponent();
        }

        private void frmBankBranches_Load(object sender, EventArgs e)
        {
            LoadData();
            this.Text = "BankBranches " + "[" + _oBranchs.Count + "]";
        }

        private void LoadData()
        {
            lvwBranch.Items.Clear();
            DBController.Instance.OpenNewConnection();

            _oBranchs.Refresh();

            foreach (Branch oBranch in _oBranchs)
            {
                ListViewItem oItem = lvwBranch.Items.Add(oBranch.Code);
                oItem.SubItems.Add(oBranch.Name);
                oItem.SubItems.Add(oBranch.Address);
                oItem.SubItems.Add(oBranch.Telephone);
                oItem.SubItems.Add(oBranch.Bank.Name);
                oItem.Tag = oBranch;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwBranch.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Channel to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oBranch = (Branch)lvwBranch.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Bank: " + _oBranch.Code + " ? ", "Confirm Bank Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oBranch.Delete();
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBankBranch oForm = new frmBankBranch();
            oForm.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBranch.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Bank Id to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oBranch = (Branch)lvwBranch.SelectedItems[0].Tag;
            frmBankBranch oForm = new frmBankBranch();
            oForm.ShowDialog(_oBranch);
            LoadData();
        }
    }
}
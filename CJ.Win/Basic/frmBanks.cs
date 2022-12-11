// <summary>
// Compamy: Transcom Electronics Limited
// Author:Uttam Kar 30-Apr-2014.
// Date: April 25, 2011
// Time :  12:00 PM
// Description: Bank Information.
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
    public partial class frmBanks : Form
    {
        Bank _oBank;
        Banks _oBanks;
        public frmBanks()
        {
            _oBank = new Bank();
            _oBanks = new Banks();
            InitializeComponent();
        }

        private void frmBanks_Load(object sender, EventArgs e)
        {
            LoadData();
            this.Text = "Banks " + "[" + _oBanks.Count + "]";
        }

        private void LoadData()
        {
            lvwBanks.Items.Clear();
            DBController.Instance.OpenNewConnection();

            _oBanks.Refresh();

            foreach (Bank oBank in _oBanks)
            {
                ListViewItem oItem = lvwBanks.Items.Add(oBank.Code);
                oItem.SubItems.Add(oBank.Name);
                oItem.SubItems.Add(oBank.Description);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsEMI), oBank.IsEMI));
                oItem.Tag = oBank;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBank oForm = new frmBank();
            oForm.ShowDialog();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwBanks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Channel to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oBank = (Bank)lvwBanks.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Bank: " + _oBank.Code + " ? ", "Confirm Bank Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oBank.Delete();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBanks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Bank Id to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oBank = (Bank)lvwBanks.SelectedItems[0].Tag;
            frmBank oForm = new frmBank();
            oForm.ShowDialog(_oBank);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
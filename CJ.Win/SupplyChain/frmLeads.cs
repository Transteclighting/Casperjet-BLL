// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jun 29, 2014
// Time :  5:37 PM
// Description: Form for SCM Leads.
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
using CJ.Class.SupplyChain;

namespace CJ.Win.SupplyChain
{
    public partial class frmLeads : Form
    {
        Leads _oLeads;
        public frmLeads()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwLeads.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Lead oLead = (Lead)lvwLeads.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Lead Description: " + oLead.LeadID.ToString() + " ? ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oLead.Delete();
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
        private void DataLoadControl()
        {
            _oLeads = new Leads();
            lvwLeads.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oLeads.Refresh( txtDescription.Text);
            this.Text = "Lead " + "[" + _oLeads.Count + "]";
            foreach (Lead oLead in _oLeads)
            {
                ListViewItem oItem = lvwLeads.Items.Add(oLead.LeadID.ToString());
                oItem.SubItems.Add(oLead.LeadDescription);
                oItem.Tag = oLead;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmLead oForm = new frmLead();
            oForm.ShowDialog();
            DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwLeads.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Lead oLead = (Lead)lvwLeads.SelectedItems[0].Tag;
            frmLead oForm = new frmLead();
            oForm.ShowDialog(oLead);
            DataLoadControl();
        }

        private void frmLeads_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void lvwLeads_DoubleClick(object sender, EventArgs e)
        {
            if (lvwLeads.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Lead oLead = (Lead)lvwLeads.SelectedItems[0].Tag;
            frmLead oForm = new frmLead();
            oForm.ShowDialog(oLead);
            DataLoadControl();
        }

    }
}
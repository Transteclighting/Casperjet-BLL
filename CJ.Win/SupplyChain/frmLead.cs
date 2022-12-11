// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jun 29, 2014
// Time :  5:37 PM
// Description: Form for SCM Lead.
// Modify Person And Date: 
// </summary>


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.SupplyChain;
using CJ.Class;

namespace CJ.Win.SupplyChain
{
    public partial class frmLead : Form
    {
        Lead _oLead;

        public frmLead()
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
        private void frmLead_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Lead Description";
            }
            else
            {
                this.Text = "Edit Lead Description";
            }
        }
        private void Save()
        {
            _oLead = new Lead();
            if (this.Tag == null)
            {
                _oLead.LeadDescription = txtDescription.Text.Trim();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oLead.Add();
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
                _oLead = (Lead)this.Tag;
                _oLead.LeadDescription = txtDescription.Text.Trim();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oLead.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Update Successfully. Lead ID : " + _oLead.LeadID.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        public void ShowDialog(Lead oLead)
        {
            this.Tag = oLead;
            txtDescription.Text = oLead.LeadDescription;
            this.ShowDialog();
        }

        private bool ValidateUI()
        {
            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Lead Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            return true;
        }
    }
}


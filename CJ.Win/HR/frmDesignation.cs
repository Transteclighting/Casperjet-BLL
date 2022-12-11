using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.Win
{
    public partial class frmDesignation : Form
    {
        public bool _IsTrue = false;
        public frmDesignation()
        {
            InitializeComponent();
        }

        public void ShowDialog(Designation oDesignation)
        {
            this.Tag = oDesignation;
            txtCode.Text = oDesignation.DesignationCode;
            txtName.Text = oDesignation.DesignationName;
            if (oDesignation.IsActive == true)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            this.ShowDialog();
        }

        private void frmDesignation_Load(object sender, EventArgs e)
        {
            if(this.Tag==null) this.Text = "Add New Designation";
            else this.Text = "Edit Designation";
        }


        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code of Designation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name if Designation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }


            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                _IsTrue = true;
                //btnClear_Click(sender, e);
                this.Close();
            }
        }


        private void Save()
        {
            if (this.Tag == null)
            {
                Designation oDesignation = new Designation();
                oDesignation.DesignationCode = txtCode.Text;
                oDesignation.DesignationName = txtName.Text;
                if (chkIsActive.Checked == true)
                    oDesignation.IsActive = true;
                else oDesignation.IsActive = false;
                
                

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDesignation.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oDesignation.DesignationCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                Designation oDesignation = (Designation)this.Tag;
                oDesignation.DesignationCode = txtCode.Text;
                oDesignation.DesignationName = txtName.Text;
                if (chkIsActive.Checked == true)
                    oDesignation.IsActive = true;
                else oDesignation.IsActive = false;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDesignation.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Designation : " + oDesignation.DesignationCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }


    }
}
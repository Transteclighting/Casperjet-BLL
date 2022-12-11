using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmHRPositionRoleType : Form
    {

        private string checkDuplicateValue;

        HRPositionRole oHRPositionRole;

        public bool _bActionSave = false;
        int nID = 0;

        public frmHRPositionRoleType()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }

        private void txtClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(HRPositionRole oHRPositionRole)
        {
            this.Tag = oHRPositionRole;
            nID = oHRPositionRole.ID;
            txtRoleTypeName.Text = oHRPositionRole.Name.ToString();

            if (oHRPositionRole.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            this.ShowDialog();
        }

        private void Save()
        {
            if (this.Tag == null)
            {

                HRPositionRole oHRPositionRole = new HRPositionRole();

                oHRPositionRole.Name = txtRoleTypeName.Text;
                oHRPositionRole.Type = 1;
                oHRPositionRole.CreateDate = DateTime.Now.Date;
                oHRPositionRole.CreateUserID = Utility.UserId;

                if (chkIsActive.Checked)
                {
                    oHRPositionRole.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oHRPositionRole.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRPositionRole.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                HRPositionRole oHRPositionRole = (HRPositionRole)this.Tag;
                oHRPositionRole.ID = nID;
                oHRPositionRole.Name = txtRoleTypeName.Text;

                oHRPositionRole.UpdateUserID = Utility.UserId;
                oHRPositionRole.UpdateDate = DateTime.Now;

                if (chkIsActive.Checked)
                {
                    oHRPositionRole.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oHRPositionRole.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRPositionRole.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private bool UIValidation()
        {
            if (string.IsNullOrEmpty(txtRoleTypeName.Text))
            {
                MessageBox.Show("Please insert role name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoleTypeName.Focus();
                return false;
            }

            //HRPositionRole oHRPositionRole = new HRPositionRole();
            //oHRPositionRole.Name = txtRoleName.Text;
            //oHRPositionRole.Type = 2;
            //checkDuplicateValue = oHRPositionRole.CheckDuplicateData();

            //frmHRPositionRole ofrmHRPositionRole = new frmHRPositionRole();

            //if (checkDuplicateValue == "Yes")
            //{
            //    MessageBox.Show("HR position role name already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtRoleName.Focus();
            //    return false;
            //}


            return true;

        }

    }
}

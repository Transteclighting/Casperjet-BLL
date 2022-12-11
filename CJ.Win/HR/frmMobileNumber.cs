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
    public partial class frmMobileNumber : Form
    {
        public frmMobileNumber()
        {
            InitializeComponent();
        }

        private void frmMobileNumber_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Mobile Number";
                cmbStatus.Visible = false;
                lblID.Visible = false;
                lblStatus.Visible = false;
                txtID.Visible = false;
                this.Size = new Size(335, 134);
                lblMobileNo.Location = new Point(14, 26);
                txtMobileNo.Location = new Point(71, 23);
                btnSave.Location = new Point(128, 60);
                btnClose.Location = new Point(212, 60);
            }
            else
            {
                this.Text = "Edit Mobile Number";

            }
            LoadCombos();
        }
        public void ShowDialog(MobileNumberAssign oMobileNumberAssign)
        {
            this.Tag = oMobileNumberAssign;

            txtID.Text = oMobileNumberAssign.MobileID.ToString();
            txtMobileNo.Text = oMobileNumberAssign.MobileNumber;
            this.ShowDialog();
        }
        private void LoadCombos()
        {

            //Employee Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MobileSIMStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.MobileSIMStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = (int)Dictionary.MobileSIMStatus.Active;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
                //DataLoadControl();
            }
        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtMobileNo.Text == "")
            {
                MessageBox.Show("Please Enter The Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
                return false;
            }

            if (txtMobileNo.Text.Length != 13)
            {
                MessageBox.Show("Please Re-Check The Mobile Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNo.Focus();
                return false;
            }

            else if (cmbStatus.Text == "")
            {
                MessageBox.Show("Please Select Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }


            #endregion

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                MobileNumberAssign oMobileNumberAssign = new MobileNumberAssign();
                oMobileNumberAssign.MobileNumber = txtMobileNo.Text;
                oMobileNumberAssign.Status = (int)Dictionary.MobileSIMStatus.Active;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oMobileNumberAssign.AddMobileNumber();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Mobile Number : " + oMobileNumberAssign.MobileNumber, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)this.Tag;
                oMobileNumberAssign.ID = Convert.ToInt32(txtID.Text);
                oMobileNumberAssign.MobileNumber = txtMobileNo.Text;
                oMobileNumberAssign.Status = cmbStatus.SelectedIndex + 1;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oMobileNumberAssign.EditMobileNumber();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update Mobile Number : " + oMobileNumberAssign.MobileNumber, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }


        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
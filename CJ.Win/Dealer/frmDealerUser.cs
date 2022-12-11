using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Dealer
{
    public partial class frmDealerUser : Form
    {
        public frmDealerUser()
        {
            InitializeComponent();
        }
        public void ShowDialog(DealerUser oDealerUser)
        {
            txtUserName.Text = oDealerUser.UserName;
            txtUserFullName.Text = oDealerUser.UserFullName;
            ctlCustomer1.txtCode.Text = oDealerUser.CustomerCode;
            ctlCustomer1.SelectedCustomer.CustomerID = oDealerUser.CustomerID;

            txtPassword.Text = oDealerUser.Password;
            txtConfimrPassword.Text = oDealerUser.Password;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            txtConfimrPassword.Enabled = false;
            chkIsActive.Visible = true;
            chkResetPassword.Visible = true;
            btnSave.Text = @"Edit";
            chkIsActive.Checked = oDealerUser.IsActive == (int) Dictionary.IsActive.Active;
            Tag = oDealerUser;
            ShowDialog();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUiInput())
            {
                Save();
                Close();
            }
        }
        private void Save()
        {
            if (Tag == null)
            {
                DealerUser oDealerUser = new DealerUser
                {
                    UserName = txtUserName.Text.Trim(),
                    UserFullName = txtUserFullName.Text.Trim()
                };
                PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);
                string sSaltValue = mph.CreateSalt();
                oDealerUser.Password = mph.CreateHash(txtPassword.Text, sSaltValue);
                oDealerUser.Salt = sSaltValue;
                oDealerUser.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                oDealerUser.CreateUserID = Utility.UserId;
                oDealerUser.CreateDate = DateTime.Now;                
                oDealerUser.IsActive = (int) Dictionary.IsActive.Active;
               

                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oDealerUser.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show(@"You Have Successfully Created User", "Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, @"Error!!!");
                }
            }
            else
            {
                DealerUser oDealerUser = (DealerUser) Tag;
                oDealerUser.UserName = txtUserName.Text.Trim();
                oDealerUser.UserFullName = txtUserFullName.Text.Trim();
                if (chkResetPassword.Checked)
                {
                    PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);
                    string sSaltValue = mph.CreateSalt();
                    oDealerUser.Password = mph.CreateHash(txtPassword.Text, sSaltValue);
                    oDealerUser.Salt = sSaltValue;
                }
                
                oDealerUser.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                if (chkIsActive.Checked)
                {
                    oDealerUser.IsActive = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    oDealerUser.IsActive = (int)Dictionary.IsActive.InActive;
                }
                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oDealerUser.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show(@"You Have Successfully Edited User", @"Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, @"Error!!!");
                }
            }
        }
        private bool ValidateUiInput()
        {
            if (txtUserName.Text == string.Empty)
            {
                MessageBox.Show(@"Please Enter User Name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return false;
            }
            if (txtUserFullName.Text == string.Empty)
            {
                MessageBox.Show(@"Please Enter User Full Name",@"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserFullName.Focus();
                return false;
            }
            if (ctlCustomer1.txtDescription.Text == string.Empty)
            {
                MessageBox.Show(@"Please Select Valid User Customer", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.Focus();
                return false;
            }
            if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show(@"Please Enter Password", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            if (txtConfimrPassword.Text == string.Empty)
            {
                MessageBox.Show(@"Please Enter Confirm Password", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfimrPassword.Focus();
                return false;
            }
            if (txtPassword.Text != txtConfimrPassword.Text)
            {
                MessageBox.Show(@"Password Doesn't Match With Confirm Password", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void frmDealerUser_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                chkIsActive.Visible = false;
                chkResetPassword.Visible = false;
            }
        }

        private void chkResentPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkResetPassword.Checked == true)
            {
                txtPassword.Enabled = true;
                txtConfimrPassword.Enabled = true;
                txtPassword.Text = string.Empty;
                txtConfimrPassword.Text = string.Empty;
            }
            else
            {
                DealerUser oDealerUser = (DealerUser)this.Tag;
                txtPassword.Text = oDealerUser.Password;
                txtConfimrPassword.Text = oDealerUser.Password;
                txtPassword.Enabled = false;
                txtConfimrPassword.Enabled = false;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmDealerUser_Click(object sender, EventArgs e)
        {
            if (ctlCustomer1.SelectedCustomer != null && txtUserFullName.Text.Trim() == String.Empty)
            {
                txtUserFullName.Text = ctlCustomer1.SelectedCustomer.CustomerName;
            }
            
        }
    }
}
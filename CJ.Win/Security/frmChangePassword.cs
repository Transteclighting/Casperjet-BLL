/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Shyam Sundar Biswas
/// Date: March 21, 2011
/// Time : 10:00 PM
/// Description: User Password Change form.
/// Modify Person And Date:
/// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Library;

namespace CJ.Win.Security
{
    public partial class frmChangePassword : Form
    {
        private int nUserId;

        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            nUserId = Utility.UserId;
            txtUserName.Text = Utility.UserFullname;
            txtLogin.Text = Utility.Username;

        }

        public int Equals(string x, string y)
        {
            int i;
            i = string.Compare(x, y);
            return i;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            User oUser;

            int i = this.Equals(this.txtNewPass.Text.Trim(), this.txtConfirmPass.Text.Trim());
            if (i != 0)
            {
                MessageBox.Show("Confirm Password is incorrect", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtNewPass.Text == "")
            {
                MessageBox.Show("Please Enter Correct Password  ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oUser= new User();
           
            DBController.Instance.OpenNewConnection();

            if (oUser.authenticate(txtLogin.Text) != false)
            {
                PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);

                string sHashValue = mph.CreateHash(txtOldPassword.Text, oUser.Salt);
                if (oUser.UserPassword.CompareTo(sHashValue) != 0)
                {
                    AppLogger.LogWarning("Invalid old password"+ Utility.Username);
                    MessageBox.Show("Invalid old password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    oUser = new User();
                    mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);
                    string sSaltValue = mph.CreateSalt();
                    oUser.UserId = nUserId;
                    oUser.UserPassword = mph.CreateHash(txtConfirmPass.Text, sSaltValue);
                    oUser.Salt = sSaltValue;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oUser.changepassword();
                        DBController.Instance.CommitTransaction();
                        AppLogger.LogInfo("Successfully Upadte The Password"+ Utility.Username);
                        MessageBox.Show("You Have Successfully Upadte The Password. ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        AppLogger.LogError("Unsuccessfull Upadte The Password" + Utility.Username);
                        MessageBox.Show(ex.Message, "Error!!!");

                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
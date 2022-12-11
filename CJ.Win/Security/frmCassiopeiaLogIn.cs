using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RSMS.Objects;

namespace CJ.Win.Security
{
    public partial class frmCassiopeiaLogIn : Form
    {
        public frmCassiopeiaLogIn()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                User.Login(txtUsername.Text, txtPassword.Text, UserOfSystem.HeadOffice);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Your UserName or Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
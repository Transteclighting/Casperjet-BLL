using System;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Security
{
    public partial class frmUserOther : Form
    {
        public frmUserOther()
        {
            InitializeComponent();
        }

        public void ShowDialog(UserOther anUserOther)
        {
            txtUserName.Enabled = false;
            this.Tag = anUserOther;
            txtUserName.Text = anUserOther.UserName;
            txtUserFullName.Text = anUserOther.UserFullName;

            chkResetPassword.Enabled = false;
            chkIsActive.Enabled = false;
        }

        private bool ValidateUiInput()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text.Trim()))
            {
                MessageBox.Show(@"Please Enter User Name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUserFullName.Text.Trim()))
            {
                MessageBox.Show(@"Please Enter User Full Name", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserFullName.Focus();
                return false;
            }
            if (cmbPermittedApp.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please Select Permitted App", @"Warning", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                cmbPermittedApp.Focus();
                return false;
            }
            if (cmbPermittedApp.Text == @"E_Csd" && ctlCSDTechnician1.txtDescription.Text == string.Empty)
            {
                MessageBox.Show(@"Please Select Valid Technician", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                ctlCSDTechnician1.Focus();
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
                MessageBox.Show(@"Please Enter Confirm Password", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtConfimrPassword.Focus();
                return false;
            }
            if (txtPassword.Text != txtConfimrPassword.Text)
            {
                MessageBox.Show(@"Password Doesn't Match With Confirm Password", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
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
                UserOther oUser = new UserOther
                {
                    UserName = txtUserName.Text.Trim(),
                    UserFullName = txtUserFullName.Text.Trim()
                };
                PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);
                string sSaltValue = mph.CreateSalt();
                oUser.Password = mph.CreateHash(txtPassword.Text, sSaltValue);
                oUser.Salt = sSaltValue;
                if (cmbPermittedApp.Text == "E_Csd")
                {
                    oUser.UserName += ".csdtp";
                    oUser.InstrumentId = ctlCSDTechnician1.SelectedTechnician.TechnicianID;
                }
                oUser.CreateUserID = Utility.UserId;
                oUser.CreateDate = DateTime.Now;
                oUser.AppID = cmbPermittedApp.SelectedIndex;
                oUser.IsActive = true;


                if (cmbPermittedApp.Text == "CJ_Apps")
                {
                    oUser.AppID = (int)Dictionary.AndroidAppID.CJ_Apps;

                }
                else if (cmbPermittedApp.Text == "CJ_Digital")
                {
                    oUser.AppID = (int) Dictionary.AndroidAppID.CJ_Digital;

                }
                else if (cmbPermittedApp.Text == "CJ_Lighting")
                {
                    oUser.AppID = (int) Dictionary.AndroidAppID.CJ_Lighting;

                }
                else if (cmbPermittedApp.Text == "E_Csd")
                {
                    oUser.AppID = (int) Dictionary.AndroidAppID.E_Csd;

                }
                else if (cmbPermittedApp.Text == "E_DMS")
                {
                    oUser.AppID = (int) Dictionary.AndroidAppID.E_DMS;

                }
                else if (cmbPermittedApp.Text == "All")
                {
                    oUser.AppID = (int) Dictionary.AndroidAppID.All;
                }


                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oUser.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show(@"You Have Successfully Created User", @"Create", MessageBoxButtons.OK,MessageBoxIcon.Information);
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

                oDealerUser.CustomerID = ctlCSDTechnician1.SelectedTechnician.TechnicianID;
                if (chkIsActive.Checked)
                {
                    oDealerUser.IsActive = (int) Dictionary.IsActive.Active;
                }
                else
                {
                    oDealerUser.IsActive = (int) Dictionary.IsActive.InActive;
                }
                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oDealerUser.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show(@"You Have Successfully Edited User", @"Create", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, @"Error!!!");
                }
            }
        }

        private void LoadCombo()
        {
            //Permited App
            cmbPermittedApp.Items.Clear();
            cmbPermittedApp.Items.Add("--Select--");
            foreach (int GetEnum in Enum.GetValues(typeof (Dictionary.AndroidAppID)))
            {
                cmbPermittedApp.Items.Add(Enum.GetName(typeof (Dictionary.AndroidAppID), GetEnum));
            }
            cmbPermittedApp.SelectedIndex = 0;
        }

        private void frmUserOther_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void cmbPermittedApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPermittedApp.Text == "E_Csd")
            {
                lblTechnician.Enabled = true;
                ctlCSDTechnician1.Enabled = true;
            }
            else
            {
                ctlCSDTechnician1.txtCode.Text = string.Empty;
                lblTechnician.Enabled = false;
                ctlCSDTechnician1.Enabled = false;
            }
        }
    }
}

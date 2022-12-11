using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using CJ.Class;

namespace CJ.Win
{
    public partial class frmEmail : Form
    {
        public frmEmail()
        {
            InitializeComponent();
        }


        public void ShowDialog(Email oEmail)
        {
            this.Tag = oEmail;
            
            cboSatus.Enabled = true;

            LoadCombos();
            txtEmailAddress.Text = oEmail.EmailAddress;
            txtQuota.Text = oEmail.Quota.ToString();
            cboSatus.SelectedIndex = oEmail.Status;
            cboType.SelectedIndex = oEmail.Type;
            dtpCreateDate.Value = oEmail.CreateDate.Date;
            chkWebAccess.Checked = oEmail.WebAccess;
            if (oEmail.Employee!=null) ctlEmployee1.txtCode.Text = oEmail.Employee.EmployeeCode;

            this.ShowDialog();
        }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Email";
                LoadCombos();
            }
            else 
            { 
                this.Text = "Edit Email"; 
            }
            
        }

        private void LoadCombos()
        {
            //Email Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.EmailStatus)))
            {
                cboSatus.Items.Add(Enum.GetName(typeof(Dictionary.EmailStatus), GetEnum));
            }
            cboSatus.SelectedIndex = (int)Dictionary.EmailStatus.Submitted;

            //Email Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.EmailType)))
            {
                cboType.Items.Add(Enum.GetName(typeof(Dictionary.EmailType), GetEnum));
            }
            cboType.SelectedIndex = (int)Dictionary.EmailType.Individual;
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
            Match m = emailregex.Match(txtEmailAddress.Text);

            Regex isnumber = new Regex("[0-9]");
            

            if (txtEmailAddress.Text == "")
            {
                MessageBox.Show("Please enter Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailAddress.Focus();
                return false;
            }
            else if (!m.Success)
            {
                MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailAddress.Focus();
                return false; 
            }

            if (!isnumber.IsMatch(txtQuota.Text))
            {
                MessageBox.Show("Please enter a valid Quota", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuota.Focus();
                return false;
            }

            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (validateUIInput())
            {
                //
                Save();
                //btnClear_Click(sender, e);
                this.Close();
            }
        }


        private void Save()
        {
            Employee oEmployee = ctlEmployee1.SelectedEmployee;

            if (this.Tag == null)
            {
                Email oEmail = new Email();
                //oEmail.CreateDate. = txtCode.Text;
                oEmail.EmailAddress = txtEmailAddress.Text;
                oEmail.Quota =Convert.ToDouble(txtQuota.Text); 
                oEmail.Status = cboSatus.SelectedIndex;
                oEmail.Type = cboType.SelectedIndex;
                oEmail.CreateDate = dtpCreateDate.Value.Date;
                oEmail.WebAccess = chkWebAccess.Checked;
                if(ctlEmployee1.SelectedEmployee!=null)
                    oEmail.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID; 
                else
                    oEmail.EmployeeID = null; 
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEmail.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oEmail.EmailAddress, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                Email oEmail = (Email)this.Tag;
                oEmail.EmailAddress = txtEmailAddress.Text;
                oEmail.Quota = Convert.ToDouble(txtQuota.Text);
                oEmail.Status = cboSatus.SelectedIndex;
                oEmail.Type = cboType.SelectedIndex;
                oEmail.CreateDate = dtpCreateDate.Value.Date;
                oEmail.WebAccess = chkWebAccess.Checked;
                if (ctlEmployee1.SelectedEmployee !=null)
                    oEmail.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                else
                    oEmail.EmployeeID = null;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEmail.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Email : " + oEmail.EmailAddress, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
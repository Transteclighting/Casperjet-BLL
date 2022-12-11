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
    public partial class frmCompany : Form
    {
        public frmCompany()
        {
            InitializeComponent();
        }


        public void ShowDialog(Company oCompany)
        {
            this.Tag = oCompany;
            
            txtCode.Text = oCompany.CompanyCode;
            txtName.Text = oCompany.CompanyName;

            this.ShowDialog();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            if(this.Tag==null) this.Text = "Add New Company";
            else this.Text = "Edit Company";
        }


        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code of Company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name if Company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                //btnClear_Click(sender, e);
                this.Close();
            }
        }


        private void Save()
        {
            if (this.Tag == null)
            {
                Company oCompany = new Company();
                oCompany.CompanyCode = txtCode.Text;
                oCompany.CompanyName = txtName.Text;
                oCompany.IsActive = true;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCompany.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oCompany.CompanyCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                Company oCompany = (Company)this.Tag;
                oCompany.CompanyCode = txtCode.Text;
                oCompany.CompanyName = txtName.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCompany.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Company : " + oCompany.CompanyCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
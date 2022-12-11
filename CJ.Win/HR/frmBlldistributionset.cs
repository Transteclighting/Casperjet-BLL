using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.HR;    

namespace CJ.Win.HR
{
    public partial class frmBlldistributionset : Form
    {
        BlldistributionSets _oBlldistributionSets;
        //Companys _oCompanys;
        Company oCompany;
        //int nCompanyID = 0;
        public bool _bActionSave = false;
        public frmBlldistributionset()
        {
            InitializeComponent();
        }

        private void frmBlldistributionset_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
                
            }
            //oCompany = new Company();
            //oCompany.RefreshByDisSet();
            //nCompanyID = oCompany.CompanyID;
            //txtCompany.Text = oCompany.CompanyName;

        }
        private void LoadCombos()
        {
            oCompany = new Company();
            oCompany.CompanyID = (int)Dictionary.CompanyID.BLL;
            oCompany.Refresh();
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add(oCompany.CompanyName);
            cmbCompany.SelectedIndex = 0;

        }
        public void ShowDialog(BlldistributionSet oBlldistributionSet)
        {
            this.Tag = oBlldistributionSet;
            LoadCombos();
            cmbCompany.SelectedIndex = (int)Dictionary.CompanyID.BLL;
            txtDset.Text= oBlldistributionSet.DistributionSet;
            txtDepartment.Text= oBlldistributionSet.DepartmentCode;
            txtASG.Text= oBlldistributionSet.ASG;
            //nCompanyID = oBlldistributionSet.CompanyID;
            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtDset.Text == "")
            {
                MessageBox.Show("Please enter Distribution set", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDset.Focus();
                return false;
            }

        #endregion

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                BlldistributionSet oBlldistributionSet = new BlldistributionSet();
                oBlldistributionSet.CompanyID= (int)Dictionary.CompanyID.BLL;
                oBlldistributionSet.DistributionSet= txtDset.Text;
                oBlldistributionSet.DepartmentCode = txtDepartment.Text;
                oBlldistributionSet.ASG= txtASG.Text;
                //oBlldistributionSet.CompanyID = nCompanyID;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oBlldistributionSet.AddByDistributionSet();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oBlldistributionSet.DistributionSet, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                BlldistributionSet oBlldistributionSet = (BlldistributionSet)this.Tag;
                oBlldistributionSet.CompanyID = (int)Dictionary.CompanyID.BLL;
                oBlldistributionSet.DistributionSet = txtDset.Text;
                oBlldistributionSet.DepartmentCode = txtDepartment.Text;
                oBlldistributionSet.ASG = txtASG.Text;
                //oBlldistributionSet.CompanyID = nCompanyID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oBlldistributionSet.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The BlldistributionSet : " + oBlldistributionSet.DistributionSet, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }
    }
}

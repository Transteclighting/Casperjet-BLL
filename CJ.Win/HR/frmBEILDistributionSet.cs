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


namespace CJ.Win
{
    public partial class frmBEILDistributionSet : Form
    {
        BlldistributionSets oBlldistributionSets;
        //Companys _oCompanys;
        Company _oCompany;
        MapERPHRAccpacCJAllowanceIDs _oMapERPHRAccpacCJAllowanceIDs;
        public bool _bActionSave = false;
        public frmBEILDistributionSet()
        {
            InitializeComponent();
        }

        public void ShowDialog(MapERPBEILHRDistributionSet oMapERPBEILHRDistributionSet)
        {
            this.Tag = oMapERPBEILHRDistributionSet;
            LoadCombos();
            cmbCompany.SelectedIndex = 0;
            cmbExpenseType.Text = oMapERPBEILHRDistributionSet.ExpenseType;
            cmbDistType.Text = oMapERPBEILHRDistributionSet.DistributionType;
            cmbAllowanceType.SelectedIndex =_oMapERPHRAccpacCJAllowanceIDs[oMapERPBEILHRDistributionSet.AllowanceID].AccpacAllowanceID - 1;
            txtDepartment.Text = oMapERPBEILHRDistributionSet.Department;
            txtDistCode.Text = oMapERPBEILHRDistributionSet.DistributionCode;
            txtDistSet.Text= oMapERPBEILHRDistributionSet.DistributionSet;
            txtDistDesc.Text= oMapERPBEILHRDistributionSet.DistributionDescription;
            this.ShowDialog();
        }
        private void frmBEILDistributionSet_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
        }
        private void LoadCombos()
        {
            _oCompany = new Company();
            _oCompany.CompanyID = (int)Dictionary.CompanyID.BEIL;
            _oCompany.Refresh();
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add(_oCompany.CompanyName);
            cmbCompany.SelectedIndex = 0;
            
           _oMapERPHRAccpacCJAllowanceIDs = new MapERPHRAccpacCJAllowanceIDs();
            _oMapERPHRAccpacCJAllowanceIDs.RefreshByBEILDistSet();
            cmbAllowanceType.Items.Clear();
            cmbAllowanceType.Items.Add("ALL");
            foreach (MapERPHRAccpacCJAllowanceID oMapERPHRAccpacCJAllowanceID in _oMapERPHRAccpacCJAllowanceIDs)
            {
                cmbAllowanceType.Items.Add(oMapERPHRAccpacCJAllowanceID.Description);
            }

                cmbAllowanceType.SelectedIndex = 0;


            cmbExpenseType.SelectedIndex = 0;
            cmbDistType.SelectedIndex = 0;
        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtDistDesc.Text == "")
            {
                MessageBox.Show("Please enter Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDistDesc.Focus();
                return false;
            }

            #endregion

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                MapERPBEILHRDistributionSet oMapERPBEILHRDistributionSet = new MapERPBEILHRDistributionSet();
                oMapERPBEILHRDistributionSet.CompanyID = (int)Dictionary.CompanyID.BEIL; 
                oMapERPBEILHRDistributionSet.ExpenseType = cmbExpenseType.Text;
                oMapERPBEILHRDistributionSet.DistributionType = cmbDistType.Text; 
                oMapERPBEILHRDistributionSet.AllowanceID =_oMapERPHRAccpacCJAllowanceIDs[cmbAllowanceType.SelectedIndex -1].AccpacAllowanceID;
                oMapERPBEILHRDistributionSet.Department = txtDepartment.Text;
                oMapERPBEILHRDistributionSet.DistributionSet = txtDistSet.Text;
                oMapERPBEILHRDistributionSet.DistributionCode= txtDistCode.Text;
                oMapERPBEILHRDistributionSet.DistributionDescription = txtDistDesc.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oMapERPBEILHRDistributionSet.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oMapERPBEILHRDistributionSet.ID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                MapERPBEILHRDistributionSet oMapERPBEILHRDistributionSet = (MapERPBEILHRDistributionSet)this.Tag;
                oMapERPBEILHRDistributionSet.CompanyID = (int)Dictionary.CompanyID.BEIL; 
                oMapERPBEILHRDistributionSet.ExpenseType = cmbExpenseType.Text;
                oMapERPBEILHRDistributionSet.DistributionType = cmbDistType.Text;
                oMapERPBEILHRDistributionSet.AllowanceID = _oMapERPHRAccpacCJAllowanceIDs[cmbAllowanceType.SelectedIndex -1].AccpacAllowanceID;
                oMapERPBEILHRDistributionSet.Department = txtDepartment.Text;
                oMapERPBEILHRDistributionSet.DistributionSet = txtDistSet.Text;
                oMapERPBEILHRDistributionSet.DistributionCode = txtDistCode.Text;
                oMapERPBEILHRDistributionSet.DistributionDescription = txtDistDesc.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oMapERPBEILHRDistributionSet.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The BlldistributionSet : " + oMapERPBEILHRDistributionSet.ID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

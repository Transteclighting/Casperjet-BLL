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
    public partial class frmBEILEmployeeDistSet : Form
    {
        public bool _bActionSave = false;
        private string checkDuplicateValue;

        public frmBEILEmployeeDistSet()
        {
            InitializeComponent();
        }

        private void frmBEILEmployeeDistSet_Load(object sender, EventArgs e)
        {

        }

        public void ShowDialog(MapERPBEILHREmployeeDistributionSet oMapERPBEILHREmployeeDistributionSet)
        {
            this.Tag = oMapERPBEILHREmployeeDistributionSet;

            ctlEmployee1.txtCode.Text = oMapERPBEILHREmployeeDistributionSet.EmployeeCode;
            txtEmpDeptCode.Text = oMapERPBEILHREmployeeDistributionSet.EmplDeptCode;
            txtDset.Text = oMapERPBEILHREmployeeDistributionSet.DistributionSet;
            txtDistSetDesc.Text = oMapERPBEILHREmployeeDistributionSet.DistributionSetDescription;
            this.ShowDialog();
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

        private bool UIValidation()
        {
            if (string.IsNullOrEmpty(ctlEmployee1.txtCode.Text))
            {
                MessageBox.Show("Please select an Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.txtCode.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(txtEmpDeptCode.Text))
            {
                MessageBox.Show("Please insert employee department code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmpDeptCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDset.Text))
            {
                MessageBox.Show("Please insert distribution set", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDset.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDistSetDesc.Text))
            {
                MessageBox.Show("Please insert distribution set description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDistSetDesc.Focus();
                return false;
            }


            MapERPBEILHREmployeeDistributionSet oMapERPBEILHREmployeeDistributionSet = new MapERPBEILHREmployeeDistributionSet();
            oMapERPBEILHREmployeeDistributionSet.EmployeeCode = ctlEmployee1.txtCode.Text;
            checkDuplicateValue = oMapERPBEILHREmployeeDistributionSet.CheckDuplicateData();

            if (checkDuplicateValue == "Yes" && this.Tag == null)
            {
                MessageBox.Show("Employee already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.txtCode.Focus();
                return false;
            }


            return true;

        }

        private void Save()
        {
            if (this.Tag == null)
            {
                MapERPBEILHREmployeeDistributionSet oMapERPBEILHREmployeeDistributionSet = new MapERPBEILHREmployeeDistributionSet();
                oMapERPBEILHREmployeeDistributionSet.EmployeeCode = ctlEmployee1.txtCode.Text;
                oMapERPBEILHREmployeeDistributionSet.EmplDeptCode = txtEmpDeptCode.Text;
                oMapERPBEILHREmployeeDistributionSet.DistributionSet = txtDset.Text;
                oMapERPBEILHREmployeeDistributionSet.DistributionSetDescription = txtDistSetDesc.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oMapERPBEILHREmployeeDistributionSet.BEILEmpAdd();
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
                MapERPBEILHREmployeeDistributionSet oMapERPBEILHREmployeeDistributionSet = (MapERPBEILHREmployeeDistributionSet)this.Tag;
                oMapERPBEILHREmployeeDistributionSet.EmployeeCode = ctlEmployee1.txtCode.Text;
                oMapERPBEILHREmployeeDistributionSet.EmplDeptCode = txtEmpDeptCode.Text;
                oMapERPBEILHREmployeeDistributionSet.DistributionSet = txtDset.Text;
                oMapERPBEILHREmployeeDistributionSet.DistributionSetDescription = txtDistSetDesc.Text;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oMapERPBEILHREmployeeDistributionSet.Edit();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

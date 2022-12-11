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
    public partial class frmDepartment : Form
    {
        HRDivisions _oHRDivisions;
        public bool _IsTrue = false;
        public frmDepartment()
        {
            InitializeComponent();
        }


        public void ShowDialog(Department oDepartment)
        {
            this.Tag = oDepartment;
            LoadCombos();
            txtCode.Text = oDepartment.DepartmentCode;
            txtName.Text = oDepartment.DepartmentName;
            cboDivision.SelectedIndex = _oHRDivisions.GetIndex(oDepartment.DivisionID);
            if (oDepartment.Active == 1)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            this.ShowDialog();
        }

        private void LoadCombos()
        {
            //Department
            _oHRDivisions = new HRDivisions();
            _oHRDivisions.Refresh();
            cboDivision.Items.Clear();
            foreach (HRDivision oHRDivision in _oHRDivisions)
            {
                cboDivision.Items.Add(oHRDivision.DivisionName);
            }
            cboDivision.SelectedIndex = 0;

        }
        private void frmDepartment_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
                this.Text = "Add New Department";
            }
            else this.Text = "Edit Department";
            
        }


        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code of Department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name if Department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                _IsTrue = true;
                //btnClear_Click(sender, e);
                this.Close();
            }
        }


        private void Save()
        {
            if (this.Tag == null)
            {
                Department oDepartment = new Department();
                oDepartment.DepartmentCode = txtCode.Text;
                oDepartment.DepartmentName = txtName.Text;
                if (chkIsActive.Checked == true)
                    oDepartment.Active = 1;
                else oDepartment.Active = 0;
                oDepartment.DivisionID = _oHRDivisions[cboDivision.SelectedIndex].DivisionID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDepartment.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oDepartment.DepartmentCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                Department oDepartment = (Department)this.Tag;
                oDepartment.DepartmentCode = txtCode.Text;
                oDepartment.DepartmentName = txtName.Text;
                oDepartment.DivisionID = _oHRDivisions[cboDivision.SelectedIndex].DivisionID;
                if (chkIsActive.Checked == true)
                    oDepartment.Active = 1;
                else oDepartment.Active = 0;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDepartment.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Department : " + oDepartment.DepartmentCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
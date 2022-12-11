using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.HR
{
    public partial class frmHRSection : Form
    {
        Departments _oDepartments;
        public bool _IsTrue = false;
        int nSectionID = 0;
        public frmHRSection()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(Employee oSection)
        {
            this.Tag = oSection;
            LoadCombos();
            this.Text = "Edit Sub Department";
            nSectionID = oSection.SectionID;
            txtSection.Text = oSection.SectionName;
            cmbDepartmentName.SelectedIndex = _oDepartments.GetIndex(oSection.DepartmentID) + 1;
            if (oSection.IsActive == 1)
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
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            //Department
            _oDepartments = new Departments();
            _oDepartments.GetAllDepartment();
            cmbDepartmentName.Items.Clear();
            cmbDepartmentName.Items.Add("<ALL>");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartmentName.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartmentName.SelectedIndex = 0;


        }


        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtSection.Text == "")
            {
                MessageBox.Show("Please Enter Section Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSection.Focus();
                return false;
            }

            
            if (cmbDepartmentName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Department.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartmentName.Focus();
                return false;
            }


            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Employee oSection = new Employee();
                oSection.SectionName = txtSection.Text;
                oSection.DepartmentID = _oDepartments[cmbDepartmentName.SelectedIndex - 1].DepartmentID;
                if (chkIsActive.Checked == true)
                    oSection.IsActive = (int)Dictionary.IsActive.Active;
                else oSection.IsActive = (int)Dictionary.IsActive.InActive; ;

                try
                {

                    DBController.Instance.BeginNewTransaction();
                    if (this.Tag == null)
                    {
                        oSection.AddSection();
                        _IsTrue = true;
                    }
                    else
                    {
                        oSection.SectionID = nSectionID;
                        oSection.EditSection();
                        _IsTrue = true;
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oSection.SectionID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
                this.Close();
            }
        }

        private void frmHRSection_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Sub Department";
                LoadCombos();
            }
        }
    }
}
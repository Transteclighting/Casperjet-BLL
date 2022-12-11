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
    public partial class frmProject : Form
    {
        Project _oProject;
        int nProjectID = 0;
        Departments _oDepartments;
        public bool _IsLoadData = false;

        public frmProject()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Department
            _oDepartments = new Departments();
            _oDepartments.RefreshDepartment();
            cmbConcernDepartment.Items.Clear();
            foreach (Department oDepartment in _oDepartments)
            {
                cmbConcernDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbConcernDepartment.SelectedIndex = 0;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(Project oProject)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oProject;
            LoadCombos();
            nProjectID = oProject.ProjectID;
            txtProjectNo.Text = oProject.ProjectCode;
            txtProjectName.Text = oProject.ProjectName;
            txtRemarks.Text = oProject.Remarks;
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = oProject.ProjectManager;
            oEmployee.Refresh();
            ctlEmployee1.txtCode.Text = oEmployee.EmployeeCode;
            cmbConcernDepartment.SelectedIndex = _oDepartments.GetIndex(oProject.Department);

            this.ShowDialog();
        }
        private bool UIValidation()
        {
            #region ValidInput

            if (txtProjectName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Project Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProjectName.Focus();
                return false;
            }
            if (ctlEmployee1.txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Project Manager Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.txtCode.Focus();
                return false;
            }
            #endregion
            return true;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oProject = new Project();
                        _oProject.ProjectID = nProjectID;
                        _oProject.ProjectCode = txtProjectNo.Text;
                        _oProject.ProjectName = txtProjectName.Text;
                        _oProject.ProjectManager = ctlEmployee1.SelectedEmployee.EmployeeID;
                        _oProject.Remarks = txtRemarks.Text;
                        _oProject.Department = _oDepartments[cmbConcernDepartment.SelectedIndex].DepartmentID;
                        _oProject.Edit();
                        _IsLoadData = true;

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Update. Project No: " + _oProject.ProjectCode.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {


                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oProject = new Project();
                        _oProject.ProjectCode = txtProjectNo.Text;
                        _oProject.ProjectName = txtProjectName.Text;
                        _oProject.ProjectManager = ctlEmployee1.SelectedEmployee.EmployeeID;
                        _oProject.Remarks = txtRemarks.Text;
                        _oProject.CreateDate = DateTime.Now.Date;
                        _oProject.CreateUserID = Utility.UserId;
                        _oProject.Department = _oDepartments[cmbConcernDepartment.SelectedIndex].DepartmentID;
                        _oProject.Add();
                        _IsLoadData = true;

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add New Project. Project No: " + _oProject.ProjectCode.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();


                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void frmProject_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Project";
                DBController.Instance.OpenNewConnection();
                LoadCombos();
                Project oProjectCode = new Project();
                oProjectCode.GetMaxProjectNo();
                txtProjectNo.Text = oProjectCode.ProjectCode;
            }
            else
            {
                this.Text = "Edit New Project";
            }
        }
    }
}
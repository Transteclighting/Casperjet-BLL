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
    public partial class frmProjectDetail : Form
    {
        Companys _oCompanys;
        Departments _oDepartments;
        ProjectDetail _oProjectList;
        ProjectDetail oProjectDetail;
        int nProjectID = 0;
        int nSubProjectID = 0;
        public bool _IsLoadData = false;
        public frmProjectDetail()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            ///ProjectList
            _oProjectList = new ProjectDetail();
            _oProjectList.GetAllProject();
            cmbProjectName.Items.Clear();
            foreach (Project oProject in _oProjectList)
            {
                cmbProjectName.Items.Add(oProject.ProjectName);
            }
            cmbProjectName.SelectedIndex = 0;

            //Company
            _oCompanys = new Companys();
            _oCompanys.GetCompanyALL();
            cmbCompany.Items.Clear();
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;


            //Department
            _oDepartments = new Departments();
            _oDepartments.RefreshDepartment();
            cmbConcernDepartment.Items.Clear();
            foreach (Department oDepartment in _oDepartments)
            {
                cmbConcernDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbConcernDepartment.SelectedIndex = 0;

            //Project Type 
            cmbProjectType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ITProjectType)))
            {
                cmbProjectType.Items.Add(Enum.GetName(typeof(Dictionary.ITProjectType), GetEnum));
            }
            cmbProjectType.SelectedIndex = 0;

            //Project Size 
            cmbProjectSize.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProjectSize)))
            {
                cmbProjectSize.Items.Add(Enum.GetName(typeof(Dictionary.ProjectSize), GetEnum));
            }
            cmbProjectSize.SelectedIndex = 0;

            //ProjectResourceType
            cmbResourceType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProjectResourceType)))
            {
                cmbResourceType.Items.Add(Enum.GetName(typeof(Dictionary.ProjectResourceType), GetEnum));
            }
            cmbResourceType.SelectedIndex = 0;


            //Priority
            cmbPriority.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProjectPriority)))
            {
                cmbPriority.Items.Add(Enum.GetName(typeof(Dictionary.ProjectPriority), GetEnum));
            }
            cmbPriority.SelectedIndex = 0;

            //Business unit
            cmbBusinessUnit.Items.Clear();
            //cmbBusinessUnit.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.BusinessUnitSubProject)))
            {
                cmbBusinessUnit.Items.Add(Enum.GetName(typeof(Dictionary.BusinessUnitSubProject), GetEnum));
            }
            cmbBusinessUnit.SelectedIndex = 0;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(ProjectDetail oProjectDetail)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oProjectDetail;
            LoadCombos();
            nProjectID = oProjectDetail.ProjectID;
            nSubProjectID = oProjectDetail.SubProjectID;
            cmbProjectName.SelectedIndex = _oProjectList.GetIndex(nProjectID);
            txtSubProjectName.Text = oProjectDetail.SubProjectName;
            cmbProjectType.SelectedIndex = oProjectDetail.ProjectType;
            cmbBusinessUnit.SelectedIndex = oProjectDetail.Businessunit-1;
            if (oProjectDetail.Priority=="High")
            {
                cmbPriority.SelectedIndex = 0;
            }
            else if (oProjectDetail.Priority == "Medium")
            {
                cmbPriority.SelectedIndex = 1;
            }
            else // (oProjectDetail.Priority == "Low")
            {
                cmbPriority.SelectedIndex = 2;
            }
            cmbConcernDepartment.SelectedIndex = _oDepartments.GetIndex(oProjectDetail.ConcernDepartment);
            cmbProjectSize.SelectedIndex = oProjectDetail.ProjectSize;
            cmbResourceType.SelectedIndex = oProjectDetail.ResourceType;
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = oProjectDetail.KeyPerson;
            oEmployee.Refresh();
            ctlEmployee1.txtCode.Text = oEmployee.EmployeeCode;
            cmbCompany.SelectedIndex = _oCompanys.GetIndex(oProjectDetail.Company);
            txtRemarks.Text = oProjectDetail.Remarks;
            this.ShowDialog();
        }
        private bool UIValidation()
        {
            #region ValidInput

            if (txtSubProjectName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Sub Project Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubProjectName.Focus();
                return false;
            }
            if (ctlEmployee1.txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Key Person Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                        oProjectDetail = new ProjectDetail();
                        oProjectDetail.ProjectID = _oProjectList[cmbProjectName.SelectedIndex].ProjectID;
                        oProjectDetail.SubProjectID = nSubProjectID;
                        oProjectDetail.SubProjectName = txtSubProjectName.Text;
                        oProjectDetail.ProjectType = cmbProjectType.SelectedIndex;
                        oProjectDetail.ConcernDepartment = _oDepartments[cmbConcernDepartment.SelectedIndex].DepartmentID;
                        oProjectDetail.ProjectSize = cmbProjectSize.SelectedIndex;
                        oProjectDetail.ResourceType = cmbResourceType.SelectedIndex;
                        oProjectDetail.KeyPerson = ctlEmployee1.SelectedEmployee.EmployeeID;
                        oProjectDetail.Company = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
                        oProjectDetail.Businessunit = cmbBusinessUnit.SelectedIndex+1;
                        oProjectDetail.Remarks = txtRemarks.Text;
                        oProjectDetail.Priority = cmbPriority.Text;
                        oProjectDetail.Edit();
                        _IsLoadData = true;

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Update. Sub-Project Name: " + oProjectDetail.SubProjectName.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        oProjectDetail = new ProjectDetail();
                        oProjectDetail.ProjectID = _oProjectList[cmbProjectName.SelectedIndex].ProjectID;
                        oProjectDetail.SubProjectName = txtSubProjectName.Text;
                        oProjectDetail.ProjectType = cmbProjectType.SelectedIndex;
                        oProjectDetail.ConcernDepartment = _oDepartments[cmbConcernDepartment.SelectedIndex].DepartmentID;
                        oProjectDetail.ProjectSize = cmbProjectSize.SelectedIndex;
                        oProjectDetail.ResourceType = cmbResourceType.SelectedIndex;
                        oProjectDetail.KeyPerson = ctlEmployee1.SelectedEmployee.EmployeeID;
                        oProjectDetail.Company = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
                        oProjectDetail.Businessunit = cmbBusinessUnit.SelectedIndex+1;
                        oProjectDetail.Remarks = txtRemarks.Text;
                        oProjectDetail.Priority = cmbPriority.Text;
                        oProjectDetail.Add();
                        _IsLoadData = true;

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add New Sub-Project. Sub-Project No: " + oProjectDetail.SubProjectName.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void frmProjectDetail_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Sub-Project";
                DBController.Instance.OpenNewConnection();
                LoadCombos();
            }
            else
            {
                this.Text = "Edit New Sub-Project";
            }
        }
    }
}
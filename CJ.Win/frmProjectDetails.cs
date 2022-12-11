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
    public partial class frmProjectDetails : Form
    {
        ProjectDetails _oProjectDetails;
        Departments _oDepartments;
        public frmProjectDetails()
        {
            InitializeComponent();
        }

        private void btnAddNewProject_Click(object sender, EventArgs e)
        {
            frmProjectDetail oForm = new frmProjectDetail();
            oForm.ShowDialog();
            if (oForm._IsLoadData == true)
            {
                DataLoadControl();
            }
        }
        private void SetListViewRowColour()
        {
            if (lvwProjectList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwProjectList.Items)
                {
                    if (oItem.SubItems[14].Text == "Create")
                    {
                        oItem.BackColor = Color.PeachPuff;
                    }
                    else if (oItem.SubItems[14].Text == "Planned")
                    {
                        oItem.BackColor = Color.LightGoldenrodYellow;
                    }
                    else if (oItem.SubItems[14].Text == "Working")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                    else if (oItem.SubItems[14].Text == "Done")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[14].Text == "Pending")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }

                    else
                    {
                        oItem.BackColor = Color.LightGray;

                    }

                }
            }
        }
        private void DataLoadControl()
        {
            _oProjectDetails = new ProjectDetails();
            lvwProjectList.Items.Clear();

            int nDepartment = 0;
            if (cmbConcernDepartment.SelectedIndex == 0)
            {
                nDepartment = -1;
            }
            else
            {
                nDepartment = _oDepartments[cmbConcernDepartment.SelectedIndex - 1].DepartmentID;
            }
            DBController.Instance.OpenNewConnection();
            _oProjectDetails.GetSubProjectList(nDepartment, txtProjectNo.Text.Trim(), txtProjectName.Text.Trim(), txtSubProject.Text.Trim());
            DBController.Instance.CloseConnection();

            foreach (ProjectDetail oProject in _oProjectDetails)
            {
                ListViewItem oItem = lvwProjectList.Items.Add(oProject.ProjectCode.ToString());
                oItem.SubItems.Add(oProject.ProjectName.ToString());
                oItem.SubItems.Add(oProject.ProjectManagerName.ToString());
                oItem.SubItems.Add(oProject.SubProjectName.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ITProjectType), oProject.ProjectType));
                oItem.SubItems.Add(oProject.Priority.ToString());
                oItem.SubItems.Add(oProject.ConcernDepartmentName.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ProjectSize), oProject.ProjectSize));
                if (oProject.StartDate != "")
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oProject.StartDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    oItem.SubItems.Add("");
                }
                if (oProject.EndDate != "")
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oProject.EndDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    oItem.SubItems.Add("");
                }
                oItem.SubItems.Add(oProject.KeyPersonName.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ProjectResourceType), oProject.ResourceType));
                oItem.SubItems.Add(oProject.CompanyName.ToString());
                oItem.SubItems.Add(Convert.ToDouble(Math.Round(oProject.WorkPercent, 1)).ToString() + '%');
                oItem.SubItems.Add(oProject.Remarks.ToString());

                oItem.Tag = oProject;
            }
            this.Text = "Sub-Project List[" + _oProjectDetails.Count + "]";
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Department
            _oDepartments = new Departments();
            _oDepartments.RefreshDepartment();
            cmbConcernDepartment.Items.Clear();
            cmbConcernDepartment.Items.Add("<All>");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbConcernDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbConcernDepartment.SelectedIndex = 0;


        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void frmProjectDetails_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }
        private void AddTask()
        {
            if (lvwProjectList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProjectDetail oProjectDetail = (ProjectDetail)lvwProjectList.SelectedItems[0].Tag;
            frmProjectTask oForm = new frmProjectTask();
            oForm.ShowDialog(oProjectDetail);
            if (oForm._IsTrue == true)
            {
                DataLoadControl();
            }

        }
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProjectList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProjectDetail oProjectDetail = (ProjectDetail)lvwProjectList.SelectedItems[0].Tag;
            frmProjectDetail oForm = new frmProjectDetail();
            oForm.ShowDialog(oProjectDetail);
            if (oForm._IsLoadData == true)
            {
                DataLoadControl();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
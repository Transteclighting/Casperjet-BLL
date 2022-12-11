using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmProjects : Form
    {
        ProjectDetails _oProjectDetails;
        Departments _oDepartments;
        public frmProjects()
        {
            InitializeComponent();
        }

        private void btnAddNewProject_Click(object sender, EventArgs e)
        {
            frmProject oForm = new frmProject();
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
                    if (oItem.SubItems[4].Text == "Create")
                    {
                        oItem.BackColor = Color.PeachPuff;
                    }
                    else if (oItem.SubItems[4].Text == "Planned")
                    {
                        oItem.BackColor = Color.LightGoldenrodYellow;
                    }
                    else if (oItem.SubItems[4].Text == "Working")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                    else if (oItem.SubItems[4].Text == "Done")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[4].Text == "Pending")
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

            int nDepartent = 0;
            if (cmbConcernDepartment.SelectedIndex == 0)
            {
                nDepartent = -1;
            }
            else
            {
                nDepartent = _oDepartments[cmbConcernDepartment.SelectedIndex - 1].DepartmentID;
            }

            DBController.Instance.OpenNewConnection();
            _oProjectDetails.GetProjectList(nDepartent, txtProjectNo.Text.Trim(), txtProjectName.Text.Trim());
            DBController.Instance.CloseConnection();

            foreach (Project oProject in _oProjectDetails)
            {
                ListViewItem oItem = lvwProjectList.Items.Add(oProject.ProjectCode.ToString());
                oItem.SubItems.Add(oProject.ProjectName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oProject.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oProject.ProjectManagerName.ToString());
                oItem.SubItems.Add(oProject.DepartmentName.ToString());
                ///oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ProjectStatus), oProject.Status));
                oItem.SubItems.Add(oProject.Remarks.ToString());

                oItem.Tag = oProject;
            }
            this.Text = "Project List[" + _oProjectDetails.Count + "]";
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
        private void frmProjects_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProjectList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Project oProject = (Project)lvwProjectList.SelectedItems[0].Tag;
            frmProject oForm = new frmProject();
            oForm.ShowDialog(oProject);
            if (oForm._IsLoadData == true)
            {
                DataLoadControl();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            

        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            //FrmProjectStatusFilter _oFrom = new FrmProjectStatusFilter();
            //_oFrom.ShowDialog();


            DBController.Instance.OpenNewConnection();
            ProjectDetail oProject = new ProjectDetail();
            oProject.RefreshTaskDetailRpt();
            if (oProject.Count > 0)
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptTaskDetail));
                oReport.SetDataSource(oProject);

                frmPrintPreview oFrom = new frmPrintPreview();
                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;
            }
            DBController.Instance.CloseConnection();
        }
    }
}
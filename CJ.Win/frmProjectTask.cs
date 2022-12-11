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
    public partial class frmProjectTask : Form
    {
        public bool _IsTrue = false;
        int nProjectID = 0;
        int nSubProjectID = 0;
        string sProjectName = "";
        string sSubProjectName = "";
        ProjectDetails _oProjectDetails;
        ProjectDetail _oProjectDetail;

        public frmProjectTask()
        {
            InitializeComponent();
        }

        public void ShowDialog(ProjectDetail oProjectDetail)
        {
            this.Text = "Project Task";

            nProjectID = oProjectDetail.ProjectID;
            nSubProjectID = oProjectDetail.SubProjectID;
            sProjectName = "[" + oProjectDetail.ProjectCode + "]" + oProjectDetail.ProjectName;
            sSubProjectName = oProjectDetail.SubProjectName;
            lblProjectName.Text = "[" + oProjectDetail.ProjectCode + "]" + oProjectDetail.ProjectName;
            lblSubProjectName.Text = oProjectDetail.SubProjectName;
            lblProjectType.Text = Enum.GetName(typeof(Dictionary.ITProjectType), oProjectDetail.ProjectType);
            lblProjectSize.Text = Enum.GetName(typeof(Dictionary.ProjectSize), oProjectDetail.ProjectSize);
            lblPriority.Text = oProjectDetail.Priority;
            lblConcernDepartment.Text = oProjectDetail.ConcernDepartmentName;
            lblKeyPerson.Text = oProjectDetail.KeyPersonName;
            lblResourceType.Text = Enum.GetName(typeof(Dictionary.ProjectResourceType), oProjectDetail.ResourceType);
            lblCompany.Text = oProjectDetail.CompanyName;
            lblWorkPercentage.Text = Convert.ToDouble(Math.Round(oProjectDetail.WorkPercent, 1)).ToString() + "%";
            if (oProjectDetail.StartDate != "")
            {
                lblStartDate.Text = Convert.ToDateTime(oProjectDetail.StartDate).ToString("dd-MMM-yyyy");
            }
            if (oProjectDetail.EndDate != "")
            {
                lblEndDate.Text = Convert.ToDateTime(oProjectDetail.EndDate).ToString("dd-MMM-yyyy");
            }
            lblRemarks.Text = oProjectDetail.Remarks;
            lblProjectName.Text = oProjectDetail.ProjectName;
            lblProjectName.Text = oProjectDetail.ProjectName;
            lblProjectName.Text = oProjectDetail.ProjectName;
            DataLoadControl();
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataLoadControl()
        {
            _oProjectDetails = new ProjectDetails();
            lvwProjectTask.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oProjectDetails.GetProjectTask(nProjectID, nSubProjectID);
            DBController.Instance.CloseConnection();
            foreach (ProjectDetail oProject in _oProjectDetails)
            {
                ListViewItem oItem = lvwProjectTask.Items.Add(oProject.Description.ToString());
                oItem.SubItems.Add(oProject.AssignPersonName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oProject.StartDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDateTime(oProject.EndDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oProject.Remarks.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ProjectStatus), oProject.Status));
                oItem.SubItems.Add(Convert.ToDouble(Math.Round(oProject.WorkPercent, 1)).ToString() + '%');

                oItem.Tag = oProject;
            }
            SetListViewRowColour();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProjectTaskDetail oForm = new frmProjectTaskDetail(1);
            oForm.ShowDialog(nProjectID, nSubProjectID, sProjectName, sSubProjectName, null);
            if (oForm._IsLoadData == true)
            {
                DataLoadControl();
            }
            _IsTrue = oForm._IsLoadData;
        }

        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            ProjectDetail oProjectDetail = (ProjectDetail)lvwProjectTask.SelectedItems[0].Tag;
            frmProjectTaskDetail oForm = new frmProjectTaskDetail(2);
            oForm.ShowDialog(nProjectID, nSubProjectID, sProjectName, sSubProjectName, oProjectDetail);
            if (oForm._IsLoadData == true)
            {
                DataLoadControl();
            }
            _IsTrue = oForm._IsLoadData;
        }

        private void SetListViewRowColour()
        {
            if (lvwProjectTask.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwProjectTask.Items)
                {
                    if (oItem.SubItems[5].Text == "Create")
                    {
                        oItem.BackColor = Color.PeachPuff;
                    }
                    else if (oItem.SubItems[5].Text == "Planned")
                    {
                        oItem.BackColor = Color.LightGoldenrodYellow;
                    }
                    else if (oItem.SubItems[5].Text == "Working")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                    else if (oItem.SubItems[5].Text == "Done")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[5].Text == "Pending")
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

    }
}

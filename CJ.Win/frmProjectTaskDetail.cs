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
    public partial class frmProjectTaskDetail : Form
    {
        int _ProjectID = 0;
        int _SubProjectID = 0;
        ProjectDetails _oProjectDetails;
        ProjectDetail _oProjectTask;
        public bool _IsLoadData = false;
        int _nType = 0;
        int nTaskID = 0;
        int _Minutes = 0;
        double _WorkPercentage = 0;
        public frmProjectTaskDetail(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }
        private void LoadCombos()
        {
            //Status 
            cmbStatus.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProjectStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ProjectStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }

        private void GetTotalHoure()
        {

            //TimeSpan _TotalTime = dtEndDate.Value.TimeOfDay - dtStartDate.Value.TimeOfDay;

            //if (_TotalTime.Hours < 0)
            //{

            //    TimeSpan time1 = TimeSpan.FromHours(24); // my attempt to add 24 hours
            //    _TotalTime = _TotalTime.Add(time1);
            //    lblTotalHoure.Text = _TotalTime.ToString();
            //}
            //else
            //{
            //    lblTotalHoure.Text = _TotalTime.ToString();
            //}

            //int _Minutes = _TotalTime.Hours * 60 + _TotalTime.Minutes;
        }

        public void ShowDialog(int nProjectID, int nSubProjectID, string sProjectName, string sSubProjectName, ProjectDetail oProjectDetail)
        {
            this.Text = "Add Task";
            DBController.Instance.OpenNewConnection();
            
            dtStartDate.Value = DateTime.Now.Date;
            dtEndDate.Value = DateTime.Now.Date;

            lblProjectName.Text = sProjectName;
            lblSubProjectName.Text = sSubProjectName;
            _ProjectID = nProjectID;
            _SubProjectID = nSubProjectID;
            LoadCombos();

            if (_nType != 1)
            {
                this.Text = "Edit Task";
                nTaskID = oProjectDetail.TaskID;
                txtDescription.Text = oProjectDetail.Description;
                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = oProjectDetail.AssignPerson;
                oEmployee.Refresh();
                dtStartDate.Value = Convert.ToDateTime(oProjectDetail.StartDate).Date;
                dtEndDate.Value = Convert.ToDateTime(oProjectDetail.EndDate).Date;
                ctlEmployee1.txtCode.Text = oEmployee.EmployeeCode;
                cmbStatus.SelectedIndex = oProjectDetail.Status;
                txtWorkPercent.Text = oProjectDetail.WorkPercent.ToString();
                txtRemarks.Text = oProjectDetail.Remarks;
                _WorkPercentage = oProjectDetail.WorkPercent;
            }
            this.ShowDialog();
        }
        private bool UIValidation()
        {
            #region ValidInput
            if (dtStartDate.Value.Date > dtEndDate.Value.Date)
            {
                MessageBox.Show("End date must be > start date ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtEndDate.Focus();
                return false;
            }
            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Task Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }
            if (ctlEmployee1.txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please select assign person", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.txtCode.Focus();
                return false;
            }
            if (txtWorkPercent.Text.Trim() == "")
            {
                MessageBox.Show("Please enter work percentage", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWorkPercent.Focus();
                return false;
            }
            double _nWorkPercent = 0;
            try
            {
                _nWorkPercent = Convert.ToDouble(txtWorkPercent.Text);
            }
            catch
            {
                MessageBox.Show("Please enter valid work percentage", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWorkPercent.Focus();
                return false;
            }
            if (_nWorkPercent > 100)
            {
                MessageBox.Show("Work percentage must be less then 100", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWorkPercent.Focus();
                return false;
            }
            #endregion
            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oProjectTask = new ProjectDetail();
                    _oProjectTask.ProjectID = _ProjectID;
                    _oProjectTask.SubProjectID = _SubProjectID;
                    _oProjectTask.Description = txtDescription.Text;
                    _oProjectTask.AssignPerson = ctlEmployee1.SelectedEmployee.EmployeeID;
                    _oProjectTask.Remarks = txtRemarks.Text;
                    _oProjectTask.Status = cmbStatus.SelectedIndex;
                    _oProjectTask.StartDate = dtStartDate.Value;
                    _oProjectTask.EndDate = dtEndDate.Value;
                    _oProjectTask.WorkPercent = Convert.ToDouble(txtWorkPercent.Text);
                    if (_nType == 1)
                    {
                        _oProjectTask.AddTask();
                    }
                    else
                    {
                        _oProjectTask.EditTask(nTaskID);
                    }
                    ProjectDetail oHistory = new ProjectDetail();
                    oHistory.ProjectID = _ProjectID;
                    oHistory.SubProjectID = _SubProjectID;
                    oHistory.TaskID = _oProjectTask.TaskID;
                    oHistory.StartDate = dtStartDate.Value.Date;
                    oHistory.EndDate = dtEndDate.Value.Date;
                    oHistory.WorkPercent = Convert.ToDouble(txtWorkPercent.Text);
                    if (_nType == 1)
                    {
                        oHistory.ProgressPercent = Convert.ToDouble(txtWorkPercent.Text);
                    }
                    else
                    {
                        oHistory.ProgressPercent = Convert.ToDouble(txtWorkPercent.Text) - _WorkPercentage;
                    
                    }
                    oHistory.Status = cmbStatus.SelectedIndex;
                    oHistory.Remarks = txtRemarks.Text;
                    oHistory.AddHistory();
                    _IsLoadData = true;
                    DBController.Instance.CommitTran();
                    if (_nType == 1)
                    {
                        MessageBox.Show("Successfully Add.Task Description: " + _oProjectTask.Description.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Successfully Update.Task Description: " + _oProjectTask.Description.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
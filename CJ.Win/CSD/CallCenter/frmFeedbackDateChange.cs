using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.CallCenter
{
    public partial class frmFeedbackDateChange : Form
    {
        CSDJob oCSDJob;
        JobFeedbackDates _oJobFeedbackDates;

        public frmFeedbackDateChange()
        {
            InitializeComponent();
        }

        private void frmFeedbackDateChange_Load(object sender, EventArgs e)
        {
            if (ctlCSDJob1.txtDescription.Text != string.Empty)
            {
                DataLoadControl();
            }
        }

        public void ShowDialog(string sJobNo)
        {
            DBController.Instance.OpenNewConnection();
            if (sJobNo != "")
            {
                ctlCSDJob1.txtCode.Text = sJobNo;
                ctlCSDJob1.Enabled = false;
            }
            this.ShowDialog();
        }

        private void ctlCSDJob1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCSDJob1.txtDescription.Text != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;
                oCSDJob = new CSDJob();
                oCSDJob.JobID = ctlCSDJob1.SelectedJob.JobID;
                oCSDJob.Refresh();
                txtCustomerName.Text = oCSDJob.CustomerName;
                this.Cursor = Cursors.Default;
            }
        }

        private bool ValidateUIControl()
        {
            if (txtRemarks.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Convesation Text.","Conversation Text",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUIControl())
            {
                AddCSDFeedbackDateHistory();
                this.Close();
            }            
        }

        private void AddCSDFeedbackDateHistory()
        {
            try
            {
                DBController.Instance.OpenNewConnection();
                DBController.Instance.BeginNewTransaction();

                JobFeedbackDate _oJobFeedbackDate = new JobFeedbackDate();

                _oJobFeedbackDate.JobID = oCSDJob.JobID;
                _oJobFeedbackDate.StatusID = oCSDJob.Status;
                _oJobFeedbackDate.TechnicianID = oCSDJob.AssignTo;
                _oJobFeedbackDate.FeedbackDate = Convert.ToDateTime(dtFeedbackDate.Value.Date);
                _oJobFeedbackDate.VisitingTimeFrom = null;
                _oJobFeedbackDate.VisitingTimeTo = null;
                _oJobFeedbackDate.CreateUserID = Utility.UserId;
                _oJobFeedbackDate.CreateDate = DateTime.Now;
                _oJobFeedbackDate.Remarks = txtRemarks.Text.Trim();

                _oJobFeedbackDate.Add();

                oCSDJob.JobID = oCSDJob.JobID;
                oCSDJob.LastFeedBackDate = _oJobFeedbackDate.FeedbackDate;
                oCSDJob.UpdateLastFeedbackdate();

                //oCSDJob.update

                DBController.Instance.CommitTran();

                DBController.Instance.BeginNewTransaction();
                SMSMaker _oSMSMaker;
                oCSDJob.GetSubStatus(oCSDJob.JobID);
                if (oCSDJob.Status == (int)Dictionary.JobStatus.Pending)
                {
                    if (oCSDJob.SubStatus == 1 || oCSDJob.SubStatus == 2)//Pending for Local & Foreign Parts
                    {
                        _oSMSMaker = new SMSMaker();
                        _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.WalkIn_HCall_EDD_ExtentionForParts_Customer_Source, oCSDJob.JobID);
                    }
                    else
                    {
                        _oSMSMaker = new SMSMaker();
                        _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.WalkIn_HCall_EDD_Extention_Customer_Source, oCSDJob.JobID);
                    }
                }
                else if (oCSDJob.Status == (int)Dictionary.JobStatus.Replace)
                {
                    _oSMSMaker = new SMSMaker();
                    _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.WalkIn_Replace_EDDExtention_Customer_Source, oCSDJob.JobID);
                }
                else
                { 
                    _oSMSMaker = new SMSMaker();
                    _oSMSMaker.CustomerSMS((int)Dictionary.CSDSMSModel.WalkIn_HCall_EDD_Extention_Customer_Source, oCSDJob.JobID);
                }

                DBController.Instance.CommitTran();

                MessageBox.Show("Data save Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error saving data...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            _oJobFeedbackDates = new JobFeedbackDates();
            _oJobFeedbackDates.RefreshByJobID(oCSDJob.JobID);
            this.Text = "Job feedback Date | Total: " + "[" + _oJobFeedbackDates.Count + "]";
            lvwFeedbackList.Items.Clear();
            foreach (JobFeedbackDate oJobFeedbackDate in _oJobFeedbackDates)
            {
                ListViewItem oItem = lvwFeedbackList.Items.Add(oJobFeedbackDate.FeedbackDate.ToShortDateString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.JobStatus), oJobFeedbackDate.StatusID));
                oItem.SubItems.Add(oJobFeedbackDate.SubStatusName);
                oItem.SubItems.Add(oJobFeedbackDate.TechnicianName);
                oItem.SubItems.Add(oJobFeedbackDate.Remarks);
                oItem.SubItems.Add(oJobFeedbackDate.UserName);
                oItem.SubItems.Add(oJobFeedbackDate.CreateDate.ToShortDateString());
                oItem.Tag = oJobFeedbackDate;
            }


        }
    }
}
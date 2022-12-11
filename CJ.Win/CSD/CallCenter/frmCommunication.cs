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
    public partial class frmCommunication : Form
    {
        int _nJobID = 0;
        Communication _oCommunication;
        Communications _oCommunications;
        ProactiveCall _oProactiveCall;
        CSDJob oCSDJob;
        CSDSMSHistorys _oCSDSMSHistorys;
        JobHistory _oJobHistory;
        int _nProactiveCallID;
        public frmCommunication()
        {
            InitializeComponent();
        }
        public void ShowDialog(int nJobID, int nProactiveCallID)
        {
            DBController.Instance.OpenNewConnection();
            _nProactiveCallID = nProactiveCallID;
            _nJobID = nJobID;
            oCSDJob = new CSDJob();
            oCSDJob.JobID = _nJobID;
            oCSDJob.Refresh();

            if (oCSDJob.Status == (int)Dictionary.JobStatus.Estimated || oCSDJob.Status == (int)Dictionary.JobStatus.EstimateApproved || oCSDJob.Status == (int)Dictionary.JobStatus.EstimateNotApproved)
            {
                gbEstimate.Enabled = true;
                rdoApproved.Checked = true;
            }
            else
            {
                gbEstimate.Enabled = false;
            }

            this.ShowDialog();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtRemarks.Text == "")
            {
                MessageBox.Show("Please Input Communication Text", "Blank", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtRemarks.Focus();
                return false;
            }
            if (chkRemindMeLater.Checked == true)
            {
                if (DateTime.Now.Date >= dtNxtFeedbackDate.Value.Date)
                {
                    MessageBox.Show("Next follow-up date must be greater than Today", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    dtNxtFeedbackDate.Focus();
                    return false;
                }
            }

            #endregion

            return true;
        }
        private void AddJobHistory(int nJobStatus)
        {
            _oJobHistory = new JobHistory();
            _oJobHistory.JobID = _oCommunication.JobID;
            _oJobHistory.CreateUserID = _oCommunication.CreateUserID;
            _oJobHistory.CreateDate = _oCommunication.CreateDate;
            _oJobHistory.StatusID = nJobStatus;
            _oJobHistory.Remarks = txtRemarks.Text.Trim();
            _oJobHistory.ServiceType =0;
            _oJobHistory.Add(null);
        }
        private void Save()
        {
            _oCommunication = new Communication();
            _oCommunication.JobID = _nJobID;
            _oCommunication.CreateUserID = Utility.UserId;
            _oCommunication.CreateDate = DateTime.Now;
            _oCommunication.Remarks = txtRemarks.Text;
            if (_nProactiveCallID > 0)
            {
                _oCommunication.CallCategory = (int)Dictionary.CallCategory.OutBoundCall;
            }
            else
            {
                _oCommunication.CallCategory = (int)Dictionary.CallCategory.InBoundCall;
            }
            _oCommunication.CallType = (int)Dictionary.CallType.GeneralCall;
            if (chkNoResponse.Checked) 
            {
                _oCommunication.ResponseType = (int)Dictionary.ResponseType.No_Response;
            }
            else
            {
                _oCommunication.ResponseType = (int)Dictionary.ResponseType.Response;
            }
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oCommunication.Add();
                if (_nProactiveCallID > 0)
                {
                    _oProactiveCall = new ProactiveCall();
                    _oProactiveCall.ID = _nProactiveCallID;
                    _oProactiveCall.LastCommunication = txtRemarks.Text.Trim();
                    _oProactiveCall.UpdateLastCommunication();

                    if (chkRemindMeLater.Checked == true)
                    {
                        _oProactiveCall.NextFollowUpDate = dtNxtFeedbackDate.Value.Date;
                        _oProactiveCall.UpdateNextFollowupDate();
                    }
                    if (chkConversationComplete.Checked == true)
                    {
                        _oProactiveCall.IsBanForever = (int)Dictionary.YesOrNoStatus.YES;
                        _oProactiveCall.UpdateBanForever();
                    }

                }
                if (chkNoResponse.Checked == false)
                {
                    if (oCSDJob.Status == (int)Dictionary.JobStatus.Estimated)
                    {
                        int nStatus = 0;
                        if (rdoApproved.Checked == true)
                        {
                            nStatus = (int)Dictionary.JobStatus.EstimateApproved;
                        }
                        else
                        {
                            nStatus = (int)Dictionary.JobStatus.EstimateNotApproved;
                        }
                        oCSDJob.Status = nStatus;
                        oCSDJob.SubStatus = 0;
                        oCSDJob.UpdateUserID = Utility.UserId;
                        oCSDJob.UpdateDate = DateTime.Now;
                        oCSDJob.UpdateJobStatus();
                        oCSDJob.StatusReason = txtRemarks.Text.Trim();
                        oCSDJob.UpdateStatusReason();
                    }
                }
                //if (rdoApproved.Checked == true)
                //{
                //    AddJobHistory((int)Dictionary.JobStatus.EstimateApproved);
                //}
                //else if(rdoDenied.Checked==true)
                //{
                //    AddJobHistory((int)Dictionary.JobStatus.EstimateNotApproved);
                //}

                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Saved Communication","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            _oCommunications = new Communications();
            lvwConversationList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oCommunications.RefreshByJobID(_nJobID);
            this.Text = "Communication | Job Number: " + oCSDJob.JobNo + " | Customer: " + oCSDJob.CustomerName;
            foreach (Communication oCommunication in _oCommunications)
            {
                ListViewItem oItem = lvwConversationList.Items.Add(oCommunication.CreateDate.ToString("dd-MMM-yyyy hh:mm: tt"));
                oItem.SubItems.Add(oCommunication.Remarks);
                oItem.SubItems.Add(oCommunication.UserName);
                oItem.Tag = oCommunication;
            }
            _oCSDSMSHistorys = new CSDSMSHistorys();
            _oCSDSMSHistorys.RefreshByJobID(_nJobID);
            lvwSMS.Items.Clear();
            foreach (CSDSMSHistory oCSDSMSHistory in _oCSDSMSHistorys)
            {
                ListViewItem oItem = lvwSMS.Items.Add(string.Empty);
                if (oCSDSMSHistory.SendDate != null)
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oCSDSMSHistory.SendDate).ToString("dd-MMM-yyyy hh:mm: tt"));
                }
                else
                {
                    oItem.SubItems.Add(string.Empty);
                }
                oItem.SubItems.Add(oCSDSMSHistory.SMSText);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CSDSMSStatus), oCSDSMSHistory.Status));
                oItem.SubItems.Add(oCSDSMSHistory.CreateUserName);
                oItem.Tag = oCSDSMSHistory;
            }

            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCommunication_Load(object sender, EventArgs e)
        {
            lblNextFollowupDate.Enabled = false;
            dtNxtFeedbackDate.Enabled = false;
            DataLoadControl();
        }

        private void chkRemindMeLater_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRemindMeLater.Checked)
            {
                lblNextFollowupDate.Enabled = true;
                dtNxtFeedbackDate.Enabled = true;
            }
            else
            {
                lblNextFollowupDate.Enabled = false;
                dtNxtFeedbackDate.Enabled = false;
            }
        }

        private void chkConversationComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConversationComplete.Checked)
            {
                lblNextFollowupDate.Enabled = false;
                chkRemindMeLater.Checked = false;
                chkRemindMeLater.Enabled = false;
                chkNoResponse.Enabled = false;
                dtNxtFeedbackDate.Enabled = false;
                lblNextFollowupDate.Enabled = false;
            }
            else
            {
                if (!chkRemindMeLater.Checked)
                {
                    dtNxtFeedbackDate.Enabled = false;
                }
                lblNextFollowupDate.Enabled = true;
                chkRemindMeLater.Enabled = true;
                chkNoResponse.Enabled = true;
                dtNxtFeedbackDate.Enabled = true;
                lblNextFollowupDate.Enabled = true;
            }
            
        }

        private void btnChangeFeedbackDate_Click(object sender, EventArgs e)
        {
            frmFeedbackDateChange ofrom = new frmFeedbackDateChange();
            ofrom.ShowDialog(oCSDJob.JobNo);
        }

        private void chkNoResponse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoResponse.Checked)
            {
                chkConversationComplete.Checked = false;
                chkConversationComplete.Enabled = false;
                rdoApproved.Enabled = false;
                rdoDenied.Enabled = false;
                gbEstimate.Enabled = false;
            }
            else
            {
                if (oCSDJob.Status == (int)Dictionary.JobStatus.Estimated || oCSDJob.Status == (int)Dictionary.JobStatus.EstimateApproved || oCSDJob.Status == (int)Dictionary.JobStatus.EstimateNotApproved)
                {
                    chkConversationComplete.Enabled = true;
                    rdoApproved.Enabled = true;
                    rdoDenied.Enabled = true;
                    gbEstimate.Enabled = true;
                }
            }
        }
    }
}
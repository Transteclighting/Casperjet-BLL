using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Reception
{
    public partial class frmCancelReason : Form
    {
        public bool _bIsAnyActivityDone = false;
        JobHistory _oJobHistory;
        public frmCancelReason()
        {
            InitializeComponent();
        }
        public void ShowDialog(CSDJob oCSDJob)
        {
            txtJobNo.Text = oCSDJob.JobNo;
            txtProductName.Text = oCSDJob.ProductName;
            txtCustomerName.Text = oCSDJob.CustomerName;
            txtCustomerAddress.Text = oCSDJob.CustomerAddress;
            txtMobileNo.Text = oCSDJob.MobileNo;

            this.Tag = oCSDJob;
            this.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtCancelReason.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Cancel Reason", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are You Sure to Cancel Job?", "Cancel Job", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                CancelJob();
                this.Close();
            }
        }
        private void CancelJob()
        {
            CSDJob oCSDJob = (CSDJob)this.Tag;
            try
            {
                _oJobHistory = new JobHistory();
                _oJobHistory.JobID = oCSDJob.JobID;
                _oJobHistory.StatusID = (int)Dictionary.JobStatus.Cancel;
                _oJobHistory.CreateUserID = Utility.UserId;
                _oJobHistory.CreateDate = DateTime.Now;
                _oJobHistory.ServiceType = oCSDJob.ServiceType;
                _oJobHistory.Remarks = "[Forcely Cencel Job] " + txtCancelReason.Text.Trim();
                _oJobHistory.SubStatusID = oCSDJob.SubStatus;

                oCSDJob.Status = _oJobHistory.StatusID;
                oCSDJob.UpdateUserID = Utility.UserId;
                oCSDJob.UpdateDate = DateTime.Now;

                DBController.Instance.BeginNewTransaction();
                oCSDJob.UpdateJobStatus();
                _oJobHistory.Add(oCSDJob.SubStatus);
                DBController.Instance.CommitTran();
                MessageBox.Show("Successfully Canceled", "Cencel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _bIsAnyActivityDone = true;
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

    }
}
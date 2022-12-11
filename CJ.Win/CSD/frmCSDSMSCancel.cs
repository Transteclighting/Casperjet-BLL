using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CSD
{
    public partial class frmCSDSMSCancel : Form
    {
        CSDSMSHistory _oCSDSMSHistory;
        public bool _bIsAnyActivity = false;
        public frmCSDSMSCancel()
        {
            InitializeComponent();
        }
        public void ShowDialog(CSDSMSHistory oCSDSMSHistory)
        {
            this.Tag = oCSDSMSHistory;
            this.ShowDialog();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtCancelReason.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter Cancel Reason", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult oResult = MessageBox.Show("Are You Sure to Cancel?", "Cancel SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    Cancel();
                    this.Close();
                }
            }
        }
        private void Cancel()
        {
            try
            {
                CSDSMSHistory oCSDSMSHistory = (CSDSMSHistory)this.Tag;
                oCSDSMSHistory.Status = (int)Dictionary.CSDSMSStatus.Cancel;
                oCSDSMSHistory.CancelUserID = Utility.UserId;
                oCSDSMSHistory.CancelDate = DateTime.Now;
                oCSDSMSHistory.CancelReason = txtCancelReason.Text.Trim();
                DBController.Instance.OpenNewConnection();
                DBController.Instance.BeginNewTransaction();
                oCSDSMSHistory.SMSCancel();
                DBController.Instance.CommitTran();
                MessageBox.Show("Successfully Cancelled", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _bIsAnyActivity = true;

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        
    }
}
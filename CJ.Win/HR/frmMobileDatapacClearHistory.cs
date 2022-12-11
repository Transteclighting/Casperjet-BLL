using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmMobileDatapacClearHistory : Form
    {
        public frmMobileDatapacClearHistory()
        {
            InitializeComponent();
        }
        public void ShowDialog(MobileNumberAssign oMobileNumberAssign)
        {
            this.Tag = oMobileNumberAssign;
            lblMobileNo.Text = oMobileNumberAssign.MobileNumber;
            this.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                ClearDatapac();
                this.Close();
            }
            
        }
        private void ClearDatapac()
        {
            MobileNumberAssign _oMobileNumberAssign = (MobileNumberAssign)this.Tag;            
            MobileNumber _oMobileNumber = new MobileNumber();
            _oMobileNumber.ID = _oMobileNumberAssign.MobileID;
            MobileDatapcClearHistory _oMobileDatapcClearHistory = new MobileDatapcClearHistory();
            _oMobileDatapcClearHistory.MobileID = _oMobileNumber.ID;
            _oMobileDatapcClearHistory.Date = dtDate.Value.Date;
            _oMobileDatapcClearHistory.CreateUserID = Utility.UserId;
            _oMobileDatapcClearHistory.CreateDate = DateTime.Now;
            _oMobileDatapcClearHistory.Remarks = txtRemarks.Text;
            
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oMobileNumber.ClearMobileNumber();
                _oMobileDatapcClearHistory.Add();
                _oMobileNumberAssign.UnassignMobileNumber();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Unassign Number And Clear Datapac & ISD", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private bool ValidateUIInput()
        {
            if (chkIsDatapacClear.Checked == true && chkIsISDClear.Checked == true)
            {
                return true;
            }
            else if (chkIsDatapacClear.Checked == false)
            {
                MessageBox.Show("Please Clear Datapac First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                MessageBox.Show("Please Clear ISD First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

    }
}
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 05, 2011
// Time :  4:55 PM
// Description: Class for Attendance Data.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win
{
    public partial class frmAttendData : Form
    {
        SMSMaker _oSMSMaker;
        public bool _bIsMobileNo= false;
        public frmAttendData()
        {
            InitializeComponent();
        }
        public bool bIsExecute = false;

        public void ShowDialog(AttendData oAttendData)
        {
            this.Tag = oAttendData;
            
            txtCardNo.Text = oAttendData.CardNo;
            cboStation.Text = oAttendData.StationNo;
            dtPunchDate.Value = oAttendData.PunchDate;
            dtPunchTime.Value = oAttendData.PunchTime;

            this.ShowDialog();
        }

        private void frmAttendData_Load(object sender, EventArgs e)
        {
            if (this.Tag == null) this.Text = "Add New Attendance Data";
            else this.Text = "Edit Attendance Data";
            
        }


        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtCardNo.Text == "")
            {
                MessageBox.Show("Please enter card No. of Attendance Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCardNo.Focus();
                return false;
            }
            if (txtCardNo.Text.Length < 9)
            {
                MessageBox.Show("Card No. must be 9 Digit ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCardNo.Focus();
                return false;
            }
            if (cboStation.Text == "")
            {
                MessageBox.Show("Please enter Station No of Attendance Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboStation.Focus();
                return false;
            }


            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                //btnClear_Click(sender, e);
                this.Close();
            }
        }


        private void Save()
        {
            if (this.Tag == null)
            {
              
                AttendData oAttendData = new AttendData();
                oAttendData.CardNo = txtCardNo.Text; 
                oAttendData.StationNo = cboStation.Text.Substring(0,3); //txtStationNo.Text;
                oAttendData.PunchDate = dtPunchDate.Value.Date;
                oAttendData.PunchTime = dtPunchTime.Value;
                oAttendData.IsSystem = false;
                oAttendData.UserID = Utility.UserId; 
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oAttendData.Add();
                    bIsExecute = true;
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Attendance Data of Card No: " + oAttendData.CardNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                AttendData oAttendData = (AttendData)this.Tag;
                oAttendData.CardNo = txtCardNo.Text; 
                oAttendData.StationNo = cboStation.Text.Substring(0, 3); //txtStationNo.Text;
                oAttendData.PunchDate = dtPunchDate.Value.Date;
                oAttendData.PunchTime = dtPunchTime.Value;
                oAttendData.IsSystem = false;
                oAttendData.UserID = Utility.UserId; 

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oAttendData.Edit();
                    bIsExecute = true;
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Attendance Data of Card No: " + oAttendData.CardNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void dtPunchDate_ValueChanged(object sender, EventArgs e)
        {
            dtPunchTime.Value = dtPunchDate.Value;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //_oSMSMaker = new SMSMaker();           
            //_oSMSMaker.AttendanceDataLateInfo();
            //MessageBox.Show("Successfully sent....!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Cursor = Cursors.Default;

            //bool IsSend = _oSMSMaker.IntegrateWithAPIForAttendData("01713380423","You are late by 1 hour");
            //if (IsSend)
            //{
            //    MessageBox.Show("Successfully sent....!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //ADDSMSHistory();
            //}
            //else
            //{
            //    MessageBox.Show("Error sending message...!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }        
    }
}
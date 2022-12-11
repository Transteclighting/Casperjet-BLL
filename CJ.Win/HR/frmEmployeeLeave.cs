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
    public partial class frmEmployeeLeave : Form
    {
        public frmEmployeeLeave()
        {
            InitializeComponent();
        }


        public void ShowDialog(EmployeeLeave oEmployeeLeave)
        {
            this.Tag = oEmployeeLeave;
            LoadCombos();
            ctlEmployee1.txtCode.Text = oEmployeeLeave.Employee.EmployeeCode;
            dtFromDate.Value = oEmployeeLeave.LeaveStartDate;
            dtToDate.Value = oEmployeeLeave.LeaveEndDate;
            cboLeaveType.SelectedIndex = (int)oEmployeeLeave.LeaveType;
            txtReason.Text = oEmployeeLeave.Reason;

            this.ShowDialog();
        }

        private void frmEmployeeLeave_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New EmployeeLeave";
                LoadCombos();
            }
            else this.Text = "Edit EmployeeLeave";
            
        }

        private void LoadCombos()
        {

            //Leave Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LeaveType)))
            {
                cboLeaveType.Items.Add(Enum.GetName(typeof(Dictionary.LeaveType), GetEnum));
            }
            cboLeaveType.SelectedIndex = (int)Dictionary.LeaveType.Earned_Leave;
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            if (ctlEmployee1.SelectedEmployee == null || ctlEmployee1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.Focus();
                return false;
            }
            //if (txtCode.Text == "")
            //{
            //    MessageBox.Show("Please enter Code of EmployeeLeave", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCode.Focus();
            //    return false;
            //}

            //if (txtReason.Text == "")
            //{
            //    MessageBox.Show("Please enter Reason for Leave", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtReason.Focus();
            //    return false;
            //}


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
                EmployeeLeave oEmployeeLeave = new EmployeeLeave();
                oEmployeeLeave.EmployeeID= ctlEmployee1.SelectedEmployee.EmployeeID;
                oEmployeeLeave.LeaveType = cboLeaveType.SelectedIndex;
                oEmployeeLeave.LeaveStartDate = dtFromDate.Value.Date ;
                oEmployeeLeave.LeaveEndDate = dtToDate.Value.Date;
                oEmployeeLeave.EntryDate = DateTime.Today;
                oEmployeeLeave.Reason = txtReason.Text;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEmployeeLeave.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oEmployeeLeave.EmployeeID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                EmployeeLeave oEmployeeLeave = (EmployeeLeave)this.Tag;
                oEmployeeLeave.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                oEmployeeLeave.LeaveType = cboLeaveType.SelectedIndex ;
                oEmployeeLeave.LeaveStartDate = dtFromDate.Value.Date;
                oEmployeeLeave.LeaveEndDate = dtToDate.Value.Date;
                oEmployeeLeave.EntryDate = DateTime.Today;
                oEmployeeLeave.Reason = txtReason.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEmployeeLeave.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The EmployeeLeave : " + oEmployeeLeave.EmployeeID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }



    }
}
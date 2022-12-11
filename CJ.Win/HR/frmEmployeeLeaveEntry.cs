using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.HR
{
    public partial class frmEmployeeLeaveEntry : Form
    {

        Employee _oEmployee;
        Employees _oEmployees;
        EmployeeLeaves _oEmployeeLeaves;
        EmployeeLeave _oLeave;
        EmployeeLeaves _oLeaveTypes;
        int nDayDiff = 0;
        int nNoOfDay = 0;
        int nLoginEmployeeID = 0;
        int nEmployeeID = 0;
        double nTotalDay = 0;
        int nLeaveEmployeeID = 0;
        int _nType = 0;
        int nLeaveID = 0;
        DateTime _dtEntryDate = DateTime.Now.Date;
        public bool _IsLoadTrue = false;

        public frmEmployeeLeaveEntry(int nType)
        {
            _nType = nType;
            InitializeComponent();
        }
        public void ShowDialog(EmployeeLeave oEmployeeLeave)
        {
            this.Tag = oEmployeeLeave;
            LoadCombos();

            if (_nType == (int)Dictionary.LeaveStatus.Approved)
            {
                cmbLeaveType.Enabled = false;
                cmbReason.Enabled = false;
                cmbInCharge.Enabled = false;
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                txtAddress.Enabled = false;
                txtPhone.Enabled = false;
                txtEmail.Enabled = false;
                rdo1stHalf.Enabled = false;
                rdo2ndHalf.Enabled = false;
                rdoFullday.Enabled = false;
                btnSave.Text = "Approved";
                btnSave.ForeColor = Color.Green;
                btnReject.Enabled = true;
            }
            btnReject.Enabled = false;

            nEmployeeID = oEmployeeLeave.EmployeeID;
            nLeaveID = oEmployeeLeave.LeaveID;
            _dtEntryDate = oEmployeeLeave.EntryDate;


            Employee _oEmployee = new Employee();
            _oEmployee.EmployeeID = nEmployeeID;
            _oEmployee.Refresh();
            ctlEmployee1.txtCode.Text = _oEmployee.EmployeeCode;


            dtFromDate.Value = oEmployeeLeave.LeaveStartDate;
            dtToDate.Value = oEmployeeLeave.LeaveEndDate;

            int nLeaveTypeIndex = 0;
            nLeaveTypeIndex = _oLeaveTypes.GetIndexLeaveType(oEmployeeLeave.LeaveType);
            cmbLeaveType.SelectedIndex = nLeaveTypeIndex + 1;


            cmbReason.Text = oEmployeeLeave.Reason;
            txtAddress.Text = oEmployeeLeave.Address;
            txtPhone.Text = oEmployeeLeave.MobileNo;
            txtEmail.Text = oEmployeeLeave.EmailAddress;
            txtDayNumb.Text = oEmployeeLeave.LeaveTotal.ToString();

            cmbInCharge.SelectedIndex = _oEmployees.GetIndex(oEmployeeLeave.InChargeID) + 1;

            if (oEmployeeLeave.PartialType == (int)Dictionary.PartialTypeLeave.FullDay)
            {
                rdoFullday.Checked = true;
            }
            else if (oEmployeeLeave.PartialType == (int)Dictionary.PartialTypeLeave.FirstHalf)
            {
                rdo1stHalf.Checked = true;
                double nNo1stHalf = 0;
                nNo1stHalf = 0.5;
                if (oEmployeeLeave.LeaveTotal == 1)
                {
                    txtDayNumb.Text = nNo1stHalf.ToString();
                }
                else
                {
                    oEmployeeLeave.LeaveTotal.ToString();
                }
            }

            else if (oEmployeeLeave.PartialType == (int)Dictionary.PartialTypeLeave.SecondHalf)
            {
                rdo2ndHalf.Checked = true;
                double nNo1stHalf = 0;
                nNo1stHalf = 0.5;
                if (oEmployeeLeave.LeaveTotal == 1)
                {
                    txtDayNumb.Text = nNo1stHalf.ToString();
                }
                else
                {
                    oEmployeeLeave.LeaveTotal.ToString();
                }
            }
            DayCalculation();
            this.ShowDialog();
        }

        private void LoadCombos()
        {
            //LeaveType

            _oLeaveTypes = new EmployeeLeaves();
            _oLeaveTypes.GetLeaveType();
            cmbLeaveType.Items.Clear();
            cmbLeaveType.Items.Add("--Select Leave Type--");
            foreach (EmployeeLeave oLeaveType in _oLeaveTypes)
            {
                cmbLeaveType.Items.Add(oLeaveType.LeaveTypeName);
            }
            cmbLeaveType.SelectedIndex = 0;

            //Leave Reason
            cmbReason.Items.Clear();
            cmbReason.Items.Add("---Select Reason---");
            cmbReason.Items.Add("Personal");
            cmbReason.Items.Add("Traning");
            cmbReason.Items.Add("Market Visit");
            cmbReason.Items.Add("Foreign Tour");
            cmbReason.Items.Add("Others");
            cmbReason.SelectedIndex = 0;

        }

        private bool validateUIInput()
        {


            if (ctlEmployee1.SelectedEmployee == null || ctlEmployee1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.Focus();
                return false;
            }

            if (ctlEmployee1.SelectedEmployee != null || ctlEmployee1.txtCode.Text != "")
            {
                DBController.Instance.OpenNewConnection();
                _oEmployee = new Employee();
                _oEmployee.GetPermission(Utility.UserId, ctlEmployee1.SelectedEmployee.CompanyID, ctlEmployee1.SelectedEmployee.DepartmentID);

                if (_oEmployee.CompanyID != ctlEmployee1.SelectedEmployee.CompanyID && _oEmployee.DepartmentID != ctlEmployee1.SelectedEmployee.DepartmentID)
                {
                    MessageBox.Show("You Have Not Enough Permission to add this Person Leave", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlEmployee1.Focus();
                    return false;
                }
            }

            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (cmbLeaveType.Text.Trim() == "--Select Leave Type--")
            {
                MessageBox.Show("Please enter Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLeaveType.Focus();
                return false;
            }
            if (txtDayNumb.Text.Trim() == "")
            {
                MessageBox.Show("Please Select End Date ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDayNumb.Focus();
                return false;
            }
            if (cmbReason.Text.Trim() == "---Select Reason---")
            {
                MessageBox.Show("Please Select Reason ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbReason.Focus();
                return false;
            }
            /////
            if (cmbLeaveType.Text == "Sick Leave")
            {

            }
            else if (cmbLeaveType.Text == "Casual Leave")
            {

            }
            else
            {
                if (cmbInCharge.Text.Trim() == "--Select Incharge Name--")
                {
                    MessageBox.Show("Please Select Incharge Name 1st ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbInCharge.Focus();
                    return false;
                }
            }

            if (cmbLeaveType.Text.Trim() != "--Select Leave Type--")
            {

                EmployeeLeave oBalance = new EmployeeLeave();

                _oEmployee = new Employee();
                int nCount = _oEmployee.GetEmployeebyID(ctlEmployee1.SelectedEmployee.EmployeeID);



                if (nCount > 0)
                {
                    oBalance.GetLeaveBalanceStuff(ctlEmployee1.SelectedEmployee.EmployeeID, _oLeaveTypes[cmbLeaveType.SelectedIndex - 1].LeaveType, dtFromDate.Value.Year);
                }
                else
                {
                    int nYear = 0;
                    if (dtFromDate.Value.Month < 3)
                    {
                        nYear = dtFromDate.Value.Year - 1;
                    }
                    else
                    {
                        nYear = dtFromDate.Value.Year;
                    }
                    oBalance.GetLeaveBalance(ctlEmployee1.SelectedEmployee.EmployeeID, _oLeaveTypes[cmbLeaveType.SelectedIndex - 1].LeaveType, nYear);
                }

                double _nLeaveCount = 0;
                double _nLeaveBalance = 0;
                _nLeaveCount = Convert.ToDouble(txtDayNumb.Text);
                _nLeaveBalance = oBalance.Balance - _oEmployeeLeaves[_oLeaveTypes[cmbLeaveType.SelectedIndex-1].LeaveType].Totalutilized - _nLeaveCount;

                //_nLeaveBalance =  oBalance.Balance - _nLeaveCount;
                if (_nLeaveBalance < 0)
                {
                    MessageBox.Show("Insufficient Leave Balance ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbLeaveType.Focus();
                    return false;
                }
            }

            return true;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (validateUIInput())
            {
                Save();
                _IsLoadTrue = true;
                this.Close();
            }

        }

        private void Save()
        {

            if (this.Tag == null)
            {
                EmployeeLeave oEmployeeLeave = new EmployeeLeave();
                oEmployeeLeave.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                oEmployeeLeave.CreateUserID = Utility.UserId;
                oEmployeeLeave.LeaveType = _oLeaveTypes[cmbLeaveType.SelectedIndex - 1].LeaveType;
                oEmployeeLeave.LeaveStartDate = dtFromDate.Value.Date;
                oEmployeeLeave.LeaveEndDate = dtToDate.Value.Date;
                oEmployeeLeave.EntryDate = DateTime.Now;
                oEmployeeLeave.Reason = cmbReason.Text;
                oEmployeeLeave.Address = txtAddress.Text;
                oEmployeeLeave.MobileNo = txtPhone.Text;
                oEmployeeLeave.EmailAddress = txtEmail.Text;
                oEmployeeLeave.LeaveTotal = Convert.ToDouble(txtDayNumb.Text);
                oEmployeeLeave.Status = (int)Dictionary.LeaveStatus.Acknowledged;

                if (rdoFullday.Checked == true)
                {
                    oEmployeeLeave.PartialType = (int)Dictionary.PartialTypeLeave.FullDay;
                }
                else if (rdo1stHalf.Checked == true)
                {
                    oEmployeeLeave.PartialType = (int)Dictionary.PartialTypeLeave.FirstHalf;
                }
                else if (rdo2ndHalf.Checked == true)
                {
                    oEmployeeLeave.PartialType = (int)Dictionary.PartialTypeLeave.SecondHalf;
                }
                oEmployeeLeave.InChargeID = _oEmployees[cmbInCharge.SelectedIndex - 1].EmployeeID;
                EmployeeLeave oMaxPriority = new EmployeeLeave();
                oMaxPriority.GetPriority(ctlEmployee1.SelectedEmployee.EmployeeID);
                oEmployeeLeave.Priority = oMaxPriority.Priority;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEmployeeLeave.AddTemp();

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oEmployeeLeave.LeaveID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                oEmployeeLeave.LeaveID = nLeaveID;
                oEmployeeLeave.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                oEmployeeLeave.InChargeID = _oEmployees[cmbInCharge.SelectedIndex - 1].EmployeeID;
                oEmployeeLeave.LeaveType = _oLeaveTypes[cmbLeaveType.SelectedIndex - 1].LeaveType;
                oEmployeeLeave.LeaveStartDate = dtFromDate.Value.Date;
                oEmployeeLeave.LeaveEndDate = dtToDate.Value.Date;
                oEmployeeLeave.EntryDate = _dtEntryDate;
                oEmployeeLeave.Reason = cmbReason.Text;
                oEmployeeLeave.Address = txtAddress.Text;
                oEmployeeLeave.MobileNo = txtPhone.Text;
                oEmployeeLeave.EmailAddress = txtEmail.Text;
                if (_nType == (int)Dictionary.LeaveStatus.Acknowledged)
                {
                    oEmployeeLeave.Status = (int)Dictionary.LeaveStatus.Acknowledged;
                }
                else
                {
                    oEmployeeLeave.Status = (int)Dictionary.LeaveStatus.Approved;
                }
                oEmployeeLeave.LeaveTotal = Convert.ToDouble(txtDayNumb.Text);
                if (rdoFullday.Checked == true)
                {
                    oEmployeeLeave.PartialType = (int)Dictionary.PartialTypeLeave.FullDay;
                }
                else if (rdo1stHalf.Checked == true)
                {
                    oEmployeeLeave.PartialType = (int)Dictionary.PartialTypeLeave.FirstHalf;
                }
                else if (rdo2ndHalf.Checked == true)
                {
                    oEmployeeLeave.PartialType = (int)Dictionary.PartialTypeLeave.SecondHalf;
                }
                else
                {
                    oEmployeeLeave.PartialType = 0;
                }

                if (_nType == (int)Dictionary.LeaveStatus.Approved)
                {
                    oEmployeeLeave.ApprovedUserID = Utility.UserId;
                    oEmployeeLeave.ApprovedDate = DateTime.Now;
                }
                else
                {
                    oEmployeeLeave.UpdateUserID = Utility.UserId;
                    oEmployeeLeave.UpdateDate = DateTime.Now;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (_nType == (int)Dictionary.LeaveStatus.Approved)
                    {
                        oEmployeeLeave.UpdateStatusTemp(_nType);
                        oEmployeeLeave.Approved();
                    }

                    else if (_nType == (int)Dictionary.LeaveStatus.Acknowledged)
                    {
                        oEmployeeLeave.EditTemp();
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Transaction : " + oEmployeeLeave.LeaveID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void ctlEmployee1_ChangeSelection(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();

            _oEmployees = new Employees();
            _oEmployees.GetIncharge(ctlEmployee1.SelectedEmployee.EmployeeID);
            cmbInCharge.Items.Clear();
            cmbInCharge.Items.Add("--Select Incharge Name--");
            foreach (Employee oEmployee in _oEmployees)
            {
                cmbInCharge.Items.Add(oEmployee.EmployeeName);
            }
            cmbInCharge.SelectedIndex = 0;

            _oEmployee = new Employee();
           int nCount =  _oEmployee.GetEmployeebyID(ctlEmployee1.SelectedEmployee.EmployeeID);// .GetIncharge();

            _oEmployeeLeaves = new EmployeeLeaves();
            lvwLeaveBalances.Items.Clear();
            int nEmployeeID = 0;
            nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            
            if (nCount > 0)
            {
                _oEmployeeLeaves.GetLeaveByEmployeeStuff(nEmployeeID);
            }
            else
            {
                _oEmployeeLeaves.GetLeaveByEmployee(nEmployeeID);
            }

            foreach (EmployeeLeave oEmployeeLeave in _oEmployeeLeaves)
            {
                ListViewItem oItem = lvwLeaveBalances.Items.Add(oEmployeeLeave.LeaveTypeName);
                oItem.SubItems.Add(oEmployeeLeave.LeaveAllowed.ToString());
                oItem.SubItems.Add(oEmployeeLeave.UtilizedTillDate.ToString());
                oItem.SubItems.Add(oEmployeeLeave.Prposed.ToString());
                oItem.SubItems.Add(oEmployeeLeave.Totalutilized.ToString());

                oItem.Tag = oEmployeeLeave;
            }

        }

        private void frmEmployeeLeaveEntry_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Leave";
                LoadCombos();
                btnReject.Visible = false;
            }
            else
            {
                this.Text = "Edit Leave";
            }

        }
        private void DayCalculation()
        {
            _oLeave = new EmployeeLeave();
            _oLeave.RefreshDiffDate(dtFromDate.Value.Date, dtToDate.Value.Date);
            nDayDiff = _oLeave.DiffDate;
            nNoOfDay = nDayDiff + 1;

            //if (cmbLeaveType.Text == "Casual Leave")
            //{
            _oLeave.GetNoofSATDay(dtFromDate.Value.Date, dtToDate.Value.Date);
            double _NoOfSAT = 0;
            _NoOfSAT = _oLeave.NoOfSatDay;
            _NoOfSAT = Convert.ToDouble(_NoOfSAT / 2);
            nTotalDay = Convert.ToDouble(nNoOfDay - _NoOfSAT);
            //}

            _oLeave.GetNoofHoliday(dtFromDate.Value.Date, dtToDate.Value.Date);
            int nHolDay = _oLeave.NoOfHoliday;
            //nHolDay = nHolDay + 1;

            if (cmbLeaveType.Text == "Earn Leave")
            {
                txtDayNumb.Text = Convert.ToString(nNoOfDay - nHolDay - _NoOfSAT);
            }
            else if (cmbLeaveType.Text == "Casual Leave")
            {
                txtDayNumb.Text = nTotalDay.ToString();
            }
            else
            {
                txtDayNumb.Text = nNoOfDay.ToString();

            }
            int nNo = 1;

            if (cmbLeaveType.Text == "Casual Leave" && txtDayNumb.Text == nNo.ToString())
            {
                rdo1stHalf.Visible = true;
                rdo2ndHalf.Visible = true;
                rdoFullday.Visible = true;
            }
            else
            {
                rdo1stHalf.Visible = false;
                rdo2ndHalf.Visible = false;
                rdoFullday.Visible = false;
            }
        }

        private void DayCalculationxxxxx()
        {
            _oLeave = new EmployeeLeave();
            _oLeave.RefreshDiffDate(dtFromDate.Value.Date, dtToDate.Value.Date);
            nDayDiff = _oLeave.DiffDate;
            nNoOfDay = nDayDiff + 1;

            if (cmbLeaveType.Text == "Casual_Leave")
            {
                _oLeave.GetNoofSATDay(dtFromDate.Value.Date, dtToDate.Value.Date);
                double _NoOfSAT = 0;
                _NoOfSAT = _oLeave.NoOfSatDay;
                _NoOfSAT = Convert.ToDouble(_NoOfSAT / 2);
                nTotalDay = Convert.ToDouble(nNoOfDay - _NoOfSAT);
            }

            _oLeave.GetNoofHoliday(dtFromDate.Value.Date, dtToDate.Value.Date);
            int nHolDay = _oLeave.NoOfHoliday;
            //nHolDay = nHolDay + 1;

            if (cmbLeaveType.Text == "Earned_Leave")
            {
                txtDayNumb.Text = Convert.ToString(nNoOfDay - nHolDay);
            }
            else if (cmbLeaveType.Text == "Casual_Leave")
            {
                txtDayNumb.Text = nTotalDay.ToString();
            }
            else
            {
                txtDayNumb.Text = nNoOfDay.ToString();

            }
            int nNo = 1;

            if (cmbLeaveType.Text == "Casual_Leave" && txtDayNumb.Text == nNo.ToString())
            {
                rdo1stHalf.Visible = true;
                rdo2ndHalf.Visible = true;
                rdoFullday.Visible = true;
            }
            else
            {
                rdo1stHalf.Visible = false;
                rdo2ndHalf.Visible = false;
                rdoFullday.Visible = false;
            }
        }

        private void rdoFullday_CheckedChanged(object sender, EventArgs e)
        {
            DayCalculation();
            txtDayNumb.Text = nTotalDay.ToString();
        }

        private void rdo1stHalf_CheckedChanged(object sender, EventArgs e)
        {
            DayCalculation();
            double nNo1stHalf = 0;
            nNo1stHalf = 0.5;
            if (nTotalDay == 1)
            {
                txtDayNumb.Text = nNo1stHalf.ToString();
            }
            else
            {
                txtDayNumb.Text = nTotalDay.ToString();
            }
        }

        private void rdo2ndHalf_CheckedChanged(object sender, EventArgs e)
        {
            DayCalculation();
            double nNo2ndHalf = 0;
            nNo2ndHalf = 0.5;

            if (nTotalDay == 1)
            {
                txtDayNumb.Text = nNo2ndHalf.ToString();
            }
            else
            {
                txtDayNumb.Text = nTotalDay.ToString();
            }
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            DayCalculation();
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            DayCalculation();
        }

        private void cmbLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DayCalculation();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete EmployeeLeave : " + ctlEmployee1.txtDescription.Text + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                EmployeeLeave oEmployeeLeave = new EmployeeLeave();
                oEmployeeLeave.LeaveID = nLeaveID;
                oEmployeeLeave.Status = (int)Dictionary.LeaveStatus.Reject;
                oEmployeeLeave.RejectDate = DateTime.Now.Date;
                oEmployeeLeave.RejectUserID = Utility.UserId;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEmployeeLeave.UpdateStatusTemp((int)Dictionary.LeaveStatus.Reject);
                    _IsLoadTrue = true;
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oEmployeeLeave.LeaveID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

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
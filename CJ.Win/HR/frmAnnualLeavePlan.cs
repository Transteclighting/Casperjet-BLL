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
    public partial class frmAnnualLeavePlan : Form
    {
        Employees _oEmployees;
        HRAnnualLeavePlan _oHRAnnualLeavePlan;
        int nLeavePlanID = 0;
        int nInChargID = 0;


        public frmAnnualLeavePlan()
        {
            InitializeComponent();
        }
        public void ShowDialog(HRAnnualLeavePlan oHRAnnualLeavePlan)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oHRAnnualLeavePlan;
            nLeavePlanID = 0;
            nLeavePlanID = oHRAnnualLeavePlan.LeavePlanID;
            dtToDate.Value = oHRAnnualLeavePlan.ToDate.Date;
            dtFromDate.Value = oHRAnnualLeavePlan.FromDate.Date;
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = oHRAnnualLeavePlan.EmployeeID;
            oEmployee.Refresh();
            ctlEmployee1.txtCode.Text = oEmployee.EmployeeCode;
            nInChargID = 0;
            nInChargID = _oEmployees.GetIndex(oHRAnnualLeavePlan.PersonInChargeID);
            cmbInCharge.SelectedIndex = nInChargID + 1;
            txtTotal.Text = Convert.ToInt32(oHRAnnualLeavePlan.LeaveTotal).ToString();



            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool UIValidation()
        {
            #region ValidInput
            if (cmbInCharge.SelectedIndex == null)
            {
                MessageBox.Show("Please Select Person In Charge", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbInCharge.Focus();
                return false;
            }
            if (ctlEmployee1.txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Employee Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.txtCode.Focus();
                return false;
            }
            #endregion

           return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                _oHRAnnualLeavePlan = new HRAnnualLeavePlan();
                _oHRAnnualLeavePlan.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                _oHRAnnualLeavePlan.FromDate = dtFromDate.Value.Date;
                _oHRAnnualLeavePlan.ToDate = dtToDate.Value.Date;
                _oHRAnnualLeavePlan.LeaveTotal = Convert.ToInt32(txtTotal.Text);
                _oHRAnnualLeavePlan.PersonInChargeID = _oEmployees[cmbInCharge.SelectedIndex-1].EmployeeID;
                _oHRAnnualLeavePlan.CreateDate = DateTime.Now;
                _oHRAnnualLeavePlan.CreateUserID = Utility.UserId;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oHRAnnualLeavePlan.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add Annual Leave Plan. Employee Name: " + ctlEmployee1.SelectedEmployee.EmployeeName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                _oHRAnnualLeavePlan = new HRAnnualLeavePlan();
                _oHRAnnualLeavePlan.LeavePlanID = nLeavePlanID;
                _oHRAnnualLeavePlan.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                _oHRAnnualLeavePlan.FromDate = dtFromDate.Value.Date;
                _oHRAnnualLeavePlan.ToDate = dtToDate.Value.Date;
                _oHRAnnualLeavePlan.LeaveTotal = Convert.ToInt32(txtTotal.Text);
                _oHRAnnualLeavePlan.PersonInChargeID = _oEmployees[cmbInCharge.SelectedIndex - 1].EmployeeID;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oHRAnnualLeavePlan.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update Annual Leave Plan. Employee Name : " + ctlEmployee1.SelectedEmployee.EmployeeName, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void DayCalculation()
        {
            TimeSpan Total = (dtToDate.Value - dtFromDate.Value);
            int TdDay = Convert.ToInt32(Total.TotalDays) + 1;
            txtTotal.Text = Convert.ToString(TdDay);
            if (Convert.ToInt32(TdDay) <= 0)
            {
                MessageBox.Show("End Date shoule be grather than Start Date");
            }
            else
            {
                txtTotal.Text = Convert.ToString(TdDay);
            }

        }

        private void ctlEmployee1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlEmployee1.txtCode != null)
            {

                _oEmployees = new Employees();
                _oEmployees.GetPersonInCharge(ctlEmployee1.txtCode.Text);
                cmbInCharge.Items.Clear();
                cmbInCharge.Items.Add("<All>");
                foreach (Employee oEmployee in _oEmployees)
                {
                    cmbInCharge.Items.Add(oEmployee.EmployeeName);
                }
                cmbInCharge.SelectedIndex = 0;
                        
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

        private void frmAnnualLeavePlan_Load(object sender, EventArgs e)
        {
            DayCalculation();
        }
    }
}
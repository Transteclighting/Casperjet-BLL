using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;
using CJ.Class.Library;

namespace CJ.Win.HR
{
    public partial class frmHRPayrollAddDeduct : Form
    {
        int nID = 0;
        public bool IsExecute = false;
        public frmHRPayrollAddDeduct()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            IsExecute = false;
            this.Close();
        }

        public void ShowDialog(HRPayrollAddDeduct oHRPayrollAddDeduct)
        {
            this.Tag = oHRPayrollAddDeduct;
            nID = oHRPayrollAddDeduct.ID;
            DateTime _Date = Convert.ToDateTime("01-" + oHRPayrollAddDeduct.Month + "-"+oHRPayrollAddDeduct.Year);
            dtMonth.Value = _Date;
            ctlEmployee1.txtCode.Text = oHRPayrollAddDeduct.EmployeeCode;
            if (oHRPayrollAddDeduct.Type == (int)Dictionary.AllowanceDeductionType.Add)
            {
                rdoAddition.Checked = true;
                if (oHRPayrollAddDeduct.AllowanceID == (int)Dictionary.HREmployeeAllowance.NightShiftAllowance)
                {
                    rdoNightShift.Checked = true;
                }
                else
                {
                    rdoOthers.Checked = true;
                }
            }
            else
            {
                rdoDeduction.Checked = true;
                if (oHRPayrollAddDeduct.AllowanceID == (int)Dictionary.HREmployeeAllowance.NightShiftAllowance)
                {
                    rdoNightShift.Checked = true;
                }
                else
                {
                    rdoOthers.Checked = true;
                }
            }
            txtAmount.Text = oHRPayrollAddDeduct.Amount.ToString();
            txtReason.Text = oHRPayrollAddDeduct.Remarks;


            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                IsExecute = true;
                this.Close();
            }
        }

        private void frmHRPayrollAddDeduct_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Add/Deduct";
                rdoAddition.Checked = true;
                rdoOthers.Checked = true;
            }
            else
            {
                this.Text = "Edit Add/Deduct";
            }
        }

        private bool validateUIInput()
        {
            if (ctlEmployee1.txtDescription.Text == "")
            {
                MessageBox.Show("Please input Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.Focus();
                return false;
            }

            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }
            else
            {
                double temp = 0;
                try
                {
                    temp = Convert.ToDouble(txtAmount.Text);
                }
                catch
                {
                    MessageBox.Show("Please input valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (temp <= 0)
                {
                    MessageBox.Show("Amount Must be grather than Zero (0)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            
            }
            if (rdoOthers.Checked == true)
            {
                if (txtReason.Text == "")
                {
                    MessageBox.Show("Please enter Add/Deduct reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReason.Focus();
                    return false;
                }
            }
            return true;
        }

        private void Save()
        {
            HRPayrollAddDeduct oHRPayrollAddDeduct = new HRPayrollAddDeduct();

            oHRPayrollAddDeduct.CompanyID = ctlEmployee1.SelectedEmployee.CompanyID;
            oHRPayrollAddDeduct.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            DateTime _Date = dtMonth.Value;

            oHRPayrollAddDeduct.Month = _Date.Month;
            oHRPayrollAddDeduct.Year = _Date.Year;
            if (rdoAddition.Checked == true)
            {
                oHRPayrollAddDeduct.Type = (int)Dictionary.AllowanceDeductionType.Add;
                if (rdoNightShift.Checked == true)
                {
                    oHRPayrollAddDeduct.AllowanceID = (int)Dictionary.HREmployeeAllowance.NightShiftAllowance;
                }
                else
                {
                    oHRPayrollAddDeduct.AllowanceID = (int)Dictionary.HREmployeeAllowance.Otherexpense;
                }
            }
            else
            {
                oHRPayrollAddDeduct.Type = (int)Dictionary.AllowanceDeductionType.Deduct;
                oHRPayrollAddDeduct.AllowanceID = (int)Dictionary.HREmployeeAllowance.OtherDeduction;
            }
            
            oHRPayrollAddDeduct.Amount = Convert.ToDouble(txtAmount.Text);
            oHRPayrollAddDeduct.Status = (int)Dictionary.PayrollAddDeductStatus.Create;
            oHRPayrollAddDeduct.Remarks = txtReason.Text;
            oHRPayrollAddDeduct.CreateUserID = Utility.UserId;
            oHRPayrollAddDeduct.CreateDate = DateTime.Now;
            oHRPayrollAddDeduct.UpdateUserID = Utility.UserId;
            oHRPayrollAddDeduct.UpdateDate = DateTime.Now;

            if (this.Tag == null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRPayrollAddDeduct.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Data Save Successfully, ID: " + oHRPayrollAddDeduct.ID.ToString(), "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRPayrollAddDeduct.ID = nID;
                    oHRPayrollAddDeduct.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Data Save Successfully, ID: " + oHRPayrollAddDeduct.ID.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (ctlEmployee1.txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Employee Number","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ctlEmployee1.txtCode.Focus();
                return;
            }
            if (txtHours.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Hours", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHours.Focus();
                return;
            }
            else
            {
                try
                {
                    double temp = Convert.ToDouble(txtHours.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter Valid Hours", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMinute.Focus();
                    return;
                }
            }
            if (txtMinute.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Minute", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMinute.Focus();
                return;
            }
            else
            {
                double temp = 0;
                try
                {
                    temp = Convert.ToDouble(txtMinute.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter Valid Minute", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMinute.Focus();
                    return;
                }
                if (temp > 59)
                {
                    MessageBox.Show("Please enter Valid Minute", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMinute.Focus();
                    return;
                }
            }
            int nHours = Convert.ToInt32(txtHours.Text);
            int nMinute = Convert.ToInt32(txtMinute.Text);
            int nTotalMinutes = nHours * 60 + nMinute;

            DateTime _Date = dtMonth.Value.Date;
            TELLib _oTELLib = new TELLib();
            DateTime _LastDateOfMonth = _oTELLib.LastDayofMonth(_Date);
            int nDay = _LastDateOfMonth.Day;
            int nYear = dtMonth.Value.Year;

            Employee _oEmployee = new Employee();
            _oEmployee.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            _oEmployee.Refresh();

            HRPayroll _oHRPayroll = new HRPayroll();
            double _TakehomeSalary = _oHRPayroll.GetTakehomeSalary(_oEmployee.EmployeeID, _oEmployee.CompanyID, nYear);

            double _x = Math.Round((_TakehomeSalary / nDay / 8 / 60) * nTotalMinutes,0);
            txtAmount.Text = _x.ToString();

        }

        private void chkLWPCalculator_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLWPCalculator.Checked == true)
            {
                lblNote.Visible = true;
                gbLWPCalculate.Visible = true;
            }
            else
            {
                lblNote.Visible = false;
                gbLWPCalculate.Visible = false;
            }
        }

        private void rdoAddition_CheckedChanged(object sender, EventArgs e)
        {
            rdoNightShift.Enabled = true;  
        }

        private void rdoDeduction_CheckedChanged(object sender, EventArgs e)
        {
            rdoOthers.Checked = true;
            rdoNightShift.Enabled = false;
        }

    }
}
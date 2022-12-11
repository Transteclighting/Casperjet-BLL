// <summary>
// Compamy: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Jun 20, 2016
// Time : 02:02 PM
// Description: Module for Employee Salary Settings.
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
using CJ.Class.HR;
using CJ.Class.Report;
using CJ.Class.Library;

namespace CJ.Win.HR
{
    public partial class frmPayrollEmployeeSetting : Form
    {
        EmployeeAllowance _oEmployeeAllowance;
        public bool _bFlag = false;
        int nEmployeeID = 0;
        int nCompanyID = 0;

        public frmPayrollEmployeeSetting()
        {
            InitializeComponent();
        }

        private void frmPayrollEmployeeSetting_Load(object sender, EventArgs e)
        {
            chkAutoDistributed.Checked = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _bFlag = true;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        public void ShowDialog(EmployeeAllowance oEmployeeAllowance)
        {
            this.Tag = oEmployeeAllowance;

            dtSalaryMonth.Value = Convert.ToDateTime("01-Jan-" + oEmployeeAllowance.EffectiveYear);
            lblEmployee.Text = "Employee: " + oEmployeeAllowance.Name + " [" + oEmployeeAllowance.Code + "]";
            nEmployeeID = oEmployeeAllowance.EmployeeID;
            nCompanyID = oEmployeeAllowance.CompanyID;
            FillData(nCompanyID);

            this.ShowDialog();
        }

        private void Save()
        {
            
            DateTime _Date = dtSalaryMonth.Value;
            int nYear = _Date.Year;

            _oEmployeeAllowance = new EmployeeAllowance();

            _oEmployeeAllowance.EmployeeID = nEmployeeID;
            _oEmployeeAllowance.CompanyID = nCompanyID;
            _oEmployeeAllowance.EffectiveYear = nYear;

            DBController.Instance.OpenNewConnection();
            DBController.Instance.BeginNewTransaction();
            try
            {
                _oEmployeeAllowance.Delete(nCompanyID, nEmployeeID, nYear);

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.BasicSalary;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtBasicSalary.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.HouseRent;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtHouseRent.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.CarAllowance;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtCarAllowance.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.MedicalAllowanceforStaff;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtMedicalAllowance.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.Conveyance;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtConveyanceAllowance.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.EntertainmentAllowance;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtEntertainmentAllowance.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.SpecialAllowance;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtSpecialAllowance.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.PF;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtProvidentFund.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.AITSalary;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtAITSalary.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.HouseMaintenance;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtHouseManitenance.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.Utilityexpense;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtUtilityExpense.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.ChildEducationAllowance;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtChildrenEduExpense.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.OverTimeExpense;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtOvertimeExpense.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.LunchExpense;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtLunchExpense.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.Canteenexpense;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtCanteenExpense.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.Otherexpense;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtOtherExpense.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.NonRotatingShift;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtNonRotatingAllow.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.RotatingShift;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtShiftingAllowance.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.Driverexpense;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtDriverExpense.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.Serventexpense;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtServentExpense.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.FestivalBonus;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtFestivalBonus.Text);
                _oEmployeeAllowance.Add();

                _oEmployeeAllowance.AllowanceID = (int)Dictionary.HREmployeeAllowance.LFA;
                _oEmployeeAllowance.Amount = Convert.ToDouble(txtLFA.Text);
                _oEmployeeAllowance.Add();

                DBController.Instance.CommitTran();
                MessageBox.Show("Data Save Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error Saving Data:\n" + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBasicSalary_TextChanged(object sender, EventArgs e)
        {
            //if (this.Tag == null)
            if (chkAutoDistributed.Checked == true)
            {
                txtHouseRent.Text =Convert.ToString(Math.Round(Convert.ToDouble(txtBasicSalary.Text) / 2, 0));
                txtProvidentFund.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBasicSalary.Text) * 10/100, 0));
                txtUtilityExpense.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBasicSalary.Text) * 25/100, 0));
                txtServentExpense.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBasicSalary.Text) * 25/100, 0));
                txtFestivalBonus.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtBasicSalary.Text), 0));
            }
            Sum();
        }

        private void Sum()
        {
            double _GrossSalary = Math.Round(Convert.ToDouble(txtBasicSalary.Text), 0) + Math.Round(Convert.ToDouble(txtHouseRent.Text), 0) + Math.Round(Convert.ToDouble(txtCarAllowance.Text), 0) + Math.Round(Convert.ToDouble(txtMedicalAllowance.Text), 0) + Math.Round(Convert.ToDouble(txtConveyanceAllowance.Text), 0) + Math.Round(Convert.ToDouble(txtEntertainmentAllowance.Text), 0) + Math.Round(Convert.ToDouble(txtSpecialAllowance.Text), 0);
            txtGrossSalary.Text = _GrossSalary.ToString();

            double _TotalDeduction = Math.Round(Convert.ToDouble(txtProvidentFund.Text), 0) + Math.Round(Convert.ToDouble(txtAITSalary.Text), 0);
            txtTotalDeduction.Text = _TotalDeduction.ToString();

            double _NetPayment = _GrossSalary - _TotalDeduction;
            txtNetPayable.Text = _NetPayment.ToString();

            double _TotalExpense = Math.Round(Convert.ToDouble(txtHouseManitenance.Text), 0) + Math.Round(Convert.ToDouble(txtUtilityExpense.Text), 0) + Math.Round(Convert.ToDouble(txtChildrenEduExpense.Text), 0) + Math.Round(Convert.ToDouble(txtOvertimeExpense.Text), 0) + Math.Round(Convert.ToDouble(txtLunchExpense.Text), 0) + Math.Round(Convert.ToDouble(txtCanteenExpense.Text), 0) + Math.Round(Convert.ToDouble(txtOtherExpense.Text), 0) + Math.Round(Convert.ToDouble(txtNonRotatingAllow.Text), 0) + Math.Round(Convert.ToDouble(txtShiftingAllowance.Text), 0);
            txtTotalExpense.Text = _TotalExpense.ToString();

            double _TotalSubsidy = Math.Round(Convert.ToDouble(txtDriverExpense.Text), 0) + Math.Round(Convert.ToDouble(txtServentExpense.Text), 0);
            txtTotalSubsidy.Text = _TotalSubsidy.ToString();

            double _Total = _TotalExpense + _TotalSubsidy;
            txtTotal.Text = _Total.ToString();

            txtTakeHomeSalary.Text = Convert.ToString(_NetPayment + _Total);
        }

        private void txtHouseRent_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtCarAllowance_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtMedicalAllowance_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtConveyanceAllowance_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtEntertainmentAllowance_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtSpecialAllowance_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtProvidentFund_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtAITSalary_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtHouseManitenance_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtUtilityExpense_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtChildrenEduExpense_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtOvertimeExpense_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtLunchExpense_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtCanteenExpense_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtOtherExpense_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtNonRotatingAllow_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtShiftingAllowance_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtDriverExpense_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void txtServentExpense_TextChanged(object sender, EventArgs e)
        {
            Sum();
        }

        private void FillData(int nCompanyID)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime _Date = dtSalaryMonth.Value.Date;
            int nYear = _Date.Year;
            _oEmployeeAllowance = new EmployeeAllowance();
            int nAllowanceID = 0;

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.BasicSalary;
            txtBasicSalary.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.HouseRent;
            txtHouseRent.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.CarAllowance;
            txtCarAllowance.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.MedicalAllowanceforStaff;
            txtMedicalAllowance.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.Conveyance;
            txtConveyanceAllowance.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.EntertainmentAllowance;
            txtEntertainmentAllowance.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.SpecialAllowance;
            txtSpecialAllowance.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.PF;
            txtProvidentFund.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.AITSalary;
            txtAITSalary.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.HouseMaintenance;
            txtHouseManitenance.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.Utilityexpense;
            txtUtilityExpense.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.ChildEducationAllowance;
            txtChildrenEduExpense.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.OverTimeExpense;
            txtOvertimeExpense.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.LunchExpense;
            txtLunchExpense.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.Canteenexpense;
            txtCanteenExpense.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.Otherexpense;
            txtOtherExpense.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.NonRotatingShift;
            txtNonRotatingAllow.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.RotatingShift;
            txtShiftingAllowance.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.Driverexpense;
            txtDriverExpense.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.Serventexpense;
            txtServentExpense.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.FestivalBonus;
            txtFestivalBonus.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));

            nAllowanceID = (int)Dictionary.HREmployeeAllowance.LFA;
            txtLFA.Text = Convert.ToString(_oEmployeeAllowance.GetAllowance(nEmployeeID, nAllowanceID, nYear, nCompanyID));
            
            this.Cursor = Cursors.Default;
        }

        private void dtSalaryMonth_ValueChanged(object sender, EventArgs e)
        {
            FillData(nCompanyID);
        }

        private void chkAutoDistributed_CheckedChanged(object sender, EventArgs e)
        {
            Sum(); 
        }

    }
}
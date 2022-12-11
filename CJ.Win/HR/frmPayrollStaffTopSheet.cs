using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;
using CJ.Report;
using CJ.Report.HR;
using CJ.Class.Library;

namespace CJ.Win.HR
{
    public partial class frmPayrollStaffTopSheet : Form
    {
        TELLib _oTElLib;
        Companys _oCompanys;
        public frmPayrollStaffTopSheet()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PayrollPrint();
        }

        private void LoadCombos()
        {
            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cmbCompany.Items.Clear();
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

        }

        private void PayrollPrint()
        {
            DateTime _Date = dtSalaryMonth.Value.Date;
            int nMonth = _Date.Month;
            int nYear = _Date.Year;
            _oTElLib = new TELLib();
            int nCompanyID = 0;
            int nPayrollSettingsID = 0;

            if (_oCompanys.Count > 0)
            {
                nCompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
            }

            if (rdoSalary.Checked == true)
            {
                nPayrollSettingsID = (int)Dictionary.PayrollSettings.FullSalary;
            }
            else if (rdoBonus.Checked == true)
            {
                nPayrollSettingsID = (int)Dictionary.PayrollSettings.FestivalBonus;
            }
            else if (rdoLFA.Checked == true)
            {
                nPayrollSettingsID = (int)Dictionary.PayrollSettings.LFA;
            }
            else if (rdoArear.Checked == true)
            {
                nPayrollSettingsID = (int)Dictionary.PayrollSettings.AREAR;
            }

            
            EmployeeAllowances _oEmployeeAllowances = new EmployeeAllowances();
            this.Cursor = Cursors.WaitCursor;
            _oEmployeeAllowances.RefreshPayrollStaffTopSheet(nMonth, nYear, nCompanyID, nPayrollSettingsID);

            if (_oEmployeeAllowances.Count == 0)
            {
                MessageBox.Show("There is no data!!","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                return;
            }
            
            rptPayrollStaffTopSheet doc;
            doc = new rptPayrollStaffTopSheet();
            doc.SetDataSource(_oEmployeeAllowances);
            
            doc.SetParameterValue("Type", "Staff");
            string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), nMonth);
            doc.SetParameterValue("Month", _sMonth + " - " + nYear.ToString());
            doc.SetParameterValue("ReportName", "Staff Salary Top Sheet for the month of " + _sMonth + " - " + nYear.ToString());
            doc.SetParameterValue("User", Utility.UserFullname);
            doc.SetParameterValue("Company", "Bangladesh Lamps Limited");
            double _Amount = TotalAmount(_oEmployeeAllowances);
            doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

            this.Cursor = Cursors.Default;
        }

        private void frmPayrollStaffTopSheet_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private double TotalAmount(EmployeeAllowances _oEmployeeAllowances)
        {
            double _Amount = 0;
            foreach (EmployeeAllowance oHRPayrollAllow in _oEmployeeAllowances)
            {
                _Amount = _Amount + (oHRPayrollAllow.BasicSalary + oHRPayrollAllow.ConsolidateSalary + oHRPayrollAllow.HouseRent + oHRPayrollAllow.MedicalAllowanceforStaff + oHRPayrollAllow.EntertainmentAllowance + oHRPayrollAllow.Conveyance + oHRPayrollAllow.SpecialAllowance + oHRPayrollAllow.RotatingShift + oHRPayrollAllow.NonRotatingShift + oHRPayrollAllow.LFA + oHRPayrollAllow.FestivalBonus + oHRPayrollAllow.OverTime + oHRPayrollAllow.Lunch + oHRPayrollAllow.NightShiftAllowance + oHRPayrollAllow.ChildEducationAllowance + oHRPayrollAllow.OtherExpense) -(oHRPayrollAllow.PF + oHRPayrollAllow.PFLoanPrincipal + oHRPayrollAllow.PFLoanInterest + oHRPayrollAllow.ArticleLoanTV + oHRPayrollAllow.ArticleLoanRef + oHRPayrollAllow.ArticleLoanAC + oHRPayrollAllow.EmergencyLoan + oHRPayrollAllow.EPSLoan + oHRPayrollAllow.BuildingLoanPrincipal + oHRPayrollAllow.BuildingLoanInterest + oHRPayrollAllow.AdvanceSalary + oHRPayrollAllow.AITSalary + oHRPayrollAllow.MobileBill + oHRPayrollAllow.OtherDeduction);
            }
            return _Amount;
        }

        private void rdoArear_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoSalary_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
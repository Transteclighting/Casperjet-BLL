// <summary>
// Compamy: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Jun 16, 2016
// Time : 04:30 PM
// Description: Module for Payroll.
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
    public partial class frmPayroll : Form

    {
        
        string sFromDate = "";
        string sToDate = "";
        Employees oEmployees;
        Employee _oEmployee;
        DSGetEmployee _oDSGetEmployee;
        EmployeeAllowance _oEmployeeAllownace;
        EmployeeAllowances _oEmployeeAllownaces;
        HRLoan _oHRLoan;
        EPSSalesOrder _oEPSSalesOrder;
        Companys _oCompanys;
        HRPayroll _oHRPayroll;
        int nTotalData = 0;
        int _nTotalColumn = 80;
        int nLastColumnIndex = 0;
        double _LoanAmount = 0;
        bool _bFlag = false;
        TELLib oLib;
        int nPayrollID = 0;

        int indexGrossSalary = 0;
        int indexTotalDeduction = 0;
        int indexTotalExpense = 0;
        int indexTotalSubsidy = 0;
        int indexNetSalary = 0;
        int indexTotalSalary = 0;

        public frmPayroll()
        {
            InitializeComponent();
        }

        private void btnGetEmployee_Click(object sender, EventArgs e)
        {
            if (DataGetValidate())
            {
                cmbCompany.Enabled = false;
                cmbType.Enabled = false;
                frmPayrollGetEmployee oFrom = new frmPayrollGetEmployee(_oCompanys[cmbCompany.SelectedIndex - 1].CompanyID, cmbCompany.Text, cmbType.SelectedIndex, cmbType.Text);
                oFrom.ShowDialog();
                oEmployees = oFrom._oEmployees;
                FillDataSet(oFrom._oEmployees);
                this.Text = "HR Payroll | Selected Employee: " + Convert.ToString(RowCount());
                lblProgress.Text = "0/" + Convert.ToString(RowCount());
                if (oEmployees != null)
                {
                    if (oEmployees.Count > 0)
                    {
                        btnSave.Enabled = false;
                        btnProcess.Enabled = true;
                    }
                }
                else
                {
                    btnSave.Enabled = false;
                    btnProcess.Enabled = false;
                }
            }
        }

        private void FillDataSet(Employees oEmployees)
        {
            _oDSGetEmployee = new DSGetEmployee();
            if (oEmployees == null)
            { oEmployees = new Employees(); }
            foreach (Employee oEmployee in oEmployees)
            {
                DSGetEmployee.EmployeeRow oRow = _oDSGetEmployee.Employee.NewEmployeeRow();

                oRow.EmployeeID = oEmployee.EmployeeID;
                oRow.EmployeeCode = oEmployee.EmployeeCode;
                oRow.EmployeeName = oEmployee.EmployeeName;

                _oDSGetEmployee.Employee.AddEmployeeRow(oRow);
                _oDSGetEmployee.AcceptChanges();
            }
            AppendToGrid(_oDSGetEmployee);
        }

        private void AppendToGrid(DSGetEmployee oDSEmployee)
        {
            int nIndex = 0;
            nTotalData = oDSEmployee.Employee.Count;
            lblProgress.Text = "0/" + nTotalData.ToString();
            foreach (DSGetEmployee.EmployeeRow oDSRow in oDSEmployee.Employee)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvItem);
                oRow.Cells[0].Value = oDSRow.EmployeeCode;
                oRow.Cells[1].Value = oDSRow.EmployeeName;
                oRow.Cells[2].Value = oDSRow.EmployeeID;
                dgvItem.Rows.Add(oRow);

                //nIndex = checkDuplicateLineItem(oRow.Cells[0].Value.ToString());

                //if (nIndex > 1)
                //{
                //    oRow.Cells[2].Value = "";
                //    MessageBox.Show("Duplicate Employee!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                //    dgvItem.Rows.RemoveAt(nIndex);
                //    return;
                //}
                //else
                //{
                //    dgvItem.Rows[nIndex].Cells[0].ReadOnly = true;
                //    GetTotalEmployee();
                //}
                //nIndex++;
                GetTotalEmployee();
            }
        }

        private void AddColumnsDynamically()
        {
            RemoveColumns(_nTotalColumn);

            _oEmployeeAllownaces = new EmployeeAllowances();
            _oEmployeeAllownaces.GetAllowance();
            int nCount = 0;
            int nGroupID = 1;
            foreach (EmployeeAllowance oAllowance in _oEmployeeAllownaces)
            {
                nCount++;
                string sColumn = "col" + nCount.ToString();
                string sColumn1 = sColumn + "_1";

                string sColumnHead = oAllowance.Name;
                string sColumnName = sColumnHead.Replace(" ", "");

                //Add Sub Total and Total
                if (oAllowance.GroupID > nGroupID)
                {
                    TotalColumn(nGroupID);
                    nGroupID++;
                }

                //Basic Salary (Column Index 3,4)
                DataGridViewTextBoxColumn Col = new DataGridViewTextBoxColumn();
                Col.HeaderText = sColumnHead;
                Col.Name = sColumnName;
                Col.Width = 60;
                Col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvItem.Columns.Add(Col);
                DataGridViewTextBoxColumn Col1 = new DataGridViewTextBoxColumn();
                Col1.HeaderText = sColumnHead + "_1";
                Col1.Name = sColumnName + "_1";
                dgvItem.Columns.Add(Col1);
                dgvItem.Columns[sColumnName + "_1"].Visible = false;

            }
            //For Last
            TotalColumn(4);

        }

        private void TotalColumn(int nGroupID)
        {

            if (nGroupID == (int)Dictionary.AllowanceGroupType.GrossSalary)
            {
                //Gross Salary (Column Index 21)
                DataGridViewTextBoxColumn col11 = new DataGridViewTextBoxColumn();
                col11.HeaderText = "Gross Salary";
                col11.Name = "GrossSalary";
                col11.Width = 80;
                col11.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col11.ReadOnly = true;
                col11.DefaultCellStyle.BackColor = Color.LightGray;
                dgvItem.Columns.Add(col11);
            }
            else if (nGroupID == (int)Dictionary.AllowanceGroupType.Deduction)
            {
                //Total Deduction (Column Index 46)
                DataGridViewTextBoxColumn col25 = new DataGridViewTextBoxColumn();
                col25.HeaderText = "Total Deduction";
                col25.Name = "TotalDeduction";
                col25.Width = 70;
                col25.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col25.ReadOnly = true;
                col25.DefaultCellStyle.BackColor = Color.LightGray;
                dgvItem.Columns.Add(col25);

                //Net Salary (Column Index 47)
                DataGridViewTextBoxColumn col26 = new DataGridViewTextBoxColumn();
                col26.HeaderText = "Net Salary";
                col26.Name = "NetSalary";
                col26.Width = 80;
                col26.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col26.ReadOnly = true;
                col26.DefaultCellStyle.BackColor = Color.LightGray;
                dgvItem.Columns.Add(col26);
            }
            else if (nGroupID == (int)Dictionary.AllowanceGroupType.Expense)
            {
                //Total Expense (Column Index 66)
                DataGridViewTextBoxColumn col36 = new DataGridViewTextBoxColumn();
                col36.HeaderText = "Total Expense";
                col36.Name = "TotalExpense";
                col36.Width = 80;
                col36.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col36.ReadOnly = true;
                col36.DefaultCellStyle.BackColor = Color.LightGray;
                dgvItem.Columns.Add(col36);
            }
            else if (nGroupID == (int)Dictionary.AllowanceGroupType.Subsidy)
            {
                //Total Subsidy (Column Index 71)
                DataGridViewTextBoxColumn col39 = new DataGridViewTextBoxColumn();
                col39.HeaderText = "Total Subsidy";
                col39.Name = "TotalSubsidy";
                col39.Width = 80;
                col39.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col39.ReadOnly = true;
                col39.DefaultCellStyle.BackColor = Color.LightGray;
                dgvItem.Columns.Add(col39);

                //Total Salary (Column Index 72)
                DataGridViewTextBoxColumn col40 = new DataGridViewTextBoxColumn();
                col40.HeaderText = "Total Salary";
                col40.Name = "TotalSalary";
                col40.Width = 80;
                col40.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col40.ReadOnly = true;
                col40.DefaultCellStyle.BackColor = Color.LightGray;
                dgvItem.Columns.Add(col40);
            }
        }
        
        private void DynamicProcess()
        {
            oLib = new TELLib();

            int i = 0;
            DateTime _SalaryDate = Convert.ToDateTime(dtSalaryMonth.Value);
            int nYear = _SalaryDate.Year;
            int nMonth = _SalaryDate.Month;
            DateTime _LastDateOfMonth = oLib.LastDayofMonth(_SalaryDate);
            int nLastDay = _LastDateOfMonth.Day;

            DateTime _LastMonth = _SalaryDate.AddMonths(-1);
            int nYear1 = _LastMonth.Year;
            int nMonth1 = _LastMonth.Month;

            //DateTime _OverTimeStartDate = Convert.ToDateTime("16-" + nMonth1.ToString() + "-" + nYear1.ToString());
            //DateTime _OverTimeEndDate = Convert.ToDateTime("15-" + nMonth.ToString() + "-" + nYear.ToString());


            DateTime _OverTimeStartDate = Convert.ToDateTime(sFromDate);
            DateTime _OverTimeEndDate = Convert.ToDateTime(sToDate);


            int nCompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            nTotalData = RowCount();
            pbProgress.Maximum = dgvItem.Rows.Count;
            pbProgress.Value = 0;
            Company _oCompany = new Company();
            int nCustomerID = _oCompany.EPSCustomerID(nCompanyID);

            int nIncrement = 0;
            int nArearMonth = Convert.ToInt32(nudNoOfMonth.Value);
            string sArearMonth = "";
            string sArearYear = "";

            DateTime _CurrentDate = Convert.ToDateTime("1-" + nMonth.ToString() + "-" + nYear.ToString());
            for (int x = 0; x < nArearMonth; x++)
            {
                nIncrement++;
                DateTime _Date = _CurrentDate.AddMonths(- nIncrement);
                if (sArearMonth != "")
                {
                    sArearMonth = sArearMonth + "," + _Date.Month.ToString();
                }
                else 
                {
                    sArearMonth = sArearMonth + _Date.Month.ToString();
                }
                if (sArearYear != "")
                {
                    sArearYear = sArearYear + "," + _Date.Year.ToString();
                }
                else
                {
                    sArearYear = sArearYear + _Date.Year.ToString();
                }
                
            }
            
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                i = i + 1;
                lblProgress.Text = i.ToString() + "/" + nTotalData.ToString();
                lblProgress.Refresh();
                pbProgress.Value = i;

                int nEmployeeID = 0;
                nEmployeeID = Convert.ToInt32(oItemRow.Cells[2].Value);

                _oHRLoan = new HRLoan();
                _oHRLoan.GetLoanByEmployee(nEmployeeID, nMonth, nYear);

                double _OhterSchemeAmount = _oHRLoan.GetOtherLoanByEmployee(nEmployeeID,nCompanyID, nMonth, nYear);

                EPSSalesOrder _oEPSSalesOrder = new EPSSalesOrder();
                double _EPSLoan = _oEPSSalesOrder.GetEPSLoanAmountByEmployee(nEmployeeID, nCustomerID, nMonth, nYear);

                MobileBill _oMobileBill = new MobileBill();
                double _MobileBill = _oMobileBill.GetMobileBill(nMonth1, nYear1, nEmployeeID);

                HROverTime _oHROverTime = new HROverTime();
                //int _OvertimeMinuts = _oHROverTime.GetOverTime(nMonth, nYear, nEmployeeID);
                double _OvertimeAmount = _oHROverTime.GetOverTimeAmount(nEmployeeID,nMonth, nYear);
                

                EmployeeAllowances _oGetBasiclAllow = new EmployeeAllowances();
                _oGetBasiclAllow.GetAllowance();

                EmployeeAllowance _oGetEmplAllow = new EmployeeAllowance();
                _oGetEmplAllow.Refresh(nEmployeeID, nCompanyID, nYear);

                HRPayrollAddDeduct _oHRPayrollAddDeduct = new HRPayrollAddDeduct();
                double _OtherDeduct = _oHRPayrollAddDeduct.GetAmount(nCompanyID, nEmployeeID, nMonth, nYear, (int)Dictionary.AllowanceDeductionType.Deduct, false);
                double _OtherExpense = _oHRPayrollAddDeduct.GetAmount(nCompanyID, nEmployeeID, nMonth, nYear, (int)Dictionary.AllowanceDeductionType.Add, false);
                double _NightShiftAllowance = _oHRPayrollAddDeduct.GetAmount(nCompanyID, nEmployeeID, nMonth, nYear, (int)Dictionary.AllowanceDeductionType.Add, true);

                EmployeeAllowance _oGetAllowGroupItem = new EmployeeAllowance();

                Employee _oEmpl = new Employee();
                _oEmpl.EmployeeID = nEmployeeID;
                _oEmpl.Refresh();

                int nIndex = 3;
                int nGroupID = 1;
                int nItemCount = 0;
                int nCount = 0;
                double _GrossSalary = 0;
                double _TotalDeduction = 0;
                double _NetSalary = 0;
                double _TotalExpese = 0;
                double _TotalSubsidy = 0;
                double _TotalSalary = 0;
                double _Amount = 0;
                double _BasicSalary = 0;
                double _OtherExpenseEmplSetting = 0;

                DateTime _JoiningDate = Convert.ToDateTime(_oEmpl.JoiningDate);

                int nJoiningYear = _JoiningDate.Year;
                int nJoiningMonth = _JoiningDate.Month;
                int nJoiningDay = _JoiningDate.Day;

                int PartialSalaryDay = 0;
                bool IsPartialSalary = false;
                if (nYear == nJoiningYear)
                {
                    if (nMonth == nJoiningMonth)
                    {
                        if (nJoiningDay > 1)
                        {
                            PartialSalaryDay = (nLastDay - nJoiningDay) + 1;
                            IsPartialSalary = true;
                        }
                    }
                }



                foreach (EmployeeAllowance oAllowance in _oGetBasiclAllow)
                {
                    //Set Allowance from Employee Settings
                    _Amount = 0;
                    if (chkFullSalary.Checked == true)
                    {
                        if (oAllowance.ID != (int)Dictionary.HREmployeeAllowance.FestivalBonus && oAllowance.ID != (int)Dictionary.HREmployeeAllowance.LFA)
                        {
                            if (_oEmpl.GradeID == (int)Dictionary.CONGradeID.CON_Officer || _oEmpl.GradeID == (int)Dictionary.CONGradeID.CON_Supervisor || _oEmpl.GradeID == (int)Dictionary.CONGradeID.CON_Staff)
                            {
                                if (oAllowance.ID == (int)Dictionary.HREmployeeAllowance.BasicSalary)
                                {
                                    _BasicSalary = _oGetEmplAllow.GetAllowance(nEmployeeID, oAllowance.ID, nYear, nCompanyID);
                                }
                                else if (oAllowance.ID == (int)Dictionary.HREmployeeAllowance.ConsolidateSalary)
                                {
                                    _Amount = _BasicSalary;
                                    if (IsPartialSalary)
                                    {
                                        _Amount = Math.Round(_Amount / nLastDay * PartialSalaryDay, 0);
                                    }
                                }
                                else
                                {
                                    _Amount = _oGetEmplAllow.GetAllowance(nEmployeeID, oAllowance.ID, nYear, nCompanyID);
                                    if (IsPartialSalary)
                                    {
                                        _Amount = Math.Round(_Amount / nLastDay * PartialSalaryDay, 0);
                                    }
                                }

                            }
                            else
                            {
                                if (oAllowance.ID == (int)Dictionary.HREmployeeAllowance.Otherexpense)
                                {
                                    _OtherExpenseEmplSetting = _oGetEmplAllow.GetAllowance(nEmployeeID, oAllowance.ID, nYear, nCompanyID);
                                    if (IsPartialSalary)
                                    {
                                        _OtherExpenseEmplSetting = Math.Round(_OtherExpenseEmplSetting / nLastDay * PartialSalaryDay, 0);
                                    }
                                }
                                else
                                {
                                    _Amount = _oGetEmplAllow.GetAllowance(nEmployeeID, oAllowance.ID, nYear, nCompanyID);
                                    if (IsPartialSalary)
                                    {
                                        _Amount = Math.Round(_Amount / nLastDay * PartialSalaryDay, 0);
                                    }
                                }
                            }
                        }
                        else
                        {
                            _Amount = 0;
                        }
                    }
                    else
                    {
                        _Amount = 0;
                    }

                    if (chkFestivalBonus.Checked == true)
                    {
                        if (oAllowance.ID == (int)Dictionary.HREmployeeAllowance.FestivalBonus)
                        {
                            _Amount = _oGetEmplAllow.GetAllowance(nEmployeeID, oAllowance.ID, nYear, nCompanyID);
                            _Amount = _Amount * Convert.ToInt32(nudNoOfBonus.Value);

                            //HRLoan _oBountAmount = new HRLoan();
                            //double _BountAmount = _oBountAmount.GetBonusAmount(nEmployeeID, nCompanyID, nMonth, nYear);
                            //Rest Bonus after Builing Loan Adjustment (if any)
                            //_Amount = _Amount - _BountAmount;

                            if (_Amount < 0)
                            {
                                _Amount = 0;
                            }

                        }
                    }

                    if (chkLFA.Checked == true)
                    {
                        if (oAllowance.ID == (int)Dictionary.HREmployeeAllowance.LFA)
                        {
                            _Amount = _oGetEmplAllow.GetAllowance(nEmployeeID, oAllowance.ID, nYear, nCompanyID);
                        }
                    }

                    if (oAllowance.GroupID == nGroupID)
                    {
                        nItemCount = _oGetAllowGroupItem.AllwoanceGroupItem(nGroupID);
                        nGroupID++;
                        nCount = 0;
                    }
                    //Get Allowance without Employee Settings
                    if (chkFullSalary.Checked == true)
                    {
                        if (GetLoanAmount(oAllowance.ID, _oHRLoan, _EPSLoan, _MobileBill, _OvertimeAmount, _oEmpl.EmpStatus, nCompanyID, _OtherDeduct, _OtherExpense, _OtherExpenseEmplSetting, _OhterSchemeAmount, _NightShiftAllowance))
                        {
                            _Amount = _LoanAmount;
                        }
                    }

                    //Arear Calculation
                    if (chkArear.Checked == true)
                    {
                        _Amount = ArearCalculation(nEmployeeID, nCompanyID, oAllowance.ID, nMonth, nYear, nArearMonth, sArearMonth, sArearYear);
                    }

                    //Set Value into Grid
                    nCount++;
                    oItemRow.Cells[nIndex].Value = Convert.ToString(_Amount);
                    nIndex++;
                    oItemRow.Cells[nIndex].Value = Convert.ToString(_Amount);
                    nIndex++;
                    //Generate Subtotal Amount
                    if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.GrossSalary)
                    {
                        _GrossSalary = _GrossSalary + _Amount;
                    }
                    else if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Deduction)
                    {
                        _TotalDeduction = _TotalDeduction + _Amount;
                    }
                    else if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Expense)
                    {
                        _TotalExpese = _TotalExpese + _Amount;
                    }
                    else if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Subsidy)
                    {
                        _TotalSubsidy = _TotalSubsidy + _Amount;
                    }
                    
                    //Sub Total
                    if (nItemCount == nCount)
                    {
                        double _GroupAmount = 0;
                        if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.GrossSalary)
                        {
                            _GroupAmount = _GrossSalary;
                            oItemRow.Cells[nIndex].Value = Convert.ToString(_GroupAmount);
                            nIndex++;
                        }
                        else if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Deduction)
                        {
                            _GroupAmount = _TotalDeduction;
                            oItemRow.Cells[nIndex].Value = Convert.ToString(_GroupAmount);
                            nIndex++;
                            _NetSalary = _GrossSalary - _TotalDeduction;
                            oItemRow.Cells[nIndex].Value = Convert.ToString(_NetSalary);
                            nIndex++;
                        }
                        else if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Expense)
                        {
                            _GroupAmount = _TotalExpese;
                            oItemRow.Cells[nIndex].Value = Convert.ToString(_GroupAmount);
                            nIndex++;
                        }
                        else if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Subsidy)
                        {
                            _GroupAmount = _TotalSubsidy;
                            oItemRow.Cells[nIndex].Value = Convert.ToString(_GroupAmount);
                            nIndex++;

                            _TotalSalary = _NetSalary + _TotalExpese + _TotalSubsidy;
                            oItemRow.Cells[nIndex].Value = Convert.ToString(_TotalSalary);
                            nLastColumnIndex = nIndex++;
                        }

                    }
                }

            }

        }

        private bool GetLoanAmount(int nAllownaceID, HRLoan _oHRLoan, double _EPSLoanAmount, double _MobileBill, double _OvertimeAmount, int nEmpStatus, int nCompanyID, double _OtherDeduct, double _OtherExpense, double _OtherExpenseEmplSetting, double _OhterSchemeAmount, double _NightShiftAllowance)
        {
            if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.ArticleLoanTV)
            {
                _LoanAmount = _oHRLoan.AL_TV;
                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.ArticleLoanRef)
            {
                _LoanAmount = _oHRLoan.AL_Ref;
                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.ArticleLoanAC)
            {
                _LoanAmount = _oHRLoan.AL_AC;
                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.AdvanceSalary)
            {
                _LoanAmount = _oHRLoan.SalaryAdvance;
                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.BuildingLoan)
            {
                //if (_oHRLoan.IsBonus > 0)
                //{
                //    _LoanAmount = _oHRLoan.BuildingLoanInt;
                //}
                //else
                //{
                //    _LoanAmount = _oHRLoan.BuildingLoan;
                //}

                _LoanAmount = _oHRLoan.BuildingLoan;

                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.EmergencyLoan)
            {
                _LoanAmount = _oHRLoan.EmergencyLoan;
                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.PFLoan)
            {
                _LoanAmount = _oHRLoan.PFLoan;
                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.EPSLoan)
            {
                _LoanAmount = _EPSLoanAmount;
                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.CarLoan)
            {
                _LoanAmount = 0;
                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.MobileBill)
            {
                _LoanAmount = _MobileBill;
                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.OverTimeExpense)
            {
                _LoanAmount = _OvertimeAmount;
                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.OtherDeduction)
            {
                _LoanAmount = _OtherDeduct + _OhterSchemeAmount;
                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.Otherexpense)
            {
                _LoanAmount = _OtherExpense + _OtherExpenseEmplSetting;
                return true;
            }
            else if (nAllownaceID == (int)Dictionary.HREmployeeAllowance.NightShiftAllowance)
            {
                _LoanAmount = _NightShiftAllowance;
                return true;
            }
            return false;
        }

        private double ArearCalculation(int nEmployeeID, int nCompanyID, int nAllowanceID, int nMonth, int nYear, int nNoOfArearMonth, string sArearMonth, string sArearYear)
        {
            double _Amount = 0;


            HRPayrollItem _oArearItemValue = new HRPayrollItem();
            _oArearItemValue.GetArearItemValue(nEmployeeID, nCompanyID, nAllowanceID, nMonth, nYear, sArearMonth, sArearYear);

            double _CurrentValue = _oArearItemValue.CurrentAmount * nNoOfArearMonth;
            double _PreviousValue = _oArearItemValue.PreviousAmount;

            _Amount = _CurrentValue - _PreviousValue;

            return _Amount;
        }

        private void LoadCombos()
        {
            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cmbCompany.Items.Add("--Select--");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            //HRLoanType
            cmbType.Items.Add("--Select--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PayrollType)))
            {
                cmbType.Items.Add(Enum.GetName(typeof(Dictionary.PayrollType), GetEnum));
            }
            cmbType.SelectedIndex = 0;
        }

        private void RemoveColumns(int nTotal)
        {
            for (int i = nTotal; i <= nTotal; i--)
            {
                if (i != 2)
                {
                    try
                    {
                        dgvItem.Columns.RemoveAt(i);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    break;
                }
            }
        }
        
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == ItemCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }
       
        public void GetTotalEmployee()
        {
            int nCount = 0;
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    if (oItemRow.Cells[2].Value.ToString().Trim() != "")
                    {
                        
                        try
                        {
                            nCount++;
                        }
                        catch
                        {

                        }
                    }

                }
            }
            
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (ProcessValidate())
            {
                _bFlag = false;
                chkFullSalary.Enabled = false;
                chkFestivalBonus.Enabled = false;
                chkLFA.Enabled = false;
                chkArear.Enabled = false;
                nudNoOfBonus.Enabled = false;
                nudNoOfMonth.Enabled = false;
                dtSalaryMonth.Enabled = false;
                AddColumnsDynamically();
                DynamicProcess();
                _bFlag = true;
                GetColumnIndex();
                GetTotalAmount();
                btnSave.Enabled = true;
                btnProcess.Enabled = false;
            }
        }

        public void ShowDialog(HRPayroll oHRPayroll)
        {
            this.Tag = oHRPayroll;
            oLib = new TELLib();
            nPayrollID = oHRPayroll.PayrollID;
           
            LoadCombos();

            DateTime _Date = Convert.ToDateTime("01-" + oHRPayroll.TMonth + "-" + oHRPayroll.TYear);
            dtSalaryMonth.Value = _Date;
            cmbCompany.SelectedIndex = _oCompanys.GetIndex(oHRPayroll.CompanyID) + 1;
            cmbType.SelectedIndex = oHRPayroll.Type;
            txtDescription.Text = oHRPayroll.Description;

            HRPayrollSettings _oHRPayrollSettings = new HRPayrollSettings();

            _oHRPayrollSettings.Refresh(nPayrollID);

            foreach (HRPayrollSetting oHRPayrollSetting in _oHRPayrollSettings)
            {
                if (oHRPayrollSetting.SettingsID == (int)Dictionary.PayrollSettings.FullSalary)
                {
                    chkFullSalary.Checked = true;
                }
                else if (oHRPayrollSetting.SettingsID == (int)Dictionary.PayrollSettings.FestivalBonus)
                {
                    chkFestivalBonus.Checked = true;
                    nudNoOfBonus.Value = oHRPayrollSetting.SettingsTimes;
                }
                else if (oHRPayrollSetting.SettingsID == (int)Dictionary.PayrollSettings.LFA)
                {
                    chkLFA.Checked = true;
                }
                else if (oHRPayrollSetting.SettingsID == (int)Dictionary.PayrollSettings.AREAR)
                {
                    chkArear.Checked = true;
                    nudNoOfMonth.Value = oHRPayrollSetting.SettingsTimes;
                }
            
            }

            cmbCompany.Enabled = false;
            dtSalaryMonth.Enabled = false;
            cmbType.Enabled = false;
            btnGetEmployee.Enabled = false;
            btnProcess.Enabled = false;
            btnClear.Enabled = false;
            gbSettings.Enabled = false;

            AddColumnsDynamically();

            HRPayroll _oHRPayroll = new HRPayroll();
            _oHRPayroll.PayrollID = oHRPayroll.PayrollID;
            _oHRPayroll.GetEmployeeByPayrollID();

            foreach (HRPayrollItem oHRPayrollItem in _oHRPayroll)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvItem);

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = oHRPayrollItem.EmployeeID;
                oEmployee.Refresh();

                oRow.Cells[0].Value = oEmployee.EmployeeCode;
                oRow.Cells[1].Value = oEmployee.EmployeeName;
                oRow.Cells[2].Value = oEmployee.EmployeeID.ToString();

                _oEmployeeAllownaces = new EmployeeAllowances();
                _oEmployeeAllownaces.GetAllowance();

                int nCellIndex = 3;
                int nGroupID = 0;
                int nGroupID1 = 1;
                double _Amount = 0;
                double _GrossSalary = 0;
                double _Deduction = 0;
                double _Expense = 0;
                double _Subsidy = 0;
                int nCount = 1;
                int nGroupItem = 0;

                foreach (EmployeeAllowance oAllowance in _oEmployeeAllownaces)
                {

                    if (nGroupID != oAllowance.GroupID)
                    {
                        EmployeeAllowance _oAllowance = new EmployeeAllowance();
                        nGroupItem = _oAllowance.AllwoanceGroupItem(oAllowance.GroupID);
                        nGroupItem = nGroupItem + 1;
                        nGroupID++;
                        nCount = 1;
                    }
                    if (nGroupID == oAllowance.GroupID)
                    {
                        nCount++;
                    }

                    HRPayrollItem _oPayrollItem = new HRPayrollItem();
                    _oPayrollItem.RefreshPayrollItem(oHRPayroll.PayrollID, oHRPayrollItem.EmployeeID, oAllowance.ID);

                    _Amount = _oPayrollItem.EditedAmount;

                    oRow.Cells[nCellIndex].Value = _Amount.ToString();
                    nCellIndex++;
                    oRow.Cells[nCellIndex].Value = _oPayrollItem.CalculatedAmount.ToString();
                    nCellIndex++;

                    if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.GrossSalary)
                    {
                        _GrossSalary = _GrossSalary + _Amount;
                    }
                    else if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Deduction)
                    {
                        _Deduction = _Deduction + _Amount;
                    }
                    else if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Expense)
                    {
                        _Expense = _Expense + _Amount;
                    }
                    else if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Subsidy)
                    {
                        _Subsidy = _Subsidy + _Amount;
                    }

                    if (nGroupItem == nCount)
                    {
                        if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.GrossSalary)
                        {
                            oRow.Cells[nCellIndex].Value = _GrossSalary.ToString();
                            nCellIndex++;
                        }
                        else if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Deduction)
                        {
                            oRow.Cells[nCellIndex].Value = _Deduction.ToString();
                            nCellIndex++;
                            oRow.Cells[nCellIndex].Value = (_GrossSalary - _Deduction).ToString();
                            nCellIndex++;
                        }
                        else if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Expense)
                        {
                            oRow.Cells[nCellIndex].Value = _Expense.ToString();
                            nCellIndex++;
                        }
                        else if (oAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Subsidy)
                        {
                            oRow.Cells[nCellIndex].Value = _Subsidy.ToString();
                            nCellIndex++;
                            oRow.Cells[nCellIndex].Value = ((_GrossSalary - _Deduction) + (_Expense + _Subsidy)).ToString();
                            nCellIndex++;
                        }
                    }
                }
                dgvItem.Rows.Add(oRow);
            }
            GetColumnIndex();
            GetTotalAmount();
            _bFlag = true;
            this.ShowDialog();
        }

        private void ResetTotalValue()
        {
            lblGrossSalary.Text = "0.00";
            lblDeduction.Text = "0.00";
            lblNetSalary.Text = "0.00";
            lblExpense.Text = "0.00";
            lblSubsidy.Text = "0.00";
            lblTotalSalary.Text = "0.00";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbCompany.Enabled = true;
            cmbType.Enabled = true;
            dtSalaryMonth.Enabled = true;

            chkFullSalary.Enabled = true;
            chkFullSalary.Checked = false;
            chkFestivalBonus.Enabled = true;
            chkFestivalBonus.Checked = false;
            chkLFA.Enabled = true;
            chkLFA.Checked = false;
            chkArear.Enabled = true;
            chkArear.Checked = false;

            nudNoOfBonus.Enabled = true;
            nudNoOfBonus.Value = 1;
            nudNoOfMonth.Enabled = true;
            nudNoOfMonth.Value = 1;

            btnProcess.Enabled = false;
            btnSave.Enabled = false;

            dgvItem.Rows.Clear();
            dgvItem.Refresh();
            RemoveColumns(_nTotalColumn);
            pbProgress.Value = 0;
            lblProgress.Text = "0/" + Convert.ToString(RowCount());
            this.Text = "HR Payroll | Selected Employee: " + Convert.ToString(RowCount());
            ResetTotalValue();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                this.Cursor = Cursors.WaitCursor;
                Save();
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void Save()
        {
            _oHRPayroll = new HRPayroll();
            _oHRPayroll = GetData(_oHRPayroll);

            DBController.Instance.OpenNewConnection();

            try
            {
                DBController.Instance.BeginNewTransaction();
                
                if (this.Tag == null)
                {
                    _oHRPayroll.Add(true);
                    InsertSetting(_oHRPayroll.PayrollID);
                    HRPayroll _TotalEmployee = new HRPayroll();
                    _oHRPayroll.EditNoOfEmployee(_oHRPayroll.GetTotalEmployeeByPayrollID());

                }
                else
                {
                    _oHRPayroll.PayrollID = nPayrollID;
                    _oHRPayroll.Status = (int)Dictionary.PayrollStatus.Create;
                    _oHRPayroll.Edit();
                    _oHRPayroll.DeleteItem();
                    _oHRPayroll.Add(false);
                    HRPayroll _TotalEmployee = new HRPayroll();
                    _oHRPayroll.EditNoOfEmployee(_oHRPayroll.GetTotalEmployeeByPayrollID());
                }

                DBController.Instance.CommitTran();

                MessageBox.Show("Data Save Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error Saving Data:\n" + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validateUIInput()
        {
            int nRowCount = 0;
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    nRowCount++;
                    break;
                }
            }
            if (nRowCount == 0)
            {
                MessageBox.Show("Please Get at least an Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            double _Value = 0;
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    _Value = _Value + Convert.ToDouble(oItemRow.Cells[nLastColumnIndex].Value);
                }
            }
            if (_Value == 0)
            {
                MessageBox.Show("There is no value to process data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            string sEmployeeList = "";
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    if (sEmployeeList == "")
                    {
                        sEmployeeList = oItemRow.Cells[2].Value.ToString();
                    }
                    else
                    {
                        sEmployeeList = sEmployeeList + ',' + oItemRow.Cells[2].Value.ToString();
                    }
                }
            }

            //HRAttendInfo oAbsentList = new HRAttendInfo();
            //int _NoOfAbsentEmployee = oAbsentList.GetNoOfAbsent(sFromDate, sToDate, sEmployeeList);
            //if (_NoOfAbsentEmployee != 0)
            //{
            //    MessageBox.Show("The attendance report shows "+ _NoOfAbsentEmployee + " employees are absent.\n Necessary steps need to be taken for absent employees before processing the salary", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}

            return true;
        }

        private bool DataGetValidate()
        {
            int nSettingCount = 0;
            int nRowCount = 0;
            if (cmbCompany.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCompany.Focus();
                return false;
            }
            if (cmbType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbType.Focus();
                return false;
            }

            return true;
        }

        private bool ProcessValidate()
        {
            int nSettingCount = 0;
     
            if (chkFullSalary.Checked == true)
            {
                nSettingCount++;
            }
            if (chkFestivalBonus.Checked == true)
            {
                nSettingCount++;
            }
            if (chkLFA.Checked == true)
            {
                nSettingCount++;
            }
            if (chkArear.Checked == true)
            {
                nSettingCount++;
            }

            if (nSettingCount == 0)
            {
                MessageBox.Show("Please checked at least one event from settings", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private HRPayroll GetData(HRPayroll _oHRPayroll)
        {
            HRPayrollItem _oHRPayrollItem;
            DateTime _Date = Convert.ToDateTime(dtSalaryMonth.Value);
            int nMonth = _Date.Month;
            int nYear = _Date.Year;
            int nIndex = 0;
            int nItemCount = 0;
            int nGroupID = 1;
            int nCount = 0;
            int nCount1 = 0;
            int nEmployeeID = 0;

            _oHRPayroll.CompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            string _CompanyCode = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyCode;
            _oHRPayroll.TMonth = nMonth;
            _oHRPayroll.TYear = nYear;
            _oHRPayroll.Status = (int)Dictionary.PayrollStatus.Create;
            _oHRPayroll.Type = cmbType.SelectedIndex;
            _oHRPayroll.Description = txtDescription.Text.Trim();
            _oHRPayroll.NoOfEmpl = RowCount();
            _oHRPayroll.GrossSalary = Convert.ToDouble(lblGrossSalary.Text);
            _oHRPayroll.Deduct = Convert.ToDouble(lblDeduction.Text);
            _oHRPayroll.NetSalary = Convert.ToDouble(lblNetSalary.Text);
            _oHRPayroll.Expense = Convert.ToDouble(lblExpense.Text);
            _oHRPayroll.Subsidy = Convert.ToDouble(lblSubsidy.Text);
            _oHRPayroll.TotalSalary = Convert.ToDouble(lblTotalSalary.Text);

            _oHRPayroll.CreateUserID = Utility.UserId;
            _oHRPayroll.CreateDate = DateTime.Now;
            _oHRPayroll.UpdateUserID = Utility.UserId;
            _oHRPayroll.UpdateDate = DateTime.Now;

            HRPayroll oPayroll = new HRPayroll();
            int nLastNumber = oPayroll.PayrollCount(_oHRPayroll.CompanyID, nMonth, nYear);
            nLastNumber = nLastNumber + 1;
            string _sYear = _Date.ToString("yy");
            string _sMonth = _Date.ToString("MM");

            _oHRPayroll.Code = _CompanyCode + "-" + _sYear + _sMonth + "-" + nLastNumber.ToString("00");

            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    nCount1 = 0;
                    nIndex = 2;
                    nGroupID = 1;
                    EmployeeAllowances _oGetBasiclAllow = new EmployeeAllowances();
                    _oGetBasiclAllow.GetAllowance();
                    EmployeeAllowance _oGetAllowGroupItem = new EmployeeAllowance();
                    foreach (EmployeeAllowance oEmployeeAllowance in _oGetBasiclAllow)
                    {
                        _oHRPayrollItem = new HRPayrollItem();
                        if (nCount1 == 0)
                        {
                            nEmployeeID = int.Parse(oItemRow.Cells[2].Value.ToString().Trim());
                            nCount1++;
                        }
                        _oHRPayrollItem.EmployeeID = nEmployeeID;
                        _oHRPayrollItem.ItemID = oEmployeeAllowance.ID;
                        nIndex++;
                        try
                        {
                            _oHRPayrollItem.EditedAmount = Math.Round(Convert.ToDouble(oItemRow.Cells[nIndex].Value.ToString().Trim()), 0);
                                //_oHRPayrollItem.EditedAmount = int.Parse(oItemRow.Cells[nIndex].Value.ToString().Trim());
                        }
                        catch
                        {
                            _oHRPayrollItem.EditedAmount = 0;
                        }
                        nIndex++;
                        try
                        {
                            _oHRPayrollItem.CalculatedAmount = int.Parse(oItemRow.Cells[nIndex].Value.ToString().Trim());
                        }
                        catch
                        {
                            _oHRPayrollItem.CalculatedAmount = 0;
                        }

                        if (_oHRPayrollItem.CalculatedAmount + _oHRPayrollItem.EditedAmount != 0)
                        {
                            _oHRPayroll.Add(_oHRPayrollItem);
                        }

                        if (oEmployeeAllowance.GroupID == nGroupID)
                        {
                            nItemCount = _oGetAllowGroupItem.AllwoanceGroupItem(nGroupID);
                            nGroupID++;
                            nCount = 0;
                        }
                        nCount++;
                        if (nItemCount == nCount)
                        {
                            if (oEmployeeAllowance.GroupID == (int)Dictionary.AllowanceGroupType.GrossSalary)
                            {
                                nIndex++;
                            }
                            else if (oEmployeeAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Deduction)
                            {
                                nIndex++;
                                nIndex++;
                            }
                            else if (oEmployeeAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Expense)
                            {
                                nIndex++;
                            }
                            else if (oEmployeeAllowance.GroupID == (int)Dictionary.AllowanceGroupType.Subsidy)
                            {
                                nIndex++;
                                nIndex++;
                            }
                        }
                    }
                }
            }

            return _oHRPayroll;

        }

        private void InsertSetting(int nPayrollID)
        {
            HRPayrollSetting oHRPayrollSetting = new HRPayrollSetting();
            oHRPayrollSetting.PayrollID = nPayrollID;
            if (chkFullSalary.Checked == true)
            {
                oHRPayrollSetting.SettingsID = (int)Dictionary.PayrollSettings.FullSalary;
                oHRPayrollSetting.SettingsTimes = 0;
                oHRPayrollSetting.Add();
            }
            if (chkFestivalBonus.Checked == true)
            {
                oHRPayrollSetting.SettingsID = (int)Dictionary.PayrollSettings.FestivalBonus;
                oHRPayrollSetting.SettingsTimes = Convert.ToInt32(nudNoOfBonus.Value);
                oHRPayrollSetting.Add();
            }
            if (chkLFA.Checked == true)
            {
                oHRPayrollSetting.SettingsID = (int)Dictionary.PayrollSettings.LFA;
                oHRPayrollSetting.SettingsTimes = 0;
                oHRPayrollSetting.Add();
            }
            if (chkArear.Checked == true)
            {
                oHRPayrollSetting.SettingsID = (int)Dictionary.PayrollSettings.AREAR;
                oHRPayrollSetting.SettingsTimes = Convert.ToInt32(nudNoOfMonth.Value);
                oHRPayrollSetting.Add();
            }   
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayroll_Load(object sender, EventArgs e)
        {
            this.Text = "HR Payroll | Selected Employee: " + Convert.ToString(RowCount());


            DateTime LastMonth = dtSalaryMonth.Value.AddMonths(-1);
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string sMonthName = mfi.GetMonthName(dtSalaryMonth.Value.Month).ToString();
            string sLastMonth = mfi.GetMonthName(LastMonth.Month).ToString();
            sFromDate = "16-" + sLastMonth + "-" + LastMonth.Year + "";
            sToDate = "15-" + sMonthName + "-" + dtSalaryMonth.Value.Year + "";


            if (this.Tag == null)
            {
                btnSave.Enabled = false;
                btnProcess.Enabled = false;
                LoadCombos();
                ResetTotalValue();

                int nYear = DateTime.Today.Year;
                int nMonth = DateTime.Today.Month;
                DateTime _date = Convert.ToDateTime(nYear.ToString() + "-" + nMonth.ToString() + "-01");
                dtSalaryMonth.Value = _date;
            }

        }

        private void dgvItem_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.Text = "HR Payroll | Selected Employee: " + Convert.ToString(RowCount());
            lblProgress.Text = "0/" + Convert.ToString(RowCount());
            GetTotalAmount();
        }

        private int RowCount()
        {
            int nCount = 0;
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    nCount++;
                }
            }
            return nCount;
        }

        private void dgvItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_bFlag == true)
            {
                if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            int nColIndex = 3;
            int nTotal = 0;
            double _GrossTotal = 0;
            double _DeductionTotal = 0;
            double _NetSalary = 0;
            double _ExpenseTotal = 0;
            double _SubsidyTotal = 0;


            _oEmployeeAllownace = new EmployeeAllowance();
            //Gross Salary
            nTotal = _oEmployeeAllownace.AllwoanceGroupItem((int)Dictionary.AllowanceGroupType.GrossSalary);
            for (int i = 0; i < nTotal; i++)
            {
                double temp = 0;
                try
                {
                    temp = Convert.ToDouble(dgvItem.Rows[nRowIndex].Cells[nColIndex].Value.ToString());
                }
                catch
                {
                    temp = 0;
                }

                _GrossTotal = _GrossTotal + temp;
                nColIndex++;
                nColIndex++;
            }
            dgvItem.Rows[nRowIndex].Cells[indexGrossSalary].Value = _GrossTotal.ToString();
            
            //Deduction
            nTotal = _oEmployeeAllownace.AllwoanceGroupItem((int)Dictionary.AllowanceGroupType.Deduction);
            nColIndex++;
            for (int i = 0; i < nTotal; i++)
            {
                double temp = 0;
                try
                {
                    temp = Convert.ToDouble(dgvItem.Rows[nRowIndex].Cells[nColIndex].Value.ToString());
                }
                catch
                {
                    temp = 0;
                }

                _DeductionTotal = _DeductionTotal + temp;
                nColIndex++;
                nColIndex++;
            }
            dgvItem.Rows[nRowIndex].Cells[indexTotalDeduction].Value = _DeductionTotal.ToString();
            _NetSalary = _GrossTotal - _DeductionTotal;
            dgvItem.Rows[nRowIndex].Cells[indexNetSalary].Value = Convert.ToString(Convert.ToDouble(_NetSalary));

            //Total Expense
            nTotal = _oEmployeeAllownace.AllwoanceGroupItem((int)Dictionary.AllowanceGroupType.Expense);
            nColIndex++;
            nColIndex++;
            for (int i = 0; i < nTotal; i++)
            {
                double temp = 0;
                try
                {
                    temp = Convert.ToDouble(dgvItem.Rows[nRowIndex].Cells[nColIndex].Value.ToString());
                }
                catch
                {
                    temp = 0;
                }

                _ExpenseTotal = _ExpenseTotal + temp;
                nColIndex++;
                nColIndex++;
            }
            dgvItem.Rows[nRowIndex].Cells[indexTotalExpense].Value = _ExpenseTotal.ToString();

            //Total Subsidy
            nTotal = _oEmployeeAllownace.AllwoanceGroupItem((int)Dictionary.AllowanceGroupType.Subsidy);
            nColIndex++;
            for (int i = 0; i < nTotal; i++)
            {
                double temp = 0;
                try
                {
                    temp = Convert.ToDouble(dgvItem.Rows[nRowIndex].Cells[nColIndex].Value.ToString());
                }
                catch
                {
                    temp = 0;
                }

                _SubsidyTotal = _SubsidyTotal + temp;
                nColIndex++;
                nColIndex++;
            }
            dgvItem.Rows[nRowIndex].Cells[indexTotalSubsidy].Value = _SubsidyTotal.ToString();
            dgvItem.Rows[nRowIndex].Cells[indexTotalSalary].Value = Convert.ToString(Convert.ToDouble(_NetSalary) + Convert.ToDouble(_ExpenseTotal) + Convert.ToDouble(_SubsidyTotal));
            
            GetTotalAmount();
        }

        public void GetTotalAmount()
        {
            lblGrossSalary.Text = "0.00";
            lblDeduction.Text = "0.00";
            lblNetSalary.Text = "0.00";
            lblExpense.Text = "0.00";
            lblSubsidy.Text = "0.00";
            lblTotalSalary.Text = "0.00";

            double _GrossTotal = 0;
            double _Deduction = 0;
            double _NetSalary = 0;
            double _Expense = 0;
            double _Subsidy = 0;

            oLib = new TELLib();
            int nCount = 0;


            foreach (DataGridViewRow oRow in dgvItem.Rows)
            {
                try
                {

                    

                    
                        //NetSalary
                    
                        
                    //TotalSalary
                    //_GrossTotal = _GrossTotal + Convert.ToDouble(oRow.Cells[35].Value.ToString());
                    //_Deduction = _Deduction + Convert.ToDouble(oRow.Cells[52].Value.ToString());
                    //_Expense = _Expense + Convert.ToDouble(oRow.Cells[72].Value.ToString());
                    //_Subsidy = _Subsidy + Convert.ToDouble(oRow.Cells[77].Value.ToString());

                    _GrossTotal = _GrossTotal + Convert.ToDouble(oRow.Cells[indexGrossSalary].Value.ToString());
                    _Deduction = _Deduction + Convert.ToDouble(oRow.Cells[indexTotalDeduction].Value.ToString());
                    _Expense = _Expense + Convert.ToDouble(oRow.Cells[indexTotalExpense].Value.ToString());
                    _Subsidy = _Subsidy + Convert.ToDouble(oRow.Cells[indexTotalSubsidy].Value.ToString());

                }
                catch
                { 
                
                }
            }

            lblGrossSalary.Text = oLib.TakaFormat(_GrossTotal);
            lblDeduction.Text = oLib.TakaFormat(_Deduction);
            _NetSalary = _GrossTotal - _Deduction;
            lblNetSalary.Text = oLib.TakaFormat(_NetSalary);
            lblExpense.Text = oLib.TakaFormat(_Expense);
            lblSubsidy.Text = oLib.TakaFormat(_Subsidy);
            lblTotalSalary.Text = oLib.TakaFormat(_NetSalary + _Expense + _Subsidy);
           
        }

        private void GetColumnIndex()
        {
            indexGrossSalary = dgvItem.Columns["GrossSalary"].Index;
            indexTotalDeduction = dgvItem.Columns["TotalDeduction"].Index;
            indexNetSalary = dgvItem.Columns["NetSalary"].Index;
            indexTotalExpense = dgvItem.Columns["TotalExpense"].Index;
            indexTotalSubsidy = dgvItem.Columns["TotalSubsidy"].Index;
            indexTotalSalary = dgvItem.Columns["TotalSalary"].Index;
        }

        private void chkFullSalary_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFullSalary.Checked == true)
            {
                chkArear.Checked = false;
                chkArear.Enabled = false;
                lblLast.Enabled = false;
                lblMonths.Enabled = false;
                nudNoOfMonth.Enabled = false;
            }
            else
            {
                if (chkFestivalBonus.Checked == false && chkLFA.Checked == false)
                {
                    chkArear.Enabled = true;
                    lblLast.Enabled = true;
                    lblMonths.Enabled = true;
                    nudNoOfMonth.Enabled = true;
                }
            }
        }

        private void chkFestivalBonus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFestivalBonus.Checked == true)
            {
                chkArear.Checked = false;
                chkArear.Enabled = false;
                lblLast.Enabled = false;
                lblMonths.Enabled = false;
                nudNoOfMonth.Enabled = false;
            }
            else
            {
                if (chkFullSalary.Checked == false && chkLFA.Checked == false)
                {
                    chkArear.Enabled = true;
                    lblLast.Enabled = true;
                    lblMonths.Enabled = true;
                    nudNoOfMonth.Enabled = true;
                }
            }
        }

        private void chkLFA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLFA.Checked == true)
            {
                chkArear.Checked = false;
                chkArear.Enabled = false;
                lblLast.Enabled = false;
                lblMonths.Enabled = false;
                nudNoOfMonth.Enabled = false;
            }
            else
            {
                if (chkFullSalary.Checked == false && chkFestivalBonus.Checked == false)
                {
                    chkArear.Enabled = true;
                    lblLast.Enabled = true;
                    lblMonths.Enabled = true;
                    nudNoOfMonth.Enabled = true;
                }
            }
        }

        private void chkArear_CheckedChanged(object sender, EventArgs e)
        {
            if (chkArear.Checked == true)
            {
                chkFullSalary.Checked = false;
                chkFullSalary.Enabled = false;
                chkFestivalBonus.Checked = false;
                chkFestivalBonus.Enabled = false;
                chkLFA.Checked = false;
                chkLFA.Enabled = false;
                nudNoOfBonus.Enabled = false;
            }
            else
            {
                chkFullSalary.Enabled = true;
                chkFestivalBonus.Enabled = true;
                chkLFA.Enabled = true;
                nudNoOfBonus.Enabled = true;
            }
        }

        private void SelectRow()
        {
            string _sSearchValue = txtCode.Text.Trim();
            int rowIndex = -1;
            foreach (DataGridViewRow row in dgvItem.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(_sSearchValue))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            if (rowIndex >= 0)
            {
                dgvItem.CurrentCell = dgvItem[0, rowIndex];
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            SelectRow();
        }

        private void btnAbsentList_Click(object sender, EventArgs e)
        {

            string sEmployeeList = "";
            foreach (DataGridViewRow oItemRow in dgvItem.Rows)
            {
                if (oItemRow.Index < dgvItem.Rows.Count)
                {
                    if (sEmployeeList == "")
                    {
                        sEmployeeList = oItemRow.Cells[2].Value.ToString();
                    }
                    else
                    {
                        sEmployeeList = sEmployeeList + ',' + oItemRow.Cells[2].Value.ToString();
                    }
                }
            }
            if (sEmployeeList != "")
            {
                frmAbsentList ofrmAbsentList = new frmAbsentList(sFromDate, sToDate, sEmployeeList);
                ofrmAbsentList.ShowDialog();
            }
        }
    }
}
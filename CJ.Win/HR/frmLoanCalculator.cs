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
using CJ.Class.Library;


namespace CJ.Win.HR
{
    public partial class frmLoanCalculator : Form
    {
        LoanCalculators _oLoanCalculators;
        HRLoan _oHRLoan;
        TELLib oTELLib; 

        public frmLoanCalculator()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Process();
            }
        }
        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtPV.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Principle Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPV.Focus();
                return false;
            }
            else
            {
                try
                {
                    double temp = Convert.ToDouble(txtPV.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter Valid Principle Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPV.Focus();
                    return false;
                }
            }
            if (txtInstallmentNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Installment No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInstallmentNo.Focus();
                return false;
            }
            else
            {
                try
                {
                    double temp = Convert.ToInt32(txtInstallmentNo.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter Valid Installment No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInstallmentNo.Focus();
                    return false;
                }
            }
            if (txtInteresrRate.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Interest Rate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInteresrRate.Focus();
                return false;
            }
            else
            {
                try
                {
                    double temp = Convert.ToDouble(txtInteresrRate.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter Valid Interest Rate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInteresrRate.Focus();
                    return false;
                }
            }
            if (chkBonusAdjust.Checked == true)
            {
                if (txtBasicSalary.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter Basic salary", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBasicSalary.Focus();
                    return false;
                }
                else
                {
                    try
                    {
                        double temp = Convert.ToDouble(txtBasicSalary.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Please enter Valid Basic salary", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtBasicSalary.Focus();
                        return false;
                    }
                }
            }
            #endregion

            return true;
        }
        private void Process()
        {
            double NPer = 0;
            double PV = 0;
            double Rate = 0;
            double _BasicSalary = 0;
            bool IsPFLoan = false;
            DateTime dtDate = DateTime.Today;
            dgvEMI.Rows.Clear();

            NPer = Convert.ToDouble(txtInstallmentNo.Text);
            PV = Convert.ToDouble(txtPV.Text);
            Rate = Convert.ToDouble(txtInteresrRate.Text);
            _BasicSalary = Convert.ToDouble(txtBasicSalary.Text);


            if (dtStartDate.Value.Day > 15)
                dtDate = dtStartDate.Value.Date.AddMonths(1);
            else dtDate = dtStartDate.Value.Date;

            _oLoanCalculators = new LoanCalculators();
            if (chkIsPFLoan.Checked == true)
            {
                IsPFLoan = true;
            }
            _oLoanCalculators.CalculateResult(Rate, NPer, PV, dtDate, chkBonusAdjust.Checked, _BasicSalary, IsPFLoan);

            int i = 0;
            foreach (LoanCalculator oLoanCalculator in _oLoanCalculators)
            {
                dgvEMI.Rows.Add();
                dgvEMI[0, i].Value = oLoanCalculator.InstallmentNo;
                dgvEMI[1, i].Value = oLoanCalculator.BalancePrincipal;
                dgvEMI[2, i].Value = oLoanCalculator.PrincipalPayable;
                dgvEMI[3, i].Value = oLoanCalculator.InterestPayable;
                dgvEMI[4, i].Value = oLoanCalculator.ClosingBalance;
                dgvEMI[5, i].Value = Convert.ToDateTime(oLoanCalculator.PaymentDate).ToString("dd-MMM-yyyy");
                i++;
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            PrintEMI();

            this.Cursor = Cursors.Default;
        }

        public void PrintEMI()
        {
            _oHRLoan = new HRLoan();

            foreach (DataGridViewRow oItemRow in dgvEMI.Rows)
            {
                if (oItemRow.Index < dgvEMI.Rows.Count - 1)
                {
                    HRLoanDetail oHRLoanDetail = new HRLoanDetail();

                    oHRLoanDetail.InstallmentNo = int.Parse(oItemRow.Cells[0].Value.ToString());
                    oHRLoanDetail.BalancePrincipal = Convert.ToDouble(oItemRow.Cells[1].Value);
                    oHRLoanDetail.PrincipalPayable = Convert.ToDouble(oItemRow.Cells[2].Value);
                    oHRLoanDetail.InterestPayable = Convert.ToDouble(oItemRow.Cells[3].Value);
                    oHRLoanDetail.TotalPayable = Convert.ToDouble(oItemRow.Cells[4].Value);
                    oHRLoanDetail.PaymentDate = Convert.ToDateTime(oItemRow.Cells[5].Value);
                    oHRLoanDetail.EMIStatusName = "N/A";
                    _oHRLoan.Add(oHRLoanDetail);
                }
            }


            oTELLib = new TELLib();

            rptLoanEMIPrint doc = new rptLoanEMIPrint();

            doc.SetDataSource(_oHRLoan);

            doc.SetParameterValue("CompanyName", "Unknown Company");
            doc.SetParameterValue("EmployeeCode", "N/A");
            doc.SetParameterValue("EmployeeName", "N/A");
            doc.SetParameterValue("Designation", "N/A");
            doc.SetParameterValue("Designation", "N/A");
            doc.SetParameterValue("Department", "N/A");

            doc.SetParameterValue("LoanType", "N/A");

            doc.SetParameterValue("LoanSubType", "N/A");
            doc.SetParameterValue("LoanStatus", "N/A");
            doc.SetParameterValue("LoanNo", "N/A");
            doc.SetParameterValue("DisburseDate", Convert.ToDateTime(dtStartDate.Value).ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("AllocatedAmount", oTELLib.TakaFormat(Convert.ToDouble(txtPV.Text)));
            doc.SetParameterValue("Downpayment", oTELLib.TakaFormat(Convert.ToDouble("0")));
            doc.SetParameterValue("InterestRate", oTELLib.TakaFormat(Convert.ToDouble(txtInteresrRate.Text)) + "%");
            doc.SetParameterValue("NoOfInstallment", txtInstallmentNo.Text);
            doc.SetParameterValue("User Name", Utility.Username);


            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(doc);
            //doc.PrintToPrinter(1, true, 1, 1);
        }
    }
}
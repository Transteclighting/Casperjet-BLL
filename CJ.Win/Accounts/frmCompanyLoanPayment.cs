using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.Win.Accounts
{
    public partial class frmCompanyLoanPayment : Form
    {
        CompanyLoan _oCompanyLoan;
        CompanyLoanHistory _oCompanyLoanHistory;
        CompanyLoanInterest _oCompanyLoanInterest;

        public frmCompanyLoanPayment()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void Save()
        {
            _oCompanyLoanHistory = new CompanyLoanHistory();

            _oCompanyLoanHistory.LoanID = _oCompanyLoan.ID;
            _oCompanyLoanHistory.TranDate = Convert.ToDateTime(dtPaymentDate.Value.Date);
            _oCompanyLoanHistory.TranType = (int)Dictionary.CompanyLoanTranType.Payment;
            _oCompanyLoanHistory.TranSide = (int)Dictionary.TranSide.OUT;
            _oCompanyLoanHistory.Amount = Convert.ToDouble(txtPayment.Text);
            _oCompanyLoanHistory.CreateUserID = Utility.UserId;
            _oCompanyLoanHistory.CreateDate = dtPaymentDate.Value;

            try
            {
                object _LastPaymentDate = _oCompanyLoan.GetLastPaymentDate();
                if (_LastPaymentDate != null)
                {
                    if (Convert.ToDateTime(_LastPaymentDate).Date > _oCompanyLoanHistory.TranDate)
                    {
                        MessageBox.Show("Payment Date Must be Greater or Equal Last Payment Date", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                DBController.Instance.BeginNewTransaction();
                _oCompanyLoanHistory.Add();

                // Last payment date must less then or equal current payment
                

                //Insert Interest
                _oCompanyLoanInterest = new CompanyLoanInterest();
                _oCompanyLoanInterest.LoanID = _oCompanyLoan.ID;
                if (_oCompanyLoanInterest.GetLastDataByLoanID())
                {
                    _oCompanyLoanInterest.FromDate = _oCompanyLoanInterest.ToDate.AddDays(1);
                }
                else
                {
                    _oCompanyLoanInterest.FromDate = _oCompanyLoan.ReceiveDate;
                }
                _oCompanyLoanInterest.ToDate = _oCompanyLoanHistory.TranDate;
                _oCompanyLoanInterest.Days = (_oCompanyLoanInterest.ToDate - _oCompanyLoanInterest.FromDate).Days;
                _oCompanyLoanInterest.InterestOnPrincipal = _oCompanyLoan.PayablePrincipal;
                _oCompanyLoanInterest.Interest = Math.Round((_oCompanyLoan.PayablePrincipal * _oCompanyLoan.CurrentInterestRate / 100) / 360 * _oCompanyLoanInterest.Days, 0);
                _oCompanyLoanInterest.InterestRate = _oCompanyLoan.CurrentInterestRate;
                _oCompanyLoanInterest.CreateUserID = Utility.UserId;
                _oCompanyLoanInterest.CreateDate = DateTime.Now;
                _oCompanyLoanInterest.Add();

                // Interest Add for History
                _oCompanyLoanHistory.TranType = (int)Dictionary.CompanyLoanTranType.Interest;
                _oCompanyLoanHistory.TranSide = (int)Dictionary.TranSide.IN;
                _oCompanyLoanHistory.Amount = _oCompanyLoanInterest.Interest;
                _oCompanyLoanHistory.Add();

                //Update Payment
                
                _oCompanyLoan.PayablePrincipal = Convert.ToDouble(txtPayment.Text); 
                _oCompanyLoan.LastPaymentDate = _oCompanyLoanHistory.TranDate;
                _oCompanyLoan.PayableInterest = _oCompanyLoanInterest.Interest;
                _oCompanyLoan.TotalPayment = Convert.ToDouble(txtPayment.Text);

                _oCompanyLoan.UpdatePayment();

                DBController.Instance.CommitTran();
                MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void frmCompanyLoanPayment_Load(object sender, EventArgs e)
        {

        }

        public void ShowDialog(CompanyLoan oCompanyLoan)
        {
            this.Tag = oCompanyLoan;
            _oCompanyLoan = oCompanyLoan;
            lblLoanNumber.Text = oCompanyLoan.LoanNumber;
            lblLoanAmount.Text = oCompanyLoan.BDTAmount.ToString();
            lblPrincipalPayable.Text = oCompanyLoan.PayablePrincipal.ToString();
            lblInterestPayable.Text = oCompanyLoan.PayableInterest.ToString();
            this.ShowDialog();
        }
    }
}

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
    public partial class frmCompanyLoanQuarterEnd : Form
    {
        CompanyLoans _oCompanyLoans;
        CompanyLoanInterest _oCompanyLoanInterest;
        CompanyLoanHistory _oCompanyLoanHistory;
        CompanyLoanQuarterEnd _oCompanyLoanQuarterEnd;
        public frmCompanyLoanQuarterEnd()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Process();
        }

        private void Process()
        {
            try
            {
                _oCompanyLoans = new CompanyLoans();
                _oCompanyLoans.GetQuarterEndEligibleData();

                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                DBController.Instance.BeginNewTransaction();
                foreach (CompanyLoan _oCompanyLoan in _oCompanyLoans)
                {

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
                    _oCompanyLoanInterest.ToDate = Convert.ToDateTime(dtQuarterEndDate.Value);
                    _oCompanyLoanInterest.Days = (_oCompanyLoanInterest.ToDate - _oCompanyLoanInterest.FromDate).Days;
                    _oCompanyLoanInterest.InterestOnPrincipal = _oCompanyLoan.PayablePrincipal;
                    _oCompanyLoanInterest.Interest = Math.Round((_oCompanyLoan.PayablePrincipal * _oCompanyLoan.CurrentInterestRate / 100) / 360 * _oCompanyLoanInterest.Days,0);
                    _oCompanyLoanInterest.InterestRate = _oCompanyLoan.CurrentInterestRate;
                    _oCompanyLoanInterest.CreateUserID = Utility.UserId;
                    _oCompanyLoanInterest.CreateDate = DateTime.Now;
                    _oCompanyLoanInterest.Add();

                    // Interest Add for History

                    _oCompanyLoanHistory = new CompanyLoanHistory();
                    _oCompanyLoanHistory.LoanID = _oCompanyLoan.ID;
                    _oCompanyLoanHistory.TranDate = Convert.ToDateTime(dtQuarterEndDate.Value.Date);
                    _oCompanyLoanHistory.TranType = (int)Dictionary.CompanyLoanTranType.QuarterEnd;
                    _oCompanyLoanHistory.TranSide = (int)Dictionary.TranSide.IN;
                    _oCompanyLoanHistory.Amount = _oCompanyLoanInterest.Interest;
                    _oCompanyLoanHistory.CreateUserID = Utility.UserId;
                    _oCompanyLoanHistory.CreateDate = DateTime.Now;
                    _oCompanyLoanHistory.Add();

                    //Update Payment

                    _oCompanyLoan.PayablePrincipal = _oCompanyLoan.PayableInterest + _oCompanyLoanInterest.Interest;
                    _oCompanyLoan.LastQuarterEndDate = Convert.ToDateTime(dtQuarterEndDate.Value.Date);
                    _oCompanyLoan.PayableInterest = 0;

                    _oCompanyLoan.UpdateQuarterEndHeader();

                }

                _oCompanyLoanQuarterEnd = new CompanyLoanQuarterEnd();
                _oCompanyLoanQuarterEnd.QuarterEndDate = Convert.ToDateTime(dtQuarterEndDate.Value.Date);
                _oCompanyLoanQuarterEnd.NoOfLoanEffect = _oCompanyLoans.Count;
                _oCompanyLoanQuarterEnd.CreateUserID = Utility.UserId;
                _oCompanyLoanQuarterEnd.CreateDate = DateTime.Now;
                _oCompanyLoanQuarterEnd.Add();

                DBController.Instance.CommitTran();
                MessageBox.Show("Quarter End Successfully..\n No. of Loan Effect: "+ _oCompanyLoans.Count.ToString() + "", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
                throw (ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

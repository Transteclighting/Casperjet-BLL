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
    public partial class frmCompanyLoanNumber : Form
    {
        CompanyLoan _oCompanyLoan;
        int _nLoanID = 0;
        string _sLoanNumber = "";
        public frmCompanyLoanNumber(int nLoanID, string sLoanNumber)
        {
            _nLoanID = nLoanID;
            _sLoanNumber = sLoanNumber;
            InitializeComponent();
            txtLoanNumber.Text = _sLoanNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                
            }
        }

        private bool UIValidation()
        {
            if (txtLoanNumber.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Loan Number", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void Save()
        {
            try
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                _oCompanyLoan = new CompanyLoan();
                _oCompanyLoan.ID = _nLoanID;
                _oCompanyLoan.LoanNumber = txtLoanNumber.Text.Trim();
                if (!_oCompanyLoan.CheckLoanNumber())
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCompanyLoan.UpdateLoanNumber();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Loan Number Updated Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Duplicate Loan Number!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

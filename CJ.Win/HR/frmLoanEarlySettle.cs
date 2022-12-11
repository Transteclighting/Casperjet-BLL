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
    public partial class frmLoanEarlySettle : Form
    {
        TELLib _oTELLib;
        int nLoanID = 0;
        HRLoan _oHRLoan;
        public bool IsExecute;
        public frmLoanEarlySettle()
        {
            InitializeComponent();
        }

        public void ShowDialog(HRLoan oHRLoan)
        {
            this.Tag = oHRLoan;
            nLoanID = oHRLoan.LoanID;
            _oTELLib = new TELLib();
            double _PrincipalAmount = 0;
            double _InterestAmount = 0;

            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = oHRLoan.EmployeeID;
            oEmployee.RefreshDetail();

            lblEmployeeNo.Text = oHRLoan.EmployeeCode;
            lblEmployeeName.Text = oHRLoan.EmployeeName;
            lblDesignation.Text = oEmployee.DesignationName;
            lblDepartment.Text = oEmployee.DepartmentName;
            lblCompany.Text = oEmployee.ComapanyName;

            lblLoanNo.Text = oHRLoan.LoanNo;
            string sLoanType = "";
            sLoanType = Enum.GetName(typeof(Dictionary.HRLoanType), oHRLoan.LoanTypeID);
            string sLoanSubType = "";
            if (oHRLoan.LoanTypeID == (int)Dictionary.HRLoanType.Article)
            {
                sLoanSubType = " - " + Enum.GetName(typeof(Dictionary.HRLoanArticle), oHRLoan.ArticleType);
            }
            lblLoanType.Text = sLoanType + sLoanSubType;
            lblDisburseDate.Text = oHRLoan.DisburseDate.ToString("dd-MMM-yyyy");
            lblLoanAmount.Text = _oTELLib.TakaFormat(oHRLoan.AllocatedAmount);
            lblNoOfInstallment.Text = oHRLoan.NoOfInstallment.ToString();

            _oHRLoan = new HRLoan();
            _oHRLoan.GetDueLoanDetail(nLoanID);

            foreach (HRLoanDetail oHRLoanDetail in _oHRLoan)
            {
                ListViewItem oItem = lvwItems.Items.Add(oHRLoanDetail.InstallmentNo.ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oHRLoanDetail.BalancePrincipal));
                oItem.SubItems.Add(_oTELLib.TakaFormat(oHRLoanDetail.PrincipalPayable));
                oItem.SubItems.Add(_oTELLib.TakaFormat(oHRLoanDetail.InterestPayable));
                oItem.SubItems.Add(_oTELLib.TakaFormat(oHRLoanDetail.TotalPayable));
                oItem.SubItems.Add(oHRLoanDetail.PaymentDate.ToString("MMM-yyyy"));

                _PrincipalAmount = _PrincipalAmount + oHRLoanDetail.PrincipalPayable;
                _InterestAmount = _InterestAmount + oHRLoanDetail.InterestPayable;
            }

            lblPrincipalPayable.Text = _oTELLib.ExcludeDecimal(_oTELLib.TakaFormat(_PrincipalAmount));
            lblInterestPayable.Text = _oTELLib.ExcludeDecimal(_oTELLib.TakaFormat(_InterestAmount));
            lblTotalPayable.Text = _oTELLib.ExcludeDecimal(_oTELLib.TakaFormat(_PrincipalAmount + _InterestAmount));
            lblAmountInWord.Text = "Taka Zero only";

            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                DialogResult oResult = MessageBox.Show("Are you sure You want to Early settled the Loan: " + lblLoanNo.Text + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    Save();
                    this.Close();
                }
            }
        }

        private bool UIValidation()
        {
            double _PrincipalAmt = Convert.ToDouble(lblPrincipalPayable.Text);
            double _PrincipalReceive = Convert.ToDouble(txtPrincipalAmount.Text);

            double _InterestAmt = Convert.ToDouble(lblInterestPayable.Text);
            double _InterestReceive = Convert.ToDouble(txtInterestAmount.Text);

            double _TotalReceive = _PrincipalReceive + _InterestReceive;

            if (_TotalReceive <= 0)
            {
                MessageBox.Show("Receive amount must be Greater than Zero", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (_PrincipalReceive > _PrincipalAmt)
            {
                MessageBox.Show("Principal Receive must be less or equal Payable Principal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (_InterestReceive > _InterestAmt)
            {
                MessageBox.Show("Interest Receive must be less or equal Payable Interest", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void Save()
        {
            try
            {
                DBController.Instance.OpenNewConnection();
                DBController.Instance.BeginNewTransaction();
                _oHRLoan = new HRLoan();
                for (int i = 0; i < lvwItems.Items.Count; i++)
                {
                    ListViewItem itm = lvwItems.Items[i];

                    int nInstallmentNo = Convert.ToInt32(itm.Text);

                    HRLoanDetail _oHRLoanDetail = new HRLoanDetail();
                    _oHRLoanDetail.GetLoanDetailByInstallment(nLoanID, nInstallmentNo);
                    _oHRLoan.UpdateCurrentBalance(false, _oHRLoanDetail.PrincipalPayable, nLoanID);
                    _oHRLoanDetail.UpdateEarlySettle(nLoanID, nInstallmentNo);
                }


                _oHRLoan.UpdateStatus(nLoanID, (int)Dictionary.HRLoanStatus.Closed);

                HRLoanDetail oHRLDet = new HRLoanDetail();

                oHRLDet.LoanID = nLoanID;
                oHRLDet.PrincipalPayable = Convert.ToDouble(txtPrincipalAmount.Text);
                oHRLDet.InterestPayable = Convert.ToDouble(txtInterestAmount.Text);
                oHRLDet.PaymentDate = Convert.ToDateTime(dtFromDate.Value.Date);
                oHRLDet.Remarks = txtRemarks.Text.Trim();
                oHRLDet.CreateUserID = Utility.UserId;
                oHRLDet.CreateDate = DateTime.Now;
                oHRLDet.AddEarlySettle();

                DBController.Instance.CommitTran();
                IsExecute = true;
                MessageBox.Show("Data save Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error saving data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            IsExecute = false;
            this.Close();
        }

        private void frmLoanEarlySettle_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _oTELLib = new TELLib();

            double temp = 0;
            try
            {
                temp = Convert.ToDouble(txtPrincipalAmount.Text);
            }
            catch
            {
                temp = 0;
            }
            GetTotal();
        }

        private void txtInterestAmount_TextChanged(object sender, EventArgs e)
        {
            double temp = 0;
            try
            {
                temp = Convert.ToDouble(txtInterestAmount.Text);
            }
            catch
            {
                temp = 0;
            }

            GetTotal();
        }

        private void GetTotal()
        {
            double temp = 0;
            double temp1 = 0;
            try
            {
                temp = Convert.ToDouble(txtPrincipalAmount.Text);
            }
            catch
            {
                temp = 0;
            }
            try
            {
                temp1 = Convert.ToDouble(txtInterestAmount.Text);
            }
            catch
            {
                temp1 = 0;
            }
            lblTotalReceive.Text = _oTELLib.TakaFormat(temp + temp1);
            lblAmountInWord.Text = _oTELLib.TakaWords(temp + temp1);
        }
    }
}
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
using CJ.Class.Accounts;
using CJ.Report;

namespace CJ.Win.Accounts
{
    public partial class frmCompanyLoans : Form
    {
        Banks oBanks;
        CompanyLoans _oCompanyLoans;
        CompanyLoan _oCompanyLoan;
        CompanyLoanInterests _oCompanyLoanInterests;
        CompanyLoanHistorys _oCompanyLoanHistorys;
        DSCompanyLoan _oDSCompanyLoan;
        DSCompanyLoan _oDSCompanyLoanHistory;
        DSCompanyLoan _oDSCompanyLoanInterest;
        int nBankID = 0;
        public frmCompanyLoans()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCompanyLoan oform = new frmCompanyLoan(oBanks);
            oform.ShowDialog();
            if (oform.bIsSave)
            {
                DataLoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwCompanyLoans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CompanyLoan oCompanyLoan = (CompanyLoan)lvwCompanyLoans.SelectedItems[0].Tag;
            if (oCompanyLoan.Status != (int)Dictionary.CompanyLoanStatus.Create)
            {
                MessageBox.Show("Only Create status can be Edited", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmCompanyLoan oForm = new frmCompanyLoan(oBanks);
            oForm.ShowDialog(oCompanyLoan);
            if (oForm.bIsSave)
            {
                DataLoadControl();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwCompanyLoans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CompanyLoan oCompanyLoan = (CompanyLoan)lvwCompanyLoans.SelectedItems[0].Tag;
            if (oCompanyLoan.Status != (int)Dictionary.CompanyLoanStatus.Create)
            {
                MessageBox.Show("Only Create status can be deleted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Loan Number: " + oCompanyLoan.LoanNumber + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCompanyLoan.Delete();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Successfully deleted!!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void frmCompanyLoans_Load(object sender, EventArgs e)
        {
            chkExpireDateRangeChecked.Checked = true;
            chkCreateDateRangeChecked.Checked = true;
            LoadCombo();
            DataLoadControl();
        }

        private void LoadCombo()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CompanyLoanStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.CompanyLoanStatus), GetEnum));
            }

            cmbStatus.SelectedIndex = 0;

            cmbLoanType.Items.Clear();
            cmbLoanType.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CompanyLoanType)))
            {
                if (GetEnum == (int)Dictionary.CompanyLoanType.OBU_Upass)
                {
                    cmbLoanType.Items.Add("OBU/Upass");
                }
                else if (GetEnum == (int)Dictionary.CompanyLoanType.STL_Time)
                {
                    cmbLoanType.Items.Add("STL/Time");
                }
                else if (GetEnum == (int)Dictionary.CompanyLoanType.LTR)
                {
                    cmbLoanType.Items.Add("LTR");
                }
                else if (GetEnum == (int)Dictionary.CompanyLoanType.Long_term)
                {
                    cmbLoanType.Items.Add("Long/term");
                }
            }

            cmbLoanType.SelectedIndex = 0;

            cmbBank.Items.Clear();
            cmbBank.Items.Add("<All>");
            oBanks = new Banks();
            oBanks.Refresh();
            foreach (Bank oBank in oBanks)
            {
                cmbBank.Items.Add(oBank.Code + " - " + oBank.Name);
            }
            cmbBank.SelectedIndex = 0;
        }

        private void chkReceiveDateRangeChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReceiveDateRangeChecked.Checked == true)
            {
                lblReceiveDate.Enabled = false;
                lblReceiveDateTo.Enabled = false;
                dtReceiveFromDate.Enabled = false;
                dtReceiveToDate.Enabled = false;
            }
            else
            {
                lblReceiveDate.Enabled = true;
                lblReceiveDateTo.Enabled = true;
                dtReceiveFromDate.Enabled = true;
                dtReceiveToDate.Enabled = true;
            }
        }

        private void chkExpireDateRangeChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpireDateRangeChecked.Checked == true)
            {
                lblExpireDate.Enabled = false;
                lblExpireDateTo.Enabled = false;
                dtExpireFromDate.Enabled = false;
                dtExpireToDate.Enabled = false;
            }
            else
            {
                lblExpireDate.Enabled = true;
                lblExpireDateTo.Enabled = true;
                dtExpireFromDate.Enabled = true;
                dtExpireToDate.Enabled = true;
            }
        }

        private void chkCreateDateRangeChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreateDateRangeChecked.Checked == true)
            {
                lblCreateDate.Enabled = false;
                lblCreateDateTo.Enabled = false;
                dtCreateFromDate.Enabled = false;
                dtCreateToDate.Enabled = false;
            }
            else
            {
                lblCreateDate.Enabled = true;
                lblCreateDateTo.Enabled = true;
                dtCreateFromDate.Enabled = true;
                dtCreateToDate.Enabled = true;
            }
        }

        private void DataLoadControl()
        {
            _oCompanyLoans = new CompanyLoans();
            lvwCompanyLoans.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbBank.SelectedIndex == 0)
            {
                nBankID = 0;
            }
            else
            {
                nBankID = oBanks[cmbBank.SelectedIndex - 1].BankID;
            }

            _oCompanyLoans.Refresh(dtReceiveFromDate.Value.Date, dtReceiveToDate.Value.Date, dtExpireFromDate.Value.Date, dtExpireToDate.Value.Date, dtCreateFromDate.Value.Date, dtCreateToDate.Value.Date, chkReceiveDateRangeChecked.Checked, chkExpireDateRangeChecked.Checked, chkCreateDateRangeChecked.Checked, txtLoanNumber.Text, txtLCNumber.Text, nBankID, cmbStatus.SelectedIndex, cmbLoanType.SelectedIndex);
            this.Text = "Total " + "[" + _oCompanyLoans.Count + "]";
            foreach (CompanyLoan oCompanyLoan in _oCompanyLoans)
            {
                ListViewItem oItem = lvwCompanyLoans.Items.Add(Enum.GetName(typeof(Dictionary.CompanyID), oCompanyLoan.CompanyID));
                oItem.SubItems.Add(oCompanyLoan.LoanNumber);
                //oItem.SubItems.Add(oCompanyLoan.LoanType.ToString());
                if (oCompanyLoan.LoanType == (int)Dictionary.CompanyLoanType.OBU_Upass)
                {
                    oItem.SubItems.Add("OBU/Upass");
                }
                else if (oCompanyLoan.LoanType == (int)Dictionary.CompanyLoanType.STL_Time)
                {
                    oItem.SubItems.Add("STL/Time");
                }
                else if (oCompanyLoan.LoanType == (int)Dictionary.CompanyLoanType.LTR)
                {
                    oItem.SubItems.Add("LTR");
                }
                else if (oCompanyLoan.LoanType == (int)Dictionary.CompanyLoanType.Long_term)
                {
                    oItem.SubItems.Add("Long/term");
                }
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CompanyLoanStatus), oCompanyLoan.Status));
                oItem.SubItems.Add(oCompanyLoan.LCNumber);
                oItem.SubItems.Add(oCompanyLoan.ReceiveDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCompanyLoan.BDTAmount.ToString());
                oItem.SubItems.Add(oCompanyLoan.DurationDays.ToString() + " Days");
                oItem.SubItems.Add(oCompanyLoan.ExpireDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCompanyLoan.BankCode + " - " + oCompanyLoan.BankName);
                oItem.SubItems.Add(oCompanyLoan.CreateUser);
                oItem.SubItems.Add(oCompanyLoan.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCompanyLoan.Remarks);
                //oItem.SubItems.Add(oCompanyLoan.DivisionName);

                oItem.Tag = oCompanyLoan;
            }
            setListViewRowColour();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void setListViewRowColour()
        {
            if (lvwCompanyLoans.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCompanyLoans.Items)
                {
                    if (oItem.SubItems[3].Text == Dictionary.CompanyLoanStatus.Create.ToString())
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                    else if (oItem.SubItems[3].Text == Dictionary.CompanyLoanStatus.Running.ToString())
                    {
                        oItem.BackColor = Color.Wheat;
                    }
                    else if (oItem.SubItems[3].Text == Dictionary.CompanyLoanStatus.Overdue.ToString())
                    {
                        oItem.BackColor = Color.Red;
                    }
                    else if (oItem.SubItems[3].Text == Dictionary.CompanyLoanStatus.Settled.ToString())
                    {
                        oItem.BackColor = Color.White;
                    }
                    else
                    {
                        oItem.BackColor = Color.LightGray;

                    }
                }
            }
        }

        private void btnRunning_Click(object sender, EventArgs e)
        {
            if (lvwCompanyLoans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to POST.", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CompanyLoan oCompanyLoan = (CompanyLoan)lvwCompanyLoans.SelectedItems[0].Tag;
            if (oCompanyLoan.Status != (int)Dictionary.CompanyLoanStatus.Create)
            {
                MessageBox.Show("Only Create status can be Posted", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to POST the Loan Number: " + oCompanyLoan.LoanNumber + " ? ", "Confirm Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCompanyLoan.Status = (int)Dictionary.CompanyLoanStatus.Running;
                    oCompanyLoan.StatusChange();
                    DBController.Instance.CommitTran();
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnLoanNumber_Click(object sender, EventArgs e)
        {
            if (lvwCompanyLoans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to update Loan#.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CompanyLoan oCompanyLoan = (CompanyLoan)lvwCompanyLoans.SelectedItems[0].Tag;
            frmCompanyLoanNumber oForm = new frmCompanyLoanNumber(oCompanyLoan.ID, oCompanyLoan.LoanNumber);
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (lvwCompanyLoans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to make payment", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CompanyLoan oCompanyLoan = (CompanyLoan)lvwCompanyLoans.SelectedItems[0].Tag;

            if (oCompanyLoan.Status != (int)Dictionary.CompanyLoanStatus.Running)
            {
                MessageBox.Show("You can make payment on Running Loan only", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmCompanyLoanPayment oForm = new frmCompanyLoanPayment();
            oForm.ShowDialog(oCompanyLoan);
            DataLoadControl();
        }

        private void btnQuarterEnd_Click(object sender, EventArgs e)
        {
            frmCompanyLoanQuarterEnd oForm = new frmCompanyLoanQuarterEnd();
            oForm.ShowDialog();
        }

        private void btnInterestRate_Click(object sender, EventArgs e)
        {

        }

        private void btnLoanHistory_Click(object sender, EventArgs e)
        {
            LoanHistory();
        }

        private void LoanHistory()
        {
            _oCompanyLoan = new CompanyLoan();
            _oCompanyLoanInterests = new CompanyLoanInterests();
            _oCompanyLoanHistorys = new CompanyLoanHistorys();



            if (lvwCompanyLoans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to get Loan History.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CompanyLoan oCompanyLoan = (CompanyLoan)lvwCompanyLoans.SelectedItems[0].Tag;

            //_oCompanyLoan = new CompanyLoan();
            oCompanyLoan.Refresh();

            _oDSCompanyLoanInterest = new DSCompanyLoan();

            _oCompanyLoanInterests = new CompanyLoanInterests();
            _oCompanyLoanInterests.Refresh(oCompanyLoan.ID);

            foreach (CompanyLoanInterest oCompanyLoanInterest in _oCompanyLoanInterests)
            {

                DSCompanyLoan.LoanInterestRow oLoanInterestRow = _oDSCompanyLoanInterest.LoanInterest.NewLoanInterestRow();

                oLoanInterestRow.FromDate = oCompanyLoanInterest.FromDate;
                oLoanInterestRow.ToDate = oCompanyLoanInterest.ToDate;
                oLoanInterestRow.Days = oCompanyLoanInterest.Days;
                oLoanInterestRow.InterestOnPrincipal = oCompanyLoanInterest.InterestOnPrincipal;
                oLoanInterestRow.Interest = oCompanyLoanInterest.Interest;
                oLoanInterestRow.IR = oCompanyLoanInterest.InterestRate;

                _oDSCompanyLoanInterest.LoanInterest.AddLoanInterestRow(oLoanInterestRow);
                _oDSCompanyLoanInterest.AcceptChanges();
                
            }

           

            _oDSCompanyLoanHistory = new DSCompanyLoan();
            _oCompanyLoanHistorys = new CompanyLoanHistorys();
            _oCompanyLoanHistorys.Refresh(oCompanyLoan.ID);

            foreach (CompanyLoanHistory oCompanyLoanHistory in _oCompanyLoanHistorys)
            {

                DSCompanyLoan.CompanyLoanHistoryRow oCompanyLoanHistoryRow = _oDSCompanyLoanHistory.CompanyLoanHistory.NewCompanyLoanHistoryRow();

                oCompanyLoanHistoryRow.TranDate = oCompanyLoanHistory.TranDate;
                oCompanyLoanHistoryRow.TranType = oCompanyLoanHistory.TranTypeName;
                oCompanyLoanHistoryRow.IN = 0;
                oCompanyLoanHistoryRow.OUT = 0;
                oCompanyLoanHistoryRow.Balance = 0;

                _oDSCompanyLoanHistory.CompanyLoanHistory.AddCompanyLoanHistoryRow(oCompanyLoanHistoryRow);
                _oDSCompanyLoanHistory.AcceptChanges();

            }

            _oDSCompanyLoan = new DSCompanyLoan();
            _oDSCompanyLoan.Merge(_oDSCompanyLoanInterest);
            _oDSCompanyLoan.Merge(_oDSCompanyLoanHistory);
            _oDSCompanyLoan.AcceptChanges();

            rptCompanyLoanHistory doc;
            doc = new rptCompanyLoanHistory();
            doc.SetDataSource(_oDSCompanyLoan);
            doc.SetParameterValue("LoanNumber", oCompanyLoan.LoanNumber);

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }
    }
}

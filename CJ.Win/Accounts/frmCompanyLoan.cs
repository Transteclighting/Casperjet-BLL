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
    public partial class frmCompanyLoan : Form
    {
        Banks _oBanks;
        Companys _oCompanys;
        CompanyLoan _oCompanyLoan;
        public bool bIsSave = false;
        public frmCompanyLoan(Banks oBanks)
        {
            InitializeComponent();
            _oBanks = oBanks;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCompanyLoan_Load(object sender, EventArgs e)
        {
            if(this.Tag == null)
            {
                LoadCombo();
            }
        }

        private void LoadCombo()
        {

            cmbLoanType.Items.Clear();
            cmbLoanType.Items.Add("-- Select --");
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

            cmbSupplyType.Items.Clear();
            cmbSupplyType.Items.Add("-- Select --");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SupplyType)))
            {
                cmbSupplyType.Items.Add(Enum.GetName(typeof(Dictionary.SupplyType), GetEnum));
            }
            cmbSupplyType.SelectedIndex = 0;



            cmbBank.Items.Clear();
            cmbBank.Items.Add("-- Select --");
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Code + " - " + oBank.Name);
            }
            cmbBank.SelectedIndex = 0;


            cmbCurrency.Items.Clear();
            cmbCurrency.Items.Add("BDT");
            cmbCurrency.Items.Add("USD");
            cmbCurrency.SelectedIndex = 0;

            _oCompanys = new Companys();
            _oCompanys.GetCompany();
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("-- Select --");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyCode + " - " + oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                _oCompanyLoan = new CompanyLoan();
                _oCompanyLoan.LoanNumber = txtLoanNumber.Text.Trim();
                if (this.Tag == null)
                {
                    if (!_oCompanyLoan.CheckLoanNumber())
                    {
                        Save();
                        bIsSave = true;
                    }
                    else
                    {
                        MessageBox.Show("Duplicate Loan Number!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Save();
                    bIsSave = true;
                }
                this.Close();
            }
        }

        private bool validateUIInput()
        {
            if (cmbCompany.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a Company", "Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            if (cmbLoanType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a Loan Type", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbBank.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a Bank", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtLoanNumber.Text.Trim() == "")
            {
                MessageBox.Show("Please input Loan Number", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoanNumber.Focus();
                return false;
            }
            if (txtLC.Text.Trim() == "")
            {
                MessageBox.Show("Please input LC Number", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLC.Focus();
                return false;
            }
            if (dtReceiveDate.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Receive date must be less or equal current date", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dtReceiveDate.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Receive date must be less or equal current date", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please input Loan Amount", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                try
                {
                    Convert.ToDouble(txtAmount.Text);
                }
                catch
                {
                    MessageBox.Show("Please input valid Loan Amount", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

            }
            if (cmbCurrency.SelectedIndex == 1)//1=USD
            {
                if (txtConversionRate.Text.Trim() == "")
                {
                    MessageBox.Show("Please input Conversion Rate", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    try
                    {
                        Convert.ToDouble(txtConversionRate.Text);
                        
                        if (txtConversionAmount.Text.Trim() == "")
                        {
                            MessageBox.Show("Please input Conversion Amount", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        else
                        {
                            try
                            {
                                Convert.ToDouble(txtConversionAmount.Text);
                            }
                            catch
                            {
                                MessageBox.Show("Please input valid Conversion Amount", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }

                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please input valid Conversion Rate", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                }
            }
            if (txtDuration.Text.Trim() == "")
            {
                MessageBox.Show("Please input Loan Duration", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                try
                {
                   int nDays = Convert.ToInt32(txtDuration.Text);
                    if (nDays <= 0)
                    {
                        MessageBox.Show("Loan Duration must be greater then Zero (0)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Please input valid Loan Duration", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

            }
            if (txtInterestRate.Text.Trim() == "")
            {
                MessageBox.Show("Please input Interest Rate", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                try
                {
                    Convert.ToDouble(txtInterestRate.Text);
                }
                catch
                {
                    MessageBox.Show("Please input valid Interest Rate", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

            }
            if (txtPurposeOfLoan.Text.Trim() == "")
            {
                MessageBox.Show("Please input Purpose of Loan", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbSupplyType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select supply type", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                CompanyLoan oCompanyLoan = new CompanyLoan();

                oCompanyLoan.CompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
                oCompanyLoan.LoanType = cmbLoanType.SelectedIndex;
                oCompanyLoan.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
                oCompanyLoan.LoanNumber = txtLoanNumber.Text;
                oCompanyLoan.LCNumber = txtLC.Text;
                oCompanyLoan.ReceiveDate = Convert.ToDateTime(dtReceiveDate.Value.Date);
                oCompanyLoan.Currency = cmbCurrency.Text;
                oCompanyLoan.Amount = Convert.ToDouble(txtAmount.Text);
                oCompanyLoan.ConversionRate = Convert.ToDouble(txtConversionRate.Text);
                if (oCompanyLoan.Currency == "BDT")
                {
                    oCompanyLoan.BDTAmount = oCompanyLoan.Amount;
                }
                else
                {
                    oCompanyLoan.BDTAmount = Convert.ToDouble(txtConversionAmount.Text);
                }

                oCompanyLoan.PayablePrincipal = oCompanyLoan.BDTAmount;
                oCompanyLoan.DurationDays = Convert.ToInt32(txtDuration.Text);
                oCompanyLoan.CurrentInterestRate = Convert.ToDouble(txtInterestRate.Text);
                oCompanyLoan.ExpireDate = Convert.ToDateTime(dtExpireDate.Value.Date);
                oCompanyLoan.PurposeOfLoan = txtPurposeOfLoan.Text;
                oCompanyLoan.SupplyType = cmbSupplyType.Text;
                oCompanyLoan.Remarks = txtRemarks.Text;
                oCompanyLoan.Status = (int)Dictionary.CompanyLoanStatus.Create;
                oCompanyLoan.CreateUserID = Utility.UserId;
                oCompanyLoan.CreateDate = DateTime.Now;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCompanyLoan.Add();
                    CompanyLoanHistory oCompanyLoanHistory = new CompanyLoanHistory();

                    oCompanyLoanHistory.LoanID = oCompanyLoan.ID;
                    oCompanyLoanHistory.TranDate = oCompanyLoan.ReceiveDate;
                    oCompanyLoanHistory.TranType = (int)Dictionary.CompanyLoanTranType.Receive;
                    oCompanyLoanHistory.TranSide = (int)Dictionary.TranSide.IN;
                    oCompanyLoanHistory.Amount = oCompanyLoan.Amount;
                    oCompanyLoanHistory.CreateUserID = oCompanyLoan.CreateUserID;
                    oCompanyLoanHistory.CreateDate = oCompanyLoan.CreateDate;

                    oCompanyLoanHistory.Add();

                    DBController.Instance.CommitTran();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Refresh();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                CompanyLoan oCompanyLoan = (CompanyLoan)this.Tag;

                oCompanyLoan.CompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
                oCompanyLoan.LoanType = cmbLoanType.SelectedIndex;
                oCompanyLoan.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
                //oCompanyLoan.LoanNumber = txtLoanNumber.Text;
                oCompanyLoan.LCNumber = txtLC.Text;
                oCompanyLoan.ReceiveDate = Convert.ToDateTime(dtReceiveDate.Value.Date);
                oCompanyLoan.Currency = cmbCurrency.Text;
                oCompanyLoan.Amount = Convert.ToDouble(txtAmount.Text);
                oCompanyLoan.ConversionRate = Convert.ToDouble(txtConversionRate.Text);
                if (oCompanyLoan.Currency == "BDT")
                {
                    oCompanyLoan.BDTAmount = oCompanyLoan.Amount;
                }
                else
                {
                    oCompanyLoan.BDTAmount = Convert.ToDouble(txtConversionAmount.Text);
                }
                oCompanyLoan.DurationDays = Convert.ToInt32(txtDuration.Text);
                oCompanyLoan.CurrentInterestRate = Convert.ToDouble(txtInterestRate.Text);
                oCompanyLoan.ExpireDate = Convert.ToDateTime(dtExpireDate.Value.Date);
                oCompanyLoan.PurposeOfLoan = txtPurposeOfLoan.Text;
                oCompanyLoan.SupplyType = cmbSupplyType.Text;
                oCompanyLoan.Remarks = txtRemarks.Text;
                oCompanyLoan.UpdateUserID = Utility.UserId;
                oCompanyLoan.UpdateDate = DateTime.Now;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCompanyLoan.Edit();
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Refresh();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCurrency.SelectedIndex == 0)
            {
                lblConvRate.Visible = false;
                lblConvAmount.Visible = false;
                txtConversionRate.Visible = false;
                txtConversionAmount.Visible = false;

                txtConversionRate.Text = "0";
                txtConversionAmount.Text = "0";
            }
            else
            {
                lblConvRate.Visible = true;
                lblConvAmount.Visible = true;
                txtConversionRate.Visible = true;
                txtConversionAmount.Visible = true;
            }
        }

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            DateTime _ReceiveDate = dtReceiveDate.Value;
            dtExpireDate.Value = _ReceiveDate.AddDays(Convert.ToInt32(txtDuration.Text));
        }

        private void txtConversionRate_TextChanged(object sender, EventArgs e)
        {
            if (cmbCurrency.Text == "USD")
            {
                BDTConversion();
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (cmbCurrency.Text == "USD")
            {
                BDTConversion();
            }
        }

        private void BDTConversion()
        {
            txtConversionAmount.Text = (Convert.ToDouble(txtConversionRate.Text) * Convert.ToDouble(txtAmount.Text)).ToString();
        }

        public void ShowDialog(CompanyLoan oCompanyLoan)
        {
            this.Tag = oCompanyLoan;
            LoadCombo();
            //nID = 0;
            //nID = oHRLoanType.ID;
            cmbCompany.SelectedIndex = _oCompanys.GetIndex(oCompanyLoan.CompanyID) + 1;
            cmbLoanType.SelectedIndex = oCompanyLoan.LoanType;
            cmbBank.SelectedIndex = _oBanks.GetIndexByID(oCompanyLoan.BankID) + 1;
            txtLoanNumber.Text = oCompanyLoan.LoanNumber;
            txtLoanNumber.Enabled = false;
            txtLC.Text = oCompanyLoan.LCNumber;
            dtReceiveDate.Value = oCompanyLoan.ReceiveDate;
            cmbCurrency.Text = oCompanyLoan.Currency;
            txtAmount.Text = oCompanyLoan.Amount.ToString();
            txtConversionRate.Text = oCompanyLoan.ConversionRate.ToString();
            if (oCompanyLoan.Currency == "BDT")
            {
                txtConversionAmount.Text = oCompanyLoan.Amount.ToString();
            }
            else
            {
                txtConversionAmount.Text = oCompanyLoan.BDTAmount.ToString();
            }
            txtDuration.Text = oCompanyLoan.DurationDays.ToString();
            txtInterestRate.Text = oCompanyLoan.CurrentInterestRate.ToString();
            dtExpireDate.Value = oCompanyLoan.ExpireDate;
            txtPurposeOfLoan.Text = oCompanyLoan.PurposeOfLoan;
            cmbSupplyType.Text = oCompanyLoan.SupplyType;
            txtRemarks.Text = oCompanyLoan.Remarks;


            this.ShowDialog();
        }
    }
}

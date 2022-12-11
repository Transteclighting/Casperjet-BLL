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
    public partial class frmLoan : Form
    {
        LoanCalculators _oLoanCalculators;
        HRLoan _oHRLoan;
        TELLib _oTELLib;
        LoanTypes _oLoanTypes;
        double _CurrentBalance = 0;
        public frmLoan()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInputSave())
            {
                Save();
                this.Close();
            }
            
        }

        private void Save()
        {
            _oHRLoan = new HRLoan();
            _oHRLoan = GetUIData(_oHRLoan);

            DBController.Instance.OpenNewConnection();
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oHRLoan.Add();
                _oHRLoan.UpdateCurrentBalance(true, _CurrentBalance, _oHRLoan.LoanID);
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Data Save Successfully; Loan # : " + _oHRLoan.LoanNo.ToString(), "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error Inserting Data\n\n" + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validateUIInput()
        {

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
            if (txtDownPayment.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Down Payment Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDownPayment.Focus();
                return false;
            }
            else
            {
                try
                {
                    double temp = Convert.ToDouble(txtDownPayment.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter Valid Down Payment Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDownPayment.Focus();
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

            if (cmbLoanType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Loan Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLoanType.Focus();
                return false;
            }
            else if (cmbLoanType.SelectedIndex == (int)Dictionary.HRLoanType.Article)
            {
                if (cmbArticleType.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Article Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbArticleType.Focus();
                    return false;
                }
            }
            if (ctlEmployee1.txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please select Employee ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.txtCode.Focus();
                return false;
            }
            UserPermission _oUserPermission = new UserPermission();
            if (!_oUserPermission.CheckPermissionalData("Company", ctlEmployee1.SelectedEmployee.CompanyID, Utility.UserId))
            {
                MessageBox.Show("You have no permission to create \nthe loan schedule for this Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool validateUIInputSave()
        {

            if (dgvEMI.Rows.Count == 0)
            {
                MessageBox.Show("There is no repayment schedule", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }

        public HRLoan GetUIData(HRLoan _oHRLoan)
        {
            //Loan No
            _CurrentBalance = 0;
            _oHRLoan.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            _oHRLoan.CompanyID = ctlEmployee1.SelectedEmployee.CompanyID;
            _oHRLoan.LoanTypeID = _oLoanTypes[cmbLoanType.SelectedIndex - 1].LoanTypeID;
            if (_oHRLoan.LoanTypeID == (int)Dictionary.HRLoanType.Article)
            {
                _oHRLoan.ArticleType = cmbArticleType.SelectedIndex;
            }
            else
            {
                _oHRLoan.ArticleType = 0;
            }

            _oHRLoan.AllocatedAmount = Convert.ToDouble(txtPV.Text);
            _oHRLoan.DisburseDate = Convert.ToDateTime(dtStartDate.Value.Date);
            _oHRLoan.DownPayment = Convert.ToDouble(txtDownPayment.Text);
            _oHRLoan.NoOfInstallment = Convert.ToInt32(txtInstallmentNo.Text);
            _oHRLoan.InterestRate = Convert.ToDouble(txtInteresrRate.Text);
            _oHRLoan.Status = (int)Dictionary.HRLoanStatus.Running;
            _oHRLoan.CreateUserID = Utility.UserId;
            _oHRLoan.CreateDate = DateTime.Now;

            int nDay = _oHRLoan.DisburseDate.Day;
            _oTELLib = new TELLib();
            DateTime _FromDate = _oTELLib.FirstDayofMonth(_oHRLoan.DisburseDate);
            DateTime _ToDate = _FromDate.AddMonths(1);
            HRLoan oLoan = new HRLoan();
            int nCount = oLoan.GetTotalLoan(_oHRLoan.LoanTypeID, _FromDate, _ToDate, _oHRLoan.CompanyID);
            nCount = nCount + 1;
            string _sYear = _FromDate.ToString("yy");
            string _sMonth = _FromDate.ToString("MM");
            _oHRLoan.LoanNo = GetCompanyPrefix(_oHRLoan.CompanyID) + "-" + GetLoanPrefix(_oHRLoan.LoanTypeID) + "-" + _sYear + _sMonth + "-" + nCount.ToString("000");

            // Loan Details

            foreach (DataGridViewRow oItemRow in dgvEMI.Rows)
            {
                if (oItemRow.Index < dgvEMI.Rows.Count)
                {
                    HRLoanDetail _oHRLoanDetail = new HRLoanDetail();

                    _oHRLoanDetail.InstallmentNo = int.Parse(oItemRow.Cells[0].Value.ToString().Trim());
                    _oHRLoanDetail.BalancePrincipal = Convert.ToDouble(oItemRow.Cells[1].Value.ToString().Trim());
                    _oHRLoanDetail.PrincipalPayable = Convert.ToDouble(oItemRow.Cells[2].Value.ToString().Trim());
                    _oHRLoanDetail.InterestPayable = Convert.ToDouble(oItemRow.Cells[3].Value.ToString().Trim());
                    _oHRLoanDetail.TotalPayable = Convert.ToDouble(oItemRow.Cells[4].Value.ToString().Trim());
                    _oHRLoanDetail.PaymentDate = Convert.ToDateTime("1-" + oItemRow.Cells[5].Value.ToString().Trim());
                    _oHRLoanDetail.IsDue = (int)Dictionary.YesOrNoStatus.YES;
                    _oHRLoanDetail.IsEarlyClose = (int)Dictionary.YesOrNoStatus.NO;
                    if (_oHRLoan.LoanTypeID == (int)Dictionary.HRLoanType.BuildingOrCash)
                    {
                        int nMonth = _oHRLoanDetail.PaymentDate.Month;
                        if (nMonth == 12)
                        {
                            _oHRLoanDetail.IsBonus = (int)Dictionary.YesOrNoStatus.YES;
                        }
                        else
                        {
                            _oHRLoanDetail.IsBonus = (int)Dictionary.YesOrNoStatus.NO;
                        }
                    }
                    else
                    {
                        _oHRLoanDetail.IsBonus = (int)Dictionary.YesOrNoStatus.NO;
                    }

                    _CurrentBalance = _CurrentBalance + _oHRLoanDetail.PrincipalPayable;

                    _oHRLoan.Add(_oHRLoanDetail);
                }
            }
            return _oHRLoan;
        }
        private string GetLoanPrefix(int nLoanTypeID)
        {
            string _sPrefix = "";
            if (nLoanTypeID == (int)Dictionary.HRLoanType.Article)
            {
                _sPrefix = "AL";
            }
            else if (nLoanTypeID == (int)Dictionary.HRLoanType.BuildingOrCash)
            {
                _sPrefix = "CL";
            }
            else if (nLoanTypeID == (int)Dictionary.HRLoanType.SalaryAdvance)
            {
                _sPrefix = "SA";
            }
            else if (nLoanTypeID == (int)Dictionary.HRLoanType.Emergency)
            {
                _sPrefix = "EL";
            }
            else if (nLoanTypeID == (int)Dictionary.HRLoanType.ProvidentFund)
            {
                _sPrefix = "PF";
            }
            else
            {
                _sPrefix = "MI";
            }

            return _sPrefix;
        }

        private string GetCompanyPrefix(int nCompanyID)
        {
            string _sPrefix = "";
            if (nCompanyID == (int)Dictionary.CompanyID.TEL)
            {
                _sPrefix = "T";
            }
            else if (nCompanyID == (int)Dictionary.CompanyID.BEIL)
            {
                _sPrefix = "E";
            }
            else if (nCompanyID == (int)Dictionary.CompanyID.BLL)
            {
                _sPrefix = "B";
            }
            else if (nCompanyID == (int)Dictionary.CompanyID.TML)
            {
                _sPrefix = "M";
            }
            else
            {
                _sPrefix = "O";
            }

            return _sPrefix;
        }
        private void Process()
        {
            double NPer = 0;
            double PV = 0;
            double Rate = 0;
            double DownPayment = 0;
            double _Bonus = 0;
            bool _bFlag = false;
            bool _IsPFLoan = false;
            int nLoanTypeID = 0;
            DateTime dtDate = DateTime.Today;
            dgvEMI.Rows.Clear();

                NPer = Convert.ToDouble(txtInstallmentNo.Text);
                PV = Convert.ToDouble(txtPV.Text);
                Rate = Convert.ToDouble(txtInteresrRate.Text);
                DownPayment = Convert.ToDouble(txtDownPayment.Text);
                PV = PV - DownPayment;

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                int nCompanyID = ctlEmployee1.SelectedEmployee.CompanyID;
                DateTime _Date = dtStartDate.Value.Date;
                int nYear = _Date.Year;
                EmployeeAllowance _oEmployeeAllowance = new EmployeeAllowance();
                _Bonus = _oEmployeeAllowance.GetAllowance(oEmployee.EmployeeID, (int)Dictionary.HREmployeeAllowance.FestivalBonus, nYear, nCompanyID);
                nLoanTypeID = _oLoanTypes[cmbLoanType.SelectedIndex - 1].LoanTypeID;
                if (nLoanTypeID == (int)Dictionary.HRLoanType.BuildingOrCash)
                {
                    _bFlag = true;
                }


            if (dtStartDate.Value.Day > 15)
                dtDate = dtStartDate.Value.Date.AddMonths(1);
            else dtDate = dtStartDate.Value.Date;

            if (nLoanTypeID == (int)Dictionary.HRLoanType.ProvidentFund)
            {
                _IsPFLoan = true;
            }
            _oLoanCalculators = new LoanCalculators();
            _oLoanCalculators.CalculateResult(Rate, NPer, PV, dtDate, _bFlag, _Bonus, _IsPFLoan);

            int i = 0;
            foreach (LoanCalculator oLoanCalculator in _oLoanCalculators)
            {
                dgvEMI.Rows.Add();
                dgvEMI[0, i].Value = oLoanCalculator.InstallmentNo;
                dgvEMI[1, i].Value = oLoanCalculator.BalancePrincipal;
                dgvEMI[2, i].Value = oLoanCalculator.PrincipalPayable;
                dgvEMI[3, i].Value = oLoanCalculator.InterestPayable;
                dgvEMI[4, i].Value = oLoanCalculator.ClosingBalance;
                dgvEMI[5, i].Value = Convert.ToDateTime(oLoanCalculator.PaymentDate).ToString("MMM-yyyy");
                i++;
            }
        }

        private void cmbLoanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nLoanTypeID = 0;
            if (cmbLoanType.SelectedIndex != 0)
            {
                nLoanTypeID = _oLoanTypes[cmbLoanType.SelectedIndex - 1].LoanTypeID;
            }
            if (nLoanTypeID == (int)Dictionary.HRLoanType.Article)
            {
                cmbArticleType.Visible = true;
                lblArticleType.Visible = true;
            }
            else
            {
                cmbArticleType.Visible = false;
                lblArticleType.Visible = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoan_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void LoadCombos()
        {
            
            //HRLoanType
            _oLoanTypes = new LoanTypes();
            _oLoanTypes.RefreshActiveData();
            cmbLoanType.Items.Add("--Select--");
            foreach (LoanType oLoanType in _oLoanTypes)
            {
                cmbLoanType.Items.Add(oLoanType.LoanTypeName);
            }
            cmbLoanType.SelectedIndex = 0;

            //HRLoanArticle
            cmbArticleType.Items.Add("--Select--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRLoanArticle)))
            {
                cmbArticleType.Items.Add(Enum.GetName(typeof(Dictionary.HRLoanArticle), GetEnum));
            }
            cmbArticleType.SelectedIndex = 0;

        }
    }
}
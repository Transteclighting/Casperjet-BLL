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

namespace CJ.Win.HR
{
    public partial class frmPFReport : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        LoanTypes _oLoanTypes;
        public frmPFReport()
        {
            InitializeComponent();
        }

        private void frmPFReport_Load(object sender, EventArgs e)
        {
            LoadCombos();
            lblStatus.Enabled = false;
            cmbStatus.Enabled = false;
            lblIsEarlyClose.Enabled = false;
            cmbIsEarlyClose.Enabled = false;
            cmbLoanType.Enabled = false;
            cmbSubLoanType.Enabled = false;
            lblLoanType.Enabled = false;
            lblSubLoanType.Enabled = false;

        }

        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cmbCompany.Items.Clear();
            if (_oCompanys.Count == 0)
            {
                cmbCompany.Items.Add("No Permission!!");
            }
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.GetDepartmentAll();
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("All");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("All");
            cmbStatus.Items.Add("Paid");
            cmbStatus.Items.Add("Due");
            cmbStatus.SelectedIndex = 0;

            cmbIsEarlyClose.Items.Clear();
            cmbIsEarlyClose.Items.Add("All");
            cmbIsEarlyClose.Items.Add("No");
            cmbIsEarlyClose.Items.Add("Yes");
            cmbIsEarlyClose.SelectedIndex = 0;

            //Loan Type
            //cmbLoanType.Items.Clear();
            //cmbLoanType.Items.Add("ALL");
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRLoanType)))
            //{
            //    cmbLoanType.Items.Add(Enum.GetName(typeof(Dictionary.HRLoanType), GetEnum));
            //}
            //cmbLoanType.SelectedIndex = 0;


            //Sub Loan Type
            cmbSubLoanType.Items.Clear();
            cmbSubLoanType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRLoanArticle)))
            {
                cmbSubLoanType.Items.Add(Enum.GetName(typeof(Dictionary.HRLoanArticle), GetEnum));
            }
            cmbSubLoanType.SelectedIndex = 0;
            
            //HRLoanType
            _oLoanTypes = new LoanTypes();
            _oLoanTypes.Refresh();
            cmbLoanType.Items.Add("All");
            foreach (LoanType oLoanType in _oLoanTypes)
            {
                cmbLoanType.Items.Add(oLoanType.LoanTypeName);
            }
            cmbLoanType.SelectedIndex = 0;



        }

        private void btnPreview_Click(object sender, EventArgs e)
        {            
            if (rdoPFSchedule.Checked == true)
            {
                PFScheduleView();                
            }
            else if (rdoAll.Checked == true)
            {
                AllLoanSchedule();                
            }
            else
            {
                AllLoanDisbursement();                
            }
            
        }
        private void AllLoanDisbursement()
        {
            this.Cursor = Cursors.WaitCursor;
            int nSearchCompanyID;
            if (_oCompanys.Count != 0)
            {
                nSearchCompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
            }
            else
            {
                nSearchCompanyID = 0;
            }

            int nSearchDepartmentID;
            if (cmbDepartment.SelectedIndex == 0)
            {
                nSearchDepartmentID = -1;
            }
            else
            {
                nSearchDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }
            
            int nLoanType = -1;
            if (cmbLoanType.SelectedIndex != 0)
            {
                nLoanType = cmbLoanType.SelectedIndex;
            }
            int nSubLoanType = -1;
            if (cmbSubLoanType.SelectedIndex != 0)
            {
                nSubLoanType = cmbSubLoanType.SelectedIndex;
            }
            HRLoans _oHRLoans = new HRLoans();
            _oHRLoans.GetLoanDisbursmentForReport(nSearchCompanyID, nSearchDepartmentID, nLoanType, nSubLoanType, dtMonth.Value.Month, dtMonth.Value.Year);

            rptLoanReport doc;
            doc = new rptLoanReport();

            List<LoanDisbursment> PFList = new List<LoanDisbursment>();

            foreach (HRLoan aHRLoan in _oHRLoans)
            {
                var PFLoan = new LoanDisbursment
                {
                    LoanNo = aHRLoan.LoanNo,
                    AllocatedAmount = aHRLoan.AllocatedAmount,
                    DisbursDate = aHRLoan.DisburseDate,
                    DownPayment = aHRLoan.DownPayment,
                    EmployeeCode = aHRLoan.EmployeeCode,
                    EmployeeName = aHRLoan.EmployeeName,
                    DepartmentName = aHRLoan.DepartmentName,
                    LoanTypeName = aHRLoan.LoanTypeName,
                    NoOfInstallment = aHRLoan.NoOfInstallment,
                    InterestRate = aHRLoan.InterestRate
                    //TotalPayable = aHRLoan.TotalPayable
                };
                PFList.Add(PFLoan);
            }
            //doc.SetDataSource(_oHRLoans);
            doc.SetDataSource(PFList);

            doc.SetParameterValue("PrintUser", Utility.UserFullname);
            doc.SetParameterValue("Company", cmbCompany.Text);
            doc.SetParameterValue("Department", cmbDepartment.Text);
            doc.SetParameterValue("Month", dtMonth.Text);
            doc.SetParameterValue("LoanType", cmbLoanType.Text);
            doc.SetParameterValue("SubLoanType", cmbSubLoanType.Text);

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
            
        }
        
        private void PFScheduleView()
        {
            this.Cursor = Cursors.WaitCursor;
            int nSearchCompanyID;
            if (_oCompanys.Count != 0)
            {
                nSearchCompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
            }
            else
            {
                nSearchCompanyID = 0;
            }
            
            int nSearchDepartmentID;
            if (cmbDepartment.SelectedIndex == 0)
            {
                nSearchDepartmentID = -1;
            }
            else
            {
                nSearchDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }

            int nEmployeeID = -1;
            if (ctlEmployee1.txtDescription.Text != string.Empty)
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }

            HRPayroll _oHRPayroll = new HRPayroll();
            _oHRPayroll.GetEmployeePFForReport(nSearchCompanyID, nSearchDepartmentID, nEmployeeID,dtMonth.Value.Month,dtMonth.Value.Year);

            rptPFReport doc;
            doc = new rptPFReport();

            List<PFSchedule> PFList = new List<PFSchedule>();

            foreach (HRPayroll aHRPayroll in _oHRPayroll)
            {
                var PFLoan = new PFSchedule
                {
                    EmployeeID = aHRPayroll.EmployeeID,
                    EmployeeCode = aHRPayroll.EmployeeCode,
                    EmployeeName = aHRPayroll.EmployeeName,
                    DesignationName = aHRPayroll.DesignationName,
                    EditedAmount = aHRPayroll.EditedAmount

                };
                PFList.Add(PFLoan);
            }

            //doc.SetDataSource(_oHRPayroll);
            doc.SetDataSource(PFList);

            doc.SetParameterValue("PrintUser", Utility.UserFullname);
            doc.SetParameterValue("Company", cmbCompany.Text);
            doc.SetParameterValue("Department", cmbDepartment.Text);
            doc.SetParameterValue("Month",dtMonth.Text);
            if (ctlEmployee1.txtDescription.Text != string.Empty)
            {
                doc.SetParameterValue("Employee", ctlEmployee1.txtCode.Text + "-" + ctlEmployee1.txtDescription.Text);
            }
            else
            {
                doc.SetParameterValue("Employee", "All");
            }
       
            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;

        }

        private void AllLoanSchedule()
        {
            this.Cursor = Cursors.WaitCursor;
            int nSearchCompanyID;
            if (_oCompanys.Count != 0)
            {
                nSearchCompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
            }
            else
            {
                nSearchCompanyID = 0;
            }
            
            int nSearchDepartmentID;
            if (cmbDepartment.SelectedIndex == 0)
            {
                nSearchDepartmentID = -1;
            }
            else
            {
                nSearchDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }

            int nEmployeeID = -1;
            string sEmplName = string.Empty;
            if (ctlEmployee1.txtDescription.Text != string.Empty)
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                sEmplName = ctlEmployee1.txtDescription.Text;
            }
            int nIsDue=-1;
            if (cmbStatus.SelectedIndex != 0)
            {
                nIsDue = cmbStatus.SelectedIndex - 1;
            }

            int nIsEarlyClose = -1;
            if(cmbIsEarlyClose.SelectedIndex != 0)
            {
                nIsEarlyClose = cmbIsEarlyClose.SelectedIndex - 1;
            }
            int nLoanType = -1;
            if (cmbLoanType.SelectedIndex != 0)
            {
                nLoanType = cmbLoanType.SelectedIndex;
            }
            int nSubLoanType = -1;
            if (cmbSubLoanType.SelectedIndex != 0)
            {
                nSubLoanType = cmbSubLoanType.SelectedIndex;
            }
            HRLoans _oHRLoans = new HRLoans();
            _oHRLoans.GetLoanScheduleForReport(nEmployeeID, nSearchCompanyID, nSearchDepartmentID, nIsDue, nIsEarlyClose, dtMonth.Value.Month, dtMonth.Value.Year, nLoanType, nSubLoanType);

            rptLoansSchedule doc;
            doc = new rptLoansSchedule();

            List<LoanSchedule> PFList = new List<LoanSchedule>();

            foreach (HRLoan aHRLoan in _oHRLoans)
            {
                var PFLoan = new LoanSchedule
                {
                    LoanNo = aHRLoan.LoanNo,
                    BalancePrincipal = aHRLoan.BalancePrincipal,
                    IsEarlyClose = aHRLoan.IsEarlyClose,
                    IsDue = aHRLoan.IsDue,
                    EmployeeCode = aHRLoan.EmployeeCode,
                    EmployeeName = aHRLoan.EmployeeName,
                    DepartmentName = aHRLoan.DepartmentName,
                    LoanTypeName = aHRLoan.LoanTypeName,
                    PrincipalPayable = aHRLoan.PrincipalPayable,
                    InterestPayable = aHRLoan.InterestPayable,
                    TotalPayable = aHRLoan.TotalPayable
                };
                PFList.Add(PFLoan);
            }

            //doc.SetDataSource(_oHRLoans);
            doc.SetDataSource(PFList);

            doc.SetParameterValue("PrintUser", Utility.UserFullname);
            doc.SetParameterValue("Company", cmbCompany.Text);
            doc.SetParameterValue("Department", cmbDepartment.Text);
            doc.SetParameterValue("Month", dtMonth.Text);
            doc.SetParameterValue("Employee", sEmplName);
            doc.SetParameterValue("Status",cmbStatus.Text);
            doc.SetParameterValue("IsEarlyClose",cmbIsEarlyClose.Text);
            if (ctlEmployee1.txtDescription.Text != string.Empty)
            {
                doc.SetParameterValue("Employee", ctlEmployee1.txtCode.Text + "-" + ctlEmployee1.txtDescription.Text);
            }
            else
            {
                doc.SetParameterValue("Employee", "All");
            }
            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;

        }

        private void rdoAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAll.Checked == true)
            {
                lblStatus.Enabled = true;
                cmbStatus.Enabled = true;
                lblIsEarlyClose.Enabled = true;
                cmbIsEarlyClose.Enabled = true;
                cmbLoanType.Enabled = true;
                lblLoanType.Enabled = true;
            }
            else 
            {
                lblStatus.Enabled = false;
                cmbStatus.Enabled = false;
                lblIsEarlyClose.Enabled = false;
                cmbIsEarlyClose.Enabled = false;
                cmbLoanType.Enabled = false;
                lblLoanType.Enabled = false;
            }
            
        }

        private void rdoDisbursement_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDisbursement.Checked == true)
            {
                lblLoanType.Enabled = true;
                cmbLoanType.Enabled = true;
                lblEmployee.Enabled = false;
                ctlEmployee1.Enabled = false;
                ctlEmployee1.txtCode.Text = string.Empty;

            }
            else 
            {
                cmbLoanType.Enabled = false;
                lblLoanType.Enabled = false;
                cmbSubLoanType.Enabled = false;
                lblSubLoanType.Enabled = false;
                lblEmployee.Enabled = true;
                ctlEmployee1.Enabled = true;

            }
        }

        private void cmbLoanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLoanType.SelectedIndex != (int)Dictionary.HRLoanType.Article)
            {
                lblSubLoanType.Enabled = false;
                cmbSubLoanType.Enabled = false;
                cmbSubLoanType.SelectedIndex = 0;
            }
            else
            {
                lblSubLoanType.Enabled = true;
                cmbSubLoanType.Enabled = true;
            }
        }

        private void rdoPFSchedule_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPFSchedule.Checked == true)
            {
                cmbSubLoanType.SelectedIndex = 0;
                cmbLoanType.SelectedIndex = 0;
                cmbStatus.SelectedIndex = 0;
                cmbIsEarlyClose.SelectedIndex = 0;
                lblSubLoanType.Enabled = false;
                cmbSubLoanType.Enabled = false;
            }
                        
        }


    }
}
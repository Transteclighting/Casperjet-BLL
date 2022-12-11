using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;
using CJ.Report.HR;
using CJ.Report;

namespace CJ.Win.HR
{
    public partial class frmPayrollCompareReport : Form
    {
        Companys _oCompanys;
        Departments _oDepartments;
        //Employees oEmployees;
        //EmployeeAllowance _oEmployeeAllowance;
        //EmployeeAllowances _oEmployeeAllowances;

        public frmPayrollCompareReport()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            int nEmployeeID = 0;
            int nCompanyID = 0;
            int nDepartmentID = 0;
            DateTime _Date = dtMonth.Value;
            DateTime _Date1 = dtMonth1.Value;


            if (ctlEmployee1.txtDescription.Text != "")
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }
            if (cmbCompany.SelectedIndex != 0)
            {
                nCompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }
            if (cmbDepartment.SelectedIndex != 0)
            {
                nDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }
            

            this.Cursor = Cursors.WaitCursor;
            EmployeeAllowances _oEmployeeAllowances = new EmployeeAllowances();
            _oEmployeeAllowances.CompareReportData(nEmployeeID, nCompanyID, nDepartmentID, _Date.Month, _Date.Year, _Date1.Month, _Date1.Year, cmbEmployeeType.SelectedIndex, cmbStatus.SelectedIndex);
            rptPayrollCompareReport doc;
            doc = new rptPayrollCompareReport();
            doc.SetDataSource(_oEmployeeAllowances);
            
            doc.SetParameterValue("CompanyName", cmbCompany.Text);
            doc.SetParameterValue("Department", cmbDepartment.Text);
            doc.SetParameterValue("EmployeeType", cmbEmployeeType.Text);
            doc.SetParameterValue("PayrollStatus", cmbStatus.Text);
            doc.SetParameterValue("EmployeeType", cmbEmployeeType.Text);
            doc.SetParameterValue("Employee", ctlEmployee1.txtDescription.Text);
            doc.SetParameterValue("PrintUser", Utility.UserFullname);
            doc.SetParameterValue("Month", dtMonth.Value.ToString("MMM-yyyy"));
            doc.SetParameterValue("CompareMonth", dtMonth1.Value.ToString("MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

            this.Cursor = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayrollCompareReport_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void LoadCombos()
        {
            //Company
            _oCompanys = new Companys();
            _oCompanys.GetCompanyALL();
            cmbCompany.Items.Add("All");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            //Employee Type
            cmbEmployeeType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PayrollType)))
            {
                cmbEmployeeType.Items.Add(Enum.GetName(typeof(Dictionary.PayrollType), GetEnum));
            }
            cmbEmployeeType.SelectedIndex = 0;

            //Status
            cmbStatus.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PayrollStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.PayrollStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.GetDepartmentAll();
            cmbDepartment.Items.Add("All");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmEmployees : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        private JobGrades _oJobGrades;
        private Employee _oEmployee;

        public frmEmployees()
        {
            InitializeComponent();
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            LoadCombos();
            
        }

        private void LoadCombos()
        {

            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh();
            cboCompany.Items.Clear();
            cboCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            cboCompany.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.Refresh();
            cboDepartment.Items.Clear();
            cboDepartment.Items.Add("<All>");
            foreach (Department oDepartment in _oDepartments)
            {
                cboDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cboDepartment.SelectedIndex = 0;

            //JobGrade
            _oJobGrades = new JobGrades();
            _oJobGrades.Refresh();
            cboJobGrade.Items.Clear();
            cboJobGrade.Items.Add("<All>");
            foreach (JobGrade oJobGrade in _oJobGrades)
            {
                cboJobGrade.Items.Add(oJobGrade.JobGradeName);
            }
            cboJobGrade.SelectedIndex = 0;

            //Employee Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.GeneralStatus)))
            {
                cboStatus.Items.Add(Enum.GetName(typeof(Dictionary.GeneralStatus), GetEnum));
            }
            cboStatus.SelectedIndex = (int)Dictionary.GeneralStatus.Active;
        }

        private void DataLoadControl()
        {
            Employees oEmployees = new Employees();
            lvwEmployees.Items.Clear();
            DBController.Instance.OpenNewConnection();

            int nCompanyID = 0;
            if (cboCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;

            int nDepartmentID = 0;
            if (cboDepartment.SelectedIndex > 0) nDepartmentID = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;

            int nJobGradeID = 0;
            if (cboJobGrade.SelectedIndex > 0) nJobGradeID = _oJobGrades[cboJobGrade.SelectedIndex - 1].JobGradeID;

            oEmployees.RefreshDetail(nCompanyID, nDepartmentID, nJobGradeID, txtCode.Text, txtName.Text, (Dictionary.GeneralStatus)cboStatus.SelectedIndex, false);

            this.Text = "Employees  " + "[" + oEmployees.Count + "]";

            foreach (Employee oEmployee in oEmployees)
            {
                ListViewItem oItem = lvwEmployees.Items.Add(oEmployee.EmployeeCode);
                oItem.SubItems.Add(oEmployee.EmployeeName);
                oItem.SubItems.Add(oEmployee.JobGrade.JobGradeName);
                oItem.SubItems.Add(oEmployee.Designation.DesignationName);
                oItem.SubItems.Add(oEmployee.Department.DepartmentName);
                oItem.SubItems.Add(oEmployee.Company.CompanyCode);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HREmployeeStatus), oEmployee.EmpStatus));
                oItem.Tag = oEmployee;
            }
        }


        //private void frmEmployees_Load(object sender, EventArgs e)
        //{
        //    DataLoadControl();
        //}

        public bool ShowDialog(Employee oEmployee)
        {
            _oEmployee = oEmployee;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }


        //private void DataLoadControl()
        //{
        //    Employees oEmployees = new Employees();
        //    lvwEmployees.Items.Clear();
        //    DBController.Instance.OpenNewConnection();
        //    oEmployees.Refresh();

        //    foreach (Employee oEmployee in oEmployees)
        //    {
        //        ListViewItem oItem = lvwEmployees.Items.Add(oEmployee.EmployeeCode);
        //        oItem.SubItems.Add(oEmployee.EmployeeName);
        //        oItem.Tag = oEmployee;
        //    }
        //}

        private void lvwEmployees_DoubleClick(object sender, EventArgs e)
        {

            Employee oEmployee = (Employee)lvwEmployees.SelectedItems[0].Tag;

            _oEmployee.EmployeeCode = oEmployee.EmployeeCode;
            _oEmployee.EmployeeName = oEmployee.EmployeeName;
            this.Close();
        }

        private void lvwEmployees_KeyPress(object sender, KeyPressEventArgs e)
        {

            Employee oEmployee = (Employee)lvwEmployees.SelectedItems[0].Tag;

            _oEmployee.EmployeeCode = oEmployee.EmployeeCode;
            _oEmployee.EmployeeName = oEmployee.EmployeeName;
            this.Close();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

    }
}
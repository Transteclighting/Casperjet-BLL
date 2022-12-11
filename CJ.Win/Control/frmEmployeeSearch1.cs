using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Control
{
    public partial class frmEmployeeSearch1 : Form
    {
        Companys _oCompanys;
        Departments _oDepartments;
        Employees _oSections;
        Employees _oEmployees;
        Employee _oEmployee;
        

        public frmEmployeeSearch1()
        {
            InitializeComponent();
        }

        public bool ShowDialog(Employee oEmployee)
        {
            _oEmployee = oEmployee;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Company
            _oCompanys = new Companys();
            _oCompanys.GetCompanyALL();
            cboCompany.Items.Clear();
            cboCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            cboCompany.SelectedIndex = 0;
            
            
            //Department
            _oDepartments = new Departments();
            _oDepartments.GetDepartmentAll();
            cboDepartment.Items.Clear();
            cboDepartment.Items.Add("<All>");
            foreach (Department oDepartment in _oDepartments)
            {
                cboDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cboDepartment.SelectedIndex = 0;

            //Section
            _oSections = new Employees();
            _oSections.GetSection();
            cmbSection.Items.Clear();
            cmbSection.Items.Add("<All>");
            foreach (Employee oSection in _oSections)
            {
                cmbSection.Items.Add(oSection.SectionName);
            }
            cmbSection.SelectedIndex = 0;

        }

        private void DataLoadControl()
        {
            _oEmployees = new Employees();
            lvwEmployees.Items.Clear();
            DBController.Instance.OpenNewConnection();


            int nCompanyID = 0;
            if (cboCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;

            int nDepartmentID = 0;
            if (cboDepartment.SelectedIndex > 0) nDepartmentID = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;

            int nSectionID = 0;
            if (cmbSection.SelectedIndex > 0) nSectionID = _oSections[cmbSection.SelectedIndex - 1].SectionID;

            _oEmployees.GetEmployeeList(nCompanyID, nDepartmentID, txtEmployeeName.Text, nSectionID);

            this.Text = "Employees  " + "[" + _oEmployees.Count + "]";

            foreach (Employee oEmployee in _oEmployees)
            {
                ListViewItem oItem = lvwEmployees.Items.Add(oEmployee.EmployeeName);
                oItem.SubItems.Add(oEmployee.SectionName);
                oItem.SubItems.Add(oEmployee.DesignationName);
                oItem.SubItems.Add(oEmployee.DepartmentName);
                oItem.SubItems.Add(oEmployee.ComapanyName);
                oItem.Tag = oEmployee;
            }
        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void lvwEmployees_KeyPress(object sender, KeyPressEventArgs e)
        {
            Employee oEmployee = (Employee)lvwEmployees.SelectedItems[0].Tag;

            _oEmployee.EmployeeCode = oEmployee.EmployeeCode;
            _oEmployee.EmployeeName = oEmployee.EmployeeName;
            this.Close();

        }

        private void lvwEmployees_DoubleClick(object sender, EventArgs e)
        {

            Employee oEmployee = (Employee)lvwEmployees.SelectedItems[0].Tag;

            _oEmployee.EmployeeCode = oEmployee.EmployeeCode;
            _oEmployee.EmployeeName = oEmployee.EmployeeName;
            this.Close();

        }

        private void frmEmployeeSearch1_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }
    }
}
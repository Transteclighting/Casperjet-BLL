// <summary>
// Compamy: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Jun 16, 2016
// Time : 04:30 PM
// Description: Module for Payroll Get Employee.
// Modify Person And Date:
// </summary>


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
    public partial class frmPayrollGetEmployee : Form
    {
        Companys _oCompanys;
        Departments _oDepartments;
        public Employees _oEmployees;
        Employees oEmployees;
        string _sDepartmentID = "";
        string _sDesignationID = "";
        int _nCompanyID = 0;
        int _nGradeType = 0;
        string _sCompanyName = "";
        string _sGradeTypeText = "";
        public frmPayrollGetEmployee(int nCompanyID, string sCompanyName, int nGradeType, string sGradeTypeText)
        {
            _nCompanyID = nCompanyID;
            _sCompanyName = sCompanyName;
            _nGradeType = nGradeType;
            _sGradeTypeText = sGradeTypeText;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCombos()
        {
            //Department
            _oDepartments = new Departments();
            _oDepartments.GetDepartmentAll();
            cmbDepartment.Items.Add("All");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;


            //Is Factory Employee
            cmbIsFactoryEmployee.Items.Clear();
            cmbIsFactoryEmployee.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsFactoryEmployee.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsFactoryEmployee.SelectedIndex = 0;
        }

        private void frmPayrollGetEmployee_Load(object sender, EventArgs e)
        {
            LoadCombos();
            lblCompanyName.Text = "Company: " + _sCompanyName;
            lblType.Text = "Grade Type: " + _sGradeTypeText + "";
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void ckbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSelect.Checked == true)
            {
                for (int i = 0; i < lvwEmployee.Items.Count; i++)
                {
                    ListViewItem itm = lvwEmployee.Items[i];

                    lvwEmployee.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwEmployee.Items.Count; i++)
                {
                    ListViewItem itm = lvwEmployee.Items[i];

                    lvwEmployee.Items[i].Checked = false;

                }
            }
        }

        private void DataLoadControl()
        {
            oEmployees = new Employees();
            lvwEmployee.Items.Clear();
            int nEmployeeID = 0;
            string sDeptID = "";
            string sDepartmentID = _sDepartmentID;

            if (sDepartmentID == "")
            {
                if (cmbDepartment.SelectedIndex != 0)
                {
                    sDeptID = Convert.ToString(_oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID);
                }

            }
            if (sDeptID != "")
            {
                sDepartmentID = sDeptID;
            }

            if (ctlEmployee1.txtDescription.Text != "")
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }
            int nIsFactoryEmployee = 0;
            if (cmbIsFactoryEmployee.SelectedIndex == 0)
            {
                nIsFactoryEmployee = -1;
            }
            else
            {
                nIsFactoryEmployee = cmbIsFactoryEmployee.SelectedIndex - 1;
            }
            oEmployees.GetEmployees(_nCompanyID, sDepartmentID, _sDesignationID, nEmployeeID, _nGradeType, nIsFactoryEmployee);

            this.Text = "Total " + "[" + oEmployees.Count + "]";
            foreach (Employee oEmployee in oEmployees)
            {

                ListViewItem oItem = lvwEmployee.Items.Add(oEmployee.EmployeeCode);
                oItem.SubItems.Add(oEmployee.EmployeeName);
                oItem.SubItems.Add(oEmployee.Designation.DesignationName);
                oItem.SubItems.Add(oEmployee.Department.DepartmentName);

                oItem.Tag = oEmployee;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            SetData();
            this.Close();
        }
        
        private void SetData()
        {
            _oEmployees = new Employees();
            for (int i = 0; i < lvwEmployee.Items.Count; i++)
            {
                ListViewItem itm = lvwEmployee.Items[i];
                if (lvwEmployee.Items[i].Checked == true)
                {
                    Employee oEmployee = (Employee)lvwEmployee.Items[i].Tag;
                    _oEmployees.Add(oEmployee);

                }
            }
        }

        private void linklblMultiSelectDepartments_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDepartmentsMultiSelect oForm = new frmDepartmentsMultiSelect();
            oForm.ShowDialog();
            linklblMultiSelectDepartments.Text = "Selected " + oForm._nCount.ToString() + " Departments";
            _sDepartmentID = "";
            _sDepartmentID = oForm._sSelectedDepartmentID;
            if (_sDepartmentID != "")
            {
                cmbDepartment.SelectedIndex = 0;
                cmbDepartment.Enabled = false;
            }
            else
            {
                cmbDepartment.Enabled = true;
            }
        }

        private void linkLabelMultiSelectDesignation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDesignationSearch oForm = new frmDesignationSearch();
            oForm.ShowDialog();
            linkLabelMultiSelectDesignation.Text = "Selected " + oForm._nCount.ToString() + " Designations";
            _sDesignationID = "";
            _sDesignationID = oForm._sSelectedDesignationID;
            //if (_sDepartmentID != "")
            //{
            //    cmbDepartment.SelectedIndex = 0;
            //    cmbDepartment.Enabled = false;
            //}
            //else
            //{
            //    cmbDepartment.Enabled = true;
            //}
        }
    }
}
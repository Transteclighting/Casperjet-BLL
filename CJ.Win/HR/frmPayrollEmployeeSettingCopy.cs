using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win
{
    public partial class frmHRPayrollEmployeeSettingCopy : Form
    {
        int _nUIType = 0;
        Companys _oCompanys;
        Departments _oDepartments;
        Employees oEmployees;
        string _sTitleString = "";
        EmployeeAllowance _oEmployeeAllowance;
        EmployeeAllowances _oEmployeeAllowances;

        public frmHRPayrollEmployeeSettingCopy(int nUIType)
        {
            InitializeComponent();
            _nUIType = nUIType;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_nUIType == 1)//Copy
            {
                if (UIControl())
                {
                    Save();
                    this.Close();
                }
            }
            else
            {

            }
        }

        private bool UIControl()
        {

            DateTime _Date = dtCopyYear.Value;
            int nYear = _Date.Year;
            DateTime _Date1 = dtSetTo.Value;
            int nYear1 = _Date1.Year;
            int nCount = 0;
            for (int i = 0; i < lvwItem.Items.Count; i++)
            {
                ListViewItem itm = lvwItem.Items[i];
                if (lvwItem.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please select employee(s) to copy settings", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (nYear == nYear1)
            {
                MessageBox.Show("Copy Year and Set Year should be different", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbEntryAction.SelectedIndex == 0)
            {
                MessageBox.Show("Please select overwrite action", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmHRPayrollEmployeeSettingCopy_Load(object sender, EventArgs e)
        {
            if (_nUIType == 1)
            {
                _sTitleString = "Employee Settings Copy";
            }
            else
            {
                _sTitleString = "Employee Settings Delete";
            }
            this.Text = _sTitleString;
            LoadCombos();

        }

        private void DataLoadControl()
        {
            oEmployees = new Employees();
            lvwItem.Items.Clear();
            int nEmployeeID = 0;
            string sDepartmentID = "";
            int nCompanyID = 0;

            if (cmbCompany.SelectedIndex != 0)
            {
                nCompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }
            if (cmbDepartment.SelectedIndex != 0)
            {
                sDepartmentID = Convert.ToString(_oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID);
            }
            if (ctlEmployee1.txtDescription.Text != "")
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }
            oEmployees.GetEmployee(nCompanyID, sDepartmentID, nEmployeeID, 0);

            this.Text = _sTitleString + " | Total " + "[" + oEmployees.Count + "]";
            foreach (Employee oEmployee in oEmployees)
            {

                ListViewItem oItem = lvwItem.Items.Add(oEmployee.EmployeeCode);
                oItem.SubItems.Add(oEmployee.EmployeeName);
                oItem.SubItems.Add(oEmployee.Designation.DesignationName);
                oItem.SubItems.Add(oEmployee.Department.DepartmentName);
                oItem.SubItems.Add(oEmployee.Company.CompanyCode);

                oItem.Tag = oEmployee;
            }
        }

        private void LoadCombos()
        {
            //Company
            _oCompanys = new Companys();
            _oCompanys.GetCompanyALL();
            cmbCompany.Items.Add("All");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyCode);
            }
            cmbCompany.SelectedIndex = 0;

            //Status
            cmbEntryAction.Items.Add("Select");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbEntryAction.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbEntryAction.SelectedIndex = 0;

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

        private void Save()
        {

            DateTime _Date = dtCopyYear.Value;
            int nYear = _Date.Year;
            DateTime _Date1 = dtSetTo.Value;
            int nYear1 = _Date1.Year;
            EmployeeAllowance _oEmployeeAllowance = new EmployeeAllowance();

            DBController.Instance.OpenNewConnection();
            DBController.Instance.BeginNewTransaction();
            try
            {


                for (int i = 0; i < lvwItem.Items.Count; i++)
                {
                    ListViewItem itm = lvwItem.Items[i];
                    if (lvwItem.Items[i].Checked == true)
                    {
                        Employee oEmployee = (Employee)lvwItem.Items[i].Tag;

                        int nOverWrite = cmbEntryAction.SelectedIndex - 1;

                        if (nOverWrite == (int)Dictionary.YesOrNoStatus.YES)
                        {

                            _oEmployeeAllowance.Delete(oEmployee.CompanyID, oEmployee.EmployeeID, nYear1);

                            _oEmployeeAllowances = new EmployeeAllowances();
                            _oEmployeeAllowances.Refresh(oEmployee.EmployeeID, oEmployee.CompanyID, nYear);
                           
                            foreach (EmployeeAllowance oEmployeeAllowance in _oEmployeeAllowances)
                            {
                                oEmployeeAllowance.EffectiveYear = nYear1;
                                oEmployeeAllowance.Add();
                            }
                        }
                        else
                        {

                            if (!_oEmployeeAllowance.CheckAllowance(oEmployee.EmployeeID, oEmployee.CompanyID, nYear1))
                            {
                                _oEmployeeAllowances = new EmployeeAllowances();
                                //_oEmployeeAllowances.Refresh(oEmployee.EmployeeID, oEmployee.CompanyID, nYear);
                                _oEmployeeAllowances.Refresh(oEmployee.EmployeeID, 82942, nYear);
                                foreach (EmployeeAllowance oEmployeeAllowance in _oEmployeeAllowances)
                                {
                                    oEmployeeAllowance.EffectiveYear = nYear1;
                                    oEmployeeAllowance.Add();
                                }
                            }

                        }

                    }
                }


                DBController.Instance.CommitTran();
                MessageBox.Show("Data Save Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error Saving Data:\n" + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                for (int i = 0; i < lvwItem.Items.Count; i++)
                {
                    ListViewItem itm = lvwItem.Items[i];

                    lvwItem.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwItem.Items.Count; i++)
                {
                    ListViewItem itm = lvwItem.Items[i];

                    lvwItem.Items[i].Checked = false;

                }
            }
        }
    }
}
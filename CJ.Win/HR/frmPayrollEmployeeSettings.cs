using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Library;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmPayrollEmployeeSettings : Form
    {
        Companys _oCompanys;
        Departments _oDepartments;
        EmployeeAllowances _oEmployeeAllowances;
        TELLib oTELLib;

        public frmPayrollEmployeeSettings()
        {
            InitializeComponent();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SetSetting();
        }

        private void SetSetting()
        {
            if (lvwEmployeeSettings.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to set Salary", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EmployeeAllowance oEmployeeAllowance = (EmployeeAllowance)lvwEmployeeSettings.SelectedItems[0].Tag;
            frmPayrollEmployeeSetting oForm = new frmPayrollEmployeeSetting();
            oForm.ShowDialog(oEmployeeAllowance);
            if (oForm._bFlag == false)
            {
                DataLoadControl();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            if (_oCompanys.Count == 0)
            {
                cmbCompany.Items.Add("No Permission!!");
            }
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            //Status
            cmbStatus.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
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

        private void frmPayrollEmployeeSettings_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oEmployeeAllowances = new EmployeeAllowances();
            lvwEmployeeSettings.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            int nEmployeeID = 0;
            int nCompanyID = 0;
            int nDepartmentID = 0;
            DateTime _Date = dtSalaryMonth.Value;
            int nYear = _Date.Year;
            if (ctlEmployee1.txtDescription.Text != "")
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }
            if (_oCompanys.Count < 1)
            {
                nCompanyID = -1;
            }
            else
            {
                nCompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
            }
            
            if (cmbDepartment.SelectedIndex != 0)
            {
                nDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }

            _oEmployeeAllowances.RefreshDetail(nCompanyID, nEmployeeID, nDepartmentID, cmbStatus.SelectedIndex - 1, nYear);

            this.Text = "Employee Payroll Settings | Total: " + "[" + _oEmployeeAllowances.Count + "]";
            foreach (EmployeeAllowance oEmployeeAllowance in _oEmployeeAllowances)
            {
                oTELLib = new TELLib();
                ListViewItem oItem = lvwEmployeeSettings.Items.Add(oEmployeeAllowance.Code);
                oItem.SubItems.Add(oEmployeeAllowance.Name);
                oItem.SubItems.Add(oEmployeeAllowance.Designation);
                oItem.SubItems.Add(oEmployeeAllowance.DepartmentName);
                oItem.SubItems.Add(oEmployeeAllowance.CompanyName);
                oItem.SubItems.Add(oEmployeeAllowance.EffectiveYear.ToString());
                oItem.SubItems.Add(oTELLib.TakaFormat(oEmployeeAllowance.Amount));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oEmployeeAllowance.IsSet));

                oItem.Tag = oEmployeeAllowance;
            }
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwEmployeeSettings.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwEmployeeSettings.Items)
                {
                    if (oItem.SubItems[7].Text == Dictionary.YesOrNoStatus.YES.ToString())
                    {
                        oItem.BackColor = Color.White;
                    }
                    else
                    {
                        oItem.BackColor = Color.LightPink;
                    }
                }
            }
        }

        private void lvwEmployeeSettings_DoubleClick(object sender, EventArgs e)
        {
            SetSetting();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            frmHRPayrollEmployeeSettingCopy _ofrom = new frmHRPayrollEmployeeSettingCopy(1);
            _ofrom.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmHRPayrollEmployeeSettingCopy _ofrom = new frmHRPayrollEmployeeSettingCopy(2);
            _ofrom.ShowDialog();
        }
    }
}
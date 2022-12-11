using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmOutStationDutyList : Form
    {
        Companys _oCompanys;
        Departments _oDepartments;
        public frmOutStationDutyList()
        {
            InitializeComponent();
        }

        private void frmOutStationDutyList_Load(object sender, EventArgs e)
        {
            LoadCombos();
            //DataLoadControl();
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Company
            _oCompanys = new Companys();
            _oCompanys.GetCompanyALL();
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.GetDepartmentAll();
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("<All>");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;
        }
        private void DataLoadControl()
        {
            //Employee
            int nEmployeeID;
            if (ctlEmployee1.txtDescription.Text != String.Empty)
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }
            else
            {
                nEmployeeID = -1;
            }

            //Company
            int nCompanyID;
            if (cmbCompany.SelectedIndex == 0)
            {
                nCompanyID = -1;
            }
            else
            {
                nCompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }

            //Department
            int nDepartmentID;
            if (cmbDepartment.SelectedIndex == 0)
            {
                nDepartmentID = -1;
            }
            else
            {
                nDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }
           

            //Start Date Rang
            string _dtStartDateFrom;
            string _dtStartDateTo;
            if (!chkEnableDisableStartDateRange.Checked)
            {
                _dtStartDateFrom = dtStartDateFrom.Value.Date.ToShortDateString();
                _dtStartDateTo = dtStartDateTo.Value.Date.ToShortDateString();
            }
            else
            {
                _dtStartDateFrom = String.Empty;
                _dtStartDateTo = String.Empty;
            }

            //End Date Rang
            string _dtEndDateFrom;
            string _dtEndDateTo;
            if (!chkEnableDisableEndDateRange.Checked)
            {
                _dtEndDateFrom = dtEndDateFrom.Value.Date.ToShortDateString();
                _dtEndDateTo = dtEndDateTo.Value.Date.ToShortDateString();
                
            }
            else
            {
                _dtEndDateFrom = String.Empty;
                _dtEndDateTo = String.Empty;            
            }            
               

            OutStationDuties oOutStationDuties = new OutStationDuties();
            lvwEmployeeOutDuty.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oOutStationDuties.Refresh(nEmployeeID, nCompanyID, nDepartmentID, _dtStartDateFrom, _dtStartDateTo, _dtEndDateFrom, _dtEndDateTo);
            this.Text = "Employee Out Sation Duty " + "[" + oOutStationDuties.Count + "]";
            foreach (OutStationDuty oOutStationDuty in oOutStationDuties)
            {
                ListViewItem oItem = lvwEmployeeOutDuty.Items.Add(oOutStationDuty.Employee.EmployeeCode);
                oItem.SubItems.Add(oOutStationDuty.Employee.EmployeeName);
                oItem.SubItems.Add(oOutStationDuty.StartDate.ToShortDateString());
                oItem.SubItems.Add(oOutStationDuty.EndDate.ToShortDateString());
                oItem.SubItems.Add(oOutStationDuty.Adderss.ToString());
                oItem.SubItems.Add(oOutStationDuty.Remarks);
                oItem.Tag = oOutStationDuty;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOutStationDuty oForm = new frmOutStationDuty();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwEmployeeOutDuty.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OutStationDuty oOutStationDuty = (OutStationDuty)lvwEmployeeOutDuty.SelectedItems[0].Tag;
            frmOutStationDuty oForm = new frmOutStationDuty();
            oForm.ShowDialog(oOutStationDuty);
            DataLoadControl();
        }
     

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwEmployeeOutDuty.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OutStationDuty oOutStationDuty = (OutStationDuty)lvwEmployeeOutDuty.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Duty ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oOutStationDuty.Delete();
                    DBController.Instance.CommitTransaction();
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkEnableDisableFromDateRanf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableDisableStartDateRange.Checked == true)
            {
                dtStartDateFrom.Enabled = false;
                dtStartDateTo.Enabled = false;
            }
            else
            {
                dtStartDateFrom.Enabled = true;
                dtStartDateTo.Enabled = true;
            }
        }

        private void chkEnableDisableToDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableDisableEndDateRange.Checked == true)
            {
                dtEndDateFrom.Enabled = false;
                dtEndDateTo.Enabled = false;
            }
            else
            {
                dtEndDateFrom.Enabled = true;
                dtEndDateTo.Enabled = true;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoadControl();

        }

      

       
    }
}
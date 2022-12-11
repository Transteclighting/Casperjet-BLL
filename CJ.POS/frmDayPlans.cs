using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.POS
{
    public partial class frmDayPlans : Form
    {
        DayPlans _oDPs = new DayPlans();
        private Employees _oEmployees;
        bool IsCheck = false;
        public frmDayPlans()
        {
            InitializeComponent();
            LoadCombo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDayPlan oForm = new frmDayPlan();
            oForm.ShowDialog();
        }
        public void LoadCombo()
        {
            _oEmployees = new Employees();
            cmbEmpoyee.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oEmployees.GetShowroomSalesPerson();
            cmbEmpoyee.Items.Add("<Select Sales Person>");
            foreach (Employee oEmployee in _oEmployees)
            {
                cmbEmpoyee.Items.Add(oEmployee.EmployeeName);
            }
            if (_oEmployees.Count > 0)
                cmbEmpoyee.SelectedIndex = 0;

        }
        private void LoadData()
        {
            lvwDayPlans.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int nEmployeeID = 0;
            DateTime? dFromDate = null;
            DateTime? dToDate = null;
            try
            {
                nEmployeeID = _oEmployees[cmbEmpoyee.SelectedIndex - 1].EmployeeID;
            }
            catch
            {
                nEmployeeID = 0;
            }
        
            if(!IsCheck)
            {
                dFromDate = dtFromdate.Value;
                dToDate = dtTodate.Value;
            }

            _oDPs = new DayPlans();
            _oDPs.Refresh(txtPlanNo.Text.Trim(), nEmployeeID, dFromDate, dToDate);
            foreach (DayPlan oDP in _oDPs)
            {
                ListViewItem oItem = lvwDayPlans.Items.Add(oDP.PlanNo);
                oItem.SubItems.Add(oDP.EmployeeName);
                oItem.SubItems.Add(oDP.LocationName);
                oItem.SubItems.Add("Create");

                oItem.Tag = oDP;
            }

        }

        private void frmDayPlans_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwDayPlans.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DayPlan oDP = (DayPlan)lvwDayPlans.SelectedItems[0].Tag;

            frmDayPlan oForm = new frmDayPlan();
            oForm.ShowDialog(oDP);
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }
    }
}

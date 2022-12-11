using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.HR
{
    public partial class frmAnnualLeavePlans : Form
    {
        bool IsCheck = false;
        HRAnnualLeavePlans _oHRAnnualLeavePlans;

        public frmAnnualLeavePlans()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAnnualLeavePlan oFrom = new frmAnnualLeavePlan();
            oFrom.ShowDialog();
            DataLoadControl();
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
        private void DataLoadControl()
        {
            _oHRAnnualLeavePlans = new HRAnnualLeavePlans();
            lvwAnnualLeavePlan.Items.Clear();

            DBController.Instance.OpenNewConnection();
            _oHRAnnualLeavePlans.RefreshData(dtFromdate.Value.Date, dtTodate.Value.Date, txtEmpName.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (HRAnnualLeavePlan oHRAnnualLeavePlan in _oHRAnnualLeavePlans)
            {
                ListViewItem oItem = lvwAnnualLeavePlan.Items.Add(Convert.ToInt32(oHRAnnualLeavePlan.LeavePlanID).ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oHRAnnualLeavePlan.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oHRAnnualLeavePlan.EmployeeName.ToString());
                oItem.SubItems.Add(oHRAnnualLeavePlan.DepartmentName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oHRAnnualLeavePlan.FromDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDateTime(oHRAnnualLeavePlan.ToDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oHRAnnualLeavePlan.InChargeName.ToString());
                oItem.SubItems.Add(Convert.ToInt16(oHRAnnualLeavePlan.LeaveTotal).ToString());
                oItem.Tag = oHRAnnualLeavePlan;
            }
        }


        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwAnnualLeavePlan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HRAnnualLeavePlan oHRAnnualLeavePlan = (HRAnnualLeavePlan)lvwAnnualLeavePlan.SelectedItems[0].Tag;
            frmAnnualLeavePlan oForm = new frmAnnualLeavePlan();
            oForm.ShowDialog(oHRAnnualLeavePlan);
            DataLoadControl();

        }

        private void frmAnnualLeavePlans_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
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
    public partial class frmHRPayrollAddDeducts : Form
    {
        HRPayrollAddDeducts _oHRPayrollAddDeducts;
        Companys _oCompanys;
        bool IsCheck = false;
        public frmHRPayrollAddDeducts()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHRPayrollAddDeduct oform = new frmHRPayrollAddDeduct();
            oform.ShowDialog();
            if (oform.IsExecute)
            {
                DataLoadControl();
            }
        }

        private void LoadCombos()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("All");

            //Stock Requisition Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PayrollAddDeductStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.PayrollAddDeductStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cmbCompany.Items.Clear();
            if (_oCompanys.Count > 1)
            {
                cmbCompany.Items.Add("All");
            }
            if (_oCompanys.Count == 0)
            {
                cmbCompany.Items.Add("No Permission!!");
            }
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyCode);
            }
            cmbCompany.SelectedIndex = 0;

        }

        private void frmHRPayrollAddDeducts_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            if (lvwItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            HRPayrollAddDeduct oHRPayrollAddDeduct = (HRPayrollAddDeduct)lvwItems.SelectedItems[0].Tag;
            if (oHRPayrollAddDeduct.Status != (int)Dictionary.PayrollAddDeductStatus.Create)
            {
                MessageBox.Show("Only create status data could be Edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmHRPayrollAddDeduct oform = new frmHRPayrollAddDeduct();
            oform.ShowDialog(oHRPayrollAddDeduct);
            if (oform.IsExecute)
            {
                DataLoadControl();
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (lvwItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Approve.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            HRPayrollAddDeduct oHRPayrollAddDeduct = (HRPayrollAddDeduct)lvwItems.SelectedItems[0].Tag;
            if (oHRPayrollAddDeduct.Status != (int)Dictionary.PayrollAddDeductStatus.Create)
            {
                MessageBox.Show("Only create status data could be Approved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to Approve Data: " + oHRPayrollAddDeduct.ID.ToString() + " ? ", "Confirm Ticket Approve", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRPayrollAddDeduct.Status = (int)Dictionary.PayrollAddDeductStatus.Approve;
                    oHRPayrollAddDeduct.ApproveBy = Utility.UserId;
                    oHRPayrollAddDeduct.ApproveDate = DateTime.Now;
                    oHRPayrollAddDeduct.Approve();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Approved data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            HRPayrollAddDeduct oHRPayrollAddDeduct = (HRPayrollAddDeduct)lvwItems.SelectedItems[0].Tag;
            if (oHRPayrollAddDeduct.Status != (int)Dictionary.PayrollAddDeductStatus.Create)
            {
                MessageBox.Show("Only create status data could be deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Data: " + oHRPayrollAddDeduct.ID.ToString() + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oHRPayrollAddDeduct.Delete();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Deleted data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void DataLoadControl()
        {
            _oHRPayrollAddDeducts = new HRPayrollAddDeducts();
            int nCompanyID = 0;
            int nEmployeeID = 0;
            nCompanyID = GetCompanyID(_oCompanys);
            if (ctlEmployee1.txtDescription.Text != "")
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }
            DateTime _Date = dtMonth.Value;
            lvwItems.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oHRPayrollAddDeducts.Refresh(nCompanyID, nEmployeeID, _Date.Month, _Date.Year, cmbStatus.SelectedIndex, IsCheck);
            this.Text = "Payroll Add/Deduct | Total: " + "[" + _oHRPayrollAddDeducts.Count + "]";
            foreach (HRPayrollAddDeduct oHRPayrollAddDeduct in _oHRPayrollAddDeducts)
            {
                ListViewItem oItem = lvwItems.Items.Add(oHRPayrollAddDeduct.CompanyCode);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayrollAddDeduct.Month));
                oItem.SubItems.Add(oHRPayrollAddDeduct.Year.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.AllowanceDeductionType), oHRPayrollAddDeduct.Type));
                oItem.SubItems.Add(oHRPayrollAddDeduct.AllowanceName);
                oItem.SubItems.Add(oHRPayrollAddDeduct.Amount.ToString());
                oItem.SubItems.Add(oHRPayrollAddDeduct.EmployeeName + " [" + oHRPayrollAddDeduct.EmployeeCode + "]");
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.PayrollAddDeductStatus), oHRPayrollAddDeduct.Status));
                oItem.SubItems.Add(oHRPayrollAddDeduct.CreateUser);
                oItem.SubItems.Add(Convert.ToDateTime(oHRPayrollAddDeduct.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oHRPayrollAddDeduct.ApproveUser);
                if (oHRPayrollAddDeduct.ApproveDate != null)
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oHRPayrollAddDeduct.ApproveDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    oItem.SubItems.Add("");
                }
                oItem.SubItems.Add(oHRPayrollAddDeduct.Remarks);
                oItem.Tag = oHRPayrollAddDeduct;

                if (oHRPayrollAddDeduct.Status == (int)Dictionary.PayrollAddDeductStatus.Create)
                {
                    oItem.BackColor = Color.DarkSalmon;
                }
                else
                {
                    oItem.BackColor = Color.White;
                }
            }
        }

        private int GetCompanyID(Companys oCompanys)
        {
            int nCompanyID;
            if (_oCompanys.Count == 1)
            {
                nCompanyID = oCompanys[cmbCompany.SelectedIndex].CompanyID; // Only one company
            }
            else if (_oCompanys.Count > 1)
            {
                try
                {
                    nCompanyID = oCompanys[cmbCompany.SelectedIndex - 1].CompanyID; // Specific company from all 
                }
                catch
                {
                    nCompanyID = 0; // All Selection
                }
            }
            else
            {
                nCompanyID = -1; // No Permission
            }

            return nCompanyID;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtMonth.Enabled = false;
                lblMonth.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtMonth.Enabled = true;
                lblMonth.Enabled = true;
                IsCheck = false;
            }
        }

        private void lvwItems_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            frmAllowanceDeductUploader ofrmAllowanceDeductUploader = new frmAllowanceDeductUploader();
            ofrmAllowanceDeductUploader.ShowDialog();
            DBController.Instance.OpenNewConnection();
            DataLoadControl();
        }
    }
}
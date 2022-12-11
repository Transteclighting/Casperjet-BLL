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
    public partial class frmAllowanceDeducts : Form
    {
        AllowanceDeductions _oAllowanceDeductions;

        public frmAllowanceDeducts()
        {
            InitializeComponent();
        }
        private void LoadCombo()
        {
            //IsActive
            cmbIsActive.Items.Clear();
            cmbIsActive.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsActive)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.IsActive), GetEnum));
            }
            cmbIsActive.SelectedIndex = 0;

            //Allowance Deduction Type
            cmbType.Items.Clear();
            cmbType.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.AllowanceDeductionType)))
            {
                cmbType.Items.Add(Enum.GetName(typeof(Dictionary.AllowanceDeductionType), GetEnum));
            }
            cmbType.SelectedIndex = 0;

        }

        private void DataLoadControl()
        {
            _oAllowanceDeductions = new AllowanceDeductions();
            lvwAllowanceDeducts.Items.Clear();

            int nIsActive = 0;
            if (cmbIsActive.SelectedIndex == 0)
            {
                nIsActive = -1;
            }
            else
            {
                nIsActive = cmbIsActive.SelectedIndex - 1;
            }
            int nType = 0;
            if (cmbType.SelectedIndex == 0)
            {
                nType = -1;
            }
            else
            {
                nType = cmbType.SelectedIndex;
            }
            DBController.Instance.OpenNewConnection();

            _oAllowanceDeductions.RefreshData(txtCode.Text.Trim(), txtName.Text.Trim(), nIsActive, nType);
            DBController.Instance.CloseConnection();

            foreach (AllowanceDeduction oAllowanceDeduction in _oAllowanceDeductions)
            {
                ListViewItem oItem = lvwAllowanceDeducts.Items.Add(oAllowanceDeduction.Code.ToString());
                oItem.SubItems.Add(oAllowanceDeduction.Name.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oAllowanceDeduction.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.AllowanceDeductionType), oAllowanceDeduction.Type));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oAllowanceDeduction.IsActive));
                oItem.Tag = oAllowanceDeduction;
            }
            this.Text = "Allowance & Deduction" + "(" + _oAllowanceDeductions.Count + ")";
        }

        private void frmAllowanceDeducts_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombo();
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAllowanceDeduct oForm = new frmAllowanceDeduct();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwAllowanceDeducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AllowanceDeduction oAllowanceDeduction = (AllowanceDeduction)lvwAllowanceDeducts.SelectedItems[0].Tag;
            frmAllowanceDeduct oForm = new frmAllowanceDeduct();
            oForm.ShowDialog(oAllowanceDeduction);
            DataLoadControl();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void lvwAllowanceDeducts_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
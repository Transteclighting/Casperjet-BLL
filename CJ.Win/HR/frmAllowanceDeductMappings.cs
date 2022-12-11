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
    public partial class frmAllowanceDeductMappings : Form
    {
        AllowanceDeductions _oAllowanceDeductions;
        JobGrades _oJobGrades;
        Companys _oCompanys;

        public frmAllowanceDeductMappings()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCombo()
        {

            //Allowance Deduction Type
            cmbType.Items.Clear();
            cmbType.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.AllowanceDeductionType)))
            {
                cmbType.Items.Add(Enum.GetName(typeof(Dictionary.AllowanceDeductionType), GetEnum));
            }
            cmbType.SelectedIndex = 0;

            //Job Grades
            _oJobGrades = new JobGrades();
            _oJobGrades.Refresh();
            cmbGrade.Items.Clear();
            cmbGrade.Items.Add("--Select--");
            foreach (JobGrade oJobGrade in _oJobGrades)
            {
                cmbGrade.Items.Add(oJobGrade.JobGradeCode);
            }
            cmbGrade.SelectedIndex = 0;

            //Company
            _oCompanys = new Companys();
            _oCompanys.RefreshByCompany("ALL");
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("--Select--");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

        }

        private void DataLoadControl()
        {
            _oAllowanceDeductions = new AllowanceDeductions();
            lvwAllowanceDeductMapping.Items.Clear();

            int nType = 0;
            if (cmbType.SelectedIndex == 0)
            {
                nType = -1;
            }
            else
            {
                nType = cmbType.SelectedIndex;
            }

            int nJobGrade = 0;
            if (cmbGrade.SelectedIndex == 0)
            {
                nJobGrade = -1;
            }
            else
            {
                nJobGrade = _oJobGrades[cmbGrade.SelectedIndex - 1].JobGradeID;
            }

            int nCompany = 0;
            if (cmbCompany.SelectedIndex == 0)
            {
                nCompany = -1;
            }
            else
            {
                nCompany = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }

            DBController.Instance.OpenNewConnection();

            _oAllowanceDeductions.RefreshMappingData(nType, nJobGrade, nCompany);
            DBController.Instance.CloseConnection();

            foreach (AllowanceDeduction oAllowanceDeduction in _oAllowanceDeductions)
            {
                ListViewItem oItem = lvwAllowanceDeductMapping.Items.Add(oAllowanceDeduction.GradeName.ToString());
                oItem.SubItems.Add(oAllowanceDeduction.CompanyName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oAllowanceDeduction.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oAllowanceDeduction.Name.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.AllowanceDeductionType), oAllowanceDeduction.Type));
                oItem.SubItems.Add(Convert.ToDouble(oAllowanceDeduction.Amount).ToString());
                
                oItem.Tag = oAllowanceDeduction;
            }
            this.Text = "Grade Wise Allowance & Deduction Mapping" + "(" + _oAllowanceDeductions.Count + ")";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAllowanceDeductMapping oForm = new frmAllowanceDeductMapping();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwAllowanceDeductMapping.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AllowanceDeduction oAllowanceDeduction = (AllowanceDeduction)lvwAllowanceDeductMapping.SelectedItems[0].Tag;
            frmAllowanceDeductMapping oForm = new frmAllowanceDeductMapping();
            oForm.ShowDialog(oAllowanceDeduction);
            DataLoadControl();

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmAllowanceDeductMappings_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombo();
            DataLoadControl();
        }

        private void lvwAllowanceDeductMapping_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
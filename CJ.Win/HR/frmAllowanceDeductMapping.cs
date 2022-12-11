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
    public partial class frmAllowanceDeductMapping : Form
    {
        Companys _oCompanys;
        JobGrades _oJobGrades;
        AllowanceDeductions _oAllowanceDeductions;
        AllowanceDeduction _oAllowanceDeduction;
        int nADID = 0;
        int nMAPID = 0;
        int nGradeID = 0;

        public frmAllowanceDeductMapping()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(AllowanceDeduction oAllowanceDeduction)
        {
            this.Tag = oAllowanceDeduction;
            DBController.Instance.OpenNewConnection();
            nADID = 0;
            nADID = oAllowanceDeduction.ID;
            nGradeID = 0;
            nGradeID = oAllowanceDeduction.GradeID;
            LoadCombos();
            nMAPID = oAllowanceDeduction.MapID;

            int nADIndex = 0;
            nADIndex = _oAllowanceDeductions.GetIndex(oAllowanceDeduction.ID);
            cmbAD.SelectedIndex = nADIndex; 

            int nGradIndex = 0;
            nGradIndex = _oJobGrades.GetIndex(oAllowanceDeduction.GradeID);
            cmbGrade.SelectedIndex = nGradIndex + 1;

            int nCompanyIndex = 0;
            nCompanyIndex = _oCompanys.GetIndex(oAllowanceDeduction.CompanyID);
            cmbCompany.SelectedIndex = nCompanyIndex + 1;

            txtAmount.Text = Convert.ToString(oAllowanceDeduction.Amount);

            this.ShowDialog();
        }

        private void LoadCombos()
        {

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

            //Allowance Deductions
            _oAllowanceDeductions = new AllowanceDeductions();
            _oAllowanceDeductions.Refresh();
            cmbAD.Items.Clear();
            //cmbAD.Items.Add("--Select--");
            foreach (AllowanceDeduction oAllowanceDeduction in _oAllowanceDeductions)
            {
                cmbAD.Items.Add("[" + oAllowanceDeduction.Code + "]" + oAllowanceDeduction.Name);
            }
            cmbAD.SelectedIndex = 0;

        }
        private bool UIValidation()
        {
            #region ValidInput
            if (cmbGrade.SelectedIndex == null)
            {
                MessageBox.Show("Please Select Job Grade", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGrade.Focus();
                return false;
            }
            if (cmbCompany.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Company Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCompany.Focus();
                return false;
            }
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }
            #endregion

            return true;

        }
        private void Save()
        {
            if (this.Tag == null)
            {
                _oAllowanceDeduction = new AllowanceDeduction();

                _oAllowanceDeduction.ID = _oAllowanceDeductions[cmbAD.SelectedIndex].ID;
                _oAllowanceDeduction.GradeID = _oJobGrades[cmbGrade.SelectedIndex - 1].JobGradeID;
                _oAllowanceDeduction.CompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
                _oAllowanceDeduction.Amount = Convert.ToDouble(txtAmount.Text);
                _oAllowanceDeduction.CreateDate = DateTime.Now.Date;
                _oAllowanceDeduction.CreateUserID = Utility.UserId;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oAllowanceDeduction.AddADMapping();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction. JobGradeName : " + _oJobGrades[cmbGrade.SelectedIndex - 1].JobGradeName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                _oAllowanceDeduction = new AllowanceDeduction();
                _oAllowanceDeduction.MapID = nMAPID;
                _oAllowanceDeduction.ID = _oAllowanceDeductions[cmbAD.SelectedIndex].ID;
                _oAllowanceDeduction.GradeID = _oJobGrades[cmbGrade.SelectedIndex - 1].JobGradeID;
                _oAllowanceDeduction.CompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
                _oAllowanceDeduction.Amount = Convert.ToDouble(txtAmount.Text);
                _oAllowanceDeduction.UpdateDate = DateTime.Now.Date;
                _oAllowanceDeduction.UpdateUserID = Utility.UserId;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oAllowanceDeduction.EditADMapping();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Updated The  JobGradeName: " + _oJobGrades[cmbGrade.SelectedIndex - 1].JobGradeName, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
            }
        }

        private void frmAllowanceDeductMapping_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New Mapping";
                DBController.Instance.OpenNewConnection();
                LoadCombos();

            }
            else
            {
                this.Text = "Edit Mapping";
            }
        }

        private void cmbAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            
            //Job Grades
            _oJobGrades = new JobGrades();
            _oJobGrades.Refresh(_oAllowanceDeductions[cmbAD.SelectedIndex].ID, nADID, nGradeID);
            cmbGrade.Items.Clear();
            cmbGrade.Items.Add("--Select--");
            foreach (JobGrade oJobGrade in _oJobGrades)
            {
                cmbGrade.Items.Add(oJobGrade.JobGradeCode);
            }
            cmbGrade.SelectedIndex = 0;

        }
    }
}
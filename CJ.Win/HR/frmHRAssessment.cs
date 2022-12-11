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
    public partial class frmHRAssessment : Form
    {
        public bool _bActionSave = false;

        private HRAssessments _oHRAssessments;
        private HRAssessment _oHRAssessment;
        public frmHRAssessment()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            dtFromDate.Value = DateTime.Today.Date;
            dtToDate.Value = DateTime.Today.Date;
            dtTargetFrom.Value = DateTime.Today.Date;
            dtTargetTo.Value = DateTime.Today.Date;

            udAssessmentYear.Text = DateTime.Now.Year.ToString();

            udLastPromotion.Text = DateTime.Now.Year.ToString();

            cmbAssessmentType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRAssessmentType)))
            {
                cmbAssessmentType.Items.Add(Enum.GetName(typeof(Dictionary.HRAssessmentType), GetEnum));
            }
            cmbAssessmentType.SelectedIndex = 0;
        }

        public void ShowDialog(HRAssessment oHRAssessment)
        {
            this.Tag = oHRAssessment;
            this.Text = "Edit Assessment Data";
            LoadCombos();
            ctlEmployee1.txtCode.Text = oHRAssessment.EmployeeCode;
            ctlEmployee2.txtCode.Text = oHRAssessment.LineManagerCode;

            cmbAssessmentType.SelectedIndex = oHRAssessment.AssessmentType - 1;

            //cmbAssessmentType.SelectedIndex = _oHRAssessments.GetIndex(oHRAssessment.AssessmentType) + 1;
            if (oHRAssessment.AssessmentYear != 0)
            {
                udAssessmentYear.Value = oHRAssessment.AssessmentYear;
                chkPromotionYear.Checked = true;
                udAssessmentYear.Enabled = true;
            }
            else
            {
                udAssessmentYear.Value = 2000;
                chkPromotionYear.Checked = false;
                udAssessmentYear.Enabled = false;
            }

           dtFromDate.Value = oHRAssessment.FromDate;
            dtToDate.Value = oHRAssessment.ToDate;
            txtBasicSalary.Text = oHRAssessment.BasicSalary.ToString();
            txtGrossSalary.Text = oHRAssessment.GrossSalary.ToString();
            txtLastIncrementAmount.Text = oHRAssessment.IncrementAmount.ToString();
            udLastPromotion.Text = oHRAssessment.YearofLastPromotion.ToString();
            txtxAcademicQualification.Text = oHRAssessment.AcademicQualification;
            txtSalesTarget.Text = oHRAssessment.SalesTarget.ToString();
            txtSalesActual.Text = oHRAssessment.Achievement.ToString();

            try
            {
                dtTargetFrom.Value = oHRAssessment.TargetForm;
            }
            catch
            {
                dtTargetFrom.Value = DateTime.Now.Date;
            }


            try
            {
                dtTargetTo.Value = oHRAssessment.ToDate;
            }
            catch
            {
                dtTargetTo.Value = DateTime.Now.Date;
            }


            if (oHRAssessment.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            this.ShowDialog();
        }

        private void ctlEmployee1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlEmployee1.txtDescription.Text != "")
            {
                _oHRAssessment = new HRAssessment();

                DBController.Instance.CheckConnection();

                _oHRAssessment.FindEmployeeDetails(ctlEmployee1.SelectedEmployee.EmployeeID);
                ctlEmployee2.txtCode.Text = _oHRAssessment.EmployeeCode;
            }

            if (ctlEmployee1.txtCode.Text.Length == 0)
            {
                ctlEmployee2.txtCode.Text = "";
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }

        private void Save()
        {
            if (this.Tag == null)
            {

                HRAssessment oHRAssessment = new HRAssessment();

                oHRAssessment.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                oHRAssessment.DesignationID = ctlEmployee1.SelectedEmployee.DesignationID;
                oHRAssessment.DepartmentID = ctlEmployee1.SelectedEmployee.DepartmentID;
                oHRAssessment.CompanyID = ctlEmployee1.SelectedEmployee.CompanyID;

                oHRAssessment.LineManagerID = ctlEmployee2.SelectedEmployee.EmployeeID;

                //oHRAssessment.AssessmentType = _oHRAssessments[cmbAssessmentType.SelectedIndex - 1].AssessmentType;
                oHRAssessment.AssessmentType = (int)Enum.Parse(typeof(Dictionary.HRAssessmentType), cmbAssessmentType.SelectedItem.ToString());

                oHRAssessment.AssessmentYear = Int32.Parse(udAssessmentYear.Text);
                oHRAssessment.BasicSalary = Convert.ToDouble(txtBasicSalary.Text);
                oHRAssessment.GrossSalary = Convert.ToDouble(txtGrossSalary.Text);
                oHRAssessment.IncrementAmount = Convert.ToDouble(txtLastIncrementAmount.Text);

                if (chkPromotionYear.Checked == true)
                {
                    oHRAssessment.YearofLastPromotion = Int32.Parse(udLastPromotion.Text);
                }
                else
                {
                    oHRAssessment.YearofLastPromotion = -1;
                }

                //else
                //{
                //    oHRAssessment.YearofLastPromotion = null;
                //}


                oHRAssessment.AcademicQualification = txtxAcademicQualification.Text;

                if (txtSalesTarget.Text != "")
                {
                    oHRAssessment.SalesTarget = Convert.ToDouble(txtSalesTarget.Text);
                }
                else
                    oHRAssessment.SalesTarget = 0;

                if (txtSalesActual.Text != "")
                {
                    oHRAssessment.Achievement = Convert.ToDouble(txtSalesActual.Text);
                }
                else
                    oHRAssessment.Achievement = 0;

                oHRAssessment.FromDate = dtFromDate.Value.Date;
                oHRAssessment.ToDate = dtToDate.Value.Date;

                oHRAssessment.TargetForm = dtTargetFrom.Value.Date;
                oHRAssessment.TargetTo = dtTargetTo.Value.Date;

                oHRAssessment.IsActive = (int)Dictionary.YesOrNoStatus.YES;

                oHRAssessment.Status = (int)Dictionary.HRAssessmentStatus.Ready_To_Assess;

                try
                {
                    DBController.Instance.CheckConnection();
                    DBController.Instance.BeginNewTransaction();
                    oHRAssessment.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                HRAssessment oHRAssessment = (HRAssessment)this.Tag;

                oHRAssessment.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                oHRAssessment.DesignationID = ctlEmployee1.SelectedEmployee.DesignationID;
                oHRAssessment.DepartmentID = ctlEmployee1.SelectedEmployee.DepartmentID;
                oHRAssessment.CompanyID = ctlEmployee1.SelectedEmployee.CompanyID;

                oHRAssessment.LineManagerID = ctlEmployee2.SelectedEmployee.EmployeeID;

                oHRAssessment.AssessmentType = (int)Enum.Parse(typeof(Dictionary.HRAssessmentType), cmbAssessmentType.SelectedItem.ToString());

                oHRAssessment.AssessmentYear = Int32.Parse(udAssessmentYear.Text);
                oHRAssessment.BasicSalary = Convert.ToDouble(txtBasicSalary.Text);
                oHRAssessment.GrossSalary = Convert.ToDouble(txtGrossSalary.Text);
                oHRAssessment.IncrementAmount = Convert.ToDouble(txtLastIncrementAmount.Text);

                if (chkPromotionYear.Checked == true)
                {
                    oHRAssessment.YearofLastPromotion = Int32.Parse(udLastPromotion.Text);
                }
                else
                {
                    oHRAssessment.YearofLastPromotion = -1;
                }

                oHRAssessment.AcademicQualification = txtxAcademicQualification.Text;
                oHRAssessment.SalesTarget = Convert.ToDouble(txtSalesTarget.Text);
                oHRAssessment.Achievement = Convert.ToDouble(txtSalesActual.Text);

                oHRAssessment.FromDate = dtFromDate.Value.Date;
                oHRAssessment.ToDate = dtToDate.Value.Date;

                oHRAssessment.TargetForm = dtTargetFrom.Value.Date;
                oHRAssessment.TargetTo = dtTargetTo.Value.Date;

                if (chkIsActive.Checked)
                {
                    oHRAssessment.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oHRAssessment.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }

                oHRAssessment.Status = (int)Dictionary.HRAssessmentStatus.Ready_To_Assess;

                try
                {
                    DBController.Instance.CheckConnection();
                    DBController.Instance.BeginNewTransaction();
                    oHRAssessment.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }



        private bool UIValidation()
        {
            if (ctlEmployee1.txtCode.Text == "")
            {
                MessageBox.Show("Please select an employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.txtCode.Focus();
                return false;
            }

            //if (cmbAssessmentType.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please select a assessment type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbAssessmentType.Focus();
            //    return false;
            //}

            if (txtBasicSalary.Text == "")
            {
                MessageBox.Show("Please enter basic salary", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBasicSalary.Focus();
                return false;
            }

            if (txtGrossSalary.Text == "")
            {
                MessageBox.Show("Please enter gross salary", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGrossSalary.Focus();
                return false;
            }

            if (txtLastIncrementAmount.Text == "")
            {
                MessageBox.Show("Please enter last increament", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastIncrementAmount.Focus();
                return false;
            }


            if (udLastPromotion.Text == "")
            {
                MessageBox.Show("Please enter last promotion", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                udLastPromotion.Focus();
                return false;
            }


            if (ctlEmployee2.txtCode.Text == "")
            {
                MessageBox.Show("Please select line manager", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee2.txtCode.Focus();
                return false;
            }

            if (txtxAcademicQualification.Text == "")
            {
                MessageBox.Show("Please enter academic qualification", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtxAcademicQualification.Focus();
                return false;
            }



            //EMIBankMapping oEMIBankMapping = new EMIBankMapping();
            //oEMIBankMapping.BankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
            //oEMIBankMapping.EMITenureID = _oEMITenures[cmbTenure.SelectedIndex - 1].EMITenureID;
            //checkDuplicateValue = oEMIBankMapping.CheckDuplicateData();

            //if (checkDuplicateValue == "Yes")
            //{
            //    MessageBox.Show("Bank EMI already exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbTenure.Focus();
            //    return false;
            //}

            return true;

        }

        private void frmHRAssessment_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Assessment Data";
                LoadCombos();
            }

            udLastPromotion.Enabled = false;
        }

        private void txtBasicSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtGrossSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtLastIncrementAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtSalesTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtSalesActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void chkPromotionYear_CheckedChanged(object sender, EventArgs e)
        {

            if (chkPromotionYear.Checked == true)
            {
                udLastPromotion.Enabled = chkPromotionYear.Checked;
            }

            else
            {
                udLastPromotion.Enabled = false;
            }

        }

    }
}
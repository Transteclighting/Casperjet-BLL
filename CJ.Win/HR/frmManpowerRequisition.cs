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
    public partial class frmManpowerRequisition : Form
    {
        Departments _oDepartments;
        Designations _oDesignations;
        JobGrades _oJobGrades;
        HRPositions _oHRPositions;
        HRManpowerRequisition _oHRManpowerRequisition;


        public frmManpowerRequisition()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            dtRequisitionDate.Value = DateTime.Today;
            //Vacancy Type
            cmbVacancyType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRManpowerVacancyType)))
            {
                cmbVacancyType.Items.Add(Enum.GetName(typeof(Dictionary.HRManpowerVacancyType), GetEnum));
            }
            cmbVacancyType.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.RefreshDepartment();
            cmbDepartment.Items.Clear();
            //cmbDepartment.Items.Add("<All>");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;

            //PositionLevel
            cmbPositionLevel.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRManpowerPositionLevel)))
            {
                cmbPositionLevel.Items.Add(Enum.GetName(typeof(Dictionary.HRManpowerPositionLevel), GetEnum));
            }
            cmbPositionLevel.SelectedIndex = 0;

            //Designation
            _oDesignations = new Designations();
            _oDesignations.Refresh();
            cmbDesignation.Items.Clear();
            //cmbDesignation.Items.Add("<All>");
            foreach (Designation oDesignation in _oDesignations)
            {
                cmbDesignation.Items.Add(oDesignation.DesignationName);
            }
            cmbDesignation.SelectedIndex = 0;


            //JobGrade
            _oJobGrades = new JobGrades();
            _oJobGrades.Refresh();
            cmbJobGrade.Items.Clear();
            //cmbJobGrade.Items.Add("<All>");
            foreach (JobGrade oJobGrade in _oJobGrades)
            {
                cmbJobGrade.Items.Add(oJobGrade.JobGradeName);
            }
            cmbJobGrade.SelectedIndex = 0;


            //AgeLevel
            cmbAgeLevel.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRManpowerAgeLevel)))
            {
                string sAgeLevel = "";
                if (GetEnum == (int)Dictionary.HRManpowerAgeLevel.Eighteen_Plus)
                {
                    sAgeLevel = "18+";
                }
                else if (GetEnum == (int)Dictionary.HRManpowerAgeLevel.Twenty_Plus)
                {
                    sAgeLevel = "20+";
                }
                else if (GetEnum == (int)Dictionary.HRManpowerAgeLevel.TwentyFive_Plus)
                {
                    sAgeLevel = "25+";
                }
                else if (GetEnum == (int)Dictionary.HRManpowerAgeLevel.Thirty_Plus)
                {
                    sAgeLevel = "30+";
                }
                else if (GetEnum == (int)Dictionary.HRManpowerAgeLevel.Forty_Plus)
                {
                    sAgeLevel = "40+";
                }
                else if (GetEnum == (int)Dictionary.HRManpowerAgeLevel.Fifty_Plus)
                {
                    sAgeLevel = "50+";
                }
                cmbAgeLevel.Items.Add(sAgeLevel.ToString());
            }
            cmbAgeLevel.SelectedIndex = 0;


            // EmploymentType
            cmbEmploymentType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRManpowerEmployeementType)))
            {
                cmbEmploymentType.Items.Add(Enum.GetName(typeof(Dictionary.HRManpowerEmployeementType), GetEnum));
            }
            cmbEmploymentType.SelectedIndex = 0;

            //HRManpowerContractPeriod
            cmbContractPeriod.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRManpowerContractPeriod)))
            {
                string ContractPeriod = "";
                if (GetEnum == (int)Dictionary.HRManpowerContractPeriod.Six_Months)
                {
                    ContractPeriod = "06 Months";
                }
                else if (GetEnum == (int)Dictionary.HRManpowerContractPeriod.One_Year)
                {
                    ContractPeriod = "01 Year";
                }
                else if (GetEnum == (int)Dictionary.HRManpowerContractPeriod.Others)
                {
                    ContractPeriod = "Others";
                }
                else if (GetEnum == (int)Dictionary.HRManpowerContractPeriod.NA)
                {
                    ContractPeriod = "Not Applicable";
                }
                cmbContractPeriod.Items.Add(ContractPeriod.ToString());
            }
            cmbContractPeriod.SelectedIndex = 0;

            //Employment Status
            cmbEmploymentStatus.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRManpowerEmploymentStatus)))
            {
                cmbEmploymentStatus.Items.Add(Enum.GetName(typeof(Dictionary.HRManpowerEmploymentStatus), GetEnum));
            }
            cmbEmploymentStatus.SelectedIndex = 0;

            //EducationalQualification
            cmbEducationalQualification.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRManpowerEducationalQualification)))
            {
                cmbEducationalQualification.Items.Add(Enum.GetName(typeof(Dictionary.HRManpowerEducationalQualification), GetEnum));
            }
            cmbEducationalQualification.SelectedIndex = 0;

            //Experience
            cmbExperience.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRManpowerExperience)))
            {
                string sManpowerExperience = "";
                if (GetEnum == (int)Dictionary.HRManpowerExperience.Fresh_Six_Month_Plus)
                {
                    sManpowerExperience = "Fresh/06 Months+";
                }
                else if (GetEnum == (int)Dictionary.HRManpowerExperience.Three_Year_Plus)
                {
                    sManpowerExperience = "03 Years+";
                }
                else if (GetEnum == (int)Dictionary.HRManpowerExperience.Five_Year_Plus)
                {
                    sManpowerExperience = "05 Years+";
                }
                else if (GetEnum == (int)Dictionary.HRManpowerExperience.Ten_Year_Plus)
                {
                    sManpowerExperience = "10 Years+";
                }

                cmbExperience.Items.Add(sManpowerExperience.ToString());
            }
            cmbExperience.SelectedIndex = 0;

            //Department
            _oHRPositions = new HRPositions();
            _oHRPositions.GetPositionByCompany(Utility.CompanyInfo);
            cmbReportto.Items.Clear();
            //cmbReportto.Items.Add("<All>");
            foreach (HRPosition oHRPosition in _oHRPositions)
            {
                cmbReportto.Items.Add(oHRPosition.PositionName);
            }
            cmbReportto.SelectedIndex = 0;

            //WithinBudget
            cmbWithinBudget.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbWithinBudget.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbWithinBudget.SelectedIndex = 0;

            //AdditionBudget
            cmbAdditionBudget.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbAdditionBudget.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbAdditionBudget.SelectedIndex = 0;

            
        }

        private void frmManpowerRequisition_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {

            if (txtNoofVacancy.Text == "")
            {
                MessageBox.Show("Please enter No of Vacancy", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoofVacancy.Focus();
                return false;
            }

            if (txtEducationMajorArea.Text == "")
            {
                MessageBox.Show("Please enter education major Area", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEducationMajorArea.Focus();
                return false;
            }
            if (txtSalaryRange.Text == "")
            {
                MessageBox.Show("Please enter salary range", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalaryRange.Focus();
                return false;
            }
            if (txtResponsibilityArea.Text == "")
            {
                MessageBox.Show("Please enter responsibility area", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtResponsibilityArea.Focus();
                return false;
            }


            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
            }

        }
        private void Save()
        {
            _oHRManpowerRequisition = new HRManpowerRequisition();
            _oHRManpowerRequisition.RequisitionDate = dtRequisitionDate.Value.Date;
            _oHRManpowerRequisition.VacancyType = cmbVacancyType.SelectedIndex;
            _oHRManpowerRequisition.ReplacementDetail = txtReplacementInfo.Text.Trim();
            _oHRManpowerRequisition.DepartmentID = _oDepartments[cmbDepartment.SelectedIndex].DepartmentID;
            _oHRManpowerRequisition.DesignationID = _oDesignations[cmbDesignation.SelectedIndex].DesignationID;
            _oHRManpowerRequisition.NoOfVacancy = Convert.ToInt32(txtNoofVacancy.Text);
            _oHRManpowerRequisition.Grade = _oJobGrades[cmbJobGrade.SelectedIndex].JobGradeID;
            _oHRManpowerRequisition.ContractPeriod = cmbContractPeriod.SelectedIndex;
            _oHRManpowerRequisition.EmployeeStatus = cmbEmploymentStatus.SelectedIndex;
            _oHRManpowerRequisition.EducationalQualification = cmbEducationalQualification.Text;
            _oHRManpowerRequisition.EducationMajor = txtEducationMajorArea.Text;
            _oHRManpowerRequisition.Age = cmbAgeLevel.Text;
            _oHRManpowerRequisition.Experience = cmbExperience.Text;
            _oHRManpowerRequisition.SalaryRange = Convert.ToDouble(txtSalaryRange.Text);
            _oHRManpowerRequisition.Reportto = _oHRPositions[cmbReportto.SelectedIndex].PositionID;
            _oHRManpowerRequisition.WithinBudget = cmbWithinBudget.SelectedIndex;
            _oHRManpowerRequisition.AdditionBudget = cmbAdditionBudget.SelectedIndex;
            _oHRManpowerRequisition.Others = txtOthers.Text;
            _oHRManpowerRequisition.Responsibility = txtResponsibilityArea.Text;
            _oHRManpowerRequisition.CreateUserID = Utility.UserId;
            _oHRManpowerRequisition.CreateDate = DateTime.Now.Date;


            try
            {
                DBController.Instance.BeginNewTransaction();
                _oHRManpowerRequisition.Add();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Add Manpower Requisition", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }



    }
}
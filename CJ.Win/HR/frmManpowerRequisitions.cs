using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using CJ.Report.HR;
using CJ.Class.Library;

namespace CJ.Win.HR
{
    public partial class frmManpowerRequisitions : Form
    {
        Departments _oDepartments;
        HRManpowerRequisitions _oHRManpowerRequisitions;
        HRManpowerRequisition _oHRManpowerRequisition;
        bool IsCheck = false;

        public frmManpowerRequisitions()
        {
            InitializeComponent();
        }

        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            _oHRManpowerRequisitions = new HRManpowerRequisitions();
            lvwHRManpowerRequisitions.Items.Clear();
            int nDepartmentID = 0;
            if (cmbDepartment.SelectedIndex == 0)
            {
                nDepartmentID = -1;
            }
            else
            {
                nDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }

            DBController.Instance.OpenNewConnection();
            _oHRManpowerRequisitions.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtMRNo.Text.Trim(), nDepartmentID, IsCheck);
            DBController.Instance.CloseConnection();
            foreach (HRManpowerRequisition oHRManpowerRequisition in _oHRManpowerRequisitions)
            {
                ListViewItem oItem = lvwHRManpowerRequisitions.Items.Add(oHRManpowerRequisition.MRNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oHRManpowerRequisition.RequisitionDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HRManpowerVacancyType), oHRManpowerRequisition.VacancyType));
                oItem.SubItems.Add(oHRManpowerRequisition.ReplacementDetail.ToString());
                oItem.SubItems.Add(oHRManpowerRequisition.DepartmentName.ToString());
                oItem.SubItems.Add(oHRManpowerRequisition.DesignationName.ToString());
                oItem.SubItems.Add(Convert.ToInt32(oHRManpowerRequisition.NoOfVacancy).ToString());
                oItem.SubItems.Add(oHRManpowerRequisition.JobGradeName.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HRManpowerEmployeementType), oHRManpowerRequisition.TypeOfEmployment));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HRManpowerContractPeriod), oHRManpowerRequisition.ContractPeriod));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HRManpowerEmploymentStatus), oHRManpowerRequisition.EmployeeStatus));
                oItem.SubItems.Add(oHRManpowerRequisition.EducationalQualification.ToString());
                oItem.SubItems.Add(oHRManpowerRequisition.EducationMajor.ToString());
                oItem.SubItems.Add(oHRManpowerRequisition.Age.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oHRManpowerRequisition.SalaryRange).ToString());
                oItem.SubItems.Add(oHRManpowerRequisition.PositionName.ToString());
                oItem.Tag = oHRManpowerRequisition;
            }
            this.Cursor = Cursors.Default;
        }
        private void LoadCombos()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;


            //Department
            _oDepartments = new Departments();
            _oDepartments.RefreshDepartment();
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("<All>");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmManpowerRequisitions_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (lvwHRManpowerRequisitions.SelectedItems.Count != 0)
            {
                this.Cursor = Cursors.WaitCursor;
                int nMRID = 0;

                _oHRManpowerRequisition = (HRManpowerRequisition)lvwHRManpowerRequisitions.SelectedItems[0].Tag;

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptManPowerRequisition));
                oReport.SetDataSource(_oHRManpowerRequisition);


                oReport.SetParameterValue("MRNo", _oHRManpowerRequisition.MRNo);
                oReport.SetParameterValue("RequisitionDate", _oHRManpowerRequisition.RequisitionDate.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("VacancyType", Enum.GetName(typeof(Dictionary.HRManpowerVacancyType), _oHRManpowerRequisition.VacancyType));
                oReport.SetParameterValue("ReplacementDetail", _oHRManpowerRequisition.ReplacementDetail);
                oReport.SetParameterValue("DepartmentName", _oHRManpowerRequisition.DepartmentName);
                oReport.SetParameterValue("DesignationName", _oHRManpowerRequisition.DesignationName);
                oReport.SetParameterValue("NoOfVacancy", _oHRManpowerRequisition.NoOfVacancy);
                oReport.SetParameterValue("JobGradeName", _oHRManpowerRequisition.JobGradeName);
                oReport.SetParameterValue("TypeOfEmployment", Enum.GetName(typeof(Dictionary.HRManpowerEmployeementType), _oHRManpowerRequisition.TypeOfEmployment));
                oReport.SetParameterValue("ContractPeriod", Enum.GetName(typeof(Dictionary.HRManpowerContractPeriod), _oHRManpowerRequisition.ContractPeriod));
                oReport.SetParameterValue("EmployeementStatus", Enum.GetName(typeof(Dictionary.HRManpowerEmploymentStatus), _oHRManpowerRequisition.EmployeeStatus));
                oReport.SetParameterValue("EducationalQualification", _oHRManpowerRequisition.EducationalQualification);
                oReport.SetParameterValue("EducationMajor", _oHRManpowerRequisition.EducationMajor);
                oReport.SetParameterValue("Age", _oHRManpowerRequisition.Age);
                TELLib oTELLib = new TELLib();
                oReport.SetParameterValue("SalaryRange", oTELLib.TakaFormat( _oHRManpowerRequisition.SalaryRange) );
                oReport.SetParameterValue("ReportTo", _oHRManpowerRequisition.PositionName);

                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmManpowerRequisition ofrmManpowerRequisition = new frmManpowerRequisition();
            ofrmManpowerRequisition.ShowDialog();
        }
    }
}
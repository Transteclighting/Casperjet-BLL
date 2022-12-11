using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;
using CJ.Report;
using CJ.Report.HR;

namespace CJ.Win.HR
{
    public partial class frmEmployees : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        private JobGrades _oJobGrades;
        HRDivisions oHRDivisions;
        SBUs _oSBUs;
        Employees _oSections;
        JobLocations _oJobLocations;
        public frmEmployees()
        {
            InitializeComponent();
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            LoadCombos();
            //DataLoadControl();
        }

        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cboCompany.Items.Clear();
            if (_oCompanys.Count > 1)
            {
                cboCompany.Items.Add("<All>");
            }
            else if (_oCompanys.Count == 0)
            {
                cboCompany.Items.Add("No Permission!!");
            }
            foreach (Company oCompany in _oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            cboCompany.SelectedIndex = 0;




            //Division
            oHRDivisions = new HRDivisions();
            oHRDivisions.Refresh();
            cmbDivision.Items.Clear();
            cmbDivision.Items.Add("<ALL>");
            foreach (HRDivision oHRDivision in oHRDivisions)
            {
                cmbDivision.Items.Add(oHRDivision.DivisionName);
            }
            cmbDivision.SelectedIndex = 0;

            //BU
            _oSBUs = new SBUs();
            _oSBUs.Refresh();
            cmbBU.Items.Clear();
            cmbBU.Items.Add("<ALL>");
            foreach (SBU oSBU in _oSBUs)
            {
                cmbBU.Items.Add(oSBU.SBUName);
            }
            cmbBU.SelectedIndex = 0;


            //JobGrade
            _oJobGrades = new JobGrades();
            _oJobGrades.Refresh();
            cboJobGrade.Items.Clear();
            cboJobGrade.Items.Add("<All>");
            foreach (JobGrade oJobGrade in _oJobGrades)
            {
                cboJobGrade.Items.Add(oJobGrade.JobGradeName);
            }
            cboJobGrade.SelectedIndex = 0;

            //Employee Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.GeneralStatus)))
            {
                cboStatus.Items.Add(Enum.GetName(typeof(Dictionary.GeneralStatus), GetEnum));
            }
            cboStatus.SelectedIndex = (int)Dictionary.GeneralStatus.Active;

            //Sections
            _oSections = new Employees();
            _oSections.GetSection();
            cmbSection.Items.Clear();
            cmbSection.Items.Add("<All>");
            foreach (Employee oEmployee in _oSections)
            {
                cmbSection.Items.Add(oEmployee.SectionName);
            }
            cmbSection.SelectedIndex = 0;



            //Location
            _oJobLocations = new JobLocations();
            _oJobLocations.Refresh();
            cboJobLocation.Items.Clear();
            cboJobLocation.Items.Add("<All>");
            foreach (JobLocation oJobLocation in _oJobLocations)
            {
                cboJobLocation.Items.Add(oJobLocation.JobLocationName);
            }
            cboJobLocation.SelectedIndex = 0;

        }

        private int GetCompanyID(Companys oCompanys)
        {
            int nCompanyID;
            if (_oCompanys.Count == 1)
            {
                nCompanyID = oCompanys[cboCompany.SelectedIndex].CompanyID; // Only one company
            }
            else if (_oCompanys.Count > 1)
            {
                try
                {
                    nCompanyID = oCompanys[cboCompany.SelectedIndex - 1].CompanyID; // Specific company from all 
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


        private void DataLoadControl()
        {
            Employees oEmployees = new Employees();
            lvwEmployees.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            int nCompanyID = 0;
            nCompanyID = GetCompanyID(_oCompanys);


            int nDivisionID = 0;
            if (cmbDivision.SelectedIndex > 0) nDivisionID = oHRDivisions[cmbDivision.SelectedIndex - 1].DivisionID;


            int nDepartmentID = 0;
            if (cboDepartment.SelectedIndex > 0) nDepartmentID = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;

            int nJobGradeID = 0;
            if (cboJobGrade.SelectedIndex > 0) nJobGradeID = _oJobGrades[cboJobGrade.SelectedIndex - 1].JobGradeID;


            int nSBUID = 0;
            if (cmbBU.SelectedIndex > 0) nSBUID = _oSBUs[cmbBU.SelectedIndex - 1].SBUID;

            int nSectionID = 0;
            if (cmbSection.SelectedIndex > 0) nSectionID = _oSections[cmbSection.SelectedIndex - 1].SectionID;
            
            
            int nJobLocation = 0;

            //_oJobLocations[cboJobLocation.SelectedIndex].JobLocationID;
            if (cboJobLocation.SelectedIndex > 0) nJobLocation = _oJobLocations[cboJobLocation.SelectedIndex - 1].JobLocationID;


            oEmployees.RefreshDetails(nCompanyID, nDepartmentID, nJobGradeID, ctlEmployee1.txtCode.Text, ctlEmployee1.txtDescription.Text, (Dictionary.GeneralStatus)cboStatus.SelectedIndex, chkIsFactoryEmployee.Checked, nDivisionID, nSBUID, nSectionID, nJobLocation);

            this.Text = "Employees  " + "[" + oEmployees.Count + "]";

            foreach (Employee oEmployee in oEmployees)
            {
                ListViewItem oItem = lvwEmployees.Items.Add(oEmployee.EmployeeCode);
                oItem.SubItems.Add(oEmployee.EmployeeName);
                oItem.SubItems.Add(oEmployee.JobGrade.JobGradeName);
                oItem.SubItems.Add(oEmployee.Designation.DesignationName);
                oItem.SubItems.Add(oEmployee.SectionName);
                oItem.SubItems.Add(oEmployee.Department.DepartmentName);
                oItem.SubItems.Add(oEmployee.DivisionName);
                oItem.SubItems.Add(oEmployee.JobLocation.JobLocationName);
                oItem.SubItems.Add(oEmployee.SBUName);
                oItem.SubItems.Add(oEmployee.Company.CompanyCode);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HREmployeeStatus), oEmployee.EmpStatus));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesNAStatus), oEmployee.IsFactory));


               
                oItem.Tag = oEmployee;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmployee oForm = new frmEmployee();
            oForm.ShowDialog();
            if (oForm._bActionSave)
                DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwEmployees.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Employee to Print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Employee oEmp = (Employee)lvwEmployees.SelectedItems[0].Tag;
            Employees oEmployees = new Employees();
            oEmployees.GetEmployee(oEmp.EmployeeID);
            rptServiceBook oReport = new rptServiceBook();
            oReport.SetDataSource(oEmployees);
            oReport.SetParameterValue("DOB", oEmployees[0].DateOfBirth.ToString("dd-MMM-yyyy"));

            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReport);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwEmployees.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Employee to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Employee oEmployee = (Employee)lvwEmployees.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Employee: " + oEmployee.EmployeeCode + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEmployee.Delete();
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

        private void lvwEmployees_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void Edit()
        {
            if (lvwEmployees.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Employee to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Employee oEmployee = (Employee)lvwEmployees.SelectedItems[0].Tag;
            frmEmployee oForm = new frmEmployee();
            oForm.ShowDialog(oEmployee);
            if (oForm._bActionSave)
                DataLoadControl();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbDivision.SelectedIndex > 0)
            {
                //Department
                _oDepartments = new Departments();
                _oDepartments.GetDepartmentByDivisionID(oHRDivisions[cmbDivision.SelectedIndex - 1].DivisionID);
                cboDepartment.Items.Clear();
                cboDepartment.Items.Add("<All>");
                foreach (Department oDepartment in _oDepartments)
                {
                    cboDepartment.Items.Add(oDepartment.DepartmentName);
                }
                cboDepartment.SelectedIndex = 0;
            }
            else
            {
                cboDepartment.Items.Clear();
                cboDepartment.Items.Add("<All>");
                cboDepartment.SelectedIndex = 0;
            }
        }
    }
}
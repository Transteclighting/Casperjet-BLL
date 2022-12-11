using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Plan;
using CJ.Class.Library;
using CJ.Class.POS;
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Configuration;
using CJ.Class.HR;

namespace CJ.Win
{
    public partial class frmEmployee : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        private Designations _oDesignations;
        private JobLocations _oJobLocations;
        private JobLocation _oJobLocation;
        private JobGrades _oJobGrades;
        private JobGrades _oEquivalentGrades;
        private Shifts _oShifts;
        private Employees _oEmployees;
        Employee oEmployee;
        DataSyncManager _oDataSyncManager;
        int nEmployeeID;
        private Banks _oBanks;
        DateTime dtConfirmDate = DateTime.Now.Date;
        DateTime dtSeparationDate = DateTime.Now.Date;
        Employees _oSections;
        public bool _bActionSave = false;
        byte[] photo_aray;
        int nCompany = 0;
        int nDepartment = 0;
        int nDesignation = 0;
        int nJobGrade = 0;
        int nEquivalentGrade = 0;
        int nLocation = 0;
        int nShift = 0;
        int nStatus = 0;
        int nSection = 0;
        int nBU = 0;
        int nOutletEmployeeType = 0;
        Employees _oOutletEmployees = new Employees();

        string sCompany = "";
        string sDepartment = "";
        string sDesignation = "";
        string sJobGrade = "";
        string sEquivalentGrade = "";
        string sLocation = "";
        string sShift = "";
        string sStatus = "";
        string sSection = "";
        string sBU = "";
        string sOutletEmployeeType = "";
        SBUs _oSBUs;
        HRDivisions oHRDivisions;
        MemoryStream ms;
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void GetPicture(int nEMployeeID)

        {
            string[] sConn;
            string[] sConnDB;
            string[] sConnSV;
            string[] sUserID;
            string[] sPassword;
            string _sConnDB;
            string _sConnSV;
            string _sUserID;
            string _sPassword;
            sConn = ConfigurationManager.AppSettings["ConnectionString"].Split(';');
            sConnDB = sConn[1].Split('=');
            _sConnDB = sConnDB[1].ToString();
            sConnSV = sConn[2].Split('=');
            _sConnSV = sConnSV[1].ToString();

            sUserID = sConn[3].Split('=');
            _sUserID = sUserID[1].ToString();
            sPassword = sConn[4].Split('=');
            _sPassword = sPassword[1].ToString();
            SqlConnection con = new SqlConnection("Data Source=" + _sConnSV + ";Initial Catalog=" + _sConnDB + ";User ID=" + _sUserID + ";Password=" + _sPassword + "");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM t_Employee where EmployeeID =" + nEMployeeID + "", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["EmployeePhoto"]);
                    pictureBox.Image = new Bitmap(ms);
                }
                catch
                {

                }
            }
        }

        public void ShowDialog(Employee oEmployee)
        {
            this.Tag = oEmployee;
            dtEffectiveDate.Visible = true;
            lblEffectiveDate.Visible = true;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            GetPicture(oEmployee.EmployeeID);

            LoadCombos();
            cboStatus.SelectedIndex = oEmployee.EmpStatus;
            nEmployeeID = oEmployee.EmployeeID;
            txtCode.Text = oEmployee.EmployeeCode;
            txtName.Text = oEmployee.EmployeeName;
            cboCompany.SelectedIndex = _oCompanys.GetIndex(oEmployee.CompanyID) + 1;
            cmbDivision.SelectedIndex = oHRDivisions.GetIndex(oEmployee.DivisionID) + 1;
            cboDesignation.SelectedIndex = _oDesignations.GetIndex(oEmployee.DesignationID);
            cboJobGrade.SelectedIndex = _oJobGrades.GetIndex(oEmployee.GradeID);
            cboJobLocation.SelectedIndex = _oJobLocations.GetIndex(oEmployee.LocationID);
            cmbEquivalentGrade.SelectedIndex = _oEquivalentGrades.GetIndex(oEmployee.EquivalentGradeID);
            cboDepartment.SelectedIndex = _oDepartments.GetIndex(oEmployee.DepartmentID) + 1;
            cmbBU.SelectedIndex = _oSBUs.GetIndex(oEmployee.SBUID);

            txtPresentAddress.Text = oEmployee.PresentAddress;
            txtPermanantAddress.Text = oEmployee.PermanantAddress;
            txtNationalID.Text = oEmployee.NationalID;
            txtTINNo.Text = oEmployee.TINNo;
            txtBloodGroup.Text = oEmployee.BloodGroup;



            if (oEmployee.IsFactory == (int)Dictionary.YesNAStatus.Yes)
            {
                chkIsFactoryEmp.Checked = true;
            }
            else
            {
                chkIsFactoryEmp.Checked = false;
            }
            if (oEmployee.IsEligibleForLateSMS == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkLateSMS.Checked = true;
            }
            else
            {
                chkLateSMS.Checked = false;
            }

            int nBankIndex = _oBanks.GetIndexByID(oEmployee.EBankID);
            if (oEmployee.EBankID == 0)
            {
                cmbBank.SelectedIndex = 0;
            }
            else
            {
                cmbBank.SelectedIndex = nBankIndex + 1;
            }

            if (oEmployee.Gender == "Male")
            {
                cmbGender.SelectedIndex = 1;
            }
            else if (oEmployee.Gender == "Female")
            {
                cmbGender.SelectedIndex = 2;
            }
            else
            {
                cmbGender.SelectedIndex = 0;
            }

            txtBankAccNo.Text = oEmployee.BankAccountNo;
            dtpBirthDate.Value = oEmployee.DateOfBirth;
            dtpJoiningDate.Value = oEmployee.JoiningDate;
            cboShift.SelectedIndex = _oShifts.GetIndex(oEmployee.ShiftID);


            nCompany = oEmployee.CompanyID;
            nDepartment = oEmployee.DepartmentID;
            nDesignation = oEmployee.DesignationID;
            nJobGrade = oEmployee.GradeID;
            nLocation = oEmployee.LocationID;
            nEquivalentGrade = oEmployee.EquivalentGradeID;
            nShift = oEmployee.ShiftID;
            nStatus = oEmployee.EmpStatus;
            cmbSection.SelectedIndex = _oSections.GetSectionIndex(oEmployee.SectionID) + 1;
            nSection = oEmployee.SectionID;
            nBU = oEmployee.SBUID;

            sCompany = oEmployee.Company.CompanyName;
            sDepartment = oEmployee.Department.DepartmentName;
            sDesignation = oEmployee.Designation.DesignationName;
            sJobGrade = oEmployee.JobGrade.JobGradeName;
            sEquivalentGrade = cmbEquivalentGrade.Text;
            sLocation = oEmployee.JobLocation.JobLocationName;
            sShift = oEmployee.Shift.ShiftName;
            sStatus = cboStatus.Text;
            sSection = cmbSection.Text;
            sBU = cmbBU.Text;

            btnAddDesignation.Enabled = false;
            cmbFloor.SelectedIndex = oEmployee.Floor;
            cmbRoom.Text = oEmployee.Room;
            cmbShowAttnRpt.SelectedIndex = oEmployee.ShowAttendanceRpt;
            txtContactNo.Text = oEmployee.Mobile;
            if (oEmployee.IsWFH == (int)Dictionary.YesNAStatus.Yes)
            {
                cbIsWFH.Checked = true;
            }
            else
            {
                cbIsWFH.Checked = false;
            }


            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            Employee _oEmpBasicSalary = new Employee();
            _oEmpBasicSalary.EmployeeID = nEmployeeID;
            _oEmpBasicSalary.GetBasicSalary();
            txtBasicSalary.Text = _oEmpBasicSalary.BasicSalary.ToString();
            txtEmergencyContact.Text = _oEmpBasicSalary.EmergencyContact;
            txtEmergencyContactRelationship.Text = _oEmpBasicSalary.EmergencyContactRelationship;
            dtConfirmDate = Convert.ToDateTime(_oEmpBasicSalary.ConfirmDate);
            dtSeparationDate = Convert.ToDateTime(_oEmpBasicSalary.SeparationDate);

            //Employee _oEmpstatus = new Employee();
            //_oEmpstatus.EmployeeID = nEmployeeID;
            //_oEmpstatus.EmployeeStatus();


            if (_oEmpBasicSalary.IsPayrollEmployee == (int)Dictionary.YesNAStatus.Yes)
            {
                chkIsPayrollEmployee.Checked = true;
            }
            else
            {
                chkIsPayrollEmployee.Checked = false;
            }
          
            //if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Confirmed)
            //{
            //    lblText.Visible = true;
            //    dtDate.Enabled = true;
            //    lblText.Text = "Confirm Date";
            //    dtDate.Value = dtConfirmDate;
            //}
            //else if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Contractual || cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.NotEmployed)
            //{
            //    lblText.Visible = false;
            //    dtDate.Enabled = false;
            //}
            //else
            //{
            //    lblText.Visible = true;
            //    dtDate.Visible = true;
            //    dtDate.Enabled = false;
            //    lblText.Text = "Effective  Date";
            //    dtDate.Value = dtSeparationDate;
            //}

            Employees oGetOutletEmployees = new Employees();
            if (oGetOutletEmployees.GetOutletEmployeeNew(nEmployeeID) != 0)
            {
                _oOutletEmployees = oGetOutletEmployees;
                lbloutletemployeetype.Visible = true;
                lblProductCategory.Visible = true;
                cmboutletemployeetype.Visible = true;
                //cmbProductCategory.Visible = true;
                dgvProductCategory.Visible = true;

                //cmbProductCategory.SelectedIndex = oGetOutletEmployee.ProductCategoryID;
                for (int i=0;i<= dgvProductCategory.Rows.Count;i++)
                {
                    foreach (Employee oEmp in oGetOutletEmployees)
                    {
                        if (i == oEmp.ProductCategoryID)
                        {
                            dgvProductCategory.Rows[i].Cells[0].Value = true;
                            dgvProductCategory.Rows[i].Cells[2].Value = oEmp.EffectiveDate;
                        }
                        cmboutletemployeetype.SelectedIndex = oEmp.OutletEmployeeType - 1;
                        nOutletEmployeeType = oEmp.OutletEmployeeType;
                        sOutletEmployeeType = cmboutletemployeetype.Text;
                    }
                }

            }



            

            this.ShowDialog();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            lblText.Visible = false;
            dtDate.Visible = false;

            if (this.Tag == null)
            {
                this.Text = "Add New Employee";
                LoadCombos();
            }
            else
            {
                this.Text = "Edit Employee";
                if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Confirmed)
                {
                    lblText.Visible = true;
                    dtDate.Visible = true;
                    lblText.Text = "Confirm Date";
                    dtDate.Enabled = true;
                    dtDate.Value = dtConfirmDate;
                }
                else if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Contractual || cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.NotEmployed)
                {
                    lblText.Visible = false;
                    dtDate.Visible = false;
                    dtDate.Enabled = false;
                }
                else
                {
                    lblText.Visible = true;
                    dtDate.Visible = true;
                    lblText.Text = "Separation Date";
                    dtDate.Enabled = true;
                    dtDate.Value = dtSeparationDate;
                }
            }
        }

        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            //Division
            oHRDivisions = new HRDivisions();
            oHRDivisions.Refresh();
            cmbDivision.Items.Clear();
            cmbDivision.Items.Add("-- Select Division --");
            foreach (HRDivision oHRDivision in oHRDivisions)
            {
                cmbDivision.Items.Add(oHRDivision.DivisionName);
            }
            cmbDivision.SelectedIndex = 0;

            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cboCompany.Items.Clear();
            cboCompany.Items.Add("-- Select Company --");
            foreach (Company oCompany in _oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            if (this.Tag == null)
            {
                cboCompany.SelectedIndex = 0;
            }

            //Designation
            _oDesignations = new Designations();
            _oDesignations.Refresh();
            cboDesignation.Items.Clear();
            foreach (Designation oDesignation in _oDesignations)
            {
                cboDesignation.Items.Add(oDesignation.DesignationName);
            }
            cboDesignation.SelectedIndex = 0;

            //Location
            _oJobLocations = new JobLocations();
            _oJobLocations.Refresh();
            cboJobLocation.Items.Clear();
            foreach (JobLocation oJobLocation in _oJobLocations)
            {
                cboJobLocation.Items.Add(oJobLocation.JobLocationName);
            }
            cboJobLocation.SelectedIndex = 0;

            //JobGrade
            _oJobGrades = new JobGrades();
            _oJobGrades.Refresh();
            cboJobGrade.Items.Clear();
            foreach (JobGrade oJobGrade in _oJobGrades)
            {
                cboJobGrade.Items.Add(oJobGrade.JobGradeName);
            }
            cboJobGrade.SelectedIndex = 0;

            //EquivalentGrades
            _oEquivalentGrades = new JobGrades();
            _oEquivalentGrades.Refresh();
            cmbEquivalentGrade.Items.Clear();
            foreach (JobGrade oEquivalentGrade in _oEquivalentGrades)
            {
                cmbEquivalentGrade.Items.Add(oEquivalentGrade.JobGradeName);
            }
            cmbEquivalentGrade.SelectedIndex = 0;

            //Employee Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HREmployeeStatus)))
            {
                cboStatus.Items.Add(Enum.GetName(typeof(Dictionary.HREmployeeStatus), GetEnum));
            }
            cboStatus.SelectedIndex = 0;

            //Employee Floor 
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HREmployeeFloor)))
            {
                cmbFloor.Items.Add(Enum.GetName(typeof(Dictionary.HREmployeeFloor), GetEnum));
            }
            cmbFloor.SelectedIndex = 0;

            //Room
            _oEmployees = new Employees();
            _oEmployees.RefreshRoom();
            cmbRoom.Items.Clear();
            foreach (Employee oEmployee in _oEmployees)
            {
                cmbRoom.Items.Add(oEmployee.Room);
            }
            //cmbRoom.SelectedIndex = 0;

            //Show Attendance Report 
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbShowAttnRpt.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbShowAttnRpt.SelectedIndex = 0;

            //Location
            _oBanks = new Banks();
            _oBanks.Refresh();
            cmbBank.Items.Clear();
            cmbBank.Items.Add("<ALL>");
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.SelectedIndex = 0;

            //Gender
            cmbGender.Items.Clear();
            cmbGender.Items.Add("<Select Gender>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.Gender)))
            {
                cmbGender.Items.Add(Enum.GetName(typeof(Dictionary.Gender), GetEnum));
            }
            cmbGender.SelectedIndex = 0;



            //Outlet Employee Type
            cmboutletemployeetype.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OutletEmployeeType)))
            {
                cmboutletemployeetype.Items.Add(Enum.GetName(typeof(Dictionary.OutletEmployeeType), GetEnum));
            }
            cmboutletemployeetype.SelectedIndex = 0;

           
            //Product Category
            dgvProductCategory.Rows.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductCategory)))
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvProductCategory);
                oRow.Cells[1].Value = (Enum.GetName(typeof(Dictionary.ProductCategory), GetEnum));
                oRow.Cells[2].Value = DateTime.Today.Date;
                oRow.Cells[3].Value = GetEnum;
                dgvProductCategory.Rows.Add(oRow);
            }

            //dgvProductCategory.SelectedIndex = 0;
            ////Product Category
            //cmbProductCategory.Items.Clear();
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductCategory)))
            //{
            //    cmbProductCategory.Items.Add(Enum.GetName(typeof(Dictionary.ProductCategory), GetEnum));
            //}
            //cmbProductCategory.SelectedIndex = 0;

            //BU
            _oSBUs = new SBUs();
            _oSBUs.Refresh();
            cmbBU.Items.Clear();
            foreach (SBU oSBU in _oSBUs)
            {
                cmbBU.Items.Add(oSBU.SBUName);
            }
            cmbBU.SelectedIndex = 0;

        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtCode.Text == "")
            {
                MessageBox.Show("Please Enter Code of Employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter Name of Employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtPermanantAddress.Text == "")
            {
                MessageBox.Show("Please Enter Permanant Address of Employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPermanantAddress.Focus();
                return false;
            }

            if (txtPresentAddress.Text == "")
            {
                MessageBox.Show("Please Enter Present Address of Employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPresentAddress.Focus();
                return false;
            }
            if (cmbGender.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Gender.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
                return false;
            }

            if (cboCompany.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCompany.Focus();
                return false;
            }
            if (cmbDivision.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Division", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDivision.Focus();
                return false;
            }
            if (cboDepartment.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDepartment.Focus();
                return false;
            }
            if (cmbSection.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select sub department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSection.Focus();
                return false;
            }
            if (cboDesignation.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Designation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDesignation.Focus();
                return false;
            }
            //if (cboJobLocation.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select Job Location", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cboJobLocation.Focus();
            //    return false;
            //}
            //if (cboJobGrade.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select Job Grade", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cboJobGrade.Focus();
            //    return false;
            //}
            //if (cmbEquivalentGrade.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select Equivalent Grade", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbEquivalentGrade.Focus();
            //    return false;
            //}
            if (cboShift.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select a Shift.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboShift.Focus();
                return false;
            }

            if (txtContactNo.Text == "")
            {
                MessageBox.Show("Please Enter ContactNo of Employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNo.Focus();
                return false;
            }
         
            

            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }

        private void InsertHistory()
        {
            Employee oEmpHistory = new Employee();
            oEmpHistory.EmployeeID = nEmployeeID;

            
            if (nCompany != _oCompanys[cboCompany.SelectedIndex - 1].CompanyID)
            {
                oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.Company;
                oEmpHistory.From = nCompany;
                oEmpHistory.To = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;
                oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
                oEmpHistory.Remarks = sCompany + " to " + cboCompany.Text;
                oEmpHistory.AddEmployeeHistory();

            }
            if (nDepartment != _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID)
            {
                oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.Department;
                oEmpHistory.From = nDepartment;
                oEmpHistory.To = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;
                oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
                oEmpHistory.Remarks = sDepartment + " to " + cboDepartment.Text;
                oEmpHistory.AddEmployeeHistory();
            }
            if (nDesignation != _oDesignations[cboDesignation.SelectedIndex].DesignationID)
            {
                oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.Designation;
                oEmpHistory.From = nDesignation;
                oEmpHistory.To = _oDesignations[cboDesignation.SelectedIndex].DesignationID;
                oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
                oEmpHistory.Remarks = sDesignation + " to " + cboDesignation.Text;
                oEmpHistory.AddEmployeeHistory();
            
            }
            if (nJobGrade != _oJobGrades[cboJobGrade.SelectedIndex].JobGradeID)
            {
                oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.Job_Grade;
                oEmpHistory.From = nJobGrade;
                oEmpHistory.To = _oJobGrades[cboJobGrade.SelectedIndex].JobGradeID;
                oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
                oEmpHistory.Remarks = sJobGrade + " to " + cboJobGrade.Text;
                oEmpHistory.AddEmployeeHistory();
            }

            if (nEquivalentGrade != _oEquivalentGrades[cmbEquivalentGrade.SelectedIndex].JobGradeID)
            {
                oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.Equivalent_Grade;
                oEmpHistory.From = nEquivalentGrade;
                oEmpHistory.To = _oEquivalentGrades[cmbEquivalentGrade.SelectedIndex].JobGradeID;
                oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
                oEmpHistory.Remarks = sEquivalentGrade + " to " + cmbEquivalentGrade.Text;
                oEmpHistory.AddEmployeeHistory();
            }
            if (nLocation != _oJobLocations[cboJobLocation.SelectedIndex].JobLocationID)
            {
                oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.Location;
                oEmpHistory.From = nLocation;
                oEmpHistory.To = _oJobLocations[cboJobLocation.SelectedIndex].JobLocationID;
                oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
                oEmpHistory.Remarks = sLocation + " to " + cboJobLocation.Text;
                oEmpHistory.AddEmployeeHistory();
            }
            if (nShift != _oShifts[cboShift.SelectedIndex].ShiftID)
            {
                oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.Shift;
                oEmpHistory.From = nShift;
                oEmpHistory.To = _oShifts[cboShift.SelectedIndex].ShiftID;
                oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
                oEmpHistory.Remarks = sShift + " to " + cboShift.Text;
                oEmpHistory.AddEmployeeHistory();
            }
            if (nStatus != cboStatus.SelectedIndex)
            {
                oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.Status;
                oEmpHistory.From = nStatus;
                oEmpHistory.To = cboStatus.SelectedIndex;
                oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
                oEmpHistory.Remarks = sStatus + " to " + cboStatus.Text;
                oEmpHistory.AddEmployeeHistory();
            }
            if (nSection != _oSections[cmbSection.SelectedIndex - 1].SectionID)
            {
                oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.Section;
                oEmpHistory.From = nSection;
                oEmpHistory.To = _oSections[cmbSection.SelectedIndex - 1].SectionID;
                oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
                oEmpHistory.Remarks = sSection + " to " + cmbSection.Text;
                oEmpHistory.AddEmployeeHistory();
            }
            if (nBU != _oSBUs[cmbBU.SelectedIndex].SBUID)
            {
                oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.BU;
                oEmpHistory.From = nBU;
                oEmpHistory.To = _oSBUs[cmbBU.SelectedIndex].SBUID;//oEmpHistory.To = _oSBUs[cmbBU.SelectedIndex - 1].SBUID;
                oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
                oEmpHistory.Remarks = sBU + " to " + cmbBU.Text;
                oEmpHistory.AddEmployeeHistory();
            }

            if (cmboutletemployeetype.Enabled == true)
            {
                if (nOutletEmployeeType != cmboutletemployeetype.SelectedIndex + 1)
                {
                    oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.OutletEmployeeType;
                    oEmpHistory.From = nOutletEmployeeType;
                    oEmpHistory.To = cmboutletemployeetype.SelectedIndex + 1;
                    oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
                    oEmpHistory.Remarks = sOutletEmployeeType + " to " + cmboutletemployeetype.Text;
                    oEmpHistory.AddEmployeeHistory();
                }

                foreach (DataGridViewRow oRow in dgvProductCategory.Rows)
                {
                    if (Convert.ToBoolean(oRow.Cells[0].Value) == true)
                    {
                        oEmpHistory.Type = (int)Dictionary.HREmployeeHistoryType.ProductCategory;
                        oEmpHistory.From = Convert.ToInt32(oRow.Cells[3].Value);
                        oEmpHistory.To = Convert.ToInt32(oRow.Cells[3].Value);
                        oEmpHistory.EffectiveDate = dtEffectiveDate.Value.Date;
                        oEmpHistory.Remarks = oRow.Cells[1].Value.ToString() + " to " + oRow.Cells[1].Value.ToString();
                        oEmpHistory.AddEmployeeHistory();
                    }
                }
            }

        }
    
        private void Save()
        {
            if (this.Tag == null)
            {
                oEmployee = new Employee();
                //oEmployee.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                oEmployee.EmployeeCode = txtCode.Text;
                oEmployee.EmployeeName = txtName.Text;
                oEmployee.PresentAddress = txtPresentAddress.Text;
                oEmployee.PermanantAddress = txtPermanantAddress.Text;
                oEmployee.DateOfBirth = dtpBirthDate.Value.Date;
                oEmployee.Gender = cmbGender.Text;
                oEmployee.Mobile = txtContactNo.Text;
                oEmployee.EmergencyContact = txtEmergencyContact.Text;
                oEmployee.EmergencyContactRelationship = txtEmergencyContactRelationship.Text;
                oEmployee.NationalID = txtNationalID.Text;
                oEmployee.TINNo = txtTINNo.Text;
                oEmployee.BloodGroup = txtBloodGroup.Text;
                oEmployee.CompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;
                oEmployee.SBUID = _oSBUs[cmbBU.SelectedIndex].SBUID;
                oEmployee.DepartmentID = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;
                oEmployee.SectionID = _oSections[cmbSection.SelectedIndex - 1].SectionID;
                oEmployee.LocationID = _oJobLocations[cboJobLocation.SelectedIndex].JobLocationID;
                oEmployee.DesignationID = _oDesignations[cboDesignation.SelectedIndex].DesignationID;
                oEmployee.GradeID = _oJobGrades[cboJobGrade.SelectedIndex].JobGradeID;
                oEmployee.EquivalentGradeID = _oEquivalentGrades[cmbEquivalentGrade.SelectedIndex].JobGradeID;
                oEmployee.ShiftID = _oShifts[cboShift.SelectedIndex].ShiftID;
                if (chkIsPayrollEmployee.Checked == true)
                {
                    oEmployee.IsPayrollEmployee = (int)Dictionary.YesNAStatus.Yes;

                }
                else
                {
                    oEmployee.IsPayrollEmployee = (int)Dictionary.YesNAStatus.NA;
                }

                if (cbIsWFH.Checked == true)
                {
                    oEmployee.IsWFH = (int)Dictionary.YesNAStatus.Yes;

                }
                else
                {
                    oEmployee.IsWFH = (int)Dictionary.YesNAStatus.NA;
                }
                if (chkLateSMS.Checked == true)
                {
                    oEmployee.IsEligibleForLateSMS = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oEmployee.IsEligibleForLateSMS = (int)Dictionary.YesOrNoStatus.NO;
                }
                if (chkIsFactoryEmp.Checked == true)
                {
                    oEmployee.IsFactory = (int)Dictionary.YesNAStatus.Yes;
                }
                else
                {
                    oEmployee.IsFactory = (int)Dictionary.YesNAStatus.NA;
                }
                oEmployee.JoiningDate = dtpJoiningDate.Value.Date;
                oEmployee.EmpStatus = cboStatus.SelectedIndex;

                if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Confirmed)
                {
                    oEmployee.ConfirmDate = dtDate.Value.Date;
                }
                else if (cboStatus.SelectedIndex != (int)Dictionary.HREmployeeStatus.Contractual || cboStatus.SelectedIndex != (int)Dictionary.HREmployeeStatus.NotEmployed)
                {
                    oEmployee.SeparationDate = dtDate.Value.Date;
                }
                oEmployee.Room = cmbRoom.Text;
                oEmployee.Floor = cmbFloor.SelectedIndex;
                oEmployee.ShowAttendanceRpt = cmbShowAttnRpt.SelectedIndex;
                if (cmbBank.SelectedIndex != 0)
                {
                    oEmployee.EBankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
                }
                else
                {
                    oEmployee.EBankID = 0;
                }

                oEmployee.BankAccountNo = txtBankAccNo.Text;
                try
                {
                    oEmployee.BasicSalary = Convert.ToDouble(txtBasicSalary.Text);
                }
                catch
                {
                    oEmployee.BasicSalary = 0;
                }

                oEmployee.CardNo = txtCode.Text.PadLeft(9, '0');
                oEmployee.PaymentMode = 1;

                try
                {
                    _oDataSyncManager = new DataSyncManager();
                    _oJobLocation = new JobLocation();
                    DBController.Instance.BeginNewTransaction();
                    oEmployee.Add();
                    if (pictureBox.Image != null)
                    {
                        oEmployee.UpdateImage(pictureBox.Image, oEmployee.EmployeeID);
                    }
                    int nDepertment;
                    nDepertment = oEmployee.DepartmentID;

                    if (nDepertment == 82975)
                    {
                        _oJobLocation.RefreshShowroomJoblocation(oEmployee.LocationID);
                        if (_oJobLocations[cboJobLocation.SelectedIndex].JobLocationID == _oJobLocation.JobLocationID) ;
                        {
                            _oDataSyncManager.SendEmployeeToShowroom(oEmployee, Dictionary.DataTransferType.Add, _oJobLocation.WarehouseID);

                            ///Outlet Employee                            
                            Employee oOutletEmployee = new Employee();
                            oOutletEmployee.DeleteOutletEmployee(oEmployee.EmployeeID);
                            int nCount = 0;
                            foreach (DataGridViewRow oRow in dgvProductCategory.Rows)
                            {
                                if (Convert.ToBoolean(oRow.Cells[0].Value) == true)
                                {
                                    oOutletEmployee.EmployeeID = oEmployee.EmployeeID;
                                    oOutletEmployee.OutletEmployeeType = cmboutletemployeetype.SelectedIndex + 1;

                                    oOutletEmployee.ProductCategoryID = Convert.ToInt32(oRow.Cells[3].Value);
                                    oOutletEmployee.EffectiveDate = Convert.ToDateTime(oRow.Cells[2].Value);



                                    if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Contractual)
                                    {
                                        oOutletEmployee.IsActive = (int)Dictionary.IsActive.Active;
                                    }
                                    else if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Confirmed)
                                    {
                                        oOutletEmployee.IsActive = (int)Dictionary.IsActive.Active;
                                    }
                                    else
                                    {
                                        oOutletEmployee.IsActive = (int)Dictionary.IsActive.InActive;
                                    }
                                    oOutletEmployee.AddOutletEmployee();
                                    nCount = nCount + 1;
                                }

                            }

                            if(nCount == 0)
                            {
                                oOutletEmployee.EmployeeID = oEmployee.EmployeeID;
                                oOutletEmployee.OutletEmployeeType = cmboutletemployeetype.SelectedIndex + 1;

                                oOutletEmployee.ProductCategoryID = 0;
                                oOutletEmployee.EffectiveDate = DateTime.Today;

                                if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Contractual)
                                {
                                    oOutletEmployee.IsActive = (int)Dictionary.IsActive.Active;
                                }
                                else if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Confirmed)
                                {
                                    oOutletEmployee.IsActive = (int)Dictionary.IsActive.Active;
                                }
                                else
                                {
                                    oOutletEmployee.IsActive = (int)Dictionary.IsActive.InActive;
                                }
                                oOutletEmployee.AddOutletEmployee();
                            }
                        }

                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oEmployee.EmployeeCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                Employee oEmployee = (Employee)this.Tag;
                oEmployee.EmployeeCode = txtCode.Text;
                oEmployee.EmployeeName = txtName.Text;
                oEmployee.PresentAddress = txtPresentAddress.Text;
                oEmployee.PermanantAddress = txtPermanantAddress.Text;
                oEmployee.DateOfBirth = dtpBirthDate.Value.Date;
                oEmployee.Gender = cmbGender.Text;
                oEmployee.Mobile = txtContactNo.Text;
                oEmployee.EmergencyContact = txtEmergencyContact.Text;
                oEmployee.EmergencyContactRelationship = txtEmergencyContactRelationship.Text;
                oEmployee.NationalID = txtNationalID.Text;
                oEmployee.TINNo = txtTINNo.Text;
                oEmployee.BloodGroup = txtBloodGroup.Text;
                oEmployee.CompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;
                oEmployee.SBUID = _oSBUs[cmbBU.SelectedIndex].SBUID;
                oEmployee.DepartmentID = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;
                oEmployee.SectionID = _oSections[cmbSection.SelectedIndex - 1].SectionID;
                oEmployee.LocationID = _oJobLocations[cboJobLocation.SelectedIndex].JobLocationID;
                oEmployee.DesignationID = _oDesignations[cboDesignation.SelectedIndex].DesignationID;
                oEmployee.GradeID = _oJobGrades[cboJobGrade.SelectedIndex].JobGradeID;
                oEmployee.EquivalentGradeID = _oEquivalentGrades[cmbEquivalentGrade.SelectedIndex].JobGradeID;
                oEmployee.ShiftID = _oShifts[cboShift.SelectedIndex].ShiftID;
                if (chkIsPayrollEmployee.Checked == true)
                {
                    oEmployee.IsPayrollEmployee = (int)Dictionary.YesNAStatus.Yes;

                }
                else
                {
                    oEmployee.IsPayrollEmployee = (int)Dictionary.YesNAStatus.NA;
                }

                if (cbIsWFH.Checked == true)
                {
                    oEmployee.IsWFH = (int)Dictionary.YesNAStatus.Yes;

                }
                else
                {
                    oEmployee.IsWFH = (int)Dictionary.YesNAStatus.NA;
                }

                if (chkIsFactoryEmp.Checked == true)
                {
                    oEmployee.IsFactory = (int)Dictionary.YesNAStatus.Yes;
                }
                else
                {
                    oEmployee.IsFactory = (int)Dictionary.YesNAStatus.NA;
                }
                if (chkLateSMS.Checked == true)
                {
                    oEmployee.IsEligibleForLateSMS = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oEmployee.IsEligibleForLateSMS = (int)Dictionary.YesOrNoStatus.NO;
                }
                oEmployee.JoiningDate = dtpJoiningDate.Value.Date;
                oEmployee.EmpStatus = cboStatus.SelectedIndex;

                if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Confirmed)
                {
                    oEmployee.ConfirmDate = dtDate.Value.Date;

                }
                else if (cboStatus.SelectedIndex != (int)Dictionary.HREmployeeStatus.Contractual || cboStatus.SelectedIndex != (int)Dictionary.HREmployeeStatus.NotEmployed)
                {
                    oEmployee.SeparationDate = dtDate.Value.Date;
                    oEmployee.ConfirmDate = dtConfirmDate;
                }
                oEmployee.Room = cmbRoom.Text;
                oEmployee.Floor = cmbFloor.SelectedIndex;
                oEmployee.ShowAttendanceRpt = cmbShowAttnRpt.SelectedIndex;
                if (cmbBank.SelectedIndex != 0)
                {
                    oEmployee.EBankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
                }
                else
                {
                    oEmployee.EBankID = 0;
                }

                oEmployee.BankAccountNo = txtBankAccNo.Text;
                try
                {
                    oEmployee.BasicSalary = Convert.ToDouble(txtBasicSalary.Text);
                }
                catch
                {
                    oEmployee.BasicSalary = 0;
                }

                oEmployee.CardNo = txtCode.Text.PadLeft(9, '0');
                oEmployee.PaymentMode = 1;

                try
                {
                    _oDataSyncManager = new DataSyncManager();
                    _oJobLocation = new JobLocation();
                    DBController.Instance.BeginNewTransaction();
                    oEmployee.Edit();
                    if (pictureBox.Image != null)
                    {
                        oEmployee.UpdateImage(pictureBox.Image, oEmployee.EmployeeID);
                    }
                    InsertHistory();
                    int nDepertment;
                    nDepertment = oEmployee.DepartmentID;

                    if (nDepertment == 82975)
                    {
                        _oJobLocation.RefreshShowroomJoblocation(oEmployee.LocationID);
                        if (_oJobLocations[cboJobLocation.SelectedIndex].JobLocationID == _oJobLocation.JobLocationID) ;
                        {
                            _oDataSyncManager.SendEmployeeToShowroom(oEmployee, Dictionary.DataTransferType.Add, _oJobLocation.WarehouseID);

                            ///Outlet Employee                            
                            Employee oOutletEmployee = new Employee();
                            oOutletEmployee.DeleteOutletEmployee(oEmployee.EmployeeID);

                            foreach (DataGridViewRow oRow in dgvProductCategory.Rows)
                            {
                                if (Convert.ToBoolean(oRow.Cells[0].Value) == true)
                                {
                                    oOutletEmployee.EmployeeID = oEmployee.EmployeeID;
                                    oOutletEmployee.OutletEmployeeType = cmboutletemployeetype.SelectedIndex + 1;

                                    oOutletEmployee.ProductCategoryID = Convert.ToInt32(oRow.Cells[3].Value);
                                    oOutletEmployee.EffectiveDate = Convert.ToDateTime(oRow.Cells[2].Value);

                                    //oOutletEmployee.ProductCategoryID = cmbProductCategory.SelectedIndex;
                                    //for (int i = 0; i < dgvProductCategory.Rows.Count; i++)
                                    //{
                                    //    foreach (Employee oEmp in oGetOutletEmployees)
                                    //    {
                                    //        if (i == oEmp.ProductCategoryID)
                                    //        {
                                    //            dgvProductCategory.Rows[i].Cells[0].Value = true;
                                    //        }
                                    //        cmboutletemployeetype.SelectedIndex = oEmp.OutletEmployeeType - 1;
                                    //    }
                                    //}

                                    if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Contractual)
                                    {
                                        oOutletEmployee.IsActive = (int)Dictionary.IsActive.Active;
                                    }
                                    else if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Confirmed)
                                    {
                                        oOutletEmployee.IsActive = (int)Dictionary.IsActive.Active;
                                    }
                                    else
                                    {
                                        oOutletEmployee.IsActive = (int)Dictionary.IsActive.InActive;
                                    }
                                    oOutletEmployee.AddOutletEmployee();
                                }
                            }
                        }

                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Employee : " + oEmployee.EmployeeCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            //Shift
            _oShifts = new Shifts();
            if (cboCompany.SelectedIndex != 0)
                _oShifts.Refresh(_oCompanys[cboCompany.SelectedIndex - 1].CompanyID);
            cboShift.Items.Clear();
            foreach (Shift oShift in _oShifts)
            {
                cboShift.Items.Add(oShift.ShiftName);
            }
            if (_oShifts.Count > 0) cboShift.SelectedIndex = 0;
        }

        private void btnAddDesignation_Click(object sender, EventArgs e)
        {
            frmDesignation oForm = new frmDesignation();
            oForm.ShowDialog();


            //Designation
            _oDesignations = new Designations();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oDesignations.Refresh();
            DBController.Instance.CloseConnection();
            cboDesignation.Items.Clear();
            foreach (Designation oDesignation in _oDesignations)
            {
                cboDesignation.Items.Add(oDesignation.DesignationName);
            }
            cboDesignation.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Confirmed)
            {
                lblText.Visible = true;
                dtDate.Visible = true;
                lblText.Text = "Confirm Date";
                dtDate.Enabled = true;
                dtDate.Value = dtConfirmDate;
            }
            else if (cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.Contractual || cboStatus.SelectedIndex == (int)Dictionary.HREmployeeStatus.NotEmployed)
            {
                lblText.Visible = false;
                dtDate.Visible = false;
                dtDate.Enabled = false;
            }
            else
            {
                lblText.Visible = true;
                dtDate.Visible = true;
                lblText.Text = "Separation Date";
                dtDate.Enabled = true;
                dtDate.Value = dtSeparationDate;

            }
        }

        private void cboJobLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            JobLocation oOutletEmpLocation = new JobLocation();
            oOutletEmpLocation.RefreshShowroomJoblocation(_oJobLocations[cboJobLocation.SelectedIndex].JobLocationID);
            if (oOutletEmpLocation.WarehouseID != 0)
            {
                lbloutletemployeetype.Enabled = true;
                lblProductCategory.Enabled = true;
                cmboutletemployeetype.Enabled = true;
                //cmbProductCategory.Enabled = true;
                dgvProductCategory.Enabled = true;
            }
            else
            {
                lbloutletemployeetype.Enabled = false;
                lblProductCategory.Enabled = false;
                cmboutletemployeetype.Enabled = false;
                //cmbProductCategory.Enabled = false;
                dgvProductCategory.Enabled = false;
            }
        }

        private void btnSection_Click(object sender, EventArgs e)
        {
            CJ.Win.HR.frmHRSection oForm = new CJ.Win.HR.frmHRSection();
            oForm.ShowDialog();
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
                cboDepartment.Items.Add("-- Select Department --");
                foreach (Department oDepartment in _oDepartments)
                {
                    cboDepartment.Items.Add(oDepartment.DepartmentName);
                }
                cboDepartment.SelectedIndex = 0;
            }
            else
            {
                cboDepartment.Items.Clear();
                cboDepartment.Items.Add("-- Select Department --");
                cboDepartment.SelectedIndex = 0;
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cboDepartment.SelectedIndex > 0)
            {

                //Sections
                _oSections = new Employees();
                _oSections.GetSectionData("", -1, _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID);
                cmbSection.Items.Clear();
                cmbSection.Items.Add("-- Select Section --");
                foreach (Employee oEmployee in _oSections)
                {
                    cmbSection.Items.Add(oEmployee.SectionName);
                }
                cmbSection.SelectedIndex = 0;
            }
            else
            {
                cmbSection.Items.Clear();
                cmbSection.Items.Add("-- Select Section --");
                cmbSection.SelectedIndex = 0;
            }
        }

        private void cboDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialogData.FileName = "";
            this.openFileDialogData.Multiselect = false;
            this.openFileDialogData.Filter = "";
            this.openFileDialogData.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            if (this.openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                //this.Text = this.openFileDialogData.DefaultExt.ToString();
                pictureBox.Image = Image.FromFile(this.openFileDialogData.FileName);
            }
            //openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            //DialogResult res = openFileDialog1.ShowDialog();
            //if (res == DialogResult.OK)
            //{
            //    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            //}

        }

        //void conv_photo()
        //{

        //    //converting photo to binary data
        //    if (pictureBox.Image != null)
        //    {
        //        //using FileStream:(will not work while updating, if image is not changed)
        //        //FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
        //        //byte[] photo_aray = new byte[fs.Length];
        //        //fs.Read(photo_aray, 0, photo_aray.Length); 

        //        //using MemoryStream:
        //        ms = new MemoryStream();
        //        pictureBox.Image.Save(ms, ImageFormat.Jpeg);
        //        byte[] photo_aray = new byte[ms.Length];
        //        ms.Position = 0;
        //        ms.Read(photo_aray, 0, photo_aray.Length);
        //        //cmd.Parameters.AddWithValue("@photo", photo_aray);
        //    }
        //}
    }
}
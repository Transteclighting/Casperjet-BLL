// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 17, 2013
// Time :  4:55 PM
// Description: Form for Medical Claim List
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
//using CJ.Class.Report;
//using CJ.Report;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmMedicalClaims : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        private Shifts _oShifts;
        private MedicalClaims _oMedicalClaims;

        public frmMedicalClaims()
        {
            InitializeComponent();
        }

        private void frmMedicalClaims_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void LoadCombos()
        {

            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh();
            cboCompany.Items.Clear();
            cboCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            cboCompany.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.Refresh();
            cboDepartment.Items.Clear();
            cboDepartment.Items.Add("<All>");
            foreach (Department oDepartment in _oDepartments)
            {
                cboDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cboDepartment.SelectedIndex = 0;

            //Shift
            _oShifts = new Shifts();
            _oShifts.Refresh();
            cboShift.Items.Clear();
            cboShift.Items.Add("<All>");
            foreach (Shift oShift in _oShifts)
            {
                cboShift.Items.Add(oShift.ShiftName);
            }
            cboShift.SelectedIndex = 0;

            //Attendance Status
            cboStatus.Items.Clear();
            cboStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRAttendanceStatus)))
            {
                cboStatus.Items.Add(Enum.GetName(typeof(Dictionary.HRAttendanceStatus), GetEnum));
            }
            cboStatus.SelectedIndex = 0;

            //Show Attendance Report 
            cmbShowRpt.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbShowRpt.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbShowRpt.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oMedicalClaims = new MedicalClaims();
            lvwMedicalClaims.Items.Clear();
            DBController.Instance.OpenNewConnection();


            int nCompanyID = 0;
            if (cboCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;

            int nDepartmentID = 0;
            if (cboDepartment.SelectedIndex > 0) nDepartmentID = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;

            int nShiftID = 0;
            if (cboShift.SelectedIndex > 0) nShiftID = _oShifts[cboShift.SelectedIndex - 1].ShiftID;

            int nStatus = -1;
            if (cboStatus.SelectedIndex > 0) nStatus = cboStatus.SelectedIndex - 1;

            //_oMedicalClaims.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, nCompanyID, nDepartmentID, nShiftID, nStatus, txtCode.Text, txtName.Text, cmbShowRpt.SelectedIndex - 1);
            _oMedicalClaims.Refresh();

            this.Text = "MedicalClaim " + "[" + _oMedicalClaims.Count + "]";
            foreach (MedicalClaim oMedicalClaim in _oMedicalClaims)
            {
                oMedicalClaim.ReadDB = true;
                ListViewItem oItem = lvwMedicalClaims.Items.Add(oMedicalClaim.MedicalClaimNo);
                oItem.SubItems.Add(oMedicalClaim.Employee.EmployeeName);
                oItem.SubItems.Add(oMedicalClaim.ClaimDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oMedicalClaim.ClaimType.ToString());
                oItem.SubItems.Add(oMedicalClaim.ClaimAmount.ToString());
                oItem.SubItems.Add(oMedicalClaim.ClaimStatus.ToString());
                oItem.SubItems.Add(oMedicalClaim.Remarks.ToString());

                //switch (oMedicalClaim.ClaimStatus)
                //{
                //    case Dictionary.HRAttendanceStatus.Leave:
                //        oItem.BackColor = Color.FromArgb(200, 200, 255);
                //        break;
                //    case Dictionary.HRAttendanceStatus.OutStation:
                //        oItem.BackColor = Color.FromArgb(200, 200, 200);
                //        break;
                //    case Dictionary.HRAttendanceStatus.Absent:
                //        oItem.BackColor = Color.FromArgb(255, 200, 200);
                //        break;
                //    case Dictionary.HRAttendanceStatus.Holiday:
                //        oItem.BackColor = Color.FromArgb(200, 255, 200);
                //        break;
                //    case Dictionary.HRAttendanceStatus.Late:
                //        oItem.BackColor = Color.FromArgb(255, 255, 200);
                //        break;
                //}
                oItem.Tag = oMedicalClaim;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMedicalClaim oForm = new frmMedicalClaim();
            oForm.ShowDialog();
            //DataLoadControl();
        }


    }
}
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 05, 2011
// Time :  4:55 PM
// Description: Class for Attendance Data.
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
using CJ.Class.Report;
using CJ.Report;
using CJ.Class.HR;

namespace CJ.Win
{
    public partial class frmAttendInfos : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        private Shifts _oShifts;
        private AttendInfos _oAttendInfos;
        OutStationDuty oOutStationDuty;

        public frmAttendInfos()
        {
            InitializeComponent();
        }

        private void frmAttendInfos_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void LoadCombos()
        {

            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cboCompany.Items.Clear();
            cboCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            cboCompany.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.Refresh(Utility.UserId);
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

        private void DataLoadControl()
        {
            _oAttendInfos = new AttendInfos();
            lvwAttendInfos.Items.Clear();
            DBController.Instance.OpenNewConnection();


            int nCompanyID = 0;
            if (cboCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;

            int nDepartmentID = 0;
            if (cboDepartment.SelectedIndex > 0) nDepartmentID = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;

            int nShiftID = 0;
            if (cboShift.SelectedIndex > 0) nShiftID = _oShifts[cboShift.SelectedIndex - 1].ShiftID;

            int nStatus= -1;
            if (cboStatus.SelectedIndex > 0) nStatus = cboStatus.SelectedIndex-1;

            _oAttendInfos.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, nCompanyID, nDepartmentID, nShiftID, nStatus, ctlEmployee1.txtCode.Text, ctlEmployee1.txtDescription.Text, cmbShowRpt.SelectedIndex - 1, Utility.UserId, chkIsFactoryEmployee.Checked);
            this.Text = "AttendInfo " + "[" + _oAttendInfos.Count + "]";
            foreach (AttendInfo oAttendInfo in _oAttendInfos)
            {
                //oAttendInfo.ReadDB = true;
                ListViewItem oItem = lvwAttendInfos.Items.Add(oAttendInfo.Employee.EmployeeCode);
                oItem.SubItems.Add(oAttendInfo.Employee.EmployeeName);
                oItem.SubItems.Add(oAttendInfo.PunchDate.ToString("dd-MMM-yyyy"));
                if (oAttendInfo.TimeIn == null) oItem.SubItems.Add("");
                else oItem.SubItems.Add(((DateTime)oAttendInfo.TimeIn).ToString("hh:mm tt"));
                if (oAttendInfo.TimeOut == null) oItem.SubItems.Add("");
                else oItem.SubItems.Add(((DateTime)oAttendInfo.TimeOut).ToString("hh:mm tt"));
                if (oAttendInfo.Late == null) oItem.SubItems.Add("");
                else oItem.SubItems.Add(((DateTime)oAttendInfo.Late).ToString("HH:mm"));
                oItem.SubItems.Add(oAttendInfo.PunchCount.ToString());
                oItem.SubItems.Add(oAttendInfo.Status.ToString());                

                switch (oAttendInfo.Status)
                {
                    case Dictionary.HRAttendanceStatus.Leave:
                        oItem.BackColor = Color.FromArgb(200, 200, 255);
                        break;
                    case Dictionary.HRAttendanceStatus.OutStation:
                        oItem.BackColor = Color.FromArgb(200, 200, 200);
                        break;
                    case Dictionary.HRAttendanceStatus.Absent:
                        oItem.BackColor = Color.FromArgb(255, 200, 200);
                        break;
                    case Dictionary.HRAttendanceStatus.Holiday:
                        oItem.BackColor = Color.FromArgb(200, 255, 200); 
                        break;
                    case Dictionary.HRAttendanceStatus.Late:
                        oItem.BackColor = Color.FromArgb(255, 255, 200);
                        break;
                }                
                oItem.Tag = oAttendInfo;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoadControl();
            this.Cursor = Cursors.Default;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            rptHRAttendInfos orptAttendInfos = new rptHRAttendInfos();
            CJ.Class.Report.rptHRAttendInfo orptAttendInfo;
 
            foreach (AttendInfo oAttendInfo in _oAttendInfos)
            {
                orptAttendInfo = new CJ.Class.Report.rptHRAttendInfo();
                oAttendInfo.Employee.ReadDB = true;
                orptAttendInfo._sEmployeeCode = oAttendInfo.Employee.EmployeeCode;
                orptAttendInfo._sEmployeeName= oAttendInfo.Employee.EmployeeName;
                orptAttendInfo._sCompany = oAttendInfo.Employee.Company.CompanyName; 
                orptAttendInfo._sDepartment = oAttendInfo.Employee.Department.DepartmentName;
                orptAttendInfo._sDesignation = oAttendInfo.Employee.Designation.DesignationName;
                orptAttendInfo._dPunchDate = oAttendInfo.PunchDate;
                if (oAttendInfo.TimeIn == null) orptAttendInfo._dTimeIn="";
                else orptAttendInfo._dTimeIn=((DateTime)oAttendInfo.TimeIn).ToString("hh:mm tt");
                if (oAttendInfo.TimeOut == null) orptAttendInfo._dTimeOut ="";
                else orptAttendInfo._dTimeOut =((DateTime)oAttendInfo.TimeOut).ToString("hh:mm tt");
                if (oAttendInfo.Late == null) orptAttendInfo._dLate ="";
                else orptAttendInfo._dLate =((DateTime)oAttendInfo.Late).ToString("HH:mm");
                orptAttendInfo._nPunchCount = oAttendInfo.PunchCount;
                orptAttendInfo._sStatus = oAttendInfo.Status.ToString(); 
               
                orptAttendInfo._sRemarks = oAttendInfo.Remarks;
                orptAttendInfos.Add(orptAttendInfo);
            }


            CJ.Report.rptHRAttendInfo oReport = new CJ.Report.rptHRAttendInfo();

            oReport.SetDataSource(orptAttendInfos);

            oReport.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));

            oReport.SetParameterValue("Company", cboCompany.Text);
            oReport.SetParameterValue("Department", cboDepartment.Text);
            oReport.SetParameterValue("Shift", cboShift.Text);
            oReport.SetParameterValue("Status", cboStatus.Text);
            oReport.SetParameterValue("EmpCode", ctlEmployee1.txtCode.Text);

            
            frmPrintPreview oFrom = new frmPrintPreview();

            oFrom.ShowDialog(oReport);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
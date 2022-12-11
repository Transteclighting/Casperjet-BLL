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
using CJ.Class.HR;
using CJ.Class.Report;
using CJ.Report;
using CJ.Report.HR;

namespace CJ.Win
{
    public partial class frmAttendReports : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        private JobLocations _oJobLocations;
        public frmAttendReports()
        {
            InitializeComponent();
        }

        private void frmAttendReports_Load(object sender, EventArgs e)
        {
            dtFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
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
            //Location
            _oJobLocations = new JobLocations();
            _oJobLocations.Refresh();
            cmbLocation.Items.Clear();
            cmbLocation.Items.Add("<All>");
            foreach (JobLocation oJobLocation in _oJobLocations)
            {
                cmbLocation.Items.Add(oJobLocation.JobLocationName);
            }
            cmbLocation.SelectedIndex = 0;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            Print();
            
            this.Cursor = Cursors.Default;
        }
        private void Print()
        {
            rptHRAttendSummarys oDatas = new rptHRAttendSummarys();

            int nCompanyID = 0;
            if (cboCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;

            int nDepartmentID = 0;
            if (cboDepartment.SelectedIndex > 0) nDepartmentID = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;

            int nLocationID = 0;
            if (cmbLocation.SelectedIndex > 0) nLocationID = _oJobLocations[cmbLocation.SelectedIndex - 1].JobLocationID;
            //int nType = 0;            
            if (rbEmployeeWise.Checked)
            {
                oDatas.RefreshEmployeeWise(dtFromDate.Value, dtToDate.Value, nCompanyID, nDepartmentID, nLocationID, chkIsAttendanceEmployee.Checked, rdoAllEmployee.Checked, rdoFactoryEmployee.Checked, rdoNonFactoryEmployee.Checked);
                rptHRAttendEmpWise oReport = new rptHRAttendEmpWise();
                oReport.SetDataSource(oDatas);

                oReport.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));

                oReport.SetParameterValue("Company", cboCompany.Text);
                oReport.SetParameterValue("Department", cboDepartment.Text);
                oReport.SetParameterValue("Location", cmbLocation.Text);
                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
            }
            else if (rbDepartmentWise.Checked)
            {
                oDatas.RefreshDepartmentWise(dtFromDate.Value, dtToDate.Value, nCompanyID, nDepartmentID, nLocationID, chkIsAttendanceEmployee.Checked, rdoAllEmployee.Checked, rdoFactoryEmployee.Checked, rdoNonFactoryEmployee.Checked);
                rptHRAttendDeptWise oReport = new rptHRAttendDeptWise();
                oReport.SetDataSource(oDatas);

                oReport.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));

                oReport.SetParameterValue("Company", cboCompany.Text);
                oReport.SetParameterValue("Department", cboDepartment.Text);
                oReport.SetParameterValue("Location", cmbLocation.Text);
                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
            }
            else if (rbDateWise.Checked)
            {
                oDatas.RefreshDayWise(dtFromDate.Value, dtToDate.Value, nCompanyID, nDepartmentID, nLocationID, chkIsAttendanceEmployee.Checked, rdoAllEmployee.Checked, rdoFactoryEmployee.Checked, rdoNonFactoryEmployee.Checked);
                rptHRAttendDayWise oReport = new rptHRAttendDayWise();
                oReport.SetDataSource(oDatas);

                oReport.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));

                oReport.SetParameterValue("Company", cboCompany.Text);
                oReport.SetParameterValue("Department", cboDepartment.Text);
                oReport.SetParameterValue("Location", cmbLocation.Text);
                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
            }
        }

        
        private void lblTo_Click(object sender, EventArgs e)
        {

        }

       
    }
}
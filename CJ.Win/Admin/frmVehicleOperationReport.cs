using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;
using CJ.Report;
using CJ.Class.Report;
using System.Configuration;
using CJ.Class;




namespace CJ.Win.Admin
{
    public partial class frmVehicleOperationReport : Form
    {
        string sVehicleCode;
        Companys oCompanys;
        Departments oDepartments;
        RptVehicleOperationDetails oRptVehicleOperationDetails;
        RptVehicleOperationSummaryDetails oRptVehicleOperationSummaryDetails;
        
        public frmVehicleOperationReport()
        {
            InitializeComponent();
        }      
        private void frmVehicleOperationReport_Load(object sender, EventArgs e)
        {
            oCompanys = new Companys();
            oCompanys.Refresh();
            cmbCompany.Items.Clear();
            foreach (Company oCompany in oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            oDepartments = new Departments();
            oDepartments.Refresh();
            cmbDepartment.Items.Clear();           
            foreach(Department oDepartment in oDepartments)
            
            {

                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;
            
          
        }   

        private void btnShowReport_Click_1(object sender, EventArgs e)
        {
            oRptVehicleOperationDetails = new RptVehicleOperationDetails();            
            DateTime dt =dateTimePicker2.Value.AddDays(1).Date;
            oRptVehicleOperationDetails.VehicleOperation(dateTimePicker1.Value.Date, dt.Date, oCompanys[cmbCompany.SelectedIndex].CompanyID, oDepartments[cmbDepartment.SelectedIndex].DepartmentID, txtCode.Text);
            if (oRptVehicleOperationDetails.Count > 0)
            {
                rptVehicleOperation oReport = new rptVehicleOperation();
                oReport.SetDataSource(oRptVehicleOperationDetails);
                oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                oReport.SetParameterValue("PrintedBy", Utility.Username.ToString());
                oReport.SetParameterValue("FromDate", dateTimePicker1.Value.Date);
                oReport.SetParameterValue("ToDate", dateTimePicker2.Value.Date);
                crystalReportViewer1.ReportSource = oReport;
            }
            else MessageBox.Show("No Data ! ");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSummaryReport_Click(object sender, EventArgs e)
        {
            oRptVehicleOperationSummaryDetails = new RptVehicleOperationSummaryDetails();
            DateTime dt = dateTimePicker2.Value.AddDays(1).Date;
            oRptVehicleOperationSummaryDetails.VehicleOperationSummary(dateTimePicker1.Value.Date, dt.Date,  oDepartments[cmbDepartment.SelectedIndex].DepartmentID, txtCode.Text );
            if (oRptVehicleOperationSummaryDetails.Count > 0)
            {

                rptVehicleOprSummary oReport = new rptVehicleOprSummary();
                oReport.SetDataSource(oRptVehicleOperationSummaryDetails);
                oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                oReport.SetParameterValue("PrintedBy", Utility.Username.ToString());
                oReport.SetParameterValue("FromDate", dateTimePicker1.Value.Date);
                oReport.SetParameterValue("ToDate", dateTimePicker2.Value.Date);
                crystalReportViewer1.ReportSource = oReport;
            }
            else MessageBox.Show("No Data ! ");

        }   
       

       

        
    }
}
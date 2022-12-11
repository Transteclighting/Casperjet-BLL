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
using CJ.Class.Admin;
using System.Configuration;
using CJ.Class;

namespace CJ.Win.Admin
{
    public partial class frmVehicleOperationReportAdmin : Form
    {

        string sVehicleCode;
        Companys oCompanys;
        Departments oDepartments;
        VehicleExpenseHeads oVehicleExpenseHeads;
        RptVehicleOperationReportAdminDetails oRptVehicleOperationReportAdminDetails;       
        //RptVehicleOperationSummaryDetails oRptVehicleOperationSummaryDetails;
        
        public frmVehicleOperationReportAdmin()
        {
            InitializeComponent();
        }

        private void frmVehicleOperationReportAdmin_Load(object sender, EventArgs e)
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
            foreach (Department oDepartment in oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;

            oVehicleExpenseHeads = new VehicleExpenseHeads();
            oVehicleExpenseHeads.Refresh();
            cmbExpenseHead.Items.Clear();
            foreach (VehicleExpenseHead oVehicleExpenseHead in oVehicleExpenseHeads)
            {
                cmbExpenseHead.Items.Add(oVehicleExpenseHead.ExpenseHeadName);
            }
            cmbExpenseHead.SelectedIndex = 0;

        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            oRptVehicleOperationReportAdminDetails = new RptVehicleOperationReportAdminDetails();
          
            DateTime dt = dateTimePicker2.Value.AddDays(1).Date;
            oRptVehicleOperationReportAdminDetails.VehicleOperation(dateTimePicker1.Value.Date, dt.Date, oCompanys[cmbCompany.SelectedIndex].CompanyID, oDepartments[cmbDepartment.SelectedIndex].DepartmentID, txtCode.Text, oVehicleExpenseHeads[cmbExpenseHead.SelectedIndex].ExpenseHeadID);
            if (oRptVehicleOperationReportAdminDetails.Count > 0)
            {
                rptVehicleOperation oReport = new rptVehicleOperation();
                oReport.SetDataSource(oRptVehicleOperationReportAdminDetails);
                oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                oReport.SetParameterValue("PrintedBy", Utility.Username.ToString());
                oReport.SetParameterValue("FromDate", dateTimePicker1.Value.Date);
                oReport.SetParameterValue("ToDate", dateTimePicker2.Value.Date);
                crystalReportViewer1.ReportSource = oReport;
            }
            else MessageBox.Show("No Data ! ");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
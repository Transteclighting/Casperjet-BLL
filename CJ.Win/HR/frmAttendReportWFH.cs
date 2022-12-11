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

namespace CJ.Win.HR
{
    public partial class frmAttendReportWFH : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        public frmAttendReportWFH()
        {
            InitializeComponent();
        }

        private void frmAttendReportWFH_Load(object sender, EventArgs e)
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
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            rptHRAttendSummarys oDatas = new rptHRAttendSummarys();
            //CJ.Class.Report.rptHRAttendSummary
            int nCompanyID = 0;
            if (cboCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;

            int nDepartmentID = 0;
            if (cboDepartment.SelectedIndex > 0) nDepartmentID = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;
           
                oDatas.RefreshByWFH(dtDate.Value.Date,nCompanyID, nDepartmentID,rdoAll.Checked,rdoIsCheckin.Checked,rdoIsNotChecking.Checked);
                rptHRAttendReportWFH oReport = new rptHRAttendReportWFH();
                oReport.SetDataSource(oDatas);

                oReport.SetParameterValue("Date", dtDate.Value.ToString("dd-MMM-yyyy"));
                oReport.SetParameterValue("Company", cboCompany.Text);
                oReport.SetParameterValue("Department", cboDepartment.Text);
                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);


        }         
    }
}

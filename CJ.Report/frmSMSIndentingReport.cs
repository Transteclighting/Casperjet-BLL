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

using CJ.Class;

namespace CJ.Report
{
    public partial class frmSMSIndentingReport : Form
    {
        int ncbCheck=-1;
        string _sCompanyName;
        public frmSMSIndentingReport()
        {
            InitializeComponent();
        }

        private void btshow_Click(object sender, EventArgs e)
        {
            if (_sCompanyName == "BLL")
            {
                SMSIndentings oSMSIndentings = new SMSIndentings();

                DateTime dt = dateTimePicker2.Value.AddDays(1);
                oSMSIndentings.GetDataForReport(dateTimePicker1.Value.Date, dt.Date, ncbCheck, txtMobileNo.Text);
                crtSMSIdenting oReport = new crtSMSIdenting();
                oReport.SetDataSource(oSMSIndentings);
                crystalReportViewer1.ReportSource = oReport;
            }
            else if (_sCompanyName == "TML")
            {
                TMLSMSIndentings oTMLSMSIndenting = new TMLSMSIndentings();
                DateTime dt = dateTimePicker2.Value.AddDays(1);
                oTMLSMSIndenting.GetDataForReport(dateTimePicker1.Value.Date, dt.Date, ncbCheck, txtMobileNo.Text);
                crtSMSIdenting oReport = new crtSMSIdenting();
                oReport.SetDataSource(oTMLSMSIndenting);
                crystalReportViewer1.ReportSource = oReport;
            }

        }
        public void ShowDialog(string sCompany)
        {
            _sCompanyName = sCompany;
            this.ShowDialog();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.Text == "1") ncbCheck = 1;
            else if (cbStatus.Text == "0") ncbCheck = 0;
            else ncbCheck = -1;
        }
    }
}
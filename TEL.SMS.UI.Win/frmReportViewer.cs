using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using TEL.SMS.Reports;

namespace TEL.SMS.UI.Win
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        public void crystalReportViewer1_Load(object sender, EventArgs e)
        {
        }
        public void ReportRefersh(ShowroomStockReport oSR)
        {
            crystalReportViewer1.ReportSource = oSR;
        }
        public void WarrantyActReportRefersh(rptWarrantyActivation oWA)
        {
            crystalReportViewer1.ReportSource = oWA;
        }
        private void frmReportViewer_Load(object sender, EventArgs e)
        {

        }
        public void ShowDialog(ReportClass oReport)
        {
            crystalReportViewer1.ReportSource = oReport;
            this.ShowDialog();
        }
    }
}
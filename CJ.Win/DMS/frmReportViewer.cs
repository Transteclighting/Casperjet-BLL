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


namespace CJ.Win.DMS
{
    public partial class frmReportViewer : Form
    {
        rptReplaceClaimDeliverys orptReplaceClaimDeliverys;
        int _nReplaceClaimID;
        public frmReportViewer(int nReplaceClaimID)
        {
            InitializeComponent();
            _nReplaceClaimID = nReplaceClaimID;
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            orptReplaceClaimDeliverys = new rptReplaceClaimDeliverys();

            //orptReplaceClaimDeliverys.ReplaceClaimDelivery(_nReplaceClaimID);
            if (orptReplaceClaimDeliverys.Count > 0)
            {
                rptReplaceClaimDeliveryItem oReport = new rptReplaceClaimDeliveryItem();
                oReport.SetDataSource(orptReplaceClaimDeliverys);
                //oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                //oReport.SetParameterValue("PrintedBy", Utilityj,..Username.ToString());
                //oReport.SetParameterValue("FromDate", dateTimePicker1.Value.Date);
                //oReport.SetParameterValue("ToDate", dateTimePicker2.Value.Date);
                crystalReportViewer1.ReportSource = oReport;
            }
            else MessageBox.Show("No Data ! ");
        }
    }
}
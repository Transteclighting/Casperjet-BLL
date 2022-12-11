using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;

namespace CJ.Report
{
    public partial class frmPrintPreviewWithoutExport : Form
    {
        public frmPrintPreviewWithoutExport()
        {
            InitializeComponent();
        }
        public void ShowDialog(ReportClass oReport)
        {
            //Test comment
            
            crvPrintPreview.ShowExportButton = false;
            crvPrintPreview.ShowRefreshButton = false;
            crvPrintPreview.ShowGroupTreeButton = false;

            crvPrintPreview.ReportSource = oReport;

            this.ShowDialog();
        }
    }
}
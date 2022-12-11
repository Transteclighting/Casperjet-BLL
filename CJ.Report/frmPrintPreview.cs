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
    public partial class frmPrintPreview : Form
    {
        public frmPrintPreview()
        {
            InitializeComponent();
        }

        public void ShowDialog(ReportClass oReport) 
        {
            //Test comment
            crvPrintPreview.ReportSource = oReport;

            this.ShowDialog();
        }
    }
}
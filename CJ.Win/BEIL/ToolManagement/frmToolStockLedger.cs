using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.BEIL;
using CJ.Win.Security;
using CJ.Class;
using CJ.Class.BEIL;
using CJ.Class.Report;
using CJ.Report;
using CJ.Report.BEIL;

namespace CJ.Win.BEIL.ToolManagement
{
    public partial class frmToolStockLedger : Form
    {
        ToolTran oToolTran;
        //ToolTran _ooToolTran;
        int employeeID = 0;

        public frmToolStockLedger()
        {
            InitializeComponent();
        }

        private void frmEmployeeToolLedger_Load(object sender, EventArgs e)
        {
            rdoEmployee.Checked = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PrintPromo();
            this.Cursor = Cursors.Default;
        }

        public void PrintPromo()
        {
            if (rdoEmployee.Checked == true)
            {
                this.Cursor = Cursors.WaitCursor;

                if (ctlEmployee1.SelectedEmployee == null || ctlEmployee1.txtCode.Text == "")
                {
                    MessageBox.Show("Please Select an Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlEmployee1.Focus();
                    return;
                }

                employeeID = ctlEmployee1.SelectedEmployee.EmployeeID;

                oToolTran = new ToolTran();

                DBController.Instance.OpenNewConnection();


                oToolTran.GetDataForReportStockLedger(employeeID);

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptToolStockLedger));
                oReport.SetDataSource(oToolTran);
                oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                oReport.SetParameterValue("PrintBy", Utility.UserFullname);
                oReport.SetParameterValue("ReportName", "Employee Wise");
                oReport.SetParameterValue("IsTrue", false);

                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;

            }

            else
            {
                this.Cursor = Cursors.WaitCursor;

                oToolTran = new ToolTran();

                DBController.Instance.OpenNewConnection();

                oToolTran.GetDataForReportStockLedgerSoundStock();

                CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptToolStockLedger));
                oReport.SetDataSource(oToolTran);
                oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                oReport.SetParameterValue("PrintBy", Utility.UserFullname);
                oReport.SetParameterValue("ReportName", "Sound Stock");
                oReport.SetParameterValue("IsTrue", true);

                frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
                this.Cursor = Cursors.Default;

            }

        }

        private void rdoWH_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoWH.Checked == true)
            {
                ctlEmployee1.txtCode.Text = null;
                ctlEmployee1.Enabled = false;
            }

            else
            {
                ctlEmployee1.Enabled = true;
            }

        }
    }
}

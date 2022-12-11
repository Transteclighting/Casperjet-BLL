using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Report;
using CJ.Class.Process;
using System.IO;

namespace EmailSheduler
{
    public partial class frmTargetPdf : Form
    {
        public frmTargetPdf()
        {
            InitializeComponent();
        }

        public void CreatePath()
        {
            string sPath = @"D:\ExportedData";
            if (!Directory.Exists(sPath))
                Directory.CreateDirectory(sPath);
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lblDataProcess.Text = "Data Preparing. Please wait...";
            lblDataProcess.Refresh();

            try
            {
                RetailSalesInvoices oInvoice = new RetailSalesInvoices();
                DBController.Instance.OpenNewConnection();
                oInvoice.RefreshSRMEmployee();
                DBController.Instance.CloseConnection();
                int nTotalSend = 0;
                foreach (RetailSalesInvoice oItemRows in oInvoice)
                {
                    DBController.Instance.OpenNewConnection();
                    RetailSalesInvoices oItem = new RetailSalesInvoices();
                    oItem.RefreshEmployeeTarget(oItemRows.EmployeeCode);

                    CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptExportEmployeeTarget));
                    oReport.SetDataSource(oItem);
                    oReport.SetParameterValue("Outlet", oItemRows.ShowroomCode);
                    oReport.SetParameterValue("EmployeeCode", oItemRows.EmployeeCode);
                    oReport.SetParameterValue("EmployeeName", oItemRows.EmployeeName);
                    oReport.SetParameterValue("ReportName", "TARGET FOR THE MONTH OF DECEMBER-2021");
                    CreatePath();
                    oReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\ExportedData\" + oItemRows.ShowroomCode.ToString() + "-[" + oItemRows.EmployeeCode + "] " + oItemRows.EmployeeName + "" + ".pdf");
                    DBController.Instance.CloseConnection();
                }


                lblDataProcess.Text = "Data Update Successfully.Total Invoice=" + oInvoice.Count + " and Total Sent=" + nTotalSend + "";
                lblDataProcess.Refresh();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Inserting Data:" + ex + " ");
            }
        }
    }
}

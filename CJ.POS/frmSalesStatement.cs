// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: May 05, 2014
// Time : 05:36 PM
// Description: Sales Statement Report for POS
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.POS;
using CJ.POS;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Report;

namespace CJ.POS
{
    public partial class frmSalesStatement : Form
    {
        SystemInfo oSystemInfo;
        DailySalesReports _oDailySalesReports;

        public frmSalesStatement()
        {
            InitializeComponent();
        }

        private void frmSalesStatement_Load(object sender, EventArgs e)
        {
            oSystemInfo = new SystemInfo();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            dtFromDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate).Date;
            dtToDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate).Date;
            DBController.Instance.CloseConnection();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
            Report();
            DBController.Instance.CloseConnection();
            this.Cursor = Cursors.Default;
        }
        private void Report()
        {
            
            _oDailySalesReports = new DailySalesReports();
            
            _oDailySalesReports.RefreshPOSSalesStatement(dtFromDate.Value, dtToDate.Value);

            if (_oDailySalesReports.Count == 0)
            {
                MessageBox.Show("There is no sales data ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptPOSSalesStatement));// rptPOSSalesStatement
            doc.SetDataSource(_oDailySalesReports);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("ReportName", "Sales Statement");
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            DailySalesReport oDailySalesReport = new DailySalesReport();
            oDailySalesReport.GetChannelWiseNetSales(dtFromDate.Value, dtToDate.Value);
            doc.SetParameterValue("Retail", oDailySalesReport.RetailNetSales);
            doc.SetParameterValue("B2B", oDailySalesReport.B2BNetSales);
            doc.SetParameterValue("B2C", oDailySalesReport.B2CNetSales);
            doc.SetParameterValue("HPA", oDailySalesReport.HPANetSales);
            doc.SetParameterValue("Dealer", oDailySalesReport.DealerNetSales);
            doc.SetParameterValue("Estore", oDailySalesReport.EstoreNetSales);

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }
    }
}
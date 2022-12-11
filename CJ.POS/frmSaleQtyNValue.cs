// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: May 05, 2014
// Time : 08:04 PM
// Description: Sales Qty and Value Report for POS
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
using CJ.Class.Library;

namespace CJ.POS
{
    public partial class frmSaleQtyNValue : Form
    {
        SystemInfo oSystemInfo;
        //TELLib _oTELLib;

        DailySalesReports _oDailySalesReports;
        int _nReportKey = 0;
        public frmSaleQtyNValue(int nReportKey)
        {
            InitializeComponent();
            _nReportKey = nReportKey;
        }

        private void frmSaleQtyNValue_Load(object sender, EventArgs e)
        {
            oSystemInfo = new SystemInfo();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oSystemInfo.Refresh();
            //_oTELLib = new TELLib();
            dtFromDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate).Date;
            dtToDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate).Date;
            DBController.Instance.CloseConnection();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (_nReportKey == (int)Dictionary.ReportKeyfrmSaleQtyNValue.Sale_Qty_and_Value_All)
            {
                Report();
            }
            else if (_nReportKey == (int)Dictionary.ReportKeyfrmSaleQtyNValue.Sale_Qty_and_Value_Retail_Other)
            {
                ReportNew();
            }
            else if (_nReportKey == (int)Dictionary.ReportKeyfrmSaleQtyNValue.Sale_Qty_and_Value_Dealer)
            {
                ReportNew();
            }
                DBController.Instance.CloseConnection();
            this.Cursor = Cursors.Default;
        }
        private void Report()
        {
            //_oTELLib = new TELLib();
            _oDailySalesReports = new DailySalesReports();

            _oDailySalesReports.RefreshPOSSaleQtyNValue(dtFromDate.Value, dtToDate.Value, txtProductCode.Text.Trim(), txtProductName.Text.Trim());
            if (_oDailySalesReports.Count == 0)
            {
                MessageBox.Show("There is no sales data ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptPOSSaleQtyNValue));
            doc.SetDataSource(_oDailySalesReports);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("ReportName", "Product Wise Sales Quantity and Value");
            if (txtProductCode.Text.Trim() != "")
            {
                doc.SetParameterValue("sProductCode", txtProductCode.Text.ToString());
            }
            else
            {
                doc.SetParameterValue("sProductCode", "");
            }
            if (txtProductName.Text.Trim() != "")
            {
                doc.SetParameterValue("sProductName", txtProductName.Text.ToString());
            }
            else
            {
                doc.SetParameterValue("sProductName", "");
            }
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void ReportNew()
        {
            //_oTELLib = new TELLib();
            _oDailySalesReports = new DailySalesReports();

            _oDailySalesReports.RefreshPOSSaleQtyNValueNew(dtFromDate.Value, dtToDate.Value, txtProductCode.Text.Trim(), txtProductName.Text.Trim(), _nReportKey);
            if (_oDailySalesReports.Count == 0)
            {
                MessageBox.Show("There is no sales data ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptPOSSaleQtyNValue));
            doc.SetDataSource(_oDailySalesReports);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            doc.SetParameterValue("ReportName", "Product Wise Sales Quantity and Value");
            if (txtProductCode.Text.Trim() != "")
            {
                doc.SetParameterValue("sProductCode", txtProductCode.Text.ToString());
            }
            else
            {
                doc.SetParameterValue("sProductCode", "");
            }
            if (txtProductName.Text.Trim() != "")
            {
                doc.SetParameterValue("sProductName", txtProductName.Text.ToString());
            }
            else
            {
                doc.SetParameterValue("sProductName", "");
            }
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }
    }
}
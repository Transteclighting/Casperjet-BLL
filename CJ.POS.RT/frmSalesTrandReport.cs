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

namespace CJ.POS.RT
{
    public partial class frmSalesTrandReport : Form
    {
        RetailSalesInvoices _oSalesTrandReports;

        //SystemInfo oSystemInfo;
        TELLib _oTELLib;
        int nTYear = 0;
        int nTMonth = 0;
        int nLastYear = 0;
        int nThisYear = 0;
        int _nReportKey = 0;
        public frmSalesTrandReport(int nReportKey)
        {
            InitializeComponent();
            _nReportKey = nReportKey;
        }

        private void Report()
        {
            this.Cursor = Cursors.WaitCursor;
            _oSalesTrandReports = new RetailSalesInvoices();
            _oTELLib = new TELLib();
            //oSystemInfo = new SystemInfo();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //oSystemInfo.Refresh();

            nThisYear = dtSalesYear.Value.Year;
            nLastYear = nThisYear - 1;


            _oSalesTrandReports.SalesTrandReportRT(nThisYear, nLastYear);
            if (_oSalesTrandReports.Count == 0)
            {
                MessageBox.Show("There is no sales data ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesTrandReport));
            doc.SetDataSource(_oSalesTrandReports);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", Utility.WarehouseName);
            doc.SetParameterValue("ReportName", "Sales Trend Report");
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(_oTELLib.ServerDateTime()).ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ThisYear", nThisYear.ToString());
            doc.SetParameterValue("LastYear", nLastYear.ToString());

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }
        private void ReportNew()
        {
            this.Cursor = Cursors.WaitCursor;
            _oSalesTrandReports = new RetailSalesInvoices();
            _oTELLib = new TELLib();
            //oSystemInfo = new SystemInfo();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //oSystemInfo.Refresh();

            nThisYear = dtSalesYear.Value.Year;
            nLastYear = nThisYear - 1;


            _oSalesTrandReports.SalesTrandReportNewRT(nThisYear, nLastYear, _nReportKey);
            if (_oSalesTrandReports.Count == 0)
            {
                MessageBox.Show("There is no sales data ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptSalesTrandReport));
            doc.SetDataSource(_oSalesTrandReports);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", Utility.WarehouseName);
            doc.SetParameterValue("ReportName", "Sales Trend Report");
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(_oTELLib.ServerDateTime()).ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ThisYear", nThisYear.ToString());
            doc.SetParameterValue("LastYear", nLastYear.ToString());

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }
        private void ReportbyWeek()
        {

            _oSalesTrandReports = new RetailSalesInvoices();
            _oTELLib = new TELLib();
            //oSystemInfo = new SystemInfo();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //oSystemInfo.Refresh();

            nTMonth = dtWeek.Value.Month;
            nTYear = dtWeek.Value.Year;

            DateTime _dtFirstDayofMonth = _oTELLib.FirstDayofMonth(dtWeek.Value.Date);
            DateTime _dtLastDayofMonth = _oTELLib.LastDayofMonth(dtWeek.Value.Date);


            _oSalesTrandReports.TgtVsAchMAGWiseWeek(_dtFirstDayofMonth, _dtLastDayofMonth, nTYear, nTMonth);
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMAGWiseTGTvsActual));
            doc.SetDataSource(_oSalesTrandReports);

            //doc.SetParameterValue("UserName", Utility.Username);
            //doc.SetParameterValue("CompanyName", Utility.CompanyName);
            //doc.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            //doc.SetParameterValue("ReportName", "Sales Trend Report");
            //doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));
            //doc.SetParameterValue("ThisYear", nThisYear.ToString());
            //doc.SetParameterValue("LastYear", nLastYear.ToString());

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (_nReportKey == (int)Dictionary.ReportKeyfrmSalesTrandReport.Sales_Trand_All)
            {
                Report();
            }
            else
            {
                ReportNew();
            }
            //ReportbyWeek();

        }

        private void frmSalesTrandReport_Load(object sender, EventArgs e)
        {
            _oTELLib = new TELLib();
            dtWeek.Visible = false;
            dtSalesYear.Value = _oTELLib.ServerDateTime();
        }
    }
}
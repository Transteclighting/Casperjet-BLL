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
    public partial class frmCustomerTGTvsACH : Form
    {
        RetailSalesInvoices _oCustTGTvsAchReports;

        //SystemInfo oSystemInfo;
        TELLib _oTELLib;

        public frmCustomerTGTvsACH()
        {
            InitializeComponent();
        }

        private void Report()
        {

            _oCustTGTvsAchReports = new RetailSalesInvoices();
            _oTELLib = new TELLib();
            //oSystemInfo = new SystemInfo();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //oSystemInfo.Refresh();

            int nTGTYear = Convert.ToInt32(dtDate.Value.Year);
            int nTGTMonth = Convert.ToInt32(dtDate.Value.Month);
            DateTime dtGetDate = Convert.ToDateTime((dtDate.Value.Date));
            DateTime FirstDateOfThisMonth = _oTELLib.FirstDayofMonth(dtGetDate);


            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string sMonthName = mfi.GetMonthName(nTGTMonth).ToString();

            _oCustTGTvsAchReports.CustomerTgtVsAchByMonthRT(FirstDateOfThisMonth, nTGTYear, nTGTMonth);
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptPOSCustomerTGTvsAch));
            doc.SetDataSource(_oCustTGTvsAchReports);
            
            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", Utility.WarehouseName);
            doc.SetParameterValue("ReportName", "Customer Target Vs. Achievement (By Month)");
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(_oTELLib.ServerDateTime()).ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("Month", sMonthName);
            doc.SetParameterValue("Year", Convert.ToString(nTGTYear));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Report();
        }

        private void frmCustomerTGTvsACH_Load(object sender, EventArgs e)
        {
            _oTELLib = new TELLib();
            dtDate.Value = _oTELLib.ServerDateTime();
        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblYear_Click(object sender, EventArgs e)
        {

        }
    }
}
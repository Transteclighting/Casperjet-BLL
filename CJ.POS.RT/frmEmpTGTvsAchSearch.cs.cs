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
    public partial class frmEmpTGTvsAchSearch : Form
    {
        RetailSalesInvoices _oDailySalesReports;
        SalesLeads _oSalesLeads;
        //SystemInfo oSystemInfo;
        TELLib _oTELLib;
        int _nType = 0;
        Employees oEmployees;
        public frmEmpTGTvsAchSearch(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void Report()
        {
            this.Cursor = Cursors.WaitCursor;
            _oDailySalesReports = new RetailSalesInvoices();
            _oTELLib = new TELLib();
            //oSystemInfo = new SystemInfo();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //oSystemInfo.Refresh();

            if (rdoByMonth.Checked == true)
            {
                int nTGTYear = Convert.ToInt32(dtDate.Value.Year);
                int nTGTMonth = Convert.ToInt32(dtDate.Value.Month);
                int nLastMonth = Convert.ToInt32(dtDate.Value.AddMonths(-1).Month);

                System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                string sMonthName = mfi.GetMonthName(nTGTMonth).ToString();
                string sLastMonth = mfi.GetMonthName(nLastMonth).ToString(); //nTGTMonth

                DateTime dtGetDate = Convert.ToDateTime((dtDate.Value.Date));
                DateTime FirstDateOfThisMonth = _oTELLib.FirstDayofMonth(dtGetDate);
                DateTime LastDateOfThisMonth = _oTELLib.LastDayofMonth(dtGetDate);
                DateTime FirstDayOfLastMonth = _oTELLib.FirstDayofLastMonth(dtGetDate);
                DateTime TodayOfLastMonth = dtGetDate.AddMonths(-1);
                DateTime FirstDateOfLYThisMonth = FirstDateOfThisMonth.AddYears(-1);
                DateTime TodayOfLYThisMonth = dtGetDate.AddYears(-1);

                _oDailySalesReports.TgtVsAchExecutiveWiseRT(FirstDateOfThisMonth, dtGetDate, FirstDayOfLastMonth, TodayOfLastMonth, FirstDateOfLYThisMonth, TodayOfLYThisMonth, nTGTYear, nTGTMonth);
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptEmpTGTvsAchValue));
                doc.SetDataSource(_oDailySalesReports);
                doc.SetParameterValue("UserName", Utility.Username);
                doc.SetParameterValue("CompanyName", Utility.CompanyName);
                doc.SetParameterValue("Outlet", Utility.WarehouseName);
                doc.SetParameterValue("ReportName", "Executive Wise Target Vs. Actual (Value)");

                doc.SetParameterValue("PrintDate", Convert.ToDateTime(_oTELLib.ServerDateTime()).ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("ThisMonth", "Up to (" + dtGetDate.ToString("dd-MMM-yyyy") + ")");
                doc.SetParameterValue("LastMonth", "Up to (" + TodayOfLastMonth.ToString("dd-MMM-yyyy") + ")");
                doc.SetParameterValue("LYThisMonth", "Up to (" + TodayOfLYThisMonth.ToString("dd-MMM-yyyy") + ")");


                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
            else
            {
                int nTGTYear = Convert.ToInt32(dtWeek.Value.Year);
                int nTGTMonth = Convert.ToInt32(dtWeek.Value.Month);
                int nLastMonth = Convert.ToInt32(dtDate.Value.AddMonths(-1).Month);

                System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                string sMonthName = mfi.GetMonthName(nTGTMonth).ToString();
                string sLastMonth = mfi.GetMonthName(nLastMonth).ToString();

                DateTime dtGetDate = Convert.ToDateTime((dtWeek.Value.Date));
                DateTime FirstDateOfThisMonth = _oTELLib.FirstDayofMonth(dtGetDate);
                DateTime LastDateOfThisMonth = _oTELLib.LastDayofMonth(dtGetDate);
                DateTime FirstDayOfLastMonth = _oTELLib.FirstDayofLastMonth(dtGetDate);
                DateTime TodayOfLastMonth = dtGetDate.AddMonths(-1);
                DateTime FirstDateOfLYThisMonth = FirstDateOfThisMonth.AddYears(-1);
                DateTime TodayOfLYThisMonth = dtGetDate.AddYears(-1);

                _oDailySalesReports.TgtVsAchExecutiveWiseWeekRT(FirstDateOfThisMonth, LastDateOfThisMonth, nTGTYear, nTGTMonth);
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptEmpTGTvsAchByWeek));
                doc.SetDataSource(_oDailySalesReports);
                doc.SetParameterValue("UserName", Utility.Username);
                doc.SetParameterValue("CompanyName", Utility.CompanyName);
                doc.SetParameterValue("Outlet", Utility.WarehouseName);
                doc.SetParameterValue("ReportName", "Executive Wise Weekly Target Vs. Actual (Value)");
                doc.SetParameterValue("PrintDate", Convert.ToDateTime(_oTELLib.ServerDateTime()).ToString("dd-MMM-yyyy"));
                doc.SetParameterValue("TargetYear", nTGTYear);
                doc.SetParameterValue("TargetMonth", sMonthName);

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
            this.Cursor = Cursors.Default;
        }

        public void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();
            oEmployees = new Employees();
            cmbEmpoyee.Items.Clear();
            oEmployees.GetShowroomSalesPersonRT();
            cmbEmpoyee.Items.Add("<ALL>");
            foreach (Employee oEmployee in oEmployees)
            {
                cmbEmpoyee.Items.Add(oEmployee.EmployeeName);
            }
            if (oEmployees.Count > 0)
                cmbEmpoyee.SelectedIndex = 0;
        }
        private void ReportforSalesLead()
        {
            this.Cursor = Cursors.WaitCursor;
            _oSalesLeads = new SalesLeads();
            _oTELLib = new TELLib();
            //oSystemInfo = new SystemInfo();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //oSystemInfo.Refresh();
            DateTime dtFirstDateOfThisMonth = _oTELLib.FirstDayofMonth(dtWeek.Value.Date);
            DateTime dtLastDateOfThisMonth = _oTELLib.LastDayofMonth(dtWeek.Value.Date);
            int nTYear = Convert.ToInt32(dtWeek.Value.Year);
            int nTMonth = Convert.ToInt32(dtWeek.Value.Month);

            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string sMonthName = mfi.GetMonthName(nTMonth).ToString();


            int nEmpID = 0;
            if (cmbEmpoyee.SelectedIndex == 0)
            {
                nEmpID = -1;
            }
            else
            {
                nEmpID = oEmployees[cmbEmpoyee.SelectedIndex - 1].EmployeeID;
            }

            _oSalesLeads.LeadTgtVsAchExecutiveWiseRT(Utility.WarehouseID, dtFirstDateOfThisMonth, dtLastDateOfThisMonth, nTYear, nTMonth, nEmpID);
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptLeadTGTvsActual));
            doc.SetDataSource(_oSalesLeads);

            doc.SetParameterValue("ReportName", "Executive & Channel Wise Sales Lead Summary Report");
            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", Utility.WarehouseName);
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(DateTime.Now.Date).ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("TargetMonth", sMonthName);
            doc.SetParameterValue("TargetYear", nTYear);

            //doc.SetParameterValue("ThisMonth", "Up to (" + dtGetDate.ToString("dd-MMM-yyyy") + ")");
            //doc.SetParameterValue("LastMonth", "Up to (" + TodayOfLastMonth.ToString("dd-MMM-yyyy") + ")");
            //doc.SetParameterValue("LYThisMonth", "Up to (" + TodayOfLYThisMonth.ToString("dd-MMM-yyyy") + ")");


            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_nType == 1)
            {
                Report();
            }
            else
            {
                ReportforSalesLead();
            }
        }

        private void frmEmpTGTvsAchSearch_Load(object sender, EventArgs e)
        {

            _oTELLib = new TELLib();
            
            if (_nType == 1)
            {
                dtDate.Visible = true;
                dtWeek.Visible = false;
                dtDate.Value = _oTELLib.ServerDateTime();
                dtWeek.Value = _oTELLib.ServerDateTime(); 
                lblSalesPerson.Visible = false;
                cmbEmpoyee.Visible = false;
                rdoByWeek.Visible = true;
                rdoByMonth.Visible = true;
                this.Text = "Executive Wise Sales Target Vs. Actual";
            }
            else
            {
                dtDate.Visible = false;
                dtWeek.Visible = true;
                dtWeek.Value = _oTELLib.ServerDateTime();
                lblSalesPerson.Visible = true;
                cmbEmpoyee.Visible = true;
                rdoByWeek.Visible = false;
                rdoByMonth.Visible = false;
                this.Text = "Executive Wise Lead Target Vs. Actual";
                LoadCombo();
            }
        }

        private void rdoByMonth_CheckedChanged(object sender, EventArgs e)
        {
            dtDate.Visible = true;
            dtWeek.Visible = false;
        }

        private void rdoByWeek_CheckedChanged(object sender, EventArgs e)
        {
            dtDate.Visible = false;
            dtWeek.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
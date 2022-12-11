using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.POS;
using CJ.Class.Library;
using CJ.Class.POS;
using CJ.Report;
using CJ.Report.Mini;
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmMAGWeekTargetVsActual : Form
    {
        CalendarWeeks _oCalendarWeeks;
        RetailSalesInvoices _oReport;
        TELLib _oTELLib;
        //SystemInfo oSystemInfo;
        int _nType = 0;
        Employees oEmployees;

        public frmMAGWeekTargetVsActual(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void frmMAGWeekTargetVsActual_Load(object sender, EventArgs e)
        {

            _oTELLib = new TELLib();
            dtMonth.Value = _oTELLib.ServerDateTime();
            lblSalesPerson.Visible = false;
            cmbEmpoyee.Visible = false;
            if (_nType == 1)
            {
                this.Text = "Channel, MAG & Brand Wise Weekly Target Vs. Actual";
                lblSalesPerson.Visible = false;
                cmbEmpoyee.Visible = false;
            }

            if (_nType == (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty)
            {
                this.Text = "Executive Wise Weekly Report (Qty & Value)";
                LoadSalesPerson();
                lblSalesPerson.Visible = true;
                cmbEmpoyee.Visible = true;

            }
            else if (_nType == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
            {
                this.Text = "Executive Wise Weekly Lead Report (Qty & Value)";
                LoadSalesPerson();
                lblSalesPerson.Visible = true;
                cmbEmpoyee.Visible = true;
            }

        }

        public void LoadSalesPerson()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
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

        private void LoadCombo()
        {

            DBController.Instance.OpenNewConnection();
            //Weeks
            _oCalendarWeeks = new CalendarWeeks();
            _oCalendarWeeks.GetWeeks(dtMonth.Value.Month, dtMonth.Value.Year);
            cmbWeek.Items.Clear();
            cmbWeek.Items.Add("<All>");
            foreach (CalendarWeek oCalendarWeek in _oCalendarWeeks)
            {
                cmbWeek.Items.Add(oCalendarWeek.WeekNo);
            }
            cmbWeek.SelectedIndex = 0;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_nType == 1)
            {
                Report();
            }
            else
            {
                ExecutiveWiseWeeklyReport();
            }
        }

        private void Report()
        {
            this.Cursor = Cursors.WaitCursor;
            _oReport = new RetailSalesInvoices();
            _oTELLib = new TELLib();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nTGTYear = Convert.ToInt32(dtMonth.Value.Year);
            int nTGTMonth = Convert.ToInt32(dtMonth.Value.Month);
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string sMonthName = mfi.GetMonthName(nTGTMonth).ToString();
            DateTime FirstDateOfThisMonth = _oTELLib.FirstDayofMonth(dtMonth.Value.Date);
            DateTime LastDateOfThisMonth = _oTELLib.LastDayofMonth(dtMonth.Value.Date).AddDays(1);
            int nWeek = 0;
            if (cmbWeek.SelectedIndex == 0)
            {
                nWeek = -1;
            }
            else
            {
                nWeek = _oCalendarWeeks[cmbWeek.SelectedIndex - 1].WeekNo;
            }

            _oReport.MAGWeekTgtVsAchRT(FirstDateOfThisMonth, LastDateOfThisMonth, nTGTYear, nTGTMonth, nWeek);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMAGWeekTargetVsActual));
            doc.SetDataSource(_oReport);
            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", Utility.WarehouseName);
            doc.SetParameterValue("ReportName", "Channel, MAG & Brand Wise Weekly Target Vs. Actual");
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(_oTELLib.ServerDateTime()).ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("TargetYear", nTGTYear.ToString());
            doc.SetParameterValue("TargetMonth", sMonthName.ToString());
            if (cmbWeek.SelectedIndex == 0)
            {
                doc.SetParameterValue("TargetWeek", "<ALL>");
            }
            else
            {
                doc.SetParameterValue("TargetWeek", nWeek.ToString());
            }

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

            this.Cursor = Cursors.Default;
        }

        private void ExecutiveWiseWeeklyReport()
        {
            this.Cursor = Cursors.WaitCursor;
            _oReport = new RetailSalesInvoices();
            _oTELLib = new TELLib();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nTGTYear = Convert.ToInt32(dtMonth.Value.Year);
            int nTGTMonth = Convert.ToInt32(dtMonth.Value.Month);
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string sMonthName = mfi.GetMonthName(nTGTMonth).ToString();
            DateTime FirstDateOfThisMonth = _oTELLib.FirstDayofMonth(dtMonth.Value.Date);
            DateTime LastDateOfThisMonth = _oTELLib.LastDayofMonth(dtMonth.Value.Date).AddDays(1);
            int nWeek = 0;
            if (cmbWeek.SelectedIndex == 0)
            {
                nWeek = -1;
            }
            else
            {
                nWeek = _oCalendarWeeks[cmbWeek.SelectedIndex - 1].WeekNo;
            }
            int nSalesPersonID = 0;
            if (cmbEmpoyee.SelectedIndex == 0)
            {
                nSalesPersonID = -1;
            }
            else
            {
                nSalesPersonID = oEmployees[cmbEmpoyee.SelectedIndex - 1].EmployeeID;
            }

            _oReport.EmployeeMAGWeekTgtVsAchRT(FirstDateOfThisMonth, LastDateOfThisMonth, nTGTYear, nTGTMonth, nWeek, _nType, nSalesPersonID);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptEmployeeWiseMAGWeekTargetVsActual));
            doc.SetDataSource(_oReport);
            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("Outlet", Utility.WarehouseName);
            if (_nType == (int)Dictionary.PlanVersionType.ExecutiveMAGWeekTargetQty)
            {
                doc.SetParameterValue("ReportName", "Executive Wise Weekly Report (Qty & Value)");
            }
            else if (_nType == (int)Dictionary.PlanVersionType.ExecutiveLeadTarget)
            {
                doc.SetParameterValue("ReportName", "Executive Wise Weekly Lead Report (Qty & Value)");
            }
            doc.SetParameterValue("PrintDate", Convert.ToDateTime(_oTELLib.ServerDateTime()).ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("TargetYear", nTGTYear.ToString());
            doc.SetParameterValue("TargetMonth", sMonthName.ToString());
            if (cmbWeek.SelectedIndex == 0)
            {
                doc.SetParameterValue("TargetWeek", "<ALL>");
            }
            else
            {
                doc.SetParameterValue("TargetWeek", nWeek.ToString());
            }
            doc.SetParameterValue("SalesPerson", cmbEmpoyee.Text.ToString());
            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

            this.Cursor = Cursors.Default;
        }

        private void dtMonth_ValueChanged(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
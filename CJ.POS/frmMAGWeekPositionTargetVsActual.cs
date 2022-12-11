using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;
using CJ.Report.POS;
using CJ.POS.TELWEBSERVER;
using CJ.Report;

namespace CJ.POS
{
    public partial class frmMAGWeekPositionTargetVsActual : Form
    {
        CalendarWeeks _oCalendarWeeks;
        RetailSalesInvoices _oReport;
        TELLib _oTELLib;
        Employees oEmployees;
        string _sReportType;

        public frmMAGWeekPositionTargetVsActual()
        {
            InitializeComponent();

        }

        private void frmMAGWeekTargetPositionVsActual_Load(object sender, EventArgs e)
        {
            dtMonth.Value = DateTime.Today;
            lblSalesPerson.Visible = false;
            cmbEmpoyee.Visible = false;
            this.Text = "Category wise Target Vs Actual";
            LoadSalesPerson();
            //lblSalesPerson.Visible = true;
            //cmbEmpoyee.Visible = true;


        }

        public void LoadSalesPerson()
        {
            DBController.Instance.OpenNewConnection();
            oEmployees = new Employees();
            cmbEmpoyee.Items.Clear();
            oEmployees.GetShowroomSalesPerson();
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

              Report();

        }

        private void Report()
        {
            this.Cursor = Cursors.WaitCursor;
            
            int Desc;
            if (Utility.InternetGetConnectedState(out Desc, 0))
            {
                try
                {
                    Service oSerivce = new Service();


                    try
                    {

                        System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                        string sMonthName = mfi.GetMonthName(Convert.ToInt32(dtMonth.Value.Month)).ToString();
                        int nWeek = -1;
                        if (cmbWeek.SelectedIndex == 0)
                        {
                            nWeek = -1;
                        }
                        else
                        {
                            nWeek = _oCalendarWeeks[cmbWeek.SelectedIndex - 1].WeekNo;
                        }
                        string sSalesPersonCode = "";
                        if (cmbEmpoyee.SelectedIndex == 0)
                        {
                            sSalesPersonCode = "";
                        }
                        else
                        {
                            sSalesPersonCode = oEmployees[cmbEmpoyee.SelectedIndex - 1].EmployeeCode;
                        }
                        string sType = "";
                        if (rdoExecutiveWise.Checked == true)
                        {
                            sType = "SE";
                        }
                        else
                        {
                            sType = "ABM";
                        }

                        CJ.POS.TELWEBSERVER.DSTargetvsActual oDSTargetvsActual = new CJ.POS.TELWEBSERVER.DSTargetvsActual();
                        CJ.Class.POS.DSTargetvsActual _oDSTargetvsActual = new CJ.Class.POS.DSTargetvsActual();

                        CJ.Class.DataTransfer.DataTransfer oDataTransfer = new CJ.Class.DataTransfer.DataTransfer();
                        oDSTargetvsActual = oSerivce.DownloadMAGWeekPositionTargetvsActual(oDSTargetvsActual, Utility.WarehouseID, Convert.ToInt32(dtMonth.Value.Month), Convert.ToInt32(dtMonth.Value.Year), nWeek, sSalesPersonCode, sType);

                        _oDSTargetvsActual.Merge(oDSTargetvsActual);
                        _oDSTargetvsActual.AcceptChanges();


                        if (_oDSTargetvsActual.MAGWeekPositionTargetvsActual.Count > 0)
                        {



                            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptMAGWeekPositionTargetVsActual));
                            doc.SetDataSource(_oDSTargetvsActual);
                            doc.SetParameterValue("UserName", Utility.EmployeeDetail);
                            doc.SetParameterValue("CompanyName", Utility.CompanyName);
                            doc.SetParameterValue("Outlet", Utility.WarehouseName);
                            doc.SetParameterValue("ReportName", "Channel, MAG & Brand Wise Weekly Target Vs. Actual");
                            doc.SetParameterValue("PrintDate", Convert.ToDateTime(Utility.SystemDate).ToString("dd-MMM-yyyy"));
                            doc.SetParameterValue("TargetYear", Convert.ToInt32(dtMonth.Value.Year).ToString());
                            doc.SetParameterValue("TargetMonth", sMonthName.ToString());

                            if (cmbWeek.SelectedIndex == 0)
                            {
                                doc.SetParameterValue("TargetWeek", "<ALL>");
                            }
                            else
                            {
                                doc.SetParameterValue("TargetWeek", nWeek.ToString());
                            }
                            doc.SetParameterValue("PrintedBy", Utility.EmployeeDetail);
                            frmPrintPreview frmView;
                            frmView = new frmPrintPreview();
                            frmView.ShowDialog(doc);
                        }
                        else
                        {
                            MessageBox.Show("There is no data ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        AppLogger.LogError("Error getting report data/" + ex.Message);
                        MessageBox.Show("Error getting report data\nSystem Date: " + Convert.ToDateTime(Utility.SystemDate).ToString("dd-MMM-yyyy") + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch
                {
                    MessageBox.Show("Please Check Internet Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please Check Internet Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


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
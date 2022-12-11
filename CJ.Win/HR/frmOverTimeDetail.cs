using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;
using CJ.Class.Library;
using CJ.Report;

namespace CJ.Win.HR
{
    public partial class frmOverTimeDetail : Form
    {
        HROverTimes _oHROverTimes;
        HROverTime _oTotal;
        TELLib _oTELLib;
        Companys _oCompanys;
        Departments _oDepartments;

        public frmOverTimeDetail()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cmbCompany.Items.Clear();
            //cmbCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;


            //Department
            _oDepartments = new Departments();
            _oDepartments.Refresh(Utility.UserId);
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("<All>");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;

            //HR OverTime Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HROverTimeStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.HROverTimeStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }
        private void Report()
        {

            HROverTimes oHrOverTimes = new HROverTimes();
            _oTELLib = new TELLib();

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }
            int nEmployeeID = 0;
            if (ctlEmployee1.txtCode.Text == "")
            {
                nEmployeeID = -1;
            }
            else
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            } 


            int nCompanyId = 0;
            //if (cmbCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            nCompanyId = _oCompanys[cmbCompany.SelectedIndex].CompanyID;


            int nDepartmentId = 0;
            if (cmbDepartment.SelectedIndex > 0) nDepartmentId = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            //nDepartmentID = _oDepartments[cmbDepartment.SelectedIndex].DepartmentID;


            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string sMonthName = mfi.GetMonthName(dtMonthYear.Value.Month).ToString();
            _oTotal = new HROverTime();
            _oTotal.GetTotalForReport(dtMonthYear.Value.Month, dtMonthYear.Value.Year, nStatus, nDepartmentId, nCompanyId, nEmployeeID);

            oHrOverTimes.GetSummary(dtMonthYear.Value.Month, dtMonthYear.Value.Year, nStatus, nDepartmentId, nCompanyId, nEmployeeID);
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptOverTimeSummary));

            List<OverTime> aList = new List<OverTime>();

            foreach (HROverTime oHrOverTime in oHrOverTimes)
            {
                var aHrOverTime = new OverTime
                {
                    EmployeeName = oHrOverTime.EmployeeName,
                    GTotalHour = oHrOverTime.GTotalHour,
                    GTotalLessHour = oHrOverTime.GTotalLessHour,
                    NetHour = oHrOverTime.NetHour,
                    Amount = oHrOverTime.Amount

                };
                aList.Add(aHrOverTime);
            }

            doc.SetDataSource(aList);
            //doc.SetDataSource(oHrOverTimes);

            if (cmbCompany.SelectedIndex == 0)
            {
                doc.SetParameterValue("CompanyName", Utility.CompanyName);
            }
            else
            {
                doc.SetParameterValue("CompanyName", cmbCompany.Text);
            }
            doc.SetParameterValue("ReportName", "Month Wise Overtime Summary");
            doc.SetParameterValue("Month", sMonthName);
            doc.SetParameterValue("Year", Convert.ToString(dtMonthYear.Value.Year));
            doc.SetParameterValue("Status", cmbStatus.Text);
            doc.SetParameterValue("Department", cmbDepartment.Text);
            doc.SetParameterValue("EmployeeName", ctlEmployee1.txtDescription.Text);
            doc.SetParameterValue("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("TotalHour", Convert.ToString(_oTotal.Hour));
            doc.SetParameterValue("LessHour", Convert.ToString(_oTotal.GLessHour));
            doc.SetParameterValue("NetHour", Convert.ToString(_oTotal.GNetHour));



            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
            Report();
            DBController.Instance.CloseConnection();
            this.Cursor = Cursors.Default;
        }

        private void frmOverTimeDetail_Load(object sender, EventArgs e)
        {
            dtMonthYear.Value = DateTime.Now;
            LoadCombos();
        }


    }
}
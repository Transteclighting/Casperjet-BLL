using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;
using CJ.Report;
using CJ.Report.HR;
using CJ.Class.Report;
using System.Globalization;

namespace CJ.Win.HR
{
    public partial class frmHRAttendInfoView : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        private Employee _oEmployee;
        int _nIsFactoryAttendence;

        DayOfWeek firstWeekDay = DayOfWeek.Friday;
        DayOfWeek lastWeekDay = DayOfWeek.Thursday;
        public frmHRAttendInfoView(int nIsFactoryAttendence)
        {
            InitializeComponent();
            _nIsFactoryAttendence = nIsFactoryAttendence;
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();

            //Company
            _oCompanys = new Companys();
            _oCompanys.GetCompany();
            cmbCompany.Items.Clear();
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.GetDepartmentAll();
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("All");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartment.SelectedIndex = 0;
        }
        private void frmHRAttendInfoView_Load(object sender, EventArgs e)
        {
            //LoadCombos();

            if (_nIsFactoryAttendence == 0)
            {
                dtFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                LoadCombos();
            }
            else if(_nIsFactoryAttendence == 1)
            {
                //if(DateTime.Today.DayOfWeek == firstWeekDay)
                //GetWeekdayInRange(Convert.ToDateTime("2021-Sep-1"), Convert.ToDateTime("2021-Sep-20"), firstWeekDay);

                //dtFromDate.Value = GetFirstdayInRange(DateTime.Today, firstWeekDay);
                //dtToDate.Value = GetLastdayInRange(DateTime.Today, lastWeekDay);
                dtFromDate.Visible = false;
                lblDate.Visible = false;
                dtToDate.Visible = false;
                lblTo.Visible = false;
                dtMonth.Visible = true;
                lblMonth.Visible = true;
                LoadCombos();
                this.Text = "Attendance and Overtime Register";
            }

            else if (_nIsFactoryAttendence == 2)
            {
                this.Text = "Leave Register";
                dtFromDate.Visible = false;
                dtToDate.Visible = false;
                lblDate.Visible = false;
                lblTo.Visible = false;
            }
        }

        public static DateTime GetFirstdayInRange(DateTime from, DayOfWeek day)
        {
            const int daysInWeek = 7;


            var daysToAdd = ((int)day - (int)from.DayOfWeek + daysInWeek) % daysInWeek - daysInWeek;


            from = from.AddDays(daysToAdd);

            return from;
        }

        public static DateTime GetLastdayInRange(DateTime from, DayOfWeek day)
        {
            const int daysInWeek = 7;


            var daysToAdd = ((int)day - (int)from.DayOfWeek + daysInWeek) % daysInWeek;


            from = from.AddDays(daysToAdd);

            return from;
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            if (dtToDate.Value.Date > dtFromDate.Value.AddDays(31))
            {
                MessageBox.Show("Can't view over 31 days attendance data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtToDate.Focus();
                return false;
            }
            else if (dtFromDate.Value.Date > dtToDate.Value.Date)
            {
                MessageBox.Show("To Date Must be Greater Than From Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtToDate.Focus();
                return false;
            }

            //else if (_nIsFactoryAttendence == 1)
            //{
            //    if (cmbCompany.SelectedIndex==-1)
            //    {
            //        if (ctlEmployee1.txtCode.Text.Trim() != "")
            //        {
            //            MessageBox.Show("Please select a Company", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //    }
            //} 

            //if (_nIsFactoryAttendence == 1)
            //{
            //    System.DayOfWeek i = dtFromDate.Value.DayOfWeek;

            //    if ((i != System.DayOfWeek.Friday))
            //    {
            //        MessageBox.Show("Please Friday as Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //        return false;
            //    }
            //}

            if (_nIsFactoryAttendence == 2)
            {
                if(ctlEmployee1.txtCode.Text.Trim()=="")
                {
                    MessageBox.Show("Please select an Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    return false;
                }
                //ctlEmployee1.SelectedEmployee.
            }

                #endregion

                return true;
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                if (_nIsFactoryAttendence == 0)
                {
                    DataView();
                }
                else if (_nIsFactoryAttendence == 1)
                {
                    PrintAttendanceForFactory();
                }
                else if (_nIsFactoryAttendence == 2)
                {
                    PrintLeaveForFactory();
                }

            }
        }

        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            //if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            //{
            //    time = time.AddDays(3);
            //}

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Friday);
        }

        private void PrintAttendanceForFactory()
        {
            rptHRAttendSummarys oDatas = new rptHRAttendSummarys();
            int nWeekNumber = 0;
            nWeekNumber = GetIso8601WeekOfYear(dtFromDate.Value.Date);

            string sMonth = dtMonth.Text;

            int nCompanyID = 0;
            if (cmbCompany.SelectedIndex >= 0)
                nCompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;

            int nDepartmentID = 0;
            if (cmbDepartment.SelectedIndex > 0)
            {
                nDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }
            else
            {
                nDepartmentID = 0;
            }
            int nEmployeeID = 0;
            try
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                nCompanyID = ctlEmployee1.SelectedEmployee.CompanyID;
                nDepartmentID = ctlEmployee1.SelectedEmployee.DepartmentID;
            }
            catch
            {
                nEmployeeID = -1;
            }
           
            //int nType = 0;            
            
                oDatas.RefreshFactoryFormate(dtMonth.Value.Month, dtMonth.Value.Year, nCompanyID, nDepartmentID, nEmployeeID);
                rptDailyAttendanceAndOvertimeRegister oReport = new rptDailyAttendanceAndOvertimeRegister();
                oReport.SetDataSource(oDatas);

            //oReport.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            //oReport.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            if (ctlEmployee1.txtDescription.Text.Trim() != "")
            {
                _oEmployee = new Employee();
                _oEmployee.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                _oEmployee.ReadDB = true;
                _oEmployee.Refresh();
                oReport.SetParameterValue("Company", _oEmployee.Company.CompanyName);
            }
            else
            {
                oReport.SetParameterValue("Company", _oCompanys[cmbCompany.SelectedIndex].CompanyName);
            }
            oReport.SetParameterValue("CompanyAddress", "Gashirdia, Shashpur, Shibpur, Narsingdi");
            oReport.SetParameterValue("Month", sMonth);
            oReport.SetParameterValue("RegNo", "");
            //oReport.SetParameterValue("Location", cmbLocation.Text);
            frmPrintPreview oFrom = new frmPrintPreview();

                oFrom.ShowDialog(oReport);
           
        }
        EmployeeLeaves _oEmployeeLeaves = new EmployeeLeaves();
        double _nEarnLeave = 0;
        double _nSickLeave = 0;
        double _nCasualLeave = 0;
        private void PrintLeaveForFactory()
        {
            _oEmployeeLeaves = new EmployeeLeaves();
            int nEmployeeID = 0;
            nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            EmployeeLeaves oEmployeeLeavesBalance = new EmployeeLeaves();

            
            DSAttendance dsAtt = new DSAttendance();
            _oEmployeeLeaves.GetLeaveAllowedByEmployee(ctlEmployee1.txtCode.Text.Trim());

            _nSickLeave = _oEmployeeLeaves[0].LeaveAllowed;
            _nEarnLeave = _oEmployeeLeaves[1].LeaveAllowed;
            _nCasualLeave = _oEmployeeLeaves[2].LeaveAllowed;

            double nLeaveBalance = 0;
            foreach (EmployeeLeave oLeave in _oEmployeeLeaves)
            {
                oEmployeeLeavesBalance.GetFactoryLeaveByEmployee(oLeave.EmployeeID,DateTime.Today,DateTime.Today, oLeave.LeaveType);

                nLeaveBalance = oLeave.LeaveAllowed;

                foreach (EmployeeLeave oL in oEmployeeLeavesBalance)
                {
                    DSAttendance.LeaveRegisterRow oRow = dsAtt.LeaveRegister.NewLeaveRegisterRow();
                    oRow.EarnLeave = oLeave.LeaveAllowed;
                    if (oLeave.LeaveType == 0)
                    {
                        oRow.SickLeaveApplied = oL.LeaveTotal;
                    }

                    if (oLeave.LeaveType == 1)
                    {
                        oRow.EarnLeaveApplied = oL.LeaveTotal;
                    }

                    if (oLeave.LeaveType == 2)
                    {
                        oRow.CasualLeaveApplied = oL.LeaveTotal;
                    }
                   
                    oRow.RejectReason = oL.RejectReason;
                    oRow.ApprovedDate = oL.ApprovedDate;
                    oRow.LeaveApproved = oL.LeaveTotal;
                    oRow.EarnLeaveAdjustment = oL.EarnLeaveAdjustment;

                    if (oLeave.LeaveType == 0)
                    {
                        nLeaveBalance = nLeaveBalance - oL.LeaveTotal;
                        oRow.SickLeaveRemain = nLeaveBalance;
                        //oRow.EarnLeaveRemain = _oEmployeeLeaves[1].LeaveAllowed;
                        //oRow.CasualLeaveRemain = _oEmployeeLeaves[2].LeaveAllowed;
                    }

                    if (oLeave.LeaveType == 1)
                    {
                        nLeaveBalance = nLeaveBalance - oL.LeaveTotal;
                        oRow.EarnLeaveRemain = nLeaveBalance;
                        //oRow.CasualLeaveRemain = _oEmployeeLeaves[2].LeaveAllowed;
                        //oRow.SickLeaveRemain = _oEmployeeLeaves[0].LeaveAllowed;
                    }
                    if (oLeave.LeaveType == 2)
                    {
                        nLeaveBalance = nLeaveBalance -oL.LeaveTotal;
                        oRow.CasualLeaveRemain = nLeaveBalance;
                        //oRow.EarnLeaveRemain = _oEmployeeLeaves[1].LeaveAllowed;
                        //oRow.SickLeaveRemain = _oEmployeeLeaves[0].LeaveAllowed;
                    }
                    oRow.LeaveType = oLeave.LeaveType;
                    dsAtt.LeaveRegister.AddLeaveRegisterRow(oRow);
                }
            }
            dsAtt.AcceptChanges();

            dsAtt.Tables["LeaveRegister"].DefaultView.Sort = "ApprovedDate asc";

            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            oEmployee.RefreshDetail();

            DataTable dt1 = dsAtt.Tables["LeaveRegister"].DefaultView.ToTable();

            //DataTable dtnew = new DataTable();
            //foreach (DataRow dr in dt1.Rows)
            //{
            //    if (Convert.ToInt32(dr["LeaveType"]) == 0)
            //    {
            //        dr["SickLeaveRemain"] = _nSickLeave- Convert.ToDouble(dr["SickLeaveRemain"]);
            //        dr["EarnLeaveRemain"] = _nEarnLeave - Convert.ToDouble(dr["EarnLeaveRemain"]);
            //        dr["CasualLeaveRemain"] = _nCasualLeave - Convert.ToDouble(dr["CasualLeaveRemain"]);
            //        _nSickLeave= _nSickLeave - Convert.ToDouble(dr["SickLeaveRemain"]);
            //    }
            //    if (Convert.ToInt32(dr["LeaveType"]) == 1)
            //    {
            //        dr["SickLeaveRemain"] = _nSickLeave - Convert.ToDouble(dr["SickLeaveRemain"]);
            //        dr["EarnLeaveRemain"] = _nEarnLeave - Convert.ToDouble(dr["EarnLeaveRemain"]);
            //        dr["CasualLeaveRemain"] = _nCasualLeave - Convert.ToDouble(dr["CasualLeaveRemain"]);
            //        _nEarnLeave = _nEarnLeave - Convert.ToDouble(dr["EarnLeaveRemain"]);
            //    }
            //    if (Convert.ToInt32(dr["LeaveType"]) == 2)
            //    {
            //        dr["SickLeaveRemain"] = _nSickLeave - Convert.ToDouble(dr["SickLeaveRemain"]);
            //        dr["EarnLeaveRemain"] = _nEarnLeave - Convert.ToDouble(dr["EarnLeaveRemain"]);
            //        dr["CasualLeaveRemain"] = _nCasualLeave - Convert.ToDouble(dr["CasualLeaveRemain"]);
            //        _nCasualLeave = _nCasualLeave - Convert.ToDouble(dr["CasualLeaveRemain"]);
            //    }
            //    dtnew.Rows.Add(dr.ItemArray);
            //}

            //int nType = 0;            

            List<EmployeeLeaves> oEmployeeLeaves = new List<EmployeeLeaves>();
            //studentDetails = (EmployeeLeaves)dsAtt.Tables["LeaveRegister"];

            rptLeaveRegisterAndLeaveBook oReport = new rptLeaveRegisterAndLeaveBook();
            oReport.SetDataSource(dt1);


            //oReport.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            //oReport.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));

            oReport.SetParameterValue("Company", oEmployee.ComapanyName);
            oReport.SetParameterValue("Address", "Gashirdia, Shashpur, Shibpur, Narsingdi");//oEmployee.JoblocationName);//
            oReport.SetParameterValue("EmployeeCode", oEmployee.EmployeeCode);
            oReport.SetParameterValue("EmployeeName", oEmployee.EmployeeName);
            oReport.SetParameterValue("DepartmentName", oEmployee.DepartmentName);
            oReport.SetParameterValue("DesignationName", oEmployee.DesignationName);
            oReport.SetParameterValue("JoiningDate", ctlEmployee1.SelectedEmployee.JoiningDate);
            //oReport.SetParameterValue("Location", cmbLocation.Text);
            frmPrintPreview oFrom = new frmPrintPreview();

            oFrom.ShowDialog(oReport);

        }
        private void DataView()
        {
            this.Cursor = Cursors.WaitCursor;
            int nCompanyID = 0;
            if (cmbCompany.SelectedIndex >= 0) nCompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;

            int nSearchDepartmentID;
            if (cmbDepartment.SelectedIndex == 0)
            {
                nSearchDepartmentID = -1;
            }
            else
            {
                nSearchDepartmentID = _oDepartments[cmbDepartment.SelectedIndex - 1].DepartmentID;
            }

            int nEmployeeID = -1;
            if (ctlEmployee1.txtDescription.Text != string.Empty)
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }

            HRAttendInfos _oHRAttendInfos = new HRAttendInfos();
            DSAttendance _oDSAttendanceRaw = new DSAttendance();
            
            _oDSAttendanceRaw = _oHRAttendInfos.GetHRAttendInfoRawData(dtFromDate.Value.Date, dtToDate.Value.Date, nCompanyID, nSearchDepartmentID, nEmployeeID,chkIsFactoryEmployee.Checked);
            _oHRAttendInfos.GetHRAttendInfoReportRevised(_oDSAttendanceRaw, dtFromDate.Value.Date, dtToDate.Value.Date, nCompanyID, nSearchDepartmentID, nEmployeeID, chkIsFactoryEmployee.Checked);

            rptHRAttendInfoView doc;
            doc = new rptHRAttendInfoView();
            doc.SetDataSource(_oHRAttendInfos);
            doc.SetParameterValue("PrintUser", Utility.UserFullname);
            doc.SetParameterValue("Company", cmbCompany.Text);
            doc.SetParameterValue("Department", cmbDepartment.Text);
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));

            for (int i = 1; i <= 31; i++)
            {
                doc.SetParameterValue("_" + i, "--");
            }

            DateTime _dFromDate = dtFromDate.Value.Date;
            double _TotalDay = (dtToDate.Value.Date - dtFromDate.Value.Date).TotalDays;
            int nCount = 0;
            for (int i = 0; i <= _TotalDay; i++)
            {
                nCount++;
                int _Day = _dFromDate.AddDays(i).Day;

                doc.SetParameterValue("_" + nCount, _Day.ToString());
            }

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;

        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (_nIsFactoryAttendence == 1)
            {
                dtToDate.Value= dtFromDate.Value.AddDays(6);
                dtToDate.Enabled = false;
                //System.DayOfWeek i = dtFromDate.Value.DayOfWeek;

                //if ((i == System.DayOfWeek.Friday))
                //{

                //}
                //else 
                //{
                //    MessageBox.Show("Please try again, you can only select Friday");
                //    dtFromDate.Value = GetFirstdayInRange(DateTime.Today, firstWeekDay);
                //    return;
                //}
            }
        }

        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            //if (_nIsFactoryAttendence == 1)
            //{
            //    System.DayOfWeek i = dtToDate.Value.DayOfWeek;
            //    if ((i == System.DayOfWeek.Thursday))
            //    {

            //    }
            //    else
            //    {
            //        MessageBox.Show("Please try again, you can only select Thursday");
            //        dtToDate.Value = GetLastdayInRange(DateTime.Today, lastWeekDay);
            //        return;
            //    }
            //}
        }

        //public static List<DateTime> GetWeekdayInRange(DateTime from, DateTime to, DayOfWeek day)
        //{
        //    const int daysInWeek = 7;
        //    var result = new List<DateTime>();
        //    var daysToAdd = ((int)day - (int)from.DayOfWeek + daysInWeek) % daysInWeek;

        //    do
        //    {
        //        from = from.AddDays(daysToAdd);
        //        result.Add(from);
        //        daysToAdd = daysInWeek;
        //    } while (from < to);

        //    return result;
        //}
    }
}

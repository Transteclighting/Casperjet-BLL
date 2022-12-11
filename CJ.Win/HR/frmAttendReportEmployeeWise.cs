// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 05, 2011
// Time :  4:55 PM
// Description: Class for Attendance Data.
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
using CJ.Class.Report;
using CJ.Report;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmAttendReportEmployeeWise : Form
    {       
        private AttendInfos _oAttendInfos;
        OutStationDuty oOutStationDuty;
        Setting oSetting;

        public frmAttendReportEmployeeWise()
        {
            InitializeComponent();
        }
     
        private void frmAttendReportEmployeeWise_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }
        private void LoadCombos()
        {          

            //Attendance Status
            cboStatus.Items.Clear();
            cboStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRAttendanceStatus)))
            {
                cboStatus.Items.Add(Enum.GetName(typeof(Dictionary.HRAttendanceStatus), GetEnum));
            }
            cboStatus.SelectedIndex = 0;
        }
        private void DataLoadControl() 
        {
            //string sDateFrom = "08:00:00";
            _oAttendInfos = new AttendInfos();
            lvwAttendInfos.Items.Clear();
            DBController.Instance.OpenNewConnection();
            int nStatus = -1;
            if (cboStatus.SelectedIndex > 0) nStatus = cboStatus.SelectedIndex - 1;

            _oAttendInfos.RefreshByEmployeeWise(dtFromDate.Value.Date, dtToDate.Value.Date, nStatus, ctlEmployee1.SelectedEmployee.EmployeeID);
            this.Text = "AttendInfo " + "[" + _oAttendInfos.Count + "]";
            int i = 0;
            foreach (AttendInfo oAttendInfo in _oAttendInfos)
            {
                ListViewItem oItem  = lvwAttendInfos.Items.Add(oAttendInfo.PunchDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oAttendInfo.Date.ToString());
                if (oAttendInfo.TimeIn == null) oItem.SubItems.Add("");
                else oItem.SubItems.Add(((DateTime)oAttendInfo.TimeIn).ToString("hh:mm tt"));
                if (oAttendInfo.TimeOut == null) oItem.SubItems.Add("");
                else oItem.SubItems.Add(((DateTime)oAttendInfo.TimeOut).ToString("hh:mm tt"));
                if (oAttendInfo.Late == null) oItem.SubItems.Add("");
                else oItem.SubItems.Add(((DateTime)oAttendInfo.Late).ToString("HH:mm"));
                oItem.SubItems.Add(oAttendInfo.TotalHour.ToString());
                oItem.SubItems.Add(oAttendInfo.LessExtraTime.ToString());
                oItem.SubItems.Add(oAttendInfo.PunchCount.ToString());
                oItem.SubItems.Add(oAttendInfo.Status.ToString());

                switch (oAttendInfo.Status)
                {
                    case Dictionary.HRAttendanceStatus.Absent:
                        lvwAttendInfos.Items[i].SubItems[8].BackColor = Color.FromArgb(255, 200, 200);
                        break;
                    case Dictionary.HRAttendanceStatus.Holiday:
                        lvwAttendInfos.Items[i].SubItems[8].BackColor = Color.FromArgb(200, 255, 200);
                        break;
                    case Dictionary.HRAttendanceStatus.Late:
                        lvwAttendInfos.Items[i].SubItems[8].BackColor = Color.FromArgb(255, 255, 200);
                        break;                                                
                }
                lvwAttendInfos.Items[i].UseItemStyleForSubItems = false;
                if (oAttendInfo.LessExtraTime.ToString().Contains("-"))
                {
                    lvwAttendInfos.Items[i].SubItems[6].ForeColor = Color.Red;
                }

                else
                {
                    lvwAttendInfos.Items[i].SubItems[6].ForeColor = Color.Green;
                }

                i++;
                oItem.Tag = oAttendInfo;
            }
        }
        private void setListViewRowColour()
        {
            if (lvwAttendInfos.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwAttendInfos.Items)
                {
                    if (oItem.SubItems[8].Text == "Absent")
                    {
                        oItem.BackColor = Color.FromArgb(255, 200, 200);
                    }
                    else if (oItem.SubItems[8].Text == "Holiday")
                    {
                        oItem.BackColor = Color.FromArgb(200, 255, 200);
                    }
                    else if (oItem.SubItems[8].Text == "Late")
                    {
                        oItem.BackColor = Color.FromArgb(255, 255, 200);
                    }
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ctlEmployee1.SelectedEmployee != null)
            {
                this.Cursor = Cursors.WaitCursor;
                DataLoadControl();
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Sealect a Employee.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            oSetting = new Setting();
            oSetting.Refresh();

            DateTime dTimeOut;
            DateTime dSTimeOut;
            int nTotalAbsent = 0;
            int nTotalPresent = 0;
            int nTotalLate = 0;
            int nTotalHourCount = 0;
            int nLessHourCount = 0;
            int nMoreHourCount = 0;
            int nTotalRemarks = 0;

            if (_oAttendInfos==null)
            {
                MessageBox.Show("First Search then print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_oAttendInfos.Count <=0)
            {
                MessageBox.Show("First Search then print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            rptHRAttendInfos orptAttendInfos = new rptHRAttendInfos();
            CJ.Class.Report.rptHRAttendInfo orptAttendInfo;

            double AddTotalHour = 0;
            double TotalLessTime = 0;
            double TotalMoreTime = 0;
            int nTotalLess = 0;
            int nTotalExtra = 0;
            int nTotalHour = 0;

            AttendInfo oInfoForExtra = new AttendInfo();
            oInfoForExtra.GetWorkingHour(dtFromDate.Value.Date, dtToDate.Value.Date, ctlEmployee1.txtCode.Text);

            foreach (AttendInfo oAttendInfo in _oAttendInfos)
            {
                orptAttendInfo = new  CJ.Class.Report.rptHRAttendInfo();          
                orptAttendInfo._dPunchDate = oAttendInfo.PunchDate;
                orptAttendInfo._dDate = oAttendInfo.Date;
                if (oAttendInfo.TimeIn == null) orptAttendInfo._dTimeIn = "";
                else orptAttendInfo._dTimeIn = ((DateTime)oAttendInfo.TimeIn).ToString("hh:mm tt");
                if (oAttendInfo.TimeOut == null) orptAttendInfo._dTimeOut = "";
                else orptAttendInfo._dTimeOut = ((DateTime)oAttendInfo.TimeOut).ToString("hh:mm tt");
                if (oAttendInfo.Late == null) orptAttendInfo._dLate = "";
                else orptAttendInfo._dLate = ((DateTime)oAttendInfo.Late).ToString("HH:mm");
                orptAttendInfo._nPunchCount = oAttendInfo.PunchCount;

                string sTimeOut = Convert.ToDateTime(oAttendInfo.TimeOut).ToString("hh:mm tt");
                string sSTimeOut = Convert.ToDateTime(oSetting.TimeOut).ToString("hh:mm tt");                

                dTimeOut = Convert.ToDateTime(sTimeOut);
                dSTimeOut = Convert.ToDateTime(sSTimeOut);
                orptAttendInfo._nTotalHour = oAttendInfo.TotalHour;

                if (dTimeOut > dSTimeOut)
                    orptAttendInfo._sRemarks = "Stayed after " + sSTimeOut;
                else orptAttendInfo._sRemarks = oAttendInfo.Remarks;
                orptAttendInfo._dLessExtraTime = oAttendInfo.LessExtraTime;

                //----------------------------
                string sLessMoreTotalTime = Convert.ToString(oAttendInfo.LessExtraTime);
                // Split authors separated by a comma followed by space  
                string[] sList = sLessMoreTotalTime.Split(':');
                int nCount = 0;
                int nTotal = 0;

                foreach (string oItem in sList)
                {
                    if (sLessMoreTotalTime != ":")
                    {
                        if (nCount == 0)
                        {
                            nTotal = Convert.ToInt32(oItem);
                            nTotal = nTotal * 60;

                            nCount++;
                        }
                        else
                        {
                            if (nTotal < 0)

                            {
                                nTotal = nTotal * -1;                                   
                                nTotal += Convert.ToInt32(oItem);
                                nTotal = nTotal * -1;
                            }
                            else
                            {
                                nTotal += Convert.ToInt32(oItem);
                            }
                               
                        }
                    }
                }

                if (nTotal > 0)
                {
                    nTotalExtra += nTotal;
                }
                else
                {
                    nTotalLess += nTotal;
                }

                //--------------------------------

                orptAttendInfos.Add(orptAttendInfo);
                orptAttendInfo._sStatus = oAttendInfo.Status.ToString();
                if (orptAttendInfo._sStatus == "Absent")
                {
                    nTotalAbsent++;                                      
                }
                if (orptAttendInfo._sStatus == "Present")
                    nTotalPresent++;
                if (orptAttendInfo._sStatus == "Late")
                    nTotalLate++;
                if (orptAttendInfo._sStatus == "Present" || orptAttendInfo._sStatus == "Late")
                    nTotalHourCount++;

                //bool s = orptAttendInfo._dLessExtraTime.ToString().Contains("-");

                if (!orptAttendInfo._dLessExtraTime.ToString().Contains("-") & orptAttendInfo._sStatus != "Holiday" & orptAttendInfo._sStatus != "Absent")
                {
                    nMoreHourCount++;
                }
                if (orptAttendInfo._dLessExtraTime.ToString().Contains("-"))
                {
                    nLessHourCount++;
                }
                if (orptAttendInfo._sRemarks == "Stayed after 07:00 PM")
                    nTotalRemarks++;
            }
             TotalLessTime = Math.Round((double) nTotalLess / 60, 2);
             TotalMoreTime = Math.Round((double) nTotalExtra / 60,2);

            Employee oEmployee = ctlEmployee1.SelectedEmployee;
            oEmployee.ReadDB = true;
            rptHRAttendInfoEmployee oReport = new rptHRAttendInfoEmployee();

            oReport.SetDataSource(orptAttendInfos);

            oReport.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));

            oReport.SetParameterValue("Company", oEmployee.Company.CompanyName);
            oReport.SetParameterValue("Department", oEmployee.Department.DepartmentName);
            oReport.SetParameterValue("User Name", Utility.Username);
            oReport.SetParameterValue("Status", cboStatus.Text);
            oReport.SetParameterValue("EmpCode", ctlEmployee1.SelectedEmployee.EmployeeCode);
            oReport.SetParameterValue("EmpName", ctlEmployee1.SelectedEmployee.EmployeeName);
            oReport.SetParameterValue("Total Present", nTotalPresent.ToString()+" Days");
            oReport.SetParameterValue("Total Absent", nTotalAbsent.ToString()+" Days");
            oReport.SetParameterValue("Total Late", nTotalLate.ToString() + " Days");
            oReport.SetParameterValue("Total Hour", AddTotalHour.ToString() + " Hours");
            oReport.SetParameterValue("Total Hour Count", nTotalHourCount.ToString() + " Days");
            oReport.SetParameterValue("Total Less Time", TotalLessTime.ToString() + " Hours");
            oReport.SetParameterValue("Total More Time", TotalMoreTime.ToString() + " Hours");
            oReport.SetParameterValue("Less Hour Count", nLessHourCount.ToString() + " Days");
            oReport.SetParameterValue("More Hour Count", nMoreHourCount.ToString() + " Days");
            oReport.SetParameterValue("Total Remarks", nTotalRemarks.ToString() + " Days");


            oReport.SetParameterValue("LessWorkHour", oInfoForExtra.LessWorkHour.ToString() + " Hours (" + oInfoForExtra.CountLessWorkingDay.ToString() + " Days)");
            oReport.SetParameterValue("MoreWorkHour", oInfoForExtra.MoreWorkHour.ToString() + " Hours (" + oInfoForExtra.CountExtraWorkingDay.ToString() + " Days)");
            oReport.SetParameterValue("StandardWorkHour", oInfoForExtra.StandardWorkHoure.ToString() + " Hours (" + oInfoForExtra.CountStandardWarkingDay.ToString() + " Days)");
            oReport.SetParameterValue("ActualWorkHour", oInfoForExtra.ActualWorkHour.ToString() + " Hours (" + oInfoForExtra.CountStandardWarkingDay.ToString() + " Days)");

            frmPrintPreview oFrom = new frmPrintPreview();

            oFrom.ShowDialog(oReport);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

using CJ.Class;
using CJ.Class.CSD;
using Microsoft.VisualBasic.FileIO;

namespace CJ.AttendanceProcess
{
    public partial class Form1 : Form
    {
        string _sArg;
        public Form1(string sArg)
        {
            InitializeComponent();
            _sArg = sArg;

            if (_sArg == "Auto")
            {
                btnProcessNew_Click(null, null);
                this.Close();
            }
        }



        public class Attendance
        {
            public int IdAttendance { get; set; }
            public string Userid { get; set; }
            public DateTime? Checktime { get; set; }
            public int? Checktype { get; set; }
            public string ControllerDoorNo { get; set; }
            public DateTime? AttendDate { get; set; }
            public int? Isvalid { get; set; }
        }

        private void Load()
        {

            try
            {

                AttendInfo oAttendanceInfo = new AttendInfo();
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(Utility.AttendanceXAMPPServer + "AttendanceData.php?max_id=" + oAttendanceInfo.GetMaxIngressNumber());
                    var result = JsonConvert.DeserializeObject<List<Attendance>>(json);

                    int nCount = 0;
                    AttendData oAttendData;
                    foreach (Attendance anAttendance in result)
                    {
                        oAttendData = new AttendData();
                        oAttendData.CardNo = anAttendance.Userid.PadLeft(9, '0');
                        oAttendData.PunchDate = Convert.ToDateTime(anAttendance.Checktime).Date;
                        oAttendData.PunchTime = Convert.ToDateTime(anAttendance.Checktime);
                        oAttendData.StationNo = anAttendance.ControllerDoorNo;
                        oAttendData.IsSystem = true;
                        oAttendData.UserID = 3;
                        oAttendData.IngressFlag = anAttendance.IdAttendance;

                        oAttendData.AddRevised();
                        nCount++;
                    }
                    //Create Data Log
                    AttendanceLog((int)Dictionary.HRAttendanceDataProcessLog.DataLoad);
                    // MessageBox.Show("Data has been Saved Successfully!\nTotal Data:" + nCount.ToString() + "");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void Process()
        {

            int nData;
            AttendInfos oAttendInfos = new AttendInfos();
            int nCompanyID = 0;
            int nDepartmentID = 0;
            int nEmployeeID = 0;
            nData = oAttendInfos.ProcessRevised(dtFromDate.Value.Date, dtToDate.Value.Date, nCompanyID, nDepartmentID, pbDays, pbEmployee, -1, nEmployeeID, false);
            //Create Data Log
            AttendanceLog((int)Dictionary.HRAttendanceDataProcessLog.DataProcess);
            //Send SMS those who were Late/ Absent
            SMSMaker oSMSMaker = new SMSMaker();
            oSMSMaker.HO_SMS("HRAttendance", dtFromDate.Value.Date, dtToDate.Value.Date);
            if (_sArg == "")
            {
                MessageBox.Show("Data Processed Successfully! Affected row(s): " + nData + "", "Data Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnProcessNew_Click(object sender, EventArgs e)
        {

            var date = DateTime.Now;
            Cursor = Cursors.WaitCursor;
            DBController.Instance.OpenNewConnection();
            Utility.UserId = 3;
            Load();
            Process();
            if (date.Hour >= 12 || date.Hour < 13)
            {
                AttendData oPunchHistories = new AttendData();
                string sMechineList = "";
                sMechineList = oPunchHistories.GetNoPunchMechineListforSMS(dtFromDate.Value.Date, dtToDate.Value.Date);
                if (sMechineList != "")
                {
                    SCMShipments _SCMShipments = new SCMShipments();
                    DBController.Instance.OpenNewConnection();
                    _SCMShipments.GETSMSMobileNo(204);
                    string sText = "The below machines have no card punch history" + '\n' + sMechineList;
                    foreach (SCMShipment oItem in _SCMShipments)
                    {
                        SMSMaker _oSMSMaker = new SMSMaker();
                        bool IsSend = _oSMSMaker.IntegrateWithAPI(1, oItem.MobileNo, sText);
                    }
                }
            }

            Cursor = Cursors.Default;
            DBController.Instance.CloseConnection();
            this.Close();
        }


        private void AttendanceLog(int nType)
        {
            HRAttendanceDataProcessLog oADPL = new HRAttendanceDataProcessLog();
            oADPL.LogType = nType;
            if (nType == (int)Dictionary.HRAttendanceDataProcessLog.DataProcess)
            {
                oADPL.FromDate = dtFromDate.Value.Date;
                oADPL.ToDate = dtToDate.Value.Date;
                oADPL.Company = "<All>";
                string isnolyFactorValue = "";
                isnolyFactorValue = "No";
                oADPL.OnlyFactory = isnolyFactorValue;
                oADPL.Department = "<All>";
                oADPL.LogShift = "";
                oADPL.EmployeeId = 0;
                oADPL.CreateUserID = 3;
                oADPL.CreateDate = DateTime.Now;
                oADPL.Add("CJ.AttendanceProcess");
            }

        }

    }
}

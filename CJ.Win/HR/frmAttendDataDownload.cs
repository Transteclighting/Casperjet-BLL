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

using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

using CJ.Class;
using CJ.Class.CSD;
using Microsoft.VisualBasic.FileIO;

namespace CJ.Win
{
    public partial class frmAttendDataDownload : Form
    {
        private Departments _oDepartments;
        private Companys _oCompanys;
        Shifts oShifts;

        public frmAttendDataDownload()
        {
            InitializeComponent();
        }

        private void frmAttendDataDownload_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            //dtFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            LoadCombos();
        }

        private void LoadCombos()
        {

            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cboCompany.Items.Clear();
            cboCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            cboCompany.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.RefreshDepartment();
            cboDepartment.Items.Clear();
            cboDepartment.Items.Add("<All>");
            foreach (Department oDepartment in _oDepartments)
            {
                cboDepartment.Items.Add(oDepartment.DepartmentName);
            }
            cboDepartment.SelectedIndex = 0;
            oShifts = new Shifts();

        }

        private void LoadDataFromTxt()
        {
            AttendData oAttendData;
            string strFileName = "";
            string FilePath = "";
            string FileExtention = "";
            string sLoc;
            string sDay;
            string sMonth;
            string sYear;
            string sHour;
            string sMinute;
            string sCardNo;
            string sTime;
            string sDate;

            if (this.openFileDialogData.CheckFileExists)
            {
                Regex rgTime = new Regex("[0-9][0-9]:[0-9][0-9]");
                Regex rgDate = new Regex("[0-3][0-9]-[0-1][0-9]-[0-9][0-9][0-9][0-9]");
                strFileName = this.openFileDialogData.FileName.Substring(this.openFileDialogData.FileName.LastIndexOf('\\') + 1);
                FileExtention = strFileName.Substring(strFileName.LastIndexOf('.') + 1);
                FilePath = this.txtBrowseData.Text.ToString();
                try
                {
                    //string machine = this.FindMachine();
                    StreamReader sr = new StreamReader(FilePath);
                    string input = null;
                    int nCount = 0;
                    while ((input = sr.ReadLine()) != null)
                    {
                        nCount++;
                    }
                    //Progress Bar Initialization
                    //---------------------------
                    pbLoad.Value = 0;
                    pbLoad.Minimum = 0;
                    pbLoad.Maximum = nCount;
                    pbLoad.Step = 1;
                    //---------------------------
                    sr = new StreamReader(FilePath);
                    input = null;
                    while ((input = sr.ReadLine()) != null)
                    {
                        string sRecord = input.Trim();
                        sLoc = sRecord.Substring(0, 3);
                        sDay = sRecord.Substring(3, 2);
                        sMonth = sRecord.Substring(5, 2);
                        sYear = sRecord.Substring(7, 2);
                        sHour = sRecord.Substring(9, 2);
                        sMinute = sRecord.Substring(11, 2);
                        sCardNo = sRecord.Substring(15, 9);
                        sTime = sHour + ":" + sMinute;
                        sDate = sDay + "/" + sMonth + "/" + sYear;
                        sDate = Convert.ToDateTime(sDate).ToString("dd-MM-yyyy");
                        if (rgTime.IsMatch(sTime) && rgDate.IsMatch(sDate))
                        {
                            oAttendData = new AttendData();
                            oAttendData.CardNo = sCardNo;
                            oAttendData.PunchDate = Convert.ToDateTime(sDate);
                            oAttendData.PunchTime = Convert.ToDateTime(sTime);
                            oAttendData.StationNo = sLoc;
                            oAttendData.IsSystem = true;
                            oAttendData.UserID = Utility.UserId;
                            oAttendData.Add();

                        }
                        pbLoad.PerformStep();
                    }
                    sr.Close();
                    MessageBox.Show(nCount + " Data Loaded Successfully!","Data Load",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail to Load Data. " + ex.ToString());

                }
            }
        }

        private void LoadDataFromTxtTML()
        {
            AttendData oAttendData;
            string strFileName = "";
            string FilePath = "";
            string FileExtention = "";
            string sLoc;
            string sDay;
            string sMonth;
            string sYear;
            string sHour;
            string sMinute;
            string sCardNo;
            string sTime;
            string sDate;
            DateTime dDate;
            
            if (this.openFileDialogData.CheckFileExists)
            {
                Regex rgTime = new Regex("[0-9][0-9]:[0-9][0-9]");
                Regex rgDate = new Regex("[0-3][0-9]-[0-1][0-9]-[0-9][0-9][0-9][0-9]");
                strFileName = this.openFileDialogData.FileName.Substring(this.openFileDialogData.FileName.LastIndexOf('\\') + 1);
                FileExtention = strFileName.Substring(strFileName.LastIndexOf('.') + 1);
                FilePath = this.txtBrowseData.Text.ToString();
                try
                {
                    //string machine = this.FindMachine();
                    StreamReader sr = new StreamReader(FilePath);
                    string input = null;
                    int nCount = 0;
                    while ((input = sr.ReadLine()) != null)
                    {
                        nCount++;
                    }
                    //Progress Bar Initialization
                    //---------------------------
                    pbLoad.Value = 0;
                    pbLoad.Minimum = 0;
                    pbLoad.Maximum = nCount;
                    pbLoad.Step = 1;
                    //---------------------------
                    sr = new StreamReader(FilePath);
                    input = null;
                    while ((input = sr.ReadLine()) != null)
                    {
                        string sRecord = input.Trim();

                        string[] sSplit = sRecord.Split(new Char[] {','});

                        //foreach (string s in sSplit)
                        //{

                        //    if (s.Trim() != "")
                        //        Console.WriteLine(s);
                        //}

                        //sRecord.Split(

                        sLoc = "007";
                        sDay = sSplit[5].Substring(8, 2);
                        sMonth = sSplit[5].Substring(5, 2);
                        sYear = sSplit[5].Substring(0, 4);
                        //sHour = sRecord.Substring(9, 2);
                        //sMinute = sRecord.Substring(11, 2);
                        sCardNo = sSplit[1].ToString().PadLeft(9,'0');
                        sTime = sSplit[7];//sHour + ":" + sMinute;
                        dDate = new DateTime(Convert.ToInt32(sYear), Convert.ToInt32(sMonth), Convert.ToInt32(sDay));
                        sDate = dDate.ToString("dd-MM-yyyy");
                        if (rgTime.IsMatch(sTime) && rgDate.IsMatch(sDate) && sSplit[1].Length>0)
                        {
                            oAttendData = new AttendData();
                            oAttendData.CardNo = sCardNo;
                            oAttendData.PunchDate = dDate;
                            oAttendData.PunchTime = Convert.ToDateTime(sTime);
                            oAttendData.StationNo = sLoc;
                            oAttendData.IsSystem = true;
                            oAttendData.UserID = Utility.UserId;
                            oAttendData.Add();

                        }
                        pbLoad.PerformStep();
                    }
                    sr.Close();
                    MessageBox.Show(nCount + " Data Loaded Successfully!", "Data Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail to Load Data. " + ex.ToString());

                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialogData.FileName = "";
            this.openFileDialogData.Multiselect = false;
            this.openFileDialogData.Filter = "";
            this.openFileDialogData.Filter = "Text File(*.txt;)|*.txt;| File(*.TXT;)|*.TXT;|CSV File(*.csv;)|*.csv;|All Files(*.*;)|*.*";
            if (this.openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                this.txtBrowseData.Text = this.openFileDialogData.FileName.ToString();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDataFromTxt();
            
        }

        private void btnLoadTML_Click(object sender, EventArgs e)
        {
            //LoadDataFromTxtTML();
            GetDataTableFromCSVFile(this.txtBrowseData.Text.ToString());
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            bool b;
            AttendInfos oAttendInfos = new AttendInfos();
            int nCompanyID = 0;
            if (cboCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;

            int nDepartmentID = 0;
            if (cboDepartment.SelectedIndex > 0) nDepartmentID = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;

            if (oShifts.Count > 0)
            {
                b = oAttendInfos.Process(dtFromDate.Value.Date, dtToDate.Value.Date, nCompanyID, nDepartmentID, pbDays, pbEmployee, oShifts[cmbShift.SelectedIndex].ShiftID);
            }
            else
            {
                b = oAttendInfos.Process(dtFromDate.Value.Date, dtToDate.Value.Date, nCompanyID, nDepartmentID, pbDays, pbEmployee, -1);
            }
            MessageBox.Show("Data Processed Successfully!", "Data Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnProcessNew_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            SMSMaker oSMSMaker;
            int nData;
            AttendInfos oAttendInfos = new AttendInfos();
            
            int nCompanyID = 0;
            if (cboCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;

            int nDepartmentID = 0;
            if (cboDepartment.SelectedIndex > 0) nDepartmentID = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;
            int nEmployeeID = 0;
            if (ctlEmployee1.txtDescription.Text != "")
            {
                nEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
            }
            if (oShifts.Count > 0)
            {
                nData = oAttendInfos.ProcessRevised(dtFromDate.Value.Date, dtToDate.Value.Date, nCompanyID, nDepartmentID, pbDays, pbEmployee, oShifts[cmbShift.SelectedIndex].ShiftID, nEmployeeID, chkOnlyFactory.Checked);
            }
            else 
            {
                nData = oAttendInfos.ProcessRevised(dtFromDate.Value.Date, dtToDate.Value.Date, nCompanyID, nDepartmentID, pbDays, pbEmployee, -1, nEmployeeID, chkOnlyFactory.Checked);
            }
            //Create Data Log
            AttendanceLog((int)Dictionary.HRAttendanceDataProcessLog.DataProcess);
            
            //Send SMS those who were Late/Absent
            oSMSMaker = new SMSMaker();
            oSMSMaker.HO_SMS("HRAttendance", dtFromDate.Value.Date, dtToDate.Value.Date);
            
            //Birthday SMS
            oSMSMaker = new SMSMaker();
            oSMSMaker.HO_SMS("Birthday", dtFromDate.Value.Date, dtToDate.Value.Date);
            

            this.Cursor = Cursors.Default;
            MessageBox.Show("Data Processed Successfully! Affected row(s): "+ nData + "", "Data Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AttendanceLog(int nType)
        {
            HRAttendanceDataProcessLog oADPL = new HRAttendanceDataProcessLog();
            oADPL.LogType = nType;

            if (nType == (int)Dictionary.HRAttendanceDataProcessLog.DataProcess)
            {
                oADPL.FromDate = dtFromDate.Value.Date;
                oADPL.ToDate = dtToDate.Value.Date;
                oADPL.Company = cboCompany.Text;
                string isnolyFactorValue = "";
                if (chkOnlyFactory.Checked)
                {
                    isnolyFactorValue = "Yes";
                }
                else
                {
                    isnolyFactorValue = "No";
                }
                oADPL.OnlyFactory = isnolyFactorValue;
                oADPL.Department = cboDepartment.Text;
                oADPL.LogShift = cmbShift.Text;

                if (ctlEmployee1.SelectedEmployee != null)
                {
                    oADPL.EmployeeId = ctlEmployee1.SelectedEmployee.EmployeeID;
                }
                else
                {
                    oADPL.EmployeeId = 0;
                }

                oADPL.CreateUserID = Utility.UserId;
                oADPL.CreateDate = DateTime.Now;
                oADPL.Add("CJ.Win");
            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int nCompanyID = 0;
            if (cboCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;

            int nDepartmentID = 0;
            if (cboDepartment.SelectedIndex > 0) nDepartmentID = _oDepartments[cboDepartment.SelectedIndex - 1].DepartmentID;

            AttendInfos oAttendInfos = new AttendInfos();
            oAttendInfos.DeleteAll(dtFromDate.Value.Date, dtToDate.Value.Date, nCompanyID, nDepartmentID);
        }

        private void ckbShift_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShift.Checked == true)
            {
                oShifts = new Shifts();
                cmbShift.Enabled = true;
                cmbShift.Items.Clear();
                int nCompanyID = 0;
                if (cboCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cboCompany.SelectedIndex - 1].CompanyID;
                oShifts.GetShift(nCompanyID);
                foreach (Shift oShift in oShifts)
                {
                    cmbShift.Items.Add(oShift.ShiftName);
                }
                cmbShift.SelectedIndex = oShifts.Count - 1;
            }
            else
            {
                oShifts = new Shifts();
                cmbShift.Items.Clear();
                cmbShift.Enabled = false;
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
        private void btnLoadBLL_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                int maxId = 0;

                DBController.Instance.OpenNewConnection();

                AttendInfo oAttendanceInfo = new AttendInfo();
                //oAttendanceInfo.GetMaxIngressNumber();

                using (var webClient = new System.Net.WebClient())
                {

                    //string sAttendanceXAMPPServer = "";
                    //sAttendanceXAMPPServer = Utility.AttendanceXAMPPServer;
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
                        oAttendData.UserID = Utility.UserId;
                        oAttendData.IngressFlag = anAttendance.IdAttendance;

                        oAttendData.AddRevised();
                        nCount++;
                    }
                    //Create Data Log
                    AttendanceLog((int)Dictionary.HRAttendanceDataProcessLog.DataLoad);
                    MessageBox.Show("Data has been Saved Successfully!\nTotal Data:"+ nCount.ToString() + "");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor = Cursors.Default;
        }

        private static DataTable GetDataTableFromCSVFile(string csvfilePath)
        {
            DataTable csvData = new DataTable();
            using (TextFieldParser csvReader = new TextFieldParser(csvfilePath))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;

                //Read columns from CSV file, remove this line if columns not exits  
                string[] colFields = csvReader.ReadFields();

                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }

                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }
            int nCount = 0;
            foreach (DataRow oRow in csvData.Rows)
            {
                //string sTest = oRow[4].ToString();
                AttendData oAttendData = new AttendData();
                //int nID = Convert.ToInt32(oRow[4].ToString()).ToString("000000000");
                oAttendData.CardNo = Convert.ToInt32(oRow[1].ToString()).ToString("000000000");
                oAttendData.PunchDate = Convert.ToDateTime(oRow[0].ToString());
                oAttendData.PunchTime = Convert.ToDateTime(oRow[0].ToString());
                oAttendData.StationNo = "001";
                oAttendData.IsSystem = true;
                oAttendData.AddCSVData();
                nCount++;
            }
            nCount = nCount;
            return csvData;
        }

    }
}
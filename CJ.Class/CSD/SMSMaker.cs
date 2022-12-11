// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 11, 2014
// Time :  12:00 PM
// Description: Class for SMS Maker
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using CJ.Class.HR;

namespace CJ.Class.CSD
{
    public class SMSMaker
    {
        private int _nSMSMessageID;
        private DateTime _dRequestDate;
        private string _sSMSText;
        private int _nSMSType;
        private string _sSingleMobileNo;
        private Object _dSendDate;
        private int _nStatus;
        private string _sSubmittedBy;
        private Object _sUserGroupName;
        private int _nSuccessCount;
        private int _nfailCount;
        private int _nEmployeeID;
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private string _sContactNo;
        private object _Late;
        private object _TimeIn;
        private DateTime _dPunchDate;


        /// <summary>
        /// Get set property for SMSMessageID
        /// </summary>
        public int SMSMessageID
        {
            get { return _nSMSMessageID; }
            set { _nSMSMessageID = value; }
        }
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }
        public object Late
        {
            get { return _Late; }
            set { _Late = value; }
        }
        public object TimeIn
        {
            get { return _TimeIn; }
            set { _TimeIn = value; }
        }
        /// <summary>
        /// Get set property for RequestDate
        /// </summary>
        public DateTime RequestDate
        {
            get { return _dRequestDate; }
            set { _dRequestDate = value; }
        }
        /// <summary>
        /// Get set property for SMSTextT
        /// </summary>
        public string SMSText
        {
            get { return _sSMSText; }
            set { _sSMSText = value; }
        }
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }
        public DateTime PunchDate
        {
            get { return _dPunchDate; }
            set { _dPunchDate = value; }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value; }
        }
        /// <summary>
        /// Get set property for SMSTypeT
        /// </summary>
        public int SMSType
        {
            get { return _nSMSType; }
            set { _nSMSType = value; }
        }
        /// <summary>
        /// Get set property for SingleMobileNo
        /// </summary>
        public string SingleMobileNo
        {
            get { return _sSingleMobileNo; }
            set { _sSingleMobileNo = value; }
        }
        /// <summary>
        /// Get set property for SendDateT
        /// </summary>
        public Object SendDate
        {
            get { return _dSendDate; }
            set { _dSendDate = value; }
        }
        /// <summary>
        /// Get set property for StatusT
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        /// <summary>
        /// Get set property for SubmittedBy
        /// </summary>
        public string SubmittedBy
        {
            get { return _sSubmittedBy; }
            set { _sSubmittedBy = value; }
        }
        /// <summary>
        /// Get set property for UserGroupName
        /// </summary>
        public Object UserGroupName
        {
            get { return _sUserGroupName; }
            set { _sUserGroupName = value; }
        }
        /// <summary>
        /// Get set property for SuccessCount
        /// </summary>
        public int SuccessCount
        {
            get { return _nSuccessCount; }
            set { _nSuccessCount = value; }
        }
        /// <summary>
        /// Get set property for failCount
        /// </summary>
        public int failCount
        {
            get { return _nfailCount; }
            set { _nfailCount = value; }
        }


        private int _nSMSMapID;
        private int _nJobID;
        private int _nTypeOfSMS;
        private string _sHotline;
        private string _sServiceTime;

        public int SMSMapID
        {
            get { return _nSMSMapID; }
            set { _nSMSMapID = value; }
        }
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }
        public int TypeOfSMS
        {
            get { return _nTypeOfSMS; }
            set { _nTypeOfSMS = value; }
        }
        public string Hotline
        {
            get { return _sHotline; }
            set { _sHotline = value; }
        }
        public string ServiceTime
        {
            get { return _sServiceTime; }
            set { _sServiceTime = value; }
        }

        private string _sJobNo;
        private string _sGSPNJobNo;
        private DateTime _dCreateDate;
        private object _dLastFeedBackDate;
        private object _dVisitingDate;
        private object _dVisitingTimeFrom;
        private object _dVisitingTimeTo;
        private string _sModel;
        private string _sGroupName;
        private object _nRefChannelID;
        private object _nRefSalesPointID;
        private string _sCustomerName;
        private string _sCustContactNo;
        private string _sCustomerAddress;
        private object _nAssignTo;
        private string _sServiceType;
        private string _sServiceTypeFull;
        private string _sJobType;
        private string _sTechMobNo;
        private string _sSupMobNo;
        private string _sTPMGRMobile;
        private string _sTechcianName;
        private string _sTPName;
        private string _sSourceMobileNo;
        private string _sFault;
        private string _sEstSpAmount;
        private string _sEstScAmount;
        
        public void ProductReceive(int nJobID, string sJobNo, string sContactNo, DateTime dCreateDate, DateTime dFeedbackDate)
        {
            _nTypeOfSMS = (int)Dictionary.TypeOfJobSMS.WalkIn_Receive;
            string sHelpline = GetHelpline(_nTypeOfSMS);
            _sSMSText = "TRANSCOM SERVICE: Dear Sir, Received CTV on " + dCreateDate.Date.ToString("dd-MMM-yyyy") + ", Job#" + sJobNo + ", Expected Feedback Date is " + dFeedbackDate.Date.ToString("dd-MMM-yyyy") + ". HELPLINE: " + sHelpline + "; from 9:00am to 9:00pm";
            _sSingleMobileNo = sContactNo;
            AddToServer();
            _nJobID = nJobID;
            AddSMSMapping();
        }
        
        public void EDDExtention(int nJobID, string sJobNo, string sContactNo, DateTime dFeedbackDate)
        {
            _nTypeOfSMS = (int)Dictionary.TypeOfJobSMS.EDD_Extention;
            string sHelpline = GetHelpline(_nTypeOfSMS);
            _sSMSText = "TRANSCOM SERVICE: Dear Sir, Delivery Date for Job#" + sJobNo + " is extended upto " + dFeedbackDate.Date.ToString("dd-MMM-yyyy") + ". Sorry for inconvenient.  HELPLINE: " + sHelpline + "; from 9:00am to 9:00pm";
            _sSingleMobileNo = sContactNo;
            AddToServer();
            _nJobID = nJobID;
            AddSMSMapping();
        }
        public void AttendanceDataLateInfo()
        {
            string _dDate ="";           
            Employees oEmployees = new Employees();            
            oEmployees.GetHRLateAttendanceEmployeewise();
            foreach (Employee oEmployee in oEmployees)
            {
                _nEmployeeID = oEmployee.EmployeeID;
                _sContactNo = oEmployee.Mobile;
                _sEmployeeName = oEmployee.EmployeeName;
                _Late = oEmployee.Late;
                _TimeIn = oEmployee.TimeIn;
                _dDate = oEmployee.PunchDate.ToString("dd-MMM-yyyy");
                bool _bFlag = oEmployees.CheckAttendData(_nEmployeeID, _dDate);
                if (!_bFlag)
                {
                    _sSMSText = "Dear " + _sEmployeeName + ", you have come to office at " + _TimeIn + " AM. dated on " + _dDate + " you are Late by " + _Late + " - HR ";
                    IntegrateWithAPI(_nEmployeeID, _sContactNo, _sSMSText);
                    AttendData oAttendData = new AttendData();
                    oAttendData.UpdateAttendData(_nEmployeeID, _dDate);
                }
                else
                {
                    _bFlag = false;
                }                
            }          
        }

        private void AddSMSMapping()
        {
            int nSMSMapID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SMSMapID]) FROM t_CSDSMSMapping";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nSMSMapID = 1;
                }
                else
                {
                    nSMSMapID = Convert.ToInt32(maxID) + 1;
                }
                _nSMSMapID = nSMSMapID;

                sSql = "INSERT INTO t_CSDSMSMapping(SMSMapID,SMSMessageID,JobID,TypeOfSMS) VALUES(?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SMSMapID", _nSMSMapID);
                cmd.Parameters.AddWithValue("SMSMessageID", _nSMSMessageID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("TypeOfSMS", _nTypeOfSMS);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        private void AddToServer()
        {
            int nMaxSMSMessageID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SMSMessageID]) FROM t_SMSMessage";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSMSMessageID = 1;
                }
                else
                {
                    nMaxSMSMessageID = Convert.ToInt32(maxID) + 1;
                }
                _nSMSMessageID = nMaxSMSMessageID;

                sSql = "INSERT INTO t_SMSMessage(SMSMessageID,RequestDate,SMSText,"
                    + " SMSType,SingleMobileNo,SendDate,Status,SubmittedBy,"
                    + " UserGroupName,SuccessCount,failCount"
                    + " ) VALUES(?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SMSMessageID", _nSMSMessageID);
                cmd.Parameters.AddWithValue("RequestDate", DateTime.Now);
                cmd.Parameters.AddWithValue("SMSText", _sSMSText);
                cmd.Parameters.AddWithValue("SMSType", 1);
                cmd.Parameters.AddWithValue("SingleMobileNo", _sSingleMobileNo);
                cmd.Parameters.AddWithValue("SendDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("SubmittedBy", Utility.UserId);
                cmd.Parameters.AddWithValue("UserGroupName", "CSDJobSMS");
                cmd.Parameters.AddWithValue("SuccessCount", 0);
                cmd.Parameters.AddWithValue("failCount", 0);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public string GetHelpline(int nTypeOfJobSMS)
        {
            string sHelpline = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDSMSHelpline where TypeOfJobSMS = " + nTypeOfJobSMS + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sHelpline = reader["Helpline"].ToString();

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sHelpline;   
        }
        //public string GetHRLateAttendanceEmployeewise()
        //{
        //    string sMobileNo = "";

        //    DateTime _dDate = DateTime.Now;
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    string sSql = "Select a.EmployeeID,EmployeeCode,EmployeeName, isnull(MobileNumber,a.MobileNo)as ContactNo,FORMAT(TimeIn,'hh:mm')TimeIn, " +
        //                    "CONVERT(VARCHAR(10), DATEPART(HOUR, Late)) + ' Hour' + CONVERT(VARCHAR(10), DATEPART(MINUTE, Late)) + ' Minutes' as Late " +
        //                    "from(Select A.*, Late, PunchDate,TimeIn from t_Employee a, t_HRAttendInfo b where a.EmployeeID = b.EmployeeID and b.Status = 2)a " +
        //                    "left outer join " +
        //                    "(Select EmployeeID, MobileNumber from t_MobileNumberAssign a, t_MobileNumber b " +
        //                    "where a.MobileID= b.ID and AssignFor = 1) b on a.EmployeeID = b.EmployeeID " +
        //                    "where PunchDate = '16-Jun-2019' and a.EmployeeID = '85979'";

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            sMobileNo = reader["ContactNo"].ToString();

        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return sMobileNo;
        //}

        public string GetServiceTime(int nTypeOfJobSMS)
        {
            string sServiceTime = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDSMSHelpline where TypeOfJobSMS = " + nTypeOfJobSMS + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sServiceTime = reader["ServiceTime"].ToString();

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sServiceTime;
        }

        public bool CustomerSMS(int nSMSID, int nJobID)
        {
            bool _bIsSend = false;
            string sText = "";
            string sHelpline = "";
            string sServiceTime = "";
            string sContactNumber = "";
            string sMobileNo = "";
            bool bIsAutoSend = false;
            int nServerType = 0;
            string sEstimateAmount = "";
            //, string _sPG, string _sJobNo, string _sScheduleDate, string _sScheduleTime
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ID, Helpline, ServiceTime, Text, ContactNumber, IsAutoSend,ServerType from dbo.t_CSDSMSModel Where ID = " + nSMSID + " and IsActive = 1";

            GetData(nJobID);
            //.ToString("hh:mm tt")
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    sText = reader["Text"].ToString();
                    sHelpline = reader["Helpline"].ToString();
                    sServiceTime = reader["ServiceTime"].ToString();
                    sContactNumber = reader["ContactNumber"].ToString();
                    if (Convert.ToInt32(reader["IsAutoSend"]) == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        bIsAutoSend = true;
                    }
                    nServerType = Convert.ToInt32(reader["ServerType"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            string sLastFeedBackDate = "";
            try
            {
                DateTime dLastFeedBackDate = Convert.ToDateTime(_dLastFeedBackDate);
                sLastFeedBackDate = dLastFeedBackDate.ToString("dd-MMM-yyyy");
            }
            catch
            {
            }

            string sVisitingDate = "";
            try
            {
                DateTime dVisitingDate = Convert.ToDateTime(_dVisitingDate);
                sVisitingDate = dVisitingDate.ToString("dd-MMM-yyyy");
            }
            catch
            {
            }
            string sVisitingTimeFrom = "";
            try
            {
                DateTime dVisitingTimeFrom = Convert.ToDateTime(_dVisitingTimeFrom);
                sVisitingTimeFrom = dVisitingTimeFrom.ToString("hh:mm tt");
            }
            catch
            {
            }
            string sVisitingTimeTo = "";
            try
            {
                DateTime dVisitingTimeTo = Convert.ToDateTime(_dVisitingTimeTo);
                sVisitingTimeTo = dVisitingTimeTo.ToString("hh:mm tt");
            }
            catch
            {
            }
            double _sum = Convert.ToDouble(_sEstScAmount) + Convert.ToDouble(_sEstSpAmount);
            sEstimateAmount = "Tk. " + _sum.ToString() + " ( Service Charge: " + _sEstScAmount + " & Spare Parts: " + _sEstSpAmount + ")";

            string[] stringArray = { _sGroupName, _sJobNo, _sGSPNJobNo, sLastFeedBackDate, sVisitingDate, sVisitingTimeFrom, sVisitingTimeTo, sHelpline, sServiceTime, _dCreateDate.ToString("dd-MMM-yyyy"), _sModel, _sCustomerName, _sCustContactNo, _sCustomerAddress, _sServiceType, _sServiceTypeFull, _sJobType, _sTechMobNo, _sSupMobNo, _sTPMGRMobile, _sTechcianName, _sTPName, _sSourceMobileNo, _sFault, sEstimateAmount };

            string[] sParameter = { 
                "<sGroupName>", 
                "<sJobNo>", 
                "<sGSPNJobNo>", 
                "<sLastFeedbackDate>",
                "<sScheduleDate>", 
                "<sScheduleTimeFrom>", 
                "<sScheduleTimeTo>", 
                "<sHelpline>", 
                "<sServiceTime>",
                "<sCreateDate>",
                "<sModel>",
                "<sCustomerName>",
                "<sCustContactNo>",
                "<sCustomerAddress>",
                "<sServiceType>",
                "<sServiceTypeFull>",
                "<sJobType>",
                "<sTechMobNo>",
                "<sSupMobNo>",
                "<sTPMGRMobile>",
                "<sTechcianName>",
                "<sTPName>",
                "<sSourceMobileNo>",
                "<sFault>",
                "<sEstimateString>"
            };

            int nCount = 0;
            foreach (string s in stringArray)
            {
                string sParam = sParameter[nCount];
                sText = sText.Replace(sParam, s);
                nCount++;
            }

            string[] sContactArray = sContactNumber.Split(',');
            foreach (string c in sContactArray)
            {
                nCount = 0;
                foreach (string p in sParameter)
                {
                    if (c == p)
                    {
                        sMobileNo = stringArray[nCount];
                        _bIsSend = Insert(nSMSID, nJobID, sText, sMobileNo, bIsAutoSend, nServerType);
                        break;
                    }
                    nCount++;
                }
            }

            return _bIsSend;
        }

        public bool HO_SMS(string sType, DateTime dtFromDate, DateTime dtToDate)
        {
            bool _bIsSend = false;
            DSAttendance oDSAttendance = new DSAttendance();
            oDSAttendance = GetAttendanceSMSModel(oDSAttendance);

            //Date must be start from 01-Mar-2021
            DateTime _dProcessStartFrom = Convert.ToDateTime("01-Mar-2021");
            //DateTime _dSMSStartFrom = Convert.ToDateTime("04-Mar-2021");
            DateTime _dSMSStartFrom = DateTime.Now.Date.AddDays(-3);
            AttendDatas _oAttendDatas;
            AttendDatas _oAttendMTDYTD = new AttendDatas();
            int[] MTD_YTD = new int[2];
            int nSMSType = -1;
            

            if (sType == "HRAttendance")
            {
                _oAttendDatas = new AttendDatas();
                _oAttendDatas.GetEligibleEmployeeForAttendanceSMS(_dSMSStartFrom);

                foreach (AttendData oAttendData in _oAttendDatas)
                {
                    if (oAttendData.Status == (int)Dictionary.HRAttendanceStatus.Absent)
                    {
                        nSMSType = (int)Dictionary.SMSModel.Absent;
                    }
                    else if (oAttendData.Status == (int)Dictionary.HRAttendanceStatus.Late)
                    {
                        nSMSType = (int)Dictionary.SMSModel.Late;
                    }

                    DataRow[] oDRSMSModel = oDSAttendance.AttendanceSMSModel.Select(" Type= '" + nSMSType + "'");
                    if (oDRSMSModel.Length > 0)
                    {
                        string _ModelText = oDRSMSModel[0]["ModelText"].ToString();

                        if (oAttendData.Status == (int)Dictionary.HRAttendanceStatus.Absent)
                        {
                            if (oAttendData.PunchDate.Date != DateTime.Now.Date)
                            {
                                MTD_YTD = _oAttendMTDYTD.Get_MTD_YTD_Late_Absent(_dProcessStartFrom, oAttendData.PunchDate, oAttendData.Status, oAttendData.EmployeeId);
                                SMSGenerateforAttendance(_ModelText, oAttendData.PunchDate.ToString("dd-MMM-yyyy"), oAttendData.OnlyTimeIn, MTD_YTD[0].ToString(), MTD_YTD[1].ToString(), oAttendData.EmployeeId, oAttendData.MobileNo);
                            }
                        }
                        else if (oAttendData.Status == (int)Dictionary.HRAttendanceStatus.Late)
                        {
                            MTD_YTD = _oAttendMTDYTD.Get_MTD_YTD_Late_Absent(_dProcessStartFrom, oAttendData.PunchDate, oAttendData.Status, oAttendData.EmployeeId);
                            SMSGenerateforAttendance(_ModelText, oAttendData.PunchDate.ToString("dd-MMM-yyyy"), oAttendData.OnlyTimeIn, MTD_YTD[0].ToString(), MTD_YTD[1].ToString(), oAttendData.EmployeeId, oAttendData.MobileNo);
                        }
                    }
                }
            }
            else if (sType == "Birthday")
            {
                _oAttendDatas = new AttendDatas();
               

                DateTime _dFromDate = dtFromDate.Date.AddDays(-1);
                DateTime _dToDate = dtToDate.Date;
                int nDay = (_dToDate - _dFromDate).Days;
                string _sDate = "";
                DateTime _ProcessStartDate = Convert.ToDateTime("01-Dec-2021");
                DateTime _date = _dFromDate;
                string _ModelText = "";
                string _ModelTextGrp = "";
                SMSMessages oSMSMessage;
                
                if (nDay > 0)
                {
                    //if (_dFromDate >= _ProcessStartDate)
                    {
                        for (int i = 0; i < nDay; i++)
                        {
                            DateTime _xdate = _date.AddDays(1);

                            if(_xdate >= _ProcessStartDate)
                            {
                                _oAttendDatas.GetEligibleEmployeeForBirthdaySMS(_ProcessStartDate, _xdate);
                                nSMSType = (int)Dictionary.SMSModel.Birthday;
                                DataRow[] oDRSMSModel = oDSAttendance.AttendanceSMSModel.Select(" Type= '" + nSMSType + "'");

                                if (oDRSMSModel.Length > 0)
                                {
                                    _ModelText = oDRSMSModel[0]["ModelText"].ToString();
                                    foreach (AttendData oAttendData in _oAttendDatas)
                                    {
                                        //Individual
                                        SMSGenerateforBirthday(_ModelText, _xdate.ToString("dd-MMM-yyyy"), oAttendData.EmployeeName, oAttendData.EmployeeId, oAttendData.MobileNo, _xdate.Year, true);
                                        //Group SMS
                                        nSMSType = (int)Dictionary.SMSModel.BirthdayGroup;
                                        DataRow[] oDRSMSModelGroup = oDSAttendance.AttendanceSMSModel.Select(" Type= '" + nSMSType + "'");

                                        if (oAttendData.Company == "TEL")
                                        {
                                            _ModelTextGrp = oDRSMSModelGroup[0]["ModelText"].ToString();
                                            //Loop Mobile Number Group
                                            //205 BirthdayGroup_TEL
                                            oSMSMessage = new SMSMessages();
                                            oSMSMessage.GetMobileNoByGroup(205);
                                            foreach (SMSMessage oSMS in oSMSMessage)
                                            {
                                                SMSGenerateforBirthday(_ModelTextGrp, _xdate.ToString("dd-MMM-yyyy"), oAttendData.EmployeeName, oAttendData.EmployeeId, oSMS.SingleMobileNo, _xdate.Year, false);
                                            }

                                        }
                                        else if (oAttendData.Company == "BLL")
                                        {
                                            _ModelTextGrp = oDRSMSModelGroup[0]["ModelText"].ToString();
                                            //Loop Mobile Number Group
                                            //206	BirthdayGroup_BLL
                                            oSMSMessage = new SMSMessages();
                                            oSMSMessage.GetMobileNoByGroup(206);
                                            foreach (SMSMessage oSMS in oSMSMessage)
                                            {
                                                SMSGenerateforBirthday(_ModelTextGrp, _xdate.ToString("dd-MMM-yyyy"), oAttendData.EmployeeName, oAttendData.EmployeeId, oSMS.SingleMobileNo, _xdate.Year, false);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }

            return _bIsSend;
        }

        private DSAttendance GetAttendanceSMSModel(DSAttendance oDSAttendance)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select Id, Type, ModelText, IsActive from dbo.t_SMSModel Where IsActive = " + (int)Dictionary.YesOrNoStatus.YES + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSAttendance.AttendanceSMSModelRow oAttendanceSMSModelRow = oDSAttendance.AttendanceSMSModel.NewAttendanceSMSModelRow();

                    oAttendanceSMSModelRow.ModelText = reader["ModelText"].ToString();
                    oAttendanceSMSModelRow.Id = (int)reader["Id"];
                    oAttendanceSMSModelRow.Type = (int)reader["Type"];
                    oAttendanceSMSModelRow.IsActive = (int)reader["IsActive"];

                    oDSAttendance.AttendanceSMSModel.AddAttendanceSMSModelRow(oAttendanceSMSModelRow);
                    oDSAttendance.AcceptChanges();                 
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSAttendance;
        }
        private bool SMSGenerateforAttendance(string _ModelText, string _sDate, string _sTime, string _sMTDDays, string _sYTDDays, int nEmployeeId, string sMobileNo)
        {

            if (Convert.ToInt32(_sMTDDays) > 1)
            {
                _sMTDDays = _sMTDDays + " days";
            }
            else
            {
                _sMTDDays = _sMTDDays + " day";
            }
            if (Convert.ToInt32(_sYTDDays) > 1)
            {
                _sYTDDays = _sYTDDays + " days";
            }
            else
            {
                _sYTDDays = _sYTDDays + " day";
            }

            string[] stringArray = { _sDate, _sTime, _sMTDDays, _sYTDDays };

            string[] sParameter = {
                "<sDate>",
                "<sTime>",
                "<sMTDDays>",
                "<sYTDDays>"
            };

            int nCount = 0;
            foreach (string s in stringArray)
            {
                string sParam = sParameter[nCount];
                _ModelText = _ModelText.Replace(sParam, s);
                nCount++;
            }

            if(IntegrateWithAPI(nEmployeeId, sMobileNo, _ModelText))
            {
                //Insert SMS
                SMSMessage oSMSMessage = new SMSMessage();
                oSMSMessage.RequestDate = DateTime.Now;
                oSMSMessage.SMSText = _ModelText;
                oSMSMessage.SMSType = 1;
                oSMSMessage.SingleMobileNo = sMobileNo;
                oSMSMessage.SendDate = oSMSMessage.RequestDate;
                oSMSMessage.Status = 1;
                oSMSMessage.SubmittedBy = Utility.UserId.ToString();
                oSMSMessage.UserGroupName = "HR_Attendance";
                oSMSMessage.SuccessCount = 1;
                oSMSMessage.FailCount = 0;
                oSMSMessage.EmployeeId = nEmployeeId;

                oSMSMessage.Add();

                //Insert attendance
                HRAttendanceSMS oHRAttendanceSMS = new HRAttendanceSMS();
                oHRAttendanceSMS.EmployeeId = nEmployeeId;
                oHRAttendanceSMS.TDate = Convert.ToDateTime(_sDate);
                oHRAttendanceSMS.SMSId = oSMSMessage.SMSMessageID;
                oHRAttendanceSMS.CreateDate = DateTime.Now;
                oHRAttendanceSMS.CreateUserId = Utility.UserId;
                oHRAttendanceSMS.Add();
              
            }

            return true;
        }
        private bool SMSGenerateforBirthday(string _ModelText, string _sDate, string _sName, int nEmployeeId, string sMobileNo, int nYear, bool _bIndividual)
        {

            
            string[] stringArray = { _sDate, _sName};

            string[] sParameter = {
                "<sDate>",
                "<sName>"
            };

            int nCount = 0;
            foreach (string s in stringArray)
            {
                string sParam = sParameter[nCount];
                _ModelText = _ModelText.Replace(sParam, s);
                nCount++;
            }

            if (IntegrateWithAPI(nEmployeeId, sMobileNo, _ModelText))
            {
                //Insert SMS
                SMSMessage oSMSMessage = new SMSMessage();
                oSMSMessage.RequestDate = DateTime.Now;
                oSMSMessage.SMSText = _ModelText;
                oSMSMessage.SMSType = 1;
                oSMSMessage.SingleMobileNo = sMobileNo;
                oSMSMessage.SendDate = oSMSMessage.RequestDate;
                oSMSMessage.Status = 1;
                oSMSMessage.SubmittedBy = Utility.UserId.ToString();
                oSMSMessage.UserGroupName = "Birthday";
                oSMSMessage.SuccessCount = 1;
                oSMSMessage.FailCount = 0;
                oSMSMessage.EmployeeId = nEmployeeId;

                oSMSMessage.Add();

                //Insert Birthday SMS
                if (_bIndividual)
                {
                    HRAttendanceSMS oHRAttendanceSMS = new HRAttendanceSMS();
                    oHRAttendanceSMS.EmployeeId = nEmployeeId;
                    oHRAttendanceSMS.TYear = nYear;
                    oHRAttendanceSMS.SMSId = oSMSMessage.SMSMessageID;
                    //oHRAttendanceSMS.SMSId = 1;
                    oHRAttendanceSMS.CreateDate = DateTime.Now;
                    oHRAttendanceSMS.CreateUserId = Utility.UserId;
                    oHRAttendanceSMS.AddBirthdaySMS();
                }
            }

            return true;
        }
        private bool Insert(int nSMSModelID, int nJobID, string sSMSText, string sMobileNo, bool IsAutoSend, int nServerType)
        {
            bool _bIsSend = false;
            CSDSMSHistory oCSDSMSHistory = new CSDSMSHistory();

            oCSDSMSHistory.SMSModelID = nSMSModelID;
            oCSDSMSHistory.JobID = nJobID;
            oCSDSMSHistory.SMSText = sSMSText;
            oCSDSMSHistory.MobileNo = sMobileNo;
            oCSDSMSHistory.IsAutoCreate = (int)Dictionary.YesOrNoStatus.YES;
            oCSDSMSHistory.CreateUserID = Utility.UserId;
            oCSDSMSHistory.CreateDate = DateTime.Now;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oCSDSMSHistory.Add();
                if (IsAutoSend)
                {
                    //Check 310 char Max two SMS
                    if (sSMSText.Length <= 310)
                    {
                        if (sMobileNo.Length == 11)
                        {
                            if (nServerType == (int)Dictionary.SMSServerType.OwnServer)
                            {
                                CSDSMS oCSDSMS = new CSDSMS();
                                oCSDSMS.SMSTextT = sSMSText;
                                oCSDSMS.SingleMobileNo = sMobileNo;
                                oCSDSMS.SubmittedBy = Utility.Username;
                                oCSDSMS.AddToServer();

                                oCSDSMSHistory.StatusUpdate((int)Dictionary.CSDSMSStatus.Sent);
                                oCSDSMSHistory.SendUserID = Utility.UserId;
                                oCSDSMSHistory.SendDate = DateTime.Now;
                                oCSDSMSHistory.SendStatusUpdate();

                                _bIsSend = true;
                            }
                            else if (nServerType == (int)Dictionary.SMSServerType.ThirdPartyServer)
                            {
                                _bIsSend = IntegrateWithAPI(oCSDSMSHistory.ID, sMobileNo, sSMSText);
                                if (_bIsSend)
                                {
                                    oCSDSMSHistory.StatusUpdate((int)Dictionary.CSDSMSStatus.Sent);
                                    oCSDSMSHistory.SendUserID = Utility.UserId;
                                    oCSDSMSHistory.SendDate = DateTime.Now;
                                    oCSDSMSHistory.SendStatusUpdate();
                                }
                                //_bIsSend = true;
                            }
                            
                        }
                    }
                    //Send to server
                
                }
                DBController.Instance.CommitTran();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
            }
            return _bIsSend;
        }       
        public bool IntegrateWithAPI(int nID, string sMobileNo, string sText)
        {
            string HtmlResult = "";
            //String sid = "TranscomElecNon";
            String sid = "TranscomElecBrand";
            String user = "transcomelec";
            String pass = "u=25K587";

            String URI = "http://sms.sslwireless.com/pushapi/dynamic/server.php";
            String myParameters = "user=" + user + "&pass=" + pass + "&sms[0][0]=" + sMobileNo + "&sms[0][1]=" +
            System.Web.HttpUtility.UrlEncode("" + sText + "") + "&sms[0][2]=" + "" + nID + "" + "&sid=" + sid;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, myParameters);
                }
                return SendStatus(HtmlResult);
            }
            catch
            {

                return false;
            }
            
        }        
        public void IntegrateWithAPIBulk()
        {
            String sid = "STAKEHOLDER"; String user = "USER NAME"; String pass = "PASSWORD";
            String URI = "http://sms.sslwireless.com/pushapi/dynamic/server.php";
            String myParameters = "user=" + user + "&pass=" + pass + "&sms[0][0]=88***********&sms[0][1]=" +
            System.Web.HttpUtility.UrlEncode("Test SMS1\nTest SMS2\nTest SMS API3") + "&sms[0][2]=" + "1234567890" + "&sms[1][0]=88***********&sms[1][1]=" +
            System.Web.HttpUtility.UrlEncode("TESTSMS2\nTESTSMS3") + "&sms[1][2]=" + "1234567890" + "&sid=" + sid;
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URI, myParameters); Console.Write(HtmlResult);
            }
        }
        private bool SendStatus(string uri)
        {
            string sREFERENCEID = "";
            //using (XmlReader reader = XmlReader.Create(uri))
            using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(uri)))
            {
                string title = null;
                string author = null;

                reader.MoveToContent();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element
                        && reader.Name == "SMSINFO")
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element &&
                                reader.Name == "REFERENCEID")
                            {
                                sREFERENCEID = reader.ReadString();
                                break;
                            }
                        }
                        //while (reader.Read())
                        //{
                        //    if (reader.NodeType == XmlNodeType.Element &&
                        //        reader.Name == "Author")
                        //    {
                        //        author = reader.ReadString();
                        //        break;
                        //    }
                        //}
                        //yield return new Book() {Title = title, Author = author};
                    }
                }
            }
            if (sREFERENCEID != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void GetData(int nJobID)
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select JobID, JobNo, GSPNJobNo, CreateDate, LastFeedBackDate, VisitingDate, VisitingTimeFrom, VisitingTimeTo, " +
                          " ProductModel as Model, GroupName, a.RefChannelID, a.RefSalesPointID, CustomerName, a.MobileNo as CustContactNo,  " +
                          " CustomerAddress, AssignTo, CASE When ServiceType = 1 then 'W' When ServiceType = 2 then 'H' " +
                          " When ServiceType = 4 then 'I' else 'x' end as  " +
                          " ServiceType, CASE When ServiceType = 1 then 'W' When ServiceType = 2 then 'H' " +
                          " When ServiceType = 4 then 'I' else 'x' end as  " +
                          " ServiceType, CASE When ServiceType = 1 then 'Walk-In' When ServiceType = 2 then 'Home Service' " +
                          " When ServiceType = 4 then 'Installation' else 'x' end as  " +
                          " ServiceTypeFull,Case when JobType = 1 then 'FW' when JobType = 2 then 'PD'  " +
                          " when JobType = 3 then 'SW' else 'CW' end as JobType, b.MobileNo as TechMobNo, c.MobileNo as SupMobNo, " +
                          " e.Mobile as TPMGRMobile, b.Name as TechcianName, e.Name as TPName, f.MobileNo as SourceMobileNo, Fault, IsNull(EstSpAmount,0) as EstSpAmount, IsNull(EstScAmount,0) as EstScAmount from t_CSDJob a " +
                          " Left Outer JOIN " +
                          " (Select TechnicianID, MobileNo, SupervisorID, ThirdPartyID, Name from t_CSDTechnician) b ON b.TechnicianID = a.AssignTo " +
                          " Left Outer JOIN " +
                          " (Select SupervisorID, MobileNo from t_CSDTechnicalSupervisor) c ON b.SupervisorID = c.SupervisorID " +
                          " Left Outer JOIN " +
                          " (Select a.ProductID, GroupName, ProductModel from dbo.t_CSDServiceChargeProduct a, dbo.t_CSDServiceCharge b, t_Product c " +
                          " Where a.ServiceChargeID = b.ServiceChargeID and a.ProductID = c.ProductID)d ON a.ProductID = d.ProductID " +
                          " Left Outer JOIN " +
                          " (Select InterServiceID, Mobile, Name from t_CSDInterService)e ON e.InterServiceID = b.ThirdPartyID " +
                          " Left Outer JOIN " +
                          " (Select CustomerID as RefSalesPointID, ChannelID as RefChannelID, CellPhoneNumber as MobileNo  " +
                          " from t_Customer a, t_CustomerType b " +
                          " Where a.CustTypeID = b.CustTypeID " +
                          " UNION ALL " +
                          " Select InterServiceID as RefSalesPointID, 98 as RefChannelID, Mobile from t_CSDInterService)f  " +
                          " ON a.RefChannelID = f.RefChannelID and a.RefSalesPointID = f.RefSalesPointID " +
                          " INNER JOIN " +
                          " (Select FaultID as PrimaryFaultID, FaultDescription as Fault from dbo.t_CSDProductFault Where FaultLevel = 2)g " +
                          " ON a.PrimaryFaultID = g.PrimaryFaultID " +
                          " Where JobID = " + nJobID + " ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    _nJobID = (int)reader["JobID"];
                    _sJobNo = (string)reader["JobNo"];
                    if (reader["GSPNJobNo"] != DBNull.Value)
                    {
                        _sGSPNJobNo = "GSPN#" + (string)reader["GSPNJobNo"];
                    }
                    else
                    {
                        _sGSPNJobNo = "";
                    }
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    if (reader["LastFeedBackDate"] != DBNull.Value)
                        _dLastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"]);
                    else _dLastFeedBackDate = "";
                    if (reader["VisitingDate"] != DBNull.Value)
                        _dVisitingDate = Convert.ToDateTime(reader["VisitingDate"]);
                    else _dVisitingDate = "";
                    if (reader["VisitingTimeFrom"] != DBNull.Value)
                        _dVisitingTimeFrom = Convert.ToDateTime(reader["VisitingTimeFrom"]);
                    else _dVisitingTimeFrom = "";
                    if (reader["VisitingTimeTo"] != DBNull.Value)
                        _dVisitingTimeTo = Convert.ToDateTime(reader["VisitingTimeTo"]);
                    else _dVisitingTimeTo = "";
                    if (reader["Model"] != DBNull.Value)
                        _sModel = (string)reader["Model"];
                    else _sModel = "";
                    if (reader["GroupName"] != DBNull.Value)
                        _sGroupName = (string)reader["GroupName"];
                    else _sGroupName = "";
                    if (reader["RefChannelID"] != DBNull.Value)
                        _nRefChannelID = (int)reader["RefChannelID"];
                    else _nRefChannelID = "";
                    if (reader["RefSalesPointID"] != DBNull.Value)
                        _nRefSalesPointID = (int)reader["RefSalesPointID"];
                    else _nRefSalesPointID = "";
                    if (reader["CustomerName"] != DBNull.Value)
                        _sCustomerName = (string)reader["CustomerName"];
                    else _sCustomerName = "";
                    if (reader["CustContactNo"] != DBNull.Value)
                        _sCustContactNo = (string)reader["CustContactNo"];
                    else _sCustContactNo = "";
                    if (reader["CustomerAddress"] != DBNull.Value)
                        _sCustomerAddress = (string)reader["CustomerAddress"];
                    else _sCustomerAddress = "";
                    if (reader["AssignTo"] != DBNull.Value)
                        _nAssignTo = (int)reader["AssignTo"];
                    else _nAssignTo = "";
                    _sServiceType = (string)reader["ServiceType"];
                    _sServiceTypeFull = (string)reader["ServiceTypeFull"];
                    _sJobType = (string)reader["JobType"];
                    if (reader["TechMobNo"] != DBNull.Value)
                        _sTechMobNo = (string)reader["TechMobNo"];
                    else _sTechMobNo = "";
                    if (reader["SupMobNo"] != DBNull.Value)
                        _sSupMobNo = (string)reader["SupMobNo"];
                    else _sSupMobNo = "";
                    if (reader["TPMGRMobile"] != DBNull.Value)
                        _sTPMGRMobile = (string)reader["TPMGRMobile"];
                    else _sTPMGRMobile = "";
                    if (reader["TechcianName"] != DBNull.Value)
                        _sTechcianName = (string)reader["TechcianName"];
                    else _sTechcianName = "";
                    if (reader["TPName"] != DBNull.Value)
                        _sTPName = (string)reader["TPName"];
                    else _sTPName = "";
                    if (reader["SourceMobileNo"] != DBNull.Value)
                        _sSourceMobileNo = (string)reader["SourceMobileNo"];
                    else _sSourceMobileNo = "";
                    if (reader["Fault"] != DBNull.Value)
                        _sFault = (string)reader["Fault"];
                    else _sFault = "";
                    _sEstSpAmount = Convert.ToString(reader["EstSpAmount"]);
                    _sEstScAmount = Convert.ToString(reader["EstScAmount"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }

    
    }


}

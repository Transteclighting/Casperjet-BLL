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
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

using System.Windows.Forms;
using CJ.Class.HR;

namespace CJ.Class
{
    public class AttendData
    {
        private string _sEmployeeCode;
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }
        private string _sEmployeeName;
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
        private string _sCompany;
        public string Company
        {
            get { return _sCompany; }
            set { _sCompany = value.Trim(); }
        }
        private string _sDepartment;
        public string Department
        {
            get { return _sDepartment; }
            set { _sDepartment = value.Trim(); }
        }
        private string _sDesignation;
        public string Designation
        {
            get { return _sDesignation; }
            set { _sDesignation = value.Trim(); }
        }
        private int _nAttendDataID;
        private string _sCardNo;
        private DateTime _dPunchDate;
        private DateTime _dPunchTime;
        private string _sStationNo;
        private bool _bIsSystem;
        private int _nUserID;
        private int _nIngressFlag;

        /// <summary>
        /// Get set property for AttendDataID
        /// </summary>
        public int AttendDataID
        {
            get { return _nAttendDataID; }
            set { _nAttendDataID = value; }
        }
        /// <summary>
        /// Get set property for CardNo
        /// </summary>
        public string CardNo
        {
            get { return _sCardNo; }
            set { _sCardNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for PunchDate
        /// </summary>
        public DateTime PunchDate
        {
            get { return _dPunchDate; }
            set { _dPunchDate = value; }
        }

        /// <summary>
        /// Get set property for PunchTime
        /// </summary>
        public DateTime PunchTime
        {
            get { return _dPunchTime; }
            set { _dPunchTime = value; }
        }

        /// <summary>
        /// Get set property for StationNo
        /// </summary>
        public string StationNo
        {
            get { return _sStationNo; }
            set { _sStationNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for IsSystem
        /// </summary>
        public bool IsSystem
        {
            get { return _bIsSystem; }
            set { _bIsSystem = value; }
        }

        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }
        public int IngressFlag
        {
            get { return _nIngressFlag; }
            set { _nIngressFlag = value; }
        }

        private string _sMobileNo;
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
        }
        private string _sOnlyTimeIn;
        public string OnlyTimeIn
        {
            get { return _sOnlyTimeIn; }
            set { _sOnlyTimeIn = value; }
        }
        private int _nStatus;
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        private int _nEmployeeId;
        public int EmployeeId
        {
            get { return _nEmployeeId; }
            set { _nEmployeeId = value; }
        }

        private int _nMTD;
        public int MTD
        {
            get { return _nMTD; }
            set { _nMTD = value; }
        }
        private int _nYTD;
        public int YTD
        {
            get { return _nYTD; }
            set { _nYTD = value; }
        }

        public string GetNoPunchMechineListforSMS(DateTime _dSMSStartFrom,DateTime _dSMSStartTo)
        {

            string nMeshineList = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select x.Devicename+'['+y.DeviceSerialNumber+']' as Devicename From (Select Devicename From " +
                        "( " +
                        "Select Devicename, 0 as PunchCount From t_HRAttendanceMechine where isActive = 1 " +
                        "Union All " +
                        "Select StationNo, count(AttendDataID) NoOfPunch " +
                        "From t_HRAttendData where PunchDate between '" + _dSMSStartFrom + "' and '" + _dSMSStartTo.AddDays(1) + "' and PunchDate < '" + _dSMSStartTo.AddDays(1) + "' " +
                        "group by StationNo " +
                        ") Main group by Devicename " +
                        "having sum(PunchCount) = 0) x,t_HRAttendanceMechine y where x.Devicename=y.Devicename";


            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (nMeshineList == "")
                        nMeshineList = (string)reader["Devicename"];
                    else
                        nMeshineList = nMeshineList + ',' + (string)reader["Devicename"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nMeshineList;
        }
        public void Add()
        {
            int nMaxAttendDataID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([AttendDataID]) FROM t_HRAttendData";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxAttendDataID = 1;
                }
                else
                {
                    nMaxAttendDataID = Convert.ToInt32(maxID) + 1;
                }
                _nAttendDataID = nMaxAttendDataID;

                sSql = "INSERT INTO t_HRAttendData (AttendDataID,CardNo,PunchDate,PunchTime,StationNo,IsSystem,UserID)  VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("AttendDataID", _nAttendDataID);
                cmd.Parameters.AddWithValue("CardNo", _sCardNo);
                cmd.Parameters.AddWithValue("PunchDate", _dPunchDate);
                cmd.Parameters.AddWithValue("PunchTime", _dPunchTime);
                cmd.Parameters.AddWithValue("StationNo", _sStationNo);
                cmd.Parameters.AddWithValue("IsSystem", _bIsSystem);
                cmd.Parameters.AddWithValue("UserID", _nUserID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void AddCSVData()
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {


                sSql = "INSERT INTO t_testshift (testdatashift)  VALUES(?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("testdatashift", _sCardNo);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddRevised()
        {
            int nMaxAttendDataID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([AttendDataID]) FROM t_HRAttendData";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxAttendDataID = 1;
                }
                else
                {
                    nMaxAttendDataID = Convert.ToInt32(maxID) + 1;
                }
                _nAttendDataID = nMaxAttendDataID;

                sSql = "INSERT INTO t_HRAttendData (AttendDataID,CardNo,PunchDate,PunchTime,StationNo,IsSystem,UserID,IngressFlag)  VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("AttendDataID", _nAttendDataID);
                cmd.Parameters.AddWithValue("CardNo", _sCardNo);
                cmd.Parameters.AddWithValue("PunchDate", _dPunchDate);
                cmd.Parameters.AddWithValue("PunchTime", _dPunchTime);
                cmd.Parameters.AddWithValue("StationNo", _sStationNo);
                cmd.Parameters.AddWithValue("IsSystem", _bIsSystem);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("IngressFlag", _nIngressFlag);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_HRAttendData SET CardNo=?, PunchDate=?,"
                    + " PunchTime=?, StationNo=?, IsSystem=?, UserID=?"
                    + " WHERE AttendDataID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CardNo", _sCardNo);
                cmd.Parameters.AddWithValue("PunchDate", _dPunchDate);
                cmd.Parameters.AddWithValue("PunchTime", _dPunchTime);
                cmd.Parameters.AddWithValue("StationNo", _sStationNo);
                cmd.Parameters.AddWithValue("IsSystem", _bIsSystem);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("AttendDataID", _nAttendDataID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateAttendData(int nEmployeeID,string _dDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            //_dDate = DateTime.Today.ToString();
            try
            {

                sSql = "UPDATE t_HRAttendInfo SET Flag=1 where EmployeeID="+ nEmployeeID + " and PunchDate='"+_dDate+"'";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_HRAttendData WHERE [AttendDataID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("AttendDataID", _nAttendDataID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }


    }

    public class AttendDatas : CollectionBase
    {
        public AttendData this[int i]
        {
            get { return (AttendData)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(AttendData oAttendData)
        {
            InnerList.Add(oAttendData);
        }

        public int GetIndex(int nAttendDataID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].AttendDataID == nAttendDataID)
                {
                    return i;
                }
            }
            return -1;
        }



        public void GetEligibleEmployeeForAttendanceSMS(DateTime _dSMSStartFrom)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.EmployeeID, a.PunchDate, a.Status, e.MobileNo, " +
                          " IsNull(CONVERT(varchar(15), CAST(a.TimeIn AS TIME), 100), '') as OnlyTimeIn from t_HRAttendInfo a " +
                          " INNER JOIN (Select * from t_Employee Where IsEligibleForLateSMS = " + (int)Dictionary.YesOrNoStatus.YES + " and EMPStatus IN(" + (int)Dictionary.HREmployeeStatus.Contractual + ", " + (int)Dictionary.HREmployeeStatus.Confirmed + ")) e " +
                          " ON a.EmployeeID = e.EmployeeID Left Outer JOIN t_HRAttendanceSMS b " +
                          " ON a.EmployeeID = b.EmployeeId and a.PunchDate = b.TDate " +
                          " Where a.PunchDate >= '" + _dSMSStartFrom + "' and b.TDate is null and a.Status IN (" + (int)Dictionary.HRAttendanceStatus.Absent + ", " + (int)Dictionary.HRAttendanceStatus.Late + ") " +
                          " Order by a.PunchDate ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AttendData oAttendData = new AttendData();

                    oAttendData.EmployeeId = (int)reader["EmployeeId"];
                    oAttendData.PunchDate = Convert.ToDateTime(reader["PunchDate"]);
                    oAttendData.Status = (int)reader["Status"];
                    oAttendData.MobileNo = (string)reader["MobileNo"];
                    oAttendData.OnlyTimeIn = (string)reader["OnlyTimeIn"];

                    InnerList.Add(oAttendData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetEligibleEmployeeForBirthdaySMS(DateTime _dSMSStartFrom, DateTime _dDate)
        {
            string sStartDate = _dSMSStartFrom.Date.ToString("dd-MMM-yyyy");
            string sDate = _dDate.ToString("dd-MMM-yyyy");
            int nYear = _dDate.Year;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from " +
                          " ( " +
                          " Select a.EmployeeID, (EmployeeName + ' [' + EmployeeCode + '], ' + 'Mob: '+MobileNo+', '+ DesignationName + ', ' + DepartmentName + ', ' + CompanyCode) as EmployeeName, a.CompanyCode, b.TYear, a.MobileNo from " +
                          " ( " +
                          " SELECT * from v_EmployeeDetails Where FORMAT(CONVERT(datetime, '"+ sDate + "'), 'dd-MMM') = FORMAT(DateOfBirth, 'dd-MMM') and EMPStatus IN(" + (int)Dictionary.HREmployeeStatus.Contractual + ", " + (int)Dictionary.HREmployeeStatus.Confirmed + ") " +
                         // " and FORMAT(CONVERT(datetime, '"+ _dSMSStartFrom + "'), 'dd-MMM') <= FORMAT(DateOfBirth, 'dd-MMM') " +
                          " ) a " +
                          " Left Outer JOIN " +
                          " (Select * from t_HRBirthdaySMSLog Where TYear = "+ nYear + ") b ON a.EmployeeID = b.EmployeeId " +
                          " )f Where TYear Is Null ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AttendData oAttendData = new AttendData();

                    oAttendData.EmployeeId = (int)reader["EmployeeId"];
                    oAttendData.EmployeeName = (string)reader["EmployeeName"];
                    oAttendData.MobileNo = (string)reader["MobileNo"];
                    oAttendData.Company = (string)reader["CompanyCode"];

                    InnerList.Add(oAttendData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int[] Get_MTD_YTD_Late_Absent(DateTime dInitialStartDate, DateTime dAttendDate, int nStatus, int nEmployeeId)
        {
            int[] MTD_YTD = new int[2];

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select a.*, YTD from " +
                          " ( " +
                          " Select EmployeeID, month(a.PunchDate) as TMonth, year(a.PunchDate) as TYear, " +
                          " Status, count(*) as MTD from t_HRAttendInfo a " +
                          " Where a.PunchDate >= '"+ dInitialStartDate + "' " +
                          " and a.PunchDate <= '"+ dAttendDate + "' " +
                          " and month(a.PunchDate) = month('" + dAttendDate + "') " +
                          " and year(a.PunchDate) = year('" + dAttendDate + "') " +
                          " and Status = "+ nStatus + " and a.EmployeeID = "+ nEmployeeId + " " +
                          " Group by EmployeeID, Status, month(a.PunchDate), year(a.PunchDate) " +
                          " )a " +
                          " INNER JOIN " +
                          " (Select EmployeeID, year(a.PunchDate) as TYear, " +
                          " Status, count(*) as YTD from t_HRAttendInfo a " +
                          " Where a.PunchDate >= '"+ dInitialStartDate + "' " +
                          " and a.PunchDate <= '" + dAttendDate + "' " +
                          " and year(a.PunchDate) = year('" + dAttendDate + "') " +
                          " and Status = "+ nStatus +"  and a.EmployeeID = "+ nEmployeeId + " " +
                          " Group by EmployeeID, Status, year(a.PunchDate))b " +
                          " ON a.EmployeeID = b.EmployeeID and a.TYear = b.TYear and a.Status = b.Status ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    AttendData oAttendData = new AttendData();
                    MTD_YTD[0] = (int)reader["MTD"];
                    MTD_YTD[1] = (int)reader["YTD"];
                    //oAttendData.MTD = (int)reader["MTD"];
                    //oAttendData.YTD = (int)reader["YTD"];

                    InnerList.Add(oAttendData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return MTD_YTD;
        }
        public void Refresh()
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRAttendData";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }

        public void RefreshAbsentData(string dFromDate, string dToDate, string sEmpList)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            //dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select EmployeeCode,EmployeeName,DesignationName,DepartmentName,CompanyCode,PunchDate From  " +
                       "t_HRAttendInfo a, v_EmployeeDetails b where Status = 0 and PunchDate between '" + dFromDate + "' and '" + dToDate + "'  " +
                       "and a.EmployeeID = b.EmployeeID and a.EmployeeID in (" + sEmpList + ") Order by EmployeeCode,PunchDate";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AttendData oAttendData = new AttendData();

                    oAttendData.EmployeeCode = (string)reader["EmployeeCode"];
                    oAttendData.EmployeeName = (string)reader["EmployeeName"];
                    oAttendData.Designation = (string)reader["DesignationName"];
                    oAttendData.Department = (string)reader["DepartmentName"];
                    oAttendData.PunchDate = (DateTime)reader["PunchDate"];
                    oAttendData.Company = (string)reader["CompanyCode"];

                    InnerList.Add(oAttendData);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public DSAttendance GetAttendanceData(DSAttendance oDAttendance, DateTime dFromDate, DateTime dToDate, int nCompanyID, int nEmployeeID, int nDepartmentID)
        {
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " SELECT EmployeeID, a.CardNo, PunchDate, PunchTime " +
                          " FROM t_HRAttendData a, t_Employee b " +
                          " WHERE a.CardNo = b.CardNo AND PunchDate between '"+ dFromDate + "' and '"+ dToDate + "' " +
                          " and PunchDate < '"+ dToDate + "' ";

            if (nCompanyID == 0)
            {
                sSql = sSql + " and CompanyID IN (Select DataID from dbo.t_UserPermissionData Where DataType='Company' and UserID=" + Utility.UserId + ") ";
            }
            else
            {
                sSql = sSql + " and CompanyID = " + nCompanyID + " ";
            }
            if (nDepartmentID != 0)
            {
                sSql = sSql + " AND DepartmentID=" + nDepartmentID + " ";
            }
            if (nEmployeeID != 0)
            {
                sSql = sSql + " AND EmployeeID=" + nEmployeeID + " ";
            }
            sSql = sSql + "  Order by EmployeeID, PunchDate, PunchTime ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSAttendance.HolydayRow oAttendanceRow = oDAttendance.Holyday.NewHolydayRow();


                    oAttendanceRow.EmployeeID = (int)reader["EmployeeID"];
                    oAttendanceRow.CardNumber = (string)reader["CardNo"];
                    oAttendanceRow.FromDate = (DateTime)reader["PunchDate"];
                    oAttendanceRow.ToDate = (DateTime)reader["PunchTime"];

                    oDAttendance.Holyday.AddHolydayRow(oAttendanceRow);
                    oDAttendance.AcceptChanges();
                }
                reader.Close();
                //InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDAttendance;
        }

        public void Refresh(string sCardNo, DateTime dPunchDate)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRAttendData WHERE CardNo=? AND PunchDate=? ORDER BY PunchTime";
            cmd.Parameters.AddWithValue("CardNo", sCardNo);
            cmd.Parameters.AddWithValue("PunchDate", dPunchDate);

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate,string sCardNo)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRAttendData"
                + " WHERE CardNo LIKE ? AND PunchDate BETWEEN ? AND ? ORDER BY AttendDataID DESC";

            cmd.Parameters.AddWithValue("CardNo", "%" + sCardNo + "%");
            cmd.Parameters.AddWithValue("FromDate", dFromDate);
            cmd.Parameters.AddWithValue("ToDate", dToDate);

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }

        private void GetData(OleDbCommand cmd)
        {
            InnerList.Clear();
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AttendData oAttendData = new AttendData();
                    oAttendData.AttendDataID = (int)reader["AttendDataID"];
                    oAttendData.CardNo = (string)reader["CardNo"];
                    oAttendData.PunchDate = (DateTime)reader["PunchDate"];
                    oAttendData.PunchTime = (DateTime)reader["PunchTime"];
                    oAttendData.StationNo = (string)reader["StationNo"];
                    oAttendData.IsSystem = Convert.ToBoolean(reader["IsSystem"]);
                    oAttendData.UserID = (int)reader["UserID"];

                    InnerList.Add(oAttendData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class AttendInfo
    {
        private int _nID;
        private int _nEmployeeID;
        private DateTime _dPunchDate;
        private object _dTimeIn;
        private object _dTimeOut;
        private object _dLate;
        private int _nPunchCount;
        private Dictionary.HRAttendanceStatus _nStatus;
        private string _sRemarks;
        private string _sEmployeeName;
        private int _nWarehouseID;
        private int _nAttendanceStatus;
        private string _sEmployeeCode;
        private object _nTotalHour;
        private object _dDate;
        private object _dLessExtraTime;
        private string _sLessWorkHour;
        private string _sActualWorkHour;
        private string _sMoreWorkHour;
        private string _sStandardWorkHoure;
        private string _sCountExtraWorkingDay;
        private string _sCountLessWorkingDay;
        private string _sCountStandardWarkingDay;
        public string CountStandardWarkingDay
        {
            get { return _sCountStandardWarkingDay; }
            set { _sCountStandardWarkingDay = value.Trim(); }
        }
        public string CountExtraWorkingDay
        {
            get { return _sCountExtraWorkingDay; }
            set { _sCountExtraWorkingDay = value.Trim(); }
        }
        public string CountLessWorkingDay
        {
            get { return _sCountLessWorkingDay; }
            set { _sCountLessWorkingDay = value.Trim(); }
        }


        public string LessWorkHour
        {
            get { return _sLessWorkHour; }
            set { _sLessWorkHour = value.Trim(); }
        }
        public string ActualWorkHour
        {
            get { return _sActualWorkHour; }
            set { _sActualWorkHour = value.Trim(); }
        }

        public string MoreWorkHour
        {
            get { return _sMoreWorkHour; }
            set { _sMoreWorkHour = value.Trim(); }
        }

        public string StandardWorkHoure
        {
            get { return _sStandardWorkHoure; }
            set { _sStandardWorkHoure = value.Trim(); }
        }
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        public object TotalHour
        {
            get { return _nTotalHour; }
            set { _nTotalHour = value; }
        }
        public object Date
        {
            get { return _dDate; }
            set { _dDate = value; }
        }
        /// <summary>
        /// Get set property for PunchCount
        /// </summary>
        public int AttendanceStatus
        {
            get { return _nAttendanceStatus; }
            set { _nAttendanceStatus = value; }
        }

        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }


        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }

        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
        private Employee _oEmployee;

        private bool _bReadDB;

        /// <summary>
        /// Get set property for EmployeeID
        /// </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        public Employee Employee
        {
            get
            {
                if (_oEmployee == null)
                {
                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = _nEmployeeID;
                    if (_bReadDB) _oEmployee.Refresh();
                }

                return _oEmployee;
            }
        }

        /// <summary>
        /// Get set property for PunchDate
        /// </summary>
        public DateTime PunchDate
        {
            get { return _dPunchDate; }
            set { _dPunchDate = value; }
        }

        /// <summary>
        /// Get set property for TimeIn
        /// </summary>
        public object TimeIn
        {
            get { return _dTimeIn; }
            set { _dTimeIn = value; }
        }

        /// <summary>
        /// Get set property for TimeOut
        /// </summary>
        public object TimeOut
        {
            get { return _dTimeOut; }
            set { _dTimeOut = value; }
        }
        public object LessExtraTime
        {
            get { return _dLessExtraTime; }
            set { _dLessExtraTime = value; }
        }

        /// <summary>
        /// Get set property for Late
        /// </summary>
        public object Late
        {
            get { return _dLate; }
            set { _dLate = value; }
        }

        /// <summary>
        /// Get set property for PunchCount
        /// </summary>
        public int PunchCount
        {
            get { return _nPunchCount; }
            set { _nPunchCount = value; }
        }

        /// <summary>
        /// Get set property for Status
        /// </summary>
        public Dictionary.HRAttendanceStatus Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ?
        /// </summary>
        public bool ReadDB
        {
            get { return _bReadDB; }
            set { _bReadDB = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_HRAttendInfo(EmployeeID,PunchDate,TimeIn,"
                    + " TimeOut,Late,PunchCount,Status,Remarks) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("PunchDate", _dPunchDate);
                cmd.Parameters.AddWithValue("TimeIn", _dTimeIn);
                cmd.Parameters.AddWithValue("TimeOut", _dTimeOut);
                cmd.Parameters.AddWithValue("Late", _dLate);
                cmd.Parameters.AddWithValue("PunchCount", _nPunchCount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddForPOS(DateTime dtDate)
        {
            int nID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_OutletAttendanceInfo where Date not in ('" + dtDate + "')";

                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nID = 1;
                }
                else
                {
                    nID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nID;

                sSql = "INSERT INTO t_OutletAttendanceInfo(ID,EmployeeID,WarehouseID,Date,TimeIn,"
                     + " TimeOut,Status) VALUES(?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Date", _dPunchDate);
                if (_nAttendanceStatus == (int)Dictionary.HRAttendanceStatusForOutlet.Present)
                {
                    cmd.Parameters.AddWithValue("TimeIn", _dTimeIn);
                    cmd.Parameters.AddWithValue("TimeOut", _dTimeOut);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TimeIn", null);
                    cmd.Parameters.AddWithValue("TimeOut", null);
                }
                cmd.Parameters.AddWithValue("Status", _nAttendanceStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_HRAttendInfo WHERE EmployeeID=? AND PunchDate=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("PunchDate", _dPunchDate);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetMaxIngressNumber()
        {
            int nMaxNumber = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT isnull(MAX(IngressFlag),0) as IngressFlag FROM [dbo].[t_HRAttendData] where IngressFlag is not null";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    nMaxNumber = (int)reader["IngressFlag"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nMaxNumber;
        }

        public void GetWorkingHour(DateTime FromPunchDate, DateTime ToPunchDate, string sEmpCode)
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            ToPunchDate = ToPunchDate.AddDays(1);
            

            string sSql = "Select *,  " +
                        "CAST(LessWorkingMin/60 AS VARCHAR(6)) + ':' + replace( str(CAST(LessWorkingMin%60 As VARCHAR(20)),2),' ','0') as LesWorkingHour  From   " +
                        "(  " +
                        "Select count(OfficeWorkingMin) CountStandardWarkingDay,sum(OfficeWorkingMin) OfficeWorkingMin,  " +
                        "CAST(sum(OfficeWorkingMin)/60 AS VARCHAR(6)) + ':' + replace( str(CAST(sum(OfficeWorkingMin)%60 As VARCHAR(20)),2),' ','0') as StandardWorkingHour,  " +
                        "sum(ActualWorkingMin) ActualWorkingMin,  " +
                        "CAST(sum(ActualWorkingMin)/60 AS VARCHAR(6)) + ':' + replace( str(CAST(sum(ActualWorkingMin)%60 As VARCHAR(20)),2),' ','0') as ActualWorkingHour,  " +
                        "sum(ExtraWorkingMin) as ExtraWorkingMin,  " +
                        "CAST(sum(ExtraWorkingMin)/60 AS VARCHAR(6)) + ':' + replace( str(CAST(sum(ExtraWorkingMin)%60 As VARCHAR(20)),2),' ','0') as ExtraWorkingHour,  " +
                        "sum(LessWorkingMin)*-1 as LessWorkingMin,sum(CountLessWorkingDay) CountLessWorkingDay,sum(CountExtraWorkingDay) CountExtraWorkingDay  " +
                        "From   " +
                        "(  " +
                        "Select *,  " +
                        "DATEDIFF(mi, LoginTime, LogoutTime)+1 OfficeWorkingMin,  " +
                        "isnull(DATEDIFF(mi, TimeIn, TimeOut),0) ActualWorkingMin,  " +
                        "isnull(DATEDIFF(mi, TimeIn, TimeOut),0)-(DATEDIFF(mi, LoginTime, LogoutTime)+1) DiffMin,  " +
                        "case when isnull(DATEDIFF(mi, TimeIn, TimeOut),0)-(DATEDIFF(mi, LoginTime, LogoutTime)+1)<0 then   " +
                        "isnull(DATEDIFF(mi, TimeIn, TimeOut),0)-(DATEDIFF(mi, LoginTime, LogoutTime)+1) end as LessWorkingMin,  " +
                        "case when isnull(DATEDIFF(mi, TimeIn, TimeOut),0)-(DATEDIFF(mi, LoginTime, LogoutTime)+1)>=0 then   " +
                        "isnull(DATEDIFF(mi, TimeIn, TimeOut),0)-(DATEDIFF(mi, LoginTime, LogoutTime)+1) end as ExtraWorkingMin,  " +
                        "case when isnull(DATEDIFF(mi, TimeIn, TimeOut),0)-(DATEDIFF(mi, LoginTime, LogoutTime)+1)<0 then 1 else 0 end as IsLess,  " +
                        "case when isnull(DATEDIFF(mi, TimeIn, TimeOut),0)-(DATEDIFF(mi, LoginTime, LogoutTime)+1)<0 then   "+
                        "1 else 0 end as CountLessWorkingDay,   " +
                        "case when isnull(DATEDIFF(mi, TimeIn, TimeOut), 0)-(DATEDIFF(mi, LoginTime, LogoutTime) + 1) >= 0 then   " +
                        "1 else 0 end as CountExtraWorkingDay  " +
                        "From   " +
                        "(  " +
                        "Select PunchDate,c.Status,  " +
                        "CONVERT(VARCHAR(5), c.TimeIn, 108) TimeIn,  " +
                        "CONVERT(VARCHAR(5), c.TimeOut, 108) TimeOut,  " +
                        "CONVERT(VARCHAR(5), b.LoginTime, 108) LoginTime,  " +
                        "case when DATENAME(dw,PunchDate)='Saturday' then '13:30' else CONVERT(VARCHAR(5), b.LogoutTime, 108) end LogoutTime  " +
                        "from t_Employee a,t_HRShift b,t_HRAttendInfo c  " +
                        "where a.ShiftID=b.ShiftID and a.EmployeeID=c.EmployeeID and   " +
                        "PunchDate between '" + FromPunchDate + "' and '" + ToPunchDate + "' and PunchDate<'" + ToPunchDate + "'and EmployeeCode='" + sEmpCode + "'  " +
                        "and Status not In (3,4,5)  " +
                        ") X ) xx ) Main";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["LesWorkingHour"] is DBNull)
                    {
                        _sLessWorkHour = "00:00";
                    }
                    else
                    {
                        _sLessWorkHour = (string)reader["LesWorkingHour"];
                    }
                    if (reader["ExtraWorkingHour"] is DBNull)
                    {
                        _sMoreWorkHour = "00:00";
                    }
                    else
                    {
                        _sMoreWorkHour = (string)reader["ExtraWorkingHour"];
                    }
                    _sStandardWorkHoure = (string)reader["StandardWorkingHour"];
                    _sCountLessWorkingDay = Convert.ToInt32(reader["CountLessWorkingDay"]).ToString();
                    _sCountExtraWorkingDay = Convert.ToInt32(reader["CountExtraWorkingDay"]).ToString();
                    _sCountStandardWarkingDay = Convert.ToInt32(reader["CountStandardWarkingDay"]).ToString();
                    _sActualWorkHour = (string)reader["ActualWorkingHour"];


                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }


    public class AttendInfos : CollectionBase
    {
        public AttendInfo this[int i]
        {
            get { return (AttendInfo)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(AttendInfo oAttendInfo)
        {
            InnerList.Add(oAttendInfo);
        }

        //public int GetIndex(int nAttendInfoID)
        //{
        //    int i;
        //    for (i = 0; i < this.Count; i++)
        //    {
        //        if (this[i].AttendInfoID == nAttendInfoID)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRAttendInfo";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }

        public void Refresh(DateTime dFromDate,DateTime dToDate, int nCompanyID, int nDepartmentID, int nShiftID, int nStatus, string sCode, string sName, int sAttendanceRpt, int nUserID,bool isFactoryEmployee)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "SELECT * FROM t_HRAttendInfo A "+
            //              " INNER JOIN v_EmployeeDetails B ON A.EmployeeID=B.EmployeeID " +
            //              " inner join t_UserPermissionData c on c.DataID=b.DepartmentID and c.UserID= "+nUserID+" and c.DataType='Department' "+
            //              "inner join t_UserPermissionData d on d.DataID=b.CompanyID and d.UserID= " + nUserID + " and d.DataType='Company' " +
            string sSql = "SELECT * FROM t_HRAttendInfo A " +
                          " INNER JOIN v_EmployeeDetails B ON A.EmployeeID=B.EmployeeID " +
                          //" inner join t_UserPermissionData c on c.DataID=b.DepartmentID  and c.DataType='Department' " +
                          //"inner join t_UserPermissionData d on d.DataID=b.CompanyID and d.UserID= " + nUserID + " and d.DataType='Company' " +

                 " WHERE PunchDate BETWEEN ? AND ?";
            cmd.Parameters.AddWithValue("FromDate", dFromDate);
            cmd.Parameters.AddWithValue("ToDate", dToDate);
            string sClause = "";

            if (nCompanyID != 0)
            {
                sClause = " AND CompanyID=?";
                cmd.Parameters.AddWithValue("CompanyID", nCompanyID);
            }

            if (nDepartmentID != 0)
            {
                sClause = sClause + " AND DepartmentID=?";
                cmd.Parameters.AddWithValue("DepartmentID", nDepartmentID);
            }

            if (nShiftID != 0)
            {
                sClause = sClause + " AND ShiftID=?";
                cmd.Parameters.AddWithValue("ShiftID", nShiftID);
            }
            
            if (nStatus>-1)
            {
                sClause = sClause + " AND Status=?";
                cmd.Parameters.AddWithValue("Status", nStatus);
            }

            if (sCode != "")
            {
                sClause = sClause + " AND EmployeeCode=?";
                cmd.Parameters.AddWithValue("EmployeeCode", sCode);
            }

            if (sName != "")
            {
                sClause = sClause + " AND EmployeeName LIKE ?";
                cmd.Parameters.AddWithValue("EmployeeName", "%" + sName + "%");
            }

            if (sAttendanceRpt > -1)
            {
                sClause = sClause + " AND ShowAttendanceRpt=?";
                cmd.Parameters.AddWithValue("ShowAttendanceRpt", sAttendanceRpt);
            }
            if (isFactoryEmployee)
            {
                sSql += " AND IsFactoryEmployee = " + (int) Dictionary.YesNAStatus.Yes;
            }
            cmd.CommandText = sSql + sClause + " ORDER BY CompanyID, DepartmentID, A.EmployeeID";
            cmd.CommandType = CommandType.Text;
            GetData(cmd);

        }

        private void GetData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AttendInfo oAttendInfo = new AttendInfo();

                    oAttendInfo.EmployeeID = (int)reader["EmployeeID"];
                    oAttendInfo.Employee.EmployeeID = (int)reader["EmployeeID"];
                    oAttendInfo.Employee.EmployeeCode=(string)reader["EmployeeCode"];
                    oAttendInfo.Employee.EmployeeName= (string)reader["EmployeeName"];
                    oAttendInfo.Employee.DepartmentID = (int)reader["DepartmentID"];
                    oAttendInfo.Employee.DesignationID = (int)reader["DesignationID"];
                    oAttendInfo.Employee.CompanyID = (int)reader["CompanyID"];
                    oAttendInfo.PunchDate = (DateTime)reader["PunchDate"];
                    if (reader["TimeIn"] is DBNull)
                    {
                        oAttendInfo.TimeIn = null;
                    }
                    else
                    {
                        oAttendInfo.TimeIn = (DateTime)reader["TimeIn"];
                    }

                    if (reader["TimeOut"] is DBNull)
                    {
                        oAttendInfo.TimeOut = null;
                    }
                    else
                    {
                        oAttendInfo.TimeOut = (DateTime)reader["TimeOut"];
                    }

                    if (reader["Late"] is DBNull)
                    {
                        oAttendInfo.Late = null;
                    }
                    else
                    {
                        oAttendInfo.Late = (DateTime)reader["Late"];
                    }

                    oAttendInfo.PunchCount = (int)reader["PunchCount"];
                    oAttendInfo.Status = (Dictionary.HRAttendanceStatus)reader["Status"];
                    InnerList.Add(oAttendInfo);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool Process(DateTime dFromDate, DateTime dTodate, int nCompanyID, int nDepartmentID, ProgressBar pbDate, ProgressBar pbEmployee,int nShiftID)
        {
            DateTime d;
            if (dFromDate > dTodate)
            {
                return false;
            }
            Holiday oHoliday;
            EmployeeLeave oEmployeeLeave;
            OutStationDuty oOutStationDuty;
            AttendDatas oAttendDatas;
            AttendInfo oAttendInfo;
            Employees oEmployees = new Employees();
            oEmployees.RefreshDetail(nCompanyID, nDepartmentID, 0, "", "", Dictionary.GeneralStatus.Active,false);
            //82973
            try
            {
                pbDate.Minimum = 0;
                TimeSpan oDateSpan = dTodate - dFromDate;
                pbDate.Maximum = Convert.ToInt32( oDateSpan.TotalDays)+1;
                pbDate.Step = 1;
                pbDate.Value = 0;
                for (d = dFromDate; d<=dTodate; d=d.AddDays(1))
                {
                    pbEmployee.Minimum = 0;
                    pbEmployee.Maximum = oEmployees.Count;
                    pbEmployee.Step = 1;
                    pbEmployee.Value = 0;
                    foreach (Employee oEmployee in oEmployees)
                    {
                        
                        //Holiday calculation
                        oHoliday = new Holiday();
                        oHoliday.CompanyID = oEmployee.CompanyID;
                        oHoliday.HolidayDate = d;
                        bool bIsHoliday=oHoliday.IsHoliday();
                        //Leave calculation                      
                        oEmployeeLeave = new EmployeeLeave();
                        oEmployeeLeave.EmployeeID = oEmployee.EmployeeID;
                        bool bIsLeave = oEmployeeLeave.IsLeave(d);

                        // Out Stationb Leave
                        oOutStationDuty = new OutStationDuty();
                        oOutStationDuty.EmployeeID = oEmployee.EmployeeID;
                        bool bIsOutSationLeave = oOutStationDuty.IsOutStationDuty(d);

                        //Attendance
                        oAttendInfo = new AttendInfo();
                        oAttendInfo.EmployeeID = oEmployee.EmployeeID;
                        oAttendInfo.PunchDate = d;

                        //if (bIsHoliday || bIsLeave)
                        //{
                        //    //Holiday & Leave
                        //    if (bIsHoliday) oAttendInfo.Status = Dictionary.HRAttendanceStatus.Holiday;
                        //    if (bIsLeave) oAttendInfo.Status = Dictionary.HRAttendanceStatus.Leave;
                        //    oAttendInfo.PunchCount = 0;
                        //}
                        //else
                        //{
                        //    oAttendDatas = new AttendDatas();
                        //    oAttendDatas.Refresh(oEmployee.CardNo, d);
                        //    if (oAttendDatas.Count > 0)
                        //    {
                        //        DateTime dTimeIn;
                        //        DateTime dLoginTime = oEmployee.Shift.LoginTime;
                        //        dTimeIn = oAttendDatas[0].PunchTime;
                        //        oAttendInfo.TimeIn = dTimeIn;
                        //        TimeSpan o = new TimeSpan(dLoginTime.Hour, dLoginTime.Minute, 0);
                        //        if (o < dTimeIn.Subtract(dTimeIn.Date))
                        //        {
                        //            //Late Present
                        //            oAttendInfo.Late = dTimeIn.Subtract(dTimeIn.Date) - o;
                        //            oAttendInfo.Status = Dictionary.HRAttendanceStatus.Late;
                        //        }
                        //        else
                        //        {
                        //            //Present
                        //            oAttendInfo.Late = null;
                        //            oAttendInfo.Status = Dictionary.HRAttendanceStatus.Present;
                        //        }
                        //        if (oAttendDatas.Count > 1)
                        //            oAttendInfo.TimeOut = oAttendDatas[oAttendDatas.Count - 1].PunchTime;

                        //    }
                        //    else
                        //    {
                        //        //Absent
                        //        oAttendInfo.Status = Dictionary.HRAttendanceStatus.Absent;
                        //    }
                        //    oAttendInfo.PunchCount = oAttendDatas.Count;
                        //}


                        oAttendDatas = new AttendDatas();
                        oAttendDatas.Refresh(oEmployee.CardNo, d.Date);
                        if (oAttendDatas.Count > 0)
                        {
                            DateTime dTimeIn;
                            DateTime dLoginTime;
                            if (nShiftID != -1)
                            {
                                Shift oShift = new Shift();
                                oShift.ShiftID = nShiftID;
                                oShift.Refresh();
                                dLoginTime = oShift.LoginTime;
                            }
                            else dLoginTime = oEmployee.Shift.LoginTime;

                            dTimeIn = oAttendDatas[0].PunchTime;
                            oAttendInfo.TimeIn = dTimeIn;
                            if (bIsHoliday || bIsLeave || bIsOutSationLeave)
                            {
                                //Holiday & Leave
                                if (bIsHoliday) oAttendInfo.Status = Dictionary.HRAttendanceStatus.Holiday;
                                if (bIsLeave) oAttendInfo.Status = Dictionary.HRAttendanceStatus.Leave;
                                if (bIsOutSationLeave) oAttendInfo.Status = Dictionary.HRAttendanceStatus.OutStation;
                            }
                            else
                            {
                                TimeSpan o = new TimeSpan(dLoginTime.Hour, dLoginTime.Minute, 0);
                                if (o < dTimeIn.Subtract(dTimeIn.Date))
                                {
                                    //Late Present
                                    oAttendInfo.Late = dTimeIn.Subtract(dTimeIn.Date) - o;
                                    oAttendInfo.Status = Dictionary.HRAttendanceStatus.Late;
                                }
                                else
                                {
                                    //Present
                                    oAttendInfo.Late = null;
                                    oAttendInfo.Status = Dictionary.HRAttendanceStatus.Present;
                                }
                            }
                            if (oAttendDatas.Count > 1)
                                oAttendInfo.TimeOut = oAttendDatas[oAttendDatas.Count - 1].PunchTime;
                        }
                        else
                        {
                            if (bIsHoliday || bIsLeave || bIsOutSationLeave)
                            {
                                //Holiday & Leave
                                if (bIsHoliday) oAttendInfo.Status = Dictionary.HRAttendanceStatus.Holiday;
                                if (bIsLeave) oAttendInfo.Status = Dictionary.HRAttendanceStatus.Leave;
                                if (bIsOutSationLeave) oAttendInfo.Status = Dictionary.HRAttendanceStatus.OutStation;
                            }
                            else
                            {
                                //Absent
                                oAttendInfo.Status = Dictionary.HRAttendanceStatus.Absent;
                            }
                        }
                        oAttendInfo.PunchCount = oAttendDatas.Count;


                        oAttendInfo.Remarks = "Test";
                        oAttendInfo.Delete();
                        oAttendInfo.Add();
                        pbEmployee.PerformStep();
                    }
                    pbDate.PerformStep(); 
                }

                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
                return false;
            }
        }

        //Modified by Hakim
        public int ProcessRevised(DateTime dFromDate, DateTime dTodate, int nCompanyID, int nDepartmentID, ProgressBar pbDate, ProgressBar pbEmployee, int nShiftID, int nEmployeeID, bool _IsOnlyFactory)
        {
            int nCount = 0;
            DateTime d;
            pbDate.Minimum = 0;
            TimeSpan oDateSpan = dTodate - dFromDate;
            pbDate.Maximum = Convert.ToInt32(oDateSpan.TotalDays) + 1;
            pbDate.Step = 1;
            pbDate.Value = 0;

            Holiday oHoliday;
            EmployeeLeave oEmployeeLeave;
            OutStationDuty oOutStationDuty;
            AttendDatas oAttendDatas;
            AttendInfo oAttendInfo;
            Shifts oShifts;
            Employees oEmployees = new Employees();

            DSAttendance _oDSHolyday;
            DSAttendance _oDSLeave;
            DSAttendance _oDSOutstation;
            DSAttendance _oDSAttendance;
            DSAttendance _oDShift;

            oEmployees.GetEmployeeAttendanceProcess(nCompanyID, nDepartmentID, nEmployeeID, dFromDate, dTodate, _IsOnlyFactory);


            Holidays oHolidays = new Holidays();
            _oDSHolyday = new DSAttendance();
            _oDSHolyday = oHolidays.GetHolydayData(_oDSHolyday, nCompanyID, dFromDate, dTodate);

            EmployeeLeaves oEmployeeLeaves = new EmployeeLeaves();
            _oDSLeave = new DSAttendance();
            _oDSLeave = oEmployeeLeaves.GetLeave(_oDSLeave, dFromDate, dTodate);

            OutStationDuties oOutStationDuties = new OutStationDuties();
            _oDSOutstation = new DSAttendance();
            _oDSOutstation = oOutStationDuties.GetOutstationData(_oDSOutstation, dFromDate, dTodate);

            oAttendDatas = new AttendDatas();
            _oDSAttendance = new DSAttendance();
            _oDSAttendance = oAttendDatas.GetAttendanceData(_oDSAttendance, dFromDate, dTodate, nCompanyID, nEmployeeID, nDepartmentID);

            oShifts = new Shifts();
            _oDShift = new DSAttendance();
            _oDShift = oShifts.GetShiftData(_oDShift, nCompanyID);

            #region
            try
            {

                for (d = dFromDate; d <= dTodate; d = d.AddDays(1))
                {
                    pbEmployee.Minimum = 0;
                    pbEmployee.Maximum = oEmployees.Count;
                    pbEmployee.Step = 1;
                    pbEmployee.Value = 0;
                    foreach (Employee oEmployee in oEmployees)
                    {

                        //Holiday calculation
                        oHoliday = new Holiday();
                        oHoliday.CompanyID = oEmployee.CompanyID;
                        oHoliday.HolidayDate = d;
                        bool bIsHoliday = CheckHolyday(_oDSHolyday, oEmployee.CompanyID, d);



                        //Leave calculation                      
                        oEmployeeLeave = new EmployeeLeave();
                        oEmployeeLeave.EmployeeID = oEmployee.EmployeeID;
                        bool bIsLeave = CheckLeave(_oDSLeave, oEmployee.EmployeeID, d);


                        // Out Stationb Leave
                        oOutStationDuty = new OutStationDuty();
                        oOutStationDuty.EmployeeID = oEmployee.EmployeeID;
                        bool bIsOutSationLeave = CheckOutstation(_oDSOutstation, oEmployee.EmployeeID, d);


                        //Attendance
                        oAttendInfo = new AttendInfo();
                        oAttendInfo.EmployeeID = oEmployee.EmployeeID;
                        oAttendInfo.PunchDate = d;



                        oAttendDatas = new AttendDatas();
                        //oAttendDatas.Refresh(oEmployee.CardNo, d.Date);

                        //string[] Attendance = GetAttendance(_oDSAttendance, oEmployee.EmployeeID, d);
                        //oEmployee.EmployeeID
                        string[] attendata;
                        attendata = GetAttendance(_oDSAttendance, oEmployee.EmployeeID, d);
                        int nTotalData = Convert.ToInt32(attendata[0]);
                        DateTime dInTime;
                        DateTime dOutTime;
                        if (nTotalData > 0)
                        {
                            dInTime = Convert.ToDateTime(attendata[1]);
                            dOutTime = Convert.ToDateTime(attendata[2]);
                        }

                        // if (oAttendDatas.Count > 0)
                        if (nTotalData > 0)
                        {
                            DateTime dTimeIn;
                            DateTime dLoginTime;
                            if (nShiftID != -1)
                            {
                                Shift oShift = new Shift();
                                //oShift.ShiftID = nShiftID;
                                //oShift.Refresh();
                                //dLoginTime = oShift.LoginTime;
                                dLoginTime = GetShift(_oDShift, nShiftID);
                            }
                            else
                            {
                                dLoginTime = GetShift(_oDShift, oEmployee.ShiftID);
                            }

                            //dTimeIn = oAttendDatas[0].PunchTime;
                            dTimeIn = Convert.ToDateTime(attendata[1]);
                            oAttendInfo.TimeIn = dTimeIn;
                            if (bIsHoliday || bIsLeave || bIsOutSationLeave)
                            {
                                //Holiday & Leave
                                if (bIsHoliday) oAttendInfo.Status = Dictionary.HRAttendanceStatus.Holiday;
                                if (bIsLeave) oAttendInfo.Status = Dictionary.HRAttendanceStatus.Leave;
                                if (bIsOutSationLeave) oAttendInfo.Status = Dictionary.HRAttendanceStatus.OutStation;
                            }
                            else
                            {
                                TimeSpan o = new TimeSpan(dLoginTime.Hour, dLoginTime.Minute, 0);
                                if (o < dTimeIn.Subtract(dTimeIn.Date))
                                {
                                    //Late Present
                                    oAttendInfo.Late = dTimeIn.Subtract(dTimeIn.Date) - o;
                                    oAttendInfo.Status = Dictionary.HRAttendanceStatus.Late;
                                }
                                else
                                {
                                    //Present
                                    oAttendInfo.Late = null;
                                    oAttendInfo.Status = Dictionary.HRAttendanceStatus.Present;
                                }
                            }
                            if (nTotalData > 1)
                                //oAttendInfo.TimeOut = oAttendDatas[oAttendDatas.Count - 1].PunchTime;
                                oAttendInfo.TimeOut = Convert.ToDateTime(attendata[2]);

                        }
                        else
                        {
                            if (bIsHoliday || bIsLeave || bIsOutSationLeave)
                            {
                                //Holiday & Leave
                                if (bIsHoliday) oAttendInfo.Status = Dictionary.HRAttendanceStatus.Holiday;
                                if (bIsLeave) oAttendInfo.Status = Dictionary.HRAttendanceStatus.Leave;
                                if (bIsOutSationLeave) oAttendInfo.Status = Dictionary.HRAttendanceStatus.OutStation;
                            }
                            else
                            {
                                //Absent
                                oAttendInfo.Status = Dictionary.HRAttendanceStatus.Absent;
                            }
                        }
                        oAttendInfo.PunchCount = nTotalData;


                        oAttendInfo.Remarks = "Test";
                        oAttendInfo.Delete();
                        oAttendInfo.Add();
                        pbEmployee.PerformStep();

                        nCount++;
                    }
                    pbDate.PerformStep();
                }

                
            }
            catch (Exception ex)
            {
                throw (ex);
               
            }
            return nCount;
            #endregion
        }

        private bool CheckHolyday(DSAttendance oDSHolyday, int nCompanyID, DateTime dDate)
        {
            DataRow[] oDR = oDSHolyday.Holyday.Select(" CompanyID= '" + nCompanyID + "' and FromDate= '" + dDate + "'");

            int nCount = 0;
            try
            {
                nCount = oDR.Length;
            }
            catch
            {
                nCount = 0;
            }

            if (nCount != 0)
                return true;
            else return false;
        }
        private bool CheckLeave(DSAttendance oDSLeave, int nEmployeeID, DateTime dDate)
        {
            DataRow[] oDR = oDSLeave.Holyday.Select(" EmployeeID= '" + nEmployeeID + "' and FromDate <= '" + dDate + "' and ToDate >= '" + dDate + "'");

            int nCount = 0;
            try
            {
                nCount = oDR.Length;
            }
            catch
            {
                nCount = 0;
            }

            if (nCount != 0)
                return true;
            else return false;
        }

        private bool CheckOutstation(DSAttendance oDSOutstation, int nEmployeeID, DateTime dDate)
        {
            DataRow[] oDR = oDSOutstation.Holyday.Select(" EmployeeID= '" + nEmployeeID + "' and FromDate <= '" + dDate + "' and ToDate >= '" + dDate + "'");

            int nCount = 0;
            try
            {
                nCount = oDR.Length;
            }
            catch
            {
                nCount = 0;
            }

            if (nCount != 0)
                return true;
            else return false;
        }

        private string[] GetAttendance(DSAttendance oDSAttendance, int nEmployeeID, DateTime dDate)
        {
            DataRow[] oDR = oDSAttendance.Holyday.Select(" EmployeeID= '" + nEmployeeID + "' and FromDate = '" + dDate + "'");
            string[] array;
            array = new string[3];
            int nCount = 0;
            try
            {
                nCount = oDR.Length;
                DataRow FristRow = oDR[0];
                string sInTime = FristRow["ToDate"].ToString();
                string sOutTime = "";

                array[0] = oDR.Length.ToString();
                array[1] = sInTime;

                if (nCount > 0)
                {
                    DataRow LastRow = oDR[nCount - 1];
                    sOutTime = LastRow["ToDate"].ToString();

                    array[2] = sOutTime;
                }

                
            }
            catch
            {
                nCount = 0;
            }

            return array;
        }

        private DateTime GetShift(DSAttendance oDSShift, int nShiftID)
        {
            DataRow[] oDR = oDSShift.Holyday.Select(" ShiftID= '" + nShiftID + "'");

            DateTime dInTime = new DateTime();
            try
            {
                DataRow FristRow = oDR[0];
                dInTime = Convert.ToDateTime(FristRow["FromDate"]);
            }
            catch
            {
                
            }

            return dInTime;
        }

        public void DeleteAll(DateTime dFromDate, DateTime dTodate, int nCompanyID, int nDepartmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_HRAttendInfo WHERE PunchDate BETWEEN ? AND ?";
                cmd.Parameters.AddWithValue("FromDate", dFromDate);
                cmd.Parameters.AddWithValue("ToDate", dTodate);
                string sClause = "";

                //if (nCompanyID != 0)
                //{
                //    sClause = " AND CompanyID=?";
                //    cmd.Parameters.AddWithValue("CompanyID", nCompanyID);
                //}

                //if (nDepartmentID != 0)
                //{
                //    sClause = sClause + " AND DepartmentID=?";
                //    cmd.Parameters.AddWithValue("DepartmentID", nDepartmentID);
                //}

                cmd.CommandText = sSql + sClause;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByEmployeeWise(DateTime dFromDate, DateTime dToDate,  int nStatus, int nEmployeeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "SELECT * FROM t_HRAttendInfo A"
            //    + " INNER JOIN v_EmployeeDetails B ON A.EmployeeID=B.EmployeeID And B.EmployeeID=? "
            //    + " WHERE PunchDate BETWEEN ? AND ?";

            //string sSql = "Select EmployeeID,PunchDate,CompanyID,DepartmentID,TimeIn,TimeOut,PunchCount,Status,DATEDIFF(HOUR, MIN(FirstTime), MAX(LastTime)) Totalhour,Late from( " +
            //                "Select EmployeeID, PunchDate,CompanyID,DepartmentID, TimeIn, TimeOut, PunchCount, Status, " +
            //                "Min(FirstTime)FirstTime, Max(LastTime)LastTime,Late from( " +
            //                "SELECT a.EmployeeID EmployeeID,CompanyID,DepartmentID, PunchDate, TimeIn, TimeOut, PunchCount, Status, Convert(Time, TimeIn) as FirstTime, " +
            //                "Convert(Time, TimeOut) as LastTime,Late " +
            //                "FROM t_HRAttendInfo A INNER JOIN v_EmployeeDetails B ON A.EmployeeID = B.EmployeeID " +
            //                "And B.EmployeeID = ?  WHERE PunchDate BETWEEN ? and ?)A " +
            //                "group by EmployeeID, PunchDate,CompanyID,DepartmentID, TimeIn, TimeOut, PunchCount, Status,Late)A " +
            //                "group by EmployeeID, PunchDate,CompanyID,DepartmentID, TimeIn, TimeOut, PunchCount, Status,Late";

            //string sSql = "SELECT a.EmployeeID,CompanyID,DepartmentID,PunchDate,TimeIn,TimeOut,PunchCount,Status,Late,SUM(DATEDIFF(minute,TimeIn,TimeOut)) as TotalMinutes," +
            //                "LEFT(CONVERT(VARCHAR(10), max(TimeOut) - min(TimeIn), 108), 5)Totalhour,FORMAT(PunchDate, 'dddd') AS Date " +
            //                "FROM t_HRAttendInfo A INNER JOIN v_EmployeeDetails B ON A.EmployeeID = B.EmployeeID " +
            //                "And B.EmployeeID = ?  WHERE PunchDate BETWEEN ? and ? " +
            //                "Group By a.EmployeeID,CompanyID,DepartmentID,PunchDate,TimeIn,TimeOut,PunchCount,Status,Late";

            //string sSql = "SELECT a.EmployeeID,CompanyID,DepartmentID,PunchDate,TimeIn,TimeOut,PunchCount,Status,Late,SUM(DATEDIFF(minute,TimeIn,TimeOut)) as TotalMinutes," +
            //                "CONCAT((DATEDIFF(Minute,TimeIn,[TimeOut])/60),':',(DATEDIFF(Minute,TimeIn,[TimeOut])%60)) TotalHour,FORMAT(PunchDate, 'dddd') AS Date, " +
            //                "CASE WHEN FORMAT(PunchDate, 'dddd')='Saturday' then ( select  CONCAT(CASE WHEN SIGN(diff) = -1 THEN '-' END " +
            //                ", FORMAT(ABS(diff/60), '0#'), ':', FORMAT(ABS(diff%60), '0#')) diff FROM    ( " +
            //                "SELECT   DATEDIFF(MINUTE, '4:00', LEFT(CONVERT(VARCHAR(10), max(TimeOut) - min(TimeIn), 108), 5)) diff) D) else " +
            //                "( select  CONCAT(CASE WHEN SIGN(diff) = -1 THEN '-' END, FORMAT(ABS(diff/60), '0#'), ':', FORMAT(ABS(diff%60), '0#')) diff " +
            //                "FROM (SELECT   DATEDIFF(MINUTE, '8:00', LEFT(CONVERT(VARCHAR(10), max(TimeOut) - min(TimeIn), 108), 5)) diff ) D) end as LessExtraTime " +
            //                "FROM t_HRAttendInfo A INNER JOIN v_EmployeeDetails B ON A.EmployeeID = B.EmployeeID " +
            //                "And B.EmployeeID = ?  WHERE PunchDate BETWEEN ? and ? " +
            //                "Group By a.EmployeeID,CompanyID,DepartmentID,PunchDate,TimeIn,TimeOut,PunchCount,Status,Late";

            string sSql = "Select a.EmployeeID,CompanyID,DepartmentID,PunchDate,TimeIn,TimeOut,PunchCount,Status,Late, " +
                            "TotalMinutes,TotalHour,Date, " +
                            "CASE WHEN Extraminuite < 0 THEN '-' ELSE '' END " +
                            "+ CONVERT(VARCHAR(8), DATEADD( MINUTE, ABS(ISNULL( Extraminuite, 0 ) ), '00:00:00'), 108 )LessExtraTime from " +
                            "(SELECT a.EmployeeID, CompanyID, DepartmentID, PunchDate, TimeIn, TimeOut, PunchCount, Status, Late, " +
                            "SUM(DATEDIFF(minute, TimeIn, TimeOut)) as TotalMinutes, " +
                            "CONCAT(cast((DATEDIFF(Minute, TimeIn,[TimeOut]) / 60) as varchar(2)), ':', " +
                            "RIGHT('00' + cast((DATEDIFF(Minute, TimeIn,[TimeOut]) % 60) as varchar(2)), 2)) TotalHour, " +

                            "CASE when FORMAT(PunchDate, 'dddd') = 'Saturday' then SUM(DATEDIFF(minute, TimeIn, TimeOut)) - 240 else " +
                            "SUM(DATEDIFF(minute, TimeIn, TimeOut)) - 480 end as Extraminuite, " +
                            "FORMAT(PunchDate, 'dddd') AS Date " +
 

                             "FROM t_HRAttendInfo A INNER JOIN v_EmployeeDetails B ON A.EmployeeID = B.EmployeeID " +
                             "And B.EmployeeID = ?  WHERE PunchDate BETWEEN ? and ? " +
                             "Group By a.EmployeeID, CompanyID, DepartmentID, PunchDate, TimeIn, TimeOut, PunchCount, Status, Late)A";

            cmd.Parameters.AddWithValue("EmployeeID", nEmployeeID);
            cmd.Parameters.AddWithValue("FromDate", dFromDate);
            cmd.Parameters.AddWithValue("ToDate", dToDate);
            string sClause = "";         

            if (nStatus > -1)
            {
                sClause = sClause + " WHERE Status=?";
                cmd.Parameters.AddWithValue("Status", nStatus);
            }
        
            cmd.CommandText = sSql + sClause + " ORDER BY CompanyID, DepartmentID, A.EmployeeID";
            cmd.CommandType = CommandType.Text;
            GetDataByEmployeeWise(cmd);

        }
        private void GetDataByEmployeeWise(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AttendInfo oAttendInfo = new AttendInfo();
                    
                    oAttendInfo.PunchDate = (DateTime)reader["PunchDate"];
                    if (reader["TimeIn"] is DBNull)
                    {
                        oAttendInfo.TimeIn = null;
                    }
                    else
                    {
                        oAttendInfo.TimeIn = (DateTime)reader["TimeIn"];
                    }

                    if (reader["TimeOut"] is DBNull)
                    {
                        oAttendInfo.TimeOut = null;
                    }
                    else
                    {
                        oAttendInfo.TimeOut = (DateTime)reader["TimeOut"];
                    }                    
                    if (reader["Late"] is DBNull)
                    {
                        oAttendInfo.Late = null;
                    }
                    else
                    {
                        oAttendInfo.Late = (DateTime)reader["Late"];
                    }
                    if (reader["TotalHour"] is DBNull)
                    {
                        oAttendInfo.TotalHour = "";
                    }
                    else
                    {
                        oAttendInfo.TotalHour = (string)reader["TotalHour"];
                    }
                    oAttendInfo.Date = (string)reader["Date"];
                    oAttendInfo.PunchCount = (int)reader["PunchCount"];
                    oAttendInfo.Status = (Dictionary.HRAttendanceStatus)reader["Status"];
                    if (reader["LessExtraTime"] is DBNull)
                    {
                        oAttendInfo.LessExtraTime = "";
                    }
                    else
                    {
                        oAttendInfo.LessExtraTime = reader["LessExtraTime"];
                    }
                    InnerList.Add(oAttendInfo);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDate(DateTime dtCDate)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From  "+
                        " (Select EmployeeID,'" + dtCDate + "' as Date,  " +
                        " '[' + EmployeeCode + ']' + ' ' + EmployeeName as EmployeeName  "+
                        " From t_Employee where Status in (1,2)) Main where Date not in (  " +
                        " Select Date From t_OutletAttendanceInfo)";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AttendInfo oAttendInfo = new AttendInfo();

                    oAttendInfo.EmployeeID = Convert.ToInt32(reader["EmployeeID"].ToString());
                    oAttendInfo.EmployeeName = (string)reader["EmployeeName"];
                    oAttendInfo.PunchDate = Convert.ToDateTime(reader["Date"].ToString());

                    InnerList.Add(oAttendInfo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDataForPOS(DateTime dFromDate, DateTime dToDate, string sEmpCode, string sEmpName, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = " Select a.*,EmployeeCode,EmployeeName  "+
                       " From t_OutletAttendanceInfo a,t_Employee b  " +
                       " where a.EmployeeID=b.EmployeeID  ";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND Date between '" + dFromDate + "' and '" + dToDate + "' and Date<'" + dToDate + "' ";
            }

            if (sEmpCode != "")
            {
                sSql = sSql + " AND EmployeeCode like '%" + sEmpCode + "%'";
            }
            if (sEmpName != "")
            {
                sSql = sSql + " AND EmployeeName like '%" + sEmpName + "%'";
            }
            sSql = sSql + " Order by Date Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AttendInfo oAttendInfo = new AttendInfo();

                    oAttendInfo.ID = (int)reader["ID"];
                    oAttendInfo.EmployeeID = (int)reader["EmployeeID"];
                    oAttendInfo.EmployeeCode = (string)reader["EmployeeCode"];
                    oAttendInfo.EmployeeName = (string)reader["EmployeeName"];
                    oAttendInfo.PunchDate = (DateTime)reader["Date"];
                    if (reader["TimeIn"] is DBNull)
                    {
                        oAttendInfo.TimeIn = null;
                    }
                    else
                    {
                        oAttendInfo.TimeIn = (DateTime)reader["TimeIn"];
                    }

                    if (reader["TimeOut"] is DBNull)
                    {
                        oAttendInfo.TimeOut = null;
                    }
                    else
                    {
                        oAttendInfo.TimeOut = (DateTime)reader["TimeOut"];
                    }
                    oAttendInfo.AttendanceStatus = (int)reader["Status"];

                    InnerList.Add(oAttendInfo);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }
}
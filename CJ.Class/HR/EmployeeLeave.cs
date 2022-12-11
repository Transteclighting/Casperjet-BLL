// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 15, 2011
// Time :  12:00 PM
// Description: Class for EmployeeLeave.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Class
{
    public class EmployeeLeave
    {
        private int _nLeaveID;
        private int _nEmployeeID;
        private int _nLeaveType;
        private DateTime _dLeaveStartDate;
        private DateTime _dLeaveEndDate;
        private DateTime _dEntryDate;
        private string _sReason;
        private double _nPrposed;
        private double _nUtilizedTillDate;
        private double _nTotalutilized;
        private int _nLeaveAllowed;
        private int _nDiffDate;
        private int _nNoOfSatDay;
        private int _nNoOfFRIDay;
        private int _nNoOfHoliday;

        private int _nInChargeID;
        private string _sAddress;
        private string _sMobileNo;
        private string _sEmailaddress;
        private int _nStatus;
        private double _LeaveTotal;
        private int _nPartialType;
        private int _nCreateUserID;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nApprovedUserID;
        private DateTime _dApprovedDate;
        private int _nRejectUserID;
        private DateTime _dRejectDate;
        private int _nLineManagerID;

        private int _nIsTemp;
        private int _nPriority;
        private double _Balance;
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        // <summary>
        // Get set property for Priority
        // </summary>
        public int Priority
        {
            get { return _nPriority; }
            set { _nPriority = value; }
        }

        // <summary>
        // Get set property for IsTemp
        // </summary>
        public int IsTemp
        {
            get { return _nIsTemp; }
            set { _nIsTemp = value; }
        }

        // <summary>
        // Get set property for LineManagerID
        // </summary>
        public int LineManagerID
        {
            get { return _nLineManagerID; }
            set { _nLineManagerID = value; }
        }


        // <summary>
        // Get set property for InChargeID
        // </summary>
        public int InChargeID
        {
            get { return _nInChargeID; }
            set { _nInChargeID = value; }
        }

        // <summary>
        // Get set property for Address
        // </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }

        // <summary>
        // Get set property for MobileNo
        // </summary>
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Emailaddress
        // </summary>
        public string EmailAddress
        {
            get { return _sEmailaddress; }
            set { _sEmailaddress = value.Trim(); }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for LeaveTotal
        // </summary>
        public double LeaveTotal
        {
            get { return _LeaveTotal; }
            set { _LeaveTotal = value; }
        }

        // <summary>
        // Get set property for PartialType
        // </summary>
        public int PartialType
        {
            get { return _nPartialType; }
            set { _nPartialType = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for ApprovedUserID
        // </summary>
        public int ApprovedUserID
        {
            get { return _nApprovedUserID; }
            set { _nApprovedUserID = value; }
        }

        // <summary>
        // Get set property for ApprovedDate
        // </summary>
        public DateTime ApprovedDate
        {
            get { return _dApprovedDate; }
            set { _dApprovedDate = value; }
        }

        // <summary>
        // Get set property for RejectUserID
        // </summary>
        public int RejectUserID
        {
            get { return _nRejectUserID; }
            set { _nRejectUserID = value; }
        }

        // <summary>
        // Get set property for RejectDate
        // </summary>
        public DateTime RejectDate
        {
            get { return _dRejectDate; }
            set { _dRejectDate = value; }
        }

        /// <summary>
        /// Get set property for _nNoOfHoliday
        /// </summary>
        public int NoOfHoliday
        {
            get { return _nNoOfHoliday; }
            set { _nNoOfHoliday = value; }
        }

        /// <summary>
        /// Get set property for NoOfFRIDay
        /// </summary>
        public int NoOfFRIDay
        {
            get { return _nNoOfFRIDay; }
            set { _nNoOfFRIDay = value; }
        }

        /// <summary>
        /// Get set property for NoOfSatDay
        /// </summary>
        public int NoOfSatDay
        {
            get { return _nNoOfSatDay; }
            set { _nNoOfSatDay = value; }
        }

        /// <summary>
        /// Get set property for DiffDate
        /// </summary>
        public int DiffDate
        {
            get { return _nDiffDate; }
            set { _nDiffDate = value; }
        }

        private Employee _oEmployee;

        /// <summary>
        /// Get set property for LeaveID
        /// </summary>
        public int LeaveID
        {
            get { return _nLeaveID; }
            set { _nLeaveID = value; }
        }

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
                    _oEmployee.Refresh();
                }

                return _oEmployee;
            }
        }

        /// <summary>
        /// Get set property for LeaveType
        /// </summary>
        public int LeaveType
        {
            get { return _nLeaveType; }
            set { _nLeaveType = value; }
        }

        /// <summary>
        /// Get set property for LeaveStartDate
        /// </summary>
        public DateTime LeaveStartDate
        {
            get { return _dLeaveStartDate; }
            set { _dLeaveStartDate = value; }
        }

        /// <summary>
        /// Get set property for LeaveEndDate
        /// </summary>
        public DateTime LeaveEndDate
        {
            get { return _dLeaveEndDate; }
            set { _dLeaveEndDate = value; }
        }

        /// <summary>
        /// Get set property for EntryDate
        /// </summary>
        public DateTime EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
        }

        /// <summary>
        /// Get set property for Reason
        /// </summary>
        public string Reason
        {
            get { return _sReason; }
            set { _sReason = value.Trim(); }
        }

        public double Prposed
        {
            get { return _nPrposed; }
            set { _nPrposed = value; }
        }
        public double UtilizedTillDate
        {
            get { return _nUtilizedTillDate; }
            set { _nUtilizedTillDate = value; }
        }
        public double Totalutilized
        {
            get { return _nTotalutilized; }
            set { _nTotalutilized = value; }
        }
        public int LeaveAllowed
        {
            get { return _nLeaveAllowed; }
            set { _nLeaveAllowed = value; }
        }
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
        private string _sCompanyCode;
        public string CompanyCode
        {
            get { return _sCompanyCode; }
            set { _sCompanyCode = value.Trim(); }
        }
        private string _sDepartmentCode;
        public string DepartmentCode
        {
            get { return _sDepartmentCode; }
            set { _sDepartmentCode = value.Trim(); }
        }
        private string _sDepartmentName;
        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value.Trim(); }
        }

        private string _sDesignationName;
        public string DesignationName
        {
            get { return _sDesignationName; }
            set { _sDesignationName = value.Trim(); }
        }
        private string _sLeaveTypeName;
        public string LeaveTypeName
        {
            get { return _sLeaveTypeName; }
            set { _sLeaveTypeName = value.Trim(); }
        }
        private string _sDays;
        public string Days
        {
            get { return _sDays; }
            set { _sDays = value.Trim(); }
        }

        private double _nEarnLeave;
        public double EarnLeave
        {
            get { return _nEarnLeave; }
            set { _nEarnLeave = value; }
        }
        private double _nEarnLeaveApplied;
        public double EarnLeaveApplied
        {
            get { return _nEarnLeaveApplied; }
            set { _nEarnLeaveApplied = value; }
        }
        private double _nCasualLeaveApplied;
        public double CasualLeaveApplied
        {
            get { return _nCasualLeaveApplied; }
            set { _nCasualLeaveApplied = value; }
        }

        private double _nSickLeaveApplied;
        public double SickLeaveApplied
        {
            get { return _nSickLeaveApplied; }
            set { _nSickLeaveApplied = value; }
        }
        private string _nRejectReason;
        public string RejectReason
        {
            get { return _nRejectReason; }
            set { _nRejectReason = value; }
        }
        
        private double _nLeaveApproved;
        public double LeaveApproved
        {
            get { return _nLeaveApproved; }
            set { _nLeaveApproved = value; }
        }
        private int _nEarnLeaveAdjustment;
        public int EarnLeaveAdjustment
        {
            get { return _nEarnLeaveAdjustment; }
            set { _nEarnLeaveAdjustment = value; }
        }
        private double _nEarnLeaveRemain;
        public double EarnLeaveRemain
        {
            get { return _nEarnLeaveRemain; }
            set { _nEarnLeaveRemain = value; }
        }
        private double _nCasualLeaveRemain;
        public double CasualLeaveRemain
        {
            get { return _nCasualLeaveRemain; }
            set { _nCasualLeaveRemain = value; }
        }
        private double _nSickLeaveRemain;
        public double SickLeaveRemain
        {
            get { return _nSickLeaveRemain; }
            set { _nSickLeaveRemain = value; }
        }

        public void Add()
        {
            int nMaxLeaveID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([LeaveID]) FROM t_EmployeeLeave";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLeaveID = 1;
                }
                else
                {
                    nMaxLeaveID = Convert.ToInt32(maxID) + 1;
                }
                _nLeaveID = nMaxLeaveID;

                sSql = "INSERT INTO t_EmployeeLeave(LeaveID,EmployeeID,LeaveType,"
                    + "LeaveStartDate,LeaveEndDate,EntryDate,Reason) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeaveID", _nLeaveID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("LeaveType", _nLeaveType);
                cmd.Parameters.AddWithValue("LeaveStartDate", _dLeaveStartDate);
                cmd.Parameters.AddWithValue("LeaveEndDate", _dLeaveEndDate);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);
                cmd.Parameters.AddWithValue("Reason", _sReason);
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

                sSql = "UPDATE t_EmployeeLeave SET EmployeeID=?,LeaveType=?,"
                    + "LeaveStartDate=?,LeaveEndDate=?,EntryDate=?,Reason=?"
                    + " WHERE LeaveID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("LeaveType", _nLeaveType);
                cmd.Parameters.AddWithValue("LeaveStartDate", _dLeaveStartDate);
                cmd.Parameters.AddWithValue("LeaveEndDate", _dLeaveEndDate);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("LeaveID", _nLeaveID);

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
                sSql = "DELETE FROM t_EmployeeLeaveTemp WHERE [LeaveID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeaveID", _nLeaveID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public void GetLeaveBalance(int nEmployeeID, int nLeaveType, int nSYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int EYear = nSYear + 1;
            try
            {
                cmd.CommandText = "Select LeaveType,LeaveAllowed-Totalutilized as Balance From  " +
                                " (Select x.*,isnull(UtilizedTillDate,0) UtilizedTillDate,   " +
                                " isnull(UtilizedTillDate,0) as Totalutilized From    " +
                                " (Select * From   " +
                                " (Select EmployeeID,LeaveType,LeaveTypename,  " +
                                " LeaveAllowed from t_leave a,t_Employee b where LeaveType in (0,2)  " +
                                " Union All  " +
                                " Select EmployeeID,LeaveType,LeaveTypename,  " +
                                " LeaveAllowed=Case when EMPStatus=2 and TotalConfirmDate>=365 then LeaveAllowed   " +
                                " when EMPStatus<>2 then 0 else 30 end From   " +
                                " (Select EmployeeID,LeaveType,LeaveTypename,LeaveAllowed,EMPStatus,  " +
                                " DATEDIFF(day,ConfirmDate,Getdate()) TotalConfirmDate  " +
                                " from t_leave a,t_Employee b where LeaveType=1) x  " +
                                " Union All  " +
                                " Select EmployeeID,LeaveType,LeaveTypename,  " +
                                " LeaveAllowed=Case when Gender='Female' then LeaveAllowed else 0 end  " +
                                " from t_leave a,t_Employee b where  LeaveType=3  " +
                                " Union All  " +
                                " Select EmployeeID,LeaveType,LeaveTypename,  " +
                                " LeaveAllowed=Case when Gender='Male' and EMPStatus=2 then LeaveAllowed else 0 end  " +
                                " from t_leave a,t_Employee b where LeaveType=4) Main    " +
                                " where EmployeeID= " + nEmployeeID + " and LeaveAllowed>0) x   " +
                                " Left Outer join    " +
                                " (Select LeaveType, Sum(CASE when Status=2 then LeaveTotal else 0 end) as UtilizedTillDate    " +
                                " from t_EmployeeLeave Where EmployeeID=" + nEmployeeID + " and    " +
                                " LeaveStartDate >='01-Mar-" + nSYear + "' and Status in (2) and    " +
                                " LeaveEndDate < '01-Mar-" + EYear + "' group by LeaveType) z   " +
                                " on x.LeaveType=z.LeaveType) Main where LeaveType=" + nLeaveType + " and EmployeeID=" + nEmployeeID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Balance = (double)reader["Balance"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLeaveBalanceStuff(int nEmployeeID, int nLeaveType, int nSYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int EYear = nSYear + 1;
            try
            {
                cmd.CommandText = "Select LeaveType,LeaveAllowed-Totalutilized as Balance From  " +
                                " (Select x.*,isnull(UtilizedTillDate,0) UtilizedTillDate,   " +
                                " isnull(UtilizedTillDate,0) as Totalutilized From    " +
                                " (Select * From   " +
                                " (Select EmployeeID,LeaveType,LeaveTypename,  " +
                                " LeaveAllowed from t_leaveStuff a,t_Employee b where LeaveType in (0,2)  " +
                                " Union All  " +
                                " Select EmployeeID,LeaveType,LeaveTypename,  " +
                                " LeaveAllowed=Case when EMPStatus=2 and TotalConfirmDate>=365 then LeaveAllowed   " +
                                " when EMPStatus<>2 then 0 else 30 end From   " +
                                " (Select EmployeeID,LeaveType,LeaveTypename,LeaveAllowed,EMPStatus,  " +
                                " DATEDIFF(day,ConfirmDate,Getdate()) TotalConfirmDate  " +
                                " from t_leaveStuff a,t_Employee b where LeaveType=1) x  " +
                                " Union All  " +
                                " Select EmployeeID,LeaveType,LeaveTypename,  " +
                                " LeaveAllowed=Case when Gender='Female' then LeaveAllowed else 0 end  " +
                                " from t_leaveStuff a,t_Employee b where  LeaveType=3  " +
                                " Union All  " +
                                " Select EmployeeID,LeaveType,LeaveTypename,  " +
                                " LeaveAllowed=Case when Gender='Male' and EMPStatus=2 then LeaveAllowed else 0 end  " +
                                " from t_leaveStuff a,t_Employee b where LeaveType=4) Main    " +
                                " where EmployeeID= " + nEmployeeID + " and LeaveAllowed>0) x   " +
                                " Left Outer join    " +
                                " (Select LeaveType, Sum(CASE when Status=2 then LeaveTotal else 0 end) as UtilizedTillDate    " +
                                " from t_EmployeeLeave Where EmployeeID=" + nEmployeeID + " and    " +
                                " LeaveStartDate >='01-Jan-" + nSYear + "' and Status in (2) and    " +
                                " LeaveEndDate < '01-Jan-" + EYear + "' group by LeaveType) z   " +
                                " on x.LeaveType=z.LeaveType) Main where LeaveType=" + nLeaveType + " and EmployeeID=" + nEmployeeID + "";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Balance = (double)reader["Balance"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_EmployeeLeave where LeaveID =?";
                cmd.Parameters.AddWithValue("LeaveID", _nLeaveID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLeaveID = (int)reader["LeaveID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nLeaveType = (int)reader["LeaveType"];
                    _dLeaveStartDate = (DateTime)reader["LeaveStartDate"];
                    _dLeaveEndDate = (DateTime)reader["LeaveEndDate"];
                    _dEntryDate = (DateTime)reader["EntryDate"];
                    _sReason = (string)reader["Reason"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetPriority(int nEmployeeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select max(Priority) Priority  " +
                                  "From t_EmployeeLineManager  where EmployeeID=" + nEmployeeID + " and LineManagerType=1";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPriority = (int)reader["Priority"];

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool IsLeave(DateTime dDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_EmployeeLeave"
                    + " WHERE EmployeeID =? AND LeaveStartDate<=? AND LeaveeNDDate>=?";
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("Date", dDate.Date);
                cmd.Parameters.AddWithValue("Date", dDate.Date);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) nCount++;
                reader.Close();
                return nCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshDiffDate(DateTime FromDate, DateTime ToDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT DATEDIFF(day,'" + FromDate + "','" + ToDate + "') AS DiffDate";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDiffDate = (int)reader["DiffDate"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetNoofSATDay(DateTime FromDate, DateTime ToDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT datediff(day, -2, '" + ToDate + "')/7-datediff(day, -1, '" + FromDate + "')/7 AS SAT";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nNoOfSatDay = (int)reader["SAT"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetNoofFRIDay(DateTime FromDate, DateTime ToDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT datediff(day, -3, '" + ToDate + "')/7-datediff(day, -2, '" + FromDate + "')/7 AS FRI";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nNoOfFRIDay = (int)reader["FRI"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetNoofHoliday(DateTime FromDate, DateTime ToDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            ToDate = ToDate.AddDays(1);
            try
            {
                cmd.CommandText = "  Select Count(Holiday) NoOfHoliday From " +
                                 " (SELECT distinct Holiday FROM dbo.t_HRHoliday where Holiday between '" + FromDate + "' and '" + ToDate + "' and Holiday < '" + ToDate + "') x";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nNoOfHoliday = (int)reader["NoOfHoliday"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Approved()
        {
            int nMaxLeaveID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LeaveID]) FROM t_EmployeeLeave";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLeaveID = 1;
                }
                else
                {
                    nMaxLeaveID = Convert.ToInt32(maxID) + 1;
                }
                _nLeaveID = nMaxLeaveID;
                sSql = "INSERT INTO t_EmployeeLeave (LeaveID, EmployeeID, InChargeID, LeaveType, LeaveStartDate, LeaveEndDate, EntryDate, Reason, Address, MobileNo, Emailaddress, Status, LeaveTotal, PartialType, CreateUserID, UpdateUserID, UpdateDate, ApprovedUserID, ApprovedDate, RejectUserID, RejectDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LeaveID", _nLeaveID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("InChargeID", _nInChargeID);
                cmd.Parameters.AddWithValue("LeaveType", _nLeaveType);
                cmd.Parameters.AddWithValue("LeaveStartDate", _dLeaveStartDate);
                cmd.Parameters.AddWithValue("LeaveEndDate", _dLeaveEndDate);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("Emailaddress", _sEmailaddress);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("LeaveTotal", _LeaveTotal);
                cmd.Parameters.AddWithValue("PartialType", _nPartialType);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
                cmd.Parameters.AddWithValue("RejectUserID", null);
                cmd.Parameters.AddWithValue("RejectDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatusTemp(int nType)
        {
            string sdate = "";
            string sUserID = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            
            try
            {
                if (nType == (int)Dictionary.LeaveStatus.Approved)
                {
                    sdate = "ApprovedDate";
                    sUserID = "ApprovedUserID";
                }
                else if (nType == (int)Dictionary.LeaveStatus.Reject)
                {
                    sdate = "RejectDate";
                    sUserID = "RejectUserID";

                }

                sSql = "UPDATE t_EmployeeLeaveTemp SET  Status = ?, " + sUserID + " = ?, " + sdate + " = ? WHERE LeaveID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _nStatus);

                if (nType == (int)Dictionary.LeaveStatus.Approved)
                {
                    cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                    cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
                }
                else if (nType == (int)Dictionary.LeaveStatus.Reject)
                {

                    cmd.Parameters.AddWithValue("RejectUserID", _nRejectUserID);
                    cmd.Parameters.AddWithValue("RejectDate", _dRejectDate);
                }

                cmd.Parameters.AddWithValue("LeaveID", _nLeaveID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddTemp()
        {
            int nMaxLeaveID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LeaveID]) FROM t_EmployeeLeaveTemp";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLeaveID = 1;
                }
                else
                {
                    nMaxLeaveID = Convert.ToInt32(maxID) + 1;
                }
                _nLeaveID = nMaxLeaveID;
                sSql = "INSERT INTO t_EmployeeLeaveTemp (LeaveID, EmployeeID, InChargeID, LeaveType, LeaveStartDate, LeaveEndDate, EntryDate, Reason, Address, MobileNo, Emailaddress, Status, LeaveTotal, PartialType, CreateUserID, UpdateUserID, UpdateDate, ApprovedUserID, ApprovedDate, RejectUserID, RejectDate,Priority) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LeaveID", _nLeaveID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("InChargeID", _nInChargeID);
                cmd.Parameters.AddWithValue("LeaveType", _nLeaveType);
                cmd.Parameters.AddWithValue("LeaveStartDate", _dLeaveStartDate);
                cmd.Parameters.AddWithValue("LeaveEndDate", _dLeaveEndDate);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("Emailaddress", _sEmailaddress);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("LeaveTotal", _LeaveTotal);
                cmd.Parameters.AddWithValue("PartialType", _nPartialType);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("RejectUserID", null);
                cmd.Parameters.AddWithValue("RejectDate", null);
                cmd.Parameters.AddWithValue("Priority", _nPriority);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditTemp()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_EmployeeLeaveTemp SET EmployeeID = ?, InChargeID = ?, LeaveType = ?, LeaveStartDate = ?, LeaveEndDate = ?, Reason = ?, Address = ?, MobileNo = ?, Emailaddress = ?, Status = ?, LeaveTotal = ?, PartialType = ?,  UpdateUserID = ?, UpdateDate = ? WHERE LeaveID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                cmd.Parameters.AddWithValue("InChargeID", _nInChargeID);
                cmd.Parameters.AddWithValue("LeaveType", _nLeaveType);
                cmd.Parameters.AddWithValue("LeaveStartDate", _dLeaveStartDate);
                cmd.Parameters.AddWithValue("LeaveEndDate", _dLeaveEndDate);
                cmd.Parameters.AddWithValue("Reason", _sReason);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("Emailaddress", _sEmailaddress);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("LeaveTotal", _LeaveTotal);
                cmd.Parameters.AddWithValue("PartialType", _nPartialType);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);


                cmd.Parameters.AddWithValue("LeaveID", _nLeaveID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteTemp()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_EmployeeLeaveTemp WHERE [LeaveID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeaveID", _nLeaveID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshTemp()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_EmployeeLeaveTemp where LeaveID =?";
                cmd.Parameters.AddWithValue("LeaveID", _nLeaveID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLeaveID = (int)reader["LeaveID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
                    _nInChargeID = (int)reader["InChargeID"];
                    _nLeaveType = (int)reader["LeaveType"];
                    _dLeaveStartDate = Convert.ToDateTime(reader["LeaveStartDate"].ToString());
                    _dLeaveEndDate = Convert.ToDateTime(reader["LeaveEndDate"].ToString());
                    _dEntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    _sReason = (string)reader["Reason"];
                    _sAddress = (string)reader["Address"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _sEmailaddress = (string)reader["Emailaddress"];
                    _nStatus = (int)reader["Status"];
                    _LeaveTotal = Convert.ToDouble(reader["LeaveTotal"].ToString());
                    _nPartialType = (int)reader["PartialType"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nApprovedUserID = (int)reader["ApprovedUserID"];
                    _dApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    _nRejectUserID = (int)reader["RejectUserID"];
                    _dRejectDate = Convert.ToDateTime(reader["RejectDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool RefreshByemployeeLinemanager(int nLineManagerId, int nLeaveEmployeeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_EmployeeLineManager where LineManagerId =? and EmployeeID=?";
                cmd.Parameters.AddWithValue("LineManagerId", nLineManagerId);
                cmd.Parameters.AddWithValue("EmployeeID", nLeaveEmployeeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nEmployeeID = (int)reader["EmployeeId"];
                    _nLineManagerID = (int)reader["LineManagerId"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
    public class EmployeeLeaves : CollectionBase
    {
        public EmployeeLeave this[int i]
        {
            get { return (EmployeeLeave)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(EmployeeLeave oEmployeeLeave)
        {
            InnerList.Add(oEmployeeLeave);
        }

        public int GetIndex(int nLeaveID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].LeaveID == nLeaveID)
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetIndexLeaveType(int nLeaveType)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].LeaveType == nLeaveType)
                {
                    return i;
                }
            }
            return -1;
        }

        public DSAttendance GetLeave(DSAttendance oDSLeave, DateTime dFromDate, DateTime dToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select * from (SELECT LeaveID, EmployeeID, Convert(datetime,replace(convert(varchar, LeaveStartDate,6),'','-'),1)LeaveStartDate, "+
                          " Convert(datetime, replace(convert(varchar, LeaveEndDate, 6), '', '-'), 1)LeaveEndDate "+
                          " FROM t_EmployeeLeave ) a Where LeaveStartDate between '"+ dFromDate + "' and '"+ dToDate + "' or LeaveEndDate between '" + dFromDate + "' and '" + dToDate + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSAttendance.HolydayRow oLeaveRow = oDSLeave.Holyday.NewHolydayRow();

                    oLeaveRow.EmployeeID = (int)reader["EmployeeID"];
                    oLeaveRow.FromDate = (DateTime)reader["LeaveStartDate"];
                    oLeaveRow.ToDate = (DateTime)reader["LeaveEndDate"];

                    oDSLeave.Holyday.AddHolydayRow(oLeaveRow);
                    oDSLeave.AcceptChanges();
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSLeave;
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_EmployeeLeave";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeLeave oEmployeeLeave = new EmployeeLeave();

                    oEmployeeLeave.LeaveID = (int)reader["LeaveID"];
                    oEmployeeLeave.EmployeeID = (int)reader["EmployeeID"];
                    oEmployeeLeave.LeaveType = (int)reader["LeaveType"];
                    oEmployeeLeave.LeaveStartDate = (DateTime)reader["LeaveStartDate"];
                    oEmployeeLeave.LeaveEndDate = (DateTime)reader["LeaveEndDate"];
                    oEmployeeLeave.EntryDate = (DateTime)reader["EntryDate"];
                    oEmployeeLeave.Reason = (string)reader["Reason"];
                    InnerList.Add(oEmployeeLeave);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_EmployeeLeave WHERE LeaveStartDate BETWEEN ? AND ?";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FromDate", dFromDate);
                cmd.Parameters.AddWithValue("ToDate", dToDate);

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeLeave oEmployeeLeave = new EmployeeLeave();

                    oEmployeeLeave.LeaveID = (int)reader["LeaveID"];
                    oEmployeeLeave.EmployeeID = (int)reader["EmployeeID"];
                    oEmployeeLeave.LeaveType = (int)reader["LeaveType"];
                    oEmployeeLeave.LeaveStartDate = (DateTime)reader["LeaveStartDate"];
                    oEmployeeLeave.LeaveEndDate = (DateTime)reader["LeaveEndDate"];
                    oEmployeeLeave.EntryDate = (DateTime)reader["EntryDate"];
                    oEmployeeLeave.Reason = (string)reader["Reason"];
                    InnerList.Add(oEmployeeLeave);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate, string sCode, string sName, int nLeaveType, bool IsCheck)
        {
            InnerList.Clear();
            DateTime _dToDate = dToDate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.*,EmployeeCode, EmployeeName FROM t_EmployeeLeave a, " +
                          "t_Employee b where a.EmployeeID=b.EmployeeID ";

            if (IsCheck == false)
            {
                sSql = sSql + " AND EntryDate BETWEEN '" + dFromDate + "' AND '" + _dToDate + "' AND EntryDate < '" + _dToDate + "' ";
            }
            if (sCode != "")
            {
                sSql = sSql + " AND EmployeeCode ='" + sCode + "'";
            }
            if (sName != "")
            {
                sSql = sSql + " AND EmployeeName like '%" + sName + "%'";
            }
            if (nLeaveType >= 0)
            {
                sSql = sSql + " AND LeaveType = " + nLeaveType + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FromDate", dFromDate);
                cmd.Parameters.AddWithValue("ToDate", dToDate);

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeLeave oEmployeeLeave = new EmployeeLeave();

                    oEmployeeLeave.LeaveID = (int)reader["LeaveID"];
                    oEmployeeLeave.EmployeeID = (int)reader["EmployeeID"];
                    oEmployeeLeave.LeaveType = (int)reader["LeaveType"];
                    oEmployeeLeave.LeaveStartDate = (DateTime)reader["LeaveStartDate"];
                    oEmployeeLeave.LeaveEndDate = (DateTime)reader["LeaveEndDate"];
                    oEmployeeLeave.EntryDate = (DateTime)reader["EntryDate"];
                    oEmployeeLeave.Reason = (string)reader["Reason"];
                    InnerList.Add(oEmployeeLeave);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLeave(DateTime dFromDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select a.EmployeeID, EmployeeCode, EmployeeName, CompanyCode, DepartmentCode, CASE When LeaveType=0 then 'SL' " +
                          "  When LeaveType=1 then 'EL' When LeaveType=2 then 'CL' When LeaveType=3 then 'ML' When LeaveType=4 then 'PL' " +
                          "  When LeaveType=5 then 'LWP' end as LeaveTypeName, LeaveStartDate, LeaveEndDate, (DATEDIFF(day,LeaveStartDate, LeaveEndDate)+1) as Days " +
                          "  from dbo.t_EmployeeLeave a, (select EmployeeID, EmployeeCode, EmployeeName, CompanyID, DepartmentID from t_Employee)b, " +
                          "  (Select CompanyID, CompanyCode from t_Company)c, (Select DepartmentID, DepartmentCode from t_Department)d " +
                          "  Where a.EmployeeID=b.EmployeeID and b.CompanyID=c.CompanyID and b.DepartmentID=d.DepartmentID " +
                          "  and LeaveStartDate > '" + dFromDate + "' Order by CompanyCode, DepartmentCode, EmployeeName, LeaveType ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeLeave oEmployeeLeave = new EmployeeLeave();

                    oEmployeeLeave.EmployeeID = (int)reader["EmployeeID"];
                    oEmployeeLeave.EmployeeCode = (string)reader["EmployeeCode"];
                    oEmployeeLeave.EmployeeName = (string)reader["EmployeeName"];
                    oEmployeeLeave.CompanyCode = (string)reader["CompanyCode"];
                    oEmployeeLeave.DepartmentCode = (string)reader["DepartmentCode"];
                    oEmployeeLeave.LeaveTypeName = (string)reader["LeaveTypeName"];
                    oEmployeeLeave.LeaveStartDate = Convert.ToDateTime(reader["LeaveStartDate"]);
                    oEmployeeLeave.LeaveEndDate = Convert.ToDateTime(reader["LeaveEndDate"]);
                    oEmployeeLeave.Days = Convert.ToString(reader["Days"]);

                    InnerList.Add(oEmployeeLeave);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLeaveByEmployee(int nEmployeeID)
        {

            DateTime CurrentDate = DateTime.Today.Date;

            int nMonth = CurrentDate.Month;
            int nYear = CurrentDate.Year;
            int nNextYear = nYear + 1;
            int nStartYear;

            if (nMonth == 1 || nMonth == 2)
            {
                nStartYear = nYear - 1;
            }
            else
            {
                nStartYear = nYear;
            }

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select x.*,isnull(Prposed,0) Prposed,isnull(UtilizedTillDate,0) UtilizedTillDate, " +
                            " isnull(Prposed,0) + isnull(UtilizedTillDate,0) as Totalutilized From  " +
                            " (Select * From  " +
                            " (Select EmployeeID,LeaveType,LeaveTypename,  " +
                            " LeaveAllowed from t_leave a,t_Employee b where LeaveType in (0,2)  " +
                            " Union All  " +
                            " Select EmployeeID,LeaveType,LeaveTypename,  " +
                            " LeaveAllowed=Case when EMPStatus=2 and TotalConfirmDate>=365 then LeaveAllowed   " +
                            " when EMPStatus<>2 then 0 else 30 end From   " +
                            " (Select EmployeeID,LeaveType,LeaveTypename,LeaveAllowed,EMPStatus,  " +
                            " DATEDIFF(day,ConfirmDate,Getdate()) TotalConfirmDate  " +
                            " from t_leave a,t_Employee b where LeaveType=1) x  " +
                            " Union All  " +
                            " Select EmployeeID,LeaveType,LeaveTypename,  " +
                            " LeaveAllowed=Case when Gender='Female' then LeaveAllowed else 0 end  " +
                            " from t_leave a,t_Employee b where  LeaveType=3  " +
                            " Union All  " +
                            " Select EmployeeID,LeaveType,LeaveTypename,  " +
                            " LeaveAllowed=Case when Gender='Male' and EMPStatus=2 then LeaveAllowed else 0 end  " +
                            " from t_leave a,t_Employee b where LeaveType=4) Main    " +
                            " where EmployeeID=" + nEmployeeID + " and LeaveAllowed>0  " +
                            " ) x " +
                            " Left Outer join  " +
                            " (Select LeaveType, Sum(CASE when Status in (1,5,6) then LeaveTotal else 0 end) as Prposed " +
                            " from t_EmployeeLeaveTemp Where EmployeeID=" + nEmployeeID + " and  " +
                            " LeaveStartDate >='01-Mar-" + nStartYear + "' and Status not in (2,3,4) and  " +
                            " LeaveEndDate < '01-Mar-" + nNextYear + "' group by LeaveType) y " +
                            " on x.LeaveType=y.LeaveType " +
                            " Left Outer Join  " +
                            " (Select LeaveType, Sum(CASE when Status=2 then LeaveTotal else 0 end) as UtilizedTillDate  " +
                            " from t_EmployeeLeave Where EmployeeID=" + nEmployeeID + " and  " +
                            " LeaveStartDate >='01-Mar-" + nStartYear + "' and Status in (2) and  " +
                            " LeaveEndDate < '01-Mar-" + nNextYear + "' group by LeaveType) z " +
                            " on x.LeaveType=z.LeaveType ";

                        

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeLeave oEmployeeLeave = new EmployeeLeave();

                    oEmployeeLeave.LeaveType = (int)reader["LeaveType"];
                    oEmployeeLeave.LeaveTypeName = (string)reader["LeaveTypeName"];
                    oEmployeeLeave.LeaveAllowed = (int)reader["LeaveAllowed"];
                    if (reader["Prposed"] != DBNull.Value)
                        oEmployeeLeave.Prposed = (double)reader["Prposed"];
                    else oEmployeeLeave.Prposed = 0;
                    if (reader["UtilizedTillDate"] != DBNull.Value)
                        oEmployeeLeave.UtilizedTillDate = (double)reader["UtilizedTillDate"];
                    else oEmployeeLeave.UtilizedTillDate = 0;
                    if (reader["Totalutilized"] != DBNull.Value)
                        oEmployeeLeave.Totalutilized = (double)reader["Totalutilized"];
                    else oEmployeeLeave.Totalutilized = 0;

                    InnerList.Add(oEmployeeLeave);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetLeaveByEmployeeStuff(int nEmployeeID)
        {

            DateTime CurrentDate = DateTime.Today.Date;

            int nMonth = CurrentDate.Month;
            int nYear = CurrentDate.Year;
            int nNextYear = nYear + 1;
            int nStartYear;

            if (nMonth == 1 || nMonth == 2)
            {
                nStartYear = nYear - 1;
            }
            else
            {
                nStartYear = nYear;
            }

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select x.*,isnull(Prposed,0) Prposed,isnull(UtilizedTillDate,0) UtilizedTillDate, " +
                            " isnull(Prposed,0) + isnull(UtilizedTillDate,0) as Totalutilized From  " +
                            " (Select * From  " +
                            " (Select EmployeeID,LeaveType,LeaveTypename,  " +
                            " LeaveAllowed from t_leaveStuff a,t_Employee b where LeaveType in (0,2)  " +
                            " Union All  " +
                            " Select EmployeeID,LeaveType,LeaveTypename,  " +
                            " LeaveAllowed=Case when EMPStatus=2 and TotalConfirmDate>=365 then LeaveAllowed   " +
                            " when EMPStatus<>2 then 0 else 30 end From   " +
                            " (Select EmployeeID,LeaveType,LeaveTypename,LeaveAllowed,EMPStatus,  " +
                            " DATEDIFF(day,ConfirmDate,Getdate()) TotalConfirmDate  " +
                            " from t_leaveStuff a,t_Employee b where LeaveType=1) x  " +
                            " Union All  " +
                            " Select EmployeeID,LeaveType,LeaveTypename,  " +
                            " LeaveAllowed=Case when Gender='Female' then LeaveAllowed else 0 end  " +
                            " from t_leaveStuff a,t_Employee b where  LeaveType=3  " +
                            " Union All  " +
                            " Select EmployeeID,LeaveType,LeaveTypename,  " +
                            " LeaveAllowed=Case when Gender='Male' and EMPStatus=2 then LeaveAllowed else 0 end  " +
                            " from t_leaveStuff a,t_Employee b where LeaveType=4) Main    " +
                            " where EmployeeID=" + nEmployeeID + " and LeaveAllowed>0  " +
                            " ) x " +
                            " Left Outer join  " +
                            " (Select LeaveType, Sum(CASE when Status in (1,5,6) then LeaveTotal else 0 end) as Prposed " +
                            " from t_EmployeeLeaveTemp Where EmployeeID=" + nEmployeeID + " and  " +
                            " LeaveStartDate >='01-Jan-" + nStartYear + "' and Status not in (2,3,4) and  " +
                            " LeaveEndDate < '01-Jan-" + nNextYear + "' group by LeaveType) y " +
                            " on x.LeaveType=y.LeaveType " +
                            " Left Outer Join  " +
                            " (Select LeaveType, Sum(CASE when Status=2 then LeaveTotal else 0 end) as UtilizedTillDate  " +
                            " from t_EmployeeLeave Where EmployeeID=" + nEmployeeID + " and  " +
                            " LeaveStartDate >='01-Jan-" + nStartYear + "' and Status in (2) and  " +
                            " LeaveEndDate < '01-Jan-" + nNextYear + "' group by LeaveType) z " +
                            " on x.LeaveType=z.LeaveType ";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeLeave oEmployeeLeave = new EmployeeLeave();

                    oEmployeeLeave.LeaveType = (int)reader["LeaveType"];
                    oEmployeeLeave.LeaveTypeName = (string)reader["LeaveTypeName"];
                    oEmployeeLeave.LeaveAllowed = (int)reader["LeaveAllowed"];
                    if (reader["Prposed"] != DBNull.Value)
                        oEmployeeLeave.Prposed = (double)reader["Prposed"];
                    else oEmployeeLeave.Prposed = 0;
                    if (reader["UtilizedTillDate"] != DBNull.Value)
                        oEmployeeLeave.UtilizedTillDate = (double)reader["UtilizedTillDate"];
                    else oEmployeeLeave.UtilizedTillDate = 0;
                    if (reader["Totalutilized"] != DBNull.Value)
                        oEmployeeLeave.Totalutilized = (double)reader["Totalutilized"];
                    else oEmployeeLeave.Totalutilized = 0;

                    InnerList.Add(oEmployeeLeave);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLeaveType()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_Leave";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeLeave oLeave = new EmployeeLeave();
                    oLeave.LeaveType = (int)reader["LeaveType"];
                    oLeave.LeaveTypeName = (string)reader["LeaveTypeName"];
                    oLeave.LeaveAllowed = (int)reader["LeaveAllowed"];
                    InnerList.Add(oLeave);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshTemp()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_EmployeeLeaveTemp";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeLeave oEmployeeLeaveTemp = new EmployeeLeave();
                    oEmployeeLeaveTemp.LeaveID = (int)reader["LeaveID"];
                    oEmployeeLeaveTemp.EmployeeID = (int)reader["EmployeeID"];
                    oEmployeeLeaveTemp.InChargeID = (int)reader["InChargeID"];
                    oEmployeeLeaveTemp.LeaveType = (int)reader["LeaveType"];
                    oEmployeeLeaveTemp.LeaveStartDate = Convert.ToDateTime(reader["LeaveStartDate"].ToString());
                    oEmployeeLeaveTemp.LeaveEndDate = Convert.ToDateTime(reader["LeaveEndDate"].ToString());
                    oEmployeeLeaveTemp.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    oEmployeeLeaveTemp.Reason = (string)reader["Reason"];
                    oEmployeeLeaveTemp.Address = (string)reader["Address"];
                    oEmployeeLeaveTemp.MobileNo = (string)reader["MobileNo"];
                    oEmployeeLeaveTemp.EmailAddress = (string)reader["Emailaddress"];
                    oEmployeeLeaveTemp.Status = (int)reader["Status"];
                    oEmployeeLeaveTemp.LeaveTotal = Convert.ToDouble(reader["LeaveTotal"].ToString());
                    oEmployeeLeaveTemp.PartialType = (int)reader["PartialType"];
                    oEmployeeLeaveTemp.CreateUserID = (int)reader["CreateUserID"];
                    oEmployeeLeaveTemp.UpdateUserID = (int)reader["UpdateUserID"];
                    oEmployeeLeaveTemp.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oEmployeeLeaveTemp.ApprovedUserID = (int)reader["ApprovedUserID"];
                    oEmployeeLeaveTemp.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"].ToString());
                    oEmployeeLeaveTemp.RejectUserID = (int)reader["RejectUserID"];
                    oEmployeeLeaveTemp.RejectDate = Convert.ToDateTime(reader["RejectDate"].ToString());
                    InnerList.Add(oEmployeeLeaveTemp);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByUserWise(bool nIsFactoryEmployee, int nCompanyID, int nEmployeeID, DateTime dFromDate, DateTime dToDate, string sEmployeeCode, string sEmployeeName, string sDepartment, int nLeaveType, int nStatus, bool IsCheck)
        {
            DateTime _dToDate = dToDate.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From  (" +
                        "Select * From  "+
                        " (SELECT LeaveID,a.EmployeeID,InChargeID,LeaveTotal,EmployeeCode,EmployeeName,LeaveType,   "+
                        " LeaveStartDate,LeaveEndDate,EntryDate,Address,  "+
                        " a.MobileNo,Emailaddress,Reason,Status,DepartmentName,DesignationName,PartialType,   "+
                        " UpdateUserID, UpdateDate, ApprovedUserID,    "+
                        " ApprovedDate,CreateUserID,RejectUserID,RejectDate, 1 as IsTemp, IsFactoryEmployee,CompanyID    " +
                        " FROM t_Employee d,t_EmployeeLeaveTemp a,t_Department b,t_designation c   "+
                        " Where d.EmployeeID=a.EmployeeID and d.DepartmentID=b.DepartmentID and d.DesignationID=c.DesignationID   "+
                        " and InchargeID is not Null   "+
                        " and a.EmployeeID in (Select distinct EmployeeID From    "+
                        " (select EmployeeID from t_EmployeeLineManager where LineManagerID=" + nEmployeeID + "  " +
                        " Union All      "+
                        " Select EmployeeID From t_EmployeeLeaveTemp where InChargeID=" + nEmployeeID + "  " +
                        " Union All    "+
                        " Select EmployeeID From v_EmployeeDetails a,t_UserPermissionData b,t_UserPermissionData c  "+
                        " where b.DataID=a.CompanyID and c.DataID=a.DepartmentID and   "+
                        " b.DataType='Company' and c.DataType='Department' and b.UserID=" + Utility.UserId + " and  c.UserID=" + Utility.UserId + "    " +
                        " Union All   " +
                        " Select EmployeeID From t_EmployeeLeaveTemp where EmployeeID=" + nEmployeeID + ") x) and Status<>2 ) Main " +
                        
                        " Union All  "+

                        " Select * From  " +
                        " (SELECT LeaveID,a.EmployeeID,InChargeID,LeaveTotal,EmployeeCode,EmployeeName,LeaveType,   " +
                        " LeaveStartDate,LeaveEndDate,EntryDate,Address,  " +
                        " a.MobileNo,Emailaddress,Reason,Status,DepartmentName,DesignationName,PartialType,   " +
                        " UpdateUserID, UpdateDate, ApprovedUserID,    " +
                        " ApprovedDate,CreateUserID,RejectUserID,RejectDate,0 as IsTemp, IsFactoryEmployee,CompanyID    " +
                        " FROM t_Employee d,t_EmployeeLeave a,t_Department b,t_designation c   " +
                        " Where d.EmployeeID=a.EmployeeID and d.DepartmentID=b.DepartmentID and d.DesignationID=c.DesignationID   " +
                        " and InchargeID is not Null   " +
                        " and a.EmployeeID in (Select distinct EmployeeID From    " +
                        " (select EmployeeID from t_EmployeeLineManager where LineManagerID=" + nEmployeeID + "  " +
                        " Union All      " +
                        " Select EmployeeID From t_EmployeeLeave where InChargeID=" + nEmployeeID + "  " +
                        " Union All    " +
                        " Select EmployeeID From v_EmployeeDetails a,t_UserPermissionData b,t_UserPermissionData c  " +
                        " where b.DataID=a.CompanyID and c.DataID=a.DepartmentID and   " +
                        " b.DataType='Company' and c.DataType='Department' and b.UserID=" + Utility.UserId + " and  c.UserID=" + Utility.UserId + "    " +
                        " Union All   " +
                        " Select EmployeeID From t_EmployeeLeave where EmployeeID=" + nEmployeeID + ") x)) Main  "+
                        " ) xxx where 1=1";




            if (IsCheck == false)
            {
                sSql = sSql + " AND EntryDate BETWEEN '" + dFromDate + "' AND '" + _dToDate + "' AND EntryDate < '" + _dToDate + "' ";
            }
            if (sEmployeeCode != "")
            {
                sSql = sSql + " AND EmployeeCode LIKE '%" + sEmployeeCode + "%'";
            }

            if (sEmployeeName != "")
            {
                sSql = sSql + " AND EmployeeName LIKE '%" + sEmployeeName + "%'";
            }
            if (sDepartment != "--All Department--")
            {
                sSql = sSql + " AND DepartmentName = '" + sDepartment + "'  ";
            }
            if (nLeaveType >= 0)
            {
                sSql = sSql + " AND LeaveType = " + nLeaveType + "";
            }
            if (nStatus >= 0)
            {
                sSql = sSql + " AND Status = " + nStatus + "";
            }
            if (nCompanyID > 0)
            {
                sSql = sSql + " AND CompanyID = " + nCompanyID + "";
            }

            if (nIsFactoryEmployee==true)
            {
                sSql = sSql + " and IsFactoryEmployee = 1";
            }

            sSql = sSql + " ORDER by EntryDate DESC";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeLeave oEmployeeLeave = new EmployeeLeave();


                    oEmployeeLeave.LeaveID = (int)reader["LeaveID"];
                    oEmployeeLeave.EmployeeID = (int)reader["EmployeeID"];
                    oEmployeeLeave.EmployeeCode = (string)reader["EmployeeCode"];
                    oEmployeeLeave.EmployeeName = (string)reader["EmployeeName"];
                    if (reader["InChargeID"] != DBNull.Value)
                        oEmployeeLeave.InChargeID = Convert.ToInt32(reader["InChargeID"]);
                    else oEmployeeLeave.InChargeID = 0;
                    if (reader["LeaveTotal"] != DBNull.Value)
                        oEmployeeLeave.LeaveTotal = Convert.ToInt32(reader["LeaveTotal"]);
                    else oEmployeeLeave.LeaveTotal = 0;
                    oEmployeeLeave.LeaveType = (int)reader["LeaveType"];
                    oEmployeeLeave.LeaveStartDate = Convert.ToDateTime(reader["LeaveStartDate"].ToString());
                    oEmployeeLeave.LeaveEndDate = Convert.ToDateTime(reader["LeaveEndDate"].ToString());
                    oEmployeeLeave.EntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    if (reader["Address"] != DBNull.Value)
                        oEmployeeLeave.Address = (string)reader["Address"];
                    else oEmployeeLeave.Address = "";
                    if (reader["MobileNo"] != DBNull.Value)
                        oEmployeeLeave.MobileNo = (string)reader["MobileNo"];
                    else oEmployeeLeave.MobileNo = "";
                    if (reader["Emailaddress"] != DBNull.Value)
                        oEmployeeLeave.EmailAddress = (string)reader["Emailaddress"];
                    else oEmployeeLeave.EmailAddress = "";
                    if (reader["Status"] != DBNull.Value)
                        oEmployeeLeave.Status = Convert.ToInt32(reader["Status"]);
                    else oEmployeeLeave.Status = 0;
                    oEmployeeLeave.Reason = (string)reader["Reason"];
                    oEmployeeLeave.DepartmentName = (string)reader["DepartmentName"];
                    oEmployeeLeave.DesignationName = (string)reader["DesignationName"];


                    if (reader["PartialType"] != DBNull.Value)
                    {
                        oEmployeeLeave.PartialType = (int)reader["PartialType"];
                    }
                    else
                    {
                        oEmployeeLeave.PartialType = 0;
                    }

                    oEmployeeLeave.IsTemp = (int)reader["IsTemp"];

                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oEmployeeLeave.UpdateUserID = (int)reader["UpdateUserID"];
                    }
                    else
                    {
                        oEmployeeLeave.UpdateUserID = 0;
                    }
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oEmployeeLeave.UpdateDate = Convert.ToDateTime(reader["UpdateDate"]);
                    }
                    else
                    {
                        oEmployeeLeave.UpdateDate = DateTime.Now.Date;
                    }
                    if (reader["ApprovedUserID"] != DBNull.Value)
                    {
                        oEmployeeLeave.ApprovedUserID = (int)reader["ApprovedUserID"];
                    }
                    else
                    {
                        oEmployeeLeave.ApprovedUserID = 0;
                    }
                    if (reader["ApprovedDate"] != DBNull.Value)
                    {
                        oEmployeeLeave.ApprovedDate = Convert.ToDateTime(reader["ApprovedDate"]);
                    }
                    else
                    {
                        oEmployeeLeave.ApprovedDate = DateTime.Now.Date;
                    }
                    if (reader["CreateUserID"] != DBNull.Value)
                    {
                        oEmployeeLeave.CreateUserID = (int)reader["CreateUserID"];
                    }
                    else
                    {
                        oEmployeeLeave.CreateUserID = 0;
                    }
                    if (reader["RejectUserID"] != DBNull.Value)
                    {
                        oEmployeeLeave.RejectUserID = (int)reader["RejectUserID"];
                    }
                    else
                    {
                        oEmployeeLeave.RejectUserID = 0;
                    }
                    if (reader["RejectDate"] != DBNull.Value)
                    {
                        oEmployeeLeave.RejectDate = Convert.ToDateTime(reader["RejectDate"]);
                    }
                    else
                    {
                        oEmployeeLeave.RejectDate = DateTime.Now.Date;
                    }

                    InnerList.Add(oEmployeeLeave);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetFactoryLeaveByEmployee(int nEmployeeID,DateTime dFromDate, DateTime dTodate, int nLeaveType)
        {

            DateTime CurrentDate = DateTime.Today.Date;

            int nMonth = CurrentDate.Month;
            int nYear = CurrentDate.Year;
            int nNextYear = nYear + 1;
            int nStartYear;

            if (nMonth == 1 || nMonth == 2)
            {
                nStartYear = nYear - 1;
            }
            else
            {
                nStartYear = nYear;
            }

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"select EntryDate,ApprovedDate,RejectReason,LeaveTotal from t_EmployeeLeaveTemp 
                           where LeaveType="+ nLeaveType + " and Status in(2,3) and  EmployeeID=" + nEmployeeID+" and LeaveStartDate>='01-MAR-2021' and LeaveEndDate<'01-MAR-2022'";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeLeave oEmployeeLeave = new EmployeeLeave();

                    oEmployeeLeave.EntryDate = (DateTime)reader["EntryDate"];
                    oEmployeeLeave.ApprovedDate = (DateTime)reader["ApprovedDate"];
                    try
                    {
                        oEmployeeLeave.RejectReason = (string)reader["RejectReason"];
                    }
                    catch
                    {

                        oEmployeeLeave.RejectReason = "";
                    }
                    oEmployeeLeave.LeaveTotal = (double)reader["LeaveTotal"];
                    //if (reader["Prposed"] != DBNull.Value)
                    //    oEmployeeLeave.Prposed = (double)reader["Prposed"];
                    //else oEmployeeLeave.Prposed = 0;
                    //if (reader["UtilizedTillDate"] != DBNull.Value)
                    //    oEmployeeLeave.UtilizedTillDate = (double)reader["UtilizedTillDate"];
                    //else oEmployeeLeave.UtilizedTillDate = 0;
                    //if (reader["Totalutilized"] != DBNull.Value)
                    //    oEmployeeLeave.Totalutilized = (double)reader["Totalutilized"];
                    //else oEmployeeLeave.Totalutilized = 0;

                    InnerList.Add(oEmployeeLeave);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetLeaveAllowedByEmployee(string sEmployeeCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"Select * From 
                        (
                        select EmployeeCode, EmployeeID, LeaveType, LeaveTypeName,
                        case when LeaveType = 0 then LeaveAllowed
                        when LeaveType = 1 and EMPStatus = 1 then 0
                        when LeaveType = 1 and EMPStatus = 2 and DATEDIFF(day, ConfirmDate, Getdate()) >= 365 then LeaveAllowed
                        when LeaveType = 1 and EMPStatus = 2 and DATEDIFF(day, ConfirmDate, Getdate()) < 365 then 30
                        when LeaveType = 2 then LeaveAllowed
                        when LeaveType = 3 and Gender = 'Female' then LeaveAllowed
                        when LeaveType = 4 and Gender = 'Male' and EMPStatus = 2 then LeaveAllowed
                        else 0 end LeaveAllowed from t_leave a, t_Employee b where EMPStatus in (1, 2)
                        ) Main where EmployeeCode = '" + sEmployeeCode + "' and LeaveAllowed> 0";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeLeave oLeave = new EmployeeLeave();
                    oLeave.EmployeeCode = (string)reader["EmployeeCode"];
                    oLeave.EmployeeID = (int)reader["EmployeeID"];
                    oLeave.LeaveType = (int)reader["LeaveType"];
                    oLeave.LeaveTypeName = (string)reader["LeaveTypeName"];
                    oLeave.LeaveAllowed = (int)reader["LeaveAllowed"];
                    InnerList.Add(oLeave);
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





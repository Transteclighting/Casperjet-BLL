// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: July 19, 2012
// Time :  2:20 PM
// Description: Class for Vehicle Sehedule History Data.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.CSD;

namespace CJ.Class.CSD
{
    public class VehicleScheduleHistory
    {

        private int _nVRHistoryID;
        private int _nVRID;
        private int _nUserID;
        private string _sUserName;
        private int _nStatus;
        private string _sStatusName;
        private DateTime _dStatusDate;
        private Object _sRemarks;
        private Object _dDates;
        private Object _dTimeFrom;
        private Object _dTimeTo;

        private User _oUser;
        private VehicleSchedule _oVehicleSchedule;

        /// <summary>
        /// Get set property for VRHistoryID
        /// </summary>
        public int VRHistoryID
        {
            get { return _nVRHistoryID; }
            set { _nVRHistoryID = value; }
        }
        /// <summary>
        /// Get set property for VRID
        /// </summary>
        public int VRID
        {
            get { return _nVRID; }
            set { _nVRID = value; }
        }
        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }
        /// <summary>
        /// Get set property for UserName
        /// </summary>
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }
        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        /// <summary>
        /// Get set property for StatusName
        /// </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }
        /// <summary>
        /// Get set property for StatusDate
        /// </summary>
        public DateTime StatusDate
        {
            get { return _dStatusDate; }
            set { _dStatusDate = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public Object Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        /// <summary>
        /// Get set property for Dates
        /// </summary>
        public Object Dates
        {
            get { return _dDates; }
            set { _dDates = value; }
        }
        /// <summary>
        /// Get set property for TimeFrom
        /// </summary>
        public Object TimeFrom
        {
            get { return _dTimeFrom; }
            set { _dTimeFrom = value; }
        }
        /// <summary>
        /// Get set property for TimeTo
        /// </summary>
        public Object TimeTo
        {
            get { return _dTimeTo; }
            set { _dTimeTo = value; }
        }

        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                    _oUser.UserId = _nUserID;
                    _oUser.RefreshByUserID();
                }
                return _oUser;
            }
        }
        public VehicleSchedule VehicleSchedule
        {
            get
            {
                if (_oVehicleSchedule == null)
                {
                    _oVehicleSchedule = new VehicleSchedule();
                }
                return _oVehicleSchedule;
            }
        }
        public void AddVehicleScheduleHistory()
        {
            int nMaxVRHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([VRHistoryID]) FROM t_CSDVehicleRequisitionHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVRHistoryID = 1;
                }
                else
                {
                    nMaxVRHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nVRHistoryID = nMaxVRHistoryID;


                sSql = "INSERT INTO t_CSDVehicleRequisitionHistory(VRHistoryID,VRID,UserID,Status,StatusDate,Remarks,Dates,TimeFrom, TimeTo) VALUES(?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VRHistoryID", _nVRHistoryID);
                cmd.Parameters.AddWithValue("VRID", _nVRID);
                cmd.Parameters.AddWithValue("UserID", Utility.UserId);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("StatusDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Dates", _dDates);
                cmd.Parameters.AddWithValue("TimeFrom", _dTimeFrom);
                cmd.Parameters.AddWithValue("TimeTo", _dTimeTo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateHistoryRemarks()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = "Update t_CSDVehicleRequisitionHistory SET Remarks=?, Dates=?, TimeFrom=?, TimeTo=? Where VRID=? and Status=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Dates", _dDates);
                cmd.Parameters.AddWithValue("TimeFrom", _dTimeFrom);
                cmd.Parameters.AddWithValue("TimeTo", _dTimeTo);

                cmd.Parameters.AddWithValue("VRID", _nVRID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh()
        {
         
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDVehicleRequisitionHistory where VRID=?";
            cmd.Parameters.AddWithValue("VRID", _nVRID);
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _dStatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    _nStatus = int.Parse(reader["Status"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _nUserID = (int)reader["UserID"];
                    _dDates = (Object)reader["Dates"].ToString();
                    _dTimeFrom = (Object)reader["TimeFrom"].ToString();
                    _dTimeTo = (Object)reader["TimeTo"].ToString();
                    
                }
                reader.Close();             

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckVRHistory()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDVehicleRequisitionHistory where VRID=? and Status=?";
            cmd.Parameters.AddWithValue("VRID", _nVRID);
            cmd.Parameters.AddWithValue("Status", _nStatus);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _dStatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    _nStatus = int.Parse(reader["Status"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _nUserID = (int)reader["UserID"];
                    _dDates = (Object)reader["Dates"].ToString();
                    _dTimeFrom = (Object)reader["TimeFrom"].ToString();
                    _dTimeTo = (Object)reader["TimeTo"].ToString();
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return false;
            else return true;
        }
    }
    public class VehicleScheduleHistorys : CollectionBase
    {
        public VehicleScheduleHistory this[int i]
        {
            get { return (VehicleScheduleHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(VehicleScheduleHistory oVehicleScheduleHistory)
        {
            InnerList.Add(oVehicleScheduleHistory);
        }
        public void Refresh()//String txtPaidJobID
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select VRHistoryID,VRID,StatusDate, Dates,TimeFrom,TimeTo,UserName,StatusName,Status,UserID,Remarks from " +
                            "( "+
                            "SELECT VRHistoryID,VRID,StatusDate,UserName, Remarks,Status,RH.UserID UserID, " +
                            "StatusName=CASE  "+
                            "When Status=0 Then 'Requisition' "+
                            "When Status=1 Then 'Schedule'  "+
                            "When Status=2 Then 'ReSchedule'  "+
                            "When Status=3 Then 'Done'  "+
                            "When Status=4 Then 'Suspend'  "+
                            "When Status=5 Then 'Cancel'  "+
                            "End,  "+
                            "RTRIM(RIGHT(CONVERT(varchar, Dates, 105),11)) Dates,  "+
                            "RTRIM(RIGHT(CONVERT(varchar, TimeFrom, 100),7))TimeFrom,  "+
                            "RTRIM(RIGHT(CONVERT(varchar, TimeTo, 100),7))TimeTo  "+
                            "FROM t_CSDVehicleRequisitionHistory RH INNER JOIN t_user U ON U.UserID=RH.UserID)A "+
                            "Order by StatusDate ";

            //if (txtPaidJobID != "")
            //{
            //    //txtPaidJobID = "%" + txtPaidJobID + "%";
            //    sSql = sSql + " AND PaidJobID ='" + txtPaidJobID + "'";
            //}

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleScheduleHistory oVehicleScheduleHistory = new VehicleScheduleHistory();

                    oVehicleScheduleHistory.VRID = (int)reader["VRID"];
                    oVehicleScheduleHistory.StatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    oVehicleScheduleHistory.Status = int.Parse(reader["Status"].ToString());
                    oVehicleScheduleHistory.Remarks = (string)reader["Remarks"];
                    oVehicleScheduleHistory.UserID = (int)reader["UserID"];
                    oVehicleScheduleHistory.Dates = (Object)reader["Dates"].ToString();
                    oVehicleScheduleHistory.TimeFrom = (Object)reader["TimeFrom"].ToString();
                    oVehicleScheduleHistory.TimeTo = (Object)reader["TimeTo"].ToString();

                    InnerList.Add(oVehicleScheduleHistory);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByID(int nVRID)//String txtPaidJobID
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select VRHistoryID,VRID,StatusDate,Dates,TimeFrom,TimeTo,UserName,StatusName,Status,UserID,Remarks from " +
                            "( " +
                            "SELECT VRHistoryID,VRID,StatusDate,UserName, Remarks,Status,RH.UserID UserID, " +
                            "StatusName=CASE  " +
                            "When Status=0 Then 'Requisition' " +
                            "When Status=1 Then 'Schedule'  " +
                            "When Status=2 Then 'ReSchedule'  " +
                            "When Status=3 Then 'Done'  " +
                            "When Status=4 Then 'Suspend'  " +
                            "When Status=5 Then 'Cancel'  " +
                            "End,  " +
                            "RTRIM(RIGHT(CONVERT(varchar, Dates, 105),11)) Dates,  " +
                            "RTRIM(RIGHT(CONVERT(varchar, TimeFrom, 100),7))TimeFrom,  " +
                            "RTRIM(RIGHT(CONVERT(varchar, TimeTo, 100),7))TimeTo  " +
                            "FROM t_CSDVehicleRequisitionHistory RH INNER JOIN t_user U ON U.UserID=RH.UserID)A " +
                            "where VRID=?";


            cmd.Parameters.AddWithValue("VRID", nVRID);

            //if (txtPaidJobID != "")
            //{
            //    //txtPaidJobID = "%" + txtPaidJobID + "%";
            //    sSql = sSql + " AND PaidJobID ='" + txtPaidJobID + "'";
            //}

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleScheduleHistory oVehicleScheduleHistory = new VehicleScheduleHistory();
                    oVehicleScheduleHistory.VRID = (int)reader["VRID"];
                    oVehicleScheduleHistory.StatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    oVehicleScheduleHistory.Status = int.Parse(reader["Status"].ToString());
                    oVehicleScheduleHistory.Remarks = (Object)reader["Remarks"].ToString();
                    oVehicleScheduleHistory.UserID = (int)reader["UserID"];
                    oVehicleScheduleHistory.UserName = (string)reader["UserName"];
                    oVehicleScheduleHistory.StatusName = (string)reader["StatusName"];
                    oVehicleScheduleHistory.Dates = (Object)reader["Dates"].ToString();
                    oVehicleScheduleHistory.TimeFrom = (Object)reader["TimeFrom"].ToString();
                    oVehicleScheduleHistory.TimeTo = (Object)reader["TimeTo"].ToString();


                    InnerList.Add(oVehicleScheduleHistory);
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


